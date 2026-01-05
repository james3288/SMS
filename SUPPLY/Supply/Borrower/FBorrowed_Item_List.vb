Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FBorrowed_Item_List
    Public public_fi_id As Integer
    Public pub_bs_id As Integer

    Private Sub PanelBSForm_btnExit_Click(sender As Object, e As EventArgs)

    End Sub

    Public Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        search()
    End Sub
    Public Sub search()
        If cmbSearchBy.Text = "Search By Default" Then
            PanelBsForm_Save.Enabled = True
            borrower_slip_list(0)
        Else
            PanelBsForm_Save.Enabled = True
            borrower_slip_list(6)
        End If
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
                newCMD.Parameters.AddWithValue("@fi_id", public_fi_id)
            ElseIf m = 5 Then
                'newCMD.Parameters.AddWithValue("@n", 33)
                'newCMD.Parameters.AddWithValue("@type_of_charge", cmbSearchByCategory.Text)
                'newCMD.Parameters.AddWithValue("@bs_no", "")

                'If cmbTypeofCategory.Text = "ADFIL" Then
                '    Dim charges_id As Integer = get_id("dbCharge_to", "charge_to", cmbSearch.Text, 0)
                '    newCMD.Parameters.AddWithValue("@charge_id", charges_id)

                'ElseIf cmbTypeofCategory.Text = "PROJECT" Then
                '    Dim charges_id As Integer = get_id_proj_equip(0, cmbSearch.Text)
                '    newCMD.Parameters.AddWithValue("@charge_id", charges_id)

                'ElseIf cmbTypeofCategory.Text = "EQUIPMENT" Then
                '    Dim charges_id As Integer = get_id_proj_equip(1, cmbSearch.Text)
                '    newCMD.Parameters.AddWithValue("@charge_id", charges_id)

                'ElseIf cmbTypeofCategory.Text = "WAREHOUSE" Then
                '    Dim charges_id As Integer = get_id("dbwh_area", "wh_area", cmbSearch.Text, 0)
                '    newCMD.Parameters.AddWithValue("@charge_id", charges_id)

                'End If

            ElseIf m = 6 Then
                newCMD.Parameters.AddWithValue("@n", 34)
            End If

            newDR = newCMD.ExecuteReader
            Dim a(25) As String

            While newDR.Read

                Dim borrower_slip_id As Integer = CInt(newDR.Item("borrower_slip_id").ToString)
                With FBorrowed_Item_Monitoring


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
                    a(7) = UCase(.get_charges_name(CInt(newDR.Item("borrowed_by").ToString), newDR.Item("type_borrowed_by").ToString)) ' custodian here
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
                    result = IIf(year > 0, year & " years, ", year & " year,") & " " & IIf(month1 > 1, month1 & " months", month1 & " month") &
                       " and " &
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

                    a(20) = IIf(newDR.Item("bs_tr").ToString = "BS", date_borrow.AddDays(.borrower_expiration(pub_bs_id)), "N/A")

                    If cmbSearchBy.Text = "Item Name" Then
                        If search_by(a(22), txtSearch.Text) = True Then
                        Else
                            GoTo proceedhere
                        End If

                    ElseIf cmbSearchBy.Text = "Custodian" Then
                        If search_by(a(7), txtSearch.Text) = True Then
                        Else
                            GoTo proceedhere
                        End If

                    ElseIf cmbSearchBy.Text = "Charges" Then
                        If search_by(a(3), txtSearch.Text) = True Then
                        Else
                            GoTo proceedhere
                        End If

                    ElseIf cmbSearchBy.Text = "Item No." Then
                        If search_by(a(21), txtSearch.Text) = True Then
                        Else
                            GoTo proceedhere
                        End If

                    ElseIf cmbSearchBy.Text = "Brand" Then
                        If search_by(a(4), txtSearch.Text) = True Then
                        Else
                            GoTo proceedhere
                        End If

                    ElseIf cmbSearchBy.Text = "BS_NO" Then
                        If search_by(a(1), txtSearch.Text) = True Then
                        Else
                            GoTo proceedhere
                        End If

                    End If

                    Dim lvl As New ListViewItem(a)
                    lvlBorrowerList.Items.Add(lvl)

                    Dim date_expired As DateTime = date_borrow.AddDays(.borrower_expiration(pub_bs_id))
                    Dim date_expired_result As TimeSpan = Now - date_expired


                    If newDR.Item("bs_tr").ToString = "BS" Then
                        If lvlBorrowerList.Items(inc).SubItems(12).Text = "waiting..." Then
                            If .downtimedays(Now, date_expired) <= 0 Then
                                lvlBorrowerList.Items(inc).BackColor = Color.Red
                                lvlBorrowerList.Items(inc).ForeColor = Color.White
                            End If
                        Else
                            If .downtimedays(Date.Parse(lvlBorrowerList.Items(inc).SubItems(15).Text), date_expired) <= 0 Then
                                lvlBorrowerList.Items(inc).BackColor = Color.Orange
                                lvlBorrowerList.Items(inc).ForeColor = Color.Black
                            Else
                                lvlBorrowerList.Items(inc).BackColor = Color.GreenYellow
                                lvlBorrowerList.Items(inc).ForeColor = Color.Black
                            End If
                        End If
                    End If
                End With

                inc += 1

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
                    turnover_location = FBorrowed_Item_Monitoring.get_charges_name(CInt(newDR.Item("turnover_location_id").ToString), newDR.Item("turnover_location").ToString)
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

    Private Sub FBorrowed_Item_List_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub cmbSearchBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearchBy.SelectedIndexChanged
        If cmbSearchBy.Text = "Search By Default" Then
        Else
            txtSearch.Enabled = True
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            search()

        End If
    End Sub

    Private Sub PanelBsForm_Save_Click(sender As Object, e As EventArgs) Handles PanelBsForm_Save.Click
        Dim bs_id As Integer
        With FBorrowed_Item_Monitoring
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
                    bs_id = .bs_form_save_update("save")
                Else
                    'count nya og naa nabay na store nga bslip ani nga item, kung zero wala pa
                    If lvlBorrowerList.Items.Count = 0 Then
                        bs_id = .bs_form_save_update("save")
                    Else
                        MessageBox.Show("This item has not been return yet..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If


                End If

                'lvlist_loader()

                Dim fi_id As Integer = public_fi_id

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
                        .update_borrower_turonver_bsno(txtBsNo.Text, lvlBorrowerList.SelectedItems(0).SubItems(1).Text)
                    End If

                    .update_borrowed_slip_form()

                    'lvlist_loader()

                    btnSearch.PerformClick()
                    listfocus(lvlBorrowerList, bs_id)

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


            End If
        End With

    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
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

    Private Sub cmbtype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtype.SelectedIndexChanged
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

    Private Sub btn_picbox2_Click(sender As Object, e As EventArgs) Handles btn_picbox2.Click
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

        charge_to_destination = 10
        FCharge_To.ShowDialog()
    End Sub
End Class