Imports System.Data.OleDb

Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Public Class FQTO_Maintenance
    Dim strDestination As String

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim n As Integer

        If txtMaterials.Text = "" Or txtQTO_itemdesc.Text = "" Or txtQTO_itemname.Text = "" Or txtUnit.Text = "" Then
            MessageBox.Show("Some fields are empty..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If btnSave.Text = "Save" Then
            If MessageBox.Show("Are you sure you want to save this data?", "SUPPLY:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Try
                    newSQ.connection.Open()
                    newCMD = New SqlCommand("proc_QTO_maintenance", newSQ.connection)
                    newCMD.Parameters.Clear()
                    newCMD.CommandType = CommandType.StoredProcedure

                    newCMD.Parameters.AddWithValue("@n", 1)
                    newCMD.Parameters.AddWithValue("@materials", txtMaterials.Text)
                    newCMD.Parameters.AddWithValue("@qto_item_name", txtQTO_itemname.Text)
                    newCMD.Parameters.AddWithValue("@qto_item_desc", txtQTO_itemdesc.Text)
                    newCMD.Parameters.AddWithValue("@unit", txtUnit.Text)

                    'newCMD.CommandTimeout = 300
                    n = newCMD.ExecuteScalar

                Catch ex As Exception
                    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    newSQ.connection.Close()
                    If n > 0 Then
                        MessageBox.Show("Successfully Saved...", "Supply Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        load_qto_items(2)
                        txtQTO_itemname.Clear()
                        txtQTO_itemdesc.Clear()
                        txtQTO_itemname.Focus()
                        listfocus(lvlQTOList, n)
                    Else
                        MessageBox.Show("There is something wrong with data..", "Supply Info:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                End Try
            End If

        ElseIf btnSave.Text = "Update" Then
            If MessageBox.Show("Are you sure you want to update this data?", "SUPPLY:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Try
                    newSQ.connection.Open()
                    newCMD = New SqlCommand("proc_QTO_maintenance", newSQ.connection)
                    newCMD.Parameters.Clear()
                    newCMD.CommandType = CommandType.StoredProcedure

                    n = lvlQTOList.SelectedItems(0).Text

                    newCMD.Parameters.AddWithValue("@n", 3)
                    newCMD.Parameters.AddWithValue("@qto_id", n)
                    newCMD.Parameters.AddWithValue("@materials", txtMaterials.Text)
                    newCMD.Parameters.AddWithValue("@qto_item_name", txtQTO_itemname.Text)
                    newCMD.Parameters.AddWithValue("@qto_item_desc", txtQTO_itemdesc.Text)
                    newCMD.Parameters.AddWithValue("@unit", txtUnit.Text)

                    'newCMD.CommandTimeout = 300
                    newCMD.ExecuteNonQuery()

                Catch ex As Exception
                    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    newSQ.connection.Close()

                    MessageBox.Show("Successfully Updated...", "Supply Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    lvlQTOList.Enabled = True
                    load_qto_items(2)

                    txtMaterials.Clear()
                    txtQTO_itemname.Clear()
                    txtQTO_itemdesc.Clear()
                    txtUnit.Clear()

                    txtQTO_itemname.Focus()
                    listfocus(lvlQTOList, n)

                End Try
            End If

        End If

    End Sub

    Private Sub FQTO_Maintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_qto_items(2)
    End Sub
    Private Sub load_qto_items(n As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        lvlQTOList.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_QTO_maintenance", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@searchby", cmbSearchBy.Text)
            newCMD.Parameters.AddWithValue("@search", txtSearch.Text)

            newCMD.CommandTimeout = 300

            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read

                a(0) = newDR.Item("qto_id").ToString
                a(1) = newDR.Item("qto_item_name").ToString
                a(2) = newDR.Item("qto_item_desc").ToString
                a(3) = newDR.Item("unit").ToString
                a(4) = newDR.Item("materials").ToString

                Dim lvl As New ListViewItem(a)

                lvlQTOList.Items.Add(lvl)

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        lvlQTOList.Enabled = False
        btnSave.Text = "Update"

        txtMaterials.Text = lvlQTOList.SelectedItems(0).SubItems(4).Text
        txtQTO_itemname.Text = lvlQTOList.SelectedItems(0).SubItems(1).Text
        txtQTO_itemdesc.Text = lvlQTOList.SelectedItems(0).SubItems(2).Text
        txtUnit.Text = lvlQTOList.SelectedItems(0).SubItems(3).Text

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you want to delete this data?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim newSQ As New SQLcon
            Dim newCMD As SqlCommand
            Dim newDR As SqlDataReader

            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_QTO_maintenance", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 4)
                newCMD.Parameters.AddWithValue("qto_id", lvlQTOList.SelectedItems(0).Text)

                newCMD.ExecuteNonQuery()
                lvlQTOList.SelectedItems(0).Remove()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Dim xlWorkBook1 As Excel.Workbook
        Dim xlApp As Excel.Application
        Try
            With OpenFileDialog1
                .Filter = "Microsoft Excel 2003|*.xls;*.xlsx"
                If .ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                    Return
                End If
                strDestination = .FileName

            End With

            Dim split() As String
            split = strDestination.Split("\")

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

            'Dim proc As System.Diagnostics.Process

            'For Each proc In System.Diagnostics.Process.GetProcessesByName("EXCEL")
            '    '   proc.Kill()
            'Next

            For Each itm As Control In Me.Controls
                If itm.Name = "GBSelectExSheet" Then
                    itm.Enabled = True
                    itm.Show()

                Else
                    itm.Enabled = False
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        For Each itm As Control In Me.Controls
            itm.Enabled = True
            GBSelectExSheet.Hide()
        Next

    End Sub

    Private Sub ListSheets_DoubleClick(sender As Object, e As EventArgs) Handles ListSheets.DoubleClick
        Dim exist, imported As Integer
        If MessageBox.Show("are you sure you wan't to import data to database?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim OLEDBCON As New OLEDBcon
            Dim checker As String
            Try
                OLEDBCON.OLEConnection(strDestination)
                OLEDBCON.connection.Open()


                Dim query As String = "SELECT * FROM [" & ListSheets.SelectedItem.ToString & "$]"
                Dim myCommand As System.Data.OleDb.OleDbCommand = New System.Data.OleDb.OleDbCommand(query, OLEDBCON.connection)
                Dim myoledr As System.Data.OleDb.OleDbDataReader = myCommand.ExecuteReader

                While myoledr.Read
                    If myoledr.Item("MATERIALS").ToString = "" Then
                    Else
                        'MsgBox(myoledr.Item("MATERIALS").ToString)

                        Dim materials As String = myoledr.Item("MATERIALS").ToString
                        Dim QTO_itemname As String = myoledr.Item("ITEM NAME").ToString
                        Dim QTO_itemdesc As String = myoledr.Item("ITEM SPECIFICATIONS").ToString
                        Dim QTO_unit As String = myoledr.Item("UNIT").ToString

                        'check if exist 
                        If check_if_exist_qto_maintenance(QTO_itemname, QTO_itemdesc, QTO_unit, materials) > 0 Then
                            exist += 1
                        Else
                            'insert

                            insert_into_qto_maintenance(QTO_itemname, QTO_itemdesc, QTO_unit, materials)
                            imported += 1
                        End If


                    End If

                End While
                myoledr.Close()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description & vbCrLf & vbCrLf & checker, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                OLEDBCON.connection.Close()
                MessageBox.Show(imported & " Successfully import.." & vbCrLf & exist & " exist.", "Supply Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)

                For Each itm As Control In Me.Controls
                    If itm.Name = "GBSelectExSheet" Then
                        itm.Enabled = False
                    Else
                        itm.Enabled = True
                    End If
                Next
                load_qto_items(2)
            End Try
        End If
    End Sub
    Private Function check_if_exist_qto_maintenance(qto_item_name As String, qto_item_desc As String, qto_unit As String, materials As String) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_QTO_maintenance", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 5)
            newCMD.Parameters.AddWithValue("@materials", materials)
            newCMD.Parameters.AddWithValue("@qto_item_name", qto_item_name)
            newCMD.Parameters.AddWithValue("@qto_item_desc", qto_item_desc)
            newCMD.Parameters.AddWithValue("@unit", qto_unit)

            'newCMD.CommandTimeout = 300
            newDR = newCMD.ExecuteReader
            While newDR.Read
                check_if_exist_qto_maintenance += 1
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

        End Try
    End Function
    Private Sub insert_into_qto_maintenance(qto_item_name As String, qto_item_desc As String, qto_unit As String, materials As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_QTO_maintenance", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 1)
            newCMD.Parameters.AddWithValue("@materials", materials)
            newCMD.Parameters.AddWithValue("@qto_item_name", qto_item_name)
            newCMD.Parameters.AddWithValue("@qto_item_desc", qto_item_desc)
            newCMD.Parameters.AddWithValue("@unit", qto_unit)

            'newCMD.CommandTimeout = 300
            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

        End Try

    End Sub
    Private Sub ListSheets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListSheets.SelectedIndexChanged

    End Sub

    Private Sub FQTO_Maintenance_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then

            For Each itm As Control In Me.Controls
                itm.Enabled = True
                GBSelectExSheet.Hide()

            Next
        End If
    End Sub

    Private Sub lvlQTOList_DoubleClick(sender As Object, e As EventArgs) Handles lvlQTOList.DoubleClick
        If pub_button_name = "pboxqtyoff" Then
            pub_qto_id = IIf(lvlQTOList.SelectedItems(0).Text = "", 0, lvlQTOList.SelectedItems(0).Text)
            FRequestField.txtQtyTakeOff.Text = lvlQTOList.SelectedItems(0).SubItems(1).Text & " - " & lvlQTOList.SelectedItems(0).SubItems(2).Text
            Me.Close()
        End If
    End Sub

    Private Sub lvlQTOList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvlQTOList.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnSearch.Click
        load_qto_items(6)
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()

        End If
    End Sub
End Class