Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FSelectedAggregates
    Public local_array(,) As String
    Dim array_34(), array_fine_sand(), array_g1(), array_oversize_g1() As String

    Dim thread, thread1, thread2, thread3 As System.Threading.Thread
    Dim count_finesand1 As Double
    Dim fine_sand_bol, bol_34, g1_bol, bol_overseize_g1 As Boolean
    Dim get_fine_sand, get_g1, get34, get_oversize_g1 As Double
    Dim nn As Integer
    Dim items As String
    Dim b(5) As String
    Dim selectedindex As Integer = 0
    Dim selectedindex1 As Integer = 0
    Dim wh As String
    Dim tig_next As Boolean
    Dim abortsearching As Boolean = False
    Private Sub FSelectedAggregates_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_warehouse()

    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        For Each row As ListViewItem In lvlSelectedAggregates.Items
            If row.Checked = True Then
                FStockCard.display_stock_card3(11, row.Text)
            End If
        Next

    End Sub
    Private Sub load_warehouse()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        lvlSelectedAggregates.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("select DISTINCT wh_area from dbwh_area ORDER BY wh_area ASC", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.Text
            newDR = newCMD.ExecuteReader
            Dim a(3) As String

            While newDR.Read
                a(0) = newDR("wh_area").ToString

                Dim lvl As New ListViewItem(a)
                lvlStockPile.Items.Add(lvl)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FStockpile_monitoring.lvlSelectedAggregates.Items.Clear()
        ListView1.Items.Clear()
        Label3.Text = "Initializing..."
        GroupBox1.Text = "Total Balance as of " & Format(Date.Parse(dtpTo.Text), "MM/dd/yyyy")

        For Each row As ListViewItem In lvlStockPile.Items
            If row.Checked = True Then
                'wh_source(row.Text)
                'wh_source_list(row.Text)
                'wh = row.Text
                cmbWareHouse.Items.Add(row.Text)
                'Button3.PerformClick()
                'c(lvlSelectedAggregates)

            End If
        Next


        Button5.PerformClick()
        Timer5.Start()

    End Sub
    Private Sub c(aggreg_listview As ListView)

        'FStockpile_monitoring.lvlSelectedAggregates.Items.Clear()

        With FStockpile_monitoring
            'Dim count_finesand, count_g1, count_3_4th As String
            'Dim count_finesand, count_g1, count_3_4th As Integer
            Dim count_finesand, count_g1, count_3_4th As Double
            Dim a(10) As String
            For i = 0 To local_array.GetUpperBound(0)
                For Each row1 As ListViewItem In aggreg_listview.Items

                    If row1.SubItems(2).Text = local_array(i, 1) Then

                        If row1.SubItems(1).Text.Contains("Fine Sand") Then
                            'count_finesand += 1
                            'count_finesand &= row1.Text & " "
                            Dim d As delegate_get_aggregates_balance = AddressOf display_stock_card3
                            d.Invoke(11, row1.Text)

                            'count_finesand += display_stock_card3(11, row1.Text)
                            'count_finesand += d.Invoke(11, row1.Text)
                        ElseIf row1.SubItems(1).Text.Contains("3/4 GRAVEL") Then
                            'count_3_4th += 1
                            'count_3_4th &= row1.Text & " "
                            'count_3_4th += display_stock_card3(11, row1.Text)
                            Dim d As delegate_get_aggregates_balance = AddressOf display_stock_card3
                            d.Invoke(11, row1.Text)

                            'count_3_4th += d.Invoke(11, row1.Text)
                        ElseIf row1.SubItems(1).Text.Contains("G-1") Then
                            'count_g1 += 1
                            'count_g1 &= row1.Text & " "
                            'count_g1 += display_stock_card3(11, row1.Text)

                            Dim d As delegate_get_aggregates_balance = AddressOf display_stock_card3
                            d.Invoke(11, row1.Text)

                            'count_g1 += d.Invoke(11, row1.Text)
                        End If
                    End If
                Next

                a(1) = local_array(i, 0)
                a(2) = local_array(i, 1)
                a(3) = FormatNumber(count_finesand,,, TriState.False)
                a(4) = FormatNumber(count_3_4th,,, TriState.False)
                a(5) = FormatNumber(count_g1,,, TriState.False)

                If a(1) = "" And a(2) = "" Then
                    Exit Sub
                End If

                Dim lvl As New ListViewItem(a)

                If .lvlSelectedAggregates.InvokeRequired Then
                    .lvlSelectedAggregates.Invoke(Sub()
                                                      .lvlSelectedAggregates.Items.Add(lvl)

                                                  End Sub)
                Else
                    .lvlSelectedAggregates.Items.Add(lvl)
                End If


                count_finesand = 0
                count_3_4th = 0
                count_g1 = 0

            Next
        End With
    End Sub
    Private Delegate Sub delegate_get_aggregates_balance(n As Integer, wh_id As Integer)
    Private Delegate Sub delegate_get_aggregates_balance1(n As Integer, wh_id As Integer, aw As String)

    Public Function display_stock_card3(n As Integer, wh_id As Integer) As Double
        Dim balance1 As Double
        Dim beginning_balance As Double = get_prev_remaining_balance1(wh_id) + FStockCard.get_prev_item_balance(wh_id)

        If wh_id = 0 Then
            Exit Function
        End If

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.CommandTimeout = 0

            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newCMD.Parameters.AddWithValue("@date_from", Date.Parse("2001-01-01"))
            newCMD.Parameters.AddWithValue("@date_to", Date.Parse(dtpTo.Text))

            newDR = newCMD.ExecuteReader

            Dim a(20) As String
            Dim rowcount As Integer = 0
            While newDR.Read
                Dim ws_no As String = newDR.Item("WS_NO").ToString
                Dim rs_no As String = newDR.Item("rs_no").ToString

                'lblReOrderPoint.Text = newDR.Item("REORDER_POINT").ToString
                Select Case n

                    Case 11
                        If newDR.Item("WITHDRAWN").ToString = "NO" Then
                            GoTo proceedhere
                        End If

                        If newDR.Item("stat").ToString = "" And newDR.Item("dr_no").ToString = "" Then
                            GoTo proceedhere
                        End If

                        If newDR.Item("IN_OUT").ToString = "OUT" Then

                            If newDR.Item("SORTING").ToString = "A" Then
                                a(8) = ""
                                a(9) = CDbl(newDR.Item("qty_OUT").ToString) - count_qty_dr_using_ws_no(ws_no, rs_no, 12)

                                'example 12/8 so, 8-12 = -4 therefore,  dili pde mag negative
                                If a(9) < 0 Then
                                    beginning_balance = beginning_balance - 0
                                Else
                                    beginning_balance = beginning_balance - CDbl(a(9))
                                End If

                                If count_qty_dr_using_ws_no(ws_no, rs_no, 12) = 0 Then
                                    a(9) = CDbl(newDR.Item("qty_OUT").ToString)
                                Else
                                    a(9) = count_qty_dr_using_ws_no(ws_no, rs_no, 12) & "/" & CDbl(newDR.Item("qty_OUT").ToString)
                                End If

                                a(10) = FormatNumber(beginning_balance,,, TriState.False)

                            Else
                                beginning_balance = beginning_balance - CDbl(newDR.Item("qty_OUT").ToString)
                                a(10) = FormatNumber(beginning_balance,,, TriState.False)
                            End If

                        ElseIf newDR.Item("IN_OUT").ToString = "IN" Then

                            a(8) = newDR.Item("qty_IN").ToString
                            beginning_balance = beginning_balance + CDbl(a(8))
                            a(10) = FormatNumber(beginning_balance,,, TriState.False)

                        End If

                        balance1 = beginning_balance
                        rowcount += 1

proceedhere:

                End Select

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
            display_stock_card3 = balance1
        End Try

    End Function
    Public Function get_prev_remaining_balance1(wh_id As Integer) As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim in_qty, out_qty As Double

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 6)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newCMD.Parameters.AddWithValue("@date_prevfrom", Date.Parse("1991-01-01"))
            newCMD.Parameters.AddWithValue("@date_prevto", Date.Parse("2014-01-01").AddDays(-1))

            newDR = newCMD.ExecuteReader

            While newDR.Read
                If newDR.Item("IN_OUT").ToString = "IN" Then
                    in_qty += newDR.Item("desired_qty").ToString

                ElseIf newDR.Item("IN_OUT").ToString = "OUT" Then
                    out_qty += newDR.Item("desired_qty").ToString

                End If
            End While
            newDR.Close()

            get_prev_remaining_balance1 = in_qty - out_qty

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Function
            End If
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Function

    Private Sub wh_source(stockpile As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        lvlSelectedAggregates.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 15)
            newCMD.Parameters.AddWithValue("@wharea", stockpile)

            newCMD.CommandTimeout = 300

            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                a(0) = newDR.Item("wh_id").ToString
                a(1) = newDR.Item("whItem").ToString & " - " & newDR.Item("whItemDesc").ToString
                a(2) = newDR.Item("whClass").ToString

                Dim lvl As New ListViewItem(a)
                lvlSelectedAggregates.Items.Add(lvl)

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub wh_source_list(stockpile As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 16)
            newCMD.Parameters.AddWithValue("@wharea", stockpile)

            newCMD.CommandTimeout = 300

            newDR = newCMD.ExecuteReader
            Dim a(10) As String
            Dim i As Integer
            ReDim local_array(50, 50)
            While newDR.Read

                ' MsgBox(newDR.Item("whClass").ToString)

                local_array(i, 0) = stockpile
                local_array(i, 1) = newDR.Item("whClass").ToString

                i += 1
                'Dim lvl As New ListViewItem(a)
                'FStockpile_monitoring.lvlSelectedAggregates.Items.Add(lvl)

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub CheckedAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckedAllToolStripMenuItem.Click
        For Each row As ListViewItem In lvlStockPile.Items
            row.Checked = True
        Next
    End Sub

    Private Sub UnchekedAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnchekedAllToolStripMenuItem.Click
        For Each row As ListViewItem In lvlStockPile.Items
            row.Checked = False
        Next
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick

        If Not thread2.IsAlive Then
            'b(2) = get_g1
            ListBox1.Items.Clear()

        End If
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        If ComboBox1.Items.Count = selectedindex Then
            'stop na ky mana man og loop sa items
            Timer4.Stop()
            tmr_checker.Start()
            Exit Sub
        End If

        Button2.PerformClick()
        selectedindex += 1
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        'sugod na dayon og set variable to 0 para reset
        Label7.Enabled = True
        lblG1.Text = 0
        lblTotal_34.Text = 0
        lblTotal_finesand.Text = 0
        lblOversizeG1.Text = 0

        get_fine_sand = 0
        get34 = 0
        get_g1 = 0
        get_oversize_g1 = 0

        bol_34 = False
        fine_sand_bol = False
        g1_bol = False
        bol_overseize_g1 = False

        selectedindex = 0
        Panel3.Visible = True

        Erase array_34
        Erase array_fine_sand
        Erase array_g1
        Erase array_oversize_g1

        'Array.Clear(array_34, 0, array_34.Length)
        'Array.Clear(array_fine_sand, 0, array_fine_sand.Length)
        'Array.Clear(array_g1, 0, array_g1.Length)

        Timer4.Start()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If ListView1.InvokeRequired Then
            ListView1.Invoke(Sub()
                                 b(0) = get34
                                 b(1) = get_fine_sand
                                 b(2) = get_g1
                                 b(3) = wh
                                 b(4) = get_oversize_g1
                                 Dim lvl As New ListViewItem(b)
                                 ListView1.Items.Add(lvl)
                             End Sub)
        Else
            b(0) = get34
            b(1) = get_fine_sand
            b(2) = get_g1
            b(3) = get_oversize_g1
            b(3) = wh
            b(4) = get_oversize_g1
            Dim lvl As New ListViewItem(b)
            ListView1.Items.Add(lvl)
        End If
    End Sub

    Private Sub tmr_checker_Tick(sender As Object, e As EventArgs) Handles tmr_checker.Tick

        If Not thread.IsAlive And Not thread1.IsAlive And Not thread2.IsAlive And Not thread3.IsAlive Then
            Button4.PerformClick()
            tmr_checker.Stop()
            Panel3.Visible = False
            tig_next = True
        End If
    End Sub

    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick
        If tig_next = True Then
            Dim a, b, c, d As Decimal

            If cmbWareHouse.Items.Count - 1 = selectedindex1 Then
                Timer5.Stop()

                For Each row As ListViewItem In ListView1.Items
                    a += CDec(row.Text) '3/4
                    b += CDec(row.SubItems(1).Text) ' fine sand 
                    c += CDec(row.SubItems(2).Text) ' G-1
                    d += CDec(row.SubItems(4).Text) 'Oversize G-1
                Next

                lblTotal_34.Text = a
                lblTotal_finesand.Text = b
                lblG1.Text = c
                lblOversizeG1.Text = d

                Exit Sub
            End If

            selectedindex1 += 1
            tig_next = False

            Button5.PerformClick()

        End If

    End Sub



    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        cmbWareHouse.SelectedIndex = selectedindex1

        'e list sa first ang stockpile source
        wh_source(cmbWareHouse.Text)
        'e store sa array ang stockpile
        wh_source_list(cmbWareHouse.Text)
        wh = cmbWareHouse.Text

        Button3.PerformClick()

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Dispose()

    End Sub

    Private Sub Timer6_Tick(sender As Object, e As EventArgs) Handles Timer6.Tick

        If Not thread3.IsAlive Then
            'b(2) = get_g1
            ListBox1.Items.Clear()

        End If
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        abortsearching = True
        Label3.Text = "Aborting process..."
        Try
            If abortsearching = True Then
                Label7.Enabled = False
                If thread.IsAlive Then
                    thread.Abort()
                End If

                If thread1.IsAlive Then
                    thread1.Abort()
                End If

                If thread2.IsAlive Then
                    thread2.Abort()
                End If

                Timer1.Stop()
                Timer2.Stop()
                Timer3.Stop()
                Timer4.Stop()
                tmr_checker.Stop()
                Timer5.Stop()
            End If

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        If Not thread1.IsAlive Then
            'b(1) = get_fine_sand
            ListBox1.Items.Clear()

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click



        'For Each row As ListViewItem In lvlSelectedAggregates.Items

        '    If row.SubItems(1).Text.Contains("Fine Sand") Then
        '        'MsgBox(row.SubItems(2).Text)


        '        Dim dd As delegate_get_aggregates_balance1 = AddressOf display_agg
        '        dd.Invoke(11, row.Text, "Fine Sand")

        '    ElseIf row.SubItems(1).Text.Contains("3/4 GRAVEL") Then
        '        'MsgBox(row.SubItems(2).Text)

        '        Dim dd As delegate_get_aggregates_balance1 = AddressOf display_agg
        '        dd.Invoke(11, row.Text, "3/4 Gravel")

        '    ElseIf row.SubItems(1).Text.Contains("G-1") Then
        '        'MsgBox(row.SubItems(2).Text)
        '        g1_bol = True
        '    End If
        'Next


        ComboBox1.SelectedIndex = selectedindex
        load_aggregates_now(ComboBox1.Text)



        'Timer1.Start()


    End Sub
    Private Sub load_aggregates_now(aggregates As String)
        ListBox1.Items.Clear()
        Dim i As Integer = 0
        Dim s As String
        For Each row As ListViewItem In lvlSelectedAggregates.Items
            If row.SubItems(1).Text.Contains(aggregates) Then
                ListBox1.Items.Add(row.Text)
                s &= row.Text & "-"
                i += 1
            End If
        Next

        If s = Nothing Then
            s = "0-0-0"
        Else
            s = s.Substring(0, s.Length - 1)
        End If

        If aggregates = "3/4 GRAVEL" Then
            array_34 = s.Split("-")
        ElseIf aggregates = "Fine Sand" Then
            array_fine_sand = s.Split("-")
        ElseIf aggregates = "G-1" Then
            array_g1 = s.Split("-")
        ElseIf aggregates = "Oversize G-1" Then
            array_oversize_g1 = s.Split("-")
        End If

        i = 0


        nn = 11
        Select Case aggregates
            Case "3/4 GRAVEL"
                items = "3/4 GRAVEL"
                thread = New System.Threading.Thread(AddressOf agg1)
                thread.Start()
                Timer1.Start()
            Case "Fine Sand"
                items = "Fine Sand"
                thread1 = New System.Threading.Thread(AddressOf agg2)
                thread1.Start()
                Timer2.Start()

            Case "G-1"
                items = "G-1"
                thread2 = New System.Threading.Thread(AddressOf agg3)
                thread2.Start()
                Timer3.Start()

            Case "Oversize G-1"
                items = "Oversize G-1"
                thread3 = New System.Threading.Thread(AddressOf agg4)
                thread3.Start()
                Timer6.Start()
        End Select



    End Sub
    Private Sub agg1()
        nn = 11
        'For i = 0 To ListBox1.Items.Count - 1
        '    display_stock_card7(ListBox1.Items(i))
        'Next

        For i = 0 To array_34.Length - 1
            display_stock_card7(array_34(i))
        Next
    End Sub

    Private Sub agg2()
        nn = 11
        'For i = 0 To ListBox1.Items.Count - 1
        '    display_stock_card7(ListBox1.Items(i))
        'Next

        For i = 0 To array_fine_sand.Length - 1
            display_stock_card7(array_fine_sand(i))
        Next
    End Sub

    Private Sub agg3()
        nn = 11
        'For i = 0 To ListBox1.Items.Count - 1
        '    display_stock_card7(ListBox1.Items(i))
        'Next

        For i = 0 To array_g1.Length - 1
            display_stock_card7(array_g1(i))
        Next
    End Sub

    Private Sub agg4()
        nn = 11
        'For i = 0 To ListBox1.Items.Count - 1
        '    display_stock_card7(ListBox1.Items(i))
        'Next

        For i = 0 To array_oversize_g1.Length - 1
            display_stock_card7(array_oversize_g1(i))
        Next
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If Not thread.IsAlive Then
            ' b(0) = get34
            ListBox1.Items.Clear()
        End If


        'If bol_34 = True And fine_sand_bol = True And g1_bol = True Then

        '    If ListView1.InvokeRequired Then
        '        ListView1.Invoke(Sub()
        '                             Dim lvl As New ListViewItem(b)
        '                             ListView1.Items.Add(lvl)
        '                         End Sub)
        '    Else
        '        Dim lvl As New ListViewItem(b)
        '        ListView1.Items.Add(lvl)
        '    End If
        '    Timer1.Stop()

        'End If


    End Sub

    Public Sub display_stock_card7(wh_id As Integer)
        Dim balance1, balance2 As Double
        Dim beginning_balance As Double = get_prev_remaining_balance1(wh_id) + FStockCard.get_prev_item_balance(wh_id)
        Dim re_items As String

        If wh_id = 0 Then
            Exit Sub
        End If

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.CommandTimeout = 0

            newCMD.Parameters.AddWithValue("@n", nn)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newCMD.Parameters.AddWithValue("@date_from", Date.Parse("2001-01-01"))
            newCMD.Parameters.AddWithValue("@date_to", Date.Parse(dtpTo.Text))

            newDR = newCMD.ExecuteReader

            Dim a(20) As String
            Dim rowcount As Integer = 0
            While newDR.Read
                Dim ws_no As String = newDR.Item("WS_NO").ToString
                Dim rs_no As String = newDR.Item("rs_no").ToString

                'lblReOrderPoint.Text = newDR.Item("REORDER_POINT").ToString
                Select Case nn

                    Case 11

                        If newDR.Item("WITHDRAWN").ToString = "NO" Then
                            GoTo proceedhere
                        End If

                        If newDR.Item("stat").ToString = "" And newDR.Item("dr_no").ToString = "" Then
                            GoTo proceedhere
                        End If

                        If newDR.Item("IN_OUT").ToString = "OUT" Then

                            If newDR.Item("SORTING").ToString = "A" Then
                                a(8) = ""
                                a(9) = CDbl(newDR.Item("qty_OUT").ToString) - count_qty_dr_using_ws_no(ws_no, rs_no, 12)

                                'example 12/8 so, 8-12 = -4 therefore,  dili pde mag negative
                                If a(9) < 0 Then
                                    beginning_balance = beginning_balance - 0
                                Else
                                    beginning_balance = beginning_balance - CDbl(a(9))
                                End If

                                If count_qty_dr_using_ws_no(ws_no, rs_no, 12) = 0 Then
                                    a(9) = CDbl(newDR.Item("qty_OUT").ToString)
                                Else
                                    a(9) = count_qty_dr_using_ws_no(ws_no, rs_no, 12) & "/" & CDbl(newDR.Item("qty_OUT").ToString)
                                End If

                                a(10) = FormatNumber(beginning_balance,,, TriState.False)

                            Else
                                beginning_balance = beginning_balance - CDbl(newDR.Item("qty_OUT").ToString)
                                a(10) = FormatNumber(beginning_balance,,, TriState.False)
                            End If

                        ElseIf newDR.Item("IN_OUT").ToString = "IN" Then

                            a(8) = newDR.Item("qty_IN").ToString
                            beginning_balance = beginning_balance + CDbl(a(8))
                            a(10) = FormatNumber(beginning_balance,,, TriState.False)

                        End If

                        re_items = newDR.Item("wh_item").ToString
                        balance1 = beginning_balance

                        Select Case newDR.Item("wh_item").ToString
                            Case "Oversize G-1"
                                get_oversize_g1 += balance1
                                bol_overseize_g1 = True
                        End Select


                        If Label3.InvokeRequired Then
                                Label3.Invoke(Sub() Label3.Text = "Initializing... " & Format(Date.Parse(newDR.Item("date").ToString), "MM/dd/yyyy") & " " & newDR.Item("rs_no").ToString)
                            Else
                                Label3.Text = "Initializing... " & Format(Date.Parse(newDR.Item("date").ToString), "MM/dd/yyyy") & newDR.Item("rs_no").ToString
                            End If


                            rowcount += 1

