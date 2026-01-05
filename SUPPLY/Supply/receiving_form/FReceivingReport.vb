Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FReceivingReport
    Dim SQLcon As New SQLcon
    Dim sqldr As SqlDataReader
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim x As String
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Dim pub_textbox As TextBox
    Dim backspace As Boolean
    Dim n As Integer
    Dim name1 As String
    Dim booleanOperator_Cancel As Boolean = False
    Dim y As Integer

    Dim old_price_value As Double
    Dim old_qty As Double

    Dim rowind As Integer
    Dim mArray(50, 50) As String
    Private Sub FReceivingReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtPOno.Enabled = False
        txtRSNo.Enabled = False
        txtSOno.Text = "none"
        txtHauler.Text = "n/a"
        txtPlateNo.Text = "n/a"
        ListBox1.Visible = False
        cmbSupplier.Enabled = True
        'Panel_Supplier.Visible = False

        load_suppliers_list()
        'view_receiving()

        Receiving_function()

        '**for listbox gone 
        For Each ctr As Control In Panel1.Controls

            If TypeOf ctr Is Button Then
                AddHandler ctr.GotFocus, AddressOf CommonHandler
            ElseIf TypeOf ctr Is TextBox Then
                AddHandler ctr.GotFocus, AddressOf CommonHandler
            ElseIf TypeOf ctr Is ComboBox Then
                AddHandler ctr.GotFocus, AddressOf CommonHandler
            ElseIf TypeOf ctr Is DateTimePicker Then
                AddHandler ctr.GotFocus, AddressOf CommonHandler
            End If
        Next

    End Sub
    Private Sub CommonHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If ListBox1.Visible = True Then
            ListBox1.Visible = False
        End If

    End Sub

    Public Function is_partially_received(rs_id As Integer) As Boolean
        Dim exist As Integer = check_if_exist("dbreceiving_items", "rs_id", rs_id, 1)
        Dim rr_qty As Integer = get_received_sub_amount_and_qty(rs_id, 2, 0)
        Dim rs_qty As Integer = get_rs_qty(rs_id)

        If rr_qty = rs_qty Then
            is_partially_received = False
        ElseIf rr_qty < rs_qty
            is_partially_received = True
        End If
    End Function
    Public Function get_rs_qty(rs_id As Integer) As Decimal
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 10)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_rs_qty = CDec(newDR.Item("qty").ToString())
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Function
    Public Sub Receiving_function()
        Dim exist As Integer = check_if_exist("dbreceiving_items", "rs_id", rs_id, 1)

        If exist > 0 Then
            btnSave.Text = "Update"
            If type_purchasing = "PURCHASE ORDER" Then
                view_po_released("OTHERS", 11)
            ElseIf type_purchasing = "CASH" Then
                view_cv_released("OTHERS", 44)
            End If
        Else
            btnSave.Text = "Save"
            'king edit
            If type_purchasing = "PURCHASE ORDER" Then
                view_po_released("OTHERS", 1)
            ElseIf type_purchasing = "CASH" Then
                view_cv_released("OTHERS", 4)
            End If

        End If

    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
        Me.Dispose()
        clear_field()

    End Sub

    Public Sub clear_field()
        txtPOno.Clear()
        txtRSNo.Clear()
        txtInvoiceNo.Clear()
        ' txtSupplier.Clear()
        cmbSupplier.Text = Nothing
        txtRRno.Clear()
        DTPReceived.Refresh()
        txtReceivedby.Clear()
        txtCheckedby.Clear()
        lbl_invoiceID.Text = ""
        'txtSupplier.Text = ""
        cmbSupplier.Text = ""

    End Sub

    Private Sub FReceivingReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            btnReceive.PerformClick()
        End If
    End Sub

  
    Public Sub view_po_released(ByVal type As String, ByVal n As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim a(15) As String
        Dim c As Integer = 0

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@type", type)

            If btnSave.Text = "Update" Then
                newCMD.Parameters.AddWithValue("@n", n)
                newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            ElseIf btnSave.Text = "Save" Then
                newCMD.Parameters.AddWithValue("@n", n)
                newCMD.Parameters.AddWithValue("@rs_no", rs_no)
            End If

            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim rs_id As Integer = CInt(newDR.Item("rs_id").ToString)
                Dim exist As Integer = check_if_exist("dbreceiving_items", "rs_id", rs_id, 1)

                If exist > 0 Then
                    If btnSave.Text = "Update" Then
                        lblrr_info_id.Text = newDR.Item("rr_info_id").ToString
                    ElseIf btnSave.Text = "Save" Then
                        GoTo proceedhere
                    End If

                End If

                Dim po_det_id As Integer = CInt(newDR.Item("po_det_id").ToString)
                Dim sub_amount As Double = get_total_amount(CInt(newDR.Item("rr_item_id").ToString), 1, po_det_id)
                Dim sub_qty As Double = get_received_sub_amount_and_qty(CInt(newDR.Item("rs_id").ToString), 2, po_det_id)
                Dim Samount As Double = get_received_sub_amount_and_qty(CInt(newDR.Item("rs_id").ToString), 3, po_det_id)
                Dim po_qty As Decimal = CDec(newDR.Item("qty").ToString)

                a(1) = newDR.Item("po_no").ToString
                a(2) = newDR.Item("ITEM_NAME").ToString
                a(3) = po_qty
                a(4) = sub_qty
                'a(4) = FormatNumber(CDbl(newDR.Item("UNIT_AMOUNT").ToString), 2, , TriState.True)
                a(5) = Samount
                a(6) = newDR.Item("ITEM_DESC").ToString
                a(7) = multiplecharges(newDR.Item("rs_id").ToString, 1)
                a(9) = newDR.Item("wh_id").ToString
                a(10) = newDR.Item("rs_id").ToString
                a(11) = newDR.Item("IN_OUT").ToString
                a(14) = po_det_id

                'remarks
                If btnSave.Text = "Save" Then
                    a(8) = ""
                    a(12) = 0
                ElseIf btnSave.Text = "Update" Then
                    a(8) = newDR.Item("remarks").ToString
                    a(12) = newDR.Item("rr_item_id").ToString
                End If

                'If check_if_exist("dbreceiving_items", "po_det_id", po_det_id, 1) > 0 Then
                If po_qty = sub_qty Then

                    DataGridView1.Rows.Add(a)

                ElseIf po_qty > sub_qty

                    dgReceivingItem.Rows.Add(a)

                End If

                'End If

                For Each row As DataGridViewRow In dgReceivingItem.Rows
                    If row.Cells(11).Value = "FACILITIES" Or row.Cells(11).Value = "TOOLS" Or row.Cells(11).Value = "ADD-ON" Then

                        row.Cells(6).ReadOnly = True
                        row.Cells(9).ReadOnly = True
                        row.Cells(10).ReadOnly = True
                        row.Cells(11).ReadOnly = True
                        row.Cells(12).ReadOnly = True

                    Else
                        row.Cells(9).ReadOnly = True
                        row.Cells(10).ReadOnly = True
                        row.Cells(11).ReadOnly = True
                        row.Cells(12).ReadOnly = True
                    End If
                Next
proceedhere:

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

        End Try
    End Sub
    Public Function get_received_sub_amount_and_qty(rs_id As Integer, n As Integer, po_det_id As Integer) As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 9)
            'newCMD.Parameters.AddWithValue("@rr_item_id", rr_item_id)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                If n = 1 Then
                    get_received_sub_amount_and_qty += CDbl(newDR.Item("amount").ToString)
                ElseIf n = 2 Then
                    get_received_sub_amount_and_qty += CDbl(newDR.Item("qty").ToString)
                ElseIf n = 3 Then
                    get_received_sub_amount_and_qty += CDbl(newDR.Item("amount").ToString) * CDbl(newDR.Item("qty").ToString)
                ElseIf n = 4
                    ' get_received_sub_amount_and_qty += 
                End If

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function

    Public Function get_total_amount(rr_item_id As Integer, n As Integer, po_det_id As Integer) As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 99)
            'newCMD.Parameters.AddWithValue("@rr_item_id", rr_item_id)
            newCMD.Parameters.AddWithValue("@rr_item_id", rr_item_id)
            newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                If n = 1 Then
                    get_total_amount += CDbl(newDR.Item("amount").ToString)
                ElseIf n = 2 Then
                    get_total_amount += CDbl(newDR.Item("qty").ToString)
                ElseIf n = 3 Then
                    get_total_amount += CDbl(newDR.Item("amount").ToString) * CDbl(newDR.Item("qty").ToString)
                ElseIf n = 4
                    ' get_received_sub_amount_and_qty += 
                End If

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Sub view_cv_released(ByVal type As String, ByVal n As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim a(15) As String
        Dim c As Integer = 0

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@type", type)

            If btnSave.Text = "Update" Then
                newCMD.Parameters.AddWithValue("@n", n)
                newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            ElseIf btnSave.Text = "Save" Then
                newCMD.Parameters.AddWithValue("@n", n)
                newCMD.Parameters.AddWithValue("@rs_no", rs_no)
            End If

            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim rs_id As Integer = CInt(newDR.Item("rs_id").ToString)
                Dim rr_exist As Integer = check_if_exist("dbreceiving_items", "rs_id", rs_id, 1)

                If rr_exist > 0 Then
                    If btnSave.Text = "Update" Then
                        lblrr_info_id.Text = newDR.Item("rr_info_id").ToString
                    ElseIf btnSave.Text = "Save" Then
                        GoTo proceedhere
                    End If

                End If

                a(1) = newDR.Item("cv_no").ToString
                a(2) = newDR.Item("ITEM_NAME").ToString
                a(3) = newDR.Item("cv_qty").ToString
                a(4) = FormatNumber(CDbl(newDR.Item("UNIT_AMOUNT").ToString), 2, , TriState.True)
                a(5) = newDR.Item("ITEM_DESC").ToString
                a(6) = multiplecharges(newDR.Item("rs_id").ToString, 1)
                a(8) = newDR.Item("wh_id").ToString
                a(9) = newDR.Item("rs_id").ToString
                a(10) = newDR.Item("IN_OUT").ToString
                a(11) = newDR.Item("rr_item_id").ToString

                dgReceivingItem.Rows.Add(a)

                If rr_exist > 0 Then
                    dgReceivingItem.Rows(c).Cells(0).Value = True
                End If

                c += 1

                For Each row As DataGridViewRow In dgReceivingItem.Rows
                    If row.Cells(10).Value = "FACILITIES" Or row.Cells(10).Value = "TOOLS" Or row.Cells(10).Value = "ADD-ON" Then

                        row.Cells(3).ReadOnly = True
                        row.Cells(8).ReadOnly = True
                        row.Cells(9).ReadOnly = True
                        row.Cells(10).ReadOnly = True
                        row.Cells(11).ReadOnly = True

                    Else
                        row.Cells(8).ReadOnly = True
                        row.Cells(9).ReadOnly = True
                        row.Cells(10).ReadOnly = True
                        row.Cells(11).ReadOnly = True
                    End If
                Next

proceedhere:



            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

            For Each row As DataGridViewRow In dgReceivingItem.Rows
                If row.Cells(10).Value = "FACILITIES" Or row.Cells(10).Value = "TOOLS" Or row.Cells(10).Value = "ADD-ON" Then
                    row.Cells(5).ReadOnly = True
                End If

            Next
        End Try
    End Sub

    Public Function multiplecharges(ByVal rs_id As Integer, ByVal n As Integer) As String

        If n = 1 Then
            multiplecharges = "ADFIL"
        ElseIf n = 2 Then
            multiplecharges = "OUTSOURCE"
        End If

        Dim mcharges As String = get_multiple_charges(rs_id)

        If mcharges.Length < 1 Then
        Else

            mcharges = mcharges.Trim().Substring(0, mcharges.Length - 1)
            multiplecharges = multiplecharges & "(" & UCase(mcharges) & ")"

        End If
    End Function

    Public Sub view_receiving()

        If receiving_inout = "OTHERS" Then
            If check_if_exist("dbreceiving_info", "rs_no", Val(rs_no), 0) > 0 Then
                load_from_rr_info(2)
                load_from_rr_item()
                btnSave.Text = "Update"
            Else
                view_from_PO()
                btnSave.Text = "Save"
            End If

        ElseIf type_purchasing = "PURCHASE ORDER" Then
            If receiving_inout = "FACILITIES" Or receiving_inout = "TOOLS" Or receiving_inout = "ADD-ON" Then
                If check_if_exist("dbreceiving_info", "po_no", Val(po_no), 0) > 0 Then
                    load_from_rr_info(1)
                    load_from_rr_item()
                    btnSave.Text = "Update"
                Else
                    view_from_PO()
                    btnSave.Text = "Save"
                End If

            ElseIf receiving_inout = "IN" Then
                If check_if_exist("dbreceiving_info", "po_no", Val(po_no), 0) > 0 Then
                    load_from_rr_info(1)
                    load_from_rr_item()
                    btnSave.Text = "Update"
                Else
                    view_from_PO()
                    btnSave.Text = "Save"
                End If
            End If

        ElseIf type_purchasing = "CASH" Then
            If receiving_inout = "FACILITIES" Or receiving_inout = "TOOLS" Or receiving_inout = "ADD-ON" Then
                If check_if_exist("dbreceiving_info", "rs_no", Val(rs_no), 0) > 0 Then
                    load_from_rr_info(2)
                    load_from_rr_item()
                    btnSave.Text = "Update"
                Else
                    view_from_PO()
                    btnSave.Text = "Save"
                End If

            ElseIf receiving_inout = "IN" Then
                If check_if_exist("dbreceiving_info", "rs_no", Val(rs_no), 0) > 0 Then
                    load_from_rr_info(2)
                    load_from_rr_item()
                    btnSave.Text = "Update"
                Else
                    view_from_PO()
                    btnSave.Text = "Save"
                End If
            End If

        Else

        End If


    End Sub

#Region "OLD"
    'If receiving_inout = "OTHERS" Then
    '    If check_if_exist("dbreceiving_info", "rs_no", Val(rs_no), 0) > 0 Then
    '        load_from_rr_info(2)
    '        load_from_rr_item()
    '        btnSave.Text = "Update"
    '    Else
    '        view_item_info_PO()
    '        btnSave.Text = "Save"
    '    End If

    'ElseIf receiving_inout = "FACILITIES" Then

    '    'If check_if_exist("dbreceiving_info", "po_no", Val(po_no), 0) > 0 Then
    '    '    load_from_rr_info(1)
    '    '    load_from_rr_item()
    '    '    btnSave.Text = "Update"
    '    'Else
    '    MsgBox("MAO NI")
    '    view_item_info_PO()
    '    btnSave.Text = "Save"
    '    'End If

    'Else
    '    If check_if_exist("dbreceiving_info", "po_no", Val(po_no), 0) > 0 Then
    '        load_from_rr_info(1)
    '        load_from_rr_item()
    '        btnSave.Text = "Update"
    '    Else
    '        view_item_info_PO()
    '        btnSave.Text = "Save"
    '    End If
    'End If
#End Region

    Public Sub load_suppliers_list()
        cmbSupplier.Items.Clear()
      
        Try
            SQLcon.connection.Open()
            publicquery = "SELECT Supplier_Name FROM dbSupplier"
            cmd = New SqlCommand(publicquery, SQLcon.connection)
            sqldr = cmd.ExecuteReader
            While sqldr.Read
                cmbSupplier.Items.Add(sqldr.Item("Supplier_Name").ToString)
            End While
            sqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()

        End Try
    End Sub

    Public Sub load_from_rr_info(ByVal n As Integer)

        If n = 1 Then

            Try
                SQLcon.connection.Open()
                publicquery = "SELECT * FROM dbreceiving_info WHERE po_no = " & po_no

                cmd = New SqlCommand(publicquery, SQLcon.connection)
                sqldr = cmd.ExecuteReader
                While sqldr.Read

                    lblInfo_ID.Text = sqldr.Item("rr_info_id").ToString
                    'lbl_rr_item.Text = sqldr.Item("rr_item_id").ToString
                    txtReceivedby.Text = sqldr.Item("received_by").ToString
                    txtCheckedby.Text = sqldr.Item("checked_by").ToString
                    'txtSupplier.Text = sqldr.Item("supplier").ToString
                    cmbSupplier.Text = sqldr.Item("supplier").ToString
                    txtInvoiceNo.Text = sqldr.Item("invoice_no").ToString
                    txtRRno.Text = sqldr.Item("rr_no").ToString
                    txtPOno.Text = sqldr.Item("po_no").ToString
                    DTPReceived.Text = sqldr.Item("date_received").ToString
                    txtRSNo.Text = sqldr.Item("rs_no").ToString
                    txtSOno.Text = sqldr.Item("so_no").ToString
                    txtHauler.Text = sqldr.Item("hauler").ToString
                    txtPlateNo.Text = sqldr.Item("plateno").ToString

                End While
                sqldr.Close()
            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                SQLcon.connection.Close()
            End Try

        ElseIf n = 2 Then

            Try
                SQLcon.connection.Open()
                publicquery = "SELECT * FROM dbreceiving_info WHERE rs_no = " & rs_no

                cmd = New SqlCommand(publicquery, SQLcon.connection)
                sqldr = cmd.ExecuteReader
                While sqldr.Read

                    lblInfo_ID.Text = sqldr.Item("rr_info_id").ToString
                    txtReceivedby.Text = sqldr.Item("received_by").ToString
                    txtCheckedby.Text = sqldr.Item("checked_by").ToString
                    'txtSupplier.Text = sqldr.Item("supplier").ToString
                    cmbSupplier.Text = sqldr.Item("supplier").ToString
                    txtInvoiceNo.Text = sqldr.Item("invoice_no").ToString
                    txtRRno.Text = sqldr.Item("rr_no").ToString
                    txtPOno.Text = sqldr.Item("po_no").ToString
                    DTPReceived.Text = sqldr.Item("date_received").ToString
                    txtRSNo.Text = sqldr.Item("rs_no").ToString
                    txtSOno.Text = sqldr.Item("so_no").ToString
                    txtHauler.Text = sqldr.Item("hauler").ToString
                    txtPlateNo.Text = sqldr.Item("plateno").ToString

                End While
                sqldr.Close()
            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                SQLcon.connection.Close()
            End Try

        End If

    End Sub

    Public Sub load_from_rr_item()
        dgReceivingItem.Rows.Clear()

        Try
            SQLcon.connection.Open()

            If receiving_inout = "OTHERS" Then
                'publicquery = "SELECT a.rr_item_id,a.wh_id,a.qty,a.item_description,a.remarks,a.rs_id,c.item_desc FROM dbreceiving_items a "
                'publicquery &= "INNER JOIN dbreceiving_info b ON a.rr_info_id = b.rr_info_id "
                'publicquery &= "INNER JOIN dbrequisition_slip c ON a.rs_id = c.rs_id"
                'publicquery &= "WHERE b.rs_no = " & rs_no

                publicquery = "SELECT " & _
                "a.rr_item_id," & _
                "a.wh_id," & _
                "a.qty," & _
                "a.item_description," & _
                "a.remarks," & _
                "a.rs_id," & _
                "c.item_desc," & _
                "b.rs_no " & _
                "FROM " & _
                "dbreceiving_items a " & _
                "INNER JOIN dbreceiving_info b " & _
                "ON a.rr_info_id = b.rr_info_id " & _
                "INNER JOIN dbPO_details c " & _
                "ON a.rs_id = c.rs_id " & _
                "WHERE b.rs_no = '" & rs_no & "'"


            ElseIf type_purchasing = "PURCHASE ORDER" Then
                If receiving_inout = "FACILITIES" Or receiving_inout = "TOOLS" Or receiving_inout = "ADD-ON" Then

                    publicquery = "SELECT DISTINCT a.rr_item_id,a.rr_info_id,a.rr_no,a.invoice_no,a.wh_id,d.facility_name,a.qty,a.item_description,a.remarks,a.rs_id " & _
                    "FROM dbreceiving_items a " & _
                    "INNER JOIN dbPO_details c ON a.wh_id = c.wh_id " & _
                    "INNER JOIN dbfacilities_names d ON d.fac_id = a.wh_id " & _
                    "INNER JOIN dbreceiving_info b ON a.rr_info_id = b.rr_info_id WHERE b.po_no = " & po_no

                ElseIf receiving_inout = "IN" Then

                    publicquery = "SELECT a.rr_item_id,a.rr_info_id,a.rr_no,a.invoice_no,a.wh_id,a.qty,a.item_description,c.whItem,a.remarks,a.rs_id " & _
                    "FROM dbreceiving_items a " & _
                    "INNER JOIN dbwarehouse_items c ON a.wh_id = c.wh_id " & _
                    "INNER JOIN dbreceiving_info b ON a.rr_info_id = b.rr_info_id WHERE b.po_no = " & po_no

                End If

            ElseIf type_purchasing = "CASH" Then

                If receiving_inout = "FACILITIES" Or receiving_inout = "TOOLS" Then
                    publicquery = "SELECT DISTINCT a.rr_item_id,a.rr_info_id,a.rr_no,a.invoice_no,a.wh_id,d.facility_name,a.qty,a.item_description,a.remarks,a.rs_id " & _
                    "FROM dbreceiving_items a " & _
                    "INNER JOIN dbPO_details c ON a.wh_id = c.wh_id " & _
                    "INNER JOIN dbfacilities_names d ON d.fac_id = a.wh_id " & _
                    "INNER JOIN dbreceiving_info b ON a.rr_info_id = b.rr_info_id WHERE b.rs_no = " & rs_no

                ElseIf receiving_inout = "IN" Then

                    publicquery = "SELECT a.rr_item_id,a.rr_info_id,a.rr_no,a.invoice_no,a.wh_id,a.qty,a.item_description,c.whItem,a.remarks,a.rs_id " & _
                    "FROM dbreceiving_items a " & _
                    "INNER JOIN dbwarehouse_items c ON a.wh_id = c.wh_id " & _
                    "INNER JOIN dbreceiving_info b ON a.rr_info_id = b.rr_info_id WHERE b.rs_no = " & rs_no

                End If

            Else

            End If

            cmd = New SqlCommand(publicquery, SQLcon.connection)
            sqldr = cmd.ExecuteReader
            While sqldr.Read

                Dim a(10) As String

                a(0) = sqldr.Item("rr_item_id").ToString
                a(1) = sqldr.Item("wh_id").ToString
                a(3) = sqldr.Item("qty").ToString
                a(6) = sqldr.Item("remarks").ToString

                If type_purchasing = "CASH" Then
                    If receiving_inout = "OTHERS" Then

                        a(2) = sqldr.Item("item_description").ToString
                        a(4) = sqldr.Item("item_description").ToString

                    ElseIf receiving_inout = "IN" Then

                        a(2) = get_item_name(sqldr.Item("wh_id").ToString, 1)
                        a(3) = sqldr.Item("qty").ToString
                        a(4) = sqldr.Item("item_description").ToString

                    ElseIf receiving_inout = "FACILITIES" Or receiving_inout = "TOOLS" Or receiving_inout = "ADD-ON" Then

                        a(2) = sqldr.Item("facility_name").ToString
                        a(3) = sqldr.Item("qty").ToString
                        a(4) = sqldr.Item("item_description").ToString

                    End If

                ElseIf type_purchasing = "PURCHASE ORDER" Then
                    If receiving_inout = "FACILITIES" Or receiving_inout = "TOOLS" Or receiving_inout = "ADD-ON" Then

                        a(2) = sqldr.Item("facility_name").ToString
                        a(3) = sqldr.Item("qty").ToString
                        a(4) = sqldr.Item("item_description").ToString

                    ElseIf receiving_inout = "OTHERS" Then

                        a(2) = sqldr.Item("item_desc").ToString
                        a(3) = sqldr.Item("qty").ToString
                        a(4) = sqldr.Item("item_description").ToString

                    End If

                End If

                charge_to_id = get_charge_to_id(sqldr.Item("rs_id").ToString)

                Select Case type_charges
                    Case "EQUIPMENT"
                        a(5) = GET_equip_desc_AND_proj_desc(charge_to_id, 1)
                    Case "PROJECT"
                        a(5) = GET_equip_desc_AND_proj_desc(charge_to_id, 2)
                    Case "WAREHOUSE"
                        a(5) = GET_equip_desc_AND_proj_desc(charge_to_id, 4)
                    Case "PERSONAL"
                        a(5) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                    Case "CASH"
                        a(5) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                    Case "ADFIL"
                        a(5) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)

                        If a(5) = "ADFIL" Then
                            Dim mcharges As String = get_multiple_charges(sqldr.Item("rs_id").ToString)

                            If mcharges.Length < 1 Then
                            Else
                                mcharges = mcharges.Trim().Substring(0, mcharges.Length - 1)
                                a(5) = a(5) & "(" & UCase(mcharges) & ")"
                            End If

                        End If
                End Select



                dgReceivingItem.Rows.Add(a)

            End While
            sqldr.Close()

            dgReceivingItem.AllowUserToAddRows = False

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub

    Public Sub view_from_PO()
        dgReceivingItem.Rows.Clear()
        'Dim row As Integer

        Dim RS_NO As String = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(1).Text
       
        Try
            SQLcon.connection.Open()
            cmd = New SqlCommand("proc_receiving_crud", SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure

            If receiving_inout = "OTHERS" Then
                ' MsgBox("OTHERS 2")
                cmd.Parameters.AddWithValue("@crud", 77)
                cmd.Parameters.AddWithValue("@rsNo", RS_NO)

                'ElseIf receiving_inout = "FACILITIES" Or receiving_inout = "TOOLS" Then
                '    'MsgBox("FACILTIES 2")
                '    cmd.Parameters.AddWithValue("@crud", 9)
                '    cmd.Parameters.AddWithValue("@POno", po_no)

            ElseIf type_purchasing = "PURCHASE ORDER" Then

                If receiving_inout = "FACILITIES" Or receiving_inout = "TOOLS" Or receiving_inout = "ADD-ON" Then
                    cmd.Parameters.AddWithValue("@crud", 9)
                    cmd.Parameters.AddWithValue("@POno", po_no)

                ElseIf receiving_inout = "IN" Then
                    cmd.Parameters.AddWithValue("@crud", 1)
                    cmd.Parameters.AddWithValue("@POno", po_no)
                End If

            ElseIf type_purchasing = "CASH" Then

                If receiving_inout = "FACILITIES" Or receiving_inout = "TOOLS" Or receiving_inout = "ADD-ON" Then
                    cmd.Parameters.AddWithValue("@crud", 10)
                    cmd.Parameters.AddWithValue("@rsNo", RS_NO)

                ElseIf receiving_inout = "IN" Then
                    cmd.Parameters.AddWithValue("@crud", 11)
                    cmd.Parameters.AddWithValue("@rsNo", RS_NO)

                End If

            Else
                '    'MsgBox("IN 2")
                '    cmd.Parameters.AddWithValue("@crud", 1)
                '    cmd.Parameters.AddWithValue("@POno", po_no)

            End If

            sqldr = cmd.ExecuteReader

            While sqldr.Read

                Dim a(10) As String


                If receiving_inout = "OTHERS" Then
                    'MsgBox("OTHERS 3")

                    cmbSupplier.Enabled = False
                    PictureBox2.Enabled = False
                    cmbSupplier.Text = sqldr.Item("Supplier_Name").ToString

                    If type_purchasing = "PURCHASE ORDER" Then
                        a(1) = sqldr.Item("rs_id").ToString
                        a(2) = sqldr.Item("rs_id").ToString
                        a(3) = sqldr.Item("ITEM_DESC_A").ToString()
                        a(4) = sqldr.Item("qty").ToString
                        a(5) = sqldr.Item("ITEM_DESC_B").ToString()
                        a(8) = sqldr.Item("po_no").ToString


                    ElseIf type_purchasing = "CASH" Then
                        txtPOno.Text = 0

                        a(0) = sqldr.Item("rs_id").ToString
                        a(1) = sqldr.Item("wh_id").ToString
                        a(2) = sqldr.Item("cv_items").ToString()
                        a(3) = sqldr.Item("cv_qty").ToString
                        a(4) = sqldr.Item("cv_items").ToString()

                    End If

                    'a(0) = sqldr.Item("rs_id").ToString
                    'a(1) = sqldr.Item("wh_id").ToString
                    'a(2) = sqldr.Item("cv_items").ToString()
                    'a(3) = sqldr.Item("cv_qty").ToString
                    'a(4) = sqldr.Item("cv_items").ToString()

                    charge_to_id = get_charge_to_id(sqldr.Item("rs_id").ToString)
                    type_charges = "ADFIL"

                    Select Case type_charges
                        Case "EQUIPMENT"
                            a(6) = GET_equip_desc_AND_proj_desc(charge_to_id, 1)
                        Case "PROJECT"
                            a(6) = GET_equip_desc_AND_proj_desc(charge_to_id, 2)
                        Case "WAREHOUSE"
                            a(6) = GET_equip_desc_AND_proj_desc(charge_to_id, 4)
                        Case "PERSONAL"
                            a(6) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                        Case "CASH"
                            a(6) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                        Case "ADFIL"
                            a(6) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)

                            If a(6) = "ADFIL" Then
                                Dim mcharges As String = get_multiple_charges(sqldr.Item("rs_id").ToString)

                                If mcharges.Length < 1 Then
                                Else
                                    mcharges = mcharges.Trim().Substring(0, mcharges.Length - 1)
                                    a(6) = a(6) & "(" & UCase(mcharges) & ")"
                                End If

                            End If
                    End Select


                    dgReceivingItem.Rows.Add(a)

                ElseIf type_purchasing = "PURCHASE ORDER" Then
                    If receiving_inout = "FACILITIES" Or receiving_inout = "TOOLS" Or receiving_inout = "ADD-ON" Then
                        cmbSupplier.Text = sqldr.Item("Supplier_Name").ToString

                        a(0) = sqldr.Item("rs_id").ToString
                        a(1) = sqldr.Item("wh_id").ToString
                        a(2) = sqldr.Item("facility_name").ToString
                        a(3) = sqldr.Item("qty").ToString
                        a(4) = sqldr.Item("item_desc").ToString

                        charge_to_id = get_charge_to_id(sqldr.Item("rs_id").ToString)
                        type_charges = sqldr.Item("charge_type").ToString

                        Select Case type_charges
                            Case "EQUIPMENT"
                                a(5) = GET_equip_desc_AND_proj_desc(charge_to_id, 1)
                            Case "PROJECT"
                                a(5) = GET_equip_desc_AND_proj_desc(charge_to_id, 2)
                            Case "WAREHOUSE"
                                a(5) = GET_equip_desc_AND_proj_desc(charge_to_id, 4)
                            Case "PERSONAL"
                                a(5) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                            Case "CASH"
                                a(5) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                            Case "ADFIL"
                                a(5) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)

                                If a(5) = "ADFIL" Then
                                    Dim mcharges As String = get_multiple_charges(sqldr.Item("rs_id").ToString)

                                    If mcharges.Length < 1 Then
                                    Else
                                        mcharges = mcharges.Trim().Substring(0, mcharges.Length - 1)
                                        a(5) = a(5) & "(" & UCase(mcharges) & ")"
                                    End If

                                End If
                        End Select


                        dgReceivingItem.Rows.Add(a)

                    ElseIf receiving_inout = "IN" Then

                        txtPOno.Text = sqldr.Item("po_no").ToString
                        cmbSupplier.Text = sqldr.Item("Supplier_Name").ToString

                        a(0) = sqldr.Item("rs_id").ToString
                        a(1) = sqldr.Item("wh_id").ToString
                        a(2) = get_item_name(sqldr.Item("wh_id").ToString(), 1)
                        a(3) = sqldr.Item("qty").ToString
                        a(4) = get_item_name(sqldr.Item("wh_id").ToString(), 2)


                        charge_to_id = get_charge_to_id(sqldr.Item("rs_id").ToString)
                        type_charges = sqldr.Item("charge_type").ToString

                        Select Case type_charges
                            Case "EQUIPMENT"
                                a(5) = GET_equip_desc_AND_proj_desc(charge_to_id, 1)
                            Case "PROJECT"
                                a(5) = GET_equip_desc_AND_proj_desc(charge_to_id, 2)
                            Case "WAREHOUSE"
                                a(5) = GET_equip_desc_AND_proj_desc(charge_to_id, 4)
                            Case "PERSONAL"
                                a(5) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                            Case "CASH"
                                a(5) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                            Case "ADFIL"
                                a(5) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)

                                If a(5) = "ADFIL" Then
                                    Dim mcharges As String = get_multiple_charges(sqldr.Item("rs_id").ToString)

                                    If mcharges.Length < 1 Then
                                    Else
                                        mcharges = mcharges.Trim().Substring(0, mcharges.Length - 1)
                                        a(5) = a(5) & "(" & UCase(mcharges) & ")"
                                    End If

                                End If
                        End Select

                        dgReceivingItem.Rows.Add(a)

                    End If
                    'ElseIf receiving_inout = "FACILITIES" Or receiving_inout = "TOOLS" Then
                    '    'MsgBox("FACILITIES 3")
                    '    cmbSupplier.Text = sqldr.Item("Supplier_Name").ToString

                    '    a(0) = sqldr.Item("rs_id").ToString
                    '    a(1) = sqldr.Item("wh_id").ToString
                    '    a(2) = sqldr.Item("facility_name").ToString
                    '    a(3) = sqldr.Item("qty").ToString
                    '    a(4) = sqldr.Item("item_desc").ToString
                    '    dgReceivingItem.Rows.Add(a)
                ElseIf type_purchasing = "CASH" Then

                    If receiving_inout = "FACILITIES" Or receiving_inout = "TOOLS" Or receiving_inout = "ADD-ON" Then
                        cmbSupplier.Text = sqldr.Item("Supplier_Name").ToString
                        a(0) = sqldr.Item("rs_id").ToString
                        a(1) = sqldr.Item("wh_id").ToString
                        a(2) = sqldr.Item("facility_name").ToString
                        a(3) = sqldr.Item("cv_qty").ToString
                        a(4) = sqldr.Item("cv_items").ToString

                        charge_to_id = get_charge_to_id(sqldr.Item("rs_id").ToString)
                        type_charges = sqldr.Item("charge_type").ToString

                        Select Case type_charges
                            Case "EQUIPMENT"
                                a(5) = GET_equip_desc_AND_proj_desc(charge_to_id, 1)
                            Case "PROJECT"
                                a(5) = GET_equip_desc_AND_proj_desc(charge_to_id, 2)
                            Case "WAREHOUSE"
                                a(5) = GET_equip_desc_AND_proj_desc(charge_to_id, 4)
                            Case "PERSONAL"
                                a(5) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                            Case "CASH"
                                a(5) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                            Case "ADFIL"
                                a(5) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)

                                If a(5) = "ADFIL" Then
                                    Dim mcharges As String = get_multiple_charges(sqldr.Item("rs_id").ToString)

                                    If mcharges.Length < 1 Then
                                    Else
                                        mcharges = mcharges.Trim().Substring(0, mcharges.Length - 1)
                                        a(5) = a(5) & "(" & UCase(mcharges) & ")"
                                    End If

                                End If
                        End Select


                        dgReceivingItem.Rows.Add(a)

                    ElseIf receiving_inout = "IN" Then

                        txtPOno.Text = 0
                        cmbSupplier.Enabled = False
                        PictureBox2.Enabled = False
                        cmbSupplier.Text = sqldr.Item("Supplier_Name").ToString

                        a(0) = sqldr.Item("rs_id").ToString
                        a(1) = sqldr.Item("wh_id").ToString
                        a(2) = sqldr.Item("cv_items").ToString()
                        a(3) = sqldr.Item("cv_qty").ToString
                        a(4) = sqldr.Item("whItemDesc").ToString()

                        charge_to_id = get_charge_to_id(sqldr.Item("rs_id").ToString)
                        type_charges = "ADFIL"

                        Select Case type_charges
                            Case "EQUIPMENT"
                                a(5) = GET_equip_desc_AND_proj_desc(charge_to_id, 1)
                            Case "PROJECT"
                                a(5) = GET_equip_desc_AND_proj_desc(charge_to_id, 2)
                            Case "WAREHOUSE"
                                a(5) = GET_equip_desc_AND_proj_desc(charge_to_id, 4)
                            Case "PERSONAL"
                                a(5) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                            Case "CASH"
                                a(5) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                            Case "ADFIL"
                                a(5) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)

                                If a(5) = "ADFIL" Then
                                    Dim mcharges As String = get_multiple_charges(sqldr.Item("rs_id").ToString)

                                    If mcharges.Length < 1 Then
                                    Else
                                        mcharges = mcharges.Trim().Substring(0, mcharges.Length - 1)
                                        a(5) = a(5) & "(" & UCase(mcharges) & ")"
                                    End If

                                End If
                        End Select

                        dgReceivingItem.Rows.Add(a)

                    End If


                Else
                    'MsgBox("IN 3")
                    'txtPOno.Text = sqldr.Item("po_no").ToString
                    'cmbSupplier.Text = sqldr.Item("Supplier_Name").ToString

                    'a(0) = sqldr.Item("rs_id").ToString
                    'a(1) = sqldr.Item("wh_id").ToString
                    'a(2) = get_item_name(sqldr.Item("wh_id").ToString(), 1)
                    'a(3) = sqldr.Item("qty").ToString
                    'a(4) = get_item_name(sqldr.Item("wh_id").ToString(), 2)
                    'dgReceivingItem.Rows.Add(a)

                End If

                    'If check_if_rs_cancel(sqldr.Item("rs_id").ToString) > 0 Then
                    '    With dgReceivingItem.Rows(row)
                    '        For i = 0 To 4
                    '            .Cells(i).Style.BackColor = Color.Red
                    '            .Cells(i).Style.ForeColor = Color.White
                    '        Next
                    '    End With
                    'End If

                'row += 1


            End While
            sqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try

    End Sub

