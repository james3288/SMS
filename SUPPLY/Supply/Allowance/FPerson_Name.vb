Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FPerson_Name
    Public SQ As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Dim z As Integer
    Dim w As Integer
    Dim tmp_full_name As String
    Dim from_allowance_table As Boolean = False
    Dim id_list As New List(Of List(Of String))

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        check_if_exist()
    End Sub
    Public Sub clear_field()
        txtLast_Name.Text = ""
        txtFirst_Name.Text = ""
        txtMiddle_Name.Text = ""
        txtExt_Name.Text = ""
    End Sub
    Public Sub update_Person_Name()
        Dim id As Integer = lvl_Person_Name.SelectedItems(0).SubItems(0).Text
        Dim NewSQlconn As New SQLcon
        Try
            NewSQlconn.connection.Open()
            Dim sqlcomm1 As New SqlCommand

            sqlcomm1.Connection = NewSQlconn.connection
            sqlcomm1.CommandText = "sp_crud_Allowance"
            sqlcomm1.CommandType = CommandType.StoredProcedure
            sqlcomm1.Parameters.AddWithValue("@n", 11)
            sqlcomm1.Parameters.AddWithValue("@person_id", id)
            sqlcomm1.Parameters.AddWithValue("@last_name", txtLast_Name.Text)
            sqlcomm1.Parameters.AddWithValue("@first_name", txtFirst_Name.Text)
            sqlcomm1.Parameters.AddWithValue("@middle_name", txtMiddle_Name.Text)
            sqlcomm1.Parameters.AddWithValue("@ext_name", txtExt_Name.Text)
            sqlcomm1.Parameters.AddWithValue("@hrms_person_id", TextBox1.Text)
            w = id
            sqlcomm1.ExecuteNonQuery()
            MessageBox.Show("Successfully updated...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            NewSQlconn.connection.Close()
        End Try
    End Sub
    Public Sub save_Person_Name()
        Dim sql1 As New SQLcon
        Try
            sql1.connection.Open()
            Dim sqlcomm1 As New SqlCommand

            sqlcomm1.Connection = sql1.connection
            sqlcomm1.CommandText = "sp_crud_Allowance"
            sqlcomm1.CommandType = CommandType.StoredProcedure
            sqlcomm1.Parameters.AddWithValue("@n", 9)
            sqlcomm1.Parameters.AddWithValue("@last_name", txtLast_Name.Text)
            sqlcomm1.Parameters.AddWithValue("@first_name", txtFirst_Name.Text)
            sqlcomm1.Parameters.AddWithValue("@middle_name", txtMiddle_Name.Text)
            sqlcomm1.Parameters.AddWithValue("@ext_name", txtExt_Name.Text)

            z = sqlcomm1.ExecuteScalar

            MessageBox.Show("Successfully Saved...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sql1.connection.Close()
        End Try
    End Sub
    Sub get_list_id(ByVal name As String)
        id_list.Clear()
        Dim i As Integer = 0
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "select id from dbAllowance where name = '" & name & "'"
            sqlcomm.CommandType = CommandType.Text
            dr = sqlcomm.ExecuteReader

            While dr.Read
                id_list.Add(New List(Of String))
                id_list(i).Add(dr.Item(0).ToString)
                i = i + 1
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Sub update_all_id()
        For Each id As List(Of String) In id_list
            'MsgBox(id(0))
            Try
                SQ.connection.Open()
                Dim sqlcomm As New SqlCommand

                sqlcomm.Connection = SQ.connection
                sqlcomm.CommandText = "sp_crud_Allowance"
                sqlcomm.CommandType = CommandType.StoredProcedure
                sqlcomm.Parameters.AddWithValue("@n", 13)
                sqlcomm.Parameters.AddWithValue("@allowance_id", id(0))
                dr = sqlcomm.ExecuteReader
                dr.Close()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                SQ.connection.Close()
            End Try
        Next
    End Sub
    Public Sub load_Person_Name()
        lvl_Person_Name.Items.Clear()
        Dim sql2 As New SQLcon
        Dim new_dr As SqlDataReader
        Try
            sql2.connection.Open()
            Dim sqlcomm2 As New SqlCommand

            sqlcomm2.Connection = sql2.connection
            sqlcomm2.CommandText = "sp_crud_Allowance"
            sqlcomm2.CommandType = CommandType.StoredProcedure
            sqlcomm2.Parameters.AddWithValue("@n", 10)

            new_dr = sqlcomm2.ExecuteReader

            While new_dr.Read
                Dim a(20) As String
                a(0) = new_dr.Item("person_id").ToString
                a(1) = new_dr.Item("last_name").ToString
                a(2) = new_dr.Item("first_name").ToString
                a(3) = new_dr.Item("middle_name").ToString
                a(4) = new_dr.Item("ext_name").ToString
                a(5) = new_dr.Item("hrms_person_id").ToString

                Dim lvl As New ListViewItem(a)
                lvl_Person_Name.Items.Add(lvl)

            End While
            new_dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sql2.connection.Close()
        End Try
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        If lvl_Person_Name.SelectedItems.Count > 0 Then
            btnSave.Text = "Update"
            txtLast_Name.Text = lvl_Person_Name.SelectedItems(0).SubItems(1).Text
            txtFirst_Name.Text = lvl_Person_Name.SelectedItems(0).SubItems(2).Text
            txtMiddle_Name.Text = lvl_Person_Name.SelectedItems(0).SubItems(3).Text
            txtExt_Name.Text = lvl_Person_Name.SelectedItems(0).SubItems(4).Text
            TextBox1.Text = lvl_Person_Name.SelectedItems(0).SubItems(5).Text

            lvl_Person_Name.Enabled = False
            from_allowance_table = False
        End If
    End Sub



    Private Sub lvl_Person_Name_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If cmbSearch.Text = "Last Name" Then
            Search_Last_Name()
        End If
    End Sub
    Public Sub Search_Last_Name()
        lvl_Person_Name.Items.Clear()
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_Allowance"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 14)
            sqlcomm.Parameters.AddWithValue("@last_name", txtSearch.Text)

            dr = sqlcomm.ExecuteReader

            While dr.Read
                Dim a(20) As String
                a(0) = dr.Item("person_id").ToString
                a(1) = dr.Item("last_name").ToString
                a(2) = dr.Item("first_name").ToString
                a(3) = dr.Item("middle_name").ToString
                a(4) = dr.Item("ext_name").ToString
                a(5) = dr.Item("hrms_person_id").ToString

                Dim lvl As New ListViewItem(a)
                lvl_Person_Name.Items.Add(lvl)
                'MsgBox("test")
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub FPerson_Name_Closed(sender As Object, e As EventArgs) Handles Me.Closed
    End Sub

    Private Sub cmbSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearch.SelectedIndexChanged

    End Sub
    Public Sub check_if_exist()
        Try

            If btnSave.Text = "Save" Then
                MsgBox("Unable to Save, This is not Currently Running. EVER!")
                'save_Person_Name()
                'load_Person_Name()
                'listfocus(lvl_Person_Name, z)
                'clear_field()
            Else btnSave.Text = "Update"
                Dim ex = MessageBox.Show("Are you sure u want to update the SELECTED item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If ex = MsgBoxResult.Yes Then

                    'SQ.connection.Open()
                    'Dim sqlcomm As New SqlCommand

                    'sqlcomm.Connection = SQ.connection
                    'sqlcomm.CommandText = "sp_crud_Allowance"
                    'sqlcomm.CommandType = CommandType.StoredProcedure
                    'sqlcomm.Parameters.AddWithValue("@n", 15)
                    'sqlcomm.Parameters.AddWithValue("@string_name", txtLast_Name.Text + txtFirst_Name.Text + txtMiddle_Name.Text + txtExt_Name.Text)
                    '' MsgBox(txtLast_Name.Text + txtFirst_Name.Text + txtMiddle_Name.Text + txtExt_Name.Text)
                    'dr = sqlcomm.ExecuteReader

                    'If dr.HasRows Then
                    '    MsgBox("Name already exist")
                    'Else
                    update_Person_Name()
                    load_Person_Name()
                    listfocus(lvl_Person_Name, w)
                    'btnSave.Text = "Save"
                    btnSave.Text = "Update"
                    lvl_Person_Name.Enabled = True
                    clear_field()
                    'End If

                End If
            End If

            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub FPerson_Name_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            lvl_Person_Name.Enabled = True
            clear_field()
            txtLast_Name.Focus()
            btnSave.Text = "Save"
        ElseIf e.Control And e.KeyCode = Keys.S Then
            check_if_exist()
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim ex = MessageBox.Show("Are you sure u want to DELETE the SELECTED items?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If ex = MsgBoxResult.Yes Then
            For Each row As ListViewItem In lvl_Person_Name.SelectedItems
                Delete_Person_name(row.SubItems(0).Text)
                row.Remove()
                ' MsgBox(row.SubItems(0).Text)
            Next
            MessageBox.Show("Successfully Deleted...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Public Sub Delete_Person_name(ByVal x As Integer)
        ' Dim i As Integer = lvlLiquidationReport.SelectedItems(0).SubItems(0).Text
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_Allowance"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 16)
            sqlcomm.Parameters.AddWithValue("id", x)
            sqlcomm.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub lvl_Person_Name_DoubleClick(sender As Object, e As EventArgs)
        With FAllowance
            .txtName.Text = lvl_Person_Name.SelectedItems(0).SubItems(2).Text + " " + lvl_Person_Name.SelectedItems(0).SubItems(1).Text
            .txtName.Focus()
        End With
        Me.Close()
    End Sub

    Private Sub FPerson_Name_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbSearch.Text = "Last Name"
    End Sub

    Private Sub FPerson_Name_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Allowance_sum.save_name_list(1)
    End Sub


End Class