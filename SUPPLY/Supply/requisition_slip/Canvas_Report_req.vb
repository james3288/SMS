Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class Canvas_Report_req
    Public SQ As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Public purpose_canvas As String
    Public public_query As String
    Dim list_of_supplier As New List(Of List(Of String))
    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Canvas_Report_req_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        suppliers()
        For Each drv As DataGridViewRow In dgvPOList.Rows
            drv.Cells(0).Value = True
            rsNo.Text = drv.Cells(3).Value
        Next
        getCanvassNo()

    End Sub


    Private Sub dgvPOList_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPOList.CellEndEdit
        Dim targetColumnIndex1 As Integer = 19
        Dim targetColumnIndex2 As Integer = 21
        Dim targetColumnIndex3 As Integer = 23

        If e.ColumnIndex = targetColumnIndex1 Then
            Dim cell As DataGridViewCell = dgvPOList(e.ColumnIndex, e.RowIndex)
            Dim inputValue As String = cell.Value.ToString()

            If Not IsNumeric(inputValue) Then
                MessageBox.Show("Invalid input. Please enter a numeric value.")
                cell.Value = Nothing
            End If
        ElseIf e.ColumnIndex = targetColumnIndex2 Then
            Dim cell As DataGridViewCell = dgvPOList(e.ColumnIndex, e.RowIndex)
            Dim inputValue As String = cell.Value.ToString()

            If Not IsNumeric(inputValue) Then
                MessageBox.Show("Invalid input. Please enter a numeric value.")
                cell.Value = Nothing
            End If
        ElseIf e.ColumnIndex = targetColumnIndex3 Then
            Dim cell As DataGridViewCell = dgvPOList(e.ColumnIndex, e.RowIndex)
            Dim inputValue As String = cell.Value.ToString()

            If Not IsNumeric(inputValue) Then
                MessageBox.Show("Invalid input. Please enter a numeric value.")
                cell.Value = Nothing
            End If
        End If
        calculate_unitprice()

        'Try
        '    For i As Integer = 0 To dgvPOList.Rows.Count - 1
        '        Dim quantity As String = dgvPOList.Rows(i).Cells(7).Value
        '        Dim digits_from_quantity As String = get_integers_only(quantity)

        '        Dim unit1 As Double = dgvPOList.Rows(i).Cells(17).Value
        '        Dim total1 As Double = CDec(digits_from_quantity.ToString) * CDec(unit1.ToString)
        '        dgvPOList.Rows(i).Cells(18).Value = String.Format("{0:#,##0.00}", total1)


        '        Dim unit2 As Double = dgvPOList.Rows(i).Cells(19).Value
        '        Dim total2 As Double = CDec(digits_from_quantity.ToString) * CDec(unit2.ToString)
        '        dgvPOList.Rows(i).Cells(20).Value = String.Format("{0:#,##0.00}", total2)

        '        Dim unit3 As Double = dgvPOList.Rows(i).Cells(21).Value
        '        Dim total3 As Double = CDec(digits_from_quantity.ToString) * CDec(unit3.ToString)
        '        dgvPOList.Rows(i).Cells(22).Value = String.Format("{0:#,##0.00}", total3)
        '    Next
        'Catch ex As Exception
        '    MsgBox("INPUT NOT ACCEPTABLE. MAYBE YOU INPUT LETTERS OR IF NOT. CALL MAKMAK :)")
        'End Try

    End Sub

    Public Sub calculate_unitprice()
        Try
            For i As Integer = 0 To dgvPOList.Rows.Count - 1
                Dim quantity As String = dgvPOList.Rows(i).Cells(9).Value
                Dim digits_from_quantity As String = get_with_decimals(quantity)
                digits_from_quantity = digits_from_quantity.TrimEnd("."c)

                Dim unit1 As Double = dgvPOList.Rows(i).Cells(19).Value
                Dim total1 As Double = CDec(digits_from_quantity.ToString) * CDec(unit1.ToString)
                dgvPOList.Rows(i).Cells(20).Value = String.Format("{0:#,##0.00}", total1)


                Dim unit2 As Double = dgvPOList.Rows(i).Cells(21).Value
                Dim total2 As Double = CDec(digits_from_quantity.ToString) * CDec(unit2.ToString)
                dgvPOList.Rows(i).Cells(22).Value = String.Format("{0:#,##0.00}", total2)

                Dim unit3 As Double = dgvPOList.Rows(i).Cells(23).Value
                Dim total3 As Double = CDec(digits_from_quantity.ToString) * CDec(unit3.ToString)
                dgvPOList.Rows(i).Cells(24).Value = String.Format("{0:#,##0.00}", total3)
            Next
        Catch ex As Exception
            'MsgBox("INPUT NOT ACCEPTABLE. MAYBE YOU INPUT LETTERS OR IF NOT. CALL MAKMAK :)")
        End Try
    End Sub

    Private Function get_integers_only(s As String) As String

        Return New String(s.Where(Function(x As Char) System.Char.IsDigit(x)).ToArray)
    End Function

    Private Function get_with_decimals(s As String) As String
        Return New String(s.Where(Function(x As Char) Char.IsDigit(x) Or x = "."c).ToArray())
    End Function
    Private Sub Canvas_Report_req_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        dgvPOList.Rows.Clear()
    End Sub

    Public Sub suppliers()

        list_of_supplier = New List(Of List(Of String))
        Dim row As Integer
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "proc_supplier"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 2)
            dr = sqlcomm.ExecuteReader

            While dr.Read
                list_of_supplier.Add(New List(Of String))
                list_of_supplier(row).Add(dr.Item(1).ToString)
                row = row + 1
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

        Dim txt_row As New AutoCompleteStringCollection
        For Each list_row As List(Of String) In list_of_supplier
            txt_row.Add(list_row(0))
        Next


        TextBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        TextBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
        TextBox1.AutoCompleteCustomSource = txt_row

        TextBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        TextBox2.AutoCompleteSource = AutoCompleteSource.CustomSource
        TextBox2.AutoCompleteCustomSource = txt_row

        TextBox3.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        TextBox3.AutoCompleteSource = AutoCompleteSource.CustomSource
        TextBox3.AutoCompleteCustomSource = txt_row
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub submit_Click(sender As Object, e As EventArgs) Handles submit.Click
        report_canvas_with_budget()
        'Dim response As Integer

        'response = MsgBox("With Bugetary Cost Column?", vbYesNo + vbQuestion, "Confirmation")

        'If response = vbYes Then
        '    report_canvas_with_budget()
        'Else
        '    preview_report_canvas()
        'End If



    End Sub


    Public Sub preview_report_canvas()

        Dim canvas_datas As New DataTable
        'Dim i As Integer = 0

        Try
            With canvas_datas
                .Columns.Add("ItemName")
                .Columns.Add("Specifications")
                .Columns.Add("Quantity")
                .Columns.Add("UnitPrice")
                .Columns.Add("TotalPrice")
                .Columns.Add("UnitPrice2")
                .Columns.Add("TotalPrice2")
                .Columns.Add("UnitPrice3")
                .Columns.Add("TotalPrice3")
            End With
            For Each row2 As DataGridViewRow In dgvPOList.Rows
                If row2.Cells(0).Value = True Then
                    canvas_datas.Rows.Add(row2.Cells(4).Value, row2.Cells(5).Value,
                           row2.Cells(9).Value, row2.Cells(19).Value, row2.Cells(20).Value, row2.Cells(21).Value, row2.Cells(22).Value, row2.Cells(23).Value, row2.Cells(24).Value)
                End If

            Next

            'For i As Integer = 0 To dgvPOList.Rows.Count - 1
            '    canvas_datas.Rows.Add(dgvPOList.Rows(i).Cells(3).Value, dgvPOList.Rows(i).Cells(4).Value,
            '            dgvPOList.Rows(i).Cells(7).Value, dgvPOList.Rows(i).Cells(17).Value,
            '            dgvPOList.Rows(i).Cells(18).Value, dgvPOList.Rows(i).Cells(19).Value,
            '             dgvPOList.Rows(i).Cells(20).Value,
            '             dgvPOList.Rows(i).Cells(21).Value,
            '             dgvPOList.Rows(i).Cells(22).Value)

            'Next

            Dim viewEM As New DataView(canvas_datas)
            canvas_report_FORMVIEW.ReportViewer1.LocalReport.DataSources.Item(0).Value = viewEM
            canvas_report_FORMVIEW.ShowDialog()
            canvas_report_FORMVIEW.Dispose()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "supply INFOS canvas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub report_canvas_with_budget()
        Dim canvas_datas As New DataTable
        'Dim i As Integer = 0

        Try

            With canvas_datas
                .Columns.Add("ItemName")
                .Columns.Add("Specifications")
                .Columns.Add("Quantity")
                .Columns.Add("UnitPrice")
                .Columns.Add("TotalPrice")
                .Columns.Add("UnitPrice2")
                .Columns.Add("TotalPrice2")
                .Columns.Add("UnitPrice3")
                .Columns.Add("TotalPrice3")
                .Columns.Add("BudgetCost")
            End With

            For Each row2 As DataGridViewRow In dgvPOList.Rows
                If row2.Cells(0).Value = True Then
                    canvas_datas.Rows.Add(row2.Cells(4).Value, row2.Cells(5).Value,
                              row2.Cells(9).Value, row2.Cells(19).Value, row2.Cells(20).Value,
                              row2.Cells(21).Value, row2.Cells(22).Value, row2.Cells(23).Value,
                              row2.Cells(24).Value, row2.Cells(8).Value)
                End If
            Next

            ' Step 3: Get the current row count and add 5 blank rows
            Dim currentRowCount As Integer = canvas_datas.Rows.Count

            If currentRowCount > 33 Then
                Dim totAddRow3 As Integer = 22 - currentRowCount
                For i As Integer = 1 To totAddRow3
                    canvas_datas.Rows.Add("")
                Next

            ElseIf currentRowCount > 22 Then
                Dim totAddRow3 As Integer = 33 - currentRowCount
                For i As Integer = 1 To totAddRow3
                    canvas_datas.Rows.Add("")
                Next

            ElseIf currentRowCount > 11 Then

                Dim totAddRow As Integer = 22 - currentRowCount
                For i As Integer = 1 To totAddRow
                    canvas_datas.Rows.Add("")
                Next
            Else
                Dim totAddRow2 As Integer = 11 - currentRowCount
                For i As Integer = 1 To totAddRow2
                    canvas_datas.Rows.Add("")

                Next

            End If

            'MessageBox.Show("Rows added: " & currentRowCount & vbCrLf & "Total Rows including blank: " & canvas_datas.Rows.Count)




            Dim viewEM As New DataView(canvas_datas)
            canvas_report_FORMVIEW_2.ReportViewer1.LocalReport.DataSources.Item(0).Value = viewEM
            canvas_report_FORMVIEW_2.ShowDialog()
            canvas_report_FORMVIEW_2.Dispose()
            Dim response1 = MsgBox("You want to save Canvass?", vbYesNo + vbQuestion, "Confirmation")

            If response1 = vbYes Then
                saving_canvass()
            Else

            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "supply INFOS canvas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        enabling_buttons(False)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        enabling_buttons(True)
    End Sub

    Public Function enabling_buttons(condition As Boolean)
        If condition = True Then
            Panel2.Visible = False
            dgvPOList.Enabled = True
            TextBox1.Enabled = True
            TextBox2.Enabled = True
            TextBox3.Enabled = True
            canvas_date.Enabled = True
            purpose_txt.Enabled = True
            Button1.Enabled = True
            submit.Enabled = True
            canvasbys.Enabled = True
            appve_by.Enabled = True
        ElseIf condition = False Then

            Panel2.Visible = True
            dgvPOList.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            canvas_date.Enabled = False
            purpose_txt.Enabled = False
            Button1.Enabled = False
            submit.Enabled = False
            canvasbys.Enabled = False
            appve_by.Enabled = False

            TextBox5.Focus()

        End If
        Return condition
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox5.Text = "" Then
            MsgBox("You Enter Null")
        Else
            get_anotherRS()
            purpose_txt.Text = purpose_txt.Text + "/ " + TextBox5.Text + "(" + purpose_canvas + ")"
            rsNo.Text = rsNo.Text & ", " & TextBox5.Text
            calculate_unitprice()
        End If

        'If purpose_txt.TextLength <= 5 Then
        '    MsgBox("asd")
        'End If
        'Dim strLength As String = TextBox1.Text
        'MessageBox.Show("Number of Characters: " & strLength.Length.ToString)

    End Sub

    Public Sub get_anotherRS()
        Dim SQ As New SQLcon
        Dim dr As SqlDataReader
        Dim exist As Boolean = False
        'Dim newcmd As SqlCommand
        'dgvPOList.Rows.Clear()
        'Dim i As Integer = get_id_projeccode(cmbSearch_Project_WorkSite.Text)
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "proc_requisition_slip"
            sqlcomm.CommandType = CommandType.StoredProcedure

            sqlcomm.Parameters.AddWithValue("@searchby", TextBox5.Text)
            sqlcomm.Parameters.AddWithValue("@n", 455)
            dr = sqlcomm.ExecuteReader
            While dr.Read
                Dim a(20) As String
                For Each row2 As DataGridViewRow In dgvPOList.Rows
                    'If row2.Cells(2).Value = dr.Item(2).ToString Then

                    If row2.Cells(2).Value = dr.Item(2).ToString Then

                        Dim quantity As String = row2.Cells(9).Value
                        Dim digits_from_quantity As String = get_integers_only(quantity)
                        Dim digits_from_quantity2 As String = get_integers_only(dr.Item(4).ToString)
                        row2.Cells(9).Value = CDec(digits_from_quantity) + CDec(digits_from_quantity2) & " " & dr.Item(5).ToString
                        exist = True
                    Else
                        a(0) = True

                        a(2) = dr.Item(2).ToString
                        a(3) = dr.Item(1).ToString
                        a(4) = dr.Item(7).ToString
                        a(5) = dr.Item(3).ToString
                        a(9) = dr.Item(4).ToString & " " & dr.Item(5).ToString

                    End If
                Next

                purpose_canvas = dr.Item(6).ToString
                If exist = False Then
                    dgvPOList.Rows.Add(a)
                Else

                End If

            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "supply INFOSsss", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

    End Sub

    Private Sub MergeItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MergeItemToolStripMenuItem.Click

        Dim rowadd As DataGridViewRow
        Dim row2 As DataGridViewRow
        Dim total_merge As Decimal
        Dim lett As String
        For Each row2 In dgvPOList.SelectedRows
            Dim quantity As String = row2.Cells(9).Value
            lett = getletters(row2.Cells(9).Value)

            Dim digits_from_quantity As String = get_with_decimals(quantity)
            digits_from_quantity = digits_from_quantity.TrimEnd("."c)

            total_merge = total_merge + digits_from_quantity
            dgvPOList.Rows.Remove(row2)
        Next
        dgvPOList.Rows.Add(row2)

        For Each rowadd In dgvPOList.Rows
        Next
        rowadd.Cells(9).Value = total_merge & " " & lett & "."

    End Sub



    Private Sub DeleteRowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteRowToolStripMenuItem.Click
        For Each row2 As DataGridViewRow In dgvPOList.SelectedRows
            dgvPOList.Rows.Remove(row2)
        Next
    End Sub

    Private Function getletters(s As String) As String
        Return New String(s.Where(Function(x As Char) System.Char.IsLetter(x)).ToArray)

    End Function

    Private Sub TextBox5_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox5.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Button2.PerformClick()
                TextBox5.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        purpose_txt.Text = "line_one" & vbCrLf & "line_two"
    End Sub

    Private Sub AddRowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddRowToolStripMenuItem.Click
        dgvPOList.Rows.Add()

    End Sub

    Private Sub dgvPOList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPOList.CellContentClick

    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            For Each row As DataGridViewRow In dgvPOList.Rows
                If Not row.IsNewRow Then
                    Dim DimselectedDateTime As DateTime = canvas_date.Value
                    Dim DimRsNo As String = row.Cells(3).Value?.ToString()
                    Dim DimItemName As String = row.Cells(4).Value?.ToString()
                    Dim DimDescription As String = row.Cells(5).Value?.ToString()
                    Dim DimBudgetary As String = row.Cells(8).Value?.ToString()
                    Dim DimQty As String = row.Cells(9).Value?.ToString()

                    Dim DimUnitPrice1 As String = row.Cells(19).Value?.ToString()
                    Dim DimTotalPrice1 As String = row.Cells(20).Value?.ToString()
                    Dim DimcTotalPriceFinal1 As String = DimTotalPrice1.Replace(",", "")

                    Dim DimUnitPrice2 As String = row.Cells(21).Value?.ToString()
                    Dim DimTotalPrice2 As String = row.Cells(22).Value?.ToString()
                    Dim DimcTotalPriceFinal2 As String = DimTotalPrice2.Replace(",", "")

                    Dim DimUnitPrice3 As String = row.Cells(23).Value?.ToString()
                    Dim DimTotalPrice3 As String = row.Cells(24).Value?.ToString()
                    Dim DimcTotalPriceFinal3 As String = DimTotalPrice3.Replace(",", "")



                    Dim message1 As String = $"RsNo: {DimRsNo}{Environment.NewLine}"
                    message1 &= $"Supplier: {TextBox1.Text}{Environment.NewLine}"
                    message1 &= $"Data from DimItemName: {DimItemName}{Environment.NewLine}"
                    message1 &= $"Data from DimDescription: {DimDescription}{Environment.NewLine}"
                    message1 &= $"Data from DimBudgetary: {DimBudgetary}{Environment.NewLine}"
                    message1 &= $"Data from DimQty: {DimQty}{Environment.NewLine}"
                    message1 &= $"Data from DimUnitPrice1: {DimUnitPrice1}{Environment.NewLine}"
                    message1 &= $"Data from DimTotalPrice1: {DimcTotalPriceFinal1}{Environment.NewLine}"
                    message1 &= $"Data from remarks: {remarks1.Text}{Environment.NewLine}"
                    message1 &= $"Data from purpose: {purpose_txt.Text}{Environment.NewLine}"
                    message1 &= $"Data from canvass by: {canvasbys.Text}{Environment.NewLine}"
                    message1 &= $"Data from approve by: {appve_by.Text}{Environment.NewLine}"

                    Dim message2 As String = $"RsNo: {DimRsNo}{Environment.NewLine}"
                    message2 &= $"Supplier: {TextBox2.Text}{Environment.NewLine}"
                    message2 &= $"Data from DimItemName: {DimItemName}{Environment.NewLine}"
                    message2 &= $"Data from DimDescription: {DimDescription}{Environment.NewLine}"
                    message2 &= $"Data from DimBudgetary: {DimBudgetary}{Environment.NewLine}"
                    message2 &= $"Data from DimQty: {DimQty}{Environment.NewLine}"
                    message2 &= $"Data from DimUnitPrice2: {DimUnitPrice2}{Environment.NewLine}"
                    message2 &= $"Data from DimTotalPrice2: {DimcTotalPriceFinal2}{Environment.NewLine}"
                    message2 &= $"Data from remarks: {remarks2.Text}{Environment.NewLine}"
                    message2 &= $"Data from purpose: {purpose_txt.Text}{Environment.NewLine}"
                    message2 &= $"Data from canvass by: {canvasbys.Text}{Environment.NewLine}"
                    message2 &= $"Data from approve by: {appve_by.Text}{Environment.NewLine}"

                    Dim message3 As String = $"RsNo: {DimRsNo}{Environment.NewLine}"
                    message3 &= $"Supplier: {TextBox3.Text}{Environment.NewLine}"
                    message3 &= $"Data from DimItemName: {DimItemName}{Environment.NewLine}"
                    message3 &= $"Data from DimDescription: {DimDescription}{Environment.NewLine}"
                    message3 &= $"Data from DimBudgetary: {DimBudgetary}{Environment.NewLine}"
                    message3 &= $"Data from DimQty: {DimQty}{Environment.NewLine}"
                    message3 &= $"Data from DimUnitPrice3: {DimUnitPrice3}{Environment.NewLine}"
                    message3 &= $"Data from DimTotalPrice3: {DimcTotalPriceFinal3}{Environment.NewLine}"
                    message3 &= $"Data from remarks: {remarks3.Text}{Environment.NewLine}"
                    message3 &= $"Data from purpose: {purpose_txt.Text}{Environment.NewLine}"
                    message3 &= $"Data from canvass by: {canvasbys.Text}{Environment.NewLine}"
                    message3 &= $"Data from approve by: {appve_by.Text}{Environment.NewLine}"


                    If Not String.IsNullOrEmpty(TextBox1.Text) Then
                        insertCanvassFunction(DimRsNo,
                                          TextBox1.Text,
                                          DimItemName,
                                          DimDescription,
                                          DimBudgetary,
                                          DimQty,
                                          DimUnitPrice1,
                                          DimTotalPrice1,
                                          remarks1.Text,
                                          purpose_txt.Text,
                                          canvasbys.Text,
                                          appve_by.Text,
                                          TextBox6.Text,
                                          DimselectedDateTime)

                    End If

                    If Not String.IsNullOrEmpty(TextBox2.Text) Then
                        insertCanvassFunction(DimRsNo,
                                          TextBox2.Text,
                                          DimItemName,
                                          DimDescription,
                                          DimBudgetary,
                                          DimQty,
                                          DimUnitPrice2,
                                          DimTotalPrice2,
                                          remarks2.Text,
                                          purpose_txt.Text,
                                          canvasbys.Text,
                                          appve_by.Text,
                                          TextBox6.Text,
                                          DimselectedDateTime)

                    End If

                    If Not String.IsNullOrEmpty(TextBox3.Text) Then
                        insertCanvassFunction(DimRsNo,
                                          TextBox3.Text,
                                          DimItemName,
                                          DimDescription,
                                          DimBudgetary,
                                          DimQty,
                                          DimUnitPrice3,
                                          DimTotalPrice3,
                                          remarks3.Text,
                                          purpose_txt.Text,
                                          canvasbys.Text,
                                          appve_by.Text,
                                          TextBox6.Text,
                                          DimselectedDateTime)

                    End If

                End If

            Next

            MsgBox("INSERT SUCCESS")
        Catch ex As Exception
            MsgBox("Error Pages")

        End Try


    End Sub

    Public Sub getCanvassNo()
        Try
            SQ.connection.Open()
            public_query = "SELECT top 1 canvass_no FROM dbCanvass order by canvass_id desc"
            cmd = New SqlCommand(public_query, SQ.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim currentValue As Integer = Integer.Parse(dr.Item(0).ToString())
                Dim incrementedValue As String = (currentValue + 1).ToString("D4")

                TextBox6.Text = incrementedValue
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub



    Public Function insertCanvassFunction(ByVal rsno As String,
                                          ByVal sup_name As String,
                                          ByVal itemname As String,
                                          ByVal itemdesc As String,
                                          ByVal budget As String,
                                          ByVal qty As String,
                                          ByVal unitprice As Decimal,
                                          ByVal totalprice As Decimal,
                                          ByVal remarks As String,
                                          ByVal prupose As String,
                                          ByVal canvasby As String,
                                          ByVal approveby As String,
                                          ByVal canvassno As String,
                                          ByVal canvassdate As DateTime)
        Dim designationId As Integer = 0
        Try
            SQ.connection.Open()

            Dim insertQuery As String = "INSERT INTO dbCanvass (canvass_no
                                                                    ,supplier_name
                                                                    ,rs_no
                                                                    ,item_name
                                                                    ,description
                                                                    ,budgetary_cost
                                                                    ,qty
                                                                    ,unit_price
                                                                    ,total_price
                                                                    ,remarks
                                                                    ,purpose
                                                                    ,canvass_by
                                                                    ,approved_by
                                                                    ,canvass_date)
                                                            VALUES (@val_canvas
                                                                    ,@val_supplier
                                                                    ,@val_rsno
                                                                    ,@val_itemname
                                                                    ,@val_desc
                                                                    ,@val_budget
                                                                    ,@val_qty
                                                                    ,@val_unitprice
                                                                    ,@val_totalprice
                                                                    ,@val_remarks
                                                                    ,@val_purpose
                                                                    ,@val_canvassby
                                                                    ,@val_approveby
                                                                    ,@val_canvassdate);"
            Using cmd As New SqlCommand(insertQuery, SQ.connection)
                cmd.Parameters.AddWithValue("@val_canvas", canvassno)
                cmd.Parameters.AddWithValue("@val_supplier", sup_name)
                cmd.Parameters.AddWithValue("@val_rsno", rsno)
                cmd.Parameters.AddWithValue("@val_itemname", itemname)
                cmd.Parameters.AddWithValue("@val_desc", itemdesc)
                cmd.Parameters.AddWithValue("@val_budget", budget)
                cmd.Parameters.AddWithValue("@val_qty", qty)
                cmd.Parameters.AddWithValue("@val_unitprice", unitprice)
                cmd.Parameters.AddWithValue("@val_totalprice", totalprice)
                cmd.Parameters.AddWithValue("@val_remarks", remarks)
                cmd.Parameters.AddWithValue("@val_purpose", prupose)
                cmd.Parameters.AddWithValue("@val_canvassby", canvasby)
                cmd.Parameters.AddWithValue("@val_approveby", approveby)
                cmd.Parameters.AddWithValue("@val_canvassdate", canvassdate)
                cmd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & ex.Message, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Function

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        Dim selectedDateTime As DateTime = canvas_date.Value

        ' Now you can use selectedDateTime as needed
        MessageBox.Show("Selected Date and Time: " & selectedDateTime.ToString())
    End Sub


    Public Sub saving_canvass()
        Try
            For Each row As DataGridViewRow In dgvPOList.Rows
                If Not row.IsNewRow Then
                    Dim DimselectedDateTime As DateTime = canvas_date.Value
                    Dim DimRsNo As String = row.Cells(3).Value?.ToString()
                    Dim DimItemName As String = row.Cells(4).Value?.ToString()
                    Dim DimDescription As String = row.Cells(5).Value?.ToString()
                    Dim DimBudgetary As String = row.Cells(8).Value?.ToString()
                    Dim DimQty As String = row.Cells(9).Value?.ToString()

                    Dim DimUnitPrice1 As String = row.Cells(19).Value?.ToString()
                    Dim DimTotalPrice1 As String = row.Cells(20).Value?.ToString()
                    Dim DimcTotalPriceFinal1 As String = DimTotalPrice1.Replace(",", "")

                    Dim DimUnitPrice2 As String = row.Cells(21).Value?.ToString()
                    Dim DimTotalPrice2 As String = row.Cells(22).Value?.ToString()
                    Dim DimcTotalPriceFinal2 As String = DimTotalPrice2.Replace(",", "")

                    Dim DimUnitPrice3 As String = row.Cells(23).Value?.ToString()
                    Dim DimTotalPrice3 As String = row.Cells(24).Value?.ToString()
                    Dim DimcTotalPriceFinal3 As String = DimTotalPrice3.Replace(",", "")



                    Dim message1 As String = $"RsNo: {DimRsNo}{Environment.NewLine}"
                    message1 &= $"Supplier: {TextBox1.Text}{Environment.NewLine}"
                    message1 &= $"Data from DimItemName: {DimItemName}{Environment.NewLine}"
                    message1 &= $"Data from DimDescription: {DimDescription}{Environment.NewLine}"
                    message1 &= $"Data from DimBudgetary: {DimBudgetary}{Environment.NewLine}"
                    message1 &= $"Data from DimQty: {DimQty}{Environment.NewLine}"
                    message1 &= $"Data from DimUnitPrice1: {DimUnitPrice1}{Environment.NewLine}"
                    message1 &= $"Data from DimTotalPrice1: {DimcTotalPriceFinal1}{Environment.NewLine}"
                    message1 &= $"Data from remarks: {remarks1.Text}{Environment.NewLine}"
                    message1 &= $"Data from purpose: {purpose_txt.Text}{Environment.NewLine}"
                    message1 &= $"Data from canvass by: {canvasbys.Text}{Environment.NewLine}"
                    message1 &= $"Data from approve by: {appve_by.Text}{Environment.NewLine}"

                    Dim message2 As String = $"RsNo: {DimRsNo}{Environment.NewLine}"
                    message2 &= $"Supplier: {TextBox2.Text}{Environment.NewLine}"
                    message2 &= $"Data from DimItemName: {DimItemName}{Environment.NewLine}"
                    message2 &= $"Data from DimDescription: {DimDescription}{Environment.NewLine}"
                    message2 &= $"Data from DimBudgetary: {DimBudgetary}{Environment.NewLine}"
                    message2 &= $"Data from DimQty: {DimQty}{Environment.NewLine}"
                    message2 &= $"Data from DimUnitPrice2: {DimUnitPrice2}{Environment.NewLine}"
                    message2 &= $"Data from DimTotalPrice2: {DimcTotalPriceFinal2}{Environment.NewLine}"
                    message2 &= $"Data from remarks: {remarks2.Text}{Environment.NewLine}"
                    message2 &= $"Data from purpose: {purpose_txt.Text}{Environment.NewLine}"
                    message2 &= $"Data from canvass by: {canvasbys.Text}{Environment.NewLine}"
                    message2 &= $"Data from approve by: {appve_by.Text}{Environment.NewLine}"

                    Dim message3 As String = $"RsNo: {DimRsNo}{Environment.NewLine}"
                    message3 &= $"Supplier: {TextBox3.Text}{Environment.NewLine}"
                    message3 &= $"Data from DimItemName: {DimItemName}{Environment.NewLine}"
                    message3 &= $"Data from DimDescription: {DimDescription}{Environment.NewLine}"
                    message3 &= $"Data from DimBudgetary: {DimBudgetary}{Environment.NewLine}"
                    message3 &= $"Data from DimQty: {DimQty}{Environment.NewLine}"
                    message3 &= $"Data from DimUnitPrice3: {DimUnitPrice3}{Environment.NewLine}"
                    message3 &= $"Data from DimTotalPrice3: {DimcTotalPriceFinal3}{Environment.NewLine}"
                    message3 &= $"Data from remarks: {remarks3.Text}{Environment.NewLine}"
                    message3 &= $"Data from purpose: {purpose_txt.Text}{Environment.NewLine}"
                    message3 &= $"Data from canvass by: {canvasbys.Text}{Environment.NewLine}"
                    message3 &= $"Data from approve by: {appve_by.Text}{Environment.NewLine}"


                    If Not String.IsNullOrEmpty(TextBox1.Text) Then
                        Dim budgetNew As String = DimBudgetary
                        If budgetNew = "" Or budgetNew = 0 Then
                            budgetNew = "0.00"
                        End If
                        insertCanvassFunction(DimRsNo,
                                          TextBox1.Text,
                                          DimItemName,
                                          DimDescription,
                                          budgetNew,
                                          DimQty,
                                          DimUnitPrice1,
                                          DimTotalPrice1,
                                          remarks1.Text,
                                          purpose_txt.Text,
                                          canvasbys.Text,
                                          appve_by.Text,
                                          TextBox6.Text,
                                          DimselectedDateTime)

                    End If

                    If Not String.IsNullOrEmpty(TextBox2.Text) Then
                        Dim budgetNew As String = DimBudgetary
                        If budgetNew = "" Or budgetNew = 0 Then
                            budgetNew = "0.00"
                        End If
                        insertCanvassFunction(DimRsNo,
                                          TextBox2.Text,
                                          DimItemName,
                                          DimDescription,
                                          budgetNew,
                                          DimQty,
                                          DimUnitPrice2,
                                          DimTotalPrice2,
                                          remarks2.Text,
                                          purpose_txt.Text,
                                          canvasbys.Text,
                                          appve_by.Text,
                                          TextBox6.Text,
                                          DimselectedDateTime)

                    End If

                    If Not String.IsNullOrEmpty(TextBox3.Text) Then
                        Dim budgetNew As String = DimBudgetary
                        If budgetNew = "" Or budgetNew = 0 Then
                            budgetNew = "0.00"
                        End If
                        insertCanvassFunction(DimRsNo,
                                          TextBox3.Text,
                                          DimItemName,
                                          DimDescription,
                                          budgetNew,
                                          DimQty,
                                          DimUnitPrice3,
                                          DimTotalPrice3,
                                          remarks3.Text,
                                          purpose_txt.Text,
                                          canvasbys.Text,
                                          appve_by.Text,
                                          TextBox6.Text,
                                          DimselectedDateTime)

                    End If

                End If

            Next

            MsgBox("Saving Data Success!")
        Catch ex As Exception
            MsgBox("Error Pages")

        End Try
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        Dim rowIndex As Integer = 0
        Dim subTotalText As String = "Sub Total"
        Dim remarks As String = "Remarks"


        For i As Integer = 1 To dgvPOList.Rows.Count

            If i Mod 10 = 0 Then

                Dim newRow As DataGridViewRow = CType(dgvPOList.Rows(3).Clone(), DataGridViewRow)
                newRow.Cells(3).Value = subTotalText
                dgvPOList.Rows.Insert(i + rowIndex, newRow)
                rowIndex += 1
            End If
            If i Mod 10 = 0 Then

                Dim newRow As DataGridViewRow = CType(dgvPOList.Rows(3).Clone(), DataGridViewRow)
                newRow.Cells(3).Value = remarks

                dgvPOList.Rows.Insert(i + rowIndex, newRow)

                rowIndex += 1
            End If
        Next

    End Sub
End Class