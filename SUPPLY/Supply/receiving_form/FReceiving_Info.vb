Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FReceiving_Info
    Public txtname As String
    Dim txtbox As TextBox
    Public txtname1 As String
    Dim b As Integer
    Public sup_ids As String
    Private customMsg As New customMessageBox
    Public old_rr_no As String
    Private cOthersCategory As New OTHERSCATEGORY
    Public cTireSerialStore As New PropsFields.tireSerial_props_fields

    Private Sub FReceiving_Info_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        'load_suppliers_list()
        ' show_cmbOperator()
        show_cmb_plate_no()

        ''--COMMONHANDLER--

        If cmbPoNo.Items.Count = 0 Then
        Else
            cmbPoNo.SelectedIndex = 0
        End If

        cmbHauler.SelectedIndex = 2

        For Each ctrl As Control In Panel1.Controls
            If TypeOf ctrl Is Button Then
                AddHandler ctrl.GotFocus, AddressOf commonhadler
            ElseIf TypeOf ctrl Is TextBox Then
                AddHandler ctrl.GotFocus, AddressOf commonhadler
            ElseIf TypeOf ctrl Is ComboBox Then
                AddHandler ctrl.GotFocus, AddressOf commonhadler
            ElseIf TypeOf ctrl Is DateTimePicker Then
                AddHandler ctrl.GotFocus, AddressOf commonhadler
            End If
        Next

        cmbOthersCategory.Items.Add(cOthersCategory.NOT_APPLICABLE)
        cmbOthersCategory.Items.Add(cOthersCategory.FOR_TIRE_STOCKING)
        cmbOthersCategory.SelectedIndex = 0
    End Sub
    Public Sub load_suppliers_list(cmb As ComboBox)
        cmb.Items.Clear()

        Dim sqlcon As New SQLcon
        Dim sqldr As SqlDataReader
        Dim cmd As SqlCommand

        Try
            sqlcon.connection.Open()
            publicquery = "SELECT Supplier_Name FROM dbSupplier ORDER BY Supplier_Name ASC"
            cmd = New SqlCommand(publicquery, sqlcon.connection)
            sqldr = cmd.ExecuteReader
            While sqldr.Read
                'cmb.Items.Add(sqldr.Item("Supplier_Id").ToString)
                cmb.Items.Add(sqldr.Item("Supplier_Name").ToString)
            End While
            sqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()

        End Try
    End Sub
    Public Sub load_po_details()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new1", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 1)


            newDR = newCMD.ExecuteReader

            While newDR.Read

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Public Sub receiving_without_po()
        Try
            If check_if_exist("dbreceiving_info", "invoice_no", txtInvoiceNo.Text, 0) > 0 Then
                If MessageBox.Show("Invoice No. already exist. Do you still want to proceed?", "SUPPLY INFO.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    With FReceiving_Items

                    End With

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub btnReceive_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReceive.Click

        MsgBox(cTireSerialStore.tire_position_id)


        sup_ids = ""
        sup_ids = get_id("dbSupplier", "Supplier_Name", cmbSupplier.Text, 0)
        If cmbSupplier.Text = "" Or txtInvoiceNo.Text = "" Or txtRSNo.Text = "" Or txtSOno.Text = "" Or txtRRno.Text = "" Or txtReceivedby.Text = "" Or txtCheckedby.Text = "" _
            Or txtPlateNo.Text = "" Or cmbHauler.Text = "" Then

            If button_click_name = "CreateReceivingReportToolStripMenuItem" Then
                MessageBox.Show("Please fill up all fields to continue.", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If

        If btnReceive.Text = "Receive" Then
            'date submitted
            FReceiving_Items2.date_submitted = date_submitted()



            If check_if_exist("dbreceiving_info", "invoice_no", txtInvoiceNo.Text, 0) > 0 Then
                If MessageBox.Show("Invoice No. already exist. Do you still want to proceed?", "SUPPLY INFO.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    With FReceiving_Items
                        If button_click_name = "CreateReceivingReportToolStripMenuItem" Then
                            '
                            If FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(18).Text = "CASH WITH RR" Then
                                'released_po2()
                                FReceiving_Items2.DataGridView1.Rows.Clear()
                                released_po3()
                                FReceiving_Items2.btnSave.Text = "Save"
                                FReceiving_Items2.ShowDialog()
                                Exit Sub
                            Else
                                With FRequistionForm
                                    'this code is intended for crushing and hauling rs with po and rr
                                    If .cmbDivision.Text = "CRUSHING AND HAULING" Then
                                        crusher_receiving = 1
                                        crusher_total_qty_received = 0
                                        released_po4()

                                        .Button2.Text = "Save"
                                        FReceiving_Items2.ShowDialog()

                                        'If crusher_total_qty_received > 0 Then
                                        '    .Button2.Text = "Save"
                                        '    FReceiving_Items2.ShowDialog()
                                        'Else
                                        '    MessageBox.Show("Item has been totally received...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        'End If

                                        Exit Sub
                                    Else
                                        released_po1(txtRSNo.Text, cmbPoNo.Text, CInt(FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text))
                                    End If
                                End With
                                'released_po1(txtRSNo.Text, cmbPoNo.Text, CInt(FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text))
                            End If



                        Else
                            released_po(txtRSNo.Text, cmbPoNo.Text)
                        End If

                        .Button2.Text = "Save"
                        .ShowDialog()
                    End With
                Else

                    txtInvoiceNo.Focus()
                    Exit Sub
                End If
            Else
                With FReceiving_Items

                    If button_click_name = "CreateReceivingReportToolStripMenuItem" Then
                        If FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(18).Text = "CASH WITH RR" Then
                            'released_po2()
                            FReceiving_Items2.DataGridView1.Rows.Clear()
                            released_po3()
                            FReceiving_Items2.btnSave.Text = "Save"
                            FReceiving_Items2.ShowDialog()
                            Exit Sub
                        Else
                            With FRequistionForm
                                'this code is intended for crushing and hauling rs with po and rr
                                If .cmbDivision.Text = "CRUSHING AND HAULING" Then
                                    crusher_receiving = 1
                                    crusher_total_qty_received = 0
                                    released_po4()

                                    .Button2.Text = "Save"
                                    FReceiving_Items2.ShowDialog()

                                    'If crusher_total_qty_received > 0 Then
                                    '    .Button2.Text = "Save"
                                    '    FReceiving_Items2.ShowDialog()
                                    'Else
                                    '    MessageBox.Show("Item has been totally received...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    'End If
                                    Exit Sub
                                Else
                                    released_po1(txtRSNo.Text, cmbPoNo.Text, CInt(FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text))
                                End If
                            End With

                        End If
                    Else
                        released_po(txtRSNo.Text, cmbPoNo.Text)
                    End If

                    .Button2.Text = "Save"
                    .ShowDialog()

                End With
            End If

        ElseIf btnReceive.Text = "Add Information" Then

            'initialize class object
            Dim rrInfoInsertUpdate As New Model_King_Dynamic_Update

            'initialize value to insert 
            Dim rr_no As String = txtRRno.Text
            Dim invoiceno As String = txtInvoiceNo.Text
            Dim supplier As New Model._Mod_Supplier
            Dim supplier_id As Integer = supplier.if_exist(cmbSupplier.Text)
            Dim invoice_no As String = txtInvoiceNo.Text
            Dim po_no As String = cmbPoNo.Text
            Dim rs_no As String = txtRSNo.Text
            Dim date_received As DateTime = Date.Parse(DTPReceived.Text)
            Dim received_by As String = txtReceivedby.Text
            Dim checked_by As String = txtCheckedby.Text
            Dim received_status As String = "PENDING"
            Dim so_no As String = "N/A"
            Dim plate_no As String = "N/A"
            Dim plateno_id As Integer = 0
            Dim insource_outsource As String = ""
            Dim operator_id As Integer = 0
            Dim operator_name As String = ""
            Dim date_log As DateTime = Format(Date.Parse(Now), "yyyy-MM-dd HH:mm:ss")
            Dim user_id As Integer = pub_user_id
            Dim date_submitted As DateTime = Date.Parse(dtp_date_submitted.Text)


            Dim columnValues As New Dictionary(Of String, Object)()

            columnValues.Add("rr_no", rr_no)
            columnValues.Add("invoice_no", invoiceno)
            columnValues.Add("supplier_id", supplier_id)
            columnValues.Add("po_no", po_no)
            columnValues.Add("rs_no", rs_no)
            columnValues.Add("date_received", date_received)
            columnValues.Add("received_by", received_by)
            columnValues.Add("checked_by", checked_by)
            columnValues.Add("received_status", received_status)
            columnValues.Add("so_no", so_no)
            columnValues.Add("plateno", plate_no)
            columnValues.Add("Plateno_id", plateno_id)
            columnValues.Add("insource_outsource", insource_outsource)
            columnValues.Add("operator_id", operator_id)
            columnValues.Add("date_log", date_log)
            columnValues.Add("user_id", user_id)
            columnValues.Add("date_submitted", date_submitted)

            For Each row As ListViewItem In FReceivingReportList.lvlreceivingreportlist.Items
                If row.Selected = True Then
                    Dim check_rr_info_id As Integer = row.SubItems(17).Text
                    Dim RRINFOS = FReceivingReportList.get_rr_info(check_rr_info_id) 'get rr info from database

                    If RRINFOS.Count() = 0 Then 'check if exist rrinfo

                        'first insert sa sa rr_info ang data nga naa sa dictionary nga columnValues, second kwaon ang id sa rr_info_id
                        Dim rr_info_id As Integer = rrInfoInsertUpdate.InsertData_and_return_id("dbreceiving_info", columnValues)

                        'third update ang rr_info_id sa row nga ge select ddto na sa rr_items
                        Dim columnUpdateValues As New Dictionary(Of String, Object)()
                        columnUpdateValues.Add("rr_info_id", rr_info_id) 'what to update

                        Dim rr_item_id As Integer = row.Text
                        Dim updateCondition As String = $"rr_item_id = {rr_item_id}" 'query condtion 

                        rrInfoInsertUpdate.UpdateData("dbreceiving_items", columnUpdateValues, updateCondition) 'execute update query            
                    End If
                End If
            Next

            FReceivingReportList.btnSearch.PerformClick() 'refresh using btnSearch        
            Me.Dispose()

        ElseIf btnReceive.Text = "Update" Then
            Dim rr_info_id As Integer = CDbl(FReceivingReportList.lvlreceivingreportlist.SelectedItems(0).SubItems(17).Text)
            Dim ex = MessageBox.Show("Are you sure u want To update the selected item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If ex = MsgBoxResult.Yes Then

#Region "check if rr-no exist in dr"

                Dim rrNo As String = txtRRno.Text
                Dim rsId As Integer = FReceivingReportList.lvlreceivingreportlist.SelectedItems(0).SubItems(16).Text
                Dim isRrNoExistInDr As Boolean = checkRrExistInDr(old_rr_no, rsId)

                If isRrNoExistInDr Then
                    'update all dr that have found same ws-no
                    Dim msgbox As String = "some data will be affected from dr.." & vbCrLf & "do you still want to proceed and update?"

                    If customMsg.messageYesNo(msgbox, "SUPPLY INFO:", MessageBoxIcon.Question) Then
                        updateRrIfFoundInDr(rrNo, rsId)
                    Else
                        Exit Sub
                    End If

                End If

#End Region

                update_rr_info(rr_info_id)
                MessageBox.Show("Successfully updated...", "SUPPLY INFO.", MessageBoxButtons.OK)
                Me.Dispose()
            Else
                Me.Close()
            End If
            FReceiving_Items_Monitoring.load_rr_info()
            FReceivingReportList.btnSearch.PerformClick()
            listfocus(FReceivingReportList.lvlreceivingreportlist, rr_info_id)
            Exit Sub
        End If

proceedhere:

        ''intended for cash with rr
        'If btnReceive.Text = "Update" Then
        '    Dim rr_info_id As Integer = CDbl(FReceivingReportList.lvlreceivingreportlist.SelectedItems(0).SubItems(17).Text)
        '    Dim ex = MessageBox.Show("Are you sure u want To update the selected item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        '    If ex = MsgBoxResult.Yes Then
        '        update_rr_info(rr_info_id)
        '        MessageBox.Show("Successfully updated...", "SUPPLY INFO.", MessageBoxButtons.OK)
        '        Me.Dispose()
        '    Else
        '        Me.Close()
        '    End If
        '    FReceiving_Items_Monitoring.load_rr_info()
        '    FReceivingReportList.btnSearch.PerformClick()
        '    listfocus(FReceivingReportList.lvlreceivingreportlist, rr_info_id)
        '    Exit Sub
        'End If

    End Sub
    Public Sub update_rr_info(ByVal rr_info_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim operator_id As Integer = get_operator_id(cmbOperator.Text)
        Dim plateno_id As Integer = get_plateno_id(txtPlateNo.Text)
        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 13)
            newCMD.Parameters.AddWithValue("@rr_info_id", rr_info_id)
            newCMD.Parameters.AddWithValue("@checked_by", txtCheckedby.Text)
            newCMD.Parameters.AddWithValue("@date_received", Date.Parse(DTPReceived.Text))
            newCMD.Parameters.AddWithValue("@hauler", txtHauler.Text)
            newCMD.Parameters.AddWithValue("@insource_outsource", cmbHauler.Text)
            newCMD.Parameters.AddWithValue("@operator_id", operator_id)
            newCMD.Parameters.AddWithValue("@operator_name", cmbOperator.Text)
            newCMD.Parameters.AddWithValue("@invoice_no", txtInvoiceNo.Text)
            newCMD.Parameters.AddWithValue("@plateno", txtPlateNo.Text)
            newCMD.Parameters.AddWithValue("@plateno_id", plateno_id)
            newCMD.Parameters.AddWithValue("@po_no", cmbPoNo.Text)
            newCMD.Parameters.AddWithValue("@received_by", txtReceivedby.Text)
            newCMD.Parameters.AddWithValue("@received_status", txtReceivedby.Text)
            newCMD.Parameters.AddWithValue("@rr_no", txtRRno.Text)
            newCMD.Parameters.AddWithValue("@rs_no", txtRSNo.Text)
            newCMD.Parameters.AddWithValue("@so_no", txtSOno.Text)
            newCMD.Parameters.AddWithValue("@supplier_id", get_id("dbSupplier", "Supplier_Name", cmbSupplier.Text, 0))
            newCMD.Parameters.AddWithValue("@user_id", pub_user_id)
            newCMD.Parameters.AddWithValue("@date_submitted", Date.Parse(dtp_date_submitted.Text)) 'added /3/13/24

            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("Error MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Public Function get_plateno_id(ByVal x As String) As Integer
        Dim sqlcon As New SQLcon
        Dim sqldr As SqlDataReader
        Dim cmd As SqlCommand

        Try
            sqlcon.connection1.Open()
            publicquery = "SELECT equipListID FROM dbequipment_list WHERE plate_no = '" & x & "'"
            cmd = New SqlCommand(publicquery, sqlcon.connection1)
            sqldr = cmd.ExecuteReader
            While sqldr.Read
                get_plateno_id = sqldr.Item(0).ToString
            End While
            sqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection1.Close()

        End Try
    End Function
    Public Function get_operator_id(ByVal x As String) As Integer

        Dim sqlcon As New SQLcon
        Dim sqldr As SqlDataReader
        Dim cmd As SqlCommand

        Try
            sqlcon.connection1.Open()
            publicquery = "SELECT operator_id FROM dboperator WHERE operator_name = '" & x & "'"
            cmd = New SqlCommand(publicquery, sqlcon.connection1)
            sqldr = cmd.ExecuteReader
            While sqldr.Read
                get_operator_id = sqldr.Item(0).ToString
            End While
            sqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection1.Close()

        End Try
    End Function
    Public Sub released_po1(ByVal rs_no As String, ByVal po_no As String, rs_id As Integer)

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim c As Integer = 0
        Dim t(10) As String
        Try

            With FReceiving_Items
                .DataGridView1.Rows.Clear()

                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_receiving_crud_new1", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure


                If button_click_name = "CreateReceivingWithoutPOToolStripMenuItem" Then
                    newCMD.Parameters.AddWithValue("@n", 11)
                    newCMD.Parameters.AddWithValue("@rs_id", rs_id)
                Else
                    newCMD.Parameters.AddWithValue("@n", 1)
                End If

                newCMD.Parameters.AddWithValue("@rs_no", rs_no)
                newCMD.Parameters.AddWithValue("@po_no", po_no)
                newDR = newCMD.ExecuteReader

                While newDR.Read
                    'FReceiving_Items.cmbItemName.Items.Add(newDR.Item("po_det_id").ToString & "-" & newDR.Item("whItem").ToString & "(" & (newDR.Item("whItemDesc").ToString) & ")")
                    Dim row(20) As String

                    If check_if_exist("dbreceiving_items", "po_det_id", CDbl(newDR.Item("po_det_id").ToString), 1) > 0 Then

                        row(0) = "> " & newDR.Item("whItem").ToString & " ( " & newDR.Item("whItemDesc").ToString & " )"
                        row(1) = CDbl(newDR.Item("qty").ToString) - get_remaining_qty1(1, CDbl(newDR.Item("rs_id").ToString))
                        row(2) = newDR.Item("unit").ToString
                        ' row(3) = "-"
                        row(5) = newDR.Item("po_det_id").ToString
                        row(6) = c
                        row(7) = 0
                        row(8) = get_remaining_qty1(1, CDbl(newDR.Item("rs_id").ToString))
                        row(9) = newDR.Item("rs_id").ToString
                        row(10) = newDR.Item("main_sub").ToString
                        row(11) = newDR.Item("rs_no").ToString

                    Else

                        row(0) = "> " & newDR.Item("whItem").ToString & "(" & newDR.Item("whItemDesc").ToString & ")"
                        row(1) = newDR.Item("qty").ToString
                        row(2) = "-" 'newDR.Item("unit").ToString
                        '  row(3) = "-"
                        row(5) = newDR.Item("po_det_id").ToString
                        row(6) = c
                        row(7) = newDR.Item("qty").ToString
                        row(8) = get_remaining_qty(1, CDbl(row(5)))
                        row(9) = newDR.Item("rs_id").ToString
                        row(10) = newDR.Item("main_sub").ToString
                        row(11) = newDR.Item("rs_no").ToString

                    End If

                    If row(1) = 0 Then
                        GoTo proceedhere
                    End If

                    .DataGridView1.Rows.Add(row)

                    .DataGridView1.Rows(c).DefaultCellStyle.BackColor = Color.DarkGreen
                    .DataGridView1.Rows(c).DefaultCellStyle.ForeColor = Color.White

                    .DataGridView1.Rows(c).Cells("col_sub_item_desc").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_po_qty").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_unit").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_price").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_qty_received").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_po_det_id").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_rr_item_id").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_rs_id").ReadOnly = True

                    Dim gridComboBox1 As New DataGridViewComboBoxCell
                    gridComboBox1.Items.Add("Include") 'Populate the Combobox
                    gridComboBox1.Items.Add("Pending") 'Populate the Combobox
                    .DataGridView1.Item(4, c) = gridComboBox1

                    .DataGridView1.Item(4, c).Value = "Include"

                    Dim a(10) As String

                    a(0) = newDR.Item("whItem").ToString & " " & newDR.Item("whItemDesc").ToString
                    a(1) = 1
                    a(2) = "pc/s" 'row(2)
                    a(3) = FormatNumber(0, 2, , , TriState.True)
                    a(4) = "-"
                    a(5) = "-"
                    a(6) = c
                    a(7) = "-"
                    a(8) = "-"
                    a(9) = newDR.Item("rs_id").ToString

                    .DataGridView1.Rows.Add(a)
                    c += 1

                    .DataGridView1.Rows(c).DefaultCellStyle.BackColor = Color.LightGreen

                    .DataGridView1.Rows(c).Cells("col_desired_qty").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_qty_received").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_po_det_id").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_rr_item_id").ReadOnly = True

                    'Dim gridComboBox11 As New DataGridViewComboBoxCell
                    'gridComboBox11.Items.Add("Include")
                    'gridComboBox11.Items.Add("Exclude")
                    'gridComboBox11.Items.Add("Fixed")
                    '.DataGridView1.Item(4, c) = gridComboBox11
                    .DataGridView1.Item(4, c).Value = "Include"

                    c += 1

                    t(0) = "TOTAL"
                    t(1) = 0
                    t(2) = "-"
                    t(3) = FormatNumber(0, 2, , , TriState.True)
                    t(4) = "-"
                    t(5) = "-"
                    t(6) = row(6)
                    t(7) = "-"
                    t(8) = "-"

                    .DataGridView1.Rows.Add(t)

                    FReceiving_Items_Monitoring.set_cell_readonly(c, True)
                    .DataGridView1.Rows(c).DefaultCellStyle.Font = New Font(Control.DefaultFont, FontStyle.Italic)

                    .DataGridView1.Rows(c).Cells("col_desired_qty").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_qty_received").ReadOnly = True

                    c += 1
proceedhere:

                End While
                newDR.Close()

                .DataGridView1.Columns("col_desired_qty").Visible = True

            End With

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

            Dim aa(10) As String
            Dim grandtotal As Double

            With FReceiving_Items

                For Each row As DataGridViewRow In .DataGridView1.Rows
                    If row.DefaultCellStyle.BackColor = Color.White Then
                        grandtotal = CDbl(row.Cells(3).Value)
                    End If
                Next

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

            End With

        End Try

    End Sub
    Public Sub released_po2()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim c As Integer = 0
        Dim t(10) As String

        Dim get_rs_id As Integer = FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text
        Dim get_rs_no As String = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(1).Text
        Try

            With FReceiving_Items
                .DataGridView1.Rows.Clear()

                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_receiving_crud_new1", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 8)
                newCMD.Parameters.AddWithValue("@rs_id", get_rs_id)
                newCMD.Parameters.AddWithValue("@rs_no", get_rs_no)

                newDR = newCMD.ExecuteReader

                While newDR.Read
                    'FReceiving_Items.cmbItemName.Items.Add(newDR.Item("po_det_id").ToString & "-" & newDR.Item("whItem").ToString & "(" & (newDR.Item("whItemDesc").ToString) & ")")
                    Dim row(20) As String

                    If check_if_exist("dbreceiving_items", "po_det_id", CDbl(newDR.Item("po_det_id").ToString), 1) > 0 Then

                        row(0) = "> " & newDR.Item("item_desc").ToString
                        row(1) = CDbl(newDR.Item("qty").ToString) - get_remaining_qty1(1, CDbl(newDR.Item("rs_id").ToString))
                        row(2) = newDR.Item("unit").ToString
                        ' row(3) = "-"
                        row(5) = newDR.Item("po_det_id").ToString
                        row(6) = c
                        row(7) = 0
                        row(8) = get_remaining_qty1(1, CDbl(newDR.Item("rs_id").ToString))
                        row(9) = newDR.Item("rs_id").ToString
                        row(10) = newDR.Item("main_sub").ToString
                        row(11) = newDR.Item("rs_no").ToString

                    Else

                        row(0) = "> " & newDR.Item("item_desc").ToString & ")"
                        row(1) = newDR.Item("qty").ToString
                        row(2) = "-" 'newDR.Item("unit").ToString
                        '  row(3) = "-"
                        row(5) = newDR.Item("po_det_id").ToString
                        row(6) = c
                        row(7) = newDR.Item("qty").ToString
                        row(8) = get_remaining_qty(1, CDbl(row(5)))
                        row(9) = newDR.Item("rs_id").ToString
                        row(10) = newDR.Item("main_sub").ToString
                        row(11) = newDR.Item("rs_no").ToString

                    End If

                    If row(1) = 0 Then
                        GoTo proceedhere
                    End If

                    .DataGridView1.Rows.Add(row)

                    .DataGridView1.Rows(c).DefaultCellStyle.BackColor = Color.DarkGreen
                    .DataGridView1.Rows(c).DefaultCellStyle.ForeColor = Color.White

                    .DataGridView1.Rows(c).Cells("col_sub_item_desc").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_po_qty").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_unit").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_price").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_qty_received").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_po_det_id").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_rr_item_id").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_rs_id").ReadOnly = True

                    Dim gridComboBox1 As New DataGridViewComboBoxCell
                    gridComboBox1.Items.Add("Include") 'Populate the Combobox
                    gridComboBox1.Items.Add("Pending") 'Populate the Combobox
                    .DataGridView1.Item(4, c) = gridComboBox1

                    .DataGridView1.Item(4, c).Value = "Include"

                    Dim a(10) As String

                    a(0) = newDR.Item("item_desc").ToString
                    a(1) = 1
                    a(2) = "pc/s" 'row(2)
                    a(3) = FormatNumber(0, 2, , , TriState.True)
                    a(4) = "-"
                    a(5) = "-"
                    a(6) = c
                    a(7) = "-"
                    a(8) = "-"
                    a(9) = newDR.Item("rs_id").ToString

                    .DataGridView1.Rows.Add(a)
                    c += 1

                    .DataGridView1.Rows(c).DefaultCellStyle.BackColor = Color.LightGreen

                    .DataGridView1.Rows(c).Cells("col_desired_qty").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_qty_received").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_po_det_id").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_rr_item_id").ReadOnly = True

                    'Dim gridComboBox11 As New DataGridViewComboBoxCell
                    'gridComboBox11.Items.Add("Include")
                    'gridComboBox11.Items.Add("Exclude")
                    'gridComboBox11.Items.Add("Fixed")
                    '.DataGridView1.Item(4, c) = gridComboBox11
                    .DataGridView1.Item(4, c).Value = "Include"

                    c += 1

                    t(0) = "TOTAL"
                    t(1) = 0
                    t(2) = "-"
                    t(3) = FormatNumber(0, 2, , , TriState.True)
                    t(4) = "-"
                    t(5) = "-"
                    t(6) = row(6)
                    t(7) = "-"
                    t(8) = "-"

                    .DataGridView1.Rows.Add(t)

                    FReceiving_Items_Monitoring.set_cell_readonly(c, True)
                    .DataGridView1.Rows(c).DefaultCellStyle.Font = New Font(Control.DefaultFont, FontStyle.Italic)

                    .DataGridView1.Rows(c).Cells("col_desired_qty").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_qty_received").ReadOnly = True

                    c += 1
