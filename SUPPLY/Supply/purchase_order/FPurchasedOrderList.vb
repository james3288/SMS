Imports System.ComponentModel
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Linq
Imports Microsoft.Win32
Public Class FPurchasedOrderList

    Public sqlcon As New SQLcon
    Dim panloc As New Point(0, 0)
    Dim curloc As New Point(0, 0)

    Dim SQ As New SQLcon
    Dim CMD As SqlCommand
    Dim DR As SqlDataReader
    Public supply_name As String
    Public po As String

    Public all_rs_no As String
    Public all_charge_to As String

    Private myPO As New CLASS_PO
    Private POData As New Model._Mod_Purchase_Order
    Private cListofListview As New List(Of ListViewItem)
    Private cListOfPo As New List(Of Model._Mod_Purchase_Order.Purchase_Order_Field)


    Private cListOfPoDateLogPrice As New List(Of T_exportDateLogPrice)
    Private forExportExcel As Boolean
    Dim cFileName As String
    Private newAuth As New authType

    Private cProperNames As New Model_ProperNames
    Private customMsg As New customMessageBox

    Public isEditAllPo As Boolean
    Public cPoDetId As Integer
    Private meInstruction As String

#Region "GET"
    Public ReadOnly Property getListOfPo As List(Of Model._Mod_Purchase_Order.Purchase_Order_Field)
        Get
            Return cListOfPo
        End Get
    End Property
#End Region

    Private Sub setpositions()
        panloc = panel_fdate.Location
        curloc = System.Windows.Forms.Cursor.Position
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub FPurchasedOrderList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer_panelmvemEnt.Interval = "1"
        setpositions()
        Label15.Parent = pboxHeader
        pboxHeader.Width = FMain.Width - FMain.ToolStrip1.Width
        ListJobOrderNo.Location = New Point(1000, 1000)
        cmbSearchByCategory.Text = "Search by PO No."
        'btnSearch.PerformClick()

        'load_PO(8)
        panel_fdate.Hide()

        Dim searchbar As New class_placeholder4
        searchbar.king_placeholder_textbox("Search Here...", txtSearch, Nothing, gboxSearch, My.Resources.search, False, "White")

        Dim searchbarby As New class_placeholder4
        searchbarby.king_placeholder_combobox("Search By", cmbSearchByCategory, Nothing, gboxSearch, My.Resources.categories, "White")

        loadItems()
    End Sub

    Private Sub loadItems()
        Try
            cProperNames.initialize(Panel3)
            cProperNames.loadProperNames()
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

#Region "FORM LOAD"

    Public Sub load_PO(ByVal n As Integer)
        lvlpurchasedOrderList.Items.Clear()

        Dim a(24) As String
        Dim c As Integer

        Try
            SQ.connection.Open()

            CMD = New SqlCommand("proc_po_query", SQ.connection)
            CMD.Parameters.Clear()
            CMD.CommandType = CommandType.StoredProcedure

            If cmbSearchByCategory.Text = "Search by PO No." Then
                CMD.Parameters.AddWithValue("@n", 9)
                CMD.Parameters.AddWithValue("@value", txtSearch.Text)

            ElseIf cmbSearchByCategory.Text = "Search by RS No." Then
                CMD.Parameters.AddWithValue("@n", 10)
                CMD.Parameters.AddWithValue("@value", txtSearch.Text)

            ElseIf cmbSearchByCategory.Text = "Search by PO Date" Then
                CMD.Parameters.AddWithValue("@n", 11)
                CMD.Parameters.AddWithValue("@po_date", Date.Parse(dtpSearchPoDATE.Text))

            ElseIf cmbSearchByCategory.Text = "Search by Item Description" Then
                CMD.Parameters.AddWithValue("@n", 12)
                CMD.Parameters.AddWithValue("@value", txtSearch.Text)

            ElseIf cmbSearchByCategory.Text = "Filter by MOnth/Year" Then
                CMD.Parameters.AddWithValue("@n", 13)
                CMD.Parameters.AddWithValue("@po_date", Date.Parse(DTP_dateFrom.Text))
                CMD.Parameters.AddWithValue("@po_date2", Date.Parse(DTP_dateTo.Text))
            ElseIf cmbSearchByCategory.Text = "Search by Charge To" Then
                CMD.Parameters.AddWithValue("@n", 15)

            End If

            DR = CMD.ExecuteReader

            While DR.Read
                a(0) = DR.Item("po_det_id").ToString()
                a(1) = DR.Item("po_no").ToString
                a(2) = DR.Item("rs_no").ToString()
                a(3) = Format(Date.Parse(DR.Item("po_date").ToString()), "MM/dd/yyyy")
                a(4) = DR.Item("Supplier_Name").ToString()
                a(6) = DR.Item("item_desc").ToString
                a(7) = DR.Item("qty").ToString
                a(8) = DR.Item("unit").ToString
                a(9) = FormatNumber(CDbl(DR.Item("unit_price").ToString), 2, , , TriState.True)
                a(10) = FormatNumber(CDbl(DR.Item("qty").ToString) * CDbl(DR.Item("unit_price").ToString), 2, , , TriState.True)
                a(12) = DR.Item("instructor").ToString
                a(13) = DR.Item("Supplier_Location").ToString
                a(14) = DR.Item("terms").ToString
                a(15) = CHARGE_TO(DR.Item("charge_to_id").ToString, DR.Item("charge_type").ToString)
                a(16) = DR.Item("prepared_by").ToString
                a(17) = DR.Item("checked_by").ToString
                a(18) = DR.Item("approved_by").ToString
                a(19) = DR.Item("approved_by").ToString
                a(20) = DR.Item("rs_id").ToString
                a(21) = DR.Item("selected").ToString
                a(22) = DR.Item("po_id").ToString

                'If TYPE_IN_OUT(DR.Item("wh_id").ToString) = "FACILITIES" Or TYPE_IN_OUT(DR.Item("wh_id").ToString) = "TOOLS" Or TYPE_IN_OUT(DR.Item("wh_id").ToString) = "ADD-ON" Then
                '    a(5) = FRequistionForm.GET_ITEM_DESC_FROM_FACILITIES(DR.Item("wh_id").ToString)

                'Else
                '    a(5) = DR.Item("whItem").ToString & " - " & DR.Item("whItemDesc").ToString
                'End If



                'If check_po_received(DR.Item("po_no").ToString) > 0 Then
                '    a(11) = "PURCHASED"
                'Else
                '    a(11) = IIf(DR.Item("selected").ToString = "TRUE", "PO RELEASED", "PO PENDING")
                'End If

                If a(15) = "ADFIL" Then
                    Dim mcharges As String = get_multiple_charges(DR.Item("rs_id").ToString)

                    If mcharges.Length < 1 Then
                    Else
                        mcharges = mcharges.Trim().Substring(0, mcharges.Length - 1)
                        a(15) = a(15) & "(" & UCase(mcharges) & ")"
                    End If
                End If

                If cmbSearchByCategory.Text = "Search by Charge To" Then
                    If a(15) Like "*" & UCase(txtSearch.Text) & "*" Then
                    Else
                        GoTo proceedhere
                    End If
                End If

                Dim lvl As New ListViewItem(a)
                lvlpurchasedOrderList.Items.Add(lvl)

                If a(11) = "PO PENDING" Then
                    lvlpurchasedOrderList.Items(c).BackColor = Color.Red
                    lvlpurchasedOrderList.Items(c).ForeColor = Color.White

                End If

                c += 1

