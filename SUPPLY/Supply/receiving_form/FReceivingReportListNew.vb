Imports SUPPLY.KeyPerformanceIndicatorModel

Public Class FReceivingReportListNew
    Private NEWRRMODEL As New ReceivingModel
    Private searchUI As New class_placeholder5
    Private cn As New ReceivingModel.COLUMNS
    Private cLevel As New ReceivingModel.ROWLEVEL
    Private customDataGrid As New CustomGridview

    Public ReadOnly Property getNEWRRMODEL As ReceivingModel
        Get
            Return NEWRRMODEL
        End Get

    End Property
    Private customMsg As New customMessageBox
    Private Sub FReceivingReportListNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        NEWRRMODEL.initialize_searchBarPanel(Panel11)
        NEWRRMODEL.execute_initialize(loadingPanel)

        Dim fontFamily As New Dictionary(Of String, String)
        fontFamily.Add("fontName", cFontsFamily.bombardier)
        fontFamily.Add("fontSize", 12)

        searchUI.king_placeholder_textbox("Search RR No...",
                                    txtSearch,
                                    Nothing,
                                    Panel11,
                                    My.Resources.received,
                                    False,
                                    searchUI.cCustomColor.Custom1,,,, fontFamily)

        'color legend

        poLegend.BackColor = cRsRowColor.WsPo
        rrLegend.BackColor = cRsRowColor.Rr
        totalLegend.BackColor = Color.White
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        NEWRRMODEL.initialize("", txtSearch.Text, DataGridView1)
        NEWRRMODEL.execute()
    End Sub

    Private Sub EditAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditAllToolStripMenuItem.Click
        If Utilities.isNotRestrictedTo(cDepartments.PURCHASING) Or
            Utilities.isAuthenticatedWithoutMessage(auth) Then

            'If Not isOnwerOfSelectedRsData() Then
            '    customMsg.message("error", "you are not an owner of this data...", "SMS INFO:")
            '    Exit Sub
            'End If

            With FCreateReceiving
                .isEditNew = True
                .btnCreateReceiving.Text = "Update Receiving"

                Dim rr_item_id As Integer = DataGridView1.SelectedRows(0).Cells(NameOf(cn.rr_item_id)).Value

                .rrDataForEditNew = NEWRRMODEL.
                                        getListOfRrDatas().
                                        FirstOrDefault(Function(x)
                                                           Return x.rr_item_id = rr_item_id
                                                       End Function)

                .ShowDialog()
            End With

        Else
            customMsg.message("error", "You are not allowed to this transaction!", "SMS INFO:")
        End If

    End Sub

    Private Sub disableAllItems()
        For Each item As ToolStripMenuItem In ContextMenuStrip1.Items
            item.Enabled = False
        Next
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        Try

            If DataGridView1.Rows.Count > 0 Then

                Dim row = DataGridView1.SelectedRows(0)

                If row.Cells(NameOf(cn.level)).Value = cLevel.rr Then
                    disableAllItems()
                    enableDisableItems(EditToolStripMenuItem.Name)
                    enableDisableItems(RemoveToolStripMenuItem.Name)

                Else
                    disableAllItems()
                End If
            Else
                disableAllItems()
            End If

            enableDisableItems(RefreshToolStripMenuItem.Name)
            enableDisableItems(ColumnSettingsToolStripMenuItem.Name)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub enableDisableItems(itemName As String)
        Try
            For Each item As ToolStripMenuItem In ContextMenuStrip1.Items
                If item.Name = itemName Then
                    item.Enabled = True
                End If
            Next
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        If Not isAuthenticated(auth) Then
            Exit Sub
        Else
            removeReceiving()
        End If


    End Sub

    Private Sub removeReceiving()
        Try
            If customMsg.messageYesNo("Are you sure you want to remove selected data?", "SUPPLY INFO:", MessageBoxIcon.Question) Then
                Dim deleteReceiving As New DeleteReceivingServices
                Dim rr_item_id As Integer = DataGridView1.SelectedRows(0).Cells(NameOf(cn.rr_item_id)).Value

                Dim rrData = NEWRRMODEL.getListOfRrDatas().
                                            FirstOrDefault(Function(x)
                                                               Return x.rr_item_id = rr_item_id
                                                           End Function)

                Dim deleteResult As Boolean

                If isForTire(rrData) Then
                    deleteResult = deleteReceiving.ExecuteIncludingTireWithReturnBoolean(rrData)
                Else
                    deleteResult = deleteReceiving.ExecuteWithReturnBoolean(rrData)
                End If

                If deleteResult = True Then
                    customMsg.message("info", "selected item successfully deleted!", "SUPPLY INFO:")
                    btnSearch.PerformClick()
                Else
                    customMsg.message("error", "something went wrong in your query to delete!", "SUPPLY INFO:")
                End If
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Function isForTire(rrData As ReceivingModel.COLUMNS) As Boolean
        If rrData?.serial_id > 0 Then
            Return True
        End If
    End Function

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub EditTireSerialNoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditTireSerialNoToolStripMenuItem.Click
        customMsg.message("warning", "coming soon...", "SUPPLY INFO:")
    End Sub

    Private Sub SearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchToolStripMenuItem.Click
        customMsg.message("warning", "coming soon...", "SMS INFO:")
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                btnSearch.PerformClick()
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub EditRRQtyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditRRQtyToolStripMenuItem.Click
        Try
            'If Not isOnwerOfSelectedRsData() Then
            '    customMsg.message("error", "you are not an owner of this data...", "SMS INFO:")
            '    Exit Sub
            'End If

            Dim selectedRow = DataGridView1.SelectedRows(0)

            Dim rr_item_sub_id As Integer = selectedRow.Cells(NameOf(cn.rr_item_sub_id)).Value
            Dim rr_item_id As Integer = selectedRow.Cells(NameOf(cn.rr_item_id)).Value

            Dim rrDatas = NEWRRMODEL.getListOfRrDatas().FirstOrDefault(Function(x) x.rr_item_sub_id = rr_item_sub_id)

            With FEditRSQtyOnly
                .isFromReceiving = True
                .cRrQty = rrDatas.rr_qty
                .cUnit = rrDatas.unit
                .cRrItemSubId = rr_item_sub_id
                .cRrItemId = rr_item_id

                .ShowDialog()
            End With

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

