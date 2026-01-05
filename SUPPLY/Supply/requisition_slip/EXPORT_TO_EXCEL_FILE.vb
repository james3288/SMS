Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop
Imports System.ComponentModel
Public Class EXPORT_TO_EXCEL_FILE

    Private myListView As New ListView
    Private ListViewData As New List(Of Dictionary(Of String, String))
    Private myFileName As String
    Private export_bg As New BackgroundWorker
    Private export_bg1, export_bg2 As New BackgroundWorker
    Private cWhatToExport As String

    Private cListOfPoDateLogPrice As New Object
    Private cFileName As String
    Private cProgressBar As New ProgressBar

    Public Sub Export_Rs_to_Excel_File(listview As ListView)

        ' If the listview parameter is provided, use it; otherwise, use the class-level myListView
        myListView = listview

        ' Clear the existing ListViewData list before exporting new data
        ListViewData.Clear()

        ' Iterate through the items in the ListView and extract data to populate the ListViewData list
        For Each item As ListViewItem In myListView.Items
            Dim dataDictionary As New Dictionary(Of String, String)

            With dataDictionary
                .Add("rs_id", item.Text)
                .Add("RS NO.", item.SubItems(1).Text)
                .Add("DR NO.", item.SubItems(21).Text)
                .Add("WS NO./RR NO.", item.SubItems(36).Text)
                .Add("REQUEST DATE", item.SubItems(2).Text)
                .Add("DATE NEEDED", item.SubItems(7).Text)
                .Add("J.O NO.", item.SubItems(3).Text)
                .Add("ITEM DESCRIPTION", item.SubItems(4).Text)
                .Add("CONS.ITEM", item.SubItems(29).Text)
                .Add("CONS.ITEM DESC", item.SubItems(30).Text)
                .Add("QTY TAKE OFF DESCRIPTION", item.SubItems(37).Text)
                .Add("RS QTY", item.SubItems(5).Text)
                .Add("PO/CV/WS QTY RELEASED", item.SubItems(22).Text)
                .Add("RR/WS QTY RECEIVED", item.SubItems(23).Text)
                .Add("DR QTY (out/in)", item.SubItems(32).Text)
                .Add("PRICE", item.SubItems(43).Text)
                .Add("UNIT", item.SubItems(6).Text)
                .Add("TYPE OF REQUEST", item.SubItems(8).Text)
                .Add("IN/OUT", item.SubItems(9).Text)
                .Add("PO/CV STATUS", item.SubItems(10).Text)
                .Add("RR STATUS", item.SubItems(11).Text)
                .Add("WS STATUS", item.SubItems(12).Text)
                .Add("CHARGE TO", item.SubItems(2).Text)
                .Add("LOCATION", item.SubItems(20).Text)
                .Add("DATE LOG", item.SubItems(16).Text)
                .Add("TYPE OF CHARGES", item.SubItems(17).Text)
                .Add("TYPE OF PURCHASING", item.SubItems(18).Text)
                .Add("REQUESTED BY", item.SubItems(28).Text)
                .Add("WAREHOUSE/QY AREA", item.SubItems(33).Text)
                .Add("USERNAME", item.SubItems(24).Text)

                Select Case item.BackColor
                    Case Color.Lime
                        .Add("row_type", "Main RS")
                    Case Color.DarkGreen
                        .Add("row_type", "Sub RS")
                    Case Color.LightGreen
                        .Add("row_type", "withdrawal/purchaseorder")
                    Case Color.LightPink
                        .Add("row_type", "receiving")
                    Case Color.LightYellow
                        .Add("row_type", "dr")

                End Select
            End With

            ListViewData.Add(dataDictionary)
        Next
    End Sub

    Public Sub _Export_To_Excel(Optional listOfPoDateLogPrice As Object = Nothing, Optional FileName As String = "", Optional myProgressbar As ProgressBar = Nothing)

        cListOfPoDateLogPrice = listOfPoDateLogPrice
        cFileName = FileName
        cProgressBar = myProgressbar


        If cProgressBar.InvokeRequired Then
            cProgressBar.Invoke(Sub()
                                    cProgressBar.Maximum = cListOfPoDateLogPrice.count
                                End Sub)
        End If

        export_now3()


    End Sub


    Public Sub CheckListViewData()
        ' Assuming ListViewData contains data (already populated)
        Dim result As String = ""

        ' Loop through the list of dictionaries (ListViewData)
        For Each dataDictionary As Dictionary(Of String, String) In ListViewData
            ' Loop through the key-value pairs in each dictionary
            For Each kvp As KeyValuePair(Of String, String) In dataDictionary
                Dim key As String = kvp.Key
                Dim value As String = kvp.Value
                ' Print or display the key-value pair data
                result &= $"Key: {key}, Value: {value}" & vbCrLf
            Next
            ' Add a separator line between each dictionary data for better visibility
            result &= "--------------" & vbCrLf & vbCrLf
        Next

        'MsgBox(result)
        ExportDataToExcel()
    End Sub
    Private Sub ExportDataToExcel()

        Dim excelApp As New Application()
        Dim workbook As Workbook = excelApp.Workbooks.Add()
        Dim worksheet As Worksheet = workbook.Sheets(1)

        ' Write headers to the first row of the worksheet
        Dim headerRow As Dictionary(Of String, String) = ListViewData.FirstOrDefault()
        If headerRow IsNot Nothing Then
            Dim colIndex As Integer = 1
            For Each key As String In headerRow.Keys
                worksheet.Cells(1, colIndex).Value = key
                ' Apply style to the header row (e.g., bold font, background color, etc.)
                worksheet.Cells(1, colIndex).Font.Bold = True
                'worksheet.Cells(1, colIndex).Interior.Color = RGB(220, 220, 220) ' Light Gray
                colIndex += 1
            Next
        End If

        ' Write data to the worksheet
        Dim rowIndex As Integer = 2
        For Each dataDictionary As Dictionary(Of String, String) In ListViewData
            Dim colIndex As Integer = 1
            For Each value As String In dataDictionary.Values
                worksheet.Cells(rowIndex, colIndex).Value = IIf(value.Contains("=>"), value.Replace("=>", ""), value)

                colIndex += 1

            Next

            ' Apply conditional formatting to the row based on the value in the "row_type" column
            Dim rsNoCellValue As String = ""

            If dataDictionary.TryGetValue("row_type", rsNoCellValue) Then
                If rsNoCellValue = "Main RS" Then
                    Dim range As Range = worksheet.Range(worksheet.Cells(rowIndex, 1), worksheet.Cells(rowIndex, headerRow.Count))
                    range.Interior.Color = ColorTranslator.ToOle(Color.Lime)  ' Change the color to the desired one (e.g., Lime)

                ElseIf rsNoCellValue = "Sub RS" Then
                    Dim range As Range = worksheet.Range(worksheet.Cells(rowIndex, 1), worksheet.Cells(rowIndex, headerRow.Count))
                    range.Interior.Color = ColorTranslator.ToOle(Color.DarkGreen)

                ElseIf rsNoCellValue = "withdrawal/purchaseorder" Then
                    Dim range As Range = worksheet.Range(worksheet.Cells(rowIndex, 1), worksheet.Cells(rowIndex, headerRow.Count))
                    range.Interior.Color = ColorTranslator.ToOle(Color.LightGreen)

                ElseIf rsNoCellValue = "receiving" Then
                    Dim range As Range = worksheet.Range(worksheet.Cells(rowIndex, 1), worksheet.Cells(rowIndex, headerRow.Count))
                    range.Interior.Color = ColorTranslator.ToOle(Color.LightPink)

                ElseIf rsNoCellValue = "dr" Then
                    Dim range As Range = worksheet.Range(worksheet.Cells(rowIndex, 1), worksheet.Cells(rowIndex, headerRow.Count))
                    range.Interior.Color = ColorTranslator.ToOle(Color.LightYellow)

                End If
            End If

            rowIndex += 1
        Next

        ' Get the range of data (assuming all data is contiguous)
        Dim startCell As Range = worksheet.Cells(1, 1)
        Dim endCell As Range = worksheet.Cells(rowIndex - 1, headerRow.Count)

        ' Create a table from the range
        Dim tableRange As Range = worksheet.Range(startCell, endCell)
        Dim table As ListObject = worksheet.ListObjects.Add(XlListObjectSourceType.xlSrcRange, tableRange, , XlYesNoGuess.xlYes)
        table.Name = "MyTable" ' Optional: You can give a name to the table

        ' Apply a built-in table style
        table.TableStyle = "TableStyleLight9" ' You can use other built-in styles as needed


        Dim SaveFileDialog1 As New SaveFileDialog
        SaveFileDialog1.Title = "Save Excel File"
        SaveFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx"
        SaveFileDialog1.ShowDialog()

        'exit if no file selected
        If SaveFileDialog1.FileName = "" Then
            Exit Sub
        End If

        ' Save the workbook to a file
        'Dim filePath As String = "D:\file.xlsx" ' Replace with your desired file path
        workbook.SaveAs(SaveFileDialog1.FileName)

        ' Clean up
        workbook.Close()
        Marshal.ReleaseComObject(worksheet)
        Marshal.ReleaseComObject(workbook)
        excelApp.Quit()
        Marshal.ReleaseComObject(excelApp)

        ' Display a message or perform other actions upon successful export
    End Sub


    Sub New()

        AddHandler export_bg.DoWork, AddressOf export_bg_DoWork
        AddHandler export_bg.RunWorkerCompleted, AddressOf export_bg_RunWorkerCompleted

        AddHandler export_bg1.DoWork, AddressOf export_bg1_DoWork
        AddHandler export_bg1.RunWorkerCompleted, AddressOf export_bg1_RunWorkerCompleted

        AddHandler export_bg2.DoWork, AddressOf export_bg2_DoWork
        AddHandler export_bg2.RunWorkerCompleted, AddressOf export_bg2_RunWorkerCompleted

    End Sub

    Public Sub _initialize(Optional lView As ListView = Nothing, Optional filename As String = "")

        myListView = lView
        myFileName = filename

        export_bg.WorkerSupportsCancellation = True
        export_bg.RunWorkerAsync()

    End Sub

    Public Sub _initialize_po_export(Optional lView As ListView = Nothing, Optional filename As String = "")
        myListView = lView
        myFileName = filename

        export_bg1.WorkerSupportsCancellation = True
        export_bg1.RunWorkerAsync()
    End Sub

    Public Sub _initialize_ws_export(Optional lView As ListView = Nothing, Optional filename As String = "", Optional whatToExpert As String = "")
        myListView = lView
        myFileName = filename
        cWhatToExport = whatToExpert

        export_bg2.WorkerSupportsCancellation = True
        export_bg2.RunWorkerAsync()
    End Sub

    Private Sub export_bg_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)

        Dim trd As Threading.Thread
        trd = New Threading.Thread(AddressOf export_data_to_excel)
        trd.Start()
        trd.Join()

    End Sub

    Private Sub export_bg1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)

        Dim trd As Threading.Thread
        trd = New Threading.Thread(AddressOf export_data_to_excel1)
        trd.Start()
        trd.Join()

    End Sub

    Private Sub export_bg2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)

        Dim trd As Threading.Thread
        trd = New Threading.Thread(AddressOf export_data_to_excel1)
        trd.Start()
        trd.Join()

    End Sub

    Private Sub export_bg_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        MessageBox.Show("Exported successfully...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub export_bg1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        MessageBox.Show("Exported successfully...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub export_bg2_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        MessageBox.Show("WS Exported successfully...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub export_data_to_excel()

        If myListView.InvokeRequired Then
            myListView.Invoke(Sub()
                                  export_now()
                              End Sub)
        Else
            export_now()
        End If
    End Sub

    Private Sub export_data_to_excel1()

        If myListView.InvokeRequired Then
            myListView.Invoke(Sub()
                                  If cWhatToExport = "" Then
                                      export_now1()
                                  ElseIf cWhatToExport = "withdrawal" Then
                                      export_now2()
                                  End If

                              End Sub)
        Else
            export_now1()
        End If
    End Sub

    Private Sub export_now()
        Dim xlApp As New Excel.Application
        Try
            'create objects to interface to Excel
            Dim xls As New Excel.Application
            Dim book As Excel.Workbook
            Dim sheet As Excel.Worksheet

            Dim chartRange As Excel.Range
            Dim chartRange1 As Excel.Range
            Dim chartRange2 As Excel.Range

            'create a workbook and get reference to first worksheet
            xls.Workbooks.Add()
            book = xls.ActiveWorkbook
            sheet = book.ActiveSheet
            'step through rows and columns and copy data to worksheet
            Dim row As Integer = 2
            Dim col As Integer = 1
            Dim c As Integer = 1
            Dim excel_array() As String = New String() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC"}
            Dim excel_index As Integer = 1
            Dim iii As Integer = 0

            sheet.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange, sheet.Range("$A$1:$AB$1"), , Excel.XlYesNoGuess.xlYes).Name = "Table1"

            '~~> Format the table
            sheet.ListObjects("Table1").TableStyle = "TableStyleLight9"

            sheet.Cells(1, 1) = "RS No."
            sheet.Cells(1, 2) = "DR NO."
            sheet.Cells(1, 3) = "WS NO./RR NO."
            sheet.Cells(1, 4) = "REQUEST DATE"
            sheet.Cells(1, 5) = "DATE NEEDED"
            sheet.Cells(1, 6) = "J.O NO."
            sheet.Cells(1, 7) = "ITEM DESCRIPTION"
            sheet.Cells(1, 8) = "CONS.ITEM"
            sheet.Cells(1, 9) = "CONS.ITEM DESC."
            sheet.Cells(1, 10) = "QTY TAKE OFF DESCRIPTION"
            sheet.Cells(1, 11) = "RS QTY"
            sheet.Cells(1, 12) = "PO/CV/WS QTY RELEASED"
            sheet.Cells(1, 13) = "RR/WS QTY RECEIVED"
            sheet.Cells(1, 14) = "DR QTY (out/in)"
            sheet.Cells(1, 15) = "PRICE"
            sheet.Cells(1, 16) = "UNIT"
            sheet.Cells(1, 17) = "TYPE OF REQUEST"
            sheet.Cells(1, 18) = "IN/OUT"
            sheet.Cells(1, 19) = "PO/CV STATUS"
            sheet.Cells(1, 20) = "RR STATUS"
            sheet.Cells(1, 21) = "WS STATUS"
            sheet.Cells(1, 22) = "CHARGE TO"
            sheet.Cells(1, 23) = "LOCATION"
            sheet.Cells(1, 24) = "DATE LOG"
            sheet.Cells(1, 25) = "TYPE OF CHARGES"
            sheet.Cells(1, 26) = "TYPE OF PURCHASING"
            sheet.Cells(1, 27) = "REQUESTED BY"
            sheet.Cells(1, 28) = "WAREHOUSE/QY AREA"
            sheet.Cells(1, 29) = "USERNAME"


            'For Each item As ListViewItem In LVLEquipList.Items

            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Dim col1, row1 As Integer
            row1 = 2
            col1 = 1


            chartRange1 = sheet.Range(excel_array(3) & 1, excel_array(3) & 1)
            chartRange1.EntireColumn.NumberFormat = "@"

            For Each rows As ListViewItem In myListView.Items
                If rows.Selected = True Then

                    sheet.Cells(row1, 1) = rows.SubItems(1).Text
                    sheet.Cells(row1, 2) = rows.SubItems(21).Text
                    sheet.Cells(row1, 3) = rows.SubItems(36).Text
                    'sheet.Cells(row1, 4) = Format(Convert.ToDateTime(rows.SubItems(2).Text), "M/d/yyyy")

                    If IsDate(rows.SubItems(2).Text) = True Then
                        sheet.Cells(row1, 4) = DateTime.ParseExact(rows.SubItems(2).Text, "M/d/yyyy", Globalization.CultureInfo.InvariantCulture)
                    Else
                        sheet.Cells(row1, 4) = rows.SubItems(2).Text
                    End If


                    If IsDate(rows.SubItems(7).Text) = True Then
                        sheet.Cells(row1, 5) = DateTime.ParseExact(rows.SubItems(7).Text, "M/d/yyyy", Globalization.CultureInfo.InvariantCulture)
                    Else
                        sheet.Cells(row1, 5) = rows.SubItems(7).Text
                    End If

                    'sheet.Cells(row1, 5) = date_needed
                    sheet.Cells(row1, 6) = rows.SubItems(3).Text
                    sheet.Cells(row1, 7) = rows.SubItems(4).Text
                    sheet.Cells(row1, 8) = rows.SubItems(29).Text
                    sheet.Cells(row1, 9) = rows.SubItems(30).Text
                    sheet.Cells(row1, 10) = rows.SubItems(37).Text
                    sheet.Cells(row1, 11) = rows.SubItems(5).Text
                    sheet.Cells(row1, 12) = rows.SubItems(22).Text
                    sheet.Cells(row1, 13) = rows.SubItems(23).Text
                    sheet.Cells(row1, 14) = rows.SubItems(32).Text


                    Dim subItemIndex As Integer = 43
                    Dim subItemsCount As Integer = rows.SubItems.Count

                    If subItemIndex >= 0 AndAlso subItemIndex < subItemsCount Then
                        ' The index is valid, you can safely access the subitem
                        sheet.Cells(row1, 15) = rows.SubItems(subItemIndex).Text
                    Else
                        ' The index is invalid, handle the error or take appropriate action
                        ' In this example, we'll use a default value or leave the cell empty
                        sheet.Cells(row1, 15) = "0" ' Or sheet.Cells(row1, 15).Value = "" to leave it empty
                    End If

                    sheet.Cells(row1, 16) = rows.SubItems(6).Text
                    sheet.Cells(row1, 17) = rows.SubItems(8).Text
                    sheet.Cells(row1, 18) = rows.SubItems(9).Text
                    sheet.Cells(row1, 19) = rows.SubItems(10).Text
                    sheet.Cells(row1, 20) = rows.SubItems(11).Text
                    sheet.Cells(row1, 21) = rows.SubItems(12).Text
                    sheet.Cells(row1, 22) = rows.SubItems(13).Text
                    sheet.Cells(row1, 23) = rows.SubItems(14).Text
                    sheet.Cells(row1, 24) = rows.SubItems(16).Text
                    sheet.Cells(row1, 25) = rows.SubItems(17).Text
                    sheet.Cells(row1, 26) = rows.SubItems(18).Text
                    sheet.Cells(row1, 27) = rows.SubItems(28).Text
                    sheet.Cells(row1, 28) = rows.SubItems(33).Text
                    sheet.Cells(row1, 29) = rows.SubItems(24).Text

                    chartRange1 = sheet.Range(excel_array(3) & 2, excel_array(3) & 2)
                    chartRange1.EntireColumn.NumberFormat = "@"

                    chartRange = sheet.Range("A" & row1, "AC" & row1)


                    With chartRange

                        .HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter
                        .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                        .Font.Size = 12
                        .Font.FontStyle = "Arial"
                        .EntireColumn.ColumnWidth = 15
                        '.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightYellow)

                        .Borders(Excel.XlBordersIndex.xlEdgeLeft).Weight = 2
                        .Borders(Excel.XlBordersIndex.xlEdgeRight).Weight = 2
                        .Borders(Excel.XlBordersIndex.xlEdgeTop).Weight = 2
                        .Borders(Excel.XlBordersIndex.xlEdgeBottom).Weight = 2
                        'chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)

                        '.Range("F" & col1).Formula = "=(E" & col1 & "-D" & col1 & ")*24*60/60"
                        .EntireColumn.AutoFit()

                    End With

                    If rows.BackColor = Color.DarkGreen Then
                        sheet.Range("A" & row1, "AC" & row1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkGreen)
                        sheet.Range("A" & row1, "AC" & row1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                    ElseIf rows.BackColor = Color.LightGreen Then
                        sheet.Range("A" & row1, "AC" & row1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen)
                        sheet.Range("A" & row1, "AC" & row1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                    ElseIf rows.BackColor = Color.LightYellow Then
                        sheet.Range("A" & row1, "AC" & row1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightYellow)
                        sheet.Range("A" & row1, "AC" & row1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                    End If

                    row1 += 1

                End If
            Next
            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


            'save the workbook and clean up
            book.SaveAs(myFileName)
            xls.Workbooks.Close()
            xls.Quit()
            releaseObject(sheet)
            releaseObject(book)
            releaseObject(xls)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub 'EXPORT BY PO DATE


    Private Sub export_now1() 'EXPORT BY DATELOG
        Dim xlApp As New Excel.Application
        Try
            'create objects to interface to Excel
            Dim xls As New Excel.Application
            Dim book As Excel.Workbook
            Dim sheet As Excel.Worksheet

            Dim chartRange As Excel.Range
            Dim chartRange1 As Excel.Range

            'create a workbook and get reference to first worksheet
            xls.Workbooks.Add()
            book = xls.ActiveWorkbook
            sheet = book.ActiveSheet

            'step through rows and columns and copy data to worksheet
            Dim row As Integer = 2
            Dim col As Integer = 1
            Dim c As Integer = 1
            Dim excel_array() As String = New String() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W"}
            Dim excel_index As Integer = 1
            Dim iii As Integer = 0

            sheet.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange, sheet.Range("$A$1:$W$1"), , Excel.XlYesNoGuess.xlYes).Name = "Table1"

            '~~> Format the table
            sheet.ListObjects("Table1").TableStyle = "TableStyleLight9"

            sheet.Cells(1, 1) = "PO NO."
            sheet.Cells(1, 2) = "RS NO."
            sheet.Cells(1, 3) = "PO DATE"
            sheet.Cells(1, 4) = "SUPPLIER NAME"
            sheet.Cells(1, 5) = "ITEM NAME"
            sheet.Cells(1, 6) = "ITEM DESCRIPTION"
            sheet.Cells(1, 7) = "TYPE OR REQUEST"
            sheet.Cells(1, 8) = "QTY"
            sheet.Cells(1, 9) = "UNIT"
            sheet.Cells(1, 10) = "UNIT PRICE"
            sheet.Cells(1, 11) = "TOTAL AMOUNT"
            sheet.Cells(1, 12) = "INSTRUCTIONS"
            sheet.Cells(1, 13) = "ADDRESS"
            sheet.Cells(1, 14) = "TERMS"
            sheet.Cells(1, 15) = "CHARGES"
            sheet.Cells(1, 16) = "DATE NEEDED"
            sheet.Cells(1, 17) = "PREPARED BY"
            sheet.Cells(1, 18) = "CHECKED BY"
            sheet.Cells(1, 19) = "APPROVED BY"
            sheet.Cells(1, 20) = "IN OUT"
            sheet.Cells(1, 21) = "RS DATE"
            sheet.Cells(1, 22) = "PRINT STATUS"
            sheet.Cells(1, 23) = "USERS"

            'For Each item As ListViewItem In LVLEquipList.Items

            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Dim col1, row1 As Integer
            row1 = 2
            col1 = 1

            chartRange1 = sheet.Range(excel_array(3) & 1, excel_array(3) & 1)
            chartRange1.EntireColumn.NumberFormat = "@"

            For Each rows As ListViewItem In myListView.Items
                'If rows.Selected = True Then

                sheet.Cells(row1, 1) = rows.SubItems(1).Text 'PO NO
                sheet.Cells(row1, 2) = rows.SubItems(2).Text 'RS NO
                'sheet.Cells(row1, 4) = Format(Convert.ToDateTime(rows.SubItems(2).Text), "M/d/yyyy")

                'PO DATE
                If IsDate(rows.SubItems(3).Text) = True Then
                    sheet.Cells(row1, 3) = DateTime.ParseExact(rows.SubItems(3).Text, "M/d/yyyy", Globalization.CultureInfo.InvariantCulture)
                Else
                    sheet.Cells(row1, 3) = rows.SubItems(3).Text
                End If

                'DATE NEEDED
                If IsDate(rows.SubItems(16).Text) = True Then
                    sheet.Cells(row1, 16) = DateTime.ParseExact(rows.SubItems(16).Text, "M/d/yyyy", Globalization.CultureInfo.InvariantCulture)
                Else
                    sheet.Cells(row1, 16) = rows.SubItems(16).Text
                End If

                'RS DATE
                If IsDate(rows.SubItems(29).Text) = True Then
                    sheet.Cells(row1, 21) = DateTime.ParseExact(rows.SubItems(29).Text, "M/d/yyyy", Globalization.CultureInfo.InvariantCulture)
                Else
                    sheet.Cells(row1, 21) = rows.SubItems(29).Text
                End If

                sheet.Cells(row1, 4) = rows.SubItems(4).Text 'SUPPLIER NAME
                sheet.Cells(row1, 5) = rows.SubItems(5).Text 'ITEM NAME
                sheet.Cells(row1, 6) = rows.SubItems(6).Text 'ITEM DESC
                sheet.Cells(row1, 7) = rows.SubItems(30).Text 'TYPE OF REQUEST
                sheet.Cells(row1, 8) = rows.SubItems(7).Text 'QTY
                sheet.Cells(row1, 9) = rows.SubItems(8).Text 'UNIT
                sheet.Cells(row1, 10) = rows.SubItems(9).Text 'UNIT PRICE
                sheet.Cells(row1, 11) = rows.SubItems(10).Text 'TOTAL AMOUNT
                sheet.Cells(row1, 12) = rows.SubItems(12).Text 'INSTRUCTIONS
                sheet.Cells(row1, 13) = rows.SubItems(13).Text 'ADDRESS
                sheet.Cells(row1, 14) = rows.SubItems(14).Text 'TERMS
                sheet.Cells(row1, 15) = rows.SubItems(15).Text 'CHARGES
                sheet.Cells(row1, 16) = rows.SubItems(16).Text 'DATE NEEDED
                sheet.Cells(row1, 17) = rows.SubItems(17).Text 'PREPARED BY
                sheet.Cells(row1, 18) = rows.SubItems(18).Text 'CHECKED BY
                sheet.Cells(row1, 19) = rows.SubItems(19).Text 'APPROVED BY
                sheet.Cells(row1, 20) = rows.SubItems(23).Text 'IN OUT
                sheet.Cells(row1, 21) = rows.SubItems(29).Text 'RS DATE
                sheet.Cells(row1, 22) = rows.SubItems(25).Text 'PRINT STATUS
                sheet.Cells(row1, 23) = rows.SubItems(28).Text 'USERS


                '    Dim subItemIndex As Integer = 43
                '    Dim subItemsCount As Integer = rows.SubItems.Count

                '    If subItemIndex >= 0 AndAlso subItemIndex < subItemsCount Then
                '        ' The index is valid, you can safely access the subitem
                '        sheet.Cells(row1, 15) = rows.SubItems(subItemIndex).Text
                '    Else
                '        ' The index is invalid, handle the error or take appropriate action
                '        ' In this example, we'll use a default value or leave the cell empty
                '        sheet.Cells(row1, 15) = "0" ' Or sheet.Cells(row1, 15).Value = "" to leave it empty
                '    End If

                '    sheet.Cells(row1, 16) = rows.SubItems(6).Text
                '    sheet.Cells(row1, 17) = rows.SubItems(8).Text
                '    sheet.Cells(row1, 18) = rows.SubItems(9).Text
                '    sheet.Cells(row1, 19) = rows.SubItems(10).Text
                '    sheet.Cells(row1, 20) = rows.SubItems(11).Text
                '    sheet.Cells(row1, 21) = rows.SubItems(12).Text
                '    sheet.Cells(row1, 22) = rows.SubItems(13).Text
                '    sheet.Cells(row1, 23) = rows.SubItems(14).Text
                '    sheet.Cells(row1, 25) = rows.SubItems(17).Text
                '    sheet.Cells(row1, 26) = rows.SubItems(18).Text
                '    sheet.Cells(row1, 27) = rows.SubItems(28).Text
                '    sheet.Cells(row1, 28) = rows.SubItems(33).Text
                '    sheet.Cells(row1, 29) = rows.SubItems(24).Text

                chartRange1 = sheet.Range(excel_array(3) & 2, excel_array(3) & 2)
                chartRange1.EntireColumn.NumberFormat = "@"

                chartRange = sheet.Range("A" & row1, "W" & row1)


                With chartRange

                    .HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter
                    .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    .Font.Size = 12
                    .Font.FontStyle = "Arial"
                    .EntireColumn.ColumnWidth = 15
                    '.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightYellow)

                    .Borders(Excel.XlBordersIndex.xlEdgeLeft).Weight = 2
                    .Borders(Excel.XlBordersIndex.xlEdgeRight).Weight = 2
                    .Borders(Excel.XlBordersIndex.xlEdgeTop).Weight = 2
                    .Borders(Excel.XlBordersIndex.xlEdgeBottom).Weight = 2
                    'chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)

                    '.Range("F" & col1).Formula = "=(E" & col1 & "-D" & col1 & ")*24*60/60"
                    .EntireColumn.AutoFit()

                End With

                row1 += 1

                'End If
            Next
            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


            'save the workbook and clean up
            book.SaveAs(myFileName)
            xls.Workbooks.Close()
            xls.Quit()
            releaseObject(sheet)
            releaseObject(book)
            releaseObject(xls)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub export_now2()
        Dim xlApp As New Excel.Application
        Try
            'create objects to interface to Excel
            Dim xls As New Excel.Application
            Dim book As Excel.Workbook
            Dim sheet As Excel.Worksheet

            Dim chartRange As Excel.Range
            Dim chartRange1 As Excel.Range

            'create a workbook and get reference to first worksheet
            xls.Workbooks.Add()
            book = xls.ActiveWorkbook
            sheet = book.ActiveSheet

            'step through rows and columns and copy data to worksheet
            Dim row As Integer = 2
            Dim col As Integer = 1
            Dim c As Integer = 1
            Dim excel_array() As String = New String() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q"}
            Dim excel_index As Integer = 1
            Dim iii As Integer = 0

            sheet.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange, sheet.Range("$A$1:$Q$1"), , Excel.XlYesNoGuess.xlYes).Name = "Table1"

            '~~> Format the table
            sheet.ListObjects("Table1").TableStyle = "TableStyleLight9"

            sheet.Cells(1, 1) = "Date Withdrawn"
            sheet.Cells(1, 2) = "RS_NO"
            sheet.Cells(1, 3) = "WS NO"
            sheet.Cells(1, 4) = "Item Name"
            sheet.Cells(1, 5) = "Quantity"
            sheet.Cells(1, 6) = "Unit Price"
            sheet.Cells(1, 7) = "Amount"
            sheet.Cells(1, 8) = "Unit"
            sheet.Cells(1, 9) = "Item Description"
            sheet.Cells(1, 10) = "Withdrawn From"
            sheet.Cells(1, 11) = "Withdrawn By"
            sheet.Cells(1, 12) = "Released By"
            sheet.Cells(1, 13) = "Status"
            sheet.Cells(1, 14) = "Charge To"
            sheet.Cells(1, 15) = "Remarks"
            sheet.Cells(1, 16) = "DR OPTION"
            sheet.Cells(1, 17) = "Purpose"

            'For Each item As ListViewItem In LVLEquipList.Items

            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Dim col1, row1 As Integer
            row1 = 2
            col1 = 1

            chartRange1 = sheet.Range(excel_array(3) & 1, excel_array(3) & 1)
            chartRange1.EntireColumn.NumberFormat = "@"

            For Each rows As ListViewItem In myListView.Items
                ''If rows.Selected = True Then

                'sheet.Cells(row1, 1) = rows.SubItems(1).Text 'PO NO
                'sheet.Cells(row1, 2) = rows.SubItems(2).Text 'RS NO
                ''sheet.Cells(row1, 4) = Format(Convert.ToDateTime(rows.SubItems(2).Text), "M/d/yyyy")

                ''PO DATE
                'If IsDate(rows.SubItems(3).Text) = True Then
                '    sheet.Cells(row1, 3) = DateTime.ParseExact(rows.SubItems(3).Text, "M/d/yyyy", Globalization.CultureInfo.InvariantCulture)
                'Else
                '    sheet.Cells(row1, 3) = rows.SubItems(3).Text
                'End If

                ''DATE NEEDED
                'If IsDate(rows.SubItems(16).Text) = True Then
                '    sheet.Cells(row1, 16) = DateTime.ParseExact(rows.SubItems(16).Text, "M/d/yyyy", Globalization.CultureInfo.InvariantCulture)
                'Else
                '    sheet.Cells(row1, 16) = rows.SubItems(16).Text
                'End If

                ''RS DATE
                'If IsDate(rows.SubItems(29).Text) = True Then
                '    sheet.Cells(row1, 21) = DateTime.ParseExact(rows.SubItems(29).Text, "M/d/yyyy", Globalization.CultureInfo.InvariantCulture)
                'Else
                '    sheet.Cells(row1, 21) = rows.SubItems(29).Text
                'End If

                sheet.Cells(row1, 1) = DateTime.ParseExact(rows.SubItems(3).Text, "M/d/yyyy", Globalization.CultureInfo.InvariantCulture)
                sheet.Cells(row1, 2) = rows.SubItems(2).Text
                sheet.Cells(row1, 3) = rows.SubItems(1).Text
                sheet.Cells(row1, 4) = rows.SubItems(4).Text
                sheet.Cells(row1, 5) = rows.SubItems(5).Text
                sheet.Cells(row1, 6) = rows.SubItems(7).Text
                sheet.Cells(row1, 7) = rows.SubItems(8).Text
                sheet.Cells(row1, 8) = rows.SubItems(6).Text
                sheet.Cells(row1, 9) = rows.SubItems(9).Text
                sheet.Cells(row1, 10) = rows.SubItems(10).Text
                sheet.Cells(row1, 11) = rows.SubItems(11).Text
                sheet.Cells(row1, 12) = rows.SubItems(12).Text
                sheet.Cells(row1, 13) = rows.SubItems(13).Text
                sheet.Cells(row1, 14) = rows.SubItems(14).Text
                sheet.Cells(row1, 15) = rows.SubItems(19).Text
                sheet.Cells(row1, 16) = rows.SubItems(20).Text
                sheet.Cells(row1, 17) = rows.SubItems(21).Text


                chartRange1 = sheet.Range(excel_array(3) & 2, excel_array(3) & 2)
                chartRange1.EntireColumn.NumberFormat = "@"

                chartRange = sheet.Range("A" & row1, "Q" & row1)


                With chartRange

                    .HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter
                    .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    .Font.Size = 12
                    .Font.FontStyle = "Arial"
                    .EntireColumn.ColumnWidth = 15
                    '.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightYellow)

                    .Borders(Excel.XlBordersIndex.xlEdgeLeft).Weight = 2
                    .Borders(Excel.XlBordersIndex.xlEdgeRight).Weight = 2
                    .Borders(Excel.XlBordersIndex.xlEdgeTop).Weight = 2
                    .Borders(Excel.XlBordersIndex.xlEdgeBottom).Weight = 2
                    'chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)

                    '.Range("F" & col1).Formula = "=(E" & col1 & "-D" & col1 & ")*24*60/60"
                    .EntireColumn.AutoFit()

                End With

                row1 += 1

                'End If
            Next
            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


            'save the workbook and clean up
            book.SaveAs(myFileName)
            xls.Workbooks.Close()
            xls.Quit()
            releaseObject(sheet)
            releaseObject(book)
            releaseObject(xls)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub export_now3() 'EXPORT BY DATELOG AND PRICE
        Dim xlApp As New Excel.Application
        Try
            'create objects to interface to Excel
            Dim xls As New Excel.Application
            Dim book As Excel.Workbook
            Dim sheet As Excel.Worksheet

            Dim chartRange As Excel.Range
            Dim chartRange1 As Excel.Range

            'create a workbook and get reference to first worksheet
            xls.Workbooks.Add()
            book = xls.ActiveWorkbook
            sheet = book.ActiveSheet
            'step through rows and columns and copy data to worksheet
            Dim row As Integer = 2
            Dim col As Integer = 1
            Dim c As Integer = 1
            Dim excel_array() As String = New String() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W"}
            Dim excel_index As Integer = 1
            Dim iii As Integer = 0

            sheet.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange, sheet.Range("$A$1:$M$1"), , Excel.XlYesNoGuess.xlYes).Name = "Table1"

            '~~> Format the table
            sheet.ListObjects("Table1").TableStyle = "TableStyleLight9"

            sheet.Cells(1, 1) = "PO NO."
            sheet.Cells(1, 2) = "RS NO."
            sheet.Cells(1, 3) = "PO DATE"
            sheet.Cells(1, 4) = "SUPPLIER NAME"
            sheet.Cells(1, 5) = "ITEM NAME"
            sheet.Cells(1, 6) = "ITEM DESCRIPTION"
            sheet.Cells(1, 7) = "TYPE OR REQUEST"
            sheet.Cells(1, 8) = "QTY"
            sheet.Cells(1, 9) = "UNIT"
            sheet.Cells(1, 10) = "UNIT PRICE"
            sheet.Cells(1, 11) = "TOTAL AMOUNT"
            sheet.Cells(1, 12) = "INSTRUCTIONS"
            sheet.Cells(1, 13) = "ADDRESS"
            sheet.Cells(1, 14) = "TERMS"
            sheet.Cells(1, 15) = "CHARGES"
            sheet.Cells(1, 16) = "DATE NEEDED"
            sheet.Cells(1, 17) = "PREPARED BY"
            sheet.Cells(1, 18) = "CHECKED BY"
            sheet.Cells(1, 19) = "APPROVED BY"
            sheet.Cells(1, 20) = "IN OUT"
            sheet.Cells(1, 21) = "RS DATE"
            sheet.Cells(1, 22) = "PRINT STATUS"
            sheet.Cells(1, 23) = "USERS"


            'For Each item As ListViewItem In LVLEquipList.Items

            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Dim col1, row1 As Integer
            row1 = 2
            col1 = 1


            chartRange1 = sheet.Range(excel_array(3) & 1, excel_array(3) & 1)
            chartRange1.EntireColumn.NumberFormat = "@"

            For Each x As Model._Mod_Purchase_Order.Purchase_Order_Field In cListOfPoDateLogPrice
                'If rows.Selected = True Then

                sheet.Cells(row1, 1) = x.po_no
                sheet.Cells(row1, 2) = x.rs_no
                sheet.Cells(row1, 3) = x.po_date
                sheet.Cells(row1, 4) = x.Supplier_Name
                sheet.Cells(row1, 5) = x.Item_Name
                sheet.Cells(row1, 6) = x.Item_Desc
                sheet.Cells(row1, 7) = x.type_of_request
                sheet.Cells(row1, 8) = x.qty
                sheet.Cells(row1, 9) = x.unit
                sheet.Cells(row1, 10) = x.unit_price
                sheet.Cells(row1, 11) = x.total_amount
                sheet.Cells(row1, 12) = x.instructions
                sheet.Cells(row1, 13) = x.address
                sheet.Cells(row1, 14) = x.terms
                sheet.Cells(row1, 15) = x.charges
                sheet.Cells(row1, 16) = x.date_needed
                sheet.Cells(row1, 17) = x.prepared_by
                sheet.Cells(row1, 18) = x.checked_by
                sheet.Cells(row1, 19) = x.approved_by
                sheet.Cells(row1, 20) = x.inout
                sheet.Cells(row1, 21) = x.rs_date
                sheet.Cells(row1, 22) = x.print_stats
                sheet.Cells(row1, 23) = x.user_logs

                chartRange1 = sheet.Range(excel_array(3) & 2, excel_array(3) & 2)
                chartRange1.EntireColumn.NumberFormat = "@"

                chartRange = sheet.Range("A" & row1, "W" & row1)


                With chartRange

                    .HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter
                    .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    .Font.Size = 12
                    .Font.FontStyle = "Arial"
                    .EntireColumn.ColumnWidth = 15
                    '.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightYellow)

                    .Borders(Excel.XlBordersIndex.xlEdgeLeft).Weight = 2
                    .Borders(Excel.XlBordersIndex.xlEdgeRight).Weight = 2
                    .Borders(Excel.XlBordersIndex.xlEdgeTop).Weight = 2
                    .Borders(Excel.XlBordersIndex.xlEdgeBottom).Weight = 2


                    .EntireColumn.AutoFit()

                End With

                row1 += 1

                If cProgressBar.InvokeRequired Then
                    cProgressBar.Invoke(Sub()
                                            cProgressBar.Value += 1
                                        End Sub)
                Else
                    cProgressBar.Value += 1
                End If
            Next
            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


            'save the workbook and clean up
            book.SaveAs(cFileName)
            xls.Workbooks.Close()
            xls.Quit()
            releaseObject(sheet)
            releaseObject(book)
            releaseObject(xls)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub releaseObject(ByVal obj As Object)
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

End Class
