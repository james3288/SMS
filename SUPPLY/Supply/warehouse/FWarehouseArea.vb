Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports System.Web.UI.WebControls
Imports CrystalDecisions.[Shared]
Imports CrystalDecisions.Windows.Forms
Imports Microsoft.Reporting.WebForms
Imports Microsoft.Reporting.WinForms

Public Class FWarehouseArea
    Public sq As New SQLcon
    Public dr As SqlDataReader
    Public cmd As SqlCommand

    Private whAreaUI, inchargeUI, locationUI, searchUI, whOptionUI, searchInchargeUI As New class_placeholder4
    Private whAreaStockpileModel, EmployeeModel, WhInchargeNewModel As New ModelNew.Model
    Private cSearch As String = ""
    Private csearchIncharge As String = ""

    Dim cBgWorkerChecker As Timer
    Private cListOfListViewItem As New List(Of ListViewItem)
    Private cCustomMsg As New customMessageBox
    Public cStoredId As Integer
    Public isFromWareHouse_link_quarry_btn As Boolean
    Public isFromWareHouse_link_whs_btn As Boolean
    Public isFromWareHouse_edit_warehouseArea As Boolean
    Private customMsg As New customMessageBox
    Private cListOfEmployee As New List(Of PropsFields.employee_props_fields)
    Private cListOfIncharge As New List(Of PropsFields.inchargeNew_fields)
    Public isTriggered, isUpdateWhAreaProperName As Boolean
    Private panelInchargeIsOpen As Boolean

    Public charge_to_id As Integer
    Private rearrangeLvl As New ListTabIndex
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Try

            If txtWharea.Text = "" Then
                MessageBox.Show("Please fillup textfield..", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtWharea.Focus()

                Return

                'ElseIf txtWhIncharge.Text = "" Then
                '    MessageBox.Show("Please fillup textfield..", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    txtWhIncharge.Focus()

                '    Return
            ElseIf txtWarehouseLoc.Text = "" Then
                MessageBox.Show("Please fillup textfield..", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtWarehouseLoc.Focus()

                Return

            ElseIf cmbWarehouseOptions.Text = "" Then
                cCustomMsg.message("error", "Please select an option first...", "SUPPLY INFO:")
                Return
            Else

                If btnSave.Text = "Save" Then

                    If MessageBox.Show("Are you sure you want to save this data?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

#Region "FILTER"
                        If cmbWarehouseOptions.Text.ToUpper() = cWarehouseOption.WAREHOUSE.ToUpper() Then
                            If charge_to_id = 0 Then
                                cCustomMsg.message("error", "You must select a proper warehouse name first to proceed saving...", "SUPPLY INFO:")
                                Exit Sub
                            Else
                                Dim checkIfWarehouseExist = cListOfWhAreaStockpile.Where(Function(x)
                                                                                             Return x.wh_area_proper_name.ToUpper() = txtWharea.Text.ToUpper()
                                                                                         End Function).ToList()

                                If checkIfWarehouseExist.Count > 0 Then
                                    cCustomMsg.message("error", "This warehouse name already exist...", "SUPPLY INFO:")
                                    Exit Sub
                                End If
                            End If
                        Else
                            charge_to_id = 0
                        End If
#End Region

                        Dim cc As New ColumnValuesObj
                        cc.add("wh_area", txtWharea.Text)
                        cc.add("wh_location", txtWarehouseLoc.Text)
                        cc.add("wh_options", cmbWarehouseOptions.Text)
                        cc.add("charge_to_id", charge_to_id)

                        Dim id As Integer = cc.insertQuery_and_return_id("dbwh_area")

                        If id > 0 Then
                            cCustomMsg.message("info", "Successfully Saved...", "SUPPLY INFO:")
                        Else
                            cCustomMsg.message("error", "There is something wrong when saving datas..", "SUPPLY INFO:")
                            Exit Sub
                        End If

                        clearTextBox()
                        txtWharea.Focus()

                        cStoredId = id

                        cSearch = ""
                        load_whArea_stockpile()

                    Else
                        Return
                    End If

                ElseIf btnSave.Text = "Update" Then

                    'publicquery = "UPDATE dbwh_area Set wh_area = '" & txtWharea.Text & "', wh_incharge = '" & txtWhIncharge.Text &
                    '    "', wh_location ='" & txtWarehouseLoc.Text & "', wh_options = '" & cmbWarehouseOptions.Text & "' "
                    'publicquery &= "WHERE wh_area_id = " & lvlWhareaList.SelectedItems(0).Text

                    'UPDATE_INSERT_DELETE_QUERY(publicquery, 1, "UPDATE")

                    Dim c As New ColumnValuesObj
                    c.add("wh_area", txtWharea.Text)
                    'c.add("wh_incharge", txtWhIncharge.Text)
                    c.add("wh_location", txtWarehouseLoc.Text)
                    c.add("wh_options", cmbWarehouseOptions.Text)

                    c.setCondition($"wh_area_id = {lvlWhareaList.SelectedItems(0).Text}")
                    c.updateQuery("dbwh_area", True)


                    Dim n As Integer = lvlWhareaList.SelectedItems(0).Text

                    MessageBox.Show("SUCCESSFULLY UPDATED..", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'load_wh_area()

                    'listfocus(lvlWhareaList, n)
                    'lvlWhareaList.Enabled = True
                    clearTextBox()
                    btnEdit.PerformClick()

                    cStoredId = n
                    cSearch = ""
                    load_whArea_stockpile()

                End If
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub clearTextBox()
        whAreaUI.resetTextFields()
        inchargeUI.resetTextFields()
        locationUI.resetTextFields()
        whOptionUI.resetComboBoxFields()
    End Sub

    Public Function if_wh_exist(ByVal wharea As String, ByVal whincharge As String) As Integer
        Try
            sq.connection.Open()
            publicquery = "SELECT * FROM dbwh_area WHERE wh_area = '" & wharea & "' AND wh_incharge = '" & whincharge & "'"
            cmd = New SqlCommand(publicquery, sq.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                if_wh_exist += 1
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sq.connection.Close()

        End Try
    End Function

    Private Sub FWarehouseArea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        registerRow()

#Region "REARRANGE TABINDEX"
        rearrangeLvl.rearrangeTabIndex()
#End Region

        'load_wh_area()
        lvlWhareaList.BackColor = ColorTranslator.FromHtml("#20242C")

        'UI
        whAreaUI.king_placeholder_textbox("Warehouse Area/Stockpile/Quarry...", txtWharea, Nothing, Panel3, My.Resources.received)
        'inchargeUI.king_placeholder_textbox("Warehouse Area Incharge...", txtWhIncharge, Nothing, Panel3, My.Resources.received)
        locationUI.king_placeholder_textbox("Locaiton...", txtWarehouseLoc, Nothing, Panel3, My.Resources.received)
        searchUI.king_placeholder_textbox("Search Here...", txtSearch, Nothing, Panel2, My.Resources.received)
        whOptionUI.king_placeholder_combobox("Select Option", cmbWarehouseOptions, Nothing, Panel3, My.Resources.received)
        searchInchargeUI.king_placeholder_textbox("Search Incharge...", txtSearchIncharge, Nothing, Panel6, My.Resources.received)

        'whOptionUI.cBox.Items.Add(cWarehouseOption.QUARRY)
        whOptionUI.cBox.Items.Add(cWarehouseOption.STOCKPILE)
        whOptionUI.cBox.Items.Add(cWarehouseOption.WAREHOUSE)
        'whOptionUI.cBox.Items.Add(cWarehouseOption.ON_SITE_STORAGE)

        'load warehouse area/ stockpile
        load_whArea_stockpile()
    End Sub

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
            .addColumns(col_wh_area_id)
            .addColumns(col_wh_stockpile_area)
            .addColumns(col_whArea_properName)
            .addColumns(col_wh_location)
            .addColumns(col_incharge)
            .addColumns(col_options)

        End With

    End Sub

    Public Sub load_whArea_stockpile()

        whAreaStockpileModel.clearParameter()
        EmployeeModel.clearParameter()
        WhInchargeNewModel.clearParameter()

        loadingPanel.Visible = True

        Dim cv As New ColumnValues
        cv.add("crud", 7)
        cv.add("search", cSearch)

        Dim cv2 As New ColumnValues

        Dim cv3 As New ColumnValues
        cv3.add("crud", "8")

        _initializing(cCol.forWareHouseStockpileArea,
                      cv.getValues(),
                      whAreaStockpileModel,
                      whAreaStockpileBgWorker)

        _initializing(cCol.forEmployeeData,
                      cv2.getValues(),
                      EmployeeModel,
                      whAreaStockpileBgWorker)

        _initializing(cCol.forWhInchargeNew,
                      cv3.getValues(),
                      WhInchargeNewModel,
                      whAreaStockpileBgWorker)

        cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, whAreaStockpileBgWorker)

    End Sub

    Private Sub SuccessfullyDone()
        cListOfWhAreaStockpile = TryCast(whAreaStockpileModel.cData, List(Of PropsFields.whArea_stockpile_props_fields))
        cListOfEmployee = TryCast(EmployeeModel.cData, List(Of PropsFields.employee_props_fields))
        cListOfIncharge = TryCast(WhInchargeNewModel.cData, List(Of PropsFields.inchargeNew_fields))

        Dim newResult = cListOfWhAreaStockpile.Where(Function(x)
                                                         Dim output As String = x.wh_area.ToUpper() & " " & x.wh_incharge.ToUpper() & " " & x.wh_location.ToUpper()
                                                         Return output.Contains(cSearch.ToUpper())
                                                     End Function).OrderBy(Function(x) x.wh_area).ToList()

        Dim employeeResult = cListOfEmployee.Select(Function(x)
                                                        Return x.employee
                                                    End Function).ToList()

        inchargeUI.AutoCompleteData = employeeResult
        inchargeUI.set_autocomplete()

        'MsgBox(cListOfWhAreaStockpile.Count)
        resultPreview(newResult)
        loadingPanel.Visible = False
    End Sub

    Private Sub resultPreview(data As List(Of PropsFields.whArea_stockpile_props_fields))
        Dim a(5) As String
        cListOfListViewItem.Clear()
        lvlWhareaList.Items.Clear()

        For Each row In data
            a(0) = row.wh_area_id
            a(1) = row.wh_area
            a(2) = Utilities.getWhIncharge(row.wh_area_id, cListOfIncharge) 'row.wh_incharge
            a(3) = row.wh_location
            a(4) = row.wh_options
            a(5) = row.wh_area_proper_name

            Dim lvl As New ListViewItem(a)
            cListOfListViewItem.Add(lvl)
        Next

        lvlWhareaList.Items.AddRange(cListOfListViewItem.ToArray)

        If cStoredId > 0 Then
            listfocus(lvlWhareaList, cStoredId)
            cStoredId = 0
        End If


    End Sub

    'Private Function getWhIncharge(paramWhAreaId As Integer) As String


    '    Dim result = cListOfIncharge.Where(Function(x) x.wh_area_id = paramWhAreaId)
    '    'Dim result = Utilities.ifInchargeAlreadyChecked(paramInchargeId, paramWhAreaId, cListOfIncharge)
    '    Dim columnNames As New List(Of String)

    '    For Each row In result
    '        columnNames.Add(row.whIncharge)
    '    Next

    '    ' Convert the list of column names to an array of strings and join them with commas
    '    Return String.Join(", ", columnNames.ToArray())
    'End Function

    Public Sub load_wh_area()
        lvlWhareaList.Items.Clear()

        publicquery = "SELECT * FROM dbwh_area ORDER BY wh_area ASC"
        SELECT_QUERY(publicquery, 3, lvlWhareaList, "5-5", -1)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Try
            If btnEdit.Text = "Cancel" Then
                lvlWhareaList.Enabled = True
                'txtWharea.Clear()
                'txtWhIncharge.Clear()
                'txtWarehouseLoc.Clear()
                clearTextBox()
                txtWarehouseLoc.Enabled = True

                txtWharea.Focus()
                btnEdit.Text = "Edit"
                btnSave.Text = "Save"
                ' btnRemove.Enabled = True

            ElseIf btnEdit.Text = "Edit" Then
                lvlWhareaList.Enabled = False

                txtWharea.Text = lvlWhareaList.SelectedItems(0).SubItems(1).Text
                'txtWhIncharge.Text = lvlWhareaList.SelectedItems(0).SubItems(2).Text
                txtWarehouseLoc.Text = lvlWhareaList.SelectedItems(0).SubItems(3).Text


                setSelectedIndex(cmbWarehouseOptions, lvlWhareaList.SelectedItems(0).SubItems(4).Text)

                txtWharea.Focus()
                btnEdit.Text = "Cancel"
                btnSave.Text = "Update"
                'btnRemove.Enabled = False


                txtWarehouseLoc.Enabled = True
            End If
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try



    End Sub

    Private Sub debounce_new_Tick(sender As Object, e As EventArgs) Handles debounce_new.Tick
        debounce_new.Stop()
        Dim searchResult As New List(Of PropsFields.whArea_stockpile_props_fields)
        searchResult = cListOfWhAreaStockpile.Where(Function(x)
                                                        Dim output As String = x.wh_area.ToUpper() &
                                                                                " " & x.wh_incharge.ToUpper() &
                                                                                " " & x.wh_location.ToUpper() &
                                                                                " " & x.wh_area_proper_name

                                                        Return output.Contains(cSearch.ToUpper)
                                                    End Function).OrderBy(Function(x) x.wh_area).ToList()



        If searchResult.Count > 0 Then
            'setCustomGridview()
            resultPreview(searchResult)
        End If

        loadingPanel.Visible = False
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        If cCustomMsg.messageYesNo("Are you sure you want to remove the data?", "SUPPLY INFO:") Then
            Dim c As New ColumnValuesObj

            c.setCondition($"wh_area_id = {Val(lvlWhareaList.SelectedItems(0).Text)}")
            c.deleteData("dbwh_area")

            cCustomMsg.message("info", "Successfully removed!", "SUPPLY INFO:")
            'lvlWhareaList.SelectedItems(0).Remove()

            cSearch = ""
            load_whArea_stockpile()
        End If

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        For Each ctr As Control In Panel5.Controls
            If ctr.Name = NameOf(Panel6) Then
                ctr.Visible = False
            Else
                ctr.Enabled = True
            End If
        Next

        For Each ctr As Control In Panel3.Controls
            ctr.Enabled = True
        Next

        For Each ctr As Control In Panel2.Controls
            ctr.Enabled = True
        Next

        panelInchargeIsOpen = False
    End Sub

    Private Sub AddInchargeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddInchargeToolStripMenuItem.Click
        panelInchargeIsOpen = True

        Dim wh_area_id As Integer = lvlWhareaList.SelectedItems(0).Text
        'open panel
        openPanelIncharge()

        displayListOfIncharge(wh_area_id)
    End Sub

    Private Sub displayListOfIncharge(Optional param_wh_area_id As Integer = 0, Optional paramSearch As String = "")
        'list of wh incharge
        ListView1.Items.Clear()
        Dim search As String = IIf(searchInchargeUI.ifBlankTexbox(), "", paramSearch)

        Dim whIncharge = cListOfEmployee.Where(Function(x)
                                                   'x.designation.ToUpper() = "WAREHOUSING IN-CHARGE" And
                                                   Dim fullname As String = x.last_name & "," & x.first_name & " " & x.middle_name
                                                   Return Not x.status_name.ToUpper() = cEmployeeStatus.SEPARATED And
                                                   fullname.ToUpper().Contains(search.ToUpper())
                                                   'And
                                                   'Not x.status_name.ToUpper() = cEmployeeStatus.RETIRED
                                               End Function).ToList()

        Dim listOfLvl As New List(Of ListViewItem)
        For Each emp As PropsFields.employee_props_fields In whIncharge
            Dim a(2) As String

            a(0) = emp.employee_id
            a(1) = emp.last_name & ", " & emp.first_name & " " & emp.middle_name

            Dim lvl As New ListViewItem(a)
            listOfLvl.Add(lvl)
        Next

        ListView1.Items.AddRange(listOfLvl.ToArray)

        'check incharge if exist
        For Each row As ListViewItem In ListView1.Items
            Dim aa = Utilities.ifInchargeAlreadyChecked(row.Text, param_wh_area_id, cListOfIncharge)

            If aa.Count > 0 Then
                row.Checked = True
            Else
                row.Checked = False
            End If
        Next
    End Sub

    Private Sub openPanelIncharge()
        For Each ctr As Control In Panel5.Controls
            If ctr.Name = NameOf(Panel6) Then
                ctr.Visible = True
            Else
                ctr.Enabled = False
            End If
        Next

        For Each ctr As Control In Panel3.Controls
            ctr.Enabled = False
        Next

        For Each ctr As Control In Panel2.Controls
            ctr.Enabled = False
        Next
    End Sub
    Private Sub btnSaveCharges_Click(sender As Object, e As EventArgs) Handles btnSaveCharges.Click
        Dim wh_area_id As Integer = lvlWhareaList.SelectedItems(0).Text

        For Each row As ListViewItem In ListView1.Items
            'check first if already saved in database
            Dim aa = Utilities.ifInchargeAlreadyChecked(row.Text, wh_area_id, cListOfIncharge)

            If row.Checked Then

                If aa.Count = 0 Then 'if walay makita
                    insertIncharge(wh_area_id, row.Text)
                End If

            Else
                If aa.Count > 0 Then 'if naay makita
                    removeIncharge(row.Text, wh_area_id)
                End If
            End If
        Next

        customMsg.message("info", "Incharge Successfully Updated", "SUPPLY INFO:")
        cStoredId = wh_area_id

        load_whArea_stockpile()

        Button2.PerformClick()

    End Sub

    Private Sub insertIncharge(param_wh_area_id As Integer, param_incharge_id As Integer)
        Dim cc As New ColumnValuesObj

        cc.add("wh_area_id", param_wh_area_id)
        cc.add("incharge_id", param_incharge_id)

        cc.insertQuery("db_wh_area_incharge")
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub searchIncharge_debounce_Tick(sender As Object, e As EventArgs) Handles searchIncharge_debounce.Tick
        searchIncharge_debounce.Stop()


        'Dim searchResult As New List(Of PropsFields.whArea_stockpile_props_fields)
        'searchResult = cListOfWhAreaStockpile.Where(Function(x)
        '                                                Dim output As String = x.wh_area.ToUpper() & " " & x.wh_incharge.ToUpper() & " " & x.wh_location.ToUpper()
        '                                                Return output.Contains(cSearch.ToUpper)
        '                                            End Function).OrderBy(Function(x) x.wh_area).ToList()

        If csearchIncharge = "" Then

        Else
            displayListOfIncharge(lvlWhareaList.SelectedItems(0).Text, csearchIncharge)
        End If



        'If searchResult.Count > 0 Then
        '    'setCustomGridview()
        '    resultPreview(searchResult)
        'End If

        pleaseWaitLabel.Visible = False
    End Sub

    Private Sub txtSearchIncharge_TextChanged(sender As Object, e As EventArgs) Handles txtSearchIncharge.TextChanged
        'displayListOfIncharge(IIf(lvlWhareaList.Items.Count > 0,
        '                          lvlWhareaList.SelectedItems(0).Text, 0),
        '                      txtSearchIncharge.Text)

        'If searchInchargeUI.ifBlankTexbox() Then

        'Else
        '    displayListOfIncharge(lvlWhareaList.SelectedItems(0).Text, txtSearchIncharge.Text)
        'End If

        csearchIncharge = IIf(searchInchargeUI.placeHolder = txtSearchIncharge.Text, "", searchInchargeUI.tbox.Text)
    End Sub

    Private Sub lvlWhareaList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvlWhareaList.SelectedIndexChanged

    End Sub

    Private Sub cmbWarehouseOptions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbWarehouseOptions.SelectedIndexChanged

        If cmbWarehouseOptions.Text.ToUpper() = cWarehouseOption.WAREHOUSE.ToUpper() Then
            txtWharea.Enabled = False
            txtWarehouseLoc.Focus()

            FCharge_To.forSaveWarehouseProperName = True
            FCharge_To.ShowDialog()
        Else
            txtWharea.Enabled = True
            txtWharea.Focus()
        End If

    End Sub

    Private Sub LinkToProperWarehouseNameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LinkToProperWarehouseNameToolStripMenuItem.Click
        If cCustomMsg.messageYesNo("Note: this function is intended for warehouse that will link to proper naming" &
                                   vbCrLf & "do you want to procceed?", "SUPPY INFO:", MessageBoxIcon.Warning) Then

            FCharge_To.forWarehouseProperName = True
            FCharge_To.ShowDialog()
        End If

    End Sub

    Private Sub removeIncharge(paramInchargeId As Integer, paramWhAreaId As Integer)
        Dim cc As New ColumnValuesObj

        cc.setCondition($"incharge_id = {paramInchargeId} and wh_area_id = {paramWhAreaId}")
        cc.deleteData("db_wh_area_incharge")
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click

        btnEdit.PerformClick()
    End Sub

    Private Sub lvlWhareaList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvlWhareaList.DoubleClick

        If Not target_location_project = Nothing Then
            If target_location_project.ToUpper() = FDeliveryReceipt.Name.ToUpper() Then
                With FDeliveryReceipt
                    If charge_to_destination = 11 Then

                        FDeliveryReceipt.cmbTypeofCharge.Text = "WAREHOUSE"
                        FDeliveryReceipt.txtChargeTo.Text = lvlWhareaList.SelectedItems(0).SubItems(1).Text

                    Else
                        For Each row As DataGridViewRow In .dgv_dr_list.Rows
                            If row.Cells(1).Selected = True Then

                                row.Cells("col_source").Value = lvlWhareaList.SelectedItems(0).SubItems(1).Text
                                row.Cells("col_category").Value = "WAREHOUSE"

                            End If
                        Next
                    End If
                End With

                target_location_project = Nothing
                Me.Dispose()
                FCharge_To.Close()

            ElseIf target_location_project.ToUpper() = FPreviousStackCardFinal.Name.ToUpper() Then

                If charge_to_destination = 2 Then

                    charge_to_id = Val(lvlWhareaList.SelectedItems(0).Text)
                    FPreviousStackCardFinal.txtChargeTo.Text = lvlWhareaList.SelectedItems(0).SubItems(1).Text

                End If

                target_location_project = Nothing
                Me.Dispose()
                FCharge_To.Close()

                'ElseIf target_location_project = "FPreviousStackCardFinal" Then

            ElseIf target_location_project.ToUpper() = FDRLIST1.Name.ToUpper() Then

                If charge_to_destination = 13 Then
                    If MessageBox.Show("Are you sure you want to edit source to this selected row?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        With FDRLIST1
                            For Each row As ListViewItem In .lvl_drList.Items
                                If row.Selected = True Then
                                    FCharge_To.update_source_drlist1("WAREHOUSE", lvlWhareaList.SelectedItems(0).Text, row.Text)
                                    row.SubItems(5).Text = lvlWhareaList.SelectedItems(0).SubItems(1).Text
                                End If
                            Next
                        End With

                        target_location_project = Nothing
                        charge_to_destination = 0
                        Me.Close()
                    End If
                End If

            ElseIf target_location_project.ToUpper() = FDRLIST2.Name.ToUpper() Then

                If charge_to_destination = 13 Then
                    If MessageBox.Show("Are you sure you want to edit source to this selected row?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        With FDRLIST1
                            For Each row As ListViewItem In .lvl_drList.Items
                                If row.Selected = True Then
                                    FCharge_To.update_source_drlist1("WAREHOUSE", lvlWhareaList.SelectedItems(0).Text, row.Text)
                                    row.SubItems(5).Text = lvlWhareaList.SelectedItems(0).SubItems(1).Text
                                End If
                            Next
                        End With

                        target_location_project = Nothing
                        charge_to_destination = 0
                        Me.Close()
                    End If
                End If

            ElseIf target_location_project.ToUpper() = FWarehouseItems.Name.ToUpper() And isFromWareHouse_link_quarry_btn Then

                If cCustomMsg.messageYesNo("Are you sure you want to update quarry?", "SUPPLY INFO:") Then
                    Dim quarry_id As Integer = lvlWhareaList.SelectedItems(0).Text
                    Dim wh_id As Integer
                    For Each row In FWarehouseItems.lvlItemList.SelectedItems

                        'update quarry_id
                        Dim cc As New ColumnValuesObj
                        cc.add("quarry_id", quarry_id)
                        cc.setCondition($"wh_id = {row.text}")
                        cc.updateQuery("dbwarehouse_items")

                        wh_id = row.text
                    Next

                    FWarehouseItems.linkTriggered = True
                    FWarehouseItems.cWh_id = wh_id

                    FWarehouseItems.loadWhItems()

                    Me.Dispose()
                End If

            ElseIf target_location_project.ToUpper() = FWarehouseItems.Name.ToUpper() And isFromWareHouse_link_whs_btn Then

                FWarehouseItems.txtWarehouseArea.Text = lvlWhareaList.SelectedItems(0).SubItems(1).Text
                Me.Dispose()
            End If

            If target_location_project = "" Then

            Else
                With FWarehouseItems
                    .txtWarehouseArea.Text = lvlWhareaList.SelectedItems(0).SubItems(1).Text
                    .whAreaId = lvlWhareaList.SelectedItems(0).Text
                    .whAreaCategory = "WAREHOUSE"
                End With

                Me.Close()
            End If

        End If

        'for edit warehousearea
        If isFromWareHouse_edit_warehouseArea Then
            If customMsg.messageYesNo("Are you sure you want to update warehouse area of the selected items?", "SUPPLY INFO:") Then
                Dim whAreaId As Integer = lvlWhareaList.SelectedItems(0).Text

                For Each row As ListViewItem In FWarehouseItems.lvlItemList.Items
                    If row.Selected Then
                        Dim cc As New ColumnValuesObj

                        cc.setCondition($"wh_id = {row.Text}")
                        cc.add("whArea", whAreaId)

                        cc.updateQuery("dbwarehouse_items")
                    End If
                Next

                customMsg.message("info", "warehouse area successfully updated", "SUPPLY INFO:")

                With FWarehouseItems
                    .linkTriggered = True
                    .loadWhItems()
                End With


            End If
        End If

    End Sub


    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

        cSearch = IIf(searchUI.placeHolder = txtSearch.Text, "", searchUI.tbox.Text)

        'Dim newSQ As New SQLcon
        'Dim newCMD As SqlCommand
        'Dim newDR As SqlDataReader

        'lvlWhareaList.Items.Clear()

        'Try
        '    newSQ.connection.Open()
        '    newCMD = New SqlCommand("proc_wh_items_crud", newSQ.connection)
        '    newCMD.Parameters.Clear()
        '    newCMD.CommandType = CommandType.StoredProcedure
        '    newCMD.CommandTimeout = 0

        '    newCMD.Parameters.AddWithValue("@crud", "7")
        '    newCMD.Parameters.AddWithValue("@search", txtSearch.Text)

        '    newDR = newCMD.ExecuteReader

        '    Dim a(10) As String

        '    While newDR.Read
        '        a(0) = newDR.Item("wh_area_id").ToString
        '        a(1) = newDR.Item("wh_area").ToString
        '        a(2) = newDR.Item("wh_incharge").ToString
        '        a(3) = newDR.Item("wh_location").ToString

        '        Dim lvl As New ListViewItem(a)
        '        lvlWhareaList.Items.Add(lvl)

        '    End While
        '    newDR.Close()

        'Catch ex As Exception
        '    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Finally
        '    newSQ.connection.Close()
        'End Try
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

    Private Sub FWarehouseArea_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Dispose()
    End Sub

    Private Sub txtSearchIncharge_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearchIncharge.KeyDown
        If e.KeyCode = 17 Then
            Exit Sub
        End If

        If txtSearchIncharge.TextLength > 0 Then
            pleaseWaitLabel.Visible = True
            searchIncharge_debounce.Start()
        Else
            pleaseWaitLabel.Visible = True
            csearchIncharge = ""
            searchIncharge_debounce.Start()

        End If
    End Sub
End Class