proceedhere:

                        End Select

            End While
            newDR.Close()

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                If Panel3.InvokeRequired Then
                    Panel3.Invoke(Sub() Panel3.Visible = False)
                Else
                    Panel3.Visible = False
                End If
                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

            'Dim b(10) As String
            'Dim gg As String

            'If re_items = "" Then
            '    'if null
            'Else
            '    If re_items.Contains("3/4 GRAVEL") Then
            '        get34 += balance1
            '        bol_34 = True
            '        gg = "3/4: " & balance1
            '    End If

            '    If re_items.Contains("Fine Sand") Then
            '        get_fine_sand += balance1
            '        fine_sand_bol = True
            '        gg = "Fine Sand: " & balance1
            '    End If

            '    If re_items.Contains("G-1") Then
            '        get_g1 += balance1
            '        g1_bol = True
            '        gg = "G-1: " & balance1
            '    End If

            '    If re_items.Contains("Oversize G-1") Then
            '        get_oversize_g1 += balance1
            '        bol_overseize_g1 = True
            '        gg = "Oversize G-1: " & balance1

            '    End If


            'End If


            'If ListView1.InvokeRequired Then
            '    ListView1.Invoke(Sub()
            '                         ListView1.Items.Add(gg)
            '                     End Sub)
            'Else
            '    ListView1.Items.Add(gg)
            'End If
        End Try

    End Sub

    Public Function count_qty_dr_using_ws_no(ws_no As String, rs_no As String, n As Integer) As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@ws_no", ws_no)
            newCMD.Parameters.AddWithValue("@rs_no", rs_no)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                If newDR.Item("qty").ToString = "" Then
                    count_qty_dr_using_ws_no = 0
                Else
                    count_qty_dr_using_ws_no = CDbl(newDR.Item("qty").ToString)
                End If

            End While

            newDR.Close()

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Function
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
End Class