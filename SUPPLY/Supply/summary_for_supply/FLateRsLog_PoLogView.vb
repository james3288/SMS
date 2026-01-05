Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Globalization
Imports Microsoft.Office.Interop
Public Class FLateRsLog_PoLogView
    Public sqlcon As New SQLcon
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim rowind As Integer
    Dim copy_string As String
    Dim casual_factor As String = ""
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub FLateRsLog_PoLogView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_late_rs_logs()
    End Sub

    Public Function get_datagrid_rowindex() As Integer

        For i As Integer = 0 To Me.DataGridView1.SelectedCells.Count - 1
            get_datagrid_rowindex = Me.DataGridView1.SelectedCells.Item(i).RowIndex
        Next
    End Function

    Private Sub btnSearch2_Click(sender As Object, e As EventArgs) Handles btnSearch2.Click

        If cmbSearch.Text = "Rs No." Then
            If TextBox2.Text = "" Then
                load_late_rs_logs()
            Else
                get_rs_no()
            End If

        Else

        End If
    End Sub

    Public Sub get_rs_no()
        DataGridView1.Rows.Clear()
        Dim increment_no As Integer = 1
        DataGridView1.Columns(9).DefaultCellStyle.BackColor = Color.LightBlue


        Try
            sqlcon.connection.Open()
            cmd = New SqlCommand("sp_supplier_evaluation", sqlcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandTimeout = 0
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@rs_date_log_from", Format(Date.Parse(date_log_range.rs_log_from.Value), "MM/dd/yyyy"))
            'cmd.Parameters.AddWithValue("@rs_date_log_to", Format(Date.Parse(date_log_range.rs_log_to.Value), "MM/dd/yyyy"))
            'cmd.Parameters.AddWithValue("@po_date_log_from", Format(Date.Parse(date_log_range.po_log_from.Value), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@po_date_log_to", Format(Date.Parse(date_log_range.po_log_to.Value), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@rs_no", TextBox2.Text)

            cmd.Parameters.AddWithValue("@n", 1011) 'SA PROJECT
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                Dim row As New DataGridViewRow()
                DataGridView1.Rows.Add(
                    dr("rs_id").ToString,
                    increment_no.ToString,
                dr("REQUEST").ToString,
                dr("type_name").ToString,
                dr("rs_no").ToString,
                dr("CHARGES").ToString,
                dr("WH_ITEM_NAME").ToString,
                dr("RS_ITEM_DESCRIPTION").ToString,
                dr("requested_by").ToString,
                dr("CASUAL_FACTORS").ToString,
                dr("RS_DATE_LOG").ToString,
                dr("PO_DATE_LOG").ToString,
                dr("days_difference").ToString
            )
                increment_no = increment_no + 1
            End While
            dr.Close()

            cmd.Parameters("@n").Value = 1012 'SA EQUIPMENT
            dr = cmd.ExecuteReader()
            While dr.Read()
                Dim row As New DataGridViewRow()
                DataGridView1.Rows.Add(
                    dr("rs_id").ToString,
                    increment_no.ToString,
                dr("REQUEST").ToString,
                dr("type_name").ToString,
                dr("rs_no").ToString,
                dr("CHARGES").ToString,
                dr("WH_ITEM_NAME").ToString,
                dr("RS_ITEM_DESCRIPTION").ToString,
                dr("requested_by").ToString,
                dr("CASUAL_FACTORS").ToString,
                dr("RS_DATE_LOG").ToString,
                dr("PO_DATE_LOG").ToString,
                dr("days_difference").ToString
            )
                increment_no = increment_no + 1
            End While
            dr.Close()

            cmd.Parameters("@n").Value = 1013  ' SA OTHERS
            dr = cmd.ExecuteReader()
            While dr.Read()
                Dim row As New DataGridViewRow()
                DataGridView1.Rows.Add(
                    dr("rs_id").ToString,
                    increment_no.ToString,
                dr("REQUEST").ToString,
                dr("tor_sub_desc").ToString,
                dr("rs_no").ToString,
                dr("CHARGES").ToString,
                dr("WH_ITEM_NAME").ToString,
                dr("RS_ITEM_DESCRIPTION").ToString,
                dr("requested_by").ToString,
                dr("CASUAL_FACTORS").ToString,
                dr("RS_DATE_LOG").ToString,
                dr("PO_DATE_LOG").ToString,
                dr("days_difference").ToString
            )
                increment_no = increment_no + 1
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        Finally
            sqlcon.connection.Close()
        End Try
    End Sub


    Private Sub load_late_rs_logs() 'for now PROJECT SA'
        DataGridView1.Rows.Clear()
        Dim increment_no As Integer = 1
        DataGridView1.Columns(9).DefaultCellStyle.BackColor = Color.LightBlue


        Try
            SQLcon.connection.Open()
            cmd = New SqlCommand("sp_supplier_evaluation", sqlcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandTimeout = 0
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@rs_date_log_from", Format(Date.Parse(date_log_range.rs_log_from.Value), "MM/dd/yyyy"))
            'cmd.Parameters.AddWithValue("@rs_date_log_to", Format(Date.Parse(date_log_range.rs_log_to.Value), "MM/dd/yyyy"))
            'cmd.Parameters.AddWithValue("@po_date_log_from", Format(Date.Parse(date_log_range.po_log_from.Value), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@po_date_log_to", Format(Date.Parse(date_log_range.po_log_to.Value), "MM/dd/yyyy"))

            cmd.Parameters.AddWithValue("@n", 10144) 'SA PROJECT
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                Dim row As New DataGridViewRow()
                DataGridView1.Rows.Add(
                    dr("rs_id").ToString,
                    increment_no.ToString,
                dr("REQUEST").ToString,
                dr("type_name").ToString,
                dr("rs_no").ToString,
                dr("CHARGES").ToString,
                dr("WH_ITEM_NAME").ToString,
                dr("RS_ITEM_DESCRIPTION").ToString,
                dr("requested_by").ToString,
                dr("CASUAL_FACTORS").ToString,
                dr("RS_DATE_LOG").ToString,
                dr("PO_DATE_LOG").ToString,
                dr("days_difference").ToString
            )
                increment_no = increment_no + 1
            End While
            dr.Close()

            cmd.Parameters("@n").Value = 10155 'SA EQUIPMENT
            dr = cmd.ExecuteReader()
            While dr.Read()
                Dim row As New DataGridViewRow()
                DataGridView1.Rows.Add(
                    dr("rs_id").ToString,
                    increment_no.ToString,
                dr("REQUEST").ToString,
                dr("type_name").ToString,
                dr("rs_no").ToString,
                dr("CHARGES").ToString,
                dr("WH_ITEM_NAME").ToString,
                dr("RS_ITEM_DESCRIPTION").ToString,
                dr("requested_by").ToString,
                dr("CASUAL_FACTORS").ToString,
                dr("RS_DATE_LOG").ToString,
                dr("PO_DATE_LOG").ToString,
                dr("days_difference").ToString
            )
                increment_no = increment_no + 1
            End While
            dr.Close()

            cmd.Parameters("@n").Value = 10166  ' SA OTHERS
            dr = cmd.ExecuteReader()
            While dr.Read()
                Dim row As New DataGridViewRow()
                DataGridView1.Rows.Add(
                    dr("rs_id").ToString,
                    increment_no.ToString,
                dr("REQUEST").ToString,
                dr("tor_sub_desc").ToString,
                dr("rs_no").ToString,
                dr("CHARGES").ToString,
                dr("WH_ITEM_NAME").ToString,
                dr("RS_ITEM_DESCRIPTION").ToString,
                dr("requested_by").ToString,
                dr("CASUAL_FACTORS").ToString,
                dr("RS_DATE_LOG").ToString,
                dr("PO_DATE_LOG").ToString,
                dr("days_difference").ToString
            )
                increment_no = increment_no + 1
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub

    Private Sub cmbSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearch.SelectedIndexChanged
        If cmbSearch.Text = "Rs No." Then
            Label1.Text = "Rs No."
        ElseIf cmbSearch.Text = "Charges" Then
            Label1.Text = "Charges"
        ElseIf cmbSearch.Text = "Item" Then
            Label1.Text = "Item"
        End If
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        export_late_to_excel()
        'CODE FOR COPY
        'rowind = Format(get_datagrid_rowindex)
        'copy_string = DataGridView1.Rows(rowind).Cells("Column20").Value
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'CODE FOR PASTE
        'For Each row As DataGridViewRow In DataGridView1.SelectedRows
        '    row.Cells("Column20").Value = copy_string
        'Next
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        'For Each row As DataGridViewRow In DataGridView1.Rows
        '    If Not row.IsNewRow Then
        '        Dim value As String = row.Cells(0).Selected.ToString()
        '        MsgBox(value)
        '    End If
        'Next
    End Sub

    Private Sub IdToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'CODE FOR GETTING ID OF DATAGRIDVIEW
        'Dim first_category As String = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
        'MsgBox(first_category)
    End Sub

    Private Sub DataGridView1_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellLeave
        'Dim var_rs_id As String = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
        'Dim cas_sample = DataGridView1.SelectedRows(0).Cells(9).Value.ToString()

        Try


            'Dim var_rs_id As String = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
            'For Each row As DataGridViewRow In DataGridView1.SelectedRows
            '    If row.Cells(0).Value = var_rs_id Then
            '        MsgBox(row.Cells(9).Value)
            '    End If
            'Next

            'Dim cas_sample As String = ""
            'MsgBox("rs_id" + var_rs_id + "casual:" + cas_sample)
            'sqlcon.connection.Open()
            'Dim sqlcomm As New SqlCommand

            'sqlcomm.Connection = sqlcon.connection
            'sqlcomm.CommandText = "proc_progress_report_data"
            'sqlcomm.CommandType = CommandType.StoredProcedure
            'sqlcomm.Parameters.AddWithValue("@n", 110)
            'sqlcomm.Parameters.AddWithValue("@rs_ids", var_rs_id)
            'sqlcomm.Parameters.AddWithValue("@casual_factor", cas_sample)
            'sqlcomm.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try
        'MsgBox(var_rs_id)
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        If e.ColumnIndex = 9 Then
            ' Retrieve the new value
            Dim newValue As Object = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            Dim ids As Object = DataGridView1.Rows(e.RowIndex).Cells(0).Value
            If newValue Is Nothing OrElse newValue.ToString() = String.Empty Then
                casual_factor = ""
                Dim selectedValues As New List(Of String)()
                For Each row As DataGridViewRow In DataGridView1.SelectedRows
                    Dim cellValue As Object = row.Cells(0).Value
                    Dim cellValueStr As String = If(cellValue Is Nothing OrElse cellValue.ToString() = String.Empty, "empty", cellValue.ToString())
                    selectedValues.Add(cellValueStr)
                Next

                Try
                    Dim var_rs_id As String = ids.ToString()
                    sqlcon.connection.Open()
                    Dim sqlcomm As New SqlCommand

                    sqlcomm.Connection = sqlcon.connection
                    sqlcomm.CommandText = "proc_progress_report_data"
                    sqlcomm.CommandType = CommandType.StoredProcedure
                    sqlcomm.Parameters.AddWithValue("@n", 110)
                    sqlcomm.Parameters.AddWithValue("@rs_ids", var_rs_id)
                    sqlcomm.Parameters.AddWithValue("@casual_factor", casual_factor)
                    sqlcomm.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    sqlcon.connection.Close()
                End Try
            Else
                casual_factor = newValue.ToString()
                Dim selectedValues As New List(Of String)()
                For Each row As DataGridViewRow In DataGridView1.SelectedRows
                    Dim cellValue As Object = row.Cells(0).Value
                    Dim cellValueStr As String = If(cellValue Is Nothing OrElse cellValue.ToString() = String.Empty, "empty", cellValue.ToString())
                    selectedValues.Add(cellValueStr)
                Next
                Dim var_rs_id As String = ids.ToString()

                Try
                    sqlcon.connection.Open()
                    Dim sqlcomm As New SqlCommand

                    sqlcomm.Connection = sqlcon.connection
                    sqlcomm.CommandText = "proc_progress_report_data"
                    sqlcomm.CommandType = CommandType.StoredProcedure
                    sqlcomm.Parameters.AddWithValue("@n", 110)
                    sqlcomm.Parameters.AddWithValue("@rs_ids", var_rs_id)
                    sqlcomm.Parameters.AddWithValue("@casual_factor", casual_factor)
                    sqlcomm.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    sqlcon.connection.Close()
                End Try
            End If
        End If
    End Sub

    Public Sub export_late_to_excel()
        SaveFileDialog1.Title = "Save Excel File"
        SaveFileDialog1.Filter = "Excel files (*.xls, *.xlsx)|*.xls;*.xlsx"
        SaveFileDialog1.FilterIndex = 2 ' Default to .xlsx format
        SaveFileDialog1.DefaultExt = ".xlsx"
        SaveFileDialog1.ShowDialog()
        'exit if no file selected
        If SaveFileDialog1.FileName = "" Then
            Exit Sub
        End If
        'create objects to interface to Excel
        Dim xls As New Excel.Application
        Dim book As Excel.Workbook
        Dim sheet As Excel.Worksheet
        'create a workbook and get reference to first worksheet
        xls.Workbooks.Add()
        book = xls.ActiveWorkbook
        sheet = book.ActiveSheet
        'step through rows and columns and copy data to worksheet

        Dim headerRange As Excel.Range = sheet.Range("A1:L1")
        headerRange.HorizontalAlignment = Excel.Constants.xlCenter
        headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(&H82B1FF))
        Dim dataRange As Excel.Range = sheet.Range("A1:L" & sheet.Rows.Count)
        dataRange.AutoFilter(1)

        sheet.Cells(1, 1) = "NO."
        sheet.Cells(1, 2) = "REQUEST"
        sheet.Cells(1, 3) = "CATEGORY"
        sheet.Cells(1, 4) = "RS NO"
        sheet.Cells(1, 5) = "CHARGES"
        sheet.Cells(1, 6) = "ITEM"
        sheet.Cells(1, 7) = "ITEM DESCRIPTION"
        sheet.Cells(1, 8) = "REQUESTOR"
        sheet.Cells(1, 9) = "CASUAL FACTOR"
        sheet.Cells(1, 10) = "RS LOG DATE"
        sheet.Cells(1, 11) = "PO LOG DATE"
        sheet.Cells(1, 12) = "NO. OF DAYS DELAYED"

        Dim row1 As Integer = 2

        For Each rows As DataGridViewRow In DataGridView1.Rows
            If rows.Cells(1).Value IsNot Nothing Then sheet.Cells(row1, 1) = rows.Cells(1).Value.ToString()
            If rows.Cells(2).Value IsNot Nothing Then sheet.Cells(row1, 2) = rows.Cells(2).Value.ToString()
            If rows.Cells(3).Value IsNot Nothing Then sheet.Cells(row1, 3) = rows.Cells(3).Value.ToString()
            If rows.Cells(4).Value IsNot Nothing Then sheet.Cells(row1, 4) = rows.Cells(4).Value.ToString()
            If rows.Cells(5).Value IsNot Nothing Then sheet.Cells(row1, 5) = rows.Cells(5).Value.ToString()
            If rows.Cells(6).Value IsNot Nothing Then sheet.Cells(row1, 6) = rows.Cells(6).Value.ToString()
            If rows.Cells(7).Value IsNot Nothing Then sheet.Cells(row1, 7) = rows.Cells(7).Value.ToString()
            If rows.Cells(8).Value IsNot Nothing Then sheet.Cells(row1, 8) = rows.Cells(8).Value.ToString()
            If rows.Cells(9).Value IsNot Nothing Then sheet.Cells(row1, 9) = rows.Cells(9).Value.ToString()

            Dim formattedDate As String
            If rows.Cells(10).Value IsNot Nothing Then formattedDate = Format(CDate(rows.Cells(10).Value.ToString()), "MM-dd-yyyy hh:mm AM/PM")
            sheet.Cells(row1, 10) = formattedDate

            Dim formattedDate2 As String
            If rows.Cells(11).Value IsNot Nothing Then formattedDate2 = Format(CDate(rows.Cells(11).Value.ToString()), "MM-dd-yyyy hh:mm AM/PM")
            sheet.Cells(row1, 11) = formattedDate2
            If rows.Cells(12).Value IsNot Nothing Then sheet.Cells(row1, 12) = rows.Cells(12).Value.ToString()
            row1 += 1
        Next

        'save the workbook and clean up
        book.SaveAs(SaveFileDialog1.FileName)
        xls.Workbooks.Close()
        xls.Quit()
        releaseObject(sheet)
        releaseObject(book)
        releaseObject(xls)
        MsgBox("EXPORTING DONE!")
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

    Private Sub DataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        Dim txtEdit As TextBox = CType(e.Control, TextBox)
        RemoveHandler txtEdit.KeyPress, AddressOf TextBox_KeyPress
        AddHandler txtEdit.KeyPress, AddressOf TextBox_KeyPress
    End Sub

    Private Sub TextBox_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = "c"c OrElse e.KeyChar = "C"c Then
            Dim txtEdit As TextBox = CType(sender, TextBox)
            txtEdit.Text = "Canvass"
            txtEdit.SelectionStart = txtEdit.Text.Length
            e.Handled = True ' Prevent "c" from being typed into the cell
        ElseIf e.KeyChar = "e" OrElse e.KeyChar = "E" Then
            Dim txtEdit As TextBox = CType(sender, TextBox)
            txtEdit.Text = "Except"
            txtEdit.SelectionStart = txtEdit.Text.Length
            e.Handled = True ' Prevent "c" from being typed into the cell
        

        End If
    End Sub


End Class