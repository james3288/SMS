Imports System.Data.SqlClient
Imports System.Data

Public Class FFac_Tools_maintenance
    Dim tor_id As Integer
    Dim tor_sub_id As Integer
    Dim inout_id As Integer
    Dim tsp_id As Integer
    Dim wh_id As Integer
    Public pub_po_id As Integer
    Dim po_det_id As Integer

    Private Sub cmbItemName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbItemName.SelectedIndexChanged

        FMaterials_ToolsTurnOverTextFields.get_WhItemDesc(cmbItemName.Text, 0, cmbItem_desc)

    End Sub

    Private Sub FFac_Tools_maintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FMaterials_ToolsTurnOverTextFields.get_whItem(0, cmbItemName)
        load_request_type(1, cmbType)
    End Sub
    Public Sub load_request_type(ByVal n As Integer, ByVal cmbbox As ComboBox)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim query As String
        cmbbox.Items.Clear()

        newSQ.connection.Open()

        Try
            If n = 1 Then
                query = "SELECT tor_desc FROM dbType_of_Request"
            ElseIf n = 2 Then
                query = "SELECT tor_sub_desc FROM dbType_of_Request_sub WHERE tor_id = " & tor_id
            End If

            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                If n = 1 Then
                    cmbbox.Items.Add(newDR.Item("tor_desc").ToString)
                ElseIf n = 2 Then
                    cmbbox.Items.Add(newDR.Item("tor_sub_desc").ToString)
                End If

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    'get_id("dbwarehouse_items", "whItem^whItemDesc", cmbItemName.Text & "^" & cmbItem_desc.Text, 2)
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtItemName_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        FRequistionForm.cmbSearchByCategory.Text = "Search by RS.No."
        FRequistionForm.txtSearch.Text = txtrsno.Text

        'filter

        For Each ctr As Control In FlowLayoutPanel1.Controls
            If TypeOf ctr Is ComboBox Or TypeOf ctr Is TextBox Then
                If ctr.Text = "" Then
                    MessageBox.Show("You must fill up field first...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If
        Next

        'save rs
        insert_rs()

        'save po
        insert_po(1)

        'receiving
        insert_dbreceiving_info()

    End Sub
    Public Function insert_dbreceiving_info() As Integer
        'Dim suppname, invoiceno, supplier, po_no, rs_no, receivedby, checkedby, receivedstatus, so_no, hauler, plateno As String
        'Dim date_received As DateTime
        Dim rr_item_id As Integer
        Dim rr_info_id As Integer
        Dim rr_item_sub_id As Integer

        Dim subitem As String
        Dim qty As Integer
        Dim unit As String
        Dim price As Double
        Dim selected As String

        With FReceiving_Info
            Dim newSQ As New SQLcon
            Dim newCMD As SqlCommand
            'Dim supplier_id As Integer = get_id("dbSupplier", "Supplier_Name", .cmbSupplier.Text, 0)

            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_receiving_crud_new", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 2)
                newCMD.Parameters.AddWithValue("@type", "OTHERS")

                newCMD.Parameters.AddWithValue("@rr_no", txtrsno.Text)
                newCMD.Parameters.AddWithValue("@invoice_no", txtrsno.Text)
                newCMD.Parameters.AddWithValue("@supplier_id", 62)
                newCMD.Parameters.AddWithValue("@po_no", txtrsno.Text)
                newCMD.Parameters.AddWithValue("@rs_no", .txtRSNo.Text)
                newCMD.Parameters.AddWithValue("@date_received", Date.Parse("1991-01-01"))
                newCMD.Parameters.AddWithValue("@received_by", "n/a")
                newCMD.Parameters.AddWithValue("@checked_by", "n/a")
                newCMD.Parameters.AddWithValue("@received_status", "PENDING")
                newCMD.Parameters.AddWithValue("@so_no", .0)
                newCMD.Parameters.AddWithValue("@hauler", "")
                newCMD.Parameters.AddWithValue("@plateno", "n/a")

                rr_info_id = newCMD.ExecuteScalar()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()

                rr_item_id = FReceiving_Items.insert_update_dbreceiving_items(rr_info_id, "OTHERS", 3, "", "", 0, pub_rs_id, CInt(txtQty.Text), 0, po_det_id, "Include", 0)

                Dim query As String = "INSERT INTO dbreceiving_item_partially(rr_item_id,desired_qty) VALUES(" & rr_item_id & "," & txtQty.Text & ")"
                UPDATE_INSERT_DELETE_QUERY(query, 0, "INSERT")

                subitem = cmbItem_desc.Text
                qty = txtQty.Text
                unit = txtUnit.Text
                price = 0
                selected = "Include"

                rr_item_sub_id = FReceiving_Items.insert_to_receiving_sub_item(subitem, qty, price, unit, selected, rr_item_id)
                FReceiving_Items.insert_reserved_item(rr_item_sub_id, subitem, rs_no, rs_id, qty)

                FReceiving_Items.update_po_price_qty(price, rs_id)

                Dim query1 As String = "SELECT rs_id FROM dbrequisition_slip a WHERE a.rs_no = '" & txtrsno.Text & "' AND a.main_sub = '" & "MAIN" & "'"
                Dim main_rs_id As Integer = get_specific_column_value(query1, 1)

                If check_if_exist("dbBorrower_checking_info", "rs_id", main_rs_id, 1) = 0 Then 'if dili zero, no need to insert na
                    FItem_Sets.dbBorrower_checking_info(main_rs_id) 'insert to dbBorrower_checking_info            
                End If

                Dim query2 As String = "SELECT checking_info_id FROM dbBorrower_checking_info WHERE rs_id = " & main_rs_id
                Dim checkingInfo_id As Integer = get_specific_column_value(query2, 1) 'get id from dbBorrower_checking_info
                FItem_Sets.insert_borrowerchercking_items(checkingInfo_id, rr_item_sub_id, subitem, 0, txtQty.Text, rr_item_id)

                FListofBorrowerItem.update_requestionslip(main_rs_id, 0)

            End Try
        End With

    End Function

    Public Sub INSERT_PO_DETAILS(ByVal po_id As Integer, ByVal sup_id As Integer, ByVal wh_id As Integer, ByVal item_desc As String,
                                    ByVal po_no As String, ByVal terms As String, ByVal qty As Integer,
                                    ByVal unit As String, ByVal unitprice As Double, ByVal amount As Double, ByVal rs_id As Integer, ByVal SELECTED As String)

        Dim SQ As New SQLcon
        Dim cmd As SqlCommand
        Try
            SQ.connection.Open()

            Dim lof_id As Integer = FPOFORM.get_lof_id(wh_id, item_desc)

            cmd = New SqlCommand("proc_po_query", SQ.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@n", 2)
            cmd.Parameters.AddWithValue("@po_id", po_id)
            cmd.Parameters.AddWithValue("@supplier_id", sup_id)
            cmd.Parameters.AddWithValue("@wh_id", wh_id)
            cmd.Parameters.AddWithValue("@item_desc", item_desc)
            cmd.Parameters.AddWithValue("@po_no", po_no)
            cmd.Parameters.AddWithValue("@terms", terms)
            cmd.Parameters.AddWithValue("@qty", qty)
            cmd.Parameters.AddWithValue("@unit", unit)
            cmd.Parameters.AddWithValue("@unit_price", unitprice)
            cmd.Parameters.AddWithValue("@amount", amount)
            cmd.Parameters.AddWithValue("@selected", SELECTED)
            cmd.Parameters.AddWithValue("@rs_id", rs_id)
            cmd.Parameters.AddWithValue("@lof_id", lof_id)

            po_det_id = cmd.ExecuteScalar()

            'If qty > 1 Then
            '    For i = 0 To qty - 1
            '        FPOFORM.INSERT_FACILITIES_ITEM(po_det_id, lof_id, Date.Parse("1991-01-01"), 0, 0, "", "pending", 1, "", "", 0)
            '    Next
            'Else
            '    FPOFORM.INSERT_FACILITIES_ITEM(po_det_id, lof_id, Date.Parse("1991-01-01"), 0, 0, "", "pending", qty, "", "", 0)
            'End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

    End Sub

    Public Sub insert_po(n As Integer)
        Dim SQ As New SQLcon
        Dim cmd As SqlCommand
        Try
            SQ.connection.Open()

            cmd = New SqlCommand("proc_po_query", SQ.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@n", n)

            If n = 1 Then
                cmd.Parameters.AddWithValue("@po_date", Date.Parse("1991-01-01"))
                cmd.Parameters.AddWithValue("@rs_no", txtrsno.Text)
                cmd.Parameters.AddWithValue("@instructions", "for pickup")
                cmd.Parameters.AddWithValue("@charge_to", 150)
                cmd.Parameters.AddWithValue("@charge_type", "ADFIL")
                cmd.Parameters.AddWithValue("@date_needed", Date.Parse("1991-01-01"))
                cmd.Parameters.AddWithValue("@prepared_by", "n/a")
                cmd.Parameters.AddWithValue("@checked_by", "n/a")
                cmd.Parameters.AddWithValue("@approved_by", "n/a")

            End If

            pub_po_id = cmd.ExecuteScalar()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
            INSERT_PO_DETAILS(pub_po_id, 62, wh_id, cmbItem_desc.Text, txtrsno.Text, "n/a", txtQty.Text, txtUnit.Text, 0, 0, pub_rs_id, "TRUE")

        End Try
    End Sub
    Public Sub insert_rs()
        Dim n As Integer
        Dim SQ As New SQLcon
        Dim cmd As SqlCommand

        Try
            SQ.connection.Open()
            publicquery = Nothing

            wh_id = get_id("dbwarehouse_items", "whItem^whItemDesc", cmbItemName.Text & "^" & cmbItem_desc.Text, 2)

            tor_sub_id = get_id("dbType_of_Request_sub", "tor_sub_desc", cmbSub.Text, 0)
            inout_id = get_id("dbinout", "in_out_desc", cmbIn.Text, 0)
            tsp_id = get_id("dbtor_sub_property", "tor_sub_id^inout_id", tor_sub_id & "^" & inout_id, 3)

            publicquery = "Set NOCOUNT On;"
            publicquery = "INSERT INTO dbrequisition_slip(rs_no, date_req, job_order_no, charge_to, Location, "
            publicquery &= "wh_id, item_desc, qty, unit, typeRequest, Process, purpose, date_needed, requested_by, noted_by, wh_incharge, approved_by, IN_OUT, date_log, type_of_purchasing, remarks, user_id, remarks1, main_sub)"
            publicquery &= " VALUES('" & txtrsno.Text & "','"
            publicquery &= Date.Parse("1991-01-01") & "','" & 0 & "','" & 150 & "','"
            publicquery &= "BUTUAN" & "','" & wh_id & "','" & cmbItem_desc.Text & "'," & txtQty.Text & ",'" & txtUnit.Text & "','"
            publicquery &= cmbType.Text & "','" & "ADFIL" & "','" & "n/a" & "','" & Date.Parse("1991-01-01") & "','" & "n/a" & "','"
            publicquery &= "n/a" & "','" & "Vanessa Fabe Piedad" & "','" & "n/a" & "','" & "OTHERS" & "','" & Format(Date.Parse("1991-01-01"), "yyyy-MM-dd") & "','" & "PURCHASE ORDER" & "','" & from_old_item_or_new_item & "','" & pub_user_id & "','N/A','MAIN') "

            publicquery &= "SELECT SCOPE_IDENTITY()"

            cmd = New SqlCommand(publicquery, SQ.connection)

            pub_rs_id = cmd.ExecuteScalar()

            rs_tor_sub_pro_save(pub_rs_id)

            MessageBox.Show("Successfully Inserted...", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
            from_old_item_or_new_item = Nothing

            FListOfItems.save_fac_tools(pub_rs_id, cmb_factools.Text)

            'save charges
            Dim query As String = "INSERT INTO dbMultipleCharges(all_charges_id,type_name,rs_id,fi_id) VALUES(" & 150 & ",'" & "OTHERS" & "'," & pub_rs_id & "," & 0 & ")"
            UPDATE_INSERT_DELETE_QUERY(query, 0, "INSERT")
        End Try
    End Sub
    Public Sub rs_tor_sub_pro_save(ByVal rs_id As Integer)

        Try
            tor_sub_id = get_id("dbType_of_Request_sub", "tor_sub_desc", cmbSub.Text, 0)
            inout_id = get_id("dbinout", "in_out_desc", cmbIn.Text, 0)
            tsp_id = get_id("dbtor_sub_property", "tor_sub_id^inout_id", tor_sub_id & "^" & inout_id, 3)

            Dim query As String = "INSERT INTO rs_tor_sub_property(rs_id,tsp_id,tor_sub_id) VALUES(" & rs_id & "," & tsp_id & "," & tor_sub_id & ")"
            UPDATE_INSERT_DELETE_QUERY(query, 0, "INSERT")

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try
    End Sub
    Private Sub cmbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbType.SelectedIndexChanged
        tor_id = get_id_sub_type_of_request()
        load_request_type(2, cmbSub)

        If cmbType.Text = "Admin And Misc. Request" Then
            cmbSub.Items.Remove("Borrower")
        End If
    End Sub

    Public Function get_id_sub_type_of_request()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim query As String
        newSQ.connection.Open()

        Try
            query = "SELECT tor_id FROM dbType_of_Request WHERE tor_desc='" & cmbType.Text & "'"
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_id_sub_type_of_request = newDR.Item(0).ToString
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
End Class