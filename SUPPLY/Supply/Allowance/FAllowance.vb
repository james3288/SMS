
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FAllowance
    Public SQ As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Public public_query As String
    Dim txtbox As TextBox
    Public textname As String
    Dim z As Integer
    Dim w As Integer

    Dim IsFormBeingDragged As Boolean
    Dim drag As Boolean
    Dim MouseDownX As Integer
    Dim MouseDownY As Integer
    Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
    Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
    Public name_list As New List(Of List(Of String))
    ' Dim name_list As New List(Of String)
    Dim name_list_location As New List(Of String)
    Dim name_list_amount As New List(Of String)
    Dim name_list_amount_salary As New List(Of String)
    Dim list_name_operator As New List(Of List(Of String))
    Private Sub FAllowance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '  load_allowance()
        load_Project_Worksite_Designation(0)
        load_Project_Worksite_Designation(1)
        'load_Project_Worksite_Designation(2)
        save_name_list(1) 'name data save
        save_name_list(2) 'location data save
        save_name_list(3) 'amount data save
        save_name_list(4)
        save_list_name()
    End Sub
    Public Sub save_list_name()
        list_name_operator = New List(Of List(Of String))
        Dim row As Integer
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_Allowance"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 18)
            dr = sqlcomm.ExecuteReader

            While dr.Read
                list_name_operator.Add(New List(Of String))
                list_name_operator(row).Add(dr.Item(0).ToString)
                row = row + 1
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

        Dim txt_row As New AutoCompleteStringCollection
        For Each list_row As List(Of String) In list_name_operator
            txt_row.Add(list_row(0))
        Next

        txtName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtName.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtName.AutoCompleteCustomSource = txt_row
    End Sub

    Public Sub load_Project_Worksite_Designation(ByVal x As Integer)
        Try
            SQ.connection1.Open()
            If x = 0 Or x = 1 Then
                public_query = "SELECT * FROM dbprojectdesc ORDER BY project_desc ASC"
            ElseIf x = 2 Then
                public_query = "SELECT * FROM dbequipment_list ORDER BY plate_no ASC"
            End If
            cmd = New SqlCommand(public_query, SQ.connection1)
            dr = cmd.ExecuteReader

            While dr.Read
                If x = 0 Then
                    cmbProjectWorksite.Items.Add(dr.Item("project_desc").ToString)
                ElseIf x = 1 Then
                    cmbSearch_Project_WorkSite.Items.Add(dr.Item("project_desc").ToString)
                ElseIf x = 2 Then
                    cmbDesignation.Items.Add(dr.Item("plate_no").ToString)
                End If

            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection1.Close()
        End Try
    End Sub

    Private Sub FAllowance_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
    End Sub

    Private Sub FAllowance_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
    End Sub

    Private Sub FAllowance_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
    End Sub

    Private Sub TableLayoutPanel1_Paint_1(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint
    End Sub

    Private Sub TableLayoutPanel1_MouseDown(sender As Object, e As MouseEventArgs) Handles TableLayoutPanel1.MouseDown
    End Sub

    Private Sub TableLayoutPanel1_MouseUp(sender As Object, e As MouseEventArgs) Handles TableLayoutPanel1.MouseUp
    End Sub

    Private Sub TableLayoutPanel1_MouseMove(sender As Object, e As MouseEventArgs) Handles TableLayoutPanel1.MouseMove
    End Sub
    Private Sub LlbTitleAllowanceSummary_Click(sender As Object, e As EventArgs) Handles LlbTitleAllowanceSummary.Click
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If cmbProjectWorksite.Text = "" Then
            MessageBox.Show("Project/Worksite field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            cmbProjectWorksite.Focus()
        ElseIf txtLocation.Text = "" Then
            MessageBox.Show("Location field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtLocation.Focus()
        ElseIf txtName.Text = "" Then
            MessageBox.Show("Name field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtName.Focus()
        ElseIf cmbDesignation.Text = "" Then
            MessageBox.Show("Designation field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            cmbDesignation.Focus()
        ElseIf txtVoucher.Text = "" Then
            MessageBox.Show("Voucher No. field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtVoucher.Focus()
        ElseIf txtAmount.Text = "" Then
            MessageBox.Show("Amount field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtAmount.Focus()
        ElseIf txtAmount_Salary.Text = "" Then
            MessageBox.Show("Amount Salary field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtAmount_Salary.Focus()
        Else
            If btnSave.Text = "Save" Then
                save_allowance()
                cmbSearch.Text = "Date"
                DTP_search_Allowance.Text = DTP_Allowance.Text
                btnSearch.PerformClick()
                listfocus(lvlAllowance, z)
                clear_fields(0)
                txtName.Focus()
                ' load_allowance()
            ElseIf btnSave.Text = "Update" Then
                Dim ex = MessageBox.Show("Are you sure u want to update the SELECTED item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If ex = MsgBoxResult.Yes Then
                    update_allowance()
                    cmbSearch.Text = "Date"
                    DTP_search_Allowance.Text = DTP_Allowance.Text
                    btnSearch.PerformClick()
                    listfocus(lvlAllowance, w)
                    btnSave.Text = "Save"
                    clear_fields(1)
                    DTP_Allowance.Focus()
                End If
            End If
        End If
    End Sub
    Function check_id_is_exist(ByVal id As String) As Boolean
        For Each cur_id As List(Of String) In name_list
            If id.Equals(cur_id(0)) Then
                Return True
                Exit For
            End If
        Next
    End Function
    Public Sub clear_fields(ByVal x As Integer)
        If x = 0 Then
            txtName.Text = ""
            cmbDesignation.Text = Nothing
            txtVoucher.Text = ""
            txtAmount.Text = ""
            txtAmount_Salary.Text = ""
            btnSave.Text = "Save"
        ElseIf x = 1 Then
            cmbProjectWorksite.Text = Nothing
            txtLocation.Text = ""
            txtName.Text = ""
            cmbDesignation.Text = Nothing
            txtVoucher.Text = ""
            txtAmount.Text = ""
            txtAmount_Salary.Text = ""
            btnSave.Text = "Save"
        Else

        End If
    End Sub
    Public Sub update_allowance()
        Dim id As Integer = lvlAllowance.SelectedItems(0).SubItems(0).Text
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_Allowance"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 2)
            sqlcomm.Parameters.AddWithValue("@Id", id)
            sqlcomm.Parameters.AddWithValue("@Date", DateTime.Parse(DTP_Allowance.Text))
            sqlcomm.Parameters.AddWithValue("@Project_WorkSite", get_id_Project_Worksite(cmbProjectWorksite.Text))
            sqlcomm.Parameters.AddWithValue("@Location", txtLocation.Text)
            sqlcomm.Parameters.AddWithValue("@Name", txtName.Text)
            sqlcomm.Parameters.AddWithValue("@Designation", get_id_Designation(cmbDesignation.Text))
            sqlcomm.Parameters.AddWithValue("@Voucher", txtVoucher.Text)
            sqlcomm.Parameters.AddWithValue("@Amount", CDbl(txtAmount.Text))
            sqlcomm.Parameters.AddWithValue("@Amount_Salary", CDbl(txtAmount_Salary.Text))

            sqlcomm.ExecuteNonQuery()
            MessageBox.Show("Successfully Updated...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Sub load_allowance()
        lvlAllowance.Items.Clear()

        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_Allowance"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 1)
            dr = sqlcomm.ExecuteReader
            While dr.Read
                Dim a(20) As String
                a(0) = dr.Item(0).ToString
                a(1) = dr.Item(1).ToString
                a(2) = get_ProjectName_Designation(dr.Item(2).ToString, 0)
                a(3) = dr.Item(3).ToString
                a(4) = dr.Item(4).ToString
                a(5) = get_ProjectName_Designation(dr.Item(5).ToString, 1)
                a(6) = dr.Item(6).ToString
                a(7) = dr.Item(7).ToString

                Dim lvl As New ListViewItem(a)
                lvlAllowance.Items.Add(lvl)
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Function get_ProjectName_Designation(ByVal x As String, ByVal n As Integer) As String
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand

        Try
            SQ.connection1.Open()
            If n = 0 Then
                public_query = "SELECT project_desc FROM dbprojectdesc WHERE proj_id = '" & x & "' "
            ElseIf n = 1 Then
                public_query = "SELECT plate_no FROM dbequipment_list WHERE equipListID = '" & x & "' "
            End If
            newcmd = New SqlCommand(public_query, SQ.connection1)
            newdr = newcmd.ExecuteReader

            While newdr.Read
                get_ProjectName_Designation = newdr.Item(0).ToString
            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection1.Close()
        End Try
    End Function
    Public Sub save_allowance()
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand()

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_Allowance"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 0)
            sqlcomm.Parameters.AddWithValue("@Date", DateTime.Parse(DTP_Allowance.Text))
            sqlcomm.Parameters.AddWithValue("@Project_WorkSite", get_id_Project_Worksite(cmbProjectWorksite.Text))
            sqlcomm.Parameters.AddWithValue("@Location", txtLocation.Text)
            sqlcomm.Parameters.AddWithValue("@Name", txtName.Text)
            sqlcomm.Parameters.AddWithValue("@Designation", get_id_Designation(cmbDesignation.Text))
            sqlcomm.Parameters.AddWithValue("@Voucher", txtVoucher.Text)
            sqlcomm.Parameters.AddWithValue("@Amount", CDbl(txtAmount.Text))
            sqlcomm.Parameters.AddWithValue("@Amount_Salary", CDbl(txtAmount_Salary.Text))

            z = sqlcomm.ExecuteScalar()
            MessageBox.Show("Successfully Saved...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Function get_id_Project_Worksite(ByVal x As String) As Integer
        Try
            SQ.connection1.Open()
            public_query = "SELECT proj_id FROM dbprojectdesc WHERE project_desc = '" & x & "'"
            cmd = New SqlCommand(public_query, SQ.connection1)
            dr = cmd.ExecuteReader

            While dr.Read
                get_id_Project_Worksite = dr.Item(0).ToString
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection1.Close()
        End Try

    End Function
    Public Function get_id_Designation(ByVal x As String) As Integer
        Try
            SQ.connection1.Open()
            public_query = "SELECT equipListID FROM dbequipment_list WHERE plate_no = '" & x & "'"
            cmd = New SqlCommand(public_query, SQ.connection1)
            dr = cmd.ExecuteReader

            While dr.Read
                get_id_Designation = dr.Item(0).ToString
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection1.Close()
        End Try

    End Function
    Private Sub txtDesignation_TextChanged1(sender As Object, e As EventArgs) Handles txtName.TextChanged

    End Sub
    Public Sub save_name_list(ByVal n As Integer)
        Dim i As Integer = 0
        Try
            SQ.connection.Open()
            If n = 1 Then
                public_query = "select person_id, (last_name +', ' + first_name + ' ' + middle_name + ' ' + ext_name) from dbo.tblPerson "
            ElseIf n = 2 Then
                public_query = "SELECT DISTINCT Location FROM dbAllowance"
            ElseIf n = 3 Then
                public_query = "SELECT DISTINCT Amount FROM dbAllowance"
            ElseIf n = 4 Then
                public_query = "SELECT DISTINCT Amount_Salary FROM dbAllowance"
            End If

            cmd = New SqlCommand(public_query, SQ.connection)
            dr = cmd.ExecuteReader

            While dr.Read
                If n = 1 Then
                    name_list.Add(New List(Of String))
                    name_list(i).Add(dr.Item(0).ToString)
                    name_list(i).Add(dr.Item(1).ToString)
                ElseIf n = 2 Then
                    name_list_location.Add(dr.Item(0).ToString)
                ElseIf n = 3 Then
                    name_list_amount.Add(dr.Item(0).ToString)
                ElseIf n = 4 Then
                    name_list_amount_salary.Add(dr.Item(0).ToString)
                End If
                i = i + 1
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("Error MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

        'list name_list_location
        Dim txt_row2 As New AutoCompleteStringCollection
        For Each list_location In name_list_location
            txt_row2.Add(list_location)
        Next
        txtLocation.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtLocation.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtLocation.AutoCompleteCustomSource = txt_row2

        'list name_list_amount
        Dim txt_row3 As New AutoCompleteStringCollection
        For Each list_amount In name_list_amount
            txt_row3.Add(list_amount)
        Next
        txtAmount.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtAmount.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtAmount.AutoCompleteCustomSource = txt_row3
    End Sub
    Private Sub txt_cmbbox_GotFocus(sender As Object, e As EventArgs) Handles DTP_Allowance.GotFocus, cmbProjectWorksite.GotFocus, txtLocation.GotFocus, txtName.GotFocus, txtVoucher.GotFocus, txtAmount.GotFocus, cmbSearch.GotFocus, cmbSearch_Project_WorkSite.GotFocus, txtSearch.GotFocus, cmbDesignation.GotFocus, txtAmount_Salary.GotFocus
        sender.backcolor = Color.Yellow
    End Sub
    Private Sub txtname_name(sender As Object, e As EventArgs) Handles txtName.Leave
        cmbDesignation.Items.Clear()
        If txtName.Text <> "" Then
            Try
                SQ.connection.Open()
                Dim sqlcomm As New SqlCommand
                sqlcomm.Connection = SQ.connection
                sqlcomm.CommandText = "sp_crud_Allowance"
                sqlcomm.CommandType = CommandType.StoredProcedure
                sqlcomm.Parameters.AddWithValue("@n", 19)
                sqlcomm.Parameters.AddWithValue("@operator", txtName.Text)
                sqlcomm.Parameters.AddWithValue("@eu_date", CDate(DTP_Allowance.Text))
                dr = sqlcomm.ExecuteReader
                If dr.HasRows = True Then
                    While dr.Read
                        cmbDesignation.Items.Add(dr.Item(0).ToString)
                    End While
                    dr.Close()
                Else
                    'MsgBox("ian")
                    load_plate_no()
                End If
            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                SQ.connection.Close()
            End Try
        End If
    End Sub
    Public Sub load_plate_no()
        Dim newSqlcon1 As New SQLcon
        Dim newdr1 As SqlDataReader

        Try
            newSqlcon1.connection.Open()
            Dim newsqlcom1 As New SqlCommand

            newsqlcom1.Connection = newSqlcon1.connection
            newsqlcom1.CommandText = "sp_crud_Allowance"
            newsqlcom1.CommandType = CommandType.StoredProcedure
            newsqlcom1.Parameters.AddWithValue("@n", 20)
            newdr1 = newsqlcom1.ExecuteReader

            While newdr1.Read
                cmbDesignation.Items.Add(newdr1.Item(0).ToString)
            End While
            newdr1.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSqlcon1.connection.Close()
        End Try
    End Sub

    Private Sub txt_cmbbox_leave(sender As Object, e As EventArgs) Handles DTP_Allowance.Leave, cmbProjectWorksite.Leave, txtLocation.Leave, txtName.Leave, txtVoucher.Leave, txtAmount.Leave, cmbSearch.Leave, cmbSearch_Project_WorkSite.Leave, txtSearch.Leave, cmbDesignation.Leave, txtAmount_Salary.Leave
        sender.backcolor = Color.White
    End Sub
    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged

    End Sub

    Private Sub txtName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtName.KeyDown

    End Sub

    Private Sub txtLocation_TextChanged(sender As Object, e As EventArgs) Handles txtLocation.TextChanged

    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        If lvlAllowance.SelectedItems.Count > 0 Then
            DTP_Allowance.Text = lvlAllowance.SelectedItems(0).SubItems(1).Text
            cmbProjectWorksite.Text = lvlAllowance.SelectedItems(0).SubItems(2).Text
            txtLocation.Text = lvlAllowance.SelectedItems(0).SubItems(3).Text
            txtName.Text = lvlAllowance.SelectedItems(0).SubItems(4).Text
            cmbDesignation.Text = lvlAllowance.SelectedItems(0).SubItems(5).Text
            txtVoucher.Text = lvlAllowance.SelectedItems(0).SubItems(6).Text
            txtAmount.Text = lvlAllowance.SelectedItems(0).SubItems(7).Text
            txtAmount_Salary.Text = lvlAllowance.SelectedItems(0).SubItems(8).Text

            btnSave.Focus()
            btnSave.Text = "Update"
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim ex = MessageBox.Show("Are you sure u want to DELETE the SELECTED item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If ex = MsgBoxResult.Yes Then
            For Each row As ListViewItem In lvlAllowance.Items
                If row.Selected = True Then
                    DeleteRecord_Allowance()
                    row.Remove()
                End If
            Next
            MessageBox.Show("Successfully Deleted...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Public Sub DeleteRecord_Allowance()
        Dim i As Integer = lvlAllowance.SelectedItems(0).SubItems(0).Text
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_Allowance"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 3)
            sqlcomm.Parameters.AddWithValue("@id", i)
            sqlcomm.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub cmbSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearch.SelectedIndexChanged
        If cmbSearch.Text = "Date" Then
            DTP_search_Allowance.Location = New Point(txtSearch.Bounds.Left, txtSearch.Bounds.Top)
            DTP_search_Allowance.Parent = GroupBox1
            DTP_search_Allowance.Visible = True
            DTP_search_Allowance.BringToFront()
            cmbSearch_Project_WorkSite.Visible = False
        ElseIf cmbSearch.Text = "Project Work Site" Then
            load_Project_Worksite_Designation(1)
            cmbSearch_Project_WorkSite.Location = New Point(txtSearch.Bounds.Left, txtSearch.Bounds.Top)
            cmbSearch_Project_WorkSite.Parent = GroupBox1
            DTP_search_Allowance.Visible = False
            cmbSearch_Project_WorkSite.Visible = True
            cmbSearch_Project_WorkSite.BringToFront()
        ElseIf cmbSearch.Text = "Name" Then
            DTP_search_Allowance.Visible = False
            cmbSearch_Project_WorkSite.Visible = False
        ElseIf cmbSearch.Text = "Voucher" Then
            DTP_search_Allowance.Visible = False
            cmbSearch_Project_WorkSite.Visible = False
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If cmbSearch.Text = "Project Work Site" Then
            Search_allowance(0)
        ElseIf cmbSearch.Text = "Name" Then
            Search_allowance(1)
        ElseIf cmbSearch.Text = "Voucher" Then
            Search_allowance(2)
        ElseIf cmbSearch.Text = "Date" Then
            Search_allowance(3)
        ElseIf cmbSearch.Text = "Plate No." Then
            Search_allowance(4)
        End If
    End Sub
    Public Sub Search_allowance(ByVal x As Integer)
        lvlAllowance.Items.Clear()
        Dim i As Integer = get_id_Project_Worksite(cmbSearch_Project_WorkSite.Text)
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_Allowance"
            sqlcomm.CommandType = CommandType.StoredProcedure

            If x = 0 Then
                sqlcomm.Parameters.AddWithValue("@n", 4)
                sqlcomm.Parameters.AddWithValue("@Project_WorkSite", i)
            ElseIf x = 1 Then
                sqlcomm.Parameters.AddWithValue("@n", 5)
                sqlcomm.Parameters.AddWithValue("@Name", txtSearch.Text)
            ElseIf x = 2 Then
                sqlcomm.Parameters.AddWithValue("@n", 6)
                sqlcomm.Parameters.AddWithValue("@Voucher", txtSearch.Text)
            ElseIf x = 3 Then
                sqlcomm.Parameters.AddWithValue("@n", 7)
                sqlcomm.Parameters.AddWithValue("@date", Date.Parse(DTP_search_Allowance.Text))
            ElseIf x = 4 Then
                sqlcomm.Parameters.AddWithValue("@n", 17)
                sqlcomm.Parameters.AddWithValue("@plateno", txtSearch.Text)
            End If

            dr = sqlcomm.ExecuteReader

            While dr.Read

                Dim a(20) As String
                a(0) = dr.Item(0).ToString
                a(1) = Format(Date.Parse(dr.Item("Date").ToString), "MM/dd/yyyy")
                a(2) = get_ProjectName_Designation(dr.Item(2).ToString, 0)
                a(3) = dr.Item(3).ToString
                a(4) = dr.Item(4).ToString
                If x = 4 Then
                    a(5) = dr.Item("plate_no")
                Else
                    a(5) = get_ProjectName_Designation(dr.Item(5).ToString, 1)
                End If
                a(6) = dr.Item(6).ToString
                a(7) = FormatNumber(dr.Item(7).ToString)
                a(8) = FormatNumber(dr.Item(10).ToString)

                Dim lvl As New ListViewItem(a)
                lvlAllowance.Items.Add(lvl)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub cmbProjectWorksite_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProjectWorksite.SelectedIndexChanged

    End Sub

    Private Sub cmbSearch_Project_WorkSite_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearch_Project_WorkSite.SelectedIndexChanged

    End Sub

    Private Sub txtAmount_TextChanged(sender As Object, e As EventArgs) Handles txtAmount.TextChanged

    End Sub

    Private Sub txtVoucher_TextChanged(sender As Object, e As EventArgs) Handles txtVoucher.TextChanged

    End Sub

    Private Sub btnSave_GotFocus(sender As Object, e As EventArgs) Handles btnSave.GotFocus

    End Sub

    Private Sub FAllowance_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            clear_fields(1)
            DTP_Allowance.Focus()
        ElseIf e.Control And e.KeyCode = Keys.S Then
            If cmbProjectWorksite.Text = "" Then
                MessageBox.Show("Project/Worksite field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                cmbProjectWorksite.Focus()
            ElseIf txtLocation.Text = "" Then
                MessageBox.Show("Location field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtLocation.Focus()
            ElseIf txtName.Text = "" Then
                MessageBox.Show("Name field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtName.Focus()
            ElseIf cmbDesignation.Text = "" Then
                MessageBox.Show("Designation field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                cmbDesignation.Focus()
            ElseIf txtVoucher.Text = "" Then
                MessageBox.Show("Voucher No. field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtVoucher.Focus()
            ElseIf txtAmount.Text = "" Then
                MessageBox.Show("Amount field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtAmount.Focus()
            ElseIf txtAmount_Salary.Text = "" Then
                MessageBox.Show("Amount Salary field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtAmount_Salary.Focus()
            Else
                If btnSave.Text = "Save" Then
                    save_allowance()
                    cmbSearch.Text = "Date"
                    DTP_search_Allowance.Text = DTP_Allowance.Text
                    btnSearch.PerformClick()
                    listfocus(lvlAllowance, z)
                    clear_fields(0)
                    txtName.Focus()
                    ' load_allowance()
                ElseIf btnSave.Text = "Update" Then
                    Dim ex = MessageBox.Show("Are you sure u want to update the SELECTED item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    If ex = MsgBoxResult.Yes Then
                        update_allowance()
                        cmbSearch.Text = "Date"
                        DTP_search_Allowance.Text = DTP_Allowance.Text
                        btnSearch.PerformClick()
                        listfocus(lvlAllowance, w)
                        btnSave.Text = "Save"
                        clear_fields(1)
                        DTP_Allowance.Focus()
                    End If

                End If
            End If
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        FPerson_Name.ShowDialog()
    End Sub
    Private Sub cmbDesignation_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbDesignation.SelectedIndexChanged

    End Sub

    Private Sub txtName_ImeModeChanged(sender As Object, e As EventArgs) Handles txtName.ImeModeChanged

    End Sub

    Private Sub DTP_Allowance_ValueChanged(sender As Object, e As EventArgs) Handles DTP_Allowance.ValueChanged

    End Sub
End Class