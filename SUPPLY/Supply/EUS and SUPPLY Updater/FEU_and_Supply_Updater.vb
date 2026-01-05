Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FEU_and_Supply_Updater
    Private Sub cmbTypeOfChargesName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTypeOfChargesName.SelectedIndexChanged
        cmbTypeofCharge.Text = ""

        cmbTypeofCharge.Items.Clear()

        If cmbTypeOfChargesName.Text = "EQUIPMENT" Then
            load_charge_to1(2, cmbTypeOfChargesName.Text)

        ElseIf cmbTypeOfChargesName.Text = "PROJECT" Then
            load_charge_to1(1, cmbTypeOfChargesName.Text)

        ElseIf cmbTypeOfChargesName.Text = "WAREHOUSE" Then
            load_charge_to1(6, cmbTypeOfChargesName.Text)

        ElseIf cmbTypeOfChargesName.Text = "PERSONAL" Or cmbTypeOfChargesName.Text = "MAINOFFICE" Or cmbTypeOfChargesName.Text = "OTHERS" Or cmbTypeOfChargesName.Text = "COMPANY" Or cmbTypeOfChargesName.Text = "DIVISION" Or cmbTypeOfChargesName.Text = "DEPARTMENT" Or cmbTypeOfChargesName.Text = "SECTION" Or cmbTypeOfChargesName.Text = "SHOPS" Or cmbTypeOfChargesName.Text = "MOBILE CRUSHER" Or cmbTypeOfChargesName.Text = "CRUSHER PLANT" Or cmbTypeOfChargesName.Text = "BATCHING PLANT" Or cmbTypeOfChargesName.Text = "WAREHOUSES" Or cmbTypeOfChargesName.Text = "FABRICATION" Or cmbTypeOfChargesName.Text = "BUNKHOUSE" Or cmbTypeOfChargesName.Text = "OTHERS_NEW" Then
            load_charge_to1(3, cmbTypeOfChargesName.Text)

            'ElseIf cmbTypeOfChargesName.Text = "MAINOFFICE" Then
            '    load_charge_to(4)

            'ElseIf cmbTypeOfChargesName.Text = "OTHERS" Or cmbTypeOfChargesName.Text = "COMPANY" Then
            '    load_charge_to(5)


        End If

    End Sub
    Private Sub load_charge_to1(ByVal n As Integer, ByVal name As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        cmbTypeofCharge1.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("sp_charges_to", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            If n = 1 Then
                newCMD.Parameters.AddWithValue("@n", 1)
            ElseIf n = 2 Then
                newCMD.Parameters.AddWithValue("@n", 2)
            ElseIf n = 3 Then
                newCMD.Parameters.AddWithValue("@n", 3)
                newCMD.Parameters.AddWithValue("@type_name", name)
            ElseIf n = 6 Then
                newCMD.Parameters.AddWithValue("@n", 4)

            End If

            newDR = newCMD.ExecuteReader
            While newDR.Read
                If n = 1 Then
                    cmbTypeofCharge.Items.Add(newDR.Item("project_desc").ToString)
                ElseIf n = 2 Then
                    cmbTypeofCharge.Items.Add(newDR.Item("plate_no").ToString)
                ElseIf n = 3 Then
                    cmbTypeofCharge.Items.Add(newDR.Item("charge_to").ToString)
                ElseIf n = 6 Then
                    cmbTypeofCharge.Items.Add(newDR.Item("wh_area").ToString)
                End If
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Private Sub load_charge_to2(ByVal n As Integer, ByVal name As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("sp_charges_to", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            If n = 1 Then
                newCMD.Parameters.AddWithValue("@n", 1)
            ElseIf n = 2 Then
                newCMD.Parameters.AddWithValue("@n", 2)
            ElseIf n = 3 Then
                newCMD.Parameters.AddWithValue("@n", 3)
                newCMD.Parameters.AddWithValue("@type_name", name)
            ElseIf n = 6 Then
                newCMD.Parameters.AddWithValue("@n", 4)

            End If

            newDR = newCMD.ExecuteReader
            While newDR.Read
                If n = 1 Then
                    cmbTypeofCharge1.Items.Add(newDR.Item("project_desc").ToString)
                ElseIf n = 2 Then
                    cmbTypeofCharge1.Items.Add(newDR.Item("plate_no").ToString)
                ElseIf n = 3 Then
                    cmbTypeofCharge1.Items.Add(newDR.Item("charge_to").ToString)
                ElseIf n = 6 Then
                    cmbTypeofCharge1.Items.Add(newDR.Item("wh_area").ToString)
                End If
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        If ComboBox1.Text = "EUS" Then
            search_eus()
        ElseIf ComboBox1.Text = "SUPPLY" Then
            search_supply()
        ElseIf ComboBox1.Text = "EQUIPMENT REQUEST" Then
            search_equipment_request()
        End If
    End Sub
    Private Sub search_equipment_request()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        ListView1.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_eus_supply_updater", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 5)
            newCMD.Parameters.AddWithValue("@project", cmbTypeofCharge.Text)
            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                a(0) = newDR.Item("req_ID").ToString
                a(2) = newDR.Item("typename").ToString
                a(3) = newDR.Item("charges").ToString

                Dim lvl As New ListViewItem(a)
                ListView1.Items.Add(lvl)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub search_supply()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        ListView1.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_eus_supply_updater", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 3)
            newCMD.Parameters.AddWithValue("@project", cmbTypeofCharge.Text)
            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                a(0) = newDR.Item("charges_id").ToString
                a(1) = newDR.Item("rs_id").ToString
                a(2) = newDR.Item("type_name").ToString
                a(3) = newDR.Item("charges").ToString

                Dim lvl As New ListViewItem(a)
                ListView1.Items.Add(lvl)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub search_eus()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        ListView1.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_eus_supply_updater", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 1)
            newCMD.Parameters.AddWithValue("@project", cmbTypeofCharge.Text)

            newCMD.CommandTimeout = 300

            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                a(0) = newDR.Item("eu_id").ToString
                a(1) = newDR.Item("project").ToString
                a(2) = newDR.Item("start_time").ToString
                a(3) = newDR.Item("end_time").ToString

                Dim lvl As New ListViewItem(a)
                ListView1.Items.Add(lvl)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTypeOfChargesName1.SelectedIndexChanged

        cmbTypeofCharge1.Items.Clear()

        If cmbTypeOfChargesName1.Text = "EQUIPMENT" Then
            load_charge_to2(2, cmbTypeOfChargesName1.Text)

        ElseIf cmbTypeOfChargesName1.Text = "PROJECT" Then
            load_charge_to2(1, cmbTypeOfChargesName1.Text)

        ElseIf cmbTypeOfChargesName1.Text = "WAREHOUSE" Then
            load_charge_to2(6, cmbTypeOfChargesName1.Text)

        ElseIf cmbTypeOfChargesName1.Text = "PERSONAL" Or cmbTypeOfChargesName1.Text = "MAINOFFICE" Or cmbTypeOfChargesName1.Text = "OTHERS" Or cmbTypeOfChargesName1.Text = "COMPANY" Or
            cmbTypeOfChargesName1.Text = "DIVISION" Or cmbTypeOfChargesName1.Text = "DEPARTMENT" Or cmbTypeOfChargesName1.Text = "SECTION" Or
            cmbTypeOfChargesName1.Text = "SHOPS" Or cmbTypeOfChargesName1.Text = "MOBILE CRUSHER" Or cmbTypeOfChargesName1.Text = "CRUSHER PLANT" Or
            cmbTypeOfChargesName1.Text = "BATCHING PLANT" Or cmbTypeOfChargesName1.Text = "WAREHOUSES" Or cmbTypeOfChargesName1.Text = "FABRICATION" Or
            cmbTypeOfChargesName1.Text = "BUNKHOUSE" Or cmbTypeOfChargesName1.Text = "OTHERS_NEW" Then
            load_charge_to2(3, cmbTypeOfChargesName1.Text)

            'ElseIf cmbTypeOfChargesName.Text = "MAINOFFICE" Then
            '    load_charge_to(4)

            'ElseIf cmbTypeOfChargesName.Text = "OTHERS" Or cmbTypeOfChargesName.Text = "COMPANY" Then
            '    load_charge_to(5)


        End If

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        If MessageBox.Show("Are you sure you want to update selected data?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then


            For Each row As ListViewItem In ListView1.Items
                If row.Checked = True Then
                    'update project from dbeu 
                    Select Case ComboBox1.Text
                        Case "EUS"
                            update_eu_project(row.Text)
                        Case "SUPPLY"
                            update_supply_charges(row.Text)
                        Case "EQUIPMENT REQUEST"
                            update_equipment_req_project(row.Text)
                    End Select
                End If
            Next

            MsgBox("successfully updated...")
        End If

    End Sub

    Private Sub update_supply_charges(charges_id As Integer)
        Dim all_charges_id As Integer

        If cmbTypeOfChargesName1.Text = "PROJECT" Then
            all_charges_id = FRequisition_Non_Item.get_id_charge_to(cmbTypeofCharge1.Text, 1)

        ElseIf cmbTypeOfChargesName1.Text = "EQUIPMENT" Then
            all_charges_id = FRequisition_Non_Item.get_id_charge_to(cmbTypeofCharge1.Text, 2)

        ElseIf cmbTypeOfChargesName1.Text = "WAREHOUSE" Then
            all_charges_id = FRequisition_Non_Item.connection_get_id_charge_to(cmbTypeOfChargesName1.Text, cmbTypeofCharge1.Text, 1)

        ElseIf cmbTypeOfChargesName1.Text = "PERSONAL" Or cmbTypeOfChargesName1.Text = "MAINOFFICE" Or cmbTypeOfChargesName1.Text = "OTHERS" Or
            cmbTypeOfChargesName1.Text = "COMPANY" Or cmbTypeOfChargesName1.Text = "DIVISION" Or cmbTypeOfChargesName1.Text = "DEPARTMENT" Or
            cmbTypeOfChargesName1.Text = "SECTION" Or cmbTypeOfChargesName1.Text = "SHOPS" Or cmbTypeOfChargesName1.Text = "MOBILE CRUSHER" Or
            cmbTypeOfChargesName1.Text = "CRUSHER PLANT" Or cmbTypeOfChargesName1.Text = "BATCHING PLANT" Or cmbTypeOfChargesName1.Text = "WAREHOUSES" Or
            cmbTypeOfChargesName1.Text = "FABRICATION" Or cmbTypeOfChargesName1.Text = "BUNKHOUSE" Or cmbTypeOfChargesName1.Text = "OTHERS_NEW" Then

            all_charges_id = FRequisition_Non_Item.connection_get_id_charge_to(cmbTypeOfChargesName1.Text, cmbTypeofCharge1.Text, 2)

        End If

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_eus_supply_updater", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 4)
            newCMD.Parameters.AddWithValue("@all_charges_id", all_charges_id)
            newCMD.Parameters.AddWithValue("@charges_id", charges_id)
            newCMD.Parameters.AddWithValue("@typename", cmbTypeOfChargesName1.Text)

            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Private Sub update_equipment_req_project(req_id As Integer)

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim all_charges_id As Integer = FRequisition_Non_Item.get_id_charge_to(cmbTypeofCharge1.Text, 1)
        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_eus_supply_updater", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 6)
            newCMD.Parameters.AddWithValue("@proj_id", all_charges_id)
            newCMD.Parameters.AddWithValue("@req_id", req_id)
            newCMD.Parameters.AddWithValue("@typename", cmbTypeOfChargesName1.Text)

            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub


    Private Sub update_eu_project(eu_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_eus_supply_updater", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 2)
            newCMD.Parameters.AddWithValue("@change_to_this_project", cmbTypeofCharge1.Text)
            newCMD.Parameters.AddWithValue("@eu_id", eu_id)
            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        For Each row As ListViewItem In ListView1.Items
            row.Checked = True
        Next
    End Sub

    Private Sub UnselectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnselectAllToolStripMenuItem.Click
        For Each row As ListViewItem In ListView1.Items
            row.Checked = False
        Next
    End Sub


End Class