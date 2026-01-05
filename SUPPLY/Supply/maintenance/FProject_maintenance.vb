Imports System.ComponentModel
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports SUPPLY.PropsFields


Public Class FProject_maintenance
    Public sqlcon As New SQLcon2
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Public prj_id As Integer
    Dim j As Integer
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Dim trd As Threading.Thread
    Dim cListOfLviewItem As New List(Of ListViewItem)

    Private cActiveEnactiveUI, cSearchUI As New class_placeholder4
    Dim cBgWorkerChecker As Timer
    Dim cModel As New ModelNew.Model
    Dim isActive As String = cIsActive.ALL
    Dim cResult As New List(Of PropsFields.project_maintenance_fields)
    Dim cSearch As String
    Dim triggeredSaveUpdate As String = ""
    Dim projId As Integer = 0

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Dispose()
    End Sub

    Private Sub FProject_maintenance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label15.Parent = pboxHeader
        btnExit.Parent = pboxHeader

        cListOfLviewItem.Clear()
        lvl_projectDesc.Items.Clear()

        'get_project_desc()

        'load_project("")

        'UI
        cSearchUI.king_placeholder_textbox("Search Project", txt_search, Nothing, Panel1, My.Resources.categories, False,)
        cActiveEnactiveUI.king_placeholder_combobox("Select Option", cmbActiveEnactive, Nothing, Panel1, My.Resources.categories,)

        cmbActiveEnactive.Items.Add(cIsActive.ALL)
        cmbActiveEnactive.Items.Add(cIsActive.ACTIVE)
        cmbActiveEnactive.Items.Add(cIsActive.ENACTIVE)
        'cmbActiveEnactive.SelectedIndex = 0

        getProjects()

    End Sub

    Private Sub load_project(search As String)
        cListOfLviewItem.Clear()
        lvl_projectDesc.Items.Clear()

        Dim newProject As New class_project With {.proj_desc = search}

        With newProject
            .select_proj()

            For Each row In .cListOfProject
                Dim a(12) As String

                a(0) = row.proj_id
                a(1) = row.proj_desc.ToUpper
                a(2) = row.location
                a(3) = row.contract_id
                a(4) = row.contract_name
                a(5) = row.duration
                'a(5) = row.duration & " days (" & row.datefrom & " - " & row.dateto & ")"
                a(6) = row.project_engineer
                a(10) = IIf(row.date_completion = Date.Parse("1990-01-01"), "Waiting", row.date_close)
                a(11) = IIf(row.date_completion = Date.Parse("1990-01-01"), "Waiting", Format(row.date_completion, "MM/dd/yyyy"))
                'a(10) = IIf(row.days_left <= 0, "due", row.days_left) & " day/s"
                a(12) = row.dateCloseOpen

                Dim lvl As New ListViewItem(a)

                If row.days_left < 0 Then
                    If row.dateCloseOpen = "Date Close" Then
                        lvl.ForeColor = Color.Red
                    ElseIf row.dateCloseOpen = "Date Open" Then
                        lvl.ForeColor = Color.DarkGreen
                    End If

                Else
                    lvl.ForeColor = Color.Black
                End If
                cListOfLviewItem.Add(lvl)
            Next

            lvl_projectDesc.Items.AddRange(cListOfLviewItem.ToArray)

        End With
    End Sub
    Public Sub get_project_desc()
        Dim newSQ As New SQLcon

        lvl_projectDesc.Items.Clear()
        Dim x(10) As String
        Dim errs As String

        Try
            Dim cmd As SqlCommand
            Dim dr As SqlDataReader

            newSQ.connection1.Open()

            publicquery = "SELECT a.proj_id, a.project_desc, a.location, a.Contract_id, a.contract_name, a.project_duration, a.project_engineer, "
            publicquery &= "case when contract_amount IS NULL then 0.00 else a.contract_amount end as contract_amount, "
            publicquery &= "case when budgetary_amount IS NULL then 0.00 else a.budgetary_amount end as budgetary_amount, "
            publicquery &= "case when actual_amount IS NULL then 0.00 else a.actual_amount end as actual_amount, "
            publicquery &= "b.datefrom, b.dateto "
            publicquery &= "FROM dbprojectdesc a "
            publicquery &= "LEFT JOIN dbProject_Duration b on b.proj_id = a.proj_id "
            publicquery &= "ORDER BY a.project_desc ASC"

            cmd = New SqlCommand(publicquery, newSQ.connection1)

            dr = cmd.ExecuteReader
            While dr.Read

                Dim duration As Double
                Dim cDatefrom As DateTime
                Dim cDateto As DateTime

                If (dr.Item("datefrom").ToString) = "" Then
                    cDatefrom = Date.Parse("1990-01-01")
                Else
                    errs = dr.Item("datefrom").ToString
                    cDatefrom = Date.Parse(dr.Item("datefrom").ToString)
                End If

                If (dr.Item("dateto").ToString) = "" Then
                    cDateto = Date.Parse("1990-01-01")
                Else
                    cDateto = Date.Parse(dr.Item("dateto").ToString)
                End If

                duration = cDateto.Subtract(cDatefrom).TotalDays

                Dim days_left As Double
                days_left = FormatNumber(cDateto.Subtract(Date.Parse(Now)).TotalDays, 2,,, TriState.True)

                x(0) = dr.Item("proj_id").ToString
                x(1) = dr.Item("project_desc").ToString
                x(2) = dr.Item("location").ToString
                x(3) = dr.Item("Contract_id").ToString
                x(4) = dr.Item("contract_name").ToString
                x(5) = duration & " days (" & cDatefrom & " - " & cDateto & ")"
                x(6) = dr.Item("project_engineer").ToString
                x(7) = FormatNumber(dr.Item("contract_amount").ToString, 2, , , TriState.True)
                x(8) = FormatNumber(dr.Item("budgetary_amount").ToString, 2, , , TriState.True)
                x(9) = FormatNumber(dr.Item("actual_amount").ToString, 2, , , TriState.True)
                x(10) = IIf(days_left < 0, "due", days_left) & " day/s"
                If search_by1(x(1), txt_search.Text) = True Then
                Else
                    GoTo proceedhere
                End If

                Dim newList As New ListViewItem(x)
                lvl_projectDesc.Items.Add(newList)

