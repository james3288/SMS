Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FIncome_statement
    Public SQ As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Public plateNo As String = ""
    Public docs_title As String = ""
    Public DateRangeTitle As String = ""
    Public monthArray(11) As String
    Public monthArrayOperation(11) As Decimal
    Private Sub FIncome_statement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FSummary_of_AcquiredEquipment.view_category(cmb_category)
    End Sub
    Public Sub load_equipType(cbox As ComboBox, cbox_cat As String)
        cbox.Items.Clear()
        Dim sqL As New SQLcon
        Dim sqlcommand As New SqlCommand
        Dim dr As SqlDataReader
        Try
            sqL.connection.Open()
            sqlcommand.Connection = sqL.connection
            sqlcommand.CommandText = "proc_equipment_monitoring"
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.Parameters.AddWithValue("@n", 14)
            sqlcommand.Parameters.AddWithValue("@eq_cat", cbox_cat)
            sqlcommand.CommandTimeout = 0
            dr = sqlcommand.ExecuteReader
            While dr.Read
                cbox.Items.Add(dr.Item(0).ToString)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqL.connection.Close()
        End Try
    End Sub
    Public Sub view_income_statement(cmbox As String)
        DataGridView1.Rows.Clear()
        Dim cmd As New SqlCommand
        Dim a(20) As String
        Try
            SQ.connection.Open()
            cmd.Connection = SQ.connection
            cmd.CommandText = "proc_equipment_monitoring"
            'cmd.Parameters.Clear()
            'cmd.Parameters.Add("@n", SqlDbType.Int)
            'cmd.Parameters("@n").Value = 10
            'cmd.Parameters.Add("@eq_type", SqlDbType.NVarChar)
            'cmd.Parameters("@eq_type").Value = cmb_equiptype.Text
            'cmd.Parameters.Add("@dateto", SqlDbType.DateTime)
            'cmd.Parameters("@dateto").Value = Date.Parse(eu_dateto)
            cmd.CommandType = CommandType.StoredProcedure
            If cmbox = "All Type" Then
                cmd.Parameters.AddWithValue("@n", 12)
            Else
                cmd.Parameters.AddWithValue("@n", 10)
                cmd.Parameters.AddWithValue("@eq_type", cmb_equiptype.Text)
            End If

            cmd.Parameters.AddWithValue("@datefrom", Date.Parse(DateTimePicker1.Text))
            cmd.Parameters.AddWithValue("@dateto", Date.Parse(DateTimePicker2.Text))
            cmd.Parameters.AddWithValue("@eq_cat", cmb_category.Text)

            cmd.CommandTimeout = 0
            dr = cmd.ExecuteReader
            While dr.Read
                If cmb_category.Text = "Heavy Equipment" Then
                    a(0) = "Construction Equipment"
                Else
                    a(0) = cmb_category.Text
                End If
                a(1) = dr.Item(0).ToString

                If cmbox = "All Type" Then
                    'a(2) = dr.Item(1).ToString
                    a(3) = dr.Item(1).ToString
                    a(4) = dr.Item(2).ToString
                    a(5) = dr.Item(3).ToString
                    a(6) = dr.Item(4).ToString
                    a(7) = dr.Item(5).ToString
                    a(8) = dr.Item(6).ToString
                    a(9) = dr.Item(7).ToString
                    a(19) = dr.Item(8).ToString
                    a(11) = dr.Item(9).ToString
                    a(12) = dr.Item(10).ToString
                    a(13) = dr.Item(11).ToString
                    a(14) = dr.Item(12).ToString
                Else
                    a(2) = dr.Item(1).ToString
                    a(3) = dr.Item(2).ToString
                    a(4) = dr.Item(3).ToString
                    a(5) = dr.Item(4).ToString
                    a(6) = dr.Item(5).ToString
                    a(7) = dr.Item(6).ToString
                    a(8) = dr.Item(7).ToString
                    a(9) = dr.Item(8).ToString
                    a(10) = dr.Item(9).ToString
                    a(11) = dr.Item(10).ToString
                    a(12) = dr.Item(11).ToString
                    a(13) = dr.Item(12).ToString
                    a(14) = dr.Item(13).ToString
                    a(15) = dr.Item(14).ToString
                    a(16) = dr.Item(15).ToString
                    a(17) = dr.Item(16).ToString
                End If
                DataGridView1.Rows.Add(a)

            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub cmb_search_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_search.SelectedIndexChanged
        If cmb_category.Text = "" Then
            MessageBox.Show("Pls. select 1 category.", "Supply Info.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If cmb_search.Text = "All Type" Then
                cmb_equiptype.Enabled = False
                'cmb_equiptype.Visible = False
                'Label1.Text = "Date From:"
                'Label2.Text = "Date To:"
                'With DateTimePicker2
                '    .Location = New Point(cmb_equiptype.Bounds.Left, cmb_equiptype.Bounds.Bottom - 25)
                '    .Width = cmb_equiptype.Width
                '    .Parent = Panel3
                '    .BringToFront()
                '    .Visible = True
                'End With
            Else
                'Label1.Text = "Date:"
                'Label2.Text = "Equipment Type:"
                'cmb_equiptype.Visible = True
                'DateTimePicker2.Visible = False
                cmb_equiptype.Enabled = True
                load_equipType(cmb_equiptype, cmb_category.Text)
            End If
            Panel3.Visible = True
            DateTimePicker1.Visible = True
            ComboBox1.Visible = False
            ComboBox1.Text = "Date Aquired"
        End If
    End Sub

    Private Sub btn_viewReport_Click(sender As Object, e As EventArgs)
        'If Panel3.Visible = True Then
        '    Panel3.Visible = False
        'End If

        'If cmb_search.Text = "All Type" Then
        '    view_report_All_Type()

        'ElseIf cmb_search.Text = "Equipment Type" Then
        '    view_report_TypeOfEquip()

        'End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cmb_equiptype.Text = "" And cmb_search.Text = "Equipment Type" Then
            MessageBox.Show("Pls. select Equipment Type to proceed.", "Supply Info.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else

            view_income_statement(cmb_search.Text)
            For Each row As DataGridViewRow In DataGridView1.Rows
                row.Selected = True
            Next
            Panel3.Visible = False
        End If
    End Sub

    Private Sub Panel3_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel3.MouseDown
        If e.Button = MouseButtons.Left Then
            drag = True
            mousex = e.X
            mousey = e.Y
        End If
    End Sub

    Private Sub Panel3_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel3.MouseMove
        If drag Then
            Dim temp As Point = New Point()

            temp.X = Panel3.Location.X + (e.X - mousex)
            temp.Y = Panel3.Location.Y + (e.Y - mousey)
            Panel3.Location = temp
            temp = Nothing
        End If
    End Sub

    Private Sub Panel3_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel3.MouseUp
        If e.Button = MouseButtons.Left Then
            drag = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel3.Visible = False
    End Sub

    Public Sub view_report_All_Type()

        Dim dt As New DataTable

        With dt
            .Columns.Add("Category")
            .Columns.Add("Type_of_Equipment")
            .Columns.Add("Equipment_Plate_No")
            .Columns.Add("Rental_Revenue")
            .Columns.Add("Repair")
            .Columns.Add("Maintenance")
            .Columns.Add("Fuel")
            .Columns.Add("Tires")
            .Columns.Add("Allowances")
            .Columns.Add("Salary_wages")
            .Columns.Add("Depreciation_Expense")
            .Columns.Add("Miscellaneous_Expense")
            .Columns.Add("Total_Cost")
            .Columns.Add("Net_Revenue")
            .Columns.Add("Net_Revenue_Without")
            .Columns.Add("Equipment_Age")
            .Columns.Add("Equipment_Brand")
        End With

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            dt.Rows.Add(DataGridView1.Rows(i).Cells(0).Value, DataGridView1.Rows(i).Cells(1).Value,
            DataGridView1.Rows(i).Cells(2).Value, DataGridView1.Rows(i).Cells(4).Value,
            DataGridView1.Rows(i).Cells(5).Value, DataGridView1.Rows(i).Cells(6).Value,
            DataGridView1.Rows(i).Cells(7).Value, DataGridView1.Rows(i).Cells(8).Value,
            DataGridView1.Rows(i).Cells(9).Value, DataGridView1.Rows(i).Cells(10).Value,
            DataGridView1.Rows(i).Cells(11).Value, DataGridView1.Rows(i).Cells(12).Value,
            DataGridView1.Rows(i).Cells(13).Value, DataGridView1.Rows(i).Cells(14).Value,
            DataGridView1.Rows(i).Cells(15).Value, DataGridView1.Rows(i).Cells(16).Value,
            DataGridView1.Rows(i).Cells(17).Value)
        Next
        'For Each item As ListViewItem In Me.ListView1.Items
        'Next

        Dim view As New DataView(dt)

        FAll_Type.ReportViewer1.LocalReport.DataSources.Item(0).Value = view
        FAll_Type.ShowDialog()
        FAll_Type.Dispose()

    End Sub

    Public Sub view_report_TypeOfEquip()


        Dim dt As New DataTable

        With dt
            .Columns.Add("Category")
            .Columns.Add("Type_of_Equipment")
            .Columns.Add("Equipment_Plate_No")
            .Columns.Add("Rental_Revenue")
            .Columns.Add("Repair")
            .Columns.Add("Maintenance")
            .Columns.Add("Fuel")
            .Columns.Add("Tires")
            .Columns.Add("Allowances")
            .Columns.Add("Salary_wages")
            .Columns.Add("Depreciation_Expense")
            .Columns.Add("Miscellaneous_Expense")
            .Columns.Add("Total_Cost")
            .Columns.Add("Net_Revenue")
            .Columns.Add("Net_Revenue_Without")
            .Columns.Add("Equipment_Age")
            .Columns.Add("Equipment_Brand")
        End With

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            dt.Rows.Add(
                DataGridView1.Rows(i).Cells(0).Value,
                DataGridView1.Rows(i).Cells(1).Value,
                DataGridView1.Rows(i).Cells(2).Value,
                DataGridView1.Rows(i).Cells(4).Value,
                DataGridView1.Rows(i).Cells(5).Value,
                DataGridView1.Rows(i).Cells(6).Value,
                DataGridView1.Rows(i).Cells(7).Value,
                DataGridView1.Rows(i).Cells(8).Value,
                DataGridView1.Rows(i).Cells(9).Value,
                DataGridView1.Rows(i).Cells(10).Value,
                DataGridView1.Rows(i).Cells(11).Value,
                DataGridView1.Rows(i).Cells(12).Value,
                DataGridView1.Rows(i).Cells(13).Value,
                DataGridView1.Rows(i).Cells(14).Value,
                DataGridView1.Rows(i).Cells(15).Value,
                DataGridView1.Rows(i).Cells(16).Value,
                DataGridView1.Rows(i).Cells(17).Value)
        Next


        'For Each item As ListViewItem In Me.ListView1.Items
        'Next

        Dim view As New DataView(dt)

        FEquipMon_TypeOfEquip.ReportViewer1.LocalReport.DataSources.Item(0).Value = view
        FEquipMon_TypeOfEquip.ShowDialog()
        FEquipMon_TypeOfEquip.Dispose()

    End Sub

    Private Sub cmb_category_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_category.SelectedIndexChanged
        If Panel3.Visible = True Then
            load_equipType(cmb_equiptype, cmb_category.Text)
        End If
    End Sub

    Private Sub PrintArrivalEquipmentRentalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintArrivalEquipmentRentalToolStripMenuItem.Click

        Dim dt As New DataTable

        With dt
            .Columns.Add("Category")
            .Columns.Add("Type_of_Equipment")
            .Columns.Add("Total_EU_RunHours")
            .Columns.Add("Rental_Revenue")
            .Columns.Add("Repair")
            .Columns.Add("Maintenance")
            .Columns.Add("Fuel")
            .Columns.Add("Tires")
            .Columns.Add("Allowances")
            .Columns.Add("Salary_wages")
            .Columns.Add("Depreciation_Expense")
            .Columns.Add("Miscellaneous_Expense")
            .Columns.Add("Total_Cost")
            .Columns.Add("Net_Revenue")
            .Columns.Add("Equipment_Age")
            .Columns.Add("Equipment_Brand")
            .Columns.Add("Equipment_ID")
            .Columns.Add("Net_Revenue_Without")

        End With

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            dt.Rows.Add(
            DataGridView1.Rows(i).Cells(0).Value,
            DataGridView1.Rows(i).Cells(1).Value,
            DataGridView1.Rows(i).Cells(3).Value,
            DataGridView1.Rows(i).Cells(4).Value,
            DataGridView1.Rows(i).Cells(5).Value,
            DataGridView1.Rows(i).Cells(6).Value,
            DataGridView1.Rows(i).Cells(7).Value,
            DataGridView1.Rows(i).Cells(8).Value,
            DataGridView1.Rows(i).Cells(9).Value,
            DataGridView1.Rows(i).Cells(10).Value,
            DataGridView1.Rows(i).Cells(11).Value,
            DataGridView1.Rows(i).Cells(12).Value,
            DataGridView1.Rows(i).Cells(13).Value,
            DataGridView1.Rows(i).Cells(14).Value,
            DataGridView1.Rows(i).Cells(16).Value,
            DataGridView1.Rows(i).Cells(17).Value,
            DataGridView1.Rows(i).Cells(2).Value,
            DataGridView1.Rows(i).Cells(15).Value)
        Next

        'For Each item As ListViewItem In Me.ListView1.Items
        'Next

        Dim view As New DataView(dt)

        FArrival_Equip_Rental_Report.ReportViewer1.LocalReport.DataSources.Item(0).Value = view
        FArrival_Equip_Rental_Report.ShowDialog()
        FArrival_Equip_Rental_Report.Dispose()
    End Sub

    Private Sub PrintGeneralEquipmentRentalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintGeneralEquipmentRentalToolStripMenuItem.Click
        If Panel3.Visible = True Then
            Panel3.Visible = False
        End If

        If cmb_search.Text = "All Type" Then
            view_report_All_Type()

        ElseIf cmb_search.Text = "Equipment Type" Then
            view_report_TypeOfEquip()
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub cmb_equiptype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_equiptype.SelectedIndexChanged

    End Sub

    Private Sub PrintMonthlyRevenueReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintMonthlyRevenueReportToolStripMenuItem.Click
        For Each row As DataGridViewRow In DataGridView1.SelectedRows
            Dim cellValue As String = row.Cells(2).Value.ToString()
            plateNo = cellValue
        Next
        'MsgBox(plateNo)
        'MsgBox(cmb_category.Text)
        'MsgBox(cmb_search.Text)
        'MsgBox(DateTimePicker1.Text + DateTimePicker2.Text)
        Panel6.Visible = True
        Panel6.Location = New Point(495, 107)
        Label11.Text = "equipment selected revenue"



    End Sub

    Private Sub get_customer_rental_revenue()
        DataGridView2.Rows.Clear()
        Dim cmd As New SqlCommand
        Dim a(20) As String
        Try
            SQ.connection.Open()
            cmd.Connection = SQ.connection
            cmd.CommandText = "proc_equipment_monitoring"
            cmd.CommandType = CommandType.StoredProcedure
            If cmb_search.Text = "All Type" Then
                'cmd.Parameters.AddWithValue("@n", 12)
            Else
                cmd.Parameters.AddWithValue("@n", 118)
                cmd.Parameters.AddWithValue("@datefrom", Date.Parse(DateTimePicker1.Text))
                cmd.Parameters.AddWithValue("@dateto", Date.Parse(DateTimePicker2.Text))
                cmd.Parameters.AddWithValue("@eq_cat", cmb_category.Text)
                cmd.Parameters.AddWithValue("eq_type", cmb_equiptype.Text)
                cmd.Parameters.AddWithValue("@plate_no", plateNo)
            End If

            cmd.CommandTimeout = 0
            dr = cmd.ExecuteReader
            While dr.Read
                a(0) = dr.Item(0).ToString
                a(1) = dr.Item(4).ToString
                a(2) = dr.Item(5).ToString
                a(3) = dr.Item(6).ToString
                a(4) = dr.Item(3).ToString
                DataGridView2.Rows.Add(a)

            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub


    Private Sub get_customer_rental_revenue_new1()
        DataGridView4.Rows.Clear()
        Dim cmd As New SqlCommand
        Dim a(20) As String
        Try
            SQ.connection.Open()
            cmd.Connection = SQ.connection
            cmd.CommandText = "proc_equipment_monitoring"
            cmd.CommandType = CommandType.StoredProcedure
            If cmb_search.Text = "All Type" Then
                'cmd.Parameters.AddWithValue("@n", 12)
            Else
                cmd.Parameters.AddWithValue("@n", 12222)
                cmd.Parameters.AddWithValue("@datefrom2", Date.Parse(DateTimePicker1.Text))
                cmd.Parameters.AddWithValue("@dateto2", Date.Parse(DateTimePicker2.Text))
                cmd.Parameters.AddWithValue("@eq_cat2", cmb_category.Text)
                cmd.Parameters.AddWithValue("eq_type2", cmb_equiptype.Text)
                'cmd.Parameters.AddWithValue("@plate_no", plateNo)
            End If

            cmd.CommandTimeout = 0
            dr = cmd.ExecuteReader
            While dr.Read
                a(0) = dr.Item(0).ToString
                a(1) = dr.Item(1).ToString
                a(2) = dr.Item(2).ToString
                a(3) = dr.Item(3).ToString
                a(4) = dr.Item(4).ToString
                a(5) = dr.Item(5).ToString
                a(6) = If(IsDBNull(dr.Item(6)), "0", dr.Item(6).ToString) ' Check for NULL and set to "0" if NULL
                a(7) = If(IsDBNull(dr.Item(7)), "0", dr.Item(7).ToString) ' Check for NULL and set to "0" if NULL
                a(8) = If(IsDBNull(dr.Item(8)), "0", dr.Item(8).ToString) ' Check for NULL and set to "0" if NULL
                DataGridView4.Rows.Add(a)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub get_customer_rental_revenue_quarterly()
        DataGridView2.Rows.Clear()
        Dim cmd As New SqlCommand
        Dim a(20) As String
        Try
            SQ.connection.Open()
            cmd.Connection = SQ.connection
            cmd.CommandText = "proc_equipment_monitoring"
            cmd.CommandType = CommandType.StoredProcedure
            If cmb_search.Text = "All Type" Then
                'cmd.Parameters.AddWithValue("@n", 12)
            Else
                cmd.Parameters.AddWithValue("@n", 119)
                cmd.Parameters.AddWithValue("@datefrom", Date.Parse(DateTimePicker1.Text))
                cmd.Parameters.AddWithValue("@dateto", Date.Parse(DateTimePicker2.Text))
                cmd.Parameters.AddWithValue("@eq_cat", cmb_category.Text)
                cmd.Parameters.AddWithValue("@eq_type", cmb_equiptype.Text)
            End If

            cmd.CommandTimeout = 0
            dr = cmd.ExecuteReader
            While dr.Read
                a(0) = dr.Item(0).ToString
                a(1) = dr.Item(4).ToString
                a(2) = dr.Item(5).ToString
                a(3) = dr.Item(6).ToString
                a(4) = dr.Item(3).ToString
                DataGridView2.Rows.Add(a)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub


    Private Sub get_customer_rental_for_monthly_income_statement()
        DataGridView2.Rows.Clear()
        Dim cmd As New SqlCommand
        Dim a(20) As String
        Try
            SQ.connection.Open()
            cmd.Connection = SQ.connection
            cmd.CommandText = "proc_equipment_monitoring"
            cmd.CommandType = CommandType.StoredProcedure
            If cmb_search.Text = "All Type" Then
                'cmd.Parameters.AddWithValue("@n", 12)
            Else
                cmd.Parameters.AddWithValue("@n", 119)
                cmd.Parameters.AddWithValue("@datefrom", Date.Parse(DateTimePicker1.Text))
                cmd.Parameters.AddWithValue("@dateto", Date.Parse(DateTimePicker2.Text))
                cmd.Parameters.AddWithValue("@eq_cat", cmb_category.Text)
                cmd.Parameters.AddWithValue("@eq_type", cmb_equiptype.Text)
            End If

            cmd.CommandTimeout = 0
            dr = cmd.ExecuteReader
            While dr.Read
                a(0) = dr.Item(0).ToString
                a(1) = dr.Item(4).ToString
                a(2) = dr.Item(5).ToString
                a(3) = dr.Item(6).ToString
                a(4) = dr.Item(3).ToString
                DataGridView2.Rows.Add(a)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub get_customer_rental_for_monthly_income_statement2()
        DataGridView3.Rows.Clear()
        Dim cmd As New SqlCommand
        Dim a(14) As String
        Try
            SQ.connection.Open()
            cmd.Connection = SQ.connection
            cmd.CommandText = "proc_equipment_monitoring2"
            cmd.CommandType = CommandType.StoredProcedure
            If cmb_search.Text = "All Type" Then
                'cmd.Parameters.AddWithValue("@n", 12)
            Else
                cmd.Parameters.AddWithValue("@n", 1)
                cmd.Parameters.AddWithValue("@datefrom2", Date.Parse(DateTimePicker1.Text))
                cmd.Parameters.AddWithValue("@dateto2", Date.Parse(DateTimePicker2.Text))
                cmd.Parameters.AddWithValue("@eq_cat2", cmb_category.Text)
                cmd.Parameters.AddWithValue("@eq_type2", cmb_equiptype.Text)
            End If

            cmd.CommandTimeout = 0
            dr = cmd.ExecuteReader
            While dr.Read
                a(0) = dr.Item(1).ToString
                a(1) = dr.Item(0).ToString
                a(2) = dr.Item(2).ToString
                a(3) = dr.Item(3).ToString
                a(4) = dr.Item(4).ToString
                a(5) = dr.Item(5).ToString
                a(6) = dr.Item(6).ToString
                a(7) = dr.Item(7).ToString
                a(8) = dr.Item(8).ToString
                a(9) = dr.Item(9).ToString
                a(10) = dr.Item(10).ToString
                a(11) = dr.Item(11).ToString
                a(12) = dr.Item(12).ToString
                a(13) = dr.Item(13).ToString
                DataGridView3.Rows.Add(a)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Public Sub get_culmulative_statement_with_months()
        DataGridView5.Rows.Clear()
        Dim cmd As New SqlCommand
        Dim a(26) As String
        Try
            SQ.connection.Open()
            cmd.Connection = SQ.connection
            cmd.CommandText = "proc_equipment_monitoring2"
            cmd.CommandType = CommandType.StoredProcedure
            If cmb_search.Text = "All Type" Then
                'cmd.Parameters.AddWithValue("@n", 12)
            Else
                cmd.Parameters.AddWithValue("@n", 3)
                cmd.Parameters.AddWithValue("@datefrom2", Date.Parse(DateTimePicker1.Text))
                cmd.Parameters.AddWithValue("@dateto2", Date.Parse(DateTimePicker2.Text))
                cmd.Parameters.AddWithValue("@eq_cat2", cmb_category.Text)
                cmd.Parameters.AddWithValue("@eq_type2", cmb_equiptype.Text)
            End If

            cmd.CommandTimeout = 0
            dr = cmd.ExecuteReader
            While dr.Read
                a(0) = dr.Item(1).ToString
                a(1) = dr.Item(2).ToString
                a(2) = dr.Item(3).ToString
                a(3) = dr.Item(4).ToString
                a(4) = dr.Item(6).ToString
                a(5) = dr.Item(7).ToString
                a(6) = dr.Item(8).ToString
                a(7) = dr.Item(9).ToString
                a(8) = dr.Item(10).ToString
                a(9) = dr.Item(11).ToString
                a(10) = dr.Item(12).ToString
                a(11) = dr.Item(13).ToString
                a(12) = dr.Item(14).ToString
                a(13) = dr.Item(15).ToString

                a(14) = dr.Item(16).ToString
                a(15) = dr.Item(17).ToString
                a(16) = dr.Item(18).ToString

                DataGridView5.Rows.Add(a)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Public Sub get_culmulative_statement_with_months_operations()
        DataGridView6.Rows.Clear()
        Dim cmd As New SqlCommand
        Dim a(26) As String
        ' Cumulative dictionaries for multiple columns
        Dim cumulativeAllowances As New Dictionary(Of String, Double)()
        Dim cumulativeFuel As New Dictionary(Of String, Double)()
        Dim cumulativeMaintenance As New Dictionary(Of String, Double)()
        Dim cumulativeOthers As New Dictionary(Of String, Double)()
        Dim cumulativeRepair As New Dictionary(Of String, Double)()
        Dim cumulativeSalary As New Dictionary(Of String, Double)()
        Dim cumulativeUtilization As New Dictionary(Of String, Double)()
        Dim cumulativeTires As New Dictionary(Of String, Double)()

        Try
            SQ.connection.Open()
            cmd.Connection = SQ.connection
            cmd.CommandText = "proc_equipment_monitoring2"
            cmd.CommandType = CommandType.StoredProcedure

            If cmb_search.Text = "All Type" Then
                'cmd.Parameters.AddWithValue("@n", 12)
            Else
                cmd.Parameters.AddWithValue("@n", 4)
                cmd.Parameters.AddWithValue("@datefrom2", Date.Parse(DateTimePicker1.Text))
                cmd.Parameters.AddWithValue("@dateto2", Date.Parse(DateTimePicker2.Text))
                cmd.Parameters.AddWithValue("@eq_cat2", cmb_category.Text)
                cmd.Parameters.AddWithValue("@eq_type2", cmb_equiptype.Text)
            End If

            cmd.CommandTimeout = 0
            dr = cmd.ExecuteReader

            Dim previousPlateNo As String = String.Empty

            While dr.Read

                Dim plen As String = dr.Item(0).ToString()
                Dim plateNo As String = dr.Item(1).ToString()
                Dim month As String = dr.Item(2).ToString()

                Dim allowances As Double = Convert.ToDouble(dr.Item(3).ToString()) ' Allowances column
                Dim fuel As Double = Convert.ToDouble(dr.Item(4).ToString()) ' Fuel column
                Dim maintenance As Double = Convert.ToDouble(dr.Item(5).ToString()) ' Maintenance column
                Dim others As Double = Convert.ToDouble(dr.Item(6).ToString()) ' Others column
                Dim repair As Double = Convert.ToDouble(dr.Item(7).ToString()) ' Repair column
                Dim salary As Double = Convert.ToDouble(dr.Item(8).ToString()) ' Salary column
                Dim utilization As Double = Convert.ToDouble(dr.Item(9).ToString()) ' Utilization column
                Dim tires As Double = Convert.ToDouble(dr.Item(10).ToString())

                If plateNo <> previousPlateNo Then
                    cumulativeAllowances.Clear()
                    cumulativeFuel.Clear()
                    cumulativeMaintenance.Clear()
                    cumulativeOthers.Clear()
                    cumulativeRepair.Clear()
                    cumulativeSalary.Clear()
                    cumulativeUtilization.Clear()
                    cumulativeTires.Clear()
                End If


                If Not cumulativeAllowances.ContainsKey(plateNo) Then
                    cumulativeAllowances(plateNo) = 0
                End If
                cumulativeAllowances(plateNo) += allowances

                If Not cumulativeFuel.ContainsKey(plateNo) Then
                    cumulativeFuel(plateNo) = 0
                End If
                cumulativeFuel(plateNo) += fuel

                If Not cumulativeMaintenance.ContainsKey(plateNo) Then
                    cumulativeMaintenance(plateNo) = 0
                End If
                cumulativeMaintenance(plateNo) += maintenance

                If Not cumulativeOthers.ContainsKey(plateNo) Then
                    cumulativeOthers(plateNo) = 0
                End If
                cumulativeOthers(plateNo) += others

                If Not cumulativeRepair.ContainsKey(plateNo) Then
                    cumulativeRepair(plateNo) = 0
                End If
                cumulativeRepair(plateNo) += repair

                If Not cumulativeSalary.ContainsKey(plateNo) Then
                    cumulativeSalary(plateNo) = 0
                End If
                cumulativeSalary(plateNo) += salary

                If Not cumulativeUtilization.ContainsKey(plateNo) Then
                    cumulativeUtilization(plateNo) = 0
                End If
                cumulativeUtilization(plateNo) += utilization

                If Not cumulativeTires.ContainsKey(plateNo) Then
                    cumulativeTires(plateNo) = 0
                End If
                cumulativeTires(plateNo) += tires

                ' Store the current values in the 'a' array for adding to DataGridView
                a(0) = plen
                a(1) = plateNo
                a(2) = month
                a(3) = cumulativeAllowances(plateNo).ToString() ' Cumulative Allowances
                a(4) = cumulativeFuel(plateNo).ToString() ' Cumulative Fuel
                a(5) = cumulativeMaintenance(plateNo).ToString() ' Cumulative Maintenance
                a(6) = cumulativeOthers(plateNo).ToString() ' Cumulative Others
                a(7) = cumulativeRepair(plateNo).ToString() ' Cumulative Repair
                a(8) = cumulativeSalary(plateNo).ToString() ' Cumulative Salary
                a(9) = cumulativeUtilization(plateNo).ToString() ' Cumulative Utilization
                a(10) = cumulativeTires(plateNo).ToString()


                DataGridView6.Rows.Add(a)

                previousPlateNo = plateNo
            End While

            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub


    Public Sub get_culmulative_statement_with_months_operations22222()
        DataGridView6.Rows.Clear()
        Dim cmd As New SqlCommand
        Dim a(26) As String
        ' Cumulative dictionaries for multiple columns
        Dim cumulativeAllowances As New Dictionary(Of String, Double)()
        Dim cumulativeFuel As New Dictionary(Of String, Double)()
        Dim cumulativeMaintenance As New Dictionary(Of String, Double)()
        Dim cumulativeOthers As New Dictionary(Of String, Double)()
        Dim cumulativeRepair As New Dictionary(Of String, Double)()
        Dim cumulativeSalary As New Dictionary(Of String, Double)()
        Dim cumulativeUtilization As New Dictionary(Of String, Double)()

        Try
            SQ.connection.Open()
            cmd.Connection = SQ.connection
            cmd.CommandText = "proc_equipment_monitoring2"
            cmd.CommandType = CommandType.StoredProcedure

            If cmb_search.Text = "All Type" Then
                'cmd.Parameters.AddWithValue("@n", 12)
            Else
                cmd.Parameters.AddWithValue("@n", 6)
                cmd.Parameters.AddWithValue("@datefrom2", Date.Parse(DateTimePicker1.Text))
                cmd.Parameters.AddWithValue("@dateto2", Date.Parse(DateTimePicker2.Text))
                cmd.Parameters.AddWithValue("@eq_cat2", cmb_category.Text)
                cmd.Parameters.AddWithValue("@eq_type2", cmb_equiptype.Text)
            End If

            cmd.CommandTimeout = 0
            dr = cmd.ExecuteReader

            Dim previousPlateNo As String = String.Empty

            While dr.Read

                Dim plen As String = dr.Item(0).ToString()
                Dim plateNo As String = dr.Item(1).ToString()
                Dim month As String = dr.Item(2).ToString()

                Dim allowances As Double = Convert.ToDouble(dr.Item(3).ToString()) ' Allowances column
                Dim fuel As Double = Convert.ToDouble(dr.Item(4).ToString()) ' Fuel column
                Dim maintenance As Double = Convert.ToDouble(dr.Item(5).ToString()) ' Maintenance column
                Dim others As Double = Convert.ToDouble(dr.Item(6).ToString()) ' Others column
                Dim repair As Double = Convert.ToDouble(dr.Item(7).ToString()) ' Repair column
                Dim salary As Double = Convert.ToDouble(dr.Item(8).ToString()) ' Salary column
                Dim utilization As Double = Convert.ToDouble(dr.Item(9).ToString()) ' Utilization column
                Dim tires As Double = Convert.ToDouble(dr.Item(10).ToString())
                'If plateNo <> previousPlateNo Then
                '    cumulativeAllowances.Clear()
                '    cumulativeFuel.Clear()
                '    cumulativeMaintenance.Clear()
                '    cumulativeOthers.Clear()
                '    cumulativeRepair.Clear()
                '    cumulativeSalary.Clear()
                '    cumulativeUtilization.Clear()
                'End If


                'If Not cumulativeAllowances.ContainsKey(plateNo) Then
                '    cumulativeAllowances(plateNo) = 0
                'End If
                'cumulativeAllowances(plateNo) += allowances

                'If Not cumulativeFuel.ContainsKey(plateNo) Then
                '    cumulativeFuel(plateNo) = 0
                'End If
                'cumulativeFuel(plateNo) += fuel

                'If Not cumulativeMaintenance.ContainsKey(plateNo) Then
                '    cumulativeMaintenance(plateNo) = 0
                'End If
                'cumulativeMaintenance(plateNo) += maintenance

                'If Not cumulativeOthers.ContainsKey(plateNo) Then
                '    cumulativeOthers(plateNo) = 0
                'End If
                'cumulativeOthers(plateNo) += others

                'If Not cumulativeRepair.ContainsKey(plateNo) Then
                '    cumulativeRepair(plateNo) = 0
                'End If
                'cumulativeRepair(plateNo) += repair

                'If Not cumulativeSalary.ContainsKey(plateNo) Then
                '    cumulativeSalary(plateNo) = 0
                'End If
                'cumulativeSalary(plateNo) += salary

                'If Not cumulativeUtilization.ContainsKey(plateNo) Then
                '    cumulativeUtilization(plateNo) = 0
                'End If
                'cumulativeUtilization(plateNo) += utilization

                ' Store the current values in the 'a' array for adding to DataGridView
                a(0) = plen
                a(1) = plateNo
                a(2) = month
                a(3) = allowances 'Cumulative Allowances
                a(4) = fuel ' Cumulative Fuel
                a(5) = maintenance  ' Cumulative Maintenance
                a(6) = others ' Cumulative Others
                a(7) = repair  ' Cumulative Repair
                a(8) = salary  ' Cumulative Salary
                a(9) = utilization  ' Cumulative Utilization
                a(10) = tires


                DataGridView6.Rows.Add(a)

                previousPlateNo = plateNo
            End While

            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Public Sub get_culmulative_statement_Depreciation_with_months()
        DataGridView7.Rows.Clear()
        Dim cmd As New SqlCommand
        Dim a(26) As String
        Try
            SQ.connection.Open()
            cmd.Connection = SQ.connection
            cmd.CommandText = "proc_equipment_monitoring2"
            cmd.CommandType = CommandType.StoredProcedure
            If cmb_search.Text = "All Type" Then
                'cmd.Parameters.AddWithValue("@n", 12)
            Else
                cmd.Parameters.AddWithValue("@n", 5)
                cmd.Parameters.AddWithValue("@datefrom2", Date.Parse(DateTimePicker1.Text))
                cmd.Parameters.AddWithValue("@dateto2", Date.Parse(DateTimePicker2.Text))
                cmd.Parameters.AddWithValue("@eq_cat2", cmb_category.Text)
                cmd.Parameters.AddWithValue("@eq_type2", cmb_equiptype.Text)
            End If

            cmd.CommandTimeout = 0
            dr = cmd.ExecuteReader
            While dr.Read
                a(0) = dr.Item(1).ToString
                a(1) = dr.Item(2).ToString
                a(2) = dr.Item(3).ToString
                a(3) = dr.Item(4).ToString
                'a(4) = dr.Item(4).ToString

                a(5) = dr.Item(7).ToString
                a(6) = dr.Item(8).ToString
                a(7) = dr.Item(9).ToString
                a(8) = dr.Item(10).ToString
                a(9) = dr.Item(11).ToString
                a(10) = dr.Item(12).ToString
                a(11) = dr.Item(13).ToString
                a(12) = dr.Item(14).ToString
                a(13) = dr.Item(15).ToString
                a(14) = dr.Item(16).ToString
                a(15) = dr.Item(17).ToString
                a(16) = dr.Item(18).ToString
                DataGridView7.Rows.Add(a)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub


    Public Sub get_culmulative_statement_Depreciation_with_months_2()
        DataGridView9.Rows.Clear()
        Dim cmd As New SqlCommand
        Dim a(4) As String
        Try
            SQ.connection.Open()
            cmd.Connection = SQ.connection
            cmd.CommandText = "proc_equipment_monitoring2"
            cmd.CommandType = CommandType.StoredProcedure
            If cmb_search.Text = "All Type" Then
                'cmd.Parameters.AddWithValue("@n", 12)
            Else
                cmd.Parameters.AddWithValue("@n", 7)
                cmd.Parameters.AddWithValue("@datefrom2", Date.Parse(DateTimePicker1.Text))
                cmd.Parameters.AddWithValue("@dateto2", Date.Parse(DateTimePicker2.Text))
                cmd.Parameters.AddWithValue("@eq_cat2", cmb_category.Text)
                cmd.Parameters.AddWithValue("@eq_type2", cmb_equiptype.Text)
            End If

            cmd.CommandTimeout = 0
            dr = cmd.ExecuteReader
            While dr.Read
                a(0) = dr.Item(0).ToString
                a(1) = dr.Item(1).ToString
                a(2) = dr.Item(2).ToString
                a(3) = dr.Item(3).ToString
                a(4) = dr.Item(4).ToString

                'a(5) = dr.Item(7).ToString
                'a(6) = dr.Item(8).ToString
                'a(7) = dr.Item(9).ToString
                'a(8) = dr.Item(10).ToString
                'a(9) = dr.Item(11).ToString
                'a(10) = dr.Item(12).ToString
                'a(11) = dr.Item(13).ToString
                'a(12) = dr.Item(14).ToString
                'a(13) = dr.Item(15).ToString
                'a(14) = dr.Item(16).ToString
                'a(15) = dr.Item(17).ToString
                'a(16) = dr.Item(18).ToString
                DataGridView9.Rows.Add(a)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Sub get_culmulative_income_statement()
        DataGridView3.Rows.Clear()
        Dim cmd As New SqlCommand
        Dim a(14) As String
        Try
            SQ.connection.Open()
            cmd.Connection = SQ.connection
            cmd.CommandText = "proc_equipment_monitoring2"
            cmd.CommandType = CommandType.StoredProcedure
            If cmb_search.Text = "All Type" Then
                'cmd.Parameters.AddWithValue("@n", 12)
            Else
                cmd.Parameters.AddWithValue("@n", 1)
                cmd.Parameters.AddWithValue("@datefrom2", Date.Parse(DateTimePicker1.Text))
                cmd.Parameters.AddWithValue("@dateto2", Date.Parse(DateTimePicker2.Text))
                cmd.Parameters.AddWithValue("@eq_cat2", cmb_category.Text)
                cmd.Parameters.AddWithValue("@eq_type2", cmb_equiptype.Text)
            End If

            cmd.CommandTimeout = 0
            dr = cmd.ExecuteReader
            While dr.Read
                a(0) = dr.Item(1).ToString
                a(1) = dr.Item(0).ToString
                a(2) = dr.Item(2).ToString
                a(3) = dr.Item(3).ToString
                a(4) = dr.Item(4).ToString
                a(5) = dr.Item(5).ToString
                a(6) = dr.Item(6).ToString
                a(7) = dr.Item(7).ToString
                a(8) = dr.Item(8).ToString
                a(9) = dr.Item(9).ToString
                a(10) = dr.Item(10).ToString
                a(11) = dr.Item(11).ToString
                a(12) = dr.Item(12).ToString
                a(13) = dr.Item(13).ToString
                DataGridView3.Rows.Add(a)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    'Public Sub view_monthly_revenue_report()
    '    Dim dt As New DataTable

    '    With dt
    '        .Columns.Add("Customer")
    '        .Columns.Add("RunHours")
    '        .Columns.Add("RentalRate")
    '        .Columns.Add("PlateNo")
    '    End With

    '    For i As Integer = 0 To DataGridView2.Rows.Count - 1
    '        dt.Rows.Add(
    '        DataGridView2.Rows(i).Cells(1).Value,
    '        DataGridView2.Rows(i).Cells(2).Value,
    '        DataGridView2.Rows(i).Cells(3).Value,
    '        DataGridView2.Rows(i).Cells(4).Value
    '        )
    '    Next

    '    'For Each item As ListViewItem In Me.ListView1.Items
    '    'Next

    '    Dim view As New DataView(dt)

    '    EquipmentMonthlyReportForm.ReportViewer1.LocalReport.DataSources.Item(0).Value = view
    '    EquipmentMonthlyReportForm.ShowDialog()
    '    EquipmentMonthlyReportForm.Dispose()
    'End Sub

    Public Sub view_monthly_revenue_report()
        Dim dt As New DataTable

        With dt
            .Columns.Add("Customer")
            .Columns.Add("RentalRate")
            .Columns.Add("PlateNo")
            .Columns.Add("Month1")
            .Columns.Add("Month2")
            .Columns.Add("Month3")
        End With

        For i As Integer = 0 To DataGridView4.Rows.Count - 1
            dt.Rows.Add(
            DataGridView4.Rows(i).Cells(4).Value,
            DataGridView4.Rows(i).Cells(5).Value,
            DataGridView4.Rows(i).Cells(3).Value,
            DataGridView4.Rows(i).Cells(6).Value,
            DataGridView4.Rows(i).Cells(7).Value,
            DataGridView4.Rows(i).Cells(8).Value
            )
        Next

        'For Each item As ListViewItem In Me.ListView1.Items
        'Next

        Dim view As New DataView(dt)

        EquipmentMonthlyReportForm.ReportViewer1.LocalReport.DataSources.Item(0).Value = view
        EquipmentMonthlyReportForm.ShowDialog()
        EquipmentMonthlyReportForm.Dispose()
    End Sub


    Public Sub view_quarterly_revenue_report()

        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim dt3 As New DataTable

        With dt
            .Columns.Add("Customer")
            .Columns.Add("RentalRate")
            .Columns.Add("PlateNo")
            .Columns.Add("Month1")
            .Columns.Add("Month2")
            .Columns.Add("Month3")
        End With

        For i As Integer = 0 To DataGridView4.Rows.Count - 1
            dt.Rows.Add(
            DataGridView4.Rows(i).Cells(4).Value,
            DataGridView4.Rows(i).Cells(5).Value,
            DataGridView4.Rows(i).Cells(3).Value,
            DataGridView4.Rows(i).Cells(6).Value,
            DataGridView4.Rows(i).Cells(7).Value,
            DataGridView4.Rows(i).Cells(8).Value
            )
        Next

        With dt2
            .Columns.Add("PlateNo")
            .Columns.Add("MonthName")
            .Columns.Add("Allowances")
            .Columns.Add("Fuel")
            .Columns.Add("Maintenance")
            .Columns.Add("Others")
            .Columns.Add("Repair")
            .Columns.Add("Salary")
            .Columns.Add("Utilization")
            .Columns.Add("Tires")

        End With

        For i As Integer = 0 To DataGridView6.Rows.Count - 1
            dt2.Rows.Add(
        DataGridView6.Rows(i).Cells(1).Value.ToString(),
        DataGridView6.Rows(i).Cells(2).Value.ToString(),
        DataGridView6.Rows(i).Cells(3).Value.ToString(),
        DataGridView6.Rows(i).Cells(4).Value.ToString(),
        DataGridView6.Rows(i).Cells(5).Value.ToString(),
        DataGridView6.Rows(i).Cells(6).Value.ToString(),
        DataGridView6.Rows(i).Cells(7).Value.ToString(),
        DataGridView6.Rows(i).Cells(8).Value.ToString(),
        DataGridView6.Rows(i).Cells(9).Value.ToString(),
        DataGridView6.Rows(i).Cells(10).Value.ToString())

        Next


        With dt3
            .Columns.Add("EquipmentId")
            .Columns.Add("PlateNo")
            .Columns.Add("Month1")
            .Columns.Add("Month2")
            .Columns.Add("Month3")

        End With

        For i As Integer = 0 To DataGridView9.Rows.Count - 1
            dt3.Rows.Add(
        If(DataGridView9.Rows(i).Cells(0).Value.ToString() = "-", "0.00", DataGridView9.Rows(i).Cells(0).Value),
        If(DataGridView9.Rows(i).Cells(1).Value.ToString() = "-", "0.00", DataGridView9.Rows(i).Cells(1).Value),
        If(DataGridView9.Rows(i).Cells(2).Value.ToString() = "-", "0.00", DataGridView9.Rows(i).Cells(2).Value),
        If(DataGridView9.Rows(i).Cells(3).Value.ToString() = "-", "0.00", DataGridView9.Rows(i).Cells(3).Value),
        If(DataGridView9.Rows(i).Cells(4).Value.ToString() = "-", "0.00", DataGridView9.Rows(i).Cells(4).Value))
        Next




        Dim view As New DataView(dt)
        Dim view2 As New DataView(dt2)
        Dim view3 As New DataView(dt3)

        EquipmentQuarterlyIncomeFormReport.ReportViewer1.LocalReport.DataSources.Item(0).Value = view
        EquipmentQuarterlyIncomeFormReport.ReportViewer1.LocalReport.DataSources.Item(1).Value = view2
        EquipmentQuarterlyIncomeFormReport.ReportViewer1.LocalReport.DataSources.Item(2).Value = view3
        EquipmentQuarterlyIncomeFormReport.ShowDialog()
        EquipmentQuarterlyIncomeFormReport.Dispose()
    End Sub

    Public Sub view_monthly_income_statement_report()
        Dim dt As New DataTable

        With dt
            .Columns.Add("EquipmentCat")
            .Columns.Add("EquipmentType")
            .Columns.Add("PlateNo")
            .Columns.Add("Project")
            .Columns.Add("Rate")
            .Columns.Add("TotalHour")
            .Columns.Add("Repair")
            .Columns.Add("Maintenance")
            .Columns.Add("Fuel")
            .Columns.Add("Tires")
            .Columns.Add("Allowance")
            .Columns.Add("Salaries")
            .Columns.Add("Depreciation")
            .Columns.Add("Miscellaneous")
        End With

        For i As Integer = 0 To DataGridView3.Rows.Count - 1
            Dim projectValue As String = If(DataGridView3.Rows(i).Cells(3).Value Is Nothing, "", DataGridView3.Rows(i).Cells(3).Value.ToString().Trim())
            If projectValue = "" Then
                Continue For
            End If

            dt.Rows.Add(
        If(DataGridView3.Rows(i).Cells(0).Value.ToString() = "-", "0.00", DataGridView3.Rows(i).Cells(0).Value),
        If(DataGridView3.Rows(i).Cells(1).Value.ToString() = "-", "0.00", DataGridView3.Rows(i).Cells(1).Value),
        If(DataGridView3.Rows(i).Cells(2).Value.ToString() = "-", "0.00", DataGridView3.Rows(i).Cells(2).Value),
        projectValue,
        If(DataGridView3.Rows(i).Cells(4).Value.ToString() = "-", "0.00", DataGridView3.Rows(i).Cells(4).Value),
        If(DataGridView3.Rows(i).Cells(5).Value.ToString() = "-", "0.00", DataGridView3.Rows(i).Cells(5).Value),
        If(DataGridView3.Rows(i).Cells(6).Value.ToString() = "-", "0.00", DataGridView3.Rows(i).Cells(6).Value),
        If(DataGridView3.Rows(i).Cells(7).Value.ToString() = "-", "0.00", DataGridView3.Rows(i).Cells(7).Value),
        If(DataGridView3.Rows(i).Cells(8).Value.ToString() = "-", "0.00", DataGridView3.Rows(i).Cells(8).Value),
        If(DataGridView3.Rows(i).Cells(9).Value.ToString() = "-", "0.00", DataGridView3.Rows(i).Cells(9).Value),
        If(DataGridView3.Rows(i).Cells(10).Value.ToString() = "-", "0.00", DataGridView3.Rows(i).Cells(10).Value),
        If(DataGridView3.Rows(i).Cells(11).Value.ToString() = "-", "0.00", DataGridView3.Rows(i).Cells(11).Value),
        If(DataGridView3.Rows(i).Cells(12).Value.ToString() = "-", "0.00", DataGridView3.Rows(i).Cells(12).Value),
        If(DataGridView3.Rows(i).Cells(13).Value.ToString() = "-", "0.00", DataGridView3.Rows(i).Cells(13).Value)
    )
        Next


        'For Each item As ListViewItem In Me.ListView1.Items
        'Next

        Dim view As New DataView(dt)

        EquipmentMonthlyIncomeFormReport.ReportViewer1.LocalReport.DataSources.Item(0).Value = view
        EquipmentMonthlyIncomeFormReport.ShowDialog()
        EquipmentMonthlyIncomeFormReport.Dispose()
    End Sub

    Public Sub view_culmulative_statement_report()
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim dt3 As New DataTable

        With dt
            .Columns.Add("EquipmentId")
            .Columns.Add("EquipmentCategory")
            .Columns.Add("EquipmentType")
            .Columns.Add("PlateNo")
            .Columns.Add("Project")
            .Columns.Add("January")
            .Columns.Add("February")
            .Columns.Add("March")
            .Columns.Add("April")
            .Columns.Add("May")
            .Columns.Add("June")
            .Columns.Add("July")
            .Columns.Add("August")
            .Columns.Add("September")
            .Columns.Add("October")
            .Columns.Add("November")
            .Columns.Add("December")
        End With

        For i As Integer = 0 To DataGridView5.Rows.Count - 1
            dt.Rows.Add(
        If(DataGridView5.Rows(i).Cells(0).Value.ToString() = "-", "0.00", DataGridView5.Rows(i).Cells(0).Value),
        If(DataGridView5.Rows(i).Cells(1).Value.ToString() = "-", "0.00", DataGridView5.Rows(i).Cells(1).Value),
        If(DataGridView5.Rows(i).Cells(2).Value.ToString() = "-", "0.00", DataGridView5.Rows(i).Cells(2).Value),
        If(DataGridView5.Rows(i).Cells(3).Value.ToString() = "-", "0.00", DataGridView5.Rows(i).Cells(3).Value),
        If(DataGridView5.Rows(i).Cells(4).Value.ToString() = "-", "0.00", DataGridView5.Rows(i).Cells(4).Value),
        If(DataGridView5.Rows(i).Cells(5).Value.ToString() = "-", "0.00", DataGridView5.Rows(i).Cells(5).Value),
        If(DataGridView5.Rows(i).Cells(6).Value.ToString() = "-", "0.00", DataGridView5.Rows(i).Cells(6).Value),
        If(DataGridView5.Rows(i).Cells(7).Value.ToString() = "-", "0.00", DataGridView5.Rows(i).Cells(7).Value),
        If(DataGridView5.Rows(i).Cells(8).Value.ToString() = "-", "0.00", DataGridView5.Rows(i).Cells(8).Value),
        If(DataGridView5.Rows(i).Cells(9).Value.ToString() = "-", "0.00", DataGridView5.Rows(i).Cells(9).Value),
        If(DataGridView5.Rows(i).Cells(10).Value.ToString() = "-", "0.00", DataGridView5.Rows(i).Cells(10).Value),
        If(DataGridView5.Rows(i).Cells(11).Value.ToString() = "-", "0.00", DataGridView5.Rows(i).Cells(11).Value),
        If(DataGridView5.Rows(i).Cells(12).Value.ToString() = "-", "0.00", DataGridView5.Rows(i).Cells(12).Value),
        If(DataGridView5.Rows(i).Cells(13).Value.ToString() = "-", "0.00", DataGridView5.Rows(i).Cells(13).Value),
        If(DataGridView5.Rows(i).Cells(14).Value.ToString() = "-", "0.00", DataGridView5.Rows(i).Cells(14).Value),
        If(DataGridView5.Rows(i).Cells(15).Value.ToString() = "-", "0.00", DataGridView5.Rows(i).Cells(15).Value),
        If(DataGridView5.Rows(i).Cells(16).Value.ToString() = "-", "0.00", DataGridView5.Rows(i).Cells(16).Value)
)
        Next


        With dt2
            .Columns.Add("PlateNo")
            .Columns.Add("MonthName")
            .Columns.Add("Allowances")
            .Columns.Add("Fuel")
            .Columns.Add("Maintenance")
            .Columns.Add("Others")
            .Columns.Add("Repair")
            .Columns.Add("Salary")
            .Columns.Add("Utilization")
            .Columns.Add("Tires")

        End With

        For i As Integer = 0 To DataGridView6.Rows.Count - 1
            dt2.Rows.Add(
        DataGridView6.Rows(i).Cells(1).Value.ToString(),
        DataGridView6.Rows(i).Cells(2).Value.ToString(),
        DataGridView6.Rows(i).Cells(3).Value.ToString(),
        DataGridView6.Rows(i).Cells(4).Value.ToString(),
        DataGridView6.Rows(i).Cells(5).Value.ToString(),
        DataGridView6.Rows(i).Cells(6).Value.ToString(),
        DataGridView6.Rows(i).Cells(7).Value.ToString(),
        DataGridView6.Rows(i).Cells(8).Value.ToString(),
        DataGridView6.Rows(i).Cells(9).Value.ToString(),
        DataGridView6.Rows(i).Cells(10).Value.ToString())

        Next


        With dt3
            .Columns.Add("EquipmentId")
            .Columns.Add("EquipmentType")
            .Columns.Add("PlateNo")
            .Columns.Add("January")
            .Columns.Add("February")
            .Columns.Add("March")
            .Columns.Add("April")
            .Columns.Add("May")
            .Columns.Add("June")
            .Columns.Add("July")
            .Columns.Add("August")
            .Columns.Add("September")
            .Columns.Add("October")
            .Columns.Add("November")
            .Columns.Add("December")
        End With

        For i As Integer = 0 To DataGridView7.Rows.Count - 1
            dt3.Rows.Add(
        If(DataGridView7.Rows(i).Cells(0).Value.ToString() = "-", "0.00", DataGridView7.Rows(i).Cells(0).Value),
        If(DataGridView7.Rows(i).Cells(2).Value.ToString() = "-", "0.00", DataGridView7.Rows(i).Cells(2).Value),
        If(DataGridView7.Rows(i).Cells(3).Value.ToString() = "-", "0.00", DataGridView7.Rows(i).Cells(3).Value),
        If(DataGridView7.Rows(i).Cells(5).Value.ToString() = "-", "0.00", DataGridView7.Rows(i).Cells(5).Value),
        If(DataGridView7.Rows(i).Cells(6).Value.ToString() = "-", "0.00", DataGridView7.Rows(i).Cells(6).Value),
        If(DataGridView7.Rows(i).Cells(7).Value.ToString() = "-", "0.00", DataGridView7.Rows(i).Cells(7).Value),
        If(DataGridView7.Rows(i).Cells(8).Value.ToString() = "-", "0.00", DataGridView7.Rows(i).Cells(8).Value),
        If(DataGridView7.Rows(i).Cells(9).Value.ToString() = "-", "0.00", DataGridView7.Rows(i).Cells(9).Value),
        If(DataGridView7.Rows(i).Cells(10).Value.ToString() = "-", "0.00", DataGridView7.Rows(i).Cells(10).Value),
        If(DataGridView7.Rows(i).Cells(11).Value.ToString() = "-", "0.00", DataGridView7.Rows(i).Cells(11).Value),
        If(DataGridView7.Rows(i).Cells(12).Value.ToString() = "-", "0.00", DataGridView7.Rows(i).Cells(12).Value),
        If(DataGridView7.Rows(i).Cells(13).Value.ToString() = "-", "0.00", DataGridView7.Rows(i).Cells(13).Value),
        If(DataGridView7.Rows(i).Cells(14).Value.ToString() = "-", "0.00", DataGridView7.Rows(i).Cells(14).Value),
        If(DataGridView7.Rows(i).Cells(15).Value.ToString() = "-", "0.00", DataGridView7.Rows(i).Cells(15).Value),
        If(DataGridView7.Rows(i).Cells(16).Value.ToString() = "-", "0.00", DataGridView7.Rows(i).Cells(16).Value)
)
        Next


        'For Each item As ListViewItem In Me.ListView1.Items
        'Next

        Dim view As New DataView(dt)
        Dim view2 As New DataView(dt2)
        Dim view3 As New DataView(dt3)

        EquipmentCulmulativeStatementFormReport.ReportViewer1.LocalReport.DataSources.Item(0).Value = view
        EquipmentCulmulativeStatementFormReport.ReportViewer1.LocalReport.DataSources.Item(1).Value = view2
        EquipmentCulmulativeStatementFormReport.ReportViewer1.LocalReport.DataSources.Item(2).Value = view3
        EquipmentCulmulativeStatementFormReport.ShowDialog()
        EquipmentCulmulativeStatementFormReport.Dispose()
    End Sub

    'Public Sub view_culmulative_statement_report_operations()
    '    Dim dt2 As New DataTable

    '    With dt2
    '        .Columns.Add("PlateNo")
    '        .Columns.Add("MonthName")
    '        .Columns.Add("Allowances")
    '        .Columns.Add("Fuel")
    '        .Columns.Add("Maintenance")
    '        .Columns.Add("Others")
    '        .Columns.Add("Repair")
    '        .Columns.Add("Salary")
    '        .Columns.Add("Utilization")

    '    End With

    '    For i As Integer = 0 To DataGridView5.Rows.Count - 1
    '        dt2.Rows.Add(
    '    If(DataGridView6.Rows(i).Cells(0).Value.ToString() = "-", "0.00", DataGridView5.Rows(i).Cells(0).Value),
    '    If(DataGridView6.Rows(i).Cells(1).Value.ToString() = "-", "0.00", DataGridView5.Rows(i).Cells(1).Value),
    '    If(DataGridView6.Rows(i).Cells(2).Value.ToString() = "-", "0.00", DataGridView5.Rows(i).Cells(2).Value),
    '    If(DataGridView6.Rows(i).Cells(3).Value.ToString() = "-", "0.00", DataGridView5.Rows(i).Cells(3).Value),
    '    If(DataGridView6.Rows(i).Cells(4).Value.ToString() = "-", "0.00", DataGridView5.Rows(i).Cells(4).Value),
    '    If(DataGridView6.Rows(i).Cells(5).Value.ToString() = "-", "0.00", DataGridView5.Rows(i).Cells(5).Value),
    '    If(DataGridView6.Rows(i).Cells(6).Value.ToString() = "-", "0.00", DataGridView5.Rows(i).Cells(6).Value),
    '    If(DataGridView6.Rows(i).Cells(7).Value.ToString() = "-", "0.00", DataGridView5.Rows(i).Cells(7).Value),
    '    If(DataGridView6.Rows(i).Cells(8).Value.ToString() = "-", "0.00", DataGridView5.Rows(i).Cells(8).Value))

    '    Next

    '    'For Each item As ListViewItem In Me.ListView1.Items
    '    'Next

    '    Dim view As New DataView(dt2)

    '    EquipmentCulmulativeStatementFormReport.ReportViewer1.LocalReport.DataSources.Item(2).Value = view
    '    EquipmentCulmulativeStatementFormReport.ShowDialog()
    '    EquipmentCulmulativeStatementFormReport.Dispose()
    'End Sub

    Public Sub view_culmulative_income_report()
        Dim dt As New DataTable

        With dt
            .Columns.Add("EquipmentCat")
            .Columns.Add("EquipmentType")
            .Columns.Add("PlateNo")
            .Columns.Add("Project")
            .Columns.Add("Rate")
            .Columns.Add("TotalHour")
            .Columns.Add("Repair")
            .Columns.Add("Maintenance")
            .Columns.Add("Fuel")
            .Columns.Add("Tires")
            .Columns.Add("Allowance")
            .Columns.Add("Salaries")
            .Columns.Add("Depreciation")
            .Columns.Add("Miscellaneous")
        End With

        For i As Integer = 0 To DataGridView3.Rows.Count - 1
            dt.Rows.Add(
        If(DataGridView3.Rows(i).Cells(0).Value.ToString() = "-", "0.00", DataGridView3.Rows(i).Cells(0).Value),
        If(DataGridView3.Rows(i).Cells(1).Value.ToString() = "-", "0.00", DataGridView3.Rows(i).Cells(1).Value),
        If(DataGridView3.Rows(i).Cells(2).Value.ToString() = "-", "0.00", DataGridView3.Rows(i).Cells(2).Value),
        If(DataGridView3.Rows(i).Cells(3).Value.ToString() = "-", "0.00", DataGridView3.Rows(i).Cells(3).Value),
        If(DataGridView3.Rows(i).Cells(4).Value.ToString() = "-", "0.00", DataGridView3.Rows(i).Cells(4).Value),
        If(DataGridView3.Rows(i).Cells(5).Value.ToString() = "-", "0.00", DataGridView3.Rows(i).Cells(5).Value),
        If(DataGridView3.Rows(i).Cells(6).Value.ToString() = "-", "0.00", DataGridView3.Rows(i).Cells(6).Value),
        If(DataGridView3.Rows(i).Cells(7).Value.ToString() = "-", "0.00", DataGridView3.Rows(i).Cells(7).Value),
        If(DataGridView3.Rows(i).Cells(8).Value.ToString() = "-", "0.00", DataGridView3.Rows(i).Cells(8).Value),
        If(DataGridView3.Rows(i).Cells(9).Value.ToString() = "-", "0.00", DataGridView3.Rows(i).Cells(9).Value),
        If(DataGridView3.Rows(i).Cells(10).Value.ToString() = "-", "0.00", DataGridView3.Rows(i).Cells(10).Value),
        If(DataGridView3.Rows(i).Cells(11).Value.ToString() = "-", "0.00", DataGridView3.Rows(i).Cells(11).Value),
        If(DataGridView3.Rows(i).Cells(12).Value.ToString() = "-", "0.00", DataGridView3.Rows(i).Cells(12).Value),
        If(DataGridView3.Rows(i).Cells(13).Value.ToString() = "-", "0.00", DataGridView3.Rows(i).Cells(13).Value)
    )
        Next

        'For Each item As ListViewItem In Me.ListView1.Items
        'Next

        Dim view As New DataView(dt)

        EquipmentMonthlyIncomeFormReport.ReportViewer1.LocalReport.DataSources.Item(0).Value = view
        EquipmentMonthlyIncomeFormReport.ShowDialog()
        EquipmentMonthlyIncomeFormReport.Dispose()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Label11.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
        ComboBox5.Text = ""
        Panel6.Visible = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Label11.Text = "equipment selected revenue" Then
            Dim datefroms As String
            Dim datetos As String
            datefroms = DateTimePicker1.Text
            datetos = DateTimePicker2.Text

            Dim dateObj As Date
            Dim dateObj2 As Date
            dateObj = DateTime.ParseExact(datefroms, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture)
            dateObj2 = DateTime.ParseExact(datetos, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture)

            Dim formattedDateFrom As String
            Dim formattedDateTo As String
            formattedDateFrom = Format(dateObj, "MMM dd, yyyy")
            formattedDateTo = Format(dateObj2, "MMM dd, yyyy")
            Label10.Text = formattedDateFrom + " - " + formattedDateTo


            get_customer_rental_revenue()
            view_monthly_revenue_report()
            Panel6.Visible = False
            ComboBox2.Text = ""
            ComboBox3.Text = ""
            ComboBox4.Text = ""
            ComboBox5.Text = ""

        ElseIf Label11.Text = "equipment quarterly revenue" Then
            Dim datefroms As String
            Dim datetos As String
            datefroms = DateTimePicker1.Text
            datetos = DateTimePicker2.Text

            Dim dateObj As Date
            Dim dateObj2 As Date
            dateObj = DateTime.ParseExact(datefroms, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture)
            dateObj2 = DateTime.ParseExact(datetos, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture)

            Dim formattedDateFrom As String
            Dim formattedDateTo As String
            formattedDateFrom = Format(dateObj, "MMM dd, yyyy")
            formattedDateTo = Format(dateObj2, "MMM dd, yyyy")
            Label10.Text = formattedDateFrom + " - " + formattedDateTo

            'get_customer_rental_revenue_quarterly()
            get_customer_rental_revenue_new1()
            view_monthly_revenue_report()
            Panel6.Visible = False
            ComboBox2.Text = ""
            ComboBox3.Text = ""
            ComboBox4.Text = ""
            ComboBox5.Text = ""


        ElseIf Label11.Text = "equipment monthly cost report" Then
            If cmb_search.Text = "All Type" Then
                view_report_All_Type()

            ElseIf cmb_search.Text = "Equipment Type" Then

                get_culmulative_statement_with_months_operations22222()
                get_culmulative_statement_Depreciation_with_months_2()
                reportview_cost_quarterly()

                'view_monthly_cost_report_TypeOfEquip()
            End If

        ElseIf Label11.Text = "equipment quarterly income statement" Then
            If cmb_search.Text = "All Type" Then
                MsgBox("equipment monthly income statement ALL BUT NOT YET CODE FOR REPORT")

            ElseIf cmb_search.Text = "Equipment Type" Then
                docs_title = ""
                Dim datefroms As String
                Dim datetos As String
                datefroms = DateTimePicker1.Text
                datetos = DateTimePicker2.Text

                Dim dateObj As Date
                Dim dateObj2 As Date
                dateObj = DateTime.ParseExact(datefroms, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture)
                dateObj2 = DateTime.ParseExact(datetos, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture)

                Dim formattedDateFrom As String
                Dim formattedDateTo As String
                formattedDateFrom = Format(dateObj, "MMM dd, yyyy")
                formattedDateTo = Format(dateObj2, "MMM yyyy")
                Label10.Text = formattedDateTo
                docs_title = "QUARTERLY INCOME STATEMENT"
                DateRangeTitle = "For the month of "

                'get_customer_rental_for_monthly_income_statement()
                get_customer_rental_revenue_new1()
                get_culmulative_statement_with_months_operations22222()
                get_culmulative_statement_Depreciation_with_months_2()

                view_quarterly_revenue_report()
                'get_customer_rental_for_monthly_income_statement2()
                'view_monthly_income_statement_report()
                Panel6.Visible = False
                ComboBox2.Text = ""
                ComboBox3.Text = ""
                ComboBox4.Text = ""
                ComboBox5.Text = ""
            End If

        ElseIf Label11.Text = "equipment anual income statement" Then
            If cmb_search.Text = "All Type" Then
                MsgBox("equipment monthly income statement ALL BUT NOT YET CODE FOR REPORT")

            ElseIf cmb_search.Text = "Equipment Type" Then
                docs_title = ""
                Dim datefroms As String
                Dim datetos As String
                datefroms = DateTimePicker1.Text
                datetos = DateTimePicker2.Text


                Dim dateObj As Date
                Dim dateObj2 As Date
                dateObj = DateTime.ParseExact(datefroms, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture)
                dateObj2 = DateTime.ParseExact(datetos, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture)

                Dim formattedDateFrom As String
                Dim formattedDateTo As String
                formattedDateFrom = Format(dateObj, "MMM dd, yyyy")
                formattedDateTo = Format(dateObj2, "yyyy")
                Label10.Text = formattedDateTo
                DateRangeTitle = "For the Year Ended"
                docs_title = "ANUAL INCOME STATEMENT"

                'get_customer_rental_for_monthly_income_statement()
                get_customer_rental_for_monthly_income_statement2()
                view_monthly_income_statement_report()
                Panel6.Visible = False
                ComboBox2.Text = ""
                ComboBox3.Text = ""
                ComboBox4.Text = ""
                ComboBox5.Text = ""
            End If
        ElseIf Label11.Text = "culmulative income statement" Then
            DateRangeTitle = "For the year ended "

            If cmb_search.Text = "All Type" Then
                MsgBox("equipment monthly income statement ALL BUT NOT YET CODE FOR REPORT")

            ElseIf cmb_search.Text = "Equipment Type" Then
                docs_title = ""
                Dim datefroms As String
                Dim datetos As String
                datefroms = DateTimePicker1.Text
                datetos = DateTimePicker2.Text

                Dim dateObj As Date
                Dim dateObj2 As Date
                dateObj = DateTime.ParseExact(datefroms, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture)
                dateObj2 = DateTime.ParseExact(datetos, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture)

                Dim formattedDateFrom As String
                Dim formattedDateTo As String
                formattedDateFrom = Format(dateObj, "MMM dd, yyyy")
                formattedDateTo = Format(dateObj2, "MMM yyyy")
                Label10.Text = formattedDateTo
                'DateRangeTitle = "For the year ended "
                'docs_title = "ANUAL INCOME STATEMENT"

                'get_customer_rental_for_monthly_income_statement()
                'get_customer_rental_for_monthly_income_statement2()


                get_culmulative_statement_with_months()
                get_culmulative_statement_with_months_operations()
                get_culmulative_statement_Depreciation_with_months()
                monthArray(0) = SumColumnValues(DataGridView5, 5).ToString
                monthArray(1) = SumColumnValues(DataGridView5, 6).ToString
                monthArray(2) = SumColumnValues(DataGridView5, 7).ToString
                monthArray(3) = SumColumnValues(DataGridView5, 8).ToString
                monthArray(4) = SumColumnValues(DataGridView5, 9).ToString
                monthArray(5) = SumColumnValues(DataGridView5, 10).ToString
                monthArray(6) = SumColumnValues(DataGridView5, 11).ToString
                monthArray(7) = SumColumnValues(DataGridView5, 12).ToString
                monthArray(8) = SumColumnValues(DataGridView5, 13).ToString
                monthArray(9) = SumColumnValues(DataGridView5, 14).ToString
                monthArray(10) = SumColumnValues(DataGridView5, 15).ToString
                monthArray(11) = SumColumnValues(DataGridView5, 16).ToString


                getOperationExpense()
                'MsgBox("All January is: " & monthArrayOperation(0) &
                '       "All February is: " & monthArrayOperation(1) &
                '       "All March is: " & monthArrayOperation(2))

                view_culmulative_statement_report()

                Panel6.Visible = False
                ComboBox2.Text = ""
                ComboBox3.Text = ""
                ComboBox4.Text = ""
                ComboBox5.Text = ""
            End If
        ElseIf Label11.Text = "Print Consolidated Report" Then

            If cmb_search.Text = "All Type" Then
                'view_report_All_Type()

            ElseIf cmb_search.Text = "Equipment Type" Then
                consolidated_report_view()

            End If

        End If

    End Sub

    Public Function SumColumnValues(ByVal dgv As DataGridView, ByVal columnIndex As Integer) As Decimal
        Dim total As Decimal = 0

        For Each row As DataGridViewRow In dgv.Rows
            ' Check if the row is not a new row
            If Not row.IsNewRow Then
                Dim cellValue As Object = row.Cells(columnIndex).Value
                If cellValue IsNot Nothing AndAlso IsNumeric(cellValue) Then
                    Dim numericValue As Decimal
                    If Decimal.TryParse(cellValue.ToString(), numericValue) Then
                        total += numericValue
                    End If
                End If
            End If
        Next

        Return total.ToString("F2")
    End Function

    Public Sub getOperationExpense()
        For Each row As DataGridViewRow In DataGridView6.Rows
            'sa allowance only
            If row.Cells(2).Value.ToString() = "January" Then
                monthArrayOperation(0) += Convert.ToDecimal(row.Cells(7).Value)
                monthArrayOperation(0) += Convert.ToDecimal(row.Cells(5).Value)
                monthArrayOperation(0) += Convert.ToDecimal(row.Cells(4).Value)
                monthArrayOperation(0) += Convert.ToDecimal(row.Cells(3).Value)
                monthArrayOperation(0) += Convert.ToDecimal(row.Cells(8).Value)
                monthArrayOperation(0) += Convert.ToDecimal(row.Cells(6).Value)
                monthArrayOperation(0) += Convert.ToDecimal(row.Cells(10).Value)
            ElseIf row.Cells(2).Value.ToString = "February" Then
                monthArrayOperation(1) += Convert.ToDecimal(row.Cells(7).Value)
                monthArrayOperation(1) += Convert.ToDecimal(row.Cells(5).Value)
                monthArrayOperation(1) += Convert.ToDecimal(row.Cells(4).Value)
                monthArrayOperation(1) += Convert.ToDecimal(row.Cells(3).Value)
                monthArrayOperation(1) += Convert.ToDecimal(row.Cells(8).Value)
                monthArrayOperation(1) += Convert.ToDecimal(row.Cells(6).Value)
                monthArrayOperation(1) += Convert.ToDecimal(row.Cells(10).Value)

            ElseIf row.Cells(2).Value.ToString = "March" Then
                monthArrayOperation(2) += Convert.ToDecimal(row.Cells(7).Value)
                monthArrayOperation(2) += Convert.ToDecimal(row.Cells(5).Value)
                monthArrayOperation(2) += Convert.ToDecimal(row.Cells(4).Value)
                monthArrayOperation(2) += Convert.ToDecimal(row.Cells(3).Value)
                monthArrayOperation(2) += Convert.ToDecimal(row.Cells(8).Value)
                monthArrayOperation(2) += Convert.ToDecimal(row.Cells(6).Value)
                monthArrayOperation(2) += Convert.ToDecimal(row.Cells(10).Value)
            ElseIf row.Cells(2).Value.ToString = "April" Then
                monthArrayOperation(3) += Convert.ToDecimal(row.Cells(7).Value)
                monthArrayOperation(3) += Convert.ToDecimal(row.Cells(5).Value)
                monthArrayOperation(3) += Convert.ToDecimal(row.Cells(4).Value)
                monthArrayOperation(3) += Convert.ToDecimal(row.Cells(3).Value)
                monthArrayOperation(3) += Convert.ToDecimal(row.Cells(8).Value)
                monthArrayOperation(3) += Convert.ToDecimal(row.Cells(6).Value)
                monthArrayOperation(3) += Convert.ToDecimal(row.Cells(10).Value)

            ElseIf row.Cells(2).Value.ToString = "May" Then
                monthArrayOperation(4) += Convert.ToDecimal(row.Cells(7).Value)
                monthArrayOperation(4) += Convert.ToDecimal(row.Cells(5).Value)
                monthArrayOperation(4) += Convert.ToDecimal(row.Cells(4).Value)
                monthArrayOperation(4) += Convert.ToDecimal(row.Cells(3).Value)
                monthArrayOperation(4) += Convert.ToDecimal(row.Cells(8).Value)
                monthArrayOperation(4) += Convert.ToDecimal(row.Cells(6).Value)
                monthArrayOperation(4) += Convert.ToDecimal(row.Cells(10).Value)

            ElseIf row.Cells(2).Value.ToString = "June" Then
                monthArrayOperation(5) += Convert.ToDecimal(row.Cells(7).Value)
                monthArrayOperation(5) += Convert.ToDecimal(row.Cells(5).Value)
                monthArrayOperation(5) += Convert.ToDecimal(row.Cells(4).Value)
                monthArrayOperation(5) += Convert.ToDecimal(row.Cells(3).Value)
                monthArrayOperation(5) += Convert.ToDecimal(row.Cells(8).Value)
                monthArrayOperation(5) += Convert.ToDecimal(row.Cells(6).Value)
                monthArrayOperation(5) += Convert.ToDecimal(row.Cells(10).Value)

            ElseIf row.Cells(2).Value.ToString = "July" Then
                monthArrayOperation(6) += Convert.ToDecimal(row.Cells(7).Value)
                monthArrayOperation(6) += Convert.ToDecimal(row.Cells(5).Value)
                monthArrayOperation(6) += Convert.ToDecimal(row.Cells(4).Value)
                monthArrayOperation(6) += Convert.ToDecimal(row.Cells(3).Value)
                monthArrayOperation(6) += Convert.ToDecimal(row.Cells(8).Value)
                monthArrayOperation(6) += Convert.ToDecimal(row.Cells(6).Value)
                monthArrayOperation(6) += Convert.ToDecimal(row.Cells(10).Value)
            ElseIf row.Cells(2).Value.ToString = "August" Then
                monthArrayOperation(7) += Convert.ToDecimal(row.Cells(7).Value)
                monthArrayOperation(7) += Convert.ToDecimal(row.Cells(5).Value)
                monthArrayOperation(7) += Convert.ToDecimal(row.Cells(4).Value)
                monthArrayOperation(7) += Convert.ToDecimal(row.Cells(3).Value)
                monthArrayOperation(7) += Convert.ToDecimal(row.Cells(8).Value)
                monthArrayOperation(7) += Convert.ToDecimal(row.Cells(6).Value)
                monthArrayOperation(7) += Convert.ToDecimal(row.Cells(10).Value)

            ElseIf row.Cells(2).Value.ToString = "September" Then
                monthArrayOperation(8) += Convert.ToDecimal(row.Cells(7).Value)
                monthArrayOperation(8) += Convert.ToDecimal(row.Cells(5).Value)
                monthArrayOperation(8) += Convert.ToDecimal(row.Cells(4).Value)
                monthArrayOperation(8) += Convert.ToDecimal(row.Cells(3).Value)
                monthArrayOperation(8) += Convert.ToDecimal(row.Cells(8).Value)
                monthArrayOperation(8) += Convert.ToDecimal(row.Cells(6).Value)
                monthArrayOperation(8) += Convert.ToDecimal(row.Cells(10).Value)
            ElseIf row.Cells(2).Value.ToString = "October" Then
                monthArrayOperation(9) += Convert.ToDecimal(row.Cells(7).Value)
                monthArrayOperation(9) += Convert.ToDecimal(row.Cells(5).Value)
                monthArrayOperation(9) += Convert.ToDecimal(row.Cells(4).Value)
                monthArrayOperation(9) += Convert.ToDecimal(row.Cells(3).Value)
                monthArrayOperation(9) += Convert.ToDecimal(row.Cells(8).Value)
                monthArrayOperation(9) += Convert.ToDecimal(row.Cells(6).Value)
                monthArrayOperation(9) += Convert.ToDecimal(row.Cells(10).Value)

            ElseIf row.Cells(2).Value.ToString = "November" Then
                monthArrayOperation(10) += Convert.ToDecimal(row.Cells(7).Value)
                monthArrayOperation(10) += Convert.ToDecimal(row.Cells(5).Value)
                monthArrayOperation(10) += Convert.ToDecimal(row.Cells(4).Value)
                monthArrayOperation(10) += Convert.ToDecimal(row.Cells(3).Value)
                monthArrayOperation(10) += Convert.ToDecimal(row.Cells(8).Value)
                monthArrayOperation(10) += Convert.ToDecimal(row.Cells(6).Value)
                monthArrayOperation(10) += Convert.ToDecimal(row.Cells(10).Value)
            ElseIf row.Cells(2).Value.ToString = "December" Then
                monthArrayOperation(11) += Convert.ToDecimal(row.Cells(7).Value)
                monthArrayOperation(11) += Convert.ToDecimal(row.Cells(5).Value)
                monthArrayOperation(11) += Convert.ToDecimal(row.Cells(4).Value)
                monthArrayOperation(11) += Convert.ToDecimal(row.Cells(3).Value)
                monthArrayOperation(11) += Convert.ToDecimal(row.Cells(8).Value)
                monthArrayOperation(11) += Convert.ToDecimal(row.Cells(6).Value)
                monthArrayOperation(11) += Convert.ToDecimal(row.Cells(10).Value)
            End If
        Next
    End Sub





    Private Sub PrintMonthlyCostReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintMonthlyCostReportToolStripMenuItem.Click
        Label11.Text = "equipment monthly cost report"
        Panel6.Visible = True
        Panel6.Location = New Point(495, 107)
        dateformat()
        If Panel3.Visible = True Then
            Panel3.Visible = False
        End If

    End Sub

    Public Sub dateformat()
        Dim startDate As Date = DateTimePicker1.Value
        Dim endDate As Date = DateTimePicker2.Value

        Dim result As String = String.Format("{0:MMMM dd} - {1:MMMM dd, yyyy}", startDate, endDate)

        Label21.Text = result
    End Sub

    Public Sub view_monthly_cost_report_TypeOfEquip()
        Dim dt As New DataTable
        With dt
            .Columns.Add("Category")
            .Columns.Add("Type_of_Equipment")
            .Columns.Add("Equipment_Plate_No")
            .Columns.Add("Rental_Revenue")
            .Columns.Add("Repair")
            .Columns.Add("Maintenance")
            .Columns.Add("Fuel")
            .Columns.Add("Tires")
            .Columns.Add("Allowances")
            .Columns.Add("Salary_wages")
            .Columns.Add("Depreciation_Expense")
            .Columns.Add("Miscellaneous_Expense")
            .Columns.Add("Total_Cost")
            .Columns.Add("Net_Revenue")
            .Columns.Add("Net_Revenue_Without")
            .Columns.Add("Equipment_Age")
            .Columns.Add("Equipment_Brand")
        End With

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            dt.Rows.Add(
                DataGridView1.Rows(i).Cells(0).Value,
                DataGridView1.Rows(i).Cells(1).Value,
                DataGridView1.Rows(i).Cells(2).Value,
                DataGridView1.Rows(i).Cells(4).Value,
                DataGridView1.Rows(i).Cells(5).Value,
                DataGridView1.Rows(i).Cells(6).Value,
                DataGridView1.Rows(i).Cells(7).Value,
                DataGridView1.Rows(i).Cells(8).Value,
                DataGridView1.Rows(i).Cells(9).Value,
                DataGridView1.Rows(i).Cells(10).Value,
                DataGridView1.Rows(i).Cells(11).Value,
                DataGridView1.Rows(i).Cells(12).Value,
                DataGridView1.Rows(i).Cells(13).Value,
                DataGridView1.Rows(i).Cells(14).Value,
                DataGridView1.Rows(i).Cells(15).Value,
                DataGridView1.Rows(i).Cells(16).Value,
                DataGridView1.Rows(i).Cells(17).Value)
        Next
        'For Each item As ListViewItem In Me.ListView1.Items
        'Next

        Dim view As New DataView(dt)

        FEquipment_Monthly_Cost_Report_typeofequip_Form.ReportViewer1.LocalReport.DataSources.Item(0).Value = view
        FEquipment_Monthly_Cost_Report_typeofequip_Form.ShowDialog()
        FEquipment_Monthly_Cost_Report_typeofequip_Form.Dispose()

    End Sub

    Private Sub PrintAllEquipmentRevenueReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintAllEquipmentRevenueReportToolStripMenuItem.Click
        Panel6.Visible = True
        Panel6.Location = New Point(495, 107)
        Label11.Text = "equipment quarterly revenue"
    End Sub

    Private Sub PrintMonthlyIncomeStatementReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintMonthlyIncomeStatementReportToolStripMenuItem.Click
        Panel6.Visible = True
        dateformat()
        Panel6.Location = New Point(495, 107)
        Label11.Text = "equipment quarterly income statement"
    End Sub

    Private Sub PrintAnnualIncomeStatementReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintAnnualIncomeStatementReportToolStripMenuItem.Click
        Panel6.Visible = True
        Panel6.Location = New Point(495, 107)
        Label11.Text = "equipment anual income statement"
    End Sub

    Private Sub PrintCumulativeIncomeStatementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintCumulativeIncomeStatementToolStripMenuItem.Click
        Panel6.Visible = True
        Panel6.Location = New Point(495, 107)
        Label11.Text = "culmulative income statement"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        get_culmulative_statement_with_months_operations()
    End Sub


    Private Sub reportview_cost_quarterly()

        Dim dt2 As New DataTable
        Dim dt3 As New DataTable



        With dt2
            .Columns.Add("PlateNo")
            .Columns.Add("MonthName")
            .Columns.Add("Allowances")
            .Columns.Add("Fuel")
            .Columns.Add("Maintenance")
            .Columns.Add("Others")
            .Columns.Add("Repair")
            .Columns.Add("Salary")
            .Columns.Add("Utilization")
            .Columns.Add("Tires")

        End With

        For i As Integer = 0 To DataGridView6.Rows.Count - 1
            dt2.Rows.Add(
        DataGridView6.Rows(i).Cells(1).Value.ToString(),
        DataGridView6.Rows(i).Cells(2).Value.ToString(),
        DataGridView6.Rows(i).Cells(3).Value.ToString(),
        DataGridView6.Rows(i).Cells(4).Value.ToString(),
        DataGridView6.Rows(i).Cells(5).Value.ToString(),
        DataGridView6.Rows(i).Cells(6).Value.ToString(),
        DataGridView6.Rows(i).Cells(7).Value.ToString(),
        DataGridView6.Rows(i).Cells(8).Value.ToString(),
        DataGridView6.Rows(i).Cells(9).Value.ToString(),
        DataGridView6.Rows(i).Cells(10).Value.ToString())

        Next


        With dt3
            .Columns.Add("EquipmentId")
            .Columns.Add("PlateNo")
            .Columns.Add("Month1")
            .Columns.Add("Month2")
            .Columns.Add("Month3")

        End With

        For i As Integer = 0 To DataGridView9.Rows.Count - 1
            dt3.Rows.Add(
        If(DataGridView9.Rows(i).Cells(0).Value.ToString() = "-", "0.00", DataGridView9.Rows(i).Cells(0).Value),
        If(DataGridView9.Rows(i).Cells(1).Value.ToString() = "-", "0.00", DataGridView9.Rows(i).Cells(1).Value),
        If(DataGridView9.Rows(i).Cells(2).Value.ToString() = "-", "0.00", DataGridView9.Rows(i).Cells(2).Value),
        If(DataGridView9.Rows(i).Cells(3).Value.ToString() = "-", "0.00", DataGridView9.Rows(i).Cells(3).Value),
        If(DataGridView9.Rows(i).Cells(4).Value.ToString() = "-", "0.00", DataGridView9.Rows(i).Cells(4).Value))
        Next





        Dim view2 As New DataView(dt2)
        Dim view3 As New DataView(dt3)

        FEquipment_Monthly_Cost_Report_typeofequip_Form.ReportViewer1.LocalReport.DataSources.Item(0).Value = view2
        FEquipment_Monthly_Cost_Report_typeofequip_Form.ReportViewer1.LocalReport.DataSources.Item(1).Value = view3
        FEquipment_Monthly_Cost_Report_typeofequip_Form.ShowDialog()
        FEquipment_Monthly_Cost_Report_typeofequip_Form.Dispose()
    End Sub

    Private Sub DataGridView6_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView6.CellContentClick

    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint

    End Sub

    Private Sub PrintConsolidatedReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintConsolidatedReportToolStripMenuItem.Click
        Panel6.Visible = True
        Panel6.Location = New Point(495, 107)
        Label11.Text = "Print Consolidated Report"
    End Sub


    Private Sub consolidated_report_view()

        Dim dt2 As New DataTable

        With dt2
            .Columns.Add("PlateNo")
            .Columns.Add("RunHours")
            .Columns.Add("RentalRevenue")
            .Columns.Add("Repair")
            .Columns.Add("Maintenance")
            .Columns.Add("Fuel")
            .Columns.Add("Tires")
            .Columns.Add("Allowances")
            .Columns.Add("SalaryWages")
            .Columns.Add("Depreciation")
            .Columns.Add("Miscellaneous")
            .Columns.Add("TotalCost")
        End With


        For i As Integer = 0 To DataGridView1.Rows.Count - 1

            If DataGridView1.Rows(i).Selected Then
                dt2.Rows.Add(
            DataGridView1.Rows(i).Cells(2).Value?.ToString(),
            DataGridView1.Rows(i).Cells(3).Value?.ToString(),
            DataGridView1.Rows(i).Cells(4).Value?.ToString(),
            DataGridView1.Rows(i).Cells(5).Value?.ToString(),
            DataGridView1.Rows(i).Cells(6).Value?.ToString(),
            DataGridView1.Rows(i).Cells(7).Value?.ToString(),
            DataGridView1.Rows(i).Cells(8).Value?.ToString(),
            DataGridView1.Rows(i).Cells(9).Value?.ToString(),
            DataGridView1.Rows(i).Cells(10).Value?.ToString(),
            DataGridView1.Rows(i).Cells(11).Value?.ToString(),
            DataGridView1.Rows(i).Cells(12).Value?.ToString(),
            DataGridView1.Rows(i).Cells(13).Value?.ToString()
        )
            End If
        Next


        Dim view2 As New DataView(dt2)


        equipment_consolidated_ReportForm.ReportViewer1.LocalReport.DataSources.Item(0).Value = view2
        equipment_consolidated_ReportForm.ShowDialog()
        equipment_consolidated_ReportForm.Dispose()
    End Sub
End Class