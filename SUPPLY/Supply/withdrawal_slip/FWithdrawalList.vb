Imports System.ComponentModel
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports OfficeOpenXml.ExcelErrorValue

Public Class FWithdrawalList
    Public sqlcon As New SQLcon
    Dim panloc As New Point(0, 0)
    Dim curloc As New Point(0, 0)
    Public ws_id_count As Integer
    Dim thread, thread1 As System.Threading.Thread
    Dim abortsearching As String


    Dim SaveFileDialog1 As New SaveFileDialog
    Dim xls As New Excel.Application
    Dim book As Excel.Workbook
    Dim sheet As Excel.Worksheet


    Private Withdrawal_Data As New Model._Mod_Withdrawal
    Private cListofListview As New List(Of ListViewItem)
    Private cListOfWs
    Private cListOfWithdrawnItems As New List(Of PropsFields.withdrawn_props_fields)
    Public cListOfPartiallyWithdrawn As New List(Of PropsFields.partiallyWithdrawn_props_fields)
    Private cListofWithdrawal As New List(Of PropsFields.withdrawal_props_fields)
    Private cListOfCancelledTransaction As New List(Of PropsFields.CancelledTransaction)

    Private customMsg As New customMessageBox
    Private cProperNames As New Model_ProperNames
    Private whItemsModel As New ModelNew.Model
    Private withdrawnModel As New ModelNew.Model
    Private partiallyWithdrawnModel As New ModelNew.Model
    Private employeesModel As New ModelNew .Model
    Private withdrawalModel,
        serialNoViewModel,
        cancelledTransactionModel As New ModelNew.Model

    Private cRowColor As New RowColor

    Private newAuth As New authType
    Public loadingStat As Integer
    Public cPartiallyWithdrawnId As Integer
    Public cSearchByEnum As New searchByEnum

    Private searchUI As New class_placeholder5
    Private dateFromUI, dateToUI, searchInPanel As New class_placeholder5
    Public isEdit As Boolean
    Public cWsId As Integer
    Private cLoadType As Integer

    Private cSomeComponents As New ColumnValuesObj
    Private cWITHRAWALLISTMODEL As New WithdrawalListModel

    Public Class RowColor
        Public Property released As Color = Color.LightGreen
        Public Property withdrawn As Color = Color.LightYellow
    End Class

    Public Enum LoadingStatus
        all = 1
        partiallyWithdrawn
        withdrawalReleased
        cancelWithdrawn
        withdraw
    End Enum

    Public Class searchByEnum

        Public ReadOnly Property search_by_ws_no As String = "Search by WS No."
        Public ReadOnly Property search_by_rs_no As String = "Search by RS No."
        Public ReadOnly Property search_by_charges As String = "Search by Charges"
        Public ReadOnly Property search_by_items As String = "Search by Items"
        Public ReadOnly Property search_by_users As String = "Search by Users"
        Public ReadOnly Property search_by_withdrawn_by As String = "Search by withdrawn by"
        Public ReadOnly Property search_released_by As String = "Search by released by"
        Public ReadOnly Property search_by_date_issued As String = "Search by Date Issued"
        Public ReadOnly Property search_by_date_withdrawn As String = "Search by Date Withdrawn"
        Public ReadOnly Property search_by_issued_by As String = "Search by Issued by"
        Public ReadOnly Property search_by_received_by As String = "Search by Received by"
        Public ReadOnly Property search_by_released_by As String = "Search by Released by"


    End Class

    Public ReadOnly Property getcListOfWithdrawnItems() As List(Of PropsFields.withdrawn_props_fields)
        Get
            Return cListOfWithdrawnItems
        End Get
    End Property

    Public ReadOnly Property ListOfPartiallyWithdrawn() As List(Of PropsFields.partiallyWithdrawn_props_fields)
        Get
            Return cListOfPartiallyWithdrawn
        End Get
    End Property

    Private Sub setpositions()
        panloc = panel_fdate.Location
        curloc = System.Windows.Forms.Cursor.Position
    End Sub
    Dim cBgWorkerChecker As Timer
    Private cListOfColName As New List(Of ColumnHeader)
    Private rearrangeLvl As New ListTabIndex
    Private Sub registerRow()
        'With cListOfColName
        '    .Add(col_ws_id)
        '    .Add(col_date_withdrawn)
        '    .Add(col_charge_to)
        '    .Add(col_rs_no)
        '    .Add(col_ws_no)
        '    .Add(col_item_name)
        '    .Add(col_item_desc)
        '    .Add(col_qty)
        '    .Add(col_unit)
        '    .Add(col_unit_price)
        '    .Add(col_amount)
        '    .Add(col_issued_by)
        '    .Add(col_released_by)
        '    .Add(col_withdrwan_received_by)
        '    .Add(col_status)
        '    .Add(col_dr_option)
        '    .Add(col_withdrawn_from)
        '    .Add(col_purpose)
        '    .Add(col_user)
        '    .Add(col_remarks)
        '    .Add(col_ws_info_id)
        '    .Add(col_partially_withdrawn_id)
        '    .Add(col_rs_id)
        '    .Add(col_withdrawn_id)
        '    .Add(col_wh_id)
        'End With

        With rearrangeLvl
            .addColumns(col_ws_id)
            .addColumns(col_date_withdrawn)
            .addColumns(col_charge_to)
            .addColumns(col_rs_no)
            .addColumns(col_ws_no)
            .addColumns(col_item_name)
            .addColumns(col_item_desc)
            .addColumns(col_qty)
            .addColumns(col_unit)
            .addColumns(col_unit_price)
            .addColumns(col_amount)
            .addColumns(col_issued_by)
            .addColumns(col_released_by)
            .addColumns(col_withdrwan_received_by)
            .addColumns(col_status)
            .addColumns(col_dr_option)
            .addColumns(col_withdrawn_from)
            .addColumns(col_purpose)
            .addColumns(col_user)
            .addColumns(col_remarks)
            .addColumns(col_ws_info_id)
            .addColumns(col_partially_withdrawn_id)
            .addColumns(col_rs_id)
            .addColumns(col_withdrawn_id)

        End With

    End Sub
    Private Sub FWithdrawalList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        registerRow()

#Region "REARRANGE TABINDEX"
        'For Each columnHeader As ColumnHeader In cListOfColName
        '    columnHeader.DisplayIndex = cListOfColName.IndexOf(columnHeader)
        'Next
        rearrangeLvl.rearrangeTabIndex()

