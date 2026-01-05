Imports System.ComponentModel
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Windows.Interop
Imports OfficeOpenXml.FormulaParsing.ExpressionGraph
Public Class Fsearchbycharges
    Dim counter As Integer
    Public thread, thread1 As System.Threading.Thread
    Dim proj1, item1 As String
    Dim search_charges, item_name As String
    Dim time_ticker As Integer
    Public threadaborted As Boolean
    Dim list_item_desc As New List(Of List(Of String))

    Dim crs_data As New Class_Search_Charges.search_charges_data

    Dim trd, trd2, trd3 As Threading.Thread
    Dim charges As New class_charges
    Dim ListOfLview As New List(Of ListViewItem)
    Dim ListOfThreading As New List(Of Threading.Thread)
    Dim ListOfWsClass As New List(Of class_withdrawal)
    Dim ListOfWsID As New List(Of String)

    Private cListOfRsId As New List(Of rsIdType)
    Private cListOfDatas As New List(Of datasType)
    Private cListOfThreading As New List(Of Threading.Thread)
    Private cRsId As Integer

    Private Class datasType
        Property rs_id As Integer
        Property price As Double
        Property rs_price As Double
    End Class

    Private Class rsIdType
        Property rs_id As Integer
        Property typeOfPurchasing As String
    End Class

    ' Define a counter for completed workers
    Private completedWorkers As Integer = 0
    Private totalWorkers As Integer = 0 ' Update if you add more workers
    Private Sub Fsearchbycharges_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbByDate.Text = "BY DATE FROM THE BEGINNING"

        If pub_search_by_charges = 1 Then
            rs_search_by_charges()

        ElseIf pub_search_by_charges = 2 Then
            ws_search_by_charges()
        End If


        ''**** temporary enable please don't delete this ****
        'pub_search_by_charges = 1
        'For Each ctr As Control In Me.GroupBox1.Controls

        '    ctr.Enabled = True
        'Next

    End Sub

    Private Sub ws_search_by_charges()
        search_charges = cmbProject.Text
        item_name = txtItemSearch.Text

        list_item_desc.Clear()
        load_items(4, list_item_desc, "")

        Dim placeholder As New Class_PlaceHolder_Warehouse
        placeholder.load_what_you_search(txtItemSearch, list_item_desc)

        cmbGenerateProject.Enabled = False

    End Sub

    Private Sub rs_search_by_charges()

        If FRequistionForm.cmbDivision.Text = "WAREHOUSING AND SUPPLY" Then
            search_charges = cmbProject.Text
            item_name = txtItemSearch.Text

            list_item_desc.Clear()

            If search_charges = "" Or search_charges = "Charges..." AndAlso item_name = "" Or item_name = "Items..." Then
                'pass
            Else

                load_items(2, list_item_desc, "WAREHOUSING AND SUPPLY")

                Dim placeholder As New Class_PlaceHolder_Warehouse
                placeholder.load_what_you_search(txtItemSearch, list_item_desc)

                cmbGenerateProject.Enabled = False
            End If



            'FDRLIST.load_requestor(cmbProject, 14)

            'load_rs_id_first_for_charges(FRequistionForm.txtSearch.Text, FRequistionForm.txtItemName.Text)

            'lvlSearchCharges.Items.Clear()
            'thread = New System.Threading.Thread(AddressOf load_the_charges)
            'thread.Start()
            'Panel3.Visible = True
            'btnEndProcess.Visible = True
            'Timer1.Start()

        Else
            If FRequistionForm.cmbSearchByCategory.Text = "Generate Summary of Hauling Aggregates" Then

                'cmbProject.Items.Add("")

                'cmbGenerateProject.Enabled = True
                'cmbProject.Enabled = True
                'txtChargesSearch.Enabled = True
                'txtItemSearch.Enabled = True
                'Button2.Enabled = True
                'dtpdatefrom.Enabled = True
                'Button1.Enabled = False

            ElseIf FRequistionForm.cmbSearchByCategory.Text = "Search by Charges" Or FRequistionForm.cmbSearchByCategory.Text = "Search by Requested by" Or FRequistionForm.cmbSearchByCategory.Text = "Search by User Name" Then

                'FDRLIST.load_requestor(cmbProject, 14)
                'cmbGenerateProject.Enabled = False
                'Button1.Enabled = True
                'cmbGenerateProject.Enabled = False
                'cmbGenerateProject.Enabled = True
                'cmbProject.Enabled = False
                'txtChargesSearch.Enabled = False
                'txtItemSearch.Enabled = False
                'Button2.Enabled = False
                'dtpdatefrom.Enabled = False
                'Button1.Enabled = True


                '**********************************************
                'Button2.Enabled = False

                'search_charges = FRequistionForm.txtSearch.Text
                'item_name = FRequistionForm.txtItemName.Text

                'btnEndProcess.Visible = True
                'thread = New System.Threading.Thread(AddressOf search_by_charges2)
                'thread.Start(FRequistionForm.cmbSearchByCategory.Text)
                'Timer1.Start()
                '**********************************************
                'search_by_charges()

                search_charges = cmbProject.Text
                item_name = txtItemSearch.Text

                list_item_desc.Clear()
                load_items(2, list_item_desc, "CRUSHING AND HAULING")

                Dim placeholder As New Class_PlaceHolder_Warehouse
                placeholder.load_what_you_search(txtItemSearch, list_item_desc)

                cmbGenerateProject.Enabled = False
                cmbProject.Enabled = True
                cmbProject1.Enabled = True
                txtItemSearch.Enabled = True
                dtpdatefrom.Enabled = True
                dtpdateto.Enabled = True
                Button2.Enabled = True
                Button1.Enabled = True

            End If

        End If



        'For Each row As ListViewItem In lvlSearchCharges.Items
        '    row.Checked = True
        'Next

        'Button1.PerformClick()
    End Sub
    Private Sub load_items(n As Integer, data_list As List(Of List(Of String)), search_option As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim data_list1 As New List(Of List(Of String))
        data_list1 = data_list
        '1 - item name 
        '2 - item desc
        '3 - warehouse area
        '4 - warehouse and hauling
        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_list_of_item1", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@search_option", search_option)

            'If n = 1 Then
            '    newCMD.Parameters.AddWithValue("@search_option", search_option)
            'ElseIf n = 2 Then
            '    newCMD.Parameters.AddWithValue("@search_option", search_option)
            'ElseIf n = 3 Then
            '    newCMD.Parameters.AddWithValue("@search_option", search_option)
            'End If
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
        End Try
    End Sub

    Private Sub load_the_charges()
        If cmbProject1.InvokeRequired Then
            cmbProject1.Invoke(Sub()
                                   load_rs_id_first_for_charges(cmbProject1.Text, txtItemSearch.Text)
                               End Sub)
        Else
            load_rs_id_first_for_charges(cmbProject1.Text, txtItemSearch.Text)
        End If


        For Each row As String In ListBox1.Items
            load_the_charges1(row)
        Next

    End Sub
    Private Sub load_rs_id_first_for_charges(charges As String, items As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        If ListBox1.InvokeRequired Then
            ListBox1.Invoke(Sub()
                                ListBox1.Items.Clear()
                            End Sub)
        Else
            ListBox1.Items.Clear()
        End If


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 15)

            Select Case charges
                Case "Charges..."
                    charges = ""
                Case "RS No..."
                    charges = ""
            End Select

            Select Case items
                Case "Items..."
                    items = ""
            End Select

            newCMD.Parameters.AddWithValue("@charges", charges)
            newCMD.Parameters.AddWithValue("@items", items)

            newCMD.CommandTimeout = 100

            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                If ListBox1.InvokeRequired Then
                    ListBox1.Invoke(Sub()
                                        ListBox1.Items.Add(newDR.Item("rs_id").ToString)
                                    End Sub)
                Else
                    ListBox1.Items.Add(newDR.Item("rs_id").ToString)
                End If

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub load_the_charges1(rs_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 16)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newCMD.CommandTimeout = 100

            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                a(0) = newDR.Item("rs_no").ToString
                a(1) = newDR.Item("item_desc_from_warehouse").ToString
                a(2) = Date.Parse(newDR.Item("date_req").ToString)
                a(3) = newDR.Item("wh_id").ToString
                a(4) = newDR.Item("rs_id").ToString
                a(6) = newDR.Item("item_desc_from_rs").ToString

                Dim lvl As New ListViewItem(a)

                If lvlSearchCharges.InvokeRequired Then
                    lvlSearchCharges.Invoke(Sub() lvlSearchCharges.Items.Add(lvl))
                Else
                    lvlSearchCharges.Items.Add(lvl)
                End If

            End While

        Catch ex As Exception
            If threadaborted = True Then
                MessageBox.Show("Process has been aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                threadaborted = False
                Exit Sub
            End If
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub search_by_charges1(search As String, generate_option As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        'FRequistionForm.lvlrequisitionlist.Items.Clear()
        lvlSearchCharges.Items.Clear()

        Dim search_charges As String = search
        Dim item_name As String = txtItemSearch.Text

        Try
            newSQ.connection.Open()
            ' newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search", newSQ.connection)
            newCMD = New SqlCommand("proc_Aggregates_Search_by_Charges", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure


            If FRequistionForm.cmbSearchByCategory.Text = "Search by Requested by" Then
                newCMD.Parameters.AddWithValue("@search_charges", search_charges)

            Else
                If generate_option = "Generate by All Project" Or generate_option = "Generate by Specific project" Then
                    If search = "" Then
                        'kini kung empty ang requestor
                        newCMD.Parameters.AddWithValue("@n", 5)
                    Else
                        newCMD.Parameters.AddWithValue("@n", 2)
                    End If

                    newCMD.Parameters.AddWithValue("@search_charges", search_charges)
                    newCMD.Parameters.AddWithValue("@itemname", item_name)
                    newCMD.Parameters.AddWithValue("@generate_option", generate_option)
                    newCMD.Parameters.AddWithValue("@datefrom", Date.Parse(dtpdatefrom.Text))
                    newCMD.Parameters.AddWithValue("@dateto", Date.Parse(dtpdateto.Text))
                Else
                    newCMD.Parameters.AddWithValue("@n", 6)
                    newCMD.Parameters.AddWithValue("@search_charges", txtChargesSearch.Text)
                    newCMD.Parameters.AddWithValue("@generate_option", generate_option)

                End If
            End If

            newCMD.CommandTimeout = 300

            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                a(0) = newDR.Item("rs_no").ToString
                If newDR.Item("wh_id").ToString = 0 Then
                    a(1) = newDR.Item("items").ToString
                Else
                    a(1) = newDR.Item("whItem").ToString & " - " & newDR.Item("item_desc").ToString
                End If

                a(2) = Format(Date.Parse(newDR.Item("rs_date").ToString), "MM/dd/yyyy")
                a(3) = newDR.Item("wh_id").ToString
                a(4) = newDR.Item("rs_id").ToString
                a(5) = search_charges

                Dim lvl As New ListViewItem(a)
                lvlSearchCharges.Items.Add(lvl)

                Application.DoEvents()
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub search_by_charges(searchby As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        FRequistionForm.lvlrequisitionlist.Items.Clear()
        lvlSearchCharges.Items.Clear()

        'Dim search_charges As String = FRequistionForm.txtSearch.Text
        'Dim item_name As String = FRequistionForm.txtItemName.Text

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            If FRequistionForm.cmbDivision.Text = "WAREHOUSING AND SUPPLY" Then
                newCMD.Parameters.AddWithValue("@n", 34)
                newCMD.Parameters.AddWithValue("@category", searchby)
            Else
                newCMD.Parameters.AddWithValue("@n", 2)
            End If

            If FRequistionForm.cmbSearchByCategory.Text = "Search by Requested by" Then
                newCMD.Parameters.AddWithValue("@search_charges", IIf(search_charges = "Requested By...", "", search_charges))
            Else
                newCMD.Parameters.AddWithValue("@search_charges", IIf(search_charges = "Charges...", "", search_charges))
            End If

            newCMD.Parameters.AddWithValue("@iem_desc", IIf(item_name = "Items...", "", item_name))
            newCMD.CommandTimeout = 300

            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read

                a(0) = newDR.Item("rs_no").ToString
                If newDR.Item("wh_id").ToString = 0 Then
                    a(1) = newDR.Item("items").ToString
                Else
                    a(1) = newDR.Item("whItem").ToString & " - " & newDR.Item("item_desc").ToString
                End If

                a(2) = Format(Date.Parse(newDR.Item("rs_date").ToString), "MM/dd/yyyy")
                a(3) = newDR.Item("wh_id").ToString
                a(4) = newDR.Item("rs_id").ToString
                a(6) = newDR.Item("items").ToString

                Dim lvl As New ListViewItem(a)
                If lvlSearchCharges.InvokeRequired Then
                    lvlSearchCharges.Invoke(Sub() lvlSearchCharges.Items.Add(lvl))
                Else
                    lvlSearchCharges.Items.Add(lvl)
                End If

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Private Sub search_by_charges2(searchby As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        lvlSearchCharges.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            'newCMD.Parameters.AddWithValue("@n", 2)
            newCMD.Parameters.AddWithValue("@n", 22)

            If searchby = "Search by Requested by" Then
                newCMD.Parameters.AddWithValue("@search_charges", IIf(search_charges = "Requested By...", "", search_charges))

            ElseIf searchby = "Search by Charges" Then
                newCMD.Parameters.AddWithValue("@search_charges", IIf(search_charges = "Charges...", "", search_charges))

            ElseIf FRequistionForm.cmbSearchByCategory.Text = "Search by User Name" Then
                newCMD.Parameters.AddWithValue("@search_charges", search_charges)
            End If

            If item_name = "Items..." Then
                item_name = ""
            End If

            newCMD.Parameters.AddWithValue("@iem_desc", item_name)
            newCMD.Parameters.AddWithValue("@searchby", searchby)
            newCMD.CommandTimeout = 300

            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read

                a(0) = newDR.Item("rs_no").ToString
                If newDR.Item("wh_id").ToString = 0 Then
                    a(1) = newDR.Item("items").ToString
                Else
                    a(1) = newDR.Item("whItem").ToString & " - " & newDR.Item("item_desc").ToString
                End If

                a(2) = Format(Date.Parse(newDR.Item("rs_date").ToString), "MM/dd/yyyy")
                a(3) = newDR.Item("wh_id").ToString
                a(4) = newDR.Item("rs_id").ToString
                a(6) = newDR.Item("items").ToString

                Dim lvl As New ListViewItem(a)
                If lvlSearchCharges.InvokeRequired Then
                    lvlSearchCharges.Invoke(Sub() lvlSearchCharges.Items.Add(lvl))
                Else
                    lvlSearchCharges.Items.Add(lvl)
                End If

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        counter = 0

        GroupBox1.Enabled = False
        lvlSearchCharges.Enabled = False

        If pub_search_by_charges = 1 Then
            load_rs_charges()
        ElseIf pub_search_by_charges = 2 Then
            load_ws_charges()
            'load_ws_charges2()
        ElseIf pub_search_by_charges = 3 Then
            load_rs_charges()
        End If



    End Sub
    Private Sub load_ws_charges()
        FWithdrawalList.ListBox1.Items.Clear()
        FWithdrawalList.ws_id_count = 0

        For Each row As ListViewItem In lvlSearchCharges.Items
            If row.Checked = True Then
                FWithdrawalList.ListBox1.Items.Add(row.SubItems(4).Text)
            End If
        Next

        FWithdrawalList.ws_id_count = FWithdrawalList.ListBox1.Items.Count
        FWithdrawalList.search1()
    End Sub

    Private Sub load_ws_charges2()
        Panel3.Visible = True

        Dim count As Integer

        For Each row As ListViewItem In lvlSearchCharges.Items
            If row.Checked = True Then
                count += 1
            End If
        Next

        ProgressBar1.Maximum = count

        For Each row As ListViewItem In lvlSearchCharges.Items
            If row.Checked = True Then
                Dim cw As New class_withdrawal
                cw.ws_id = row.SubItems(4).Text

                trd2 = New Threading.Thread(AddressOf cw._initialize)
                trd2.Start()
                trd2.Join()

                ListOfWsClass.Add(cw)
                ProgressBar1.Value += 1
                'ListOfThreading.Add(trd2)
            End If
        Next

        'For Each thread In ListOfThreading
        '    thread.Start()
        '    thread.Join()
        'Next
        Dim LofLvlItem As New List(Of ListViewItem)

        For Each ws In ListOfWsClass
            Dim list = ws.cListOfWithdrawal
            If ws.done = True Then
                For Each row In list
                    Dim a(22) As String
                    a(0) = row.ws_id
                    a(1) = row.ws_no
                    a(2) = row.rs_no
                    a(3) = row.date_withdrawn
                    a(4) = row.item_name
                    a(5) = row.qty
                    a(6) = row.unit
                    a(7) = row.unit_price
                    a(8) = row.amount
                    a(9) = row.item_desc
                    a(10) = row.warehouse_area
                    a(11) = row.withdrawn_by
                    a(12) = row.released_by
                    a(13) = row.status
                    a(14) = row.charges
                    a(15) = row.ws_info_id
                    a(16) = row.rs_id
                    a(18) = row.wh_id
                    a(19) = row.remarks
                    a(20) = row.dr_option
                    a(21) = row.purpose

                    Dim lvl As New ListViewItem(a)
                    LofLvlItem.Add(lvl)
                Next
            Else
                ListBox1.Items.Add(ws.ws_id)
            End If
        Next

        FWithdrawalList.lvlwithdrawalList.Items.AddRange(LofLvlItem.ToArray)
        Me.Dispose()

    End Sub
    Private Sub load_rs_charges()
        FRequistionForm.lvlrequisitionlist.Items.Clear()
        FRequistionForm.ListBox1.Items.Clear()


        If cmbGenerateProject.Text = "Generate by RS No." Or cmbGenerateProject.Text = "Generate by DR No." Or cmbGenerateProject.Text = "Generate by WS No." Then
            load_search_by_charges_hauling_and_crushing(txtChargesSearch.Text, "", 0)
            Exit Sub
        End If

        For Each row As ListViewItem In lvlSearchCharges.Items
            If row.Checked = True Then
                If FRequistionForm.cmbDivision.Text = "WAREHOUSING AND SUPPLY" Then
                    'load_search_by_charges_warehousing(row.Text, row.SubItems(1).Text, row.SubItems(3).Text)
                    With FRequistionForm
                        .ListBox1.Items.Add(row.SubItems(4).Text)
                    End With
                Else
                    'load_search_by_charges_hauling_and_crushing(row.Text, row.SubItems(1).Text, row.SubItems(3).Text)
                    With FRequistionForm
                        '.load_rs_rs_id(4, row.Text, "")
                        '.load_main_qty(row.Text)
                        .ListBox1.Items.Add(row.SubItems(4).Text)
                        '.thread = New System.Threading.Thread(AddressOf .search_using_rs)
                        '.thread.Start()
                    End With

                End If
            End If
        Next

        If FRequistionForm.cmbDivision.Text = "WAREHOUSING AND SUPPLY" Then
            'Me.Hide()

            FRequistionForm.cmbProject.Location = New Point(100000, 10000)
            FRequistionForm.Button2.Location = New Point(100000, 10000)
            FRequistionForm.Button4.Location = New Point(100000, 10000)
            FRequistionForm.ListBox1.Location = New Point(100000, 10000)
            FRequistionForm.lblRecords.Text = FRequistionForm.ListBox1.Items.Count.ToString("N0") & " record(s) found..."

            FRequistionForm.lvlrequisitionlist.Visible = False
            FRequistionForm.rs_id_count = FRequistionForm.ListBox1.Items.Count
            FRequistionForm.FlowLayoutPanel1.Enabled = False
            thread = New System.Threading.Thread(AddressOf FRequistionForm.search_using_rs1)
            thread.Start()
            Timer3.Start()
            FRequistionForm.Label7.Text = "waiting..."
        Else
            'Me.Hide()

            FRequistionForm.cmbProject.Location = New Point(100000, 10000)
            FRequistionForm.Button2.Location = New Point(100000, 10000)
            FRequistionForm.Button4.Location = New Point(100000, 10000)
            FRequistionForm.ListBox1.Location = New Point(100000, 10000)
            FRequistionForm.lblRecords.Text = FRequistionForm.ListBox1.Items.Count.ToString("N0") & " record(s) found..."

            FRequistionForm.lvlrequisitionlist.Visible = False
            FRequistionForm.rs_id_count = FRequistionForm.ListBox1.Items.Count

            FRequistionForm.FlowLayoutPanel1.Enabled = False
            thread = New System.Threading.Thread(AddressOf FRequistionForm.search_using_rs)
            thread.Start()
            Timer3.Start()
            FRequistionForm.Label7.Text = "waiting..."
        End If

    End Sub
    Private Sub load_search_by_charges_warehousing(rs_no As String, itemdesc As String, wh_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        With FRequistionForm

            ' Dim counter As Integer = 0

            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_requisition_slip", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 42)
                newCMD.Parameters.AddWithValue("@searchby", "Search by RS.No.")
                newCMD.Parameters.AddWithValue("@rs_no", rs_no)
                newCMD.Parameters.AddWithValue("@search", rs_no)
                newCMD.Parameters.AddWithValue("@itemname", itemdesc)
                newCMD.Parameters.AddWithValue("@wh_id", wh_id)

                'newCMD.Parameters.AddWithValue("@category", .cmbSearchByCategory.Text)
                'newCMD.Parameters.AddWithValue("@inout", .cmbInOut.Text)
                'newCMD.Parameters.AddWithValue("@range1", range1)
                'newCMD.Parameters.AddWithValue("@range2", range2)


                'newCMD.Parameters.AddWithValue("@search", search)
                'newCMD.Parameters.AddWithValue("@itemname", .txtItemName.Text)

                newCMD.CommandTimeout = 300

                newDR = newCMD.ExecuteReader

                Dim a(40) As String
                Dim dat_req, date_needed As DateTime
                Dim pocv_status, rr_status, ws_status As String

                While newDR.Read

                    a(0) = newDR.Item("rs_id").ToString

                    If newDR.Item("date_req").ToString = "" Or newDR.Item("date_req").ToString = "-" Then
                        dat_req = "1990-01-01"
                    Else
                        dat_req = newDR.Item("date_req").ToString
                    End If

                    a(2) = Format(Date.Parse(dat_req), "MM/dd/yyyy")
                    a(3) = newDR.Item("job_order_no").ToString
                    a(6) = newDR.Item("unit").ToString

                    Select Case newDR.Item("sorting").ToString
                        Case "A"

                            If newDR.Item("date_needed").ToString = "" Or newDR.Item("date_needed").ToString = "-" Then
                                date_needed = "1990-01-01"
                            Else
                                date_needed = newDR.Item("date_needed").ToString
                            End If

                            a(1) = newDR.Item("rs_no").ToString
                            a(4) = newDR.Item("items").ToString
                            a(5) = newDR.Item("qty").ToString
                            a(7) = Format(Date.Parse(date_needed), "MM/dd/yyyy")
                            a(8) = newDR.Item("type_of_request").ToString
                            a(13) = newDR.Item("charges").ToString
                            a(14) = newDR.Item("location").ToString
                            a(15) = newDR.Item("wh_id").ToString
                            a(16) = newDR.Item("date_log").ToString
                            a(17) = newDR.Item("type_of_charges").ToString
                            a(18) = newDR.Item("type_of_purchasing").ToString
                            a(19) = newDR.Item("remarks").ToString
                            a(21) = 0
                            a(22) = newDR.Item("po_cv_ws_released").ToString
                            a(23) = newDR.Item("rr_qty_received").ToString
                            a(24) = newDR.Item("username").ToString
                            a(25) = newDR.Item("ws_id").ToString
                            a(28) = newDR.Item("requested_by").ToString
                            a(29) = newDR.Item("cons_item").ToString
                            a(30) = newDR.Item("cons_item_desc").ToString
                            a(31) = newDR.Item("type_of_delivery").ToString
                            a(32) = 0
                            a(33) = newDR.Item("wh_area").ToString
                            a(35) = newDR.Item("rr_item_id").ToString
                            a(36) = "-"

                            Dim rs_qty As Double = CDbl(a(5))
                            Dim po_qty As Double = CDbl(IIf(a(22) = "", 0, a(22)))
                            Dim ws_rr_qty As Double = CDbl(IIf(a(23) = "", 0, a(23)))

                            Select Case newDR.Item("IN_OUT").ToString
                                Case "In"

                                    If po_qty < rs_qty Then
                                        If po_qty = 0 Then
                                            pocv_status = "PENDING"
                                        Else
                                            pocv_status = "PO/CV PARTIALLY RELEASED"
                                        End If

                                    ElseIf po_qty = rs_qty Then
                                        pocv_status = "PO/CV RELEASED"
                                    End If

                                    If ws_rr_qty < po_qty Then
                                        If ws_rr_qty = 0 Then
                                            rr_status = "PENDING"
                                        Else
                                            rr_status = "PARTIALLY RECEIVED"
                                        End If

                                    ElseIf ws_rr_qty = po_qty Then
                                        If ws_rr_qty = 0 Then
                                            rr_status = "PENDING"
                                        Else
                                            rr_status = "RECEIVED"
                                        End If
                                    End If

                                    'if wala pay po og rr nya na item check na
                                    If ws_rr_qty = 0 And po_qty = 0 Then
                                        pocv_status = "PENDING"
                                        rr_status = "PENDING"
                                    End If

                                    ws_status = "N/A"
                                Case "OTHERS"
                                    If po_qty < rs_qty Then
                                        pocv_status = "PO/CV PARTIALLY RELEASED"
                                    ElseIf po_qty = rs_qty Then
                                        pocv_status = "PO/CV RELEASED"
                                    End If

                                    If ws_rr_qty < po_qty Then
                                        If ws_rr_qty = 0 Then
                                            rr_status = "PENDING"
                                        Else
                                            rr_status = "PARTIALLY RECEIVED"
                                        End If
                                    ElseIf ws_rr_qty = po_qty Then
                                        rr_status = "RECEIVED"
                                    End If

                                    'if wala pay po og rr nya na item check na
                                    If ws_rr_qty = 0 And po_qty = 0 Then
                                        pocv_status = "PENDING"
                                        rr_status = "PENDING"
                                    End If

                                    ws_status = "N/A"
                                Case "OUT"
                                    If ws_rr_qty < po_qty Then
                                        ws_status = "PARTIALLY WITHDRAWN"
                                    ElseIf rs_qty > ws_rr_qty And ws_rr_qty > 0 Then
                                        ws_status = "PARTIALLY WITHDRAWN"
                                    ElseIf ws_rr_qty = po_qty Then
                                        ws_status = "WITHDRAWN"
                                    End If

                                    'if wala pay po og rr nya na item check na
                                    If ws_rr_qty = 0 And po_qty = 0 Then
                                        ws_status = "PENDING"
                                    End If

                                    pocv_status = "N/A"
                                    rr_status = "N/A"
                            End Select

                            '
                            If a(15) = 0 Then 'wala pa na item check
                                a(10) = "WAITING..."
                                a(11) = "WAITING..."
                                a(12) = "WAITING..."
                            Else
                                a(10) = pocv_status
                                a(11) = rr_status
                                a(12) = ws_status
                            End If

                        Case "B"
                            a(1) = "-"
                            a(4) = ChrW(187) & " " & newDR.Item("items").ToString
                            a(5) = "-"
                            a(13) = "-"

                            If newDR.Item("IN_OUT").ToString = "In" Or newDR.Item("IN_OUT").ToString = "OTHERS" Then
                                a(7) = "-"
                                a(8) = newDR.Item("type_of_request").ToString
                                a(10) = "- released"
                                a(11) = "-"
                                a(12) = "-"
                                a(17) = newDR.Item("type_of_charges").ToString
                                a(18) = newDR.Item("type_of_purchasing").ToString
                                a(19) = newDR.Item("remarks").ToString
                                a(22) = newDR.Item("qty").ToString
                                a(23) = "-"
                                a(24) = newDR.Item("username").ToString
                                a(25) = newDR.Item("ws_id").ToString
                                a(28) = newDR.Item("requested_by").ToString
                                a(29) = newDR.Item("cons_item").ToString
                                a(31) = newDR.Item("type_of_delivery").ToString
                                a(33) = newDR.Item("wh_area").ToString
                                a(35) = newDR.Item("rr_item_id").ToString
                            Else
                                a(7) = "-"
                                a(10) = "-"
                                a(11) = "-"

                                If newDR.Item("withdrawn").ToString = "" Then
                                    a(12) = "WITHDRAWAL RELEASED"
                                Else
                                    a(12) = "WITHDRAWN"
                                End If

                                a(8) = newDR.Item("type_of_request").ToString
                                a(17) = newDR.Item("type_of_charges").ToString
                                a(18) = newDR.Item("type_of_purchasing").ToString
                                a(19) = newDR.Item("remarks").ToString
                                a(22) = "-"
                                a(23) = newDR.Item("qty").ToString
                                a(24) = newDR.Item("username").ToString
                                a(25) = newDR.Item("ws_id").ToString
                                a(28) = newDR.Item("requested_by").ToString
                                a(29) = newDR.Item("cons_item").ToString
                                a(31) = newDR.Item("type_of_delivery").ToString
                                a(33) = newDR.Item("wh_area").ToString
                                a(35) = newDR.Item("rr_item_id").ToString
                            End If

                            a(36) = newDR.Item("po_no").ToString

                        Case "C"
                            a(1) = "-"
                            a(4) = "      " & ChrW(155) & " " & newDR.Item("items").ToString
                            a(5) = "-"
                            a(8) = newDR.Item("type_of_request").ToString
                            a(10) = "-"
                            a(11) = "- received"
                            a(12) = "N/A"
                            a(17) = newDR.Item("type_of_charges").ToString
                            a(18) = newDR.Item("type_of_purchasing").ToString
                            a(19) = newDR.Item("remarks").ToString
                            a(22) = "-"
                            a(23) = newDR.Item("qty").ToString
                            a(24) = newDR.Item("username").ToString
                            a(25) = newDR.Item("ws_id").ToString
                            a(28) = newDR.Item("requested_by").ToString
                            a(29) = newDR.Item("cons_item").ToString
                            a(31) = newDR.Item("type_of_delivery").ToString
                            a(33) = newDR.Item("wh_area").ToString
                            a(35) = newDR.Item("rr_item_id").ToString
                            a(36) = newDR.Item("rr_no").ToString

                    End Select

                    a(9) = newDR.Item("IN_OUT").ToString
                    a(37) = newDR.Item("qto_items").ToString
                    a(38) = newDR.Item("qto_id").ToString

                    Dim lvl As New ListViewItem(a)
                    .lvlrequisitionlist.Items.Add(lvl)

                    If newDR.Item("sorting").ToString = "A" Then
                        .lvlrequisitionlist.Items(counter).BackColor = Color.DarkGreen
                        .lvlrequisitionlist.Items(counter).ForeColor = Color.White
                        .lvlrequisitionlist.Items(counter).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Bold)
                    ElseIf newDR.Item("sorting").ToString = "B" Then
                        .lvlrequisitionlist.Items(counter).BackColor = Color.LightGreen
                        .lvlrequisitionlist.Items(counter).Font = New Font(New FontFamily("Arial"), 9, FontStyle.Bold)
                    ElseIf newDR.Item("sorting").ToString = "C" Then
                        .lvlrequisitionlist.Items(counter).BackColor = Color.LightYellow
                        .lvlrequisitionlist.Items(counter).Font = New Font(New FontFamily("Arial"), 8, FontStyle.Bold)
                        'lvlrequisitionlist.Items(counter).Font.Size = "11pt"
                    End If

                    counter += 1
                    Application.DoEvents()

                End While

                newDR.Close()

            Catch ex As Exception
                MessageBox.Show("Error MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try
        End With
    End Sub
    Private Sub load_dr(rs_no As String, itemdesc As String, wh_id As Integer, project As String)

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        With FDRLIST
            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_Aggregates_Search_by_Charges", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure
                newCMD.Parameters.AddWithValue("@n", 41)

                newCMD.Parameters.AddWithValue("@wh_id", wh_id)
                newCMD.Parameters.AddWithValue("@rs_no", rs_no)
                newCMD.Parameters.AddWithValue("@itemname", itemdesc)
                newCMD.Parameters.AddWithValue("@search", rs_no)

                newCMD.Parameters.AddWithValue("@datefrom", Date.Parse(dtpdatefrom.Text))
                newCMD.Parameters.AddWithValue("@dateto", Date.Parse(dtpdateto.Text))

                newCMD.CommandTimeout = 300
                newDR = newCMD.ExecuteReader

                Dim a(40) As String

                While newDR.Read

                    If newDR.Item("dr_option").ToString = "" Or newDR.Item("dr_option").ToString = "WITH DR" Then
                        GoTo proceedhere
                    Else

                    End If
                    If newDR.Item("date_request").ToString = "" Then
                    Else
                        a(3) = Format(Date.Parse(newDR.Item("date_request").ToString), "MM/dd/yyyy")
                    End If

                    If newDR.Item("date_request").ToString = "" Then
                    Else
                        a(3) = Format(Date.Parse(newDR.Item("date_request").ToString), "MM/dd/yyyy")
                    End If

                    a(0) = newDR.Item("dr_id").ToString
                    a(1) = newDR.Item("dr_no").ToString
                    a(2) = newDR.Item("rs_no").ToString
                    a(4) = newDR.Item("whItem").ToString 'newDR.Item("ITEM_DESC").ToString
                    a(5) = newDR.Item("SUPP_SOURCE").ToString
                    a(6) = newDR.Item("rs_qty").ToString
                    a(7) = newDR.Item("unit").ToString
                    a(8) = newDR.Item("conssession_ticket").ToString
                    a(9) = newDR.Item("operator").ToString
                    a(10) = project 'newDR.Item("charges").ToString
                    a(12) = newDR.Item("checked_by").ToString
                    a(13) = newDR.Item("received_by").ToString
                    a(14) = newDR.Item("dr_info_id").ToString
                    a(15) = newDR.Item("rs_id").ToString
                    a(16) = newDR.Item("IN_OUT").ToString
                    a(19) = IIf(newDR.Item("IN_OUT").ToString = "OTHERS", "Unavailable this time...", newDR.Item("ws_no").ToString)
                    a(20) = newDR.Item("par_rr_item_id").ToString
                    a(21) = newDR.Item("remarks").ToString
                    a(22) = newDR.Item("SUPPLIER").ToString
                    a(23) = newDR.Item("username").ToString
                    a(24) = newDR.Item("plate_no").ToString
                    a(25) = newDR.Item("RR_NO").ToString
                    a(27) = newDR.Item("price").ToString
                    a(28) = newDR.Item("total_amount").ToString
                    a(29) = newDR.Item("whItemDesc").ToString
                    a(30) = newDR.Item("date_request").ToString

                    If newDR.Item("IN_OUT").ToString = "OUT" Then
                        a(6) = 0
                        a(26) = newDR.Item("OUT_DR_QTY").ToString
                    Else
                        a(6) = newDR.Item("IN_OTHERS_DR_QTY").ToString
                        a(26) = 0
                    End If

                    Dim lvl As New ListViewItem(a)
                    .lvl_drList.Items.Add(lvl)

                    counter += 1
proceedhere:
                End While

                newDR.Close()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try
        End With

    End Sub
    Private Sub load_search_by_charges_hauling_and_crushing(rs_no As String, itemdesc As String, wh_id As Integer)

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        With FRequistionForm
            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure



                'para sa generate by RS NO lng ni
                If cmbGenerateProject.Text = "Generate by RS No." Then
                    newCMD.Parameters.AddWithValue("@searchby", "Generate by RS No.")
                    newCMD.Parameters.AddWithValue("@n", 37)
                    newCMD.Parameters.AddWithValue("@rs_no", rs_no)
                    newCMD.Parameters.AddWithValue("@search", rs_no)
                    newCMD.Parameters.AddWithValue("@iem_desc", itemdesc)
                    newCMD.Parameters.AddWithValue("@wh_id", wh_id)

                    GoTo GOHERE
                ElseIf cmbGenerateProject.Text = "Generate by DR No." Then
                    newCMD.Parameters.AddWithValue("@searchby", "Generate by DR No.")
                    newCMD.Parameters.AddWithValue("@n", 37)
                    newCMD.Parameters.AddWithValue("@rs_no", rs_no)
                    newCMD.Parameters.AddWithValue("@search", rs_no)
                    newCMD.Parameters.AddWithValue("@iem_desc", itemdesc)
                    newCMD.Parameters.AddWithValue("@wh_id", wh_id)
                    GoTo GOHERE
                ElseIf cmbGenerateProject.Text = "Generate by WS No." Then
                    newCMD.Parameters.AddWithValue("@searchby", "Generate by WS No.")
                    newCMD.Parameters.AddWithValue("@n", 37)
                    newCMD.Parameters.AddWithValue("@rs_no", rs_no)
                    newCMD.Parameters.AddWithValue("@search", rs_no)
                    newCMD.Parameters.AddWithValue("@iem_desc", itemdesc)
                    newCMD.Parameters.AddWithValue("@wh_id", wh_id)
                    GoTo GOHERE
                End If

                'diri nga part para sa search by RS gkan RS FORM
                newCMD.Parameters.AddWithValue("@searchby", "Search by RS.No.")
                newCMD.Parameters.AddWithValue("@n", 33)

                newCMD.Parameters.AddWithValue("@rs_no", rs_no)
                newCMD.Parameters.AddWithValue("@search", rs_no)
                newCMD.Parameters.AddWithValue("@iem_desc", itemdesc)
                newCMD.Parameters.AddWithValue("@wh_id", wh_id)


GOHERE:

                'newCMD.CommandTimeout = 300
                newDR = newCMD.ExecuteReader

                Dim a(43) As String

                While newDR.Read

                    If newDR.Item("division").ToString = "WAREHOUSING AND SUPPLY" Then
                        GoTo proceedhere
                    End If

                    If newDR.Item("mother_rs").ToString = "A1" And newDR.Item("IN_OUT").ToString = "IN" Then
                        GoTo proceedhere
                    End If

                    a(0) = newDR.Item("rs_id").ToString
                    a(1) = newDR.Item("rs_no").ToString

                    If newDR.Item("date_request").ToString = "" Then
                    Else
                        a(2) = Format(Date.Parse(newDR.Item("date_request").ToString), "MM/dd/yyyy")
                    End If

                    a(3) = newDR.Item("job_order_no").ToString
                    a(4) = newDR.Item("ITEM_DESC").ToString
                    a(5) = newDR.Item("rs_qty").ToString
                    a(6) = newDR.Item("unit").ToString
                    a(7) = IIf(Format(Date.Parse(newDR.Item("date_needed").ToString), "MM/dd/yyyy") = "01/01/1900", "", Format(Date.Parse(newDR.Item("date_needed").ToString), "MM/dd/yyyy"))
                    a(8) = newDR.Item("type_of_request").ToString
                    a(9) = newDR.Item("IN_OUT").ToString
                    a(10) = newDR.Item("po_status").ToString
                    a(11) = ""
                    a(12) = newDR.Item("ws_status").ToString
                    a(13) = newDR.Item("charges").ToString
                    a(14) = newDR.Item("location").ToString
                    a(15) = newDR.Item("wh_id").ToString
                    a(16) = newDR.Item("date_log").ToString
                    a(17) = newDR.Item("type_of_charges").ToString
                    a(18) = newDR.Item("type_of_purchasing").ToString
                    a(19) = newDR.Item("remarks").ToString
                    a(20) = ""
                    a(21) = newDR.Item("dr_no").ToString

                    If newDR.Item("mother_rs").ToString = "A" And newDR.Item("IN_OUT").ToString = "IN" Then
                        a(22) = newDR.Item("M_po_ws_released").ToString
                    Else
                        a(22) = newDR.Item("po_ws_qty_released").ToString
                    End If

                    If newDR.Item("mother_rs").ToString = "A" And newDR.Item("IN_OUT").ToString = "IN" Then
                        a(23) = newDR.Item("M_rr_ws_received").ToString
                    Else
                        a(23) = newDR.Item("rr_ws_qty_received").ToString
                    End If

                    a(24) = newDR.Item("users").ToString
                    a(25) = newDR.Item("ws_id_dr_id").ToString
                    a(26) = ""
                    a(27) = ""
                    a(28) = newDR.Item("requested_by").ToString
                    a(29) = newDR.Item("cons_item").ToString
                    a(30) = newDR.Item("cons_item_desc").ToString
                    a(31) = newDR.Item("type_of_delivery").ToString

                    If newDR.Item("IN_OUT").ToString = "OUT" Then
                        If newDR.Item("mother_rs").ToString = "A1" Then
                            a(23) = newDR.Item("OUT_DR_QTY").ToString

                            If newDR.Item("ws_dr_in_qty").ToString = "" Then
                                a(32) = newDR.Item("ws_dr_out_qty").ToString
                            Else
                                a(32) = newDR.Item("ws_dr_out_qty").ToString & "/" & newDR.Item("ws_dr_in_qty").ToString
                            End If

                        ElseIf newDR.Item("mother_rs").ToString = "A" Then
                            a(32) = 0
                        Else
                            a(32) = newDR.Item("OUT_DR_QTY").ToString
                        End If

                    Else
                        a(32) = newDR.Item("IN_OTHERS_DR_QTY").ToString
                    End If

                    a(33) = newDR.Item("wh_area").ToString
                    a(34) = 0
                    a(35) = 0
                    a(36) = newDR.Item("ws_no").ToString
                    a(39) = newDR.Item("temp_col_item_name").ToString
                    a(40) = newDR.Item("charges").ToString
                    a(41) = newDR.Item("dr_option").ToString
                    a(42) = newDR.Item("dr_items_id").ToString

                    Dim lvl As New ListViewItem(a)
                    .lvlrequisitionlist.Items.Add(lvl)

                    If newDR.Item("mother_rs").ToString = "A" Then
                        .lvlrequisitionlist.Items(counter).BackColor = Color.DarkGreen
                        .lvlrequisitionlist.Items(counter).ForeColor = Color.White
                        .lvlrequisitionlist.Items(counter).Font = New Font(New FontFamily("Arial"), 10, FontStyle.Bold)
                    ElseIf newDR.Item("mother_rs").ToString = "A1" Then
                        .lvlrequisitionlist.Items(counter).BackColor = Color.LightGreen
                        .lvlrequisitionlist.Items(counter).Font = New Font(New FontFamily("Arial"), 10, FontStyle.Bold)
                    ElseIf newDR.Item("mother_rs").ToString = "A2" Then
                        .lvlrequisitionlist.Items(counter).BackColor = Color.LightYellow
                        'lvlrequisitionlist.Items(counter).Font.Size = "11pt"
                    End If

                    counter += 1

proceedhere:
                    Application.DoEvents()

                End While

                newDR.Close()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try
        End With

    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        For Each row As ListViewItem In lvlSearchCharges.Items
            row.Checked = True
        Next
    End Sub

    Private Sub UnselectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnselectAllToolStripMenuItem.Click
        For Each row As ListViewItem In lvlSearchCharges.Items
            row.Checked = False
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'If cmbGenerateProject.Text = "Generate by All Project" Then
        '    For Each items As String In cmbProject.Items
        '        search_by_charges1(items, "Generate by All Project")

        '        For Each row As ListViewItem In lvlSearchCharges.Items
        '            If row.SubItems(3).Text = 0 Then
        '            Else
        '                row.Checked = True
        '            End If

        '        Next

        '        Button1.PerformClick()
        '        Button3.PerformClick()

        '        Label1.Text = items & " " & "Loading..."

        '    Next

        'ElseIf cmbGenerateProject.Text = "Generate by Specific project" Then
        '    search_by_charges1(cmbProject.Text, "Generate by Specific project")
        '    For Each row As ListViewItem In lvlSearchCharges.Items
        '        If row.SubItems(3).Text = 0 Then
        '        Else
        '            row.Checked = True
        '        End If

        '    Next

        '    Button1.PerformClick()
        '    Button3.PerformClick()

        '    Label1.Text = cmbProject.Text & " " & "Loading..."

        'ElseIf cmbGenerateProject.Text = "Generate by RS No." Or cmbGenerateProject.Text = "Generate by DR No." Or cmbGenerateProject.Text = "Generate by WS No." Then

        '    Button1.PerformClick()
        '    Button3.PerformClick()

        '    Label1.Text = txtChargesSearch.Text & " " & "Loading..."

        'End If

        'warehouse_charges()
        If pub_search_by_charges = 1 Then
            rs_search()
        ElseIf pub_search_by_charges = 2 Then
            'ws_search()
            ws_search2()

        ElseIf pub_search_by_charges = 3 Then
            rs_search_type_of_request()
        End If

    End Sub
    Private Sub rs_search()

        Label7.Visible = False

        With crs_data

            .charges = cmbProject1.Text
            .items = txtItemSearch.Text
            .date_from = Date.Parse(dtpdatefrom.Text)
            .date_to = Date.Parse(dtpdateto.Text)
            .lbox = ListBox1
            .lview = lvlSearchCharges
            .progressbar = ProgressBar1
            .searchby = FRequistionForm.cmbSearchByCategory.Text
            .options = FRequistionForm.cmbDivision.Text
            .lbl = Label7

            If cmbByDate.Text = "BY DATE RANGE" Then
                .bydaterange = True
            ElseIf cmbByDate.Text = "BY SPECIFIC REQUESTOR" Then
                .bydaterange = True
            Else
                .bydaterange = False
            End If
        End With

        ProgressBar1.Value = 0
        Dim c_search As New Class_Search_Charges(crs_data)

        Panel3.Visible = True

        If FRequistionForm.cmbDivision.Text = "WAREHOUSING AND SUPPLY" Then
            c_search.specific_requestor = True

            thread = New Threading.Thread(AddressOf c_search.load_charges_to_listbox)
        Else
            thread = New Threading.Thread(AddressOf c_search.load_charges_to_listbox_hauling)
            'thread = New Threading.Thread(AddressOf c_search.load_charges_to_listbox)
        End If
        thread.Start()
        timer_thread.Start()

    End Sub

    Private Sub ws_search()
        Label7.Visible = False

        With crs_data

            .charges = cmbProject1.Text
            .items = txtItemSearch.Text
            .date_from = Date.Parse(dtpdatefrom.Text)
            .date_to = Date.Parse(dtpdateto.Text)
            .lbox = ListBox1
            .lview = lvlSearchCharges
            .progressbar = ProgressBar1
            .searchby = FRequistionForm.cmbSearchByCategory.Text
            .options = FRequistionForm.cmbDivision.Text
            .lbl = Label7

            If cmbByDate.Text = "BY DATE RANGE" Then
                .bydaterange = True
            Else
                .bydaterange = False
            End If
        End With

        ProgressBar1.Value = 0
        Dim c_search As New Class_Search_Charges(crs_data)

        Panel3.Visible = True

        thread = New Threading.Thread(AddressOf c_search.ws_charges)
        thread.Start()
        timer_thread2.Start()

    End Sub

    Private Sub ws_search2()
        lvlSearchCharges.Items.Clear()
        ProgressBar1.Value = 0
        ProgressBar1.Style = ProgressBarStyle.Marquee
        charges.cListOfWsCharges.Clear()
        ListOfLview.Clear()

        charges.charges_desc = cmbProject1.Text
        charges.items = txtItemSearch.Text
        charges.bydate = cmbByDate.Text
        charges.datefrom = Date.Parse(dtpdatefrom.Text)
        charges.dateto = Date.Parse(dtpdateto.Text)

        charges.division = "WAREHOUSING AND SUPPLY"

        BackgroundWorker1.RunWorkerAsync()
        Threading.Thread.Sleep(500)
        BackgroundWorker2.RunWorkerAsync()

    End Sub
    Private Sub rs_search_type_of_request()

        Label7.Visible = False

        With crs_data

            .charges = cmbProject1.Text
            .items = txtItemSearch.Text
            .date_from = Date.Parse(dtpdatefrom.Text)
            .date_to = Date.Parse(dtpdateto.Text)
            .lbox = ListBox1
            .lview = lvlSearchCharges
            .progressbar = ProgressBar1
            .searchby = FRequistionForm.cmbSearchByCategory.Text
            .options = FRequistionForm.cmbDivision.Text
            .lbl = Label7
            .type_of_purchasing = FRequistionForm.txtSearch.Text

            If cmbByDate.Text = "BY DATE RANGE" Then
                .bydaterange = True
            Else
                .bydaterange = False
            End If
        End With

        ProgressBar1.Value = 0
        Dim c_search As New Class_Search_Charges(crs_data)
        Panel3.Visible = True

        thread = New Threading.Thread(AddressOf c_search.load_type_of_request_to_listbox)

        thread.Start()
        timer_thread4.Start()

    End Sub
    Private Sub warehouse_charges()
        'thread1 = New System.Threading.Thread(AddressOf panel_loading)
        'thread1.Start()

        lvlSearchCharges.Items.Clear()

        thread = New System.Threading.Thread(AddressOf load_the_charges)
        thread.Start()

        btnEndProcess.Visible = True
        Timer1.Start()
    End Sub

    Private Sub panel_loading()
        If Panel3.InvokeRequired Then
            Panel3.Invoke(Sub()
                              lvlSearchCharges.Visible = False
                              Panel3.Visible = True

                              load_rs_id_first_for_charges(cmbProject1.Text, txtItemSearch.Text)
                          End Sub)
        Else
            lvlSearchCharges.Visible = False
            Panel3.Visible = True

            load_rs_id_first_for_charges(cmbProject1.Text, txtItemSearch.Text)
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        'Dim searchcategory As String = cmbGenerateProject.Text

        'With FRequistionForm
        '    For Each row As ListViewItem In .lvlrequisitionlist.Items

        '        Select Case searchcategory
        '            Case "Generate by All Project", "Generate by Specific project"

        '                If Date.Parse(row.SubItems(2).Text).Month & "/" & Date.Parse(row.SubItems(2).Text).Year =
        '                Date.Parse(dtpdatefrom.Text).Month & "/" & Date.Parse(dtpdatefrom.Text).Year Then

        '                    If row.SubItems(41).Text = "" Or row.SubItems(41).Text = "WITH DR" Then
        '                    Else
        '                        .load_dr(row.SubItems(41).Text, row.SubItems(42).Text)
        '                    End If
        '                End If

        '            Case "Generate by RS No.", "Generate by DR No.", "Generate by WS No."

        '                If row.SubItems(41).Text = "" Or row.SubItems(41).Text = "WITH DR" Then
        '                Else
        '                    .load_dr(row.SubItems(41).Text, row.SubItems(42).Text)
        '                End If
        '        End Select
        '    Next
        'End With

        'FDRLIST.Show()

        load_to_drList()

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub cmbGenerateProject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGenerateProject.SelectedIndexChanged
        Select Case cmbGenerateProject.Text
            Case "Generate by All Project"

                cmbProject.Enabled = False
                txtItemSearch.Enabled = True
                txtChargesSearch.Enabled = False
                'dtpdatefrom.Enabled = False

            Case "Generate by RS No.", "Generate by DR No.", "Generate by WS No."

                cmbProject.Enabled = False
                txtItemSearch.Enabled = False
                txtChargesSearch.Enabled = True
                dtpdatefrom.Enabled = False

                Button1.Enabled = True
                Button2.Enabled = True

            Case "Generate by Specific project"

                cmbProject.Enabled = True
                txtItemSearch.Enabled = True
                txtChargesSearch.Enabled = False
                dtpdatefrom.Enabled = True

                Button1.Enabled = True
                Button2.Enabled = True

                FDRLIST.load_requestor(cmbProject, 14)

        End Select
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        FRequistionForm.lvlrequisitionlist.Items.Clear()

        'If cmbGenerateProject.Text = "Generate by All Project" Then
        '    For Each proj As String In cmbProject.Items
        '        'Dim proj As String = cmbProject.Text

        '        If countThis(proj) > 0 Then
        '            FRequistionForm.lvlrequisitionlist.Items.Clear()

        '            'If proj = "20-02 FCFAD" Then
        '            '    MsgBox(proj)
        '            'End If

        '            Label1.Text = proj & " " & "Loading..."

        '            summary_charges(proj, txtItemSearch.Text)
        '            load_to_drList()
        '            'Button3.PerformClick()
        '            counter = 0
        '        Else
        '            FRequistionForm.lvlrequisitionlist.Items.Clear()

        '            'MsgBox(proj)
        '            counter = 0
        '        End If
        '    Next

        'ElseIf cmbGenerateProject.Text = "Generate by Specific project" Then

        '    FRequistionForm.lvlrequisitionlist.Items.Clear()

        '    If Application.OpenForms().OfType(Of FDRLIST).Any Then
        '        ' MessageBox.Show("Opened")
        '        FDRLIST.lvl_drList.Items.Clear()
        '    Else
        '        'Dim f2 As New Form2
        '        'f2.Text = "form2"
        '        'f2.Show()
        '    End If

        '    If countThis(cmbProject.Text) > 0 Then

        '        Label1.Text = cmbProject.Text & " " & "Loading..."
        '        summary_charges(cmbProject.Text, txtItemSearch.Text)
        '        load_to_drList()
        '        counter = 0
        '    Else
        '        'MsgBox(proj)
        '        counter = 0
        '    End If
        'End If

        With FRequistionForm

            '.cmbProject.Location = New Point(100000, 10000)
            '.Button2.Location = New Point(100000, 10000)
            '.Button4.Location = New Point(100000, 10000)
            '.ListBox1.Location = New Point(100000, 10000)

            .Button8.PerformClick()
            .Label7.Text = cmbProject.Text
        End With


        Me.Hide()


    End Sub
    Public Sub load_to_drList()
        Dim searchcategory As String = cmbGenerateProject.Text

        With FRequistionForm
            For Each row As ListViewItem In .lvlrequisitionlist.Items

                .load_dr(row.SubItems(41).Text, row.SubItems(42).Text)

                'Select Case searchcategory
                '    Case "Generate by All Project", "Generate by Specific project"

                '        If Date.Parse(row.SubItems(2).Text).Month & "/" & Date.Parse(row.SubItems(2).Text).Year =
                '        Date.Parse(dtpdatefrom.Text).Month & "/" & Date.Parse(dtpdatefrom.Text).Year Then

                '            If row.SubItems(41).Text = "" Or row.SubItems(41).Text = "WITH DR" Then
                '            Else
                '                .load_dr(row.SubItems(41).Text, row.SubItems(42).Text)
                '            End If
                '        End If

                '    Case "Generate by RS No.", "Generate by DR No.", "Generate by WS No."

                '        If row.SubItems(41).Text = "" Or row.SubItems(41).Text = "WITH DR" Then
                '        Else
                '            .load_dr(row.SubItems(41).Text, row.SubItems(42).Text)
                '        End If
                'End Select
            Next
        End With

        FDRLIST.Show()
    End Sub
    Private Function countThis(project As String) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        With FRequistionForm
            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 39)
                newCMD.Parameters.AddWithValue("@project", project)
                newCMD.Parameters.AddWithValue("@datefrom", Date.Parse(dtpdatefrom.Text))
                newCMD.Parameters.AddWithValue("@dateto", Date.Parse(dtpdateto.Text))
                newDR = newCMD.ExecuteReader

                newCMD.CommandTimeout = 100

                While newDR.Read
                    countThis = newDR.Item("counts").ToString
                End While

                newDR.Close()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try
        End With
    End Function

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub summary_charges(project As String, item As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader



        With FRequistionForm
            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@searchby", "Generate by RS No.")
                If project = "" Then
                    newCMD.Parameters.AddWithValue("@n", 40)
                Else
                    newCMD.Parameters.AddWithValue("@n", 38)
                End If

                newCMD.Parameters.AddWithValue("@project", project)
                newCMD.Parameters.AddWithValue("@item", item)
                newCMD.Parameters.AddWithValue("@datefrom", Date.Parse(dtpdatefrom.Text))
                newCMD.Parameters.AddWithValue("@dateto", Date.Parse(dtpdateto.Text))


GOHERE:

                newCMD.CommandTimeout = 100
                newDR = newCMD.ExecuteReader

                Dim a(43) As String

                While newDR.Read

                    If newDR.Item("division").ToString = "WAREHOUSING AND SUPPLY" Then
                        GoTo proceedhere
                    End If

                    If newDR.Item("mother_rs").ToString = "A1" And newDR.Item("IN_OUT").ToString = "IN" Then
                        GoTo proceedhere
                    End If

                    a(0) = newDR.Item("rs_id").ToString
                    a(1) = newDR.Item("rs_no").ToString

                    If newDR.Item("date_request").ToString = "" Then
                    Else
                        a(2) = Format(Date.Parse(newDR.Item("date_request").ToString), "MM/dd/yyyy")
                    End If

                    a(3) = newDR.Item("job_order_no").ToString
                    a(4) = newDR.Item("ITEM_DESC").ToString
                    a(5) = newDR.Item("rs_qty").ToString
                    a(6) = newDR.Item("unit").ToString
                    a(7) = IIf(Format(Date.Parse(newDR.Item("date_needed").ToString), "MM/dd/yyyy") = "01/01/1900", "", Format(Date.Parse(newDR.Item("date_needed").ToString), "MM/dd/yyyy"))
                    a(8) = newDR.Item("type_of_request").ToString
                    a(9) = newDR.Item("IN_OUT").ToString
                    a(10) = newDR.Item("po_status").ToString
                    a(11) = ""
                    a(12) = newDR.Item("ws_status").ToString
                    a(13) = newDR.Item("charges").ToString
                    a(14) = newDR.Item("location").ToString
                    a(15) = newDR.Item("wh_id").ToString
                    a(16) = newDR.Item("date_log").ToString
                    a(17) = newDR.Item("type_of_charges").ToString
                    a(18) = newDR.Item("type_of_purchasing").ToString
                    a(19) = newDR.Item("remarks").ToString
                    a(20) = ""
                    a(21) = newDR.Item("dr_no").ToString

                    If newDR.Item("mother_rs").ToString = "A" And newDR.Item("IN_OUT").ToString = "IN" Then
                        a(22) = newDR.Item("M_po_ws_released").ToString
                    Else
                        a(22) = newDR.Item("po_ws_qty_released").ToString
                    End If

                    If newDR.Item("mother_rs").ToString = "A" And newDR.Item("IN_OUT").ToString = "IN" Then
                        a(23) = newDR.Item("M_rr_ws_received").ToString
                    Else
                        a(23) = newDR.Item("rr_ws_qty_received").ToString
                    End If

                    a(24) = newDR.Item("users").ToString
                    a(25) = newDR.Item("ws_id_dr_id").ToString
                    a(26) = ""
                    a(27) = ""
                    a(28) = newDR.Item("requested_by").ToString
                    a(29) = newDR.Item("cons_item").ToString
                    a(30) = newDR.Item("cons_item_desc").ToString
                    a(31) = newDR.Item("type_of_delivery").ToString

                    If newDR.Item("IN_OUT").ToString = "OUT" Then
                        If newDR.Item("mother_rs").ToString = "A1" Then
                            a(23) = newDR.Item("OUT_DR_QTY").ToString

                            If newDR.Item("ws_dr_in_qty").ToString = "" Then
                                a(32) = newDR.Item("ws_dr_out_qty").ToString
                            Else
                                a(32) = newDR.Item("ws_dr_out_qty").ToString & "/" & newDR.Item("ws_dr_in_qty").ToString
                            End If

                        ElseIf newDR.Item("mother_rs").ToString = "A" Then
                            a(32) = 0
                        Else
                            a(32) = newDR.Item("OUT_DR_QTY").ToString
                        End If

                    Else
                        a(32) = newDR.Item("IN_OTHERS_DR_QTY").ToString
                    End If

                    a(33) = newDR.Item("wh_area").ToString
                    a(34) = 0
                    a(35) = 0
                    a(36) = newDR.Item("ws_no").ToString
                    a(39) = newDR.Item("temp_col_item_name").ToString
                    a(40) = newDR.Item("charges").ToString
                    a(41) = newDR.Item("dr_option").ToString
                    a(42) = newDR.Item("dr_items_id").ToString

                    Dim lvl As New ListViewItem(a)
                    .lvlrequisitionlist.Items.Add(lvl)

                    If newDR.Item("mother_rs").ToString = "A" Then
                        .lvlrequisitionlist.Items(counter).BackColor = Color.DarkGreen
                        .lvlrequisitionlist.Items(counter).ForeColor = Color.White
                        .lvlrequisitionlist.Items(counter).Font = New Font(New FontFamily("Arial"), 10, FontStyle.Bold)
                    ElseIf newDR.Item("mother_rs").ToString = "A1" Then
                        .lvlrequisitionlist.Items(counter).BackColor = Color.LightGreen
                        .lvlrequisitionlist.Items(counter).Font = New Font(New FontFamily("Arial"), 10, FontStyle.Bold)
                    ElseIf newDR.Item("mother_rs").ToString = "A2" Then
                        .lvlrequisitionlist.Items(counter).BackColor = Color.LightYellow
                        'lvlrequisitionlist.Items(counter).Font.Size = "11pt"
                    End If

                    counter += 1

proceedhere:
                    Application.DoEvents()

                End While

                newDR.Close()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try
        End With
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not thread.IsAlive Then
            Panel3.Visible = False
            lvlSearchCharges.Visible = True
            Timer1.Stop()
            btnEndProcess.Visible = False
            FRequistionForm.btnSearch.Enabled = True
        Else
            Panel3.Visible = True
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        With FRequistionForm
            If time_ticker = .ListBox1.Items.Count Then
                Timer2.Stop()
                time_ticker = 0
                FRequistionForm.btnSearch.Enabled = True
            Else
                'Label6.Text = .ListBox1.Items(time_ticker).ToString
                'Me.Refresh()
                If Not .thread.IsAlive Then
                    FRequistionForm.btnSearch.Enabled = True
                End If
            End If
        End With
        time_ticker += 1
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnEndProcess.Click
        'threadaborted = True
        'thread.Abort()

        If IsNothing(thread) Then
            Label7.Visible = True
            charges_abort = True

            Exit Sub
        End If

        If IsNothing(thread1) Then
            Label7.Visible = True
            charges_abort = True

            Exit Sub
        End If


        If thread.IsAlive Then
            Label7.Visible = True
            charges_abort = True
            thread.Abort()
        End If

        If thread1.IsAlive Then
            Label7.Visible = True
            charges_abort = True
            thread1.Abort()
        End If

        If BW_rrPrice.IsBusy Then
            MessageBox.Show("Unable to abort this process...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        If Not thread.IsAlive Then
            FRequistionForm.Panel3.Visible = False
            Timer3.Stop()
            Me.Dispose()
            FRequistionForm.lvlrequisitionlist.Visible = True
            FRequistionForm.FlowLayoutPanel1.Enabled = True
            FRequistionForm.btnSearch.Enabled = True

        Else
            FRequistionForm.Panel3.Visible = True
        End If
    End Sub

    Private Sub cmbProject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProject.SelectedIndexChanged
        cmbProject1.Text = ""

        If cmbProject.Text = "EQUIPMENT" Then
            load_charge_to(2, cmbProject, cmbProject1)

        ElseIf cmbProject.Text = "PROJECT" Then
            load_charge_to(1, cmbProject, cmbProject1)

        ElseIf cmbProject.Text = "WAREHOUSE" Then
            load_charge_to(6, cmbProject, cmbProject1)

        Else
            load_charge_to(3, cmbProject, cmbProject1)

        End If

    End Sub
    Public Sub load_charge_to(ByVal n As Integer, ByVal cmbtypeofcharges As ComboBox, cmbcharges As ComboBox)

        cmbcharges.Items.Clear()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("sp_charges_to", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            If n = 1 Then
                newCMD.Parameters.AddWithValue("@n", 1)
            ElseIf n = 2 Then
                newCMD.Parameters.AddWithValue("@n", 2)
            ElseIf n = 3 Then
                newCMD.Parameters.AddWithValue("@n", 3)
                newCMD.Parameters.AddWithValue("@type_name", cmbtypeofcharges.Text)
            ElseIf n = 6 Then
                newCMD.Parameters.AddWithValue("@n", 4)
            End If
            newDR = newCMD.ExecuteReader

            While newDR.Read
                If n = 1 Then
                    cmbcharges.Items.Add(newDR.Item("project_desc").ToString)
                ElseIf n = 2 Then
                    cmbcharges.Items.Add(newDR.Item("plate_no").ToString)
                ElseIf n = 3 Then
                    cmbcharges.Items.Add(newDR.Item("charge_to").ToString)
                ElseIf n = 6 Then
                    cmbcharges.Items.Add(newDR.Item("wh_area").ToString)
                End If

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub summary_charges1()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        With FRequistionForm
            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@searchby", "Generate by RS No.")
                If proj1 = "" Then
                    newCMD.Parameters.AddWithValue("@n", 40)
                Else
                    newCMD.Parameters.AddWithValue("@n", 38)
                End If

                newCMD.Parameters.AddWithValue("@project", proj1)
                newCMD.Parameters.AddWithValue("@item", item1)
                newCMD.Parameters.AddWithValue("@datefrom", Date.Parse(dtpdatefrom.Text))
                newCMD.Parameters.AddWithValue("@dateto", Date.Parse(dtpdateto.Text))


GOHERE:

                newCMD.CommandTimeout = 100
                newDR = newCMD.ExecuteReader

                Dim a(43) As String

                While newDR.Read

                    If newDR.Item("division").ToString = "WAREHOUSING AND SUPPLY" Then
                        GoTo proceedhere
                    End If

                    If newDR.Item("mother_rs").ToString = "A1" And newDR.Item("IN_OUT").ToString = "IN" Then
                        GoTo proceedhere
                    End If

                    a(0) = newDR.Item("rs_id").ToString
                    a(1) = newDR.Item("rs_no").ToString

                    If newDR.Item("date_request").ToString = "" Then
                    Else
                        a(2) = Format(Date.Parse(newDR.Item("date_request").ToString), "MM/dd/yyyy")
                    End If

                    a(3) = newDR.Item("job_order_no").ToString
                    a(4) = newDR.Item("ITEM_DESC").ToString
                    a(5) = newDR.Item("rs_qty").ToString
                    a(6) = newDR.Item("unit").ToString
                    a(7) = IIf(Format(Date.Parse(newDR.Item("date_needed").ToString), "MM/dd/yyyy") = "01/01/1900", "", Format(Date.Parse(newDR.Item("date_needed").ToString), "MM/dd/yyyy"))
                    a(8) = newDR.Item("type_of_request").ToString
                    a(9) = newDR.Item("IN_OUT").ToString
                    a(10) = newDR.Item("po_status").ToString
                    a(11) = ""
                    a(12) = newDR.Item("ws_status").ToString
                    a(13) = newDR.Item("charges").ToString
                    a(14) = newDR.Item("location").ToString
                    a(15) = newDR.Item("wh_id").ToString
                    a(16) = newDR.Item("date_log").ToString
                    a(17) = newDR.Item("type_of_charges").ToString
                    a(18) = newDR.Item("type_of_purchasing").ToString
                    a(19) = newDR.Item("remarks").ToString
                    a(20) = ""
                    a(21) = newDR.Item("dr_no").ToString

                    If newDR.Item("mother_rs").ToString = "A" And newDR.Item("IN_OUT").ToString = "IN" Then
                        a(22) = newDR.Item("M_po_ws_released").ToString
                    Else
                        a(22) = newDR.Item("po_ws_qty_released").ToString
                    End If

                    If newDR.Item("mother_rs").ToString = "A" And newDR.Item("IN_OUT").ToString = "IN" Then
                        a(23) = newDR.Item("M_rr_ws_received").ToString
                    Else
                        a(23) = newDR.Item("rr_ws_qty_received").ToString
                    End If

                    a(24) = newDR.Item("users").ToString
                    a(25) = newDR.Item("ws_id_dr_id").ToString
                    a(26) = ""
                    a(27) = ""
                    a(28) = newDR.Item("requested_by").ToString
                    a(29) = newDR.Item("cons_item").ToString
                    a(30) = newDR.Item("cons_item_desc").ToString
                    a(31) = newDR.Item("type_of_delivery").ToString

                    If newDR.Item("IN_OUT").ToString = "OUT" Then
                        If newDR.Item("mother_rs").ToString = "A1" Then
                            a(23) = newDR.Item("OUT_DR_QTY").ToString

                            If newDR.Item("ws_dr_in_qty").ToString = "" Then
                                a(32) = newDR.Item("ws_dr_out_qty").ToString
                            Else
                                a(32) = newDR.Item("ws_dr_out_qty").ToString & "/" & newDR.Item("ws_dr_in_qty").ToString
                            End If

                        ElseIf newDR.Item("mother_rs").ToString = "A" Then
                            a(32) = 0
                        Else
                            a(32) = newDR.Item("OUT_DR_QTY").ToString
                        End If

                    Else
                        a(32) = newDR.Item("IN_OTHERS_DR_QTY").ToString
                    End If

                    a(33) = newDR.Item("wh_area").ToString
                    a(34) = 0
                    a(35) = 0
                    a(36) = newDR.Item("ws_no").ToString
                    a(39) = newDR.Item("temp_col_item_name").ToString
                    a(40) = newDR.Item("charges").ToString
                    a(41) = newDR.Item("dr_option").ToString
                    a(42) = newDR.Item("dr_items_id").ToString

                    Dim lvl As New ListViewItem(a)
                    .lvlrequisitionlist.Items.Add(lvl)

                    If newDR.Item("mother_rs").ToString = "A" Then
                        .lvlrequisitionlist.Items(counter).BackColor = Color.DarkGreen
                        .lvlrequisitionlist.Items(counter).ForeColor = Color.White
                        .lvlrequisitionlist.Items(counter).Font = New Font(New FontFamily("Arial"), 10, FontStyle.Bold)
                    ElseIf newDR.Item("mother_rs").ToString = "A1" Then
                        .lvlrequisitionlist.Items(counter).BackColor = Color.LightGreen
                        .lvlrequisitionlist.Items(counter).Font = New Font(New FontFamily("Arial"), 10, FontStyle.Bold)
                    ElseIf newDR.Item("mother_rs").ToString = "A2" Then
                        .lvlrequisitionlist.Items(counter).BackColor = Color.LightYellow
                        'lvlrequisitionlist.Items(counter).Font.Size = "11pt"
                    End If

                    counter += 1

proceedhere:
                    Application.DoEvents()

                End While

                newDR.Close()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try
        End With
    End Sub

    Private Sub timer_thread1_Tick(sender As Object, e As EventArgs) Handles timer_thread.Tick
        If Not thread.IsAlive Then
            timer_thread.Stop()

            Dim c_search As New Class_Search_Charges(crs_data)
            lvlSearchCharges.Visible = False
            thread1 = New Threading.Thread(AddressOf c_search.load_charges)
            thread1.Start()
            timer_thread1.Start()

            'If crs_data.options = "WAREHOUSING AND SUPPLY" Then
            '    Dim c_search As New Class_Search_Charges(crs_data)
            '    lvlSearchCharges.Visible = False
            '    thread1 = New Threading.Thread(AddressOf c_search.load_charges)
            '    thread1.Start()
            '    timer_thread1.Start()
            'End If
        End If
    End Sub

    Private Sub timer_thread1_Tick_1(sender As Object, e As EventArgs) Handles timer_thread1.Tick
        If Not thread1.IsAlive Then
            Panel3.Visible = False
            timer_thread1.Stop()
            lvlSearchCharges.Visible = True
        End If
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs)
        With crs_data

            .charges = cmbProject1.Text
            .items = txtItemSearch.Text
            .date_from = Date.Parse(dtpdatefrom.Text)
            .date_to = Date.Parse(dtpdateto.Text)
            .lbox = ListBox1
            .lview = lvlSearchCharges

        End With

        Dim c_search As New Class_Search_Charges(crs_data)
        Dim thread2 As System.Threading.Thread
        thread2 = New Threading.Thread(AddressOf load_charges)
        thread2.Start(ListBox1)
        timer_thread1.Start()
    End Sub

    Private Sub Fsearchbycharges_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'With crs_data

        '    .charges = cmbProject1.Text
        '    .items = txtItemSearch.Text
        '    .date_from = Date.Parse(dtpdatefrom.Text)
        '    .date_to = Date.Parse(dtpdateto.Text)
        '    .lbox = ListBox1
        '    .lview = lvlSearchCharges

        'End With

        'Dim c_search As New Class_Search_Charges(crs_data)
        'thread1 = New Threading.Thread(AddressOf c_search.load_charges)
        'thread1.Start()
        'timer_thread1.Start()
    End Sub

    Private Sub cmbProject_GotFocus(sender As Object, e As EventArgs) Handles cmbProject.GotFocus
        sender.DroppedDown = True
    End Sub

    Private Sub cmbByDate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbByDate.SelectedIndexChanged
        If cmbByDate.Text = "BY DATE RANGE" Then
            dtpdatefrom.Enabled = True
            dtpdateto.Enabled = True '

        ElseIf cmbByDate.Text = "BY SPECIFIC REQUESTOR" Then
            dtpdatefrom.Enabled = True
            dtpdateto.Enabled = True

        Else
            dtpdatefrom.Enabled = False
            dtpdateto.Enabled = False
        End If
    End Sub

    Private Sub timer_thread2_Tick(sender As Object, e As EventArgs) Handles timer_thread2.Tick
        If Not thread.IsAlive Then
            timer_thread2.Stop()

            Dim c_search As New Class_Search_Charges(crs_data)
            lvlSearchCharges.Visible = False
            thread1 = New Threading.Thread(AddressOf c_search.load_charges_ws)
            thread1.Start()
            timer_thread3.Start()

        End If
    End Sub

    Private Sub timer_thread3_Tick(sender As Object, e As EventArgs) Handles timer_thread3.Tick
        If Not thread1.IsAlive Then
            Panel3.Visible = False
            timer_thread1.Stop()
            lvlSearchCharges.Visible = True
        End If
    End Sub

    Private Sub timer_thread4_Tick(sender As Object, e As EventArgs) Handles timer_thread4.Tick
        If Not thread.IsAlive Then
            timer_thread4.Stop()

            Dim c_search As New Class_Search_Charges(crs_data)
            lvlSearchCharges.Visible = False
            thread1 = New Threading.Thread(AddressOf c_search.load_charges)
            thread1.Start()
            timer_thread1.Start()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        charges._initialize2()
        load_to_listview()

    End Sub

    Private Delegate Sub del_load_to_listview()

    Private Sub load_to_listview()
        If InvokeRequired Then
            Invoke(New del_load_to_listview(AddressOf load_to_listview))
            Exit Sub
        End If


        Dim MyData = charges.cListOfWsCharges
        ProgressBar1.Maximum = MyData.Count

        For Each datas In MyData
            Dim col As String() = New String() {
                datas.ws_no,
                datas.item_desc_from_warehouse,
                datas.ws_date,
                "",
                datas.ws_id,
                datas.charges,
                datas.item_desc_from_rs
               }
            Dim lvl As New ListViewItem(col)
            ListOfLview.Add(lvl)

            ProgressBar1.Value += 1
        Next

        addToList()

    End Sub
    Private Delegate Sub del_addToList()

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork

        trd3 = New Threading.Thread(AddressOf check_if_finish)
        trd3.Start()

    End Sub

    Private Sub ShowRRPriceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowRRPriceToolStripMenuItem.Click


        'cListOfRsId.Add(535487)
        'cListOfRsId.Add(537893)

        totalWorkers = 0
        completedWorkers = 0
        cListOfRsId.Clear()
        cListOfDatas.Clear()
        cListOfThreading.Clear()
        ProgressBar1.Value = 0

        For Each row As ListViewItem In lvlSearchCharges.Items
            If row.Checked = True Then
                Dim rsIdTypeNew As New rsIdType
                With rsIdTypeNew
                    .rs_id = row.SubItems(4).Text
                    .typeOfPurchasing = row.SubItems(8).Text.ToUpper()
                End With

                cListOfRsId.Add(rsIdTypeNew)
            End If
        Next

        If cListOfRsId.Count = 0 Then
            Exit Sub
        End If

        totalWorkers = cListOfRsId.Count
        Panel3.Visible = True

        'BW price updates
        BW_rrPrice.WorkerSupportsCancellation = True
        BW_rrPrice.RunWorkerAsync()


    End Sub


    Private Sub showPrice(paramRsId As Integer, Optional paramTypeOfPurchasing As String = "")

        Dim bw As New System.ComponentModel.BackgroundWorker()
        bw.WorkerSupportsCancellation = True

        ' Attach DoWork event with paramRsId
        AddHandler bw.DoWork, Sub(sender, e) BW_showRRPrice_DoWorkNew(sender, e, paramRsId, paramTypeOfPurchasing)

        ' Attach RunWorkerCompleted to track when the work is done
        AddHandler bw.RunWorkerCompleted, AddressOf WorkerCompleted

        bw.RunWorkerAsync()
    End Sub

    ' Handle worker completion
    Private Sub WorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs)
        ' Increment the completed workers counter
        completedWorkers += 1

        ' Check if all workers are done
        If completedWorkers >= totalWorkers Then

            MessageBox.Show("The Prices have loaded successfully...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)

            If lvlSearchCharges.InvokeRequired Then
                lvlSearchCharges.Invoke(Sub()
                                            task_finished()
                                        End Sub)
            Else
                task_finished()


            End If

        End If
    End Sub

    Private Sub task_finished()
        Panel3.Visible = False
        For Each row As ListViewItem In lvlSearchCharges.Items
            If row.Checked = True Then
                For Each row2 In cListOfDatas
                    If row.SubItems(4).Text = row2.rs_id Then
                        row.SubItems(7).Text = Format(row2.price, "#,##0")
                        Exit For
                    End If
                Next
            End If

        Next
    End Sub

    Private Sub BW_showRRPrice_DoWorkNew(sender As Object, e As System.ComponentModel.DoWorkEventArgs, paramRsId As Integer, Optional TypeOfPurchasing As String = "")


        If TypeOfPurchasing = "CASH WITHOUT RR" Then
            'FOR RS DATA
            forRSData(paramRsId)
        Else
            'FOR RR DATA
            forRRData(paramRsId)
        End If

    End Sub

    Private Sub forRRData(paramRsId As Integer)
        'FOR RR DATA
        Dim rrPrice As New Model._Mod_RR
        rrPrice.cStoreProcedureName = "proc_receiving_crud_new6"
        rrPrice.parameter("@n", 8)

        rrPrice.parameter("@rs_id", paramRsId)
        rrPrice.cSearchBy = Model._Mod_RR.searchByEnum.rs_id_but_price_col_only

        Dim datas As New List(Of Model._Mod_RR.rr_fields)
        datas = rrPrice.LISTOFRR

        If ProgressBar1.InvokeRequired Then
            ProgressBar1.Invoke(Sub()
                                    ProgressBar1.Maximum = cListOfRsId.Count
                                End Sub)
        End If


        Dim newDatas As New datasType
        For Each row In datas
            With newDatas

                .rs_id = row.rs_id
                .price = row.price

            End With

            SyncLock cListOfDatas
                cListOfDatas.Add(newDatas)

                If ProgressBar1.InvokeRequired Then
                    ProgressBar1.Invoke(Sub()
                                            ProgressBar1.Value += 1
                                        End Sub)
                End If
            End SyncLock

            'cListOfDatas.Add(newDatas)
        Next
    End Sub

    Private Sub forRSData(paramRsId As Integer)
        Dim rsPrice As New Model._Mod_RS
        rsPrice.cStoreProcedureName = "proc_receiving_crud_new6"
        rsPrice.parameter("@n", 9)

        rsPrice.parameter("@rs_id", paramRsId)
        rsPrice.cSearchBy = Model._Mod_RR.searchByEnum.rs_id_but_price_col_only

        Dim datas As New List(Of Model._Mod_RS.rs_fields)
        datas = rsPrice.LISTOFRS

        If ProgressBar1.InvokeRequired Then
            ProgressBar1.Invoke(Sub()
                                    ProgressBar1.Maximum = cListOfRsId.Count
                                End Sub)
        End If


        Dim newDatas As New datasType
        For Each row In datas
            With newDatas

                .rs_id = row.rs_id
                .price = row.amount

            End With

            SyncLock cListOfDatas
                cListOfDatas.Add(newDatas)

                If ProgressBar1.InvokeRequired Then
                    ProgressBar1.Invoke(Sub()
                                            ProgressBar1.Value += 1
                                        End Sub)
                End If
            End SyncLock

            'cListOfDatas.Add(newDatas)
        Next

    End Sub

    Private Sub check_if_finish()
        If Panel3.InvokeRequired Then
            Panel3.Invoke(Sub()
                              Panel3.Visible = True
                          End Sub)
        Else
            Panel3.Visible = True
        End If

        While charges.trd.IsAlive

        End While

        If Panel3.InvokeRequired Then
            Panel3.Invoke(Sub()
                              Panel3.Visible = False
                          End Sub)
        Else
            Panel3.Visible = False
        End If
    End Sub

    Private Sub BW_rrPrice_DoWork(sender As Object, e As DoWorkEventArgs) Handles BW_rrPrice.DoWork


        For Each rsIdData In cListOfRsId

            Dim td As Threading.Thread
            Threading.Thread.Sleep(100)
            td = New Threading.Thread(Sub() showPrice(rsIdData.rs_id, rsIdData.typeOfPurchasing))
            td.Start()
            cListOfThreading.Add(td)

        Next

        ' Wait for all threads to complete
        For Each td In cListOfThreading
            td.Join()
        Next
    End Sub

    Private Sub BW_showRRPrice_DoWork(sender As Object, e As DoWorkEventArgs)
        Dim td As Threading.Thread

        td = New Threading.Thread(Sub() showPrice(535487))
        td.Start()

        Dim td2 As Threading.Thread

        td2 = New Threading.Thread(Sub() showPrice(537893))
        td2.Start()


        td.Join()
        td2.Join()


    End Sub

    Private Sub addToList()
        If InvokeRequired Then
            Invoke(New del_addToList(AddressOf addToList))
            Exit Sub
        End If

        lvlSearchCharges.Items.AddRange(ListOfLview.ToArray)

    End Sub
    Private Sub cmbProject1_GotFocus(sender As Object, e As EventArgs) Handles cmbProject1.GotFocus
        sender.DroppedDown = True
    End Sub

    Public Sub load_charges(lbox1 As ListBox)
        'If lbox1.InvokeRequired Then
        '    lbox1.Invoke(Sub()

        '                     For Each row As String In lbox1.Items
        '                         load_the_charges(row)
        '                     Next
        '                 End Sub)
        'Else
        '    For Each row As String In lbox1.Items
        '        load_the_charges(row)
        '    Next
        'End If

        For i = 0 To lbox1.Items.Count - 1
            load_the_charges(ListBox1.Items(i))
        Next

    End Sub
    Private Sub load_the_charges(rs_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 16)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newCMD.CommandTimeout = 100

            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                a(0) = newDR.Item("rs_no").ToString
                a(1) = newDR.Item("item_desc_from_warehouse").ToString
                a(2) = Date.Parse(newDR.Item("date_req").ToString)
                a(3) = newDR.Item("wh_id").ToString
                a(4) = newDR.Item("rs_id").ToString
                a(6) = newDR.Item("item_desc_from_rs").ToString

                Dim lvl As New ListViewItem(a)

                If lvlSearchCharges.InvokeRequired Then
                    lvlSearchCharges.Invoke(Sub() lvlSearchCharges.Items.Add(lvl))
                Else
                    lvlSearchCharges.Items.Add(lvl)
                End If

            End While

        Catch ex As Exception
            'If threadaborted = True Then
            '    MessageBox.Show("Process has been aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    threadaborted = False
            '    Exit Sub
            'End If
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub BW_rrPrice_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BW_rrPrice.RunWorkerCompleted

    End Sub
End Class