Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Threading
Imports Microsoft.Office.Interop

Public Class FAggregates_General_Request2
    Dim thread As System.Threading.Thread
    Dim row_index As Integer
    Dim counter, counter1, counter2, counter3 As Integer
    Dim last As Boolean = False
    Dim starting As Integer = 0
    Public temp_sto_proj As String = ""
    Dim listview2_index As Integer
    Private Sub FAggregates_General_Request2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView2.Items.Clear()
        load_projects()

        Panel5.Location = New Point(1000, 1000)
    End Sub
    Private Sub load_projects()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        lvlProject.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_aggregates_general_request1", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 2)

            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                lvlProject.Items.Add(newDR.Item("project").ToString)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub btnLoadProject_Click(sender As Object, e As EventArgs) Handles btnLoadProject.Click
        If Application.OpenForms().OfType(Of FRequistionForm).Any Then

        Else
            form_active("FRequistionForm")
        End If


        Dim a(10) As String

        ListView1.Items.Clear()
        ListView2.Items.Clear()
        listview2_index = 0

        row_index = 0
        counter = 0

        For Each row As ListViewItem In lvlProject.Items
            If row.Checked = True Then

                a(1) = row.Text
                a(2) = "-"
                a(3) = "-"
                a(5) = "A"

                Dim lvl As New ListViewItem(a)
                lvl.BackColor = Color.Orange
                lvl.Font = New Font("Arial", 11, FontStyle.Bold)

                ListView1.Items.Add(lvl)

                Dim a2(10) As String

                'For Each aggregates As String In cmbItems.Items

                '    a2(1) = row.Text
                '    a2(2) = aggregates
                '    a2(5) = "B"
                '    Dim lvl1 As New ListViewItem(a2)
                '    lvl1.BackColor = Color.Yellow
                '    lvl1.Font = New Font("Arial", 10, FontStyle.Bold)
                '    ListView1.Items.Add(lvl1)
                'Next

                a2(1) = row.Text
                a2(2) = ""
                a2(5) = "B"
                Dim lvl1 As New ListViewItem(a2)
                lvl1.BackColor = Color.Yellow
                lvl1.Font = New Font("Arial", 10, FontStyle.Bold)
                ListView1.Items.Add(lvl1)
            End If
        Next

        For Each row As ListViewItem In ListView1.Items
            If row.BackColor = Color.Yellow Then
                counter += 1
            End If
        Next

        'tig_next2.Start()
        Button1.PerformClick()


    End Sub
    Private Sub threading_process(row_index1 As Integer, main_qty As Decimal)
        'load ang mga request sa kini nga row
        Dim STthread_Data As search_wh_data

        STthread_Data.project = ListView1.Items(row_index1).SubItems(1).Text
        STthread_Data.search = ListView1.Items(row_index1).SubItems(4).Text
        STthread_Data.item = ListView1.Items(row_index1).SubItems(2).Text
        STthread_Data.row_index1 = row_index1
        STthread_Data.main_qty = main_qty

        thread = New Threading.Thread(AddressOf load_main_rs_qty)
        thread.SetApartmentState(ApartmentState.MTA)
        thread.Start(STthread_Data)

    End Sub
    Private Sub threading_process2(row_index1 As Integer)
        'load ang mga request sa kini nga row
        Dim STthread_Data As search_wh_data

        STthread_Data.project = ListView1.Items(row_index1).SubItems(1).Text
        STthread_Data.search = ListView1.Items(row_index1).SubItems(2).Text
        STthread_Data.row_index1 = row_index1


        thread = New Threading.Thread(AddressOf load_main_rs_qty1)
        thread.SetApartmentState(ApartmentState.MTA)
        thread.Start(STthread_Data)

    End Sub
    Private Sub load_main_rs_qty1(ByVal STthread_Data As search_wh_data)

        Dim project As String = STthread_Data.project
        Dim search As String = STthread_Data.search
        Dim row_index1 As Integer = STthread_Data.row_index1

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_aggregates_general_request1", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 3)
            newCMD.Parameters.AddWithValue("@project", project)
            newCMD.Parameters.AddWithValue("@search", search)

            newDR = newCMD.ExecuteReader

            While newDR.Read


                If ListView1.InvokeRequired Then
                    ListView1.Invoke(Sub()
                                         With ListView1.Items.Insert(row_index + row_index1 + 1, "", row_index + row_index1 + 1)
                                             .SubItems.Add(project)
                                             .SubItems.Add(search)
                                             .SubItems.Add(newDR.Item("rs_main_qty").ToString)
                                             .SubItems.Add(newDR.Item("rs_no").ToString)
                                             .SubItems.Add("")
                                             .SubItems.Add("")
                                             .BackColor = Color.LightPink
                                             .Font = New Font("Arial", 12, FontStyle.Regular)
                                         End With
                                     End Sub)
                Else
                    With ListView1.Items.Insert(row_index + row_index1 + 1, "", row_index + row_index1 + 1)
                        .SubItems.Add(project)
                        .SubItems.Add(search)
                        .SubItems.Add(newDR.Item("rs_main_qty").ToString)
                        .SubItems.Add(newDR.Item("rs_no").ToString)
                        .BackColor = Color.LightPink
                        .Font = New Font("Arial", 12, FontStyle.Regular)
                    End With
                End If

                row_index += 1
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub load_main_rs_qty(ByVal STthread_Data As search_wh_data)

        Dim project As String = STthread_Data.project
        Dim search As String = STthread_Data.search
        Dim row_index1 As Integer = STthread_Data.row_index1
        Dim item As String = STthread_Data.item
        Dim total_balance As Decimal
        Dim main_qty As Decimal = STthread_Data.main_qty
        Dim rs_no As String = ""

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_aggregates_general_request1", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 4)
            newCMD.Parameters.AddWithValue("@project", project)
            newCMD.Parameters.AddWithValue("@item", item)
            newCMD.Parameters.AddWithValue("@search", search)

            newDR = newCMD.ExecuteReader

            While newDR.Read


                If ListView1.InvokeRequired Then
                    ListView1.Invoke(Sub()

                                         If newDR.Item("whItemDesc").ToString.ToUpper = "FINE SAND" Then

                                         ElseIf newDR.Item("whItemDesc").ToString.ToUpper = "3/4 GRAVEL" Then

                                         ElseIf newDR.Item("whItemDesc").ToString.ToUpper = "SCREEN SAND" Then

                                         ElseIf newDR.Item("whItemDesc").ToString.ToUpper = "G-1" Then

                                         ElseIf newDR.Item("whItemDesc").ToString.ToUpper = "OVERSIZE G-1" Then

                                         ElseIf newDR.Item("whItemDesc").ToString.ToUpper = "3/8 GRAVEL" Then

                                         Else
                                             GoTo procceedhere2
                                         End If

                                         With ListView1.Items.Insert(row_index + row_index1 + 1, newDR.Item("rs_id").ToString, row_index + row_index1 + 1)
                                             .SubItems.Add(newDR.Item("charges").ToString)
                                             .SubItems.Add(newDR.Item("item_desc").ToString & " (" & newDR.Item("whItemDesc").ToString & ")")
                                             .SubItems.Add(newDR.Item("rs_qty").ToString)
                                             .SubItems.Add(newDR.Item("rs_no").ToString)
                                             .SubItems.Add("")
                                             .SubItems.Add("")
                                             .SubItems.Add(newDR.Item("ws_qty_received").ToString)
                                             .SubItems.Add(newDR.Item("delivered").ToString)
                                             .SubItems.Add(IIf(newDR.Item("type_of_purchasing").ToString = "DR", CDbl(newDR.Item("rs_qty").ToString) - CDbl(newDR.Item("delivered").ToString), CDbl(newDR.Item("rs_qty").ToString) - CDbl(newDR.Item("ws_qty_received").ToString)))
                                             .SubItems.Add(Format(Date.Parse(newDR.Item("date_req").ToString), "MM/dd/yyyy"))
                                             .SubItems.Add(newDR.Item("whItemDesc").ToString)
                                             .BackColor = Color.LightYellow
                                             .Font = New Font("Arial", 9, FontStyle.Regular)

                                         End With

                                         total_balance += IIf(newDR.Item("type_of_purchasing").ToString = "DR", CDbl(newDR.Item("rs_qty").ToString) - CDbl(newDR.Item("delivered").ToString), CDbl(newDR.Item("rs_qty").ToString) - CDbl(newDR.Item("ws_qty_received").ToString))
                                         main_qty -= CDbl(newDR.Item("rs_qty").ToString)
                                         row_index += 1
                                         rs_no = newDR.Item("rs_no").ToString

procceedhere2:

                                     End Sub)
                Else
                    If newDR.Item("whItemDesc").ToString.ToUpper = "FINE SAND" Then

                    ElseIf newDR.Item("whItemDesc").ToString.ToUpper = "3/4 GRAVEL" Then

                    ElseIf newDR.Item("whItemDesc").ToString.ToUpper = "SCREEN SAND" Then

                    ElseIf newDR.Item("whItemDesc").ToString.ToUpper = "G-1" Then

                    ElseIf newDR.Item("whItemDesc").ToString.ToUpper = "OVERSIZE G-1" Then

                    ElseIf newDR.Item("whItemDesc").ToString.ToUpper = "3/8 GRAVEL" Then

                    Else
                        GoTo procceedhere2
                    End If

                    With ListView1.Items.Insert(row_index + row_index1 + 1, newDR.Item("rs_id").ToString, row_index + row_index1 + 1)
                        .SubItems.Add(newDR.Item("charges").ToString)
                        .SubItems.Add(newDR.Item("item_desc").ToString & " (" & newDR.Item("whItemDesc").ToString & ")")
                        .SubItems.Add(newDR.Item("rs_qty").ToString)
                        .SubItems.Add(newDR.Item("rs_no").ToString)
                        .SubItems.Add("")
                        .SubItems.Add("")
                        .SubItems.Add(newDR.Item("ws_qty_received").ToString)
                        .SubItems.Add(newDR.Item("delivered").ToString)
                        .SubItems.Add(IIf(newDR.Item("type_of_purchasing").ToString = "DR", CDbl(newDR.Item("rs_qty").ToString) - CDbl(newDR.Item("delivered").ToString), CDbl(newDR.Item("rs_qty").ToString) - CDbl(newDR.Item("ws_qty_received").ToString)))
                        .SubItems.Add(Format(Date.Parse(newDR.Item("date_req").ToString), "MM/dd/yyyy"))
                        .SubItems.Add(newDR.Item("whItemDesc").ToString)
                        .BackColor = Color.LightYellow
                    End With

                    total_balance += IIf(newDR.Item("type_of_purchasing").ToString = "DR", CDbl(newDR.Item("rs_qty").ToString) - CDbl(newDR.Item("delivered").ToString), CDbl(newDR.Item("rs_qty").ToString) - CDbl(newDR.Item("ws_qty_received").ToString))
                    main_qty -= CDbl(newDR.Item("rs_qty").ToString)
                    row_index += 1
                    rs_no = newDR.Item("rs_no").ToString