#End Region

        Timer_panelMvment.Interval = "1"
        panel_fdate.Visible = False
        Label15.Parent = pboxHeader

        cmbSearchByCategory.Text = "Search by WS No."
        'btnSearch.PerformClick()

        Dim searchby As New class_placeholder4
        Dim search As New class_placeholder4

        searchby.king_placeholder_combobox("Search By", cmbSearchByCategory, Nothing, Panel1, My.Resources.categories, "White")
        'search.king_placeholder_textbox("Search Here...", txtSearch, Nothing, Panel1, My.Resources.search, False, "White")

        searchUI.king_placeholder_textbox("Search by...", txtSearch, Nothing, Panel1, My.Resources.received, False, searchUI.cCustomColor.Custom1)
        searchInPanel.king_placeholder_textbox("Search here...", txtSearchWithDateRange, Nothing, panel_fdate, My.Resources.received, False, searchUI.cCustomColor.Custom1)
        dateFromUI.king_placeholder_datepicker("", DTP_dateFROM, panel_fdate, My.Resources.received, dateFromUI.cCustomColor.Custom1)
        dateToUI.king_placeholder_datepicker("", DTP_dateTO, panel_fdate, My.Resources.received, dateFromUI.cCustomColor.Custom1)

        cProperNames.initialize(Panel3)
        cProperNames.loadProperNames()

        'add search category
        With cmbSearchByCategory.Items

            .Add(cSearchByEnum.search_by_ws_no)
            .Add(cSearchByEnum.search_by_rs_no)
            .Add(cSearchByEnum.search_by_charges)
            .Add(cSearchByEnum.search_by_items)
            .Add(cSearchByEnum.search_by_users)
            .Add(cSearchByEnum.search_by_withdrawn_by)
            .Add(cSearchByEnum.search_released_by)
            .Add(cSearchByEnum.search_by_date_withdrawn)
            .Add(cSearchByEnum.search_by_issued_by)
            .Add(cSearchByEnum.search_by_received_by)
            .Add(cSearchByEnum.search_by_released_by)
            .Add(cSearchByEnum.search_by_date_issued)

        End With

        'With cWITHRAWALLISTMODEL
        '    .initialize_loadingPanel(loadingPanel)
        '    .initialize_listview(lvlwithdrawalList)
        '    .initialize_dataGridView(DataGridView1)
        '    .initialize_data()
        'End With

        loadWhItems()

    End Sub

    Public Sub loadWhItems()

        'loadingPanel.Visible = True

        Dim values As New Dictionary(Of String, String)
        Dim cancelledTransactionValues As New ColumnValues
        'cSomeComponents.clearParameter()
        'serialNoViewModel.clearParameter()
        'withdrawnModel.clearParameter()
        'partiallyWithdrawnModel.clearParameter()
        clear()

        cSomeComponents.add(GetType(Button).ToString, btnSearch)
        cSomeComponents.add("loadingPanel", loadingPanel)

        disableEnableWhileLoading(cSomeComponents.getValues(), False)

        _initializing(cCol.forTireSerialNoView,
                          values,
                          serialNoViewModel,
                          WhItemsBgWorker)

        _initializing(cCol.forCancelRs,
                          cancelledTransactionValues.getValues(),
                          cancelledTransactionModel,
                          WhItemsBgWorker)

        If loadingStat = LoadingStatus.partiallyWithdrawn Then

            _initializing(cCol.forWithdrawn,
                         values,
                         withdrawnModel,
                         WhItemsBgWorker)

            _initializing(cCol.forPartiallyWithdrawn,
                        values,
                        partiallyWithdrawnModel,
                        WhItemsBgWorker)

        ElseIf loadingStat = LoadingStatus.withdrawalReleased Then

            _initializing(cCol.forWithdrawn,
                         values,
                         withdrawnModel,
                         WhItemsBgWorker)

            _initializing(cCol.forPartiallyWithdrawn,
                        values,
                        partiallyWithdrawnModel,
                        WhItemsBgWorker)
        Else

            _init_._initializing(cCol.forWhItems,
                      values,
                      whItemsModel,
                      WhItemsBgWorker)

            _initializing(cCol.forWithdrawn,
                          values,
                          withdrawnModel,
                          WhItemsBgWorker)

            _initializing(cCol.forPartiallyWithdrawn,
                    values,
                    partiallyWithdrawnModel,
                    WhItemsBgWorker)

            _initializing(cCol.forEmployees,
                          values,
                          employeesModel,
                          WhItemsBgWorker)
        End If

        If cLoadType = LoadingStatus.cancelWithdrawn Or
            cLoadType = LoadingStatus.withdraw Or
            cLoadType = LoadingStatus.withdrawalReleased Then

            cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyCancelWithdrawalOrWithdraw, WhItemsBgWorker)
        Else
            cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, WhItemsBgWorker)
        End If

    End Sub

    Private Sub clear()
        cSomeComponents.clearParameter()
        serialNoViewModel.clearParameter()
        withdrawnModel.clearParameter()
        partiallyWithdrawnModel.clearParameter()
        employeesModel.clearParameter()
        whItemsModel.clearParameter()
        cancelledTransactionModel.clearParameter()

    End Sub
    Private Sub SuccessfullyDone()
        If loadingStat = LoadingStatus.partiallyWithdrawn Then

            cListOfWithdrawnItems = CType(withdrawnModel.cData, List(Of PropsFields.withdrawn_props_fields))
            cListOfPartiallyWithdrawn = CType(partiallyWithdrawnModel.cData, List(Of PropsFields.partiallyWithdrawn_props_fields))
            Results.rListOfTireSerialNoView = TryCast(serialNoViewModel.cData, List(Of PropsFields.tireSerialView_props_fields))

            loadingPanel.Visible = True
            searchNew2()

        ElseIf loadingStat = LoadingStatus.withdrawalReleased Then

            cListOfWithdrawnItems = CType(withdrawnModel.cData, List(Of PropsFields.withdrawn_props_fields))
            Results.rListOfTireSerialNoView = TryCast(serialNoViewModel.cData, List(Of PropsFields.tireSerialView_props_fields))

            loadingStat = 0
            disableEnableWhileLoading(cSomeComponents.getValues(), True)
        Else

            Results.cResult = CType(whItemsModel.cData, List(Of PropsFields.whItems_props_fields))
            cListOfWithdrawnItems = CType(withdrawnModel.cData, List(Of PropsFields.withdrawn_props_fields))
            cListOfPartiallyWithdrawn = CType(partiallyWithdrawnModel.cData, List(Of PropsFields.partiallyWithdrawn_props_fields))
            Results.cListOfEmployees = CType(employeesModel.cData, List(Of PropsFields.employee_props_fields))
            Results.rListOfTireSerialNoView = TryCast(serialNoViewModel.cData, List(Of PropsFields.tireSerialView_props_fields))
            cListOfCancelledTransaction = TryCast(cancelledTransactionModel.cData, List(Of PropsFields.CancelledTransaction))

            loadingStat = 0
            disableEnableWhileLoading(cSomeComponents.getValues(), True)
        End If



        'loadingPanel.Visible = False

    End Sub

    Private Sub SuccessfullyCancelWithdrawalOrWithdraw()

        If loadingStat = LoadingStatus.withdrawalReleased Then

            cListOfWithdrawnItems = CType(withdrawnModel.cData, List(Of PropsFields.withdrawn_props_fields))
            cListOfPartiallyWithdrawn = CType(partiallyWithdrawnModel.cData, List(Of PropsFields.partiallyWithdrawn_props_fields))
               
        End If

        searchNew2()

        'loadingPanel.Visible = False
        loadingStat = 0
        cLoadType = 0


    End Sub
    Public Sub view_withdrawnList()
        lvlwithdrawalList.Items.Clear()
        Try
            sqlcon.connection.Open()
            Dim dr As SqlDataReader
            Dim cmd As New SqlCommand("proc_withdrawal_crud", sqlcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@crud", "view_withdrawnList")
            dr = cmd.ExecuteReader
            While dr.Read
                Dim a(15) As String
                ws_item_id = dr.Item("ws_item_id").ToString
                a(0) = dr.Item("ws_info_id").ToString
                a(1) = dr.Item("ws_no").ToString
                a(2) = dr.Item("rs_no").ToString
                a(3) = Format(Date.Parse(dr.Item("date_withdraw").ToString))
                a(4) = dr.Item("qty").ToString
                a(5) = dr.Item("unit").ToString
                a(6) = dr.Item("item_name").ToString
                a(7) = dr.Item("item_desc").ToString
                a(8) = dr.Item("withdraw_from").ToString
                a(9) = dr.Item("withdraw_by").ToString
                a(10) = dr.Item("released_by").ToString
                a(11) = dr.Item("withdraw_status").ToString
                'a(12) = dr.Item("ws_item_id").ToString


                Dim process As String = get_charge_to(dr.Item("ws_item_id").ToString, 2)
                charge_to_id = get_charge_to(dr.Item("ws_item_id").ToString, 1)

                Select Case process
                    Case "EQUIPMENT"
                        a(12) = GET_equip_desc_AND_proj_desc(charge_to_id, 1)
                    Case "PROJECT"
                        a(12) = GET_equip_desc_AND_proj_desc(charge_to_id, 2)
                    Case "WAREHOUSE"
                        a(12) = GET_equip_desc_AND_proj_desc(charge_to_id, 4)
                    Case "PERSONAL"
                        a(12) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                    Case "CASH"
                        a(12) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                    Case "ADFIL"
                        a(12) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)


                        Dim mcharges As String = get_multiple_charges(dr.Item("rs_id").ToString)

                        If mcharges.Length < 1 Then
                        Else
                            mcharges = mcharges.Trim().Substring(0, mcharges.Length - 1)
                            a(12) = a(12) & "(" & UCase(mcharges) & ")"

                        End If
                End Select

                Dim lvl As New ListViewItem(a)
                lvlwithdrawalList.Items.Add(lvl)

            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try
    End Sub

    Public Function get_charge_to(ByVal id As Integer, ByVal n As Integer)
        Dim newsqlcon As New SQLcon
        Dim newcmd As SqlCommand
        Dim newsqldr As SqlDataReader

        Try
            newsqlcon.connection.Open()
            publicquery = "SELECT a.charge_to, a.process FROM dbrequisition_slip a INNER JOIN dbwithdrawal_items b ON a.rs_id = b.rs_id WHERE b.ws_item_id = '" & id & "'"
            newcmd = New SqlCommand(publicquery, newsqlcon.connection)
            newsqldr = newcmd.ExecuteReader

            While newsqldr.Read
                If n = 1 Then
                    get_charge_to = newsqldr.Item("charge_to").ToString
                ElseIf n = 2 Then
                    get_charge_to = newsqldr.Item("process").ToString
                End If

            End While
            newsqldr.Close()


        Catch ex As Exception

        End Try
    End Function

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub cms_FWithdrawalList_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cms_FWithdrawalList.Opening
        Try
            If lvlwithdrawalList.SelectedItems.Count > 0 Then
                Dim ws_id As Integer = Utilities.ifBlankReplaceToZero(lvlwithdrawalList.SelectedItems(0).Text)

                If lvlwithdrawalList.SelectedItems.Count > 0 Then
                    cms_FWithdrawalList.Enabled = True

                    Utilities.enableDisableToolStrip(EditInfoToolStripMenuItem, True)
                    Utilities.enableDisableToolStrip(EditWithdrawnItemsToolStripMenuItem, True)
                    Utilities.enableDisableToolStrip(EditReleaseItemsToolStripMenuItem, True)
                    Utilities.enableDisableToolStrip(ExportToExcelToolStripMenuItem, True)
                    Utilities.enableDisableToolStrip(ViewStockcardToolStripMenuItem, True)
                    Utilities.enableDisableToolStrip(CancelWithdrawToolStripMenuItem, True)

                    If check_if_exist("dbwithdrawn_items", "ws_id", ws_id, 1) > 0 Then
                        'cms_FWithdrawalList.Items(0).Enabled = False
                        'cms_FWithdrawalList.Items(2).Enabled = False

                    Else
                        'cms_FWithdrawalList.Items(0).Enabled = True
                        'cms_FWithdrawalList.Items(2).Enabled = True
                        EditToolStripMenuItem.Enabled = True
                        WithdrawnToolStripMenuItem.Enabled = True
                    End If
                Else
                    cms_FWithdrawalList.Enabled = False
                End If
            Else
                Utilities.disableAllItemsFromContextMenu(cms_FWithdrawalList)
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        button_click_name = "EditToolStripMenuItem"




        Exit Sub

        '----------- AYAW SA DELETA --------------------
        bol_withdrawal_edit = True

        Dim rs_id As Integer = CInt(lvlwithdrawalList.SelectedItems(0).SubItems(16).Text)
        FPOFORM.old_ws_no = lvlwithdrawalList.SelectedItems(0).SubItems(1).Text

        po_edit = 1

        FPurchasedOrderList.GET_REQUISITION_SLIP_DATA1(rs_id)

        With FPOFORM
            .lblInOut.Text = "OUT"
            .txtInstructions.ReadOnly = True
            .txtPrepared_by.Enabled = True
            .txtChecked_by.Enabled = True
            .txtApproved_by.Enabled = True

            .Label10.Text = "Withdraw From:"
            .Label9.Text = "Withdraw by:"
            .Label12.Text = "Released by:"
            .Label15.Text = "WITHDRAWAL"

            .Label10.Visible = False
            .txtPrepared_by.Visible = False
            .Label6.Visible = False
            .txtInstructions.Visible = False
            .Label11.Visible = False
            .DTPdateneeded.Visible = False

            Dim ws_info_id As Integer = CInt(lvlwithdrawalList.SelectedItems(0).SubItems(15).Text)

            form_active("FPOFORM")
            .btnSave.Text = "Update"
            '.load_po_items("UPDATE WS")
            load_withdrawal_info_and_items(ws_info_id)
            .show_warehouse_list()
            .Show()

        End With


        'With FWithdrawalSlip
        '    Dim ws_info_id As Integer = lvlwithdrawalList.SelectedItems(0).SubItems(13).Text
        '    .lbl_ws_info_id.Text = ws_info_id
        '    .lbl_rs_id.Text = lvlwithdrawalList.SelectedItems(0).SubItems(14).Text
        '    load_ws_info(ws_info_id)
        '    .dgWithdrawItems.Enabled = False
        '    .dgWithdrawItems.ForeColor = Color.Gray

        '    .btnSave.Text = "Update"
        '    .ShowDialog()

        'End With


        'With FWithdrawalSlip
        '    Try
        '        .Show()
        '        .btnSave.Text = "Update"
        '        .txtWSNo.Text = lvlwithdrawalList.SelectedItems.Item(0).SubItems(0).Text
        '        .txtRSNo.Text = lvlwithdrawalList.SelectedItems.Item(0).SubItems(1).Text
        '        .DTPDateWithdraw.Text = lvlwithdrawalList.SelectedItems.Item(0).SubItems(2).Text
        '        .txtWithdrawFrom.Text = lvlwithdrawalList.SelectedItems.Item(0).SubItems(6).Text
        '        .txtWithdrawby.Text = lvlwithdrawalList.SelectedItems.Item(0).SubItems(7).Text
        '        .txtReleasedby.Text = lvlwithdrawalList.SelectedItems.Item(0).SubItems(8).Text
        '        ' .lbl_withdrawInfoID.Text = lvlwithdrawalList.SelectedItems(0).SubItems(0).Text

        '        .dgWithdrawItems.Rows.Clear()
        '        sqlcon.connection.Open()
        '        Dim dr As SqlDataReader
        '        Dim cmd As New SqlCommand("proc_withdrawal_crud", sqlcon.connection)
        '        cmd.Parameters.Clear()
        '        cmd.CommandType = CommandType.StoredProcedure
        '        'cmd.Parameters.AddWithValue("@wsNo", .lbl_withdrawInfoID.Text)
        '        cmd.Parameters.AddWithValue("@crud", "view_withdrawItems")
        '        dr = cmd.ExecuteReader
        '        While dr.Read
        '            Dim a(10) As String

        '            '.lbl_withdrawInfoID.Text = dr.Item("ws_no").ToString
        '            .lbl_withdrawInfoID.Text = dr.Item("withdraw_info_id").ToString
        '            a(0) = dr.Item("wh_id").ToString
        '            a(1) = dr.Item("qty").ToString
        '            a(2) = dr.Item("unit").ToString
        '            a(3) = dr.Item("item_desc").ToString

        '            .dgWithdrawItems.Rows.Add(a)

        '        End While
        '        dr.Close()
        '    Catch ex As Exception
        '        MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Finally
        '        sqlcon.connection.Close()
        '    End Try
        'End With
    End Sub
    Public Sub load_withdrawal_info_and_items(ws_info_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_withdrawal_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 88)
            newCMD.Parameters.AddWithValue("@ws_info_id", ws_info_id)

            newDR = newCMD.ExecuteReader

            Dim a(20) As String
            While newDR.Read
                With FPOFORM

                    .DTPTrans.Text = Date.Parse(newDR.Item("po_date").ToString)
                    .txtInstructions.Text = newDR.Item("instructor").ToString
                    .DTPdateneeded.Text = newDR.Item("date_needed").ToString
                    .txtApproved_by.Text = newDR.Item("approved_by").ToString
                    .txtChecked_by.Text = newDR.Item("checked_by").ToString
                    .txtPrepared_by.Text = newDR.Item("prepared_by").ToString
                    .cmbdr_option.Text = newDR.Item("dr_option").ToString
                    .txtRemarks.Text = newDR.Item("remarks").ToString

                    .set_po_id = newDR.Item("po_id").ToString


                    a(0) = True
                    a(1) = IIf(newDR.Item("Supplier_Name").ToString = "", "N/A", newDR.Item("Supplier_Name").ToString)
                    a(2) = newDR.Item("wh_id").ToString
                    a(3) = newDR.Item("item_name").ToString
                    a(4) = newDR.Item("item_desc").ToString
                    a(5) = newDR.Item("po_no").ToString
                    a(6) = newDR.Item("terms").ToString
                    a(7) = CDec(newDR.Item("qty").ToString)
                    a(8) = newDR.Item("unit").ToString
                    a(9) = newDR.Item("unit_price").ToString
                    a(10) = FormatNumber(CDec(newDR.Item("unit_price").ToString) * CDec(newDR.Item("qty").ToString), 2, , TriState.True)
                    a(11) = newDR.Item("po_det_id").ToString
                    a(12) = newDR.Item("rs_id").ToString
                    a(13) = newDR.Item("lof_id").ToString
                    a(14) = newDR.Item("IN_OUT").ToString
                    a(15) = newDR.Item("type_of_purchasing").ToString
                    a(16) = FReceivingReport.multiplecharges(newDR.Item("rs_id").ToString, 1)
                    .dgvPOList.Rows.Add(a)

                End With
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

            For Each row As DataGridViewRow In FPOFORM.dgvPOList.Rows
                row.Cells(2).ReadOnly = True
                row.Cells(3).ReadOnly = True
                row.Cells(4).ReadOnly = True
                row.Cells(5).ReadOnly = False
                row.Cells(7).ReadOnly = True
                row.Cells(8).ReadOnly = True
                row.Cells(9).ReadOnly = True
                row.Cells(10).ReadOnly = True
                row.Cells(11).ReadOnly = True
                row.Cells(12).ReadOnly = True
                row.Cells(13).ReadOnly = True
                row.Cells(14).ReadOnly = True
            Next
        End Try

    End Sub

