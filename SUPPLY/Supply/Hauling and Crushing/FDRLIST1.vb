Imports System.ComponentModel
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop

Public Class FDRLIST1
    Dim dr_item_id_count As Integer = 0
    Dim thread, thread1, thread2 As System.Threading.Thread
    Dim abortsearching As Boolean = False
    Dim searching_by As String
    Dim sortColumn As Integer = -1
    Dim row_no As Integer = 1

    Dim try_item As String
    Dim try_search As String
    Dim try_searchby As String
    Dim try_inout As String
    Dim try_from As DateTime
    Dim try_to As DateTime

    Dim newDR As New class_new_dr
    Dim withoutdr_rs As New class_new_dr
    Dim newWS As New class_ws
    Dim newPO As New class_new_po
    Dim progbar As New class_progressbar

    Dim trd, trd2, trd3 As Threading.Thread
    Dim finished As Boolean = False

    Private r1 As Boolean = False
    Private listoflistviewitem As New List(Of ListViewItem)

    Public DistinctListOfDRRequestor, DistinctListOfDRItems
    Public whTOwh As New FWHtoWH

    Public Class important_ids
        Property rs_id As Integer
        Property wh_id As Integer

    End Class

    Public Structure dr_list

        Dim dr_item_id As Integer
        Dim rs_no As String
        Dim requestor As String
        Dim dr_date As DateTime
        Dim date_request As DateTime
        Dim dr_no As String
        Dim plateno As String
        Dim driver As String
        Dim ws_po_no As String
        Dim rr_no As String
        Dim item_name As String
        Dim item_desc As String
        Dim unit As String
        Dim source As String
        Dim concession_ticket As String
        Dim dr_qty As Double
        Dim price As Double
        Dim total_amount As Double
        Dim supplier As String
        Dim checked_by As String
        Dim received_by As String
        Dim withdrawn_by As String
        Dim remarks As String
        Dim user As String
        Dim inout As String
        Dim dr_option As String
        Dim rs_id As Integer
        Dim approved_by As String
        Dim wh_id As Integer
        Dim source2 As String
        Dim date_submitted As DateTime
        Dim requestor_without_rs As String

    End Structure

    Public cNewListOfDr As New List(Of dr_list)
    Public cSort As New List(Of dr_list)
    Public cListOfThread As New List(Of Threading.Thread)

    Private cProperNames As New Model_ProperNames
    Private cDrModel, cWsModel, cPoModel As New ModelNew.Model
    Dim cBgWorkerChecker As Timer

    Private cListOfDrListItems As New List(Of PropsFields.dr_list_props_fields)
    Private Function placeholdervalue(obj As Object) As String
        Dim textbox As TextBox = obj

        If textbox.Text = "RS NO..." Then
            placeholdervalue = ""
        ElseIf textbox.Text = "DR NO..." Then
            placeholdervalue = ""
        ElseIf textbox.Text = "WS NO..." Then
            placeholdervalue = ""
        ElseIf textbox.Text = "DRIVER..." Then
            placeholdervalue = ""
        ElseIf textbox.Text = "PLATE NO..." Then
            placeholdervalue = ""
        ElseIf textbox.Text = "UNIT..." Then
            placeholdervalue = ""
        ElseIf textbox.Text = "ITEM DESCRIPTION..." Then
            placeholdervalue = ""
        ElseIf textbox.Text = "CONSESSION TICKET..." Then
            placeholdervalue = ""
        ElseIf textbox.Text = "REQUESTOR..." Then
            placeholdervalue = ""
        ElseIf textbox.Text = "SOURCE..." Then
            placeholdervalue = ""
        ElseIf textbox.Text = "ITEMS..." Then
            placeholdervalue = ""
        Else
            placeholdervalue = textbox.Text
        End If
    End Function
    Public Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click


        If cmbSortBy.Text = "WITHOUT RS AND DR" Then
            Panel4.Visible = True
            withoutdr_rs = New class_new_dr
            r1 = False
            listoflistviewitem.Clear()
            lvl_drList.Items.Clear()


            bw_search_without_rs_dr = Nothing
            bw_search_without_rs_dr = New BackgroundWorker
            bw_search_without_rs_dr.WorkerSupportsCancellation = True
            bw_search_without_rs_dr.RunWorkerAsync()

            bw_check_if_done = Nothing
            bw_check_if_done = New BackgroundWorker
            bw_check_if_done.WorkerSupportsCancellation = True
            bw_check_if_done.RunWorkerAsync()

        Else
            'Dim agg_ As New class_exclusive_aggregates
            'agg_._initialize2("09283515253", "RS NO", False)

            'Dim agg_ As New class_DR2

            'agg_._initialize("09283515253", lvl_drList)

            trigger()

        End If

        'getDrs()
    End Sub


    Private Sub getDrs()
        cListOfDrListItems.Clear()
        cDrModel.clearParameter()
        cPoModel.clearParameter()
        cWsModel.clearParameter()

        Panel4.Visible = True


        Dim cv1 As New ColumnValues

        cv1.add("searchby", cmbSortBy.Text)
        cv1.add("search", txtItemDesc.Text)

        _initializing(cCol.forDrSearch,
                      cv1.getValues(),
                      cDrModel,
                      drBgWorker)

        _initializing(cCol.forDrWsSearch,
                      cv1.getValues(),
                      cWsModel,
                      drBgWorker)

        _initializing(cCol.forDrPoSearch,
                      cv1.getValues(),
                      cPoModel,
                      drBgWorker)

        cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, drBgWorker)
    End Sub

    Private Sub SuccessfullyDone()
        cListOfDrItems = TryCast(cDrModel.cData, List(Of PropsFields.dr_props_fields))
        cListOfDrWsItems = TryCast(cWsModel.cData, List(Of PropsFields.dr_ws_props_fields))
        cListOfDrPoItems = TryCast(cPoModel.cData, List(Of PropsFields.dr_po_props_fields))

        'get the data result

        ''display to gridview or listview
        displayResult()

        'done loading
        Panel4.Visible = False


    End Sub

    Private Sub displayResult()
        'dr items
        For Each row In cListOfDrItems
            Dim _dr As New PropsFields.dr_list_props_fields
            With _dr
                .rs_id = row.rs_id
                .dr_item_id = row.dr_item_id
                .rs_no = row.rs_no
                .requestor = row.requestor
                .dr_date = row.dr_date
                .date_request = row.rs_date  'IIf(row.inout = "IN", check_if_pair(row.dr_no, row.rs_date), row.rs_date)
                .dr_no = row.dr_no
                .plateno = row.plateno
                .driver = row.driver
                '.ws_po_no = IIf(row.inout = "OUT", row.ws_no, row.po_no)
                .ws_po_no = row.ws_no
                .rr_no = row.rr_no
                .item_name = row.item_name
                .item_desc = row.item_desc
                .unit = row.unit
                .source = row.dr_source
                .concession_ticket = row.concession_ticket
                .dr_qty = row.dr_qty
                .price = row.price
                .total_amount = row.total_amount
                .supplier = row.supplier
                .checked_by = row.checked_by
                .received_by = row.received_by
                .remarks = row.remarks
                .user = row.input_user
                .inout = row.inout
                .dr_option = row.dr_option
                .wh_id = row.wh_id
                .source2 = row.source2
                .date_submitted = row.date_submitted
                .requestor_without_rs = row.requestor_without_rs
            End With

            cListOfDrListItems.Add(_dr)
        Next

        'add withdrawal without dr
        For Each row In cListOfDrWsItems
            Dim _ws As New PropsFields.dr_list_props_fields
            With _ws
                .dr_item_id = row.ws_id
                .rs_no = row.rs_no
                .requestor = row.requestor
                .dr_date = row.ws_date
                .date_request = row.rs_date
                .dr_no = row.dr_no
                .plateno = row.plateno
                .driver = row.driver
                .ws_po_no = row.ws_no
                .rr_no = row.rr_no
                .item_name = row.item_name
                .item_desc = row.item_desc
                .unit = row.unit
                .source = row.ws_source
                .concession_ticket = row.concession_ticket
                .dr_qty = row.ws_qty
                .price = row.price
                .total_amount = row.total_amount
                .supplier = row.supplier
                .checked_by = row.checked_by
                .received_by = ""
                .approved_by = row.approved_by
                .withdrawn_by = row.withdrawn_by
                .source2 = row.source2
                .remarks = row.remarks
                .user = row.users
                .inout = row.inout
                .dr_option = row.dr_option
                .wh_id = row.wh_id
            End With

            cListOfDrListItems.Add(_ws)
        Next
    End Sub
    Public Sub trigger()
        If BackgroundWorker1.IsBusy Then
            BackgroundWorker1.CancelAsync()
            Exit Sub
        End If

        pub_List_of_Dr = Nothing
        btnSearch.Enabled = False
        lblRecords.Text = "waiting..."
        ProgressBar1.Style = ProgressBarStyle.Marquee
        'lvl_drList.Visible = False
        'search_dr()
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub panelvisible()

        If Panel4.InvokeRequired Then
            Panel4.Invoke(Sub()
                              Panel4.Visible = True
                              Label7.Text = "initializing..."
                              ' lvl_drList.Visible = False
                          End Sub)
        Else
            Panel4.Visible = True
            ' lvl_drList.Visible = False
        End If


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If Not thread1.IsAlive Then
            Panel4.Visible = False
            Timer1.Stop()

            lvl_drList.Visible = False
            Timer2.Start()

            Select Case searching_by
                Case "WS NO"
                    thread = New Threading.Thread(AddressOf search_using_dr1)
                    thread.Start()

                Case "RS NO", "ITEM DESCRIPTION", "REQUESTOR", "SOURCE", "UNIT"
                    thread = New Threading.Thread(AddressOf search_using_dr1)
                    thread.Start()
                Case Else
                    thread = New Threading.Thread(AddressOf search_using_dr)
                    thread.Start()
            End Select

        Else
            Panel4.Visible = True
        End If
    End Sub

    Public Sub load_dr_id(n As Integer, search As String, items As String, inout As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        With FDRLIST

            If ListBox1.InvokeRequired Then
                ListBox1.Invoke(Sub() ListBox1.Items.Clear())
            Else
                ListBox1.Items.Clear()
            End If

            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_Delivery_Receipt2", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", n)
                newCMD.Parameters.AddWithValue("@search", search)
                newCMD.Parameters.AddWithValue("@items", items)
                newCMD.Parameters.AddWithValue("@searchby", cmbSortBy.Text)
                newCMD.Parameters.AddWithValue("@inout", inout)
                newCMD.Parameters.AddWithValue("@datefrom", Date.Parse(dtpfrom.Text))
                newCMD.Parameters.AddWithValue("@dateto", Date.Parse(dtpto.Text))

                newCMD.CommandTimeout = 200
                newDR = newCMD.ExecuteReader

                While newDR.Read
                    If ListBox1.InvokeRequired Then
                        ListBox1.Invoke(Sub()
                                            Select Case searching_by
                                                Case "RS NO", "ITEM DESCRIPTION", "REQUESTOR", "SOURCE", "UNIT"
                                                    If newDR.Item("IN_OUT").ToString = "IN" And newDR.Item("type_of_purchasing").ToString = "DR" And newDR.Item("typeRequest").ToString = "" And newDR.Item("process").ToString = "" Then
                                                    Else
                                                        ListBox1.Items.Add(newDR.Item("rs_id").ToString)
                                                    End If
                                                Case "WS NO"
                                                    ListBox1.Items.Add(newDR.Item("po_det_id").ToString)
                                                Case Else
                                                    ListBox1.Items.Add(newDR.Item("dr_items_id").ToString)
                                            End Select
                                        End Sub)
                    Else
                        Select Case searching_by
                            Case "RS NO", "ITEM DESCRIPTION", "REQUESTOR", "SOURCE", "UNIT"
                                If newDR.Item("IN_OUT").ToString = "IN" And newDR.Item("type_of_purchasing").ToString = "DR" And newDR.Item("typeRequest").ToString = "" And newDR.Item("process").ToString = "" Then
                                Else
                                    ListBox1.Items.Add(newDR.Item("rs_id").ToString)
                                End If
                            Case "WS NO"
                                ListBox1.Items.Add(newDR.Item("po_det_id").ToString)
                            Case Else
                                ListBox1.Items.Add(newDR.Item("dr_items_id").ToString)
                        End Select
                    End If

                    dr_item_id_count += 1
                End While

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()

                If lblRecords.InvokeRequired Then
                    lblRecords.Invoke(Sub() lblRecords.Text = dr_item_id_count.ToString("N0") & " record(s) found...")
                Else
                    lblRecords.Text = dr_item_id_count.ToString("N0") & " record(s) found..."
                End If

            End Try
        End With

    End Sub

    Public Sub load_dr_id2(n As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        If ListBox1.InvokeRequired Then
            ListBox1.Invoke(Sub() ListBox1.Items.Clear())
        Else
            ListBox1.Items.Clear()
        End If

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@search", try_search)
            newCMD.Parameters.AddWithValue("@items", try_item)
            newCMD.Parameters.AddWithValue("@searchby", try_searchby)
            newCMD.Parameters.AddWithValue("@inout", try_inout)
            newCMD.Parameters.AddWithValue("@datefrom", Date.Parse(try_from))
            newCMD.Parameters.AddWithValue("@dateto", Date.Parse(try_to))
            newDR = newCMD.ExecuteReader

            While newDR.Read
                If ListBox1.InvokeRequired Then
                    ListBox1.Invoke(Sub()
                                        Select Case searching_by
                                            Case "RS NO", "ITEM DESCRIPTION", "REQUESTOR", "SOURCE", "UNIT"
                                                If newDR.Item("IN_OUT").ToString = "IN" And newDR.Item("type_of_purchasing").ToString = "DR" And newDR.Item("typeRequest").ToString = "" And newDR.Item("process").ToString = "" Then
                                                Else
                                                    ListBox1.Items.Add(newDR.Item("rs_id").ToString)
                                                End If
                                            Case "WS NO"
                                                ListBox1.Items.Add(newDR.Item("po_det_id").ToString)
                                            Case Else
                                                ListBox1.Items.Add(newDR.Item("dr_items_id").ToString)
                                        End Select
                                    End Sub)
                Else
                    Select Case searching_by
                        Case "RS NO", "ITEM DESCRIPTION", "REQUESTOR", "SOURCE", "UNIT"
                            If newDR.Item("IN_OUT").ToString = "IN" And newDR.Item("type_of_purchasing").ToString = "DR" And newDR.Item("typeRequest").ToString = "" And newDR.Item("process").ToString = "" Then
                            Else
                                ListBox1.Items.Add(newDR.Item("rs_id").ToString)
                            End If
                        Case "WS NO"
                            ListBox1.Items.Add(newDR.Item("po_det_id").ToString)
                        Case Else
                            ListBox1.Items.Add(newDR.Item("dr_items_id").ToString)
                    End Select
                End If

                dr_item_id_count += 1
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

            If lblRecords.InvokeRequired Then
                lblRecords.Invoke(Sub() lblRecords.Text = dr_item_id_count.ToString("N0") & " record(s) found...")
            Else
                lblRecords.Text = dr_item_id_count.ToString("N0") & " record(s) found..."
            End If

        End Try


    End Sub
    Public Sub search_using_dr()
        Try
            Dim rs_percent As Integer
            'If Integer.TryParse((rs_id_count / 100), n) Then
            '    rs_percent = rs_id_count / 100
            'Else
            '    rs_percent = 1
            'End If

            rs_percent = 1

            If ProgressBar1.InvokeRequired Then
                ProgressBar1.Invoke(Sub()
                                        ProgressBar1.Value = 0
                                        'ProgressBar1.Maximum = (rs_percent * 100)
                                        ProgressBar1.Maximum = dr_item_id_count
                                    End Sub)

            Else
                ProgressBar1.Value = 0
                'ProgressBar1.Maximum = (rs_percent * 100)
                ProgressBar1.Maximum = dr_item_id_count
            End If
            Dim count_dr As Integer

            If ListBox1.InvokeRequired Then
                ListBox1.Invoke(Sub() count_dr = ListBox1.Items.Count)
            Else
                count_dr = ListBox1.Items.Count
            End If

            For i = 0 To count_dr - 1

                ' load_rs_new2(ListBox1.Items(i))
                search_dr_new(ListBox1.Items(i))

                If ProgressBar1.InvokeRequired Then
                    ProgressBar1.Invoke(Sub()
                                            If ProgressBar1.Value = dr_item_id_count Then ' 100 Then
                                            Else
                                                ProgressBar1.Value += CDbl(rs_percent)
                                            End If

                                        End Sub)
                Else
                    ProgressBar1.Value += CDbl(rs_percent)
                End If

            Next

            If ProgressBar1.InvokeRequired Then
                ProgressBar1.Invoke(Sub() ProgressBar1.Value = ProgressBar1.Maximum)
            Else
                ProgressBar1.Value = ProgressBar1.Maximum
            End If

            dr_item_id_count = 0

            'thread.Abort()
        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub search_using_dr1()
        Try
            Dim rs_percent As Integer
            'If Integer.TryParse((rs_id_count / 100), n) Then
            '    rs_percent = rs_id_count / 100
            'Else
            '    rs_percent = 1
            'End If

            rs_percent = 1

            If ProgressBar1.InvokeRequired Then
                ProgressBar1.Invoke(Sub()
                                        ProgressBar1.Value = 0
                                        'ProgressBar1.Maximum = (rs_percent * 100)
                                        ProgressBar1.Maximum = dr_item_id_count
                                    End Sub)

            Else
                ProgressBar1.Value = 0
                'ProgressBar1.Maximum = (rs_percent * 100)
                ProgressBar1.Maximum = dr_item_id_count
            End If
            Dim count_dr As Integer

            If ListBox1.InvokeRequired Then
                ListBox1.Invoke(Sub() count_dr = ListBox1.Items.Count)
            Else
                count_dr = ListBox1.Items.Count
            End If

            For i = 0 To count_dr - 1

                ' load_rs_new2(ListBox1.Items(i))
                Select Case searching_by
                    Case "WS NO"
                        search_dr_new1(ListBox1.Items(i))
                    Case "RS NO", "ITEM DESCRIPTION", "REQUESTOR", "SOURCE", "UNIT"
                        search_dr_new4(ListBox1.Items(i))
                End Select

                If ProgressBar1.InvokeRequired Then
                    ProgressBar1.Invoke(Sub()
                                            If ProgressBar1.Value = dr_item_id_count Then ' 100 Then
                                            Else
                                                ProgressBar1.Value += CDbl(rs_percent)
                                            End If

                                        End Sub)
                Else
                    ProgressBar1.Value += CDbl(rs_percent)
                End If

            Next

            If ProgressBar1.InvokeRequired Then
                ProgressBar1.Invoke(Sub() ProgressBar1.Value = ProgressBar1.Maximum)
            Else
                ProgressBar1.Value = ProgressBar1.Maximum
            End If

            dr_item_id_count = 0

            'thread.Abort()
        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        If Not thread.IsAlive Then
            Panel4.Visible = False
            Timer2.Stop()
            lvl_drList.Visible = True

            Select Case searching_by
                Case "RS NO", "ITEM DESCRIPTION", "REQUESTOR", "SOURCE"
                Case Else
                    For Each row As ListViewItem In lvl_drList.Items
                        If row.SubItems(31).Text = "WITH DR" Then
                            row.Remove()
                        End If
                    Next

                    ''Set the ListviewItemSorter property to a new ListviewItemComparer object
                    'Me.lvl_drList.ListViewItemSorter = New ListViewItemComparer(3, lvl_drList.Sorting)

                    '' Call the sort method to manually sort
                    'lvl_drList.Sort()

            End Select
            Panel2.Enabled = True
        Else
            Panel4.Visible = True
        End If
    End Sub

    Private Sub FDRLIST1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        col_rrno.DisplayIndex = 3

        col_rs_no.DisplayIndex = 1
        col_requestor.DisplayIndex = 2
        col_dr_date.DisplayIndex = 3
        col_date_request.DisplayIndex = 4
        col_dr_no.DisplayIndex = 5
        col_plateno.DisplayIndex = 6
        col_driver.DisplayIndex = 7
        col_ws_no_po_no.DisplayIndex = 8
        col_rrno.DisplayIndex = 9
        col_item_name.DisplayIndex = 10
        col_item_desc.DisplayIndex = 11
        col_unit.DisplayIndex = 12
        col_source.DisplayIndex = 13
        col_source2.DisplayIndex = 14
        col_withdrawn_by.DisplayIndex = 15
        col_concession.DisplayIndex = 16
        col_qty_out.DisplayIndex = 17
        col_qty_in_others.DisplayIndex = 18
        col_price.DisplayIndex = 19
        col_total_amount.DisplayIndex = 20
        col_supplier.DisplayIndex = 21
        col_checked_by.DisplayIndex = 22
        col_received_by.DisplayIndex = 23
        col_remarks.DisplayIndex = 24
        col_user.DisplayIndex = 25

        ListBox1.Location = New Point(100000, 10000)

        cProperNames.initialize(Panel4)
        cProperNames.loadProperNames()

    End Sub


    Private Sub cmbSortBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSortBy.SelectedIndexChanged

        cmbEnableDateRange.Enabled = True
        txtItemDesc.Enabled = True
        cmbEnableDateRange.SelectedIndex = 1

        Select Case cmbSortBy.Text

            Case "DR DATE"
                txtItems.Text = ""
                'GroupBox2.Enabled = True
                txtItems.Enabled = False
                cmbINOUT.Enabled = False

                txtItemDesc.Text = "DR DATE..."
                txtItemDesc.Focus()

            Case "ITEM DESCRIPTION"
                txtItems.Text = ""
                GroupBox2.Enabled = False
                txtItems.Enabled = False
                cmbINOUT.Enabled = False

                txtItemDesc.Text = "ITEM DESCRIPTION..."
                txtItemDesc.Focus()

            Case "REQUESTOR"
                GroupBox2.Enabled = False
                txtItems.Enabled = False
                cmbINOUT.Enabled = False

                txtItemDesc.Text = "REQUESTOR..."
                txtItems.Text = "ITEMS..."
                txtItemDesc.Focus()
            Case "SOURCE"
                GroupBox2.Enabled = False
                txtItems.Enabled = False
                cmbINOUT.Enabled = False

                txtItemDesc.Text = "SOURCE..."
                txtItems.Text = "ITEMS..."
                txtItemDesc.Focus()

            Case "RS NO"
                txtItems.Text = ""
                GroupBox2.Enabled = False
                txtItems.Enabled = False
                cmbINOUT.Enabled = False

                txtItemDesc.Text = "RS NO..."
                txtItemDesc.Focus()
            Case "DR NO"
                txtItems.Text = ""
                GroupBox2.Enabled = False
                txtItems.Enabled = False
                cmbINOUT.Enabled = False

                txtItemDesc.Text = "DR NO..."
                txtItemDesc.Focus()

            Case "CONSESSION TICKET"
                txtItems.Text = ""
                GroupBox2.Enabled = False
                txtItems.Enabled = False
                cmbINOUT.Enabled = False

                txtItemDesc.Text = "CONSESSION TICKET..."
                txtItemDesc.Focus()

            Case "UNIT"
                txtItems.Text = ""
                GroupBox2.Enabled = False
                txtItems.Enabled = False
                cmbINOUT.Enabled = False

                txtItemDesc.Text = "UNIT..."
                txtItemDesc.Focus()
            Case "DRIVER"

                txtItems.Text = ""
                GroupBox2.Enabled = False
                txtItems.Enabled = False
                cmbINOUT.Enabled = False

                txtItemDesc.Text = "DRIVER..."

            Case "WS NO"
                GroupBox2.Enabled = False
                txtItems.Enabled = False
                cmbINOUT.Enabled = False

                txtItemDesc.Text = "WS NO..."
                txtItemDesc.Focus()

            Case "PLATE NO"
                txtItems.Text = ""
                GroupBox2.Enabled = False
                txtItems.Enabled = False
                cmbINOUT.Enabled = False

                txtItemDesc.Text = "PLATE NO..."
                txtItemDesc.Focus()

            Case "REMARKS"
                txtItems.Text = ""
                GroupBox2.Enabled = False
                txtItems.Enabled = False
                cmbINOUT.Enabled = False

                txtItemDesc.Text = "REMARKS..."
                txtItemDesc.Focus()

            Case "DATE RANGE"
                txtItems.Text = ""
                txtItems.Enabled = False
                txtItemDesc.Enabled = False

                GroupBox2.Enabled = True
                txtItems.Enabled = False
                cmbINOUT.Enabled = False
                cmbEnableDateRange.Enabled = False

            Case "WITHOUT RS AND DR"
                txtItems.Text = ""
                txtItems.Enabled = False
                txtItemDesc.Enabled = False

                GroupBox2.Enabled = True
                txtItems.Enabled = False
                cmbINOUT.Enabled = False
                cmbEnableDateRange.Enabled = False


            Case "IN/OUT"
                txtItems.Text = ""
                txtItems.Enabled = False
                txtItemDesc.Enabled = False

                cmbINOUT.Enabled = True
                cmbEnableDateRange.Enabled = True
                cmbEnableDateRange.SelectedIndex = 0


            Case Else
                GroupBox2.Enabled = False

        End Select

        searching_by = cmbSortBy.Text
    End Sub

    Private Sub search_dr_new(dr_items_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 2)
            newCMD.Parameters.AddWithValue("@dr_items_id", dr_items_id)

            newDR = newCMD.ExecuteReader

            Dim a(33) As String

            While newDR.Read
                a(0) = newDR.Item("dr_items_id").ToString
                a(1) = newDR.Item("dr_no").ToString
                a(2) = newDR.Item("rs_no").ToString
                If newDR.Item("dr_date").ToString = "" Then
                    a(3) = ""
                Else
                    a(3) = Format(Date.Parse(newDR.Item("dr_date").ToString), "MM/dd/yyyy")
                End If

                a(4) = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newDR.Item("item_name").ToString)
                a(29) = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newDR.Item("item_desc").ToString)
                a(5) = newDR.Item("dr_source").ToString
                a(7) = newDR.Item("unit").ToString
                a(8) = newDR.Item("concession_ticket_no").ToString
                a(9) = newDR.Item("operator").ToString
                a(10) = newDR.Item("requestor").ToString
                a(11) = newDR.Item("supplier").ToString 'a(7) source_wh
                a(12) = newDR.Item("check_by").ToString
                a(13) = newDR.Item("received_by").ToString
                a(14) = newDR.Item("dr_info_id").ToString
                a(15) = newDR.Item("rs_id").ToString
                a(16) = newDR.Item("IN_OUT").ToString
                a(19) = IIf(dr_with_rr(newDR.Item("rs_id").ToString) > 0, "", newDR.Item("ws_no").ToString)
                a(21) = newDR.Item("remarks").ToString 'a(11) remarks
                a(20) = newDR.Item("par_rr_item_id").ToString
                a(22) = newDR.Item("SUPPLIER").ToString
                a(23) = newDR.Item("users").ToString.ToUpper
                a(24) = newDR.Item("plate_no").ToString
                a(25) = newDR.Item("rr_no").ToString

                If newDR.Item("price").ToString = "" Then
                    a(27) = 0
                Else
                    a(27) = FormatNumber(CDbl(newDR.Item("price").ToString), 2,,, TriState.True)
                End If

                a(30) = Format(Date.Parse(IIf(IsDate(newDR.Item("rs_date").ToString) = True, newDR.Item("rs_date").ToString, "1900-01-01")), "MM/dd/yyyy")

                If newDR.Item("IN_OUT").ToString = "OUT" Then
                    a(6) = ""
                    a(26) = newDR.Item("qty").ToString
                    a(28) = FormatNumber(CDbl(a(27)) * CDbl(a(26)), 2,,, TriState.True)

                ElseIf newDR.Item("IN_OUT").ToString = "IN" Or newDR.Item("IN_OUT").ToString = "OTHERS" Then
                    a(6) = newDR.Item("qty").ToString
                    a(26) = ""
                    a(28) = FormatNumber(CDbl(a(27)) * CDbl(a(6)), 2,,, TriState.True)

                End If

                Dim lvl As New ListViewItem(a)
                lvl.BackColor = Color.LightYellow

                If lvl_drList.InvokeRequired Then
                    lvl_drList.Invoke(Sub() lvl_drList.Items.Add(lvl))
                Else
                    lvl_drList.Items.Add(lvl)
                End If
            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Sub

    Private Sub search_dr_new1(po_det_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 4)
            newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)

            newDR = newCMD.ExecuteReader

            Dim a(33) As String

            While newDR.Read

                a(0) = newDR.Item("po_det_id").ToString
                a(1) = newDR.Item("dr_no").ToString
                a(2) = newDR.Item("rs_no").ToString
                If newDR.Item("ws_date").ToString = "" Then
                    a(3) = ""
                Else
                    a(3) = Format(Date.Parse(newDR.Item("ws_date").ToString), "MM/dd/yyyy")
                End If

                a(4) = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newDR.Item("item_name").ToString)
                a(29) = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newDR.Item("item_desc").ToString)
                a(5) = newDR.Item("ws_source").ToString
                a(7) = newDR.Item("unit").ToString
                a(8) = newDR.Item("concession_ticket").ToString
                a(9) = newDR.Item("operator").ToString
                a(10) = newDR.Item("requestor").ToString
                a(11) = newDR.Item("supplier").ToString 'a(7) source_wh
                a(12) = newDR.Item("checked_by").ToString
                a(13) = newDR.Item("received_by").ToString
                a(14) = newDR.Item("dr_info_id").ToString
                a(15) = newDR.Item("rs_id").ToString
                a(16) = newDR.Item("IN_OUT").ToString
                a(19) = IIf(dr_with_rr(newDR.Item("rs_id").ToString) > 0, "", newDR.Item("ws_no").ToString)
                a(21) = newDR.Item("remarks").ToString 'a(11) remarks
                a(20) = newDR.Item("par_rr_item_id").ToString
                a(22) = newDR.Item("supplier").ToString
                a(23) = newDR.Item("users").ToString.ToUpper
                a(24) = newDR.Item("plate_no").ToString
                a(25) = newDR.Item("rr_no").ToString
                a(31) = newDR.Item("dr_option").ToString

                If newDR.Item("price").ToString = "" Then
                    a(27) = 0
                Else
                    a(27) = FormatNumber(CDbl(newDR.Item("price").ToString), 2,,, TriState.True)
                End If

                a(30) = Format(Date.Parse(IIf(IsDate(newDR.Item("rs_date").ToString) = True, newDR.Item("rs_date").ToString, "1900-01-01")), "MM/dd/yyyy")

                If newDR.Item("IN_OUT").ToString = "OUT" Then
                    a(6) = ""
                    a(26) = newDR.Item("ws_qty").ToString
                    a(28) = FormatNumber(CDbl(a(27)) * CDbl(a(26)), 2,,, TriState.True)

                ElseIf newDR.Item("IN_OUT").ToString = "IN" Or newDR.Item("IN_OUT").ToString = "OTHERS" Then
                    a(6) = newDR.Item("ws_qty").ToString
                    a(26) = ""
                    a(28) = FormatNumber(CDbl(a(27)) * CDbl(a(6)), 2,,, TriState.True)

                End If

                Dim lvl As New ListViewItem(a)
                lvl.BackColor = Color.LightGreen

                If lvl_drList.InvokeRequired Then
                    lvl_drList.Invoke(Sub() lvl_drList.Items.Add(lvl))
                Else
                    lvl_drList.Items.Add(lvl)
                End If

                search_dr_new2(newDR.Item("rs_id").ToString, newDR.Item("ws_no").ToString)