proceedhere:

                End While
                newDR.Close()

                .DataGridView1.Columns("col_desired_qty").Visible = True

            End With

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

            Dim aa(10) As String
            Dim grandtotal As Double

            With FReceiving_Items

                For Each row As DataGridViewRow In .DataGridView1.Rows
                    If row.DefaultCellStyle.BackColor = Color.White Then
                        grandtotal = CDbl(row.Cells(3).Value)
                    End If
                Next

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

            End With

        End Try

    End Sub
    Public Sub released_po3()
        b = 0
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim inc As Integer = 1

        FReceiving_Items.DataGridView1.Rows.Clear()

        Dim get_rs_id As Integer = FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text
        Dim get_rs_no As String = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(1).Text

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new1", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 10)
            newCMD.Parameters.AddWithValue("@rs_no", get_rs_no)

            newDR = newCMD.ExecuteReader
            Dim a(15) As String

            While newDR.Read
                If newDR.Item("total_qty_received").ToString = newDR.Item("qty").ToString Then
                    GoTo proceedhere
                End If

                With FReceiving_Items2
                    a(0) = newDR.Item("rs_no").ToString
                    a(1) = newDR.Item("item_desc").ToString
                    a(2) = newDR.Item("qty").ToString
                    a(3) = 0
                    a(4) = IIf(IsNumeric(newDR.Item("total_qty_received").ToString) = True, newDR.Item("total_qty_received").ToString, 0)
                    a(5) = "-"
                    a(6) = newDR.Item("unit").ToString
                    a(7) = ""
                    a(8) = newDR.Item("po_det_id").ToString
                    a(9) = newDR.Item("rs_id").ToString
                    a(10) = ""
                    a(11) = ""
                    a(12) = inc
                    a(3) = a(2) - a(4)

                    .DataGridView1.Rows.Add(a)

                    .DataGridView1.Rows(b).DefaultCellStyle.BackColor = Color.DarkGreen
                    .DataGridView1.Rows(b).DefaultCellStyle.ForeColor = Color.White
                    .DataGridView1.Rows(b).DefaultCellStyle.Font = New Font("arial", 12, FontStyle.Bold)

                    Dim gridComboBox1 As New DataGridViewComboBoxCell
                    gridComboBox1.Items.Add("Include") 'Populate the Combobox
                    gridComboBox1.Items.Add("Pending") 'Populate the Combobox
                    .DataGridView1.Item(11, b) = gridComboBox1
                    .DataGridView1.Item(11, b).Value = "Include"

                    .DataGridView1.Rows(b).Cells("col_sub_item_desc").ReadOnly = True
                    .DataGridView1.Rows(b).Cells("col_po_qty").ReadOnly = True
                    .DataGridView1.Rows(b).Cells("col_unit").ReadOnly = True
                    .DataGridView1.Rows(b).Cells("col_price").ReadOnly = True
                    .DataGridView1.Rows(b).Cells("col_qty_received").ReadOnly = True
                    .DataGridView1.Rows(b).Cells("col_po_det_id").ReadOnly = True
                    .DataGridView1.Rows(b).Cells("col_rr_item_id").ReadOnly = True
                    .DataGridView1.Rows(b).Cells("col_rs_id").ReadOnly = True

                    b += 1

                    rr_sub(a(9), a(0), a(2) - a(4), newDR.Item("item_desc").ToString, inc)
                    inc += 1
                End With