#Region "GUI_btnExt,lvlResize"

    Private Sub FWithdrawalList_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        lvlwithdrawalList.Height = Me.Height - 115
        lvlwithdrawalList.Width = Me.Width - 30
        btnExit.Location = New Point(lvlwithdrawalList.Width + 1, 10)
        FlowLayoutPanel1.Location = New Point(lvlwithdrawalList.Location.X, lvlwithdrawalList.Bounds.Bottom + 10)
    End Sub

    Private Sub btnExit_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnExit.MouseDown
        btnExit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.MouseEnter
        btnExit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.MouseLeave
        btnExit.BackgroundImage = My.Resources.close_button
    End Sub

    Private Sub btn_paneLExt_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn_paneLExt.MouseDown
        btn_paneLExt.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btn_paneLExt_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_paneLExt.MouseEnter
        btn_paneLExt.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btn_paneLExt_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_paneLExt.MouseLeave
        btn_paneLExt.BackgroundImage = My.Resources.close_button
    End Sub

#End Region

    Private Sub cmbSearchByCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSearchByCategory.SelectedIndexChanged
        Select Case cmbSearchByCategory.Text

            Case "Search by RS No."

                txtSearch.Text = "RS No..."
                txtSearch.Enabled = True
                btnSearch.Enabled = True
                panel_fdate.Visible = False
                dtpFrom.Visible = False
                dtpTo.Visible = False

                txtItemSearch.Visible = False
                txtSearch.Focus()

                dtpFrom.Visible = False
                dtpTo.Visible = False

            Case "Search by WS No."

                txtSearch.Text = "WS No..."
                txtSearch.Enabled = True
                btnSearch.Enabled = True
                panel_fdate.Visible = False
                dtpFrom.Visible = False
                dtpTo.Visible = False

                txtItemSearch.Visible = False
                txtSearch.Focus()

                dtpFrom.Visible = False
                dtpTo.Visible = False

            Case "Search by Charges"

                'txtItemSearch.Visible = False
                'txtSearch.Text = "Charges..."
                'txtSearch.Enabled = False
                'btnSearch.Enabled = True
                'panel_fdate.Visible = False
                'dtpFrom.Enabled = False
                'dtpTo.Enabled = False
                ''txtSearch.Focus()

                'dtpFrom.Visible = True
                'dtpTo.Visible = True

            'Case "Search by Date Withdrawn"
            '    txtItemSearch.Visible = False
            '    txtSearch.Text = ""
            '    txtSearch.Enabled = True
            '    btnSearch.Enabled = True
            '    panel_fdate.Visible = False
            '    dtpFrom.Visible = True
            '    dtpTo.Visible = True


            '    txtSearch.Focus()

            '    dtpFrom.Visible = False
            '    dtpTo.Visible = False

            Case "Search by Items"

                txtItemSearch.Visible = False
                txtSearch.Text = "Items..."
                txtSearch.Enabled = True
                btnSearch.Enabled = True
                panel_fdate.Visible = False
                dtpFrom.Visible = True
                dtpTo.Visible = True

                txtSearch.Focus()

                dtpFrom.Visible = False
                dtpTo.Visible = False

            Case "Search by withdrawn by"

                txtItemSearch.Visible = False
                txtSearch.Text = "Withdrawn by..."
                txtSearch.Enabled = True
                btnSearch.Enabled = True
                panel_fdate.Visible = False
                dtpFrom.Visible = True
                dtpTo.Visible = True

                txtSearch.Focus()

                dtpFrom.Visible = False
                dtpTo.Visible = False

            Case "Search by released by"

                txtItemSearch.Visible = False
                txtSearch.Text = "Released by..."
                txtSearch.Enabled = True
                btnSearch.Enabled = True
                panel_fdate.Visible = False
                dtpFrom.Visible = True
                dtpTo.Visible = True


                txtSearch.Focus()

                dtpFrom.Visible = False
                dtpTo.Visible = False

            Case "Search by User Name"

                txtItemSearch.Visible = False
                txtSearch.Text = "Username..."
                txtSearch.Enabled = True
                btnSearch.Enabled = True
                panel_fdate.Visible = False
                dtpFrom.Visible = False
                dtpTo.Visible = False

                txtSearch.Focus()

                dtpFrom.Visible = False
                dtpTo.Visible = False

            Case "Filter by MOnth/Year"

                txtItemSearch.Visible = False
                txtSearch.Text = ""
                txtSearch.Enabled = False
                btnSearch.Enabled = True
                panel_fdate.Visible = False
                dtpFrom.Visible = True
                dtpTo.Visible = True


                txtSearch.Focus()

                dtpFrom.Visible = False
                dtpTo.Visible = False
            Case "Search by Date"

                'txtSearch.Visible = False
                'txtItemSearch.Visible = False
                'dtpFrom.Visible = True
                'dtpTo.Visible = True
                panel_fdate.Visible = True

            Case cSearchByEnum.search_by_received_by,
                 cSearchByEnum.search_by_issued_by,
                 cSearchByEnum.search_by_released_by,
                 cSearchByEnum.search_by_date_withdrawn,
                 cSearchByEnum.search_by_date_issued

                DTP_dateFROM.Enabled = True
                DTP_dateTO.Enabled = True
                txtSearchWithDateRange.Enabled = True
                btn_view.Enabled = True
                panel_fdate.Enabled = True
                panel_fdate.Visible = True

                Dim listOfEmp As New List(Of String)
                listOfEmp = Results.cListOfEmployees.
                    Select(Function(x)
                               Return $"{x.employee.ToUpper()}".ToUpper()
                           End Function).ToList()

                searchInPanel.AutoCompleteData = listOfEmp
                searchInPanel.set_autocomplete()

                For Each ctr As Control In Me.Controls
                    If Not ctr.Name = NameOf(panel_fdate) And
                        Not ctr.Name = NameOf(pboxHeader) And
                        Not ctr.Name = NameOf(loadingPanel) Then

                        ctr.Enabled = False
                    Else
                        ctr.Enabled = True
                    End If
                Next

        End Select

        'Search by WS No.
        'Search by RS No.
        'Search by Charge To
        'Search by Date Withdrawn
        'Search by Item Name
        'Search by Item Description
        'Filter by MOnth/Year


        'If cmbSearchByCategory.Text = "Search by RS No." Then

        '    txtSearch.Text = ""
        '    txtSearch.Enabled = True
        '    btnSearch.Enabled = True
        '    panel_fdate.Visible = False
        '    dtpFrom.Visible = False
        '    dtpTo.Visible = False

        '    txtSearch.Focus()

        'ElseIf cmbSearchByCategory.Text = "Search by Item Name" Then
        '    txtSearch.Enabled = True
        '    btnSearch.Enabled = True
        '    panel_fdate.Visible = False
        '    dtpFrom.Visible = True
        '    dtpTo.Visible = True

        'ElseIf cmbSearchByCategory.Text = "Search by Item Description" Then
        '    txtSearch.Enabled = True
        '    btnSearch.Enabled = True
        '    panel_fdate.Visible = False
        '    dtpFrom.Visible = True
        '    dtpTo.Visible = True

        'ElseIf cmbSearchByCategory.Text = "Search by WS No." Then
        '    txtSearch.Enabled = True
        '    btnSearch.Enabled = True
        '    panel_fdate.Visible = False
        '    dtpFrom.Visible = False
        '    dtpTo.Visible = False

        'ElseIf cmbSearchByCategory.Text = "Filter by MOnth/Year" Then
        '    ''txtSearch.Enabled = False
        '    ''btnSearch.Enabled = False
        '    'txtSearch.Enabled = True
        '    'enable_disable_controls(Me, panel_fdate.Name, True, False)
        '    txtSearch.Enabled = False
        '    dtpFrom.Visible = True
        '    dtpTo.Visible = True
        'End If
        'Select Case cmbSearchByCategory.Text

        '    Case "Search by Date Withdrawn"
        '        'dtpSearchDateWthdrawn.Visible = True
        '        'dtpSearchDateWthdrawn.Parent = gboxSearch
        '        'dtpSearchDateWthdrawn.Location = New Point(txtSearch.Bounds.Left, txtSearch.Bounds.Top)
        '        'dtpSearchDateWthdrawn.Width = txtSearch.Width
        '        'txtSearch.Visible = False
        '        'btnSearch.Enabled = True
        '        'panel_fdate.Visible = False
        '        txtSearch.Enabled = False
        '        dtpFrom.Visible = False
        '        dtpTo.Visible = False
        '    Case Else
        '        txtSearch.Visible = True
        '        dtpSearchDateWthdrawn.Visible = False
        '        txtSearch.Enabled = True
        '        dtpFrom.Visible = False
        '        dtpTo.Visible = False
        'End Select
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub



    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            'With cWITHRAWALLISTMODEL
            '    .initialize_search(cmbSearchByCategory.Text, txtSearch.Text)
            '    .execute_searchBy()
            'End With

            searchNew2()
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Sub searchNew2()
        loadingPanel.Visible = True
        lvlwithdrawalList.Items.Clear()
        btnSearch.Enabled = False

        withdrawalModel.clearParameter()
        serialNoViewModel.clearParameter()
        partiallyWithdrawnModel.clearParameter()

        Dim values As New ColumnValues
        values.add("searchby", cmbSearchByCategory.Text)
        values.add("search", txtSearch.Text)
        values.add("nn", "true")


        Select Case cmbSearchByCategory.Text
            Case cSearchByEnum.search_by_date_issued,
                 cSearchByEnum.search_by_issued_by,
                 cSearchByEnum.search_by_received_by,
                 cSearchByEnum.search_by_released_by,
                 cSearchByEnum.search_by_date_withdrawn,
                 cSearchByEnum.search_by_date_issued

                values.add("date_range", "true")
                values.add("datefrom", Date.Parse(DTP_dateFROM.Text))
                values.add("dateto", Date.Parse(DTP_dateTO.Text))

        End Select

        _initializing(cCol.forWithdrawal,
                    values.getValues(),
                    withdrawalModel,
                    withdrawalBgWorker)

        _initializing(cCol.forPartiallyWithdrawn,
                        values.getValues(),
                        partiallyWithdrawnModel,
                        WhItemsBgWorker)

        cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDoneSearch, withdrawalBgWorker)

    End Sub
    Private Sub SuccessfullyDoneSearch()

        cListofWithdrawal = CType(withdrawalModel.cData, List(Of PropsFields.withdrawal_props_fields))
        cListOfPartiallyWithdrawn = CType(partiallyWithdrawnModel.cData, List(Of PropsFields.partiallyWithdrawn_props_fields))

        previewNow()

        'loadingPanel.Visible = False
        btnSearch.Enabled = True
    End Sub

    Private Sub previewNow()
        cListofListview.Clear()
        loadingPanel.Visible = True

        Dim listOfWithdrawal As New List(Of PropsFields.withdrawal_props_fields)
        Dim listOfPartialWithdrawn As New List(Of PropsFields.partiallyWithdrawn_props_fields)

        Select Case cmbSearchByCategory.Text

            Case cSearchByEnum.search_by_issued_by

                listOfWithdrawal = cListofWithdrawal.
                                              Where(Function(x)
                                                        Return x.issued_by.ToUpper().
                                              Contains(txtSearchWithDateRange.Text.ToUpper())
                                                    End Function).
                                              ToList()

                listOfPartialWithdrawn = cListOfPartiallyWithdrawn

            Case cSearchByEnum.search_by_received_by

                listOfWithdrawal = cListofWithdrawal
                listOfPartialWithdrawn = cListOfPartiallyWithdrawn.
                                                Where(Function(x)
                                                          Return x.received_by.ToUpper().
                                                Contains(txtSearchWithDateRange.Text.ToUpper())
                                                      End Function).
                                                ToList()

            Case cSearchByEnum.search_by_released_by

                listOfWithdrawal = cListofWithdrawal
                listOfPartialWithdrawn = cListOfPartiallyWithdrawn.
                                                Where(Function(x)
                                                          Return x.released_by.ToUpper().
                                                Contains(txtSearchWithDateRange.Text.ToUpper())
                                                      End Function).
                                                ToList()

            Case cSearchByEnum.search_by_date_issued

                listOfWithdrawal = cListofWithdrawal
                listOfPartialWithdrawn = cListOfPartiallyWithdrawn

            Case cSearchByEnum.search_by_date_withdrawn

                listOfWithdrawal = cListofWithdrawal
                listOfPartialWithdrawn = cListOfPartiallyWithdrawn.
                    Where(Function(x)
                              Return Date.Parse(x.date_partially_withdrawn).Date() >= Date.Parse(DTP_dateFROM.Text).Date() And
                              Date.Parse(x.date_partially_withdrawn).Date() <= Date.Parse(DTP_dateTO.Text).AddDays(10).Date()
                          End Function).ToList()

            Case cSearchByEnum.search_by_users

                listOfWithdrawal = cListofWithdrawal.
                    Where(Function(x) x.users.ToUpper().
                    Contains(txtSearch.Text.ToUpper)).
                    ToList()

                listOfPartialWithdrawn = cListOfPartiallyWithdrawn.
                    Where(Function(x) x.users.ToUpper().
                    Contains(txtSearch.Text.ToUpper())).
                    ToList()

            Case Else

                listOfWithdrawal = cListofWithdrawal
                listOfPartialWithdrawn = cListOfPartiallyWithdrawn

        End Select


        If listOfWithdrawal.Count > 0 Then

            For Each row In listOfWithdrawal

