Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Threading
Public Class FStockMonitoring
    Dim thread As System.Threading.Thread
    Private trd As Threading.Thread
    Dim row_index As Integer
    Dim abortsearching As Boolean = False

    Private NewStockPile As New class_stock_card_for_hauling
    Private listOfStockPile As New List(Of class_stockpile)
    Private listofthread As New List(Of Threading.Thread)
    Private countrow As Integer
    Private cListOfAgg As New List(Of mod_stock_pile.ls)
    Private total_items_dict As New Dictionary(Of String, Double)
    Public cListOfSelectedAggregates As New List(Of String)
    Private Sub FStockMonitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        load_warehouse()

        'initializing items what to search
        'total_items_dict.Add("fine sand", 0)
        'total_items_dict.Add("G-1", 0)
        'total_items_dict.Add("3/4 Gravel", 0)
        'total_items_dict.Add("3/8 Gravel", 0)
        'total_items_dict.Add("Oversize G-1", 0)
        'total_items_dict.Add("Mixed", 0)
        'total_items_dict.Add("Mixed Aggregates", 0)
        'total_items_dict.Add("Mixed/Boulders/200/300/foundation fill", 0)
        'total_items_dict.Add("Mixed Aggregates/ITEM104/ITEM200/BOULDERS", 0)
        'total_items_dict.Add("MIXED STONE/BOULDERS", 0)
        'total_items_dict.Add("ITEM 104", 0)

    End Sub

    Private Sub load_warehouse()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        lvlStockPile.Items.Clear()

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
        'ListView1.Items.Clear()
        'ListView2.Items.Clear()

        'lblG1.Text = 0
        'lblOversizeG1.Text = 0
        'lblTotal_34.Text = 0
        'lblTotal_finesand.Text = 0

        'Label3.Text = "Loading..."

        'For Each row As ListViewItem In lvlStockPile.Items
        '    If row.Checked = True Then
        '        For Each s As String In cmbItems.Items
        '            load_wh_first(row.Text, s)
        '        Next
        '    End If
        'Next

        'Button2.PerformClick()

        ListView1.Items.Clear()
        ListView2.Items.Clear()
        ListView3.Items.Clear()
        ListView4.Items.Clear()

        clear()
        total_items_dict.Clear()

        If FStockMonitoring_AggregatesList.ListView2.Items.Count = 0 Then
            MessageBox.Show("Please select an aggregates first to proceed calculating dr.")
            Exit Sub
        End If


        For Each row As ListViewItem In FStockMonitoring_AggregatesList.ListView2.Items
            If row.Text.EndsWith(" ") Then
                MessageBox.Show($"this item '{row.Text}' ends with space. It will not search properly.")

            Else
                total_items_dict.Add(row.Text, 0)
            End If
        Next


        Label3.Text = "Loading..."

        'loop for all stockpile name in lvlStockPile listview
        For Each row As ListViewItem In lvlStockPile.Items

            If row.Checked = True Then 'if checked

                'for each s as string in cmbitems.items


                '    'store the item data including :
                '    'item, wh_area, source and etc
                '    'to clistofagg list
                '    load_wh_first2(row.text, s)
                'next

                For Each item As KeyValuePair(Of String, Double) In total_items_dict
                    load_wh_first2(row.Text, item.Key.ToUpper())
                Next
            End If
        Next

        'after ma load tanan sa cListOfAgg list:
        'trigger and start
        start()

    End Sub

    Private Sub load_wh_first(wharea As String, items As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_stock_monitoring", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 1)
            newCMD.Parameters.AddWithValue("@wharea", wharea)
            newCMD.Parameters.AddWithValue("@search", items)

            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                a(0) = newDR.Item("wh_id").ToString
                a(1) = newDR.Item("items").ToString
                a(2) = newDR.Item("wh_area").ToString
                a(3) = 0
                a(4) = newDR.Item("wh_source").ToString

                Dim lvl As New ListViewItem(a)
                ListView1.Items.Add(lvl)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub


    Private Sub load_wh_first2(wharea As String, items As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim ls As New mod_stock_pile.ls

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_stock_monitoring", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 1)
            newCMD.Parameters.AddWithValue("@wharea", wharea)
            newCMD.Parameters.AddWithValue("@search", items)

            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                ls.wh_id = newDR.Item("wh_id").ToString
                ls.items = newDR.Item("items").ToString
                ls.wharea = newDR.Item("wh_area").ToString
                ls.source = newDR.Item("wh_source").ToString

                cListOfAgg.Add(ls)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Private Sub calculate_remaining_balance(ByVal STthread_Data As search_wh_data)
        Dim wh_id As Integer = STthread_Data.s_wh_id
        Dim n As Integer = STthread_Data.nn
        Dim row1_index As Integer = STthread_Data.row_index

        Dim beginning_balance As Double = get_prev_item_balance(wh_id)

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

            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newCMD.Parameters.AddWithValue("@date_from", Date.Parse("1990-01-01"))
            newCMD.Parameters.AddWithValue("@date_to", Date.Parse(dtpTo.Text))

            newDR = newCMD.ExecuteReader

            Dim a(20) As String
            Dim rowcount As Integer = 0
            While newDR.Read
                Dim ws_no As String = newDR.Item("WS_NO").ToString
                Dim rs_no As String = newDR.Item("rs_no").ToString

                If newDR.Item("WITHDRAWN").ToString = "NO" Then
                    GoTo proceedhere
                End If

                If newDR.Item("stat").ToString = "" And newDR.Item("dr_no").ToString = "" Then
                    GoTo proceedhere
                End If

                If newDR.Item("IN_OUT").ToString = "OUT" Then

                    If newDR.Item("SORTING").ToString = "A" Then
                        Dim count_qty_dr As Double = FStockCard.count_qty_dr_using_ws_no(ws_no, rs_no, 12)

                        a(9) = CDbl(newDR.Item("qty_OUT").ToString) - count_qty_dr

                        'example 12/8 so, 8-12 = -4 therefore,  dili pde mag negative
                        If a(9) < 0 Then
                            beginning_balance = beginning_balance - 0
                        Else
                            beginning_balance = beginning_balance - CDbl(a(9))
                        End If

                        If count_qty_dr = 0 Then
                            a(9) = CDbl(newDR.Item("qty_OUT").ToString)
                        Else
                            a(9) = count_qty_dr & "/" & CDbl(newDR.Item("qty_OUT").ToString)
                        End If

                    Else
                        beginning_balance = beginning_balance - CDbl(newDR.Item("qty_OUT").ToString)
                    End If

                ElseIf newDR.Item("IN_OUT").ToString = "IN" Then
                    beginning_balance = beginning_balance + CDbl(newDR.Item("qty_IN").ToString)
                End If
                rowcount += 1

proceedhere:

            End While
            newDR.Close()

            If ListView1.InvokeRequired Then
                ListView1.Invoke(Sub()
                                     ListView1.Items(row1_index).SubItems(3).Text = beginning_balance.ToString("N", Globalization.CultureInfo.InvariantCulture)
                                 End Sub)
            Else
                ListView1.Items(row1_index).SubItems(3).Text = beginning_balance.ToString("N", Globalization.CultureInfo.InvariantCulture)
            End If

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                If Panel2.InvokeRequired Then
                    Panel2.Invoke(Sub() Panel2.Visible = False)
                Else
                    Panel2.Visible = False
                End If
                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Public Function get_prev_item_balance(wh_id As Integer) As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT a.balance FROM dbPrevious_stock_card a WHERE a.wh_id = " & wh_id

            newCMD = New SqlCommand(query, newSQ.connection)
            'newCMD.Parameters.Clear()
            'newCMD.CommandType = CommandType.StoredProcedure

            'newCMD.Parameters.AddWithValue("@n", 14)
            'newCMD.Parameters.AddWithValue("@wh_id", wh_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_prev_item_balance = newDR.Item("balance").ToString()
            End While
            newDR.Close()

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                Exit Function
            End If
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function

    Public Structure search_wh_data
        Dim s_wh_id As Integer
        Dim nn As Integer
        Dim row_index As Integer

    End Structure
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        row_index = 0
        'Dim STthread_Data As search_wh_data
        'For Each row As ListViewItem In ListView1.Items

        '    STthread_Data.s_wh_id = row.Text
        '    STthread_Data.nn = 17

        '    thread = New Threading.Thread(AddressOf calculate_remaining_balance)
        '    thread.SetApartmentState(ApartmentState.MTA)
        '    thread.Start(STthread_Data)
        '    PictureBox1.Visible = True

        '    Timer1.Start()
        'Next

        Button4.Visible = True
        tig_next.Start()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not thread.IsAlive Then
            Timer1.Stop()
            Panel2.Visible = False

        End If
    End Sub

    Private Sub tig_next_Tick(sender As Object, e As EventArgs) Handles tig_next.Tick

        'Dim STthread_Data As search_wh_data

        'STthread_Data.s_wh_id = Row.Text
        'STthread_Data.nn = 17

        'thread = New Threading.Thread(AddressOf calculate_remaining_balance)
        'thread.SetApartmentState(ApartmentState.MTA)
        'thread.Start(STthread_Data)
        'PictureBox1.Visible = True

        'Timer1.Start()


        If (ListView1.Items.Count - 1) = row_index Then
            tig_next.Stop()
            get_balance(ListView1.Items(row_index).Text, row_index)
            'MsgBox(ListView1.Items(row_index).Text)     
            'Timer2.Start()
            Button3.Enabled = True
            btnClear.Enabled = True
            Button4.Visible = False

            Exit Sub
        End If

        If row_index = 0 Then
            get_balance(ListView1.Items(row_index).Text, row_index)
            row_index += 1

        Else
            If thread.IsAlive Then

            Else
                get_balance(ListView1.Items(row_index).Text, row_index)
                row_index += 1
            End If
        End If

    End Sub

    Private Sub get_balance(wh_id As Integer, row_index As Integer)
        Dim STthread_Data As search_wh_data

        STthread_Data.s_wh_id = wh_id
        STthread_Data.nn = 17
        STthread_Data.row_index = row_index

        thread = New Threading.Thread(AddressOf calculate_remaining_balance)
        thread.SetApartmentState(ApartmentState.MTA)
        thread.Start(STthread_Data)
        Panel2.Visible = True
        Timer1.Start()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Finesand_total, G1_total, Oversize_G1_total, Gravel34_Total, Gravel38_Total As Decimal
        Dim b(10) As String
        For Each row As ListViewItem In lvlStockPile.Items
            If row.Checked = True Then

                For Each row1 As ListViewItem In ListView1.Items
                    If row1.SubItems(1).Text = "Fine Sand" And row1.SubItems(2).Text = row.Text Then
                        Finesand_total += row1.SubItems(3).Text
                    End If

                    If row1.SubItems(1).Text = "FINE SAND" And row1.SubItems(2).Text = row.Text Then
                        Finesand_total += row1.SubItems(3).Text
                    End If

                    If row1.SubItems(1).Text = "G-1" And row1.SubItems(2).Text = row.Text Then
                        G1_total += row1.SubItems(3).Text
                    End If

                    If row1.SubItems(1).Text = "Oversize G-1" And row1.SubItems(2).Text = row.Text Then
                        Oversize_G1_total += row1.SubItems(3).Text
                    End If

                    If row1.SubItems(1).Text = "3/4 GRAVEL" And row1.SubItems(2).Text = row.Text Then
                        Gravel34_Total += row1.SubItems(3).Text
                    End If

                    If row1.SubItems(1).Text = "3/8 GRAVEL" And row1.SubItems(2).Text = row.Text Then
                        Gravel38_Total += row1.SubItems(3).Text
                    End If
                Next

                b(0) = Gravel34_Total.ToString("N", Globalization.CultureInfo.InvariantCulture)
                b(1) = Finesand_total.ToString("N", Globalization.CultureInfo.InvariantCulture)
                b(2) = G1_total.ToString("N", Globalization.CultureInfo.InvariantCulture)
                b(3) = row.Text
                b(4) = Oversize_G1_total.ToString("N", Globalization.CultureInfo.InvariantCulture)
                b(5) = Gravel38_Total.ToString("N", Globalization.CultureInfo.InvariantCulture)

                Dim lvl As New ListViewItem(b)
                ListView2.Items.Add(lvl)
            End If

            Finesand_total = 0
            G1_total = 0
            Oversize_G1_total = 0
            Gravel34_Total = 0
            Gravel38_Total = 0

        Next

        Dim aa, bb, cc, dd, ee As Decimal
        For Each row As ListViewItem In ListView2.Items
            aa += CDec(row.Text) '3/4
            bb += CDec(row.SubItems(1).Text) ' fine sand 
            cc += CDec(row.SubItems(2).Text) ' G-1
            dd += CDec(row.SubItems(4).Text) 'Oversize G-1
            ee += CDec(row.SubItems(5).Text) '3/8 GRAVEL
        Next

        lblTotal_34.Text = aa.ToString("N", Globalization.CultureInfo.InvariantCulture)
        lblTotal_finesand.Text = bb.ToString("N", Globalization.CultureInfo.InvariantCulture)
        lblG1.Text = cc.ToString("N", Globalization.CultureInfo.InvariantCulture)
        lblOversizeG1.Text = dd.ToString("N", Globalization.CultureInfo.InvariantCulture)
        lbl38Gravel.Text = ee.ToString("N", Globalization.CultureInfo.InvariantCulture)

        'Button3.Enabled = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        abortsearching = True
        Try
            If abortsearching = True Then

                If thread.IsAlive Then
                    thread.Abort()
                    tig_next.Stop()
                    Timer1.Stop()
                    Button4.Visible = False
                    Label3.Text = "Aborted, Please wait..."
                    btnClear.Enabled = True
                End If

            End If

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        For Each row As ListViewItem In lvlStockPile.Items
            row.Checked = False
        Next

        ListView1.Items.Clear()
        ListView2.Items.Clear()

        btnClear.Enabled = False

        lblG1.Text = 0
        lblOversizeG1.Text = 0
        lblTotal_34.Text = 0
        lblTotal_finesand.Text = 0
        lblTotalMixedAgg.Text = 0

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

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        ListView1.Items.Clear()
        ListView2.Items.Clear()
        ListView3.Items.Clear()

        clear()

        Label3.Text = "Loading..."

        For Each row As ListViewItem In lvlStockPile.Items
            If row.Checked = True Then
                For Each s As String In cmbItems.Items
                    load_wh_first2(row.Text, s)
                Next
            End If
        Next

        start()

    End Sub

    Private Sub clear()
        lblG1.Text = 0
        lblOversizeG1.Text = 0
        lblTotal_34.Text = 0
        lblTotal_finesand.Text = 0
        cListOfAgg.Clear()
        cListOfStockPile_Final.Clear()
        listOfStockPile.Clear()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        start()
    End Sub

    Private Delegate Sub del_start()
    Private Sub start()
        If InvokeRequired Then
            Invoke(New del_start(AddressOf start))
            Exit Sub
        End If

        Dim datefrom As DateTime = Date.Parse("2000-01-01")

        countrow = cListOfAgg.Count
        Panel2.Visible = True

        For Each row In cListOfAgg

            Dim newStockPile2 As New class_stockpile
            With newStockPile2
                .myWh_id = row.wh_id
                .myDateFrom = Date.Parse(datefrom)
                .myDateTo = Date.Parse(dtpTo.Text)
                .myItem = row.items
                .myWarehouseArea = row.wharea
                .mySource = row.source
            End With

            trd = New Threading.Thread(AddressOf go)
            trd.Start(newStockPile2)

        Next

        Dim trd2 As New Threading.Thread(AddressOf check_stat)
        trd2.Start()


    End Sub

    Private Sub go(newStockPile2 As class_stockpile)

        newStockPile2._initialize()
        listOfStockPile.Add(newStockPile2)

    End Sub


    Private Sub check_stat()

        Dim stat As Boolean = False
        While True
            If countrow = mod_stock_pile.cListOfStockPile_Final.Count Then
                Exit While
            End If
        End While

        'MsgBox("yahoo done..")

        If Panel2.InvokeRequired Then
            Panel2.Invoke(Sub()
                              Panel2.Visible = False
                          End Sub)
        End If

        king()


        'Dim g_one, fineSand, threeFourth, threeEight, oversize_G_one, mixed_aggregates, mixed, mixed_boulders_200_300_foundation_fill As Double
        'Dim _g_one As String = "G-1"
        'Dim _fine_sand As String = "FINE SAND"
        'Dim _threeFourth As String = "3/4 GRAVEL"
        'Dim _three_Eight As String = "3/8 GRAVEL"
        'Dim _oversize_G_one As String = "OVERSIZE G-1"
        'Dim _mixed_aggregates As String = "MIXED AGGREGATES"
        'Dim _mixed As String = "MIXED"
        'Dim _mixed_boulders_200_300_foundation_fill = "Mixed/Boulders/200/300/foundation fill"


        'For Each row In mod_stock_pile.cListOfStockPile_Final
        '    'MsgBox(row.balance & vbCrLf & row.items & vbCrLf & row.source & vbCrLf & row.wharea)
        '    Dim a(10) As String
        '    a(0) = row.wh_id
        '    a(1) = row.items
        '    a(2) = row.wharea
        '    a(3) = FormatNumber(row.balance, 2,,, TriState.False)
        '    a(4) = row.source

        '    If row.items.ToUpper.Contains(_g_one) Then
        '        If row.items.Length = _g_one.Length Then
        '            g_one += row.balance
        '        Else
        '            Dim warning As String = "Please check the spelling or the spacing of the items.."
        '            'MessageBox.Show(warning)
        '            Dim aa(3) As String

        '            aa(0) = row.wh_id
        '            aa(1) = row.items
        '            aa(2) = warning
        '            aa(3) = FormatNumber(row.balance, 2,,, TriState.False)

        '            Dim lvl2 As New ListViewItem(aa)

        '            If ListView3.InvokeRequired Then
        '                ListView3.Invoke(Sub()
        '                                     ListView3.Items.Add(lvl2)
        '                                 End Sub)
        '            End If
        '        End If

        '    ElseIf row.items.ToUpper.Contains(_oversize_G_one) Then
        '        If row.items.Length = _oversize_G_one.Length Then
        '            oversize_G_one += row.balance
        '        Else
        '            Dim warning As String = "Please check the spelling or the spacing of the items.."
        '            'MessageBox.Show(warning)
        '            Dim aa(3) As String

        '            aa(0) = row.wh_id
        '            aa(1) = row.items
        '            aa(2) = warning

        '            Dim lvl2 As New ListViewItem(aa)

        '            If ListView3.InvokeRequired Then
        '                ListView3.Invoke(Sub()
        '                                     ListView3.Items.Add(lvl2)
        '                                 End Sub)
        '            End If
        '        End If

        '    ElseIf row.items.ToUpper.Contains(_threeFourth) Then
        '        If row.items.Length = _threeFourth.Length Then
        '            threeFourth += row.balance
        '        Else
        '            Dim warning As String = "Please check the spelling or the spacing of the items.."
        '            'MessageBox.Show(warning)
        '            Dim aa(3) As String

        '            aa(0) = row.wh_id
        '            aa(1) = row.items
        '            aa(2) = warning

        '            Dim lvl2 As New ListViewItem(aa)

        '            If ListView3.InvokeRequired Then
        '                ListView3.Invoke(Sub()
        '                                     ListView3.Items.Add(lvl2)
        '                                 End Sub)
        '            End If
        '        End If

        '    ElseIf row.items.ToUpper.Contains(_three_Eight) Then
        '        If row.items.Length = _three_Eight.Length Then
        '            threeEight += row.balance
        '        Else
        '            Dim warning As String = "Please check the spelling or the spacing of the items.."
        '            'MessageBox.Show(warning)
        '            Dim aa(3) As String

        '            aa(0) = row.wh_id
        '            aa(1) = row.items
        '            aa(2) = warning

        '            Dim lvl2 As New ListViewItem(aa)

        '            If ListView3.InvokeRequired Then
        '                ListView3.Invoke(Sub()
        '                                     ListView3.Items.Add(lvl2)
        '                                 End Sub)
        '            End If
        '        End If

        '    ElseIf row.items.ToUpper.Contains(_fine_sand) Then
        '        If row.items.Length = _fine_sand.Length Then
        '            fineSand += row.balance
        '        Else
        '            Dim warning As String = "Please check the spelling or the spacing of the items.."
        '            'MessageBox.Show(warning)
        '            Dim aa(3) As String

        '            aa(0) = row.wh_id
        '            aa(1) = row.items
        '            aa(2) = warning

        '            Dim lvl2 As New ListViewItem(aa)

        '            If ListView3.InvokeRequired Then
        '                ListView3.Invoke(Sub()
        '                                     ListView3.Items.Add(lvl2)
        '                                 End Sub)
        '            End If
        '        End If

        '    ElseIf row.items.ToUpper.Contains(_mixed_aggregates) Then
        '        If row.items.Length = _mixed_aggregates.Length Then
        '            mixed_aggregates += row.balance
        '        Else
        '            Dim warning As String = "Please check the spelling or the spacing of the items.."
        '            'MessageBox.Show(warning)
        '            Dim aa(3) As String

        '            aa(0) = row.wh_id
        '            aa(1) = row.items
        '            aa(2) = warning

        '            Dim lvl2 As New ListViewItem(aa)

        '            If ListView3.InvokeRequired Then
        '                ListView3.Invoke(Sub()
        '                                     ListView3.Items.Add(lvl2)
        '                                 End Sub)
        '            End If
        '        End If

        '    ElseIf row.items.ToUpper.Contains(_mixed) Then
        '        If row.items.Length = _mixed.Length Then
        '            mixed += row.balance
        '        Else
        '            Dim warning As String = "Please check the spelling or the spacing of the items.."
        '            'MessageBox.Show(warning)
        '            Dim aa(3) As String

        '            aa(0) = row.wh_id
        '            aa(1) = row.items
        '            aa(2) = warning

        '            Dim lvl2 As New ListViewItem(aa)

        '            If ListView3.InvokeRequired Then
        '                ListView3.Invoke(Sub()
        '                                     ListView3.Items.Add(lvl2)
        '                                 End Sub)
        '            End If
        '        End If

        '    End If

        '    Dim lvl As New ListViewItem(a)

        '    If ListView1.InvokeRequired Then
        '        ListView1.Invoke(Sub()
        '                             ListView1.Items.Add(lvl)
        '                         End Sub)
        '    End If

        'Next

        ''Dim result As String
        ''result = "FINE SAND: " & fineSand & vbCrLf
        ''result &= "G-1: " & g_one & vbCrLf
        ''result &= "3/4 GRAVEL: " & threeFourth & vbCrLf
        ''result &= "3/8 GRAVEL: " & threeEight & vbCrLf
        ''result &= "OVERSIZE G-1: " & oversize_G_one

        'If lblTotal_34.InvokeRequired Then
        '    lblTotal_34.Invoke(Sub()
        '                           lblTotal_34.Text = FormatNumber(threeFourth, 2,,, TriState.False)
        '                           lblOversizeG1.Text = FormatNumber(oversize_G_one, 2,,, TriState.False)
        '                           lblTotal_finesand.Text = FormatNumber(fineSand, 2,,, TriState.False)
        '                           lbl38Gravel.Text = FormatNumber(threeEight, 2,,, TriState.False)
        '                           lblG1.Text = FormatNumber(g_one, 2,,, TriState.False)
        '                           lblTotalMixedAgg.Text = FormatNumber(mixed_aggregates, 2,,, TriState.False)
        '                           lblTotalMixed.Text = FormatNumber(mixed, 2,,, TriState.False)
        '                       End Sub)
        'End If


    End Sub


    '2024-12-02
    Private Sub king()

        Dim total_items_dict2 As New Dictionary(Of String, Double)

        For Each kvp As KeyValuePair(Of String, Double) In total_items_dict
            total_items_dict2.Add(kvp.Key, kvp.Value)
        Next

        For Each row In mod_stock_pile.cListOfStockPile_Final

            Dim a(10) As String

            a(0) = row.wh_id
            a(1) = row.items
            a(2) = row.wharea
            a(3) = FormatNumber(row.balance, 2,,, TriState.False)
            a(4) = row.source

            For Each item As KeyValuePair(Of String, Double) In total_items_dict

                ' Your code here using item.Key and item.Value
                If row.items.ToUpper.Contains(item.Key.ToUpper) Then

                    If row.items.Length = item.Key.Length Then
                        total_items_dict2(item.Key) += row.balance
                    Else
                        Dim warning As String = "Disregard if no issues and problem"
                        'MessageBox.Show(warning)
                        Dim aa(3) As String

                        aa(0) = row.wh_id
                        aa(1) = $"{row.items} contains {item.Key}"
                        aa(2) = warning
                        aa(3) = FormatNumber(row.balance, 2,,, TriState.False)

                        Dim lvl2 As New ListViewItem(aa)

                        If ListView3.InvokeRequired Then
                            ListView3.Invoke(Sub()
                                                 ListView3.Items.Add(lvl2)
                                             End Sub)
                        End If
                    End If
                End If
            Next

            Dim lvl As New ListViewItem(a)

            If ListView1.InvokeRequired Then
                ListView1.Invoke(Sub()
                                     ListView1.Items.Add(lvl)
                                 End Sub)
            End If
        Next

        If ListView4.InvokeRequired Then
            ListView4.Invoke(Sub()

                                 For Each item As KeyValuePair(Of String, Double) In total_items_dict2
                                     Dim c(3) As String

                                     c(0) = item.Key.ToUpper
                                     c(1) = item.Value

                                     Dim lvl As New ListViewItem(c)
                                     ListView4.Items.Add(lvl)
                                 Next
                             End Sub)
        End If


    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        FStockMonitoring_AggregatesList.ShowDialog()

    End Sub


End Class

