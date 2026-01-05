Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FPOFORM
    Public SQ As New SQLcon
    Public CMD As SqlCommand
    Public DR As SqlDataReader
    Dim n As Integer
    Dim rowind As Integer
    Public total_amount As Double
    Dim name1 As String
    Public term_day As String

    Dim pub_textbox As TextBox
    Public pub_po_id As Integer
    Public old_price_value As Double '
    Public old_qty As Integer
    Public set_po_id As Integer
    Public typeofreq As String


    Public driver_id As Integer

    ''sa po ne na part
    Public address As String
    Public requestor_m As String
    Dim want_print As Boolean
    Dim print_count As Boolean
    Dim printing As Boolean
    Public suplier_address = ""
    Public sup_po_address = ""
    Public unique_rs = ""
    Public unique_charge_all = ""
    Public po_recomendataion1 As String
    Public po_final_recomendation As String
    Public all_podet_id_for_print As String
    Public all_podet_id_printed As String
    Public choices_update_print As String



    Public public_po As String
    Public po_det_id_array As String
    Public rs_id_array As String
    Public old_ws_no As String
    Public charge_tos As String
    Public terms As String
    Public supplier_po As String
    Public isWithdrawal As Boolean
    Private customMsg As New customMessageBox

    Private vatTemp As Double = 2

    Private Sub FPOFORM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            btnSave.PerformClick()
        End If


        If e.KeyCode = Keys.F2 Then
            Try
                For Each ctr As Control In Me.Controls
                    If ctr.Name = "Panel2" Then
                        ctr.Visible = True
                        txtsplitqty.Focus()

                    Else
                        ctr.Enabled = False

                    End If
                Next

                txtsplitqty.SelectAll()
                txtsplitqty.Focus()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub FPOFORM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Label15.Parent = pboxHeader
        'ListJobOrderNo.Location = New Point(1000, 1000)
        'btnExit.Parent = pboxHeader
        'btnExit.BringToFront()

        Dim a(10) As String

        'txtApproved_by.Clear()
        'txtChecked_by.Clear()
        'txtInstructions.Clear()
        'txtPrepared_by.Clear()

        For Each ctr As Control In Me.Controls

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

        Button3.Visible = False

    End Sub
    Public Sub load_po_items(ByVal control As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim inout As String
        Dim c As Integer = 0

        If control = "SAVE" Then
            inout = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(9).Text
        ElseIf control = "UPDATE" Then
            inout = FPurchasedOrderList.lvlpurchasedOrderList.SelectedItems(0).SubItems(23).Text
        ElseIf control = "UPDATE CASH" Then
            inout = FCashVoucherList.lvlvoucherlist.SelectedItems(0).SubItems(14).Text
        ElseIf control = "UPDATE WS" Then
            inout = "OUT"
        End If

        dgvPOList.Rows.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_po_query_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            If inout = "IN" And control = "SAVE" Or inout = "OTHERS" And control = "SAVE" Then
                newCMD.Parameters.AddWithValue("@n", 11)
                newCMD.Parameters.AddWithValue("@rs_no", txtRsNo.Text)
                newCMD.Parameters.AddWithValue("@control", control)

            ElseIf inout = "FACILITIES" And control = "SAVE" Or inout = "TOOLS" And control = "SAVE" Or inout = "ADD-ON" And control = "SAVE" Then
                newCMD.Parameters.AddWithValue("@n", 2)
                newCMD.Parameters.AddWithValue("@rs_no", txtRsNo.Text)
                newCMD.Parameters.AddWithValue("@control", control)

                'ElseIf inout = "OTHERS" And control = "SAVE" Then
                '    newCMD.Parameters.AddWithValue("@n", 3)
                '    newCMD.Parameters.AddWithValue("@rs_no", txtRsNo.Text)
                '    newCMD.Parameters.AddWithValue("@control", control)

            ElseIf inout = "IN" And control = "UPDATE" Or inout = "OTHERS" And control = "UPDATE" Or inout = "BORROWER" And control = "UPDATE" Then
                Dim rs_id As Integer = FPurchasedOrderList.lvlpurchasedOrderList.SelectedItems(0).SubItems(20).Text

                newCMD.Parameters.AddWithValue("@n", 4)
                newCMD.Parameters.AddWithValue("@rs_id", rs_id)
                newCMD.Parameters.AddWithValue("@control", control)

            ElseIf inout = "IN" And control = "UPDATE CASH" Or inout = "OTHERS" And control = "UPDATE CASH" Or inout = "BORROWER" And control = "UPDATE CASH" Then
                Dim rs_id As Integer = FCashVoucherList.lvlvoucherlist.SelectedItems(0).SubItems(12).Text

                newCMD.Parameters.AddWithValue("@n", 7)
                newCMD.Parameters.AddWithValue("@rs_id", rs_id)
                newCMD.Parameters.AddWithValue("@control", control)

            ElseIf inout = "OUT" And control = "UPDATE WS" Then
                Dim rs_id As Integer = FWithdrawalList.lvlwithdrawalList.SelectedItems(0).SubItems(16).Text
                Dim ws_id As Integer = CInt(FWithdrawalList.lvlwithdrawalList.SelectedItems(0).Text)

                newCMD.Parameters.AddWithValue("@n", 44)
                newCMD.Parameters.AddWithValue("@rs_id", rs_id)
                newCMD.Parameters.AddWithValue("@control", control)
                newCMD.Parameters.AddWithValue("@ws_id", ws_id)

            ElseIf inout = "FACILITIES" And control = "UPDATE" Or inout = "TOOLS" And control = "UPDATE" Or inout = "ADD-ON" And control = "UPDATE" Then
                Dim rs_id As Integer = FPurchasedOrderList.lvlpurchasedOrderList.SelectedItems(0).SubItems(20).Text

                newCMD.Parameters.AddWithValue("@n", 5)
                newCMD.Parameters.AddWithValue("@rs_id", rs_id)
                newCMD.Parameters.AddWithValue("@control", control)

                'ElseIf inout = "OTHERS" And control = "UPDATE" Then
                '    Dim rs_id As Integer = FPurchasedOrderList.lvlpurchasedOrderList.SelectedItems(0).SubItems(20).Text

                '    newCMD.Parameters.AddWithValue("@n", 6)
                '    newCMD.Parameters.AddWithValue("@rs_id", rs_id)
                '    newCMD.Parameters.AddWithValue("@control", control)

            ElseIf inout = "QUARRY-IN" And control = "SAVE" Then
                newCMD.Parameters.AddWithValue("@n", 3)
                newCMD.Parameters.AddWithValue("@rs_no", txtRsNo.Text)
                newCMD.Parameters.AddWithValue("@control", control)

            ElseIf inout = "QUARRY-IN" And control = "UPDATE" Then
                Dim rs_id As Integer = FPurchasedOrderList.lvlpurchasedOrderList.SelectedItems(0).SubItems(20).Text

                newCMD.Parameters.AddWithValue("@n", 6)
                newCMD.Parameters.AddWithValue("@rs_id", rs_id)
                newCMD.Parameters.AddWithValue("@control", control)

            End If

            Dim a(20) As String

            newDR = newCMD.ExecuteReader
            While newDR.Read
                Dim rs_id As Integer = CInt(newDR.Item("rs_id").ToString)

                Dim exist As Integer = check_if_exist("dbPO_details", "rs_id", rs_id, 1)

                If exist > 0 Then
                    If control = "UPDATE" Or control = "UPDATE WS" Then
                    Else
                        GoTo proceed
                    End If

                End If

                Select Case inout
                    Case "IN"
                        a(2) = newDR.Item("wh_id").ToString
                        a(3) = FRequistionForm.GET_ITEM_DESC(CInt(a(2)))

                    Case "FACILITIES"
                        a(2) = newDR.Item("fac_id").ToString
                        a(3) = newDR.Item("facility_name").ToString

                    Case "TOOLS"
                        a(2) = newDR.Item("fac_id").ToString
                        a(3) = newDR.Item("facility_name").ToString

                    Case "ADD-ON"
                        a(2) = newDR.Item("fac_id").ToString
                        a(3) = newDR.Item("facility_name").ToString

                    Case "OTHERS"
                        'a(2) = newDR.Item("wh_id").ToString
                        'a(3) = newDR.Item("item_desc").ToString
                        a(2) = newDR.Item("wh_id").ToString
                        a(3) = newDR.Item("ITEM_NAME").ToString ' FRequistionForm.GET_ITEM_DESC(CInt(a(2)))

                    Case "BORROWER"
                        a(2) = newDR.Item("wh_id").ToString
                        a(3) = FRequistionForm.GET_ITEM_DESC(CInt(a(2)))

                    Case "QUARRY-IN"
                        a(2) = newDR.Item("wh_id").ToString
                        a(3) = newDR.Item("item_desc").ToString

                    Case "OUT"
                        a(2) = newDR.Item("wh_id").ToString
                        a(3) = newDR.Item("ITEM_NAME").ToString
                End Select

                If exist = 0 Then

                    If control = "SAVE" Then
                        a(4) = ""
                        a(5) = 0
                        a(6) = "60 days"
                        a(7) = CDec(newDR.Item("qty").ToString)
                        a(8) = newDR.Item("unit").ToString
                        a(9) = "0.00"
                        a(10) = "0.00"
                        a(11) = 0
                        a(12) = newDR.Item("rs_id").ToString
                        a(13) = 0
                        a(14) = newDR.Item("IN_OUT").ToString


                        dgvPOList.Rows.Add(a)
                    End If

                Else
                    If control = "UPDATE" Then

                        a(1) = newDR.Item("Supplier_Name").ToString
                        a(4) = newDR.Item("item_desc_B").ToString
                        a(5) = newDR.Item("po_no").ToString
                        a(6) = "60 days"
                        a(7) = CDec(newDR.Item("qty").ToString)
                        a(8) = newDR.Item("unit").ToString
                        a(9) = newDR.Item("unit_price").ToString
                        a(10) = FormatNumber(CDec(newDR.Item("unit_price").ToString) * CDec(newDR.Item("qty").ToString), 2, , TriState.True)
                        a(11) = newDR.Item("po_det_id").ToString
                        a(12) = newDR.Item("rs_id").ToString
                        a(13) = newDR.Item("lof_id").ToString
                        a(14) = newDR.Item("IN_OUT").ToString

                        If newDR.Item("charge_type").ToString = "ADFIL" Then
                            a(16) = multiplecharges(CInt(newDR.Item("rs_id").ToString), 1)
                        ElseIf newDR.Item("process").ToString = "ADFIL" Then
                            a(16) = multiplecharges(CInt(newDR.Item("rs_id").ToString), 1)
                        ElseIf newDR.Item("process").ToString = "OUTSOURCE" Then
                            a(16) = multiplecharges(CInt(newDR.Item("rs_id").ToString), 2)
                        End If

                        txtChargeTo.Text = ""
                        DTPTrans.Text = Date.Parse(newDR.Item("po_date").ToString)
                        txtInstructions.Text = newDR.Item("instructor").ToString
                        DTPdateneeded.Text = newDR.Item("date_needed").ToString
                        txtApproved_by.Text = newDR.Item("approved_by").ToString
                        txtChecked_by.Text = newDR.Item("checked_by").ToString
                        txtPrepared_by.Text = newDR.Item("prepared_by").ToString
                        cmbdr_option.Text = newDR.Item("dr_option").ToString
                        set_po_id = newDR.Item("po_id").ToString

                        dgvPOList.Rows.Add(a)

                    ElseIf control = "UPDATE CASH" Then
                        a(1) = newDR.Item("Supplier_Name").ToString
                        a(4) = newDR.Item("item_desc_B").ToString
                        a(5) = newDR.Item("po_no").ToString
                        a(6) = "60 days"
                        a(7) = CDec(newDR.Item("qty").ToString)
                        a(8) = newDR.Item("unit").ToString
                        a(9) = newDR.Item("unit_price").ToString
                        a(10) = FormatNumber(CDbl(newDR.Item("unit_price").ToString) * CDec(newDR.Item("qty").ToString), 2, , TriState.True)
                        a(11) = newDR.Item("po_det_id").ToString
                        a(12) = newDR.Item("rs_id").ToString
                        a(13) = newDR.Item("lof_id").ToString
                        a(14) = newDR.Item("IN_OUT").ToString
                        a(15) = newDR.Item("type_of_purchasing").ToString

                        If newDR.Item("charge_type").ToString = "ADFIL" Then
                            a(16) = multiplecharges(CInt(newDR.Item("rs_id").ToString), 1)
                        ElseIf newDR.Item("process").ToString = "ADFIL" Then
                            a(16) = multiplecharges(CInt(newDR.Item("rs_id").ToString), 1)
                        ElseIf newDR.Item("process").ToString = "OUTSOURCE" Then
                            a(16) = multiplecharges(CInt(newDR.Item("rs_id").ToString), 2)
                        End If

                        txtChargeTo.Text = ""
                        DTPTrans.Text = Date.Parse(newDR.Item("po_date").ToString)
                        txtInstructions.Text = newDR.Item("instructor").ToString
                        DTPdateneeded.Text = newDR.Item("date_needed").ToString
                        txtApproved_by.Text = newDR.Item("approved_by").ToString
                        txtChecked_by.Text = newDR.Item("checked_by").ToString
                        txtPrepared_by.Text = newDR.Item("prepared_by").ToString
                        Label15.Text = "CASH VOUCHER"
                        set_po_id = newDR.Item("po_id").ToString
                        cmbdr_option.Text = newDR.Item("dr_option").ToString
                        dgvPOList.Rows.Add(a)

                    ElseIf control = "UPDATE WS" Then

                        a(1) = newDR.Item("wh_area").ToString
                        a(4) = newDR.Item("ITEM_DESC").ToString 'newDR.Item("item_desc_B").ToString
                        a(5) = newDR.Item("po_no").ToString
                        a(6) = "60 days"
                        a(7) = CDec(newDR.Item("qty").ToString)
                        a(8) = newDR.Item("unit").ToString
                        a(9) = newDR.Item("unit_price").ToString
                        a(10) = FormatNumber(CDec(newDR.Item("unit_price").ToString) * CDec(newDR.Item("qty").ToString), 2, , TriState.True)
                        a(11) = newDR.Item("po_det_id").ToString
                        a(12) = newDR.Item("rs_id").ToString
                        a(13) = newDR.Item("lof_id").ToString
                        a(14) = newDR.Item("IN_OUT").ToString

                        If newDR.Item("charge_type").ToString = "ADFIL" Then
                            a(16) = multiplecharges(CInt(newDR.Item("rs_id").ToString), 1)
                        ElseIf newDR.Item("process").ToString = "ADFIL" Then
                            a(16) = multiplecharges(CInt(newDR.Item("rs_id").ToString), 1)
                        ElseIf newDR.Item("process").ToString = "OUTSOURCE" Then
                            a(16) = multiplecharges(CInt(newDR.Item("rs_id").ToString), 2)
                        End If

                        txtChargeTo.Text = ""
                        DTPTrans.Text = Date.Parse(newDR.Item("po_date").ToString)
                        txtInstructions.Text = newDR.Item("instructor").ToString
                        DTPdateneeded.Text = newDR.Item("date_needed").ToString
                        txtApproved_by.Text = newDR.Item("approved_by").ToString
                        txtChecked_by.Text = newDR.Item("checked_by").ToString
                        txtPrepared_by.Text = newDR.Item("prepared_by").ToString
                        'set_po_id = newDR.Item("po_id").ToString
                        Dim po_id As Integer = CInt(FWithdrawalList.lvlwithdrawalList.SelectedItems(0).Text)
                        set_po_id = po_id
                        cmbdr_option.Text = newDR.Item("dr_option").ToString
                        dgvPOList.Rows.Add(a)
                    End If
                End If

                c += 1

                For Each row As DataGridViewRow In dgvPOList.Rows
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

proceed:


            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
            Button3.PerformClick()
            lbox_List.Visible = False
        End Try
    End Sub

    Private Sub DataGridView1_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvPOList.CellBeginEdit

        rowind = Format(get_datagrid_rowindex)
        old_price_value = dgvPOList.Rows(Format(rowind)).Cells(9).Value
        old_qty = dgvPOList.Rows(Format(rowind)).Cells(7).Value
        old_ws_no = dgvPOList.Rows(rowind).Cells(NameOf(Column4)).Value

    End Sub


    Public Function get_datagrid_rowindex() As Integer

        For i As Integer = 0 To Me.dgvPOList.SelectedCells.Count - 1
            get_datagrid_rowindex = Me.dgvPOList.SelectedCells.Item(i).RowIndex
        Next
    End Function

    Private Sub dgvDeparture_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles dgvPOList.EditingControlShowing

        'Get the Editing Control. I personally prefer Trycast for this as it will not throw an error
        Dim editingComboBox As ComboBox = TryCast(e.Control, ComboBox)
        If Not editingComboBox Is Nothing Then
            'Add the handle to your IndexChanged Event
            AddHandler editingComboBox.SelectedValueChanged, AddressOf editingComboBox_SelectedIndexChanged
        End If

        'Prevent this event from firing twice, as is normally the case.
        RemoveHandler dgvPOList.EditingControlShowing, AddressOf dgvDeparture_EditingControlShowing

    End Sub
    Private Sub editingComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        dgvPOList.Refresh()

        'Get the editing control
        Dim editingComboBox As ComboBox = TryCast(sender, ComboBox)
        If editingComboBox Is Nothing Then Exit Sub

        'Show your Message Boxes
        'MessageBox.Show(editingComboBox.SelectedIndex.ToString()) ' Display index

        dgvPOList.Rows(rowind).Cells(6).Value = get_terms(editingComboBox.Text)

        'Remove the handle to this event. It will be readded each time a new combobox selection causes the EditingControlShowing Event to fire
        RemoveHandler editingComboBox.SelectedIndexChanged, AddressOf editingComboBox_SelectedIndexChanged
        'Re-enable the EditingControlShowing event so the above can take place.
        AddHandler dgvPOList.EditingControlShowing, AddressOf dgvDeparture_EditingControlShowing

    End Sub


    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()

    End Sub
    Private Sub update_ws_info_id(ws_info_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_withdrawal_new1", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 4)
            newCMD.Parameters.AddWithValue("@ws_info_id", ws_info_id)
            newCMD.Parameters.AddWithValue("@ws_id", FWithdrawalList.lvlwithdrawalList.SelectedItems(0).Text)
            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim inout As String

#Region "UPDATE WS"
        'gkan ni sa withdralist edit info ang ge click
        If button_click_name = "EditInfoToolStripMenuItem" Then

            'UPDATE PO/WS INFO
            If btnSave.Text = "Update" Then
                Dim newSQ As New SQLcon
                Dim newCMD As SqlCommand
                Dim ws_info_id As Integer

                With FWithdrawalList
                    Try
                        newSQ.connection.Open()
                        newCMD = New SqlCommand("proc_withdrawal_new1", newSQ.connection)
                        newCMD.Parameters.Clear()
                        newCMD.CommandType = CommandType.StoredProcedure

                        newCMD.Parameters.AddWithValue("@n", 10) '3
                        newCMD.Parameters.AddWithValue("@ws_id", .lvlwithdrawalList.SelectedItems(0).Text)
                        newCMD.Parameters.AddWithValue("@po_ws_date", Date.Parse(DTPTrans.Text))
                        newCMD.Parameters.AddWithValue("@rs_no", txtRsNo.Text)
                        'newCMD.Parameters.AddWithValue("@instructor", txtInstructions.Text)
                        'newCMD.Parameters.AddWithValue("@date_needed", Date.Parse(DTPdateneeded.Text))
                        newCMD.Parameters.AddWithValue("@prepared_by", txtPrepared_by.Text)
                        newCMD.Parameters.AddWithValue("@checked_by", txtChecked_by.Text)
                        newCMD.Parameters.AddWithValue("@aprroved_by", txtApproved_by.Text)
                        newCMD.Parameters.AddWithValue("@remarks", txtRemarks.Text)
                        newCMD.Parameters.AddWithValue("@droption", cmbdr_option.Text)

                        ws_info_id = newCMD.ExecuteScalar()

                        If ws_info_id > 0 Then
                            'it means insert bag.o ang ws info so kwaon ang ws_info_id nya e update sa ws_details 
                            update_ws_info_id(ws_info_id)
                        End If
                    Catch ex As Exception
                        MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        MessageBox.Show("WS INFO successfully updated...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        newSQ.connection.Close()
                    End Try
                End With

            End If

            button_click_name = ""
            FWithdrawalList.btnSearch.PerformClick()
            Me.Dispose()
            Exit Sub

            'gkan ni sa withdralist edit details ang ge click
        ElseIf button_click_name = "EditDetailsToolStripMenuItem" Then

            'UPDATE WS DETAILS
            If btnSave.Text = "Update" Then

                If customMsg.messageYesNo("are you sure you want to update this data?", "SUPPLY INFO:", MessageBoxIcon.Question) Then

#Region "FILTER IF WS EXIST IN DR"
                    Dim wsNo As String = dgvPOList.SelectedRows(0).Cells(NameOf(Column4)).Value
                    Dim rsId As Integer = dgvPOList.SelectedRows(0).Cells(NameOf(col_rs_id)).Value

                    Dim wsExistInDr As Boolean = checkWsExistInDr(wsNo, rsId)

                    If wsExistInDr Then
                        'update all dr that have found same ws-no
                        Dim msgbox As String = "some data will be affected from dr.." & vbCrLf & "do you still want to proceed and update?"

                        If customMsg.messageYesNo(msgbox, "SUPPLY INFO:", MessageBoxIcon.Question) Then
                            updateWsIfFoundInDr(wsNo, rsId)
                        Else
                            Exit Sub
                        End If

                    End If
#End Region

                    Dim newSQ As New SQLcon
                    Dim newCMD As SqlCommand

                    With FWithdrawalList

                        For Each row As DataGridViewRow In dgvPOList.Rows
                            If row.Selected = True Then
                                Try
                                    newSQ.connection.Open()
                                    newCMD = New SqlCommand("proc_withdrawal_new1", newSQ.connection)
                                    newCMD.Parameters.Clear()
                                    newCMD.CommandType = CommandType.StoredProcedure

                                    Dim unit_price As Decimal = row.Cells("Column8").Value

                                    newCMD.Parameters.AddWithValue("@n", 7)
                                    newCMD.Parameters.AddWithValue("@ws_id", row.Cells("Column10").Value)
                                    newCMD.Parameters.AddWithValue("@ws_no", row.Cells("Column4").Value)
                                    newCMD.Parameters.AddWithValue("@unit", row.Cells("Column7").Value)
                                    newCMD.Parameters.AddWithValue("@unit_price", unit_price)

                                    newCMD.ExecuteNonQuery()

                                Catch ex As Exception
                                    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Finally
                                    newSQ.connection.Close()
                                End Try
                            End If
                        Next
                    End With
                End If


            End If

            MessageBox.Show("WS Details successfully updated...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)

            button_click_name = ""
            FWithdrawalList.btnSearch.PerformClick()
            Me.Dispose()
            Exit Sub
        End If
#End Region

#Region "FILTER FIELDS WS/PO"
        Dim count_item_desc_blank As Integer
        Dim count_supplier_blank As Integer

        For Each row As DataGridViewRow In dgvPOList.Rows
            If row.Cells(0).Value = True Then
                inout = row.Cells("col_inout").Value

                If row.Cells(4).Value = "" Then
                    count_item_desc_blank += 1
                End If

                If row.Cells(1).Value = "" Then
                    count_supplier_blank += 1
                End If

            End If
        Next

        If count_item_desc_blank > 0 Then
            MessageBox.Show("Item description must not be blank..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        ElseIf count_supplier_blank > 0 Then
            If lbl_type_of_purchasing.Text = "DR" Then
            Else
                MessageBox.Show("Item supplier must not be blank..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

        End If

        Dim countqty_zero As Double

        For Each row As DataGridViewRow In dgvPOList.Rows
            If row.Cells("Column6").Value = 0 Then
                countqty_zero += 1
            End If
        Next

#End Region

#Region "SAVE PO"
        If btnSave.Text = "Save" Then

            If MessageBox.Show("Are you sure you want to save this data?", "Supply Info:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Else
                Exit Sub
            End If

            If cmbdr_option.Text = "" Then
                MessageBox.Show("Select dr options in order to proceed transaction.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim a(11) As String
            Dim if_rs_no_exist_in_poinfo As String = check_if_exist("dbPO", "rs_no", txtRsNo.Text, 0)

            If lbl_type_of_purchasing.Text = "DR" Then
                INSERT_PO(111)
                'ElseIf Label15.Text = "CASH" Then
            Else
                INSERT_PO(1)
            End If

            a(0) = pub_po_id

            Dim rs_id As Integer
            Dim d As Integer
            Dim status As String
            Dim supp_reciepent_id As Integer

            If FRequistionForm.withdrawal_stat1 = "withdrawn" Then
                'FRequistionForm.withdrawal_stat1 = ""
            Else
                Dim result = MessageBox.Show("Want To Print P.O?", "Supply System", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    want_print = True
                ElseIf result = DialogResult.No Then
                    want_print = False
                End If
            End If

            For Each oRow As DataGridViewRow In dgvPOList.Rows

                If oRow.Cells("column13").Value = True Then
                    status = "TRUE"
                Else
                    status = "FALSE"
                End If

                If oRow.Cells("col_inout").Value = "IN" Or oRow.Cells("col_inout").Value = "OTHERS" Then
                    supp_reciepent_id = get_id("dbSupplier", "Supplier_Name", dgvPOList.Rows(d).Cells(1).Value, 0)
                ElseIf oRow.Cells("col_inout").Value = "OUT" Then
                    supp_reciepent_id = get_id("dbwh_area", "wh_area", dgvPOList.Rows(d).Cells(1).Value, 0)
                End If

                If oRow.Cells("col_typeofreq").Value = "DR" Then
                    a(1) = 0 'get_id("dbQuarryInfo", "quarry_name", dgvPOList.Rows(d).Cells(1).Value, 0)
                Else
                    a(1) = supp_reciepent_id
                End If

                a(2) = dgvPOList.Rows(d).Cells(2).Value
                a(3) = dgvPOList.Rows(d).Cells(4).Value
                a(4) = dgvPOList.Rows(d).Cells(5).Value
                a(5) = dgvPOList.Rows(d).Cells(6).Value
                a(6) = dgvPOList.Rows(d).Cells(7).Value
                a(7) = dgvPOList.Rows(d).Cells(8).Value
                a(8) = dgvPOList.Rows(d).Cells(9).Value
                a(9) = dgvPOList.Rows(d).Cells(10).Value
                a(10) = dgvPOList.Rows(d).Cells(12).Value
                a(11) = status

                rs_id = dgvPOList.Rows(d).Cells("col_rs_id").Value


                If oRow.Cells("column13").Value = True Then
                    If FRequistionForm.for_print_po = True And lbl_type_of_purchasing.Text = "PURCHASE ORDER" Then

                        If want_print = True Then
                            printing = True
                            'get_po_details()
                            'PO_preview_report()
                            print_count = True
                            INSERT_PO_DETAILS_print_stat(a(0), a(1), a(2), a(3), a(4), a(5), a(6), a(7), a(8), a(9), a(10), a(11)) 'items print stat = PRINTED
                        ElseIf want_print = False Then
                            print_count = False
                            INSERT_PO_DETAILS_print_stat(a(0), a(1), a(2), a(3), a(4), a(5), a(6), a(7), a(8), a(9), a(10), a(11)) 'items print stat = FOR PRINT
                        End If
                    Else
                        INSERT_PO_DETAILS(a(0), a(1), a(2), a(3), a(4), a(5), a(6), a(7), a(8), a(9), a(10), a(11)) 'items 
                    End If
                End If
                d += 1
            Next

            If printing = True Then
                Dim rsFirstLetter As String = txtRsNo.Text.Substring(0, 1)

                FPurchasedOrderList.all_rs_no = ""
                FPurchasedOrderList.all_rs_no = txtRsNo.Text
                get_po_details()
                getChargesType()
                If rsFirstLetter = "J" Then
                    PO_preview_report_jqg()
                ElseIf rsFirstLetter = "B" Then
                    PO_preview_report_bbc()
                Else
                    PO_preview_report_adfil()
                End If




            Else
                'continue
            End If

            get_po_recommend()
            MessageBox.Show("SUCCESSFULLY SAVED...", "EUS INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)


            'Dim in_out As String = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(9).Text
            Dim in_out As String = dgvPOList.SelectedRows(0).Cells("col_inout").Value

            If in_out = "IN" Or in_out = "OTHERS" Then
                FRequistionForm.btnSearch.PerformClick()
                listfocus(FRequistionForm.lvlrequisitionlist, rs_id)
                Me.Dispose()
            End If

            If cmbdr_option.Text = "WITH DR" And in_out = "OUT" Or cmbdr_option.Text = "WITHOUT DR" And in_out = "OUT" Then

                '<====(A1) THIS CODE IS FOR AUTOMATICALLY WITHDRAW NA DILI NA MO ADTO SA WITHDRAWAL FORM
                If MessageBox.Show("Do you want to withdraw this data also?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    FDeliveryReceipt.dgv_dr_list.Rows.Clear()

                    button_click_name = "clickyesaftersavepoform"

                    FDeliveryReceipt.cmbOptions.Text = in_out

                    Dim options As String = ""
                    Select Case cmbdr_option.Text : Case "WITH DR" : options = "W/ DR" : Case "WITHOUT DR" : options = "W/O DR" : End Select
                    FDeliveryReceipt.cmbDrOptions.Text = options

                    '---retreive the multiple po_det_id in po_det_id array---
                    po_det_id_array = remove_last_character(po_det_id_array) 'remove the last comma
                    Dim po_det_id_each() As String = po_det_id_array.Split(",")

                    '---retreive the multiple rs_id in rs_id_array array---
                    rs_id_array = remove_last_character(rs_id_array) 'remove the last comma
                    Dim rs_id_each() As String = rs_id_array.Split(",")


                    '<=== (A1-1) this code is for insert data to dbwithdrawn_items
                    For i = 0 To po_det_id_each.Length - 1
                        'set ws_id = po_det_id(i)
                        Dim ws_id_ As Integer = po_det_id_each(i)
                        Dim rs_id_ As Integer = rs_id_each(i)

                        Dim query As String = "INSERT INTO dbwithdrawn_items(rs_id,ws_id) VALUES(" & rs_id_ & "," & ws_id_ & ")"
                        UPDATE_INSERT_DELETE_QUERY(query, 0, "INSERT")

                    Next

                    rs_id_each = Nothing
                    rs_id_array = Nothing
                    po_det_id_array = Nothing

                    FRequistionForm.btnSearch.PerformClick()
                    listfocus(FRequistionForm.lvlrequisitionlist, rs_id)

                    DTPTrans.Focus()

                    '<=== (A1-2) this code is for remove item after saved | kadto lng naay check ang  ma remove
                    For i As Integer = dgvPOList.Rows.Count() - 1 To 0 Step -1
                        Dim delete As Boolean
                        'first column - column13
                        delete = dgvPOList.Rows(i).Cells("column13").Value

                        ' if the checkbox cell is checked
                        If delete = True Then
                            Dim row As DataGridViewRow
                            row = dgvPOList.Rows(i)
                            dgvPOList.Rows.Remove(row)
                        End If
                    Next '(A1-2) =====>

                Else '(A1) ============>

                    'IF NO ANG GE CLICK GIKAN SA (A1) NO: Do you want to withdraw this data also?
                    '<====== (A2)
                    '<=== (A2-1) this code is for remove item after saved | kadto lng naay check ang  ma remove
                    For i As Integer = dgvPOList.Rows.Count() - 1 To 0 Step -1
                        Dim delete As Boolean
                        delete = dgvPOList.Rows(i).Cells("column13").Value

                        ' if the checkbox cell is checked
                        If delete = True Then
                            Dim row As DataGridViewRow
                            row = dgvPOList.Rows(i)
                            dgvPOList.Rows.Remove(row)
                        End If
                    Next '(A2-1) ====>
                End If '(A2) ======>
            End If
        End If

#End Region

        '<=== (B1) UPDATE APIL ANG DR KUNG NAA
        If btnSave.Text = "Update" Then

            '<=== (B1-1) checkon niya kung naa naba ni DR nga na input
            If MessageBox.Show("Are you sure you want to update this data?", "Supply Info:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then 'YES
                'og naa na DR na input!
                If count_affected_dr() > 0 Then
                    If MessageBox.Show("(" & count_affected_dr() & ") data will be affected from dr.." & vbCrLf & "do you still want to proceed and update?", "DR INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                        update_affected_dr()
                        'continue
                    Else
                        Exit Sub
                    End If
                Else
                    'continue
                End If

            Else 'NO
                Exit Sub
            End If '(B1-1) ==>

            '<=== (B1-2)
            'if PO INFO Has been deleted or blank, so need to update
            'deleted tungod ky pangita pa ang cause ngano ma delete but for the meantime kini lng sa ang buhaton
            With FPurchasedOrderList
                Dim get_po_det_id As Integer

                '<== (B1-2a) kung gkan xa sa FWithdrawalList nag edit
                If bol_withdrawal_edit = True Then
                    get_po_det_id = FWithdrawalList.lvlwithdrawalList.SelectedItems(0).Text '(B1-2a) ==>
                Else '<== (B1-2b) kung gkan xa sa FPurchasedOrderList nag edit
                    get_po_det_id = .lvlpurchasedOrderList.SelectedItems(0).Text '(B1-2b) ==>
                End If

                '<== (B1-2c) check sa database kung po_id nag exist
                If .check_po_id_exist(get_po_det_id) = "" Then
                    'kung wala nag exist | or blank | ""
                    '<== (B1-2c-a) insert PO INFO nalang dayon
                    UPDATE_INSERT_POINFO()
                    UPDATE_PO_DETAILS_USING_NEW_INSERT_PO(pub_po_id)

                    MessageBox.Show("PO INFO HAS BEEN ADDED AND SUCCESSFULLY UPDATED..", "EUS INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                    Exit Sub '(B1-2c-a) ==>
                    '(B1-2c) ==>
                Else
                    'nag exist ang po_det_id | not blanck | <> ""
                    '<== (B1-2c-b) update PO INFO
                    UPDATE_PO()
                    UPDATE_PO_DETAILS_USING_NEW_INSERT_PO(set_po_id)

                    MessageBox.Show("SUCCESSFULLY UPDATED..", "EUS INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                    Exit Sub '(B1-2c-b) ==>
                End If '(B1-2c) ==>

            End With '(B1-2) ==>

        ElseIf btnSave.Text = "Print P.O" Then
            Dim rsFirstLetter As String = txtRsNo.Text.Substring(0, 1)
            get_supply_addres()
            get_po_details()
            getChargesType()
            If rsFirstLetter = "J" Then
                PO_preview_report_jqg()
            ElseIf rsFirstLetter = "B" Then
                PO_preview_report_bbc()
            Else
                PO_preview_report_adfil()
            End If
        End If
    End Sub
    Private Function count_affected_dr() As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt1", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 1)
            newCMD.Parameters.AddWithValue("@ws_no", old_ws_no)

            newDR = newCMD.ExecuteReader

            Dim a(10) As String

            While newDR.Read
                count_affected_dr = newDR.Item("affected_dr_ws").ToString
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function

    Private Function update_affected_dr() As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt1", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 2)
            newCMD.Parameters.AddWithValue("@ws_no", old_ws_no)
            newCMD.Parameters.AddWithValue("@updated_ws_no", dgvPOList.Rows(0).Cells("Column4").Value)

            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function


#Region "GUI"

#End Region
#Region "BTNSAVE FUNCTIONS"
    Public Sub INSERT_FACILITIES_ITEM(ByVal po_det_id As Integer, ByVal lof_id As Integer, ByVal date_aquired As DateTime,
                                      ByVal custodian As Integer, ByVal received_to As Integer, ByVal condition As String,
                                      ByVal remarks As String, ByVal qty As Integer, ByVal type_of_custodian As String,
                                      ByVal type_of_received As String, ByVal no As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_facilities", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 11)
            newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)
            newCMD.Parameters.AddWithValue("@lof_id", lof_id)
            newCMD.Parameters.AddWithValue("@date_aquired", date_aquired)
            newCMD.Parameters.AddWithValue("@type_of_custodian", type_of_custodian)
            newCMD.Parameters.AddWithValue("@custodian", custodian)
            newCMD.Parameters.AddWithValue("@type_of_received", type_of_received)
            newCMD.Parameters.AddWithValue("@received_to", received_to)
            newCMD.Parameters.AddWithValue("@condition", condition)
            newCMD.Parameters.AddWithValue("@remarks", remarks)
            newCMD.Parameters.AddWithValue("@qty", qty)
            newCMD.Parameters.AddWithValue("@no", no)
            newCMD.Parameters.AddWithValue("@type_of_purchasing", "PURCHASE ORDER")

            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Sub

    Public Sub INSERT_PO_DETAILS(ByVal po_id As Integer, ByVal sup_id As Integer, ByVal wh_id As Integer, ByVal item_desc As String,
                                    ByVal po_no As String, ByVal terms As String, ByVal qty As Decimal,
                                    ByVal unit As String, ByVal unitprice As Double, ByVal amount As Double, ByVal rs_id As Integer, ByVal SELECTED As String)
        Try


            SQ.connection.Open()

            Dim lof_id As Integer = get_lof_id(wh_id, item_desc)

            CMD = New SqlCommand("proc_po_query", SQ.connection)
            CMD.Parameters.Clear()
            CMD.CommandType = CommandType.StoredProcedure

            CMD.Parameters.AddWithValue("@n", 2)
            CMD.Parameters.AddWithValue("@po_id", po_id)
            CMD.Parameters.AddWithValue("@supplier_id", sup_id)
            CMD.Parameters.AddWithValue("@wh_id", wh_id)
            CMD.Parameters.AddWithValue("@item_desc", item_desc)
            CMD.Parameters.AddWithValue("@po_no", po_no)
            CMD.Parameters.AddWithValue("@terms", terms)
            CMD.Parameters.AddWithValue("@qty", qty)
            CMD.Parameters.AddWithValue("@unit", unit)
            CMD.Parameters.AddWithValue("@unit_price", unitprice)
            CMD.Parameters.AddWithValue("@amount", amount)
            CMD.Parameters.AddWithValue("@selected", SELECTED)
            CMD.Parameters.AddWithValue("@rs_id", rs_id)
            CMD.Parameters.AddWithValue("@lof_id", lof_id)
            Dim po_det_id As Integer = CMD.ExecuteScalar()
            pub_po_det_id = po_det_id

            'for multiple withdrawn items
            po_det_id_array = po_det_id_array & po_det_id & ","
            rs_id_array = rs_id_array & rs_id & ","

            ''applicable for warehouse to warehouse
            'If cmbLinktoOtherWh.Text = "YES" Then
            '    insert_to_dbWarehouse_to_Warehouse_tbl(po_det_id, qty, lbl_link_Wh_id.Text)
            'End If


            If lblInOut.Text = "FACILITIES" Or lblInOut.Text = "TOOLS" Then

                If qty > 1 Then
                    For i = 0 To qty - 1
                        INSERT_FACILITIES_ITEM(po_det_id, lof_id, Date.Parse("1991-01-01"), 0, 0, "", "pending", 1, "", "", 0)
                    Next
                Else
                    INSERT_FACILITIES_ITEM(po_det_id, lof_id, Date.Parse("1991-01-01"), 0, 0, "", "pending", qty, "", "", 0)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

    End Sub

    Public Sub INSERT_PO_DETAILS_print_stat(ByVal po_id As Integer, ByVal sup_id As Integer, ByVal wh_id As Integer, ByVal item_desc As String,
                                    ByVal po_no As String, ByVal terms As String, ByVal qty As Decimal,
                                    ByVal unit As String, ByVal unitprice As Double, ByVal amount As Double, ByVal rs_id As Integer, ByVal SELECTED As String)
        Dim print_Stat As String = ""
        Dim print_date_log As DateTime
        If print_count = True Then
            print_Stat = "PRINTED"
            print_date_log = Format(Date.Parse(Now), "yyyy-MM-dd")
        ElseIf print_count = False Then
            print_Stat = "FOR PRINTING"
            print_date_log = "1900-01-01 00:00:00.000"
        End If
        Try


            SQ.connection.Open()

            Dim lof_id As Integer = get_lof_id(wh_id, item_desc)

            CMD = New SqlCommand("proc_po_query", SQ.connection)
            CMD.Parameters.Clear()
            CMD.CommandType = CommandType.StoredProcedure

            CMD.Parameters.AddWithValue("@n", 2)
            CMD.Parameters.AddWithValue("@po_id", po_id)
            CMD.Parameters.AddWithValue("@supplier_id", sup_id)
            CMD.Parameters.AddWithValue("@wh_id", wh_id)
            CMD.Parameters.AddWithValue("@item_desc", item_desc)
            CMD.Parameters.AddWithValue("@po_no", po_no)
            CMD.Parameters.AddWithValue("@terms", terms)
            CMD.Parameters.AddWithValue("@qty", qty)
            CMD.Parameters.AddWithValue("@unit", unit)
            CMD.Parameters.AddWithValue("@unit_price", unitprice)
            CMD.Parameters.AddWithValue("@amount", amount)
            CMD.Parameters.AddWithValue("@selected", SELECTED)
            CMD.Parameters.AddWithValue("@rs_id", rs_id)
            CMD.Parameters.AddWithValue("@lof_id", lof_id)
            CMD.Parameters.AddWithValue("@print_status", print_Stat)
            CMD.Parameters.AddWithValue("@logs_print_date", print_date_log)
            CMD.Parameters.AddWithValue("@user_id_logs", pub_user_id)
            Dim po_det_id As Integer = CMD.ExecuteScalar()
            pub_po_det_id = po_det_id

            'for multiple withdrawn items
            po_det_id_array = po_det_id_array & po_det_id & ","
            rs_id_array = rs_id_array & rs_id & ","

            ''applicable for warehouse to warehouse
            'If cmbLinktoOtherWh.Text = "YES" Then
            '    insert_to_dbWarehouse_to_Warehouse_tbl(po_det_id, qty, lbl_link_Wh_id.Text)
            'End If


            If lblInOut.Text = "FACILITIES" Or lblInOut.Text = "TOOLS" Then

                If qty > 1 Then
                    For i = 0 To qty - 1
                        INSERT_FACILITIES_ITEM(po_det_id, lof_id, Date.Parse("1991-01-01"), 0, 0, "", "pending", 1, "", "", 0)
                    Next
                Else
                    INSERT_FACILITIES_ITEM(po_det_id, lof_id, Date.Parse("1991-01-01"), 0, 0, "", "pending", qty, "", "", 0)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
        print_count = 0
    End Sub

    Public Function insert_to_dbWarehouse_to_Warehouse_tbl(po_det_id As Integer, qty As Double, wh_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()

            newCMD = New SqlCommand("proc_withdrawal_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 11)
            newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newCMD.Parameters.AddWithValue("@qty", qty)

            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE:  " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function

    Public Sub INSERT_PO(n As Integer)

        Try
            SQ.connection.Open()

            CMD = New SqlCommand("proc_po_query", SQ.connection)
            CMD.Parameters.Clear()
            CMD.CommandType = CommandType.StoredProcedure

            CMD.Parameters.AddWithValue("@n", n)

            If n = 1 Then

                CMD.Parameters.AddWithValue("@po_date", Date.Parse(DTPTrans.Text))
                    CMD.Parameters.AddWithValue("@rs_no", txtRsNo.Text)
                    CMD.Parameters.AddWithValue("@instructions", txtInstructions.Text)
                    CMD.Parameters.AddWithValue("@charge_to", lblChargeToID.Text)
                    CMD.Parameters.AddWithValue("@charge_type", lblTypeOfCharge.Text)
                    CMD.Parameters.AddWithValue("@date_needed", Date.Parse(DTPdateneeded.Text))
                    CMD.Parameters.AddWithValue("@prepared_by", txtPrepared_by.Text)
                    CMD.Parameters.AddWithValue("@checked_by", txtChecked_by.Text)
                    CMD.Parameters.AddWithValue("@approved_by", txtApproved_by.Text)
                    CMD.Parameters.AddWithValue("@user_id", pub_user_id)
                    CMD.Parameters.AddWithValue("@date_log", Format(Date.Parse(Now), "yyyy-MM-dd HH:mm:ss"))
                    CMD.Parameters.AddWithValue("@dr_option", cmbdr_option.Text)
                    CMD.Parameters.AddWithValue("@remarks", txtRemarks.Text)


            ElseIf n = 111 Then

                CMD.Parameters.AddWithValue("@po_date", Date.Parse(DTPTrans.Text))
                CMD.Parameters.AddWithValue("@rs_no", txtRsNo.Text)
                CMD.Parameters.AddWithValue("@operator_id", get_operator_id(cmb_driver.Text))
                CMD.Parameters.AddWithValue("@requestor", txtRequestor.Text)
                CMD.Parameters.AddWithValue("@dr_time", Date.Parse(DTPdateneeded.Text))
                CMD.Parameters.AddWithValue("@checked_by", txtChecked_by.Text)
                CMD.Parameters.AddWithValue("@address", txtPrepared_by.Text)
                CMD.Parameters.AddWithValue("@received_by", txtApproved_by.Text)
                CMD.Parameters.AddWithValue("@user_id", pub_user_id)
                CMD.Parameters.AddWithValue("@date_log", Format(Date.Parse(Now), "yyyy-MM-dd HH:mm:ss"))
                CMD.Parameters.AddWithValue("@dr_option", cmbdr_option.Text)
                CMD.Parameters.AddWithValue("@remarks", txtRemarks.Text)
            End If

            pub_po_id = CMD.ExecuteScalar()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            isWithdrawal = False
        Finally
            SQ.connection.Close()

        End Try

    End Sub



    Public Function get_operator_id(driver_name As String) As Integer
        Dim newsql As New SQLcon
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand

        Try
            newsql.connection1.Open()

            Dim query As String = "SELECT * FROM dboperator WHERE operator_name = '" & driver_name & "'"
            newcmd = New SqlCommand(query, newsql.connection1)
            newdr = newcmd.ExecuteReader
            While newdr.Read
                get_operator_id = newdr.Item("operator_id").ToString
            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsql.connection1.Close()
        End Try

    End Function
    Public Sub UPDATE_INSERT_POINFO()
        INSERT_PO(1)
    End Sub
    Public Sub UPDATE_PO_DETAILS_USING_NEW_INSERT_PO(po_id As Integer)
        Dim status As String
        Dim d As Integer
        Dim supp_reciepent_id As Integer
        Dim inout As String = ""


        For Each oRow As DataGridViewRow In dgvPOList.Rows

            If oRow.Cells("column13").Value = True Then
                status = "TRUE"
            Else
                status = "FALSE"
            End If

            Dim a(11) As String

            If oRow.Cells("col_inout").Value = "IN" Or oRow.Cells("col_inout").Value = "OTHERS" Or oRow.Cells("col_inout").Value = "BORROWER" Then
                supp_reciepent_id = get_id("dbSupplier", "Supplier_Name", dgvPOList.Rows(d).Cells(1).Value, 0)
            ElseIf oRow.Cells("col_inout").Value = "OUT" Then
                supp_reciepent_id = get_id("dbwh_area", "wh_area", dgvPOList.Rows(d).Cells(1).Value, 0)
            End If

            inout = oRow.Cells("col_inout").Value

            a(0) = po_id
            a(1) = supp_reciepent_id
            a(2) = dgvPOList.Rows(d).Cells(2).Value
            a(3) = dgvPOList.Rows(d).Cells(4).Value
            a(4) = dgvPOList.Rows(d).Cells(5).Value
            a(5) = dgvPOList.Rows(d).Cells(6).Value
            a(6) = dgvPOList.Rows(d).Cells(7).Value
            a(7) = dgvPOList.Rows(d).Cells(8).Value
            a(8) = dgvPOList.Rows(d).Cells(9).Value
            a(9) = dgvPOList.Rows(d).Cells(10).Value
            a(10) = dgvPOList.Rows(d).Cells(11).Value
            a(11) = status

            UPDATE_PO_DETAILS(a(0), a(1), a(2), a(3), a(4), a(5), a(6), a(7), a(8), a(9), a(10), a(11))

            d += 1

        Next

        If inout = "OUT" Then
            Dim id As Integer = CInt(FWithdrawalList.lvlwithdrawalList.SelectedItems(0).Text)
            FWithdrawalList.btnSearch.PerformClick()
            listfocus(FWithdrawalList.lvlwithdrawalList, id)

        ElseIf typeofreq = "CASH" Then
            Dim id As Integer = CInt(FCashVoucherList.lvlvoucherlist.SelectedItems(0).Text)
            FCashVoucherList.btnSearch.PerformClick()
            listfocus(FCashVoucherList.lvlvoucherlist, id)

        Else
            Dim id As Integer = CInt(FPurchasedOrderList.lvlpurchasedOrderList.SelectedItems(0).Text)
            FPurchasedOrderList.btnSearch.PerformClick()
            listfocus(FPurchasedOrderList.lvlpurchasedOrderList, id)

        End If
    End Sub
    Public Sub UPDATE_PO()
        Try
            SQ.connection.Open()

            CMD = New SqlCommand("proc_po_query", SQ.connection)
            CMD.Parameters.Clear()
            CMD.CommandType = CommandType.StoredProcedure

            CMD.Parameters.AddWithValue("@n", 55)
            CMD.Parameters.AddWithValue("@po_date", Date.Parse(DTPTrans.Text))
            CMD.Parameters.AddWithValue("@rs_no", txtRsNo.Text)
            CMD.Parameters.AddWithValue("@instructions", txtInstructions.Text)
            CMD.Parameters.AddWithValue("@charge_to", 150)
            CMD.Parameters.AddWithValue("@charge_type", "ADFIL") 'lblTypeOfCharge.Text)
            CMD.Parameters.AddWithValue("@dr_option", cmbdr_option.Text)
            CMD.Parameters.AddWithValue("@remarks", txtRemarks.Text)

            If DTPdateneeded.Visible = False Then
                CMD.Parameters.AddWithValue("@date_needed", Date.Parse("1991-01-01"))
            Else
                CMD.Parameters.AddWithValue("@date_needed", Date.Parse(DTPdateneeded.Text))
            End If

            CMD.Parameters.AddWithValue("@prepared_by", txtPrepared_by.Text)
            CMD.Parameters.AddWithValue("@checked_by", txtChecked_by.Text)
            CMD.Parameters.AddWithValue("@approved_by", txtApproved_by.Text)
            CMD.Parameters.AddWithValue("@po_id", set_po_id)
            CMD.Parameters.AddWithValue("@date_log_updated", Format(Date.Parse(Now), "yyyy-MM-dd HH:mm:ss"))
            CMD.ExecuteNonQuery()


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Sub UPDATE_PO_DETAILS(ByVal po_id As Integer, ByVal sup_id As Integer, ByVal wh_id As Integer, ByVal item_desc As String,
                                    ByVal po_no As String, ByVal terms As String, ByVal qty As Double,
                                    ByVal unit As String, ByVal unitprice As Double, ByVal amount As Double, ByVal po_det_id As Integer, ByVal selected As String)
        Try
            SQ.connection.Open()
            Dim lof_id As Integer = get_lof_id(wh_id, item_desc)

            CMD = New SqlCommand("proc_po_query", SQ.connection)
            CMD.Parameters.Clear()
            CMD.CommandType = CommandType.StoredProcedure

            CMD.Parameters.AddWithValue("@n", 66)
            CMD.Parameters.AddWithValue("@po_det_id", po_det_id)
            CMD.Parameters.AddWithValue("@po_id", po_id)
            CMD.Parameters.AddWithValue("@supplier_id", sup_id)
            CMD.Parameters.AddWithValue("@wh_id", wh_id)
            CMD.Parameters.AddWithValue("@item_desc", item_desc)
            CMD.Parameters.AddWithValue("@po_no", po_no)
            CMD.Parameters.AddWithValue("@terms", terms)
            CMD.Parameters.AddWithValue("@qty", qty)
            CMD.Parameters.AddWithValue("@unit", unit)
            CMD.Parameters.AddWithValue("@unit_price", unitprice)
            CMD.Parameters.AddWithValue("@amount", amount)
            CMD.Parameters.AddWithValue("@selected", selected)
            CMD.Parameters.AddWithValue("@lof_id", lof_id)
            CMD.Parameters.AddWithValue("@user_id_update_logs", pub_user_id)

            CMD.ExecuteNonQuery()

            If lblInOut.Text = "BORROWER" Then

                UPDATE_FACILITIES_ITEM(po_det_id, lof_id, "pending")
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Public Sub UPDATE_FACILITIES_ITEM(ByVal po_det_id As Integer, ByVal lof_id As Integer, ByVal remarks As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            Dim query As String = "UPDATE dbfacilities_items SET lof_id = " & lof_id & ",remarks = '" & remarks & "' WHERE po_det_id = " & po_det_id

            newCMD = New SqlCommand(query, newSQ.connection)
            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

#End Region
#Region "FORM LOAD FUNCTIONS"
    Public Sub load_rs_others_with_po(ByVal n As Integer)
        dgvPOList.Rows.Clear()

        SQ.connection.Open()
        Dim dr As SqlDataReader
        Dim a(20) As String
        Dim c As Integer

        Try
            Dim query As String = ""
            If n = 0 Then
                query = "SELECT * FROM dbrequisition_slip WHERE rs_no = '" & txtRsNo.Text & "'"
            ElseIf n = 1 Then
                query = "SELECT *,b.rs_no, b.item_desc AS ITEMDESC FROM dbPO_details a "
                query &= "INNER JOIN dbrequisition_slip b ON a.rs_id = b.rs_id "
                query &= "INNER JOIN dbSupplier c ON a.supplier_id = c.Supplier_id "
                query &= "WHERE b.rs_no = '" & txtRsNo.Text & "'"
            End If

            CMD = New SqlCommand(query, SQ.connection)
            dr = CMD.ExecuteReader
            While dr.Read
                If n = 0 Then
                    a(2) = dr.Item("rs_id").ToString
                    a(3) = dr.Item("item_desc").ToString
                    a(7) = dr.Item("qty").ToString
                    a(8) = dr.Item("unit").ToString
                    a(9) = 0
                    a(10) = 0
                    a(11) = 0
                    a(12) = dr.Item("rs_id").ToString

                ElseIf n = 1 Then
                    a(1) = dr.Item("supplier_name").ToString
                    a(2) = dr.Item("wh_id").ToString
                    a(3) = dr.Item("ITEMDESC").ToString
                    a(4) = dr.Item("item_desc").ToString
                    a(5) = dr.Item("po_no").ToString
                    a(6) = dr.Item("terms").ToString
                    a(7) = dr.Item("qty").ToString
                    a(8) = dr.Item("unit").ToString
                    a(9) = FormatNumber(CDbl(dr.Item("unit_price").ToString), 2, , TriState.True)
                    a(10) = FormatNumber(CDbl(dr.Item("unit_price").ToString) * CDbl(dr.Item("qty").ToString), 2, , TriState.True)
                    a(11) = dr.Item("po_det_id").ToString
                    a(12) = dr.Item("rs_id").ToString

                End If

                dgvPOList.Rows.Add(a)


                If n = 0 Then

                ElseIf n = 1 Then
                    If dr.Item("selected").ToString = "TRUE" Then
                        dgvPOList.Rows(c).Cells(0).Value = True
                    Else
                        dgvPOList.Rows(c).Cells(0).Value = False
                    End If
                End If


                c += 1
            End While

            dr.Close()

        Catch ex As Exception
            message("", 2, ex)

        Finally
            SQ.connection.Close()

        End Try
    End Sub

    Public Sub load_wh_item_using_rs()
        dgvPOList.Rows.Clear()
        Dim row As Integer
        Dim typeofpurchasing As String = "PURCHASE ORDER"

        Try
            SQ.connection.Open()

            If lblReqType.Text = "PROJECT" And lblInOut.Text = "OTHERS" Then
                publicquery = "SELECT * FROM dbrequisition_slip WHERE rs_no = " & Val(txtRsNo.Text)

            ElseIf lblReqType.Text = "EQUIPMENT" And lblInOut.Text = "OTHERS" Then
                publicquery = "SELECT * FROM dbrequisition_slip WHERE rs_no = " & Val(txtRsNo.Text)

            ElseIf lblReqType.Text = "SUPPLY" And lblInOut.Text = "OTHERS" Then
                publicquery = "SELECT * FROM dbrequisition_slip WHERE rs_no = " & Val(txtRsNo.Text)
            Else

                publicquery = "SELECT b.wh_id,b.whItem,a.qty,a.unit,a.typeRequest,a.rs_id,a.process,a.IN_OUT,b.whItemDesc,a.rs_id FROM dbrequisition_slip a " &
              "INNER JOIN dbwarehouse_items b ON a.wh_id = b.wh_id " &
              "WHERE a.rs_no = '" & Val(txtRsNo.Text) & "' AND a.type_of_purchasing = '" & typeofpurchasing & "'"

            End If

            If lblTypeOfReq.Text = "BORROWER" And lblInOut.Text = "FACILITIES" Or lblInOut.Text = "TOOLS" Or lblInOut.Text = "ADD-ON" Then

                publicquery = "SELECT b.fac_id,b.facility_name,a.qty,a.unit,a.typeRequest,a.rs_id,a.process,a.IN_OUT,a.rs_id FROM dbrequisition_slip a " &
             "INNER JOIN dbfacilities_names b ON a.wh_id = b.fac_id " &
             "WHERE a.rs_no = '" & Val(txtRsNo.Text) & "' AND a.type_of_purchasing = '" & typeofpurchasing & "'"

            End If

            CMD = New SqlCommand(publicquery, SQ.connection)
            DR = CMD.ExecuteReader

            While DR.Read

                Dim a(12) As String

                If lblReqType.Text = "PROJECT" And lblInOut.Text = "OTHERS" Then
                    'a(1) = dr.Item("item_desc").ToString
                    'a(2) = dr.Item("qty").ToString
                    'a(3) = dr.Item("unit").ToString
                    'a(4) = 0
                    'a(5) = 0
                    'a(6) = 0
                    'a(7) = dr.Item("rs_id").ToString
                    a(2) = DR.Item("wh_id").ToString
                    a(3) = DR.Item("item_desc").ToString

                ElseIf lblReqType.Text = "EQUIPMENT" And lblInOut.Text = "OTHERS" Then
                    'a(1) = dr.Item("item_desc").ToString
                    'a(2) = dr.Item("qty").ToString
                    'a(3) = dr.Item("unit").ToString
                    'a(4) = 0
                    'a(5) = 0
                    'a(6) = 0
                    'a(7) = dr.Item("rs_id").ToString
                    a(2) = DR.Item("wh_id").ToString
                    a(3) = DR.Item("item_desc").ToString
                    a(6) = DR.Item("qty").ToString
                    a(7) = DR.Item("unit").ToString
                    a(8) = 0
                    a(9) = 0

                ElseIf lblReqType.Text = "SUPPLY" And lblInOut.Text = "OTHERS" Then
                    'a(1) = dr.Item("item_desc").ToString
                    'a(2) = dr.Item("qty").ToString
                    'a(3) = dr.Item("unit").ToString
                    'a(4) = 0
                    'a(5) = 0
                    'a(6) = 0
                    'a(7) = dr.Item("rs_id").ToString
                    a(2) = DR.Item("wh_id").ToString
                    a(3) = DR.Item("item_desc").ToString
                    a(6) = DR.Item("qty").ToString
                    a(7) = DR.Item("unit").ToString
                    a(8) = 0
                    a(9) = 0

                ElseIf lblTypeOfReq.Text = "BORROWER" And lblInOut.Text = "FACILITIES" Or lblInOut.Text = "TOOLS" Or lblInOut.Text = "ADD-ON" Then
                    a(2) = DR.Item("fac_id").ToString
                    a(3) = DR.Item("facility_name").ToString
                    a(7) = DR.Item("qty").ToString
                    a(8) = DR.Item("unit").ToString
                    a(9) = 0
                    a(12) = DR.Item("rs_id").ToString

                Else

                    If DR.Item("typeRequest").ToString = "OTHERS" Then
                        a(3) = GET_ITEM_DESC_FROM_OTHERS(DR.Item("wh_id").ToString)
                    Else
                        a(3) = DR.Item("whItemDesc").ToString
                    End If

                    If DR.Item("typeRequest").ToString = "OTHERS" And DR.Item("process").ToString = "PERSONAL" Then
                        a(3) = FRequistionForm.GET_ITEM_DESC_FROM_PERSONAL_TOOLS(DR.Item("wh_id").ToString)

                    ElseIf DR.Item("IN_OUT").ToString = "FACILITIES" Then
                        If DR.Item("process").ToString = "PERSONAL" Then
                            a(3) = FRequistionForm.GET_ITEM_DESC_FROM_PERSONAL_TOOLS(DR.Item("wh_id").ToString)
                        Else
                            a(3) = FRequistionForm.GET_ITEM_DESC_FROM_OTHERS(DR.Item("wh_id").ToString)
                        End If

                    ElseIf DR.Item("IN_OUT").ToString = "TOOLS" Then
                        If DR.Item("process").ToString = "PERSONAL" Then
                            a(3) = FRequistionForm.GET_ITEM_DESC_FROM_PERSONAL_TOOLS(DR.Item("wh_id").ToString)
                        Else
                            a(3) = FRequistionForm.GET_ITEM_DESC_FROM_OTHERS(DR.Item("wh_id").ToString)
                        End If

                    ElseIf DR.Item("IN_OUT").ToString = "ADD-ON" Then
                        If DR.Item("process").ToString = "PERSONAL" Then
                            a(3) = FRequistionForm.GET_ITEM_DESC_FROM_PERSONAL_TOOLS(DR.Item("wh_id").ToString)
                        Else
                            a(3) = FRequistionForm.GET_ITEM_DESC_FROM_OTHERS(DR.Item("wh_id").ToString)
                        End If
                    End If

                    Dim price As Double = update_item_price(DR.Item("wh_id").ToString)
                    Dim totalprice As Double = price * CDbl(DR.Item("qty").ToString)

                    a(3) = DR.Item("whItemDesc").ToString
                    a(2) = DR.Item("wh_id").ToString
                    a(7) = DR.Item("qty").ToString
                    a(8) = DR.Item("unit").ToString
                    a(9) = 0
                    a(10) = 0
                    a(11) = 0
                    a(12) = DR.Item("rs_id").ToString

                End If

                dgvPOList.Rows.Add(a)

                'If check_if_rs_cancel(dr.Item("rs_id").ToString) > 0 Then
                '    With DataGridView1.Rows(row)
                '        For i = 0 To 5
                '            .Cells(i).Style.BackColor = Color.Red
                '            .Cells(i).Style.ForeColor = Color.White
                '        Next
                '    End With
                'End If

                row += 1
            End While
            DR.Close()

            dgvPOList.AllowUserToAddRows = False

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()

        End Try

    End Sub

    Public Function Load_po_details(ByVal po_id As Integer)
        dgvPOList.Rows.Clear()

        Dim c As Integer
        Try

            SQ.connection.Open()

            CMD = New SqlCommand("proc_po_query", SQ.connection)
            CMD.Parameters.Clear()
            CMD.CommandType = CommandType.StoredProcedure

            CMD.Parameters.AddWithValue("@n", 3)
            CMD.Parameters.AddWithValue("@po_id", po_id)

            DR = CMD.ExecuteReader

            While DR.Read
                Dim a(13) As String

                a(1) = DR.Item("Supplier_Name").ToString
                a(2) = DR.Item("wh_id").ToString

                If TYPE_IN_OUT(DR.Item("wh_id").ToString) = "FACILITIES" Or TYPE_IN_OUT(DR.Item("wh_id").ToString) = "TOOLS" Or TYPE_IN_OUT(DR.Item("wh_id").ToString) = "ADD-ON" Then
                    a(3) = FRequistionForm.GET_ITEM_DESC_FROM_FACILITIES(DR.Item("wh_id").ToString)
                Else
                    a(3) = DR.Item("whItem").ToString & " - " & DR.Item("whItemDesc").ToString
                End If

                a(4) = DR.Item("item_desc").ToString
                a(5) = DR.Item("po_no").ToString
                a(6) = DR.Item("terms").ToString
                a(7) = DR.Item("qty").ToString
                a(8) = DR.Item("unit").ToString
                a(9) = FormatNumber(DR.Item("unit_price").ToString, 2, , , TriState.True)
                a(10) = FormatNumber(CInt(DR.Item("qty").ToString) * CDbl(DR.Item("unit_price").ToString), 2, , , TriState.True)
                a(11) = DR.Item("po_det_id").ToString
                a(12) = DR.Item("rs_id").ToString
                a(13) = DR.Item("lof_id").ToString


                dgvPOList.Rows.Add(a)

                If DR.Item("selected").ToString = "TRUE" Then
                    dgvPOList.Rows(c).Cells(0).Value = True
                Else
                    dgvPOList.Rows(c).Cells(0).Value = False
                End If

                c += 1
            End While

            DR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Function

    Public Function load_po()
        Try
            SQ.connection.Open()

            CMD = New SqlCommand("proc_po_query", SQ.connection)
            CMD.Parameters.Clear()
            CMD.CommandType = CommandType.StoredProcedure

            CMD.Parameters.AddWithValue("@n", 4)
            CMD.Parameters.AddWithValue("@rs_no", txtRsNo.Text)

            DR = CMD.ExecuteReader

            While DR.Read

                pub_po_id = DR.Item("po_id").ToString
                DTPTrans.Text = DR.Item("po_date").ToString
                txtRsNo.Text = DR.Item("rs_no").ToString
                txtInstructions.Text = DR.Item("instructor").ToString
                DTPdateneeded.Text = DR.Item("date_needed").ToString
                txtPrepared_by.Text = DR.Item("prepared_by").ToString
                txtChecked_by.Text = DR.Item("checked_by").ToString
                txtApproved_by.Text = DR.Item("approved_by").ToString
                lblTypeOfCharge.Text = DR.Item("charge_type").ToString

                ' a.po_id()
                ',a.po_date
                ',a.rs_no
                ',a.instructor
                ',a.charge_to_id
                ',a.charge_type
                ',a.date_needed
                ',a.prepared_by
                ',a.checked_by
                ',a.approved_by

            End While

            DR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

    End Function

#End Region
#Region "FUNCTIONS"
    Public Function get_lof_id(ByVal fac_id As Integer, ByVal fac_brand As String) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()

            Dim query As String = ""

            query &= "SELECT a.lof_id,b.facility_name,a.brand FROM dbfacilities_list a "
            query &= "INNER JOIN dbfacilities_names b "
            query &= "ON a.fac_id = b.fac_id "
            query &= "WHERE b.fac_id = " & fac_id & " "
            query &= "AND a.brand = '" & fac_brand & "'"

            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_lof_id = CInt(newDR.Item("lof_id").ToString)
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'conn.connection.Close()
            newSQ.connection.Close()
        End Try
    End Function

    Public Sub show_warehouse_list()
        'Column1.Items.Clear()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT wh_area FROM dbwh_area"
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                ' Column1.Items.Add(newDR.Item(0).ToString)
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Public Sub show_supplier_list()
        'Column1.Items.Clear()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_supplier", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 2)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                'Column1.Items.Add(newDR.Item(1).ToString)
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Public Sub show_quary_source()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader



        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT * FROM dbQuarryInfo"
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                'Column1.Items.Add(newDR.Item("quarry_name").ToString)
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Public Sub grandtotal()

        Dim total As Double

        For i = 0 To dgvPOList.Rows.Count - 1
            total += CDbl(dgvPOList.Rows(i).Cells(10).Value)

        Next

        lblTotal.Text = FormatNumber(total, 2, , , TriState.True)
    End Sub
    Private Function get_terms(ByVal supname As String) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try

            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_supplier", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 1)
            newCMD.Parameters.AddWithValue("@value", supname)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_terms = newDR.Item("terms").ToString
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Function update_item_price(ByVal wh_id As Integer) As Double

        Dim newSQ As New SQLcon
        Dim newcmd As SqlCommand
        Dim newdr As SqlDataReader
        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT DISTINCT a.wh_id,b.unit_price,c.date_received FROM dbreceiving_items a " &
                                     "INNER JOIN dbPurchase_order_items b ON b.wh_id = a.wh_id " &
                                     "INNER JOIN dbreceiving_info c ON c.rr_info_id = a.rr_info_id WHERE a.wh_id = " & wh_id &
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
    Private Sub FPOFORM_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        pboxHeader.Width = FMain.Width - FMain.ToolStrip1.Width

        With dgvPOList
            .Height = Me.Height - 135
            .Width = Me.Width - 245

            'grpStatus.Width = lvlrequisitionlist.Width
        End With

        btnExit.Parent = pboxHeader
        btnExit.BringToFront()
        btnExit.Location = New Point(dgvPOList.Width + 210, 9)
    End Sub
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
#End Region


    Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPOList.CellEndEdit

        If Not IsNumeric(dgvPOList.Rows(Format(rowind)).Cells(9).Value()) Then

            MessageBox.Show("Entry must numeric..", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dgvPOList.Rows(Format(rowind)).Cells(9).Selected = True
            dgvPOList.Rows(Format(rowind)).Cells(9).Value = FormatNumber(old_price_value, 2, , , TriState.True)

        ElseIf Not IsNumeric(dgvPOList.Rows(Format(rowind)).Cells(7).Value()) Then
            MessageBox.Show("Entry must numeric..", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dgvPOList.Rows(Format(rowind)).Cells(7).Selected = True
            dgvPOList.Rows(Format(rowind)).Cells(7).Value = CInt(old_qty)

        Else
            dgvPOList.Rows(Format(rowind)).Cells(9).Value = dgvPOList.Rows(Format(rowind)).Cells(9).Value 'FormatNumber(CDbl(dgvPOList.Rows(Format(rowind)).Cells(9).Value), 2, , , TriState.True)
            'dgvPOList.Rows(Format(rowind)).Cells(10).Value = FormatNumber(CDec(dgvPOList.Rows(Format(rowind)).Cells(9).Value) * CDec(dgvPOList.Rows(Format(rowind)).Cells(7).Value), 2, , , TriState.True) 'FormatNumber(CDbl(dgvPOList.Rows(Format(rowind)).Cells(9).Value) * CDbl(dgvPOList.Rows(Format(rowind)).Cells(7).Value), 2, , , TriState.True)

            Dim amount As Double = CDec(dgvPOList.Rows(Format(rowind)).Cells(9).Value) * CDec(dgvPOList.Rows(Format(rowind)).Cells(7).Value)
            Dim vat As Double = amount * (vatTemp / 100)

            dgvPOList.Rows(Format(rowind)).Cells(10).Value = FormatNumber(amount + vat, 2, , , TriState.True)

            grandtotal()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPOList.CellContentClick

    End Sub

    Private Sub txtPrepared_by_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrepared_by.GotFocus, txtChecked_by.GotFocus, txtApproved_by.GotFocus, txtRsNo.GotFocus, txtInstructions.GotFocus _
        , txtChargeTo.GotFocus

        sender.backcolor = Color.Yellow

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

    Private Sub txtChecked_by_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtChecked_by.KeyDown

    End Sub

    Private Sub txtPrepared_by_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrepared_by.KeyDown, txtApproved_by.KeyDown, txtChecked_by.KeyDown

        pub_textbox = sender

        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down Then
                lbox_List.Focus()
                lbox_List.SelectedIndex = 0

            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtPrepared_by_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrepared_by.Leave, txtChecked_by.Leave, txtApproved_by.Leave, txtRsNo.Leave, txtInstructions.Leave _
    , txtChargeTo.Leave
        sender.backcolor = Color.White
    End Sub

    Private Sub txtbox(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrepared_by.TextChanged, txtChecked_by.TextChanged, txtApproved_by.TextChanged
        Dim tbox As TextBox = sender
        Dim n As Integer

        If tbox.Name = "txtPrepared_by" Then : n = 0 : ElseIf tbox.Name = "txtChecked_by" Then
            n = 1 : ElseIf tbox.Name = "txtApproved_by" Then : n = 2
        End If

        Try
            If tbox.Text = "" Then
                lbox_List.BringToFront()
                lbox_List.Parent = Me
                lbox_List.Location = New System.Drawing.Point(tbox.Bounds.Left + 5, tbox.Bounds.Bottom + (tbox.Height * 2))
                lbox_List.Visible = False
            Else
                lbox_List.BringToFront()
                With lbox_List
                    lbox_List.Parent = Me
                    .Location = New System.Drawing.Point(tbox.Bounds.Left + 6, tbox.Bounds.Bottom + (tbox.Height * 2))
                    .Visible = True
                    .Items.Clear()
                    .Width = tbox.Width
                End With

                ' get_withdraw(n, tbox)
                POList(tbox, n)
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Public Sub POList(ByVal txtbox As TextBox, ByVal n As Integer)
        Dim count As Integer = 0
        lbox_List.Items.Clear()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            If n = 0 Then
                publicquery = "SELECT DISTINCT prepared_by FROM dbPO WHERE prepared_by LIKE '%" & txtbox.Text & "%' ORDER BY prepared_by ASC"
            ElseIf n = 1 Then
                publicquery = "SELECT DISTINCT checked_by FROM dbPO WHERE checked_by LIKE '%" & txtbox.Text & "%' ORDER BY checked_by ASC"
            ElseIf n = 2 Then
                publicquery = "SELECT DISTINCT approved_by FROM dbPO WHERE approved_by LIKE '%" & txtbox.Text & "%' ORDER BY approved_by ASC"
            End If
            newCMD = New SqlCommand(publicquery, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                If n = 0 Then
                    lbox_List.Items.Add(newDR.Item("prepared_by").ToString)
                    count += 1
                ElseIf n = 1 Then
                    lbox_List.Items.Add(newDR.Item("checked_by").ToString)
                    count += 1
                ElseIf n = 2 Then
                    lbox_List.Items.Add(newDR.Item("approved_by").ToString)
                    count += 1
                End If
            End While

            If count > 0 Then
                lbox_List.Visible = True
            Else
                lbox_List.Visible = False
            End If

            newDR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub lbox_List_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbox_List.DoubleClick
        If lbox_List.SelectedItems.Count > 0 Then
            For Each ctr As Control In FlowLayoutPanel1.Controls
                If ctr.Name = name1 Then
                    ctr.Text = lbox_List.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next
            lbox_List.Visible = False
        Else
            MessageBox.Show("Pls select one item", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub lbox_List_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lbox_List.KeyDown

        If e.KeyCode = Keys.Enter Then
            If lbox_List.SelectedItems.Count > 0 Then
                For Each ctr As Control In FlowLayoutPanel1.Controls
                    If ctr.Name = name1 Then
                        ctr.Text = lbox_List.SelectedItem.ToString
                        ctr.Focus()
                    End If
                Next
                lbox_List.Visible = False
            End If

        ElseIf e.KeyCode = Keys.Up Then
            If lbox_List.SelectedIndex = 0 Then
                Dim f As Integer
                f = 1

                If f = 1 Then
                    pub_textbox.Focus()

                End If
                lbox_List.Visible = False
            End If

        End If
    End Sub
    Private Sub CommonHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If lbox_List.Visible = True Then
            lbox_List.Visible = False
        End If

    End Sub

    Private Sub lbox_List_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbox_List.SelectedIndexChanged

    End Sub

    Private Sub txtChecked_by_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChecked_by.TextChanged

    End Sub

    Private Sub txtApproved_by_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtApproved_by.TextChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        For Each ctr As Control In Me.Controls
            If ctr.Name = "Panel1" Then
                ctr.Visible = False

            Else
                ctr.Enabled = True

            End If
        Next
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPOList.CellDoubleClick

        Dim inout As String = dgvPOList.Rows(rowind).Cells(14).Value
        rowind = Format(get_datagrid_rowindex)

        If inout = "FACILITIES" Or inout = "TOOLS" Or inout = "ADD-ON" Then

            If dgvPOList.Rows(rowind).Cells(4).Selected = True Then
                For Each ctr As Control In Me.Controls
                    If ctr.Name = "Panel1" Then
                        ctr.Visible = True

                    Else
                        ctr.Enabled = False

                    End If
                Next
            End If

            lblItemName.Text = dgvPOList.Rows(rowind).Cells(3).Value
            load_facility_names(lblItemName.Text)


        ElseIf dgvPOList.Rows(rowind).Cells(14).Value = "OUT" Then

            If dgvPOList.Rows(rowind).Cells(9).Selected = True Then
                pnl_prices.Visible = True
                get_prices_from_items(dgvPOList.Rows(rowind).Cells(2).Value)

            ElseIf dgvPOList.Rows(rowind).Cells(7).Selected = True Then
                For Each ctr As Control In Me.Controls
                    If ctr.Name = "Panel2" Then
                        ctr.Visible = True
                    Else
                        ctr.Enabled = False
                    End If
                Next
            Else
            End If

        Else

        End If

        'If lblInOut.Text = "FACILITIES" Or lblInOut.Text = "TOOLS" Or lblInOut.Text = "ADD-ON" Then
        '    rowind = Format(get_datagrid_rowindex)

        '    If DataGridView1.Rows(rowind).Cells(4).Selected = True Then
        '        For Each ctr As Control In Me.Controls
        '            If ctr.Name = "Panel1" Then
        '                ctr.Visible = True

        '            Else
        '                ctr.Enabled = False

        '            End If
        '        Next
        '    End If

        '    lblItemName.Text = DataGridView1.Rows(rowind).Cells(3).Value
        '    load_facility_names(lblItemName.Text)

        'End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Button2.PerformClick()

        Dim lof_id As Integer = get_id("dbfacilities_list", "brand", cmbBrand.Text, 0)

        dgvPOList.Rows(rowind).Cells(4).Value = cmbBrand.Text
        dgvPOList.Rows(rowind).Cells(13).Value = lof_id

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        For Each row As DataGridViewRow In dgvPOList.Rows
            If row.Cells(11).Value = FPurchasedOrderList.lvlpurchasedOrderList.SelectedItems(0).Text Then
                row.Cells(0).Value = True
            End If
        Next

    End Sub

    Private Sub SplitQuantityToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SplitQuantityToolStripMenuItem.Click
        For Each ctr As Control In Me.Controls
            If ctr.Name = "Panel2" Then
                ctr.Visible = True
                txtsplitqty.Focus()

            Else
                ctr.Enabled = False

            End If
        Next

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        For Each ctr As Control In Me.Controls
            If ctr.Name = "Panel2" Then
                ctr.Visible = False

            Else
                ctr.Enabled = True

            End If
        Next
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim qty As Integer = CInt(dgvPOList.Rows(rowind).Cells(7).Value)

        If CDbl(txtsplitqty.Text) = 0 Then
            MessageBox.Show("zero is not applicable..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        ElseIf CDbl(txtsplitqty.Text) > CDbl(dgvPOList.Rows(rowind).Cells(7).Value) Then
            MessageBox.Show("check your qty, must not greater than selected items.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim a(20) As String


        With dgvPOList.Rows(rowind)

            a(1) = .Cells(1).Value
            a(2) = .Cells(2).Value
            a(3) = .Cells(3).Value
            a(4) = .Cells(4).Value
            a(5) = .Cells(5).Value
            a(6) = .Cells(6).Value
            a(7) = CDbl(txtsplitqty.Text)
            a(8) = .Cells(8).Value
            a(9) = .Cells(9).Value
            a(10) = .Cells(10).Value
            a(11) = .Cells(11).Value
            a(12) = .Cells(12).Value
            a(13) = .Cells(13).Value
            a(14) = .Cells(14).Value
            a(15) = .Cells(15).Value
            a(16) = .Cells(16).Value
        End With

        'dgvPOList.Rows.Add(a)

        'dgvPOList.Rows(rowind).Cells(7).Value = CDbl(dgvPOList.Rows(0).Cells(7).Value) - CDbl(txtsplitqty.Text)
        'dgvPOList.Rows(rowind).Cells(1).Value = False
        'dgvPOList.Rows(dgvPOList.Rows.Count - 1).Cells("Column13").Value = True

        dgvPOList.Rows(rowind).Cells(7).Value = CDbl(dgvPOList.Rows(rowind).Cells(7).Value) - CDbl(txtsplitqty.Text)
        dgvPOList.Rows.Add(a)

        uncheck_datagridview()
        'dgvPOList.Rows(dgvPOList.Rows.Count - 1).Cells("Column13").Value = True
        'dgvPOList.Rows(dgvPOList.Rows.Count - 1).Selected = True
        'dgvPOList.Focus()

        dgvPOList.Rows(dgvPOList.Rows.Count - 1).Cells("Column13").Value = True
        dgvPOList.CurrentCell = dgvPOList.Rows(dgvPOList.Rows.Count - 1).Cells(0)
        Button4.PerformClick()
        dgvPOList.Focus()



    End Sub
    Public Sub uncheck_datagridview()
        For i = 0 To dgvPOList.Rows.Count - 1

            dgvPOList.Rows(i).Cells("Column13").Value = False
            dgvPOList.Rows(i).Selected = False
        Next
    End Sub

    Private Sub txtsplitqty_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsplitqty.KeyDown

        If Not (e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 48 Or e.KeyValue = 49 Or e.KeyValue = 50 Or e.KeyValue = 51 Or e.KeyValue = 52 Or e.KeyValue = 53 Or e.KeyValue = 54 Or
         e.KeyValue = 55 Or e.KeyValue = 56 Or e.KeyValue = 57 Or e.KeyValue = 96 Or e.KeyValue = 97 Or e.KeyValue = 98 Or e.KeyValue = 99 Or
         e.KeyCode = Keys.OemPeriod Or
        e.KeyValue = 100 Or e.KeyValue = 101 Or e.KeyValue = 102 Or e.KeyValue = 103 Or e.KeyValue = 104 Or e.KeyValue = 105 Or e.KeyValue = 37 Or e.KeyValue = 110 Or e.KeyValue = 39) Then

            e.SuppressKeyPress() = True
        End If

        If e.KeyCode = Keys.Enter Then
            Button5.PerformClick()
        End If
    End Sub

    Private Sub dgvPOList_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvPOList.CellMouseDoubleClick

        'If dgvPOList.Rows(rowind).Cells(14).Value = "OUT" Then
        '    pnl_prices.Visible = True
        '    get_prices_from_items(dgvPOList.SelectedRows(0).Cells(2).Value)
        'Else
        'End If

    End Sub

    Public Sub get_prices_from_items(ByVal id As Integer)
        lvl_prices.Items.Clear()
        Try
            SQ.connection.Open()
            Dim query As String = "SELECT a.wh_id,a.unit,b.rr_item_id,d.item_desc,f.whItemDesc,a.qty,d.amount,c.desired_qty FROM dbPO_details a"
            query &= " INNER JOIN dbreceiving_items b ON a.rs_id = b.rs_id"
            query &= " INNER JOIN dbreceiving_item_partially c ON c.rr_item_id = b.rr_item_id"
            query &= " INNER JOIN dbreceiving_items_sub d ON d.rr_item_id = b.rr_item_id "
            query &= " INNER JOIN dbreceiving_info e ON b.rr_info_id = e.rr_info_id "
            query &= " INNER JOIN dbwarehouse_items f ON a.wh_id = f.wh_id "
            query &= " WHERE a.wh_id = '" & id & "' ORDER BY e.date_received ASC"
            CMD = New SqlCommand(query, SQ.connection)
            DR = CMD.ExecuteReader

            While DR.Read

                Dim a(10) As String

                a(0) = DR.Item("rr_item_id").ToString
                'a(1) = DR.Item("whItemDesc").ToString
                a(1) = DR.Item("item_desc").ToString
                a(2) = DR.Item("unit").ToString
                a(3) = FormatNumber(CDbl(DR.Item("amount").ToString), 2, , TriState.True)


                Dim lvl As New ListViewItem(a)
                lvl_prices.Items.Add(lvl)

            End While
            DR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        pnl_prices.Visible = False
    End Sub

    Private Sub pnl_prices_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnl_prices.Paint

    End Sub

    Private Sub lvl_prices_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvl_prices.DoubleClick
        'dgvPOList.SelectedRows(0).Cells(9).Value = FormatNumber(CDbl(lvl_prices.SelectedItems(0).SubItems(3).Text))
        'dgvPOList.SelectedRows(0).Cells(10).Value = FormatNumber(CDbl(dgvPOList.SelectedRows(0).Cells(7).Value * dgvPOList.SelectedRows(0).Cells(9).Value))
        dgvPOList.Rows(rowind).Cells(9).Value = FormatNumber(CDbl(lvl_prices.SelectedItems(0).SubItems(3).Text))
        dgvPOList.Rows(rowind).Cells(10).Value = FormatNumber(CDbl(dgvPOList.Rows(rowind).Cells(7).Value * dgvPOList.Rows(rowind).Cells(9).Value))

        pnl_prices.Visible = False
    End Sub

    Private Sub ChargesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChargesToolStripMenuItem.Click
        Dim inout As String = dgvPOList.Rows(rowind).Cells(14).Value
        rowind = Format(get_datagrid_rowindex)

        If dgvPOList.Rows(rowind).Cells(1).Selected = True Then

            FAddSupplier.Label2.Text = "yes"
            FAddSupplier.Label3.Text = rowind
            FAddSupplier.ShowDialog()
            Exit Sub

        End If
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        rowind = Format(get_datagrid_rowindex)
        public_po = dgvPOList.Rows(rowind).Cells("Column4").Value

    End Sub

    Private Sub PastePONoByBatchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PastePONoByBatchToolStripMenuItem.Click
        For Each row As DataGridViewRow In dgvPOList.Rows
            row.Cells("Column4").Value = public_po
        Next
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        For Each row As DataGridViewRow In dgvPOList.Rows
            row.Cells(0).Value = True
        Next
    End Sub

    Private Sub txt_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtApproved_by.PreviewKeyDown, txtChecked_by.PreviewKeyDown, txtInstructions.PreviewKeyDown, txtPrepared_by.PreviewKeyDown, txtRequestor.PreviewKeyDown


        If e.KeyCode = Keys.Tab Then
            If lbox_List.Visible = True Then
                lbox_List.Visible = False
            End If
        End If

    End Sub

    Private Sub txtsplitqty_TextChanged(sender As Object, e As EventArgs) Handles txtsplitqty.TextChanged

    End Sub

    Private Sub dgvPOList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPOList.CellClick
        rowind = dgvPOList.CurrentRow.Index

    End Sub

    Private Sub dgvPOList_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvPOList.CellFormatting
        If dgvPOList.CurrentCell IsNot Nothing Then
            If e.RowIndex = dgvPOList.CurrentCell.RowIndex And e.ColumnIndex = dgvPOList.CurrentCell.ColumnIndex Then
                e.CellStyle.SelectionBackColor = Color.Green
            Else
                e.CellStyle.SelectionBackColor = dgvPOList.DefaultCellStyle.SelectionBackColor
            End If
        End If
    End Sub



    Private Sub btnLinktoWh_Click(sender As Object, e As EventArgs)
        button_click_name = "btnLinktoWh"
        FWarehouseItems.ShowDialog()

    End Sub


    Public Sub get_supply_addres()
        suplier_address = ""
        Dim newSQ As New SQLcon
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand
        Try
            newSQ.connection.Open()
            publicquery = "SELECT  b.Supplier_Location FROM dbPO_details a INNER JOIN dbSupplier b ON a.supplier_id = b.Supplier_Id WHERE a.po_no = '" & sup_po_address & "'"
            newcmd = New SqlCommand(publicquery, newSQ.connection)
            newdr = newcmd.ExecuteReader
            While newdr.Read
                suplier_address = newdr.Item("Supplier_Location").ToString()
            End While
            newdr.Close()
            newSQ.connection.Close()
        Catch ex As Exception

        End Try
    End Sub


    Public Sub get_po_details()
        Dim newSQ As New SQLcon
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand
        Try
            newSQ.connection.Open()
            publicquery = "SELECT * FROM dbrequisition_slip WHERE rs_no = '" & txtRsNo.Text & "'"
            newcmd = New SqlCommand(publicquery, newSQ.connection)
            newdr = newcmd.ExecuteReader
            While newdr.Read
                requestor_m = newdr.Item("requested_by").ToString
            End While
            newdr.Close()
            newSQ.connection.Close()
        Catch ex As Exception

        End Try

        getdata_printing()
        getdata_printed()
        update_if_for_print()
        update_if_already_Printed()
        'Dim po_det_id As String
        'For Each drv As DataGridViewRow In dgvPOList.Rows
        '    If drv.Cells(0).Value = True Then
        '        po_det_id = po_det_id + "," + drv.Cells(11).Value
        '    End If
        'Next
        'Dim i = po_det_id.IndexOf(",")
        'Dim all_po_det_id = po_det_id.Substring(i + 1)

        'Dim print_status = "PRINTED"
        'Dim query2 As String = "UPDATE dbPO_details SET print_date_logs = GETDATE(), print_status = '" + print_status + "' where po_det_id IN (" + all_po_det_id + ")"
        'Try
        '    newSQ.connection.Open()
        '    publicquery = query2
        '    newcmd = New SqlCommand(publicquery, newSQ.connection)
        '    newcmd.ExecuteNonQuery()
        '    newSQ.connection.Close()
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try


    End Sub


    Public Sub PO_preview_report_adfil()
        unique_charge_all = ""
        Dim Po_data As New DataTable
        Dim values_charge_all_part2 As List(Of String) = New List(Of String)
        Dim i As Integer = 0
        With Po_data
            .Columns.Add("Description")
            .Columns.Add("Qty")
            .Columns.Add("Unit")
            .Columns.Add("UnitPrice")
            .Columns.Add("Amount")

        End With
        For Each row2 As DataGridViewRow In dgvPOList.Rows
            If row2.Cells(0).Value = True Then
                i = 1
                If row2.Cells(9).Value = "0.00" Then
                    'row2.Cells(9).Value = "-"
                    Dim zeros As String = "0"
                    Dim stringToInteger As Integer = Convert.ToInt32(zeros)
                    row2.Cells(9).Value = stringToInteger

                End If
                If row2.Cells(10).Value = "0.00" Then
                    'row2.Cells(10).Value = "-"
                    Dim zeros As String = "0"
                    Dim stringToInteger As Integer = Convert.ToInt32(zeros)
                    row2.Cells(10).Value = stringToInteger
                End If
                Po_data.Rows.Add(row2.Cells(4).Value, row2.Cells(7).Value,
                       row2.Cells(8).Value, row2.Cells(9).Value, row2.Cells(10).Value)
                supplier_po = row2.Cells(1).Value
                terms = row2.Cells(6).Value
                'charge_tos = row2.Cells(16).Value
                values_charge_all_part2.Add(row2.Cells(16).Value)

            End If

        Next
        'pag kuha sa all charge gikan grid
        Dim result2 As List(Of String) = values_charge_all_part2.Distinct().ToList
        For Each element2 As String In result2
            unique_charge_all = unique_charge_all + " / " + element2.ToString
        Next

        FPurchasedOrderList.all_charge_to = ""
        Dim iii = unique_charge_all.IndexOf("/")
        FPurchasedOrderList.all_charge_to = unique_charge_all.Substring(iii + 1)


        If i = 1 Then
            Dim view_po_print As New DataView(Po_data)
            PO_report_view.ReportViewer1.LocalReport.DataSources.Item(0).Value = view_po_print
            PO_report_view.ShowDialog()
            PO_report_view.Dispose()
            suplier_address = ""
        ElseIf i = 0 Then
            MsgBox("You don't have selected data")
        End If

    End Sub


    Public Sub PO_preview_report_bbc()
        unique_charge_all = ""
        Dim Po_data As New DataTable
        Dim values_charge_all_part2 As List(Of String) = New List(Of String)
        Dim i As Integer = 0
        With Po_data
            .Columns.Add("Description")
            .Columns.Add("Qty")
            .Columns.Add("Unit")
            .Columns.Add("UnitPrice")
            .Columns.Add("Amount")

        End With
        For Each row2 As DataGridViewRow In dgvPOList.Rows
            If row2.Cells(0).Value = True Then
                i = 1
                If row2.Cells(9).Value = "0.00" Then
                    'row2.Cells(9).Value = "-"
                    Dim zeros As String = "0"
                    Dim stringToInteger As Integer = Convert.ToInt32(zeros)
                    row2.Cells(9).Value = stringToInteger

                End If
                If row2.Cells(10).Value = "0.00" Then
                    'row2.Cells(10).Value = "-"
                    Dim zeros As String = "0"
                    Dim stringToInteger As Integer = Convert.ToInt32(zeros)
                    row2.Cells(10).Value = stringToInteger
                End If
                Po_data.Rows.Add(row2.Cells(4).Value, row2.Cells(7).Value,
                       row2.Cells(8).Value, row2.Cells(9).Value, row2.Cells(10).Value)
                supplier_po = row2.Cells(1).Value
                terms = row2.Cells(6).Value
                'charge_tos = row2.Cells(16).Value
                values_charge_all_part2.Add(row2.Cells(16).Value)

            End If

        Next
        'pag kuha sa all charge gikan grid
        Dim result2 As List(Of String) = values_charge_all_part2.Distinct().ToList
        For Each element2 As String In result2
            unique_charge_all = unique_charge_all + " / " + element2.ToString
        Next

        FPurchasedOrderList.all_charge_to = ""
        Dim iii = unique_charge_all.IndexOf("/")
        FPurchasedOrderList.all_charge_to = unique_charge_all.Substring(iii + 1)


        If i = 1 Then
            Dim view_po_print As New DataView(Po_data)
            PO_report_view_bbc.ReportViewer1.LocalReport.DataSources.Item(0).Value = view_po_print
            PO_report_view_bbc.ShowDialog()
            PO_report_view_bbc.Dispose()
            suplier_address = ""
        ElseIf i = 0 Then
            MsgBox("You don't have selected data")
        End If

    End Sub


    Public Sub PO_preview_report_jqg()
        unique_charge_all = ""
        Dim Po_data As New DataTable
        Dim values_charge_all_part2 As List(Of String) = New List(Of String)
        Dim i As Integer = 0
        With Po_data
            .Columns.Add("Description")
            .Columns.Add("Qty")
            .Columns.Add("Unit")
            .Columns.Add("UnitPrice")
            .Columns.Add("Amount")

        End With
        For Each row2 As DataGridViewRow In dgvPOList.Rows
            If row2.Cells(0).Value = True Then
                i = 1
                If row2.Cells(9).Value = "0.00" Then
                    'row2.Cells(9).Value = "-"
                    Dim zeros As String = "0"
                    Dim stringToInteger As Integer = Convert.ToInt32(zeros)
                    row2.Cells(9).Value = stringToInteger

                End If
                If row2.Cells(10).Value = "0.00" Then
                    'row2.Cells(10).Value = "-"
                    Dim zeros As String = "0"
                    Dim stringToInteger As Integer = Convert.ToInt32(zeros)
                    row2.Cells(10).Value = stringToInteger
                End If
                Po_data.Rows.Add(row2.Cells(4).Value, row2.Cells(7).Value,
                       row2.Cells(8).Value, row2.Cells(9).Value, row2.Cells(10).Value)
                supplier_po = row2.Cells(1).Value
                terms = row2.Cells(6).Value
                'charge_tos = row2.Cells(16).Value
                values_charge_all_part2.Add(row2.Cells(16).Value)

            End If

        Next
        'pag kuha sa all charge gikan grid
        Dim result2 As List(Of String) = values_charge_all_part2.Distinct().ToList
        For Each element2 As String In result2
            unique_charge_all = unique_charge_all + " / " + element2.ToString
        Next

        FPurchasedOrderList.all_charge_to = ""
        Dim iii = unique_charge_all.IndexOf("/")
        FPurchasedOrderList.all_charge_to = unique_charge_all.Substring(iii + 1)


        If i = 1 Then
            Dim view_po_print As New DataView(Po_data)
            PO_report_view_jqg.ReportViewer1.LocalReport.DataSources.Item(0).Value = view_po_print
            PO_report_view_jqg.ShowDialog()
            PO_report_view_jqg.Dispose()
            suplier_address = ""
        ElseIf i = 0 Then
            MsgBox("You don't have selected data")
        End If

    End Sub


    Private Sub btnProceedtoRR_Click(sender As Object, e As EventArgs) Handles btnProceedtoRR.Click

    End Sub

    Private Sub pboxHeader_Click(sender As Object, e As EventArgs) Handles pboxHeader.Click

    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub

    Private Sub dgvPOList_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvPOList.DataError
        e.Cancel = True
    End Sub
    Public Sub get_po_recommend()
        Try
            FMain.increment_po = ""
            'Dim d As Integer
            Dim poRecommendation As Integer
            For Each oRow As DataGridViewRow In dgvPOList.Rows
                'po_recomendataion1 = dgvPOList.Rows(d).Cells("Column4").Value
                poRecommendation = Utilities.ifBlankReplaceToZero(oRow.Cells("Column4").Value)
            Next

            'Dim stringToInteger1 As Int64 = Convert.ToInt64(po_recomendataion1)
            'stringToInteger1 = stringToInteger1 + 1
            'FMain.increment_po = stringToInteger1

            FMain.increment_po = poRecommendation + 1

            'MsgBox(stringToInteger1)
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Public Sub getdata_printing()
        Dim single_id_det As String
        Dim all_single_det As String
        Dim print_stat As String = "FOR PRINTING"
        Dim id_printing As String

        For Each drv As DataGridViewRow In dgvPOList.Rows
            If drv.Cells(0).Value = True Then
                single_id_det = single_id_det + "," + drv.Cells(11).Value
            End If
        Next
        all_single_det = single_id_det.Remove(0, 1)

        Dim newSQ As New SQLcon
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand
        Try
            newSQ.connection.Open()
            publicquery = "SELECT po_det_id FROM dbPO_details WHERE po_det_id IN (" + all_single_det + ") and print_status = '" & print_stat & "'"
            newcmd = New SqlCommand(publicquery, newSQ.connection)
            newdr = newcmd.ExecuteReader
            While newdr.Read
                id_printing = id_printing + "," + newdr.Item("po_det_id").ToString
            End While
            all_podet_id_for_print = id_printing.Remove(0, 1)
            '' MsgBox(all_podet_id_for_print)
            newdr.Close()
            newSQ.connection.Close()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub getdata_printed()
        Dim single_id_det As String
        Dim all_single_det As String
        Dim print_stat_done As String = "PRINTED"
        Dim id_printed As String

        For Each drv As DataGridViewRow In dgvPOList.Rows
            If drv.Cells(0).Value = True Then
                single_id_det = single_id_det + "," + drv.Cells(11).Value
            End If
        Next
        all_single_det = single_id_det.Remove(0, 1)
        Dim newSQ As New SQLcon
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand
        Try
            newSQ.connection.Open()
            publicquery = "SELECT po_det_id FROM dbPO_details WHERE po_det_id IN (" + all_single_det + ") and print_status = '" & print_stat_done & "'"
            newcmd = New SqlCommand(publicquery, newSQ.connection)
            newdr = newcmd.ExecuteReader
            While newdr.Read
                id_printed = id_printed + "," + newdr.Item("po_det_id").ToString
            End While
            all_podet_id_printed = id_printed.Remove(0, 1)
            '' MsgBox(all_podet_id_printed)
            newdr.Close()
            newSQ.connection.Close()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub update_if_for_print()
        Dim newSQ As New SQLcon
        Dim newcmd As SqlCommand
        Dim print_status = "PRINTED"
        Dim query2 As String = "UPDATE dbPO_details SET print_date_logs = GETDATE(), user_id_logs = '" & pub_user_id & "', print_status = '" + print_status + "' where po_det_id IN (" + all_podet_id_for_print + ")"

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

    Public Sub update_if_already_Printed()
        Dim newSQ As New SQLcon
        Dim newcmd As SqlCommand
        Dim query2 As String = "UPDATE dbPO_details SET up_prnt_dt_logs = GETDATE(), user_id_logs = '" & pub_user_id & "' where po_det_id IN (" + all_podet_id_printed + ")"

        Try
            newSQ.connection.Open()
            publicquery = query2
            newcmd = New SqlCommand(publicquery, newSQ.connection)
            newcmd.ExecuteNonQuery()
            '' MsgBox("UPDATED!")
            newSQ.connection.Close()
        Catch ex As Exception
            '' MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub CopyTermsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyTermsToolStripMenuItem.Click
        rowind = Format(get_datagrid_rowindex)
        term_day = dgvPOList.Rows(rowind).Cells("Column5").Value
    End Sub

    Private Sub PasteTermsByBatchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteTermsByBatchToolStripMenuItem.Click
        For Each row As DataGridViewRow In dgvPOList.Rows
            row.Cells("Column5").Value = term_day
        Next
    End Sub

    Public Sub getChargesType()
        Dim sql As New SQLcon
        Dim cmd As New SqlCommand
        Dim rsIdValue As Integer
        Dim finalrsid As Integer
        For Each row As DataGridViewRow In dgvPOList.Rows
            If row.Cells(0).Value = True Then
                rsIdValue = row.Cells("col_rs_id").Value.ToString()
            End If
        Next
        finalrsid = rsIdValue
        sql.connection.Open()
        Try
            cmd.Connection = sql.connection
            cmd.CommandText = "SELECT distinct type_name  FROM dbMultipleCharges 
                               WHERE rs_id = '" & finalrsid & "'"
            Using reader As SqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim result As String = reader.GetString(0)
                        lblRsID.Text = result
                    End While
                Else
                    MsgBox("No data found.")
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            sql.connection.Close()
        End Try
    End Sub

    Private Sub dgvPOList_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPOList.CellLeave

    End Sub

    Private Sub FPOFORM_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        isWithdrawal = False
    End Sub


    'NEW FUNCTIONS HERE
    Private Function checkWsExistInDr(wsNo As String, rs_id As Integer) As Boolean
        Try
            Dim c As New ColumnValuesObj

            Dim tableA As String = "dbDeliveryReport_info"
            Dim tableB As String = "dbDeliveryReport_items"

            Dim cc As New ColumnValuesObj
            Dim myAlias1 As String = "a"
            Dim myAlias2 As String = "b"
            Dim tnt As New tableNameType

            cc.addColumn($"{myAlias1}.dr_info_id")
            cc.setCondition($"{myAlias1}.ws_no = '{old_ws_no}' and {myAlias2}.rs_id = {rs_id}")
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

    Private Sub updateWsIfFoundInDr(wsNo As String, rsId As Integer)
        Try
            Dim c As New Model_King_Dynamic_Update()
            Dim cv As New ColumnValuesObj

            Dim tableA As String = "dbDeliveryReport_info"
            Dim tableB As String = "dbDeliveryReport_items"

            Dim joinClauses As New List(Of String)
            Dim condition As String = $"ws_no = '{old_ws_no}' and rs_id = {rsId}"

            joinClauses.Add($"LEFT JOIN {tableB} b ON b.dr_info_id = a.dr_info_id")
            cv.add("ws_no", wsNo)
            c.UpdateDataByTableJoin(tableA, cv.getValues(), condition, joinClauses)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub btnSave_Click_1(sender As Object, e As EventArgs) Handles btnSave.Click

    End Sub
End Class