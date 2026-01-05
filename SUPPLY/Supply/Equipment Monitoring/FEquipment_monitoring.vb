Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Globalization
Imports Microsoft.Office.Interop
Imports System.Drawing


Public Class FEquipment_monitoring
    Public SQ As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    'Dim begin_search As Boolean = False
    Private Sub FEquipment_monitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        exclusive_input()
        load_equipType(cmb_equp_type)
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy"
        cmb_search.Text = "All Type"
        btn_search.PerformClick()
        Panel8.Visible = False
        'txt_acquired_date.Enabled = True
    End Sub
    Public Sub view_reportable_data()
        FReportable_Data.lvl_equipment_monitoring.Items.Clear()
        Dim nwsqlcmd As New SqlCommand
        Dim a(20) As String
        Try
            SQ.connection.Open()

            nwsqlcmd.Connection = SQ.connection
            nwsqlcmd.CommandText = "proc_equipment_monitoring"
            nwsqlcmd.Parameters.Clear()
            nwsqlcmd.CommandType = CommandType.StoredProcedure

            ''If cmb_search_equiptype.Text = "All" Or cmb = "" Then
            'nwsqlcmd.Parameters.AddWithValue("@n", 7)

            ''Else
            ''    nwsqlcmd.Parameters.AddWithValue("@n", 8)
            ''    nwsqlcmd.Parameters.AddWithValue("@plate_no", cmb_search_plateno.Text)
            ''End If

            If cmb_search.Text = "All Type" Then
                nwsqlcmd.Parameters.AddWithValue("@n", 77)
            Else
                nwsqlcmd.Parameters.AddWithValue("@n", 777)
                nwsqlcmd.Parameters.AddWithValue("@plate_no", cmb_search_equiptype.Text)
            End If
            nwsqlcmd.Parameters.AddWithValue("@datefrom", DateTimePicker2.Text)
            nwsqlcmd.Parameters.AddWithValue("@dateto", DateTimePicker3.Text)
            nwsqlcmd.Parameters.AddWithValue("@date", Date.Now)
            nwsqlcmd.CommandTimeout = 0
            dr = nwsqlcmd.ExecuteReader
            While dr.Read
                'item.SubItems.Item(10).Text - (MonthDifference(date_aquired, Date.Now))
                Dim remaining_months As Integer = dr.Item(12).ToString - MonthDifference(dr.Item(1).ToString, DateTimePicker3.Value)
                'MsgBox(remaining_months)
                a(0) = dr.Item(0).ToString
                a(1) = Format(Date.Parse(dr.Item(1).ToString), "MM/dd/yyyy")
                a(2) = dr.Item(4).ToString
                a(3) = dr.Item(5).ToString
                a(4) = dr.Item(6).ToString
                a(5) = dr.Item(7).ToString
                a(6) = FormatNumber(dr.Item(8).ToString)
                a(7) = FormatNumber(dr.Item(9).ToString)
                a(8) = FormatNumber(dr.Item(10).ToString)
                a(9) = dr.Item(11).ToString
                a(10) = dr.Item(12).ToString
                a(11) = FormatNumber(dr.Item(13).ToString)
                a(12) = FormatNumber(dr.Item(14).ToString)
                If remaining_months <= 0 Then
                    a(13) = dr.Item(12).ToString
                    a(15) = FormatNumber(CDbl(dr.Item(12).ToString) * CDbl(dr.Item(14).ToString))
                    a(16) = FormatNumber(dr.Item(9).ToString)
                Else
                    a(13) = dr.Item(15).ToString
                    a(15) = FormatNumber(dr.Item(17).ToString)
                    a(16) = FormatNumber(dr.Item(18).ToString)
                End If

                a(14) = FormatNumber(dr.Item(16).ToString)
                a(17) = dr.Item(19).ToString
                Dim rem_use As Integer = CInt(dr.Item(12).ToString) - MonthDifference(Format(Date.Parse(dr.Item(1).ToString), "MM/dd/yyyy"), DateTimePicker3.Value)
                Dim assessment As String = ""
                If rem_use < 0 Then
                    rem_use = 0
                    assessment = "Fully Depreciated"
                End If

                a(18) = rem_use
                'a(19) = CInt(MonthDifference(Format(Date.Parse(dr.Item(1).ToString), "MM/dd/yyyy"), Date.Now) / 12) & "Year/s & " & (MonthDifference(Format(Date.Parse(dr.Item(1).ToString), "MM/dd/yyyy"), Date.Now) Mod 12) & " Month/s"
                a(19) = MonthDifference(Format(Date.Parse(dr.Item(1).ToString), "MM/dd/yyyy"), DateTimePicker3.Value) & " Month/s"
                a(20) = assessment
                Dim lvlList As New ListViewItem(a)
                'DataGridView1.Rows.Add(a)
                'flvl_equipment_monitoring.Items.Add(lvlList)
                FReportable_Data.lvl_equipment_monitoring.Items.Add(lvlList)

            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
        'last_three_column()
        'begin_search = True
    End Sub
    Public Sub view_equipment_minotoring_data(cmb As String)
        'lvl_equipment_monitoring.Items.Clear()
        DataGridView1.Rows.Clear()
        Dim nwsqlcmd As New SqlCommand
        Dim a(20) As String
        Try
            SQ.connection.Open()

            nwsqlcmd.Connection = SQ.connection
            nwsqlcmd.CommandText = "proc_equipment_monitoring"
            nwsqlcmd.Parameters.Clear()
            nwsqlcmd.CommandType = CommandType.StoredProcedure

            ''If cmb_search_equiptype.Text = "All" Or cmb = "" Then
            'nwsqlcmd.Parameters.AddWithValue("@n", 7)

            ''Else
            ''    nwsqlcmd.Parameters.AddWithValue("@n", 8)
            ''    nwsqlcmd.Parameters.AddWithValue("@plate_no", cmb_search_plateno.Text)
            ''End If

            If cmb_search.Text = "All Type" Then
                nwsqlcmd.Parameters.AddWithValue("@n", 7)
            Else
                nwsqlcmd.Parameters.AddWithValue("@n", 88)
                nwsqlcmd.Parameters.AddWithValue("@plate_no", cmb_search_equiptype.Text)
            End If
            nwsqlcmd.Parameters.AddWithValue("@datefrom", DateTimePicker2.Text)
            nwsqlcmd.Parameters.AddWithValue("@dateto", DateTimePicker3.Text)
            nwsqlcmd.Parameters.AddWithValue("@date", Date.Now)
            nwsqlcmd.CommandTimeout = 0
            dr = nwsqlcmd.ExecuteReader
            While dr.Read
                'item.SubItems.Item(10).Text - (MonthDifference(date_aquired, Date.Now))
                Dim remaining_months As Integer = dr.Item(12).ToString - MonthDifference(dr.Item(1).ToString, Date.Now)
                'MsgBox(remaining_months)
                a(0) = dr.Item(0).ToString
                a(1) = Format(Date.Parse(dr.Item(1).ToString), "MM/dd/yyyy")
                a(2) = dr.Item(4).ToString
                a(3) = dr.Item(5).ToString
                a(4) = dr.Item(6).ToString
                a(5) = dr.Item(7).ToString
                a(6) = FormatNumber(dr.Item(8).ToString)
                a(7) = FormatNumber(dr.Item(9).ToString)
                a(8) = FormatNumber(dr.Item(10).ToString)
                a(9) = dr.Item(11).ToString
                a(10) = dr.Item(12).ToString
                a(11) = FormatNumber(dr.Item(13).ToString)
                a(12) = FormatNumber(dr.Item(14).ToString)
                If remaining_months <= 0 Then
                    a(13) = dr.Item(12).ToString
                    a(15) = FormatNumber(CDbl(dr.Item(12).ToString) * CDbl(dr.Item(14).ToString))
                    a(16) = FormatNumber(dr.Item(9).ToString)
                Else
                    a(13) = dr.Item(15).ToString
                    a(15) = FormatNumber(dr.Item(17).ToString)
                    a(16) = FormatNumber(dr.Item(18).ToString)
                End If

                a(14) = FormatNumber(dr.Item(16).ToString)
                a(17) = dr.Item(19).ToString
                Dim rem_use As Integer = CInt(dr.Item(12).ToString) - MonthDifference(Format(Date.Parse(dr.Item(1).ToString), "MM/dd/yyyy"), Date.Now)
                Dim assessment As String = ""
                If rem_use < 0 Then
                    rem_use = 0
                    assessment = "Fully Depreciated"
                End If

                a(18) = rem_use
                'a(19) = CInt(MonthDifference(Format(Date.Parse(dr.Item(1).ToString), "MM/dd/yyyy"), Date.Now) / 12) & "Year/s & " & (MonthDifference(Format(Date.Parse(dr.Item(1).ToString), "MM/dd/yyyy"), Date.Now) Mod 12) & " Month/s"
                a(19) = MonthDifference(Format(Date.Parse(dr.Item(1).ToString), "MM/dd/yyyy"), Date.Now) & " Month/s"
                a(20) = assessment
                Dim lvlList As New ListViewItem(a)
                DataGridView1.Rows.Add(a)
                'lvl_equipment_monitoring.Items.Add(lvlList)

            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
        'last_three_column()
        'begin_search = True
    End Sub
    Public Sub load_equipType(cmbox As ComboBox)
        cmbox.Items.Clear()
        cmb_search_equiptype.Items.Clear()
        'cmb_search_equiptype.Items.Add("All")
        Dim sqL As New SQLcon
        Dim sqlcommand As New SqlCommand
        Dim dr As SqlDataReader
        Try
            sqL.connection.Open()
            sqlcommand.Connection = sqL.connection
            sqlcommand.CommandText = "proc_equipment_monitoring"
            sqlcommand.Parameters.Clear()
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.Parameters.AddWithValue("@n", 2)
            sqlcommand.CommandTimeout = 0

            dr = sqlcommand.ExecuteReader
            While dr.Read
                cmb_search_equiptype.Items.Add(dr.Item("equip_typeOf").ToString)

                cmbox.Items.Add(dr.Item("equip_typeOf").ToString)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqL.connection.Close()
        End Try
    End Sub
    Public Sub load_plate_no(cmb As String)
        cmb_palate_no.Items.Clear()
        cmb_search_plateno.Items.Clear()
        Dim nwsqL As New SQLcon
        Dim nwsqlcommand As New SqlCommand
        Dim dr As SqlDataReader
        Try
            nwsqL.connection.Open()
            nwsqlcommand.Connection = nwsqL.connection
            nwsqlcommand.CommandText = "proc_equipment_monitoring"
            nwsqlcommand.Parameters.Clear()
            nwsqlcommand.CommandType = CommandType.StoredProcedure

            If btn_save_update.Enabled = True Then
                nwsqlcommand.Parameters.AddWithValue("@n", 3)
            Else
                nwsqlcommand.Parameters.AddWithValue("@n", 9)
            End If

            nwsqlcommand.Parameters.AddWithValue("@eq_type", cmb)
            nwsqlcommand.CommandTimeout = 0
            dr = nwsqlcommand.ExecuteReader

            While dr.Read
                If btn_save_update.Enabled = True Then
                    cmb_palate_no.Items.Add(dr.Item("plate_no").ToString)
                Else
                    cmb_search_plateno.Items.Add(dr.Item("plate_no").ToString)
                End If
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            nwsqL.connection.Close()
        End Try
    End Sub

    Private Sub cmb_equp_type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_equp_type.SelectedIndexChanged
        load_plate_no(cmb_equp_type.Text)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'begin_search = False
        Me.Close()
        Me.Dispose()
    End Sub
    Public Sub get_data(eq_type As String, plate_no As String)
        Dim sqlcon As New SQLcon
        Dim command As New SqlCommand
        Dim dr As SqlDataReader
        Try
            sqlcon.connection.Open()
            command.Connection = sqlcon.connection
            command.CommandText = "proc_equipment_monitoring"
            command.Parameters.Clear()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@n", 1)
            command.Parameters.AddWithValue("@eq_type", eq_type)
            command.Parameters.AddWithValue("@plate_no", plate_no)
            command.CommandTimeout = 0

            dr = command.ExecuteReader
            Dim counter As Integer = 0

            While dr.Read

                counter = counter + 1

                lbl_equipId.Text = dr.Item(0).ToString
                txt_acquired_date.Text = Format(Date.Parse(dr.Item(1).ToString), "MM/dd/yyyy")
                txt_plate_no.Text = dr.Item(4).ToString
                txt_model_brand.Text = dr.Item(5).ToString
                txt_serial_no.Text = dr.Item(6).ToString
                txt_supplier.Text = dr.Item(7).ToString

            End While

            If counter = 0 Then
                lbl_equipId.Text = ""
                txt_acquired_date.Text = ""
                txt_plate_no.Text = ""
                txt_model_brand.Text = ""
                txt_serial_no.Text = ""
                txt_supplier.Text = ""
            End If

            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try
    End Sub

    Private Sub cmb_palate_no_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_palate_no.SelectedIndexChanged
        get_data(cmb_equp_type.Text, cmb_palate_no.Text)
    End Sub
    Public Sub insert_edit_data(btn_value As String)
        Dim SQcon As New SQLcon
        Dim SQcom As New SqlCommand
        Dim id As Integer = 0
        Try
            SQcon.connection.Open()
            SQcom.Connection = SQcon.connection
            SQcom.CommandText = "proc_equipment_monitoring"
            SQcom.Parameters.Clear()
            SQcom.CommandType = CommandType.StoredProcedure

            If btn_value = "Save" Then
                SQcom.Parameters.AddWithValue("@n", 4)
                SQcom.Parameters.AddWithValue("@equip_id", lbl_equipId.Text)
            Else
                SQcom.Parameters.AddWithValue("@n", 6)
                SQcom.Parameters.AddWithValue("@equip_id", lbl_equipId.Text)
            End If

            SQcom.Parameters.AddWithValue("@aq_cost", txt_acquisition_cost.Text.Replace(",", ""))
            SQcom.Parameters.AddWithValue("@dep_yr", txt_depreciation_yrs.Text)
            SQcom.CommandTimeout = 0

            If btn_value = "Save" Then
                MessageBox.Show("Successfully saved.", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If MessageBox.Show("Are you sure you want to update the data?.", "SUPPLY INFO.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then

                Else
                    Return
                End If
            End If

            SQcom.ExecuteNonQuery()

            view_equipment_minotoring_data(cmb_search.Text)
            clearfields(btn_save_update.Text)
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If btn_value = "Save" Then

                'listfocus(DataGridView1, Focus)
                'DataGridView1.Rows(DataGridView1.Rows.Count - 1).Selected = True
                'lvl_equipment_monitoring.EnsureVisible(DataGridView1.Rows.Count - 1)

            Else
                'listfocus(DataGridView1, lbl_equipId.Text)
                Dim row_index As Integer = find_item_from_datagridview(DataGridView1, 0, lbl_equipId.Text)
                DataGridView1.FirstDisplayedScrollingRowIndex = row_index
                DataGridView1.Rows(row_index).DefaultCellStyle.BackColor = Color.Blue
                DataGridView1.Rows(row_index).DefaultCellStyle.ForeColor = Color.White
            End If
            SQcon.connection.Close()
        End Try
    End Sub


    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save_update.Click
        'dataGridView1.FirstDisplayedScrollingRowIndex = 100
        If txt_acquisition_cost.Text = "" Or txt_depreciation_yrs.Text = "" Or txt_acquired_date.Text = "" Or txt_plate_no.Text = "" _
            Or txt_model_brand.Text = "" Or txt_serial_no.Text = "" Or txt_supplier.Text = "" Then

            MessageBox.Show("Pls. fill in all the required fields.", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            insert_edit_data(btn_save_update.Text)
        End If

    End Sub
    Public Sub clearfields(val As String)
        'cmb_search.Text = Nothing
        cmb_equp_type.Text = Nothing
        cmb_palate_no.Text = Nothing
        txt_acquired_date.Text = ""
        txt_plate_no.Text = ""
        txt_model_brand.Text = ""
        txt_serial_no.Text = ""
        txt_supplier.Text = ""
        txt_acquisition_cost.Text = ""
        txt_depreciation_yrs.Text = ""
        lbl_note.Visible = False
        If val = "Save" Then
        Else
            btn_save_update.Text = "Save"
            cmb_equp_type.Enabled = True
            cmb_palate_no.Enabled = True

        End If
    End Sub
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        btn_save_update.Text = "Update"
        lbl_note.Visible = True
        cmb_equp_type.Enabled = False
        cmb_palate_no.Enabled = False
        'txt_acquired_date.Text = lvl_equipment_monitoring.SelectedItems(0).SubItems(1).Text
        'txt_plate_no.Text = lvl_equipment_monitoring.SelectedItems(0).SubItems(2).Text
        'txt_model_brand.Text = lvl_equipment_monitoring.SelectedItems(0).SubItems(3).Text
        'txt_serial_no.Text = lvl_equipment_monitoring.SelectedItems(0).SubItems(4).Text
        'txt_supplier.Text = lvl_equipment_monitoring.SelectedItems(0).SubItems(5).Text
        'txt_acquisition_cost.Text = lvl_equipment_monitoring.SelectedItems(0).SubItems(6).Text
        'txt_depreciation_yrs.Text = lvl_equipment_monitoring.SelectedItems(0).SubItems(9).Text
        'lbl_equipId.Text = lvl_equipment_monitoring.SelectedItems(0).SubItems(17).Text
        txt_acquired_date.Text = DataGridView1.SelectedRows(0).Cells(1).Value
        txt_plate_no.Text = DataGridView1.SelectedRows(0).Cells(2).Value
        txt_model_brand.Text = DataGridView1.SelectedRows(0).Cells(3).Value
        txt_serial_no.Text = DataGridView1.SelectedRows(0).Cells(4).Value
        txt_supplier.Text = DataGridView1.SelectedRows(0).Cells(5).Value
        txt_acquisition_cost.Text = DataGridView1.SelectedRows(0).Cells(6).Value
        txt_depreciation_yrs.Text = DataGridView1.SelectedRows(0).Cells(9).Value
        lbl_equipId.Text = DataGridView1.SelectedRows(0).Cells(17).Value
    End Sub
    Private Sub txt_aquisition_cost_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_acquisition_cost.KeyPress, txt_depreciation_yrs.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txt_depreciation_yrs_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_depreciation_yrs.KeyDown, txt_acquisition_cost.KeyDown
        If e.KeyCode = Keys.Enter Then
            btn_save_update.PerformClick()
        End If
    End Sub
    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_search_equiptype.SelectedIndexChanged
        'If cmb_search_equiptype.Text = "All" Then
        '    cmb_search_plateno.Enabled = False
        '    view_equipment_minotoring_data(cmb_search.Text)
        'Else
        '    cmb_search_plateno.Enabled = True
        '    load_plate_no(cmb_search_equiptype.Text)
        'End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        cmb_search.Text = Nothing
        cmb_search_equiptype.Text = Nothing
        cmb_search_plateno.Text = Nothing
        panel_equip_monitoring.Visible = False
        btn_save_update.Enabled = True
        btn_search.Enabled = True
        cmb_search.Enabled = True
        'lvl_equipment_monitoring.Enabled = True
        DataGridView1.Enabled = True
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        'If cmb_search.Text = Nothing Then
        '    view_equipment_minotoring_data(cmb_search.Text)
        'Else
        '    panel_equip_monitoring.Visible = True
        '    load_equipType()
        '    cmb_search.Enabled = False
        '    btn_search.Enabled = False
        '    btn_save_update.Enabled = False
        '    lvl_equipment_monitoring.Enabled = False
        'End If
        'If begin_search = False Then

        'Else
        '    last_three_remove()
        'End If

        'Panel8.Visible = True
        view_equipment_minotoring_data(cmb_search.Text)
    End Sub
    Private Sub FEquipment_monitoring_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If MessageBox.Show("Are you sure you want to cancel Update?.", "SUPPLY INFO.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                clearfields(btn_save_update.Text)
            End If
        End If
    End Sub

    Private Sub cmb_search_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_search.SelectedIndexChanged
        'If cmb_search.Text = "Yearly" Or cmb_search.Text = Nothing Then
        '    DateTimePicker1.Format = DateTimePickerFormat.Custom
        '    DateTimePicker1.CustomFormat = "yyyy"
        'Else
        '    DateTimePicker1.Format = DateTimePickerFormat.Custom
        '    DateTimePicker1.CustomFormat = "MM/yyyy"
        'End If
        'btn_search.Enabled = True

        Select Case cmb_search.Text
            Case "All Type"
                cmb_search_equiptype.Enabled = False
            Case Else
                cmb_search_equiptype.Enabled = True
        End Select

    End Sub

    Private Sub cmb_search_plateno_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_search_plateno.SelectedIndexChanged
        view_equipment_minotoring_data(cmb_search.Text)
    End Sub

    Private Sub panel_equip_monitoring_MouseDown(sender As Object, e As MouseEventArgs) Handles panel_equip_monitoring.MouseDown
        If e.Button = MouseButtons.Left Then
            drag = True
            mousex = e.X
            mousey = e.Y
        End If
    End Sub

    Private Sub panel_equip_monitoring_MouseMove(sender As Object, e As MouseEventArgs) Handles panel_equip_monitoring.MouseMove
        If drag Then
            Dim temp As Point = New Point()

            temp.X = panel_equip_monitoring.Location.X + (e.X - mousex)
            temp.Y = panel_equip_monitoring.Location.Y + (e.Y - mousey)
            panel_equip_monitoring.Location = temp
            temp = Nothing
        End If
    End Sub

    Private Sub panel_equip_monitoring_MouseUp(sender As Object, e As MouseEventArgs) Handles panel_equip_monitoring.MouseUp
        If e.Button = MouseButtons.Left Then
            drag = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'view_report()
    End Sub
    Public Sub view_report()


        Dim dt As New DataTable

        With dt
            .Columns.Add("id")
            .Columns.Add("date_aquired")
            .Columns.Add("plate_no")
            .Columns.Add("model_brand")
            .Columns.Add("serial_no")
            .Columns.Add("supplier")
            .Columns.Add("Acquisition_Cost")
            .Columns.Add("Scrap_Salvage")
            .Columns.Add("Cost")
            .Columns.Add("Depreciation_Yrs")
            .Columns.Add("Depreciation_Mos")
            .Columns.Add("Per_Year")
            .Columns.Add("Per_Month")
            .Columns.Add("Month")
            .Columns.Add("Amount")
            .Columns.Add("Cum_AD")
            .Columns.Add("Net_Val")
            .Columns.Add("equip_mon_id")
        End With

        'For i As Integer = 0 To lvl_equipment_monitoring.Items.Count - 1
        '    dt.Rows.Add(lvl_equipment_monitoring.Items(i).SubItems(0).Text, lvl_equipment_monitoring.Items(i).SubItems(1).Text,
        '    lvl_equipment_monitoring.Items(i).SubItems(2).Text, lvl_equipment_monitoring.Items(i).SubItems(3).Text,
        '    lvl_equipment_monitoring.Items(i).SubItems(4).Text, lvl_equipment_monitoring.Items(i).SubItems(5).Text,
        '    lvl_equipment_monitoring.Items(i).SubItems(6).Text, lvl_equipment_monitoring.Items(i).SubItems(7).Text,
        '    lvl_equipment_monitoring.Items(i).SubItems(8).Text, lvl_equipment_monitoring.Items(i).SubItems(9).Text,
        '    lvl_equipment_monitoring.Items(i).SubItems(10).Text, lvl_equipment_monitoring.Items(i).SubItems(11).Text,
        '    lvl_equipment_monitoring.Items(i).SubItems(12).Text, lvl_equipment_monitoring.Items(i).SubItems(13).Text,
        '    lvl_equipment_monitoring.Items(i).SubItems(14).Text, lvl_equipment_monitoring.Items(i).SubItems(15).Text,
        '    lvl_equipment_monitoring.Items(i).SubItems(16).Text, lvl_equipment_monitoring.Items(i).SubItems(17).Text)


        'Next

        'For Each item As ListViewItem In Me.ListView1.Items
        'Next

        Dim view As New DataView(dt)

        'Freport_EquiMonitoring.ReportViewer1.LocalReport.DataSources.Item(0).Value = view
        'Freport_EquiMonitoring.ShowDialog()
        'Freport_EquiMonitoring.Dispose()

    End Sub

    Private Sub GenerateIncomeStatementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerateIncomeStatementToolStripMenuItem.Click
        FIncome_statement.Show()
    End Sub

    Private Sub cms_equip_monitoring_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cms_equip_monitoring.Opening
        'If lvl_equipment_monitoring.SelectedItems.Count > 0 Then
        '    cms_equip_monitoring.Enabled = True
        'Else
        '    cms_equip_monitoring.Enabled = False
        'End If
        If DataGridView1.SelectedRows.Count > 0 Then
            cms_equip_monitoring.Enabled = True
        Else
            cms_equip_monitoring.Enabled = False
        End If
    End Sub

    Private Sub SummaryOfAcquiredToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SummaryOfAcquiredToolStripMenuItem.Click
        FSummary_of_AcquiredEquipment.Show()
    End Sub

    Private Sub SummaryOfAllAcquiredEquipmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SummaryOfAllAcquiredEquipmentToolStripMenuItem.Click
        FAll_Summary_of_acquiredEquipment.Show()
    End Sub
    Private Sub DateRangeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DateRangeToolStripMenuItem.Click
        frm_equipment_range.itemlist.Clear()
        Dim i As Integer = 0
        'For Each item As ListViewItem In lvl_equipment_monitoring.
        For Each item As DataGridViewRow In DataGridView1.Rows
            frm_equipment_range.itemlist.Add(New List(Of String))
            frm_equipment_range.itemlist(i).Add(item.Cells(1).Value)
            frm_equipment_range.itemlist(i).Add(item.Cells(2).Value)
            frm_equipment_range.itemlist(i).Add(item.Cells(3).Value)
            frm_equipment_range.itemlist(i).Add(item.Cells(4).Value)
            frm_equipment_range.itemlist(i).Add(item.Cells(5).Value)
            frm_equipment_range.itemlist(i).Add(item.Cells(6).Value)
            frm_equipment_range.itemlist(i).Add(item.Cells(7).Value)
            frm_equipment_range.itemlist(i).Add(item.Cells(8).Value)
            frm_equipment_range.itemlist(i).Add(item.Cells(9).Value)
            frm_equipment_range.itemlist(i).Add(item.Cells(10).Value)
            frm_equipment_range.itemlist(i).Add(item.Cells(11).Value)
            frm_equipment_range.itemlist(i).Add(item.Cells(12).Value)
            i = i + 1
        Next
        frm_equipment_range.ShowDialog()
        'hide_range_panel(False)
    End Sub

    Public Shared Function MonthDifference(ByVal first As DateTime, ByVal second As DateTime) As Integer
        'MsgBox(first.Month & "==" & first.Day & "==" & first.Year)

        Dim res As Integer = 0
        If first.Day > second.Day Then
            res = (second.Month - first.Month) + 12 * (second.Year - first.Year) - 1
        Else
            res = (second.Month - first.Month) + 12 * (second.Year - first.Year)
        End If
        If res <= 0 Then
            Return 0
        Else
            Return res
        End If

    End Function

    Private Sub EquipmentInvestmentMonitoringToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EquipmentInvestmentMonitoringToolStripMenuItem.Click
        FEquipment_InvestmentMonitoring.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Panel8.Visible = True
        'FReportable_Data.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Panel8.Visible = False
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        view_reportable_data()
        FReportable_Data.Show()
        Panel8.Visible = False
    End Sub

    Private Sub ExportToExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        Dim xlApp As New Excel.Application

        Try

            SaveFileDialog1.Title = "Save Excel File"
            SaveFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx"
            SaveFileDialog1.ShowDialog()

            'exit if no file selected
            If SaveFileDialog1.FileName = "" Then
                Exit Sub
            End If

            'create objects to interface to Excel
            Dim xls As New Excel.Application
            Dim book As Excel.Workbook
            Dim sheet As Excel.Worksheet

            Dim chartRange As Excel.Range

            'create a workbook and get reference to first worksheet
            xls.Workbooks.Add()
            book = xls.ActiveWorkbook
            sheet = book.ActiveSheet
            'step through rows and columns and copy data to worksheet
            Dim row As Integer = 2
            Dim col As Integer = 1
            Dim c As Integer = 1
            Dim excel_array() As String = New String() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"} ', "Z", "AA"} ', "AB", "AC", "AD"}
            Dim excel_index As Integer = 1
            Dim iii As Integer = 0

            sheet.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange, sheet.Range("$A$1:$S$1"), , Excel.XlYesNoGuess.xlYes).Name = "Table1"

            '~~> Format the table
            sheet.ListObjects("Table1").TableStyle = "TableStyleLight9"

            sheet.Cells(1, 1) = "DATE ACQUIRED"
            sheet.Cells(1, 2) = "PLATE NO."
            sheet.Cells(1, 3) = "MODEL/BRAND"
            sheet.Cells(1, 4) = "SERIAL NO."
            sheet.Cells(1, 5) = "SUPPLIER"
            sheet.Cells(1, 6) = "ACQUISITION COST"
            sheet.Cells(1, 7) = "SCRAP/SALVAGE"
            sheet.Cells(1, 8) = "COST"
            sheet.Cells(1, 9) = "USEFUL LIFE(YRS.)"
            sheet.Cells(1, 10) = "USEFUL LIFE(MOS.)"
            sheet.Cells(1, 11) = "PER YEAR"
            sheet.Cells(1, 12) = "PER MONTH"
            sheet.Cells(1, 13) = "DEPRECIATED MONTH"
            sheet.Cells(1, 14) = "AMOUNT"
            sheet.Cells(1, 15) = "CUM A/D"
            sheet.Cells(1, 16) = "NET VAL"
            sheet.Cells(1, 17) = "REMAINING USEFUL LIFE"
            sheet.Cells(1, 18) = "AGE(UNIT)"
            sheet.Cells(1, 19) = "ASSESSMENT"

            'For Each item As ListViewItem In LVLEquipList.Items

            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Dim col1, row1 As Integer
            row1 = 2
            col1 = 1

            For i = 0 To DataGridView1.Rows.Count - 1

                'If dtgSummarySupply.Rows(i).Selected Then
                'For ii = 1 To 28
                '    sheet.Cells(row1, ii) = dtgSummarySupply.Rows(i).Cells(ii).Value
                '    ' sheet.Cells(row1, ii) = LVLEquipList.Items(i).SubItems(ii).Text
                '    col1 += 1
                'Next

                sheet.Cells(row1, 1) = DataGridView1.Rows(i).Cells("Column2").Value
                sheet.Cells(row1, 2) = DataGridView1.Rows(i).Cells("Column3").Value
                sheet.Cells(row1, 3) = DataGridView1.Rows(i).Cells("Column4").Value
                sheet.Cells(row1, 4) = DataGridView1.Rows(i).Cells("Column5").Value
                sheet.Cells(row1, 5) = DataGridView1.Rows(i).Cells("Column6").Value
                sheet.Cells(row1, 6) = DataGridView1.Rows(i).Cells("Column7").Value
                sheet.Cells(row1, 7) = DataGridView1.Rows(i).Cells("Column8").Value
                sheet.Cells(row1, 8) = DataGridView1.Rows(i).Cells("Column9").Value
                sheet.Cells(row1, 9) = DataGridView1.Rows(i).Cells("Column10").Value
                sheet.Cells(row1, 10) = DataGridView1.Rows(i).Cells("Column11").Value
                sheet.Cells(row1, 11) = DataGridView1.Rows(i).Cells("Column12").Value
                sheet.Cells(row1, 12) = DataGridView1.Rows(i).Cells("Column13").Value
                sheet.Cells(row1, 13) = DataGridView1.Rows(i).Cells("Column14").Value
                sheet.Cells(row1, 14) = DataGridView1.Rows(i).Cells("Column15").Value
                sheet.Cells(row1, 15) = DataGridView1.Rows(i).Cells("Column16").Value
                sheet.Cells(row1, 16) = DataGridView1.Rows(i).Cells("Column17").Value
                sheet.Cells(row1, 17) = DataGridView1.Rows(i).Cells("Column19").Value
                sheet.Cells(row1, 18) = DataGridView1.Rows(i).Cells("Column20").Value
                sheet.Cells(row1, 19) = DataGridView1.Rows(i).Cells("Column21").Value

                col1 += 1
                row1 += 1
                'Else

                'End If

                chartRange = sheet.Range(excel_array(0) & 1, excel_array(24) & 1)

                With chartRange

                    .HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter
                    .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    .Font.Size = 12
                    .Font.FontStyle = "Arial"
                    .EntireColumn.ColumnWidth = 15

                    .Borders(Excel.XlBordersIndex.xlEdgeLeft).Weight = 2
                    .Borders(Excel.XlBordersIndex.xlEdgeRight).Weight = 2
                    .Borders(Excel.XlBordersIndex.xlEdgeTop).Weight = 2
                    .Borders(Excel.XlBordersIndex.xlEdgeBottom).Weight = 2
                    'chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)

                    '.Range("F" & col1).Formula = "=(E" & col1 & "-D" & col1 & ")*24*60/60"
                    .EntireColumn.AutoFit()


                End With

            Next

            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            'save the workbook and clean up

            book.SaveAs(SaveFileDialog1.FileName)
            xls.Workbooks.Close()
            xls.Quit()
            releaseObject(sheet)
            releaseObject(book)
            releaseObject(xls)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub releaseObject(ByVal obj As Object)
        'Release an automation object
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint

    End Sub

    Private Sub exclusive_input()
        If FLogin.txtUsername.Text = "sheryl" Or FLogin.txtUsername.Text = "mc" Then
            'MsgBox(FLogin.txtUsername.Text)
            txt_acquired_date.ReadOnly = False
        Else
            txt_acquired_date.ReadOnly = True
        End If
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If FLogin.txtUsername.Text = "sheryl" Or FLogin.txtUsername.Text = "mc" Then
            MsgBox(FLogin.txtUsername.Text)
        Else
            MsgBox("username cant find")
        End If

    End Sub

    Private Sub GenerateCapitalInvestmentReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerateCapitalInvestmentReportToolStripMenuItem.Click


        Panel9.Visible = True
        'view_capital_investment_report()
    End Sub


    Public Sub view_capital_investment_report()
        Dim dt As New DataTable
        Dim dt2 As New DataTable

        With dt
            .Columns.Add("Id")
            .Columns.Add("EquipmentIDNo")
            .Columns.Add("PlateNo")
            .Columns.Add("YearAcquired")
            .Columns.Add("EstimatedUsefullLifeMos")
            .Columns.Add("DepreciatedUseFullLife")
            .Columns.Add("RemainingUseful")
            .Columns.Add("AcquisitionCost")
            .Columns.Add("AccumulatedDepreciation")
            .Columns.Add("NetValue")
            .Columns.Add("SalvageValue")
            .Columns.Add("EquipmentAge")
        End With

        For i As Integer = 0 To DataGridView1.Rows.Count - 1


            dt.Rows.Add(
        DataGridView1.Rows(i).Cells(0).Value.ToString(),
        DataGridView1.Rows(i).Cells(3).Value.ToString(),
        DataGridView1.Rows(i).Cells(2).Value.ToString(),
        DataGridView1.Rows(i).Cells(1).Value.ToString(),
        DataGridView1.Rows(i).Cells(10).Value.ToString(),
        DataGridView1.Rows(i).Cells(13).Value.ToString(),
        DataGridView1.Rows(i).Cells(18).Value.ToString(),
        DataGridView1.Rows(i).Cells(6).Value.ToString(),
        DataGridView1.Rows(i).Cells(15).Value.ToString(),
        DataGridView1.Rows(i).Cells(16).Value.ToString(),
        DataGridView1.Rows(i).Cells(7).Value.ToString(),
        DataGridView1.Rows(i).Cells(19).Value.ToString())
        Next


        With dt2
            .Columns.Add("Category")
            .Columns.Add("Type_of_Equipment")
            .Columns.Add("Equipment_Plate_No")
            .Columns.Add("Rental_Revenue")
            .Columns.Add("Repair")
            .Columns.Add("Maintenance")
            .Columns.Add("Fuel")
            .Columns.Add("Tires")
            .Columns.Add("Allowances")
            .Columns.Add("Salary_wages")
            .Columns.Add("Depreciation_Expense")
            .Columns.Add("Miscellaneous_Expense")
            .Columns.Add("Total_Cost")
            .Columns.Add("Net_Revenue")
            .Columns.Add("Net_Revenue_Without")

        End With

        For i As Integer = 0 To DataGridView2.Rows.Count - 1
            dt2.Rows.Add(
                DataGridView2.Rows(i).Cells(0).Value,
                DataGridView2.Rows(i).Cells(1).Value,
                DataGridView2.Rows(i).Cells(2).Value,
                DataGridView2.Rows(i).Cells(4).Value,
                DataGridView2.Rows(i).Cells(5).Value,
                DataGridView2.Rows(i).Cells(6).Value,
                DataGridView2.Rows(i).Cells(7).Value,
                DataGridView2.Rows(i).Cells(8).Value,
                DataGridView2.Rows(i).Cells(9).Value,
                DataGridView2.Rows(i).Cells(10).Value,
                DataGridView2.Rows(i).Cells(11).Value,
                DataGridView2.Rows(i).Cells(12).Value,
                DataGridView2.Rows(i).Cells(13).Value,
                DataGridView2.Rows(i).Cells(14).Value,
                DataGridView2.Rows(i).Cells(15).Value)
        Next

        Dim view As New DataView(dt)
        Dim view2 As New DataView(dt2)

        Equipment_Capital_Investment_ReportForm.ReportViewer1.LocalReport.DataSources.Item(0).Value = view
        Equipment_Capital_Investment_ReportForm.ReportViewer1.LocalReport.DataSources.Item(1).Value = view2
        Equipment_Capital_Investment_ReportForm.ShowDialog()
        Equipment_Capital_Investment_ReportForm.Dispose()
    End Sub


    Public Sub view_income_statement(cmbox As String)
        DataGridView2.Rows.Clear()
        Dim cmd As New SqlCommand
        Dim a(20) As String
        Try
            SQ.connection.Open()
            cmd.Connection = SQ.connection
            cmd.CommandText = "proc_equipment_monitoring"
            'cmd.Parameters.Clear()
            'cmd.Parameters.Add("@n", SqlDbType.Int)
            'cmd.Parameters("@n").Value = 10
            'cmd.Parameters.Add("@eq_type", SqlDbType.NVarChar)
            'cmd.Parameters("@eq_type").Value = cmb_equiptype.Text
            'cmd.Parameters.Add("@dateto", SqlDbType.DateTime)
            'cmd.Parameters("@dateto").Value = Date.Parse(eu_dateto)
            cmd.CommandType = CommandType.StoredProcedure
            If cmbox = "All Type" Then
                cmd.Parameters.AddWithValue("@n", 12)
            Else
                cmd.Parameters.AddWithValue("@n", 10)
                cmd.Parameters.AddWithValue("@eq_type", cmb_search_equiptype.Text)
            End If

            cmd.Parameters.AddWithValue("@datefrom", Date.Parse(DateTimePicker5.Text))
            cmd.Parameters.AddWithValue("@dateto", Date.Parse(DateTimePicker4.Text))
            cmd.Parameters.AddWithValue("@eq_cat", cmb_category.Text)

            cmd.CommandTimeout = 0
            dr = cmd.ExecuteReader
            While dr.Read
                If cmb_search_equiptype.Text = "Heavy Equipment" Then
                    a(0) = "Construction Equipment"
                Else
                    a(0) = cmb_search_equiptype.Text
                End If
                a(1) = dr.Item(0).ToString

                If cmbox = "All Type" Then
                    'a(2) = dr.Item(1).ToString
                    a(3) = dr.Item(1).ToString
                    a(4) = dr.Item(2).ToString
                    a(5) = dr.Item(3).ToString
                    a(6) = dr.Item(4).ToString
                    a(7) = dr.Item(5).ToString
                    a(8) = dr.Item(6).ToString
                    a(9) = dr.Item(7).ToString
                    a(19) = dr.Item(8).ToString
                    a(11) = dr.Item(9).ToString
                    a(12) = dr.Item(10).ToString
                    a(13) = dr.Item(11).ToString
                    a(14) = dr.Item(12).ToString
                Else
                    a(2) = dr.Item(1).ToString
                    a(3) = dr.Item(2).ToString
                    a(4) = dr.Item(3).ToString
                    a(5) = dr.Item(4).ToString
                    a(6) = dr.Item(5).ToString
                    a(7) = dr.Item(6).ToString
                    a(8) = dr.Item(7).ToString
                    a(9) = dr.Item(8).ToString
                    a(10) = dr.Item(9).ToString
                    a(11) = dr.Item(10).ToString
                    a(12) = dr.Item(11).ToString
                    a(13) = dr.Item(12).ToString
                    a(14) = dr.Item(13).ToString
                    a(15) = dr.Item(14).ToString
                    a(16) = dr.Item(15).ToString
                    a(17) = dr.Item(16).ToString
                End If
                DataGridView2.Rows.Add(a)

            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        Dim selectedYear As String = DateTimePicker4.Value.Year.ToString()
        Label19.Text = selectedYear



        If cmb_search_equiptype.Text = "" And cmb_search.Text = "Equipment Type" Then
            MessageBox.Show("Pls. select Equipment Type to proceed.", "Supply Info.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            view_income_statement(cmb_search.Text)
            view_capital_investment_report()
            'Panel3.Visible = False
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Panel9.Visible = False
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub
    'Sub last_three_remove()
    '    lvl_equipment_monitoring.Columns.RemoveAt(20)
    '    lvl_equipment_monitoring.Columns.RemoveAt(19)
    '    lvl_equipment_monitoring.Columns.RemoveAt(18)
    'End Sub
    'Sub last_three_column()

    '    Dim date_aquired As DateTime
    '    lvl_equipment_monitoring.Columns.Add("Remaining Useful Life", -2, HorizontalAlignment.Center)
    '    lvl_equipment_monitoring.Columns.Add("      Age(Unit)      ", -2, HorizontalAlignment.Center)
    '    lvl_equipment_monitoring.Columns.Add("     Assessment      ", -2, HorizontalAlignment.Center)
    '    For Each item As ListViewItem In lvl_equipment_monitoring.Items
    '        date_aquired = item.SubItems.Item(1).Text
    '        Dim rem_use As Integer = item.SubItems.Item(10).Text - (MonthDifference(date_aquired, Date.Now))
    '        Dim assessment As String = ""
    '        If rem_use < 0 Then
    '            rem_use = 0
    '            assessment = "Fully Depreciated"
    '        End If
    '        item.SubItems.Item(18).Text = rem_use
    '        item.SubItems.Item(19).Text = CInt((MonthDifference(date_aquired, Date.Now) / 12)) & " Yr/s & " & (MonthDifference(date_aquired, Date.Now) Mod 12) & " Mo/s"
    '        item.SubItems.Item(20).Text = assessment
    '    Next
    'End Sub

End Class