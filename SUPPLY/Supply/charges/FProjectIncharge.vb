Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FProjectIncharge
    Public cmd As SqlCommand
    Public dr As SqlDataReader

    Dim cListOfLviewItem As New List(Of ListViewItem)
    Private cListOfAllCharges As New List(Of PropsFields.AllCharges)
    Public isFromRequestFields2 As Boolean

    Public cRsId As Integer

    Private customMsg As New customMessageBox
    Public ReadOnly Property getListOfAllCharges As List(Of PropsFields.AllCharges)
        Get
            Return cListOfAllCharges
        End Get
    End Property
    Private Sub FProjectIncharge_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub FProjectIncharge_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'load_all(lvlListofProject, 0)
        'load_all(lvlMainOffice, 1)
        'load_all(lvlWarehouse, 2)
        'load_all(lvlPersons, 3)
        lvlListofCharges.Items.Clear()
        cListOfAllCharges.Clear()

        load_type_of_charges()
        cmbTypeOfCharge.Focus()
    End Sub
    Private Sub load_type_of_charges()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        cmbTypeOfCharge.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_charges2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 1)
            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                cmbTypeOfCharge.Items.Add(newDR.Item("type_of_charges").ToString)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Public Sub load_all(ByVal obj As Object, ByVal n As Integer, ByVal typeofcharge As String)
        '0 - 'fProjectIncharge
        '1 - 'Fmaterial_Turnover_Fields

        Dim lvl As ListView
        Dim cmb As ComboBox
        cListOfAllCharges.Clear()

        If n = 0 Then
            lvl = obj
            lvl.Items.Clear()

        ElseIf n = 1 Then
            cmb = obj
            cmb.Items.Clear()

        End If

        Dim sqlcon As New SQLcon
        Dim SQ As New SQLcon

        Try

            If typeofcharge = "PROJECT" Then

                sqlcon.connection1.Open()

                publicquery = "SELECT * FROM dbprojectdesc ORDER BY project_desc ASC"
                cmd = New SqlCommand(publicquery, sqlcon.connection1)

            ElseIf typeofcharge = "EQUIPMENT" Then
                sqlcon.connection1.Open()

                publicquery = "SELECT * FROM dbequipment_list ORDER BY plate_no ASC"
                cmd = New SqlCommand(publicquery, sqlcon.connection1)

            ElseIf typeofcharge = "WAREHOUSE" Then

                If whouse_rs_selection = True Then
                    'warehouse
                    SQ.connection.Open()
                    publicquery = "SELECT * FROM dbwh_area ORDER BY wh_area ASC"
                    cmd = New SqlCommand(publicquery, SQ.connection)
                Else
                    FWarehouseArea.ShowDialog()
                    Exit Sub
                End If

            Else
                SQ.connection.Open()
                publicquery = "Select * FROM dbCharge_to WHERE type_name = '" & typeofcharge & "' ORDER BY charge_to ASC"
                cmd = New SqlCommand(publicquery, SQ.connection)
            End If

            dr = cmd.ExecuteReader

            While dr.Read
                Dim a(2) As String

                If typeofcharge = "PROJECT" Then
                    a(0) = dr.Item("proj_id").ToString
                    a(1) = UCase(dr.Item("project_desc").ToString)
                    a(2) = typeofcharge

                    addAllCharges(a(0), a(1), a(2))

                ElseIf typeofcharge = "WAREHOUSE" Then
                    a(0) = dr.Item("wh_area_id").ToString
                    a(1) = UCase(dr.Item("wh_area").ToString)
                    a(2) = typeofcharge

                    addAllCharges(a(0), a(1), a(2))

                ElseIf typeofcharge = "EQUIPMENT" Then
                    a(0) = dr.Item("equipListID").ToString
                    a(1) = UCase(dr.Item("plate_no").ToString)
                    a(2) = typeofcharge

                    addAllCharges(a(0), a(1), a(2))

                ElseIf typeofcharge = "SUPPLIER" Then
                    a(0) = dr.Item("Supplier_Id").ToString
                    a(1) = UCase(dr.Item("Supplier_Name").ToString)
                    a(2) = typeofcharge

                    addAllCharges(a(0), a(1), a(2))

                Else
                    a(0) = dr.Item("charge_to_id").ToString
                    a(1) = UCase(dr.Item("charge_to").ToString)
                    a(2) = typeofcharge

                    addAllCharges(a(0), a(1), a(2))
                End If


                If search_by(a(1), txtSearch.Text) = True Then
                Else
                    GoTo proceedhere
                End If

                If n = 0 Then
                    Dim lvllist As New ListViewItem(a)
                    lvl.Items.Add(lvllist)

                ElseIf n = 1 Then
                    cmb.Items.Add(a(1))
                End If