proceedhere:

            End While

            If c = 0 Then
                MessageBox.Show("No data found", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else

            End If

            DR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
            txtSearch.Focus()

        End Try
    End Sub
#End Region

#Region "FUNCTION"
    Public Function TYPE_IN_OUT(ByVal wh_id) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()

            newCMD = New SqlCommand("proc_po_query", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 7)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)

            newDR = newCMD.ExecuteReader
            While newDR.Read
                TYPE_IN_OUT = newDR.Item("IN_OUT").ToString
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
#End Region

    Public Function check_po_received(ByVal id As Integer)

        Dim newsqlcon As New SQLcon
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand

        Try
            newsqlcon.connection.Open()

            publicquery = "SELECT * FROM dbreceiving_info WHERE po_no = '" & id & "'"
            newcmd = New SqlCommand(publicquery, newsqlcon.connection)
            newdr = newcmd.ExecuteReader

            While newdr.Read
                check_po_received = newdr.Item("po_no").ToString
            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
        End Try

    End Function

    Public Function CHARGE_TO(ByVal id As String, ByVal process As String) As String
        Try
            If process = "PROJECT" Then

                Dim sqlcon As New SQLcon

                'sqlcon.set_sql("192.168.1.92", "eus_031916", "sa", "adfil")
                'sqlcon.sql_connect()
                Dim newdr As SqlDataReader
                Dim newcmd As SqlCommand

                sqlcon.connection1.Open()

                publicquery_Psc = "SELECT project_desc FROM dbprojectdesc WHERE proj_id = " & id
                newcmd = New SqlCommand(publicquery_Psc, sqlcon.connection1)
                newdr = newcmd.ExecuteReader

                While newdr.Read
                    CHARGE_TO = newdr.Item("project_desc").ToString
                End While

                newdr.Close()
                sqlcon.connection1.Close()

            ElseIf process = "EQUIPMENT" Then
                Dim sqlcon As New SQLcon

                'sqlcon.set_sql("192.168.1.92", "eus_031916", "sa", "adfil")
                'sqlcon.sql_connect()
                Dim newdr As SqlDataReader
                Dim newcmd As SqlCommand

                sqlcon.connection1.Open()

                publicquery_Psc = "SELECT plate_no FROM dbequipment_list WHERE equipListID = " & id
                newcmd = New SqlCommand(publicquery_Psc, sqlcon.connection1)
                newdr = newcmd.ExecuteReader

                While newdr.Read
                    CHARGE_TO = newdr.Item("plate_no").ToString
                End While

                newdr.Close()
                sqlcon.connection1.Close()

            ElseIf process = "WAREHOUSE" Then
                Dim newsqlconn As New SQLcon
                Dim newdr As SqlDataReader
                Dim newcmd As SqlCommand

                newsqlconn.connection.Open()

                publicquery = "SELECT wh_area FROM dbwh_area WHERE wh_area_id = " & id
                newcmd = New SqlCommand(publicquery, newsqlconn.connection)
                newdr = newcmd.ExecuteReader

                While newdr.Read
                    CHARGE_TO = newdr.Item("wh_area").ToString
                End While

                newdr.Close()
                newsqlconn.connection.Close()

            ElseIf process = "ADFIL" Or process = "PERSONNAL" Or process = "CASH" Then
                Dim newsqlconn As New SQLcon
                Dim newdr As SqlDataReader
                Dim newcmd As SqlCommand

                newsqlconn.connection.Open()

                publicquery = "SELECT charge_to FROM dbCharge_to WHERE charge_to_id = " & id
                newcmd = New SqlCommand(publicquery, newsqlconn.connection)
                newdr = newcmd.ExecuteReader

                While newdr.Read
                    CHARGE_TO = newdr.Item("charge_to").ToString
                End While

                newdr.Close()
                newsqlconn.connection.Close()

            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub cmbSearchByCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSearchByCategory.SelectedIndexChanged
        If cmbSearchByCategory.Text = "Search by RS No." Or
      cmbSearchByCategory.Text = "Search by Item Description" Or
      cmbSearchByCategory.Text = "Search by PO No." Then
            txtSearch.Text = ""
            txtSearch.Enabled = True
            btnSearch.Enabled = True
            panel_fdate.Visible = False
            txtSearch.Focus()

        ElseIf cmbSearchByCategory.Text = "Filter by MOnth/Year" Then
            txtSearch.Enabled = False
            btnSearch.Enabled = False
            panel_fdate.Visible = True

        ElseIf cmbSearchByCategory.Text = "Filter by Date Log" Then
            txtSearch.Enabled = False
            btnSearch.Enabled = False
            panel_fdate.Visible = True

        ElseIf cmbSearchByCategory.Text = "Filter by Date Log and Price" Then
            txtSearch.Enabled = False
            btnSearch.Enabled = False
            panel_fdate.Visible = True

        ElseIf cmbSearchByCategory.Text = "View all PO For Print/Printed" Then
            'po_print()
            po_print1()

        ElseIf cmbSearchByCategory.Text = "Export By Date Log and Price" Then
            txtSearch.Enabled = False
            btnSearch.Enabled = False
            panel_fdate.Visible = True

        End If

        Select Case cmbSearchByCategory.Text
            Case "Search by PO Date"
                dtpSearchPoDATE.Visible = True
                dtpSearchPoDATE.BringToFront()
                dtpSearchPoDATE.Location = New Point(gboxSearch.Width - 406, 889)
                dtpSearchPoDATE.Width = txtSearch.Width
                txtSearch.Visible = False
                panel_fdate.Visible = False
                btnSearch.Enabled = True

            Case Else
                txtSearch.Text = ""
                txtSearch.Visible = True
                dtpSearchPoDATE.Visible = False
                txtSearch.Focus()

        End Select
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        If cmbSearchByCategory.Text = "View all PO For Print/Printed" Then
            po_print()
        Else
            ''po_list(10)

            'Dim n As Integer
            'Select Case cmbSearchByCategory.Text
            '    Case "Search by Charge To"
            '        n = 2
            '    Case Else
            '        n = 1
            'End Select

            'myPO.po_list(n, cmbSearchByCategory.Text, txtSearch.Text, lvlpurchasedOrderList, Panel3)
            ''display_po()

            If Not BW_search.IsBusy Then

                POData.clear_parameter()

                Panel3.Visible = True
                Label7.Text = "Processing data to display..."

                POData.parameter("@searchby", cmbSearchByCategory.Text)
                POData.cStoreProcedureName = "po_query_new2"

                Select Case cmbSearchByCategory.Text
                    Case "Search by PO Date"

                        POData.parameter("@n", 5)
                        POData.parameter("@search", Date.Parse(dtpSearchPoDATE.Text))
                        POData.parameter("@typeofpurchasing", "PURCHASE ORDER")

                    Case Else

                        POData.parameter("@n", 5)
                        POData.parameter("@search", txtSearch.Text)
                        POData.parameter("@typeofpurchasing", "PURCHASE ORDER")

                End Select

                BW_search.WorkerSupportsCancellation = True
                BW_search.RunWorkerAsync()

            End If

        End If

    End Sub


    Private Sub display_po()
        lvlpurchasedOrderList.Items.Clear()
        Dim listoflistview As New List(Of ListViewItem)

        For Each row In myPO.cListOfPO
            Dim a(28) As String

            a(0) = row.po_det_id
            a(1) = row.po_no
            a(2) = row.rs_no
            a(3) = row.po_date
            a(4) = row.Supplier_Name
            a(5) = row.Item_Name
            a(6) = row.Item_Desc
            a(7) = row.qty
            a(8) = row.unit
            a(9) = row.unit_price
            a(10) = row.total_amount
            a(12) = row.instructions
            a(13) = row.address
            a(14) = row.terms
            a(15) = row.charges
            a(16) = row.date_needed
            a(17) = row.prepared_by
            a(18) = row.checked_by
            a(19) = row.approved_by
            a(20) = row.rs_id
            a(21) = row.selected
            a(22) = row.po_id
            a(23) = row.inout
            a(24) = IIf(row.lead_time_rs_to_po < 0, row.lead_time_rs_to_po & " - check po_date", IIf(row.lead_time_rs_to_po > 1, row.lead_time_rs_to_po & " days", row.lead_time_rs_to_po & " day"))
            a(25) = row.print_stats
            a(26) = IIf(row.orig_date_printed = "1990-01-01", "-", row.orig_date_printed)
            a(27) = IIf(row.updated_date_printed = "1990-01-01", "-", row.updated_date_printed)
            a(28) = row.user_logs


            Dim lvl As New ListViewItem(a)
            listoflistview.Add(lvl)
        Next

        lvlpurchasedOrderList.Items.AddRange(listoflistview.ToArray)
    End Sub

    Private Sub display_po1(Optional listofpo As Object = Nothing)

        For Each row As Model._Mod_Purchase_Order.Purchase_Order_Field In cListOfPo
            Dim a(35) As String
            Dim properName As New PropsFields.whItems_properName_fields
            properName = getProperNameUsingWhPnId2(row.wh_pn_id)
            Dim propName As String = ""

            If properName Is Nothing Then
            Else
                propName = properName.item_desc
            End If

            Dim priceWithTax As Double = CreatePurchaseOrderForm.getTaxAndCalculate(row.tax_category, row.unit_price, row.vat_value)

            a(0) = row.po_det_id
            a(1) = row.po_no
            a(2) = row.rs_no
            a(3) = row.po_date
            a(4) = row.Supplier_Name
            a(5) = row.Item_Name
            a(6) = row.Item_Desc & IIf(row.wh_pn_id = 0, "", $" → {propName}")
            a(7) = row.qty
            a(8) = row.unit
            a(9) = row.unit_price
            a(10) = row.qty * priceWithTax
            a(12) = row.instructions
            a(13) = row.address
            a(14) = row.terms
            a(15) = row.charges
            a(16) = row.date_needed
            a(17) = row.prepared_by
            a(18) = row.checked_by
            a(19) = row.approved_by
            a(20) = row.rs_id
            a(21) = row.selected
            a(22) = row.po_id
            a(23) = row.inout
            a(24) = IIf(row.lead_time_rs_to_po < 0, row.lead_time_rs_to_po & " - check po_date", IIf(row.lead_time_rs_to_po > 1, row.lead_time_rs_to_po & " days", row.lead_time_rs_to_po & " day"))
            a(25) = row.print_stats
            a(26) = IIf(row.orig_date_printed = "1990-01-01", "-", row.orig_date_printed)
            a(27) = IIf(row.updated_date_printed = "1990-01-01", "-", row.updated_date_printed)
            a(28) = row.user_logs
            a(29) = row.rs_date
            a(30) = row.type_of_request
            a(31) = row.user_update_log
            a(32) = row.requestor
            a(33) = row.properName
            a(34) = priceWithTax
            a(35) = row.tax_category

            If row.cancel_po = 1 Then
                GoTo escapeHere
            End If

            Dim lvl As New ListViewItem(a)
            cListofListview.Add(lvl)

