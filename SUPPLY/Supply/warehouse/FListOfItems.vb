Imports System.ComponentModel
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FListOfItems

    Public SQ As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Public query As String
    Dim rs_no_not_withdrawn As Integer
    Public COUNT As Integer
    Dim total_quantity_pending_request As Integer
    Dim balance_of_list_of_items As Integer

    Dim txtname As String

    Dim thread_1 As Threading.Thread
    Dim t1 As Threading.Thread
    Dim t2 As System.Threading.Thread
    Dim t3 As System.Threading.Thread
    Public date_from As String
    Public date_to As String
    Public popupmsg As String
    Dim list_item_name As New List(Of List(Of String))
    Dim list_item_desc As New List(Of List(Of String))
    Dim list_warehouse_area As New List(Of List(Of String))
    Dim crs_data As New Class_SC_Hauling.SC_Hauling_Data
    Dim list_person_name As New List(Of List(Of String))
    Dim list_person_name2 As New List(Of List(Of String))
    Dim next1 As Integer
    Private customMsg As New customMessageBox

    Private cImportantIds As New FDRLIST1.important_ids
    Public isItemLinked As Boolean = False
    Public cWh_pn_id As Integer = 0

    Private whItemsModel,
        whInchargeModel,
        displayResultModel,
        properNamingModel,
        WhInchargeNewModel,
        EmployeeModel,
        AllChargesModel,
        whAreaStockpileModel As New ModelNew.Model

    Dim cBgWorkerChecker As Timer
    Private cListOfListViewItem As New List(Of ListViewItem)
    Private cSearchBy1, cSearch, cOptions As String
    Dim c As New CustomizedFields
    Private cListOfWhArea As New List(Of PropsFields.whArea_stockpile_props_fields)
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    'SET IMPORTANT IDS FROM DRLIST1 REQUESTOR
    Public Sub setIds(Optional importantIds As FDRLIST1.important_ids = Nothing)
        cImportantIds.rs_id = importantIds.rs_id
        cImportantIds.wh_id = importantIds.wh_id

    End Sub

    Private Class searchEnum
        Public Shared ReadOnly searchByItemName As String = "Search By Item Name"
        Public Shared ReadOnly searchByItemDesc As String = "Search By Item Desc."
        Public Shared ReadOnly searchByTurnoverTools As String = "Search By Turnover Tools/Materials"
        Public Shared ReadOnly searchByWarehouseArea As String = "Search By Warehouse Area"
        Public Shared ReadOnly searchByAll As String = "Search By All"
    End Class



    'Public fd As New FDATERANGE
    Private Sub load_items(n As Integer, data_list As List(Of List(Of String)), search_option As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim data_list1 As New List(Of List(Of String))
        data_list1 = data_list
        '1 - item name 
        '2 - item desc
        '3 - warehouse area
        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_list_of_item1", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", n)
            If n = 1 Then
                newCMD.Parameters.AddWithValue("@search_option", search_option)
            ElseIf n = 2 Then
                newCMD.Parameters.AddWithValue("@search_option", search_option)
            End If
            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim items As New List(Of String)

                items.Add(newDR.Item(0).ToString)
                data_list1.Add(items)

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

            Dim placeholder As New Class_PlaceHolder_Warehouse
            Select Case cmbSearchby.Text
                Case "Search By Item Desc"

                    placeholder.load_what_you_search(txtItemDesc, list_item_desc)

                Case "Search By Item Name"
                    placeholder.load_what_you_search(txtSearch, list_item_name)
                Case "Search By Warehouse Area"

                Case "Search By All"
                    placeholder.load_what_you_search(txtSearch, list_item_name)
                    placeholder.load_what_you_search(txtItemDesc, list_item_desc)

            End Select


        End Try
    End Sub


    Private Function load_items1(n As Integer, search_option As String) As List(Of List(Of String))
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim data_list1 As New List(Of List(Of String))
        '1 - item name 
        '2 - item desc
        '3 - warehouse area
        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_list_of_item1", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", n)
            If n = 1 Then
                newCMD.Parameters.AddWithValue("@search_option", search_option)
            ElseIf n = 2 Then
                newCMD.Parameters.AddWithValue("@search_option", search_option)
            End If
            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim items As New List(Of String)

                items.Add(newDR.Item(0).ToString)
                data_list1.Add(items)

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

            load_items1 = data_list1

            'Dim placeholder As New Class_PlaceHolder_Warehouse
            'Select Case cmbSearchby.Text
            '    Case "Search By Item Desc"

            '        placeholder.load_what_you_search(txtItemDesc, list_item_desc)

            '    Case "Search By Item Name"
            '        placeholder.load_what_you_search(txtSearch, list_item_name)
            '    Case "Search By Warehouse Area"

            '    Case "Search By All"
            '        placeholder.load_what_you_search(txtSearch, list_item_name)
            '        placeholder.load_what_you_search(txtItemDesc, list_item_desc)

            'End Select


        End Try
    End Function
    Private Sub FListOfItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

#Region "REARRANGE COLUMNS IN LISTVIEW"
        Dim reArrange As New ListTabIndex
        With reArrange
            .addColumns(col_wh_id)
            .addColumns(col_item_name)
            .addColumns(col_item_desc)
            .addColumns(col_wh_area_stockpile)
            .addColumns(col_quarry)
            .addColumns(col_balance)
            .addColumns(col_total_request)
            .addColumns(col_total_qty_from_requestor)
            .addColumns(col_specifi_location)
            .addColumns(col_reorder_point)
            .addColumns(col_price)
            .addColumns(col_unit)
            .addColumns(col_type_of_request)
            .addColumns(col_condition)
            .addColumns(col_clasification)
            .addColumns(col_link_qty)
            .addColumns(col_wh_incharge)
            .addColumns(col_wh_pn_id)
        End With

        reArrange.rearrangeTabIndex()
#End Region

        'wh_incharge_name()
        'aprove_by_name()

        Panel2.Hide()

        'Me.CheckForIllegalCrossThreadCalls = False

        'If lblInOut.Text = "OUT" Then
        '    With cmbSearchby
        '        .Items.Clear()
        '        .Items.Add("Search By Item Name")
        '        .Items.Add("Search By Item Desc")
        '        .Items.Add("Search By Turnover Tools/Materials")
        '        .Items.Add("Search By All")
        '        .Items.Add(cSearchBy.SEARCH_BY_PROPER_NAMING)

        '    End With
        'Else
        '    With cmbSearchby
        '        .Items.Clear()
        '        .Items.Add("Search By Item Name")
        '        .Items.Add("Search By Item Desc")
        '        .Items.Add("Search By Warehouse Area")
        '        .Items.Add("Search By All")
        '        .Items.Add(cSearchBy.SEARCH_BY_PROPER_NAMING)
        '    End With
        'End If

        'cmbSearchby.SelectedIndex = 0


        ''load_items(1, list_item_name, "")
        ''load_items(2, list_item_desc, "")
        'load_items(3, list_warehouse_area, "")

        'Dim placeholder As New Class_PlaceHolder_Warehouse

        ''placeholder.load_what_you_search(txtSearch, list_item_name)
        ''placeholder.load_what_you_search(txtItemDesc, list_item_desc)
        'placeholder.load_what_you_search(txtWarehouseArea, list_warehouse_area)

        ''triggered when items link to proper naming
        'If isItemLinked Then
        '    cmbSearchby.Text = cSearchBy.SEARCH_BY_PROPER_NAMING
        '    btnSearch2.PerformClick()
        '    FlowLayoutPanel1.Enabled = False
        'End If


        Dim dic As New Dictionary(Of String, Object)

        dic.Add("panel", Panel3)
        dic.Add("icon", My.Resources.received)
        dic.Add("panelBox", Nothing)

        c.initializeOptions(dic)

        c.addCustomizeTextBox(txtSearch, "search here...")
        c.addCustomizeTextBox(txtItemDesc, "search here...")
        c.addCustomizeTextBox(txtWarehouseArea, "warehouse area...")

        c.addCustomizeComboBox(cmboptions, "options...")
        c.addCustomizeComboBox(cmbSearchby, "search by...")

        c.runByBatch()

        loadWhItems()

    End Sub

    Public Sub search_item_from_warehouse(ByVal val As String, searchby As String, ByVal n As Integer)
        lvlWarehouseItem.Items.Clear()
        Dim i As Integer
        Try
            SQ.connection.Open()

            Dim tor_sub_id As Integer '= get_id("dbType_of_Request_sub", "tor_sub_desc", FRequestField.cmbTOR_sub.Text, 0)
            Dim inout_id As Integer '= get_id("dbinout", "in_out_desc", "IN", 0)
            Dim tsp_id As Integer '= get_id("dbtor_sub_property", "tor_sub_id^inout_id", tor_sub_id & "^" & inout_id, 3)

            cmd = New SqlCommand("proc_get_data_from_warehouse", SQ.connection)

            cmd.CommandTimeout = 0
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@search", val)
            cmd.Parameters.AddWithValue("@searchby", searchby)


            If cmboptions.Text = "WAREHOUSING" Then
                cmd.Parameters.AddWithValue("@option", "WAREHOUSING AND SUPPLY")
            Else
                cmd.Parameters.AddWithValue("@option", "CRUSHING AND HAULING")
            End If

            cmd.Parameters.AddWithValue("@n", n)
            cmd.Parameters.AddWithValue("@tsp_id", tsp_id)

            'If cmbSearchby.Text = "Search By Item Name" Then
            '    cmd.Parameters.AddWithValue("@n", 2)
            'ElseIf cmbSearchby.Text = "Search By Item Desc." Then
            '    cmd.Parameters.AddWithValue("@n", 4)
            'ElseIf cmbSearchby.Text = "" Then
            '    cmd.Parameters.AddWithValue("@n", 3)
            'End If

            dr = cmd.ExecuteReader
            Dim a(20) As String

            While dr.Read

                Dim wh_id As Integer = CInt(dr.Item("wh_id").ToString)

                If n = 3 Then

                Else
                    a(0) = dr.Item("wh_id").ToString
                    a(1) = dr.Item("whItem").ToString
                    a(2) = dr.Item("whItemDesc").ToString
                    a(3) = dr.Item("whArea").ToString

                    Dim qty_from_prev_stock_card As Double = get_qty_from_dbPrevious_stock_card(wh_id)
                    'Dim qty_requested_and_received_IN = get_total_qty_requested_and_received_IN(wh_id)
                    'Dim balance As Double = qty_from_prev_stock_card + qty_requested_and_received_IN

                    'a(4) = balance - get_total_qty_requested_and_withdrawn(wh_id, 1)

                    a(14) = IIf(dr.Item("link_qty").ToString = "", 0, dr.Item("link_qty").ToString)

                    If popupmsg = 1 Then

                        'a(4) = FormatNumber(get_wh_item_balance2(wh_id) + qty_from_prev_stock_card + CDbl(a(14)), , TriState.True) 'get_wh_item_balance(dr.Item("wh_id").ToString)
                        a(4) = FormatNumber(get_beginning_balance1(wh_id), 2,,, TriState.True)
                        a(5) = get_total_qty_requested_and_not_withdrawn_yet(wh_id, 1) '1 - total requested
                        a(6) = FormatNumber(get_total_qty_requested_and_not_withdrawn_yet(wh_id, 2),, TriState.True) '2 -total qty from requestor

                    ElseIf popupmsg = 2 Then

                        a(4) = 0
                        a(5) = 0
                        a(6) = 0

                    End If

                    'balance = get_qty_from_dbPrevious_stock_card(dr.Item("wh_id").ToString) + get_received_dr_items(dr.Item("wh_id").ToString)

                    'a(4) = balance - total_withdrawn_item(dr.Item("wh_id").ToString)
                    'a(5) = count_request_not_withdrawn(a(0), "WITHDRAWAL")
                    'a(6) = get_pending_withdrawn(dr.Item("wh_id").ToString)

                    a(7) = dr.Item("whSpecificLoc").ToString
                    a(8) = dr.Item("whReorderPoint").ToString
                    a(9) = FormatNumber(update_item_price(dr.Item("wh_id").ToString), 2, , , TriState.True)
                    a(10) = dr.Item("unit").ToString
                    a(11) = dr.Item("tor_desc").ToString & " - " & dr.Item("tor_sub_desc").ToString
                    a(13) = dr.Item("whClass").ToString

                    Dim lvl As New ListViewItem(a)
                    lvlWarehouseItem.Items.Add(lvl)

                    If popupmsg = 1 Then
                        If CDbl(a(8)) >= CDbl(a(4)) Then
                            lvlWarehouseItem.Items(i).BackColor = Color.Red
                            lvlWarehouseItem.Items(i).ForeColor = Color.White
                        End If

                        If CDbl(a(8)) = 0 And CDbl(a(4)) = 0 Then
                            lvlWarehouseItem.Items(i).BackColor = Color.Pink
                            lvlWarehouseItem.Items(i).ForeColor = Color.Black
                        End If
                    End If

                    'If CDbl(lvlWarehouseItem.Items(i).SubItems(4).Text) >= CDbl(lvlWarehouseItem.Items(i).SubItems(6).Text) Then
                    '    lvlWarehouseItem.Items(i).BackColor = Color.Red
                    '    lvlWarehouseItem.Items(i).ForeColor = Color.White
                    'End If '' ORIGINAL

                    'If FormatNumber(get_wh_item_balance2(wh_id) + qty_from_prev_stock_card + CDbl(a(14)), , TriState.True) > CDbl(lvlWarehouseItem.Items(i).SubItems(8).Text) Then
                    '    'lvlWarehouseItem.Items(i).BackColor = Color.Red
                    '    'lvlWarehouseItem.Items(i).ForeColor = Color.White
                    'ElseIf FormatNumber(get_wh_item_balance2(wh_id) + qty_from_prev_stock_card + CDbl(a(14))) = CDbl(lvlWarehouseItem.Items(i).SubItems(8).Text) Then
                    '    lvlWarehouseItem.Items(i).BackColor = Color.Black
                    '    lvlWarehouseItem.Items(i).ForeColor = Color.White
                    'Else
                    '    lvlWarehouseItem.Items(i).BackColor = Color.Red
                    '    lvlWarehouseItem.Items(i).ForeColor = Color.White
                    'End If

                    'If get_total_qty_requested_and_not_withdrawn_yet(wh_id, 1) >= 1 Then
                    '    lvlWarehouseItem.Items(i).BackColor = Color.Orange
                    'End If

                    i += 1
                End If
                ' MsgBox(a(12))
                Application.DoEvents()

            End While

            dr.Close()


        Catch ex As Exception

            If ex.Message = "Thread was being aborted." Then
                Exit Sub
                ' MessageBox.Show("Thread was being aborted...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Finally
            SQ.connection.Close()
            lvlWarehouseItem.Enabled = True

            cmbSearchby.Enabled = True
            txtSearch.Enabled = True
            btnSearch.Enabled = True
        End Try
    End Sub

    Public Sub search_item_from_warehouse2(ByVal STthread_Data As search_wh_data)

        Dim searchby As String = STthread_Data.searchby
        Dim searching As String = STthread_Data.searching
        Dim n As Integer = STthread_Data.n

        Dim i As Integer
        Try
            SQ.connection.Open()

            Dim tor_sub_id As Integer '= get_id("dbType_of_Request_sub", "tor_sub_desc", FRequestField.cmbTOR_sub.Text, 0)
            Dim inout_id As Integer '= get_id("dbinout", "in_out_desc", "IN", 0)
            Dim tsp_id As Integer '= get_id("dbtor_sub_property", "tor_sub_id^inout_id", tor_sub_id & "^" & inout_id, 3)

            cmd = New SqlCommand("proc_get_data_from_warehouse", SQ.connection)

            cmd.CommandTimeout = 0
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@search", searching)
            cmd.Parameters.AddWithValue("@searchby", searchby)

            If cmboptions.Text = "WAREHOUSING" Then
                cmd.Parameters.AddWithValue("@option", "WAREHOUSING AND SUPPLY")
            Else
                cmd.Parameters.AddWithValue("@option", "CRUSHING AND HAULING")
            End If

            cmd.Parameters.AddWithValue("@n", n)
            cmd.Parameters.AddWithValue("@tsp_id", tsp_id)

            'If cmbSearchby.Text = "Search By Item Name" Then
            '    cmd.Parameters.AddWithValue("@n", 2)
            'ElseIf cmbSearchby.Text = "Search By Item Desc." Then
            '    cmd.Parameters.AddWithValue("@n", 4)
            'ElseIf cmbSearchby.Text = "" Then
            '    cmd.Parameters.AddWithValue("@n", 3)
            'End If

            dr = cmd.ExecuteReader
            Dim a(20) As String

            While dr.Read

                Dim wh_id As Integer = CInt(dr.Item("wh_id").ToString)

                If n = 3 Then

                Else
                    a(0) = dr.Item("wh_id").ToString
                    a(1) = dr.Item("whItem").ToString
                    a(2) = dr.Item("whItemDesc").ToString
                    a(3) = dr.Item("whArea").ToString

                    'Dim qty_from_prev_stock_card As Double = get_qty_from_dbPrevious_stock_card(wh_id)
                    'Dim qty_requested_and_received_IN = get_total_qty_requested_and_received_IN(wh_id)
                    'Dim balance As Double = qty_from_prev_stock_card + qty_requested_and_received_IN

                    'a(4) = balance - get_total_qty_requested_and_withdrawn(wh_id, 1)

                    a(14) = IIf(dr.Item("link_qty").ToString = "", 0, dr.Item("link_qty").ToString)

                    If popupmsg = 1 Then

                        'a(4) = FormatNumber(get_wh_item_balance2(wh_id) + qty_from_prev_stock_card + CDbl(a(14)), , TriState.True) 'get_wh_item_balance(dr.Item("wh_id").ToString)
                        a(4) = FormatNumber(get_beginning_balance1(wh_id), 2,,, TriState.True)
                        a(5) = get_total_qty_requested_and_not_withdrawn_yet(wh_id, 1) '1 - total requested
                        a(6) = FormatNumber(get_total_qty_requested_and_not_withdrawn_yet(wh_id, 2),, TriState.True) '2 -total qty from requestor

                    ElseIf popupmsg = 2 Then

                        a(4) = 0
                        a(5) = 0
                        a(6) = 0

                    End If

                    'balance = get_qty_from_dbPrevious_stock_card(dr.Item("wh_id").ToString) + get_received_dr_items(dr.Item("wh_id").ToString)

                    'a(4) = balance - total_withdrawn_item(dr.Item("wh_id").ToString)
                    'a(5) = count_request_not_withdrawn(a(0), "WITHDRAWAL")
                    'a(6) = get_pending_withdrawn(dr.Item("wh_id").ToString)

                    a(7) = dr.Item("whSpecificLoc").ToString
                    a(8) = dr.Item("whReorderPoint").ToString
                    a(9) = FormatNumber(update_item_price(dr.Item("wh_id").ToString), 2, , , TriState.True)
                    a(10) = dr.Item("unit").ToString
                    a(11) = dr.Item("tor_desc").ToString & " - " & dr.Item("tor_sub_desc").ToString
                    a(13) = dr.Item("whClass").ToString

                    Dim lvl As New ListViewItem(a)

                    If lvlWarehouseItem.InvokeRequired Then
                        lvlWarehouseItem.Invoke(Sub() lvlWarehouseItem.Items.Add(lvl))
                    Else
                        lvlWarehouseItem.Items.Add(lvl)
                    End If

                    'ListView.Items.Add(lvl)

                    'If popupmsg = 1 Then
                    '    If CDbl(a(8)) >= CDbl(a(4)) Then
                    '        lvlWarehouseItem.Items(i).BackColor = Color.Red
                    '        lvlWarehouseItem.Items(i).ForeColor = Color.White
                    '    End If

                    '    If CDbl(a(8)) = 0 And CDbl(a(4)) = 0 Then
                    '        lvlWarehouseItem.Items(i).BackColor = Color.Pink
                    '        lvlWarehouseItem.Items(i).ForeColor = Color.Black
                    '    End If
                    'End If

                    'If CDbl(lvlWarehouseItem.Items(i).SubItems(4).Text) >= CDbl(lvlWarehouseItem.Items(i).SubItems(6).Text) Then
                    '    lvlWarehouseItem.Items(i).BackColor = Color.Red
                    '    lvlWarehouseItem.Items(i).ForeColor = Color.White
                    'End If '' ORIGINAL

                    'If FormatNumber(get_wh_item_balance2(wh_id) + qty_from_prev_stock_card + CDbl(a(14)), , TriState.True) > CDbl(lvlWarehouseItem.Items(i).SubItems(8).Text) Then
                    '    'lvlWarehouseItem.Items(i).BackColor = Color.Red
                    '    'lvlWarehouseItem.Items(i).ForeColor = Color.White
                    'ElseIf FormatNumber(get_wh_item_balance2(wh_id) + qty_from_prev_stock_card + CDbl(a(14))) = CDbl(lvlWarehouseItem.Items(i).SubItems(8).Text) Then
                    '    lvlWarehouseItem.Items(i).BackColor = Color.Black
                    '    lvlWarehouseItem.Items(i).ForeColor = Color.White
                    'Else
                    '    lvlWarehouseItem.Items(i).BackColor = Color.Red
                    '    lvlWarehouseItem.Items(i).ForeColor = Color.White
                    'End If

                    'If get_total_qty_requested_and_not_withdrawn_yet(wh_id, 1) >= 1 Then
                    '    lvlWarehouseItem.Items(i).BackColor = Color.Orange
                    'End If

                    i += 1
                End If
                ' MsgBox(a(12))
                Application.DoEvents()

            End While

            dr.Close()


        Catch ex As Exception

            If ex.Message = "Thread was being aborted." Then
                Exit Sub
                ' MessageBox.Show("Thread was being aborted...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Finally
            SQ.connection.Close()
            lvlWarehouseItem.Enabled = True

            cmbSearchby.Enabled = True
            txtSearch.Enabled = True
            btnSearch.Enabled = True
        End Try
    End Sub
    Private Function get_beginning_balance1(wh_id As Integer) As Decimal
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard4", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 8)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newCMD.Parameters.AddWithValue("@datefrom", Date.Parse(Now))
            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                get_beginning_balance1 = IIf(newDR.Item("balance").ToString = "", 0, newDR.Item("balance").ToString)
            End While

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

    Public Function get_wh_item_balance2(wh_id As Integer) As Double
        Dim beginning_balance As Double

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.CommandTimeout = 200 'added this to not popup request error | 4/12/24 => KJ

            If cmboptions.Text = "WAREHOUSING" Then
                newCMD.Parameters.AddWithValue("@n", 7)
            ElseIf cmboptions.Text = "HAULING AND CRUSHING" Then
                newCMD.Parameters.AddWithValue("@n", 88)
            End If

            newCMD.Parameters.AddWithValue("@wh_id", wh_id)

            newDR = newCMD.ExecuteReader
            While newDR.Read

                If cmboptions.Text = "WAREHOUSING" Then

                    If newDR.Item("dr_option").ToString = "WITH DR" And newDR.Item("DR").ToString = "PARENT DR" Then
                        GoTo proceedhere
                    End If

                    If newDR.Item("IN_OUT").ToString = "OUT" Then

                        beginning_balance = beginning_balance - CDbl(newDR.Item("desired_qty").ToString)

                    ElseIf newDR.Item("IN_OUT").ToString = "IN" Then

                        beginning_balance = beginning_balance + CDbl(newDR.Item("desired_qty").ToString)

                    End If
