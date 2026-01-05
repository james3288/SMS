Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class FFacilities_Tools
    Public SQ As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader

    Public fac_id As Integer

    Private Sub FFacilities_Tools_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_fac_tools()
        load_fac_tools_to_list(0)

    End Sub
    Public Sub load_fac_tools_to_list(ByVal search As Integer)
        lvlFacTools.Items.Clear()
        Try
            SQ.connection.Open()

            If search = 0 Then
                If public_fac_tools = "FACILITIES" Then
                    publicquery = "SELECT a.fac_tools_id,b.fac_desc,a.specification,a.remarks FROM dbfacilities_tools a " & _
                    "INNER JOIN dbfacilities_tools_desc b ON a.fac_id = b.fac_id AND b.fac_type = '" & "Facilities" & "'"

                ElseIf public_fac_tools = "TOOLS" Then
                    publicquery = "SELECT a.fac_tools_id,b.fac_desc,a.specification,a.remarks FROM dbfacilities_tools a " & _
                   "INNER JOIN dbfacilities_tools_desc b ON a.fac_id = b.fac_id AND b.fac_type = '" & "Tools" & "'"

                ElseIf public_fac_tools = "ALL" Then
                    publicquery = "SELECT a.fac_tools_id,b.fac_desc,a.specification,a.remarks FROM dbfacilities_tools a " & _
                     "INNER JOIN dbfacilities_tools_desc b ON a.fac_id = b.fac_id"
                End If
               
            ElseIf search = 1 Then
                If public_fac_tools = "FACILITIES" Then
                    publicquery = "SELECT a.fac_tools_id,b.fac_desc,a.specification,a.remarks FROM dbfacilities_tools a " & _
                    "INNER JOIN dbfacilities_tools_desc b ON a.fac_id = b.fac_id WHERE a.specification LIKE '%" & txtSearch.Text & "%' AND b.fac_type = '" & "Facilities" & "'"

                ElseIf public_fac_tools = "TOOLS" Then
                    publicquery = "SELECT a.fac_tools_id,b.fac_desc,a.specification,a.remarks FROM dbfacilities_tools a " & _
                    "INNER JOIN dbfacilities_tools_desc b ON a.fac_id = b.fac_id WHERE a.specification LIKE '%" & txtSearch.Text & "%' AND b.fac_type = '" & "Tools" & "'"

                ElseIf public_fac_tools = "ALL" Then
                    publicquery = "SELECT a.fac_tools_id,b.fac_desc,a.specification,a.remarks FROM dbfacilities_tools a " & _
                     "INNER JOIN dbfacilities_tools_desc b ON a.fac_id = b.fac_id WHERE a.specification LIKE '%" & txtSearch.Text & "%'"
                End If
             
            End If

            'SELECT_QUERY(publicquery, 3, lvlFacTools, "100-100", 100)

            cmd = New SqlCommand(publicquery, SQ.connection)
            dr = cmd.ExecuteReader
            Dim a(10) As String
            While dr.Read
                a(0) = dr.Item("fac_tools_id").ToString
                a(1) = UCase(dr.Item("fac_desc").ToString)
                a(2) = UCase(dr.Item("specification").ToString)
                a(3) = dr.Item("remarks").ToString
                a(4) = available_fac_tools(dr.Item("fac_tools_id").ToString) - borrowed_fac_tools(dr.Item("fac_tools_id").ToString)
                a(5) = borrowed_fac_tools(dr.Item("fac_tools_id").ToString)
                a(6) = available_fac_tools(dr.Item("fac_tools_id").ToString)
                Dim lvl As New ListViewItem(a)
                lvlFacTools.Items.Add(lvl)

            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()

        End Try
    End Sub
    Public Function borrowed_fac_tools(ByVal fac_tools_id) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT * FROM dbBorrower_slip_details WHERE fac_tools_id = " & fac_tools_id
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader
            While newDR.Read
                If check_dbBorrower_slip_returned_if_return(newDR.Item("brs_details_id").ToString) = "" Then
                    borrowed_fac_tools += newDR.Item("qty").ToString
                Else

                End If
            End While
            newDR.Close()

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
                check_dbBorrower_slip_returned_if_return = newDR.Item("date_return").ToString
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function


    Public Function available_fac_tools(ByVal wh_id As Integer) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try

            newSQ.connection.Open()

            newCMD = New SqlCommand("proc_requisition_slip", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure


            newCMD.Parameters.AddWithValue("@n", 1)
            newCMD.Parameters.AddWithValue("@searchby", "")
            newDR = newCMD.ExecuteReader
            While newDR.Read
                Dim a(20) As String

                a(0) = newDR.Item("rs_id").ToString
                a(1) = newDR.Item("rs_no").ToString
                a(2) = Format(Date.Parse(newDR.Item("date_req").ToString), "MM/dd/yyyy")
                a(3) = newDR.Item("job_order_no").ToString

                a(4) = 0

                a(5) = newDR.Item("qty").ToString
                a(6) = newDR.Item("unit").ToString
                a(7) = Format(Date.Parse(newDR.Item("date_needed").ToString), "MM/dd/yyyy")
                a(8) = newDR.Item("typeRequest").ToString
                a(9) = newDR.Item("IN_OUT").ToString

                If newDR.Item("trans").ToString = "cancel" Then
                    a(10) = "CANCELLED"
                    a(11) = "CANCELLED"
                    a(12) = "CANCELLED"

                Else
                    If check_if_exist("dbpurchase_order", "rs_no", newDR.Item("rs_no").ToString, 0) > 0 Then
                        a(10) = "PO RELEASED"
                    Else
                        a(10) = "PENDING"
                    End If

                    If newDR.Item("IN_OUT").ToString = "IN" Then
                        a(12) = "N/A"
                        a(11) = "PENDING"
                    ElseIf newDR.Item("IN_OUT").ToString = "OUT" Then
                        a(12) = "PENDING"
                        a(11) = "N/A"
                        a(10) = "N/A"

                    ElseIf newDR.Item("IN_OUT").ToString = "FACILITIES" Or newDR.Item("IN_OUT").ToString = "TOOLS" Then
                        a(12) = "N/A"
                        a(11) = "PENDING"
                    End If


                    If check_if_exist("dbreceiving_info", "rs_no", newDR.Item("rs_no").ToString, 0) > 0 Then
                        a(10) = "PURCHASED"
                        a(11) = "RECEIVED"
                    Else

                    End If

                    If check_if_exist("dbwithdrawal_info", "rs_no", newDR.Item("rs_no").ToString, 0) > 0 Then
                        a(12) = "WITHDRAWN"
                        a(10) = "N/A"
                        a(11) = "N/A"
                    Else

                    End If

                End If

                If newDR.Item("IN_OUT").ToString = "FACILITIES" Or newDR.Item("IN_OUT").ToString = "TOOLS" Then
                    If newDR.Item("wh_id").ToString = wh_id And a(11) = "RECEIVED" Then
                        available_fac_tools += Val(a(5))
                    End If
                End If

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Public Sub load_fac_tools()
        cmbFacTools.Items.Clear()

        Try
            SQ.connection.Open()

            If public_fac_tools = "FACILITIES" Then
                publicquery = "SELECT fac_desc FROM dbfacilities_tools_desc WHERE fac_type = '" & "Facilities" & "'"
            ElseIf public_fac_tools = "TOOLS" Then
                publicquery = "SELECT fac_desc FROM dbfacilities_tools_desc WHERE fac_type = '" & "Tools" & "'"
            ElseIf public_fac_tools = "ALL" Then
                publicquery = "SELECT fac_desc FROM dbfacilities_tools_desc"
            End If

            'SELECT_QUERY(publicquery, 1, cmbFacTools, "5-5", 0)

            cmd = New SqlCommand(publicquery, SQ.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                cmbFacTools.Items.Add(dr.Item("fac_desc").ToString)
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()

        End Try
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
        Me.Dispose()

    End Sub



    Public Function check_if_exist_fac(ByVal fac_tools As String, ByVal specification As String) As Integer
        Try
            SQ.connection.Open()

            publicquery = "SELECT * FROM dbfacilities_tools WHERE fac_tools_desc = '" & fac_tools & "' AND specification = '" & specification & "'"
            cmd = New SqlCommand(publicquery, SQ.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                check_if_exist_fac += 1
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

    End Function

   
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Try
            Dim n As Integer

            If cmbFacTools.Text = "" Then
                MessageBox.Show("Please select a facilities and tools first..", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            ElseIf txtBrandTools.Text = "" Then
                MessageBox.Show("Please fill out the spefication first..", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If btnSave.Text = "Update" Then

                Dim id As Integer = CInt(lvlFacTools.SelectedItems(0).Text)

                publicquery = "UPDATE dbfacilities_tools SET fac_tools_desc = '" & cmbFacTools.Text & _
                "',specification = '" & txtBrandTools.Text & "',remarks = '" & txtRemarks.Text & "' "
                publicquery &= "WHERE fac_tools_id = " & id

                UPDATE_INSERT_DELETE_QUERY(publicquery, 0, "UPDATE")

                n = id

                MessageBox.Show("Successfully Updated...", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                load_fac_tools_to_list(0)

                btnRemove.PerformClick()

                txtSearch.Clear()
                txtBrandTools.Clear()
                txtRemarks.Clear()

            ElseIf btnSave.Text = "Save" Then

                If check_if_exist_fac(cmbFacTools.Text, txtBrandTools.Text) > 0 Then
                    MessageBox.Show("The data you been trying to save is already stored...", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                    txtBrandTools.Focus()

                End If

                publicquery = "INSERT INTO dbfacilities_tools(fac_tools_desc,specification,remarks,fac_id) VALUES('" & cmbFacTools.Text & "','" & _
                txtBrandTools.Text & "','" & txtRemarks.Text & "'," & CInt(Label2.Text) & ")"

                n = UPDATE_INSERT_DELETE_QUERY(publicquery, 1, "INSERT")

                MessageBox.Show("Successfully Saved...", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                load_fac_tools_to_list(0)

            End If

            listfocus(lvlFacTools, n)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click

        cmbFacTools.Text = lvlFacTools.SelectedItems(0).SubItems(1).Text
        txtBrandTools.Text = lvlFacTools.SelectedItems(0).SubItems(2).Text
        txtRemarks.Text = lvlFacTools.SelectedItems(0).SubItems(3).Text

        lvlFacTools.Enabled = False
        btnSave.Text = "Update"
        btnRemove.Text = "Cancel"
        txtSearch.Enabled = False


    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If btnRemove.Text = "Cancel" Then
            lvlFacTools.Enabled = True
            btnSave.Text = "Save"
            btnRemove.Text = "Remove"
            txtSearch.Enabled = True

            txtBrandTools.Focus()

        ElseIf btnRemove.Text = "Remove" Then

            If lvlFacTools.SelectedItems.Count > 0 Then
                If MessageBox.Show("Are you sure you want to remove selected item?", "EUS Info:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    publicquery = "DELETE FROM dbfacilities_tools WHERE fac_tools_id = " & CInt(lvlFacTools.SelectedItems(0).Text)
                    UPDATE_INSERT_DELETE_QUERY(publicquery, 0, "DELETE")

                    lvlFacTools.SelectedItems(0).Remove()
                    MessageBox.Show("Successfully removed...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If
            End If
        End If
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveToolStripMenuItem.Click
        btnRemove.PerformClick()

    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        load_fac_tools_to_list(1)

    End Sub

    Private Sub lvlFacTools_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvlFacTools.DoubleClick
        wh_id = lvlFacTools.SelectedItems(0).Text

        With FRequestField
            .txtItemDesc.Text = lvlFacTools.SelectedItems(0).SubItems(1).Text & " - " & lvlFacTools.SelectedItems(0).SubItems(2).Text

        End With
        Me.Close()
    End Sub

    Private Sub lvlFacTools_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvlFacTools.SelectedIndexChanged

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        pnlAddFacTools.Enabled = True

        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is Panel Then
            Else
                ctr.Enabled = False
            End If
        Next
        btnFac_Save.Text = "Save"

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        pnlAddFacTools.Enabled = False
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is Panel Then
                ctr.Enabled = False
            Else
                ctr.Enabled = True
            End If
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFac_Save.Click
        If btnFac_Save.Text = "Save" Then
            publicquery = "INSERT INTO dbfacilities_tools_desc(fac_type,fac_desc) VALUES('" & cmbFac_type.Text & "','" & txtFac_desc.Text & "')"
            UPDATE_INSERT_DELETE_QUERY(publicquery, 0, "INSERT")

            MessageBox.Show("Successfully Stored..", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)

            txtFac_desc.Clear()
            load_fac_tools()

        ElseIf btnFac_Save.Text = "Update" Then
            publicquery = "UPDATE dbfacilities_tools_desc SET fac_type = '" & cmbFac_type.Text & "',fac_desc = '" & txtFac_desc.Text & "' WHERE fac_id = " & CInt(Label2.Text)
            UPDATE_INSERT_DELETE_QUERY(publicquery, 0, "UPDATE")

            MessageBox.Show("Successfully Stored..", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)

            txtFac_desc.Clear()
            load_fac_tools()
            load_fac_tools_to_list(0)
            Button2.PerformClick()

        End If
       
    End Sub

    Private Sub cmbFacTools_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFacTools.SelectedIndexChanged
        fac_id = get_id("dbfacilities_tools_desc", "fac_desc", cmbFacTools.Text, 0)

        Label2.Text = fac_id

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click

        If Label2.Text = 0 Then
            MessageBox.Show("Please select a type to delete...", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If MessageBox.Show("Are you sure you want to delete the type of facilities? ", "EUS Info:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            'publicquery = "DELETE FROM dbfacilities_tools_desc WHERE fac_id = " & CInt(Label2.Text)
            'UPDATE_INSERT_DELETE_QUERY(publicquery, 0, "DELETE")
            'load_fac_tools()

            'Label2.Text = 0
            'MessageBox.Show("Successfully Deleted..", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)

            MessageBox.Show("Can't remove this time... Please contact the administrator for more details..", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Else

        End If

     

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        pnlAddFacTools.Enabled = True

        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is Panel Then
            Else
                ctr.Enabled = False
            End If
        Next

        btnFac_Save.Text = "Update"

        Try
            SQ.connection.Open()
            Dim query As String = "SELECT * FROM dbfacilities_tools_desc WHERE fac_id = " & CInt(Label2.Text)
            cmd = New SqlCommand(query, SQ.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                cmbFac_type.Text = dr.Item("fac_type").ToString
                txtFac_desc.Text = dr.Item("fac_desc").ToString
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()

        End Try

    End Sub

    Private Sub CreateBorrowerSlipToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim a(10) As String

        For i = 0 To lvlFacTools.Items.Count - 1

            If lvlFacTools.Items(i).Checked = True Then
                Try
                    SQ.connection.Open()
                    Dim query As String = "SELECT * FROM dbreceiving_items WHERE wh_id = " & Val(lvlFacTools.Items(i).Text)
                    cmd = New SqlCommand(query, SQ.connection)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        With FBorrow_List

                            a(1) = dr.Item("wh_id").ToString
                            a(2) = get_fac_type(dr.Item("wh_id").ToString, "")
                            a(3) = dr.Item("item_description").ToString
                            a(4) = dr.Item("qty").ToString
                            a(5) = 0

                            .dgBorrowList.Rows.Add(a)

                        End With
                    End While
                    dr.Close()

                Catch ex As Exception
                    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    SQ.connection.Close()

                End Try
            End If

        Next

        FBorrow_List.Show()

    End Sub

    Public Function get_fac_type(ByVal wh_id As Integer, ByVal id As String) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT b.fac_tools_id,a.fac_type,b.specification,a.fac_desc FROM dbfacilities_tools_desc a " & _
                                  "INNER JOIN dbfacilities_tools b ON a.fac_id = b.fac_id WHERE b.fac_tools_id = " & wh_id

            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                If id = "id" Then
                    get_fac_type = newDR.Item("fac_tools_id").ToString
                Else
                    get_fac_type = newDR.Item("fac_desc").ToString
                End If

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

        End Try
    End Function

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateBS.Click
        Dim a(10) As String
        Dim n As Integer = 0
        Dim ctr As Integer

        FBorrow_List.dgBorrowList.Rows.Clear()

        For i = 0 To lvlFacTools.Items.Count - 1

            If lvlFacTools.Items(i).Checked = True Then
                Try
                    SQ.connection.Open()
                    Dim query As String = "SELECT * FROM dbreceiving_items WHERE wh_id = " & Val(lvlFacTools.Items(i).Text)
                    cmd = New SqlCommand(query, SQ.connection)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        With FBorrow_List

                            a(1) = dr.Item("rr_item_id").ToString
                            a(2) = get_fac_type(dr.Item("wh_id").ToString, "")
                            a(3) = dr.Item("item_description").ToString
                            a(4) = dr.Item("qty").ToString
                            a(5) = 0
                            a(6) = get_fac_type(dr.Item("wh_id").ToString, "id")
                            .dgBorrowList.Rows.Add(a)

                            If borrow_status_exist(dr.Item("rr_item_id").ToString) = "borrowed" Then
                                For ii = 0 To 6
                                    .dgBorrowList.Rows(n).Cells(ii).Style.BackColor = Color.Violet
                                    .dgBorrowList.Rows(n).Cells(ii).Style.ForeColor = Color.White
                                Next
                            End If

                            n += 1
                        End With
                    End While
                    dr.Close()

                Catch ex As Exception
                    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    SQ.connection.Close()

                End Try

                ctr += 1
            End If

        Next

        If ctr > 0 Then : FBorrow_List.Show() : Else : MessageBox.Show("Please check atleast 1 to proceed...", "Supply Info:", MessageBoxButtons.OK, MessageBoxIcon.Error) : End If

    End Sub

    Public Function borrow_status_exist(ByVal rr_item_id As Integer) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()

            Dim query As String = "SELECT * FROM borrow_status WHERE rr_item_id = " & rr_item_id

            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader
            While newDR.Read
                borrow_status_exist = newDR.Item("status").ToString
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
End Class