#Region "PRIVATE GET"

    Private Function getRrDataByRrItemId(rrItemId As Integer) As PropsFields.receiving_props_fields

        Try
            Dim listOfReceiving = NEWRRMODEL.getListOfReceiving
            getRrDataByRrItemId = listOfReceiving.FirstOrDefault(Function(x) x.rr_item_id = rrItemId)

            Return getRrDataByRrItemId
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function

    Public Function isOnwerOfSelectedRsData()
        Try
            Dim cn = NEWRRMODEL.cn
            Dim rr_item_id As Integer = DataGridView1.SelectedRows(0).Cells(NameOf(cn.rr_item_id)).Value

            Dim rrData = getRrDataByRrItemId(rr_item_id)

            If Utilities.isOnwerOfData(rrData.user_id) OrElse
                Utilities.isAuthenticatedWithoutMessage(auth) Then

                Return True

            Else
                Return False

            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Sub ColumnSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColumnSettingsToolStripMenuItem.Click
        Try
            Dim listOfColumnSettings As New List(Of PropsFields.columnSettings)

            With FColumnSettings
                customDataGrid.customDatagridview(.DataGridView1)
                customDataGrid.autoSizeColumn(.DataGridView1, True)

                For Each col As DataGridViewColumn In DataGridView1.Columns
                    Dim colSettings As New PropsFields.columnSettings

                    With colSettings
                        .displayIndex = col.DisplayIndex.ToString()
                        .headerText = col.HeaderText
                        .headerName = col.Name
                    End With

                    listOfColumnSettings.Add(colSettings)
                Next

                .isFromRrForm = True
                .DataGridView1.DataSource = listOfColumnSettings

                customDatagridView(.DataGridView1)
                .ShowDialog()
            End With
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub customDatagridView(dgv As DataGridView)
        Try
            Dim cn3 As New PropsFields.columnSettings

            ''hide columns
            'For Each column As DataGridViewColumn In dgv.Columns
            '    If column.Name = NameOf(cn3.headerName) Then
            '        column.Visible = False
            '    Else
            '        column.Visible = True
            '    End If
            'Next

            Dim chkCol As New DataGridViewCheckBoxColumn() With {
                  .Name = "Select",                ' column’s internal name
                  .HeaderText = "Select",          ' what shows in the header
                  .Width = 50,                     ' optional sizing
                  .ReadOnly = False             ' allow the user to check/uncheck
                  }

            dgv.Columns.Add(chkCol)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub


#End Region
End Class