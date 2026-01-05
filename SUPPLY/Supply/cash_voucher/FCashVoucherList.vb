Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FCashVoucherList
    Dim sqlcon As New SQLcon
    Dim cmd As SqlCommand
    Dim sqldr As SqlDataReader
    Dim process As String
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Dispose()
    End Sub

    Private Sub FCashVoucherList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        panel_cv_date_to_from.Visible = False
        cmbSearch.Text = "Search by CV No."
        'load_cv_List()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        'load_cv_List()
        '        Search by RS No.
        'Search by CV No.
        'Search by CV Date
        'Search by Charge To
        'Search by Item Description
        'Filter by Month/Year

        If cmbSearch.Text = "Search by CV No." Then
            search_by(44)
        ElseIf cmbSearch.Text = "Search by RS No." Then
            search_by(45)
        ElseIf cmbSearch.Text = "Search by CV Date" Then
            search_by(46)
        ElseIf cmbSearch.Text = "Search by Item Description" Then
            search_by(47)
        ElseIf cmbSearch.Text = "Filter by Month/Year" Then
            panel_cv_date_to_from.Visible = True
            'search_by(48)
        End If


    End Sub

    Public Sub search_by(ByVal n As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        lvlvoucherlist.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_cashvoucher_query", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", n)

            If cmbSearch.Text = "Search by CV Date" Then
                newCMD.Parameters.AddWithValue("@date_from", Format(Date.Parse(dtp_cv_date.Value.ToString), "MM/dd/yyyy"))
            ElseIf cmbSearch.Text = "Filter by Month/Year" Then
                newCMD.Parameters.AddWithValue("@date_from", Date.Parse(Dtp_cv_datefrom.Text))
                newCMD.Parameters.AddWithValue("@date_to", Date.Parse(Dtp_cv_dateto.Text))
                'newCMD.Parameters.AddWithValue("@rs_no", "")
            ElseIf cmbSearch.Text = "Search by Item Description" Then
                newCMD.Parameters.AddWithValue("@cvItemDesc", txtSearch.Text)
            ElseIf cmbSearch.Text = "Search by CV No." Then
                newCMD.Parameters.AddWithValue("@cvNo", txtSearch.Text)
            Else
                newCMD.Parameters.AddWithValue("@rs_no", txtSearch.Text)
            End If

            Dim a(30) As String

            newDR = newCMD.ExecuteReader
            While newDR.Read

                Dim inout As String = newDR.Item("IN_OUT").ToString
                Dim rs_date As DateTime = newDR.Item("date_req").ToString
                Dim po_date As DateTime = newDR.Item("po_date").ToString
                Dim rr_qty As Integer = get_rr_qty(newDR.Item("rs_id").ToString, 1)
                Dim rs_qty As Integer = CInt(newDR.Item("qty").ToString)

                If inout = "IN" Or inout = "OTHERS" Or inout = "QUARRY-IN" Or inout = "BORROWER" Then
                    a(4) = FRequistionForm.GET_ITEM_DESC(newDR.Item("wh_id").ToString)

                ElseIf inout = "FACILITIES" Or inout = "TOOLS" Or inout = "ADD-ON" Then
                    a(4) = FRequistionForm.GET_ITEM_DESC_FROM_FACILITIES(newDR.Item("wh_id").ToString)
                End If

                a(0) = newDR.Item("po_det_id").ToString
                a(1) = Format(Date.Parse(newDR.Item("po_date").ToString), "MM/dd/yyyy")
                a(2) = newDR.Item("rs_no").ToString
                a(3) = newDR.Item("po_no").ToString
                a(5) = newDR.Item("Supplier_Name").ToString
                a(6) = FReceivingReport.multiplecharges(CInt(newDR.Item("rs_id").ToString), 1)
                a(7) = newDR.Item("qty").ToString
                a(8) = rr_qty
                a(9) = FormatNumber(CDbl(newDR.Item("unit_price").ToString), 2, , TriState.True)
                a(10) = FormatNumber(CDbl(get_rr_qty(newDR.Item("rs_id").ToString, 1)) * CDbl(newDR.Item("unit_price").ToString), 2, , TriState.True)
                a(12) = newDR.Item("rs_id").ToString
                a(14) = newDR.Item("IN_OUT").ToString
                a(15) = newDR.Item("type_of_purchasing").ToString

                If rr_qty = 0 Then
                    'a(11) = "NO RECEIVER YET"
                    a(13) = "PENDING"
                ElseIf rr_qty < rs_qty Then
                    'a(11) = get_rr_qty(newDR.Item("rs_id").ToString, 2)
                    a(13) = "PARTIALLY RECEIVED"
                Else
                    'a(11) = get_rr_qty(newDR.Item("rs_id").ToString, 2)
                    a(13) = "RECEIVED"
                End If

                If cmbSearch.Text = "Search by RS No." Then
                    If UCase(a(2)) Like "*" & UCase(txtSearch.Text) & "*" Then
                    Else
                        GoTo proceedhere
                    End If

                ElseIf cmbSearch.Text = "Search by Item Name" Then
                    If UCase(a(4)) Like "*" & UCase(txtSearch.Text) & "*" Then
                    Else
                        GoTo proceedhere
                    End If
                End If


                Dim lvl As New ListViewItem(a)
                lvlvoucherlist.Items.Add(lvl)

