Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FQtyTakeOffPartView
    Public Sqlcon As New SQLcon
    Dim sqlcmd As SqlCommand
    Dim sqldr As SqlDataReader
    Public Sub save_QTO_PartView()
        Dim newSQ As New SQLcon
        Dim newCMD As New SqlCommand
        Dim z As Integer

        Try
            newSQ.connection.Open()
            newCMD.Connection = newSQ.connection
            newCMD.CommandText = "proc_Quantity_takeoff"
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 66)
            newCMD.Parameters.AddWithValue("@Part_Category", "Part " + txtPart.Text)
            newCMD.Parameters.AddWithValue("@name_category", txtNameCategory.Text)

            z = newCMD.ExecuteScalar
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
        MsgBox("Successfully Save")
        load_QTO_PartView()
        listfocus(lvlPartCategory, z)
    End Sub
    Public Sub load_QTO_PartView()
        lvlPartCategory.Items.Clear()
        Dim nwsqlcmd As New SqlCommand
        Dim a(30) As String
        Try
            Sqlcon.connection.Open()
            nwsqlcmd.Connection = Sqlcon.connection
            nwsqlcmd.CommandText = "proc_Quantity_takeoff"
            nwsqlcmd.CommandType = CommandType.StoredProcedure
            nwsqlcmd.Parameters.AddWithValue("@n", 67)

            sqldr = nwsqlcmd.ExecuteReader
            While sqldr.Read
                a(0) = sqldr.Item(0).ToString
                a(1) = sqldr.Item(1).ToString
                a(2) = sqldr.Item(2).ToString

                Dim lvlList As New ListViewItem(a)
                lvlPartCategory.Items.Add(lvlList)
            End While
            sqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sqlcon.connection.Close()
        End Try
    End Sub
    Public Sub update_QTO_PartView()
        Dim newSQ As New SQLcon
        Dim newCMD As New SqlCommand
        Dim x As Integer = lvlPartCategory.SelectedItems(0).SubItems(0).Text

        Try
            newSQ.connection.Open()
            newCMD.Connection = newSQ.connection
            newCMD.CommandText = "proc_Quantity_takeoff"
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 68)
            newCMD.Parameters.AddWithValue("@id_part_cat", x)
            newCMD.Parameters.AddWithValue("@Part_Category", "Part " + txtPart.Text)
            newCMD.Parameters.AddWithValue("@name_category", txtNameCategory.Text)
            newCMD.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
        MsgBox("Successfully Updated")

        load_QTO_PartView()
        listfocus(lvlPartCategory, x)
        lvlPartCategory.Enabled = True
        txtPart.Text = ""
        txtNameCategory.Text = ""
        btn_save.Text = "Save"
    End Sub
    Public Sub delete_QTO_PartView(id As Integer)
        Dim sqlcmd As New SqlCommand
        Try
            Sqlcon.connection.Open()
            sqlcmd.Connection = Sqlcon.connection
            sqlcmd.CommandText = "proc_Quantity_takeoff"
            sqlcmd.CommandType = CommandType.StoredProcedure
            sqlcmd.Parameters.AddWithValue("@n", 69)
            sqlcmd.Parameters.AddWithValue("@id_part_cat", id)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sqlcon.connection.Close()
        End Try
    End Sub
    Public Sub search_QTO_PartView(ByVal value As String)
        lvlPartCategory.Items.Clear()
        Dim nwsqlcmd As New SqlCommand
        Dim a(30) As String
        Try
            Sqlcon.connection.Open()
            nwsqlcmd.Connection = Sqlcon.connection
            nwsqlcmd.CommandText = "proc_Quantity_takeoff"
            nwsqlcmd.CommandType = CommandType.StoredProcedure
            nwsqlcmd.Parameters.AddWithValue("@n", 70)
            nwsqlcmd.Parameters.AddWithValue("@Part_Category", value)
            sqldr = nwsqlcmd.ExecuteReader
            While sqldr.Read
                a(0) = sqldr.Item(0).ToString
                a(1) = sqldr.Item(1).ToString
                a(2) = sqldr.Item(2).ToString

                Dim lvlList As New ListViewItem(a)
                lvlPartCategory.Items.Add(lvlList)
            End While
            sqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sqlcon.connection.Close()
        End Try
    End Sub
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If btn_save.Text = "Save" Then
            save_QTO_PartView()
        ElseIf btn_save.Text = "Update" Then
            update_QTO_PartView()
        End If
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        btn_save.Text = "Update"
        Dim str As String
        Dim strArr() As String
        str = lvlPartCategory.SelectedItems(0).SubItems(1).Text
        strArr = str.Split(" ")
        txtPart.Text = strArr(1)
        txtNameCategory.Text = lvlPartCategory.SelectedItems(0).SubItems(2).Text
        lvlPartCategory.Enabled = False
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        search_QTO_PartView(txtSearch.Text)
    End Sub

    Private Sub FQtyTakeOffPartView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_QTO_PartView()
        txtPart.Focus()
    End Sub

    Private Sub FQtyTakeOffPartView_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If MessageBox.Show("Are you sure you want to cancel Update?.", "SUPPLY INFO.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                txtPart.Text = ""
                txtNameCategory.Text = ""
                lvlPartCategory.Enabled = True
                btn_save.Text = "Save"
            End If
        ElseIf e.Control And e.KeyCode = Keys.S Then
            btn_save.PerformClick()
        End If
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you want to Delete the data?.", "SUPPLY INFO.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
            delete_QTO_PartView(lvlPartCategory.SelectedItems(0).Text)
            lvlPartCategory.SelectedItems(0).Remove()
        Else : Return
        End If
    End Sub

    Private Sub txtPart_TextChanged(sender As Object, e As EventArgs) Handles txtPart.TextChanged

    End Sub

    Private Sub txtbox_GotFocus(sender As Object, e As EventArgs) Handles txtPart.GotFocus, txtNameCategory.GotFocus, txtSearch.GotFocus
        sender.backcolor = Color.Yellow
    End Sub

    Private Sub txtbox_Leave(sender As Object, e As EventArgs) Handles txtSearch.Leave, txtPart.Leave, txtNameCategory.Leave
        sender.backcolor = Color.White
    End Sub

    Private Sub lvlPartCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvlPartCategory.SelectedIndexChanged

    End Sub

    Private Sub lvlPartCategory_DoubleClick(sender As Object, e As EventArgs) Handles lvlPartCategory.DoubleClick
        If lvlPartCategory.Items.Count > 0 Then
            FQty_takeoff.txtPart_category.Text = lvlPartCategory.SelectedItems(0).SubItems(1).Text + " - " + lvlPartCategory.SelectedItems(0).SubItems(2).Text
        End If
    End Sub

    Private Sub FQtyTakeOffPartView_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        With FQty_takeoff
            .save_data_part_category(57)
            .load_list_part_category()
        End With
    End Sub
End Class