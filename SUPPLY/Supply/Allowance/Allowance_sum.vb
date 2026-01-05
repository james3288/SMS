Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Globalization
Imports Microsoft.Office.Interop
Public Class Allowance_sum
    Public SQ As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Public public_query As String
    Dim list_name_operator As New List(Of List(Of String))
    Public name_list As New List(Of List(Of String))
    Public plate_no_list As New List(Of List(Of String))

    Dim project_list_no As New List(Of String)
    Dim plate_list_no As New List(Of String)
    Dim name_list_location As New List(Of String)
    Dim name_list_amount As New List(Of String)
    Dim name_list_amount_salary As New List(Of String)
    Dim name_list_charge_to As New List(Of String)
    Dim name_listss As New List(Of String)
    Dim z As Integer

    Dim list_project_desc As New List(Of List(Of String))
    Dim list_charge_description As New List(Of List(Of String))
    Dim list_charge_to As New List(Of List(Of String))
    Dim list_equipment_list As New List(Of List(Of String))
    Dim list_typeofequipments As New List(Of List(Of String))
    Dim sortColumn As Integer = -1
    Public total_adfilchargecode As String
    Public total_projectcode As String
    Public ids_for_deleting As Integer

    Dim txt_row3 As New AutoCompleteStringCollection
    Dim nameIDList As New Dictionary(Of String, String)
    Dim hrms_person_id As Integer = 0

    Private Sub Allowance_sum_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_charges()
        load_project_name()
        load_adfilcode()

        'load_Project_Worksite_Designation(0)
        'load_Project_Worksite_Designation(1)
        load_adfil_charge(2)
        load_adfil_charge(0)
        'save_name_list(1) 'name data save
        save_name_list(2) 'location data save
        'save_list_name()
        ''plate_no()
    End Sub
    Private Sub txt_cmbbox_GotFocus(sender As Object, e As EventArgs) Handles txtVoucher.GotFocus,
        cmbSearch.GotFocus, cmbSearch_Project_WorkSite.GotFocus, txtSearch.GotFocus,
        txtadfil_code1.GotFocus, cmbcategory1.GotFocus, cmbcategory2.GotFocus, txtAllowanceAmt.GotFocus, txtAmtRet.GotFocus, txtAwnceAmtSalary.GotFocus,
        txtAmtRetSalary.GotFocus, cmbview_search.GotFocus
        sender.backcolor = Color.Yellow
    End Sub
    Private Sub txt_cmbbox_leave(sender As Object, e As EventArgs) Handles txtVoucher.Leave,
        cmbSearch.Leave, cmbSearch_Project_WorkSite.Leave, txtSearch.Leave,
        txtadfil_code1.Leave, cmbcategory1.Leave, cmbcategory2.Leave, txtAllowanceAmt.Leave, txtAmtRet.Leave, txtAwnceAmtSalary.Leave, txtAmtRetSalary.Leave, cmbview_search.Leave
        sender.backcolor = Color.White
        ''allowance

        txtAllowanceAmt.Text = Format(Val(txtAllowanceAmt.Text), "0.00")
        txtAmtRet.Text = Format(Val(txtAmtRet.Text), "0.00")
        txtTotalAmt.Text = Format(Val(txtTotalAmt.Text), "0.00")
        txtTotalAmt.Text = Format(Val(txtAllowanceAmt.Text - txtAmtRet.Text), "0.00")

        ''salarywage
        txtAwnceAmtSalary.Text = Format(Val(txtAwnceAmtSalary.Text), "0.00")
        txtAmtRetSalary.Text = Format(Val(txtAmtRetSalary.Text), "0.00")
        txtTotAmtSalary.Text = Format(Val(txtTotAmtSalary.Text), "0.00")
        txtTotAmtSalary.Text = Format(Val(txtAwnceAmtSalary.Text - txtAmtRetSalary.Text), "0.00")

    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcategory1.SelectedIndexChanged
        If cmbcategory1.Text = "EQUIP" Then
            cmbcategory2.Enabled = True
            'cmbProjectcode.Text = ""
            cmbequip_no.Enabled = True
            'cmbProjectcode.Enabled = False
            'txtadfil_code.Enabled = False
            'txtLocation.Enabled = False
            cmbcategory2.Visible = True
            'cmbProjectcode.Items.Clear()
            save_name_list(1)
            load_plate_no()
            cmbcategory2.Enabled = True
            'save_list_name()
            'save_list_name()
            'lblProjectWorksite.Text = "Equip. No"
            'plate_no()


        ElseIf cmbcategory1.Text = "ADMIN" Then
            cmbcategory2.SelectedIndex = -1
            'cmbProjectcode.Text = ""
            'txtadfil_code1.Text = ""
            cmbcategory2.Enabled = False
            cmbProjectcode.Enabled = False
            txtadfil_code1.Enabled = False
            cmbcategory2.Enabled = True
            save_name_list(1)
            'cmbequip_no.Enabled = False
            'cmbcategory2.Visible = False

        ElseIf cmbcategory1.Text = "PROJECT" Then
            cmbcategory2.SelectedIndex = -1
            cmbProjectcode.Enabled = True
            txtadfil_code1.Enabled = True
            cmbcategory2.Enabled = False

            'cmbequip_no.Enabled = False
            'cmbcategory2.Visible = False
            cmbProjectcode.Items.Clear()
            save_name_list(1)
            'load_Project_Worksite_Designation(0)
            'load_Project_Worksite_Designation(1)
            'lblProjectWorksite.Text = "Project Code Work Site:"
        ElseIf cmbcategory1.Text = "OPERATION" Then
            save_name_list(1)
            cmbcategory2.SelectedIndex = -1
            cmbcategory2.Enabled = False
            'cmbequip_no.Enabled = False

        End If
    End Sub

    Public Sub clear_fields(ByVal x As Integer)
        If x = 0 Then
            txtName.Text = ""
            cmbDesignation.Text = Nothing
            cmbcategory1.SelectedIndex = -1
            cmbcategory2.SelectedIndex = -1
            cmbProjectcode.Text = ""
            txtadfil_code1.Text = ""
            txtAllowanceAmt.Text = "0.00"
            txtAmtRet.Text = "0.00"
            txtTotalAmt.Text = "0.00"
            txtAwnceAmtSalary.Text = "0.00"
            txtAmtRetSalary.Text = "0.00"
            txtTotAmtSalary.Text = "0.00"
            cmbequip_no.Text = ""
            btnSave.Text = "Save"

        ElseIf x = 1 Then
            '' cmbProjectWorksite.Text = Nothing
            txtLocation.Text = ""
            txtName.Text = ""
            cmbDesignation.Text = Nothing
            cmbequip_no.Text = Nothing
            txtVoucher.Text = ""
            cmbcategory1.SelectedIndex = -1
            cmbcategory2.SelectedIndex = -1
            txtProjName.Text = ""
            txtadfil_code.Text = ""
            txtAllowanceAmt.Text = "0.00"
            txtAmtRet.Text = "0.00"
            txtTotalAmt.Text = "0.00"
            txtAwnceAmtSalary.Text = "0.00"
            txtAmtRetSalary.Text = "0.00"
            txtTotAmtSalary.Text = "0.00"
            cmbequip_no.Text = ""
            btnSave.Text = "Save"
        Else

        End If
    End Sub

    Public Sub load_Project_Worksite_Designation(ByVal x As Integer)
        Try
            SQ.connection1.Open()
            If x = 0 Or x = 1 Then
                public_query = "SELECT * FROM dbprojectdesc ORDER BY project_desc ASC"
            End If
            cmd = New SqlCommand(public_query, SQ.connection1)
            dr = cmd.ExecuteReader

            While dr.Read
                If x = 0 Then
                    cmbProjectcode.Items.Add(dr.Item("project_desc").ToString)
                ElseIf x = 1 Then
                    cmbview_search.Items.Add(dr.Item("project_desc").ToString)
                End If
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection1.Close()
        End Try

    End Sub

    Public Sub load_adfil_charge(ByVal x As Integer)
        Try
            SQ.connection.Open()
            If x = 0 Or x = 1 Then
                public_query = "SELECT * FROM dbcharge_description ORDER BY description ASC"
            ElseIf x = 2 Then
                public_query = "SELECT * FROM dbdesignation ORDER BY designation ASC"
            ElseIf x = 3 Then
                public_query = "SELECT * FROM dbcharge_description ORDER BY description ASC"
            End If
            cmd = New SqlCommand(public_query, SQ.connection)
            dr = cmd.ExecuteReader

            While dr.Read
                If x = 0 Then
                    'txtadfil_code.Items.Add(dr.Item("code").ToString)
                ElseIf x = 2 Then
                    ''cmbDesignation.Items.Add(dr.Item(0).ToString)
                    cmbDesignation.Items.Add(dr.Item("designation").ToString)
                ElseIf x = 3 Then
                    cmbview_search.Items.Add(dr.Item("code").ToString)
                End If
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
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

    'Public Sub load_plate_no()
    '    Dim newSqlcon1 As New SQLcon
    '    Dim newdr1 As SqlDataReader

    '    Try
    '        newSqlcon1.connection.Open()
    '        Dim newsqlcom1 As New SqlCommand

    '        newsqlcom1.Connection = newSqlcon1.connection
    '        newsqlcom1.CommandText = "sp_crud_Allowance"
    '        newsqlcom1.CommandType = CommandType.StoredProcedure
    '        newsqlcom1.Parameters.AddWithValue("@n", 20)
    '        newdr1 = newsqlcom1.ExecuteReader

    '        While newdr1.Read
    '            cmbDesignation.Items.Add(newdr1.Item(0).ToString)
    '        End While
    '        newdr1.Close()

    '    Catch ex As Exception
    '        MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        newSqlcon1.connection.Close()
    '    End Try
    'End Sub
    'Private Sub txtname_name(sender As Object, e As EventArgs) Handles txtName.Leave
    '    cmbDesignation.Items.Clear()
    '    If txtName.Text <> "" Then
    '        Try
    '            SQ.connection.Open()
    '            Dim sqlcomm As New SqlCommand

    '            sqlcomm.Connection = SQ.connection
    '            sqlcomm.CommandText = "sp_crud_Allowance"
    '            sqlcomm.CommandType = CommandType.StoredProcedure
    '            sqlcomm.Parameters.AddWithValue("@n", 19)
    '            sqlcomm.Parameters.AddWithValue("@operator", txtName.Text)
    '            sqlcomm.Parameters.AddWithValue("@eu_date", CDate(DTP_Allowance.Text))
    '            dr = sqlcomm.ExecuteReader
    '            If dr.HasRows = True Then
    '                While dr.Read
    '                    cmbDesignation.Items.Add(dr.Item(0).ToString)
    '                End While
    '                dr.Close()
    '            Else
    '                'MsgBox("ian")
    '                load_plate_no()
    '            End If
    '        Catch ex As Exception
    '            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Finally
    '            SQ.connection.Close()
    '        End Try
    '    End If
    'End Sub

    Public Sub save_name_list(ByVal n As Integer)
        Dim i As Integer = 0
        Dim uses As Boolean


        Try
            SQ.connection.Open()
            If n = 1 Then
                'public_query = "select (last_name +', ' + first_name + ' ' + LEFT(middle_name, 1)) from dbo.tblPerson "

                public_query = "select
				                a.person_id,
				                a.last_name + ', ' + a.first_name + ISNULL(' ' + LEFT(a.middle_name,1) + '. ','') + ISNULL(a.ext_name,'') as Employee
				                ,(SELECT
												                STUFF((
													                select 
													                ' / ' + aa.position_name
													                from hrms_db.dbo.tblPosition aa
													                inner join hrms_db.dbo.tblEmployeePosition bb on bb.position_id = aa.position_id
													                where bb.status = 'active'
													                and bb.employee_id = c.employee_id
													                FOR XML PATH(''), TYPE
												                ).value('.', 'nvarchar(max)'), 1, 2, '')
											                ) AS Position
			                from hrms_db.dbo.tblPerson a
			                inner join hrms_db.dbo.tblEmployee b on b.person_id = a.person_id
			                left join hrms_db.dbo.tblEmployeeStatus c on c.employee_id = b.employee_id
			                where (c.status = 'active' or c.status is null)
			                and (c.status_id <> 4 or c.status_id is null)
			                order by a.last_name asc"


            ElseIf n = 2 Then
                public_query = "SELECT DISTINCT Location FROM dbAllowance"
            ElseIf n = 3 Then
                public_query = "SELECT DISTINCT Amount FROM dbAllowance"
            ElseIf n = 4 Then
                public_query = "SELECT DISTINCT Amount_Salary FROM dbAllowance"
            ElseIf n = 5 Then
                public_query = "SELECT DISTINCT charge_to from dbCharge_to"
            ElseIf n = 6 Then
                public_query = "select
		                                a.person_id
		                                ,a.last_name + ', ' + a.first_name + ISNULL(' ' + LEFT(a.middle_name,1) + '. ','') + ISNULL(a.ext_name,'') as Employee
		                                ,(SELECT
			                                   STUFF((
					                                select ' / ' + aa.position_name
					                                from hrms_db.dbo.tblPosition aa
					                                inner join hrms_db.dbo.tblEmployeePosition bb on bb.position_id = aa.position_id
					                                where bb.status = 'active'
						                                and bb.employee_id = c.employee_id 
						                                FOR XML PATH(''), TYPE).value('.', 'nvarchar(max)'), 1, 2, '')) AS Position
						            
                                  from hrms_db.dbo.tblPerson a
                                  inner join hrms_db.dbo.tblEmployee b on b.person_id = a.person_id
                                  left join hrms_db.dbo.tblEmployeeStatus c on c.employee_id = b.employee_id
                                  where (c.status = 'active' or c.status is null)
                                  order by a.last_name asc"
            End If

            cmd = New SqlCommand(public_query, SQ.connection)
            dr = cmd.ExecuteReader

            While dr.Read
                If n = 1 Then
                    'name_listss.Add(dr.Item(1).ToString)
                    Dim id As String = dr.Item(0).ToString()
                    Dim name As String = dr.Item(1).ToString()

                    If Not nameIDList.ContainsKey(name) Then
                        txt_row3.Add(name)
                        nameIDList.Add(name, id)
                    End If
                    uses = False
                ElseIf n = 2 Then
                    name_list_location.Add(dr.Item(0).ToString)
                    uses = True
                ElseIf n = 3 Then
                    name_list_amount.Add(dr.Item(0).ToString)
                ElseIf n = 4 Then
                    name_list_amount_salary.Add(dr.Item(0).ToString)
                ElseIf n = 5 Then
                    name_list_charge_to.Add(dr.Item(0).ToString)
                    uses = False
                ElseIf n = 6 Then
                    Dim id As String = dr.Item(0).ToString()
                    Dim name As String = dr.Item(1).ToString()

                    If Not nameIDList.ContainsKey(name) Then
                        txt_row3.Add(name)
                        nameIDList.Add(name, id)
                    End If
                    uses = False
                End If
                i = i + 1
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("Error MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

        If uses = True Then
            Dim txt_row2 As New AutoCompleteStringCollection
            For Each list_location In name_list_location
                txt_row2.Add(list_location)
            Next
            txtLocation.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtLocation.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtLocation.AutoCompleteCustomSource = txt_row2
        ElseIf uses = False Then
            txtName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtName.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtName.AutoCompleteCustomSource = txt_row3
            'Dim txt_row3 As New AutoCompleteStringCollection
            'For Each tbl_name_list In name_listss
            '    txt_row3.Add(tbl_name_list)
            'Next
            'txtName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            'txtName.AutoCompleteSource = AutoCompleteSource.CustomSource
            'txtName.AutoCompleteCustomSource = txt_row3

        End If

    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)
        FPerson_Name.ShowDialog()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtName.Text = "" Then
            MessageBox.Show("Name field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtName.Focus()
        ElseIf cmbDesignation.Text = "" Then
            MessageBox.Show("Designation field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            cmbDesignation.Focus()

        Else
            If btnSave.Text = "Save" Then
                removed_selection_lenght()
                check_allwnce_exist()

                'cmbSearch.Text = "Date"
                'DTP_search_Allowance.Text = DTP_Allowance.Text
                'btnSearch.PerformClick()
                'listfocus(lvlAllowance, z)
                'clear_fields(0)
                'DTP_Allowance.Focus()

            ElseIf btnSave.Text = "Update" Then
                removed_selection_lenght()
                Dim ex = MessageBox.Show("Are you sure u want to update the SELECTED item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If ex = MsgBoxResult.Yes Then
                    update_all_sum()
                    'btnSearch.PerformClick()
                    clear_fields(1)
                    btnSave.Text = "Save"
                End If

            End If
        End If
    End Sub

    Private Sub cmbcategory2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcategory2.SelectedIndexChanged
        'If cmbcategory2.Text = "ID/UNIT NUMBER" Then
        '    cmbProjectcode.Enabled = True
        'Else
        '    'cmbProjectcode.Enabled = False
        '    'cmbProjectcode.Text = ""
        '    'cmbcategory3.SelectedIndex = -1  this is for clear dropdownlist
        'End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs)

    End Sub

    'Public Sub plate_no_equip_no()
    '    Dim server As String = "192.168.2.96"
    '    Dim dBase As String = "eus"
    '    Dim sqls As New SqlConnection("SERVER=" & server & ";Database=" & dBase & ";Uid=sa;Pwd=P@ssw0rd1!")
    '    Dim i As Integer = 0
    '    Try
    '        sqls.Open()
    '        public_query = "SELECT * FROM dbeu WHERE eu_id =(SELECT MAX(eu_id) FROM dbeu WHERE eu_date BETWEEN '2022-04-25' AND '2022-05-07' and operator LIKE '%" & txtName.Text & "%') "
    '        cmd = New SqlCommand(public_query, sqls)
    '        dr = cmd.ExecuteReader

    '        While dr.Read
    '            cmbProjectcode.Text = dr.Item(2).ToString
    '            'cmbProjectcode.Items.Add(dr.Item(2).ToString)
    '            'plate_list_no.Add(dr.Item(0).ToString)
    '        End While
    '        dr.Close()

    '    Catch ex As Exception
    '        MessageBox.Show("Error MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        sqls.Close()
    '    End Try
    '    'Dim txt_row2 As New AutoCompleteStringCollection
    '    'For Each list_of_plate In plate_list_no
    '    '    txt_row2.Add(list_of_plate)
    '    'Next
    '    ''cmbcategory3.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    '    ''cmbcategory3.AutoCompleteSource = AutoCompleteSource.CustomSource
    '    ''cmbcategory3.AutoCompleteCustomSource = txt_row2
    '    'cmbProjectcode.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    '    'cmbProjectcode.AutoCompleteSource = AutoCompleteSource.CustomSource
    '    'cmbProjectcode.AutoCompleteCustomSource = txt_row2

    'End Sub
    Private Sub txtadfil_code_Click(sender As Object, e As EventArgs)
        '' allowance_charge_to_code.ShowDialog()
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
        designation_form.ShowDialog()
    End Sub


    Public Function get_id_plateno(ByVal x As String) As Integer
        Try
            SQ.connection1.Open()
            public_query = "SELECT equipListID FROM dbequipment_list WHERE plate_no = '" & x & "'"
            cmd = New SqlCommand(public_query, SQ.connection1)
            dr = cmd.ExecuteReader
            While dr.Read
                get_id_plateno = dr.Item(0).ToString
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection1.Close()
        End Try
    End Function

    Public Function get_id_proj_location(ByVal x As String) As Integer
        Try
            SQ.connection1.Open()
            public_query = "SELECT location FROM dbprojectdesc WHERE project_desc = '" & x & "'"
            cmd = New SqlCommand(public_query, SQ.connection1)
            dr = cmd.ExecuteReader
            While dr.Read
                txtLocation.Text = dr.Item(0).ToString
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection1.Close()
        End Try

    End Function

    Public Function get_id_person(ByVal x As String) As Integer
        'Dim fullnames As String = txtName.Text
        Dim firstname As String = Split(Trim(Split(x, ",")(1)), " ")(0)
        Dim lastname As String = Split(x, ", ")(0)

        Try
            SQ.connection.Open()
            public_query = "select person_id from dbo.tblPerson where last_name = '" & lastname & "' and first_name LIKE '%" & firstname & "%'"
            cmd = New SqlCommand(public_query, SQ.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                get_id_person = dr.Item(0).ToString
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

    End Function

    Public Function get_id_designation(ByVal x As String) As Integer
        Try
            SQ.connection.Open()
            public_query = "SELECT designation_id FROM dbdesignation WHERE designation = '" & x & "'"
            cmd = New SqlCommand(public_query, SQ.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                get_id_designation = dr.Item(0).ToString
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Function

    Public Function get_id_projeccode(ByVal x As String) As Integer
        Try
            SQ.connection1.Open()
            public_query = "SELECT proj_id FROM dbprojectdesc WHERE project_desc = '" & x & "'"
            cmd = New SqlCommand(public_query, SQ.connection1)
            dr = cmd.ExecuteReader
            While dr.Read
                get_id_projeccode = dr.Item(0).ToString
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection1.Close()
        End Try

    End Function

    Public Function get_id_adfilchargecode(ByVal x As String) As Integer
        Try
            SQ.connection.Open()
            public_query = "SELECT charge_desc_id FROM dbcharge_description WHERE code = '" & x & "'"
            cmd = New SqlCommand(public_query, SQ.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                get_id_adfilchargecode = dr.Item(0).ToString
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

    End Function

    Public Sub save_sum_allawance()

        Dim sql1 As New SQLcon
        Dim proj_id As Integer
        Dim adfil_id As Integer
        checkingName_exist_from_HRMS()
        If hrms_person_id = 0 Then
            Exit Sub
        End If

        Try
            sql1.connection.Open()
            Dim sqlcomm As New SqlCommand()

            If txtProjName.Text = "" Then
                proj_id = 0
            Else
                proj_id = get_id_projeccode(txtProjName.Text)
            End If

            If txtadfil_code.Text = "" Then
                adfil_id = 0
            Else
                adfil_id = get_id_adfilchargecode(txtadfil_code.Text)
            End If


            sqlcomm.Connection = sql1.connection
            sqlcomm.CommandText = "sp_crud_Allowance"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 24)
            sqlcomm.Parameters.AddWithValue("@sum_date", DateTime.Parse(DTP_Allowance.Text))
            sqlcomm.Parameters.AddWithValue("@sum_name", txtName.Text)
            sqlcomm.Parameters.AddWithValue("@sum_desig", get_id_designation(cmbDesignation.Text))
            sqlcomm.Parameters.AddWithValue("@sum_location", txtLocation.Text)
            sqlcomm.Parameters.AddWithValue("@sum_cate", cmbcategory1.Text)
            sqlcomm.Parameters.AddWithValue("@sum_subcat", cmbcategory2.Text)
            sqlcomm.Parameters.AddWithValue("@sum_plate", get_id_plateno(cmbequip_no.Text))
            sqlcomm.Parameters.AddWithValue("@sum_proj_code", proj_id)
            sqlcomm.Parameters.AddWithValue("@sum_adfilcode", adfil_id)
            sqlcomm.Parameters.AddWithValue("@sum_voucher", txtVoucher.Text)
            sqlcomm.Parameters.AddWithValue("@sum_allfrom", DateTime.Parse(dtpFrom.Text))
            sqlcomm.Parameters.AddWithValue("@sum_allto", DateTime.Parse(dtpTo.Text))
            sqlcomm.Parameters.AddWithValue("@sum_allamt", CDbl(txtAllowanceAmt.Text))
            If txtAmtRet.Text = "" Then
                sqlcomm.Parameters.AddWithValue("@sum_allret", CDbl("0.00"))
            Else
                sqlcomm.Parameters.AddWithValue("@sum_allret", CDbl(txtAmtRet.Text))
            End If
            If txtAmtRet.Text = "0.00" Then
                sqlcomm.Parameters.AddWithValue("@sum_alltotal", CDbl(txtAllowanceAmt.Text))
            Else
                sqlcomm.Parameters.AddWithValue("@sum_alltotal", CDbl(txtTotalAmt.Text))
            End If


            sqlcomm.Parameters.AddWithValue("@sum_swfrom", DateTime.Parse(dtpFromSalary.Text))
            sqlcomm.Parameters.AddWithValue("@sum_swto", DateTime.Parse(dtpToSalary.Text))
            sqlcomm.Parameters.AddWithValue("@sum_swamt", CDbl(txtAwnceAmtSalary.Text))
            sqlcomm.Parameters.AddWithValue("@sum_swret", CDbl(txtAmtRetSalary.Text))
            sqlcomm.Parameters.AddWithValue("@sum_swtot", CDbl(txtTotAmtSalary.Text))
            sqlcomm.Parameters.AddWithValue("@sum_person_id", get_id_person(txtName.Text))
            sqlcomm.Parameters.AddWithValue("@sum_cat_code", txtboxCategory.Text)
            sqlcomm.Parameters.AddWithValue("@remarks", txtRemarks.Text)
            sqlcomm.Parameters.AddWithValue("@user_id", pub_user_id)
            sqlcomm.Parameters.AddWithValue("@hrms_person_id", hrms_person_id)

            z = sqlcomm.ExecuteScalar()
            MessageBox.Show("Successfully Saved...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '"DERE MAG BUTANG UG MA DUGANG NA AMMOUNT SA EQUIPMENT"
            cmbSearch.Text = "Date"
            DTP_search_Allowance.Text = DTP_Allowance.Text
            DTP_period_to.Text = DTP_Allowance.Text
            btnSearch.PerformClick()
            listfocus(lvlAllowance, z)
            lvlAllowance.Focus()
            clear_fields(0)
            DTP_Allowance.Focus()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sql1.connection.Close()
        End Try
    End Sub

    Public Sub update_all_sum()
        Dim id As Integer = lvlAllowance.SelectedItems(0).SubItems(0).Text
        Dim sql1 As New SQLcon
        Dim proj_id As Integer
        Dim adfil_id As Integer
        Dim currentDate As Date = Date.Today
        Try
            sql1.connection.Open()
            Dim sqlcomm As New SqlCommand()
            If txtProjName.Text = "" Then
                proj_id = 0
            Else
                proj_id = get_id_projeccode(txtProjName.Text)
            End If
            If txtadfil_code.Text = "" Then
                adfil_id = 0
            Else
                adfil_id = get_id_adfilchargecode(txtadfil_code.Text)
            End If

            sqlcomm.Connection = sql1.connection
            sqlcomm.CommandText = "sp_crud_Allowance"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 28)
            sqlcomm.Parameters.AddWithValue("@sum_Ids", id)
            sqlcomm.Parameters.AddWithValue("@sum_date", DateTime.Parse(DTP_Allowance.Text))
            sqlcomm.Parameters.AddWithValue("@sum_name", txtName.Text)
            sqlcomm.Parameters.AddWithValue("@sum_desig", get_id_designation(cmbDesignation.Text))
            sqlcomm.Parameters.AddWithValue("@sum_location", txtLocation.Text)
            sqlcomm.Parameters.AddWithValue("@sum_cate", cmbcategory1.Text)
            sqlcomm.Parameters.AddWithValue("@sum_subcat", cmbcategory2.Text)
            sqlcomm.Parameters.AddWithValue("@sum_plate", get_id_plateno(cmbequip_no.Text))
            sqlcomm.Parameters.AddWithValue("@sum_proj_code", proj_id)
            sqlcomm.Parameters.AddWithValue("@sum_adfilcode", adfil_id)
            sqlcomm.Parameters.AddWithValue("@sum_voucher", txtVoucher.Text)
            sqlcomm.Parameters.AddWithValue("@sum_allfrom", DateTime.Parse(dtpFrom.Text))
            sqlcomm.Parameters.AddWithValue("@sum_allto", DateTime.Parse(dtpTo.Text))
            sqlcomm.Parameters.AddWithValue("@sum_allamt", CDbl(txtAllowanceAmt.Text))



            If txtAmtRet.Text = "" Or txtAmtRet.Text = "0.00" Then
                sqlcomm.Parameters.AddWithValue("@sum_allret", CDbl("0.00"))
            Else
                sqlcomm.Parameters.AddWithValue("@sum_allret", CDbl(txtAmtRet.Text))
                sqlcomm.Parameters.AddWithValue("@return_date_log", currentDate.ToString("yyyy-MM-dd"))

            End If
            If txtAmtRet.Text = "0.00" Then
                sqlcomm.Parameters.AddWithValue("@sum_alltotal", CDbl(txtAllowanceAmt.Text))
            Else
                sqlcomm.Parameters.AddWithValue("@sum_alltotal", CDbl(txtTotalAmt.Text))
            End If
            sqlcomm.Parameters.AddWithValue("@sum_swfrom", DateTime.Parse(dtpFromSalary.Text))
            sqlcomm.Parameters.AddWithValue("@sum_swto", DateTime.Parse(dtpToSalary.Text))
            sqlcomm.Parameters.AddWithValue("@sum_swamt", CDbl(txtAwnceAmtSalary.Text))
            sqlcomm.Parameters.AddWithValue("@sum_swret", CDbl(txtAmtRetSalary.Text))
            sqlcomm.Parameters.AddWithValue("@sum_swtot", CDbl(txtTotAmtSalary.Text))
            sqlcomm.Parameters.AddWithValue("@sum_person_id", get_id_person(txtName.Text))
            sqlcomm.Parameters.AddWithValue("@sum_cat_code", txtboxCategory.Text)
            sqlcomm.Parameters.AddWithValue("@remarks", txtRemarks.Text)
            sqlcomm.Parameters.AddWithValue("@user_id", pub_user_id)
            If cbDateReturnSelection.Checked = True Then
                sqlcomm.Parameters.AddWithValue("@sum_date_return", DateTime.Parse(dtpDateReturned.Text))
                sqlcomm.Parameters.AddWithValue("@returned_by", txtReturnedBy.Text)
                sqlcomm.Parameters.AddWithValue("@receive_by", txtReceiveBy.Text)
            Else
                sqlcomm.Parameters.AddWithValue("@sum_date_return", "01/01/1995")
            End If


            sqlcomm.ExecuteNonQuery()
            MessageBox.Show("Successfully Updated...", "Supply Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
            update_without_database()
            btnSearch.PerformClick()
            dtpDateReturned.Enabled = False
            cbDateReturnSelection.Checked = False

            txtReturnedBy.Enabled = False
            txtReceiveBy.Enabled = False
            txtReturnedBy.Text = ""
            txtReceiveBy.Text = ""

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "Supply INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sql1.connection.Close()
        End Try
    End Sub
    Private Sub txtName_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Public Sub Search_allowance(ByVal x As Integer)
        lvlAllowance.Items.Clear()
        Dim i As Integer = get_id_projeccode(cmbSearch_Project_WorkSite.Text)
        Dim count1 As Integer = 0
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_Allowance"
            sqlcomm.CommandType = CommandType.StoredProcedure

            If x = 0 Then
                If CheckBox1.Checked = True Then
                    sqlcomm.Parameters.AddWithValue("@n", 415)
                    sqlcomm.Parameters.AddWithValue("@sum_project_code_search", cmbview_search.Text)
                    sqlcomm.Parameters.AddWithValue("@sum_date", DTP_search_Allowance.Text)
                    sqlcomm.Parameters.AddWithValue("@sum_date_to", DTP_period_to.Text)
                Else
                    sqlcomm.Parameters.AddWithValue("@n", 399)
                    sqlcomm.Parameters.AddWithValue("@sum_project_code_search", cmbview_search.Text)
                    sqlcomm.Parameters.AddWithValue("@sum_date", DTP_search_Allowance.Text)
                    sqlcomm.Parameters.AddWithValue("@sum_date_to", DTP_period_to.Text)
                End If

            ElseIf x = 1 Then

                If CheckBox1.Checked = True Then
                    sqlcomm.Parameters.AddWithValue("@n", 416)
                    sqlcomm.Parameters.AddWithValue("@Name", txtSearch.Text)
                Else
                    sqlcomm.Parameters.AddWithValue("@n", 22)
                    sqlcomm.Parameters.AddWithValue("@Name", txtSearch.Text)
                End If

            ElseIf x = 2 Then
                If CheckBox1.Checked = True Then
                    sqlcomm.Parameters.AddWithValue("@n", 417)
                    sqlcomm.Parameters.AddWithValue("@sum_adfilcharge_search", cmbview_search.Text)
                    sqlcomm.Parameters.AddWithValue("@sum_date", DTP_search_Allowance.Text)
                    sqlcomm.Parameters.AddWithValue("@sum_date_to", DTP_period_to.Text)
                Else
                    sqlcomm.Parameters.AddWithValue("@n", 400)
                    sqlcomm.Parameters.AddWithValue("@sum_adfilcharge_search", cmbview_search.Text)
                    sqlcomm.Parameters.AddWithValue("@sum_date", DTP_search_Allowance.Text)
                    sqlcomm.Parameters.AddWithValue("@sum_date_to", DTP_period_to.Text)
                End If

            ElseIf x = 3 Then
                If CheckBox1.Checked = True Then
                    sqlcomm.Parameters.AddWithValue("@n", 418)
                    sqlcomm.Parameters.AddWithValue("@sum_cate", cmbview_search.Text)
                Else
                    sqlcomm.Parameters.AddWithValue("@n", 26)
                    sqlcomm.Parameters.AddWithValue("@sum_cate", cmbview_search.Text)
                End If

            ElseIf x = 4 Then
                If CheckBox1.Checked = True Then
                    sqlcomm.Parameters.AddWithValue("@n", 419)
                    sqlcomm.Parameters.AddWithValue("@sum_subcat", cmbview_search.Text)
                Else
                    sqlcomm.Parameters.AddWithValue("@n", 27)
                    sqlcomm.Parameters.AddWithValue("@sum_subcat", cmbview_search.Text)
                End If

            ElseIf x = 5 Then
                If CheckBox1.Checked = True Then
                    sqlcomm.Parameters.AddWithValue("@n", 420)
                    sqlcomm.Parameters.AddWithValue("@sum_date", DTP_search_Allowance.Text)
                Else
                    sqlcomm.Parameters.AddWithValue("@n", 30)
                    sqlcomm.Parameters.AddWithValue("@sum_date", DTP_search_Allowance.Text)
                End If

            ElseIf x = 6 Then
                If CheckBox1.Checked = True Then
                    sqlcomm.Parameters.AddWithValue("@n", 414)
                    sqlcomm.Parameters.AddWithValue("@sum_date", DTP_search_Allowance.Text)
                    sqlcomm.Parameters.AddWithValue("@sum_date_to", DTP_period_to.Text)
                Else
                    sqlcomm.Parameters.AddWithValue("@n", 31)
                    sqlcomm.Parameters.AddWithValue("@sum_date", DTP_search_Allowance.Text)
                    sqlcomm.Parameters.AddWithValue("@sum_date_to", DTP_period_to.Text)
                End If


            ElseIf x = 7 Then
                If CheckBox1.Checked = True Then
                    sqlcomm.Parameters.AddWithValue("@n", 421)
                    sqlcomm.Parameters.AddWithValue("@sum_date", DTP_search_Allowance.Text)
                    sqlcomm.Parameters.AddWithValue("@sum_date_to", DTP_period_to.Text)
                Else
                    sqlcomm.Parameters.AddWithValue("@n", 32)
                    sqlcomm.Parameters.AddWithValue("@sum_date", DTP_search_Allowance.Text)
                    sqlcomm.Parameters.AddWithValue("@sum_date_to", DTP_period_to.Text)
                End If


            ElseIf x = 8 Then
                If CheckBox1.Checked = True Then
                    sqlcomm.Parameters.AddWithValue("@n", 422)
                    sqlcomm.Parameters.AddWithValue("@sum_date", DTP_search_Allowance.Text)
                    sqlcomm.Parameters.AddWithValue("@sum_date_to", DTP_period_to.Text)
                Else
                    sqlcomm.Parameters.AddWithValue("@n", 33)
                    sqlcomm.Parameters.AddWithValue("@sum_date", DTP_search_Allowance.Text)
                    sqlcomm.Parameters.AddWithValue("@sum_date_to", DTP_period_to.Text)
                End If

            ElseIf x = 9 Then
                If CheckBox1.Checked = True Then
                    sqlcomm.Parameters.AddWithValue("@n", 423)
                    sqlcomm.Parameters.AddWithValue("@sum_voucher", txtSearch.Text)
                Else
                    sqlcomm.Parameters.AddWithValue("@n", 34)
                    sqlcomm.Parameters.AddWithValue("@sum_voucher", txtSearch.Text)
                End If

            ElseIf x = 10 Then
                sqlcomm.Parameters.AddWithValue("@n", 35)
                sqlcomm.Parameters.AddWithValue("@sum_date", DTP_search_Allowance.Text)
                sqlcomm.Parameters.AddWithValue("@sum_date_to", DTP_period_to.Text)


            ElseIf x = 11 Then
                sqlcomm.Parameters.AddWithValue("@n", 409)
                sqlcomm.Parameters.AddWithValue("@sum_date", DTP_search_Allowance.Text)
                sqlcomm.Parameters.AddWithValue("@sum_date_to", DTP_period_to.Text)
                sqlcomm.Parameters.AddWithValue("@equipment_type", cmb_equipment_search.Text)
            ElseIf x = 12 Then

                If CheckBox1.Checked = True Then
                    sqlcomm.Parameters.AddWithValue("@n", 424)
                    sqlcomm.Parameters.AddWithValue("@sum_date", DTP_search_Allowance.Text)
                    sqlcomm.Parameters.AddWithValue("@sum_date_to", DTP_period_to.Text)
                    sqlcomm.Parameters.AddWithValue("@remarks", cmb_equipment_search.Text)
                Else
                    sqlcomm.Parameters.AddWithValue("@n", 411)
                    sqlcomm.Parameters.AddWithValue("@sum_date", DTP_search_Allowance.Text)
                    sqlcomm.Parameters.AddWithValue("@sum_date_to", DTP_period_to.Text)
                    sqlcomm.Parameters.AddWithValue("@remarks", cmb_equipment_search.Text)
                End If

            ElseIf x = 13 Then

                If CheckBox1.Checked = True Then
                    'sqlcomm.Parameters.AddWithValue("@n", 424)
                    'sqlcomm.Parameters.AddWithValue("@sum_date", DTP_search_Allowance.Text)
                    'sqlcomm.Parameters.AddWithValue("@sum_date_to", DTP_period_to.Text)
                    'sqlcomm.Parameters.AddWithValue("@remarks", cmb_equipment_search.Text)
                Else
                    sqlcomm.Parameters.AddWithValue("@n", 425)
                    sqlcomm.Parameters.AddWithValue("@sum_adfilcharge_search", cmbview_search.Text)
                    sqlcomm.Parameters.AddWithValue("@sum_date", DTP_search_Allowance.Text)
                    sqlcomm.Parameters.AddWithValue("@sum_date_to", DTP_period_to.Text)

                End If
            ElseIf x = 14 Then

                If CheckBox1.Checked = True Then
                    'sqlcomm.Parameters.AddWithValue("@n", 424)
                    'sqlcomm.Parameters.AddWithValue("@sum_date", DTP_search_Allowance.Text)
                    'sqlcomm.Parameters.AddWithValue("@sum_date_to", DTP_period_to.Text)
                    'sqlcomm.Parameters.AddWithValue("@remarks", cmb_equipment_search.Text)
                Else
                    sqlcomm.Parameters.AddWithValue("@n", 426)
                    sqlcomm.Parameters.AddWithValue("@sum_date", DTP_search_Allowance.Text)
                    sqlcomm.Parameters.AddWithValue("@sum_date_to", DTP_period_to.Text)
                    sqlcomm.Parameters.AddWithValue("@sum_project_code_search", cmbview_search.Text)
                End If
            End If
            dr = sqlcomm.ExecuteReader
            While dr.Read

                Dim a(31) As String

                a(0) = dr.Item(20).ToString()
                a(1) = dr.Item(1).ToString()

                If IsDate(dr.Item("date")) Then
                    a(2) = Format(CDate(dr.Item("date")), "MM/dd/yyyy")
                Else
                    a(2) = "-"
                End If

                a(3) = dr.Item(2).ToString()
                a(4) = dr.Item(4).ToString()
                a(5) = dr.Item(5).ToString()
                a(6) = dr.Item(9).ToString()
                a(7) = dr.Item(6).ToString() ' ok na
                a(8) = dr.Item(7).ToString() ' project
                a(9) = dr.Item(3).ToString()
                a(10) = dr.Item(8).ToString()

                If IsDate(dr.Item(10)) Then
                    a(11) = Format(CDate(dr.Item(10)), "MM/dd/yyyy")
                Else
                    a(11) = "-"
                End If

                If IsDate(dr.Item(11)) Then
                    a(12) = Format(CDate(dr.Item(11)), "MM/dd/yyyy")
                Else
                    a(12) = "-"
                End If

                If IsNumeric(dr.Item(12)) Then
                    a(13) = FormatNumber(dr.Item(12))
                Else
                    a(13) = "0"
                End If

                If IsNumeric(dr.Item(13)) Then
                    a(14) = FormatNumber(dr.Item(13))
                Else
                    a(14) = "0"
                End If

                If IsNumeric(dr.Item(14)) Then
                    a(15) = FormatNumber(dr.Item(14))
                Else
                    a(15) = "0"
                End If

                If IsDate(dr.Item(15)) Then
                    a(16) = Format(CDate(dr.Item(15)), "MM/dd/yyyy")
                Else
                    a(16) = "-"
                End If

                If IsDate(dr.Item(16)) Then
                    a(17) = Format(CDate(dr.Item(16)), "MM/dd/yyyy")
                Else
                    a(17) = "-"
                End If

                If IsNumeric(dr.Item(17)) Then
                    a(18) = FormatNumber(dr.Item(17))
                Else
                    a(18) = "0"
                End If

                If IsNumeric(dr.Item(18)) Then
                    a(19) = FormatNumber(dr.Item(18))
                Else
                    a(19) = "0"
                End If

                If IsNumeric(dr.Item(19)) Then
                    a(20) = FormatNumber(dr.Item(19))
                Else
                    a(20) = "0"
                End If

                a(21) = dr.Item(21).ToString()
                a(22) = dr.Item(22).ToString()
                a(23) = dr.Item(23).ToString()

                ' Safe handling of dr.Item(24) with known invalid placeholder dates
                If IsDate(dr.Item(24)) Then
                    Dim tempDate As Date = CDate(dr.Item(24))
                    Dim formattedDate As String = Format(tempDate, "MM/dd/yyyy")
                    If formattedDate = "01/01/1995" OrElse formattedDate = "01/01/1990" OrElse formattedDate = "01/01/1900" Then
                        a(24) = "-"
                    Else
                        a(24) = formattedDate
                    End If
                Else
                    a(24) = "-"
                End If

                a(25) = dr.Item(25).ToString()
                a(26) = dr.Item(26).ToString()

                If cmbSearch.Text = "Equipment Period" Then
                    a(27) = dr.Item(27).ToString()
                Else
                    a(27) = "N/A"
                End If

                If IsDate(dr.Item("date_return_time").ToString) Then
                    Dim tempDate As Date = CDate(dr.Item("date_return_time").ToString)
                    Dim formattedDate As String = Format(tempDate, "MM/dd/yyyy")
                    If formattedDate = "" OrElse formattedDate = "01/01/1990" OrElse formattedDate = "01/01/1900" Then
                        a(28) = "-"
                    Else
                        a(28) = formattedDate
                    End If
                Else
                    a(28) = "-"
                End If
                a(29) = dr.Item("deduction_amt").ToString
                If IsDate(dr.Item("user_update_log").ToString) Then
                    Dim tempDate As Date = CDate(dr.Item("user_update_log").ToString)
                    Dim formattedDate As String = Format(tempDate, "MM/dd/yyyy")
                    If formattedDate = "" OrElse formattedDate = "01/01/1990" OrElse formattedDate = "01/01/1900" Then
                        a(30) = "-"
                    Else
                        a(30) = formattedDate
                    End If
                Else
                    a(30) = "-"
                End If
                If IsDate(dr.Item("DateTimeCreated").ToString) Then
                    Dim tempDate As Date = CDate(dr.Item("DateTimeCreated").ToString)
                    Dim formattedDate As String = Format(tempDate, "MM/dd/yyyy")
                    If formattedDate = "" OrElse formattedDate = "01/01/1990" OrElse formattedDate = "01/01/1900" Then
                        a(31) = "-"
                    Else
                        a(31) = formattedDate
                    End If
                Else
                    a(31) = "-"
                End If

                count1 = count1 + 1
                Dim lvl As New ListViewItem(a)
                lvlAllowance.Items.Add(lvl)
            End While
            Label26.Text = "No. of Data Found: " & count1
            dr.Close()

        Catch ex As Exception
            Dim msg1 As New customMessageBox
            msg1.ErrorMessage(ex)

            'MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description & ex.ToString, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If cmbSearch.Text = "Project Code" Then
            Search_allowance(0)
        ElseIf cmbSearch.Text = "Name" Then
            Search_allowance(1)
        ElseIf cmbSearch.Text = "Adfil Charges Code" Then
            Search_allowance(2)
        ElseIf cmbSearch.Text = "Category" Then
            Search_allowance(3)
        ElseIf cmbSearch.Text = "Sub Category" Then
            Search_allowance(4)
        ElseIf cmbSearch.Text = "Date" Then
            Search_allowance(6)
        ElseIf cmbSearch.Text = "Allowance Monthly Period" Then
            Search_allowance(7)
        ElseIf cmbSearch.Text = "Salary Monthly Period" Then
            Search_allowance(8)
        ElseIf cmbSearch.Text = "Cash Voucher No." Then
            Search_allowance(9)
        ElseIf cmbSearch.Text = "Admin/Operation/Project" Then
            Search_allowance(10)
        ElseIf cmbSearch.Text = "Equipment Period" Then
            Search_allowance(11)

        ElseIf cmbSearch.Text = "Remarks" Then
            Search_allowance(12)
        ElseIf cmbSearch.Text = "Adfil Code - Allowance Period" Then
            Search_allowance(13)
        ElseIf cmbSearch.Text = "Project Code - Allowance Period" Then
            Search_allowance(14)
        End If
        total_amt_search()
    End Sub


    Private Sub cmbSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearch.SelectedIndexChanged
        If cmbSearch.Text = "Project Code" Then
            cmbview_search.Items.Clear()
            txtSearch.Text = ""
            cmbview_search.Text = ""
            txtSearch.Visible = False
            cmbview_search.Visible = True
            cmbview_search.Location = New Point(233, 19)
            btnSearch.Location = New Point(653, 19)
            Button2.Location = New Point(786, 19)
            cmbview_search.Parent = GroupBox1
            cmbview_search.Width = 150
            load_Project_Worksite_Designation(1)
            'DTP_search_Allowance.Location = New Point(txtSearch.Bounds.Left, txtSearch.Bounds.Top)
            DTP_search_Allowance.Location = New Point(385, 19)
            DTP_search_Allowance.Parent = GroupBox1
            DTP_search_Allowance.Visible = True
            DTP_search_Allowance.BringToFront()
            DTP_search_Allowance.Width = 132
            DTP_period_to.Location = New Point(519, 19)
            DTP_period_to.Parent = GroupBox1
            DTP_period_to.Visible = True
            DTP_period_to.BringToFront()
            DTP_period_to.Width = 132
            'DTP_search_Allowance.Visible = False
            'DTP_period_to.Visible = False
        ElseIf cmbSearch.Text = "Name" Then
            DTP_search_Allowance.Visible = False
            DTP_period_to.Visible = False
            txtSearch.Text = ""
            cmbview_search.Text = ""
            txtSearch.Visible = True
            cmbview_search.Visible = False
        ElseIf cmbSearch.Text = "Adfil Charges Code" Then
            DTP_search_Allowance.Visible = True
            DTP_period_to.Visible = True
            txtSearch.Text = ""
            cmbview_search.Text = ""
            txtSearch.Visible = False
            cmbview_search.Visible = True
            cmbview_search.Location = New Point(233, 19)
            btnSearch.Location = New Point(652, 19)
            Button2.Location = New Point(785, 19)
            DTP_search_Allowance.Location = New Point(385, 19)
            DTP_period_to.Location = New Point(519, 19)
            DTP_period_to.Width = 132
            DTP_search_Allowance.Width = 132
            cmbview_search.Width = 150
            DTP_search_Allowance.Parent = GroupBox1
            DTP_period_to.Parent = GroupBox1
            cmbview_search.Parent = GroupBox1
            cmbview_search.Items.Clear()
            load_adfil_charge(3)
        ElseIf cmbSearch.Text = "Category" Then
            DTP_search_Allowance.Visible = False
            DTP_period_to.Visible = False
            txtSearch.Text = ""
            cmbview_search.Text = ""
            txtSearch.Visible = False
            cmbview_search.Visible = True
            cmbview_search.Location = New Point(233, 19)
            cmbview_search.Parent = GroupBox1
            cmbview_search.Items.Clear()
            cmbview_search.Items.Add("ADMIN")
            cmbview_search.Items.Add("PROJECT")
            cmbview_search.Items.Add("EQUIP")
            cmbview_search.Items.Add("OPERATION")
        ElseIf cmbSearch.Text = "Sub Category" Then
            DTP_search_Allowance.Visible = False
            DTP_period_to.Visible = False
            txtSearch.Text = ""
            cmbview_search.Text = ""
            txtSearch.Visible = False
            cmbview_search.Visible = True
            cmbview_search.Location = New Point(233, 19)
            cmbview_search.Parent = GroupBox1
            cmbview_search.Items.Clear()
            cmbview_search.Items.Add("ID/UNIT NUMBER")
            cmbview_search.Items.Add("MNT")
            cmbview_search.Items.Add("FAB")
        ElseIf cmbSearch.Text = "Date" Then
            txtSearch.Visible = False
            cmbview_search.Visible = False
            DTP_search_Allowance.Location = New Point(233, 19)
            DTP_search_Allowance.Parent = GroupBox1
            DTP_search_Allowance.Width = 130
            DTP_search_Allowance.Visible = True
            DTP_period_to.Location = New Point(367, 19)
            DTP_period_to.Parent = GroupBox1
            DTP_period_to.Width = 130
            DTP_period_to.Visible = True
            DTP_search_Allowance.BringToFront()
        ElseIf cmbSearch.Text = "Allowance Monthly Period" Then
            txtSearch.Visible = False
            cmbview_search.Visible = False
            DTP_search_Allowance.Location = New Point(233, 19)
            DTP_search_Allowance.Parent = GroupBox1
            DTP_search_Allowance.Visible = True
            DTP_search_Allowance.BringToFront()
            DTP_search_Allowance.Width = 132
            DTP_period_to.Location = New Point(367, 19)
            DTP_period_to.Parent = GroupBox1
            DTP_period_to.Visible = True
            DTP_period_to.BringToFront()
            DTP_period_to.Width = 132
            btnSearch.Location = New Point(501, 19)
            Button2.Location = New Point(633, 19)
        ElseIf cmbSearch.Text = "Admin/Operation/Project" Then
            txtSearch.Visible = False
            cmbview_search.Visible = False
            DTP_search_Allowance.Location = New Point(txtSearch.Bounds.Left, txtSearch.Bounds.Top)
            DTP_search_Allowance.Parent = GroupBox1
            DTP_search_Allowance.Visible = True
            DTP_search_Allowance.BringToFront()
            DTP_search_Allowance.Width = 132
            DTP_period_to.Location = New Point(367, 19)
            DTP_period_to.Parent = GroupBox1
            DTP_period_to.Visible = True
            DTP_period_to.BringToFront()
            DTP_period_to.Width = 132
            btnSearch.Location = New Point(500, 19)
            Button2.Location = New Point(633, 19)

        ElseIf cmbSearch.Text = "Salary Monthly Period" Then
            txtSearch.Visible = False
            cmbview_search.Visible = False
            DTP_search_Allowance.Location = New Point(txtSearch.Bounds.Left, txtSearch.Bounds.Top)
            DTP_search_Allowance.Parent = GroupBox1
            DTP_search_Allowance.Visible = True
            DTP_search_Allowance.BringToFront()
            DTP_search_Allowance.Width = 132
            DTP_period_to.Location = New Point(367, 19)
            DTP_period_to.Parent = GroupBox1
            DTP_period_to.Visible = True
            DTP_period_to.BringToFront()
            DTP_period_to.Width = 132
        ElseIf cmbSearch.Text = "Cash Voucher No." Then
            DTP_search_Allowance.Visible = False
            DTP_period_to.Visible = False
            txtSearch.Text = ""
            cmbview_search.Text = ""
            txtSearch.Visible = True
            cmbview_search.Visible = False
        ElseIf cmbSearch.Text = "Equipment Period" Then
            cmb_equipment_search.Items.Clear()
            txtSearch.Text = ""
            cmb_equipment_search.Text = ""
            txtSearch.Visible = False
            cmb_equipment_search.Visible = True
            cmb_equipment_search.Location = New Point(233, 19)
            btnSearch.Location = New Point(653, 19)
            Button2.Location = New Point(786, 19)
            cmb_equipment_search.Parent = GroupBox1
            cmb_equipment_search.Width = 150
            load_Project_Worksite_Designation(1)
            DTP_search_Allowance.Location = New Point(385, 19)
            DTP_search_Allowance.Parent = GroupBox1
            DTP_search_Allowance.Visible = True
            DTP_search_Allowance.BringToFront()
            DTP_search_Allowance.Width = 132
            DTP_period_to.Location = New Point(519, 19)
            DTP_period_to.Parent = GroupBox1
            DTP_period_to.Visible = True
            DTP_period_to.BringToFront()
            DTP_period_to.Width = 132
        ElseIf cmbSearch.Text = "Remarks" Then
            'DTP_search_Allowance.Visible = False
            'DTP_period_to.Visible = False
            'txtSearch.Text = ""
            'cmbview_search.Text = ""
            'txtSearch.Visible = True
            'cmbview_search.Visible = False


            cmb_equipment_search.Items.Clear()
            txtSearch.Text = ""
            cmb_equipment_search.Text = ""
            txtSearch.Visible = False
            cmb_equipment_search.Visible = True
            cmb_equipment_search.Location = New Point(233, 19)
            btnSearch.Location = New Point(653, 19)
            Button2.Location = New Point(786, 19)
            cmb_equipment_search.Parent = GroupBox1
            cmb_equipment_search.Width = 150
            load_Project_Worksite_Designation(1)
            DTP_search_Allowance.Location = New Point(385, 19)
            DTP_search_Allowance.Parent = GroupBox1
            DTP_search_Allowance.Visible = True
            DTP_search_Allowance.BringToFront()
            DTP_search_Allowance.Width = 132
            DTP_period_to.Location = New Point(519, 19)
            DTP_period_to.Parent = GroupBox1
            DTP_period_to.Visible = True
            DTP_period_to.BringToFront()
            DTP_period_to.Width = 132

        ElseIf cmbSearch.Text = "Adfil Code - Allowance Period" Then
            DTP_search_Allowance.Visible = True
            DTP_period_to.Visible = True
            txtSearch.Text = ""
            cmbview_search.Text = ""
            txtSearch.Visible = False
            cmbview_search.Visible = True
            cmbview_search.Location = New Point(233, 19)
            btnSearch.Location = New Point(652, 19)
            Button2.Location = New Point(785, 19)
            DTP_search_Allowance.Location = New Point(385, 19)
            DTP_period_to.Location = New Point(519, 19)
            DTP_period_to.Width = 132
            DTP_search_Allowance.Width = 132
            cmbview_search.Width = 150
            DTP_search_Allowance.Parent = GroupBox1
            DTP_period_to.Parent = GroupBox1
            cmbview_search.Parent = GroupBox1
            cmbview_search.Items.Clear()
            load_adfil_charge(3)

        ElseIf cmbSearch.Text = "Project Code - Allowance Period" Then
            cmbview_search.Items.Clear()
            txtSearch.Text = ""
            cmbview_search.Text = ""
            txtSearch.Visible = False
            cmbview_search.Visible = True
            cmbview_search.Location = New Point(233, 19)
            btnSearch.Location = New Point(653, 19)
            Button2.Location = New Point(786, 19)
            cmbview_search.Parent = GroupBox1
            cmbview_search.Width = 150
            load_Project_Worksite_Designation(1)
            'DTP_search_Allowance.Location = New Point(txtSearch.Bounds.Left, txtSearch.Bounds.Top)
            DTP_search_Allowance.Location = New Point(385, 19)
            DTP_search_Allowance.Parent = GroupBox1
            DTP_search_Allowance.Visible = True
            DTP_search_Allowance.BringToFront()
            DTP_search_Allowance.Width = 132
            DTP_period_to.Location = New Point(519, 19)
            DTP_period_to.Parent = GroupBox1
            DTP_period_to.Visible = True
            DTP_period_to.BringToFront()
            DTP_period_to.Width = 132
        End If

    End Sub

    Private Sub txtAllowanceAmtGotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAllowanceAmt.GotFocus
        If txtAllowanceAmt.Text = "0.00" Then
            txtAllowanceAmt.Text = ""
        End If
    End Sub
    Private Sub txtAllowanceAmtLostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAllowanceAmt.LostFocus
        If txtAllowanceAmt.Text = "" Then
            txtAllowanceAmt.Text = "0.00"
        End If
    End Sub

    Private Sub txtAmtRetGotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmtRet.GotFocus
        If txtAmtRet.Text = "0.00" Then
            txtAmtRet.Text = ""
        End If
    End Sub
    Private Sub txtAmtRetLostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmtRet.LostFocus
        If txtAmtRet.Text = "" Then
            txtAmtRet.Text = "0.00"
        End If
    End Sub
    Private Sub txtTotalAmtGotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalAmt.GotFocus
        If txtTotalAmt.Text = "0.00" Then
            txtTotalAmt.Text = ""
        End If
    End Sub
    Private Sub txtTotalAmtLostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalAmt.LostFocus
        If txtTotalAmt.Text = "" Then
            txtTotalAmt.Text = "0.00"
        End If
    End Sub

    ''\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    Private Sub txtAwnceAmtSalaryGotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAwnceAmtSalary.GotFocus
        If txtAwnceAmtSalary.Text = "0.00" Then
            txtAwnceAmtSalary.Text = ""
        End If
    End Sub
    Private Sub txtAwnceAmtSalaryLostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAwnceAmtSalary.LostFocus
        If txtAwnceAmtSalary.Text = "" Then
            txtAwnceAmtSalary.Text = "0.00"
        End If
    End Sub

    Private Sub txtAmtRetSalaryGotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmtRetSalary.GotFocus
        If txtAmtRetSalary.Text = "0.00" Then
            txtAmtRetSalary.Text = ""
        End If
    End Sub
    Private Sub txtAmtRetSalaryLostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmtRetSalary.LostFocus
        If txtAmtRetSalary.Text = "" Then
            txtAmtRetSalary.Text = "0.00"
        End If
    End Sub
    Private Sub txtTotAmtSalaryGotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotAmtSalary.GotFocus
        If txtTotAmtSalary.Text = "0.00" Then
            txtTotAmtSalary.Text = ""
        End If
    End Sub
    Private Sub txtTotAmtSalaryLostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotAmtSalary.LostFocus
        If txtTotAmtSalary.Text = "" Then
            txtTotAmtSalary.Text = "0.00"
        End If
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        cbDateReturnSelection.Enabled = True


        'cmbcategory2.Text = ""
        Dim first_category As String = lvlAllowance.SelectedItems(0).SubItems(4).Text
        If lvlAllowance.SelectedItems.Count >= 0 Then
            txtName.Text = lvlAllowance.SelectedItems(0).SubItems(1).Text
            cmbDesignation.Text = lvlAllowance.SelectedItems(0).SubItems(3).Text
            cmbcategory1.Text = lvlAllowance.SelectedItems(0).SubItems(4).Text
            cmbcategory2.Text = lvlAllowance.SelectedItems(0).SubItems(5).Text
            ''sa daan nga plate
            cmbequip_no.Text = lvlAllowance.SelectedItems(0).SubItems(7).Text
            txtProjName.Text = lvlAllowance.SelectedItems(0).SubItems(8).Text
            'If first_category = "EQUIP" Then
            '    txtProjName.Text = lvlAllowance.SelectedItems(0).SubItems(7).Text
            'Else
            '    txtProjName.Text = lvlAllowance.SelectedItems(0).SubItems(8).Text
            'End If
            txtadfil_code.Text = lvlAllowance.SelectedItems(0).SubItems(10).Text
            txtLocation.Text = lvlAllowance.SelectedItems(0).SubItems(9).Text
            txtVoucher.Text = lvlAllowance.SelectedItems(0).SubItems(6).Text
            DTP_Allowance.Text = lvlAllowance.SelectedItems(0).SubItems(2).Text
            dtpFrom.Text = lvlAllowance.SelectedItems(0).SubItems(11).Text
            dtpTo.Text = lvlAllowance.SelectedItems(0).SubItems(12).Text
            txtAllowanceAmt.Text = lvlAllowance.SelectedItems(0).SubItems(13).Text
            txtAmtRet.Text = lvlAllowance.SelectedItems(0).SubItems(14).Text
            txtTotalAmt.Text = lvlAllowance.SelectedItems(0).SubItems(15).Text
            dtpFromSalary.Text = lvlAllowance.SelectedItems(0).SubItems(16).Text
            dtpToSalary.Text = lvlAllowance.SelectedItems(0).SubItems(17).Text
            txtAwnceAmtSalary.Text = lvlAllowance.SelectedItems(0).SubItems(18).Text
            txtAmtRetSalary.Text = lvlAllowance.SelectedItems(0).SubItems(19).Text
            txtTotAmtSalary.Text = lvlAllowance.SelectedItems(0).SubItems(20).Text
            txtRemarks.Text = lvlAllowance.SelectedItems(0).SubItems(21).Text
            If lvlAllowance.SelectedItems(0).SubItems(24).Text = "-" Then
                cbDateReturnSelection.Checked = False
            Else
                cbDateReturnSelection.Checked = True
                txtReceiveBy.Enabled = True
                txtReturnedBy.Enabled = True

                dtpDateReturned.Text = lvlAllowance.SelectedItems(0).SubItems(24).Text
                txtReceiveBy.Text = lvlAllowance.SelectedItems(0).SubItems(25).Text
                txtReturnedBy.Text = lvlAllowance.SelectedItems(0).SubItems(26).Text
            End If

            btnSave.Focus()
            btnSave.Text = "Update"
            txtAllowanceAmt.Text = txtAllowanceAmt.Text.Replace(",", "")
            txtAmtRet.Text = txtAmtRet.Text.Replace(",", "")
            txtAwnceAmtSalary.Text = txtAwnceAmtSalary.Text.Replace(",", "")
            txtAmtRetSalary.Text = txtAmtRetSalary.Text.Replace(",", "")

        End If
    End Sub
    Public Sub Deletedata_allwancesum()
        ids_for_deleting = lvlAllowance.SelectedItems(0).SubItems(0).Text
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_Allowance"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 29)
            sqlcomm.Parameters.AddWithValue("@sum_Ids", ids_for_deleting)
            sqlcomm.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click


        Dim ex = MessageBox.Show("ARE YOU AN IT-PROGRAMMER?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If ex = MsgBoxResult.Yes Then
            For_Deleting_Verification.ShowDialog()
            'For Each row As ListViewItem In lvlAllowance.Items
            '    If row.Selected = True Then
            '        deleted_to_store_data()
            '        Deletedata_allwancesum()
            '        row.Remove()
            '    End If
            'Next
            'MessageBox.Show("Successfully Deleted...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Public Function get_id_operator(ByVal x As String) As Integer
        Try
            SQ.connection.Open()
            public_query = "SELECT designation_id FROM dbdesignation WHERE designation = '" & x & "'"
            cmd = New SqlCommand(public_query, SQ.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                get_id_operator = dr.Item(0).ToString
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Function


    Private Sub txtadfil_code_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtadfil_code1.SelectedIndexChanged
        txtboxCategory.Text = set_category(txtadfil_code1.Text)
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub txtAmtRet_TextChanged(sender As Object, e As EventArgs) Handles txtAmtRet.TextChanged

    End Sub

    Private Sub txtTotalAmt_Click(sender As Object, e As EventArgs) Handles txtTotalAmt.Click


    End Sub

    Private Sub txtTotalAmt_MouseLeave(sender As Object, e As EventArgs) Handles txtTotalAmt.MouseLeave

    End Sub

    Private Sub cmbProjectcode_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmbcategory3_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtAllowanceAmt_TextChanged(sender As Object, e As EventArgs) Handles txtAllowanceAmt.TextChanged

    End Sub

    Private Sub cmbview_search_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbview_search.SelectedIndexChanged

    End Sub

    Private Sub txtLocation_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtName_TextChanged_1(sender As Object, e As EventArgs) Handles txtName.TextChanged

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
                cmbequip_no.Items.Add(newdr1.Item(0).ToString)
            End While
            newdr1.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSqlcon1.connection.Close()
        End Try
    End Sub
    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click
        MsgBox("This is not working EVER!")
        'designation_form.ShowDialog()
        'designation_form.txt_desig.Focus()
    End Sub

    Private Sub txtName_Leave(sender As Object, e As EventArgs) Handles txtName.Leave
        checkingName_exist_from_HRMS()
        cmbequip_no.Items.Clear()
        If txtName.Text <> "" Then
            Try

                SQ.connection.Open()
                Dim sqlcomm As New SqlCommand
                sqlcomm.Connection = SQ.connection
                sqlcomm.CommandText = "sp_crud_Allowance"
                sqlcomm.CommandType = CommandType.StoredProcedure
                sqlcomm.Parameters.AddWithValue("@n", 1199)
                sqlcomm.Parameters.AddWithValue("@operator2", hrms_person_id)
                dr = sqlcomm.ExecuteReader
                If dr.HasRows = True Then
                    While dr.Read
                        cmbequip_no.Text = dr.Item(0).ToString
                        load_plate_no()
                        'cmbequip_no.Items.Add(dr.Item(0).ToString)
                    End While
                    dr.Close()
                Else
                    cmbequip_no.Text = ""
                    load_plate_no()
                End If
            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                SQ.connection.Close()
            End Try
        End If
        autogen_designation()
        autoGen_EmployeeCategory()
        'plate_no_equip_no()
    End Sub

    Private Sub autoGen_EmployeeCategory()
        Dim employee_category As String = ""
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_Allowance"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 412)
            sqlcomm.Parameters.AddWithValue("@hrms_person_id", hrms_person_id)
            dr = sqlcomm.ExecuteReader

            If dr.HasRows = True Then
                While dr.Read
                    employee_category = dr.Item(2).ToString
                    MsgBox(employee_category)

                End While
                dr.Close()
            Else
            End If
            SQ.connection.Close()
        Catch ex As Exception
            ex.Message().ToString()
        End Try

        If employee_category = "General" Or employee_category = "JQG-2go" Then
            cmbcategory1.Text = "ADMIN"
        ElseIf employee_category = "Plant & Equipment" Then
            cmbcategory1.Text = "EQUIP"
            cmbcategory2.Text = "ID/UNIT NUMBER"
        ElseIf employee_category = "Project-Based" Or employee_category = "Project-Based (local)" Then
            cmbcategory1.Text = "PROJECT"

        End If



    End Sub

    Private Sub cmbProjectcode_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbProjectcode.SelectedIndexChanged

    End Sub

    Private Sub cmbDesignation_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
    Function set_category(ByVal project_name As String) As String
        Dim return_value As String = ""
        Dim has_value As Boolean = False
        For Each item As List(Of String) In list_charge_description
            If project_name.ToUpper.Equals(item(4).ToUpper) Then
                return_value = item(2)
                has_value = True
                Exit For
            End If
        Next
        If has_value = False Then
            For Each item As List(Of String) In list_project_desc
                If project_name.ToUpper.Equals(item(1).ToUpper) Then
                    return_value = "PROJECT CODE"
                    has_value = True
                    Exit For
                End If
            Next
        End If
        If has_value = False Then
            For Each item As List(Of String) In list_equipment_list
                If project_name.ToUpper.Equals(item(4).ToUpper) Then
                    return_value = "EQUIPMENT"
                    has_value = True
                    Exit For
                End If
            Next
        End If
        If has_value = False Then
            For Each item As List(Of String) In list_charge_to
                If project_name.ToUpper.Equals(item(1).ToUpper) Then
                    return_value = item(2)
                    has_value = True
                    Exit For
                End If
            Next
        End If
        If has_value = False Then
            return_value = "N/A"
        End If
        Return return_value
    End Function

    Sub load_charges()
        Dim txt_project_desc As String = "SELECT [proj_id]
                                                  ,[project_desc]
                                                  ,[location]
                                                  ,[Contract_id]
                                                  ,[contract_name]
                                                  ,[project_duration]
                                                  ,[project_engineer]
                                                  ,[contract_amount]
                                                  ,[budgetary_amount]
                                                  ,[actual_amount]
                                              FROM [eus].[dbo].[dbprojectdesc]"


        Dim txt_charge_description As String = "SELECT a.[charge_desc_id]
                                                      ,a.[charge_cat_id]
                                                      ,b.Charge_cat_name
                                                      ,a.[description]
                                                      ,a.[code]
                                                  FROM [supply_db].[dbo].[dbcharge_description] a
                                                  inner join [supply_db].[dbo].[dbCharge_Category] b
                                                 on b.charge_cat_id = a.charge_cat_id"
        'Dim txt_charge_to As String = "SELECT [charge_to_id]
        '                                      ,[charge_to]
        '                                      ,[type_name]
        '                                      ,[charge_desc_id]
        '                                  FROM [supply_db].[dbo].[dbCharge_to]"
        'Dim txt_equipment_list As String = "SELECT [equipListID]
        '                                          ,[equipUnitID]
        '                                          ,[equipCatID]
        '                                          ,[equipTypeID]
        '                                          ,[plate_no]
        '                                          ,[type_of_oil_id]
        '                                          ,[operator_id]
        '                                      FROM [eus].[dbo].[dbequipment_list]"

        'Dim txt_type_of_equipment As String = "select equip_typeOf as equip_type from dbequipment_type a"
        Try
            Dim cmd1 As SqlCommand
            Dim cmd2 As SqlCommand
            Dim cmd3 As SqlCommand
            Dim cmd4 As SqlCommand
            SQ.connection1.Open()

            cmd1 = New SqlCommand(txt_project_desc, SQ.connection1)
            cmd1.Parameters.Clear()
            cmd1.CommandType = CommandType.Text

            cmd2 = New SqlCommand(txt_charge_description, SQ.connection1)
            cmd2.Parameters.Clear()
            cmd2.CommandType = CommandType.Text

            'cmd3 = New SqlCommand(txt_charge_to, SQ.connection1)
            'cmd3.Parameters.Clear()
            'cmd3.CommandType = CommandType.Text

            'cmd4 = New SqlCommand(txt_equipment_list, SQ.connection1)
            'cmd4.Parameters.Clear()
            'cmd4.CommandType = CommandType.Text

            ''''''''''''''''''''''''''''''''''''''''''''''''''
            dr = cmd1.ExecuteReader
            While dr.Read
                Dim items As New List(Of String)
                items.Add(dr(0).ToString)
                items.Add(dr(1).ToString)
                items.Add(dr(2).ToString)
                items.Add(dr(3).ToString)
                items.Add(dr(4).ToString)
                items.Add(dr(5).ToString)
                items.Add(dr(6).ToString)
                items.Add(dr(7).ToString)
                items.Add(dr(8).ToString)
                items.Add(dr(9).ToString)

                list_project_desc.Add(items)
            End While
            dr.Close()
            ''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''
            dr = cmd2.ExecuteReader
            While dr.Read
                Dim items1 As New List(Of String)
                items1.Add(dr(0).ToString)
                items1.Add(dr(1).ToString)
                items1.Add(dr(2).ToString)
                items1.Add(dr(3).ToString)
                items1.Add(dr(4).ToString)

                list_charge_description.Add(items1)
            End While
            dr.Close()
            '''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''
            'dr = cmd3.ExecuteReader
            'While dr.Read
            '    Dim items As New List(Of String)
            '    items.Add(dr(0).ToString)
            '    items.Add(dr(1).ToString)
            '    items.Add(dr(2).ToString)
            '    items.Add(dr(3).ToString)
            '    list_charge_to.Add(items)
            'End While
            'dr.Close()
            '''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''
            'dr = cmd4.ExecuteReader
            'While dr.Read
            '    Dim items As New List(Of String)
            '    items.Add(dr(0).ToString)
            '    items.Add(dr(1).ToString)
            '    items.Add(dr(2).ToString)
            '    items.Add(dr(3).ToString)
            '    items.Add(dr(4).ToString)
            '    items.Add(dr(5).ToString)
            '    items.Add(dr(6).ToString)
            '    list_equipment_list.Add(items)
            'End While
            'dr.Close()
            ''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & ex.StackTrace() & vbCrLf & "Info: " & ex.Message, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection1.Close()
        End Try
    End Sub

    Sub load_project_name()
        Dim project_names As New AutoCompleteStringCollection
        'For Each item As List(Of String) In list_charge_description
        '    project_names.Add(item(4))
        'Next

        For Each item As List(Of String) In list_project_desc
            project_names.Add(item(1))
        Next
        'For Each item As List(Of String) In list_equipment_list
        '    project_names.Add(item(4))
        'Next
        'For Each item As List(Of String) In list_charge_to
        '    project_names.Add(item(1))
        'Next

        txtProjName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtProjName.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtProjName.AutoCompleteCustomSource = project_names
    End Sub

    Sub load_adfilcode()
        Dim project_names As New AutoCompleteStringCollection
        For Each item As List(Of String) In list_charge_description
            project_names.Add(item(4))
        Next

        'For Each item As List(Of String) In list_project_desc
        '    project_names.Add(item(1))
        'Next
        'For Each item As List(Of String) In list_equipment_list
        '    project_names.Add(item(4))
        'Next
        'For Each item As List(Of String) In list_charge_to
        '    project_names.Add(item(1))
        'Next

        txtadfil_code.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtadfil_code.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtadfil_code.AutoCompleteCustomSource = project_names
    End Sub
    Private Sub txtProjName_TextChanged(sender As Object, e As EventArgs) Handles txtProjName.TextChanged
        txtboxCategory.Text = set_category(txtProjName.Text)

        If String.IsNullOrEmpty(txtProjName.Text) Then
            txtadfil_code.Enabled = True
        Else
            txtadfil_code.Enabled = False

        End If

        get_id_proj_location(txtProjName.Text)
    End Sub

    Private Sub PictureBox2_Click_1(sender As Object, e As EventArgs) Handles PictureBox2.Click
        'FCharge_To.cmbTypeofCharge.Text = "PERSONAL"
        'FCharge_To.ShowDialog()
        FPerson_Name.ShowDialog()
    End Sub

    Private Sub txtadfil_code_TextChanged(sender As Object, e As EventArgs) Handles txtadfil_code.TextChanged
        txtboxCategory.Text = set_category(txtadfil_code.Text)
        If String.IsNullOrEmpty(txtadfil_code.Text) Then
            txtProjName.Enabled = True
        Else
            txtProjName.Enabled = False

        End If
    End Sub


    Public Sub view_after_save()
        lvlAllowance.Items.Add("sample1", "sample2", "sample3")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles refresh_category.Click
        If cmbcategory1.Text = "EQUIP" Then
            save_list_name()
        ElseIf cmbcategory1.Text = "ADMIN" Then
            save_name_list(5)
        ElseIf cmbcategory1.Text = "PROJECT" Then
            save_name_list(5)
        ElseIf cmbcategory1.Text = "OPERATION" Then
            save_name_list(5)
        End If
    End Sub

    Private Sub btnSave_KeyDown(sender As Object, e As KeyEventArgs) Handles btnSave.KeyDown

    End Sub

    Private Sub Allowance_sum_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If e.Control And e.KeyCode = Keys.S Then
            btnSave.PerformClick()
        ElseIf e.KeyCode = Keys.Escape Then
            clear_fields(1)
        End If

    End Sub

    Public Sub removed_selection_lenght()
        txtadfil_code.SelectionLength = 0
        txtProjName.SelectionLength = 0
        txtLocation.SelectionLength = 0
        txtName.SelectionLength = 0
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)


    End Sub
    'Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
    '    For i = 0 To lvlAllowance.Items.Count - 1
    '        If lvlAllowance.Items(i).SubItems(1).Text = TextBox1.Text Then
    '            lvlAllowance.Items(i).Selected = True
    '        End If
    '    Next
    'End Sub

    Public Sub check_allwnce_exist()
        Dim amt As Decimal = 1400.0
        Try
            SQ.connection.Open()
            public_query = "select name, alwnce_from,alwnce_to FROM [supply_db].[dbo].[allowance_sum] 
            where name = '" & txtName.Text & "' and '" & dtpFrom.Text & "' between alwnce_from and alwnce_to "
            cmd = New SqlCommand(public_query, SQ.connection)
            dr = cmd.ExecuteReader

            If dr.HasRows Then
                SQ.connection.Close()
                MsgBox("This Person already Inputed in the Period of " + dtpFrom.Text)
                If txtAllowanceAmt.Text >= amt Then
                    MsgBox("The Amount Value Exceeds 1400")
                Else
                    voucher_input.ShowDialog()
                End If
            Else
                SQ.connection.Close()
                'else proceed to save
                If txtAllowanceAmt.Text >= amt Then
                    MsgBox("The Amount Value Exceeds 1400")
                Else
                    save_sum_allawance()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try

    End Sub

    Private Sub lvlAllowance_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvlAllowance.ColumnClick
        ' If current column is not the previously clicked column
        ' Add
        If Not e.Column = sortColumn Then

            ' Set the sort column to the new column
            sortColumn = e.Column

            'Default to ascending sort order
            lvlAllowance.Sorting = SortOrder.Ascending

        Else

            'Flip the sort order
            If lvlAllowance.Sorting = SortOrder.Ascending Then
                lvlAllowance.Sorting = SortOrder.Descending
            Else
                lvlAllowance.Sorting = SortOrder.Ascending
            End If
        End If

        'Set the ListviewItemSorter property to a new ListviewItemComparer object
        Me.lvlAllowance.ListViewItemSorter = New ListViewItemComparer(e.Column, lvlAllowance.Sorting)

        ' Call the sort method to manually sort
        lvlAllowance.Sort()


    End Sub

    Public Sub autogen_designation()
        Try
            SQ.connection.Open()

            'public_query = "select
            '        a.person_id,
            '        a.last_name + ', ' + a.first_name + ISNULL(' ' + LEFT(a.middle_name,1) + '. ','') + ISNULL(a.ext_name,'') as Employee
            '        ,(SELECT
            '                STUFF((
            '	                select 
            '	                ' / ' + aa.position_name
            '	                from hrms_db.dbo.tblPosition aa
            '	                inner join hrms_db.dbo.tblEmployeePosition bb on bb.position_id = aa.position_id
            '	                where bb.status = 'active'
            '	                and bb.employee_id = c.employee_id
            '	                FOR XML PATH(''), TYPE
            '                ).value('.', 'nvarchar(max)'), 1, 2, '')
            '               ) AS Position
            '       from hrms_db.dbo.tblPerson a
            '       inner join hrms_db.dbo.tblEmployee b on b.person_id = a.person_id
            '       left join hrms_db.dbo.tblEmployeeStatus c on c.employee_id = b.employee_id
            '       where (c.status = 'active' or c.status is null)
            '       and (c.status_id <> 4 or c.status_id is null)
            '                and a.person_id = '" & hrms_person_id & "'
            '       order by a.last_name asc"


            public_query = "select
                    a.person_id,
                    a.last_name + ', ' + a.first_name + ISNULL(' ' + LEFT(a.middle_name,1) + '. ','') + ISNULL(a.ext_name,'') as Employee
                    ,(SELECT
                            STUFF((
            	                select 
            	                ' / ' + aa.position_name
            	                from hrms_db.dbo.tblPosition aa
            	                inner join hrms_db.dbo.tblEmployeePosition bb on bb.position_id = aa.position_id
            	                where bb.status = 'active'
            	                and bb.employee_id = c.employee_id
            	                FOR XML PATH(''), TYPE
                            ).value('.', 'nvarchar(max)'), 1, 2, '')
                           ) AS Position
                   from hrms_db.dbo.tblPerson a
                   inner join hrms_db.dbo.tblEmployee b on b.person_id = a.person_id
                   left join hrms_db.dbo.tblEmployeeStatus c on c.employee_id = b.employee_id
                   where (c.status = 'active' or c.status is null)

                            and a.person_id = '" & hrms_person_id & "'
                   order by a.last_name asc"
            cmd = New SqlCommand(public_query, SQ.connection)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                While dr.Read
                    'cmbDesignation.Text = dr.Item(3).ToString
                    cmbDesignation.Text = dr.Item(2).ToString
                End While
                dr.Close()
            Else
            End If
            SQ.connection.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try
    End Sub


    Public Sub total_amt_search()
        'sa allawance 
        Dim sum1 As Decimal
        Dim total As Decimal
        'sa salary wages
        Dim sum2 As Decimal
        Dim total2 As Decimal
        For Each itemsum In lvlAllowance.Items
            sum1 += itemsum.subitems.item(15).text
            sum2 += itemsum.subitems.item(20).text
        Next
        total = Format(Val(sum1), "0.00")
        total_amt.Text = total.ToString("N0")

        total2 = Format(Val(sum2), "0.00")
        total_salarywages.Text = total2.ToString("N0")


    End Sub

    Private Sub Allowance_sum_Resize(sender As Object, e As EventArgs) Handles Me.Resize

    End Sub

    Public Sub input_data_all()
        Dim fname As String = ""
        Dim position As String = ""


    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        'totalsum_of_projectcode()
        'totalsum_of_adfilchargecode()
    End Sub

    Public Sub totalsum_of_adfilchargecode()

        Dim amt As Decimal
        Dim amt2 As String
        For Each item As ListViewItem In lvlAllowance.Items
            Dim value As String = item.SubItems(10).Text
            If Not String.IsNullOrEmpty(value) Then
                amt = amt + item.SubItems(15).Text
                'MsgBox("AdfilChargeCode: " & item.SubItems(10).Text & " " & item.SubItems(15).Text)
            Else
            End If
        Next
        amt2 = amt.ToString("N2")
        total_adfilchargecode = amt2
        'MsgBox(" ADFIL CHARGE CODE " & total_adfilchargecode)
    End Sub

    Public Sub totalsum_of_projectcode()

        Dim amt As Decimal
        Dim amt2 As String

        For Each item As ListViewItem In lvlAllowance.Items
            Dim value As String = item.SubItems(8).Text
            If Not String.IsNullOrEmpty(value) Then
                amt = amt + item.SubItems(15).Text
                'MsgBox("AdfilChargeCode: " & item.SubItems(10).Text & " " & item.SubItems(15).Text)
            Else
            End If
        Next
        amt2 = amt.ToString("N2")
        total_projectcode = amt2
        'MsgBox(" PROJECT CODE " & total_projectcode)
    End Sub


    Public Sub update_without_database()
        Dim id As Integer
        Dim selected_id = lvlAllowance.SelectedItems(0).SubItems(0).Text
        For Each item As ListViewItem In lvlAllowance.Items
            id = item.SubItems(0).Text
            If selected_id = id Then
                item.SubItems(1).Text = txtName.Text
                item.SubItems(3).Text = cmbDesignation.Text
                item.SubItems(4).Text = cmbcategory1.Text
                item.SubItems(5).Text = cmbcategory2.Text
                item.SubItems(7).Text = cmbequip_no.Text
                item.SubItems(8).Text = txtProjName.Text
                item.SubItems(10).Text = txtadfil_code.Text
                item.SubItems(9).Text = txtLocation.Text
                item.SubItems(6).Text = txtVoucher.Text
                item.SubItems(2).Text = DTP_Allowance.Text
                item.SubItems(11).Text = dtpFrom.Text
                item.SubItems(12).Text = dtpTo.Text
                item.SubItems(13).Text = txtAllowanceAmt.Text
                item.SubItems(14).Text = txtAmtRet.Text
                item.SubItems(15).Text = txtTotalAmt.Text
                item.SubItems(16).Text = dtpFromSalary.Text
                item.SubItems(17).Text = dtpToSalary.Text
                item.SubItems(18).Text = txtAwnceAmtSalary.Text
                item.SubItems(19).Text = txtAmtRetSalary.Text
                item.SubItems(20).Text = txtTotAmtSalary.Text
            End If
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ex = MessageBox.Show("Generate with PREVIOUS SUMMARY?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)
        If ex = MsgBoxResult.Yes Then
            GenerateDataForm.ShowDialog()
        ElseIf ex = MsgBoxResult.No Then
            totalsum_of_projectcode()
            totalsum_of_adfilchargecode()
            If lvlAllowance.Items.Count = 0 Then
                MsgBox("NO DATA FOUND!")
            Else
                preview_allwance_report()
            End If
        Else

        End If









    End Sub


    Public Sub preview_allwance_report()
        Dim fromDate As DateTime = DTP_search_Allowance.Value
        Dim toDate As DateTime = DTP_period_to.Value

        Dim resultString As String = $"{fromDate.ToString("MMMM d", CultureInfo.InvariantCulture)}-{toDate.ToString("d, yyyy", CultureInfo.InvariantCulture)}"
        dateperiod.Text = resultString

        Dim allawance_data As New DataTable
        Dim i As Integer = 0
        With allawance_data
            .Columns.Add("Name")
            .Columns.Add("DateStarted")
            .Columns.Add("Designation")
            .Columns.Add("Category")
            .Columns.Add("SubCategory")
            .Columns.Add("CashVoucherNumber")
            .Columns.Add("PlateNo")
            .Columns.Add("ProjectCode")
            .Columns.Add("Location")
            .Columns.Add("AdfilChargeCode")
            .Columns.Add("AllowanceFrom")
            .Columns.Add("AllowanceTo")
            .Columns.Add("AllowanceAmount")
            .Columns.Add("AllowanceReturn")
            .Columns.Add("AllowanceTotal")
            .Columns.Add("SalaryWageFrom")
            .Columns.Add("SalaryWageTo")
            .Columns.Add("SalaryWageAmount")
            .Columns.Add("SalaryWageReturn")
            .Columns.Add("SalaryWageTotal")
        End With
        For i = 0 To lvlAllowance.Items.Count - 1
            allawance_data.Rows.Add(allawance_data.NewRow)
            allawance_data.Rows(i).Item("Name") = lvlAllowance.Items(i).SubItems(1).Text
            allawance_data.Rows(i).Item("DateStarted") = lvlAllowance.Items(i).SubItems(2).Text
            allawance_data.Rows(i).Item("Designation") = lvlAllowance.Items(i).SubItems(3).Text
            allawance_data.Rows(i).Item("Category") = lvlAllowance.Items(i).SubItems(4).Text
            allawance_data.Rows(i).Item("SubCategory") = lvlAllowance.Items(i).SubItems(5).Text
            allawance_data.Rows(i).Item("CashVoucherNumber") = lvlAllowance.Items(i).SubItems(6).Text
            allawance_data.Rows(i).Item("PlateNo") = lvlAllowance.Items(i).SubItems(7).Text
            allawance_data.Rows(i).Item("ProjectCode") = lvlAllowance.Items(i).SubItems(8).Text
            If String.IsNullOrEmpty(allawance_data.Rows(i).Item("ProjectCode").ToString()) Then
                allawance_data.Rows(i).Item("ProjectCode") = lvlAllowance.Items(i).SubItems(10).Text
            End If
            allawance_data.Rows(i).Item("Location") = lvlAllowance.Items(i).SubItems(9).Text
            'allawance_data.Rows(i).Item("AdfilChargeCode") = lvlAllowance.Items(i).SubItems(10).Text
            allawance_data.Rows(i).Item("AllowanceFrom") = lvlAllowance.Items(i).SubItems(11).Text
            allawance_data.Rows(i).Item("AllowanceTo") = lvlAllowance.Items(i).SubItems(12).Text
            allawance_data.Rows(i).Item("AllowanceAmount") = lvlAllowance.Items(i).SubItems(13).Text
            allawance_data.Rows(i).Item("AllowanceReturn") = lvlAllowance.Items(i).SubItems(14).Text
            allawance_data.Rows(i).Item("AllowanceTotal") = lvlAllowance.Items(i).SubItems(15).Text
            allawance_data.Rows(i).Item("SalaryWageFrom") = lvlAllowance.Items(i).SubItems(16).Text
            allawance_data.Rows(i).Item("SalaryWageTo") = lvlAllowance.Items(i).SubItems(17).Text
            allawance_data.Rows(i).Item("SalaryWageAmount") = lvlAllowance.Items(i).SubItems(18).Text
            allawance_data.Rows(i).Item("SalaryWageReturn") = lvlAllowance.Items(i).SubItems(19).Text
            allawance_data.Rows(i).Item("SalaryWageTotal") = lvlAllowance.Items(i).SubItems(20).Text
        Next
        Dim viewEMs As New DataView(allawance_data)
        allawance_report_form.ReportViewer1.LocalReport.DataSources.Item(0).Value = viewEMs
        allawance_report_form.ShowDialog()
        allawance_report_form.Dispose()
    End Sub


    Public Sub deleted_to_store_data()
        Dim selected_id = lvlAllowance.SelectedItems(0).SubItems(0).Text
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_Allowance"
            sqlcomm.CommandType = CommandType.StoredProcedure

            sqlcomm.Parameters.AddWithValue("@n", 388)
            sqlcomm.Parameters.AddWithValue("@allowance_sum_ids", selected_id)
            dr = sqlcomm.ExecuteReader
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub txtAmtRetSalary_TextChanged(sender As Object, e As EventArgs) Handles txtAmtRetSalary.TextChanged

    End Sub

    Private Sub ExportAllToExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportAllToExcelToolStripMenuItem.Click
        SaveFileDialog1.Title = "Save Excel File"
        SaveFileDialog1.Filter = "Excel files (*.xls, *.xlsx)|*.xls;*.xlsx"
        SaveFileDialog1.FilterIndex = 2 ' Default to .xlsx format
        SaveFileDialog1.DefaultExt = ".xlsx"
        SaveFileDialog1.ShowDialog()
        'exit if no file selected
        If SaveFileDialog1.FileName = "" Then
            Exit Sub
        End If
        'create objects to interface to Excel
        Dim xls As New Excel.Application
        Dim book As Excel.Workbook
        Dim sheet As Excel.Worksheet
        'create a workbook and get reference to first worksheet
        xls.Workbooks.Add()
        book = xls.ActiveWorkbook
        sheet = book.ActiveSheet
        'step through rows and columns and copy data to worksheet

        Dim headerRange As Excel.Range = sheet.Range("A1:Y1")
        headerRange.HorizontalAlignment = Excel.Constants.xlCenter
        headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(&H82B1FF))
        Dim dataRange As Excel.Range = sheet.Range("A1:AY" & sheet.Rows.Count)
        dataRange.AutoFilter(1)

        sheet.Cells(1, 1) = "NAME"
        sheet.Cells(1, 2) = "DATE STARTED"
        sheet.Cells(1, 3) = "DESIGNATION"
        sheet.Cells(1, 4) = "CATEGORY"
        sheet.Cells(1, 5) = "SUB CATEGORY"
        sheet.Cells(1, 6) = "CASH VOUCHER NUMBER"
        sheet.Cells(1, 7) = "PLATE NO."
        sheet.Cells(1, 8) = "PROJECT CODE"
        sheet.Cells(1, 9) = "LOCATION"
        sheet.Cells(1, 10) = "ADFIL CHARGE CODE"
        sheet.Cells(1, 11) = "ALLOWANCE FROM"
        sheet.Cells(1, 12) = "ALLOWANCE TO"
        sheet.Cells(1, 13) = "ALLOWANCE AMOUNT"
        sheet.Cells(1, 14) = "ALLOWANCE RETURN"
        sheet.Cells(1, 15) = "DEDUCTION"
        sheet.Cells(1, 16) = "ALLOWANCE TOTAL"
        sheet.Cells(1, 17) = "ALLOWANCE RETURN DATE"
        sheet.Cells(1, 18) = "ALLOWANCE RETURN DATE LOG"
        sheet.Cells(1, 19) = "RETURN BY"
        sheet.Cells(1, 20) = "RECEIVE BY"
        sheet.Cells(1, 21) = "USER LOG INPUT"
        sheet.Cells(1, 22) = "DATE LOG INPUT"
        sheet.Cells(1, 23) = "USER LOG UPDATE"
        sheet.Cells(1, 24) = "UPDATE DATE LOG"
        sheet.Cells(1, 25) = "REMARKS"
        Dim row1 As Integer = 2

        For Each rows As ListViewItem In lvlAllowance.Items
            'If rows.Selected = True Then
            sheet.Cells(row1, 1) = rows.SubItems(1).Text
            sheet.Cells(row1, 2) = DateTime.ParseExact(rows.SubItems(2).Text, "M/d/yyyy", Globalization.CultureInfo.InvariantCulture)
            sheet.Cells(row1, 3) = rows.SubItems(3).Text
            sheet.Cells(row1, 4) = rows.SubItems(4).Text
            sheet.Cells(row1, 5) = rows.SubItems(5).Text
            sheet.Cells(row1, 6) = rows.SubItems(6).Text
            sheet.Cells(row1, 7) = rows.SubItems(7).Text
            sheet.Cells(row1, 8) = rows.SubItems(8).Text
            sheet.Cells(row1, 9) = rows.SubItems(9).Text
            sheet.Cells(row1, 10) = rows.SubItems(10).Text
            sheet.Cells(row1, 11) = DateTime.ParseExact(rows.SubItems(11).Text, "M/d/yyyy", Globalization.CultureInfo.InvariantCulture)
            sheet.Cells(row1, 12) = DateTime.ParseExact(rows.SubItems(12).Text, "M/d/yyyy", Globalization.CultureInfo.InvariantCulture)
            sheet.Cells(row1, 13) = rows.SubItems(13).Text
            sheet.Cells(row1, 14) = rows.SubItems(14).Text

            sheet.Cells(row1, 15) = rows.SubItems(29).Text
            sheet.Cells(row1, 16) = rows.SubItems(15).Text

            If rows.SubItems(24).Text = "-" Then
                sheet.Cells(row1, 17) = "N/A"
            Else
                sheet.Cells(row1, 17) = DateTime.ParseExact(rows.SubItems(24).Text, "M/d/yyyy", Globalization.CultureInfo.InvariantCulture)

            End If

            If rows.SubItems(28).Text = "-" Then
                sheet.Cells(row1, 18) = "N/A"
            Else
                sheet.Cells(row1, 18) = DateTime.ParseExact(rows.SubItems(28).Text, "M/d/yyyy", Globalization.CultureInfo.InvariantCulture)

            End If

            sheet.Cells(row1, 19) = rows.SubItems(26).Text
            sheet.Cells(row1, 20) = rows.SubItems(25).Text

            sheet.Cells(row1, 21) = rows.SubItems(22).Text
            If rows.SubItems(31).Text = "-" Then
                sheet.Cells(row1, 22) = "-"
            Else
                sheet.Cells(row1, 22) = DateTime.ParseExact(rows.SubItems(31).Text, "M/d/yyyy", Globalization.CultureInfo.InvariantCulture)
            End If


            sheet.Cells(row1, 23) = rows.SubItems(23).Text

            If rows.SubItems(30).Text = "-" Then
                sheet.Cells(row1, 24) = "N/A"
            Else
                sheet.Cells(row1, 24) = DateTime.ParseExact(rows.SubItems(30).Text, "M/d/yyyy", Globalization.CultureInfo.InvariantCulture)
            End If

            sheet.Cells(row1, 25) = rows.SubItems(21).Text
            row1 += 1
        Next

        'save the workbook and clean up
        book.SaveAs(SaveFileDialog1.FileName)
        xls.Workbooks.Close()
        xls.Quit()
        releaseObject(sheet)
        releaseObject(book)
        releaseObject(xls)
        MsgBox("EXPORTING DONE!")
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub cbDateReturnSelection_CheckedChanged(sender As Object, e As EventArgs) Handles cbDateReturnSelection.CheckedChanged
        If cbDateReturnSelection.Checked = True Then
            dtpDateReturned.Enabled = True
            txtReceiveBy.Enabled = True
            txtReturnedBy.Enabled = True

        Else
            dtpDateReturned.Enabled = False
            txtReceiveBy.Enabled = False
            txtReturnedBy.Enabled = False
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        checkingName_exist_from_HRMS()

    End Sub

    Public Sub checkingName_exist_from_HRMS()
        hrms_person_id = 0
        Dim selectedName As String = txtName.Text.Trim()
        Dim found As Boolean = False

        For Each pair As KeyValuePair(Of String, String) In nameIDList
            If pair.Key.IndexOf(selectedName, StringComparison.OrdinalIgnoreCase) >= 0 Then
                hrms_person_id = pair.Value
                'MessageBox.Show("The ID for '" & pair.Key & "' is: " & pair.Value)
                found = True
                Exit For
            End If
        Next

        If Not found Then
            MessageBox.Show("can't found ID for that name. PLease contact IT Programmer for Consultation")
        End If
    End Sub

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

    End Sub

    'Private Sub btnSalaryForm_Click(sender As Object, e As EventArgs) Handles btnSalaryForm.Click
    '    FSalaryForm.ShowDialog()


    'End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        If txtAmtRet.Text = "" Or txtAmtRet.Text = "0.00" Then
            MsgBox("way sulod")
        Else
            MsgBox("NAAY sulod")

        End If
    End Sub
End Class