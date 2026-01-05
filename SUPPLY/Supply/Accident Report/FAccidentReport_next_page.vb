Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Public Class FAccidentReport_next_page
    Public SQ As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Dim list_unsafe_acts As New List(Of List(Of String))
    Dim list_unsafe_condition As New List(Of List(Of String))
    Dim list_management_sys_def As New List(Of List(Of String))
    Dim list_checked_items As New List(Of List(Of String))
    Dim root_cause_type_id As Integer
    Dim root_cause_description As String
    Public Sub load_root_cause_analysis(ByVal n As Integer)
        If n = 1 Then
            ' gview_Unsafe_acts.Rows.Clear()
        ElseIf n = 2 Then
            ' lvlUnsafeConditions.Items.Clear()
        ElseIf n = 3 Then
            ' lvlManagementSysDef.Items.Clear()
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
                a(1) = dr.Item(0).ToString

                If n = 1 Then
                    gview_Unsafe_acts.Rows.Add(a)
                ElseIf n = 2 Then
                    gview_unsafe_condition.Rows.Add(a)
                ElseIf n = 3 Then
                    gview_mgt_syt_deficiency.Rows.Add(a)
                End If
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Function get_root_cause_info_id(ByVal x As Integer, ByVal y As String) As Integer
        ' Try
        SQ.connection.Open()
        Dim sqlcomm As New SqlCommand

        sqlcomm.Connection = SQ.connection
        sqlcomm.CommandText = "sp_crud_AccidentReport"
        sqlcomm.CommandType = CommandType.StoredProcedure
        sqlcomm.Parameters.AddWithValue("@n", 11)
        sqlcomm.Parameters.AddWithValue("@root_cause_type_id", x)
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
    Public Sub insert_root_cause_analysis(ByVal x As Integer)
        If x = 1 Then
            If list_unsafe_acts.Count = 0 Then
                ' MsgBox("ian wlay sulod" & " " & "unsafe acts")
            Else
                Dim str_query As String = "insert into dbRoot_cause_analysis values "
                Dim c As Integer = 0
                For Each list As List(Of String) In list_unsafe_acts
                    If c = 0 Then
                        str_query = str_query + "(" & list(0) & ", " & list(1) & ", '" & list(2) & "')"
                    Else
                        str_query = str_query + ",(" & list(0) & ", " & list(1) & ", '" & list(2) & "')"
                    End If
                    c = c + 1
                Next
                ' MsgBox(str_query)
                connection_save_to_root_cause_analysis(str_query)
            End If
        ElseIf x = 2 Then
            If list_unsafe_condition.Count = 0 Then
                ' MsgBox("ian wlay sulod" & " " & "unsafe condition")
            Else
                Dim str_query As String = "insert into dbRoot_cause_analysis values "
                Dim c1 As Integer = 0
                For Each list As List(Of String) In list_unsafe_condition
                    If c1 = 0 Then
                        str_query = str_query + "(" & list(0) & ", " & list(1) & ", '" & list(2) & "')"
                    Else
                        str_query = str_query + ",(" & list(0) & ", " & list(1) & ", '" & list(2) & "')"
                    End If
                    c1 = c1 + 1
                Next
                'MsgBox(str_query)
                connection_save_to_root_cause_analysis(str_query)
            End If
        ElseIf x = 3 Then
            If list_management_sys_def.Count = 0 Then
                '  MsgBox("ian wlay sulod" & " " & "management system def")
            Else
                Dim str_query As String = "insert into dbRoot_cause_analysis values "
                Dim c2 As Integer = 0
                For Each list As List(Of String) In list_management_sys_def
                    If c2 = 0 Then
                        str_query = str_query + "(" & list(0) & ", " & list(1) & ", '" & list(2) & "')"
                    Else
                        str_query = str_query + ",(" & list(0) & ", " & list(1) & ", '" & list(2) & "')"
                    End If
                    c2 = c2 + 1
                Next
                ' MsgBox(str_query)
                connection_save_to_root_cause_analysis(str_query)
            End If
        End If
    End Sub
    Public Sub connection_save_to_root_cause_analysis(ByVal str_query As String)
        ' Try
        SQ.connection.Open()
        Dim sqlcomm As New SqlCommand

        sqlcomm.Connection = SQ.connection
        sqlcomm.CommandType = CommandType.Text
        sqlcomm.CommandText = str_query

        sqlcomm.ExecuteNonQuery()

        'MessageBox.Show("Successfully Saved...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ' Catch ex As Exception
        'MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '  Finally
        SQ.connection.Close()
        ' End Try
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
    Public Sub insert_list_checked_items()
        SQ.connection.Open()
        Dim row As Integer
        Dim sqlcomm As New SqlCommand

        sqlcomm.Connection = SQ.connection
        sqlcomm.CommandText = "sp_crud_AccidentReport"
        sqlcomm.CommandType = CommandType.StoredProcedure
        sqlcomm.Parameters.AddWithValue("@n", 14)
        sqlcomm.Parameters.AddWithValue("@acc_report_id", get_acc_id)
        'sqlcomm.Parameters.AddWithValue("@acc_report_id", 4)

        dr = sqlcomm.ExecuteReader

        While dr.Read
            list_checked_items.Add(New List(Of String))
            list_checked_items(row).Add(dr.Item(0).ToString)
            list_checked_items(row).Add(dr.Item(1).ToString)
            row = row + 1
        End While
        dr.Close()

        SQ.connection.Close()
    End Sub
    Sub load_list_checked_items()
        Dim n As Integer

        For index As Integer = 1 To list_checked_items.Count
            ' MsgBox("item checked item" & list_checked_items(index - 1)(0))
            load_root_cause_type_id_description(list_checked_items(index - 1)(0), n, list_checked_items(index - 1)(1))
        Next

    End Sub
    Public Sub load_root_cause_type_id_description(ByVal x As String, ByVal n As Integer, ByVal y As String)
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
            For i As Integer = 0 To gview_Unsafe_acts.Rows.Count - 1
                If gview_Unsafe_acts.Rows(i).Cells(1).Value.ToString = root_cause_description Then
                    ' MsgBox("yes naa raq gview_Unsafe_acts")
                    gview_Unsafe_acts(0, i).Value = True
                    gview_Unsafe_acts.Rows(i).Cells(2).Value = y
                End If
            Next
        ElseIf n = 2 Then
            For i As Integer = 0 To gview_unsafe_condition.Rows.Count - 1
                If gview_unsafe_condition.Rows(i).Cells(1).Value.ToString = root_cause_description Then
                    '  MsgBox("yes naa raq gview_unsafe_condition")
                    gview_unsafe_condition(0, i).Value = True
                    gview_unsafe_condition.Rows(i).Cells(2).Value = y
                End If
            Next
        ElseIf n = 3 Then
            For i As Integer = 0 To gview_mgt_syt_deficiency.Rows.Count - 1
                If gview_mgt_syt_deficiency.Rows(i).Cells(1).Value.ToString = root_cause_description Then
                    ' MsgBox("yes naa raq gview_mgt_syt_deficiency")
                    gview_mgt_syt_deficiency(0, i).Value = True
                    gview_mgt_syt_deficiency.Rows(i).Cells(2).Value = y
                End If
            Next
        End If

    End Sub
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
    Public Sub save_to_root_cause_analysis()
        list_unsafe_acts = New List(Of List(Of String))
        list_unsafe_condition = New List(Of List(Of String))
        list_management_sys_def = New List(Of List(Of String))
        Dim row As Integer = 0
        Dim row1 As Integer = 0
        Dim row2 As Integer = 0
        Dim accident_id As Integer = get_acc_id

        For i As Integer = 0 To gview_Unsafe_acts.Rows.Count - 1
            If CBool(DirectCast(gview_Unsafe_acts.Rows(i).Cells(0), DataGridViewCheckBoxCell).Value) = True Then
                'get root cause info ID
                Dim value As Integer
                value = get_root_cause_info_id(1, gview_Unsafe_acts.Rows(i).Cells(1).Value)
                ' MsgBox(get_root_cause_info_id(1, gview_Unsafe_acts.Rows(i).Cells(1).Value))

                list_unsafe_acts.Add(New List(Of String))
                list_unsafe_acts(row).Add(value)
                list_unsafe_acts(row).Add(accident_id)
                list_unsafe_acts(row).Add(gview_Unsafe_acts.Rows(i).Cells(2).Value)

                row = row + 1
            End If
        Next

        For i As Integer = 0 To gview_unsafe_condition.Rows.Count - 1
            If CBool(DirectCast(gview_unsafe_condition.Rows(i).Cells(0), DataGridViewCheckBoxCell).Value) = True Then
                'get root cause info ID
                Dim value As Integer
                value = get_root_cause_info_id(2, gview_unsafe_condition.Rows(i).Cells(1).Value)
                ' MsgBox(get_root_cause_info_id(1, gview_Unsafe_acts.Rows(i).Cells(1).Value))

                list_unsafe_condition.Add(New List(Of String))
                list_unsafe_condition(row1).Add(value)
                list_unsafe_condition(row1).Add(accident_id)
                list_unsafe_condition(row1).Add(gview_unsafe_condition.Rows(i).Cells(2).Value)

                row1 = row1 + 1
            End If
        Next

        For i As Integer = 0 To gview_mgt_syt_deficiency.Rows.Count - 1
            If CBool(DirectCast(gview_mgt_syt_deficiency.Rows(i).Cells(0), DataGridViewCheckBoxCell).Value) = True Then
                'get root cause info ID
                Dim value As Integer
                value = get_root_cause_info_id(3, gview_mgt_syt_deficiency.Rows(i).Cells(1).Value)
                ' MsgBox(get_root_cause_info_id(1, gview_Unsafe_acts.Rows(i).Cells(1).Value))

                list_management_sys_def.Add(New List(Of String))
                list_management_sys_def(row2).Add(value)
                list_management_sys_def(row2).Add(accident_id)
                list_management_sys_def(row2).Add(gview_mgt_syt_deficiency.Rows(i).Cells(2).Value)

                row2 = row2 + 1
            End If
        Next

        'insert list_unsafe_acts
        insert_root_cause_analysis(1)
        'insert list_unsafe_condition
        insert_root_cause_analysis(2)
        'insert list_management_system_deficiencies
        insert_root_cause_analysis(3)

        'For Each item As List(Of String) In list_management_sys_def
        '    MsgBox("test 1 : " & item(0) & " and test 2 : " & item(1) & " and test 3 : " & item(2))
        'Next
    End Sub
    Private Sub FAccidentReport_next_page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        End If

    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.Text = "Save" Then
            'save to table root cause analysis
            save_to_root_cause_analysis()
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

            'save to table root cause analysis
            save_to_root_cause_analysis()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
End Class