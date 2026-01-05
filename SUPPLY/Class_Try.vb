Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class Class_Try
    Private main_finesand, main_g1, main_34, main_mixed_boulders, main_waste, main_item_104, main_screen_sand, main_item_104_item_200_boulders, main_item_200 As Integer

    Public Sub YellowRow(lvl As ListView)
        Dim iniFile As String = Application.StartupPath & "\" & "AGGREGATES" & ".txt"
        Dim iniFile1 As String = Application.StartupPath & "\" & "AGGREGATES1" & ".txt"

        'If FileIO.FileSystem.FileExists(iniFile) = True Then
        '    'nag exist
        '    Dim objReader As New System.IO.StreamReader(iniFile)
        '    Dim lines As String

        '    Do While objReader.Peek() <> -1
        '        lines = lines & objReader.ReadLine().ToString & "=0" & vbCrLf
        '    Loop

        '    IO.File.WriteAllText(iniFile1, lines)

        'Else
        '    MsgBox("wala pani, buhatan sa nako og file!")
        '    FileIO.FileSystem.WriteAllText(iniFile, 0, True)
        'End If

        adding_ini_files(iniFile, 1)
        adding_ini_files(iniFile1, 2)

        get_aggregates_from_db(lvl)
        for_item_not_exist_in_db(lvl)
        set_remaining_balance(lvl)


    End Sub

    Private Sub adding_ini_files(iniFiles As String, n As Integer)
        If FileIO.FileSystem.FileExists(iniFiles) = True Then
            get_aggregates_to_compile(iniFiles, n)
        Else
            FileIO.FileSystem.WriteAllText(iniFiles, 0, True)
            get_aggregates_to_compile(iniFiles, n)
        End If
    End Sub
    Private Sub get_aggregates_to_compile(iniFile As String, n As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim compile_aggregates As String = ""
        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_aggregates_general_request1", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 6)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                If n = 1 Then
                    compile_aggregates = compile_aggregates & newDR.Item("agg_main_rs").ToString & vbCrLf
                ElseIf n = 2 Then
                    compile_aggregates = compile_aggregates & newDR.Item("agg_main_rs").ToString & "=0" & vbCrLf
                End If

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

            If n = 1 Then
                FileIO.FileSystem.WriteAllText(iniFile, 0, True)
                IO.File.WriteAllText(iniFile, compile_aggregates)
            ElseIf n = 2 Then
                FileIO.FileSystem.WriteAllText(iniFile, 0, True)
                IO.File.WriteAllText(iniFile, compile_aggregates)
            End If

            'Dim compile_aggregates1 As String = compile_aggregates.Substring(0, compile_aggregates.Length - 1)
            'IO.File.WriteAllText(iniFile, compile_aggregates)

        End Try
    End Sub



    Private Sub set_remaining_balance(lvl As ListView)
        Dim agg_name As String = ""
        Try

            Dim main_qty As Double
            Dim counter As Integer

            Dim get_rs_no As String = ""

            '*** FIRST STEP ****
            For Each row As ListViewItem In lvl.Items

                If row.BackColor = Color.Yellow Then
                    'kwaon ang main qty first
                    counter += 1

                    If counter > 1 Then

                        lvl.Items(row.Index - 1).SubItems(1).Text = get_rs_no
                        lvl.Items(row.Index - 1).SubItems(4).Text = agg_name
                        lvl.Items(row.Index - 1).SubItems(37).Text = "Remaining Balance:"
                        lvl.Items(row.Index - 1).SubItems(5).Text = main_qty

                    End If

                    get_rs_no = row.SubItems(1).Text
                    agg_name = row.SubItems(4).Text
                    main_qty = IIf(IsNumeric(row.SubItems(5).Text) = False, 0, row.SubItems(5).Text)
                End If

                If row.BackColor = Color.DarkGreen Then

                    If row.SubItems(15).Text = 0 Then
                    Else
                        'if ang row sa row.index-1 kay dili yellow 
                        If (row.Index - 1) = -1 Then
                            Dim iniFile3 As String = Application.StartupPath & "\" & "AGGREGATES2" & ".txt"

                            If FileIO.FileSystem.FileExists(iniFile3) = True Then
                                'Dim objReader As New System.IO.StreamReader(iniFile3)
                                'Dim lines As String = ""

                                'Do While objReader.Peek() <> -1
                                '    lines = lines & objReader.ReadLine().ToString & vbCrLf
                                'Loop

                                'lines = lines & row.SubItems(4).Text & vbCrLf
                                'IO.File.WriteAllText(iniFile3, row.SubItems(1).Text & " | " & lines)

                                My.Computer.FileSystem.WriteAllText(iniFile3, row.SubItems(1).Text & " | " & row.SubItems(4).Text & vbCrLf, True)
                                GoTo proceedhere
                            Else

                                FileIO.FileSystem.WriteAllText(iniFile3, 0, True)
                                IO.File.WriteAllText(iniFile3, row.SubItems(1).Text & " | " & row.SubItems(4).Text & vbCrLf)

                            End If
                        End If

                        If lvl.Items(row.Index - 1).BackColor = Color.Yellow Then


                        ElseIf lvl.Items(row.Index - 1).BackColor = Color.White Then
                            'If main_qty < 0 Then
                            'Else
                            '    lvlrequisitionlist.Items(row.Index - 1).SubItems(37).Text = "Remaining Balance:"
                            '    lvlrequisitionlist.Items(row.Index - 1).SubItems(5).Text = main_qty
                            'End If
                            lvl.Items(row.Index - 1).SubItems(1).Text = get_rs_no
                            lvl.Items(row.Index - 1).SubItems(4).Text = agg_name
                            lvl.Items(row.Index - 1).SubItems(37).Text = "Remaining Balance:"
                            lvl.Items(row.Index - 1).SubItems(5).Text = main_qty

                        End If
                    End If

                    main_qty -= row.SubItems(5).Text
proceedhere:

                End If
            Next

            '*** SECOND STEP ****
            Dim count_rows As Integer = lvl.Items.Count - 1

            lvl.Items(count_rows).SubItems(1).Text = get_rs_no
            lvl.Items(count_rows).SubItems(4).Text = agg_name
            lvl.Items(count_rows).SubItems(37).Text = "Remaining Balance:"
            lvl.Items(count_rows).SubItems(5).Text = main_qty

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub get_aggregates_from_db(lvl As ListView)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 27)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                main_qty_items(newDR.Item("agg_main_rs").ToString, lvl)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Private Sub for_item_not_exist_in_db(lvl As ListView)
        'for item nga nag naay wh_id pero wala nag exist sa database
        For Each row As ListViewItem In lvl.Items
            If row.BackColor = Color.DarkGreen Then
                If row.SubItems(15).Text = 0 Then
                Else
                    If check_if_exist("dbwarehouse_items", "wh_id", row.SubItems(15).Text, 1) = 0 Then
                        for_item_not_exist_aggregates(row.Index, "", lvl)
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub for_item_not_exist_aggregates(index As Integer, items As String, lvl As ListView)
        With lvl.Items.Insert(index, "")
            .SubItems.Add("")
            .SubItems.Add("")
            .SubItems.Add("")
            .SubItems.Add(items.ToUpper)
            .SubItems.Add("")
            .BackColor = Color.Yellow
            .Font = New Font("Arial", 12, FontStyle.Bold)
        End With
    End Sub
    Private Sub main_qty_items(items As String, lvl As ListView)

        For Each row As ListViewItem In lvl.Items
            If row.BackColor = Color.DarkGreen Then
                If row.SubItems(15).Text = 0 Then

                Else
                    'If items = "FINE SAND" Then
                    '    main_item_checker(main_finesand, row.SubItems(15).Text, items, row.Index, lvl)
                    'ElseIf items = "G-1" Then
                    '    main_item_checker(main_g1, row.SubItems(15).Text, items, row.Index, lvl)
                    'ElseIf items = "3/4 GRAVEL" Then
                    '    main_item_checker(main_34, row.SubItems(15).Text, items, row.Index, lvl)
                    'ElseIf items = "Mixed/Boulders/200/300/foundation fill" Then
                    '    main_item_checker(main_mixed_boulders, row.SubItems(15).Text, items, row.Index, lvl)
                    'ElseIf items = "Waste" Then
                    '    main_item_checker(main_waste, row.SubItems(15).Text, items, row.Index, lvl)
                    'ElseIf items = "ITEM 104" Then
                    '    main_item_checker(main_item_104, row.SubItems(15).Text, items, row.Index, lvl)
                    'ElseIf items = "Screen Sand" Then
                    '    main_item_checker(main_screen_sand, row.SubItems(15).Text, items, row.Index, lvl)
                    'ElseIf items = "Mixed Aggregates/ITEM104/ITEM200/BOULDERS" Then
                    '    main_item_checker(main_item_104_item_200_boulders, row.SubItems(15).Text, items, row.Index, lvl)
                    'ElseIf items = "ITEM 200" Then
                    '    main_item_checker(main_item_200, row.SubItems(15).Text, items, row.Index, lvl)
                    'End If


                    Dim iniFile As String = Application.StartupPath & "\" & "AGGREGATES" & ".txt"
                    Dim iniFile1 As String = Application.StartupPath & "\" & "AGGREGATES1" & ".txt"

                    Dim sp As System.Array

                    If FileIO.FileSystem.FileExists(iniFile) = True Then
                        'nag exist
                        Dim objReader As New System.IO.StreamReader(iniFile)
                        Dim exist As Boolean

                        Do While objReader.Peek() <> -1

                            If objReader.ReadLine().ToString = items Then
                                exist = True
                            End If
                        Loop

                        'KUNG NAG EXIST
                        If exist = True Then
                            Dim ss As String = ""

                            Dim lines() As String = IO.File.ReadAllLines(iniFile1)

                            For i As Integer = 0 To lines.Length - 1
                                If lines(i).Contains(items) Then
                                    ss = lines(i)
                                End If
                            Next

                            sp = Split(ss, "=")
                            main_item_checker(sp(1), row.SubItems(15).Text, items, row.Index, lvl)
                        Else
                            MsgBox(items & " wala nag exist")
                        End If
                    Else
                        MsgBox("wala pani, buhatan sa nako og file 2!")
                        FileIO.FileSystem.WriteAllText(iniFile, 0, True)
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub main_item_checker(gg As Integer, wh_id As Integer, items As String, rowindex As Integer, lvl As ListView)
        If gg > 0 Then
        Else
            check_what_items1(wh_id, items, rowindex, lvl)
        End If

    End Sub

    Private Sub check_what_items1(wh_id As Integer, items As String, index As Integer, lvl As ListView)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim counter As Integer

        Try

            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 26)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newCMD.Parameters.AddWithValue("@items", items)
            newCMD.Parameters.AddWithValue("@rs_id", lvl.Items(index).Text)

            newDR = newCMD.ExecuteReader

            While newDR.Read

                If newDR.Item("tt").ToString = 1 Then

                    With lvl.Items.Insert(index, "")
                        .SubItems.Add(newDR.Item("rs_no").ToString)
                        .SubItems.Add("")
                        .SubItems.Add("")
                        .SubItems.Add(items.ToUpper)
                        .SubItems.Add(newDR.Item("main_qty").ToString)
                        .SubItems.Add("")
                        .SubItems.Add("")
                        .SubItems.Add("")
                        .SubItems.Add("")
                        .SubItems.Add("")
                        .SubItems.Add("")
                        .SubItems.Add("")
                        .SubItems.Add("")
                        .SubItems.Add("")
                        .SubItems.Add("")
                        .SubItems.Add("")
                        .SubItems.Add("")
                        .SubItems.Add("")
                        .SubItems.Add("")
                        .SubItems.Add("")
                        .SubItems.Add("")
                        .SubItems.Add("")
                        .SubItems.Add("")
                        .SubItems.Add(newDR.Item("username").ToString)

                        .BackColor = Color.Yellow
                        .Font = New Font("Arial", 12, FontStyle.Bold)
                    End With

                    'If items = "FINE SAND" Then
                    '    main_finesand += 1
                    'ElseIf items = "G-1" Then
                    '    main_g1 += 1
                    'ElseIf items = "3/4 GRAVEL" Then
                    '    main_34 += 1
                    'ElseIf items = "Mixed/Boulders/200/300/foundation fill" Then
                    '    main_mixed_boulders += 1
                    'ElseIf items = "Waste" Then
                    '    main_waste += 1
                    'ElseIf items = "ITEM 104" Then
                    '    main_item_104 += 1
                    'ElseIf items = "Screen Sand" Then
                    '    main_screen_sand += 1
                    'ElseIf items = "Mixed Aggregates/ITEM104/ITEM200/BOULDERS" Then
                    '    main_item_104_item_200_boulders += 1
                    'ElseIf items = "ITEM 200" Then
                    '    main_item_200 += 1
                    'End If



                    '**** THIS CODE IS FOR UPDATING LINE IN NOTEPAD *****
                    Dim iniFile As String = Application.StartupPath & "\" & "AGGREGATES" & ".txt"
                    Dim iniFile1 As String = Application.StartupPath & "\" & "AGGREGATES1" & ".txt"

                    Dim newline As String = items & "=1"

                    If System.IO.File.Exists(iniFile) Then
                        Dim lines() As String = IO.File.ReadAllLines(iniFile1)
                        For i As Integer = 0 To lines.Length - 1

                            If lines(i) = items Then
                                'If lines(i).Contains(items) Then
                                lines(i) = newline
                            Else
                                lines(i) = lines(i).ToString
                            End If
                        Next
                        IO.File.WriteAllLines(iniFile1, lines) 'assuming you want to write the file
                    Else
                        MsgBox("walay makita")
                    End If

                End If
                counter += 1
            End While


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
End Class
