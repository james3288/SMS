Imports System.Data.Sql
Imports System.Data.SqlClient
Imports SUPPLY.Interfaces
Public Class FKeyPerformanceIndicator
    Private indicatorUI, searchUI, leadTimeDaysCategoryUI, leadTimeDaysUI As New class_placeholder5
    Private kpiModel As New ModelNew.Model

    Private customMsg As New customMessageBox
    Private customGridview As New CustomGridview
    Public isViewing, isFromWareHouse, isFromWareHouseNew, isFromWarehouseItemNew As Boolean
    Private cKPI As New KeyPerformanceIndicatorModel
    Dim cBgWorkerChecker As Timer
    Private cn As New PropsFields.KPIprops_fields
    Private cEditKpi As New PropsFields.KPIprops_fields
    Private cSaveCaption As New enumSaveCaption
    Private cLeadTimeCategoryNew As String
    Dim l As New List(Of String)
    Dim SQ As New SQLcon
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim public_query As String

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Const CS_DROPSHADOW As Integer = &H20000
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_DROPSHADOW
            Return cp
        End Get
    End Property


    Public Class enumSaveCaption
        Public ReadOnly Property Save As String = "Save (Ctrl + S)"
        Public ReadOnly Property Update As String = "Update (Ctrl + S)"

    End Class
    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        With DataGridView1.SelectedRows(0)

            indicatorUI.resetBgColor()
            leadTimeDaysUI.resetBgColor()
            searchUI.resetBgColor()
            leadTimeDaysCategoryUI.resetBgColor()
            btnSave.Text = cSaveCaption.Save

            searchBoxLocation(DataGridView1, 0, panelPopUp)
            indicatorUI.tbox.Focus()
        End With

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnPanelPopUpExit.Click
        panelBoxClose()
    End Sub
    Private Sub panelBoxClose()
        panelPopUp.Visible = False

        leadTimeDaysUI.clear_textBox()
        leadTimeDaysUI.resetBgColor()

        indicatorUI.clear_textBox()
        indicatorUI.resetBgColor()

        leadTimeDaysCategoryUI.clear_textBox()
        leadTimeDaysCategoryUI.resetBgColor()
    End Sub

    Private Sub FKeyPerformanceIndicator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            displayLeadCategory()
            'l.Add("RS TO WS")
            'l.Add("WS TO WR")

            btnSave.Text = cSaveCaption.Save


            'searchUI.king_placeholder_textbox("search here...", txtSearch, Nothing, Panel1, My.Resources.received,)
            customGridview.customDatagridview(DataGridView1,, 28)

            indicatorUI.king_placeholder_textbox("Indicator...",
                                                 txtIndicator,
                                                 Nothing,
                                                 panelPopUp,
                                                 My.Resources.received,
                                                 False,
                                                 indicatorUI.cCustomColor.Custom1)

            leadTimeDaysUI.king_placeholder_textbox("lead time days...",
                                                    txtLeadTimeDays,
                                                    Nothing,
                                                    panelPopUp,
                                                    My.Resources.received,
                                                    True,
                                                    leadTimeDaysUI.cCustomColor.Custom1)

            leadTimeDaysCategoryUI.king_placeholder_textbox("lead time category...",
                                                    txtLeadTimeCategory,
                                                    l,
                                                    panelPopUp,
                                                    My.Resources.received,
                                                    False,
                                                    leadTimeDaysCategoryUI.cCustomColor.Custom1)

            customGridview.customDatagridview(DataGridView1, "#011526")
            customGridview.customDatagridview(DataGridView2, "#011526")
            loadAllDataHere()
            displayAllSelectedKpi()

            'movable panel
            Dim myPanel As New MovablePanel

            myPanel.addPanel(Panel1)

            myPanel.initializeForm(Me)
            myPanel.addPanelEventHandler()

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.Text = cSaveCaption.Save Then
            If Not haveAnError() And cEditKpi IsNot Nothing Then
                btnSave.Focus()
                kpiSaved()
            End If
        Else
            If Not haveAnError() And cEditKpi IsNot Nothing Then
                btnSave.Focus()
                kpiUpdate()

            End If

        End If

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub loadAllDataHere()
        Try
            Dim c As New ColumnValues
            _initializing(cCol.forKPIView,
                          c.getValues(),
                          kpiModel,
                          KPIDataBgWorker)

            cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, KPIDataBgWorker)
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        If customMsg.messageYesNo("Are you sure you want to remove this data?", "SUPPLY INFO:") Then
            Dim id As Integer = DataGridView1.SelectedRows(0).Cells(NameOf(cn.kpi_id)).Value
            cKPI.delete(id)

            loadAllDataHere()
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If DataGridView1.SelectedRows.Count > 0 Then
            For Each item As ToolStripMenuItem In ContextMenuStrip1.Items
                item.Enabled = True
            Next
        Else
            For Each item As ToolStripMenuItem In ContextMenuStrip1.Items
                item.Enabled = False
            Next
        End If
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Dim id As Integer = DataGridView1.SelectedRows(0).Cells(NameOf(cn.kpi_id)).Value

        panelPopUp.Visible = True
        Dim data = Results.rListOfKPiData.Where(Function(x) x.kpi_id = id).ToList()

        If data.Count > 0 Then
            indicatorUI.tbox.Text = data(0).indicator
            indicatorUI.resetBgColor()

            leadTimeDaysUI.tbox.Text = data(0).lead_time_days
            leadTimeDaysUI.resetBgColor()

            leadTimeDaysCategoryUI.tbox.Text = data(0).lead_time_category
            leadTimeDaysCategoryUI.resetBgColor()

            cEditKpi = data(0)
        End If

        btnSave.Text = cSaveCaption.Update
        indicatorUI.tbox.Focus()

    End Sub

    Private Sub SuccessfullyDone()
        Results.rListOfKPiData = TryCast(kpiModel.cData, List(Of PropsFields.KPIprops_fields))

        If Results.rListOfKPiData.Count > 0 Then
            DataGridView1.DataSource = Results.rListOfKPiData
            setCustomGridview()
        End If
    End Sub
    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        Dim kpi_cn As New PropsFields.whItemsFinal

        If isViewing Then
            Exit Sub
        End If

        Dim wh_id As Integer = FWarehouseItemsNew.DataGridView1.SelectedRows(0).Cells("wh_id").Value
        Dim kpi_id As Integer = DataGridView1.SelectedRows(0).Cells(NameOf(cn.kpi_id)).Value

        check_kpi_inserted_exist()

        'If isViewing Then
        '    Exit Sub
        'End If

        'If isFromWareHouse Then
        '    Dim selected As New PropsFields.KPIprops_fields

        '    If Results.rListOfKPiData.Count > 0 Then
        '        selected = Results.rListOfKPiData.Where(Function(x)
        '                                                    Return x.kpi_id = DataGridView1.SelectedRows(0).Cells(NameOf(cn.kpi_id)).Value
        '                                                End Function).ToList()(0)

        '        If selected IsNot Nothing Then
        '            FWarehouseItems.kpi_id = selected.kpi_id
        '            FWarehouseItems.txtKeyPerformanceIndicator.Text = selected.indicator
        '        End If
        '    End If
        '    FWarehouseItems.KPIForm.Close()

        'ElseIf isFromWareHouseNew Then
        '    Dim kpi_cn As New PropsFields.whItemsFinal
        '    Dim selectedRow = DataGridView1.SelectedRows(0)

        '    Dim wh_id As Integer = FWarehouseItemsNew.DataGridView1.SelectedRows(0).Cells("wh_id").Value

        '    Dim kpi_id As Integer = selectedRow.Cells(NameOf(cn.kpi_id)).Value
        '    Dim kpi As String = selectedRow.Cells(NameOf(cn.indicator)).Value


        '    If FWarehouseItemsNew.getWhItemsModel().updateKPIFromWareItem(kpi_id, wh_id) Then

        '        'FWarehouseItemsNew.getWhItemsModel().setRowId = wh_id
        '        'FWarehouseItemsNew.getWhItemsModel().isEdit = True
        '        'FWarehouseItemsNew.getWhItemsModel().getWarehouseItems("dbwarehouse_items")

        '        FWarehouseItemsNew.getWhItemsModel().reloadItemsWithoutRefresh(wh_id, NameOf(kpi_cn.kpi), kpi)

        '        Me.Dispose()
        '    Else
        '        customMsg.message("error", "something went wrong with ware area / stockpile area update...", "SUPPLY INFO:")
        '        Exit Sub
        '    End If

        'ElseIf isFromWarehouseItemNew Then
        '    Dim kpi_id As Integer = DataGridView1.SelectedRows(0).Cells(NameOf(cn.kpi_id)).Value
        '    Dim kpi As String = DataGridView1.SelectedRows(0).Cells(NameOf(cn.indicator)).Value

        '    FCreateWarehouseItemForm.whitemStorage.kpi_id = kpi_id
        '    FCreateWarehouseItemForm.txtKPI.Text = kpi
        '    FCreateWarehouseItemForm.txtKPI.Focus()
        '    Me.Dispose()
        'End If

    End Sub

    Private Sub kpiSaved()
        Try
            If customMsg.messageYesNo("Are you sure you want to save this data?", "SUPPLY INFO:") Then

                Dim wh_id As Integer = 0
                Dim createKpi As New PropsFields.KPIprops_fields
                With createKpi
                    .indicator = txtIndicator.Text
                    .lead_time_days = txtLeadTimeDays.Text
                    .lead_time_category = cLeadTimeCategoryNew  'txtLeadTimeCategory.Text
                End With

                Dim result As Integer = cKPI.saved(createKpi)

                If result > 0 Then
                    customMsg.message("info", "Successfully saved...", "SUPPLY INFO:")
                    loadAllDataHere()
                    FWarehouseItemsNew.displayKpiCategory()
                    Me.Dispose()
                    'panelBoxClose()
                Else
                    customMsg.message("error", "something went wrong with save!", "SUPPLY INFO:")
                End If
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try


    End Sub


    Private Sub kpiUpdate()
        Try
            cEditKpi.indicator = txtIndicator.Text
            cEditKpi.lead_time_days = txtLeadTimeDays.Text
            cEditKpi.lead_time_category = cLeadTimeCategoryNew

            Dim result As Boolean = cKPI.update(cEditKpi, cEditKpi.kpi_id)

            If result = True Then
                customMsg.message("info", "Successfully updated...", "SUPPLY INFO:")
                loadAllDataHere()
                FWarehouseItemsNew.displayKpiCategory()
                panelBoxClose()

            Else
                customMsg.message("error", "something went wrong with update!", "SUPPLY INFO:")
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub setCustomGridview()

        With customGridview

            'readonly cells
            For Each row As DataGridViewRow In DataGridView1.Rows
                row.ReadOnly = True
            Next

            .subcustomDatagridviewSettings2("headerTextOnly", DataGridView1, NameOf(cn.indicator),, "Indicator")
            .subcustomDatagridviewSettings2("headerTextOnly", DataGridView1, NameOf(cn.lead_time_days),, "Lead time days")
            .subcustomDatagridviewSettings2("headerTextOnly", DataGridView1, NameOf(cn.lead_time_category),, "Lead time category")
            .autoSizeColumn(DataGridView1, True)

            '.subcustomDatagridviewSettings("headerTextOnly", DataGridView1, 3,, dgvCol.UNIT_PRICE)
            '.subcustomDatagridviewSettings("headerTextOnly", DataGridView1, 4,, dgvCol.AMOUNT)

            'hide columns
            'For Each col As DataGridViewColumn In DataGridView1.Columns
            '    If col.Name = NameOf(wr.serial_id) Or
            '        col.Name = NameOf(wr.col_id) Then
            '        col.Visible = False
            '    Else
            '        col.Visible = True
            '    End If
            'Next
        End With

    End Sub

    Private Function haveAnError() As Boolean
