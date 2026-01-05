Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FProjectCost
    Dim total_materials As Decimal
    Public SQ As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Public trd As Threading.Thread
    Dim how_many As Integer
    Dim dfrom As DateTime = Date.Parse("01-01-2017")
    Dim dto As DateTime = Date.Parse(Now)
    Dim itemlist As New List(Of List(Of String))
    Dim total_project_cost As Double = 0.0
    Dim txtbox As TextBox
    Public textname As String

    'Public Sub loading()
    '    Floading.ShowDialog()
    'End Sub
    Private Sub FProjectCost_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox2.Enabled = False
        by_projectcode()

    End Sub

    Public Sub by_projectcode()
        Dim sq As New SQLcon
        Dim dr1 As SqlDataReader
        Dim cmd1 As SqlCommand
        ComboBox2.Items.Clear()
        Dim i As Integer = 0
        Try

            sq.connection1.Open()
            publicquery = "SELECT project_desc, location, project_engineer FROM dbprojectdesc ORDER BY project_desc ASC"
            cmd1 = New SqlCommand(publicquery, sq.connection1)

            dr1 = cmd1.ExecuteReader

            While dr1.Read


                ComboBox2.Items.Add(dr1.Item("project_desc").ToString)
                itemlist.Add(New List(Of String))
                itemlist(i).Add(dr1.Item(0).ToString)
                itemlist(i).Add(dr1.Item(1).ToString)
                itemlist(i).Add(dr1.Item(2).ToString)
                i = i + 1
            End While
            dr1.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sq.connection1.Close()
        End Try


    End Sub
    Sub project_cost_equipment(ByVal projcode As String)

        Dim a(20) As String
        Dim b(20) As String
        Dim row As Integer = 0
        While row < 7
            Dim lvl As New ListViewItem(a)
            ListView1.Items.Add(lvl)
            row = row + 1
        End While
        a(1) = "I. Materials"
        a(11) = FormatNumber(total_materials)

        Dim lvl1 As New ListViewItem(a)
        ListView1.Items.Add(lvl1)
        b(1) = "II. Equipment"

        Dim current1 As Double = heavy_equipment_Details(projcode, 0)
        'Dim current2 As Double = FormatNumber(light_heavy_equipment_Details1(projcode, "Light Equipment", 21, True, dfrom, dto, 0, 0), 2, , TriState.True)
        'Dim current3 As Double = FormatNumber(light_exempted_from_eu(projcode, dfrom, dto), 2, , TriState.True)

        'Dim total As Double = FormatNumber((current1 + current2 + current3), 2, , TriState.True)
        Dim total As Double = FormatNumber(current1, 2, , TriState.True)
        b(11) = FormatNumber(total)
        'b(11) = FormatNumber(("100,000"), 2, , TriState.True)
        total_project_cost = total_project_cost + b(11)

        Dim lvl2 As New ListViewItem(b)
        ListView1.Items.Add(lvl2)

    End Sub

    Public Function heavy_equipment_Details(ByVal proj As String, ByVal n As Integer) As Double

        Dim newSQ As New SQLcon
        Dim newcmd As SqlCommand
        Dim newdr As SqlDataReader
        Dim a(10) As String

        Try
            newSQ.connection1.Open()

            newcmd = New SqlCommand("proc_eu_charges", newSQ.connection1)
            newcmd.Parameters.Clear()
            newcmd.CommandType = CommandType.StoredProcedure
            newcmd.Parameters.AddWithValue("@project", proj)
            newcmd.Parameters.AddWithValue("@from", Format(Date.Parse(dfrom), "yyyy-MM-dd"))
            newcmd.Parameters.AddWithValue("@to", Format(Date.Parse(dto), "yyyy-MM-dd"))
            newcmd.Parameters.AddWithValue("@n", 103)
            newcmd.CommandTimeout = 0

            newdr = newcmd.ExecuteReader
            While newdr.Read


                heavy_equipment_Details = CDbl(newdr(0))


            End While
            newdr.Close()

        Catch ex As Exception
            'MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection1.Close()
        End Try
    End Function

    Public Function eu_calculate_rh(ByVal equipListID As Integer, ByVal datefrom As DateTime, ByVal dateto As DateTime, ByVal project As String) As Double


        Dim newSQ As New SQLcon
        Dim newcmd As SqlCommand
        Dim newdr As SqlDataReader

        Try
            newSQ.connection1.Open()

            newcmd = New SqlCommand("proc_FEquipment_Charges_new", newSQ.connection1)
            newcmd.Parameters.Clear()
            newcmd.CommandType = CommandType.StoredProcedure

            newcmd.Parameters.AddWithValue("@n", 4)
            newcmd.Parameters.AddWithValue("@equipListID", equipListID)
            newcmd.Parameters.AddWithValue("@from", datefrom)
            newcmd.Parameters.AddWithValue("@dateto", dateto)
            newcmd.Parameters.AddWithValue("@project", project)

            newdr = newcmd.ExecuteReader
            While newdr.Read
                Dim cat As String = check_if_light(newdr.Item("equipListID").ToString)

                If cat = "Light Equipment" Then
                    If check_light_exemption(newdr.Item("equipTypeID").ToString) > 0 Then
                        eu_calculate_rh += totaltime(
                        Format(Date.Parse(newdr.Item("start_time").ToString), "hh:mm:ss tt"),
                        Format(Date.Parse(newdr.Item("end_time").ToString), "hh:mm:ss tt"),
                        True
                    )
                    End If
                Else
                    eu_calculate_rh += totaltime(
                         Format(Date.Parse(newdr.Item("start_time").ToString), "hh:mm:ss tt"),
                         Format(Date.Parse(newdr.Item("end_time").ToString), "hh:mm:ss tt"),
                         True
                     )
                End If

            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection1.Close()
        End Try
    End Function

    Public Function check_if_light(ByVal equipListID As Integer) As String

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection1.Open()
            newCMD = New SqlCommand("proc_FEquipment_Charges_new", newSQ.connection1)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 5)
            newCMD.Parameters.AddWithValue("@equipListID", equipListID)

            newDR = newCMD.ExecuteReader
            While newDR.Read
                check_if_light = newDR.Item("equip_category").ToString
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection1.Close()
        End Try

    End Function
    Sub project_cost_labor(ByVal n As Integer, ByVal projcode As String)

        Dim SQ As New SQLcon
        Dim dr As SqlDataReader
        Dim sqlcomm As New SqlCommand

        Dim new_item_no As Boolean = False
        Dim item_no As String = ""
        'ListView1.Items.Clear()

        Try

            SQ.connection.Open()


            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "proc_filterBy"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", n)
            sqlcomm.Parameters.AddWithValue("@projectcode", projcode)
            sqlcomm.CommandTimeout = 0


            dr = sqlcomm.ExecuteReader

            While dr.Read
                Dim a(20) As String

                a(1) = "III. Labor"
                a(11) = FormatNumber(dr.Item(0).ToString)
                total_project_cost = total_project_cost + a(11)
                Dim lvl2 As New ListViewItem(a)
                ListView1.Items.Add(lvl2)
                'a(0) = dr.Item(0).ToString
                'a(1) = dr.Item(1).ToString
                'a(2) = dr.Item(2).ToString
                'a(3) = dr.Item(3).ToString

                'Dim lvl As New ListViewItem(a)
                'ListView1.Items.Add(lvl)

            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Sub project_cost_miscellaneous(ByVal n As Integer, ByVal projcode As String)

        Dim SQ As New SQLcon
        Dim dr As SqlDataReader
        Dim sqlcomm As New SqlCommand

        Dim new_item_no As Boolean = False
        Dim item_no As String = ""
        'ListView1.Items.Clear()

        Try

            SQ.connection.Open()


            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "proc_filterBy"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", n)
            sqlcomm.Parameters.AddWithValue("@projectcode", projcode)
            sqlcomm.CommandTimeout = 0

            dr = sqlcomm.ExecuteReader

            While dr.Read
                Dim a(20) As String

                a(1) = "IV. Miscellaneous"
                a(11) = FormatNumber(dr.Item(0).ToString)
                Dim lvl2 As New ListViewItem(a)
                ListView1.Items.Add(lvl2)

                Dim b(20) As String
                total_project_cost = total_project_cost + a(11)
                b(1) = "        TOTAL PROJECT COST"
                b(11) = FormatNumber(total_project_cost)
                Dim lvl3 As New ListViewItem(b)
                ListView1.Items.Add(lvl3)
                'a(0) = dr.Item(0).ToString
                'a(1) = dr.Item(1).ToString
                'a(2) = dr.Item(2).ToString
                'a(3) = dr.Item(3).ToString

                'Dim lvl As New ListViewItem(a)
                'ListView1.Items.Add(lvl)

            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Sub project_cost_material(ByVal n As Integer, ByVal projcode As String)

        total_materials = 0
        Dim SQ As New SQLcon
        Dim dr As SqlDataReader
        Dim sqlcomm As New SqlCommand

        Dim new_item_no As Boolean = False
        Dim item_no As String = ""
        Dim item_dsc As String = ""
        ListView1.Items.Clear()

        Try

            SQ.connection.Open()

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "proc_filterBy"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", n)
            sqlcomm.Parameters.AddWithValue("@projectcode", projcode)
            sqlcomm.CommandTimeout = 0

            dr = sqlcomm.ExecuteReader
            Dim row_count As Integer = 0
            Dim num_rows As Integer = 0
            Dim insert_data(20) As String
            Dim insert_num_row As Integer = 0
            Dim sub_total As Double = 0
            Dim has_result As Boolean = False

            While dr.Read
                has_result = True
                row_count = row_count + 1
                If item_no = dr.Item(0).ToString And item_dsc = dr.Item(1).ToString Then
                    new_item_no = False
                Else
                    item_no = dr.Item(0).ToString
                    item_dsc = dr.Item(1).ToString
                    new_item_no = True
                    If row_count > 1 Then
                        Dim c(20) As String
                        Dim row As Integer = 0
                        insert_data(11) = FormatNumber(sub_total)
                        Dim item As ListViewItem = ListView1.Items(insert_num_row - 1)
                        Dim intIndex As Integer = item.Index
                        item.Remove()
                        Dim insert_lvl As New ListViewItem(insert_data)
                        ListView1.Items.Insert(intIndex, insert_lvl)

                        While row < 2
                            num_rows = num_rows + 1
                            Dim lvl As New ListViewItem(c)
                            'c(0) = ""
                            ListView1.Items.Add(lvl)
                            row = row + 1
                        End While
                        sub_total = 0
                    End If
                End If
                If new_item_no = True Then
                    'Erase insert_data
                    Dim a(20) As String
                    insert_data(0) = dr.Item(0).ToString.Replace("*", "")
                    insert_data(1) = dr.Item(1).ToString
                    insert_data(2) = dr.Item(3).ToString
                    If IsNumeric(dr.Item(4).ToString) Then
                        insert_data(3) = FormatNumber(dr.Item(4).ToString)
                    Else
                        insert_data(3) = dr.Item(4).ToString
                    End If
                    If IsNumeric(dr.Item(5).ToString) Then
                        insert_data(4) = FormatNumber(dr.Item(5).ToString)
                    Else
                        insert_data(4) = dr.Item(5).ToString
                    End If
                    If IsNumeric(dr.Item(6).ToString) Then
                        insert_data(5) = FormatNumber(dr.Item(6).ToString)
                    Else
                        insert_data(5) = dr.Item(6).ToString
                    End If

                    a(0) = dr.Item(0).ToString
                    a(1) = dr.Item(1).ToString
                    a(2) = dr.Item(3).ToString

                    If IsNumeric(dr.Item(4).ToString) Then
                        a(3) = FormatNumber(dr.Item(4).ToString)
                    Else
                        a(3) = dr.Item(4).ToString
                    End If

                    If IsNumeric(dr.Item(5).ToString) Then
                        a(4) = FormatNumber(dr.Item(5).ToString)
                    Else
                        a(4) = dr.Item(5).ToString
                    End If
                    If IsNumeric(dr.Item(6).ToString) Then
                        a(5) = FormatNumber(dr.Item(6).ToString)
                    Else
                        a(5) = dr.Item(6).ToString
                    End If
                    'a(5) = dr.Item(6).ToString
                    'a(12) = "(MAIN)" & dr.Item(0).ToString
                    num_rows = num_rows + 1
                    insert_num_row = num_rows
                    Dim lvl As New ListViewItem(a)
                    ListView1.Items.Add(lvl)
                    Dim b(20) As String
                    b(1) = "    " + dr.Item(2).ToString
                    b(6) = dr.Item(7).ToString
                    If IsNumeric(dr.Item(8).ToString) Then
                        b(7) = FormatNumber(dr.Item(8).ToString)
                    Else
                        b(7) = dr.Item(8).ToString
                    End If
                    'b(7) = FormatNumber(dr.Item(8).ToString)
                    b(8) = dr.Item(9).ToString
                    'If dr.Item(14).ToString.Contains("PURCHASE") Then
                    '    'received
                    '    b(9) = FormatNumber(dr.Item(10).ToString)
                    '    b(10) = FormatNumber(CDbl(dr.Item(11).ToString) / CDbl(dr.Item(10).ToString))
                    'ElseIf dr.Item(14).ToString.Contains("WITHDRAW") Then
                    '    'withdraw
                    '    b(9) = FormatNumber(dr.Item(12).ToString)
                    '    b(10) = FormatNumber(CDbl(dr.Item(13).ToString) / CDbl(dr.Item(12).ToString))
                    'ElseIf dr.Item(14).ToString.Contains("CASH") Then
                    '    'received
                    '    b(9) = FormatNumber(dr.Item(10).ToString)
                    '    b(10) = FormatNumber(CDbl(dr.Item(11).ToString) / CDbl(dr.Item(10).ToString))
                    'Else
                    '    'withdraw
                    '    b(9) = FormatNumber(dr.Item(12).ToString)
                    '    If IsNumeric(dr.Item(13).ToString) Then
                    '        b(10) = FormatNumber(CDbl(dr.Item(13).ToString) / CDbl(dr.Item(12).ToString))
                    '    Else
                    '        b(10) = 0
                    '    End If
                    'End If

                    If dr.Item(16).ToString = "REQUEST" Then
                        b(9) = FormatNumber(CDbl(dr.Item(12).ToString))
                        b(10) = FormatNumber(CDbl(dr.Item(13).ToString) / CDbl(dr.Item(12).ToString))
                        b(11) = FormatNumber(CDbl(dr.Item(13).ToString))
                        'b(11) = FormatNumber(CDbl(b(9)) * CDbl(b(10)))
                    Else
                        b(9) = FormatNumber(CDbl(dr.Item(11).ToString))
                        b(10) = FormatNumber(CDbl(dr.Item(12).ToString) / CDbl(dr.Item(11).ToString))
                        b(11) = FormatNumber(CDbl(dr.Item(12).ToString))
                    End If


                    b(12) = FormatNumber(CDbl(dr.Item(15).ToString))

                    Dim budgetary As Double
                    Dim actual As Double
                    Dim pending As Double

                    If IsNumeric(b(7)) Then
                        budgetary = FormatNumber(b(7))
                    Else
                        budgetary = 0
                    End If

                    If IsNumeric(b(9)) Then
                        actual = FormatNumber(b(9)) ''sss
                    Else
                        actual = 0
                    End If

                    If IsNumeric(b(12)) Then
                        pending = FormatNumber(b(12))
                    Else
                        pending = 0
                    End If


                    b(13) = budgetary - (actual + pending)
                    total_materials = total_materials + CDbl(b(11))
                    sub_total = sub_total + CDbl(b(11))
                    num_rows = num_rows + 1

                    Dim lvl2 As New ListViewItem(b)
                    ListView1.Items.Add(lvl2)
                Else

                    Dim a(20) As String
                    'a(0) = dr.Item(0).ToString
                    a(1) = "    " + dr.Item(2).ToString
                    a(6) = dr.Item(7).ToString
                    If IsNumeric(dr.Item(8).ToString) Then
                        a(7) = FormatNumber(dr.Item(8).ToString)
                    Else
                        a(7) = dr.Item(8).ToString
                    End If
                    'a(7) = FormatNumber(dr.Item(8).ToString)
                    a(8) = dr.Item(9).ToString
                    'If dr.Item(14).ToString.Contains("PURCHASE") Then
                    '    'received
                    '    a(9) = FormatNumber(dr.Item(10).ToString)
                    '    a(10) = FormatNumber(CDbl(dr.Item(11).ToString) / CDbl(dr.Item(10).ToString))
                    'ElseIf dr.Item(14).ToString.Contains("WITHDRAW") Then
                    '    'withdraw
                    '    a(9) = FormatNumber(dr.Item(12).ToString)
                    '    a(10) = FormatNumber(CDbl(dr.Item(13).ToString) / CDbl(dr.Item(12).ToString))
                    'ElseIf dr.Item(14).ToString.Contains("CASH") Then
                    '    'received
                    '    a(9) = FormatNumber(dr.Item(10).ToString)
                    '    a(10) = FormatNumber(CDbl(dr.Item(11).ToString) / CDbl(dr.Item(10).ToString))
                    'Else
                    '    'withdraw
                    '    a(9) = FormatNumber(dr.Item(12).ToString)
                    '    'a(10) = FormatNumber(dr.Item(13).ToString)
                    '    If IsNumeric(dr.Item(13).ToString) Then
                    '        a(10) = FormatNumber(CDbl(dr.Item(13).ToString) / CDbl(dr.Item(12).ToString))
                    '    Else
                    '        a(10) = 0
                    '    End If
                    'End If


                    If dr.Item(16).ToString = "REQUEST" Then
                        a(9) = FormatNumber(CDbl(dr.Item(12).ToString))
                        a(10) = FormatNumber(CDbl(dr.Item(13).ToString) / CDbl(dr.Item(12).ToString))
                        a(11) = FormatNumber(CDbl(dr.Item(13).ToString))
                    Else
                        a(9) = FormatNumber(CDbl(dr.Item(11).ToString))
                        a(10) = FormatNumber(CDbl(dr.Item(12).ToString) / CDbl(dr.Item(11).ToString))
                        a(11) = FormatNumber(CDbl(dr.Item(12).ToString))
                    End If



                    'a(11) = FormatNumber(CDbl(a(9)) * CDbl(a(10)))


                    a(12) = FormatNumber(CDbl(dr.Item(15).ToString))

                    Dim budgetary As Double
                    Dim actual As Double
                    Dim pending As Double

                    If IsNumeric(a(7)) Then
                        budgetary = FormatNumber(a(7))
                    Else
                        budgetary = 0
                    End If

                    If IsNumeric(a(9)) Then
                        actual = FormatNumber(a(9)) ''sss
                    Else
                        actual = 0
                    End If

                    If IsNumeric(a(12)) Then
                        pending = FormatNumber(a(12))
                    Else
                        pending = 0
                    End If

                    a(13) = budgetary - (actual + pending)
                    total_materials = total_materials + CDbl(a(11))
                    sub_total = sub_total + CDbl(a(11))
                    num_rows = num_rows + 1

                    Dim lvl As New ListViewItem(a)
                    ListView1.Items.Add(lvl)


                End If

                'a(0) = dr.Item(0).ToString
                'a(1) = dr.Item(1).ToString
                'a(2) = dr.Item(2).ToString
                'a(3) = dr.Item(3).ToString

                'Dim lvl As New ListViewItem(a)
                'ListView1.Items.Add(lvl)


            End While
            If has_result = True Then
                insert_data(11) = FormatNumber(sub_total)
                Dim item2 As ListViewItem = ListView1.Items(insert_num_row - 1)
                Dim intIndex2 As Integer = item2.Index
                item2.Remove()
                Dim insert_lvl2 As New ListViewItem(insert_data)
                ListView1.Items.Insert(intIndex2, insert_lvl2)
            End If



            dr.Close()
            'MsgBox(num_rows)
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
        total_project_cost = FormatNumber(total_project_cost + total_materials)
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
        ListView1.Items.Clear()
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Project" Then
            ComboBox2.Enabled = True
        Else
            FMonthlyProjectCost.ShowDialog()
            ComboBox2.Enabled = False
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)
        For Each l As List(Of String) In itemlist
            If l.Contains(ComboBox2.Text) Then
                Label2.Text = l(1)
                Label3.Text = l(2)
            End If
        Next

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'total_project_cost = 0.0
        'trd = New Threading.Thread(AddressOf loading)
        'trd.Start()
        'trd.IsBackground = True

        project_cost_material(3, ComboBox2.Text)
        project_cost_equipment(ComboBox2.Text)
        project_cost_labor(2, ComboBox2.Text)
        project_cost_miscellaneous(1, ComboBox2.Text)

        set_colors()
        'trd.Abort()
    End Sub

    Sub set_colors()
        'Dim ListView1 As ListView = New ListView

        For Each item As ListViewItem In ListView1.Items
            If item.SubItems.Item(13).Text = "" Then
                'MsgBox("nothing")
            Else
                If CDbl(item.SubItems.Item(13).Text) < 0 Then
                    item.BackColor = Color.Red
                    item.ForeColor = Color.White
                End If
            End If
        Next
    End Sub

    '''''''''''''''EQUIPMENT EUS CODE''''''''''''''''

    Public Function calculate_total_eu_per_project(ByVal project As String) As Double

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection1.Open()
            newCMD = New SqlCommand("proc_FEquipment_Charges_new", newSQ.connection1)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 3)
            newCMD.Parameters.Add("@from", SqlDbType.Date).Value = Format(Date.Parse(dfrom))
            newCMD.Parameters.Add("@dateto", SqlDbType.Date).Value = Format(Date.Parse(dto))
            newCMD.Parameters.AddWithValue("@project", project)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                If newDR.Item("equip_category").ToString = "Light Equipment" Then

                Else
                    calculate_total_eu_per_project += totaltime(
                             Format(Date.Parse(newDR.Item("start_time").ToString), "hh:mm:ss tt"),
                             Format(Date.Parse(newDR.Item("end_time").ToString), "hh:mm:ss tt"),
                             True
                         ) * CDbl(newDR.Item("rate").ToString)
                End If
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection1.Close()
        End Try

    End Function

    Public Function light_heavy_equipment_Details1(ByVal project As String, ByVal equipcat As String, ByVal field As Integer, ByVal bol As Boolean, ByVal datefrom As DateTime, ByVal dateto As DateTime, ByVal m As Integer, ByVal n As Integer) As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim a(15) As String

        Dim result As String = ""
        Dim convertedtomonth As String = ""

        Try
            newSQ.connection1.Open()

            newCMD = New SqlCommand("proc_dbequipment_get_desired_data", newSQ.connection1)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@searchfor", project)
            newCMD.Parameters.AddWithValue("@field", 101)
            newCMD.Parameters.AddWithValue("@datefrom", Date.Parse(dfrom))
            newCMD.Parameters.AddWithValue("@dateto", Date.Parse(Now))
            newCMD.Parameters.AddWithValue("@equipCat", equipcat)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                ' Dim rate As Double = newDR.Item("rate").ToString

                Dim equiptypeid As Integer = CInt(newDR.Item("equipTypeID").ToString)
                'Dim rate As Double = Get_Equipment_Rate(equiptypeid)
                Dim rate As Double = CDbl(Val(newDR.Item("rate").ToString))
                Dim er_no As String = newDR.Item("er_no").ToString
                Dim plateno As String = newDR.Item("plate_no").ToString
                'Dim date_received As String = check_received_date(newDR.Item("req_ID").ToString)
                Dim date_received As String = newDR.Item("date_received").ToString
                'Dim date_turnover As String = check_turnover_date(newDR.Item("req_ID").ToString)
                Dim date_turnover As String = newDR.Item("date_turnover").ToString
                Dim is_this_light_equip As Integer = CInt(newDR.Item("light_equipment").ToString)
                'Dim is_this_light_equip As Integer = check_light_exemption(equiptypeid)
                Dim noofdays As Integer

                Dim rangefrom As DateTime = Date.Parse("01-01-2017")
                Dim rangeto As DateTime = Date.Parse(Now)

                Dim drec_month, dtur_month, dtur_year, drec_year As Integer

                If is_this_light_equip > 0 Then
                    GoTo proceedhere
                Else

                End If

                '*******************************
                '*      FOR DATE RECEIVED
                '*******************************
                If date_received = "" Then
                    date_received = "waiting..."
                Else
                    date_received = date_received
                    drec_month = Date.Parse(date_received).Month
                    drec_year = Date.Parse(date_received).Year

                    'If MonthDifference(Date.Parse(DTPFrom.Text), Date.Parse(date_received)) > 0 Then
                    '    n += 1
                    'End If
                End If

                '*******************************
                '*      FOR DATE TURNOVER
                '*******************************


                If date_turnover = "" Then
                    date_turnover = "waiting..."
                Else
                    date_turnover = date_turnover
                    dtur_month = Date.Parse(date_turnover).Month
                    dtur_year = Date.Parse(date_turnover).Year

                    'If MonthDifference(Date.Parse(DTPFrom.Text), Date.Parse(date_turnover)) > 0 Then
                    '    n1 += 1
                    'End If
                End If

                If date_received <> "waiting..." And date_turnover = "waiting..." Then

                    If drec_month = Date.Parse("01-01-2017").Month _
                    And drec_year = Date.Parse("01-01-2017").Year Then

                        noofdays = calc_number_of_days(Date.Parse(Now), Date.Parse(date_received))
                        noofdays = IIf(noofdays < 0, 0, noofdays)

                        a(9) = cal_equip_req_charges(Date.Parse(date_received), noofdays, rate)
                    Else

                        noofdays = calc_number_of_days(Date.Parse(Now), Date.Parse("01-01-2017"))
                        a(9) = cal_equip_req_charges(Date.Parse("01-01-2017"), noofdays, rate)
                    End If

                ElseIf date_received <> "waiting..." And date_turnover <> "waiting..." Then

                    If if_this_date_exist(Date.Parse(date_turnover)) = True Then

                        If if_this_date_exist(Date.Parse(date_received)) = True Then
                            noofdays = calc_number_of_days(Date.Parse(date_turnover), Date.Parse(date_received))
                            a(9) = cal_equip_req_charges(Date.Parse(date_received), noofdays, rate)

                        Else
                            noofdays = calc_number_of_days(Date.Parse(date_turnover), datefrom)
                            a(9) = cal_equip_req_charges(Date.Parse("01-01-2017"), noofdays, rate)
                        End If

                    Else
                        If Date.Parse(date_turnover) > Now Then

                            If Date.Parse(date_received) < "01-01-2017" Then
                                noofdays = calc_number_of_days(dto, dfrom)
                                a(9) = cal_equip_req_charges(Date.Parse(dfrom), noofdays, rate)
                            Else
                                noofdays = calc_number_of_days(dto, date_received)
                                a(9) = cal_equip_req_charges(Date.Parse(date_received), noofdays, rate)
                            End If

                        End If
                    End If


                End If

                If noofdays <= 0 Then
                    GoTo proceedhere
                End If

                Dim month As Integer = 0
                Dim counter As Integer = 1
                Dim days As Integer = 0
                Dim year As Integer = 0
                Dim total As Double
                Dim lastdate As DateTime

                'Dim gg As String

                'For I = 1 To noofdays - 1
                '    days += 1

                '    If datefrom.AddDays(I) = datefrom.AddMonths(counter) Then

                '        month += 1
                '        counter += 1
                '        days = 0
                '    End If

                '    lastdate = datefrom.AddDays(I)

                'Next

                '********************************** *
                'm - 0, para sa lvl_light_details   *
                'm - 1, para sa lvlEquipCharges     *
                '********************************** *

                If m = 0 Then
                ElseIf m = 1 Then
                    'light_heavy_equipment_Details1 += CDbl(a(9))

                    'how_many = get_no_of_request(er_no, plateno)
                    'Dim total_noofdays As String

                    'If how_many > 0 Then
                    '    total_noofdays = FormatNumber(Decimal.Parse((noofdays / 31) / how_many))
                    'ElseIf how_many = 0 Then
                    '    total_noofdays = FormatNumber(Decimal.Parse(noofdays / 31))
                    'End If

                    'light_heavy_equipment_Details1 += FormatNumber((CDbl(rate) * CDbl(total_noofdays)), 2, , TriState.True)

                    'GoTo proceedhere
                End If

                'result = IIf(month > 1, month & " months", month & " month") & _
                '   " and " & _
                '   IIf(days - 1 > 1, days & " days", days & " day")

                a(0) = newDR.Item("req_ID").ToString
                a(1) = newDR.Item("equip_typeOf").ToString
                a(2) = newDR.Item("plate_no").ToString
                a(3) = newDR.Item("er_no").ToString
                'a(4) = noofdays

                how_many = get_no_of_request(a(3), a(2))

                If how_many > 0 Then
                    a(4) = FormatNumber(Decimal.Parse(noofdays / 31) / how_many)
                ElseIf how_many = 0 Then
                    a(4) = FormatNumber(Decimal.Parse(noofdays / 31))
                End If

                'a(5) = result
                a(6) = date_received
                a(7) = date_turnover
                a(8) = FormatNumber(rate, 2, , TriState.True)
                a(9) = FormatNumber((CDbl(a(8)) * CDbl(a(4))), 2, , TriState.True)

                If date_received = "waiting..." Then
                    GoTo proceedhere
                Else
                    If Date.Parse(date_received) > Date.Parse(dto) Then
                        GoTo proceedhere
                    End If
                End If

                If n = 1 Then
                    Dim lvl As New ListViewItem(a)
                    'FEquipment_Charges_new.lvl_light_details.Items.Add(lvl)
                Else
                    ' If n = 0 And m = 0 Then
                    light_heavy_equipment_Details1 += FormatNumber(CDbl(a(9)), 2, , , TriState.True)
                    ' End If

                End If