proceedhere:
                ElseIf cmboptions.Text = "HAULING AND CRUSHING" Then
                    Dim rs_no As String = newDR.Item("rs_no").ToString
                    Dim ws_no As String = newDR.Item("WS_NO").ToString


                    If newDR.Item("WITHDRAWN").ToString = "NO" Then
                        GoTo proceedhere1
                    End If

                    If newDR.Item("stat").ToString = "" And newDR.Item("dr_no").ToString = "" Then
                        GoTo proceedhere1
                    End If

                    If newDR.Item("IN_OUT").ToString = "OUT" Then
                        If newDR.Item("SORTING").ToString = "A" Then
                            beginning_balance = beginning_balance - CDbl(CDbl(newDR.Item("qty_OUT").ToString) - FStockCard.count_qty_dr_using_ws_no(ws_no, rs_no, 12))
                        Else
                            beginning_balance = beginning_balance - CDbl(newDR.Item("qty_OUT").ToString)
                        End If

                    ElseIf newDR.Item("IN_OUT").ToString = "IN" Then

                        beginning_balance = beginning_balance + CDbl(newDR.Item("qty_IN").ToString)

                    End If
proceedhere1:

                End If

            End While
            newDR.Close()

            get_wh_item_balance2 = beginning_balance

        Catch ex As Exception
            If ex.Message = "Thread was being aborted." Then

            Else
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Public Function get_wh_item_balance1(wh_id As Integer) As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim a(20) As String


        Try
            newSQ.connection.Open()

            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.CommandTimeout = 0
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 3)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)

            newDR = newCMD.ExecuteReader

            Dim beginningbalance As Double

            While newDR.Read

                Dim INOUT As String = newDR.Item("IN_OUT").ToString
                Dim type_of_purchasing = newDR.Item("type_of_purchasing").ToString

                If INOUT = "IN" Then
                    If type_of_purchasing = "DR" Then
                        If newDR.Item("DR_ID_PO_DET_ID").ToString = "" Then
                            GoTo proceedhere
                        Else
                            beginningbalance = beginningbalance + CDbl(newDR.Item("PO_WS_QTY").ToString)
                        End If

                    Else
                        beginningbalance = beginningbalance + CDbl(newDR.Item("PARTIALLY_RR").ToString)
                    End If

                    get_wh_item_balance1 = beginningbalance

                ElseIf INOUT = "OUT" Then

                    If newDR.Item("dr_option").ToString = "WITH DR" And newDR.Item("DR_NO").ToString = "" Then
                        GoTo proceedhere
                    End If

                    If newDR.Item("WITHDRAWN_ITEM").ToString = "" Then
                        'meaning wala pa na withdraw
                        GoTo proceedhere
                    End If

                    beginningbalance = beginningbalance - CDbl(newDR.Item("PO_WS_QTY").ToString)

                    get_wh_item_balance1 = beginningbalance

                End If

proceedhere:

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function


    Public Function get_wh_item_balance(wh_id As Integer) As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim a(20) As String
        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_get_data_from_warehouse", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure


            If wh_id = 0 Then
                Exit Function
            End If

            newCMD.Parameters.AddWithValue("@n", 17)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)

            newDR = newCMD.ExecuteReader

            Dim beginningbalance As Double = FStockCard.get_prev_item_balance(wh_id)

            While newDR.Read

                Dim INOUT As String = newDR.Item("IN_OUT").ToString
                Dim type_of_purchasing = newDR.Item("type_of_purchasing").ToString

                a(3) = newDR.Item("RS_NO").ToString
                a(4) = IIf(newDR.Item("INVOICE_NO").ToString = "", "N/A", newDR.Item("INVOICE_NO").ToString)
                a(5) = IIf(newDR.Item("RR_NO").ToString = "", "N/A", newDR.Item("RR_NO").ToString)

                If INOUT = "IN" Then
                    If type_of_purchasing = "DR" Then
                        If newDR.Item("DR_ID_PO_DET_ID").ToString = "" Then
                            GoTo proceedhere
                        Else
                            'a(2) = Format(Date.Parse(newDR.Item("RR_DR_WS_DATE").ToString), "MM/dd/yyyy")
                            'a(4) = newDR.Item("DR_NO").ToString
                            'a(6) = "N/A"
                            'a(7) = newDR.Item("SOURCE_WH").ToString
                            'a(8) = newDR.Item("PO_WS_QTY").ToString
                            'a(9) = 0

                            beginningbalance = beginningbalance + CDbl(newDR.Item("PO_WS_QTY").ToString)
                        End If

                    Else
                        'a(2) = Format(Date.Parse(newDR.Item("RR_DR_WS_DATE").ToString), "MM/dd/yyyy")
                        'a(6) = "N/A"
                        'a(7) = newDR.Item("SOURCE_SUPPLIER").ToString
                        'a(8) = newDR.Item("PARTIALLY_RR").ToString
                        'a(9) = 0

                        beginningbalance = beginningbalance + CDbl(newDR.Item("PARTIALLY_RR").ToString)
                    End If

                    get_wh_item_balance = beginningbalance

                ElseIf INOUT = "OUT" Then

                    If type_of_purchasing = "WITHDRAWAL" And newDR.Item("DR_ID_PO_DET_ID").ToString = "" Then

                        'meaning nag out pero walay withdrawal form
                        'a(2) = Format(Date.Parse(newDR.Item("PO_DATE").ToString), "MM/dd/yyyy")
                        'a(4) = "N/A"
                        'a(7) = newDR.Item("SOURCE_WH").ToString

                    ElseIf type_of_purchasing = "WITHDRAWAL" And newDR.Item("DR_ID_PO_DET_ID").ToString <> "" Then

                        ''meaning nag out pero naay withdrawal
                        'a(2) = Format(Date.Parse(newDR.Item("RR_DR_WS_DATE").ToString), "MM/dd/yyyy")
                        'a(4) = newDR.Item("DR_NO").ToString
                        'a(7) = IIf(newDR.Item("SOURCH_DR").ToString = "", newDR.Item("SOURCE_WH").ToString, newDR.Item("SOURCH_DR").ToString)

                    End If

                    If newDR.Item("WITHDRAWN_ITEM").ToString = "" Then
                        'meaning wala pa na withdraw
                        GoTo proceedhere
                    End If

                    'a(5) = "N/A"
                    'a(6) = IIf(newDR.Item("PO_WS_NO").ToString = "", "N/A", newDR.Item("PO_WS_NO").ToString)
                    'a(8) = 0
                    'a(9) = newDR.Item("PO_WS_QTY").ToString

                    beginningbalance = beginningbalance - CDbl(newDR.Item("PO_WS_QTY").ToString)

                    get_wh_item_balance = beginningbalance

                End If

