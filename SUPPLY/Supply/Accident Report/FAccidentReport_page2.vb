Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Public Class FAccidentReport_page2
    Public SQ As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Dim list_unsafe_acts As New List(Of List(Of String))
    Dim list_unsafe_condition As New List(Of List(Of String))
    Dim list_management_sys_def As New List(Of List(Of String))
    Dim list_checked_items As New List(Of String)
    Dim root_cause_type_id As Integer
    Dim root_cause_description As String
    Public Sub load_root_cause_analysis(ByVal n As Integer)
        If n = 1 Then
            lvlUnsafeActs.Items.Clear()
        ElseIf n = 2 Then
            lvlUnsafeConditions.Items.Clear()
        ElseIf n = 3 Then
            lvlManagementSysDef.Items.Clear()
        End If

        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_AccidentReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 4)

            If n = 1 Then
                sqlcomm.Parameters.AddWithValue("@id", 1)
            ElseIf n = 2 Then
                sqlcomm.Parameters.AddWithValue("@id", 2)
            ElseIf n = 3 Then
                sqlcomm.Parameters.AddWithValue("@id", 3)
            End If

            dr = sqlcomm.ExecuteReader

            While dr.Read
                Dim a(10) As String

                a(0) = dr.Item(0).ToString

                Dim lvl As New ListViewItem(a)
                If n = 1 Then
                    lvlUnsafeActs.Items.Add(lvl)
                ElseIf n = 2 Then
                    lvlUnsafeConditions.Items.Add(lvl)
                ElseIf n = 3 Then
                    lvlManagementSysDef.Items.Add(lvl)
                End If

            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Private Sub FAccidentReport_page2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If boolean_acc_report = False Then
            load_root_cause_analysis(1)
            load_root_cause_analysis(2)
            load_root_cause_analysis(3)
        Else

            load_root_cause_analysis(1)
            load_root_cause_analysis(2)
            load_root_cause_analysis(3)

            insert_list_checked_items()
            load_list_checked_items()

            'Dim row As Integer = 0

            'For Each item In lvlUnsafeActs.Items
            '    If item.text = "Improper Work Technique" Then
            '        lvlUnsafeActs.Items(row).Checked = True
            '    End If
            '    row = row + 1
            'Next

            ' lvlUnsafeActs.Items(1).Checked = True
        End If

    End Sub
    Public Sub insert_list_checked_items()
        SQ.connection.Open()
        Dim sqlcomm As New SqlCommand

        sqlcomm.Connection = SQ.connection
        sqlcomm.CommandText = "sp_crud_AccidentReport"
        sqlcomm.CommandType = CommandType.StoredProcedure
        sqlcomm.Parameters.AddWithValue("@n", 14)
        sqlcomm.Parameters.AddWithValue("@acc_report_id", get_acc_id)

        dr = sqlcomm.ExecuteReader

        While dr.Read
            list_checked_items.Add(dr.Item(0).ToString)
        End While
        dr.Close()

        SQ.connection.Close()
    End Sub
    Sub load_list_checked_items()
        Dim n As Integer

        For index As Integer = 1 To list_checked_items.Count
            ' MsgBox("item checked item" & list_checked_items(index - 1))
            load_root_cause_type_id_description(list_checked_items(index - 1), n)
        Next

    End Sub
    Public Sub load_root_cause_type_id_description(ByVal x As String, ByVal n As Integer)
        SQ.connection.Open()
        Dim sqlcomm As New SqlCommand

        sqlcomm.Connection = SQ.connection
        sqlcomm.CommandText = "sp_crud_AccidentReport"
        sqlcomm.CommandType = CommandType.StoredProcedure
        sqlcomm.Parameters.AddWithValue("@n", 15)
        sqlcomm.Parameters.AddWithValue("@root_cause_info_id", CInt(x))

        dr = sqlcomm.ExecuteReader

        While dr.Read
            root_cause_type_id = dr.Item(1).ToString
            root_cause_description = dr.Item(2).ToString
        End While
        dr.Close()

        SQ.connection.Close()

        n = root_cause_type_id
        ' MsgBox("test n: " & n)
        If n = 1 Then
            Dim row As Integer
            For Each item In lvlUnsafeActs.Items
                If item.text = root_cause_description Then
                    lvlUnsafeActs.Items(row).Checked = True
                End If
                row = row + 1
            Next
        ElseIf n = 2 Then
            Dim row1 As Integer
            For Each item In lvlUnsafeConditions.Items
                If item.text = root_cause_description Then
                    lvlUnsafeConditions.Items(row1).Checked = True
                End If
                row1 = row1 + 1
            Next
        ElseIf n = 3 Then
            Dim row2 As Integer
            For Each item In lvlManagementSysDef.Items
                If item.text = root_cause_description Then
                    lvlManagementSysDef.Items(row2).Checked = True
                End If
                row2 = row2 + 1
            Next
        End If

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.Text = "Save" Then
            list_unsafe_acts = New List(Of List(Of String))
            list_unsafe_condition = New List(Of List(Of String))
            list_management_sys_def = New List(Of List(Of String))
            Dim row As Integer = 0
            Dim row1 As Integer = 0
            Dim row2 As Integer = 0

            For Each item In lvlUnsafeActs.CheckedItems
                list_unsafe_acts.Add(New List(Of String))
                list_unsafe_acts(row).Add(1)
                list_unsafe_acts(row).Add(item.text)

                row = row + 1
            Next

            For Each item1 In lvlUnsafeConditions.CheckedItems
                list_unsafe_condition.Add(New List(Of String))
                list_unsafe_condition(row1).Add(2)
                list_unsafe_condition(row1).Add(item1.text)

                row1 = row1 + 1
            Next

            For Each item2 In lvlManagementSysDef.CheckedItems
                list_management_sys_def.Add(New List(Of String))
                list_management_sys_def(row2).Add(3)
                list_management_sys_def(row2).Add(item2.text)

                row2 = row2 + 1
            Next

            load_list()
            MessageBox.Show("Successfully Saved...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
            FAccidentReport.Close()
            Me.Close()
            FAccidentReportField.lvl_acc_report_field.SelectedItems.Clear()
            With FAccidentReportField
                '.btnSearch.PerformClick()
                search_acc_report_1()
                listfocus1(.lvl_acc_report_field, get_acc_id)
            End With

        ElseIf btnSave.Text = "Update" Then

            'delete first
            Delete_mul_root_cause_analysis(get_acc_id)
            'save
            list_unsafe_acts = New List(Of List(Of String))
            list_unsafe_condition = New List(Of List(Of String))
            list_management_sys_def = New List(Of List(Of String))
            Dim row As Integer = 0
            Dim row1 As Integer = 0
            Dim row2 As Integer = 0

            For Each item In lvlUnsafeActs.CheckedItems
                list_unsafe_acts.Add(New List(Of String))
                list_unsafe_acts(row).Add(1)
                list_unsafe_acts(row).Add(item.text)

                row = row + 1
            Next

            For Each item1 In lvlUnsafeConditions.CheckedItems
                list_unsafe_condition.Add(New List(Of String))
                list_unsafe_condition(row1).Add(2)
                list_unsafe_condition(row1).Add(item1.text)

                row1 = row1 + 1
            Next

            For Each item2 In lvlManagementSysDef.CheckedItems
                list_management_sys_def.Add(New List(Of String))
                list_management_sys_def(row2).Add(3)
                list_management_sys_def(row2).Add(item2.text)

                row2 = row2 + 1
            Next

            load_list()
            MessageBox.Show("Successfully Updated...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.Close()
            FAccidentReportField.lvl_acc_report_field.SelectedItems.Clear()
            With FAccidentReportField
                '.btnSearch.PerformClick()
                search_acc_report_1()
                listfocus1(.lvl_acc_report_field, get_acc_id)
            End With
        End If

    End Sub

    Public Sub search_acc_report_1()
        FAccidentReportField.lvl_acc_report_field.Items.Clear()

        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_AccidentReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 16)

            dr = sqlcomm.ExecuteReader

            While dr.Read
                Dim a(25) As String

                a(0) = dr.Item("acc_report_id").ToString
                a(1) = dr.Item("cat_damage_name").ToString
                a(2) = dr.Item("accident_report_no").ToString
                a(3) = dr.Item("cat_damaged").ToString
                a(4) = dr.Item("listProperty_equip_mat_damaged").ToString
                a(5) = dr.Item("natured_damaged").ToString
                a(6) = dr.Item("object_subs_inflicting_damaged").ToString
                a(7) = dr.Item("app_cost_damaged").ToString
                a(8) = dr.Item("breakdown_days").ToString
                a(9) = dr.Item("investigator_name").ToString
                a(10) = dr.Item("job_position").ToString
                a(11) = dr.Item("project_desc").ToString
                a(12) = dr.Item("depart_section_name").ToString
                a(13) = dr.Item("CHARGE_TO").ToString
                a(14) = Format(Date.Parse(dr.Item("date_incident").ToString), "MM/dd/yyyy")
                a(15) = dr.Item("time_incident").ToString
                a(16) = Format(Date.Parse(dr.Item("date_report").ToString), "MM/dd/yyyy")
                a(17) = dr.Item("time_report").ToString
                a(18) = dr.Item("witnessed_by").ToString
                a(19) = dr.Item("supervisor_info_id").ToString
                a(20) = dr.Item("injured_party_id").ToString
                a(21) = dr.Item("equip_pro_dam_id").ToString

                Dim lvl As New ListViewItem(a)
                FAccidentReportField.lvl_acc_report_field.Items.Add(lvl)

            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Sub load_list()
        'For Each item As List(Of String) In list_unsafe_acts
        '    MsgBox("test 1 : " & item(0) & " and test 2 : " & item(1))
        'Next

        For index As Integer = 1 To list_unsafe_acts.Count
            insert_root_cause_analysis(get_root_cause_info_id(list_unsafe_acts(index - 1)(0), list_unsafe_acts(index - 1)(1)))
            'MsgBox("unsafe acts: " & get_root_cause_info_id(list_unsafe_acts(index - 1)(0), list_unsafe_acts(index - 1)(1)))
        Next

        For index_1 As Integer = 1 To list_unsafe_condition.Count
            insert_root_cause_analysis(get_root_cause_info_id(list_unsafe_condition(index_1 - 1)(0), list_unsafe_condition(index_1 - 1)(1)))
            'MsgBox("conditional acts: " & get_root_cause_info_id(list_unsafe_condition(index_1 - 1)(0), list_unsafe_condition(index_1 - 1)(1)))
        Next

        For index_2 As Integer = 1 To list_management_sys_def.Count
            insert_root_cause_analysis(get_root_cause_info_id(list_management_sys_def(index_2 - 1)(0), list_management_sys_def(index_2 - 1)(1)))
            ' MsgBox("management system def: " & get_root_cause_info_id(list_management_sys_def(index_2 - 1)(0), list_management_sys_def(index_2 - 1)(1)))
        Next
    End Sub
    Public Sub insert_root_cause_analysis(ByVal x As Integer)
        Dim z As Integer
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_AccidentReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 12)
            sqlcomm.Parameters.AddWithValue("@type_root_cause_id", x)
            sqlcomm.Parameters.AddWithValue("@acc_report_id", get_acc_id)

            z = sqlcomm.ExecuteScalar

            ' MessageBox.Show("Successfully Saved...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Public Function get_root_cause_info_id(ByVal x As String, ByVal y As String) As Integer
        ' Try
        SQ.connection.Open()
        Dim sqlcomm As New SqlCommand

        sqlcomm.Connection = SQ.connection
        sqlcomm.CommandText = "sp_crud_AccidentReport"
        sqlcomm.CommandType = CommandType.StoredProcedure
        sqlcomm.Parameters.AddWithValue("@n", 11)
        sqlcomm.Parameters.AddWithValue("@root_cause_type_id", CInt(x))
        sqlcomm.Parameters.AddWithValue("@root_cause_description", y)

        dr = sqlcomm.ExecuteReader

        While dr.Read
            get_root_cause_info_id = dr.Item(0).ToString
        End While
        dr.Close()

        ' Catch ex As Exception
        ' MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ' Finally
        SQ.connection.Close()
        ' End Try
    End Function
    Public Sub Delete_mul_root_cause_analysis(ByVal x As Integer)
        ' Dim i As Integer = lvlLiquidationReport.SelectedItems(0).SubItems(0).Text
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_AccidentReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 24)
            sqlcomm.Parameters.AddWithValue("@acc_report_id", x)
            sqlcomm.ExecuteNonQuery()
            ' MsgBox("delete")
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

End Class