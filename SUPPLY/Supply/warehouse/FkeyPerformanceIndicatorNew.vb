Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FkeyPerformanceIndicatorNew
    Private customGridview As New CustomGridview
    Private indicatorUI, searchUI, leadTimeDaysCategoryUI, leadTimeDaysUI As New class_placeholder5
    Dim SQ As New SQLcon
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim public_query As String
    Private cSaveCaption As New enumSaveCaption
    Private customMsg As New customMessageBox
    Private cEditKpi As New PropsFields.KPIprops_fields
    Private cLeadTimeCategoryNew As String
    Private cKPI As New KeyPerformanceIndicatorModel
    Private kpiModel As New ModelNew.Model
    Dim cBgWorkerChecker As Timer
    Private tempRowValues As List(Of Object) = Nothing
    Dim IsFormBeingDragged As Boolean
    Dim drag As Boolean
    Dim MouseDownX As Integer
    Dim MouseDownY As Integer

    Private dragging As Boolean = False
    Private dragOffset As Point
    Private indicatorsCopy As String = ""


    Public Class enumSaveCaption
        Public ReadOnly Property Save As String = "Save (Ctrl + S)"
        Public ReadOnly Property Update As String = "Update (Ctrl + S)"
    End Class

    Private Sub btnPanelPopUpExit_Click(sender As Object, e As EventArgs) Handles btnPanelPopUpExit.Click
        panelBoxClose()
    End Sub

    Dim l As New List(Of String)
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
        FCreateWarehouseItemForm.txtKPI.Text = indicatorsCopy
    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        If DataGridView1.CurrentRow Is Nothing OrElse DataGridView1.CurrentRow.IsNewRow Then
            MessageBox.Show("Please select a valid row first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim selectedRow As DataGridViewRow = DataGridView1.CurrentRow
        Dim KpiIdStr As String = selectedRow.Cells(0).Value?.ToString()
        Dim kpiCategory As String = selectedRow.Cells(3).Value?.ToString()

        Dim exists As Boolean = DataGridView2.Rows.Cast(Of DataGridViewRow)().
        Any(Function(r) r.Cells(0).Value IsNot Nothing AndAlso r.Cells(0).Value.ToString() = KpiIdStr)

        Dim movingExists As Boolean = DataGridView2.Rows.Cast(Of DataGridViewRow)().
        Any(Function(r) r.Cells(3).Value IsNot Nothing AndAlso r.Cells(3).Value.ToString() = "Moving Category")

        If exists Then
            MessageBox.Show("This KPI ID already exists in the list.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        ElseIf kpiCategory = "Moving Category" AndAlso movingExists Then
            MessageBox.Show("Only one 'Moving Category' can be added.", "Restriction", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        tempRowValues = New List(Of Object)()
        For i As Integer = 0 To selectedRow.Cells.Count - 1
            tempRowValues.Add(selectedRow.Cells(i).Value)
        Next

        If kpiCategory = "Type Request Category" Then
            Panel2.Visible = True
            'searchBoxLocation(Panel1, 0, Panel2)
            Panel2.Location = New Point(391, 104)
            ComboBox1.SelectedIndex = -1
            ComboBox1.Focus()

            DataGridView1.Enabled = False
        Else
            While DataGridView2.Columns.Count <= 4
                DataGridView2.Columns.Add("col" & DataGridView2.Columns.Count.ToString(), "Column " & DataGridView2.Columns.Count.ToString())
            End While

            Dim newRowIndex As Integer = DataGridView2.Rows.Add(tempRowValues.ToArray())
            DataGridView2.Rows(newRowIndex).Cells(4).Value = "N/A"
        End If
    End Sub

    Private Sub FkeyPerformanceIndicatorNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        displayKeyIndicators()
        display_type_of_request()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        gettingAllKpiID()
        gettingAllIndicators()
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

    Private Sub displayKeyIndicators()
        DataGridView1.Rows.Clear()
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_kpi_crud"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 3)
            dr = sqlcomm.ExecuteReader()

            While dr.Read
                DataGridView1.Rows.Add(dr.Item(0).ToString(),
                                dr.Item(1).ToString(),
                                dr.Item(3).ToString(),
                                dr.Item(2).ToString())
            End While
            dr.Close()
        Catch ex As Exception
            Dim msg1 As New customMessageBox
            msg1.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

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

    Private Sub gettingAllKpiID()
        Dim kpiIds As New List(Of String)

        For Each row As DataGridViewRow In DataGridView2.Rows
            If Not row.IsNewRow AndAlso row.Cells(0).Value IsNot Nothing Then
                kpiIds.Add(row.Cells(0).Value.ToString())

                'store kpi_id and tor_id
                Dim _kpi_id_and_tor_id_storage As New PropsFields.SELECTED_KPI
                With _kpi_id_and_tor_id_storage
                    .kpi_id = row.Cells("col_kpi_id").Value
                    .tor_id = Utilities.ifBlankReplaceToZero(row.Cells("col_tor_id").Value) ' IIf(row.Cells("col_tor_id").Value = "N/A", 0, row.Cells("col_tor_id").Value)
                End With

                FCreateWarehouseItemForm.cListOfSelectedKPI.Add(_kpi_id_and_tor_id_storage)
            End If
        Next

        Dim joinedIds As String = String.Join(", ", kpiIds.ToArray())
        'FCreateWarehouseItemForm.kpiId_selected = joinedIds
        With FCreateWarehouseItemForm
            .txtKPI.ReadOnly = False
            .txtKPI.Text = joinedIds
            .txtKPI.ReadOnly = True
        End With

        'MsgBox(FCreateWarehouseItemForm.kpiId_selected)
        Me.Close()
    End Sub

    Private Sub gettingAllIndicators()
        Dim kpiIndicators As New List(Of String)

        For Each row As DataGridViewRow In DataGridView2.Rows
            If Not row.IsNewRow AndAlso row.Cells(1).Value IsNot Nothing Then
                kpiIndicators.Add(row.Cells(1).Value.ToString())
            End If
        Next
        Dim joinedIds As String = String.Join(", ", kpiIndicators.ToArray())
        FCreateWarehouseItemForm.txtKPI.Text = joinedIds
        indicatorsCopy = joinedIds
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        MessageBox.Show("This Function Temporary not Functional", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'Dim id As Integer = DataGridView1.SelectedRows(0).Cells(0).Value
        'panelPopUp.Visible = True

        'Dim data = Results.rListOfKPiData.Where(Function(x) x.kpi_id = id).ToList()
        'If data.Count > 0 Then
        '    indicatorUI.tbox.Text = data(0).indicator
        '    indicatorUI.resetBgColor()
        '    leadTimeDaysUI.tbox.Text = data(0).lead_time_days
        '    leadTimeDaysUI.resetBgColor()
        '    leadTimeDaysCategoryUI.tbox.Text = data(0).lead_time_category
        '    leadTimeDaysCategoryUI.resetBgColor()
        '    cEditKpi = data(0)
        'End If

        'btnSave.Text = cSaveCaption.Update
        'indicatorUI.tbox.Focus()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Dim kpi_category As String
        'For Each row As DataGridViewRow In DataGridView2.Rows
        '    If row.Cells(3).Value.ToString() = "Type Request Category" Then
        '        kpi_category = row.Cells(3).Value.ToString()
        '        Exit For
        '    End If
        'Next
        gettingAllKpiID()
        gettingAllIndicators()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel2.Visible = False
        DataGridView1.Enabled = True
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        If tempRowValues Is Nothing Then
            MsgBox("No row prepared to add. Please choose a row first.")
            Return
        End If

        If ComboBox1.Text Is Nothing OrElse ComboBox1.Text.Trim() = "" Then
            MsgBox("Please select data first.")
            Return
        End If

        While DataGridView2.Columns.Count <= 4
            DataGridView2.Columns.Add("col" & DataGridView2.Columns.Count.ToString(), "Column " & DataGridView2.Columns.Count.ToString())
        End While

        Dim newRowIndex As Integer = DataGridView2.Rows.Add(tempRowValues.ToArray())
        DataGridView2.Rows(newRowIndex).Cells(4).Value = ComboBox1.Text

        tempRowValues = Nothing
        ComboBox1.SelectedIndex = -1
        Panel2.Visible = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If tempRowValues Is Nothing Then
            MsgBox("No row prepared to add. Please choose a row first.")
            Return
        End If

        If ComboBox1.Text Is Nothing OrElse ComboBox1.Text.Trim() = "" Then
            MsgBox("Please select data first.")
            Return
        End If

        While DataGridView2.Columns.Count <= 4
            DataGridView2.Columns.Add("col" & DataGridView2.Columns.Count.ToString(), "Column " & DataGridView2.Columns.Count.ToString())
        End While

        Dim newRowIndex As Integer = DataGridView2.Rows.Add(tempRowValues.ToArray())
        DataGridView2.Rows(newRowIndex).Cells(4).Value = ComboBox1.SelectedValue

        tempRowValues = Nothing
        ComboBox1.SelectedIndex = -1
        Panel2.Visible = False
        DataGridView1.Enabled = True
    End Sub

    Private Function haveAnError() As Boolean
#Region "FILTER"
        If indicatorUI.ifBlankTexbox() Or
            leadTimeDaysUI.ifBlankTexbox() Or
            leadTimeDaysCategoryUI.ifBlankTexbox() Then

            customMsg.message("error", "textfields must not be blank!", "SUPPLY INFO:")
            Return True
        End If

#End Region
    End Function

    Private Sub RemoveSelectedIndicatorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveSelectedIndicatorToolStripMenuItem.Click
        If DataGridView2.SelectedRows.Count > 0 Then
            Dim confirm As DialogResult = MessageBox.Show("Are you sure you want to delete this row?", "Confirm Delete", MessageBoxButtons.YesNo)
            If confirm = DialogResult.Yes Then
                DataGridView2.Rows.Remove(DataGridView2.SelectedRows(0))
            End If
        Else
            MessageBox.Show("No row selected.")
        End If
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        MsgBox("The delete function is not working at the moment. Please go to Warehousing and edit the item there to delete it.", MsgBoxStyle.Exclamation, "Notice")

    End Sub

    Private Sub panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
        End If
    End Sub

    Private Sub panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If IsFormBeingDragged Then
            Dim temp As Point = New Point()

            temp.X = Me.Location.X + (e.X - MouseDownX)
            temp.Y = Me.Location.Y + (e.Y - MouseDownY)
            Me.Location = temp
            temp = Nothing
        End If
    End Sub

    Private Sub panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
    End Sub

    Private Sub Panel2_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel2.MouseMove

    End Sub

    Private Sub Panel2_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel2.MouseUp

    End Sub

    Private Sub Panel2_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel2.MouseDown
        If e.Button = MouseButtons.Left Then
            Dim m As System.Windows.Forms.Message = System.Windows.Forms.Message.Create(Me.Handle, &HA1, New IntPtr(2), IntPtr.Zero)
            Capture = False
            DefWndProc(m)
        End If
    End Sub

    Private Sub panelPopUp_MouseDown(sender As Object, e As MouseEventArgs) Handles panelPopUp.MouseDown
        If e.Button = MouseButtons.Left Then
            dragging = True
            dragOffset = New Point(Cursor.Position.X - Me.Left, Cursor.Position.Y - Me.Top)
        End If
    End Sub

    Private Sub panelPopUp_MouseMove(sender As Object, e As MouseEventArgs) Handles panelPopUp.MouseMove
        If dragging Then
            Me.Location = New Point(Cursor.Position.X - dragOffset.X, Cursor.Position.Y - dragOffset.Y)
        End If
    End Sub

    Private Sub panelPopUp_MouseUp(sender As Object, e As MouseEventArgs) Handles panelPopUp.MouseUp
        dragging = False
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub



    Private Sub kpiSaved()
        Try
            If customMsg.messageYesNo("Are you sure you want to save this data?", "SUPPLY INFO:") Then

                Dim wh_id As Integer = 0
                Dim createKpi As New PropsFields.KPIprops_fields
                With createKpi
                    .indicator = txtIndicator.Text
                    .lead_time_days = txtLeadTimeDays.Text
                    .lead_time_category = txtLeadTimeCategory.Text
                End With

                Dim result As Integer = cKPI.saved(createKpi)

                If result > 0 Then
                    customMsg.message("info", "Successfully saved...", "SUPPLY INFO:")
                    'loadAllDataHere()
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
            cEditKpi.lead_time_category = txtLeadTimeCategory.Text

            Dim result As Boolean = cKPI.update(cEditKpi, cEditKpi.kpi_id)

            If result = True Then
                customMsg.message("info", "Successfully updated...", "SUPPLY INFO:")
                'loadAllDataHere()
                FWarehouseItemsNew.displayKpiCategory()
                panelBoxClose()

            Else
                customMsg.message("error", "something went wrong with update!", "SUPPLY INFO:")
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub


    Private Sub display_type_of_request()
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand("sp_kpi_crud", SQ.connection)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 4)

            Dim dt As New DataTable()
            Dim da As New SqlDataAdapter(sqlcomm)
            da.Fill(dt)

            ComboBox1.DataSource = dt
            ComboBox1.DisplayMember = "tor_desc"
            ComboBox1.ValueMember = "tor_id"

        Catch ex As Exception
            Dim msg1 As New customMessageBox
            msg1.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
End Class