#Region "For cancel releasing/withdrawal -> it will not display"
                If isCancelWithdrawal(row) Then
                    GoTo cancelHere
                End If
#End Region

#Region "this code of line is for filtering received by, released by"
                If cmbSearchByCategory.Text = cSearchByEnum.search_by_received_by Or
                    cmbSearchByCategory.Text = cSearchByEnum.search_by_released_by Then

                    If listOfPartialWithdrawn.
                  Where(Function(x)
                            Return x.withdrawn_id = row.withdrawn_id And Not x.status = "deleted"
                        End Function).
                  ToList().Count = 0 Then

                        GoTo continueHere

                    End If
                End If
#End Region

                Dim a(28) As String
                Dim serialNo As String = ""

#Region "ProperNames"

                Dim properName As New PropsFields.whItems_properName_fields
                properName = getProperNameUsingWhPnId2(row.wh_pn_id)

#End Region

#Region "for SERIAL NO"
                If Results.rListOfTireSerialNoView.Count > 0 Then

                    Dim lookupId As Integer = Utilities.ifBlankReplaceToZero(row.serial_id)
                    Dim found = Results.rListOfTireSerialNoView.FirstOrDefault(Function(x) x.serial_id = lookupId)
                    serialNo = If(found IsNot Nothing, found.serial_no, String.Empty)

                End If