proceedhere:

                noofdays = Nothing
                month = Nothing
                days = Nothing
                year = Nothing
                counter = Nothing



            End While

            newDR.Close()

            Dim grandtotal As Double

            'If bol = False Then
            'Else
            '    For i = 0 To lvl_light_details.Items.Count - 1
            '        grandtotal += CDbl(lvl_light_details.Items(i).SubItems(9).Text)
            '    Next
            'End If

            ' lblGrandTotal.Text = "INCREASE FROM " & datefrom & " TO " & dateto & " : " & FormatNumber(grandtotal, 2, 0, 0, TriState.True) ' AS OF " & character_month(Date.Parse(datefrom).Month) & " : " & FormatNumber(grandtotal, 2, 0, 0, TriState.True)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & ex.StackTrace() & vbCrLf & "THE ERROR: " & a(10) & vbCrLf & "Info: " & ex.Message, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection1.Close()
        End Try
    End Function

    Public Function calc_number_of_days(ByVal dfrom As Date, ByVal dto As Date) As Double

        Dim span = dfrom - dto

        calc_number_of_days = span.TotalDays + 1

    End Function

    Public Function cal_equip_req_charges(ByVal d As DateTime, ByVal noofdays As Integer, ByVal rate As Double) As Double
        Dim sd As Integer
        Dim bb As DateTime
        Dim total As Double
        Dim nn As Double
        Dim lastday As Integer

        For I = 1 To noofdays - 1

            'MsgBox(d.AddDays(I))
            sd = sd + 1
            If d.AddDays(I).Day = 1 Then
                'MsgBox(n)
                'MsgBox(d.AddDays(I - 1).Day - d.Day & vbCrLf & d.AddDays(I - 1))
                total += (sd / d.AddDays(I - 1).Day) * rate
                sd = 0
            End If

            bb = d.AddDays(I)
        Next
        'MsgBox(n + 1 & " hahahaha" & " " & bb)
        lastday = CInt(LastDayOfMonth(bb).Day)

        nn = ((CInt(sd + 1) / lastday)) * rate
        cal_equip_req_charges = nn + total

    End Function

    Public Function if_this_date_exist(ByVal dd As DateTime) As Boolean

        For i = 0 To calc_number_of_days(Date.Parse(dto), Date.Parse(dfrom)) - 1
            If Date.Parse(dfrom).AddDays(i) = dd Then
                if_this_date_exist = True
            End If

        Next

    End Function

    Public Function get_no_of_request(ByVal id As Integer, ByVal plateno As String)

        Dim newsqlcon As New SQLcon
        Dim newdr As SqlDataReader
        Dim numrows As Integer

        Try
            newsqlcon.connection1.Open()

            publicquery = "SELECT COUNT(*)FROM dbequipment_request a INNER JOIN dbequipment_list b ON a.equipListID = b.equipListID WHERE a.er_no = '" & id & "' AND b.plate_no = '" & plateno & "'"
            cmd = New SqlCommand(publicquery, newsqlcon.connection1)
            numrows = cmd.ExecuteScalar

            get_no_of_request = numrows

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & ex.StackTrace() & vbCrLf & "THE ERROR: " & vbCrLf & "Info: " & ex.Message, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection1.Close()
        End Try

    End Function
    Public Function light_exempted_from_eu(ByVal proj As String, ByVal dFrom As DateTime, ByVal dTo As DateTime) As Double

        Dim newSQ As New SQLcon
        Dim newDR As SqlDataReader
        Dim newCMD As SqlCommand

        Try
            newSQ.connection1.Open()

            newCMD = New SqlCommand("proc_eu_charges", newSQ.connection1)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 102)
            newCMD.Parameters.AddWithValue("@project", proj)
            newCMD.Parameters.AddWithValue("@from", dFrom)
            newCMD.Parameters.AddWithValue("@to", Now)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim rate As Double = CDbl(newDR.Item("rate").ToString)

                'If check_light_exemption(newDR.Item("equipTypeID").ToString) > 0 Then
                light_exempted_from_eu += totaltime(newDR.Item("start_time").ToString, newDR.Item("end_time").ToString, True) * rate
                'Else

                'End If
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection1.Close()
        End Try
    End Function

    Public Function check_received_date(ByVal reqID As Integer) As String
        Dim newsqlcon As New SQLcon
        Dim newcmd As SqlCommand
        Dim newsqldr As SqlDataReader

        Try
            newsqlcon.connection1.Open()
            Dim query As String = "SELECT * FROM dbequipment_received WHERE req_ID = " & reqID
            newcmd = New SqlCommand(query, newsqlcon.connection1)
            'numrows = newcmd.ExecuteScalar()
            newsqldr = newcmd.ExecuteReader

            While newsqldr.Read
                check_received_date = Format(Date.Parse(newsqldr.Item("date_received").ToString), "MM/dd/yyyy")
            End While
            newsqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & ex.StackTrace() & vbCrLf & "Info: " & ex.Message, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection1.Close()
        End Try
    End Function


    Public Function check_turnover_date(ByVal reqID As Integer) As String
        Dim newsqlcon1 As New SQLcon
        Dim newcmd1 As SqlCommand
        Dim newsqldr1 As SqlDataReader

        Try
            newsqlcon1.connection1.Open()
            Dim query As String = "SELECT * FROM dbequipment_turnover WHERE req_ID = " & reqID
            newcmd1 = New SqlCommand(query, newsqlcon1.connection1)
            newsqldr1 = newcmd1.ExecuteReader

            While newsqldr1.Read
                check_turnover_date = Format(Date.Parse(newsqldr1.Item("date_turnover").ToString), "MM/dd/yyyy")
            End While
            newsqldr1.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & ex.StackTrace() & vbCrLf & "Info: " & ex.Message, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon1.connection1.Close()
        End Try
    End Function

    Public Function check_light_exemption(ByVal id As Integer) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try

            newSQ.connection1.Open()
            Dim query As String = "SELECT * FROM dblight_exemption WHERE equipTypeID = " & id
            newCMD = New SqlCommand(query, newSQ.connection1)
            newDR = newCMD.ExecuteReader
            While newDR.Read
                check_light_exemption += 1
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection1.Close()
        End Try

    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' view_report()
        Panel6.Visible = True
    End Sub
    Public Sub view_report()


        Dim dt As New DataTable

        With dt
            .Columns.Add("item_no")
            .Columns.Add("item_description")
            .Columns.Add("contract_unit")
            .Columns.Add("contract_qty")
            .Columns.Add("contract_unit_cost")
            .Columns.Add("contract_total_cost")
            .Columns.Add("budgetary_unit")
            .Columns.Add("budgetry_quantity")
            .Columns.Add("actual_unit")
            .Columns.Add("actual_qty")
            .Columns.Add("actual_unit_cost")
            .Columns.Add("actual_total_cost")
        End With

        For i As Integer = 0 To ListView1.Items.Count - 1
            dt.Rows.Add(ListView1.Items(i).SubItems(0).Text, ListView1.Items(i).SubItems(1).Text,
            ListView1.Items(i).SubItems(2).Text, ListView1.Items(i).SubItems(3).Text,
            ListView1.Items(i).SubItems(4).Text, ListView1.Items(i).SubItems(5).Text,
            ListView1.Items(i).SubItems(6).Text, ListView1.Items(i).SubItems(7).Text,
            ListView1.Items(i).SubItems(8).Text, ListView1.Items(i).SubItems(9).Text,
            ListView1.Items(i).SubItems(10).Text, ListView1.Items(i).SubItems(11).Text)

        Next

        'For Each item As ListViewItem In Me.ListView1.Items
        'Next

        Dim view As New DataView(dt)

        FProject_Cost_Report.ReportViewer1.LocalReport.DataSources.Item(0).Value = view
        FProject_Cost_Report.ShowDialog()
        FProject_Cost_Report.Dispose()

    End Sub

    Private Sub btn_proceed_Click(sender As Object, e As EventArgs) Handles btn_proceed.Click
        view_report()
    End Sub

    Private Sub txt_preparedby_TextChanged(sender As Object, e As EventArgs) Handles txt_preparedby.TextChanged, txt_approvedby.TextChanged
        txtbox = sender
        With ListBox1
            .Location = New System.Drawing.Point(txtbox.Location.X, txtbox.Location.Y + txtbox.Height)
            .Width = txtbox.Width
            .Parent = Panel6
            .BringToFront()

            If txtbox.Text = "" Then
                .Visible = False
            Else
                .Visible = True
                list_box(txtbox, ListBox1)
            End If
        End With
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Panel6.Visible = False
        ListBox1.Visible = False

    End Sub
    Public Function list_box(ByVal textbox As TextBox, list As ListBox) As String
        With list
            .Items.Clear()
            Dim n As Integer
            Dim newSQ As New SQLcon
            Dim newCMD As SqlCommand
            Dim newDR As SqlDataReader
            Dim query As String
            Try
                newSQ.connection.Open()
                query = "select name from tblUsers where name like '%' + '" & textbox.Text & "'+ '%' "
                newCMD = New SqlCommand(query, newSQ.connection)
                newDR = newCMD.ExecuteReader

                While newDR.Read
                    .Items.Add(newDR.Item("name").ToString)
                End While
                newDR.Close()

                If .Items.Count > 0 Then
                    .Visible = True
                Else
                    .Visible = False
                End If
            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection1.Close()
            End Try
        End With
    End Function

    Private Sub txt_preparedby_GotFocus(sender As Object, e As EventArgs) Handles txt_preparedby.GotFocus, txt_approvedby.GotFocus
        If txt_preparedby.Focused Then
            textname = txt_preparedby.Name
        ElseIf txt_approvedby.Focused Then
            textname = txt_approvedby.Name
        End If
    End Sub

    Private Sub txt_preparedby_HandleCreated(sender As Object, e As EventArgs) Handles txt_preparedby.HandleCreated

    End Sub

    Private Sub txt_preparedby_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_preparedby.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
            If ListBox1.Visible = True Then
                If ListBox1.Items.Count > 0 Then
                    ListBox1.Focus()
                    ListBox1.SelectedIndex = 0
                End If
            Else
            End If
        End If
    End Sub

    Private Sub ListBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            For Each ctr As Control In Panel6.Controls
                If ctr.Name = textname Then
                    ctr.Text = ListBox1.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next
            ListBox1.Visible = False
        End If

        If ListBox1.SelectedIndex = 0 Then
            If e.KeyCode = Keys.Up Then
                txtbox.Focus()
            End If
        End If
    End Sub

    Private Sub txt_approvedby_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_approvedby.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
            If ListBox1.Visible = True Then
                If ListBox1.Items.Count > 0 Then
                    ListBox1.Focus()
                    ListBox1.SelectedIndex = 0
                End If
            Else
            End If
        End If
    End Sub

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        For Each ctr As Control In Panel6.Controls
            If ctr.Name = textname Then
                ctr.Text = ListBox1.SelectedItem.ToString
                ctr.Focus()
            End If
        Next
        ListBox1.Visible = False
    End Sub
End Class