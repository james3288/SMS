Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Threading
Imports Microsoft.Office.Interop
Imports System.ComponentModel
Public Class FReceivingReportList
    Public sqlcon As New SQLcon
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader

    Dim IsFormBeingDragged As Boolean
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Dim thread, thread1, thread3, th_store_lisbox, th_store_listview, th_sort_lisview, th_back_lbox1, th_export_excel As System.Threading.Thread
    Dim threadaborted As Boolean
    Dim cal_po_det_id, cal_po_det_id1 As Integer
    Dim counter1, counter2 As Integer
    Dim old_rs1, new_rs1 As String
    Dim total_price1, total_amount1 As Decimal
    Dim grand_total As Decimal
    Dim b As Integer
    Dim rr_data As New Class_Receiving.rr_data


    Dim SaveFileDialog1 As New SaveFileDialog
    Dim xls As New Excel.Application
    Dim book As Excel.Workbook
    Dim sheet As Excel.Worksheet

    Private r1, r2, r3 As Boolean
    Private a1, a2 As Boolean
    Private new_receiving As New class_receiving_
    Private new_po As New class_receiving_
    Public cListOfReceiving As New List(Of class_receiving_.rr_data2)

    Private searchby As String
    Private mysearch As String
    Private items As String
    Public DateFrom As DateTime
    Public DateTo As DateTime

    Private supplier As New class_supplier
    Private myItems As New class_items
    Private myCharges As New class_charges

    'king 11/7/2023
    Private RRdata As New Model._Mod_RR

    Private cProperNameModel As New Model_ProperNames
    Private cListOfreceivingDatas As New List(Of COLUMNS)

    Private Class COLUMNS
        Public Property rr_item_id As Integer
        Public Property rr_info_id As Integer
        Public Property rr_no As String
        Public Property po_det_id As Integer
        Public Property rs_no As String
        Public Property po_cv_no As String
        Public Property invoice_no As String
        Public Property supplier As String
        Public Property date_received As DateTime
        Public Property rr_qty As Double
        Public Property price As String
        Public Property item_name As String
        Public Property item_desc As String
        Public Property remarks As String
        Public Property type_of_purchasing As String
        Public Property total_amount As String
        Public Property status As String
        Public Property sorting As String
        Public Property charges As String
        Public Property wh_id As Integer
        Public Property inout As String
        Public Property checked_by As String
        Public Property received_by As String
        Public Property rs_purpose As String
        Public Property unit As String
        Public Property rs_id As Integer
        Public Property lead_time As String
        Public Property date_submitted As DateTime
        Public Property wh_pn_id As Integer

    End Class


    Public WriteOnly Property mSearch As String
        Set(value As String)
            ' Sets the field from an external call.
            mysearch = value
        End Set
    End Property

    Public WriteOnly Property mSearchBy As String
        Set(value As String)
            ' Sets the field from an external call.
            searchby = value
        End Set
    End Property

    Public WriteOnly Property mItems As String
        Set(value As String)
            ' Sets the field from an external call.
            items = value
        End Set
    End Property

    Public WriteOnly Property mR1 As Boolean
        Set(value As Boolean)
            ' Sets the field from an external call.
            r1 = value
        End Set
    End Property


    '052924 KING
    Private cRrData As New List(Of Model._Mod_RR.rr_fields)
    Private cPoData As New List(Of Model._Mod_Purchase_Order.Purchase_Order_Field)


    Public Sub searchRecord_ReceivingReport()
        lvlreceivingreportlist.Items.Clear()

        Dim SQ As New SQLcon
        Dim sqlcomm As New SqlCommand
        Dim dr As SqlDataReader

        Try
            SQ.connection.Open()

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "proc_receiving_crud"
            sqlcomm.CommandType = CommandType.StoredProcedure

            If cmbSearch.Text = "Rr_no" Then
                sqlcomm.Parameters.AddWithValue("@search", txtSearch.Text)
                sqlcomm.Parameters.AddWithValue("@crud", "Search_receiving_items_RRno")
            ElseIf cmbSearch.Text = "Po_no" Then
                sqlcomm.Parameters.AddWithValue("@search", txtSearch.Text)
                sqlcomm.Parameters.AddWithValue("@crud", "Search_receiving_Items_PO_no")
            ElseIf cmbSearch.Text = "Rs_no" Then
                sqlcomm.Parameters.AddWithValue("@search", txtSearch.Text)
                sqlcomm.Parameters.AddWithValue("@crud", "Search_receiving_Items_RS_no")
            ElseIf cmbSearch.Text = "Invoice_no" Then
                sqlcomm.Parameters.AddWithValue("@search", txtSearch.Text)
                sqlcomm.Parameters.AddWithValue("@crud", "Search_receiving_Items_Invoice_no")
            ElseIf cmbSearch.Text = "Supplier" Then
                sqlcomm.Parameters.AddWithValue("@search", txtSearch.Text)
                sqlcomm.Parameters.AddWithValue("@crud", "Search_receiving_Items_Supplier")
            ElseIf cmbSearch.Text = "Date_received" Then
                sqlcomm.Parameters.AddWithValue("@date_received", Date.Parse(DTP_search.Text))
                sqlcomm.Parameters.AddWithValue("@crud", "Search_receiving_Items_Date_received")
            ElseIf cmbSearch.Text = "Quantity" Then
                sqlcomm.Parameters.AddWithValue("@search", txtSearch.Text)
                sqlcomm.Parameters.AddWithValue("@crud", "Search_receiving_Items_Quantity")
            ElseIf cmbSearch.Text = "Item_description" Then
                sqlcomm.Parameters.AddWithValue("@search", txtSearch.Text)
                sqlcomm.Parameters.AddWithValue("@crud", "Search_receiving_Items_Description")
            ElseIf cmbSearch.Text = "Filter by Month" Then
                sqlcomm.Parameters.AddWithValue("@from_date_received", Date.Parse(DtpickerFrom.Text))
                sqlcomm.Parameters.AddWithValue("@to_date_received", Date.Parse(DTP_to.Text))
                sqlcomm.Parameters.AddWithValue("@crud", "Search_receiving_Items_by_date")
            Else
                sqlcomm.Parameters.AddWithValue("@crud", "")
            End If

            dr = sqlcomm.ExecuteReader

            If dr.HasRows Then
                While dr.Read
                    Dim a(15) As String

                    'a(0) = dr.Item("rr_no").ToString
                    'a(1) = dr.Item("po_no").ToString
                    'a(2) = dr.Item("rs_no").ToString
                    'a(3) = dr.Item("invoice_no").ToString
                    'a(4) = dr.Item("supplier").ToString
                    'a(5) = Format(Date.Parse(dr.Item("date_received").ToString), "MM/dd/yyyy")
                    'a(6) = dr.Item("received_by").ToString
                    'a(7) = dr.Item("checked_by").ToString
                    'a(8) = dr.Item("qty").ToString
                    'a(9) = dr.Item("item_description").ToString
                    'a(10) = dr.Item("remarks").ToString
                    'a(11) = dr.Item("received_status").ToString


                    a(0) = dr.Item("rr_info_id").ToString
                    a(1) = dr.Item("rr_no").ToString
                    a(2) = dr.Item("po_no").ToString
                    a(3) = dr.Item("rs_no").ToString
                    a(4) = dr.Item("invoice_no").ToString
                    a(5) = dr.Item("supplier").ToString
                    a(6) = Format(Date.Parse(dr.Item("date_received").ToString), "MM/dd/yyyy")
                    a(7) = dr.Item("received_by").ToString
                    a(8) = dr.Item("checked_by").ToString
                    a(9) = dr.Item("qty").ToString
                    a(10) = dr.Item("item_description").ToString
                    a(11) = dr.Item("remarks").ToString
                    a(12) = dr.Item("received_status").ToString

                    If dr.Item("po_no").ToString > 0 Then
                        a(13) = "PURCHASED ORDER"
                    Else
                        a(13) = "CASH"
                    End If


                    Dim lvl As New ListViewItem(a)
                    lvlreceivingreportlist.Items.Add(lvl)

                End While
            Else
                MessageBox.Show("Data doesn't exist...", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub FReceivingReportList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Label15.Parent = pboxHeader
        'pboxHeader.Width = FMain.Width - FMain.ToolStrip1.Width
        'lvlreceivingreportlist.Location = New Point(1000, 1000)
        Label15.Parent = pboxHeader
        Label15.BringToFront()
        ' viewRRList(0)

        Panel_date_duration.BringToFront()
        Panel_date_duration.Location = New Point(480, 650)
        'cmbSearch.Text = "Rr_no"

        col_price.DisplayIndex = 10
        col_total_amount.DisplayIndex = 11
        col_item_name.DisplayIndex = 12
        col_item_description.DisplayIndex = 13
        col_remarks.DisplayIndex = 14
        col_status.DisplayIndex = 15
        col_type.DisplayIndex = 16
        col_charges.DisplayIndex = 17
        col_rs_id.DisplayIndex = 18
        col_rr_info_id.DisplayIndex = 19


        Button2.Location = New Point(100000, 10000)
        ListBox1.Location = New Point(100000, 10000)
        ListBox3.Location = New Point(100000, 10000)
        ListView1.Location = New Point(100000, 10000)
        Button3.Location = New Point(100000, 10000)
        ListBox2.Location = New Point(100000, 10000)


        cProperNameModel.initialize(Panel3)
        cProperNameModel.loadProperNames()

    End Sub

    Public Sub viewRRList(ByVal n As Integer)
        lvlreceivingreportlist.Items.Clear()
        Dim z As Integer = 0
        Try
            sqlcon.connection.Open()
            Dim dr As SqlDataReader
            Dim cmd As New SqlCommand("proc_receiving_crud", sqlcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure

            If n = 0 Then
                cmd.Parameters.AddWithValue("@crud", 8)
            ElseIf n = 1 Then
                If cmbSearch.Text = "Search By RR No" Then
                    cmd.Parameters.AddWithValue("@crud", 888)
                    cmd.Parameters.AddWithValue("@value", txtSearch.Text)
                ElseIf cmbSearch.Text = "Search By Charge To" Then
                    cmd.Parameters.AddWithValue("@crud", 12)
                ElseIf cmbSearch.Text = "Search By PO No" Then
                    cmd.Parameters.AddWithValue("@crud", 13)
                    cmd.Parameters.AddWithValue("@value", txtSearch.Text)
                ElseIf cmbSearch.Text = "Search By RS No" Then
                    cmd.Parameters.AddWithValue("@crud", 14)
                    cmd.Parameters.AddWithValue("@value", txtSearch.Text)
                ElseIf cmbSearch.Text = "Search By Date Received" Then
                    cmd.Parameters.AddWithValue("@crud", 15)
                    cmd.Parameters.AddWithValue("@date_received", Date.Parse(DTP_search.Text))
                ElseIf cmbSearch.Text = "Search By Item Description" Then
                    cmd.Parameters.AddWithValue("@crud", 16)
                    cmd.Parameters.AddWithValue("@value", txtSearch.Text)
                ElseIf cmbSearch.Text = "Filter By Month/Year" Then
                    cmd.Parameters.AddWithValue("@crud", 17)
                    cmd.Parameters.AddWithValue("@from_date_received", Date.Parse(DtpickerFrom.Text))
                    cmd.Parameters.AddWithValue("@to_date_received", Date.Parse(DTP_to.Text))
                End If
            End If

            dr = cmd.ExecuteReader
            While dr.Read
                Dim a(15) As String

                a(0) = dr.Item("rr_info_id").ToString
                a(1) = dr.Item("rr_no").ToString
                a(2) = dr.Item("po_no").ToString
                a(3) = dr.Item("rs_no").ToString
                a(4) = dr.Item("invoice_no").ToString
                a(5) = dr.Item("supplier").ToString
                a(6) = Format(Date.Parse(dr.Item("date_received").ToString))
                a(7) = dr.Item("received_by").ToString
                a(8) = dr.Item("checked_by").ToString
                a(9) = dr.Item("qty").ToString
                a(12) = dr.Item("remarks").ToString
                a(13) = dr.Item("received_status").ToString
                a(14) = dr.Item("type_of_purchasing").ToString

                type_charges = dr.Item("process").ToString


                If dr.Item("IN_OUT").ToString = "IN" Then

                    a(10) = get_item_name(dr.Item("wh_id").ToString, 1)
                    a(11) = dr.Item("item_description").ToString

                ElseIf dr.Item("IN_OUT").ToString = "FACILITIES" Or dr.Item("IN_OUT").ToString = "TOOLS" Or dr.Item("IN_OUT").ToString = "ADD-ON" Then

                    a(10) = get_item_name(dr.Item("wh_id").ToString, 2)
                    a(11) = dr.Item("item_description").ToString

                ElseIf dr.Item("IN_OUT").ToString = "OTHERS" Then

                    a(10) = dr.Item("item_desc").ToString
                    a(11) = dr.Item("item_description").ToString

                End If


                'If dr.Item("type_of_purchasing").ToString = "PURCHASE ORDER" Then
                '    If dr.Item("IN_OUT").ToString = "IN" Then
                '        a(10) = get_item_name(dr.Item("wh_id").ToString, 1)
                '        a(11) = dr.Item("item_description").ToString
                '        a(14) = "PURCHASED ORDER"
                '    ElseIf dr.Item("IN_OUT").ToString = "FACILITIES" Or dr.Item("IN_OUT").ToString = "TOOLS" Then
                '        a(10) = get_item_name(dr.Item("wh_id").ToString, 2)
                '        a(11) = dr.Item("item_description").ToString
                '        a(14) = "PURCHASED ORDER"
                '    End If
                'ElseIf dr.Item("type_of_purchasing").ToString = "CASH" Then
                '    If dr.Item("IN_OUT").ToString = "IN" Then
                '        a(10) = get_item_name(dr.Item("wh_id").ToString, 1)
                '        a(11) = dr.Item("item_description").ToString
                '        a(14) = "PURCHASED ORDER"
                '    ElseIf dr.Item("IN_OUT").ToString = "FACILITIES" Or dr.Item("IN_OUT").ToString = "TOOLS" Then
                '        a(10) = get_item_name(dr.Item("wh_id").ToString, 2)
                '        a(11) = dr.Item("item_description").ToString
                '        a(14) = "PURCHASED ORDER"
                '    ElseIf dr.Item("IN_OUT").ToString = "OTHERS" Then
                '        a(10) = dr.Item("item_description").ToString
                '        a(11) = dr.Item("item_description").ToString
                '        a(14) = "PURCHASED ORDER"
                '    End If
                'End If

                charge_to_id = get_charge_to(dr.Item("rr_item_id").ToString, 1)

                Select Case type_charges
                    Case "EQUIPMENT"
                        a(15) = GET_equip_desc_AND_proj_desc(charge_to_id, 1)
                    Case "PROJECT"
                        a(15) = GET_equip_desc_AND_proj_desc(charge_to_id, 2)
                    Case "WAREHOUSE"
                        a(15) = GET_equip_desc_AND_proj_desc(charge_to_id, 4)
                    Case "PERSONAL"
                        a(15) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                    Case "CASH"
                        a(15) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                    Case "ADFIL"
                        a(15) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)

                        Dim mcharges As String = get_multiple_charges(dr.Item("rs_id").ToString)

                        If mcharges.Length < 1 Then
                        Else
                            mcharges = mcharges.Trim().Substring(0, mcharges.Length - 1)
                            a(15) = a(15) & "(" & UCase(mcharges) & ")"
                        End If

                End Select

                If cmbSearch.Text = "Search By Charge To" Then
                    If a(15) Like "*" & UCase(txtSearch.Text) & "*" Then
                    Else
                        GoTo proceedhere
                    End If
                End If


                Dim lvl As New ListViewItem(a)
                lvlreceivingreportlist.Items.Add(lvl)

                z += 1

proceedhere:

            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try
    End Sub

    Public Function get_charge_to(ByVal id As Integer, ByVal n As Integer)
        Dim newsqlcon As New SQLcon
        Dim newcmd As SqlCommand
        Dim newsqldr As SqlDataReader

        Try
            newsqlcon.connection.Open()
            publicquery = "SELECT a.charge_to, a.process FROM dbrequisition_slip a INNER JOIN dbreceiving_items b ON a.rs_id = b.rs_id WHERE b.rr_item_id = '" & id & "'"
            newcmd = New SqlCommand(publicquery, newsqlcon.connection)
            newsqldr = newcmd.ExecuteReader

            While newsqldr.Read
                If n = 1 Then
                    get_charge_to = newsqldr.Item("charge_to").ToString
                ElseIf n = 2 Then
                    get_charge_to = newsqldr.Item("process").ToString
                End If

            End While
            newsqldr.Close()


        Catch ex As Exception

        End Try
    End Function

    Public Function get_item_name(ByVal id As Integer, ByVal n As Integer)
        Dim newsqlcon As New SQLcon
        Dim newcmd As SqlCommand
        Dim newsqldr As SqlDataReader

        If n = 1 Then
            Try
                newsqlcon.connection.Open()
                publicquery = "SELECT whItem FROM dbwarehouse_items WHERE wh_id = '" & id & "'"
                newcmd = New SqlCommand(publicquery, newsqlcon.connection)
                newsqldr = newcmd.ExecuteReader

                While newsqldr.Read
                    get_item_name = newsqldr.Item("whItem").ToString
                End While
                newsqldr.Close()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newsqlcon.connection.Close()
            End Try

        ElseIf n = 2 Then

            Try
                newsqlcon.connection.Open()
                publicquery = "SELECT facility_name FROM dbfacilities_names WHERE fac_id = '" & id & "'"
                newcmd = New SqlCommand(publicquery, newsqlcon.connection)
                newsqldr = newcmd.ExecuteReader

                While newsqldr.Read
                    get_item_name = newsqldr.Item("facility_name").ToString
                End While
                newsqldr.Close()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newsqlcon.connection.Close()
            End Try


        End If


    End Function

    Private Sub FReceivingReportList_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        pboxHeader.Width = FMain.Width - FMain.ToolStrip1.Width

        lvlreceivingreportlist.Height = Me.Height - 110
        lvlreceivingreportlist.Width = Me.Width - 30
        btnExit.Location = New Point(lvlreceivingreportlist.Width + 1, 10)

        FlowLayoutPanel1.Location = New Point(lvlreceivingreportlist.Location.X, lvlreceivingreportlist.Bounds.Bottom)
    End Sub

    Private Sub btnExit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Public Function get_InOut(ByVal id As Integer)
        Try
            sqlcon.connection.Open()

            publicquery = "SELECT * FROM dbrequisition_slip WHERE rs_no = '" & id & "' "
            cmd = New SqlCommand(publicquery, sqlcon.connection)
            dr = cmd.ExecuteReader

            While dr.Read
                get_InOut = dr.Item("IN_OUT").ToString
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try
    End Function


    Public Function get_type_purchasing(ByVal id As Integer)
        Try
            sqlcon.connection.Open()

            publicquery = "SELECT * FROM dbrequisition_slip WHERE rs_no = '" & id & "' "
            cmd = New SqlCommand(publicquery, sqlcon.connection)
            dr = cmd.ExecuteReader

            While dr.Read
                get_type_purchasing = dr.Item("type_of_purchasing").ToString
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try
    End Function

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        button_click_name = "EditToolStripMenuItem"
        FReceiving_Items2.btnSave.Text = "Update"

        If lvlreceivingreportlist.SelectedItems(0).BackColor = Color.DarkGreen Or lvlreceivingreportlist.SelectedItems(0).BackColor = Color.White Then
            'MessageBox.Show("Select the main row(Darkgreen) to edit items description.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MessageBox.Show("Select the lightgreen to edit items description.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim type_of_purchasing As String = lvlreceivingreportlist.SelectedItems(0).SubItems(14).Text

        If type_of_purchasing = "CASH WITH RR" Then
            FReceiving_Items2.DataGridView1.Rows.Clear()
            b = 0
            Dim rr_item_id As Integer = lvlreceivingreportlist.SelectedItems(0).Text
            edit_cash_with_rr(rr_item_id)
            FReceiving_Items2.ShowDialog()
            Exit Sub
        End If

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim c As Integer = 0
        Dim rr_info_id As Integer = CInt(lvlreceivingreportlist.SelectedItems(0).SubItems(17).Text)
        Dim po_no As String = lvlreceivingreportlist.SelectedItems(0).SubItems(2).Text
        Dim split() As String

        'split = po_no.Split(" ")
        'po_no = split(2)

        Try

            With FReceiving_Items
                .DataGridView1.Rows.Clear()

                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_receiving_crud_new1", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                If po_no = "-" Then
                    newCMD.Parameters.AddWithValue("@n", 9)
                Else
                    newCMD.Parameters.AddWithValue("@n", 2)
                End If
                newCMD.Parameters.AddWithValue("@rr_info_id", rr_info_id)
                newCMD.Parameters.AddWithValue("@po_no", po_no)
                newDR = newCMD.ExecuteReader

                While newDR.Read

                    Dim row(10) As String

                    row(0) = "> " & newDR.Item("whItem").ToString & " ( " & newDR.Item("whItemDesc").ToString & " )"
                    row(1) = "-" 'CInt(newDR.Item("qty").ToString)
                    row(2) = newDR.Item("unit").ToString
                    '  row(3) = "-"
                    row(5) = newDR.Item("po_det_id").ToString
                    row(6) = newDR.Item("rr_item_id").ToString
                    row(7) = CDec(CDec(newDR.Item("qty").ToString)) - CDec(newDR.Item("desired_qty").ToString)
                    row(8) = newDR.Item("desired_qty").ToString
                    row(9) = newDR.Item("rs_id").ToString

                    .DataGridView1.Rows.Add(row)

                    .DataGridView1.Rows(c).DefaultCellStyle.BackColor = Color.DarkGreen
                    .DataGridView1.Rows(c).DefaultCellStyle.ForeColor = Color.White
                    .DataGridView1.Rows(c).DefaultCellStyle.Font = New Font(Control.DefaultFont, FontStyle.Bold)

                    set_cell_readonly(c, True)
                    .DataGridView1.Rows(c).Cells(4).ReadOnly = False
                    .DataGridView1.Rows(c).Cells("col_qty_received").ReadOnly = True

                    Dim gridComboBox1 As New DataGridViewComboBoxCell



                    gridComboBox1.Items.Add("Include")
                    gridComboBox1.Items.Add("Pending")
                    .DataGridView1.Item(4, c) = gridComboBox1

                    .DataGridView1.Item(4, c).Value = newDR.Item("selected").ToString
                    Dim sub_items_count As Integer = FReceiving_Items_Monitoring.load_sub_items(CInt(newDR.Item("rr_item_id").ToString), c)

                    c += sub_items_count
                    c += 1
                End While
                newDR.Close()

                .Button2.Text = "Update"

                .DataGridView1.Columns("col_desired_qty").Visible = False

                .Show()

            End With

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

            Dim aa(10) As String
            Dim grandtotal As Double


            With FReceiving_Items

                aa(0) = "GRAND TOTAL"
                aa(1) = 0
                aa(2) = "-"
                aa(3) = FormatNumber(grandtotal, 2, , , TriState.True)
                aa(4) = "-"
                aa(5) = "-"
                aa(6) = 0
                aa(7) = "-"
                aa(8) = "-"

                .DataGridView1.Rows.Add(aa)

                FReceiving_Items_Monitoring.set_cell_readonly(c, True)
                .DataGridView1.Rows(c).DefaultCellStyle.Font = New Font("Arial", 12, FontStyle.Bold)

                .DataGridView1.Rows(c).DefaultCellStyle.BackColor = Color.Orange

                .DataGridView1.Rows(c).Cells("col_desired_qty").ReadOnly = True
                .DataGridView1.Rows(c).Cells("col_qty_received").ReadOnly = True

                For i = 0 To .DataGridView1.Rows.Count - 1
                    If .DataGridView1.Rows(i).Cells(0).Value = "TOTAL" Then
                        grandtotal += CDbl(.DataGridView1.Rows(i).Cells("col_price").Value)
                    End If
                Next

                .DataGridView1.Rows(.DataGridView1.Rows.Count - 1).Cells("col_price").Value = FormatNumber(grandtotal, 2,,, TriState.True)
            End With

        End Try
    End Sub

    Private Sub edit_cash_with_rr(rr_item_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        grand_total = 0
        Dim inc As Integer = 1
        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new4", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 17)
            newCMD.Parameters.AddWithValue("@rr_item_id", rr_item_id)

            newDR = newCMD.ExecuteReader
            Dim a(15) As String

            While newDR.Read

                With FReceiving_Items2
                    a(0) = newDR.Item("rs_no").ToString
                    a(1) = newDR.Item("item_desc").ToString
                    a(2) = newDR.Item("qty").ToString
                    a(3) = 0
                    a(4) = IIf(IsNumeric(newDR.Item("total_qty_received").ToString) = True, newDR.Item("total_qty_received").ToString, 0)
                    a(5) = "-"
                    a(6) = newDR.Item("unit").ToString
                    a(7) = ""
                    a(8) = newDR.Item("rr_item_id").ToString
                    a(9) = newDR.Item("rs_id").ToString
                    a(10) = ""
                    a(11) = ""
                    a(12) = inc
                    a(3) = a(2) - a(4)

                    .DataGridView1.Rows.Add(a)

                    .DataGridView1.Rows(b).DefaultCellStyle.BackColor = Color.DarkGreen
                    .DataGridView1.Rows(b).DefaultCellStyle.ForeColor = Color.White
                    .DataGridView1.Rows(b).DefaultCellStyle.Font = New Font("arial", 12, FontStyle.Bold)

                    'Dim gridComboBox1 As New DataGridViewComboBoxCell
                    'gridComboBox1.Items.Add("Include") 'Populate the Combobox
                    'gridComboBox1.Items.Add("Pending") 'Populate the Combobox
                    '.DataGridView1.Item(11, b) = gridComboBox1
                    '.DataGridView1.Item(11, b).Value = "Include"

                    .DataGridView1.Rows(b).Cells("col_desired_qty").ReadOnly = True
                    .DataGridView1.Rows(b).Cells("col_sub_item_desc").ReadOnly = True
                    .DataGridView1.Rows(b).Cells("col_po_qty").ReadOnly = True
                    .DataGridView1.Rows(b).Cells("col_unit").ReadOnly = True
                    .DataGridView1.Rows(b).Cells("col_price").ReadOnly = True
                    .DataGridView1.Rows(b).Cells("col_qty_received").ReadOnly = True
                    .DataGridView1.Rows(b).Cells("col_po_det_id").ReadOnly = True
                    .DataGridView1.Rows(b).Cells("col_rr_item_id").ReadOnly = True
                    .DataGridView1.Rows(b).Cells("col_rs_id").ReadOnly = True

                    b += 1

                    'rr_sub(a(9), a(0), a(2) - a(4), newDR.Item("item_desc").ToString, inc)
                    rr_sub(a(8), inc)
                    'inc += 1
                End With
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

            Dim a(15) As String

            With FReceiving_Items2

                a(0) = ""
                a(1) = "GRAND TOTAL"
                a(2) = ""
                a(3) = "-"
                a(4) = "-"
                a(5) = FormatNumber(grand_total, 2,,, TriState.True)
                a(6) = ""
                a(7) = ""
                a(8) = ""
                a(9) = 0
                a(10) = ""
                a(11) = ""
                a(12) = ""

                .DataGridView1.Rows.Add(a)

                .DataGridView1.Rows(b).DefaultCellStyle.BackColor = Color.Orange
                .DataGridView1.Rows(b).DefaultCellStyle.ForeColor = Color.Black
                .DataGridView1.Rows(b).DefaultCellStyle.Font = New Font("arial", 14, FontStyle.Bold)

                .DataGridView1.Rows(b).Cells("col_sub_item_desc").ReadOnly = True
                .DataGridView1.Rows(b).Cells("col_po_qty").ReadOnly = True
                .DataGridView1.Rows(b).Cells("col_unit").ReadOnly = True
                .DataGridView1.Rows(b).Cells("col_price").ReadOnly = True
                .DataGridView1.Rows(b).Cells("col_qty_received").ReadOnly = True
                .DataGridView1.Rows(b).Cells("col_selection").ReadOnly = True
                .DataGridView1.Rows(b).Cells("col_desired_qty").ReadOnly = True

                b += 1
            End With
        End Try

    End Sub
    Private Sub rr_sub(rr_item_id As Integer, inc As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new4", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 18)
            newCMD.Parameters.AddWithValue("@rr_item_id", rr_item_id)
            newDR = newCMD.ExecuteReader

            Dim a(15) As String

            While newDR.Read
                With FReceiving_Items2
                    a(0) = ""
                    a(1) = newDR.Item("item_desc").ToString
                    a(2) = CDec(newDR.Item("qty").ToString)
                    a(3) = "-"
                    a(4) = "-"
                    a(5) = FormatNumber(CDec(newDR.Item("amount").ToString), 2,,, TriState.True)
                    a(6) = newDR.Item("unit").ToString
                    a(7) = ""
                    a(8) = newDR.Item("rr_item_sub_id").ToString
                    a(9) = 0
                    a(10) = ""
                    a(11) = ""
                    a(12) = inc

                    .DataGridView1.Rows.Add(a)

                    .DataGridView1.Rows(b).DefaultCellStyle.BackColor = Color.LightGreen
                    .DataGridView1.Rows(b).DefaultCellStyle.ForeColor = Color.Black
                    .DataGridView1.Rows(b).DefaultCellStyle.Font = New Font("arial", 11, FontStyle.Italic)

                    .DataGridView1.Rows(b).Cells("col_desired_qty").ReadOnly = True
                    .DataGridView1.Rows(b).Cells("col_desired_qty").ReadOnly = True
                    .DataGridView1.Rows(b).Cells("col_qty_received").ReadOnly = True
                    .DataGridView1.Rows(b).Cells("col_selection").ReadOnly = True

                    grand_total += (CDec(a(2)) * CDec(a(5)))
                End With

                b += 1
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Public Sub set_cell_readonly(ByVal n As Integer, ByVal enable As Boolean)
        For i = 0 To 6
            FReceiving_Items.DataGridView1.Rows(n).Cells(i).ReadOnly = enable
        Next
    End Sub
    Private Sub cms_FRecvngReportLst_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cms_FRecvngReportLst.Opening
        If lvlreceivingreportlist.SelectedItems.Count > 0 Then
            cms_FRecvngReportLst.Enabled = True
        Else
            cms_FRecvngReportLst.Enabled = False
        End If

        If lvlreceivingreportlist.SelectedItems(0).SubItems(14).Text = "DR" Then
            with_dr_status = "in with rs"

        End If


        Select Case lvlreceivingreportlist.SelectedItems(0).BackColor
            Case Color.DarkGreen
                For Each item As ToolStripItem In cms_FRecvngReportLst.Items
                    item.Enabled = False
                Next

            Case Color.LightGreen
                For Each item As ToolStripItem In cms_FRecvngReportLst.Items
                    If item.Name = "CreateDRToolStripMenuItem" Then
                        item.Enabled = True
                    ElseIf item.Name = "CreateNewItemsAndUpdateToolStripMenuItem" Then
                        item.Enabled = False
                    Else
                        item.Enabled = True
                    End If
                Next

            Case Color.White
                For Each item As ToolStripItem In cms_FRecvngReportLst.Items
                    item.Enabled = False
                Next

        End Select

        'If lvlreceivingreportlist.SelectedItems(0).BackColor = Color.DarkGreen Then
        '    CreateDRToolStripMenuItem.Enabled = True
        'Else
        '    CreateDRToolStripMenuItem.Enabled = False

        'End If

    End Sub
    Public Sub create_delivery_receipt(rr_no As String)

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim a(30) As String
        Dim counter As Integer = 0

        Dim type_of_purchasing As String = lvlreceivingreportlist.SelectedItems(0).SubItems(14).Text
        Dim rs_no As String = lvlreceivingreportlist.SelectedItems(0).SubItems(3).Text
        Dim rs_id As String = lvlreceivingreportlist.SelectedItems(0).SubItems(16).Text

        Dim split() As String

        Dim rr_qty_string As String = lvlreceivingreportlist.SelectedItems(0).SubItems(9).Text

        split = rr_qty_string.Split("/")
        Dim rr_qty_double As Double = split(0)

        FDeliveryReceipt.cmbOptions.Text = lvlreceivingreportlist.SelectedItems(0).SubItems(24).Text
        FDeliveryReceipt.cmbOptions.Enabled = False

        FDeliveryReceipt.cmbRRNo.Items.Clear()
        FDeliveryReceipt.cmbRRNo.Items.Add(rr_no)
        FDeliveryReceipt.cmbRRNo.SelectedIndex = 0

        FDeliveryReceipt.cmbSupplier.Items.Clear()
        FReceiving_Info.load_suppliers_list(FDeliveryReceipt.cmbSupplier)

        FDeliveryReceipt.dgv_dr_list.Rows.Clear()

        Try
            'newSQ.connection.Open()
            'newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            'newCMD.Parameters.Clear()
            'newCMD.CommandType = CommandType.StoredProcedure

            'newCMD.Parameters.AddWithValue("@n", 12)
            'newCMD.Parameters.AddWithValue("@rs_no", rs_no)
            '' newCMD.Parameters.AddWithValue("@rr_no", rr_no)
            'newCMD.Parameters.AddWithValue("@wh_id", CInt(lvlreceivingreportlist.SelectedItems(0).SubItems(23).Text))

            'newDR = newCMD.ExecuteReader

            'While newDR.Read
            '    With FDeliveryReceipt

            '        If type_of_purchasing = "DR" Then
            '            .cmbDrOptions.Text = "W/ DR"
            '            .cmbDrOptions.Enabled = False

            '        ElseIf type_of_purchasing = "WITHDRAWAL" Then
            '            .cmbDrOptions.Text = "W/ DR"
            '            .cmbDrOptions.Enabled = True

            '        End If

            '        .dtpDRDate.Text = Date.Parse(newDR.Item("date").ToString)

            '        .txtPlateNo.Text = newDR.Item("plate_no").ToString
            '        .cmbOperator.Text = newDR.Item("operator").ToString
            '        .txtDriver.Text = newDR.Item("operator").ToString

            '        .cmbTypeofCharge.Text = newDR.Item("type_of_request").ToString

            '        If .cmbTypeofCharge.Text = "PROJECT" Or .cmbTypeofCharge.Text = "EQUIPMENT" Then
            '            .cmbChargeTo.Text = newDR.Item("REQUESTOR_NAME").ToString

            '        Else
            '            .txtChargeTo.Text = newDR.Item("REQUESTOR_NAME").ToString

            '        End If

            '        .txtrsno.Text = newDR.Item("rs_no").ToString
            '        .cmbSupplier.Text = newDR.Item("SUPPLIER_NAME").ToString
            '        .txtconcession.Text = newDR.Item("concession_ticket_no").ToString
            '        .txtcheckedby.Text = newDR.Item("checkedBy").ToString
            '        .txtreceivedby.Text = newDR.Item("receivedby").ToString
            '        .cmbWsNo_PoNo.Items.Clear()

            '        ' AddWithdrawalNos(CInt(lvlrequisitionlist.SelectedItems(0).Text), .cmbWsNo_PoNo, rs_no)

            '        FRequistionForm.AddRRNo(rs_id, .cmbWsNo_PoNo, rs_no)

            '        a(0) = "True"
            '        a(1) = newDR.Item("dr_no").ToString
            '        a(2) = newDR.Item("SOURCE").ToString
            '        a(3) = newDR.Item("category").ToString
            '        a(4) = 0
            '        a(5) = newDR.Item("ITEM_NAME").ToString
            '        a(6) = rs_id
            '        a(7) = 0
            '        a(8) = newDR.Item("wh_id").ToString
            '        a(10) = 0

            '        .dgv_dr_list.Rows.Add(a)

            '        counter += 1
            '    End With
            'End While
            'newDR.Close()

            If counter = 0 Then

                FDeliveryReceipt.txtrsno.Text = lvlreceivingreportlist.SelectedItems(0).SubItems(3).Text

                a(0) = "True"
                a(1) = ""
                a(2) = ""
                a(3) = ""
                a(4) = rr_qty_double 'rs_qty - dr_qty
                a(5) = lvlreceivingreportlist.SelectedItems(0).SubItems(10).Text & " - " & lvlreceivingreportlist.SelectedItems(0).SubItems(11).Text 'item name - item desc
                a(6) = rs_id
                a(7) = 0
                a(8) = lvlreceivingreportlist.SelectedItems(0).SubItems(23).Text 'wh_id
                a(10) = 0

                FDeliveryReceipt.dgv_dr_list.Rows.Add(a)

            End If

            FDeliveryReceipt.rr_list_left()
            FDeliveryReceipt.ShowDialog()


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Private Sub btnExit_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Enter

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

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()

        End If
    End Sub

    Private Sub txtchange_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        'searchRecord_ReceivingReport()

    End Sub

    Private Sub txtleaved(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.Leave
        Dim txtbox As TextBox = sender

        If txtbox.Text = "" Then
            Select Case cmbSearch.Text
                Case "Search By RR No"
                    txtbox.Text = "RR No..."

                Case "Search By PO and CV No"
                    txtbox.Text = "Po/CV No..."

                Case "Search By RS No"
                    txtbox.Text = "Rs No..."

                Case "Search By Items"
                    txtbox.Text = "Items..."

                Case "Search By Charges"
                    txtbox.Text = "Charges..."

                Case "Search By Supplier"
                    txtbox.Text = "Supplier..."

                Case "Search By Invoice No."
                    txtbox.Text = "Invoice No..."
            End Select
        End If


    End Sub

    Private Sub cmbSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSearch.SelectedIndexChanged
        'dtpFrom.Visible = True
        'dtpTo.Visible = True
        'txtSearch.Width = 175
        'txtSearch.Enabled = True
        'If cmbSearch.Text = "Search By PO and CV No" Or cmbSearch.Text = "Search By RR No" Or
        ' cmbSearch.Text = "Search By RS No" Or cmbSearch.Text = "Search By Charges" Or cmbSearch.Text = "Search By Items" Or
        '    cmbSearch.Text = "Search by Charges (WAREHOUSE)" Or cmbSearch.Text = "Search by Charges (PERSONAL AND OTHERS)" Or
        '    cmbSearch.Text = "Search by Charges (EQUIPMENT)" Or cmbSearch.Text = "Search by Charges (PROJECT)" Then

        '    txtSearch.Enabled = True
        '    btnSearch.Enabled = True
        '    Panel_date_duration.Visible = False
        '    dtpFrom.Visible = False
        '    dtpTo.Visible = False
        '    txtSearch.Width = txtSearch.Width + dtpTo.Width + dtpFrom.Width


        'ElseIf cmbSearch.Text = "Search By Invoice No." Then
        '    dtpFrom.Visible = False
        '    dtpTo.Visible = False
        '    txtSearch.Width = txtSearch.Width + dtpTo.Width + dtpFrom.Width

        'ElseIf cmbSearch.Text = "Search By Supplier" Then
        '    dtpFrom.Visible = True
        '    dtpTo.Visible = True
        '    txtSearch.Visible = True

        'ElseIf cmbSearch.Text = "Filter By Month/Year" Then
        '    txtSearch.Text = ""
        '    'Panel_date_duration.Visible = True
        '    'txtSearch.Enabled = False
        '    'btnSearch.Enabled = False
        '    'Panel_date_duration.Location = New Point(515, 192)
        '    txtSearch.Enabled = False

        'End If

        'Select Case cmbSearch.Text
        '    Case "Search By Date Received"
        '        'DTP_search.Visible = True

        '        'DTP_search.Location = New Point(txtSearch.Width + 106, 903)
        '        'DTP_search.Width = txtSearch.Width
        '        'txtSearch.Visible = False
        '        'Panel_date_duration.Visible = False
        '        'btnSearch.Enabled = True
        '    Case Else
        '        txtSearch.Visible = True
        '        txtSearch.Focus()
        '        DTP_search.Visible = False
        'End Select


        Select Case cmbSearch.Text
            Case "Search By RS No"
                txtItem.Visible = False
                dtpFrom.Visible = False
                dtpTo.Visible = False
                txtSearch.Visible = True
                txtSearch.ForeColor = Color.Gray
                txtSearch.Text = "Rs No..."
                cmb_type_of_request.Visible = False
                cmbDivision.Visible = False

                txtSearch.Focus()
                txtItem.Visible = False

                btnSearch.Enabled = True
            Case "Search By Items"
                txtItem.Visible = False
                dtpFrom.Visible = False
                dtpTo.Visible = False
                txtSearch.Visible = True
                txtSearch.ForeColor = Color.Gray
                txtSearch.Text = "Items..."
                cmb_type_of_request.Visible = False
                cmbDivision.Visible = False

                txtSearch.Focus()
                txtItem.Visible = False

                btnSearch.Enabled = True
            Case "Search By Charges"

                txtItem.Visible = False
                dtpFrom.Visible = True
                dtpTo.Visible = True
                txtSearch.Visible = True
                txtSearch.Text = "Charges..."
                txtSearch.ForeColor = Color.Gray
                cmb_type_of_request.Visible = False
                cmbDivision.Visible = False

                txtSearch.Focus()
                txtItem.Visible = False

                btnSearch.Enabled = False

                a1 = False 'bw_type_of_charges_name
                a2 = False 'bw_get_items

                'CHECK IF DONE
                bw_check_if_done_supp_items = New BackgroundWorker
                bw_check_if_done_supp_items.WorkerSupportsCancellation = True
                bw_check_if_done_supp_items.RunWorkerAsync()

                'GET CHARGES NAME
                bw_type_charges_name = New BackgroundWorker
                bw_type_charges_name.WorkerSupportsCancellation = True
                bw_type_charges_name.RunWorkerAsync()

                'GET ITEMS
                bw_get_items = New BackgroundWorker
                bw_get_items.WorkerSupportsCancellation = True
                bw_get_items.RunWorkerAsync()

            Case "Search By Supplier"
                txtItem.Visible = True
                dtpFrom.Visible = False
                dtpTo.Visible = False
                txtSearch.Visible = True
                txtSearch.Text = "Supplier..."
                txtSearch.ForeColor = Color.Gray
                cmb_type_of_request.Visible = False
                cmbDivision.Visible = False

                txtItem.Visible = True
                txtItem.Text = "Items..."
                txtItem.ForeColor = Color.Gray

                txtSearch.Focus()
                btnSearch.Enabled = False

                a1 = False 'bw_supplier
                a2 = False 'bw_items

                'CHECK IF DONE
                bw_check_if_done_supp_items = New BackgroundWorker
                bw_check_if_done_supp_items.WorkerSupportsCancellation = True
                bw_check_if_done_supp_items.RunWorkerAsync()

                'GET SUPPLIER 
                bw_get_supplier_data = New BackgroundWorker
                bw_get_supplier_data.WorkerSupportsCancellation = True
                bw_get_supplier_data.RunWorkerAsync()

                'GET ITEMS
                bw_get_items = New BackgroundWorker
                bw_get_items.WorkerSupportsCancellation = True
                bw_get_items.RunWorkerAsync()

                searchby = cmbSearch.Text

                'FReceiving_Searchby.ShowDialog()

            Case "Search By PO and CV No"
                txtItem.Visible = False
                dtpFrom.Visible = False
                dtpTo.Visible = False
                txtSearch.Visible = True
                txtSearch.Text = "Po/CV No..."
                txtSearch.ForeColor = Color.Gray
                cmb_type_of_request.Visible = False
                cmbDivision.Visible = False

                txtSearch.Focus()
                txtItem.Visible = False

                btnSearch.Enabled = True
            Case "Search By Invoice No."
                txtItem.Visible = False
                dtpFrom.Visible = False
                dtpTo.Visible = False
                txtSearch.Visible = True
                txtSearch.Text = "Invoice No..."
                txtSearch.ForeColor = Color.Gray
                cmb_type_of_request.Visible = False
                cmbDivision.Visible = False

                txtSearch.Focus()
                txtItem.Visible = False

                btnSearch.Enabled = True
            Case "Search By RR No"
                txtItem.Visible = False
                dtpFrom.Visible = False
                dtpTo.Visible = False
                txtSearch.Visible = True
                txtSearch.Text = "RR No..."
                txtSearch.ForeColor = Color.Gray
                cmb_type_of_request.Visible = False
                cmbDivision.Visible = False

                txtSearch.Focus()
                txtItem.Visible = False

                btnSearch.Enabled = True
            Case "Search By Date Received"
                txtItem.Visible = False
                dtpFrom.Visible = True
                dtpTo.Visible = True
                txtSearch.Visible = False
                txtSearch.ForeColor = Color.Gray
                txtItem.Visible = False
                cmb_type_of_request.Visible = True
                cmbDivision.Visible = True

                FRequestField.load_type_of_request_and_sub(1, cmb_type_of_request, 0)
        End Select
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        r1 = False
        ' dria pangitaa 042023 jimmy
        Panel3.Location = New Point(lvlreceivingreportlist.Location.X, lvlreceivingreportlist.Location.Y)
        Panel3.Visible = True


        cListOfReceiving.Clear()
        searchby = cmbSearch.Text
        mysearch = txtSearch.Text
        items = IIf(txtItem.Text = "Items...", "", txtItem.Text)

        start_search()

        'Button2.PerformClick()




        'lvlreceivingreportlist.Items.Clear()
        'ProgressBar1.Value = 0

        'Me.Timer1.Start()
        'thread = New System.Threading.Thread(Sub() Me.LOAD_RR_BY_THREAD())
        'thread.Start()


    End Sub

    Public Sub start_search2(datefrom As DateTime, dateto As DateTime, item As String, searchby As String, search As String)

        'CLEAR DATA FIRST
        cRrData.Clear()
        cPoData.Clear()

        'RR DATA
        setRrData(datefrom, dateto, item, searchby, search)

        'PO DATA
        setPoData()

        compiledReceivingData()
    End Sub

    Private Sub setPoData()
        Dim distinctrsno = From row In cRrData
                           Select row.rs_no, row.po_det_id Distinct Order By rs_no Ascending

        Dim typeofpurchasing = From row In cRrData
                               Select row.type_of_purchasing Take 1 Distinct Order By rs_no Ascending


        Dim typeofp As String = ""
        For Each row In typeofpurchasing
            typeofp = row
        Next

        'new_po = New class_receiving_

        For Each row In distinctrsno

            Dim po1 As New Model._Mod_Purchase_Order
            po1.cStoreProcedureName = "proc_receiving_crud_new6"
            po1.parameter("@n", 3)
            po1.parameter("@po_det_id", row.po_det_id)
            po1.parameter("@rs_no", row.rs_no)

            Dim d As New List(Of Model._Mod_Purchase_Order.Purchase_Order_Field)
            d = po1.LISTOFPURCHASEORDER_RECEIVING

            d.ForEach(Sub(x)
                          cPoData.Add(x)
                      End Sub)
        Next

    End Sub

    Private Sub setRrData(datefrom As DateTime, dateto As DateTime, item As String, searchby As String, search As String)
        Dim rr1 As New Model._Mod_RR

        rr1.cStoreProcedureName = "proc_receiving_crud_new6"
        rr1.parameter("@n", 6)
        rr1.parameter("@datefrom", datefrom)
        rr1.parameter("@dateto", dateto)
        rr1.parameter("@item", item)
        rr1.parameter("@searchby", searchby)
        rr1.parameter("@search", search)

        cRrData = rr1.LISTOFRR
    End Sub


    Public Sub start_search()

        bw_check_if_finish = New BackgroundWorker
        bw_check_if_finish.WorkerSupportsCancellation = True
        bw_check_if_finish.RunWorkerAsync()

        bw_get_rr_data = New BackgroundWorker
        bw_get_rr_data.WorkerSupportsCancellation = True
        bw_get_rr_data.RunWorkerAsync()
    End Sub

    Private Delegate Sub del_1()

    Private Sub LOAD_RR_BY_THREAD()
        'receiving_list2(txtSearch.Text, Date.Parse(dtpFrom.Text), Date.Parse(dtpTo.Text), cmbSearch.Text)
        If txtSearch.InvokeRequired Then
            txtSearch.Invoke(New del_1(AddressOf LOAD_RR_BY_THREAD))
        ElseIf dtpFrom.InvokeRequired Then
            dtpFrom.Invoke(New del_1(AddressOf LOAD_RR_BY_THREAD))
        ElseIf dtpTo.InvokeRequired Then
            dtpTo.Invoke(New del_1(AddressOf LOAD_RR_BY_THREAD))
        ElseIf cmbSearch.InvokeRequired Then
            cmbSearch.Invoke(New del_1(AddressOf LOAD_RR_BY_THREAD))
        Else
            receiving_list2(txtSearch.Text, Date.Parse(dtpFrom.Text), Date.Parse(dtpTo.Text), cmbSearch.Text)
        End If
    End Sub
    Private Function count_rr(charges As String, datefrom As DateTime, dateto As DateTime) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new4", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 2)
            newCMD.Parameters.AddWithValue("@search", charges)
            newCMD.Parameters.AddWithValue("@date_from", datefrom)
            newCMD.Parameters.AddWithValue("@date_to", dateto)

            newCMD.CommandTimeout = 100

            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                count_rr = newDR.Item("count_rr").ToString
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Private Sub receiving_list2(search As String, datefrom As DateTime, dateto As DateTime, searchby As String)
        Dim rowcounter As Integer
        Dim indicator As String

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        If ProgressBar1.InvokeRequired Then
            ProgressBar1.Invoke(Sub() ProgressBar1.Maximum = count_rr(search, datefrom, dateto))
        Else
            ProgressBar1.Maximum = count_rr(search, datefrom, dateto)
        End If

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new4", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            Select Case searchby
                Case "Search By Invoice No."
                    newCMD.Parameters.AddWithValue("@n", 5)
                Case "Search By Charges"
                    newCMD.Parameters.AddWithValue("@n", 1)
                    newCMD.Parameters.AddWithValue("@date_from", datefrom)
                    newCMD.Parameters.AddWithValue("@date_to", dateto)

                Case "Search By RR No"
                    newCMD.Parameters.AddWithValue("@n", 7)
                Case "Search By Date Received"
                    newCMD.Parameters.AddWithValue("@n", 66)

                    newCMD.Parameters.AddWithValue("@date_from", datefrom)
                    newCMD.Parameters.AddWithValue("@date_to", dateto)
                Case Else
                    'newCMD.Parameters.AddWithValue("@n", 4)
                    newCMD.Parameters.AddWithValue("@n", 8)
            End Select

            newCMD.Parameters.AddWithValue("@searchby", searchby)
            newCMD.Parameters.AddWithValue("@search", search)

            newDR = newCMD.ExecuteReader
            Dim a(30) As String
            Dim aa(30) As String

            Dim main As Boolean = False
            Dim main2 As Boolean = False
            Dim child As Boolean = False
            Dim total_amount As Decimal = 0
            Dim po_date As DateTime
            Dim date_received As DateTime
            Dim grand_total_amount, grand_total_amount1, total_qty, total_price As Decimal
            Dim store_rs_no As String = ""

            While newDR.Read
                If newDR.Item("main").ToString = "A" Then

                    If newDR.Item("po_rr_date_received").ToString = "" Then
                        po_date = Date.Parse("1990-01-01")
                    Else
                        po_date = Date.Parse(newDR.Item("po_rr_date_received").ToString)
                    End If

                    a(4) = "-"
                    a(1) = "-"
                    a(18) = "-"
                    a(21) = "-"
                    a(22) = "-"

                    If main = True Then
                        'add rows here

                        'aa(9) = "TOTAL: " & total_qty
                        'aa(22) = "TOTAL: " & FormatNumber(total_amount, 2,,, TriState.True)
                        'Dim lvl1 As New ListViewItem(aa)
                        'lvlreceivingreportlist.Items.Add(lvl1)

                        'total_price = 0
                        'total_qty = 0

                        'lvlreceivingreportlist.Items(rowcounter).BackColor = Color.LightGreen
                        'lvlreceivingreportlist.Items(rowcounter).ForeColor = Color.Black
                        'lvlreceivingreportlist.Items(rowcounter).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Bold)

                        'rowcounter += 1
                    End If

                    If store_rs_no <> newDR.Item("rs_no").ToString Then
                        'add rows here
                        If main = False Then 'false
                        Else 'true 
                            'aa(9) = "TOTAL: " & total_qty
                            aa(18) = FormatNumber(grand_total_amount1, 2,,, TriState.True)
                            aa(22) = FormatNumber(total_amount, 2,,, TriState.True)

                            Dim lvl1 As New ListViewItem(aa)
                            lvlreceivingreportlist.Items.Add(lvl1)

                            total_price = 0
                            total_qty = 0
                            total_amount = 0
                            grand_total_amount1 = 0

                            lvlreceivingreportlist.Items(rowcounter).BackColor = Color.White
                            lvlreceivingreportlist.Items(rowcounter).ForeColor = Color.Black
                            lvlreceivingreportlist.Items(rowcounter).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Bold)

                            rowcounter += 1
                        End If
                    End If

                    main = True
                    store_rs_no = newDR.Item("rs_no").ToString
                    a(6) = Format(Date.Parse(po_date), "MM/dd/yyyy")
                Else
                    date_received = Date.Parse(newDR.Item("po_rr_date_received").ToString)

                    child = True
                    'total_qty += newDR.Item("qty").ToString
                    total_amount += newDR.Item("amount").ToString
                    grand_total_amount += CDec(newDR.Item("amount").ToString) * CDec(newDR.Item("qty").ToString)
                    grand_total_amount1 += CDec(newDR.Item("amount").ToString) * CDec(newDR.Item("qty").ToString)

                    a(18) = FormatNumber(CDec(newDR.Item("amount").ToString) * CDec(newDR.Item("qty").ToString),, TriState.True)
                    a(21) = FSummarySupplyTransaction.day_and_days(IIf(DateDiff(DateInterval.Day, po_date, date_received) < 0, 0, DateDiff(DateInterval.Day, po_date, date_received)))
                    a(22) = FormatNumber(newDR.Item("amount").ToString, 2,,, TriState.True)

                    main = True
                    store_rs_no = newDR.Item("rs_no").ToString
                    a(6) = Format(Date.Parse(date_received), "MM/dd/yyyy")

                End If

                a(0) = newDR.Item("rr_item_id").ToString
                a(1) = newDR.Item("rr_no").ToString
                a(2) = newDR.Item("po_no").ToString
                a(3) = newDR.Item("rs_no").ToString
                a(4) = newDR.Item("invoice_no").ToString
                a(5) = newDR.Item("SUPPLIER").ToString
                'a(6) = Format(Date.Parse(date_received), "MM/dd/yyyy")
                a(9) = newDR.Item("qty").ToString
                a(10) = newDR.Item("item_name").ToString
                a(11) = newDR.Item("item_desc").ToString
                a(13) = newDR.Item("stat").ToString
                a(14) = newDR.Item("type_of_purchasing").ToString
                a(15) = newDR.Item("CHARGES").ToString
                a(17) = newDR.Item("rr_info_id").ToString
                a(23) = newDR.Item("wh_id").ToString
                a(24) = newDR.Item("IN_OUT").ToString

                Dim lvl As New ListViewItem(a)

                If lvlreceivingreportlist.InvokeRequired Then
                    lvlreceivingreportlist.Invoke(Sub() lvlreceivingreportlist.Items.Add(lvl))
                Else
                    lvlreceivingreportlist.Items.Add(lvl)
                End If

                If newDR.Item("main").ToString = "A" Then

                    lvlreceivingreportlist.Items(rowcounter).BackColor = Color.DarkGreen
                    lvlreceivingreportlist.Items(rowcounter).ForeColor = Color.White
                    lvlreceivingreportlist.Items(rowcounter).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Bold)

                Else
                    lvlreceivingreportlist.Items(rowcounter).BackColor = Color.LightGreen
                    lvlreceivingreportlist.Items(rowcounter).ForeColor = Color.Black
                    lvlreceivingreportlist.Items(rowcounter).Font = New Font(New FontFamily("Arial"), 9, FontStyle.Italic)

                End If

                rowcounter += 1

                If ProgressBar1.InvokeRequired Then
                    ProgressBar1.Invoke(Sub() ProgressBar1.Value += 1)
                Else
                    ProgressBar1.Value += 1
                End If

            End While

            aa(18) = FormatNumber(grand_total_amount1, 2,,, TriState.True)
            aa(22) = FormatNumber(total_amount, 2,,, TriState.True)

            Dim lvl2 As New ListViewItem(aa)

            If lvlreceivingreportlist.InvokeRequired Then
                lvlreceivingreportlist.Invoke(Sub()
                                                  lvlreceivingreportlist.Items.Add(lvl2)
                                                  lvlreceivingreportlist.Items(rowcounter).BackColor = Color.White
                                                  lvlreceivingreportlist.Items(rowcounter).ForeColor = Color.Black
                                                  lvlreceivingreportlist.Items(rowcounter).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Bold)
                                              End Sub)
            Else
                lvlreceivingreportlist.Items.Add(lvl2)
                lvlreceivingreportlist.Items(rowcounter).BackColor = Color.White
                lvlreceivingreportlist.Items(rowcounter).ForeColor = Color.Black
                lvlreceivingreportlist.Items(rowcounter).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Bold)
            End If

            total_price = 0
            total_qty = 0
            total_amount = 0
            grand_total_amount1 = 0



        Catch ex As Exception

            If threadaborted = True Then
                MessageBox.Show("Process has been aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                threadaborted = False
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

            'Dim aa(10) As String
            'Dim main As Boolean = False
            'Dim child As Boolean = False
            'Dim main2 As Boolean = False
            'Dim total_amount As Decimal = 0
            'Dim rowcount As Integer = 0

            'For Each row As ListViewItem In lvlreceivingreportlist.Items
            '    If row.BackColor = Color.DarkGreen Then

            '        If main = True Then
            '            'meaning niagi na og green
            '            main2 = True
            '        End If

            '        indicator = "green"
            '    Else
            '        indicator = "light-green"
            '    End If

            '    If main2 = True Then
            '        MsgBox(total_amount)
            '        total_amount = 0
            '        child = False
            '        main2 = False

            '        aa(5) = "2000"

            '        Dim lvl As New ListViewItem(aa)
            '        lvlreceivingreportlist.Items.Add(lvl)

            '    End If



            '    If indicator = "green" Then
            '        'state that this will be main
            '        main = True
            '    Else
            '        child = True
            '    End If

            '    If main = True And child = True Then
            '        'calculate na ang total amount
            '        total_amount += row.SubItems(22).Text
            '    End If

            '    rowcount += 1

            '    If lvlreceivingreportlist.Items.Count = rowcount Then
            '        MsgBox(total_amount)
            '        total_amount = 0
            '        child = False
            '        main2 = False
            '    End If

            'Next
        End Try

    End Sub
    Private Sub receiving_list1()
        lvlreceivingreportlist.Items.Clear()
        Dim rowcounter As Integer
        Dim sumqty As Double
        Dim wh_id As Integer

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new3", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.CommandTimeout = 0

            Select Case cmbSearch.Text
                Case "Search By Charges", "Search By Item Name", "Search By Item Description"
                    newCMD.Parameters.AddWithValue("@n", 2)
                Case Else
                    newCMD.Parameters.AddWithValue("@n", 1)
            End Select

            newCMD.Parameters.AddWithValue("@searchby", cmbSearch.Text)
            newCMD.Parameters.AddWithValue("@search", txtSearch.Text)

            newCMD.Parameters.AddWithValue("@date_from", Date.Parse(dtpFrom.Text))
            newCMD.Parameters.AddWithValue("@date_to", Date.Parse(dtpTo.Text))

            newDR = newCMD.ExecuteReader
            Dim store_rs As String = ""
            Dim partial_qty As Double = 0
            Dim store_wh_id As Integer = 0

            While newDR.Read
                Dim a(25) As String

                a(0) = newDR.Item("rr_item_id").ToString

                'parent
                If newDR.Item("sorting").ToString = 1 Then

                    If store_rs = newDR.Item("RSNO1").ToString And store_wh_id = newDR.Item("wh_id").ToString Then
                        partial_qty += newDR.Item("dqty").ToString
                    Else
                        partial_qty = 0
                        partial_qty = newDR.Item("dqty").ToString
                    End If

                    a(1) = newDR.Item("rr_no").ToString
                    a(2) = newDR.Item("po_no").ToString
                    a(3) = newDR.Item("RSNO1").ToString
                    a(4) = newDR.Item("invoice_no").ToString
                    a(5) = newDR.Item("SUPPLIER").ToString
                    a(6) = Format(Date.Parse(newDR.Item("date_received").ToString), "yyyy-MM-dd")
                    'a(9) = newDR.Item("dqty").ToString & "/" & IIf(newDR.Item("po_qty").ToString = "", 0, newDR.Item("po_qty").ToString)
                    a(9) = partial_qty & "/" & IIf(newDR.Item("po_qty").ToString = "", 0, newDR.Item("po_qty").ToString)
                    a(10) = newDR.Item("whItem").ToString
                    a(11) = newDR.Item("whItemDesc").ToString

                    a(13) = newDR.Item("RECEIVED_STATUS").ToString
                    a(14) = newDR.Item("type_of_purchasing").ToString
                    a(15) = newDR.Item("CHARGES").ToString ' multiplecharges(newDR.Item("rs_id").ToString, 1)
                    a(16) = newDR.Item("rs_id").ToString
                    a(17) = newDR.Item("rr_info_id").ToString
                    a(18) = "-"
                    a(19) = 0
                    a(23) = newDR.Item("wh_id").ToString
                    a(24) = newDR.Item("IN_OUT").ToString
                    a(25) = newDR.Item("dr_qty").ToString

                    Dim po_date As DateTime
                    Dim rr_date As DateTime

                    If newDR.Item("PO_DATE").ToString = "" Then
                        po_date = Date.Parse("1991-01-01")
                    Else
                        po_date = Date.Parse(newDR.Item("PO_DATE").ToString)
                    End If

                    '======================================================

                    If newDR.Item("date_received").ToString = "" Then
                        rr_date = Date.Parse("1991-01-01")
                    Else
                        rr_date = Date.Parse(newDR.Item("date_received").ToString)
                    End If

                    a(21) = FSummarySupplyTransaction.day_and_days(IIf(DateDiff(DateInterval.Day, po_date, rr_date) < 0, 0, DateDiff(DateInterval.Day, po_date, rr_date)))


                    'sub
                ElseIf newDR.Item("sorting").ToString = 2 Then

                    a(9) = newDR.Item("desired_qty").ToString
                    a(10) = "-"
                    a(11) = "- " & newDR.Item("item_desc_sub").ToString
                    a(18) = FormatNumber(CDbl(newDR.Item("amount").ToString) * CDbl(newDR.Item("desired_qty").ToString),, TriState.True)
                    a(22) = newDR.Item("amount").ToString
                    a(25) = newDR.Item("dr_qty").ToString

                End If
                store_wh_id = newDR.Item("wh_id").ToString
                store_rs = newDR.Item("RSNO1").ToString

                Dim row As New ListViewItem(a)
                lvlreceivingreportlist.Items.Add(row)

                If newDR.Item("sorting").ToString = 1 Then

                    lvlreceivingreportlist.Items(rowcounter).BackColor = Color.DarkGreen
                    lvlreceivingreportlist.Items(rowcounter).ForeColor = Color.White

                Else

                    lvlreceivingreportlist.Items(rowcounter).BackColor = Color.LightGreen
                    lvlreceivingreportlist.Items(rowcounter).ForeColor = Color.Black

                End If

                rowcounter += 1

                Application.DoEvents()


            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub receiving_list()
        lvlreceivingreportlist.Items.Clear()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.CommandTimeout = 0

            newCMD.Parameters.AddWithValue("@n", 18)
            newCMD.Parameters.AddWithValue("@searchby", cmbSearch.Text)
            newCMD.Parameters.AddWithValue("@search", txtSearch.Text)
            newCMD.Parameters.AddWithValue("@date_from", Date.Parse(dtpFrom.Text))
            newCMD.Parameters.AddWithValue("@date_to", Date.Parse(dtpTo.Text))
            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim a(25) As String

                a(0) = newDR.Item("rr_item_id").ToString
                a(1) = newDR.Item("rr_no").ToString
                a(2) = newDR.Item("po_no").ToString
                a(3) = newDR.Item("rs_no").ToString
                a(4) = newDR.Item("invoice_no").ToString
                a(5) = newDR.Item("SUPPLIER").ToString
                a(6) = Format(Date.Parse(newDR.Item("date_received").ToString), "MM/dd/yyyy")
                a(7) = newDR.Item("received_by").ToString
                a(8) = newDR.Item("checked_by").ToString
                a(9) = newDR.Item("total_qty").ToString
                a(10) = newDR.Item("whItem").ToString
                a(11) = newDR.Item("whItemDesc").ToString
                a(12) = newDR.Item("remarks").ToString
                a(13) = newDR.Item("RECEIVED_STATUS").ToString
                a(14) = newDR.Item("type_of_purchasing").ToString
                a(15) = newDR.Item("CHARGES").ToString
                a(16) = newDR.Item("rs_id").ToString
                a(17) = newDR.Item("rr_info_id").ToString
                a(18) = FormatNumber(newDR.Item("total_amount").ToString,, TriState.True)
                a(19) = 0
                a(20) = newDR.Item("qty_received").ToString
                a(25) = newDR.Item("dr_qty").ToString

                Dim po_date As DateTime
                Dim rr_date As DateTime

                If newDR.Item("PO_DATE").ToString = "" Then
                    po_date = Date.Parse("1991-01-01")
                Else
                    po_date = Date.Parse(newDR.Item("PO_DATE").ToString)
                End If

                '======================================================

                If newDR.Item("date_received").ToString = "" Then
                    rr_date = Date.Parse("1991-01-01")
                Else
                    rr_date = Date.Parse(newDR.Item("date_received").ToString)
                End If

                a(21) = FSummarySupplyTransaction.day_and_days(IIf(DateDiff(DateInterval.Day, po_date, rr_date) < 0, 0, DateDiff(DateInterval.Day, po_date, rr_date)))

                Dim row As New ListViewItem(a)
                lvlreceivingreportlist.Items.Add(row)

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub


    Public Sub receiving_view()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim a(22) As String

        lvlreceivingreportlist.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            If cmbSearch.Text = "Search By Date Received" Then
                newCMD.Parameters.AddWithValue("@n", 6)
                newCMD.Parameters.AddWithValue("@date_received", Date.Parse(DTP_search.Text))
            ElseIf cmbSearch.Text = "Filter By Month/Year" Then
                newCMD.Parameters.AddWithValue("@n", 7)
                newCMD.Parameters.AddWithValue("@date_from", Date.Parse(DtpickerFrom.Text))
                newCMD.Parameters.AddWithValue("@date_to", Date.Parse(DTP_to.Text))

            ElseIf cmbSearch.Text = "Search By RS No" Then
                newCMD.Parameters.AddWithValue("@n", 56)
                newCMD.Parameters.AddWithValue("@rs_no", txtSearch.Text)

            ElseIf cmbSearch.Text = "Search By RR No" Then
                newCMD.Parameters.AddWithValue("@n", 5)
                newCMD.Parameters.AddWithValue("@rr_no", txtSearch.Text)

            ElseIf cmbSearch.Text = "Search By Item Name" Then
                newCMD.Parameters.AddWithValue("@n", 57)
                newCMD.Parameters.AddWithValue("@item_desc", txtSearch.Text)

            ElseIf cmbSearch.Text = "Search By Item Description" Then
                newCMD.Parameters.AddWithValue("@n", 58)
                newCMD.Parameters.AddWithValue("@item_desc", txtSearch.Text)

            ElseIf cmbSearch.Text = "Search By PO and CV No" Then

                newCMD.Parameters.AddWithValue("@n", 59)
                newCMD.Parameters.AddWithValue("@item_desc", txtSearch.Text)

            ElseIf cmbSearch.Text = "Search by Charges (WAREHOUSE)" Then
                newCMD.Parameters.AddWithValue("@n", 60)
                newCMD.Parameters.AddWithValue("@item_desc", txtSearch.Text)

            ElseIf cmbSearch.Text = "Search by Charges (PERSONAL AND OTHERS)" Then
                newCMD.Parameters.AddWithValue("@n", 61)
                newCMD.Parameters.AddWithValue("@item_desc", txtSearch.Text)

            ElseIf cmbSearch.Text = "Search by Charges (EQUIPMENT)" Then
                newCMD.Parameters.AddWithValue("@n", 62)
                newCMD.Parameters.AddWithValue("@item_desc", txtSearch.Text)

            ElseIf cmbSearch.Text = "Search by Charges (PROJECT)" Then
                newCMD.Parameters.AddWithValue("@n", 63)
                newCMD.Parameters.AddWithValue("@item_desc", txtSearch.Text)
            End If

            newDR = newCMD.ExecuteReader
            While newDR.Read
                Dim po_date As DateTime
                Dim rr_item_id As Integer = newDR.Item("rr_item_id").ToString
                If newDR.Item("po_date").ToString = "" Then
                    po_date = Date.Parse("1991-01-01")
                Else
                    po_date = Date.Parse(newDR.Item("po_date").ToString)
                End If

                Dim rr_date As DateTime = Date.Parse(newDR.Item("date_received").ToString)
                Dim typeofpurchasing As String = newDR.Item("type_of_purchasing").ToString

                a(0) = rr_item_id
                a(1) = newDR.Item("rr_no").ToString
                a(2) = get_multiple_po_no(CInt(newDR.Item("rr_item_id").ToString))

                'If typeofpurchasing = "PURCHASE ORDER" Then
                '    a(2) = "PO NO: " '& newDR.Item("PO_CV_NO").ToString 
                'ElseIf typeofpurchasing = "CASH" Then
                '    a(2) = "CV NO: " ' & newDR.Item("PO_CV_NO").ToString
                'End If

                Dim rs_id As Integer = newDR.Item("rs_id").ToString
                Dim sub_amount As Double = FReceivingReport.get_total_amount(newDR.Item("rr_item_id").ToString, 3, get_po_det_id(rs_id))
                'Dim sub_qty As Double = FReceivingReport.get_received_sub_amount_and_qty(newDR.Item("rr_item_id").ToString, 2)
                Dim sub_qty As Double = FReceivingReport.get_received_sub_amount_and_qty(newDR.Item("rs_id").ToString, 2, get_po_det_id(rs_id))
                Dim po_qty As Double = newDR.Item("qty").ToString
                Dim status As String

                Dim desired_qty As Integer = get_desired_qty(CInt(newDR.Item("rs_id").ToString))
                Dim exist_pending As Integer = check_if_exist_pending(CInt(newDR.Item("rr_item_id").ToString))

                If exist_pending > 0 Then
                    status = "PARTIALLY RECEIVED"
                Else

                    If desired_qty < po_qty Then
                        status = "PARTIALLY RECEIVED"
                    Else
                        status = "RECEIVED"
                    End If
                End If

                a(3) = newDR.Item("rs_no").ToString
                a(4) = newDR.Item("invoice_no").ToString
                a(5) = newDR.Item("SUPPLIER_NAME").ToString
                a(6) = Format(Date.Parse(newDR.Item("date_received").ToString), "MM/dd/yyyy")
                a(9) = newDR.Item("desired_qty").ToString 'sub_qty & "/" & po_qty
                a(10) = newDR.Item("ITEM_NAME").ToString
                a(11) = newDR.Item("ITEM_DESC").ToString
                'a(11) = get_item_description(newDR.Item("rs_id").ToString) & " (" & newDR.Item("ITEM_DESC").ToString & ")"
                a(12) = newDR.Item("remarks").ToString
                a(13) = status
                a(14) = newDR.Item("type_of_purchasing").ToString
                a(15) = FReceivingReport.multiplecharges(newDR.Item("rs_id").ToString, 1)
                a(16) = rs_id
                a(17) = newDR.Item("rr_info_id").ToString
                a(18) = FormatNumber(sub_amount, 2,,, TriState.True)
                a(19) = "N/A"
                a(21) = FSummarySupplyTransaction.day_and_days(IIf(DateDiff(DateInterval.Day, po_date, rr_date) < 0, 0, DateDiff(DateInterval.Day, po_date, rr_date)))

                Dim lvl As New ListViewItem(a)
                lvlreceivingreportlist.Items.Add(lvl)

                Application.DoEvents()

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Public Function get_item_description(ByVal y As String) As String
        Try
            sqlcon.connection.Open()

            publicquery = "SELECT item_desc FROM dbPO_details WHERE rs_id = '" & y & "' "
            cmd = New SqlCommand(publicquery, sqlcon.connection)
            dr = cmd.ExecuteReader

            While dr.Read
                get_item_description = dr.Item(0).ToString
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try
    End Function
    Public Function check_if_exist_pending(ByVal x As Integer) As Integer
        'Dim newSQ As New SQLcon
        'Dim newCMD As SqlCommand
        'Dim newDR As SqlDataReader

        Try
            sqlcon.connection.Open()

            publicquery = "SELECT selected FROM dbreceiving_items_sub WHERE rr_item_id = '" & x & "' "
            cmd = New SqlCommand(publicquery, sqlcon.connection)
            dr = cmd.ExecuteReader

            While dr.Read
                'check_if_exist_pending += dr.Item(0).ToString
                If dr.Item(0).ToString = "Pending" Then
                    check_if_exist_pending += 1
                End If
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try

    End Function

    Public Function get_multiple_po_no(ByVal rr_item_id As Integer) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        get_multiple_po_no = ""

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 15)
            newCMD.Parameters.AddWithValue("@rr_item_id", rr_item_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_multiple_po_no = newDR.Item("po_no").ToString()
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Function
    Public Function get_po_det_id(rs_id As Integer) As Integer
        Dim query As String = "SELECT po_det_id FROM dbPO_details WHERE rs_id = " & rs_id
        get_po_det_id = get_specific_column_value(query, 1)
    End Function

    Public Function get_desired_qty(rs_id As Integer) As Integer

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new1", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 5)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_desired_qty += CInt(newDR.Item("desired_qty").ToString())
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Function


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit_panel_duration.Click
        Panel_date_duration.Visible = False
    End Sub

    Private Sub btnSearchDuration_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchDuration.Click
        'receiving_view()
        receiving_list()

        Panel_date_duration.Hide()
    End Sub

    Private Sub btnExit_panel_duration_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnExit_panel_duration.MouseDown
        btnExit_panel_duration.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_panel_duration_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit_panel_duration.MouseEnter
        btnExit_panel_duration.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_panel_duration_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit_panel_duration.MouseLeave
        btnExit_panel_duration.BackgroundImage = My.Resources.close_button
    End Sub

    Private Sub pboxHeader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pboxHeader.Click

    End Sub

    Private Sub Panel_date_duration_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel_date_duration.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Panel_date_duration.Left
        mousey = Windows.Forms.Cursor.Position.Y - Panel_date_duration.Top
    End Sub

    Private Sub Panel_date_duration_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel_date_duration.MouseMove
        If drag Then
            Panel_date_duration.Top = Windows.Forms.Cursor.Position.Y - mousey
            Panel_date_duration.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Panel_date_duration_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel_date_duration.MouseUp
        drag = False
    End Sub

    Private Sub Panel_date_duration_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel_date_duration.Paint

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click

        If MessageBox.Show("Are you sure you want to delete this selected data?", "Supply Info:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            If lvlreceivingreportlist.SelectedItems(0).BackColor = Color.DarkGreen Then
                MessageBox.Show("Select lightgreen to remove items.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim newSQ As New SQLcon
            Dim newCMD As SqlCommand

            Dim rr_item_id As Integer = lvlreceivingreportlist.SelectedItems(0).Text

            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_receiving_crud_new1", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 6)
                newCMD.Parameters.AddWithValue("@rr_item_id", CInt(lvlreceivingreportlist.SelectedItems(0).Text))
                newCMD.Parameters.AddWithValue("@rr_info_id", CInt(lvlreceivingreportlist.SelectedItems(0).SubItems(17).Text))
                newCMD.ExecuteNonQuery()

                ' lvlreceivingreportlist.SelectedItems(0).Remove()
                btnSearch.PerformClick()
                listfocus(lvlreceivingreportlist, rr_item_id)

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try


            'For Each item As ListViewItem In lvlreceivingreportlist.Items
            '    If item.Selected = True Then

            '    If row_counter("dbreceiving_items", "rr_info_id", CInt(item.SubItems(17).Text), 1) > 1 Then
            '        'dili sa e delte ang receiving info 
            '        Dim query As String = "DELETE FROM dbreceiving_items WHERE rr_item_id = " & CInt(item.Text)
            '        UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

            '        query = Nothing
            '        query = "DELETE FROM dbreceiving_items_sub WHERE rr_item_id = " & CInt(item.Text)
            '        UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

            '        query = Nothing
            '        query = "DELETE FROM dbreceiving_item_partially WHERE rr_item_id = " & CInt(item.Text)
            '        UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

            '        item.Remove()

            '    Else
            '        Dim query As String
            '        query = "DELETE FROM dbreceiving_items WHERE rr_item_id = " & CInt(item.Text)
            '        UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

            '        query = Nothing
            '        query = "DELETE FROM dbreceiving_info WHERE rr_info_id = " & CInt(item.SubItems(17).Text)
            '        UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

            '        query = Nothing
            '        query = "DELETE FROM dbreceiving_items_sub WHERE rr_item_id = " & CInt(item.Text)
            '        UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

            '        query = Nothing
            '        query = "DELETE FROM dbreceiving_item_partially WHERE rr_item_id = " & CInt(item.Text)
            '        UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

            '        item.Remove()

            '    End If

            '    Dim query1 As String = ""
            '    query1 = "DELETE FROM dbreceiving_items_sub WHERE rr_item_id = " & CInt(item.Text)
            '    UPDATE_INSERT_DELETE_QUERY(query1, 0, "DELETE")


            'End If
            'Next
        End If

    End Sub

    Public Sub delete_recieving()
        Try
            Dim query As String
            query = "DELETE FROM dbreceiving_info"
        Catch ex As Exception
            MessageBox.Show("Error MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub RRList_delete()
        Try
            sqlcon.connection.Open()
            Dim cmd As SqlCommand
            publicquery = "DELETE FROM dbreceiving_info WHERE rr_info_id = " & lvlreceivingreportlist.SelectedItems(0).SubItems(0).Text & ""
            cmd = New SqlCommand(publicquery, sqlcon.connection)
            cmd.ExecuteNonQuery()
            sqlcon.connection.Close()

            sqlcon.connection.Open()
            publicquery = "DELETE FROM dbreceiving_items WHERE rr_info_id = " & lvlreceivingreportlist.SelectedItems(0).SubItems(0).Text & ""
            cmd = New SqlCommand(publicquery, sqlcon.connection)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
            viewRRList(0)
        End Try
    End Sub

    Private Sub EditInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditInfoToolStripMenuItem.Click
        button_click_name = "EditInfoToolStripMenuItem"

        If lvlreceivingreportlist.SelectedItems(0).BackColor = Color.DarkGreen Or lvlreceivingreportlist.SelectedItems(0).BackColor = Color.White Then
            'MessageBox.Show("Select the main row(Darkgreen) to edit items info.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MessageBox.Show("Select the lightgreen to edit items info.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        With FReceiving_Info
            .old_rr_no = lvlreceivingreportlist.SelectedItems(0).SubItems(1).Text
            .load_suppliers_list(.cmbSupplier)

            'Dim rr_info_id As Integer = lvlreceivingreportlist.SelectedItems(0).SubItems(17).Text
            'FReceiving_Items_Monitoring.edit_receiving_info(rr_info_id)
            '.btnReceive.Text = "Update"
            '.ShowDialog()


            'king 11/07/23

            Dim rr_info_id As Integer = lvlreceivingreportlist.SelectedItems(0).SubItems(17).Text
            Dim RRINFOS = get_rr_info(rr_info_id) 'get rr info from database

            If RRINFOS.Count() > 0 Then 'check if exist rrinfo
                display_edit_info(RRINFOS)

            Else
                If MessageBox.Show("Some information has been missing,Do you want add the missing information?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    .btnReceive.Text = "Add Information"
                    .ShowDialog()
                End If
            End If

        End With
    End Sub
    Private Sub display_edit_info(rrinfos As List(Of Object))
        With FReceiving_Info

            'loop data to get values
            For Each row In rrinfos
                Dim n As Integer = 0

                For Each kvp As KeyValuePair(Of String, Object) In row
                    'MsgBox($"{kvp.Key}: {kvp.Value.ToString()}")

                    'make case statement for column name 
                    Select Case kvp.Key
                        Case "Supplier_Name"
                            .cmbSupplier.Text = kvp.Value.ToString()
                        Case "checked_by"
                            .txtCheckedby.Text = kvp.Value.ToString()
                        Case "date_received"
                            .DTPReceived.Text = Date.Parse(kvp.Value.ToString)
                        Case "po_no"
                            .cmbPoNo.Items.Add(kvp.Value.ToString())
                            .cmbPoNo.Text = kvp.Value.ToString()
                        Case "rs_no"
                            .txtRSNo.Text = kvp.Value.ToString()
                        Case "so_no"
                            .txtSOno.Text = kvp.Value.ToString()
                        Case "hauler"
                            .txtHauler.Text = kvp.Value.ToString()
                        Case "rr_no"
                            .txtRRno.Text = kvp.Value.ToString()
                        Case "received_by"
                            .txtReceivedby.Text = kvp.Value.ToString()
                        Case "plateno"
                            .txtPlateNo.Text = kvp.Value.ToString()
                        Case "invoice_no"
                            .txtInvoiceNo.Text = kvp.Value.ToString()
                    End Select
                Next
            Next

            .btnReceive.Text = "Update"
            .ShowDialog()

        End With
    End Sub
    Public Function get_rr_info(par_rr_info_id As Integer) As List(Of Object)

        With FReceiving_Info

            Dim rr_info_id As Integer = par_rr_info_id
            Dim dynamicEditRR As New Model_Dynamic_Select

            Dim table As String = "dbreceiving_info a" 'table
            Dim condition As String = $"a.rr_info_id = {rr_info_id}" 'conditions

            'columns
            dynamicEditRR.join_columns("a.checked_by,")
            dynamicEditRR.join_columns("a.date_received,")
            dynamicEditRR.join_columns("a.hauler,")
            dynamicEditRR.join_columns("a.insource_outsource,")
            dynamicEditRR.join_columns("a.operator_name,")
            dynamicEditRR.join_columns("a.invoice_no,")
            dynamicEditRR.join_columns("a.plateno,")
            dynamicEditRR.join_columns("a.po_no,")
            dynamicEditRR.join_columns("a.received_by,")
            dynamicEditRR.join_columns("a.received_status,")
            dynamicEditRR.join_columns("a.rr_info_id,")
            dynamicEditRR.join_columns("a.rr_no,")
            dynamicEditRR.join_columns("a.rs_no,")
            dynamicEditRR.join_columns("a.so_no,")
            dynamicEditRR.join_columns("a.supplier_id,")
            dynamicEditRR.join_columns("b.Supplier_Name")

            'end columns

            'inner or left join
            dynamicEditRR.joining("LEFT JOIN dbSupplier b ")
            dynamicEditRR.joining("ON b.Supplier_Id = a.supplier_id")
            'end inner or left join

            'initialize data
            dynamicEditRR._initialize(table, condition, dynamicEditRR.cJoinColumns, dynamicEditRR.cJoining)

            get_rr_info = dynamicEditRR.select_query() 'get data


        End With

    End Function


    Private Sub lvlreceivingreportlist_MouseMove(sender As Object, e As MouseEventArgs) Handles lvlreceivingreportlist.MouseMove
        'Dim itm As ListViewItem
        'itm = lvlreceivingreportlist.GetItemAt(e.X, e.Y)
        'For Each item As ListViewItem In lvlreceivingreportlist.Items
        '    item.Selected = False
        'Next
        'If itm IsNot Nothing Then
        '    itm.Selected = True

        'End If
        'If Not itm Is Nothing Then
        '    Form2.Dispose()
        'End If
        'itm = Nothing
    End Sub

    Private Sub lvlreceivingreportlist_MouseClick(sender As Object, e As MouseEventArgs) Handles lvlreceivingreportlist.MouseClick
        'If e.Button = Windows.Forms.MouseButtons.Left Then

        '    Dim itm As ListViewItem
        'itm = lvlreceivingreportlist.GetItemAt(e.X, e.Y)
        'If Not itm Is Nothing Then
        '    If itm.Selected Then
        '        'MessageBox.Show("=>" & itm.SubItems(10).Text.Replace(" - ", "=") & "<=")
        '        Form2.Label1.Text = itm.SubItems(10).Text
        '        Dim s As String = itm.SubItems(10).Text.Replace(" - ", "=")
        '        'Dim s As String = "asd asdsdTest101asdsd sd sdsds"
        '        Dim str() As String = s.Split("=")
        '            'For Each item In str
        '            'MessageBox.Show("=>" & item & "<=")
        '            'Next
        '            'readItemImage(searchItemID(str(0), str(1)))
        '            Form2.Show()
        '        Form2.BringToFront()
        '        Form2.Location = New Point(MousePosition.X, MousePosition.Y)
        '    End If

        'Else
        '    Form2.Dispose()
        'End If
        '    itm = Nothing

        'End If
    End Sub

    Private Sub CreateDRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateDRToolStripMenuItem.Click

        with_dr_status = "in with rs"

        button_click_name = ""
        pub_button_name = "CreateDRToolStripMenuItem"
        Dim rr_no As String = lvlreceivingreportlist.SelectedItems(0).SubItems(1).Text
        create_delivery_receipt(rr_no)

        FDeliveryReceipt.Panel9.Enabled = False
        FDeliveryReceipt.Button1.PerformClick()


    End Sub

    Private Sub CreateNewItemsAndUpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateNewItemsAndUpdateToolStripMenuItem.Click
        button_click_name = "CreateNewItemsAndUpdateToolStripMenuItem"

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        FReceiving_Create_New_Item.lvlCreate_New_Item.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_requisition_slip", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 40)
            newCMD.Parameters.AddWithValue("@rs_no", lvlreceivingreportlist.SelectedItems(0).SubItems(3).Text)
            newDR = newCMD.ExecuteReader

            Dim a(10) As String

            While newDR.Read

                a(0) = newDR.Item("rs_id").ToString
                a(1) = newDR.Item("whItem").ToString
                a(2) = newDR.Item("item_desc").ToString
                a(3) = newDR.Item("unit").ToString
                a(4) = newDR.Item("wh_id").ToString

                Dim lvl As New ListViewItem(a)
                FReceiving_Create_New_Item.lvlCreate_New_Item.Items.Add(lvl)
            End While

            newDR.Close()
            FReceiving_Create_New_Item.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Private Sub btnSearch_DoubleClick(sender As Object, e As EventArgs) Handles btnSearch.DoubleClick
        lvlreceivingreportlist.Items.Clear()


    End Sub

    Private Sub ExportToExcelFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToExcelFileToolStripMenuItem.Click
        'Dim columns As New List(Of String)
        'Dim columncount As Integer = lvlreceivingreportlist.Columns.Count - 1


        ''For i As Integer = 0 To columncount
        ''    columns.Add(lvlrequisitionlist.Columns(i).Text)
        ''Next


        ''For Each columnname In columns
        ''    MessageBox.Show(columnname)
        ''Next


        'Dim SaveFileDialog1 As New SaveFileDialog
        'SaveFileDialog1.Title = "Save Excel File"
        'SaveFileDialog1.Filter = "Excel files (*.xls)|*.xls|Excel Files (*.xlsx)|*.xslx"
        'SaveFileDialog1.ShowDialog()
        ''exit if no file selected
        'If SaveFileDialog1.FileName = "" Then
        '    Exit Sub
        'End If
        ''create objects to interface to Excel
        'Dim xls As New Excel.Application
        'Dim book As Excel.Workbook
        'Dim sheet As Excel.Worksheet
        ''create a workbook and get reference to first worksheet
        'xls.Workbooks.Add()
        'book = xls.ActiveWorkbook
        'sheet = book.ActiveSheet
        ''step through rows and columns and copy data to worksheet
        'Dim row As Integer = 1
        'Dim col As Integer = 1


        'For Each item As ListViewItem In lvlreceivingreportlist.Items
        '    If item.BackColor = Color.DarkGreen Then

        '    ElseIf item.BackColor = Color.White Then

        '    Else

        '        If row = 1 Then
        '            For i As Integer = 0 To columncount
        '                sheet.Cells(row, col) = lvlreceivingreportlist.Columns(i).Text
        '                sheet.Cells(row, col).interior.color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkGreen)

        '                col = col + 1
        '            Next
        '            row = 2
        '            col = 1

        '            For i As Integer = 0 To item.SubItems.Count - 1

        '                sheet.Cells(row, col) = item.SubItems(i).Text
        '                sheet.Cells(row, col).interior.color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen)

        '                col = col + 1
        '            Next
        '        Else
        '            For i As Integer = 0 To item.SubItems.Count - 1

        '                sheet.Cells(row, col) = item.SubItems(i).Text
        '                sheet.Cells(row, col).interior.color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen)

        '                col = col + 1
        '            Next
        '        End If
        '        row += 1
        '        col = 1
        '    End If

        'Next
        ''save the workbook and clean up
        'book.SaveAs(SaveFileDialog1.FileName)
        'xls.Workbooks.Close()
        'xls.Quit()
        'releaseObject(sheet)
        'releaseObject(book)
        'releaseObject(xls)


        'exportToExcelFile()
        SaveFileDialog1.Title = "Save Excel File"
        SaveFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx"

        SaveFileDialog1.ShowDialog()

        'exit if no file selected
        If SaveFileDialog1.FileName = "" Then
            Exit Sub
        End If

        thread1 = New System.Threading.Thread(AddressOf panelvisible2)
        thread1.SetApartmentState(ApartmentState.MTA)
        thread1.Start()

        th_export_excel = New System.Threading.Thread(AddressOf exp)
        th_export_excel.SetApartmentState(ApartmentState.MTA)
        th_export_excel.Start()
        timer_export_excel.Start()

    End Sub
    Private Sub exp()
        exportToExcelFile()
    End Sub
    Private Sub exportToExcelFile()
        Try

            If lvlreceivingreportlist.InvokeRequired Then
                lvlreceivingreportlist.Invoke(Sub()

                                                  Dim xlApp As New Excel.Application
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
                                                  Dim excel_array() As String = New String() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R"}
                                                  Dim excel_index As Integer = 1
                                                  Dim iii As Integer = 0

                                                  sheet.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange, sheet.Range("$A$1:$R$1"), , Excel.XlYesNoGuess.xlYes).Name = "Table1"

                                                  '~~> Format the table
                                                  sheet.ListObjects("Table1").TableStyle = "TableStyleLight9"

                                                  sheet.Cells(1, 1) = "RR No."
                                                  sheet.Cells(1, 2) = "PO and CV No."
                                                  sheet.Cells(1, 3) = "RS No."
                                                  sheet.Cells(1, 4) = "Invoice No."
                                                  sheet.Cells(1, 5) = "Suppliers Name"
                                                  sheet.Cells(1, 6) = "Date"
                                                  sheet.Cells(1, 7) = "Quantity"
                                                  sheet.Cells(1, 8) = "UNIT"
                                                  sheet.Cells(1, 9) = "Price" '8 ni sauna
                                                  sheet.Cells(1, 10) = "Total Amount"
                                                  sheet.Cells(1, 11) = "Item(s) Description"
                                                  sheet.Cells(1, 12) = "Remarks"
                                                  sheet.Cells(1, 13) = "Status"
                                                  sheet.Cells(1, 14) = "Type"
                                                  sheet.Cells(1, 15) = "Charge To"
                                                  sheet.Cells(1, 16) = "Lead Time Po to RR"
                                                  sheet.Cells(1, 17) = "IN/OUT"
                                                  sheet.Cells(1, 18) = "PURPOSE"
                                                  sheet.Cells(1, 19) = "RS DATE"

                                                  'For Each item As ListViewItem In LVLEquipList.Items

                                                  '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                                                  Dim col1, row1 As Integer
                                                  row1 = 2
                                                  col1 = 1

                                                  chartRange1 = sheet.Range(excel_array(3) & 1, excel_array(3) & 1)
                                                  chartRange1.EntireColumn.NumberFormat = "@"

                                                  For Each rows As ListViewItem In lvlreceivingreportlist.Items
                                                      'If rows.Selected = True Then
                                                      If rows.BackColor = Color.DarkGreen Then

                                                      ElseIf rows.BackColor = Color.White Then

                                                      Else

                                                          sheet.Cells(row1, 1) = rows.SubItems(1).Text
                                                          sheet.Cells(row1, 2) = rows.SubItems(2).Text
                                                          sheet.Cells(row1, 3) = rows.SubItems(3).Text
                                                          sheet.Cells(row1, 4) = rows.SubItems(4).Text
                                                          sheet.Cells(row1, 5) = rows.SubItems(5).Text
                                                          sheet.Cells(row1, 6) = Date.Parse(rows.SubItems(6).Text)
                                                          sheet.Cells(row1, 7) = rows.SubItems(9).Text
                                                          sheet.Cells(row1, 8) = rows.SubItems(29).Text
                                                          sheet.Cells(row1, 9) = rows.SubItems(22).Text '8 ni sauna
                                                          sheet.Cells(row1, 10) = rows.SubItems(18).Text
                                                          sheet.Cells(row1, 11) = rows.SubItems(11).Text
                                                          sheet.Cells(row1, 12) = rows.SubItems(12).Text
                                                          sheet.Cells(row1, 13) = rows.SubItems(13).Text
                                                          sheet.Cells(row1, 14) = rows.SubItems(14).Text
                                                          sheet.Cells(row1, 15) = rows.SubItems(15).Text
                                                          sheet.Cells(row1, 16) = rows.SubItems(21).Text
                                                          sheet.Cells(row1, 17) = rows.SubItems(24).Text
                                                          sheet.Cells(row1, 18) = rows.SubItems(28).Text
                                                          sheet.Cells(row1, 19) = rows.SubItems(31).Text

                                                          Label2.Font = New Font("Arial", 10, FontStyle.Italic)
                                                          Label2.ForeColor = Color.Orange
                                                          Label2.Text = rows.SubItems(10).Text & " - " & rows.SubItems(6).Text
                                                          ProgressBar1.Style = ProgressBarStyle.Continuous

                                                          chartRange1 = sheet.Range(excel_array(3) & row1, excel_array(3) & row1)
                                                          chartRange1.EntireColumn.NumberFormat = "@"

                                                          chartRange = sheet.Range(excel_array(0) & 1, excel_array(17) & 1)

                                                          With chartRange

                                                              .HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter
                                                              .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                                                              .Font.Size = 12
                                                              .Font.FontStyle = "Arial"
                                                              .EntireColumn.ColumnWidth = 15

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

                                              End Sub)
            End If

            'save the workbook and clean up

            book.SaveAs(SaveFileDialog1.FileName)
            xls.Workbooks.Close()
            xls.Quit()
            releaseObject(sheet)
            releaseObject(book)

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                If FlowLayoutPanel1.InvokeRequired Then
                    FlowLayoutPanel1.Invoke(Sub() FlowLayoutPanel1.Enabled = True)
                    xls.Workbooks.Close()
                    xls.Quit()
                    releaseObject(sheet)
                    releaseObject(book)
                Else
                    FlowLayoutPanel1.Enabled = True
                    xls.Workbooks.Close()
                    xls.Quit()
                    releaseObject(sheet)
                    releaseObject(book)
                End If
                Return
                Exit Sub
            End If


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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not thread.IsAlive Then
            Me.Timer1.Stop()
            Panel3.Visible = False
            'Else
            '    Panel3.Visible = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ListView1.Items.Clear()
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        lvlreceivingreportlist.Items.Clear()

        thread1 = New System.Threading.Thread(AddressOf panelvisible)
        thread1.Start()

        With rr_data

            .date_from = Date.Parse(dtpFrom.Text)
            .date_to = Date.Parse(dtpTo.Text)
            .type_of_request = cmb_type_of_request.Text
            .listview = ListView1
            .lvlreceivingview = lvlreceivingreportlist
            .lbox = ListBox1
            .items = txtItem.Text
            .search = txtSearch.Text
            .searchby = cmbSearch.Text
            .lbox2 = ListBox3
            .panel = Panel3
            .division = cmbDivision.Text

        End With

        th_store_lisbox = New System.Threading.Thread(AddressOf load_rr3)
        th_store_lisbox.Start()
        timer_store_item_lbox1.Start()

        'load_po_det_id()

    End Sub
    Private Sub load_rr3()
        Dim c_search As New Class_Receiving(rr_data)
        c_search.store_rr_items_in_listbox()

        'If ListBox1.InvokeRequired Then
        '    ListBox1.Invoke(Sub()
        '                        cal_po_det_id = ListBox1.Items.Count
        '                        lblRecords.Text = cal_po_det_id
        '                    End Sub)
        'Else
        '    cal_po_det_id = ListBox1.Items.Count
        '    lblRecords.Text = cal_po_det_id
        'End If

    End Sub
    Private Sub load_rr4()

        Dim c_search As New Class_Receiving(rr_data)
        'c_search.store_rr_items_in_listview()

        For i = 0 To ListBox3.Items.Count - 1
            If ListView1.InvokeRequired Then
                ListView1.Invoke(Sub()
                                     ListView1.Visible = False
                                 End Sub)
            Else
                ListView1.Visible = False
            End If
            c_search.get_rr_items(ListBox3.Items(i))
        Next

    End Sub
    Private Sub load_rr5()

        Dim c_search As New Class_Receiving(rr_data)
        c_search.sort_listview(1)

    End Sub
    Private Sub load_rr6()

        Dim c_search As New Class_Receiving(rr_data)
        c_search.back_rr_items_in_listbox_final()

    End Sub

    Private Sub panelvisible()
        If Panel3.InvokeRequired Then
            Panel3.Invoke(Sub()
                              Panel3.Visible = True
                              Label7.Visible = True
                              lblRecords.Text = 0
                              Label7.Text = "initializing..."
                              lvlreceivingreportlist.Visible = False
                              counter1 = 0

                          End Sub)
        Else
            Panel3.Visible = True
            Label7.Visible = True
            lblRecords.Text = 0
            Label7.Text = "initializing..."
            lvlreceivingreportlist.Visible = False
            counter1 = 0
        End If

    End Sub

    Private Sub panelvisible2()
        If Panel3.InvokeRequired Then
            Panel3.Invoke(Sub()
                              Panel1.Visible = True
                              Label2.Visible = True

                              Label2.Text = "initializing..."
                              lvlreceivingreportlist.Visible = False


                          End Sub)
        Else
            Panel1.Visible = True
            Label2.Visible = True

            Label2.Text = "initializing..."
            lvlreceivingreportlist.Visible = False

        End If

    End Sub



    Private Sub load_rr2()
        Try
            Dim rs_percent As Integer
            Dim n As Integer
            'If Integer.TryParse((cal_po_det_id / 100), n) Then
            '    rs_percent = cal_po_det_id / 100
            'Else
            '    rs_percent = 1
            'End If
            rs_percent = 1

            If ProgressBar1.InvokeRequired Then
                ProgressBar1.Invoke(Sub()
                                        ProgressBar1.Value = 0
                                        'ProgressBar1.Maximum = (rs_percent * 100)
                                        ProgressBar1.Maximum = cal_po_det_id1
                                    End Sub)

            Else
                ProgressBar1.Value = 0
                'ProgressBar1.Maximum = (rs_percent * 100)
                ProgressBar1.Maximum = cal_po_det_id1
            End If

            For Each item As String In ListBox2.Items
                load_po_items1(item)

                If ProgressBar1.InvokeRequired Then
                    ProgressBar1.Invoke(Sub()
                                            If ProgressBar1.Value = cal_po_det_id1 Then ' 100 Then

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

            cal_po_det_id1 = 0
            counter1 = 0

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                If FlowLayoutPanel1.InvokeRequired Then
                    FlowLayoutPanel1.Invoke(Sub() FlowLayoutPanel1.Enabled = True)
                Else
                    FlowLayoutPanel1.Enabled = True
                End If
                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub load_rr1()
        Try
            Dim rs_percent As Integer
            Dim n As Integer
            'If Integer.TryParse((cal_po_det_id / 100), n) Then
            '    rs_percent = cal_po_det_id / 100
            'Else
            '    rs_percent = 1
            'End If
            rs_percent = 1

            If ProgressBar1.InvokeRequired Then
                ProgressBar1.Invoke(Sub()
                                        ProgressBar1.Value = 0
                                        'ProgressBar1.Maximum = (rs_percent * 100)
                                        ProgressBar1.Maximum = cal_po_det_id
                                    End Sub)

            Else
                ProgressBar1.Value = 0
                'ProgressBar1.Maximum = (rs_percent * 100)
                ProgressBar1.Maximum = cal_po_det_id
            End If
            For i = 0 To ListBox1.Items.Count - 1
                ' For Each item As String In ListBox1.Items
                load_po_items(ListBox1.Items(i))

                If ProgressBar1.InvokeRequired Then
                    ProgressBar1.Invoke(Sub()
                                            If ProgressBar1.Value = cal_po_det_id Then ' 100 Then

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

            cal_po_det_id = 0
            counter1 = 0

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                If FlowLayoutPanel1.InvokeRequired Then
                    FlowLayoutPanel1.Invoke(Sub() FlowLayoutPanel1.Enabled = True)
                Else
                    FlowLayoutPanel1.Enabled = True
                End If
                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub load_po_det_id()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim search As String
        Dim items As String

        Select Case txtSearch.Text
            Case "RR No..."
                search = ""

            Case "Po/CV No..."
                search = ""

            Case "Rs No..."
                search = ""

            Case "Items..."
                search = ""

            Case "Charges..."
                search = ""

            Case "Supplier..."
                search = ""

            Case "Invoice No..."
                search = ""
            Case Else
                search = txtSearch.Text
        End Select

        If txtItem.Text = "Items..." Then
            items = ""
        Else
            items = txtItem.Text
        End If

        If ListBox1.InvokeRequired Then
            ListBox1.Invoke(Sub() ListBox1.Items.Clear())
        Else
            ListBox1.Items.Clear()
        End If

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new4", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            If cmbSearch.Text = "Search By Charges" Then
                newCMD.Parameters.AddWithValue("@n", 6)
                newCMD.Parameters.AddWithValue("@date_from", Date.Parse(dtpFrom.Text))
                newCMD.Parameters.AddWithValue("@date_to", Date.Parse(dtpTo.Text))

            ElseIf cmbSearch.Text = "Search By RS No" Or cmbSearch.Text = "Search By Items" Then
                newCMD.Parameters.AddWithValue("@n", 3)

            ElseIf cmbSearch.Text = "Search By RR No" Then
                newCMD.Parameters.AddWithValue("@n", 7)

            ElseIf cmbSearch.Text = "Search By Invoice No." Then
                newCMD.Parameters.AddWithValue("@n", 8)

            ElseIf cmbSearch.Text = "Search By Supplier" Then
                newCMD.Parameters.AddWithValue("@n", 9)
                newCMD.Parameters.AddWithValue("@date_from", Date.Parse(dtpFrom.Text))
                newCMD.Parameters.AddWithValue("@date_to", Date.Parse(dtpTo.Text))
                newCMD.Parameters.AddWithValue("@items", items)

            ElseIf cmbSearch.Text = "Search By Date Received" Then
                newCMD.Parameters.AddWithValue("@n", 22) '10
                newCMD.Parameters.AddWithValue("@date_from", Date.Parse(dtpFrom.Text))
                newCMD.Parameters.AddWithValue("@date_to", Date.Parse(dtpTo.Text))
                newCMD.Parameters.AddWithValue("@type_of_request", "Construction Materials")

            ElseIf cmbSearch.Text = "Search By PO and CV No" Then

                newCMD.Parameters.AddWithValue("@n", 3)

            End If

            newCMD.Parameters.AddWithValue("@search", search)
            newCMD.Parameters.AddWithValue("@searchby", cmbSearch.Text)

            newCMD.CommandTimeout = 100

            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                ListBox1.Items.Add(IIf(newDR.Item("po_det_id").ToString = "", 0, newDR.Item("po_det_id").ToString))
                cal_po_det_id += 1

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
            lblRecords.Text = cal_po_det_id.ToString("N0")

        End Try
    End Sub
    Private Function placeholdervalue(obj As Object) As String
        Dim textbox As TextBox = obj

        If textbox.Text = "RR No..." Then
            placeholdervalue = ""
        ElseIf textbox.Text = "Po/CV No..." Then
            placeholdervalue = ""
        ElseIf textbox.Text = "RS No..." Then
            placeholdervalue = ""
        ElseIf textbox.Text = "Items..." Then
            placeholdervalue = ""
        ElseIf textbox.Text = "Charges..." Then
            placeholdervalue = ""
        ElseIf textbox.Text = "Supplier..." Then
            placeholdervalue = ""
        ElseIf textbox.Text = "Invoice No..." Then
            placeholdervalue = ""
        Else
            placeholdervalue = textbox.Text
        End If
    End Function

    Private Sub load_po_det_id1()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim search As String
        Dim items As String

        search = placeholdervalue(txtSearch)

        If txtItem.Text = "Items..." Then
            items = ""
        Else
            items = txtItem.Text
        End If

        If ListBox2.InvokeRequired Then
            ListBox2.Invoke(Sub() ListBox2.Items.Clear())
        Else
            ListBox2.Items.Clear()
        End If

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new4", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@search", search)
            newCMD.Parameters.AddWithValue("@searchby", cmbSearch.Text)

            If cmbSearch.Text = "Search By Date Received" Then
                newCMD.Parameters.AddWithValue("@n", 25) '16
                newCMD.Parameters.AddWithValue("@date_from", Date.Parse(dtpFrom.Text))
                newCMD.Parameters.AddWithValue("@date_to", Date.Parse(dtpTo.Text))
                newCMD.Parameters.AddWithValue("@type_of_request", cmb_type_of_request.Text)
                newCMD.Parameters.AddWithValue("@division", cmbDivision.Text)

            ElseIf cmbSearch.Text = "Search By Charges" Then
                newCMD.Parameters.AddWithValue("@n", 21)
                newCMD.Parameters.AddWithValue("@date_from", Date.Parse(dtpFrom.Text))
                newCMD.Parameters.AddWithValue("@date_to", Date.Parse(dtpTo.Text))

            Else
                newCMD.Parameters.AddWithValue("@n", 14)
                newCMD.Parameters.AddWithValue("@date_from", Date.Parse(dtpFrom.Text))
                newCMD.Parameters.AddWithValue("@date_to", Date.Parse(dtpTo.Text))

            End If

            newCMD.CommandTimeout = 100

            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                ListBox2.Items.Add(newDR.Item("rs_id").ToString)
                cal_po_det_id1 += 1

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub load_po_items(po_det_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new4", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 4)
            newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)
            newCMD.CommandTimeout = 100

            newDR = newCMD.ExecuteReader
            Dim a(32) As String

            While newDR.Read
                Dim po_date As DateTime
                If newDR.Item("po_date").ToString = "" Then
                    po_date = Date.Parse("1990-01-01")
                Else
                    po_date = Date.Parse(newDR.Item("po_date").ToString)
                End If

                a(1) = "-"
                a(2) = newDR.Item("po_no").ToString
                a(3) = newDR.Item("rs_no").ToString
                a(4) = "-"
                a(5) = newDR.Item("SUPPLIER").ToString
                a(6) = Format(po_date, "MM/dd/yyyy")
                a(7) = "-"
                a(8) = "-"
                a(9) = CDec(newDR.Item("qty").ToString)
                a(10) = newDR.Item("whItem").ToString
                a(11) = newDR.Item("whItemDesc").ToString
                a(12) = "-" 'newDR.Item("remarks").ToString
                a(13) = "-"
                a(14) = "-"
                a(15) = newDR.Item("CHARGES").ToString
                a(16) = newDR.Item("rs_id").ToString
                a(17) = "-"
                a(18) = "-"
                a(19) = "-"
                a(20) = "-"
                a(21) = "-"
                a(22) = "-"
                a(23) = newDR.Item("wh_id").ToString
                a(24) = newDR.Item("IN_OUT").ToString
                a(25) = "-"
                a(26) = "-"
                a(27) = "-"
                a(28) = newDR.Item("purpose").ToString
                a(29) = newDR.Item("unit").ToString

                If newDR.Item("cancel_status").ToString = "" Then
                Else
                    a(13) = "Cancelled PO"
                End If

                If counter1 = 0 Then
                Else
                    If old_rs1 = newDR.Item("rs_no").ToString Then
                    Else
                        Dim a1(32) As String
                        a1(22) = FormatNumber(total_price1, 2,,, TriState.True)
                        a1(18) = FormatNumber(total_amount1, 2,,, TriState.True)

                        Dim lvl1 As New ListViewItem(a1)
                        With lvl1
                            .BackColor = Color.White
                            .ForeColor = Color.Black
                            .Font = New Font(New FontFamily("Arial"), 11, FontStyle.Italic)
                        End With
                        InvokeRequiredList(lvlreceivingreportlist, lvl1)

                        total_amount1 = 0
                        total_price1 = 0
                    End If
                End If


                Dim lvl As New ListViewItem(a)
                With lvl
                    .BackColor = Color.DarkGreen
                    .ForeColor = Color.White
                    .Font = New Font(New FontFamily("Arial"), 12, FontStyle.Bold)
                End With

                InvokeRequiredList(lvlreceivingreportlist, lvl)

                If Label7.InvokeRequired Then
                    Label7.Invoke(Sub() Label7.Text = newDR.Item("whItemDesc").ToString)
                Else
                    Label7.Text = newDR.Item("po_no").ToString
                End If

                load_rr_item_sub1(newDR.Item("po_det_id").ToString)

                new_rs1 = newDR.Item("rs_no").ToString
                counter1 += 1
            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                If FlowLayoutPanel1.InvokeRequired Then
                    FlowLayoutPanel1.Invoke(Sub() FlowLayoutPanel1.Enabled = True)
                Else
                    FlowLayoutPanel1.Enabled = True
                End If
                Return
                Exit Sub
            End If
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Private Sub load_po_items1(rs_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new4", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 13)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.CommandTimeout = 100

            newDR = newCMD.ExecuteReader
            Dim a(32) As String

            While newDR.Read
                Dim po_date As DateTime
                If newDR.Item("date_req").ToString = "" Then
                    po_date = Date.Parse("1990-01-01")
                Else
                    po_date = Date.Parse(newDR.Item("date_req").ToString)
                End If

                a(1) = "-"
                a(2) = newDR.Item("po_no").ToString
                a(3) = newDR.Item("rs_no").ToString
                a(4) = "-"
                a(5) = newDR.Item("SUPPLIER").ToString
                a(6) = Format(po_date, "MM/dd/yyyy")
                a(7) = "-"
                a(8) = "-"
                a(9) = CDec(newDR.Item("qty").ToString)
                a(10) = "-"
                a(11) = newDR.Item("item_desc").ToString
                a(12) = "-" 'newDR.Item("remarks").ToString
                a(13) = "-"
                a(14) = "-"
                a(15) = newDR.Item("CHARGES").ToString
                a(16) = newDR.Item("rs_id").ToString
                a(17) = "-"
                a(18) = "-"
                a(19) = "-"
                a(20) = "-"
                a(21) = "-"
                a(22) = "-"
                a(23) = newDR.Item("wh_id").ToString
                a(24) = newDR.Item("IN_OUT").ToString
                a(25) = "-"
                a(26) = "-"
                a(27) = "-"
                a(28) = newDR.Item("purpose").ToString

                If counter1 = 0 Then
                Else
                    If old_rs1 = newDR.Item("rs_no").ToString Then
                    Else
                        Dim a1(32) As String
                        a1(22) = FormatNumber(total_price1, 2,,, TriState.True)
                        a1(18) = FormatNumber(total_amount1, 2,,, TriState.True)

                        Dim lvl1 As New ListViewItem(a1)
                        With lvl1
                            .BackColor = Color.White
                            .ForeColor = Color.Black
                            .Font = New Font(New FontFamily("Arial"), 11, FontStyle.Italic)
                        End With
                        InvokeRequiredList(lvlreceivingreportlist, lvl1)

                        total_amount1 = 0
                        total_price1 = 0
                    End If
                End If


                Dim lvl As New ListViewItem(a)
                With lvl
                    .BackColor = Color.DarkGreen
                    .ForeColor = Color.White
                    .Font = New Font(New FontFamily("Arial"), 12, FontStyle.Bold)
                End With

                InvokeRequiredList(lvlreceivingreportlist, lvl)

                If Label7.InvokeRequired Then
                    Label7.Invoke(Sub() Label7.Text = newDR.Item("item_desc").ToString)
                Else
                    Label7.Text = newDR.Item("po_no").ToString
                End If

                load_rr_item_sub2(newDR.Item("rs_id").ToString)

                new_rs1 = newDR.Item("rs_no").ToString
                counter1 += 1
            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                If FlowLayoutPanel1.InvokeRequired Then
                    FlowLayoutPanel1.Invoke(Sub() FlowLayoutPanel1.Enabled = True)
                Else
                    FlowLayoutPanel1.Enabled = True
                End If
                Return
                Exit Sub
            End If
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Private Sub InvokeRequiredList(listview As ListView, lvl As ListViewItem)

        If listview.InvokeRequired Then
            listview.Invoke(Sub() listview.Items.Add(lvl))
        Else
            listview.Items.Add(lvl)
        End If

    End Sub
    Private Sub load_rr_item_sub2(rs_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new4", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 15)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.CommandTimeout = 100

            newDR = newCMD.ExecuteReader
            Dim a(32) As String

            While newDR.Read
                Dim date_received As DateTime
                Dim po_date As DateTime

                If newDR.Item("date_received").ToString = "" Then
                    date_received = Date.Parse("1990-01-01")
                Else
                    date_received = Date.Parse(newDR.Item("date_received").ToString)
                End If

                If newDR.Item("date_req").ToString = "" Then
                    po_date = Date.Parse("1990-01-01")
                Else
                    po_date = Date.Parse(newDR.Item("date_req").ToString)
                End If

                a(0) = newDR.Item("rr_item_id").ToString
                a(1) = newDR.Item("rr_no").ToString
                a(2) = newDR.Item("po_no").ToString
                a(3) = newDR.Item("rs_no").ToString
                a(4) = newDR.Item("invoice_no").ToString
                a(5) = newDR.Item("SUPPLIER").ToString
                a(6) = Format(Date.Parse(date_received), "MM/dd/yyyy")
                a(7) = newDR.Item("received_by").ToString
                a(8) = newDR.Item("checked_by").ToString
                a(9) = CDec(newDR.Item("qty").ToString)
                a(10) = newDR.Item("whItem").ToString
                a(11) = newDR.Item("item_desc").ToString
                a(12) = newDR.Item("remarks").ToString
                a(13) = "received"
                a(14) = newDR.Item("type_of_purchasing").ToString
                a(15) = newDR.Item("CHARGES").ToString
                a(16) = newDR.Item("rs_id").ToString
                a(17) = newDR.Item("rr_info_id").ToString
                a(18) = FormatNumber(CDec(newDR.Item("total_amount").ToString), 2,,, TriState.True)
                a(19) = "-"
                a(20) = "-"
                a(21) = FSummarySupplyTransaction.day_and_days(IIf(DateDiff(DateInterval.Day, po_date, date_received) < 0, 0, DateDiff(DateInterval.Day, po_date, date_received)))
                a(22) = CDec(newDR.Item("amount").ToString).ToString("G17", CultureInfo.InvariantCulture) 'FormatNumber(CDec(newDR.Item("amount").ToString), 2,,, TriState.True)
                a(23) = newDR.Item("wh_id").ToString
                a(24) = newDR.Item("IN_OUT").ToString
                a(25) = "-"
                a(26) = newDR.Item("checked_by").ToString
                a(27) = newDR.Item("received_by").ToString
                a(28) = newDR.Item("purpose").ToString

                If Label7.InvokeRequired Then
                    Label7.Invoke(Sub() Label7.Text = newDR.Item("item_desc").ToString)
                Else
                    Label7.Text = newDR.Item("po_no").ToString
                End If

                Dim lvl As New ListViewItem(a)

                a(18) = 0
                a(22) = 0

                With lvl
                    .BackColor = Color.LightGreen
                    .ForeColor = Color.Black
                    .Font = New Font(New FontFamily("Arial"), 9, FontStyle.Italic)
                End With

                InvokeRequiredList(lvlreceivingreportlist, lvl)

                old_rs1 = newDR.Item("rs_no").ToString

                total_price1 = total_price1 + newDR.Item("amount").ToString
                total_amount1 = total_amount1 + newDR.Item("total_amount").ToString

                counter1 += 1
            End While

        Catch ex As Exception
            If threadaborted = True Then
                MessageBox.Show("Process has been aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub load_rr_item_sub1(po_det_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new4", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            Dim c_search As New Class_Receiving(rr_data)

            If rr_data.searchby = "Search By Date Received" Then
                newCMD.Parameters.AddWithValue("@n", 24)
                newCMD.Parameters.AddWithValue("@date_from", rr_data.date_from)
                newCMD.Parameters.AddWithValue("@date_to", rr_data.date_to)
            Else
                newCMD.Parameters.AddWithValue("@n", 5)
            End If

            newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)
            newCMD.CommandTimeout = 100

            newDR = newCMD.ExecuteReader
            Dim a(32) As String

            While newDR.Read
                Dim date_received As DateTime
                Dim po_date As DateTime

                If newDR.Item("date_received").ToString = "" Then
                    date_received = Date.Parse("1990-01-01")
                Else
                    date_received = Date.Parse(newDR.Item("date_received").ToString)
                End If

                If newDR.Item("po_date").ToString = "" Then
                    po_date = Date.Parse("1990-01-01")
                Else
                    po_date = Date.Parse(newDR.Item("po_date").ToString)
                End If


                a(0) = newDR.Item("rr_item_id").ToString
                a(1) = newDR.Item("rr_no").ToString
                a(2) = newDR.Item("po_no").ToString
                a(3) = newDR.Item("rs_no").ToString
                a(4) = newDR.Item("invoice_no").ToString
                a(5) = newDR.Item("SUPPLIER").ToString
                a(6) = Format(Date.Parse(date_received), "MM/dd/yyyy")
                a(7) = newDR.Item("received_by").ToString
                a(8) = newDR.Item("checked_by").ToString
                a(9) = CDec(newDR.Item("qty").ToString)
                a(10) = newDR.Item("whItem").ToString
                a(11) = newDR.Item("item_desc").ToString
                a(12) = newDR.Item("remarks").ToString
                a(13) = "received"
                a(14) = newDR.Item("type_of_purchasing").ToString
                a(15) = newDR.Item("CHARGES").ToString
                a(16) = newDR.Item("rs_id").ToString
                a(17) = newDR.Item("rr_info_id").ToString
                a(18) = FormatNumber(CDec(newDR.Item("total_amount").ToString), 2,,, TriState.True)
                a(19) = "-"
                a(20) = "-"
                a(21) = FSummarySupplyTransaction.day_and_days(IIf(DateDiff(DateInterval.Day, po_date, date_received) < 0, 0, DateDiff(DateInterval.Day, po_date, date_received)))
                a(22) = CDec(newDR.Item("amount").ToString).ToString("G17", CultureInfo.InvariantCulture) 'FormatNumber(CDec(newDR.Item("amount").ToString), 2,,, TriState.True)
                a(23) = newDR.Item("wh_id").ToString
                a(24) = newDR.Item("IN_OUT").ToString
                a(25) = "-"
                a(26) = newDR.Item("checked_by").ToString
                a(27) = newDR.Item("received_by").ToString
                a(28) = newDR.Item("purpose").ToString
                a(29) = newDR.Item("unit").ToString

                If Label7.InvokeRequired Then
                    Label7.Invoke(Sub() Label7.Text = newDR.Item("item_desc").ToString)
                Else
                    Label7.Text = newDR.Item("po_no").ToString
                End If

                Dim lvl As New ListViewItem(a)

                a(18) = 0
                a(22) = 0

                With lvl
                    .BackColor = Color.LightGreen
                    .ForeColor = Color.Black
                    .Font = New Font(New FontFamily("Arial"), 9, FontStyle.Italic)
                End With

                InvokeRequiredList(lvlreceivingreportlist, lvl)

                old_rs1 = newDR.Item("rs_no").ToString

                total_price1 = total_price1 + newDR.Item("amount").ToString
                total_amount1 = total_amount1 + newDR.Item("total_amount").ToString

                counter1 += 1
            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                If FlowLayoutPanel1.InvokeRequired Then
                    FlowLayoutPanel1.Invoke(Sub() FlowLayoutPanel1.Enabled = True)
                Else
                    FlowLayoutPanel1.Enabled = True
                End If
                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If Not thread.IsAlive Then
            'cmbProject.SelectedIndex = 1
            Label7.Text = "waiting..."
            Panel3.Visible = False
            Timer2.Stop()
            'lvlreceivingreportlist.Visible = True
            FlowLayoutPanel1.Enabled = True

            If threadaborted = True Then

            Else
                If ListBox1.Items.Count > 0 Then
                    Dim a1(32) As String
                    a1(22) = FormatNumber(total_price1, 2,,, TriState.True)
                    a1(18) = FormatNumber(total_amount1, 2,,, TriState.True)

                    Dim lvl1 As New ListViewItem(a1)
                    With lvl1
                        .BackColor = Color.White
                        .ForeColor = Color.Black
                        .Font = New Font(New FontFamily("Arial"), 11, FontStyle.Italic)
                    End With
                    InvokeRequiredList(lvlreceivingreportlist, lvl1)

                    total_amount1 = 0
                    total_price1 = 0
                End If
            End If

            threadaborted = False
            Button3.PerformClick()

        Else
            Panel3.Visible = True
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        counter1 = 0
        FlowLayoutPanel1.Enabled = False

        load_po_det_id1()

        If ListBox2.Items.Count = 0 Then
            lvlreceivingreportlist.Visible = True
            FlowLayoutPanel1.Enabled = True
            Exit Sub
        End If

        thread1 = New System.Threading.Thread(AddressOf panelvisible)
        thread1.Start()

        thread = New System.Threading.Thread(AddressOf load_rr2)
        thread.Start()
        Timer3.Start()
    End Sub

    Private Sub bw_ge_rr_data_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw_get_rr_data.DoWork
        new_receiving = New class_receiving_
        new_receiving.searchby = searchby
        new_receiving.search = mysearch 'txtSearch.Text
        new_receiving.item = items

        new_receiving.DateFrom = DateFrom
        new_receiving.DateTo = DateTo

        new_receiving.receiving()

    End Sub

    Private Sub timer_back_rr_item_lbox_Tick(sender As Object, e As EventArgs) Handles timer_back_rr_item_lbox.Tick
        If Not th_back_lbox1.IsAlive Then
            timer_back_rr_item_lbox.Stop()

            If ListBox1.InvokeRequired Then
                ListBox1.Invoke(Sub()
                                    cal_po_det_id = ListBox1.Items.Count
                                    lblRecords.Text = cal_po_det_id
                                End Sub)
            Else
                cal_po_det_id = ListBox1.Items.Count
                lblRecords.Text = cal_po_det_id
            End If

            Label7.Text = "Initializing... Step 4"

            thread = New System.Threading.Thread(AddressOf load_rr1)
            thread.Start()
            Timer2.Start()
        End If
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        threadaborted = True
        Label3.Visible = True

        thread1.Abort()
        th_export_excel.Abort()
        Panel1.Visible = False
    End Sub

    Private Sub bw_check_if_finish_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw_check_if_finish.DoWork
        check_if_done_process()
    End Sub

    Private Sub timer_export_excel_Tick(sender As Object, e As EventArgs) Handles timer_export_excel.Tick
        If Not th_export_excel.IsAlive Then
            timer_export_excel.Stop()
            Panel1.Visible = False
            lvlreceivingreportlist.Visible = True
        End If
    End Sub

    Private Sub bw_get_po_data_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw_get_po_data.DoWork

        Dim distinctrsno = From row In new_receiving.cListOfReceiving2
                           Select row.rs_no, row.po_det_id Distinct Order By rs_no Ascending

        Dim typeofpurchasing = From row In new_receiving.cListOfReceiving2
                               Select row.type_of_purchasing Take 1 Distinct Order By rs_no Ascending

        Dim typeofp As String = ""
        For Each row In typeofpurchasing
            typeofp = row
        Next

        new_po = New class_receiving_
        For Each row In distinctrsno
            new_po.search = row.rs_no
            new_po.typeofpurchasing = typeofp
            new_po.po_det_id = row.po_det_id
            new_po.po()
        Next

    End Sub

    Private Sub timer_sort_item_lbox_Tick(sender As Object, e As EventArgs) Handles timer_sort_item_lbox.Tick
        If Not th_sort_lisview.IsAlive Then
            timer_sort_item_lbox.Stop()
            'ListView1.Visible = True

            Label7.Text = "Finalizing..."


            th_back_lbox1 = New System.Threading.Thread(AddressOf load_rr6)
            th_back_lbox1.Start()
            timer_back_rr_item_lbox.Start()

        End If
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        If Not thread.IsAlive Then
            'cmbProject.SelectedIndex = 1
            Label7.Text = "waiting..."
            Panel3.Visible = False
            Timer3.Stop()
            lvlreceivingreportlist.Visible = True
            FlowLayoutPanel1.Enabled = True

            If threadaborted = True Then

            Else
                If ListBox1.Items.Count > 0 Then
                    Dim a1(32) As String
                    a1(22) = FormatNumber(total_price1, 2,,, TriState.True)
                    a1(18) = FormatNumber(total_amount1, 2,,, TriState.True)

                    Dim lvl1 As New ListViewItem(a1)
                    With lvl1
                        .BackColor = Color.White
                        .ForeColor = Color.Black
                        .Font = New Font(New FontFamily("Arial"), 11, FontStyle.Italic)
                    End With
                    InvokeRequiredList(lvlreceivingreportlist, lvl1)

                    total_amount1 = 0
                    total_price1 = 0
                End If
            End If

            threadaborted = False
        Else
            Panel3.Visible = True
        End If
    End Sub

    Private Sub bw_compile_data_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw_compile_data.DoWork
        Dim grand_total_price As Double
        Dim grand_total_amount As Double

        Dim PO = From p In new_po.cListOfPO2
                 Select p.po_det_id, p.po_cvno, p.supplier, p.po_date, p.po_qty,
                        p.item_name, p.item_desc, p.remarks, p.charges, p.wh_id, p.rs_no,
                        p.inout, p.rs_purpose, p.unit Order By po_date Ascending

        Dim cRSNO As String = ""
        Dim counter As Integer = 0


        'for price and totalamount in subtotal row
        Dim price As Double
        Dim totalamount As Double

        'THIS CODE IS FOR CASH WITH RR
        If new_po.typeofpurchasing = "CASH WITH RR" Then

            For Each row2 In new_receiving.cListOfReceiving2
                Dim rrdata As New class_receiving_.rr_data2

                'add subtotal 
                If counter = 0 Then
                Else
                    If cRSNO <> row2.rs_no Then
                        Dim subtotal As New class_receiving_.rr_data2

                        With subtotal
                            .supplier = "Subtotal:"
                            .price = price
                            .total_amount = totalamount
                            .sorting = "CC"

                            'reset
                            price = 0
                            totalamount = 0

                            cListOfReceiving.Add(subtotal)
                        End With
                    End If
                End If

                With rrdata
                    .rr_item_id = row2.rr_item_id
                    .rr_info_id = row2.rr_info_id
                    .rs_id = row2.rs_id
                    .rr_no = row2.rr_no
                    .po_cv_no = "N/A"
                    .rs_no = row2.rs_no
                    .invoice_no = row2.invoice_no
                    .supplier = row2.supplier
                    .date_received = row2.date_received
                    .rr_qty = row2.rr_qty
                    .price = row2.price
                    .total_amount = row2.price * row2.rr_qty
                    .item_name = row2.item_name
                    .item_desc = row2.item_desc
                    .remarks = row2.remarks
                    .status = "received"
                    .type_of_purchasing = row2.type_of_purchasing
                    .charges = row2.charges
                    .wh_id = row2.wh_id
                    .inout = row2.inout
                    .checked_by = row2.checked_by
                    .received_by = row2.received_by
                    .rs_purpose = row2.rs_purpose
                    .unit = row2.unit
                    .lead_time = 0
                    .sorting = "B"

                    cListOfReceiving.Add(rrdata)

                    price += row2.price
                    totalamount += .total_amount

                    grand_total_price += row2.price
                    grand_total_amount += .total_amount



                End With



                cRSNO = row2.rs_no
                counter += 1
            Next
        End If
        '---------END-------------------

        For Each row In PO
            'HEADER

            Dim podata As New class_receiving_.rr_data2

            'add subtotal 
            If counter = 0 Then
            Else
                If cRSNO <> row.rs_no Then
                    Dim subtotal As New class_receiving_.rr_data2

                    With subtotal
                        .supplier = "Subtotal:"
                        .price = price
                        .total_amount = totalamount
                        .sorting = "CC"

                        'reset
                        price = 0
                        totalamount = 0

                        cListOfReceiving.Add(subtotal)
                    End With
                End If
            End If

            With podata

                .po_det_id = row.po_det_id
                .rr_no = "-"
                .po_cv_no = row.po_cvno
                .rs_no = row.rs_no
                .invoice_no = "-"
                .supplier = row.supplier
                .date_received = row.po_date
                .rr_qty = row.po_qty
                .price = "-"
                .total_amount = "-"
                .item_name = row.item_name
                .item_desc = row.item_desc
                .remarks = row.remarks
                .status = "-"
                .type_of_purchasing = "-"
                .charges = row.charges
                .wh_id = row.wh_id
                .inout = row.inout
                .checked_by = "-"
                .received_by = "-"
                .rs_purpose = row.rs_purpose
                .unit = row.unit
                .sorting = "A"

                cListOfReceiving.Add(podata)
            End With

            'BODY
            For Each row2 In new_receiving.cListOfReceiving2
                Dim rrdata As New class_receiving_.rr_data2

                If row.po_det_id = row2.po_det_id Then
                    Dim properName As New PropsFields.whItems_properName_fields
                    properName = getProperNameUsingWhPnId2(row2.wh_pn_id)
                    Dim propName As String = ""

                    If properName IsNot Nothing Then
                        propName = $" → {properName.item_desc}"

                    End If

                    With rrdata
                        .rr_item_id = row2.rr_item_id
                        .rr_info_id = row2.rr_info_id
                        .rs_id = row2.rs_id
                        .rr_no = row2.rr_no
                        .po_cv_no = row.po_cvno
                        .rs_no = row2.rs_no
                        .invoice_no = row2.invoice_no
                        .supplier = row2.supplier
                        .date_received = row2.date_received
                        .rr_qty = row2.rr_qty
                        .price = row2.price
                        .total_amount = row2.price * row2.rr_qty
                        .item_name = row.item_name
                        .item_desc = row2.item_desc & $"{propName}"
                        .remarks = row2.remarks
                        .status = "received"
                        .type_of_purchasing = row2.type_of_purchasing
                        .charges = row2.charges
                        .wh_id = row2.wh_id
                        .inout = row.inout
                        .checked_by = row2.checked_by
                        .received_by = row2.received_by
                        .rs_purpose = row.rs_purpose
                        .unit = row2.unit
                        .lead_time = FSummarySupplyTransaction.day_and_days(IIf(DateDiff(DateInterval.Day, row.po_date, row2.date_received) < 0, 0, DateDiff(DateInterval.Day, row.po_date, row2.date_received)))
                        .date_submitted = row2.date_submitted
                        .serial_id = row2.serial_id
                        .sorting = "B"

                        cListOfReceiving.Add(rrdata)

                        price += row2.price
                        totalamount += .total_amount

                        grand_total_price += row2.price
                        grand_total_amount += .total_amount
                    End With

                End If
            Next

            cRSNO = row.rs_no
            counter += 1
        Next

continuehere:

        'add lastsubtotal
        Dim lastsubtotal As New class_receiving_.rr_data2
        With lastsubtotal
            .supplier = "Subtotal:"
            .price = price
            .total_amount = totalamount
            .sorting = "CC"

            'reset 
            price = 0
            totalamount = 0

            cListOfReceiving.Add(lastsubtotal)
        End With

        'add grandtotal
        Dim grandtotaldata As New class_receiving_.rr_data2
        With grandtotaldata
            .supplier = "Grandtotal:"
            .price = grand_total_price
            .total_amount = grand_total_amount
            .sorting = "C"

            cListOfReceiving.Add(grandtotaldata)
        End With


    End Sub

    Private Sub compiledReceivingData()

        Dim newPOData = From p In cPoData
                        Select p.po_det_id, p.po_no, p.Supplier_Name, p.po_date, p.qty,
                        p.Item_Name, p.Item_Desc, p.remarks, p.charges, p.wh_id, p.rs_no,
                        p.inout, p.rs_purpose, p.unit, p.rs_date Order By po_date, rs_no Ascending

        Dim newRRData = From p In cRrData
                        Select p Order By p.date_received Ascending


        lvlreceivingreportlist.Items.Clear()


        'initialize data
        Dim lastPoNo As String = ""
        Dim rowIndex As Integer

        Dim totalPrice As Double
        Dim totalAmount As Double
        Dim grandTotalPrice As Double
        Dim grandTotalAmount As Double

        For Each poRow In newPOData

            Dim a(31) As String

#Region "PO ROWS"
            a(0) = poRow.po_det_id
            a(1) = "-"
            a(2) = poRow.po_no
            a(3) = poRow.rs_no
            a(4) = "-"
            a(5) = poRow.Supplier_Name
            a(6) = poRow.po_date

            a(10) = poRow.Item_Name
            a(11) = poRow.Item_Desc
            a(12) = poRow.remarks
            a(14) = "PURCHASE ORDER"
            a(15) = poRow.charges

            a(23) = poRow.wh_id
            a(24) = poRow.inout
            a(28) = poRow.rs_purpose
            a(29) = poRow.unit
            a(31) = poRow.rs_date

#End Region
            Dim tempPoNo As String = poRow.po_no 'store poNo to compare every row


            If tempPoNo <> lastPoNo Then 'this if statement is for adding po header

                If rowIndex <> 0 Then 'if not first row

                    'add sub total here
                    addListViewItemSubTotal("Subtotal:", totalPrice, totalAmount)
                    grandTotalPrice += totalPrice
                    grandTotalAmount += totalAmount

                    totalAmount = 0
                    totalPrice = 0


                    'add po header 
                    listViewItemRowDesign(a, Color.DarkGreen, Color.White, New Font(New FontFamily("Arial"), 10, FontStyle.Bold))
                    rowIndex += 1

                Else 'if first row
                    'add po header 
                    listViewItemRowDesign(a, Color.DarkGreen, Color.White, New Font(New FontFamily("Arial"), 10, FontStyle.Bold))
                    rowIndex += 1
                End If


            End If

            'FOR RR ROW
            For Each rrRow In newRRData

                If poRow.po_det_id = rrRow.po_det_id Then

#Region "RR ROWS"
                    a(0) = rrRow.rr_item_id
                    a(1) = rrRow.rr_no
                    a(2) = poRow.po_no
                    a(3) = rrRow.rs_no
                    a(4) = rrRow.invoice_no
                    a(5) = rrRow.supplier
                    a(6) = rrRow.date_received
                    a(7) = rrRow.received_by
                    a(8) = rrRow.checked_by
                    a(9) = rrRow.rr_qty
                    a(10) = rrRow.item_name
                    a(11) = rrRow.item_desc
                    a(12) = rrRow.remarks
                    a(13) = rrRow.status
                    a(14) = rrRow.type_of_purchasing
                    a(15) = rrRow.charges
                    a(16) = rrRow.rs_id 'rsid
                    a(17) = rrRow.rr_info_id  'rr_info_id
                    'a(18) = IIf(IsNumeric(row.total_amount), CDec(row.total_amount).ToString("G17", CultureInfo.InvariantCulture), 0)
                    If rrRow.total_amount = "-" Then
                    Else
                        a(18) = CDec(rrRow.price * rrRow.rr_qty).ToString("N", CultureInfo.InvariantCulture) 'CDec(rrRow.total_amount).ToString("N", CultureInfo.InvariantCulture)
                    End If

                    a(19) = 0 'total 
                    a(20) = 0
                    a(21) = FSummarySupplyTransaction.day_and_days(IIf(DateDiff(DateInterval.Day, poRow.po_date, rrRow.date_received) < 0, 0, DateDiff(DateInterval.Day, poRow.po_date, rrRow.date_received)))
                    a(22) = CDec(rrRow.price).ToString("N", CultureInfo.InvariantCulture)
                    a(23) = rrRow.wh_id
                    a(24) = rrRow.inout
                    a(25) = 0
                    a(26) = rrRow.checked_by
                    a(27) = rrRow.received_by
                    a(28) = rrRow.rs_purpose
                    a(29) = rrRow.unit
                    a(30) = IIf(rrRow.date_submitted = "12:00 AM", "-", rrRow.date_submitted)
                    a(31) = poRow.rs_date

#End Region
                    'add rr row
                    listViewItemRowDesign(a,
                                          Color.LightGreen,
                                          Color.Black,
                                          New Font(New FontFamily("Arial"), 9, FontStyle.Italic))

                    lastPoNo = poRow.po_no 'this line used for adding po header 

                    'add totalamount and totalprice here
                    totalPrice += rrRow.price
                    totalAmount += (rrRow.price * rrRow.rr_qty)

                    rowIndex += 1
                    Exit For
                End If
            Next
        Next

        If rowIndex <> 0 Then
            addListViewItemSubTotal("Subtotal:", totalPrice, totalAmount)
            grandTotalPrice += totalPrice
            grandTotalAmount += totalAmount

            totalAmount = 0
            totalPrice = 0
        End If

        'CASH WITH RR

#Region "CASH WITH RR HEADER"
        Dim ab(30) As String

        For i = 0 To ab.Length - 1
            ab(i) = "-"
        Next

        ab(5) = "CASH WITH RR"

        listViewItemRowDesign(ab, Color.DarkGreen, Color.White, New Font(New FontFamily("Arial"), 12, FontStyle.Bold))

#End Region

        For Each rrRow In newRRData
            Dim a(31) As String
            If rrRow.type_of_purchasing = "CASH WITH RR" Then

#Region "CASH WITH RR ROW"
                a(0) = rrRow.rr_item_id
                a(1) = rrRow.rr_no
                a(2) = "-"
                a(3) = rrRow.rs_no
                a(4) = rrRow.invoice_no
                a(5) = rrRow.supplier
                a(6) = rrRow.date_received
                a(7) = rrRow.received_by
                a(8) = rrRow.checked_by
                a(9) = rrRow.rr_qty
                a(10) = rrRow.item_name
                a(11) = rrRow.item_desc
                a(12) = rrRow.remarks
                a(13) = rrRow.status
                a(14) = rrRow.type_of_purchasing
                a(15) = rrRow.charges
                a(16) = rrRow.rs_id 'rsid
                a(17) = rrRow.rr_info_id  'rr_info_id
                'a(18) = IIf(IsNumeric(row.total_amount), CDec(row.total_amount).ToString("G17", CultureInfo.InvariantCulture), 0)
                If rrRow.total_amount = "-" Then
                Else
                    a(18) = CDec(rrRow.price * rrRow.rr_qty).ToString("N", CultureInfo.InvariantCulture)
                End If

                a(19) = 0 'total 
                a(20) = 0
                a(21) = "-"
                a(22) = CDec(rrRow.price).ToString("N", CultureInfo.InvariantCulture)
                a(23) = rrRow.wh_id
                a(24) = rrRow.inout
                a(25) = 0
                a(26) = rrRow.checked_by
                a(27) = rrRow.received_by
                a(28) = rrRow.rs_purpose
                a(29) = rrRow.unit
                a(30) = IIf(rrRow.date_submitted = "12:00 AM", "-", rrRow.date_submitted)
                a(31) = rrRow.rs_date
#End Region

                'add cash with rr row
                listViewItemRowDesign(a, Color.LightGreen, Color.Black, New Font(New FontFamily("Arial"), 9, FontStyle.Italic))

                'add totalamount and totalprice here
                totalPrice += rrRow.price
                totalAmount += (rrRow.price * rrRow.rr_qty)
            End If
        Next


        addListViewItemSubTotal("Subtotal:", totalPrice, totalAmount)
        grandTotalPrice += totalPrice
        grandTotalAmount += totalAmount

        totalAmount = 0
        totalPrice = 0

        addListViewItemSubTotal("Grandtotal", grandTotalPrice, grandTotalAmount)
        grandTotalPrice = 0
        grandTotalAmount = 0



        'FOR SUBTOTAL ROW
        'Dim bb(30) As String
        '    bb(5) = "Subtotal:"
        '    bb(18) = 0 'total amount
        '    bb(22) = 0 'price

        '    Dim lvl3 As New ListViewItem(bb)
        '    lvl3.BackColor = Color.White
        '    lvl3.ForeColor = Color.Black
        '    lvl3.Font = New Font(New FontFamily("Arial"), 12, FontStyle.Bold)

        '    lvlreceivingreportlist.Items.Add(lvl3)

    End Sub

    Private Sub addListViewItemSubTotal(caption As String, totalPrice As Double, totalAmount As Double)

        'FOR SUBTOTAL ROW
        Dim a(30) As String

        For i = 0 To a.Count - 1
            a(i) = "-"
        Next

        a(5) = caption
        a(18) = totalAmount.ToString("N", CultureInfo.InvariantCulture)  'total amount
        a(22) = totalPrice.ToString("N", CultureInfo.InvariantCulture)  'price

        listViewItemRowDesign(a, Color.White, Color.Black, New Font(New FontFamily("Arial"), 11, FontStyle.Bold))
    End Sub

    Private Sub listViewItemRowDesign(a() As String, bgColor As Color, fontColor As Color, Optional fontStyle As Font = Nothing)

        Dim lvl2 As New ListViewItem(a)
        lvl2.BackColor = bgColor
        lvl2.ForeColor = fontColor
        lvl2.Font = fontStyle

        lvlreceivingreportlist.Items.Add(lvl2)
    End Sub
    Private Sub timer_store_item_listview_Tick(sender As Object, e As EventArgs) Handles timer_store_item_listview.Tick
        If Not th_store_listview.IsAlive Then
            timer_store_item_listview.Stop()

            With rr_data
                .listview = ListView1
            End With

            Label7.Text = "Initializing...On process..."
            'sort listview
            th_sort_lisview = New System.Threading.Thread(AddressOf load_rr5)
            th_sort_lisview.Start()
            timer_sort_item_lbox.Start()

        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        abcdf()
    End Sub

    Private Sub bw_get_supplier_data_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw_get_supplier_data.DoWork

        supplier.supplier_data()
        Dim d As New class_aggregates_obj
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)

        thread = New System.Threading.Thread(AddressOf load_rr4)
        thread.Start()

    End Sub

    Private Sub bw_get_items_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw_get_items.DoWork
        myItems.search = ""
        myItems.search_option = ""

        myItems.item()

    End Sub

    Private Sub bw_check_if_done_supp_items_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw_check_if_done_supp_items.DoWork
        check_if_done_supp_items()
    End Sub
    Private Sub check_if_done_supp_items()
        While True
            If a1 = True And a2 = True Then
                Exit While
            End If
        End While
    End Sub
    Private Sub timer_store_item_lbox1_Tick(sender As Object, e As EventArgs) Handles timer_store_item_lbox1.Tick
        If Not th_store_lisbox.IsAlive Then
            timer_store_item_lbox1.Stop()

            Label7.Text = "Initializing...Just a moment.."
            th_store_listview = New System.Threading.Thread(AddressOf load_rr4)
            th_store_listview.Start()
            timer_store_item_listview.Start()
        End If
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged

    End Sub

    Private Sub bw_type_charges_name_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw_type_charges_name.DoWork
        myCharges.get_charges_category_name()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        threadaborted = True
        thread.Abort()
        Panel3.Visible = False

    End Sub

    Private Sub bw_check_if_done_typeofchargesname_DoWork(sender As Object, e As DoWorkEventArgs)
        check_if_done_charges_items()
    End Sub
    Private Sub check_if_done_charges_items()
        While True
            If a1 = True And a2 = True Then
                Exit While
            End If
        End While
    End Sub
    Private Sub EditAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditAllToolStripMenuItem.Click
        With FCreateReceiving
            .isEdit = True

            Dim selectedRow = lvlreceivingreportlist.SelectedItems(0)

            With .rrDataForEdit
                .po_det_id = 0
                .item_description = selectedRow.SubItems(11).Text
                .po_no = selectedRow.SubItems(2).Text
                .po_qty_balance = "-"
                .rr_qty = selectedRow.SubItems(9).Text
                .unit = selectedRow.SubItems(29).Text
                .unit_price = selectedRow.SubItems(22).Text
                .amount = FormatNumber(CDbl(.rr_qty) * CDbl(.unit_price)).ToString() 'selectedRow.SubItems(19).Text
                .rs_id = 0
            End With

            .ShowDialog()
        End With
    End Sub

    Private Sub txtSearch_GotFocus(sender As Object, e As EventArgs) Handles txtSearch.GotFocus
        Dim txtbox As TextBox = sender

        Select Case txtbox.Text
            Case "RR No..."
                txtbox.Text = ""

            Case "Po/CV No..."
                txtbox.Text = ""

            Case "Rs No..."
                txtbox.Text = ""

            Case "Items..."
                txtbox.Text = ""

            Case "Charges..."
                txtbox.Text = ""

            Case "Supplier..."
                txtbox.Text = ""

            Case "Invoice No..."
                txtbox.Text = ""
        End Select

    End Sub

    Private Sub txtItem_GotFocus(sender As Object, e As EventArgs) Handles txtItem.GotFocus
        Dim txtbox As TextBox = sender

        If sender.text = "Items..." Then
            txtbox.Text = ""
        End If
    End Sub

    Private Sub txtItems_Leave(sender As Object, e As EventArgs) Handles txtItem.Leave
        Dim txtbox As TextBox = sender

        If txtbox.Text = "" Then
            txtbox.Text = "Items..."
        End If

    End Sub

    Private Sub txtItem_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItem.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()

        End If
    End Sub

    Private Sub bw_get_rr_data_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw_get_rr_data.RunWorkerCompleted
        r1 = True
    End Sub

    Private Sub check_if_done_process()
        While True
            If r1 = True Then
                Exit While
            End If
        End While
    End Sub

    Private Sub bw_check_if_finish_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw_check_if_finish.RunWorkerCompleted

        bw_get_po_data = New BackgroundWorker
        bw_get_po_data.WorkerSupportsCancellation = True
        bw_get_po_data.RunWorkerAsync()

    End Sub

    Private Sub bw_get_po_data_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw_get_po_data.RunWorkerCompleted
        'MsgBox(new_po.cListOfPO2.Count)

        bw_compile_data = New BackgroundWorker
        bw_compile_data.WorkerSupportsCancellation = True
        bw_compile_data.RunWorkerAsync()

        'abcdf()

    End Sub

    Private Sub abcdf()
        lvlreceivingreportlist.Items.Clear()
        Dim l As New List(Of ListViewItem)

        For Each row In cListOfReceiving
            Dim a(40) As String

            a(0) = row.rr_item_id
            a(1) = row.rr_no
            a(2) = row.po_cv_no
            a(3) = row.rs_no
            a(4) = row.invoice_no
            a(5) = row.supplier

            a(7) = row.received_by
            a(8) = row.checked_by

            a(10) = row.item_name
            a(11) = row.item_desc
            a(12) = row.remarks
            a(13) = row.status
            a(14) = row.type_of_purchasing
            a(15) = row.charges
            a(16) = row.rs_id 'rsid
            a(17) = row.rr_info_id  'rr_info_id
            'a(18) = IIf(IsNumeric(row.total_amount), CDec(row.total_amount).ToString("G17", CultureInfo.InvariantCulture), 0)
            If row.total_amount = "-" Then
            Else
                a(18) = CDec(row.total_amount).ToString("N", CultureInfo.InvariantCulture)
            End If
            a(19) = 0 'total 
            a(20) = 0
            a(21) = row.lead_time

            If row.sorting = "C" Then
                a(6) = ""
                a(9) = ""
                a(22) = CDec(row.price).ToString("N", CultureInfo.InvariantCulture)
            ElseIf row.sorting = "CC" Then
                a(6) = ""
                a(9) = ""
                a(22) = CDec(row.price).ToString("N", CultureInfo.InvariantCulture)
            Else
                a(6) = row.date_received
                a(9) = row.rr_qty
                a(22) = row.price
            End If

            a(23) = row.wh_id
            a(24) = row.inout
            a(25) = 0
            a(26) = row.checked_by
            a(27) = row.received_by
            a(28) = row.rs_purpose
            a(29) = row.unit
            a(30) = IIf(row.date_submitted = "12:00 AM", "-", row.date_submitted)

            Dim lvl As New ListViewItem(a)
            If row.sorting = "A" Then
                lvl.BackColor = Color.DarkGreen
                lvl.ForeColor = Color.White
                lvl.Font = New Font(New FontFamily("Arial"), 11, FontStyle.Bold)

            ElseIf row.sorting = "B" Then
                lvl.BackColor = Color.LightGreen
                lvl.ForeColor = Color.Black
                lvl.Font = New Font(New FontFamily("Arial"), 10, FontStyle.Italic)

            ElseIf row.sorting = "C" Then
                lvl.BackColor = Color.White
                lvl.ForeColor = Color.Black
                lvl.Font = New Font(New FontFamily("Arial"), 12, FontStyle.Bold)

            ElseIf row.sorting = "CC" Then
                lvl.BackColor = Color.White
                lvl.ForeColor = Color.Black
                lvl.Font = New Font(New FontFamily("Arial"), 10, FontStyle.Bold)
            End If

            l.Add(lvl)
        Next
        'ADD DATA TO LISTVIEW
        lvlreceivingreportlist.Items.AddRange(l.ToArray)

        'REMOVE UNNECESSARY DATA
        Select Case cmbSearch.Text
            Case "Search By RR No", "Search By PO and CV No", "Search By Invoice No."
                'REMOVE ALL PO NA WALAY REFLECT RR
                Dim colorint As Integer
                For Each row As ListViewItem In lvlreceivingreportlist.Items

                    If row.BackColor = Color.DarkGreen Then
                        'check iyang sunod og darkgreen ba ghapun 
                        If colorint = 0 Then
                        Else
                            If lvlreceivingreportlist.Items(colorint - 1).BackColor = Color.DarkGreen Then
                                'REMOVE
                                row.Remove()
                            ElseIf lvlreceivingreportlist.Items(colorint + 1).BackColor = Color.White Then
                                row.Remove()
                            End If
                        End If
                    End If
                    colorint += 1
                Next
        End Select

        Panel3.Visible = False


    End Sub

    Private Sub bw_compile_data_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw_compile_data.RunWorkerCompleted
        'MsgBox(cListOfReceiving.Count)
        abcdf()

    End Sub

    Private Sub bw_get_supplier_data_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw_get_supplier_data.RunWorkerCompleted
        a1 = True
    End Sub

    Private Sub bw_get_items_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw_get_items.RunWorkerCompleted
        a2 = True
    End Sub

    Private Sub bw_check_if_done_supp_items_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw_check_if_done_supp_items.RunWorkerCompleted

        With FReceiving_Searchby
            If cmbSearch.Text = "Search By Supplier" Then

                .listofsupplier.cListOfSupplier = supplier.cListOfSupplier
                .listofitems.cListOfItems = myItems.cListOfItems
                .cmbCharges.Enabled = False
                .txtname = "Supplier"

            ElseIf cmbSearch.Text = "Search By Charges" Then

                .listofcharges.cListChargesCatName = myCharges.cListChargesCatName
                .listofitems.cListOfItems = myItems.cListOfItems
                .cmbCharges.Enabled = True
                .txtname = "Charges"

            End If

            .ShowDialog()

        End With

    End Sub

    Private Sub bw_type_charges_name_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw_type_charges_name.RunWorkerCompleted
        a1 = True
    End Sub
End Class