proceedhere:

            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description & vbCrLf & vbCrLf & errs, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MsgBox(errs)
        Finally
            newSQ.connection1.Close()
        End Try
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click

        ''prj_id = lvl_projectDesc.SelectedItems(0).Text
        ''txtprojectdesc.Text = lvl_projectDesc.SelectedItems(0).SubItems(1).Text
        ''txtlocation.Text = lvl_projectDesc.SelectedItems(0).SubItems(2).Text
        ''txtContractId.Text = lvl_projectDesc.SelectedItems(0).SubItems(3).Text
        ''txtContractName.Text = lvl_projectDesc.SelectedItems(0).SubItems(4).Text
        ''txtProjectduration.Text = lvl_projectDesc.SelectedItems(0).SubItems(5).Text
        ''txtProjectengineer.Text = lvl_projectDesc.SelectedItems(0).SubItems(6).Text
        ''txtContractamount.Text = lvl_projectDesc.SelectedItems(0).SubItems(7).Text
        ''txtBudgetaryamount.Text = lvl_projectDesc.SelectedItems(0).SubItems(8).Text

        Dim newProj As New class_project With {.proj_id = CInt(lvl_projectDesc.SelectedItems(0).Text)}
        newProj.edit()

        With newProj
            txtprojectdesc.Text = .proj_desc
            txtlocation.Text = .location
            txtContractId.Text = .contract_id
            txtContractName.Text = .contract_name
            txtProjectduration.Text = lvl_projectDesc.SelectedItems(0).SubItems(5).Text
            txtProjectengineer.Text = .project_engineer
            txtContractamount.Text = .contract_amount
            txtBudgetaryamount.Text = .budgetary_amount
            dtpDateFrom.Text = .datefrom
            dtpDateTo.Text = .dateto
            dtpDateCompletion.Text = .date_completion
            txtProjectduration.Text = .duration
            cmbDateClose.Text = "Date Close"

        End With

        btn_save.Text = "Update"
        pnl_projectdesc.Visible = True
        lvl_projectDesc.Enabled = False

    End Sub

    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        pnl_projectdesc.Visible = False
        lvl_projectDesc.Enabled = True
        btn_save.Text = "Save"
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click

        If btn_save.Text = "Update" Then
            If MessageBox.Show("Are you sure you want to Update this data?", "Supply Info:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim proj_id As Integer = CInt(lvl_projectDesc.SelectedItems(0).Text)

                'public projectid
                projId = proj_id
                save_update_projectdesc(txtprojectdesc.Text, txtlocation.Text, txtContractId.Text, txtContractName.Text, txtProjectduration.Text, txtProjectengineer.Text, txtContractamount.Text, txtBudgetaryamount.Text, "Update", proj_id)

                'for project duration
                Dim newProj As New class_project
                newProj = New class_project With {
                                        .proj_id = proj_id,
                                        .datefrom = Date.Parse(dtpDateFrom.Text),
                                        .dateto = Date.Parse(dtpDateTo.Text),
                                        .date_completion = Date.Parse(dtpDateCompletion.Text),
                                        .dateCloseOpen = cmbDateClose.Text
                                        }

                newProj.update()

                'load_project(txt_search.Text)
                'listfocus(lvl_projectDesc, proj_id)
                triggeredSaveUpdate = cTriggered.UPDATE
                getProjects()

            Else
                Return
            End If
        ElseIf btn_save.Text = "Save" Then
            If MessageBox.Show("Are you sure you want to save this data?", "Supply Info:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                save_update_projectdesc(txtprojectdesc.Text, txtlocation.Text, txtContractId.Text, txtContractName.Text, txtProjectduration.Text, txtProjectengineer.Text, txtContractamount.Text, txtBudgetaryamount.Text, "Save")

                'for project duration
                Dim newProj As New class_project
                newProj = New class_project With {
                                        .proj_id = j,
                                        .datefrom = Date.Parse(dtpDateFrom.Text),
                                        .dateto = Date.Parse(dtpDateTo.Text),
                                        .date_completion = Date.Parse(dtpDateCompletion.Text),
                                        .dateCloseOpen = cmbDateClose.Text
                                        }

                newProj.update()

                triggeredSaveUpdate = cTriggered.SAVE
                getProjects()

                'load_project(txt_search.Text)
                'listfocus(lvl_projectDesc, j)
            End If

        End If

        pnl_projectdesc.Visible = False
        lvl_projectDesc.Enabled = True

    End Sub

    Public Sub save_update_projectdesc(ByVal projecdesc As String, ByVal location As String, ByVal Contract_id As String, ByVal contract_name As String, ByVal project_duration As String, ByVal project_engineer As String, ByVal contract_amount As String, ByVal budgetary_amount As String, ByVal btn As String, Optional proj_id As Integer = 0)
        Dim newSQ As New SQLcon
        Try

            Dim cmd As SqlCommand
            Dim dr As SqlDataReader

            newSQ.connection1.Open()

            If btn = "Update" Then
                publicquery = "UPDATE dbprojectdesc SET project_desc = '" & projecdesc & "', location = '" & location & "', Contract_id = '" & Contract_id & "', contract_name = '" & contract_name & "', "
                publicquery &= "project_engineer = '" & project_engineer & "', contract_amount = '" & contract_amount & "', budgetary_amount = '" & budgetary_amount & "', project_duration = '" & project_duration & "' "
                publicquery &= "WHERE proj_id = '" & proj_id & "' "

            ElseIf btn = "Save" Then
                publicquery = "SET NOCOUNT ON;"
                publicquery &= "INSERT INTO dbprojectdesc (project_desc, location, Contract_id, contract_name, project_engineer, contract_amount, budgetary_amount, project_duration) "
                publicquery &= "VALUES ('" & projecdesc & "', '" & location & "', '" & Contract_id & "', '" & contract_name & "','" & project_engineer & "','" & contract_amount & "','" & budgetary_amount & "','" & project_duration & "') "
                publicquery &= "SELECT SCOPE_IDENTITY()"
            End If

            cmd = New SqlCommand(publicquery, newSQ.connection1)

            If btn = "Update" Then
                cmd.ExecuteNonQuery()
            ElseIf btn = "Save" Then
                j = cmd.ExecuteScalar
                MessageBox.Show("Successfully saved", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection1.Close()
            'get_project_desc()

            'If btn = "Update" Then
            '    listfocus(lvl_projectDesc, prj_id)
            '    btn_save.Text = "Save"
            'ElseIf btn = "Save" Then
            '    listfocus(lvl_projectDesc, j)
            'End If

        End Try
    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click

        For Each ctr As Control In pnl_projectdesc.Controls
            If TypeOf ctr Is TextBox Then
                Dim tbox As TextBox = ctr
                tbox.Clear()

            End If
        Next

        pnl_projectdesc.Visible = True
        lvl_projectDesc.Enabled = False

    End Sub

    Private Sub DeteleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeteleToolStripMenuItem.Click

        If MessageBox.Show("Are you sure you want to Delete this data?", "Supply Info:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            delete_prjdesc()
            delete_date_completion()

            lvl_projectDesc.SelectedItems(0).Remove()
        Else
            Return
        End If

    End Sub

    Public Sub delete_prjdesc()
        Dim newSQ As New SQLcon
        Dim cmd As SqlCommand


        Try
            newSQ.connection1.Open()
            publicquery = "DELETE FROM dbprojectdesc WHERE proj_id = '" & lvl_projectDesc.SelectedItems(0).Text & "'"
            cmd = New SqlCommand(publicquery, newSQ.connection1)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection1.Close()
        End Try
    End Sub

    Public Sub delete_date_completion()
        Dim newSQ As New SQLcon
        Dim cmd As SqlCommand


        Try
            newSQ.connection1.Open()
            publicquery = "DELETE FROM dbProject_Duration WHERE proj_id = '" & lvl_projectDesc.SelectedItems(0).Text & "'"
            cmd = New SqlCommand(publicquery, newSQ.connection1)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection1.Close()
        End Try
    End Sub



#Region "GUI"
    Private Sub FProject_maintenance_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown, pboxHeader.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub FProject_maintenance_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove, pboxHeader.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub FProject_maintenance_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp, pboxHeader.MouseUp
        drag = False
    End Sub

    Private Sub btnExit_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnExit.MouseDown
        btnExit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.MouseEnter
        btnExit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.MouseLeave
        btnExit.BackgroundImage = My.Resources.close_button
    End Sub

    Private Sub lvl_projectDesc_DoubleClick(sender As Object, e As EventArgs) Handles lvl_projectDesc.DoubleClick

        If target_location_project = "FDeliveryReceipt" Then

            With FDeliveryReceipt
                For Each row As DataGridViewRow In .dgv_dr_list.Rows
                    If row.Cells(1).Selected = True Then
                        row.Cells("col_source").Value = lvl_projectDesc.SelectedItems(0).SubItems(1).Text
                        row.Cells("col_category").Value = "PROJECT"
                    End If

                Next
            End With

        ElseIf target_location_project = "FDeliveryReceipt_txtChargeTo" Then
            With FDeliveryReceipt
                For Each row As DataGridViewRow In .dgv_dr_list.Rows
                    If row.Cells(1).Selected = True Then
                        FDeliveryReceipt.txtChargeTo.Text = lvl_projectDesc.SelectedItems(0).SubItems(1).Text
                        FDeliveryReceipt.cmbTypeofCharge.Text = "PROJECT"
                    End If

                Next
            End With
        End If

        Me.Dispose()
    End Sub

    Private Sub FProject_maintenance_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        public_rowind = Nothing
        target_location_project = Nothing

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FImport_excel.Show()
    End Sub
#End Region
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        project_cost_maintenance_report()
    End Sub
    Public Sub project_cost_maintenance_report()

        Dim dt As New DataTable
        Dim i As Integer = 0

        With dt
            .Columns.Add("proj_code")
            .Columns.Add("contract_amount")
            .Columns.Add("budgetary")
            .Columns.Add("actual_cost")
            .Columns.Add("percentage_actual_expense")
            '.Columns.Add("remarks")

        End With

        For i = 0 To lvl_projectDesc.Items.Count - 1
            dt.Rows.Add(dt.NewRow)

            dt.Rows(i).Item("proj_code") = lvl_projectDesc.Items(i).SubItems(1).Text
            dt.Rows(i).Item("contract_amount") = lvl_projectDesc.Items(i).SubItems(7).Text
            dt.Rows(i).Item("budgetary") = lvl_projectDesc.Items(i).SubItems(8).Text
            dt.Rows(i).Item("actual_cost") = lvl_projectDesc.Items(i).SubItems(9).Text
            If lvl_projectDesc.Items(i).SubItems(7).Text = 0.00 Or lvl_projectDesc.Items(i).SubItems(8).Text = 0.00 Or lvl_projectDesc.Items(i).SubItems(9).Text = 0.00 Then
                dt.Rows(i).Item("percentage_actual_expense") = 0
            Else
                dt.Rows(i).Item("percentage_actual_expense") = (lvl_projectDesc.Items(i).SubItems(9).Text / lvl_projectDesc.Items(i).SubItems(8).Text) * 100
            End If
            ' dt.Rows(i).Item("remarks") = lvl_projectDesc.Items(i).SubItems(10).Text

        Next

        Dim view As New DataView(dt)

        FReport_project_maintenance.ReportViewer1.LocalReport.DataSources.Item(0).Value = view
        FReport_project_maintenance.ShowDialog()
        FReport_project_maintenance.Dispose()
    End Sub

    Private Sub cmbDateClose_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDateClose.SelectedIndexChanged
        If cmbDateClose.Text = "Date Close" Then
            dtpDateCompletion.Enabled = True
        Else
            dtpDateCompletion.Enabled = False
        End If
    End Sub


    Private Sub cmbActiveEnactive_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbActiveEnactive.SelectedIndexChanged

        displayResult(cResult)
    End Sub


    Private Sub getProjects()
        lvl_projectDesc.Items.Clear()
        cListOfLviewItem.Clear()
        cModel.clearParameter()

        loadingPanel.Visible = True

        Dim values As New Dictionary(Of String, String)
        values.Add("project", "")

        _initializing(cCol.forActive_Projects, values, cModel, projectsBgWorker)
        cBgWorkerChecker = BgWorkersCheckerFn(AddressOf Done, projectsBgWorker)

    End Sub

    Private Sub Done()
        'get the data result
        cResult = CType(cModel.cData, List(Of PropsFields.project_maintenance_fields))

        'display to gridview or listview
        displayResult(cResult)

        'done loading
        loadingPanel.Visible = False

        'reset selected index to 0
        cmbActiveEnactive.SelectedIndex = 0

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles debounce.Tick
        debounce.Stop()

        Dim searchResult As New List(Of PropsFields.project_maintenance_fields)

        searchResult = (From A In cResult
                        Where A.proj_desc.ToUpper().Contains(cSearch.ToUpper()) ' Adjust this to use Contains or other method based on your needs
                        Select A).ToList()

        If Not cSearchUI.ifBlankTexbox() Then
            displayResult(searchResult)
        Else
            displayResult(cResult)
        End If

        loadingPanel.Visible = False
    End Sub

    Private Sub displayResult(paramResult As List(Of PropsFields.project_maintenance_fields))
        lvl_projectDesc.Items.Clear()
        cListOfLviewItem.Clear()


        For Each row In paramResult
            Dim a(12) As String

            a(0) = row.proj_id
            a(1) = row.proj_desc.ToUpper
            a(2) = row.location
            a(3) = row.contract_id
            a(4) = row.contract_name
            a(5) = row.duration
            'a(5) = row.duration & " days (" & row.datefrom & " - " & row.dateto & ")"
            a(6) = row.project_engineer
            a(10) = IIf(row.date_completion = Date.Parse("1990-01-01"), "Waiting", row.date_close)
            a(11) = IIf(row.date_completion = Date.Parse("1990-01-01"), "Waiting", Format(row.date_completion, "MM/dd/yyyy"))
            'a(10) = IIf(row.days_left <= 0, "due", row.days_left) & " day/s"
            a(12) = row.dateCloseOpen

            Dim lvl As New ListViewItem(a)

            Select Case cmbActiveEnactive.Text
                Case cIsActive.ACTIVE
                    If row.days_left < 0 Then
                        If row.dateCloseOpen = "Date Open" Then
                            lvl.ForeColor = Color.DarkGreen
                            cListOfLviewItem.Add(lvl)
                        End If
                    End If

                Case cIsActive.ENACTIVE
                    If row.days_left < 0 Then
                        If row.dateCloseOpen = "Date Close" Then
                            lvl.ForeColor = Color.Red
                            cListOfLviewItem.Add(lvl)
                        End If
                    End If

                Case cIsActive.ALL
                    If row.days_left < 0 Then
                        If row.dateCloseOpen = "Date Close" Then
                            lvl.ForeColor = Color.Red
                        ElseIf row.dateCloseOpen = "Date Open" Then
                            lvl.ForeColor = Color.DarkGreen
                        End If
                    Else
                        lvl.ForeColor = Color.Black
                    End If

                    cListOfLviewItem.Add(lvl)
            End Select
        Next

        lvl_projectDesc.Items.AddRange(cListOfLviewItem.ToArray)

        'if triggered update
        If triggeredSaveUpdate = cTriggered.UPDATE Then
            listfocus(lvl_projectDesc, projId)

            'clear
            projId = 0
            triggeredSaveUpdate = ""
        End If

    End Sub

    Private Sub txt_search_TextChanged(sender As Object, e As EventArgs) Handles txt_search.TextChanged
        cSearch = txt_search.Text
    End Sub

    Private Sub txt_search_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_search.KeyDown
        If txt_search.TextLength > 0 Then
            loadingPanel.Visible = True
            debounce.Start()
        Else
            loadingPanel.Visible = True
            cSearch = ""
            debounce.Start()

        End If

    End Sub
End Class