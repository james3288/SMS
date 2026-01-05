Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices

Public Class frmJournalEntry
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the key is not a digit or a control key, handle the event to prevent input
            e.Handled = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ListView1.Items.Count <= 0 Then
            MsgBox("NO DATA")
        Else
            ExportListViewToExcel(ListView1)
        End If
    End Sub

    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        If ComboBox1.Text = "" Or TextBox1.Text = "" Then
            MsgBox("Please select MONTH and YEAR")
        Else
            display_journal_entry()
        End If

    End Sub

    Private Sub frmJournalEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub ExportListViewToExcel(ByVal lv As ListView)
        Dim excelApp As New Excel.Application
        Dim excelWorkBook As Excel.Workbook = excelApp.Workbooks.Add(Type.Missing)
        Dim excelWorkSheet As Excel.Worksheet = Nothing

        Try
            excelWorkSheet = excelWorkBook.Sheets(1)
            excelWorkSheet = excelWorkBook.ActiveSheet
            excelWorkSheet.Name = "ExportedData"

            ' Writing the column headers
            For i As Integer = 1 To lv.Columns.Count
                excelWorkSheet.Cells(1, i) = lv.Columns(i - 1).Text
            Next

            ' Writing the data
            For i As Integer = 0 To lv.Items.Count - 1
                For j As Integer = 0 To lv.Items(i).SubItems.Count - 1
                    excelWorkSheet.Cells(i + 2, j + 1) = lv.Items(i).SubItems(j).Text
                Next
            Next

            ' Save the Excel file
            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
            saveDialog.FilterIndex = 1

            If saveDialog.ShowDialog() = DialogResult.OK Then
                excelWorkBook.SaveAs(saveDialog.FileName)
                MessageBox.Show("Export Successful")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            ' Clean up
            excelWorkBook.Close(False)
            excelApp.Quit()

            ' Release COM objects
            ReleaseObject(excelWorkSheet)
            ReleaseObject(excelWorkBook)
            ReleaseObject(excelApp)
        End Try
    End Sub

    Private Sub ReleaseObject(ByVal obj As Object)
        Try
            Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
    Sub display_journal_entry()
        ListView1.Items.Clear()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT 
			                            ACC_TITLE
			                            ,ACC_CLASSIFICATION
			                            ,SUM(TOTAL_PRICE) as TOTAL_AMOUNT
		                            FROM
		                            (SELECT
				                            isnull((select top 1 aa.date_paid from dbAccounting_Update_Purchased aa where aa.rs_id = b.rs_id),'') as DATE_PAID,
				                            isnull((select top 1 bb.account_title from dbAccounting_Update_Purchased aa 
							                            inner join dbAccount_Title bb on bb.accnt_title_id = aa.account_title_id where aa.rs_id = b.rs_id), 0) as ACC_TITLE,
				                            isnull((select top 1 bb.account_classification from dbAccounting_Update_Purchased aa
							                            inner join dbAccount_Classification bb on bb.accnt_classification_id = aa.account_classification_id where aa.rs_id = b.rs_id), 0) as ACC_CLASSIFICATION,
				                            isnull(h.qty * h.amount,0) AS TOTAL_PRICE
		                              FROM dbPO_details a  
		                              right join dbrequisition_slip b
		                              ON b.rs_id = a.rs_id
		                              LEFT join rs_tor_sub_property c  
		                              ON c.rs_id = b.rs_id
		                              LEFT join dbType_of_Request_sub d 
		                              ON d.tor_sub_id = c.tor_sub_id	
		                              LEFT join dbwarehouse_items e
		                              ON e.wh_id = b.wh_id			  
		                              left join dbreceiving_items f 
		                              ON a.po_det_id = f.po_det_id 
		                              left join dbreceiving_info g
		                              ON g.rr_info_id = f.rr_info_id			  
		                              left join dbreceiving_items_sub h 
		                              ON f.rr_item_id = h.rr_item_id
		                              left join dbreceiving_item_partially i 
		                              ON f.rr_item_id = i.rr_item_id			
		                              left join dbPO j
		                              ON j.po_id = a.po_id
		                              LEFT JOIN dbSupplier k
		                              ON g.supplier_id = k.Supplier_Id
		                              WHERE (f.rs_id is not null) AND (b.type_of_purchasing = 'PURCHASE ORDER')	
		                              and (select top 1 YEAR(aup.date_paid) from dbAccounting_Update_Purchased aup where aup.rs_id = b.rs_id) = " & TextBox1.Text & "
		                              and (select top 1 MONTH(aup.date_paid) from dbAccounting_Update_Purchased aup where aup.rs_id = b.rs_id) = " & (ComboBox1.SelectedIndex + 1) & ") as TBL
		                            GROUP BY DATE_PAID, ACC_TITLE, ACC_CLASSIFICATION
		                            ORDER BY ACC_CLASSIFICATION"
            newCMD = New SqlCommand(query, newSQ.connection)
            newCMD.CommandTimeout = 0
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.Text
            newDR = newCMD.ExecuteReader
            While newDR.Read
                Dim a(50) As String
                a(0) = newDR.Item("ACC_TITLE").ToString
                a(1) = newDR.Item("ACC_CLASSIFICATION").ToString
                a(2) = FormatNumber(newDR.Item("TOTAL_AMOUNT").ToString)
                Dim item As New ListViewItem(a)
                ListView1.Items.Add(item)
            End While
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class