#End Region

                Dim proName As String = ""

                If properName Is Nothing Then
                    proName = ""
                Else
                    proName = properName.item_desc
                End If
                '{IIf(serialNo = "", "", $"| serial No: {serialNo}}
                a(0) = row.ws_id
                a(1) = row.ws_no
                a(2) = row.rs_no
                a(3) = row.ws_date
                a(4) = row.item_name
                a(5) = row.ws_qty
                a(6) = row.unit
                a(7) = FormatNumber(row.unit_price, 2,, TriState.True)
                a(8) = FormatNumber(row.amount, 2,, TriState.True)
                a(9) = row.item_desc & IIf(row.wh_pn_id = 0, "", $" → {proName}")
                a(10) = row.withdrawn_from
                a(11) = row.withdrawn_by
                a(12) = row.released_by
                a(14) = row.charges
                a(15) = row.ws_info_id
                a(16) = row.rs_id
                a(18) = row.wh_id
                a(19) = row.remarks
                a(20) = row.dr_option
                a(21) = row.purpose
                a(24) = row.issued_by
                a(25) = row.users
                a(26) = row.division
                a(27) = row.serial_id
                a(28) = row.tire_category

                Dim withdrawnId As New List(Of PropsFields.withdrawn_props_fields)
                withdrawnId = cListOfWithdrawnItems.Where(Function(x) x.ws_id = row.ws_id).ToList()

                If withdrawnId.Count > 0 Then
                    a(13) = IIf(withdrawnId(0).status IsNot "", "- released", "- withdrawn")

                    If withdrawnId.Count > 0 Then
                        a(22) = withdrawnId(0).withdrawn_id
                    Else
                        a(22) = 0
                    End If
                Else
                    a(13) = "pending"
                End If

                Dim lvl As New ListViewItem(a)
                lvl.BackColor = cRowColor.released

                cListofListview.Add(lvl)

                'for partially withdrawn
                For Each row1 In listOfPartialWithdrawn
                    If withdrawnId.Count > 0 Then
                        If withdrawnId(0).withdrawn_id = row1.withdrawn_id And Not row1.status = "deleted" Then
                            Dim aa(28) As String

                            For i = 0 To 22
                                aa(i) = "-"
                            Next

                            aa(0) = row.ws_id
                            aa(3) = row1.date_partially_withdrawn
                            aa(5) = row1.partially_withdrawn_qty
                            aa(6) = row1.units
                            aa(9) = $"- {proName}"
                            aa(11) = row1.received_by
                            aa(12) = row1.released_by
                            aa(13) = "- withdrawn"
                            aa(23) = row1.partially_withdrawn_id
                            aa(25) = row1.users
                            aa(27) = row1.serial_id
                            aa(28) = $"SERIAL NO: {getSerialNo(row1.serial_id)}"

                            Dim lvl2 As New ListViewItem(aa)
                            lvl2.BackColor = cRowColor.withdrawn

                            cListofListview.Add(lvl2)
                        End If
                    End If
                Next
continueHere:
cancelHere:
            Next
        End If

        lvlwithdrawalList.Items.AddRange(cListofListview.ToArray)
        loadingPanel.Visible = False
        Utilities.customListViewHeight(lvlwithdrawalList, 26)

        listfocus(lvlwithdrawalList, cWsId)

        isEditForListView(isEdit, lvlwithdrawalList, cWsId)

        disableEnableWhileLoading(cSomeComponents.getValues(), True)


    End Sub

    Private Sub searchNew()
        Withdrawal_Data.clear_parameter()

        Panel3.Visible = True
        Label7.Text = "Processing data to display..."

        Withdrawal_Data.parameter("@searchby", cmbSearchByCategory.Text)
        Withdrawal_Data.cStoreProcedureName = "po_query_new2"

        Select Case cmbSearchByCategory.Text
            Case cSearchByEnum.search_by_issued_by

            Case Else

                Withdrawal_Data.parameter("@n", 6)
                Withdrawal_Data.parameter("@search", txtSearch.Text)

        End Select

        BW_Search.WorkerSupportsCancellation = True
        BW_Search.RunWorkerAsync()
    End Sub

    Public Sub search1()


        ProgressBar1.Value = 0
        'ListBox1.Items.Clear()


        thread1 = New System.Threading.Thread(AddressOf panelvisible)
        thread1.Start()
        lvlwithdrawalList.Items.Clear()
        Label7.Text = "Initializing..."

        'load_ws_id1()
        thread = New System.Threading.Thread(AddressOf search_using_rs1)
        thread.Start()
        Timer1.Start()

    End Sub

    Private Sub panelvisible()
        If Panel3.InvokeRequired Then
            Panel3.Invoke(Sub()
                              Panel3.Visible = True
                              Label7.Text = "initializing..."
                              lvlwithdrawalList.Visible = False
                          End Sub)
        Else
            Panel3.Visible = True
            Label7.Text = "initializing..."
            lvlwithdrawalList.Visible = False
        End If

    End Sub


    Public Function check_qty_withdrawn(ws_id As Integer) As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT b.qty FROM dbwithdrawn_items a INNER JOIN dbPO_details b ON a.rs_id = b.rs_id WHERE a.ws_id = " & ws_id
            newCMD = New SqlCommand(query, newSQ.connection)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                check_qty_withdrawn += newDR.Item("qty").ToString()
            End While
            newDR.Close()

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                If FlowLayoutPanel1.InvokeRequired Then
                    FlowLayoutPanel1.Invoke(Sub() FlowLayoutPanel1.Enabled = True)
                Else
                    FlowLayoutPanel1.Enabled = True
                End If
                Exit Function
            End If
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try



    End Function


    Private Sub btn_paneLExt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_paneLExt.Click
        enable_disable_controls(Me, panel_fdate.Name, False, True)
    End Sub

    Private Sub btn_view_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_view.Click

        searchNew2()

    End Sub

#Region "MovingPanelCode"

    Private Sub panel_fdate_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panel_fdate.MouseDown
        Timer_panelMvment.Enabled = True
        Timer_panelMvment.Start()
        setpositions()
    End Sub

    Private Sub panel_fdate_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panel_fdate.MouseUp
        Timer_panelMvment.Stop()
        setpositions()
    End Sub

    Private Sub Timer_panelMvment_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_panelMvment.Tick
        panel_fdate.Location = panloc - curloc + System.Windows.Forms.Cursor.Position
        setpositions()
    End Sub
