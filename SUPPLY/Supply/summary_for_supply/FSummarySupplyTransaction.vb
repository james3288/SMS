Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Globalization
Imports Microsoft.Office.Interop
Imports System.Drawing

Public Class FSummarySupplyTransaction
    Public sqlcon As New SQLcon
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim n As Integer
    Dim IsFormBeingDragged As Boolean
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Dim datefrom As DateTime
    Dim dateto As DateTime
    Dim datefromLog As DateTime
    Dim datetoLog As DateTime
    Dim category As String
    Dim chargeTo As String

    Public rowind As Integer
    Dim datagridSummarySupplyID As Integer

    Dim list_project_desc As New List(Of List(Of String))
    Dim list_charge_description As New List(Of List(Of String))
    Dim list_charge_to As New List(Of List(Of String))
    Dim list_equipment_list As New List(Of List(Of String))
    Dim list_typeofequipments As New List(Of List(Of String))

    Private Sub FSummarySupplyTransaction_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.C Then
            For Each row As DataGridViewRow In dtgSummarySupply.SelectedRows
                dtgSummarySupply.Rows.Remove(row)
            Next
        End If
    End Sub

    Private Sub FSummarySupplyTransaction_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Label15.Parent = pboxHeader
        pboxHeader.Width = FMain.Width - FMain.ToolStrip1.Width
        'lvlreceivingreportlist.Location = New Point(1000, 1000)
        Label15.Parent = pboxHeader
        Label15.BringToFront()
        txtSearch.Visible = False
        cmbSearch1.Visible = True
        cmbSearch1.Location = New Point(txtSearch.Location.X, txtSearch.Location.Y)
        cmbSearch1.Width = txtSearch.Width
        panel_chargeTo.Location = New Point(444, 146)
        panel_daterange_req.Location = New Point(444, 146)
        ' viewsummarysupply_from_RequisitionSlip()

        'SearchSummarySupply()

        'Panel_date_duration.BringToFront()
        'Panel_date_duration.Location = New Point(480, 650)

        dtgSummarySupply.EnableHeadersVisualStyles = False

        'For i As Integer = 0 To dtgSummarySupply.RowCount - 1
        '    dtgSummarySupply.Columns(i).HeaderCell.Style.BackColor = Color.LightSteelBlue
        'Next
        load_charges()
        load_project_name()
    End Sub

    '#Region "search orig"
    '    '0 = rsID
    '    '1 = rsDate
    '    '2 = poDate
    '    '3 = wsDate
    '    '4 = qty
    '    '5 = unit
    '    '6 = item name
    '    '7 = description
    '    '8 = requestor
    '    '9 = poNo
    '    '10 = rsNO
    '    '11 = rrNo
    '    '12 = dateRR
    '    '13 = unitPrice
    '    '14 = amount
    '    '15 = charges
    '    '16 = leadtime rs to po
    '    '17 = leadtime po to rr
    '    '18 = supplier
    '    '19 = remarks
    '    '20 = typeofrequest
    '    '21 = dr/tr/or/invoice
    '    '22 = soNo
    '    '23 = hauler
    '    '24 = plateno
    '    '25 = status

    '    Public Sub viewsummarysupply_from_RequisitionSlip()
    '        dtgSummarySupply.Rows.Clear()
    '        ' Dim row As Integer
    '        Try
    '            sqlcon.connection.Open()
    '            publicquery = "SELECT * FROM dbrequisition_slip WHERE process IN ('ADFIL','WAREHOUSE','PERSONAL','CASH','PROJECT')"
    '            cmd = New SqlCommand(publicquery, sqlcon.connection)
    '            dr = cmd.ExecuteReader

    '            While dr.Read
    '                Dim a(30) As String

    '                a(0) = dr.Item("rs_id").ToString
    '                a(1) = Format(Date.Parse(dr.Item("date_req").ToString), "MM/dd/yyyy")

    '                'If check_if_exist("dbPO", "rs_no", dr.Item("rs_no").ToString, 0) > 0 Then
    '                '    a(2) = 
    '                'End If

    '                If dr.Item("type_of_purchasing").ToString = "PURCHASE ORDER" Then
    '                    a(2) = get_po_details(dr.Item("rs_id").ToString, 1) 'get po date
    '                    a(3) = "-"
    '                    a(12) = get_rr_details(dr.Item("rs_id").ToString, 1) ' get rr date

    '                ElseIf dr.Item("type_of_purchasing").ToString = "CASH" Then
    '                    a(2) = get_cv_date(dr.Item("rs_no").ToString, 1)
    '                    a(3) = "-"
    '                    a(12) = get_rr_details(dr.Item("rs_id").ToString, 1)

    '                ElseIf dr.Item("type_of_purchasing").ToString = "WITHDRAWAL" Then
    '                    a(2) = "-"
    '                    a(3) = get_withdrawal_infos(dr.Item("rs_id").ToString, 1)

    '                End If

    '                a(4) = dr.Item("qty").ToString
    '                a(5) = dr.Item("unit").ToString

    '                If dr.Item("typeRequest").ToString = "BORROWER" Then
    '                    a(6) = get_itemName_facilities(dr.Item("wh_id").ToString)
    '                Else
    '                    a(6) = get_info_warehouse(dr.Item("wh_id").ToString, 1)
    '                End If

    '                a(7) = dr.Item("item_desc").ToString
    '                a(8) = dr.Item("requested_by").ToString
    '                a(10) = dr.Item("rs_no").ToString
    '                a(11) = get_rr_details(dr.Item("rs_id").ToString, 2) ' get rr no


    '                Dim process As String = dr.Item("process").ToString
    '                charge_to_id = dr.Item("charge_to").ToString

    '                Select Case process
    '                    Case "EQUIPMENT"
    '                        a(15) = GET_equip_desc_AND_proj_desc(charge_to_id, 1)
    '                    Case "PROJECT"
    '                        a(15) = GET_equip_desc_AND_proj_desc(charge_to_id, 2)
    '                    Case "WAREHOUSE"
    '                        a(15) = GET_equip_desc_AND_proj_desc(charge_to_id, 4)
    '                    Case "PERSONAL"
    '                        a(15) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
    '                    Case "CASH"
    '                        a(15) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
    '                    Case "ADFIL"
    '                        a(15) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
    '                End Select

    '                If check_if_exist("dbPO", "rs_no", dr.Item("rs_no").ToString, 0) > 0 Then
    '                    Dim rsdate As DateTime = a(1)
    '                    Dim poDate As DateTime = a(2)
    '                    a(9) = get_po_details(dr.Item("rs_id").ToString, 2) 'get po no
    '                    a(13) = FormatNumber(get_po_details(dr.Item("rs_id").ToString, 3), 2, , , TriState.True) 'get the unit price
    '                    a(14) = FormatNumber(get_po_details(dr.Item("rs_id").ToString, 4), 2, , , TriState.True) 'get the amount
    '                    a(16) = DateDiff(DateInterval.Day, rsdate, poDate)
    '                Else
    '                    Dim rsdate As DateTime = a(1)
    '                    Dim poDate As DateTime = a(2)
    '                    a(9) = "Cash"
    '                    a(13) = FormatNumber(get_data_from_dbCashVoucher_items(dr.Item("rs_id").ToString), 2, , , TriState.True)
    '                    a(14) = FormatNumber(a(4) * a(13), 2, , , TriState.True)
    '                    a(16) = DateDiff(DateInterval.Day, rsdate, poDate)
    '                End If

    '                If check_if_exist("dbreceiving_info", "rs_no", dr.Item("rs_no").ToString, 0) > 0 Then
    '                    Dim poDate As DateTime = a(2)
    '                    Dim dateRR As DateTime = a(12)
    '                    a(17) = DateDiff(DateInterval.Day, poDate, dateRR)
    '                    a(18) = get_rr_details(dr.Item("rs_id").ToString, 4) ' get supplier name
    '                Else
    '                    a(18) = get_po_details(dr.Item("rs_id").ToString, 5) 'get supplier name
    '                End If

    '                a(19) = dr.Item("remarks").ToString
    '                a(20) = dr.Item("typeRequest").ToString
    '                a(21) = get_rr_details(dr.Item("rs_id").ToString, 3)
    '                a(22) = get_rr_details(dr.Item("rs_id").ToString, 5)
    '                a(23) = get_rr_details(dr.Item("rs_id").ToString, 6)
    '                a(24) = get_rr_details(dr.Item("rs_id").ToString, 7)
    '                a(26) = dr.Item("type_of_purchasing").ToString

    '                If (a(19) IsNot Nothing AndAlso a(19).Count > 0) Then
    '                    a(25) = "Completed"
    '                Else

    '                End If

    '                dtgSummarySupply.Rows.Add(a)

    '                For Each rw As DataGridViewRow In dtgSummarySupply.Rows
    '                    If rw.Cells(26).Value.ToString = "CASH" Then
    '                        rw.DefaultCellStyle.BackColor = Color.LightGreen
    '                    ElseIf rw.Cells(26).Value.ToString = "PURCHASE ORDER" Then
    '                        rw.DefaultCellStyle.BackColor = Color.LightBlue
    '                    End If
    '                    'If dr.Item("type_of_purchasing").ToString = "CASH" Then
    '                    '    MsgBox("pink")
    '                    'ElseIf dr.Item("type_of_purchasing").ToString = "PURCHASE ORDER" Then
    '                    '    rw.DefaultCellStyle.BackColor = Color.LightSteelBlue
    '                    'End If
    '                Next


    '            End While
    '            dr.Close()

    '        Catch ex As Exception
    '            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Finally
    '            sqlcon.connection.Close()
    '        End Try
    '    End Sub
    '#End Region

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub
    Public Function multi_charges_counter(ByVal rs_no As String)
        Dim sqlcon1 As New SQLcon
        Dim newcmd As SqlCommand
        Dim newDR As SqlDataReader

        Try
            sqlcon1.connection.Open()

            newcmd = New SqlCommand("proc_search_summarySupply", sqlcon1.connection)
            newcmd.Parameters.Clear()
            newcmd.CommandType = CommandType.StoredProcedure

            newcmd.Parameters.AddWithValue("@n", 111)
            newcmd.Parameters.AddWithValue("@searchby", rs_no)

            newDR = newcmd.ExecuteReader

            If newDR.HasRows Then
                While newDR.Read
                    multi_charges_counter = CInt(newDR.Item("CountProj").ToString)
                End While
            End If

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon1.connection.Close()
        End Try
    End Function

    Public Function multiplecharges_det(ByVal rs_id As Integer) As String

        multiplecharges_det = "ADFIL"
        Dim mcharges As String = get_multiple_charges(rs_id)

        If mcharges.Length < 1 Then
        Else
            mcharges = mcharges.Trim().Substring(0, mcharges.Length - 1)
            multiplecharges_det = multiplecharges_det & "(" & UCase(mcharges) & ")"
        End If

    End Function
    Public Sub Summary_of_supply()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_search_summarySupply", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 55)

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

    Public Function SearchSummarySupply()
        dtgSummarySupply.Rows.Clear()
        Dim det_error As String
        Try
            sqlcon.connection.Open()
            Dim newdr As SqlDataReader
            Dim cmd As SqlCommand

            cmd = New SqlCommand("proc_search_summarySupply", sqlcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@n", 55)
            cmd.Parameters.AddWithValue("@searchby", txtSearch.Text)

            newdr = cmd.ExecuteReader

            While newdr.Read
                Dim type_of_purchasing As String = newdr.Item("type_of_purchasing").ToString
                Dim a(35) As String
                Dim type_name As String = newdr.Item("type_name").ToString
                Dim charge_name As String = ""
                Dim rs_id As Integer = CInt(newdr.Item("rs_id").ToString)
                Dim po_exist As Integer = check_if_exist("dbPO_details", "rs_id", newdr.Item("rs_id").ToString, 1)
                Dim cv_exist As Integer = check_if_exist("dbCashVoucher_items", "rs_id", newdr.Item("rs_id").ToString, 1)
                Dim ws_exist As Integer = check_if_exist("dbwithdrawal_items", "rs_id", newdr.Item("rs_id").ToString, 1)
                Dim rr_item_exist As Integer = check_if_exist("dbreceiving_items", "rs_id", newdr.Item("rs_id").ToString, 1)

                Dim date_req As DateTime = Format(Date.Parse(newdr.Item("date_req").ToString), "MM/dd/yyyy")
                Dim unit As String = newdr.Item("unit").ToString
                Dim count As Integer = CInt(multi_charges_counter(newdr.Item("rs_no").ToString))
                Dim qty As Double = CDbl(newdr.Item("qty").ToString)

                Dim unit_amount As Double = get_po_details(rs_id, 3)
                Dim item_name As String = newdr.Item("whItem").ToString & " ( " & newdr.Item("whItemDesc").ToString & ")" ' newdr.Item("ITEM_NAME").ToString
                'Dim item_desc_from_rr As String = newdr.Item("ITEM_DESC_FROM_RR").ToString
                Dim requested_by As String = newdr.Item("requested_by").ToString
                Dim rs_no As String = newdr.Item("RS_NO").ToString
                Dim rr_item_id As String = get_item_id("dbreceiving_items", "rs_id", newdr.Item("rs_id").ToString)
                Dim type_of_request As String = newdr.Item("typeRequest").ToString
                Dim remarks_status As String = newdr.Item("remarks_status").ToString
                ' Dim tor_sub_desc As String = newdr.Item("tor_sub_desc").ToString
                'Dim in_out_desc As String = newdr.Item("in_out_desc").ToString
                'MessageBox.Show("this : " & type_of_purchasing)
                'MessageBox.Show("item_id : " & rr_item_id)
                ' If newdr.Item("UNIT_AMOUNT").ToString = "" Then : unit_amount = 0 : Else : unit_amount = newdr.Item("UNIT_AMOUNT").ToString : End If

                Dim wh_id As Integer = newdr.Item("wh_id").ToString

                ' -------- get charges ----------
                If type_name = "EQUIPMENT" Then
                    charge_name = GET_equip_desc_AND_proj_desc(newdr.Item("all_charges_id").ToString, 1)

                ElseIf type_name = "PROJECT" Then
                    charge_name = GET_equip_desc_AND_proj_desc(newdr.Item("all_charges_id").ToString, 2)

                ElseIf type_name = "MAINOFFICE" Or type_name = "PERSONAL" Or type_name = "OTHERS" Then
                    charge_name = GET_equip_desc_AND_proj_desc(newdr.Item("all_charges_id").ToString, 3)

                End If
                'charge_name = FReceivingReport.multiplecharges(dr.Item("rs_id").ToString)
                '-------end get charges ----------
                If item_name = " ( )" Then
                    item_name = newdr.Item("subtitute_name").ToString

                End If
                a(0) = rs_id
                a(1) = date_req
                a(4) = FormatNumber(qty / count, 0, , , TriState.True)
                a(5) = unit
                a(6) = item_name

                a(8) = requested_by
                a(10) = rs_no
                a(13) = "-" 'FormatNumber(unit_amount, 2, , TriState.True)
                a(14) = IIf(get_all_rr_info_using_rs_id(rs_id, 4) = "", 0, get_all_rr_info_using_rs_id(rs_id, 4)) 'FormatNumber(CDbl(unit_amount) * CDbl(a(4)), 2, , TriState.True)
                a(14) = FormatNumber(CDbl(a(14)) / count, 2, , , TriState.True)
                a(15) = UCase(charge_name)

                a(19) = remarks_status
                a(21) = get_rr_details(rs_id, 3)
                a(22) = get_rr_details(rs_id, 5)
                a(23) = get_rr_details(rs_id, 6)
                a(24) = get_rr_details(rs_id, 7)
                'a(20) = type_of_request & " - " & tor_sub_desc & "(" & in_out_desc & ")"
                a(26) = type_of_purchasing

                Select Case type_of_purchasing
                    Case "PURCHASE ORDER", "CASH", "WITHDRAWAL"
                        Dim po_cv_date As String = get_multiple_po_no_po_date(rs_id, 2)
                        Dim rr_date As DateTime
                        Dim po_no As String = get_multiple_po_no_po_date(rs_id, 1)

                        a(3) = "-"
                        If type_of_purchasing = "PURCHASE ORDER" Then
                            a(2) = "PO DATE: " & get_multiple_po_no_po_date(rs_id, 2)
                            a(7) = IIf(get_all_rr_info_using_rs_id(rs_id, 3) = "", 0, get_all_rr_info_using_rs_id(rs_id, 3)) / count  'item_desc_from_rr
                            a(7) = FormatNumber(a(7), 0, , , TriState.True)
                            a(9) = "PO NO: " & IIf(po_no = "", "PENDING", po_no)
                            a(16) = po(date_req, get_multiple_po_no_po_date(rs_id, 2))
                            'a(28) = po(date_req, get_multiple_po_no_po_date(rs_id, 2))

                        ElseIf type_of_purchasing = "CASH" Then
                            a(2) = "CV DATE: " & get_multiple_po_no_po_date(rs_id, 2)
                            a(7) = IIf(get_all_rr_info_using_rs_id(rs_id, 3) = "", 0, get_all_rr_info_using_rs_id(rs_id, 3)) / count  'item_desc_from_rr
                            a(7) = FormatNumber(a(7), 0, , , TriState.True)
                            a(9) = "CV NO: " & IIf(po_no = "", "PENDING", po_no)
                        ElseIf type_of_purchasing = "WITHDRAWAL" Then
                            a(2) = "WS DATE: " & get_multiple_po_no_po_date(rs_id, 2)

                            a(7) = IIf(get_all_rr_info_using_rs_id(rs_id, 5) = "", 0, get_all_rr_info_using_rs_id(rs_id, 5)) / count  'item_desc_from_rr
                            a(7) = FormatNumber(a(7), 0, , , TriState.True)
                            a(9) = "WS NO: " & IIf(po_no = "", "PENDING", po_no)
                            'a(27) = po(date_req, get_multiple_po_no_po_date(rs_id, 2))

                        End If

                        a(11) = remove_last_character(get_all_rr_info_using_rs_id(rs_id, 1)) ' newdr.Item("RR_NO").ToString
                        a(12) = "DATE OF RR: " & remove_last_character(get_all_rr_info_using_rs_id(rs_id, 2)) '"DATE OF RR: " & IIf(rr_date = Date.Parse("1991-01-01"), "PENDING", rr_date)
                        'a(16) = lead_time_rs_to_po(rs_id, date_req)

                        a(18) = get_po_details(newdr.Item("rs_id").ToString, 5)
                        a(31) = termsFunction(a(18), get_po_details(newdr.Item("rs_id").ToString, 6), get_all_rr_info_using_rs_id(rs_id, 2))

                        a(17) = proccess1(get_multiple_po_no_po_date(rs_id, 2), remove_last_character(get_all_rr_info_using_rs_id(rs_id, 2)))
                        'a(29) = proccess1(get_multiple_po_no_po_date(rs_id, 2), remove_last_character(get_all_rr_info_using_rs_id(rs_id, 2)))

                        a(30) = proccess2(date_req, remove_last_character(get_all_rr_info_using_rs_id(rs_id, 2)))

                        If po_exist > 0 And a(7) = 0 Then
                            If newdr.Item("IN_OUT").ToString = "IN" Or newdr.Item("IN_OUT").ToString = "OTHERS" Then
                                a(25) = "WAITING FOR RR"
                            ElseIf newdr.Item("IN_OUT").ToString = "OUT" Then
                                a(25) = "WAITING FOR WS"
                            End If

                        ElseIf po_exist = 0 And a(7) = 0 Then
                            If newdr.Item("IN_OUT").ToString = "IN" Or newdr.Item("IN_OUT").ToString = "OTHERS" Then
                                a(25) = "WAITING FOR PO AND RR"
                            ElseIf newdr.Item("IN_OUT").ToString = "OUT" Then
                                a(25) = "WAITING FOR WS"
                            End If

                        ElseIf po_exist > 0 And a(7) > 0 Then

                            If CDbl(a(4)) > CDbl(a(7)) Then
                                a(25) = "PARTIALLY COMPLETED"
                            Else
                                a(25) = "COMPLETED"
                            End If

                        End If

                    Case "WITHDRAWAL"


                        a(18) = "n/a"
                        a(21) = "none"
                        a(22) = "none"
                        a(23) = "n/a"
                        a(24) = "n/a"


                End Select

                If cmbSearch.Text = "CHARGES" Then
                    If search_by(a(15), txtSearch.Text) = True Then
                    Else
                        GoTo proceedhere
                    End If
                ElseIf cmbSearch.Text = "R.S. NO" Then
                    If search_by(a(10), txtSearch.Text) = True Then
                    Else
                        GoTo proceedhere
                    End If
                ElseIf cmbSearch.Text = "P.O. NO" Then
                    If search_by(a(9), txtSearch.Text) = True Then
                    Else
                        GoTo proceedhere
                    End If
                ElseIf cmbSearch.Text = "R.R. NO" Then
                    If search_by(a(11), txtSearch.Text) = True Then
                    Else
                        GoTo proceedhere
                    End If
                ElseIf cmbSearch.Text = "ITEM NAME" Then
                    If search_by(a(6), txtSearch.Text) = True Then
                    Else
                        GoTo proceedhere
                    End If
                ElseIf cmbSearch.Text = "ITEM DESCRIPTION" Then
                    If search_by(a(7), txtSearch.Text) = True Then
                    Else
                        GoTo proceedhere
                    End If
                ElseIf cmbSearch.Text = "TYPE" Then
                    If search_by(a(26), cmbSearch1.Text) = True Then
                    Else
                        GoTo proceedhere
                    End If
                ElseIf cmbSearch.Text = "STATUS" Then
                    If search_by(a(25), txtSearch.Text) = True Then
                    Else
                        GoTo proceedhere
                    End If
                End If


                dtgSummarySupply.Rows.Add(a)
                If rr_item_id <> "" Then
                    'sqlcon.connection.Close()
                    load_sub(rs_no, rr_item_id, rs_id)
                End If



proceedhere:
            End While
            For Each rw As DataGridViewRow In dtgSummarySupply.Rows
                If rw.Cells(26).Value.ToString = "CASH" Then
                    rw.DefaultCellStyle.BackColor = Color.LightBlue
                ElseIf rw.Cells(26).Value.ToString = "PURCHASE ORDER" Then
                    rw.DefaultCellStyle.BackColor = Color.Green
                ElseIf rw.Cells(26).Value.ToString = "WITHDRAWAL" Then
                    rw.DefaultCellStyle.BackColor = Color.Orange
                ElseIf rw.Cells(26).Value.ToString = "" And rw.Cells(1).Value.ToString <> "" Then
                    rw.DefaultCellStyle.BackColor = Color.White
                End If
                ' MsgBox(rw.Cells(1).Value.ToString)
            Next
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & "error: " & det_error & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try

    End Function


    Public Function lead_time_rs_to_po(rs_id As Integer, rs_date As DateTime)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        lead_time_rs_to_po = ""

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_search_summarySupply", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 16)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                lead_time_rs_to_po &= day_and_days(IIf(DateDiff(DateInterval.Day, rs_date, Date.Parse(newDR.Item("po_date").ToString)) < 0, 0, DateDiff(DateInterval.Day, rs_date, Date.Parse(newDR.Item("po_date").ToString)))) & ","
            End While
            newDR.Close()

            lead_time_rs_to_po = remove_last_character(lead_time_rs_to_po)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Public Function get_multiple_po_no_po_date(rs_id As Integer, m As Integer) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        get_multiple_po_no_po_date = ""

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_search_summarySupply", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 16)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                If m = 1 Then
                    get_multiple_po_no_po_date &= newDR.Item("po_no").ToString & ","
                ElseIf m = 2 Then
                    get_multiple_po_no_po_date &= Format(Date.Parse(newDR.Item("po_date").ToString), "MM/dd/yyyy") & ","
                End If

            End While
            newDR.Close()

            get_multiple_po_no_po_date = remove_last_character(get_multiple_po_no_po_date)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function

    Public Function get_all_rr_info_using_rs_id(rs_id As Integer, n As Integer) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        get_all_rr_info_using_rs_id = ""
        Dim qty_received As Integer
        Dim amount As Double

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_search_summarySupply", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            If n = 1 Then
                newCMD.Parameters.AddWithValue("@n", 9)
            ElseIf n = 2 Then
                newCMD.Parameters.AddWithValue("@n", 10)
            ElseIf n = 3 Then
                newCMD.Parameters.AddWithValue("@n", 14)
            ElseIf n = 4 Then
                newCMD.Parameters.AddWithValue("@n", 15)
            ElseIf n = 5 Then
                newCMD.Parameters.AddWithValue("@n", 17)
            End If

            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read

                If n = 1 Then
                    get_all_rr_info_using_rs_id &= newDR.Item("rr_no").ToString & ","
                ElseIf n = 2 Then
                    get_all_rr_info_using_rs_id &= Format(Date.Parse(newDR.Item("date_received").ToString), "MM/dd/yyyy") & ","
                ElseIf n = 3 Then
                    qty_received += CInt(newDR.Item("desired_qty").ToString)
                    get_all_rr_info_using_rs_id = qty_received
                ElseIf n = 4 Then
                    amount += CDbl(newDR.Item("amount").ToString) * CInt(newDR.Item("desired_qty").ToString)
                    get_all_rr_info_using_rs_id = amount
                ElseIf n = 5 Then
                    qty_received += CDec(newDR.Item("qty").ToString)
                    get_all_rr_info_using_rs_id = qty_received
                End If

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function

    Public Function day_and_days(ByVal value As Integer) As String
        If value > 1 Then
            day_and_days = value & " days"
        ElseIf value <= 1 Then
            day_and_days = value & " day"
        End If
    End Function
    Public Function if_exist_on_string(ByVal value As String, ByVal search As String) As Boolean
        If UCase(value) Like "*" & UCase(search) & "*" Then
            if_exist_on_string = True
        Else
            if_exist_on_string = False
        End If
    End Function
    Public Function get_true_false_dbPO_details(ByVal id As Integer)
        Dim newsqlcon As New SQLcon
        Dim newcmd As SqlCommand
        Dim newsqldr As SqlDataReader

        Try
            newsqlcon.connection.Open()
            publicquery = "SELECT selected FROM dbPO_details WHERE rs_id = '" & id & "'"
            newcmd = New SqlCommand(publicquery, newsqlcon.connection)
            newsqldr = newcmd.ExecuteReader

            While newsqldr.Read
                get_true_false_dbPO_details = newsqldr.Item("selected").ToString
            End While
            newsqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
        End Try


    End Function

    Public Function get_data_from_dbPODetails(ByVal rsID As Integer, ByVal poNO As String, ByVal whID As Integer)

        Dim newsqlcon As New SQLcon
        Dim newcmd As SqlCommand
        Dim newsqldr As SqlDataReader

        Try
            newsqlcon.connection.Open()

            publicquery = "SELECT * FROM dbPO_details WHERE rs_id = '" & rsID & "' AND po_no = '" & poNO & "' AND wh_id = '" & whID & "'"
            newcmd = New SqlCommand(publicquery, newsqlcon.connection)
            newsqldr = newcmd.ExecuteReader

            While newsqldr.Read
                get_data_from_dbPODetails = newsqldr.Item("unit_price").ToString
            End While
            newsqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
        End Try
    End Function

    Public Function get_data_from_dbCashVoucher_items(ByVal rsID As Integer)
        Dim newsqlcon As New SQLcon
        Dim newcmd As SqlCommand
        Dim newsqldr As SqlDataReader

        Try
            newsqlcon.connection.Open()

            publicquery = "SELECT * FROM dbCashVoucher_items WHERE rs_id = '" & rsID & "' "
            newcmd = New SqlCommand(publicquery, newsqlcon.connection)
            newsqldr = newcmd.ExecuteReader

            While newsqldr.Read
                get_data_from_dbCashVoucher_items = newsqldr.Item("cv_amount").ToString
            End While
            newsqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
        End Try
    End Function

    Public Function get_po_details(ByVal id As Integer, ByVal n As Integer)
        Dim newsqlcon As New SQLcon
        Dim newcmd As SqlCommand
        Dim newsqldr As SqlDataReader

        Try
            newsqlcon.connection.Open()

            publicquery = "SELECT a.po_date, b.po_no, b.unit_price, b.amount, c.Supplier_Name, c.terms FROM dbPO a INNER JOIN dbPO_details b ON a.po_id = b.po_id INNER JOIN dbSupplier c ON b.supplier_id = c.Supplier_Id WHERE rs_id = '" & id & "' "
            newcmd = New SqlCommand(publicquery, newsqlcon.connection)
            newsqldr = newcmd.ExecuteReader

            While newsqldr.Read
                If n = 1 Then
                    get_po_details = Format(Date.Parse(newsqldr.Item("po_date").ToString), "MM/dd/yyyy")
                ElseIf n = 2 Then
                    get_po_details = newsqldr.Item("po_no").ToString
                ElseIf n = 3 Then
                    get_po_details = newsqldr.Item("unit_price").ToString
                ElseIf n = 4 Then
                    get_po_details = FormatNumber(newsqldr.Item("amount").ToString)
                ElseIf n = 5 Then
                    get_po_details = newsqldr.Item("Supplier_Name").ToString
                ElseIf n = 6 Then
                    get_po_details = newsqldr.Item("terms").ToString
                End If

            End While
            newsqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
        End Try
    End Function

    Public Function get_cv_date(ByVal id As Integer, ByVal n As Integer)
        Dim newsqlcon As New SQLcon
        Dim newcmd As SqlCommand
        Dim newsqldr As SqlDataReader

        Try
            newsqlcon.connection.Open()

            publicquery = "SELECT * FROM dbCashVoucher_info WHERE rs_no = '" & id & "' "
            newcmd = New SqlCommand(publicquery, newsqlcon.connection)
            newsqldr = newcmd.ExecuteReader

            While newsqldr.Read
                If n = 1 Then
                    get_cv_date = Format(Date.Parse(newsqldr.Item("cv_date").ToString), "MM/dd/yyyy")
                ElseIf n = 2 Then
                    get_cv_date = newsqldr.Item("cv_no").ToString()
                End If


            End While
            newsqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
        End Try
    End Function

    Public Function get_withdrawal_infos(ByVal id As Integer, ByVal n As Integer)
        Dim newsqlcon As New SQLcon
        Dim newcmd As SqlCommand
        Dim newsqldr As SqlDataReader

        Try
            newsqlcon.connection.Open()

            publicquery = "SELECT a.rs_id, a.ws_no, b.date_withdraw, b.withdraw_from FROM dbwithdrawal_items a INNER JOIN dbwithdrawal_info b ON  a.ws_info_id = b.ws_info_id WHERE rs_id = '" & id & "'  "
            newcmd = New SqlCommand(publicquery, newsqlcon.connection)
            newsqldr = newcmd.ExecuteReader

            While newsqldr.Read
                If n = 1 Then
                    get_withdrawal_infos = Format(Date.Parse(newsqldr.Item("date_withdraw").ToString), "MM/dd/yyyy")
                ElseIf n = 2 Then
                    get_withdrawal_infos = newsqldr.Item("ws_no").ToString
                ElseIf n = 3 Then
                    get_withdrawal_infos = newsqldr.Item("withdraw_from").ToString
                End If
            End While
            newsqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
        End Try
    End Function

    Public Function get_rr_details(ByVal id As Integer, ByVal n As Integer)
        Dim newsqlcon As New SQLcon
        Dim newcmd As SqlCommand
        Dim newsqldr As SqlDataReader

        Try
            newsqlcon.connection.Open()

            publicquery = "SELECT a.date_received, a.rr_no, a.invoice_no, a.supplier_id, a.so_no, a.hauler, a.plateno, b.item_description "
            publicquery &= "FROM dbreceiving_info a INNER JOIN dbreceiving_items b ON a.rr_info_id = b.rr_info_id WHERE b.rs_id = " & id
            newcmd = New SqlCommand(publicquery, newsqlcon.connection)
            newsqldr = newcmd.ExecuteReader

            While newsqldr.Read

                If n = 1 Then
                    get_rr_details = Format(Date.Parse(newsqldr.Item("date_received").ToString), "MM/dd/yyyy")
                ElseIf n = 2 Then
                    get_rr_details = newsqldr.Item("rr_no").ToString
                ElseIf n = 3 Then
                    get_rr_details = newsqldr.Item("invoice_no").ToString
                ElseIf n = 4 Then
                    get_rr_details = newsqldr.Item("supplier").ToString
                ElseIf n = 5 Then
                    get_rr_details = newsqldr.Item("so_no").ToString
                ElseIf n = 6 Then
                    get_rr_details = newsqldr.Item("hauler").ToString
                ElseIf n = 7 Then
                    get_rr_details = newsqldr.Item("plateno").ToString
                ElseIf n = 8 Then
                    get_rr_details = newsqldr.Item("item_description").ToString
                End If

            End While
            newsqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
        End Try

    End Function

    Private Sub FSummarySupplyTransaction_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        dtgSummarySupply.Height = Me.Height - 110
        dtgSummarySupply.Width = Me.Width - 30
        btnExit.Location = New Point(dtgSummarySupply.Width + 1, 10)
        gboxSearch.Location = New Point(dtgSummarySupply.Location.X, dtgSummarySupply.Bounds.Bottom)
        btnRefresh.Location = New Point(dtgSummarySupply.Location.Y + dtgSummarySupply.Width - 125, dtgSummarySupply.Bounds.Bottom)

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

    Public Function get_itemName_facilities(ByVal id As Integer)
        Dim newsqlcon As New SQLcon
        Dim newcmd As SqlCommand
        Dim newsqldr As SqlDataReader

        Try
            newsqlcon.connection.Open()
            publicquery = "SELECT brand FROM dbfacilities_list WHERE fac_id = '" & id & "'"
            newcmd = New SqlCommand(publicquery, newsqlcon.connection)
            newsqldr = newcmd.ExecuteReader

            While newsqldr.Read
                get_itemName_facilities = newsqldr.Item("brand").ToString
            End While
            newsqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
        End Try
    End Function

    Public Function get_info_warehouse(ByVal id As Integer, ByVal n As Integer)
        Dim newsqlcon As New SQLcon
        Dim newsqldr As SqlDataReader
        Dim newcmd As SqlCommand

        Try
            newsqlcon.connection.Open()
            publicquery = "SELECT whItem, default_price, whItemDesc FROM dbwarehouse_items WHERE wh_id = '" & id & "' "
            newcmd = New SqlCommand(publicquery, newsqlcon.connection)
            newsqldr = newcmd.ExecuteReader

            While newsqldr.Read
                If n = 1 Then
                    get_info_warehouse = newsqldr.Item("whItem").ToString
                ElseIf n = 2 Then
                    get_info_warehouse = newsqldr.Item("default_price").ToString
                ElseIf n = 3 Then
                    get_info_warehouse = newsqldr.Item("whItemDesc").ToString
                End If

            End While
            newsqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
        End Try

    End Function

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click

        'receiving_n = 2
        'po_no = lvlsummarysupply.SelectedItems(0).SubItems(8).Text
        'rs_no = lvlsummarysupply.SelectedItems(0).SubItems(9).Text
        'receiving_inout = get_InOut(rs_no)
        'FReceivingReport.txtPOno.Text = lvlsummarysupply.SelectedItems(0).SubItems(8).Text
        'FReceivingReport.ShowDialog()


    End Sub

    Private Sub cms_FRecvngReportLst_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cms_FRecvngReportLst.Opening
        If dtgSummarySupply.Rows.Count > 0 Then
            cms_FRecvngReportLst.Enabled = True
        Else
            cms_FRecvngReportLst.Enabled = False
        End If
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
    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click

        Dim msg = MessageBox.Show("Are you sure yOu want to delete the data?...", "EUS INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Error)

        If msg = Windows.Forms.DialogResult.Yes Then
        Else
            Return
        End If

    End Sub
    Public Function get_datagrid_rowindex() As Integer
        For i As Integer = 0 To Me.dtgSummarySupply.SelectedCells.Count - 1
            get_datagrid_rowindex = Me.dtgSummarySupply.SelectedCells.Item(i).RowIndex
        Next
    End Function
    Private Sub dtgSummarySupply_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dtgSummarySupply.CellBeginEdit

        If dtgSummarySupply.Rows(Format(get_datagrid_rowindex)).Cells(1).Value = "" Then
            dtgSummarySupply.Rows(Format(get_datagrid_rowindex)).Cells(1).Value = ""
        Else
            datagridSummarySupplyID = CStr(dtgSummarySupply.Rows(Format(get_datagrid_rowindex)).Cells(1).Value)
            rowind = Format(get_datagrid_rowindex)
        End If

    End Sub
    Private Sub dtgSummarySupply_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgSummarySupply.CellEndEdit

        If dtgSummarySupply.Rows(Format(rowind)).Cells(4).Value <> Nothing Then
            sqlcon.connection.Open()
            Dim query As String = "UPDATE dbreceiving_items SET remarks ='" & dtgSummarySupply.Rows(Format(rowind)).Cells(21).Value & "' WHERE rr_item_id = '" & dtgSummarySupply.Rows(Format(rowind)).Cells(4).Value & "'"
            cmd = New SqlCommand(query, sqlcon.connection)
            cmd.ExecuteNonQuery()
            sqlcon.connection.Close()
        Else
            sqlcon.connection.Open()
            Dim query As String = "UPDATE dbrequisition_slip SET remarks_status ='" & dtgSummarySupply.Rows(Format(rowind)).Cells(21).Value & "' WHERE rs_id = '" & datagridSummarySupplyID & "'"
            cmd = New SqlCommand(query, sqlcon.connection)
            cmd.ExecuteNonQuery()
            sqlcon.connection.Close()
        End If

        'If cmbSearch.Text = "PENDING REQUEST" Then
        '    sqlcon.connection.Open()
        '    Dim query As String = "UPDATE dbrequisition_slip SET remarks_status ='" & dtgSummarySupply.Rows(Format(rowind)).Cells(21).Value & "' WHERE rs_id = '" & datagridSummarySupplyID & "'"
        '    'Dim query As String = "UPDATE dbreceiving_items SET remarks ='" & dtgSummarySupply.Rows(Format(rowind)).Cells(19).Value & "' WHERE rr_info_id = '" & dtgSummarySupply.Rows(Format(rowind)).Cells(3).Value & "'"
        '    cmd = New SqlCommand(query, sqlcon.connection)
        '    cmd.ExecuteNonQuery()
        '    sqlcon.connection.Close()
        'Else
        '    sqlcon.connection.Open()
        '    'Dim query As String = "UPDATE dbrequisition_slip SET remarks_status ='" & dtgSummarySupply.Rows(Format(rowind)).Cells(19).Value & "' WHERE rs_id = '" & datagridSummarySupplyID & "'"
        '    Dim query As String = "UPDATE dbreceiving_items SET remarks ='" & dtgSummarySupply.Rows(Format(rowind)).Cells(21).Value & "' WHERE rr_item_id = '" & dtgSummarySupply.Rows(Format(rowind)).Cells(4).Value & "'"
        '    cmd = New SqlCommand(query, sqlcon.connection)
        '    cmd.ExecuteNonQuery()
        '    sqlcon.connection.Close()
        'End If

        If dtgSummarySupply.Rows(Format(rowind)).Cells(21).Value = "" Then
            dtgSummarySupply.Rows(Format(rowind)).Cells(27).Value = ""
        Else
            dtgSummarySupply.Rows(Format(rowind)).Cells(27).Value = "COMPLETED"
        End If

    End Sub
    Private Sub dtgSummarySupply_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgSummarySupply.CellEnter
        dtgSummarySupply.EditMode = DataGridViewEditMode.EditOnEnter
    End Sub
    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click

        If cmbSearch.Text = "DATE REQUEST" Then
            SummarySupply(1, "")
        ElseIf cmbSearch.Text = "REQUEST TYPE" Then
            SummarySupply(2, cmbSearch1.Text)
        ElseIf cmbSearch.Text = "DATE REQUEST/LOG" Then
            SummarySupply(3, "")
        ElseIf cmbSearch.Text = " PENDING REQUEST" Then
            SummarySupply(4, cmbSearch1.Text)
        ElseIf cmbSearch.Text = "RS NO." Then
            SummarySupply(6, txtSearch.Text)
        ElseIf cmbSearch.Text = "ALL" Then
            SummarySupply(5, cmbSearch1.Text)
        End If

    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        'SummarySupply()
        'SearchSummarySupply()

        If cmbSearch.Text = "RS NO." Then
            SummarySupply(6, txtSearch.Text)
        ElseIf cmbSearch.Text = "" Then
            MsgBox("Select first the category")
        ElseIf cmbSearch.Text = "LATE RS LOG AND PO LOG" Then
            date_log_range.ShowDialog()

        Else
            btnSearch1.Text = "Search"
            panel_daterange_req.Visible = True
            ComboBox1.Enabled = False
        End If



    End Sub
    Private Sub cmbSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSearch.SelectedIndexChanged

        If cmbSearch.Text = "REQUEST TYPE" Then
            cmbSearch1.Enabled = True
            txtSearch.Enabled = False
            cmbSearch1.Visible = True
            cmbSearch1.Location = New Point(txtSearch.Location.X, txtSearch.Location.Y)
            cmbSearch1.Width = txtSearch.Width
            txtSearch.Visible = False

        ElseIf cmbSearch.Text = "DATE REQUEST" Or cmbSearch.Text = "DATE REQUEST/LOG" Then
            panel_daterange_req.Visible = True
            txtSearch.Enabled = False
            btnSearch.Enabled = False
            ComboBox1.Enabled = False
            cmbSearch1.Enabled = False
            'cmbSearch1.Items.Clear()
            btnSearch1.Text = "Search"

        ElseIf cmbSearch.Text = "PENDING REQUEST" Then
            'panel_daterange_req.Visible = True
            txtSearch.Enabled = False
            btnSearch.Enabled = True
            ComboBox1.Enabled = False
            cmbSearch1.Visible = True
            cmbSearch1.Location = New Point(txtSearch.Location.X, txtSearch.Location.Y)
            cmbSearch1.Width = txtSearch.Width
            cmbSearch1.Enabled = True
            'cmbSearch1.Items.Clear()
            btnSearch1.Text = "Search"

            'Panel1.Width = 329
            'Panel1.Height = 251
            'Button2.Location = New Point(193, 207)
            'Panel1.Location = New Point(552, 193)
            'Panel1.Top = (dtgSummarySupply.Height - Panel1.Height) / 2
            'Panel1.Left = (dtgSummarySupply.Width - Panel1.Width) / 2

        ElseIf cmbSearch.Text = "RS NO." Then
            cmbSearch1.Visible = False
            txtSearch.Enabled = True
            txtSearch.Visible = True
            txtSearch.Location = New Point(txtSearch.Location.X, txtSearch.Location.Y)
            txtSearch.Width = txtSearch.Width

        ElseIf cmbSearch.Text = "ALL" Then
            txtSearch.Enabled = False
            cmbSearch1.Enabled = True
            cmbSearch1.Visible = True
            cmbSearch1.Location = New Point(txtSearch.Location.X, txtSearch.Location.Y)
            cmbSearch1.Width = txtSearch.Width
            txtSearch.Visible = False
            'cmbSearch1.Visible = True
            'txtSearch.Enabled = True
            'txtSearch.Visible = True
            'txtSearch.Location = New Point(txtSearch.Location.X, txtSearch.Location.Y)
            'txtSearch.Width = txtSearch.Width

            'Else
            '    cmbSearch1.Visible = False
            '    txtSearch.Enabled = True
            '    txtSearch.Visible = True

        ElseIf cmbSearch.Text = "LATE SERVED" Then
            txtSearch.Enabled = False
            cmbSearch1.Enabled = True
            cmbSearch1.Visible = True
            cmbSearch1.Location = New Point(txtSearch.Location.X, txtSearch.Location.Y)
            cmbSearch1.Width = txtSearch.Width
            txtSearch.Visible = False


        ElseIf cmbSearch.Text = "DATE NEEDED EXCEED" Then
            txtSearch.Enabled = False
            cmbSearch1.Enabled = True
            cmbSearch1.Visible = True
            cmbSearch1.Location = New Point(txtSearch.Location.X, txtSearch.Location.Y)
            cmbSearch1.Width = txtSearch.Width
            txtSearch.Visible = False

        ElseIf cmbSearch.Text = "DATE EXPORTED" Then
            txtSearch.Enabled = False
            cmbSearch1.Enabled = True
            cmbSearch1.Visible = True
            cmbSearch1.Location = New Point(txtSearch.Location.X, txtSearch.Location.Y)
            cmbSearch1.Width = txtSearch.Width

        ElseIf cmbSearch.Text = "PURCHASED ORDER W/O RR" Then
            txtSearch.Enabled = False
            cmbSearch1.Enabled = True
            cmbSearch1.Visible = True
            cmbSearch1.Location = New Point(txtSearch.Location.X, txtSearch.Location.Y)
            cmbSearch1.Width = txtSearch.Width


        ElseIf cmbSearch.Text = "CHARGE TO" Then
            txtSearch.Enabled = False
            txtSearch.Visible = True
            cmbSearch1.Enabled = False
            cmbSearch1.Visible = False
            cmbSearch1.Location = New Point(txtSearch.Location.X, txtSearch.Location.Y)
            cmbSearch1.Width = txtSearch.Width
            panel_chargeTo.Visible = True
            panel_chargeTo.Location = New Point(444, 146)
        End If

    End Sub

    Public Function get_charge_type()


        Try
            Dim newsqlcon As New SQLcon
            Dim newcmd As SqlCommand
            Dim dt As New DataTable()
            Dim ds As New DataSet

            sqlcon.connection.Open()
            newcmd = New SqlCommand("proc_summary_supply", sqlcon.connection)
            newcmd.Parameters.Clear()
            newcmd.CommandType = CommandType.StoredProcedure
            newcmd.CommandTimeout = 0
            newcmd.Parameters.AddWithValue("@n", 14)

            For i As Integer = 0 To ds.Tables(i).Rows.Count - 1
                cmbSearch1.Items.Add(ds.Tables(i).Rows(i)(0))
            Next

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & "error: " & Err.Description, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try
    End Function


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        panel_daterange_req.Visible = False
        btnSearch.Enabled = True
        cmbSearch.Enabled = True
        btnSearch1.Text = "Search"

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnSearch1.Click

        datefrom = Format(Date.Parse(dtpStartDate.Value), "MM/dd/yyyy")
        dateto = Format(Date.Parse(dtpEndDate.Value), "MM/dd/yyyy")

        If btnSearch1.Text = "Preview" Then

            Dim result As Integer = MessageBox.Show("Select first the Date Posted!", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

            If result = DialogResult.Cancel Then
                panel_daterange_req.Visible = True
                panel_dateRange_Log.Visible = False

            ElseIf result = DialogResult.OK Then
                panel_daterange_req.Visible = False
                panel_dateRange_Log.Visible = True
                btnSearch2.Text = "Preview"

            End If

        ElseIf btnSearch1.Text = "Search" Then

            If cmbSearch.Text = "DATE REQUEST" Then

                SummarySupply(1, "")
                txtSearch.Enabled = False
                panel_daterange_req.Visible = False
                panel_dateRange_Log.Visible = False
                btnSearch.Enabled = True

                'ElseIf cmbSearch.Text = "REQUEST TYPE" Then


                '    panel_daterange_req.Visible = False
                '    panel_dateRange_Log.Visible = True
                '    btnSearch.Enabled = Truesadadasdasdas

            ElseIf cmbSearch.Text = "DATE REQUEST/LOG" Or cmbSearch.Text = "REQUEST TYPE" Or cmbSearch.Text = "ALL" Or cmbSearch.Text = "LATE SERVED" Or cmbSearch.Text = "DATE NEEDED EXCEED" Then

                panel_daterange_req.Visible = False

                Dim result As Integer = MessageBox.Show("Select first the Date Posted!", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

                If result = DialogResult.Cancel Then
                    panel_daterange_req.Visible = True

                ElseIf result = DialogResult.OK Then
                    panel_dateRange_Log.Visible = True

                End If

            ElseIf cmbSearch.Text = "PENDING REQUEST" Then
                SummarySupply(4, cmbSearch1.Text)
                panel_daterange_req.Visible = False
                btnSearch.Enabled = True

            ElseIf cmbSearch.Text = "CANCELLED" Then
                SummarySupply(8, cmbSearch1.Text)
                panel_daterange_req.Visible = False
                btnSearch.Enabled = True

                'ElseIf cmbSearch.Text = "DATE NEEDED EXCEED" Then

            ElseIf cmbSearch.Text = "DATE EXPORTED" Then
                SummarySupply(11, cmbSearch1.Text)
                panel_daterange_req.Visible = False
                btnSearch.Enabled = True

            ElseIf cmbSearch.Text = "PURCHASED ORDER W/O RR" Then
                SummarySupply(12, cmbSearch1.Text)
                'panel_daterange_req.Visible = False
                btnSearch.Enabled = False


            ElseIf cmbSearch.Text = "CHARGE TO" Then
                category = ComboBox4.Text
                chargeTo = TextBox2.Text

                SummarySupply_ChargeTo(13, category, chargeTo)
                'panel_daterange_req.Visible = False
                btnSearch.Enabled = False


            End If

        End If

        panel_daterange_req.Visible = False

    End Sub
    Private Sub btnSearch2_Click(sender As Object, e As EventArgs) Handles btnSearch2.Click

        datefromLog = Format(Date.Parse(dtp_dateFrom_Log.Value), "MM/dd/yyyy")
        datetoLog = Format(Date.Parse(dtp_dateTo_Log.Value), "MM/dd/yyyy")


        If btnSearch2.Text = "Search" Then
            'If cmbSearch.Text = "DATE REQUEST" Then

            '    SummarySupply(1, "")
            '    panel_daterange_req.Visible = False
            '    panel_dateRange_Log.Visible = False
            '    btnSearch.Enabled = True

            If cmbSearch.Text = "REQUEST TYPE" Then

                SummarySupply(2, cmbSearch1.Text)
                panel_daterange_req.Visible = False
                panel_dateRange_Log.Visible = False
                btnSearch.Enabled = True

            ElseIf cmbSearch.Text = "DATE REQUEST/LOG" Then

                SummarySupply(3, "")
                panel_daterange_req.Visible = False
                panel_dateRange_Log.Visible = False
                btnSearch.Enabled = True

            ElseIf cmbSearch.Text = "ALL" Then
                SummarySupply(5, cmbSearch1.Text)
                panel_daterange_req.Visible = False
                panel_dateRange_Log.Visible = False
                btnSearch.Enabled = True

            ElseIf cmbSearch.Text = "LATE SERVED" Then
                SummarySupply(7, cmbSearch1.Text)
                panel_daterange_req.Visible = False
                panel_dateRange_Log.Visible = False
                btnSearch.Enabled = True

            ElseIf cmbSearch.Text = "DATE NEEDED EXCEED" Then
                SummarySupply(9, cmbSearch1.Text)
                panel_daterange_req.Visible = False
                panel_dateRange_Log.Visible = False
                btnSearch.Enabled = True

            End If

        ElseIf btnSearch2.Text = "Preview" Then

            'FProgressReport.ShowDialog()
            Dim result As Integer = MessageBox.Show("Select first the RS DATE LOG AND PO DATE LOG", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

            If result = DialogResult.Cancel Then
                panel_daterange_req.Visible = True
                panel_dateRange_Log.Visible = False

            ElseIf result = DialogResult.OK Then
                panel_daterange_req.Visible = False
                panel_dateRange_Log.Visible = False
                date_log_range.ShowDialog()

                btnSearch2.Text = "Preview"

            End If


        End If



    End Sub
    Public Sub SummarySupply(ByVal n As Integer, search As String)

        dtgSummarySupply.Rows.Clear()

        panel_dateRange_Log.Visible = False
        Dim mthread As New Threading.Thread(AddressOf loading)
        mthread.Start()

        Dim newsqlcon As New SQLcon
        Dim newsqldr As SqlDataReader
        Dim newcmd As SqlCommand
        Dim a(40) As String
        Try
            newsqlcon.connection.Open()
            newcmd = New SqlCommand("proc_summary_supply", newsqlcon.connection)
            newcmd.CommandTimeout = 0
            newcmd.Parameters.Clear()
            newcmd.CommandType = CommandType.StoredProcedure
            newcmd.Parameters.AddWithValue("@n", n)
            newcmd.Parameters.Add("@dateFrom", SqlDbType.Date).Value = Format(Date.Parse(datefrom))
            newcmd.Parameters.Add("@dateTo", SqlDbType.Date).Value = Format(Date.Parse(dateto))
            newcmd.Parameters.Add("@dateFromLog", SqlDbType.Date).Value = Format(Date.Parse(datefromLog))
            newcmd.Parameters.Add("@dateToLog", SqlDbType.Date).Value = Format(Date.Parse(datetoLog))
            'newcmd.Parameters.AddWithValue("@dateFrom", Format(Date.Parse(datefrom), "MM/dd/yyyy"))
            'newcmd.Parameters.AddWithValue("@dateTo", Format(Date.Parse(dateto), "MM/dd/yyyy"))
            'newcmd.Parameters.AddWithValue("@dateFromLog", Format(Date.Parse(datefromLog), "MM/dd/yyyy"))
            'newcmd.Parameters.AddWithValue("@dateToLog", Format(Date.Parse(datetoLog), "MM/dd/yyyy"))
            newcmd.Parameters.AddWithValue("@searchby", search)
            'MsgBox(newcmd.Parameters.AddWithValue("@searchby", search))
            newsqldr = newcmd.ExecuteReader

            While newsqldr.Read

                a(0) = dtgSummarySupply.RowCount
                a(1) = newsqldr.Item("rs_id").ToString
                a(2) = Format(Date.Parse(newsqldr.Item("date_req").ToString), "MM/dd/yyyy")
                a(4) = newsqldr.Item("rr_item_id").ToString

                'a(25) = newsqldr.Item("plate_no").ToString ''''' FOR HAULING FUNCTION '''
                'a(12) = Format(Date.Parse(newsqldr.Item("DATE_RECEIVED").ToString), "MM/dd/yy")


                If cmbSearch.Text = "ALL" Or cmbSearch.Text = "DATE EXPORTED" Then

                    If newsqldr.Item("po_date").ToString <> Nothing Then
                        a(3) = Format(Date.Parse(newsqldr.Item("po_date").ToString), "MM/dd/yyyy")
                        'a(14) = Format(Date.Parse(newsqldr.Item("date_needed").ToString), "MM/dd/yyyy")
                        'a(18) = po(a(2), a(3))
                    ElseIf newsqldr.Item("rr_item_id").ToString <> Nothing Then
                        a(13) = Format(Date.Parse(newsqldr.Item("DATE_RECEIVED").ToString), "MM/dd/yyyy")
                        'a(19) = po(a(3), a(13))
                        'a(34) = interval_needed_received(a(13), Format(Date.Parse(newsqldr.Item("date_needed").ToString), "MM/dd/yyyy"))
                    Else
                        'a(3) = Format(Date.Parse(newsqldr.Item("po_date").ToString), "MM/dd/yyyy")
                        a(5) = newsqldr.Item("QTY_REQUESTED").ToString ' / newsqldr.Item("NO_OF_CHARGES").ToString
                        a(10) = ""
                        a(12) = ""
                        'a(13) = Format(Date.Parse(newsqldr.Item("DATE_LOG_WITHDRAW").ToString), "MM/dd/yyyy")
                        If newsqldr.Item("DATE_RECEIVED").ToString = "" Then
                            a(13) = ""
                        Else
                            a(13) = Format(Date.Parse(newsqldr.Item("DATE_RECEIVED").ToString), "MM/dd/yyyy")
                        End If
                        a(18) = ""
                        a(19) = ""
                        a(27) = ""
                    End If

                    'If newsqldr.Item("type_of_purchasing").ToString = "WITHDRAWAL" Then
                    '    a(5) = newsqldr.Item("QTY_REQUESTED").ToString
                    'End If

                    If newsqldr.Item("rr_item_id").ToString <> Nothing Then
                        a(5) = newsqldr.Item("QTY_REQUESTED").ToString / newsqldr.Item("NO_OF_CHARGES").ToString
                        a(13) = Format(Date.Parse(newsqldr.Item("DATE_RECEIVED").ToString), "MM/dd/yyyy")
                        'a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE").ToString)
                        'a(19) = po(a(3), a(13))
                        a(20) = newsqldr.Item("SUPPLIER_NAME").ToString
                        a(21) = newsqldr.Item("remarks").ToString
                        a(23) = newsqldr.Item("invoice_no").ToString
                    Else
                        'a(3) = Format(Date.Parse(newsqldr.Item("po_date").ToString), "MM/dd/yyyy")
                        a(5) = newsqldr.Item("QTY_REQUESTED").ToString
                        'a(13) = Format(Date.Parse(newsqldr.Item("DATE_LOG_WITHDRAW").ToString), "MM/dd/yyyy")
                        'a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE_WITHDRAWAL").ToString)
                        'a(19) = po(a(3), a(13))
                        a(20) = "N/A"
                        a(21) = newsqldr.Item("remarks_status").ToString
                        a(23) = "N/A"
                    End If

                    'End If

                    a(6) = newsqldr.Item("unit").ToString
                    'a(7) = newsqldr.Item("whItem").ToString + " - " + newsqldr.Item("whItemDesc").ToString
                    a(7) = newsqldr.Item("whItem").ToString + " --- " + newsqldr.Item("itemDesc_request").ToString + " --- " + newsqldr.Item("whItemDesc_receiving_withdrawal").ToString

                    'If newsqldr.Item("rr_item_id").ToString <> Nothing Then
                    '    a(8) = newsqldr.Item("QTY_RECEIVED").ToString
                    '    a(12) = newsqldr.Item("rr_no").ToString
                    'Else
                    '    'a(8) = newsqldr.Item("QTY_WITHDRAWN").ToString
                    '    a(12) = "N/A"
                    'End If

                    If (Not String.IsNullOrEmpty(newsqldr.Item("rr_item_id").ToString)) Then
                        a(8) = newsqldr.Item("QTY_RECEIVED").ToString
                        a(12) = newsqldr.Item("rr_no").ToString
                    Else
                        a(8) = newsqldr.Item("QTY_WITHDRAWN").ToString
                    End If


                    a(9) = newsqldr.Item("requested_by").ToString
                    a(10) = newsqldr.Item("po_no").ToString
                    a(11) = newsqldr.Item("rs_no").ToString


                    If newsqldr.Item("type_of_purchasing").ToString = "WITHDRAWAL" Then
                        a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE_WITHDRAWAL").ToString)
                    ElseIf newsqldr.Item("type_of_purchasing").ToString = "CASH WITHOUT RR" Then
                        a(15) = FormatNumber(newsqldr.Item("WO_RR_PRICE").ToString)
                    ElseIf newsqldr.Item("type_of_purchasing").ToString = "CASH WITH RR" Then
                        a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE").ToString)
                    Else
                        If (Not String.IsNullOrEmpty(newsqldr.Item("UNIT_PRICE").ToString)) Then
                            a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE").ToString)
                        Else
                            a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE_WITHDRAWAL").ToString)
                        End If

                        'If newsqldr.Item("UNIT_PRICE").ToString = "0" Or newsqldr.Item("UNIT_PRICE").ToString.IsNullOrEmpty Then
                        '    a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE_WITHDRAWAL").ToString)
                        'Else
                        '    a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE").ToString)
                        'End If
                    End If


                    If newsqldr.Item("type_name").ToString = "WAREHOUSE" Then
                        a(17) = newsqldr.Item("CHARGE_TO_WAREHOUSE").ToString
                    ElseIf newsqldr.Item("type_name").ToString = "PROJECT" Then
                        a(17) = newsqldr.Item("CHARGE_TO_PROJECT").ToString
                    ElseIf newsqldr.Item("type_name").ToString = "EQUIPMENT" Then
                        a(17) = newsqldr.Item("CHARGE_TO_EQUIPMENT").ToString
                    ElseIf newsqldr.Item("type_name").ToString = "OTHERS" _
                            Or newsqldr.Item("type_name").ToString = "MAINOFFICE" _
                            Or newsqldr.Item("type_name").ToString = "PERSONAL" _
                            Or newsqldr.Item("type_name").ToString = "COMPANY" _
                            Or newsqldr.Item("type_name").ToString = "DIVISION" _
                            Or newsqldr.Item("type_name").ToString = "DEPARTMENT" _
                            Or newsqldr.Item("type_name").ToString = "SECTION" _
                            Or newsqldr.Item("type_name").ToString = "SHOPS" _
                            Or newsqldr.Item("type_name").ToString = "MOBILE CRUSHER" _
                            Or newsqldr.Item("type_name").ToString = "CRUSHER PLANT" _
                            Or newsqldr.Item("type_name").ToString = "BATCHING PLANT" _
                            Or newsqldr.Item("type_name").ToString = "WAREHOUSES" _
                            Or newsqldr.Item("type_name").ToString = "FABRICATION" _
                            Or newsqldr.Item("type_name").ToString = "BUNKHOUSE" _
                            Or newsqldr.Item("type_name").ToString = "OTHERS_NEW" _
                            Or newsqldr.Item("type_name").ToString = "PROPERTY CODES" _
                           Or newsqldr.Item("type_name").ToString = "HOUSE & LOT" Then
                        a(17) = newsqldr.Item("CHARGE_TO_PER_MAIN_OTHERS").ToString
                    End If

                    'a(21) = newsqldr.Item("DATEDIFF").ToString
                    a(22) = newsqldr.Item("typeRequest").ToString + " - " + newsqldr.Item("tor_sub_desc").ToString

                    a(24) = "N/A"
                    a(25) = "N/A"
                    a(26) = "N/A"
                    a(28) = newsqldr.Item("type_of_purchasing").ToString
                    a(33) = newsqldr.Item("SUPPLIERS_TERMS").ToString

                    If cmbSearch.Text = "ALL" Then
                        a(35) = Format(Date.Parse(newsqldr.Item("DATE_LOG_REQUEST").ToString), "MM/dd/yyyy")
                        If newsqldr.Item("DATE_LOG_RECEIVED").ToString <> Nothing Then
                            a(36) = Format(Date.Parse(newsqldr.Item("DATE_LOG_RECEIVED").ToString), "MM/dd/yyyy")
                        Else
                            a(36) = "NULL"
                        End If
                    End If

                    If newsqldr.Item("type_of_purchasing").ToString = "WITHDRAWAL" Then
                        a(27) = "COMPLETED"
                    ElseIf (newsqldr.Item("type_of_purchasing").ToString = "PURCHASE ORDER") Or (newsqldr.Item("type_of_purchasing").ToString = "CASH") Or (newsqldr.Item("type_of_purchasing").ToString = "CASH WITH RR") Or (newsqldr.Item("type_of_purchasing").ToString = "CASH WITHOUT RR") Then
                        If a(21) <> Nothing Then
                            a(27) = "COMPLETED"
                        Else
                            a(27) = ""
                        End If
                    End If

                    a(39) = newsqldr.Item("purpose").ToString

                    dtgSummarySupply.Rows.Add(a)

                ElseIf cmbSearch.Text = "PENDING REQUEST" Then

                    If newsqldr.Item("po_date").ToString <> Nothing Then
                        a(3) = Format(Date.Parse(newsqldr.Item("po_date").ToString), "MM/dd/yyyy")
                        a(14) = Format(Date.Parse(newsqldr.Item("date_needed").ToString), "MM/dd/yyyy")
                        a(18) = po(a(2), a(3))
                    ElseIf newsqldr.Item("rr_item_id").ToString <> Nothing Then
                        a(13) = Format(Date.Parse(newsqldr.Item("DATE_RECEIVED").ToString), "MM/dd/yyyy")
                        a(19) = po(a(3), a(13))
                        'a(34) = interval_needed_received(a(13), Format(Date.Parse(newsqldr.Item("date_needed").ToString), "MM/dd/yyyy"))
                    Else
                        'a(3) = Format(Date.Parse(newsqldr.Item("po_date").ToString), "MM/dd/yyyy")
                        a(5) = newsqldr.Item("QTY_REQUESTED").ToString ' / newsqldr.Item("NO_OF_CHARGES").ToString
                        a(10) = ""
                        a(12) = ""
                        'a(13) = Format(Date.Parse(newsqldr.Item("DATE_LOG_WITHDRAW").ToString), "MM/dd/yyyy")
                        a(18) = ""
                        a(19) = ""
                        a(27) = ""
                    End If

                    'If newsqldr.Item("type_of_purchasing").ToString = "WITHDRAWAL" Then
                    '    a(5) = newsqldr.Item("QTY_REQUESTED").ToString
                    'End If

                    If newsqldr.Item("rr_item_id").ToString <> Nothing Then
                        a(5) = newsqldr.Item("QTY_REQUESTED").ToString / newsqldr.Item("NO_OF_CHARGES").ToString
                        a(13) = Format(Date.Parse(newsqldr.Item("DATE_RECEIVED").ToString), "MM/dd/yyyy")
                        'a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE").ToString)
                        a(19) = po(a(3), a(13))
                        a(20) = newsqldr.Item("SUPPLIER_NAME").ToString
                        a(21) = newsqldr.Item("remarks").ToString
                        a(23) = newsqldr.Item("invoice_no").ToString
                    Else
                        'a(3) = Format(Date.Parse(newsqldr.Item("po_date").ToString), "MM/dd/yyyy")
                        a(5) = newsqldr.Item("QTY_REQUESTED").ToString
                        'a(13) = Format(Date.Parse(newsqldr.Item("DATE_LOG_WITHDRAW").ToString), "MM/dd/yyyy")
                        'a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE_WITHDRAWAL").ToString)
                        'a(19) = po(a(3), a(13))
                        a(20) = "N/A"
                        a(21) = newsqldr.Item("remarks_status").ToString
                        a(23) = "N/A"
                    End If

                    'End If

                    a(6) = newsqldr.Item("unit").ToString
                    a(7) = newsqldr.Item("whItem").ToString + " - " + newsqldr.Item("whItemDesc").ToString

                    If (Not String.IsNullOrEmpty(newsqldr.Item("rr_item_id").ToString)) Then
                        a(8) = newsqldr.Item("QTY_RECEIVED").ToString
                        a(12) = newsqldr.Item("rr_no").ToString
                    Else
                        a(8) = ""
                    End If

                    a(9) = newsqldr.Item("requested_by").ToString
                    a(10) = newsqldr.Item("po_no").ToString
                    a(11) = newsqldr.Item("rs_no").ToString


                    If newsqldr.Item("type_of_purchasing").ToString = "WITHDRAWAL" Then
                        a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE_WITHDRAWAL").ToString)
                    Else
                        If (Not String.IsNullOrEmpty(newsqldr.Item("UNIT_PRICE").ToString)) Then
                            a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE").ToString)
                        Else
                            a(15) = ""
                        End If
                    End If

                    If newsqldr.Item("type_name").ToString = "WAREHOUSE" Then
                        a(17) = newsqldr.Item("CHARGE_TO_WAREHOUSE").ToString
                    ElseIf newsqldr.Item("type_name").ToString = "PROJECT" Then
                        a(17) = newsqldr.Item("CHARGE_TO_PROJECT").ToString
                    ElseIf newsqldr.Item("type_name").ToString = "EQUIPMENT" Then
                        a(17) = newsqldr.Item("CHARGE_TO_EQUIPMENT").ToString
                    ElseIf newsqldr.Item("type_name").ToString = "OTHERS" _
                        Or newsqldr.Item("type_name").ToString = "MAINOFFICE" _
                        Or newsqldr.Item("type_name").ToString = "PERSONAL" _
                         Or newsqldr.Item("type_name").ToString = "COMPANY" _
                            Or newsqldr.Item("type_name").ToString = "DIVISION" _
                            Or newsqldr.Item("type_name").ToString = "DEPARTMENT" _
                            Or newsqldr.Item("type_name").ToString = "SECTION" _
                            Or newsqldr.Item("type_name").ToString = "SHOPS" _
                            Or newsqldr.Item("type_name").ToString = "MOBILE CRUSHER" _
                            Or newsqldr.Item("type_name").ToString = "CRUSHER PLANT" _
                            Or newsqldr.Item("type_name").ToString = "BATCHING PLANT" _
                            Or newsqldr.Item("type_name").ToString = "WAREHOUSES" _
                            Or newsqldr.Item("type_name").ToString = "FABRICATION" _
                            Or newsqldr.Item("type_name").ToString = "BUNKHOUSE" _
                            Or newsqldr.Item("type_name").ToString = "OTHERS_NEW" _
                            Or newsqldr.Item("type_name").ToString = "PROPERTY CODES" _
                            Or newsqldr.Item("type_name").ToString = "HOUSE & LOT" Then
                        a(17) = newsqldr.Item("CHARGE_TO_PER_MAIN_OTHERS").ToString
                    End If

                    'a(21) = newsqldr.Item("DATEDIFF").ToString
                    a(22) = newsqldr.Item("typeRequest").ToString + " - " + newsqldr.Item("tor_sub_desc").ToString

                    a(24) = "N/A"
                    a(25) = "N/A"
                    a(26) = "N/A"
                    a(28) = newsqldr.Item("type_of_purchasing").ToString
                    a(33) = newsqldr.Item("SUPPLIERS_TERMS").ToString

                    If cmbSearch.Text = "ALL" Then
                        a(35) = Format(Date.Parse(newsqldr.Item("DATE_LOG_REQUEST").ToString), "MM/dd/yyyy")
                        If newsqldr.Item("DATE_LOG_RECEIVED").ToString <> Nothing Then
                            a(36) = Format(Date.Parse(newsqldr.Item("DATE_LOG_RECEIVED").ToString), "MM/dd/yyyy")
                        Else
                            a(36) = "NULL"
                        End If
                    End If

                    If newsqldr.Item("type_of_purchasing").ToString = "WITHDRAWAL" Then
                        a(27) = "COMPLETED"
                    ElseIf (newsqldr.Item("type_of_purchasing").ToString = "PURCHASE ORDER") Or (newsqldr.Item("type_of_purchasing").ToString = "CASH") Then
                        If a(21) <> Nothing Then
                            a(27) = "COMPLETED"
                        Else
                            a(27) = ""
                        End If
                    End If

                    a(39) = newsqldr.Item("purpose").ToString

                    dtgSummarySupply.Rows.Add(a)

                ElseIf cmbSearch.Text = "DATE NEEDED EXCEED" Then

                    Dim date1 As DateTime = Format(Date.Parse(newsqldr.Item("date_needed").ToString), "MM/dd/yyyy")

                    Dim date2 As DateTime = Format(Date.Parse(newsqldr.Item("DATE_RECEIVED").ToString), "MM/dd/yyyy")

                    Dim days As Long = DateDiff(DateInterval.Day, date1, date2)

                    If days > 5 Then

                        If newsqldr.Item("po_date").ToString <> Nothing Then
                            a(3) = Format(Date.Parse(newsqldr.Item("po_date").ToString), "MM/dd/yyyy")
                            a(14) = Format(Date.Parse(newsqldr.Item("date_needed").ToString), "MM/dd/yyyy")
                            a(18) = po(a(2), a(3))
                        ElseIf newsqldr.Item("rr_item_id").ToString <> Nothing Then
                            a(13) = Format(Date.Parse(newsqldr.Item("DATE_RECEIVED").ToString), "MM/dd/yyyy")
                            a(19) = po(a(3), a(13))
                            'a(34) = interval_needed_received(a(13), Format(Date.Parse(newsqldr.Item("date_needed").ToString), "MM/dd/yyyy"))
                        Else
                            'a(3) = Format(Date.Parse(newsqldr.Item("po_date").ToString), "MM/dd/yyyy")
                            a(5) = newsqldr.Item("QTY_REQUESTED").ToString ' / newsqldr.Item("NO_OF_CHARGES").ToString
                            a(10) = ""
                            a(12) = ""
                            'a(13) = Format(Date.Parse(newsqldr.Item("DATE_LOG_WITHDRAW").ToString), "MM/dd/yyyy")
                            a(18) = ""
                            a(19) = ""
                            a(27) = ""
                        End If

                        'If newsqldr.Item("type_of_purchasing").ToString = "WITHDRAWAL" Then
                        '    a(5) = newsqldr.Item("QTY_REQUESTED").ToString
                        'End If

                        If newsqldr.Item("rr_item_id").ToString <> Nothing Then
                            a(5) = newsqldr.Item("QTY_REQUESTED").ToString / newsqldr.Item("NO_OF_CHARGES").ToString
                            a(13) = Format(Date.Parse(newsqldr.Item("DATE_RECEIVED").ToString), "MM/dd/yyyy")
                            'a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE").ToString)
                            a(19) = po(a(14), a(13))
                            a(20) = newsqldr.Item("SUPPLIER_NAME").ToString
                            a(21) = newsqldr.Item("remarks").ToString
                            a(23) = newsqldr.Item("invoice_no").ToString
                        Else
                            'a(3) = Format(Date.Parse(newsqldr.Item("po_date").ToString), "MM/dd/yyyy")
                            a(5) = newsqldr.Item("QTY_REQUESTED").ToString
                            'a(13) = Format(Date.Parse(newsqldr.Item("DATE_LOG_WITHDRAW").ToString), "MM/dd/yyyy")
                            'a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE_WITHDRAWAL").ToString)
                            'a(19) = po(a(3), a(13))
                            a(20) = "N/A"
                            a(21) = newsqldr.Item("remarks_status").ToString
                            a(23) = "N/A"
                        End If

                        'End If

                        a(6) = newsqldr.Item("unit").ToString
                        a(7) = newsqldr.Item("whItem").ToString + " - " + newsqldr.Item("whItemDesc").ToString

                        If (Not String.IsNullOrEmpty(newsqldr.Item("rr_item_id").ToString)) Then
                            a(8) = newsqldr.Item("QTY_RECEIVED").ToString
                            a(12) = newsqldr.Item("rr_no").ToString
                        Else
                            a(8) = newsqldr.Item("QTY_WITHDRAWN").ToString
                        End If

                        a(9) = newsqldr.Item("requested_by").ToString
                        a(10) = newsqldr.Item("po_no").ToString
                        a(11) = newsqldr.Item("rs_no").ToString


                        If newsqldr.Item("type_of_purchasing").ToString = "WITHDRAWAL" Then
                            a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE_WITHDRAWAL").ToString)
                        Else
                            If (Not String.IsNullOrEmpty(newsqldr.Item("UNIT_PRICE").ToString)) Then
                                a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE").ToString)
                            Else
                                a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE_WITHDRAWAL").ToString)
                            End If
                        End If

                        If newsqldr.Item("type_name").ToString = "WAREHOUSE" Then
                            a(17) = newsqldr.Item("CHARGE_TO_WAREHOUSE").ToString
                        ElseIf newsqldr.Item("type_name").ToString = "PROJECT" Then
                            a(17) = newsqldr.Item("CHARGE_TO_PROJECT").ToString
                        ElseIf newsqldr.Item("type_name").ToString = "EQUIPMENT" Then
                            a(17) = newsqldr.Item("CHARGE_TO_EQUIPMENT").ToString
                        ElseIf newsqldr.Item("type_name").ToString = "OTHERS" _
                            Or newsqldr.Item("type_name").ToString = "MAINOFFICE" _
                            Or newsqldr.Item("type_name").ToString = "PERSONAL" _
                             Or newsqldr.Item("type_name").ToString = "COMPANY" _
                            Or newsqldr.Item("type_name").ToString = "DIVISION" _
                            Or newsqldr.Item("type_name").ToString = "DEPARTMENT" _
                            Or newsqldr.Item("type_name").ToString = "SECTION" _
                            Or newsqldr.Item("type_name").ToString = "SHOPS" _
                            Or newsqldr.Item("type_name").ToString = "MOBILE CRUSHER" _
                            Or newsqldr.Item("type_name").ToString = "CRUSHER PLANT" _
                            Or newsqldr.Item("type_name").ToString = "BATCHING PLANT" _
                            Or newsqldr.Item("type_name").ToString = "WAREHOUSEST" _
                            Or newsqldr.Item("type_name").ToString = "FABRICATION" _
                            Or newsqldr.Item("type_name").ToString = "BUNKHOUSE" _
                            Or newsqldr.Item("type_name").ToString = "OTHERS_NEW" _
                            Or newsqldr.Item("type_name").ToString = "PROPERTY CODES" _
                            Or newsqldr.Item("type_name").ToString = "HOUSE & LOT" Then
                            a(17) = newsqldr.Item("CHARGE_TO_PER_MAIN_OTHERS").ToString
                        End If

                        'a(21) = newsqldr.Item("DATEDIFF").ToString
                        a(22) = newsqldr.Item("typeRequest").ToString + " - " + newsqldr.Item("tor_sub_desc").ToString

                        a(24) = "N/A"
                        a(25) = "N/A"
                        a(26) = "N/A"
                        a(28) = newsqldr.Item("type_of_purchasing").ToString
                        a(33) = newsqldr.Item("SUPPLIERS_TERMS").ToString

                        If cmbSearch.Text = "ALL" Then
                            a(35) = Format(Date.Parse(newsqldr.Item("DATE_LOG_REQUEST").ToString), "MM/dd/yyyy")
                            If newsqldr.Item("DATE_LOG_RECEIVED").ToString <> Nothing Then
                                a(36) = Format(Date.Parse(newsqldr.Item("DATE_LOG_RECEIVED").ToString), "MM/dd/yyyy")
                            Else
                                a(36) = "NULL"
                            End If
                        End If

                        If newsqldr.Item("type_of_purchasing").ToString = "WITHDRAWAL" Then
                            a(27) = "COMPLETED"
                        ElseIf (newsqldr.Item("type_of_purchasing").ToString = "PURCHASE ORDER") Or (newsqldr.Item("type_of_purchasing").ToString = "CASH") Then
                            If a(21) <> Nothing Then
                                a(27) = "COMPLETED"
                            Else
                                a(27) = ""
                            End If
                        End If

                        a(39) = newsqldr.Item("purpose").ToString

                        dtgSummarySupply.Rows.Add(a)

                    End If


                ElseIf cmbSearch.Text = "PURCHASED ORDER W/O RR" Then

                    If newsqldr.Item("po_date").ToString <> Nothing Then
                        a(3) = Format(Date.Parse(newsqldr.Item("po_date").ToString), "MM/dd/yyyy")
                        'a(14) = Format(Date.Parse(newsqldr.Item("date_needed").ToString), "MM/dd/yyyy")
                        'a(18) = po(a(2), a(3))
                    ElseIf newsqldr.Item("rr_item_id").ToString <> Nothing Then
                        a(13) = Format(Date.Parse(newsqldr.Item("DATE_RECEIVED").ToString), "MM/dd/yyyy")
                        'a(19) = po(a(3), a(13))
                        'a(34) = interval_needed_received(a(13), Format(Date.Parse(newsqldr.Item("date_needed").ToString), "MM/dd/yyyy"))
                    Else
                        'a(3) = Format(Date.Parse(newsqldr.Item("po_date").ToString), "MM/dd/yyyy")
                        a(5) = newsqldr.Item("QTY_REQUESTED").ToString ' / newsqldr.Item("NO_OF_CHARGES").ToString
                        a(10) = ""
                        a(12) = ""
                        'a(13) = Format(Date.Parse(newsqldr.Item("DATE_LOG_WITHDRAW").ToString), "MM/dd/yyyy")
                        a(13) = ""
                        a(18) = ""
                        a(19) = ""
                        a(27) = ""
                    End If

                    'If newsqldr.Item("type_of_purchasing").ToString = "WITHDRAWAL" Then
                    '    a(5) = newsqldr.Item("QTY_REQUESTED").ToString
                    'End If

                    If newsqldr.Item("rr_item_id").ToString <> Nothing Then
                        a(5) = newsqldr.Item("QTY_REQUESTED").ToString / newsqldr.Item("NO_OF_CHARGES").ToString
                        a(13) = Format(Date.Parse(newsqldr.Item("DATE_RECEIVED").ToString), "MM/dd/yyyy")
                        'a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE").ToString)
                        'a(19) = po(a(3), a(13))
                        a(20) = newsqldr.Item("SUPPLIER_NAME").ToString
                        a(21) = newsqldr.Item("remarks").ToString
                        a(23) = newsqldr.Item("invoice_no").ToString
                    Else
                        'a(3) = Format(Date.Parse(newsqldr.Item("po_date").ToString), "MM/dd/yyyy")
                        a(5) = newsqldr.Item("QTY_REQUESTED").ToString
                        'a(13) = Format(Date.Parse(newsqldr.Item("DATE_LOG_WITHDRAW").ToString), "MM/dd/yyyy")
                        'a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE_WITHDRAWAL").ToString)
                        'a(19) = po(a(3), a(13))
                        a(20) = "N/A"
                        a(21) = newsqldr.Item("remarks_status").ToString
                        a(23) = "N/A"
                    End If

                    'End If

                    a(6) = newsqldr.Item("unit").ToString
                    'a(7) = newsqldr.Item("whItem").ToString + " - " + newsqldr.Item("whItemDesc").ToString
                    a(7) = newsqldr.Item("whItem").ToString + " --- " + newsqldr.Item("itemDesc_request").ToString + " --- " + newsqldr.Item("whItemDesc_receiving_withdrawal").ToString

                    'If newsqldr.Item("rr_item_id").ToString <> Nothing Then
                    '    a(8) = newsqldr.Item("QTY_RECEIVED").ToString
                    '    a(12) = newsqldr.Item("rr_no").ToString
                    'Else
                    '    'a(8) = newsqldr.Item("QTY_WITHDRAWN").ToString
                    '    a(12) = "N/A"
                    'End If

                    If (Not String.IsNullOrEmpty(newsqldr.Item("rr_item_id").ToString)) Then
                        a(8) = newsqldr.Item("QTY_RECEIVED").ToString
                        a(12) = newsqldr.Item("rr_no").ToString
                    Else
                        a(8) = newsqldr.Item("QTY_WITHDRAWN").ToString
                    End If


                    a(9) = newsqldr.Item("requested_by").ToString
                    a(10) = newsqldr.Item("po_no").ToString
                    a(11) = newsqldr.Item("rs_no").ToString


                    If newsqldr.Item("type_of_purchasing").ToString = "WITHDRAWAL" Then
                        a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE_WITHDRAWAL").ToString)
                    ElseIf newsqldr.Item("type_of_purchasing").ToString = "CASH WITHOUT RR" Then
                        a(15) = FormatNumber(newsqldr.Item("WO_RR_PRICE").ToString)
                    ElseIf newsqldr.Item("type_of_purchasing").ToString = "CASH WITH RR" Then
                        a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE").ToString)
                    Else
                        If (Not String.IsNullOrEmpty(newsqldr.Item("UNIT_PRICE").ToString)) Then
                            a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE").ToString)
                        Else
                            a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE_WITHDRAWAL").ToString)
                        End If

                        'If newsqldr.Item("UNIT_PRICE").ToString = "0" Or newsqldr.Item("UNIT_PRICE").ToString.IsNullOrEmpty Then
                        '    a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE_WITHDRAWAL").ToString)
                        'Else
                        '    a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE").ToString)
                        'End If
                    End If


                    If newsqldr.Item("type_name").ToString = "WAREHOUSE" Then
                        a(17) = newsqldr.Item("CHARGE_TO_WAREHOUSE").ToString
                    ElseIf newsqldr.Item("type_name").ToString = "PROJECT" Then
                        a(17) = newsqldr.Item("CHARGE_TO_PROJECT").ToString
                    ElseIf newsqldr.Item("type_name").ToString = "EQUIPMENT" Then
                        a(17) = newsqldr.Item("CHARGE_TO_EQUIPMENT").ToString
                    ElseIf newsqldr.Item("type_name").ToString = "OTHERS" _
                            Or newsqldr.Item("type_name").ToString = "MAINOFFICE" _
                            Or newsqldr.Item("type_name").ToString = "PERSONAL" _
                            Or newsqldr.Item("type_name").ToString = "COMPANY" _
                            Or newsqldr.Item("type_name").ToString = "DIVISION" _
                            Or newsqldr.Item("type_name").ToString = "DEPARTMENT" _
                            Or newsqldr.Item("type_name").ToString = "SECTION" _
                            Or newsqldr.Item("type_name").ToString = "SHOPS" _
                            Or newsqldr.Item("type_name").ToString = "MOBILE CRUSHER" _
                            Or newsqldr.Item("type_name").ToString = "CRUSHER PLANT" _
                            Or newsqldr.Item("type_name").ToString = "BATCHING PLANT" _
                            Or newsqldr.Item("type_name").ToString = "WAREHOUSES" _
                            Or newsqldr.Item("type_name").ToString = "FABRICATION" _
                            Or newsqldr.Item("type_name").ToString = "BUNKHOUSE" _
                            Or newsqldr.Item("type_name").ToString = "OTHERS_NEW" _
                            Or newsqldr.Item("type_name").ToString = "PROPERTY CODES" _
                           Or newsqldr.Item("type_name").ToString = "HOUSE & LOT" Then
                        a(17) = newsqldr.Item("CHARGE_TO_PER_MAIN_OTHERS").ToString
                    End If

                    'a(21) = newsqldr.Item("DATEDIFF").ToString
                    a(22) = newsqldr.Item("typeRequest").ToString + " - " + newsqldr.Item("tor_sub_desc").ToString

                    a(24) = "N/A"
                    a(25) = "N/A"
                    a(26) = "N/A"
                    a(28) = newsqldr.Item("type_of_purchasing").ToString
                    a(33) = newsqldr.Item("SUPPLIERS_TERMS").ToString

                    If cmbSearch.Text = "ALL" Then
                        a(35) = Format(Date.Parse(newsqldr.Item("DATE_LOG_REQUEST").ToString), "MM/dd/yyyy")
                        If newsqldr.Item("DATE_LOG_RECEIVED").ToString <> Nothing Then
                            a(36) = Format(Date.Parse(newsqldr.Item("DATE_LOG_RECEIVED").ToString), "MM/dd/yyyy")
                        Else
                            a(36) = "NULL"
                        End If
                    End If

                    If newsqldr.Item("type_of_purchasing").ToString = "WITHDRAWAL" Then
                        a(27) = "COMPLETED"
                    ElseIf (newsqldr.Item("type_of_purchasing").ToString = "PURCHASE ORDER") Or (newsqldr.Item("type_of_purchasing").ToString = "CASH") Or (newsqldr.Item("type_of_purchasing").ToString = "CASH WITH RR") Or (newsqldr.Item("type_of_purchasing").ToString = "CASH WITHOUT RR") Then
                        If a(21) <> Nothing Then
                            a(27) = "COMPLETED"
                        Else
                            a(27) = ""
                        End If
                    End If

                    a(39) = newsqldr.Item("purpose").ToString

                    dtgSummarySupply.Rows.Add(a)





                Else '''''ELSE WHOLE LOOP

                    a(5) = newsqldr.Item("QTY_REQUESTED").ToString

                    If newsqldr.Item("po_date").ToString <> Nothing Then
                        a(3) = Format(Date.Parse(newsqldr.Item("po_date").ToString), "MM/dd/yyyy")
                        a(14) = Format(Date.Parse(newsqldr.Item("date_needed").ToString), "MM/dd/yyyy")
                        a(21) = newsqldr.Item("remarks").ToString
                        If newsqldr.Item("type_of_purchasing").ToString = "PURCHASE ORDER" Then
                            a(18) = po(a(2), a(3))
                        Else
                            a(18) = "N/A"
                        End If

                    Else
                        a(3) = ""
                        a(5) = newsqldr.Item("QTY_REQUESTED").ToString
                        a(10) = ""
                        a(12) = ""
                        a(14) = ""
                        a(18) = "N/A"
                        a(19) = "N/A"
                        a(21) = newsqldr.Item("remarks").ToString
                        a(27) = ""
                    End If

                    If newsqldr.Item("rr_item_id").ToString <> Nothing Then
                        a(5) = newsqldr.Item("QTY_REQUESTED").ToString / newsqldr.Item("NO_OF_CHARGES").ToString
                        a(8) = newsqldr.Item("QTY_RECEIVED").ToString
                        a(13) = Format(Date.Parse(newsqldr.Item("DATE_RECEIVED").ToString), "MM/dd/yyyy")
                        'a(14) = Format(Date.Parse(newsqldr.Item("date_needed").ToString), "MM/dd/yyyy")
                        a(12) = newsqldr.Item("rr_no").ToString

                        If newsqldr.Item("whItem").ToString = "Aggregates" Then
                            If newsqldr.Item("type_of_purchasing").ToString = "PURCHASE ORDER" Then
                                a(19) = po(a(2), a(13))
                            ElseIf newsqldr.Item("type_of_purchasing").ToString = "CASH" Or newsqldr.Item("type_of_purchasing").ToString = "CASH WITH RR" Then
                                a(19) = po(a(2), a(13))
                            ElseIf newsqldr.Item("type_of_purchasing").ToString = "CASH WITHOUT RR" Then
                                a(19) = "N/A"
                            End If
                        Else
                            If newsqldr.Item("type_of_purchasing").ToString = "PURCHASE ORDER" Then
                                a(19) = po(a(14), a(13))
                            ElseIf newsqldr.Item("type_of_purchasing").ToString = "CASH" Or newsqldr.Item("type_of_purchasing").ToString = "CASH WITH RR" Then
                                a(19) = po(a(2), a(13))
                            ElseIf newsqldr.Item("type_of_purchasing").ToString = "CASH WITHOUT RR" Then
                                a(19) = "N/A"
                            End If
                        End If

                        a(20) = newsqldr.Item("SUPPLIER_NAME").ToString
                        a(21) = newsqldr.Item("remarks").ToString
                        a(23) = newsqldr.Item("invoice_no").ToString

                    ElseIf String.IsNullOrEmpty(newsqldr.Item("rr_item_id").ToString) Then
                        a(8) = ""
                        a(12) = ""
                        a(13) = ""
                        a(21) = newsqldr.Item("remarks").ToString
                    Else

                        a(13) = ""
                        a(12) = ""

                        If newsqldr.Item("date_needed").ToString = "" Then
                            a(12) = ""
                            a(13) = ""
                        Else
                            a(14) = ""
                        End If
                        a(18) = "N/A"
                        a(20) = "N/A"
                        'a(21) = newsqldr.Item("remarks_status").ToString
                        a(21) = newsqldr.Item("remarks").ToString
                        a(23) = "N/A"
                    End If


                    'End If

                    a(6) = newsqldr.Item("unit").ToString
                    a(7) = newsqldr.Item("whItem").ToString + " - " + newsqldr.Item("whItemDesc").ToString

                    'If (Not String.IsNullOrEmpty(newsqldr.Item("rr_item_id").ToString)) Then
                    '    a(8) = newsqldr.Item("QTY_RECEIVED").ToString
                    'Else
                    '    a(8) = newsqldr.Item("QTY_WITHDRAWN").ToString
                    'End If

                    a(9) = newsqldr.Item("requested_by").ToString
                    a(10) = newsqldr.Item("po_no").ToString
                    a(11) = newsqldr.Item("rs_no").ToString


                    If newsqldr.Item("type_of_purchasing").ToString = "WITHDRAWAL" Then
                        a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE_WITHDRAWAL").ToString)
                    ElseIf newsqldr.Item("type_of_purchasing").ToString = "CASH WITHOUT RR" Then
                        a(15) = FormatNumber(newsqldr.Item("WO_RR_PRICE").ToString)
                    Else
                        If (Not String.IsNullOrEmpty(newsqldr.Item("UNIT_PRICE").ToString)) Then
                            a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE").ToString)
                        Else
                            newsqldr.Item("QTY_WITHDRAWN").ToString()
                            a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE_WITHDRAWAL").ToString)
                        End If
                    End If

                    If newsqldr.Item("type_name").ToString = "WAREHOUSE" Then
                        a(17) = newsqldr.Item("CHARGE_TO_WAREHOUSE").ToString
                    ElseIf newsqldr.Item("type_name").ToString = "PROJECT" Then
                        a(17) = newsqldr.Item("CHARGE_TO_PROJECT").ToString
                    ElseIf newsqldr.Item("type_name").ToString = "EQUIPMENT" Then
                        a(17) = newsqldr.Item("CHARGE_TO_EQUIPMENT").ToString
                    ElseIf newsqldr.Item("type_name").ToString = "OTHERS" _
                        Or newsqldr.Item("type_name").ToString = "MAINOFFICE" _
                        Or newsqldr.Item("type_name").ToString = "PERSONAL" _
                         Or newsqldr.Item("type_name").ToString = "COMPANY" _
                            Or newsqldr.Item("type_name").ToString = "DIVISION" _
                            Or newsqldr.Item("type_name").ToString = "DEPARTMENT" _
                            Or newsqldr.Item("type_name").ToString = "SECTION" _
                            Or newsqldr.Item("type_name").ToString = "SHOPS" _
                            Or newsqldr.Item("type_name").ToString = "MOBILE CRUSHER" _
                            Or newsqldr.Item("type_name").ToString = "CRUSHER PLANT" _
                            Or newsqldr.Item("type_name").ToString = "BATCHING PLANT" _
                            Or newsqldr.Item("type_name").ToString = "WAREHOUSES" _
                            Or newsqldr.Item("type_name").ToString = "FABRICATION" _
                            Or newsqldr.Item("type_name").ToString = "BUNKHOUSE" _
                            Or newsqldr.Item("type_name").ToString = "OTHERS_NEW" _
                            Or newsqldr.Item("type_name").ToString = "PROPERTY CODES" _
                            Or newsqldr.Item("type_name").ToString = "HOUSE & LOT" _
                            Or newsqldr.Item("type_name").ToString = "SHIPYARD & DRY DOCKING" _
                            Or newsqldr.Item("type_name").ToString = "MOBILE VIBRATING SCREEN" _
                            Or newsqldr.Item("type_name").ToString = "TEMPORARY CODES" _
                            Then


                        a(17) = newsqldr.Item("CHARGE_TO_PER_MAIN_OTHERS").ToString
                    End If

                    'a(21) = newsqldr.Item("DATEDIFF").ToString
                    a(22) = newsqldr.Item("typeRequest").ToString + " - " + newsqldr.Item("tor_sub_desc").ToString

                    a(24) = "N/A"
                    a(25) = "N/A"
                    a(26) = "N/A"
                    a(28) = newsqldr.Item("type_of_purchasing").ToString
                    a(33) = newsqldr.Item("SUPPLIERS_TERMS").ToString

                    If cmbSearch.Text = "ALL" Then
                        a(35) = Format(Date.Parse(newsqldr.Item("DATE_LOG_REQUEST").ToString), "MM/dd/yyyy")
                        If newsqldr.Item("DATE_LOG_RECEIVED").ToString <> Nothing Then
                            a(36) = Format(Date.Parse(newsqldr.Item("DATE_LOG_RECEIVED").ToString), "MM/dd/yyyy")
                        Else
                            a(36) = "NULL"
                        End If
                    End If

                    If newsqldr.Item("type_of_purchasing").ToString = "WITHDRAWAL" Then
                        a(27) = "COMPLETED"
                    ElseIf (newsqldr.Item("type_of_purchasing").ToString = "PURCHASE ORDER") Or (newsqldr.Item("type_of_purchasing").ToString = "CASH") Then
                        If a(21) <> Nothing Then
                            a(27) = "COMPLETED"
                        Else
                            a(27) = ""
                        End If
                    End If

                    a(39) = newsqldr.Item("purpose").ToString

                    dtgSummarySupply.Rows.Add(a)

                End If

                For Each rw As DataGridViewRow In dtgSummarySupply.Rows
                    If rw.Cells(21).Value = "Served on Date" Then
                    ElseIf rw.Cells(28).Value = "WITHDRAWAL" Then

                    Else
                        rw.DefaultCellStyle.BackColor = Color.Red
                    End If
                Next

                For Each rw As DataGridViewRow In dtgSummarySupply.Rows
                    If rw.Cells(27).Value = "" Then
                        rw.Cells(27).Style.BackColor = Color.Blue
                    End If
                Next


                'For Each rw As DataGridViewRow In dtgSummarySupply.Rows
                '    'If rw.Cells(28).Value.ToString = "CASH" Then
                '    '    rw.DefaultCellStyle.BackColor = Color.LightSkyBlue
                '    'ElseIf rw.Cells(28).Value.ToString = "PURCHASE ORDER" Then
                '    '    rw.DefaultCellStyle.BackColor = Color.Lavender
                '    'ElseIf rw.Cells(28).Value.ToString = "WITHDRAWAL" Then
                '    '    rw.DefaultCellStyle.BackColor = Color.LightSteelBlue
                '    'End If
                '    If cmbSearch.Text = "RS NO." Or cmbSearch.Text = "PENDING REQUEST" Then
                '    Else
                '        If rw.Cells(34).Value.ToString < 0 Then
                '            rw.DefaultCellStyle.BackColor = Color.Red
                '        End If
                '    End If
                'Next

                'Application.DoEvents()

            End While
            newsqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & "error: " & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
            mthread.Abort()
        End Try


    End Sub
    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        cmbSearch.Text = ""
        panel_daterange_req.Visible = True
        btnSearch1.Text = "Preview"
        Label3.Visible = False
        ComboBox1.Enabled = False
        cmbSearch.Enabled = False
        btnSearch.Enabled = False

        'ComboBox1.Visible = False
        'Panel1.Width = 329
        'Panel1.Height = 181
        'Panel1.Location = New Point(552, 193)
        'Button2.Location = New Point(193, 130)
    End Sub
    Public Sub Save_Status()


    End Sub
    Public Sub addItems(ByVal col As AutoCompleteStringCollection)

        col.Add("Served on Date")
        col.Add("Served - By Requestors Choice")
        col.Add("Late - requestors choice")
        col.Add("Un-served Request")

    End Sub
    Private Sub dtgSummarySupply_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dtgSummarySupply.EditingControlShowing

        Dim titleText As String = dtgSummarySupply.Columns(21).HeaderText
        If titleText.Equals("REMARKS") Then
            Dim autoText As TextBox = TryCast(e.Control, TextBox)
            If autoText IsNot Nothing Then
                autoText.AutoCompleteMode = AutoCompleteMode.Suggest
                autoText.AutoCompleteSource = AutoCompleteSource.CustomSource
                Dim DataCollection As New AutoCompleteStringCollection()
                addItems(DataCollection)
                autoText.AutoCompleteCustomSource = DataCollection
            End If
        End If
    End Sub
    Private Sub pboxHeader_Click(sender As Object, e As EventArgs) Handles pboxHeader.Click

    End Sub

    Public Function Update_Reported_Request()

        MsgBox(datefrom)
        MsgBox(dateto)

        Try
            sqlcon.connection.Open()
            cmd = New SqlCommand("proc_summary_supply", sqlcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 0
            cmd.Parameters.Add("@dateFrom", SqlDbType.Date).Value = Format(Date.Parse(datefrom))
            cmd.Parameters.Add("@dateTo", SqlDbType.Date).Value = Format(Date.Parse(dateto))
            cmd.Parameters.Add("@dateFromLog", SqlDbType.Date).Value = Format(Date.Parse(datefromLog))
            cmd.Parameters.Add("@dateToLog", SqlDbType.Date).Value = Format(Date.Parse(datetoLog))
            cmd.Parameters.AddWithValue("@searchby", cmbSearch1.Text)
            cmd.Parameters.AddWithValue("@n", 55)

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & "error: " & Err.Description, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try

    End Function

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click


        Dim result As Integer = MessageBox.Show("Do you want to EXPORT and proceed to REPORT UPDATE?", "STATUS", MessageBoxButtons.YesNoCancel)

        If result = DialogResult.Cancel Then

        ElseIf result = DialogResult.No Then
            Dim xlApp As New Excel.Application

            Try

                SaveFileDialog1.Title = "Save Excel File"
                SaveFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx"
                SaveFileDialog1.ShowDialog()

                'exit if no file selected
                If SaveFileDialog1.FileName = "" Then
                    Exit Sub
                End If

                'create objects to interface to Excel
                Dim xls As New Excel.Application
                Dim book As Excel.Workbook
                Dim sheet As Excel.Worksheet

                Dim chartRange As Excel.Range

                'create a workbook and get reference to first worksheet
                xls.Workbooks.Add()
                book = xls.ActiveWorkbook
                sheet = book.ActiveSheet
                'step through rows and columns and copy data to worksheet
                Dim row As Integer = 2
                Dim col As Integer = 1
                Dim c As Integer = 1
                Dim excel_array() As String = New String() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"} ', "Z", "AA"} ', "AB", "AC", "AD"}
                Dim excel_index As Integer = 1
                Dim iii As Integer = 0

                sheet.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange, sheet.Range("$A$1:$Z$1"), , Excel.XlYesNoGuess.xlYes).Name = "Table1"

                '~~> Format the table
                sheet.ListObjects("Table1").TableStyle = "TableStyleLight9"

                sheet.Cells(1, 1) = "RS DATE"
                sheet.Cells(1, 2) = "PO/WS DATE"
                sheet.Cells(1, 3) = "QTY REQUESTED"
                sheet.Cells(1, 4) = "UNIT"
                sheet.Cells(1, 5) = "ITEM NAME"
                sheet.Cells(1, 6) = "RECEIVED/WITHDRAWN QTY"
                sheet.Cells(1, 7) = "REQUESTOR"
                sheet.Cells(1, 8) = "P.O. NO/W.S NO"
                sheet.Cells(1, 9) = "R.S. NO"
                sheet.Cells(1, 10) = "R.R. NO"
                sheet.Cells(1, 11) = "DATE OF RR."
                sheet.Cells(1, 12) = "UNIT PRICE"
                sheet.Cells(1, 13) = "CHARGES"
                sheet.Cells(1, 14) = "LEAD TIME R.S. TO P.O."
                sheet.Cells(1, 15) = "LEAD TIME P.O TO R.R."
                sheet.Cells(1, 16) = "SUPPLIER"
                sheet.Cells(1, 17) = "REMARKS"
                sheet.Cells(1, 18) = "TYPE OF REQUEST"
                sheet.Cells(1, 19) = "D.R, T.R, O.R/INVOICE"
                sheet.Cells(1, 20) = "S.O NO"
                sheet.Cells(1, 21) = "HAULER"
                sheet.Cells(1, 22) = "PLATE NO."
                sheet.Cells(1, 23) = "STATUS"
                sheet.Cells(1, 24) = "TYPE"
                sheet.Cells(1, 25) = "TERMS (days)"
                'sheet.Cells(1, 26) = "DATE LOG REQUEST"
                'sheet.Cells(1, 27) = "DATE LOG RECEIVED"
                'sheet.Cells(1, 28) = "JOB ORDER NO"
                'sheet.Cells(1, 29) = "LOCATION"
                sheet.Cells(1, 26) = "PURPOSE"

                'For Each item As ListViewItem In LVLEquipList.Items

                '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                Dim col1, row1 As Integer
                row1 = 2
                col1 = 1

                For i = 0 To dtgSummarySupply.Rows.Count - 1

                    'If dtgSummarySupply.Rows(i).Selected Then
                    'For ii = 1 To 28
                    '    sheet.Cells(row1, ii) = dtgSummarySupply.Rows(i).Cells(ii).Value
                    '    ' sheet.Cells(row1, ii) = LVLEquipList.Items(i).SubItems(ii).Text
                    '    col1 += 1
                    'Next

                    sheet.Cells(row1, 1) = dtgSummarySupply.Rows(i).Cells("col_rs_date").Value
                    sheet.Cells(row1, 2) = dtgSummarySupply.Rows(i).Cells("col_po_date").Value
                    sheet.Cells(row1, 3) = dtgSummarySupply.Rows(i).Cells("col_qty").Value
                    sheet.Cells(row1, 4) = dtgSummarySupply.Rows(i).Cells("col_unit").Value
                    sheet.Cells(row1, 5) = dtgSummarySupply.Rows(i).Cells("col_item_name").Value
                    sheet.Cells(row1, 6) = dtgSummarySupply.Rows(i).Cells("col_received_qty").Value
                    sheet.Cells(row1, 7) = dtgSummarySupply.Rows(i).Cells("col_requestor").Value
                    sheet.Cells(row1, 8) = dtgSummarySupply.Rows(i).Cells("col_po_no_and_ws_no").Value
                    sheet.Cells(row1, 9) = dtgSummarySupply.Rows(i).Cells("col_rs_no").Value
                    sheet.Cells(row1, 10) = dtgSummarySupply.Rows(i).Cells("col_rr_no").Value
                    sheet.Cells(row1, 11) = dtgSummarySupply.Rows(i).Cells("col_date_of_rr").Value
                    sheet.Cells(row1, 12) = dtgSummarySupply.Rows(i).Cells("col_unit_price").Value
                    sheet.Cells(row1, 13) = dtgSummarySupply.Rows(i).Cells("col_charges").Value
                    sheet.Cells(row1, 14) = dtgSummarySupply.Rows(i).Cells("col_lead_time_rs_to_po").Value
                    sheet.Cells(row1, 15) = dtgSummarySupply.Rows(i).Cells("col_lead_time_po_to_rr").Value
                    sheet.Cells(row1, 16) = dtgSummarySupply.Rows(i).Cells("col_supplier").Value
                    sheet.Cells(row1, 17) = dtgSummarySupply.Rows(i).Cells("col_remarks").Value
                    sheet.Cells(row1, 18) = dtgSummarySupply.Rows(i).Cells("col_type_of_request").Value
                    sheet.Cells(row1, 19) = dtgSummarySupply.Rows(i).Cells("col_invoice").Value
                    sheet.Cells(row1, 20) = dtgSummarySupply.Rows(i).Cells("col_so_no").Value
                    sheet.Cells(row1, 21) = dtgSummarySupply.Rows(i).Cells("col_hauler").Value
                    sheet.Cells(row1, 22) = dtgSummarySupply.Rows(i).Cells("col_plate_no").Value
                    sheet.Cells(row1, 23) = dtgSummarySupply.Rows(i).Cells("col_status").Value
                    sheet.Cells(row1, 24) = dtgSummarySupply.Rows(i).Cells("col_type").Value
                    sheet.Cells(row1, 25) = dtgSummarySupply.Rows(i).Cells("terms").Value
                    'sheet.Cells(row1, 26) = dtgSummarySupply.Rows(i).Cells("DATE_LOG_REQUEST").Value
                    'sheet.Cells(row1, 27) = dtgSummarySupply.Rows(i).Cells("DATE_LOG_RECEIVED").Value
                    'sheet.Cells(row1, 28) = dtgSummarySupply.Rows(i).Cells("Job_order_no").Value
                    'sheet.Cells(row1, 29) = dtgSummarySupply.Rows(i).Cells("Location").Value
                    sheet.Cells(row1, 26) = dtgSummarySupply.Rows(i).Cells("purpose").Value

                    col1 += 1
                    row1 += 1
                    'Else

                    'End If

                    chartRange = sheet.Range(excel_array(0) & 1, excel_array(24) & 1)

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

                Next

                '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                'save the workbook and clean up

                book.SaveAs(SaveFileDialog1.FileName)
                xls.Workbooks.Close()
                xls.Quit()
                releaseObject(sheet)
                releaseObject(book)
                releaseObject(xls)

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try


        ElseIf result = DialogResult.Yes Then
            If cmbSearch.Text = "ALL" Then
                Update_Reported_Request()
            Else

            End If

            Dim xlApp As New Excel.Application

            Try

                SaveFileDialog1.Title = "Save Excel File"
                SaveFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx"
                SaveFileDialog1.ShowDialog()

                'exit if no file selected
                If SaveFileDialog1.FileName = "" Then
                    Exit Sub
                End If

                'create objects to interface to Excel
                Dim xls As New Excel.Application
                Dim book As Excel.Workbook
                Dim sheet As Excel.Worksheet

                Dim chartRange As Excel.Range

                'create a workbook and get reference to first worksheet
                xls.Workbooks.Add()
                book = xls.ActiveWorkbook
                sheet = book.ActiveSheet
                'step through rows and columns and copy data to worksheet
                Dim row As Integer = 2
                Dim col As Integer = 1
                Dim c As Integer = 1
                Dim excel_array() As String = New String() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"} ', "Z", "AA"} ', "AB", "AC", "AD"}
                Dim excel_index As Integer = 1
                Dim iii As Integer = 0

                sheet.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange, sheet.Range("$A$1:$Z$1"), , Excel.XlYesNoGuess.xlYes).Name = "Table1"

                '~~> Format the table
                sheet.ListObjects("Table1").TableStyle = "TableStyleLight9"

                sheet.Cells(1, 1) = "RS DATE"
                sheet.Cells(1, 2) = "PO/WS DATE"
                sheet.Cells(1, 3) = "QTY REQUESTED"
                sheet.Cells(1, 4) = "UNIT"
                sheet.Cells(1, 5) = "ITEM NAME"
                sheet.Cells(1, 6) = "RECEIVED/WITHDRAWN QTY"
                sheet.Cells(1, 7) = "REQUESTOR"
                sheet.Cells(1, 8) = "P.O. NO/W.S NO"
                sheet.Cells(1, 9) = "R.S. NO"
                sheet.Cells(1, 10) = "R.R. NO"
                sheet.Cells(1, 11) = "DATE OF RR."
                sheet.Cells(1, 12) = "UNIT PRICE"
                sheet.Cells(1, 13) = "CHARGES"
                sheet.Cells(1, 14) = "LEAD TIME R.S. TO P.O."
                sheet.Cells(1, 15) = "LEAD TIME P.O TO R.R."
                sheet.Cells(1, 16) = "SUPPLIER"
                sheet.Cells(1, 17) = "REMARKS"
                sheet.Cells(1, 18) = "TYPE OF REQUEST"
                sheet.Cells(1, 19) = "D.R, T.R, O.R/INVOICE"
                sheet.Cells(1, 20) = "S.O NO"
                sheet.Cells(1, 21) = "HAULER"
                sheet.Cells(1, 22) = "PLATE NO."
                sheet.Cells(1, 23) = "STATUS"
                sheet.Cells(1, 24) = "TYPE"
                sheet.Cells(1, 25) = "TERMS (days)"
                'sheet.Cells(1, 26) = "DATE LOG REQUEST"
                'sheet.Cells(1, 27) = "DATE LOG RECEIVED"
                'sheet.Cells(1, 28) = "JOB ORDER NO"
                'sheet.Cells(1, 29) = "LOCATION"
                sheet.Cells(1, 26) = "PURPOSE"

                'For Each item As ListViewItem In LVLEquipList.Items

                '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                Dim col1, row1 As Integer
                row1 = 2
                col1 = 1

                For i = 0 To dtgSummarySupply.Rows.Count - 1

                    'If dtgSummarySupply.Rows(i).Selected Then
                    'For ii = 1 To 28
                    '    sheet.Cells(row1, ii) = dtgSummarySupply.Rows(i).Cells(ii).Value
                    '    ' sheet.Cells(row1, ii) = LVLEquipList.Items(i).SubItems(ii).Text
                    '    col1 += 1
                    'Next

                    sheet.Cells(row1, 1) = dtgSummarySupply.Rows(i).Cells("col_rs_date").Value
                    sheet.Cells(row1, 2) = dtgSummarySupply.Rows(i).Cells("col_po_date").Value
                    sheet.Cells(row1, 3) = dtgSummarySupply.Rows(i).Cells("col_qty").Value
                    sheet.Cells(row1, 4) = dtgSummarySupply.Rows(i).Cells("col_unit").Value
                    sheet.Cells(row1, 5) = dtgSummarySupply.Rows(i).Cells("col_item_name").Value
                    sheet.Cells(row1, 6) = dtgSummarySupply.Rows(i).Cells("col_received_qty").Value
                    sheet.Cells(row1, 7) = dtgSummarySupply.Rows(i).Cells("col_requestor").Value
                    sheet.Cells(row1, 8) = dtgSummarySupply.Rows(i).Cells("col_po_no_and_ws_no").Value
                    sheet.Cells(row1, 9) = dtgSummarySupply.Rows(i).Cells("col_rs_no").Value
                    sheet.Cells(row1, 10) = dtgSummarySupply.Rows(i).Cells("col_rr_no").Value
                    sheet.Cells(row1, 11) = dtgSummarySupply.Rows(i).Cells("col_date_of_rr").Value
                    sheet.Cells(row1, 12) = dtgSummarySupply.Rows(i).Cells("col_unit_price").Value
                    sheet.Cells(row1, 13) = dtgSummarySupply.Rows(i).Cells("col_charges").Value
                    sheet.Cells(row1, 14) = dtgSummarySupply.Rows(i).Cells("col_lead_time_rs_to_po").Value
                    sheet.Cells(row1, 15) = dtgSummarySupply.Rows(i).Cells("col_lead_time_po_to_rr").Value
                    sheet.Cells(row1, 16) = dtgSummarySupply.Rows(i).Cells("col_supplier").Value
                    sheet.Cells(row1, 17) = dtgSummarySupply.Rows(i).Cells("col_remarks").Value
                    sheet.Cells(row1, 18) = dtgSummarySupply.Rows(i).Cells("col_type_of_request").Value
                    sheet.Cells(row1, 19) = dtgSummarySupply.Rows(i).Cells("col_invoice").Value
                    sheet.Cells(row1, 20) = dtgSummarySupply.Rows(i).Cells("col_so_no").Value
                    sheet.Cells(row1, 21) = dtgSummarySupply.Rows(i).Cells("col_hauler").Value
                    sheet.Cells(row1, 22) = dtgSummarySupply.Rows(i).Cells("col_plate_no").Value
                    sheet.Cells(row1, 23) = dtgSummarySupply.Rows(i).Cells("col_status").Value
                    sheet.Cells(row1, 24) = dtgSummarySupply.Rows(i).Cells("col_type").Value
                    sheet.Cells(row1, 25) = dtgSummarySupply.Rows(i).Cells("terms").Value
                    'sheet.Cells(row1, 26) = dtgSummarySupply.Rows(i).Cells("DATE_LOG_REQUEST").Value
                    'sheet.Cells(row1, 27) = dtgSummarySupply.Rows(i).Cells("DATE_LOG_RECEIVED").Value
                    'sheet.Cells(row1, 28) = dtgSummarySupply.Rows(i).Cells("Job_order_no").Value
                    'sheet.Cells(row1, 29) = dtgSummarySupply.Rows(i).Cells("Location").Value
                    sheet.Cells(row1, 26) = dtgSummarySupply.Rows(i).Cells("purpose").Value

                    col1 += 1
                    row1 += 1
                    'Else

                    'End If

                    chartRange = sheet.Range(excel_array(0) & 1, excel_array(24) & 1)




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

                Next

                '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                'save the workbook and clean up

                book.SaveAs(SaveFileDialog1.FileName)
                xls.Workbooks.Close()
                xls.Quit()
                releaseObject(sheet)
                releaseObject(book)
                releaseObject(xls)

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try


            MessageBox.Show("Reported Status UPDATED!", "STATUS", MessageBoxButtons.OK)
        End If

    End Sub
    Public Sub loading()
        'Floading.ShowDialog()
    End Sub

    Public Sub releaseObject(ByVal obj As Object)
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        panel_dateRange_Log.Visible = False
        panel_chargeTo.Visible = False
        btnSearch.Enabled = True
        cmbSearch.Enabled = True
        btnSearch1.Text = "Search"
        btnSearch2.Text = "Search"

    End Sub

    Private Sub cmbSearch1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearch1.SelectedIndexChanged
        panel_daterange_req.Visible = True

        If cmbSearch.Text = "PURCHASED ORDER W/O RR" Then
            Label7.Text = "Request Date"
        Else
            Label7.Text = "PO Date"
        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        If dtgSummarySupply.Rows.Count > 0 Then
            For i = dtgSummarySupply.Rows.Count - 1 To 0 Step -1
                If dtgSummarySupply.Rows(i).Cells(19).Value.ToString.Contains(TextBox1.Text) Then
                Else
                    dtgSummarySupply.Rows.RemoveAt(i)
                End If
            Next
        End If

    End Sub

    Private Sub dtgSummarySupply_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgSummarySupply.CellContentClick

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub panel_daterange_req_Paint(sender As Object, e As PaintEventArgs) Handles panel_daterange_req.Paint
        category = ComboBox4.Text
        chargeTo = TextBox2.Text
    End Sub

    Private Sub panel_dateRange_Log_Paint(sender As Object, e As PaintEventArgs) Handles panel_dateRange_Log.Paint

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        panel_chargeTo.Visible = False
    End Sub

    Sub load_charges()
        Dim txt_project_desc As String = "SELECT [proj_id]
                                                  ,[project_desc]
                                                  ,[location]
                                                  ,[Contract_id]
                                                  ,[contract_name]
                                                  ,[project_duration]
                                                  ,[project_engineer]
                                                  ,[contract_amount]
                                                  ,[budgetary_amount]
                                                  ,[actual_amount]
                                              FROM [eus].[dbo].[dbprojectdesc]"
        Dim txt_charge_description As String = "SELECT a.[charge_desc_id]
                                                      ,a.[charge_cat_id]
                                                      ,b.Charge_cat_name
                                                      ,a.[description]
                                                      ,a.[code]
                                                  FROM [supply_db].[dbo].[dbcharge_description] a
                                                  inner join [supply_db].[dbo].[dbCharge_Category] b
	                                                on b.charge_cat_id = a.charge_cat_id"
        Dim txt_charge_to As String = "SELECT [charge_to_id]
                                              ,[charge_to]
                                              ,[type_name]
                                              ,[charge_desc_id]
                                          FROM [supply_db].[dbo].[dbCharge_to]"
        Dim txt_equipment_list As String = "SELECT [equipListID]
                                                  ,[equipUnitID]
                                                  ,[equipCatID]
                                                  ,[equipTypeID]
                                                  ,[plate_no]
                                                  ,[type_of_oil_id]
                                                  ,[operator_id]
                                              FROM [eus].[dbo].[dbequipment_list]"

        Dim txt_type_of_equipment As String = "select equip_typeOf as equip_type from dbequipment_type a"
        Try
            Dim cmd1 As SqlCommand
            Dim cmd2 As SqlCommand
            Dim cmd3 As SqlCommand
            Dim cmd4 As SqlCommand
            sqlcon.connection.Open()

            cmd1 = New SqlCommand(txt_project_desc, sqlcon.connection)
            cmd1.Parameters.Clear()
            cmd1.CommandType = CommandType.Text

            cmd2 = New SqlCommand(txt_charge_description, sqlcon.connection)
            cmd2.Parameters.Clear()
            cmd2.CommandType = CommandType.Text

            cmd3 = New SqlCommand(txt_charge_to, sqlcon.connection)
            cmd3.Parameters.Clear()
            cmd3.CommandType = CommandType.Text

            cmd4 = New SqlCommand(txt_equipment_list, sqlcon.connection)
            cmd4.Parameters.Clear()
            cmd4.CommandType = CommandType.Text

            ''''''''''''''''''''''''''''''''''''''''''''''''''
            dr = cmd1.ExecuteReader
            While dr.Read
                Dim items As New List(Of String)
                items.Add(dr(0).ToString)
                items.Add(dr(1).ToString)
                items.Add(dr(2).ToString)
                items.Add(dr(3).ToString)
                items.Add(dr(4).ToString)
                items.Add(dr(5).ToString)
                items.Add(dr(6).ToString)
                items.Add(dr(7).ToString)
                items.Add(dr(8).ToString)
                items.Add(dr(9).ToString)

                list_project_desc.Add(items)
            End While
            dr.Close()
            ''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''
            dr = cmd2.ExecuteReader
            While dr.Read
                Dim items As New List(Of String)
                items.Add(dr(0).ToString)
                items.Add(dr(1).ToString)
                items.Add(dr(2).ToString)
                items.Add(dr(3).ToString)
                items.Add(dr(4).ToString)

                list_charge_description.Add(items)
            End While
            dr.Close()
            ''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''
            dr = cmd3.ExecuteReader
            While dr.Read
                Dim items As New List(Of String)
                items.Add(dr(0).ToString)
                items.Add(dr(1).ToString)
                items.Add(dr(2).ToString)
                items.Add(dr(3).ToString)
                list_charge_to.Add(items)
            End While
            dr.Close()
            ''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''
            dr = cmd4.ExecuteReader
            While dr.Read
                Dim items As New List(Of String)
                items.Add(dr(0).ToString)
                items.Add(dr(1).ToString)
                items.Add(dr(2).ToString)
                items.Add(dr(3).ToString)
                items.Add(dr(4).ToString)
                items.Add(dr(5).ToString)
                items.Add(dr(6).ToString)
                list_equipment_list.Add(items)
            End While
            dr.Close()
            ''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & ex.StackTrace() & vbCrLf & "Info: " & ex.Message, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try
    End Sub
    Function set_category(ByVal project_name As String) As String
        Dim return_value As String = ""
        Dim has_value As Boolean = False

        For Each item As List(Of String) In list_charge_description
            If project_name.ToUpper.Equals(item(4).ToUpper) Then
                return_value = item(2)
                has_value = True
                Exit For
            End If
        Next

        If has_value = False Then
            For Each item As List(Of String) In list_project_desc
                If project_name.ToUpper.Equals(item(1).ToUpper) Then
                    return_value = "PROJECT CODE"
                    has_value = True
                    Exit For
                End If
            Next
        End If

        If has_value = False Then
            For Each item As List(Of String) In list_equipment_list
                If project_name.ToUpper.Equals(item(4).ToUpper) Then
                    return_value = "EQUIPMENT"
                    has_value = True
                    Exit For
                End If
            Next
        End If

        If has_value = False Then
            For Each item As List(Of String) In list_charge_to
                If project_name.ToUpper.Equals(item(1).ToUpper) Then
                    return_value = item(2)
                    has_value = True
                    Exit For
                End If
            Next
        End If
        If has_value = False Then
            return_value = "N/A"
        End If
        Return return_value
    End Function

    Sub load_project_name()
        Dim project_names As New AutoCompleteStringCollection
        For Each item As List(Of String) In list_charge_description
            project_names.Add(item(4))
        Next

        For Each item As List(Of String) In list_project_desc
            project_names.Add(item(1))
        Next

        For Each item As List(Of String) In list_equipment_list
            project_names.Add(item(4))
        Next

        For Each item As List(Of String) In list_charge_to
            project_names.Add(item(1))
        Next

        TextBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        TextBox2.AutoCompleteSource = AutoCompleteSource.CustomSource
        TextBox2.AutoCompleteCustomSource = project_names
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        ComboBox4.Text = set_category(TextBox2.Text)
    End Sub

    Private Sub btnSearch3_Click(sender As Object, e As EventArgs) Handles btnSearch3.Click
        category = ComboBox4.Text
        chargeTo = TextBox2.Text
        Label7.Text = "Date Request"
        panel_chargeTo.Visible = False
        panel_daterange_req.Visible = True

    End Sub

    Public Sub SummarySupply_ChargeTo(ByVal n As Integer, category As String, chargeTo As String)

        dtgSummarySupply.Rows.Clear()

        panel_dateRange_Log.Visible = False
        Dim mthread As New Threading.Thread(AddressOf loading)
        mthread.Start()

        Dim newsqlcon As New SQLcon
        Dim newsqldr As SqlDataReader
        Dim newcmd As SqlCommand
        Dim a(40) As String
        Try
            newsqlcon.connection.Open()
            newcmd = New SqlCommand("proc_summary_supply", newsqlcon.connection)
            newcmd.CommandTimeout = 0
            newcmd.Parameters.Clear()
            newcmd.CommandType = CommandType.StoredProcedure
            newcmd.Parameters.AddWithValue("@n", 13)
            newcmd.Parameters.Add("@dateFrom", SqlDbType.Date).Value = Format(Date.Parse(datefrom))
            newcmd.Parameters.Add("@dateTo", SqlDbType.Date).Value = Format(Date.Parse(dateto))
            newcmd.Parameters.AddWithValue("@typename1", ComboBox4.Text)
            newcmd.Parameters.AddWithValue("@chargeTo", TextBox2.Text)
            newsqldr = newcmd.ExecuteReader

            While newsqldr.Read

                a(0) = dtgSummarySupply.RowCount
                a(1) = newsqldr.Item("rs_id").ToString
                a(2) = Format(Date.Parse(newsqldr.Item("date_req").ToString), "MM/dd/yyyy")
                a(4) = newsqldr.Item("rr_item_id").ToString

                'a(25) = newsqldr.Item("plate_no").ToString ''''' FOR HAULING FUNCTION '''
                'a(12) = Format(Date.Parse(newsqldr.Item("DATE_RECEIVED").ToString), "MM/dd/yy")


                If newsqldr.Item("po_date").ToString <> Nothing Then
                        a(3) = Format(Date.Parse(newsqldr.Item("po_date").ToString), "MM/dd/yyyy")
                        'a(14) = Format(Date.Parse(newsqldr.Item("date_needed").ToString), "MM/dd/yyyy")
                        'a(18) = po(a(2), a(3))
                    ElseIf newsqldr.Item("rr_item_id").ToString <> Nothing Then
                        a(13) = Format(Date.Parse(newsqldr.Item("DATE_RECEIVED").ToString), "MM/dd/yyyy")
                        'a(19) = po(a(3), a(13))
                        'a(34) = interval_needed_received(a(13), Format(Date.Parse(newsqldr.Item("date_needed").ToString), "MM/dd/yyyy"))
                    Else
                        'a(3) = Format(Date.Parse(newsqldr.Item("po_date").ToString), "MM/dd/yyyy")
                        a(5) = newsqldr.Item("QTY_REQUESTED").ToString ' / newsqldr.Item("NO_OF_CHARGES").ToString
                        a(10) = ""
                        a(12) = ""
                        'a(13) = Format(Date.Parse(newsqldr.Item("DATE_LOG_WITHDRAW").ToString), "MM/dd/yyyy")
                        a(13) = Format(Date.Parse(newsqldr.Item("DATE_RECEIVED").ToString), "MM/dd/yyyy")
                        a(18) = ""
                        a(19) = ""
                        a(27) = ""
                    End If

                    'If newsqldr.Item("type_of_purchasing").ToString = "WITHDRAWAL" Then
                    '    a(5) = newsqldr.Item("QTY_REQUESTED").ToString
                    'End If

                    If newsqldr.Item("rr_item_id").ToString <> Nothing Then
                        a(5) = newsqldr.Item("QTY_REQUESTED").ToString / newsqldr.Item("NO_OF_CHARGES").ToString
                        a(13) = Format(Date.Parse(newsqldr.Item("DATE_RECEIVED").ToString), "MM/dd/yyyy")
                        'a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE").ToString)
                        'a(19) = po(a(3), a(13))
                        a(20) = newsqldr.Item("SUPPLIER_NAME").ToString
                        a(21) = newsqldr.Item("remarks").ToString
                        a(23) = newsqldr.Item("invoice_no").ToString
                    Else
                        'a(3) = Format(Date.Parse(newsqldr.Item("po_date").ToString), "MM/dd/yyyy")
                        a(5) = newsqldr.Item("QTY_REQUESTED").ToString
                        'a(13) = Format(Date.Parse(newsqldr.Item("DATE_LOG_WITHDRAW").ToString), "MM/dd/yyyy")
                        'a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE_WITHDRAWAL").ToString)
                        'a(19) = po(a(3), a(13))
                        a(20) = "N/A"
                        a(21) = newsqldr.Item("remarks_status").ToString
                        a(23) = "N/A"
                    End If

                    'End If

                    a(6) = newsqldr.Item("unit").ToString
                    'a(7) = newsqldr.Item("whItem").ToString + " - " + newsqldr.Item("whItemDesc").ToString
                    a(7) = newsqldr.Item("whItem").ToString + " --- " + newsqldr.Item("itemDesc_request").ToString + " --- " + newsqldr.Item("whItemDesc_receiving_withdrawal").ToString

                    'If newsqldr.Item("rr_item_id").ToString <> Nothing Then
                    '    a(8) = newsqldr.Item("QTY_RECEIVED").ToString
                    '    a(12) = newsqldr.Item("rr_no").ToString
                    'Else
                    '    'a(8) = newsqldr.Item("QTY_WITHDRAWN").ToString
                    '    a(12) = "N/A"
                    'End If

                    If (Not String.IsNullOrEmpty(newsqldr.Item("rr_item_id").ToString)) Then
                        a(8) = newsqldr.Item("QTY_RECEIVED").ToString
                        a(12) = newsqldr.Item("rr_no").ToString
                    Else
                        a(8) = newsqldr.Item("QTY_WITHDRAWN").ToString
                    End If


                    a(9) = newsqldr.Item("requested_by").ToString
                    a(10) = newsqldr.Item("po_no").ToString
                    a(11) = newsqldr.Item("rs_no").ToString


                    If newsqldr.Item("type_of_purchasing").ToString = "WITHDRAWAL" Then
                        a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE_WITHDRAWAL").ToString)
                    ElseIf newsqldr.Item("type_of_purchasing").ToString = "CASH WITHOUT RR" Then
                        a(15) = FormatNumber(newsqldr.Item("WO_RR_PRICE").ToString)
                    ElseIf newsqldr.Item("type_of_purchasing").ToString = "CASH WITH RR" Then
                        a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE").ToString)
                    Else
                        If (Not String.IsNullOrEmpty(newsqldr.Item("UNIT_PRICE").ToString)) Then
                            a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE").ToString)
                        Else
                            a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE_WITHDRAWAL").ToString)
                        End If

                        'If newsqldr.Item("UNIT_PRICE").ToString = "0" Or newsqldr.Item("UNIT_PRICE").ToString.IsNullOrEmpty Then
                        '    a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE_WITHDRAWAL").ToString)
                        'Else
                        '    a(15) = FormatNumber(newsqldr.Item("UNIT_PRICE").ToString)
                        'End If
                    End If


                    If newsqldr.Item("type_name").ToString = "WAREHOUSE" Then
                        a(17) = newsqldr.Item("CHARGE_TO_WAREHOUSE").ToString
                    ElseIf newsqldr.Item("type_name").ToString = "PROJECT" Then
                        a(17) = newsqldr.Item("CHARGE_TO_PROJECT").ToString
                    ElseIf newsqldr.Item("type_name").ToString = "EQUIPMENT" Then
                        a(17) = newsqldr.Item("CHARGE_TO_EQUIPMENT").ToString
                    ElseIf newsqldr.Item("type_name").ToString = "OTHERS" _
                            Or newsqldr.Item("type_name").ToString = "MAINOFFICE" _
                            Or newsqldr.Item("type_name").ToString = "PERSONAL" _
                            Or newsqldr.Item("type_name").ToString = "COMPANY" _
                            Or newsqldr.Item("type_name").ToString = "DIVISION" _
                            Or newsqldr.Item("type_name").ToString = "DEPARTMENT" _
                            Or newsqldr.Item("type_name").ToString = "SECTION" _
                            Or newsqldr.Item("type_name").ToString = "SHOPS" _
                            Or newsqldr.Item("type_name").ToString = "MOBILE CRUSHER" _
                            Or newsqldr.Item("type_name").ToString = "CRUSHER PLANT" _
                            Or newsqldr.Item("type_name").ToString = "BATCHING PLANT" _
                            Or newsqldr.Item("type_name").ToString = "WAREHOUSES" _
                            Or newsqldr.Item("type_name").ToString = "FABRICATION" _
                            Or newsqldr.Item("type_name").ToString = "BUNKHOUSE" _
                            Or newsqldr.Item("type_name").ToString = "OTHERS_NEW" _
                            Or newsqldr.Item("type_name").ToString = "PROPERTY CODES" _
                           Or newsqldr.Item("type_name").ToString = "HOUSE & LOT" Then
                        a(17) = newsqldr.Item("CHARGE_TO_PER_MAIN_OTHERS").ToString
                    End If

                    'a(21) = newsqldr.Item("DATEDIFF").ToString
                    a(22) = newsqldr.Item("typeRequest").ToString + " - " + newsqldr.Item("tor_sub_desc").ToString

                    a(24) = "N/A"
                    a(25) = "N/A"
                    a(26) = "N/A"
                    a(28) = newsqldr.Item("type_of_purchasing").ToString
                    a(33) = newsqldr.Item("SUPPLIERS_TERMS").ToString

                    If cmbSearch.Text = "ALL" Then
                        a(35) = Format(Date.Parse(newsqldr.Item("DATE_LOG_REQUEST").ToString), "MM/dd/yyyy")
                        If newsqldr.Item("DATE_LOG_RECEIVED").ToString <> Nothing Then
                            a(36) = Format(Date.Parse(newsqldr.Item("DATE_LOG_RECEIVED").ToString), "MM/dd/yyyy")
                        Else
                            a(36) = "NULL"
                        End If
                    End If

                    If newsqldr.Item("type_of_purchasing").ToString = "WITHDRAWAL" Then
                        a(27) = "COMPLETED"
                    ElseIf (newsqldr.Item("type_of_purchasing").ToString = "PURCHASE ORDER") Or (newsqldr.Item("type_of_purchasing").ToString = "CASH") Or (newsqldr.Item("type_of_purchasing").ToString = "CASH WITH RR") Or (newsqldr.Item("type_of_purchasing").ToString = "CASH WITHOUT RR") Then
                        If a(21) <> Nothing Then
                            a(27) = "COMPLETED"
                        Else
                            a(27) = ""
                        End If
                    End If

                    a(39) = newsqldr.Item("purpose").ToString

                    dtgSummarySupply.Rows.Add(a)

                For Each rw As DataGridViewRow In dtgSummarySupply.Rows
                    If rw.Cells(21).Value = "Served on Date" Then
                    ElseIf rw.Cells(28).Value = "WITHDRAWAL" Then

                    Else
                        rw.DefaultCellStyle.BackColor = Color.Red
                    End If
                Next

                For Each rw As DataGridViewRow In dtgSummarySupply.Rows
                    If rw.Cells(27).Value = "" Then
                        rw.Cells(27).Style.BackColor = Color.Blue
                    End If
                Next


                'For Each rw As DataGridViewRow In dtgSummarySupply.Rows
                '    'If rw.Cells(28).Value.ToString = "CASH" Then
                '    '    rw.DefaultCellStyle.BackColor = Color.LightSkyBlue
                '    'ElseIf rw.Cells(28).Value.ToString = "PURCHASE ORDER" Then
                '    '    rw.DefaultCellStyle.BackColor = Color.Lavender
                '    'ElseIf rw.Cells(28).Value.ToString = "WITHDRAWAL" Then
                '    '    rw.DefaultCellStyle.BackColor = Color.LightSteelBlue
                '    'End If
                '    If cmbSearch.Text = "RS NO." Or cmbSearch.Text = "PENDING REQUEST" Then
                '    Else
                '        If rw.Cells(34).Value.ToString < 0 Then
                '            rw.DefaultCellStyle.BackColor = Color.Red
                '        End If
                '    End If
                'Next

                'Application.DoEvents()

            End While
            newsqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & "error: " & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
            mthread.Abort()
        End Try


    End Sub
End Class