proceedhere:

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Public Function get_total_qty_requested_and_received_IN(wh_id As Integer) As Double

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_list_of_item", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newCMD.Parameters.AddWithValue("@n", 1)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_total_qty_requested_and_received_IN += CInt(newDR.Item("desired_qty").ToString)

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
            GC.Collect()

        End Try
    End Function

    Public Function get_total_qty_requested_and_not_withdrawn_yet(wh_id As Integer, nn As Integer) As Double

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_list_of_item", newSQ.connection)
            newCMD.CommandTimeout = 0
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newCMD.Parameters.AddWithValue("@n", 3)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                ' If newDR.Item("ws_id").ToString = "" Then
                If nn = 1 Then
                    get_total_qty_requested_and_not_withdrawn_yet += 1
                ElseIf nn = 2 Then
                    If newDR.Item("qty_left").ToString = "" Then
                    Else
                        get_total_qty_requested_and_not_withdrawn_yet += CDbl(newDR.Item("qty_left").ToString)
                    End If

                    'get_total_qty_requested_and_not_withdrawn_yet += CDbl(newDR.Item("rs_qty").ToString)
                End If
                ' End If
            End While
            newDR.Close()

        Catch ex As Exception
            If ex.Message = "Thread was being aborted." Then
                Exit Function
                ' MessageBox.Show("Thread was being aborted...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Finally
            newSQ.connection.Close()
            GC.Collect()

        End Try
    End Function

    Public Function get_total_qty_requested_and_withdrawn(wh_id As Integer, nn As Integer) As Double

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_list_of_item", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newCMD.Parameters.AddWithValue("@n", 2)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim ws_qty As Double

                If newDR.Item("ws_qty").ToString = "" Then
                    ws_qty = 0
                Else
                    ws_qty = CDbl(newDR.Item("ws_qty").ToString)
                End If

                If newDR.Item("ws_id").ToString <> "" Then

                    If nn = 1 Then
                        get_total_qty_requested_and_withdrawn += ws_qty
                    ElseIf nn = 2
                        get_total_qty_requested_and_withdrawn += 1
                    End If

                End If
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
            GC.Collect()

        End Try
    End Function
    Public Function get_pending_withdrawn(ByVal wh_id As Integer) As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim myQUERY As String
        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_get_data_from_warehouse", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 8)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read

                Dim rs_id As Integer = CInt(newDR.Item("rs_id").ToString)

                If check_if_exist("dbwithdrawn_items", "rs_id", rs_id, 0) > 0 Then
                    myQUERY = "SELECT qty FROM dbrequisition_slip WHERE rs_id = " & rs_id
                    Dim qty As Integer = get_specific_column_value(myQUERY, 1)

                    get_pending_withdrawn += qty - get_total_qty_from_requestor(rs_id, 0)
                Else
                    get_pending_withdrawn += newDR.Item("qty").ToString
                End If

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function

    Public Function get_total_qty_from_requestor(ByVal rs_id As Integer, ByVal n As Integer) As Integer
        Dim sqlcon As New SQLcon
        Dim sqlreader As SqlDataReader
        Dim sqlcmd As SqlCommand
        Dim r As Integer = 1
        Dim nn As Integer = 1
        Try
            sqlcon.connection.Open()
            Dim query As String = "SELECT a.rs_id, a.qty AS req_qty, b.qty FROM  dbrequisition_slip a "
            query &= "INNER JOIN dbPO_details b ON a.rs_id = b.rs_id "
            query &= "INNER JOIN dbwithdrawn_items c ON c.ws_id = b.po_det_id "
            query &= "WHERE a.rs_id = " & rs_id
            sqlcmd = New SqlCommand(query, sqlcon.connection)
            sqlreader = sqlcmd.ExecuteReader
            While sqlreader.Read
                If n = 0 Then
                    get_total_qty_from_requestor += CInt(sqlreader.Item("qty").ToString)
                ElseIf n = 1 Then

                End If
            End While
            sqlreader.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try
    End Function

    Public Function get_received_dr_items(ByVal wh_id As Integer) As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_get_data_from_warehouse", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 5)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                If newDR.Item("IN_OUT").ToString = "IN" Then
                    If newDR.Item("type_of_purchasing").ToString = "DR" Then
                        get_received_dr_items = get_total_qty_received_and_qty_DR(wh_id, 7)
                    Else
                        get_received_dr_items = get_total_qty_received_and_qty_DR(wh_id, 6)
                    End If

                End If

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Function get_total_qty_received_and_qty_DR(wh_id As Integer, n As Integer) As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_get_data_from_warehouse", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read

                get_total_qty_received_and_qty_DR += CDbl(newDR.Item("desired_qty").ToString)

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function


    Public Function count_request_not_withdrawn(ByVal n As String, ByVal x As String) As Integer
        Dim newSQ As New SQLcon
        Dim newcmd As SqlCommand
        Dim newdr As SqlDataReader
        Dim myQUERY1 As String
        Dim q As Integer = 1
        Try
            newSQ.connection.Open()

            Dim query As String = "SELECT * FROM dbrequisition_slip where wh_id = '" & n & "'  AND type_of_purchasing = '" & x & "'"
            newcmd = New SqlCommand(query, newSQ.connection)
            newdr = newcmd.ExecuteReader

            While newdr.Read

                If check_if_exist("dbwithdrawn_items", "rs_id", CInt(newdr.Item("rs_id").ToString), 0) > 0 Then
                    myQUERY1 = "SELECT qty FROM dbrequisition_slip WHERE rs_id = " & CInt(newdr.Item("rs_id").ToString)
                    Dim qty As Integer = get_specific_column_value(myQUERY1, 1)
                    Dim nn As Integer = qty - get_total_qty_from_requestor(CInt(newdr.Item("rs_id").ToString), 0)

                    If nn = 0 Then
                        q -= 1

                        count_request_not_withdrawn = q
                    Else
                    End If

                Else

                    count_request_not_withdrawn = q

                End If

                q += 1

            End While

            newdr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Public Function check_if_not_withdrawn(ByVal n As String, ByVal x As String) As Integer
        Dim newSQ As New SQLcon
        Dim newcmd As SqlCommand
        Dim newdr As SqlDataReader
        Try
            newSQ.connection.Open()

            Dim query As String = "SELECT * FROM dbrequisition_slip where wh_id = '" & n & "'  AND type_of_purchasing = '" & x & "'"
            newcmd = New SqlCommand(query, newSQ.connection)
            newdr = newcmd.ExecuteReader

            While newdr.Read
                If check_if_exist_in_withdrawal(newdr.Item(rs_id).ToString) > 0 Then

                Else
                    check_if_not_withdrawn += newdr.Item("qty").ToString
                End If

            End While

            newdr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Function check_if_exist_in_withdrawal(ByVal y As String) As Integer
        Dim newSQ1 As New SQLcon
        Dim newcmd1 As SqlCommand
        Dim newdr1 As SqlDataReader
        Try
            newSQ1.connection.Open()
            Dim query As String = "SELECT * FROM dbwithdrawal_items WHERE [rs_id] = '" & y & "'"
            newcmd1 = New SqlCommand(query, newSQ1.connection)
            newdr1 = newcmd1.ExecuteReader

            While newdr1.Read
                check_if_exist_in_withdrawal += 1
            End While
            newdr1.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ1.connection.Close()
        End Try
    End Function
    'Public Function get_total_Qty(ByVal n As String)

    '    Dim newSQ1 As New SQLcon
    '    Dim newdr1 As SqlDataReader
    '    Try
    '        newSQ1.connection.Open()
    '        Dim sqlComm As New SqlCommand()

    '        sqlComm.Connection = newSQ1.connection
    '        sqlComm.CommandText = "for_total_qty_of_pending_withdrawal"
    '        sqlComm.CommandType = CommandType.StoredProcedure


    '        newdr1 = sqlComm.ExecuteReader

    '        If newdr1.HasRows Then
    '            ' MessageBox.Show("Data already exist...", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Else

    '            Dim newSQ As New SQLcon
    '            Dim newcmd As SqlCommand
    '            Dim newdr As SqlDataReader

    '            newSQ.connection.Open()

    '            Dim query As String = "SELECT SUM(qty) FROM dbrequisition_slip WHERE wh_id = '" & n & "'"
    '            newcmd = New SqlCommand(query, newSQ.connection)
    '            newdr = newcmd.ExecuteReader

    '            While newdr.Read
    '                get_total_Qty = newdr.Item(0).ToString
    '            End While
    '            newdr.Close()
    '        End If
    '        newdr1.Close()
    '    Catch ex As Exception
    '        MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        newSQ1.connection.Close()
    '    End Try

    'End Function
    Public Function get_total_request(ByVal n As String)
        Dim newSQ As New SQLcon
        Dim newcmd As SqlCommand
        Dim newdr As SqlDataReader
        Try
            newSQ.connection.Open()

            Dim query As String = "SELECT COUNT(wh_id) FROM dbrequisition_slip WHERE wh_id = '" & n & "'"
            newcmd = New SqlCommand(query, newSQ.connection)
            newdr = newcmd.ExecuteReader

            While newdr.Read
                get_total_request = newdr.Item(0).ToString
            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Function get_qty_from_dbPrevious_stock_card(ByVal wh_id As Integer) As Double

        Dim newSQ As New SQLcon
        Dim newcmd As SqlCommand
        Dim newdr As SqlDataReader
        Try
            newSQ.connection.Open()

            Dim query As String = "SELECT * FROM dbPrevious_stock_card WHERE wh_id = " & wh_id & " ORDER BY date_previous ASC"
            newcmd = New SqlCommand(query, newSQ.connection)
            newdr = newcmd.ExecuteReader
            While newdr.Read

                get_qty_from_dbPrevious_stock_card = Val(newdr.Item("balance").ToString)

            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Public Function update_item_price(ByVal wh_id As Integer) As Double

        Dim newSQ As New SQLcon
        Dim newcmd As SqlCommand
        Dim newdr As SqlDataReader
        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT DISTINCT a.wh_id,b.unit_price,c.date_received FROM dbreceiving_items a " &
                                     "INNER JOIN dbPurchase_order_items b ON b.wh_id = a.wh_id " &
                                     "INNER JOIN dbreceiving_info c ON c.rr_info_id = a.rr_info_id WHERE a.wh_id = " & wh_id &
                                     " ORDER BY c.date_received ASC"
            newcmd = New SqlCommand(query, newSQ.connection)
            newdr = newcmd.ExecuteReader

            While newdr.Read
                update_item_price = newdr.Item("unit_price").ToString
            End While
            newdr.Close()

        Catch ex As Exception
            If ex.Message = "Thread was being aborted." Then
                Exit Function
                ' MessageBox.Show("Thread was being aborted...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Public Function total_receiving_item(ByVal id As Integer) As Integer
        Dim newSQ As New SQLcon
        Dim newcmd As SqlCommand
        Dim newdr As SqlDataReader

        '  lvlWarehouseItem.Items.Clear()
        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT d.desired_qty FROM dbreceiving_items a "
            query &= "INNER JOIN dbPO_details b "
            query &= "ON a.po_det_id = b.po_det_id "
            query &= "INNER JOIN dbrequisition_slip c "
            query &= "ON c.rs_id = b.rs_id "
            query &= "INNER JOIN dbreceiving_item_partially d "
            query &= "ON d.rr_item_id = a.rr_item_id "
            query &= "WHERE b.wh_id = '" & id & "' AND c.IN_OUT = '" & "IN" & "'"

            newcmd = New SqlCommand(query, newSQ.connection)
            newdr = newcmd.ExecuteReader
            While newdr.Read
                total_receiving_item += newdr.Item("desired_qty").ToString
            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function

    Public Function total_withdrawn_item(ByVal id As Integer) As Integer
        Dim newSQ As New SQLcon
        Dim newcmd As SqlCommand
        Dim newdr As SqlDataReader

        Try
            newSQ.connection.Open()

            newcmd = New SqlCommand("proc_withdrawal_new", newSQ.connection)
            newcmd.Parameters.Clear()
            newcmd.CommandType = CommandType.StoredProcedure
            'newCMD.Parameters.AddWithValue("@n", 8)
            'newCMD.Parameters.AddWithValue("@turnover_item_id", id)
            'newCMD.Parameters.AddWithValue("@remarks", 1)
            newcmd.Parameters.AddWithValue("@n", 7)
            newcmd.Parameters.AddWithValue("@wh_id", id)

            newdr = newcmd.ExecuteReader
            While newdr.Read

                total_withdrawn_item += CInt(newdr.Item("qty").ToString)

            End While
            newdr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function

    Public Sub viewMaterialToolsTurnOverList()
        lvlWarehouseItem.Items.Clear()
        Dim i As Integer = 0
        Try
            SQ.connection.Open()
            Dim newdr As SqlDataReader
            publicquery = "SELECT * FROM dbMaterialTools_TurnOver"
            Dim cmd As SqlCommand = New SqlCommand(publicquery, SQ.connection)
            newdr = cmd.ExecuteReader
            While newdr.Read
                Dim a(15) As String

                a(0) = newdr.Item("type_of_material_id").ToString
                a(1) = get_name_of_ItemName(newdr.Item("type_of_material_id").ToString, newdr.Item("bases").ToString)
                a(2) = get_name_of_id(newdr.Item("type_of_material_id").ToString, newdr.Item("bases").ToString)
                a(3) = newdr.Item("whArea").ToString
                a(5) = newdr.Item("specLocation").ToString
                a(6) = 1
                a(7) = FormatNumber(0, TriState.True)
                a(8) = newdr.Item("unit").ToString

                Dim balance As Double

                balance = get_qty_from_materialsTurnOver(newdr.Item("type_of_material_id").ToString)
                a(4) = balance - total_withdrawn_item(newdr.Item("type_of_material_id").ToString)

                If cmbSearchby.Text = "Search By Turnover Tools/Materials" Then

                End If

                Dim lvlList As New ListViewItem(a)
                lvlWarehouseItem.Items.Add(lvlList)


                If CDbl(lvlWarehouseItem.Items(i).SubItems(4).Text) < CDbl(lvlWarehouseItem.Items(i).SubItems(6).Text) Then
                    lvlWarehouseItem.Items(i).BackColor = Color.Red
                    lvlWarehouseItem.Items(i).ForeColor = Color.White
                ElseIf CDbl(lvlWarehouseItem.Items(i).SubItems(4).Text) = CDbl(lvlWarehouseItem.Items(i).SubItems(6).Text) Then
                    lvlWarehouseItem.Items(i).BackColor = Color.Black
                    lvlWarehouseItem.Items(i).ForeColor = Color.White
                Else
                    'lvlWarehouseItem.Items(i).BackColor = Color.Red
                    'lvlWarehouseItem.Items(i).ForeColor = Color.White
                End If

                i += 1

            End While
            newdr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Public Function get_qty_from_materialsTurnOver(ByVal wh_id As Integer) As Integer

        Dim newSQL As New SQLcon
        Dim newcmd As SqlCommand
        Dim newsqdr As SqlDataReader
        Try
            newSQL.connection.Open()

            Dim query As String = "SELECT * FROM dbMaterialTools_TurnOver WHERE type_of_material_id = " & wh_id & ""
            newcmd = New SqlCommand(query, newSQL.connection)
            newsqdr = newcmd.ExecuteReader
            While newsqdr.Read

                get_qty_from_materialsTurnOver = Val(newsqdr.Item("qty").ToString)

            End While
            newsqdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQL.connection.Close()
        End Try
    End Function

    Public Function get_name_of_id(ByVal x As Integer, ByVal y As Integer)
        Dim newsq As New SQLcon
        Try

            Dim newdr1 As SqlDataReader
            newsq.connection.Open()
            If y = 2 Then
                query = "SELECT * FROM dbwarehouse_items WHERE wh_id = " & x
            ElseIf y = 1 Then
                query = "SELECT * FROM warehouse_items_new WHERE id = " & x
            End If

            Dim cmd As SqlCommand = New SqlCommand(query, newsq.connection)
            newdr1 = cmd.ExecuteReader

            While newdr1.Read
                If y = 2 Then
                    get_name_of_id = newdr1.Item("whItemDesc").ToString
                ElseIf y = 1 Then
                    get_name_of_id = newdr1.Item("Whitem_Desc").ToString
                End If
            End While
            newdr1.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsq.connection.Close()
        End Try
    End Function
    Public Function get_name_of_ItemName(ByVal x As Integer, ByVal y As Integer)
        Dim newsq As New SQLcon
        Try

            Dim newdr1 As SqlDataReader
            newsq.connection.Open()
            If y = 2 Then
                query = "SELECT * FROM dbwarehouse_items WHERE wh_id = " & x
            ElseIf y = 1 Then
                query = "SELECT * FROM warehouse_items_new WHERE id = " & x
            End If

            Dim cmd As SqlCommand = New SqlCommand(query, newsq.connection)
            newdr1 = cmd.ExecuteReader

            While newdr1.Read
                If y = 2 Then
                    get_name_of_ItemName = newdr1.Item("whItem").ToString
                ElseIf y = 1 Then
                    get_name_of_ItemName = newdr1.Item("WHitem").ToString
                End If
            End While
            newdr1.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsq.connection.Close()
        End Try
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub lvlWarehouseItem_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvlWarehouseItem.DoubleClick
        'If thread_1.IsAlive = True Then
        '    MessageBox.Show("unable to procceed transactions, wait for the thread to finish..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Exit Sub
        'End If


        Dim balance As Double
        Dim total_request As Double
        Dim total_qty_from_requestor As Double
        Dim link_qty As Double

        If button_click_name = "ItemsToolStripMenuItem" Then
            Exit Sub

        ElseIf button_click_name = "searchbystockcard" Then

            Dim item_name As String = lvlWarehouseItem.SelectedItems(0).SubItems(1).Text
            Dim item_desc As String = lvlWarehouseItem.SelectedItems(0).SubItems(2).Text
            Dim wharea As String = lvlWarehouseItem.SelectedItems(0).SubItems(3).Text
            Dim incharge As String = lvlWarehouseItem.SelectedItems(0).SubItems(15).Text

            Dim items As String = $"{item_name} - {item_desc} ({wharea}) {incharge}"
            StockCard1.lblitem_name.Text = items
            StockCard1.cWh_id = lvlWarehouseItem.SelectedItems(0).Text
            StockCard1.Panel7.Visible = True

            StockCard1.new_stockcard_search()

            Me.Close()
            Exit Sub

        ElseIf button_click_name = "forstockcard" Then
            'FDATERANGE.ShowDialog()
            'fd.ShowDialog()

        ElseIf button_click_name = "btnSelectItem" Then
            FRequistionForm.charges_wh_id = CInt(lvlWarehouseItem.SelectedItems(0).Text)

            If FRequistionForm.cmbSearchByCategory.Text = "Search by item (Item Checked only)" Then

                FRequistionForm.cmbpages.Items.Clear()
                FRequistionForm.pages(FRequistionForm.cmbDivision.Text)

                'FRequistionForm.load_rs_3(17)

            ElseIf FRequistionForm.cmbSearchByCategory.Text = "Search by Charges (Specific Item)" Then
                Panel2.Show()
            Else
                FRequistionForm.load_rs_3(16)
            End If

            Exit Sub
            Me.Close()

        ElseIf button_click_name = "ChangeItemNamedescriptionToolStripMenuItem" Then
            With FRequistionForm

                Dim rs_id As Integer = .lvlrequisitionlist.SelectedItems(0).Text
                Dim wh_id As Integer = lvlWarehouseItem.SelectedItems(0).Text
                Dim rs_no As String = .lvlrequisitionlist.SelectedItems(0).SubItems(1).Text

                If MessageBox.Show("Are you sure you want to update the selected rs data to this item description?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    Dim query As String = "update dbrequisition_slip set wh_id = " & wh_id & " WHERE rs_id = " & rs_id
                    UPDATE_INSERT_DELETE_QUERY(query, 0, "UPDATE")

                    .cmbSearchByCategory.Text = "Search by RS.No."
                    .txtSearch.Text = rs_no
                    .load_rs_3(13)
                    listfocus(.lvlrequisitionlist, rs_id)

                    Me.Close()
                    Exit Sub
                End If

            End With

        ElseIf button_click_name = "UpdateSourceFromRS" Then
            If MessageBox.Show("Are you sure you want to update selected data from rs?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Dim counter As Integer = 0

                For Each row As ListViewItem In FRequistionForm.lvlrequisitionlist.Items
                    If row.Selected = True Then
                        Dim newSQ As New SQLcon
                        Dim newCMD As SqlCommand

                        Try
                            newSQ.connection.Open()
                            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
                            newCMD.Parameters.Clear()
                            newCMD.CommandType = CommandType.StoredProcedure

                            newCMD.Parameters.AddWithValue("@n", 45)
                            newCMD.Parameters.AddWithValue("@wh_id", lvlWarehouseItem.SelectedItems(0).Text)
                            newCMD.Parameters.AddWithValue("@rs_id", row.Text)
                            newCMD.ExecuteNonQuery()

                        Catch ex As Exception
                            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            newSQ.connection.Close()
                        End Try
                        counter += 1
                    End If
                Next

                If counter > 0 Then
                    MessageBox.Show("Successfully Updated..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'btnSearch.PerformClick()
                Else
                    MessageBox.Show("I think there's something wrong with the update..", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                End If
                FRequistionForm.load_rs_3(13)
                Exit Sub
                Me.Close()


            End If

        ElseIf button_click_name = "EndorseItemCheckingToolStripMenuItem" Then
            If MessageBox.Show("Are you sure you want to endorse the request to this item?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                'insert into dbEndorse_items
                Dim item_desc As String = lvlWarehouseItem.SelectedItems(0).SubItems(2).Text
                Dim rs_id As Integer = FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text

                insert_into_dbEndorse_items(item_desc, rs_id)
                Me.Close()
            End If

            Exit Sub

        ElseIf button_click_name = "WHtoWH" Then

#Region "EDIT REQUESTOR WH TO WH"
            Dim wh_id As Integer = lvlWarehouseItem.SelectedItems(0).Text
            Dim stockpile As String = lvlWarehouseItem.SelectedItems(0).SubItems(3).Text
            Dim item As String = $"{lvlWarehouseItem.SelectedItems(0).SubItems(1).Text} - {lvlWarehouseItem.SelectedItems(0).SubItems(2).Text}"

            'With FDRLIST1.whTOwh.dgvData

            '    .Rows(1).Cells("wh_id").Value = wh_id
            '    .Rows(1).Cells("requestor").Value = stockpile
            '    .Rows(1).Cells("item_name").Value = item

            'End With

            With FWHtoWH.dgvData

                .Rows(1).Cells("wh_id").Value = wh_id
                .Rows(1).Cells("requestor").Value = stockpile
                .Rows(1).Cells("item_name").Value = item

            End With

            Me.Close()
#End Region

            Exit Sub

        ElseIf button_click_name = "edit requestor from drlist1 - OTHERS WITHOUT RS" Then

#Region "EDIT REQUESTOR FROM DRLIST1 - OTHERS WITHOUT RS"
            Try
                Dim updateWhId_FromRs As New Model_King_Dynamic_Update
                Dim wh_id As Integer = lvlWarehouseItem.SelectedItems(0).Text

                Dim columnValues As New Dictionary(Of String, Object)()
                columnValues.Add("wh_id", wh_id)

                updateWhId_FromRs.UpdateData("dbrequisition_slip", columnValues, $"rs_id = {cImportantIds.rs_id }")

                For Each row As ListViewItem In FDRLIST1.lvl_drList.Items
                    If row.Selected = True Then

                        row.SubItems(35).Text = wh_id
                        row.SubItems(4).Text = lvlWarehouseItem.SelectedItems(0).SubItems(1).Text
                        row.SubItems(29).Text = lvlWarehouseItem.SelectedItems(0).SubItems(2).Text
                        row.SubItems(10).Text = lvlWarehouseItem.SelectedItems(0).SubItems(3).Text

                    End If
                Next
                Me.Close()

            Catch ex As Exception
                'MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                customMsg.ErrorMessage(ex)
            End Try
#End Region

            Exit Sub

        ElseIf button_click_name = "edit requestor from drlist2 - OTHERS WITHOUT RS" Then

#Region "EDIT REQUESTOR FROM DRLIST2 - OTHERS WITHOUT RS"
            Try
                Dim updateWhId_FromRs As New Model_King_Dynamic_Update
                Dim wh_id As Integer = lvlWarehouseItem.SelectedItems(0).Text

                Dim columnValues As New Dictionary(Of String, Object)()
                columnValues.Add("wh_id", wh_id)

                updateWhId_FromRs.UpdateData("dbrequisition_slip", columnValues, $"rs_id = {cImportantIds.rs_id }")

                For Each row As ListViewItem In FDRLIST2.lvl_drList.Items
                    If row.Selected = True Then

                        row.SubItems(35).Text = wh_id
                        row.SubItems(4).Text = lvlWarehouseItem.SelectedItems(0).SubItems(1).Text
                        row.SubItems(29).Text = lvlWarehouseItem.SelectedItems(0).SubItems(2).Text
                        row.SubItems(10).Text = lvlWarehouseItem.SelectedItems(0).SubItems(3).Text

                    End If
                Next
                Me.Close()

            Catch ex As Exception
                'MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                customMsg.ErrorMessage(ex)
            End Try
#End Region

            Exit Sub

        ElseIf button_click_name = "STOCKPILE TO STOCKPILE" Then
            'FCreateDeliveryReceipt.lblItemIn.Text = $"{lvlWarehouseItem.SelectedItems(0).SubItems(2).Text }"
            Me.Dispose()
            Exit Sub
        End If

        wh_id = lvlWarehouseItem.SelectedItems(0).Text
        pub_wh_id = lvlWarehouseItem.SelectedItems(0).Text

        Dim qty_from_prev_stock_card As Double = get_qty_from_dbPrevious_stock_card(wh_id)

        'link_qty = CDbl(lvlWarehouseItem.SelectedItems(0).SubItems(14).Text)
        'balance = FormatNumber(get_wh_item_balance2(wh_id) + qty_from_prev_stock_card + CDbl(link_qty), , TriState.True) 'get_wh_item_balance(dr.Item("wh_id").ToString)


        If cmboptions.Text = "WAREHOUSING" Then
            balance = get_beginning_balance1(wh_id)
        ElseIf cmboptions.Text = "HAULING AND CRUSHING" Then
            balance = FormatNumber(get_wh_item_balance2(wh_id) + qty_from_prev_stock_card + CDbl(link_qty), , TriState.True) 'get_wh_item_balance(dr.Item("wh_id").ToString)
        End If


        total_request = get_total_qty_requested_and_not_withdrawn_yet(wh_id, 1) '1 - total requested
        total_qty_from_requestor = FormatNumber(get_total_qty_requested_and_not_withdrawn_yet(wh_id, 2),, TriState.True) '2 -total qty from requestor

        If balance > CDbl(lvlWarehouseItem.SelectedItems(0).SubItems(8).Text) And lblInOut.Text = "OUT" Then
            MessageBox.Show("Unable to select this item, check the reorder point..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        Else
            If wh_item_destination = 1 Then

                If FRequestField.cmbInOut.Text = "OTHERS" Then 'if others ang inout combobox
                    With FRequestField

                        .txtItemDesc.Text = lvlWarehouseItem.SelectedItems(0).SubItems(2).Text
                        .txtUnit.Text = lvlWarehouseItem.SelectedItems(0).SubItems(8).Text
                        .txtQty.Text = 0

                    End With

                    Me.Dispose()

                Else 'if in/out ang inout na combobox
                    'For Each ctr As Control In pnlItemDesc.Controls
                    '    If ctr.Name = "pnlQty" Then
                    '        ctr.Visible = True
                    '    Else
                    '        ctr.Enabled = False
                    '    End If
                    'Next

                    'txtBalance.Text = lvlWarehouseItem.SelectedItems(0).SubItems(4).Text
                    'txtQty.Focus()

                    For Each ctr As Control In pnlItemDesc.Controls
                        If ctr.Name = "pnl_newqty" Then
                            ctr.Visible = True
                        Else
                            ctr.Enabled = False
                        End If
                    Next

                    'txt_balanceNew.Text = CDbl(lvlWarehouseItem.SelectedItems(0).SubItems(4).Text) - CDbl(lvlWarehouseItem.SelectedItems(0).SubItems(6).Text)
                    'txt_reorderPoint.Text = lvlWarehouseItem.SelectedItems(0).SubItems(8).Text
                    'txtrequestqty.Text = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(5).Text

                    txt_balanceNew.Text = balance - total_qty_from_requestor
                    txt_reorderPoint.Text = lvlWarehouseItem.SelectedItems(0).SubItems(8).Text
                    txtrequestqty.Text = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(5).Text
                End If

                'With FRequestField
                '    .txtItemDesc.Text = lvlWarehouseItem.SelectedItems(0).SubItems(2).Text
                '    .txtUnit.Text = lvlWarehouseItem.SelectedItems(0).SubItems(8).Text
                'End With

            ElseIf wh_item_destination = 2 Then
                FPreviousStackCardFinal.txtItemDesc.Text = lvlWarehouseItem.SelectedItems(0).SubItems(2).Text
                FPreviousStackCardFinal.txt_item_name.Text = lvlWarehouseItem.SelectedItems(0).SubItems(1).Text
                Me.Close()
            End If

        End If

        FRequestField.lblFromWh_or_FromTO.Text = lblFromWh_or_FromTO.Text
        'lboxUnit.Visible = False

    End Sub
    Private Function insert_into_dbEndorse_items(item_desc As String, rs_id As Integer) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_QTO_maintenance", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 12)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.Parameters.AddWithValue("@user_id", pub_user_id)
            newCMD.Parameters.AddWithValue("@item_desc", item_desc)

            insert_into_dbEndorse_items = newCMD.ExecuteScalar

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Private Sub btnQtyClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQtyClose.Click
        close_panel_qty()
    End Sub

    Private Sub btnQtyOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQtyOk.Click
        If lblInOut.Text = "IN" Or lblInOut.Text = "QUARRY-IN" Then
            'If CInt(txtBalance.Text) >= CInt(txtQty.Text) Then
            With FRequestField
                .txtItemDesc.Text = lvlWarehouseItem.SelectedItems(0).SubItems(2).Text
                .txtUnit.Text = lvlWarehouseItem.SelectedItems(0).SubItems(8).Text
                .txtQty.Text = txtQty.Text
                .txtUnit.Text = lvlWarehouseItem.SelectedItems(0).SubItems(8).Text
            End With
            close_panel_qty()
            Me.Close()


            'MessageBox.Show("Check the balance if greater than quantity...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' End If
        ElseIf lblInOut.Text = "OUT" Then
            If CInt(txtBalance.Text) >= CInt(txtQty.Text) And CInt(txtBalance.Text) >= CInt(lvlWarehouseItem.SelectedItems(0).SubItems(6).Text) + CInt(txtQty.Text) Then

                If cmbSearchby.Text = "Search By Item Name" And cmbSearchby.Text = "Search By Item Desc." Then

                    If CInt(lvlWarehouseItem.SelectedItems(0).SubItems(8).Text) >= CInt(txtBalance.Text) - CInt(txtQty.Text) Then
                        MessageBox.Show("Warning: " & vbCrLf & "Reorder point was already achieved..", "Supply Info:", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    End If
                Else
                End If

                With FRequestField
                    .txtItemDesc.Text = lvlWarehouseItem.SelectedItems(0).SubItems(2).Text
                    .txtUnit.Text = lvlWarehouseItem.SelectedItems(0).SubItems(10).Text
                    .txtQty.Text = txtQty.Text
                    '.txtUnit.Text = lvlWarehouseItem.SelectedItems(0).SubItems(8).Text
                End With

                close_panel_qty()
                Me.Close()


                '  MsgBox(Val(lvlWarehouseItem.SelectedItems(0).SubItems(12).Text) + CInt(txtQty.Text))
            ElseIf CInt(txtBalance.Text) < CInt(lvlWarehouseItem.SelectedItems(0).SubItems(6).Text) + CInt(txtQty.Text) Then
                MessageBox.Show("The quantity that you requested is out of bound...", "SUPPLY INFO:", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
            ElseIf CInt(txtBalance.Text) <= CInt(txtQty.Text)
                MessageBox.Show("Check the balance if greater than quantity...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtQty.Focus()
            End If
        End If


    End Sub

    Public Sub close_panel_qty()
        For Each ctr As Control In pnlItemDesc.Controls
            If ctr.Name = "pnlQty" Then
                ctr.Visible = False
            Else
                ctr.Enabled = True
            End If
        Next
    End Sub

    Public Sub close_newpanel()
        For Each ctr As Control In pnlItemDesc.Controls
            If ctr.Name = "pnl_newqty" Then
                ctr.Visible = False
            Else
                ctr.Enabled = True
            End If
        Next
    End Sub

    Private Sub txtQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQty.KeyDown
        If Not (e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 48 Or e.KeyValue = 49 Or e.KeyValue = 50 Or e.KeyValue = 51 Or e.KeyValue = 52 Or e.KeyValue = 53 Or e.KeyValue = 54 Or
           e.KeyValue = 55 Or e.KeyValue = 56 Or e.KeyValue = 57 Or e.KeyValue = 96 Or e.KeyValue = 97 Or e.KeyValue = 98 Or e.KeyValue = 99 Or
           e.KeyCode = Keys.OemPeriod Or
          e.KeyValue = 100 Or e.KeyValue = 101 Or e.KeyValue = 102 Or e.KeyValue = 103 Or e.KeyValue = 104 Or e.KeyValue = 105 Or e.KeyValue = 37 Or e.KeyValue = 39) Then

            e.SuppressKeyPress() = True
        End If

        If e.KeyCode = Keys.Enter Then
            btnQtyOk.PerformClick()

        End If

    End Sub

    Private Sub cmbSearchby_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSearchby.SelectedIndexChanged

        Try

            If cOptions IsNot Nothing Then
                Dim RawData = Utilities.getFinalData().Where(Function(x) x.division.ToUpper() = cOptions.ToUpper()).ToList()
                Dim l As New AutoCompleteStringCollection

                If cmbSearchby.Text = cSearchBy.SEARCH_BY_ITEM_DESC Then
                    For Each row In RawData
                        l.Add(row.item_desc)
                    Next

                    autoComplete(l, txtSearch)

                    cSearch = ""
                    txtSearch.Visible = True
                    txtItemDesc.Visible = False
                    txtWarehouseArea.Visible = False
                    txtSearch.Focus()
                    txtSearch.SelectAll()

                ElseIf cmbSearchby.Text = cSearchBy.SEARCH_BY_ITEM_NAME Then
                    For Each row In RawData
                        l.Add(row.item_name)
                    Next

                    autoComplete(l, txtSearch)

                    cSearch = ""
                    txtSearch.Visible = True
                    txtItemDesc.Visible = False
                    txtWarehouseArea.Visible = False
                    txtSearch.Focus()
                    txtSearch.SelectAll()

                ElseIf cmbSearchby.Text = cSearchBy.SEARCH_BY_WAREHOUSE_AREA Then
                    For Each row In RawData
                        l.Add(row.warehouse_area)
                    Next

                    autoComplete(l, txtWarehouseArea)

                    cSearch = ""
                    txtItemDesc.Visible = False
                    txtSearch.Visible = False
                    txtWarehouseArea.Visible = True
                    txtWarehouseArea.Focus()
                    txtWarehouseArea.SelectAll()

                ElseIf cmbSearchby.Text = cSearchBy.SEARCH_BY_PROPER_NAMING Then
                    For Each row In cListOfProperNaming
                        l.Add(row.item_desc)
                    Next

                    autoComplete(l, txtSearch)

                    cSearch = ""
                    txtSearch.Visible = True
                    txtItemDesc.Visible = False
                    txtWarehouseArea.Visible = False
                    txtSearch.Focus()
                    txtSearch.SelectAll()
                End If

            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

        Exit Sub

        'Dim search_option As String = ""
        'If cmboptions.Text = "WAREHOUSING" Then
        '    search_option = "WAREHOUSING AND SUPPLY"
        'ElseIf cmboptions.Text = "HAULING AND CRUSHING" Then
        '    search_option = "CRUSHING AND HAULING"
        'End If


        'If cmbSearchby.Text = "Search By Turnover Tools/Materials" Then
        '    'FRequestField.lblFromWh_or_FromTO.Text = 2
        '    from_old_item_or_new_item = 2

        'ElseIf cmbSearchby.Text = "Search By All" Then

        '    txtSearch.Visible = True
        '    txtItemDesc.Visible = True
        '    txtWarehouseArea.Visible = True

        '    txtItemDesc.Text = "Item Description..."
        '    txtSearch.Text = "Item Name..."
        '    txtWarehouseArea.Text = "Warehouse Area..."


        '    list_item_desc.Clear()
        '    list_item_name.Clear()

        '    load_items(1, list_item_name, search_option)
        '    load_items(2, list_item_desc, search_option)

        '    'Dim placeholder As New Class_PlaceHolder_Warehouse

        '    'placeholder.load_what_you_search(txtSearch, list_item_name)
        '    'placeholder.load_what_you_search(txtItemDesc, list_item_desc)

        '    txtSearch.Focus()

        'ElseIf cmbSearchby.Text = cSearchBy.SEARCH_BY_ITEM_DESC Then  '"Search By Item Desc" Then
        '    'FRequestField.lblFromWh_or_FromTO.Text = 1
        '    from_old_item_or_new_item = 1
        '    txtItemDesc.Visible = True
        '    txtSearch.Visible = False
        '    txtWarehouseArea.Visible = False

        '    txtItemDesc.Text = "Item Description..."
        '    txtSearch.Text = "Item Name..."
        '    txtWarehouseArea.Text = "Warehouse Area..."

        '    list_item_desc.Clear()

        '    load_items(2, list_item_desc, search_option)

        '    txtItemDesc.Focus()

        'ElseIf cmbSearchby.Text = cSearchBy.SEARCH_BY_ITEM_NAME Then '"Search By Item Name" Then
        '    'FRequestField.lblFromWh_or_FromTO.Text = 1
        '    from_old_item_or_new_item = 1
        '    txtItemDesc.Visible = False
        '    txtSearch.Visible = True
        '    txtWarehouseArea.Visible = False

        '    txtItemDesc.Text = "Item Description..."
        '    txtSearch.Text = "Item Name..."
        '    txtWarehouseArea.Text = "Warehouse Area..."

        '    list_item_name.Clear()

        '    load_items(1, list_item_name, search_option)

        '    Dim placeholder As New Class_PlaceHolder_Warehouse
        '    placeholder.load_what_you_search(txtSearch, list_item_name)

        '    txtSearch.Focus()


        'ElseIf cmbSearchby.Text = cSearchBy.SEARCH_BY_WAREHOUSE_AREA Then ' "Search By Warehouse Area" Then
        '    'FRequestField.lblFromWh_or_FromTO.Text = 1
        '    from_old_item_or_new_item = 1
        '    txtItemDesc.Visible = False
        '    txtSearch.Visible = False
        '    txtWarehouseArea.Visible = True

        '    txtItemDesc.Text = "Item Description..."
        '    txtSearch.Text = "Item Name..."
        '    txtWarehouseArea.Text = "Warehouse Area..."

        '    list_warehouse_area.Clear()

        '    load_items(3, list_warehouse_area, "")

        '    Dim placeholder As New Class_PlaceHolder_Warehouse
        '    placeholder.load_what_you_search(txtWarehouseArea, list_warehouse_area)

        '    txtWarehouseArea.Focus()

        'End If

    End Sub

    Private Sub autoComplete(l As AutoCompleteStringCollection, Optional tBox As TextBox = Nothing)

        tBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        tBox.AutoCompleteSource = AutoCompleteSource.CustomSource
        tBox.AutoCompleteCustomSource = l

    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        lvlWarehouseItem.CheckBoxes = True
        'If cmbSearchby.Text = "Search By Item Name" Then

        '    'Dim mthread As New Threading.Thread(AddressOf loading)
        '    'thread_1 = New Threading.Thread(AddressOf loading)

        '    Me.CheckForIllegalCrossThreadCalls = False
        '    thread_1 = New Threading.Thread(AddressOf item_searching)
        '    thread_1.Start()
        '    btnAbort.Visible = True

        '    'thread_1.Abort()

        'ElseIf cmbSearchby.Text = "Search By Item Desc" Then
        '    search_item_from_warehouse(txtSearch.Text, 4)
        'ElseIf cmbSearchby.Text = "Search By Turnover Tools/Materials" Then
        '    'viewMaterialToolsTurnOverList()
        '    view_materials_turnover()
        'ElseIf cmbSearchby.Text = "Search By Warehouse Area" Then


        'End If
        'lvlWarehouseItem.Enabled = False
        cmbSearchby.Enabled = False
        txtSearch.Enabled = False
        btnSearch.Enabled = False

        Dim themsg As String = "Hi " & fname & " " & lname & "," & vbCrLf & " Click Yes - lang og gusto nimo ma display og apil ang balance, pero medyo lag." & vbCrLf & vbCrLf &
            "Click No - lang kung gusto nimo dili ma display og apil ang balance. medyo pas-pas (sama sa gugma nga paspas ra mawala :))"

        If MessageBox.Show(themsg, "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            popupmsg = 1
        Else
            popupmsg = 2
        End If

        't2 = New Thread(AddressOf item_searching)
        't2.Start()



        'Me.CheckForIllegalCrossThreadCalls = False
        'thread_1 = New Threading.Thread(AddressOf item_searching)
        'thread_1.Start()



        Dim STthread_Data As search_wh_data
        STthread_Data.searchby = cmbSearchby.Text
        STthread_Data.searching = txtSearch.Text
        STthread_Data.n = 22

        t2 = New Threading.Thread(AddressOf search_item_from_warehouse2)
        t2.SetApartmentState(Threading.ApartmentState.MTA)
        t2.Start(STthread_Data)
        PictureBox1.Visible = True
        'btnAbort.Visible = True
        Timer1.Start()

        'txtSearch.Focus()

        't2 = New Threading.Thread(New ThreadStart(Sub() item_searching2(txtSearch, cmbSearchby, lvlWarehouseItem)))
        't2.Start()
        'Timer1.Start()

    End Sub
    Private Delegate Sub UpdateDelegate(txt As TextBox, cmb As ComboBox, listview As ListView)

    '' ALLOW THREAD TO COMMUNICATE WITH FORM CONTROL
    'Private Delegate Sub UpdateTextDelegate(TB As TextBox, txt As String)

    '' UPDATE TEXTBOX
    'Private Sub UpdateText(TB As TextBox, txt As String)
    '    If TB.InvokeRequired Then
    '        TB.Invoke(New UpdateTextDelegate(AddressOf UpdateText), New Object() {TB, txt})
    '    Else
    '        If txt IsNot Nothing Then TB.AppendText(txt & vbCrLf)
    '    End If
    'End Sub
    Public Sub item_searching()
        Try
            search_item_from_warehouse(txtSearch.Text, cmbSearchby.Text, 22)

        Catch ex As Exception
            If ex.Message = "Thread was being aborted." Then
                Exit Sub
                ' MessageBox.Show("Thread was being aborted...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try

    End Sub

    Public Sub loading()
        Floading.ShowDialog()
        Floading.TopMost = True
    End Sub
    Public Sub view_materials_turnover()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim a(10) As String

        lvlWarehouseItem.Items.Clear()

        Try
            newSQ.connection.Open()

            newCMD = New SqlCommand("proc_turnover_materials", newSQ.connection)
            newCMD.CommandTimeout = 0
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 1)

            newDR = newCMD.ExecuteReader
            While newDR.Read

                a(0) = newDR.Item("turnover_item_id").ToString
                a(1) = newDR.Item("item_name").ToString
                a(2) = newDR.Item("item_desc").ToString
                a(3) = FProjectIncharge.get_specific_charges_name(newDR.Item("turnover_to_type").ToString, CInt(newDR.Item("turnover_to_id").ToString))

                Dim balance As Double
                Dim qty, total_withdraw As Double

                qty = CInt(newDR.Item("qty").ToString)
                total_withdraw = total_withdrawn_item(CInt(newDR.Item("turnover_item_id").ToString))
                balance = qty - total_withdraw

                a(4) = balance
                a(5) = newDR.Item("spec_loc").ToString
                a(6) = "N/A"
                a(7) = "N/A"
                a(8) = newDR.Item("unit").ToString
                a(9) = newDR.Item("tor_desc").ToString
                a(10) = newDR.Item("condition_of_item").ToString

                Dim lvl As New ListViewItem(a)
                lvlWarehouseItem.Items.Add(lvl)


            End While
            newDR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try



    End Sub

    Private Sub AddItemsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddItemsToolStripMenuItem.Click
        FWarehouseItems.Dock = DockStyle.None
        FWarehouseItems.Show()

    End Sub

    Private Sub FListOfItems_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        FRequestField.btnUnitFocus.PerformClick()
        button_click_name = Nothing

        btnSearch.Enabled = True
        txtSearch.Enabled = True
        cmbSearchby.Enabled = True
        cmboptions.Enabled = True

        lvlWarehouseItem.CheckBoxes = False

        list_item_desc.Clear()
        list_item_name.Clear()
        list_warehouse_area.Clear()

        'FlowLayoutPanel1.Enabled = True
        isItemLinked = False
        cWh_pn_id = 0

        Me.Dispose()
        GC.Collect()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        close_newpanel()
    End Sub

    Private Sub cmb_inOut_New_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_inOut_New.SelectedIndexChanged
        type_of_req(cmb_inOut_New.Text)
    End Sub

    Public Sub type_of_req(ByVal in_out As String)

        With cmb_typeof_pucrchasing
            .Items.Clear()

            If in_out = "IN" Or in_out = "OTHERS" Then

                .Items.Add("CASH")
                .Items.Add("PURCHASE ORDER")
                .Items.Add("DR")
                .Items.Add("N/A")
                .Items.Add("CASH WITH RR")
                'txtWhIncharge.Text = "Vanessa Fabe Piedad"
                txtWhIncharge.Enabled = True
            ElseIf in_out = "OUT" Then
                .Items.Add("WITHDRAWAL")
                'txtWhIncharge.Text = "Vanessa Fabe Piedad"
                txtWhIncharge.Enabled = False


            End If

        End With

    End Sub

    Private Sub btn_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ok.Click

        If cmb_inOut_New.Text = "" Then

            MessageBox.Show("Select IN,OUT or OTHERS on the combobox first..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf cmb_typeof_pucrchasing.Text = "" Then

            MessageBox.Show("Select WITHDRAWAL,CASH,PURCHASE ORDER,N/A on the combobox first..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        ElseIf cmb_factools.Text = "" Then

            MessageBox.Show("Select tools,facilities or N/A on the combobox first..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If

        If CInt(txt_balanceNew.Text) < CInt(txtrequestqty.Text) Then
            If cmb_inOut_New.Text = "IN" Or cmb_inOut_New.Text = "OTHERS" Then
                'continue...
            Else

                If CInt(txt_balanceNew.Text) = CInt(txt_reorderPoint.Text) Then
                    MessageBox.Show("Warning: " & vbCrLf & "Reorder point was already achieved", "Supply Info:", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    If MessageBox.Show("Insufficient quantity," & vbCrLf & "are you still want to proceed?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = DialogResult.Yes Then
                        'continue...
                    Else
                        Exit Sub
                    End If
                End If
            End If
        End If

        For Each ctr As Control In pnl_newqty.Controls
            If TypeOf ctr Is TextBox Or TypeOf ctr Is ComboBox Then
                If ctr.Text = "" Then
                    MessageBox.Show("Pls fill up some blank in the fields..", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If
        Next

        'If cmb_inOut_New.Text = "" Or cmb_typeof_pucrchasing.Text = "" Or cmb_factools.Text = "" Or txt_remarks.Text = "" Or txtWhIncharge.Text = "" Or txtApproved_by.Text = "" Then
        '    MessageBox.Show("Pls fill up all fields.", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If

        UPDATE_REQ_INOUT_TYPEOFPUCRCHASING(lvlWarehouseItem.SelectedItems(0).Text, cmb_inOut_New.Text, cmb_typeof_pucrchasing.Text, txt_remarks.Text)

        Dim query As String = "SELECT main_sub FROM dbrequisition_slip WHERE rs_id = " & rs_id
        Dim main_sub As String = get_specific_column_value(query, 0)

        If main_sub = "SUB" Then

        ElseIf main_sub = "" Then
            If cmb_factools.Text = "FACILITIES" Or cmb_factools.Text = "TOOLS" Then
                Dim query1 As String = "UPDATE dbrequisition_slip SET main_sub = '" & "MAIN" & "', wh_incharge = '" & txtWhIncharge.Text & "',approved_by = '" & txtApproved_by.Text & "',warehouse_checker_id = " & pub_user_id & " WHERE rs_id = " & rs_id
                UPDATE_INSERT_DELETE_QUERY(query1, 0, "UPDATE")
            Else
                Dim query1 As String = "UPDATE dbrequisition_slip SET wh_incharge = '" & txtWhIncharge.Text _
                    & "',approved_by = '" & txtApproved_by.Text &
                    "',warehouse_checker_id = " & pub_user_id &
                    ",item_checked_log = '" & Date.Now() &
                    "' WHERE rs_id = " & rs_id
                UPDATE_INSERT_DELETE_QUERY(query1, 0, "UPDATE")
            End If
        End If

        If cmb_factools.Text = "N/A" Then
        Else
            save_fac_tools(rs_id, cmb_factools.Text)
        End If

        close_newpanel()
        Me.Close()

        rs_id = FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text
        FRequistionForm.btnSearch.PerformClick()
        listfocus(FRequistionForm.lvlrequisitionlist, rs_id)

    End Sub

    Public Sub UPDATE_REQ_INOUT_TYPEOFPUCRCHASING(ByVal whid As Integer, ByVal inout As String, ByVal typeofpucrchasing As String, ByVal remarks As String)
        Try
            SQ.connection.Open()
            publicquery = "UPDATE dbrequisition_slip Set wh_id = '" & whid & "', IN_OUT = '" & inout & "', type_of_purchasing = '" & typeofpucrchasing & "', remarks1 = '" & remarks & "' WHERE rs_id = '" & rs_id & "' "
            cmd = New SqlCommand(publicquery, SQ.connection)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
            GC.Collect()

        End Try
    End Sub

    Public Sub save_fac_tools(ByVal rs_id As Integer, ByVal fac_tools As String)
        Dim sqL As New SQLcon
        Dim newcmd As SqlCommand

        Try
            sqL.connection.Open()
            publicquery = "INSERT INTO Mark_Fac_Tools (rs_id, Marker) VALUES ('" & rs_id & "', '" & fac_tools & "')"
            newcmd = New SqlCommand(publicquery, sqL.connection)
            newcmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqL.connection.Close()
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try
    End Sub

    Private Sub txt_remarks_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_remarks.KeyDown, cmb_factools.KeyDown, cmb_typeof_pucrchasing.KeyDown, cmb_inOut_New.KeyDown
        If e.KeyCode = Keys.Enter Then
            btn_ok.PerformClick()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtApproved_by.TextChanged
        'Try
        '    If txtApproved_by.Text = "" Then
        '        'lboxUnit.Location = New System.Drawing.Point(txtApproved_by.Bounds.Left, txtApproved_by.Bounds.Bottom)
        '        With lboxUnit
        '            .Visible = False

        '        End With
        '    Else
        '        With lboxUnit
        '            .Parent = pnl_newqty
        '            .BringToFront()
        '            .Enabled = True
        '            .Location = New System.Drawing.Point(txtApproved_by.Bounds.Left, txtApproved_by.Bounds.Bottom)
        '            .Visible = True
        '            .Items.Clear()
        '            .Width = txtApproved_by.Width
        '        End With

        '        Dim query As String = "SELECT DISTINCT approved_by FROM dbrequisition_slip WHERE approved_by LIKE '%" & txtApproved_by.Text & "%'"
        '        lboxUnit.Items.Clear()

        '        SELECT_QUERY3(query, lboxUnit)
        '        If lboxUnit.Items.Count > 0 Then
        '        Else
        '            lboxUnit.Visible = False
        '        End If
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub txtWhIncharge_TextChanged(sender As Object, e As EventArgs) Handles txtWhIncharge.TextChanged

        'Try
        '    If txtWhIncharge.Text = "" Then
        '        'lboxUnit.Location = New System.Drawing.Point(txtApproved_by.Bounds.Left, txtApproved_by.Bounds.Bottom)
        '        With lboxUnit
        '            .Visible = False

        '        End With
        '    Else
        '        With lboxUnit
        '            .Parent = pnl_newqty
        '            .BringToFront()
        '            .Enabled = True
        '            .Location = New System.Drawing.Point(txtWhIncharge.Bounds.Left, txtWhIncharge.Bounds.Bottom)
        '            .Visible = True
        '            .Items.Clear()
        '            .Width = txtWhIncharge.Width
        '        End With

        '        Dim query As String = "SELECT DISTINCT wh_incharge FROM dbrequisition_slip WHERE wh_incharge LIKE '%" & txtWhIncharge.Text & "%'"
        '        lboxUnit.Items.Clear()

        '        SELECT_QUERY3(query, lboxUnit)
        '        If lboxUnit.Items.Count > 0 Then
        '        Else
        '            lboxUnit.Visible = False
        '        End If
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub txtApproved_by_GotFocus(sender As Object, e As EventArgs) Handles txtApproved_by.GotFocus
        txtname = txtApproved_by.Name
    End Sub


    Private Sub txtWhIncharge_GotFocus(sender As Object, e As EventArgs) Handles txtWhIncharge.GotFocus
        txtname = txtWhIncharge.Name
    End Sub


    Private Sub txtWH_Pass_KeyDown(sender As Object, e As KeyEventArgs) Handles txtWH_Pass.KeyDown
        If e.KeyCode = Keys.Enter Then

            If txtWH_Pass.Text = "12345" Then
                btnWhPassclose.PerformClick()

                publicvariables.wh_id_for_dr = lvlWarehouseItem.SelectedItems(0).Text
                publicvariables.pub_items_for_dr = lvlWarehouseItem.SelectedItems(0).SubItems(1).Text & " - " & lvlWarehouseItem.SelectedItems(0).SubItems(2).Text

                FWorWODRvb.Show()
                Me.Close()

            End If
        End If




    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles btnWhPassclose.Click
        Panel1.Visible = False
        txtWH_Pass.Clear()

    End Sub

    Private Sub CreateTransactionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateTransactionToolStripMenuItem.Click

        'Panel1.Visible = True
        'Panel1.Location = New Point((lvlWarehouseItem.Width / 2) - (Panel1.Width / 2), (lvlWarehouseItem.Height / 2) - (Panel1.Height / 2))
        'txtWH_Pass.Focus()

    End Sub

    Private Sub lvlWarehouseItem_KeyDown(sender As Object, e As KeyEventArgs) Handles lvlWarehouseItem.KeyDown

    End Sub

    Private Sub DetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetailsToolStripMenuItem.Click

        Dim wh_id As Integer = lvlWarehouseItem.SelectedItems(0).Text
        Dim qty_from_prev_stock_card As Double = get_qty_from_dbPrevious_stock_card(wh_id)
        Dim balance, total_requested, total_qty_from_requestor As Double

        'balance = get_wh_item_balance2(wh_id) ' + qty_from_prev_stock_card 'get_wh_item_balance(dr.Item("wh_id").ToString)
        ' total_requested = get_total_qty_requested_and_not_withdrawn_yet(wh_id, 1) '1 - total requested
        'total_qty_from_requestor = get_total_qty_requested_and_not_withdrawn_yet(wh_id, 2) '2 -total qty from requestor

        balance = FormatNumber((get_wh_item_balance2(wh_id) + qty_from_prev_stock_card), 2,,, TriState.True)

        MessageBox.Show("BALANCE: " & vbCrLf & balance & vbCrLf & vbCrLf & "TOTAL REQUESTED: " & vbCrLf & total_requested _
                       & vbCrLf & vbCrLf & "TOTAL QTY FROM REQUESTOR: " & vbCrLf _
                        , "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub CreateTurnoverHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateTurnoverHistoryToolStripMenuItem.Click
        With FTurnover_History
            .lblItemName.Text = lvlWarehouseItem.SelectedItems(0).SubItems(1).Text
            .lblItemDesc.Text = lvlWarehouseItem.SelectedItems(0).SubItems(2).Text
            load_turnover_items(lvlWarehouseItem.SelectedItems(0).Text)
            .Show()

        End With
    End Sub

    Public Sub load_turnover_items(wh_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        FTurnover_History.lvl_turnover_list.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_turnover_history", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 2)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim a(10) As String

                a(0) = newDR.Item("th_id").ToString
                a(1) = newDR.Item("turnover_from_type").ToString
                a(2) = newDR.Item("turnover_from").ToString
                a(3) = newDR.Item("turnover_to_type").ToString
                a(4) = newDR.Item("turnover_to").ToString
                a(5) = newDR.Item("qty").ToString
                a(6) = newDR.Item("received_by").ToString
                a(7) = newDR.Item("turnover_by").ToString
                a(8) = newDR.Item("noted_by").ToString
                a(9) = newDR.Item("date_turnover").ToString
                a(10) = newDR.Item("condition_of_items").ToString

                Dim lvl As New ListViewItem(a)
                FTurnover_History.lvl_turnover_list.Items.Add(lvl)

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub


    Private Sub cmboptions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmboptions.SelectedIndexChanged
        Dim search_option As String = ""

        If cmboptions.Text = cDivision.WAREHOUSING_AND_SUPPLY Then
            cOptions = cDivision.WAREHOUSING_AND_SUPPLY
        ElseIf cmboptions.Text = cDivision.CRUSHING_AND_HAULING Then
            cOptions = cDivision.CRUSHING_AND_HAULING
        End If


    End Sub

    Private Sub ViewPriceHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewPriceHistoryToolStripMenuItem.Click
        With ViewPriceHistory
            .lblwh_id.Text = lvlWarehouseItem.SelectedItems(0).Text
        End With

        ViewPriceHistory.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel2.Hide()
    End Sub

    Private Sub Button2_Click_3(sender As Object, e As EventArgs) Handles Button2.Click
        date_from = DateTimePicker1.Value.ToString("yyyy/MM/dd")
        date_to = DateTimePicker2.Value.ToString("yyyy/MM/dd")
        FRequistionForm.lvlrequisitionlist.Items.Clear()
        'If thread_1.IsAlive = True Then
        '    MessageBox.Show("unable to procceed transactions, wait for the thread to finish..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Exit Sub
        'End If

        If button_click_name = "ItemsToolStripMenuItem" Then
            Exit Sub

        ElseIf button_click_name = "btnSelectItem" Then
            FRequistionForm.clear_data = "yes"
            'For Each item In lvlWarehouseItem.CheckedItems(0).Text
            '    MsgBox(item.Text)
            'Next
            For Each item In lvlWarehouseItem.CheckedItems
                FRequistionForm.clear_data = "no"
                FRequistionForm.charges_wh_id = CInt(item.text)

                If FRequistionForm.cmbSearchByCategory.Text = "Search by item (Item Checked only)" Then

                    FRequistionForm.load_rs_3(17)

                Else

                    FRequistionForm.load_rs_3(16)

                End If
            Next
            FRequistionForm.clear_data = "yes"
            Exit Sub
            Me.Close()

        ElseIf button_click_name = "ChangeItemNamedescriptionToolStripMenuItem" Then
            With FRequistionForm

                Dim rs_id As Integer = .lvlrequisitionlist.SelectedItems(0).Text
                Dim wh_id As Integer = lvlWarehouseItem.SelectedItems(0).Text
                Dim rs_no As String = .lvlrequisitionlist.SelectedItems(0).SubItems(1).Text

                If MessageBox.Show("Are you sure you want to update the selected rs data to this item description?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    Dim query As String = "update dbrequisition_slip set wh_id = " & wh_id & " WHERE rs_id = " & rs_id
                    UPDATE_INSERT_DELETE_QUERY(query, 0, "UPDATE")

                    .cmbSearchByCategory.Text = "Search by RS.No."
                    .txtSearch.Text = rs_no
                    .load_rs_3(13)
                    listfocus(.lvlrequisitionlist, rs_id)

                    Me.Close()
                    Exit Sub
                End If

            End With
        End If


        Dim qty_from_prev_stock_card As Double = get_qty_from_dbPrevious_stock_card(wh_id)
        Dim balance As Double
        Dim total_request As Double
        Dim total_qty_from_requestor As Double
        Dim link_qty As Double

        wh_id = lvlWarehouseItem.SelectedItems(0).Text
        pub_wh_id = lvlWarehouseItem.SelectedItems(0).Text

        link_qty = CDbl(lvlWarehouseItem.SelectedItems(0).SubItems(14).Text)
        balance = FormatNumber(get_wh_item_balance2(wh_id) + qty_from_prev_stock_card + CDbl(link_qty), , TriState.True) 'get_wh_item_balance(dr.Item("wh_id").ToString)
        total_request = get_total_qty_requested_and_not_withdrawn_yet(wh_id, 1) '1 - total requested
        total_qty_from_requestor = FormatNumber(get_total_qty_requested_and_not_withdrawn_yet(wh_id, 2),, TriState.True) '2 -total qty from requestor

        If balance > CDbl(lvlWarehouseItem.SelectedItems(0).SubItems(8).Text) And lblInOut.Text = "OUT" Then
            MessageBox.Show("Unable to select this item, check the reorder point..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        Else
            If wh_item_destination = 1 Then

                If FRequestField.cmbInOut.Text = "OTHERS" Then 'if others ang inout combobox
                    With FRequestField

                        .txtItemDesc.Text = lvlWarehouseItem.SelectedItems(0).SubItems(2).Text
                        .txtUnit.Text = lvlWarehouseItem.SelectedItems(0).SubItems(8).Text
                        .txtQty.Text = 0

                    End With

                    Me.Dispose()

                Else 'if in/out ang inout na combobox
                    'For Each ctr As Control In pnlItemDesc.Controls
                    '    If ctr.Name = "pnlQty" Then
                    '        ctr.Visible = True
                    '    Else
                    '        ctr.Enabled = False
                    '    End If
                    'Next

                    'txtBalance.Text = lvlWarehouseItem.SelectedItems(0).SubItems(4).Text
                    'txtQty.Focus()

                    For Each ctr As Control In pnlItemDesc.Controls
                        If ctr.Name = "pnl_newqty" Then
                            ctr.Visible = True
                        Else
                            ctr.Enabled = False
                        End If
                    Next

                    'txt_balanceNew.Text = CDbl(lvlWarehouseItem.SelectedItems(0).SubItems(4).Text) - CDbl(lvlWarehouseItem.SelectedItems(0).SubItems(6).Text)
                    'txt_reorderPoint.Text = lvlWarehouseItem.SelectedItems(0).SubItems(8).Text
                    'txtrequestqty.Text = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(5).Text

                    txt_balanceNew.Text = balance - total_qty_from_requestor
                    txt_reorderPoint.Text = lvlWarehouseItem.SelectedItems(0).SubItems(8).Text
                    txtrequestqty.Text = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(5).Text
                End If

                'With FRequestField
                '    .txtItemDesc.Text = lvlWarehouseItem.SelectedItems(0).SubItems(2).Text
                '    .txtUnit.Text = lvlWarehouseItem.SelectedItems(0).SubItems(8).Text
                'End With

            ElseIf wh_item_destination = 2 Then
                FPreviousStackCardFinal.txtItemDesc.Text = lvlWarehouseItem.SelectedItems(0).SubItems(2).Text
                FPreviousStackCardFinal.txt_item_name.Text = lvlWarehouseItem.SelectedItems(0).SubItems(1).Text
                Me.Close()
            End If

        End If

        FRequestField.lblFromWh_or_FromTO.Text = lblFromWh_or_FromTO.Text
        'lboxUnit.Visible = False
        Panel2.Hide()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not t2.IsAlive Then
            Timer1.Stop()
            PictureBox1.Visible = False
            ' btnAbort.Visible = False
            btnSearch2.Enabled = True
            txtSearch.Enabled = True

            For Each row As ListViewItem In lvlWarehouseItem.Items
                If row.SubItems(4).Text = 0 And row.SubItems(8).Text = 0 Then
                    row.BackColor = Color.Pink
                    row.ForeColor = Color.Black
                ElseIf CDbl(row.SubItems(8).Text) > CDbl(row.SubItems(4).Text) Then
                    row.BackColor = Color.Red
                    row.ForeColor = Color.White
                End If
            Next


            If popupmsg = 1 Then
                lvlWarehouseItem.Visible = True
                next1 = 0
                tig_next.Start()
            Else
                lvlWarehouseItem.Visible = True
            End If
        Else
            PictureBox1.Visible = True
        End If

    End Sub

    Public Structure search_wh_data
        Dim searchby As String
        Dim searching As String
        Dim item_name As String
        Dim item_desc As String
        Dim warehouse_area As String
        Dim search_option As String
        Dim n As Integer
    End Structure

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnSearch2.Click
        cSearchBy1 = cmbSearchby.Text
        cOptions = cmboptions.Text.ToUpper()

        Select Case cmbSearchby.Text

            Case cSearchBy.SEARCH_BY_ITEM_DESC,
                 cSearchBy.SEARCH_BY_ITEM_NAME,
                 cSearchBy.SEARCH_BY_PROPER_NAMING

                cSearch = txtSearch.Text

            Case cSearchBy.SEARCH_BY_WAREHOUSE_AREA

                cSearch = txtWarehouseArea.Text

        End Select

        PictureBox1.Visible = True

        BackgroundWorker1.WorkerSupportsCancellation = True
        BackgroundWorker1.RunWorkerAsync()

        Exit Sub



        Dim STthread_Data As search_wh_data
        With STthread_Data
            .searchby = cmbSearchby.Text
            .searching = IIf(txtSearch.Text = "Item Name...", "", txtSearch.Text)
            .item_name = IIf(txtSearch.Text = "Item Name...", "", txtSearch.Text)
            .item_desc = IIf(txtItemDesc.Text = "Item Description...", "", txtItemDesc.Text)
            .warehouse_area = IIf(txtWarehouseArea.Text = "Warehouse Area...", "", txtWarehouseArea.Text)
            .search_option = cmboptions.Text
        End With

        If cmbSearchby.Text = searchEnum.searchByItemName Or
            cmbSearchby.Text = searchEnum.searchByItemDesc Or
            cmbSearchby.Text = searchEnum.searchByWarehouseArea Then

            STthread_Data.n = searchByEnum.testing

        ElseIf cmbSearchby.Text = cSearchBy.SEARCH_BY_PROPER_NAMING Then

            STthread_Data.n = searchByEnum.link_items

        Else
            STthread_Data.n = searchByEnum.itemName_ItemDesc_WhArea
        End If

        ' btnAbort.Visible = True
        btnSearch2.Enabled = False

        Dim themsg As String = "Hi " & fname & " " & lname & "," & vbCrLf & " Click Yes - lang og gusto nimo ma display og apil ang balance, pero medyo lag." & vbCrLf & vbCrLf &
            "Click No - lang kung gusto nimo dili ma display og apil ang balance. medyo pas-pas (sama sa gugma nga paspas ra mawala :))"

        If MessageBox.Show(themsg, "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            popupmsg = 1
        Else
            popupmsg = 2
        End If

        lvlWarehouseItem.Visible = False

        t2 = New Threading.Thread(AddressOf search)
        t2.SetApartmentState(Threading.ApartmentState.MTA)
        t2.Start(STthread_Data)

        PictureBox1.Location = New Point(509, 113)
        PictureBox1.Visible = True
        Timer1.Start()

        't2 = New Threading.Thread(New ThreadStart(Sub() item_searching3(txtSearch, cmbSearchby, lvlWarehouseItem)))
        't2.Start()
    End Sub

    Private Sub displayResult()

        Try
            cListOfListViewItem.Clear()

            Dim themsg As String = "Hi " & fname & " " & lname & "," & vbCrLf & " Click Yes - lang og gusto nimo ma display og apil ang balance, pero medyo lag." & vbCrLf & vbCrLf &
                "Click No - lang kung gusto nimo dili ma display og apil ang balance. medyo pas-pas (sama sa gugma nga paspas ra mawala :))"

            If MessageBox.Show(themsg, "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                popupmsg = 1
            Else
                popupmsg = 2
            End If

            'initData

            Dim initData = getFinalData().Where(Function(x)
                                                    Return x.division.ToUpper() = cOptions.ToUpper()
                                                End Function).
                                                OrderBy(Function(x) x.wh_id).
                                                ToList()

            Dim dataResult As New List(Of PropsFields.whItemsFinal)

            Select Case cSearchBy1
                Case cSearchBy.SEARCH_BY_ITEM_NAME
                    dataResult = initData.Where(Function(x) x.item_name.ToUpper().Contains(cSearch.ToUpper())).ToList()

                Case cSearchBy.SEARCH_BY_ITEM_DESC
                    dataResult = initData.Where(Function(x)
                                                    Return $"{x.item_desc}{Utilities.formatProperNames(x.proper_item_name, x.proper_item_desc, x.wh_pn_id)}".
                                                    ToUpper().
                                                    Contains(cSearch.ToUpper())
                                                End Function).ToList()

                Case cSearchBy.SEARCH_BY_SPECIFIC_LOC
                    dataResult = initData.Where(Function(x) x.specific_loc.ToUpper().Contains(cSearch.ToUpper())).ToList()

                Case cSearchBy.SEARCH_BY_WAREHOUSE_AREA
                    dataResult = initData.Where(Function(x) x.warehouse_area.ToUpper().Contains(cSearch.ToUpper())).ToList()

                Case cSearchBy.SEARCH_BY_WAREHOUSE_INCHARGE
                    dataResult = initData.Where(Function(x)
                                                    Dim fname As String = IIf(IsNothing(x.firstname), "", x.firstname)
                                                    Dim lname As String = IIf(IsNothing(x.lastname), "", x.lastname)

                                                    Dim inchargeNew As String = Utilities.getWhIncharge(x.wh_area_id, Results.rListOfIncharge)

                                                    'Dim incharge As String = $"{x.incharge.ToUpper()} {fname}, {lname}"
                                                    Return inchargeNew.Contains(cSearch.ToUpper())
                                                End Function).ToList()

                Case cSearchBy.SEARCH_BY_DISABLED_ITEM

                    dataResult = initData.Where(Function(x) x.disable = 1).ToList()

                Case cSearchBy.SEARCH_BY_PROPER_NAMING
                    dataResult = initData.Where(Function(x)
                                                    Return x.proper_item_desc.ToUpper().Contains(cSearch.ToUpper())
                                                End Function).ToList()
                Case Else
                    If isItemLinked Then
                        dataResult = initData.Where(Function(x) x.wh_pn_id = cWh_pn_id).ToList()
                    End If
            End Select

            Dim a(17) As String

            For Each row In dataResult

                a(0) = row.wh_id
                a(1) = row.item_name
                a(2) = $"{row.item_desc}{Utilities.formatProperNames(row.proper_item_name, row.proper_item_desc, row.wh_pn_id)}"
                a(3) = Utilities.getWarehouseAreaStockpile(row.wh_area_id, row.whArea_category, row.warehouse_area) 'row.warehouse_area

                If popupmsg = 2 Then

                    a(4) = FormatNumber(0, 2,,, TriState.True)
                    a(5) = 0
                    a(6) = 0

                ElseIf popupmsg = 1 Then

                    a(4) = 0
                    a(5) = get_total_qty_requested_and_not_withdrawn_yet(row.wh_id, 1) '1 - total requested
                    a(6) = FormatNumber(get_total_qty_requested_and_not_withdrawn_yet(row.wh_id, 2),, TriState.True) '2 -total qty from requestor

                End If

                a(7) = row.specific_loc
                a(8) = row.reorder_point
                a(9) = FormatNumber(update_item_price(row.wh_id), 2, , , TriState.True)
                a(10) = row.units
                a(11) = row.type_of_item
                a(13) = row.classification
                a(15) = Utilities.getWhIncharge(row.wh_area_id, Results.rListOfIncharge) 'IIf(row.incharge_id = 0, $"({row.incharge})", $"{row.lastname}, {row.firstname}")
                a(16) = row.wh_pn_id
                a(17) = row.quarry

                Dim lvl As New ListViewItem(a)

                If row.disable = 1 Then
                    lvl = customListviewItem(, a,,, Color.White, "#D4836D")
                End If

                If row.wh_pn_id > 0 Then
                    lvl = customListviewItem(Color.White, a,,, Color.Black)
                Else
                    lvl = customListviewItem(Color.White, a,,, Color.Gray)
                End If

                cListOfListViewItem.Add(lvl)
            Next
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try


    End Sub


    Public Sub loadWhItems()
        cListOfListViewItem.Clear()
        whItemsModel.clearParameter()
        whInchargeModel.clearParameter()
        properNamingModel.clearParameter()
        WhInchargeNewModel.clearParameter()
        EmployeeModel.clearParameter()
        AllChargesModel.clearParameter()
        whAreaStockpileModel.clearParameter()

#Region "INITIALIZE SEARCHBY"
        cmbSearchby.Items.Clear()
        cmbSearchby.Items.Add(cSearchBy.SEARCH_BY_ITEM_NAME)
        cmbSearchby.Items.Add(cSearchBy.SEARCH_BY_ITEM_DESC)
        cmbSearchby.Items.Add(cSearchBy.SEARCH_BY_WAREHOUSE_AREA)
        cmbSearchby.Items.Add(cSearchBy.SEARCH_BY_PROPER_NAMING)

#End Region

#Region "INITIALIZE OPTIONS"
        cmboptions.Items.Add(cDivision.WAREHOUSING_AND_SUPPLY)
        cmboptions.Items.Add(cDivision.CRUSHING_AND_HAULING)

#End Region

        PictureBox1.Visible = True

        Dim values As New Dictionary(Of String, String)
        Dim cv3 As New ColumnValues
        cv3.add("crud", "8")


        Dim cv As New ColumnValues
        cv.add("crud", 7)
        cv.add("search", "")


        _initializing(cCol.forWhItems,
                      values,
                      whItemsModel,
                      WhItemsBgWorker)

        _initializing(cCol.forWhIncharge,
                      values,
                      whInchargeModel,
                      WhItemsBgWorker)

        _initializing(cCol.forWhItem_ProperNames,
                      values,
                      properNamingModel,
                      WhItemsBgWorker)

        _initializing(cCol.forWhInchargeNew,
                      cv3.getValues(),
                      WhInchargeNewModel,
                      WhItemsBgWorker)

        _initializing(cCol.forEmployeeData,
                      cv3.getValues(),
                      EmployeeModel,
                      WhItemsBgWorker)

        _initializing(cCol.forAllCharges,
                        cv3.getValues(),
                        AllChargesModel,
                        WhItemsBgWorker)

        _initializing(cCol.forWareHouseStockpileArea,
                      cv.getValues(),
                      whAreaStockpileModel,
                      WhItemsBgWorker)


        cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, WhItemsBgWorker)

    End Sub

    Private Sub SuccessfullyDone()

        Results.cResult = TryCast(whItemsModel.cData, List(Of PropsFields.whItems_props_fields))
        Results.cResult2 = TryCast(whInchargeModel.cData, List(Of PropsFields.incharge_fields))
        Results.rListOfIncharge = TryCast(WhInchargeNewModel.cData, List(Of PropsFields.inchargeNew_fields))
        Results.cListOfEmployees = TryCast(EmployeeModel.cData, List(Of PropsFields.employee_props_fields))
        Results.cListOfProperNaming = TryCast(properNamingModel.cData, List(Of PropsFields.whItems_properName_fields))
        Results.rListOfAllCharges = TryCast(AllChargesModel.cData, List(Of PropsFields.AllCharges))
        cListOfWhArea = TryCast(whAreaStockpileModel.cData, List(Of PropsFields.whArea_stockpile_props_fields))

        PictureBox1.Visible = False

        If isItemLinked Then
            btnSearch2.PerformClick()
            Panel3.Enabled = False
        End If
    End Sub
    Enum searchByEnum
        itemName_ItemDesc_WhArea_division = 1
        itemName_ItemDesc_WhArea = 2
        testing = 12
        link_items = 13

    End Enum

    Private Sub search(ByVal wh_data As search_wh_data)

        'Dim searchby As String = STthread_Data.searchby
        'Dim searching As String = STthread_Data.searching

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim search_option As String = ""

        If cmboptions.Text = "WAREHOUSING" Then
            search_option = "WAREHOUSING AND SUPPLY"

        ElseIf cmboptions.Text = "HAULING AND CRUSHING" Then
            search_option = "CRUSHING AND HAULING"

        End If

        'ListView.Items.Clear()
        If lvlWarehouseItem.InvokeRequired Then
            lvlWarehouseItem.Invoke(Sub() lvlWarehouseItem.Items.Clear())
        Else
            lvlWarehouseItem.Items.Clear()

        End If

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_get_data_from_warehouse1", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            With wh_data
                If .n = searchByEnum.testing Then
                    newCMD.Parameters.AddWithValue("@n", .n)
                    newCMD.Parameters.AddWithValue("@search_by", .searchby)
                    newCMD.Parameters.AddWithValue("@item_name", IIf(.searchby = searchEnum.searchByItemName, .item_name, .item_desc))
                    newCMD.Parameters.AddWithValue("@search_option", search_option)
                    newCMD.Parameters.AddWithValue("@warehouse_area", .warehouse_area)

                ElseIf .n = searchByEnum.itemName_ItemDesc_WhArea Then
                    newCMD.Parameters.AddWithValue("@n", .n)
                    newCMD.Parameters.AddWithValue("@item_name", .item_name)
                    newCMD.Parameters.AddWithValue("@item_desc", .item_desc)
                    newCMD.Parameters.AddWithValue("@warehouse_area", .warehouse_area)
                    'newCMD.Parameters.AddWithValue("@search_option", .search_option)

                ElseIf .n = searchByEnum.link_items Then
                    newCMD.Parameters.AddWithValue("@n", .n)
                    newCMD.Parameters.AddWithValue("@wh_pn_id", cWh_pn_id)

                End If
            End With

            newDR = newCMD.ExecuteReader

            Dim a(16) As String

            While newDR.Read

                ''if disabled
                'If newDR.Item("disable").ToString = 1 Then
                '    GoTo procceedHere
                'End If
                Dim proper_item_name As String = newDR.Item("proper_item_name").ToString
                Dim proper_item_desc As String = newDR.Item("proper_item_desc").ToString
                Dim wh_pn_id As Integer = IIf(newDR.Item("wh_pn_id").ToString = "", 0, newDR.Item("wh_pn_id").ToString)
                Dim properNames As String = Utilities.formatProperNames(proper_item_name,
                                                                                      proper_item_desc,
                                                                                      wh_pn_id)
                a(0) = newDR.Item("wh_id").ToString
                a(1) = newDR.Item("wh_item").ToString
                a(2) = $"{newDR.Item("wh_desc").ToString}{properNames}"
                a(3) = newDR.Item("wh_area").ToString

                If popupmsg = 2 Then

                    a(4) = FormatNumber(0, 2,,, TriState.True)
                    a(5) = 0
                    a(6) = 0

                ElseIf popupmsg = 1 Then
                    'With crs_data
                    '    .wh_id = newDR.Item("wh_id").ToString
                    '    .date_from = Date.Parse(Now)
                    '    .user_id = pub_user_id
                    '    .wh_area = newDR.Item("wh_area").ToString
                    '    .intended = "WAREHOUSE ITEM"
                    'End With

                    'get_balance()

                    'a(4) = FormatNumber(get_beginning_balance1(newDR.Item("wh_id").ToString), 2,,, TriState.True)
                    a(4) = 0
                    a(5) = get_total_qty_requested_and_not_withdrawn_yet(newDR.Item("wh_id").ToString, 1) '1 - total requested
                    a(6) = FormatNumber(get_total_qty_requested_and_not_withdrawn_yet(newDR.Item("wh_id").ToString, 2),, TriState.True) '2 -total qty from requestor

                End If
                'a(4) = IIf(popupmsg = 2, 0, FormatNumber(get_beginning_balance1(newDR.Item("wh_id").ToString), 2,,, TriState.True))

                a(7) = newDR.Item("location").ToString
                a(8) = newDR.Item("whReorderPoint").ToString
                a(9) = FormatNumber(update_item_price(newDR.Item("wh_id").ToString), 2, , , TriState.True)
                a(10) = newDR.Item("unit").ToString
                a(11) = newDR.Item("tor_desc").ToString & " - " & newDR.Item("tor_sub_desc").ToString
                a(13) = newDR.Item("whClass").ToString
                a(15) = newDR.Item("wh_incharge").ToString
                a(16) = wh_pn_id

                Dim lvl As New ListViewItem(a)

                If lvlWarehouseItem.InvokeRequired Then
                    lvlWarehouseItem.Invoke(Sub()
                                                lvlWarehouseItem.Items.Add(lvl)
                                            End Sub)
                Else
                    lvlWarehouseItem.Items.Add(lvl)
                End If
                'ListView.Items.Add(lvl)

procceedHere:
            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Sub
    Private Sub get_balance()

        PictureBox1.Visible = True
        t3 = New Threading.Thread(AddressOf get_prev_balance)
        t3.Start()
        Timer2.Start()
    End Sub

    Private Function get_prev_balance() As Double
        Dim c_search As New Class_SC_Hauling(crs_data)
        'c_search.st_delete()
        'c_search.from_rs("OUT")
        'c_search.from_rs("IN")
        'get_prev_balance = c_search.prev_balance_in_label1()
        'c_search.rem_balance(get_prev_balance)
        'MsgBox(get_prev_balance)

        c_search.rem_balance(0)

    End Function

    Private Sub btnExit_Click(sender As Object, e As EventArgs)
        FRequestField.btnUnitFocus.PerformClick()
        button_click_name = Nothing

        btnSearch.Enabled = True
        txtSearch.Enabled = True
        cmbSearchby.Enabled = True
        cmboptions.Enabled = True

        lvlWarehouseItem.CheckBoxes = False
        Me.Dispose()

    End Sub


    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If Not t3.IsAlive Then
            Timer2.Stop()
            PictureBox1.Visible = False

            If next1 = lvlWarehouseItem.Items.Count - 1 Then
                tig_next.Stop()
            Else
                tig_next.Start()
            End If

        End If
    End Sub

    Private Sub TryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TryToolStripMenuItem.Click
        With crs_data
            .wh_id = lvlWarehouseItem.SelectedItems(0).Text
            .date_from = Date.Parse(Now)
            .user_id = pub_user_id
            .intended = "WAREHOUSE ITEM"
        End With

        get_balance()
    End Sub

    Private Sub tig_next_Tick(sender As Object, e As EventArgs) Handles tig_next.Tick
        Dim indexcount As Integer = lvlWarehouseItem.Items.Count - 1

        'If lvlWarehouseItem.Items(next1).Text = lvlWarehouseItem.Items(indexcount).Text Then
        '    Label17.Text = lvlWarehouseItem.Items(next1).Text
        '    lvlWarehouseItem.SelectedItems.Clear()
        '    next1 += 1
        '    listfocus(lvlWarehouseItem, lvlWarehouseItem.Items(next1).Text)
        '    tig_next_triger(lvlWarehouseItem.Items(next1).Text, next1)
        '    tig_next.Stop()
        '    Exit Sub
        'End If
        If indexcount = -1 Then
            tig_next.Stop()
            Exit Sub
        End If

        Label17.Text = lvlWarehouseItem.Items(next1).Text

        '****triger****
        tig_next.Stop()
        tig_next_triger(lvlWarehouseItem.Items(next1).Text, next1)
        lvlWarehouseItem.SelectedItems.Clear()
        listfocus(lvlWarehouseItem, lvlWarehouseItem.Items(next1).Text)
        '****end triger***

        If indexcount = 0 Then
            tig_next.Stop()
            Exit Sub
        End If

        next1 += 1

        If next1 = indexcount Then
            tig_next.Stop()
            tig_next_triger(lvlWarehouseItem.Items(next1).Text, next1)
            lvlWarehouseItem.SelectedItems.Clear()
            listfocus(lvlWarehouseItem, lvlWarehouseItem.Items(next1).Text)
        End If

    End Sub

    Private Sub tig_next_triger(wh_id As Integer, rowindex As Integer)
        With crs_data
            .lvl = lvlWarehouseItem
            .wh_id = wh_id
            .date_from = Date.Parse(Now)
            .user_id = pub_user_id
            .intended = "WAREHOUSE ITEM"
            .rowindex = rowindex
        End With

        get_balance()
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs)
        listfocus(lvlWarehouseItem, lvlWarehouseItem.Items(lvlWarehouseItem.Items.Count - 1).Text)
    End Sub

    Private Sub cmb_factools_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_factools.SelectedIndexChanged

    End Sub

    Private Sub lvlWarehouseItem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvlWarehouseItem.SelectedIndexChanged

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        displayResult()

    End Sub

    Private Sub FOROUTWITHOURRSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FOROUTWITHOURRSToolStripMenuItem.Click

        Try
            Dim selectedItem As ListViewItem = lvlWarehouseItem.SelectedItems(0)

            With FCreateDeliveryReceipt
                .ReleasedQty = 0

                .DeliveredQty = 0

                With .cStockpileOut

                    .wh_id = selectedItem.Text
                    .typeOfPurchasing = cTypeOfPurchasing.WITHDRAWAL
                    .charges = ""
                    .units = selectedItem.SubItems(10).Text
                End With

                .cTypeOfPurchasing1 = cTypeOfPurchasing.WITHDRAWAL
                .cWithDr = False
                .cDrOption = DROptions.out_without_rs
                '.CheckBox1.Enabled = False

                .ShowDialog()
            End With
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
        Exit Sub

        ''FDeliveryReceipt.Activate()
        ''FDeliveryReceipt.MdiParent = Me
        ''FDeliveryReceipt.Dock = DockStyle.Fill




        'publicvariables.wh_id_for_dr = lvlWarehouseItem.SelectedItems(0).Text
        'publicvariables.pub_items_for_dr = lvlWarehouseItem.SelectedItems(0).SubItems(1).Text & " - " & lvlWarehouseItem.SelectedItems(0).SubItems(2).Text

        'FDeliveryReceipt.trigger("out without rs", "OUT")

        'FDeliveryReceipt.Activate()
        'FDeliveryReceipt.MdiParent = FMain
        'FDeliveryReceipt.Dock = DockStyle.Fill
        'FDeliveryReceipt.Show()
        Dim wh_id As Integer = lvlWarehouseItem.SelectedItems(0).Text
        Dim itemDesc As String = $"{lvlWarehouseItem.SelectedItems(0).SubItems(1).Text} - {lvlWarehouseItem.SelectedItems(0).SubItems(2).Text}"

        'Floading.Show()
        'Dim ok As Boolean = FDeliveryReceipt.trigger2("out without rs", "OUT", wh_id, itemDesc)

        'If ok = True Then

        '    FDeliveryReceipt.cmbOptions.Enabled = False
        '    FDeliveryReceipt.Activate()
        '    FDeliveryReceipt.MdiParent = FMain
        '    FDeliveryReceipt.Dock = DockStyle.Fill
        '    FDeliveryReceipt.Show()
        'Else
        '    customMsg.message("error", "There is something wrong with your transactions", "SUPPLY INFO:")
        'End If

        Dim status As New FDeliveryReceipt.aggStatus
        status.wh_id = wh_id
        status.item_desc = itemDesc
        status.status = FDeliveryReceipt.Status.outWithoutRs
        status.inOut = "OUT"
        status.rsNo = "N/A"

        FDeliveryReceipt.trigger3(status)

        FDeliveryReceipt.cmbOptions.Enabled = False
        FDeliveryReceipt.Activate()
        FDeliveryReceipt.MdiParent = FMain
        FDeliveryReceipt.Dock = DockStyle.Fill
        FDeliveryReceipt.Show()

    End Sub

    Private Sub FORINWITHOUTRSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FORINWITHOUTRSToolStripMenuItem.Click

        Try
            Dim selectedItem As ListViewItem = lvlWarehouseItem.SelectedItems(0)

            With FCreateDeliveryReceipt
                .ReleasedQty = 0

                .DeliveredQty = 0

                With .cStockpileIn

                    .wh_id = selectedItem.Text
                    .typeOfPurchasing = cTypeOfPurchasing.DR
                    .units = selectedItem.SubItems(10).Text

                End With

                .cTypeOfPurchasing1 = cTypeOfPurchasing.DR
                .cWithDr = False
                .cDrOption = DROptions.in_without_rs


                .ShowDialog()
            End With
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
        Exit Sub



        publicvariables.wh_id_for_dr = lvlWarehouseItem.SelectedItems(0).Text
        publicvariables.pub_items_for_dr = lvlWarehouseItem.SelectedItems(0).SubItems(1).Text & " - " & lvlWarehouseItem.SelectedItems(0).SubItems(2).Text

        FDeliveryReceipt.trigger("in without rs", "IN")

        FDeliveryReceipt.Activate()
        FDeliveryReceipt.MdiParent = FMain
        FDeliveryReceipt.Dock = DockStyle.Fill

        FDeliveryReceipt.Show()


    End Sub

    Private Sub FOROTHERSWITHRSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FOROTHERSWITHRSToolStripMenuItem.Click

        Try
            Dim selectedRow = lvlWarehouseItem.SelectedItems(0)

            With FCreateDeliveryReceipt
                .ReleasedQty = 0

                .DeliveredQty = 0

                With .cStockpileIn

                    Dim charges

                    .wh_id = selectedRow.Text
                    .typeOfPurchasing = cTypeOfPurchasing.DR
                    .units = selectedRow.SubItems(10).Text
                    .charges = selectedRow.SubItems(3).Text
                    .stockpile = "waiting..."
                    .quarry = "waiting..."
                    .itemName = selectedRow.SubItems(2).Text
                End With

                .cTypeOfPurchasing1 = cTypeOfPurchasing.DR
                .cWithDr = False
                .cDrOption = DROptions.others_without_rs


                .ShowDialog()
            End With
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
        Exit Sub


        Dim wh_id As Integer = lvlWarehouseItem.SelectedItems(0).Text
        Dim itemDesc As String = $"{lvlWarehouseItem.SelectedItems(0).SubItems(1).Text} - {lvlWarehouseItem.SelectedItems(0).SubItems(2).Text}"

        Dim status As New FDeliveryReceipt.aggStatus
        status.wh_id = wh_id
        status.item_desc = itemDesc
        status.status = FDeliveryReceipt.Status.othersWithoutRs
        status.inOut = "OTHERS"
        status.rsNo = "N/A"

        FDeliveryReceipt.trigger3(status)

        FDeliveryReceipt.cmbOptions.Enabled = False
        FDeliveryReceipt.Activate()
        FDeliveryReceipt.MdiParent = FMain
        FDeliveryReceipt.Dock = DockStyle.Fill
        FDeliveryReceipt.Show()
    End Sub

    Private Sub BW_get_data_DoWork(sender As Object, e As DoWorkEventArgs) Handles BW_get_data.DoWork
        Dim item_data As New Model._Mod_Warehouse_Item
    End Sub

    Public Sub aprove_by_name()
        list_person_name = New List(Of List(Of String))
        Dim row As Integer
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_supplier_evaluation"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 3)
            dr = sqlcomm.ExecuteReader

            While dr.Read
                list_person_name.Add(New List(Of String))
                list_person_name(row).Add(dr.Item(0).ToString)
                row = row + 1
            End While

            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

        Dim txt_row As New AutoCompleteStringCollection

        For Each list_row As List(Of String) In list_person_name
            txt_row.Add(list_row(0))
        Next
        txtApproved_by.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtApproved_by.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtApproved_by.AutoCompleteCustomSource = txt_row
    End Sub

    Public Sub wh_incharge_name()
        list_person_name2 = New List(Of List(Of String))
        Dim row As Integer
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_supplier_evaluation"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 4)
            dr = sqlcomm.ExecuteReader

            While dr.Read
                list_person_name2.Add(New List(Of String))
                list_person_name2(row).Add(dr.Item(0).ToString)
                row = row + 1
            End While

            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

        Dim txt_row As New AutoCompleteStringCollection

        For Each list_row As List(Of String) In list_person_name2
            txt_row.Add(list_row(0))
        Next
        txtWhIncharge.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtWhIncharge.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtWhIncharge.AutoCompleteCustomSource = txt_row
    End Sub


    Private Sub ViewStockcardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewStockcardToolStripMenuItem.Click
        'With StockCard1
        '    .loadStockcard(lvlWarehouseItem.SelectedItems(0).Text)
        '    .ShowDialog()
        'End With

        If cOptions = cDivision.WAREHOUSING_AND_SUPPLY Then

            With FStockCard3
                .loadStockCard(lvlWarehouseItem.SelectedItems(0).Text)
                .Text = $"{lvlWarehouseItem.SelectedItems(0).SubItems(1).Text} - {lvlWarehouseItem.SelectedItems(0).SubItems(2).Text} ({lvlWarehouseItem.SelectedItems(0).SubItems(3).Text })"
                .ShowDialog()
            End With

        Else
            customMsg.message("error", "coming soon...", "SUPPLY INFO:")
        End If


    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        lvlWarehouseItem.Items.Clear()
        lvlWarehouseItem.Items.AddRange(cListOfListViewItem.ToArray())

        PictureBox1.Visible = False
    End Sub

End Class