#Region "FILTER"
        If indicatorUI.ifBlankTexbox() Or
            leadTimeDaysUI.ifBlankTexbox() Or
            leadTimeDaysCategoryUI.ifBlankTexbox() Then

            customMsg.message("error", "textfields must not be blank!", "SUPPLY INFO:")
            Return True
        End If

        'If l.Count > 0 Then
        '    If l.Where(Function(x) x.ToUpper() = txtLeadTimeCategory.Text.ToUpper()).ToList().Count = 0 Then
        '        customMsg.message("error", "Please select a proper category...", "SUPPLY INFO:")
        '        Return True
        '    End If
        'End If
#End Region
    End Function

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub RemoveSelectedIndicatorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveSelectedIndicatorToolStripMenuItem.Click
        Dim wh_item_kpi_id As Integer = 0
        Dim wh_indicator As String = ""
        For Each row As DataGridViewRow In DataGridView2.SelectedRows
            wh_item_kpi_id = Convert.ToInt32(row.Cells(5).Value)
            wh_indicator = row.Cells(1).Value
        Next
        Dim message As String = $"Are You Sure to Remove '{wh_indicator}'?"

        If MessageBox.Show(message, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            removeIndicatorOnItemNames(wh_item_kpi_id)
        Else

        End If
    End Sub

    Private Sub FKeyPerformanceIndicator_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.S Then

            txtLeadTimeCategory.SelectAll()
            btnSave.Focus()
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub txtLeadTimeCategory_LostFocus(sender As Object, e As EventArgs) Handles txtLeadTimeCategory.LostFocus
        cLeadTimeCategoryNew = txtLeadTimeCategory.Text
    End Sub


    '####maki CODE
    Public Sub check_kpi_inserted_exist()
        Dim selectedRow = DataGridView1.SelectedRows(0)
        Dim SQ As New SQLcon
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim public_query As String
        Dim wh_id As Integer = FWarehouseItemsNew.DataGridView1.SelectedRows(0).Cells("wh_id").Value
        Dim kpi_selected_category As String = selectedRow.Cells(NameOf(cn.lead_time_category)).Value
        Dim kpi_selected_id As String = selectedRow.Cells(NameOf(cn.kpi_id)).Value
        Dim whkpi As Integer = 0


        Try



            If cKPI.kpi_category = "Type Request Category" Then
                SQ.connection.Open()
                public_query = " select top 1 a.whItem_kpi_id as kpi_id
                              from dbWarehouseItems_dbKPI a
                              INNER JOIN dbwarehouse_items b on b.wh_id = a.wh_id
                              INNER JOIN dbKeyPerformanceIndicator c on c.kpi_id = a.kpi_id
                              where c.lead_time_category = '" & kpi_selected_category & "' 
                                    and a.wh_id = '" & wh_id & "' AND a.kpi_id =  '" & kpi_selected_id & "'"

                cmd = New SqlCommand(public_query, SQ.connection)
                dr = cmd.ExecuteReader

                If dr.HasRows Then

                    'MessageBox.Show("This item has already been selected in the " + cKPI.kpi_category, "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Dim message As String = $"This KPI has already selected!"
                    MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    SQ.connection.Close()
                Else
                    kpiSelectedData()
                    SQ.connection.Close()
                End If

            Else
                SQ.connection.Open()
                public_query = " select top 1 a.whItem_kpi_id as kpi_id
                              from dbWarehouseItems_dbKPI a
                              INNER JOIN dbwarehouse_items b on b.wh_id = a.wh_id
                              INNER JOIN dbKeyPerformanceIndicator c on c.kpi_id = a.kpi_id
                              where c.lead_time_category = '" & kpi_selected_category & "' and a.wh_id = '" & wh_id & "'"

                cmd = New SqlCommand(public_query, SQ.connection)
                dr = cmd.ExecuteReader

                If dr.HasRows Then

                    'MessageBox.Show("This item has already been selected in the " + cKPI.kpi_category, "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Dim message As String = $"'{kpi_selected_category}' has already selected, do you still want to continue and update the indicator?"

                    If MessageBox.Show(message, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        While dr.Read()
                            whkpi = dr.Item("kpi_id").ToString()
                        End While

                        updateChangeKpi(whkpi)

                        Dim mk As New WarehouseItemModel.KPI_storage
                        With mk
                            .wh_id = wh_id
                            .indicator = selectedRow.Cells(NameOf(cn.indicator)).Value
                            .lead_time_category = selectedRow.Cells(NameOf(cn.lead_time_category)).Value
                        End With

                        FWarehouseItemsNew.getWhItemsModel().getMultipleKPIFromMkStorageAndUpdate(mk)
                    Else
                        'MsgBox("You cancel")
                    End If
                    SQ.connection.Close()
                Else
                    kpiSelectedData()
                    SQ.connection.Close()
                End If

            End If


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try

    End Sub

    Public Sub updateChangeKpi(ByVal WhKpiID As Integer)
        Dim SQ As New SQLcon
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim public_query As String
        Dim wh_id As Integer = FWarehouseItemsNew.DataGridView1.SelectedRows(0).Cells("wh_id").Value
        Dim kpi_id As Integer = DataGridView1.SelectedRows(0).Cells(NameOf(cn.kpi_id)).Value
        Try
            SQ.connection.Open()
            public_query = "UPDATE dbWarehouseItems_dbKPI SET kpi_id = '" & kpi_id & "' where whItem_kpi_id = '" & WhKpiID & "'"
            cmd = New SqlCommand(public_query, SQ.connection)
            dr = cmd.ExecuteReader
            MessageBox.Show("Successfully Update!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            displayAllSelectedKpi()
            SQ.connection.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try

    End Sub

    Private Sub kpiSelectedData()
        Dim kpi_cn As New PropsFields.whItemsFinal
        Dim selectedRow = DataGridView1.SelectedRows(0)
        Dim selectedRow2 = FWarehouseItemsNew.DataGridView1.SelectedRows(0)
        Try
            If customMsg.messageYesNo("Are you sure you want to save this data?", "SUPPLY INFO:") Then


                Dim wh_id As Integer = selectedRow2.Cells("wh_id").Value
                Dim kpi_id As Integer = selectedRow.Cells(NameOf(cn.kpi_id)).Value
                Dim kpi_indicator As String = selectedRow.Cells(NameOf(cn.indicator)).Value

                Dim result As Integer = cKPI.saved2(wh_id, kpi_id, kpi_indicator)
                'Dim kpi As String = $"{FWarehouseItemsNew.getWhItemsModel().getMultipleKPIFromMkStorage(wh_id)}/{selectedRow.Cells(NameOf(cn.indicator)).Value}"

                If result > 0 Then
                    customMsg.message("info", "Successfully saved...", "SUPPLY INFO:")
                    displayAllSelectedKpi()
#Region "ADD TO listOfMultipleKPI"
                    Dim addMk As New PropsFields.MultipleKPIprops_fields
                    With addMk
                        .wh_id = wh_id
                        .kpi_id = kpi_id
                        .indicator = selectedRow.Cells(NameOf(cn.indicator)).Value
                        .lead_time_category = selectedRow.Cells(NameOf(cn.lead_time_category)).Value
                    End With
                    FWarehouseItemsNew.getWhItemsModel().addMultipleKPI(addMk)
#End Region

                    'retreive again
                    Dim kpi = FWarehouseItemsNew.getWhItemsModel().getMultipleKPIByWhId(wh_id)
                    FWarehouseItemsNew.getWhItemsModel().reloadItemsWithoutRefresh(wh_id, NameOf(kpi_cn.kpi), kpi)

                Else
                    customMsg.message("error", "something went wrong with save!", "SUPPLY INFO:")
                End If
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub displayLeadCategory()
        Dim SQ As New SQLcon
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim public_query As String
        Try
            SQ.connection.Open()
            public_query = "select distinct lead_time_category from dbKeyPerformanceIndicator order by lead_time_category asc"
            cmd = New SqlCommand(public_query, SQ.connection)
            dr = cmd.ExecuteReader

            If dr.HasRows Then
                While dr.Read()
                    l.Add(dr.Item("lead_time_category").ToString())
                End While
            Else
                SQ.connection.Close()
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub removeIndicatorOnItemNames(ByVal whkpiID As Integer)
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_kpi_crud"
            sqlcomm.CommandType = CommandType.StoredProcedure

            sqlcomm.Parameters.AddWithValue("@n", 2)
            sqlcomm.Parameters.AddWithValue("@whItem_kpi_id", whkpiID)
            dr = sqlcomm.ExecuteReader()
            MessageBox.Show("Successfully Removed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dr.Close()
            displayAllSelectedKpi()
        Catch ex As Exception
            Dim msg1 As New customMessageBox
            msg1.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Sub


    Private Sub displayAllSelectedKpi()
        DataGridView2.Rows.Clear()
        Dim wh_id As Integer = FWarehouseItemsNew.DataGridView1.SelectedRows(0).Cells("wh_id").Value

        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_kpi_crud"
            sqlcomm.CommandType = CommandType.StoredProcedure

            sqlcomm.Parameters.AddWithValue("@n", 1)
            sqlcomm.Parameters.AddWithValue("@whID", wh_id)

            dr = sqlcomm.ExecuteReader()

            While dr.Read
                DataGridView2.Rows.Add(dr.Item(1).ToString(),
                                dr.Item(2).ToString(),
                                dr.Item(3).ToString(),
                                dr.Item(4).ToString(),
                                dr.Item(0).ToString(),
                                dr.Item(5).ToString())
            End While
            dr.Close()

        Catch ex As Exception
            Dim msg1 As New customMessageBox
            msg1.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

End Class