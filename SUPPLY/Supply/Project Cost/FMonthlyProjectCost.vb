Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FMonthlyProjectCost
    Public SQ As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Public dfrom As DateTime = Date.Parse("01-01-2017")
    Public dto As DateTime = Date.Parse(Now)
    Public trd As Threading.Thread
    Dim txtbox As TextBox
    Public Sub loading()
        'Floading.ShowDialog()
    End Sub

    Sub monthly_projectcost(ByVal n As Integer)

        Dim SQ As New SQLcon
        Dim dr As SqlDataReader
        Dim sqlcomm As New SqlCommand
        Dim count As Integer = 0

        Dim new_item_no As Boolean = False
        Dim item_no As String = ""
        DTG_MontlyProjectCost.Rows.Clear()

        Try
            SQ.connection.Open()

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "proc_filterBy"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", n)

            dr = sqlcomm.ExecuteReader

            While dr.Read

                Dim a(20) As String

                a(0) = dr.Item(0).ToString

                Dim projectcode As String = dr.Item(0).ToString

                Dim current1 As Double = FProjectCost.heavy_equipment_Details(projectcode, 0)
                'Dim current2 As Double = FormatNumber(FProjectCost.light_heavy_equipment_Details1(projectcode, "Light Equipment", 21, True, dfrom, dto, 0, 0), 2, , TriState.True)
                'Dim current3 As Double = FormatNumber(FProjectCost.light_exempted_from_eu(projectcode, dfrom, dto), 2, , TriState.True)

                Dim total As Double = FormatNumber(current1, 2, , TriState.True)

                a(1) = FormatNumber((dr.Item(1).ToString + total), 2, , TriState.True)
                a(2) = FormatNumber(dr.Item(2).ToString)
                a(3) = FormatNumber(total)
                a(4) = FormatNumber(dr.Item(3).ToString)
                a(5) = FormatNumber(dr.Item(4).ToString)

                Dim budget_materials_amount As Double = CDbl(dr.Item(5).ToString)
                Dim budget_eqpt_amount As Double = CDbl(dr.Item(6).ToString)
                Dim budget_labor_amount As Double = CDbl(dr.Item(7).ToString)
                Dim budget_misc_amount As Double = CDbl(dr.Item(8).ToString)
                Dim total_budget_amount As Double = budget_materials_amount + budget_eqpt_amount + budget_labor_amount + budget_misc_amount


                Dim val_a_6 As Double
                a(6) = Format(total_budget_amount / CDbl(dr.Item(9).ToString) * 100)
                If a(6) = "NaN" Or a(6) = "Infinity" Then
                    val_a_6 = 0.00
                    a(6) = "0%"
                Else
                    val_a_6 = Format(total_budget_amount / CDbl(dr.Item(9).ToString) * 100)
                    a(6) = Format(total_budget_amount / CDbl(dr.Item(9).ToString) * 100, "0.00") + "%"
                End If


                a(7) = Format((CDbl(dr.Item(5).ToString) / total_budget_amount) * 100)
                If a(7) = "NaN" Or a(7) = "Infinity" Then
                    a(7) = "0%"
                Else
                    a(7) = Format((CDbl(dr.Item(5).ToString) / total_budget_amount) * 100, "0.00") + "%"
                End If

                a(8) = Format((CDbl(dr.Item(6).ToString) / total_budget_amount) * 100)
                If a(8) = "NaN" Or a(8) = "Infinity" Then
                    a(8) = "0%"
                Else
                    a(8) = Format((CDbl(dr.Item(6).ToString) / total_budget_amount) * 100, "0.00") + "%"
                End If

                a(9) = Format((CDbl(dr.Item(7).ToString) / total_budget_amount) * 100)
                If a(9) = "NaN" Or a(9) = "Infinity" Then
                    a(9) = "0%"
                Else
                    a(9) = Format((CDbl(dr.Item(7).ToString) / total_budget_amount) * 100, "0.00") + "%"
                End If

                a(10) = Format((CDbl(dr.Item(8).ToString) / total_budget_amount) * 100)
                If a(10) = "NaN" Or a(10) = "Infinity" Then
                    a(10) = "0%"
                Else
                    a(10) = Format((CDbl(dr.Item(8).ToString) / total_budget_amount) * 100, "0.00") + "%"

                End If

                a(11) = Format(((CDbl(dr.Item(1).ToString) + total) / total_budget_amount) * 100)
                If a(11) = "NaN" Or a(11) = "Infinity" Then
                    a(11) = "0%"
                Else
                    a(11) = Format(((CDbl(dr.Item(1).ToString) + total) / total_budget_amount) * 100, "0.00") + "%"
                End If

                a(12) = Format((CDbl(dr.Item(2).ToString) / budget_materials_amount) * 100)
                If a(12) = "NaN" Or a(12) = "Infinity" Then
                    a(12) = "0%"
                Else
                    a(12) = Format((CDbl(dr.Item(2).ToString) / budget_materials_amount) * 100, "0.00") + "%"

                End If

                a(13) = Format((total / budget_eqpt_amount) * 100)
                If a(13) = "NaN" Or a(13) = "Infinity" Then
                    a(13) = "0%"
                Else
                    a(13) = Format((total / budget_eqpt_amount) * 100, "0.00") + "%"

                End If

                a(14) = Format((CDbl(dr.Item(4).ToString) / budget_labor_amount) * 100)
                If a(14) = "NaN" Or a(14) = "Infinity" Then
                    a(14) = "0%"
                Else
                    a(14) = Format((CDbl(dr.Item(4).ToString) / budget_labor_amount) * 100, "0.00") + "%"
                End If

                a(15) = Format((CDbl(dr.Item(3).ToString) / budget_misc_amount) * 100)
                If a(15) = "NaN" Or a(15) = "Infinity" Then
                    a(15) = "0%"
                Else
                    a(15) = Format((CDbl(dr.Item(3).ToString) / budget_misc_amount) * 100, "0.00") + "%"

                End If


                DTG_MontlyProjectCost.Rows.Add(a)

                If CDbl(a(1)) < CDbl(val_a_6) Then
                    DTG_MontlyProjectCost.Rows(count).DefaultCellStyle.BackColor = Color.Red

                End If
                count = count + 1

            End While


            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

    End Sub
    Public Function function_budget_misc_amount(ByVal x As String) As Double
        Dim SQ1 As New SQLcon
        Dim dr1 As SqlDataReader
        Dim sqlcomm1 As New SqlCommand



        Try
            SQ1.connection.Open()

            sqlcomm1.Connection = SQ1.connection
            sqlcomm1.CommandText = "proc_filterBy"
            sqlcomm1.CommandType = CommandType.StoredProcedure
            sqlcomm1.Parameters.AddWithValue("@n", 9)
            sqlcomm1.Parameters.AddWithValue("@proj_name", x)
            dr1 = sqlcomm1.ExecuteReader

            While dr1.Read
                If x = "" Then
                    function_budget_misc_amount = 0
                Else
                    function_budget_misc_amount = dr1.Item(0).ToString
                End If


            End While
            dr1.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Function
    Public Function function_budget_labor_amount(ByVal x As String) As Double
        Dim SQ1 As New SQLcon
        Dim dr1 As SqlDataReader
        Dim sqlcomm1 As New SqlCommand



        Try
            SQ1.connection.Open()

            sqlcomm1.Connection = SQ1.connection
            sqlcomm1.CommandText = "proc_filterBy"
            sqlcomm1.CommandType = CommandType.StoredProcedure
            sqlcomm1.Parameters.AddWithValue("@n", 8)
            sqlcomm1.Parameters.AddWithValue("@proj_name", x)
            dr1 = sqlcomm1.ExecuteReader

            While dr1.Read
                If x = "" Then
                    function_budget_labor_amount = 0
                Else
                    function_budget_labor_amount = dr1.Item(0).ToString
                End If


            End While
            dr1.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Function
    Public Function function_budget_eqpt_amount(ByVal x As String) As Double
        Dim SQ1 As New SQLcon
        Dim dr1 As SqlDataReader
        Dim sqlcomm1 As New SqlCommand



        Try
            SQ1.connection.Open()

            sqlcomm1.Connection = SQ1.connection
            sqlcomm1.CommandText = "proc_filterBy"
            sqlcomm1.CommandType = CommandType.StoredProcedure
            sqlcomm1.Parameters.AddWithValue("@n", 7)
            sqlcomm1.Parameters.AddWithValue("@proj_name", x)
            dr1 = sqlcomm1.ExecuteReader

            While dr1.Read
                If x = "" Then
                    function_budget_eqpt_amount = 0
                Else
                    function_budget_eqpt_amount = dr1.Item(0).ToString
                End If


            End While
            dr1.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Function
    Public Function function_budget_materials_amount(ByVal x As String) As Double
        Dim SQ1 As New SQLcon
        Dim dr1 As SqlDataReader
        Dim sqlcomm1 As New SqlCommand



        Try
            SQ1.connection.Open()

            sqlcomm1.Connection = SQ1.connection
            sqlcomm1.CommandText = "proc_filterBy"
            sqlcomm1.CommandType = CommandType.StoredProcedure
            sqlcomm1.Parameters.AddWithValue("@n", 6)
            sqlcomm1.Parameters.AddWithValue("@proj_name", x)
            dr1 = sqlcomm1.ExecuteReader

            While dr1.Read
                If x = "" Then
                    function_budget_materials_amount = 0
                Else
                    function_budget_materials_amount = dr1.Item(0).ToString
                End If


            End While
            dr1.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Function




    Private Sub btn_preview_Click(sender As Object, e As EventArgs) Handles btn_preview.Click

        'Dim a(10) As String

        'a(0) = "16-18 EWLRD"
        'a(1) = "39,815,125.39"
        'a(2) = "421,107.00"
        'a(3) = "26,003,564.97"
        'a(4) = "13,056,795.12"
        'a(5) = "333,658.30"

        'Dim list As New ListViewItem(a)
        'ListView1.Items.Add(list)


        'trd = New Threading.Thread(AddressOf loading)
        'trd.Start()
        'trd.IsBackground = True

        monthly_projectcost(4)


        'trd.Abort()
    End Sub
    'Public Function get_total_by_project()
    '    'lvlProjectsDetails.Items.Clear()



    '    trd = New Threading.Thread(AddressOf loading)
    '    trd.Start()
    '    trd.IsBackground = True

    '    Try
    '        SQ.connection1.Open()
    '        cmd = New SqlCommand("proc_FEquipment_Charges_new", SQ.connection1)
    '        cmd.Parameters.Clear()
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.Parameters.AddWithValue("@n", 1)

    '        dr = cmd.ExecuteReader

    '        Dim a(10) As String

    '        While dr.Read

    '            Dim projectname As String = dr.Item("project_desc").ToString

    '            Dim current1 As Double = FormatNumber(FProjectCost.calculate_total_eu_per_project(projectname), 2, , , TriState.True)
    '            Dim current2 As Double = FormatNumber(FProjectCost.light_heavy_equipment_Details1(projectname, "Light Equipment", 21, True, dfrom, dto, 0, 0), 2, , TriState.True)
    '            Dim current3 As Double = FormatNumber(FProjectCost.light_exempted_from_eu(projectname, dfrom, dto), 2, , TriState.True)


    '            Dim total As Double = FormatNumber((current1 + current2 + current3), 2, , TriState.True)


    '            a(3) = FormatNumber((total), 2, , TriState.True)


    '            Dim lvl As New ListViewItem(a)
    '            ListView1.Items.Add(lvl)

    '            ListView1.Refresh()

    '        End While

    '        dr.Close()

    '        trd.Abort()

    '    Catch ex As Exception
    '        MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        SQ.connection1.Close()
    '    End Try

    'End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel.Visible = True
    End Sub
    Public Sub monthlyprojectcost_report()
        Dim dt As New DataTable
        With dt
            .Columns.Add("project_code")
            .Columns.Add("actual_total")
            .Columns.Add("actual_materials")
            .Columns.Add("actual_eqpt")
            .Columns.Add("actual_misc")
            .Columns.Add("actual_labor")
            .Columns.Add("budgetary_total")
            .Columns.Add("budgetary_materials")
            .Columns.Add("budgetary_eqpt")
            .Columns.Add("budgetary_labor")
            .Columns.Add("budgetary_misc")
            .Columns.Add("percentage_total")
            .Columns.Add("percentage_materials")
            .Columns.Add("percentage_eqpt")
            .Columns.Add("percentage_labor")
            .Columns.Add("percentage_misc")
            .Columns.Add("project_accomp")
        End With

        For i As Integer = 0 To DTG_MontlyProjectCost.Rows.Count - 1
            dt.Rows.Add(DTG_MontlyProjectCost.Rows(i).Cells(0).Value, DTG_MontlyProjectCost.Rows(i).Cells(1).Value,
            DTG_MontlyProjectCost.Rows(i).Cells(2).Value, DTG_MontlyProjectCost.Rows(i).Cells(3).Value,
            DTG_MontlyProjectCost.Rows(i).Cells(4).Value, DTG_MontlyProjectCost.Rows(i).Cells(5).Value,
              DTG_MontlyProjectCost.Rows(i).Cells(6).Value, DTG_MontlyProjectCost.Rows(i).Cells(7).Value,
              DTG_MontlyProjectCost.Rows(i).Cells(8).Value, DTG_MontlyProjectCost.Rows(i).Cells(9).Value,
              DTG_MontlyProjectCost.Rows(i).Cells(10).Value, DTG_MontlyProjectCost.Rows(i).Cells(11).Value,
              DTG_MontlyProjectCost.Rows(i).Cells(12).Value, DTG_MontlyProjectCost.Rows(i).Cells(13).Value,
              DTG_MontlyProjectCost.Rows(i).Cells(14).Value, DTG_MontlyProjectCost.Rows(i).Cells(15).Value,
             DTG_MontlyProjectCost.Rows(i).Cells(16).Value)

        Next
        Dim view As New DataView(dt)

        FMonthlyProjectCost_Report.ReportViewer1.LocalReport.DataSources.Item(0).Value = view
        FMonthlyProjectCost_Report.ShowDialog()
        FMonthlyProjectCost_Report.Dispose()

    End Sub

    Private Sub FMonthlyProjectCost_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel.Visible = False
        Lbx_namelist.Visible = False
    End Sub

    Private Sub txt_preparedby_TextChanged(sender As Object, e As EventArgs) Handles txt_preparedby.TextChanged, txt_approvedby.TextChanged
        txtbox = sender
        With Lbx_namelist
            .Location = New System.Drawing.Point(txtbox.Location.X, txtbox.Location.Y + txtbox.Height)
            .Width = txtbox.Width
            .Parent = Panel
            .BringToFront()

            If txtbox.Text = "" Then
                .Visible = False
            Else
                .Visible = True
                FProjectCost.list_box(txtbox, Lbx_namelist)
            End If
        End With
    End Sub
    Private Sub txt_preparedby_GotFocus(sender As Object, e As EventArgs) Handles txt_preparedby.GotFocus, txt_approvedby.GotFocus
        If txt_preparedby.Focused Then
            FProjectCost.textname = txt_preparedby.Name
        ElseIf txt_approvedby.Focused Then
            FProjectCost.textname = txt_approvedby.Name
        End If
    End Sub

    Private Sub btn_proceed_Click(sender As Object, e As EventArgs) Handles btn_proceed.Click
        monthlyprojectcost_report()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Lbx_namelist.SelectedIndexChanged

    End Sub
    Private Sub ListBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles Lbx_namelist.KeyDown
        If e.KeyCode = Keys.Enter Then
            For Each ctr As Control In Panel.Controls
                If ctr.Name = FProjectCost.textname Then
                    ctr.Text = Lbx_namelist.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next
            Lbx_namelist.Visible = False
        End If
    End Sub
    Private Sub Lbx_namelist_DoubleClick(sender As Object, e As EventArgs) Handles Lbx_namelist.DoubleClick
        For Each ctr As Control In Panel.Controls
            If ctr.Name = FProjectCost.textname Then
                ctr.Text = Lbx_namelist.SelectedItem.ToString
                ctr.Focus()
            End If
        Next
        Lbx_namelist.Visible = False
    End Sub

    Private Sub txt_preparedby_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_preparedby.KeyDown, txt_approvedby.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
            With Lbx_namelist
                If .Visible = True Then
                    If .Items.Count > 0 Then
                        .Focus()
                        .SelectedIndex = 0
                    End If
                Else
                End If
            End With
        End If
    End Sub

    '    Private Sub Button2_Click(sender As Object, e As EventArgs)
    '        Dim SQ As New SQLcon
    '        Dim dr As SqlDataReader
    '        Dim sqlcomm As New SqlCommand

    '        Dim new_item_no As Boolean = False
    '        Dim item_no As String = ""
    '        ListView1.Items.Clear()

    '        Try
    '            SQ.connection.Open()

    '            sqlcomm.Connection = SQ.connection
    '            sqlcomm.CommandText = "proc_filterBy"
    '            sqlcomm.CommandType = CommandType.StoredProcedure
    '            sqlcomm.Parameters.AddWithValue("@n", 4)

    '            dr = sqlcomm.ExecuteReader

    '            While dr.Read
    '                Dim a(20) As String

    '                a(0) = dr.Item(0).ToString

    '                Dim projectcode As String = dr.Item(0).ToString

    '                Dim current1 As Double = FProjectCost.heavy_equipment_Details(projectcode, 0)
    '                'Dim current2 As Double = FormatNumber(FProjectCost.light_heavy_equipment_Details1(projectcode, "Light Equipment", 21, True, dfrom, dto, 0, 0), 2, , TriState.True)
    '                'Dim current3 As Double = FormatNumber(FProjectCost.light_exempted_from_eu(projectcode, dfrom, dto), 2, , TriState.True)

    '                Dim total As Double = FormatNumber(current1, 2, , TriState.True)

    '                a(1) = FormatNumber((dr.Item(1).ToString + total), 2, , TriState.True)
    '                a(2) = FormatNumber(dr.Item(2).ToString)
    '                a(3) = FormatNumber(total)

    '                a(4) = FormatNumber(dr.Item(3).ToString)
    '                a(5) = FormatNumber(dr.Item(4).ToString)

    '                Dim budget_materials_amount As Double = CDbl(dr.Item(5).ToString)
    '                Dim budget_eqpt_amount As Double = CDbl(dr.Item(6).ToString)
    '                Dim budget_labor_amount As Double = CDbl(dr.Item(7).ToString)
    '                Dim budget_misc_amount As Double = CDbl(dr.Item(8).ToString)
    '                Dim total_budget_amount As Double = budget_materials_amount + budget_eqpt_amount + budget_labor_amount + budget_misc_amount

    '                a(6) = Format(total_budget_amount / CDbl(dr.Item(9).ToString) * 100, "0.00")
    '                If a(6) = "NaN" Or a(6) = "Infinity" Then
    '                    a(6) = 0
    '                End If


    '                a(7) = Format((CDbl(dr.Item(5).ToString) / total_budget_amount) * 100, "0.00")
    '                If a(7) = "NaN" Or a(7) = "Infinity" Then
    '                    a(7) = 0
    '                End If

    '                a(8) = Format((CDbl(dr.Item(6).ToString) / total_budget_amount) * 100, "0.00")
    '                If a(8) = "NaN" Or a(8) = "Infinity" Then
    '                    a(8) = 0
    '                End If

    '                a(9) = Format((CDbl(dr.Item(7).ToString) / total_budget_amount) * 100, "0.00")
    '                If a(9) = "NaN" Or a(9) = "Infinity" Then
    '                    a(9) = 0
    '                End If

    '                a(10) = Format((CDbl(dr.Item(8).ToString) / total_budget_amount) * 100, "0.00")
    '                If a(10) = "NaN" Or a(10) = "Infinity" Then
    '                    a(10) = 0
    '                End If

    '                a(11) = Format(((CDbl(dr.Item(1).ToString) + total) / total_budget_amount) * 100, "0.00")
    '                If a(11) = "NaN" Or a(11) = "Infinity" Then
    '                    a(11) = 0
    '                End If

    '                a(12) = Format((CDbl(dr.Item(2).ToString) / budget_materials_amount) * 100, "0.00")
    '                If a(12) = "NaN" Or a(12) = "Infinity" Then
    '                    a(12) = 0
    '                End If

    '                a(13) = Format((total / budget_eqpt_amount) * 100, "0.00")
    '                If a(13) = "NaN" Or a(13) = "Infinity" Then
    '                    a(13) = 0
    '                End If

    '                a(14) = Format((CDbl(dr.Item(4).ToString) / budget_labor_amount) * 100, "0.00")
    '                If a(14) = "NaN" Or a(14) = "Infinity" Then
    '                    a(14) = 0
    '                End If

    '                a(15) = Format((CDbl(dr.Item(3).ToString) / budget_misc_amount) * 100, "0.00")
    '                If a(15) = "NaN" Or a(15) = "Infinity" Then
    '                    a(15) = 0
    '                End If

    '                'Dim lvl As New ListViewItem(a)
    '                'ListView1.Items.Add(lvl)
    '                'ListView1.Refresh()
    '                DTG_MontlyProjectCost.Rows.Add(a)
    '            End While
    '            dr.Close()

    '        Catch ex As Exception
    '            'MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Finally
    '            SQ.connection.Close()
    '        End Try
    '    End Sub
End Class