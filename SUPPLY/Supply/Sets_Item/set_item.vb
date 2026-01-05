Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class set_item
    Dim id_set_name As Integer
    Dim id_dbSet_Details As Integer
    Dim z As Integer
    Dim y As Integer
    Dim n As Integer

    Dim IsFormBeingDragged As Boolean
    Dim drag As Boolean
    Dim MouseDownX As Integer
    Dim MouseDownY As Integer
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtSet_items.TextChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If MessageBox.Show("Check to warehouse database if exist.", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Panel1.Visible = True

            For Each ctr As Control In Me.Controls
                If ctr.Name = "Panel1" Then
                    ctr.Visible = True
                    FMaterials_ToolsTurnOverTextFields.get_whItem(0, cmbItemName)
                Else
                    ctr.Enabled = False
                End If
            Next

        Else
            z = get_set_items_id(ComboBox1.Text)
            load_lvl_set_items(z)
            txtSet_items.Text = ""
        End If


    End Sub
    Public Sub load_lvl_set_items(ByVal x As Integer)
        lvlSet_item.Items.Clear()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim query As String

        Try
            newSQ.connection.Open()
            query = "SELECT * FROM dbSet_Details WHERE set_item_id = '" & x & "'"

            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim a(10) As String
                a(0) = newDR.Item(0).ToString
                a(1) = newDR.Item(1).ToString
                a(2) = get_set_items_name(newDR.Item(1).ToString)
                a(3) = newDR.Item(2).ToString

                Dim lvl As New ListViewItem(a)
                lvlSet_item.Items.Add(lvl)

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Public Function get_set_items_name(ByVal x As String) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim query As String
        Try
            newSQ.connection.Open()
            query = "SELECT set_items FROM dbSet_Items WHERE set_item_id = '" & x & "'"
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_set_items_name = newDR.Item(0).ToString
            End While
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Public Function get_set_items_id(ByVal x As String) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim query As String
        Try
            newSQ.connection.Open()
            query = "SELECT set_item_id FROM dbSet_Items WHERE set_items = '" & x & "'"
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_set_items_id = newDR.Item(0).ToString
                'id_set_name = newDR.Item(0).ToString
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function


    Private Sub set_item_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        add_data_on_combobox(ComboBox1)
    End Sub
    Public Sub add_data_on_combobox(cmb As ComboBox)
        cmb.Items.Clear()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim query As String

        Try
            newSQ.connection.Open()
            query = "SELECT set_items FROM dbSet_Items"
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                cmb.Items.Add(newDR.Item(0).ToString)
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If check_if_exist_set_items(txtSet_items.Text) > 0 Then
            Dim z = MessageBox.Show("Set Items already exist on the database", "EUS Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            If z = MsgBoxResult.Cancel Then
                lvlSet_item.Enabled = True
                btnSave.Text = "Save"
                txtSet_items.Text = ""
            End If
        Else
            If btnSave.Text = "Save" Then
                save_set_item(z, txtSet_items.Text, wh_id)
                load_lvl_set_items(z)
                listfocus(lvlSet_item, y)
                txtSet_items.Text = ""
            ElseIf btnSave.Text = "Update" Then
                Dim ex = MessageBox.Show("Are you sure you want to update the selected item?", "EUS INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If ex = MsgBoxResult.Yes Then
                    update_set_item()
                    load_lvl_set_items(z)
                    listfocus(lvlSet_item, id_dbSet_Details)
                    btnSave.Text = "Save"
                    txtSet_items.Text = ""
                Else
                    txtSet_items.Text = ""
                    btnSave.Text = "Save"
                    lvlSet_item.Enabled = True
                End If
            End If
        End If
    End Sub
    Public Function check_if_exist_set_items(ByVal x As String) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim query As String
        Try
            newSQ.connection.Open()
            query = "SELECT sub_details FROM dbSet_Details WHERE sub_details='" & x & "' "
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader()

            While newDR.Read
                check_if_exist_set_items += 1
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function

    Public Sub update_set_item()
        id_dbSet_Details = lvlSet_item.SelectedItems(0).SubItems(0).Text
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        'Dim newDR As SqlDataReader
        Dim query As String
        Try
            newSQ.connection.Open()
            query = "UPDATE dbSet_Details SET sub_details = '" & txtSet_items.Text & "' WHERE set_det_id = '" & id_dbSet_Details & "' "
            newCMD = New SqlCommand(query, newSQ.connection)
            newCMD.ExecuteNonQuery()

            MessageBox.Show("Successfully Updated...", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
        lvlSet_item.Enabled = True
    End Sub
    Public Sub save_set_item(set_item_id As Integer, options As String, wh_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        'Dim newDR As SqlDataReader
        Dim query As String

        Try
            newSQ.connection.Open()
            query = "SET NOCOUNT ON INSERT INTO dbSet_Details(set_item_id,sub_details,options,wh_id)VALUES('" & set_item_id & "','" & options & "','" & "include" & "','" & wh_id & "') SELECT SCOPE_IDENTITY()"
            newCMD = New SqlCommand(query, newSQ.connection)
            y = newCMD.ExecuteScalar
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click

        If lvlSet_item.Items.Count > 0 Then
            btnSave.Text = "Update"
            id_dbSet_Details = lvlSet_item.SelectedItems(0).SubItems(0).Text
            lvlSet_item.Enabled = False
            txtSet_items.Text = lvlSet_item.SelectedItems(0).SubItems(3).Text

        End If
    End Sub

    Private Sub CMS_lvlSet_items_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CMS_lvlSet_items.Opening

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim ex = MessageBox.Show("are you sure you want to delete the selected item?", "EUS INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If ex = MsgBoxResult.Yes Then
            For Each row As ListViewItem In lvlSet_item.Items
                If row.Selected = True Then
                    delete_set_items(CInt(row.Text))
                    row.Remove()
                End If
            Next
            ' MessageBox.Show("Successfully Deleted...", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Public Sub delete_set_items(ByVal x As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        'Dim newDR As SqlDataReader
        Dim query As String
        Try
            newSQ.connection.Open()
            query = "DELETE FROM dbSet_Details WHERE set_det_id = '" & x & "' "
            newCMD = New SqlCommand(query, newSQ.connection)
            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub lvlSet_item_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvlSet_item.SelectedIndexChanged

    End Sub

    Private Sub lvlSet_item_KeyDown(sender As Object, e As KeyEventArgs) Handles lvlSet_item.KeyDown

    End Sub

    Private Sub set_item_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            txtSet_items.Text = ""
            btnSave.Text = "Save"
            lvlSet_item.Enabled = True
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim ex = MessageBox.Show("are you sure you want to delete the selected item?", "EUS INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If ex = MsgBoxResult.Yes Then
            For Each row As ListViewItem In lvlSet_item.Items
                If row.Selected = True Then
                    delete_set_items(CInt(row.Text))
                    row.Remove()
                End If
            Next
            ' MessageBox.Show("Successfully Deleted...", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
        txtSet_items.Text = ""
    End Sub
#Region "GUIForm"
    Private Sub set_item_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
        End If
    End Sub

    Private Sub set_item_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
    End Sub

    Private Sub set_item_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If IsFormBeingDragged Then
            Dim temp As Point = New Point()

            temp.X = Me.Location.X + (e.X - MouseDownX)
            temp.Y = Me.Location.Y + (e.Y - MouseDownY)
            Me.Location = temp
            temp = Nothing
        End If
    End Sub
#End Region


    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
#Region "GUI"
    Private Sub btnExit_MouseDown(sender As Object, e As MouseEventArgs) Handles btnExit.MouseDown
        btnExit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_MouseEnter(sender As Object, e As EventArgs) Handles btnExit.MouseEnter
        btnExit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_MouseLeave(sender As Object, e As EventArgs) Handles btnExit.MouseLeave
        btnExit.BackgroundImage = My.Resources.close_button
    End Sub
#End Region
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        FAdd_Set_Name.Show()
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        PictureBox1.Image = My.Resources.Plus_sign_neg
    End Sub

    Private Sub PictureBox1_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox1.MouseEnter
        PictureBox1.Image = My.Resources.Plus_sign_neg
    End Sub

    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.Image = My.Resources.Plus_sign
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        For Each ctr As Control In Me.Controls
            If ctr.Name = "Panel1" Then
                ctr.Visible = False
            Else
                ctr.Enabled = True
            End If
        Next

    End Sub

    Private Sub cmbItemName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbItemName.SelectedIndexChanged
        ListView1.Items.Clear()
        FMaterials_ToolsTurnOverTextFields.get_WhItemDesc(cmbItemName.Text, 2, ListView1)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MessageBox.Show("Are you sure you want to save this selected data?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            For Each row As ListViewItem In ListView1.Items
                If row.Checked = True Then

                    Dim set_items_id As Integer = get_id("dbSet_Items", "set_items", ComboBox1.Text, 0)
                    save_set_item(set_items_id, row.SubItems(1).Text, CInt(row.Text))

                End If
            Next

            MessageBox.Show("Successfully Saved...", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            z = get_set_items_id(ComboBox1.Text)
            load_lvl_set_items(z)
        End If

    End Sub
End Class