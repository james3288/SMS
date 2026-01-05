Imports Microsoft.Office.Interop
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FImport
    Public sq As New SQLcon
    Public cmd As SqlCommand
    'exceL-
    Dim xlWorkBook As Excel.Workbook
    Dim strDestination As String
    Dim xlApp As Excel.Application
    Dim xlWorkBook1 As Excel.Workbook
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim xlWorkBook1 As Excel.Workbook
        'Dim xlApp As Excel.Application
        Try
            With OpenFileDialog1
                .Filter = "Microsoft Excel 2003|*.xls;*.xlsx"
                If .ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                    Return
                Else
                    strDestination = .FileName
                End If
            End With

            'trd = New Threading.Thread(AddressOf loading)
            'trd.Start()


            xlApp = New Excel.Application

            xlWorkBook1 = xlApp.Workbooks.Open(strDestination)
            ListSheets.Items.Clear()

            For Each ews In xlWorkBook1.Sheets
                ListSheets.Items.Add(ews.name)
            Next ews

            xlWorkBook1.Close()
            xlApp.Quit()

            xlWorkBook1 = Nothing
            xlApp = Nothing
            'trd.Abort()
            'trd = Nothing

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'trd.Abort()
            'trd = Nothing
        Finally

        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim OLEDBCON As New OLEDBcon

        'Dim query1 As String = ""

        ' If MessageBox.Show("Are you sure you want to store this data to database?", "EUS info:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

        Try
                OLEDBCON.OLEConnection(strDestination)
                OLEDBCON.connection.Open()

            'trd = New Threading.Thread(AddressOf loading)
            'trd.IsBackground = True
            'trd.Start()

            Dim query As String = "SELECT * FROM [" & ListSheets.SelectedItem.ToString & "$]"
            Dim myCommand As System.Data.OleDb.OleDbCommand = New System.Data.OleDb.OleDbCommand(query, OLEDBCON.connection)

                Dim myoledr As System.Data.OleDb.OleDbDataReader = myCommand.ExecuteReader

                While myoledr.Read
                Dim a(20) As String
                'a(0) = myoledr(1).ToString
                'a(1) = myoledr(1).ToString
                'a(2) = myoledr(2).ToString
                'a(3) = myoledr(3).ToString
                'a(5) = myoledr(4).ToString

                'Dim lvl As New ListViewItem(a)
                'ListView1.Items.Add(lvl)

                MessageBox.Show(myoledr(1).ToString)

                '    ImportWarehouseItems(myoledr(0).ToString, myoledr(1).ToString,
                'myoledr(2).ToString, myoledr(3).ToString, myoledr(4).ToString)

            End While
                myoledr.Close()

            'trd.Abort()
            'trd = Nothing

            'MessageBox.Show("Successfuly Done..", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description & vbCrLf & query1, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Finally

                OLEDBCON.connection.Close()
                ListSheets = Nothing

            End Try
        'End If
    End Sub

    Public Sub import_to_Db()

    End Sub
End Class