proceedhere:

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
                a(5) = FormatNumber(0, 2,,, TriState.True)
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

    Public Sub released_po4()

        b = 0
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim inc As Integer = 1

        FReceiving_Items2.DataGridView1.Rows.Clear()

        Try

            Dim get_rs_id As Integer = FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text
            Dim get_rs_no As String = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(1).Text

            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new1", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 13)
            newCMD.Parameters.AddWithValue("@rs_no", get_rs_no)
            newCMD.Parameters.AddWithValue("@rs_id", get_rs_id)
            newDR = newCMD.ExecuteReader

            Dim rt As New Class_RR
            Dim qty_received, po_qty As Decimal

            With FRequistionForm.lvlrequisitionlist.SelectedItems(0)
                qty_received = rt.total_received_po(.SubItems(35).Text, FRequistionForm.lvlrequisitionlist)
                po_qty = rt.po_qty(FRequistionForm.lvlrequisitionlist)
            End With

            Dim a(15) As String

            While newDR.Read


                With FReceiving_Items2
                    a(0) = newDR.Item("rs_no").ToString
                    a(1) = newDR.Item("item_desc").ToString
                    a(2) = po_qty - qty_received

                    'a(2) = CDec(newDR.Item("qty").ToString) - CDec(newDR.Item("qty_received").ToString)
                    'a(2) = IIf(newDR.Item("qty").ToString = "", 0, newDR.Item("qty_received").ToString) - IIf(newDR.Item("qty_received").ToString = "", 0, newDR.Item("qty_received").ToString)
                    'a(4) = IIf(IsNumeric(newDR.Item("qty_received").ToString) = True, newDR.Item("qty_received").ToString, 0)
                    a(4) = qty_received
                    a(5) = "-"
                    a(6) = newDR.Item("unit").ToString
                    a(7) = ""
                    a(8) = newDR.Item("po_det_id").ToString
                    a(9) = newDR.Item("rs_id").ToString
                    a(10) = ""
                    a(11) = ""
                    a(12) = inc
                    'a(3) = CDec(newDR.Item("qty").ToString) - CDec(newDR.Item("qty_received").ToString)
                    a(3) = po_qty - qty_received

                    .DataGridView1.Rows.Add(a)

                    crusher_total_qty_received = CDec(newDR.Item("qty").ToString) - CDec(newDR.Item("qty_received").ToString)

                    .DataGridView1.Rows(b).DefaultCellStyle.BackColor = Color.DarkGreen
                    .DataGridView1.Rows(b).DefaultCellStyle.ForeColor = Color.White
                    .DataGridView1.Rows(b).DefaultCellStyle.Font = New Font("arial", 12, FontStyle.Bold)

                    Dim gridComboBox1 As New DataGridViewComboBoxCell
                    gridComboBox1.Items.Add("Include") 'Populate the Combobox
                    gridComboBox1.Items.Add("Pending") 'Populate the Combobox
                    .DataGridView1.Item(11, b) = gridComboBox1
                    .DataGridView1.Item(11, b).Value = "Include"

                    .DataGridView1.Rows(b).Cells("col_sub_item_desc").ReadOnly = True
                    .DataGridView1.Rows(b).Cells("col_po_qty").ReadOnly = True
                    .DataGridView1.Rows(b).Cells("col_unit").ReadOnly = True
                    .DataGridView1.Rows(b).Cells("col_price").ReadOnly = True
                    .DataGridView1.Rows(b).Cells("col_qty_received").ReadOnly = True
                    .DataGridView1.Rows(b).Cells("col_po_det_id").ReadOnly = True
                    .DataGridView1.Rows(b).Cells("col_rr_item_id").ReadOnly = True
                    .DataGridView1.Rows(b).Cells("col_rs_id").ReadOnly = True

                    b += 1

                    'rr_sub(a(9), a(0), CDec(newDR.Item("qty").ToString) - CDec(newDR.Item("qty_received").ToString), newDR.Item("item_desc").ToString, inc)
                    rr_sub(a(9), a(0), a(2), newDR.Item("item_desc").ToString, inc)
                    inc += 1
                End With
