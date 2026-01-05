Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FCreateCharges
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Public bs_status As String

    Private Sub FCreateCharges_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If check_if_exist("dbBorrower_charges", "bs_id", CInt(FBorrowed_Item_Monitoring.lvlBorrowerList.SelectedItems(0).Text), 1) > 0 Then
            btnSave.Text = "Update"
        End If

        lvlList.Items.Clear()


        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim bs_id As Integer = CInt(FBorrowed_Item_Monitoring.lvlBorrowerList.SelectedItems(0).Text)
        Dim counter As Integer = 0

        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT * FROM dbBorrower_charges WHERE bs_id = " & bs_id & " AND bs_status = '" & lbl_bs_status.Text & "'"
            newCMD = New SqlCommand(query, newSQ.connection)

            newDR = newCMD.ExecuteReader
            While newDR.Read
                counter += 1
            End While

            newDR.Close()

            If counter > 0 Then
                btnSave.Text = "Update"
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Sub

    Public Sub load_all(ByVal obj As Object, ByVal n As Integer)

        Dim lvl As ListView = obj

        Dim sqlcon As New SQLcon
        Dim SQ As New SQLcon

        Try

            If n = 0 Then
                'sqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
                'sqlcon.sql_connect()
                sqlcon.connection1.Open()

                publicquery = "SELECT * FROM dbprojectdesc ORDER BY project_desc ASC"
                cmd = New SqlCommand(publicquery, sqlcon.connection1)

            ElseIf n = 1 Then
                'main office
                SQ.connection.Open()
                publicquery = "SELECT * FROM dbCharge_to WHERE type_name = 'MAINOFFICE' ORDER BY charge_to ASC"
                cmd = New SqlCommand(publicquery, SQ.connection)
            ElseIf n = 2 Then
                'warehouse
                SQ.connection.Open()
                publicquery = "SELECT * FROM dbwh_area ORDER BY wh_area ASC"
                cmd = New SqlCommand(publicquery, SQ.connection)

            ElseIf n = 3 Then
                'persons
                SQ.connection.Open()
                publicquery = "SELECT * FROM dbCharge_to WHERE type_name = 'PERSONAL' ORDER BY charge_to ASC"
                cmd = New SqlCommand(publicquery, SQ.connection)

            ElseIf n = 4 Then
                'sqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
                'sqlcon.sql_connect()
                sqlcon.connection1.Open()

                publicquery = "SELECT * FROM dbequipment_list ORDER BY plate_no ASC"
                cmd = New SqlCommand(publicquery, sqlcon.connection1)

            ElseIf n = 5 Then
                'persons
                SQ.connection.Open()
                publicquery = "SELECT * FROM dbCharge_to WHERE type_name = 'OTHERS' ORDER BY charge_to ASC"
                cmd = New SqlCommand(publicquery, SQ.connection)

            End If

            dr = cmd.ExecuteReader

            While dr.Read
                Dim a(2) As String

                If n = 0 Then
                    a(0) = dr.Item("proj_id").ToString
                    a(1) = UCase(dr.Item("project_desc").ToString)
                    a(2) = "PROJECT"

                ElseIf n = 1 Then
                    a(0) = dr.Item("charge_to_id").ToString
                    a(1) = UCase(dr.Item("charge_to").ToString)
                    a(2) = "ADFIL"
                ElseIf n = 2 Then
                    a(0) = dr.Item("wh_area_id").ToString
                    a(1) = UCase(dr.Item("wh_area").ToString)
                    a(2) = "ADFIL"
                ElseIf n = 3 Then
                    a(0) = dr.Item("charge_to_id").ToString
                    a(1) = UCase(dr.Item("charge_to").ToString)
                    a(2) = "ADFIL"

                ElseIf n = 4 Then
                    a(0) = dr.Item("equipListID").ToString
                    a(1) = UCase(dr.Item("plate_no").ToString)
                    a(2) = "EQUIPMENT"

                ElseIf n = 5 Then
                    a(0) = dr.Item("charge_to_id").ToString
                    a(1) = UCase(dr.Item("charge_to").ToString)
                    a(2) = "ADFIL"

                End If

                Dim lvllist As New ListViewItem(a)
                lvl.Items.Add(lvllist)

            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If n = 0 Then
                sqlcon.connection1.Close()
            Else
                SQ.connection.Close()

            End If


        End Try
    End Sub

    Private Sub cmbTypeofCharge_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTypeofCharge.SelectedIndexChanged
        ''load_all(lvlListofProject, 0)
        ''load_all(lvlMainOffice, 1)
        ''load_all(lvlWarehouse, 2)
        ''load_all(lvlPersons, 3)


        FProjectIncharge.load_all(lvlList, 0, cmbTypeofCharge.Text)
        item_checking()


        'If cmbTypeofCharge.Text = "PROJECT" Then
        '    lvlList.Items.Clear()
        '    load_all(lvlList, 0)

        'ElseIf cmbTypeofCharge.Text = "ADFIL" Then
        '    lvlList.Items.Clear()
        '    load_all(lvlList, 1)
        '    load_all(lvlList, 3)
        '    load_all(lvlList, 5)

        'ElseIf cmbTypeofCharge.Text = "EQUIPMENT" Then
        '    lvlList.Items.Clear()
        '    load_all(lvlList, 4)

        'End If



    
    End Sub
    Private Sub item_checking()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()

            Dim bs_id As Integer = CInt(FBorrowed_Item_Monitoring.lvlBorrowerList.SelectedItems(0).Text)

            Dim query As String = "SELECT * FROM dbBorrower_charges WHERE bs_id = " & bs_id & " AND bs_status = '" & lbl_bs_status.Text & "'" '& " AND fi_id = " & CInt(lvList.SelectedItems(0).Text)

            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader
            Dim a(10) As String
            While newDR.Read

                Dim charges_id As Integer = CInt(newDR.Item("charge_id").ToString)
                Dim type_of_charges As String = newDR.Item("type_of_charges").ToString

                Dim checkInt As Integer = FindItem(lvlList, charges_id) 'DTPTripForDelete.Text)
                If checkInt <> -1 Then
                    lvlList.Items(checkInt).Checked = True
                End If

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        save_update_turnover_items()

    End Sub
    Public Sub save_update_turnover_items()

        If btnSave.Text = "Update" Then '
            Dim bs_id As Integer = CInt(FBorrowed_Item_Monitoring.lvlBorrowerList.SelectedItems(0).Text)

            'Dim query As String = "DELETE FROM dbBorrower_charges WHERE bs_id = " & bs_id & " AND type_of_charges = '" & cmbTypeofCharge.Text & "' AND bs_status = '" & lbl_bs_status.Text & "'"
            'UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

            'check_items(lvlList)
            'Me.Dispose()
            'FBorrowed_Item_Monitoring.btnSearch.PerformClick()


            Dim query As String = "DELETE FROM dbBorrower_charges WHERE bs_id = " & bs_id & " AND type_of_charges = '" & cmbTypeofCharge.Text & "' AND bs_status = '" & lbl_bs_status.Text & "'"
            UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

            If lbl_bs_status.Text = "Turnover" Then

                With FBorrower_Turnover
                    .lvlList.Items.Clear()
                    For Each row As ListViewItem In lvlList.Items
                        If row.Checked = True Then
                            Dim a(2) As String
                            a(0) = CInt(row.Text)
                            a(1) = row.SubItems(1).Text
                            a(2) = row.SubItems(2).Text

                            Dim lvl As New ListViewItem(a)
                            .lvlList.Items.Add(lvl)
                        End If
                    Next
                End With
            Else
                check_items(lvlList)
                FBorrowed_Item_Monitoring.btnSearch.PerformClick()
                listfocus(FBorrowed_Item_Monitoring.lvlBorrowerList, bs_id)
            End If
            Me.Dispose()

        ElseIf btnSave.Text = "Save" Then
            Dim bs_id As Integer = CInt(FBorrowed_Item_Monitoring.lvlBorrowerList.SelectedItems(0).Text)
            If lbl_bs_status.Text = "Turnover" Then

                With FBorrower_Turnover
                    .lvlList.Items.Clear()
                    For Each row As ListViewItem In lvlList.Items
                        If row.Checked = True Then
                            Dim a(2) As String
                            a(0) = CInt(row.Text)
                            a(1) = row.SubItems(1).Text
                            a(2) = row.SubItems(2).Text

                            Dim lvl As New ListViewItem(a)
                            .lvlList.Items.Add(lvl)
                        End If
                    Next
                End With

                Me.Dispose()

            Else
                check_items(lvlList)
                Me.Dispose()

                FBorrowed_Item_Monitoring.btnSearch.PerformClick()
                listfocus(FBorrowed_Item_Monitoring.lvlBorrowerList, bs_id)

            End If


        End If
    End Sub
    Private Sub check_items(ByVal lvl As Object)
        Dim listview As ListView = lvl
        Dim bs_id, charge_id As Integer
        Dim type_name As String

        For Each row As ListViewItem In listview.Items
            If row.Checked = True Then
                bs_id = CInt(FBorrowed_Item_Monitoring.lvlBorrowerList.SelectedItems(0).Text)
                charge_id = CInt(row.Text)
                type_name = row.SubItems(2).Text
                bs_status = lbl_bs_status.Text
                insert_into_dbborrower_charges(bs_id, charge_id, type_name, bs_status)
            End If
        Next

    End Sub
    Public Sub insert_into_dbborrower_charges(ByVal bs_id As Integer, ByVal charge_id As Integer, ByVal type_of_charges As String, ByVal bs_status As String)

        Dim query As String = "INSERT INTO dbBorrower_charges(bs_id,charge_id,type_of_charges,bs_status) VALUES(" & bs_id & "," & charge_id & ",'" & type_of_charges & "','" & bs_status & "')"
        UPDATE_INSERT_DELETE_QUERY(query, 0, "INSERT")

    End Sub
End Class