#Region "view item info PO old"
    Public Sub view_item_info_PO()
        dgReceivingItem.Rows.Clear()
        Dim row As Integer

        Dim RS_NO As String = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(1).Text
        Dim inout As String = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(9).Text

        Try
            SQLcon.connection.Open()
            cmd = New SqlCommand("proc_receiving_crud", SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure

            If inout = "OTHERS" Then

                cmd.Parameters.AddWithValue("@crud", 4)
                cmd.Parameters.AddWithValue("@rsNo", RS_NO)

            ElseIf inout = "FACILITIES" Then

                MsgBox("IKADUHA NI")
                cmd.Parameters.AddWithValue("@crud", 6)
                cmd.Parameters.AddWithValue("@POno", po_no)

            Else
                'cmd.Parameters.AddWithValue("@crud", 1)
                'cmd.Parameters.AddWithValue("@POno", po_no)
            End If

            sqldr = cmd.ExecuteReader

            While sqldr.Read

                Dim a(10) As String
                'txtRSNo.Text = sqldr.Item("rs_no").ToString

                If inout = "OTHERS" Then
                    txtPOno.Text = 0
                    cmbSupplier.Text = ""

                    a(1) = sqldr.Item("wh_id").ToString
                    a(2) = sqldr.Item("item_desc").ToString()
                    a(3) = sqldr.Item("qty").ToString
                    a(4) = sqldr.Item("item_desc").ToString()
                    dgReceivingItem.Rows.Add(a)


                ElseIf inout = "FACILITIES" Then


                    MsgBox("IKATULO NI")
                    'MsgBox(po_no)
                    'txtPOno.Text = sqldr.Item("po_no").ToString
                    'cmbSupplier.Text = sqldr.Item("Supplier_Name").ToString

                    a(1) = sqldr.Item("wh_id").ToString
                    'a(2) = sqldr.Item("po_no").ToString
                    dgReceivingItem.Rows.Add(a)

                Else
                    'txtPOno.Text = sqldr.Item("po_no").ToString
                    'cmbSupplier.Text = sqldr.Item("Supplier_Name").ToString

                    'a(1) = sqldr.Item("wh_id").ToString
                    'a(2) = sqldr.Item("item_desc").ToString()
                    'a(3) = sqldr.Item("qty").ToString
                    'a(4) = sqldr.Item("item_desc").ToString()
                    'dgReceivingItem.Rows.Add(a)

                End If

                'txtSupplier.Text = sqldr.Item("supplier").ToString

                'a(1) = sqldr.Item("wh_id").ToString
                'a(2) = sqldr.Item("item_desc").ToString()
                'a(3) = sqldr.Item("qty").ToString
                'a(4) = sqldr.Item("item_desc").ToString()
                'dgReceivingItem.Rows.Add(a)

                'If check_if_rs_cancel(sqldr.Item("rs_id").ToString) > 0 Then
                '    With dgReceivingItem.Rows(row)
                '        For i = 0 To 4
                '            .Cells(i).Style.BackColor = Color.Red
                '            .Cells(i).Style.ForeColor = Color.White
                '        Next
                '    End With
                'End If

                'row += 1
            End While
            sqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try

    End Sub
#End Region


    Public Function get_charge_to_id(ByVal rs_id As Integer)
        Dim newsqlcon As New SQLcon
        Dim newcmd As SqlCommand
        Dim newsqldr As SqlDataReader

        Try
            newsqlcon.connection.Open()
            publicquery = "SELECT charge_to FROM dbrequisition_slip WHERE rs_id = '" & rs_id & "'"
            newcmd = New SqlCommand(publicquery, newsqlcon.connection)
            newsqldr = newcmd.ExecuteReader

            While newsqldr.Read
                get_charge_to_id = newsqldr.Item("charge_to").ToString
            End While

            newsqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
        End Try
    End Function

    Public Function get_item_name(ByVal id As Integer, ByVal n As Integer)
        Dim newsqlcon As New SQLcon
        Dim newcmd As SqlCommand
        Dim newsqldr As SqlDataReader

        Try
            newsqlcon.connection.Open()

            publicquery = "SELECT * FROM dbwarehouse_items WHERE wh_id = '" & id & "' "
            newcmd = New SqlCommand(publicquery, newsqlcon.connection)
            newsqldr = newcmd.ExecuteReader

            While newsqldr.Read
                If n = 1 Then
                    get_item_name = newsqldr.Item("whItem").ToString
                ElseIf n = 2 Then
                    get_item_name = newsqldr.Item("whItemDesc").ToString
                End If

            End While
            newsqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
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

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If cmbSupplier.Text = "" Then
            MessageBox.Show("Pls. Fill up Supplier's Name", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbSupplier.Focus()
        ElseIf txtInvoiceNo.Text = "" Then
            MessageBox.Show("Pls. Fill up DR/Invoice No", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtInvoiceNo.Focus()
        ElseIf txtPOno.Text = "" Then
            MessageBox.Show("Pls. Fill up P.O NO.", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPOno.Focus()
        ElseIf txtRSNo.Text = "" Then
            MessageBox.Show("Pls. Fill up R.S NO.", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRSNo.Focus()
        ElseIf txtRRno.Text = "" Then
            MessageBox.Show("Pls. Fill up R.R NO.", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRRno.Focus()
        ElseIf DTPReceived.Text = "" Then
            MessageBox.Show("Pls. Fill up Date Received", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            DTPReceived.Focus()
        ElseIf txtReceivedby.Text = "" Then
            MessageBox.Show("Pls. Fill up Received by", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtReceivedby.Focus()
        ElseIf txtCheckedby.Text = "" Then
            MessageBox.Show("Pls. Fill up Checked by", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCheckedby.Focus()
        Else
            If btnSave.Text = "Save" Then

                Dim focus As Integer = save_rr_info()
                save_rr_item()
                update_status_PO()

                FRequistionForm.lvlrequisitionlist.Items.Clear()
                FRequistionForm.load_rs_3(1)
                listfocus(FRequistionForm.lvlrequisitionlist, txtRSNo.Text)
                'MessageBox.Show("Successfully Saved...", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ElseIf btnSave.Text = "Update" Then

                updatereceiving_info()
                updatereceiving_items()
                'FSummarySupplyTransaction.SearchSummarySupply()
                listfocus(FReceivingReportList.lvlreceivingreportlist, txtRRno.Text)

            End If
        End If

        'update_condition_receiving()

        'With FRequistionForm
        '    If .lvlrequisitionlist.SelectedItems(0).SubItems(10).Text = "waiting" Then

        '    End If
        'End With

        ' rr_save_item()
        'Me.Dispose()

    End Sub
    Public Sub update_condition_receiving()
        Try
            SQLcon.connection.Open()
            Dim dr As SqlDataReader
            Dim cmd As New SqlCommand("proc_receiving_crud", SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@receiving_info_id", lblInfo_ID.Text)
            cmd.Parameters.AddWithValue("@crud", "Update_condition_Receiving")
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                Dim ex As MsgBoxResult = MessageBox.Show("Are you sure you want to update the existing RECORD ?", "EUS INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If ex = MsgBoxResult.Yes Then
                    If btnSave.Text = "Save" Then
                        With FRequistionForm
                            If .lvlrequisitionlist.Items.Count > 0 Then
                                save_rr_info()
                                save_rr_item()
                                update_status_PO()
                            End If
                        End With
                    ElseIf btnSave.Text = "Update" Then
                        With FSummarySupplyTransaction
                            updatereceiving_info()
                            updatereceiving_items()
                            '.SearchSummarySupply()
                        End With
                    End If
                Else
                End If
            Else
                ' MessageBox.Show("ERROR ! ! !", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub

    Public Function save_rr_info() As Integer
        '    Dim x As String
        Dim status_received As String = "RECEIVED"
        Try
            SQLcon.connection.Open()

            publicquery = "INSERT INTO dbreceiving_info(rr_no,invoice_no,supplier,po_no,"
            publicquery &= "rs_no,date_received,received_by,checked_by,received_status,so_no,hauler,plateno)"
            publicquery &= "VALUES('" & txtRRno.Text & "','" & txtInvoiceNo.Text & "','" & cmbSupplier.Text & "',"
            publicquery &= "'" & txtPOno.Text & "','" & txtRSNo.Text & "','" & DTPReceived.Text & "',"
            publicquery &= "'" & txtReceivedby.Text & "','" & txtCheckedby.Text & "','" & status_received & "','" & txtSOno.Text & "','" & txtHauler.Text & "','" & txtPlateNo.Text & "') "
            cmd = New SqlCommand(publicquery, SQLcon.connection)
            save_rr_info = cmd.ExecuteScalar

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Function

    Public Function save_rr_item() As Integer
        Try
            SQLcon.connection.Open()
            For i = 0 To dgReceivingItem.RowCount - 1
                If dgReceivingItem.Rows(i).Cells(0).Value = True Then

                    If dgReceivingItem.Rows(i).Cells(0).Style.BackColor = Color.Red Then

                    Else
                        cmd = New SqlCommand("proc_receiving_crud", SQLcon.connection)
                        cmd.Parameters.Clear()
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("@invoiceNo", txtInvoiceNo.Text)
                        cmd.Parameters.AddWithValue("@Qty", dgReceivingItem.Rows(i).Cells(4).Value)
                        cmd.Parameters.AddWithValue("@Description", dgReceivingItem.Rows(i).Cells(5).Value)
                        cmd.Parameters.AddWithValue("@remarks", dgReceivingItem.Rows(i).Cells(7).Value)
                        cmd.Parameters.AddWithValue("@rsNo", txtRSNo.Text)
                        cmd.Parameters.AddWithValue("@whID", dgReceivingItem.Rows(i).Cells(2).Value)
                        cmd.Parameters.AddWithValue("@receivingNo", txtRRno.Text)
                        cmd.Parameters.AddWithValue("@rsID", dgReceivingItem.Rows(i).Cells(1).Value)

                        cmd.Parameters.AddWithValue("@crud", "INSERT_TO_ITEMS")
                        cmd.ExecuteNonQuery()
                    End If
                End If
               
            Next

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
            MessageBox.Show("Successfully Saved...", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Function

    Public Sub update_status_PO()
        Dim po_status As String = "PURCHASED"
        Try
            SQLcon.connection.Open()

            publicquery = "UPDATE dbpurchase_order SET status = '" & po_status & "' WHERE po_no = '" & txtPOno.Text & "' "
            cmd = New SqlCommand(publicquery, SQLcon.connection)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub

#Region "DragFORMCODE"
    Private Sub FReceivingReport_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub
    Private Sub FReceivingReport_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub
    Private Sub FReceivingReport_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        drag = False
    End Sub
#End Region

    Public Sub updatereceiving_info()
        SQLcon.connection.Close()
        'With FReceivingReportList
        Try
            SQLcon.connection.Open()
            Dim dr As String
            cmd = New SqlCommand("proc_receiving_crud", SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@receiving_info_id", lblInfo_ID.Text)
            cmd.Parameters.AddWithValue("@supplier", cmbSupplier.Text)
            cmd.Parameters.AddWithValue("@invoiceNo", txtInvoiceNo.Text)
            cmd.Parameters.AddWithValue("@POno", txtPOno.Text)
            cmd.Parameters.AddWithValue("@rsNo", txtRSNo.Text)
            cmd.Parameters.AddWithValue("@receivingNo", txtRRno.Text)
            cmd.Parameters.AddWithValue("@date_received", DTPReceived.Text)
            cmd.Parameters.AddWithValue("@receivedBy", txtReceivedby.Text)
            cmd.Parameters.AddWithValue("@checkedBy", txtCheckedby.Text)
            cmd.Parameters.AddWithValue("@soNo", txtSOno.Text)
            cmd.Parameters.AddWithValue("@hauler", txtHauler.Text)
            cmd.Parameters.AddWithValue("@plateNo", txtPlateNo.Text)

            cmd.Parameters.AddWithValue("@crud", "Update_to_Receiving_info")
            dr = cmd.ExecuteNonQuery()
            ' .lvlreceivingreportlist.Items.Add(dr)
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
        ' End With
    End Sub

    Public Sub updatereceiving_items()
        'With FReceivingReportList
        Try
            SQLcon.connection.Open()
            Dim dr As String
            For i = 0 To dgReceivingItem.Rows.Count - 1
                cmd = New SqlCommand("proc_receiving_crud", SQLcon.connection)
                cmd.Parameters.Clear()
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@whID", dgReceivingItem.Rows(i).Cells(1).Value)
                cmd.Parameters.AddWithValue("@receiving_items_id", dgReceivingItem.Rows(i).Cells(0).Value)
                'cmd.Parameters.AddWithValue("@whID", dgReceivingItem.Rows(i).Cells(0).Value)
                cmd.Parameters.AddWithValue("@Qty", dgReceivingItem.Rows(i).Cells(3).Value)
                cmd.Parameters.AddWithValue("@Description", dgReceivingItem.Rows(i).Cells(4).Value)
                cmd.Parameters.AddWithValue("@remarks", dgReceivingItem.Rows(i).Cells(6).Value)
                cmd.Parameters.AddWithValue("@crud", "Update_to_Receiving_items")
                dr = cmd.ExecuteNonQuery()
                ' .lvlreceivingreportlist.Items.Add(dr)
            Next
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
            MessageBox.Show("Successfully Updated...", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        'End With
    End Sub

#Region "txtbOXKeysCode"

    Private Sub txtRRno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRRno.KeyDown
        If e.KeyCode = Keys.Back Then
            backspace = True
        Else
            backspace = False
        End If
    End Sub

    Private Sub txtRRno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRRno.KeyPress
        If backspace = False Then
            If Not IsNumeric(e.KeyChar) Then
                FReceivingReport_ToolTip.Show("NUMBERS only !", sender, 2000)
                e.KeyChar = Nothing
            End If
        End If
    End Sub

    Private Sub txtInvoiceNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInvoiceNo.KeyDown
        If e.KeyCode = Keys.Back Then
            backspace = True
        Else
            backspace = False
        End If
    End Sub

    Private Sub txtInvoiceNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInvoiceNo.KeyPress
        If backspace = False Then
            If Not IsNumeric(e.KeyChar) Then
                FReceivingReport_ToolTip.Show("NUMBERS only !", sender, 2000)
                e.KeyChar = Nothing
            End If
        End If
    End Sub

    Private Sub txtPOno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPOno.KeyDown
        If e.KeyCode = Keys.Back Then
            backspace = True
        Else
            backspace = False
        End If
    End Sub

    Private Sub txtPOno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPOno.KeyPress
        If backspace = False Then
            If Not IsNumeric(e.KeyChar) Then
                FReceivingReport_ToolTip.Show("NUMBERS only !", sender, 2000)
                e.KeyChar = Nothing
            End If
        End If
    End Sub

    Private Sub txtRSNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRSNo.KeyDown, txtSOno.KeyDown
        If e.KeyCode = Keys.Back Then
            backspace = True
        Else
            backspace = False
        End If
    End Sub

    Private Sub txtRSNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRSNo.KeyPress, txtSOno.KeyPress
        If backspace = False Then
            If Not IsNumeric(e.KeyChar) Then
                FReceivingReport_ToolTip.Show("NUMBERS only !", sender, 2000)
                e.KeyChar = Nothing
            End If
        End If
    End Sub
#End Region

#Region "GUI_BUTTON"
    Private Sub btnExit_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnExit.MouseDown
        btnExit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.MouseEnter
        btnExit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.MouseLeave
        btnExit.BackgroundImage = My.Resources.close_button
    End Sub
#End Region

    Private Sub DTPReceived_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPReceived.ValueChanged

    End Sub

    Private Sub txtReceivedby_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReceivedby.TextChanged
        ' searchbox(txtReceivedby)

      
        '    ListBox1.Width = txtReceivedby.Width
        '    ListBox1.Location = New Point(txtReceivedby.Location.X, txtReceivedby.Location.Y + 24)
        'If txtReceivedby.Focus = True Then
        '    ListBox1.Visible = True
        '    receivedby_list(0)
        'End If

        Try
            If txtReceivedby.Text = "" Then
                ListBox1.Location = New System.Drawing.Point(txtReceivedby.Location.X, txtReceivedby.Location.Y + txtReceivedby.Height)
                ListBox1.Visible = False
            Else
                With ListBox1
                    .Location = New System.Drawing.Point(txtReceivedby.Location.X, txtReceivedby.Location.Y + txtReceivedby.Height)
                    .Visible = True
                    .Items.Clear()
                    .Width = txtReceivedby.Width
                End With
                receivedby_list(0)
                'get_withdraw(n, tbox)

            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Private Sub searchbox(ByVal obj As Object)

    '    Dim tbox As TextBox = obj

    '    lbox_receivedby.Parent = Panel1
    '    lbox_receivedby.BringToFront()
    '    lbox_receivedby.Enabled = True
    '    lbox_receivedby.Location = New Point(tbox.Location.X, tbox.Location.Y + tbox.Height)
    '    lbox_receivedby.Width = tbox.Width
    'End Sub
    Private Sub receivedby_list(ByVal n As Integer)
        'If txtReceivedby.Text = "" Then
        '    ListBox1.Visible = False
        'ElseIf txtCheckedby.Text = "" Then
        '    ListBox1.Visible = False
        'Else
        ListBox1.Items.Clear()
        Dim counter As Integer = 0
        Try
            SQLcon.connection.Open()
            Dim dr As SqlDataReader
            Dim cmd As New SqlCommand("proc_receiving_crud", SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            If n = 0 Then
                cmd.Parameters.AddWithValue("@receivedBy", txtReceivedby.Text)
                cmd.Parameters.AddWithValue("@crud", "get_received_by")
            ElseIf n = 1 Then
                cmd.Parameters.AddWithValue("@checkedBy", txtCheckedby.Text)
                cmd.Parameters.AddWithValue("@crud", "get_checked_by")
            End If
            dr = cmd.ExecuteReader
            If dr.HasRows = False Then
                ListBox1.Visible = False
            Else
                While dr.Read
                    If n = 0 Then
                        Dim receivedby As String = dr.Item("received_by").ToString
                        ListBox1.Items.Add(receivedby)
                        counter += 1
                    ElseIf n = 1 Then
                        Dim checkedby As String = dr.Item("checked_by").ToString
                        ListBox1.Items.Add(checkedby)
                        counter += 1
                    End If

                    If counter > 0 Then
                        ListBox1.Visible = True
                    Else
                        ListBox1.Visible = False
                    End If
                End While
                dr.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
        'End If


    End Sub

    Private Sub txtCheckedby_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCheckedby.GotFocus
        If txtCheckedby.Focused Then
            name1 = txtCheckedby.Name
            txtCheckedby.SelectAll()
        End If
    End Sub

    Private Sub txtCheckedby_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCheckedby.TextChanged

        'searchbox(txtCheckedby)

        'ListBox1.Width = txtCheckedby.Width
        'ListBox1.Location = New Point(txtCheckedby.Location.X, txtCheckedby.Location.Y + 24)
        'If txtCheckedby.Focus = True Then
        '    ListBox1.Visible = True
        '    receivedby_list(1)
        'End If

        Try
            If txtCheckedby.Text = "" Then
                ListBox1.Location = New System.Drawing.Point(txtCheckedby.Location.X, txtCheckedby.Location.Y + txtCheckedby.Height)
                ListBox1.Visible = False
            Else
                With ListBox1
                    .Location = New System.Drawing.Point(txtCheckedby.Location.X, txtCheckedby.Location.Y + txtCheckedby.Height)
                    .Visible = True
                    .Items.Clear()
                    .Width = txtReceivedby.Width
                End With
                receivedby_list(1)
                'get_withdraw(n, tbox)

            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtField_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSupplier.GotFocus, txtInvoiceNo.GotFocus, txtPOno.GotFocus, txtRSNo.GotFocus, _
   txtRRno.GotFocus, txtReceivedby.GotFocus, txtCheckedby.GotFocus, txtSOno.GotFocus, txtHauler.GotFocus, txtPlateNo.GotFocus

        sender.backcolor = Color.Yellow

        If txtPlateNo.Focused Then
            name1 = txtPlateNo.Name
            txtPlateNo.SelectAll()
        ElseIf txtCheckedby.Focused Then
            name1 = txtCheckedby.Name
            txtCheckedby.SelectAll()
        ElseIf txtReceivedby.Focused Then
            name1 = txtReceivedby.Name
            txtReceivedby.SelectAll()
        End If

        ListBox1.Visible = False

    End Sub

    Private Sub txtPlateNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPlateNo.KeyDown, txtCheckedby.KeyDown, txtReceivedby.KeyDown
        pub_textbox = sender

        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
            If ListBox1.Visible = True Then
                If ListBox1.Items.Count > 0 Then
                    ListBox1.Focus()
                    ListBox1.SelectedIndex = 0
                End If
            Else
            End If
        End If
    End Sub

    Private Sub txtField_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSupplier.Leave, txtInvoiceNo.Leave, txtPOno.Leave, txtRSNo.Leave, _
   txtRRno.Leave, txtReceivedby.Leave, txtCheckedby.Leave, txtSOno.Leave, txtHauler.Leave, txtPlateNo.Leave

        sender.backcolor = Color.White

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Panel_Supplier.Visible = True
        show_supplier_list(lvList)

        If lvList.SelectedItems.Count > 0 Then
            Dim index As Integer = lvList.Items.Count - 1

            lvList.Items(index).Selected = True
            lvList.Items(index).EnsureVisible()
        End If

    End Sub
    Public Sub show_supplier_list(ByVal list As ListView)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        list.Items.Clear()
        newSQ.connection.Open()
        Try

            Dim query As String = "SELECT * FROM dbSupplier order by Supplier_Name asc"
            newCMD = New SqlCommand(query, newSQ.connection)

            newDR = newCMD.ExecuteReader

            While newDR.Read

                Dim a(5) As String
                a(0) = newDR.Item(0).ToString
                a(1) = newDR.Item(1).ToString
                a(2) = newDR.Item(2).ToString
                a(3) = newDR.Item(3).ToString
                Dim lvl As New ListViewItem(a)
                list.Items.Add(lvl)

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'conn.connection.Close()
            newSQ.connection.Close()
        End Try
    End Sub

    Public Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If txt_SupplierName.Text <> "" And txt_SupplierLocation.Text <> "" Then
            If booleanOperator_Cancel = True Then
                btn_Update.Enabled = False
                txt_SupplierName.Text = ""
                txt_SupplierLocation.Text = ""
                lvList.Enabled = True
                btnAdd.Text = "Add"
            ElseIf btnAdd.Text = "Add" Then
                Insert_Supplier(txt_SupplierName.Text, txt_SupplierLocation.Text, "")
                show_supplier_list(lvList)
                txt_SupplierName.Text = ""
                txt_SupplierLocation.Text = ""
                txt_SupplierName.Focus()
                listfocus(lvList, n)
            End If
        End If

        'load_suppliers_list()
        booleanOperator_Cancel = False
    End Sub
    Public Function Insert_Supplier(ByVal suppliername As String, ByVal supplocation As String, terms As String) As Integer

        SQLcon.connection.Open()

        Try
            Dim sqlComm As New SqlCommand()

            sqlComm.Connection = SQLcon.connection

            sqlComm.CommandText = "sp_Insert_Supplier"
            sqlComm.CommandType = CommandType.StoredProcedure
            sqlComm.Parameters.AddWithValue("@Supplier_Name", suppliername.Replace("'", "`"))
            sqlComm.Parameters.AddWithValue("@Supplier_Location", supplocation)
            sqlComm.Parameters.AddWithValue("@Supplier_terms", terms)
            Insert_Supplier = sqlComm.ExecuteScalar()
            SQLcon.connection.Close()

            MessageBox.Show("Successfully Saved...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'conn.connection.Close()
        End Try

    End Function

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Panel_Supplier.Hide()
        load_suppliers_list()
    End Sub

    Private Sub btn_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Update.Click
        Dim ex = MsgBox("Are you sure u want to update the SELECTED item?", MsgBoxStyle.YesNo, "Information")
        If ex = MsgBoxResult.Yes Then

            Dim term As New TextBox

            UpdateRecord_Supplier(Val(lvList.SelectedItems(0).Text), txt_SupplierName, txt_SupplierLocation, term)
            show_supplier_list(lvList)
            listfocus(lvList, n)

            btnAdd.Text = "Add"
            btn_Update.Enabled = False
            lvList.Enabled = True
        Else
        End If

        booleanOperator_Cancel = False
    End Sub
    Public Sub UpdateRecord_Supplier(ByVal supplier_id As Integer, ByVal suppname As TextBox, ByVal supplocation As TextBox, terms As TextBox)

        Try
            SQLcon.connection.Open()
            Dim sqlComm As New SqlCommand

            sqlComm.Connection = SQLcon.connection
            sqlComm.CommandText = "sp_Update_Supplier"
            sqlComm.CommandType = CommandType.StoredProcedure
            sqlComm.Parameters.AddWithValue("@Supplier_Name", suppname.Text)
            sqlComm.Parameters.AddWithValue("@Supplier_Location", supplocation.Text)
            sqlComm.Parameters.AddWithValue("@Supplier_terms", terms.Text)
            sqlComm.Parameters.AddWithValue("@Supplier_Id", supplier_id)
            sqlComm.ExecuteNonQuery()

            show_supplier_list(lvList)
            suppname.Text = ""
            supplocation.Text = ""
            suppname.Focus()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try

    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        If lvList.SelectedItems.Count > 0 Then
            lvList.Enabled = False
            txt_SupplierName.Text = lvList.SelectedItems.Item(0).SubItems(1).Text
            txt_SupplierLocation.Text = lvList.SelectedItems.Item(0).SubItems(2).Text
            btnAdd.Text = "Cancel"
            btn_Update.Enabled = True
            booleanOperator_Cancel = True
        End If
    End Sub

    Private Sub lvList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvList.DoubleClick
        cmbSupplier.Text = lvList.SelectedItems(0).SubItems(1).Text
        Panel_Supplier.Hide()
        cmbSupplier.Focus()
    End Sub

    Private Sub lvList_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvList.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            CMS_lvList.Show(Me, e.Location)
            CMS_lvList.Show(Cursor.Position)
        End If
    End Sub

    Private Sub lvList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvList.SelectedIndexChanged

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim ex = MsgBox("Are you sure u want to DELETE the SELECTED item?", MsgBoxStyle.YesNo, "ERROR")
        If ex = MsgBoxResult.Yes Then
            Dim n As Integer = DeleteRecord_Supplier(lvList)
            show_supplier_list(lvList)
            listfocus(lvList, n)

            txt_SupplierName.Text = ""
            txt_SupplierLocation.Text = ""
            btn_Update.Enabled = False
            btnAdd.Text = "Add"
        Else
        End If
        load_suppliers_list()
        booleanOperator_Cancel = False
    End Sub
    Public Function DeleteRecord_Supplier(ByVal lvl As ListView) As Integer
        n = Val(lvl.SelectedItems(0).Text)

        Try
            SQLcon.connection.Open()
            Dim sqlComm As New SqlCommand

            sqlComm.Connection = SQLcon.connection
            sqlComm.CommandText = "sp_Delete_Supplier"
            sqlComm.CommandType = CommandType.StoredProcedure
            sqlComm.Parameters.AddWithValue("@Supplier_Id", n)
            DeleteRecord_Supplier = n + 1

            sqlComm.ExecuteNonQuery()

            MessageBox.Show("Successfully Deleted...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try

    End Function

    Private Sub txtInvoiceNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvoiceNo.TextChanged
      
    End Sub

    Private Sub cmbSupplier_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSupplier.Leave

    End Sub

    Private Sub cmbSupplier_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSupplier.SelectedIndexChanged

    End Sub

    Public Sub load_equipment(ByVal n As Integer)
        ListBox1.Items.Clear()
        Dim counter As Integer = 0

        Dim sqlcon As New SQLcon

        'sqlcon.set_sql("192.168.1.92", "eus_031916", "sa", "adfil")
        'sqlcon.sql_connect()

        'cmbPlateNo.Width = txtCheckedby.Width
        'cmbPlateNo.Location = New Point(txtCheckedby.Bounds.Left, txtCheckedby.Bounds.Top)
        'cmbPlateNo.Visible = False
        'cmbox.BringToFront()

        Try
            sqlcon.connection1.Open()

            If n = 0 Then
                publicquery = "SELECT * FROM dbequipment_list WHERE plate_no LIKE '%" & txtPlateNo.Text & "%' "
            End If

            cmd = New SqlCommand(publicquery, sqlcon.connection1)
            sqldr = cmd.ExecuteReader
            If sqldr.HasRows = False Then
                ListBox1.Visible = False
            Else
                While sqldr.Read
                    If n = 0 Then
                        Dim plateno As String = sqldr.Item("plate_no").ToString
                        ListBox1.Items.Add(plateno)
                        counter += 1
                    End If


                    If counter = 0 Then
                        ListBox1.Visible = False
                    Else
                        ListBox1.Visible = True
                    End If
                End While
                sqldr.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection1.Close()
        End Try
    End Sub

    Private Sub txtPlateNo_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtPlateNo.MouseClick
        txtPlateNo.SelectionStart = 0
        txtPlateNo.SelectionLength = Len(txtPlateNo.Text)
    End Sub

    Private Sub txtPlateNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPlateNo.TextChanged

        'ListBox1.Width = txtPlateNo.Width
        'ListBox1.Location = New Point(txtPlateNo.Location.X, txtPlateNo.Location.Y + 24)
        'If txtPlateNo.Focus = True Then
        '    ListBox1.BringToFront()
        '    ListBox1.Visible = True
        '    load_equipment(0)
        'End If

        Try
            If txtPlateNo.Text = "" Then
                ListBox1.Location = New System.Drawing.Point(txtPlateNo.Location.X, txtPlateNo.Location.Y + txtPlateNo.Height)
                ListBox1.Visible = False
            Else
                With ListBox1
                    ListBox1.BringToFront()
                    .Location = New System.Drawing.Point(txtPlateNo.Location.X, txtPlateNo.Location.Y + txtPlateNo.Height)
                    .Visible = True
                    .Items.Clear()
                    .Width = txtPlateNo.Width
                End With
                load_equipment(0)
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ListBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick

        If ListBox1.SelectedItems.Count > 0 Then
            For Each ctr As Control In Panel1.Controls
                If ctr.Name = name1 Then
                    ctr.Text = ListBox1.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next
            ListBox1.Visible = False
        Else
            MessageBox.Show("Pls select data", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub ListBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox1.KeyDown

        If e.KeyCode = Keys.Enter Then
            For Each ctr As Control In Panel1.Controls
                If ctr.Name = name1 Then
                    ctr.Text = ListBox1.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next
            ListBox1.Visible = False
        ElseIf e.KeyCode = Keys.Up Then
            If ListBox1.SelectedIndex = 0 Then
                Dim f As Integer
                f = 1

                If f = 1 Then
                    pub_textbox.Focus()

                End If
                ListBox1.Visible = False
            End If

        End If

    End Sub

    Private Sub txtSOno_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtSOno.MouseClick
        txtSOno.SelectionStart = 0
        txtSOno.SelectionLength = Len(txtSOno.Text)
    End Sub

    Private Sub txtHauler_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtHauler.MouseClick
        txtHauler.SelectionStart = 0
        txtHauler.SelectionLength = Len(txtHauler.Text)
    End Sub

    Private Sub txtRRno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRRno.TextChanged

    End Sub

    Private Sub FReceivingReport_ToolTip_Popup(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PopupEventArgs) Handles FReceivingReport_ToolTip.Popup

    End Sub

    Private Sub ListBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox1.KeyUp
     
    End Sub

   

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub btnSave_new_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave_new.Click
        'Dim rr_info_id As Integer = insert_dbreceiving_info("OTHERS", 2)

        'For Each row As DataGridViewRow In dgReceivingItem.Rows
        '    If row.Cells(0).Value = True Then

        '    End If
        'Next

        'If rr_info_id > 0 Then
        '    MessageBox.Show("Successufuly Saved..", "SupplyInfo:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
        For Each item As Control In Me.Controls
            If item.Name = "Panel1" Then
                item.Visible = True
            Else
                item.Enabled = False
            End If
        Next

        If btnSave.Text = "Save" Then
            btnReceive.Text = "Receive"

        ElseIf btnSave.Text = "Update" Then
            'rr_info
            get_rr_info()
            btnReceive.Text = "Update"

        End If

        ListBox1.Visible = False
      
    End Sub
    Public Sub get_rr_info()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        newSQ.connection.Open()

        Try
            Dim query As String = "SELECT * FROM dbreceiving_info WHERE rr_info_id = " & CDbl(lblrr_info_id.Text)
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader
            While newDR.Read

                cmbSupplier.Text = newDR.Item("supplier").ToString
                txtInvoiceNo.Text = newDR.Item("invoice_no").ToString
                txtPOno.Text = newDR.Item("po_no").ToString
                txtRSNo.Text = newDR.Item("rs_no").ToString
                txtSOno.Text = newDR.Item("so_no").ToString
                txtHauler.Text = newDR.Item("hauler").ToString
                txtRRno.Text = newDR.Item("rr_no").ToString
                DTPReceived.Text = newDR.Item("date_received").ToString
                txtReceivedby.Text = newDR.Item("received_by").ToString
                txtCheckedby.Text = newDR.Item("checked_by").ToString
                txtPlateNo.Text = newDR.Item("plateno").ToString

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Public Sub insert_dbreceiving_items(ByVal rr_info_id As Integer, ByVal type As String, ByVal n As Integer, ByVal item_desc As String, ByVal remarks As String, ByVal wh_id As Integer, ByVal rs_id As Integer, ByVal qty As Integer, rowindex As Integer, po_det_id As Integer)
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

            Dim rr_item_id As Integer = newCMD.ExecuteScalar

            Dim a(10) As String
            For i = 0 To 49
                If mArray(rowindex, i) = Nothing Then
                Else

                    Dim items() As String
                    Dim raw_item As String = mArray(rowindex, i)
                    items = raw_item.Split("^")

                    a(1) = items(0)
                    a(2) = items(1)
                    a(3) = FormatNumber(items(2), 2,,, TriState.True)
                    a(4) = items(3)

                    insert_sub_rr_items(rr_item_id, a(1), CInt(a(2)), CDbl(a(3)), a(4))
                End If

            Next



        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Public Sub insert_sub_rr_items(rr_item_id As Integer, item_desc As String, qty As Double, amount As Double, unit As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 8)

            newCMD.Parameters.AddWithValue("@rr_item_id", rr_item_id)
            newCMD.Parameters.AddWithValue("@item_desc", item_desc)
            newCMD.Parameters.AddWithValue("@qty", qty)
            newCMD.Parameters.AddWithValue("@unit", unit)
            newCMD.Parameters.AddWithValue("@amount", amount)

            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Public Sub update_sub_rr_items(rr_item_id As Integer, item_desc As String, qty As Double, amount As Double, unit As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 88)
            newCMD.Parameters.AddWithValue("@rr_item_sub_id", CInt(ListView1.SelectedItems(0).Text))
            newCMD.Parameters.AddWithValue("@rr_item_id", rr_item_id)
            newCMD.Parameters.AddWithValue("@item_desc", item_desc)
            newCMD.Parameters.AddWithValue("@qty", qty)
            newCMD.Parameters.AddWithValue("@unit", unit)
            newCMD.Parameters.AddWithValue("@amount", amount)

            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Public Sub update_dbreceiving_items(ByVal rr_info_id As Integer, ByVal type As String, ByVal n As Integer, _
                                        ByVal item_desc As String, ByVal remarks As String, ByVal wh_id As Integer, _
                                        ByVal rs_id As Integer, ByVal qty As Integer, ByVal rr_item_id As Integer)
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
            newCMD.Parameters.AddWithValue("@rr_item_id", rr_item_id)

            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Public Function insert_dbreceiving_info(ByVal type As String, ByVal n As Integer) As Integer
        'Dim suppname, invoiceno, supplier, po_no, rs_no, receivedby, checkedby, receivedstatus, so_no, hauler, plateno As String
        'Dim date_received As DateTime


        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@type", type)

            newCMD.Parameters.AddWithValue("@rr_no", txtRRno.Text)
            newCMD.Parameters.AddWithValue("@invoice_no", txtInvoiceNo.Text)
            newCMD.Parameters.AddWithValue("@supplier", cmbSupplier.Text)
            newCMD.Parameters.AddWithValue("@po_no", txtPOno.Text)
            newCMD.Parameters.AddWithValue("@rs_no", txtRSNo.Text)
            newCMD.Parameters.AddWithValue("@date_received", Date.Parse(DTPReceived.Text))
            newCMD.Parameters.AddWithValue("@received_by", txtReceivedby.Text)
            newCMD.Parameters.AddWithValue("@checked_by", txtCheckedby.Text)
            newCMD.Parameters.AddWithValue("@received_status", "PENDING")
            newCMD.Parameters.AddWithValue("@so_no", txtSOno.Text)
            newCMD.Parameters.AddWithValue("@hauler", txtHauler.Text)
            newCMD.Parameters.AddWithValue("@plateno", txtPlateNo.Text)

            insert_dbreceiving_info = newCMD.ExecuteScalar()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        For Each item As Control In Me.Controls
            If item.Name = "Panel1" Then
                item.Visible = False
            Else
                item.Enabled = True
            End If
        Next
    End Sub

 
    Private Sub btnReceive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceive.Click
        Dim rr_info_id As Integer
        If btnReceive.Text = "Update" Then
            rr_info_id = CDbl(lblrr_info_id.Text)
        Else
            rr_info_id = insert_dbreceiving_info("OTHERS", 2)
        End If

        Dim rr_item_id As Integer = 0

        If select_atleast_one(dgReceivingItem) = 0 Then
            MessageBox.Show("Please, select atleast 1 in the list.", "Supply Info:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If

        For Each row As DataGridViewRow In dgReceivingItem.Rows
            If row.Cells(0).Value = True Then

                'assigning value from datagrid
                Dim desc As String = row.Cells(6).Value
                Dim remarks As String = row.Cells(8).Value
                Dim wh_id As Integer = row.Cells(9).Value
                Dim rs_id As Integer = row.Cells(10).Value
                Dim qty As Integer = row.Cells(3).Value
                Dim unit_amount As Double = CDbl(row.Cells(5).Value)
                rr_item_id = CInt(row.Cells(12).Value)
                Dim lof_id As Integer = get_id("dbfacilities_list", "brand", row.Cells(6).Value, 0)
                Dim inout As String = row.Cells(11).Value
                Dim po_det_id As Integer = row.Cells(14).Value

                If btnReceive.Text = "Update" Then

                    Dim type_of_purchasing As String = FReceivingReportList.lvlreceivingreportlist.SelectedItems(0).SubItems(14).Text

                    update_dbreceiving_items(rr_info_id, "OTHERS", 33, desc, remarks, wh_id, rs_id, qty, rr_item_id)
                    update_po_and_cv_price(type_of_purchasing, rs_id, unit_amount) 'update price from po items and cv items

                    If inout = "FACILITIES" Or inout = "TOOLS" Or inout = "ADD-ON" Then
                        update_lof_id_From_PO_CV_det(type_of_purchasing, rs_id, lof_id, row.Cells(6).Value)
                    Else
                        update_po_cv_item_desc(type_of_purchasing, rs_id, row.Cells(6).Value)
                    End If

                Else

                    Dim type_of_purchasing As String = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(18).Text

                    insert_dbreceiving_items(rr_info_id, "OTHERS", 3, desc, remarks, wh_id, rs_id, qty, CInt(row.Index.ToString), po_det_id)
                    update_po_and_cv_price(type_of_purchasing, rs_id, unit_amount) 'update price from po items and cv items

                    If inout = "FACILITIES" Or inout = "TOOLS" Or inout = "ADD-ON" Then
                        update_lof_id_From_PO_CV_det(type_of_purchasing, rs_id, lof_id, row.Cells(6).Value)
                    Else
                        update_po_cv_item_desc(type_of_purchasing, rs_id, row.Cells(6).Value)
                    End If

                End If

            End If
        Next

        If rr_info_id > 0 Then

            If btnReceive.Text = "Update" Then
                MessageBox.Show("Successfully Updated..", "Supply Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
                FReceivingReportList.btnSearch.PerformClick()
                listfocus(FReceivingReportList.lvlreceivingreportlist, rr_item_id)
            ElseIf btnReceive.Text = "Receive" Then

                MessageBox.Show("Successfully Saved..", "Supply Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
                FRequistionForm.btnSearch.PerformClick()
                listfocus(FRequistionForm.lvlrequisitionlist, rs_id)
            End If


            Me.Close()
            Me.Dispose()

        End If
    End Sub


    Public Sub update_po_and_cv_price(ByVal type As String, ByVal rs_id As Integer, ByVal unit_price As Double)
        If type = "PURCHASE ORDER" Then
            Dim query As String = "UPDATE dbPO_details SET unit_price = " & unit_price & " WHERE rs_id = " & rs_id
            UPDATE_INSERT_DELETE_QUERY(query, 0, "UPDATE")

        ElseIf type = "CASH" Then
            Dim query As String = "UPDATE dbCashVoucher_items SET cv_amount = " & unit_price & " WHERE rs_id = " & rs_id
            UPDATE_INSERT_DELETE_QUERY(query, 0, "UPDATE")

        End If
    End Sub

    Public Sub update_lof_id_From_PO_CV_det(ByVal type As String, ByVal rs_id As Integer, ByVal lof_id As Integer, ByVal item_desc As String)
        If type = "PURCHASE ORDER" Then
            Dim query As String = "UPDATE dbPO_details SET lof_id = " & lof_id & ",item_desc = '" & item_desc & "' WHERE rs_id = " & rs_id
            UPDATE_INSERT_DELETE_QUERY(query, 0, "UPDATE")

        ElseIf type = "CASH" Then
            Dim query As String = "UPDATE dbCashVoucher_items SET cv_itemDesc = '" & item_desc & "' WHERE rs_id = " & rs_id
            UPDATE_INSERT_DELETE_QUERY(query, 0, "UPDATE")

        End If
    End Sub
    Public Sub update_po_cv_item_desc(ByVal type As String, ByVal rs_id As Integer, ByVal item_desc As String)
        If type = "PURCHASE ORDER" Then
            Dim query As String = "UPDATE dbPO_details SET item_desc = '" & item_desc & "' WHERE rs_id = " & rs_id
            UPDATE_INSERT_DELETE_QUERY(query, 0, "UPDATE")

        ElseIf type = "CASH" Then
            Dim query As String = "UPDATE dbCashVoucher_items SET cv_itemDesc = '" & item_desc & "' WHERE rs_id = " & rs_id
            UPDATE_INSERT_DELETE_QUERY(query, 0, "UPDATE")

        End If
    End Sub

    Private Sub dgReceivingItem_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgReceivingItem.CellBeginEdit
        rowind = Format(get_datagrid_rowindex)
        old_price_value = dgReceivingItem.Rows(Format(rowind)).Cells(4).Value
        'old_qty = dgReceivingItem.Rows(Format(rowind)).Cells(7).Value
    End Sub

    Private Sub dgReceivingItem_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgReceivingItem.CellDoubleClick

        Dim itemname As String
        Dim row As Integer
        Dim type As String = dgReceivingItem.Rows(rowind).Cells(10).Value

        rowind = Format(get_datagrid_rowindex)
        If type = "FACILITIES" Or type = "TOOLS" Or type = "ADD-ON" Then
            If dgReceivingItem.Rows(rowind).Cells(5).Selected = True Then
                For Each ctr As Control In Me.Controls
                    If ctr.Name = "Panel2" Then
                        ctr.Visible = True

                    Else
                        ctr.Enabled = False

                    End If
                Next
            End If

            itemname = dgReceivingItem.Rows(rowind).Cells(2).Value
            load_facility_names(itemname)

        End If
    End Sub
    Public Function load_facility_names(ByVal fac_name As String) As String
        cmbBrand.Items.Clear()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()

            newCMD = New SqlCommand("proc_facilities", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 9)
            newCMD.Parameters.AddWithValue("@fac_name", fac_name)

            newDR = newCMD.ExecuteReader
            While newDR.Read
                cmbBrand.Items.Add(newDR.Item("brand").ToString)

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Function get_datagrid_rowindex() As Integer

        For i As Integer = 0 To Me.dgReceivingItem.SelectedCells.Count - 1
            get_datagrid_rowindex = Me.dgReceivingItem.SelectedCells.Item(i).RowIndex
        Next
    End Function

    'Private Sub dgvDeparture_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles dgReceivingItem.EditingControlShowing

    '    'Get the Editing Control. I personally prefer Trycast for this as it will not throw an error
    '    Dim editingComboBox As Button = TryCast(e.Control, Button)
    '    If Not editingComboBox Is Nothing Then
    '        'Add the handle to your IndexChanged Event
    '        AddHandler editingComboBox.Click, AddressOf editingComboBox_SelectedIndexChanged
    '    End If

    '    'Prevent this event from firing twice, as is normally the case.
    '    RemoveHandler dgReceivingItem.EditingControlShowing, AddressOf dgvDeparture_EditingControlShowing

    'End Sub
    'Private Sub editingComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    dgReceivingItem.Refresh()

    '    'Get the editing control
    '    Dim gridviewbutton As Button = TryCast(sender, Button)
    '    If gridviewbutton Is Nothing Then Exit Sub

    '    'Show your Message Boxes
    '    'MessageBox.Show(editingComboBox.SelectedIndex.ToString()) ' Display index

    '    dgReceivingItem.Rows(rowind).Cells(12).Value = "Sub Items"
    '    MessageBox.Show("hello")

    '    'Remove the handle to this event. It will be readded each time a new combobox selection causes the EditingControlShowing Event to fire
    '    RemoveHandler gridviewbutton.Click, AddressOf editingComboBox_SelectedIndexChanged
    '    'Re-enable the EditingControlShowing event so the above can take place.
    '    AddHandler dgReceivingItem.EditingControlShowing, AddressOf dgvDeparture_EditingControlShowing

    'End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        For Each ctr As Control In Me.Controls
            If ctr.Name = "Panel2" Then
                ctr.Visible = False

            Else
                ctr.Enabled = True

            End If
        Next
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Button2.PerformClick()

        Dim lof_id As Integer = get_id("dbfacilities_list", "brand", cmbBrand.Text, 0)

        'DataGridView1.Rows(rowind).Cells(4).Value = cmbBrand.Text
        'DataGridView1.Rows(rowind).Cells(13).Value = lof_id

        dgReceivingItem.Rows(rowind).Cells(5).Value = cmbBrand.Text


    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        FBorrower.ShowDialog()
    End Sub

    Private Sub dgReceivingItem_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgReceivingItem.CellEndEdit
        If Not IsNumeric(dgReceivingItem.Rows(Format(rowind)).Cells(4).Value()) Then

            MessageBox.Show("Entry must numeric..", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dgReceivingItem.Rows(Format(rowind)).Cells(5).Selected = True
            dgReceivingItem.Rows(Format(rowind)).Cells(5).Value = FormatNumber(old_price_value, 2, , , TriState.True)


        Else
            dgReceivingItem.Rows(Format(rowind)).Cells(5).Value = FormatNumber(CDbl(dgReceivingItem.Rows(Format(rowind)).Cells(4).Value), 2, , , TriState.True)

        End If
    End Sub

    Private Sub dgReceivingItem_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgReceivingItem.CellContentClick
        rowind = Format(get_datagrid_rowindex)

        If dgReceivingItem.Rows(rowind).Cells(12).Value = 0 Then ' wala pa na save
            If e.RowIndex < 0 Then
                Exit Sub
            End If

            Dim grid = DirectCast(sender, DataGridView)

            If TypeOf grid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
                If grid.Columns(e.ColumnIndex).Name = "sub_item" Then
                    For Each ctr As Control In Me.Controls
                        If ctr.Name = "PnlAddOtherItems" Then
                            ctr.Visible = True
                        Else
                            ctr.Enabled = False
                        End If
                    Next
                End If
            End If

            ListView1.Items.Clear()

            'mArray(rowind, 0) = "hi"
            'mArray(rowind, 1) = "hello"
            'mArray(rowind, 2) = "world"

            For i = 0 To 49
                If mArray(rowind, i) = Nothing Then
                Else
                    Dim a(5) As String
                    Dim items() As String
                    Dim raw_item As String = mArray(rowind, i)
                    items = raw_item.Split("^")

                    a(1) = items(0)
                    a(2) = items(1)
                    a(3) = FormatNumber(items(2), 2,,, TriState.True)
                    a(4) = items(3)

                    Dim lvl As New ListViewItem(a)
                    ListView1.Items.Add(lvl)
                End If
            Next

        Else 'na save na
            'get sub receiving item from database

            Dim grid = DirectCast(sender, DataGridView)

            If TypeOf grid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
                If grid.Columns(e.ColumnIndex).Name = "sub_item" Then
                    For Each ctr As Control In Me.Controls
                        If ctr.Name = "PnlAddOtherItems" Then
                            ctr.Visible = True
                        Else
                            ctr.Enabled = False
                        End If
                    Next
                End If
            End If

            view_receiving_sub_items()
        End If



    End Sub
    Public Sub view_receiving_sub_items()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim rs_id As Integer = CInt(dgReceivingItem.Rows(rowind).Cells(10).Value)

        Dim a(10) As String
        Try
            ListView1.Items.Clear()

            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            Dim po_det_id As Integer = CInt(dgReceivingItem.Rows(rowind).Cells(14).Value)

            newCMD.Parameters.AddWithValue("@n", 9)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read

                a(0) = newDR.Item("rr_item_sub_id").ToString
                a(1) = newDR.Item("item_desc").ToString
                a(2) = newDR.Item("qty").ToString
                a(3) = FormatNumber(newDR.Item("amount").ToString, 2,,, TriState.True)
                a(4) = newDR.Item("unit").ToString

                Dim lvl As New ListViewItem(a)
                ListView1.Items.Add(lvl)

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim str As String = ""
        Dim amount As Double

        For Each ctr As Control In Me.Controls
            If ctr.Name = "PnlAddOtherItems" Then
                ctr.Visible = False
            Else
                ctr.Enabled = True
            End If
        Next

        Dim i As Integer = 0
        Dim sub_qty As Integer

        For i = 0 To 49
            mArray(rowind, i) = Nothing
        Next

        For i = 0 To ListView1.Items.Count - 1

            With ListView1
                mArray(rowind, i) = .Items(i).SubItems(1).Text & "^" & .Items(i).SubItems(2).Text & "^" & .Items(i).SubItems(3).Text & "^" & .Items(i).SubItems(4).Text
                str &= .Items(i).SubItems(1).Text & ","
                amount += CDbl(.Items(i).SubItems(2).Text) * CDbl(.Items(i).SubItems(3).Text)
                sub_qty += CDbl(.Items(i).SubItems(2).Text)
            End With
        Next

        If str.Length = 0 Then
            str = ""
        Else
            str = str.Trim().Substring(0, str.Length - 1)
        End If

        dgReceivingItem.Rows(rowind).Cells(4).Value = sub_qty
        dgReceivingItem.Rows(rowind).Cells(5).Value = FormatNumber(amount, 2,,, TriState.True)
        dgReceivingItem.Rows(rowind).Cells(8).Value = str



    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnAddSub.Click
        'ListBox2.Items.Add(txtOtherItems.Text)

        Dim a(10) As String
        a(1) = txtOtherItems.Text
        a(2) = txtotherqty.Text
        a(3) = FormatNumber(txtotheramount.Text, 2,,, TriState.True)
        a(4) = txtUnit.Text

        Dim rr_item_id As Integer = CInt(dgReceivingItem.Rows(rowind).Cells(12).Value)
        Dim qty As Integer = CInt(dgReceivingItem.Rows(rowind).Cells(3).Value)
        Dim sub_qty As Integer = 0

        If dgReceivingItem.Rows(rowind).Cells(12).Value <> 0 Then 'kung not equal to zero, meaning, na butang na sa database
            'If ListView1.Items.Count > 0 Then 'if naa nay item sa listview

            'Else ' if walay item sa listview
            '    sub_qty = CInt(txtotherqty.Text)
            'End If

            sub_qty = 0 'set sa og zero para ma refresh

            If btnAddSub.Text = "Add" Then 'kung ADD ang button,

                sub_qty = CDbl(txtotherqty.Text) 'e set sa daan ang value gkan sa txtotherqty.text 
                For i = 0 To ListView1.Items.Count - 1 'e loop ang item sa listview1 para ehapon ang qty

                    sub_qty += CDbl(ListView1.Items(i).SubItems(2).Text)

                Next

                'pag human og loop, check daun kung dako ba ang sub qty kysa actual qty
                If sub_qty > qty Then
                    MessageBox.Show("please check the actual qty of rs..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else 'og walay problema tanan, INSERT ang item

                    insert_sub_rr_items(rr_item_id, a(1), CInt(a(2)), CDbl(a(3)), a(4))

                End If

            ElseIf btnAddSub.Text = "Update" Then 'kung UPDATE ang button
                For i = 0 To ListView1.Items.Count - 1 'e loop ang item sa listview1 para ehapon ang qty

                    If ListView1.Items(i).Selected = False Then 'kung false,kini nga item qty apil sa count
                        sub_qty += CDbl(ListView1.Items(i).SubItems(2).Text)
                    Else 'kini nga item qty walay apil sa count, ang naa sa txtotherqty.text ang e apil og count
                        sub_qty += CInt(txtotherqty.Text)
                    End If
                Next

                'pag human og loop, check daun kung dako ba ang sub qty kysa actual qty
                If sub_qty > qty Then
                    MessageBox.Show("please check the actual qty of rs..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else 'og walay problema tanan, UPDATE ang item

                    update_sub_rr_items(rr_item_id, a(1), CInt(a(2)), CDbl(a(3)), a(4))
                    btnRemove.PerformClick() 'assume, na cancel ang button ani
                End If

            End If

            view_receiving_sub_items()

        Else 'kung equal to zero, meaning, wala pa na butang na sa database

            If ListView1.Items.Count > 0 Then 'if naa nay item sa listview
                For i = 0 To ListView1.Items.Count - 1
                    sub_qty += CDbl(ListView1.Items(i).SubItems(2).Text)
                Next
            Else ' if walay item sa listview
                sub_qty = CInt(txtotherqty.Text)
            End If

            If sub_qty > qty Then
                MessageBox.Show("please check the actual qty of rs..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim lvl As New ListViewItem(a)
            ListView1.Items.Add(lvl)
        End If

        txtOtherItems.Clear()
        txtotheramount.Text = 0
        txtotherqty.Text = 0
        txtUnit.Text = "PCS"

        txtOtherItems.Focus()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        ' ListBox2.Items.Remove(ListBox2.SelectedItem)
        If btnRemove.Text = "Remove" Then
            If MessageBox.Show("Are you sure you want to delete this item?", "SUPPLY INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                If dgReceivingItem.Rows(rowind).Cells(12).Value <> 0 Then
                    Dim query As String = "DELETE FROM dbreceiving_items_sub WHERE rr_item_sub_id = " & CInt(ListView1.SelectedItems(0).Text)
                    UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")
                    ListView1.SelectedItems(0).Remove()
                Else
                    ListView1.SelectedItems(0).Remove()

                End If

            End If

        Else
            btnAddSub.Text = "Add"
            btnRemove.Text = "Remove"
            ListView1.Enabled = True

            txtOtherItems.Clear()
            txtotherqty.Clear()
            txtotheramount.Clear()

            txtOtherItems.Focus()

        End If

    End Sub

    Private Sub txtOtherItems_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOtherItems.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAddSub.PerformClick()

        End If
    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click

    End Sub

    Private Sub txtOtherItems_TextChanged(sender As Object, e As EventArgs) Handles txtOtherItems.TextChanged

    End Sub

    Private Sub txtotherqty_TextChanged(sender As Object, e As EventArgs) Handles txtotherqty.TextChanged

    End Sub

    Private Sub txtotherqty_KeyDown(sender As Object, e As KeyEventArgs) Handles txtotherqty.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAddSub.PerformClick()

        End If
    End Sub


    Private Sub txtotheramount_KeyDown(sender As Object, e As KeyEventArgs) Handles txtotheramount.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAddSub.PerformClick()

        End If
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        btnAddSub.Text = "Update"
        btnRemove.Text = "Cancel"
        ListView1.Enabled = False

        With ListView1.SelectedItems(0)
            txtOtherItems.Text = .SubItems(1).Text
            txtotherqty.Text = .SubItems(2).Text
            txtotheramount.Text = .SubItems(3).Text
            txtUnit.Text = .SubItems(4).Text
        End With

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
End Class