procceedhere2:
                End If
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

            If ListView1.InvokeRequired Then
                ListView1.Invoke(Sub()
                                     With ListView1.Items.Insert(row_index + row_index1 + 1, "", row_index + row_index1 + 1)
                                         .SubItems.Add("")
                                         .SubItems.Add("Remaining Balance:")
                                         .SubItems .Add("")'.SubItems.Add(main_qty)
                                         .SubItems.Add(rs_no)
                                         .SubItems.Add("")
                                         .SubItems.Add("")
                                         .SubItems.Add("")
                                         .SubItems.Add("")
                                         .SubItems.Add(total_balance)

                                         .Font = New Font("Arial", 12, FontStyle.Bold)
                                     End With
                                 End Sub)
            Else
                With ListView1.Items.Insert(row_index + row_index1 + 1, "", row_index + row_index1 + 1)
                    .SubItems.Add("")
                    .SubItems.Add("Remaining Balance:")
                    .SubItems.Add("") '.SubItems.Add(main_qty)
                    .SubItems.Add("")
                    .SubItems.Add("")
                    .SubItems.Add("")
                    .SubItems.Add("")
                    .SubItems.Add("")
                    .SubItems.Add(total_balance)
                    .Font = New Font("Arial", 12, FontStyle.Bold)
                End With
            End If

            If tig_next2.Enabled = False Then
                'REMOVE ang mga walay labot
                If Button6.InvokeRequired Then
                    Button6.Invoke(Sub()
                                       Button6.PerformClick()
                                   End Sub)
                Else
                    Button6.PerformClick()
                End If
            End If

        End Try
    End Sub

    Private Sub load_main_rs_qty3(ByVal STthread_Data As search_wh_data)

        Dim project As String = STthread_Data.project
        Dim search As String = STthread_Data.search
        Dim row_index1 As Integer = STthread_Data.row_index1
        Dim item As String = STthread_Data.item
        Dim total_balance As Decimal
        Dim main_qty As Decimal = STthread_Data.main_qty

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_aggregates_general_request1", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 5)
            newCMD.Parameters.AddWithValue("@project", project)
            newCMD.Parameters.AddWithValue("@item", item)
            newCMD.Parameters.AddWithValue("@search", search)

            newDR = newCMD.ExecuteReader

            While newDR.Read


                If ListView1.InvokeRequired Then
                    ListView1.Invoke(Sub()
                                         With ListView1.Items.Insert(row_index + row_index1 + 1, newDR.Item("rs_id").ToString, row_index + row_index1 + 1)
                                             .SubItems.Add(newDR.Item("charges").ToString)
                                             .SubItems.Add(newDR.Item("item_desc").ToString & " (" & newDR.Item("whItemDesc").ToString & ")")
                                             .SubItems.Add(newDR.Item("rs_qty").ToString)
                                             .SubItems.Add(newDR.Item("rs_no").ToString)
                                             .SubItems.Add("")
                                             .SubItems.Add("")
                                             .SubItems.Add(newDR.Item("ws_qty_received").ToString)
                                             .SubItems.Add(newDR.Item("delivered").ToString)
                                             .SubItems.Add(IIf(newDR.Item("type_of_purchasing").ToString = "DR", CDbl(newDR.Item("rs_qty").ToString) - CDbl(newDR.Item("delivered").ToString), CDbl(newDR.Item("rs_qty").ToString) - CDbl(newDR.Item("ws_qty_received").ToString)))
                                             .SubItems.Add(Format(Date.Parse(newDR.Item("date_req").ToString), "MM/dd/yyyy"))
                                             .BackColor = Color.LightYellow
                                             .Font = New Font("Arial", 9, FontStyle.Regular)

                                         End With
                                     End Sub)
                Else
                    With ListView1.Items.Insert(row_index + row_index1 + 1, newDR.Item("rs_id").ToString, row_index + row_index1 + 1)
                        .SubItems.Add(newDR.Item("charges").ToString)
                        .SubItems.Add(newDR.Item("item_desc").ToString & " (" & newDR.Item("whItemDesc").ToString & ")")
                        .SubItems.Add(newDR.Item("rs_qty").ToString)
                        .SubItems.Add(newDR.Item("rs_no").ToString)
                        .SubItems.Add("")
                        .SubItems.Add("")
                        .SubItems.Add(newDR.Item("ws_qty_received").ToString)
                        .SubItems.Add(newDR.Item("delivered").ToString)
                        .SubItems.Add(IIf(newDR.Item("type_of_purchasing").ToString = "DR", CDbl(newDR.Item("rs_qty").ToString) - CDbl(newDR.Item("delivered").ToString), CDbl(newDR.Item("rs_qty").ToString) - CDbl(newDR.Item("ws_qty_received").ToString)))
                        .SubItems.Add(Format(Date.Parse(newDR.Item("date_req").ToString), "MM/dd/yyyy"))
                        .BackColor = Color.LightYellow
                    End With
                End If

                total_balance += IIf(newDR.Item("type_of_purchasing").ToString = "DR", CDbl(newDR.Item("rs_qty").ToString) - CDbl(newDR.Item("delivered").ToString), CDbl(newDR.Item("rs_qty").ToString) - CDbl(newDR.Item("ws_qty_received").ToString))
                main_qty -= CDbl(newDR.Item("rs_qty").ToString)

                row_index += 1
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

        End Try
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs)
        row_index = 0
        tig_next.Start()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not thread.IsAlive Then
            Timer1.Stop()
            Panel2.Visible = False

        End If
    End Sub

    Public Structure search_wh_data

        Dim project As String
        Dim search As String
        Dim row_index1 As Integer
        Dim item As String
        Dim main_qty As Decimal

    End Structure

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        'Dim row_index1 As Integer = row_index

        'If counter = 3 Then

        '    If last = True Then
        '        Timer2.Stop()
        '    Else
        '        Timer2.Stop()
        '        tig_next.Start()
        '    End If

        '    counter = 0
        'Else
        '    ListBox2.Items.Add(counter)

        '    If last = True Then
        '        row_index1 += 1
        '    End If

        '    ListView1.Items.Insert(row_index1, "image", row_index1).SubItems.Add(counter)
        '    counter += 1
        '    row_index += 1

        'End If


        If Not thread.IsAlive Then
            Panel2.Visible = False
            Timer3.Stop()
        Else

        End If
    End Sub

    Private Sub tig_next2_Tick(sender As Object, e As EventArgs) Handles tig_next2.Tick
        If IsNothing(thread) Then
            insert_sub()
        Else
            If Not thread.IsAlive Then
                insert_sub()

            End If
        End If
    End Sub

    Private Sub insert_sub()
        Panel2.Visible = True
        Timer3.Start()

        row_index = 0
        Dim main_qty As Decimal = 0

        For Each row As ListViewItem In ListView1.Items
            If row.BackColor = Color.LightPink Then
                If row.SubItems(6).Text = "Done" Then

                Else
                    main_qty = IIf(row.SubItems(3).Text = "", 0, row.SubItems(3).Text)
                    row.SubItems(6).Text = "Done"
                    threading_process(row.Index, main_qty)
                    Exit For
                End If
            End If
        Next

        Dim donecounter As Integer

        For Each row As ListViewItem In ListView1.Items
            If row.BackColor = Color.LightPink Then
                If row.SubItems(6).Text = "Done" Then
                    donecounter += 1
                End If
            End If
        Next

        '- humana tanan og process
        If donecounter = counter Then
            tig_next2.Stop()
        End If
    End Sub

    Private Sub insert_sub2()
        Panel2.Visible = True
        Timer3.Start()

        row_index = 0
        'Dim main_qty As Decimal = 0

        For Each row As ListViewItem In ListView1.Items
            If row.BackColor = Color.Yellow Then
                If row.SubItems(6).Text = "Done" Then

                Else
                    'main_qty = IIf(row.SubItems(3).Text = "", 0, row.SubItems(3).Text)
                    row.SubItems(6).Text = "Done"
                    threading_process2(row.Index)
                    Exit For
                End If
            End If
        Next

        Dim donecounter As Integer

        For Each row As ListViewItem In ListView1.Items
            If row.BackColor = Color.Yellow Then
                If row.SubItems(6).Text = "Done" Then
                    donecounter += 1
                End If
            End If
        Next

        If donecounter = counter Then
            tig_next3.Stop()
        End If
    End Sub

    Private Sub insert_sub1()
        Panel2.Visible = True
        Timer3.Start()

        row_index = 0
        Dim main_qty As Decimal = 0

        For Each row As ListViewItem In ListView1.Items
            If row.BackColor = Color.Yellow Then
                If row.SubItems(6).Text = "Done" Then

                Else
                    main_qty = IIf(row.SubItems(3).Text = "", 0, row.SubItems(3).Text)
                    row.SubItems(6).Text = "Done"
                    threading_process(row.Index, main_qty)
                    Exit For
                End If
            End If
        Next

        Dim donecounter As Integer

        For Each row As ListViewItem In ListView1.Items
            If row.BackColor = Color.Yellow Then
                If row.SubItems(6).Text = "Done" Then
                    donecounter += 1
                End If
            End If
        Next

        If donecounter = counter Then
            tig_next2.Stop()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel2.Visible = True
        Timer3.Start()

        row_index = 0
        Dim main_qty As Decimal = 0

        For Each row As ListViewItem In ListView1.Items
            If row.BackColor = Color.Yellow Then
                If row.SubItems(6).Text = "Done" Then

                Else
                    main_qty = IIf(row.SubItems(3).Text = "", 0, row.SubItems(3).Text)
                    row.SubItems(6).Text = "Done"
                    Dim row_index1 As Integer = row.Index
                    threading_process(row_index1, main_qty)
                    Exit For
                End If
            End If
        Next

        Dim donecounter As Integer

        For Each row As ListViewItem In ListView1.Items
            If row.BackColor = Color.Yellow Then
                If row.SubItems(6).Text = "Done" Then
                    donecounter += 1
                End If
            End If
        Next

        If donecounter = counter Then
            tig_next2.Stop()
        End If
    End Sub

    Private Sub tig_next3_Tick(sender As Object, e As EventArgs) Handles tig_next3.Tick
        If IsNothing(thread) Then
            insert_sub2()
        Else
            If Not thread.IsAlive Then
                insert_sub2()
            End If
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        tig_next3.Start()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        counter = 0
        counter1 = 0

        For Each row As ListViewItem In ListView1.Items
            If row.BackColor = Color.LightPink Then
                counter += 1
            End If
        Next

        tig_next2.Start()

    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        threading_process(ListView1.SelectedItems(0).Index, IIf(ListView1.SelectedItems(0).SubItems(3).Text = "", 0, ListView1.SelectedItems(0).SubItems(3).Text))
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        For Each row As ListViewItem In lvlProject.Items
            If row.Checked = True Then
                For Each a As String In ComboBox1.Items
                    load_non_item_check(a, row.Text)
                Next
            End If
        Next

    End Sub

    Private Sub load_non_item_check(item As String, project As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_aggregates_general_request1", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 5)
            newCMD.Parameters.AddWithValue("@item", item)
            newCMD.Parameters.AddWithValue("@project ", project)
            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                a(0) = newDR.Item("rs_id").ToString
                a(1) = newDR.Item("charges").ToString
                a(2) = newDR.Item("item_desc").ToString
                a(3) = newDR.Item("rs_qty").ToString
                a(4) = newDR.Item("rs_no").ToString
                a(10) = newDR.Item("date_req").ToString

                Dim lvl As New ListViewItem(a)
                ListView1.Items.Add(lvl)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        counter3 = 0
        counter2 = 0

        ListView2.Items.Clear()

        If ListView1.InvokeRequired Then
            ListView1.Invoke(Sub()
                                 For Each row As ListViewItem In ListView1.Items
                                     If row.BackColor = Color.LightPink Then
                                         If row.Index = ListView1.Items.Count - 1 Then
                                         Else
                                             If ListView1.Items(row.Index + 1).SubItems(2).Text = "Remaining Balance:" Then
                                                 'row.SubItems(6).Text = "Delete"
                                                 'ListView1.Items(row.Index + 1).SubItems(6).Text = "Delete"
                                                 ListView1.Items(row.Index + 1).Remove()
                                                 row.Remove()
                                             End If
                                         End If

                                     End If
                                 Next

                                 'OVER ALL TOTAL padong sa listview1
                                 counter2 = ListView1.Items.Count

                                 tig_calculate.Start()

                             End Sub)
        Else
            For Each row As ListViewItem In ListView1.Items
                If row.BackColor = Color.LightPink Then
                    If row.Index = ListView1.Items.Count - 1 Then
                    Else
                        If ListView1.Items(row.Index + 1).SubItems(2).Text = "Remaining Balance:" Then
                            'row.SubItems(6).Text = "Delete"
                            'ListView1.Items(row.Index + 1).SubItems(6).Text = "Delete"
                            ListView1.Items(row.Index + 1).Remove()
                            row.Remove()
                        End If
                    End If

                End If
            Next

            'OVER ALL TOTAL padong sa listview1
            counter2 = ListView1.Items.Count

            tig_calculate.Start()

        End If

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ListView2.Items.Clear()

        With FRequistionForm
            .total_finesand = 0 : .total_g1 = 0 : .total_screensand = 0 : .total_three_fourth = 0 : .total_three_eight = 0
            If Application.OpenForms().OfType(Of FRequistionForm).Any Then
            Else
                form_active("FRequistionForm")
                Me.TopMost = True
            End If
        End With

        counter1 = 0
        tig_next4.Start()


    End Sub

    Private Sub tig_check_sa_rs_Tick(sender As Object, e As EventArgs) Handles tig_check_sa_rs.Tick
        With FRequistionForm
            If Not .thread.IsAlive Then
                tig_check_sa_rs.Stop()
                tig_next4.Start()

            End If
        End With
    End Sub

    Private Sub tig_next_Tick(sender As Object, e As EventArgs) Handles tig_next.Tick

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

    End Sub

    Private Sub ExportRSToExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportRSToExcelToolStripMenuItem.Click
        Dim xlApp As New Excel.Application

        Try
            Dim SaveFileDialog1 As New SaveFileDialog
            SaveFileDialog1.Title = "Save Excel File"
            SaveFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx"
            SaveFileDialog1.ShowDialog()

            If SaveFileDialog1.FileName = "" Then
                Exit Sub
            End If

            'create objects to interface to Excel
            Dim xls As New Excel.Application
            Dim book As Excel.Workbook
            Dim sheet As Excel.Worksheet

            Dim chartRange As Excel.Range

            'create a workbook and get reference to first worksheet
            xls.Workbooks.Add()
            book = xls.ActiveWorkbook
            sheet = book.ActiveSheet
            'step through rows and columns and copy data to worksheet
            Dim row As Integer = 2
            Dim col As Integer = 1
            Dim c As Integer = 1
            Dim excel_array() As String = New String() {"RS NO", "PROJECT"}
            Dim excel_index As Integer = 1
            Dim iii As Integer = 0

            sheet.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange, sheet.Range("$A$1:$A$1"), , Excel.XlYesNoGuess.xlYes).Name = "Table1"

            '~~> Format the table
            sheet.ListObjects("Table1").TableStyle = "TableStyleLight9"

            sheet.Cells(1, 1) = "RS No."
            sheet.Cells(1, 1) = "PROJECT"

            'For Each item As ListViewItem In LVLEquipList.Items

            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Dim col1, row1 As Integer
            row1 = 2
            col1 = 1

            chartRange = sheet.Range("A" & 1, "B" & 2)
            chartRange.EntireColumn.NumberFormat = "@"

            For Each rows As ListViewItem In ListView2.Items
                'If rows.Selected = True Then

                sheet.Cells(row1, 1) = rows.Text
                sheet.Cells(row1, 2) = rows.SubItems(6).Text


                With chartRange

                    .HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter
                    .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    .Font.Size = 12
                    .Font.FontStyle = "Arial"
                    .EntireColumn.ColumnWidth = 15
                    '.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightYellow)

                    .Borders(Excel.XlBordersIndex.xlEdgeLeft).Weight = 2
                    .Borders(Excel.XlBordersIndex.xlEdgeRight).Weight = 2
                    .Borders(Excel.XlBordersIndex.xlEdgeTop).Weight = 2
                    .Borders(Excel.XlBordersIndex.xlEdgeBottom).Weight = 2
                    'chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)

                    '.Range("F" & col1).Formula = "=(E" & col1 & "-D" & col1 & ")*24*60/60"
                    .EntireColumn.AutoFit()

                End With

                row1 += 1

                'End If
            Next
            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            'save the workbook and clean up
            book.SaveAs(SaveFileDialog1.FileName)
            xls.Workbooks.Close()
            xls.Quit()
            releaseObject(sheet)
            releaseObject(book)
            releaseObject(xls)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        'Release an automation object
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub tig_total_Tick(sender As Object, e As EventArgs) Handles tig_total.Tick

        With FRequistionForm
            ' If IsNothing(.thread) Then
            If Not .thread.IsAlive Then
                    Dim a, b, c, d, f As Double
                    For Each row As ListViewItem In ListView2.Items

                        a += row.SubItems(1).Text
                        b += row.SubItems(2).Text
                        c += row.SubItems(3).Text
                        d += row.SubItems(4).Text
                        f += row.SubItems(5).Text

                    Next

                    Dim aa(10) As String
                    aa(0) = "TOTAL:"
                    aa(1) = a
                    aa(2) = b
                    aa(3) = c
                    aa(4) = d
                    aa(5) = f

                    Dim lvl As New ListViewItem(aa)
                    lvl.BackColor = Color.LightPink

                    ListView2.Items.Add(lvl)

                    tig_total.Stop()

                End If
        End With


    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        With FRequistionForm
            If IsNothing(.thread) Then
                .txtSearch.Text = TextBox2.Text
                .btnSearch.PerformClick()
                Exit Sub
            End If

            If Not .thread.IsAlive Then
                .txtSearch.Text = TextBox2.Text
                .btnSearch.PerformClick()
                Exit Sub
            ElseIf .thread.IsAlive Then
                MsgBox("Can't process")
            End If
        End With
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

    End Sub

    Private Function check_if_nag_process() As Integer
        With FRequistionForm
            If IsNothing(.thread) Then
                check_if_nag_process = 1
                Exit Function
            End If

            If Not .thread.IsAlive Then
                check_if_nag_process = 2
                Exit Function

            ElseIf .thread.IsAlive Then
                check_if_nag_process = 3
                Exit Function
            End If
        End With
    End Function

    Private Sub SelectAllToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem1.Click
        For Each row As ListViewItem In lvlProject.Items
            row.Checked = True
        Next
    End Sub

    Private Sub UnselectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnselectAllToolStripMenuItem.Click
        For Each row As ListViewItem In lvlProject.Items
            row.Checked = False
        Next
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

    End Sub

    Private Sub g(n As Integer)
        With FRequistionForm
            .cmbDivision.Text = "CRUSHING AND HAULING"
            .cmbSearchByCategory.Text = "Search by RS.No."

            .txtSearch.Text = ListView1.Items(n).SubItems(4).Text
            temp_sto_proj = ListView1.Items(n).SubItems(1).Text

            .btnSearch.PerformClick()
        End With

    End Sub
    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles tig_calculate.Tick
        '1 - wala pa sukad
        '2 - wala na nag process
        '3 - nag process pa 


        If ListView1.Items(listview2_index).BackColor = Color.LightPink Then

            Select Case check_if_nag_process()
                Case 1
                    g(listview2_index)
                    tig_calculate.Stop()
                    listview2_index += 1
                Case 2
                    g(listview2_index)
                    tig_calculate.Stop()
                    listview2_index += 1

                Case 3
                    tig_calculate.Stop()
            End Select

        Else
            listview2_index += 1
        End If

        If ListView1.Items.Count = listview2_index Then
            tig_calculate.Stop()
            listview2_index = 0
            tig_total.Start()
        Else
            tig_calculate.Start()
        End If


        '        If ListView1.Items(counter3).BackColor = Color.LightPink Then
        '            Label1.Text = ListView1.Items(counter3).SubItems(4).Text

        '            With FRequistionForm

        '                If IsNothing(.thread) Then
        '                    .cmbDivision.Text = "CRUSHING AND HAULING"
        '                    .cmbSearchByCategory.Text = "Search by RS.No."

        '                    .txtSearch.Text = ListView1.Items(counter3).SubItems(4).Text
        '                    temp_sto_proj = ListView1.Items(counter3).SubItems(1).Text

        '                    .btnSearch.PerformClick()

        '                    GoTo proccedhere

        '                End If


        '                If .thread.IsAlive = True Then
        '                    'tig_calculate.Stop()
        '                    GoTo proccedhere
        '                ElseIf .thread.IsAlive = False Then

        '                    .cmbDivision.Text = "CRUSHING AND HAULING"
        '                    .cmbSearchByCategory.Text = "Search by RS.No."

        '                    .txtSearch.Text = ListView1.Items(counter3).SubItems(4).Text
        '                    temp_sto_proj = ListView1.Items(counter3).SubItems(1).Text

        '                    .btnSearch.PerformClick()

        '                End If
        '            End With
        '        End If

        '        counter3 += 1

        '        If counter3 = counter2 Then

        '            tig_calculate.Stop()
        '            'tig_total.Start()


        '        End If

        'proccedhere:

    End Sub

    Private Sub tig_next4_Tick(sender As Object, e As EventArgs) Handles tig_next4.Tick


        If ListView1.Items(counter1).BackColor = Color.LightPink Then
            Label1.Text = ListView1.Items(counter1).SubItems(4).Text
            tig_next4.Stop()

            With FRequistionForm

                .cmbDivision.Text = "CRUSHING AND HAULING"
                .cmbSearchByCategory.Text = "Search by RS.No."

                .txtSearch.Text = ListView1.Items(counter1).SubItems(4).Text
                .project1 = ListView1.Items(counter1).SubItems(1).Text
                .btnSearch.PerformClick()
                tig_check_sa_rs.Start()

            End With
        End If

        counter1 += 1

        'FOR TOTAL
        Dim items_fs_total, items_g1_total, items_three_fourth, items_three_eight, items_screen_sand As Double

        If counter1 = ListView1.Items.Count - 1 Then
            Label1.Text = ListView1.Items(counter1).SubItems(4).Text
            tig_next4.Stop()

            Dim proj As String = ""
            For Each rows As ListViewItem In ListView2.Items
                If rows.Index = 0 Then
                    proj = rows.SubItems(6).Text
                End If

                If proj = rows.SubItems(6).Text Then
                    items_fs_total += rows.SubItems(1).Text
                    items_g1_total += rows.SubItems(2).Text
                    items_three_fourth += rows.SubItems(3).Text
                    items_three_eight += rows.SubItems(4).Text
                    items_screen_sand += rows.SubItems(5).Text
                Else
                    With ListView2.Items.Insert(rows.Index, "", rows.Index + 1)
                        .SubItems.Add(items_fs_total)
                        .SubItems.Add(items_g1_total)
                        .SubItems.Add(items_three_fourth)
                        .SubItems.Add(items_three_eight)
                        .SubItems.Add(items_screen_sand)
                        .SubItems.Add(proj)

                        .BackColor = Color.LightPink
                        .Font = New Font("Arial", 12, FontStyle.Bold)
                    End With

                    items_fs_total = 0
                    items_g1_total = 0
                    items_three_fourth = 0
                    items_three_eight = 0
                    items_screen_sand = 0

                    proj = rows.SubItems(6).Text

                    items_fs_total += rows.SubItems(1).Text
                    items_g1_total += rows.SubItems(2).Text
                    items_three_fourth += rows.SubItems(3).Text
                    items_three_eight += rows.SubItems(4).Text
                    items_screen_sand += rows.SubItems(5).Text

                End If
            Next

            'LAST ROW
            Dim a(6) As String

            a(0) = ""
            a(1) = items_fs_total
            a(2) = items_g1_total
            a(3) = items_three_fourth
            a(4) = items_three_eight
            a(5) = items_screen_sand
            a(6) = proj

            Dim lvl As New ListViewItem(a)
            lvl.BackColor = Color.LightPink
            lvl.Font = New Font("Arial", 12, FontStyle.Bold)
            ListView2.Items.Add(lvl)

            'With FRequistionForm
            '    .txtSearch.Text = ListView1.Items(counter1).SubItems(4).Text
            '    .btnSearch.PerformClick()
            '    tig_check_sa_rs.Start()
            'End With

            'With FRequistionForm
            '    If Not .thread.IsAlive Then
            '        Dim a(5) As String

            '        a(1) = .total_finesand
            '        a(2) = .total_g1
            '        a(3) = .total_three_fourth

            '        Dim lvl As New ListViewItem(a)
            '        ListView2.Items.Add(lvl)
            '    End If
            'End With
            Exit Sub
        End If

    End Sub
End Class