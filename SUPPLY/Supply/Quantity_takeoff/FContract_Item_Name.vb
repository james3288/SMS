Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FContract_Item_Name
    Public Sqlcon As New SQLcon
    Dim sqlcmd As SqlCommand
    Dim sqldr As SqlDataReader
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If btn_save.Text = "Save" Then
            If check_if_exist("dbContract_Item_Name_No", "Item_name_no", txtItemno.Text, 0) > 0 Then
                MsgBox("DATA ALREADY HAVE")
            Else
                save_contract_item_name()
            End If

        ElseIf btn_save.Text = "Update" Then
            If check_if_exist("dbContract_Item_Name_No", "Item_name_no", txtItemno.Text, 0) > 0 Then
                MsgBox("DATA ALREADY HAVE")
            Else
                update_contract_item_name()
            End If

        End If
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        search_contract_item_name(txtSearch.Text)
    End Sub


    Private Sub FContract_Item_Name_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_contract_item_name()
    End Sub


    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        btn_save.Text = "Update"
        txtItemno.Text = lvlContruct_Quantities.SelectedItems(0).SubItems(1).Text
        lvlContruct_Quantities.Enabled = False

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you want to Delete the data?.", "SUPPLY INFO.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
            delete_contract_item_name(lvlContruct_Quantities.SelectedItems(0).Text)
            lvlContruct_Quantities.SelectedItems(0).Remove()
        Else : Return
        End If
    End Sub

    Private Sub FContract_Item_Name_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If MessageBox.Show("Are you sure you want to cancel Update?.", "SUPPLY INFO.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                txtItemno.Text = ""

                lvlContruct_Quantities.Enabled = True
                btn_save.Text = "Save"

            End If
        End If
    End Sub
    Public Sub load_contract_item_name()
        lvlContruct_Quantities.Items.Clear()

        Dim nwsqlcmd As New SqlCommand
        Dim a(30) As String

        Try
            Sqlcon.connection.Open()

            nwsqlcmd.Connection = Sqlcon.connection
            nwsqlcmd.CommandText = "proc_Quantity_takeoff"
            nwsqlcmd.CommandType = CommandType.StoredProcedure
            nwsqlcmd.Parameters.AddWithValue("@n", 38)

            sqldr = nwsqlcmd.ExecuteReader
            While sqldr.Read

                a(0) = sqldr.Item(0).ToString
                a(1) = sqldr.Item(1).ToString

                Dim lvlList As New ListViewItem(a)
                lvlContruct_Quantities.Items.Add(lvlList)

            End While
            sqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sqlcon.connection.Close()
        End Try
    End Sub
    Public Sub save_contract_item_name()
        Dim newSQ As New SQLcon
        Dim newCMD As New SqlCommand
        Dim z As Integer

        Try
            newSQ.connection.Open()

            newCMD.Connection = newSQ.connection
            newCMD.CommandText = "proc_Quantity_takeoff"
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 37)
            newCMD.Parameters.AddWithValue("@const_item_name", txtItemno.Text)

            z = newCMD.ExecuteScalar
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
        MsgBox("Successfully Save")
        load_contract_item_name()
        listfocus(lvlContruct_Quantities, z)

    End Sub
    Public Sub update_contract_item_name()
        Dim newSQ As New SQLcon
        Dim newCMD As New SqlCommand
        Dim x As Integer = lvlContruct_Quantities.SelectedItems(0).SubItems(0).Text

        Try
            newSQ.connection.Open()

            newCMD.Connection = newSQ.connection
            newCMD.CommandText = "proc_Quantity_takeoff"
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 39)
            newCMD.Parameters.AddWithValue("@id", x)
            newCMD.Parameters.AddWithValue("@const_item_name", txtItemno.Text)

            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
        MsgBox("Successfully Updated")

        load_contract_item_name()
        listfocus(lvlContruct_Quantities, x)
        lvlContruct_Quantities.Enabled = True
        txtItemno.Text = ""
        btn_save.Text = "Save"

    End Sub
    Public Sub delete_contract_item_name(id As Integer)
        Dim sqlcmd As New SqlCommand
        Try
            Sqlcon.connection.Open()
            sqlcmd.Connection = Sqlcon.connection
            sqlcmd.CommandText = "proc_Quantity_takeoff"
            sqlcmd.CommandType = CommandType.StoredProcedure
            sqlcmd.Parameters.AddWithValue("@n", 40)
            sqlcmd.Parameters.AddWithValue("@id", id)
            sqlcmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sqlcon.connection.Close()
        End Try
    End Sub
    Public Sub search_contract_item_name(ByVal value As String)
        lvlContruct_Quantities.Items.Clear()

        Dim nwsqlcmd As New SqlCommand
        Dim a(30) As String

        Try
            Sqlcon.connection.Open()

            nwsqlcmd.Connection = Sqlcon.connection
            nwsqlcmd.CommandText = "proc_Quantity_takeoff"
            nwsqlcmd.CommandType = CommandType.StoredProcedure
            nwsqlcmd.Parameters.AddWithValue("@n", 41)
            nwsqlcmd.Parameters.AddWithValue("@const_item_name", value)
            sqldr = nwsqlcmd.ExecuteReader
            While sqldr.Read

                a(0) = sqldr.Item(0).ToString
                a(1) = sqldr.Item(1).ToString

                Dim lvlList As New ListViewItem(a)
                lvlContruct_Quantities.Items.Add(lvlList)

            End While
            sqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sqlcon.connection.Close()
        End Try
    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    lvlContruct_Quantities.Items.Clear()

    '    Dim nwsqlcmd As New SqlCommand
    '    Dim a(30) As String

    '    Try
    '        Sqlcon.connection.Open()

    '        nwsqlcmd.Connection = Sqlcon.connection
    '        nwsqlcmd.CommandText = "proc_Quantity_takeoff"
    '        nwsqlcmd.CommandType = CommandType.StoredProcedure
    '        nwsqlcmd.Parameters.AddWithValue("@n", 45)

    '        sqldr = nwsqlcmd.ExecuteReader
    '        While sqldr.Read

    '            a(0) = sqldr.Item(0).ToString


    '            Dim lvlList As New ListViewItem(a)
    '            lvlContruct_Quantities.Items.Add(lvlList)

    '        End While
    '        sqldr.Close()
    '    Catch ex As Exception
    '        MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        Sqlcon.connection.Close()
    '    End Try
    'End Sub

    'Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '    Dim newSQ As New SQLcon
    '    Dim newCMD As New SqlCommand
    '    ' MsgBox(lvl_qty_takeoff.Items(0).SubItems(25).Text)


    '    For Each row As ListViewItem In lvlContruct_Quantities.Items

    '        Try

    '            newSQ.connection.Open()

    '            newCMD.Connection = newSQ.connection
    '            newCMD.CommandText = "proc_Quantity_takeoff"
    '            newCMD.Parameters.Clear()
    '            newCMD.CommandType = CommandType.StoredProcedure
    '            newCMD.Parameters.AddWithValue("@n", 46)
    '            newCMD.Parameters.AddWithValue("@const_item_name", row.SubItems(0).Text)


    '            newCMD.ExecuteNonQuery()
    '            '  MsgBox("ian")
    '        Catch ex As Exception
    '            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Finally
    '            newSQ.connection.Close()
    '        End Try

    '    Next

    '    MsgBox("Successfully Save")
    'End Sub
End Class