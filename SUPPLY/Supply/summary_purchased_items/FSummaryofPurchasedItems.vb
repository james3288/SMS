Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FSummaryofPurchasedItems
    Dim sqLCON As New SQLcon
    Dim NEWcmd As SqlCommand
    Dim NEWdr As SqlDataReader
    Dim IsFormBeingDragged As Boolean
    Dim drag As Boolean
    Dim MouseDownX As Integer
    Dim MouseDownY As Integer
    Dim itemlist As New List(Of List(Of String))


#Region "DragForm/Panel"
    Private Sub pboxHeader_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pboxHeader.MouseDown, Label15.MouseDown
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
        End If
    End Sub

    Private Sub pboxHeader_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pboxHeader.MouseMove, Label15.MouseMove
        If IsFormBeingDragged Then
            Dim temp As Point = New Point()

            temp.X = Me.Location.X + (e.X - MouseDownX)
            temp.Y = Me.Location.Y + (e.Y - MouseDownY)
            Me.Location = temp
            temp = Nothing
        End If
    End Sub

    Private Sub pboxHeader_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pboxHeader.MouseUp, Label15.MouseUp
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
    End Sub

    Private Sub panel_POdateSearch_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panel_POdateSearch.MouseDown
        drag = True
        MouseDownX = Windows.Forms.Cursor.Position.X - panel_POdateSearch.Left
        MouseDownY = Windows.Forms.Cursor.Position.Y - panel_POdateSearch.Top
    End Sub

    Private Sub panel_POdateSearch_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panel_POdateSearch.MouseMove
        If drag Then
            panel_POdateSearch.Top = Windows.Forms.Cursor.Position.Y - MouseDownY
            panel_POdateSearch.Left = Windows.Forms.Cursor.Position.X - MouseDownX
        End If
    End Sub

    Private Sub panel_POdateSearch_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panel_POdateSearch.MouseUp
        drag = False
    End Sub

