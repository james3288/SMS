Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FAggregates_General_Request
    Dim counter As Integer
    Dim aggregates As String
    Private FINESAND As New class_aggregates_monitoring
    Private ITEM_104 As New class_aggregates_monitoring

    Public Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click


        row_wh_id.DisplayIndex = 0
        row_rs_no.DisplayIndex = 1
        row_rs_date.DisplayIndex = 2
        row_type_of_aggregates.DisplayIndex = 3
        row_dr_option.DisplayIndex = 4
        row_item_desc.DisplayIndex = 5
        row_rs_qty.DisplayIndex = 6
        row_qty_withdrawn.DisplayIndex = 7
        row_dr_delivered.DisplayIndex = 8
        row_rs_balance.DisplayIndex = 9
        row_ws_balance.DisplayIndex = 10
        row_purpose.DisplayIndex = 11
        row_charges.DisplayIndex = 12


        lvlAllRs.Items.Clear()
        pub_list_of_agg_monitoring.Clear()
        panel_for_loading.Visible = True

        pub_cbcb = 0

        '+++ NEW CODE 4/14/2023 +++++++++++++++++++++++++++++++
        '+++OG NAA KAY GUSTO E ADD NA ITEM DIRI LANG PAG ADD+++
        '+++ DYNAMIC NANANG SA UBOS +++++++++++++++++++++++++++
        Dim my_aggregates As New Dictionary(Of String, String)

        If cmbSearchby.Text = "Search by Project Only" Then
            For Each aggregates In LIST_OF_AGGREGATES()
                my_aggregates.Add(aggregates, IIf(aggregates = "FINE SAND", "SAND", aggregates))
            Next
        Else
            my_aggregates.Add(cmbAggregates.Text, IIf(cmbAggregates.Text = "FINE SAND", "SAND", cmbAggregates.Text))
        End If

        '++++++++++++++++++++++++++++++++++++++++++++++++++++++

        For Each pair As KeyValuePair(Of String, String) In my_aggregates
            Dim item As New class_aggregates_monitoring
            item._initialize(cmbProject.Text, pair.Value, lvlAllRs, Date.Parse(dtpfrom.Text), Date.Parse(dtpto.Text), pair.Key)
        Next

        Dim ichecker As New class_aggregates_monitoring
        ichecker._initialize_checker(lvlAllRs, my_aggregates.Count, panel_for_loading)




        'DONTE DELETE THIS CODE
        'If cmbSearchby.Text = "Search by Specific Aggregates" Then
        '    If cmbAggregates.Text = "G1" Then
        '        search_general_request_for_aggregates("G-1", "G1", "G-1")
        '    ElseIf cmbAggregates.Text = "FINE SAND" Then
        '        search_general_request_for_aggregates("fine sand", "sand", "FINE SAND")
        '    ElseIf cmbAggregates.Text = "3/4" Then
        '        search_general_request_for_aggregates("3/4", "3/4", "3/4")
        '    ElseIf cmbAggregates.Text = "WASTE" Then
        '        search_general_request_for_aggregates("Waste", "Waste", "Waste")
        '    End If

        'Else
        '    search_general_request_for_aggregates("G-1", "G1", "G-1")
        '    search_general_request_for_aggregates("fine sand", "sand", "FINE SAND")
        '    search_general_request_for_aggregates("3/4", "3/4", "3/4")
        '    search_general_request_for_aggregates("Waste", "Waste", "Waste")

        'End If

        'For Each row As ListViewItem In lvlAllRs.Items
        '    If row.Text = "" And row.SubItems(6).Text = "" Then
        '    Else
        '        If row.SubItems(6).Text = "Aggregates" Then
        '        Else
        '            row.Remove()
        '        End If
        '    End If
        'Next

        'counter = 0


    End Sub
    Private Sub search_general_request_for_aggregates(search1 As String, search2 As String, type_of_aggregates As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_aggregates_general_request", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 1)
            newCMD.Parameters.AddWithValue("@search", search1)
            newCMD.Parameters.AddWithValue("@search1", search2)
            newCMD.Parameters.AddWithValue("@charges", cmbProject.Text)
            newCMD.Parameters.AddWithValue("@datefrom", dtpfrom.Text)
            newCMD.Parameters.AddWithValue("@dateto", dtpto.Text)

            newCMD.CommandTimeout = 300

            newDR = newCMD.ExecuteReader

            Dim a(15) As String
            While newDR.Read

                a(0) = newDR.Item("wh_id").ToString
                a(1) = newDR.Item("item_desc").ToString
                a(2) = IIf(newDR.Item("qty").ToString = "", 0, newDR.Item("qty").ToString)
                a(3) = newDR.Item("purpose").ToString
                a(4) = newDR.Item("rs_no").ToString
                a(5) = newDR.Item("charges").ToString
                a(6) = newDR.Item("item_name").ToString
                a(7) = type_of_aggregates
                a(8) = IIf(newDR.Item("ws_qty_received").ToString = "", 0, newDR.Item("ws_qty_received").ToString)
                a(10) = IIf(newDR.Item("delivered").ToString = "", 0, newDR.Item("delivered").ToString)

                If newDR.Item("type_of_purchasing").ToString = "DR" Then
                    a(9) = a(2) - a(10)
                Else
                    a(9) = a(2) - a(8)
                End If

                a(11) = newDR.Item("date_req").ToString
                a(12) = newDR.Item("type_of_purchasing").ToString
                a(13) = newDR.Item("IN_OUT").ToString

                Dim lvl As New ListViewItem(a)
                lvlAllRs.Items.Add(lvl)

                If newDR.Item("mother").ToString = "A" Then
                    lvlAllRs.Items(counter).BackColor = Color.DarkGreen
                    lvlAllRs.Items(counter).ForeColor = Color.White
                    lvlAllRs.Items(counter).Font = New Font(New FontFamily("Arial"), 10, FontStyle.Bold)
                End If

                counter += 1
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtCharges.TextChanged

    End Sub

    Private Sub lblSearchByCategory_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'aggregates = ""

        'general_aggregates_calc("FINE SAND")
        'general_aggregates_calc("G-1")
        'general_aggregates_calc("3/4")
        'general_aggregates_calc("Waste")
        'MsgBox(aggregates)


        'Dim rs_balance, ws_balance As Double

        'For Each row As ListViewItem In lvlAllRs.Items
        '    If IsNumeric(row.SubItems(9).Text) Then
        '        rs_balance += row.SubItems(9).Text
        '    End If

        '    If IsNumeric(row.SubItems(15).Text) Then
        '        ws_balance += row.SubItems(15).Text
        '    End If
        'Next

        'Dim a(20) As String
        'a(1) = "TOTAL"
        'a(9) = rs_balance

        'Dim lvl As New ListViewItem(a)
        'lvl.Font = New Font("Arial", 14)

        'lvlAllRs.Items.Add(lvl)

        'ADD COLUMN FIRST



        With FStockpile_monitoring.lvlSelectedAggregates
            .Columns.Clear()
            .Items.Clear()

            Dim columnHeader As New ColumnHeader()
            columnHeader.Text = "AGGREGATES"
            columnHeader.TextAlign = HorizontalAlignment.Center
            columnHeader.Width = 200

            .Columns.Add(columnHeader)

            For Each agg In LIST_OF_AGGREGATES()
                Dim columnHeader1 As New ColumnHeader()
                columnHeader1.Text = agg
                columnHeader1.TextAlign = HorizontalAlignment.Center
                columnHeader1.Width = 100

                .Columns.Add(columnHeader1)

            Next
        End With

        'ADD 1ST ROWS
        add_row_in_stockpile_monitoring("PARTIAL REQUESTED:", 2, Color.Blue)
        'ADD 2ND ROWS
        add_row_in_stockpile_monitoring("WITHDRAWN:", 8, Color.Blue)
        'ADD 3ND ROWS
        add_row_in_stockpile_monitoring("DELIVERED:", 10, Color.Blue)
        'ADD 4TH ROWS
        add_row_in_stockpile_monitoring("RS BALANCE:", 9, Color.DarkBlue)
        'ADD 5TH ROWS
        add_row_in_stockpile_monitoring("WS BALANCE:", 15, Color.DarkBlue)

        FStockpile_monitoring.ShowDialog()

    End Sub
    Private Sub add_row_in_stockpile_monitoring(rowname As String, columnindex As Integer, Optional rowbgcolor As Color = Nothing)
        Dim a(20) As String
        For Each column As ColumnHeader In FStockpile_monitoring.lvlSelectedAggregates.Columns
            'MsgBox(column.Index)

            Dim balance As Double = 0

            For Each row As ListViewItem In lvlAllRs.Items

                If row.SubItems(7).Text.ToUpper = column.Text.ToUpper Then
                    If IsNumeric(row.SubItems(columnindex).Text) Then '9
                        balance += row.SubItems(columnindex).Text
                    End If
                End If
            Next

            If column.Index = 0 Then
                a(0) = rowname
            Else
                a(column.Index) = IIf(balance = 0, "-", balance)
            End If
        Next

        Dim lvl As New ListViewItem(a)
        lvl.BackColor = rowbgcolor
        lvl.ForeColor = Color.White

        FStockpile_monitoring.lvlSelectedAggregates.Items.Add(lvl)
    End Sub

    Private Sub general_aggregates_calc(type_of_aggregates As String)
        Dim rs_qty As Double
        Dim rs_withdrawn As Double


        aggregates += type_of_aggregates & ":"

        For Each row As ListViewItem In lvlAllRs.Items
            If row.Checked = True Then
                If row.SubItems(7).Text = type_of_aggregates Then
                    rs_qty += IIf(row.SubItems(2).Text = "", 0, row.SubItems(2).Text)
                    rs_withdrawn += IIf(row.SubItems(8).Text = "", 0, row.SubItems(8).Text)
                End If

            End If
        Next

        aggregates += vbCrLf & vbCrLf & "Partial Requested: " & rs_qty
        aggregates += vbCrLf & "Withdraw: " & rs_withdrawn
        aggregates += vbCrLf & "Balance: " & rs_qty - rs_withdrawn

        aggregates += vbCrLf & vbCrLf & vbCrLf

    End Sub

    Private Sub FAggregates_General_Request_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''by_projectcode()

        For Each agg In LIST_OF_AGGREGATES()
            cmbAggregates.Items.Add(agg)

            ' Set the properties of the ToolStripMenuItem
            Dim toolStripMenuItem1 As New ToolStripMenuItem()

            toolStripMenuItem1.Name = agg
            toolStripMenuItem1.Size = New Size(154, 22)
            toolStripMenuItem1.Text = agg
            AddHandler toolStripMenuItem1.Click, AddressOf AgToolStripMenuItem_Click

            SetAggregatesNameToolStripMenuItem.DropDownItems.Add(toolStripMenuItem1)
        Next

        FDRLIST.load_requestor(cmbProject, 14)
        ''cmbProject.Items.Add("")

        'load_warehouse()
    End Sub

    Private Function LIST_OF_AGGREGATES() As List(Of String)

        LIST_OF_AGGREGATES = New List(Of String)

        With LIST_OF_AGGREGATES
            .Add("FINE SAND")
            .Add("3/4")
            .Add("WASTE")
            .Add("ITEM 104")
            .Add("ITEM 200")
            .Add("EMBANKMENT SOIL")
            .Add("MIXED STONE")
            .Add("BOULDERS")
            .Add("ITEM 300")
            .Add("BOULDERS (HS)")
            .Add("MOUNTAIN SOIL")
            .Add("FILLING MATERIALS")
            .Add("MIXED")
            .Add("MOUNTAIN GRAVEL")
            .Add("G-1")
            .Add("RIVER MIX")

        End With

        LIST_OF_AGGREGATES.Sort()


    End Function
    Private Sub load_warehouse()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        cmbProject.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("select DISTINCT wh_area from dbwh_area ORDER BY wh_area ASC", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.Text
            newDR = newCMD.ExecuteReader
            Dim a(3) As String

            While newDR.Read
                cmbProject.Items.Add(newDR("wh_area").ToString)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Public Sub by_projectcode()
        Dim sq As New SQLcon
        Dim dr1 As SqlDataReader
        Dim cmd1 As SqlCommand
        cmbProject.Items.Clear()
        Dim i As Integer = 0
        Try

            sq.connection1.Open()
            publicquery = "SELECT project_desc, location, project_engineer FROM dbprojectdesc ORDER BY project_desc ASC"
            cmd1 = New SqlCommand(publicquery, sq.connection1)

            dr1 = cmd1.ExecuteReader

            While dr1.Read
                cmbProject.Items.Add(dr1.Item("project_desc").ToString)
            End While
            dr1.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sq.connection1.Close()
        End Try
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        For Each row As ListViewItem In lvlAllRs.Items
            row.Checked = True
        Next
    End Sub

    Private Sub DeselectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeselectAllToolStripMenuItem.Click
        For Each row As ListViewItem In lvlAllRs.Items
            row.Checked = False
        Next
    End Sub

    Private Sub CalculateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalculateToolStripMenuItem.Click
        Button1.PerformClick()

    End Sub

    Private Sub cmbSearchby_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearchby.SelectedIndexChanged
        If cmbSearchby.Text = "Search by Specific Aggregates" Then

            cmbProject.Visible = True
            cmbAggregates.Visible = True
            dtpfrom.Visible = True
            dtpto.Visible = True

        Else
            cmbProject.Visible = True
            cmbAggregates.Visible = False
            dtpfrom.Visible = True
            dtpto.Visible = True
        End If
    End Sub

    Private Sub GenerateAllProjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerateAllProjectToolStripMenuItem.Click
        Dim a(10) As String
        'FStockpile_monitoring.lvlSelectedAggregates.Items.Clear()
        'Dim counter As Integer = 0
        'btnSearch.PerformClick()

        'For Each row As ListViewItem In lvlAllRs.Items
        '    row.Checked = True
        'Next

        For Each proj As String In cmbProject.Items
            counter = 0

            For Each row As ListViewItem In lvlAllRs.Items
                If row.SubItems(5).Text = proj Then
                    counter += 1
                End If
            Next

            If counter > 0 Then
                'cmbProject.Text = proj

                a(1) = proj
                a(3) = general_aggregates_calc1("FINE SAND", proj)
                a(4) = general_aggregates_calc1("3/4", proj)
                a(5) = general_aggregates_calc1("G-1", proj)
                a(6) = general_aggregates_calc1("Waste", proj)

                Dim lvl As New ListViewItem(a)
                FStockpile_monitoring.lvlSelectedAggregates.Items.Add(lvl)

                'FStockpile_monitoring.ShowDialog()

                form_active("FStockpile_monitoring")
                FStockpile_monitoring.Show()
                Application.DoEvents()
            End If

        Next

        Dim finesand, three4th, g1, waste As Decimal

        For Each row As ListViewItem In FStockpile_monitoring.lvlSelectedAggregates.Items

            finesand += row.SubItems(3).Text
            three4th += row.SubItems(4).Text
            g1 += row.SubItems(5).Text
            waste += row.SubItems(6).Text

        Next

        Dim a1(6) As String

        a1(1) = "TOTAL:"
        a1(3) = FormatNumber(finesand, 2,,, TriState.True)
        a1(4) = FormatNumber(three4th, 2,,, TriState.True)
        a1(5) = FormatNumber(g1, 2,,, TriState.True)
        a1(6) = FormatNumber(waste, 2,,, TriState.True)

        Dim lvl1 As New ListViewItem(a1)
        FStockpile_monitoring.lvlSelectedAggregates.Items.Add(lvl1)

        form_active("FStockpile_monitoring")
        FStockpile_monitoring.Show()
        Application.DoEvents()

        'btnSearch.PerformClick()

        'For Each row As ListViewItem In lvlAllRs.Items
        '    row.Checked = True
        'Next

        'a(1) = cmbProject.Text
        'a(3) = general_aggregates_calc1("FINE SAND")
        'a(4) = general_aggregates_calc1("G-1")
        'a(5) = general_aggregates_calc1("3/4")
        'a(6) = general_aggregates_calc1("Waste")

        'Dim lvl As New ListViewItem(a)
        'FStockpile_monitoring.lvlSelectedAggregates.Items.Add(lvl)





    End Sub

    Private Function general_aggregates_calc1(type_of_aggregates As String, project As String) As Decimal
        Dim rs_qty As Decimal
        Dim rs_withdrawn As Decimal
        Dim delivered As Decimal

        'aggregates += type_of_aggregates & ":"

        For Each row As ListViewItem In lvlAllRs.Items
            If row.Checked = True Then
                If row.SubItems(7).Text = type_of_aggregates And row.SubItems(5).Text = project Then
                    rs_qty += IIf(row.SubItems(2).Text = "", 0, row.SubItems(2).Text)

                    'delivered += IIf(row.SubItems(10).Text = "", 0, row.SubItems(10).Text)

                    If row.SubItems(13).Text = "OTHERS" Then
                        rs_withdrawn += IIf(row.SubItems(10).Text = "", 0, row.SubItems(10).Text)
                    ElseIf row.SubItems(13).Text = "OUT" Then
                        rs_withdrawn += IIf(row.SubItems(8).Text = "", 0, row.SubItems(8).Text)
                    End If
                End If
            End If
        Next

        'aggregates += vbCrLf & vbCrLf & "Partial Requested: " & rs_qty
        'aggregates += vbCrLf & "Withdraw: " & rs_withdrawn
        'aggregates += vbCrLf & "Balance: " & rs_qty - rs_withdrawn

        general_aggregates_calc1 = rs_qty - rs_withdrawn

        'aggregates += vbCrLf & vbCrLf & vbCrLf

    End Function

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click


        For Each selectedItem As ListViewItem In lvlAllRs.SelectedItems
            lvlAllRs.Items.Remove(selectedItem)
        Next
    End Sub

    Private Sub AgToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim t As ToolStripMenuItem = sender

        For Each row As ListViewItem In lvlAllRs.Items
            If row.Selected = True Then
                row.SubItems(7).Text = t.Text
            End If
        Next
    End Sub
End Class