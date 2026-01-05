Imports Microsoft.Office.Interop.Excel

Public Class FUserInfo
    Private employeeUI As New ModelNew.Model
    Dim cBgWorkerChecker As Timer
    Private customGridview As New CustomGridview
    Private aa As New PropsFields.employee_props_fields
    Private chp2 As New CHP

    Private searchUI As New class_placeholder4
    Public isFromFRegistrationForm As Boolean
    Private customMsg As New customMessageBox
    Dim cSearch As String

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Const CS_DROPSHADOW As Integer = &H20000
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_DROPSHADOW
            Return cp
        End Get
    End Property

    Private Class CHP
        Public ReadOnly Property FirstName = "FIRST NAME"
        Public ReadOnly Property MiddleName = "MIDDLE NAME"
        Public ReadOnly Property LastName = "LAST NAME"
        Public ReadOnly Property Designation = "DESIGNATION"
        Public ReadOnly Property Department = "DEPARTMENT"
        Public ReadOnly Property Status = "STATUS"
        Public ReadOnly Property EMPLOYEE_ID = "EMPLOYEE_ID"



    End Class

    Private Sub FUserInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        customGridview.customDatagridview(DataGridView1,, 28)

        'ui
        searchUI.king_placeholder_textbox("Search here...", txtSearch, Nothing, Panel1, My.Resources.received)
        loadEmployeeData()

        txtSearch.Focus()

        'movable panel
        Dim myPanel As New MovablePanel

        myPanel.addPanel(Panel1)


        myPanel.initializeForm(Me)
        myPanel.addPanelEventHandler()

    End Sub

    Private Sub loadEmployeeData()
        employeeUI.clearParameter()

        loadingPanel.Visible = True

        Dim values As New Dictionary(Of String, String)

        _initializing(cCol.forEmployeeData,
                      values, employeeUI,
                      employeeDataBgWorker)

        cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, employeeDataBgWorker)

    End Sub

    Private Sub SuccessfullyDone()
        cListOfEmployeeDatas = TryCast(employeeUI.cData, List(Of PropsFields.employee_props_fields))

        'get the data result

        DataGridView1.DataSource = cListOfEmployeeDatas

        If cListOfEmployeeDatas.Count > 0 Then
            setCustomGridview()
            'selectedRows(DataGridView1, 0, cWh_pn_id)
        End If


        'done loading
        loadingPanel.Visible = False
    End Sub

    Private Sub setCustomGridview()

        With customGridview

            'readonly cells
            For Each col As DataGridViewColumn In DataGridView1.Columns
                .subcustomDatagridviewSettings("ReadOnlyCells", DataGridView1, col.Index)
            Next
            .subcustomDatagridviewSettings("ReadOnlyCells", DataGridView1, DataGridView1.Columns.Count)

            'hide colums
            .customDatagridviewHideColumn(DataGridView1, NameOf(aa.person_id), False)
            .customDatagridviewHideColumn(DataGridView1, NameOf(aa.employee), False)
            .customDatagridviewHideColumn(DataGridView1, NameOf(aa.position), False)
            .customDatagridviewHideColumn(DataGridView1, NameOf(aa.ext_name), False)


            'change headertext name

            .subcustomDatagridviewSettings2("headerTextOnly", DataGridView1, NameOf(aa.first_name), 200, chp2.FirstName)
            .subcustomDatagridviewSettings2("headerTextOnly", DataGridView1, NameOf(aa.last_name), 200, chp2.LastName)
            .subcustomDatagridviewSettings2("headerTextOnly", DataGridView1, NameOf(aa.middle_name), 200, chp2.MiddleName)
            .subcustomDatagridviewSettings2("headerTextOnly", DataGridView1, NameOf(aa.designation), 200, chp2.Designation)
            .subcustomDatagridviewSettings2("headerTextOnly", DataGridView1, NameOf(aa.department), 200, chp2.Department)
            .subcustomDatagridviewSettings2("headerTextOnly", DataGridView1, NameOf(aa.status_name), 200, chp2.Status)
            .subcustomDatagridviewSettings2("headerTextOnly", DataGridView1, NameOf(aa.employee_id), 60, chp2.EMPLOYEE_ID)

            .autoSizeColumn(DataGridView1, True)
        End With

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Dispose()
    End Sub

    Private Sub debounce_new_Tick(sender As Object, e As EventArgs) Handles debounce_new.Tick
        debounce_new.Stop()

        Dim searchResult As New List(Of PropsFields.employee_props_fields)
        searchResult = cListOfEmployeeDatas.Where(Function(x)
                                                      Dim output As String = x.first_name.ToUpper() &
                                                      " " & x.middle_name & " " & x.last_name.ToUpper() & " " & x.designation.ToUpper() &
                                                      " " & x.department.ToUpper()

                                                      Return output.Contains(cSearch.ToUpper)
                                                  End Function).OrderBy(Function(x) x.first_name).ToList()

        DataGridView1.DataSource = searchResult

        If searchResult.Count > 0 Then
            setCustomGridview()
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

    Private Sub FUserInfo_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Dispose()
    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        If customMsg.messageYesNo("Are you sure you want to link this to ther SMS users?", "SUPPLY INFO:") Then
            Dim user_id As Integer = FRegistrationForm.lvlRegstrationForm.SelectedItems(0).Text
            Dim employee_id As Integer = DataGridView1.SelectedRows(0).Cells(NameOf(aa.employee_id)).Value
            Dim cc As New ColumnValuesObj

            cc.add("employee_id", employee_id)
            cc.setCondition($"user_id = {user_id}")
            cc.updateQuery("dbregistrationform")

            FRegistrationForm.isTriggered = True
            FRegistrationForm.cUserId = user_id
            FRegistrationForm.loadUsersNew()
            Me.Close()
        End If
    End Sub


End Class