proceedhere:

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
            a(5) = FormatNumber(0, 2,,, TriState.True)
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
    Private Sub rr_sub(rs_id As Integer, rs_no As String, qty As Decimal, item_desc As String, inc As Integer)
        Dim a(15) As String

        With FReceiving_Items2

            a(0) = rs_no
            a(1) = item_desc
            a(2) = qty
            a(3) = "-"
            a(4) = "-"
            a(5) = FormatNumber(0, 2,,, TriState.True)
            a(6) = "pc/s"
            a(7) = ""
            a(8) = 0
            a(9) = 0
            a(10) = rs_id
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

            b += 1
        End With
    End Sub


    Public Sub released_po(ByVal rs_no As String, ByVal po_no As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim c As Integer = 0
        Dim t(10) As String
        Try

            With FReceiving_Items
                .DataGridView1.Rows.Clear()

                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_receiving_crud_new1", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure


                If button_click_name = "CreateReceivingWithoutPOToolStripMenuItem" Then
                    newCMD.Parameters.AddWithValue("@n", 11)
                Else
                    newCMD.Parameters.AddWithValue("@n", 1)
                End If

                newCMD.Parameters.AddWithValue("@rs_no", rs_no)
                newCMD.Parameters.AddWithValue("@po_no", po_no)
                newDR = newCMD.ExecuteReader

                While newDR.Read
                    'FReceiving_Items.cmbItemName.Items.Add(newDR.Item("po_det_id").ToString & "-" & newDR.Item("whItem").ToString & "(" & (newDR.Item("whItemDesc").ToString) & ")")
                    Dim row(20) As String

                    If check_if_exist("dbreceiving_items", "po_det_id", CDbl(newDR.Item("po_det_id").ToString), 1) > 0 Then

                        row(0) = "> " & newDR.Item("whItem").ToString & " ( " & newDR.Item("whItemDesc").ToString & " )"
                        row(1) = CDbl(newDR.Item("qty").ToString) - get_remaining_qty(1, CDbl(newDR.Item("po_det_id").ToString))
                        row(2) = newDR.Item("unit").ToString
                        ' row(3) = "-"
                        row(5) = newDR.Item("po_det_id").ToString
                        row(6) = c
                        row(7) = 0
                        row(8) = get_remaining_qty(1, CDbl(row(5)))
                        row(9) = newDR.Item("rs_id").ToString
                        row(10) = newDR.Item("main_sub").ToString
                        row(11) = newDR.Item("rs_no").ToString

                    Else

                        row(0) = "> " & newDR.Item("whItem").ToString & "(" & newDR.Item("whItemDesc").ToString & ")"
                        row(1) = newDR.Item("qty").ToString
                        row(2) = "-" 'newDR.Item("unit").ToString
                        '  row(3) = "-"
                        row(5) = newDR.Item("po_det_id").ToString
                        row(6) = c
                        row(7) = newDR.Item("qty").ToString
                        row(8) = 0
                        row(9) = newDR.Item("rs_id").ToString
                        row(10) = newDR.Item("main_sub").ToString
                        row(11) = newDR.Item("rs_no").ToString

                    End If

                    If row(1) = 0 Then
                        GoTo proceedhere
                    End If

                    .DataGridView1.Rows.Add(row)

                    .DataGridView1.Rows(c).DefaultCellStyle.BackColor = Color.DarkGreen
                    .DataGridView1.Rows(c).DefaultCellStyle.ForeColor = Color.White

                    .DataGridView1.Rows(c).Cells("col_sub_item_desc").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_po_qty").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_unit").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_price").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_qty_received").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_po_det_id").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_rr_item_id").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_rs_id").ReadOnly = True

                    Dim gridComboBox1 As New DataGridViewComboBoxCell
                    gridComboBox1.Items.Add("Include") 'Populate the Combobox
                    gridComboBox1.Items.Add("Pending") 'Populate the Combobox
                    .DataGridView1.Item(4, c) = gridComboBox1

                    .DataGridView1.Item(4, c).Value = "Include"

                    Dim a(10) As String

                    a(0) = newDR.Item("whItem").ToString & " " & newDR.Item("whItemDesc").ToString
                    a(1) = 1
                    a(2) = "pc/s" 'row(2)
                    a(3) = FormatNumber(0, 2, , , TriState.True)
                    a(4) = "-"
                    a(5) = "-"
                    a(6) = c
                    a(7) = "-"
                    a(8) = "-"
                    a(9) = newDR.Item("rs_id").ToString

                    .DataGridView1.Rows.Add(a)
                    c += 1

                    .DataGridView1.Rows(c).DefaultCellStyle.BackColor = Color.LightGreen

                    .DataGridView1.Rows(c).Cells("col_desired_qty").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_qty_received").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_po_det_id").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_rr_item_id").ReadOnly = True

                    'Dim gridComboBox11 As New DataGridViewComboBoxCell
                    'gridComboBox11.Items.Add("Include")
                    'gridComboBox11.Items.Add("Exclude")
                    'gridComboBox11.Items.Add("Fixed")
                    '.DataGridView1.Item(4, c) = gridComboBox11
                    .DataGridView1.Item(4, c).Value = "Include"

                    c += 1

                    t(0) = "TOTAL"
                    t(1) = 0
                    t(2) = "-"
                    t(3) = FormatNumber(0, 2, , , TriState.True)
                    t(4) = "-"
                    t(5) = "-"
                    t(6) = row(6)
                    t(7) = "-"
                    t(8) = "-"

                    .DataGridView1.Rows.Add(t)

                    FReceiving_Items_Monitoring.set_cell_readonly(c, True)
                    .DataGridView1.Rows(c).DefaultCellStyle.Font = New Font(Control.DefaultFont, FontStyle.Italic)

                    .DataGridView1.Rows(c).Cells("col_desired_qty").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_qty_received").ReadOnly = True

                    c += 1
