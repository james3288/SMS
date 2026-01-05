Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.Globalization
Public Class FLiquidationReport
    Public SQ As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Public public_query As String
    Dim txtbox As TextBox
    Public textname As String

    Dim tor_id As Integer
    Dim tor_sub_id As Integer
    Dim inout_id As Integer
    Dim tsp_id As Integer
    Dim z As Integer
    Dim w As Integer
    Dim list_liquidation_info As New List(Of List(Of String))

    Public item_details_id As Integer = 0
    Public item_details_desc As String = ""
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        lvlLiquidationReport.Enabled = True
        list_liquidation_info.Clear()
        Me.Close()
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
    Public Sub save_data_liquidation_info()
        Dim Row As Integer
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_LiquidationReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 20)

            dr = sqlcomm.ExecuteReader
            While dr.Read
                list_liquidation_info.Add(New List(Of String))
                list_liquidation_info(Row).Add(dr.Item("location").ToString)
                list_liquidation_info(Row).Add(dr.Item("unit").ToString)
                list_liquidation_info(Row).Add(dr.Item("amount").ToString)
                list_liquidation_info(Row).Add(dr.Item("item_name").ToString)
                list_liquidation_info(Row).Add(dr.Item("item_description").ToString)
                list_liquidation_info(Row).Add(dr.Item("purpose").ToString)
                Row = Row + 1
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Public Sub load_list_liquidation_info()
        Dim row As New AutoCompleteStringCollection
        Dim row1 As New AutoCompleteStringCollection
        Dim row2 As New AutoCompleteStringCollection
        Dim row3 As New AutoCompleteStringCollection
        Dim row4 As New AutoCompleteStringCollection
        Dim row5 As New AutoCompleteStringCollection


        For Each item As List(Of String) In list_liquidation_info
            '' MsgBox("test 1 : " & item(0) & " and test 2 : " & item(1))
            row.Add(item(0))
            row1.Add(item(1))
            row2.Add(item(2))
            row3.Add(item(3))
            row4.Add(item(4))
            row5.Add(item(5))
        Next
        txtLoc.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtLoc.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtLoc.AutoCompleteCustomSource = row

        txtUnit.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtUnit.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtUnit.AutoCompleteCustomSource = row1

        txtAmount.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtAmount.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtAmount.AutoCompleteCustomSource = row2

        txtItemName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtItemName.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtItemName.AutoCompleteCustomSource = row3

        txtItemDesc.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtItemDesc.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtItemDesc.AutoCompleteCustomSource = row4

        txtPurpose.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtPurpose.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtPurpose.AutoCompleteCustomSource = row5
    End Sub
    Public Sub load_list_txtbox(ByVal obj As TextBox, ByVal txtbox As List(Of String))
        Dim row As New AutoCompleteStringCollection
        For Each item In txtbox
            row.Add(item)
        Next
        obj.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        obj.AutoCompleteSource = AutoCompleteSource.CustomSource
        obj.AutoCompleteCustomSource = row
    End Sub
    Private Sub FLiquidationReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_type_of_request_and_sub(1, cmbRequestType, tor_id)
        load_type_of_charges_name_liquidation()
        load_list_txtbox(txtRequestBy, glb_list_personnel_hover) ' pop up
        load_list_txtbox(txtConducted_by, glb_list_personnel_hover) ' pop up
        save_data_liquidation_info()
        load_list_liquidation_info()

        '****for header column height****
        'Dim imgList As New ImageList()
        'imgList.ImageSize = New Size(1, 50) ' Width doesn’t matter much, height = 30px
        'lvlLiquidationReport.SmallImageList = imgList
        '********************************
        'lvlLiquidationReport.OwnerDraw = True
        DTPReq.Focus()
    End Sub
    Public Sub load_type_of_charges_name_liquidation()
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
    Public Sub load_type_of_charges_name()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        cmbTypeOfChargesName.Items.Clear()
        newSQ.connection.Open()
        Try
            Dim query As String
            query = "SELECT type_of_charges FROM dbType_of_charges"
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                cmbTypeOfChargesName.Items.Add(newDR.Item("type_of_charges").ToString)
            End While
            newDR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
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
            End If
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader
            While newDR.Read
                If n = 1 Then
                    cbox.Items.Add(newDR.Item("tor_desc").ToString)
                ElseIf n = 2 Then
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
    Private Sub txtTypeofCharge_TextChanged(sender As Object, e As EventArgs) Handles txtTypeofCharge.TextChanged
    End Sub
    Public Sub clear_field()
        ' cmbTypeofCharge.Text = Nothing
        'cmbRequestType.Text = Nothing
        'cmbTOR_sub.Text = Nothing
        'cmbtype_of_purchase.Text = Nothing
        'txtws_cash_voice.Text = ""
        'txtRSno.Text = ""
        'txtTypeofCharge.Text = ""
        'cmbTypeofCharge.Text = Nothing
        'txtLoc.Text = ""
        'txtJOno.Text = ""
        txtItemName.Text = ""
        txtItemDesc.Text = ""
        'txtQty.Text = ""
        'txtUnit.Text = ""
        txtAmount.Text = ""
        'txtConducted_by.Text = ""
        'txtPurpose.Text = ""
        'txtRequestBy.Text = ""
    End Sub
    Public Sub show_liquidation_report()
        lvlLiquidationReport.Items.Clear()
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_LiquidationReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 1)
            dr = sqlcomm.ExecuteReader
            While dr.Read
                Dim a(20) As String
                a(0) = dr.Item("id").ToString
                a(1) = Format(Date.Parse(dr.Item("date_request").ToString), "MM/dd/yyyy")
                a(2) = dr.Item("TYPE_OF_REQUEST").ToString & " - " & dr.Item("TYPE_OF_REQUEST_SUB").ToString
                ' a(3) = dr.Item("TYPE_OF_REQUEST_SUB").ToString
                a(3) = dr.Item("rs_no").ToString
                a(4) = dr.Item("CHARGE_TO").ToString
                a(5) = dr.Item("location").ToString
                a(6) = dr.Item("jo_no").ToString
                a(7) = dr.Item("item_description").ToString
                a(8) = dr.Item("quantity").ToString
                a(9) = dr.Item("unit").ToString
                a(10) = dr.Item("amount").ToString
                a(11) = dr.Item("purpose").ToString
                a(12) = Format(Date.Parse(dr.Item("date_needed").ToString), "MM/dd/yyyy")
                a(13) = dr.Item("requested_by").ToString

                Dim lvl As New ListViewItem(a)
                lvlLiquidationReport.Items.Add(lvl)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Sub save_liquidation_report()
        Dim tor_id As Integer = get_tor_id(cmbRequestType.Text)
        Dim tor_sub_id As Integer = get_tor_sub_id(cmbTOR_sub.Text, tor_id)
        Dim tors_ca_id As Integer = 0

        If cmbConsolidated_account.Text <> "" Then
            tors_ca_id = _getId_v1(2222, tor_sub_id, cmbConsolidated_account.Text)
        End If

        '  Try
        SQ.connection.Open()
        Dim sqlcomm As New SqlCommand

        sqlcomm.Connection = SQ.connection
        sqlcomm.CommandText = "sp_crud_LiquidationReport"
        sqlcomm.CommandType = CommandType.StoredProcedure
        sqlcomm.Parameters.AddWithValue("@n", 1001)
        sqlcomm.Parameters.AddWithValue("@date_request", DateTime.Parse(DTPReq.Text))
        sqlcomm.Parameters.AddWithValue("@type_of_request", tor_id)
        sqlcomm.Parameters.AddWithValue("@sub", tor_sub_id)

        If cmbConsolidated_account.Text <> "" Then
            sqlcomm.Parameters.AddWithValue("@tors_ca_id", tors_ca_id)
        Else
            sqlcomm.Parameters.AddWithValue("@tors_ca_id", DBNull.Value)
        End If

        sqlcomm.Parameters.AddWithValue("@type_of_purchasing", cmbtype_of_purchase.Text)
        If txtws_cash_voice.Text = "" Then
            sqlcomm.Parameters.AddWithValue("@ws_no_cash_invoice", "null")
        Else
            sqlcomm.Parameters.AddWithValue("@ws_no_cash_invoice", txtws_cash_voice.Text)
        End If
        sqlcomm.Parameters.AddWithValue("@rs_no", txtRSno.Text)
        sqlcomm.Parameters.AddWithValue("@type_of_charges", cmbTypeOfChargesName.Text)
        If cmbTypeOfChargesName.Text = "PROJECT" Then
            sqlcomm.Parameters.AddWithValue("@charge_to", get_id_charge_to(cmbTypeofCharge.Text, 1))
        ElseIf cmbTypeOfChargesName.Text = "EQUIPMENT" Then
            sqlcomm.Parameters.AddWithValue("@charge_to", get_id_charge_to(cmbTypeofCharge.Text, 2))
        ElseIf cmbTypeOfChargesName.Text = "WAREHOUSE" Then
            sqlcomm.Parameters.AddWithValue("@charge_to", connection_get_id_charge_to(cmbTypeOfChargesName.Text, cmbTypeofCharge.Text, 1))
        Else
            sqlcomm.Parameters.AddWithValue("@charge_to", connection_get_id_charge_to(cmbTypeOfChargesName.Text, cmbTypeofCharge.Text, 2))
        End If

        sqlcomm.Parameters.AddWithValue("@location", txtLoc.Text)
        sqlcomm.Parameters.AddWithValue("@jo_no", txtJOno.Text)
        sqlcomm.Parameters.AddWithValue("@item_name", txtItemName.Text)
        sqlcomm.Parameters.AddWithValue("@item_description", txtItemDesc.Text)
        sqlcomm.Parameters.AddWithValue("@quantity", CDbl(txtQty.Text))
        sqlcomm.Parameters.AddWithValue("@unit", txtUnit.Text)

        If cmbtype_of_purchase.Text = "WITHDRAWN" Then
            Dim n As Double
            n = CDbl(txtQty.Text) * CDbl(txtAmount.Text)
            sqlcomm.Parameters.AddWithValue("@amount", n)
        ElseIf cmbtype_of_purchase.Text = "CASH" Then
            sqlcomm.Parameters.AddWithValue("@amount", CDbl(txtAmount.Text))
        End If
        sqlcomm.Parameters.AddWithValue("@purpose", txtPurpose.Text)
        sqlcomm.Parameters.AddWithValue("@conducted_by", txtConducted_by.Text)
        sqlcomm.Parameters.AddWithValue("@date_needed", DateTime.Parse(DTPTimeNeeded.Text))
        sqlcomm.Parameters.AddWithValue("@requested_by", txtRequestBy.Text)
        sqlcomm.Parameters.AddWithValue("@date_log", Format(Date.Parse(Now), "yyyy-MM-dd"))
        sqlcomm.Parameters.AddWithValue("@userLog_id", pub_user_id)
        z = sqlcomm.ExecuteScalar
        MessageBox.Show("Successfully Saved...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ' Catch ex As Exception
        'MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '  Finally
        SQ.connection.Close()
        ' End Try
    End Sub
    Public Function get_id_supplier(ByVal x As String) As Integer
        Dim newSQ As New SQLcon
        Try
            newSQ.connection.Open()
            Dim query As String
            query = "select Supplier_Id from dbSupplier where Supplier_Name = '" & x & "' "
            cmd = New SqlCommand(query, newSQ.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                get_id_supplier = dr.Item(0).ToString
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Public Sub Update_liquidation_report()
        Dim tor_id As Integer = get_tor_id(cmbRequestType.Text)
        Dim tor_sub_id As Integer = get_tor_sub_id(cmbTOR_sub.Text, tor_id)
        Dim id As Integer = lvlLiquidationReport.SelectedItems(0).SubItems(0).Text
        Dim tors_ca_id As Integer = 0

        If cmbConsolidated_account.Text <> "" Then
            tors_ca_id = _getId_v1(2222, tor_sub_id, cmbConsolidated_account.Text)
        End If

        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_LiquidationReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 222)
            sqlcomm.Parameters.AddWithValue("@id", id)
            sqlcomm.Parameters.AddWithValue("@date_request", DateTime.Parse(DTPReq.Text))
            sqlcomm.Parameters.AddWithValue("@type_of_request", tor_id)
            sqlcomm.Parameters.AddWithValue("@sub", tor_sub_id)

            If cmbConsolidated_account.Text <> "" Then
                sqlcomm.Parameters.AddWithValue("@tors_ca_id", tors_ca_id)
            Else
                sqlcomm.Parameters.AddWithValue("@tors_ca_id", DBNull.Value)
            End If

            sqlcomm.Parameters.AddWithValue("@type_of_purchasing", cmbtype_of_purchase.Text)
            If txtws_cash_voice.Text = "" Then
                sqlcomm.Parameters.AddWithValue("@ws_no_cash_invoice", "null")
            Else
                sqlcomm.Parameters.AddWithValue("@ws_no_cash_invoice", txtws_cash_voice.Text)
            End If
            sqlcomm.Parameters.AddWithValue("@rs_no", txtRSno.Text)
            sqlcomm.Parameters.AddWithValue("@type_of_charges", cmbTypeOfChargesName.Text)
            If cmbTypeOfChargesName.Text = "PROJECT" Then
                sqlcomm.Parameters.AddWithValue("@charge_to", get_id_charge_to(cmbTypeofCharge.Text, 1))
            ElseIf cmbTypeOfChargesName.Text = "EQUIPMENT" Then
                sqlcomm.Parameters.AddWithValue("@charge_to", get_id_charge_to(cmbTypeofCharge.Text, 2))
            ElseIf cmbTypeOfChargesName.Text = "WAREHOUSE" Then
                sqlcomm.Parameters.AddWithValue("@charge_to", connection_get_id_charge_to(cmbTypeOfChargesName.Text, cmbTypeofCharge.Text, 1))
            Else
                sqlcomm.Parameters.AddWithValue("@charge_to", connection_get_id_charge_to(cmbTypeOfChargesName.Text, cmbTypeofCharge.Text, 2))
            End If
            sqlcomm.Parameters.AddWithValue("@location", txtLoc.Text)
            sqlcomm.Parameters.AddWithValue("@jo_no", txtJOno.Text)
            sqlcomm.Parameters.AddWithValue("@item_name", txtItemName.Text)
            sqlcomm.Parameters.AddWithValue("@item_description", txtItemDesc.Text)
            sqlcomm.Parameters.AddWithValue("@quantity", CDbl(txtQty.Text))
            sqlcomm.Parameters.AddWithValue("@unit", txtUnit.Text)
            If cmbtype_of_purchase.Text = "WITHDRAWN" Then
                Dim n As Double
                n = CDbl(txtQty.Text) * CDbl(txtAmount.Text)
                sqlcomm.Parameters.AddWithValue("@amount", n)
            ElseIf cmbtype_of_purchase.Text = "CASH" Then
                sqlcomm.Parameters.AddWithValue("@amount", CDbl(txtAmount.Text))
            End If
            sqlcomm.Parameters.AddWithValue("@purpose", txtPurpose.Text)
            sqlcomm.Parameters.AddWithValue("@conducted_by", txtConducted_by.Text)
            sqlcomm.Parameters.AddWithValue("@date_needed", DateTime.Parse(DTPTimeNeeded.Text))
            sqlcomm.Parameters.AddWithValue("@requested_by", txtRequestBy.Text)
            sqlcomm.Parameters.AddWithValue("@userUpdateLog_id", pub_user_id)
            sqlcomm.Parameters.AddWithValue("@userUpdateLog_Update", Date.Now)
            w = id
            sqlcomm.ExecuteNonQuery()
            MessageBox.Show("Successfully updated...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Sub Update_soft_delete(ByVal id As Integer)
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_LiquidationReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 19)
            sqlcomm.Parameters.AddWithValue("@id", id)
            sqlcomm.Parameters.AddWithValue("@status_soft_delete", "delete")
            sqlcomm.ExecuteNonQuery()
            'MessageBox.Show("Successfully Deleted...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Sub Update_status_cancel(ByVal id As Integer)
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_LiquidationReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 220)
            sqlcomm.Parameters.AddWithValue("@id", id)
            sqlcomm.Parameters.AddWithValue("@status_cancel", "Cancelled")
            sqlcomm.Parameters.AddWithValue("@cancelled_remarks", txtCancelledRemarks.Text)
            sqlcomm.ExecuteNonQuery()
            'MessageBox.Show("Successfully Deleted...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
    Public Function _getValue(ByVal n As Integer, ByVal valueID As Integer) As String
        Dim Sql_conn As New SQLcon
        Dim dr As SqlDataReader
        Dim result As String = ""

        Try
            Sql_conn.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = Sql_conn.connection
            sqlcomm.CommandText = "sp_crud_LiquidationReport"
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
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        If lvlLiquidationReport.SelectedItems.Count > 0 Then
            DTPReq.Text = lvlLiquidationReport.SelectedItems(0).SubItems(1).Text
            Dim s As String = lvlLiquidationReport.SelectedItems(0).SubItems(2).Text
            Dim value As String()
            value = s.Split("-")
            cmbRequestType.Text = value(0).Trim
            cmbTOR_sub.Text = value(1).Trim

            '****consolidated account****
            If lvlLiquidationReport.SelectedItems(0).SubItems(26).Text = "" Then
                cmbConsolidated_account.Text = ""
            Else
                Dim tors_ca_id As Integer = CInt(lvlLiquidationReport.SelectedItems(0).SubItems(26).Text)
                Dim accountTitle As String = _getValue(25, tors_ca_id)
                cmbConsolidated_account.Text = accountTitle
            End If
            '****************************

            cmbtype_of_purchase.Text = lvlLiquidationReport.SelectedItems(0).SubItems(4).Text
            Dim x As String = lvlLiquidationReport.SelectedItems(0).SubItems(5).Text
            Dim n As String()
            n = x.Split
            txtws_cash_voice.Text = n(2).Trim
            'cmbConsolidated_account.Text = lvlLiquidationReport.SelectedItems(0).SubItems(3).Text.Trim
            txtRSno.Text = lvlLiquidationReport.SelectedItems(0).SubItems(6).Text
            cmbTypeOfChargesName.Text = lvlLiquidationReport.SelectedItems(0).SubItems(7).Text
            cmbTypeofCharge.Text = lvlLiquidationReport.SelectedItems(0).SubItems(8).Text
            txtLoc.Text = lvlLiquidationReport.SelectedItems(0).SubItems(9).Text
            txtJOno.Text = lvlLiquidationReport.SelectedItems(0).SubItems(10).Text
            txtItemName.Text = lvlLiquidationReport.SelectedItems(0).SubItems(11).Text
            txtItemDesc.Text = lvlLiquidationReport.SelectedItems(0).SubItems(12).Text
            txtQty.Text = lvlLiquidationReport.SelectedItems(0).SubItems(13).Text
            txtUnit.Text = lvlLiquidationReport.SelectedItems(0).SubItems(14).Text
            If cmbtype_of_purchase.Text = "WITHDRAWN" Then
                Dim u As Double
                u = CDbl(lvlLiquidationReport.SelectedItems(0).SubItems(15).Text) / CDbl(lvlLiquidationReport.SelectedItems(0).SubItems(13).Text)
                txtAmount.Text = u
            ElseIf cmbtype_of_purchase.Text = "CASH" Then
                txtAmount.Text = lvlLiquidationReport.SelectedItems(0).SubItems(15).Text
            End If
            txtPurpose.Text = lvlLiquidationReport.SelectedItems(0).SubItems(16).Text
            txtConducted_by.Text = lvlLiquidationReport.SelectedItems(0).SubItems(17).Text
            DTPTimeNeeded.Text = lvlLiquidationReport.SelectedItems(0).SubItems(18).Text
            txtRequestBy.Text = lvlLiquidationReport.SelectedItems(0).SubItems(19).Text
            btnSave.Text = "Update"
            cmbRequestType.Focus()
            lvlLiquidationReport.Enabled = False
        End If
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim ex = MessageBox.Show("Are you sure u want to DELETE the SELECTED items?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If ex = MsgBoxResult.Yes Then
            For Each row As ListViewItem In lvlLiquidationReport.SelectedItems
                'Delete_LiquidationReport(row.SubItems(0).Text)
                Update_soft_delete(row.SubItems(0).Text)
                row.Remove()
                ' MsgBox(row.SubItems(0).Text)
            Next
            MessageBox.Show("Successfully Deleted...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Public Sub Delete_LiquidationReport(ByVal x As Integer)
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_LiquidationReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 3)
            sqlcomm.Parameters.AddWithValue("id", x)
            sqlcomm.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Private Sub cmbSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearch.SelectedIndexChanged
        If cmbSearch.Text = "Date Request" Then
            Panel_date_duration.Visible = True
            txtSearch.Enabled = False
            btnSearch.Enabled = True
            DTP_search_liquidation.Visible = False
            TotalLitersToolStripMenuItem.Enabled = False
            ExportToExcelToolStripMenuItem.Enabled = True
        ElseIf cmbSearch.Text = "Type of Request" Then
            txtSearch.Enabled = True
            btnSearch.Enabled = True
            txtSearch.Focus()
            Panel_date_duration.Visible = False
            DTP_search_liquidation.Visible = False
            TotalLitersToolStripMenuItem.Enabled = False
            ExportToExcelToolStripMenuItem.Enabled = True
        ElseIf cmbSearch.Text = "Rs no." Then
            txtSearch.Enabled = True
            btnSearch.Enabled = True
            txtSearch.Focus()
            Panel_date_duration.Visible = False
            DTP_search_liquidation.Visible = False
            TotalLitersToolStripMenuItem.Enabled = False
            ExportToExcelToolStripMenuItem.Enabled = True
        ElseIf cmbSearch.Text = "Charge to" Then
            txtSearch.Enabled = True
            btnSearch.Enabled = False
            txtSearch.Focus()
            Panel_date_duration.Visible = True
            DTP_search_liquidation.Visible = False
            TotalLitersToolStripMenuItem.Enabled = False
            ExportToExcelToolStripMenuItem.Enabled = True
        ElseIf cmbSearch.Text = "Location" Then
            txtSearch.Enabled = True
            btnSearch.Enabled = True
            txtSearch.Focus()
            Panel_date_duration.Visible = False
            DTP_search_liquidation.Visible = False
            TotalLitersToolStripMenuItem.Enabled = False
            ExportToExcelToolStripMenuItem.Enabled = True
        ElseIf cmbSearch.Text = "Jo no." Then
            txtSearch.Enabled = True
            btnSearch.Enabled = True
            txtSearch.Focus()
            Panel_date_duration.Visible = False
            DTP_search_liquidation.Visible = False
            TotalLitersToolStripMenuItem.Enabled = False
            ExportToExcelToolStripMenuItem.Enabled = True
        ElseIf cmbSearch.Text = "Item Description" Then
            txtSearch.Enabled = True
            btnSearch.Enabled = False
            TotalLitersToolStripMenuItem.Enabled = True
            ExportToExcelToolStripMenuItem.Enabled = True
            txtSearch.Focus()
            Panel_date_duration.Visible = True
            DTP_search_liquidation.Visible = False
        ElseIf cmbSearch.Text = "Date" Then
            DTP_search_liquidation.Location = New Point(txtSearch.Bounds.Left, txtSearch.Bounds.Top)
            DTP_search_liquidation.Parent = GroupBox1
            DTP_search_liquidation.Visible = True
            DTP_search_liquidation.BringToFront()
            Panel_date_duration.Visible = False
            TotalLitersToolStripMenuItem.Enabled = False
            ExportToExcelToolStripMenuItem.Enabled = True
            btnSearch.Enabled = True
            ' txtSearch.Visible = False
        ElseIf cmbSearch.Text = "Type of Purchase" Then
            txtSearch.Enabled = True
            btnSearch.Enabled = True
            txtSearch.Focus()
            Panel_date_duration.Visible = False
            DTP_search_liquidation.Visible = False
            TotalLitersToolStripMenuItem.Enabled = False
            ExportToExcelToolStripMenuItem.Enabled = True
        ElseIf cmbSearch.Text = "Ws or Cv" Then
            txtSearch.Enabled = True
            btnSearch.Enabled = True
            txtSearch.Focus()
            Panel_date_duration.Visible = False
            DTP_search_liquidation.Visible = False
            TotalLitersToolStripMenuItem.Enabled = False
            ExportToExcelToolStripMenuItem.Enabled = True
        ElseIf cmbSearch.Text = "Item Name" Then
            txtSearch.Enabled = True
            btnSearch.Enabled = True
            txtSearch.Focus()
            Panel_date_duration.Visible = False
            DTP_search_liquidation.Visible = False
            TotalLitersToolStripMenuItem.Enabled = False
            ExportToExcelToolStripMenuItem.Enabled = True
        ElseIf cmbSearch.Text = "Type of Charges" Then
            txtSearch.Enabled = True
            btnSearch.Enabled = True
            txtSearch.Focus()
            Panel_date_duration.Visible = False
            DTP_search_liquidation.Visible = False
            TotalLitersToolStripMenuItem.Enabled = False
            ExportToExcelToolStripMenuItem.Enabled = True
        End If
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If cmbSearch.Text = "Date Request" Then
            search_LiquidationReport(0)
        ElseIf cmbSearch.Text = "Type of Request" Then
            search_LiquidationReport(1)
        ElseIf cmbSearch.Text = "Rs no." Then
            search_LiquidationReport(2)
        ElseIf cmbSearch.Text = "Charge to" Then
            search_LiquidationReport(3)
        ElseIf cmbSearch.Text = "Location" Then
            search_LiquidationReport(4)
        ElseIf cmbSearch.Text = "Jo no." Then
            search_LiquidationReport(5)
        ElseIf cmbSearch.Text = "Item Description" Then
            Panel_date_duration.Visible = True
            'search_LiquidationReport(6)
        ElseIf cmbSearch.Text = "Date" Then
            search_LiquidationReport(7)
        ElseIf cmbSearch.Text = "Type of Purchase" Then
            search_LiquidationReport(8)
        ElseIf cmbSearch.Text = "Ws or Cv" Then
            search_LiquidationReport(9)
        ElseIf cmbSearch.Text = "Item Name" Then
            search_LiquidationReport(10)
        ElseIf cmbSearch.Text = "Type of Charges" Then
            search_LiquidationReport(11)
        End If
    End Sub
    Public Sub search_LiquidationReport(ByVal n As Integer)
        lvlLiquidationReport.Items.Clear()
        Dim row As Integer = 0
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_LiquidationReport"
            sqlcomm.CommandType = CommandType.StoredProcedure

            If n = 0 Then
                sqlcomm.Parameters.AddWithValue("@n", 1111)
                sqlcomm.Parameters.AddWithValue("@date_from", DateTime.Parse(DtpickerFrom.Text))
                sqlcomm.Parameters.AddWithValue("@date_to", DateTime.Parse(DTP_to.Text))
                sqlcomm.Parameters.AddWithValue("@sys_search", "Date Request")
            ElseIf n = 1 Then
                sqlcomm.Parameters.AddWithValue("@n", 1111)
                sqlcomm.Parameters.AddWithValue("@TYPE_OF_REQUEST1", txtSearch.Text)
                sqlcomm.Parameters.AddWithValue("@sys_search", "Type of Request")
            ElseIf n = 2 Then
                sqlcomm.Parameters.AddWithValue("@n", 1111)
                sqlcomm.Parameters.AddWithValue("@rs_no", txtSearch.Text)
                sqlcomm.Parameters.AddWithValue("@sys_search", "Rs no.")
            ElseIf n = 3 Then
                sqlcomm.Parameters.AddWithValue("@n", 777)
                sqlcomm.Parameters.AddWithValue("@CHARGE_TO1", txtSearch.Text)
                sqlcomm.Parameters.AddWithValue("@date_from", DateTime.Parse(DtpickerFrom.Text))
                sqlcomm.Parameters.AddWithValue("@date_to", DateTime.Parse(DTP_to.Text))
            ElseIf n = 4 Then
                sqlcomm.Parameters.AddWithValue("@n", 1111)
                sqlcomm.Parameters.AddWithValue("@location", txtSearch.Text)
                sqlcomm.Parameters.AddWithValue("@sys_search", "Location")
            ElseIf n = 5 Then
                sqlcomm.Parameters.AddWithValue("@n", 1111)
                sqlcomm.Parameters.AddWithValue("@jo_no", txtSearch.Text)
                sqlcomm.Parameters.AddWithValue("@sys_search", "Jo no.")
            ElseIf n = 6 Then
                sqlcomm.Parameters.AddWithValue("@n", 1444)
                sqlcomm.Parameters.AddWithValue("@item_description", txtSearch.Text)
                sqlcomm.Parameters.AddWithValue("@date_from", DateTime.Parse(DtpickerFrom.Text))
                sqlcomm.Parameters.AddWithValue("@date_to", DateTime.Parse(DTP_to.Text))
                sqlcomm.Parameters.AddWithValue("@sys_search", "Item Description")
            ElseIf n = 7 Then
                sqlcomm.Parameters.AddWithValue("@n", 1111)
                sqlcomm.Parameters.AddWithValue("@date_search", DateTime.Parse(DTP_search_liquidation.Text))
                sqlcomm.Parameters.AddWithValue("@sys_search", "Date")
            ElseIf n = 8 Then
                sqlcomm.Parameters.AddWithValue("@n", 1111)
                sqlcomm.Parameters.AddWithValue("@type_of_purchasing", txtSearch.Text)
                sqlcomm.Parameters.AddWithValue("@sys_search", "Type of Purchase")
            ElseIf n = 9 Then
                sqlcomm.Parameters.AddWithValue("@n", 1111)
                sqlcomm.Parameters.AddWithValue("@ws_no_cash_invoice", txtSearch.Text)
                sqlcomm.Parameters.AddWithValue("@sys_search", "Ws or Cv")
            ElseIf n = 10 Then
                sqlcomm.Parameters.AddWithValue("@n", 1444)
                sqlcomm.Parameters.AddWithValue("@item_name", txtSearch.Text)
                sqlcomm.Parameters.AddWithValue("@sys_search", "Item Name")
            ElseIf n = 11 Then
                sqlcomm.Parameters.AddWithValue("@n", 1444)
                sqlcomm.Parameters.AddWithValue("@type_of_charges", txtSearch.Text)
                sqlcomm.Parameters.AddWithValue("@sys_search", "Type of Charges")
            End If

            dr = sqlcomm.ExecuteReader
            While dr.Read
                Dim a(26) As String
                a(0) = dr.Item("id").ToString
                a(1) = Format(Date.Parse(dr.Item("date_request").ToString), "MM/dd/yyyy")
                a(2) = dr.Item("TYPE_OF_REQUEST").ToString & " - " & dr.Item("TYPE_OF_REQUEST_SUB").ToString
                a(3) = dr.Item("consolidated_title").ToString
                a(4) = dr.Item("type_of_purchasing").ToString
                If dr.Item("type_of_purchasing").ToString = "CASH" Then
                    a(5) = "CV # " + dr.Item("ws_no_or_cash_invoice").ToString
                ElseIf dr.Item("type_of_purchasing").ToString = "WITHDRAWN" Then
                    a(5) = "WS # " + dr.Item("ws_no_or_cash_invoice").ToString
                End If
                a(6) = dr.Item("rs_no").ToString
                a(7) = dr.Item("type_of_charges").ToString
                a(8) = dr.Item("CHARGE_TO").ToString
                a(9) = dr.Item("location").ToString
                a(10) = dr.Item("jo_no").ToString
                a(11) = dr.Item("item_name").ToString
                a(12) = dr.Item("item_description").ToString
                a(13) = dr.Item("quantity").ToString
                a(14) = dr.Item("unit").ToString
                a(15) = FormatNumber(dr.Item("amount").ToString, 2)
                'a(15) = dr.Item("SUPPLIER").ToString
                'a(16) = dr.Item("rs_id").ToString
                a(16) = dr.Item("purpose").ToString
                a(17) = dr.Item("conducted_by").ToString
                a(18) = Format(Date.Parse(dr.Item("date_needed").ToString), "MM/dd/yyyy")
                a(19) = dr.Item("requested_by").ToString
                a(20) = dr.Item("complete_name").ToString
                a(21) = Format(Date.Parse(dr.Item("date_log").ToString), "MM/dd/yyyy")
                a(22) = dr.Item("UserLog_Update").ToString
                a(23) = dr.Item("userUpdateLog_Update").ToString
                'a(22) = Format(Date.Parse(dr.Item("userUpdateLog_Update").ToString), "MM/dd/yyyy")
                a(24) = dr.Item("status_cancel").ToString
                a(25) = dr.Item("cancelled_remarks").ToString
                a(26) = dr.Item("tors_ca_id").ToString

                Dim lvl As New ListViewItem(a)
                lvlLiquidationReport.Items.Add(lvl)

                If lvlLiquidationReport.Items(row).SubItems(24).Text = "Cancelled" Then
                    lvlLiquidationReport.Items(row).BackColor = Color.OrangeRed
                    lvlLiquidationReport.Items(row).ForeColor = Color.White
                End If

                row += 1 'for row para sa cancelled color
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Private Sub btnSearchDuration_Click(sender As Object, e As EventArgs) Handles btnSearchDuration.Click
        If cmbSearch.Text = "Item Description" Then
            search_LiquidationReport(6)
            Panel_date_duration.Visible = False
        ElseIf cmbSearch.Text = "Charge to" Then
            search_LiquidationReport(3)
        ElseIf cmbSearch.Text = "Date Request" Then
            search_LiquidationReport(0)
        End If
    End Sub
    Private Sub btnExit_panel_duration_Click(sender As Object, e As EventArgs) Handles btnExit_panel_duration.Click
        Panel_date_duration.Visible = False
    End Sub
    Private Sub DTPReq_GotFocus(sender As Object, e As EventArgs) Handles cmbRequestType.GotFocus, DTPReq.GotFocus, cmbTOR_sub.GotFocus, txtRSno.GotFocus, txtTypeofCharge.GotFocus, cmbTypeofCharge.GotFocus, txtLoc.GotFocus, txtJOno.GotFocus, txtItemDesc.GotFocus, txtQty.GotFocus, txtUnit.GotFocus, txtAmount.GotFocus, txtPurpose.GotFocus, DTPTimeNeeded.GotFocus, txtRequestBy.GotFocus, cmbSearch.GotFocus, txtSearch.GotFocus, cmbtype_of_purchase.GotFocus, txtws_cash_voice.GotFocus, txtConducted_by.GotFocus, txtItemName.GotFocus, txtCancelledRemarks.GotFocus, cmbConsolidated_account.GotFocus
        sender.backcolor = Color.Yellow
    End Sub
    Private Sub DTPReq_Leave(sender As Object, e As EventArgs) Handles DTPReq.Leave, cmbRequestType.Leave, cmbTOR_sub.Leave, txtRSno.Leave, txtTypeofCharge.Leave, cmbTypeofCharge.Leave, txtLoc.Leave, txtJOno.Leave, txtItemDesc.Leave, txtQty.Leave, txtUnit.Leave, txtAmount.Leave, txtPurpose.Leave, DTPTimeNeeded.Leave, txtRequestBy.Leave, cmbSearch.Leave, txtSearch.Leave, cmbtype_of_purchase.Leave, txtws_cash_voice.Leave, txtConducted_by.Leave, txtItemName.Leave, txtCancelledRemarks.Leave, cmbConsolidated_account.Leave
        sender.backcolor = Color.White
    End Sub
    Private Sub FLiquidationReport_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            ' clear_field()
            DTPReq.Focus()
            btnSave.Text = "Save"
            lvlLiquidationReport.Enabled = True
        ElseIf e.Control And e.KeyCode = Keys.S Then
            If cmbRequestType.Text = "" Or cmbTOR_sub.Text = "" Or cmbtype_of_purchase.Text = "" Or txtRSno.Text = "" Or txtLoc.Text = "" Or txtJOno.Text = "" Or txtItemName.Text = "" Or txtItemDesc.Text = "" Or txtQty.Text = "" Or txtUnit.Text = "" Or txtAmount.Text = "" Or txtPurpose.Text = "" Or txtConducted_by.Text = "" Or txtRequestBy.Text = "" Then
                MessageBox.Show("Field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                For Each ctrl As Control In Panel2.Controls
                    If ctrl.Text = "" Then
                        ' MsgBox(objt.Text)
                        ctrl.Focus()
                    End If
                Next
            ElseIf (cmbRequestType.Text = "Construction Materials" Or cmbRequestType.Text = "Equipment Request") And cmbTypeofCharge.Text = "" Then
                MessageBox.Show("Field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                cmbTypeofCharge.Focus()
            ElseIf cmbRequestType.Text = "Admin and Misc. Request" Then
                MessageBox.Show("Field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtTypeofCharge.Focus()
            Else
                If btnSave.Text = "Save" Then
                    save_liquidation_report()
                    cmbSearch.Text = "Date"
                    DTP_search_liquidation.Text = DTPReq.Text
                    btnSearch.PerformClick()
                    listfocus(lvlLiquidationReport, z)
                    clear_field()
                    DTPReq.Focus()
                ElseIf btnSave.Text = "Update" Then
                    Dim ex = MessageBox.Show("Are you sure u want to update the SELECTED item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    If ex = MsgBoxResult.Yes Then
                        Update_liquidation_report()
                        cmbSearch.Text = "Date"
                        DTP_search_liquidation.Text = DTPReq.Text
                        btnSearch.PerformClick()
                        listfocus(lvlLiquidationReport, w)
                        btnSave.Text = "Save"
                        clear_field()
                        DTPReq.Focus()
                        lvlLiquidationReport.Enabled = True
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
    End Sub
    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            If cmbSearch.Text = "Charge to" Then
                Panel_date_duration.Visible = True
            Else
                btnSearch.PerformClick()
            End If
        End If
    End Sub
    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
    End Sub
    Private Sub cmbTypeofCharge_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbTypeofCharge.SelectedIndexChanged
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

    Private Sub btnSave_Click_1(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim bool_accountTitle_hasItem As Boolean = False
        If cmbRequestType.Text = "" Or cmbTOR_sub.Text = "" Or txtRSno.Text = "" Or txtLoc.Text = "" Or txtJOno.Text = "" Or txtItemDesc.Text = "" Or txtQty.Text = "" Or txtUnit.Text = "" Or txtAmount.Text = "" Or txtPurpose.Text = "" Or txtRequestBy.Text = "" Or txtItemName.Text = "" Or cmbtype_of_purchase.Text = "" Or txtConducted_by.Text = "" Then
            MessageBox.Show("Field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            For Each ctrl As Control In Panel2.Controls
                If ctrl.Text = "" Then
                    ' MsgBox(objt.Text)
                    ctrl.Focus()
                End If
            Next
        ElseIf (cmbRequestType.Text = "Construction Materials" Or cmbRequestType.Text = "Equipment Request") And cmbTypeofCharge.Text = "" Then
            MessageBox.Show("Field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            cmbTypeofCharge.Focus()
            'ElseIf cmbRequestType.Text = "Admin and Misc. Request" And txtTypeofCharge.Text = "" Then
            '    MessageBox.Show("Field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    txtTypeofCharge.Focus()
        Else
            If cmbConsolidated_account.Items.Count > 0 Then ' pag naay sulod ang Account Title
                bool_accountTitle_hasItem = True
            End If

            If bool_accountTitle_hasItem = True And cmbConsolidated_account.Text = "" Then
                MessageBox.Show("Please Select Account Title...", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbConsolidated_account.Focus()
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
                    save_liquidation_report()
                    cmbSearch.Text = "Date"
                    DTP_search_liquidation.Text = DTPReq.Text
                    If item_details_id <> 0 Then
                        insert_requisition_slip_item_details(item_details_id, z)
                    End If

                    btnSearch.PerformClick()
                    listfocus(lvlLiquidationReport, z)
                    clear_field()
                    DTPReq.Focus()
                ElseIf btnSave.Text = "Update" Then

                    Dim ex = MessageBox.Show("Are you sure u want to update the SELECTED item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    If ex = MsgBoxResult.Yes Then
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
                        Update_liquidation_report()
                        cmbSearch.Text = "Date"
                        DTP_search_liquidation.Text = DTPReq.Text
                        If item_details_id <> 0 Then
                            update_requisition_slip_item_details_non_item(item_details_id, w)
                        End If

                        btnSearch.PerformClick()
                        listfocus(lvlLiquidationReport, w)
                        btnSave.Text = "Save"
                        clear_field()
                        DTPReq.Focus()
                        lvlLiquidationReport.Enabled = True
                    End If
                End If 'end sa save and update
            End If 'end sa bool_accountTitle_hasItem
            bool_accountTitle_hasItem = False

        End If
    End Sub
    Public Sub viewCmb_v2(ByVal cmb As Object, ByVal n As Integer, ByVal valueId As Integer)
        cmb.items.clear()
        Dim SqlConn As New SQLcon
        Dim dr As SqlDataReader
        Try
            SqlConn.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SqlConn.connection
            sqlcomm.CommandText = "sp_crud_LiquidationReport"
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
    Private Sub cmbRequestType_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbRequestType.SelectedIndexChanged
        tor_id = get_id("dbType_of_Request", "tor_desc", cmbRequestType.Text, 0)
        viewCmb_v2(cmbTOR_sub, 23, tor_id)
        cmbConsolidated_account.Items.Clear()
    End Sub
    Private Sub txtRSno_TextChanged(sender As Object, e As EventArgs) Handles txtRSno.TextChanged
    End Sub
    Private Sub DTPReq_ValueChanged_1(sender As Object, e As EventArgs) Handles DTPReq.ValueChanged
    End Sub
    Private Sub cmbTOR_sub_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbTOR_sub.SelectedIndexChanged
        viewCmb(cmbConsolidated_account, 24, cmbRequestType.Text, cmbTOR_sub.Text)
    End Sub
    Private Sub txtws_cash_voice_TextChanged(sender As Object, e As EventArgs) Handles txtws_cash_voice.TextChanged
    End Sub
    Private Sub ExportToExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        SaveFileDialog1.Title = "Save Excel File"
        SaveFileDialog1.Filter = "Excel files (*.xls, *.xlsx)|*.xls;*.xlsx"
        SaveFileDialog1.FilterIndex = 2 ' Default to .xlsx format
        SaveFileDialog1.DefaultExt = ".xlsx"
        SaveFileDialog1.ShowDialog()
        'exit if no file selected
        If SaveFileDialog1.FileName = "" Then
            Exit Sub
        End If
        'create objects to interface to Excel
        Dim xls As New Excel.Application
        Dim book As Excel.Workbook
        Dim sheet As Excel.Worksheet
        'create a workbook and get reference to first worksheet
        xls.Workbooks.Add()
        book = xls.ActiveWorkbook
        sheet = book.ActiveSheet


        Dim headerRange As Excel.Range = sheet.Range("A1:T1")
        headerRange.HorizontalAlignment = Excel.Constants.xlCenter
        headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(&H82B1FF))
        Dim dataRange As Excel.Range = sheet.Range("A1:T" & sheet.Rows.Count)
        dataRange.AutoFilter(1)
        'step through rows and columns and copy data to worksheet
        sheet.Cells(1, 1) = "Id"
        sheet.Cells(1, 2) = "Date Request"
        sheet.Cells(1, 3) = "Type of Request"
        sheet.Cells(1, 4) = "Account Title"
        sheet.Cells(1, 5) = "Type of Purchase"
        sheet.Cells(1, 6) = "Ws/Cash Invoice"
        sheet.Cells(1, 7) = "RS no."
        sheet.Cells(1, 8) = "Type of Charges"
        sheet.Cells(1, 9) = "Charge to:"
        sheet.Cells(1, 10) = "Location"
        sheet.Cells(1, 11) = "J.O. No."
        sheet.Cells(1, 12) = "Item Name"
        sheet.Cells(1, 13) = "Item Description"
        sheet.Cells(1, 14) = "Quantity"
        sheet.Cells(1, 15) = "Unit"
        sheet.Cells(1, 16) = "Amount"
        sheet.Cells(1, 17) = "Purpose"
        sheet.Cells(1, 18) = "Conducted by"
        sheet.Cells(1, 19) = "Date Needed"
        sheet.Cells(1, 20) = "Requested"
        sheet.Cells(1, 21) = "Status"

        Dim row1 As Integer = 2

        For Each rows As ListViewItem In lvlLiquidationReport.Items
            ' Check if the status in the column is "Canceled"
            If rows.SubItems(24).Text <> "Cancelled" Then
                sheet.Cells(row1, 1) = rows.SubItems(0).Text
                sheet.Cells(row1, 2) = DateTime.ParseExact(rows.SubItems(1).Text, "M/d/yyyy", Globalization.CultureInfo.InvariantCulture)
                sheet.Cells(row1, 3) = rows.SubItems(2).Text
                sheet.Cells(row1, 4) = rows.SubItems(3).Text
                sheet.Cells(row1, 5) = rows.SubItems(4).Text
                sheet.Cells(row1, 6) = rows.SubItems(5).Text
                sheet.Cells(row1, 7) = rows.SubItems(6).Text
                sheet.Cells(row1, 8) = rows.SubItems(7).Text
                sheet.Cells(row1, 9) = rows.SubItems(8).Text
                sheet.Cells(row1, 10) = rows.SubItems(9).Text
                sheet.Cells(row1, 11) = rows.SubItems(10).Text
                sheet.Cells(row1, 12) = rows.SubItems(11).Text
                sheet.Cells(row1, 13) = rows.SubItems(12).Text
                sheet.Cells(row1, 14) = rows.SubItems(13).Text
                sheet.Cells(row1, 15) = rows.SubItems(14).Text
                sheet.Cells(row1, 16) = rows.SubItems(15).Text
                sheet.Cells(row1, 17) = rows.SubItems(16).Text
                sheet.Cells(row1, 18) = rows.SubItems(17).Text
                sheet.Cells(row1, 19) = Format(Convert.ToDateTime(rows.SubItems(18).Text), "M/d/yyyy")
                sheet.Cells(row1, 20) = rows.SubItems(19).Text
                sheet.Cells(row1, 21) = rows.SubItems(24).Text
                row1 += 1
            End If
        Next

        'save the workbook and clean up
        book.SaveAs(SaveFileDialog1.FileName)
        xls.Workbooks.Close()
        xls.Quit()
        releaseObject(sheet)
        releaseObject(book)
        releaseObject(xls)
        MsgBox("Export Done", MsgBoxStyle.Information)
    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        'Release an automation object
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
    Private Sub TotalLitersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TotalLitersToolStripMenuItem.Click
        Dim i As Integer = 0
        For Each item As ListViewItem In lvlLiquidationReport.Items
            i += CInt(item.SubItems(12).Text)
        Next
        MsgBox("total liters " & " " & i)
    End Sub
    Private Sub CvExportToExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CvExportToExcelToolStripMenuItem.Click
        SaveFileDialog1.Title = "Save Excel File"
        SaveFileDialog1.Filter = "Excel files (*.xls)|*.xls|Excel Files (*.xlsx)|*.xslx"
        SaveFileDialog1.ShowDialog()
        'exit if no file selected
        If SaveFileDialog1.FileName = "" Then
            Exit Sub
        End If
        'create objects to interface to Excel
        Dim xls As New Excel.Application
        Dim book As Excel.Workbook
        Dim sheet As Excel.Worksheet
        'create a workbook and get reference to first worksheet
        xls.Workbooks.Add()
        book = xls.ActiveWorkbook
        sheet = book.ActiveSheet
        'step through rows and columns and copy data to worksheet
        sheet.Cells(1, 1) = "Id"
        sheet.Cells(1, 2) = "Date Request"
        sheet.Cells(1, 3) = "Type of Request"
        sheet.Cells(1, 4) = "Account Title"
        sheet.Cells(1, 5) = "Type of Purchase"
        sheet.Cells(1, 6) = "Ws/Cash Invoice"
        sheet.Cells(1, 7) = "RS no."
        sheet.Cells(1, 8) = "Type of Charges"
        sheet.Cells(1, 9) = "Charge to:"
        sheet.Cells(1, 10) = "Location"
        sheet.Cells(1, 11) = "J.O. No."
        sheet.Cells(1, 12) = "Item Name"
        sheet.Cells(1, 13) = "Item Description"
        sheet.Cells(1, 14) = "Quantity"
        sheet.Cells(1, 15) = "Unit"
        sheet.Cells(1, 16) = "Amount"
        sheet.Cells(1, 17) = "Purpose"
        sheet.Cells(1, 18) = "Conducted by"
        sheet.Cells(1, 19) = "Date Needed"
        sheet.Cells(1, 20) = "Requested"

        Dim row As Integer = 2
        Dim col As Integer = 1
        For Each item As ListViewItem In lvlLiquidationReport.Items
            Dim sam As String() = item.SubItems(5).Text.Split(" ")

            If IsNumeric(sam(2)) = True And sam(2) <> "0" Then

                For i As Integer = 0 To item.SubItems.Count - 1
                    '  MsgBox(item.SubItems.Count - 1)
                    sheet.Cells(row, col) = item.SubItems(i).Text
                    col = col + 1
                Next
                row += 1
                col = 1
            End If
        Next

        'save the workbook and clean up
        book.SaveAs(SaveFileDialog1.FileName)
        xls.Workbooks.Close()
        xls.Quit()
        releaseObject(sheet)
        releaseObject(book)
        releaseObject(xls)
    End Sub
    Private Sub cmbTypeOfChargesName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTypeOfChargesName.SelectedIndexChanged
        cmbTypeofCharge.Text = ""

        If cmbTypeOfChargesName.Text = "EQUIPMENT" Then
            load_charge_to(2, cmbTypeOfChargesName.Text)
            txtTypeofCharge.Visible = False
            cmbTypeofCharge.Visible = True
        ElseIf cmbTypeOfChargesName.Text = "PROJECT" Then
            load_charge_to(1, cmbTypeOfChargesName.Text)
            txtTypeofCharge.Visible = False
            cmbTypeofCharge.Visible = True
        ElseIf cmbTypeOfChargesName.Text = "WAREHOUSE" Then
            load_charge_to(6, cmbTypeOfChargesName.Text)
            txtTypeofCharge.Visible = False
            cmbTypeofCharge.Visible = True
        Else
            load_charge_to(3, cmbTypeOfChargesName.Text)
        End If
    End Sub
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter
    End Sub
    Private Sub cmbtype_of_purchase_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtype_of_purchase.SelectedIndexChanged
    End Sub
    Private Sub txtItemName_TextChanged(sender As Object, e As EventArgs) Handles txtItemName.TextChanged
    End Sub

    Private Sub FLiquidationReport_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        list_liquidation_info.Clear()
    End Sub

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk

    End Sub
    Private Sub cmbTypeofCharge_Leave(sender As Object, e As EventArgs) Handles cmbTypeofCharge.Leave
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

    Private Sub TotalAmountToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TotalAmountToolStripMenuItem.Click
        Dim total As Double = 0.0

        For i = 0 To lvlLiquidationReport.SelectedItems.Count - 1
            total = total + CDbl(lvlLiquidationReport.SelectedItems(i).SubItems(15).Text)
        Next

        MsgBox("Total Amount: " + FormatNumber(total, 2))
    End Sub

    Private Sub ToolStrip_Cancel_Click(sender As Object, e As EventArgs) Handles ToolStrip_Cancel.Click
        Dim ex = MessageBox.Show("Are you sure u want to Cancel the SELECTED items?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If ex = MsgBoxResult.Yes Then
            Panel_Cancelled_Remarks.Visible = True
        End If
    End Sub

    Private Sub btnSaveCancelled_Click(sender As Object, e As EventArgs) Handles btnSaveCancelled.Click
        For Each row As ListViewItem In lvlLiquidationReport.SelectedItems
            Update_status_cancel(row.SubItems(0).Text)
        Next
        Panel_Cancelled_Remarks.Visible = False
        btnSearch.PerformClick()
        MessageBox.Show("Successfully Cancelled...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel_Cancelled_Remarks.Visible = False
    End Sub

    Public Sub viewCmb(ByVal cmb As Object, ByVal n As Integer, ByVal cmbTxt1 As String, Optional cmbTxt2 As String = "")
        cmb.items.clear()
        Dim SqlConn As New SQLcon
        Dim dr As SqlDataReader
        Try
            SqlConn.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SqlConn.connection
            sqlcomm.CommandText = "sp_crud_LiquidationReport"
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
    Public Function getCodesInConsolidatedAccount(ByVal cmbText As String) As String
        Dim result As String = ""
        Dim input As String = cmbText
        ' Split by "("
        Dim parts() As String = input.Split("("c)

        ' Trim spaces and remove closing parenthesis if exists
        For i As Integer = 0 To parts.Length - 1
            parts(i) = parts(i).Trim().TrimEnd(")"c)
        Next

        ' Result:
        ' parts(0) = "ELECTRICAL MATERIALS"
        ' parts(1) = "ELMAT"
        Return parts(1)
    End Function
    Public Function _getId_v1(ByVal n As Integer, ByVal valueID As Integer, Optional value As String = "") As Integer
        Dim Sql_conn As New SQLcon
        Dim dr As SqlDataReader

        Try
            Sql_conn.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = Sql_conn.connection
            sqlcomm.CommandText = "sp_crud_LiquidationReport"
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

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub lvlLiquidationReport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvlLiquidationReport.SelectedIndexChanged

    End Sub

    Private Sub lvlLiquidationReport_DrawColumnHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs) Handles lvlLiquidationReport.DrawColumnHeader

    End Sub


End Class