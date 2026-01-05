Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FPreviousStockCard
    Public SQ As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader

    Dim x As Integer
    Dim n As Integer = 0
   
    Dim operatorCancel As Boolean = False

    Public Sub DeleteRecord_PreviousStockCard()
        Dim newSQ As New SQLcon
        n = Val(lvList.SelectedItems(0).Text)

        Try
            newSQ.connection.Open()
            Dim sqlComm As New SqlCommand

            sqlComm.Connection = newSQ.connection
            sqlComm.CommandText = "sp_crud_PreviousStockCard"
            sqlComm.CommandType = CommandType.StoredProcedure
            sqlComm.Parameters.AddWithValue("@psc_id", n)
            sqlComm.Parameters.AddWithValue("@n", 3)
            x = n + 1

            sqlComm.ExecuteNonQuery()



        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    
    Public Sub load_PreviousStockCard()
        lvList.Items.Clear()

        Dim newsq1 As New SQLcon
        Dim newdr1 As SqlDataReader
        Dim newcmd As SqlCommand

        Try

            newsq1.connection.Open()

            newcmd = New SqlCommand("sp_load_PreviousStockCard", newsq1.connection)
            newcmd.Parameters.Clear()
            newcmd.CommandType = CommandType.StoredProcedure

            newdr1 = newcmd.ExecuteReader
            While newdr1.Read
                Dim a(20) As String

                a(0) = newdr1.Item("psc_id").ToString
                a(1) = Format(Date.Parse(newdr1.Item("date_previous").ToString), "MM/dd/yyyy")
                a(2) = newdr1.Item("rs_no").ToString
                a(3) = newdr1.Item("invoice_no").ToString
                a(4) = newdr1.Item("receiving_no").ToString
                a(5) = newdr1.Item("ws_no").ToString
                a(6) = newdr1.Item("typeRequest").ToString
                a(7) = newdr1.Item("status").ToString
                a(8) = charge_to_or_supplier(newdr1.Item("supplier_reciepient").ToString, newdr1.Item("type_of_charge").ToString)
                'a(8) = CHARGE_TO(newdr.Item("supplier_reciepient").ToString, newdr.Item("typeRequest").ToString, newdr.Item("status").ToString)
                a(9) = GET_ITEM_DESC(newdr1.Item("wh_id").ToString, 1)
                a(10) = GET_ITEM_DESC(newdr1.Item("wh_id").ToString, 2)
                a(11) = newdr1.Item("in_out").ToString
                a(12) = newdr1.Item("balance").ToString
                a(13) = newdr1.Item("remarks").ToString
                a(14) = newdr1.Item("type_of_charge").ToString
                a(15) = newdr1.Item("type_of_purchase").ToString
                a(16) = newdr1.Item("tor_sub_id").ToString

                Dim lvl As New ListViewItem(a)
                lvList.Items.Add(lvl)
            End While
            newdr1.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsq1.connection.Close()
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

            ElseIf type_of_charge_or_supplier = "ADFIL" Then
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

    Public Function GET_ITEM_DESC(ByVal parse_wh_id As Integer, ByVal n As Integer)
        Dim newsq As New SQLcon
        Dim newdr As SqlDataReader

        Try
            newsq.connection.Open()
            publicquery_Psc = "SELECT * FROM dbwarehouse_items WHERE wh_id = " & parse_wh_id
            cmd = New SqlCommand(publicquery_Psc, newsq.connection)
            newdr = cmd.ExecuteReader
            While newdr.Read
                If n = 1 Then
                    GET_ITEM_DESC = newdr.Item("whItem").ToString
                ElseIf n = 2 Then
                    GET_ITEM_DESC = newdr.Item("whItemDesc").ToString
                End If

            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsq.connection.Close()

        End Try
    End Function
    Public Sub clear_PreviousStockCardFinal()
        With FPreviousStackCardFinal
            .cmbTypeofCharge.Text = Nothing
            .cmbInOut.Text = Nothing
            .cmbTypeOfPurchase.Text = Nothing
            .cmbTypeofCharge.Text = Nothing
            .txtChargeTo.Text = ""
            .cmbCharges.Text = Nothing
            .DTP_PreviousStockcard.Text = ""
            .txtRSno.Text = ""
            .txtItemDesc.Text = ""
            .txt_item_name.Text = ""
            .txtInvoice.Text = ""
            .txt_Receiving_no.Text = ""
            .txt_Ws_no.Text = ""
            .txtIn_out.Text = ""
            .txtBalance.Text = ""
            .txtRemarks.Text = ""
        End With

    End Sub
    Private Sub SearchRecord_PreviousStockCard(ByVal n As Integer)
        'lvList.Items.Clear()

        'Dim newSQ As New SQLcon
        'Dim sqlComm As New SqlCommand()
        'Dim newdr As SqlDataReader

        'Try
        '    newSQ.connection.Open()

        '    sqlComm.Connection = newSQ.connection
        '    sqlComm.CommandText = "sp_crud_PreviousStockCard"
        '    sqlComm.CommandType = CommandType.StoredProcedure
        '    sqlComm.Parameters.AddWithValue("@n", 12)
        '    'If cmbSearchByCategory.Text = "Rs_no" Then
        '    '    sqlComm.Parameters.AddWithValue("@rs_no", txtSearch.Text)
        '    '    sqlComm.Parameters.AddWithValue("@n", 4)
        '    'ElseIf cmbSearchByCategory.Text = "Invoice_no" Then
        '    '    sqlComm.Parameters.AddWithValue("@invoice_no", txtSearch.Text)
        '    '    sqlComm.Parameters.AddWithValue("@n", 5)
        '    'ElseIf cmbSearchByCategory.Text = "Receiving_no" Then
        '    '    sqlComm.Parameters.AddWithValue("@receiving_no", txtSearch.Text)
        '    '    sqlComm.Parameters.AddWithValue("@n", 6)
        '    'ElseIf cmbSearchByCategory.Text = "Ws_no" Then
        '    '    sqlComm.Parameters.AddWithValue("@Ws_no", txtSearch.Text)
        '    '    sqlComm.Parameters.AddWithValue("@n", 7)
        '    'ElseIf cmbSearchByCategory.Text = "Item_name" Or cmbSearchByCategory.Text = "Item Desc" Then
        '    '   sqlComm.Parameters.AddWithValue("@search", txtSearch.Text)
        '    '    sqlComm.Parameters.AddWithValue("@n", 8)
        '    'ElseIf cmbSearchByCategory.Text = "Date" Then
        '    '    sqlComm.Parameters.AddWithValue("@date_previous", Date.Parse(DTP_PSC.Text))
        '    '    sqlComm.Parameters.AddWithValue("@n", 9)
        '    ' End If

        '    'If n = 1 Then
        '    '    sqlComm.Parameters.AddWithValue("@rs_no", txtSearch.Text)
        '    '    sqlComm.Parameters.AddWithValue("@n", 4)
        '    'End If

        '    newdr = sqlComm.ExecuteReader
        '    '   If newdr.HasRows Then
        '    While newdr.Read

        '        Dim a(20) As String

        '        a(0) = newdr.Item("psc_id").ToString
        '        a(1) = Format(Date.Parse(newdr.Item("date_previous").ToString), "MM/dd/yyyy")
        '        a(2) = newdr.Item("rs_no").ToString
        '        a(3) = newdr.Item("invoice_no").ToString
        '        a(4) = newdr.Item("receiving_no").ToString
        '        a(5) = newdr.Item("ws_no").ToString
        '        a(6) = newdr.Item("typeRequest").ToString
        '        a(7) = newdr.Item("status").ToString
        '        a(8) = charge_to_or_supplier(newdr.Item("supplier_reciepient").ToString, newdr.Item("type_of_charge").ToString)
        '        a(9) = get_whItem(newdr.Item("wh_id").ToString)
        '        a(10) = get_whItemDesc(newdr.Item("wh_id").ToString)
        '        'If cmbSearchByCategory.Text = "Item_name" Or cmbSearchByCategory.Text = "Item Desc" Then
        '        '    a(9) = newdr.Item("whItem").ToString
        '        '    a(10) = newdr.Item("whItemDesc").ToString
        '        'Else
        '        '    a(9) = GET_ITEM_DESC(newdr.Item("wh_id").ToString, 1)
        '        '    a(10) = GET_ITEM_DESC(newdr.Item("wh_id").ToString, 2)
        '        'End If
        '        a(11) = newdr.Item("in_out").ToString
        '        a(12) = newdr.Item("balance").ToString
        '        a(13) = newdr.Item("remarks").ToString

        '        '                    If cmbSearchByCategory.Text = "Rs_no" Then
        '        '                        If search_by1(a(2), txtSearch.Text) = True Then
        '        '                        Else
        '        '                            GoTo anhidrea

        '        '                        End If

        '        '                    End If


        '        '                    Dim lvl As New ListViewItem(a)
        '        '                    lvList.Items.Add(lvl)
        '        'anhidrea:
        '    End While
        '    ' End If

        '    newdr.Close()

        'Catch ex As Exception
        '    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Finally
        '    newSQ.connection.Close()
        'End Try

        lvList.Items.Clear()

        Dim newsq1 As New SQLcon
        Dim newdr1 As SqlDataReader
        Dim newcmd As SqlCommand

        Try

            newsq1.connection.Open()

            newcmd = New SqlCommand("sp_crud_PreviousStockCard", newsq1.connection)
            newcmd.Parameters.Clear()
            newcmd.CommandType = CommandType.StoredProcedure

            If n = 1 Then
                newcmd.Parameters.AddWithValue("@rs_no", txtSearch.Text)
                newcmd.Parameters.AddWithValue("@n", 4)
            ElseIf n = 2 Then
                newcmd.Parameters.AddWithValue("@invoice_no", txtSearch.Text)
                newcmd.Parameters.AddWithValue("@n", 5)
            ElseIf n = 3 Then
                newcmd.Parameters.AddWithValue("@receiving_no", txtSearch.Text)
                newcmd.Parameters.AddWithValue("@n", 6)
            ElseIf n = 4 Then
                newcmd.Parameters.AddWithValue("@Ws_no", txtSearch.Text)
                newcmd.Parameters.AddWithValue("@n", 7)
            ElseIf n = 5 Then
                newcmd.Parameters.AddWithValue("@search", txtSearch.Text)
                newcmd.Parameters.AddWithValue("@n", 8)
            ElseIf n = 6 Then
                newcmd.Parameters.AddWithValue("@date_previous", Date.Parse(DTP_PSC.Text))
                newcmd.Parameters.AddWithValue("@n", 9)
            End If
            'newcmd.Parameters.AddWithValue("@n", 12)
            newdr1 = newcmd.ExecuteReader
            While newdr1.Read
                Dim a(20) As String

                a(0) = newdr1.Item("psc_id").ToString
                a(1) = Format(Date.Parse(newdr1.Item("date_previous").ToString), "MM/dd/yyyy")
                a(2) = newdr1.Item("rs_no").ToString
                a(3) = newdr1.Item("invoice_no").ToString
                a(4) = newdr1.Item("receiving_no").ToString
                a(5) = newdr1.Item("ws_no").ToString
                a(6) = newdr1.Item("typeRequest").ToString
                a(7) = newdr1.Item("status").ToString
                a(8) = charge_to_or_supplier(newdr1.Item("supplier_reciepient").ToString, newdr1.Item("type_of_charge").ToString)
                'a(8) = CHARGE_TO(newdr.Item("supplier_reciepient").ToString, newdr.Item("typeRequest").ToString, newdr.Item("status").ToString)
                If n = 5 Then
                    a(9) = newdr1.Item("whItem").ToString
                    a(10) = newdr1.Item("whItemDesc").ToString
                Else
                    a(9) = GET_ITEM_DESC(newdr1.Item("wh_id").ToString, 1)
                    a(10) = GET_ITEM_DESC(newdr1.Item("wh_id").ToString, 2)
                End If
                a(11) = newdr1.Item("in_out").ToString
                a(12) = newdr1.Item("balance").ToString
                a(13) = newdr1.Item("remarks").ToString
                a(14) = newdr1.Item("type_of_charge").ToString
                a(15) = newdr1.Item("type_of_purchase").ToString
                a(16) = newdr1.Item("tor_sub_id").ToString
                a(17) = newdr1.Item("wh_area").ToString
                a(18) = newdr1.Item("wh_id").ToString

                Dim lvl As New ListViewItem(a)
                lvList.Items.Add(lvl)
            End While
            newdr1.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsq1.connection.Close()
        End Try

    End Sub
    Public Function get_whItemDesc(ByVal x As Integer) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim query As String

        Try
            newSQ.connection.Open()
            query = "select whItemDesc from dbwarehouse_items where wh_id = '" & x & "'"
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_whItemDesc = newDR.Item(0).ToString
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Function get_whItem(ByVal x As Integer) As String

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim query As String

        Try
            newSQ.connection.Open()
            query = "select whItem from dbwarehouse_items where wh_id = '" & x & "'"
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_whItem = newDR.Item(0).ToString
            End While
            newDR.Close()


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    'Private Sub FPreviousStockCard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    '    btnExit.Parent = pboxHeader
    '    btnExit.BringToFront()
    '    ' load_PreviousStockCard()

    '    'Dim index As Integer = lvList.Items.Count - 1
    '    'lvList.Items(index).Selected = True
    '    'lvList.Items(index).EnsureVisible()

    '    cmbSearchByCategory.Text = "Rs_no"
    '    'With FPreviousStackCardFinal
    '    '    .load_cmbTypeofRequest()
    '    'End With

    'End Sub


    Private Sub pboxHeader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pboxHeader.Click

    End Sub

    Private Sub FPreviousStockCard_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown

    End Sub

    Private Sub FPreviousStockCard_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove

    End Sub

    Private Sub FPreviousStockCard_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp

    End Sub
    Public Sub load_cmbTypeofRequest()
        With FPreviousStackCardFinal
            .cmbRequestType.Items.Clear()
        End With

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim query As String
        Try
            newSQ.connection.Open()
            query = "SELECT tor_desc FROM dbType_of_Request "
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                With FPreviousStackCardFinal
                    .cmbRequestType.Items.Add(newDR.Item(0).ToString)
                End With
            End While
            newDR.Close()


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        'clear_PreviousStockCardFinal()
        'load_cmbTypeofRequest()
        FPreviousStackCardFinal.Show()
        get_data_from_dbPreviouStockCard(lvList.SelectedItems(0).SubItems(0).Text)

    End Sub
    Public Sub get_data_from_dbPreviouStockCard(ByVal psc_id As Integer)
        lvList.Enabled = True
        Try
            SQ.connection.Open()
            publicquery = "Select * from dbPrevious_stock_card WHERE psc_id = '" & psc_id & "' "
            cmd = New SqlCommand(publicquery, SQ.connection)
            dr = cmd.ExecuteReader

            While dr.Read
                With FPreviousStackCardFinal

                    Dim tor_id As Integer = get_tor_id(dr.Item("tor_sub_id").ToString)
                    Dim tor_sub_desc As String = show_tor_sub_desc(dr.Item("tor_sub_id").ToString)
                    .btnSave.Text = "Update"
                    .cmbRequestType.Text = get_type_of_request(tor_id)
                    .cmbSubTypeofRequest.Text = tor_sub_desc
                    .cmbInOut.Text = dr.Item("status").ToString
                    .cmbTypeOfPurchase.Text = dr.Item("type_of_purchase").ToString
                    .cmbTypeofCharge.Text = dr.Item("type_of_charge").ToString
                    .txtChargeTo.Text = charge_to_or_supplier(dr.Item("supplier_reciepient").ToString, dr.Item("type_of_charge").ToString)
                    .cmbChargeTo.Text = charge_to_or_supplier(dr.Item("supplier_reciepient").ToString, dr.Item("type_of_charge").ToString)
                    .DTP_PreviousStockcard.Text = dr.Item("date_previous").ToString
                    .txtRSno.Text = dr.Item("rs_no").ToString
                    .txtItemDesc.Text = GET_ITEM_DESC(dr.Item("wh_id").ToString, 2)
                    .txt_item_name.Text = GET_ITEM_DESC(dr.Item("wh_id").ToString, 1)
                    .txtInvoice.Text = dr.Item("invoice_no").ToString
                    .txt_Receiving_no.Text = dr.Item("receiving_no").ToString
                    .txt_Ws_no.Text = dr.Item("ws_no").ToString
                    .txtIn_out.Text = dr.Item("in_out").ToString
                    .txtBalance.Text = dr.Item("balance").ToString
                    .txtRemarks.Text = dr.Item("remarks").ToString
                End With
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

        'FPreviousStackCardFinal.ShowDialog()
    End Sub
    Public Function show_tor_sub_desc(ByVal x As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim query As String
        Try
            newSQ.connection.Open()
            query = "SELECT tor_sub_desc FROM dbType_of_Request_sub WHERE tor_sub_id = '" & x & "'"
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                show_tor_sub_desc = newDR.Item(0).ToString
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Public Function get_type_of_request(ByVal x As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim query As String
        Try
            newSQ.connection.Open()
            query = "SELECT tor_desc FROM dbType_of_Request WHERE tor_id = '" & x & "'"
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_type_of_request = newDR.Item("tor_desc").ToString
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Public Function get_tor_id(ByVal x As Integer) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim query As String
        Try
            newSQ.connection.Open()
            query = "SELECT tor_id FROM dbType_of_Request_sub WHERE tor_sub_id = '" & x & "'"
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_tor_id = newDR.Item(0).ToString
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Private Sub lvList_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvList.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenuStrip1.Show(Me, e.Location)
            ContextMenuStrip1.Show(Cursor.Position)
        End If
    End Sub

    Private Sub txtRSno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub


    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim ex = MessageBox.Show("Are you sure u want to DELETE the SELECTED item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If ex = MsgBoxResult.Yes Then
            For Each row As ListViewItem In lvList.Items
                If row.Selected = True Then
                    DeleteRecord_PreviousStockCard()
                    row.Remove()
                End If
            Next
            MessageBox.Show("Successfully Deleted...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub cmbSearchByCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DateTimePicker_PreviousStockCard_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If cmbSearchByCategory.Text = "Rs_no" Then
            SearchRecord_PreviousStockCard(1)
        ElseIf cmbSearchByCategory.Text = "Invoice_no" Then
            SearchRecord_PreviousStockCard(2)
        ElseIf cmbSearchByCategory.Text = "Receiving_no" Then
            SearchRecord_PreviousStockCard(3)
        ElseIf cmbSearchByCategory.Text = "Ws_no" Then
            SearchRecord_PreviousStockCard(4)
        ElseIf cmbSearchByCategory.Text = "Item_name" Or cmbSearchByCategory.Text = "Item Desc" Then
            SearchRecord_PreviousStockCard(5)
        ElseIf cmbSearchByCategory.Text = "Date" Then
            SearchRecord_PreviousStockCard(6)
        End If
        ' load_PreviousStockCard()

    End Sub

    Private Sub FPreviousStockCard_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'lvList.Width = Me.Width - txtBalance.Width - 30
        lvList.Height = Me.Height - 110
        lvList.Width = Me.Width - 20

        gboxSearch.Location = New Point(lvList.Location.X, lvList.Bounds.Bottom)

        btnExit.Parent = pboxHeader
        btnExit.BringToFront()
        btnExit.Location = New Point(lvList.Width + 1, 10)
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        ''SearchRecord_PreviousStockCard()
        'If txtSearch.Text = "" Then
        '    load_PreviousStockCard()
        'End If
    End Sub

    Private Sub txtWs_no_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Btn_for_PreviousStockCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_for_PreviousStockCard.Click
        FPreviousStackCardFinal.Show()
        lvList.Enabled = False

    End Sub

    Private Sub txtField_leave(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtBalance_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    End Sub

    Private Sub txtField_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmbSearchByCategory_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSearchByCategory.SelectedIndexChanged
        If cmbSearchByCategory.Text = "Date" Then
            DTP_PSC.Width = txtSearch.Width
            DTP_PSC.Location = New Point(txtSearch.Bounds.Left, txtSearch.Bounds.Top)
            DTP_PSC.Parent = gboxSearch
            DTP_PSC.BringToFront()
            DTP_PSC.Visible = True
            txtSearch.Text = ""
        ElseIf cmbSearchByCategory.Text = "Rs_no" Then
            DTP_PSC.Visible = False
            txtSearch.Text = ""
            txtSearch.Focus()
            'If DTP_PSC.Visible = False Then
            '    load_PreviousStockCard()
            'End If
        ElseIf cmbSearchByCategory.Text = "Invoice_no" Then
            DTP_PSC.Visible = False
            txtSearch.Text = ""
            txtSearch.Focus()
            'If DTP_PSC.Visible = False Then
            '    load_PreviousStockCard()
            'End If
        ElseIf cmbSearchByCategory.Text = "Receiving_no" Then
            DTP_PSC.Visible = False
            txtSearch.Text = ""
            txtSearch.Focus()
            'If DTP_PSC.Visible = False Then
            '    load_PreviousStockCard()
            'End If
        ElseIf cmbSearchByCategory.Text = "Ws_no" Then
            DTP_PSC.Visible = False
            txtSearch.Text = ""
            txtSearch.Focus()
            'If DTP_PSC.Visible = False Then
            '    load_PreviousStockCard()
            'End If
        ElseIf cmbSearchByCategory.Text = "Item_name" Or cmbSearchByCategory.Text = "Item Desc" Then
            DTP_PSC.Visible = False
            txtSearch.Text = ""
            txtSearch.Focus()
            'If DTP_PSC.Visible = False Then
            '    load_PreviousStockCard()
            'End If
        End If
    End Sub

    Private Sub DTP_PSC_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTP_PSC.Leave
        load_PreviousStockCard()
    End Sub

    Private Sub DTP_PSC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_PSC.ValueChanged

    End Sub

    Private Sub lvList_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvList.Resize

    End Sub

    Private Sub lvList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvList.SelectedIndexChanged

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

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub FPreviousStockCard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class