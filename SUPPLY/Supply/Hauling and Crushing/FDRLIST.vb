Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Public Class FDRLIST
    Public rowcount As Integer = 0
    Dim sortColumn As Integer = -1
    Private Sub FDRLIST_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'load_DR()
        ColumnHeader26.DisplayIndex = 3

        ColumnHeader3.DisplayIndex = 1
        ColumnHeader11.DisplayIndex = 2
        ColumnHeader4.DisplayIndex = 3
        ColumnHeader31.DisplayIndex = 4
        ColumnHeader2.DisplayIndex = 5
        ColumnHeader25.DisplayIndex = 6
        ColumnHeader10.DisplayIndex = 7
        ColumnHeader20.DisplayIndex = 8
        ColumnHeader26.DisplayIndex = 9
        ColumnHeader5.DisplayIndex = 10
        ColumnHeader30.DisplayIndex = 11
        ColumnHeader8.DisplayIndex = 12
        ColumnHeader6.DisplayIndex = 13
        ColumnHeader9.DisplayIndex = 14
        ColumnHeader27.DisplayIndex = 16
        ColumnHeader7.DisplayIndex = 16
        ColumnHeader28.DisplayIndex = 17
        ColumnHeader29.DisplayIndex = 18
        ColumnHeader23.DisplayIndex = 19
        ColumnHeader13.DisplayIndex = 20
        ColumnHeader14.DisplayIndex = 21
        ColumnHeader22.DisplayIndex = 22
        ColumnHeader24.DisplayIndex = 23

        ComboBox2.Location = New Point(20000, 0)
    End Sub

    Public Sub load_DR(n As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim a(25) As String
        lvl_drList.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure


            newCMD.Parameters.AddWithValue("@search", txtSearch.Text)
            newCMD.Parameters.AddWithValue("@searchby", cmbSearchBy.Text)


            If cmbSearchBy.Text = "Search by Project/Requestor" Then

                newCMD.Parameters.AddWithValue("@n", 55)
                newCMD.Parameters.AddWithValue("@sortby", FSORTBY.cmbSortBy.Text)
                newCMD.Parameters.AddWithValue("@project", cmbRequestor.Text)
                newCMD.Parameters.AddWithValue("@datefrom", Date.Parse(dtpFrom.Text))
                newCMD.Parameters.AddWithValue("@dateto", Date.Parse(dtpTo.Text))

                newCMD.Parameters.AddWithValue("@search1", FSORTBY.txtItemDesc.Text)
                newCMD.Parameters.AddWithValue("@searchby1", FSORTBY.cmbSortBy.Text)

            ElseIf cmbSearchBy.Text = "Search by DR Date" Then

                newCMD.Parameters.AddWithValue("@n", 56)
                newCMD.Parameters.AddWithValue("@sortby", FSORTBY.cmbSortBy.Text)
                newCMD.Parameters.AddWithValue("@datefrom", dtpFrom.Text)
                newCMD.Parameters.AddWithValue("@dateto", dtpTo.Text)

                newCMD.Parameters.AddWithValue("@search1", FSORTBY.txtItemDesc.Text)
                newCMD.Parameters.AddWithValue("@searchby1", FSORTBY.cmbSortBy.Text)

            Else

                newCMD.Parameters.AddWithValue("@n", n)
                newCMD.Parameters.AddWithValue("@sortby", FSORTBY.cmbSortBy.Text)
                newCMD.Parameters.AddWithValue("@datefrom", dtpFrom.Text)
                newCMD.Parameters.AddWithValue("@dateto", dtpTo.Text)

                newCMD.Parameters.AddWithValue("@search1", FSORTBY.txtItemDesc.Text)
                newCMD.Parameters.AddWithValue("@searchby1", FSORTBY.cmbSortBy.Text)

            End If

            newDR = newCMD.ExecuteReader

            While newDR.Read

                a(0) = newDR.Item("dr_items_id").ToString
                a(1) = newDR.Item("dr_no").ToString
                a(2) = newDR.Item("rs_no").ToString
                a(3) = Format(Date.Parse(newDR.Item("date").ToString), "MM/dd/yyyy")
                a(4) = newDR.Item("whItem").ToString & "-" & newDR.Item("whItemDesc").ToString
                a(5) = newDR.Item("SOURCE").ToString
                a(6) = newDR.Item("qty").ToString
                a(7) = newDR.Item("unit").ToString
                a(8) = newDR.Item("concession_ticket_no").ToString
                a(9) = newDR.Item("DRIVER").ToString
                a(10) = newDR.Item("REQUESTOR").ToString 'IIf(newDR.Item("REQUESTOR").ToString = "", newDR.Item("REQUESTOR1").ToString, newDR.Item("REQUESTOR"))
                a(11) = newDR.Item("address").ToString
                a(12) = newDR.Item("checkedBy").ToString
                a(13) = newDR.Item("receivedby").ToString
                a(14) = newDR.Item("dr_info_id").ToString
                a(15) = newDR.Item("rs_id").ToString
                a(16) = newDR.Item("IN_OUT").ToString
                a(19) = newDR.Item("ws_no").ToString
                a(20) = newDR.Item("par_rr_item_id").ToString
                a(21) = newDR.Item("remarks").ToString
                a(22) = newDR.Item("SUPPLIER").ToString
                a(23) = newDR.Item("users").ToString
                a(24) = newDR.Item("PLATE_NO").ToString
                a(25) = newDR.Item("RR_NO").ToString

                If newDR.Item("dr_no").ToString = "n/a" Or newDR.Item("dr_no").ToString = "" Then
                    a(17) = "n/a"
                    a(18) = "n/a"
                Else
                    a(17) = Format(Date.Parse(newDR.Item("time_from").ToString), "HH:mm:ss tt")
                    a(18) = Format(Date.Parse(newDR.Item("time_to").ToString), "HH:mm:ss tt")

                End If

                Dim lvl As New ListViewItem(a)
                lvl_drList.Items.Add(lvl)

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE:  " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Public Function get_operator(operator_id As Integer) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection1.Open()
            Dim query As String = "SELECT * FROM dboperator WHERE operator_id = " & operator_id
            newCMD = New SqlCommand(query, newSQ.connection1)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_operator = newDR.Item("operator_name").ToString
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection1.Close()
        End Try

    End Function

    Private Sub EditInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditInfoToolStripMenuItem.Click
        button_click_name = "EditInfoToolStripMenuItem"
        pub_button_name = "EditInfoToolStripMenuItem"

        Dim rs_id As Integer = lvl_drList.SelectedItems(0).SubItems(15).Text
        Dim dr_info_id As Integer = lvl_drList.SelectedItems(0).SubItems(14).Text
        Dim ws_no As String = lvl_drList.SelectedItems(0).SubItems(19).Text
        Dim rs_no As String = lvl_drList.SelectedItems(0).SubItems(2).Text

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        With FDeliveryReceipt

            FReceiving_Info.load_suppliers_list(.cmbSupplier)
            FReceiving_Info.show_cmbOperator(.cmbOperator)
            FPreviousStackCardFinal.load_set_type_of_charge("CASH", .cmbTypeofCharge)
            .cmbWsNo_PoNo.Items.Clear()
            FRequistionForm.AddWithdrawalNos(rs_id, .cmbWsNo_PoNo, rs_no)
            .cmbWsNo_PoNo.Text = ws_no
            .cmbWsNo_PoNo.Enabled = False

        End With

        FDeliveryReceipt.Panel7.Enabled = True
        FDeliveryReceipt.dgv_dr_list.Enabled = False

        FDeliveryReceipt.Panel9.Enabled = True
        FDeliveryReceipt.cmbSupplier.Enabled = True

        FDeliveryReceipt.cmbOptions.Enabled = False
        FDeliveryReceipt.cmbDrOptions.Enabled = False
        FDeliveryReceipt.txtprice.Enabled = True

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 4)
            newCMD.Parameters.AddWithValue("@dr_info_id", dr_info_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                With FDeliveryReceipt

                    .dtpDRDate.Text = newDR.Item("date").ToString
                    '.dtpTimeFrom.Text = newDR.Item("time_from").ToString
                    '.dtpTime_to.Text = newDR.Item("time_to").ToString

                    .txtPlateNo.Text = newDR.Item("PLATENO").ToString

                    If .txtPlateNo.Text = "" Then
                        .txtPlateNo.Text = newDR.Item("plate_no_outsource").ToString
                    End If

                    .txtDriver.Text = newDR.Item("OPERATOR").ToString

                    If .txtDriver.Text = "" Then
                        .txtDriver.Text = newDR.Item("operator_outsource").ToString
                    End If
                    '.cmbOperator.Text = newDR.Item("OPERATOR").ToString

                    .cat = newDR.Item("type_of_request").ToString
                    .cat_desc = newDR.Item("REQUESTOR").ToString


                    .cmbTypeofCharge.Text = newDR.Item("type_of_request").ToString

                    If .cmbTypeofCharge.Text = "PROJECT" Or .cmbTypeofCharge.Text = "EQUIPMENT" Then
                        .cmbChargeTo.Text = newDR.Item("REQUESTOR").ToString

                    Else
                        .txtChargeTo.Text = newDR.Item("REQUESTOR").ToString
                    End If

                    '.txtpono.Text = FRequistionForm.get_PO_NO(rs_id)
                    .txtrsno.Text = newDR.Item("rs_no").ToString
                    '.txtaddress.Text = newDR.Item("address").ToString
                    .cmbSupplier.Text = newDR.Item("SUPPLIER").ToString
                    .txtconcession.Text = newDR.Item("concession_ticket_no").ToString
                    .txtcheckedby.Text = newDR.Item("checkedBy").ToString
                    .txtreceivedby.Text = newDR.Item("receivedby").ToString
                    .txtRemarks.Text = newDR.Item("remarks").ToString
                    .txtprice.Text = newDR.Item("price").ToString

                    .cmbOptions.SelectedIndex = -1
                    .cmbDrOptions.SelectedIndex = -1

                    If newDR.Item("dr_no").ToString = "n/a" Then
                        With FDeliveryReceipt

                            '.dtpTimeFrom.Enabled = False
                            '.dtpTime_to.Enabled = False
                            .txtPlateNo.Enabled = False
                            .cmbOperator.Enabled = False
                            .cmbTypeofCharge.Enabled = True
                            .cmbChargeTo.Enabled = True
                            .txtChargeTo.Enabled = True
                            '.txtaddress.Enabled = False
                            .txtrsno.Enabled = False
                            '.txtpono.Enabled = False
                            .txtconcession.Enabled = False
                            .txtcheckedby.Enabled = False
                            .txtreceivedby.Enabled = False

                        End With
                    Else
                        With FDeliveryReceipt

                            '.dtpTimeFrom.Enabled = True
                            '.dtpTime_to.Enabled = True
                            .txtPlateNo.Enabled = True
                            .cmbOperator.Enabled = True
                            .cmbTypeofCharge.Enabled = True
                            .cmbChargeTo.Enabled = True
                            .txtChargeTo.Enabled = True
                            '.txtaddress.Enabled = True
                            .txtrsno.Enabled = True
                            '.txtpono.Enabled = True
                            .txtconcession.Enabled = True
                            .txtcheckedby.Enabled = True
                            .txtreceivedby.Enabled = True

                        End With
                    End If


                End With
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
            FDeliveryReceipt.btnSave.Text = "Update Info"
            FDeliveryReceipt.lbl_dr_info_id.Text = lvl_drList.SelectedItems(0).SubItems(14).Text
            FDeliveryReceipt.dgv_dr_list.Enabled = False
            FDeliveryReceipt.dgv_dr_list.Rows.Clear()

            If lvl_drList.SelectedItems(0).SubItems(16).Text = "OTHERS" Or lvl_drList.SelectedItems(0).SubItems(16).Text = "IN" Then
                FDeliveryReceipt.txtprice.Enabled = True
                FDeliveryReceipt.Panel9.Enabled = False
            Else
                FDeliveryReceipt.txtprice.Enabled = False
                FDeliveryReceipt.txtprice.Text = 0
                FDeliveryReceipt.Panel9.Enabled = False
            End If

            FDeliveryReceipt.ShowDialog()


        End Try

    End Sub

    Private Sub EditDescriptionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditDescriptionToolStripMenuItem.Click
        button_click_name = "EditDescriptionToolStripMenuItem"

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        FDeliveryReceipt.dgv_dr_list.Rows.Clear()
        FDeliveryReceipt.Panel7.Enabled = False
        FDeliveryReceipt.dgv_dr_list.Enabled = True

        Dim dr_info_id As Integer = lvl_drList.SelectedItems(0).SubItems(14).Text

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 6)
            newCMD.Parameters.AddWithValue("@dr_info_id", dr_info_id)

            newDR = newCMD.ExecuteReader
            Dim a(20) As String
            While newDR.Read
                a(0) = "True"
                a(1) = newDR.Item("dr_no").ToString
                a(2) = newDR.Item("SOURCE").ToString
                a(3) = newDR.Item("category").ToString
                a(4) = newDR.Item("qty").ToString
                a(5) = newDR.Item("ITEM_NAME").ToString
                a(6) = newDR.Item("rs_id").ToString
                a(7) = newDR.Item("dr_items_id").ToString
                a(8) = newDR.Item("wh_id").ToString
                a(9) = "Selected"
                FDeliveryReceipt.dgv_dr_list.Rows.Add(a)

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

        FDeliveryReceipt.btnSave.Text = "Update Description"
        FDeliveryReceipt.ShowDialog()
    End Sub

    Private Sub RemoveItemsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveItemsToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you want to remove this item?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim newSQ As New SQLcon
            Dim newCMD As SqlCommand

            Try
                For Each row As ListViewItem In lvl_drList.Items

                    If row.Selected = True Then

                        Dim dr_item_id, dr_info_id As Integer
                        Dim rs_id As Integer = row.SubItems(15).Text
                        Dim par_rr_item_id As Integer = IIf(row.SubItems(20).Text = "", 0, row.SubItems(20).Text) 'this is suppose to be rr_item_id not par_rr_item_id
                        Dim rs_no As String = row.SubItems(2).Text
                        Dim in_out As String = row.SubItems(16).Text
                        Dim ws_no_po_no As String = row.SubItems(19).Text
                        Dim rr_no As String = row.SubItems(25).Text

                        dr_item_id = row.Text
                        dr_info_id = row.SubItems(14).Text

                        'DELETE DR INFO AND DR DETAILS-------------------
                        newSQ.connection.Open()
                        newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
                        newCMD.Parameters.Clear()
                        newCMD.CommandType = CommandType.StoredProcedure

                        newCMD.Parameters.AddWithValue("@n", 7)
                        newCMD.Parameters.AddWithValue("@dr_item_id", dr_item_id)
                        newCMD.Parameters.AddWithValue("@dr_info_id", dr_info_id)

                        newCMD.ExecuteNonQuery()
                        newSQ.connection.Close()
                        '----------------------------------------------

                        'If rs_no = "" Or rs_no = "N/A" Or rs_no = "n/a" Then

                        '    delete_rr_data(rs_id)
                        '    delete_all_connected_from_dr(rs_id)
                        '    delete_from_rs(rs_id)

                        'Else
                        '    If in_out = "IN" Then
                        '        If ws_no_po_no = "" Then
                        '            If rr_no <> "" Then
                        '                'delete_specific_rr_data(par_rr_item_id)  'this is suppose to be rr_item_id not par_rr_item_id
                        '            Else
                        '                delete_rr_data(rs_id)
                        '                delete_all_connected_from_dr(rs_id)
                        '            End If


                        '        Else
                        '            delete_all_connected_from_dr_IN(rs_id, par_rr_item_id) 'this is suppose to be rr_item_id not par_rr_item_id
                        '        End If

                        '    End If

                        'End If


                    End If

                Next

                'delete_all_connected_from_dr(rs_id)

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally

                MessageBox.Show("Successfully removed...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'load_DR(5)
                'btnSearch.PerformClick()
                For Each row As ListViewItem In lvl_drList.Items
                    If row.Selected = True Then
                        row.Remove()
                    End If
                Next
            End Try
        End If

    End Sub
    Public Sub delete_all_connected_from_dr_IN(rs_id As Integer, par_rr_item_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 17)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.Parameters.AddWithValue("@par_rr_item_id", par_rr_item_id)

            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Public Sub delete_all_connected_from_dr(rs_id As Integer)

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newdr As SqlDataReader

        Try

            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 10)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newdr = newCMD.ExecuteReader

            While newdr.Read
                Dim query As String

                query = "DELETE FROM dbPO_details WHERE po_det_id = " & newdr.Item("po_det_id").ToString
                UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")
                query = Nothing

                query = "DELETE FROM dbPO WHERE po_id = " & newdr.Item("po_id").ToString
                UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")
                query = Nothing

                query = "DELETE FROM dbwithdrawn_items WHERE rs_id = " & rs_id
                UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")
                query = Nothing
            End While

            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub delete_from_rs(rs_id As Integer)

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try

            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 11)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub delete_specific_rr_data(rr_item_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 77)
            newCMD.Parameters.AddWithValue("@rr_item_id3", rr_item_id)
            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Public Sub delete_rr_data(rs_id As Integer)

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newdr As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 9)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newdr = newCMD.ExecuteReader
            While newdr.Read

                'dete data from db_receiving_items
                Dim query1 As String = "DELETE FROM dbreceiving_items WHERE rr_item_id = " & newdr.Item("rr_item_id").ToString
                UPDATE_INSERT_DELETE_QUERY(query1, 0, "DELETE")
                query1 = Nothing

                'delete data from dbreceiving_info
                Dim query2 As String = "DELETE FROM dbreceiving_info WHERE rr_info_id = " & newdr.Item("rr_info_id").ToString
                UPDATE_INSERT_DELETE_QUERY(query2, 0, "DELETE")
                query2 = Nothing

                'delete data from dbreceiving_item_partially
                Dim query3 As String = "DELETE FROM dbreceiving_item_partially WHERE par_rr_item_id = " & newdr.Item("par_rr_item_id").ToString
                UPDATE_INSERT_DELETE_QUERY(query3, 0, "DELETE")
                query3 = Nothing

            End While
            newdr.Close()


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Public Sub waste_excemption(datefrom As DateTime, dateto As DateTime, searchby As String, search As String, searchitem As String, remarks As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        FWasteExcemption.lvlListOfAggregates.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 33)
            newCMD.Parameters.AddWithValue("@datefrom", Date.Parse(datefrom))
            newCMD.Parameters.AddWithValue("@dateto", Date.Parse(dateto))
            newCMD.Parameters.AddWithValue("@Search", search)
            newCMD.Parameters.AddWithValue("@Searchby", searchby)
            'newCMD.Parameters.AddWithValue("@SearchItem", txtSearchItems.Text)
            newCMD.Parameters.AddWithValue("@SearchItem", searchitem)
            newCMD.Parameters.AddWithValue("@remarks", remarks)
            newCMD.CommandTimeout = 50

            newDR = newCMD.ExecuteReader


            Dim a(10) As String

            While newDR.Read
                a(0) = newDR.Item("ITEM_DESC").ToString
                a(1) = newDR.Item("remarks").ToString

                Dim lvl As New ListViewItem(a)

                FWasteExcemption.lvlListOfAggregates.Items.Add(lvl)
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click


        pub_button_name = "btnSearch"

        If cmbSearchBy.Text = "Search by Project/Requestor" Or cmbSearchBy.Text = "Search by Warehouse/Stockpile" Then

            FSORTBY.Height = 399
            FSORTBY.GroupBox2.Visible = True
            FSORTBY.cmbEnable_Disable.SelectedIndex = 0
        End If

        FSORTBY.ShowDialog()
        'dr_list(30, txtSearch.Text)
    End Sub

    Public Function get_qty_left_from_receiving(value As String, rs_id As Integer, n As Integer) As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_withdrawal_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@value", value)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_qty_left_from_receiving = IIf(newDR.Item("qty").ToString = "", 0, newDR.Item("qty").ToString)
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Function
    Public Function count_qty_dr_using_ws_no(ws_no As String, rs_no As String, n As Integer, rs_id As Integer) As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@ws_no", ws_no)
            newCMD.Parameters.AddWithValue("@rs_no", rs_no)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                If newDR.Item("qty").ToString = "" Then
                    count_qty_dr_using_ws_no = 0
                Else
                    count_qty_dr_using_ws_no = CDbl(newDR.Item("qty").ToString)
                End If

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Public Sub dr_list(n As Integer, search As String, remarks As String)


        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.CommandTimeout = 0

            'newCMD.Parameters.AddWithValue("@n", n)
            'newCMD.Parameters.AddWithValue("@search", search)

            newCMD.Parameters.AddWithValue("@search", txtSearch.Text)
            newCMD.Parameters.AddWithValue("@searchby", cmbSearchBy.Text)

            'If cmbSearchBy.Text = "Search by Project/Requestor" Then

            '    newCMD.Parameters.AddWithValue("@n", 55)
            '    newCMD.Parameters.AddWithValue("@sortby", FSORTBY.cmbSortBy.Text)
            '    newCMD.Parameters.AddWithValue("@project", cmbRequestor.Text)
            '    newCMD.Parameters.AddWithValue("@datefrom", dtpFrom.Text)
            '    newCMD.Parameters.AddWithValue("@dateto", dtpTo.Text)

            '    newCMD.Parameters.AddWithValue("@search1", FSORTBY.txtItemDesc.Text)
            '    newCMD.Parameters.AddWithValue("@searchby1", FSORTBY.cmbSortBy.Text)

            If cmbSearchBy.Text = "Search by DR Date" Then

                newCMD.Parameters.AddWithValue("@n", 31)
                newCMD.Parameters.AddWithValue("@sortby", FSORTBY.cmbSortBy.Text)
                newCMD.Parameters.AddWithValue("@datefrom", FSORTBY.dtpfrom.Text)
                newCMD.Parameters.AddWithValue("@dateto", FSORTBY.dtpto.Text)

                newCMD.Parameters.AddWithValue("@search1", FSORTBY.txtItemDesc.Text)
                newCMD.Parameters.AddWithValue("@searchby1", FSORTBY.cmbSortBy.Text)

            Else

                newCMD.Parameters.AddWithValue("@n", n)
                newCMD.Parameters.AddWithValue("@project", txtSearch.Text)
                newCMD.Parameters.AddWithValue("@searchby1", FSORTBY.cmbSortBy.Text)
                newCMD.Parameters.AddWithValue("@sortby", FSORTBY.cmbSortBy.Text)
                newCMD.Parameters.AddWithValue("@SearchItem", search) 'item descrip.
                newCMD.Parameters.AddWithValue("@remarks", remarks) 'remarks
                newCMD.Parameters.AddWithValue("@inout", FSORTBY.cmbINOUT.Text)
                newCMD.Parameters.AddWithValue("@division", FSORTBY.cmbdivision.Text)
                newCMD.Parameters.AddWithValue("@datefrom", FSORTBY.dtpfrom.Text)
                newCMD.Parameters.AddWithValue("@dateto", FSORTBY.dtpto.Text)
                newCMD.Parameters.AddWithValue("@search2", FSORTBY.txtItemDesc.Text) 'depend on what to search rs,item desc,consession etc.
                rowcount = 0

            End If

            newDR = newCMD.ExecuteReader

            Dim a(40) As String

            While newDR.Read
                Dim ws_no As String = newDR.Item("WS_NO").ToString
                Dim rs_no As String = newDR.Item("rs_no").ToString


                If newDR.Item("IN_OUT").ToString = "OUT" Then
                    If newDR.Item("WITHDRAWN").ToString = "NO" Then
                        GoTo proceedhere
                    End If

                    If newDR.Item("stat").ToString = "" And newDR.Item("dr_no").ToString = "" Then
                        GoTo proceedhere

                    ElseIf newDR.Item("stat").ToString = "" And newDR.Item("dr_no").ToString <> "" Then
                        a(1) = newDR.Item("dr_no").ToString
                        a(19) = "N/A"
                        a(25) = "N/A"
                    End If

                ElseIf newDR.Item("IN_OUT").ToString = "IN" Or newDR.Item("IN_OUT").ToString = "OTHERS" Then
                    If newDR.Item("WITHDRAWN").ToString = "NO" Then
                        If newDR.Item("SORTING").ToString = "AA" Then

                        Else
                            GoTo proceedhere
                        End If

                    End If

                    If newDR.Item("stat").ToString = "" And newDR.Item("dr_no").ToString = "" Then
                        If newDR.Item("SORTING").ToString = "AA" Then

                        Else
                            GoTo proceedhere
                        End If

                    ElseIf newDR.Item("stat").ToString = "" And newDR.Item("dr_no").ToString <> "" Then
                        a(1) = newDR.Item("dr_no").ToString
                        a(19) = "N/A"
                        a(25) = "N/A"
                    End If

                End If

                a(0) = newDR.Item("dr_items_id").ToString
                a(2) = newDR.Item("rs_no").ToString

                If newDR.Item("date").ToString = "" Then
                    a(3) = "1901-01-01"
                Else
                    a(3) = Format(Date.Parse(newDR.Item("date").ToString), "MM-dd-yyyy")
                End If
                'a(3) = IIf(newDR.Item("date").ToString = "", "1901-01-01", newDR.Item("date").ToString)
                a(4) = newDR.Item("item_name").ToString
                a(29) = newDR.Item("item_desc").ToString
                a(5) = newDR.Item("SUPP_SOURCE").ToString
                a(7) = newDR.Item("unit").ToString
                a(8) = newDR.Item("concession_ticket_no").ToString
                a(9) = newDR.Item("DRIVER").ToString
                a(10) = newDR.Item("RECEPIENT").ToString
                a(11) = newDR.Item("SUPPLIER").ToString 'a(7) source_wh
                a(12) = newDR.Item("checkedBy").ToString
                a(13) = newDR.Item("receivedby").ToString
                a(14) = newDR.Item("dr_info_id").ToString
                a(15) = newDR.Item("rs_id").ToString
                a(16) = newDR.Item("IN_OUT").ToString
                a(20) = newDR.Item("par_rr_item_id").ToString
                a(21) = newDR.Item("remarks").ToString 'a(11) remarks
                a(22) = newDR.Item("SUPPLIER").ToString
                a(23) = newDR.Item("username").ToString.ToUpper
                a(24) = newDR.Item("plate_no").ToString

                If newDR.Item("date_request").ToString = "" Then
                    a(30) = ""
                Else
                    a(30) = Format(Date.Parse(newDR.Item("date_request").ToString), "MM-dd-yyyy")
                End If

                If newDR.Item("PRICE").ToString = "" Then : a(27) = 0 : Else : a(27) = FormatNumber(newDR.Item("PRICE").ToString, 2,,, TriState.True) : End If

                Select Case newDR.Item("stat").ToString
                    Case "IN WITHOUT RS AND DR"
                        a(1) = newDR.Item("dr_no").ToString 'a(4)
                        a(19) = "N/A" 'a(6)
                        a(25) = "N/A" 'a(5)

                    Case "OUT WITHOUT RS AND DR"
                        a(1) = newDR.Item("dr_no").ToString 'a(4)
                        a(19) = "N/A" 'a(6)
                        a(25) = "N/A" 'a(5)

                    Case "IN WITH DR BUT NO RS"
                        a(1) = newDR.Item("dr_no").ToString 'a(4)
                        a(19) = "N/A" 'a(6)
                        a(25) = "N/A" 'a(5)


                    Case "OUT WITH DR BUT NO RS"
                        a(1) = newDR.Item("dr_no").ToString 'a(4)
                        a(19) = "N/A" 'a(6)
                        a(25) = "N/A" 'a(5)

                    Case "IN WITH DR AND WITH RS"
                        a(1) = newDR.Item("dr_no").ToString 'a(4)
                        a(19) = "N/A" 'a(6)
                        a(25) = "N/A" 'a(5)

                    Case "OUT WITH DR AND WITH RS"
                        a(1) = newDR.Item("dr_no").ToString 'a(4)
                        a(19) = newDR.Item("WS_NO").ToString 'a(6)
                        a(25) = "N/A" 'a(5)

                    Case "IN WITH RS AND RR BUT NO DR"
                        a(1) = newDR.Item("INVOICE_NO").ToString 'a(4)
                        a(19) = "N/A" 'a(6)
                        a(25) = "rr_no" 'a(5)

                    Case "OUT WITH RS AND WS BUT NO DR"
                        a(1) = newDR.Item("INVOICE_NO").ToString 'a(4)
                        a(19) = newDR.Item("WS_NO").ToString 'a(6)
                        a(25) = "N/A" 'a(5)

                    Case ""
                        If newDR.Item("PO_NO").ToString = "0" Then
                            a(19) = ("N/A")
                        ElseIf newDR.Item("PO_NO").ToString = "" Then
                            a(19) = ("N/A")
                        Else
                            a(19) = newDR.Item("PO_NO").ToString
                        End If

                End Select

                a(25) = IIf(newDR.Item("RR_NO").ToString.ToUpper = "", "N/A", newDR.Item("RR_NO").ToString.ToUpper)

                'If newDR.Item("SORTING").ToString = "A" And a(25) = "N/A" Then

                'End If


                If newDR.Item("IN_OUT").ToString = "OUT" Then

                    If newDR.Item("SORTING").ToString = "A" Then

                        a(26) = CDbl(newDR.Item("qty_OUT").ToString) - count_qty_dr_using_ws_no(ws_no, rs_no, 122, newDR.Item("rs_id").ToString)

                        If FStockCard.count_qty_dr_using_ws_no(ws_no, rs_no, 12) = 0 Then
                            a(26) = CDbl(newDR.Item("qty_OUT").ToString)
                            a(28) = FormatNumber(CDbl(a(26)) * CDbl(a(27)), 2,,, TriState.True)
                        Else
                            a(1) = ""
                            a(5) = ""
                            a(6) = ""
                            a(26) = count_qty_dr_using_ws_no(ws_no, rs_no, 122, newDR.Item("rs_id").ToString) & "/" & CDbl(newDR.Item("qty_OUT").ToString)

                        End If
                    Else
                        a(6) = ""
                        a(26) = newDR.Item("qty_OUT").ToString

                        'total amount
                        a(28) = FormatNumber(CDbl(a(26)) * CDbl(a(27)), 2,,, TriState.True)

                    End If

                ElseIf newDR.Item("IN_OUT").ToString = "IN" Or newDR.Item("IN_OUT").ToString = "OTHERS" Then

                    a(26) = ""
                    a(6) = CDbl(newDR.Item("qty_IN").ToString) '- get_qty_left_from_receiving(newDR.Item("RR_NO").ToString, newDR.Item("rs_id").ToString, 99)

                    'total amount
                    a(28) = FormatNumber(CDbl(a(6)) * CDbl(a(27)), 2,,, TriState.True)

                End If

                If newDR.Item("SORTING").ToString = "AA" Then ' IF AA

                    a(5) = ""

                    If get_qty_left_from_receiving(newDR.Item("RS_NO").ToString, newDR.Item("rs_id").ToString, 100) = 0 Then
                        a(1) = ""
                        a(5) = ""
                        a(6) = CDbl(newDR.Item("qty_IN").ToString) & "/" & CDbl(newDR.Item("qty_IN").ToString)
                        a(26) = ""
                    Else
                        a(1) = ""
                        a(5) = ""
                        a(6) = get_qty_left_from_receiving(newDR.Item("RS_NO").ToString, newDR.Item("rs_id").ToString, 100) & "/" & CDbl(newDR.Item("qty_IN").ToString)
                        a(26) = ""
                    End If
                End If

                Dim lvl As New ListViewItem(a)
                lvl_drList.Items.Add(lvl)


                'If newDR.Item("IN_OUT").ToString = "OUT" Then

                '    lvlDRList.Items(rowcount).BackColor = Color.LightGreen
                '    lvlDRList.Items(rowcount).ForeColor = Color.Black

                'ElseIf newDR.Item("IN_OUT").ToString = "IN" Then

                '    lvlDRList.Items(rowcount).BackColor = Color.YellowGreen
                '    lvlDRList.Items(rowcount).ForeColor = Color.Black

                'ElseIf newDR.Item("IN_OUT").ToString = "OTHERS" Then

                '    lvlDRList.Items(rowcount).BackColor = Color.PaleTurquoise
                '    lvlDRList.Items(rowcount).ForeColor = Color.Black

                'End If

                'If newDR.Item("SORTING").ToString = "AA" Or newDR.Item("SORTING").ToString = "A" Then
                '    If newDR.Item("type_of_delivery").ToString = "WITHOUT DR" Then

                '    Else
                '        Dim result As Double = 0.000

                '        'lvlDRList.Items(rowcount).SubItems(3).Text = ""
                '        If Double.TryParse(a(6), result) = True Then

                '        Else
                '            lvlDRList.Items(rowcount).BackColor = Color.Green
                '            lvlDRList.Items(rowcount).ForeColor = Color.White
                '            lvlDRList.Items(rowcount).Font = New Font(lvlDRList.Font, FontStyle.Bold)
                '        End If

                '        If Double.TryParse(a(26), result) = True Then
                '        Else
                '            lvlDRList.Items(rowcount).BackColor = Color.Green
                '            lvlDRList.Items(rowcount).ForeColor = Color.White
                '            lvlDRList.Items(rowcount).Font = New Font(lvlDRList.Font, FontStyle.Bold)
                '        End If
                '    End If
                'End If

                rowcount += 1