#End Region

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click

        If Not isAuthenticated(auth) Then
            Exit Sub
        End If

        If MessageBox.Show("Are you sure you want to delete selected items?", "PO INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            For Each row As ListViewItem In lvlwithdrawalList.Items

                If row.BackColor = cRowColor.withdrawn And row.Selected Then
                    'If auth = newAuth.admin Then
                    'Else
                    '    customMsg.message("error", "We're sorry, but you do not have the necessary permissions to remove this transaction." &
                    '                      vbCrLf & "Please contact the system administrator for further assistance.", "SUPPLY INFO:")
                    '    Exit Sub
                    'End If
                    Dim selectedRow = lvlwithdrawalList.SelectedItems(0)
                    Dim cc As New ColumnValuesObj

                    cc.add("user_updated", pub_user_id)
                    cc.add("date_time_deleted", Date.Parse(Now))
                    cc.add("user_deleted", pub_user_id)
                    cc.add("status", "deleted")

                    cc.setCondition($"partially_withdrawn_id = {selectedRow.SubItems(23).Text}")
                    cc.updateQuery("dbwithdrawal_partially_withdrawn")

                ElseIf row.BackColor = cRowColor.released And row.Selected Then

                    Dim selectedRow = lvlwithdrawalList.SelectedItems(0)

                    Dim withdrawn_id As Integer = ifBlankReplaceToZero(selectedRow.SubItems(22).Text)
                    Dim ws_id As Integer = selectedRow.Text
                    Dim ws_info_id As Integer = selectedRow.SubItems(15).Text

                    Dim data = cListOfPartiallyWithdrawn.Where(Function(x) x.withdrawn_id = withdrawn_id).ToList()

                    If data.Count > 0 Then
                        'customMsg.message("error", "Removed is not allowed if there is already withdrawn item...", "SUPPLY INFO")
                        If customMsg.messageYesNo("Removed is not allowed if there is already withdrawn item, do you still want to cotinue remove?", "SMS INFO:", MessageBoxIcon.Question) Then
                            removeReleasedItems(ws_info_id, ws_id, withdrawn_id)
                        Else
                            Exit Sub
                        End If
                    Else
                        removeReleasedItems(ws_info_id, ws_id, withdrawn_id)
                    End If
                End If

            Next

            MessageBox.Show("Successfully Removed..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)

            For Each row As ListViewItem In lvlwithdrawalList.Items
                If row.Selected = True Then
                    row.Remove()
                End If
            Next

            'refresh partially withdrawn data
            loadingStat = LoadingStatus.partiallyWithdrawn
            loadWhItems()
        End If



        'If MessageBox.Show("Are you sure you want to delete this data?", "Supply Info:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        '    For Each item As ListViewItem In lvlwithdrawalList.Items
        '        If item.Selected = True Then

        '            If row_counter("dbwithdrawal_items", "ws_info_id", CInt(item.SubItems(13).Text), 1) > 1 Then
        '                'dili sa e delte ang receiving info 
        '                Dim query As String = "DELETE FROM dbwithdrawal_items WHERE ws_item_id = " & CInt(item.Text)
        '                UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

        '                query = "DELETE FROM dbwithdrawn_items WHERE rs_id = " & CInt(item.SubItems(14).Text)
        '                UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

        '                item.Remove()

        '            Else
        '                Dim query As String
        '                query = "DELETE FROM dbwithdrawal_items WHERE ws_item_id = " & CInt(item.Text)
        '                UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

        '                query = Nothing

        '                query = "DELETE FROM dbwithdrawal_info WHERE ws_info_id = " & CInt(item.SubItems(13).Text)
        '                UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

        '                query = "DELETE FROM dbwithdrawn_items WHERE rs_id = " & CInt(item.SubItems(14).Text)
        '                UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

        '                item.Remove()

        '            End If
        '        End If
        '    Next
        'End If

    End Sub

    Private Function addTable(tableName As String, condition As String) As PropsFields.SMSTables
        addTable = New PropsFields.SMSTables
        With addTable
            .table = tableName
            .condtion = condition
        End With

        Return addTable
    End Function

    Public Function countPartiallyWithdrawn(ws_id As Integer) As Double

        For Each item As ListViewItem In lvlwithdrawalList.Items
            If item.Text = ws_id And item.BackColor = Color.LightYellow Then
                countPartiallyWithdrawn += item.SubItems(5).Text
            End If
        Next

    End Function




    Private Sub CalculateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalculateToolStripMenuItem.Click
        Dim sum_qty As Double

        For Each row As ListViewItem In lvlwithdrawalList.Items
            If row.Selected = True Then
                sum_qty = sum_qty + row.SubItems(5).Text
            End If

        Next

        MessageBox.Show("Sum qty: " & sum_qty, "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ExportToExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToExcelToolStripMenuItem.Click

        If lvlwithdrawalList.Items.Count > 0 Then

            Dim export_ws As New EXPORT_TO_EXCEL_FILE
            Dim SaveFileDialog1 As New SaveFileDialog

            SaveFileDialog1.Title = "Save Excel File"
            SaveFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx"
            SaveFileDialog1.ShowDialog()

            'exit if no file selected
            If SaveFileDialog1.FileName = "" Then
                Exit Sub
            End If

            export_ws._initialize_ws_export(lvlwithdrawalList, SaveFileDialog1.FileName, "withdrawal")

        Else
            MessageBox.Show("There is no data found in the list..", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

    Private Sub txtSearch_GotFocus(sender As Object, e As EventArgs) Handles txtSearch.GotFocus

        Select Case txtSearch.Text
            Case "Charges..."
                txtSearch.ForeColor = Color.Black
                txtSearch.Clear()
            Case "RS No..."
                txtSearch.ForeColor = Color.Black
                txtSearch.Clear()
            Case "Items..."
                txtSearch.ForeColor = Color.Black
                txtSearch.Clear()
            Case "WS No..."
                txtSearch.ForeColor = Color.Black
                txtSearch.Clear()
            Case "Requested By..."
                txtSearch.ForeColor = Color.Black
                txtSearch.Clear()
            Case "Input By..."
                txtSearch.ForeColor = Color.Black
                txtSearch.Clear()
            Case "Username..."
                txtSearch.ForeColor = Color.Black
                txtSearch.Clear()
            Case "Type of Request..."
                txtSearch.ForeColor = Color.Black
                txtSearch.Clear()
            Case "Withdrawn by..."
                txtSearch.ForeColor = Color.Black
                txtSearch.Clear()
            Case "Released by..."
                txtSearch.ForeColor = Color.Black
                txtSearch.Clear()
        End Select
    End Sub

    Private Sub txtSearch_Leave(sender As Object, e As EventArgs) Handles txtSearch.Leave

        If txtSearch.Text = "" Then
            Select Case cmbSearchByCategory.Text
                Case "Search by Charges"
                    txtSearch.Text = "Charges..."
                Case "Search by RS No."
                    txtSearch.Text = "RS No..."
                Case "Search by Items"
                    txtSearch.Text = "Items..."
                Case "Search by WS No."
                    txtSearch.Text = "WS No..."
                Case "Search by Input by"
                    txtSearch.Text = "Input By..."
                Case "Search by User Name"
                    txtSearch.Text = "Username..."
                Case "Search by Type of Request/Sub"
                    txtSearch.Text = "Type of Request..."
                Case "Search by withdrawn by"
                    txtSearch.Text = "Withdrawn by..."
                Case "Search by released by"
                    txtSearch.Text = "Released by..."
            End Select

            txtSearch.ForeColor = Color.Gray
        End If
    End Sub

    Public Sub search_using_rs1()
        Try
            Dim rs_percent As Integer
            Dim n As Integer
            'If Integer.TryParse((rs_id_count / 100), n) Then
            '    rs_percent = rs_id_count / 100
            'Else
            '    rs_percent = 1
            'End If

            rs_percent = 1

            If ProgressBar1.InvokeRequired Then
                ProgressBar1.Invoke(Sub()
                                        ProgressBar1.Value = 0
                                        ProgressBar1.Maximum = ws_id_count
                                    End Sub)

            Else
                ProgressBar1.Value = 0
                ProgressBar1.Maximum = ws_id_count
            End If

            For i = 0 To ListBox1.Items.Count - 1

                view_withdrawal_details2(ListBox1.Items(i))

                If ProgressBar1.InvokeRequired Then
                    ProgressBar1.Invoke(Sub()
                                            If ProgressBar1.Value = ws_id_count Then ' 100 Then
                                            Else
                                                ProgressBar1.Value += CDbl(rs_percent)
                                            End If

                                        End Sub)
                Else
                    If ProgressBar1.Value = ws_id_count Then ' 100 Then
                    Else
                        ProgressBar1.Value += CDbl(rs_percent)
                    End If
                End If

            Next

            If ProgressBar1.InvokeRequired Then
                ProgressBar1.Invoke(Sub() ProgressBar1.Value = ProgressBar1.Maximum)
            Else
                ProgressBar1.Value = ProgressBar1.Maximum
            End If

            ws_id_count = 0
            'counter1 = 0
            'thread.Abort()
        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                If FlowLayoutPanel1.InvokeRequired Then
                    FlowLayoutPanel1.Invoke(Sub() FlowLayoutPanel1.Enabled = True)
                Else
                    FlowLayoutPanel1.Enabled = True
                End If

                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not thread.IsAlive Then
            Panel3.Visible = False
            Timer1.Stop()
            lvlwithdrawalList.Visible = True

            If lvlwithdrawalList.Items.Count > 0 Then
                listfocus(lvlwithdrawalList, pub_ws_id2)
            End If

            If pub_search_by_charges = 2 Then
                Fsearchbycharges.Dispose()

            End If
        Else
            Panel3.Visible = True
        End If
    End Sub


    Public Sub view_withdrawal_details2(ws_id1 As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim a(22) As String

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_withdrawal_new1", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 2)
            newCMD.Parameters.AddWithValue("@ws_id", ws_id1)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim ws_id As Integer = CInt(newDR.Item("WS_ID").ToString)
                Dim rs_id As Integer = CInt(newDR.Item("rs_id").ToString)
                Dim if_exist As Integer = check_if_exist("dbwithdrawn_items", "ws_id", ws_id, 1)
                Dim rs_qty As Integer = CInt(newDR.Item("RS_QTY").ToString)
                Dim status As String

                If if_exist > 0 Then

                    Dim qty_withdrawn As Integer
                    qty_withdrawn = check_qty_withdrawn(ws_id)
                    'MessageBox.Show("w : " & qty_withdrawn & ", r : " & rs_qty)
                    If qty_withdrawn < rs_qty Then
                        status = "PARTIALLY WITHDRAWN"
                    Else
                        status = "WITHDRAWN"
                    End If
                Else
                    status = "WITHDRAWAL RELEASED"
                End If

                a(0) = newDR.Item("WS_ID").ToString
                a(1) = newDR.Item("WS_NO").ToString
                a(2) = newDR.Item("RS_NO").ToString

                If newDR.Item("DATE_WITHDRAWN").ToString = "" Then
                    a(3) = Format(Date.Parse("1991-01-01"), "MM/dd/yyyy")
                Else
                    a(3) = Format(Date.Parse(newDR.Item("DATE_WITHDRAWN").ToString), "MM/dd/yyyy")
                End If

                a(4) = newDR.Item("ITEM_NAME").ToString
                a(5) = newDR.Item("qty").ToString
                a(6) = newDR.Item("unit").ToString
                a(7) = FormatNumber(CDbl(newDR.Item("unit_price").ToString), 2, , TriState.True)
                a(8) = FormatNumber(CDbl(newDR.Item("amount").ToString), 2, , TriState.True)
                'a(7) = FormatNumber(CDbl(a(6) / a(4)))
                a(9) = newDR.Item("ITEM_DESC").ToString
                'a(8) = newDR.Item("WITHDRAWN_FROM").ToString
                a(10) = FRequistionForm.get_wh_area(newDR.Item("wh_id").ToString)
                a(11) = newDR.Item("WITHDRAWN_BY").ToString
                a(12) = newDR.Item("RELEASED_BY").ToString
                a(13) = status
                a(14) = newDR.Item("charges").ToString
                a(15) = IIf(newDR.Item("WS_INFO_ID").ToString = "", 0, newDR.Item("WS_INFO_ID").ToString)
                a(16) = newDR.Item("rs_id").ToString
                'a(15) = newDR.Item("po_no").ToString
                a(18) = newDR.Item("wh_id").ToString
                a(19) = newDR.Item("remarks").ToString
                a(20) = newDR.Item("dr_option").ToString
                a(21) = newDR.Item("purpose").ToString

                Dim lvl As New ListViewItem(a)
                If lvlwithdrawalList.InvokeRequired Then
                    lvlwithdrawalList.Invoke(Sub() lvlwithdrawalList.Items.Add(lvl))
                Else
                    lvlwithdrawalList.Items.Add(lvl)
                End If

                If Label7.InvokeRequired Then
                    Label7.Invoke(Sub() Label7.Text = newDR.Item("WS_ID").ToString & " " & newDR.Item("ITEM_NAME").ToString & " - " & newDR.Item("ITEM_DESC").ToString)
                Else
                    Label7.Text = newDR.Item("WS_ID").ToString & " " & newDR.Item("ITEM_NAME").ToString & " - " & newDR.Item("ITEM_DESC").ToString
                End If

            End While
            newDR.Close()

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                If FlowLayoutPanel1.InvokeRequired Then
                    FlowLayoutPanel1.Invoke(Sub() FlowLayoutPanel1.Enabled = True)
                Else
                    FlowLayoutPanel1.Enabled = True
                End If

                Return
                Exit Sub
            End If
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        abortsearching = True

        Try
            If abortsearching = True Then
                thread.Abort()
            End If

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub EditDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditDetailsToolStripMenuItem.Click

        If lvlwithdrawalList.SelectedItems(0).BackColor = cRowColor.withdrawn Then
            customMsg.message("error", "this transaction is not applicable for editing details", "SUPPLY INFO:")
            Exit Sub
        End If

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        button_click_name = "EditDetailsToolStripMenuItem"

        FPOFORM.dgvPOList.Rows.Clear()
        Dim counter As Integer

        With FPOFORM
            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_withdrawal_new1", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 6)
                newCMD.Parameters.AddWithValue("@ws_id", lvlwithdrawalList.SelectedItems(0).Text)
                newDR = newCMD.ExecuteReader
                Dim a(20) As String

                While newDR.Read
                    a(0) = True
                    a(1) = newDR.Item("supplier").ToString
                    a(2) = newDR.Item("wh_id").ToString
                    a(3) = newDR.Item("item_name").ToString
                    a(4) = newDR.Item("item_desc").ToString
                    a(5) = newDR.Item("ws_no").ToString
                    a(6) = newDR.Item("terms").ToString
                    a(7) = CDec(newDR.Item("qty").ToString)
                    a(8) = newDR.Item("unit").ToString
                    a(9) = newDR.Item("unit_price").ToString
                    a(10) = FormatNumber(CDec(newDR.Item("total_amount").ToString), 2, , TriState.True)
                    a(11) = newDR.Item("po_det_id").ToString
                    a(12) = newDR.Item("rs_id").ToString
                    'a(13) = newDR.Item("lof_id").ToString
                    a(14) = newDR.Item("IN_OUT").ToString
                    'a(15) = newDR.Item("type_of_purchasing").ToString
                    '(16) = FReceivingReport.multiplecharges(newDR.Item("rs_id").ToString, 1)
                    .dgvPOList.Rows.Add(a)

                    .dgvPOList.Rows(counter).Cells("column1").ReadOnly = True
                    .dgvPOList.Rows(counter).Cells("column2").ReadOnly = True
                    .dgvPOList.Rows(counter).Cells("column3").ReadOnly = True
                    .dgvPOList.Rows(counter).Cells("column11").ReadOnly = True
                    .dgvPOList.Rows(counter).Cells("column6").ReadOnly = True
                    .dgvPOList.Rows(counter).Cells("column9").ReadOnly = True
                    .dgvPOList.Rows(counter).Cells("column10").ReadOnly = True
                    .dgvPOList.Rows(counter).Cells("column12").ReadOnly = True
                    .dgvPOList.Rows(counter).Cells("column14").ReadOnly = True
                    .dgvPOList.Rows(counter).Cells("col_inout").ReadOnly = True
                    .dgvPOList.Rows(counter).Cells("col_typeofreq").ReadOnly = True
                    .dgvPOList.Rows(counter).Cells("col_rs_id").ReadOnly = True

                    counter += 1
                End While

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                '.lblInOut.Text = "OUT"
                .txtInstructions.ReadOnly = False
                .txtPrepared_by.Enabled = False
                .txtChecked_by.Enabled = False
                .txtApproved_by.Enabled = False
                .DTPTrans.Enabled = False
                .txtRemarks.Enabled = False
                .cmbdr_option.Enabled = False
                .txtRsNo.Enabled = False

                .Label10.Text = "Withdraw From:"
                .Label9.Text = "Withdraw by:"
                .Label12.Text = "Released by:"
                .Label15.Text = "WITHDRAWAL"

                .Label10.Visible = False
                .txtPrepared_by.Visible = False
                .Label6.Visible = False
                .txtInstructions.Visible = False
                .Label11.Visible = False
                .DTPdateneeded.Visible = False
                .lbox_List.Visible = False




                .btnSave.Text = "Update"

                newSQ.connection.Close()
                form_active("FPOFORM")
                .Show()

            End Try
        End With

    End Sub

    Private Sub lvlwithdrawalList_Click(sender As Object, e As EventArgs) Handles lvlwithdrawalList.Click
        Try
            If lvlwithdrawalList.Items.Count > 0 Then
                pub_ws_id2 = Utilities.ifBlankReplaceToZero(lvlwithdrawalList.SelectedItems(0).Text) 'IIf(IsNumeric( lvlwithdrawalList.SelectedItems(0).Text), lvlwithdrawalList.SelectedItems(0).Text, 0)
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtItemSearch_GotFocus(sender As Object, e As EventArgs) Handles txtItemSearch.GotFocus
        If txtItemSearch.Text = "Items..." Then
            txtItemSearch.Clear()
            txtItemSearch.ForeColor = Color.Black
        End If

    End Sub

    Private Sub txtItemSearch_Leave(sender As Object, e As EventArgs) Handles txtItemSearch.Leave

        If txtItemSearch.Text = "" Then
            txtItemSearch.Text = "Items..."
            txtItemSearch.ForeColor = Color.Gray
        End If
    End Sub


    Private Sub BW_Search_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BW_Search.DoWork

        cListOfWs = Withdrawal_Data.LISTOFWITHDRAWAL()
        display_ws()

    End Sub
    Private Sub display_ws(Optional listofpo As Object = Nothing)

        For Each row As Model._Mod_Withdrawal.Withdrawal_Fields In cListOfWs
            Dim a(28) As String

            Dim properName As New PropsFields.whItems_properName_fields
            properName = getProperNameUsingWhPnId2(row.wh_pn_id)

            Dim proName As String = ""

            If properName Is Nothing Then
                proName = ""
            Else
                proName = properName.item_desc
            End If

            a(0) = row.ws_id
            a(1) = row.ws_no
            a(2) = row.rs_no
            a(3) = row.ws_date
            a(4) = row.item_name
            a(5) = row.ws_qty
            a(6) = row.unit
            a(7) = FormatNumber(row.unit_price, 2,, TriState.True)
            a(8) = FormatNumber(row.amount, 2,, TriState.True)
            a(9) = row.item_desc & IIf(row.wh_pn_id = 0, "", $" → {proName}")
            a(10) = row.withdrawn_from
            a(11) = "-" 'row.withdrawn_by
            a(12) = "-" 'row.released_by
            a(13) = "- released" 'row.status
            a(14) = row.charges
            a(15) = row.ws_info_id
            a(16) = row.rs_id
            a(18) = row.wh_id
            a(19) = row.remarks
            a(20) = row.dr_option
            a(21) = row.purpose
            a(24) = row.issued_by

            Dim withdrawnId As New List(Of PropsFields.withdrawn_props_fields)
            withdrawnId = cListOfWithdrawnItems.Where(Function(x) x.ws_id = row.ws_id).ToList()

            If withdrawnId.Count > 0 Then
                a(22) = withdrawnId(0).withdrawn_id
            Else
                a(22) = 0
            End If


            Dim lvl As New ListViewItem(a)
            lvl.BackColor = cRowColor.released

            cListofListview.Add(lvl)

            'for partially withdrawn
            For Each row1 In cListOfPartiallyWithdrawn
                If withdrawnId.Count > 0 Then
                    If withdrawnId(0).withdrawn_id = row1.withdrawn_id And Not row1.status = "deleted" Then
                        Dim aa(23) As String

                        For i = 0 To 22
                            aa(i) = "-"
                        Next

                        aa(0) = row.ws_id
                        aa(3) = row1.date_partially_withdrawn
                        aa(5) = row1.partially_withdrawn_qty
                        aa(9) = $"- {proName}"
                        aa(11) = row1.received_by
                        aa(12) = row1.released_by
                        aa(13) = "- withdrawn"
                        aa(23) = row1.partially_withdrawn_id

                        Dim lvl2 As New ListViewItem(aa)
                        lvl2.BackColor = cRowColor.withdrawn

                        cListofListview.Add(lvl2)
                    End If
                End If
            Next
        Next

    End Sub

    Private Sub WithdrawnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WithdrawnToolStripMenuItem.Click

#Region "FOR WAREHOUSING WITHDRAWAL"
        Try

            'kung withdrawn row di pede maka withdraw ddto ra sa release row
            If lvlwithdrawalList.SelectedItems(0).BackColor = cRowColor.withdrawn Then
                customMsg.message("error", "you must select the released row to proceed in this transaction", "SUPPLY INFO:")
                Exit Sub
            End If

            'check if all partial qty already withdrawn
            Dim qty_released As Double = lvlwithdrawalList.SelectedItems(0).SubItems(5).Text
            Dim ws_id As Integer = lvlwithdrawalList.SelectedItems(0).Text

            Dim partiallyWithdrawnQty As Double = countPartiallyWithdrawn(ws_id)

            If partiallyWithdrawnQty >= qty_released Then
                customMsg.message("error", "All qty release has been withdrawn", "SUPPLY INFO:")
                Exit Sub
            End If


            'check for warehousing or hauling
            Dim whId As Integer = lvlwithdrawalList.SelectedItems(0).SubItems(18).Text
            Dim abc As New List(Of PropsFields.whItems_props_fields)


            abc = Results.cResult.Where(Function(x) x.wh_id = whId).ToList()

            If abc(0).division = cDivision.WAREHOUSING_AND_SUPPLY Then

                FWithdrawnItems.isForTire = isForTire()
                FWithdrawnItems.cWhId = whId
                FWithdrawnItems.saveStatus = SaveBtn.Save
                FWithdrawnItems.ShowDialog()

                Exit Sub
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
            Exit Sub
        End Try

#End Region

        'Dim rs_no As String

        If MessageBox.Show("Are you sure you want to withdraw this item?", "Suppy Info:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim rs_id As Integer

            Dim withdrawnData = cListOfWithdrawnItems.Where(Function(x) x.ws_id = lvlwithdrawalList.SelectedItems(0).Text).ToList()

            If withdrawnData.Count > 0 Then
                customMsg.message("error", "this item has already withdrawn", "SUPPLY INFO:")
                Exit Sub
            End If

            For Each row As ListViewItem In lvlwithdrawalList.Items
                If row.Selected = True Then

                    rs_id = CInt(row.SubItems(16).Text)
                    Dim ws_id As Integer = CInt(row.Text)
                    cWsId = ws_id

                    'Dim query As String = "INSERT INTO dbwithdrawn_items(rs_id,ws_id,date_log_withdrawn) VALUES(" & rs_id & "," & ws_id & ",'" & Format(Date.Parse(Now), "yyyy-MM-dd") & "')"
                    'UPDATE_INSERT_DELETE_QUERY(query, 0, "INSERT")

                    'rs_no = row.SubItems(2).Text

                    Dim cc As New ColumnValuesObj
                    cc.add("rs_id", rs_id)
                    cc.add("ws_id", ws_id)
                    cc.add("date_log_withdrawn", Date.Parse(Now))
                    cc.insertQuery("dbwithdrawn_items")

                End If
            Next

            'If MessageBox.Show("Do you want to link this item to other warehouse?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            '    button_click_name = "link_to_other_wh"
            '    FWarehouseItems.ShowDialog()

            'End If

            loadingStat = LoadingStatus.withdrawalReleased
            cLoadType = LoadingStatus.withdraw
            loadWhItems()

            Exit Sub

        End If

        'If Application.OpenForms().OfType(Of FRequistionForm).Any Then
        '    'it means open
        '    With FRequistionForm
        '        .cmbDivision.Text = "WAREHOUSING AND SUPPLY"
        '        .cmbSearchByCategory.Text = "Search by RS.No."
        '        .txtSearch.Text = rs_no
        '        .btnSearch.PerformClick()
        '    End With

        'Else
        '    'wala open 
        'End If

        'btnSearch.PerformClick()
        'listfocus(lvlwithdrawalList, rs_id)
    End Sub


    Private Sub ViewStockcardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewStockcardToolStripMenuItem.Click
        With FStockCard3
            Dim wh_id As Integer = lvlwithdrawalList.SelectedItems(0).SubItems(18).Text
            Dim data = Results.cResult.Where(Function(x) x.wh_id = wh_id).ToList()

            If data.Count > 0 Then
                .loadStockCard(wh_id)
                .Text = $"{data(0).item_name} - {data(0).item_desc} ({ data(0).warehouse_area })"
                .ShowDialog()
            End If

        End With
    End Sub

    Private Sub EditInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditInfoToolStripMenuItem.Click
        Try
            Dim selectedRow = lvlwithdrawalList.SelectedItems(0)

            'edit all is not applicable for partially withdrawn
            If selectedRow.BackColor = cRowColor.withdrawn Then
                customMsg.message("error", "edit all is not applicable for partially withdrawn...", "SUPPLY INFO:")
                Exit Sub
            End If

            If selectedRow.SubItems(26).Text = cDivision.CRUSHING_AND_HAULING Then
                With FCreateWithdrawalSlipForDr.updateWithdrawalStorage

                    .ws_id = selectedRow.Text
                    .ws_info_id = selectedRow.SubItems(15).Text
                    .rs_no = selectedRow.SubItems(2).Text
                    .ws_date = selectedRow.SubItems(3).Text
                    .dr_option = selectedRow.SubItems(20).Text
                    .remarks = selectedRow.SubItems(19).Text
                    .released_by = selectedRow.SubItems(12).Text
                    .withdrawn_by = selectedRow.SubItems(11).Text
                    .ws_no = selectedRow.SubItems(1).Text
                    .ws_qty = selectedRow.SubItems(5).Text
                    .unit = selectedRow.SubItems(6).Text
                    .price = selectedRow.SubItems(7).Text
                    .rs_id = selectedRow.SubItems(16).Text


                End With

                With FCreateWithdrawalSlipForDr
                    .isEdit = True
                    .ShowDialog()
                End With

            ElseIf selectedRow.SubItems(26).Text = cDivision.WAREHOUSING_AND_SUPPLY Then
                With FCreateWithdrawalSlip.updateWithdrawalStorage

                    .ws_id = selectedRow.Text
                    .ws_info_id = selectedRow.SubItems(15).Text
                    .rs_no = selectedRow.SubItems(2).Text
                    .ws_date = selectedRow.SubItems(3).Text
                    .dr_option = selectedRow.SubItems(20).Text
                    .remarks = selectedRow.SubItems(19).Text
                    .released_by = selectedRow.SubItems(12).Text
                    .withdrawn_by = selectedRow.SubItems(11).Text
                    .ws_no = selectedRow.SubItems(1).Text
                    .ws_qty = selectedRow.SubItems(5).Text
                    .unit = selectedRow.SubItems(6).Text
                    .price = selectedRow.SubItems(7).Text
                    .rs_id = selectedRow.SubItems(16).Text
                    .date_issued = selectedRow.SubItems(3).Text
                    .issued_by = selectedRow.SubItems(24).Text
                    .serial_id = selectedRow.SubItems(27).Text

                End With


                With FCreateWithdrawalSlip
                    .cWsId = selectedRow.Text
                    .isEdit = True
                    .btnFinalSave.Text = "Update Withdrawal"
                    .ShowDialog()
                End With
            End If



        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub CancelWithdrawToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelWithdrawToolStripMenuItem.Click
        Dim rowSelection = lvlwithdrawalList.SelectedItems(0)

        If rowSelection.SubItems(26).Text = cDivision.WAREHOUSING_AND_SUPPLY Then
            customMsg.message("error", "It's not applicable in warehousing and supply...", "SUPPLY INFO:")
            Exit Sub
        End If

        If rowSelection.SubItems(13).Text = "- released" Then
            customMsg.message("error", "this transaction is not applicable for warehousing...", "SUPPLY INFO:")
            Exit Sub
        End If

        If customMsg.messageYesNo("Are you sure you want to cancel withdraw to this item?", "SUPPLY INFO:", MessageBoxIcon.Question) Then
            Dim cc As New ColumnValuesObj
            cc.setCondition($"ws_id = {rowSelection.Text}")
            cc.deleteData("dbwithdrawn_items")

            cWsId = rowSelection.Text

            cLoadType = LoadingStatus.cancelWithdrawn
            loadingStat = LoadingStatus.withdrawalReleased
            loadWhItems()


        End If
    End Sub

    Private Sub EditWithdrawnItemsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditWithdrawnItemsToolStripMenuItem.Click

        If lvlwithdrawalList.SelectedItems(0).BackColor = cRowColor.withdrawn Then
            With FWithdrawnItems

                .txtAmount.Enabled = False
                .amountUI.resetBgColor()

                .partiallyWithdrawnId = lvlwithdrawalList.SelectedItems(0).SubItems(23).Text
                .btnWithdraw.Text = "Update"
                .saveStatus = SaveBtn.Update
                .ShowDialog()
            End With
        Else
            customMsg.message("error", "not applicable in this transaction...", "SUPPLY INFO:")
        End If



    End Sub

    Private Sub EditReleaseItemsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditReleaseItemsToolStripMenuItem.Click
        Try
            If lvlwithdrawalList.SelectedItems(0).BackColor = cRowColor.released Then

                Dim rawData As New List(Of PropsFields.withdrawal_props_fields)
                rawData = cListofWithdrawal

                Dim data = rawData.Where(Function(x) x.ws_id = lvlwithdrawalList.SelectedItems(0).Text).ToList()
                Dim whData = Results.cResult.Where(Function(x) x.wh_id = lvlwithdrawalList.SelectedItems(0).SubItems(18).Text).ToList()

                If data.Count > 0 Then
                    With FCreateWithdrawalSlip
                        .saveStatus = SaveBtn.Update
                        .btnFinalSave.Text = "Update (Ctrl + S)"
                        .btnReleaseNow.Enabled = False
                        .Panel5.Enabled = False
                        .cWsInfoId = lvlwithdrawalList.SelectedItems(0).SubItems(15).Text
                        .cWsId = lvlwithdrawalList.SelectedItems(0).Text

                        With .wsNew
                            .charges = data(0).charges
                            .rs_no = data(0).rs_no
                            .issued_by = data(0).issued_by
                            .whLocation = whData(0).warehouse_area

                            FCreateWithdrawalSlip.dtpDateIssued.Text = data(0).ws_date
                            FCreateWithdrawalSlip.dtpDateNeeded.Text = data(0).date_needed

                        End With

                        .ShowDialog()
                    End With
                End If
            Else
                customMsg.message("error", "this transaction is not applicable in editing release items", "SUPPLY INFO:")
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try


    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub BW_Search_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BW_Search.RunWorkerCompleted
        lvlwithdrawalList.Items.Clear()

        lvlwithdrawalList.Items.AddRange(cListofListview.ToArray)
        Panel3.Visible = False
        cListofListview.Clear()

        'for row select after partially withdraw
        If loadingStat = LoadingStatus.partiallyWithdrawn Then
            listfocus(lvlwithdrawalList, cPartiallyWithdrawnId)
        End If

        'reset all
        cPartiallyWithdrawnId = 0
        loadingStat = 0
    End Sub

#Region "BUSINESS LOGIC"
    Public Function isForTire() As Boolean
        Try
            Dim tireCategory As New OTHERSCATEGORY

            Dim selectedRow = lvlwithdrawalList.SelectedItems(0)

            If selectedRow.SubItems(28).Text = tireCategory.TIRE_STORAGE Then
                isForTire = True
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function
#End Region

#Region "UTILITIES"
    Private Function getSerialNo(serial_id As Integer) As String
        Try
            Dim result = Results.rListOfTireSerialNoView?.FirstOrDefault(Function(x) x.serial_id = serial_id)

            Return result?.serial_no
        Catch ex As Exception

        End Try
    End Function

    Private Function isCancelWithdrawal(row As PropsFields.withdrawal_props_fields) As Boolean
        Try

            Dim transId As Integer = CInt(row.ws_id)

            Dim cancelResult = isCancelledDataFor(transId, "WS")

            If cancelResult Then
                Return True
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

#End Region

#Region "PRIVATE GET"
    Private Function isCancelledDataFor(transId As Integer,
                                        transaction As String) As Boolean
        Try
            Dim isCancelled = cListOfCancelledTransaction.FirstOrDefault(Function(x)
                                                                             Return x.trans_id = transId And x.trans = transaction
                                                                         End Function)



            If isCancelled IsNot Nothing Then
                Return True
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
#End Region

#Region "CRUD"
    Private Sub removeReleasedItems(ws_info_id As Integer, ws_id As Integer, withdrawn_id As Integer)
        Try
            Dim cc As New ColumnValuesObj
            Dim tables As New List(Of PropsFields.SMSTables)
            With tables
                .Add(addTable("dbPO", $"po_id = {ws_info_id}"))
                .Add(addTable("dbPO_details", $"po_det_id = {ws_id}"))
                .Add(addTable("dbwithdrawn_items", $"withdrawn_id = {withdrawn_id}"))
            End With

            cc.deleteDataUsingRollback(tables)
        Catch ex As Exception

        End Try
    End Sub
#End Region
End Class