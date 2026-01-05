Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Globalization
Imports Microsoft.Office.Interop
Public Class FEquipment_history
    Public Sqlcon As New SQLcon
    Dim sqlcmd As SqlCommand
    Dim sqldr As SqlDataReader

    Private Sub FEquipment_history_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'get_plate_no()
        get_sub_desc()
        panel_date_reported.Visible = False

        For Each column As DataGridViewColumn In dtg_equipmentHistory.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

    End Sub

    'Public Sub Get_Category()
    '    If cmb_category.Text = "Equipment Type" Then
    '        get_equipment_type()
    '    Else
    '        get_plate_no()
    '    End If
    'End Sub

    Public Sub get_sub_desc()
        Dim newsql As New SQLcon
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand
        cmb_category.Items.Clear()

        Try
            newsql.connection.Open()
            publicquery = "SELECT tor_sub_desc FROM dbType_of_Request_sub WHERE tor_id = '2'"
            newcmd = New SqlCommand(publicquery, newsql.connection)
            newdr = newcmd.ExecuteReader
            While newdr.Read
                cmb_category.Items.Add(newdr.Item("tor_sub_desc").ToString)
            End While

            cmb_category.Items.Add("Equipment Type")
            cmb_category.Items.Add("All Category")
            newdr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & ex.StackTrace() & vbCrLf & "Info: " & ex.Message, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsql.connection.Close()
        End Try
    End Sub

    Public Sub get_plate_no()
        Dim sq1 As New SQLcon
        Dim sqdr As SqlDataReader
        'cmb_plate_no.Items.Clear()
        Try
            sq1.connection1.Open()
            publicquery = "SELECT DISTINCT plate_no FROM dbequipment_list ORDER BY plate_no ASC"
            sqlcmd = New SqlCommand(publicquery, sq1.connection1)
            sqdr = sqlcmd.ExecuteReader
            While sqdr.Read
                cmb_plate_no.Items.Add(sqdr.Item("plate_no").ToString)
            End While
            sqdr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & ex.StackTrace() & vbCrLf & "Info: " & ex.Message, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sq1.connection1.Close()
        End Try
    End Sub

    Public Sub get_equipment_type()
        Dim sq1 As New SQLcon
        Dim sqdr As SqlDataReader
        cmb_plate_no.Items.Clear()
        Try
            sq1.connection1.Open()
            publicquery = "SELECT DISTINCT equip_typeOf FROM dbequipment_type ORDER BY equip_typeOf ASC"
            sqlcmd = New SqlCommand(publicquery, sq1.connection1)
            sqdr = sqlcmd.ExecuteReader
            While sqdr.Read
                cmb_plate_no.Items.Add(sqdr.Item("equip_typeOf").ToString)
            End While
            sqdr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & ex.StackTrace() & vbCrLf & "Info: " & ex.Message, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sq1.connection1.Close()
        End Try
    End Sub

    Public Sub proc_dbfuelconsumptionreport_edited_viewing(ByVal searchby As Integer, ByVal plate_no As String, ByVal date_from As DateTime, ByVal date_to As DateTime)
        Dim sqlcon1 As New SQLcon
        Try
            sqlcon1.connection1.Open()
            sqlcmd = New SqlCommand("proc_dbfuelconsumptionreport_edited_viewing", sqlcon1.connection1)
            sqlcmd.Parameters.Clear()
            sqlcmd.CommandType = CommandType.StoredProcedure

            sqlcmd.Parameters.AddWithValue("@searchby", searchby)
            sqlcmd.Parameters.AddWithValue("@plateno", plate_no)
            sqlcmd.Parameters.AddWithValue("@date_from2", date_from)
            sqlcmd.Parameters.AddWithValue("@date_to2", date_to)

            sqldr = sqlcmd.ExecuteReader
            Dim a(15) As String
            While sqldr.Read

                a(0) = sqldr.Item("fuel_rep_id").ToString()
                a(1) = Format(Date.Parse(sqldr.Item("date_refuel").ToString), "MM/dd/yyyy")
                a(2) = "-"
                a(3) = "-"
                a(4) = "Refuel"
                a(5) = sqldr.Item("liters").ToString()
                a(6) = "ltrs."
                a(7) = "Fuel"
                a(8) = "Diesel Fuel"
                a(9) = sqldr.Item("operator").ToString()
                a(10) = sqldr.Item("po_ws_rr_no").ToString()
                a(11) = FormatNumber(sqldr.Item("amount").ToString(), 2, , , TriState.True)

                dtg_equipmentHistory.Rows.Add(a)

            End While
            sqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & ex.StackTrace() & vbCrLf & "Info: " & ex.Message, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon1.connection1.Close()
        End Try
    End Sub
    Public Sub get_history_fuel(value As String, plateno As String, datefrom As DateTime, dateto As DateTime)
        Dim newcmd As SqlCommand
        Dim newdr As SqlDataReader
        Try
            Sqlcon.connection.Open()
            newcmd = New SqlCommand("proc_dbequipment_history", Sqlcon.connection)
            newcmd.Parameters.Clear()
            newcmd.CommandType = CommandType.StoredProcedure

            newcmd.Parameters.AddWithValue("@n", 4)
            newcmd.Parameters.AddWithValue("@value", value)
            newcmd.Parameters.AddWithValue("@plateno", plateno)
            newcmd.Parameters.AddWithValue("@datefrom", datefrom)
            newcmd.Parameters.AddWithValue("@dateto", dateto)

            newdr = newcmd.ExecuteReader
            Dim b(15) As String
            While newdr.Read

                If check_if_exist("dbreceiving_items", "rs_id", newdr.Item("rs_id").ToString, 0 > 0) Or check_if_exist("dbwithdrawn_items", "rs_id", newdr.Item("rs_id").ToString, 0 > 0) Then

                    b(0) = newdr.Item("rs_id").ToString
                    b(1) = Format(Date.Parse(newdr.Item("date_req").ToString), "MM/dd/yyyy")
                    b(2) = newdr.Item("job_order_no").ToString
                    b(3) = "-"
                    b(4) = "-"
                    b(5) = newdr.Item("qty").ToString
                    b(6) = newdr.Item("unit").ToString
                    b(7) = "Fuel"
                    b(8) = newdr.Item("item_desc").ToString
                    b(9) = newdr.Item("requested_by").ToString
                    b(10) = newdr.Item("po_no").ToString
                    b(11) = newdr.Item("amount").ToString

                    dtg_equipmentHistory.Rows.Add(b)

                End If
            End While
            newdr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & ex.StackTrace() & vbCrLf & "Info: " & ex.Message, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sqlcon.connection.Close()
        End Try
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
        Me.Dispose()
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
    Private Sub cmb_plate_no_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_plate_no.SelectedIndexChanged
        'FEquipment_history_searchby_date.ShowDialog()
    End Sub

    Private Sub cmb_category_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_category.SelectedIndexChanged

        If cmb_category.Text = "Equipment Type" Then
            cmb_plate_no.Items.Clear()
            get_equipment_type()
            lbl_plateno.Text = "Type:"
            dtg_equipmentHistory.Columns("Column4").Visible = True
            dtg_equipmentHistory.Columns(4).HeaderCell.Value = "Plate No."
        Else
            cmb_plate_no.Items.Clear()
            get_plate_no()
            lbl_plateno.Text = "Plate #:"
            'dtg_equipmentHistory.Columns(4).HeaderCell.Value = "J.O. No."
            dtg_equipmentHistory.Columns("Column4").Visible = False
        End If

    End Sub

    Private Sub btn_preview_Click(sender As Object, e As EventArgs) Handles btn_preview.Click

        If cmb_status.Text = "Reported Status" Then
            view_report()
            panel_date_reported.Visible = False
        Else
            panel_date_reported.Visible = True
        End If

        'panel_date_reported.Visible = True

    End Sub
    Public Sub update_report_status_equipment()
        Dim dateFrom As DateTime
        Dim dateTo As DateTime

        With FEquipment_history_searchby_date
            dateFrom = .dtp_from.Value
            dateTo = .dtp_to.Value

        End With


        If cmb_category.Text = "Allowances" Then

            Try
                Sqlcon.connection.Open()
                sqlcmd = New SqlCommand("sp_crud_Allowance", Sqlcon.connection)
                sqlcmd.Parameters.Clear()
                sqlcmd.CommandType = CommandType.StoredProcedure
                sqlcmd.CommandTimeout = 0
                sqlcmd.Parameters.AddWithValue("@from_date", Format(Date.Parse(dateFrom), "MM/dd/yyyy"))
                sqlcmd.Parameters.AddWithValue("@to_date", Format(Date.Parse(dateTo), "MM/dd/yyyy"))
                sqlcmd.Parameters.AddWithValue("@plateno", cmb_plate_no.Text)
                sqlcmd.Parameters.AddWithValue("@datereported", Format(Date.Parse(dtp_reported.Value), "MM/dd/yyyy"))
                sqlcmd.Parameters.AddWithValue("@n", 881)

                sqlcmd.ExecuteNonQuery()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & "error: " & Err.Description, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Sqlcon.connection.Close()
            End Try


        ElseIf cmb_category.Text = "Salaries" Then

            Try
                Sqlcon.connection.Open()
                sqlcmd = New SqlCommand("sp_crud_Allowance", Sqlcon.connection)
                sqlcmd.Parameters.Clear()
                sqlcmd.CommandType = CommandType.StoredProcedure
                sqlcmd.CommandTimeout = 0
                sqlcmd.Parameters.AddWithValue("@from_date", Format(Date.Parse(dateFrom), "MM/dd/yyyy"))
                sqlcmd.Parameters.AddWithValue("@to_date", Format(Date.Parse(dateTo), "MM/dd/yyyy"))
                sqlcmd.Parameters.AddWithValue("@plateno", cmb_plate_no.Text)
                sqlcmd.Parameters.AddWithValue("@datereported", Format(Date.Parse(dtp_reported.Value), "MM/dd/yyyy"))
                sqlcmd.Parameters.AddWithValue("@n", 377)

                sqlcmd.ExecuteNonQuery()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & "error: " & Err.Description, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Sqlcon.connection.Close()
            End Try
        ElseIf cmb_category.Text = "Fuel" Then

            Try
                Sqlcon.connection.Open()
                sqlcmd = New SqlCommand("proc_dbequipment_history", Sqlcon.connection)
                sqlcmd.Parameters.Clear()
                sqlcmd.CommandType = CommandType.StoredProcedure
                sqlcmd.CommandTimeout = 0
                sqlcmd.Parameters.AddWithValue("@plateno", cmb_plate_no.Text)
                sqlcmd.Parameters.AddWithValue("@category", cmb_category.Text)
                sqlcmd.Parameters.AddWithValue("@datefrom", Format(Date.Parse(dateFrom), "MM/dd/yyyy"))
                sqlcmd.Parameters.AddWithValue("@dateto", Format(Date.Parse(dateTo), "MM/dd/yyyy"))
                sqlcmd.Parameters.AddWithValue("@datereported", Format(Date.Parse(dtp_reported.Value), "MM/dd/yyyy"))
                sqlcmd.Parameters.AddWithValue("@n", 101)

                sqlcmd.ExecuteNonQuery()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & "error: " & Err.Description, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Sqlcon.connection.Close()
            End Try

        ElseIf cmb_category.Text = "Repair" Then

            Try
                Sqlcon.connection.Open()
                sqlcmd = New SqlCommand("proc_dbequipment_history", Sqlcon.connection)
                sqlcmd.Parameters.Clear()
                sqlcmd.CommandType = CommandType.StoredProcedure
                sqlcmd.CommandTimeout = 0
                sqlcmd.Parameters.AddWithValue("@plateno", cmb_plate_no.Text)
                sqlcmd.Parameters.AddWithValue("@category", cmb_category.Text)
                sqlcmd.Parameters.AddWithValue("@datefrom", Format(Date.Parse(dateFrom), "MM/dd/yyyy"))
                sqlcmd.Parameters.AddWithValue("@dateto", Format(Date.Parse(dateTo), "MM/dd/yyyy"))
                sqlcmd.Parameters.AddWithValue("@datereported", Format(Date.Parse(dtp_reported.Value), "MM/dd/yyyy"))
                sqlcmd.Parameters.AddWithValue("@n", 201)

                sqlcmd.ExecuteNonQuery()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & "error: " & Err.Description, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Sqlcon.connection.Close()
            End Try

        ElseIf cmb_category.Text = "All Category" Then

            Try
                Sqlcon.connection.Open()
                sqlcmd = New SqlCommand("proc_dbequipment_history", Sqlcon.connection)
                sqlcmd.Parameters.Clear()
                sqlcmd.CommandType = CommandType.StoredProcedure
                sqlcmd.CommandTimeout = 0
                sqlcmd.Parameters.AddWithValue("@plateno", cmb_plate_no.Text)
                sqlcmd.Parameters.AddWithValue("@category", cmb_category.Text)
                sqlcmd.Parameters.AddWithValue("@datefrom", Format(Date.Parse(dateFrom), "MM/dd/yyyy"))
                sqlcmd.Parameters.AddWithValue("@dateto", Format(Date.Parse(dateTo), "MM/dd/yyyy"))
                sqlcmd.Parameters.AddWithValue("@datereported", Format(Date.Parse(dtp_reported.Value), "MM/dd/yyyy"))
                sqlcmd.Parameters.AddWithValue("@n", 501)

                sqlcmd.ExecuteNonQuery()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & "error: " & Err.Description, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Sqlcon.connection.Close()
            End Try

        Else

            Try
                Sqlcon.connection.Open()
                sqlcmd = New SqlCommand("proc_dbequipment_history", Sqlcon.connection)
                sqlcmd.Parameters.Clear()
                sqlcmd.CommandType = CommandType.StoredProcedure
                sqlcmd.CommandTimeout = 0
                sqlcmd.Parameters.AddWithValue("@plateno", cmb_plate_no.Text)
                sqlcmd.Parameters.AddWithValue("@category", cmb_category.Text)
                sqlcmd.Parameters.AddWithValue("@datefrom", Format(Date.Parse(dateFrom), "MM/dd/yyyy"))
                sqlcmd.Parameters.AddWithValue("@dateto", Format(Date.Parse(dateTo), "MM/dd/yyyy"))
                sqlcmd.Parameters.AddWithValue("@datereported", Format(Date.Parse(dtp_reported.Value), "MM/dd/yyyy"))
                sqlcmd.Parameters.AddWithValue("@n", 301)

                sqlcmd.ExecuteNonQuery()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & "error: " & Err.Description, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Sqlcon.connection.Close()
            End Try

        End If

    End Sub

    Public Sub view_report()

        Dim dt As New DataTable

        With dt
            .Columns.Add("date")
            .Columns.Add("rs_no")
            .Columns.Add("category")
            .Columns.Add("plate_no")
            .Columns.Add("jo_no")
            .Columns.Add("conducted_by")
            .Columns.Add("work_problems_details")
            .Columns.Add("qty")
            .Columns.Add("unit")
            .Columns.Add("item_name")
            .Columns.Add("description")
            .Columns.Add("requestor")
            .Columns.Add("po_no")
            .Columns.Add("amount")

        End With

        For i As Integer = 0 To dtg_equipmentHistory.Rows.Count - 1
            dt.Rows.Add(
            dtg_equipmentHistory.Rows(i).Cells(1).Value, dtg_equipmentHistory.Rows(i).Cells(2).Value,
            dtg_equipmentHistory.Rows(i).Cells(3).Value, dtg_equipmentHistory.Rows(i).Cells(4).Value,
            dtg_equipmentHistory.Rows(i).Cells(5).Value, dtg_equipmentHistory.Rows(i).Cells(6).Value,
            dtg_equipmentHistory.Rows(i).Cells(7).Value, dtg_equipmentHistory.Rows(i).Cells(8).Value,
            dtg_equipmentHistory.Rows(i).Cells(9).Value, dtg_equipmentHistory.Rows(i).Cells(10).Value,
            dtg_equipmentHistory.Rows(i).Cells(11).Value, dtg_equipmentHistory.Rows(i).Cells(12).Value,
            dtg_equipmentHistory.Rows(i).Cells(13).Value, dtg_equipmentHistory.Rows(i).Cells(14).Value
            )
        Next

        Dim view As New DataView(dt)

        If cmb_category.Text = "Equipment Type" Then
            FReport.ReportViewer3.LocalReport.DataSources.Item(0).Value = view
            FReport.ShowDialog()
            FReport.Dispose()
        Else
            FReport_Old.ReportViewer1.LocalReport.DataSources.Item(0).Value = view
            FReport_Old.ShowDialog()
            FReport_Old.Dispose()
        End If

    End Sub

    Private Sub dtg_equipmentHistory_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub SplitContainer1_Panel1_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel1.Paint

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub cmb_status_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_status.SelectedIndexChanged
        FEquipment_history_searchby_date.ShowDialog()
    End Sub

    Private Sub TableLayoutPanel3_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim result As Integer = MessageBox.Show("Do you want to proceed to REPORT UPDATE?", "STATUS", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.No Then
            MessageBox.Show("This transaction will not be reported!", "STATUS", MessageBoxButtons.OK)
        ElseIf result = DialogResult.Yes Then
            update_report_status_equipment()
            MessageBox.Show("Reported Status UPDATED!", "STATUS", MessageBoxButtons.OK)
        ElseIf result = DialogResult.Cancel Then

        End If

        view_report()

        panel_date_reported.Visible = False

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        panel_date_reported.Visible = False
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

        Dim headerRange As Excel.Range = sheet.Range("A1:O1")
        headerRange.HorizontalAlignment = Excel.Constants.xlCenter
        headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#F8CBAD"))

        Dim dataRange As Excel.Range = sheet.Range("A1:O" & sheet.Rows.Count)
        dataRange.AutoFilter(1)

        sheet.Cells(1, 1) = "No."
        sheet.Cells(1, 2) = "DATE"
        sheet.Cells(1, 3) = "RS NO."
        sheet.Cells(1, 4) = "CATEGORY"
        sheet.Cells(1, 5) = "JO NO."
        sheet.Cells(1, 6) = "CONDUCTED BY"
        sheet.Cells(1, 7) = "WORK/PROBLEM"
        sheet.Cells(1, 8) = "QTY"
        sheet.Cells(1, 9) = "UNIT"
        sheet.Cells(1, 10) = "ITEM NAME"
        sheet.Cells(1, 11) = "ITEM DESCRIPTION"
        sheet.Cells(1, 12) = "REQUESTOR"
        sheet.Cells(1, 13) = "PO NO."
        sheet.Cells(1, 14) = "AMOUNT"
        sheet.Cells(1, 15) = "TYPE OF PURCHASING"

        Dim row1 As Integer = 2
        Dim rowNumbering As Integer = 1

        For Each row As DataGridViewRow In dtg_equipmentHistory.Rows

            sheet.Cells(row1, 1) = rowNumbering
            Dim dateString4 As String = If(row.Cells(1).Value IsNot Nothing, row.Cells(1).Value.ToString(), "")
            If Not String.IsNullOrEmpty(dateString4) Then
                Dim dateValue4 As DateTime
                If DateTime.TryParseExact(dateString4, "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, dateValue4) Then
                    sheet.Cells(row1, 2).Value = dateValue4
                Else
                End If
            Else
            End If
            sheet.Cells(row1, 3) = row.Cells(2).Value.ToString()
            sheet.Cells(row1, 4) = row.Cells(3).Value.ToString()

            sheet.Cells(row1, 5) = row.Cells(5).Value.ToString()
            sheet.Cells(row1, 6) = row.Cells(6).Value.ToString()
            sheet.Cells(row1, 7) = row.Cells(7).Value.ToString()
            sheet.Cells(row1, 8) = row.Cells(8).Value.ToString()
            sheet.Cells(row1, 9) = row.Cells(9).Value.ToString()
            sheet.Cells(row1, 10) = row.Cells(10).Value.ToString()
            sheet.Cells(row1, 11) = row.Cells(11).Value.ToString()
            sheet.Cells(row1, 12) = row.Cells(12).Value.ToString()
            sheet.Cells(row1, 13) = row.Cells(13).Value.ToString()
            sheet.Cells(row1, 14) = row.Cells(14).Value.ToString()
            sheet.Cells(row1, 15) = row.Cells(4).Value.ToString()

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
End Class