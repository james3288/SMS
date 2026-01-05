Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FProgressReport

    Public sqlcon As New SQLcon
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Public txtname As String
    Public pub_textbox As TextBox
    Public data_major As String
    Public data_minor As String
    Public data_equipment_maintenance As String
    Public data_equipment_repair As String
    Public data_equipment_rehabilitation As String
    Public data_equipment_fuel As String
    Public data_equipment_tires As String
    Public data_admin As String
    Public data_other_con As String
    Public data_other_equipment_charges As String
    Public data_paf_charges As String

    Public c As Integer = 5
    Public a(10) As String
    Public b(10) As String

    Public l As Integer = 0
    Public T As Double
    Public S As Double
    Public P As Double
    Public D As Double
    Public U As Double



    Public Sub clear_item_listview()
        lvl_major.Items.Clear()
        lvl_minor.Items.Clear()
        lvl_admin.Items.Clear()
        lvl_equipment_maintenance.Items.Clear()
        lvl_equipment_repair.Items.Clear()
        lvl_equipment_rehabilitation.Items.Clear()
        lvl_equipment_fuel.Items.Clear()
        lvl_equipment_tires.Items.Clear()
        dtg_unserved.Rows.Clear()
        lvl_Total_Request.Items.Clear()
        lvl_Total_Amount.Items.Clear()

    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        clear_item_listview()
        FSummarySupplyTransaction.btnSearch.Enabled = True
        FSummarySupplyTransaction.cmbSearch.Enabled = True
        FSummarySupplyTransaction.btnSearch1.Text = "Search"
        FSummarySupplyTransaction.btnSearch2.Text = "Search"
        FSummarySupplyTransaction.panel_dateRange_Log.Visible = False
        Me.Close()
    End Sub
    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        'FCrystal_Progress_Report.ShowDialog()
        'dtg_unserved.Rows.RemoveAt(dtg_unserved.Rows.Count - 1)

        If txt_TargetMinor.Text = "" Or txt_TargetMajor.Text = "" Or txt_TargetAdmin.Text = "" Or txt_TargetEquipment.Text = "" Or txt_TargetEquipment_Repair.Text = "" Or
         txt_TargetEquipment_Fuel.Text = "" Or txt_TargetEquipment_Rehabilitation.Text = "" Or txt_TargetEquipment_Tires.Text = "" Then
            MessageBox.Show("Please fill up all the targets to generate the data!", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txt_TargetMajor.Focus()
            txt_TargetMajor.BackColor = Color.Yellow
        Else
            'Update_Reported_Request()
            Panel1.Visible = True
        End If

    End Sub
    Public Function Update_Reported_Request()

        Try
            sqlcon.connection.Open()
            cmd = New SqlCommand("proc_progress_report_data", sqlcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure


            cmd.Parameters.AddWithValue("@datefrom", Format(Date.Parse(FSummarySupplyTransaction.dtpStartDate.Value), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@dateto", Format(Date.Parse(FSummarySupplyTransaction.dtpEndDate.Value), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@datefromLog", Format(Date.Parse(FSummarySupplyTransaction.dtp_dateFrom_Log.Value), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@datetoLog", Format(Date.Parse(FSummarySupplyTransaction.dtp_dateTo_Log.Value), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@n", 23)
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & "error: " & Err.Description, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try

    End Function


    Public Function Update_Reported_maki_project()

        Try
            sqlcon.connection.Open()
            cmd = New SqlCommand("proc_progress_report_data", sqlcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@datefrom", Format(Date.Parse(date_log_range.rs_log_from.Value), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@dateto", Format(Date.Parse(date_log_range.rs_log_to.Value), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@datefromLog", Format(Date.Parse(date_log_range.po_log_from.Value), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@datetoLog", Format(Date.Parse(date_log_range.po_log_to.Value), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@n", 1017)
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & "error: " & Err.Description, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try

    End Function

    Public Function Update_Reported_maki_equipment()

        Try
            sqlcon.connection.Open()
            cmd = New SqlCommand("proc_progress_report_data", sqlcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@datefrom", Format(Date.Parse(date_log_range.rs_log_from.Value), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@dateto", Format(Date.Parse(date_log_range.rs_log_to.Value), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@datefromLog", Format(Date.Parse(date_log_range.po_log_from.Value), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@datetoLog", Format(Date.Parse(date_log_range.po_log_to.Value), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@n", 1018)
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & "error: " & Err.Description, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try

    End Function

    Public Function Update_Reported_maki_others()

        Try
            sqlcon.connection.Open()
            cmd = New SqlCommand("proc_progress_report_data", sqlcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@datefrom", Format(Date.Parse(date_log_range.rs_log_from.Value), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@dateto", Format(Date.Parse(date_log_range.rs_log_to.Value), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@datefromLog", Format(Date.Parse(date_log_range.po_log_from.Value), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@datetoLog", Format(Date.Parse(date_log_range.po_log_to.Value), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@n", 1019)
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & "error: " & Err.Description, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try

    End Function

    'Public Sub loading()
    '    Floading.ShowDialog()

    'End Sub
    Private Sub FProgressReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ''create two scroll bars
        'Dim hs As HScrollBar
        'Dim vs As VScrollBar
        'hs = New HScrollBar()
        'vs = New VScrollBar()

        ''set properties
        'hs.Location = New Point(10, 200)
        'hs.Size = New Size(175, 15)
        'hs.Value = 50
        'vs.Location = New Point(200, 30)
        'vs.Size = New Size(15, 175)
        'hs.Value = 50

        ''adding the scroll bars to the form
        'Me.Controls.Add(hs)
        'Me.Controls.Add(vs)
        '' Set the caption bar text of the form.  


        'Dim mthread As New Threading.Thread(AddressOf loading)
        'mthread.Start()

        'Me.HorizontalScroll.Maximum = False
        'Me.AutoScroll = False
        'Me.VerticalScroll.Visible = True
        'Me.AutoScroll = True

        load_form()

        load_project_request()
        load_equipment_request()
        load_others_request_data()
        load_late_rs_logs()


        'mthread.Abort()

    End Sub
    Public Sub load_form()

        lbox_List.Location = New Point(1000, 1000)
        Panel1.Visible = False
        Label5.Text = Format(Date.Parse(FSummarySupplyTransaction.dtpEndDate.Value), "MMMM yyyy")


        While l <= 11

            l = l + 1
            If l = 1 Then 'Major Request
                'T = progress_report_data(2) + progress_report_data(3) + progress_report_data(4) + progress_report_data(5) 'progress_report_data(1
                T = progress_report_data(2) + progress_report_data(4) + progress_report_data(5) 'progress_report_data(1)
                S = progress_report_data(2)
                'P = progress_report_data(3)
                D = progress_report_data(4)
                U = progress_report_data(5)
            ElseIf l = 2 Then 'Minor Request
                'T = progress_report_data(7) + progress_report_data(8) + progress_report_data(9) + progress_report_data(10) 'progress_report_data(6)
                T = progress_report_data(7) + progress_report_data(9) + progress_report_data(10) 'progress_report_data(6)
                S = progress_report_data(7)
                'P = progress_report_data(8)
                D = progress_report_data(9)
                U = progress_report_data(10)
            ElseIf l = 3 Then 'Equipment Maintenance
                'T = progress_report_data(12) + progress_report_data(13) + progress_report_data(14) + progress_report_data(15)  'progress_report_data(11)
                T = progress_report_data(12) + progress_report_data(14) + progress_report_data(15)  'progress_report_data(11)
                S = progress_report_data(12)
                'P = progress_report_data(13)
                D = progress_report_data(14)
                U = progress_report_data(15)
            ElseIf l = 4 Then 'Admin and Misc
                'T = progress_report_data(17) + progress_report_data(18) + progress_report_data(19) + progress_report_data(20)  'progress_report_data(16)
                T = progress_report_data(17) + progress_report_data(19) + progress_report_data(20)  'progress_report_data(16)
                S = progress_report_data(17)
                'P = progress_report_data(18)
                D = progress_report_data(19)
                U = progress_report_data(20)
            ElseIf l = 5 Then 'Equipment Repair
                'T = progress_report_data(122) + progress_report_data(133) + progress_report_data(144) + progress_report_data(155) 'progress_report_data(111)
                T = progress_report_data(122) + progress_report_data(144) + progress_report_data(155) 'progress_report_data(111)
                S = progress_report_data(122)
                'P = progress_report_data(133)
                D = progress_report_data(144)
                U = progress_report_data(155)
            ElseIf l = 6 Then 'Equipment Rehabilitation
                'T = progress_report_data(1222) + progress_report_data(1333) + progress_report_data(1444) + progress_report_data(1555) ' progress_report_data(1111)
                T = progress_report_data(1222) + progress_report_data(1444) + progress_report_data(1555) ' progress_report_data(1111)
                S = progress_report_data(1222)
                'P = progress_report_data(1333)
                D = progress_report_data(1444)
                U = progress_report_data(1555)
            ElseIf l = 7 Then 'Equipment Fuel
                'T = progress_report_data(12222) + progress_report_data(13333) + progress_report_data(14444) + progress_report_data(15555) 'progress_report_data(11111)
                T = progress_report_data(12222) + progress_report_data(14444) + progress_report_data(15555) 'progress_report_data(11111)
                S = progress_report_data(12222)
                'P = progress_report_data(13333)
                D = progress_report_data(14444)
                U = progress_report_data(15555)
            ElseIf l = 8 Then 'Equipment Tires
                'T = progress_report_data(122222) + progress_report_data(133333) + progress_report_data(144444) + progress_report_data(155555) 'progress_report_data(111111)
                T = progress_report_data(122222) + progress_report_data(144444) + progress_report_data(155555) 'progress_report_data(111111)
                S = progress_report_data(122222)
                'P = progress_report_data(133333)
                D = progress_report_data(144444)
                U = progress_report_data(155555)
            ElseIf l = 9 Then 'Other Construction Charges
                'T = progress_report_data(122222) + progress_report_data(133333) + progress_report_data(144444) + progress_report_data(155555) 'progress_report_data(111111)
                T = progress_report_data(991) + progress_report_data(992) + progress_report_data(993) 'progress_report_data(111111)
                S = progress_report_data(991)
                'P = progress_report_data(133333)
                D = progress_report_data(992)
                U = progress_report_data(993)
            ElseIf l = 10 Then 'Other Equipment Charges
                'T = progress_report_data(122222) + progress_report_data(133333) + progress_report_data(144444) + progress_report_data(155555) 'progress_report_data(111111)
                T = progress_report_data(994) + progress_report_data(995) + progress_report_data(996) 'progress_report_data(111111)
                S = progress_report_data(994)
                'P = progress_report_data(133333)
                D = progress_report_data(995)
                U = progress_report_data(996)

            ElseIf l = 11 Then 'Plant and equipments
                'T = progress_report_data(122222) + progress_report_data(133333) + progress_report_data(144444) + progress_report_data(155555) 'progress_report_data(111111)
                T = progress_report_data(1021) + progress_report_data(1022) + progress_report_data(1023) 'progress_report_data(111111)
                S = progress_report_data(1021)
                'P = progress_report_data(133333)
                D = progress_report_data(1022)
                U = progress_report_data(1023)

            End If

            While c >= 0

                If c = 5 Then

                    a(0) = "T"
                    a(1) = "Total no. of requests"
                    a(2) = T
                    '  a(3) = "100.00%"
                    If a(2) = 0 Then
                        a(3) = "0.00%"
                    Else
                        a(3) = "100.00%"
                    End If

                ElseIf c = 4 Then

                    a(0) = "S"
                    a(1) = "No. of requests served on time (%=S/[S+D+U])"
                    a(2) = S
                    a(3) = FormatPercent(S / (S + D + U))
                    'a(3) = (S / (S + D + U)) * 100
                    If a(3) = "NaN" Then
                        a(3) = "0.00%"
                    End If

                    'ElseIf c = 3 Then

                    '    a(0) = "P"
                    '    a(1) = "No. of pending requests (%=P/T)"
                    '    a(2) = P
                    '    a(3) = FormatPercent(P / T)
                    '    If a(3) = "NaN" Then
                    '        a(3) = "0.00%"
                    '    End If

                ElseIf c = 2 Then

                    a(0) = "D"
                    a(1) = "No. of requests delivered late (%=D/[S+D+U])"
                    a(2) = D
                    a(3) = FormatPercent(D / (S + D + U))
                    If a(3) = "NaN" Then
                        a(3) = "0.00%"
                    End If

                ElseIf c = 1 Then

                    a(0) = "U"
                    a(1) = "No. of un-served requests (%=U/[S+D+U])"
                    a(2) = U
                    a(3) = FormatPercent(U / (S + D + U))
                    If a(3) = "NaN" Then
                        a(3) = "0.00%"
                    End If

                ElseIf c = 0 Then

                    a(0) = ""
                    a(1) = "No. of items delivered defective"
                    a(2) = "0"
                    a(3) = "0.00%"
                    If a(3) = "NaN" Then
                        a(3) = "0.00%"
                    End If

                End If

                c = c - 1

                If l = 1 Then
                    Dim lvl As New ListViewItem(a)
                    lvl_major.Items.Add(lvl)
                ElseIf l = 2 Then
                    Dim lvl As New ListViewItem(a)
                    lvl_minor.Items.Add(lvl)
                ElseIf l = 3 Then
                    Dim lvl As New ListViewItem(a)
                    lvl_equipment_maintenance.Items.Add(lvl)
                ElseIf l = 4 Then
                    Dim lvl As New ListViewItem(a)
                    lvl_admin.Items.Add(lvl)
                ElseIf l = 5 Then
                    Dim lvl As New ListViewItem(a)
                    lvl_equipment_repair.Items.Add(lvl)
                ElseIf l = 6 Then
                    Dim lvl As New ListViewItem(a)
                    lvl_equipment_rehabilitation.Items.Add(lvl)
                ElseIf l = 7 Then
                    Dim lvl As New ListViewItem(a)
                    lvl_equipment_fuel.Items.Add(lvl)
                ElseIf l = 8 Then
                    Dim lvl As New ListViewItem(a)
                    lvl_equipment_tires.Items.Add(lvl)
                ElseIf l = 9 Then
                    Dim lvl As New ListViewItem(a)
                    lvl_other_construction_charges.Items.Add(lvl)
                ElseIf l = 10 Then
                    Dim lvl As New ListViewItem(a)
                    lvl_other_equipment_charges.Items.Add(lvl)
                ElseIf l = 11 Then
                    Dim lvl As New ListViewItem(a)
                    lvlPlantEquipments.Items.Add(lvl)
                End If

            End While
            c = 5
        End While


        '''' TOTAL REQUEST BY CATEGORY ''''''
        Dim x As Integer = 10
        While x >= 0

            If x = 10 Then
                b(0) = "Major"
                'b(1) = progress_report_data(2) + progress_report_data(3) + progress_report_data(4) + progress_report_data(5) 'progress_report_data(1)
                b(1) = progress_report_data(2) + progress_report_data(4) + progress_report_data(5) 'progress_report_data(1)
            ElseIf x = 9 Then
                b(0) = "Minor"
                'b(1) = progress_report_data(7) + progress_report_data(8) + progress_report_data(9) + progress_report_data(10) 'progress_report_data(6)
                b(1) = progress_report_data(7) + progress_report_data(9) + progress_report_data(10) 'progress_report_data(6)
            ElseIf x = 8 Then
                b(0) = "Maintenance"
                'b(1) = progress_report_data(12) + progress_report_data(13) + progress_report_data(14) + progress_report_data(15)  'progress_report_data(11)
                b(1) = progress_report_data(12) + progress_report_data(14) + progress_report_data(15)  'progress_report_data(11)
            ElseIf x = 7 Then
                b(0) = "Repair"
                'b(1) = progress_report_data(122) + progress_report_data(133) + progress_report_data(144) + progress_report_data(155) 'progress_report_data(111)
                b(1) = progress_report_data(122) + progress_report_data(144) + progress_report_data(155) 'progress_report_data(111)
            ElseIf x = 6 Then
                b(0) = "Rehabilitation"
                'b(1) = progress_report_data(1222) + progress_report_data(1333) + progress_report_data(1444) + progress_report_data(1555) ' progress_report_data(1111)
                b(1) = progress_report_data(1222) + progress_report_data(1444) + progress_report_data(1555) ' progress_report_data(1111)
            ElseIf x = 5 Then
                b(0) = "Fuel"
                'b(1) = progress_report_data(12222) + progress_report_data(13333) + progress_report_data(14444) + progress_report_data(15555) 'progress_report_data(11111)
                b(1) = progress_report_data(12222) + progress_report_data(14444) + progress_report_data(15555) 'progress_report_data(11111)
            ElseIf x = 4 Then
                b(0) = "Tires"
                'b(1) = progress_report_data(122222) + progress_report_data(133333) + progress_report_data(144444) + progress_report_data(155555) 'progress_report_data(111111)
                b(1) = progress_report_data(122222) + progress_report_data(144444) + progress_report_data(155555) 'progress_report_data(111111)
            ElseIf x = 3 Then
                b(0) = "Admin"
                'b(1) = progress_report_data(17) + progress_report_data(18) + progress_report_data(19) + progress_report_data(20)  'progress_report_data(16)
                b(1) = progress_report_data(17) + progress_report_data(19) + progress_report_data(20)  'progress_report_data(16)
            ElseIf x = 2 Then
                b(0) = "Other Construction"
                'b(1) = progress_report_data(2) + progress_report_data(3) + progress_report_data(4) + progress_report_data(5) 'progress_report_data(1)
                b(1) = progress_report_data(991) + progress_report_data(992) + progress_report_data(993) 'progress_report_data(1)
            ElseIf x = 1 Then
                b(0) = "Other Equipment Charges"
                'b(1) = progress_report_data(2) + progress_report_data(3) + progress_report_data(4) + progress_report_data(5) 'progress_report_data(1)
                b(1) = progress_report_data(994) + progress_report_data(995) + progress_report_data(996) 'progress_report_data(1)
            ElseIf x = 0 Then
                b(0) = "Plants and Equipments"
                'b(1) = progress_report_data(2) + progress_report_data(3) + progress_report_data(4) + progress_report_data(5) 'progress_report_data(1)
                b(1) = progress_report_data(1021) + progress_report_data(1022) + progress_report_data(1023) 'progress_report_data(1)
            End If

            x = x - 1

            Dim newitem As New ListViewItem(b)
            lvl_Total_Request.Items.Add(newitem)

            Dim TotalSum As Double = 0
            For Each item In lvl_Total_Request.Items
                TotalSum += CDbl(item.SubItems.Item(1).Text)
            Next
            lbl_total_request.Text = TotalSum
        End While

        ''''' TOTAL AMOUNT BY CATEGORY ''''''
        Dim z As Integer = 10
        Dim bb(10) As String

        While z >= 0

            If z = 10 Then
                bb(0) = "Major"
                bb(1) = FormatNumber(get_total_amount_by_category(1))
                If bb(1) = "" Then
                    bb(1) = "0"
                End If
            ElseIf z = 9 Then
                bb(0) = "Minor"
                bb(1) = FormatNumber(get_total_amount_by_category(2))
                If bb(1) = "" Then
                    bb(1) = "0"
                End If
            ElseIf z = 8 Then
                bb(0) = "Maintenance"
                bb(1) = FormatNumber(get_total_amount_by_category(3))
                If bb(1) = "" Then
                    bb(1) = "0"
                End If
            ElseIf z = 7 Then
                bb(0) = "Repair"
                bb(1) = FormatNumber(get_total_amount_by_category(4))
                If bb(1) = "" Then
                    bb(1) = "0"
                End If
            ElseIf z = 6 Then
                bb(0) = "Rehabilitation"
                bb(1) = FormatNumber(get_total_amount_by_category(5))
                If bb(1) = "" Then
                    bb(1) = "0"
                End If
            ElseIf z = 5 Then
                bb(0) = "Fuel"
                bb(1) = FormatNumber(get_total_amount_by_category(6))
                If bb(1) = "" Then
                    bb(1) = "0"
                End If
            ElseIf z = 4 Then
                bb(0) = "Tires"
                bb(1) = FormatNumber(get_total_amount_by_category(7))
                If bb(1) = "" Then
                    bb(1) = "0"
                End If
            ElseIf z = 3 Then
                bb(0) = "Admin"
                bb(1) = FormatNumber(get_total_amount_by_category(8))
                If bb(1) = "" Then
                    bb(1) = "0"
                End If
            ElseIf z = 2 Then
                bb(0) = "Other Constructions"
                bb(1) = FormatNumber(get_total_amount_by_category2(1))
                If bb(1) = "" Then
                    bb(1) = "0"
                End If
            ElseIf z = 1 Then
                bb(0) = "Other Equipment Charges"
                bb(1) = FormatNumber(get_total_amount_by_category(10))
                If bb(1) = "" Then
                    bb(1) = "0"
                End If
            ElseIf z = 0 Then
                bb(0) = "Plants and Equipments"
                bb(1) = FormatNumber(get_total_amount_by_category(11))
                If bb(1) = "" Then
                    bb(1) = "0"
                End If
            End If

            z = z - 1

            Dim newitem1 As New ListViewItem(bb)
            lvl_Total_Amount.Items.Add(newitem1)

            Dim TotalAmount As Double = 0
            For Each item1 In lvl_Total_Amount.Items
                TotalAmount += CDbl(item1.SubItems.Item(1).Text)
            Next
            lbl_total_amount.Text = FormatNumber(TotalAmount)

        End While


        get_unserved_data()
        'get_wrap_cell()

    End Sub


    Public Function progress_report_data(ByVal n As Integer)

        Try
            sqlcon.connection.Open()

            cmd = New SqlCommand("proc_progress_report_data", sqlcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandTimeout = 0
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@datefrom", Format(Date.Parse(FSummarySupplyTransaction.dtpStartDate.Value), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@dateto", Format(Date.Parse(FSummarySupplyTransaction.dtpEndDate.Value), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@datefromLog", Format(Date.Parse(FSummarySupplyTransaction.dtp_dateFrom_Log.Value), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@datetoLog", Format(Date.Parse(FSummarySupplyTransaction.dtp_dateTo_Log.Value), "MM/dd/yyyy"))

            If n = 1 Then
                cmd.Parameters.AddWithValue("@n", 1)
            ElseIf n = 2 Then
                cmd.Parameters.AddWithValue("@n", 2)
            ElseIf n = 3 Then
                cmd.Parameters.AddWithValue("@n", 3)
            ElseIf n = 4 Then
                cmd.Parameters.AddWithValue("@n", 4)
            ElseIf n = 5 Then
                cmd.Parameters.AddWithValue("@n", 5)
            ElseIf n = 6 Then
                cmd.Parameters.AddWithValue("@n", 6)
            ElseIf n = 7 Then
                cmd.Parameters.AddWithValue("@n", 7)
            ElseIf n = 8 Then
                cmd.Parameters.AddWithValue("@n", 8)
            ElseIf n = 9 Then
                cmd.Parameters.AddWithValue("@n", 9)
            ElseIf n = 10 Then
                cmd.Parameters.AddWithValue("@n", 10)
            ElseIf n = 11 Then
                cmd.Parameters.AddWithValue("@n", 11)
            ElseIf n = 12 Then
                cmd.Parameters.AddWithValue("@n", 12)
            ElseIf n = 13 Then
                cmd.Parameters.AddWithValue("@n", 13)
            ElseIf n = 14 Then
                cmd.Parameters.AddWithValue("@n", 14)
            ElseIf n = 15 Then
                cmd.Parameters.AddWithValue("@n", 15)
            ElseIf n = 111 Then
                cmd.Parameters.AddWithValue("@n", 111)
            ElseIf n = 122 Then
                cmd.Parameters.AddWithValue("@n", 122)
            ElseIf n = 133 Then
                cmd.Parameters.AddWithValue("@n", 133)
            ElseIf n = 144 Then
                cmd.Parameters.AddWithValue("@n", 144)
            ElseIf n = 155 Then
                cmd.Parameters.AddWithValue("@n", 155)
            ElseIf n = 1111 Then
                cmd.Parameters.AddWithValue("@n", 1111)
            ElseIf n = 1222 Then
                cmd.Parameters.AddWithValue("@n", 1222)
            ElseIf n = 1333 Then
                cmd.Parameters.AddWithValue("@n", 1333)
            ElseIf n = 1444 Then
                cmd.Parameters.AddWithValue("@n", 1444)
            ElseIf n = 1555 Then
                cmd.Parameters.AddWithValue("@n", 1555)
            ElseIf n = 11111 Then
                cmd.Parameters.AddWithValue("@n", 11111)
            ElseIf n = 12222 Then
                cmd.Parameters.AddWithValue("@n", 12222)
            ElseIf n = 13333 Then
                cmd.Parameters.AddWithValue("@n", 13333)
            ElseIf n = 14444 Then
                cmd.Parameters.AddWithValue("@n", 14444)
            ElseIf n = 15555 Then
                cmd.Parameters.AddWithValue("@n", 15555)
            ElseIf n = 111111 Then
                cmd.Parameters.AddWithValue("@n", 111111)
            ElseIf n = 122222 Then
                cmd.Parameters.AddWithValue("@n", 122222)
            ElseIf n = 133333 Then
                cmd.Parameters.AddWithValue("@n", 133333)
            ElseIf n = 144444 Then
                cmd.Parameters.AddWithValue("@n", 144444)
            ElseIf n = 155555 Then
                cmd.Parameters.AddWithValue("@n", 155555)
            ElseIf n = 16 Then
                cmd.Parameters.AddWithValue("@n", 16)
            ElseIf n = 17 Then
                cmd.Parameters.AddWithValue("@n", 17)
            ElseIf n = 18 Then
                cmd.Parameters.AddWithValue("@n", 18)
            ElseIf n = 19 Then
                cmd.Parameters.AddWithValue("@n", 19)
            ElseIf n = 20 Then
                cmd.Parameters.AddWithValue("@n", 20)
            ElseIf n = 991 Then
                cmd.Parameters.AddWithValue("@n", 991)
            ElseIf n = 992 Then
                cmd.Parameters.AddWithValue("@n", 992)
            ElseIf n = 993 Then
                cmd.Parameters.AddWithValue("@n", 993)
            ElseIf n = 994 Then
                cmd.Parameters.AddWithValue("@n", 994)
            ElseIf n = 995 Then
                cmd.Parameters.AddWithValue("@n", 995)
            ElseIf n = 996 Then
                cmd.Parameters.AddWithValue("@n", 996)
            ElseIf n = 1021 Then
                cmd.Parameters.AddWithValue("@n", 1021)
            ElseIf n = 1022 Then
                cmd.Parameters.AddWithValue("@n", 1022)
            ElseIf n = 1023 Then
                cmd.Parameters.AddWithValue("@n", 1023)
            End If

            dr = cmd.ExecuteReader

            While dr.Read
                If dr.HasRows Then
                    If n = 1 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Major").ToString)
                    ElseIf n = 2 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Served_OnTime_Major").ToString)
                    ElseIf n = 3 Then
                        progress_report_data = CDbl(dr.Item("Total_Pending_Major").ToString)
                    ElseIf n = 4 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Late_Major").ToString)
                    ElseIf n = 5 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Unserved").ToString)
                    ElseIf n = 6 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Minor").ToString)
                    ElseIf n = 7 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Served_OnTime_Minor").ToString)
                    ElseIf n = 8 Then
                        progress_report_data = CDbl(dr.Item("Total_Pending_Minor").ToString)
                    ElseIf n = 9 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Late_Minor").ToString)
                    ElseIf n = 10 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Unserved_Minor").ToString)
                    ElseIf n = 11 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Equipment_Maintenance").ToString)
                    ElseIf n = 12 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Served_OnTime_Equipment_Maintenance").ToString)
                    ElseIf n = 13 Then
                        progress_report_data = CDbl(dr.Item("Total_Pending_Equipment_Maintenance").ToString)
                    ElseIf n = 14 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Late_Equipment_Maintenance").ToString)
                    ElseIf n = 15 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Unserved_Equipment_Maintenance").ToString)
                    ElseIf n = 111 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Equipment_Repair").ToString)
                    ElseIf n = 122 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Served_OnTime_Equipment_Repair").ToString)
                    ElseIf n = 133 Then
                        progress_report_data = CDbl(dr.Item("Total_Pending_Equipment_Repair").ToString)
                    ElseIf n = 144 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Late_Equipment_Repair").ToString)
                    ElseIf n = 155 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Unserved_Equipment_Repair").ToString)
                    ElseIf n = 1111 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Equipment_Rehabilitation").ToString)
                    ElseIf n = 1222 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Served_OnTime_Equipment_Rehabilitation").ToString)
                    ElseIf n = 1333 Then
                        progress_report_data = CDbl(dr.Item("Total_Pending_Equipment_Rehabilitation").ToString)
                    ElseIf n = 1444 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Late_Equipment_Rehabilitation").ToString)
                    ElseIf n = 1555 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Unserved_Equipment_Rehabilitation").ToString)
                    ElseIf n = 11111 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Equipment_Fuel").ToString)
                    ElseIf n = 12222 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Served_OnTime_Equipment_Fuel").ToString)
                    ElseIf n = 13333 Then
                        progress_report_data = CDbl(dr.Item("Total_Pending_Equipment_Fuel").ToString)
                    ElseIf n = 14444 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Late_Equipment_Fuel").ToString)
                    ElseIf n = 15555 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Unserved_Equipment_Fuel").ToString)
                    ElseIf n = 111111 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Equipment_Tires").ToString)
                    ElseIf n = 122222 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Served_OnTime_Equipment_Tires").ToString)
                    ElseIf n = 133333 Then
                        progress_report_data = CDbl(dr.Item("Total_Pending_Equipment_Tires").ToString)
                    ElseIf n = 144444 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Late_Equipment_Tires").ToString)
                    ElseIf n = 155555 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Unserved_Equipment_Tires").ToString)
                    ElseIf n = 16 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Admin").ToString)
                    ElseIf n = 17 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Served_OnTime_Admin").ToString)
                    ElseIf n = 18 Then
                        progress_report_data = CDbl(dr.Item("Total_Pending_Admin").ToString)
                    ElseIf n = 19 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Late_Admin").ToString)
                    ElseIf n = 20 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Unserved_Admin").ToString)
                    ElseIf n = 991 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Serve_Other_Construction").ToString)
                    ElseIf n = 992 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Late_Other_Construction").ToString)
                    ElseIf n = 993 Then
                        progress_report_data = CDbl(dr.Item("Total_Other_ConstructionRequest_Unserved").ToString)

                    ElseIf n = 994 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Serve_Other_equipment_charges").ToString)
                    ElseIf n = 995 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Late_Other_equipment_charges").ToString)
                    ElseIf n = 996 Then
                        progress_report_data = CDbl(dr.Item("Total_Other_equipment_charges_Unserved").ToString)


                    ElseIf n = 1021 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Serve_Plant_Equipments_Charges").ToString)
                    ElseIf n = 1022 Then
                        progress_report_data = CDbl(dr.Item("Total_Request_Late_Plant_Equipments_Charges").ToString)
                    ElseIf n = 1023 Then
                        progress_report_data = CDbl(dr.Item("Total_Plant_Equipments_Charges_Unserved").ToString)
                    End If
                End If
            End While

            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & "error: " & Err.Description, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try

    End Function
    Public Function get_unserved_data()
        Dim a(10) As String

        Try
            sqlcon.connection.Open()
            Dim newdr As SqlDataReader
            Dim newcmd As SqlCommand

            newcmd = New SqlCommand("proc_progress_report_data", sqlcon.connection)
            cmd.CommandTimeout = 0
            newcmd.Parameters.Clear()
            newcmd.CommandType = CommandType.StoredProcedure
            newcmd.Parameters.AddWithValue("@datefrom", Format(Date.Parse(FSummarySupplyTransaction.dtpStartDate.Value), "MM/dd/yyyy"))
            newcmd.Parameters.AddWithValue("@dateto", Format(Date.Parse(FSummarySupplyTransaction.dtpEndDate.Value), "MM/dd/yyyy"))
            newcmd.Parameters.AddWithValue("@dateFromLog", Format(Date.Parse(FSummarySupplyTransaction.dtp_dateFrom_Log.Value), "MM/dd/yyyy"))
            newcmd.Parameters.AddWithValue("@dateToLog", Format(Date.Parse(FSummarySupplyTransaction.dtp_dateTo_Log.Value), "MM/dd/yyyy"))
            newcmd.Parameters.AddWithValue("@n", 21)

            newdr = newcmd.ExecuteReader()
            'gnewdr.Item("desired_qty").ToString & " " & newdr.Item("unit").ToString & " - " & newdr.Item("whItem").ToString & " " & newdr.Item("whItemDesc").ToString
            While newdr.Read
                a(0) = newdr.Item("STATUS").ToString
                a(1) = newdr.Item("tor_sub_desc").ToString
                a(2) = newdr.Item("rs_no").ToString
                a(3) = newdr.Item("whItem").ToString
                a(4) = newdr.Item("whItemDesc").ToString
                a(5) = newdr.Item("REQUESTOR").ToString
                a(6) = newdr.Item("remarks").ToString
                a(7) = newdr.Item("project_desc").ToString
                a(8) = newdr.Item("DATEDIFF").ToString + " days"
                a(9) = newdr.Item("SUPPLIERS_NAME").ToString

                'If newdr.Item("STATUS").ToString = "UNSERVED" Then
                '    a(4) = ""
                '    a(5) = ""
                'ElseIf newdr.Item("STATUS").ToString = "LATESERVED" Then
                '    'a(4) = newdr.Item("DATEDIFF").ToString + " days"
                '    'a(5) = newdr.Item("SUPPLIERS_NAME").ToString
                '    a(4) = ""
                '    a(5) = ""
                'End If

                dtg_unserved.Rows.Add(a)

            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & "error: " & Err.Description, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try

    End Function
    Public Function get_total_amount_by_category(ByVal n As Integer) As Integer
        ' Dim count As Double

        Try
            sqlcon.connection.Open()
            cmd = New SqlCommand("proc_progress_report_data", sqlcon.connection)
            cmd.CommandTimeout = 0
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@datefrom", Format(Date.Parse(FSummarySupplyTransaction.dtpStartDate.Text), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@dateto", Format(Date.Parse(FSummarySupplyTransaction.dtpEndDate.Text), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@datefromLog", Format(Date.Parse(FSummarySupplyTransaction.dtp_dateFrom_Log.Text), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@datetoLog", Format(Date.Parse(FSummarySupplyTransaction.dtp_dateTo_Log.Text), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@n", 22)

            dr = cmd.ExecuteReader

            While dr.Read
                If n = 1 Then
                    If dr.Item("tor_sub_desc").ToString = "CONSTRUCTION MATERIALS-MAJOR" Then
                        get_total_amount_by_category += (dr.Item("TOTAL_AMOUNT").ToString)
                    End If
                ElseIf n = 2 Then
                    If dr.Item("tor_sub_desc").ToString = "CONSTRUCTION MATERIALS-MINOR" Then
                        get_total_amount_by_category += (dr.Item("TOTAL_AMOUNT").ToString)
                    End If
                ElseIf n = 3 Then
                    If dr.Item("tor_sub_desc").ToString = "MAINTENANCE EXPENSE" Then
                        get_total_amount_by_category += (dr.Item("TOTAL_AMOUNT").ToString)
                    End If
                ElseIf n = 4 Then
                    If dr.Item("tor_sub_desc").ToString = "REPAIR EXPENSE" Then
                        get_total_amount_by_category += (dr.Item("TOTAL_AMOUNT").ToString)
                    End If
                ElseIf n = 5 Then
                    If dr.Item("tor_sub_desc").ToString = "REHABILITATION EXPENSE" Then
                        get_total_amount_by_category += (dr.Item("TOTAL_AMOUNT").ToString)
                    End If
                ElseIf n = 6 Then
                    If dr.Item("tor_sub_desc").ToString = "FUEL EXPENSE" Then
                        get_total_amount_by_category += (dr.Item("TOTAL_AMOUNT").ToString)
                    End If
                ElseIf n = 7 Then
                    If dr.Item("tor_sub_desc").ToString = "TIRES AND ACCESSORIES EXPENSE" Then
                        get_total_amount_by_category += (dr.Item("TOTAL_AMOUNT").ToString)
                    End If
                ElseIf n = 8 Then
                    If dr.Item("tor_desc").ToString = "Admin and Misc. Request" Then
                        get_total_amount_by_category += (dr.Item("TOTAL_AMOUNT").ToString)
                    End If

                ElseIf n = 9 Then
                    If dr.Item("tor_sub_desc").ToString = "OTHER CONSTRUCTION MATERIALS" And dr.Item("typeRequest").ToString = "Construction materials" Then
                        get_total_amount_by_category += (dr.Item("TOTAL_AMOUNT").ToString)
                    End If
                ElseIf n = 10 Then
                    If dr.Item("tor_sub_desc").ToString = "OTHER EQUIPMENT REQUEST" And dr.Item("typeRequest").ToString = "Equipment Request" Then
                        get_total_amount_by_category += (dr.Item("TOTAL_AMOUNT").ToString)
                    End If

                ElseIf n = 11 Then
                    If dr.Item("tor_sub_desc").ToString = "Acquisition" And dr.Item("typeRequest").ToString = "Equipment Request" Then
                        get_total_amount_by_category += (dr.Item("TOTAL_AMOUNT").ToString)
                    End If
                End If

            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & "error: " & Err.Description, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try
    End Function


    Public Function get_total_amount_by_category2(ByVal n As Integer) As Integer
        ' Dim count As Double

        Try
            sqlcon.connection.Open()
            cmd = New SqlCommand("proc_progress_report_data", sqlcon.connection)
            cmd.CommandTimeout = 0
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@datefrom", Format(Date.Parse(FSummarySupplyTransaction.dtpStartDate.Text), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@dateto", Format(Date.Parse(FSummarySupplyTransaction.dtpEndDate.Text), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@datefromLog", Format(Date.Parse(FSummarySupplyTransaction.dtp_dateFrom_Log.Text), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@datetoLog", Format(Date.Parse(FSummarySupplyTransaction.dtp_dateTo_Log.Text), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@n", 106)

            dr = cmd.ExecuteReader

            While dr.Read
                If n = 1 Then
                    get_total_amount_by_category2 += (dr.Item("TOTAL_AMOUNTs").ToString)
                End If

            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & "error: " & Err.Description, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try
    End Function
    Public Sub get_wrap_cell()
        dtg_unserved.Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dtg_unserved.Columns(4).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        ' dtgSummarySupply.Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dtg_unserved.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dtg_unserved.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        'dtg_unserved.AutoResizeRow(1, DataGridViewAutoSizeRowMode.AllCells)

    End Sub

    Public Sub preview_report_revised()
        'Dim DataTable1 As New dtStationary.DataTable1DataTable

        Dim dtUnserved_Request As New DataTable
        Dim dtProblems As New DataTable
        Dim dtRiskMonitoring_all As New DataTable

        Dim i As Integer = 0

        With dtUnserved_Request
            .Columns.Add("STATUS")
            .Columns.Add("tor_sub_desc")
            .Columns.Add("rs_no")
            .Columns.Add("item_quantity")
            .Columns.Add("item_description")
            .Columns.Add("requestor")
            .Columns.Add("remarks")
            .Columns.Add("DATEDIFF")
            .Columns.Add("project_desc")
        End With

        For i = 0 To dtg_unserved.Rows.Count - 1
            dtUnserved_Request.Rows.Add(dtg_unserved.Rows(i).Cells(0).Value, dtg_unserved.Rows(i).Cells(1).Value, dtg_unserved.Rows(i).Cells(2).Value _
                                        , dtg_unserved.Rows(i).Cells(3).Value, dtg_unserved.Rows(i).Cells(4).Value _
                                        , dtg_unserved.Rows(i).Cells(5).Value, dtg_unserved.Rows(i).Cells(6).Value _
                                        , dtg_unserved.Rows(i).Cells(8).Value, dtg_unserved.Rows(i).Cells(7).Value)
        Next
        dtUnserved_Request.Rows.RemoveAt(dtUnserved_Request.Rows.Count - 1)

        With dtProblems
            .Columns.Add("Issues")
            .Columns.Add("Actions")
        End With

        For i = 0 To dtg_problems.Rows.Count - 1
            dtProblems.Rows.Add(dtg_problems.Rows(i).Cells(0).Value, dtg_problems.Rows(i).Cells(1).Value)
        Next
        dtProblems.Rows.RemoveAt(dtProblems.Rows.Count - 1)



        With dtRiskMonitoring_all
            .Columns.Add("Request")
            .Columns.Add("Category")
            .Columns.Add("Rs")
            .Columns.Add("Charges")
            .Columns.Add("WhItem")
            .Columns.Add("RsItem")
            .Columns.Add("Requestor")
            .Columns.Add("CasualFactor")
            .Columns.Add("RsDateLog")
            .Columns.Add("PoDateLog")
            .Columns.Add("DayDelays")
        End With

        For Each row2 As DataGridViewRow In DataGridView1.Rows
            If row2.Cells(0).Value = True Then
                dtRiskMonitoring_all.Rows.Add(row2.Cells(1).Value, row2.Cells(2).Value,
                           row2.Cells(3).Value, row2.Cells(4).Value, row2.Cells(5).Value,
                           row2.Cells(6).Value, row2.Cells(7).Value, row2.Cells(8).Value,
                           row2.Cells(9).Value, row2.Cells(10).Value, row2.Cells(11).Value)
            End If

        Next

        Dim viewUnserved As New DataView(dtUnserved_Request)
        Dim viewProblems As New DataView(dtProblems)
        Dim view_risk As New DataView(dtRiskMonitoring_all)

        FReportViewer_ProgressReportRevised.ReportViewer2.LocalReport.DataSources.Item(1).Value = viewUnserved
        FReportViewer_ProgressReportRevised.ReportViewer2.LocalReport.DataSources.Item(2).Value = viewProblems
        FReportViewer_ProgressReportRevised.ReportViewer2.LocalReport.DataSources.Item(3).Value = view_risk

        FReportViewer_ProgressReportRevised.ShowDialog()
        FReportViewer_ProgressReportRevised.Dispose()

    End Sub

    Public Sub preview_report()
        'Dim DataTable1 As New dtStationary.DataTable1DataTable

        Dim dtMajor_Request As New DataTable
        Dim dtMinor_Request As New DataTable
        Dim dtEquipment_Request As New DataTable
        Dim dtEquipment_Request_Repair As New DataTable
        Dim dtEquipment_Request_Rehabilitation As New DataTable
        Dim dtEquipment_Request_Fuel As New DataTable
        Dim dtEquipment_Request_Tires As New DataTable
        Dim dtAdmin_Request As New DataTable
        Dim dtUnserved_Request As New DataTable
        Dim dtAll_Category As New DataTable
        Dim dtTotal_Category As New DataTable

        Dim i As Integer = 0

        With dtMajor_Request
            .Columns.Add("data")
        End With

        For i = 0 To lvl_major.Items.Count - 1
            dtMajor_Request.Rows.Add(dtMajor_Request.NewRow)
            dtMajor_Request.Rows(i).Item("data") = lvl_major.Items(i).SubItems(2).Text
        Next

        With dtMinor_Request
            .Columns.Add("code")
            .Columns.Add("determinant")
            .Columns.Add("data")
            .Columns.Add("percentage")
        End With

        For i = 0 To lvl_minor.Items.Count - 1
            dtMinor_Request.Rows.Add(dtMinor_Request.NewRow)
            dtMinor_Request.Rows(i).Item("code") = lvl_minor.Items(i).SubItems(0).Text
            dtMinor_Request.Rows(i).Item("determinant") = lvl_minor.Items(i).SubItems(1).Text
            dtMinor_Request.Rows(i).Item("data") = lvl_minor.Items(i).SubItems(2).Text
            dtMinor_Request.Rows(i).Item("percentage") = lvl_minor.Items(i).SubItems(3).Text
        Next

        With dtEquipment_Request
            .Columns.Add("code")
            .Columns.Add("determinant")
            .Columns.Add("data")
            .Columns.Add("percentage")
        End With

        For i = 0 To lvl_equipment_maintenance.Items.Count - 1
            dtEquipment_Request.Rows.Add(dtEquipment_Request.NewRow)
            dtEquipment_Request.Rows(i).Item("code") = lvl_equipment_maintenance.Items(i).SubItems(0).Text
            dtEquipment_Request.Rows(i).Item("determinant") = lvl_equipment_maintenance.Items(i).SubItems(1).Text
            dtEquipment_Request.Rows(i).Item("data") = lvl_equipment_maintenance.Items(i).SubItems(2).Text
            dtEquipment_Request.Rows(i).Item("percentage") = lvl_equipment_maintenance.Items(i).SubItems(3).Text
        Next

        With dtEquipment_Request_Repair
            .Columns.Add("code")
            .Columns.Add("determinant")
            .Columns.Add("data")
            .Columns.Add("percentage")
        End With

        For i = 0 To lvl_equipment_repair.Items.Count - 1
            dtEquipment_Request_Repair.Rows.Add(dtEquipment_Request_Repair.NewRow)
            dtEquipment_Request_Repair.Rows(i).Item("code") = lvl_equipment_repair.Items(i).SubItems(0).Text
            dtEquipment_Request_Repair.Rows(i).Item("determinant") = lvl_equipment_repair.Items(i).SubItems(1).Text
            dtEquipment_Request_Repair.Rows(i).Item("data") = lvl_equipment_repair.Items(i).SubItems(2).Text
            dtEquipment_Request_Repair.Rows(i).Item("percentage") = lvl_equipment_repair.Items(i).SubItems(3).Text
        Next

        With dtEquipment_Request_Rehabilitation
            .Columns.Add("code")
            .Columns.Add("determinant")
            .Columns.Add("data")
            .Columns.Add("percentage")
        End With

        For i = 0 To lvl_equipment_rehabilitation.Items.Count - 1
            dtEquipment_Request_Rehabilitation.Rows.Add(dtEquipment_Request_Rehabilitation.NewRow)
            dtEquipment_Request_Rehabilitation.Rows(i).Item("code") = lvl_equipment_rehabilitation.Items(i).SubItems(0).Text
            dtEquipment_Request_Rehabilitation.Rows(i).Item("determinant") = lvl_equipment_rehabilitation.Items(i).SubItems(1).Text
            dtEquipment_Request_Rehabilitation.Rows(i).Item("data") = lvl_equipment_rehabilitation.Items(i).SubItems(2).Text
            dtEquipment_Request_Rehabilitation.Rows(i).Item("percentage") = lvl_equipment_rehabilitation.Items(i).SubItems(3).Text
        Next

        With dtEquipment_Request_Fuel
            .Columns.Add("code")
            .Columns.Add("determinant")
            .Columns.Add("data")
            .Columns.Add("percentage")
        End With

        For i = 0 To lvl_equipment_fuel.Items.Count - 1
            dtEquipment_Request_Fuel.Rows.Add(dtEquipment_Request_Fuel.NewRow)
            dtEquipment_Request_Fuel.Rows(i).Item("code") = lvl_equipment_fuel.Items(i).SubItems(0).Text
            dtEquipment_Request_Fuel.Rows(i).Item("determinant") = lvl_equipment_fuel.Items(i).SubItems(1).Text
            dtEquipment_Request_Fuel.Rows(i).Item("data") = lvl_equipment_fuel.Items(i).SubItems(2).Text
            dtEquipment_Request_Fuel.Rows(i).Item("percentage") = lvl_equipment_fuel.Items(i).SubItems(3).Text
        Next

        With dtEquipment_Request_Tires
            .Columns.Add("code")
            .Columns.Add("determinant")
            .Columns.Add("data")
            .Columns.Add("percentage")
        End With

        For i = 0 To lvl_equipment_tires.Items.Count - 1
            dtEquipment_Request_Tires.Rows.Add(dtEquipment_Request_Tires.NewRow)
            dtEquipment_Request_Tires.Rows(i).Item("code") = lvl_equipment_tires.Items(i).SubItems(0).Text
            dtEquipment_Request_Tires.Rows(i).Item("determinant") = lvl_equipment_tires.Items(i).SubItems(1).Text
            dtEquipment_Request_Tires.Rows(i).Item("data") = lvl_equipment_tires.Items(i).SubItems(2).Text
            dtEquipment_Request_Tires.Rows(i).Item("percentage") = lvl_equipment_tires.Items(i).SubItems(3).Text
        Next

        With dtAdmin_Request
            .Columns.Add("code")
            .Columns.Add("deteminant")
            .Columns.Add("data")
            .Columns.Add("percentage")
        End With

        For i = 0 To lvl_admin.Items.Count - 1
            dtAdmin_Request.Rows.Add(dtAdmin_Request.NewRow)
            dtAdmin_Request.Rows(i).Item("code") = lvl_admin.Items(i).SubItems(0).Text
            dtAdmin_Request.Rows(i).Item("deteminant") = lvl_admin.Items(i).SubItems(1).Text
            dtAdmin_Request.Rows(i).Item("data") = lvl_admin.Items(i).SubItems(2).Text
            dtAdmin_Request.Rows(i).Item("percentage") = lvl_admin.Items(i).SubItems(3).Text
        Next

        With dtUnserved_Request
            .Columns.Add("rs_no")
            .Columns.Add("item_quantity")
            .Columns.Add("tor_sub_desc")
            .Columns.Add("project_desc")
            .Columns.Add("DATEDIFF")
            .Columns.Add("SUPPLIERS_NAME")
            .Columns.Add("STATUS")
        End With

        For i = 0 To dtg_unserved.Rows.Count - 1
            dtUnserved_Request.Rows.Add(dtg_unserved.Rows(i).Cells(0).Value, dtg_unserved.Rows(i).Cells(1).Value _
                                        , dtg_unserved.Rows(i).Cells(2).Value, dtg_unserved.Rows(i).Cells(3).Value, dtg_unserved.Rows(i).Cells(4).Value _
                                        , dtg_unserved.Rows(i).Cells(5).Value, dtg_unserved.Rows(i).Cells(6).Value)
        Next
        dtUnserved_Request.Rows.RemoveAt(dtUnserved_Request.Rows.Count - 1)


        With dtAll_Category
            .Columns.Add("Purchases")
            .Columns.Add("Category")
        End With

        For i = 0 To lvl_Total_Request.Items.Count - 1
            dtAll_Category.Rows.Add(dtAll_Category.NewRow)
            dtAll_Category.Rows(i).Item("Category") = lvl_Total_Request.Items(i).SubItems(0).Text
            dtAll_Category.Rows(i).Item("Purchases") = lvl_Total_Request.Items(i).SubItems(1).Text

        Next


        With dtTotal_Category
            .Columns.Add("Purchases")
            .Columns.Add("Category")
        End With

        For i = 0 To lvl_Total_Amount.Items.Count - 1
            dtTotal_Category.Rows.Add(dtTotal_Category.NewRow)
            dtTotal_Category.Rows(i).Item("Category") = lvl_Total_Amount.Items(i).SubItems(0).Text
            dtTotal_Category.Rows(i).Item("Purchases") = lvl_Total_Amount.Items(i).SubItems(1).Text

        Next



        Dim ViewMajorRequest As New DataView(dtMajor_Request)
        Dim viewMinorRequest As New DataView(dtMinor_Request)
        Dim viewEquipment As New DataView(dtEquipment_Request)
        Dim viewEquipment_Repair As New DataView(dtEquipment_Request_Repair)
        Dim viewEquipment_Rehabilitation As New DataView(dtEquipment_Request_Rehabilitation)
        Dim viewEquipment_Fuel As New DataView(dtEquipment_Request_Fuel)
        Dim viewEquipment_Tires As New DataView(dtEquipment_Request_Tires)
        Dim viewAdmin As New DataView(dtAdmin_Request)
        Dim viewUnserved As New DataView(dtUnserved_Request)
        Dim viewTotalRequest As New DataView(dtAll_Category)
        Dim viewTotalAmount As New DataView(dtTotal_Category)

        FReportViewer_ProgressReport.ReportViewer2.LocalReport.DataSources.Item(0).Value = ViewMajorRequest
        FReportViewer_ProgressReport.ReportViewer2.LocalReport.DataSources.Item(1).Value = viewMinorRequest
        FReportViewer_ProgressReport.ReportViewer2.LocalReport.DataSources.Item(2).Value = viewEquipment
        FReportViewer_ProgressReport.ReportViewer2.LocalReport.DataSources.Item(3).Value = viewAdmin
        FReportViewer_ProgressReport.ReportViewer2.LocalReport.DataSources.Item(4).Value = viewUnserved
        FReportViewer_ProgressReport.ReportViewer2.LocalReport.DataSources.Item(5).Value = viewTotalRequest
        FReportViewer_ProgressReport.ReportViewer2.LocalReport.DataSources.Item(6).Value = viewTotalAmount
        FReportViewer_ProgressReport.ReportViewer2.LocalReport.DataSources.Item(7).Value = viewEquipment_Repair
        FReportViewer_ProgressReport.ReportViewer2.LocalReport.DataSources.Item(8).Value = viewEquipment_Rehabilitation
        FReportViewer_ProgressReport.ReportViewer2.LocalReport.DataSources.Item(9).Value = viewEquipment_Fuel
        FReportViewer_ProgressReport.ReportViewer2.LocalReport.DataSources.Item(10).Value = viewEquipment_Tires
        FReportViewer_ProgressReport.ShowDialog()
        FReportViewer_ProgressReport.Dispose()


    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click

        ''save_admin_name()
        'If txt_TargetMinor.Text = "" Or txt_TargetMajor.Text = "" Or txt_TargetAdmin.Text = "" Or txt_TargetEquipment.Text = "" Then
        '    MessageBox.Show("Please fill up all the targets to generate the data!", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    'txt_TargetMajor.Focus()
        '    'txt_TargetMajor.BackColor = Color.Yellow
        'Else


        data_major = lvl_major.Items(1).SubItems(3).Text.ToString.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "")
        data_minor = lvl_minor.Items(1).SubItems(3).Text.ToString.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "")
        data_equipment_maintenance = lvl_equipment_maintenance.Items(1).SubItems(3).Text.ToString.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "")
        data_equipment_repair = lvl_equipment_repair.Items(1).SubItems(3).Text.ToString.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "")
        data_equipment_rehabilitation = lvl_equipment_rehabilitation.Items(1).SubItems(3).Text.ToString.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "")
        data_equipment_fuel = lvl_equipment_fuel.Items(1).SubItems(3).Text.ToString.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "")
        data_equipment_tires = lvl_equipment_tires.Items(1).SubItems(3).Text.ToString.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "")
        data_admin = lvl_admin.Items(1).SubItems(3).Text.ToString.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "")
        data_other_con = lvl_other_construction_charges.Items(1).SubItems(3).Text.ToString.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "")
        data_other_equipment_charges = lvl_other_equipment_charges.Items(1).SubItems(3).Text.ToString.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "")
        data_paf_charges = lvlPlantEquipments.Items(1).SubItems(3).Text.ToString.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "")
        'FReportViewer_ProgressReportRevised.ShowDialog()
        preview_report_revised()

        'preview_report()
        'End If

    End Sub
    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        KeyPreview = True
    End Sub
    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        Panel1.Visible = False
    End Sub
    Private Sub txtCheckName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)

        lbox_List.Visible = False
        If txtCheckName.Focused Then
            txtname = txtCheckName.Name
            txtCheckName.SelectAll()
        End If
        sender.backcolor = Color.Yellow

    End Sub

    Private Sub txtCheckName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'pub_textbox = sender
        'Try
        '    If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down Then
        '        lbox_List.Focus()
        '        lbox_List.SelectedIndex = 0
        '    End If

        'Catch ex As Exception
        '    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
            If lbox_List.Visible = True Then
                If lbox_List.Items.Count > 0 Then
                    lbox_List.Focus()
                    lbox_List.SelectedIndex = 0
                End If
            Else

            End If
        End If
    End Sub

    Private Sub txtCheckName_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        sender.backcolor = Color.White
    End Sub

    Private Sub txtCheckName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)


        'lbox_List.Location = New Point(txtCheckName.Location.X, txtCheckName.Location.Y + 26)
        'If txtCheckName.Focus = True Then
        '    lbox_List.Visible = True
        '    get_admin_name(txtCheckName)
        'End If


        'Try
        '    If txtCheckName.Text = "" Then
        '        lbox_List.BringToFront()
        '        lbox_List.Location = New System.Drawing.Point(txtCheckName.Location.X, txtCheckName.Location.Y + txtCheckName.Height)
        '        lbox_List.Visible = False
        '    Else
        '        lbox_List.BringToFront()
        '        With lbox_List
        '            .Location = New System.Drawing.Point(txtCheckName.Location.X, txtCheckName.Location.Y + txtCheckName.Height)
        '            .Visible = True
        '            .Items.Clear()
        '            .Width = txtCheckName.Width
        '        End With

        '        get_admin_name(txtCheckName)
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

    End Sub

    Public Function get_admin_name(ByVal txtbox As TextBox)
        lbox_List.Items.Clear()
        Dim counter As Integer = 0
        Try
            sqlcon.connection.Open()
            Dim query As String = "SELECT Name FROM admin_names WHERE Name Like '%" & txtbox.Text & "%'"
            cmd = New SqlCommand(query, sqlcon.connection)
            dr = cmd.ExecuteReader

            While dr.Read
                lbox_List.Items.Add(dr.Item("Name").ToString)
                counter += 1
            End While

            If counter = 0 Then
                lbox_List.Visible = False

            Else
                lbox_List.Visible = True
            End If

            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & "error: " & Err.Description, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try

    End Function

    Public Function save_admin_name()
        Try
            sqlcon.connection.Open()
            Dim query As String = "INSERT INTO admin_names(Name) VALUES ('" & txtCheckName.Text & "')"
            cmd = New SqlCommand(query, sqlcon.connection)
            dr = cmd.ExecuteScalar

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & "error: " & Err.Description, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try
    End Function

    Private Sub lbox_List_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        If lbox_List.SelectedItems.Count > 0 Then
            For Each ctr As Control In Me.Controls
                If ctr.Name = txtname Then
                    ctr.Text = lbox_List.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next
            'lbox_List.Visible = False
        Else
            MessageBox.Show("Pls select one item", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub lbox_List_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyCode = Keys.Enter Then
            For Each ctr As Control In Me.Controls
                If ctr.Name = txtname Then
                    ctr.Text = lbox_List.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next
            lbox_List.Visible = False
        End If

    End Sub

    Private Sub btnReported_Click(sender As Object, e As EventArgs)

        Dim result As Integer = MessageBox.Show("Do you want to proceed to REPORT UPDATE?", "STATUS", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            MessageBox.Show("The request will not be reported!", "STATUS", MessageBoxButtons.OK)
        ElseIf result = DialogResult.Yes Then
            Update_Reported_Request()
            MessageBox.Show("Reported Status UPDATED!", "STATUS", MessageBoxButtons.OK)
        End If

        'Update_Reported_Request()
    End Sub

    Private Sub dtg_unserved_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub btnPreview_Click_1(sender As Object, e As EventArgs) Handles btnPreview.Click

    End Sub

    Private Sub btnGenerate_Click_1(sender As Object, e As EventArgs) Handles btnGenerate.Click


    End Sub

    Private Sub btnReported_Click_1(sender As Object, e As EventArgs) Handles btnReported.Click
        Dim result As Integer = MessageBox.Show("Do you want to proceed to REPORT UPDATE?", "STATUS", MessageBoxButtons.YesNo)

        If result = DialogResult.No Then
            MessageBox.Show("The request will not be reported!", "STATUS", MessageBoxButtons.OK)
        ElseIf result = DialogResult.Yes Then
            Update_Reported_Request()
            Update_Reported_maki_project()
            Update_Reported_maki_equipment()
            Update_Reported_maki_others()

            MessageBox.Show("Reported Status UPDATED!", "STATUS", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub btn_close_Click_1(sender As Object, e As EventArgs) Handles btn_close.Click

    End Sub

    Private Sub load_equipment_request()
        Try
            sqlcon.connection.Open()
            cmd = New SqlCommand("sp_supplier_evaluation", sqlcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandTimeout = 0
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@rs_date_log_from", Format(Date.Parse(date_log_range.rs_log_from.Value), "MM/dd/yyyy"))
            'cmd.Parameters.AddWithValue("@rs_date_log_to", Format(Date.Parse(date_log_range.rs_log_to.Value), "MM/dd/yyyy"))
            'cmd.Parameters.AddWithValue("@po_date_log_from", Format(Date.Parse(date_log_range.po_log_from.Value), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@po_date_log_to", Format(Date.Parse(date_log_range.po_log_to.Value), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@n", 100)

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            If dr.Read() Then
                Dim a(2) As String
                a(0) = "Total No. of Requisition Slip"
                a(1) = dr.Item(0).ToString()
                Dim lvl As New ListViewItem(a)
                lvl_equipment_request.Items.Insert(0, lvl)
            End If
            dr.Close()


            cmd.Parameters("@n").Value = 101

            dr = cmd.ExecuteReader()
            If dr.Read() Then
                Dim b(2) As String
                b(0) = "No. of Request Process on time"
                b(1) = dr.Item(0).ToString()
                Dim lvl2 As New ListViewItem(b)
                lvl_equipment_request.Items.Insert(1, lvl2)
            End If
            dr.Close()

            cmd.Parameters("@n").Value = 102

            dr = cmd.ExecuteReader()
            If dr.Read() Then
                Dim c(2) As String
                c(0) = "No. of RS Late Process"
                c(1) = dr.Item(0).ToString()
                Dim lvl3 As New ListViewItem(c)
                lvl_equipment_request.Items.Insert(2, lvl3)
            End If
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        Finally
            sqlcon.connection.Close()
        End Try

    End Sub

    Private Sub load_project_request()
        Dim process_ontime As Decimal
        Dim all_request As Decimal
        Try
            sqlcon.connection.Open()
            cmd = New SqlCommand("sp_supplier_evaluation", sqlcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandTimeout = 0
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@rs_date_log_from", Format(Date.Parse(date_log_range.rs_log_from.Value), "MM/dd/yyyy"))
            'cmd.Parameters.AddWithValue("@rs_date_log_to", Format(Date.Parse(date_log_range.rs_log_to.Value), "MM/dd/yyyy"))
            'cmd.Parameters.AddWithValue("@po_date_log_from", Format(Date.Parse(date_log_range.po_log_from.Value), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@po_date_log_to", Format(Date.Parse(date_log_range.po_log_to.Value), "MM/dd/yyyy"))

            cmd.Parameters.AddWithValue("@n", 997)

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            If dr.Read() Then
                all_request = dr.Item(0).ToString()
                Dim a(2) As String
                a(0) = "Total No. of Requisition Slip"
                a(1) = dr.Item(0).ToString()
                Dim lvl As New ListViewItem(a)
                lvl_project_request.Items.Insert(0, lvl)
            End If
            dr.Close()


            cmd.Parameters("@n").Value = 998

            dr = cmd.ExecuteReader()
            If dr.Read() Then
                process_ontime = dr.Item(0).ToString()
                Dim b(2) As String
                b(0) = "No. of Request Process on time"
                b(1) = dr.Item(0).ToString()

                Dim lvl2 As New ListViewItem(b)
                lvl_project_request.Items.Insert(1, lvl2)
            End If
            dr.Close()

            cmd.Parameters("@n").Value = 999

            dr = cmd.ExecuteReader()
            If dr.Read() Then
                Dim c(2) As String
                c(0) = "No. of RS Late Process"
                c(1) = dr.Item(0).ToString()
                Dim lvl3 As New ListViewItem(c)
                lvl_project_request.Items.Insert(2, lvl3)
            End If
            dr.Close()


            'If lvl_project_request.Items.Count > 0 Then
            '    Dim percentage1 As Decimal
            '    Dim firstItem As ListViewItem = lvl_project_request.Items(0)
            '    If firstItem.SubItems.Count < 2 Then
            '        While firstItem.SubItems.Count < 2
            '            firstItem.SubItems.Add("")
            '        End While
            '    End If
            '    percentage1 = process_ontime / all_request * 100
            '    firstItem.SubItems(2).Text = percentage1.ToString("F2")
            'End If
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        Finally
            sqlcon.connection.Close()
        End Try
    End Sub


    Private Sub load_others_request_data()
        Try
            sqlcon.connection.Open()
            cmd = New SqlCommand("sp_supplier_evaluation", sqlcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandTimeout = 0
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@rs_date_log_from", Format(Date.Parse(date_log_range.rs_log_from.Value), "MM/dd/yyyy"))
            'cmd.Parameters.AddWithValue("@rs_date_log_to", Format(Date.Parse(date_log_range.rs_log_to.Value), "MM/dd/yyyy"))
            'cmd.Parameters.AddWithValue("@po_date_log_from", Format(Date.Parse(date_log_range.po_log_from.Value), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@po_date_log_to", Format(Date.Parse(date_log_range.po_log_to.Value), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@n", 103)

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            If dr.Read() Then
                Dim a(2) As String
                a(0) = "Total No. of Requisition Slip"
                a(1) = dr.Item(0).ToString()
                Dim lvl As New ListViewItem(a)
                lvl_other_request.Items.Insert(0, lvl)
            End If
            dr.Close()


            cmd.Parameters("@n").Value = 104

            dr = cmd.ExecuteReader()
            If dr.Read() Then
                Dim b(2) As String
                b(0) = "No. of Request Process on time"
                b(1) = dr.Item(0).ToString()
                Dim lvl2 As New ListViewItem(b)
                lvl_other_request.Items.Insert(1, lvl2)
            End If
            dr.Close()

            cmd.Parameters("@n").Value = 105

            dr = cmd.ExecuteReader()
            If dr.Read() Then
                Dim c(2) As String
                c(0) = "No. of RS Late Process"
                c(1) = dr.Item(0).ToString()
                Dim lvl3 As New ListViewItem(c)
                lvl_other_request.Items.Insert(2, lvl3)
            End If
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        Finally
            sqlcon.connection.Close()
        End Try
    End Sub

    Private Sub btnbutton2_Click(sender As Object, e As EventArgs) Handles btnbutton2.Click
        load_late_rs_logs()
        Panel2.Visible = True

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txt_TargetMinor.Text = "" Or txt_TargetMajor.Text = "" Or txt_TargetAdmin.Text = "" Or txt_TargetEquipment.Text = "" Or txt_TargetEquipment_Repair.Text = "" Or
         txt_TargetEquipment_Fuel.Text = "" Or txt_TargetEquipment_Rehabilitation.Text = "" Or txt_TargetEquipment_Tires.Text = "" Then
            MessageBox.Show("Please fill up all the targets to generate the data!", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txt_TargetMajor.Focus()
            txt_TargetMajor.BackColor = Color.Yellow
        Else
            'Update_Reported_Request()
            Panel1.Location = New Point(778, 400)
            Panel1.Visible = True
            Panel2.Visible = False

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel2.Visible = False
    End Sub


    Private Sub load_late_rs_logs() 'for now PROJECT SA'
        DataGridView1.Rows.Clear()
        Dim increment_no As Integer = 1

        Try
            sqlcon.connection.Open()
            cmd = New SqlCommand("sp_supplier_evaluation", sqlcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandTimeout = 0
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@rs_date_log_from", Format(Date.Parse(date_log_range.rs_log_from.Value), "MM/dd/yyyy"))
            'cmd.Parameters.AddWithValue("@rs_date_log_to", Format(Date.Parse(date_log_range.rs_log_to.Value), "MM/dd/yyyy"))
            'cmd.Parameters.AddWithValue("@po_date_log_from", Format(Date.Parse(date_log_range.po_log_from.Value), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@po_date_log_to", Format(Date.Parse(date_log_range.po_log_to.Value), "MM/dd/yyyy"))

            cmd.Parameters.AddWithValue("@n", 107) 'SA PROJECT
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                Dim row As New DataGridViewRow()
                DataGridView1.Rows.Add(
                    increment_no.ToString,
                dr("REQUEST").ToString,
                dr("type_name").ToString,
                dr("rs_no").ToString,
                dr("CHARGES").ToString,
                dr("WH_ITEM_NAME").ToString,
                dr("RS_ITEM_DESCRIPTION").ToString,
                dr("requested_by").ToString,
                dr("CASUAL_FACTORS").ToString,
                dr("RS_DATE_LOG").ToString,
                dr("PO_DATE_LOG").ToString,
                dr("days_difference").ToString
            )
                increment_no = increment_no + 1

            End While
            dr.Close()

            cmd.Parameters("@n").Value = 108 'SA EQUIPMENT
            dr = cmd.ExecuteReader()
            While dr.Read()
                Dim row As New DataGridViewRow()
                DataGridView1.Rows.Add(
                    increment_no.ToString,
                dr("REQUEST").ToString,
                dr("type_name").ToString,
                dr("rs_no").ToString,
                dr("CHARGES").ToString,
                dr("WH_ITEM_NAME").ToString,
                dr("RS_ITEM_DESCRIPTION").ToString,
                dr("requested_by").ToString,
                dr("CASUAL_FACTORS").ToString,
                dr("RS_DATE_LOG").ToString,
                dr("PO_DATE_LOG").ToString,
                dr("days_difference").ToString
            )
                increment_no = increment_no + 1
            End While
            dr.Close()

            cmd.Parameters("@n").Value = 109  ' SA OTHERS
            dr = cmd.ExecuteReader()
            While dr.Read()
                Dim row As New DataGridViewRow()
                DataGridView1.Rows.Add(
                    increment_no.ToString,
                dr("REQUEST").ToString,
                dr("tor_sub_desc").ToString,
                dr("rs_no").ToString,
                dr("CHARGES").ToString,
                dr("WH_ITEM_NAME").ToString,
                dr("RS_ITEM_DESCRIPTION").ToString,
                dr("requested_by").ToString,
                dr("CASUAL_FACTORS").ToString,
                dr("RS_DATE_LOG").ToString,
                dr("PO_DATE_LOG").ToString,
                dr("days_difference").ToString
            )
                increment_no = increment_no + 1
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        Finally
            sqlcon.connection.Close()
        End Try
    End Sub

    Private Sub Report_risk_project_equip_others()
        Dim dtRiskMonitoring_all As New DataTable


        Dim i As Integer = 0

        With dtRiskMonitoring_all
            .Columns.Add("Request")
            .Columns.Add("Category")
            .Columns.Add("Rs")
            .Columns.Add("Charges")
            .Columns.Add("WhItem")
            .Columns.Add("RsItem")
            .Columns.Add("Requestor")
            .Columns.Add("CasualFactor")
            .Columns.Add("RsDateLog")
            .Columns.Add("PoDateLog")
            .Columns.Add("DayDelays")
        End With

        For Each row2 As DataGridViewRow In DataGridView1.Rows
            If row2.Cells(0).Value = True Then
                dtRiskMonitoring_all.Rows.Add(row2.Cells(1).Value, row2.Cells(2).Value,
                           row2.Cells(3).Value, row2.Cells(4).Value, row2.Cells(5).Value,
                           row2.Cells(6).Value, row2.Cells(7).Value, row2.Cells(8).Value,
                           row2.Cells(9).Value, row2.Cells(10).Value, row2.Cells(11).Value)
            End If

        Next
        Dim view_risk As New DataView(dtRiskMonitoring_all)

        FReportViewer_ProgressReportRevised.ReportViewer2.LocalReport.DataSources.Item(0).Value = view_risk
        FReportViewer_ProgressReportRevised.ShowDialog()
        FReportViewer_ProgressReportRevised.Dispose()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub


End Class