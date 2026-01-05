Imports System.Data.Sql
Imports System.Data.SqlClient

Imports Microsoft.Office.Interop
Imports System.Data


Public Class FConstruction_Items
    Dim strDestination As String
    Dim name1 As String
    Dim pub_textbox As TextBox
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ListSheets_DoubleClick(sender As Object, e As EventArgs) Handles ListSheets.DoubleClick

        Dim OLEDBCON As New OLEDBcon

        Try
            OLEDBCON.OLEConnection(strDestination)
            OLEDBCON.connection.Open()

            Dim query As String = "SELECT * FROM [" & ListSheets.SelectedItem.ToString & "$]"
            Dim myCommand As System.Data.OleDb.OleDbCommand = New System.Data.OleDb.OleDbCommand(query, OLEDBCON.connection)

            'count = myCommand.ExecuteScalar

            Dim myoledr As System.Data.OleDb.OleDbDataReader = myCommand.ExecuteReader

            While myoledr.Read
                'insert
                Dim items, item_desc, size, units As String

                items = myoledr.Item("Items").ToString
                item_desc = myoledr.Item("Item_desc").ToString
                size = myoledr.Item("Size").ToString
                units = myoledr.Item("Units").ToString

                insert_into_dbConstruction_Items(items, item_desc, size, units, 1)

                cmbSearch.SelectedIndex = 1
                txtSearch.Text = item_desc
                btnSearch.PerformClick()


            End While
            myoledr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            OLEDBCON.connection.Close()
            Me.Dispose()

        End Try
    End Sub

    Public Function insert_into_dbConstruction_Items(items As String, item_desc As String, size As String, units As String, n As Integer) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("PROC_Construction_Materials", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@items", items)
            newCMD.Parameters.AddWithValue("@item_desc", item_desc)
            newCMD.Parameters.AddWithValue("@size", size)
            newCMD.Parameters.AddWithValue("@units", units)

            insert_into_dbConstruction_Items = newCMD.ExecuteScalar()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Sub update_dbConstruction_Items(items As String, item_desc As String, size As String, units As String, n As Integer, const_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("PROC_Construction_Materials", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@items", items)
            newCMD.Parameters.AddWithValue("@item_desc", item_desc)
            newCMD.Parameters.AddWithValue("@size", size)
            newCMD.Parameters.AddWithValue("@units", units)
            newCMD.Parameters.AddWithValue("@const_id", const_id)

            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Private Sub txtbox(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItems.TextChanged, txtItemDesc.TextChanged, txtSize.TextChanged, txtUnits.TextChanged
        Dim tbox As TextBox = sender
        Dim n As Integer

        If tbox.Name = "txtItems" Then : n = 0 : ElseIf tbox.Name = "txtItemDesc" : n = 1 : ElseIf tbox.Name = "txtSize" : n = 2 : ElseIf tbox.Name = "txtUnits" : n = 3 : End If

        Try
            If tbox.Text = "" Then
                lbox_List.BringToFront()
                lbox_List.Parent = Panel1
                lbox_List.Location = New System.Drawing.Point(tbox.Bounds.Left, tbox.Bounds.Bottom)
                lbox_List.Visible = False
            Else
                lbox_List.BringToFront()
                With lbox_List
                    lbox_List.Parent = Panel1
                    .Location = New System.Drawing.Point(tbox.Bounds.Left, tbox.Bounds.Bottom)
                    .Visible = True
                    .Items.Clear()
                    .Width = tbox.Width
                End With

                ' get_withdraw(n, tbox)
                contruct_List(tbox, n)

            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE:  " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub contruct_List(ByVal txtbox As TextBox, ByVal n As Integer)

        Dim count As Integer = 0

        lbox_List.Items.Clear()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            If n = 0 Then
                publicquery = "SELECT DISTINCT item FROM dbContruct_quantities WHERE item LIKE '%" & txtbox.Text & "%' ORDER BY item ASC"
            ElseIf n = 1 Then
                publicquery = "SELECT DISTINCT item_desc FROM dbContruct_quantities WHERE item_desc LIKE '%" & txtbox.Text & "%' ORDER BY item_desc ASC"
            ElseIf n = 2 Then
                publicquery = "SELECT DISTINCT size FROM dbContruct_quantities WHERE size LIKE '%" & txtbox.Text & "%' ORDER BY size ASC"
            ElseIf n = 3
                publicquery = "SELECT DISTINCT units FROM dbContruct_quantities WHERE units LIKE '%" & txtbox.Text & "%' ORDER BY units ASC"
            End If
            newCMD = New SqlCommand(publicquery, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read

                If n = 0 Then
                    lbox_List.Items.Add(newDR.Item("item").ToString)
                    count += 1
                ElseIf n = 1 Then
                    lbox_List.Items.Add(newDR.Item("item_desc").ToString)
                    count += 1
                ElseIf n = 2 Then
                    lbox_List.Items.Add(newDR.Item("size").ToString)
                    count += 1

                ElseIf n = 3 Then
                    lbox_List.Items.Add(newDR.Item("units").ToString)
                    count += 1
                End If

            End While

            If count > 0 Then
                lbox_List.Visible = True
            Else
                lbox_List.Visible = False
            End If

            newDR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub FConstruction_Items_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbox_List.Parent = Panel1

        If restriction = "Admin" Then
            Button1.Enabled = True
            ListSheets.Enabled = True
        Else
            Button1.Enabled = False
            ListSheets.Enabled = False
        End If
    End Sub

    Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItems.KeyDown, txtItemDesc.KeyDown, txtSize.KeyDown, txtUnits.KeyDown
        pub_textbox = sender

        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down Then
                lbox_List.Focus()
                lbox_List.SelectedIndex = 0

            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txt_GotFocus(sender As Object, e As EventArgs) Handles txtItems.GotFocus, txtItemDesc.GotFocus, txtSize.GotFocus, txtUnits.GotFocus
        lbox_List.Visible = False
        sender.backcolor = Color.Yellow

        If txtItems.Focused Then
            name1 = txtItems.Name
            txtItems.SelectAll()

        ElseIf txtItemDesc.Focused Then
            name1 = txtItemDesc.Name
            txtItemDesc.SelectAll()

        ElseIf txtSize.Focused Then
            name1 = txtSize.Name
            txtSize.SelectAll()

        ElseIf txtUnits.Focused Then
            name1 = txtUnits.Name
            txtUnits.SelectAll()

        End If
    End Sub

    Private Sub txt_Leave(sender As Object, e As EventArgs) Handles txtItems.Leave, txtItemDesc.Leave, txtSize.Leave, txtUnits.Leave
        sender.backcolor = Color.White
    End Sub

    Private Sub lbox_List_DoubleClick(sender As Object, e As EventArgs) Handles lbox_List.DoubleClick
        If lbox_List.SelectedItems.Count > 0 Then
            For Each ctr As Control In Panel1.Controls
                If ctr.Name = name1 Then
                    ctr.Text = lbox_List.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next
            lbox_List.Visible = False
        Else
            MessageBox.Show("Pls select one item", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub lbox_List_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbox_List.SelectedIndexChanged

    End Sub

    Private Sub lbox_List_KeyDown(sender As Object, e As KeyEventArgs) Handles lbox_List.KeyDown
        If e.KeyCode = Keys.Enter Then
            If lbox_List.SelectedItems.Count > 0 Then
                For Each ctr As Control In Panel1.Controls
                    If ctr.Name = name1 Then
                        ctr.Text = lbox_List.SelectedItem.ToString
                        ctr.Focus()
                    End If
                Next
                lbox_List.Visible = False
            Else
                MessageBox.Show("Pls select one item", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub ListSheets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListSheets.SelectedIndexChanged

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click



        If btnSave.Text = "Save" Then
            For Each ctr As Control In Panel1.Controls
                If TypeOf ctr Is TextBox Then
                    If ctr.Text = "" Then
                        MessageBox.Show("Please fill all blank fields..", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                End If
            Next

            If MessageBox.Show("Are you sure you want to save this item?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim items, item_desc, size, units As String
                items = txtItems.Text
                item_desc = txtItemDesc.Text
                size = txtSize.Text
                units = txtUnits.Text

                Dim id As Integer = insert_into_dbConstruction_Items(items, item_desc, size, units, 1)

                If id > 0 Then
                    MessageBox.Show("Succesfully Save...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                txtSearch.Text = item_desc
                cmbSearch.SelectedIndex = 1
                btnSearch.PerformClick()

                listfocus(lvlConstructList, id)
            End If

        ElseIf btnSave.Text = "Update" Then
            If MessageBox.Show("Are you sure you want to Update this item?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim items, item_desc, size, units As String
                items = txtItems.Text
                item_desc = txtItemDesc.Text
                size = txtSize.Text
                units = txtUnits.Text

                Dim const_id As Integer = CInt(lvlConstructList.SelectedItems(0).Text)
                update_dbConstruction_Items(items, item_desc, size, units, 6, const_id)

                MessageBox.Show("Succesfully updated...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)

                clear()

                txtSearch.Text = item_desc
                cmbSearch.SelectedIndex = 1
                btnSearch.PerformClick()

                listfocus(lvlConstructList, const_id)
            End If
        End If


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearch.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        'Search by items
        'Search by item description
        'Search by size
        'Search by units

        If cmbSearch.Text = "Search by items" Then
            search(2, txtSearch.Text)

        ElseIf cmbSearch.Text = "Search by item description" Then
            search(3, txtSearch.Text)

        ElseIf cmbSearch.Text = "Search by size" Then
            search(4, txtSearch.Text)

        ElseIf cmbSearch.Text = "Search by units" Then
            search(5, txtSearch.Text)

        End If
    End Sub

    Public Sub search(n As Integer, value As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim a(10) As String
        lvlConstructList.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("PROC_Construction_Materials", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@value", value)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                a(0) = newDR.Item("const_id").ToString
                a(1) = newDR.Item("item").ToString
                a(2) = newDR.Item("item_desc").ToString
                a(3) = newDR.Item("size").ToString
                a(4) = newDR.Item("units").ToString

                Dim lvl As New ListViewItem(a)
                lvlConstructList.Items.Add(lvl)

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you want to remove this item?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            For Each row As ListViewItem In lvlConstructList.Items

                If row.Selected = True Then
                    Dim query As String = "DELETE FROM dbContruct_quantities WHERE const_id = " & CInt(row.Text)
                    UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

                End If

            Next

            btnSearch.PerformClick()

        End If
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        With lvlConstructList.SelectedItems(0)

            txtItems.Text = .SubItems(1).Text
            txtItemDesc.Text = .SubItems(2).Text
            txtSize.Text = .SubItems(3).Text
            txtUnits.Text = .SubItems(4).Text



        End With


        lvlConstructList.Enabled = False
        btnSave.Text = "Update"

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub FConstruction_Items_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            clear()
        End If


    End Sub

    Public Sub clear()
        For Each ctr As Control In Panel1.Controls
            If TypeOf ctr Is TextBox Then
                ctr.Text = ""
            End If
        Next

        btnSave.Text = "Save"
        txtItems.Focus()
        lvlConstructList.Enabled = True
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()

        End If
    End Sub

    Private Sub lvlConstructList_DoubleClick(sender As Object, e As EventArgs) Handles lvlConstructList.DoubleClick
        Dim item, item_desc As String

        item = lvlConstructList.SelectedItems(0).SubItems(1).Text
        item_desc = lvlConstructList.SelectedItems(0).SubItems(2).Text

        FRequestField.txtConsItem.Text = item
        FRequestField.txtConsItemDesc.Text = item_desc

        Me.Dispose()

    End Sub
End Class