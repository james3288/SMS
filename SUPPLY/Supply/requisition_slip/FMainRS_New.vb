
Public Class FMainRS_New

    Private main_rs_qty_id As Integer
    Private cListOfMainRsFields As New List(Of ListViewItem)
    Private cListOfMainRsFields2 As New List(Of ListViewItem)
    Dim cBgWorkerChecker As Timer
    Private mainRsSubModel, mainRsModel As New ModelNew.Model
    Dim drModel As ModelDR
    Dim mainRsSub As New List(Of PropsFields.main_rsdata_props_fields)
    Dim mainRs As New List(Of PropsFields.main_rsdata_props_fields)
    Private cListOfMainRsSub As New List(Of PropsFields.main_rsdata_props_fields)
    Private clistOfMainRs As New List(Of PropsFields.main_rsdata_props_fields)
    Public isCreateMainRsQty As Boolean
    Private customMsg As New customMessageBox
    Private clistOfListViewItemNew As New List(Of ListViewItem)
    Private clistOfListViewItemNew2 As New List(Of ListViewItem)

    Private openCloseQtyCategoryUI,
        openCloseQtyUI As New class_placeholder5

    Private cMainRsQuantity As Double
    Private cTotalRequest As Double
    Private Class MainRsFields
        Public Property id As Integer
        Public Property rsNo As String
        Public Property mainQty As Double
        Public Property subQty As Double
        Public Property source As String
        Public Property openedClosed As String

    End Class

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Const CS_DROPSHADOW As Integer = &H20000
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_DROPSHADOW
            Return cp
        End Get
    End Property

    Private Sub FMainRS_New_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim newFont As New ColumnValues
        newFont.add("fontName", cFontsFamily.bombardier)
        newFont.add("fontSize", 12)

        openCloseQtyCategoryUI.king_placeholder_combobox("open/close...",
                                                         cmbOpenCloseQty,
                                                         Nothing,
                                                         Panel1,
                                                         My.Resources.received,,,,
                                                         newFont.getValues())


        openCloseQtyUI.king_placeholder_textbox("quantity...",
                                                txtMainRSQty,
                                                Nothing,
                                                Panel1,
                                                My.Resources.received,
                                                True,,,,,
                                                newFont.getValues())

        ListView1.BackColor = ColorTranslator.FromHtml("#0A0F15")
        ListView2.BackColor = ColorTranslator.FromHtml("#0A0F15")

        If isCreateMainRsQty Then
            loadMainRsNew()
            Exit Sub
        End If

        Dim p_main_rs_qty As New class_placeholder4
        Dim p_openclose_qty As New class_placeholder4

        Dim cListOfListViewitem As New List(Of ListViewItem)
        Dim rs_no As String = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(1).Text

        ListView1.Items.Clear()
        ListView2.Items.Clear()

        p_main_rs_qty.king_placeholder_textbox("Main RS QTY...", txtMainRSQty, Nothing, Panel1, My.Resources.loan, True, "White")
        p_openclose_qty.king_placeholder_combobox("OPEN/CLOSE", cmbOpenCloseQty, Nothing, Panel1, My.Resources.open, "White")

        Dim mainrsqty As New class_main_rs_qty
        'mainrsqty._initialize(rs_no, ListView2, FRequistionForm.cAggregates, ListView1, True)

        lblOldMainRsQty.Text = mainrsqty.OLD_MAIN_RS_QTY(rs_no)
        Label3.Text = IIf(mainrsqty.cOpenCloseQty = 1, "open-qty", "close-qty")

        'display   

        drModel = FRequistionForm.GetDRModel
        mainRsSub = drModel.GetListOfMainRsSub()
        mainRs = drModel.GetListOfMainRs()

        display()
    End Sub

    Private Sub loadMainRsNew()
        clistOfListViewItemNew.Clear()
        clistOfListViewItemNew2.Clear()

        ListView1.Items.Clear()
        ListView2.Items.Clear()

        cTotalRequest = 0

        displayMainRsResult()
    End Sub

    Private Sub displayMainRsResult()
        Try
            Dim rsRows = FRequesitionFormForDR.getNewDrModel()

            'to sub Rs with main
            For Each row In rsRows.getListOfRsDatas
                If row.level = rsRows.getLevel.main_rs Then
                    requesitionSlipMainRsRow(row)
                End If
            Next

            'to sub Rs without main
            For Each row In rsRows.getListOfRsDatas
                If row.level = rsRows.getLevel.sub_rs Then
                    If row.main_rs_qty_id = 0 Then
                        requesitionSlipNoMainRsRow(row)
                    End If
                End If
            Next

            ListView2.Items.AddRange(clistOfListViewItemNew.ToArray())
            ListView1.Items.AddRange(clistOfListViewItemNew2.ToArray())

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub requesitionSlipMainRsRow(rsRow As RSDRModel.COLUMNS)
        Try
            Dim rsRows = FRequesitionFormForDR.getNewDrModel()
            Dim a(6) As String
            With rsRow
                a(0) = rsRow.rs_id
                a(1) = rsRow.rs_no
                a(2) = rsRow.rs_qty
                a(4) = rsRow.source
                a(6) = rsRow.level

                Dim mainRs = rsRows.getMainRs().FirstOrDefault(Function(x) x.main_rs_qty_id = rsRow.rs_id)?.open_close_qty
                a(5) = IIf(mainRs = 0, "CLOSE QTY", "OPEN QTY")
            End With

            'Dim lvl As New ListViewItem(a)
            'lvl.BackColor = ColorTranslator.FromHtml("#0A0F15")
            'lvl.ForeColor = Color.White
            'lvl.Font = New Font(cFontsFamily.bombardier, 13, FontStyle.Regular)
            Dim lvl = Utilities.customListViewRowColorAndFonts(a,
                                                               ColorTranslator.FromHtml("#0A0F15"),
                                                               Color.White,
                                                               cFontsFamily.bombardier)

            Utilities.customListViewHeight(ListView2)
            clistOfListViewItemNew.Add(lvl)

            For Each row In rsRows.getListOfRsDatas
                If row.level = rsRows.getLevel.sub_rs Then
                    If rsRow.rs_id = row.main_rs_qty_id Then
                        requesitionSlipSubRsRow(row, rsRow.rs_id)
                    End If
                End If
            Next

            requesitionRemainingBalanceRow(rsRow.rs_id)
            cTotalRequest = 0

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Sub requesitionSlipSubRsRow(rsRow As RSDRModel.COLUMNS,
                                        Optional mainRsId As Integer = 0)
        Try
            Dim a(7) As String
            With rsRow
                a(0) = rsRow.rs_id
                a(1) = "-"
                a(2) = rsRow.item_desc
                a(3) = rsRow.rs_qty
                a(4) = rsRow.source
                a(6) = rsRow.level
                a(7) = mainRsId

            End With
            Dim lvl As New ListViewItem(a)
            lvl.BackColor = cRsRowColor.MainSubRS
            lvl.ForeColor = cRsRowColor.Dr

            clistOfListViewItemNew.Add(lvl)
            cTotalRequest += rsRow.rs_qty
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Sub requesitionSlipNoMainRsRow(rsRow As RSDRModel.COLUMNS)
        Try
            Dim a(6) As String
            With rsRow
                a(0) = rsRow.rs_id
                a(1) = rsRow.rs_no
                a(2) = rsRow.item_desc
                a(5) = rsRow.rs_qty
                a(6) = rsRow.type_of_purchasing

            End With

            Dim lvl = Utilities.customListViewRowColorAndFonts(a,
                                                               cRsRowColor.MainSubRS,
                                                               cRsRowColor.Dr,
                                                               cFontsFamily.bombardier)

            Utilities.customListViewHeight(ListView1)
            clistOfListViewItemNew2.Add(lvl)

            'movable panel
            Dim myPanel As New MovablePanel

            myPanel.addPanel(Panel2)

            myPanel.initializeForm(Me)
            myPanel.addPanelEventHandler()

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Sub requesitionRemainingBalanceRow(mainRsId As Integer)
        Try
            Dim rsRows = FRequesitionFormForDR.getNewDrModel()
            Dim mainRs = rsRows.getMainRs()

            Dim a(6) As String
            a(1) = "-"
            a(2) = "Remaining Balance:"
            a(3) = mainRs.FirstOrDefault(Function(x) x.main_rs_qty_id = mainRsId)?.main_rs_qty - cTotalRequest
            a(6) = "-"

            Dim lvl As New ListViewItem(a)
            lvl.BackColor = cRsRowColor.totalRow
            lvl.ForeColor = cRsRowColor.Dr

            clistOfListViewItemNew.Add(lvl)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub display()
        Dim rs As New List(Of PropsFields.rsdata_props_fields)
        rs = drModel.GetListOfRs()

        cListOfMainRsFields.Clear()
        cListOfMainRsFields2.Clear()

        ListView2.Items.Clear()
        ListView1.Items.Clear()

        For Each row In mainRs
            Dim a(5) As String
            a(0) = row.main_rs_qty_id
            a(1) = row.rs_no
            a(2) = IIf(row.open_close_qty = 1, "ᨖ", row.main_rs_qty)
            a(5) = IIf(row.open_close_qty = 1, "OPEN QTY", "CLOSE QTY")

            Dim lvl As New ListViewItem(a)

            lvl = customListviewItem(cRsRowColor.MainRs, a, FontStyle.Bold, 11, Color.Black)
            cListOfMainRsFields.Add(lvl)

            'Main RS-SUB
            For Each row2 In mainRsSub
                If row2.main_rs_qty_id = row.main_rs_qty_id Then
                    'RS
                    Dim rowRs = rs.Where(Function(x) x.rs_id = row2.rs_id).ToList()

                    If rowRs.Count > 0 Then
                        With rowRs(0)
                            Dim aa(5) As String

                            aa(0) = .rs_id
                            aa(2) = getProperNaming(rowRs(0))
                            aa(3) = .rs_qty
                            aa(4) = .source

                            Dim lvl1 As New ListViewItem
                            lvl1 = customListviewItem(cRsRowColor.MainSubRS, aa, FontStyle.Bold, 11, Color.White)

                            cListOfMainRsFields.Add(lvl1)
                        End With
                    End If
                End If
            Next
        Next

        For Each req In rs
