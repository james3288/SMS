Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FBorrower_Details
    Public txtname As String
    Private Sub cmbChargesType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbChargesType.SelectedIndexChanged
        FProjectIncharge.load_all(cmbChargesDesc, 1, cmbChargesType.Text)
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Dim br_tr_id As Integer
        Dim br_rs_id As Integer
        'Dim rs_id As Integer = check_if_numeric(FListofBorrowerItem.lvlBorrowerItem.SelectedItems(0).Text)
        Dim count As Integer

        If btnSave.Text = "Save" Then
            br_rs_id = FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text

            If MessageBox.Show("Are you sure you want to Borrow this item?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                If listview_counter(lvlBorrowerItem, "checked") = 0 Then
                    MessageBox.Show("You must check the item atleast one(1).", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                br_tr_id = save_update_borrower_info(1)
            Else
                Exit Sub
            End If

        ElseIf btnSave.Text = "Update" Then
            br_rs_id = CInt(lvlBorrowerItem.SelectedItems(0).SubItems(20).Text)

            If MessageBox.Show("Are you sure you want to update this item?", "SUPPLY INFO: ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                save_update_borrower_info(11)
                clear()

                'txtBsNo.Enabled = False
                'txtPurpose.Enabled = False
                'txtWithdrawn.Enabled = False
                'txtReleased.Enabled = False
                'txtNotedBy.Enabled = False
                'txtApproved_by.Enabled = False
                'txtRemarks.Enabled = False
                'btnToggle.Enabled = False
                'DtpDate.Enabled = False
                'cmbChargesDesc.Enabled = False
                'cmbChargesType.Enabled = False
                'btnAddTempCustodian.Enabled = False
                'cmbSelectBSorTS.Enabled = False
                'btnSave.Enabled = False

                For Each ctr As Control In TableLayoutPanel1.Controls
                    If ctr.Name = "Panel2" Then
                        ctr.Enabled = False
                    Else
                        ctr.Enabled = True

                    End If
                Next

                Exit Sub
            Else
                Exit Sub
            End If
        End If

        For Each row As ListViewItem In lvlBorrowerItem.Items
            If row.Checked = True Then
                insert_into_dbborrower_details(CInt(row.Text), row.SubItems(1).Text, CInt(row.SubItems(2).Text), CInt(row.SubItems(3).Text), br_tr_id, br_rs_id)
            End If
        Next

        clear()

        Me.Close()
        FRequistionForm.btnSearch.PerformClick()
        listfocus(FRequistionForm.lvlrequisitionlist, br_rs_id)

        txtReleased.Text = "Christopher Q. Balbin"
        txtNotedBy.Text = "Vanessa F. Piedad"
        txtApproved_by.Text = "Mercy Fe G. Cupay"

        'FListofBorrowerItem.btnBMsearch.PerformClick()
        'istfocus(FListofBorrowerItem.lvlBorrowerItem, rs_id)
    End Sub
    Public Sub insert_into_dbborrower_details(ByVal rr_item_sub_id As Integer, ByVal sub_item_desc As String, ByVal qty As Integer, ByVal rr_item_id As Integer, ByVal br_tr_id As Integer, ByVal br_rs_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 2)

            newCMD.Parameters.AddWithValue("@rr_item_sub_id", rr_item_sub_id)
            newCMD.Parameters.AddWithValue("@br_tr_id", br_tr_id)
            newCMD.Parameters.AddWithValue("@sub_item_desc", sub_item_desc)
            newCMD.Parameters.AddWithValue("@qty", qty)
            newCMD.Parameters.AddWithValue("@rr_item_id", rr_item_id)
            newCMD.Parameters.AddWithValue("@rs_id", br_rs_id)

            Dim br_tr_det_id As Integer = newCMD.ExecuteScalar()

            insert_external_days(br_tr_det_id, CInt(txtEstimatedDaysReturn.Text), CInt(txtdaysExtension.Text))


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Public Sub insert_external_days(ByVal br_tr_det_id As Integer, ByVal external_days As Integer, ByVal extendeddays As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 9)
            newCMD.Parameters.AddWithValue("@br_tr_det_id", br_tr_det_id)
            newCMD.Parameters.AddWithValue("@estimated_days_return", external_days)
            newCMD.Parameters.AddWithValue("@extended", extendeddays)

            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Public Sub update_external_days(ByVal br_tr_det_id As Integer, ByVal external_days As Integer, ByVal extendeddays As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 10)
            newCMD.Parameters.AddWithValue("@br_tr_det_id", br_tr_det_id)
            newCMD.Parameters.AddWithValue("@estimated_days_return", external_days)
            newCMD.Parameters.AddWithValue("@extended", extendeddays)

            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Public Function save_update_borrower_info(ByVal n As Integer) As Integer
        'Dim charges As New function_charges

        'Dim typeofcharges As String = cmbChargesType.Text
        'Dim charge_id As Integer = charges.charges_id(typeofcharges, cmbChargesDesc.Text)
        Dim br_tr_id As Integer
        Dim multiplecharges As String = ""

        For Each row As ListViewItem In lvlMultipleCustodian.Items
            Dim charges As New function_charges

            Dim typeofcharges As String = row.Text
            Dim charge_id As Integer = charges.charges_id(typeofcharges, row.SubItems(1).Text)

            multiplecharges &= typeofcharges & ":" & charge_id & ","
        Next

        multiplecharges = remove_last_character(multiplecharges)

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            If n = 1 Then
                newCMD.Parameters.AddWithValue("@n", 1)
            ElseIf n = 11 Then
                br_tr_id = CInt(lvlBorrowerItem.SelectedItems(0).SubItems(16).Text)
                newCMD.Parameters.AddWithValue("@n", 11)
                newCMD.Parameters.AddWithValue("@br_tr_id", br_tr_id)
            End If

            newCMD.Parameters.AddWithValue("@typeofborrow", cmbSelectBSorTS.Text)
            newCMD.Parameters.AddWithValue("@date_borrow", Date.Parse(DtpDate.Text))
            newCMD.Parameters.AddWithValue("@bs_no", txtBsNo.Text)
            newCMD.Parameters.AddWithValue("@purpose", txtPurpose.Text)
            newCMD.Parameters.AddWithValue("@typeofcharges", "")
            newCMD.Parameters.AddWithValue("@charges_id", 0)
            newCMD.Parameters.AddWithValue("@withdrawn_by", txtWithdrawn.Text)
            newCMD.Parameters.AddWithValue("@released_by", txtReleased.Text)
            newCMD.Parameters.AddWithValue("@noted_by", txtNotedBy.Text)
            newCMD.Parameters.AddWithValue("@approved_by", txtApproved_by.Text)
            newCMD.Parameters.AddWithValue("@remarks", txtRemarks.Text)
            newCMD.Parameters.AddWithValue("@multiple_charges", multiplecharges)

            If n = 1 Then
                save_update_borrower_info = newCMD.ExecuteScalar()
            ElseIf n = 11 Then
                newCMD.ExecuteNonQuery()

                btnSave.Text = "Save"
                lvlBorrowerItem.Enabled = True
                btnToggle.Text = ">"
                lvlMultipleCustodian.Visible = False

                update_external_days(CInt(lvlBorrowerItem.SelectedItems(0).SubItems(4).Text), CInt(txtEstimatedDaysReturn.Text), CInt(txtdaysExtension.Text))

                btnSearch.PerformClick()
                listfocus(lvlBorrowerItem, br_tr_id)


            End If


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE:" & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Private Sub load_multiple_charges_edit(ByVal multiplecharges As String)
        Dim load_multiple_charges_edit As String = ""
        lvlMultipleCustodian.Items.Clear()

        If multiplecharges = "" Or multiplecharges = Nothing Then
            Exit Sub
        End If

        Dim charges_array() As String
        Dim splittedcharges() As String
        charges_array = multiplecharges.Split(",")

        Dim charges As New function_charges

        For Each a As String In charges_array.ToArray
            splittedcharges = a.Split(":")
            Dim b(2) As String

            Dim type_of_charges As String = splittedcharges(0)
            Dim custodian_desc As String = charges.charges_desc(type_of_charges, CInt(splittedcharges(1)))

            b(0) = type_of_charges
            b(1) = custodian_desc

            Dim lvl As New ListViewItem(b)
            lvlMultipleCustodian.Items.Add(lvl)

        Next
    End Sub

    Private Sub SplitQuantityToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SplitQuantityToolStripMenuItem.Click

        For Each item As ListViewItem In lvlBorrowerItem.CheckedItems
            If item.SubItems(2).Text <= 1 Then
                MessageBox.Show("Sorry you can't split 1 qty.", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else : FSplitQty.ShowDialog()
            End If
        Next

    End Sub

    Private Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4.Click
        For Each ctr As Control In Me.Controls
            If ctr.Name = "Panel5" Then
                ctr.Visible = False
            Else
                ctr.Enabled = True
            End If
        Next
    End Sub

    Private Sub Button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button5.Click
        Dim a(22) As String


        With lvlBorrowerItem

            If CDbl(.SelectedItems(0).SubItems(2).Text) < CDbl(txtsplitqty.Text) Then
                MessageBox.Show("your desired qty must not greater than the actual qty...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            ElseIf CDbl(txtsplitqty.Text) = 0 Then
                MessageBox.Show("zero is not applicable...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            ElseIf CDbl(txtsplitqty.Text) = CDbl(.SelectedItems(0).SubItems(2).Text) Then
                MessageBox.Show("must not be equal...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End If

            a(0) = .SelectedItems(0).Text
            a(1) = .SelectedItems(0).SubItems(1).Text
            a(2) = CDbl(txtsplitqty.Text)
            a(3) = .SelectedItems(0).SubItems(3).Text
            a(4) = .SelectedItems(0).SubItems(4).Text
            a(5) = .SelectedItems(0).SubItems(5).Text
            a(6) = .SelectedItems(0).SubItems(6).Text
            a(7) = .SelectedItems(0).SubItems(7).Text
            a(8) = .SelectedItems(0).SubItems(8).Text
            a(9) = .SelectedItems(0).SubItems(9).Text
            a(10) = .SelectedItems(0).SubItems(10).Text


            a(11) = .SelectedItems(0).SubItems(11).Text
            a(12) = .SelectedItems(0).SubItems(12).Text
            a(13) = .SelectedItems(0).SubItems(13).Text
            a(14) = .SelectedItems(0).SubItems(14).Text
            a(15) = .SelectedItems(0).SubItems(15).Text
            a(16) = .SelectedItems(0).SubItems(16).Text

            Dim lvl As New ListViewItem(a)
            ' .Items.Insert(.SelectedItems(0).Index + 1, lvl)
            .Items.Add(lvl)
            .SelectedItems(0).SubItems(2).Text = CDbl(.SelectedItems(0).SubItems(2).Text) - CDbl(txtsplitqty.Text)
        End With

        Button4.PerformClick()


    End Sub

    Private Sub btnToggle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnToggle.Click
        If btnToggle.Text = ">" Then
            lvlMultipleCustodian.Visible = True
            btnToggle.Text = "<"
        ElseIf btnToggle.Text = "<" Then
            lvlMultipleCustodian.Visible = False
            btnToggle.Text = ">"
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem1.Click
        For Each row As ListViewItem In lvlMultipleCustodian.Items
            If row.Selected = True Then
                row.Remove()
            End If
        Next
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddTempCustodian.Click
        Dim a(2) As String

        a(0) = cmbChargesType.Text
        a(1) = cmbChargesDesc.Text

        Dim lvl As New ListViewItem(a)
        lvlMultipleCustodian.Items.Add(lvl)

    End Sub

    Private Sub EditInfoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles EditInfoToolStripMenuItem.Click
        lvlBorrowerItem.Enabled = False

        btnSave.Text = "Update"
        edit_borrower_info(CInt(lvlBorrowerItem.SelectedItems(0).SubItems(16).Text))

        For Each ctr As Control In TableLayoutPanel1.Controls
            If ctr.Name = "Panel2" Then
                ctr.Enabled = True
            Else
                ctr.Enabled = False
            End If
        Next

        btnToggle.PerformClick()
        lbox_suggest.Visible = False


        'txtBsNo.Enabled = True
        'txtPurpose.Enabled = True
        'txtWithdrawn.Enabled = True
        'txtReleased.Enabled = True
        'txtNotedBy.Enabled = True
        'txtApproved_by.Enabled = True
        'txtRemarks.Enabled = True
        'lvlBorrowerItem.Enabled = True
        'btnToggle.Enabled = True
        'DtpDate.Enabled = True
        'cmbChargesDesc.Enabled = True
        'cmbChargesType.Enabled = True
        'btnAddTempCustodian.Enabled = True
        'cmbSelectBSorTS.Enabled = True
        'btnSave.Enabled = True

        'If lvlBorrowerItem.SelectedItems(0).SubItems(5).Text = "BS" Then
        '    txtWithdrawn.Enabled = True
        '    txtReleased.Enabled = True
        '    txtNotedBy.Enabled = True
        '    txtApproved_by.Enabled = True
        '    txtEstimatedDaysReturn.Enabled = True
        '    txtdaysExtension.Enabled = True

        'Else
        '    txtWithdrawn.Enabled = False
        '    txtReleased.Enabled = False
        '    txtNotedBy.Enabled = False
        '    txtApproved_by.Enabled = False
        '    txtEstimatedDaysReturn.Enabled = False
        '    txtdaysExtension.Enabled = False

        'End If
    End Sub

    Private Sub edit_borrower_info(ByVal br_tr_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 5)
            newCMD.Parameters.AddWithValue("@br_tr_id", br_tr_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read

                cmbSelectBSorTS.Text = newDR.Item("typeofborrow").ToString
                txtBsNo.Text = newDR.Item("bs_no").ToString
                DtpDate.Text = newDR.Item("date_borrow").ToString
                txtPurpose.Text = newDR.Item("purpose").ToString
                txtWithdrawn.Text = newDR.Item("withdrawn_by").ToString
                load_multiple_charges_edit(newDR.Item("multiple_charges").ToString)
                txtReleased.Text = newDR.Item("released_by").ToString
                txtNotedBy.Text = newDR.Item("noted_by").ToString
                txtApproved_by.Text = newDR.Item("approved_by").ToString
                txtRemarks.Text = newDR.Item("remarks").ToString
                txtEstimatedDaysReturn.Text = FListofBorrowerItem.return_estimated_days(CInt(lvlBorrowerItem.SelectedItems(0).SubItems(4).Text), 1)
                txtdaysExtension.Text = FListofBorrowerItem.return_estimated_days(CInt(lvlBorrowerItem.SelectedItems(0).SubItems(4).Text), 2)

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Private Sub FBorrower_Details_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Escape Then
            clear()

            For Each ctr As Control In TableLayoutPanel1.Controls
                If ctr.Name = "Panel2" Then
                    ctr.Enabled = False
                Else
                    ctr.Enabled = True
                End If
            Next
        End If
    End Sub
    Public Sub clear()

        txtBsNo.Clear()
        txtPurpose.Clear()
        txtWithdrawn.Clear()
        txtReleased.Clear()
        txtNotedBy.Clear()
        txtApproved_by.Clear()
        txtRemarks.Clear()
        lvlBorrowerItem.Enabled = True
        btnToggle.Text = ">"
        lvlMultipleCustodian.Items.Clear()
        lvlMultipleCustodian.Visible = False
        txtEstimatedDaysReturn.Text = 0
        txtdaysExtension.Text = 0

        btnSave.Text = "Save"
        txtBsNo.Focus()
    End Sub
    Private Sub FBorrower_Details_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        lvlMultipleCustodian.Items.Clear()


        'For Each row As ListViewItem In lvlBorrowerItem.Items

        '    Dim estimateddays As String = row.SubItems(17).Text
        '    Dim extendeddays As String = row.SubItems(18).Text

        '    If estimateddays = extendeddays Then
        '        If estimateddays = "" And extendeddays = "" Then
        '        Else
        '            row.BackColor = Color.Red
        '            row.ForeColor = Color.White
        '        End If
        '    End If

        'Next

    End Sub

    Private Sub CreateTurnoverToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CreateTurnoverToolStripMenuItem.Click
        Dim count As Integer

        For Each row As ListViewItem In lvlBorrowerItem.Items
            If row.Checked = True Then
                count += 1

            End If
        Next

        If count = 0 Then
            MessageBox.Show("Select atleast 1 in the list.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim a(20) As String

        For Each row As ListViewItem In lvlBorrowerItem.Items
            If row.Checked = True Then
                a(0) = row.SubItems(4).Text
                a(1) = row.SubItems(1).Text
                a(2) = row.SubItems(2).Text
                a(3) = row.SubItems(3).Text
                a(4) = row.SubItems(19).Text
                a(5) = row.SubItems(20).Text

                If rr_item_sub_id_if_exist(a(0)) > 0 Then
                    MessageBox.Show("Item " & a(1) & " with a BR NO of " & a(3) & " is already on the list..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    Dim lvl As New ListViewItem(a)
                    lvl_Return_items.Items.Add(lvl)
                End If

            End If
        Next

    End Sub
    Public Function rr_item_sub_id_if_exist(ByVal br_tr_det_id As Integer) As Integer

        For Each row As ListViewItem In lvl_Return_items.Items
            If row.Text = br_tr_det_id Then
                rr_item_sub_id_if_exist += 1
            End If
        Next
    End Function

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReturnthisItem.Click
        If lvl_Return_items.Items.Count = 0 Then
            MessageBox.Show("no item found on the list.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If MessageBox.Show("Are you sure you want to return this items ?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            FBorrower_return_items.lvlMultipleCustodian.Items.Clear()

            FBorrower_return_items.ShowDialog()

        End If

    End Sub

    Private Sub Panel2_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub cmbSelectBSorTS_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSelectBSorTS.GotFocus, txtBsNo.GotFocus, DtpDate.GotFocus, txtEstimatedDaysReturn.GotFocus, txtdaysExtension.GotFocus, _
        txtPurpose.GotFocus, cmbChargesType.GotFocus, cmbChargesDesc.GotFocus, txtWithdrawn.GotFocus, txtReleased.GotFocus, txtNotedBy.GotFocus, txtApproved_by.GotFocus, txtRemarks.GotFocus

        If txtWithdrawn.Focused Then
            txtname = txtWithdrawn.Name
            txtWithdrawn.SelectAll()

        ElseIf txtReleased.Focused Then
            txtname = txtReleased.Name
            txtReleased.SelectAll()

        ElseIf txtNotedBy.Focused Then
            txtname = txtNotedBy.Name
            txtNotedBy.SelectAll()

        ElseIf txtApproved_by.Focused Then
            txtname = txtApproved_by.Name
            txtApproved_by.SelectAll()

        ElseIf txtRemarks.Focused Then
            txtname = txtRemarks.Name
            txtWithdrawn.SelectAll()

        End If

        lbox_suggest.Visible = False
    End Sub

    Private Sub cmbSelectBSorTS_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSelectBSorTS.SelectedIndexChanged
        If cmbSelectBSorTS.Text = "BS" Then
            txtBsNo.Text = 0
            txtBsNo.Enabled = True
            txtPurpose.Enabled = True
            txtWithdrawn.Enabled = True
            txtReleased.Enabled = True
            txtNotedBy.Enabled = True
            txtApproved_by.Enabled = True
            txtRemarks.Enabled = True
            lvlBorrowerItem.Enabled = True
            btnToggle.Enabled = True
            DtpDate.Enabled = True
            cmbChargesDesc.Enabled = True
            cmbChargesType.Enabled = True
            btnAddTempCustodian.Enabled = True
            cmbSelectBSorTS.Enabled = True
            btnSave.Enabled = True
            txtEstimatedDaysReturn.Enabled = True
            txtdaysExtension.Enabled = True


            txtWithdrawn.Text = ""
            txtReleased.Text = "Christopher Q. Balbin"
            txtNotedBy.Text = "Vanessa F. Piedad"
            txtApproved_by.Text = "Mercy Fe G. Cupay"


        ElseIf cmbSelectBSorTS.Text = "TR" Then
            txtBsNo.Text = "N/A"
            txtBsNo.Enabled = False
            txtPurpose.Enabled = False
            txtWithdrawn.Enabled = False
            txtReleased.Enabled = False
            txtNotedBy.Enabled = False
            txtApproved_by.Enabled = False
            txtRemarks.Enabled = True
            lvlBorrowerItem.Enabled = True
            btnToggle.Enabled = True
            DtpDate.Enabled = True
            cmbChargesDesc.Enabled = True
            cmbChargesType.Enabled = True
            btnAddTempCustodian.Enabled = True
            cmbSelectBSorTS.Enabled = True
            btnSave.Enabled = True
            txtEstimatedDaysReturn.Enabled = False
            txtEstimatedDaysReturn.Enabled = False
            txtdaysExtension.Enabled = False

            txtWithdrawn.Text = ""
            txtReleased.Text = "N/A"
            txtNotedBy.Text = "N/A"
            txtApproved_by.Text = "N/A"

        End If
    End Sub

    Public Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        If rs_id <> 0 Then
            search_borrowed_items(rs_id, 0)
        Else
            search_borrowed_items(rs_id, 1)
        End If
    End Sub
    Public Sub search_borrowed_items(ByVal id As Integer, ByVal n As Integer)

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim c As Integer

        Dim charges As New function_charges
        lvlBorrowerItem.Items.Clear()

        Dim a(30) As String
        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            If n = 0 Then
                newCMD.Parameters.AddWithValue("@n", 4)
                newCMD.Parameters.AddWithValue("@br_tr_det_id", id)
            ElseIf n = 1 Then
                newCMD.Parameters.AddWithValue("@n", 25)
            End If

            newDR = newCMD.ExecuteReader

            While newDR.Read
                If check_if_exist("dbborrower_turnover_details", "br_tr_det_id", CInt(newDR.Item("br_tr_det_id").ToString), 1) > 0 Then
                Else

                    a(0) = newDR.Item("rr_item_sub_id").ToString
                    a(1) = newDR.Item("sub_item_desc").ToString
                    a(2) = newDR.Item("qty").ToString
                    a(3) = newDR.Item("rr_item_id").ToString
                    a(4) = newDR.Item("br_tr_det_id").ToString
                    a(5) = newDR.Item("typeofborrow").ToString
                    a(6) = newDR.Item("bs_no").ToString
                    a(7) = Format(Date.Parse(newDR.Item("date_borrow").ToString), "MM/dd/yyyy")
                    a(8) = newDR.Item("purpose").ToString
                    a(9) = newDR.Item("typeofcharges").ToString
                    a(10) = FListofBorrowerItem.load_multiple_charges(newDR.Item("multiple_charges").ToString)
                    a(11) = newDR.Item("withdrawn_by").ToString
                    a(12) = newDR.Item("released_by").ToString
                    a(13) = newDR.Item("noted_by").ToString
                    a(14) = newDR.Item("approved_by").ToString
                    a(15) = newDR.Item("remarks").ToString
                    a(16) = newDR.Item("br_tr_id").ToString
                    a(17) = calc_month_and_days(Date.Parse(a(7)), Now)
                    a(19) = "Functional"
                    a(20) = newDR.Item("rs_id").ToString

                    Dim estimateddays As Integer = FListofBorrowerItem.return_estimated_days(CInt(newDR.Item("br_tr_det_id").ToString), 1)
                    Dim extendeddays As Integer = FListofBorrowerItem.return_estimated_days(CInt(newDR.Item("br_tr_det_id").ToString), 2)

                    a(18) = calc_month_and_days(Date.Parse(a(7)), Date.Parse(a(7)).AddDays(estimateddays + extendeddays))

                    If n = 0 Then
                        If CInt(a(2)) - FListofBorrowerItem.return_turnover_item_qty(CInt(a(4))) = 0 Then
                            GoTo proceedhere
                        Else
                            a(2) = CInt(a(2)) - FListofBorrowerItem.return_turnover_item_qty(CInt(a(4)))
                        End If
                    ElseIf n = 1 Then
                    End If

                    If cmbSearchBy.Text = "CUSTODIAN" Then
                        If search_by1(a(10), txtSearch.Text) = True Then
                        Else
                            GoTo proceedhere
                        End If
                    ElseIf cmbSearchBy.Text = "DESCRIPTION" Then
                        If search_by1(a(1), txtSearch.Text) = True Then
                        Else
                            GoTo proceedhere
                        End If
                    ElseIf cmbSearchBy.Text = "TYPE OF BORROW" Then
                        If search_by1(a(5), txtSearch.Text) = True Then
                        Else
                            GoTo proceedhere
                        End If
                    ElseIf cmbSearchBy.Text = "BS NO" Then
                        If search_by1(a(6), txtSearch.Text) = True Then
                        Else
                            GoTo proceedhere
                        End If
                    End If

                    Dim lvl As New ListViewItem(a)
                    lvlBorrowerItem.Items.Add(lvl)

                    Dim timespan1 As TimeSpan = Now - Date.Parse(a(7))
                    Dim timespan2 As TimeSpan = Date.Parse(a(7)).AddDays(estimateddays + extendeddays) - Date.Parse(a(7))

                    If timespan1.TotalDays >= timespan2.TotalDays Then
                        If a(5) = "BS" Then
                            lvlBorrowerItem.Items(c).BackColor = Color.Red
                            lvlBorrowerItem.Items(c).ForeColor = Color.White
                        Else

                        End If

                    End If

                    c += 1

proceedhere:

                End If

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub


    'Public Sub get_br_tr_det_id(ByVal id As Integer)
    '    Dim mysqLcon As New SQLcon

    '    Try
    '        mysqLcon.connection.Open()
    '        publicquery = "SELECT br_tr_det_id FROM dbborrower_details WHERE rs_id = " & id
    '        Dim mycmd As SqlCommand = New SqlCommand(publicquery, mysqLcon.connection)
    '        Dim mydreader As SqlDataReader = mycmd.ExecuteReader
    '        While mydreader.Read
    '            If check_if_exist("dbborrower_turnover_details", "br_tr_det_id", CInt(mydreader.Item("br_tr_det_id").ToString), 1) > 0 Then
    '            Else
    '                'MessageBox.Show(mydreader.Item("br_tr_det_id").ToString)

    '            End If
    '        End While
    '        mydreader.Close()
    '    Catch ex As Exception
    '        MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        mysqLcon.connection.Close()
    '    End Try
    'End Sub

    Private Sub CMS_lvlBorrowerItem_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMS_lvlBorrowerItem.Opening

        If lvlBorrowerItem.SelectedItems.Count > 0 Then
            CMS_lvlBorrowerItem.Enabled = True
        Else
            CMS_lvlBorrowerItem.Enabled = False
        End If

    End Sub

    Private Sub TableLayoutPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub txtWithdrawn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWithdrawn.KeyDown, txtReleased.KeyDown, txtNotedBy.KeyDown,
            txtApproved_by.KeyDown, txtRemarks.KeyDown

        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then

            If lbox_suggest.Visible = True Then
                If lbox_suggest.Items.Count > 0 Then
                    lbox_suggest.Focus()
                    lbox_suggest.SelectedIndex = 0

                End If

            End If
        End If
    End Sub

    Private Sub txtWithdrawn_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWithdrawn.TextChanged
        Try
            If txtWithdrawn.Text = "" Then
                lbox_suggest.Visible = False
            Else
                With lbox_suggest
                    .Parent = Panel2
                    .BringToFront()
                    .Location = New System.Drawing.Point(txtWithdrawn.Bounds.Left, txtWithdrawn.Bounds.Bottom)
                    .Visible = True
                    .Items.Clear()
                    .Width = txtWithdrawn.Width
                End With

                get_withdrawnby(txtWithdrawn.Text)
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub get_withdrawnby(ByVal notedby As String)
        Dim SQLcon As New SQLcon
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim cnt As Integer = 0

        Try
            SQLcon.connection.Open()
            publicquery = "SELECT DISTINCT withdrawn_by FROM dbborrower_info WHERE withdrawn_by LIKE '%" & notedby & "%'"
            Command = New SqlCommand(publicquery, SQLcon.connection)
            Reader = Command.ExecuteReader
            While Reader.Read
                lbox_suggest.Items.Add(Reader.Item("withdrawn_by").ToString)
                cnt += 1
            End While

            If cnt > 0 Then
                lbox_suggest.Visible = True
            Else
                lbox_suggest.Visible = False
            End If

            Reader.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub

    Private Sub lbox_suggest_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbox_suggest.DoubleClick
        If lbox_suggest.SelectedItems.Count > 0 Then
            For Each ctr As Control In Panel2.Controls
                If ctr.Name = txtname Then
                    ctr.Text = lbox_suggest.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next

            lbox_suggest.Visible = False
        End If
    End Sub

    Private Sub lbox_suggest_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lbox_suggest.KeyDown

        If e.KeyCode = Keys.Enter Then
            For Each ctr As Control In Panel2.Controls
                If ctr.Name = txtname Then
                    ctr.Text = lbox_suggest.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next
            lbox_suggest.Visible = False
        End If

    End Sub

    Private Sub DefectiveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DefectiveToolStripMenuItem.Click
        For Each row As ListViewItem In lvlBorrowerItem.Items
            If row.Selected = True Then
                row.SubItems(19).Text = "Defective"
            End If

        Next
    End Sub

    Private Sub FunctionalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FunctionalToolStripMenuItem.Click
        For Each row As ListViewItem In lvlBorrowerItem.Items
            If row.Selected = True Then
                row.SubItems(19).Text = "Functional"
            End If

        Next
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub cmbSearchBy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSearchBy.SelectedIndexChanged
        txtSearch.Focus()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        select_unselect_listview(lvlBorrowerItem, 1)
    End Sub

    Private Sub UnselectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnselectAllToolStripMenuItem.Click
        select_unselect_listview(lvlBorrowerItem, 2)
    End Sub

    Private Sub txtReleased_TextChanged(sender As Object, e As EventArgs) Handles txtReleased.TextChanged

        Try
            If txtReleased.Text = "" Then
                lbox_suggest.Visible = False
            Else
                With lbox_suggest
                    .Parent = Panel2
                    .BringToFront()
                    .Location = New System.Drawing.Point(txtReleased.Bounds.Left, txtReleased.Bounds.Bottom)
                    .Visible = True
                    .Items.Clear()
                    .Width = txtWithdrawn.Width
                End With

                Dim query As String = "SELECT DISTINCT released_by FROM dbborrower_info WHERE released_by LIKE '%" & txtReleased.Text & "%'"
                SELECT_QUERY3(query, lbox_suggest)
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub lbox_suggest_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbox_suggest.SelectedIndexChanged

    End Sub

    Private Sub lbox_suggest_MouseEnter(sender As Object, e As EventArgs) Handles lbox_suggest.MouseEnter

    End Sub

    Private Sub txtNotedBy_TextChanged(sender As Object, e As EventArgs) Handles txtNotedBy.TextChanged
        Try
            If txtNotedBy.Text = "" Then
                lbox_suggest.Visible = False
            Else
                With lbox_suggest
                    .Parent = Panel2
                    .BringToFront()
                    .Location = New System.Drawing.Point(txtNotedBy.Bounds.Left, txtNotedBy.Bounds.Bottom)
                    .Visible = True
                    .Items.Clear()
                    .Width = txtWithdrawn.Width
                End With

                Dim query As String = "SELECT DISTINCT noted_by FROM dbborrower_info WHERE noted_by LIKE '%" & txtNotedBy.Text & "%'"
                SELECT_QUERY3(query, lbox_suggest)
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtApproved_by_TextChanged(sender As Object, e As EventArgs) Handles txtApproved_by.TextChanged
        Try
            If txtApproved_by.Text = "" Then
                lbox_suggest.Visible = False
            Else
                With lbox_suggest
                    .Parent = Panel2
                    .BringToFront()
                    .Location = New System.Drawing.Point(txtApproved_by.Bounds.Left, txtApproved_by.Bounds.Bottom)
                    .Visible = True
                    .Items.Clear()
                    .Width = txtWithdrawn.Width
                End With

                Dim query As String = "SELECT DISTINCT approved_by FROM dbborrower_info WHERE approved_by LIKE '%" & txtApproved_by.Text & "%'"
                SELECT_QUERY3(query, lbox_suggest)
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtRemarks_TextChanged(sender As Object, e As EventArgs) Handles txtRemarks.TextChanged
        Try
            If txtRemarks.Text = "" Then
                lbox_suggest.Visible = False
            Else
                With lbox_suggest
                    .Parent = Panel2
                    .BringToFront()
                    .Location = New System.Drawing.Point(txtRemarks.Bounds.Left, txtRemarks.Bounds.Bottom)
                    .Visible = True
                    .Items.Clear()
                    .Width = txtWithdrawn.Width
                End With

                Dim query As String = "SELECT DISTINCT remarks FROM dbborrower_info WHERE remarks LIKE '%" & txtRemarks.Text & "%'"
                SELECT_QUERY3(query, lbox_suggest)
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class