proceedhere:

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Public Function get_rr_qty(ByVal rs_id As Integer, ByVal n As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 17)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                If n = 1 Then
                    get_rr_qty += CDbl(newDR.Item("desired_qty").ToString())
                ElseIf n = 2 Then
                    get_rr_qty = newDR.Item("received_by").ToString
                End If

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
            GC.Collect()

        End Try

    End Function

    Public Sub load_cv_List()
        lvlvoucherlist.Items.Clear()
        Dim rs_id As Integer = 0
        Try
            sqlcon.connection.Open()
            cmd = New SqlCommand("proc_cashvoucher_query", sqlcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@n", 4)
            sqldr = cmd.ExecuteReader

            While sqldr.Read
                'Dim QUERY1 As String
                Dim a(15) As String
                rs_id = sqldr.Item("rs_id").ToString

                'QUERY1 = "SELECT item_desc FROM dbrequisition_slip WHERE rs_id = " & rs_id
                'Dim item_desc As String = get_specific_column_value(QUERY1, 0)

                get_process(rs_id)
                a(0) = sqldr.Item("cv_info_id").ToString
                a(1) = Format(Date.Parse(sqldr.Item("cv_date").ToString), "MM/dd/yyyy")
                a(2) = sqldr.Item("rs_no").ToString
                a(3) = sqldr.Item("cv_no").ToString
                a(4) = FRequistionForm.GET_ITEM_DESC(sqldr.Item("wh_id").ToString)
                a(5) = sqldr.Item("Supplier_Name").ToString
                If process = "PERSONAL" Or process = "ADFIL" Then
                    a(6) = GET_equip_desc_AND_proj_desc(sqldr.Item("cv_charge_to_id").ToString, 3)

                    Dim mcharges As String = get_multiple_charges(rs_id)

                    If mcharges.Length < 1 Then
                    Else
                        mcharges = mcharges.Trim().Substring(0, mcharges.Length - 1)
                        a(6) = a(6) & "(" & UCase(mcharges) & ")"

                    End If

                ElseIf process = "WAREHOUSE" Then
                    a(6) = GET_equip_desc_AND_proj_desc(sqldr.Item("cv_charge_to_id").ToString, 4)
                ElseIf process = "PROJECT" Then
                    a(6) = GET_equip_desc_AND_proj_desc(sqldr.Item("cv_charge_to_id").ToString, 2)
                ElseIf process = "EQUIPMENT" Then
                    a(6) = GET_equip_desc_AND_proj_desc(sqldr.Item("cv_charge_to_id").ToString, 1)
                End If
                a(7) = sqldr.Item("cv_qty").ToString
                a(8) = FormatNumber(sqldr.Item("cv_amount").ToString)
                a(9) = FormatNumber(CDbl(sqldr.Item("cv_amount").ToString) * CDbl(sqldr.Item("cv_qty").ToString), 2, , TriState.True)
                a(10) = sqldr.Item("cv_received_by").ToString
                a(11) = sqldr.Item("rs_id").ToString

                If cmbSearch.Text = "Search by RS No." Then
                    If search_by(a(2), txtSearch.Text) = True Then
                    Else
                        GoTo proceedhere
                    End If

                ElseIf cmbSearch.Text = "Search by CV No." Then
                    If search_by(a(3), txtSearch.Text) = True Then
                    Else
                        GoTo proceedhere
                    End If

                ElseIf cmbSearch.Text = "Search by Charge To" Then
                    If search_by(a(6), txtSearch.Text) = True Then
                    Else
                        GoTo proceedhere
                    End If

                ElseIf cmbSearch.Text = "Search by Item Description" Then
                    If search_by(a(4), txtSearch.Text) = True Then
                    Else
                        GoTo proceedhere
                    End If

                ElseIf cmbSearch.Text = "Search by CV Date" Then
                    If search_by(Date.Parse(a(1)), Date.Parse(dtp_cv_date.Text)) = True Then
                    Else
                        GoTo proceedhere
                    End If

                ElseIf cmbSearch.Text = "Filter by Month/Year" Then
                    If search_by(Date.Parse(a(1)), Date.Parse(Dtp_cv_datefrom.Text)) = True Or search_by(Date.Parse(a(1)), Date.Parse(Dtp_cv_dateto.Text)) Then
                    Else
                        GoTo proceedhere
                    End If

                End If

                Dim lvl As New ListViewItem(a)
                lvlvoucherlist.Items.Add(lvl)

proceedhere:

            End While
            sqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try
    End Sub

    Public Sub get_process(ByVal rs_id As Integer)
        Dim SQ As New SQLcon
        Dim DR As SqlDataReader
        Try
            SQ.connection.Open()
            publicquery = "SELECT * FROM dbrequisition_slip WHERE rs_id = '" & rs_id & "' AND type_of_purchasing = 'CASH'"
            cmd = New SqlCommand(publicquery, SQ.connection)
            DR = cmd.ExecuteReader
            While DR.Read
                process = DR.Item("process").ToString
            End While
            DR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub


    Private Sub FCashVoucherList_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        lvlvoucherlist.Height = Me.Height - 110
        lvlvoucherlist.Width = Me.Width - 30
        btnExit.Location = New Point(lvlvoucherlist.Width + 1, 10)

        gboxSearch.Location = New Point(lvlvoucherlist.Location.X, lvlvoucherlist.Bounds.Bottom)
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click

        'FCashVoucher.lbl_cv_info_id.Text = lvlvoucherlist.SelectedItems(0).Text
        'FCashVoucher.lbl_rs_id.Text = lvlvoucherlist.SelectedItems(0).SubItems(11).Text
        'FCashVoucher.lbox_cash_voucher.Visible = False
        'FCashVoucher.ShowDialog()


        'po_edit = 1

        'GET_REQUISITION_SLIP_DATA1(lvlvoucherlist.SelectedItems(0).SubItems(12).Text)

        'FPOFORM.lblInOut.Text = lvlvoucherlist.SelectedItems(0).SubItems(14).Text

        'With FPOFORM

        '    .typeofreq = lvlvoucherlist.SelectedItems(0).SubItems(15).Text
        '    .Label10.Text = "Prepared by:"
        '    .Label9.Text = "Checked by:"
        '    .Label12.Text = "Approved by:"
        '    .Label15.Text = "CASH"

        '    .txtInstructions.ReadOnly = True
        '    .txtPrepared_by.ReadOnly = True
        '    .txtChecked_by.ReadOnly = True
        '    .txtApproved_by.ReadOnly = True

        '    form_active("FPOFORM")
        '    .btnSave.Text = "Update"
        '    .load_po_items("UPDATE CASH")
        '    .show_supplier_list()
        '    .Show()

        'End With

        edit_cash_voucher(CInt(lvlvoucherlist.SelectedItems(0).Text))
        form_active("FPOFORM")
        FPOFORM.btnSave.Text = "Update"
        FPOFORM.Show()
    End Sub
    Public Sub edit_cash_voucher(cv_id As Integer)

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_cashvoucher_query", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 18)
            newCMD.Parameters.AddWithValue("@po_det_id", cv_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim a(20) As String

                With FPOFORM

                    a(0) = True
                    a(1) = newDR.Item("Supplier_Name").ToString
                    a(2) = newDR.Item("wh_id").ToString
                    a(3) = newDR.Item("whItem").ToString
                    a(4) = newDR.Item("whItemDesc").ToString
                    a(5) = newDR.Item("po_no").ToString
                    a(6) = newDR.Item("terms").ToString
                    a(7) = newDR.Item("qty").ToString
                    a(8) = newDR.Item("unit").ToString
                    a(9) = FormatNumber(CDbl(newDR.Item("unit_price").ToString),,, TriState.True)
                    a(10) = FormatNumber(CDbl(newDR.Item("qty").ToString) * CDbl(newDR.Item("unit_price").ToString),,, TriState.True)
                    a(11) = newDR.Item("po_det_id").ToString
                    a(12) = newDR.Item("rs_id").ToString
                    a(13) = newDR.Item("lof_id").ToString
                    a(14) = newDR.Item("IN_OUT").ToString
                    a(15) = newDR.Item("type_of_purchasing").ToString
                    a(16) = newDR.Item("CHARGES").ToString

                    .dgvPOList.Rows.Add(a)

                    .set_po_id = newDR.Item("po_id").ToString
                    .DTPTrans.Text = Date.Parse(newDR.Item("po_date").ToString)
                    .txtRsNo.Text = newDR.Item("rs_no").ToString
                    .txtInstructions.Text = newDR.Item("instructor").ToString
                    .DTPdateneeded.Text = Date.Parse(newDR.Item("date_needed").ToString)
                    .txtPrepared_by.Text = newDR.Item("prepared_by").ToString
                    .txtChecked_by.Text = newDR.Item("checked_by").ToString
                    .txtApproved_by.Text = newDR.Item("approved_by").ToString
                    .cmbdr_option.Text = "WITHOUT DR"
                    .txtRemarks.Text = newDR.Item("remarks").ToString
                    .lblTypeOfReq.Text = newDR.Item("type_of_purchasing").ToString
                    .typeofreq = newDR.Item("type_of_purchasing").ToString

                    .lbox_List.Visible = False

                    .txtInstructions.Enabled = False
                    .DTPdateneeded.Enabled = False
                    .txtPrepared_by.Enabled = False
                    .txtChecked_by.Enabled = False
                    .txtApproved_by.Enabled = False
                    .cmbdr_option.Enabled = False
                    .txtRemarks.Enabled = False


                End With

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Public Sub GET_REQUISITION_SLIP_DATA1(ByVal rs_id As String)
        Dim SQ As New SQLcon
        Dim DR As SqlDataReader

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

    Public Sub delete_all_cvList()
        Try
            sqlcon.connection.Open()
            Dim cmd As SqlCommand
            publicquery = "DELETE FROM dbCashVoucher_info WHERE cv_info_id = " & lvlvoucherlist.SelectedItems(0).SubItems(0).Text & ""
            cmd = New SqlCommand(publicquery, sqlcon.connection)
            cmd.ExecuteNonQuery()
            sqlcon.connection.Close()

            sqlcon.connection.Open()
            publicquery = "DELETE FROM dbCashVoucher_items WHERE cv_info_id = " & lvlvoucherlist.SelectedItems(0).SubItems(0).Text & "" ' AND rs_id = " & lvlvoucherlist.SelectedItems(0).SubItems(11).Text & ""
            cmd = New SqlCommand(publicquery, sqlcon.connection)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
            lvlvoucherlist.SelectedItems(0).Remove()
        End Try
    End Sub

    Public Sub delete_cvList()
        Try
            sqlcon.connection.Open()
            publicquery = "DELETE FROM dbCashVoucher_items WHERE cv_info_id = " & lvlvoucherlist.SelectedItems(0).SubItems(0).Text & " AND rs_id = " & lvlvoucherlist.SelectedItems(0).SubItems(11).Text & ""
            cmd = New SqlCommand(publicquery, sqlcon.connection)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
            load_cv_List()
        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        'Dim msg = MessageBox.Show("Are you sure you want to delete the data ?.", "SUPPLY INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        'If msg = Windows.Forms.DialogResult.Yes Then
        '    delete_all_cvList()
        'Else
        '    'delete_cvList()
        'End If

        If MessageBox.Show("Are you sure you want to delete selected items?", "PO INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            For Each itm As ListViewItem In lvlvoucherlist.Items
                If itm.Selected = True Then
                    Dim query As String = "DELETE FROM dbPO WHERE po_id = " & CInt(itm.SubItems(0).Text)
                    UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

                    query = Nothing

                    query = "DELETE FROM dbPO_details WHERE po_id = " & CInt(itm.SubItems(0).Text)
                    UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

                    itm.Remove()

                End If
            Next
        End If


    End Sub

    Private Sub cms_CashVoucherList_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cms_CashVoucherList.Opening
        If lvlvoucherlist.SelectedItems.Count > 0 Then
            cms_CashVoucherList.Enabled = True
        Else
            cms_CashVoucherList.Enabled = False
        End If
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown

        If e.KeyCode = Keys.Enter Then
            load_cv_List()
        End If

    End Sub

   

    Private Sub dtp_cv_date_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtp_cv_date.KeyDown
        load_cv_List()
    End Sub

    Private Sub cmbSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSearch.SelectedIndexChanged
        If cmbSearch.Text = "Search by RS No." Or cmbSearch.Text = "Search by CV No." Or _
               cmbSearch.Text = "Search by Charge To" Or cmbSearch.Text = "Search by Item Description" Then
            txtSearch.Enabled = True
            btnSearch.Enabled = True
            dtp_cv_date.Visible = False
            panel_cv_date_to_from.Visible = False
        ElseIf cmbSearch.Text = "Filter by Month/Year" Then
            panel_cv_date_to_from.Visible = True
            txtSearch.Enabled = False
            btnSearch.Enabled = False
        End If

        Select Case cmbSearch.Text
            Case "Search by CV Date"
                btnSearch.Enabled = True
                dtp_cv_date.Visible = True
                dtp_cv_date.Location = New Point(txtSearch.Width + 107, 901)
                dtp_cv_date.Width = txtSearch.Width
                panel_cv_date_to_from.Visible = False
                txtSearch.Visible = False
            Case Else
                txtSearch.Visible = True
                dtp_cv_date.Visible = False
                txtSearch.Focus()
        End Select
    End Sub

    Private Sub btn_view_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_view.Click
        'CV_search()
        'load_cv_List()
        search_by(48)
    End Sub

    Private Sub btn_paneLExt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_paneLExt.Click
        For Each ctr As Control In Me.Controls

            If ctr.Name = "panel_cv_date_to_from" Then
                ctr.Visible = False
                btnSearch.Enabled = True
            Else
                ctr.Enabled = True
            End If

        Next
    End Sub

    Private Sub panel_cv_date_to_from_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles panel_cv_date_to_from.Paint

    End Sub

#Region "Panel_GUI"
    Private Sub panel_cv_date_to_from_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panel_cv_date_to_from.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - panel_cv_date_to_from.Left
        mousey = Windows.Forms.Cursor.Position.Y - panel_cv_date_to_from.Top
    End Sub

    Private Sub panel_cv_date_to_from_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panel_cv_date_to_from.MouseMove
        If drag Then
            panel_cv_date_to_from.Left = Windows.Forms.Cursor.Position.X - mousex
            panel_cv_date_to_from.Top = Windows.Forms.Cursor.Position.Y - mousey
        End If
    End Sub

    Private Sub panel_cv_date_to_from_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panel_cv_date_to_from.MouseUp
        drag = False
    End Sub

    Private Sub btn_paneLExt_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_paneLExt.Click
        panel_cv_date_to_from.Visible = False
    End Sub

    Private Sub btn_paneLExt_MouseDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn_paneLExt.MouseDown
        btn_paneLExt.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btn_paneLExt_MouseEnter1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_paneLExt.MouseEnter
        btn_paneLExt.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btn_paneLExt_MouseLeave1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_paneLExt.MouseLeave
        btn_paneLExt.BackgroundImage = My.Resources.close_button
    End Sub
#End Region

    Private Function search_by(ByVal a As String, ByVal p2 As String) As Boolean
        Throw New NotImplementedException
    End Function

End Class