proceedhere:

                Application.DoEvents()
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub CalculateQtyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalculateQtyToolStripMenuItem.Click
        Dim calc As Double = 0

        For Each row As ListViewItem In lvl_drList.Items
            If row.Selected = True Then
                If row.SubItems(16).Text = "IN" Or row.SubItems(16).Text = "OTHERS" Then
                    calc += CDbl(row.SubItems(6).Text)
                Else
                    calc += CDbl(row.SubItems(26).Text)
                End If
            End If
        Next

        MsgBox(calc)

    End Sub

    Private Sub cmbSearchBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearchBy.SelectedIndexChanged
        If cmbSearchBy.Text = "Search by Project/Requestor" Then
            txtSearch.Visible = False
            dtpFrom.Visible = False
            dtpTo.Visible = False
            cmbRequestor.Visible = True
            'load_requestor(cmbRequestor, 14)
            'ElseIf cmbSearchBy.Text = "Search by Project/Requestor" Then
            '    txtSearch.Visible = True
            '    dtpFrom.Visible = True
            '    dtpTo.Visible = True
            '    cmbRequestor.Visible = True
            '    load_requestor(cmbRequestor, 14)

        ElseIf cmbSearchBy.Text = "Search by Warehouse/Stockpile Area" Then
            txtSearch.Visible = True
            dtpFrom.Visible = True
            dtpTo.Visible = True
            cmbRequestor.Visible = True
            load_requestor(cmbRequestor, 15)

        ElseIf cmbSearchBy.Text = "Search by DR Date" Then
            txtSearch.Visible = True
            dtpFrom.Visible = True
            dtpTo.Visible = True
            cmbRequestor.Visible = False

        Else
            cmbRequestor.Visible = False
            dtpFrom.Visible = False
            dtpTo.Visible = False

            txtSearch.Visible = True
            dtpFrom.Visible = False
            dtpTo.Visible = False
        End If

    End Sub
    Public Sub load_requestor(cmb As ComboBox, n As Integer)
        cmb.Items.Clear()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", n)

            Dim newdr As SqlDataReader

            newdr = newCMD.ExecuteReader
            While newdr.Read
                If n = 14 Then
                    If newdr.Item("project_desc").ToString = "" Then

                    Else
                        cmb.Items.Add(newdr.Item("project_desc").ToString)
                    End If
                ElseIf n = 15 Then
                    cmb.Items.Add(newdr.Item("wh_area").ToString)
                End If

            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If

    End Sub

    Private Sub lvlDRList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvl_drList.SelectedIndexChanged

    End Sub


    Public Sub view_report()

        Dim dt As New DataTable

        With dt
            .Columns.Add("dr_no")
            .Columns.Add("rs_no")
            .Columns.Add("date")

        End With

        For i As Integer = 0 To lvl_drList.Items.Count - 1
            dt.Rows.Add(
            lvl_drList.Items(i).SubItems(1).Text, lvl_drList.Items(i).SubItems(2).Text,
            lvl_drList.Items(i).SubItems(3).Text)
        Next

        Dim view As New DataView(dt)

        SAMPLEREPORT.ReportViewer1.LocalReport.DataSources.Item(0).Value = view
        SAMPLEREPORT.ShowDialog()
        SAMPLEREPORT.Dispose()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        view_report()
    End Sub

    Private Sub CMS_lvlDRList_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CMS_lvlDRList.Opening
        'If dr_date.SelectedItems(0).BackColor = Color.Black Then
        '    For Each itm As ToolStripItem In CMS_lvlDRList.Items
        '        itm.Enabled = False
        '    Next
        'Else
        '    For Each itm As ToolStripItem In CMS_lvlDRList.Items
        '        itm.Enabled = True
        '    Next
        'End If
    End Sub

    Private Sub GenerateReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerateReportToolStripMenuItem.Click
        FPreparedbyvb.ShowDialog()
        'FWasteExcemption.ShowDialog()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        For Each row As ListViewItem In FWasteExcemption.lvlListOfAggregates.Items
            MsgBox(row.Text)
        Next
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        'lvl_drList.Items.Clear()
        cmbRequestor.SelectedIndex = -1
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        load_charges_type(ComboBox1.Text, cmbRequestor)
    End Sub

    Public Sub load_charges_type(chargetype As String, cmb As ComboBox)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        cmb.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 43)
            newCMD.Parameters.AddWithValue("@chargestype", chargetype)

            newDR = newCMD.ExecuteReader

            Dim a(10) As String

            While newDR.Read
                cmb.Items.Add(newDR.Item("chargetype").ToString)
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub CheckSelectedToolStripMenuItem_Click(sender As Object, e As EventArgs)
        For Each row As ListViewItem In lvl_drList.Items
            If row.Selected = True Then
                row.Checked = True
            End If
        Next
    End Sub

    Private Sub UncheckSelectedToolStripMenuItem_Click(sender As Object, e As EventArgs)
        For Each row As ListViewItem In lvl_drList.Items
            If row.Selected = True Then
                row.Checked = False
            End If
        Next
    End Sub

    Private Sub CheckSelectedToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CheckSelectedToolStripMenuItem1.Click
        For Each row As ListViewItem In lvl_drList.Items
            If row.Selected = True Then
                row.Checked = True
            End If
        Next
    End Sub

    Private Sub UncheckSelectedsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UncheckSelectedsToolStripMenuItem.Click
        For Each row As ListViewItem In lvl_drList.Items
            If row.Selected = True Then
                row.Checked = False
            End If
        Next
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        For Each row As ListViewItem In lvl_drList.Items
            row.Checked = True
        Next
    End Sub

    Private Sub EditPriceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditPriceToolStripMenuItem.Click

        FEditPrice.txtreceivedby.Text = lvl_drList.SelectedItems(0).SubItems(13).Text
        FEditPrice.ShowDialog()

    End Sub

    Private Sub ExemptionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExemptionToolStripMenuItem.Click

        FAggregates_Exemption.lvl_agg_excemption.Items.Clear()

        For Each row As ListViewItem In lvl_drList.Items
            Dim a(3) As String

            a(0) = row.SubItems(4).Text
            a(1) = row.SubItems(29).Text

            Dim lvl As New ListViewItem(a)

            FAggregates_Exemption.lvl_agg_excemption.Items.Add(lvl)
            FAggregates_Exemption.ShowDialog()

        Next
    End Sub

    Private Sub EditToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem1.Click
        With EditDR

            .cmbOperator.Enabled = False
            .txtSpecificColumn.Enabled = False
            .dtpDrDate.Enabled = True
            editspecificdr = "date"
            .ShowDialog()

        End With


    End Sub

    Private Sub EditOperatorDriverToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditOperatorDriverToolStripMenuItem.Click
        With EditDR

            .cmbOperator.Enabled = True
            .txtSpecificColumn.Enabled = False
            .dtpDrDate.Enabled = False
            editspecificdr = "operator"
            load_operator()

            .ShowDialog()

        End With

    End Sub

    Private Sub load_operator()
        With EditDR
            .cmbOperator.Items.Clear()

            Dim sqlcon As New SQLcon
            Dim sqldr As SqlDataReader
            Dim cmd As SqlCommand

            Try
                sqlcon.connection1.Open()
                publicquery = "SELECT operator_name FROM dboperator ORDER BY operator_name ASC"
                cmd = New SqlCommand(publicquery, sqlcon.connection1)
                sqldr = cmd.ExecuteReader
                While sqldr.Read
                    .cmbOperator.Items.Add(sqldr.Item("operator_name").ToString)
                End While
                sqldr.Close()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                sqlcon.connection1.Close()
            End Try
        End With

    End Sub

    Private Sub PriceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PriceToolStripMenuItem.Click
        With EditDR

            .cmbOperator.Enabled = False
            .txtSpecificColumn.Enabled = True
            .txtSpecificColumn.Clear()
            .dtpDrDate.Enabled = False
            editspecificdr = "price"
            'load_operator()

            .ShowDialog()

        End With
    End Sub

    Private Sub ReceivedByToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReceivedByToolStripMenuItem.Click
        With EditDR

            .cmbOperator.Enabled = False
            .txtSpecificColumn.Enabled = True
            .txtSpecificColumn.Clear()
            .dtpDrDate.Enabled = False
            editspecificdr = "received by"
            'load_operator()

            .ShowDialog()

        End With
    End Sub

    Private Sub ConToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConToolStripMenuItem.Click
        With EditDR

            .cmbOperator.Enabled = False
            .txtSpecificColumn.Enabled = True
            .txtSpecificColumn.Clear()
            .dtpDrDate.Enabled = False
            editspecificdr = "Concession"
            'load_operator()

            .ShowDialog()

        End With
    End Sub

    Private Sub DRNOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DRNOToolStripMenuItem.Click
        With EditDR

            .cmbOperator.Enabled = False
            .txtSpecificColumn.Enabled = True
            .txtSpecificColumn.Clear()
            .dtpDrDate.Enabled = False
            editspecificdr = "drno"

            .ShowDialog()

        End With
    End Sub

    Private Sub PlateNOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlateNOToolStripMenuItem.Click
        With EditDR

            .cmbOperator.Enabled = False
            .txtSpecificColumn.Enabled = True
            .txtSpecificColumn.Clear()
            .dtpDrDate.Enabled = False
            editspecificdr = "plateno"

            .ShowDialog()

        End With
    End Sub

    Private Sub SupplierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupplierToolStripMenuItem.Click
        With EditDR

            .cmbOperator.Enabled = False
            .txtSpecificColumn.Enabled = True
            .txtSpecificColumn.Clear()
            .dtpDrDate.Enabled = False
            editspecificdr = "supplier"

            .ShowDialog()

        End With
    End Sub

    Private Sub cmbRequestor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRequestor.SelectedIndexChanged

    End Sub

    Private Function get_dr1(project As String, n As Integer) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@project", project)
            'newCMD.Parameters.AddWithValue("@rs_no", FSORTBY.txtItemDesc.Text)
            newCMD.Parameters.AddWithValue("@search", FSORTBY.txtItemDesc.Text)
            newCMD.Parameters.AddWithValue("@item_desc", FSORTBY.txtItems.Text)
            newCMD.Parameters.AddWithValue("@inout", FSORTBY.cmbINOUT.Text)
            newCMD.Parameters.AddWithValue("@searchby1", "RS NO")
            newCMD.Parameters.AddWithValue("@datefrom", Date.Parse(FSORTBY.dtpfrom.Text))
            newCMD.Parameters.AddWithValue("@dateto", Date.Parse(FSORTBY.dtpto.Text))
            newCMD.CommandTimeout = 220

            newDR = newCMD.ExecuteReader

            Dim a(35) As String

            While newDR.Read
                a(0) = newDR.Item("dr_items_id").ToString
                a(1) = newDR.Item("dr_no").ToString
                a(2) = newDR.Item("rs_no").ToString
                If newDR.Item("dr_date").ToString = "" Then
                    a(3) = ""
                Else
                    a(3) = Format(Date.Parse(newDR.Item("dr_date").ToString), "MM/dd/yyyy")
                End If

                a(4) = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newDR.Item("item_name").ToString)
                a(29) = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newDR.Item("item_desc").ToString)
                a(5) = newDR.Item("SUPP_SOURCE").ToString
                a(7) = newDR.Item("unit").ToString
                a(8) = newDR.Item("concession_ticket_no").ToString
                a(9) = newDR.Item("DRIVER").ToString
                a(10) = newDR.Item("PROJECT").ToString
                a(11) = newDR.Item("SUPPLIER").ToString 'a(7) source_wh
                a(12) = newDR.Item("checkedBy").ToString
                a(13) = newDR.Item("receivedby").ToString
                a(14) = newDR.Item("dr_info_id").ToString
                a(15) = newDR.Item("rs_id").ToString
                a(16) = newDR.Item("IN_OUT").ToString
                a(19) = newDR.Item("PO_WS_NO").ToString
                a(21) = newDR.Item("remarks").ToString 'a(11) remarks
                a(20) = newDR.Item("par_rr_item_id").ToString
                a(22) = newDR.Item("SUPPLIER").ToString
                a(23) = newDR.Item("username").ToString.ToUpper
                a(24) = newDR.Item("plate_no").ToString
                a(25) = newDR.Item("RR_NO").ToString

                If newDR.Item("unit_price").ToString = "" Then
                    a(27) = 0
                Else
                    a(27) = FormatNumber(CDbl(newDR.Item("unit_price").ToString), 2,,, TriState.True)
                End If

                a(30) = Format(Date.Parse(newDR.Item("date_request").ToString), "MM/dd/yyyy")

                If newDR.Item("IN_OUT").ToString = "OUT" Then
                    a(6) = ""
                    a(26) = newDR.Item("qty").ToString
                    a(28) = FormatNumber(CDbl(a(27)) * CDbl(a(26)), 2,,, TriState.True)

                ElseIf newDR.Item("IN_OUT").ToString = "IN" Or newDR.Item("IN_OUT").ToString = "OTHERS" Then
                    a(6) = newDR.Item("qty").ToString
                    a(26) = ""
                    a(28) = FormatNumber(CDbl(a(27)) * CDbl(a(6)), 2,,, TriState.True)

                End If
                Dim lvl As New ListViewItem(a)
                'FDRLIST.lvl_drList.Items.Add(New ListViewItem(a, lvlgroup))
                lvl_drList.Items.Add(lvl)
                Application.DoEvents()

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Private Sub LoadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadToolStripMenuItem.Click

        'SyncToOracle(ProgressBar1)

    End Sub

    Public Function SyncToOracle(ByRef p_objProgressBar As ProgressBar)

        Dim projcount As Integer

        If cmbRequestor.Text = "" Then
            For Each item As String In ComboBox2.Items
                If item = "" Then

                Else
                    projcount += 1
                End If
            Next
        Else
            projcount = 1
        End If


        Dim projpercent As Double = projcount / 100

        ProgressBar1.Value = 0
        ProgressBar1.Maximum = (projpercent * 100) * 100

        For Each item As String In ComboBox2.Items
            get_dr1(item, 40)
            ProgressBar1.Value += CInt(projpercent * 100)
        Next

        ProgressBar1.Value = ProgressBar1.Maximum

    End Function

    Private Sub lvl_drList_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvl_drList.ColumnClick

        ' If current column is not the previously clicked column
        ' Add
        If Not e.Column = sortColumn Then

            ' Set the sort column to the new column
            sortColumn = e.Column

            'Default to ascending sort order
            lvl_drList.Sorting = SortOrder.Ascending

        Else

            'Flip the sort order
            If lvl_drList.Sorting = SortOrder.Ascending Then
                lvl_drList.Sorting = SortOrder.Descending
            Else
                lvl_drList.Sorting = SortOrder.Ascending
            End If
        End If

        'Set the ListviewItemSorter property to a new ListviewItemComparer object
        Me.lvl_drList.ListViewItemSorter = New ListViewItemComparer(e.Column, lvl_drList.Sorting)

        ' Call the sort method to manually sort
        lvl_drList.Sort()

    End Sub

    Private Sub ExportToExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        Dim columns As New List(Of String)
        Dim columncount As Integer = lvl_drList.Columns.Count - 1


        'For i As Integer = 0 To columncount
        '    columns.Add(lvlrequisitionlist.Columns(i).Text)
        'Next


        'For Each columnname In columns
        '    MessageBox.Show(columnname)
        'Next


        Dim SaveFileDialog1 As New SaveFileDialog
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
        Dim row As Integer = 1
        Dim col As Integer = 1
        For Each item As ListViewItem In lvl_drList.Items
            If row = 1 Then
                For i As Integer = 0 To columncount
                    sheet.Cells(row, col) = lvl_drList.Columns(i).Text
                    col = col + 1
                Next
                row = 2
                col = 1
                For i As Integer = 0 To item.SubItems.Count - 1
                    sheet.Cells(row, col) = item.SubItems(i).Text
                    col = col + 1
                Next
            Else
                For i As Integer = 0 To item.SubItems.Count - 1
                    sheet.Cells(row, col) = item.SubItems(i).Text
                    col = col + 1
                Next
            End If
            row += 1
            col = 1
        Next
        'save the workbook and clean up
        book.SaveAs(SaveFileDialog1.FileName)
        xls.Workbooks.Close()
        xls.Quit()
        releaseObject(sheet)
        releaseObject(book)
        releaseObject(xls)
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

    Private Sub DateSubmittedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DateSubmittedToolStripMenuItem.Click
        With EditDR

            .cmbOperator.Enabled = False
            .txtSpecificColumn.Enabled = False
            .dtpDrDate.Enabled = True
            editspecificdr = "date-submitted"
            .ShowDialog()

        End With
    End Sub
End Class
