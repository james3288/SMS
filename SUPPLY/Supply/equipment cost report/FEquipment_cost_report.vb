Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Globalization
Imports Microsoft.Office.Interop
Public Class FEquipment_cost_report
    Public head As String
    Public eu_datefrom As DateTime
    Public eu_dateto As DateTime
    Public datefrom As DateTime
    Public dateto As DateTime
    Private Sub FEquipment_cost_report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel5.Visible = False
        Panel6.Visible = False
        Panel7.Visible = False
        cmb_equip_type.Enabled = False
        cmb_status.Enabled = False
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnExit_MouseDown(sender As Object, e As MouseEventArgs) Handles btnExit.MouseDown
        btnExit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_MouseEnter(sender As Object, e As EventArgs) Handles btnExit.MouseEnter
        btnExit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_MouseLeave(sender As Object, e As EventArgs) Handles btnExit.MouseLeave
        btnExit.BackgroundImage = My.Resources.close_button
    End Sub

    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        Panel5.Visible = False
        cmb_search.Enabled = True
        If cmb_search.Text = "All Type" Then
        Else
            cmb_equip_type.Enabled = True
        End If
    End Sub
    Public Sub equip_type(ByVal n As Integer)
        Dim sqLcon As New SQLcon
        Dim sqLcmd As SqlCommand
        Dim sqLdr As SqlDataReader
        cmb_equip_type.Items.Clear()

        Try
            sqLcon.connection.Open()
            sqLcmd = New SqlCommand("proc_equipment_cost_report", sqLcon.connection)
            sqLcmd.Parameters.Clear()
            sqLcmd.CommandType = CommandType.StoredProcedure
            sqLcmd.Parameters.AddWithValue("@n", n)
            sqLcmd.Parameters.AddWithValue("@equiptype", "")

            sqLdr = sqLcmd.ExecuteReader

            While sqLdr.Read
                cmb_equip_type.Items.Add(sqLdr.Item("equip_typeOf").ToString)
            End While

            sqLdr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & ex.StackTrace() & vbCrLf & "Info: " & ex.Message, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqLcon.connection.Close()
        End Try

    End Sub
    Private Sub cmb_search_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_search.SelectedIndexChanged

        If cmb_search.Text = "Equipment Type" Then
            cmb_equip_type.Enabled = True
            cmb_status.Enabled = True
            equip_type(4)
        Else
            'Panel5.Visible = True
            cmb_search.Enabled = False
            cmb_equip_type.Enabled = False
            cmb_status.Enabled = True
        End If

    End Sub

#Region "btn"
    Private Sub btn_exit_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_exit.MouseDown
        btn_exit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btn_exit_MouseEnter(sender As Object, e As EventArgs) Handles btn_exit.MouseEnter
        btn_exit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btn_exit_MouseLeave(sender As Object, e As EventArgs) Handles btn_exit.MouseLeave
        btn_exit.BackgroundImage = My.Resources.close_button
    End Sub
    Private Sub Button1_MouseDown(sender As Object, e As MouseEventArgs) Handles Button1.MouseDown
        Button1.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub Button1_MouseEnter(sender As Object, e As EventArgs) Handles Button1.MouseEnter
        Button1.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.BackgroundImage = My.Resources.close_button
    End Sub
