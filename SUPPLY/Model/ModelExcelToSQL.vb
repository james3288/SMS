Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class ModelExcelToSQL
    Dim customMsgBox As New customMessageBox
    Public Function GetExcelFilePath() As String
        ' Create a new OpenFileDialog instance
        Dim openFileDialog As New OpenFileDialog()

        ' Set the filter to only allow Excel files (.xls, .xlsx)
        openFileDialog.Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx"

        ' Show the OpenFileDialog and check if the user selected a file
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Return the selected file path
            Return openFileDialog.FileName
        Else
            ' If no file is selected, return an empty string or handle as needed
            Return String.Empty
        End If
    End Function

    Public Sub ImportExcelToSQL(ByVal excelFilePath As String)
        ' Define the connection string for Excel
        Dim excelConnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & excelFilePath & ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;'"

        ' Create OleDb connection to Excel
        Using excelConnection As New OleDbConnection(excelConnString)
            ' Open Excel connection
            excelConnection.Open()

            ' Get the sheet name (assuming the first sheet)
            Dim sheetName As String = excelConnection.GetSchema("Tables").Rows(0)("TABLE_NAME").ToString()

            ' Query to select all data from the Excel sheet
            Dim excelQuery As String = "SELECT * FROM [" & sheetName & "]"

            ' Create DataAdapter to load data from Excel sheet
            Using excelAdapter As New OleDbDataAdapter(excelQuery, excelConnection)
                ' Fill a DataTable with the Excel data
                Dim excelDataTable As New DataTable()
                excelAdapter.Fill(excelDataTable)

                'Iterate through rows in the DataTable And insert them into SQL Server
                For Each row As DataRow In excelDataTable.Rows

                    Dim c As New Model_King_Dynamic_Update()
                    Dim itemName As String = TrimLastBlank(row(cExcelToSQLHeader.ITEM).ToString.Replace("'", "`"))
                    Dim itemDesc As String = TrimLastBlank(row(cExcelToSQLHeader.ITEM_DESC).ToString.Replace("'", "`"))
                    Dim units As String = TrimLastBlank(row(cExcelToSQLHeader.UNIT).ToString.Replace("'", "`"))

                    Dim columnValues As New Dictionary(Of String, Object)()
                    With columnValues
                        .Add("item_name", itemName)
                        .Add("item_desc", itemDesc)
                        .Add("units", units)
                        .Add("type_of_request", IIf(IsDBNull(row(cExcelToSQLHeader.TYPE_OF_REQUEST)), "", row(cExcelToSQLHeader.TYPE_OF_REQUEST)))
                    End With

                    If Not isExistInTable(columnValues) Then
                        c.InsertData("dbwarehouse_items_proper_name", columnValues)
                    End If


                Next

                customMsgBox.message("info", "Excel data was successfully imported to SQL", "SUPPLY INFO:")


            End Using
        End Using
    End Sub

    Private Function isExistInTable(Optional paramDic As Dictionary(Of String, Object) = Nothing) As Boolean
        Dim c As New Model_Dynamic_Select

        Dim table As String = "dbwarehouse_items_proper_name a" 'table
        Dim condition As String = $"a.item_name = '{paramDic("item_name").ToString.Replace("'", "`")}' 
                                    and a.item_desc = '{paramDic("item_desc").ToString.Replace("'", "`")}' 
                                    and a.units = '{paramDic("units").ToString.Replace("'", "`")}'" 'conditions

        'columns
        c.join_columns("a.item_name")
        'end columns


        'initialize data
        c._initialize(table, condition, c.cJoinColumns,, "supply_db")


        Dim rrData As New List(Of Object) 'create a list of ojbect 
        rrData = c.select_query() 'get data

        'loop data to get values
        If rrData.Count > 0 Then
            MsgBox(paramDic("item_desc"))
            Return True
        End If
    End Function
End Class