#Region "==> RS"
            '==> RS
            With req
                If Not .inout = cInOut._IN And
                    Not .type_of_purchasing = cTypeOfPurchasing.DR And
                    Not .request_type = "" And
                    Not .process = "" Then

                    forRsRow(req)

                ElseIf .inout = cInOut._IN Or .inout = cInOut._OTHERS Then

                    If .type_of_purchasing = cTypeOfPurchasing.DR And
                        .request_type <> "" And
                        .process <> "" Then

                        forRsRow(req)

                    ElseIf .type_of_purchasing = cTypeOfPurchasing.PURCHASE_ORDER Then
                        forRsRow(req)
                    End If

                Else
                    If Not req.rs_no.ToUpper() = "N/A" Then
                        forRsRow(req)
                    End If

                End If
            End With
#End Region
        Next

        ListView2.Items.AddRange(cListOfMainRsFields.ToArray)
        ListView1.Items.AddRange(cListOfMainRsFields2.ToArray)
    End Sub

    Private Sub forRsRow(row As PropsFields.rsdata_props_fields)

        Dim check = mainRsSub.Where(Function(x) x.rs_id = row.rs_id).ToList()

        If Not check.Count > 0 Then

            Dim bb(6) As String
            bb(0) = row.rs_id
            bb(1) = row.rs_no