escapeHere:
        Next

        If isEditAllPo Then
            If lvlpurchasedOrderList.InvokeRequired Then
                lvlpurchasedOrderList.Invoke(Sub()
                                                 listfocus(lvlpurchasedOrderList, cPoDetId)
                                                 isEditAllPo = False
                                             End Sub)
            End If
        End If

    End Sub

    Private Sub po_list(n As Integer)
        lvlpurchasedOrderList.Items.Clear()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim print_stat = "For Print"
        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("po_query_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@searchby", cmbSearchByCategory.Text)

            If cmbSearchByCategory.Text = "Search by PO Date" Then
                newCMD.Parameters.AddWithValue("@search", Format(Date.Parse(dtpSearchPoDATE.Text), "yyyy-MM-dd"))
            ElseIf cmbSearchByCategory.Text = "Filter by MOnth/Year" Then
                newCMD.Parameters.AddWithValue("@date_from", Format(Date.Parse(DTP_dateFrom.Text), "yyyy-MM-dd"))
                newCMD.Parameters.AddWithValue("@date_to", Format(Date.Parse(DTP_dateTo.Text), "yyyy-MM-dd"))
            Else

                newCMD.Parameters.AddWithValue("@search", txtSearch.Text)
            End If

            newDR = newCMD.ExecuteReader

            Dim a(28) As String

            While newDR.Read

                Dim po_date As DateTime = newDR.Item("po_date").ToString
                Dim date_needed As DateTime = newDR.Item("date_needed").ToString
                Dim rs_date As DateTime = newDR.Item("date_req").ToString
                Dim print_date_data As DateTime
                Dim print_date_update As DateTime
                If IsDate(newDR.Item("print_date_logss").ToString) = True Then
                    print_date_data = newDR.Item("print_date_logss").ToString
                Else
                    print_date_data = "1900-01-01"
                End If
                If IsDate(newDR.Item("print_date_update").ToString) = True Then
                    print_date_update = newDR.Item("print_date_update").ToString
                Else
                    print_date_update = "1900-01-01"
                End If

                a(0) = newDR.Item("po_det_id").ToString
                a(1) = newDR.Item("po_no").ToString
                a(2) = newDR.Item("rs_no").ToString
                a(3) = Format(po_date, "MM/dd/yyyy")
                a(4) = newDR.Item("Supplier_Name").ToString
                a(5) = newDR.Item("Item_Name").ToString
                a(6) = newDR.Item("Item_desc").ToString
                a(7) = newDR.Item("qty").ToString
                a(8) = newDR.Item("unit").ToString
                a(9) = FormatNumber(CDbl(newDR.Item("unit_price").ToString), 2, , TriState.True)
                a(10) = FormatNumber(CDbl(newDR.Item("total_amount").ToString), 2, , TriState.True)
                a(12) = newDR.Item("instructions").ToString
                a(13) = newDR.Item("address").ToString
                a(14) = newDR.Item("terms").ToString
                'a(15) = FReceivingReport.multiplecharges(CInt(newDR.Item("rs_id").ToString), 1)
                a(15) = newDR.Item("charges").ToString
                a(16) = Format(date_needed, "MM/dd/yyyy")
                a(17) = newDR.Item("prepared_by").ToString
                a(18) = newDR.Item("checked_by").ToString
                a(19) = newDR.Item("approved_by").ToString
                a(20) = newDR.Item("rs_id").ToString
                a(21) = newDR.Item("selected").ToString
                a(22) = newDR.Item("po_id").ToString
                a(23) = newDR.Item("IN_OUT").ToString
                a(24) = FSummarySupplyTransaction.day_and_days(IIf(DateDiff(DateInterval.Day, rs_date, po_date) < 0, 0, DateDiff(DateInterval.Day, rs_date, po_date)))
                a(25) = newDR.Item("print_stats").ToString
                a(26) = IIf(Format(Date.Parse(print_date_data), "MM/dd/yyyy") = "01/01/1900", "", Format(Date.Parse(print_date_data), "MM/dd/yyyy"))
                a(27) = IIf(Format(Date.Parse(print_date_update), "MM/dd/yyyy") = "01/01/1900", "", Format(Date.Parse(print_date_update), "MM/dd/yyyy"))
                a(28) = newDR.Item("userss").ToString
                Dim lvl As New ListViewItem(a)
                lvlpurchasedOrderList.Items.Add(lvl)

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub po_print()
        lvlpurchasedOrderList.Items.Clear()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        'Dim print_stat = "For Print"
        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("po_query_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 15)
            newDR = newCMD.ExecuteReader

            Dim a(26) As String

            While newDR.Read

                Dim po_date As DateTime = newDR.Item("po_date").ToString
                Dim date_needed As DateTime = newDR.Item("date_needed").ToString
                Dim rs_date As DateTime = newDR.Item("date_req").ToString
                Dim print_date_data As DateTime
                If IsDate(newDR.Item("print_date_logs").ToString) = True Then
                    print_date_data = newDR.Item("print_date_logs").ToString
                Else
                    print_date_data = "1900-01-01"
                End If


                a(0) = newDR.Item("po_det_id").ToString
                a(1) = newDR.Item("po_no").ToString
                a(2) = newDR.Item("rs_no").ToString
                a(3) = Format(po_date, "MM/dd/yyyy")
                a(4) = newDR.Item("Supplier_Name").ToString
                a(5) = newDR.Item("Item_Name").ToString
                a(6) = newDR.Item("Item_desc").ToString
                a(7) = newDR.Item("qty").ToString
                a(8) = newDR.Item("unit").ToString
                a(9) = FormatNumber(CDbl(newDR.Item("unit_price").ToString), 2, , TriState.True)
                a(10) = FormatNumber(CDbl(newDR.Item("total_amount").ToString), 2, , TriState.True)
                a(12) = newDR.Item("instructions").ToString
                a(13) = newDR.Item("location").ToString
                a(14) = newDR.Item("terms").ToString
                'a(15) = FReceivingReport.multiplecharges(CInt(newDR.Item("rs_id").ToString), 1)  IBALIK IF NEEDED value kai ADFIL RA PERME
                a(15) = newDR.Item("charges").ToString
                a(16) = Format(date_needed, "MM/dd/yyyy")
                a(17) = newDR.Item("prepared_by").ToString
                a(18) = newDR.Item("checked_by").ToString
                a(19) = newDR.Item("approved_by").ToString
                a(20) = newDR.Item("rs_id").ToString
                a(21) = newDR.Item("selected").ToString
                a(22) = newDR.Item("po_id").ToString
                a(23) = newDR.Item("IN_OUT").ToString
                a(24) = FSummarySupplyTransaction.day_and_days(IIf(DateDiff(DateInterval.Day, rs_date, po_date) < 0, 0, DateDiff(DateInterval.Day, rs_date, po_date)))
                a(25) = newDR.Item("print_stats").ToString
                a(26) = IIf(Format(Date.Parse(print_date_data), "MM/dd/yyyy") = "01/01/1900", "", Format(Date.Parse(print_date_data), "MM/dd/yyyy"))
                Dim lvl As New ListViewItem(a)
                lvlpurchasedOrderList.Items.Add(lvl)

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    'KING (9/13/23)
    Private Sub po_print1()
        POData.clear_parameter()

        Panel3.Visible = True
        Label7.Text = "Processing data to display..."

        POData.cStoreProcedureName = "po_query_new2"
        POData.parameter("@n", 4)

        BW_search.WorkerSupportsCancellation = True
        BW_search.RunWorkerAsync()

    End Sub
    Public Sub PO_preview_report()
        Dim dt As New DataTable
        Dim i As Integer = 0

        With dt
            .Columns.Add("proj_code")
            .Columns.Add("contract_amount")
            .Columns.Add("budgetary")
            .Columns.Add("actual_cost")
            .Columns.Add("percentage_actual_expense")
            '.Columns.Add("remarks")

        End With

        For i = 0 To lvlpurchasedOrderList.Items.Count - 1
            dt.Rows.Add(dt.NewRow)

            dt.Rows(i).Item("proj_code") = lvlpurchasedOrderList.Items(i).SubItems(1).Text
            dt.Rows(i).Item("contract_amount") = lvlpurchasedOrderList.Items(i).SubItems(7).Text
            dt.Rows(i).Item("budgetary") = lvlpurchasedOrderList.Items(i).SubItems(8).Text
            dt.Rows(i).Item("actual_cost") = lvlpurchasedOrderList.Items(i).SubItems(9).Text
            If lvlpurchasedOrderList.Items(i).SubItems(7).Text = 0.00 Or lvlpurchasedOrderList.Items(i).SubItems(8).Text = 0.00 Or lvlpurchasedOrderList.Items(i).SubItems(9).Text = 0.00 Then
                dt.Rows(i).Item("percentage_actual_expense") = 0
            Else
                dt.Rows(i).Item("percentage_actual_expense") = (lvlpurchasedOrderList.Items(i).SubItems(9).Text / lvlpurchasedOrderList.Items(i).SubItems(8).Text) * 100
            End If
            ' dt.Rows(i).Item("remarks") = lvl_projectDesc.Items(i).SubItems(10).Text

        Next

        Dim view As New DataView(dt)

        FReport_project_maintenance.ReportViewer1.LocalReport.DataSources.Item(0).Value = view
        FReport_project_maintenance.ShowDialog()
        FReport_project_maintenance.Dispose()

    End Sub


    Public Sub search_by(ByVal n As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        lvlpurchasedOrderList.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("po_query_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", n)

            If cmbSearchByCategory.Text = "Search by PO Date" Then
                newCMD.Parameters.AddWithValue("@rs_no", Date.Parse(dtpSearchPoDATE.Text))
            ElseIf cmbSearchByCategory.Text = "Filter by MOnth/Year" Then
                newCMD.Parameters.AddWithValue("@date_from", Date.Parse(DTP_dateFrom.Text))
                newCMD.Parameters.AddWithValue("@date_to", Date.Parse(DTP_dateTo.Text))
                newCMD.Parameters.AddWithValue("@rs_no", "")
            ElseIf cmbSearchByCategory.Text = "Search by Item Name" Then
                newCMD.Parameters.AddWithValue("@rs_no", "")
            ElseIf cmbSearchByCategory.Text = "Search by RS No." Then
                newCMD.Parameters.AddWithValue("@rs_no", txtSearch.Text)
            Else
                newCMD.Parameters.AddWithValue("@rs_no", txtSearch.Text)
            End If

            Dim a(30) As String

            newDR = newCMD.ExecuteReader
            While newDR.Read
                Dim inout As String = newDR.Item("IN_OUT").ToString
                Dim rs_date As DateTime = newDR.Item("date_req").ToString
                Dim po_date As DateTime = IIf(IsDate(newDR.Item("po_date").ToString) = True, newDR.Item("po_date").ToString, "1991-01-01")
                Dim date_needed As DateTime = IIf(IsDate(newDR.Item("date_needed").ToString) = True, newDR.Item("date_needed").ToString, "1991-01-01")

                If inout = "IN" Or inout = "OTHERS" Or inout = "QUARRY-IN" Or inout = "BORROWER" Then
                    a(5) = FRequistionForm.GET_ITEM_DESC(newDR.Item("wh_id").ToString)

                ElseIf inout = "FACILITIES" Or inout = "TOOLS" Or inout = "ADD-ON" Then
                    a(5) = FRequistionForm.GET_ITEM_DESC_FROM_FACILITIES(newDR.Item("wh_id").ToString)
                End If

                a(0) = newDR.Item("po_det_id").ToString
                a(1) = newDR.Item("po_no").ToString
                a(2) = newDR.Item("rs_no").ToString
                a(3) = Format(po_date, "MM/dd/yyyy")
                a(4) = newDR.Item("Supplier_Name").ToString
                a(6) = newDR.Item("item_desc").ToString
                a(7) = newDR.Item("qty").ToString
                a(8) = newDR.Item("unit").ToString
                a(9) = FormatNumber(CDbl(newDR.Item("unit_price").ToString), 2, , TriState.True)
                a(10) = FormatNumber(CDbl(newDR.Item("qty").ToString) * CDbl(newDR.Item("unit_price").ToString), 2, , TriState.True)
                a(12) = newDR.Item("instructor").ToString
                a(13) = newDR.Item("location").ToString
                a(14) = newDR.Item("terms").ToString
                a(15) = FReceivingReport.multiplecharges(CInt(newDR.Item("rs_id").ToString), 1)
                a(16) = Format(date_needed, "MM/dd/yyyy")
                a(17) = newDR.Item("prepared_by").ToString
                a(18) = newDR.Item("checked_by").ToString
                a(19) = newDR.Item("approved_by").ToString
                a(20) = newDR.Item("rs_id").ToString
                a(21) = newDR.Item("selected").ToString
                a(22) = newDR.Item("po_id").ToString
                a(23) = newDR.Item("IN_OUT").ToString
                a(24) = FSummarySupplyTransaction.day_and_days(IIf(DateDiff(DateInterval.Day, rs_date, po_date) < 0, 0, DateDiff(DateInterval.Day, rs_date, po_date)))

                'If cmbSearchByCategory.Text = "Search by RS No." Then
                '    If UCase(a(2)) Like "*" & UCase(txtSearch.Text) & "*" Then
                '    Else
                '        GoTo proceedhere
                '    End If

                'ElseIf cmbSearchByCategory.Text = "Search by Item Name" Then
                '    If UCase(a(5)) Like "*" & UCase(txtSearch.Text) & "*" Then
                '    Else
                '        GoTo proceedhere
                '    End If
                'End If


                Dim lvl As New ListViewItem(a)
                lvlpurchasedOrderList.Items.Add(lvl)

proceedhere:

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
#Region "GUI"
    Private Sub FPurchasedOrderList_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        lvlpurchasedOrderList.Height = Me.Height - 115
        lvlpurchasedOrderList.Width = Me.Width - 30
        btnExit.Location = New Point(lvlpurchasedOrderList.Width + 1, 10)
        gboxSearch.Location = New Point(lvlpurchasedOrderList.Location.X, lvlpurchasedOrderList.Bounds.Bottom)
    End Sub

    Private Sub btnExit_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnExit.MouseDown
        btnExit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.MouseEnter
        btnExit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.MouseLeave
        btnExit.BackgroundImage = My.Resources.close_button
    End Sub

    Private Sub btn_panelExt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_panelExt.Click
        panel_fdate.Visible = False
        txtSearch.Enabled = True
        btnSearch.Enabled = True
        txtSearch.Focus()
    End Sub

    Private Sub btn_panelExt_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn_panelExt.MouseDown
        btn_panelExt.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btn_panelExt_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_panelExt.MouseEnter
        btn_panelExt.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btn_panelExt_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_panelExt.MouseLeave
        btn_panelExt.BackgroundImage = My.Resources.close_button
    End Sub

#End Region

#Region "MovingPanelCode"
    Private Sub panel_fdate_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panel_fdate.MouseDown
        Timer_panelmvemEnt.Enabled = True
        Timer_panelmvemEnt.Start()
        setpositions()
    End Sub

    Private Sub panel_fdate_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panel_fdate.MouseUp
        Timer_panelmvemEnt.Stop()
        setpositions()
    End Sub

    Private Sub Timer_panelmvemEnt_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_panelmvemEnt.Tick
        panel_fdate.Location = panloc - curloc + System.Windows.Forms.Cursor.Position
        setpositions()
    End Sub
#End Region

    Private Sub btn_view_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_view.Click
        'load_PO(0)
        'po_list(100)

        'clear parameter first
        ProgressBar1.Value = 0
        POData.clear_parameter()


        If cmbSearchByCategory.Text = "Filter by MOnth/Year" Then

            POData.parameter("@n", 3)

        ElseIf cmbSearchByCategory.Text = "Filter by Date Log" Then
            POData.parameter("@n", 8)

        ElseIf cmbSearchByCategory.Text = "Filter by Date Log and Price" Then
            'coming soon...
            POData.parameter("@n", 9)

        ElseIf cmbSearchByCategory.Text = "Export By Date Log and Price" Then

            POData.parameter("@n", 9)
            forExportExcel = True
            ProgressBar1.Style = ProgressBarStyle.Blocks

        End If


        Panel3.Visible = True


        POData.parameter("@searchby", cmbSearchByCategory.Text)
        POData.parameter("@typeofpurchasing", "PURCHASE ORDER")
        POData.parameter("@datefrom", Date.Parse(DTP_dateFrom.Text))
        POData.parameter("@dateto", Date.Parse(DTP_dateTo.Text))
        POData.cStoreProcedureName = "po_query_new2"

        BW_search.WorkerSupportsCancellation = True
        BW_search.RunWorkerAsync()

    End Sub

    Private Sub dtpSearchPoDATE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpSearchPoDATE.ValueChanged

    End Sub
    Public Function check_po_id_exist(po_det_id) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_po_query", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 16)
            newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)

            newCMD.CommandTimeout = 300

            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                check_po_id_exist = newDR.Item("po_id").ToString
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function


    Private Sub edit_po(po_det_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        FPOFORM.dgvPOList.Columns(7).ReadOnly = True
        FPOFORM.old_ws_no = lvlpurchasedOrderList.SelectedItems(0).SubItems(1).Text

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_po_query", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 17)
            newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)

            newCMD.CommandTimeout = 300

            newDR = newCMD.ExecuteReader
            Dim a(20) As String

            While newDR.Read
                With FPOFORM
                    .DTPTrans.Text = IIf(newDR.Item("po_date").ToString = "", Now, newDR.Item("po_date").ToString)
                    .txtRsNo.Text = newDR.Item("rs_no").ToString
                    .txtInstructions.Text = newDR.Item("instruction").ToString
                    .DTPdateneeded.Text = IIf(newDR.Item("date_needed").ToString = "", Now, newDR.Item("date_needed").ToString)
                    .txtPrepared_by.Text = newDR.Item("prepared_by").ToString
                    .txtChecked_by.Text = newDR.Item("checked_by").ToString
                    .txtApproved_by.Text = newDR.Item("approved_by").ToString
                    .cmbdr_option.Text = newDR.Item("dr_option").ToString
                    .txtRemarks.Text = newDR.Item("remarks").ToString

                    FPOFORM.set_po_id = IIf(newDR.Item("po_id").ToString = "", 0, newDR.Item("po_id").ToString)
                    a(1) = newDR.Item("SUPPLIER").ToString
                    a(2) = newDR.Item("wh_id").ToString
                    a(3) = newDR.Item("Item_Name").ToString
                    'a(4) = newDR.Item("Item_Desc").ToString
                    a(4) = newDR.Item("rs_item_desc").ToString & " (" & newDR.Item("ITEM_NAME").ToString & ")"

                    a(5) = newDR.Item("po_no").ToString
                    a(6) = newDR.Item("terms").ToString
                    a(7) = CDec(newDR.Item("qty").ToString)
                    a(8) = newDR.Item("unit").ToString
                    a(9) = newDR.Item("unit_price").ToString
                    a(10) = FormatNumber(CDec(newDR.Item("Amount").ToString), 2, , TriState.True)
                    a(11) = newDR.Item("po_det_id").ToString
                    a(12) = newDR.Item("rs_id").ToString
                    a(13) = newDR.Item("lof_id").ToString
                    a(14) = newDR.Item("IN_OUT").ToString
                    a(16) = newDR.Item("charges2").ToString

                    .dgvPOList.Rows.Add(a)

                    For Each row As DataGridViewRow In .dgvPOList.Rows
                        If row.Cells(14).Value = "FACILITIES" Or row.Cells(14).Value = "TOOLS" Or row.Cells(14).Value = "ADD-ON" Then

                            row.Cells(2).ReadOnly = True
                            row.Cells(3).ReadOnly = True
                            row.Cells(4).ReadOnly = True
                            row.Cells(7).ReadOnly = True
                            row.Cells(8).ReadOnly = True
                            row.Cells(9).ReadOnly = False
                            row.Cells(10).ReadOnly = True
                            row.Cells(11).ReadOnly = True
                            row.Cells(12).ReadOnly = True
                            row.Cells(13).ReadOnly = True
                            row.Cells(14).ReadOnly = True

                        ElseIf row.Cells(14).Value = "QUARRY-IN" Then
                            row.Cells(2).ReadOnly = True
                            row.Cells(3).ReadOnly = False
                            row.Cells(4).ReadOnly = False
                            row.Cells(7).ReadOnly = True
                            row.Cells(8).ReadOnly = True
                            row.Cells(9).ReadOnly = False
                            row.Cells(10).ReadOnly = True
                            row.Cells(11).ReadOnly = True
                            row.Cells(12).ReadOnly = True
                            row.Cells(13).ReadOnly = True
                            row.Cells(14).ReadOnly = True
                        Else

                            row.Cells(2).ReadOnly = True
                            row.Cells(3).ReadOnly = False
                            row.Cells(4).ReadOnly = False
                            row.Cells(7).ReadOnly = True
                            row.Cells(8).ReadOnly = True
                            row.Cells(9).ReadOnly = False
                            row.Cells(10).ReadOnly = True
                            row.Cells(11).ReadOnly = True
                            row.Cells(12).ReadOnly = True
                            row.Cells(13).ReadOnly = True
                            row.Cells(14).ReadOnly = True

                        End If
                    Next

                End With

            End While

            With FPOFORM
                form_active("FPOFORM")
                .btnSave.Text = "Update"
                '.load_po_items("UPDATE")
                .show_supplier_list()
                .Show()

                .lbox_List.Visible = False
                .Button3.PerformClick()
            End With

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click

    End Sub

    Public Sub GET_REQUISITION_SLIP_DATA1(ByVal rs_id As String)

        Try
            SQ.connection.Open()

            publicquery = "SELECT * FROM dbrequisition_slip WHERE rs_id = " & rs_id
            CMD = New SqlCommand(publicquery, SQ.connection)
            DR = CMD.ExecuteReader
            While DR.Read

                With FPOFORM
                    .txtRsNo.Text = DR.Item("rs_no").ToString
                    .lblChargeToID.Text = DR.Item("charge_to").ToString
                    '.lblTypeOfCharge.Text = lvlpurchasedOrderList.SelectedItems(0).SubItems(17).Text

                    Dim typeOfRequest As String = DR.Item("typeRequest").ToString
                    Dim INOUT As String = DR.Item("IN_OUT").ToString
                    Dim process As String = DR.Item("process").ToString
                    Dim charge_for_cash As String = DR.Item("type_of_purchasing").ToString
                    charge_to_id = DR.Item("charge_to").ToString

                    '*=========================================
                    '* 4 - charge to warehouse
                    '* 3 - charge to department,admin and etc.
                    '* 1 - charge to equipment
                    '* 2 - charge to project
                    '*=========================================

                    Select Case process
                        Case "EQUIPMENT"
                            .txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 1)
                        Case "PROJECT"
                            .txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 2)
                        Case "WAREHOUSE"
                            .txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 4)
                        Case "PERSONAL"
                            .txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                        Case "CASH"
                            .txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                        Case "ADFIL"
                            .txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                            Dim mcharges As String = get_multiple_charges(CInt(DR.Item("rs_id").ToString))

                            If mcharges.Length < 1 Then
                            Else
                                mcharges = mcharges.Trim().Substring(0, mcharges.Length - 1)
                                .txtChargeTo.Text = .txtChargeTo.Text & "(" & UCase(mcharges) & ")"

                            End If
                    End Select
                End With

            End While

            DR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Public Sub GET_REQUISITION_SLIP_DATA(ByVal rs_id As Integer)

        Dim sqldr As SqlDataReader
        Try
            sqlcon.connection.Open()

            publicquery = "SELECT * FROM dbrequisition_slip WHERE rs_id = " & rs_id
            CMD = New SqlCommand(publicquery, sqlcon.connection)
            sqldr = CMD.ExecuteReader
            While sqldr.Read

                With FRequestField
                    .btnSave.Text = "Update"

                    public_rs_id = sqldr.Item("rs_id").ToString
                    .cmbRequestType.Text = sqldr.Item("typeRequest").ToString
                    .cmbInOut.Text = sqldr.Item("IN_OUT").ToString
                    .txtRSno.Text = sqldr.Item("rs_no").ToString
                    .txtLoc.Text = sqldr.Item("location").ToString
                    .DTPReq.Text = sqldr.Item("date_req").ToString
                    .txtJOno.Text = sqldr.Item("job_order_no").ToString

                    .txtQty.Text = sqldr.Item("qty").ToString
                    .txtUnit.Text = sqldr.Item("unit").ToString
                    .txtItemDesc.Text = sqldr.Item("item_desc").ToString
                    wh_id = sqldr.Item("wh_id").ToString
                    .txtPurpose.Text = sqldr.Item("purpose").ToString
                    .DTPTimeNeeded.Text = sqldr.Item("date_needed").ToString
                    .txtRequestBy.Text = sqldr.Item("requested_by").ToString
                    .txtNotedBy.Text = sqldr.Item("noted_by").ToString
                    .txtApprovedby.Text = sqldr.Item("approved_by").ToString
                    .txtWarehouseIncharge.Text = sqldr.Item("wh_incharge").ToString
                    .cmbTypeofCharge.Text = sqldr.Item("process").ToString
                    .lboxUnit.Visible = False
                    Dim typeOfRequest As String = sqldr.Item("typeRequest").ToString
                    Dim INOUT As String = sqldr.Item("IN_OUT").ToString
                    Dim process As String = sqldr.Item("process").ToString
                    Dim charge_for_cash As String = sqldr.Item("type_of_purchasing").ToString
                    charge_to_id = sqldr.Item("charge_to").ToString
                    .lboxUnit.Visible = False

                    '*=========================================
                    '* 4 - charge to warehouse
                    '* 3 - charge to department,admin and etc.
                    '* 1 - charge to equipment
                    '* 2 - charge to project
                    '*========================================

                    Select Case process
                        Case "EQUIPMENT"
                            .cmbChargeTo.Visible = True
                            .cmbChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 1)
                        Case "PROJECT"
                            .cmbChargeTo.Visible = True
                            .cmbChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 2)
                        Case "WAREHOUSE"
                            .txtChargeTo.Visible = True
                            .txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 4)
                        Case "PERSONAL"
                            .txtChargeTo.Visible = True
                            .txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                        Case "CASH"
                            .txtChargeTo.Visible = True
                            .txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                        Case "ADFIL"
                            .txtChargeTo.Visible = True
                            .txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                    End Select

                    .cmbTypeOfPurchase.Text = sqldr.Item("type_of_purchasing").ToString
                End With

            End While

            sqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub CMB_lvlpurchasedOrderList_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMB_lvlpurchasedOrderList.Opening
        Try
            If lvlpurchasedOrderList.SelectedItems.Count > 0 Then
                Dim selectedRow = lvlpurchasedOrderList.SelectedItems(0)

                Utilities.enableDisableToolStrip(EditAllToolStripMenuItem, True)
                Utilities.enableDisableToolStrip(DeleteToolStripMenuItem, True)
                Utilities.enableDisableToolStrip(CalculateQtyToolStripMenuItem, True)
                Utilities.enableDisableToolStrip(PrintPOToolStripMenuItem, True)
                Utilities.enableDisableToolStrip(ExportPOToExcelToolStripMenuItem, True)

                If selectedRow.SubItems(11).Text = "PURCHASED" Then
                    CMB_lvlpurchasedOrderList.Items(0).Enabled = False
                Else
                    CMB_lvlpurchasedOrderList.Items(0).Enabled = True
                End If

                If auth = newAuth.admin Then
                    EditQtyAuthToolStripMenuItem.Visible = True
                Else
                    EditQtyAuthToolStripMenuItem.Visible = True
                End If
            Else
                Utilities.disableAllItemsFromContextMenu(CMB_lvlpurchasedOrderList)
            End If

            Utilities.enableDisableToolStrip(RefreshToolStripMenuItem, True)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click

        If Not isAuthenticated(auth) Then
            Exit Sub
        End If

        If MessageBox.Show("Are you sure you want to delete selected items?", "PO INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim po_det_id As Integer = CInt(lvlpurchasedOrderList.SelectedItems(0).Text)
            Dim po_id As Integer = CInt(lvlpurchasedOrderList.SelectedItems(0).SubItems(22).Text)

            Dim newSQ As New SQLcon
            Dim newCMD As SqlCommand

            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_po_query_new", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 8)
                newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)
                newCMD.Parameters.AddWithValue("@po_id", po_id)

                newCMD.ExecuteNonQuery()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
                MessageBox.Show("Successfully Removed..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lvlpurchasedOrderList.SelectedItems(0).Remove()

            End Try

            'For Each itm As ListViewItem In lvlpurchasedOrderList.Items
            '    If itm.Selected = True Then
            '        Dim query As String = "DELETE FROM dbPO WHERE po_id = " & CInt(itm.SubItems(22).Text)
            '        UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

            '        query = Nothing

            '        query = "DELETE FROM dbPO_details WHERE po_id = " & CInt(itm.SubItems(22).Text)
            '        UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

            '        itm.Remove()

            '    End If
            'Next
        End If

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub CalculateQtyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalculateQtyToolStripMenuItem.Click
        Dim sum_qty As Double

        For Each row As ListViewItem In lvlpurchasedOrderList.Items

            sum_qty += row.SubItems(7).Text

        Next

        MsgBox(sum_qty)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Public Sub view_reportss()

        Dim dt As New DataTable
        With dt
            .Columns.Add("PoNo")
            .Columns.Add("Address")
            .Columns.Add("Terms")
            .Columns.Add("Date")
            .Columns.Add("PoNo")
            .Columns.Add("Description")
            .Columns.Add("Qty")
            .Columns.Add("Unit")
            .Columns.Add("UnitPrice")
            .Columns.Add("Amount")
        End With

        For i As Integer = 0 To lvlpurchasedOrderList.Items.Count - 1
            dt.Rows.Add(
                lvlpurchasedOrderList.Items(i).SubItems(5).Text,
                lvlpurchasedOrderList.Items(i).SubItems(6).Text,
                lvlpurchasedOrderList.Items(i).SubItems(7).Text,
                lvlpurchasedOrderList.Items(i).SubItems(8).Text,
                lvlpurchasedOrderList.Items(i).SubItems(9).Text)

            po = lvlpurchasedOrderList.Items(i).SubItems(1).Text
            If po = True Then

            End If
            supply_name = lvlpurchasedOrderList.Items(i).SubItems(6).Text


        Next



        'For Each item As ListViewItem In Me.ListView1.Items
        'Next

        Dim view As New DataView(dt)

        Report_view_multi_print.ReportViewer1.LocalReport.DataSources.Item(0).Value = view
        Report_view_multi_print.ShowDialog()
        Report_view_multi_print.Dispose()

    End Sub

    Private Sub View_report_btn_Click(sender As Object, e As EventArgs)
        view_reportss()
    End Sub


    Private Sub PrintPOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintPOToolStripMenuItem.Click
        Try
            If forPrintPO() Then
                Dim printPO As New PrintPurchaseOrderServices
                Dim selectedRow = lvlpurchasedOrderList.SelectedItems(0)

                If selectedRow.SubItems(25).Text.ToUpper() = printPO.cPoStatus.FOR_PRINTING Or
                    selectedRow.SubItems(25).Text.ToUpper() = "" Then

                    Dim po_details_id As Integer = selectedRow.Text
                    Dim printResult As Boolean = printPO.ExecuteUpdateForPrintingToPrintedWithReturnTrue(po_details_id)

                    If printResult Then

                        transferring_data_for_printing()
                    Else
                        customMsg.message("error", "there is something wrong in printing!", "SUPPLY INFO:")
                    End If

                ElseIf selectedRow.SubItems(25).Text.ToUpper() = printPO.cPoStatus.PRINTED Then

                    Dim po_details_id As Integer = selectedRow.Text
                    Dim printResult As Boolean = printPO.ExecuteUpdateForRePrintWithReturnTrue(po_details_id)

                    If printResult Then
                        transferring_data_for_printing()
                    Else
                        customMsg.message("error", "there is something wrong in printing!", "SUPPLY INFO:")
                    End If

                End If
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Function forPrintPO() As Boolean
        Try
            If customMsg.messageYesNo("Do you want to print PO?", "SUPPLY INFO:", MessageBoxIcon.Question) Then
                Return True
            End If
            Return False

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
    Private Sub EditToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem1.Click
        'FPOFORM.print_btn.Visible = True
        'check if dbpo id exist

        customMsg.message("error", "Sorry for the inconvenience, this transaction is under maintenance...", "SMS INFO:")
        Exit Sub

        Dim po_det_id As Integer = lvlpurchasedOrderList.SelectedItems(0).Text

        If check_po_id_exist(lvlpurchasedOrderList.SelectedItems(0).Text) = "" Then
            MessageBox.Show("PO INFO is missing, you need to update data..", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            edit_po(po_det_id)
        Else
            edit_po(po_det_id)
        End If
        'end


        'po_edit = 1


        'GET_REQUISITION_SLIP_DATA1(lvlpurchasedOrderList.SelectedItems(0).SubItems(20).Text)

        'FPOFORM.lblInOut.Text = lvlpurchasedOrderList.SelectedItems(0).SubItems(23).Text

        'With FPOFORM

        '    .Label10.Text = "Prepared by:"
        '    .Label9.Text = "Checked by:"
        '    .Label12.Text = "Approved by:"

        '    .txtInstructions.ReadOnly = True
        '    .txtPrepared_by.Enabled = True
        '    .txtChecked_by.Enabled = True
        '    .txtApproved_by.Enabled = True

        '    .Label10.Visible = True
        '    .txtPrepared_by.Visible = True
        '    .Label6.Visible = True
        '    .txtInstructions.Visible = True
        '    .Label11.Visible = True
        '    .DTPdateneeded.Visible = True

        '    form_active("FPOFORM")
        '    .btnSave.Text = "Update"
        '    .load_po_items("UPDATE")
        '    .show_supplier_list()
        '    .Show()

        'End With

    End Sub

    Private Sub EditQtyOnlyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditQtyOnlyToolStripMenuItem.Click
        With FEditPOQTY
            .ShowDialog()
        End With

    End Sub

    Private Sub BW_search_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BW_search.DoWork

        cListOfPo = POData.LISTOFPURCHASEORDER()

        If Not forExportExcel = True Then
            display_po1()
        End If

    End Sub
    Private Sub BW_search_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BW_search.RunWorkerCompleted

        lvlpurchasedOrderList.Items.Clear()


        If Not forExportExcel = True Then
            lvlpurchasedOrderList.Items.AddRange(cListofListview.ToArray)
            Utilities.customListViewHeight(lvlpurchasedOrderList, 26)

            Panel3.Visible = False
            cListofListview.Clear()

        Else
            BW_export_to_excel_by_dateLog_price.WorkerSupportsCancellation = True
            BW_export_to_excel_by_dateLog_price.RunWorkerAsync()
        End If


    End Sub

    Private Sub ExportPOToExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportPOToExcelToolStripMenuItem.Click
        If lvlpurchasedOrderList.Items.Count > 0 Then

            Dim export_po As New EXPORT_TO_EXCEL_FILE
            Dim SaveFileDialog1 As New SaveFileDialog

            SaveFileDialog1.Title = "Save Excel File"
            SaveFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx"
            SaveFileDialog1.ShowDialog()

            'exit if no file selected
            If SaveFileDialog1.FileName = "" Then
                Exit Sub
            End If

            export_po._initialize_po_export(lvlpurchasedOrderList, SaveFileDialog1.FileName)

            'BW_export_to_excel_by_dateLog_price.WorkerSupportsCancellation = True
            'BW_export_to_excel_by_dateLog_price.RunWorkerAsync()


        Else
            MessageBox.Show("There is no data found in the list..", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

    Private Sub BW_export_to_excel_by_dateLog_price_DoWork(sender As Object, e As DoWorkEventArgs) Handles BW_export_to_excel_by_dateLog_price.DoWork


        Dim SaveFileDialog1 As New SaveFileDialog

        SaveFileDialog1.Title = "Save Excel File"
        SaveFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx"
        SaveFileDialog1.ShowDialog()

        'exit if no file selected
        If SaveFileDialog1.FileName = "" Then
            Exit Sub
        End If

        cFileName = SaveFileDialog1.FileName

        Dim PoDateLogPrice_to_Excel As New EXPORT_TO_EXCEL_FILE
        PoDateLogPrice_to_Excel._Export_To_Excel(cListOfPo, cFileName, ProgressBar1)


    End Sub

    Private Sub BW_export_to_excel_by_dateLog_price_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BW_export_to_excel_by_dateLog_price.RunWorkerCompleted

        Panel3.Visible = False
        MessageBox.Show("Successfully Exported...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub EditQtyAuthToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditQtyAuthToolStripMenuItem.Click
        Try
            'If Not isOnwerOfSelectedRsData() OrElse Not isAuthenticatedWithoutMessage(auth) Then
            '    customMsg.message("error", "You are not an owner of this data!", "SMS INFO:")
            '    Exit Sub
            'End If
            Dim selectedRow = lvlpurchasedOrderList.SelectedItems(0)
            Dim where As String = "po_det_id"
            Dim po_det_id As Integer = selectedRow.Text
            Dim po_id As Integer = selectedRow.SubItems(22).Text
            Dim rs_id As Integer = selectedRow.SubItems(20).Text

            Dim newUpdateFrom As New UpdateForm

            With newUpdateFrom
                .qtyPlaceholder = "Qty Here..."
                .unitsPlaceholder = "Units Here..."
                .toolTip = "qty"

                .cTypes = enumType.ifInteger
                .cTableName = "dbPO_details"

                'table columns
                .column = "qty"
                .column2 = "unit"

                .cWhereId = where
                .cId = po_det_id
                .cPoId = po_id
                .cRsId = rs_id

                .isUpdateQtyAndUnit = True
                .ShowDialog()

            End With

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Public Sub transferring_data_for_printing()

        Dim po_det As String
        With CreatePurchaseOrderForm

        End With
        CreatePurchaseOrderForm.unique_rs = ""
        CreatePurchaseOrderForm.unique_charge_all = ""
        CreatePurchaseOrderForm.Datagridview2.Rows.Clear()

        CreatePurchaseOrderForm.Datagridview2.Columns(7).ReadOnly = True

        Dim values As List(Of String) = New List(Of String)
        Dim values_charge_all As List(Of String) = New List(Of String)
        Dim po_id As String = lvlpurchasedOrderList.SelectedItems(0).SubItems(1).Text

        For i = 0 To lvlpurchasedOrderList.Items.Count - 1
            If lvlpurchasedOrderList.Items(i).SubItems(1).Text = po_id Then
                CreatePurchaseOrderForm.Datagridview2.Rows.Add(lvlpurchasedOrderList.Items(i).SubItems(18).Text,
                                           lvlpurchasedOrderList.Items(i).SubItems(4).Text,
                                           lvlpurchasedOrderList.Items(i).SubItems(5).Text,
                                           lvlpurchasedOrderList.Items(i).SubItems(5).Text,
                                           lvlpurchasedOrderList.Items(i).SubItems(6).Text,
                                           lvlpurchasedOrderList.Items(i).SubItems(1).Text,
                                           lvlpurchasedOrderList.Items(i).SubItems(14).Text,
                                           lvlpurchasedOrderList.Items(i).SubItems(7).Text,
                                           lvlpurchasedOrderList.Items(i).SubItems(8).Text,
                                           lvlpurchasedOrderList.Items(i).SubItems(9).Text,
                                           lvlpurchasedOrderList.Items(i).SubItems(10).Text,
                                           lvlpurchasedOrderList.Items(i).SubItems(0).Text,
                                           lvlpurchasedOrderList.Items(i).SubItems(20).Text,
                                           lvlpurchasedOrderList.Items(i).SubItems(22).Text,
                                           lvlpurchasedOrderList.Items(i).SubItems(23).Text,
                                           "Purchased Order",
                                           lvlpurchasedOrderList.Items(i).SubItems(15).Text,
                                           lvlpurchasedOrderList.Items(i).SubItems(33).Text)

                CreatePurchaseOrderForm.isForPrint_FromPOList = True

                CreatePurchaseOrderForm.isForRsNo_FromPOList = lvlpurchasedOrderList.Items(i).SubItems(2).Text
                'CreatePurchaseOrderForm.txtRsNo.Text = lvlpurchasedOrderList.Items(i).SubItems(2).Text
                'CreatePurchaseOrderForm.dtpDateNeeded.Text = lvlpurchasedOrderList.Items(i).SubItems(16).Text
                CreatePurchaseOrderForm.isForDateNeeded_FromPOList = lvlpurchasedOrderList.Items(i).SubItems(16).Text
                CreatePurchaseOrderForm.isForTrans_FromPOList = lvlpurchasedOrderList.Items(i).SubItems(3).Text
                po_det = lvlpurchasedOrderList.Items(i).SubItems(22).Text
                CreatePurchaseOrderForm.sup_po_address = lvlpurchasedOrderList.Items(i).SubItems(1).Text
                CreatePurchaseOrderForm.cPrintList = "FromPOList"
                'values sa pag kuha sa rs nga duplicate
                values.Add(lvlpurchasedOrderList.Items(i).SubItems(2).Text)
                values_charge_all.Add(lvlpurchasedOrderList.Items(i).SubItems(15).Text)
                meInstruction = lvlpurchasedOrderList.Items(i).SubItems(12).Text
            End If

        Next

        Dim result As List(Of String) = values.Distinct().ToList

        For Each element As String In result
            CreatePurchaseOrderForm.unique_rs = CreatePurchaseOrderForm.unique_rs + "/" + element.ToString
        Next

        Dim result2 As List(Of String) = values_charge_all.Distinct().ToList

        For Each element2 As String In result2
            CreatePurchaseOrderForm.unique_charge_all = CreatePurchaseOrderForm.unique_charge_all + " / " + element2.ToString
        Next

        'sa all rs pag duplicate'
        all_rs_no = ""
        Dim ii = CreatePurchaseOrderForm.unique_rs.IndexOf("/")
        all_rs_no = CreatePurchaseOrderForm.unique_rs.Substring(ii + 1)

        'sa charge pag duplicate'
        all_charge_to = ""
        Dim iii = CreatePurchaseOrderForm.unique_charge_all.IndexOf("/")
        all_charge_to = CreatePurchaseOrderForm.unique_charge_all.Substring(iii + 1)

        For Each drv As DataGridViewRow In CreatePurchaseOrderForm.Datagridview2.Rows
            drv.Cells(0).Value = True
        Next

        Dim sqldr As SqlDataReader
        Try
            sqlcon.connection.Open()

            publicquery = "SELECT * FROM dbPO WHERE po_id = " & po_det
            CMD = New SqlCommand(publicquery, sqlcon.connection)
            sqldr = CMD.ExecuteReader
            While sqldr.Read
                With CreatePurchaseOrderForm
                    form_active("CreatePurchaseOrderForm")
                    .cmbdr_option = sqldr.Item("dr_option").ToString
                    .txtInstruction.Text = "asdasd"
                    .Panel7.Visible = True
                    .isReprintPo = True
                    .cInstructionFromPOList = meInstruction
                    .btnCreatePurchaseOrder.Enabled = False
                    .ShowDialog()

                    '.lbox_List.Visible = False
                End With
            End While

            sqldr.Close()
            'CreatePurchaseOrderForm.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try

    End Sub

    Private Sub EditAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditAllToolStripMenuItem.Click
        Try
            'If Not isOnwerOfSelectedRsData() Then
            '    customMsg.message("error", "You are not an owner of this data!", "SMS INFO:")
            '    Exit Sub
            'End If

            Dim selectedRow = lvlpurchasedOrderList.SelectedItems(0)

            Dim selectedPo = getListOfPo.FirstOrDefault(Function(x) x.po_det_id = selectedRow.Text)

            With CreatePurchaseOrderForm
                .isEditAllPo = True
                .cPoInfoData = selectedPo
                .Label2.Text = $"{selectedPo.Item_Name} - {selectedPo.Item_Desc}"
                .ShowDialog()
            End With
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

#Region "PRIVATE GET"
    Public Function isOnwerOfSelectedRsData()
        Try

            Dim selectedRow = lvlpurchasedOrderList.SelectedItems(0)
            Dim po_det_id As Integer = selectedRow.Text

            Dim poData = getListOfPo().FirstOrDefault(Function(x) x.po_det_id = po_det_id)

            If Utilities.isOnwerOfData(poData.po_ws_user_id) Then

                Return True

            Else
                Return False

            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        loadItems()
    End Sub

#End Region


End Class