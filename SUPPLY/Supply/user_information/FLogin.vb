Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FLogin
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader

    Private smsUsersModel As New ModelNew.Model
    Private hrmsUsersModel As New ModelNew.Model
    Dim cBgWorkerChecker As Timer

    Private cDataNew As New List(Of PropsFields.usersData)
    Private cSomeComponents As New ColumnValuesObj
    Private customMsg As New customMessageBox
    Private Sub FLogin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            login()

        End If
    End Sub

    Private Sub FLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        readfolder()
        pboxIconUname.Parent = pboxUname
        pboxIconUname.BringToFront()
        pboxIconUname.Location = New Point(10, 10)
        pboxIconPw.Parent = pboxPw
        pboxIconPw.BringToFront()
        pboxIconPw.Location = New Point(10, 10)

        lblSignIn.Parent = pboxSignIn
        lblSignIn.BringToFront()
        lblSignIn.Location = New Point(32, 9)
        lblCancel.Parent = pboxCancel
        lblCancel.BringToFront()
        lblCancel.Location = New Point(32, 9)

        loadUsersNew()
    End Sub

    Public Sub loadUsersNew()

        cDataNew.Clear()

        hrmsUsersModel.clearParameter()
        smsUsersModel.clearParameter()

        cSomeComponents.add(GetType(Label).ToString, lblSignIn)
        cSomeComponents.add(GetType(PictureBox).ToString, pboxSignIn)
        cSomeComponents.add("loadingPanel", loadingPanel)

        disableEnableWhileLoading(cSomeComponents.getValues(), False)

        'loadingPanel.Visible = True

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
        'refactorAndLoadEmployeesData()

        'done loading
        'loadingPanel.Visible = False
        disableEnableWhileLoading(cSomeComponents.getValues(), True)
    End Sub

    Private Sub refactorAndLoadEmployeesData()
        Try
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
        } Order By fname, lname Ascending)

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

                    cDataNew.Add(aa)
                Next


                '  previewResult(cData)
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub pboxCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pboxCancel.Click, lblCancel.Click
        End
    End Sub

    Private Sub lblChngePw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblChngePw.Click
        FRegistrationForm.ShowDialog()

    End Sub

    Private Sub pboxSignIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pboxSignIn.Click, lblSignIn.Click
        login()
        'newLogin()
    End Sub

    Private Sub newLogin()

        Dim userInfo As New Model_UserInfo
        Dim result As Model_UserInfo.CUserInfo = userInfo._initialize(5, txtUsername.Text, txtPassword.Text)

        MsgBox(result.user_id)
    End Sub

    Public Sub login()


        If user_exist() = True Then
            'restric user if to login depends on their department or designation
            Dim user As New PropsFields.usersData
            user = cDataNew.FirstOrDefault(Function(x) x.user_id = pub_user_id)

            Dim cc As New ColumnValuesObj
            Dim myAlias1 As String = "a"
            Dim myAlias2 As String = "b"
            Dim tnt As New tableNameType

            cc.addColumn($"{myAlias2}.fname")
            cc.addColumn($"{myAlias2}.lname")

            cc.setCondition($"{myAlias1}.user_id = {pub_user_id}")
            cc.addJoinClause($"LEFT JOIN dbregistrationform {myAlias2} ON {myAlias2}.user_id = {myAlias1}.user_id")
            cc.selectQuery("dbuser_access", True, myAlias1, tnt.supply_table)


#Region "STORE EMPLOYEE DEPARTMENT"
            Dim employee = cListOfEmployeeDatas.FirstOrDefault(Function(x) x.employee_id = Utilities.ifBlankReplaceToZero(employee_id))
            department = employee?.department
#End Region

            FMain.ToolStripLabel1.Text = "Hello, " & fname & " " & lname

            access_control_enable_disable()
            Load_list_value(glb_list_personnel_hover, 109) 'for pop-up personnel
            Me.Close()

        Else
            message("No user has found..", 4, )
        End If

    End Sub
    Public Sub access_control_enable_disable()
        Dim SQ As New SQLcon
        Try
            SQ.connection.Open()
            Dim query As String = "SELECT * FROM dbuser_access WHERE user_id = " & pub_user_id
            cmd = New SqlCommand(query, SQ.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim access_no As Integer = CInt(dr.Item("access_desc_id").ToString)
                supp_trans_buttons(True, access_no)
            End While
            dr.Close()

        Catch ex As Exception
            message("", 2, ex)
        Finally
            SQ.connection.Close()
        End Try

    End Sub
    Public Function user_exist() As Boolean
        Dim SQ As New SQLcon

        user_exist = False

        Try
            SQ.connection.Open()
            Dim query As String = "SELECT * FROM dbregistrationform WHERE username = '" & txtUsername.Text & "' AND password = '" & txtPassword.Text & "'"
            cmd = New SqlCommand(query, SQ.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                pub_user_id = dr.Item("user_id").ToString
                uname = dr.Item("username").ToString
                fname = dr.Item("fname").ToString
                lname = dr.Item("lname").ToString
                restriction = dr.Item("restriction").ToString
                access = dr.Item("access").ToString
                gender = dr.Item("gender").ToString
                username = dr.Item("username").ToString
                password = dr.Item("password").ToString
                auth = dr.Item("auth").ToString
                employee_id = dr.Item("employee_id").ToString

                user_exist = True
            End While
            dr.Close()

        Catch ex As Exception
            message("", 2, ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function
    Public Sub Load_list_value(ByVal list_value As List(Of String), ByVal n As Integer)
        list_value.Clear()
        Dim Sql_conn As New SQLcon
        Dim dr As SqlDataReader
        Try
            Sql_conn.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = Sql_conn.connection
            sqlcomm.CommandText = "crud_wh_Facility_Maintenance"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", n)

            dr = sqlcomm.ExecuteReader
            While dr.Read
                list_value.Add(dr.Item(0).ToString)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sql_conn.connection.Close()
        End Try
    End Sub
End Class