proceedhere:

                End While
                newDR.Close()

                .DataGridView1.Columns("col_desired_qty").Visible = True

            End With

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

            Dim aa(10) As String
            Dim grandtotal As Double

            With FReceiving_Items

                For Each row As DataGridViewRow In .DataGridView1.Rows
                    If row.DefaultCellStyle.BackColor = Color.White Then
                        grandtotal = CDbl(row.Cells(3).Value)
                    End If
                Next

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

            End With

        End Try

    End Sub
    Public Function get_remaining_qty1(ByVal n As Integer, ByVal rs_id As Integer) As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new1", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 44)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                If n = 1 Then
                    get_remaining_qty1 += CDbl(newDR.Item("desired_qty").ToString)
                End If
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Function get_remaining_qty(ByVal n As Integer, ByVal po_det_id As Integer) As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new1", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 4)
            newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                If n = 1 Then
                    get_remaining_qty += CDbl(newDR.Item("desired_qty").ToString)
                End If
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        FReceiving_Items_Monitoring.ShowDialog()

    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Me.Dispose()

    End Sub

    Private Sub cmbSupplier_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSupplier.GotFocus, txtInvoiceNo.GotFocus, txtPOno.GotFocus, txtRSNo.GotFocus, txtSOno.GotFocus, txtHauler.GotFocus, txtRRno.GotFocus,
        txtReceivedby.GotFocus, txtCheckedby.GotFocus, txtPlateNo.GotFocus

        sender.backcolor = Color.Yellow

        'If txtReceivedby.Focused Then
        '    txtname = txtReceivedby.Name
        '    txtReceivedby.SelectAll()
        'ElseIf txtCheckedby.Focused Then
        '    txtname = txtCheckedby.Name
        '    txtCheckedby.SelectAll()
        'End If

        'list_box.Visible = False

        If txtReceivedby.Focused Then
            txtname1 = txtReceivedby.Name
            txtReceivedby.SelectAll()
        ElseIf txtCheckedby.Focused Then
            txtname1 = txtCheckedby.Name
            txtCheckedby.SelectAll()
        ElseIf txtPlateNo.Focused Then
            txtname1 = txtPlateNo.Name
            txtPlateNo.SelectAll()
        End If

    End Sub

    Private Sub txtReceivedby_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReceivedby.KeyDown, txtCheckedby.KeyDown, txtPlateNo.KeyDown

        'If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
        '    If list_box.Visible = True Then
        '        If list_box.Items.Count > 0 Then
        '            list_box.Focus()
        '            list_box.SelectedIndex = 0
        '        End If
        '    End If
        'End If

        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
            If list_box.Visible = True Then
                If list_box.Items.Count > 0 Then
                    list_box.Focus()
                    list_box.SelectedIndex = 0
                End If
            End If
            'ListBox1.Focus()
        End If

    End Sub

    Private Sub cmbSupplier_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSupplier.Leave, txtInvoiceNo.Leave, txtPOno.Leave, txtRSNo.Leave, txtSOno.Leave, txtHauler.Leave, txtRRno.Leave, txtReceivedby.Leave,
        txtCheckedby.Leave, txtPlateNo.Leave

        sender.backcolor = Color.White

    End Sub

    Private Sub txtReceivedby_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReceivedby.TextChanged
        'Try
        '    If txtReceivedby.Text = "" Then
        '        lbox_receiving.Location = New System.Drawing.Point(txtReceivedby.Location.X, txtReceivedby.Location.Y + txtReceivedby.Height)
        '    Else
        '        With lbox_receiving
        '            .Location = New System.Drawing.Point(txtReceivedby.Location.X, txtReceivedby.Location.Y + txtReceivedby.Height)
        '            .Visible = True
        '            .Items.Clear()
        '            .Width = txtReceivedby.Width
        '        End With

        '        lbox_list(txtReceivedby.Text, 0)

        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub txtCheckedby_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCheckedby.TextChanged
        'Try
        '    If txtCheckedby.Text = "" Then
        '        lbox_receiving.Location = New System.Drawing.Point(txtCheckedby.Location.X, txtCheckedby.Location.Y + txtCheckedby.Height)
        '    Else
        '        With lbox_receiving
        '            .Location = New System.Drawing.Point(txtCheckedby.Location.X, txtCheckedby.Location.Y + txtCheckedby.Height)
        '            .Visible = True
        '            .BringToFront()
        '            .Items.Clear()
        '            .Width = txtCheckedby.Width
        '        End With

        '        lbox_list(txtCheckedby.Text, 1)

        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try


    End Sub

    Public Sub lbox_list(ByVal txtbox As TextBox, ByVal n As Integer, list As ListBox)
        Dim sql As New SQLcon
        Dim newcmd As SqlCommand
        Dim newdr As SqlDataReader
        Dim count As Integer = 0
        list.Items.Clear()
        Try
            sql.connection.Open()

            If n = 2 Then
                publicquery = "SELECT DISTINCT received_by FROM dbreceiving_info WHERE received_by LIKE '%" & txtbox.Text & "%'"
            ElseIf n = 3 Then
                publicquery = "SELECT DISTINCT checked_by FROM dbreceiving_info WHERE checked_by LIKE '%" & txtbox.Text & "%'"
            ElseIf n = 1 Then
                'show_cmb_plate_no()
                list.Items.Clear()

                Dim sqlcon1 As New SQLcon
                Dim sqldr1 As SqlDataReader
                Dim cmd1 As SqlCommand

                Try
                    sqlcon1.connection1.Open()
                    publicquery = "SELECT plate_no FROM dbequipment_list WHERE plate_no LIKE '%" & txtbox.Text & "%'"
                    cmd1 = New SqlCommand(publicquery, sqlcon1.connection1)
                    sqldr1 = cmd1.ExecuteReader
                    While sqldr1.Read

                        list.Items.Add(sqldr1.Item("plate_no").ToString)

                    End While
                    sqldr1.Close()

                Catch ex As Exception
                    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    sqlcon1.connection1.Close()

                End Try
                GoTo anhidiri
            End If


            'For received_by and checked_by
            newcmd = New SqlCommand(publicquery, sql.connection)
            newdr = newcmd.ExecuteReader

            While newdr.Read
                If n = 2 Then
                    list.Items.Add(newdr.Item("received_by").ToString)
                ElseIf n = 3 Then
                    list.Items.Add(newdr.Item("checked_by").ToString)
                End If
                count += 1
            End While

            If count > 0 Then
                list.Visible = True
            Else
                list.Visible = False
            End If

            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sql.connection.Close()
        End Try
