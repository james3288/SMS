Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FBorrowedDetails
    Public sq As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader

    Private Sub FBorrowedDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        load_borrowed(0, txtSearch.Text)
    End Sub

    Public Sub load_borrowed(ByVal n As Integer, ByVal search As String)
        lvList.Items.Clear()
        Dim inc As Integer

        Dim a(14) As String
        Try
            sq.connection.Open()
            cmd = New SqlCommand("proc_borrower_viewing", sq.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@searchby", search)
            cmd.Parameters.AddWithValue("@n", n)

            dr = cmd.ExecuteReader
            While dr.Read

                a(0) = dr.Item("brs_details_id").ToString
                a(1) = dr.Item("fac_tools_desc").ToString
                a(2) = dr.Item("specification").ToString
                a(3) = dr.Item("item_description").ToString
                a(4) = dr.Item("qty").ToString
                a(5) = charge_to(dr.Item("brs_details_id").ToString)
                a(6) = dr.Item("borrowed_by").ToString
                a(7) = Format(Date.Parse(dr.Item("date_borrow").ToString), "MM/dd/yyyy")

                If Format(Date.Parse(dr.Item("date_return").ToString), "yyyy-MM-dd") = "1990-01-01" Then
                    a(8) = "RETURN BY PROJECT BASE"
                Else
                    a(8) = Format(Date.Parse(dr.Item("date_return").ToString), "MM/dd/yyyy")
                End If

                If a(8) = "RETURN BY PROJECT BASE" Then
                    a(9) = ""
                Else
                    a(9) = check_dbBorrower_slip_returned_if_return(dr.Item("brs_details_id").ToString)
                End If

                a(10) = IIf(check_dbBorrower_slip_returned_if_return(dr.Item("brs_details_id").ToString) = "", "Waiting...", "RETURNED")

                If a(10) = "RETURNED" Then
                    If a(8) = "RETURN BY PROJECT BASE" Then
                        a(11) = downtimedays(Date.Parse(a(7)), Now) + 1
                    Else
                        a(11) = downtimedays(Date.Parse(a(7)), Date.Parse(a(8))) + 1
                    End If

                Else
                    a(11) = downtimedays(Date.Parse(a(7)), Now) + 1
                End If


                a(12) = dr.Item("rr_item_id").ToString
                a(13) = dr.Item("bs_no").ToString
                a(14) = dr.Item("borrower_slip_id").ToString

                Dim lvl As New ListViewItem(a)
                lvList.Items.Add(lvl)

                If a(8) = "RETURN BY PROJECT BASE" Then

                Else
                    If downtimedays(Date.Parse(a(7)), Date.Parse(a(8))) <= downtimedays(Date.Parse(a(7)), Now) + 1 Then
                        lvList.Items(inc).BackColor = Color.Red
                    End If
                End If

                inc += 1

            End While

            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sq.connection.Close()
        End Try
    End Sub

    Public Function downtimedays(ByVal d1 As DateTime, ByVal d2 As DateTime) As String
        Dim ffrom As DateTime
        Dim fromto As DateTime

        ffrom = Date.Parse(d1)
        fromto = Date.Parse(d2)

        Dim travelTime As TimeSpan = fromto - ffrom

        downtimedays = Math.Round(CDbl(travelTime.TotalDays.ToString), 1)
        downtimedays = sp(downtimedays, ".", 0)


    End Function

    Public Function charge_to(ByVal brs_details_id As Integer) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_crud", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@brs_details_id", brs_details_id)
            newCMD.Parameters.AddWithValue("@n", 1)

            newDR = newCMD.ExecuteReader
            While newDR.Read
                charge_to = FRequistionForm.CHARGE_TO(newDR.Item("borrowed_for").ToString, "OTHERS", newDR.Item("type_of_charge").ToString)
            End While
            newDR.Close()
            'CHARGE_TO(newdr.Item("charge_to").ToString, newdr.Item("typeRequest").ToString, newdr.Item("process").ToString)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Public Function check_dbBorrower_slip_returned_if_return(ByVal brs_details_id As Integer) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_crud", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@brs_details_id", brs_details_id)
            newDR = newCMD.ExecuteReader
            While newDR.Read
                check_dbBorrower_slip_returned_if_return = Format(Date.Parse(newDR.Item("date_return").ToString), "MM/dd/yyyy")
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function

    Private Sub ItemReturnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemReturnToolStripMenuItem.Click
        panel_hide_show(1)
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        panel_hide_show(0)
    End Sub
    Public Sub panel_hide_show(ByVal n As Integer)
        If n = 1 Then
            pnlReturnBox.Visible = True
        ElseIf n = 0 Then
            pnlReturnBox.Visible = False
        End If

        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is Panel Then
                If n = 1 Then
                    ctr.Enabled = True
                ElseIf n = 0 Then
                    ctr.Enabled = False
                End If

            Else
                If n = 1 Then
                    ctr.Enabled = False
                ElseIf n = 0 Then
                    ctr.Enabled = True
                End If

            End If
        Next
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'dbBorrower_slip_returned
        Dim n As Integer
        Try
            sq.connection.Open()
            cmd = New SqlCommand("proc_borrower_crud", sq.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@brs_details_id", lvList.SelectedItems(0).Text)
            cmd.Parameters.AddWithValue("@datereturned", Date.Parse(DTPdateReturn.Text))
            cmd.Parameters.AddWithValue("@return_by", txtReturnby.Text)
            cmd.Parameters.AddWithValue("@type_of_query", "INSERT")

            n = cmd.ExecuteScalar()

            MessageBox.Show("Successfully Returned..", "Supply Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)



        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sq.connection.Close()

            If check_if_exist("borrow_status", "rr_item_id", Val(lvList.SelectedItems(0).SubItems(12).Text), 0) > 0 Then
                'update
                Dim query As String = "UPDATE borrow_status SET status = '" & "returned" & "' WHERE rr_item_id = " & Val(lvList.SelectedItems(0).SubItems(12).Text)
                UPDATE_INSERT_DELETE_QUERY(query, 0, "UPDATE")
            Else
                'insert 
                Dim query As String = "INSERT INTO borrow_status(rr_item_id,status) VALUES(" & Val(lvList.SelectedItems(0).SubItems(12).Text) & ",'" & "returned" & "')"
                UPDATE_INSERT_DELETE_QUERY(query, 0, "INSERT")

            End If

            panel_hide_show(0)
            load_borrowed(0, txtSearch.Text)

            listfocus(lvList, n)
        End Try
    End Sub

    Private Sub FBorrowedDetails_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        pboxHeader.Width = Me.Width

        lvList.Width = Me.Width - 30
        lvList.Height = Me.Height - 110

        btnExit2.Parent = pboxHeader
        btnExit2.BringToFront()
        btnExit2.Location = New Point(lvList.Bounds.Right - 10, 5)

        gboxSearch.Location = New Point(lvList.Location.X, lvList.Bounds.Bottom)
    End Sub

    Private Sub btnExit2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit2.Click
        Me.Close()

    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        If cmbSearchByCategory.Text = "Search by Item Details" Then
            load_borrowed(0, txtSearch.Text)
        End If
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Dim inc As Integer

        Dim a(14) As String
        Try
            sq.connection.Open()
            cmd = New SqlCommand("proc_borrower_viewing", sq.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@searchby", "")
            cmd.Parameters.AddWithValue("@n", 2)
            cmd.Parameters.AddWithValue("@brs_details_id", CInt(lvList.SelectedItems(0).Text))

            dr = cmd.ExecuteReader
            While dr.Read
                With FBorrowerSlip
                    .cmbTypeofCharge.Text = dr.Item("type_of_charge").ToString

                    Select Case .cmbTypeofCharge.Text
                        Case "ADFIL"
                            .txtChargeTo.Text = GET_equip_desc_AND_proj_desc(Val(dr.Item("borrowed_for").ToString), 3)
                            wh_id = dr.Item("borrowed_for").ToString
                        Case "SHOPS"
                            .cmbChargeTo.Text = GET_equip_desc_AND_proj_desc(Val(dr.Item("borrowed_for").ToString), 2)
                        Case "PROJECT"
                            .cmbChargeTo.Text = GET_equip_desc_AND_proj_desc(Val(dr.Item("borrowed_for").ToString), 2)

                        Case "EQUIPMENT"
                            .cmbChargeTo.Text = GET_equip_desc_AND_proj_desc(Val(dr.Item("borrowed_for").ToString), 1)

                        Case "WAREHOUSE"
                            .txtChargeTo.Text = GET_equip_desc_AND_proj_desc(Val(dr.Item("borrowed_for").ToString), 3)
                            wh_id = dr.Item("borrowed_for").ToString
                            
                    End Select

                    .txtBs_no.Text = dr.Item("bs_no").ToString
                    .dtpDateBorrow.Text = Date.Parse(dr.Item("date_borrow").ToString)
                    .txtPurpose.Text = dr.Item("purpose").ToString
                    .txtBorrowedby.Text = dr.Item("borrowed_by").ToString

                    If Date.Parse(dr.Item("date_return").ToString) = Date.Parse("1990-01-01") Then
                        .cmbTypeofreturn.Text = "By Project"
                        .dtpDateReturn.Enabled = False
                    Else
                        .cmbTypeofreturn.Text = "By Date"
                        .dtpDateReturn.Enabled = True
                    End If

                    .cmbTypeofreturn.Text = ""
                    .dtpDateReturn.Text = dr.Item("date_return").ToString
                    .txtNotedBy.Text = dr.Item("noted_by").ToString
                    .txtApprovedBy.Text = dr.Item("approved_by").ToString
                    .lbox_getdata.Visible = False

                    .lvlFacTools.Enabled = False
                End With


                'a(0) = dr.Item("brs_details_id").ToString
                'a(1) = dr.Item("fac_tools_desc").ToString
                'a(2) = dr.Item("specification").ToString
                'a(3) = dr.Item("item_description").ToString
                'a(4) = dr.Item("qty").ToString
                'a(5) = charge_to(dr.Item("brs_details_id").ToString)
                'a(6) = dr.Item("borrowed_by").ToString
                'a(7) = Format(Date.Parse(dr.Item("date_borrow").ToString), "MM/dd/yyyy")


                'a(8) = Format(Date.Parse(dr.Item("date_return").ToString), "MM/dd/yyyy")

                'a(9) = check_dbBorrower_slip_returned_if_return(dr.Item("brs_details_id").ToString)
                'a(10) = IIf(check_dbBorrower_slip_returned_if_return(dr.Item("brs_details_id").ToString) = "", "Waiting...", "RETURNED")
                'a(11) = downtimedays(Date.Parse(a(7)), Now) + 1
                'a(12) = dr.Item("rr_item_id").ToString

                'Dim lvl As New ListViewItem(a)
                'lvList.Items.Add(lvl)

                'If a(8) = "RETURN BY PROJECT BASE" Then

                'Else
                '    If downtimedays(Date.Parse(a(7)), Date.Parse(a(8))) <= downtimedays(Date.Parse(a(7)), Now) + 1 Then
                '        lvList.Items(inc).BackColor = Color.Red
                '    End If
                'End If

                inc += 1

            End While

            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sq.connection.Close()
            borrower_details()

        End Try

        FBorrowerSlip.btnFac_Save.Text = "Update"
        FBorrowerSlip.ShowDialog()

    End Sub

    Public Sub borrower_details()
        FBorrowerSlip.lvlFacTools.Items.Clear()

        Dim a(14) As String

        Try
            sq.connection.Open()
            cmd = New SqlCommand("proc_borrower_crud", sq.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@n", 6)
            cmd.Parameters.AddWithValue("@bs_no", CInt(lvList.SelectedItems(0).SubItems(13).Text))

            dr = cmd.ExecuteReader
            While dr.Read
                With FBorrowerSlip

                    a(0) = dr.Item("borrower_slip_id").ToString
                    a(1) = dr.Item("qty").ToString
                    a(2) = dr.Item("item_description").ToString
                    a(3) = dr.Item("fac_tools_id").ToString

                    Dim list As New ListViewItem(a)
                    .lvlFacTools.Items.Add(list)
                End With

            End While

            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sq.connection.Close()
        End Try

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click

        If count_borrower_slip() > 1 Then
            borrower_slip_remove(1)
            load_borrowed(0, txtSearch.Text)
        Else
            borrower_slip_remove(2)
            load_borrowed(0, txtSearch.Text)
        End If



    End Sub
    Public Function update_borrower_status()
        Try
            sq.connection.Open()
            cmd = New SqlCommand("proc_borrower_crud", sq.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@type_of_query", "UPDATE")
            cmd.Parameters.AddWithValue("@n", 2)
            cmd.Parameters.AddWithValue("@rr_item_id", CInt(lvList.SelectedItems(0).SubItems(12).Text))
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sq.connection.Close()
        End Try
    End Function

    Public Function count_borrower_slip() As Integer
        Try
            sq.connection.Open()
            cmd = New SqlCommand("proc_borrower_crud", sq.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@type_of_query", "SELECT")
            cmd.Parameters.AddWithValue("@n", 7)
            cmd.Parameters.AddWithValue("@borrower_slip_id", CInt(lvList.SelectedItems(0).SubItems(14).Text))

            dr = cmd.ExecuteReader
            While dr.Read
                count_borrower_slip += 1
            End While

            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sq.connection.Close()
        End Try
    End Function

    Public Sub borrower_slip_remove(ByVal n As Integer)
        Dim a(14) As String

        Try
            sq.connection.Open()
            cmd = New SqlCommand("proc_borrower_crud", sq.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@type_of_query", "DELETE")
            cmd.Parameters.AddWithValue("@n", n)
            cmd.Parameters.AddWithValue("@borrower_slip_id", CInt(lvList.SelectedItems(0).SubItems(14).Text))
            cmd.Parameters.AddWithValue("@brs_details_id", CInt(lvList.SelectedItems(0).Text))

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sq.connection.Close()
            update_borrower_status()
        End Try
    End Sub
End Class