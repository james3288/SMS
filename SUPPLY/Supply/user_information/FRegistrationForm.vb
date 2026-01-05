Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Web.UI

Public Class FRegistrationForm
    Public sqlcon As New SQLcon
    Dim drag As Boolean
    Dim opr As Boolean = True
    Dim mousex As Integer
    Dim mousey As Integer
    Dim n As Integer
    Public user_id As Integer

    Private smsUsersModel As New ModelNew.Model
    Private hrmsUsersModel As New ModelNew.Model
    Dim cBgWorkerChecker As Timer

    Public isTriggered As Boolean
    Public cUserId As Integer
    Private cListOfListViewItem As New List(Of ListViewItem)
    Private searchUI As New class_placeholder4
    Private cSearch As String
    Private cData As New List(Of PropsFields.usersData)

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Const CS_DROPSHADOW As Integer = &H20000
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_DROPSHADOW
            Return cp
        End Get
    End Property


    Private Sub FRegistrationForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbl_register.Parent = pboxRegister
        lbl_register.BringToFront()
        lbl_register.Location = New Point(22, 8)

        lbl_cancel.Parent = pboxCancel
        lbl_cancel.BringToFront()
        lbl_cancel.Location = New Point(25, 8)

        'clearFields()
        'loadRgstrationForm()

        'ui
        searchUI.king_placeholder_textbox("Search here...", txtSearch, Nothing, Panel1, My.Resources.received)

        load_access()

        loadUsersNew()
    End Sub

    Public Sub loadUsersNew()

        cListOfListViewItem.Clear()
        lvlRegstrationForm.Items.Clear()
        cData.Clear()

        hrmsUsersModel.clearParameter()
        smsUsersModel.clearParameter()


        loadingPanel.Visible = True

        Dim values As New Dictionary(Of String, String)

        _initializing(cCol.forEmployeeData,
                      values,
                      hrmsUsersModel,
                      employeeDataBgWorker)

        _initializing(cCol.forSmsUsers,
                      values,
                      smsUsersModel,
                      employeeDataBgWorker)

        cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, employeeDataBgWorker)

    End Sub

    Private Sub SuccessfullyDone()
        cListOfEmployeeDatas = TryCast(hrmsUsersModel.cData, List(Of PropsFields.employee_props_fields))
        cListOfSmsUsers = TryCast(smsUsersModel.cData, List(Of PropsFields.smsUsers_props_fields))

        'get the data result

        If cListOfEmployeeDatas.Count > 0 Then

            Dim data = (From row In cListOfSmsUsers
                        Group Join row2 In cListOfEmployeeDatas
                       On row2.employee_id Equals row.employee_id Into newList = Group
                        From row2 In newList.DefaultIfEmpty()
                        Select New With {
               .user_id = row.user_id,
               .fName = row.fName,
               .lName = row.lName,
               .username = row.username,
               .password = row.password,
               .restriction = row.restriction,
               .access = row.access,
               .ip_Address = row.ip_Address,
               .department = If(row2 IsNot Nothing AndAlso row2.department IsNot Nothing, row2.department, ""),
               .status_name = If(row2 IsNot Nothing AndAlso row2.status_name IsNot Nothing, row2.status_name, ""),
               .designation = If(row2 IsNot Nothing AndAlso row2.designation IsNot Nothing, row2.designation, "")
        } Order By user_id, fname, lname Ascending)

            For Each row In data
                Dim aa As New PropsFields.usersData
                With aa
                    .user_id = row.user_id
                    .fName = row.fName
                    .lName = row.lName
                    .username = row.username
                    .password = row.password
                    .restriction = row.restriction
                    .access = row.access
                    .ip_Address = row.ip_Address
                    .department = row.department
                    .status_name = row.status_name
                    .designation = row.designation
                End With

                cData.Add(aa)
            Next



            previewResult(cData)
        End If


        'done loading
        loadingPanel.Visible = False
    End Sub


    Private Sub previewResult(data As List(Of PropsFields.usersData))
        cListOfListViewItem.Clear()
        lvlRegstrationForm.Items.Clear()

        Dim a(11) As String

        If Not data Is Nothing Then

            For Each row In data

                a(0) = row.user_id
                a(1) = row.fName
                a(2) = row.lName
                a(4) = row.username
                a(5) = row.password
                a(6) = row.ip_Address
                a(7) = row.restriction
                a(8) = row.access
                a(9) = row.department
                a(10) = row.status_name
                a(11) = row.designation

                Dim lvl As New ListViewItem(a)
                cListOfListViewItem.Add(lvl)
            Next

            lvlRegstrationForm.Items.AddRange(cListOfListViewItem.ToArray)
        End If


        If isTriggered = True Then
            listfocus(lvlRegstrationForm, cUserId)
        End If

        isTriggered = False
        cUserId = 0

    End Sub

    Private Sub loadRgstrationForm()
        sqlcon.connection.Close()
        lvlRegstrationForm.Items.Clear()
        Try

            sqlcon.connection.Open()
            Dim cmd As SqlCommand
            Dim dr As SqlDataReader
            publicquery = "SELECT * FROM dbregistrationform"
            cmd = New SqlCommand(publicquery, sqlcon.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim lst(10) As String

                lst(0) = dr.Item("user_id").ToString
                lst(1) = dr.Item("fname").ToString
                lst(2) = dr.Item("lname").ToString
                lst(3) = dr.Item("gender").ToString
                lst(4) = dr.Item("username").ToString
                lst(5) = dr.Item("password").ToString
                lst(6) = dr.Item("ip_address").ToString
                lst(7) = dr.Item("restriction").ToString
                lst(8) = dr.Item("access").ToString

                Dim lvl As New ListViewItem(lst)
                lvlRegstrationForm.Items.Add(lvl)

            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try
    End Sub

    Private Sub FRegistrationForm_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub FRegistrationForm_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub FRegistrationForm_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        drag = False
    End Sub

    Private Sub btnExit_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        btnExit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        btnExit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        btnExit.BackgroundImage = My.Resources.close_button
    End Sub

    Private Sub filtertxtField_register()
        If txtFname.Text = "" Or txtFname.Text.ToLower = "first name" Then
            MessageBox.Show("Pls. fill up First Name", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFname.Focus()
        ElseIf txtLname.Text = "" Or txtLname.Text.ToLower = "last name" Then
            MessageBox.Show("Pls. fill up Last Name", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtLname.Focus()
        ElseIf cmbGender.Text = "" Or cmbGender.Text.ToLower = "gender" Then
            MessageBox.Show("Choose your Gender", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbGender.Focus()
        ElseIf txtUsrname.Text = "" Or txtUsrname.Text.ToLower = "username" Then
            MessageBox.Show("Pls. fill up Username", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtUsrname.Focus()
        ElseIf txtPassword.Text = "" Or txtPassword.Text.ToLower = "password" Then
            MessageBox.Show("Pls. fill up Password", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPassword.Focus()
        ElseIf txtIpAddress.Text = "" Or txtIpAddress.Text.ToLower = "ip address" Then
            MessageBox.Show("Pls. fill up Ip Address", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtIpAddress.Focus()
        ElseIf cmbRestriction.Text = "" Or cmbRestriction.Text.ToLower = "restriction" Then
            MessageBox.Show("Choose your Restriction", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbRestriction.Focus()
            'ElseIf txtAccess.Text = "" Or txtAccess.Text.ToLower = "access" Then
            '    MessageBox.Show("Pls. fill up Access", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    txtAccess.Focus()
        Else
            If MessageBox.Show("Are you sure you want to save this data?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                regstration_save()
            End If
        End If

    End Sub

    Private Sub filtertxtField_update()
        If txtFname.Text = "" Or txtFname.Text.ToLower = "first name" Then
            MessageBox.Show("Pls. fill up First Name", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFname.Focus()
        ElseIf txtLname.Text = "" Or txtLname.Text.ToLower = "last name" Then
            MessageBox.Show("Pls. fill up Last Name", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtLname.Focus()
            'ElseIf cmbGender.Text = "" Or cmbGender.Text.ToLower = "gender" Then
            '    MessageBox.Show("Choose your Gender", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    cmbGender.Focus()
        ElseIf txtUsrname.Text = "" Or txtUsrname.Text.ToLower = "username" Then
            MessageBox.Show("Pls. fill up Username", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtUsrname.Focus()
        ElseIf txtPassword.Text = "" Or txtPassword.Text.ToLower = "password" Then
            MessageBox.Show("Pls. fill up Password", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPassword.Focus()
        ElseIf txtIpAddress.Text = "" Or txtIpAddress.Text.ToLower = "ip address" Then
            MessageBox.Show("Pls. fill up Ip Address", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtIpAddress.Focus()
        ElseIf cmbRestriction.Text = "" Or cmbRestriction.Text.ToLower = "restriction" Then
            MessageBox.Show("Choose your Restriction", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbRestriction.Focus()
            'ElseIf txtAccess.Text = "" Or txtAccess.Text.ToLower = "access" Then
            '    MessageBox.Show("Pls. fill up Access", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    txtAccess.Focus()
        Else
            update_rgstrationForm()
        End If
    End Sub

    Private Sub regstration_save()
        Try
            sqlcon.connection.Open()
            Dim cmd As SqlCommand
            publicquery = "SET NOCOUNT ON;"
            publicquery &= "INSERT INTO dbregistrationform(fname,lname,username,password,ip_address,restriction,access,gender)"
            publicquery &= "VALUES('" & txtFname.Text & "','" & txtLname.Text & "','" & txtUsrname.Text & "','" & txtPassword.Text & "',"
            publicquery &= "'" & txtIpAddress.Text & "','" & cmbRestriction.Text & "','" & txtAccess.Text & "','" & cmbGender.Text & "')"
            publicquery &= "SELECT SCOPE_IDENTITY()"
            cmd = New SqlCommand(publicquery, sqlcon.connection)
            public_rs_id = cmd.ExecuteScalar()
            user_id = public_rs_id

            insert_into_dbaccess_desc(user_id)
            MessageBox.Show("You have successfully registered...", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'loadRgstrationForm()

            'listfocus(lvlRegstrationForm, Focus)
            'lvlRegstrationForm.Items(lvlRegstrationForm.Items.Count - 1).Selected = True
            'lvlRegstrationForm.EnsureVisible(lvlRegstrationForm.Items.Count - 1)

            isTriggered = True
            cUserId = user_id

            loadUsersNew()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
            clearFields()
            txtFname.Focus()
        End Try
    End Sub
    Public Sub insert_into_dbaccess_desc(ByVal pick_user_id As Integer)
        Dim query As String
        query = "DELETE FROM dbuser_access WHERE user_id = " & pick_user_id
        UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

        For Each itm As ListViewItem In lvlAccess.Items
            If itm.Checked = True Then
                query = Nothing

                query = "INSERT INTO dbuser_access(user_id,access_desc_id) VALUES(" & pick_user_id & "," & CInt(itm.Text) & ")"
                UPDATE_INSERT_DELETE_QUERY(query, 0, "INSERT")
            End If
        Next

        'For Each row As ListViewItem In lvlAccess.Items
        '    If row.Checked = True Then

        '    End If
        'Next
    End Sub

    Private Function access_item_exist() As Boolean
        Dim cc As New ColumnValuesObj

    End Function
    Private Sub update_rgstrationForm()
        Try
            Dim n As Integer = lbl_userid.Text
            sqlcon.connection.Open()
            Dim dr As String
            Dim cmd As SqlCommand
            cmd = New SqlCommand("proc_update_regstrationForm", sqlcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@user_id", lbl_userid.Text)
            cmd.Parameters.AddWithValue("@fname", txtFname.Text)
            cmd.Parameters.AddWithValue("@lname", txtLname.Text)
            cmd.Parameters.AddWithValue("@username", txtUsrname.Text)
            cmd.Parameters.AddWithValue("@password", txtPassword.Text)
            cmd.Parameters.AddWithValue("@ip_address", txtIpAddress.Text)
            cmd.Parameters.AddWithValue("@restriction", cmbRestriction.Text)
            cmd.Parameters.AddWithValue("@access", txtAccess.Text)
            cmd.Parameters.AddWithValue("@gender", cmbGender.Text)
            cmd.Parameters.AddWithValue("@crud", "Update_dbregistrationform")
            dr = cmd.ExecuteNonQuery

            user_id = CInt(lvlRegstrationForm.SelectedItems(0).Text)

            insert_into_dbaccess_desc(user_id)
            MessageBox.Show("Information has been successfully updated...", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)

            loadRgstrationForm()
            'listfocus(lvlRegstrationForm, n)

            isTriggered = True
            cUserId = user_id

            loadUsersNew()
            lvlRegstrationForm.Enabled = True

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
            lbl_register.Text = "Register"
            lbl_cancel.Text = "Cancel"
            clearFields()
            txtFname.Focus()
        End Try
    End Sub
    Private Sub clearFields()
        txtFname.Text = "First Name"
        txtLname.Text = "Last Name"
        cmbGender.Items.Add("Gender")
        cmbGender.Text = "Gender"
        txtUsrname.Text = "Username"
        txtPassword.Text = "Password"
        txtIpAddress.Text = "Ip Address"
        cmbRestriction.Items.Add("Restriction")
        cmbRestriction.Text = "Restriction"
        txtAccess.Text = "Access"
        txtSearch.Enabled = True
        lvlRegstrationForm.Enabled = True
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        cmbGender.Items.Remove("Gender")
        cmbRestriction.Items.Remove("Restriction")
        lbl_register.Text = "Update"
        lbl_cancel.Text = "Clear"

        'lbl_userid.Text = lvlRegstrationForm.SelectedItems.Item(0).SubItems(0).Text
        'txtFname.Text = lvlRegstrationForm.SelectedItems.Item(0).SubItems(1).Text
        'txtLname.Text = lvlRegstrationForm.SelectedItems.Item(0).SubItems(2).Text
        ''cmbGender.Text = lvlRegstrationForm.SelectedItems.Item(0).SubItems(3).Text
        'txtUsrname.Text = lvlRegstrationForm.SelectedItems.Item(0).SubItems(4).Text
        'txtPassword.Text = lvlRegstrationForm.SelectedItems.Item(0).SubItems(5).Text
        'txtIpAddress.Text = lvlRegstrationForm.SelectedItems.Item(0).SubItems(6).Text
        'cmbRestriction.Text = lvlRegstrationForm.SelectedItems.Item(0).SubItems(7).Text
        ''txtAccess.Text = lvlRegstrationForm.SelectedItems.Item(0).SubItems(8).Text

        Dim user As New PropsFields.usersData
        user = cData.FirstOrDefault(Function(x) x.user_id = lvlRegstrationForm.SelectedItems(0).Text)

        lbl_userid.Text = user.user_id
        txtFname.Text = user.fName
        txtLname.Text = user.lName
        txtUsrname.Text = user.username
        txtPassword.Text = user.password
        txtIpAddress.Text = user.ip_Address
        cmbRestriction.Text = user.restriction


        lvlRegstrationForm.Enabled = False
        load_user_access()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim ex As MsgBoxResult = MessageBox.Show("Are you sure you Want to DELETE the Selected Info.?", "EUS INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If ex = MsgBoxResult.Yes Then
            Dim query As String = "DELETE FROM dbuser_access WHERE user_id = " & CInt(lvlRegstrationForm.SelectedItems(0).Text)
            UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

            delete_rgstrationForm()

        End If
    End Sub

    Private Sub delete_rgstrationForm()
        Try
            sqlcon.connection.Open()
            Dim cmd As SqlCommand
            publicquery = "DELETE FROM dbregistrationform WHERE user_id = " & lvlRegstrationForm.SelectedItems.Item(0).SubItems(0).Text & ""
            cmd = New SqlCommand(publicquery, sqlcon.connection)
            cmd.ExecuteNonQuery()

            loadRgstrationForm()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try
    End Sub

    Private Sub lbl_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_cancel.Click, pboxCancel.Click
        If lbl_cancel.Text = "Cancel" Then
            opr = False
            Dim ext As MsgBoxResult = MessageBox.Show("Are you sure you Want to CANCEL?...", "EUS INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If opr = False Then
                If ext = MsgBoxResult.Yes Then
                    lvlRegstrationForm.Enabled = True
                    Me.Close()
                Else
                    txtFname.Focus()
                End If
            End If
            opr = True
        ElseIf lbl_cancel.Text = "Clear" Then
            clearFields()

        End If
        lbl_register.Text = "Register"
        lbl_cancel.Text = "Cancel"
    End Sub

    Private Sub lbl_register_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_register.Click, pboxRegister.Click
        If lbl_register.Text = "Register" Then

            filtertxtField_register()

        ElseIf lbl_register.Text = "Update" Then
            filtertxtField_update()
        End If
    End Sub

    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        drag = False
    End Sub



    'Private Sub txtSearch_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.Leave
    '    txtSearch.Text = "Search"
    '    loadRgstrationForm()
    'End Sub


    Private Sub Search_Info()
        lvlRegstrationForm.Items.Clear()
        Try
            sqlcon.connection.Open()
            Dim cmd As SqlCommand
            Dim dr As SqlDataReader
            publicquery = "SELECT * FROM dbregistrationform WHERE fname LIKE '%" & txtSearch.Text & "%' OR "
            publicquery &= "lname LIKE '%" & txtSearch.Text & "%' OR gender LIKE '%" & txtSearch.Text & "%' OR "
            publicquery &= "username LIKE '%" & txtSearch.Text & "%' OR password LIKE '%" & txtSearch.Text & "%' OR "
            publicquery &= "ip_address LIKE '%" & txtSearch.Text & "%' OR restriction LIKE '%" & txtSearch.Text & "%' OR "
            publicquery &= " access LIKE '%" & txtSearch.Text & "%' "
            cmd = New SqlCommand(publicquery, sqlcon.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim lst(10) As String

                lst(0) = dr.Item("user_id").ToString
                lst(1) = dr.Item("fname").ToString
                lst(2) = dr.Item("lname").ToString
                lst(3) = dr.Item("gender").ToString
                lst(4) = dr.Item("username").ToString
                lst(5) = dr.Item("password").ToString
                lst(6) = dr.Item("ip_address").ToString
                lst(7) = dr.Item("restriction").ToString
                lst(8) = dr.Item("access").ToString

                Dim lvl As New ListViewItem(lst)
                lvlRegstrationForm.Items.Add(lvl)

            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try
    End Sub

    Private Sub pboxRegister_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pboxRegister.MouseDown
        pboxRegister.BackgroundImage = My.Resources.button_reg_hover
    End Sub

    Private Sub pboxRegister_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pboxRegister.MouseEnter
        pboxRegister.BackgroundImage = My.Resources.button_reg_hover
    End Sub

    Private Sub pboxRegister_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pboxRegister.MouseLeave
        pboxRegister.BackgroundImage = My.Resources.button_reg
    End Sub

    Private Sub pboxCancel_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pboxCancel.MouseDown
        pboxCancel.BackgroundImage = My.Resources.button_reg_hover
    End Sub

    Private Sub pboxCancel_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pboxCancel.MouseEnter
        pboxCancel.BackgroundImage = My.Resources.button_reg_hover
    End Sub

    Private Sub pboxCancel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pboxCancel.MouseLeave
        pboxCancel.BackgroundImage = My.Resources.button_reg
    End Sub

    Private Sub cmbRestriction_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRestriction.GotFocus
        cmbRestriction.Items.Remove("Restriction")
    End Sub

    Private Sub cmbRestriction_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRestriction.Leave
        If cmbRestriction.Text = Nothing Then
            cmbRestriction.Items.Add("Restriction")
            cmbRestriction.Text = "Restriction"
        End If
    End Sub


    Private Sub cmslvlRegstrationForm_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmslvlRegstrationForm.Opening
        If lvlRegstrationForm.SelectedItems.Count > 0 Then
            cmslvlRegstrationForm.Enabled = True
        Else
            cmslvlRegstrationForm.Enabled = False
        End If
    End Sub

    Private Sub txtFname_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFname.Leave
        If txtFname.Text = "" Then
            txtFname.Text = "First Name"
        End If
    End Sub

    Private Sub txtFname_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtFname.MouseClick
        If txtFname.Text = "First Name" Then
            txtFname.Text = ""
        End If
    End Sub

    Private Sub txtUsrname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsrname.GotFocus
        If txtUsrname.Text = "Username" Then
            txtUsrname.Text = Nothing
        End If
    End Sub

    Private Sub txtUsrname_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsrname.Leave
        If txtUsrname.Text = "" Then
            txtUsrname.Text = "Username"
        End If
    End Sub

    Private Sub cmbGender_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbGender.GotFocus
        cmbGender.Items.Remove("Gender")
    End Sub

    Private Sub cmbGender_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbGender.Leave
        If cmbGender.Text = Nothing Then
            cmbGender.Items.Add("Gender")
            cmbGender.Text = "Gender"
        End If
    End Sub

    Private Sub txtLname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLname.GotFocus
        If txtLname.Text = "Last Name" Then
            txtLname.Text = Nothing
        End If
    End Sub

    Private Sub txtLname_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLname.Leave
        If txtLname.Text = "" Then
            txtLname.Text = "Last Name"
        End If
    End Sub

    Private Sub txtPassword_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.GotFocus
        If txtPassword.Text = "Password" Then
            txtPassword.Text = ""
        End If
    End Sub

    Private Sub txtPassword_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.Leave
        If txtPassword.Text = "" Then
            txtPassword.Text = "Password"
        End If
    End Sub

    Private Sub txtIpAddress_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIpAddress.GotFocus
        If txtIpAddress.Text = "Ip Address" Then
            txtIpAddress.Text = ""
        End If
    End Sub

    Private Sub txtIpAddress_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIpAddress.Leave
        If txtIpAddress.Text = "" Then
            txtIpAddress.Text = "Ip Address"
        End If
    End Sub

    Private Sub txtAccess_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccess.GotFocus
        If txtAccess.Text = "Access" Then
            txtAccess.Text = ""
        End If
    End Sub

    Private Sub txtAccess_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccess.Leave
        If txtAccess.Text = "" Then
            txtAccess.Text = "Access"
        End If
    End Sub

    Private Sub btnnvsible_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnvsibleA.Click
        If lbl_register.Text = "Register" Then
            filtertxtField_register()
        ElseIf lbl_register.Text = "Update" Then
            update_rgstrationForm()
        End If
    End Sub

    Private Sub btnnvsibleC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnvsibleC.Click
        If btnnvsibleC.Text = "CancelBTN" Then
            opr = False
            Dim ext As MsgBoxResult = MessageBox.Show("Are you sure you Want to CANCEL?...", "EUS INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If opr = False Then
                If ext = MsgBoxResult.Yes Then
                    lvlRegstrationForm.Enabled = True
                    Me.Close()
                Else
                    txtFname.Focus()
                End If
            End If
            opr = True
            ' ElseIf lbl_cancel.Text = "Clear" Then
            ' clearFields()
        End If
        'lbl_register.Text = "Register"
        'lbl_cancel.Text = "Cancel"
    End Sub

    Private Sub PictureBox19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox19.Click

    End Sub

    Private Sub PictureBox20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox20.Click

        showPanelAccess(True)

    End Sub

    Private Sub showPanelAccess(enable As Boolean)
        For Each a In Me.Controls
            If TypeOf a Is Panel Then
                If a.name = NameOf(PanelAccess) Then
                    PanelAccess.Visible = enable
                    PanelAccess.Location = New Point(244, 182)
                    PanelAccess.Enabled = enable

                    If Not lbl_register.Text = "Register" And enable = True Then
                        load_access()
                        load_user_access()
                    End If
                End If
            Else
                a.Enabled = Not enable
            End If

        Next
    End Sub
    Public Sub load_user_access()
        Dim newsq As New SQLcon
        Dim sqldr As SqlDataReader
        Dim sqlcmd As SqlCommand
        Dim a(10) As String

        Try
            newsq.connection.Open()

            Dim query As String = "SELECT * FROM dbuser_access WHERE user_id = " & CInt(lvlRegstrationForm.SelectedItems(0).Text) & " ORDER BY access_desc_id"
            sqlcmd = New SqlCommand(query, newsq.connection)
            sqldr = sqlcmd.ExecuteReader
            While sqldr.Read
                check_if_access_desc_id_exist(CInt(sqldr.Item("access_desc_id").ToString))
            End While
            sqldr.Close()
        Catch ex As Exception
            message("", 2, )
        Finally

            newsq.connection.Close()

        End Try
    End Sub
    Public Sub check_if_access_desc_id_exist(ByVal access_desc_id As Integer)
        For Each itm As ListViewItem In lvlAccess.Items
            If CInt(itm.Text) = access_desc_id Then
                itm.Checked = True
            End If
        Next

    End Sub
    Public Function check_if_access_desc_id_and_user_id_exist(ByVal access_desc_id As Integer, ByVal user_id As Integer) As Boolean
        Dim newsq As New SQLcon
        Dim sqldr As SqlDataReader
        Dim sqlcmd As SqlCommand
        Dim a(10) As String

        Try
            newsq.connection.Open()

            Dim query As String = "SELECT user_id,access_desc_id FROM dbuser_access WHERE user_id = " & user_id & " AND access_desc_id = " & access_desc_id
            sqlcmd = New SqlCommand(query, newsq.connection)
            sqldr = sqlcmd.ExecuteReader
            While sqldr.Read
                check_if_access_desc_id_and_user_id_exist = True
            End While
            sqldr.Close()
        Catch ex As Exception
            message("", 2, )
        Finally
            newsq.connection.Close()
        End Try

    End Function

    Public Sub load_access()
        Dim newsq As New SQLcon
        Dim sqldr As SqlDataReader
        Dim sqlcmd As SqlCommand
        Dim a(10) As String

        lvlAccess.Items.Clear()

        Try
            newsq.connection.Open()

            Dim query As String = "SELECT * FROM dbaccess_desc ORDER BY access_no"
            sqlcmd = New SqlCommand(query, newsq.connection)
            sqldr = sqlcmd.ExecuteReader
            While sqldr.Read
                a(0) = sqldr.Item("access_no").ToString
                a(1) = sqldr.Item("access_desc").ToString

                Dim lvl As New ListViewItem(a)
                lvlAccess.Items.Add(lvl)


            End While
            sqldr.Close()
        Catch ex As Exception
            message("", 2, )
        Finally

            newsq.connection.Close()

        End Try


    End Sub
    'Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
    '    If lbl_register.Text = "Update" Then
    '        For Each ctr As Control In Me.Controls
    '            If ctr.Name = "PanelAccess" Then
    '                ctr.Enabled = True
    '                ctr.Visible = False
    '            ElseIf ctr.Name = "lvlRegstrationForm" Then
    '                ctr.Enabled = False
    '            Else
    '                ctr.Enabled = True
    '            End If
    '        Next

    '        txtSearch.Enabled = False

    '    Else
    '        For Each ctr As Control In Me.Controls
    '            If ctr.Name = "PanelAccess" Then
    '                ctr.Location = New Point(1000, 1000)
    '                ctr.Enabled = True
    '            Else
    '                ctr.Enabled = True
    '            End If
    '        Next
    '    End If

    'End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        insert_into_dbaccess_desc(user_id)
    End Sub

    Private Sub EditAccessDesc_Click(sender As Object, e As EventArgs) Handles EditAccessDesc.Click

        FEditUserAccess.txtUserAccessDesc.Text = lvlAccess.SelectedItems(0).SubItems(1).Text
        FEditUserAccess.btnSave.Text = "Update"
        FEditUserAccess.ShowDialog()

    End Sub

    Private Sub AddNewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewToolStripMenuItem.Click
        FEditUserAccess.btnSave.Text = "Save"
        FEditUserAccess.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        If MessageBox.Show("Are you sure you want to delete the selected data?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim delete As New Model_King_Dynamic_Update

            delete.DeleteData("dbaccess_desc", $"access_no='{lvlAccess.SelectedItems(0).Text}'")
            load_access()


        End If
    End Sub

    Private Sub LinkToProperUserInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LinkToProperUserInfoToolStripMenuItem.Click
        With FUserInfo
            .isFromFRegistrationForm = True
            .ShowDialog()
        End With
    End Sub

    Private Sub btnExit_Click_1(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Dispose()
    End Sub

    Private Sub debounce_new_Tick(sender As Object, e As EventArgs) Handles debounce_new.Tick
        debounce_new.Stop()

        Dim searchResult
        searchResult = cData.Where(Function(x)
                                       Dim output As String = x.fName.ToUpper() &
                                                      " " & x.lName.ToUpper() &
                                                      " " & x.department.ToUpper() &
                                                      " " & x.designation.ToUpper() &
                                                      " " & x.access.ToUpper() &
                                                      " " & x.status_name.ToUpper()

                                       Return output.Contains(cSearch.ToUpper)

                                   End Function).
                                   OrderBy(Function(x) x.user_id).
                                   ThenBy(Function(x) x.fName).
                                   ThenBy(Function(x) x.lName).ToList()



        If searchResult.Count > 0 Then
            previewResult(searchResult)
        End If

        loadingPanel.Visible = False
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        cSearch = txtSearch.Text
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If txtSearch.TextLength > 0 Then
            loadingPanel.Visible = True
            debounce_new.Start()
        Else
            loadingPanel.Visible = True
            cSearch = ""
            debounce_new.Start()

        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        showPanelAccess(False)
    End Sub

    Private Sub ClearAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearAllToolStripMenuItem.Click
        checkUncheckListView(lvlAccess, False)

    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        checkUncheckListView(lvlAccess, True)
    End Sub

    Private Sub checkUncheckListView(lvl As ListView, enable As Boolean)
        For Each row As ListViewItem In lvl.Items
            row.Checked = enable
        Next
    End Sub
End Class