proceedhere:

            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub search_dr_new2(rs_id As Integer, ws_no As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 5)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.Parameters.AddWithValue("@ws_no", ws_no)

            newDR = newCMD.ExecuteReader

            Dim a(33) As String

            While newDR.Read
                a(0) = newDR.Item("dr_items_id").ToString
                a(1) = newDR.Item("dr_no").ToString
                a(2) = newDR.Item("rs_no").ToString
                If newDR.Item("dr_date").ToString = "" Then
                    a(3) = ""
                Else
                    a(3) = Format(Date.Parse(newDR.Item("dr_date").ToString), "MM/dd/yyyy")
                End If

                a(4) = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newDR.Item("item_name").ToString)
                a(29) = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newDR.Item("item_desc").ToString)
                a(5) = newDR.Item("dr_source").ToString
                a(7) = newDR.Item("unit").ToString
                a(8) = newDR.Item("concession_ticket_no").ToString
                a(9) = newDR.Item("operator").ToString
                a(10) = newDR.Item("requestor").ToString
                a(11) = newDR.Item("supplier").ToString 'a(7) source_wh
                a(12) = newDR.Item("check_by").ToString
                a(13) = newDR.Item("received_by").ToString
                a(14) = newDR.Item("dr_info_id").ToString
                a(15) = newDR.Item("rs_id").ToString
                a(16) = newDR.Item("IN_OUT").ToString
                a(19) = IIf(dr_with_rr(newDR.Item("rs_id").ToString) > 0, "", newDR.Item("ws_no").ToString)
                a(21) = newDR.Item("remarks").ToString 'a(11) remarks
                a(20) = newDR.Item("par_rr_item_id").ToString
                a(22) = newDR.Item("SUPPLIER").ToString
                a(23) = newDR.Item("users").ToString.ToUpper
                a(24) = newDR.Item("plate_no").ToString
                a(25) = newDR.Item("rr_no").ToString

                If newDR.Item("price").ToString = "" Then
                    a(27) = 0
                Else
                    a(27) = FormatNumber(CDbl(newDR.Item("price").ToString), 2,,, TriState.True)
                End If

                a(30) = Format(Date.Parse(IIf(IsDate(newDR.Item("rs_date").ToString) = True, newDR.Item("rs_date").ToString, "1900-01-01")), "MM/dd/yyyy")

                If newDR.Item("IN_OUT").ToString = "OUT" Then
                    a(6) = ""
                    a(26) = newDR.Item("qty").ToString
                    a(28) = FormatNumber(CDbl(a(27)) * CDbl(a(26)), 2,,, TriState.True)

                ElseIf newDR.Item("IN_OUT").ToString = "IN" Or newDR.Item("IN_OUT").ToString = "OTHERS" Then
                    a(6) = newDR.Item("qty").ToString
                    a(26) = ""
                    a(28) = FormatNumber(CDbl(a(27)) * CDbl(a(6)), 2,,, TriState.True)

                End If

                Dim lvl As New ListViewItem(a)
                lvl.BackColor = Color.LightYellow

                If lvl_drList.InvokeRequired Then
                    lvl_drList.Invoke(Sub() lvl_drList.Items.Add(lvl))
                Else
                    lvl_drList.Items.Add(lvl)
                End If

                search_dr_new3(newDR.Item("ws_no").ToString, newDR.Item("dr_no").ToString, newDR.Item("rs_no").ToString)
            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Sub

    Private Sub search_dr_new3(ws_no As String, dr_no As String, rs_no As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 6)
            newCMD.Parameters.AddWithValue("@rs_no", rs_no)
            newCMD.Parameters.AddWithValue("@ws_no", ws_no)
            newCMD.Parameters.AddWithValue("@dr_no", dr_no)
            newDR = newCMD.ExecuteReader

            Dim a(33) As String

            While newDR.Read
                a(0) = newDR.Item("dr_items_id").ToString
                a(1) = newDR.Item("dr_no").ToString
                a(2) = newDR.Item("rs_no").ToString
                If newDR.Item("dr_date").ToString = "" Then
                    a(3) = ""
                Else
                    a(3) = Format(Date.Parse(newDR.Item("dr_date").ToString), "MM/dd/yyyy")
                End If

                a(4) = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newDR.Item("item_name").ToString)
                a(29) = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newDR.Item("item_desc").ToString)
                a(5) = newDR.Item("dr_source").ToString
                a(7) = newDR.Item("unit").ToString
                a(8) = newDR.Item("concession_ticket_no").ToString
                a(9) = newDR.Item("operator").ToString
                a(10) = newDR.Item("requestor").ToString
                a(11) = newDR.Item("supplier").ToString 'a(7) source_wh
                a(12) = newDR.Item("check_by").ToString
                a(13) = newDR.Item("received_by").ToString
                a(14) = newDR.Item("dr_info_id").ToString
                a(15) = newDR.Item("rs_id").ToString
                a(16) = newDR.Item("IN_OUT").ToString
                a(19) = IIf(dr_with_rr(newDR.Item("rs_id").ToString) > 0, "", newDR.Item("ws_no").ToString)
                a(21) = newDR.Item("remarks").ToString 'a(11) remarks
                a(20) = newDR.Item("par_rr_item_id").ToString
                a(22) = newDR.Item("SUPPLIER").ToString
                a(23) = newDR.Item("users").ToString.ToUpper
                a(24) = newDR.Item("plate_no").ToString
                a(25) = newDR.Item("rr_no").ToString

                If newDR.Item("price").ToString = "" Then
                    a(27) = 0
                Else
                    a(27) = FormatNumber(CDbl(newDR.Item("price").ToString), 2,,, TriState.True)
                End If

                a(30) = Format(Date.Parse(IIf(IsDate(newDR.Item("rs_date").ToString) = True, newDR.Item("rs_date").ToString, "1900-01-01")), "MM/dd/yyyy")

                If newDR.Item("IN_OUT").ToString = "OUT" Then
                    a(6) = ""
                    a(26) = newDR.Item("qty").ToString
                    a(28) = FormatNumber(CDbl(a(27)) * CDbl(a(26)), 2,,, TriState.True)

                ElseIf newDR.Item("IN_OUT").ToString = "IN" Or newDR.Item("IN_OUT").ToString = "OTHERS" Then
                    a(6) = newDR.Item("qty").ToString
                    a(26) = ""
                    a(28) = FormatNumber(CDbl(a(27)) * CDbl(a(6)), 2,,, TriState.True)

                End If

                Dim lvl As New ListViewItem(a)
                If lvl_drList.InvokeRequired Then
                    lvl_drList.Invoke(Sub() lvl_drList.Items.Add(lvl))
                Else
                    lvl_drList.Items.Add(lvl)
                End If
            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Sub

    'SEARCH FOR RS NO
    Private Sub search_dr_new4(rs_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 9)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader

            Dim a(33) As String

            While newDR.Read

                a(2) = newDR.Item("rs_no").ToString
                a(5) = newDR.Item("source").ToString
                a(10) = newDR.Item("requestor").ToString
                a(16) = newDR.Item("IN_OUT").ToString
                a(32) = row_no

                Dim lvl As New ListViewItem(a)
                lvl.BackColor = Color.DarkGreen
                lvl.ForeColor = Color.White
                lvl.Font = New Font("Arial", 12, FontStyle.Italic)


                If lvl_drList.InvokeRequired Then
                    lvl_drList.Invoke(Sub()
                                          lvl_drList.Items.Add(lvl)
                                      End Sub)
                Else
                    lvl_drList.Items.Add(lvl)
                End If

                row_no += 1

                search_dr_new5(newDR.Item("rs_id").ToString)
            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    'RS -> WS
    Private Sub search_dr_new5(rs_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 10)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader

            Dim a(33) As String

            While newDR.Read

                a(0) = newDR.Item("po_det_id").ToString
                a(1) = newDR.Item("dr_no").ToString
                a(2) = newDR.Item("rs_no").ToString

                If newDR.Item("ws_date").ToString = "" Then
                    a(3) = ""
                Else
                    a(3) = Format(Date.Parse(newDR.Item("ws_date").ToString), "MM/dd/yyyy")
                End If

                a(4) = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newDR.Item("item_name").ToString)
                a(29) = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newDR.Item("item_desc").ToString)
                a(5) = newDR.Item("ws_source").ToString
                a(7) = newDR.Item("unit").ToString
                a(8) = newDR.Item("concession_ticket").ToString
                a(9) = newDR.Item("operator").ToString
                a(10) = newDR.Item("requestor").ToString
                a(11) = newDR.Item("supplier").ToString 'a(7) source_wh
                a(12) = newDR.Item("checked_by").ToString
                a(13) = newDR.Item("received_by").ToString
                a(14) = newDR.Item("dr_info_id").ToString
                a(15) = newDR.Item("rs_id").ToString
                a(16) = newDR.Item("IN_OUT").ToString
                a(19) = IIf(dr_with_rr(newDR.Item("rs_id").ToString) > 0, "", newDR.Item("ws_no").ToString)
                a(21) = newDR.Item("remarks").ToString 'a(11) remarks
                a(20) = newDR.Item("par_rr_item_id").ToString
                a(22) = newDR.Item("supplier").ToString
                a(23) = newDR.Item("users").ToString.ToUpper
                a(24) = newDR.Item("plate_no").ToString
                a(25) = newDR.Item("rr_no").ToString
                a(31) = newDR.Item("dr_option").ToString
                a(32) = row_no

                If newDR.Item("price").ToString = "" Then
                    a(27) = 0
                Else
                    a(27) = FormatNumber(CDbl(newDR.Item("price").ToString), 2,,, TriState.True)
                End If

                a(30) = Format(Date.Parse(IIf(IsDate(newDR.Item("rs_date").ToString) = True, newDR.Item("rs_date").ToString, "1900-01-01")), "MM/dd/yyyy")

                If newDR.Item("IN_OUT").ToString = "OUT" Then
                    a(6) = ""
                    a(26) = newDR.Item("ws_qty").ToString
                    a(28) = FormatNumber(CDbl(a(27)) * CDbl(a(26)), 2,,, TriState.True)

                ElseIf newDR.Item("IN_OUT").ToString = "IN" Or newDR.Item("IN_OUT").ToString = "OTHERS" Then
                    a(6) = newDR.Item("ws_qty").ToString
                    a(26) = ""
                    a(28) = FormatNumber(CDbl(a(27)) * CDbl(a(6)), 2,,, TriState.True)

                End If

                Dim lvl2 As New ListViewItem(a)
                lvl2.BackColor = Color.LightGreen

                If lvl_drList.InvokeRequired Then
                    lvl_drList.Invoke(Sub()
                                          lvl_drList.Items.Add(lvl2)
                                          Label7.Text = newDR.Item("po_det_id").ToString & " - " & newDR.Item("item_desc").ToString
                                      End Sub)
                Else
                    lvl_drList.Items.Add(lvl2)
                    Label7.Text = newDR.Item("po_det_id").ToString & " - " & newDR.Item("item_desc").ToString
                End If
                row_no += 1
                search_dr_new6(newDR.Item("rs_id").ToString, newDR.Item("ws_no").ToString)
            End While

        Catch ex As Exception

            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            search_dr_new8(rs_id)
            newSQ.connection.Close()
        End Try
    End Sub
    'RS->WS->DR OUT
    Private Sub search_dr_new6(rs_id As Integer, ws_no As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 6)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.Parameters.AddWithValue("@ws_no", ws_no)

            newDR = newCMD.ExecuteReader

            Dim a(33) As String

            While newDR.Read

                a(0) = newDR.Item("dr_items_id").ToString
                a(1) = newDR.Item("dr_no").ToString
                a(2) = newDR.Item("rs_no").ToString
                If newDR.Item("dr_date").ToString = "" Then
                    a(3) = ""
                Else
                    a(3) = Format(Date.Parse(newDR.Item("dr_date").ToString), "MM/dd/yyyy")
                End If

                a(4) = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newDR.Item("item_name").ToString)
                a(29) = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newDR.Item("item_desc").ToString)
                a(5) = newDR.Item("dr_source").ToString
                a(7) = newDR.Item("unit").ToString
                a(8) = newDR.Item("concession_ticket_no").ToString
                a(9) = newDR.Item("operator").ToString
                a(10) = newDR.Item("requestor").ToString
                a(11) = newDR.Item("supplier").ToString 'a(7) source_wh
                a(12) = newDR.Item("check_by").ToString
                a(13) = newDR.Item("received_by").ToString
                a(14) = newDR.Item("dr_info_id").ToString
                a(15) = newDR.Item("rs_id").ToString
                a(16) = newDR.Item("IN_OUT").ToString
                a(19) = IIf(dr_with_rr(newDR.Item("rs_id").ToString) > 0, "", newDR.Item("ws_no").ToString)
                a(21) = newDR.Item("remarks").ToString 'a(11) remarks
                a(20) = newDR.Item("par_rr_item_id").ToString
                a(22) = newDR.Item("SUPPLIER").ToString
                a(23) = newDR.Item("users").ToString.ToUpper
                a(24) = newDR.Item("plate_no").ToString
                a(25) = newDR.Item("rr_no").ToString
                a(32) = row_no

                If newDR.Item("price").ToString = "" Then
                    a(27) = 0
                Else
                    a(27) = FormatNumber(CDbl(newDR.Item("price").ToString), 2,,, TriState.True)
                End If

                a(30) = Format(Date.Parse(IIf(IsDate(newDR.Item("rs_date").ToString) = True, newDR.Item("rs_date").ToString, "1900-01-01")), "MM/dd/yyyy")

                If newDR.Item("IN_OUT").ToString = "OUT" Then
                    a(6) = ""
                    a(26) = newDR.Item("qty").ToString
                    a(28) = FormatNumber(CDbl(a(27)) * CDbl(a(26)), 2,,, TriState.True)

                ElseIf newDR.Item("IN_OUT").ToString = "IN" Or newDR.Item("IN_OUT").ToString = "OTHERS" Then
                    a(6) = newDR.Item("qty").ToString
                    a(26) = ""
                    a(28) = FormatNumber(CDbl(a(27)) * CDbl(a(6)), 2,,, TriState.True)

                End If

                Dim lvl3 As New ListViewItem(a)
                lvl3.BackColor = Color.LightYellow

                If lvl_drList.InvokeRequired Then
                    lvl_drList.Invoke(Sub()
                                          lvl_drList.Items.Add(lvl3)
                                          Label7.Text = newDR.Item("dr_items_id").ToString & " - " & newDR.Item("item_desc").ToString
                                      End Sub)
                Else
                    lvl_drList.Items.Add(lvl3)
                    Label7.Text = newDR.Item("dr_items_id").ToString & " - " & newDR.Item("item_desc").ToString
                End If

                row_no += 1

                search_dr_new7(newDR.Item("rs_no").ToString, newDR.Item("ws_no").ToString, newDR.Item("dr_no").ToString)
            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    'RS->WS->DR IN
    Private Sub search_dr_new7(rs_no As String, ws_no As String, dr_no As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 61)
            newCMD.Parameters.AddWithValue("@rs_no", rs_no)
            newCMD.Parameters.AddWithValue("@ws_no", ws_no)
            newCMD.Parameters.AddWithValue("@dr_no", dr_no)

            newDR = newCMD.ExecuteReader

            Dim a(33) As String

            While newDR.Read

                a(0) = newDR.Item("dr_items_id").ToString
                a(1) = newDR.Item("dr_no").ToString
                a(2) = newDR.Item("rs_no").ToString
                If newDR.Item("dr_date").ToString = "" Then
                    a(3) = ""
                Else
                    a(3) = Format(Date.Parse(newDR.Item("dr_date").ToString), "MM/dd/yyyy")
                End If

                a(4) = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newDR.Item("item_name").ToString)
                a(29) = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newDR.Item("item_desc").ToString)
                a(5) = newDR.Item("dr_source").ToString
                a(7) = newDR.Item("unit").ToString
                a(8) = newDR.Item("concession_ticket_no").ToString
                a(9) = newDR.Item("operator").ToString
                a(10) = newDR.Item("requestor").ToString
                a(11) = newDR.Item("supplier").ToString 'a(7) source_wh
                a(12) = newDR.Item("check_by").ToString
                a(13) = newDR.Item("received_by").ToString
                a(14) = newDR.Item("dr_info_id").ToString
                a(15) = newDR.Item("rs_id").ToString
                a(16) = newDR.Item("IN_OUT").ToString
                a(19) = IIf(dr_with_rr(newDR.Item("rs_id").ToString) > 0, "", newDR.Item("ws_no").ToString)
                a(21) = newDR.Item("remarks").ToString 'a(11) remarks
                a(20) = newDR.Item("par_rr_item_id").ToString
                a(22) = newDR.Item("SUPPLIER").ToString
                a(23) = newDR.Item("users").ToString.ToUpper
                a(24) = newDR.Item("plate_no").ToString
                a(25) = newDR.Item("rr_no").ToString
                a(32) = row_no

                If newDR.Item("price").ToString = "" Then
                    a(27) = 0
                Else
                    a(27) = FormatNumber(CDbl(newDR.Item("price").ToString), 2,,, TriState.True)
                End If

                a(30) = Format(Date.Parse(IIf(IsDate(newDR.Item("rs_date").ToString) = True, newDR.Item("rs_date").ToString, "1900-01-01")), "MM/dd/yyyy")

                If newDR.Item("IN_OUT").ToString = "OUT" Then
                    a(6) = ""
                    a(26) = newDR.Item("qty").ToString
                    a(28) = FormatNumber(CDbl(a(27)) * CDbl(a(26)), 2,,, TriState.True)

                ElseIf newDR.Item("IN_OUT").ToString = "IN" Or newDR.Item("IN_OUT").ToString = "OTHERS" Then
                    a(6) = newDR.Item("qty").ToString
                    a(26) = ""
                    a(28) = FormatNumber(CDbl(a(27)) * CDbl(a(6)), 2,,, TriState.True)

                End If

                Dim lvl3 As New ListViewItem(a)
                lvl3.BackColor = Color.LightYellow

                If lvl_drList.InvokeRequired Then
                    lvl_drList.Invoke(Sub()
                                          lvl_drList.Items.Add(lvl3)
                                          Label7.Text = newDR.Item("dr_items_id").ToString & " - " & newDR.Item("item_desc").ToString
                                      End Sub)
                Else
                    lvl_drList.Items.Add(lvl3)
                    Label7.Text = newDR.Item("dr_items_id").ToString & " - " & newDR.Item("item_desc").ToString
                End If

                row_no += 1

            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    'RS->WS->DR OTHERS
    Private Sub search_dr_new8(rs_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 62)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader

            Dim a(33) As String

            While newDR.Read

                a(0) = newDR.Item("dr_items_id").ToString
                a(1) = newDR.Item("dr_no").ToString
                a(2) = newDR.Item("rs_no").ToString
                If newDR.Item("dr_date").ToString = "" Then
                    a(3) = ""
                Else
                    a(3) = Format(Date.Parse(newDR.Item("dr_date").ToString), "MM/dd/yyyy")
                End If

                a(4) = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newDR.Item("item_name").ToString)
                a(29) = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newDR.Item("item_desc").ToString)
                a(5) = newDR.Item("dr_source").ToString
                a(7) = newDR.Item("unit").ToString
                a(8) = newDR.Item("concession_ticket_no").ToString
                a(9) = newDR.Item("operator").ToString
                a(10) = newDR.Item("requestor").ToString
                a(11) = newDR.Item("supplier").ToString 'a(7) source_wh
                a(12) = newDR.Item("check_by").ToString
                a(13) = newDR.Item("received_by").ToString
                a(14) = newDR.Item("dr_info_id").ToString
                a(15) = newDR.Item("rs_id").ToString
                a(16) = newDR.Item("IN_OUT").ToString
                a(19) = IIf(dr_with_rr(newDR.Item("rs_id").ToString) > 0, "", newDR.Item("ws_no").ToString)
                a(21) = newDR.Item("remarks").ToString 'a(11) remarks
                a(20) = newDR.Item("par_rr_item_id").ToString
                a(22) = newDR.Item("SUPPLIER").ToString
                a(23) = newDR.Item("users").ToString.ToUpper
                a(24) = newDR.Item("plate_no").ToString
                a(25) = newDR.Item("rr_no").ToString
                a(32) = row_no

                If newDR.Item("price").ToString = "" Then
                    a(27) = 0
                Else
                    a(27) = FormatNumber(CDbl(newDR.Item("price").ToString), 2,,, TriState.True)
                End If

                a(30) = Format(Date.Parse(IIf(IsDate(newDR.Item("rs_date").ToString) = True, newDR.Item("rs_date").ToString, "1900-01-01")), "MM/dd/yyyy")

                If newDR.Item("IN_OUT").ToString = "OUT" Then
                    a(6) = ""
                    a(26) = newDR.Item("qty").ToString
                    a(28) = FormatNumber(CDbl(a(27)) * CDbl(a(26)), 2,,, TriState.True)

                ElseIf newDR.Item("IN_OUT").ToString = "IN" Or newDR.Item("IN_OUT").ToString = "OTHERS" Then
                    a(6) = newDR.Item("qty").ToString
                    a(26) = ""
                    a(28) = FormatNumber(CDbl(a(27)) * CDbl(a(6)), 2,,, TriState.True)

                End If

                Dim lvl3 As New ListViewItem(a)
                lvl3.BackColor = Color.LightYellow

                If lvl_drList.InvokeRequired Then
                    lvl_drList.Invoke(Sub()
                                          lvl_drList.Items.Add(lvl3)
                                          Label7.Text = newDR.Item("dr_items_id").ToString & " - " & newDR.Item("item_desc").ToString
                                      End Sub)
                Else
                    lvl_drList.Items.Add(lvl3)
                    Label7.Text = newDR.Item("dr_items_id").ToString & " - " & newDR.Item("item_desc").ToString
                End If

                row_no += 1

            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Function dr_with_rr(rs_id As Integer) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 22)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                dr_with_rr = newDR.Item("count_rr_with_dr").ToString
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Function
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Dispose()

    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        abortsearching = True

        Try
            If abortsearching = True Then
                thread.Abort()
            End If

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                Timer1.Stop()
                Timer2.Stop()
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub txtItemDesc_TextChanged(sender As Object, e As EventArgs) Handles txtItemDesc.TextChanged

    End Sub

    Private Sub txtItemDesc_GotFocus(sender As Object, e As EventArgs) Handles txtItemDesc.GotFocus

        Select Case txtItemDesc.Text
            Case "RS NO..."
                txtItemDesc.ForeColor = Color.Black
                txtItemDesc.Clear()
            Case "DR NO..."
                txtItemDesc.ForeColor = Color.Black
                txtItemDesc.Clear()
            Case "WS NO..."
                txtItemDesc.ForeColor = Color.Black
                txtItemDesc.Clear()
            Case "DRIVER..."
                txtItemDesc.ForeColor = Color.Black
                txtItemDesc.Clear()
            Case "PLATE NO..."
                txtItemDesc.ForeColor = Color.Black
                txtItemDesc.Clear()
            Case "UNIT..."
                txtItemDesc.ForeColor = Color.Black
                txtItemDesc.Clear()
            Case "ITEM DESCRIPTION..."
                txtItemDesc.ForeColor = Color.Black
                txtItemDesc.Clear()
            Case "CONSESSION TICKET..."
                txtItemDesc.ForeColor = Color.Black
                txtItemDesc.Clear()
            Case "REQUESTOR..."
                txtItemDesc.ForeColor = Color.Black
                txtItemDesc.Clear()
            Case "SOURCE..."
                txtItemDesc.ForeColor = Color.Black
                txtItemDesc.Clear()
            Case "REMARKS..."
                txtItemDesc.ForeColor = Color.Black
                txtItemDesc.Clear()
        End Select

        txtItemDesc.BackColor = Color.Yellow
    End Sub

    Private Sub txtItems_TextChanged(sender As Object, e As EventArgs) Handles txtItems.TextChanged

    End Sub

    Private Sub txtItemDesc_Leave(sender As Object, e As EventArgs) Handles txtItemDesc.Leave

        If txtItemDesc.Text = "" Then
            Select Case cmbSortBy.Text
                Case "DR DATE"
                    txtItemDesc.Text = "DR DATE..."
                    txtItemDesc.ForeColor = Color.Gray
                Case "ITEM DESCRIPTION"
                    txtItemDesc.Text = "ITEM DESCRIPTION..."
                    txtItemDesc.ForeColor = Color.Gray
                Case "REQUESTOR"
                    txtItemDesc.Text = "REQUESTOR..."
                    txtItemDesc.ForeColor = Color.Gray
                Case "SOURCE"
                    txtItemDesc.Text = "SOURCE..."
                    txtItemDesc.ForeColor = Color.Gray
                Case "RS NO"
                    txtItemDesc.Text = "RS NO..."
                    txtItemDesc.ForeColor = Color.Gray
                Case "DR NO"
                    txtItemDesc.Text = "DR NO..."
                    txtItemDesc.ForeColor = Color.Gray
                Case "CONSESSION TICKET"
                    txtItemDesc.Text = "CONSESSION TICKET..."
                    txtItemDesc.ForeColor = Color.Gray
                Case "UNIT"
                    txtItemDesc.Text = "UNIT..."
                    txtItemDesc.ForeColor = Color.Gray
                Case "DRIVER"
                    txtItemDesc.Text = "DRIVER..."
                    txtItemDesc.ForeColor = Color.Gray
                Case "WS NO"
                    txtItemDesc.Text = "WS NO..."
                    txtItemDesc.ForeColor = Color.Gray
                Case "PLATE NO"
                    txtItemDesc.Text = "PLATE NO..."
                    txtItemDesc.ForeColor = Color.Gray

                Case "REMARKS"
                    txtItemDesc.Text = "REMARKS..."
                    txtItemDesc.ForeColor = Color.Gray
            End Select
        End If

        txtItemDesc.BackColor = Color.White
    End Sub

    Private Sub txtItems_GotFocus(sender As Object, e As EventArgs) Handles txtItems.GotFocus
        If txtItems.Text = "ITEMS..." Then
            txtItems.Text = ""
        End If
        txtItems.BackColor = Color.Yellow
        txtItems.ForeColor = Color.Black
    End Sub

    Private Sub txtItems_Leave(sender As Object, e As EventArgs) Handles txtItems.Leave
        If txtItems.Text = "" Then
            txtItems.Text = "ITEMS..."
        End If

        txtItems.ForeColor = Color.Gray
        txtItems.BackColor = Color.White
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        If Not thread2.IsAlive Then
            Timer3.Stop()
            Panel4.Visible = False
        Else
            Panel4.Visible = True
        End If
    End Sub

    Private Sub SupplierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupplierToolStripMenuItem.Click
        With EditDR1

            .cmbOperator.Enabled = False
            .txtSpecificColumn.Enabled = True
            .txtSpecificColumn.Clear()
            .dtpDrDate.Enabled = False
            editspecificdr = "supplier"

            .ShowDialog()

        End With
    End Sub

    Private Sub PlateNOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlateNOToolStripMenuItem.Click
        With EditDR1

            .cmbOperator.Enabled = False
            .txtSpecificColumn.Enabled = True
            .txtSpecificColumn.Clear()
            .dtpDrDate.Enabled = False
            editspecificdr = "plateno"

            .ShowDialog()

        End With
    End Sub

    Private Sub DRNOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DRNOToolStripMenuItem.Click
        With EditDR1
            'FILTER FOR RS/DR = N/A
            If lvl_drList.SelectedItems(0).SubItems(2).Text.ToUpper.Contains("N/A") And lvl_drList.SelectedItems(0).SubItems(1).Text.ToUpper.Contains("N/A") Then
                MessageBox.Show("This data is not applicable to edit dr..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            .cmbOperator.Enabled = False
            .txtSpecificColumn.Enabled = True
            .txtSpecificColumn.Clear()
            .dtpDrDate.Enabled = False
            editspecificdr = "drno"

            .ShowDialog()

        End With
    End Sub

    Private Sub ConToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConToolStripMenuItem.Click
        With EditDR1

            .cmbOperator.Enabled = False
            .txtSpecificColumn.Enabled = True
            .txtSpecificColumn.Clear()
            .dtpDrDate.Enabled = False
            editspecificdr = "Concession"
            'load_operator()

            .ShowDialog()

        End With
    End Sub

    Private Sub ReceivedByToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReceivedByToolStripMenuItem.Click
        With EditDR1

            .cmbOperator.Enabled = False
            .txtSpecificColumn.Enabled = True
            .txtSpecificColumn.Clear()
            .dtpDrDate.Enabled = False
            editspecificdr = "received by"
            'load_operator()

            .ShowDialog()

        End With
    End Sub

    Private Sub PriceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PriceToolStripMenuItem.Click
        With EditDR1

            .cmbOperator.Enabled = False
            .txtSpecificColumn.Enabled = True
            .txtSpecificColumn.Clear()
            .dtpDrDate.Enabled = False
            editspecificdr = "price"
            'load_operator()

            .ShowDialog()

        End With
    End Sub

    Public Sub EditOperatorDriverToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditOperatorDriverToolStripMenuItem.Click
        With EditDR1
            .cmbOperator.Enabled = True
            .txtSpecificColumn.Enabled = False
            .dtpDrDate.Enabled = False
            editspecificdr = "operator"


            'check if null ang operator_id 
            'kung null outsource
            'kung naay sulod insource

            Dim dr_item_id As Integer = lvl_drList.SelectedItems(0).Text

            If check_operator_id_if_null(dr_item_id) = "null" Then
                load_outsource_operator()
            ElseIf check_operator_id_if_null(dr_item_id) = "not-null" Then
                load_operator()
            End If

            .ShowDialog()

        End With

    End Sub
    Public Sub load_outsource_operator()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        EditDR1.cmbOperator.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt3", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 59)
            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                EditDR1.cmbOperator.Items.Add(newDR.Item("operator_outsource").ToString)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Public Function check_operator_id_if_null(dr_item_id As Integer) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt3", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 58)
            newCMD.Parameters.AddWithValue("@dr_item_id", dr_item_id)

            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                check_operator_id_if_null = newDR.Item("operator_if_null").ToString
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Sub load_operator()
        With EditDR1
            .cmbOperator.Items.Clear()

            Dim sqlcon As New SQLcon
            Dim sqldr As SqlDataReader
            Dim cmd As SqlCommand

            Try
                sqlcon.connection1.Open()
                publicquery = "SELECT operator_name FROM dboperator ORDER BY operator_name ASC"
                cmd = New SqlCommand(publicquery, sqlcon.connection1)
                sqldr = cmd.ExecuteReader
                While sqldr.Read
                    .cmbOperator.Items.Add(sqldr.Item("operator_name").ToString)
                End While
                sqldr.Close()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                sqlcon.connection1.Close()
            End Try
        End With

    End Sub

    Private Sub EditToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        With EditDR1

            .cmbOperator.Enabled = False
            .txtSpecificColumn.Enabled = False
            .dtpDrDate.Enabled = True
            editspecificdr = "date"
            .ShowDialog()

        End With

    End Sub

    Private Sub DRDateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DRDateToolStripMenuItem.Click
        With EditDR1

            .cmbOperator.Enabled = False
            .txtSpecificColumn.Enabled = False
            .txtSpecificColumn.Clear()
            .dtpDrDate.Enabled = True
            editspecificdr = "drdate"

            .ShowDialog()

        End With
    End Sub

    Private Sub RemarksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemarksToolStripMenuItem.Click
        With EditDR1

            .cmbOperator.Enabled = False
            .txtSpecificColumn.Enabled = True
            .txtSpecificColumn.Clear()
            .dtpDrDate.Enabled = False
            editspecificdr = "remarks"

            .ShowDialog()

        End With
    End Sub

    Private Sub CheckedByToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckedByToolStripMenuItem.Click
        With EditDR1

            .cmbOperator.Enabled = False
            .txtSpecificColumn.Enabled = True
            .txtSpecificColumn.Clear()
            .dtpDrDate.Enabled = False
            editspecificdr = "checkedby"

            .ShowDialog()

        End With
    End Sub

    Private Sub OTHERSToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub INToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INToolStripMenuItem.Click
        Dim dr_in As Decimal

        For Each row As ListViewItem In lvl_drList.Items
            If row.Selected = True Then
                dr_in += IIf(IsNumeric(row.SubItems(6).Text) = False, 0, row.SubItems(6).Text)
            End If
        Next

        MessageBox.Show("CALCULATE IN/OTHERS: " & vbCrLf & dr_in, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub OUTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OUTToolStripMenuItem.Click
        Dim dr_out As Decimal

        For Each row As ListViewItem In lvl_drList.Items
            If row.Selected = True Then
                'Select Case row.BackColor
                '    Case Color.DarkGreen

                '    Case Color.LightGreen

                '    Case Color.LightYellow

                '    Case Color.White
                '        dr_out += IIf(IsNumeric(row.SubItems(26).Text) = False, 0, row.SubItems(26).Text)
                'End Select

                dr_out += IIf(IsNumeric(row.SubItems(26).Text) = False, 0, row.SubItems(26).Text)
            End If
        Next


        MessageBox.Show("CALCULATE OUT: " & vbCrLf & dr_out, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ExportToExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToExcelToolStripMenuItem.Click

        Dim xlApp As New Excel.Application

        Try
            Dim SaveFileDialog1 As New SaveFileDialog
            SaveFileDialog1.Title = "Save Excel File"
            SaveFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx"
            SaveFileDialog1.ShowDialog()

            'exit if no file selected
            If SaveFileDialog1.FileName = "" Then
                Exit Sub
            End If

            'create objects to interface to Excel
            Dim xls As New Excel.Application
            Dim book As Excel.Workbook
            Dim sheet As Excel.Worksheet

            Dim chartRange As Excel.Range
            Dim chartRange1 As Excel.Range

            'create a workbook and get reference to first worksheet
            xls.Workbooks.Add()
            book = xls.ActiveWorkbook
            sheet = book.ActiveSheet
            'step through rows and columns and copy data to worksheet
            Dim row As Integer = 2
            Dim col As Integer = 1
            Dim c As Integer = 1
            Dim excel_array() As String = New String() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V"}
            Dim excel_index As Integer = 1
            Dim iii As Integer = 0

            sheet.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange, sheet.Range("$A$1:$V$1"), , Excel.XlYesNoGuess.xlYes).Name = "Table1"

            '~~> Format the table
            sheet.ListObjects("Table1").TableStyle = "TableStyleLight9"

            sheet.Cells(1, 1) = "RS No."
            sheet.Cells(1, 2) = "REQUESTOR"
            sheet.Cells(1, 3) = "DR DATE/DATE SERVED"
            sheet.Cells(1, 4) = "DATE REQUEST"
            sheet.Cells(1, 5) = "DR NO."
            sheet.Cells(1, 6) = "PLATE NO."
            sheet.Cells(1, 7) = "DRIVER"
            sheet.Cells(1, 8) = "WS NO./PO NO."
            sheet.Cells(1, 9) = "RR NO."
            sheet.Cells(1, 10) = "ITEM NAME"
            sheet.Cells(1, 11) = "ITEM DESCRIPTION"
            sheet.Cells(1, 12) = "UNIT"
            sheet.Cells(1, 13) = "SOURCE"
            sheet.Cells(1, 14) = "CONCESSION TICKET"
            sheet.Cells(1, 15) = "QTY OUT"
            sheet.Cells(1, 16) = "QTY IN"
            sheet.Cells(1, 17) = "PRICE"
            sheet.Cells(1, 18) = "TOTAL AMOUNT"
            sheet.Cells(1, 19) = "SUPPLIER"
            sheet.Cells(1, 20) = "CHECKED BY"
            sheet.Cells(1, 21) = "RECEIVED BY"
            sheet.Cells(1, 22) = "REMARKS"

            'For Each item As ListViewItem In LVLEquipList.Items

            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Dim col1, row1 As Integer
            row1 = 2
            col1 = 1

            chartRange1 = sheet.Range(excel_array(3) & 1, excel_array(3) & 1)
            chartRange1.EntireColumn.NumberFormat = "@"

            For Each rows As ListViewItem In lvl_drList.Items
                'If rows.Selected = True Then
                If rows.BackColor = Color.DarkGreen Then

                ElseIf rows.BackColor = Color.White Then

                Else

                    sheet.Cells(row1, 1) = rows.SubItems(2).Text
                    sheet.Cells(row1, 2) = rows.SubItems(10).Text
                    sheet.Cells(row1, 3) = rows.SubItems(3).Text
                    sheet.Cells(row1, 4) = rows.SubItems(30).Text
                    sheet.Cells(row1, 5) = rows.SubItems(1).Text
                    sheet.Cells(row1, 6) = rows.SubItems(24).Text
                    sheet.Cells(row1, 7) = rows.SubItems(9).Text
                    sheet.Cells(row1, 8) = rows.SubItems(19).Text
                    sheet.Cells(row1, 9) = rows.SubItems(25).Text
                    sheet.Cells(row1, 10) = rows.SubItems(4).Text
                    sheet.Cells(row1, 11) = rows.SubItems(29).Text
                    sheet.Cells(row1, 12) = rows.SubItems(7).Text
                    sheet.Cells(row1, 13) = rows.SubItems(5).Text
                    sheet.Cells(row1, 14) = rows.SubItems(8).Text
                    sheet.Cells(row1, 15) = rows.SubItems(26).Text
                    sheet.Cells(row1, 16) = rows.SubItems(6).Text
                    sheet.Cells(row1, 17) = rows.SubItems(27).Text
                    sheet.Cells(row1, 18) = rows.SubItems(28).Text
                    sheet.Cells(row1, 19) = rows.SubItems(22).Text
                    sheet.Cells(row1, 20) = rows.SubItems(12).Text
                    sheet.Cells(row1, 21) = rows.SubItems(13).Text
                    sheet.Cells(row1, 22) = rows.SubItems(21).Text

                    chartRange1 = sheet.Range(excel_array(3) & row1, excel_array(3) & row1)
                    chartRange1.EntireColumn.NumberFormat = "@"

                    chartRange = sheet.Range(excel_array(0) & 1, excel_array(15) & 1)

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
                End If
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

    Private Sub RemarksToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        With EditDR1

            .cmbOperator.Enabled = False
            .txtSpecificColumn.Enabled = True
            .txtSpecificColumn.Clear()
            .dtpDrDate.Enabled = False
            editspecificdr = "remarks"

            .ShowDialog()

        End With
    End Sub

    Private Sub SourceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SourceToolStripMenuItem.Click
        'button_click_name = "SourceToolStripMenuItem"
        charge_to_destination = 13
        'public_rowind = rowind
        target_location_project = "FDRLIST1"
        load_charges_category()

        FCharge_To.ShowDialog()

    End Sub

    Public Sub load_charges_category()
        FCharge_To.cmbTypeofCharge.Items.Clear()

        Dim charges_category_data As New Model._Mod_Charges_Category
        charges_category_data.clear_parameter()
        charges_category_data.cStoreProcedureName = "proc_charges2"
        charges_category_data.parameter("@n", 2)

        Dim listofchargescat = charges_category_data.LISTOFCHARGESCATEGORY

        'ADDITIONAL CATEGORY
        Dim ct As New Model._Mod_Charges_Category.Charges_Category_Fields
        ct.charges_category_name = "WAREHOUSE"
        listofchargescat.Add(ct)

        Dim ct1 As New Model._Mod_Charges_Category.Charges_Category_Fields
        ct1.charges_category_name = "PROJECT"

        listofchargescat.Add(ct1)

        'SORT THE LIST
        Dim loc = From aa In listofchargescat
                  Select aa.charges_category_name Order By charges_category_name Ascending


        With FCharge_To

            For Each row In loc
                .cmbTypeofCharge.Items.Add(row)
            Next

        End With
    End Sub

    Private Sub CMS_lvlDRList_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CMS_lvlDRList.Opening
        If pub_user_id = 91 Then
            DateLogToolStripMenuItem.Visible = True
        Else
            DateLogToolStripMenuItem.Visible = False
        End If

        If lvl_drList.SelectedItems.Count = 0 Then
            For Each itm As ToolStripItem In CMS_lvlDRList.Items
                itm.Enabled = False
            Next
            Exit Sub
        End If

        With lvl_drList
            If .SelectedItems(0).BackColor = Color.DarkGreen Then 'DARKGREEN
                For Each itm As ToolStripItem In CMS_lvlDRList.Items
                    If itm.Name = "EditToolStripMenuItem" Then
                        itm.Enabled = True
                    ElseIf itm.Name = "CalculateQtyToolStripMenuItem" Then
                        itm.Enabled = True
                    Else
                        itm.Enabled = False
                    End If

                Next
            ElseIf .SelectedItems(0).BackColor = Color.LightGreen Then 'LIGHTGREEN
                For Each itm As ToolStripItem In CMS_lvlDRList.Items
                    If itm.Name = "EditToolStripMenuItem" Then
                        itm.Enabled = True
                    ElseIf itm.Name = "CalculateQtyToolStripMenuItem" Then
                        itm.Enabled = True
                    ElseIf itm.Name = "GenerateReportToolStripMenuItem" Then
                        itm.Enabled = True
                    Else
                        itm.Enabled = False
                    End If

                Next
            ElseIf .SelectedItems(0).BackColor = Color.LightYellow Then 'LIGHTYELLOW
                For Each itm As ToolStripItem In CMS_lvlDRList.Items
                    itm.Enabled = True
                Next
            End If

        End With
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click

    End Sub

    Private Sub txtItems_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItems.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub WSNOToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles WSNOToolStripMenuItem2.Click
        With EditDR1

            .cmbOperator.Enabled = False
            .txtSpecificColumn.Enabled = True
            .txtSpecificColumn.Clear()
            .dtpDrDate.Enabled = False
            editspecificdr = "wsno"
            .txtSpecificColumn.Focus()

            .ShowDialog()

        End With
    End Sub

    Private Sub WithdrawnByToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WithdrawnByToolStripMenuItem.Click

        If lvl_drList.SelectedItems(0).BackColor = Color.LightYellow Then
            MessageBox.Show("Not applicable for dr.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        With EditDR1

            .cmbOperator.Enabled = False
            .txtSpecificColumn.Enabled = True
            .txtSpecificColumn.Clear()
            .dtpDrDate.Enabled = False
            editspecificdr = "withdrawnby"
            .txtSpecificColumn.Focus()

            .ShowDialog()

        End With
    End Sub

    Private Sub RequestorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RequestorToolStripMenuItem.Click
        With lvl_drList
            If .SelectedItems(0).BackColor = Color.DarkGreen Then 'DARKGREEN

            ElseIf .SelectedItems(0).BackColor = Color.LightGreen Then 'LIGHTGREEN

            ElseIf .SelectedItems(0).BackColor = Color.LightYellow Then 'LIGHTYELLOW
                Dim dr As New Class_DR
                Dim inout As String = lvl_drList.SelectedItems(0).SubItems(16).Text
                Dim consession As String = lvl_drList.SelectedItems(0).SubItems(8).Text
                Dim dr_no As String = lvl_drList.SelectedItems(0).SubItems(1).Text

                If inout = "IN" Then
#Region "==> EDIT REQUEST BY IN TRANSACTION"
                    If dr.dr_exist("OUT", dr_no) > 0 Then
                        button_click_name = "RequestorToolStripMenuItem"
                        FListOfItems.cmboptions.Text = "HAULING AND CRUSHING"
                        FListOfItems.cmboptions.Enabled = False

                        FListOfItems.ShowDialog()

                    Else
                        MessageBox.Show("To edit a requestor, you can go to Requisition Form" & vbCrLf & "using right click > Create Charges.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
#End Region

                ElseIf inout = "OUT" Then
#Region "EDIT REQUEST BY OUT TRANSACTION"
                    If dr.dr_exist("IN", dr_no) > 0 Then
                        MessageBox.Show("Please select 'IN' row to edit the requestor.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        MessageBox.Show("To edit a requestor, you can go to Requisition Form" & vbCrLf & "using right click > Create Charges.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
#End Region

                ElseIf inout = "OTHERS" Then
                    Dim rsNo As String = lvl_drList.SelectedItems(0).SubItems(2).Text
                    Dim drNo As String = lvl_drList.SelectedItems(0).SubItems(1).Text

                    If rsNo.ToUpper() = "N/A" And drNo.ToUpper() = "N/A" Then
#Region "EDIT OTHERS WITHOUT RS AND DR"

                        editByRequestor_othersWithoutRs()
#End Region

                    ElseIf rsNo.ToUpper() = "N/A" And drNo.ToUpper() <> "N/A" Then
#Region "EDIT OTHERS WITHOUT RS BUT WITH DR"
                        editByRequestor_othersWithoutRs()
#End Region
                    Else
                        MessageBox.Show("To edit a requestor, you can go to Requisition Form" & vbCrLf & "using right click > Create Charges.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                End If

                'If dr.concession_exist("IN", consession) > 0 Then
                '    If inout = "OUT" Then

                '        'With EditDR1
                '        '    .cmbOperator.Enabled = False
                '        '    .txtSpecificColumn.Enabled = True
                '        '    .txtSpecificColumn.Clear()
                '        '    .dtpDrDate.Enabled = False
                '        '    editspecificdr = "requestor"
                '        '    .ShowDialog()
                '        'End With

                '        MessageBox.Show("Unable to edit Requestor.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                '    ElseIf inout = "IN" Then
                '        button_click_name = "RequestorToolStripMenuItem"
                '        FListOfItems.cmboptions.Text = "HAULING AND CRUSHING"
                '        FListOfItems.cmboptions.Enabled = False

                '        FListOfItems.ShowDialog()

                '    End If
                'Else
                '    MessageBox.Show("To edit a requestor, you can go to Requisition Form" & vbCrLf & "using right click > Create Charges.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                'End If
            End If
        End With
    End Sub

    Private Sub editByRequestor_othersWithoutRs()
        button_click_name = "edit requestor from drlist1 - OTHERS WITHOUT RS"
        FListOfItems.cmboptions.SelectedIndex = 1
        FListOfItems.cmboptions.Enabled = False

        Dim importantIds As New important_ids
        importantIds.rs_id = lvl_drList.SelectedItems(0).SubItems(15).Text
        FListOfItems.setIds(importantIds)

        FListOfItems.ShowDialog()
    End Sub

    Private Delegate Sub del_search_dr()

    Private Sub search_dr()
        If InvokeRequired Then
            Invoke(New del_search_dr(AddressOf search_dr))
            Exit Sub
        End If

        Dim datefrom As DateTime
        Dim dateto As DateTime

        datefrom = Date.Parse(dtpfrom.Text)
        dateto = Date.Parse(dtpto.Text)

        newDR.cListOfDr.Clear()
        newWS.cListOfWs.Clear()
        newDR.cListOfReportedDR.Clear()
        cNewListOfDr.Clear()


        'Label11.Text = "Waiting..."
        'Label12.Text = "waiting..."
        'Label13.Text = "waiting..."

        'If (Not BackgroundWorker1.IsBusy) Then
        '    BackgroundWorker1.RunWorkerAsync()
        'Else
        '    MessageBox.Show("can't run in twice..", "SUPPLY INFO:", MessageBoxButtons.OK)
        '    Exit Sub
        'End If

        newDR._initialize(datefrom, dateto, cmbSortBy.Text, txtItemDesc.Text, IIf(cmbEnableDateRange.Text = "ENABLE DATE RANGE", True, False))
        cListOfThread.Add(newDR.trd)
        cListOfThread.Add(newDR.trd2)

        newWS._initialize(datefrom, dateto, cmbSortBy.Text, txtItemDesc.Text, IIf(cmbEnableDateRange.Text = "ENABLE DATE RANGE", True, False))
        cListOfThread.Add(newWS.trd)

        newPO._initialize()
        cListOfThread.Add(newPO.trd)

        'BackgroundWorker4.RunWorkerAsync()
        'merge_dr_data()

        For Each thread In cListOfThread
            thread.Join()
        Next


        'Dim newTrd As Threading.Thread
        'newTrd = New Threading.Thread(AddressOf execute_sorted_dr)
        'newTrd.Start("date_served")

        execute_sorted_dr("date_served")
    End Sub
    Private Delegate Sub del_merge_dr_data()

    Private Sub merge_dr_data()
        If InvokeRequired Then
            Invoke(New del_merge_dr_data(AddressOf merge_dr_data))
            Exit Sub
        End If

        'Panel4.Visible = False
        Dim newD As New dr_list
        'ADD dr
        For Each row As class_new_dr.dr In newDR.cListOfDr
            With newD
                .rs_id = row.rs_id
                .dr_item_id = row.dr_item_id
                .rs_no = row.rs_no
                .requestor = row.requestor
                .dr_date = row.dr_date
                .date_request = row.rs_date  'IIf(row.inout = "IN", check_if_pair(row.dr_no, row.rs_date), row.rs_date)
                .dr_no = row.dr_no
                .plateno = row.plateno
                .driver = row.driver
                '.ws_po_no = IIf(row.inout = "OUT", row.ws_no, row.po_no)
                .ws_po_no = row.ws_no
                .rr_no = row.rr_no
                .item_name = row.item_name
                .item_desc = row.item_desc
                .unit = row.unit
                .source = row.dr_source
                .concession_ticket = row.concession_ticket
                .dr_qty = row.dr_qty
                .price = row.price
                .total_amount = row.total_amount
                .supplier = row.supplier
                .checked_by = row.checked_by
                .received_by = row.received_by
                .remarks = row.remarks
                .user = row.input_user
                .inout = row.inout
                .dr_option = row.dr_option
                .wh_id = row.wh_id
                .source2 = row.source2
                .date_submitted = row.date_submitted
                .requestor_without_rs = row.requestor_without_rs

                cNewListOfDr.Add(newD)
            End With
        Next

        'Add withdrawal withour dr
        For Each row As class_ws.ws In newWS.cListOfWs
            With newD

                .dr_item_id = row.ws_id
                .rs_no = row.rs_no
                .requestor = row.requestor
                .dr_date = row.ws_date
                .date_request = row.rs_date
                .dr_no = row.dr_no
                .plateno = row.plateno
                .driver = row.driver
                .ws_po_no = row.ws_no
                .rr_no = row.rr_no
                .item_name = row.item_name
                .item_desc = row.item_desc
                .unit = row.unit
                .source = row.ws_source
                .concession_ticket = row.concession_ticket
                .dr_qty = row.ws_qty
                .price = row.price
                .total_amount = row.total_amount
                .supplier = row.supplier
                .checked_by = row.checked_by
                .received_by = ""
                .approved_by = row.approved_by
                .withdrawn_by = row.withdrawn_by
                .source2 = row.source2
                .remarks = row.remarks
                .user = row.users
                .inout = row.inout
                .dr_option = row.dr_option
                .wh_id = row.wh_id

                cNewListOfDr.Add(newD)
            End With
        Next
    End Sub

    Private Delegate Sub del_execute_sorted_dr(sortby As String)
    Private Sub execute_sorted_dr(sortby As String)
        If InvokeRequired Then
            Invoke(New del_execute_sorted_dr(AddressOf execute_sorted_dr), sortby)
            Exit Sub
        End If

        lvl_drList.Items.Clear()
        ProgressBar1.Value = 0
        ProgressBar1.Style = ProgressBarStyle.Blocks
        ProgressBar1.Maximum = cNewListOfDr.Count

        Dim ListOfDr = Nothing

        Dim dr = cNewListOfDr
        Dim reporteddr = newDR.cListOfReportedDR

        Select Case sortby
            Case "date_served"
                ListOfDr = From row In dr
                           Group Join row2 In reporteddr On row2.dr_item_id Equals row.dr_item_id
                                Into newList = Group
                           From row2 In newList.DefaultIfEmpty()
                           Select row.dr_item_id, row.dr_no, row.rs_no,
                                   row.dr_date, row.item_name, row.source,
                                   row.dr_qty, row.unit, row.concession_ticket, row.driver,
                                   row.requestor, row.checked_by, row.received_by, row.rs_id,
                                   row.inout, row.ws_po_no, row.remarks, row.supplier, row.user,
                                   row.plateno, row.price, row.item_desc, row.dr_option, row.withdrawn_by,
                                   row.rr_no, row.date_request, row2.reported_dr_id, row2.reported_user, row.wh_id,
                                   row.source2, row.date_submitted, row.requestor_without_rs
                           Order By dr_date, dr_no, dr_item_id Ascending

            Case "Item Description"
                ListOfDr = From row In dr
                           Group Join row2 In reporteddr On row2.dr_item_id Equals row.dr_item_id
                                Into newList = Group
                           From row2 In newList.DefaultIfEmpty()
                           Select row.dr_item_id, row.dr_no, row.rs_no,
                                   row.dr_date, row.item_name, row.source,
                                   row.dr_qty, row.unit, row.concession_ticket, row.driver,
                                   row.requestor, row.checked_by, row.received_by, row.rs_id,
                                   row.inout, row.ws_po_no, row.remarks, row.supplier, row.user,
                                   row.plateno, row.price, row.item_desc, row.dr_option, row.withdrawn_by,
                                   row.rr_no, row.date_request, row2.reported_dr_id, row2.reported_user,
                                   row.wh_id, row.source2, row.date_submitted, row.requestor_without_rs
                           Order By item_desc, dr_date Ascending
            Case "Source"
                ListOfDr = From row In dr
                           Group Join row2 In reporteddr On row2.dr_item_id Equals row.dr_item_id
                                Into newList = Group
                           From row2 In newList.DefaultIfEmpty()
                           Select row.dr_item_id, row.dr_no, row.rs_no,
                                   row.dr_date, row.item_name, row.source,
                                   row.dr_qty, row.unit, row.concession_ticket, row.driver,
                                   row.requestor, row.checked_by, row.received_by, row.rs_id,
                                   row.inout, row.ws_po_no, row.remarks, row.supplier, row.user,
                                   row.plateno, row.price, row.item_desc, row.dr_option, row.withdrawn_by,
                                   row.rr_no, row.date_request, row2.reported_dr_id, row2.reported_user,
                                   row.wh_id, row.source2, row.date_submitted, row.requestor_without_rs
                           Order By source, dr_date Ascending

            Case "Operator"
                ListOfDr = From row In dr
                           Group Join row2 In reporteddr On row2.dr_item_id Equals row.dr_item_id
                                Into newList = Group
                           From row2 In newList.DefaultIfEmpty()
                           Select row.dr_item_id, row.dr_no, row.rs_no,
                                   row.dr_date, row.item_name, row.source,
                                   row.dr_qty, row.unit, row.concession_ticket, row.driver,
                                   row.requestor, row.checked_by, row.received_by, row.rs_id,
                                   row.inout, row.ws_po_no, row.remarks, row.supplier, row.user,
                                   row.plateno, row.price, row.item_desc, row.dr_option, row.withdrawn_by,
                                   row.rr_no, row.date_request, row2.reported_dr_id, row2.reported_user,
                                   row.wh_id, row.source2, row.date_submitted, row.requestor_without_rs
                           Order By driver, dr_date Ascending

            Case "Supplier"
                ListOfDr = From row In dr
                           Group Join row2 In reporteddr On row2.dr_item_id Equals row.dr_item_id
                                Into newList = Group
                           From row2 In newList.DefaultIfEmpty()
                           Select row.dr_item_id, row.dr_no, row.rs_no,
                                   row.dr_date, row.item_name, row.source,
                                   row.dr_qty, row.unit, row.concession_ticket, row.driver,
                                   row.requestor, row.checked_by, row.received_by, row.rs_id,
                                   row.inout, row.ws_po_no, row.remarks, row.supplier, row.user,
                                   row.plateno, row.price, row.item_desc, row.dr_option, row.withdrawn_by,
                                   row.rr_no, row.date_request, row2.reported_dr_id, row2.reported_user,
                                   row.wh_id, row.source2, row.date_submitted, row.requestor_without_rs
                           Order By supplier, dr_date Ascending

            Case "Plate No."
                ListOfDr = From row In dr
                           Group Join row2 In reporteddr On row2.dr_item_id Equals row.dr_item_id
                                Into newList = Group
                           From row2 In newList.DefaultIfEmpty()
                           Select row.dr_item_id, row.dr_no, row.rs_no,
                                   row.dr_date, row.item_name, row.source,
                                   row.dr_qty, row.unit, row.concession_ticket, row.driver,
                                   row.requestor, row.checked_by, row.received_by, row.rs_id,
                                   row.inout, row.ws_po_no, row.remarks, row.supplier, row.user,
                                   row.plateno, row.price, row.item_desc, row.dr_option, row.withdrawn_by,
                                   row.rr_no, row.date_request, row2.reported_dr_id, row2.reported_user,
                                   row.wh_id, row.source2, row.date_submitted, row.requestor_without_rs
                           Order By plateno, dr_date Ascending
            Case "Requestor"
                ListOfDr = From row In dr
                           Group Join row2 In reporteddr On row2.dr_item_id Equals row.dr_item_id
                                Into newList = Group
                           From row2 In newList.DefaultIfEmpty()
                           Select row.dr_item_id, row.dr_no, row.rs_no,
                                   row.dr_date, row.item_name, row.source,
                                   row.dr_qty, row.unit, row.concession_ticket, row.driver,
                                   row.requestor, row.checked_by, row.received_by, row.rs_id,
                                   row.inout, row.ws_po_no, row.remarks, row.supplier, row.user,
                                   row.plateno, row.price, row.item_desc, row.dr_option, row.withdrawn_by,
                                   row.rr_no, row.date_request, row2.reported_dr_id, row2.reported_user,
                                   row.wh_id, row.source2, row.date_submitted, row.requestor_without_rs
                           Order By requestor, dr_date Ascending
        End Select


        pub_List_of_Dr = pub_List_of_Dr


        Dim LviewItem As New List(Of ListViewItem)

        For Each row In ListOfDr
            Dim a(38) As String

            a(0) = row.dr_item_id
            a(1) = row.dr_no
            a(2) = row.rs_no
            a(3) = row.dr_date
            a(4) = row.item_name
            a(5) = row.source2

            Select Case row.inout
                Case "IN"
                    a(6) = row.dr_qty
                    a(26) = "-"
                    a(10) = row.requestor
                Case "OUT"
                    a(6) = "-"
                    a(26) = row.dr_qty
                    a(10) = row.requestor
                Case "OTHERS"
                    a(6) = row.dr_qty
                    a(26) = "-"

#Region "OTHERS WITHOUT RS"
                    With row.requestor
                        If .ToString().ToUpper() = "N/A" Or .ToString().ToUpper() = "" Then
                            a(5) = row.source
                            a(10) = row.requestor_without_rs
                        Else
                            a(10) = row.requestor
                        End If
                    End With
#End Region

            End Select

            a(7) = row.unit
            a(8) = row.concession_ticket
            a(9) = row.driver

            a(11) = ""
            a(12) = IIf(row.dr_option = "WITHOUT DR", "", row.checked_by)
            a(13) = row.received_by
            a(14) = 0
            a(15) = row.rs_id
            a(16) = row.inout
            a(17) = ""
            a(18) = ""
            a(19) = IIf(row.rs_no.ToUpper() = "N/A" And row.inout = "IN", "-", row.ws_po_no)
            a(21) = row.remarks
            a(22) = row.supplier
            a(23) = row.user
            a(24) = row.plateno
            a(25) = row.rr_no
            a(27) = FormatNumber(row.price, 2,,, TriState.False)
            a(28) = FormatNumber((row.price * row.dr_qty), 2,,, TriState.False) 'row.total_amount


            Dim properNaming As New PropsFields.whItems_properName_fields
            'properNaming = getProperNameUsingWhPnId2(row.wh)
            Dim propNaming As String = ""

            If properNaming IsNot Nothing Then
                'propNaming = properNaming
            End If
            a(29) = row.item_desc


            a(30) = IIf(row.rs_no.Contains("N/A"), "-", row.date_request)
            a(31) = row.dr_option
            a(33) = IIf(row.inout = "OUT", row.withdrawn_by, "")
            a(34) = row.reported_user
            a(35) = row.wh_id
            a(36) = row.source
            a(37) = IIf(row.date_submitted.ToString = "1/1/1990 12:00:00 AM", "", row.date_submitted)

            Dim lvl As New ListViewItem(a)
            lvl.BackColor = IIf(row.dr_option = "WITH DR", Color.LightYellow, Color.LightGreen)
            lvl.ForeColor = IIf(row.reported_dr_id = 0, Color.Black, Color.Red)

            LviewItem.Add(lvl)
            ProgressBar1.Value += 1
            'lvl_drList.Items.Add(lvl)

            Dim Generator As System.Random = New System.Random()
            Label7.Text = "Generating.../Initializing..../RS NO: " & Generator.Next(1000, 100000) & "/DR NO: " & Generator.Next(1000, 100000)
            Application.DoEvents()
        Next

        lvl_drList.Items.AddRange(LviewItem.ToArray())
        lvl_drList.Visible = True
    End Sub

    Private Function check_if_pair(dr_no As String, rs_date As DateTime) As DateTime
        Dim exist As Boolean = False

        For Each row As class_new_dr.dr In newDR.cListOfDr
            If dr_no = row.dr_no And row.inout = "OUT" Then
                check_if_pair = row.rs_date
                exist = True
                Exit For
            End If
        Next

        If exist = False Then
            check_if_pair = rs_date
        End If
    End Function


    Private Delegate Sub delegate_monitor_stat()
    Private Delegate Sub delegate_monitor_stat2()
    Private Delegate Sub delegate_monitor_stat3()
    Private Delegate Sub delegate_monitor_stat4()

    Private Sub monitor_stat()

        Try
            If InvokeRequired Then
                Invoke(New delegate_monitor_stat(AddressOf monitor_stat))
                Exit Sub
            End If

            While finished = False
                'Panel4.Visible = True

                Dim Generator As System.Random = New System.Random()
                Label7.Text = "Generating.../Initializing..../RS NO: " & Generator.Next(1000, 100000) & "/DR NO: " & Generator.Next(1000, 100000)
                Application.DoEvents()
            End While
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub monitor_stat4()

        While newDR.trd2.IsAlive
            If InvokeRequired Then
                Invoke(New delegate_monitor_stat4(AddressOf monitor_stat4))
            Else
                'Label11.Text = "waiting..."
                'Label11.Refresh()

                Panel4.Visible = True
                Dim Generator As System.Random = New System.Random()
                lblRecords.Text = "Generating.../Initializing..../" & Generator.Next(1000, 100000)
                Application.DoEvents()
            End If
        End While

    End Sub

    Private Sub monitor_stat2()
        While newWS.trd.IsAlive
            If InvokeRequired Then
                Invoke(New delegate_monitor_stat2(AddressOf monitor_stat2))
            Else
                'Label12.Text = "waiting..."
                'Label12.Refresh()

                Panel4.Visible = True
                Dim Generator As System.Random = New System.Random()
                lblRecords.Text = "Generating.../Initializing..../" & Generator.Next(1, 1000)

                Application.DoEvents()
            End If
        End While
    End Sub

    Private Sub monitor_stat3()
        While newPO.trd.IsAlive
            If InvokeRequired Then
                Invoke(New delegate_monitor_stat3(AddressOf monitor_stat3))
            Else
                'Label13.Text = "waiting..."
                'Label13.Refresh()

                Panel4.Visible = True
                Dim Generator As System.Random = New System.Random()
                lblRecords.Text = "Generating.../Initializing..../" & Generator.Next(1, 1000)

                Application.DoEvents()
            End If
        End While
    End Sub

    Function DescendingComparison(ByVal valueA As DateTime,
                                  ByVal valueB As DateTime) As Integer
        ' Invert the order of the comparison to sort in descending order.
        Return valueB.CompareTo(valueA)
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Threading.Thread.Sleep(1000)


    End Sub

    Private Sub FDRLIST1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        'Threading.Thread.Sleep(1000)
        'search_dr()

        'INITIALIZE DR,WS,PO
        initialize_dr()

        'this thread is for fake rs_no generated ^_^
        Dim t2 As New Threading.Thread(AddressOf monitor_stat)
        t2.Start()

        For Each thread In cListOfThread
            thread.Join()
        Next

        finished = True

        If Panel4.InvokeRequired Then
            Panel4.Invoke(Sub()
                              lblRecords.Text = CInt(newDR.cListOfDr.Count) + CInt(newWS.cListOfWs.Count) + CInt(newPO.cListofHaulingPO.Count) & " record(s) found..."


                              merge_dr_data() 'merge all data initialized, rs,po,rr,dr

                              execute_sorted_dr("date_served")
                              Panel4.Visible = False
                              btnSearch.Enabled = True
                              finished = False
                          End Sub)
        End If

    End Sub

    Private Delegate Sub del_initialize_dr()

    Private Sub initialize_dr()
        If InvokeRequired Then
            Invoke(New del_initialize_dr(AddressOf initialize_dr))
            Exit Sub
        End If

        BackgroundWorker1.WorkerSupportsCancellation = True
        Panel4.Visible = True

        Dim datefrom As DateTime
        Dim dateto As DateTime

        datefrom = Date.Parse(dtpfrom.Text)
        dateto = Date.Parse(dtpto.Text)

        newDR.cListOfDr.Clear()
        newWS.cListOfWs.Clear()
        newDR.cListOfReportedDR.Clear()
        cNewListOfDr.Clear()

        Dim sortby As String = cmbSortBy.Text
        Dim itemdesc As String = getWhatToSearch() 'txtItemDesc.Text
        Dim enabledaterange As String = cmbEnableDateRange.Text

        'DR
        newDR._initialize(datefrom, dateto, sortby, itemdesc, IIf(enabledaterange = "ENABLE DATE RANGE", True, False), 9655)
        cListOfThread.Add(newDR.trd)
        cListOfThread.Add(newDR.trd2)

        'WS
        newWS._initialize(datefrom, dateto, sortby, itemdesc, IIf(enabledaterange = "ENABLE DATE RANGE", True, False), 9655)
        cListOfThread.Add(newWS.trd)

        'PO
        newPO._initialize()
        cListOfThread.Add(newPO.trd)

    End Sub

    Private Function getWhatToSearch() As String
        Select Case cmbSortBy.Text
            Case "IN/OUT"
                getWhatToSearch = cmbINOUT.Text
            Case Else
                getWhatToSearch = txtItemDesc.Text
        End Select
    End Function

    Private Sub GenerateReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerateReportToolStripMenuItem.Click
        With FSelectItemsForSummaryOFHauledAgg
            .ListView1.Items.Clear()
            .ListView2.Items.Clear()

            DistinctListOfDRRequestor = From row In cNewListOfDr
                                        Select row.requestor Distinct Order By requestor Ascending

            DistinctListOfDRItems = From row In cNewListOfDr
                                    Select row.wh_id, row.item_desc, row.requestor Distinct Order By item_desc Ascending

            For Each row In DistinctListOfDRRequestor
                Dim a(10) As String
                a(1) = row
                Dim lvl As New ListViewItem(a)
                .ListView2.Items.Add(lvl)
            Next

            .ShowDialog()

        End With

        'FPreparedbyvb.t = 1
        'FPreparedbyvb.ShowDialog()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        For Each row As ListViewItem In lvl_drList.Items
            row.Checked = True
        Next
    End Sub

    Private Sub RemovedReportedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemovedReportedToolStripMenuItem.Click
        Dim counter As Integer = 0

        For Each row As ListViewItem In lvl_drList.Items
            If row.Checked = True Then
                counter += 1
            End If
        Next

        If counter = 0 Then
            MessageBox.Show("please select data in a list atleast 1.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If MessageBox.Show("Are you sure you want to remove the reported status from the selected data?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            For Each row As ListViewItem In lvl_drList.Items
                If row.Checked = True Then
                    remove_reported_data(row.Text)
                End If
            Next

            MessageBox.Show("Successfuly removed reported status from selected data..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub remove_reported_data(dr_item_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_dr_list2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 11)
            newCMD.Parameters.AddWithValue("@dr_item_id", dr_item_id)
            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEnableDateRange.SelectedIndexChanged
        If cmbEnableDateRange.Text = "ENABLE DATE RANGE" Then
            GroupBox2.Enabled = True
        Else
            If cmbSortBy.Text = "IN/OUT" Then 'purpose of this filter is to restrict the daterange into enable if searching category is in/out
                cmbEnableDateRange.SelectedIndex = 0
            Else
                GroupBox2.Enabled = False
            End If

        End If
    End Sub

    Private Sub ItemNameToolStripMenuItem_Click(sender As Object, e As EventArgs)
        lvl_drList.Items.Clear()

        cSort = cNewListOfDr
        cSort.Sort(Function(x, y) x.item_desc.CompareTo(y.item_desc))
        'cSort.Sort(Function(x, y) x.dr_date.CompareTo(y.dr_date))

        For Each row As dr_list In cSort
            Dim a(31) As String

            a(0) = row.dr_item_id
            a(1) = row.dr_no
            a(2) = row.rs_no
            a(3) = row.dr_date
            a(4) = row.item_name
            a(5) = row.source

            Select Case row.inout
                Case "IN", "OTHERS"
                    a(6) = row.dr_qty
                    a(26) = "-"
                Case "OUT"
                    a(6) = "-"
                    a(26) = row.dr_qty
            End Select

            a(7) = row.unit
            a(8) = row.concession_ticket
            a(9) = row.driver
            a(10) = row.requestor
            a(11) = ""
            a(12) = row.checked_by
            a(13) = row.approved_by
            a(14) = 0
            a(15) = row.rs_id
            a(16) = row.inout
            a(17) = ""
            a(18) = ""
            a(19) = row.ws_po_no
            a(21) = row.remarks
            a(22) = row.supplier
            a(23) = row.user
            a(24) = row.plateno
            a(25) = row.rr_no
            a(27) = FormatNumber(row.price, 2,,, TriState.False)
            a(28) = FormatNumber(row.price * row.dr_qty, 2,,, TriState.False) 'row.total_amount
            a(29) = row.item_desc
            a(30) = row.date_request
            a(31) = row.dr_option

            Dim lvl As New ListViewItem(a)

            lvl.BackColor = IIf(row.dr_option = "WITH DR", Color.LightYellow, Color.LightGreen)
            lvl_drList.Items.Add(lvl)

        Next
    End Sub

    Private Sub BackgroundWorker3_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker3.DoWork
        Threading.Thread.Sleep(1000)
    End Sub

    Private Sub ItemDescToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItemDescToolStripMenuItem.Click
        execute_sorted_dr("Item Description")
    End Sub

    Private Sub DRDateServedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DRDateServedToolStripMenuItem.Click
        execute_sorted_dr("date_served")
    End Sub

    Private Sub PlateNoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PlateNoToolStripMenuItem1.Click
        execute_sorted_dr("Plate No.")
    End Sub

    Private Sub RequestorToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RequestorToolStripMenuItem1.Click
        execute_sorted_dr("Requestor")
    End Sub


    Private Sub reported_unreported(rep As String)

        lvl_drList.Items.Clear()

        Dim ListOfDr2 = Nothing
        Dim dr = cNewListOfDr
        Dim reporteddr = newDR.cListOfReportedDR

        ListOfDr2 = From row In dr
                    Group Join row2 In reporteddr On row2.dr_item_id Equals row.dr_item_id
                                Into newList = Group
                    From row2 In newList.DefaultIfEmpty()
                    Select row.dr_item_id, row.dr_no, row.rs_no,
                                   row.dr_date, row.item_name, row.source,
                                   row.dr_qty, row.unit, row.concession_ticket, row.driver,
                                   row.requestor, row.checked_by, row.received_by, row.rs_id,
                                   row.inout, row.ws_po_no, row.remarks, row.supplier, row.user,
                                   row.plateno, row.price, row.item_desc, row.dr_option, row.withdrawn_by,
                                   row.rr_no, row.date_request, row2.reported_dr_id, row2.reported_user
                    Order By dr_date, item_desc Ascending

        For Each row In ListOfDr2
            Dim a(34) As String

            If row.reported_user <> "" And rep = "Reported" Then
                'continue 
            ElseIf row.reported_user = "" And rep = "Unreported" Then
                'continue 
            Else
                GoTo proceedhere
            End If

            a(0) = row.dr_item_id
            a(1) = row.dr_no
            a(2) = row.rs_no
            a(3) = row.dr_date
            a(4) = row.item_name
            a(5) = row.source

            Select Case row.inout
                Case "IN", "OTHERS"
                    a(6) = row.dr_qty
                    a(26) = "-"
                Case "OUT"
                    a(6) = "-"
                    a(26) = row.dr_qty
            End Select

            a(7) = row.unit
            a(8) = row.concession_ticket
            a(9) = row.driver
            a(10) = row.requestor
            a(11) = ""
            a(12) = IIf(row.dr_option = "WITHOUT DR", "", row.checked_by)
            a(13) = row.received_by
            a(14) = 0
            a(15) = row.rs_id
            a(16) = row.inout
            a(17) = ""
            a(18) = ""
            a(19) = row.ws_po_no
            a(21) = row.remarks
            a(22) = row.supplier
            a(23) = row.user
            a(24) = row.plateno
            a(25) = row.rr_no
            a(27) = FormatNumber(row.price, 2,,, TriState.False)
            a(28) = FormatNumber((row.price * row.dr_qty), 2,,, TriState.False) 'row.total_amount
            a(29) = row.item_desc
            a(30) = IIf(row.rs_no.Contains("N/A"), "-", row.date_request)
            a(31) = row.dr_option
            a(33) = IIf(row.inout = "OUT", row.withdrawn_by, "")
            a(34) = row.reported_user

            Dim lvl As New ListViewItem(a)

            lvl.BackColor = IIf(row.dr_option = "WITH DR", Color.LightYellow, Color.LightGreen)
            lvl.ForeColor = IIf(row.reported_dr_id = 0, Color.Black, Color.Red)

            lvl_drList.Items.Add(lvl)

proceedhere:

        Next
    End Sub

    Private Sub UnreportedToolStripMenuItem_Click(sender As Object, e As EventArgs)
        reported_unreported("Unreported")
    End Sub

    Private Sub ReportedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportedToolStripMenuItem.Click
        reported_unreported("Reported")
    End Sub

    Private Sub UnreportedToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles UnreportedToolStripMenuItem.Click
        reported_unreported("Unreported")
    End Sub

    Private Sub UnselectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnselectAllToolStripMenuItem.Click
        For Each row As ListViewItem In lvl_drList.Items
            row.Checked = False
        Next
    End Sub

    Private Sub CheckSelectedToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CheckSelectedToolStripMenuItem1.Click
        For Each row As ListViewItem In lvl_drList.Items
            If row.Selected = True Then
                row.Checked = True
            End If
        Next
    End Sub

    Private Sub UncheckSelectedsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UncheckSelectedsToolStripMenuItem.Click
        For Each row As ListViewItem In lvl_drList.Items
            If row.Selected = True Then
                row.Checked = False
            End If
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        If BackgroundWorker1.IsBusy Then
            BackgroundWorker1.CancelAsync()
            Exit Sub
        End If

        btnSearch.Enabled = False
        lblRecords.Text = "waiting..."
        ProgressBar1.Style = ProgressBarStyle.Marquee
        'lvl_drList.Visible = False
        'search_dr()
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub bw_search_without_rs_dr_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw_search_without_rs_dr.DoWork

        withoutdr_rs.dr_data_without_rs_dr(Date.Parse(dtpfrom.Text), Date.Parse(dtpto.Text))

    End Sub

    Private Sub BackgroundWorker4_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker4.DoWork

        Dim t As Threading.Thread

        While newDR.trd.IsAlive
            Threading.Thread.Sleep(1)

            'Dim Generator As System.Random = New System.Random()
            'lblRecords.Text = "Generating.../Initializing..../" & Generator.Next(1, 1000)
            t = New Threading.Thread(AddressOf monitor_stat)
            t.Start()
            'Application.DoEvents()

        End While
    End Sub

    Private Sub bw_check_if_done_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw_check_if_done.DoWork
        check_if_done_process()
    End Sub
    Private Sub check_if_done_process()
        While True
            If r1 = True Then
                Exit While
            End If
        End While
    End Sub
    Private Sub SourceToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SourceToolStripMenuItem1.Click
        execute_sorted_dr("Source")
    End Sub

    Private Sub bw_display_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw_display.DoWork

        Dim listofwithoutrsdr = withoutdr_rs.cListOfDrWithourRs_Dr

        Dim a(40) As String

        For Each row In listofwithoutrsdr

            If row.inout = "OUT" Then
                a(6) = "-"
                a(26) = row.dr_qty


            ElseIf row.inout = "IN" Or row.inout = "OTHERS" Then
                a(6) = row.dr_qty
                a(26) = "-"

            End If

            a(0) = row.dr_item_id
            a(1) = row.dr_no
            a(2) = row.rs_no
            a(3) = row.dr_date
            a(4) = row.item_name
            a(5) = row.dr_source
            'a(6) = row.dr_qty
            a(7) = row.unit
            a(8) = row.concession_ticket
            a(9) = row.driver
            a(10) = row.requestor
            a(11) = ""
            a(12) = row.checked_by
            a(13) = row.received_by
            a(14) = 0
            a(15) = row.rs_id
            a(16) = row.inout
            a(17) = "-"
            a(18) = "-"
            a(19) = row.ws_no
            a(20) = 0
            a(21) = row.remarks
            a(22) = row.supplier
            a(23) = row.input_user
            a(24) = row.plateno
            a(25) = row.rr_no
            'a(26) = row.dr_qty
            a(27) = FormatNumber(row.price, 2,,, TriState.True)
            a(28) = FormatNumber(row.total_amount, 2,,, TriState.True)
            a(29) = row.item_desc
            a(30) = row.rs_date
            a(31) = row.dr_option
            a(32) = ""
            a(33) = row.withdrawn_by
            a(35) = row.wh_id
            a(37) = row.date_submitted

            Dim lvl As New ListViewItem(a)
            lvl.BackColor = Color.LightYellow
            listoflistviewitem.Add(lvl)

        Next

    End Sub

    Private Sub SupplierToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SupplierToolStripMenuItem1.Click
        execute_sorted_dr("Supplier")
    End Sub

    Private Sub RemovedSelectedItemsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemovedSelectedItemsToolStripMenuItem.Click

        MessageBox.Show("NOTE: this removed function is temporarily used for aggregates without rs and dr only.", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        If MessageBox.Show("Are you sure you want to removed this selected items/aggregates?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            'removed
            removed_selected_aggregates()
            btnSearch.PerformClick()

        End If
    End Sub

    Private Sub DRWHTOWHToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DRWHTOWHToolStripMenuItem.Click

        'BW_Loading.WorkerSupportsCancellation = True
        'BW_Loading.RunWorkerAsync()

        lblWait.Visible = True

        BW_edit_wh_to_wh.WorkerSupportsCancellation = True
        BW_edit_wh_to_wh.RunWorkerAsync()

        'Dim rs_no As String = lvl_drList.SelectedItems(0).SubItems(2).Text
        'Dim dr_item_id As Integer = lvl_drList.SelectedItems(0).Text

        'whTOwh = New FWHtoWH

        'With whTOwh

        '    Dim wh_to_wh As New class_DR2
        '    wh_to_wh._initialize(rs_no, Nothing, .dgvData, 2, dr_item_id)

        '    .ShowDialog()
        'End With

    End Sub


    Private Function get_listofdr(Optional dr_no As String = "") As Integer
        Dim dr As New Model._Mod_DR

        dr.parameter("@n", 4)
        dr.parameter("@where", $"where a.dr_no = '{dr_no}'")

        For Each row In dr.LISTOFDR()
            get_listofdr += 1
        Next
    End Function

    Private Sub StockpileQuaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockpileQuaryToolStripMenuItem.Click
        Dim inout As String = lvl_drList.SelectedItems(0).SubItems(16).Text

        Select Case inout
            Case "OTHERS", "IN"
                With EditDR1

                    .cmbOperator.Enabled = False
                    .txtSpecificColumn.Enabled = True
                    .txtSpecificColumn.Clear()
                    .dtpDrDate.Enabled = False
                    editspecificdr = "quarryarea"

                    Dim othercharges As New Model._Mod_Charges
                    othercharges.clear_parameter()
                    othercharges.parameter("@n", 3)

                    Dim listofcharges As New List(Of String)
                    For Each x In othercharges.LISTOFCHARGES()
                        listofcharges.Add(x.charges_desc)
                    Next

                    Dim placholder1 As New class_placeholder4

                    placholder1.king_placeholder_textbox("Quarry Area", EditDR1.txtSpecificColumn, listofcharges, EditDR1.Panel1, My.Resources.Restriction_icon, False, "White")

                    .ShowDialog()

                End With
            Case "OUT"
                MessageBox.Show("Can't edit quarry area in this procedure if transaction is 'OUT'," &
                                vbCrLf & "to fix this problem, you can go to Warehouse Item Form" & vbCrLf _
                                & "NOTE: please contact the administrator first, Thanks!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Select
    End Sub

    Private Sub BW_edit_wh_to_wh_DoWork(sender As Object, e As DoWorkEventArgs) Handles BW_edit_wh_to_wh.DoWork

        editWhToWh(lvl_drList)

    End Sub
    Public Sub editWhToWh(Optional listview As ListView = Nothing)
        Dim obj As New List(Of Object)


        Dim wh_to_wh As New class_DR2
        whTOwh = New FWHtoWH

        With whTOwh
            If listview.InvokeRequired Then
                listview.Invoke(Sub()
                                    For Each row As ListViewItem In listview.Items
                                        If row.Selected = True Then
                                            'Dim rs_no As String = lvl_drList.SelectedItems(0).SubItems(2).Text
                                            'Dim dr_item_id As Integer = lvl_drList.SelectedItems(0).Text
                                            Dim rs_no As String = row.SubItems(2).Text
                                            Dim dr_item_id As Integer = row.Text

                                            'Dim wh_to_wh As New class_DR2
                                            ''wh_to_wh._initialize(rs_no, Nothing, .dgvData, 2, dr_item_id)
                                            'Dim data = wh_to_wh._initialize_new(rs_no, Nothing, .dgvData, 2, dr_item_id)
                                            'wh_to_wh.display3(.dgvData, data)



                                            Dim data As New List(Of class_DR2.drlist2)
                                            data = Nothing
                                            Dim initializationThread As New Threading.Thread(Sub()

                                                                                                 data = wh_to_wh._initialize_new(rs_no, Nothing, whTOwh.dgvData, 2, dr_item_id)

                                                                                             End Sub)
                                            initializationThread.Start()
                                            initializationThread.Join()

                                            wh_to_wh.display3(whTOwh.dgvData, data)

                                        End If
                                    Next
                                End Sub)
            End If

        End With
    End Sub

    Private Sub removed_selected_aggregates()
        For Each row As ListViewItem In lvl_drList.Items

            If row.Selected = True Then
                If row.SubItems(2).Text.ToUpper.Contains("N/A") And row.SubItems(1).Text.ToUpper.Contains("N/A") Then
                    Dim newSQ As New SQLcon
                    Dim newCMD As SqlCommand

                    Try
                        newSQ.connection.Open()
                        newCMD = New SqlCommand("proc_delete_aggregates", newSQ.connection)
                        newCMD.Parameters.Clear()
                        newCMD.CommandType = CommandType.StoredProcedure

                        newCMD.Parameters.AddWithValue("@n", 1)
                        newCMD.Parameters.AddWithValue("@dr_items_id", row.Text)
                        newCMD.ExecuteNonQuery()

                    Catch ex As Exception
                        MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        newSQ.connection.Close()
                    End Try
                Else
                    MessageBox.Show("DELETE FUNCTION IS FOR AGGREGATES WITHOUT RS AND DR AT THIS MOMENT!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Next
    End Sub

    Private Sub BW_Loading_DoWork(sender As Object, e As DoWorkEventArgs) Handles BW_Loading.DoWork

        If Panel4.InvokeRequired Then
            Panel4.Invoke(Sub()
                              Panel4.Visible = True
                          End Sub)
        Else
            Panel4.Visible = True
        End If

    End Sub

    Private Sub DateSubmittedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DateSubmittedToolStripMenuItem.Click
        With EditDR1

            .cmbOperator.Enabled = False
            .txtSpecificColumn.Enabled = False
            .txtSpecificColumn.Clear()
            .dtpDrDate.Enabled = True
            editspecificdr = "drdatesubmitted"

            .ShowDialog()

        End With
    End Sub

    Private Sub DateLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DateLogToolStripMenuItem.Click
        With EditDR1

            .cmbOperator.Enabled = False
            .txtSpecificColumn.Enabled = False
            .txtSpecificColumn.Clear()
            .dtpDrDate.Enabled = True
            editspecificdr = "drdatelog"

            .ShowDialog()

        End With
    End Sub

    Private Sub INOUTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INOUTToolStripMenuItem.Click
        With EditDR1

            Dim dr_no As String
            Dim rs_no As String

            dr_no = lvl_drList.SelectedItems(0).SubItems(1).Text
            rs_no = lvl_drList.SelectedItems(0).SubItems(2).Text

            If (rs_no.ToUpper = "N/A" And dr_no.ToUpper <> "N/A") Or (rs_no.ToUpper = "N/A" And dr_no.ToUpper = "N/A") Then
                'NO RS BUT WITH DR
                .cmbOperator.Enabled = True
                .cmbOperator.Items.Clear()
                .cmbOperator.Items.Add("IN")
                .cmbOperator.Items.Add("OUT")

                .txtSpecificColumn.Enabled = False
                .txtSpecificColumn.Clear()
                .dtpDrDate.Enabled = False
                editspecificdr = "in/out"

                .ShowDialog()
            ElseIf rs_no.ToUpper <> "N/A" And dr_no.ToUpper <> "N/A" Then
                MessageBox.Show("This function is not applicable for dr that have an RS.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If



        End With
    End Sub

    Private Sub QTYToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QTYToolStripMenuItem.Click
        Dim dr_no As String
        Dim rs_no As String

        dr_no = lvl_drList.SelectedItems(0).SubItems(1).Text
        rs_no = lvl_drList.SelectedItems(0).SubItems(2).Text

        If rs_no.ToUpper <> "N/A" And dr_no.ToUpper <> "N/A" Then
            MessageBox.Show("This function is applicable only when there is no DR or RS number.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else

            With EditDR1
                .cmbOperator.Enabled = False
                .txtSpecificColumn.Enabled = True
                .txtSpecificColumn.Clear()
                .dtpDrDate.Enabled = False
                editspecificdr = "qty"

                .ShowDialog()
            End With

        End If
    End Sub

    Private Sub RSIDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RSIDToolStripMenuItem.Click
        If pub_user_id = 91 Then
            With EditDR1
                .cmbOperator.Enabled = False
                .txtSpecificColumn.Enabled = True
                .txtSpecificColumn.Clear()
                .dtpDrDate.Enabled = False
                editspecificdr = "rs_id"

                .ShowDialog()
            End With
        Else
            MessageBox.Show("Please call the administrator to procceed to this transaction...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub OperatorDriverToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OperatorDriverToolStripMenuItem.Click
        execute_sorted_dr("Operator")
    End Sub

    Private Sub bw_search_without_rs_dr_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw_search_without_rs_dr.RunWorkerCompleted
        r1 = True
    End Sub

    Private Sub bw_check_if_done_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw_check_if_done.RunWorkerCompleted


        bw_display = New BackgroundWorker
        bw_display.WorkerSupportsCancellation = True
        bw_display.RunWorkerAsync()


    End Sub

    Private Sub bw_display_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw_display.RunWorkerCompleted
        If lvl_drList.InvokeRequired Then
            lvl_drList.Invoke(Sub()
                                  lvl_drList.Items.AddRange(listoflistviewitem.ToArray)
                                  Panel4.Visible = False
                              End Sub)
        Else
            lvl_drList.Items.AddRange(listoflistviewitem.ToArray)
            Panel4.Visible = False
        End If

        'lvl_drList.Items.AddRange(listoflistviewitem.ToArray)


        bw_search_without_rs_dr.CancelAsync()
        bw_check_if_done.CancelAsync()
        bw_display.CancelAsync()
    End Sub

    Private Sub BW_edit_wh_to_wh_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BW_edit_wh_to_wh.RunWorkerCompleted
        lblWait.Visible = False
        whTOwh.ShowDialog()

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

    End Sub
End Class

