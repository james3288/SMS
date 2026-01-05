Imports System.Data.SqlClient
Imports System.Globalization
Imports Microsoft.Office.Interop

Public Class ExportingRecordForm
    Public search_code As Integer = 0
    Dim row_type_request As New AutoCompleteStringCollection
    Private Sub cmbSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearch.SelectedIndexChanged
        If cmbSearch.Text.Equals("RS NO") Then
            '@search_code = 1
            frmSearchCode.lblCode.Text = "R.S. NO.:"
            search_code = 1
            frmSearchCode.ShowDialog()
        ElseIf cmbSearch.Text.Equals("WS NO") Then
            '@search_code = 2
            frmSearchCode.lblCode.Text = "W.S. NO.:"
            search_code = 2
            frmSearchCode.ShowDialog()
        ElseIf cmbSearch.Text.Equals("RR NO") Then
            '@search_code = 3
            frmSearchCode.lblCode.Text = "R.R. NO.:"
            search_code = 3
            frmSearchCode.ShowDialog()
        ElseIf cmbSearch.Text.Equals("DR NO") Then
            '@search_code = 4
            frmSearchCode.lblCode.Text = "D.R. NO.:"
            search_code = 4
            frmSearchCode.ShowDialog()
        ElseIf cmbSearch.Text.Equals("PO NO") Then
            '@search_code = 5
            frmSearchCode.lblCode.Text = "P.O. NO.:"
            search_code = 5
            frmSearchCode.ShowDialog()
        ElseIf cmbSearch.Text.Equals("RS Date Range") Then
            '@search_code = 6
            frmDateRange.Text = "Requisition Slip"
            frmDateRange.Label2.Text = "R.S. Date Range"
            frmDateRange.TextBox1.Enabled = True
            frmDateRange.TextBox2.Enabled = True
            search_code = 6
            frmDateRange.ShowDialog()
        ElseIf cmbSearch.Text.Equals("WS Date Range") Then
            '@search_code = 7
            frmDateRange.Text = "Withdrawal Slip"
            frmDateRange.Label2.Text = "W.S. Date Range"
            frmDateRange.TextBox1.Enabled = True
            frmDateRange.TextBox2.Enabled = True
            search_code = 7
            frmDateRange.ShowDialog()
        ElseIf cmbSearch.Text.Equals("RR Date Range") Then
            '@search_code = 8
            frmDateRange.Text = "Receiving Report"
            frmDateRange.Label2.Text = "R.R. Date Range"
            frmDateRange.TextBox1.Enabled = True
            frmDateRange.TextBox2.Enabled = True
            search_code = 8
            frmDateRange.ShowDialog()
        ElseIf cmbSearch.Text.Equals("DR Date Range") Then
            '@search_code = 9
            frmDateRange.Text = "Delivery Report"
            frmDateRange.Label2.Text = "D.R. Date Range"
            frmDateRange.TextBox1.Enabled = True
            frmDateRange.TextBox2.Enabled = True
            search_code = 9
            frmDateRange.ShowDialog()
        ElseIf cmbSearch.Text.Equals("PO Date Range") Then
            '@search_code = 10
            frmDateRange.Text = "Purchase Order"
            frmDateRange.Label2.Text = "P.O. Date Range"
            frmDateRange.TextBox1.Enabled = True
            frmDateRange.TextBox2.Enabled = True
            search_code = 10
            frmDateRange.ShowDialog()
        ElseIf cmbSearch.Text.Equals("Liquidation") Then
            '@search_code = 14
            frmDateRange.Text = "Liquidation"
            frmDateRange.Label2.Text = "Liquidation Date Range"
            frmDateRange.TextBox1.Enabled = True
            frmDateRange.TextBox2.Enabled = True
            search_code = 14
            frmDateRange.ShowDialog()
        ElseIf cmbSearch.Text.Equals("Request Type") Then
            '@search_code = 11
            frmDateRange.Text = "Request Type"
            frmDateRange.Label2.Text = "Request Type Date Range"
            frmDateRange.TextBox1.Enabled = True
            frmDateRange.TextBox2.Enabled = False
            search_code = 11
            frmDateRange.TextBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            frmDateRange.TextBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
            frmDateRange.TextBox1.AutoCompleteCustomSource = row_type_request
            frmDateRange.ShowDialog()
        ElseIf cmbSearch.Text.Equals("Charge To") Then
            '@search_code = 12
            frmDateRange.Text = "Charges"
            frmDateRange.Label2.Text = "Charges Date Range"
            frmDateRange.TextBox1.Enabled = False
            frmDateRange.TextBox2.Enabled = True
            search_code = 12
            frmDateRange.ShowDialog()
        ElseIf cmbSearch.Text.Equals("Overall") Then
            '@search_code = 13
            frmDateRange.Text = "Overall"
            frmDateRange.Label2.Text = "Overall Date Range"
            frmDateRange.TextBox1.Enabled = False
            frmDateRange.TextBox2.Enabled = False
            search_code = 13
            frmDateRange.ShowDialog()
        ElseIf cmbSearch.Text.Equals("Overall (w/ Filter)") Then
            '@search_code = 15
            search_code = 15
            frmFilter.ShowDialog()
        ElseIf cmbSearch.Text.Equals("RR/RS Date Log Range") Then
            '@search_code = 15
            frmDateRange.Text = "RR/RS Date Log"
            frmDateRange.Label2.Text = "RR/RS Date Log Range"
            frmDateRange.TextBox1.Enabled = True
            frmDateRange.TextBox2.Enabled = True
            search_code = 16
            frmDateRange.ShowDialog()
        ElseIf cmbSearch.Text.Equals("Item Description") Then
            '@search_code = 17
            frmSearchCode.lblCode.Text = "Item Desc."
            search_code = 17
            frmSearchCode.ShowDialog()
        End If

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs)
        frmSearchCode.ShowDialog()
    End Sub

    Private Sub ExportingRecordForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        generate_type_of_request()
    End Sub
    Sub generate_type_of_request()
        Dim newsqlcon As New SQLcon
        Dim newsqldr As SqlDataReader
        Dim newcmd As SqlCommand
        Try
            newsqlcon.connection.Open()
            Dim query As String = "Select distinct [typeRequest]
                                    From [supply_db].[dbo].[dbrequisition_slip]
                                    Where typeRequest Is Not null
                                    And typeRequest <> ''"
            newcmd = New SqlCommand(query, newsqlcon.connection)
            newcmd.CommandTimeout = 0
            newcmd.CommandType = CommandType.Text
            newsqldr = newcmd.ExecuteReader

            While newsqldr.Read
                row_type_request.Add(newsqldr.Item(0).ToString)
            End While
            newsqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & "error: " & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
        End Try
    End Sub
    Sub generate_records(ByVal search_code As Integer, ByVal date_start As Date, ByVal date_end As Date, ByVal date_start_1 As Date, ByVal date_end_1 As Date, ByVal num_code As String, ByVal request_type As String, ByVal charges As String)
        dtgSummarySupply.Rows.Clear()
        Dim newsqlcon As New SQLcon
        Dim newsqldr As SqlDataReader
        Dim newcmd As SqlCommand
        Dim a(49) As String
        Try
            newsqlcon.connection.Open()
            newcmd = New SqlCommand("proc_generate_records", newsqlcon.connection)
            newcmd.CommandTimeout = 0
            newcmd.Parameters.Clear()
            newcmd.CommandType = CommandType.StoredProcedure
            newcmd.Parameters.AddWithValue("@search_code", search_code)
            newcmd.Parameters.Add("@date_start", SqlDbType.Date).Value = date_start
            newcmd.Parameters.Add("@date_end", SqlDbType.Date).Value = date_end
            newcmd.Parameters.Add("@date_start_1", SqlDbType.Date).Value = date_start
            newcmd.Parameters.Add("@date_end_1", SqlDbType.Date).Value = date_end
            newcmd.Parameters.AddWithValue("@num_code", num_code)
            newcmd.Parameters.AddWithValue("@request_type", request_type)
            newcmd.Parameters.AddWithValue("@charge_to", charges)
            newcmd.Parameters.AddWithValue("@search_value", num_code)
            newsqldr = newcmd.ExecuteReader
            While newsqldr.Read
                a(0) = dtgSummarySupply.RowCount
                a(1) = newsqldr.Item("RS_ID").ToString
                a(2) = If(newsqldr.Item("RS_DATE").ToString.Equals(""), "", Format(Date.Parse(newsqldr.Item("RS_DATE").ToString), "MM/dd/yyyy"))
                a(3) = If(newsqldr.Item("PO_DATE").ToString.Equals(""), "", Format(Date.Parse(newsqldr.Item("PO_DATE").ToString), "MM/dd/yyyy"))
                a(4) = If(newsqldr.Item("WS_DATE").ToString.Equals(""), "", Format(Date.Parse(newsqldr.Item("WS_DATE").ToString), "MM/dd/yyyy"))
                a(5) = If(newsqldr.Item("DR_DATE").ToString.Equals(""), "", Format(Date.Parse(newsqldr.Item("DR_DATE").ToString), "MM/dd/yyyy"))
                a(6) = newsqldr.Item("RR_ITEM_ID").ToString
                a(7) = newsqldr.Item("QUANTITY_REQUESTED").ToString
                a(8) = newsqldr.Item("UNIT").ToString
                a(9) = newsqldr.Item("ITEM_NAME").ToString
                a(10) = newsqldr.Item("RECEIVED_QUANTITY").ToString
                a(11) = newsqldr.Item("WITHDRAW_QTY").ToString
                a(12) = newsqldr.Item("REQUESTOR").ToString
                a(13) = newsqldr.Item("PO_NO").ToString
                a(14) = newsqldr.Item("WS_NO").ToString
                a(15) = newsqldr.Item("RS_NO").ToString
                a(16) = newsqldr.Item("RR_NO").ToString
                a(17) = newsqldr.Item("DATE_OF_RR").ToString
                a(18) = newsqldr.Item("PO_DATE_NEEDED").ToString
                a(19) = If(newsqldr.Item("UNIT_PRICE").ToString.Equals(""), "", FormatNumber(newsqldr.Item("UNIT_PRICE").ToString))
                a(20) = If(newsqldr.Item("AMOUNT").ToString.Equals(""), "", FormatNumber(newsqldr.Item("AMOUNT").ToString))
                a(21) = newsqldr.Item("CHARGES").ToString
                a(22) = newsqldr.Item("RS_TO_PO").ToString
                a(23) = newsqldr.Item("PO_TO_RR").ToString
                a(24) = newsqldr.Item("SUPPLIER").ToString
                a(25) = newsqldr.Item("REMARKS").ToString
                a(26) = newsqldr.Item("TYPE_OF_REQUEST").ToString
                a(27) = newsqldr.Item("TR_OR_INVOICE").ToString
                a(28) = newsqldr.Item("DR_NO").ToString
                a(29) = newsqldr.Item("SO_NO").ToString
                a(30) = newsqldr.Item("HAULER").ToString
                a(31) = newsqldr.Item("PLATE_NO").ToString
                a(32) = newsqldr.Item("TYPE_OF_PURCHASE").ToString
                a(33) = newsqldr.Item("TERMS").ToString
                a(34) = If(newsqldr.Item("DATE_LOG_REQUEST").ToString.Equals(""), "", Format(Date.Parse(newsqldr.Item("DATE_LOG_REQUEST").ToString), "MM/dd/yyyy"))
                a(35) = If(newsqldr.Item("DATE_LOG_RECEIVED").ToString.Equals(""), "", Format(Date.Parse(newsqldr.Item("DATE_LOG_RECEIVED").ToString), "MM/dd/yyyy"))
                a(36) = newsqldr.Item("JOB_ORDER_NO").ToString
                a(37) = newsqldr.Item("LOCATION").ToString
                a(38) = newsqldr.Item("PURPOSE").ToString
                a(39) = newsqldr.Item("VALUE").ToString
                a(40) = newsqldr.Item("DR_QTY").ToString
                'a(41) = newsqldr.Item("CV_NO").ToString
                Dim cvNo As String = newsqldr.Item("CV_NO").ToString()

                If cvNo = "0" Or cvNo.ToUpper() = "N/A" Then
                    a(41) = "N/A"
                Else
                    a(41) = cvNo
                End If
                'a(42) = newsqldr.Item("EQUIPMENT_TYPE").ToString
                a(42) = newsqldr.Item("RS_UPDATE_LOG").ToString
                a(43) = newsqldr.Item("USER_UPDATE").ToString
                a(44) = "WAPAY FUNCTION"

                'a(45) = If(newsqldr.Item("PO_WS_UPDATE_LOG").ToString.Equals("1900-01-01"), "", newsqldr.Item("PO_WS_UPDATE_LOG").ToString)
                a(45) = newsqldr.Item("PO_WS_UPDATE_LOG").ToString
                a(46) = newsqldr.Item("USER_ADD").ToString
                a(47) = newsqldr.Item("EQUIPMENT_TYPE").ToString
                a(48) = newsqldr.Item("TypeOfRequestSUB").ToString
                a(49) = newsqldr.Item("codes").ToString
                dtgSummarySupply.Rows.Add(a)
            End While
            newsqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & "error: " & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
        End Try
    End Sub


    Sub generate_records_for_report(ByVal search_code As Integer, ByVal date_start As Date, ByVal date_end As Date, ByVal date_start_1 As Date, ByVal date_end_1 As Date, ByVal num_code As String, ByVal request_type As String, ByVal charges As String)
        dtgSummarySupply.Rows.Clear()
        Dim newsqlcon As New SQLcon
        Dim newsqldr As SqlDataReader
        Dim newcmd As SqlCommand
        Dim a(47) As String
        Try
            newsqlcon.connection.Open()
            newcmd = New SqlCommand("proc_generate_records", newsqlcon.connection)
            newcmd.CommandTimeout = 0
            newcmd.Parameters.Clear()
            newcmd.CommandType = CommandType.StoredProcedure
            newcmd.Parameters.AddWithValue("@search_code", search_code)
            newcmd.Parameters.Add("@date_start", SqlDbType.Date).Value = date_start
            newcmd.Parameters.Add("@date_end", SqlDbType.Date).Value = date_end
            newcmd.Parameters.Add("@date_start_1", SqlDbType.Date).Value = date_start
            newcmd.Parameters.Add("@date_end_1", SqlDbType.Date).Value = date_end
            newcmd.Parameters.AddWithValue("@num_code", num_code)
            newcmd.Parameters.AddWithValue("@request_type", request_type)
            newcmd.Parameters.AddWithValue("@charge_to", charges)
            newcmd.Parameters.AddWithValue("@search_value", num_code)
            newsqldr = newcmd.ExecuteReader
            newsqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & "error: " & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
        End Try
    End Sub
    Private Sub ExportToExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        'SaveFileDialog1.Title = "Save Excel File"
        'SaveFileDialog1.Filter = "Excel files (*.xls)|*.xls|Excel Files (*.xlsx)|*.xslx"
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

        Dim headerRange As Excel.Range = sheet.Range("A1:AT1")
        headerRange.HorizontalAlignment = Excel.Constants.xlCenter
        headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(&H82B1FF))
        Dim dataRange As Excel.Range = sheet.Range("A1:AT" & sheet.Rows.Count)
        dataRange.AutoFilter(1)


        ' Add headers
        sheet.Cells(1, 1) = "No."
        sheet.Cells(1, 2) = "RS DATE"
        sheet.Cells(1, 3) = "PO DATE"
        sheet.Cells(1, 4) = "WS DATE"
        sheet.Cells(1, 5) = "DR DATE"
        sheet.Cells(1, 6) = "QTY  REQUESTED"
        sheet.Cells(1, 7) = "UNIT"
        sheet.Cells(1, 8) = "ITEM NAME"
        sheet.Cells(1, 9) = "RECEIVED QTY"
        sheet.Cells(1, 10) = "WITHDRAWN QTY"
        sheet.Cells(1, 11) = "REQUESTOR"
        sheet.Cells(1, 12) = "PO NO"
        sheet.Cells(1, 13) = "WS NO"
        sheet.Cells(1, 14) = "RS NO"
        sheet.Cells(1, 15) = "RR NO"
        sheet.Cells(1, 16) = "DATE OF RR"
        sheet.Cells(1, 17) = "PO DATE NEEDED"
        sheet.Cells(1, 18) = "UNIT PRICE"
        sheet.Cells(1, 19) = "AMOUNT"
        sheet.Cells(1, 20) = "CHARGES"
        sheet.Cells(1, 21) = "LEAD DAYS RS TO PO"
        sheet.Cells(1, 22) = "LEAD DAYS PO TO RR"
        sheet.Cells(1, 23) = "SUPPLIER"
        sheet.Cells(1, 24) = "REMARKS"
        sheet.Cells(1, 25) = "TYPE OF REQUEST"
        sheet.Cells(1, 26) = "TR/INVOICE"
        sheet.Cells(1, 27) = "DR NO"
        sheet.Cells(1, 28) = "SO NO"
        sheet.Cells(1, 29) = "HAULER"
        sheet.Cells(1, 30) = "PLATE NO"
        sheet.Cells(1, 31) = "TYPE OF PURCHASE"
        sheet.Cells(1, 32) = "TERMS (days)"
        sheet.Cells(1, 33) = "DATE LOG REQUEST"
        sheet.Cells(1, 34) = "DATE LOG RECEIVED"
        sheet.Cells(1, 35) = "JO NO"
        sheet.Cells(1, 36) = "LOCATION"
        sheet.Cells(1, 37) = "PURPOSE"
        sheet.Cells(1, 38) = "VALUE"
        sheet.Cells(1, 39) = "DR QTY"
        sheet.Cells(1, 40) = "CV NO/WS NO"
        sheet.Cells(1, 41) = "RS-LIQUIDATION UPDATE LOG"

        sheet.Cells(1, 42) = "RS-LIQUIDATION UPDATE USER LOG"
        sheet.Cells(1, 43) = "RS USER LOG INPUT"
        sheet.Cells(1, 44) = "EQUIPMENT TYPE"
        sheet.Cells(1, 45) = "TYPE OF REQUEST SUB"
        sheet.Cells(1, 46) = "ACCOUNT TITLE (OTHERS)"

        Dim row1 As Integer = 2

        For Each row As DataGridViewRow In dtgSummarySupply.Rows
            If Not row.IsNewRow Then
                sheet.Cells(row1, 1) = row.Cells(0).Value.ToString()

                Dim dateString As String = row.Cells(2).Value.ToString()
                Dim dateValue As DateTime = DateTime.ParseExact(dateString, "M/d/yyyy", CultureInfo.InvariantCulture)
                sheet.Cells(row1, 2).Value = dateValue



                Dim dateString1 As String = If(row.Cells(3).Value IsNot Nothing, row.Cells(3).Value.ToString(), "")
                If Not String.IsNullOrEmpty(dateString1) Then
                    Dim dateValue1 As DateTime
                    If DateTime.TryParseExact(dateString1, "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, dateValue1) Then
                        sheet.Cells(row1, 3).Value = dateValue1
                    Else

                    End If
                Else

                End If


                Dim dateString4 As String = If(row.Cells(4).Value IsNot Nothing, row.Cells(4).Value.ToString(), "")
                If Not String.IsNullOrEmpty(dateString4) Then
                    Dim dateValue4 As DateTime
                    If DateTime.TryParseExact(dateString4, "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, dateValue4) Then
                        sheet.Cells(row1, 4).Value = dateValue4
                    Else

                    End If
                Else

                End If

                Dim dateString5 As String = If(row.Cells(5).Value IsNot Nothing, row.Cells(5).Value.ToString(), "")
                If Not String.IsNullOrEmpty(dateString5) Then
                    Dim dateValue5 As DateTime
                    If DateTime.TryParseExact(dateString5, "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, dateValue5) Then
                        sheet.Cells(row1, 5).Value = dateValue5
                    Else

                    End If
                Else

                End If

                sheet.Cells(row1, 6) = row.Cells(7).Value.ToString()
                sheet.Cells(row1, 7) = row.Cells(8).Value.ToString()
                sheet.Cells(row1, 8) = row.Cells(9).Value.ToString()
                sheet.Cells(row1, 9) = row.Cells(10).Value.ToString()
                sheet.Cells(row1, 10) = row.Cells(11).Value.ToString()
                sheet.Cells(row1, 11) = row.Cells(12).Value.ToString()
                sheet.Cells(row1, 12) = row.Cells(13).Value.ToString()
                sheet.Cells(row1, 13) = row.Cells(14).Value.ToString()
                sheet.Cells(row1, 14) = row.Cells(15).Value.ToString()
                sheet.Cells(row1, 15) = row.Cells(16).Value.ToString()

                If row.Cells(17).Value.ToString() Is "" Then
                    sheet.Cells(row1, 16) = row.Cells(17).Value.ToString()
                Else
                    Dim asd As DateTime = row.Cells(17).Value.ToString()
                    sheet.Cells(row1, 16).Value = asd
                End If

                If row.Cells(18).Value.ToString() Is "" Then
                    sheet.Cells(row1, 17) = row.Cells(18).Value.ToString()
                Else
                    Dim asd As DateTime = row.Cells(18).Value.ToString()
                    sheet.Cells(row1, 17).Value = asd
                End If


                sheet.Cells(row1, 18) = row.Cells(19).Value.ToString()
                sheet.Cells(row1, 19) = row.Cells(20).Value.ToString()
                sheet.Cells(row1, 20) = row.Cells(21).Value.ToString()
                sheet.Cells(row1, 21) = row.Cells(22).Value.ToString()
                sheet.Cells(row1, 22) = row.Cells(23).Value.ToString()
                sheet.Cells(row1, 23) = row.Cells(24).Value.ToString()
                sheet.Cells(row1, 24) = row.Cells(25).Value.ToString()
                sheet.Cells(row1, 25) = row.Cells(26).Value.ToString()
                sheet.Cells(row1, 26) = row.Cells(27).Value.ToString()
                sheet.Cells(row1, 27) = row.Cells(28).Value.ToString()
                sheet.Cells(row1, 28) = row.Cells(29).Value.ToString()
                sheet.Cells(row1, 29) = row.Cells(30).Value.ToString()
                sheet.Cells(row1, 30) = row.Cells(31).Value.ToString()
                sheet.Cells(row1, 31) = row.Cells(32).Value.ToString()
                sheet.Cells(row1, 32) = row.Cells(33).Value.ToString()


                Dim dateString6 As String = If(row.Cells(34).Value IsNot Nothing, row.Cells(34).Value.ToString(), "")
                If Not String.IsNullOrEmpty(dateString6) Then
                    Dim dateValue6 As DateTime
                    Dim formatsToTry As String() = {"M/d/yyyy", "d/M/yyyy"}

                    For Each format As String In formatsToTry
                        If DateTime.TryParseExact(dateString6, format, CultureInfo.InvariantCulture, DateTimeStyles.None, dateValue6) Then
                            sheet.Cells(row1, 33).Value = dateValue6
                            Exit For
                        End If
                    Next

                    If dateValue6 = DateTime.MinValue Then
                        Console.WriteLine("Failed to parse date: " & dateString6)
                    End If
                End If




                Dim dateString7 As String = If(row.Cells(35).Value IsNot Nothing, row.Cells(35).Value.ToString(), "")
                If Not String.IsNullOrEmpty(dateString7) Then
                    Dim dateValue7 As DateTime
                    Dim formatsToTry As String() = {"M/d/yyyy", "d/M/yyyy"}


                    For Each format As String In formatsToTry
                        If DateTime.TryParseExact(dateString7, format, CultureInfo.InvariantCulture, DateTimeStyles.None, dateValue7) Then

                            sheet.Cells(row1, 34).Value = dateValue7
                            Exit For
                        End If
                    Next


                    If dateValue7 = DateTime.MinValue Then
                        Console.WriteLine("Failed to parse date: " & dateString7)
                    End If
                End If

                sheet.Cells(row1, 35) = row.Cells(36).Value.ToString()
                sheet.Cells(row1, 36) = row.Cells(37).Value.ToString()
                sheet.Cells(row1, 37) = row.Cells(38).Value.ToString()
                sheet.Cells(row1, 38) = row.Cells(39).Value.ToString()
                sheet.Cells(row1, 39) = row.Cells(40).Value.ToString()
                sheet.Cells(row1, 40) = row.Cells(41).Value.ToString()
                'sheet.Cells(row1, 41) = row.Cells(42).Value.ToString()


                'sheet.Cells(row1, 42) = row.Cells(43).Value.ToString()



                Dim dateString66 As String = If(row.Cells(42).Value IsNot Nothing, row.Cells(42).Value.ToString(), "")
                If Not String.IsNullOrEmpty(dateString66) AndAlso dateString66.Trim() <> "" Then
                    Dim dateValue66 As DateTime = DateTime.MinValue
                    Dim formatsToTry1 As String() = {
                    "M/d/yyyy h:mm:ss tt", "d/M/yyyy h:mm:ss tt",
                    "MM/dd/yyyy h:mm:ss tt", "dd/MM/yyyy h:mm:ss tt",
                    "M/d/yyyy", "d/M/yyyy", "MM/dd/yyyy", "dd/MM/yyyy"
                }

                    For Each format1 As String In formatsToTry1
                        If DateTime.TryParseExact(dateString66, format1, CultureInfo.InvariantCulture, DateTimeStyles.None, dateValue66) Then
                            Exit For
                        End If
                    Next

                    If dateValue66 <> DateTime.MinValue Then
                        sheet.Cells(row1, 41).NumberFormat = "mm-dd-yyyy"
                        sheet.Cells(row1, 41).Value = dateValue66
                    Else
                        Console.WriteLine("Failed to parse date: " & dateString66)
                        sheet.Cells(row1, 41).Value = "Invalid Date"
                    End If
                Else
                    sheet.Cells(row1, 41).Value = ""
                End If
                sheet.Cells(row1, 42) = row.Cells(43).Value.ToString()
                sheet.Cells(row1, 43) = row.Cells(46).Value.ToString()
                sheet.Cells(row1, 44) = row.Cells(47).Value.ToString()
                sheet.Cells(row1, 45) = row.Cells(48).Value.ToString()
                sheet.Cells(row1, 46) = row.Cells(49).Value.ToString()
                row1 += 1
            End If
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

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub TableLayoutPanel3_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel3.Paint

    End Sub

    Private Sub gboxSearch_Enter(sender As Object, e As EventArgs) Handles gboxSearch.Enter

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As DialogResult

        result = MessageBox.Show("Pick [YES] if want to Report, then Pick [NO] if want Partial Report ", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        generate_records_for_report(search_code, frmDateRange.dtpStartDate.Text, frmDateRange.dtpEndDate.Text, frmDateRange.dtpStartDate.Text, frmDateRange.dtpEndDate.Text, "", frmDateRange.TextBox1.Text, frmDateRange.TextBox2.Text)

        If result = DialogResult.Yes Then
            ' User clicked Yes
            'MessageBox.Show("You clicked Yes.")
            call_generate_again(search_code, frmDateRange.dtpStartDate.Text, frmDateRange.dtpEndDate.Text, frmDateRange.dtpStartDate.Text, frmDateRange.dtpEndDate.Text, "", frmDateRange.TextBox1.Text, frmDateRange.TextBox2.Text, "Report")

            MsgBox("Successfully Reported!")
        ElseIf result = DialogResult.No Then
            call_generate_again(search_code, frmDateRange.dtpStartDate.Text, frmDateRange.dtpEndDate.Text, frmDateRange.dtpStartDate.Text, frmDateRange.dtpEndDate.Text, "", frmDateRange.TextBox1.Text, frmDateRange.TextBox2.Text, "Partial")
            MsgBox("Partial Reported!")
            ' User clicked No
            'MessageBox.Show("You clicked No.")
        Else
            MessageBox.Show("You clicked Cancel.")
        End If
    End Sub



    Private Sub call_generate_again(ByVal search_code As Integer, ByVal date_start As Date, ByVal date_end As Date, ByVal date_start_1 As Date, ByVal date_end_1 As Date, ByVal num_code As String, ByVal request_type As String, ByVal charges As String, ByVal reports As String)

        Dim sql1 As New SQLcon
        Try
            sql1.connection.Open()
            Dim sqlcomm As New SqlCommand()
            sqlcomm.Connection = sql1.connection
            sqlcomm.CommandText = "proc_generate_records_reporting"
            sqlcomm.CommandType = CommandType.StoredProcedure
            'sqlcomm.Parameters.AddWithValue("@n", 28)
            sqlcomm.Parameters.AddWithValue("@search_code", search_code)
            sqlcomm.Parameters.AddWithValue("@reported", "Reported")
            sqlcomm.Parameters.Add("@date_start", SqlDbType.Date).Value = date_start
            sqlcomm.Parameters.Add("@date_end", SqlDbType.Date).Value = date_end
            sqlcomm.Parameters.Add("@date_start_1", SqlDbType.Date).Value = date_start
            sqlcomm.Parameters.Add("@date_end_1", SqlDbType.Date).Value = date_end
            sqlcomm.Parameters.AddWithValue("@num_code", num_code)
            sqlcomm.Parameters.AddWithValue("@request_type", request_type)
            sqlcomm.Parameters.AddWithValue("@charge_to", charges)
            sqlcomm.Parameters.AddWithValue("@search_value", num_code)
            sqlcomm.CommandTimeout = 0



            'sqlcomm.Parameters.AddWithValue("@sum_date", DateTime.Parse(DTP_Allowance.Text))
            'sqlcomm.Parameters.AddWithValue("@sum_name", txtName.Text)
            'sqlcomm.Parameters.AddWithValue("@sum_desig", get_id_designation(cmbDesignation.Text))
            'sqlcomm.Parameters.AddWithValue("@sum_location", txtLocation.Text)
            'sqlcomm.Parameters.AddWithValue("@sum_cate", cmbcategory1.Text)
            'sqlcomm.Parameters.AddWithValue("@sum_subcat", cmbcategory2.Text)
            sqlcomm.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "Supply INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sql1.connection.Close()
        End Try
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub
End Class