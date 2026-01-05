Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Threading
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.ComponentModel

Public Class FStockCard
    Dim SQLcon As New SQLcon
    Dim sqldr As SqlDataReader
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim stockcard_bal As String
    Dim IsFormBeingDragged As Boolean
    Dim drag As Boolean
    Dim MouseDownX As Integer
    Dim MouseDownY As Integer
    Public txtname As String
    Public stock_card_balance As Double
    Public get_wh_id As Integer
    Dim mousex As Integer
    Dim mousey As Integer
    Dim thread As System.Threading.Thread

    Private cNewDr As New class_new_dr
    Private cnewDr2 As New class_new_dr '<-- this class is for returning previous balance from dr

    Private cNewWs As New class_ws
    Private cNewWs2 As New class_ws '<-- this class is for returning previous balance from withdrawal without dr
    Private cListOfThread As New List(Of Threading.Thread)
    Public cWh_id As Integer
    Private cPreviousbalance As Double

    Private NewStockCard As New class_stock_card_for_hauling
    Private NewStockCard1 As New class_agg_remaining_balance 'GET AGGREGATES DATA
    Private NewStockCard2 As New class_agg_remaining_balance
    Private NewStockCard3 As New class_agg_remaining_balance 'PREVIOUS BALANCE kadtong sa excel pa
    Private NewStockCard4 As New class_agg_remaining_balance 'PREVIOUS BALANCE
    Private NewStockCard5 As New class_agg_remaining_balance 'WAREHOUSE LOCATION
    Private wh_loc As New class_agg_remaining_balance.wh_loc

    Dim newList As New class_agg_remaining_balance 'FOR ARRANGE BALANCE

    Public cDateFrom, cDateTo As DateTime
    Private cBalance, cprevBalance As Double

    Private trd As Threading.Thread
    Private trd_checker, trd_checker2, trd_checker3, trd_checker4 As Threading.Thread
    Private trig As Boolean = False
    Private trig2 As Boolean = False

    Private r1, r2, r3, r4, r5 As Boolean
    Public fl As New FListOfItems


    'BACKGROUNDWORKER
    Private bw_warehouse_loc As BackgroundWorker

    Private customMsg As New customMessageBox
    Private cCustomDatagrid As New CustomGridview
    Structure dr_list

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

    End Structure
    Structure stock_card_qty_list
        Dim dDate As DateTime
        Dim dQty As Double
        Dim inout As String
        Dim dr_date As DateTime

    End Structure
    Public cNewListOfDr As New List(Of dr_list)
    Private cNewListOfDrQty As New List(Of stock_card_qty_list)

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Const CS_DROPSHADOW As Integer = &H20000
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_DROPSHADOW
            Return cp
        End Get
    End Property

    Private Sub pboxHeader_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
        End If
    End Sub

    Private Sub pboxHeader_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If IsFormBeingDragged Then
            Dim temp As Point = New Point()

            temp.X = Me.Location.X + (e.X - MouseDownX)
            temp.Y = Me.Location.Y + (e.Y - MouseDownY)
            Me.Location = temp
            temp = Nothing
        End If
    End Sub

    Private Sub pboxHeader_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
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

    Private Sub FStockCard_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    get_stock_card(dtgStockCard, 4, txtItemDesc.Text)
        '    get_balance()
        '    beginning_bal()
        'End If

        If e.KeyCode = Keys.Escape Then
            Panel5.Visible = False
        End If
    End Sub

    Private Sub FStockCard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' load_all_stock_card(dtgStockCard, 3, "")
        load_warehouse()
        Panel5.Visible = False
        FMaterials_ToolsTurnOverTextFields.get_whItem(0, cmbItemName)

        Me.KeyPreview = True
        Me.BackColor = Color.Black

    End Sub
    Sub load_warehouse()
        cmbWareHouse.Items.Clear()
        Try
            SQLcon.connection.Open()
            cmd = New SqlCommand("select DISTINCT wh_area from dbwh_area ORDER BY wh_area ASC", SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.Text
            sqldr = cmd.ExecuteReader
            While sqldr.Read
                cmbWareHouse.Items.Add(sqldr("wh_area").ToString)
            End While

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub load_all_stock_card(ByVal obj As Object, ByVal field As Integer, ByVal search As String)

        dtgStockCard.Rows.Clear()
        lblitem_name.ResetText()
        lblReOrderPoint.ResetText()

        Try
            SQLcon.connection.Open()

            cmd = New SqlCommand("proc_execute_tempstockcard", SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@field", 3)
            cmd.Parameters.AddWithValue("@itemDesc", search)
            sqldr = cmd.ExecuteReader

            While sqldr.Read

                Dim a(20) As String

                lblitem_name.Text = get_warehouse_details(sqldr.Item("wh_id").ToString, 2)
                lblReOrderPoint.Text = get_warehouse_details(sqldr.Item("wh_id").ToString, 0)
                lbl_location.Text = get_warehouse_details(sqldr.Item("wh_id").ToString, 1)

                a(0) = sqldr.Item("rs_id").ToString()
                a(1) = Format(Date.Parse(sqldr.Item("date_req").ToString), "MMMM dd, yyyy")
                a(2) = sqldr.Item("rs_no").ToString()
                a(3) = get_rr_no_receiving_info(sqldr.Item("rs_no").ToString, "invoice")
                a(4) = get_rr_no_receiving_info(sqldr.Item("rs_no").ToString, "rr_no")
                a(5) = get_ws_no_withdrawal_info(sqldr.Item("rs_no").ToString)

                If sqldr.Item("IN_OUT").ToString = "IN" Then
                    a(6) = get_supplier_name_IN(sqldr.Item("rs_no").ToString, 0)
                    a(7) = sqldr.Item("qty").ToString()
                ElseIf sqldr.Item("IN_OUT").ToString = "OUT" And sqldr.Item("typeRequest").ToString = "SUPPLY" Then
                    a(6) = get_supplier_from_charge_to(sqldr.Item("charge_to").ToString)
                    a(8) = sqldr.Item("qty").ToString()
                ElseIf sqldr.Item("IN_OUT").ToString = "OUT" And sqldr.Item("typeRequest").ToString = "EQUIPMENT" Then
                    a(6) = get_supplier_equipment_OUT(sqldr.Item("charge_to").ToString)
                    a(8) = sqldr.Item("qty").ToString()
                End If

                stockcard_bal = get_balance_stockcard_maintenance(sqldr.Item("wh_id").ToString)
                a(9) = get_balance() + CInt(stockcard_bal)

                dtgStockCard.Rows.Add(a)

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub

    Public Sub get_stock_card(ByVal obj As Object, ByVal field As Integer, ByVal whID As String)

        dtgStockCard.Rows.Clear()
        lblitem_name.ResetText()
        lblReOrderPoint.ResetText()
        lbl_location.ResetText()

        Try
            SQLcon.connection.Open()

            cmd = New SqlCommand("proc_stock_card_report", SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@field", 6)
            cmd.Parameters.AddWithValue("@whID", whID)
            'cmd.Parameters.AddWithValue("@rsNo", rs_NO)
            sqldr = cmd.ExecuteReader

            While sqldr.Read

                Dim a(20) As String

                lblitem_name.Text = get_warehouse_details(sqldr.Item("wh_id").ToString, 2)
                lblReOrderPoint.Text = get_warehouse_details(sqldr.Item("wh_id").ToString, 0)
                lbl_location.Text = get_warehouse_details(sqldr.Item("wh_id").ToString, 1)

                a(0) = sqldr.Item("rs_id").ToString()
                a(1) = Format(Date.Parse(sqldr.Item("date_req").ToString), "MMMM dd, yyywy")
                a(2) = sqldr.Item("rs_no").ToString()
                a(3) = get_rr_no_receiving_info(sqldr.Item("rs_no").ToString, "invoice")
                a(4) = get_rr_no_receiving_info(sqldr.Item("rs_no").ToString, "rr_no")
                a(5) = get_ws_no_withdrawal_info(sqldr.Item("rs_no").ToString)

                If check_status_purchased(sqldr.Item("rs_no").ToString) = "RECEIVED" And sqldr.Item("IN_OUT").ToString = "IN" _
                And sqldr.Item("type_of_purchasing").ToString = "PURCHASE ORDER" Then
                    a(6) = get_supplier_name_IN(sqldr.Item("rs_no").ToString, 0)
                    a(7) = sqldr.Item("qty").ToString()
                ElseIf sqldr.Item("IN_OUT").ToString = "OUT" And sqldr.Item("process").ToString = "WAREHOUSE" Then
                    a(6) = get_supplier_from_warehouse_area(sqldr.Item("charge_to").ToString)
                    a(8) = sqldr.Item("qty").ToString()
                ElseIf sqldr.Item("IN_OUT").ToString = "IN" And sqldr.Item("process").ToString = "ADFIL" Then
                    a(6) = get_supplier_from_charge_to(sqldr.Item("charge_to").ToString)
                    a(7) = sqldr.Item("qty").ToString()
                ElseIf sqldr.Item("IN_OUT").ToString = "OUT" And sqldr.Item("process").ToString = "ADFIL" Or sqldr.Item("process").ToString = "PERSONAL" Then
                    a(6) = get_supplier_from_charge_to(sqldr.Item("charge_to").ToString)
                    a(8) = sqldr.Item("qty").ToString()
                ElseIf sqldr.Item("IN_OUT").ToString = "IN" And sqldr.Item("process").ToString = "ADFIL" Then
                    a(6) = get_supplier_from_charge_to(sqldr.Item("charge_to").ToString)
                    a(7) = sqldr.Item("qty").ToString()
                ElseIf sqldr.Item("IN_OUT").ToString = "IN" And sqldr.Item("process").ToString = "PROJECT" Then
                    a(6) = get_project_charge_to(sqldr.Item("charge_to").ToString)
                    a(8) = sqldr.Item("qty").ToString()
                ElseIf sqldr.Item("IN_OUT").ToString = "OUT" And sqldr.Item("process").ToString = "PROJECT" Then
                    a(6) = get_project_charge_to(sqldr.Item("charge_to").ToString)
                    a(8) = sqldr.Item("qty").ToString()
                    ''ElseIf sqldr.Item("IN_OUT").ToString = "OUT" And sqldr.Item("process").ToString = "PROJECT" Then
                    ''    a(6) = get_project_charge_to(sqldr.Item("charge_to").ToString)
                    ''    a(8) = sqldr.Item("qty").ToString()
                    ''ElseIf sqldr.Item("IN_OUT").ToString = "OUT" And sqldr.Item("process").ToString = "EQUIPMENT" Then
                    ''    a(6) = get_supplier_equipment_OUT(sqldr.Item("charge_to").ToString)
                    ''    a(8) = sqldr.Item("qty").ToString()
                    ''ElseIf sqldr.Item("process").ToString = "WAREHOUSE" Then
                    ''    a(6) = get_supplier_from_warehouse_area(sqldr.Item("charge_to").ToString)
                    ''    a(8) = sqldr.Item("qty").ToString()
                ElseIf sqldr.Item("type_of_purchasing").ToString = "WITHDRAWAL" And check_status_withdraw(sqldr.Item("rs_no").ToString) = "WITHDRAWN" _
                And sqldr.Item("IN_OUT").ToString = "OUT" Then
                    a(6) = get_supplier_from_charge_to(sqldr.Item("charge_to").ToString)
                    a(8) = sqldr.Item("qty").ToString()
                Else


                End If


                stockcard_bal = get_balance_stockcard_maintenance(sqldr.Item("wh_id").ToString)
                a(9) = get_balance() + CInt(stockcard_bal)

                dtgStockCard.Rows.Add(a)

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub

    Public Sub get_stock_card_wh(ByVal obj As Object, ByVal field As Integer, ByVal whID As String)

        dtgStockCard.Rows.Clear()
        lblitem_name.ResetText()
        lblReOrderPoint.ResetText()
        lbl_location.ResetText()

        Try
            SQLcon.connection.Open()

            cmd = New SqlCommand("proc_stock_card_report", SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@field", 5)
            cmd.Parameters.AddWithValue("@whID", whID)
            sqldr = cmd.ExecuteReader

            While sqldr.Read

                Dim a(20) As String

                lblitem_name.Text = get_warehouse_details(sqldr.Item("wh_id").ToString, 2)
                lblReOrderPoint.Text = get_warehouse_details(sqldr.Item("wh_id").ToString, 0)
                lbl_location.Text = get_warehouse_details(sqldr.Item("wh_id").ToString, 1)

                a(0) = sqldr.Item("psc_id").ToString()
                a(2) = Format(Date.Parse(sqldr.Item("date_previous").ToString), "MMMM dd, yyyy")
                a(3) = sqldr.Item("rs_no").ToString()
                a(4) = sqldr.Item("invoice_no").ToString()
                a(5) = sqldr.Item("receiving_no").ToString()
                a(6) = sqldr.Item("ws_no").ToString()
                a(7) = charge_to_or_supplier(sqldr.Item("supplier_reciepient").ToString, sqldr.Item("type_of_charge").ToString)

                If sqldr.Item("status").ToString = "IN" Then
                    a(8) = sqldr.Item("in_out").ToString()
                    a(10) = sqldr.Item("balance").ToString()
                    a(11) = "RECEIVED"

                ElseIf sqldr.Item("status").ToString = "OUT" Then
                    a(9) = sqldr.Item("in_out").ToString()
                    a(10) = sqldr.Item("balance").ToString()
                    a(11) = "WITHDRAWN"

                End If

                dtgStockCard.Rows.Add(a)

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub

    Public Function charge_to_or_supplier(ByVal id As String, ByVal type_of_charge_or_supplier As String) As String
        Try
            If type_of_charge_or_supplier = "SUPPLIER" Then
                publicquery_Psc = "SELECT Supplier_Name FROM dbSupplier WHERE Supplier_Id = " & id
                charge_to_or_supplier = get_specific_column_value(publicquery_Psc, 0)

            ElseIf type_of_charge_or_supplier = "PERSONAL" Then
                publicquery_Psc = "SELECT charge_to FROM dbCharge_to WHERE charge_to_id = " & id
                charge_to_or_supplier = get_specific_column_value(publicquery_Psc, 0)

            ElseIf type_of_charge_or_supplier = "WAREHOUSE" Then
                publicquery_Psc = "SELECT wh_area FROM dbwh_area WHERE wh_area_id = " & id
                charge_to_or_supplier = get_specific_column_value(publicquery_Psc, 0)

            ElseIf type_of_charge_or_supplier = "ADMIN AND MISC." Then
                publicquery_Psc = "SELECT charge_to FROM dbCharge_to WHERE charge_to_id = " & id
                charge_to_or_supplier = get_specific_column_value(publicquery_Psc, 0)

            ElseIf type_of_charge_or_supplier = "EQUIPMENT" Then

                Dim sqlcon As New SQLcon

                'sqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
                'sqlcon.sql_connect()
                Dim newdr As SqlDataReader
                Dim newcmd As SqlCommand

                sqlcon.connection1.Open()

                publicquery_Psc = "SELECT plate_no FROM dbequipment_list WHERE equipListID = " & id
                newcmd = New SqlCommand(publicquery_Psc, sqlcon.connection1)
                newdr = newcmd.ExecuteReader

                While newdr.Read
                    charge_to_or_supplier = newdr.Item("plate_no").ToString
                End While

                newdr.Close()
                sqlcon.connection1.Close()

            ElseIf type_of_charge_or_supplier = "PROJECT" Then

                Dim sqlcon As New SQLcon

                'sqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
                'sqlcon.sql_connect()
                Dim newdr As SqlDataReader
                Dim newcmd As SqlCommand

                sqlcon.connection1.Open()

                publicquery_Psc = "SELECT project_desc FROM dbprojectdesc WHERE proj_id = " & id
                newcmd = New SqlCommand(publicquery_Psc, sqlcon.connection1)
                newdr = newcmd.ExecuteReader

                While newdr.Read
                    charge_to_or_supplier = newdr.Item("project_desc").ToString
                End While

                newdr.Close()
                sqlcon.connection1.Close()

            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function


    Public Function check_status_purchased(ByVal rs_No As Integer)
        Dim newsqlcon As New SQLcon
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand

        newsqlcon.connection.Open()

        publicquery = "SELECT received_status FROM dbreceiving_info WHERE rs_no = " & rs_No
        newcmd = New SqlCommand(publicquery, newsqlcon.connection)
        newdr = newcmd.ExecuteReader

        While newdr.Read
            check_status_purchased = newdr.Item("received_status").ToString
        End While

        newdr.Close()
        newsqlcon.connection.Close()
    End Function

    Public Function check_status_withdraw(ByVal rs_no As Integer)
        Dim newsqlcon As New SQLcon
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand

        newsqlcon.connection.Open()

        publicquery = "SELECT withdraw_status FROM dbwithdrawal_info WHERE rs_no = " & rs_no
        newcmd = New SqlCommand(publicquery, newsqlcon.connection)
        newdr = newcmd.ExecuteReader

        While newdr.Read
            check_status_withdraw = newdr.Item("withdraw_status").ToString
        End While

        newdr.Close()
        newsqlcon.connection.Close()
    End Function

    Public Function get_balance_stockcard_maintenance(ByVal whID As Integer) As Double
        Dim newsqlcon As New SQLcon
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand

        newsqlcon.connection.Open()

        publicquery = "SELECT balance FROM dbPrevious_stock_card WHERE wh_id = " & whID
        newcmd = New SqlCommand(publicquery, newsqlcon.connection)
        newdr = newcmd.ExecuteReader

        While newdr.Read
            get_balance_stockcard_maintenance = CDbl(newdr.Item("balance").ToString)
        End While

        newdr.Close()
        newsqlcon.connection.Close()
    End Function

    Public Function get_ws_no_withdrawal_info(ByVal rsNo As Integer)
        Dim newsqlcon As New SQLcon
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand
        Try
            newsqlcon.connection.Open()
            publicquery = "SELECT * FROM dbwithdrawal_info WHERE rs_no = " & rsNo
            newcmd = New SqlCommand(publicquery, newsqlcon.connection)
            newdr = newcmd.ExecuteReader
            While newdr.Read
                get_ws_no_withdrawal_info = newdr.Item("ws_no").ToString
            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
        End Try
    End Function

    Public Function get_rr_no_receiving_info(ByVal value As Integer, ByVal col_name As String)
        Dim newsqlcon As New SQLcon
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand

        Try
            newsqlcon.connection.Open()

            publicquery = "SELECT * FROM dbreceiving_info WHERE rs_no = " & value
            newcmd = New SqlCommand(publicquery, newsqlcon.connection)
            newdr = newcmd.ExecuteReader

            While newdr.Read
                If col_name = "rr_no" Then
                    get_rr_no_receiving_info = newdr.Item("rr_no").ToString
                ElseIf col_name = "invoice" Then
                    get_rr_no_receiving_info = newdr.Item("invoice_no").ToString
                End If
            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
        End Try
    End Function

    Public Function get_warehouse_details(ByVal whID As Integer, ByVal n As Integer)
        Dim newsqlcon As New SQLcon
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand
        Try
            newsqlcon.connection.Open()
            If n = 0 Then
                publicquery = "SELECT whReorderPoint FROM dbwarehouse_items WHERE wh_id = " & whID
            ElseIf n = 1 Then
                publicquery = "SELECT whArea FROM dbwarehouse_items WHERE wh_id = " & whID
            ElseIf n = 2 Then
                publicquery = "SELECT whItemDesc FROM dbwarehouse_items WHERE wh_id = " & whID
            End If
            newcmd = New SqlCommand(publicquery, newsqlcon.connection)
            newdr = newcmd.ExecuteReader
            While newdr.Read
                If n = 0 Then
                    get_warehouse_details = newdr.Item("whReorderPoint").ToString
                ElseIf n = 1 Then
                    get_warehouse_details = newdr.Item("whArea").ToString
                ElseIf n = 2 Then
                    get_warehouse_details = newdr.Item("whItemDesc").ToString
                End If
            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
        End Try
    End Function

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click

        view_report()

    End Sub

    Public Sub view_report()
        Dim dt As New DataTable

        With dt
            '.Columns.Add("rs_id")
            .Columns.Add("date_req")
            .Columns.Add("rs_no")
            .Columns.Add("invoice_no")
            .Columns.Add("rr_no")
            .Columns.Add("ws_no")
            .Columns.Add("supplier")
            .Columns.Add("qty_IN")
            .Columns.Add("qty_OUT")
            .Columns.Add("balance")
            .Columns.Add("remarks")
        End With


        For i As Integer = 0 To dtgStockCard.Rows.Count - 1
            'If CBool(DirectCast(dtgStockCard.Rows(i).Cells("Column12"), DataGridViewCheckBoxCell).Value) = True Then
            '    dt.Rows.Add(dtgStockCard.Rows(i).Cells(2).Value, dtgStockCard.Rows(i).Cells(3).Value,
            '                dtgStockCard.Rows(i).Cells(4).Value, dtgStockCard.Rows(i).Cells(5).Value,
            '                dtgStockCard.Rows(i).Cells(6).Value, dtgStockCard.Rows(i).Cells(7).Value,
            '                dtgStockCard.Rows(i).Cells(8).Value, dtgStockCard.Rows(i).Cells(9).Value,
            '                dtgStockCard.Rows(i).Cells(10).Value, dtgStockCard.Rows(i).Cells(11).Value
            '                )
            'End If
            If dtgStockCard.Rows(i).Cells(1).Value = True Then
                dt.Rows.Add(dtgStockCard.Rows(i).Cells(2).Value, dtgStockCard.Rows(i).Cells(3).Value,
                            dtgStockCard.Rows(i).Cells(4).Value, dtgStockCard.Rows(i).Cells(5).Value,
                            dtgStockCard.Rows(i).Cells(6).Value, dtgStockCard.Rows(i).Cells(7).Value,
                            dtgStockCard.Rows(i).Cells(8).Value, dtgStockCard.Rows(i).Cells(9).Value,
                            dtgStockCard.Rows(i).Cells(10).Value, dtgStockCard.Rows(i).Cells(11).Value
                              )

            End If
        Next


        Dim view As New DataView(dt)


        StockCardRepotForm.ReportViewer1.LocalReport.DataSources.Item(0).Value = view
        StockCardRepotForm.ShowDialog()
        StockCardRepotForm.Dispose()

    End Sub

    Private Sub txtItemDesc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemDesc.GotFocus
        If txtItemDesc.Focused Then
            txtname = txtItemDesc.Name
            txtItemDesc.SelectAll()
        End If
    End Sub

    Private Sub txtItemDesc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItemDesc.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
            If lbox.Visible = True Then
                If lbox.Items.Count > 0 Then
                    lbox.Focus()
                    lbox.SelectedIndex = 0
                End If
            Else

            End If
        End If
    End Sub

    Private Sub txtItemDesc_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtItemDesc.MouseClick
        txtItemDesc.Text = ""
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemDesc.TextChanged
        lbox.Size = New Size(203, 80)
        lbox.Location = New Point(txtItemDesc.Location.X, txtItemDesc.Location.Y + 22)
        If txtItemDesc.Focus = True Then
            lbox.Visible = True
            list_box(1)
        End If

    End Sub

    Public Sub get_stock_card_bal()

        If check_wh_id() > 0 Then
            If if_request_exist(wh_id) > 0 Then
                get_stock_card(dtgStockCard, 2, txtItemDesc.Text)
                get_balance()
                beginning_bal()
            End If
        End If

    End Sub

    Public Function check_wh_id() As Integer
        Try
            SQLcon.connection.Open()
            publicquery = "SELECT * FROM dbwarehouse_items WHERE whItem = '" & cmbItemName.Text & "' AND whItemDesc = '" & cmbItem_desc.Text & "'"
            cmd = New SqlCommand(publicquery, SQLcon.connection)
            sqldr = cmd.ExecuteReader
            While sqldr.Read
                'check_wh_id += 1
                check_wh_id = sqldr.Item("wh_id").ToString
            End While
            sqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()

        End Try
    End Function

    Public Function if_request_exist(ByVal whID As String) As Integer
        Try
            SQLcon.connection.Open()
            publicquery = "SELECT * FROM dbrequisition_slip WHERE wh_id = '" & whID & "' "
            cmd = New SqlCommand(publicquery, SQLcon.connection)
            sqldr = cmd.ExecuteReader
            While sqldr.Read
                'rs_NO = sqldr.Item("rs_no").ToString
                if_request_exist += 1
            End While
            sqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()

        End Try
    End Function

    Public Function if_prev_stock_card_exist(ByVal wh_id As String) As Integer
        Try
            SQLcon.connection.Open()
            publicquery = "SELECT * FROM dbPrevious_stock_card WHERE wh_id = '" & wh_id & "'"
            cmd = New SqlCommand(publicquery, SQLcon.connection)
            sqldr = cmd.ExecuteReader
            While sqldr.Read
                if_prev_stock_card_exist += 1
                ''if_request_exist = sqldr.Item("item_desc").ToString
                'lblwh_id.Text = sqldr.Item("wh_id").ToString
            End While
            sqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()

        End Try
    End Function

    Public Function get_balance()
        Dim bal As Double = 0
        Dim tempbal As Double = 0
        Dim item_in As Double = 0
        Dim item_out As Double = 0

        For Each row1 As DataGridViewRow In dtgStockCard.Rows
            item_in = row1.Cells(8).Value
            item_out = row1.Cells(9).Value
            tempbal += CDbl(item_in - item_out)
            For Each row2 As DataGridViewRow In dtgStockCard.Rows
                bal = CDbl(tempbal) + CDbl(stockcard_bal)
                row1.Cells(10).Value = bal
            Next
        Next


    End Function

    Public Function beginning_bal()
        Dim last_val As String
        For Each row1 As DataGridViewRow In dtgStockCard.Rows
            last_val = row1.Cells(10).Value
            lblBalance.Text = CDbl(last_val)
        Next
    End Function

    Public Function get_supplier_name_IN(ByVal rsNo As Integer, ByVal n As Integer)
        Dim newsqlcon As New SQLcon
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand
        Try
            newsqlcon.connection.Open()
            If n = 0 Then
                publicquery = "SELECT * FROM dbreceiving_info WHERE rs_no = " & rsNo
            ElseIf n = 1 Then
                publicquery = "SELECT * FROM dbSupplier WHERE Supplier_Id = " & rsNo
            End If

            newcmd = New SqlCommand(publicquery, newsqlcon.connection)
            newdr = newcmd.ExecuteReader
            While newdr.Read
                If n = 0 Then
                    get_supplier_name_IN = newdr.Item("supplier").ToString
                ElseIf n = 1 Then
                    get_supplier_name_IN = newdr.Item("Supplier_Name").ToString
                End If

            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
        End Try
    End Function

    Public Function get_supplier_equipment_OUT(ByVal charge_to_id As Integer)
        Dim newsqlcon As New SQLcon

        'newsqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
        'newsqlcon.sql_connect()
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand

        newsqlcon.connection1.Open()

        publicquery = "SELECT plate_no FROM dbequipment_list WHERE equipListID = " & charge_to_id
        newcmd = New SqlCommand(publicquery, newsqlcon.connection1)
        newdr = newcmd.ExecuteReader

        While newdr.Read
            get_supplier_equipment_OUT = newdr.Item("plate_no").ToString
        End While

        newdr.Close()
        newsqlcon.connection1.Close()
    End Function

    Public Function get_supplier_from_charge_to(ByVal charge_id As Integer)
        Dim newsqlcon As New SQLcon
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand

        newsqlcon.connection.Open()

        publicquery = "SELECT charge_to FROM dbCharge_to WHERE charge_to_id = " & charge_id
        newcmd = New SqlCommand(publicquery, newsqlcon.connection)
        newdr = newcmd.ExecuteReader

        While newdr.Read
            get_supplier_from_charge_to = newdr.Item("charge_to").ToString
        End While

        newdr.Close()
        newsqlcon.connection.Close()
    End Function

    Public Function get_supplier_from_warehouse_area(ByVal charge_to_id As Integer)
        Dim newsqlcon As New SQLcon
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand

        newsqlcon.connection.Open()

        publicquery = "SELECT wh_area FROM dbwh_area WHERE wh_area_id = " & charge_to_id
        newcmd = New SqlCommand(publicquery, newsqlcon.connection)
        newdr = newcmd.ExecuteReader

        While newdr.Read
            get_supplier_from_warehouse_area = newdr.Item("wh_area").ToString
        End While

        newdr.Close()
        newsqlcon.connection.Close()
    End Function



    Public Function get_project_charge_to(ByVal charge_to_id As Integer)
        Dim newsqlcon As New SQLcon

        'newsqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
        'newsqlcon.sql_connect()
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand

        newsqlcon.connection1.Open()

        publicquery = "SELECT project_desc FROM dbprojectdesc WHERE proj_id = " & charge_to_id
        newcmd = New SqlCommand(publicquery, newsqlcon.connection1)
        newdr = newcmd.ExecuteReader

        While newdr.Read
            get_project_charge_to = newdr.Item("project_desc").ToString
        End While

        newdr.Close()
        newsqlcon.connection1.Close()
    End Function

    Private Sub btnExit_Click_(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        dtgStockCard.Rows.Clear()
        Me.Dispose()
    End Sub

    Private Sub txtItemName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemName.GotFocus
        If txtItemName.Focused Then
            txtname = txtItemName.Name
            txtItemName.SelectAll()
        End If
    End Sub

    Private Sub txtItemName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItemName.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
            If lbox.Visible = True Then
                If lbox.Items.Count > 0 Then
                    lbox.Focus()
                    lbox.SelectedIndex = 0
                End If
            Else

            End If
        End If
    End Sub

    Private Sub txtItemName_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtItemName.MouseClick
        txtItemName.Text = ""
    End Sub

    Private Sub txtItemName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemName.TextChanged
        lbox.Size = New Size(152, 80)
        lbox.Location = New Point(txtItemName.Location.X, txtItemName.Location.Y + 22)
        If txtItemName.Focus = True Then
            lbox.Visible = True
            list_box(0)
        End If
    End Sub

    Private Function list_box(ByVal n As Integer)
        lbox.Items.Clear()
        Dim counter As Integer = 0
        Try
            SQLcon.connection.Open()
            Dim dr As SqlDataReader
            Dim cmd As New SqlCommand("proc_wh_items_crud", SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            If n = 0 Then
                cmd.Parameters.AddWithValue("@Item", txtItemName.Text)
                cmd.Parameters.AddWithValue("@crud", "3")
            ElseIf n = 1 Then
                cmd.Parameters.AddWithValue("@ItemDesc", txtItemName.Text)
                cmd.Parameters.AddWithValue("@crud", "4")
            End If
            dr = cmd.ExecuteReader
            If dr.HasRows = False Then
                lbox.Visible = False
            Else
                While dr.Read
                    If n = 0 Then
                        Dim whItem As String = dr.Item("whitem").ToString
                        lbox.Items.Add(whItem)
                        counter += 1
                    ElseIf n = 1 Then
                        Dim whItemDesc As String = dr.Item("whItemDesc").ToString
                        lbox.Items.Add(whItemDesc)
                        counter += 1
                    End If

                End While
                If counter = 0 Then
                    lbox.Visible = False
                Else
                    lbox.Visible = True
                End If

                dr.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Function

    Private Sub lbox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbox.DoubleClick
        If lbox.SelectedItems.Count > 0 Then
            For Each ctr As Control In Me.Controls
                If ctr.Name = txtname Then
                    ctr.Text = lbox.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next
            lbox.Visible = False
        Else
            MessageBox.Show("Pls select data", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub lbox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lbox.KeyDown
        If e.KeyCode = Keys.Enter Then
            For Each ctr As Control In Me.Controls
                If ctr.Name = txtname Then
                    ctr.Text = lbox.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next
            lbox.Visible = False
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If cmbOptions.Text = "Search by StockCard" Then

            Panel5.Visible = True
            cmbforClassification.SelectedIndex = 1
            cmbforClassification.Enabled = True
            cmbclassification.Enabled = True
            cmbforClassification.Focus()
            load_clasifications(cmbclassification)


        Else
            Panel5.Visible = True
            cmbforClassification.SelectedIndex = 1
            'cmbforClassification.Enabled = False
            'cmbclassification.Enabled = False
            cmbforClassification.Focus()
            load_clasifications(cmbclassification)

        End If


        'get_wh_id = get_id("dbwarehouse_items", "whItem^whItemDesc", cmbItemName.Text & "^" & cmbItem_desc.Text, 2)

        'Dim if_wh_id_exist As Integer = check_if_exist("dbrequisition_slip", "wh_id", CInt(get_wh_id), 1)

        'If if_wh_id_exist > 0 Then
        '    view_stock_card()
        'Else
        '    get_item_previous_stockCard(get_wh_id)
        'End If

        'preview_stock_card()
        'view_stock_card()

    End Sub
    Public Sub load_clasifications(cmb As ComboBox)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        cmb.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 23)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                cmb.Items.Add(newDR.Item("wh_classification").ToString)
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Public Function get_rs_id(ByVal id As Integer) As Integer

        Dim sqlcon1 As New SQLcon
        Dim dr1 As SqlDataReader
        Dim cmd1 As SqlCommand

        Try
            sqlcon1.connection.Open()
            Dim query As String = "SELECT rs_id FROM dbrequisition_slip WHERE wh_id = " & id
            cmd1 = New SqlCommand(query, sqlcon1.connection)
            dr1 = cmd1.ExecuteReader

            While dr1.Read

                dr1.GetValue(0)

                Dim if_rs_id_exist1 As Integer = check_if_exist("dbwithdrawn_items", "rs_id", CInt(dr1.GetValue(0)), 1)
                Dim if_rs_id_exist2 As Integer = check_if_exist("dbPO_details", "rs_id", CInt(dr1.GetValue(0)), 1)

                If if_rs_id_exist1 > 0 Or if_rs_id_exist2 > 0 Then
                    view_stock_card()
                Else
                    get_item_previous_stockCard(get_wh_id)
                End If

            End While
            dr1.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon1.connection.Close()
        End Try

    End Function
    Public Sub view_stock_card()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim get_wh_id As Integer
        Dim a(20) As String
        Dim wh_item_balance As Double

        dtgStockCard.Rows.Clear()

        get_wh_id = get_id("dbwarehouse_items", "whItem^whItemDesc", cmbItemName.Text & "^" & cmbItem_desc.Text, 2)
        wh_item_balance = get_balance_stockcard_maintenance(get_wh_id)

        stock_card_balance = 0
        stock_card_balance += wh_item_balance

        lblitem_name.Text = cmbItemName.Text & " (" & cmbItem_desc.Text & ")"
        lbl_location.Text = ""
        lblReOrderPoint.Text = ""

        lblBalance.Text = stock_card_balance
        'lblBalance.Text = wh_item_balance
        'lblBalance.Text = ""

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 6)
            newCMD.Parameters.AddWithValue("@wh_id", get_wh_id)
            newCMD.Parameters.AddWithValue("@dateFrom", Date.Parse(dtpFrom.Text))
            newCMD.Parameters.AddWithValue("@dateTo", Date.Parse(dtpTo.Text))

            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim inout As String = newDR.Item("IN_OUT").ToString
                Dim date_req As DateTime = Date.Parse(newDR.Item("date_req").ToString)
                Dim rs_no As String = newDR.Item("rs_no").ToString
                Dim po_no As String = newDR.Item("po_no").ToString
                Dim po_det_id As Integer = newDR.Item("po_det_id").ToString
                Dim type_of_purchasing As String = newDR.Item("type_of_purchasing").ToString

                lblitem_name.Text = newDR.Item("ITEM_NAME").ToString & " (" & newDR.Item("ITEM_DESC").ToString & ")"
                lbl_location.Text = newDR.Item("wh_area").ToString & " (" & newDR.Item("wh_location").ToString & ")"
                lblReOrderPoint.Text = newDR.Item("whReorderPoint").ToString

                If inout = "IN" Then
                    'If type_of_purchasing = "DR" Then
                    '    view_stock_card3(date_req, rs_no, po_no, po_det_id)
                    'Else
                    view_stock_card2(date_req, rs_no, po_no, po_det_id)
                    'End If
                ElseIf inout = "OUT" Then
                    view_stock_card1(date_req, rs_no, po_no, po_det_id)
                End If

                'If type_of_purchasing = "PURCHASE ORDER" Then
                '    view_stock_card2(date_req, rs_no, po_no, po_det_id)
                'ElseIf type_of_purchasing = "WITHDRAWAL" Then
                '    view_stock_card1(date_req, rs_no, po_no, po_det_id)
                'End If


            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Public Sub get_item_previous_stockCard(ByVal id As Integer)
        Dim sqlcon As New SQLcon
        Dim dr As SqlDataReader
        Dim cmd As SqlCommand

        dtgStockCard.Rows.Clear()

        Try
            Dim a(20) As String

            sqlcon.connection.Open()
            cmd = New SqlCommand("proc_execute_tempstockcard", sqlcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@n", 12)
            cmd.Parameters.AddWithValue("@wh_id", id)
            cmd.Parameters.AddWithValue("@dateFrom", Date.Parse(dtpFrom.Text))
            cmd.Parameters.AddWithValue("@dateTo", Date.Parse(dtpTo.Text))

            dr = cmd.ExecuteReader

            While dr.Read

                lblitem_name.Text = dr.Item("whItem").ToString & " (" & dr.Item("whItemDesc").ToString & ")"
                lbl_location.Text = dr.Item("wh_area").ToString & " (" & dr.Item("wh_location").ToString & ")"
                lblReOrderPoint.Text = dr.Item("whReorderPoint").ToString
                lblBalance.Text = dr.Item("balance").ToString

                a(2) = Format(Date.Parse(dr.Item("date_previous").ToString), "MM/dd/yyyy")
                a(3) = dr.Item("rs_no").ToString
                a(7) = charge_to_or_supplier(dr.Item("supplier_reciepient").ToString, dr.Item("type_of_charge").ToString)
                a(10) = dr.Item("balance").ToString
                a(11) = dr.Item("remarks").ToString

                If dr.Item("status").ToString = "IN" Then
                    a(4) = dr.Item("invoice_no").ToString
                    a(5) = dr.Item("receiving_no").ToString
                    a(6) = "N/A"
                    a(8) = dr.Item("in_out").ToString
                    a(9) = "N/A"
                ElseIf dr.Item("status").ToString = "OUT" Then
                    a(4) = "N/A"
                    a(5) = "N/A"
                    a(6) = dr.Item("ws_no").ToString
                    a(8) = "N/A"
                    a(9) = dr.Item("in_out").ToString
                End If

                dtgStockCard.Rows.Add(a)

            End While
            dr.Close()


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try


    End Sub

    Public Sub view_stock_card2(ByVal date_req As DateTime, ByVal rs_no As String, ByVal po_no As String, ByVal po_det_id As Integer)
        Dim get_wh_id As Integer
        Dim wh_item_balance As Double

        get_wh_id = get_id("dbwarehouse_items", "whItem^whItemDesc", cmbItemName.Text & "^" & cmbItem_desc.Text, 2)
        wh_item_balance = get_balance_stockcard_maintenance(get_wh_id)

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim a(13) As String

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 7)
            newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                stock_card_balance += CDbl(newDR.Item("desired_qty").ToString)

                a(2) = date_req
                a(3) = rs_no
                a(4) = newDR.Item("invoice_no").ToString 'newDR.Item("rs_no").ToString
                a(5) = newDR.Item("rr_no").ToString
                a(6) = "N/A"
                a(7) = "SUPPLIER: " & newDR.Item("Supplier_Name").ToString
                a(8) = CDbl(newDR.Item("desired_qty").ToString)

                'a(10) = CDbl(newDR.Item("desired_qty").ToString) + CDbl(wh_item_balance)
                a(10) = stock_card_balance

                a(11) = ""

                dtgStockCard.Rows.Add(a)

            End While
            newDR.Close()

            Dim last_val As String
            For Each row1 As DataGridViewRow In dtgStockCard.Rows
                last_val = row1.Cells(10).Value
                If last_val Is Nothing Then
                    lblBalance.Text = "0"
                Else
                    lblBalance.Text = CDbl(last_val)
                End If
            Next



        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub


    Public Function get_supplier(ByVal po_det_id As Integer) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 9)
            newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_supplier = newDR.Item("Supplier_Name").ToString()
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function

    Public Sub view_stock_card1(ByVal date_req As DateTime, ByVal rs_no As String, ByVal po_no As String, ByVal po_det_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim a(13) As String

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 8)
            newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                stock_card_balance -= CDbl(newDR.Item("qty").ToString)

                a(2) = date_req
                a(3) = rs_no
                a(4) = "N/A" ' newDR.Item("rs_no").ToString
                a(5) = "N/A"
                a(6) = po_no
                a(7) = "RECEPIENT: " & FReceivingReport.multiplecharges(newDR.Item("rs_id").ToString, 1) 'newDR.Item("wh_area").ToString
                a(8) = ""
                a(9) = newDR.Item("qty").ToString
                a(10) = stock_card_balance
                a(11) = ""

                dtgStockCard.Rows.Add(a)

            End While
            newDR.Close()


            Dim last_val As String
            For Each row1 As DataGridViewRow In dtgStockCard.Rows
                last_val = row1.Cells(10).Value
                If last_val Is Nothing Then
                    lblBalance.Text = "0"
                Else
                    lblBalance.Text = CDbl(last_val)
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Public Sub view_stock_card3(ByVal date_req As DateTime, ByVal rs_no As String, ByVal dr_no As String, ByVal po_det_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim a(13) As String

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 10)
            newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                stock_card_balance += CDbl(newDR.Item("qty").ToString)

                a(2) = date_req
                a(3) = rs_no
                a(4) = dr_no ' newDR.Item("rs_no").ToString
                a(5) = "N/A"
                a(6) = "N/A"
                a(7) = "SOURCE: " & get_quarry_source(CInt(newDR.Item("rs_id").ToString))
                a(8) = newDR.Item("qty").ToString
                a(10) = stock_card_balance
                a(11) = "REMARKS"

                dtgStockCard.Rows.Add(a)

            End While
            newDR.Close()


            'Dim last_val As String
            'For Each row1 As DataGridViewRow In dtgStockCard.Rows
            '    last_val = row1.Cells(10).Value
            '    If last_val Is Nothing Then
            '        lblBalance.Text = "0"
            '    Else
            '        lblBalance.Text = CDbl(last_val)
            '    End If
            'Next


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Public Function get_quarry_source(ByVal rs_id As Integer) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 11)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_quarry_source = newDR.Item("quarry_name").ToString()
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function

    Public Function get_in_amount(ByVal po_det_id As Integer, ByVal n As Integer) As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            If n = 1 Then
                newCMD.Parameters.AddWithValue("@n", 7)
            ElseIf n = 2 Then
                newCMD.Parameters.AddWithValue("@n", 8)
            End If

            newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                If n = 1 Then
                    get_in_amount += newDR.Item("desired_qty").ToString
                ElseIf n = 2 Then
                    get_in_amount += newDR.Item("qty").ToString
                End If


            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Function get_data_from_receiving()
        'Dim newSQ As New SQLcon
        'Dim newCMD As SqlCommand
        'Dim newDR As SqlDataReader


        'Try
        '    newSQ.connection.Open()
        '    newCMD = New SqlCommand("proc_execute_tempstockcard", newSQ.connection)
        '    newCMD.Parameters.Clear()
        '    newCMD.CommandType = CommandType.StoredProcedure

        '    newCMD.Parameters.AddWithValue("@n", 7)
        '    newCMD.Parameters.AddWithValue("@fi_id", fi_id)

        '    newDR = newCMD.ExecuteReader

        '    While newDR.Read
        '        get_brand_name = newDR.Item("brand").ToString()
        '    End While
        '    newDR.Close()

        'Catch ex As Exception
        '    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Finally
        '    newSQ.connection.Close()
        'End Try

    End Function


    Public Sub preview_stock_card()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim a(20) As String
        Dim wh_item_balance As Double
        Dim get_wh_id As Integer

        get_wh_id = get_id("dbwarehouse_items", "whItem^whItemDesc", cmbItemName.Text & "^" & cmbItem_desc.Text, 2)


        wh_item_balance = get_balance_stockcard_maintenance(get_wh_id)
        lblBalance.Text = wh_item_balance

        lblitem_name.Text = cmbItemName.Text & " - " & cmbItem_desc.Text
        lbl_location.Text = get_data_from_wh_item_database(get_wh_id, "wh_area")
        lblReOrderPoint.Text = get_data_from_wh_item_database(get_wh_id, "reorder_point")

        dtgStockCard.Rows.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 3)
            newCMD.Parameters.AddWithValue("@wh_id", get_wh_id)

            newDR = newCMD.ExecuteReader
            While newDR.Read
                Dim rs_id As Integer = CInt(newDR.Item("rs_id").ToString)

                If newDR.Item("IN_OUT").ToString = "IN" Then

                    Dim rr_exist As Integer = check_if_exist("dbreceiving_items", "rs_id", CInt(newDR.Item("rs_id").ToString), 1)

                    If rr_exist > 0 Then
                        wh_item_balance += IIf(newDR.Item("WS_IN").ToString = "", 0, CDbl(newDR.Item("WS_IN").ToString))

                        a(2) = remove_last_character(get_receiving_data(rs_id, "date_received"))
                        a(3) = newDR.Item("RS_NO").ToString
                        a(4) = remove_last_character(get_receiving_data(rs_id, "invoiceno")) 'newDR.Item("INVOICE_NO").ToString
                        a(5) = remove_last_character(get_receiving_data(rs_id, "rr_no")) 'newDR.Item("RR_NO").ToString
                        a(6) = "N/A"
                        a(7) = "Supplier: " & newDR.Item("Supp_Reciepent").ToString
                        a(8) = newDR.Item("WS_IN").ToString
                        a(9) = "N/A"

                    Else
                        GoTo proceedhere
                    End If

                ElseIf newDR.Item("IN_OUT").ToString = "OUT" Then
                    Dim qty_out As Double = remove_last_character(get_withdrawn_data(rs_id, "qty_withdrawn"))

                    Dim if_rs_id_exist As Integer = check_if_exist("dbwithdrawn_items", "rs_id", CInt(newDR.Item("rs_id").ToString), 1)
                    If if_rs_id_exist > 0 Then
                        wh_item_balance -= qty_out
                        a(2) = remove_last_character(get_withdrawn_data(rs_id, "date_withdrawn"))
                    Else
                        GoTo proceedhere
                    End If

                    a(3) = newDR.Item("RS_NO").ToString
                    a(4) = "N/A"
                    a(5) = "N/A"
                    a(6) = remove_last_character(get_withdrawn_data(rs_id, "ws_no")) 'newDR.Item("WS_NO").ToString
                    a(7) = "Recipient: " & FReceivingReport.multiplecharges(CInt(newDR.Item("rs_id").ToString), 1)
                    a(8) = "N/A"
                    a(9) = qty_out 'newDR.Item("WS_OUT").ToString

                End If

                a(10) = wh_item_balance
                a(11) = IIf(newDR.Item("UNIT_AMOUNT").ToString = "", 0, newDR.Item("UNIT_AMOUNT").ToString)
                a(11) = FormatNumber(CDbl(a(11)), 2, , TriState.True)
                a(11) = IIf(a(11) = 0, get_unit_price_from_wh_item_db(newDR.Item("wh_id").ToString), a(11))

                dtgStockCard.Rows.Add(a)

proceedhere:

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Public Function get_receiving_data(ByVal rs_id As Integer, ByVal field As String) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        get_receiving_data = ""

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 4)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                If field = "invoiceno" Then
                    get_receiving_data &= newDR.Item("invoice_no").ToString & ","

                ElseIf field = "rr_no" Then
                    get_receiving_data &= newDR.Item("rr_no").ToString & ","

                ElseIf field = "date_received" Then
                    get_receiving_data &= Format(Date.Parse(newDR.Item("date_received").ToString), "MM/dd/yyyy") & ","

                End If
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Function

    Public Function get_withdrawn_data(ByVal rs_id As Integer, ByVal field As String) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        get_withdrawn_data = ""

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 5)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                If field = "ws_no" Then
                    get_withdrawn_data &= newDR.Item("ws_no").ToString & ","

                ElseIf field = "date_withdrawn" Then
                    get_withdrawn_data &= Format(Date.Parse(newDR.Item("date_withdraw").ToString), "MM/dd/yyyy") & ","

                ElseIf field = "qty_withdrawn" Then
                    get_withdrawn_data &= newDR.Item("qty").ToString & ","

                End If
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Function
    Public Function get_unit_price_from_wh_item_db(ByVal wh_d As Integer) As Double
        Dim query As String = "SELECT default_price FROM dbwarehouse_items WHERE wh_id = " & wh_id

        get_unit_price_from_wh_item_db = CDbl(get_specific_column_value(query, 2))

    End Function
    Public Function get_data_from_wh_item_database(ByVal wh_id As Integer, ByVal what_column As String) As String
        If what_column = "wh_area" Then
            Dim query As String = "SELECT wh_area FROM dbwarehouse_items a INNER JOIN dbwh_area b ON a.whArea = b.wh_area_id WHERE a.wh_id = " & wh_id
            get_data_from_wh_item_database = get_specific_column_value(query, 0)

        ElseIf what_column = "reorder_point" Then
            Dim query As String = "SELECT whReorderPoint FROM dbwarehouse_items WHERE wh_id = " & wh_id
            get_data_from_wh_item_database = get_specific_column_value(query, 1)

        End If


    End Function


    Public Sub get_stock_card_temp(ByVal obj As Object, ByVal whID As String)

        dtgStockCard.Rows.Clear()
        lblitem_name.ResetText()
        lblReOrderPoint.ResetText()
        lbl_location.ResetText()

        Try
            SQLcon.connection.Open()

            cmd = New SqlCommand("proc_execute_tempstockcard", SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@wh_id", whID)
            cmd.Parameters.AddWithValue("@n", 2)
            sqldr = cmd.ExecuteReader

            While sqldr.Read

                Dim a(20) As String

                'lblitem_name.Text = get_warehouse_details(sqldr.Item("wh_id").ToString, 2)
                lblitem_name.Text = txtItemName.Text.ToUpper
                lblReOrderPoint.Text = get_warehouse_details(sqldr.Item("wh_id").ToString, 0)
                lbl_location.Text = get_warehouse_details(sqldr.Item("wh_id").ToString, 1)

                a(0) = sqldr.Item("rs_id").ToString()
                a(2) = Format(Date.Parse(sqldr.Item("date_req").ToString), "MMMM dd, yyyy")
                a(3) = sqldr.Item("rs_no").ToString()
                'a(7) = charge_to_or_supplier(sqldr.Item("wh_id").ToString, sqldr.Item("type_request").ToString)

                Dim qty As Double = CDbl(sqldr.Item("qty").ToString)
                Dim count As Integer = count_request(sqldr.Item("rs_id").ToString)

                If sqldr.Item("in_out").ToString = "IN" And sqldr.Item("received_status").ToString = "RECEIVED" Then
                    a(4) = sqldr.Item("invoice_no").ToString()
                    a(5) = sqldr.Item("rr_no").ToString()
                    a(6) = "N/A"
                    a(7) = sqldr.Item("supplier").ToString()
                    a(8) = qty / count
                    a(11) = sqldr.Item("received_status").ToString
                    a(12) = sqldr.Item("all_charges_id").ToString

                ElseIf sqldr.Item("in_out").ToString = "OUT" And sqldr.Item("received_status").ToString = "WITHDRAWN" And sqldr.Item("type_request").ToString = "PERSONAL" _
                Or sqldr.Item("type_request").ToString = "MAINOFFICE" Or sqldr.Item("type_request").ToString = "OTHERS" Then
                    a(3) = sqldr.Item("rs_no").ToString()
                    a(4) = "N/A"
                    a(5) = "N/A"
                    a(6) = sqldr.Item("rr_no").ToString
                    a(7) = get_supplier_from_charge_to(sqldr.Item("all_charges_id").ToString)
                    a(9) = qty / count
                    a(11) = sqldr.Item("received_status").ToString
                    a(12) = sqldr.Item("all_charges_id").ToString

                ElseIf sqldr.Item("in_out").ToString = "OUT" And sqldr.Item("received_status").ToString = "WITHDRAWN" And sqldr.Item("type_request").ToString = "EQUIPMENT" Then
                    a(3) = sqldr.Item("rs_no").ToString()
                    a(4) = "N/A"
                    a(5) = "N/A"
                    a(6) = sqldr.Item("rr_no").ToString
                    a(7) = get_supplier_equipment_OUT(sqldr.Item("all_charges_id").ToString)
                    a(9) = qty / count
                    a(11) = sqldr.Item("received_status").ToString
                    a(12) = sqldr.Item("all_charges_id").ToString

                ElseIf sqldr.Item("in_out").ToString = "OUT" And sqldr.Item("received_status").ToString = "WITHDRAWN" And sqldr.Item("type_request").ToString = "PROJECT" Then
                    a(3) = sqldr.Item("rs_no").ToString()
                    a(4) = "N/A"
                    a(5) = "N/A"
                    a(6) = sqldr.Item("rr_no").ToString
                    a(7) = get_project_charge_to(sqldr.Item("all_charges_id").ToString)
                    a(9) = qty / count
                    a(11) = sqldr.Item("received_status").ToString
                    a(12) = sqldr.Item("all_charges_id").ToString

                ElseIf sqldr.Item("in_out").ToString = "OUT" And sqldr.Item("received_status").ToString = "WITHDRAWN" And sqldr.Item("type_request").ToString = "WAREHOUSE" Then
                    a(4) = "N/A"
                    a(5) = "N/A"
                    a(6) = sqldr.Item("rr_no").ToString()
                    a(7) = get_supplier_from_warehouse_area(sqldr.Item("all_charges_id").ToString)
                    a(9) = qty / count
                    a(11) = sqldr.Item("received_status").ToString
                    a(12) = sqldr.Item("all_charges_id").ToString

                Else

                End If

                stockcard_bal = get_balance_stockcard_maintenance(sqldr.Item("wh_id").ToString)
                a(10) = get_balance() + CInt(stockcard_bal)

                dtgStockCard.Rows.Add(a)

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub

    'Private Sub dtgStockCard_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dtgStockCard.CellValidating
    '    If TypeOf dtgStockCard.CurrentCell Is DataGridViewCheckBoxCell Then
    '        dtgStockCard.EndEdit()
    '        Dim Checked As Boolean = CType(dtgStockCard.CurrentCell.Value, Boolean)
    '        If Checked Then
    '            MessageBox.Show("You have checked")
    '        Else
    '            MessageBox.Show("You have un-checked")
    '        End If
    '    End If
    'End Sub

    Public Function count_request(ByVal id As Integer)

        Dim newsqlcon As New SQLcon
        Dim newcmd As SqlCommand
        Dim newsqldr As SqlDataReader

        Try
            newsqlcon.connection.Open()
            publicquery = "SELECT COUNT(*) FROM dbMultipleCharges WHERE rs_id = '" & id & "'"
            newcmd = New SqlCommand(publicquery, newsqlcon.connection)
            count_request = newcmd.ExecuteScalar

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
        End Try

    End Function

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        Dim i As Integer = 0

        For i = 0 To dtgStockCard.RowCount - 1
            dtgStockCard.Rows(i).Cells(1).Value = True
        Next

    End Sub

    Private Sub lbox_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbox.Leave
        lbox.Visible = False
    End Sub

    Private Sub lbox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbox.SelectedIndexChanged

    End Sub

    Private Sub cmbItemName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbItemName.SelectedIndexChanged

        FMaterials_ToolsTurnOverTextFields.get_WhItemDesc(cmbItemName.Text, 0, cmbItem_desc)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel5.Visible = False
    End Sub

    Private Sub btnSearch_View_Click(sender As Object, e As EventArgs) Handles btnSearch_View.Click

        If lbl_status.Text = "CRUSHING AND HAULING DEPT." Then
            If cmbOptions.Text = "Search by StockCard" Then
                dtgStockCard.Rows.Clear()
                Label6.Visible = True
                lblBalance.Text = 0
                cprevBalance = 0
                cBalance = 0

                Label6.Text = "Initializing data...."
                PictureBox1.Visible = True
                cWh_id = get_wh_id_using_wharea(cmbItemName.Text, cmbItem_desc.Text, cmbWareHouse.Text, cmbclassification.Text)

                If cWh_id = 0 Then
                    MessageBox.Show($"No Aggregates has been found, { vbCrLf } please check the item info carefully...", "SMS INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    PictureBox1.Visible = False
                    Label6.Visible = False
                    Exit Sub
                End If

                cDateFrom = dtpFrom.Text
                cDateTo = dtpTo.Text

                PictureBox2.Visible = True
                PictureBox2.Dock = DockStyle.Fill

                set_agg_variables(cWh_id, cDateFrom, cDateTo)

                GENERATE()

                'BackgroundWorker3.RunWorkerAsync()

            End If
        End If



        'mthread.Abort()

        'get_wh_id = get_id("dbwarehouse_items", "whItem^whItemDesc", cmbItemName.Text & "^" & cmbItem_desc.Text, 2)

        'Dim if_wh_id_exist As Integer = check_if_exist("dbrequisition_slip", "wh_id", CInt(get_wh_id), 1)

        'If if_wh_id_exist > 0 Then

        '    get_rs_id(get_wh_id)
        '    'view_stock_card()
        'Else
        '    get_item_previous_stockCard(get_wh_id)
        'End If
    End Sub

    Public Sub searchAggregatesByWhId(wh_id As Integer, dateFrom As DateTime, dateTo As DateTime)
        Try
            cCustomDatagrid.customDatagridview(dtgStockCard)

            PictureBox2.Visible = True
            PictureBox2.Dock = DockStyle.Fill

            PictureBox1.Visible = True

            set_agg_variables(wh_id, dateFrom, dateTo)

            GENERATE()
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Public Sub set_agg_variables(whid As Integer, datefrom As DateTime, dateto As DateTime)
        'SET VARIABLES
        cWh_id = whid
        cDateFrom = datefrom
        cDateTo = dateto

    End Sub
    Public Sub GENERATE()
        'RESET
        r1 = False
        r2 = False
        r3 = False
        r4 = False
        r5 = False

        NewStockCard1.cListOfStockCard.Clear()
        NewStockCard4.cListOfStockCard.Clear()

        NewStockCard3.myBalanceNow = 0
        NewStockCard3.my_prev_balance = 0

        'PROCESS 1: GET AGGREGATES DATA
        bw_get_agg_data = New BackgroundWorker
        bw_get_agg_data.WorkerSupportsCancellation = True
        bw_get_agg_data.RunWorkerAsync()

        'PROCESS 2: INITIALIZE PREV BALANCE 
        bw_prev_balance2 = New BackgroundWorker
        bw_prev_balance2.WorkerSupportsCancellation = True
        bw_prev_balance2.RunWorkerAsync()

        'PROCESS 3: INITIALIZE PREVIOUS BALANCE FROM THE START (EXCEL FILE DATA)
        bw_prev_balance = New BackgroundWorker
        bw_prev_balance.WorkerSupportsCancellation = True
        bw_prev_balance.RunWorkerAsync()

        'PROCESS 4: CHECK IF DONE
        bw_check_if_done = New BackgroundWorker
        bw_check_if_done.WorkerSupportsCancellation = True
        bw_check_if_done.RunWorkerAsync()

        'PROCESS 5: WAREHOUSE LOCATION
        bw_warehouse_loc = New BackgroundWorker
        AddHandler bw_warehouse_loc.DoWork, AddressOf bw_warehouse_loc_DoWork
        AddHandler bw_warehouse_loc.RunWorkerCompleted, AddressOf bw_warehouse_loc_RunWorkerCompleted

        bw_warehouse_loc.WorkerSupportsCancellation = True
        bw_warehouse_loc.RunWorkerAsync()
    End Sub

    Private Sub bw_warehouse_loc_DoWork(sender As Object, e As DoWorkEventArgs)
        wh_loc = NewStockCard5.warehouse_location(cWh_id)
    End Sub
    Private Sub bw_warehouse_loc_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        r5 = True
    End Sub

    Public Structure search_wh_data
        Dim s_item_name As String
        Dim s_item_desc As String
        Dim s_classification As String
        Dim s_warehouse As String
        Dim s_n As Integer

    End Structure

    Private Delegate Sub del_calculate_remaining_balance()
    Private Sub calculate_remaining_balance()
        If InvokeRequired Then
            Invoke(New del_calculate_remaining_balance(AddressOf calculate_remaining_balance))
            Exit Sub
        End If

        Dim STthread_Data As search_wh_data
        STthread_Data.s_item_name = cmbItemName.Text
        STthread_Data.s_item_desc = cmbItem_desc.Text
        STthread_Data.s_classification = cmbclassification.Text
        STthread_Data.s_warehouse = cmbWareHouse.Text
        STthread_Data.s_n = 17

        thread = New Threading.Thread(AddressOf display_stock_card5)
        thread.SetApartmentState(ApartmentState.MTA)
        thread.Start(STthread_Data)
        PictureBox1.Visible = True
        Label6.Visible = True
        Timer1.Start()
    End Sub
    Public Sub display_stock_card3(n As Integer, wh_id As Integer)
        Dim balance1 As Double


        dtgStockCard.Rows.Clear()

        'Dim wh_id As Integer = get_wh_id_using_wharea(cmbItemName.Text, cmbItem_desc.Text, cmbWareHouse.Text, cmbclassification.Text)

        'ugma nani nko trabahoon...
        '==>
        Dim beginning_balance As Double = get_prev_remaining_balance1(wh_id) + get_prev_item_balance(wh_id)
        lblBalance.Text = beginning_balance
        'ehehehehehe


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
            newCMD.Parameters.AddWithValue("@date_from", Date.Parse(dtpFrom.Text))
            newCMD.Parameters.AddWithValue("@date_to", Date.Parse(dtpTo.Text))

            warehouse_location(wh_id)

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



                                'example 12 / 8 so, 8 - 12 = -4 therefore, dili pde mag negative
                                If a(9) < 0 Then
                                    beginning_balance = beginning_balance - 0
                                Else
                                    'beginning_balance = beginning_balance - CDbl(a(9))
                                End If

                                If count_qty_dr_using_ws_no(ws_no, rs_no, 12) = 0 Then
                                    a(9) = CDbl(newDR.Item("qty_OUT").ToString)
                                Else
                                    a(9) = count_qty_dr_using_ws_no(ws_no, rs_no, 12) & "/" & CDbl(newDR.Item("qty_OUT").ToString)
                                End If

                                a(10) = FormatNumber(beginning_balance,,, TriState.True)

                            Else
                                beginning_balance = beginning_balance - CDbl(newDR.Item("qty_OUT").ToString)
                                a(10) = FormatNumber(beginning_balance,,, TriState.True)
                            End If

                        ElseIf newDR.Item("IN_OUT").ToString = "IN" Then

                            a(8) = newDR.Item("qty_IN").ToString
                            beginning_balance = beginning_balance + CDbl(a(8))
                            a(10) = FormatNumber(beginning_balance,,, TriState.True)

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
            MsgBox(balance1)
        End Try
    End Sub

    Structure sc
        Dim drdate As DateTime
        Dim rs_no As String
        Dim drno_invoice As String
        Dim rr_no As String
        Dim ws_no As String
        Dim supp_recipient As String
        Dim qty_in As String
        Dim qty_out As String
        Dim balance As Double
        Dim remarks As String

    End Structure

    Private Sub get_stock_card_for_hauling()

        NewStockCard._initialize(cWh_id, cDateFrom, cDateTo)
        trd_checker = New Threading.Thread(AddressOf thread_checker_1)
        trd_checker.Start()

        NewStockCard._initialize_qty(cWh_id, cDateFrom, cDateTo)
        'trd_checker2 = New Threading.Thread(AddressOf thread_checker_2)
        'trd_checker2.Start()

        NewStockCard._initialize_prev_balance()
        trd_checker3 = New Threading.Thread(AddressOf thread_checker_3)
        trd_checker3.Start()

        trd_checker4 = New Threading.Thread(AddressOf bb)
        trd_checker4.Start()

        NewStockCard._initialize_warehouse_location()
        Dim t As Threading.Thread
        t = New Threading.Thread(AddressOf thread_warehouse_location)
        t.Start()


    End Sub
    Private Sub thread_warehouse_location()
        Dim t As Threading.Thread
        t = New Threading.Thread(AddressOf NewStockCard.thread_warehouse_location)
        t.Start()
        t.Join()

        If lblitem_name.InvokeRequired Then
            lblitem_name.Invoke(Sub()
                                    lblitem_name.Text = NewStockCard.cItem_name
                                    lbl_location.Text = NewStockCard.cLocation
                                    lblReOrderPoint.Text = NewStockCard.cReorderPoint
                                End Sub)
        End If
    End Sub

    Private Sub thread_checker_1()
        If Label6.InvokeRequired Then
            Label6.Invoke(Sub()
                              Label6.Text = "Retreiving Data From Database..."
                          End Sub)
        End If
        While True
            Threading.Thread.Sleep(500)
            If Not NewStockCard.trd.IsAlive Or NewStockCard.trd Is Nothing Then
                Exit While
            End If
        End While

        display_stock_card_new()
    End Sub

    Private Sub thread_checker_2()

        While True
            Threading.Thread.Sleep(500)
            If Not NewStockCard.trd4.IsAlive Then
                Exit While
            End If
        End While

        Dim listofqty = NewStockCard.cListOfQty

        For Each row In listofqty
            If row.inout = "OUT" Then
                If IsNumeric(row.qty_out) Then
                    cBalance = Math.Round(cBalance, 2) - row.qty_out
                Else
                    Dim sp() As String = row.qty_out.ToString.Split("/")

                    If CDbl(sp(0)) < CDbl(sp(1)) Then
                        cBalance = Math.Round(cBalance) - (CDbl(sp(1)) - CDbl(sp(0)))
                    End If
                End If

            ElseIf row.inout = "IN" Then
                cBalance += row.qty_in
            End If
        Next

        'If NewStockCard.cListOfQty.Count = 0 Then
        '    cBalance = NewStockCard.prev_balance
        'End If

        If lblBalance.InvokeRequired Then
            lblBalance.Invoke(Sub()

                                  lblBalance.Text = cBalance + cprevBalance
                                  trig2 = True
                              End Sub)
        End If


    End Sub
    Private Delegate Sub del_final_generating_balance()
    Private Sub final_generating_balance()
        'If InvokeRequired Then
        '    Invoke(New del_final_generating_balance(AddressOf final_generating_balance))
        '    Exit Sub
        'End If

        Dim result As Double

        result = CDbl(cBalance)
        If lblBalance.InvokeRequired Then
            lblBalance.Invoke(Sub()
                                  lblBalance.Text = result
                              End Sub)
        Else
            lblBalance.Text = result
        End If


        If dtgStockCard.InvokeRequired Then
            'FOR INVOKE
            dtgStockCard.Invoke(Sub()
                                    If dtgStockCard.Rows.Count = 0 Then
                                        MsgBox("Successfully Generated")

                                        For Each row In dtgStockCard.Rows

                                            If row.cells(8).value = 0 Then
                                                Dim out As String

                                                If IsNumeric(row.cells(9).value) Then
                                                    out = row.cells(9).value
                                                Else
                                                    Dim sp() As String = row.cells(9).value.ToString.Split("/")

                                                    If CDbl(sp(0)) < CDbl(sp(1)) Then
                                                        out = (CDbl(sp(1)) - CDbl(sp(0)))
                                                    Else
                                                        out = 0
                                                    End If
                                                End If

                                                result = CDbl(CStr(result)) - CDbl(out)
                                                row.cells(10).value = FormatNumber(CDbl(CStr(result)), 2,,, TriState.True)

                                            ElseIf CDbl(row.cells(8).value) > 0 Then
                                                result = FormatNumber(result, 2,,, TriState.True) + CDbl(CStr(row.cells(8).value))
                                                row.cells(10).value = FormatNumber(CDbl(CStr(result)), 2,,, TriState.True)
                                            End If
                                        Next
                                    End If
                                End Sub)

        Else
            'NOT INVOKE
            If dtgStockCard.Rows.Count = 0 Then
                MsgBox("Successfully Generated")

                For Each row In dtgStockCard.Rows

                    If row.cells(8).value = 0 Then
                        Dim out As String

                        If IsNumeric(row.cells(9).value) Then
                            out = row.cells(9).value
                        Else
                            Dim sp() As String = row.cells(9).value.ToString.Split("/")

                            If CDbl(sp(0)) < CDbl(sp(1)) Then
                                out = (CDbl(sp(1)) - CDbl(sp(0)))
                            Else
                                out = 0
                            End If
                        End If

                        result = CDbl(CStr(result)) - CDbl(out)
                        row.cells(10).value = FormatNumber(CDbl(CStr(result)), 2,,, TriState.True)

                    ElseIf CDbl(row.cells(8).value) > 0 Then
                        result = FormatNumber(result, 2,,, TriState.True) + CDbl(CStr(row.cells(8).value))
                        row.cells(10).value = FormatNumber(CDbl(CStr(result)), 2,,, TriState.True)
                    End If
                Next
            End If
        End If

        If Label6.InvokeRequired Then
            Label6.Invoke(Sub()
                              Label6.Text = "Successfully Generated..."
                              PictureBox1.Visible = False
                          End Sub)
        Else
            Label6.Text = "Successfully Generated..."
            PictureBox1.Visible = False
        End If

    End Sub

    Private Sub thread_checker_3()
        While True
            Threading.Thread.Sleep(500)
            If Not NewStockCard.trd6.IsAlive Or NewStockCard.trd6 Is Nothing Then
                Exit While
            End If
        End While

        cprevBalance = NewStockCard.prev_balance

        'If lblBalance.InvokeRequired Then
        '    lblBalance.Invoke(Sub()
        '                          lblBalance.Text = cBalance
        '                      End Sub)
        'End If
    End Sub
    Private Delegate Sub del_check_if_datagridview_is_not_empty()
    Private Sub thread_checker_4()



    End Sub


    Private cListOfStockCard As New List(Of sc)
    Private Delegate Sub del_display_stock_card(n As Integer)
    Public Sub display_stock_card4(n As Integer)
        If InvokeRequired Then
            Invoke(New del_display_stock_card(AddressOf display_stock_card4), n)
            Exit Sub
        End If

        dtgStockCard.Rows.Clear()
        cListOfStockCard.Clear()

        Dim wh_id As Integer = get_wh_id_using_wharea(cmbItemName.Text, cmbItem_desc.Text, cmbWareHouse.Text, cmbclassification.Text)

        If wh_id = 0 Then
            Exit Sub
        End If

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim newSc As New sc

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.CommandTimeout = 0

            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newCMD.Parameters.AddWithValue("@date_from", Date.Parse(dtpFrom.Text))
            newCMD.Parameters.AddWithValue("@date_to", Date.Parse(dtpTo.Text))

            warehouse_location(wh_id)

            newDR = newCMD.ExecuteReader

            Dim a(20) As String
            Dim rowcount As Integer = 0
            While newDR.Read
                Dim ws_no As String = newDR.Item("WS_NO").ToString
                Dim rs_no As String = newDR.Item("rs_no").ToString

                Select Case n
                    Case 5
'                      
                    Case 11

                        With newSc

                            If newDR.Item("WITHDRAWN").ToString = "NO" Then
                                GoTo proceedhere
                            End If

                            If newDR.Item("stat").ToString = "" And newDR.Item("dr_no").ToString = "" Then
                                GoTo proceedhere

                            ElseIf newDR.Item("stat").ToString = "" And newDR.Item("dr_no").ToString <> "" Then
                                .drno_invoice = newDR.Item("dr_no").ToString
                                .rr_no = "N/A"
                                .ws_no = "N/A"
                            End If

                            .drdate = Format(Date.Parse(newDR.Item("date").ToString), "MM/dd/yyyy")
                            .rs_no = newDR.Item("rs_no").ToString

                            Dim stat As String = newDR.Item("stat").ToString

                            .drno_invoice = newDR.Item("dr_no").ToString.ToUpper
                            .ws_no = newDR.Item("WS_NO").ToString.ToUpper
                            .rr_no = IIf(newDR.Item("RR_NO").ToString.ToUpper = "", "N/A", newDR.Item("RR_NO").ToString.ToUpper)

                            If newDR.Item("IN_OUT").ToString = "OUT" Then
                                .supp_recipient = newDR.Item("SOURCE_WH").ToString

                                If newDR.Item("SORTING").ToString = "A" Then
                                    .qty_in = 0

                                    Dim count_qty_dr As Double = count_qty_dr_using_ws_no(ws_no, rs_no, 12)
                                    .qty_out = CDbl(newDR.Item("qty_OUT").ToString) - count_qty_dr

                                    'example 12/8 so, 8-12 = -4 therefore,  dili pde mag negative
                                    If .qty_out < 0 Then
                                        'beginning_balance = beginning_balance - 0
                                    Else
                                        'beginning_balance = beginning_balance - CDbl(a(9))
                                    End If

                                    If count_qty_dr = 0 Then
                                        .qty_out = CDbl(newDR.Item("qty_OUT").ToString)
                                    Else
                                        .qty_out = count_qty_dr & "/" & CDbl(newDR.Item("qty_OUT").ToString)
                                    End If
                                Else
                                    .qty_in = 0
                                    .qty_out = newDR.Item("qty_OUT").ToString
                                    'beginning_balance = beginning_balance - CDbl(newDR.Item("qty_OUT").ToString)
                                    'a(10) = FormatNumber(beginning_balance,,, TriState.True)
                                End If

                            ElseIf newDR.Item("IN_OUT").ToString = "IN" Then
                                If newDR.Item("type_of_purchasing").ToString = "PURCHASE ORDER" Then
                                    .supp_recipient = get_supp_recepient(newDR.Item("dr_no").ToString)
                                Else
                                    .supp_recipient = newDR.Item("SOURCE_WH").ToString
                                End If

                                .qty_in = newDR.Item("qty_IN").ToString
                                .qty_out = 0

                            End If

                            .remarks = newDR.Item("remarks").ToString

                            cListOfStockCard.Add(newSc)

                            'dtgStockCard.Rows.Add(a)

                            'If newDR.Item("SORTING").ToString = "A" Then
                            '    If newDR.Item("type_of_delivery").ToString = "WITHOUT DR" Then
                            '    Else
                            '        dtgStockCard.Rows(rowcount).DefaultCellStyle.BackColor = Color.LightBlue
                            '        dtgStockCard.Rows(rowcount).DefaultCellStyle.ForeColor = Color.Black
                            '    End If


                            'End If

                            rowcount += 1
                        End With
proceedhere:

                End Select
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

            display_stock_card_new()
            'calculate_remaining_balance()
        End Try

    End Sub
    Private Delegate Sub del_display_stock_card_new()
    Private Sub display_stock_card_new()
        If InvokeRequired Then
            Invoke(New del_display_stock_card_new(AddressOf display_stock_card_new))
            Exit Sub
        End If

        Dim ListOfStockCard = NewStockCard.cListOfStockCard

        Dim countrows As Integer

        For Each row In ListOfStockCard
            Dim a(24) As String

            a(2) = row.drdate
            a(3) = row.rs_no
            a(4) = row.drno_invoice
            a(5) = row.rr_no
            a(6) = row.ws_no
            a(7) = row.supp_recipient
            a(8) = row.qty_in
            a(9) = row.qty_out
            a(11) = row.remarks

            dtgStockCard.Rows.Add(a)

            If Not IsNumeric(row.qty_out) Then
                dtgStockCard.Rows(countrows).DefaultCellStyle.BackColor = Color.LightBlue
            End If

            countrows += 1

        Next

        Label6.Text = "Initializing Balance..."
        trig = True
        'calculate_remaining_balance()    
    End Sub

    Private Delegate Function del_get_supp_recepient(dr_no As String) As String
    Private Function get_supp_recepient(dr_no As String) As String
        If InvokeRequired Then
            Invoke(New del_get_supp_recepient(AddressOf get_supp_recepient), dr_no)
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

            newCMD.Parameters.AddWithValue("@n", 19)
            newCMD.Parameters.AddWithValue("@dr_no", dr_no)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_supp_recepient = newDR.Item("Supp_Rec").ToString
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Public Sub display_stock_card5(ByVal STthread_Data As search_wh_data)
        Dim n As Integer = STthread_Data.s_n
        Dim a_item_name As String = STthread_Data.s_item_name
        Dim a_item_desc As String = STthread_Data.s_item_desc
        Dim a_classification As String = STthread_Data.s_classification
        Dim a_warehouse As String = STthread_Data.s_warehouse

        Dim wh_id As Integer = get_wh_id_using_wharea(a_item_name, a_item_desc, a_warehouse, a_classification)

        'ugma nani nko trabahoon...
        '==>
        Dim beginning_balance As Double = get_prev_item_balance(wh_id)
        'ehehehehehe


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
            newCMD.Parameters.AddWithValue("@date_to", Date.Parse(dtpFrom.Text).AddDays(-1))

            warehouse_location(wh_id)

            newDR = newCMD.ExecuteReader

            Dim a(20) As String
            Dim rowcount As Integer = 0
            While newDR.Read
                Dim ws_no As String = newDR.Item("WS_NO").ToString
                Dim rs_no As String = newDR.Item("rs_no").ToString

                'lblReOrderPoint.Text = newDR.Item("REORDER_POINT").ToString
                Select Case n
                    Case 5
                        If newDR.Item("dr_option").ToString = "WITH DR" And newDR.Item("DR").ToString = "PARENT DR" Then
                            GoTo proceedhere1
                        End If

                        If newDR.Item("IN_OUT").ToString = "OUT" Then
                            beginning_balance = beginning_balance - CDbl(newDR.Item("desired_qty").ToString)

                        ElseIf newDR.Item("IN_OUT").ToString = "IN" Then
                            beginning_balance = beginning_balance + CDbl(a(8))

                        End If
proceedhere1:

                    Case 17
                        If newDR.Item("WITHDRAWN").ToString = "NO" Then
                            GoTo proceedhere
                        End If

                        If newDR.Item("stat").ToString = "" And newDR.Item("dr_no").ToString = "" Then
                            GoTo proceedhere

                        End If

                        If newDR.Item("IN_OUT").ToString = "OUT" Then

                            If newDR.Item("SORTING").ToString = "A" Then
                                Dim count_qty_dr As Double = count_qty_dr_using_ws_no(ws_no, rs_no, 12)

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

                End Select
            End While
            newDR.Close()

            'Calibrate balance
            If lblBalance.InvokeRequired Then
                lblBalance.Invoke(Sub()
                                      lblBalance.Text = beginning_balance

                                      Dim lbalance As Decimal = lblBalance.Text

                                      For Each row As DataGridViewRow In dtgStockCard.Rows
                                          If row.Cells("Column7").Value = "" Then
                                              'out

                                              If row.DefaultCellStyle.BackColor = Color.LightBlue Then

                                                  If Not IsNumeric(row.Cells("Column8").Value) Then
                                                      'dili xa numeric means naay /
                                                      Dim out() As String
                                                      out = row.Cells("Column8").Value.ToString.Split("/")

                                                      If (out(1) - out(0)) < 0 Then
                                                          lbalance = lbalance - 0
                                                      Else
                                                          lbalance = lbalance - (out(1) - out(0))
                                                      End If
                                                  Else
                                                      'numeric xa
                                                      lbalance = lbalance - CDbl(row.Cells("Column8").Value)
                                                  End If
                                              Else
                                                  lbalance = lbalance - CDbl(row.Cells("Column8").Value)
                                              End If

                                              'lbalance = lbalance - CDec(IIf(Not IsNumeric(row.Cells("Column8").Value), 0, row.Cells("Column8").Value))
                                              row.Cells("Column9").Value = FormatNumber(CDbl(lbalance), 2,,, TriState.True)

                                          ElseIf row.Cells("Column8").Value = "" Then
                                              'in
                                              lbalance = lbalance + CDec(row.Cells("Column7").Value)
                                              row.Cells("Column9").Value = FormatNumber(CDbl(lbalance), 2,,, TriState.True)
                                          End If
                                      Next
                                  End Sub)
            Else
                lblBalance.Text = beginning_balance

                Dim lbalance As Decimal = lblBalance.Text

                For Each row As DataGridViewRow In dtgStockCard.Rows
                    If row.Cells("Column7").Value = "" Then
                        'out

                        If row.DefaultCellStyle.BackColor = Color.LightBlue Then
                            Dim out() As String
                            out = row.Cells("Column8").Value.ToString.Split("/")

                            If (out(1) - out(0)) < 0 Then
                                lbalance = lbalance - 0
                            Else
                                lbalance = lbalance - (out(1) - out(0))
                            End If

                        End If

                        'lbalance = lbalance - CDec(IIf(Not IsNumeric(row.Cells("Column8").Value), 0, row.Cells("Column8").Value))
                        row.Cells("Column9").Value = FormatNumber(CDbl(lbalance), 2,,, TriState.True)

                    ElseIf row.Cells("Column8").Value = "" Then
                        'in
                        lbalance = lbalance + CDec(row.Cells("Column7").Value)
                        row.Cells("Column9").Value = FormatNumber(CDbl(lbalance), 2,,, TriState.True)
                    End If
                Next
            End If



        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Public Sub display_stock_card2(n As Integer)
        dtgStockCard.Rows.Clear()

        Dim wh_id As Integer = get_wh_id_using_wharea(cmbItemName.Text, cmbItem_desc.Text, cmbWareHouse.Text, cmbclassification.Text)

        'ugma nani nko trabahoon...
        '==>
        Dim beginning_balance As Double = get_prev_remaining_balance1(wh_id) + get_prev_item_balance(wh_id)
        lblBalance.Text = beginning_balance
        'ehehehehehe


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
            newCMD.Parameters.AddWithValue("@date_from", Date.Parse(dtpFrom.Text))
            newCMD.Parameters.AddWithValue("@date_to", Date.Parse(dtpTo.Text))

            warehouse_location(wh_id)

            newDR = newCMD.ExecuteReader

            Dim a(20) As String
            Dim rowcount As Integer = 0
            While newDR.Read
                Dim ws_no As String = newDR.Item("WS_NO").ToString
                Dim rs_no As String = newDR.Item("rs_no").ToString

                'lblReOrderPoint.Text = newDR.Item("REORDER_POINT").ToString
                Select Case n
                    Case 5
                        If newDR.Item("dr_option").ToString = "WITH DR" And newDR.Item("DR").ToString = "PARENT DR" Then
                            GoTo proceedhere1
                        End If

                        a(2) = Format(Date.Parse(newDR.Item("DATE_Withdrawn_received").ToString), "MM/dd/yyyy")
                        a(3) = IIf(newDR.Item("rs_no").ToString = "", "N/A", newDR.Item("rs_no").ToString)
                        a(4) = IIf(newDR.Item("dr_no_invoice_no").ToString = "", "N/A", newDR.Item("dr_no_invoice_no").ToString)
                        ' a(5) = IIf(newDR.Item("RR_NO").ToString = "", "N/A", newDR.Item("RR_NO").ToString)
                        a(6) = IIf(newDR.Item("WS_no").ToString = "", "N/A", newDR.Item("WS_no").ToString)


                        If newDR.Item("IN_OUT").ToString = "OUT" Then

                            a(7) = newDR.Item("SOURCE_WH").ToString
                            a(8) = ""
                            a(9) = newDR.Item("desired_qty").ToString
                            beginning_balance = beginning_balance - CDbl(a(9))

                        ElseIf newDR.Item("IN_OUT").ToString = "IN" Then

                            a(4) = newDR.Item("dr_no_invoice_no").ToString
                            a(7) = newDR.Item("SOURCE_WH").ToString
                            a(8) = newDR.Item("desired_qty").ToString
                            a(9) = ""
                            beginning_balance = beginning_balance + CDbl(a(8))

                        End If

                        a(10) = FormatNumber(beginning_balance, 2,,, TriState.True)
                        a(11) = newDR.Item("remarks").ToString

                        dtgStockCard.Rows.Add(a)
proceedhere1:

                    Case 11
                        If newDR.Item("WITHDRAWN").ToString = "NO" Then
                            GoTo proceedhere
                        End If

                        If newDR.Item("stat").ToString = "" And newDR.Item("dr_no").ToString = "" Then
                            GoTo proceedhere

                        ElseIf newDR.Item("stat").ToString = "" And newDR.Item("dr_no").ToString <> "" Then
                            a(4) = newDR.Item("dr_no").ToString
                            a(5) = "N/A"
                            a(6) = "N/A"
                        End If

                        a(2) = Format(Date.Parse(newDR.Item("date").ToString), "MM/dd/yyyy")
                        a(3) = newDR.Item("rs_no").ToString

                        Select Case newDR.Item("stat").ToString
                            Case "IN WITHOUT RS AND DR"
                                a(4) = newDR.Item("dr_no").ToString
                                a(5) = "N/A"
                                a(6) = "N/A"

                            Case "OUT WITHOUT RS AND DR"
                                a(4) = newDR.Item("dr_no").ToString
                                a(5) = "N/A"
                                a(6) = "N/A"

                            Case "IN WITH DR BUT NO RS"
                                a(4) = newDR.Item("dr_no").ToString
                                a(5) = "N/A"
                                a(6) = "N/A"

                            Case "OUT WITH DR BUT NO RS"
                                a(4) = newDR.Item("dr_no").ToString
                                a(5) = "N/A"
                                a(6) = "N/A"

                            Case "IN WITH DR AND WITH RS"
                                a(4) = newDR.Item("dr_no").ToString
                                a(5) = "N/A"
                                a(6) = "N/A"

                            Case "OUT WITH DR AND WITH RS"
                                a(4) = newDR.Item("dr_no").ToString
                                a(5) = "N/A"
                                a(6) = newDR.Item("WS_NO").ToString

                            Case "IN WITH RS AND RR BUT NO DR"
                                a(4) = newDR.Item("INVOICE_NO").ToString
                                a(5) = "rr_no"
                                a(6) = "N/A"

                            Case "OUT WITH RS AND WS BUT NO DR"
                                a(4) = newDR.Item("INVOICE_NO").ToString
                                a(5) = "N/A"
                                a(6) = newDR.Item("WS_NO").ToString

                        End Select

                        a(5) = IIf(newDR.Item("RR_NO").ToString.ToUpper = "", "N/A", newDR.Item("RR_NO").ToString.ToUpper)

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

                                a(10) = FormatNumber(beginning_balance,,, TriState.True)

                            Else
                                a(8) = ""
                                a(9) = newDR.Item("qty_OUT").ToString
                                beginning_balance = beginning_balance - CDbl(newDR.Item("qty_OUT").ToString)
                                a(10) = FormatNumber(beginning_balance,,, TriState.True)

                            End If

                        ElseIf newDR.Item("IN_OUT").ToString = "IN" Then

                            a(8) = newDR.Item("qty_IN").ToString
                            a(9) = ""
                            beginning_balance = beginning_balance + CDbl(a(8))
                            a(10) = FormatNumber(beginning_balance,,, TriState.True)

                        End If

                        a(7) = newDR.Item("SOURCE_WH").ToString
                        a(11) = newDR.Item("remarks").ToString

                        dtgStockCard.Rows.Add(a)

                        If newDR.Item("SORTING").ToString = "A" Then
                            If newDR.Item("type_of_delivery").ToString = "WITHOUT DR" Then
                            Else
                                dtgStockCard.Rows(rowcount).DefaultCellStyle.BackColor = Color.LightBlue
                                dtgStockCard.Rows(rowcount).DefaultCellStyle.ForeColor = Color.Black
                            End If


                        End If

                        rowcount += 1

proceedhere:

                End Select

                'If newDR.Item("dr_option").ToString = "WITH DR" And newDR.Item("DR").ToString = "PARENT DR" Then
                '    GoTo proceedhere
                'End If

                'a(2) = Format(Date.Parse(newDR.Item("DATE_Withdrawn_received").ToString), "MM/dd/yyyy")
                'a(3) = IIf(newDR.Item("rs_no").ToString = "", "N/A", newDR.Item("rs_no").ToString)
                'a(4) = IIf(newDR.Item("dr_no_invoice_no").ToString = "", "N/A", newDR.Item("dr_no_invoice_no").ToString)
                'a(5) = IIf(newDR.Item("rr_no").ToString = "", "N/A", newDR.Item("rr_no").ToString)
                'a(6) = IIf(newDR.Item("WS_no").ToString = "", "N/A", newDR.Item("WS_no").ToString)

                'If newDR.Item("IN_OUT").ToString = "OUT" Then

                '    a(7) = newDR.Item("SOURCE_WH").ToString
                '    a(8) = ""
                '    a(9) = newDR.Item("desired_qty").ToString
                '    beginning_balance = beginning_balance - CDbl(a(9))

                'ElseIf newDR.Item("IN_OUT").ToString = "IN"

                '    a(4) = newDR.Item("dr_no_invoice_no").ToString
                '    a(7) = newDR.Item("SOURCE_WH").ToString
                '    a(8) = newDR.Item("desired_qty").ToString
                '    a(9) = ""
                '    beginning_balance = beginning_balance + CDbl(a(8))

                'End If

                'a(10) = beginning_balance
                'a(11) = newDR.Item("remarks").ToString
                'a(13) = newDR.Item("dr_item_id").ToString




            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Private Delegate Function del_count_qty_dr_using_ws_no(ws_no As String, rs_no As String, n As Integer) As Double
    Public Function count_qty_dr_using_ws_no(ws_no As String, rs_no As String, n As Integer) As Double
        If InvokeRequired Then
            Invoke(New del_count_qty_dr_using_ws_no(AddressOf count_qty_dr_using_ws_no), ws_no, rs_no, n)
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
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Public Function count_qty_dr_using_po_no(po_no As String, rs_no As String) As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 13)
            newCMD.Parameters.AddWithValue("@po_no", po_no)
            newCMD.Parameters.AddWithValue("@rs_no", rs_no)

            newDR = newCMD.ExecuteReader

            While newDR.Read

                If newDR.Item("qty").ToString = "" Then
                    count_qty_dr_using_po_no = 0
                Else
                    count_qty_dr_using_po_no = CDbl(newDR.Item("qty").ToString)
                End If

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Private Delegate Sub del_warehouse_location(wh_id As Integer)
    Private Sub warehouse_location(wh_id As Integer)

        If InvokeRequired Then
            Invoke(New del_warehouse_location(AddressOf warehouse_location), wh_id)
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

            newCMD.Parameters.AddWithValue("@n", 9)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read

                lblitem_name.Text = newDR.Item("ITEM_NAME").ToString
                lbl_location.Text = newDR.Item("LOCATION").ToString
                lblReOrderPoint.Text = newDR.Item("REORDER_POINT").ToString

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Public Sub loading()
        Floading.ShowDialog()

    End Sub

    Public Sub display_stock_card1(n As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim a(20) As String

        dtgStockCard.Rows.Clear()

        lblitem_name.Text = cmbItemName.Text & " - " & cmbItem_desc.Text
        lbl_location.Text = cmbWareHouse.Text
        lblBalance.Text = 0
        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.CommandTimeout = 0
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            Dim wh_id As Integer = get_wh_id_using_wharea(cmbItemName.Text, cmbItem_desc.Text, cmbWareHouse.Text, cmbclassification.Text)
            Dim beginningbalance As Double = get_prev_remaining_balance(wh_id) + get_prev_item_balance(wh_id)

            lblBalance.Text = beginningbalance

            If wh_id = 0 Then
                Exit Sub
            End If

            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newCMD.Parameters.AddWithValue("@date_from", Date.Parse(dtpFrom.Text))
            newCMD.Parameters.AddWithValue("@date_to", Date.Parse(dtpTo.Text))

            newDR = newCMD.ExecuteReader

            While newDR.Read


                lblReOrderPoint.Text = newDR.Item("REDORDERPOINT").ToString

                Dim INOUT As String = newDR.Item("IN_OUT").ToString
                Dim type_of_purchasing = newDR.Item("type_of_purchasing").ToString

                a(3) = newDR.Item("RS_NO").ToString
                a(4) = IIf(newDR.Item("INVOICE_NO").ToString = "", "N/A", UCase(newDR.Item("INVOICE_NO").ToString))
                a(5) = IIf(newDR.Item("RR_NO").ToString = "", "N/A", newDR.Item("RR_NO").ToString)

                If INOUT = "IN" Then
                    If type_of_purchasing = "DR" Then
                        If newDR.Item("DR_ID_PO_DET_ID").ToString = "" Then
                            GoTo proceedhere
                        Else
                            a(2) = Format(Date.Parse(newDR.Item("RR_DR_WS_DATE").ToString), "MM/dd/yyyy")
                            a(4) = UCase(newDR.Item("DR_NO").ToString)
                            a(6) = "N/A"
                            a(7) = newDR.Item("SOURCE_WH").ToString
                            a(8) = newDR.Item("PO_WS_QTY").ToString
                            a(9) = 0

                            beginningbalance = beginningbalance + CDbl(newDR.Item("PO_WS_QTY").ToString)
                        End If

                    Else
                        a(2) = Format(Date.Parse(newDR.Item("RR_DR_WS_DATE").ToString), "MM/dd/yyyy")
                        a(6) = "N/A"
                        a(7) = newDR.Item("SOURCE_SUPPLIER").ToString
                        a(8) = newDR.Item("PARTIALLY_RR").ToString
                        a(9) = 0

                        beginningbalance = beginningbalance + CDbl(newDR.Item("PARTIALLY_RR").ToString)
                    End If

                    a(10) = beginningbalance
                    dtgStockCard.Rows.Add(a)

                ElseIf INOUT = "OUT" Then
                    'MsgBox(newDR.Item("PO_DATE").ToString)

                    'If newDR.Item("PO_DATE").ToString = "" Then
                    '    GoTo proceedhere
                    'End If

                    If newDR.Item("dr_option").ToString = "WITH DR" And newDR.Item("DR_NO").ToString = "" Then
                        GoTo proceedhere
                    End If

                    If type_of_purchasing = "WITHDRAWAL" And newDR.Item("DR_ID_PO_DET_ID").ToString = "" Then

                        'meaning nag out pero walay withdrawal form
                        a(2) = Format(Date.Parse(newDR.Item("PO_DATE").ToString), "MM/dd/yyyy")
                        a(4) = "N/A"
                        a(7) = newDR.Item("SOURCE_WH").ToString

                    ElseIf type_of_purchasing = "WITHDRAWAL" And newDR.Item("DR_ID_PO_DET_ID").ToString <> "" Then

                        'meaning nag out pero naay withdrawal
                        a(2) = Format(Date.Parse(newDR.Item("RR_DR_WS_DATE").ToString), "MM/dd/yyyy")
                        a(4) = UCase(newDR.Item("DR_NO").ToString)
                        a(7) = IIf(newDR.Item("SOURCH_DR").ToString = "", newDR.Item("SOURCE_WH").ToString, newDR.Item("SOURCH_DR").ToString)

                    End If

                    If newDR.Item("WITHDRAWN_ITEM").ToString = "" Then
                        'meaning wala pa na withdraw
                        GoTo proceedhere
                    End If

                    a(5) = "N/A"
                    a(6) = IIf(newDR.Item("PO_WS_NO").ToString = "", "N/A", newDR.Item("PO_WS_NO").ToString)
                    a(8) = 0
                    a(9) = newDR.Item("PO_WS_QTY").ToString

                    beginningbalance = beginningbalance - CDbl(newDR.Item("PO_WS_QTY").ToString)

                    a(10) = beginningbalance
                    dtgStockCard.Rows.Add(a)

                End If

proceedhere:

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Public Function get_prev_remaining_balance(wh_id As Integer) As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 2)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newCMD.Parameters.AddWithValue("@date_prevfrom", Date.Parse("1991-01-01"))
            newCMD.Parameters.AddWithValue("@date_prevto", Date.Parse(dtpFrom.Text).AddDays(-1))

            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim inout As String = newDR.Item("IN_OUT").ToString

                If inout = "IN" Then
                    If newDR.Item("QTY1").ToString = "" Then
                        get_prev_remaining_balance = CDbl(newDR.Item("QTY").ToString)
                    Else
                        get_prev_remaining_balance = CDbl(newDR.Item("QTY1").ToString)
                    End If
                End If


                If inout = "OUT" Then
                    get_prev_remaining_balance = get_prev_remaining_balance - newDR.Item("QTY").ToString
                End If
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
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
            newCMD.Parameters.AddWithValue("@date_prevto", Date.Parse(dtpFrom.Text).AddDays(-1))

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
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Function

    Public Sub display_stock_card(ByVal n As Integer)
        Dim sqlcon As New SQLcon
        Dim dr As SqlDataReader
        Dim cmd As SqlCommand
        Dim prev_bal As Double = 0
        Dim c As Integer = 0
        'cmbItemName.Text, cmbItem_desc.Text, dtpFrom.Text, dtpTo.Text, 
        dtgStockCard.Rows.Clear()
        Dim wh_id As Integer = get_wh_id_using_wharea(cmbItemName.Text, cmbItem_desc.Text, cmbWareHouse.Text, cmbclassification.Text)
        Dim beginningbalance As Double = get_prev_item_balance(wh_id)
        Dim counter As Integer = 0

        Try
            Dim a(20) As String

            sqlcon.connection.Open()
            cmd = New SqlCommand("proc_execute_tempstockcard", sqlcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@n", n)
            cmd.Parameters.AddWithValue("@dateFrom", Date.Parse(dtpFrom.Text))
            cmd.Parameters.AddWithValue("@dateTo", Date.Parse(dtpTo.Text))
            cmd.Parameters.AddWithValue("@item_name", cmbItemName.Text)
            cmd.Parameters.AddWithValue("@item_desc", cmbItem_desc.Text)
            cmd.Parameters.AddWithValue("@wh_area_name", cmbWareHouse.Text)

            dr = cmd.ExecuteReader

            While dr.Read
                c = c + 1
                If c = 1 Then
                    prev_bal = CDbl(Val(dr.Item("previous_balance").ToString))
                End If

                lblitem_name.Text = dr.Item("whItem").ToString & " (" & dr.Item("whItemDesc").ToString & ")"
                'lbl_location.Text = dr.Item("wh_area").ToString & " (" & dr.Item("wh_location").ToString & ")"
                lblReOrderPoint.Text = dr.Item("whReorderPoint").ToString
                'lblBalance.Text = dr.Item("current_balance").ToString


                If counter = 0 Then
                    lblBalance.Text = beginningbalance
                End If

                a(2) = Format(Date.Parse(dr.Item("date_req").ToString), "MM/dd/yyyy")
                a(3) = dr.Item("rs_no").ToString
                'a(7) = charge_to_or_supplier(dr.Item("Supplier_Name").ToString, dr.Item("type_of_charge").ToString)
                a(7) = dr.Item("supplier").ToString

                'prev_bal = prev_bal + CDbl(Val(dr.Item("in_qty").ToString)) - CDbl(Val(dr.Item("out_qty").ToString))
                'a(10) = prev_bal

                a(11) = dr.Item("remarks").ToString

                'If dr.Item("status").ToString = "IN" Then
                a(4) = dr.Item("invoice_no").ToString
                a(5) = dr.Item("receiving_no").ToString
                a(6) = dr.Item("po_no").ToString
                a(8) = dr.Item("in_qty").ToString
                a(9) = dr.Item("out_qty").ToString

                If a(8) > 0 Then
                    beginningbalance += CDbl(a(8))
                ElseIf a(9) > 0 Then
                    beginningbalance -= CDbl(a(9))
                End If

                a(10) = beginningbalance

                'ElseIf dr.Item("status").ToString = "OUT" Then
                'a(4) = "N/A"
                'a(5) = "N/A"
                'a(6) = dr.Item("ws_no").ToString
                'a(8) = "N/A"
                'a(9) = dr.Item("in_out").ToString
                'End If

                dtgStockCard.Rows.Add(a)
                counter += 1

            End While
            dr.Close()


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try
    End Sub

    Private Delegate Function del_get_wh_id_using_wharea(item_name As String, item_desc As String, wh_area As String, classification As String) As Integer
    Public Function get_wh_id_using_wharea(item_name As String, item_desc As String, wh_area As String, classification As String) As Integer
        If InvokeRequired Then
            Invoke(New del_get_wh_id_using_wharea(AddressOf get_wh_id_using_wharea), item_name, item_desc, wh_area, classification)
            Exit Function
        End If

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim query As String = ""

        Dim theclassification As String

        'If cmbclassification.InvokeRequired Then
        '    cmbclassification.Invoke(Sub() theclassification = cmbforClassification.Text)
        'Else
        '    theclassification = cmbforClassification.Text
        'End If

        theclassification = cmbforClassification.Text

        Try
            newSQ.connection.Open()

            If theclassification = "YES" Then

                query = "SELECT a.wh_id,b.wh_area,a.whItem,a.whItemDesc,whClass FROM dbwarehouse_items a "
                query &= "LEFT JOIN dbwh_area b "
                query &= "On b.wh_area_id = a.whArea "
                query &= "WHERE a.whItem = '" & item_name & "' "
                query &= "And a.whItemDesc = '" & item_desc & "' "
                query &= "And b.wh_area = '" & wh_area & "' "
                query &= "And a.whClass = '" & classification & "'"

            ElseIf theclassification = "NO" Then

                query = "SELECT a.wh_id,b.wh_area,a.whItem,a.whItemDesc,whClass FROM dbwarehouse_items a "
                query &= "LEFT JOIN dbwh_area b "
                query &= "On b.wh_area_id = a.whArea "
                query &= "WHERE a.whItem = '" & item_name & "' "
                query &= "And a.whItemDesc = '" & item_desc & "' "
                query &= "And b.wh_area = '" & wh_area & "'"

            End If


            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_wh_id_using_wharea = newDR.Item("wh_id").ToString
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("Error MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
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
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub Panel5_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel5.MouseMove
        If drag Then
            Panel5.Top = Windows.Forms.Cursor.Position.Y - mousey
            Panel5.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Panel5_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel5.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Panel5.Left
        mousey = Windows.Forms.Cursor.Position.Y - Panel5.Top
    End Sub

    Private Sub Panel5_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel5.MouseUp
        drag = False
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)

        'Dim i As Integer = 0

        'If CheckBox1.Checked = True Then
        '    For i = 0 To dtgStockCard.RowCount - 1
        '        dtgStockCard.Rows(i).Cells(1).Value = True
        '    Next
        'Else
        '    For i = 0 To dtgStockCard.RowCount - 1
        '        dtgStockCard.Rows(i).Cells(1).Value = False
        '    Next
        'End If

    End Sub


    Private Sub cmb_GotFocus(sender As Object, e As EventArgs) Handles cmbItem_desc.GotFocus, cmbItemName.GotFocus, cmbWareHouse.GotFocus, cmbclassification.GotFocus
        sender.DroppedDown = True
    End Sub

    Private Sub cmb_Leave(sender As Object, e As EventArgs) Handles cmbItem_desc.Leave, cmbItemName.Leave, cmbWareHouse.Leave, cmbclassification.Leave
        sender.DroppedDown = False
    End Sub

    Private Sub cmbforClassification_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbforClassification.SelectedIndexChanged
        If cmbforClassification.Text = "YES" Then
            cmbclassification.Enabled = True
        ElseIf cmbforClassification.Text = "NO" Then
            cmbclassification.Enabled = False
        End If
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub cmbItem_desc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbItem_desc.SelectedIndexChanged

    End Sub

    Private Sub OoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OoutToolStripMenuItem.Click
        Dim Sout As Double

        For Each row As DataGridViewRow In dtgStockCard.Rows
            If row.Cells("Column8").Value = "" Then
                Sout = Sout + 0
            Else
                If row.DefaultCellStyle.BackColor = Color.LightBlue Then
                    If IsNumeric(row.Cells("Column8").Value) = True Then
                        Sout = Sout + CDbl(row.Cells("Column8").Value)
                    Else
                        'MsgBox(row.Cells("Column8").Value)
                    End If
                Else
                    Sout = Sout + IIf(Not IsNumeric(row.Cells("Column8").Value), 0, row.Cells("Column8").Value)
                End If

            End If
        Next

        MsgBox(Sout)
    End Sub

    Private Sub InToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InToolStripMenuItem.Click
        Dim Sin As Double

        For Each row As DataGridViewRow In dtgStockCard.Rows
            If row.Cells("Column7").Value = "" Then
                Sin = IIf(Not IsNumeric(Sin), 0, Sin) + 0
            Else
                Sin = Sin + IIf(Not IsNumeric(row.Cells("Column7").Value), 0, row.Cells("Column7").Value)
            End If
        Next

        MsgBox(Sin)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOptions.SelectedIndexChanged
        If cmbOptions.Text = "Search by StockCard" Then
            cmbItemName.Enabled = True
            cmbItem_desc.Enabled = True
            cmbWareHouse.Enabled = True
        Else
            'cmbItemName.Enabled = False
            'cmbItem_desc.Enabled = False
            'cmbWareHouse.Enabled = True

        End If
    End Sub

    Private Sub TableLayoutPanel3_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel3.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        'MsgBox(display_stock_card3(11))
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not thread.IsAlive Then
            Timer1.Stop()
            PictureBox1.Visible = False
            Label6.Visible = False
        End If
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub



    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        initialize_dr()

        For Each thread In cListOfThread
            thread.Join()
        Next

        merge_dr_data()
        execute_sorted_dr()



    End Sub
    Private Delegate Sub del_initialize_previous_balance()

    Private Sub _initialize_previous_balance()
        If InvokeRequired Then
            Invoke(New del_initialize_previous_balance(AddressOf _initialize_previous_balance))
            Exit Sub
        End If

        cnewDr2.cListOfdrqty.Clear()
        cNewWs2.cListOfWs_qty.Clear()
        cNewListOfDrQty.Clear()

        Dim listofthreading As New List(Of Threading.Thread)

        cnewDr2._initialize_previous_balance(Date.Parse("1990-01-01"), Date.Parse(dtpFrom.Text).AddDays(-1), "WH_ID",,, cWh_id)
        listofthreading.Add(cnewDr2.trd4)

        cNewWs2._initialize_previous_balance(Date.Parse("1990-01-01"), Date.Parse(dtpFrom.Text).AddDays(-1), "WH_ID",,, cWh_id)
        listofthreading.Add(cNewWs2.trd3)


        For Each tr In listofthreading
            tr.Join()
        Next

        merge_dr_data_qty()

        cPreviousbalance = calc_remaining_balance()
        lblBalance.Text = cPreviousbalance

        BackgroundWorker1.RunWorkerAsync()


    End Sub
    Private Delegate Function del_calc_remaining_balance()
    Private Function calc_remaining_balance() As Double
        calc_remaining_balance = 0
        calc_remaining_balance = cPreviousbalance

        If InvokeRequired Then
            Invoke(New del_calc_remaining_balance(AddressOf calc_remaining_balance))
            Exit Function
        End If

        Dim ListOfDrQty = Nothing
        Dim drqty = cNewListOfDrQty

        ListOfDrQty = From row In drqty Select row.dDate, row.dQty, row.inout Order By dDate Ascending

        For Each row In ListOfDrQty
            If row.inout = "OUT" Then
                calc_remaining_balance -= row.dQty
            ElseIf row.inout = "IN" Then
                calc_remaining_balance += row.dQty
            End If
        Next

        Return calc_remaining_balance
    End Function

    Private Delegate Sub del_initialize_dr()
    Private Sub initialize_dr()

        If InvokeRequired Then
            Invoke(New del_initialize_dr(AddressOf initialize_dr))
            Exit Sub
        End If

        cNewDr.cListOfDr.Clear()
        cNewWs.cListOfWs.Clear()


        Dim datefrom As DateTime = dtpFrom.Text
        Dim dateto As DateTime = dtpTo.Text

        cNewDr._initialize(Date.Parse(datefrom), Date.Parse(dateto), "WH_ID",,, cWh_id)
        cListOfThread.Add(cNewDr.trd)

        cNewWs._initialize(Date.Parse(datefrom), Date.Parse(dateto), "WH_ID",,, cWh_id)
        cListOfThread.Add(cNewWs.trd)

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
        For Each row In cNewDr.cListOfDr
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
                .ws_po_no = IIf(row.inout = "OUT", row.ws_no, row.po_no)
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
                cNewListOfDr.Add(newD)
            End With
        Next
        'Add withdrawal withour dr
        For Each row As class_ws.ws In cNewWs.cListOfWs
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

                .remarks = row.remarks
                .user = row.users
                .inout = row.inout
                .dr_option = row.dr_option

                cNewListOfDr.Add(newD)
            End With
        Next


    End Sub

    Private Sub merge_dr_data_qty()

        If InvokeRequired Then
            Invoke(New del_merge_dr_data(AddressOf merge_dr_data_qty))
            Exit Sub
        End If

        Dim newD_qty As New stock_card_qty_list

        'ADD dr qty to cNewListOfDrQty list 
        Dim dr_qty_list = cnewDr2.cListOfdrqty

        For Each row In dr_qty_list
            With newD_qty
                .dDate = row.dr_date
                .dQty = row.dr_qty
                .inout = row.inout
            End With

            cNewListOfDrQty.Add(newD_qty)
        Next

        newD_qty = New stock_card_qty_list

        'add ws qty without dr to cNewListOfDrQty list 
        Dim ws_qty_list = cNewWs2.cListOfWs_qty

        For Each row In ws_qty_list
            With newD_qty
                .dDate = row.ws_date
                .dQty = row.ws_qty
                .inout = row.inout
            End With

            cNewListOfDrQty.Add(newD_qty)
        Next

    End Sub

    Private Sub BackgroundWorker4_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker4.DoWork
        Dim t As Threading.Thread

        t = New Threading.Thread(AddressOf bb)
        t.Start()

    End Sub


    Private Sub bb()
        Try
            Dim tt As Threading.Thread
            tt = New Threading.Thread(AddressOf NewStockCard.try_lng)
            tt.Start()
            tt.Join()

            Dim listofqty = NewStockCard.cListOfQty
            cBalance = cprevBalance

            'For Each row In listofqty
            '    If row.inout = "OUT" Then
            '        If IsNumeric(row.qty_out) Then
            '            cBalance -= CDbl(row.qty_out)
            '        Else
            '            Dim sp() As String = row.qty_out.ToString.Split("/")

            '            If CDbl(sp(0)) < CDbl(sp(1)) Then
            '                cBalance -= (CDbl(sp(1)) - CDbl(sp(0)))
            '            End If
            '        End If

            '    ElseIf row.inout = "IN" Then
            '        cBalance += CDbl(row.qty_in)
            '    End If
            'Next

            Dim qty_out, qty_in As Double
            For Each row In listofqty
                If row.inout = "OUT" Then
                    If IsNumeric(row.qty_out) Then
                        qty_out += CDbl(CStr(row.qty_out))
                    Else
                        Dim sp() As String = row.qty_out.ToString.Split("/")

                        If CDbl(sp(0)) < CDbl(sp(1)) Then
                            qty_out += CDbl(CStr((CDbl(sp(1)) - CDbl(sp(0)))))

                        End If
                    End If
                End If

                If row.inout = "IN" Then
                    qty_in += row.qty_in
                End If
            Next

            cBalance = FormatNumber((cprevBalance + qty_in) - CDbl(CStr(qty_out)), 2,,, TriState.False)

            'If lblBalance.InvokeRequired Then
            '    lblBalance.Invoke(Sub()

            '                          lblBalance.Text = CDbl(cBalance)
            '                          trig2 = True
            '                          final_generating_balance()
            '                      End Sub)
            'End If

            trig2 = True
            final_generating_balance()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Delegate Sub del_final()

    Private Sub final()
        If InvokeRequired Then
            Invoke(New del_final(AddressOf final))
            Exit Sub
        End If


        'While True
        '    'Application.DoEvents()
        '    Threading.Thread.Sleep(500)

        'End While

        For i = 0 To 200
            Threading.Thread.Sleep(1000)
        Next

        Label6.Text = "Successfully Generated..."
        PictureBox1.Visible = False
        trig = False
        'trig2 = False


        'final_generating_balance()
    End Sub

    Private Sub bw_get_agg_data_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw_get_agg_data.DoWork

        NewStockCard1.aggregates_data(cWh_id, cDateFrom, cDateTo)

    End Sub

    Private Sub bw_initialize_qty_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw_initialize_qty.DoWork
        'NewStockCard2._initialize_qty(cWh_id, cDateFrom, cDateTo)

    End Sub

    Private Delegate Sub del_execute_sorted_dr()

    Private Sub bw_prev_balance_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw_prev_balance.DoWork

        NewStockCard3.wh_id = cWh_id
        NewStockCard3.prev_balance()
    End Sub

    Private Sub bw_check_if_done_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw_check_if_done.DoWork
        check_if_done_process()
    End Sub
    Private Sub check_if_done_process()
        While True
            If r1 = True And r3 = True And r4 = True And r5 = True Then
                Exit While
            End If
        End While
    End Sub
    Private Sub execute_sorted_dr()
        If InvokeRequired Then
            Invoke(New del_execute_sorted_dr(AddressOf execute_sorted_dr))
            Exit Sub
        End If

        Dim ListOfDr = Nothing
        Dim dr = cNewListOfDr

        ListOfDr = From row In dr Select row.dr_item_id, row.dr_no, row.rs_no,
                                   row.dr_date, row.item_name, row.source,
                                   row.dr_qty, row.unit, row.concession_ticket, row.driver,
                                   row.requestor, row.checked_by, row.received_by, row.rs_id,
                                   row.inout, row.ws_po_no, row.remarks, row.supplier, row.user,
                                   row.plateno, row.price, row.item_desc, row.dr_option, row.withdrawn_by,
                                   row.rr_no, row.date_request Order By dr_date, inout, rs_id, ws_po_no  'dr_date, dr_item_id Ascending

        'order by aa.date,aa.IN_OUT,aa.rs_id,aa.WS_NO

        Dim dgrow As New List(Of DataGridViewRow)
        dtgStockCard.Rows.Clear()

        Dim balance As Double = cPreviousbalance


        Dim i As Integer = 0
        Dim a(10) As String
        For Each row In ListOfDr

            If row.inout = "OUT" Then
                balance = balance - row.dr_qty
            ElseIf row.inout = "IN" Then
                balance += row.dr_qty
            End If

            Dim rows() As String = {row.dr_item_id, Nothing,
                                        row.dr_date,
                                        row.rs_no,
                                        row.dr_no,
                                        row.rr_no,
                                        row.ws_po_no,
                                        row.requestor,
                                        IIf(row.inout = "OUT", "", row.dr_qty),
                                        IIf(row.inout = "OUT", row.dr_qty, ""),
                                        balance,
                                        row.remarks
                                    }


            'a(0) = 0
            'a(2) = row.dr_date
            'a(3) = row.rs_no

            dtgStockCard.Rows.Add(rows)
        Next

        'dtgStockCard.Rows.AddRange(dgrow.ToArray())
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        'With FListOfItems
        '    button_click_name = "forstockcard"

        '    .cmboptions.Text = "HAULING AND CRUSHING"
        '    .cmboptions.Enabled = False

        '    .ShowDialog()

        'End With

        With fl
            button_click_name = "forstockcard"
            .cmboptions.Text = "HAULING AND CRUSHING"
            .cmboptions.Enabled = False
            .ShowDialog()

        End With
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs)
        MsgBox(cWh_id & vbCrLf & cDateFrom & vbCrLf & cDateTo)
    End Sub

    Private Sub bw_close_all_forms_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw_close_all_forms.DoWork
        'Label6.Visible = False

        'fl.fd.PictureBox1.Visible = False
        'fl.fd.Close()
        'fl.Close()

        'PictureBox1.Visible = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        If cnewDr2.trd.IsAlive Then
            MsgBox("it is alive")
        End If
    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork

        Dim newTRd As Threading.Thread
        newTRd = New Threading.Thread(AddressOf _initialize_previous_balance)
        newTRd.Start()

    End Sub

    Private Sub BackgroundWorker3_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker3.DoWork

        trd = New Threading.Thread(AddressOf get_stock_card_for_hauling)
        trd.Start()

    End Sub

    Private Sub bw_prev_balance2_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw_prev_balance2.DoWork

        'GET DATA FROM PREVIOUS BALANCE
        Dim datefrom As DateTime = Date.Parse("1990-01-01")
        Dim dateto As DateTime = cDateFrom.AddDays(-1)

        NewStockCard4.aggregates_data(cWh_id, datefrom, dateto)
    End Sub

    Private Sub bw_get_agg_data_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw_get_agg_data.RunWorkerCompleted
        r1 = True
    End Sub

    Private Sub bw_initialize_qty_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw_initialize_qty.RunWorkerCompleted
        r2 = True
    End Sub

    Private Sub bw_prev_balance_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw_prev_balance.RunWorkerCompleted
        r3 = True
    End Sub


    Private Function newListOfStockCard(stockcarddata As class_agg_remaining_balance, prev_bal As Double)
        'Private Sub arrange_data()

        newListOfStockCard = New class_agg_remaining_balance

        '2. time to arrange
        Dim list = stockcarddata.cListOfStockCard

        Dim counter As Integer
        Dim b As Double
        newListOfStockCard.cListOfStockCard.Clear()

        For Each row In list
            'If row.inout = "OTHERS" Or row.inout = "" Then
            '    GoTo proceedhere
            'End If

            Dim aa As New class_agg_remaining_balance.agg_data
            With aa
                aa.drdate = row.drdate
                aa.rs_no = row.rs_no
                aa.drno_invoice = row.drno_invoice
                aa.rr_no = row.rr_no
                aa.ws_no = row.ws_no
                aa.supp_recipient = row.supp_recipient
                aa.qty_in = row.qty_in
                aa.qty_out = row.qty_out
                aa.inout = row.inout
                aa.type_of_purchasing = row.type_of_purchasing
                aa.sorting = row.sorting
                aa.remarks = row.remarks
                aa.type_of_delivery = row.type_of_delivery
                aa.stat = row.stat

                If counter = 0 Then
                    If row.inout = "OUT" Then
                        Dim out As Double

                        If IsNumeric(row.qty_out) Then
                            out = row.qty_out
                        Else
                            Dim sp() As String = row.qty_out.Split("/")

                            If CDbl(sp(0)) < CDbl(sp(1)) Then
                                out = (CDbl(sp(1)) - CDbl(sp(0)))
                            Else
                                out = 0
                            End If
                        End If

                        aa.balance = prev_bal - out

                    ElseIf row.inout = "IN" Then
                        aa.balance = prev_bal + row.qty_in

                    ElseIf row.inout = "OTHERS" Then
                        aa.balance = prev_bal + row.qty_in
                    End If

                    b = aa.balance
                Else
                    If row.inout = "OUT" Then
                        Dim out As Double

                        If IsNumeric(row.qty_out) Then
                            out = row.qty_out
                        Else
                            Dim sp() As String = row.qty_out.Split("/")

                            If CDbl(sp(0)) < CDbl(sp(1)) Then
                                out = (CDbl(sp(1)) - CDbl(sp(0)))
                            Else
                                out = 0
                            End If
                        End If

                        aa.balance = b - Math.Abs(out)

                    ElseIf row.inout = "IN" Then
                        aa.balance = b + row.qty_in

                    ElseIf row.inout = "OTHERS" Then
                        aa.balance = b + row.qty_in

                    End If

                    b = aa.balance
                End If

                newListOfStockCard.cListOfStockCard.Add(aa)
            End With
            counter += 1
proceedhere:
        Next

    End Function

    Private Sub bw_check_if_done_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw_check_if_done.RunWorkerCompleted
        'MsgBox("done")

        'MsgBox("PREVIOUS:" & NewStockCard4.cListOfStockCard.Count)
        'MsgBox("CURRENT:" & NewStockCard1.cListOfStockCard.Count)

        'FDATERANGE.Close()
        'FListOfItems.Close()

        PictureBox1.Visible = False
        abcdefg()
    End Sub

    Private Sub abcdefg()
        Try
            '1. GET THE prev balance kadtong gkan sa excel sauna
            Dim prev_bal As Double = NewStockCard3.my_prev_balance

            '2. GET THE prev balance (ex: 2014-01-01 to 2021-12-31 | ang sa display sa gridview 2022-01-01 to 2022-11-04 depende sa imong range
            ' arrange sa first ang balance 
            Dim aggdata2 = newListOfStockCard(NewStockCard4, prev_bal)
            Dim list = aggdata2.cListOfStockCard

            'kwaon dayon ang last balance
            Dim prev_bal2 As Double
            If aggdata2.cListOfStockCard.count = 0 Then
                'og walay sulod ang listofstockcard ibalik ang prevbal gkan sa excel
                prev_bal2 = prev_bal
            Else
                For Each row In list
                    prev_bal2 = row.balance
                Next
            End If

            'last previous balance
            lblBalance.Text = prev_bal2


            '3. ang sa gridview nga data ex: 2022-01-01 to 2022-11-04 depende sa imong ge search
            'arrange balance
            Dim aggdata = newListOfStockCard(NewStockCard1, prev_bal2)
            Dim list2 = aggdata.cListOfStockCard

            '4. display
            Dim counter As Integer = 0

            For Each row In list2
                Dim a(13) As String

                a(2) = Date.Parse(row.drdate)
                a(3) = row.rs_no
                a(4) = row.drno_invoice
                a(5) = row.rr_no
                a(6) = row.ws_no
                a(7) = row.supp_recipient
                a(8) = IIf(row.qty_in = "0", "-", row.qty_in)
                a(9) = IIf(row.qty_out = "0", "-", row.qty_out)
                a(10) = FormatNumber(row.balance, 2,,, TriState.True)
                a(11) = row.remarks
                a(13) = row.inout

                dtgStockCard.Rows.Add(a)

                If row.sorting = "A" Then
                    If row.type_of_delivery = "WITHOUT DR" Then
                    Else
                        dtgStockCard.Rows(counter).DefaultCellStyle.BackColor = Color.LightBlue
                        dtgStockCard.Rows(counter).DefaultCellStyle.ForeColor = Color.Black
                    End If
                End If
                'If row.sorting = "A" Then
                '    dtgStockCard.Rows(counter).DefaultCellStyle.BackColor = Color.LightBlue
                'End If
                counter += 1

            Next

            '5 display warehouse location
            lblitem_name.Text = wh_loc.item_name
            lbl_location.Text = wh_loc.location
            lblReOrderPoint.Text = wh_loc.reoderpoint

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            PictureBox2.Visible = False
            Label6.Text = "Successfully Generated..."
        End Try

    End Sub

    Private Function Mybalance(list As class_agg_remaining_balance)

    End Function
    Private Sub bw_prev_balance2_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw_prev_balance2.RunWorkerCompleted
        r4 = True
    End Sub
End Class