Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.Data.OleDb

Public Class FImportsWarehouseItems

    Private trd As Threading.Thread
    Dim strDestination As String

    Dim xlWorkBook As Excel.Workbook

    Public SQLcon As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader

    Private Sub loading()
        Floading.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim xlWorkBook1 As Excel.Workbook
        Dim xlApp As Excel.Application
        Try
            With OpenFileDialog1
                .Filter = "Microsoft Excel 2003|*.xls;*.xlsx"
                If .ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                    Return
                Else
                    strDestination = .FileName
                End If
            End With

            trd = New Threading.Thread(AddressOf loading)
            trd.Start()


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
            trd.Abort()
            trd = Nothing

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            trd.Abort()
            trd = Nothing
        Finally

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ListSheets.SelectedItems.Count > 0 Then
        Else
            MessageBox.Show("Select first a sheet that you want to import.", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        lvlView.Items.Clear()

        dbwhitems_import_excel_to_db(strDestination, ListSheets)

    End Sub

    Public Sub dbwhitems_import_excel_to_db(ByVal strDestination As String, ByVal listSheets As Object)

        Dim OLEDBCON As New OLEDBcon
        Dim a(20) As String
        Dim query1 As String = ""

        If MessageBox.Show("Are you sure you want to store this data to database?", "EUS info:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Try
                OLEDBCON.OLEConnection(strDestination)
                OLEDBCON.connection.Open()

                trd = New Threading.Thread(AddressOf loading)
                trd.IsBackground = True
                trd.Start()

                Dim query As String = "SELECT * FROM [" & listSheets.SelectedItem.ToString & "$]"
                Dim myCommand As System.Data.OleDb.OleDbCommand = New System.Data.OleDb.OleDbCommand(query, OLEDBCON.connection)

                Dim myoledr As System.Data.OleDb.OleDbDataReader = myCommand.ExecuteReader

                While myoledr.Read

                    a(1) = myoledr(0).ToString
                    a(2) = myoledr(1).ToString
                    a(3) = myoledr(2).ToString
                    a(4) = myoledr(3).ToString
                    a(5) = myoledr(4).ToString

                    Dim lvl As New ListViewItem(a)
                    lvlView.Items.Add(lvl)

                    ImportWarehouseItems(myoledr(0).ToString, myoledr(1).ToString, _
                myoledr(2).ToString, myoledr(3).ToString, myoledr(4).ToString)

                End While
                myoledr.Close()

                trd.Abort()
                trd = Nothing

                MessageBox.Show("Successfuly Done..", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description & vbCrLf & query1, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Finally

                OLEDBCON.connection.Close()
                listSheets = Nothing

            End Try
        End If
    End Sub

    Public Sub ImportWarehouseItems(ByVal item As String, ByVal classification As String, ByVal area As String, ByVal specificloc As String, ByVal incharge As String)
        Try
            SQLcon.connection.Open()

            cmd = New SqlCommand("proc_wh_items_crud", SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure

            '    cmd.Parameters.AddWithValue("@whID", whID)
            cmd.Parameters.AddWithValue("@Item", item)
            cmd.Parameters.AddWithValue("@Class", classification)
            cmd.Parameters.AddWithValue("@Area", area)
            cmd.Parameters.AddWithValue("@SpecificLoc", specificloc)
            cmd.Parameters.AddWithValue("@Incharge", incharge)
            '  cmd.Parameters.AddWithValue("@ReorderPoint", reorpoint)
            cmd.Parameters.AddWithValue("@crud", "INSERT")

            'cmd.Parameters.AddWithValue("@joborder", joborder)

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If SQLcon.hasConnection = True Then
            MsgBox("naay connection")
        Else
            MsgBox("walay connection")
        End If
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        lvlView.Items.Clear()

        Try
            SQLcon.connection.Open()
            Dim query As String = "SELECT * FROM dbwarehouse_items"
            cmd = New SqlCommand(query, SQLcon.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim a(18) As String
                a(0) = dr.Item(0).ToString
                a(1) = dr.Item(1).ToString
                a(2) = dr.Item(2).ToString
                a(3) = dr.Item(3).ToString
                a(4) = dr.Item(4).ToString
                a(5) = dr.Item(5).ToString
                a(6) = dr.Item(6).ToString


                Dim lvl As New ListViewItem(a)
                lvlView.Items.Add(lvl)

            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()

        End Try
    End Sub

    Private Sub FImportsWarehouseItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class