#Region "PROPERNAMING"
            bb(2) = getProperNaming(row)
#End Region
            bb(3) = row.source
            bb(4) = row.charges
            bb(5) = row.rs_qty
            bb(6) = row.type_of_purchasing

            Dim lvl2 As New ListViewItem(bb)
            cListOfMainRsFields2.Add(lvl2)

        End If

    End Sub

    Private Function getProperNaming(row As PropsFields.rsdata_props_fields) As String

        Dim wh_pn_id As Integer = Utilities.ifBlankReplaceToZero(row.wh_pn_id)
        Dim properNameWithoutWhId = Results.cListOfProperNaming.Where(Function(x) x.wh_pn_id = wh_pn_id).ToList()

        getProperNaming = Utilities.formatProperNamingNew_RS_WS_RR_DR(wh_pn_id,
                                                                row.wh_id,
                                                                row.rs_items,
                                                                row.item_desc)

        Return getProperNaming
    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        customMsg.message("error", "sorry for the inconvenience, this feature is under maitenance...", "SMS INFO:")
        Exit Sub

        Dim mainrsqty As New class_main_rs_qty
        Dim rs_no As String = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(1).Text

        If btnSave.Text = "SAVE" Then
            If MessageBox.Show("Are you sure you want save this data?", "SUPPLLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Dim cc As New ColumnValuesObj

                cc.add("rs_no", rs_no)
                cc.add("main_rs_qty", IIf(cmbOpenCloseQty.Text = "OPEN QTY", 0, txtMainRSQty.Text))
                cc.add("open_close", IIf(cmbOpenCloseQty.Text = "OPEN QTY", 1, 0))
                Dim id As Integer = cc.insertQuery_and_return_id("dbMain_Qty3")

                If id > 0 Then
                    reloadMainRsAndMainSubRs(rs_no)
                End If
            Else
                Exit Sub
            End If
        Else
            If MessageBox.Show("Are you sure you want update this data?", "SUPPLLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                mainrsqty.update(main_rs_qty_id, IIf(txtMainRSQty.Text = "-", 0, txtMainRSQty.Text), cmbOpenCloseQty.Text)
                btnSave.Text = "SAVE"
            Else
                Exit Sub
            End If
        End If

        For Each ctr As Control In Me.Controls
            ctr.Enabled = True
        Next

        ListView2.Items.Clear()
        ListView1.Items.Clear()

        txtMainRSQty.Clear()
        txtMainRSQty.Focus()

        ''mainrsqty._initialize(rs_no, ListView2, FRequistionForm.cAggregates, ListView1)
        'mainrsqty._initialize(rs_no, ListView2, FRequistionForm.cAggregates, ListView1, True)


    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        For Each ctr As Control In Me.Controls
            If ctr.Name = "Panel1" Then
                ctr.Enabled = True
            Else
                ctr.Enabled = False
            End If
        Next

        Dim rsRows = FRequesitionFormForDR.getNewDrModel()

        'txtMainRSQty.Text = ListView2.SelectedItems(0).SubItems(2).Text

        main_rs_qty_id = ListView2.SelectedItems(0).Text
        cmbOpenCloseQty.Text = ListView2.SelectedItems(0).SubItems(5).Text
        txtMainRSQty.Text = rsRows.getMainRs().FirstOrDefault(Function(x)
                                                                  Return x.main_rs_qty_id = main_rs_qty_id
                                                              End Function)?.main_rs_qty
        Button1.Text = "UPDATE"

    End Sub

    Private Sub FMainRS_New_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            For Each ctr As Control In Me.Controls
                ctr.Enabled = True
            Next

            txtMainRSQty.Clear()
            txtMainRSQty.Focus()
            cmbOpenCloseQty.SelectedIndex = 1

            btnSave.Text = "SAVE"

        End If

    End Sub

    Private Sub ListView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView2.SelectedIndexChanged

    End Sub

    Private Sub ListView2_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles ListView2.ItemChecked
        If e.Item.Checked Then
            For Each item As ListViewItem In ListView2.Items
                If item IsNot e.Item Then
                    item.Checked = False
                End If
            Next
        End If
    End Sub

    Private Sub btnInclude_Click(sender As Object, e As EventArgs) Handles btnInclude.Click

        If MessageBox.Show("Are you sure you want to include the selected item from list?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then


            Dim main_rs_qty_id As Integer
            Dim rs_no As String = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(1).Text
            Dim open_close As String = ""
            Dim count As Integer

            'get main_rs_qty_id
            For Each row As ListViewItem In ListView2.Items
                If row.Checked = True And row.BackColor = Color.Lime Then
                    main_rs_qty_id = row.Text
                    open_close = row.SubItems(5).Text
                    count += 1
                ElseIf row.Checked = True And row.BackColor <> Color.Lime Then
                    MessageBox.Show("Please select the main rs qty row!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit For
                    Exit Sub
                End If
            Next

            If count = 0 Then
                MessageBox.Show("Please select atleast 1 in Listview at the top!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            'select and insert data from listview1
            For Each row2 As ListViewItem In ListView1.Items
                If row2.Checked = True Then

                    'check sa kung pwede ba sa open qty ang rs
                    If check_if_pwede_pang_open_rs(row2.SubItems(6).Text, open_close) = False Then
                        MessageBox.Show("The items (Aggregates) must have item check first or `" & row2.SubItems(6).Text & "` is not applicable to open qty!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        GoTo proceedhere
                    End If

                    Dim SQ As New SQLcon
                    'insert 
                    Dim abc As New class_query
                    abc.add_parameter("@n", 9)
                    abc.add_parameter("@main_rs_qty_id", main_rs_qty_id)
                    abc.add_parameter("@rs_id", row2.Text)

                    abc.insert_update("proc_main_rs_qty", SQ.connection).ExecuteNonQuery()
                    SQ.connection.Close()
                End If
proceedhere:
            Next

            ListView1.Items.Clear()
            ListView2.Items.Clear()

            'Dim mainrsqty As New class_main_rs_qty
            ''mainrsqty._initialize(rs_no, ListView2, FRequistionForm.cAggregates, ListView1)
            'mainrsqty._initialize(rs_no, ListView2, FRequistionForm.cAggregates, ListView1, True)

            reloadSubRs(rs_no)
        End If

    End Sub
    Private Function check_if_pwede_pang_open_rs(type_of_purchasing As String, open_close_qty As String) As Boolean
        If type_of_purchasing = "DR" And open_close_qty = "OPEN QTY" Or type_of_purchasing = "DR" And open_close_qty = "CLOSE QTY" Then
            check_if_pwede_pang_open_rs = True
        ElseIf type_of_purchasing = "WITHDRAWAL" And open_close_qty = "OPEN QTY" Or
            type_of_purchasing = "PURCHASE ORDER" And open_close_qty = "OPEN QTY" Then

            check_if_pwede_pang_open_rs = False

        ElseIf type_of_purchasing = "WITHDRAWAL" And open_close_qty = "CLOSE QTY" Or
            type_of_purchasing = "PURCHASE ORDER" And open_close_qty = "CLOSE QTY" Then

            check_if_pwede_pang_open_rs = True
        Else

        End If

    End Function

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click


        Try
            Dim selectedRow = FRequesitionFormForDR.DataGridView1.SelectedRows(0)
            Dim cn = FRequesitionFormForDR.getNewDrModel().cn
            Dim rs_no As String = selectedRow.Cells(NameOf(cn.rs_no)).Value
            Dim level = FRequesitionFormForDR.getNewDrModel().getLevel()
            Dim mainRsId As Integer = 0
            Dim rsId As Integer = 0
            Dim whatLevel As String = ""

            For Each row As ListViewItem In ListView2.Items
                If row.Checked = True And row.SubItems(6).Text = level.main_rs Then
                    mainRsId = row.Text
                    whatLevel = row.SubItems(6).Text
                    Exit For
                ElseIf row.Checked = True And row.SubItems(6).Text = level.sub_rs Then
                    rsId = row.Text
                    whatLevel = row.SubItems(6).Text
                    Exit For
                End If
            Next

            Dim tables, removeMainRs As New ColumnValuesObj

            If mainRsId > 0 And whatLevel = level.main_rs Then
                If MessageBox.Show("Are you sure you want remove selected Main RS qty item?" & vbCrLf &
                                   "NOTE: sub items will also be deleted!", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    tables.addTableAndCondition("dbMain_Qty3", $"main_rs_qty_id = {mainRsId}")
                    tables.addTableAndCondition("dbMain_Qty3_details", $"main_rs_qty_id = {mainRsId}")
                    removeMainRs.deleteDataUsingRollback(tables.getListOfTables())

                    reloadAgain()
                End If

            ElseIf rsId > 0 And whatLevel = level.sub_rs Then
                If MessageBox.Show("Are you sure you want remove selected sub RS qty item?", "SUPPLY INFO:",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    tables.addTableAndCondition("dbMain_Qty3_details", $"rs_id = {rsId}")
                    removeMainRs.deleteDataUsingRollback(tables.getListOfTables())

                    reloadAgain()
                End If
            Else
                customMsg.message("error", "there is something wroing in deletion!", "SMS INFO:")
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

        Exit Sub

        '============
        '=====================

        For Each row As ListViewItem In ListView2.Items

            If row.BackColor = Color.Lime And row.Checked = True Then
                If MessageBox.Show("Are you sure you want remove selected Main RS qty item?" & vbCrLf &
                                   "NOTE: sub items will also be deleted!", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then


                    Dim rs_no As String = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(1).Text
                    Dim SQ As New SQLcon
                    'delete 
                    Dim abc As New class_query
                    abc.add_parameter("@n", 10)
                    abc.add_parameter("@main_rs_qty_id", row.Text)
                    abc.insert_update("proc_main_rs_qty", SQ.connection).ExecuteNonQuery()
                    SQ.connection.Close()

                    reloadMainRsAndMainSubRs(rs_no)

                End If


            ElseIf row.BackColor = Color.DarkGreen And row.Checked = True Then
                If MessageBox.Show("Are you sure you want remove selected sub RS qty item?", "SUPPLY INFO:",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    Dim rs_no As String = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(1).Text
                    Dim SQ As New SQLcon
                    'delete 
                    Dim abc As New class_query
                    abc.add_parameter("@n", 11)
                    abc.add_parameter("@rs_id", row.Text)
                    abc.insert_update("proc_main_rs_qty", SQ.connection).ExecuteNonQuery()
                    SQ.connection.Close()

                    'reload sub rs
                    reloadSubRs(rs_no)
                End If

                'ElseIf row.BackColor = cRsRowColor.MainSubRS And row.Checked = True Then
                '    If MessageBox.Show("Are you sure you want remove selected sub RS qty item?", "SUPPLY INFO:",
                '                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                '        Dim SQ As New SQLcon
                '        'delete 
                '        Dim abc As New class_query
                '        abc.add_parameter("@n", 11)
                '        abc.add_parameter("@rs_id", row.Text)
                '        abc.insert_update("proc_main_rs_qty", SQ.connection).ExecuteNonQuery()
                '        SQ.connection.Close()

                '        'reload sub rs
                '        'reloadSubRs(rs_no)
                '    End If

            End If
        Next

        'ListView1.Items.Clear()
        'ListView2.Items.Clear()

        'Dim mainrsqty As New class_main_rs_qty
        'mainrsqty._initialize(rs_no, ListView2, FRequistionForm.cAggregates, ListView1, True)
    End Sub

    Private Sub reloadAgain()
        customMsg.message("warning", "to make it effective, we need to reload the rs", "sms info:")
        FRequesitionFormForDR.btnSearch.PerformClick()
        Me.Dispose()

    End Sub
    Private Sub reloadSubRs(RsNo As String)
        Dim mainRsVal As New ColumnValues
        mainRsVal.add("rs_no", RsNo)
        mainRsSubModel.clearParameter()

        _init_._initializing(cCol.forMainRsSubCRH,
         mainRsVal.getValues(),
         mainRsSubModel,
         searchRsBgWorker)

        cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyReloadMainSubRs, searchRsBgWorker)
    End Sub

    Private Sub reloadMainRsAndMainSubRs(RsNo As String)
        Dim mainRsVal As New ColumnValues
        mainRsVal.add("rs_no", RsNo)
        mainRsModel.clearParameter()
        mainRsSubModel.clearParameter()

        _init_._initializing(cCol.forMainRsSubCRH,
                                 mainRsVal.getValues(),
                                 mainRsSubModel,
                                 searchRsBgWorker)

        _init_._initializing(cCol.forMainRsCRH,
                                     mainRsVal.getValues(),
                                     mainRsModel,
                                     searchRsBgWorker)

        cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessFullyReloadMainRsAndMainRsSub, searchRsBgWorker)
    End Sub

    Private Sub SuccessfullyReloadMainSubRs()
        cListOfMainRsSub = CType(mainRsSubModel.cData, List(Of PropsFields.main_rsdata_props_fields))

        drModel = FRequistionForm.GetDRModel
        mainRsSub = cListOfMainRsSub

        drModel.GetListOfMainRsSub = mainRsSub

        display()
    End Sub

    Private Sub SuccessFullyReloadMainRsAndMainRsSub()
        clistOfMainRs = CType(mainRsModel.cData, List(Of PropsFields.main_rsdata_props_fields))
        cListOfMainRsSub = CType(mainRsSubModel.cData, List(Of PropsFields.main_rsdata_props_fields))

        drModel = FRequistionForm.GetDRModel
        mainRs = clistOfMainRs
        mainRsSub = cListOfMainRsSub

        drModel.GetListOfMainRs = mainRs
        drModel.GetListOfMainRsSub = mainRsSub

        display()
    End Sub

    Private Sub cms_lvlMainRsQty_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cms_lvlMainRsQty.Opening
        If ListView2.SelectedItems(0).BackColor = Color.DarkGreen Or
            ListView2.SelectedItems(0).BackColor = cRsRowColor.MainSubRS Then

            For Each itm As ToolStripItem In cms_lvlMainRsQty.Items
                If itm.Name = "EditToolStripMenuItem" Then
                    itm.Enabled = False
                Else
                    itm.Enabled = True
                End If
            Next

        ElseIf ListView2.SelectedItems(0).BackColor = Color.Lime Or
            ListView2.SelectedItems(0).BackColor = cRsRowColor.MainRs Then

            For Each itm As ToolStripItem In cms_lvlMainRsQty.Items
                itm.Enabled = True
            Next


        End If

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub FMainRS_New_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim mainrsqty As New class_main_rs_qty
            Dim selectedRow = FRequesitionFormForDR.DataGridView1.SelectedRows(0)
            Dim cn = FRequesitionFormForDR.getNewDrModel().cn

            If Button1.Text = "SAVE" Then
                If MessageBox.Show("Are you sure you want save this data?", "SUPPLLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then


                    Dim rsNo As String = selectedRow.Cells(NameOf(cn.rs_no)).Value
                    Dim cc As New ColumnValuesObj

                    cc.add("rs_no", rsNo)
                    cc.add("main_rs_qty", IIf(cmbOpenCloseQty.Text = "OPEN QTY", 0, txtMainRSQty.Text))
                    cc.add("open_close", IIf(cmbOpenCloseQty.Text = "OPEN QTY", 1, 0))
                    Dim id As Integer = cc.insertQuery_and_return_id("dbMain_Qty3")

                    If id > 0 Then
                        'reloadMainRsAndMainSubRs(rsNo)
                        customMsg.message("warning", "lets reload the RS to be effective!", "SMS INFO:")
                        FRequesitionFormForDR.btnSearch.PerformClick()
                        Me.Dispose()
                    End If
                Else
                    Exit Sub
                End If
            Else
                If MessageBox.Show("Are you sure you want update this data?", "SUPPLLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim rsNo As String = selectedRow.Cells(NameOf(cn.rs_no)).Value

                    mainrsqty.update(main_rs_qty_id,
                                     IIf(txtMainRSQty.Text = "-", 0, txtMainRSQty.Text),
                                     cmbOpenCloseQty.Text)

                    Button1.Text = "SAVE"

                    customMsg.message("error", "lets reload the RS to be effective!", "SMS INFO:")
                    FRequesitionFormForDR.btnSearch.PerformClick()
                    Me.Dispose()
                Else
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub btnIncludeNew_Click(sender As Object, e As EventArgs) Handles btnIncludeNew.Click
        Try
            If MessageBox.Show("Are you sure you want to include the selected item from list?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim selectedRow = FRequesitionFormForDR.DataGridView1.SelectedRows(0)
                Dim cn = FRequesitionFormForDR.getNewDrModel().cn

                Dim main_rs_qty_id As Integer
                Dim rs_no As String = selectedRow.Cells(NameOf(cn.rs_no)).Value
                Dim open_close As String = ""
                Dim count As Integer
                Dim level = FRequesitionFormForDR.getNewDrModel().getLevel()

                'get main_rs_qty_id
                For Each row As ListViewItem In ListView2.Items
                    If row.Checked = True And row.SubItems(6)?.Text = level.main_rs Then
                        main_rs_qty_id = row.Text
                        open_close = row.SubItems(5).Text
                        count += 1

                    ElseIf row.Checked = True And row.SubItems(6).Text = level.sub_rs Then
                        MessageBox.Show("Please select the main rs qty row!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit For
                        Exit Sub
                    End If
                Next

                If count = 0 Then
                    MessageBox.Show("Please select atleast 1 in Listview at the top!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                'select and insert data from listview1
                For Each row2 As ListViewItem In ListView1.Items
                    If row2.Checked = True Then

                        'check sa kung pwede ba sa open qty ang rs
                        If check_if_pwede_pang_open_rs(row2.SubItems(6).Text, open_close) = False Then
                            MessageBox.Show("The items (Aggregates) must have item check first or `" & row2.SubItems(6).Text & "` is not applicable to open qty!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            GoTo proceedhere
                        End If

                        Dim SQ As New SQLcon
                        'insert 
                        Dim abc As New class_query
                        abc.add_parameter("@n", 9)
                        abc.add_parameter("@main_rs_qty_id", main_rs_qty_id)
                        abc.add_parameter("@rs_id", row2.Text)

                        abc.insert_update("proc_main_rs_qty", SQ.connection).ExecuteNonQuery()
                        SQ.connection.Close()
                    End If
proceedhere:
                Next

                reloadAgain()
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Sub cmbOpenCloseQty_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOpenCloseQty.SelectedIndexChanged
        If cmbOpenCloseQty.Text = "OPEN QTY" Then
            txtMainRSQty.Text = "-"
            txtMainRSQty.Enabled = False

        Else
            txtMainRSQty.Enabled = True
            txtMainRSQty.Text = 0
        End If
    End Sub
End Class