proceedhere:

            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If typeofcharge = "PROJECT" Or typeofcharge = "EQUIPMENT" Then
                sqlcon.connection1.Close()
            Else
                SQ.connection.Close()
            End If
        End Try
    End Sub

    Private Sub addAllCharges(charges_id As Integer, charges As String, charges_category As String)

        Dim _data As New PropsFields.AllCharges
        With _data
            .charges_id = charges_id
            .charges = charges
            .charges_category = charges_category

            cListOfAllCharges.Add(_data)
        End With

    End Sub

    Public Sub view_cmb(ByVal cmb As Object, ByVal n As Integer, Optional typeOfcharge As String = "")
        Dim cmb1 = cmb
        cmb1.items.clear()
        Dim Sql_conn As New SQLcon
        Dim dr As SqlDataReader
        Try
            Sql_conn.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = Sql_conn.connection
            sqlcomm.CommandText = "crud_charges"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", n)
            sqlcomm.Parameters.AddWithValue("@typeofcharge", typeOfcharge)

            dr = sqlcomm.ExecuteReader
            While dr.Read
                cmb1.Items.Add(dr.Item(0).ToString)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sql_conn.connection.Close()
        End Try
    End Sub

    Public Function get_specific_charges_name(ByVal typeofcharge As String, ByVal charge_id As Integer) As String
        Dim sqlcon As New SQLcon
        Dim SQ As New SQLcon

        Try

            If typeofcharge = "PROJECT" Then
                'sqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
                'sqlcon.sql_connect()
                sqlcon.connection1.Open()

                publicquery = "SELECT project_desc FROM dbprojectdesc WHERE proj_id = " & charge_id & " ORDER BY project_desc ASC"
                cmd = New SqlCommand(publicquery, sqlcon.connection1)

            ElseIf typeofcharge = "EQUIPMENT" Then

                'sqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
                'sqlcon.sql_connect()
                sqlcon.connection1.Open()

                publicquery = "SELECT plate_no FROM dbequipment_list WHERE equipListID = " & charge_id & " ORDER BY plate_no ASC"
                cmd = New SqlCommand(publicquery, sqlcon.connection1)

            ElseIf typeofcharge = "PERSONAL" Or typeofcharge = "MAINOFFICE" Or typeofcharge = "OTHERS" Then
                'main office
                SQ.connection.Open()
                publicquery = "SELECT charge_to FROM dbCharge_to WHERE type_name = '" & typeofcharge & "' AND charge_to_id = " & charge_id & " ORDER BY charge_to ASC"
                cmd = New SqlCommand(publicquery, SQ.connection)

            ElseIf typeofcharge = "WAREHOUSE" Then
                'warehouse
                SQ.connection.Open()
                publicquery = "SELECT wh_area FROM dbwh_area WHERE wh_area_id = " & charge_id & " ORDER BY wh_area ASC"
                cmd = New SqlCommand(publicquery, SQ.connection)

            End If

            dr = cmd.ExecuteReader

            While dr.Read

                If typeofcharge = "PROJECT" Then

                    get_specific_charges_name = UCase(dr.Item("project_desc").ToString)


                ElseIf typeofcharge = "MAINOFFICE" Then

                    get_specific_charges_name = UCase(dr.Item("charge_to").ToString)


                ElseIf typeofcharge = "WAREHOUSE" Then

                    get_specific_charges_name = UCase(dr.Item("wh_area").ToString)


                ElseIf typeofcharge = "PERSONAL" Then

                    get_specific_charges_name = UCase(dr.Item("charge_to").ToString)


                ElseIf typeofcharge = "EQUIPMENT" Then

                    get_specific_charges_name = UCase(dr.Item("plate_no").ToString)


                ElseIf typeofcharge = "OTHERS" Then

                    get_specific_charges_name = UCase(dr.Item("charge_to").ToString)

                End If

            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If typeofcharge = "PROJECT" Or typeofcharge = "EQUIPMENT" Then
                sqlcon.connection1.Close()
            Else
                SQ.connection.Close()

            End If

        End Try

    End Function

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim rowCompleted As Integer = 0

        If btnOk.Text = "Add Charges" Then
            If isFromRequestFields2 Then
                Dim n As Integer
                For Each row As ListViewItem In lvlListofCharges.Items
                    If row.Checked = True Then
                        Dim _charges As New PropsFields.AllCharges

                        With _charges
                            .charges_id = row.Text
                            .charges_category = row.SubItems(2).Text
                        End With

                        Dim createCharges As New CreateRequesitionSlipChargesServices
                        Dim id As Integer = createCharges.ExecuteWithReturnId(_charges, cRsId)

                        If id > 0 Then
                            n += 1
                        End If
                    End If
                Next

                If n = 0 Then
                    customMsg.message("error", "you have to check atleast 1 in the charges list...", "SUPPLY INFO:")
                Else
                    customMsg.message("info", "charges successfully created!", "SUPPLY INFO:")

                    If isFromRequestFields2 Then
                        FRequesitionFormForDR.getNewDrModel().cRsId = cRsId
                        FRequesitionFormForDR.getNewDrModel().isCreateRsAndAddCharges = True
                        FRequesitionFormForDR.txtSearch.Text = FCreateRSForm.txtRsNo.Text
                        FRequesitionFormForDR.btnSearch.PerformClick()
                        Me.Dispose()
                    End If

                End If
                Exit Sub
            End If
        End If


        For Each row As ListViewItem In lvlListofCharges.Items
            If row.Checked = True Then
                If row.ForeColor = Color.Red Then
                    MessageBox.Show(row.SubItems(1).Text & " has already completed..", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    row.Checked = False
                    rowCompleted += 1
                End If
            End If
        Next

        If rowCompleted > 0 Then
            Exit Sub
        End If

        If btnOk.Text = "OK" Then
            'from FRequestField -> FProjectIncharge
            If MessageBox.Show("Are you sure you want to insert this data?", "BORROWER INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                check_items(lvlListofCharges, pub_rs_id)
                Me.Dispose()
            End If

        ElseIf btnOk.Text = "UPDATE" Then
            'from FRequistionForm -> FProjectIncharge
            If MessageBox.Show("Are you sure you want to update this data?", "BORROWER INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim rs_id As Integer = CInt(FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text)
                Dim typename As String = cmbTypeOfCharge.Text


                If lbl_sign.Text = "R" Then
                    Dim query As String = "DELETE FROM dbMultipleCharges WHERE rs_id = " & CInt(rs_id) & " AND type_name = '" & typename & "'"
                    UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

                    check_items(lvlListofCharges, CInt(rs_id))
                    Me.Dispose()

                ElseIf lbl_sign.Text = "B" Then
                    Dim query As String = "DELETE FROM dbMultipleCharges WHERE rs_id = " & CInt(lbl_rs_id.Text) & " OR fi_id = " & CInt(FBorrowed_Item_Monitoring.lvList.SelectedItems(0).Text)
                    UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

                    check_items(lvlListofCharges, CInt(lbl_rs_id.Text))
                    Me.Dispose()

                End If

            End If

        ElseIf btnOk.Text = "Create Charges" Then

            'from FRequistionForm -> FProjectIncharge
            If MessageBox.Show("Are you sure you want to update charges of this data?", "BORROWER INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                For Each row As ListViewItem In FRequistionForm.lvlrequisitionlist.Items
                    If row.Selected = True Then
                        Dim rs_id As Integer = CInt(row.Text)
                        Dim typename As String = cmbTypeOfCharge.Text

                        If lbl_sign.Text = "R" Then
                            Dim query As String = "DELETE FROM dbMultipleCharges WHERE rs_id = " & CInt(rs_id) & " AND type_name = '" & typename & "'"
                            UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

                            check_items(lvlListofCharges, CInt(rs_id))

                        End If
                    End If
                Next

                FRequistionForm.btnSearch.PerformClick()
                listfocus(FRequistionForm.lvlrequisitionlist, rs_id)
                Me.Dispose()
            End If

        End If

        whouse_rs_selection = False

    End Sub

    Private Sub check_items(ByVal lvl As Object, ByVal rs_id As Integer)
        Dim listview As ListView = lvl
        Dim all_charges_id As Integer
        Dim type_name As String

        For Each row As ListViewItem In listview.Items
            If row.Checked = True Then
                If btnOk.Text = "OK" Then

                    all_charges_id = CInt(row.Text)
                    type_name = row.SubItems(2).Text
                    insert_into_dbmultiplecharges(all_charges_id, type_name, CInt(rs_id))

                ElseIf btnOk.Text = "Create Charges" Then
                    'Dim rs_id As Integer = CInt(FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text)

                    all_charges_id = CInt(row.Text)
                    type_name = row.SubItems(2).Text
                    insert_into_dbmultiplecharges(all_charges_id, type_name, CInt(rs_id))

                Else
                    'Dim rs_id As Integer = CInt(FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text)

                    all_charges_id = CInt(row.Text)
                    type_name = row.SubItems(2).Text
                    insert_into_dbmultiplecharges(all_charges_id, type_name, CInt(rs_id))

                End If

            End If
        Next

    End Sub
    Public Sub insert_into_dbmultiplecharges(ByVal all_charges_id As Integer, ByVal type_name As String, ByVal rs_id As Integer)

        If lbl_sign.Text = "B" Then
            Dim query As String = "INSERT INTO dbMultipleCharges(all_charges_id,type_name,rs_id,fi_id) VALUES(" & all_charges_id & ",'" & type_name & "'," & rs_id & "," & CInt(FBorrowed_Item_Monitoring.lvList.SelectedItems(0).Text) & ")"
            UPDATE_INSERT_DELETE_QUERY(query, 0, "INSERT")

        ElseIf lbl_sign.Text = "R" Then
            Dim query As String = "INSERT INTO dbMultipleCharges(all_charges_id,type_name,rs_id,fi_id) VALUES(" & all_charges_id & ",'" & type_name & "'," & rs_id & "," & 0 & ")"
            UPDATE_INSERT_DELETE_QUERY(query, 0, "INSERT")

        End If
    
    End Sub

    Public Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        lvlListofCharges.Items.Clear()
        load_all(lvlListofCharges, 0, "PROJECT")
        load_all(lvlListofCharges, 0, "MAINOFFICE")
        load_all(lvlListofCharges, 0, "PERSONAL")
        load_all(lvlListofCharges, 0, "EQUIPMENT")
        load_all(lvlListofCharges, 0, "WAREHOUSE")

        If Not isFromRequestFields2 Then
            item_checking()
        End If

    End Sub

    Private Sub cmbTypeOfCharge_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTypeOfCharge.SelectedIndexChanged
        'load_all(lvlListofCharges, 0, cmbTypeOfCharge.Text)

        If cmbTypeOfCharge.Text = "PROJECT" Then
            load_project(txtSearch.Text)
        Else
            load_all_type_of_charges(cmbTypeOfCharge.Text, txtSearch.Text)
        End If

        If Not isFromRequestFields2 Then
            item_checking()
        End If

    End Sub

    Private Sub load_project(search As String)
        cListOfLviewItem.Clear()
        lvlListofCharges.Items.Clear()

        Dim newProject As New class_project With {.proj_desc = search}

        With newProject
            .select_proj()

            For Each row In .cListOfProject
                Dim a(3) As String

                a(0) = row.proj_id
                a(1) = row.proj_desc.ToUpper
                a(2) = "PROJECT"

                Dim lvl As New ListViewItem(a)

                If row.days_left < 0 Then
                    If row.dateCloseOpen = "Date Close" Then
                        lvl.ForeColor = Color.Red
                    ElseIf row.dateCloseOpen = "Date Open" Then
                        lvl.ForeColor = Color.DarkGreen
                    End If
                Else
                    lvl.ForeColor = Color.Black
                End If
                cListOfLviewItem.Add(lvl)
            Next

            lvlListofCharges.Items.AddRange(cListOfLviewItem.ToArray)

        End With
    End Sub

    Private Sub load_all_type_of_charges(type_of_charges As String, searches As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        lvlListofCharges.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_charges1", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@typeofcharges", type_of_charges)
            newCMD.Parameters.AddWithValue("@search", searches)
            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                If UCase(newDR.Item("charges_desc").ToString) = "ADFIL LOT (NALCO)" Then
                    GoTo proceedhere
                ElseIf UCase(newDR.Item("charges_desc").ToString) = "ADFIL NALCO LEASING" Then
                    GoTo proceedhere
                    'ElseIf UCase(newDR.Item("charges_desc").ToString) = "ADFIL LOT NALCO" Then
                    ' GoTo proceedhere
                End If

                a(0) = newDR.Item("id").ToString
                a(1) = UCase(newDR.Item("charges_desc").ToString)
                a(2) = type_of_charges

                Dim lvl As New ListViewItem(a)
                lvlListofCharges.Items.Add(lvl)

proceedhere:

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub item_checking()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()



            If btnOk.Text = "OK" Then
                lbl_rs_id.Text = pub_rs_id
            Else
                Dim rs_id As Integer = CInt(FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text)
                lbl_rs_id.Text = rs_id
            End If


            Dim query As String = "SELECT * FROM dbMultipleCharges WHERE rs_id = " & lbl_rs_id.Text & " AND type_name = '" & cmbTypeOfCharge.Text & "'"

            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader
            Dim a(10) As String
            While newDR.Read

                Dim all_charges_id As Integer = CInt(newDR.Item("all_charges_id").ToString)
                Dim type_name As String = newDR.Item("type_name").ToString

                a(0) = all_charges_id

                'If type_name = "PROJECT" Then
                '    a(1) = GET_equip_desc_AND_proj_desc(all_charges_id, 2)
                'End If

                'a(2) = newDR.Item("type_name").ToString

                Dim checkInt As Integer = FindItem(lvlListofCharges, all_charges_id) 'DTPTripForDelete.Text)
                If checkInt <> -1 Then
                    lvlListofCharges.Items(checkInt).Checked = True
                End If

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()


        End Try
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

        'load_all(lvlListofCharges, 0, cmbTypeOfCharge.Text)

        If cmbTypeOfCharge.Text = "PROJECT" Then
            load_project(txtSearch.Text)
        Else
            load_all_type_of_charges(cmbTypeOfCharge.Text, txtSearch.Text)
        End If
        item_checking()
    End Sub

    Private Sub FProjectIncharge_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        whouse_rs_selection = False

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If MessageBox.Show("Are you sure you want to update charges from selected rows?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            With FRequistionForm
                For Each row As ListViewItem In .lvlrequisitionlist.Items
                    If row.Selected = True Then
                        If row.BackColor = Color.DarkGreen Then

                            Dim rs_id As Integer = row.Text

                            'delete first the charges
                            Dim query As String = "DELETE FROM dbMultipleCharges WHERE rs_id = " & CInt(rs_id) '& " AND type_name = '" & cmbTypeOfCharge.Text & "'"
                            UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

                            'get the selected charges
                            For Each row2 As ListViewItem In lvlListofCharges.Items
                                If row2.Checked = True Then
                                    'MsgBox("rs_id:" & rs_id & vbCrLf & "type name:" & cmbTypeOfCharge.Text & vbCrLf & "all charges id:" & row2.Text)
                                    update_charges(rs_id, cmbTypeOfCharge.Text, row2.Text)
                                End If
                            Next
                        End If
                    End If
                Next

                Me.Close()
                .btnSearch.PerformClick()
            End With

        End If

    End Sub

    Private Sub update_charges(rs_id As Integer, typeofcharges As String, all_charges_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_update_rs_charges", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 1)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.Parameters.AddWithValue("@typename", typeofcharges)
            newCMD.Parameters.AddWithValue("@all_charges_id", all_charges_id)

            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub lvlListofCharges_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvlListofCharges.SelectedIndexChanged
        For Each row As ListViewItem In lvlListofCharges.Items
            If row.Checked = True Then
                If row.ForeColor = Color.Red Then
                    MessageBox.Show(row.SubItems(1).Text & " has already completed..", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    row.Checked = False
                End If
            End If
        Next
    End Sub

    Private Sub FProjectIncharge_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Dispose()
    End Sub
End Class