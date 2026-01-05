Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Public Class FRequisition_Non_Item
    Public SQ As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Public public_query As String
    Dim txtbox As TextBox
    Public textname As String
    Dim tor_id As Integer
    Dim z As Integer
    Dim IsFormBeingDragged As Boolean
    Dim drag As Boolean
    Dim MouseDownX As Integer
    Dim MouseDownY As Integer
    Dim list_txtbox_loc As New List(Of String)
    Dim list_txtbox_unit As New List(Of String)
    Dim list_txtbox_requested_by As New List(Of String)
    Dim list_txtbox_noted_approved As New List(Of List(Of String))

    Public item_details_id As Integer = 0
    Public item_details_desc As String = ""
    Public Sub save_data_list_txtbox_noted_approved()
        Dim Row As Integer
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_Requisition_Non_Item"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 23)

            dr = sqlcomm.ExecuteReader
            While dr.Read
                list_txtbox_noted_approved.Add(New List(Of String))
                list_txtbox_noted_approved(Row).Add(dr.Item(0).ToString)
                list_txtbox_noted_approved(Row).Add(dr.Item(1).ToString)
                Row = Row + 1
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Sub load_list_list_txtbox_noted_approved()
        Dim row1 As New AutoCompleteStringCollection
        Dim row2 As New AutoCompleteStringCollection

        For Each item As List(Of String) In list_txtbox_noted_approved
            row1.Add(item(0))
            row2.Add(item(1))
        Next

        txtNotedBy.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtNotedBy.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtNotedBy.AutoCompleteCustomSource = row1

        txtApprovedby.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtApprovedby.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtApprovedby.AutoCompleteCustomSource = row2
    End Sub
    Public Sub save_data_txtbox(ByVal value As Integer, ByVal txtbox As List(Of String))
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_Requisition_Non_Item"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", value)

            dr = sqlcomm.ExecuteReader
            While dr.Read
                txtbox.Add(dr.Item(0).ToString)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Sub load_list_txtbox(ByVal obj As Object, ByVal txtbox As List(Of String))
        Dim row As New AutoCompleteStringCollection
        For Each item In txtbox
            row.Add(item)
        Next
        obj.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        obj.AutoCompleteSource = AutoCompleteSource.CustomSource
        obj.AutoCompleteCustomSource = row
    End Sub
    Private Sub FRequisition_Non_Item_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_type_of_request_and_sub(1, cmbRequestType, tor_id)
        load_type_of_charges_name()
        item_name(15)
        'save data for location
        save_data_txtbox(20, list_txtbox_loc)
        load_list_txtbox(txtLoc, list_txtbox_loc)
        'save data for unit
        save_data_txtbox(21, list_txtbox_unit)
        load_list_txtbox(txtUnit, list_txtbox_unit)

        load_list_txtbox(txtRequestBy, glb_list_personnel_hover) ' pop up
        load_list_txtbox(txtNotedBy, glb_list_personnel_hover) ' pop up
        load_list_txtbox(txtApprovedby, glb_list_personnel_hover) ' pop up
    End Sub
    Public Sub load_type_of_charges_name()
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_Requisition_Non_Item"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 13)
            dr = sqlcomm.ExecuteReader
            While dr.Read
                cmbTypeOfChargesName.Items.Add(dr.Item(0).ToString)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Sub load_type_of_request_and_sub(ByVal n As Integer, ByVal cbox As ComboBox, ByVal bypas_tor_id_or_tor_sub_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        cbox.Items.Clear()
        newSQ.connection.Open()
        Try
            Dim query As String
            If n = 1 Then
                query = "SELECT tor_desc FROM dbType_of_Request"
            ElseIf n = 2 Then
                query = "SELECT tor_sub_desc FROM dbType_of_Request_sub WHERE tor_id = " & bypas_tor_id_or_tor_sub_id
            ElseIf n = 4 Then
                query = "SELECT tor_sub_desc FROM dbType_of_Request_sub WHERE tor_sub_id IN (1,2,11)"
            End If

            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader
            While newDR.Read
                If n = 1 Then
                    cbox.Items.Add(newDR.Item("tor_desc").ToString)
                ElseIf n = 2 Then
                    cbox.Items.Add(newDR.Item("tor_sub_desc").ToString)
                ElseIf n = 4 Then
                    cbox.Items.Add(newDR.Item("tor_sub_desc").ToString)
                End If

            End While
            newDR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Public Sub load_charge_to(ByVal n As Integer, ByVal name As String)
        cmbTypeofCharge.Items.Clear()
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_charges_to"
            sqlcomm.CommandType = CommandType.StoredProcedure
            If n = 1 Then
                sqlcomm.Parameters.AddWithValue("@n", 1)
            ElseIf n = 2 Then
                sqlcomm.Parameters.AddWithValue("@n", 2)
            ElseIf n = 3 Then
                sqlcomm.Parameters.AddWithValue("@n", 3)
                sqlcomm.Parameters.AddWithValue("@type_name", name)
            ElseIf n = 6 Then
                sqlcomm.Parameters.AddWithValue("@n", 4)
            End If

            dr = sqlcomm.ExecuteReader
            While dr.Read
                If n = 1 Then
                    cmbTypeofCharge.Items.Add(dr.Item("project_desc").ToString)
                ElseIf n = 2 Then
                    cmbTypeofCharge.Items.Add(dr.Item("plate_no").ToString)
                ElseIf n = 3 Then
                    cmbTypeofCharge.Items.Add(dr.Item("charge_to").ToString)
                ElseIf n = 6 Then
                    cmbTypeofCharge.Items.Add(dr.Item("wh_area").ToString)
                End If
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Sub save_Requisition_Non_Item()
        'Dim item_name_id As Integer = get_contract_item_name_id(cmbItem_No.Text)
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_Requisition_Non_Item"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 1)
            sqlcomm.Parameters.AddWithValue("@rs_no", txtRSno.Text)
            sqlcomm.Parameters.AddWithValue("@date_req", DateTime.Parse(DTPReq.Text))
            sqlcomm.Parameters.AddWithValue("@job_order_no", txtJOno.Text)
            sqlcomm.Parameters.AddWithValue("@location", txtLoc.Text)
            sqlcomm.Parameters.AddWithValue("@item_desc", txtItemDesc.Text)
            sqlcomm.Parameters.AddWithValue("@qty", CDec(txtQty.Text))
            sqlcomm.Parameters.AddWithValue("@unit", txtUnit.Text)
            sqlcomm.Parameters.AddWithValue("@typeRequest", cmbRequestType.Text)
            sqlcomm.Parameters.AddWithValue("@purpose", txtPurpose.Text)
            sqlcomm.Parameters.AddWithValue("@date_needed", DateTime.Parse(DTPTimeNeeded.Text))
            sqlcomm.Parameters.AddWithValue("@requested_by", txtRequestBy.Text)
            sqlcomm.Parameters.AddWithValue("@noted_by", txtNotedBy.Text)
            sqlcomm.Parameters.AddWithValue("@approved_by", txtApprovedby.Text)
            sqlcomm.Parameters.AddWithValue("@IN_OUT", "OTHERS")
            sqlcomm.Parameters.AddWithValue("@date_log", Date.Now)
            sqlcomm.Parameters.AddWithValue("@type_of_purchasing", cmbCash_wrr_worr.Text)
            sqlcomm.Parameters.AddWithValue("@amount", txtAmount.Text)
            sqlcomm.Parameters.AddWithValue("@price", txtPrice.Text)
            sqlcomm.Parameters.AddWithValue("@wh_id", 0)
            sqlcomm.Parameters.AddWithValue("@user_id", pub_user_id)
            'sqlcomm.Parameters.AddWithValue("@contract_id", item_name_id)
            sqlcomm.Parameters.AddWithValue("@remarks_emd_purposed", txtRemarksForEmd.Text)
            z = sqlcomm.ExecuteScalar
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Sub Update_Requisition_Non_Item(ByVal rs_id As Integer)
        'Dim rs_id As Integer = CInt(lbl_rs_id.Text)
        'Dim item_name_id As Integer = get_contract_item_name_id(cmbItem_No.Text)
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_Requisition_Non_Item"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 10)
            sqlcomm.Parameters.AddWithValue("@rs_no", txtRSno.Text)
            sqlcomm.Parameters.AddWithValue("@date_req", DateTime.Parse(DTPReq.Text))
            sqlcomm.Parameters.AddWithValue("@job_order_no", txtJOno.Text)
            sqlcomm.Parameters.AddWithValue("@location", txtLoc.Text)
            sqlcomm.Parameters.AddWithValue("@item_desc", txtItemDesc.Text)
            sqlcomm.Parameters.AddWithValue("@qty", CDec(txtQty.Text))
            sqlcomm.Parameters.AddWithValue("@unit", txtUnit.Text)
            sqlcomm.Parameters.AddWithValue("@typeRequest", cmbRequestType.Text)
            sqlcomm.Parameters.AddWithValue("@purpose", txtPurpose.Text)
            sqlcomm.Parameters.AddWithValue("@date_needed", DateTime.Parse(DTPTimeNeeded.Text))
            sqlcomm.Parameters.AddWithValue("@requested_by", txtRequestBy.Text)
            sqlcomm.Parameters.AddWithValue("@noted_by", txtNotedBy.Text)
            sqlcomm.Parameters.AddWithValue("@approved_by", txtApprovedby.Text)
            sqlcomm.Parameters.AddWithValue("@IN_OUT", "OTHERS")
            'sqlcomm.Parameters.AddWithValue("@date_log", Date.Now)
            sqlcomm.Parameters.AddWithValue("@type_of_purchasing", cmbCash_wrr_worr.Text)

            Dim amount As Double = CDbl(txtQty.Text) * CDbl(txtPrice.Text)

            sqlcomm.Parameters.AddWithValue("@amount", amount)
            sqlcomm.Parameters.AddWithValue("@wh_id", 0)
            sqlcomm.Parameters.AddWithValue("@rs_id", rs_id)
            sqlcomm.Parameters.AddWithValue("@user_id", pub_user_id)
            'sqlcomm.Parameters.AddWithValue("@contract_id", item_name_id)
            sqlcomm.Parameters.AddWithValue("@date_update_log", Date.Now)
            sqlcomm.Parameters.AddWithValue("@remarks_emd_purposed", txtRemarksForEmd.Text)
            sqlcomm.Parameters.AddWithValue("@price", txtPrice.Text)
            sqlcomm.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Function getCodesInConsolidatedAccount(ByVal cmbText As String) As String
        Dim result As String = ""
        Dim input As String = cmbText
        ' Split by "("
        Dim parts() As String = input.Split("("c)

        ' Trim spaces and remove closing parenthesis if exists
        For i As Integer = 0 To parts.Length - 1
            parts(i) = parts(i).Trim().TrimEnd(")"c)
        Next

        Return parts(1)
    End Function
    Public Function getCategoryInConsolidatedAccount(ByVal cmbText As String) As String
        Dim result As String = ""
        Dim input As String = cmbText
        ' Split by "("
        Dim parts() As String = input.Split("["c)

        ' Trim spaces and remove closing parenthesis if exists
        For i As Integer = 0 To parts.Length - 1
            parts(i) = parts(i).Trim().TrimEnd("]"c)
        Next

        Return parts(0)
    End Function
    Public Sub save_rs_tor_sub_property(ByVal n As Integer, ByVal rs_id As Integer)
        Dim tor_id As Integer = get_tor_id(cmbRequestType.Text)
        Dim tor_sub_id As Integer = get_tor_sub_id(cmbTOR_sub.Text, tor_id)
        Dim tors_ca_id As Integer = 0

        If cmbAccountTitle.Text <> "" Then
            tors_ca_id = _getId_v1(2255, tor_sub_id, cmbAccountTitle.Text)
            'MsgBox("tors_ca_id " + CStr(tors_ca_id))
        End If

        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_Requisition_Non_Item"
            sqlcomm.CommandType = CommandType.StoredProcedure

            If n = 1 Then
                If cmbAccountTitle.Text <> "" Then
                    sqlcomm.Parameters.AddWithValue("@n", 26)
                    sqlcomm.Parameters.AddWithValue("@rs_id", rs_id)
                    sqlcomm.Parameters.AddWithValue("@tors_ca_id", tors_ca_id)
                    sqlcomm.ExecuteNonQuery()
                Else
                    sqlcomm.Parameters.AddWithValue("@n", 2)
                    sqlcomm.Parameters.AddWithValue("@rs_id", rs_id)
                    sqlcomm.Parameters.AddWithValue("@tor_sub_id", tor_sub_id)
                    sqlcomm.ExecuteNonQuery()
                End If

            ElseIf n = 2 Then
                If cmbAccountTitle.Text <> "" Then
                    sqlcomm.Parameters.AddWithValue("@n", 27)
                    sqlcomm.Parameters.AddWithValue("@rs_id", rs_id)
                    sqlcomm.Parameters.AddWithValue("@tors_ca_id", tors_ca_id)
                    sqlcomm.ExecuteNonQuery()
                Else
                    sqlcomm.Parameters.AddWithValue("@n", 11)
                    sqlcomm.Parameters.AddWithValue("@rs_id", rs_id)
                    sqlcomm.Parameters.AddWithValue("@tor_sub_id", tor_sub_id)
                    sqlcomm.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Sub save_multiCharges(ByVal n As Integer, ByVal rs_id As Integer)
        Dim bool_msgShow As Boolean = False
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_Requisition_Non_Item"
            sqlcomm.CommandType = CommandType.StoredProcedure
            If n = 1 Then
                sqlcomm.Parameters.AddWithValue("@n", 3)
                sqlcomm.Parameters.AddWithValue("@rs_id", rs_id)
                sqlcomm.Parameters.AddWithValue("@type_name", cmbTypeOfChargesName.Text)
            ElseIf n = 2 Then
                bool_msgShow = True
                sqlcomm.Parameters.AddWithValue("@n", 12)
                sqlcomm.Parameters.AddWithValue("@rs_id", rs_id)
                sqlcomm.Parameters.AddWithValue("@type_name", cmbTypeOfChargesName.Text)
            End If

            If cmbTypeOfChargesName.Text = "PROJECT" Then
                sqlcomm.Parameters.AddWithValue("@all_charges_id", get_id_charge_to(cmbTypeofCharge.Text, 1))
            ElseIf cmbTypeOfChargesName.Text = "EQUIPMENT" Then
                sqlcomm.Parameters.AddWithValue("@all_charges_id", get_id_charge_to(cmbTypeofCharge.Text, 2))
            ElseIf cmbTypeOfChargesName.Text = "WAREHOUSE" Then
                sqlcomm.Parameters.AddWithValue("@all_charges_id", connection_get_id_charge_to(cmbTypeOfChargesName.Text, cmbTypeofCharge.Text, 1))
            Else
                sqlcomm.Parameters.AddWithValue("@all_charges_id", connection_get_id_charge_to(cmbTypeOfChargesName.Text, cmbTypeofCharge.Text, 2))
            End If
            sqlcomm.ExecuteNonQuery()

            If bool_msgShow = False Then
                MessageBox.Show("Successfully Saved...", "SMS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Successfully Updated...", "SMS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            bool_msgShow = False
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Function get_id_charge_to(ByVal x As String, ByVal n As Integer) As Integer
        Try
            SQ.connection1.Open()
            Dim query As String
            If n = 1 Then
                query = "select proj_id from dbprojectdesc where project_desc = '" & x & "' "
            ElseIf n = 2 Then
                query = "select equipListID from dbequipment_list where plate_no = '" & x & "' "
            End If

            cmd = New SqlCommand(query, SQ.connection1)
            dr = cmd.ExecuteReader
            While dr.Read
                get_id_charge_to = dr.Item(0).ToString
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection1.Close()
        End Try
    End Function
    Public Function connection_get_id_charge_to(ByVal name As String, ByVal x As String, ByVal n As Integer) As Integer
        Dim newSQ As New SQLcon
        Try
            newSQ.connection.Open()
            Dim query1 As String
            If n = 1 Then
                query1 = "select wh_area_id from dbwh_area where wh_area = '" & x & "' "
            ElseIf n = 2 Then
                query1 = "select charge_to_id from dbCharge_to where charge_to = '" & x & "' and type_name = '" & name & "' "
            End If

            cmd = New SqlCommand(query1, newSQ.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                connection_get_id_charge_to = dr.Item(0).ToString
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Public Function get_tor_id(ByVal x As String) As Integer
        Try
            SQ.connection.Open()
            Dim query As String
            query = "select tor_id from dbType_of_Request where tor_desc = '" & x & "' "
            cmd = New SqlCommand(query, SQ.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                get_tor_id = dr.Item(0).ToString
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Function
    Public Function get_tor_sub_id(ByVal x As String, ByVal n As Integer) As Integer
        Try
            SQ.connection.Open()
            Dim query As String
            query = "select tor_sub_id from dbType_of_Request_sub where tor_id = '" & n & "' and tor_sub_desc = '" & x & "'  "
            cmd = New SqlCommand(query, SQ.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                get_tor_sub_id = dr.Item(0).ToString
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Function
    Public Sub item_name(ByVal n As Integer)
        'cmbItem_No.Items.Clear()
        Dim SQ1 As New SQLcon
        Dim CMD1 As New SqlCommand
        Dim DR As SqlDataReader
        Try
            SQ1.connection.Open()
            CMD1.Connection = SQ1.connection
            CMD1.CommandText = "sp_crud_Requisition_Non_Item"
            CMD1.CommandType = CommandType.StoredProcedure
            CMD1.Parameters.AddWithValue("@n", n)
            DR = CMD1.ExecuteReader
            While DR.Read
                'cmbItem_No.Items.Add(DR.Item("Item_name_no").ToString)
            End While
            DR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ1.connection.Close()
        End Try
    End Sub
    Public Sub cons_itemDesc(ByVal n As Integer, cmb As ComboBox)
        'cmbItemDesc.Items.Clear()
        Dim SQ2 As New SQLcon
        Dim CMD2 As New SqlCommand
        Dim DR2 As SqlDataReader
        Dim i As Integer = get_contract_item_name_id(cmb.Text)

        Try
            SQ2.connection.Open()
            CMD2.Connection = SQ2.connection
            CMD2.CommandText = "proc_Quantity_takeoff"
            CMD2.CommandType = CommandType.StoredProcedure
            CMD2.Parameters.AddWithValue("@n", n)
            CMD2.Parameters.AddWithValue("@id", i)
            DR2 = CMD2.ExecuteReader
            While DR2.Read
                'cmbItemDesc.Items.Add(DR2.Item("contract_item_desc").ToString)
            End While
            DR2.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ2.connection.Close()
        End Try
    End Sub
    Public Function get_contract_item_name_id(ByVal item As String) As Integer
        Dim SQ1 As New SQLcon
        Dim CMD1 As New SqlCommand
        Dim DR As SqlDataReader
        Try
            SQ1.connection.Open()
            CMD1.Connection = SQ1.connection
            CMD1.CommandText = "proc_Quantity_takeoff"
            CMD1.CommandType = CommandType.StoredProcedure
            CMD1.Parameters.AddWithValue("@n", 44)
            CMD1.Parameters.AddWithValue("@const_item_name", item)
            DR = CMD1.ExecuteReader
            While DR.Read
                get_contract_item_name_id = DR.Item(0).ToString
            End While
            DR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ1.connection.Close()
        End Try
    End Function
    Public Sub save_Contract_item_desc_save(ByVal x As String, ByVal y As String, ByVal z As Integer, ByVal n As Integer)
        Dim item_name_id As Integer = get_contract_item_name_id(x)
        Dim rs_id As Integer = z
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_Requisition_Non_Item"
            sqlcomm.CommandType = CommandType.StoredProcedure
            If n = 1 Then
                sqlcomm.Parameters.AddWithValue("@n", 16)
            ElseIf n = 2 Then
                sqlcomm.Parameters.AddWithValue("@n", 17)
            End If
            sqlcomm.Parameters.AddWithValue("@contract_item_name_id", item_name_id)
            sqlcomm.Parameters.AddWithValue("@contract_item_desc", y)
            sqlcomm.Parameters.AddWithValue("@rs_id", rs_id)
            sqlcomm.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Private Sub cmbRequestType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRequestType.SelectedIndexChanged
        cmbAccountTitle.Items.Clear()
        tor_id = get_id("dbType_of_Request", "tor_desc", cmbRequestType.Text, 0)
        viewCmb_v2(cmbTOR_sub, 29, tor_id)
    End Sub
    Private Sub cmbTypeOfChargesName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTypeOfChargesName.SelectedIndexChanged
        cmbTypeofCharge.Text = ""
        If cmbTypeOfChargesName.Text = "EQUIPMENT" Then
            load_charge_to(2, cmbTypeOfChargesName.Text)
        ElseIf cmbTypeOfChargesName.Text = "PROJECT" Then
            load_charge_to(1, cmbTypeOfChargesName.Text)
        ElseIf cmbTypeOfChargesName.Text = "WAREHOUSE" Then
            load_charge_to(6, cmbTypeOfChargesName.Text)
        Else
            load_charge_to(3, cmbTypeOfChargesName.Text)
        End If
    End Sub
    Public Function get_charge_cat_id(ByVal name As String) As Integer
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_Requisition_Non_Item"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 14)
            sqlcomm.Parameters.AddWithValue("@cat_name", name)
            dr = sqlcomm.ExecuteReader
            While dr.Read
                get_charge_cat_id = dr.Item(0).ToString
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim bool_accountTitle_hasItem As Boolean = False
        If cmbRequestType.Text = "" Or cmbTOR_sub.Text = "" Or cmbCash_wrr_worr.Text = "" Or txtItemDesc.Text = "" Or txtRSno.Text = "" Or cmbTypeOfChargesName.Text = "" Or cmbTypeofCharge.Text = "" Or txtLoc.Text = "" Or txtJOno.Text = "" Or txtQty.Text = "" Or txtUnit.Text = "" Or txtAmount.Text = "" Or txtPurpose.Text = "" Or txtRequestBy.Text = "" Or txtNotedBy.Text = "" Or txtApprovedby.Text = "" Or txtRemarksForEmd.Text = "" Or txtPrice.Text = "" Then
            MessageBox.Show("Field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            For Each ctrl As Control In Me.Controls
                If ctrl.Text = "" Then
                    ' MsgBox(objt.Text)
                    ctrl.Focus()
                End If
            Next
        Else
            If cmbAccountTitle.Items.Count > 0 Then ' pag naay sulod ang Account Title
                bool_accountTitle_hasItem = True
            End If

            If bool_accountTitle_hasItem = True And cmbAccountTitle.Text = "" Then
                MessageBox.Show("Please Select Account Title...", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbAccountTitle.Focus()
            Else
                If btnSave.Text = "Save" Then
                    If cmbTypeOfChargesName.Text.Equals("PROJECT") Or
                    cmbTypeOfChargesName.Text.Equals("Project") Or
                    cmbTypeOfChargesName.Text.Equals("project") Then
                        If item_details_id = 0 Then
                            frmQuanitityTakeOff.project_code = cmbTypeofCharge.Text
                            frmQuanitityTakeOff.ShowDialog()
                            If item_details_id = 0 Then
                                MsgBox("Not Saved, due to unselected Item No. from Project.")
                                Exit Sub
                            End If

                        End If

                    End If
                    save_Requisition_Non_Item()

                    If z <> 0 Then
                        If item_details_id <> 0 Then
                            insert_requisition_slip_item_details(item_details_id, z)
                        End If
                        save_rs_tor_sub_property(1, z)
                        save_multiCharges(1, z)
                    End If

                    'reload rs form : FRequesitionFormForDR.vb
                    FRequesitionFormForDR.getNewDrModel().cRsId = z
                    FRequesitionFormForDR.getNewDrModel().isCreateRsAndAddCharges = True

                    FRequesitionFormForDR.txtSearch.Text = txtRSno.Text
                    FRequesitionFormForDR.btnSearch.PerformClick()
                    Me.Dispose()

                ElseIf btnSave.Text = "Update" Then
                    If cmbTypeOfChargesName.Text.Equals("PROJECT") Or
                    cmbTypeOfChargesName.Text.Equals("Project") Or
                    cmbTypeOfChargesName.Text.Equals("project") Then
                        If item_details_id = 0 Then
                            frmQuanitityTakeOff.project_code = cmbTypeofCharge.Text
                            frmQuanitityTakeOff.ShowDialog()
                            If item_details_id = 0 Then
                                MsgBox("Not Saved, due to unselected Item No. from Project.")
                                Exit Sub
                            End If

                        End If

                    End If
                    Dim rs_id As Integer = CInt(lbl_rs_id.Text)
                    Update_Requisition_Non_Item(rs_id)
                    If item_details_id <> 0 Then
                        update_requisition_slip_item_details_non_item(item_details_id, rs_id)
                    End If
                    save_rs_tor_sub_property(2, rs_id)
                    save_multiCharges(2, rs_id)

                    'reload rs form : FRequesitionFormForDR.vb
                    FRequesitionFormForDR.getNewDrModel().cRsId = rs_id
                    FRequesitionFormForDR.getNewDrModel().isCreateRsAndAddCharges = True

                    FRequesitionFormForDR.txtSearch.Text = txtRSno.Text
                    FRequesitionFormForDR.btnSearch.PerformClick()
                    Me.Dispose()
                End If
            End If
            bool_accountTitle_hasItem = False

        End If
    End Sub
    Private Sub cmbRequestType_GotFocus(sender As Object, e As EventArgs) Handles cmbRequestType.GotFocus, cmbTOR_sub.GotFocus, txtItemDesc.GotFocus, cmbTypeOfChargesName.GotFocus, cmbTypeofCharge.GotFocus, txtLoc.GotFocus, DTPReq.GotFocus, txtJOno.GotFocus, txtQty.GotFocus, txtUnit.GotFocus, txtPurpose.GotFocus, DTPTimeNeeded.GotFocus, txtRequestBy.GotFocus, txtNotedBy.GotFocus, txtApprovedby.GotFocus, txtRSno.GotFocus, txtRemarksForEmd.GotFocus, txtAmount.GotFocus, txtPrice.GotFocus, cmbAccountTitle.GotFocus, cmbCash_wrr_worr.GotFocus
        sender.backcolor = Color.Yellow
    End Sub
    Private Sub cmbRequestType_Leave(sender As Object, e As EventArgs) Handles cmbRequestType.Leave, cmbTOR_sub.Leave, txtItemDesc.Leave, cmbTypeOfChargesName.Leave, cmbTypeofCharge.Leave, txtLoc.Leave, DTPReq.Leave, txtJOno.Leave, txtQty.Leave, txtUnit.Leave, txtPurpose.Leave, DTPTimeNeeded.Leave, txtRequestBy.Leave, txtNotedBy.Leave, txtApprovedby.Leave, txtRSno.Leave, txtRemarksForEmd.Leave, txtAmount.Leave, txtPrice.Leave, cmbAccountTitle.Leave, cmbCash_wrr_worr.Leave
        sender.backcolor = Color.White
    End Sub
    Private Sub txtLoc_TextChanged(sender As Object, e As EventArgs) Handles txtLoc.TextChanged, txtUnit.TextChanged, txtRequestBy.TextChanged, txtNotedBy.TextChanged, txtApprovedby.TextChanged
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
        list_txtbox_loc.Clear()
        list_txtbox_unit.Clear()
        list_txtbox_requested_by.Clear()
        list_txtbox_noted_approved.Clear()
    End Sub
    Private Sub txtLoc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLoc.KeyDown, txtUnit.KeyDown, txtRequestBy.KeyDown, txtNotedBy.KeyDown, txtApprovedby.KeyDown
    End Sub
    Private Sub FRequisition_Non_Item_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            btnSave.PerformClick()
        End If
    End Sub
    Private Sub pboxHeader_Click(sender As Object, e As EventArgs) Handles pboxHeader.Click
    End Sub
    Private Sub pboxHeader_MouseDown(sender As Object, e As MouseEventArgs) Handles pboxHeader.MouseDown
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
        End If
    End Sub
    Private Sub pboxHeader_Move(sender As Object, e As EventArgs) Handles pboxHeader.Move
    End Sub
    Private Sub pboxHeader_MouseUp(sender As Object, e As MouseEventArgs) Handles pboxHeader.MouseUp
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
    End Sub
    Private Sub pboxHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles pboxHeader.MouseMove
        If IsFormBeingDragged Then
            Dim temp As Point = New Point()

            temp.X = Me.Location.X + (e.X - MouseDownX)
            temp.Y = Me.Location.Y + (e.Y - MouseDownY)
            Me.Location = temp
            temp = Nothing
        End If
    End Sub
    Private Sub cmbTypeofCharge_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTypeofCharge.SelectedIndexChanged
        If cmbTypeOfChargesName.Text.Equals("PROJECT") Or
                cmbTypeOfChargesName.Text.Equals("Project") Or
                cmbTypeOfChargesName.Text.Equals("project") Then
            frmQuanitityTakeOff.project_code = cmbTypeofCharge.Text
            frmQuanitityTakeOff.ShowDialog()
            If item_details_id = 0 Then
                MsgBox("Please select Item No. First!")
            End If

        End If
    End Sub
    Private Sub txtUnit_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtUnit.PreviewKeyDown, txtLoc.PreviewKeyDown, txtRequestBy.PreviewKeyDown, txtNotedBy.PreviewKeyDown, txtApprovedby.PreviewKeyDown

    End Sub

    Private Sub txtJOno_TextChanged(sender As Object, e As EventArgs) Handles txtJOno.TextChanged
    End Sub
    Private Sub cmbCash_wrr_worr_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCash_wrr_worr.SelectedIndexChanged
        If cmbCash_wrr_worr.Text = "CASH WITHOUT RR" Then
            txtApprovedby.Text = "N/A"
            txtApprovedby.Enabled = False
        Else
            txtApprovedby.Enabled = True
        End If
    End Sub

    Private Sub cmbTypeofCharge_ParentChanged(sender As Object, e As EventArgs) Handles cmbTypeofCharge.ParentChanged

    End Sub
    Private Sub CmbtypeOfCharge_Leave(sender As Object, e As EventArgs) Handles cmbTypeofCharge.Leave
        If cmbTypeOfChargesName.Text = "PROJECT" Then
            Dim date_completion As DateTime = date_completion_1(cmbTypeofCharge.Text)
            Dim set_completion As String = set_completion_1(cmbTypeofCharge.Text)
            Dim final_date_completion As Date = date_completion.AddMonths(3)
            'MsgBox("date_completion " + date_completion)
            'MsgBox("set_completion " + set_completion)
            'MsgBox("final_date_completion " + final_date_completion)

            If set_completion = "Date Close" Then
                If Date.Now < final_date_completion Then
                    btnSave.Enabled = True
                Else
                    MessageBox.Show("This project is closed. You cannot save.", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    btnSave.Enabled = False
                End If
            Else
                btnSave.Enabled = True
            End If
        Else 'pag dili project
            btnSave.Enabled = True
        End If
    End Sub
    Private Function date_completion_1(ByVal value As String) As DateTime
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_charges_to"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 5)
            sqlcomm.Parameters.AddWithValue("@project_desc", value)

            dr = sqlcomm.ExecuteReader
            While dr.Read
                If String.IsNullOrEmpty(dr.Item("date_completion").ToString) Then

                Else
                    date_completion_1 = CDate(dr.Item("date_completion").ToString)
                End If
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Function

    Private Function set_completion_1(ByVal value As String) As String
        Dim result As String = ""
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_charges_to"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 6)
            sqlcomm.Parameters.AddWithValue("@project_desc", value)

            dr = sqlcomm.ExecuteReader
            While dr.Read
                result = dr.Item("set_completion").ToString
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
        set_completion_1 = result
    End Function

    Private Sub txtAmount_TextChanged(sender As Object, e As EventArgs) Handles txtAmount.TextChanged

    End Sub

    Private Sub txtRemarksForEmd_TextChanged(sender As Object, e As EventArgs) Handles txtRemarksForEmd.TextChanged

    End Sub

    Private Sub txtPrice_TextChanged(sender As Object, e As EventArgs) Handles txtPrice.TextChanged

    End Sub

    Private Sub txtPrice_Leave(sender As Object, e As EventArgs) Handles txtPrice.Leave
        If txtQty.Text <> "" And txtPrice.Text <> "" Then
            Dim amount As Double = CDbl(txtQty.Text) * CDbl(txtPrice.Text)
            txtAmount.Text = amount
        End If
    End Sub

    Private Sub txtQty_TextChanged(sender As Object, e As EventArgs) Handles txtQty.TextChanged

    End Sub

    Private Sub cmbTOR_sub_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTOR_sub.SelectedIndexChanged
        viewCmb(cmbAccountTitle, 2244, cmbRequestType.Text, cmbTOR_sub.Text)
    End Sub
    Public Sub viewCmb(ByVal cmb As Object, ByVal n As Integer, ByVal cmbTxt1 As String, Optional cmbTxt2 As String = "")
        cmb.items.clear()
        Dim SqlConn As New SQLcon
        Dim dr As SqlDataReader
        Try
            SqlConn.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SqlConn.connection
            sqlcomm.CommandText = "sp_crud_Requisition_Non_Item"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", n)
            sqlcomm.Parameters.AddWithValue("@value1", cmbTxt1)
            sqlcomm.Parameters.AddWithValue("@value2", cmbTxt2)

            dr = sqlcomm.ExecuteReader
            While dr.Read
                cmb.Items.Add(dr.Item(0).ToString)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SqlConn.connection.Close()
        End Try
    End Sub
    Public Sub viewCmb_v2(ByVal cmb As Object, ByVal n As Integer, ByVal valueId As Integer)
        cmb.items.clear()
        Dim SqlConn As New SQLcon
        Dim dr As SqlDataReader
        Try
            SqlConn.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SqlConn.connection
            sqlcomm.CommandText = "sp_crud_Requisition_Non_Item"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", n)
            sqlcomm.Parameters.AddWithValue("@valueID", valueId)

            dr = sqlcomm.ExecuteReader
            While dr.Read
                cmb.Items.Add(dr.Item(0).ToString)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SqlConn.connection.Close()
        End Try
    End Sub

    Public Function _getId_v1(ByVal n As Integer, ByVal valueID As Integer, Optional value As String = "") As Integer
        Dim Sql_conn As New SQLcon
        Dim dr As SqlDataReader

        Try
            Sql_conn.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = Sql_conn.connection
            sqlcomm.CommandText = "sp_crud_Requisition_Non_Item"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", n)
            sqlcomm.Parameters.AddWithValue("@valueID", valueID)
            sqlcomm.Parameters.AddWithValue("@value", value)
            dr = sqlcomm.ExecuteReader
            While dr.Read
                If String.IsNullOrEmpty(dr.Item(0).ToString) Then
                    _getId_v1 = 0
                Else
                    _getId_v1 = dr.Item(0).ToString
                End If
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sql_conn.connection.Close()
        End Try
        Return _getId_v1
    End Function
    Public Function _getValue(ByVal n As Integer, ByVal valueID As Integer) As String
        Dim Sql_conn As New SQLcon
        Dim dr As SqlDataReader
        Dim result As String = ""

        Try
            Sql_conn.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = Sql_conn.connection
            sqlcomm.CommandText = "sp_crud_Requisition_Non_Item"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", n)
            sqlcomm.Parameters.AddWithValue("@valueID", valueID)

            dr = sqlcomm.ExecuteReader
            While dr.Read
                result = dr.Item(0).ToString
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sql_conn.connection.Close()
        End Try
        Return result
    End Function


End Class