Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FBorrowed_Item_Monitoring
    Public pub_bs_id As Integer
    Public txtname1 As String
    Public pub_textbox As TextBox
    Public pub_combox As ComboBox
    Public pub_button As Button

    Dim panloc As New Point(0, 0)
    Dim curloc As New Point(0, 0)

    Public ifsearch As Integer
    Public whatcolor As String
    Public trd As Threading.Thread

    Private Sub FBorrowed_Item_Monitoring_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            clear_field()
            txtReleased.Text = "Christopher Q. Balbin"
            txtNotedBy.Text = "Vanessa F. Piedad"
            txtApproved_by.Text = "Mercy Fe G. Cupay"
            txtRemarks.Text = "N/A"
            txtBsNo.Text = 0
            txtBsNo.Focus()

            txtBsNo.Enabled = True
            PanelBsForm_Save.Text = "Save (Ctrl + S)"
            lvlBorrowerList.Enabled = True

        ElseIf e.KeyCode = Keys.F1 Then
            save_update_function(1)
        ElseIf e.KeyCode = Keys.F2 Then
            save_update_function(2)
        ElseIf e.Control And e.KeyCode = Keys.S Then
            PanelBsForm_Save.PerformClick()
        End If
    End Sub
    Public Sub save_update_function(ByVal n As Integer)

        If n = 1 Then
            borrower_edit = 1
            FOldFacilities.btnSave.Text = "Save (Ctrl + S)"
            FOldFacilities.ShowDialog()

        ElseIf n = 2 Then
            borrower_edit = 2

            If lvList.SelectedItems.Count > 0 Then
                edit_facilities(CInt(lvList.SelectedItems(0).Text))
            Else
                MessageBox.Show("Please an item first..", "Borrower Info:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If



    End Sub
    Public Sub clear_field()
        For Each ctr As Control In PanelBSForm.Controls
            If TypeOf ctr Is TextBox Then
                Dim tbox As TextBox = ctr
                tbox.Clear()

            End If
        Next
        cmbTypeofCharge.SelectedIndex = -1
        cmbChargeTo.SelectedIndex = -1
        cmbtype.SelectedIndex = -1
        cmbChargeTo1.SelectedIndex = -1
    End Sub

    Private Sub FBorrowed_Item_Monitoring_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'LOAD_facilities_item()

        cmbListOfFacilitiesTools.Items.Clear()

        For Each ctr As Control In PanelBSForm.Controls

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

        ' load_all_items_borrow("all")

    End Sub

    Public Sub load_all_items_borrow(ByVal stat As String)
        pub_bs_id = Nothing
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim counter As Integer

        lvList.Items.Clear()


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_facilities", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 29)
            newCMD.Parameters.AddWithValue("@fac_name", cmbListOfFacilitiesTools.Text)
            newCMD.Parameters.AddWithValue("@borrow_type", cmbTypeofFacTools.Text)
            newCMD.Parameters.AddWithValue("@bs_no", "")

            newDR = newCMD.ExecuteReader

            Dim a(16) As String


            While newDR.Read
                Dim bs_no As String = get_some_data_from_borrower_slip(CInt(newDR.Item("fi_id").ToString), 3)
                Dim bs_id As Integer = get_some_data_from_borrower_slip(CInt(newDR.Item("fi_id").ToString), 7)

                a(0) = newDR.Item("fi_id").ToString
                a(1) = newDR.Item("no").ToString
                a(2) = newDR.Item("RS_NO").ToString
                a(3) = newDR.Item("PO_NO").ToString
                a(4) = IIf(get_rr_no(newDR.Item("po_det_id").ToString) = "", "", get_rr_no(newDR.Item("po_det_id").ToString))
                a(5) = newDR.Item("date_aquired").ToString
                a(6) = 1
                a(7) = newDR.Item("facility_name").ToString
                a(8) = newDR.Item("brand").ToString
                a(9) = UCase(get_some_data_from_borrower_slip(CInt(newDR.Item("fi_id").ToString), 2)) ' get_charges_name(CInt(newDR.Item("custodian").ToString), newDR.Item("type_of_custodian").ToString)
                a(10) = get_some_data_from_borrower_slip(CInt(newDR.Item("fi_id").ToString), 1) ' get_charges_name(CInt(newDR.Item("received_to").ToString), newDR.Item("type_of_received").ToString)
                a(12) = newDR.Item("remarks").ToString
                a(13) = newDR.Item("BS_NO").ToString ' bs_no
                a(14) = get_some_data_from_borrower_slip(CInt(newDR.Item("fi_id").ToString), 4)
                a(11) = IIf(get_some_item_from_borrower_turnover(bs_no, 0, bs_id) = "", "Functional", get_some_item_from_borrower_turnover(bs_no, 0, bs_id))
                a(16) = newDR.Item("po_det_id").ToString

                Dim alreadyturnover As Integer = check_if_bsturnover_exist(CInt(newDR.Item("fi_id").ToString), get_some_data_from_borrower_slip(CInt(newDR.Item("fi_id").ToString), 5))

                If alreadyturnover > 0 Then
                    a(9) = get_some_item_from_borrower_turnover(bs_no, 1, bs_id)

                    a(10) = get_multiple_charges(CInt(bs_id), "Turnover") 'get_some_item_from_borrower_turnover(bs_no, 2, bs_id)
                    If a(10).Length < 1 Then
                    Else
                        a(10) = a(10).Trim().Substring(0, a(10).Length - 1)
                    End If

                    a(13) = ""
                    a(15) = "TURNOVER - " & IIf(a(11) = "Functional", "AVAILABLE", "NOT AVAILABLE")

                Else
                    a(10) = get_multiple_charges(CInt(bs_id), "Borrow") 'get_some_item_from_borrower_turnover(bs_no, 2, bs_id)
                    If a(10).Length < 1 Then
                    Else
                        a(10) = a(10).Trim().Substring(0, a(10).Length - 1)
                    End If

                    If check_if_exist("dbBorrower_Slip", "fi_id", CInt(newDR.Item("fi_id").ToString), 1) > 0 Then
                        a(5) = Format(Date.Parse(get_some_data_from_borrower_slip(CInt(newDR.Item("fi_id").ToString), 6)), "MM/dd/yyyy")
                        a(15) = "WAITING..."
                    Else
                        a(15) = "AVAILABLE"
                    End If


                End If

                If stat = "Waiting" Then
                    If a(15) = "WAITING..." Then
                        Dim lvl As New ListViewItem(a)
                        lvList.Items.Add(lvl)

                        If by_color_monitoring(CInt(newDR.Item("fi_id").ToString)) = "orange" Then
                            lvList.Items(counter).BackColor = Color.Orange
                            lvList.Items(counter).ForeColor = Color.White

                        ElseIf by_color_monitoring(CInt(newDR.Item("fi_id").ToString)) = "red" Then
                            lvList.Items(counter).BackColor = Color.Red
                            lvList.Items(counter).ForeColor = Color.White

                        ElseIf by_color_monitoring(CInt(newDR.Item("fi_id").ToString)) = "yellowgreen" Then
                            lvList.Items(counter).BackColor = Color.GreenYellow
                            lvList.Items(counter).ForeColor = Color.Black

                        ElseIf by_color_monitoring(CInt(newDR.Item("fi_id").ToString)) = "white" Then
                            lvList.Items(counter).BackColor = Color.White
                            lvList.Items(counter).ForeColor = Color.Black

                        End If

                        counter += 1
                    End If

                ElseIf stat = "Turnover - Available" Then
                    If a(15) = "TURNOVER - AVAILABLE" Then
                        Dim lvl As New ListViewItem(a)
                        lvList.Items.Add(lvl)

                        If by_color_monitoring(CInt(newDR.Item("fi_id").ToString)) = "orange" Then
                            lvList.Items(counter).BackColor = Color.Orange
                            lvList.Items(counter).ForeColor = Color.White

                        ElseIf by_color_monitoring(CInt(newDR.Item("fi_id").ToString)) = "red" Then
                            lvList.Items(counter).BackColor = Color.Red
                            lvList.Items(counter).ForeColor = Color.White

                        ElseIf by_color_monitoring(CInt(newDR.Item("fi_id").ToString)) = "yellowgreen" Then
                            lvList.Items(counter).BackColor = Color.GreenYellow
                            lvList.Items(counter).ForeColor = Color.Black

                        ElseIf by_color_monitoring(CInt(newDR.Item("fi_id").ToString)) = "white" Then
                            lvList.Items(counter).BackColor = Color.White
                            lvList.Items(counter).ForeColor = Color.Black

                        End If

                        counter += 1
                    End If

                ElseIf stat = "Turnover - Not Available" Then
                    If a(15) = "TURNOVER - NOT AVAILABLE" Then
                        Dim lvl As New ListViewItem(a)
                        lvList.Items.Add(lvl)

                        If by_color_monitoring(CInt(newDR.Item("fi_id").ToString)) = "orange" Then
                            lvList.Items(counter).BackColor = Color.Orange
                            lvList.Items(counter).ForeColor = Color.White

                        ElseIf by_color_monitoring(CInt(newDR.Item("fi_id").ToString)) = "red" Then
                            lvList.Items(counter).BackColor = Color.Red
                            lvList.Items(counter).ForeColor = Color.White

                        ElseIf by_color_monitoring(CInt(newDR.Item("fi_id").ToString)) = "yellowgreen" Then
                            lvList.Items(counter).BackColor = Color.GreenYellow
                            lvList.Items(counter).ForeColor = Color.Black

                        ElseIf by_color_monitoring(CInt(newDR.Item("fi_id").ToString)) = "white" Then
                            lvList.Items(counter).BackColor = Color.White
                            lvList.Items(counter).ForeColor = Color.Black

                        End If

                        counter += 1
                    End If

                ElseIf stat = "Available" Then

                    If a(15) = "AVAILABLE" Then

                        Dim lvl As New ListViewItem(a)
                        lvList.Items.Add(lvl)

                        If by_color_monitoring(CInt(newDR.Item("fi_id").ToString)) = "orange" Then
                            lvList.Items(counter).BackColor = Color.Orange
                            lvList.Items(counter).ForeColor = Color.White

                        ElseIf by_color_monitoring(CInt(newDR.Item("fi_id").ToString)) = "red" Then
                            lvList.Items(counter).BackColor = Color.Red
                            lvList.Items(counter).ForeColor = Color.White

                        ElseIf by_color_monitoring(CInt(newDR.Item("fi_id").ToString)) = "yellowgreen" Then
                            lvList.Items(counter).BackColor = Color.GreenYellow
                            lvList.Items(counter).ForeColor = Color.Black

                        ElseIf by_color_monitoring(CInt(newDR.Item("fi_id").ToString)) = "white" Then
                            lvList.Items(counter).BackColor = Color.White
                            lvList.Items(counter).ForeColor = Color.Black

                        End If

                        counter += 1

                        
                    End If
                End If

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
            loading_effect_end()
        End Try
    End Sub

    Public Sub loading_effect_end()

        For Each itm As Control In Me.Controls
            If itm.Name = "Panel2" Then
                itm.Visible = False
            Else
                itm.Enabled = True
            End If
        Next
    End Sub

    Public Sub LOAD_facilities_item()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim counter As Integer

        lvList.Items.Clear()


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_facilities", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 12)
            newCMD.Parameters.AddWithValue("@fac_name", cmbListOfFacilitiesTools.Text)
            newCMD.Parameters.AddWithValue("@borrow_type", cmbTypeofFacTools.Text)

            newDR = newCMD.ExecuteReader

            Dim a(30) As String
            While newDR.Read
                Dim bs_no As String = get_some_data_from_borrower_slip(CInt(newDR.Item("fi_id").ToString), 3)
                Dim bs_id As Integer = get_some_data_from_borrower_slip(CInt(newDR.Item("fi_id").ToString), 7)

                a(0) = newDR.Item("fi_id").ToString
                a(1) = newDR.Item("no").ToString

                Dim type_of_purchasing As String = newDR.Item("type_of_purchasing").ToString
                Dim cv_item_id As Integer = CInt(newDR.Item("po_det_id").ToString)
                Dim rs_id As Integer = get_rs_id_from_pocv_item(cv_item_id, type_of_purchasing)
                Dim query As String
                Dim rr_exist As Integer = check_if_exist("dbreceiving_items", "rs_id", rs_id, 1)

                If type_of_purchasing = "CASH" Then 'og no cv ad rr and rs
                    If rr_exist > 0 Then
                        query = "SELECT item_description FROM dbreceiving_items WHERE rs_id = " & rs_id
                    Else
                        query = "SELECT cv_itemDesc FROM dbCashVoucher_items WHERE rs_id = " & rs_id
                    End If


                    a(2) = newDR.Item("RS_NO").ToString
                    a(3) = "CV No: " & newDR.Item("PO_NO").ToString
                    a(8) = get_specific_column_value(query, 0)

                ElseIf type_of_purchasing = "PURCHASE ORDER" Then 'og no po and rr and rs
                    If rr_exist > 0 Then
                        query = "SELECT item_description FROM dbreceiving_items WHERE rs_id = " & rs_id
                    Else
                        query = "SELECT item_desc FROM dbPO_details WHERE rs_id = " & rs_id
                    End If


                    a(2) = newDR.Item("RS_NO").ToString
                    a(3) = "PO. No: " & newDR.Item("PO_NO").ToString
                    a(8) = get_specific_column_value(query, 0)

                ElseIf type_of_purchasing = "" Then 'if no po and rr and rs
                    a(2) = ""
                    a(3) = "No CV No. and PO. No."
                    a(8) = newDR.Item("brand").ToString

                End If

                'a(3) = IIf(newDR.Item("type_of_purchasing").ToString = "CASH", "CV NO: " & newDR.Item("PO_NO").ToString, "PO. NO: " & newDR.Item("PO_NO").ToString)
                a(4) = "RR NO: " & IIf(get_rr_no(rs_id) = "", "", get_rr_no(rs_id))
                a(5) = newDR.Item("date_aquired").ToString
                a(6) = 1
                a(7) = newDR.Item("facility_name").ToString


                a(9) = UCase(get_some_data_from_borrower_slip(CInt(newDR.Item("fi_id").ToString), 2)) ' get_charges_name(CInt(newDR.Item("custodian").ToString), newDR.Item("type_of_custodian").ToString)
                a(10) = get_some_data_from_borrower_slip(CInt(newDR.Item("fi_id").ToString), 1) ' get_charges_name(CInt(newDR.Item("received_to").ToString), newDR.Item("type_of_received").ToString)
                a(12) = newDR.Item("remarks").ToString
                a(13) = bs_no
                a(14) = get_some_data_from_borrower_slip(CInt(newDR.Item("fi_id").ToString), 4)
                a(11) = IIf(get_some_item_from_borrower_turnover(bs_no, 0, bs_id) = "", "Functional", get_some_item_from_borrower_turnover(bs_no, 0, bs_id))
                a(16) = newDR.Item("po_det_id").ToString
                a(17) = newDR.Item("fac_tools").ToString

                Dim alreadyturnover As Integer = check_if_bsturnover_exist(CInt(newDR.Item("fi_id").ToString), get_some_data_from_borrower_slip(CInt(newDR.Item("fi_id").ToString), 5))

                If alreadyturnover > 0 Then
                    a(9) = UCase(get_some_item_from_borrower_turnover(bs_no, 1, bs_id))

                    a(10) = get_multiple_charges(CInt(bs_id), "Turnover") 'get_some_item_from_borrower_turnover(bs_no, 2, bs_id)
                    If a(10).Length < 1 Then
                    Else
                        a(10) = a(10).Trim().Substring(0, a(10).Length - 1)
                    End If

                    a(13) = ""
                    a(15) = "TURNOVER - " & IIf(a(11) = "Functional", "AVAILABLE", "NOT AVAILABLE")

                Else
                    a(10) = get_multiple_charges(CInt(bs_id), "Borrow") 'get_some_item_from_borrower_turnover(bs_no, 2, bs_id)
                    If a(10).Length < 1 Then
                    Else
                        a(10) = a(10).Trim().Substring(0, a(10).Length - 1)
                    End If

                    If check_if_exist("dbBorrower_Slip", "fi_id", CInt(newDR.Item("fi_id").ToString), 1) > 0 Then
                        a(5) = Format(Date.Parse(get_some_data_from_borrower_slip(CInt(newDR.Item("fi_id").ToString), 6)), "MM/dd/yyyy")
                        a(15) = "WAITING..."
                    Else
                        a(15) = "AVAILABLE"
                    End If

                End If

                Dim lvl As New ListViewItem(a)
                lvList.Items.Add(lvl)

                If by_color_monitoring(CInt(newDR.Item("fi_id").ToString)) = "orange" Then
                    lvList.Items(counter).BackColor = Color.Orange
                    lvList.Items(counter).ForeColor = Color.White

                ElseIf by_color_monitoring(CInt(newDR.Item("fi_id").ToString)) = "red" Then
                    lvList.Items(counter).BackColor = Color.Red
                    lvList.Items(counter).ForeColor = Color.White

                ElseIf by_color_monitoring(CInt(newDR.Item("fi_id").ToString)) = "yellowgreen" Then
                    lvList.Items(counter).BackColor = Color.GreenYellow
                    lvList.Items(counter).ForeColor = Color.Black

                ElseIf by_color_monitoring(CInt(newDR.Item("fi_id").ToString)) = "white" Then
                    lvList.Items(counter).BackColor = Color.White
                    lvList.Items(counter).ForeColor = Color.Black

                End If

                counter += 1


            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
            loading_effect_end()

        End Try
    End Sub
    Public Function get_rs_id_from_pocv_item(ByVal id As Integer, ByVal type_of_purchasing As String) As Integer

        If type_of_purchasing = "PURCHASE ORDER" Then
            Dim query As String = "SELECT rs_id FROM dbPO_details WHERE po_det_id = " & id
            get_rs_id_from_pocv_item = get_specific_column_value(query, 1)

        ElseIf type_of_purchasing = "CASH" Then
            Dim query As String = "SELECT rs_id FROM dbCashVoucher_items WHERE cv_items_id = " & id
            get_rs_id_from_pocv_item = get_specific_column_value(query, 1)

        End If

    End Function
    'Public Function get_fac_id(ByVal fac_tools As String, ByVal brand As String) As Integer
    '    Dim newSQ As New SQLcon
    '    Dim newCMD As SqlCommand
    '    Dim newDR As SqlDataReader

    '    Try
    '        newSQ.connection.Open()
    '        Dim query As String = "SELECT * FROM dbBorrower_Slip_Turnover WHERE fi_id = " & fi_id & " AND borrower_slip_id = " & bs_id

    '        newCMD = New SqlCommand(query, newSQ.connection)
    '        newDR = newCMD.ExecuteReader
    '        While newDR.Read

    '        End While

    '        newDR.Close()

    '    Catch ex As Exception
    '        MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        newSQ.connection.Close()
    '    End Try
    'End Function

    Public Function check_if_bsturnover_exist(ByVal fi_id As Integer, ByVal bs_id As Integer) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT * FROM dbBorrower_Slip_Turnover WHERE fi_id = " & fi_id & " AND borrower_slip_id = " & bs_id

            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                check_if_bsturnover_exist += 1
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Public Function get_some_item_from_borrower_turnover(ByVal bs_no As String, ByVal n As Integer, ByVal bs_id As Integer) As String
        Dim query As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Try
            newSQ.connection.Open()
            query = "SELECT * FROM dbBorrower_Slip_Turnover WHERE bs_no = '" & bs_no & "' AND borrower_slip_id = " & bs_id
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                If n = 0 Then
                    get_some_item_from_borrower_turnover = newDR.Item("condition_of_item").ToString
                ElseIf n = 1 Then
                    get_some_item_from_borrower_turnover = get_charges_name(CInt(newDR.Item("turnover_location_id").ToString), newDR.Item("turnover_location").ToString)
                ElseIf n = 2 Then
                    get_some_item_from_borrower_turnover = get_charges_name(CInt(newDR.Item("type_of_turnover_id").ToString), newDR.Item("type_of_turnover_from").ToString)
                End If

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Public Function get_some_data_from_borrower_slip(ByVal fi_id As Integer, ByVal n As Integer) As String
        Dim query As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        newSQ.connection.Open()
        Try
            query = "SELECT TOP 1 * FROM dbBorrower_Slip WHERE fi_id = " & fi_id & " ORDER BY borrower_slip_id DESC"

            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                If n = 1 Then

                    Dim typeofcharge As String = newDR.Item("type_of_charge").ToString
                    Dim charge_id As Integer = CInt(newDR.Item("borrowed_for").ToString)

                    Select Case typeofcharge

                        Case "EQUIPMENT"
                            get_some_data_from_borrower_slip = GET_equip_desc_AND_proj_desc(charge_id, 1)
                        Case "PROJECT"
                            get_some_data_from_borrower_slip = GET_equip_desc_AND_proj_desc(charge_id, 2)
                        Case "WAREHOUSE"
                            get_some_data_from_borrower_slip = GET_equip_desc_AND_proj_desc(charge_id, 4)
                        Case "PERSONAL"
                            get_some_data_from_borrower_slip = GET_equip_desc_AND_proj_desc(charge_id, 3)
                        Case "CASH"
                            get_some_data_from_borrower_slip = GET_equip_desc_AND_proj_desc(charge_id, 3)
                        Case "ADFIL"
                            get_some_data_from_borrower_slip = GET_equip_desc_AND_proj_desc(charge_id, 3)
                    End Select

                ElseIf n = 2 Then
                    Dim typeofcharge As String = newDR.Item("type_borrowed_by").ToString
                    Dim charge_id As Integer = CInt(newDR.Item("borrowed_by").ToString)

                    Select Case typeofcharge

                        Case "EQUIPMENT"
                            get_some_data_from_borrower_slip = GET_equip_desc_AND_proj_desc(charge_id, 1)
                        Case "PROJECT"
                            get_some_data_from_borrower_slip = GET_equip_desc_AND_proj_desc(charge_id, 2)
                        Case "WAREHOUSE"
                            get_some_data_from_borrower_slip = GET_equip_desc_AND_proj_desc(charge_id, 4)
                        Case "PERSONAL"
                            get_some_data_from_borrower_slip = GET_equip_desc_AND_proj_desc(charge_id, 3)
                        Case "CASH"
                            get_some_data_from_borrower_slip = GET_equip_desc_AND_proj_desc(charge_id, 3)
                        Case "ADFIL"
                            get_some_data_from_borrower_slip = GET_equip_desc_AND_proj_desc(charge_id, 3)

                    End Select

                ElseIf n = 3 Then
                    get_some_data_from_borrower_slip = newDR.Item("bs_no").ToString

                ElseIf n = 4 Then
                    get_some_data_from_borrower_slip = newDR.Item("bs_tr").ToString
                ElseIf n = 5 Then
                    get_some_data_from_borrower_slip = newDR.Item("borrower_slip_id").ToString
                ElseIf n = 6 Then
                    get_some_data_from_borrower_slip = newDR.Item("date_borrow").ToString
                ElseIf n = 7 Then
                    get_some_data_from_borrower_slip = newDR.Item("borrower_slip_id").ToString
                End If

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Function get_charges_name(ByVal charge_id As Integer, ByVal type As String) As String

        Select Case type
            Case "EQUIPMENT"
                get_charges_name = GET_equip_desc_AND_proj_desc(charge_id, 1)
            Case "PROJECT"
                get_charges_name = GET_equip_desc_AND_proj_desc(charge_id, 2)
            Case "WAREHOUSE"
                get_charges_name = GET_equip_desc_AND_proj_desc(charge_id, 4)
            Case "PERSONAL"
                get_charges_name = GET_equip_desc_AND_proj_desc(charge_id, 3)
            Case "CASH"
                get_charges_name = GET_equip_desc_AND_proj_desc(charge_id, 3)
            Case "ADFIL"
                get_charges_name = GET_equip_desc_AND_proj_desc(charge_id, 3)
        End Select

    End Function
    Public Function get_bs_no(ByVal fi_id As Integer, ByVal n As Integer) As String

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_facilities", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 15)
            newCMD.Parameters.AddWithValue("@fi_id", fi_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim charge_to_id As Integer = newDR.Item("borrowed_for").ToString

                If n = 0 Then
                    get_bs_no = newDR.Item("bs_no").ToString
                ElseIf n = 1 Then
                    txtBsNo.Text = newDR.Item("bs_no").ToString
                    DtpDate.Text = newDR.Item("date_borrow").ToString
                    cmbTypeofCharge.Text = newDR.Item("type_of_charge").ToString

                    Select Case newDR.Item("type_of_charge").ToString
                        Case "EQUIPMENT"
                            cmbChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 1)
                        Case "PROJECT"
                            cmbChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 2)
                        Case "WAREHOUSE"
                            txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 4)
                        Case "PERSONAL"
                            txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                        Case "CASH"
                            txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                        Case "ADFIL"
                            txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                    End Select

                    txtPurpose.Text = newDR.Item("purpose").ToString
                    'txtBorrowedBy.Text = newDR.Item("borrowed_by").ToString
                    txtReleased.Text = newDR.Item("released_by").ToString
                    txtNotedBy.Text = newDR.Item("noted_by").ToString
                    txtApproved_by.Text = newDR.Item("approved_by").ToString
                    txtRemarks.Text = newDR.Item("remarks").ToString
                End If

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Function get_rr_no(ByVal rs_id As Integer) As String

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            'Dim query As String = "SELECT a.rr_no FROM dbreceiving_items a " & _
            '"INNER JOIN dbPO_details b " & _
            '"ON a.rs_id = b.rs_id " & _
            '" WHERE b.po_det_id = " & po_det_it
            Dim query As String
            query = "SELECT b.rr_no FROM dbreceiving_items a INNER JOIN dbreceiving_info b ON a.rr_info_id = b.rr_info_id WHERE a.rs_id = " & rs_id

            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_rr_no = newDR.Item("rr_no").ToString
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Function check_received(ByVal rs_id As Integer) As Integer

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT rs_no FROM dbreceiving_items WHERE rs_id = " & rs_id
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read

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

    Private Sub cmbTypeofCharge_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTypeofCharge.SelectedIndexChanged


        Select Case cmbTypeofCharge.Text
            Case "ADFIL"
                cmbChargeTo.Visible = False
                txtChargeTo.Visible = True

                txtChargeTo.Clear()
                charge_to_id = 0
                btn_picbox1.Enabled = True

                Select Case cmbTypeofCharge.Text

                    Case "ADFIL"
                        charge_to_selection = 2
                    Case "WAREHOUSE"
                        charge_to_selection = 1
                    Case "PERSONAL"
                        charge_to_selection = 2
                    Case "CASH"
                        charge_to_selection = 2

                End Select

                'charge_to_destination = 4
                'FCharge_To.ShowDialog()
  

            Case "PROJECT"

                cmbChargeTo.Visible = True
                txtChargeTo.Visible = False

                cmbChargeTo.Location = New Point(txtChargeTo.Bounds.Left, txtChargeTo.Bounds.Top)

                FRequestField.load_equipment(1, cmbChargeTo)

                txtChargeTo.Clear()
                charge_to_id = 0
                btn_picbox1.Enabled = False

            Case "EQUIPMENT"
                cmbChargeTo.Visible = True
                txtChargeTo.Visible = False

                cmbChargeTo.Location = New Point(txtChargeTo.Bounds.Left, txtChargeTo.Bounds.Top)

                FRequestField.load_equipment(0, cmbChargeTo)

                txtChargeTo.Clear()
                charge_to_id = 0
                btn_picbox1.Enabled = False

            Case "PERSONAL"
                cmbChargeTo.Visible = False
                txtChargeTo.Visible = True

                txtChargeTo.Clear()
                charge_to_id = 0
                btn_picbox1.Enabled = True

            Case "WAREHOUSE"
                cmbChargeTo.Visible = False
                txtChargeTo.Visible = True

                txtChargeTo.Clear()
                charge_to_id = 0


                Select Case cmbTypeofCharge.Text

                    Case "ADFIL"
                        charge_to_selection = 2
                    Case "WAREHOUSE"
                        charge_to_selection = 1
                    Case "PERSONAL"
                        charge_to_selection = 2
                    Case "CASH"
                        charge_to_selection = 2

                End Select

                'charge_to_destination = 4
                'FCharge_To.ShowDialog()
                btn_picbox1.Enabled = True

            Case "CASH"
                cmbChargeTo.Visible = False
                txtChargeTo.Visible = True

                txtChargeTo.Clear()
                charge_to_id = 0
                btn_picbox1.Enabled = True
             

        End Select
    End Sub

    Private Sub CreateBorrowerSlipToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateBorrowerSlipToolStripMenuItem.Click

        ''If exist > 0 Then
        ''    PanelBsForm_Save.Text = "Update"
        ''Else
        ''    PanelBsForm_Save.Text = "Save"
        ''End If

        ''get_bs_no(CInt(lvList.SelectedItems(0).Text), 1)

        '''========don't delete======
        'PanelBSForm.Location = New Point(Me.Bounds.Top, Me.Bounds.Left)
        'PanelBSForm.Width = Me.Width
        'PanelBSForm.Height = Me.Height
        'lvlBorrowerList.Width = Me.Width - (txtApproved_by.Width + 30)
        'lvlBorrowerList.Height = Me.Height - (GroupBox1.Height + 30 + gboxSearch.Height)

        'gboxSearch.Location = New Point(txtApproved_by.Width + 20, lvList.Height + 45)
        'PanelBSForm_btnExit.Location = New Point(lvlBorrowerList.Width, (lvlBorrowerList.Location.Y - 40))
        '''=======end don't delete=======

        'FMain.PictureBox1.Hide()
        'FMain.PictureBox2.Hide()
        'FMain.PictureBox3.Hide()

        'FMain.ToolStrip1.Hide()

        'cmbTypeofCategory.Location = New Point(txtSearch.Bounds.Left + 3, txtSearch.Bounds.Top)
        'txtSearch.Visible = False
        'FRequestField.load_type_of_request("CASH", cmbTypeofCategory)
        'cmbTypeofCategory.Width = txtSearch.Width

        'cmbSearch.Location = New Point(cmbTypeofCategory.Bounds.Right + 10, cmbTypeofCategory.Bounds.Top)
        'cmbSearch.Visible = True
        'txtSearch.Visible = False
        'cmbSearch.Width = 240
        'btnSearch.Location = New Point(cmbSearch.Bounds.Right + 10, cmbSearch.Bounds.Top)
        'Me.Refresh()

        'ifsearch = 2

        'cmbSearchByCategory.Items.Clear()

        'cmbSearchByCategory.Items.Add("Default")
        ''cmbSearchByCategory.Items.Add("Custodian")
        ''cmbSearchByCategory.Items.Add("Charges")
        ''cmbSearchByCategory.Items.Add("BS_NO")
        ''cmbSearchByCategory.Items.Add("Brand")
        ''cmbSearchByCategory.Items.Add("Item No.")

        'lbl_po_det_id.Text = lvList.SelectedItems(0).SubItems(16).Text

        'PanelBSForm_btnExit.Parent = PanelBSForm
        'PanelBSForm_btnExit.Location = New Point(btnExit.Location.X, btnExit.Location.Y)

        'Dim exist As Integer = check_if_exist("dbBorrower_Slip", "fi_id", CInt(lvList.SelectedItems(0).Text), 1)

        'For Each ctr As Control In Me.Controls
        '    If ctr.Name = "PanelBSForm" Then
        '        ctr.Visible = True
        '    Else
        '        ctr.Enabled = False
        '    End If
        'Next

        'lbl_fi_id.Text = CInt(lvList.SelectedItems(0).Text)

        'cmbTypeofCharge.Items.Clear()
        'cmbtype.Items.Clear()

        'FRequestField.load_type_of_request("CASH", cmbTypeofCharge)
        'FRequestField.load_type_of_request("CASH", cmbtype)

        'cmbSearchByCategory.Text = "Default"
        'btnSearch.PerformClick()

        ''borrower_slip_list(0)

        With FBorrowed_Item_List

            FRequestField.load_type_of_request("CASH", .cmbTypeofCharge)
            FRequestField.load_type_of_request("CASH", .cmbtype)

            .cmbSearchBy.Items.Clear()
            .cmbSearchBy.Items.Add("Search By Default")
            .cmbSearchBy.Text = "Search By Default"

            .public_fi_id = CInt(lvList.SelectedItems(0).Text)
            .search()
            .ShowDialog()
            .PanelBsForm_Save.Enabled = True
        End With


    End Sub
    Public Sub search_by_charges()

    End Sub

    Public Sub borrower_slip_list(ByVal m As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim inc As Integer

        lvlBorrowerList.Items.Clear()

        'Panel1.Location = New Point((lvlBorrowerList.Width / 2) - txtApproved_by.Width, lvlBorrowerList.Height / 2)

        'For Each itm As Control In PanelBSForm.Controls
        '    If itm.Name = "Panel1" Then
        '        itm.Visible = True
        '    Else
        '        itm.Enabled = False
        '    End If
        'Next

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_facilities", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            If m = 0 Then
                newCMD.Parameters.AddWithValue("@n", 15)
                newCMD.Parameters.AddWithValue("@fi_id", CInt(lbl_fi_id.Text))
            ElseIf m = 5 Then
                newCMD.Parameters.AddWithValue("@n", 33)
                newCMD.Parameters.AddWithValue("@type_of_charge", cmbSearchByCategory.Text)
                newCMD.Parameters.AddWithValue("@bs_no", "")

                If cmbTypeofCategory.Text = "ADFIL" Then
                    Dim charges_id As Integer = get_id("dbCharge_to", "charge_to", cmbSearch.Text, 0)
                    newCMD.Parameters.AddWithValue("@charge_id", charges_id)

                ElseIf cmbTypeofCategory.Text = "PROJECT" Then
                    Dim charges_id As Integer = get_id_proj_equip(0, cmbSearch.Text)
                    newCMD.Parameters.AddWithValue("@charge_id", charges_id)

                ElseIf cmbTypeofCategory.Text = "EQUIPMENT" Then
                    Dim charges_id As Integer = get_id_proj_equip(1, cmbSearch.Text)
                    newCMD.Parameters.AddWithValue("@charge_id", charges_id)

                ElseIf cmbTypeofCategory.Text = "WAREHOUSE" Then
                    Dim charges_id As Integer = get_id("dbwh_area", "wh_area", cmbSearch.Text, 0)
                    newCMD.Parameters.AddWithValue("@charge_id", charges_id)

                End If
            End If

            'If m = 0 Then
            '    newCMD.Parameters.AddWithValue("@n", 15)
            '    newCMD.Parameters.AddWithValue("@fi_id", CInt(lbl_fi_id.Text))
            'ElseIf m = 1 Then
            '    newCMD.Parameters.AddWithValue("@n", 27)
            '    newCMD.Parameters.AddWithValue("@type_borrowed_by", cmbTypeofCategory.Text)

            '    If cmbTypeofCategory.Text = "ADFIL" Then
            '        Dim cust_id As Integer = get_id("dbCharge_to", "charge_to", cmbSearch.Text, 0)
            '        newCMD.Parameters.AddWithValue("@borrowed_by", cust_id)

            '    ElseIf cmbTypeofCategory.Text = "PROJECT" Then
            '        Dim cust_id As Integer = get_id_proj_equip(0, cmbSearch.Text)
            '        newCMD.Parameters.AddWithValue("@borrowed_by", cust_id)

            '    ElseIf cmbTypeofCategory.Text = "EQUIPMENT" Then
            '        Dim cust_id As Integer = get_id_proj_equip(1, cmbSearch.Text)
            '        newCMD.Parameters.AddWithValue("@borrowed_by", cust_id)

            '    ElseIf cmbTypeofCategory.Text = "WAREHOUSE" Then
            '        Dim cust_id As Integer = get_id("dbwh_area", "wh_area", cmbSearch.Text, 0)
            '        newCMD.Parameters.AddWithValue("@borrowed_by", cust_id)

            '    End If
            'ElseIf m = 2 Then
            '    newCMD.Parameters.AddWithValue("@n", 28)
            '    newCMD.Parameters.AddWithValue("@type_of_charge", cmbTypeofCategory.Text)

            '    If cmbTypeofCategory.Text = "ADFIL" Then
            '        Dim charges_id As Integer = get_id("dbCharge_to", "charge_to", cmbSearch.Text, 0)
            '        newCMD.Parameters.AddWithValue("@borrowed_for", charges_id)

            '    ElseIf cmbTypeofCategory.Text = "PROJECT" Then
            '        Dim charges_id As Integer = get_id_proj_equip(0, cmbSearch.Text)
            '        newCMD.Parameters.AddWithValue("@borrowed_for", charges_id)

            '    ElseIf cmbTypeofCategory.Text = "EQUIPMENT" Then
            '        Dim charges_id As Integer = get_id_proj_equip(1, cmbSearch.Text)
            '        newCMD.Parameters.AddWithValue("@borrowed_for", charges_id)

            '    ElseIf cmbTypeofCategory.Text = "WAREHOUSE" Then
            '        Dim charges_id As Integer = get_id("dbwh_area", "wh_area", cmbSearch.Text, 0)
            '        newCMD.Parameters.AddWithValue("@borrowed_for", charges_id)

            '    End If

            'ElseIf m = 3 Then
            '    newCMD.Parameters.AddWithValue("@n", 30)
            '    newCMD.Parameters.AddWithValue("@type_of_charge", cmbTypeofCategory.Text)
            '    newCMD.Parameters.AddWithValue("@bs_no", txtSearch.Text)

            '    If cmbTypeofCategory.Text = "ADFIL" Then
            '        Dim charges_id As Integer = get_id("dbCharge_to", "charge_to", cmbSearch.Text, 0)
            '        newCMD.Parameters.AddWithValue("@borrowed_for", charges_id)

            '    ElseIf cmbTypeofCategory.Text = "PROJECT" Then
            '        Dim charges_id As Integer = get_id_proj_equip(0, cmbSearch.Text)
            '        newCMD.Parameters.AddWithValue("@borrowed_for", charges_id)

            '    ElseIf cmbTypeofCategory.Text = "EQUIPMENT" Then
            '        Dim charges_id As Integer = get_id_proj_equip(1, cmbSearch.Text)
            '        newCMD.Parameters.AddWithValue("@borrowed_for", charges_id)

            '    ElseIf cmbTypeofCategory.Text = "WAREHOUSE" Then
            '        Dim charges_id As Integer = get_id("dbwh_area", "wh_area", cmbSearch.Text, 0)
            '        newCMD.Parameters.AddWithValue("@borrowed_for", charges_id)

            '    End If

            'ElseIf m = 4 Then
            '    newCMD.Parameters.AddWithValue("@n", 31)
            '    newCMD.Parameters.AddWithValue("@type_of_charge", cmbTypeofCategory.Text)
            '    newCMD.Parameters.AddWithValue("@bs_no", "")

            '    If cmbTypeofCategory.Text = "ADFIL" Then
            '        Dim charges_id As Integer = get_id("dbCharge_to", "charge_to", cmbSearch.Text, 0)
            '        newCMD.Parameters.AddWithValue("@charge_id", charges_id)

            '    ElseIf cmbTypeofCategory.Text = "PROJECT" Then
            '        Dim charges_id As Integer = get_id_proj_equip(0, cmbSearch.Text)
            '        newCMD.Parameters.AddWithValue("@charge_id", charges_id)

            '    ElseIf cmbTypeofCategory.Text = "EQUIPMENT" Then
            '        Dim charges_id As Integer = get_id_proj_equip(1, cmbSearch.Text)
            '        newCMD.Parameters.AddWithValue("@charge_id", charges_id)

            '    ElseIf cmbTypeofCategory.Text = "WAREHOUSE" Then
            '        Dim charges_id As Integer = get_id("dbwh_area", "wh_area", cmbSearch.Text, 0)
            '        newCMD.Parameters.AddWithValue("@charge_id", charges_id)

            '    End If

            'ElseIf m = 5 Then
            '    newCMD.Parameters.AddWithValue("@n", 33)
            '    newCMD.Parameters.AddWithValue("@type_of_charge", cmbSearchByCategory.Text)
            '    newCMD.Parameters.AddWithValue("@bs_no", "")

            '    If cmbTypeofCategory.Text = "ADFIL" Then
            '        Dim charges_id As Integer = get_id("dbCharge_to", "charge_to", cmbSearch.Text, 0)
            '        newCMD.Parameters.AddWithValue("@charge_id", charges_id)

            '    ElseIf cmbTypeofCategory.Text = "PROJECT" Then
            '        Dim charges_id As Integer = get_id_proj_equip(0, cmbSearch.Text)
            '        newCMD.Parameters.AddWithValue("@charge_id", charges_id)

            '    ElseIf cmbTypeofCategory.Text = "EQUIPMENT" Then
            '        Dim charges_id As Integer = get_id_proj_equip(1, cmbSearch.Text)
            '        newCMD.Parameters.AddWithValue("@charge_id", charges_id)

            '    ElseIf cmbTypeofCategory.Text = "WAREHOUSE" Then
            '        Dim charges_id As Integer = get_id("dbwh_area", "wh_area", cmbSearch.Text, 0)
            '        newCMD.Parameters.AddWithValue("@charge_id", charges_id)

            '    End If

            'End If

            newDR = newCMD.ExecuteReader
            Dim a(25) As String

            ProgressBar1.Value = 0
            While newDR.Read

                Dim borrower_slip_id As Integer = CInt(newDR.Item("borrower_slip_id").ToString)

                a(0) = newDR.Item("borrower_slip_id").ToString
                a(1) = newDR.Item("bs_no").ToString
                a(2) = Date.Parse(newDR.Item("date_borrow").ToString)
                a(3) = UCase(get_multiple_charges(CInt(a(0)), "Borrow")) 'charges ' get_charges_name(CInt(newDR.Item("borrowed_for").ToString), newDR.Item("type_of_charge").ToString)

                If a(3).Length < 1 Then
                Else
                    a(3) = a(3).Trim().Substring(0, a(3).Length - 1)
                End If

                a(4) = newDR.Item("brand").ToString
                a(5) = 1
                a(6) = newDR.Item("purpose").ToString
                a(7) = UCase(get_charges_name(CInt(newDR.Item("borrowed_by").ToString), newDR.Item("type_borrowed_by").ToString)) ' custodian here
                a(8) = newDR.Item("withdrawn_by").ToString
                a(9) = newDR.Item("released_by").ToString
                a(10) = newDR.Item("noted_by").ToString
                a(19) = newDR.Item("approved_by").ToString
                a(13) = newDR.Item("bs_tr").ToString
                a(16) = newDR.Item("type_of_charge").ToString
                a(17) = newDR.Item("type_borrowed_by").ToString
                a(18) = newDR.Item("remarks").ToString

                a(21) = newDR.Item("no").ToString
                a(22) = newDR.Item("facility_name").ToString
                a(23) = newDR.Item("fi_id").ToString
                a(25) = newDR.Item("po_det_id").ToString


                '################king code#########################

                Dim alreadyturnover As Integer = check_if_exist("dbBorrower_Slip_Turnover", "bs_no", newDR.Item("bs_no").ToString, 0)

                'CALCULATE DAYS
                Dim d3 As DateTime

                If alreadyturnover > 0 Then
                    Dim date_turnover As String = turnover_location(newDR.Item("bs_no").ToString, 1, borrower_slip_id)
                    d3 = Date.Parse(IIf(date_turnover = "", Now, date_turnover))
                Else
                    d3 = Date.Today
                End If

                Dim d4 As DateTime = Date.Parse(newDR.Item("date_borrow").ToString)
                Dim timespan1 As TimeSpan = d3 - d4

                'this code calculate month and days (month1:2, days1:31)
                Dim days1 As Integer = 1
                Dim month1 As Integer = 0
                Dim year As Integer = 0

                Dim counter = 1

                For i = 1 To timespan1.TotalDays
                    days1 += 1

                    If d4.AddDays(i) = d4.AddMonths(counter) Then

                        'MsgBox(monthfrom.AddMonths(counter))
                        month1 += 1
                        counter += 1
                        days1 = 0

                        If month1 = 12 Then
                            year += 1
                            month1 = 0
                        End If

                    End If
                Next

                'this code convert to string type (ex. 1 month and 3 days)
                Dim result As String = ""
                result = IIf(year > 0, year & " years, ", year & " year,") & " " & IIf(month1 > 1, month1 & " months", month1 & " month") & _
                   " and " & _
                   IIf(days1 - 1 > 1, days1 & " days", days1 & " day")

                a(11) = result
                a(12) = IIf(turnover_location(newDR.Item("bs_no").ToString, 0, borrower_slip_id) = "", "waiting...", turnover_location(newDR.Item("bs_no").ToString, 0, borrower_slip_id))
                a(15) = IIf(turnover_location(newDR.Item("bs_no").ToString, 1, borrower_slip_id) = "", "waiting...", turnover_location(newDR.Item("bs_no").ToString, 1, borrower_slip_id))

                If a(12) = "waiting..." Then
                    a(24) = "waiting..."
                Else
                    a(24) = get_multiple_charges(CInt(a(0)), "Turnover")
                    If a(24).Length < 1 Then
                    Else
                        a(24) = UCase(a(24).Trim().Substring(0, a(24).Length - 1))
                    End If

                End If

                'If a(24) = "waiting..." Then
                '    a(2) = "Date Borrowed: " & a(2)
                'Else
                '    a(2) = "Date Transfer: " & a(2)
                'End If

                '#####################king code end########################
                pub_bs_id = CInt(newDR.Item("borrower_slip_id").ToString)
                Dim date_borrow As DateTime = Date.Parse(newDR.Item("date_borrow").ToString)

                a(20) = IIf(newDR.Item("bs_tr").ToString = "BS", date_borrow.AddDays(borrower_expiration(pub_bs_id)), "N/A")

                If cmbSearchByCategory.Text = "Item Name" Then
                    If search_by(a(22), txtSearch.Text) = True Then
                    Else
                        GoTo proceedhere
                    End If

                ElseIf cmbSearchByCategory.Text = "Custodian" Then
                    If search_by(a(7), txtSearch.Text) = True Then
                    Else
                        GoTo proceedhere
                    End If

                ElseIf cmbSearchByCategory.Text = "Charges" Then
                    If search_by(a(3), txtSearch.Text) = True Then
                    Else
                        GoTo proceedhere
                    End If

                ElseIf cmbSearchByCategory.Text = "Item No." Then
                    If search_by(a(21), txtSearch.Text) = True Then
                    Else
                        GoTo proceedhere
                    End If

                ElseIf cmbSearchByCategory.Text = "Brand" Then
                    If search_by(a(4), txtSearch.Text) = True Then
                    Else
                        GoTo proceedhere
                    End If

                ElseIf cmbSearchByCategory.Text = "BS_NO" Then
                    If search_by(a(1), txtSearch.Text) = True Then
                    Else
                        GoTo proceedhere
                    End If

                End If

                Dim lvl As New ListViewItem(a)
                lvlBorrowerList.Items.Add(lvl)

                Dim date_expired As DateTime = date_borrow.AddDays(borrower_expiration(pub_bs_id))
                Dim date_expired_result As TimeSpan = Now - date_expired


                If newDR.Item("bs_tr").ToString = "BS" Then
                    If lvlBorrowerList.Items(inc).SubItems(12).Text = "waiting..." Then
                        If downtimedays(Now, date_expired) <= 0 Then
                            lvlBorrowerList.Items(inc).BackColor = Color.Red
                            lvlBorrowerList.Items(inc).ForeColor = Color.White
                        End If
                    Else
                        If downtimedays(Date.Parse(lvlBorrowerList.Items(inc).SubItems(15).Text), date_expired) <= 0 Then
                            lvlBorrowerList.Items(inc).BackColor = Color.Orange
                            lvlBorrowerList.Items(inc).ForeColor = Color.Black
                        Else
                            lvlBorrowerList.Items(inc).BackColor = Color.GreenYellow
                            lvlBorrowerList.Items(inc).ForeColor = Color.Black
                        End If
                    End If
                End If


                inc += 1

                ProgressBar1.Maximum = inc
                ProgressBar1.Value += 1
                ProgressBar1.Refresh()


proceedhere:

            End While
            newDR.Close()

            If m = 1 Then
            Else
                'lblBrand.Text = lvList.SelectedItems(0).SubItems(8).Text
                'lblItemNo.Text = lvList.SelectedItems(0).SubItems(1).Text
            End If


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
            'For Each itm As Control In PanelBSForm.Controls
            '    If itm.Name = "Panel1" Then
            '        itm.Visible = False
            '    Else
            '        If itm.Name = "PanelBsForm_Save" Then
            '            itm.Enabled = False
            '        Else
            '            itm.Enabled = True
            '        End If
            '    End If

            '    cmbTypeofCharge.Enabled = False
            '    txtChargeTo.Enabled = False
            '    btn_picbox1.Enabled = False
            'Next

        End Try
    End Sub
    Public Function get_multiple_charges(ByVal bs_id As Integer, ByVal status As String) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        get_multiple_charges = ""
        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT * FROM dbBorrower_charges WHERE bs_id = " & bs_id & " AND bs_status = '" & status & "'"
            newCMD = New SqlCommand(query, newSQ.connection)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim process As String = newDR.Item("type_of_charges").ToString
                Dim charge_to_id As Integer = CInt(newDR.Item("charge_id").ToString)

                Select Case process
                    Case "EQUIPMENT"
                        get_multiple_charges &= GET_equip_desc_AND_proj_desc(charge_to_id, 1) & "/"
                    Case "PROJECT"
                        get_multiple_charges &= GET_equip_desc_AND_proj_desc(charge_to_id, 2) & "/"
                    Case "WAREHOUSE"
                        get_multiple_charges &= GET_equip_desc_AND_proj_desc(charge_to_id, 4) & "/"
                    Case "PERSONAL"
                        get_multiple_charges &= GET_equip_desc_AND_proj_desc(charge_to_id, 3) & "/"
                    Case "CASH"
                        get_multiple_charges &= GET_equip_desc_AND_proj_desc(charge_to_id, 3) & "/"
                    Case "MAINOFFICE"
                        get_multiple_charges &= GET_equip_desc_AND_proj_desc(charge_to_id, 3) & "/"

                End Select
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Public Function check_if_this_exist_in_mcharges(ByVal bs_id As Integer, ByVal status As String, ByVal charges_id As Integer, ByVal type As String) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        check_if_this_exist_in_mcharges = ""
        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT * FROM dbBorrower_charges "
            query &= "WHERE bs_id = " & bs_id & " "
            query &= "AND bs_status = '" & status & "' "
            query &= "AND charge_id = " & charges_id & " "
            query &= "AND type_of_charges = '" & type & "'"

            newCMD = New SqlCommand(query, newSQ.connection)

            newDR = newCMD.ExecuteReader
            While newDR.Read
                check_if_this_exist_in_mcharges += 1
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Public Function by_color_monitoring(ByVal fi_id As Integer) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim inc As Integer


        lvlBorrowerList.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_facilities", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 15)
            newCMD.Parameters.AddWithValue("@fi_id", fi_id)

            newDR = newCMD.ExecuteReader
            Dim a(23) As String
            While newDR.Read

                Dim borrower_slip_id As Integer = CInt(newDR.Item("borrower_slip_id").ToString)

                a(0) = newDR.Item("borrower_slip_id").ToString
                a(1) = newDR.Item("bs_no").ToString
                a(2) = Date.Parse(newDR.Item("date_borrow").ToString)
                a(3) = get_charges_name(CInt(newDR.Item("borrowed_for").ToString), newDR.Item("type_of_charge").ToString)
                a(4) = newDR.Item("brand").ToString
                a(5) = 1
                a(6) = newDR.Item("purpose").ToString
                a(7) = get_charges_name(CInt(newDR.Item("borrowed_by").ToString), newDR.Item("type_borrowed_by").ToString)
                a(8) = newDR.Item("withdrawn_by").ToString
                a(9) = newDR.Item("released_by").ToString
                a(10) = newDR.Item("noted_by").ToString
                a(19) = newDR.Item("approved_by").ToString
                a(13) = newDR.Item("bs_tr").ToString
                a(16) = newDR.Item("type_of_charge").ToString
                a(17) = newDR.Item("type_borrowed_by").ToString
                a(18) = newDR.Item("remarks").ToString

                a(21) = newDR.Item("no").ToString
                a(22) = newDR.Item("facility_name").ToString
                a(23) = newDR.Item("fi_id").ToString

                '################king code#########################

                Dim alreadyturnover As Integer = check_if_exist("dbBorrower_Slip_Turnover", "bs_no", newDR.Item("bs_no").ToString, 0)

                'CALCULATE DAYS
                Dim d3 As DateTime

                If alreadyturnover > 0 Then
                    Dim date_turnover As String = turnover_location(newDR.Item("bs_no").ToString, 1, borrower_slip_id)
                    d3 = Date.Parse(IIf(date_turnover = "", Now, date_turnover))
                Else
                    d3 = Date.Today
                End If

                Dim d4 As DateTime = Date.Parse(newDR.Item("date_borrow").ToString)
                Dim timespan1 As TimeSpan = d3 - d4

                'this code calculate month and days (month1:2, days1:31)
                Dim days1 As Integer = 1
                Dim month1 As Integer = 0
                Dim year As Integer = 0

                Dim counter = 1

                For i = 1 To timespan1.TotalDays
                    days1 += 1

                    If d4.AddDays(i) = d4.AddMonths(counter) Then

                        'MsgBox(monthfrom.AddMonths(counter))
                        month1 += 1
                        counter += 1
                        days1 = 0

                        If month1 = 12 Then
                            year += 1
                            month1 = 0
                        End If

                    End If
                Next

                'this code convert to string type (ex. 1 month and 3 days)
                Dim result As String = ""
                result = IIf(year > 0, year & " years, ", year & " year,") & " " & IIf(month1 > 1, month1 & " months", month1 & " month") & _
                   " and " & _
                   IIf(days1 - 1 > 1, days1 & " days", days1 & " day")

                a(11) = result
                a(12) = IIf(turnover_location(newDR.Item("bs_no").ToString, 0, borrower_slip_id) = "", "waiting...", turnover_location(newDR.Item("bs_no").ToString, 0, borrower_slip_id))
                a(15) = IIf(turnover_location(newDR.Item("bs_no").ToString, 1, borrower_slip_id) = "", "waiting...", turnover_location(newDR.Item("bs_no").ToString, 1, borrower_slip_id))


                '#####################king code end########################
                pub_bs_id = CInt(newDR.Item("borrower_slip_id").ToString)

                a(20) = IIf(newDR.Item("bs_tr").ToString = "BS", Date.Parse(a(2)).AddDays(borrower_expiration(pub_bs_id)), "N/A")

                Dim date_expired As DateTime = Date.Parse(a(2)).AddDays(borrower_expiration(pub_bs_id))
                Dim date_expired_result As TimeSpan = Now - date_expired


                If newDR.Item("bs_tr").ToString = "BS" Then
                    If a(12) = "waiting..." Then
                        If downtimedays(Now, date_expired) <= 0 Then
                            by_color_monitoring = "red"
                        Else
                            by_color_monitoring = "white"
                        End If
                    Else
                        If downtimedays(Date.Parse(a(15)), date_expired) <= 0 Then
                            by_color_monitoring = "orange"
                        Else
                            by_color_monitoring = "yellowgreen"
                        End If
                    End If
                End If

                inc += 1

            End While
            newDR.Close()


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

        End Try
    End Function

    Public Function get_id_proj_equip(ByVal n As Integer, ByVal search As String) As Integer
        Dim sqlcon As New SQLcon
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        Try
            'sqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
            'sqlcon.sql_connect()

            sqlcon.connection1.Open()

            If n = 0 Then
                publicquery = "SELECT proj_id FROM dbprojectdesc WHERE project_desc = '" & search & "'"
            ElseIf n = 1 Then
                publicquery = "SELECT equipListID FROM dbequipment_list WHERE plate_no = '" & search & "'"
            End If

            cmd = New SqlCommand(publicquery, sqlcon.connection1) : dr = cmd.ExecuteReader
            While dr.Read : get_id_proj_equip = CInt(dr.Item(0).ToString) : End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection1.Close()
        End Try

    End Function
    Public Function downtimedays(ByVal d1 As DateTime, ByVal d2 As DateTime) As String
        Dim ffrom As DateTime
        Dim fromto As DateTime

        ffrom = Date.Parse(d1)
        fromto = Date.Parse(d2)

        Dim travelTime As TimeSpan = fromto - ffrom

        downtimedays = Math.Round(CDbl(travelTime.TotalDays.ToString), 1)
        downtimedays = sp(downtimedays, ".", 0)


    End Function

    Public Function borrower_expiration(ByVal bs_id As Integer) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Try
            newSQ.connection.Open()

            Dim query As String = "SELECT * FROM dbBorrower_expiration WHERE bs_id = " & bs_id
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                borrower_expiration = CInt(newDR.Item("estimated_days_return").ToString) + CInt(newDR.Item("extended").ToString)
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

        End Try

    End Function
    Private Function turnover_location(ByVal bs_no As String, ByVal nn As Integer, ByVal bs_id As Integer) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_facilities", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 21)
            newCMD.Parameters.AddWithValue("@bs_no", bs_no)
            newCMD.Parameters.AddWithValue("@bs_id", bs_id)

            newDR = newCMD.ExecuteReader
            Dim a(13) As String

            While newDR.Read
                If nn = 0 Then
                    turnover_location = get_charges_name(CInt(newDR.Item("turnover_location_id").ToString), newDR.Item("turnover_location").ToString)
                ElseIf nn = 1 Then
                    turnover_location = Date.Parse(newDR.Item("date_turnover").ToString)
                End If

            End While

            newDR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Select Case cmbTypeofCharge.Text

            Case "ADFIL"
                charge_to_selection = 2
            Case "WAREHOUSE"
                charge_to_selection = 1
            Case "PERSONAL"
                charge_to_selection = 2
            Case "CASH"
                charge_to_selection = 2

        End Select

        charge_to_destination = 4
        FCharge_To.ShowDialog()

    End Sub

    Private Sub cmbChargeTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbChargeTo.SelectedIndexChanged
        equipment_project_charge_to(1)

    End Sub
    Public Function equipment_project_charge_to1(ByVal n As Integer) As Integer
        Dim sqlcon As New SQLcon
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        If cmbTypeofCharge.Text = "EQUIPMENT" Then
            Try
                'sqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
                'sqlcon.sql_connect()

                sqlcon.connection1.Open()
                publicquery = "SELECT equipListID FROM dbequipment_list WHERE plate_no = '" & cmbChargeTo.Text & "'"
                cmd = New SqlCommand(publicquery, sqlcon.connection1)
                dr = cmd.ExecuteReader

                While dr.Read
                    If n = 1 Then
                        equipment_project_charge_to1 = dr.Item(0).ToString
                    ElseIf n = 2 Then
                        equipment_project_charge_to1 = dr.Item(0).ToString
                    End If

                End While
                dr.Close()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                sqlcon.connection1.Close()
            End Try

        ElseIf cmbTypeofCharge.Text = "PROJECT" Then
            Try
                'sqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
                'sqlcon.sql_connect()

                sqlcon.connection1.Open()
                publicquery = "SELECT proj_id FROM dbprojectdesc WHERE project_desc = '" & cmbChargeTo1.Text & "'"
                cmd = New SqlCommand(publicquery, sqlcon.connection1)
                dr = cmd.ExecuteReader

                While dr.Read
                    If n = 1 Then
                        equipment_project_charge_to1 = dr.Item(0).ToString
                    ElseIf n = 2 Then
                        equipment_project_charge_to1 = dr.Item(0).ToString
                    End If
                End While
                dr.Close()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                sqlcon.connection1.Close()
            End Try

        End If
    End Function

    Public Sub equipment_project_charge_to(ByVal n As Integer)
        Dim sqlcon As New SQLcon
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        Dim typeofcharge, typeofcharge1 As String

        typeofcharge = cmbTypeofCharge.Text
        typeofcharge1 = cmbtype.Text


        If n = 1 Then
            If typeofcharge = "EQUIPMENT" Then
                Try
                    'sqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
                    'sqlcon.sql_connect()

                    sqlcon.connection1.Open()

                    publicquery = "SELECT equipListID FROM dbequipment_list WHERE plate_no = '" & cmbChargeTo.Text & "'"
                    cmd = New SqlCommand(publicquery, sqlcon.connection1) : dr = cmd.ExecuteReader
                    While dr.Read : charge_to_id = dr.Item(0).ToString : End While
                    dr.Close()

                Catch ex As Exception
                    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    sqlcon.connection1.Close()
                End Try
            ElseIf typeofcharge = "PROJECT" Then
                Try
                    'sqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
                    'sqlcon.sql_connect()

                    sqlcon.connection1.Open()

                    publicquery = "SELECT proj_id FROM dbprojectdesc WHERE project_desc = '" & cmbChargeTo.Text & "'"

                    cmd = New SqlCommand(publicquery, sqlcon.connection1) : dr = cmd.ExecuteReader
                    While dr.Read : charge_to_id = dr.Item(0).ToString : End While
                    dr.Close()

                Catch ex As Exception
                    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    sqlcon.connection1.Close()
                End Try
            End If

        ElseIf n = 2 Then
            If typeofcharge1 = "EQUIPMENT" Then
                Try
                    'sqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
                    'sqlcon.sql_connect()

                    sqlcon.connection1.Open()

                    publicquery = "SELECT equipListID FROM dbequipment_list WHERE plate_no = '" & cmbChargeTo1.Text & "'"
                    cmd = New SqlCommand(publicquery, sqlcon.connection1) : dr = cmd.ExecuteReader
                    While dr.Read : charge_to_id1 = dr.Item(0).ToString : End While
                    dr.Close()

                Catch ex As Exception
                    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    sqlcon.connection1.Close()
                End Try
            ElseIf typeofcharge1 = "PROJECT" Then
                Try
                    'sqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
                    'sqlcon.sql_connect()

                    sqlcon.connection1.Open()

                    publicquery = "SELECT proj_id FROM dbprojectdesc WHERE project_desc = '" & cmbChargeTo1.Text & "'"

                    cmd = New SqlCommand(publicquery, sqlcon.connection1) : dr = cmd.ExecuteReader
                    While dr.Read : charge_to_id1 = dr.Item(0).ToString : End While
                    dr.Close()

                Catch ex As Exception
                    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    sqlcon.connection1.Close()
                End Try
            End If
        End If
        'If cmbTypeofCharge.Text = "EQUIPMENT" Then
        '    Try
        '        sqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
        '        sqlcon.sql_connect()

        '        sqlcon.connection.Open()

        '        If n = 1 Then
        '            publicquery = "SELECT equipListID FROM dbequipment_list WHERE plate_no = '" & cmbChargeTo.Text & "'"
        '        ElseIf n = 2 Then
        '            publicquery = "SELECT equipListID FROM dbequipment_list WHERE plate_no = '" & cmbChargeTo1.Text & "'"
        '        End If

        '        cmd = New SqlCommand(publicquery, sqlcon.connection)
        '        dr = cmd.ExecuteReader

        '        While dr.Read
        '            If n = 1 Then
        '                charge_to_id = dr.Item(0).ToString
        '            ElseIf n = 2 Then
        '                charge_to_id1 = dr.Item(0).ToString
        '            End If

        '        End While
        '        dr.Close()

        '    Catch ex As Exception
        '        MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Finally
        '        sqlcon.connection.Close()
        '    End Try

        'ElseIf cmbTypeofCharge.Text = "PROJECT" Then
        '    Try
        '        sqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
        '        sqlcon.sql_connect()

        '        sqlcon.connection.Open()

        '        If n = 1 Then
        '            publicquery = "SELECT proj_id FROM dbprojectdesc WHERE project_desc = '" & cmbChargeTo.Text & "'"
        '        ElseIf n = 2 Then
        '            publicquery = "SELECT proj_id FROM dbprojectdesc WHERE project_desc = '" & cmbChargeTo1.Text & "'"
        '        End If

        '        cmd = New SqlCommand(publicquery, sqlcon.connection)
        '        dr = cmd.ExecuteReader

        '        While dr.Read
        '            If n = 1 Then
        '                charge_to_id = dr.Item(0).ToString
        '            ElseIf n = 2 Then
        '                charge_to_id1 = dr.Item(0).ToString
        '            End If
        '        End While
        '        dr.Close()

        '    Catch ex As Exception
        '        MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Finally
        '        sqlcon.connection.Close()
        '    End Try

        'End If
    End Sub


    Private Sub PanelBsForm_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelBsForm_Save.Click
        Dim bs_id As Integer

        If PanelBsForm_Save.Text = "Save (Ctrl + S)" Then
            If check_if_exist("dbBorrower_Slip", "bs_no", txtBsNo.Text, 0) > 0 Then

                If cmbSelectBSorTS.Text = "TR" Then

                ElseIf cmbSelectBSorTS.Text = "BR" Then
                    MessageBox.Show("bs_no has already exist in the database..", "Borrower Info:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

            End If

            Dim turnoverexist As Integer = check_if_exist("dbBorrower_Slip_Turnover", "borrower_slip_id", pub_bs_id, 0)
            If turnoverexist > 0 Then
                bs_id = bs_form_save_update("save")
            Else
                'count nya og naa nabay na store nga bslip ani nga item, kung zero wala pa
                If lvlBorrowerList.Items.Count = 0 Then
                    bs_id = bs_form_save_update("save")
                Else
                    MessageBox.Show("This item has not been return yet..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
               

            End If

            'lvlist_loader()

            Dim fi_id As Integer = CInt(lbl_fi_id.Text)

        FBorrower_Expiration.lbl_bs_id.Text = bs_id
        FBorrower_Expiration.btnSaveUpdate.Text = "Save"
        FBorrower_Expiration.ShowDialog()

        'LOAD_facilities_item()

        'listfocus(lvList, fi_id)
        listfocus(lvlBorrowerList, bs_id)
        MessageBox.Show("Successfully Save...", "BORROWER INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)


            txtReleased.Text = "Christopher Q. Balbin"
            txtNotedBy.Text = "Vanessa F. Piedad"
            txtApproved_by.Text = "Mercy Fe G. Cupay"
            txtRemarks.Text = "N/A"
            txtBsNo.Text = 0
            txtBsNo.Focus()

        ElseIf PanelBsForm_Save.Text = "Update (Ctrl + S)" Then
            bs_id = CInt(lvlBorrowerList.SelectedItems(0).Text)

            If MessageBox.Show("Are you sure u want to update the SELECTED item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                Dim alreadyturnover As Integer = check_if_exist("dbBorrower_Slip_Turnover", "bs_no", lvlBorrowerList.SelectedItems(0).SubItems(1).Text, 0)

                If alreadyturnover > 0 Then
                    update_borrower_turonver_bsno(txtBsNo.Text, lvlBorrowerList.SelectedItems(0).SubItems(1).Text)
                End If

                update_borrowed_slip_form()

                'lvlist_loader()

                btnSearch.PerformClick()
                listfocus(lvlBorrowerList, bs_id)
                clear_field()
                PanelBsForm_Save.Text = "Save (Ctrl + S)"
                lvlBorrowerList.Enabled = True


                cmbTypeofCharge.Enabled = False
                txtChargeTo.Enabled = False
                btn_picbox1.Enabled = False

                txtReleased.Text = "Christopher Q. Balbin"
                txtNotedBy.Text = "Vanessa F. Piedad"
                txtApproved_by.Text = "Mercy Fe G. Cupay"
                txtRemarks.Text = "N/A"
                txtBsNo.Text = 0
                txtBsNo.Focus()

            End If

        'Dim ex = MessageBox.Show("Are you sure u want to update the SELECTED item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        'If ex = MsgBoxResult.Yes Then

        '    Dim alreadyturnover As Integer = check_if_exist("dbBorrower_Slip_Turnover", "bs_no", lvlBorrowerList.SelectedItems(0).SubItems(1).Text, 0)

        '    If alreadyturnover > 0 Then
        '        update_borrower_turonver(txtBsNo.Text, lvlBorrowerList.SelectedItems(0).SubItems(1).Text)

        '    End If

        '    update_borrowed_slip_form()

        '    listfocus(lvlBorrowerList, bs_id)
        '    clear_field()
        '    PanelBsForm_Save.Text = "Save (Ctrl + S)"
        '    lvlBorrowerList.Enabled = True

        'ElseIf ex = MsgBoxResult.No Then
        '    'btnCancel.PerformClick()
        '    clear_field()
        '    lvlBorrowerList.Enabled = True
        '    PanelBsForm_Save.Text = "Save (Ctrl + S)"
        'End If
        'txtBsNo.Enabled = True

        End If

            'Dim fi_id As Integer = CInt(lvList.SelectedItems(0).Text)
            'If ifsearch = 1 Then
            '    btnSearch.PerformClick()

            'ElseIf ifsearch = 2 Then
            '    'LOAD_facilities_item()
            '    btnSearch.PerformClick()
            'End If

            'listfocus(lvList, fi_id)
    End Sub
    Public Sub update_borrower_turonver_bsno(ByVal newbs_no As String, ByVal oldbs_no As String)
        Dim newSQ As New SQLcon
        Dim newcmd As SqlCommand
        Dim newdr As SqlDataReader

        Try
            newSQ.connection.Open()

            Dim query As String
            query = "UPDATE dbBorrower_Slip_Turnover SET bs_no = '" & newbs_no & "' WHERE bs_no = '" & oldbs_no & "'"
            newcmd = New SqlCommand(query, newSQ.connection)
            newcmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Public Sub update_borrowed_slip_form()
        Dim newsql As New SQLcon

        Dim bs_id As Integer

        bs_id = CInt(lvlBorrowerList.SelectedItems(0).Text)

        Try
            newsql.connection.Open()
            Dim sqlComm As New SqlCommand

            sqlComm.Connection = newsql.connection
            sqlComm.CommandText = "proc_facilities"
            sqlComm.CommandType = CommandType.StoredProcedure
            sqlComm.Parameters.AddWithValue("@bs_id", bs_id)
            sqlComm.Parameters.AddWithValue("@bs_no", txtBsNo.Text)
            sqlComm.Parameters.AddWithValue("@date_borrow", DateTime.Parse(DtpDate.Text))
            sqlComm.Parameters.AddWithValue("@type_of_charge", cmbTypeofCharge.Text)
            sqlComm.Parameters.AddWithValue("@borrowed_for", charge_to_id)
            sqlComm.Parameters.AddWithValue("@purpose", txtPurpose.Text)
            sqlComm.Parameters.AddWithValue("@type_borrowed_by", cmbtype.Text)
            sqlComm.Parameters.AddWithValue("@borrowed_by", charge_to_id1)
            sqlComm.Parameters.AddWithValue("@withdrawn_by", txtWithdrawn.Text)
            sqlComm.Parameters.AddWithValue("@released_by", txtReleased.Text)
            sqlComm.Parameters.AddWithValue("@noted_by", txtNotedBy.Text)
            sqlComm.Parameters.AddWithValue("@approved_by", txtApproved_by.Text)
            sqlComm.Parameters.AddWithValue("@remarks", txtRemarks.Text)
            sqlComm.Parameters.AddWithValue("@n", 18)
            sqlComm.ExecuteNonQuery()

            MessageBox.Show("Successfully Updated...", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'borrower_slip_list(0)
            ' listfocus(lvlBorrowerList, lvlBorrowerList.SelectedItems(0).SubItems(1).Text)


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsql.connection.Close()
        End Try
        ' MsgBox(lvlBorrowerList.SelectedItems(0).SubItems(1).Text)
    End Sub
    Public Function bs_form_save_update(ByVal funct As String) As Integer

        For Each ctr As Control In PanelBSForm.Controls
            If TypeOf ctr Is TextBox Then
                Dim tbox As TextBox = ctr

                If tbox.Name = "txtChargeTo" Or tbox.Name = "txtChargeTo1" Then

                Else
                    If tbox.Text = "" Then
                        If cmbSelectBSorTS.Text = "TR" Then
                        Else
                            MessageBox.Show("Field must not empty...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Function
                        End If

                    End If
                End If
            End If
        Next

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_facilities", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            If funct = "save" Then
                newCMD.Parameters.AddWithValue("@n", 13)

            ElseIf funct = "update" Then
                newCMD.Parameters.AddWithValue("@n", 14)
                newCMD.Parameters.AddWithValue("@borrower_slip_id", CInt(lvList.SelectedItems(0).Text))

                ''og wala ni, pag update, mwala ang id sa turnover location
                'If cmbChargeTo1.Text = "ADFIL" Then
                '    charge_to_id = get_id("dbCharge_to", "charge_to", txtChargeTo.Text, 0)

                'ElseIf cmbChargeTo1.Text = "WAREHOUSE" Then
                '    charge_to_id1 = get_id("dbwh_area", "wh_area", txtChargeTo.Text, 0)

                'End If
            End If

            newCMD.Parameters.AddWithValue("@date_borrow", Date.Parse(DtpDate.Text))
            newCMD.Parameters.AddWithValue("@type_of_charge", cmbTypeofCharge.Text)
            newCMD.Parameters.AddWithValue("@borrowed_for", charge_to_id)
            newCMD.Parameters.AddWithValue("@purpose", txtPurpose.Text)
            newCMD.Parameters.AddWithValue("@type_borrowed_by", cmbtype.Text)
            newCMD.Parameters.AddWithValue("@borrowed_by", charge_to_id1)
            newCMD.Parameters.AddWithValue("@date_return", Date.Parse("1991-01-01"))
            newCMD.Parameters.AddWithValue("@approved_by", txtApproved_by.Text)
            newCMD.Parameters.AddWithValue("@noted_by", txtNotedBy.Text)
            newCMD.Parameters.AddWithValue("@withdrawn_by", txtWithdrawn.Text)
            newCMD.Parameters.AddWithValue("@released_by", txtReleased.Text)
            newCMD.Parameters.AddWithValue("@bs_no", txtBsNo.Text)
            newCMD.Parameters.AddWithValue("@remarks", txtRemarks.Text)
            newCMD.Parameters.AddWithValue("@bs_tr", cmbSelectBSorTS.Text)
            newCMD.Parameters.AddWithValue("@fi_id", CInt(lbl_fi_id.Text))
            newCMD.Parameters.AddWithValue("po_det_id", CInt(lbl_po_det_id.Text))

            bs_form_save_update = newCMD.ExecuteScalar

            'If bs_form_save_update > 0 Then
            '    If funct = "save" Then
            '        MessageBox.Show("Successfully Saved...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    End If
            'End If

            'If funct = "Successfully updated..." Then
            '    MessageBox.Show("Successfully Saved...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

            For Each ctr As Control In PanelBSForm.Controls
                If TypeOf ctr Is TextBox Then
                    Dim tbox As TextBox = ctr
                    tbox.Clear()

                End If
            Next
        End Try

        txtBsNo.Focus()
    End Function
    Public Sub lvlist_loader()

        Dim fi_id As Integer = CInt(lbl_fi_id.Text)
        Button2.PerformClick()
        listfocus(lvList, fi_id)

    End Sub
    Private Sub PanelBSForm_btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelBSForm_btnExit.Click
        For Each ctr As Control In Me.Controls
            If ctr.Name = "PanelBSForm" Then
                ctr.Visible = False
            Else
                ctr.Enabled = True
            End If
        Next
    End Sub

    Private Sub InsertOldFacilitiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertOldFacilitiesToolStripMenuItem.Click
        save_update_function(1)

    End Sub
    Public Sub edit_facilities(ByVal fi_id As Integer)

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim charge_id, charge_id1 As Integer
        Dim type, type1 As String

        FOldFacilities.load_to_all_cmbox()

        Try
            newSQ.connection.Open()

            Dim query As String = "SELECT * FROM dbfacilities_items WHERE fi_id = " & fi_id
            newCMD = New SqlCommand(query, newSQ.connection)

            newDR = newCMD.ExecuteReader
            While newDR.Read
                With FOldFacilities

                    .dtpDateAquired.Text = Date.Parse(newDR.Item("date_aquired").ToString)
                    .Brand_cmbfac_name.Text = lvList.SelectedItems(0).SubItems(7).Text
                    .cmbBrand.Text = lvList.SelectedItems(0).SubItems(8).Text
                    .txtno.Text = lvList.SelectedItems(0).SubItems(1).Text

                    charge_id = CInt(newDR.Item("custodian").ToString)
                    charge_to_id = charge_id

                    type = newDR.Item("type_of_custodian").ToString

                    .cmbTypeOfCustodian.Text = type

                    Select Case type
                        Case "EQUIPMENT"
                            .cmbChargeTo.Visible = True
                            .cmbChargeTo.Text = get_charges_name(charge_id, type)
                        Case "PROJECT"
                            .cmbChargeTo.Visible = True
                            .cmbChargeTo.Text = get_charges_name(charge_id, type)
                        Case "WAREHOUSE"
                            .txtCustodian.Visible = True
                            .txtCustodian.Text = get_charges_name(charge_id, type)
                        Case "PERSONAL"
                            .txtCustodian.Visible = True
                            .txtCustodian.Text = get_charges_name(charge_id, type)
                        Case "CASH"
                            .txtCustodian.Visible = True
                            .txtCustodian.Text = get_charges_name(charge_id, type)
                        Case "ADFIL"
                            .txtCustodian.Visible = True
                            .txtCustodian.Text = get_charges_name(charge_id, type)
                    End Select

                    charge_id1 = CInt(newDR.Item("received_to").ToString)
                    charge_to_id1 = charge_id1

                    type1 = newDR.Item("type_of_received").ToString

                    .cmbTypeofCharge.Text = type1

                    Select Case type1
                        Case "EQUIPMENT"
                            .cmbChargeTo1.Visible = True
                            .cmbChargeTo1.Text = get_charges_name(charge_id1, type1)
                        Case "PROJECT"
                            .cmbChargeTo1.Visible = True
                            .cmbChargeTo1.Text = get_charges_name(charge_id1, type1)
                        Case "WAREHOUSE"
                            .txtChargeTo.Visible = True
                            .txtChargeTo.Text = get_charges_name(charge_id1, type1)
                        Case "PERSONAL"
                            .txtChargeTo.Visible = True
                            .txtChargeTo.Text = get_charges_name(charge_id1, type1)
                        Case "CASH"
                            .txtChargeTo.Visible = True
                            .txtChargeTo.Text = get_charges_name(charge_id1, type1)
                        Case "ADFIL"
                            .txtChargeTo.Visible = True
                            .txtChargeTo.Text = get_charges_name(charge_id1, type1)
                    End Select

                    .cmbStatus.Text = newDR.Item("condition").ToString
                    .txtRemarks.Text = newDR.Item("remarks").ToString

                End With

            End While

            newDR.Close()
            FOldFacilities.btnSave.Text = "Update (Ctrl + S)"
            FOldFacilities.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

        End Try
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbListOfFacilitiesTools.SelectedIndexChanged
        Try

            'loading_effect_start()
            'LOAD_facilities_item()
            'loading_effect_end()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub

    Private Sub EditFacilitiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditFacilitiesToolStripMenuItem.Click
        save_update_function(2)

    End Sub


    Private Sub cmbtype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtype.SelectedIndexChanged
        Select Case cmbtype.Text
            Case "ADFIL"
                cmbChargeTo1.Visible = False
                txtChargeTo1.Visible = True

                txtChargeTo1.Clear()
                charge_to_id1 = 0
                btn_picbox2.Enabled = True

                Select Case cmbtype.Text

                    Case "ADFIL"
                        charge_to_selection = 2
                    Case "WAREHOUSE"
                        charge_to_selection = 1
                    Case "PERSONAL"
                        charge_to_selection = 2
                    Case "CASH"
                        charge_to_selection = 2

                End Select

                'charge_to_destination = 7
                'FCharge_To.ShowDialog()

            Case "PROJECT"

                cmbChargeTo1.Visible = True
                txtChargeTo1.Visible = False

                cmbChargeTo1.Location = New Point(txtChargeTo1.Bounds.Left, txtChargeTo1.Bounds.Top)

                FRequestField.load_equipment(1, cmbChargeTo1)

                txtChargeTo1.Clear()
                charge_to_id1 = 0
                btn_picbox2.Enabled = False
            Case "EQUIPMENT"
                cmbChargeTo1.Visible = True
                txtChargeTo1.Visible = False

                cmbChargeTo1.Location = New Point(txtChargeTo1.Bounds.Left, txtChargeTo1.Bounds.Top)

                FRequestField.load_equipment(0, cmbChargeTo1)

                txtChargeTo1.Clear()
                charge_to_id1 = 0
                btn_picbox2.Enabled = False

            Case "PERSONAL"
                cmbChargeTo1.Visible = False
                txtChargeTo1.Visible = True

                txtChargeTo1.Clear()
                charge_to_id1 = 0
                btn_picbox2.Enabled = True

            Case "WAREHOUSE"
                cmbChargeTo1.Visible = False
                txtChargeTo1.Visible = True

                txtChargeTo1.Clear()
                charge_to_id1 = 0

                Select Case cmbtype.Text

                    Case "ADFIL"
                        charge_to_selection = 2
                    Case "WAREHOUSE"
                        charge_to_selection = 1
                    Case "PERSONAL"
                        charge_to_selection = 2
                    Case "CASH"
                        charge_to_selection = 2

                End Select
                btn_picbox2.Enabled = True

                'charge_to_destination = 7
                'FCharge_To.ShowDialog()
            Case "CASH"
                cmbChargeTo1.Visible = False
                txtChargeTo1.Visible = True

                txtChargeTo1.Clear()
                charge_to_id1 = 0
                btn_picbox2.Enabled = True
        End Select
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Select Case cmbtype.Text

            Case "ADFIL"
                charge_to_selection = 2
            Case "WAREHOUSE"
                charge_to_selection = 1
            Case "PERSONAL"
                charge_to_selection = 2
            Case "CASH"
                charge_to_selection = 2

        End Select

        charge_to_destination = 7
        FCharge_To.ShowDialog()
    End Sub

    Private Sub cmbChargeTo1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbChargeTo1.SelectedIndexChanged
        equipment_project_charge_to(2)
    End Sub

    Private Sub PanelBSForm_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanelBSForm.MouseDown
        'Timer_PanelBSFormt.Enabled = True
        'Timer_PanelBSFormt.Start()
        'setpositions()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        For Each ctr As Control In Me.Controls
            If ctr.Name = "PanelItemNo" Then
                ctr.Visible = False
            Else
                ctr.Enabled = True
            End If
        Next

    End Sub

    Private Sub txtItemNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItemNo.KeyDown

        If Not (e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 48 Or e.KeyValue = 49 Or e.KeyValue = 50 Or e.KeyValue = 51 Or e.KeyValue = 52 Or e.KeyValue = 53 Or e.KeyValue = 54 Or _
           e.KeyValue = 55 Or e.KeyValue = 56 Or e.KeyValue = 57 Or e.KeyValue = 96 Or e.KeyValue = 97 Or e.KeyValue = 98 Or e.KeyValue = 99 Or _
           e.KeyCode = Keys.OemPeriod Or _
          e.KeyValue = 100 Or e.KeyValue = 101 Or e.KeyValue = 102 Or e.KeyValue = 103 Or e.KeyValue = 104 Or e.KeyValue = 105 Or e.KeyValue = 37 Or e.KeyValue = 39) Then

            e.SuppressKeyPress() = True
        End If
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim fi_id As Integer = CInt(lvList.SelectedItems(0).Text)
        Try

            Dim query As String = "UPDATE dbfacilities_items SET no = " & CInt(txtItemNo.Text) & " WHERE fi_id = " & CInt(lbl_fi_id.Text)
            UPDATE_INSERT_DELETE_QUERY(query, 1, "UPDATE")

            MessageBox.Show("Item No. Successfully Updated...", "EUS INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'Button1.PerformClick()
            'LOAD_facilities_item()
            'listfocus(lvList, fi_id)

        End Try
    End Sub

    Private Sub cmb_Gotfocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSelectBSorTS.GotFocus, cmbChargeTo.GotFocus, _
    cmbChargeTo1.GotFocus, cmbListOfFacilitiesTools.GotFocus, cmbtype.GotFocus, cmbTypeofCharge.GotFocus, cmbTypeofFacTools.GotFocus

        pub_combox = sender

    End Sub

    Private Sub txtbox_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQty.Leave, cmbSelectBSorTS.Leave, txtBsNo.Leave, DtpDate.Leave, cmbTypeofCharge.Leave, cmbChargeTo.Leave, txtChargeTo.Leave, txtPurpose.Leave, cmbtype.Leave, cmbChargeTo1.Leave, txtChargeTo1.Leave, txtWithdrawn.Leave, txtReleased.Leave, txtNotedBy.Leave, txtApproved_by.Leave, txtRemarks.Leave
        sender.backcolor = Color.White
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSelectBSorTS.SelectedIndexChanged

        If cmbSelectBSorTS.Text = "TR" Then
            txtBsNo.Enabled = True
            txtQty.Enabled = False
            txtPurpose.Enabled = True
            txtWithdrawn.Enabled = False
            txtReleased.Enabled = False
            txtNotedBy.Enabled = False
            txtApproved_by.Enabled = False

            txtPurpose.Text = "N/A"
            txtWithdrawn.Text = "N/A"
            txtReleased.Text = "N/A"
            txtNotedBy.Text = "N/A"
            txtApproved_by.Text = "N/A"
            txtRemarks.Text = "N/A"

            'txtBsNo.Text = 0
            txtQty.Text = 1
            txtPurpose.Text = ""
            txtWithdrawn.Text = ""
            txtReleased.Text = ""
            txtNotedBy.Text = ""
            txtApproved_by.Text = ""


        ElseIf cmbSelectBSorTS.Text = "BS" Then
            txtBsNo.Enabled = True
            txtQty.Enabled = True
            txtPurpose.Enabled = True
            txtWithdrawn.Enabled = True
            txtReleased.Enabled = True
            txtNotedBy.Enabled = True
            txtApproved_by.Enabled = True

            If PanelBsForm_Save.Text = "Update (Ctrl + S)" Then
            Else

                txtPurpose.Text = ""
                txtWithdrawn.Text = "N/A"
                txtReleased.Text = "Christopher Q. Balbin"
                txtNotedBy.Text = "Vanessa F. Piedad"
                txtApproved_by.Text = "Mercy Fe G. Cupay"
                txtRemarks.Text = "N/A"
            End If
           

        End If
    End Sub


    Private Sub TurnoverToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TurnoverToolStripMenuItem.Click
        Try
            FCreateCharges.bs_status = "Turnover"
            FBorrower_Turnover.lbl_fi_id.Text = lvlBorrowerList.SelectedItems(0).SubItems(23).Text
            FBorrower_Turnover.lbl_bs_no.Text = lvlBorrowerList.SelectedItems(0).SubItems(1).Text
            FBorrower_Turnover.txtQty.Text = lvlBorrowerList.SelectedItems(0).SubItems(5).Text
            FBorrower_Turnover.lbl_bs_id.Text = CInt(lvlBorrowerList.SelectedItems(0).Text)
            bs_id = CInt(lvlBorrowerList.SelectedItems(0).Text)
            FBorrower_Turnover.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        If lvlBorrowerList.Items.Count > 0 Then
            txtBsNo.Text = lvlBorrowerList.SelectedItems(0).SubItems(1).Text
            DtpDate.Text = Date.Parse(lvlBorrowerList.SelectedItems(0).SubItems(2).Text)
            cmbTypeofCharge.Text = lvlBorrowerList.SelectedItems(0).SubItems(16).Text

            If cmbTypeofCharge.Text = "PROJECT" Or cmbTypeofCharge.Text = "EQUIPMENT" Then
                cmbChargeTo.Text = lvlBorrowerList.SelectedItems(0).SubItems(3).Text
            Else
                txtChargeTo.Text = lvlBorrowerList.SelectedItems(0).SubItems(3).Text
            End If


            txtPurpose.Text = lvlBorrowerList.SelectedItems(0).SubItems(6).Text
            cmbtype.Text = lvlBorrowerList.SelectedItems(0).SubItems(17).Text
            If cmbtype.Text = "PROJECT" Or cmbtype.Text = "EQUIPMENT" Then
                cmbChargeTo1.Text = lvlBorrowerList.SelectedItems(0).SubItems(7).Text
            Else
                txtChargeTo1.Text = lvlBorrowerList.SelectedItems(0).SubItems(7).Text
            End If


            For Each ctr As Control In PanelBSForm.Controls
                If ctr.Name = "lvlBorrowerList" Then
                    ctr.Enabled = False
                ElseIf ctr.Name = "gboxSearch" Then
                    ctr.Enabled = True
                ElseIf ctr.Name = "PanelBSForm_btnExit" Then
                    ctr.Enabled = True
                Else
                    ctr.Enabled = True
                End If
            Next

            txtWithdrawn.Text = lvlBorrowerList.SelectedItems(0).SubItems(8).Text
            txtReleased.Text = lvlBorrowerList.SelectedItems(0).SubItems(9).Text
            txtNotedBy.Text = lvlBorrowerList.SelectedItems(0).SubItems(19).Text
            txtApproved_by.Text = lvlBorrowerList.SelectedItems(0).SubItems(19).Text
            txtRemarks.Text = lvlBorrowerList.SelectedItems(0).SubItems(18).Text
            cmbSelectBSorTS.Text = lvlBorrowerList.SelectedItems(0).SubItems(13).Text

            PanelBsForm_Save.Text = "Update (Ctrl + S)"
            'txtBsNo.Enabled = False
            lvlBorrowerList.Enabled = False

            cmbTypeofCharge.Enabled = False
            txtChargeTo.Enabled = False
            btn_picbox1.Enabled = False


        End If

        cmbSelectBSorTS.Focus()

    End Sub

    Private Sub RemoveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveToolStripMenuItem.Click
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        If MessageBox.Show("Are you sure you want to delete this data?", "Borrower Info:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_facilities", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure
                newCMD.Parameters.AddWithValue("@n", 25)
                newCMD.Parameters.AddWithValue("@bs_id", CInt(lvlBorrowerList.SelectedItems(0).Text))
                newCMD.Parameters.AddWithValue("@bs_no", lvlBorrowerList.SelectedItems(0).SubItems(1).Text)

                newCMD.ExecuteNonQuery()

                lvlBorrowerList.SelectedItems(0).Remove()

                'Dim fi_id As Integer = CInt(lvList.SelectedItems(0).Text)
                'Button2.PerformClick()
                'listfocus(lvList, fi_id)

                lvlist_loader()


            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try
        Else
            Exit Sub
        End If



    End Sub

    Private Sub txtChargeTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChargeTo.TextChanged
        If cmbTypeofCharge.Text = "PERSONAL" Then
            get_id_from_charge_to(0)
        ElseIf cmbTypeofCharge.Text = "WAREHOUSE" Then
            get_id_from_charge_to(1)
        ElseIf cmbTypeofCharge.Text = "ADFIL" Then
            get_id_from_charge_to(0)
        End If
    End Sub

    Public Sub get_id_from_charge_to(ByVal x As Integer)
        Dim newsql As New SQLcon
        Dim query As String = ""
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        Try
            newsql.connection.Open()
            If x = 0 Then
                query = "SELECT charge_to_id FROM dbCharge_to WHERE charge_to = '" & txtChargeTo.Text & "'"
            ElseIf x = 1 Then
                query = "SELECT wh_area_id FROM dbwh_area WHERE wh_area = '" & txtChargeTo.Text & "'"

            End If

            cmd = New SqlCommand(query, newsql.connection)
            dr = cmd.ExecuteReader

            While dr.Read
                If x = 0 Then
                    charge_to_id = dr.Item(0).ToString
                ElseIf x = 1 Then
                    charge_to_id = dr.Item(0).ToString
                End If

            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsql.connection.Close()
        End Try
    End Sub

    Private Sub txtChargeTo1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChargeTo1.TextChanged
        If cmbtype.Text = "PERSONAL" Then
            get_id_from_charge_to1(0)
        ElseIf cmbtype.Text = "WAREHOUSE" Then
            get_id_from_charge_to1(1)
        ElseIf cmbtype.Text = "ADFIL" Then
            get_id_from_charge_to1(0)
        End If
    End Sub

    Public Sub get_id_from_charge_to1(ByVal x As Integer)
        Dim newsql As New SQLcon
        Dim query As String = ""
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        Try
            newsql.connection.Open()
            If x = 0 Then
                query = "SELECT charge_to_id FROM dbCharge_to WHERE charge_to = '" & txtChargeTo1.Text & "'"
            ElseIf x = 1 Then
                query = "SELECT wh_area_id FROM dbwh_area WHERE wh_area = '" & txtChargeTo1.Text & "'"

            End If

            cmd = New SqlCommand(query, newsql.connection)
            dr = cmd.ExecuteReader

            While dr.Read
                If x = 0 Then
                    charge_to_id1 = dr.Item(0).ToString
                ElseIf x = 1 Then
                    charge_to_id1 = dr.Item(0).ToString
                End If

            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsql.connection.Close()
        End Try
    End Sub

    Private Sub FBorrowed_Item_Monitoring_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        pboxHeader.Width = FMain.Width - FMain.ToolStrip1.Width

        With lvList
            .Height = Me.Height - 110
            .Width = Me.Width - 30
        End With

        btnExit.Parent = pboxHeader
        btnExit.BringToFront()
        btnExit.Location = New Point(lvList.Width + 1, 10)

        gboxBorrowerMonitoringSearch.Parent = Me
        gboxBorrowerMonitoringSearch.Location = New Point(lvList.Bounds.Left, lvList.Height + 60)
        'cmbTypeofFacTools.Location = New Point(lvList.Bounds.Left, lvList.Height + 60)
        'cmbListOfFacilitiesTools.Location = New Point(cmbTypeofFacTools.Width + 20, lvList.Height + 60)
        pboxHeader.Width = Me.Width

        PanelBSForm.Location = New Point(Me.Bounds.Top, Me.Bounds.Left)
        PanelBSForm.Width = Me.Width
        PanelBSForm.Height = Me.Height
        lvlBorrowerList.Width = Me.Width - (txtApproved_by.Width + 30)
        lvlBorrowerList.Height = Me.Height - (GroupBox1.Height + 30 + gboxSearch.Height)

        PanelBSForm_btnExit.Parent = PanelBSForm
        PanelBSForm_btnExit.Location = New Point(btnExit.Location.X, btnExit.Location.Y)
        'gboxSearch.Location = New Point(txtApproved_by.Width + 20, lvList.Height + 25)
        'PanelBSForm_btnExit.Location = New Point(lvlBorrowerList.Width, (lvlBorrowerList.Location.Y - 40))

    End Sub

    Private Sub cmbTypeofFacTools_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTypeofFacTools.SelectedIndexChanged
        'If cmbTypeofFacTools.Text = "FACILITIES" Then
        '    LOAD_facilities_item()
        'ElseIf cmbTypeofFacTools.Text = "TOOLS" Then

        'End If

        load_fac_name(cmbListOfFacilitiesTools, cmbTypeofFacTools.Text)

    End Sub

    Public Sub load_fac_name(ByVal cmbobj As Object, ByVal fac_tools_type As String)
        Dim cbox As ComboBox = cmbobj

        cbox.Items.Clear()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_facilities", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 3)
            newCMD.Parameters.AddWithValue("@facility_tools", fac_tools_type)

            newDR = newCMD.ExecuteReader
            Dim a(5) As String
            While newDR.Read

                cbox.Items.Add(newDR.Item("facility_name").ToString)

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Private Sub txtWithdrawn_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWithdrawn.TextChanged, txtApproved_by.TextChanged, _
    txtNotedBy.TextChanged, txtReleased.TextChanged

        Dim tbox As TextBox = sender
        Dim n As Integer

        If tbox.Name = "txtWithdrawn" Then : n = 1 : ElseIf tbox.Name = "txtApproved_by" Then _
        : n = 4 : ElseIf tbox.Name = "txtNotedBy" Then : n = 3 _
        : ElseIf tbox.Name = "txtReleased" Then : n = 2 : End If

        Try
            If tbox.Text = "" Then
                ListBox1.Location = New System.Drawing.Point(tbox.Location.X, tbox.Location.Y + tbox.Height)
                ListBox1.Visible = False
            Else
                With ListBox1
                    .Location = New System.Drawing.Point(tbox.Location.X, tbox.Location.Y + tbox.Height)
                    .Visible = True
                    .Items.Clear()
                    .Width = tbox.Width
                End With

                get_withdraw(n, tbox)

            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtWithdrawn_keydown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWithdrawn.KeyDown, txtApproved_by.KeyDown, _
   txtNotedBy.KeyDown, txtReleased.KeyDown

        pub_textbox = sender

        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down Then
                ListBox1.Focus()
                ListBox1.SelectedIndex = 0

            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtWithdrawn_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSelectBSorTS.GotFocus, txtBsNo.GotFocus, DtpDate.GotFocus, cmbTypeofCharge.GotFocus, cmbChargeTo.GotFocus, txtChargeTo.GotFocus, txtQty.GotFocus, txtPurpose.GotFocus, cmbtype.GotFocus, cmbChargeTo1.GotFocus, txtChargeTo1.GotFocus, txtWithdrawn.GotFocus, txtReleased.GotFocus, txtNotedBy.GotFocus, txtApproved_by.GotFocus, txtRemarks.GotFocus
        sender.backcolor = Color.Yellow

        If txtWithdrawn.Focused Then
            txtname1 = txtWithdrawn.Name
            txtWithdrawn.SelectAll()
            'ListBox1.Visible = False

        ElseIf txtReleased.Focused Then
            txtname1 = txtReleased.Name
            txtReleased.SelectAll()
            'ListBox1.Visible = False

        ElseIf txtNotedBy.Focused Then
            txtname1 = txtNotedBy.Name
            txtNotedBy.SelectAll()
            'ListBox1.Visible = False

        ElseIf txtApproved_by.Focused Then
            txtname1 = txtApproved_by.Name
            txtApproved_by.SelectAll()
            'ListBox1.Visible = False

        End If

    End Sub

    Public Sub get_withdraw(ByVal n As Integer, ByVal tbox As TextBox)
        Dim counter As Integer
        Dim sqlconn As New SQLcon
        Try
            sqlconn.connection.Open()
            Dim sqlcomm As New SqlCommand
            Dim newdr As SqlDataReader

            sqlcomm.Connection = sqlconn.connection
            sqlcomm.CommandText = "sp_borrower"
            sqlcomm.CommandType = CommandType.StoredProcedure
            If n = 1 Then
                sqlcomm.Parameters.AddWithValue("@withdrawn_by", tbox.Text)
                sqlcomm.Parameters.AddWithValue("@n", 2)
            ElseIf n = 2 Then
                sqlcomm.Parameters.AddWithValue("@released_by", tbox.Text)
                sqlcomm.Parameters.AddWithValue("@n", 3)
            ElseIf n = 3 Then
                sqlcomm.Parameters.AddWithValue("@noted_by", tbox.Text)
                sqlcomm.Parameters.AddWithValue("@n", 4)
            ElseIf n = 4 Then
                sqlcomm.Parameters.AddWithValue("@approved_by", tbox.Text)
                sqlcomm.Parameters.AddWithValue("@n", 5)
            End If

            newdr = sqlcomm.ExecuteReader

            While newdr.Read
                If n = 1 Then
                    ListBox1.Items.Add(newdr.Item(0).ToString)
                    counter += 1
                ElseIf n = 2 Then
                    ListBox1.Items.Add(newdr.Item(0).ToString)
                    counter += 1
                ElseIf n = 3 Then
                    ListBox1.Items.Add(newdr.Item(0).ToString)
                    counter += 1
                ElseIf n = 4 Then
                    ListBox1.Items.Add(newdr.Item(0).ToString)
                    counter += 1
                End If

            End While
            newdr.Close()

            If counter > 0 Then
                ListBox1.Visible = True
            Else
                ListBox1.Visible = False

            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlconn.connection.Close()
        End Try
    End Sub

    Private Sub ListBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick
        If ListBox1.SelectedItems.Count > 0 Then
            For Each ctr As Control In PanelBSForm.Controls
                If ctr.Name = txtname1 Then
                    ctr.Text = ListBox1.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next
            ListBox1.Visible = False
        End If
    End Sub

    Private Sub ListBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ListBox1.SelectedItems.Count > 0 Then
                For Each ctr As Control In PanelBSForm.Controls
                    If ctr.Name = txtname1 Then
                        ctr.Text = ListBox1.SelectedItem.ToString
                        ctr.Focus()
                    End If
                Next
                ListBox1.Visible = False
            End If

        ElseIf e.KeyCode = Keys.Up Then
            If ListBox1.SelectedIndex = 0 Then
                Dim f As Integer
                f = 1

                If f = 1 Then
                    pub_textbox.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub CommonHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If ListBox1.Visible = True Then
            ListBox1.Visible = False
        End If

    End Sub

    Private Sub ListBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.Leave
        'AddHandler pub_textbox.GotFocus, AddressOf CommonHandler
        'AddHandler pub_combox.GotFocus, AddressOf CommonHandler

    End Sub


    Private Sub SetEstimatedDaysReturnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetEstimatedDaysReturnToolStripMenuItem.Click
        FBorrower_Expiration.lbl_bs_id.Text = lvlBorrowerList.SelectedItems(0).Text
        FBorrower_Expiration.ShowDialog()

    End Sub

    Private Sub txtQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQty.TextChanged

    End Sub

    Private Sub CMS_lvlBorrowerList_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMS_lvlBorrowerList.Opening
        If lvlBorrowerList.SelectedItems.Count > 0 Then
            If lvlBorrowerList.SelectedItems(0).SubItems(12).Text = "waiting..." Then
                SetEstimatedDaysReturnToolStripMenuItem.Enabled = True
                TurnoverToolStripMenuItem.Enabled = True
                EditToolStripMenuItem.Enabled = True
                RemoveToolStripMenuItem.Enabled = True
                RemoveItemTurnoverToolStripMenuItem.Enabled = False
                CreateChargesToolStripMenuItem.Enabled = True

            Else
                SetEstimatedDaysReturnToolStripMenuItem.Enabled = False
                ' TurnoverToolStripMenuItem.Enabled = False
                RemoveItemTurnoverToolStripMenuItem.Enabled = True
                RemoveToolStripMenuItem.Enabled = True
                TurnoverToolStripMenuItem.Enabled = True
                EditToolStripMenuItem.Enabled = True
            End If
        Else
            SetEstimatedDaysReturnToolStripMenuItem.Enabled = False
            TurnoverToolStripMenuItem.Enabled = False
            EditToolStripMenuItem.Enabled = False
            ' RemoveToolStripMenuItem.Enabled = False
            RemoveItemTurnoverToolStripMenuItem.Enabled = False
            RemoveToolStripMenuItem.Enabled = False
            CreateChargesToolStripMenuItem.Enabled = False

        End If

    End Sub

    Private Sub btn_picbox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_picbox1.Click
        Select Case cmbTypeofCharge.Text

            Case "ADFIL"
                charge_to_selection = 2
            Case "WAREHOUSE"
                charge_to_selection = 1
            Case "PERSONAL"
                charge_to_selection = 2
            Case "CASH"
                charge_to_selection = 2

        End Select

        charge_to_destination = 4
        FCharge_To.ShowDialog()
    End Sub

    Private Sub btn_picbox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_picbox2.Click
        Select Case cmbtype.Text

            Case "ADFIL"
                charge_to_selection = 2
            Case "WAREHOUSE"
                charge_to_selection = 1
            Case "PERSONAL"
                charge_to_selection = 2
            Case "CASH"
                charge_to_selection = 2

        End Select

        charge_to_destination = 7
        FCharge_To.ShowDialog()
    End Sub

    Private Sub Timer_PanelBSFormt_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_PanelBSFormt.Tick
        PanelBSForm.Location = panloc - curloc + System.Windows.Forms.Cursor.Position
        setpositions()
    End Sub
    Private Sub setpositions()
        panloc = PanelBSForm.Location
        curloc = System.Windows.Forms.Cursor.Position
    End Sub

    Private Sub RemoveToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveToolStripMenuItem1.Click

        If MessageBox.Show("Are you sure you want delete this selected data?", "Borrower Info:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            For Each item As ListViewItem In lvList.Items
                If item.Selected = True Then
                    remove_borrower_list_of_items(CInt(item.Text))
                    item.Remove()
                End If
            Next
        End If

    End Sub

    Public Sub remove_borrower_list_of_items(ByVal fi_id As Integer)
        Try
            Dim query, query1, query2 As String

            query = "DELETE FROM dbfacilities_items WHERE fi_id = " & fi_id
            UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

            query1 = "DELETE FROM dbBorrower_Slip WHERE fi_id = " & fi_id
            UPDATE_INSERT_DELETE_QUERY(query1, 0, "DELETE")

            query2 = "DELETE FROM dbBorrower_Slip_Turnover WHERE fi_id = " & fi_id
            UPDATE_INSERT_DELETE_QUERY(query2, 0, "DELETE")

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbSearchByCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSearchByCategory.SelectedIndexChanged
        cmbTypeofCategory.Items.Clear()
        cmbSearch.Items.Clear()

        'If cmbSearchByCategory.Text = "Custodian" Then

        '    'cmbTypeofCategory.Location = New Point(txtSearch.Bounds.Left + 3, txtSearch.Bounds.Top)
        '    'txtSearch.Visible = False
        '    'cmbTypeofCategory.Items.Clear()
        '    'FRequestField.load_type_of_request("CASH", cmbTypeofCategory)
        '    'cmbTypeofCategory.Width = txtSearch.Width

        '    cmbTypeofCategory.Enabled = True
        '    cmbTypeofCategory.Visible = True
        '    cmbSearch.Enabled = True
        '    cmbTypeofCategory.Visible = True
        '    PanelBsForm_Save.Enabled = False

        'ElseIf cmbSearchByCategory.Text = "Default" Then
        '    cmbTypeofCategory.Location = New Point(txtSearch.Bounds.Left + 3, txtSearch.Bounds.Top)
        '    txtSearch.Visible = False
        '    cmbTypeofCategory.Items.Clear()
        '    FRequestField.load_type_of_request("CASH", cmbTypeofCategory)
        '    cmbTypeofCategory.Width = txtSearch.Width

        '    cmbTypeofCategory.Enabled = True
        '    cmbTypeofCategory.Visible = True
        '    cmbSearch.Enabled = True
        '    cmbTypeofCategory.Visible = True

        '    PanelBsForm_Save.Enabled = True
        '    btnSearch.PerformClick()


        'ElseIf cmbSearchByCategory.Text = "Charges" Then
        '    cmbTypeofCategory.Location = New Point(txtSearch.Bounds.Left + 3, txtSearch.Bounds.Top)
        '    txtSearch.Visible = False
        '    cmbTypeofCategory.Items.Clear()
        '    FRequestField.load_type_of_request("CASH", cmbTypeofCategory)
        '    cmbTypeofCategory.Width = txtSearch.Width

        '    cmbTypeofCategory.Enabled = True
        '    cmbTypeofCategory.Visible = True
        '    cmbSearch.Enabled = True
        '    cmbTypeofCategory.Visible = True
        '    PanelBsForm_Save.Enabled = False



        'ElseIf cmbSearchByCategory.Text = "BS_NO" Then

        '    txtSearch.Visible = True
        '    cmbTypeofCategory.Items.Clear()
        '    FRequestField.load_type_of_request("CASH", cmbTypeofCategory)
        '    cmbTypeofCategory.Width = txtSearch.Width

        '    cmbTypeofCategory.Enabled = False
        '    cmbTypeofCategory.Visible = False
        '    cmbSearch.Enabled = False
        '    cmbTypeofCategory.Visible = False
        '    PanelBsForm_Save.Enabled = False

        'ElseIf cmbSearchByCategory.Text = "Item Name" Then
        '    txtSearch.Visible = True
        '    cmbTypeofCategory.Items.Clear()
        '    FRequestField.load_type_of_request("CASH", cmbTypeofCategory)
        '    cmbTypeofCategory.Width = txtSearch.Width

        '    cmbTypeofCategory.Enabled = False
        '    cmbTypeofCategory.Visible = False
        '    cmbSearch.Enabled = False
        '    cmbTypeofCategory.Visible = False
        '    PanelBsForm_Save.Enabled = False


        'End If

    End Sub

    Private Sub cmbTypeofCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTypeofCategory.SelectedIndexChanged
        cmbSearch.Location = New Point(cmbTypeofCategory.Bounds.Right + 10, cmbTypeofCategory.Bounds.Top)
        cmbSearch.Visible = True
        txtSearch.Visible = False
        cmbSearch.Width = 240
        btnSearch.Location = New Point(cmbSearch.Bounds.Right + 10, cmbSearch.Bounds.Top)

        If cmbTypeofCategory.Text = "ADFIL" Then
            load_charge_to(1)

        ElseIf cmbTypeofCategory.Text = "PROJECT" Then
            FRequestField.load_equipment(1, cmbSearch)
        ElseIf cmbTypeofCategory.Text = "WAREHOUSE" Then
            load_charge_to(0)
        ElseIf cmbTypeofCategory.Text = "PERSONAL" Then
            load_charge_to(1)
        ElseIf cmbTypeofCategory.Text = "SUPPLIER" Then
            load_charge_to(2)
        End If
    End Sub

    Public Sub load_charge_to(ByVal n As Integer)
        Dim newSQ As New SQLcon
        Dim newcmd As SqlCommand
        Dim newdr As SqlDataReader

        cmbSearch.Items.Clear()

        Try
            newSQ.connection.Open()

            If n = 0 Then
                publicquery = "SELECT * FROM dbwh_area"
            ElseIf n = 1 Then
                publicquery = "SELECT * FROM dbCharge_to ORDER BY charge_to ASC"
            ElseIf n = 2 Then
                publicquery = "SELECT * FROM dbSupplier"
            End If

            newcmd = New SqlCommand(publicquery, newSQ.connection)
            newdr = newcmd.ExecuteReader
            While newdr.Read
                Dim a(5) As String

                If n = 0 Then
                    a(0) = newdr.Item(0).ToString
                    a(1) = newdr.Item(1).ToString
                    a(2) = newdr.Item(3).ToString
                ElseIf n = 1 Then
                    a(0) = newdr.Item(0).ToString
                    a(1) = UCase(newdr.Item(1).ToString)
                ElseIf n = 2 Then
                    a(0) = newdr.Item(0).ToString
                    a(1) = newdr.Item(1).ToString
                End If

                cmbSearch.Items.Add(UCase(a(1)))

            End While

            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

        End Try
    End Sub

    Public Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        'If cmbSearchByCategory.Text = "Custodian" Then
        '    PanelBsForm_Save.Enabled = False
        '    borrower_slip_list(1)
        'ElseIf cmbSearchByCategory.Text = "Default" Then
        '    PanelBsForm_Save.Enabled = True
        '    borrower_slip_list(0)
        'ElseIf cmbSearchByCategory.Text = "Charges" Then
        '    PanelBsForm_Save.Enabled = False
        '    borrower_slip_list(4)
        'ElseIf cmbSearchByCategory.Text = "BS_NO" Then
        '    PanelBsForm_Save.Enabled = False
        '    borrower_slip_list(3)

        'ElseIf cmbSearchByCategory.Text = "Item Name" Then
        '    PanelBsForm_Save.Enabled = False
        '    borrower_slip_list(5)

        'End If

        If cmbSearchByCategory.Text = "Default" Then
            PanelBsForm_Save.Enabled = True
            borrower_slip_list(0)
        Else
            PanelBsForm_Save.Enabled = True
            borrower_slip_list(5)
        End If

    End Sub
    Private Sub SearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchToolStripMenuItem.Click

        'For Each ctr As Control In Me.Controls
        '    If ctr.Name = "PanelBSForm" Then
        '        ctr.Visible = True
        '    Else
        '        ctr.Enabled = False
        '    End If
        'Next


        'cmbTypeofCharge.Items.Clear()
        'cmbtype.Items.Clear()

        'FRequestField.load_type_of_request("CASH", cmbTypeofCharge)
        'FRequestField.load_type_of_request("CASH", cmbtype)

        ''If exist > 0 Then
        ''    PanelBsForm_Save.Text = "Update"
        ''Else
        ''    PanelBsForm_Save.Text = "Save"
        ''End If

        ''get_bs_no(CInt(lvList.SelectedItems(0).Text), 1)

        '''========don't delete======
        'PanelBSForm.Location = New Point(Me.Bounds.Top, Me.Bounds.Left)
        'PanelBSForm.Width = Me.Width
        'PanelBSForm.Height = Me.Height
        'lvlBorrowerList.Width = Me.Width - (txtApproved_by.Width + 30)
        'lvlBorrowerList.Height = Me.Height - (GroupBox1.Height + 30 + gboxSearch.Height)

        'gboxSearch.Location = New Point(txtApproved_by.Width + 20, lvList.Height + 45)
        'PanelBSForm_btnExit.Location = New Point(lvlBorrowerList.Width, (lvlBorrowerList.Location.Y - 40))
        '''=======end don't delete=======

        'FMain.PictureBox1.Hide()
        'FMain.PictureBox2.Hide()
        'FMain.PictureBox3.Hide()

        'FMain.ToolStrip1.Hide()

        'cmbTypeofCategory.Location = New Point(txtSearch.Bounds.Left + 3, txtSearch.Bounds.Top)
        'txtSearch.Visible = False
        'FRequestField.load_type_of_request("CASH", cmbTypeofCategory)
        'cmbTypeofCategory.Width = txtSearch.Width

        ''cmbSearch.Location = New Point(cmbTypeofCategory.Bounds.Right + 10, cmbTypeofCategory.Bounds.Top)
        ''cmbSearch.Visible = True
        ''txtSearch.Visible = False
        ''cmbSearch.Width = 240
        ''btnSearch.Location = New Point(cmbSearch.Bounds.Right + 10, cmbSearch.Bounds.Top)
        'Me.Refresh()

        'ifsearch = 2

        'cmbSearchByCategory.Items.Clear()


        'cmbSearchByCategory.Items.Add("Default")
        'cmbSearchByCategory.Items.Add("Custodian")
        'cmbSearchByCategory.Items.Add("Charges")
        'cmbSearchByCategory.Items.Add("BS_NO")
        'cmbSearchByCategory.Items.Add("Item Name")
        'cmbSearchByCategory.Items.Add("Brand")
        'cmbSearchByCategory.Items.Add("Item No.")


        'PanelBsForm_Save.Enabled = False

        'btnSearch.PerformClick()

        'PanelBSForm_btnExit.Parent = PanelBSForm
        'PanelBSForm_btnExit.Location = New Point(btnExit.Location.X, btnExit.Location.Y)

        'txtSearch.Visible = True
        'cmbTypeofCategory.Items.Clear()
        'FRequestField.load_type_of_request("CASH", cmbTypeofCategory)
        'cmbTypeofCategory.Width = txtSearch.Width

        'cmbTypeofCategory.Enabled = False
        'cmbTypeofCategory.Visible = False
        'cmbSearch.Enabled = False
        'cmbTypeofCategory.Visible = False
        'PanelBsForm_Save.Enabled = False

        'PanelBsForm_Save.Enabled = False




        With FBorrowed_Item_List
            .cmbSearchBy.Items.Clear()

            .cmbSearchBy.Items.Add("Custodian")
            .cmbSearchBy.Items.Add("Charges")
            .cmbSearchBy.Items.Add("BS_NO")
            .cmbSearchBy.Items.Add("Item Name")
            .cmbSearchBy.Items.Add("Brand")
            .cmbSearchBy.Items.Add("Item No.")

            '.public_fi_id = CInt(lvList.SelectedItems(0).Text)
            .search()
            .ShowDialog()
            .PanelBsForm_Save.Enabled = False
        End With



    End Sub
    Public Sub search_item_disable()

        For Each ctr As Control In PanelBSForm.Controls
            If ctr.Name = "lvlBorrowerList" Then
                ctr.Enabled = True
            ElseIf ctr.Name = "gboxSearch" Then
                ctr.Enabled = False
            ElseIf ctr.Name = "PanelBSForm_btnExit" Then
                ctr.Enabled = True
            Else
                ctr.Enabled = True
            End If
        Next

    End Sub

    Private Sub CMS_lvList_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMS_lvList.Opening
        If lvList.SelectedItems.Count > 0 Then
            For Each ctr As ToolStripMenuItem In CMS_lvList.Items
                ctr.Enabled = True

            Next
        Else
            For Each ctr As ToolStripMenuItem In CMS_lvList.Items
                If ctr.Name = "InsertOldFacilitiesToolStripMenuItem" Then
                    ctr.Enabled = True
                ElseIf ctr.Name = "SearchToolStripMenuItem" Then
                    ctr.Enabled = True
                Else
                    ctr.Enabled = False
                End If

            Next
        End If
    End Sub

    Private Sub RemoveItemTurnoverToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveItemTurnoverToolStripMenuItem.Click
        Dim bs_id As Integer = CInt(lvlBorrowerList.SelectedItems(0).Text)

        Try
            If MessageBox.Show("Are you sure you want to delete this data?", "BORROWER INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim query As String = "DELETE FROM dbBorrower_Slip_Turnover WHERE borrower_slip_id = " & CInt(lvlBorrowerList.SelectedItems(0).Text)
                Dim n As Integer = UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

                query = Nothing

                query = "DELETE FROM dbMultipleCharges WHERE fi_id = " & CInt(lvlBorrowerList.SelectedItems(0).SubItems(23).Text)
                UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

                MessageBox.Show("Successfully Deleted...", "BORROWER INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)

                btnSearch.PerformClick()
                listfocus(lvlBorrowerList, bs_id)

            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        LOAD_facilities_item()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FProjectIncharge.lbl_sign.Text = "B"
        If txtChargeTo.Text = "ADFIL" Then

          
            With FProjectIncharge
                .lvlListofCharges.Items.Clear()

                .load_all(.lvlListofCharges, 0, "PROJECT")
                .load_all(.lvlListofCharges, 0, "MAINOFFICE")
                .load_all(.lvlListofCharges, 0, "PERSONAL")
                .load_all(.lvlListofCharges, 0, "EQUIPMENT")
                .load_all(.lvlListofCharges, 0, "WAREHOUSE")

            End With

            Dim newSQ As New SQLcon
            Dim newCMD As SqlCommand
            Dim newDR As SqlDataReader

            Try
                newSQ.connection.Open()

                Dim rs_id As Integer = get_rs_id()
                FProjectIncharge.lbl_rs_id.Text = rs_id
                Dim query As String = "SELECT * FROM dbMultipleCharges WHERE rs_id = " & rs_id '& " AND fi_id = " & CInt(lvList.SelectedItems(0).Text)

                newCMD = New SqlCommand(query, newSQ.connection)
                newDR = newCMD.ExecuteReader
                Dim a(10) As String
                While newDR.Read

                    Dim all_charges_id As Integer = CInt(newDR.Item("all_charges_id").ToString)
                    Dim type_name As String = newDR.Item("type_name").ToString

                    a(0) = all_charges_id

                    If type_name = "PROJECTS" Then
                        a(1) = GET_equip_desc_AND_proj_desc(all_charges_id, 2)
                    End If

                    a(2) = newDR.Item("type_name").ToString

                    Dim checkInt As Integer = FindItem(FProjectIncharge.lvlListofCharges, all_charges_id) 'DTPTripForDelete.Text)
                    If checkInt <> -1 Then
                        FProjectIncharge.lvlListofCharges.Items(checkInt).Checked = True
                    End If

                End While

                newDR.Close()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
                FProjectIncharge.btnOk.Text = "UPDATE"

                FProjectIncharge.ShowDialog()

            End Try

        End If
    End Sub

    Private Function get_rs_id() As Integer

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT rs_id FROM dbPO_details WHERE po_det_id = " & CInt(lvlBorrowerList.SelectedItems(0).SubItems(25).Text)

            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_rs_id = CInt(newDR.Item("rs_id").ToString)
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function

    Private Sub CreateChargesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateChargesToolStripMenuItem.Click
        FCreateCharges.lbl_bs_status.Text = "Borrow"
        load_intended_charges_from_rs()

        FCreateCharges.ShowDialog()

    End Sub
    Public Sub load_intended_charges_from_rs()
        FCreateCharges.lvlListofCharges.Items.Clear()
        Dim sq As New SQLcon
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim sqlcon As New SQLcon
        Dim fi_id As Integer = CInt(lvlBorrowerList.SelectedItems(0).SubItems(23).Text)
        Dim rs_id As Integer = get_rs_id()

        Try
            sq.connection.Open()

            Dim query As String

            If rs_id = 0 Then
                query = "SELECT * FROM dbMultipleCharges WHERE fi_id = " & fi_id
            Else
                query = "SELECT * FROM dbMultipleCharges WHERE rs_id = " & rs_id
            End If


            cmd = New SqlCommand(query, sq.connection)
            dr = cmd.ExecuteReader
            While dr.Read

                Dim a(3) As String
                Dim charge_to_id As Integer = CInt(dr.Item("all_charges_id").ToString)

                a(0) = charge_to_id

                If dr.Item("type_name").ToString = "PROJECTS" Then
                    a(1) = GET_equip_desc_AND_proj_desc(charge_to_id, 2)

                ElseIf dr.Item("type_name").ToString = "MAINOFFICE" Then
                    a(1) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)

                ElseIf dr.Item("type_name").ToString = "WAAREHOUSE" Then
                    a(1) = GET_equip_desc_AND_proj_desc(charge_to_id, 4)

                ElseIf dr.Item("type_name").ToString = "PERSONAL" Then
                    a(1) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)

                ElseIf dr.Item("type_name").ToString = "EQUIPMENT" Then
                    a(1) = GET_equip_desc_AND_proj_desc(charge_to_id, 1)

                End If

                a(2) = dr.Item("type_name").ToString

                Dim lvl As New ListViewItem(a)
                FCreateCharges.lvlListofCharges.Items.Add(lvl)

            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sq.connection.Close()
        End Try
    End Sub

    Private Sub PanelBSForm_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelBSForm.Paint

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSearchBy.SelectedIndexChanged
        If cmbSearchBy.Text = "Items" Then
            cmbTypeofFacTools.Enabled = True
            cmbListOfFacilitiesTools.Enabled = True
            cmbTypeofFacTools.Visible = True
            cmbOtherSearch.Visible = False
        ElseIf cmbSearchBy.Text = "Status" Then
            cmbListOfFacilitiesTools.Enabled = False
            cmbOtherSearch.Visible = True
            cmbOtherSearch.Location = New Point(cmbTypeofFacTools.Bounds.Left, cmbTypeofFacTools.Bounds.Top)
            cmbTypeofFacTools.Visible = False

        End If
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBMsearch.Click
    
        Try
            ' trd1.Start()
            If cmbSearchBy.Text = "Items" Then
                LOAD_facilities_item()

            ElseIf cmbSearchBy.Text = "Status" Then
                load_all_items_borrow(cmbOtherSearch.Text)

            End If


            'Threading.Thread.Sleep(1000)
            'trd1.Abort()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally


        End Try
    

    End Sub
    Public Sub loading()
        Floading.ShowDialog()
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()

        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub
End Class