#End Region

    Private Sub FSummaryofPurchasedItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        panel_POdateSearch.Visible = False
        panel_RRdateSearch.Visible = False
        Label15.Parent = pboxHeader
        btnExit.Parent = pboxHeader
        btn_exit.Parent = panel_POdateSearch
        load_purchased_items()
        Loadsupplier()


    End Sub

    Public Sub load_purchased_items()
        lvl_summaryofpurchasedItems.Items.Clear()
        Try
            sqLCON.connection.Open()
            NEWcmd = New SqlCommand("proc_purchase_order_query", sqLCON.connection)
            NEWcmd.Parameters.Clear()
            NEWcmd.CommandType = CommandType.StoredProcedure
            NEWcmd.Parameters.AddWithValue("@n", 16)
            NEWdr = NEWcmd.ExecuteReader
            While NEWdr.Read
                Dim x(10) As String
                x(0) = Format(Date.Parse(NEWdr.Item("date_req").ToString), "MM/dd/yyyy")
                x(1) = Format(Date.Parse(NEWdr.Item("po_date").ToString), "MM/dd/yyyy")
                x(2) = NEWdr.Item("qty").ToString
                x(3) = NEWdr.Item("unit").ToString

                'x(4) = NEWdr.Item("whItem").ToString
                Dim type As String = NEWdr.Item("IN_OUT").ToString

                If type = "FACILITIES" Or type = "TOOLS" Then
                    x(4) = get_item_name(NEWdr.Item("wh_id").ToString, 1)
                Else
                    x(4) = get_item_name(NEWdr.Item("wh_id").ToString, 2)
                End If

                x(5) = NEWdr.Item("item_description").ToString
                x(6) = NEWdr.Item("supplier").ToString
                x(7) = NEWdr.Item("po_no").ToString
                x(8) = NEWdr.Item("rs_no").ToString
                x(9) = NEWdr.Item("rr_no").ToString
                x(10) = FormatNumber(NEWdr.Item("amount"), 2, , , TriState.True)

                Dim lvlList As New ListViewItem(x)
                lvl_summaryofpurchasedItems.Items.Add(lvlList)

            End While
            NEWdr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqLCON.connection.Close()
        End Try
    End Sub

    Public Function get_item_name(ByVal id As Integer, ByVal n As Integer)
        Dim SQ As New SQLcon
        Dim DR As SqlDataReader
        Dim CMD As SqlCommand
        cmb_supplierName.Items.Clear()

        If n = 1 Then
            Try
                SQ.connection.Open()
                publicquery = "SELECT facility_name FROM dbfacilities_names WHERE fac_id = '" & id & "'"
                CMD = New SqlCommand(publicquery, SQ.connection)
                DR = CMD.ExecuteReader
                While DR.Read
                    get_item_name = DR.Item("facility_name").ToString
                End While
                DR.Close()
            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                SQ.connection.Close()
            End Try


        ElseIf n = 2 Then
            Try
                SQ.connection.Open()
                publicquery = "SELECT whItem FROM dbwarehouse_items WHERE wh_id = '" & id & "'"
                CMD = New SqlCommand(publicquery, SQ.connection)
                DR = CMD.ExecuteReader
                While DR.Read
                    get_item_name = DR.Item("whItem").ToString
                End While
                DR.Close()
            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                SQ.connection.Close()
            End Try
        End If

    End Function

    Public Sub Loadsupplier()
        Dim SQ As New SQLcon
        Dim DR As SqlDataReader
        Dim CMD As SqlCommand
        cmb_supplierName.Items.Clear()
        Try
            SQ.connection.Open()
            publicquery = "SELECT Supplier_Name FROM dbSupplier ORDER BY Supplier_Name ASC"
            CMD = New SqlCommand(publicquery, SQ.connection)
            DR = CMD.ExecuteReader
            While DR.Read
                cmb_supplierName.Items.Add(DR.Item("Supplier_Name").ToString)
            End While
            DR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Public Sub Search_PurchasedItems(ByVal supplier As String, ByVal dateFrom As Date, ByVal dateTO As Date)
        lvl_summaryofpurchasedItems.Items.Clear()
        Dim newsql As New SQLcon
        Dim newdir As SqlDataReader
        Dim newcmd As SqlCommand

        Try
            newsql.connection.Open()
            newcmd = New SqlCommand("proc_purchase_order_query", newsql.connection)
            newcmd.Parameters.Clear()
            newcmd.CommandType = CommandType.StoredProcedure
            newcmd.Parameters.AddWithValue("@n", 15)
            newcmd.Parameters.AddWithValue("@po_date", dateFrom)
            newcmd.Parameters.AddWithValue("@po_date2", dateTO)
            newcmd.Parameters.AddWithValue("@supplier", supplier)

            newdir = newcmd.ExecuteReader()

            If newdir.HasRows Then
                While newdir.Read
                    Dim x(10) As String

                    x(0) = Format(Date.Parse(newdir.Item("date_req").ToString), "MM/dd/yyyy")
                    x(1) = Format(Date.Parse(newdir.Item("po_date").ToString), "MM/dd/yyyy")
                    x(2) = newdir.Item("qty").ToString
                    x(3) = newdir.Item("unit").ToString
                    'x(4) = newdir.Item("whItem").ToString

                    Dim type As String = newdir.Item("IN_OUT").ToString

                    If type = "FACILITIES" Or type = "TOOLS" Then
                        x(4) = get_item_name(newdir.Item("wh_id").ToString, 1)
                    Else
                        x(4) = get_item_name(newdir.Item("wh_id").ToString, 2)
                    End If

                    x(5) = newdir.Item("item_description").ToString
                    x(6) = newdir.Item("supplier").ToString
                    x(7) = newdir.Item("po_no").ToString
                    x(8) = newdir.Item("rs_no").ToString
                    x(9) = newdir.Item("rr_no").ToString
                    x(10) = FormatNumber(newdir.Item("amount"), 2, , , TriState.True)

                    Dim lvlList As New ListViewItem(x)
                    lvl_summaryofpurchasedItems.Items.Add(lvlList)

                End While
            Else
                MessageBox.Show("Data doesn't exist...", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            newdir.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsql.connection.Close()
        End Try
    End Sub


    'Public Sub Search_PurchasedItems()
    '    Dim sql As New SQLcon
    '    Dim newdir As SqlDataReader
    '    Dim counter As Integer = 0
    '    lvl_summaryofpurchasedItems.Items.Clear()
    '    Try
    '        sql.connection.Open()
    '        Dim newcmd As New SqlCommand("proc_purchase_order_query", sql.connection)
    '        newcmd.Parameters.Clear()
    '        newcmd.CommandType = CommandType.StoredProcedure
    '        newcmd.Parameters.AddWithValue("@n", 15)
    '        newcmd.Parameters.AddWithValue("@po_date", Format(Date.Parse(dtp_poDate_From.Text), "MM/dd/yyyy"))
    '        newcmd.Parameters.AddWithValue("@po_date2", Format(Date.Parse(dtp_poDate_To.Text), "MM/dd/yyyy"))
    '        newcmd.Parameters.AddWithValue("@supplier", cmb_supplierName.Text)

    '        newdir = newcmd.ExecuteReader

    '        If newdir.HasRows Then
    '            While newdir.Read
    '                Dim x(10) As String
    '                x(0) = Format(Date.Parse(newdir.Item("date_req").ToString), "MM/dd/yyyy")
    '                x(1) = Format(Date.Parse(newdir.Item("po_date").ToString), "MM/dd/yyyy")
    '                x(2) = newdir.Item("qty").ToString
    '                x(3) = newdir.Item("unit").ToString

    '                'x(4) = newdir.Item("whItem").ToString
    '                'x(5) = newdir.Item("item_description").ToString

    '                'Dim type As String = NEWdr.Item("IN_OUT").ToString

    '                'If type = "FACILITIES" Or type = "TOOLS" Then
    '                '    x(4) = get_item_name(NEWdr.Item("wh_id").ToString, 1)
    '                'Else
    '                '    x(4) = get_item_name(NEWdr.Item("wh_id").ToString, 2)
    '                'End If

    '                x(6) = newdir.Item("supplier").ToString
    '                x(7) = newdir.Item("po_no").ToString
    '                x(8) = newdir.Item("rs_no").ToString
    '                x(9) = newdir.Item("rr_no").ToString
    '                x(10) = newdir.Item("amount").ToString


    '                Dim lvlList As New ListViewItem(x)
    '                lvl_summaryofpurchasedItems.Items.Add(lvlList)

    '            End While
    '        Else
    '            MessageBox.Show("Data doesn't exist...", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        End If
    '        newdir.Close()
    '    Catch ex As Exception
    '        MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        sql.connection.Close()
    '    End Try
    'End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

#Region "HOVER/GUI"
    Private Sub btnExit_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnExit.MouseDown
        btnExit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.MouseEnter
        btnExit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.MouseLeave
        btnExit.BackgroundImage = My.Resources.close_button
    End Sub

    Private Sub cmb_supplierName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_supplierName.GotFocus
        sender.backcolor = Color.Yellow
    End Sub

    Private Sub cmb_supplierName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_supplierName.Leave
        sender.backcolor = Color.White
    End Sub

    Private Sub btn_exit_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn_exit.MouseDown
        btn_exit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btn_exit_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exit.MouseEnter
        btn_exit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btn_exit_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exit.MouseLeave
        btn_exit.BackgroundImage = My.Resources.close_button
    End Sub
#End Region


    Private Sub cmb_supplierName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_supplierName.SelectedIndexChanged

        'If cmb_supplierName.Text = "" Then
        '    MessageBox.Show("sample")
        '    'load_purchased_items()
        'Else
        '    MessageBox.Show("sample2")
        '    'load_purchased_items()
        '    'panel_POdateSearch.Visible = True
        '    'cmb_supplierName.Enabled = False
        'End If



    End Sub

    Private Sub btn_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exit.Click
        'panel_POdateSearch.Visible = False
        'cmb_supplierName.Enabled = True
        'Loadsupplier()
        For Each ctr As Control In Me.Controls
            If ctr.Name = "panel_POdateSearch" Then
                ctr.Visible = False
            Else
                ctr.Enabled = True

            End If
        Next

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        'MsgBox(cmb_supplierName.Text)
        'Search_PurchasedItems(cmb_supplierName.Text, dtp_poDate_From.Value, dtp_poDate_To.Value)

        panel_RRdateSearch.Visible = True
        panel_RRdateSearch.Enabled = True
        panel_POdateSearch.Visible = False

        'If cmbSearchby.Text = "Search By All" Then
        '    view_summary_of_purchase_item(3)
        'ElseIf cmbSearchby.Text = "Search By Supplier"
        '    view_summary_of_purchase_item(2)
        'End If

        'btn_exit.PerformClick()

    End Sub
    Sub viewlist()
        Dim count As Integer = 1
        Dim a(20) As String
        For Each l As List(Of String) In itemlist

            a(0) = count
            a(1) = l(0)
            a(2) = l(1)
            a(3) = l(2)
            a(4) = l(3)
            a(5) = l(4)
            a(6) = l(5)
            a(7) = l(6)
            a(8) = l(7)
            a(9) = l(8)
            a(10) = l(9)
            a(11) = l(10)
            a(12) = l(11)
            a(13) = l(12)
            a(14) = l(13)
            a(15) = l(14)
            a(16) = l(15)
            a(17) = l(16)
            a(18) = l(17)
            a(19) = l(18)
            Dim lvl As New ListViewItem(a)
            lvl_summaryofpurchasedItems.Items.Add(lvl)
            count = count + 1
        Next
    End Sub
    Sub searchlist(ByVal txt As String)
        lvl_summaryofpurchasedItems.Items.Clear()
        Dim count As Integer = 1
        Dim a(20) As String
        If (txt = " ") Then
            For Each l As List(Of String) In itemlist
                'MsgBox(l(14))
                If l(14).ToUpper = "" Then
                    a(0) = count
                    a(1) = l(0)
                    a(2) = l(1)
                    a(3) = l(2)
                    a(4) = l(3)
                    a(5) = l(4)
                    a(6) = l(5)
                    a(7) = l(6)
                    a(8) = l(7)
                    a(9) = l(8)
                    a(10) = l(9)
                    a(11) = l(10)
                    a(12) = l(11)
                    a(13) = l(12)
                    a(14) = l(13)
                    a(15) = l(14)
                    Dim lvl As New ListViewItem(a)
                    lvl_summaryofpurchasedItems.Items.Add(lvl)
                    count = count + 1

                End If

            Next
        ElseIf (txt = "All") Then
            For Each l As List(Of String) In itemlist
                'MsgBox(l(14))

                a(0) = count
                a(1) = l(0)
                a(2) = l(1)
                a(3) = l(2)
                a(4) = l(3)
                a(5) = l(4)
                a(6) = l(5)
                a(7) = l(6)
                a(8) = l(7)
                a(9) = l(8)
                a(10) = l(9)
                a(11) = l(10)
                a(12) = l(11)
                a(13) = l(12)
                a(14) = l(13)
                a(15) = l(14)
                Dim lvl As New ListViewItem(a)
                lvl_summaryofpurchasedItems.Items.Add(lvl)
                count = count + 1

            Next
        Else
            For Each l As List(Of String) In itemlist
                'MsgBox(l(14))
                If l(14).ToUpper = txt.ToUpper Then
                    a(0) = count
                    a(1) = l(0)
                    a(2) = l(1)
                    a(3) = l(2)
                    a(4) = l(3)
                    a(5) = l(4)
                    a(6) = l(5)
                    a(7) = l(6)
                    a(8) = l(7)
                    a(9) = l(8)
                    a(10) = l(9)
                    a(11) = l(10)
                    a(12) = l(11)
                    a(13) = l(12)
                    a(14) = l(13)
                    a(15) = l(14)
                    Dim lvl As New ListViewItem(a)
                    lvl_summaryofpurchasedItems.Items.Add(lvl)
                    count = count + 1

                End If

            Next
        End If

    End Sub

    Public Sub view_summary_of_purchase_item(ByVal n)

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim a(20) As String
        Dim count As Integer = 0
        Dim i As Integer = 0
        lvl_summaryofpurchasedItems.Items.Clear()

        Try
            newSQ.connection.Open()

            newCMD = New SqlCommand("proc_summary_of_po", newSQ.connection)
            newCMD.CommandTimeout = 0
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.Add("@n", SqlDbType.NVarChar).Value = n
            newCMD.Parameters.Add("@datefrom", SqlDbType.Date).Value = dtp_poDate_From.Value
            newCMD.Parameters.Add("@dateto", SqlDbType.Date).Value = dtp_poDate_To.Value
            newCMD.Parameters.Add("@datefrom_received", SqlDbType.Date).Value = dtp_from_received.Value
            newCMD.Parameters.Add("@dateto_received", SqlDbType.Date).Value = dtp_to_received.Value
            newCMD.Parameters.Add("@supplier_name", SqlDbType.NVarChar).Value = cmb_supplierName.Text

            'newCMD.Parameters.AddWithValue("@n", n)
            'newCMD.Parameters.AddWithValue("@datefrom", Format(Date.Parse(dtp_poDate_From.ToString), "yyyy-MM-dd"))
            'newCMD.Parameters.AddWithValue("@dateto", Format(Date.Parse(dtp_poDate_To.ToString), "yyyy-MM-dd"))
            'newCMD.Parameters.AddWithValue("@datefrom_received", Format(Date.Parse(dtp_from_received.ToString), "yyyy-MM-dd"))
            'newCMD.Parameters.AddWithValue("@dateto_received", Format(Date.Parse(dtp_to_received.ToString), "yyyy-MM-dd"))
            'newCMD.Parameters.AddWithValue("@supplier_name", cmb_supplierName.Text)

            newDR = newCMD.ExecuteReader
            While newDR.Read

                Dim rs_id As Integer = newDR.Item("rs_id").ToString
                Dim type_of_purchasing As String = newDR.Item("type_of_purchasing").ToString
                'Dim sub_amount As Double = FReceivingReport.get_total_amount(newDR.Item("rr_item_id").ToString, 3, FReceivingReportList.get_po_det_id(rs_id))
                'If type_of_purchasing = "PURCHASE ORDER" Then
                '    a(6) = FSummarySupplyTransaction.get_po_details(newDR.Item("rs_id").ToString, 5)
                'ElseIf type_of_purchasing = "CASH" Then
                '    a(6) = FSummarySupplyTransaction.get_rr_details(newDR.Item("rs_id").ToString, 4)
                'End If

                'If a(6) = cmb_supplierName.Text Then
                'Else
                '    GoTo proceedhere
                'End If
                itemlist.Add(New List(Of String))
                itemlist(i).Add(Format(Date.Parse(newDR.Item("date_req").ToString), "MM/dd/yyyy"))
                itemlist(i).Add(Format(Date.Parse(newDR.Item("po_date").ToString), "MM/dd/yyyy"))
                itemlist(i).Add(Format(Date.Parse(newDR.Item("date_received").ToString), "MM/dd/yyyy"))
                itemlist(i).Add(FormatNumber(CDbl(newDR.Item("desired_qty").ToString), 0, , , TriState.True))
                itemlist(i).Add(newDR.Item("unit").ToString)
                itemlist(i).Add(newDR.Item("whItem").ToString)
                itemlist(i).Add(newDR.Item("whItemDesc").ToString)
                itemlist(i).Add(newDR.Item("Supplier_Name").ToString)
                itemlist(i).Add(newDR.Item("po_no").ToString)
                itemlist(i).Add(newDR.Item("rs_no").ToString)
                itemlist(i).Add(newDR.Item("rr_no").ToString)
                itemlist(i).Add(newDR.Item("invoice_no").ToString)
                itemlist(i).Add(FormatNumber(CDbl(newDR.Item("unit_price").ToString), 2, , , TriState.True))
                itemlist(i).Add(rs_id)
                itemlist(i).Add(FormatNumber(newDR.Item("TOTAL_PRICE").ToString, 2, , , TriState.True))

                If newDR.Item("type_name").ToString = "WAREHOUSE" Then
                    itemlist(i).Add(newDR.Item("CHARGE_TO_WAREHOUSE").ToString)
                ElseIf newDR.Item("type_name").ToString = "PROJECT" Then
                    itemlist(i).Add(newDR.Item("CHARGE_TO_PROJECT").ToString)
                ElseIf newDR.Item("type_name").ToString = "EQUIPMENT" Then
                    itemlist(i).Add(newDR.Item("CHARGE_TO_EQUIPMENT").ToString)
                ElseIf newDR.Item("type_name").ToString = "OTHERS" _
                     Or newDR.Item("type_name").ToString = "MAINOFFICE" _
                     Or newDR.Item("type_name").ToString = "PERSONAL" Then
                    itemlist(i).Add(newDR.Item("CHARGE_TO_PER_MAIN_OTHERS").ToString)
                Else
                    itemlist(i).Add("")
                End If

                itemlist(i).Add(newDR.Item("typeRequest").ToString)
                itemlist(i).Add(newDR.Item("type_of_purchasing").ToString)
                itemlist(i).Add(newDR.Item("remarks").ToString)

                Dim has_d As Boolean = False
                For Each item As String In ComboBox1.Items
                    If item.ToLower = newDR.Item("remarks").ToString.ToLower Then
                        has_d = True
                    End If
                Next
                If has_d = False Then
                    ComboBox1.Items.Add(newDR.Item("remarks").ToString)
                End If





                'count = count + 1
                'a(0) = count
                'a(1) = Format(Date.Parse(newDR.Item("date_req").ToString), "MM/dd/yyyy")
                'a(2) = Format(Date.Parse(newDR.Item("po_date").ToString), "MM/dd/yyyy")
                'a(3) = FormatNumber(CDbl(newDR.Item("desired_qty").ToString), 0, , , TriState.True)
                'a(4) = newDR.Item("unit").ToString
                'a(5) = newDR.Item("whItem").ToString
                'a(6) = newDR.Item("whItemDesc").ToString
                'a(7) = newDR.Item("Supplier_Name").ToString
                'a(8) = newDR.Item("po_no").ToString
                'a(9) = newDR.Item("rs_no").ToString
                'a(10) = newDR.Item("rr_no").ToString
                'a(11) = FormatNumber(CDbl(newDR.Item("unit_price").ToString), 2, , , TriState.True)  'IIf(newDR.Item("UNIT_AMOUNT").ToString = "", FormatNumber(0, 2, , , TriState.True), FormatNumber(CDbl(newDR.Item("UNIT_AMOUNT").ToString), 2, , TriState.True))
                'a(12) = rs_id
                ''a(12) = FormatNumber(sub_amount, 2, , , TriState.True)
                'a(13) = FormatNumber(newDR.Item("TOTAL_PRICE").ToString, 2, , , TriState.True)
                ''a(13) = FormatNumber(newDR.Item("desired_qty").ToString * newDR.Item("unit_price").ToString, 2, , , TriState.True)
                'a(14) = newDR.Item("type_of_purchasing").ToString
                'a(15) = newDR.Item("remarks").ToString

                'Dim lvl As New ListViewItem(a)
                'lvl_summaryofpurchasedItems.Items.Add(lvl)

                'proceedhere:
                i = i + 1
            End While
            newDR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        report_of_summary_of_purchasedItems()
    End Sub

    Public Sub report_of_summary_of_purchasedItems()

        Dim dt As New DataTable
        Dim i As Integer = 0

        With dt
            .Columns.Add("rs_date")
            .Columns.Add("po_date")
            .Columns.Add("quantity")
            .Columns.Add("unit")
            .Columns.Add("item_name")
            .Columns.Add("description")
            .Columns.Add("supplier_name")
            .Columns.Add("poNo")
            .Columns.Add("rsNo")
            .Columns.Add("rr")
            .Columns.Add("totalPrice")
            .Columns.Add("charge_to")
            .Columns.Add("typeRequest")
            .Columns.Add("unitprice")
            .Columns.Add("rr_date")
            .Columns.Add("invoiceNo")
        End With

        For i = 0 To lvl_summaryofpurchasedItems.Items.Count - 1
            dt.Rows.Add(dt.NewRow)

            dt.Rows(i).Item("rs_date") = lvl_summaryofpurchasedItems.Items(i).SubItems(1).Text
            dt.Rows(i).Item("po_date") = lvl_summaryofpurchasedItems.Items(i).SubItems(2).Text
            dt.Rows(i).Item("quantity") = lvl_summaryofpurchasedItems.Items(i).SubItems(4).Text
            dt.Rows(i).Item("unit") = lvl_summaryofpurchasedItems.Items(i).SubItems(5).Text
            dt.Rows(i).Item("item_name") = lvl_summaryofpurchasedItems.Items(i).SubItems(6).Text
            dt.Rows(i).Item("description") = lvl_summaryofpurchasedItems.Items(i).SubItems(7).Text
            dt.Rows(i).Item("supplier_name") = lvl_summaryofpurchasedItems.Items(i).SubItems(8).Text
            dt.Rows(i).Item("poNo") = lvl_summaryofpurchasedItems.Items(i).SubItems(9).Text
            dt.Rows(i).Item("rsNo") = lvl_summaryofpurchasedItems.Items(i).SubItems(10).Text
            dt.Rows(i).Item("rr") = lvl_summaryofpurchasedItems.Items(i).SubItems(11).Text
            dt.Rows(i).Item("unitprice") = lvl_summaryofpurchasedItems.Items(i).SubItems(13).Text
            dt.Rows(i).Item("totalPrice") = lvl_summaryofpurchasedItems.Items(i).SubItems(15).Text
            dt.Rows(i).Item("charge_to") = lvl_summaryofpurchasedItems.Items(i).SubItems(16).Text
            dt.Rows(i).Item("typeRequest") = lvl_summaryofpurchasedItems.Items(i).SubItems(17).Text
            dt.Rows(i).Item("rr_date") = lvl_summaryofpurchasedItems.Items(i).SubItems(3).Text
            dt.Rows(i).Item("invoiceNo") = lvl_summaryofpurchasedItems.Items(i).SubItems(12).Text

        Next

        Dim view As New DataView(dt)

        ReportSummaryPurchasedItem.ReportViewer1.LocalReport.DataSources.Item(0).Value = view
        ReportSummaryPurchasedItem.ShowDialog()
        ReportSummaryPurchasedItem.Dispose()

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub cmb_supplierName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_supplierName.TextChanged
        If cmb_supplierName.Text = "" Then
            load_purchased_items()
            Loadsupplier()
        Else
            'load_purchased_items()
            panel_POdateSearch.Visible = True
            cmb_supplierName.Enabled = False
        End If
    End Sub

    Private Sub cmbSearchby_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearchby.SelectedIndexChanged
        If cmbSearchby.Text = "Search By Supplier" Then
            btnSearchBy.Enabled = False
            cmb_supplierName.Enabled = True
        Else
            'btnSearchBy.Enabled = True
            panel_POdateSearch.Visible = True
            cmb_supplierName.Enabled = False

        End If

    End Sub

    Private Sub btnSearchBy_Click(sender As Object, e As EventArgs) Handles btnSearchBy.Click
        For Each ctr As Control In Me.Controls
            If ctr.Name = "panel_POdateSearch" Then
                ctr.Visible = True
            Else
                ctr.Enabled = False

            End If
        Next
    End Sub

    Private Sub btnProceed_Click(sender As Object, e As EventArgs) Handles btnProceed.Click

        If cmbSearchby.Text = "Search By All" Then
            view_summary_of_purchase_item(3)
        ElseIf cmbSearchby.Text = "Search By Supplier" Then
            view_summary_of_purchase_item(2)
        End If
        viewlist()

        btn1_exit.PerformClick()

    End Sub
    Private Sub btn1_exit_Click(sender As Object, e As EventArgs) Handles btn1_exit.Click
        panel_RRdateSearch.Visible = False
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        searchlist(ComboBox1.Text)
    End Sub
End Class