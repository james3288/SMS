Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FReceiving_Items
    Dim rowind As Integer
    Dim old_price_value As Decimal
    Dim rowindex As Integer
    Dim old_qty As Integer
    Dim old_desired_qty As Integer

    Private cCustomMsg As New customMessageBox
    Public Sub calc_total_qty_and_amount(dgv As DataGridView, rr_item_id As Integer)
        Dim ccolor As Color
        Dim total_qty As Integer
        Dim total_amount As Decimal
        Dim grandtotal As Decimal


        ' ====kwaon ang total qty then set===
        With dgv
            For i = 0 To DataGridView1.Rows.Count - 1
                If .Rows(i).Cells("col_rr_item_id").Value = rr_item_id Then
                    ccolor = .Rows(i).DefaultCellStyle.BackColor

                    If ccolor = Color.LightGreen Then

                        total_qty += CDbl(.Rows(i).Cells("col_po_qty").Value)
                        total_amount += CDec(.Rows(i).Cells("col_po_qty").Value) * CDec(.Rows(i).Cells("col_price").Value)

                    ElseIf ccolor = Nothing Then
                        .Rows(i).Cells("col_po_qty").Value = total_qty
                        .Rows(i).Cells("col_price").Value = FormatNumber(total_amount, 2,,, TriState.True)

                    End If
                End If

            Next


            For i = 0 To DataGridView1.Rows.Count - 1
                If DataGridView1.Rows(i).Cells(0).Value = "TOTAL" Then
                    grandtotal += CDec(dgv.Rows(i).Cells("col_price").Value)
                End If
            Next

            dgv.Rows(dgv.Rows.Count - 1).Cells("col_price").Value = FormatNumber(grandtotal, 2,,, TriState.True)
        End With

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FReceiving_Items_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For i = 0 To 9
            Me.DataGridView1.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Me.DataGridView1.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Next

        For i = 0 To DataGridView1.Rows.Count - 1
            Me.DataGridView1.Rows(i).Height = 30
        Next

        Me.DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Me.DataGridView1.Columns(7).DisplayIndex = 3
        Me.DataGridView1.Columns(8).DisplayIndex = 4
        Me.DataGridView1.Columns(4).DisplayIndex = 0
        Me.DataGridView1.Columns(2).DisplayIndex = 5

        'Me.DataGridView1.Columns(5).Visible = True
        'Me.DataGridView1.Columns(6).Visible = True
        'Me.DataGridView1.Columns(9).Visible = True

    End Sub

    Public Function get_datagrid_rowindex() As Integer

        For i As Integer = 0 To Me.DataGridView1.SelectedCells.Count - 1
            get_datagrid_rowindex = Me.DataGridView1.SelectedCells.Item(i).RowIndex
        Next
    End Function

    Public Function get_qty_and_total_qty(rr_item_id As Integer, n As Integer) As Integer
        Dim qty, total_qty As Integer
        With DataGridView1
            For i = 0 To .Rows.Count - 1
                If .Rows(i).DefaultCellStyle.BackColor = Color.DarkGreen Then
                    If CInt(.Rows(i).Cells(6).Value) = rr_item_id Then
                        qty = CInt(.Rows(i).Cells(1).Value)
                    End If
                Else
                    If CInt(.Rows(i).Cells(6).Value) = rr_item_id And .Rows(i).Cells(4).Value = "Include" Then
                        total_qty += CInt(.Rows(i).Cells(1).Value)
                    End If
                End If
            Next

        End With

        If n = 1 Then
            Return qty
        ElseIf n = 2 Then
            Return total_qty
        End If
    End Function
    Public Sub clear_selected_on_datagridview(dgview As DataGridView)
        For i = 0 To dgview.Rows.Count - 1
            dgview.Rows(i).Cells(1).Selected = False
        Next
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub
    Public Function if_po_qty_greater_than_total_qty(po_qty As Integer, total_qty As Integer, rr_item_id As Integer, dgv As DataGridView, i As Integer) As Boolean
        If po_qty < total_qty Then

            For Each row As DataGridViewRow In dgv.Rows
                row.Selected = False
            Next

            dgv.Rows(i).Cells(1).Selected = True
            if_po_qty_greater_than_total_qty = True

        Else
            if_po_qty_greater_than_total_qty = False

        End If

    End Function
    Public Function insert_update_dbreceiving_items(ByVal rr_info_id As Integer, ByVal type As String, ByVal n As Integer, ByVal item_desc As String, ByVal remarks As String, ByVal wh_id As Integer, ByVal rs_id As Integer, ByVal qty As Decimal, rowindex As Integer, po_det_id As Integer, selected As String, rr_item_id As Integer) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@type", type)

            newCMD.Parameters.AddWithValue("@rr_info_id", rr_info_id)
            newCMD.Parameters.AddWithValue("@item_desc", item_desc)
            newCMD.Parameters.AddWithValue("@remarks", remarks)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.Parameters.AddWithValue("@qty", qty)
            newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)
            newCMD.Parameters.AddWithValue("@selected", selected)

            If n = 3 Then 'insert
                rr_item_id = newCMD.ExecuteScalar
                Return rr_item_id
            ElseIf n = 33 Then 'update
                newCMD.Parameters.AddWithValue("@rr_item_id", rr_item_id)
                newCMD.ExecuteNonQuery()
            End If




        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Public Function insert_dbreceiving_info(ByVal type As String, ByVal n As Integer) As Integer
        'Dim suppname, invoiceno, supplier, po_no, rs_no, receivedby, checkedby, receivedstatus, so_no, hauler, plateno As String
        'Dim date_received As DateTime

        With FReceiving_Info
            Dim newSQ As New SQLcon
            Dim newCMD As SqlCommand
            Dim supplier_id As Integer = get_id("dbSupplier", "Supplier_Name", .cmbSupplier.Text, 0)
            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_receiving_crud_new", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", n)
                newCMD.Parameters.AddWithValue("@type", type)

                newCMD.Parameters.AddWithValue("@rr_no", .txtRRno.Text)
                newCMD.Parameters.AddWithValue("@invoice_no", .txtInvoiceNo.Text)
                newCMD.Parameters.AddWithValue("@supplier_id", supplier_id)
                newCMD.Parameters.AddWithValue("@po_no", .cmbPoNo.Text)
                newCMD.Parameters.AddWithValue("@rs_no", .txtRSNo.Text)
                newCMD.Parameters.AddWithValue("@date_received", Date.Parse(.DTPReceived.Text))
                newCMD.Parameters.AddWithValue("@received_by", .txtReceivedby.Text)
                newCMD.Parameters.AddWithValue("@checked_by", .txtCheckedby.Text)
                newCMD.Parameters.AddWithValue("@received_status", "PENDING")
                newCMD.Parameters.AddWithValue("@so_no", .txtSOno.Text)
                newCMD.Parameters.AddWithValue("@hauler", .txtHauler.Text)
                newCMD.Parameters.AddWithValue("@plateno", .txtPlateNo.Text)
                newCMD.Parameters.AddWithValue("@date_log", Format(Date.Parse(Now), "yyyy-MM-dd HH:mm:ss"))
                newCMD.Parameters.AddWithValue("@user_id", pub_user_id)
                newCMD.Parameters.AddWithValue("@date_submitted", FReceiving_Info.date_submitted())

                insert_dbreceiving_info = newCMD.ExecuteScalar()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try
        End With

    End Function
    Public Function insert_to_receiving_sub_item(subitem As String, qty As Decimal, price As Double, unit As String, selected As String, rr_item_id As Integer) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 8)

            newCMD.Parameters.AddWithValue("@rr_item_id", rr_item_id)
            newCMD.Parameters.AddWithValue("@item_desc", subitem)
            newCMD.Parameters.AddWithValue("@qty", qty)
            newCMD.Parameters.AddWithValue("@unit", unit)
            newCMD.Parameters.AddWithValue("@amount", price)
            newCMD.Parameters.AddWithValue("@selected", selected)

            insert_to_receiving_sub_item = newCMD.ExecuteScalar
            'newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Public Function update_to_receiving_sub_item(subitem As String, qty As Double, price As Double, unit As String, selected As String, rr_item_sub_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 88)

            newCMD.Parameters.AddWithValue("@item_desc", subitem)
            newCMD.Parameters.AddWithValue("@qty", qty)
            newCMD.Parameters.AddWithValue("@unit", unit)
            newCMD.Parameters.AddWithValue("@amount", price)
            newCMD.Parameters.AddWithValue("@rr_item_sub_id", rr_item_sub_id)
            newCMD.Parameters.AddWithValue("@selected", selected)

            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Dim temp_rr_item_id As Integer = CInt(DataGridView1.SelectedRows(0).Cells(6).Value)
        Dim a(10) As String

        If DataGridView1.SelectedRows(0).DefaultCellStyle.BackColor = Nothing Then
            MessageBox.Show("Unable to Insert this area..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        a(0) = ""
        a(1) = 1
        a(2) = ""
        a(3) = FormatNumber(0, 2,,, TriState.True)
        a(5) = ""
        a(6) = temp_rr_item_id

        DataGridView1.Rows.Insert(DataGridView1.SelectedRows(0).Index + 1, a.ToArray)
        DataGridView1.Rows(DataGridView1.SelectedRows(0).Index + 1).DefaultCellStyle.BackColor = Color.LightGreen

        Dim gridComboBox11 As New DataGridViewComboBoxCell
        gridComboBox11.Items.Add("Include")
        gridComboBox11.Items.Add("Pending")
        gridComboBox11.Items.Add("Fixed")
        DataGridView1.Item(4, DataGridView1.SelectedRows(0).Index + 1) = gridComboBox11
        DataGridView1.Item(4, DataGridView1.SelectedRows(0).Index + 1).Value = "Include"

        DataGridView1.Rows(DataGridView1.SelectedRows(0).Index + 1).Cells("col_desired_qty").ReadOnly = True
        DataGridView1.Rows(DataGridView1.SelectedRows(0).Index + 1).Cells("col_qty_received").ReadOnly = True
        DataGridView1.Rows(DataGridView1.SelectedRows(0).Index + 1).Cells("col_po_det_id").ReadOnly = True
        DataGridView1.Rows(DataGridView1.SelectedRows(0).Index + 1).Cells("col_rr_item_id").ReadOnly = True

        DataGridView1.Rows(DataGridView1.SelectedRows(0).Index + 1).Height = 30

        calc_total_qty_and_amount(DataGridView1, temp_rr_item_id)
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim po_det_id, rr_item_sub_id As Integer
        Dim subitem, unit As String
        Dim price, qty As Double
        Dim selected, darkgreenselected As String
        Dim rr_info_id As Integer
        Dim rr_item_id As Integer
        Dim rs_id As Integer
        Dim sub_main As String
        Dim rs_no As String

        If Button2.Text = "Save" Then

            If MessageBox.Show("Are you sure you want save this data?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                update_item_name_desc()
                update_podet_suplierID()
                rr_info_id = insert_dbreceiving_info("OTHERS", 2)
            Else
                ' if save no
                Exit Sub
            End If

        ElseIf Button2.Text = "Update" Then

            If MessageBox.Show("Are you sure you want update this data?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                update_item_name_desc()
            Else
                'if update no
                Exit Sub
            End If

        End If

        With DataGridView1
            For i = 0 To .Rows.Count - 1
                If .Rows(i).DefaultCellStyle.BackColor = Color.DarkGreen Then

#Region "DARKGREEN / RR ITEMS"
                    'kung green ang rows                   
#Region "INITIALIZE"
                    po_det_id = .Rows(i).Cells(5).Value
                    rs_no = .Rows(i).Cells(11).Value
                    subitem = .Rows(i).Cells(0).Value

                    If .Rows(i).Cells(1).Value = "-" Then
                        qty = 0
                    Else
                        qty = CDbl(.Rows(i).Cells(1).Value)
                    End If

                    unit = .Rows(i).Cells(2).Value
                    price = .Rows(i).Cells(3).Value
                    darkgreenselected = .Rows(i).Cells(4).Value
                    selected = .Rows(i).Cells(4).Value
                    rs_id = .Rows(i).Cells("col_rs_id").Value

                    Dim desired_qty As Double = .Rows(i).Cells(7).Value
#End Region

                    If Button2.Text = "Save" Then
#Region "SAVE"
                        If selected = "Include" Then
                            rr_item_id = insert_update_dbreceiving_items(rr_info_id, "OTHERS", 3, "", "", 0, rs_id, qty, 0, po_det_id, selected, 0)

                            Dim query As String = "INSERT INTO dbreceiving_item_partially(rr_item_id,desired_qty) VALUES(" & rr_item_id & "," & desired_qty & ")"
                            UPDATE_INSERT_DELETE_QUERY(query, 0, "INSERT")

                        ElseIf selected = "Pending" Then
                            'walay insert mahitabo
                            GoTo proceedhere
                        End If
#End Region

#Region "SAVE SERIAL #"
                        saveSerialNo(rr_item_id)
#End Region

                    ElseIf Button2.Text = "Update" Then

#Region "UPDATE"
                        rr_item_id = CInt(.Rows(i).Cells(6).Value)
                        insert_update_dbreceiving_items(rr_info_id, "OTHERS", 33, "", "", 0, rs_id, qty, 0, po_det_id, selected, rr_item_id)
#End Region
                    End If
#End Region

                Else

#Region "LIGHTGREEN / RR ITEMS SUB"
                    'kung light green ang rows      
#Region "INITIALIZE"
                    rr_item_sub_id = check_if_numeric(.Rows(i).Cells(5).Value)

                    subitem = .Rows(i).Cells(0).Value
                    qty = CDec(.Rows(i).Cells(1).Value)
                    unit = .Rows(i).Cells(2).Value
                    price = .Rows(i).Cells(3).Value
                    selected = .Rows(i).Cells(4).Value
#End Region

                    '************************
                    If Button2.Text = "Save" Then
#Region "SAVE"
                        If selected = "Include" Or selected = "Pending" Then
                            'insert tong sub item (light green color)
                            'then get rr_item_sub_id dayon

                            '*****for borrower ni diri na function*******'

                            'get the MAIN item (Ex. Computer set)

                            If darkgreenselected = "Include" Then

                                rr_item_sub_id = insert_to_receiving_sub_item(subitem, qty, price, unit, selected, rr_item_id)
                                insert_reserved_item(rr_item_sub_id, subitem, rs_no, rs_id, qty)

                                update_po_price_qty(price, rs_id)

                                Dim query1 As String = "SELECT rs_id FROM dbrequisition_slip a WHERE a.rs_no = '" & rs_no & "' AND a.main_sub = '" & "MAIN" & "'"
                                Dim main_rs_id As Integer = get_specific_column_value(query1, 1)

                                If check_if_exist("dbBorrower_checking_info", "rs_id", main_rs_id, 1) = 0 Then 'if dili zero, no need to insert na
                                    FItem_Sets.dbBorrower_checking_info(main_rs_id) 'insert to dbBorrower_checking_info            
                                End If

                                Dim query As String = "SELECT checking_info_id FROM dbBorrower_checking_info WHERE rs_id = " & main_rs_id
                                Dim checkingInfo_id As Integer = get_specific_column_value(query, 1) 'get id from dbBorrower_checking_info
                                FItem_Sets.insert_borrowerchercking_items(checkingInfo_id, rr_item_sub_id, subitem, 0, 1, rr_item_id)

                                FListofBorrowerItem.update_requestionslip(main_rs_id, 0)
                            End If

                            '************END*******************************
                        End If
#End Region

                    ElseIf Button2.Text = "Update" Then
#Region "UPDATE"
                        If rr_item_sub_id = 0 Then
                            'zero meaning wala pa na insert sa database
                            'insert sub to subitem
                            If selected = "Include" Or selected = "Fixed" Then
                                insert_to_receiving_sub_item(subitem, qty, price, unit, selected, rr_item_id)

                                update_po_price_qty(price, rs_id)

                            End If
                        Else

                            update_to_receiving_sub_item(subitem, qty, price, unit, selected, rr_item_sub_id)

                            update_po_price_qty(price, rs_id)

                        End If
#End Region
                    End If

#End Region

                End If

proceedhere:
            Next
        End With


        'Create another items and update using this rs
        If MessageBox.Show("Do you want to create new item and update this data?", "Supply Info:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            create_new_item_and_update()
        Else

            FReceivingReportList.btnSearch.PerformClick()
            listfocus(FReceivingReportList.lvlreceivingreportlist, rr_item_id)
            FReceiving_Info.Dispose()
            Me.Dispose()

            If Button2.Text = "Save" Then
                If Application.OpenForms().OfType(Of FRequistionForm).Any Then
                    With FRequistionForm

                        Dim po_det_id2 As Integer = Utilities.ifBlankReplaceToZero(.lvlrequisitionlist.SelectedItems(0).SubItems(22).Text)

                        If cCustomMsg.messageYesNo("Do you also want to update the quantity in the PO to match the quantity you received today?", "SUPPLY INFO:") Then
                            cCustomMsg.message("warning", "sorry but this function is under maintenance...", "SUPPLY INFO:")

                            .btnSearch.PerformClick()
                        Else
                            .btnSearch.PerformClick()
                        End If

                    End With
                End If
            End If
        End If


    End Sub
    Private Sub create_new_item_and_update()
        Dim a(5) As String
        FReceiving_Create_New_Item.lvlCreate_New_Item.Items.Clear()

        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.DefaultCellStyle.BackColor = Color.LightGreen Then
                With FReceiving_Create_New_Item
                    Dim newSQ As New SQLcon
                    Dim newCMD As SqlCommand
                    Dim newDR As SqlDataReader

                    Try
                        newSQ.connection.Open()
                        newCMD = New SqlCommand("proc_requisition_slip", newSQ.connection)
                        newCMD.Parameters.Clear()
                        newCMD.CommandType = CommandType.StoredProcedure

                        newCMD.Parameters.AddWithValue("@n", 35)
                        newCMD.Parameters.AddWithValue("@rs_id", row.Cells("col_rs_id").Value)
                        newDR = newCMD.ExecuteReader

                        While newDR.Read

                            a(0) = row.Cells("col_rs_id").Value
                            a(1) = newDR.Item("whItem").ToString
                            a(2) = row.Cells("col_sub_item_desc").Value
                            a(3) = row.Cells("col_unit").Value
                            a(4) = newDR.Item("wh_id").ToString

                            Dim lvl As New ListViewItem(a)
                            .lvlCreate_New_Item.Items.Add(lvl)
                        End While

                        newDR.Close()

                    Catch ex As Exception
                        MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        newSQ.connection.Close()
                    End Try


                End With

                FReceiving_Create_New_Item.Show()

            End If

        Next
    End Sub
    Public Function update_item_name_desc()
        'if yes

        FUpdateItemNameDesc.DataGridView1.Rows.Clear()

        If MessageBox.Show("Do you want to update item name and item description?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim wh_id As Integer
            Dim Item_Name As String
            Dim Item_Desc As String

            For Each row As DataGridViewRow In DataGridView1.Rows

                If row.DefaultCellStyle.BackColor = Color.DarkGreen Then
                    Dim query As String = "SELECT wh_id FROM dbrequisition_slip WHERE rs_id = " & CInt(row.Cells("col_rs_id").Value)
                    wh_id = get_specific_column_value(query, 1)

                    query = "SELECT whItem FROM dbwarehouse_items WHERE wh_id = " & wh_id
                    Item_Name = get_specific_column_value(query, 0)

                    query = "SELECT whItemDesc FROM dbwarehouse_items WHERE wh_id = " & wh_id
                    Item_Desc = get_specific_column_value(query, 0)

                    Dim r(10) As String

                    r(0) = True
                    r(1) = wh_id 'wh_id 
                    r(2) = row.Cells("col_sub_item_desc").Value 'previous name
                    r(3) = Item_Name
                    r(4) = Item_Desc
                    r(5) = CInt(row.Cells("col_rs_id").Value)

                    FUpdateItemNameDesc.DataGridView1.Rows.Add(r)
                End If

            Next

            FUpdateItemNameDesc.ShowDialog()

        End If
    End Function
    Public Sub insert_reserved_item(ByVal rr_item_sub_id As Integer, ByVal item_desc As String, rs_no As String, rs_id As Integer, qty As Decimal)
        Dim newsq As New SQLcon
        Dim newcmd As SqlCommand

        Try
            newsq.connection.Open()
            publicquery = "INSERT INTO dbBorrower_reserved(rs_id, rs_no, rr_item_sub_id, item_desc,qty) VALUES ('" & rs_id & "', '" & rs_no & "', '" & rr_item_sub_id & "', '" & item_desc & "'," & qty & ")"
            newcmd = New SqlCommand(publicquery, newsq.connection)
            newcmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsq.connection.Close()
        End Try
    End Sub

    Public Function update_po_price_qty(ByVal unit_price As Decimal, ByVal rs_id As Integer)
        Dim newsqlcon As New SQLcon
        Dim newcmd As SqlCommand
        Dim newdr As SqlDataReader

        Try
            newsqlcon.connection.Open()
            'Dim query As String = "UPDATE dbPO_details SET qty = '" & desired_qty & "', unit_price = '" & unit_price & "' WHERE rs_id = '" & rs_id & "'"
            Dim query As String = "UPDATE dbPO_details SET unit_price = '" & unit_price & "' WHERE rs_id = '" & rs_id & "'"
            newcmd = New SqlCommand(query, newsqlcon.connection)
            newcmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
        End Try

    End Function

    Private Sub DataGridView1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Dim rr_item_id As Integer = DataGridView1.SelectedRows(0).Cells(6).Value

        If DataGridView1.SelectedRows(0).DefaultCellStyle.BackColor = Color.DarkGreen Then
            MessageBox.Show("Unable to remove this row..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf DataGridView1.SelectedRows(0).DefaultCellStyle.BackColor = Nothing Then
            MessageBox.Show("Unable to remove this row..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If DataGridView1.SelectedRows(0).Cells(5).Value = "" Then
                DataGridView1.Rows.Remove(DataGridView1.SelectedRows(0))
            Else
                If MessageBox.Show("Are you sure you want to delete this data?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim rr_item_sub_id As Integer
                    If DataGridView1.SelectedRows(0).Cells(5).Value = "" Then
                        rr_item_sub_id = 0
                    Else
                        rr_item_sub_id = CInt(DataGridView1.SelectedRows(0).Cells(5).Value)
                    End If

                    Dim query As String = "DELETE FROM dbreceiving_items_sub WHERE rr_item_sub_id = " & rr_item_sub_id
                    UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")
                    DataGridView1.Rows.Remove(DataGridView1.SelectedRows(0))
                End If
            End If
        End If

        calc_total_qty_and_amount(DataGridView1, rr_item_id)

    End Sub

    Private Sub DataGridView1_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridView1.CellBeginEdit
        Try
            rowind = Format(get_datagrid_rowindex)
            old_price_value = check_if_numeric(DataGridView1.Rows(Format(rowind)).Cells("col_price").Value)

            rowindex = DataGridView1.SelectedRows(0).Index
            old_qty = check_if_numeric(DataGridView1.SelectedRows(0).Cells("col_po_qty").Value)

            old_desired_qty = CInt(check_if_numeric(DataGridView1.SelectedRows(0).Cells("col_desired_qty").Value))
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        'check desired qty > actual qty
        With DataGridView1.Rows(rowind)
            Dim rr_item_id As Integer = IIf(.Cells("col_rr_item_id").Value = "", 0, .Cells("col_rr_item_id").Value)


            If if_numeric(.Cells("col_desired_qty").Value) = False And .DefaultCellStyle.BackColor = Color.DarkGreen Then
                MessageBox.Show("desired qty must numeric.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                .Cells("col_desired_qty").Value = old_desired_qty
                calc_total_qty_and_amount(DataGridView1, rr_item_id)
                Exit Sub

            End If

            Dim subitem As String = .Cells("col_sub_item_desc").Value
            Dim des_qty As Integer = IIf(if_numeric(.Cells("col_desired_qty").Value) = False, 0, .Cells("col_desired_qty").Value)
            Dim unit As String = .Cells("col_unit").Value
            Dim price As Decimal = check_if_numeric(.Cells("col_price").Value)
            Dim selected As String = .Cells(4).Value
            Dim po_det_id As Integer = IIf(.Cells("col_po_det_id").Value = "", 0, check_if_numeric(.Cells("col_po_det_id").Value))

            Dim act_qty As Integer = check_if_numeric(.Cells("col_po_qty").Value)
            Dim total_qty_rec As Integer = CInt(check_if_numeric(.Cells("col_qty_received").Value))

            'If if_numeric(.Cells("col_po_qty").Value) = False Or if_numeric(.Cells("col_price").Value) = False Then

            Dim rowcolor As Color = .DefaultCellStyle.BackColor

            If rowcolor = Color.DarkGreen Then
                If des_qty > act_qty Then
                    MessageBox.Show("total qty received must not exceed on the po qty.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    .Cells("col_desired_qty").Value = old_desired_qty

                    clear_selected_on_datagrid(DataGridView1)
                    .Selected = True
                    Exit Sub
                End If
            Else
                If if_numeric(.Cells("col_po_qty").Value) = False Or if_numeric(.Cells("col_price").Value) = False Then

                    MessageBox.Show("Price or desired qty must numeric..", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    .Cells("col_price").Value = FormatNumber(old_price_value, 2,,, TriState.True)
                    clear_selected_on_datagrid(DataGridView1)
                    calc_total_qty_and_amount(DataGridView1, rr_item_id)

                    .Selected = True
                    Exit Sub

                End If
            End If
            'End If

            .Cells("col_sub_item_desc").Value = convert_lowupcase(.Cells("col_sub_item_desc").Value, 3)


            .Cells("col_price").Value = price 'FormatNumber(CDec(check_if_numeric(.Cells("col_price").Value)), 2,,, TriState.True)
            calc_total_qty_and_amount(DataGridView1, rr_item_id)
        End With

    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If DataGridView1.CurrentCell IsNot Nothing Then
            If e.RowIndex = DataGridView1.CurrentCell.RowIndex And e.ColumnIndex = DataGridView1.CurrentCell.ColumnIndex Then
                e.CellStyle.SelectionBackColor = Color.SteelBlue
            Else
                e.CellStyle.SelectionBackColor = DataGridView1.DefaultCellStyle.SelectionBackColor

            End If
        End If
    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub FindRelatedItemsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FindRelatedItemsToolStripMenuItem.Click
        FReceiving_Find_Related_Item.ShowDialog()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox(FRequistionForm.all_rr_po_det_id)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        MsgBox(FReceiving_Info.sup_ids)
    End Sub

    Public Sub update_podet_suplierID()
        Dim newSQ As New SQLcon
        Dim newcmd As SqlCommand
        Dim query2 As String = "UPDATE dbPO_details SET supplier_id = '" + FReceiving_Info.sup_ids + "' where po_det_id IN (" + FRequistionForm.all_rr_po_det_id + ")"

        Try
            newSQ.connection.Open()
            publicquery = query2
            newcmd = New SqlCommand(publicquery, newSQ.connection)
            newcmd.ExecuteNonQuery()
            ''   MsgBox("UPDATED!")
            newSQ.connection.Close()
        Catch ex As Exception
            ''MsgBox(ex.ToString)
        End Try
    End Sub


    'new functions 
    Private Sub saveSerialNo(rr_items_id As Integer)
        Try
            With FReceiving_Info.cTireSerialStore
                Dim c As New ColumnValuesObj

                c.add("rr_items_id", rr_items_id)
                c.add("serial_no", .serial_no)
                c.add("tire_position_id", .tire_position_id)

                c.insertQuery("dbSerial")
            End With

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub
End Class