#End Region
    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        datefrom = dtp_Start.Text
        dateto = dtp_End.Text
        eu_datefrom = eu_date_from.Text
        eu_dateto = eu_date_to.Text

        'MsgBox(datefrom)
        'MsgBox(dateto)

        If cmb_search.Text = "Equipment Type" Then

            If cmb_status.Text = "Reported Status - History" Then
                Label6.Text = "Equipment Monitoring Department Head"
                get_equipment_plateno(11)
                cmb_equip_type.Enabled = True

            ElseIf cmb_status.Text = "All" Then
                Label6.Text = "Equipment Monitoring Department Head"
                get_equipment_plateno(1)
                cmb_equip_type.Enabled = True
            End If

        ElseIf cmb_search.Text = "All Type" Then

            If cmb_status.Text = "Reported Status - History" Then
                Label6.Text = "Equipment Management Division Head"
                get_equipment_equipment_type_cost(22)
                cmb_equip_type.Enabled = False

            ElseIf cmb_status.Text = "All" Then
                Label6.Text = "Equipment Management Division Head"
                get_equipment_equipment_type_cost(2)
                cmb_equip_type.Enabled = False
            End If

        End If



        'If cmb_status.Text = "Reported Status - History" Then

        '    If cmb_search.Text = "Equipment Type" Then
        '        Label6.Text = "Equipment Monitoring Head"
        '        get_equipment_plateno(11)
        '        cmb_equip_type.Enabled = True

        '    ElseIf cmb_search.Text = "All Type" Then
        '        Label6.Text = "Equipment Management Division Head"
        '        get_equipment_equipment_type_cost(22)
        '        cmb_equip_type.Enabled = False
        '    End If

        'ElseIf cmb_status.Text = "All" Then

        '    If cmb_search.Text = "Equipment Type" Then
        '        Label6.Text = "Equipment Monitoring Head"
        '        get_equipment_plateno(1)
        '        cmb_equip_type.Enabled = True

        '    ElseIf cmb_search.Text = "All Type" Then
        '        Label6.Text = "Equipment Management Division Head"
        '        get_equipment_equipment_type_cost(2)
        '        cmb_equip_type.Enabled = False
        '    End If
        'End If

        Panel5.Visible = False
        cmb_search.Enabled = True

    End Sub
    Public Sub get_equipment_equipment_type_cost(ByVal n As Integer)

        lvl_costrecord.Items.Clear()

        Dim newsqlcon As New SQLcon
        Dim newcmd As SqlCommand
        Dim newdr As SqlDataReader

        Try
            newsqlcon.connection.Open()
            newcmd = New SqlCommand("proc_equipment_cost_report_all_type", newsqlcon.connection)
            newcmd.CommandTimeout = 0
            newcmd.Parameters.Clear()
            newcmd.CommandType = CommandType.StoredProcedure

            newcmd.Parameters.AddWithValue("@datefrom", Date.Parse(dtp_Start.Text))
            newcmd.Parameters.AddWithValue("@dateto", Date.Parse(dtp_End.Text))
            newcmd.Parameters.AddWithValue("@eudatefrom", Date.Parse(eu_datefrom))
            newcmd.Parameters.AddWithValue("@eudateto", Date.Parse(eu_dateto))
            newcmd.Parameters.AddWithValue("@n", n)

            newdr = newcmd.ExecuteReader

            While newdr.Read
                Dim a(20) As String

                a(0) = newdr.Item("EQUIPMENTTYPE_OF").ToString
                a(1) = newdr.Item("TRIPS").ToString
                a(2) = newdr.Item("RUN_HOURS").ToString
                a(3) = newdr.Item("REPAIR").ToString
                a(4) = newdr.Item("MAINTENANCE").ToString
                a(5) = newdr.Item("REHABILITATION").ToString

                'If newdr.Item("EQUIPMENTTYPE_OF").ToString = "FUEL TANKER" Then
                '    a(6) = newdr.Item("FUEL_FT").ToString
                '    'If dr.Item("FUEL_FT").ToString Is Nothing Then
                '    '    a(6) = dr.Item("FUEL_FT").ToString
                '    'Else
                '    '    a(6) = dr.Item("FUEL_NFT").ToString
                '    'End If
                'Else
                '    a(6) = FormatNumber(CDbl(newdr.Item("TOTAL_FUEL").ToString))
                'End If

                a(6) = FormatNumber(CDbl(newdr.Item("TOTAL_FUEL").ToString))

                a(7) = newdr.Item("TIRES").ToString
                a(8) = newdr.Item("ALLOWANCE").ToString
                a(9) = newdr.Item("SALARIES").ToString
                a(10) = newdr.Item("OTHERS").ToString

                If newdr.Item("all_total").ToString = "" Or newdr.Item("all_total").ToString = 0 Then
                    a(11) = "-"
                Else
                    a(11) = FormatNumber(CDbl(newdr.Item("all_total").ToString))
                End If


                Dim lvl As New ListViewItem(a)
                lvl_costrecord.Items.Add(lvl)

            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & ex.StackTrace() & vbCrLf & "Info: " & ex.Message, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
        End Try

    End Sub

    Public Sub get_equipment_plateno(ByVal n As Integer)
        'MsgBox(dtp_Start.Text)
        'MsgBox(dtp_End.Text)
        'MsgBox(dtp_Start.Text)
        'MsgBox(dtp_End.Text)

        'MsgBox(datefrom)
        'MsgBox(dateto)

        lvl_costrecord.Items.Clear()

        Dim sqlcon As New SQLcon
        Dim dr As SqlDataReader
        Dim cmd As SqlCommand


        Try
            sqlcon.connection.Open()
            cmd = New SqlCommand("proc_equipment_cost_report_all_type", sqlcon.connection)
            cmd.CommandTimeout = 0
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@datefrom", Date.Parse(dtp_Start.Text))
            cmd.Parameters.AddWithValue("@dateto", Date.Parse(dtp_End.Text))
            cmd.Parameters.AddWithValue("@eudatefrom", Date.Parse(eu_datefrom))
            cmd.Parameters.AddWithValue("@eudateto", Date.Parse(eu_dateto))
            cmd.Parameters.AddWithValue("@equiptype", cmb_equip_type.Text)
            cmd.Parameters.AddWithValue("@n", n)

            dr = cmd.ExecuteReader

            While dr.Read
                Dim a(20) As String

                a(0) = dr.Item("PLATE_NO").ToString
                a(1) = dr.Item("TRIPS").ToString
                a(2) = dr.Item("RUN_HOURS").ToString
                a(3) = dr.Item("REPAIR").ToString
                a(4) = dr.Item("MAINTENANCE").ToString
                a(5) = dr.Item("REHABILITATION").ToString


                'If cmb_status.Text = "ALL" Then
                'If dr.Item("EQUIPMENTTYPE_OF").ToString = "FUEL TANKER" Then
                '    a(6) = dr.Item("FUEL_FT").ToString
                'Else
                '    a(6) = dr.Item("TOTAL_FUEL").ToString
                'End If
                'Else
                '    'a(6) = dr.Item("TOTAL_FUEL").ToString
                'End If

                a(6) = dr.Item("TOTAL_FUEL").ToString

                'If dr.Item("EQUIPMENTTYPE_OF").ToString = "FUEL TANKER" Then
                '    a(6) = dr.Item("FUEL_FT").ToString
                '    'If dr.Item("FUEL_FT").ToString Is Nothing Then
                '    '    a(6) = dr.Item("FUEL_FT").ToString
                '    'Else
                '    '    a(6) = dr.Item("FUEL_NFT").ToString
                '    'End If
                'Else
                '    a(6) = dr.Item("FUEL_NFT").ToString
                'End If


                'If a(6) = 0.00 Then
                '    a(6) = "-"
                'Else

                'End If
                'kung zero ang isa ma.zero pud ang isa,
                'If a(4) = 0.00 Then
                '    a(4) = "-"
                'Else

                'End If

                a(7) = dr.Item("TIRES").ToString
                a(8) = dr.Item("ALLOWANCE").ToString
                a(9) = dr.Item("SALARIES").ToString
                a(10) = dr.Item("OTHERS").ToString

                If dr.Item("all_total").ToString = "" Or dr.Item("all_total").ToString = 0 Then
                    a(11) = "-"
                Else
                    a(11) = FormatNumber(CDbl(dr.Item("all_total").ToString))
                End If


                'If a(1) = 0 Or a(2) = 0 Or a(3) = 0 Or a(4) = 0 Or a(5) = 0 Or a(6) = 0 Or a(7) = 0 Or a(8) = 0 Or a(9) = 0 Then
                '    a(1) = "-"
                '    a(2) = "-"
                '    a(3) = "-"
                '    a(4) = "-"
                '    a(5) = "-"
                '    a(6) = "-"
                '    a(7) = "-"
                '    a(8) = "-"
                '    a(9) = "-"
                'Else

                'End If



                Dim lvl As New ListViewItem(a)
                lvl_costrecord.Items.Add(lvl)

            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & ex.StackTrace() & vbCrLf & "Info: " & ex.Message, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try

    End Sub

    Private Sub btn_preview_Click(sender As Object, e As EventArgs) Handles btn_preview.Click
        Panel6.Visible = True


        'If cmb_search.Text = "All Type" Then
        '    head = "Equipment Management Division Head"
        'ElseIf cmb_search.Text = "Equipment Type" Then
        '    head = "Equipment Monitoring Head"
        'End If


        txt_preparedby.Focus()
    End Sub
    Public Sub view_report()

        Dim dt As New DataTable

        With dt
            .Columns.Add("equipment")
            .Columns.Add("trips")
            .Columns.Add("run_hrs")
            .Columns.Add("repair")
            .Columns.Add("maintenance")
            .Columns.Add("rehabilitation")
            .Columns.Add("fuel")
            .Columns.Add("tires")
            .Columns.Add("allowances")
            .Columns.Add("salaries")
            .Columns.Add("others")
            .Columns.Add("total_cost")
            .Columns.Add("monthyear")
        End With

        For i As Integer = 0 To lvl_costrecord.Items.Count - 1
            dt.Rows.Add(
            lvl_costrecord.Items(i).SubItems(0).Text, lvl_costrecord.Items(i).SubItems(1).Text,
            lvl_costrecord.Items(i).SubItems(2).Text, lvl_costrecord.Items(i).SubItems(3).Text,
            lvl_costrecord.Items(i).SubItems(4).Text, lvl_costrecord.Items(i).SubItems(5).Text,
            lvl_costrecord.Items(i).SubItems(6).Text, lvl_costrecord.Items(i).SubItems(7).Text,
            lvl_costrecord.Items(i).SubItems(8).Text, lvl_costrecord.Items(i).SubItems(9).Text,
            lvl_costrecord.Items(i).SubItems(10).Text, lvl_costrecord.Items(i).SubItems(11).Text
            )
        Next

        Dim view As New DataView(dt)

        FEquipment_cost_report_viewer.ReportViewer1.LocalReport.DataSources.Item(0).Value = view
        FEquipment_cost_report_viewer.ShowDialog()
        FEquipment_cost_report_viewer.Dispose()

    End Sub
    Private Sub btn_proceed_Click(sender As Object, e As EventArgs) Handles btn_proceed.Click

        view_report()
        Panel6.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel6.Visible = False
    End Sub

