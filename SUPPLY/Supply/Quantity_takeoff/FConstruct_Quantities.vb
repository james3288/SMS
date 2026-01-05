Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FConstruct_Quantities
    Public Sqlcon As New SQLcon
    Dim sqlcmd As SqlCommand
    Dim sqldr As SqlDataReader
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Dim old_item_no As String = ""
    Public Sub clearfields(save_update As String)
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is TextBox Then
                Dim tbox As TextBox = ctr
                tbox.Clear()
            End If
        Next

        If save_update = "Save" Then
        Else
            btn_save.Text = "Save"
            lbl_note.Visible = False
        End If
    End Sub
    Private Sub FConstruct_Quantities_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btn_search.PerformClick()
    End Sub
    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        view_construct_quantities(txtSearch.Text)
    End Sub
    Public Sub view_construct_quantities(search As String)
        lvlConstruct_Quantities.Items.Clear()
        Dim nwsqlcmd As New SqlCommand
        Dim a(10) As String
        Try
            Sqlcon.connection.Open()

            nwsqlcmd.Connection = Sqlcon.connection
            nwsqlcmd.CommandText = "PROC_Construction_Materials"
            nwsqlcmd.CommandType = CommandType.StoredProcedure

            nwsqlcmd.Parameters.AddWithValue("@n", 2)
            nwsqlcmd.Parameters.AddWithValue("@value", search)
            sqldr = nwsqlcmd.ExecuteReader
            While sqldr.Read

                a(0) = sqldr.Item("const_id").ToString
                a(1) = sqldr.Item("item").ToString
                a(2) = sqldr.Item("item_desc").ToString
                a(3) = sqldr.Item("size").ToString
                a(4) = sqldr.Item("units").ToString

                Dim lvlList As New ListViewItem(a)
                lvlConstruct_Quantities.Items.Add(lvlList)

            End While
            sqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sqlcon.connection.Close()
        End Try
    End Sub
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If txtItemno.Text = "" Or txtItemDesc.Text = "" Or txtSize.Text = "" _
            Or txtUnit.Text = "" Then

            MessageBox.Show("Pls. fill in all the required fields.", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            insert_update_construction_quantities(btn_save.Text)
        End If
    End Sub
    Public Sub insert_update_construction_quantities(btn_save_update As String)
        Dim newSQL As New SQLcon
        Dim newCMD As New SqlCommand
        Dim cons_id As Integer = 0
        Try
            newSQL.connection.Open()
            newCMD.Connection = newSQL.connection
            newCMD.CommandText = "PROC_Construction_Materials"
            newCMD.CommandType = CommandType.StoredProcedure

            If btn_save_update = "Save" Then
                newCMD.Parameters.AddWithValue("@n", 1)
            Else
                cons_id = lvlConstruct_Quantities.SelectedItems(0).Text
                newCMD.Parameters.AddWithValue("@n", 6)
                newCMD.Parameters.AddWithValue("@const_id", cons_id)
            End If

            newCMD.Parameters.AddWithValue("@items", txtItemno.Text)
            newCMD.Parameters.AddWithValue("@item_desc", txtItemDesc.Text)
            newCMD.Parameters.AddWithValue("@size", txtSize.Text)
            newCMD.Parameters.AddWithValue("@units", txtUnit.Text)

            If btn_save.Text = "Save" Then
                MessageBox.Show("Successfully saved.", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                FQty_takeoff.cmbItem_No.Text = txtItemno.Text
                newCMD.ExecuteNonQuery()

            Else
                If MessageBox.Show("Are you sure you want to update the data?.", "SUPPLY INFO.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    newCMD.ExecuteNonQuery()
                Else
                    Return
                End If
            End If

            insert_update_dbContract_item_no(btn_save.Text)
            btn_search.PerformClick()
            FQty_takeoff.cons_itemDesc(4, FQty_takeoff.cmbItem_No)
            FQty_takeoff.cmbItemDesc.Text = ""
            clearfields(btn_save.Text)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If btn_save_update = "Save" Then
                listfocus(lvlConstruct_Quantities, Focus)
                lvlConstruct_Quantities.Items(lvlConstruct_Quantities.Items.Count - 1).Selected = True
                lvlConstruct_Quantities.EnsureVisible(lvlConstruct_Quantities.Items.Count - 1)
            Else
                listfocus(lvlConstruct_Quantities, cons_id)
            End If
            newSQL.connection.Close()
        End Try
    End Sub
    Public Sub insert_update_dbContract_item_no(save_update_contract_item_no As String)
        Dim newSQ As New SQLcon
        Dim newCMD2 As New SqlCommand
        Try
            newSQ.connection.Open()
            newCMD2.Connection = newSQ.connection
            newCMD2.CommandText = "PROC_Construction_Materials"
            newCMD2.CommandType = CommandType.StoredProcedure

            If save_update_contract_item_no = "Save" Then
                newCMD2.Parameters.AddWithValue("@n", 10)
            Else
                newCMD2.Parameters.AddWithValue("@n", 11)
                newCMD2.Parameters.AddWithValue("@cont_item_no_2", old_item_no)
            End If

            newCMD2.Parameters.AddWithValue("@cont_item_no", txtItemno.Text)
            newCMD2.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        btn_save.Text = "Update"
        lbl_note.Visible = True
        txtItemno.Text = lvlConstruct_Quantities.SelectedItems(0).SubItems(1).Text
        txtItemDesc.Text = lvlConstruct_Quantities.SelectedItems(0).SubItems(2).Text
        txtSize.Text = lvlConstruct_Quantities.SelectedItems(0).SubItems(3).Text
        txtUnit.Text = lvlConstruct_Quantities.SelectedItems(0).SubItems(4).Text
        old_item_no = txtItemno.Text
    End Sub
    Private Sub FConstruct_Quantities_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Escape Then
            If MessageBox.Show("Are you sure you want to cancel Update?.", "SUPPLY INFO.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                clearfields(btn_save.Text)
            Else
                Return
            End If
        End If
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btn_search.PerformClick()
        End If
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you want to Delete the data?.", "SUPPLY INFO.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
            delete_cons_quatities(lvlConstruct_Quantities.SelectedItems(0).Text)
        Else
            Return
        End If
    End Sub
    Public Sub delete_cons_quatities(cons_id As Integer)
        Dim sqlcmd As New SqlCommand
        Try
            Sqlcon.connection.Open()
            sqlcmd.Connection = Sqlcon.connection
            sqlcmd.CommandText = "PROC_Construction_Materials"
            sqlcmd.CommandType = CommandType.StoredProcedure

            sqlcmd.Parameters.AddWithValue("@n", 9)
            sqlcmd.Parameters.AddWithValue("@value", cons_id)
            sqlcmd.ExecuteNonQuery()

            lvlConstruct_Quantities.SelectedItems(0).Remove()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sqlcon.connection.Close()
        End Try
    End Sub
    Private Sub FConstruct_Quantities_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown, Label5.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub
    Private Sub FConstruct_Quantities_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove, Label5.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub
    Private Sub FConstruct_Quantities_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp, Label5.MouseUp
        drag = False
    End Sub

    Private Sub txtUnit_TextChanged(sender As Object, e As EventArgs) Handles txtUnit.TextChanged

    End Sub

    Private Sub txtUnit_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUnit.KeyDown
        If e.KeyCode = Keys.Enter Then
            btn_save.PerformClick()
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub
End Class