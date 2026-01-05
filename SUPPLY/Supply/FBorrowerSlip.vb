Imports System.Data.Sql
Imports System.Data.SqlClient


Public Class FBorrowerSlip
    Public SQ As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Dim name2 As String

    Private Sub cmbTypeofCharge_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTypeofCharge.SelectedIndexChanged
        If cmbTypeofCharge.Text = "SHOPS" Then
            cmbChargeTo.Visible = True
            txtChargeTo.Visible = False


            load_equipment(2)
        ElseIf cmbTypeofCharge.Text = "PROJECT" Then
            cmbChargeTo.Visible = True
            txtChargeTo.Visible = False


            load_equipment(1)

        ElseIf cmbTypeofCharge.Text = "EQUIPMENT" Then
            cmbChargeTo.Visible = True
            txtChargeTo.Visible = False


            load_equipment(0)

        Else
            cmbChargeTo.Visible = False
            txtChargeTo.Visible = True

        End If
    End Sub

    Public Sub load_equipment(ByVal n As Integer)
        cmbChargeTo.Items.Clear()

        Dim sqlcon As New SQLcon

        'sqlcon.set_sql("192.168.1.92", "eus_031916", "sa", "adfil")
        'sqlcon.sql_connect()

        cmbChargeTo.Width = txtApprovedBy.Width
        cmbChargeTo.Location = New Point(txtChargeTo.Bounds.Left, txtChargeTo.Bounds.Top)
        txtChargeTo.Visible = False
        cmbChargeTo.BringToFront()

        Try
            sqlcon.connection1.Open()

            If n = 0 Then
                publicquery = "SELECT * FROM dbequipment_list ORDER BY plate_no ASC"
            ElseIf n = 1 Then
                publicquery = "SELECT * FROM dbprojectdesc ORDER BY project_desc ASC"
            ElseIf n = 2 Then
                publicquery = "SELECT * FROM dbprojectdesc WHERE project_desc LIKE '%" & "SHOP" & "%' ORDER BY project_desc ASC"
            End If

            cmd = New SqlCommand(publicquery, sqlcon.connection1)
            dr = cmd.ExecuteReader

            While dr.Read

                If n = 0 Then
                    cmbChargeTo.Items.Add(dr.Item("plate_no").ToString)
                ElseIf n = 1 Or n = 2 Then
                    cmbChargeTo.Items.Add(dr.Item("project_desc").ToString)
                End If

            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection1.Close()
        End Try
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        If cmbTypeofCharge.Text = "ADFIL" Then
            charge_to_selection = 2
        ElseIf cmbTypeofCharge.Text = "WAREHOUSE" Then
            charge_to_selection = 1
            charge_to_destination = 3
        End If

        FCharge_To.ShowDialog()

    End Sub

    Private Sub cmbChargeTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbChargeTo.SelectedIndexChanged
      
        Select Case cmbTypeofCharge.Text
            Case "SHOPS"
                others_charge_to_id("SHOPS")
            Case "PROJECT"
                others_charge_to_id("PROJECT")
            Case "EQUIPMENT"
                others_charge_to_id("EQUIPMENT")
        End Select

    End Sub

    Public Function others_charge_to_id(ByVal type As String)
        Dim sqlcon As New SQLcon
        Try
            'sqlcon.set_sql("192.168.1.92", "eus_031916", "sa", "adfil")
            'sqlcon.sql_connect()

            sqlcon.connection1.Open()
            Select Case type
                Case "SHOPS"
                    publicquery = "SELECT proj_id FROM dbprojectdesc WHERE project_desc = '" & cmbChargeTo.Text & "'"
                Case "PROJECT"
                    publicquery = "SELECT proj_id FROM dbprojectdesc WHERE project_desc = '" & cmbChargeTo.Text & "'"
                Case "EQUIPMENT"
                    publicquery = "SELECT equipListID FROM dbequipment_list WHERE plate_no = '" & cmbChargeTo.Text & "'"
            End Select


            cmd = New SqlCommand(publicquery, sqlcon.connection1)
            dr = cmd.ExecuteReader

            While dr.Read
                charge_to_id = dr.Item(0).ToString
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection1.Close()
        End Try
    End Function

    Private Sub btnFac_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFac_Save.Click
        If btnFac_Save.Text = "Save" Then
            Save_update(0)
        ElseIf btnFac_Save.Text = "Update" Then
            Save_update(1)
        End If

    End Sub
    Public Sub Save_update(ByVal nn As Integer)

        Try
            SQ.connection.Open()
            'publicquery = "INSERT INTO dbBorrower_Slip(date_borrow,type_of_charge,borrowed_for,purpose,borrowed_by,date_return,noted_by,approved_by,bs_no) VALUES('"
            'publicquery &= Date.Parse(dtpDateBorrow.Text) & "','"
            'publicquery &= cmbTypeofCharge.Text & "',"
            'publicquery &= charge_to_id & ",'"
            'publicquery &= txtPurpose.Text & "','"
            'publicquery &= txtBorrowedby.Text & "','"

            'If cmbTypeofreturn.Text = "By Date" Then
            '    publicquery &= Date.Parse(dtpDateReturn.Text) & "','"
            'Else
            '    publicquery &= Nothing & "','"
            'End If

            'publicquery &= txtNotedBy.Text & "','"
            'publicquery &= txtApprovedBy.Text & "','"
            'publicquery &= txtBs_no.Text & "');"
            'publicquery &= "SELECT SCOPE_IDENTITY()"

            'Dim n As Integer = UPDATE_INSERT_DELETE_QUERY(publicquery, 1, "INSERT")

            cmd = New SqlCommand("proc_borrower_crud", SQ.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@dateborrow", Date.Parse(dtpDateBorrow.Text))
            cmd.Parameters.AddWithValue("@type_of_charge", cmbTypeofCharge.Text)
            cmd.Parameters.AddWithValue("@borrowed_for", charge_to_id)
            cmd.Parameters.AddWithValue("@purpose", txtPurpose.Text)
            cmd.Parameters.AddWithValue("@borrowed_by", txtBorrowedby.Text)

            If cmbTypeofreturn.Text = "By Date" Then
                cmd.Parameters.AddWithValue("@datereturned", Date.Parse(dtpDateReturn.Text))
            Else
                cmd.Parameters.AddWithValue("@datereturned", Nothing)
            End If

            cmd.Parameters.AddWithValue("@noted_by", txtNotedBy.Text)
            cmd.Parameters.AddWithValue("@approved_by", txtApprovedBy.Text)
            cmd.Parameters.AddWithValue("@bs_no", txtBs_no.Text)

            Dim n As Integer

            Select Case btnFac_Save.Text
                Case "Save"
                    cmd.Parameters.AddWithValue("@type_of_query", "INSERT")
                    cmd.Parameters.AddWithValue("@n", 5)
                    n = cmd.ExecuteScalar

                    If n > 0 Then
                        MessageBox.Show("Successfully Saved...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    With lvlFacTools
                        For i = 0 To .Items.Count - 1
                            borrower_slip_details(n, .Items(i).Text, .Items(i).SubItems(1).Text, .Items(i).SubItems(3).Text, txtBs_no.Text)

                            If check_if_exist("borrow_status", "rr_item_id", Val(.Items(i).Text), 0) > 0 Then
                                'update
                                Dim query As String = "UPDATE borrow_status SET status = '" & "borrowed" & "' WHERE rr_item_id = " & Val(.Items(i).Text)
                                UPDATE_INSERT_DELETE_QUERY(query, 0, "UPDATE")
                            Else
                                'insert 
                                Dim query As String = "INSERT INTO borrow_status(rr_item_id,status) VALUES(" & Val(.Items(i).Text) & ",'" & "borrowed" & "')"
                                UPDATE_INSERT_DELETE_QUERY(query, 0, "INSERT")

                            End If
                        Next
                    End With

                    Me.Close()

                    With FFacilities_Tools
                        .load_fac_tools_to_list(0)

                    End With


                Case "Update"

                    cmd.Parameters.AddWithValue("@type_of_query", "UPDATE")
                    cmd.Parameters.AddWithValue("@n", 1)
                    Dim bs_id As Integer = FBorrowedDetails.lvList.SelectedItems(0).Text

                    cmd.Parameters.AddWithValue("@brs_details_id", bs_id)
                    n = cmd.ExecuteNonQuery

                    MessageBox.Show("Successfully Updated...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    With FBorrowedDetails
                        .load_borrowed(0, .txtSearch.Text)
                        listfocus(.lvList, bs_id)
                    End With

                    Me.Dispose()

            End Select


          
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    
    Public Sub borrower_slip_details(ByVal borrower_slip_id As Integer, ByVal rr_item_id As Integer, ByVal qty As Integer, ByVal fac_tools_id As Integer, ByVal bs_no As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        newSQ.connection.Open()

        Try
            publicquery = "INSERT INTO dbBorrower_slip_details(borrower_slip_id,rr_item_id,qty,fac_tools_id,bs_no) VALUES(" & _
            borrower_slip_id & "," & rr_item_id & "," & qty & "," & fac_tools_id & "," & bs_no & ")"

            UPDATE_INSERT_DELETE_QUERY(publicquery, 1, "INSERT")


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub cmbTypeofreturn_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTypeofreturn.SelectedIndexChanged
        If cmbTypeofreturn.Text = "By Date" Then : dtpDateReturn.Enabled = True
        ElseIf cmbTypeofreturn.Text = "By Project" Then : dtpDateReturn.Enabled = False : End If
    End Sub

    Public Function get_dataBorrowerSlip(ByVal n As Integer) As String
        lbox_getdata.Items.Clear()
        Dim checker As Integer
        Try
            SQ.connection.Open()
            Dim newDR As SqlDataReader
            Dim cmd As New SqlCommand("proc_borrower_crud", SQ.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            If n = 0 Then
                cmd.Parameters.AddWithValue("@borrowed_by", txtBorrowedby.Text)
                cmd.Parameters.AddWithValue("@n", 2)
            ElseIf n = 1 Then
                cmd.Parameters.AddWithValue("@noted_by", txtNotedBy.Text)
                cmd.Parameters.AddWithValue("@n", 3)
            ElseIf n = 2 Then
                cmd.Parameters.AddWithValue("@approved_by", txtApprovedBy.Text)
                cmd.Parameters.AddWithValue("@n", 4)
            End If
            newDR = cmd.ExecuteReader
            If newDR.HasRows = False Then
                lbox_getdata.Visible = False
            Else
                While newDR.Read
                    If n = 0 Then
                        Dim get_borrowedBy As String = newDR.Item("borrowed_by").ToString
                        lbox_getdata.Items.Add(get_borrowedBy)

                        checker += 1
                    ElseIf n = 1 Then
                        Dim get_notedby As String = newDR.Item("noted_by").ToString
                        lbox_getdata.Items.Add(get_notedby)

                        checker += 1
                    ElseIf n = 2 Then
                        Dim get_approvedby As String = newDR.Item("approved_by").ToString
                        lbox_getdata.Items.Add(get_approvedby)

                        checker += 1
                    End If

                End While
                newDR.Close()

                If checker = 0 Then
                    lbox_getdata.Visible = False
                Else
                    lbox_getdata.Visible = True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Function

    Private Sub pboxHeader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pboxHeader.Click

    End Sub

    Private Sub FBorrowerSlip_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtBorrowedby_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBorrowedby.GotFocus
        name2 = txtBorrowedby.Name
        txtBorrowedby.SelectAll()
    End Sub

    Private Sub txtBorrowedby_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBorrowedby.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
            If lbox_getdata.Visible = True Then
                If lbox_getdata.Items.Count > 0 Then
                    lbox_getdata.Focus()
                    lbox_getdata.SelectedIndex = 0
                End If
            Else
                'If lbox_withdrawby.Items.Count > 0 Then
                '    lbox_withdrawby.Focus()
                '    lbox_withdrawby.Items(0).Selected = True
                'End If
            End If
        End If
    End Sub

    Private Sub txtBorrowedby_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBorrowedby.TextChanged
        lbox_getdata.Location = New Point(txtBorrowedby.Location.X, txtBorrowedby.Location.Y + txtBorrowedby.Height)
        lbox_getdata.Width = txtBorrowedby.Width
        get_dataBorrowerSlip(0)
    End Sub

    Private Sub lbox_getdata_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbox_getdata.DoubleClick
        If lbox_getdata.SelectedItems.Count > 0 Then
            For Each ctr As Control In Me.Controls
                If ctr.Name = name2 Then
                    ctr.Text = lbox_getdata.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next
            lbox_getdata.Visible = False
        Else
            MessageBox.Show("Pls select data", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub lbox_getdata_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lbox_getdata.KeyDown
        If e.KeyCode = Keys.Enter Then
            For Each ctr As Control In Me.Controls
                If ctr.Name = name2 Then
                    ctr.Text = lbox_getdata.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next
            lbox_getdata.Visible = False
        End If
    End Sub

    Private Sub lbox_getdata_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbox_getdata.SelectedIndexChanged

    End Sub

    Private Sub txtNotedBy_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNotedBy.GotFocus
        name2 = txtNotedBy.Name
        txtNotedBy.SelectAll()
    End Sub

    Private Sub txtNotedBy_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNotedBy.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
            If lbox_getdata.Visible = True Then
                If lbox_getdata.Items.Count > 0 Then
                    lbox_getdata.Focus()
                    lbox_getdata.SelectedIndex = 0
                End If
            Else
                'If lbox_withdrawby.Items.Count > 0 Then
                '    lbox_withdrawby.Focus()
                '    lbox_withdrawby.Items(0).Selected = True
                'End If
            End If
        End If
    End Sub

    Private Sub txtNotedBy_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNotedBy.TextChanged

        lbox_getdata.Location = New Point(txtNotedBy.Location.X, txtNotedBy.Location.Y + txtNotedBy.Height)
        lbox_getdata.Location = New Point(txtNotedBy.Location.X, txtNotedBy.Location.Y + txtNotedBy.Height)
        lbox_getdata.Width = txtNotedBy.Width
        lbox_getdata.Visible = True
        get_dataBorrowerSlip(1)
    End Sub

    Private Sub txtApprovedBy_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtApprovedBy.GotFocus
        name2 = txtApprovedBy.Name
        txtApprovedBy.SelectAll()
    End Sub

    Private Sub txtApprovedBy_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtApprovedBy.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
            If lbox_getdata.Visible = True Then
                If lbox_getdata.Items.Count > 0 Then
                    lbox_getdata.Focus()
                    lbox_getdata.SelectedIndex = 0
                End If
            Else
                'If lbox_withdrawby.Items.Count > 0 Then
                '    lbox_withdrawby.Focus()
                '    lbox_withdrawby.Items(0).Selected = True
                'End If
            End If
        End If
    End Sub

    Private Sub txtApprovedBy_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtApprovedBy.TextChanged
        lbox_getdata.Location = New Point(txtApprovedBy.Location.X, txtApprovedBy.Location.Y + txtApprovedBy.Height)
        lbox_getdata.Width = txtApprovedBy.Width
        lbox_getdata.Visible = True
        get_dataBorrowerSlip(2)
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBs_no.KeyDown

        If Not (e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 48 Or e.KeyValue = 49 Or e.KeyValue = 50 Or e.KeyValue = 51 Or e.KeyValue = 52 Or e.KeyValue = 53 Or e.KeyValue = 54 Or _
           e.KeyValue = 55 Or e.KeyValue = 56 Or e.KeyValue = 57 Or e.KeyValue = 96 Or e.KeyValue = 97 Or e.KeyValue = 98 Or e.KeyValue = 99 Or _
           e.KeyCode = Keys.OemPeriod Or _
          e.KeyValue = 100 Or e.KeyValue = 101 Or e.KeyValue = 102 Or e.KeyValue = 103 Or e.KeyValue = 104 Or e.KeyValue = 105 Or e.KeyValue = 37 Or e.KeyValue = 39) Then

            e.SuppressKeyPress() = True
        End If

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim bs_id As Integer = FBorrowedDetails.lvList.SelectedItems(0).Text

        With FBorrowedDetails
            .load_borrowed(0, .txtSearch.Text)
            listfocus(.lvList, 7)
        End With


    End Sub
End Class