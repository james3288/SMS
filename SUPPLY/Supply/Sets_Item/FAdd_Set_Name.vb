Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FAdd_Set_Name
    Dim IsFormBeingDragged As Boolean
    Dim drag As Boolean
    Dim MouseDownX As Integer
    Dim MouseDownY As Integer

    Dim y As Integer
    Dim z As Integer
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
        ' set_item.ShowDialog()

        With set_item
            .add_data_on_combobox(.ComboBox1)
        End With
    End Sub

    Private Sub FAdd_Set_Name_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_Add_set_name()

    End Sub
    Public Sub load_Add_set_name()
        lvl_Set_Name.Items.Clear()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim query As String
        Try
            newSQ.connection.Open()
            query = "SELECT * FROM dbSet_Items"
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim a(10) As String
                a(0) = newDR.Item(0).ToString
                a(1) = newDR.Item(1).ToString

                Dim lvl As New ListViewItem(a)
                lvl_Set_Name.Items.Add(lvl)

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
#Region "GUIForm"
    Private Sub FAdd_Set_Name_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
        End If
    End Sub

    Private Sub FAdd_Set_Name_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
    End Sub

    Private Sub FAdd_Set_Name_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If IsFormBeingDragged Then
            Dim temp As Point = New Point()

            temp.X = Me.Location.X + (e.X - MouseDownX)
            temp.Y = Me.Location.Y + (e.Y - MouseDownY)
            Me.Location = temp
            temp = Nothing
        End If
    End Sub
#End Region
    Private Sub btnSave_Set_Name_Click(sender As Object, e As EventArgs) Handles btnSave_Set_Name.Click
        If check_if_exist_set_name(txtSet_name.Text) > 0 Then
            Dim m = MessageBox.Show("Set Items already exist on the database", "EUS Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop)
            If m = MsgBoxResult.Cancel Then
                lvl_Set_Name.Enabled = True
                btnSave_Set_Name.Text = "Save"
                txtSet_name.Text = ""
            End If
            txtSet_name.Focus()
            'MsgBox(check_if_exist_set_name(txtSet_name.Text))
        Else
            If btnSave_Set_Name.Text = "Save" Then
                save_set_name()
                load_Add_set_name()
                listfocus(lvl_Set_Name, y)
                txtSet_name.Text = ""
                txtSet_name.Focus()
            ElseIf btnSave_Set_Name.Text = "Update" Then
                Dim ex = MessageBox.Show("Are you sure you want to update the selected item?", "EUS INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If ex = MsgBoxResult.Yes Then
                    update_set_name()
                    load_Add_set_name()
                    listfocus(lvl_Set_Name, z)
                    lvl_Set_Name.Enabled = True
                    btnSave_Set_Name.Text = "Save"
                    txtSet_name.Text = ""
                    txtSet_name.Focus()
                Else
                    txtSet_name.Text = ""
                    btnSave_Set_Name.Text = "Save"
                    lvl_Set_Name.Enabled = True
                    txtSet_name.Focus()
                End If
            End If
        End If
    End Sub
    Public Function check_if_exist_set_name(ByVal x As String) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim query As String
        Try
            newSQ.connection.Open()
            query = "SELECT set_items FROM dbSet_Items WHERE set_items = '" & x & "' "
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader()

            While newDR.Read
                check_if_exist_set_name += 1
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Sub update_set_name()
        z = lvl_Set_Name.SelectedItems(0).SubItems(0).Text
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        '  Dim newDR As SqlDataReader
        Dim query As String
        Try
            newSQ.connection.Open()
            query = "UPDATE dbSet_Items SET set_items = '" & txtSet_name.Text & "' WHERE set_item_id = '" & z & "'"
            newCMD = New SqlCommand(query, newSQ.connection)
            newCMD.ExecuteNonQuery()

            MessageBox.Show("Successfully Updated...", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Public Sub save_set_name()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        '  Dim newDR As SqlDataReader
        Dim query As String
        Try
            newSQ.connection.Open()
            query = "SET NOCOUNT ON INSERT INTO dbSet_Items(set_items)VALUES('" & txtSet_name.Text & "') SELECT SCOPE_IDENTITY()"
            newCMD = New SqlCommand(query, newSQ.connection)
            y = newCMD.ExecuteScalar

            MessageBox.Show("Successfully Saved...", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        If lvl_Set_Name.Items.Count > 0 Then
            btnSave_Set_Name.Text = "Update"
            txtSet_name.Text = lvl_Set_Name.SelectedItems(0).SubItems(1).Text
            lvl_Set_Name.Enabled = False
        End If
    End Sub

    Private Sub FAdd_Set_Name_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            txtSet_name.Text = ""
            btnSave_Set_Name.Text = "Save"
            lvl_Set_Name.Enabled = True
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim ex = MessageBox.Show("are you sure you want to delete the selected item?", "EUS INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If ex = MsgBoxResult.Yes Then
            For Each row As ListViewItem In lvl_Set_Name.Items
                If row.Selected = True Then
                    delete_set_name(CInt(row.Text))
                    row.Remove()
                End If
            Next
        End If
    End Sub
    Public Sub delete_set_name(ByVal x As Integer)
        Dim d As Integer = lvl_Set_Name.SelectedItems(0).SubItems(0).Text
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        '  Dim newDR As SqlDataReader
        Dim query As String
        Try
            newSQ.connection.Open()
            query = "DELETE FROM dbSet_Items WHERE set_item_id = '" & d & "'"
            newCMD = New SqlCommand(query, newSQ.connection)
            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
#Region "GUI exit"
    Private Sub Button1_MouseDown(sender As Object, e As MouseEventArgs) Handles btnExit.MouseDown
        btnExit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_MouseEnter(sender As Object, e As EventArgs) Handles btnExit.MouseEnter
        btnExit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_MouseLeave(sender As Object, e As EventArgs) Handles btnExit.MouseLeave
        btnExit.BackgroundImage = My.Resources.close_button
    End Sub
#End Region
End Class