Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FOldFacilities

    Private Sub FOldFacilities_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            btnSave.PerformClick()

        End If
    End Sub

    Private Sub FOldFacilities_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ComboBox Then
                Dim cbox As ComboBox = ctr
                cbox.SelectedIndex = -1
            End If
        Next

        load_to_all_cmbox()
    End Sub
    Public Sub load_to_all_cmbox()

        cmbTypeOfCustodian.Enabled = False
        cmbTypeofCharge.Enabled = False
        cmbStatus.Enabled = False

        load_fac_name(Brand_cmbfac_name)

        cmbTypeofCharge.Items.Clear()
        cmbTypeOfCustodian.Items.Clear()

        FRequestField.load_type_of_request("CASH", cmbTypeofCharge)
        FRequestField.load_type_of_request("CASH", cmbTypeOfCustodian)

        If borrower_edit = 1 Then
        ElseIf borrower_edit = 2 Then
            load_this_if_edit()
        End If

    End Sub
    Public Sub load_this_if_edit()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_facilities", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 24)
            newCMD.Parameters.AddWithValue("@fi_id", CInt(FBorrowed_Item_Monitoring.lvList.SelectedItems(0).Text))

            newDR = newCMD.ExecuteReader
            Dim a(5) As String
            While newDR.Read

                dtpDateAquired.Text = newDR.Item("date_aquired").ToString
                cmbFac_ToolsType.Text = newDR.Item("fac_tools").ToString
                Brand_cmbfac_name.Text = newDR.Item("facility_name").ToString
                cmbBrand.Text = newDR.Item("brand").ToString
                cmbTypeOfCustodian.Text = newDR.Item("type_of_custodian").ToString
                cmbTypeofCharge.Text = newDR.Item("type_of_received").ToString
                cmbStatus.Text = newDR.Item("condition").ToString
                txtRemarks.Text = newDR.Item("remarks").ToString
                txtno.Text = newDR.Item("no").ToString

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Public Sub load_fac_name(ByVal cmbobj As Object)
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
            newCMD.Parameters.AddWithValue("@facility_tools", cmbFac_ToolsType.Text)

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

    Private Sub Brand_cmbfac_name_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Brand_cmbfac_name.SelectedIndexChanged
        load_facility_names(Brand_cmbfac_name.Text)
    End Sub

    Public Sub load_facility_names(ByVal fac_name As String)
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

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        charge_to_selection = 2

        charge_to_destination = 5

        FCharge_To.ShowDialog()
    End Sub

    Private Sub cmbTypeofCharge_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTypeofCharge.SelectedIndexChanged
        Select Case cmbTypeofCharge.Text
            Case "ADFIL"
                cmbChargeTo1.Visible = False
                txtChargeTo.Visible = True

                txtChargeTo.Clear()
                charge_to_id1 = 0

            Case "PROJECT"

                cmbChargeTo1.Visible = True
                txtChargeTo.Visible = False

                cmbChargeTo1.Location = New Point(txtChargeTo.Bounds.Left, txtChargeTo.Bounds.Top)

                FRequestField.load_equipment(1, cmbChargeTo1)

                txtChargeTo.Clear()
                charge_to_id1 = 0

            Case "EQUIPMENT"
                cmbChargeTo1.Visible = True
                txtChargeTo.Visible = False

                cmbChargeTo1.Location = New Point(txtChargeTo.Bounds.Left, txtChargeTo.Bounds.Top)

                FRequestField.load_equipment(0, cmbChargeTo1)

                txtChargeTo.Clear()
                charge_to_id1 = 0

            Case "PERSONAL"
                cmbChargeTo1.Visible = False
                txtChargeTo.Visible = True

                txtChargeTo.Clear()
                charge_to_id1 = 0

            Case "WAREHOUSE"
                cmbChargeTo1.Visible = False
                txtChargeTo.Visible = True

                txtChargeTo.Clear()
                charge_to_id1 = 0
            Case "CASH"
                cmbChargeTo1.Visible = False
                txtChargeTo.Visible = True

                txtChargeTo.Clear()
                charge_to_id1 = 0

        End Select
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
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

        charge_to_destination = 6
        FCharge_To.ShowDialog()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'For Each ctr As Control In Me.Controls
        '    If TypeOf ctr Is ComboBox Then
        '        If ctr.Text = "" Then
        '            MessageBox.Show("Please fill in the blank area..", "Borrower Info:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '            Exit Sub
        '        ElseIf ctr.Name = "cmbStatus" Then

        '        End If
        '    End If
        'Next
        If cmbFac_ToolsType.Text = "" Or cmbBrand.Text = "" Or Brand_cmbfac_name.Text = "" Then
            MessageBox.Show("Please fill in the blank area..", "Borrower Info:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        Dim lof_id As Integer = get_lof_id()

        If btnSave.Text = "Save (Ctrl + S)" Then

            FPOFORM.INSERT_FACILITIES_ITEM(0, lof_id, Date.Parse(dtpDateAquired.Text), charge_to_id, charge_to_id1, _
                                           cmbStatus.Text, txtRemarks.Text, 1, cmbTypeOfCustodian.Text, cmbTypeofCharge.Text, CInt(txtno.Text))

            MessageBox.Show("Successfully Saved...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)

            txtCustodian.Clear()
            txtChargeTo.Clear()
            txtno.Text = 0
            txtRemarks.Clear()
            cmbBrand.Items.Clear()
            cmbTypeOfCustodian.Items.Clear()
            cmbTypeofCharge.Items.Clear()

            load_to_all_cmbox()

            dtpDateAquired.Focus()

            FBorrowed_Item_Monitoring.LOAD_facilities_item()

        ElseIf btnSave.Text = "Update (Ctrl + S)" Then
            Dim fi_id As Integer = CInt(FBorrowed_Item_Monitoring.lvList.SelectedItems(0).Text)
            UPDATE_FACILITIES_ITEM(txtno.Text, lof_id, dtpDateAquired.Text, cmbTypeOfCustodian.Text, _
                                    charge_to_id, cmbTypeofCharge.Text, charge_to_id1, cmbStatus.Text, _
                                    fi_id, txtRemarks.Text)

            MessageBox.Show("Successfully Updated...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)


            FBorrowed_Item_Monitoring.LOAD_facilities_item()
            listfocus(FBorrowed_Item_Monitoring.lvList, fi_id)
            Me.Close()

        End If



    End Sub

    Public Sub UPDATE_FACILITIES_ITEM(ByVal no As Integer, ByVal lof_id As Integer, ByVal date_aquired As DateTime, _
                                      ByVal type_of_custodian As String, ByVal custodian As Integer, ByVal type_of_received As String, _
                                      ByVal received_to As Integer, ByVal condition As String, ByVal fi_id As Integer, ByVal remarks As String)

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_facilities", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 16)
            newCMD.Parameters.AddWithValue("@no", no)
            newCMD.Parameters.AddWithValue("@lof_id", lof_id)
            newCMD.Parameters.AddWithValue("@date_aquired", date_aquired)
            newCMD.Parameters.AddWithValue("@type_of_custodian", type_of_custodian)
            newCMD.Parameters.AddWithValue("@custodian", custodian)
            newCMD.Parameters.AddWithValue("@type_of_received", type_of_received)
            newCMD.Parameters.AddWithValue("@received_to", received_to)
            newCMD.Parameters.AddWithValue("@condition", condition)
            newCMD.Parameters.AddWithValue("@fi_id", fi_id)
            newCMD.Parameters.AddWithValue("@remarks", remarks)

            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub cmbTypeOfCustodian_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTypeOfCustodian.SelectedIndexChanged
        Select Case cmbTypeOfCustodian.Text
            Case "ADFIL"
                cmbChargeTo.Visible = False
                txtCustodian.Visible = True

                txtCustodian.Clear()

                If borrower_edit = 2 Then
                Else
                    charge_to_id = 0
                End If


            Case "PROJECT"

                cmbChargeTo.Visible = True
                txtCustodian.Visible = False

                cmbChargeTo.Location = New Point(txtCustodian.Bounds.Left, txtCustodian.Bounds.Top)

                FRequestField.load_equipment(1, cmbChargeTo)

                txtCustodian.Clear()
                If borrower_edit = 2 Then
                Else
                    charge_to_id = 0
                End If

            Case "EQUIPMENT"
                cmbChargeTo.Visible = True
                txtCustodian.Visible = False

                cmbChargeTo.Location = New Point(txtCustodian.Bounds.Left, txtCustodian.Bounds.Top)

                FRequestField.load_equipment(0, cmbChargeTo)

                txtCustodian.Clear()
                charge_to_id = 0

            Case "PERSONAL"
                cmbChargeTo.Visible = False
                txtCustodian.Visible = True

                txtCustodian.Clear()
                If borrower_edit = 2 Then
                Else
                    charge_to_id = 0
                End If

            Case "WAREHOUSE"
                cmbChargeTo.Visible = False
                txtCustodian.Visible = True

                txtCustodian.Clear()
                If borrower_edit = 2 Then
                Else
                    charge_to_id = 0
                End If
            Case "CASH"
                cmbChargeTo.Visible = False
                txtCustodian.Visible = True

                txtCustodian.Clear()
                If borrower_edit = 2 Then
                Else
                    charge_to_id = 0
                End If

        End Select
    End Sub

    Private Sub cmbChargeTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbChargeTo.SelectedIndexChanged
        Dim sqlcon As New SQLcon
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        If cmbTypeOfCustodian.Text = "EQUIPMENT" Then
            Try
                'sqlcon.set_sql("192.168.1.92", "eus_031916", "sa", "adfil")
                'sqlcon.sql_connect()

                sqlcon.connection1.Open()
                publicquery = "SELECT equipListID FROM dbequipment_list WHERE plate_no = '" & cmbChargeTo.Text & "'"
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

        ElseIf cmbTypeOfCustodian.Text = "PROJECT" Then
            Try
                'sqlcon.set_sql("192.168.1.92", "eus_031916", "sa", "adfil")
                'sqlcon.sql_connect()

                sqlcon.connection1.Open()
                publicquery = "SELECT proj_id FROM dbprojectdesc WHERE project_desc = '" & cmbChargeTo.Text & "'"
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

        End If

    End Sub

    Private Sub cmbChargeTo1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbChargeTo1.SelectedIndexChanged
        Dim sqlcon As New SQLcon
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        If cmbTypeofCharge.Text = "EQUIPMENT" Then
            Try
                'sqlcon.set_sql("192.168.1.92", "eus_031916", "sa", "adfil")
                'sqlcon.sql_connect()

                sqlcon.connection1.Open()
                publicquery = "SELECT equipListID FROM dbequipment_list WHERE plate_no = '" & cmbChargeTo1.Text & "'"
                cmd = New SqlCommand(publicquery, sqlcon.connection1)
                dr = cmd.ExecuteReader

                While dr.Read
                    charge_to_id1 = dr.Item(0).ToString
                End While
                dr.Close()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                sqlcon.connection1.Close()
            End Try

        ElseIf cmbTypeofCharge.Text = "PROJECT" Then
            Try
                'sqlcon.set_sql("192.168.1.92", "eus_031916", "sa", "adfil")
                'sqlcon.sql_connect()

                sqlcon.connection1.Open()
                publicquery = "SELECT proj_id FROM dbprojectdesc WHERE project_desc = '" & cmbChargeTo1.Text & "'"
                cmd = New SqlCommand(publicquery, sqlcon.connection1)
                dr = cmd.ExecuteReader

                While dr.Read
                    charge_to_id1 = dr.Item(0).ToString
                End While
                dr.Close()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                sqlcon.connection1.Close()
            End Try

        End If
    End Sub

    Private Sub cmbBrand_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBrand.SelectedIndexChanged
        Dim lof_id As Integer = get_lof_id()

        Dim query As String = "select TOP 1 a.no from dbfacilities_items a " & _
                              "INNER JOIN dbfacilities_list b " & _
                              "ON a.lof_id = b.lof_id " & _
                              "INNER JOIN dbfacilities_names c " & _
                              "ON b.fac_id = c.fac_id " & _
                              "WHERE c.facility_name = '" & Brand_cmbfac_name.Text & "' " & _
                              "ORDER BY [no] DESC"


        txtno.Text = get_specific_column_value(query, 1) + 1


    End Sub
    Public Function get_lof_id() As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_facilities", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 26)
            newCMD.Parameters.AddWithValue("@fac_name", Brand_cmbfac_name.Text)
            newCMD.Parameters.AddWithValue("@borrow_type", cmbFac_ToolsType.Text)
            newCMD.Parameters.AddWithValue("@brand", cmbBrand.Text)

            newDR = newCMD.ExecuteReader


            While newDR.Read
                get_lof_id = CInt(newDR.Item("lof_id").ToString)
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFac_ToolsType.SelectedIndexChanged
        If borrower_edit = 1 Then
            load_to_all_cmbox()
        ElseIf borrower_edit = 2 Then
            load_to_all_cmbox()
        Else
            load_to_all_cmbox()
        End If
    End Sub
End Class