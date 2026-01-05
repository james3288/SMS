Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FPurchaseOrder

    Public SQ As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Dim name1 As String
    Dim rowind As Integer
    Dim n As Integer
    Dim old_price_value As Double
    Dim public_po_id As Integer
    Public total_amount As Double
    Public x As Integer
    Dim booleanOperator_Cancel As Boolean = False
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Dispose()

    End Sub

    Private Sub FPurchaseOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtAddress.Clear()
        txtApproved_by.Clear()

        txtChecked_by.Clear()
        txtInstructions.Clear()
        txtPoNo.Text = 0
        txtPrepared_by.Clear()
        txtTerms.Clear()

        load_suppliers_list()

        If check_if_exist("dbpurchase_order", "rs_no", Val(txtRsNo.Text), 0) > 0 Then
            load_po1()
            load_po()
            btnSave.Text = "Update"
        Else
            load_wh_item_using_rs()
            btnSave.Text = "Save"
        End If

        lblTotal.Text = total_price_item()


        'load_wh_item_using_rs()
    End Sub

    Public Sub load_suppliers_list()
        cmbSupplier.Items.Clear()

        Try
            SQ.connection.Open()
            publicquery = "SELECT Supplier_Name FROM dbSupplier"
            cmd = New SqlCommand(publicquery, SQ.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                cmbSupplier.Items.Add(dr.Item(0).ToString)
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()

        End Try
    End Sub

    Public Function total_price_item() As Double

        Try
            For i = 0 To dgPurchaseOrder.Rows.Count - 1
                total_price_item += CDbl(dgPurchaseOrder.Rows(i).Cells(5).Value())
            Next

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Sub load_po1()
        Try
            SQ.connection.Open()
            publicquery = "SELECT * FROM dbpurchase_order WHERE rs_no = " & txtRsNo.Text

            cmd = New SqlCommand(publicquery, SQ.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                txtPoNo.Text = dr.Item("po_no").ToString
                DTPTrans.Text = dr.Item("po_date").ToString
                txtInstructions.Text = dr.Item("instructions").ToString
                cmbSupplier.Text = dr.Item("supplier").ToString
                txtAddress.Text = dr.Item("address").ToString
                txtTerms.Text = dr.Item("terms").ToString
                DTPdateneeded.Text = dr.Item("date_needed").ToString
                txtPrepared_by.Text = dr.Item("prepared_by").ToString
                txtChecked_by.Text = dr.Item("checked_by").ToString
                txtApproved_by.Text = dr.Item("approved_by").ToString
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Sub load_po()
        dgPurchaseOrder.Rows.Clear()
        Dim row As Integer
        Try
            SQ.connection.Open()
            publicquery = "select a.po_id, b.rs_no,a.wh_id,a.item_desc,a.qty,a.unit,a.unit_price, a.po_item_id,b.po_id,a.rs_id " & _
            "FROM dbPurchase_order_items a " & _
            "INNER JOIN dbpurchase_order b ON a.po_id = b.po_id WHERE b.rs_no = " & txtRsNo.Text

            cmd = New SqlCommand(publicquery, SQ.connection)
            dr = cmd.ExecuteReader
            While dr.Read

                Dim a(10) As String

                Dim price As Double = update_item_price(dr.Item("wh_id").ToString)
                Dim totalprice As Double = price * CDbl(dr.Item("qty").ToString)


                a(0) = dr.Item("wh_id").ToString

                a(1) = dr.Item("item_desc").ToString

                a(2) = dr.Item("qty").ToString
                a(3) = dr.Item("unit").ToString
                'a(4) = dr.Item("unit_price").ToString
                'a(5) = CDbl(dr.Item("unit_price").ToString) * CDbl(dr.Item("qty").ToString)

                a(4) = FormatNumber(price, 2, , , TriState.True)
                a(5) = FormatNumber(totalprice, 2, , , TriState.True)

                a(6) = dr.Item("po_item_id").ToString
                a(7) = dr.Item("rs_id").ToString
                dgPurchaseOrder.Rows.Add(a)

                If check_if_rs_cancel(dr.Item("rs_id").ToString) > 0 Then
                    With dgPurchaseOrder.Rows(row)
                        For i = 0 To 5
                            .Cells(i).Style.BackColor = Color.Red
                            .Cells(i).Style.ForeColor = Color.White
                        Next
                    End With

                End If

                'total_amount += CDbl(dr.Item("unit_price").ToString) * CDbl(dr.Item("qty").ToString)

                row += 1
            End While
            dr.Close()

            dgPurchaseOrder.AllowUserToAddRows = False

            For i = 0 To dgPurchaseOrder.Rows.Count - 1
                With dgPurchaseOrder
                    .Rows(i).Cells(0).ReadOnly = True
                    .Rows(i).Cells(5).ReadOnly = True
                    .Rows(i).Cells(2).ReadOnly = True
                    .Rows(i).Cells(6).ReadOnly = True
                End With
            Next


            lblTotal.Text = total_amount

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Function update_item_price(ByVal wh_id As Integer) As Double

        Dim newSQ As New SQLcon
        Dim newcmd As SqlCommand
        Dim newdr As SqlDataReader
        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT DISTINCT a.wh_id,b.unit_price,c.date_received FROM dbreceiving_items a " & _
                                     "INNER JOIN dbPurchase_order_items b ON b.wh_id = a.wh_id " & _
                                     "INNER JOIN dbreceiving_info c ON c.rr_info_id = a.rr_info_id WHERE a.wh_id = " & wh_id & _
                                     " ORDER BY c.date_received ASC"
            newcmd = New SqlCommand(query, newSQ.connection)
            newdr = newcmd.ExecuteReader

            While newdr.Read
                update_item_price = newdr.Item("unit_price").ToString
            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Public Function check_if_rs_cancel(ByVal rs_id As Integer) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()

            Dim query As String = "SELECT * FROM dbrequisition_slip WHERE rs_id = " & rs_id
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                If newDR.Item("trans").ToString = "cancel" Then
                    check_if_rs_cancel += 1
                End If
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Public Function GET_ITEM_DESC_FROM_OTHERS(ByVal parse_wh_id As Integer)
        Dim SQLcon As New SQLcon
        Dim newcmd As SqlCommand
        Dim newdr As SqlDataReader

        Try
            SQLcon.connection.Open()
            publicquery = "SELECT * FROM dbfacilities_tools WHERE fac_tools_id = " & parse_wh_id
            newcmd = New SqlCommand(publicquery, SQLcon.connection)
            newdr = newcmd.ExecuteReader
            While newdr.Read
                GET_ITEM_DESC_FROM_OTHERS = newdr.Item("specification").ToString
            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Function

    Public Sub load_wh_item_using_rs()
        dgPurchaseOrder.Rows.Clear()
        Dim row As Integer
        Try
            SQ.connection.Open()

            If lblReqType.Text = "PROJECT" And lblInOut.Text = "OTHERS" Then
                publicquery = "SELECT * FROM dbrequisition_slip WHERE rs_no = " & Val(txtRsNo.Text)

            ElseIf lblReqType.Text = "EQUIPMENT" And lblInOut.Text = "OTHERS" Then
                publicquery = "SELECT * FROM dbrequisition_slip WHERE rs_no = " & Val(txtRsNo.Text)

            ElseIf lblReqType.Text = "SUPPLY" And lblInOut.Text = "OTHERS" Then
                publicquery = "SELECT * FROM dbrequisition_slip WHERE rs_no = " & Val(txtRsNo.Text)

            Else
                publicquery = "SELECT b.wh_id,b.whItem,a.qty,a.unit,a.typeRequest,a.rs_id,a.process,a.IN_OUT FROM dbrequisition_slip a " & _
              "INNER JOIN dbwarehouse_items b ON a.wh_id = b.wh_id " & _
              "WHERE a.rs_no = " & Val(txtRsNo.Text)

            End If
          
            cmd = New SqlCommand(publicquery, SQ.connection)
            dr = cmd.ExecuteReader

            While dr.Read

                Dim a(10) As String

                a(0) = dr.Item("wh_id").ToString

                If lblReqType.Text = "PROJECT" And lblInOut.Text = "OTHERS" Then
                    a(1) = dr.Item("item_desc").ToString
                    a(2) = dr.Item("qty").ToString
                    a(3) = dr.Item("unit").ToString
                    a(4) = 0
                    a(5) = 0
                    a(6) = 0
                    a(7) = dr.Item("rs_id").ToString

                ElseIf lblReqType.Text = "EQUIPMENT" And lblInOut.Text = "OTHERS" Then
                    a(1) = dr.Item("item_desc").ToString
                    a(2) = dr.Item("qty").ToString
                    a(3) = dr.Item("unit").ToString
                    a(4) = 0
                    a(5) = 0
                    a(6) = 0
                    a(7) = dr.Item("rs_id").ToString

                ElseIf lblReqType.Text = "SUPPLY" And lblInOut.Text = "OTHERS" Then
                    a(1) = dr.Item("item_desc").ToString
                    a(2) = dr.Item("qty").ToString
                    a(3) = dr.Item("unit").ToString
                    a(4) = 0
                    a(5) = 0
                    a(6) = 0
                    a(7) = dr.Item("rs_id").ToString

                Else
                    If dr.Item("typeRequest").ToString = "OTHERS" Then
                        a(1) = GET_ITEM_DESC_FROM_OTHERS(dr.Item("wh_id").ToString)
                    Else
                        a(1) = dr.Item("whItem").ToString
                    End If

                    If dr.Item("typeRequest").ToString = "OTHERS" And dr.Item("process").ToString = "PERSONAL" Then
                        a(1) = FRequistionForm.GET_ITEM_DESC_FROM_PERSONAL_TOOLS(dr.Item("wh_id").ToString)

                        'ElseIf dr.Item("typeRequest").ToString = "BORROWER" And dr.Item("IN_OUT").ToString = "FACILITIES" Then
                    ElseIf dr.Item("IN_OUT").ToString = "FACILITIES" Then
                        If dr.Item("process").ToString = "PERSONAL" Then
                            a(1) = FRequistionForm.GET_ITEM_DESC_FROM_PERSONAL_TOOLS(dr.Item("wh_id").ToString)
                        Else
                            a(1) = FRequistionForm.GET_ITEM_DESC_FROM_OTHERS(dr.Item("wh_id").ToString)
                        End If

                        'ElseIf dr.Item("typeRequest").ToString = "BORROWER" And dr.Item("IN_OUT").ToString = "TOOLS" Then
                    ElseIf dr.Item("IN_OUT").ToString = "TOOLS" Then
                        If dr.Item("process").ToString = "PERSONAL" Then
                            a(1) = FRequistionForm.GET_ITEM_DESC_FROM_PERSONAL_TOOLS(dr.Item("wh_id").ToString)
                        Else
                            a(1) = FRequistionForm.GET_ITEM_DESC_FROM_OTHERS(dr.Item("wh_id").ToString)
                        End If

                    End If

                    Dim price As Double = update_item_price(dr.Item("wh_id").ToString)
                    Dim totalprice As Double = price * CDbl(dr.Item("qty").ToString)

                    a(2) = dr.Item("qty").ToString
                    a(3) = dr.Item("unit").ToString
                    a(4) = FormatNumber(price, 2, , , TriState.True)
                    a(5) = FormatNumber(totalprice, 2, , , TriState.True)
                    a(6) = 0
                    a(7) = dr.Item("rs_id").ToString

                End If
               
                dgPurchaseOrder.Rows.Add(a)

                If check_if_rs_cancel(dr.Item("rs_id").ToString) > 0 Then
                    With dgPurchaseOrder.Rows(row)
                        For i = 0 To 5
                            .Cells(i).Style.BackColor = Color.Red
                            .Cells(i).Style.ForeColor = Color.White
                        Next
                    End With
                End If

                row += 1
            End While
            dr.Close()

            dgPurchaseOrder.AllowUserToAddRows = False

            For i = 0 To dgPurchaseOrder.Rows.Count - 1
                With dgPurchaseOrder
                    .Rows(i).Cells(5).ReadOnly = True
                    .Rows(i).Cells(2).ReadOnly = True
                End With
            Next

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()

        End Try
    End Sub
    Public Function get_typeofreq()
        Try

        Catch ex As Exception

        End Try
    End Function

    Private Sub dgPurchaseOrder_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgPurchaseOrder.CellBeginEdit

        n = CInt(dgPurchaseOrder.Rows(Format(get_datagrid_rowindex)).Cells(0).Value)
        rowind = Format(get_datagrid_rowindex)

        old_price_value = dgPurchaseOrder.Rows(Format(rowind)).Cells(4).Value

    End Sub
    Public Function get_datagrid_rowindex() As Integer

        For i As Integer = 0 To Me.dgPurchaseOrder.SelectedCells.Count - 1
            get_datagrid_rowindex = Me.dgPurchaseOrder.SelectedCells.Item(i).RowIndex
        Next
    End Function

    Private Sub dgPurchaseOrder_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPurchaseOrder.CellEndEdit
        'MsgBox(dgPurchaseOrder.Rows(Format(rowind)).Cells(5).Value())



        If Not IsNumeric(dgPurchaseOrder.Rows(Format(rowind)).Cells(4).Value()) Then

            MessageBox.Show("Entry must numeric..", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dgPurchaseOrder.Rows(Format(rowind)).Cells(4).Selected = True
            dgPurchaseOrder.Rows(Format(rowind)).Cells(4).Value = old_price_value

        ElseIf Not IsNumeric(dgPurchaseOrder.Rows(Format(rowind)).Cells(2).Value()) Then
            MessageBox.Show("Entry must numeric..", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dgPurchaseOrder.Rows(Format(rowind)).Cells(2).Selected = True
            dgPurchaseOrder.Rows(Format(rowind)).Cells(2).Value = 0

        Else
            dgPurchaseOrder.Rows(Format(rowind)).Cells(5).Value = CDbl(dgPurchaseOrder.Rows(Format(rowind)).Cells(4).Value) * CDbl(dgPurchaseOrder.Rows(Format(rowind)).Cells(2).Value)
        End If


        Dim cellindex As Integer = dgPurchaseOrder.SelectedCells(0).ColumnIndex
        Dim cellvalue As String = dgPurchaseOrder.Rows(Format(rowind)).Cells(cellindex).Value()
        Dim rows_po_items_id As Integer = dgPurchaseOrder.Rows(Format(rowind)).Cells(6).Value()

        Try
            SQ.connection.Open()

            If cellindex = 1 Then
                publicquery = "UPDATE dbPurchase_order_items SET item_desc = '" & cellvalue & "' WHERE po_item_id = " & rows_po_items_id
            ElseIf cellindex = 3 Then
                publicquery = "UPDATE dbPurchase_order_items SET unit = '" & cellvalue & "' WHERE po_item_id = " & rows_po_items_id
            ElseIf cellindex = 4 Then
                publicquery = "UPDATE dbPurchase_order_items SET unit_price = " & cellvalue & " WHERE po_item_id = " & rows_po_items_id
            End If

            cmd = New SqlCommand(publicquery, SQ.connection)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

        lblTotal.Text = total_price_item()

    End Sub

    Private Sub dgPurchaseOrder_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPurchaseOrder.CellContentClick

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If txtPoNo.Text = "" Or txtPoNo.Text = "0" Then
            MessageBox.Show("ZERO(0) is not applicable in po no.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtPoNo.Focus()
            Return
        ElseIf txtInstructions.Text = "" Then
            MessageBox.Show("YOU FORGOT TO FILL UP INSTRUCTION:  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtInstructions.Focus()
            Return
        ElseIf cmbSupplier.Text = "" Then
            MessageBox.Show("YOU FORGOT TO SELECT ON SUPPLIER:  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            cmbSupplier.Focus()
            Return
        ElseIf txtAddress.Text = "" Then
            MessageBox.Show("YOU FORGOT TO FILL UP ON THE ADDRESS TEXTBOX...  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtAddress.Focus()
            Return
        ElseIf txtTerms.Text = "" Then
            MessageBox.Show("EMPTY TERMS.....:  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtTerms.Focus()
            Return
        ElseIf txtPrepared_by.Text = "" Then
            MessageBox.Show("YOU FORGOT TO FILL UP WHOSE PREPARED BY...:  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtPrepared_by.Focus()
            Return
        ElseIf txtChecked_by.Text = "" Then
            MessageBox.Show("YOU FORGOT TO FILL UP WHOSE CHECKED BY:  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtChecked_by.Focus()
            Return
        ElseIf txtApproved_by.Text = "" Then
            MessageBox.Show("YOU FORGOT TO FILL UP WHOSE APPROVED BY:  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtApproved_by.Focus()
            Return
        ElseIf btnSave.Text = "Save" Then
            INSERT_INTO_dbpurchase_order(1)

            Dim a(10) As String
            For i = 0 To dgPurchaseOrder.Rows.Count - 1
                ' MsgBox(dgPurchaseOrder.Rows(i).Cells(2).Value)
                a(1) = public_po_id
                a(2) = txtPoNo.Text

                a(3) = dgPurchaseOrder.Rows(i).Cells(0).Value

                a(5) = dgPurchaseOrder.Rows(i).Cells(1).Value
                a(6) = dgPurchaseOrder.Rows(i).Cells(2).Value
                a(7) = dgPurchaseOrder.Rows(i).Cells(3).Value
                a(8) = dgPurchaseOrder.Rows(i).Cells(4).Value
                a(9) = dgPurchaseOrder.Rows(i).Cells(5).Value
                a(10) = dgPurchaseOrder.Rows(i).Cells(7).Value

                INSERT_INTO_dbPurchase_order_items(a(1), a(2), a(3), a(5), a(6), a(7), a(8), a(9), a(10))

            Next

        ElseIf btnSave.Text = "Update" Then
            INSERT_INTO_dbpurchase_order(3)
        End If


        Dim nn As Integer = CInt(dgPurchaseOrder.Rows(Format(get_datagrid_rowindex)).Cells(0).Value)
        Dim rowind1 As Integer = Format(get_datagrid_rowindex)


        With FRequistionForm
            .lvlrequisitionlist.Items.Clear()
            .load_rs_2()
            listfocus(.lvlrequisitionlist, txtRsNo.Text)
        End With
        Me.Dispose()
       
    End Sub

    Public Sub INSERT_INTO_dbpurchase_order(ByVal n As Integer)
        Try
            SQ.connection.Open()


            cmd = New SqlCommand("proc_purchase_order_query", SQ.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@po_no", txtPoNo.Text)
            cmd.Parameters.AddWithValue("@po_date", DTPTrans.Text)
            cmd.Parameters.AddWithValue("@rs_no", txtRsNo.Text)
            cmd.Parameters.AddWithValue("@instructions", txtInstructions.Text)
            cmd.Parameters.AddWithValue("@supplier", cmbSupplier.Text)
            cmd.Parameters.AddWithValue("@address", txtAddress.Text)
            cmd.Parameters.AddWithValue("@terms", txtTerms.Text)
            cmd.Parameters.AddWithValue("@charge_to", lblChargeToID.Text)
            cmd.Parameters.AddWithValue("@date_needed", DTPdateneeded.Text)
            cmd.Parameters.AddWithValue("@prepared_by", txtPrepared_by.Text)
            cmd.Parameters.AddWithValue("@checked_by", txtChecked_by.Text)
            cmd.Parameters.AddWithValue("@approved_by", txtApproved_by.Text)
            cmd.Parameters.AddWithValue("@status", "PENDING")
            cmd.Parameters.AddWithValue("@n", n)

            public_po_id = cmd.ExecuteScalar()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
            If n = 3 Then
                MessageBox.Show("Data has successfully updated..", "EUS INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Data has successfully saved..", "EUS INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Try
    End Sub

    Public Sub INSERT_INTO_dbPurchase_order_items(ByVal proc_po_id As Integer, ByVal proc_pono As Integer, _
                                                  ByVal proc_wh_id As Integer, ByVal proc_wh_desc As String, _
                                                  ByVal proc_qty As Integer, ByVal proc_unit As String, _
                                                  ByVal proc_price As Double, ByVal proc_amount As Double, ByVal rs_id As Integer)
        Try
            SQ.connection.Open()


            cmd = New SqlCommand("proc_purchase_order_query", SQ.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@proc_po_id", proc_po_id)
            cmd.Parameters.AddWithValue("@proc_pono", proc_pono)
            cmd.Parameters.AddWithValue("@proc_wh_id", proc_wh_id)
            cmd.Parameters.AddWithValue("@proc_wh_desc", proc_wh_desc)
            cmd.Parameters.AddWithValue("@proc_qty", proc_qty)
            cmd.Parameters.AddWithValue("@proc_unit", proc_unit)
            cmd.Parameters.AddWithValue("@proc_price", proc_price)
            cmd.Parameters.AddWithValue("@proc_amount", proc_amount)
            cmd.Parameters.AddWithValue("@rs_id", rs_id)
            cmd.Parameters.AddWithValue("@n", 2)

            cmd.ExecuteReader()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtPoNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPoNo.KeyDown
        If Not (e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 48 Or e.KeyValue = 49 Or e.KeyValue = 50 Or e.KeyValue = 51 Or e.KeyValue = 52 Or e.KeyValue = 53 Or e.KeyValue = 54 Or _
        e.KeyValue = 55 Or e.KeyValue = 56 Or e.KeyValue = 57 Or e.KeyValue = 96 Or e.KeyValue = 97 Or e.KeyValue = 98 Or e.KeyValue = 99 Or _
        e.KeyCode = Keys.OemPeriod Or _
       e.KeyValue = 100 Or e.KeyValue = 101 Or e.KeyValue = 102 Or e.KeyValue = 103 Or e.KeyValue = 104 Or e.KeyValue = 105 Or e.KeyValue = 37 Or e.KeyValue = 39) Then

            e.SuppressKeyPress() = True
        End If
    End Sub

    Private Sub txtPoNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPoNo.TextChanged

    End Sub
    Public Sub txt_color_change_if_focus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPoNo.GotFocus, txt_SupplierLocation.GotFocus, _
    txt_SupplierName.GotFocus, txtAddress.GotFocus, txtApproved_by.GotFocus, txtChargeTo.GotFocus, txtChecked_by.GotFocus, _
    txtInstructions.GotFocus, txtPrepared_by.GotFocus, txtRsNo.GotFocus, txtTerms.GotFocus, txtTerm.GotFocus

        Dim textbox As TextBox = sender

        textbox.BackColor = Color.Yellow

        If txtPrepared_by.Focused Then
            name1 = txtPrepared_by.Name
            txtPrepared_by.SelectAll()
        ElseIf txtChecked_by.Focused Then
            name1 = txtChecked_by.Name
            txtChecked_by.SelectAll()
        ElseIf txtApproved_by.Focused Then
            name1 = txtApproved_by.Name
            txtApproved_by.SelectAll()
        End If

    End Sub

    Private Sub txtPrepared_by_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrepared_by.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
            If lbox_data.Visible = True Then
                If lbox_data.Items.Count > 0 Then
                    lbox_data.Focus()
                    lbox_data.SelectedIndex = 0

                End If
            Else
                'If lbox_receivedby.Items.Count > 0 Then
                '    lbox_receivedby.Focus()
                '    lbox_receivedby.Items(0).Selected = False
                'End If
            End If
        End If
    End Sub

    Private Sub txtChecked_by_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtChecked_by.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
            If lbox_data.Visible = True Then
                If lbox_data.Items.Count > 0 Then
                    lbox_data.Focus()
                    lbox_data.SelectedIndex = 0

                End If
            Else
                'If lbox_receivedby.Items.Count > 0 Then
                '    lbox_receivedby.Focus()
                '    lbox_receivedby.Items(0).Selected = False
                'End If
            End If
        End If
    End Sub

    Private Sub txtApproved_by_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtApproved_by.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
            If lbox_data.Visible = True Then
                If lbox_data.Items.Count > 0 Then
                    lbox_data.Focus()
                    lbox_data.SelectedIndex = 0

                End If
            Else
                'If lbox_receivedby.Items.Count > 0 Then
                '    lbox_receivedby.Focus()
                '    lbox_receivedby.Items(0).Selected = False
                'End If
            End If
        End If
    End Sub

    Public Sub txt_color_change_if_leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPoNo.Leave, txt_SupplierLocation.Leave, _
    txt_SupplierName.Leave, txtAddress.Leave, txtApproved_by.Leave, txtChargeTo.Leave, txtChecked_by.Leave, _
    txtInstructions.Leave, txtPrepared_by.Leave, txtRsNo.Leave, txtTerms.Leave

        Dim textbox As TextBox = sender

        textbox.BackColor = Color.White

    End Sub


    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click

        Panel_Supplier.Visible = True
        show_supplier_list()

        If lvList.SelectedItems.Count > 0 Then
            Dim index As Integer = lvList.Items.Count - 1

            lvList.Items(index).Selected = True
            lvList.Items(index).EnsureVisible()

        End If
    End Sub

    Private Sub show_supplier_list()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        lvList.Items.Clear()
        newSQ.connection.Open()
        Try

            Dim query As String = "SELECT * FROM dbSupplier order by Supplier_Id asc"
            newCMD = New SqlCommand(query, newSQ.connection)

            newDR = newCMD.ExecuteReader

            While newDR.Read

                Dim a(5) As String
                a(0) = newDR.Item(0).ToString
                a(1) = newDR.Item(1).ToString
                a(2) = newDR.Item(2).ToString
                a(3) = newDR.Item(3).ToString

                Dim lvl As New ListViewItem(a)
                lvList.Items.Add(lvl)

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'conn.connection.Close()
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Panel_Supplier.Hide()
        load_suppliers_list()

    End Sub

    Private Sub txt_SupplierName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_SupplierName.TextChanged

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If txt_SupplierName.Text <> "" And txt_SupplierLocation.Text <> "" Then
            If booleanOperator_Cancel = True Then
                btn_Update.Enabled = False
                txt_SupplierName.Text = ""
                txt_SupplierLocation.Text = ""
                lvList.Enabled = True
                btnAdd.Text = "Add"
            ElseIf btnAdd.Text = "Add" Then
                Insert_Supplier()
                txt_SupplierName.Text = ""
                txt_SupplierLocation.Text = ""
                txt_SupplierName.Focus()
                listfocus(lvList, n)
            End If
        End If

        load_suppliers_list()
        booleanOperator_Cancel = False

    End Sub

    Private Sub Insert_Supplier()

        SQ.connection.Open()

        Try
            Dim sqlComm As New SqlCommand()

            sqlComm.Connection = SQ.connection

            sqlComm.CommandText = "sp_Insert_Supplier"
            sqlComm.CommandType = CommandType.StoredProcedure
            sqlComm.Parameters.AddWithValue("@Supplier_Name", txt_SupplierName.Text)
            sqlComm.Parameters.AddWithValue("@Supplier_Location", txt_SupplierLocation.Text)
            sqlComm.Parameters.AddWithValue("@", txtTerm.Text)
            n = sqlComm.ExecuteScalar()
            SQ.connection.Close()

            MessageBox.Show("Successfully Saved...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)

            show_supplier_list()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'conn.connection.Close()
        End Try

    End Sub

    Private Sub btn_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Update.Click
        Dim ex = MsgBox("Are you sure u want to update the SELECTED item?", MsgBoxStyle.YesNo, "Information")
        If ex = MsgBoxResult.Yes Then
            UpdateRecord_Supplier()
            listfocus(lvList, n)
            btnAdd.Text = "Add"
            btn_Update.Enabled = False
            lvList.Enabled = True
        Else
        End If

        booleanOperator_Cancel = False
    End Sub


    Private Sub UpdateRecord_Supplier()
        n = Val(lvList.SelectedItems(0).Text)
        Try
            SQ.connection.Open()
            Dim sqlComm As New SqlCommand

            sqlComm.Connection = SQ.connection
            sqlComm.CommandText = "sp_Update_Supplier"
            sqlComm.CommandType = CommandType.StoredProcedure
            sqlComm.Parameters.AddWithValue("@Supplier_Name", txt_SupplierName.Text)
            sqlComm.Parameters.AddWithValue("@Supplier_Location", txt_SupplierLocation.Text)
            sqlComm.Parameters.AddWithValue("@Supplier_terms", txtTerm.Text)
            sqlComm.Parameters.AddWithValue("@Supplier_Id", n)
            sqlComm.ExecuteNonQuery()

            show_supplier_list()
            txt_SupplierName.Text = ""
            txt_SupplierLocation.Text = ""
            txtTerm.Clear()

            txt_SupplierName.Focus()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim ex = MsgBox("Are you sure u want to DELETE the SELECTED item?", MsgBoxStyle.YesNo, "ERROR")
        If ex = MsgBoxResult.Yes Then
            DeleteRecord_Supplier()
            listfocus(lvList, x)
            txt_SupplierName.Text = ""
            txt_SupplierLocation.Text = ""
            btn_Update.Enabled = False
            btnAdd.Text = "Add"
        Else
        End If
        load_suppliers_list()
        booleanOperator_Cancel = False
    End Sub


    Private Sub DeleteRecord_Supplier()
        n = Val(lvList.SelectedItems(0).Text)

        Try
            SQ.connection.Open()
            Dim sqlComm As New SqlCommand

            sqlComm.Connection = SQ.connection
            sqlComm.CommandText = "sp_Delete_Supplier"
            sqlComm.CommandType = CommandType.StoredProcedure
            sqlComm.Parameters.AddWithValue("@Supplier_Id", n)
            x = n + 1

            sqlComm.ExecuteNonQuery()

            show_supplier_list()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        If lvList.SelectedItems.Count > 0 Then
            lvList.Enabled = False
            txt_SupplierName.Text = lvList.SelectedItems.Item(0).SubItems(1).Text
            txt_SupplierLocation.Text = lvList.SelectedItems.Item(0).SubItems(2).Text
            txtTerm.Text = lvList.SelectedItems.Item(0).SubItems(3).Text

            btnAdd.Text = "Cancel"
            btn_Update.Enabled = True
            booleanOperator_Cancel = True
        End If
    End Sub

    Public Sub get_dataPO(ByVal x As Integer)
        lbox_data.Items.Clear()
        Dim counter As Integer = 0
        Try
            SQ.connection.Open()
            Dim dr As SqlDataReader
            Dim cmd As New SqlCommand("proc_purchase_order_query", SQ.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            If x = 0 Then
                cmd.Parameters.AddWithValue("@prepared_by", txtPrepared_by.Text)
                cmd.Parameters.AddWithValue("@n", 10)
            ElseIf x = 1 Then
                cmd.Parameters.AddWithValue("@checked_by", txtChecked_by.Text)
                cmd.Parameters.AddWithValue("@n", 11)
            ElseIf x = 2 Then
                cmd.Parameters.AddWithValue("@approved_by", txtApproved_by.Text)
                cmd.Parameters.AddWithValue("@n", 12)
            End If
            dr = cmd.ExecuteReader
            If dr.HasRows = False Then
                lbox_data.Visible = False
            Else
                While dr.Read
                    If x = 0 Then
                        Dim get_prepareBY As String = dr.Item("prepared_by").ToString
                        lbox_data.Items.Add(get_prepareBY)
                        counter += 1
                    ElseIf x = 1 Then
                        Dim get_checkedBy As String = dr.Item("checked_by").ToString
                        lbox_data.Items.Add(get_checkedBy)
                        counter += 1
                    ElseIf x = 2 Then
                        Dim get_approvedby As String = dr.Item("approved_by").ToString
                        lbox_data.Items.Add(get_approvedby)
                        counter += 1
                    End If
                    If counter > 0 Then
                        lbox_data.Visible = True
                    Else
                        lbox_data.Visible = False
                    End If
                End While
                dr.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub lvList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvList.DoubleClick

        cmbSupplier.Text = lvList.SelectedItems(0).SubItems(1).Text
        Panel_Supplier.Hide()

    End Sub

#Region "btnGUI"
    Private Sub btnExit_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnExit.MouseDown
        btnExit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.MouseEnter
        btnExit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.MouseLeave
        btnExit.BackgroundImage = My.Resources.close_button
    End Sub

    Private Sub Button3_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button3.MouseDown
        Button3.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub Button3_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.MouseEnter
        Button3.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub Button3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.MouseLeave
        Button3.BackgroundImage = My.Resources.close_button
    End Sub
#End Region

    Private Sub txtPrepared_by_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrepared_by.TextChanged
        lbox_data.Location = New Point(txtPrepared_by.Width + 528, 128)
        lbox_data.Width = txtPrepared_by.Width
        If txtPrepared_by.Focus = True Then
            lbox_data.Visible = True
            get_dataPO(0)
        Else
            lbox_data.Visible = False
        End If
    End Sub

    Private Sub lbox_data_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbox_data.DoubleClick
        If lbox_data.SelectedItems.Count > 0 Then
            For Each ctr As Control In Me.Controls
                If ctr.Name = name1 Then
                    ctr.Text = lbox_data.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next
            lbox_data.Visible = False
        Else
            MessageBox.Show("Pls select data", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        
    End Sub

    Private Sub lbox_data_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lbox_data.KeyDown
        If e.KeyCode = Keys.Enter Then
            For Each ctr As Control In Me.Controls
                If ctr.Name = name1 Then
                    ctr.Text = lbox_data.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next
            lbox_data.Visible = False
        End If
    End Sub

    Private Sub lbox_data_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbox_data.SelectedIndexChanged

    End Sub

    Private Sub txtChecked_by_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChecked_by.TextChanged
        lbox_data.Location = New Point(txtPrepared_by.Width + 528, 158)
        lbox_data.Width = txtPrepared_by.Width
        If txtChecked_by.Focus = True Then
            lbox_data.Visible = True
            get_dataPO(1)
        Else
            lbox_data.Visible = False
        End If
    End Sub

    Private Sub txtApproved_by_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtApproved_by.TextChanged
        lbox_data.Location = New Point(txtApproved_by.Width + 528, 190)
        lbox_data.Width = txtApproved_by.Width
        If txtApproved_by.Focus = True Then
            lbox_data.Visible = True
            get_dataPO(2)
        Else
            lbox_data.Visible = False
        End If
    End Sub

End Class