anhidiri:
    End Sub
    Private Sub commonhadler(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If list_box.Visible = True Then
            list_box.Visible = False
        End If
    End Sub

    Private Sub lbox_receiving_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles list_box.DoubleClick

        'If list_box.SelectedItems.Count > 0 Then
        '    For Each ctr As Control In Panel1.Controls
        '        If ctr.Name = txtname Then
        '            ctr.Text = list_box.SelectedItem.ToString
        '            ctr.Focus()
        '        End If
        '    Next
        '    list_box.Visible = False
        'Else
        '    MessageBox.Show("Pls select data", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End If
        If list_box.SelectedItems.Count > 0 Then
            For Each ctr As Control In Panel1.Controls
                If ctr.Name = txtname1 Then
                    ctr.Text = list_box.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next
            list_box.Visible = False
        End If
    End Sub

    Private Sub lbox_receiving_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles list_box.KeyDown

        'If e.KeyCode = Keys.Enter Then
        '    For Each ctr As Control In Panel1.Controls
        '        If ctr.Name = txtname Then
        '            ctr.Text = list_box.SelectedItem.ToString
        '            ctr.Focus()
        '        End If
        '    Next

        '    list_box.Visible = False
        'End If
        If e.KeyCode = Keys.Enter Then
            If list_box.SelectedItems.Count > 0 Then
                For Each ctr As Control In Panel1.Controls
                    If ctr.Name = txtname1 Then
                        ctr.Text = list_box.SelectedItem.ToString
                        ctr.Focus()
                    End If
                Next
                list_box.Visible = False
            End If
        ElseIf e.KeyCode = Keys.Up Then
            If list_box.SelectedIndex = 0 Then
                Dim f As Integer
                f = 1

                If f = 1 Then
                    list_box.SelectedIndex = 0
                    txtbox.Focus()
                End If
                'pub_textbox.Focus()
            End If
        End If
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub txtbox_list(sender As Object, e As EventArgs) Handles txtPlateNo.TextChanged, txtReceivedby.TextChanged, txtCheckedby.TextChanged
        txtbox = sender
        Dim n As Integer

        If txtbox.Name = "txtPlateNo" Then : n = 1 : ElseIf txtbox.Name = "txtReceivedby" Then : n = 2 : ElseIf txtbox.Name = "txtCheckedby" Then : n = 3 : End If

        Try
            If txtbox.Text = "" Then
                list_box.Location = New System.Drawing.Point(txtbox.Location.X, txtbox.Location.Y + txtbox.Height)
                list_box.Visible = False
            Else
                With list_box
                    .Location = New System.Drawing.Point(txtbox.Location.X, txtbox.Location.Y + txtbox.Height)
                    .Visible = True
                    .Items.Clear()
                    .Width = txtbox.Width
                    .BringToFront()
                End With

                'get_textbox_value(n, txtbox)
                lbox_list(txtbox, n, list_box)

            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbSupplier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSupplier.SelectedIndexChanged

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub cmbPoNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPoNo.SelectedIndexChanged

    End Sub

    Private Sub cmbSupplier_Click(sender As Object, e As EventArgs) Handles cmbSupplier.Click

    End Sub

    Private Sub cmbHauler_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbHauler.SelectedIndexChanged
        If cmbHauler.Text = "Insource" Then
            cmbOperator.DropDownStyle = ComboBoxStyle.DropDownList
            show_cmbOperator(cmbOperator)
            txtHauler.Text = "Insource"
            cmbOperator.Enabled = True
        ElseIf cmbHauler.Text = "Outsource" Then
            'cmbOperator.Items.Clear()
            cmbOperator.DropDownStyle = ComboBoxStyle.Simple
            txtHauler.Text = "Outsource"
            cmbOperator.Enabled = True
        ElseIf cmbHauler.Text = "N/A" Then
            cmbOperator.Enabled = False

        End If
    End Sub

    Private Sub cmbOperator_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOperator.SelectedIndexChanged

    End Sub
    Sub show_cmbOperator(cmb As ComboBox)
        cmb.Items.Clear()

        Dim sqlcon As New SQLcon
        Dim sqldr As SqlDataReader
        Dim cmd As SqlCommand

        Try
            sqlcon.connection1.Open()
            publicquery = "SELECT operator_name FROM dboperator ORDER BY operator_name ASC"
            cmd = New SqlCommand(publicquery, sqlcon.connection1)
            sqldr = cmd.ExecuteReader
            While sqldr.Read
                cmb.Items.Add(sqldr.Item("operator_name").ToString)
            End While
            sqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection1.Close()

        End Try
    End Sub
    Sub show_cmb_plate_no()
        list_box.Items.Clear()

        Dim sqlcon1 As New SQLcon
        Dim sqldr1 As SqlDataReader
        Dim cmd1 As SqlCommand

        Try
            sqlcon1.connection1.Open()
            publicquery = "SELECT plate_no FROM dbequipment_list"
            cmd1 = New SqlCommand(publicquery, sqlcon1.connection1)
            sqldr1 = cmd1.ExecuteReader
            While sqldr1.Read

                list_box.Items.Add(sqldr1.Item("plate_no").ToString)

            End While
            sqldr1.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon1.connection1.Close()

        End Try


    End Sub

    Private Sub list_box_SelectedIndexChanged(sender As Object, e As EventArgs) Handles list_box.SelectedIndexChanged

    End Sub

    Private Sub list_box_KeyUp(sender As Object, e As KeyEventArgs) Handles list_box.KeyUp
        'If e.KeyCode = Keys.Up Then
        '    If list_box.SelectedIndex = 0 Then
        '        txtbox.Focus()
        '    End If
        'End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        insert_received()

    End Sub
    Sub insert_received()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        MsgBox(get_id("dbSupplier", "Supplier_Name", cmbSupplier.Text, 0))
    End Sub

    Public Function date_submitted() As DateTime
        Dim rr_submitted As DateTime = Date.Parse(dtp_date_submitted.Text)
        Dim timenow As DateTime = Date.Parse(Now)

        Dim result As String = $"{Format(rr_submitted, "yyyy-MM-dd")} {Format(timenow, "HH:mm:ss")}"
        date_submitted = Date.Parse(result)

        Return date_submitted
    End Function

    Private Sub Button4_Click_1(sender As Object, e As EventArgs)
        MsgBox(date_submitted)
    End Sub

    'new FUNCTIONS
    Private Function checkRrExistInDr(oldRrNo As String, rs_id As Integer) As Boolean
        Try
            Dim c As New ColumnValuesObj

            Dim tableA As String = "dbDeliveryReport_info"
            Dim tableB As String = "dbDeliveryReport_items"

            Dim cc As New ColumnValuesObj
            Dim myAlias1 As String = "a"
            Dim myAlias2 As String = "b"
            Dim tnt As New tableNameType

            cc.addColumn($"{myAlias1}.dr_info_id")
            cc.setCondition($"{myAlias1}.rr_no = '{oldRrNo}' and {myAlias2}.rs_id = {rs_id}")
            cc.addJoinClause($"LEFT JOIN {tableB} {myAlias2} ON {myAlias2}.dr_info_id = {myAlias1}.dr_info_id")
            cc.selectQuery("dbDeliveryReport_info", True, myAlias1, tnt.supply_table)

            Dim result = cc.selectQuery_and_return_data(tableA, True, "a", tnt.supply_table)

            If result.count > 0 Then
                Return True
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function

    Private Sub updateRrIfFoundInDr(rrNo As String, rsId As Integer)
        Try
            Dim c As New Model_King_Dynamic_Update()
            Dim cv As New ColumnValuesObj

            Dim tableA As String = "dbDeliveryReport_info"
            Dim tableB As String = "dbDeliveryReport_items"

            Dim joinClauses As New List(Of String)
            Dim condition As String = $"rr_no = '{old_rr_no}' and rs_id = {rsId}"

            joinClauses.Add($"LEFT JOIN {tableB} b ON b.dr_info_id = a.dr_info_id")
            cv.add("rr_no", rrNo)
            c.UpdateDataByTableJoin(tableA, cv.getValues(), condition, joinClauses)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub cmbOthersCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOthersCategory.SelectedIndexChanged
        If cmbOthersCategory.Text = cOthersCategory.FOR_TIRE_STOCKING Then
            txtSerialNo.Enabled = True
            Button4.Enabled = True
        Else
            txtSerialNo.Enabled = False
            txtSerialNo.Clear()
            Button4.Enabled = False
        End If
    End Sub

    Private Sub Button4_Click_2(sender As Object, e As EventArgs) Handles Button4.Click
        FTireSerial.forReceivingInfo = True
        FTireSerial.ShowDialog()
    End Sub
End Class