#Region "Keydown"
    Private Sub dtp_Start_KeyDown(sender As Object, e As KeyEventArgs) Handles dtp_Start.KeyDown, dtp_End.KeyDown
        If e.KeyCode = Keys.Enter Then
            btn_search.PerformClick()
        End If
    End Sub
    Private Sub txt_preparedby_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_preparedby.KeyDown, txt_approvedby.KeyDown
        If e.KeyCode = Keys.Enter Then
            btn_proceed.PerformClick()
        End If
    End Sub

    Private Sub cmb_equip_type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_equip_type.SelectedIndexChanged

    End Sub

    Private Sub btn_reported_Click(sender As Object, e As EventArgs) Handles btn_reported.Click

        Dim result As Integer = MessageBox.Show("Do you want to proceed to REPORT UPDATE?", "STATUS", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.No Then
            MessageBox.Show("This transaction will not be reported!", "STATUS", MessageBoxButtons.OK)
        ElseIf result = DialogResult.Yes Then
            get_equipment_plateno(5) 'UPDATE REPORTED STATUS EU
            MessageBox.Show("Reported Status UPDATED!", "STATUS", MessageBoxButtons.OK)
        ElseIf result = DialogResult.Cancel Then

        End If

    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint
        'Dim date_start As DateTime = dtp_Start.Value
        'Dim date_end As DateTime = dtp_End.Value

    End Sub

    Private Sub cmb_status_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_status.SelectedIndexChanged
        If cmb_search.Text = "Equipment Type" Then

            Panel5.Visible = False
            Panel7.Visible = True

        ElseIf cmb_search.Text = "All Type" Then

            Panel5.Visible = False
            Panel7.Visible = True
        End If



    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        eu_datefrom = eu_date_from.Text
        eu_dateto = eu_date_to.Text  '----------------------------'

        Panel7.Visible = False
        Panel5.Visible = True

    End Sub

    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs) Handles Panel7.Paint
        'Dim eu_datefrom As DateTime = eu_date_from.Value
        'Dim eu_dateto As DateTime = eu_date_to.Value
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel7.Visible = False

        cmb_search.Enabled = True
    End Sub

    Private Sub ExportToExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        exportExcel()
    End Sub

    Private Sub exportExcel()
        SaveFileDialog1.Title = "Save Excel File"
        SaveFileDialog1.Filter = "Excel files (*.xls, *.xlsx)|*.xls;*.xlsx"
        SaveFileDialog1.FilterIndex = 2 ' Default to .xlsx format
        SaveFileDialog1.DefaultExt = ".xlsx"
        SaveFileDialog1.ShowDialog()
        'exit if no file selected
        If SaveFileDialog1.FileName = "" Then
            Exit Sub
        End If


        Dim xls As New Excel.Application
        Dim book As Excel.Workbook
        Dim sheet As Excel.Worksheet

        xls.Workbooks.Add()
        book = xls.ActiveWorkbook
        sheet = book.ActiveSheet

        Dim headerRange As Excel.Range = sheet.Range("A1:M1")
        headerRange.HorizontalAlignment = Excel.Constants.xlCenter
        headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#F8CBAD"))

        Dim dataRange As Excel.Range = sheet.Range("A1:M" & sheet.Rows.Count)
        dataRange.AutoFilter(1)

        sheet.Cells(1, 1) = "No."
        sheet.Cells(1, 2) = "EQUIPMENTS"
        sheet.Cells(1, 3) = "TRIPS"
        sheet.Cells(1, 4) = "RUN HOURS"
        sheet.Cells(1, 5) = "REPAIR"
        sheet.Cells(1, 6) = "MAINTENANCE"
        sheet.Cells(1, 7) = "REHABILITATION"
        sheet.Cells(1, 8) = "FUEL"
        sheet.Cells(1, 9) = "TIRES"
        sheet.Cells(1, 10) = "ALLOWANCES"
        sheet.Cells(1, 11) = "SALARY"
        sheet.Cells(1, 12) = "OTHERS"
        sheet.Cells(1, 13) = "TOTAL COST"

        Dim row1 As Integer = 2
        Dim rowNumbering As Integer = 1

        For Each item As ListViewItem In lvl_costrecord.Items



            sheet.Cells(row1, 1) = rowNumbering
            sheet.Cells(row1, 2) = item.SubItems(0).Text
            sheet.Cells(row1, 3) = item.SubItems(1).Text
            sheet.Cells(row1, 4) = item.SubItems(2).Text
            sheet.Cells(row1, 5) = item.SubItems(3).Text
            sheet.Cells(row1, 6) = item.SubItems(4).Text
            sheet.Cells(row1, 7) = item.SubItems(5).Text
            sheet.Cells(row1, 8) = item.SubItems(6).Text
            sheet.Cells(row1, 9) = item.SubItems(7).Text
            sheet.Cells(row1, 10) = item.SubItems(8).Text
            sheet.Cells(row1, 11) = item.SubItems(9).Text
            sheet.Cells(row1, 12) = item.SubItems(10).Text
            sheet.Cells(row1, 13) = item.SubItems(11).Text

            rowNumbering += 1
            row1 += 1

        Next


        book.SaveAs(SaveFileDialog1.FileName)
        xls.Workbooks.Close()
        xls.Quit()
        releaseObject(sheet)
        releaseObject(book)
        releaseObject(xls)
        MsgBox("Export Done", MsgBoxStyle.Information)
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk

    End Sub
#End Region
End Class