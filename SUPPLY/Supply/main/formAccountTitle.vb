Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Globalization
Imports Microsoft.Office.Interop


Public Class formAccountTitle
    Public SQ As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Public public_query As String
    Dim type1 As String = "TYPE OF REQUEST"
    Dim type2 As String = "TYPE OF REQUEST SUB"
    Dim type3 As String = "ACCOUNT TITLE"
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub formAccountTitle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If auth = "Admin" Then
            DeleteToolStripMenuItem.Enabled = True
        Else
            DeleteToolStripMenuItem.Enabled = False
        End If

        cmbSearchType.Text = "Request"
        view_request_display()
    End Sub


    Public Sub view_request_display()
        listViewRequest.Items.Clear()
        Dim count1 As Integer = 0
        listViewRequest.Columns(1).Text = "Type of Request"

        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_request_type_request"
            sqlcomm.CommandType = CommandType.StoredProcedure
            'sqlcomm.Parameters.AddWithValue("@n", 1)

            If cmbSearchType.Text = "Request" Then
                listViewRequest.Columns(1).Width = 0
                listViewRequest.Columns(5).Width = 0
                listViewRequest.Columns(2).Text = "Type of Request"
                listViewRequest.Columns(2).Width = 400
                listViewRequest.Columns(3).Width = 180
                sqlcomm.Parameters.AddWithValue("@n", 1)
                lblHeaderTitle.Text = "TYPE OF REQUEST"
                'sqlcomm.Parameters.AddWithValue("@sum_project_code_search", cmbview_search.Text)
                'sqlcomm.Parameters.AddWithValue("@sum_date", DTP_search_Allowance.Text)
                'sqlcomm.Parameters.AddWithValue("@sum_date_to", DTP_period_to.Text)

            ElseIf cmbSearchType.Text = "Request Sub" Then
                listViewRequest.Columns(1).Width = 250
                listViewRequest.Columns(5).Width = 0
                listViewRequest.Columns(2).Text = "Type of Request Sub"
                listViewRequest.Columns(2).Width = 250
                listViewRequest.Columns(3).Width = 180

                sqlcomm.Parameters.AddWithValue("@n", 2)
                lblHeaderTitle.Text = "TYPE OF REQUEST SUB"
                'sqlcomm.Parameters.AddWithValue("@sum_project_code_search", cmbview_search.Text)
                'sqlcomm.Parameters.AddWithValue("@sum_date", DTP_search_Allowance.Text)
                'sqlcomm.Parameters.AddWithValue("@sum_date_to", DTP_period_to.Text)

            ElseIf cmbSearchType.Text = "Account Title" Then
                listViewRequest.Columns(1).Width = 250
                listViewRequest.Columns(5).Width = 250
                listViewRequest.Columns(2).Width = 250
                listViewRequest.Columns(3).Width = 120
                listViewRequest.Columns(1).Text = "Code"
                listViewRequest.Columns(2).Text = "Category"
                sqlcomm.Parameters.AddWithValue("@n", 3)
                lblHeaderTitle.Text = "ACCOUNT TITLE"
                'sqlcomm.Parameters.AddWithValue("@sum_project_code_search", cmbview_search.Text)
                'sqlcomm.Parameters.AddWithValue("@sum_date", DTP_search_Allowance.Text)
                'sqlcomm.Parameters.AddWithValue("@sum_date_to", DTP_period_to.Text)
            End If

            dr = sqlcomm.ExecuteReader
            While dr.Read

                Dim a(5) As String

                a(0) = dr.Item(0).ToString()
                If cmbSearchType.Text = "Account Title" Then
                    a(1) = dr.Item(1).ToString()
                    a(2) = dr.Item(2).ToString()
                    a(4) = dr.Item(4).ToString()
                    If IsDate(dr.Item(3)) Then
                        Dim tempDate As Date = CDate(dr.Item(3))
                        Dim formattedDate As String = Format(tempDate, "MM/dd/yyyy")
                        If formattedDate = "01/01/1995" OrElse formattedDate = "01/01/1990" OrElse formattedDate = "01/01/1900" Then
                            a(3) = "-"
                        Else
                            a(3) = formattedDate
                        End If
                    Else
                        a(3) = "-"
                    End If
                    a(5) = dr.Item(5).ToString()
                Else
                    a(1) = dr.Item(1).ToString()
                    a(2) = dr.Item(2).ToString()

                    If IsDate(dr.Item(3)) Then
                        Dim tempDate As Date = CDate(dr.Item(3))
                        Dim formattedDate As String = Format(tempDate, "MM/dd/yyyy")
                        If formattedDate = "01/01/1995" OrElse formattedDate = "01/01/1990" OrElse formattedDate = "01/01/1900" Then
                            a(3) = "-"
                        Else
                            a(3) = formattedDate
                        End If
                    Else
                        a(3) = "-"
                    End If

                    a(4) = dr.Item(4).ToString()
                    a(5) = ""
                End If
                count1 = count1 + 1
                Dim lvl As New ListViewItem(a)
                listViewRequest.Items.Add(lvl)
            End While
            lblDataCount.Text = "No. of Data Found: " & count1
            dr.Close()


        Catch ex As Exception
            Dim msg1 As New customMessageBox
            msg1.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Sub


    Public Sub view_request_display_after_save()
        listViewRequest.Items.Clear()
        Dim count1 As Integer = 0
        listViewRequest.Columns(1).Text = "Type of Request"
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_request_type_request"
            sqlcomm.CommandType = CommandType.StoredProcedure
            'ASDASD

            If txtSaveType.Text = "Request Sub" Or lblHeaderTitle.Text = "TYPE OF REQUEST SUB" Then
                listViewRequest.Columns(1).Width = 250
                listViewRequest.Columns(5).Width = 0
                listViewRequest.Columns(2).Text = "Type of Request Sub"
                listViewRequest.Columns(2).Width = 250
                listViewRequest.Columns(3).Width = 180
                sqlcomm.Parameters.AddWithValue("@n", 2)


                'listViewRequest.Columns(1).Text = "Type of Request"
                'listViewRequest.Columns(2).Text = "Description"

                'sqlcomm.Parameters.AddWithValue("@sum_project_code_search", cmbview_search.Text)
                'sqlcomm.Parameters.AddWithValue("@sum_date", DTP_search_Allowance.Text)
                'sqlcomm.Parameters.AddWithValue("@sum_date_to", DTP_period_to.Text)

            ElseIf txtSaveType.Text = "Account Title" Or lblHeaderTitle.Text = "ACCOUNT TITLE" Then
                listViewRequest.Columns(1).Width = 250
                listViewRequest.Columns(5).Width = 250
                listViewRequest.Columns(2).Width = 250
                listViewRequest.Columns(3).Width = 120
                listViewRequest.Columns(1).Text = "Code"
                listViewRequest.Columns(2).Text = "Category"
                sqlcomm.Parameters.AddWithValue("@n", 3)


            ElseIf lblHeaderTitle.Text = "TYPE OF REQUEST" Then
                listViewRequest.Columns(1).Width = 0
                listViewRequest.Columns(5).Width = 0
                listViewRequest.Columns(2).Text = "Type of Request"
                listViewRequest.Columns(2).Width = 400
                listViewRequest.Columns(3).Width = 180
                sqlcomm.Parameters.AddWithValue("@n", 1)

                'listViewRequest.Columns(1).Text = "Type of Request"
                'listViewRequest.Columns(2).Text = "Description"
                'lblHeaderTitle.Text = ".:TYPE OF REQUEST SUB:."
                'sqlcomm.Parameters.AddWithValue("@sum_project_code_search", cmbview_search.Text)
                'sqlcomm.Parameters.AddWithValue("@sum_date", DTP_search_Allowance.Text)
                'sqlcomm.Parameters.AddWithValue("@sum_date_to", DTP_period_to.Text)
            End If

            dr = sqlcomm.ExecuteReader
            While dr.Read

                Dim a(5) As String

                a(0) = dr.Item(0).ToString()
                If txtSaveType.Text = "Account Title" Or lblHeaderTitle.Text = "ACCOUNT TITLE" Then
                    a(1) = dr.Item(1).ToString()
                    a(2) = dr.Item(2).ToString()
                    a(3) = dr.Item(3).ToString()
                    If IsDate(dr.Item(4)) Then
                        Dim tempDate As Date = CDate(dr.Item(4))
                        Dim formattedDate As String = Format(tempDate, "MM/dd/yyyy")
                        If formattedDate = "01/01/1995" OrElse formattedDate = "01/01/1990" OrElse formattedDate = "01/01/1900" Then
                            a(4) = "-"
                        Else
                            a(4) = formattedDate
                        End If
                    Else
                        a(4) = "-"
                    End If
                    a(5) = dr.Item(5).ToString()
                Else
                    a(1) = dr.Item(1).ToString()
                    a(2) = dr.Item(2).ToString()

                    If IsDate(dr.Item(3)) Then
                        Dim tempDate As Date = CDate(dr.Item(3))
                        Dim formattedDate As String = Format(tempDate, "MM/dd/yyyy")
                        If formattedDate = "01/01/1995" OrElse formattedDate = "01/01/1990" OrElse formattedDate = "01/01/1900" Then
                            a(3) = "-"
                        Else
                            a(3) = formattedDate
                        End If
                    Else
                        a(3) = "-"
                    End If

                    a(4) = dr.Item(4).ToString()
                    a(5) = ""
                End If

                count1 = count1 + 1
                Dim lvl As New ListViewItem(a)
                listViewRequest.Items.Add(lvl)
            End While
            lblDataCount.Text = "No. of Data Found: " & count1
            dr.Close()


        Catch ex As Exception
            Dim msg1 As New customMessageBox
            msg1.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub cmbSearchType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearchType.SelectedIndexChanged
        lblID.Text = 0
        lblDescPick.Text = ""
        txtSaveType.Text = ""
        view_request_display()

        If cmbSearchType.Text = "Request" Then
            lblHeaderTitle.Text = "TYPE OF REQUEST"
            txtDesc.Text = ""
            txtCategory.Text = ""
            txtCategory.Enabled = True
            btnSave.Text = "Save"
            btnSave.Enabled = True
            btnSearch.Text = "←                         Search Request"
            txtCategory.Enabled = True
            lblDescription.Text = "Type of Request"

        ElseIf cmbSearchType.Text = "Request Sub" Then
            lblHeaderTitle.Text = "TYPE OF REQUEST SUB"
            txtDesc.Text = ""
            txtCategory.Text = ""
            txtCategory.Enabled = True
            btnSave.Text = "Save"
            btnSave.Enabled = True
            btnSearch.Text = "←                     Search Request Sub"
            txtCategory.Enabled = True
            lblDescription.Text = "Request Sub"


        ElseIf cmbSearchType.Text = "Account Title" Then
            lblHeaderTitle.Text = "ACCOUNT TITLE"
            txtDesc.Text = ""
            txtCategory.Text = ""
            txtCategory.Enabled = True
            btnSave.Text = "Save"
            btnSave.Enabled = True
            btnSearch.Text = "←                   Search Account Title"
            txtCategory.Enabled = False
            lblDescription.Text = "Code"
            txtDesc.Focus()

        End If
    End Sub

    Private Sub PickSubToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PickSubToolStripMenuItem.Click

        Dim index_id As Integer = 0
        Dim index_desc As String = 0
        If listViewRequest.SelectedItems.Count > 0 Then
            index_id = listViewRequest.SelectedItems(0).SubItems(0).Text
            If lblHeaderTitle.Text = "TYPE OF REQUEST" Then
                index_desc = listViewRequest.SelectedItems(0).SubItems(2).Text
                lblDescription.Text = "Code"
                txtDesc.Focus()
            ElseIf lblHeaderTitle.Text = "TYPE OF REQUEST SUB" Then
                index_desc = listViewRequest.SelectedItems(0).SubItems(2).Text
                lblDescription.Text = "Code"
                txtDesc.Focus()
            ElseIf lblHeaderTitle.Text = "ACCOUNT TITLE" Then
                index_desc = listViewRequest.SelectedItems(0).SubItems(2).Text

                txtDesc.Focus()

            End If

        End If

        lblID.Text = index_id
        lblDescPick.Text = index_desc
        btnSave.Text = "Save"
        txtDesc.Text = ""
        txtCategory.Text = ""





        If cmbSearchType.Text = "Request" And txtSaveType.Text = "" Then
            txtSaveType.Text = "Request Sub"
        ElseIf (cmbSearchType.Text = "Request" Or cmbSearchType.Text = "Request Sub" And txtSaveType.Text = "Request Sub" Or txtSaveType.Text = "") Then
            txtSaveType.Text = "Account Title"
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.Text = "Save" Then
            If cmbSearchType.Text = "Request" And txtDesc.Text <> "" And txtSaveType.Text = "" Then
                check_data_exist(1)
                view_request_display()

            ElseIf cmbSearchType.Text = "Request" And lblID.Text <> "0" And txtDesc.Text <> "" And txtSaveType.Text = "Request Sub" Then
                check_data_exist(2)
                view_request_display_after_save()

            ElseIf cmbSearchType.Text = "Request" Or cmbSearchType.Text = "Request Sub" And lblID.Text <> "0" And txtDesc.Text <> "" And txtSaveType.Text = "Account Title" Then
                check_data_exist(3)
                view_request_display_after_save()
            Else
                MsgBox("Please Input Valid", MsgBoxStyle.Critical, "Validation Error")
            End If
        ElseIf btnSave.Text = "Update" Then
            If UpdateToolStripMenuItem.Text = "Update Consolidated" Then
                MsgBox("You Trying to UPDATE consolidated")
                check_data_exist_update(3)
                view_request_display_after_save()
                btnSave.Text = "Save"

            ElseIf UpdateToolStripMenuItem.Text = "Update Type of Request SUB" Then
                MsgBox("You Trying to UPDATE Request SUB")
                check_data_exist_update(2)
                view_request_display_after_save()
                btnSave.Text = "Save"
            ElseIf UpdateToolStripMenuItem.Text = "Update Type of Request" Then
                MsgBox("You Trying to UPDATE Request")
                check_data_exist_update(1)
                view_request_display()
                btnSave.Text = "Save"
            End If
        End If


    End Sub



    Public Sub check_data_exist(ByVal x As Integer)
        Try
            SQ.connection.Open()
            If x = 1 Then
                public_query = "select tor_desc FROM [supply_db].[dbo].[dbType_of_Request] 
                                where tor_desc = '" & txtDesc.Text & "'"
                cmd = New SqlCommand(public_query, SQ.connection)
                dr = cmd.ExecuteReader

                If dr.HasRows Then

                    MsgBox("The " + txtDesc.Text + " Has already exist")

                Else
                    dr.Close()
                    save_data(1)

                End If

            ElseIf x = 2 Then
                save_data(2)
                'public_query = "select tor_sub_desc FROM [supply_db].[dbo].[dbType_of_Request_sub] 
                '                where tor_sub_desc = '" & txtDesc.Text & "'"
                'cmd = New SqlCommand(public_query, SQ.connection)
                'dr = cmd.ExecuteReader


                'If dr.HasRows Then
                '    MsgBox("The " + txtDesc.Text + " Has already exist, but we’ll save it for now.")
                '    save_data(2)
                'Else
                '    dr.Close()
                '    save_data(2)

                'End If

            ElseIf x = 3 Then
                save_data(3)
                'public_query = "select codes FROM [supply_db].[dbo].[dbConsolidated_account] 
                '                where codes = '" & txtDesc.Text & "' AND status = 'active'"
                'cmd = New SqlCommand(public_query, SQ.connection)
                'dr = cmd.ExecuteReader


                'If dr.HasRows Then
                '    MsgBox("The " + txtDesc.Text + " Has already exist, but we’ll save it for now.")
                '    save_data(3)
                'Else
                '    dr.Close()
                '    save_data(3)

                'End If
            End If
            SQ.connection.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try
    End Sub


    Public Sub check_data_exist_update(ByVal x As Integer)
        Try
            SQ.connection.Open()
            If x = 1 Then
                public_query = "select tor_desc FROM [supply_db].[dbo].[dbType_of_Request] 
                                where tor_desc = '" & txtDesc.Text & "'"
                cmd = New SqlCommand(public_query, SQ.connection)
                dr = cmd.ExecuteReader

                If dr.HasRows Then

                    MsgBox("The " + txtDesc.Text + " Has already exist")

                Else
                    dr.Close()
                    update_data(1)

                End If

            ElseIf x = 2 Then
                public_query = "select tor_sub_desc FROM [supply_db].[dbo].[dbType_of_Request_sub] 
                                where tor_sub_desc = '" & txtDesc.Text & "'"
                cmd = New SqlCommand(public_query, SQ.connection)
                dr = cmd.ExecuteReader


                If dr.HasRows Then
                    MsgBox("The " + txtDesc.Text + " Has already exist")
                Else
                    dr.Close()
                    update_data(2)

                End If

            ElseIf x = 3 Then
                public_query = "select codes FROM [supply_db].[dbo].[dbConsolidated_account] 
                                where codes = '" & txtDesc.Text & "'"
                cmd = New SqlCommand(public_query, SQ.connection)
                dr = cmd.ExecuteReader


                If dr.HasRows Then
                    MsgBox("The " + txtDesc.Text + " Has already exist")
                Else
                    dr.Close()
                    update_data(3)

                End If
            End If
            SQ.connection.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try
    End Sub



    Public Sub save_data(ByVal x As Integer)

        Try
            'SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_request_type_request"
            sqlcomm.CommandType = CommandType.StoredProcedure

            If x = 1 Then
                sqlcomm.Parameters.AddWithValue("@n", 4)
                sqlcomm.Parameters.AddWithValue("@txtDesc", txtDesc.Text)
                sqlcomm.Parameters.AddWithValue("@user_id", pub_user_id)

                sqlcomm.ExecuteScalar()
                txtDesc.Text = ""
                txtSaveType.Text = ""
                MsgBox("Request Successfully Save", MsgBoxStyle.Information, "Information")
                lblHeaderTitle.Text = "TYPE OF REQUEST"


            ElseIf x = 2 Then
                sqlcomm.Parameters.AddWithValue("@n", 5)
                sqlcomm.Parameters.AddWithValue("@txtDesc", txtCategory.Text)
                sqlcomm.Parameters.AddWithValue("@ids", lblID.Text)
                sqlcomm.Parameters.AddWithValue("@user_id", pub_user_id)
                sqlcomm.Parameters.AddWithValue("@code", txtDesc.Text)

                sqlcomm.ExecuteScalar()
                txtDesc.Text = ""
                MsgBox("Request Sub Successfully Save", MsgBoxStyle.Information, "Information")
                lblHeaderTitle.Text = "TYPE OF REQUEST SUB"
                txtCategory.Text = ""

            ElseIf x = 3 Then
                sqlcomm.Parameters.AddWithValue("@n", 6)
                sqlcomm.Parameters.AddWithValue("@txtDesc", txtDesc.Text)
                sqlcomm.Parameters.AddWithValue("@ids", lblID.Text)
                sqlcomm.Parameters.AddWithValue("@txtCategory", txtCategory.Text)
                sqlcomm.Parameters.AddWithValue("@user_id", pub_user_id)
                sqlcomm.ExecuteScalar()
                txtDesc.Text = ""
                txtCategory.Text = ""
                MsgBox("Consolidation Successfully Save", MsgBoxStyle.Information, "Information")
                lblHeaderTitle.Text = "ACCOUNT TITLE"

            End If

            'SQ.connection.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try




    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening


        If lblHeaderTitle.Text = "TYPE OF REQUEST" Then
            PickSubToolStripMenuItem.Enabled = True
            txtCategory.Enabled = True
            txtCategory.Text = ""
            PickSubToolStripMenuItem.Text = "Select For Request Sub"
            UpdateToolStripMenuItem.Text = "Update Type of Request"
        ElseIf lblHeaderTitle.Text = "TYPE OF REQUEST SUB" Then
            PickSubToolStripMenuItem.Enabled = True
            PickSubToolStripMenuItem.Text = "Select For Consolidated"
            txtCategory.Enabled = True
            UpdateToolStripMenuItem.Text = "Update Type of Request SUB"

        ElseIf lblHeaderTitle.Text = "ACCOUNT TITLE" Then
            UpdateToolStripMenuItem.Text = "Update Consolidated"
            PickSubToolStripMenuItem.Enabled = False
        Else
            PickSubToolStripMenuItem.Enabled = False
            txtCategory.Enabled = False
        End If
    End Sub

    Private Sub lblHeaderTitle_Click(sender As Object, e As EventArgs) Handles lblHeaderTitle.Click

    End Sub

    Private Sub txtDesc_TextChanged(sender As Object, e As EventArgs) Handles txtDesc.TextChanged

    End Sub

    Private Sub UpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateToolStripMenuItem.Click
        btnSave.Text = "Update"
        Dim index_id As Integer = 0
        Dim index_desc As String = ""
        Dim index_category As String = ""

        If listViewRequest.SelectedItems.Count > 0 Then
            index_id = listViewRequest.SelectedItems(0).SubItems(0).Text
            If lblHeaderTitle.Text = "TYPE OF REQUEST" Then
                index_desc = listViewRequest.SelectedItems(0).SubItems(2).Text
                txtDesc.Focus()
            ElseIf lblHeaderTitle.Text = "TYPE OF REQUEST SUB" Then
                index_desc = listViewRequest.SelectedItems(0).SubItems(2).Text
                txtDesc.Focus()
            ElseIf lblHeaderTitle.Text = "ACCOUNT TITLE" Then
                index_desc = listViewRequest.SelectedItems(0).SubItems(1).Text
                index_category = listViewRequest.SelectedItems(0).SubItems(2).Text
                txtCategory.Enabled = True
                txtDesc.Focus()

            End If

        End If

        lblID.Text = index_id
        txtDesc.Text = index_desc
        txtCategory.Text = index_category
        txtSaveType.Text = ""
        lblDescPick.Text = ""

    End Sub

    Public Sub update_data(ByVal x As Integer)
        Try
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_request_type_request"
            sqlcomm.CommandType = CommandType.StoredProcedure

            If x = 1 Then
                sqlcomm.Parameters.AddWithValue("@n", 7)
                sqlcomm.Parameters.AddWithValue("@txtDesc", txtDesc.Text)
                sqlcomm.Parameters.AddWithValue("@ids", lblID.Text)
                sqlcomm.Parameters.AddWithValue("@user_id", pub_user_id)
                sqlcomm.ExecuteScalar()
                MsgBox("SUCCESSFULLY UPDATE TYPE REQUEST", MsgBoxStyle.Information, "Update Successful")
                lblHeaderTitle.Text = "TYPE OF REQUEST"
                txtDesc.Text = ""
                lblID.Text = 0
                btnSave.Text = "Save"

            ElseIf x = 2 Then
                sqlcomm.Parameters.AddWithValue("@n", 8)
                sqlcomm.Parameters.AddWithValue("@txtDesc", txtDesc.Text)
                sqlcomm.Parameters.AddWithValue("@ids", lblID.Text)
                sqlcomm.Parameters.AddWithValue("@user_id", pub_user_id)
                sqlcomm.ExecuteScalar()
                MsgBox("SUCCESSFULLY UPDATE TYPE REQUEST SUB", MsgBoxStyle.Information, "Update Successful")
                lblHeaderTitle.Text = "TYPE OF REQUEST SUB"
                txtDesc.Text = ""
                lblID.Text = 0
                btnSave.Text = "Save"

            ElseIf x = 3 Then
                sqlcomm.Parameters.AddWithValue("@n", 9)
                sqlcomm.Parameters.AddWithValue("@txtDesc", txtDesc.Text)
                sqlcomm.Parameters.AddWithValue("@txtCategory", txtCategory.Text)
                sqlcomm.Parameters.AddWithValue("@ids", lblID.Text)
                sqlcomm.Parameters.AddWithValue("@user_id", pub_user_id)
                sqlcomm.ExecuteScalar()
                MsgBox("SUCCESSFULLY UPDATE CONSOLIDATED", MsgBoxStyle.Information, "Update Successful")
                lblHeaderTitle.Text = "ACCOUNT TITLE"
                txtCategory.Text = ""
                txtDesc.Text = ""
                lblID.Text = 0
                btnSave.Text = "Save"

            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim index_id As Integer = 0
        Dim index_desc As String = ""
        Dim index_category As String = ""

        If listViewRequest.SelectedItems.Count > 0 Then
            index_id = listViewRequest.SelectedItems(0).SubItems(0).Text
            If lblHeaderTitle.Text = "TYPE OF REQUEST" Then
                index_desc = listViewRequest.SelectedItems(0).SubItems(2).Text
                'txtDesc.Focus()
            ElseIf lblHeaderTitle.Text = "TYPE OF REQUEST SUB" Then
                index_desc = listViewRequest.SelectedItems(0).SubItems(2).Text
                'txtDesc.Focus()
            ElseIf lblHeaderTitle.Text = "ACCOUNT TITLE" Then
                index_desc = listViewRequest.SelectedItems(0).SubItems(1).Text
                index_category = listViewRequest.SelectedItems(0).SubItems(2).Text
                'txtDesc.Focus()

            End If

        End If

        lblID.Text = index_id
        lblDescPick.Text = index_desc
        txtDesc.Text = ""
        txtSaveType.Text = ""
        txtCategory.Text = ""
        btnSave.Text = "Save"

        If lblHeaderTitle.Text = type1 Then
            delete_data(1)
            view_request_display()
        ElseIf lblHeaderTitle.Text = type2 Then
            delete_data(2)
            view_request_display_after_save()
        ElseIf lblHeaderTitle.Text = type3 Then
            delete_data(3)
            view_request_display_after_save()
        End If
    End Sub


    Private Sub delete_data(ByVal x As Integer)
        Dim indexDesc As String = lblDescPick.Text
        Try
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_request_type_request"
            sqlcomm.CommandType = CommandType.StoredProcedure

            SQ.connection.Open()

            If x = 1 Then
                public_query = "SELECT COUNT(*) FROM dbType_of_Request_sub WHERE tor_id = @id AND status = 'active'"
                Dim cmd As New SqlCommand(public_query, SQ.connection)
                cmd.Parameters.AddWithValue("@id", lblID.Text)

                Dim count As Integer = CInt(cmd.ExecuteScalar())

                If count > 0 Then
                    If MessageBox.Show("There are [" & count & "] Active Connected To [Request Sub] in [" & indexDesc & "] you're trying to [DELETE]." & vbCrLf & "All connected data will be deleted. " & vbCrLf & "Are you sure you want to delete?", type1, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                        sqlcomm.Parameters.AddWithValue("@n", 10)
                        sqlcomm.Parameters.AddWithValue("@ids", lblID.Text)
                        sqlcomm.Parameters.AddWithValue("@user_id", pub_user_id)
                        sqlcomm.ExecuteScalar()
                        MsgBox("Successfully Deleted!")
                        lblID.Text = 0
                        lblDescPick.Text = ""
                    Else
                        lblID.Text = 0
                        lblDescPick.Text = ""
                    End If

                Else
                    If MessageBox.Show("This data has NO connections and is safe to delete. " & vbCrLf & " Are you sure you want to delete [" & indexDesc & "]?", type1, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                        sqlcomm.Parameters.AddWithValue("@n", 10)
                        sqlcomm.Parameters.AddWithValue("@ids", lblID.Text)
                        sqlcomm.Parameters.AddWithValue("@user_id", pub_user_id)
                        sqlcomm.ExecuteScalar()
                        MsgBox("Successfully Deleted!")
                        lblID.Text = 0
                        lblDescPick.Text = ""
                    Else
                        lblID.Text = 0
                        lblDescPick.Text = ""
                    End If
                End If

            ElseIf x = 2 Then

                public_query = " SELECT COUNT(*) 
                                 FROM dbTypeOfRequestSub_dbConsolidatedAccount a
                                 LEFT JOIN dbConsolidated_account b ON b.consolidated_account_id  = a.consolidated_account_id 
                                 WHERE a.tor_sub_id = @id and b.status = 'active'"
                Dim cmd As New SqlCommand(public_query, SQ.connection)
                cmd.Parameters.AddWithValue("@id", lblID.Text)

                Dim count2 As Integer = CInt(cmd.ExecuteScalar())

                If count2 > 0 Then
                    If MessageBox.Show("There are [" & count2 & "] Active Connected To [Account Title] in [" & indexDesc & "] you're trying to [DELETE]." & vbCrLf & "All connected data will be deleted. " & vbCrLf & "Are you sure you want to delete?", type2, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                        sqlcomm.Parameters.AddWithValue("@n", 11)
                        sqlcomm.Parameters.AddWithValue("@ids", lblID.Text)
                        sqlcomm.Parameters.AddWithValue("@user_id", pub_user_id)
                        sqlcomm.ExecuteScalar()
                        MsgBox("Successfully Deleted!")
                        lblID.Text = 0
                        lblDescPick.Text = ""
                    Else
                        lblID.Text = 0
                        lblDescPick.Text = ""
                    End If
                Else
                    If MessageBox.Show("This data has NO connections and is safe to delete. " & vbCrLf & " Are you sure you want to delete [" & indexDesc & "]?", type2, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                        sqlcomm.Parameters.AddWithValue("@n", 11)
                        sqlcomm.Parameters.AddWithValue("@ids", lblID.Text)
                        sqlcomm.Parameters.AddWithValue("@user_id", pub_user_id)
                        sqlcomm.ExecuteScalar()
                        MsgBox("Successfully Deleted!")
                        lblID.Text = 0
                        lblDescPick.Text = ""
                    Else
                        lblID.Text = 0
                        lblDescPick.Text = ""
                    End If
                End If
            ElseIf x = 3 Then
                public_query = "SELECT TOP 1000 COUNT(*) FROM rs_tor_sub_property a
                                LEFT JOIN dbTypeOfRequestSub_dbConsolidatedAccount b ON b.tors_ca_id = a.tors_ca_id
                                LEFT JOIN dbConsolidated_account c ON c.consolidated_account_id = b.consolidated_account_id
                                WHERE c.consolidated_account_id = @id AND c.status = 'active'"
                Dim cmd As New SqlCommand(public_query, SQ.connection)
                cmd.Parameters.AddWithValue("@id", lblID.Text)

                Dim count2 As Integer = CInt(cmd.ExecuteScalar())

                If count2 > 0 Then
                    If MessageBox.Show("There are [" & count2 & "] Active Connected To [RS Sub Property] in [" & indexDesc & "] you're trying to [DELETE]." & vbCrLf & "All connected data will be deleted. " & vbCrLf & "Are you sure you want to delete?", type2, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                        sqlcomm.Parameters.AddWithValue("@n", 12)
                        sqlcomm.Parameters.AddWithValue("@ids", lblID.Text)
                        sqlcomm.Parameters.AddWithValue("@user_id", pub_user_id)
                        sqlcomm.ExecuteScalar()
                        MsgBox("Successfully Deleted!")
                        lblID.Text = 0
                        lblDescPick.Text = ""
                    Else
                        lblID.Text = 0
                        lblDescPick.Text = ""
                    End If
                Else
                    If MessageBox.Show("This data has NO connections and is safe to delete. " & vbCrLf & " Are you sure you want to delete [" & indexDesc & "]?", type2, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                        sqlcomm.Parameters.AddWithValue("@n", 12)
                        sqlcomm.Parameters.AddWithValue("@ids", lblID.Text)
                        sqlcomm.Parameters.AddWithValue("@user_id", pub_user_id)
                        sqlcomm.ExecuteScalar()
                        MsgBox("Successfully Deleted!")
                        lblID.Text = 0
                        lblDescPick.Text = ""
                    Else
                        lblID.Text = 0
                        lblDescPick.Text = ""
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        SQ.connection.Close()
    End Sub

    Private Sub search(ByVal x As Integer)
        listViewRequest.Items.Clear()
        Dim count1 As Integer = 0


        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_request_type_request"
            sqlcomm.CommandType = CommandType.StoredProcedure

            If x = 1 Then
                sqlcomm.Parameters.AddWithValue("@n", 13)
                sqlcomm.Parameters.AddWithValue("@txtDesc", txtDesc.Text)
                sqlcomm.Parameters.AddWithValue("@user_id", pub_user_id)
                listViewRequest.Columns(1).Width = 0
                listViewRequest.Columns(5).Width = 0
                listViewRequest.Columns(2).Text = "Type of Request"
                listViewRequest.Columns(2).Width = 400
                listViewRequest.Columns(3).Width = 180


            ElseIf x = 2 Then
                sqlcomm.Parameters.AddWithValue("@n", 14)
                sqlcomm.Parameters.AddWithValue("@txtDesc", txtDesc.Text)
                sqlcomm.Parameters.AddWithValue("@user_id", pub_user_id)
                listViewRequest.Columns(1).Width = 250
                listViewRequest.Columns(5).Width = 0
                listViewRequest.Columns(2).Text = "Type of Request Sub"
                listViewRequest.Columns(2).Width = 250
                listViewRequest.Columns(3).Width = 180

            ElseIf x = 3 Then
                sqlcomm.Parameters.AddWithValue("@n", 15)
                sqlcomm.Parameters.AddWithValue("@txtDesc", txtDesc.Text)
                sqlcomm.Parameters.AddWithValue("@user_id", pub_user_id)
                listViewRequest.Columns(1).Width = 250
                listViewRequest.Columns(5).Width = 250
                listViewRequest.Columns(2).Width = 250
                listViewRequest.Columns(3).Width = 120
                listViewRequest.Columns(1).Text = "Code"
                listViewRequest.Columns(2).Text = "Category"
            End If

            dr = sqlcomm.ExecuteReader
            While dr.Read

                Dim a(5) As String

                a(0) = dr.Item(0).ToString()
                If cmbSearchType.Text = "Account Title" Then
                    a(1) = dr.Item(1).ToString()
                    a(2) = dr.Item(2).ToString()
                    a(3) = dr.Item(3).ToString()
                    If IsDate(dr.Item(4)) Then
                        Dim tempDate As Date = CDate(dr.Item(4))
                        Dim formattedDate As String = Format(tempDate, "MM/dd/yyyy")
                        If formattedDate = "01/01/1995" OrElse formattedDate = "01/01/1990" OrElse formattedDate = "01/01/1900" Then
                            a(4) = "-"
                        Else
                            a(4) = formattedDate
                        End If
                    Else
                        a(4) = "-"
                    End If
                    a(5) = dr.Item(5).ToString()
                Else
                    a(1) = dr.Item(1).ToString()
                    a(2) = dr.Item(2).ToString()

                    If IsDate(dr.Item(3)) Then
                        Dim tempDate As Date = CDate(dr.Item(3))
                        Dim formattedDate As String = Format(tempDate, "MM/dd/yyyy")
                        If formattedDate = "01/01/1995" OrElse formattedDate = "01/01/1990" OrElse formattedDate = "01/01/1900" Then
                            a(3) = "-"
                        Else
                            a(3) = formattedDate
                        End If
                    Else
                        a(3) = "-"
                    End If

                    a(4) = dr.Item(4).ToString()
                    a(5) = ""
                End If

                count1 = count1 + 1
                Dim lvl As New ListViewItem(a)
                listViewRequest.Items.Add(lvl)
            End While
            lblDataCount.Text = "No. of Data Found: " & count1
            dr.Close()


        Catch ex As Exception
            Dim msg1 As New customMessageBox
            msg1.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click


        If lblHeaderTitle.Text = "TYPE OF REQUEST" Then
            search(1)
        ElseIf lblHeaderTitle.Text = "TYPE OF REQUEST SUB" Then
            search(2)
        ElseIf lblHeaderTitle.Text = "ACCOUNT TITLE" Then
            search(3)
        End If
    End Sub

    Private Sub formAccountTitle_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            txtDesc.Text = ""
            txtCategory.Text = ""
            txtSaveType.Text = ""
            btnSave.Text = "Save"
            If lblHeaderTitle.Text = "TYPE OF REQUEST" Then
                cmbSearchType.Text = "Request"
            ElseIf lblHeaderTitle.Text = "TYPE OF REQUEST SUB" Then
                cmbSearchType.Text = "Request Sub"
            ElseIf lblHeaderTitle.Text = "ACCOUNT TITLE" Then
                cmbSearchType.Text = "Account Title"
            End If
        ElseIf e.Control AndAlso e.KeyCode = Keys.S Then
            btnSave.PerformClick()

        End If
    End Sub
End Class