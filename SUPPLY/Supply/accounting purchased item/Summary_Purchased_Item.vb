Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.ComponentModel

Public Class Summary_Purchased_Item
    Dim tr_no_trigger As Boolean = False
    Dim thread As Threading.Thread
    Dim sqLCON As New SQLcon
    Dim NEWcmd As SqlCommand
    Dim NEWdr As SqlDataReader
    Dim IsFormBeingDragged As Boolean
    Dim drag As Boolean
    Dim MouseDownX As Integer
    Dim MouseDownY As Integer
    Public acc_class As New List(Of List(Of String))
    Public acc_title As New List(Of List(Of String))
    Dim col_supplier As New AutoCompleteStringCollection
    Dim col_charges As New AutoCompleteStringCollection

    Dim list_charge_classification As New List(Of List(Of String))

    Private Sub Summary_Purchased_Item_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Loadsupplier()
        Loadcharges()
        Loadclassification()
        load_charges_classification()
        cmbSupplierName1.AutoCompleteCustomSource = col_supplier

        panel_POdateSearch.Visible = False
        panel_RRdateSearch.Visible = False
        ComboBox1.Enabled = False
        generate_tables(acc_class, "accnt_classification_id", "account_classification", "dbAccount_Classification")
        generate_tables(acc_title, "accnt_title_id", "account_title", "dbAccount_Title")
        btnExit.Visible = False

    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearchMain.Click
        tr_no_trigger = True
        dtgPurchasedItems.Columns(2).ReadOnly = False
        dtgPurchasedItems.Columns(3).ReadOnly = False
        dtgPurchasedItems.Columns(21).ReadOnly = False
        dtgPurchasedItems.Columns(22).ReadOnly = False
        dtgPurchasedItems.Columns(23).ReadOnly = False
        dtgPurchasedItems.Columns(25).ReadOnly = False
        dtgPurchasedItems.Columns(26).ReadOnly = False
        purchase_item(1)
        'set_comboboxes()

    End Sub
    Sub generate_tables(ByVal list As List(Of List(Of String)), ByVal id As String, ByVal col As String, ByVal table As String)
        Dim SQ As New SQLcon
        Dim DR As SqlDataReader
        Dim CMD As SqlCommand
        Dim i As Integer = 0
        Try
            SQ.connection.Open()
            publicquery = "SELECT " & id & ", " & col & " FROM " & table & " ORDER BY " & col & " ASC"
            CMD = New SqlCommand(publicquery, SQ.connection)
            DR = CMD.ExecuteReader
            While DR.Read

                list.Add(New List(Of String))
                list(i).Add(DR.GetValue(0).ToString)
                list(i).Add(DR.GetValue(1).ToString)
                i = i + 1
            End While
            DR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Public Sub Loadsupplier()
        Dim SQ As New SQLcon
        Dim DR As SqlDataReader
        Dim CMD As SqlCommand
        'cmbSupplierName1.Items.Clear()
        Try
            SQ.connection.Open()
            publicquery = "SELECT Supplier_Name FROM dbSupplier ORDER BY Supplier_Name ASC"
            CMD = New SqlCommand(publicquery, SQ.connection)
            DR = CMD.ExecuteReader
            While DR.Read
                col_supplier.Add(DR.Item("Supplier_Name").ToString)
                'cmbSupplierName1.Items.Add(DR.Item("Supplier_Name").ToString)
                cmb_supplierName2.Items.Add(DR.Item("Supplier_Name").ToString)
                ComboBox1.Items.Add(DR.Item("Supplier_Name").ToString)
            End While
            DR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Public Sub Loadcharges()
        Dim SQ As New SQLcon
        Dim DR As SqlDataReader
        Dim CMD As SqlCommand
        'cmbSupplierName1.Items.Clear()
        Try
            SQ.connection.Open()
            publicquery = "select distinct case when type_name = 'WAREHOUSE'
							then (select top 1 aaa.wh_area from [supply_db].[dbo].[dbwh_area] aaa where aaa.wh_area_id = aa.all_charges_id)
						when type_name = 'PROJECT'
							then (select top 1 aaa.project_desc from [eus].[dbo].[dbprojectdesc] aaa where aaa.proj_id = aa.all_charges_id)
						when type_name = 'EQUIPMENT'
							then (select top 1 aaa.plate_no from [eus].[dbo].[dbequipment_list] aaa where aaa.equipListID = aa.all_charges_id)
						else
							(select top 1 aaa.charge_to from [supply_db].[dbo].[dbCharge_to] aaa where aaa.charge_to_id = aa.all_charges_id)
					end as 'data()'
					from [supply_db].[dbo].[dbMultipleCharges] aa order by 'data()'"
            CMD = New SqlCommand(publicquery, SQ.connection)
            DR = CMD.ExecuteReader
            While DR.Read
                ComboBox4.Items.Add(DR.Item(0).ToString)
            End While
            DR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Public Sub Loadclassification()
        Dim SQ As New SQLcon
        Dim DR As SqlDataReader
        Dim CMD As SqlCommand
        'cmbSupplierName1.Items.Clear()
        Try
            SQ.connection.Open()
            publicquery = "SELECT [accnt_classification_id]
                                  ,[account_classification]
                              FROM [supply_db].[dbo].[dbAccount_Classification]
                              where account_classification <> ''
                              order by account_classification"
            CMD = New SqlCommand(publicquery, SQ.connection)
            DR = CMD.ExecuteReader
            While DR.Read
                ComboBox3.Items.Add(DR.Item(1).ToString)
            End While
            DR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Public Sub LoadsAccountTitle()
        Dim SQ As New SQLcon
        Dim DR As SqlDataReader
        Dim CMD As SqlCommand
        'cmbSupplierName1.Items.Clear()
        Try
            SQ.connection.Open()
            publicquery = "SELECT account_title FROM dbAccount_Title ORDER BY account_title ASC"
            CMD = New SqlCommand(publicquery, SQ.connection)
            DR = CMD.ExecuteReader
            While DR.Read
                cmb_supplierName2.Items.Add(DR.Item("account_title").ToString)
            End While
            DR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Public Sub Loadsupplier2()
        Dim SQ As New SQLcon
        Dim DR As SqlDataReader
        Dim CMD As SqlCommand
        'cmbSupplierName1.Items.Clear()
        Try
            SQ.connection.Open()
            publicquery = "SELECT Supplier_Name FROM dbSupplier ORDER BY Supplier_Name ASC"
            CMD = New SqlCommand(publicquery, SQ.connection)
            DR = CMD.ExecuteReader
            While DR.Read
                ComboBox1.Items.Add(DR.Item("Supplier_Name").ToString)
            End While
            DR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub cmbSearchby_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearchby.SelectedIndexChanged
        'If cmbSearchby.Text = "Search By Supplier" Then
        '    btnSearchBy.Enabled = False
        '    cmb_supplierName2.Enabled = True
        'Else
        '    'btnSearchBy.Enabled = True
        '    panel_POdateSearch.Visible = True
        '    cmb_supplierName2.Enabled = False

        'End If
        If cmbSearchby.Text = "Search By Supplier" Then
            cmb_supplierName2.Enabled = True
            btnSearchBy.Enabled = True
            panel_POdateSearch.Visible = False
            ComboBox1.Enabled = False
            ComboBox2.Enabled = True
        ElseIf cmbSearchby.Text = "Search By All" Then
            cmb_supplierName2.Enabled = False
            btnSearchBy.Enabled = True
            panel_POdateSearch.Visible = False
            ComboBox1.Enabled = False
            'ComboBox2.Enabled = True
        ElseIf cmbSearchby.Text = "Search By Date Paid" Then
            cmb_supplierName2.Enabled = False
            btnSearchBy.Enabled = False
            Label7.Text = "Date Paid:"
            panel_POdateSearch.Visible = True
            btnSave.Text = "Preview Report"
            ComboBox1.Enabled = False
            ComboBox2.Enabled = True
        ElseIf cmbSearchby.Text = "Search By Account Title" Then
            cmb_supplierName2.Items.Clear()
            cmb_supplierName2.Enabled = True
            ComboBox1.Enabled = True
            LoadsAccountTitle()
            Loadsupplier2()
            btnSearchBy.Enabled = True
            panel_POdateSearch.Visible = False
            ComboBox2.Enabled = True
        ElseIf cmbSearchby.Text = "Search By Supplier and Charges" Then
            cmb_supplierName2.Enabled = True
            btnSearchBy.Enabled = True
            panel_POdateSearch.Visible = False
            ComboBox1.Enabled = False
            ComboBox2.Enabled = True

        Else
            cmb_supplierName2.Enabled = False
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            panel_POdateSearch.Visible = True
        End If
        dtgPurchasedItems.Columns(2).ReadOnly = True
        dtgPurchasedItems.Columns(3).ReadOnly = True
        dtgPurchasedItems.Columns(21).ReadOnly = True
        dtgPurchasedItems.Columns(22).ReadOnly = True
        dtgPurchasedItems.Columns(23).ReadOnly = True
        dtgPurchasedItems.Columns(25).ReadOnly = True
        dtgPurchasedItems.Columns(26).ReadOnly = True
    End Sub

    Public Sub purchase_item(ByVal n)

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim count As Integer = 0
        Dim i As Integer = 0
        Dim tmp_inv_classification As String = ""
        Dim tmp_accnt_title As String = ""
        Dim new_inv_classification As Boolean = True
        Dim new_accnt_title As Boolean = True
        Dim total_amt As Decimal = 0
        Dim row_count As Integer = 0
        dtgPurchasedItems.Rows.Clear()

        Try
            newSQ.connection.Open()

            newCMD = New SqlCommand("proc_purchased_items", newSQ.connection)
            newCMD.CommandTimeout = 0
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.Add("@n", SqlDbType.NVarChar).Value = n

            If n = 1 Then
                newCMD.Parameters.Add("@invoiceNo", SqlDbType.NVarChar).Value = txtbox_trNo.Text
                newCMD.Parameters.Add("@supplier_name", SqlDbType.NVarChar).Value = cmbSupplierName1.Text
                newCMD.Parameters.Add("@in_year", SqlDbType.NVarChar).Value = TextBox1.Text
            ElseIf n = 2 Then
                newCMD.Parameters.Add("@supplier_name", SqlDbType.NVarChar).Value = cmb_supplierName2.Text
                newCMD.Parameters.Add("@datefrom", SqlDbType.NVarChar).Value = dtp_poDate_From.Value.ToString("yyyy-MM-dd")
                newCMD.Parameters.Add("@dateto", SqlDbType.NVarChar).Value = dtp_poDate_To.Value.ToString("yyyy-MM-dd")
                newCMD.Parameters.Add("@datefrom_received", SqlDbType.NVarChar).Value = dtp_from_received.Value.ToString("yyyy-MM-dd")
                newCMD.Parameters.Add("@dateto_received", SqlDbType.NVarChar).Value = dtp_to_received.Value.ToString("yyyy-MM-dd")
            ElseIf n = 3 Then
                newCMD.Parameters.Add("@datefrom", SqlDbType.NVarChar).Value = dtp_poDate_From.Value.ToString("yyyy-MM-dd")
                newCMD.Parameters.Add("@dateto", SqlDbType.NVarChar).Value = dtp_poDate_To.Value.ToString("yyyy-MM-dd")
                newCMD.Parameters.Add("@datefrom_received", SqlDbType.NVarChar).Value = dtp_from_received.Value.ToString("yyyy-MM-dd")
                newCMD.Parameters.Add("@dateto_received", SqlDbType.NVarChar).Value = dtp_to_received.Value.ToString("yyyy-MM-dd")
            ElseIf n = 4 Then
                newCMD.Parameters.Add("@date_paid_from", SqlDbType.NVarChar).Value = dtp_poDate_From.Value.ToString("yyyy-MM-dd")
                newCMD.Parameters.Add("@date_paid_to", SqlDbType.NVarChar).Value = dtp_poDate_To.Value.ToString("yyyy-MM-dd")
            ElseIf n = 5 Then
                newCMD.Parameters.Add("@accnt_title", SqlDbType.NVarChar).Value = cmb_supplierName2.Text
                newCMD.Parameters.Add("@supplier_name", SqlDbType.NVarChar).Value = ComboBox1.Text
                newCMD.Parameters.Add("@datefrom", SqlDbType.NVarChar).Value = dtp_poDate_From.Value.ToString("yyyy-MM-dd")
                newCMD.Parameters.Add("@dateto", SqlDbType.NVarChar).Value = dtp_poDate_To.Value.ToString("yyyy-MM-dd")
                newCMD.Parameters.Add("@datefrom_received", SqlDbType.NVarChar).Value = dtp_from_received.Value.ToString("yyyy-MM-dd")
                newCMD.Parameters.Add("@dateto_received", SqlDbType.NVarChar).Value = dtp_to_received.Value.ToString("yyyy-MM-dd")
            ElseIf n = 6 Then
                'newCMD.Parameters.Add("@accnt_title", SqlDbType.NVarChar).Value = cmb_supplierName2.Text
                'newCMD.Parameters.Add("@supplier_name", SqlDbType.NVarChar).Value = ComboBox1.Text
                newCMD.Parameters.Add("@datefrom", SqlDbType.NVarChar).Value = dtp_poDate_From.Value.ToString("yyyy-MM-dd")
                newCMD.Parameters.Add("@dateto", SqlDbType.NVarChar).Value = dtp_poDate_To.Value.ToString("yyyy-MM-dd")
                newCMD.Parameters.Add("@datefrom_received", SqlDbType.NVarChar).Value = dtp_from_received.Value.ToString("yyyy-MM-dd")
                newCMD.Parameters.Add("@dateto_received", SqlDbType.NVarChar).Value = dtp_to_received.Value.ToString("yyyy-MM-dd")
            ElseIf n = 7 Then
                newCMD.Parameters.Add("@charges", SqlDbType.NVarChar).Value = ComboBox4.Text
                newCMD.Parameters.Add("@classification", SqlDbType.NVarChar).Value = ComboBox3.Text
                newCMD.Parameters.Add("@supplier_name", SqlDbType.NVarChar).Value = cmb_supplierName2.Text
                'newCMD.Parameters.Add("@datefrom", SqlDbType.NVarChar).Value = dtp_poDate_From.Value.ToString("yyyy-MM-dd")
                'newCMD.Parameters.Add("@dateto", SqlDbType.NVarChar).Value = dtp_poDate_To.Value.ToString("yyyy-MM-dd")
                newCMD.Parameters.Add("@date_paid_from", SqlDbType.NVarChar).Value = dtp_from_received.Value.ToString("yyyy-MM-dd")
                newCMD.Parameters.Add("date_paid_to", SqlDbType.NVarChar).Value = dtp_to_received.Value.ToString("yyyy-MM-dd")
            End If
            newDR = newCMD.ExecuteReader

            While newDR.Read
                row_count = row_count + 1
                Dim a(50) As String

                a(0) = newDR.Item("rs_id").ToString
                a(1) = newDR.Item("rr_item_id").ToString
                a(2) = newDR.Item("seq_no").ToString
                a(3) = Format(Date.Parse(newDR.Item("date_paid").ToString), "MM/dd/yyyy")
                a(4) = newDR.Item("invoice_no").ToString
                a(5) = Format(Date.Parse(newDR.Item("date_received").ToString), "MM/dd/yyyy")
                a(6) = newDR.Item("rr_no").ToString
                a(7) = Format(Date.Parse(newDR.Item("date_req").ToString), "MM/dd/yyyy")
                a(8) = newDR.Item("rs_no").ToString
                a(9) = Format(Date.Parse(newDR.Item("po_date").ToString), "MM/dd/yyyy")
                a(10) = newDR.Item("po_no").ToString
                a(11) = CDbl(newDR.Item("desired_qty").ToString)
                a(12) = newDR.Item("unit").ToString
                a(13) = newDR.Item("whItem").ToString
                a(14) = newDR.Item("whItemDesc").ToString
                a(15) = newDR.Item("Supplier_Name").ToString
                a(16) = FormatNumber(CDbl(newDR.Item("unit_price").ToString), 2, , , TriState.True)
                a(17) = FormatNumber(newDR.Item("TOTAL_PRICE").ToString, 2, , , TriState.True)

                'a(17) = "TOTAL AMOUNT"
                If n = 7 Then
                    a(19) = newDR.Item("CHARGES").ToString
                Else
                    If newDR.Item("type_name").ToString = "WAREHOUSE" Then
                        a(19) = newDR.Item("CHARGE_TO_WAREHOUSE").ToString
                    ElseIf newDR.Item("type_name").ToString = "PROJECT" Then
                        a(19) = newDR.Item("CHARGE_TO_PROJECT").ToString
                    ElseIf newDR.Item("type_name").ToString = "EQUIPMENT" Then
                        a(19) = newDR.Item("CHARGE_TO_EQUIPMENT").ToString
                    ElseIf newDR.Item("type_name").ToString = "OTHERS" _
                         Or newDR.Item("type_name").ToString = "MAINOFFICE" _
                         Or newDR.Item("type_name").ToString = "PERSONAL" Then
                        a(19) = newDR.Item("CHARGE_TO_PER_MAIN_OTHERS").ToString
                    Else
                        a(19) = ""
                    End If
                End If
                a(19) = newDR.Item("CHARGES").ToString

                a(20) = newDR.Item("typeRequest").ToString

                If cmbSearchby.Text = "Search By Acct. Title & Classification" Then

                    a(21) = newDR.Item("account_title").ToString  ''"ACCOUNT TITLE"
                    a(22) = newDR.Item("account_classification").ToString  ''"CLASSIFICATION"
                End If
                Dim input As String = a(3).Trim()
                Dim result As Date
                If Date.TryParse(input, result) And input <> "01/01/1900" Then
                    a(23) = "PAID"
                Else
                    a(23) = ""
                End If

                a(24) = newDR.Item("AUP_ID").ToString
                a(25) = newDR.Item("rr_item_id_orig").ToString
                a(26) = newDR.Item("aup_id_orig").ToString
                dtgPurchasedItems.Rows.Add(a)

                If ComboBox2.Text = "Invoice" Then

                    If tmp_inv_classification = newDR.Item("invoice_no").ToString Then
                        new_inv_classification = False
                    Else
                        new_inv_classification = True
                        tmp_inv_classification = newDR.Item("invoice_no").ToString
                    End If

                    If new_inv_classification = True Then
                        If (i - 1) > 0 Then
                            dtgPurchasedItems.Rows(i - 1).Cells(18).Value = FormatNumber(total_amt.ToString)
                        End If
                        total_amt = CDbl(newDR.Item("TOTAL_PRICE").ToString)
                    Else
                        total_amt = total_amt + CDbl(newDR.Item("TOTAL_PRICE").ToString)
                    End If
                ElseIf cmbSearchby.Text = "Search By Acct. Title & Classification" Then
                    If tmp_accnt_title = newDR.Item("account_title").ToString And tmp_inv_classification = newDR.Item("account_classification").ToString Then
                        new_inv_classification = False
                    Else
                        new_inv_classification = True
                        tmp_accnt_title = newDR.Item("account_title").ToString
                        tmp_inv_classification = newDR.Item("account_classification").ToString
                    End If

                    If new_inv_classification = True Then
                        If (i - 1) > 0 Then
                            dtgPurchasedItems.Rows(i - 1).Cells(18).Value = FormatNumber(total_amt.ToString)
                        End If
                        total_amt = CDbl(newDR.Item("TOTAL_PRICE").ToString)
                    Else
                        total_amt = total_amt + CDbl(newDR.Item("TOTAL_PRICE").ToString)
                    End If
                ElseIf tr_no_trigger = True Then
                    If tmp_inv_classification = newDR.Item("invoice_no").ToString Then
                        new_inv_classification = False
                    Else
                        new_inv_classification = True
                        tmp_inv_classification = newDR.Item("invoice_no").ToString
                    End If

                    If new_inv_classification = True Then
                        If (i - 1) > 0 Then
                            dtgPurchasedItems.Rows(i - 1).Cells(18).Value = FormatNumber(total_amt.ToString)
                        End If
                        total_amt = CDbl(newDR.Item("TOTAL_PRICE").ToString)
                    Else
                        total_amt = total_amt + CDbl(newDR.Item("TOTAL_PRICE").ToString)
                    End If

                End If
                Dim int_title As Integer = 0
                Dim int_class As Integer = 0
                If CInt(newDR.Item("acc_title_id").ToString) = 0 Then
                    int_title = get_charges_value(newDR.Item("CHARGES").ToString, 1)
                Else
                    int_title = CInt(newDR.Item("acc_title_id").ToString)
                End If
                If CInt(newDR.Item("acc_class_id").ToString) = 0 Then
                    int_class = get_charges_value(newDR.Item("CHARGES").ToString, 2)
                Else
                    int_class = CInt(newDR.Item("acc_class_id").ToString)
                End If

                set_comboboxes(i, int_title, int_class)
                'set_comboboxes(i, CInt(newDR.Item("acc_title_id").ToString), CInt(newDR.Item("acc_class_id").ToString))
                'If dtgPurchasedItems.Rows(i).Cells(21).Value.Equals("") Then

                'End If
                'If dtgPurchasedItems.Rows(i).Cells(22).Value.Equals("") Then

                'End If

                i = i + 1
            End While
            If tr_no_trigger = True And i > 0 Then
                dtgPurchasedItems.Rows(i - 1).Cells(18).Value = FormatNumber(total_amt.ToString)
                tr_no_trigger = False
            End If
            Dim r As Integer = 0
            If ComboBox2.Text = "Acct. Title & Classification" Then
                dtgPurchasedItems.Sort(dtgPurchasedItems.Columns(22), ListSortDirection.Ascending)

                While r < dtgPurchasedItems.RowCount

                    'MessageBox.Show(dtgPurchasedItems.Rows(r).Cells(22).Value)

                    If tmp_inv_classification = dtgPurchasedItems.Rows(r).Cells(22).Value Then
                        new_inv_classification = False
                    Else
                        new_inv_classification = True
                        tmp_inv_classification = dtgPurchasedItems.Rows(r).Cells(22).Value
                    End If

                    If new_inv_classification = True Then
                        If (r - 1) >= 0 Then
                            dtgPurchasedItems.Rows(r - 1).Cells(18).Value = FormatNumber(total_amt.ToString)
                        End If
                        total_amt = CDbl(dtgPurchasedItems.Rows(r).Cells(17).Value)

                    Else
                        total_amt = total_amt + CDbl(dtgPurchasedItems.Rows(r).Cells(17).Value)

                    End If

                    r = r + 1
                End While
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'jimmy added 041723
            If ComboBox2.Text = "Acct. Title Only" Then
                dtgPurchasedItems.Sort(dtgPurchasedItems.Columns(21), ListSortDirection.Ascending)

                While r < dtgPurchasedItems.RowCount

                    'MessageBox.Show(dtgPurchasedItems.Rows(r).Cells(22).Value)

                    If tmp_accnt_title = dtgPurchasedItems.Rows(r).Cells(21).Value Then
                        new_accnt_title = False
                    Else
                        new_accnt_title = True
                        tmp_accnt_title = dtgPurchasedItems.Rows(r).Cells(21).Value
                    End If

                    If new_accnt_title = True Then
                        If (r - 1) >= 0 Then
                            dtgPurchasedItems.Rows(r - 1).Cells(18).Value = FormatNumber(total_amt.ToString)
                        End If
                        total_amt = CDbl(dtgPurchasedItems.Rows(r).Cells(17).Value)

                    Else
                        total_amt = total_amt + CDbl(dtgPurchasedItems.Rows(r).Cells(17).Value)

                    End If

                    r = r + 1
                End While
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If ComboBox2.Text = "Invoice" Or cmbSearchby.Text = "Search By Acct. Title & Classification" Or cmbSearchby.Text = "Search By Supplier" Then
                If (i - 1) > 0 Then
                    dtgPurchasedItems.Rows(i - 1).Cells(18).Value = FormatNumber(total_amt.ToString)
                End If
            Else
                If (r - 1) > 0 Then
                    dtgPurchasedItems.Rows(r - 1).Cells(18).Value = FormatNumber(total_amt.ToString)
                End If
            End If

            newDR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If row_count = 0 Then
                Panel8.Visible = True
            Else
                Panel8.Visible = False
            End If
            newSQ.connection.Close()
        End Try

    End Sub

    Private Sub dtgPurchasedItems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgPurchasedItems.CellClick
        'If (e.ColumnIndex = 1) Then
        '    tmp_seq_num = dtgPurchasedItems.CurrentCell.Value
        'End If

        If (e.ColumnIndex = 3) And dtgPurchasedItems.Columns(3).ReadOnly = False Then
            summary_date_time_picker.datagridcell = dtgPurchasedItems
            summary_date_time_picker.ShowDialog()
        End If

    End Sub

    Sub set_comboboxes(ByVal row_num As Integer, ByVal acc_tit_id As Integer, ByVal acc_cla_id As Integer)
        Dim comboBoxCell1 As DataGridViewComboBoxCell
        Dim comboBoxCell2 As DataGridViewComboBoxCell
        'For Each row As DataGridViewRow In dtgPurchasedItems.Rows
        comboBoxCell1 = dtgPurchasedItems.Rows(row_num).Cells(21)
        comboBoxCell2 = dtgPurchasedItems.Rows(row_num).Cells(22)


        For Each item As List(Of String) In acc_title
            comboBoxCell1.Items.Add(item(1))
            If item(0) = acc_tit_id Then
                dtgPurchasedItems.Rows(row_num).Cells(21).Value = item(1)
            End If
        Next
        For Each item As List(Of String) In acc_class
            comboBoxCell2.Items.Add(item(1))
            If item(0) = acc_cla_id Then
                dtgPurchasedItems.Rows(row_num).Cells(22).Value = item(1)
            End If
        Next
        If acc_tit_id = 0 And acc_cla_id = 0 Then
            dtgPurchasedItems.Rows(row_num).Cells(21).Value = ""
            dtgPurchasedItems.Rows(row_num).Cells(22).Value = ""
        End If
        'Next
    End Sub

    Sub addAccounting_Update_Purchased(ByVal rs_id As Integer, ByVal rr_item_id As Integer, ByVal seq_no As Integer, ByVal date_paid As DateTime, ByVal acc_title_id As Integer, ByVal acc_class_id As Integer, ByVal remarks As String)
        Dim SQ As New SQLcon
        Dim CMD As SqlCommand

        Try
            SQ.connection.Open()
            publicquery = "insert into dbAccounting_Update_Purchased (rs_id
                                                                    , rr_item_id
                                                                    , seq_no
                                                                    , date_paid
                                                                    , account_title_id
                                                                    , account_classification_id
                                                                    , remarks) 
                                                            values (" & rs_id & "
                                                                    , " & rr_item_id & "                    
                                                                    , " & seq_no & "
                                                                    , '" & date_paid & "'
                                                                    , " & acc_title_id & "
                                                                    , " & acc_class_id & "
                                                                    , '" & remarks & "')"
            CMD = New SqlCommand(publicquery, SQ.connection)
            CMD.ExecuteReader()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Sub editAccounting_Update_Purchased(ByVal rs_id As Integer, ByVal rr_item_id As Integer, ByVal aup_id As Integer, ByVal seq_no As Integer, ByVal date_paid As DateTime, ByVal acc_title_id As Integer, ByVal acc_class_id As Integer, ByVal remarks As String)
        Dim SQ As New SQLcon
        Dim CMD As SqlCommand

        Try
            SQ.connection.Open()

            publicquery = "update dbAccounting_Update_Purchased set rs_id = " & rs_id & "
                                                                    , rr_item_id = " & rr_item_id & "                                                            
                                                                    , seq_no = " & seq_no & "
                                                                    , date_paid = '" & date_paid & "'
                                                                    , account_title_id = " & acc_title_id & "
                                                                    , account_classification_id = " & acc_class_id & "
                                                                    , remarks = '" & remarks & "'
                                                                    where rr_item_id = " & rr_item_id & " "
            'where accntng_update_purchased_id = " & aup_id & " AND rs_id = " & rs_id & " "
            'where accntng_update_purchased_id = " & aup_id & " and rr_item_id = " & rr_item_id & ""
            CMD = New SqlCommand(publicquery, SQ.connection)
            CMD.ExecuteReader()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.Text = "Save" Then
            If check_if_rows_ready_Saving() = True Then
                For Each row As DataGridViewRow In dtgPurchasedItems.Rows
                    If row.Cells(24).Value.Equals("") Then
                        Dim rs_id As Integer = CInt(row.Cells(0).Value)
                        Dim rr_item_id As Integer = CInt(row.Cells(1).Value)
                        Dim seq_id As Integer = CInt(row.Cells(2).Value)
                        Dim date_paid As DateTime = row.Cells(3).Value
                        Dim acc_title_id As Integer = get_acc_id(acc_title, row.Cells(21).Value)
                        Dim acc_class_id As Integer = get_acc_id(acc_class, row.Cells(22).Value)
                        addAccounting_Update_Purchased(rs_id, rr_item_id, seq_id, date_paid, acc_title_id, acc_class_id, row.Cells(23).Value)

                    End If
                    row.Cells(24).Value = get_aup_id(CInt(row.Cells(0).Value))
                Next
                MsgBox("Data Saved")
            Else
                MsgBox("Some data is missing!")
            End If
        ElseIf btnSave.Text = "Preview Report" Then
            view_report()
        End If



    End Sub

    Public Sub view_report()

        Dim dt As New DataTable

        Dim i As Integer = 0

        With dt
            .Columns.Add("seqNo")
            .Columns.Add("date_paid")
            .Columns.Add("INV")
            .Columns.Add("rr_date")
            .Columns.Add("rrNo")
            .Columns.Add("rs_date")
            .Columns.Add("rs")
            .Columns.Add("po_date")
            .Columns.Add("poNo")
            .Columns.Add("qty")
            .Columns.Add("unit")
            .Columns.Add("itemName")
            .Columns.Add("itemDesc")
            .Columns.Add("supplier")
            .Columns.Add("unit_price")
            .Columns.Add("total_price")
            .Columns.Add("total_amount")
            .Columns.Add("charge_to")
            .Columns.Add("request_type")
            .Columns.Add("account_title")
            .Columns.Add("classification")
            .Columns.Add("remarks")
        End With

        For i = 0 To dtgPurchasedItems.Rows.Count - 1
            dt.Rows.Add(dtgPurchasedItems.Rows(i).Cells(1).Value, dtgPurchasedItems.Rows(i).Cells(2).Value _
           , dtgPurchasedItems.Rows(i).Cells(3).Value, dtgPurchasedItems.Rows(i).Cells(4).Value _
           , dtgPurchasedItems.Rows(i).Cells(5).Value, dtgPurchasedItems.Rows(i).Cells(6).Value _
           , dtgPurchasedItems.Rows(i).Cells(7).Value, dtgPurchasedItems.Rows(i).Cells(8).Value _
           , dtgPurchasedItems.Rows(i).Cells(9).Value, dtgPurchasedItems.Rows(i).Cells(10).Value _
           , dtgPurchasedItems.Rows(i).Cells(11).Value, dtgPurchasedItems.Rows(i).Cells(12).Value _
           , dtgPurchasedItems.Rows(i).Cells(13).Value, dtgPurchasedItems.Rows(i).Cells(14).Value _
           , dtgPurchasedItems.Rows(i).Cells(15).Value, dtgPurchasedItems.Rows(i).Cells(16).Value _
           , dtgPurchasedItems.Rows(i).Cells(17).Value, dtgPurchasedItems.Rows(i).Cells(18).Value _
           , dtgPurchasedItems.Rows(i).Cells(19).Value, dtgPurchasedItems.Rows(i).Cells(20).Value _
           , dtgPurchasedItems.Rows(i).Cells(21).Value, dtgPurchasedItems.Rows(i).Cells(22).Value)
        Next

        'dt.Rows.RemoveAt(dt.Rows.Count - 1)

        Dim viewPurchasedItem As New DataView(dt)

        FSummary_Purchased_Item_Update_viewing.ReportViewer1.LocalReport.DataSources.Item(0).Value = viewPurchasedItem
        FSummary_Purchased_Item_Update_viewing.ShowDialog()
        FSummary_Purchased_Item_Update_viewing.Dispose()

    End Sub

    Function get_aup_id(ByVal rs_id As Integer) As Integer
        Dim SQ As New SQLcon
        Dim CMD As SqlCommand
        Dim DR As SqlDataReader
        Try
            SQ.connection.Open()

            publicquery = "select accntng_update_purchased_id from dbAccounting_Update_Purchased where rs_id = " & rs_id & ""
            CMD = New SqlCommand(publicquery, SQ.connection)
            DR = CMD.ExecuteReader()
            While DR.Read
                Return CInt(DR.Item(0).ToString)
            End While
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Function
    Function get_acc_id(ByVal acc_list As List(Of List(Of String)), ByVal value As String) As Integer
        Dim id As Integer = 0

        For Each item As List(Of String) In acc_list

            If value.Equals(item(1)) Then

                id = Integer.Parse(item(0))
                Exit For
            End If
        Next
        Return id
    End Function

    Function get_acc_value(ByVal acc_list As List(Of List(Of String)), ByVal id As Integer) As String
        Dim value As String = ""

        For Each item As List(Of String) In acc_list
            If id = CInt(item(0)) Then
                value = item(1)
                Exit For
            End If
        Next
        Return value
    End Function

    Function check_if_rows_ready_Saving() As Boolean
        Dim result As Boolean = True
        For Each row As DataGridViewRow In dtgPurchasedItems.Rows
            If row.Cells(2).Value.Equals("") Or
                row.Cells(3).Value.Equals("") Or
                row.Cells(4).Value.Equals("") Or
                row.Cells(21).Value.Equals("") Or
                row.Cells(22).Value.Equals("") Or
                row.Cells(23).Value.Equals("") Then
                result = False
                Exit For
            End If
        Next
        Return result
    End Function

    Function check_if_selected_rows_ready_Saving() As Boolean
        Dim result As Boolean = True
        For Each row As DataGridViewRow In dtgPurchasedItems.SelectedRows
            If row.Cells(0).Value.Equals("") Or
                row.Cells(2).Value.Equals("") Or
                row.Cells(3).Value.Equals("") Or
                row.Cells(4).Value.Equals("") Or
                row.Cells(21).Value.Equals("") Or
                row.Cells(22).Value.Equals("") Or
                row.Cells(23).Value.Equals("") Then
                result = False
                Exit For
            End If
        Next
        Return result
    End Function

    Private Sub dtgPurchasedItems_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs)
        'Dim s As String = dtgPurchasedItems.CurrentCell.Value
        'MsgBox(s)
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Dim remarks As String = "PAID"

        If check_if_selected_rows_ready_Saving() = True Then
            For Each row As DataGridViewRow In dtgPurchasedItems.SelectedRows
                If (row.Cells(24).Value.Equals("")) And (row.Cells(1).Value.Equals("")) Then

                    Dim rs_id As Integer = CInt(row.Cells(0).Value)
                    Dim rr_item_id_orig As Integer = CInt(row.Cells(25).Value)
                    Dim seq_no As Integer = CInt(row.Cells(2).Value)
                    Dim date_paid As DateTime = row.Cells(3).Value
                    Dim acc_title_id As Integer = get_acc_id(acc_title, row.Cells(21).Value)
                    Dim acc_class_id As Integer = get_acc_id(acc_class, row.Cells(22).Value)
                    addAccounting_Update_Purchased(rs_id, rr_item_id_orig, seq_no, date_paid, acc_title_id, acc_class_id, remarks)
                    row.Cells(24).Value = get_aup_id(CInt(row.Cells(0).Value))

                    'MessageBox.Show("Data Save!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'ElseIf (row.Cells(24).Value.Equals("")) And (row.Cells(1).Value.Equals("")) And (row.Cells(26).Value.Equals("") = False) Then ''UPDATE

                    '    Dim aup_id As Integer = CInt(row.Cells(26).Value)
                    '    Dim seq_no As Integer = CInt(row.Cells(2).Value)
                    '    Dim date_paid As DateTime = row.Cells(3).Value
                    '    Dim rs_id As Integer = CInt(row.Cells(0).Value)
                    '    Dim rr_item_id_orig As Integer = CInt(row.Cells(25).Value)
                    '    Dim acc_title_id As Integer = get_acc_id(acc_title, row.Cells(21).Value)
                    '    Dim acc_class_id As Integer = get_acc_id(acc_class, row.Cells(22).Value)
                    '    editAccounting_Update_Purchased(rs_id, rr_item_id_orig, aup_id, seq_no, date_paid, acc_title_id, acc_class_id, remarks)

                    '    MessageBox.Show("Data Updated!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else
                    Dim aup_id As Integer = CInt(row.Cells(24).Value)
                    Dim seq_no As Integer = CInt(row.Cells(2).Value)
                    Dim date_paid As DateTime = row.Cells(3).Value
                    Dim rs_id As Integer = CInt(row.Cells(0).Value)
                    Dim rr_item_id As Integer = CInt(row.Cells(1).Value)
                    Dim acc_title_id As Integer = get_acc_id(acc_title, row.Cells(21).Value)
                    Dim acc_class_id As Integer = get_acc_id(acc_class, row.Cells(22).Value)
                    editAccounting_Update_Purchased(rs_id, rr_item_id, aup_id, seq_no, date_paid, acc_title_id, acc_class_id, remarks)

                    'MessageBox.Show("Data Updatedd!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            Next

            MessageBox.Show("Data Updated!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)

            txtbox_trNo.Focus()

        Else
            MessageBox.Show("Some Data is missing!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub btnProceed_Click(sender As Object, e As EventArgs) Handles btnProceed.Click

        If cmbSearchby.Text = "Search By Supplier" Then
            purchase_item(2)
        ElseIf cmbSearchby.Text = "Search By All" Then
            purchase_item(3)
        ElseIf cmbSearchby.Text = "Search By Account Title" Then
            purchase_item(5)
        ElseIf cmbSearchby.Text = "Search By Acct. Title & Classification" Then
            purchase_item(6)
        ElseIf cmbSearchby.Text = "Search By Supplier and Charges" Then
            If ComboBox4.Text = "" Or ComboBox3.Text = "" Then
                MsgBox("Select Charges or Classification")
            Else
                purchase_item(7)
                lblcharges.Visible = False
                ComboBox4.Visible = False
                Label12.Visible = False
                ComboBox3.Visible = False
                ComboBox2.Items.RemoveAt(2)
                panel_POdateSearch.Visible = False
            End If
        End If
        panel_RRdateSearch.Visible = False
        lblcharges.Visible = False
        ComboBox4.Visible = False
        Label12.Visible = False
        ComboBox3.Visible = False
    End Sub

    Private Sub btnSearch_Click_1(sender As Object, e As EventArgs) Handles btnSearch.Click
        If Label7.Text = "Date Paid:" Then
            purchase_item(4)
            panel_POdateSearch.Visible = False
        Else
            panel_RRdateSearch.Visible = True
            panel_POdateSearch.Visible = False
        End If

    End Sub

    Private Sub btnSearchBy_Click_1(sender As Object, e As EventArgs) Handles btnSearchBy.Click
        If cmbSearchby.Text = "Search By Supplier and Charges" Then
            panel_RRdateSearch.Visible = True
            ComboBox2.Items.Add("Acct. Title Only")
            Label6.Text = "Date Paid:"
            lblcharges.Visible = True
            ComboBox4.Visible = True
            Label12.Visible = True
            ComboBox3.Visible = True
        Else
            Label6.Text = "RECEIVING DATE:"
            Label7.Text = "PURCHASED ORDER DATE:"
            panel_POdateSearch.Visible = True
            lblcharges.Visible = False
            ComboBox4.Visible = False
            Label12.Visible = False
            ComboBox3.Visible = False
        End If

    End Sub

    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        panel_POdateSearch.Visible = False
    End Sub

    Private Sub btn1_exit_Click(sender As Object, e As EventArgs) Handles btn1_exit.Click
        If cmbSearchby.Text = "Search By Supplier and Charges" Then
            ComboBox2.Items.RemoveAt(2)
            cmbSearchby.SelectedIndex = 0
        End If
        panel_RRdateSearch.Visible = False
        lblcharges.Visible = False
        ComboBox4.Visible = False
        Label12.Visible = False
        ComboBox3.Visible = False
    End Sub

    Private Sub Summary_Purchased_Item_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            clear_fields()
        ElseIf e.KeyCode = Keys.Enter Then
            btnSearchMain.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.S Then
            SaveToolStripMenuItem.PerformClick()
        Else
        End If
    End Sub

    Public Sub clear_fields()
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is TextBox Then
                Dim tbox As TextBox = ctr
                tbox.Clear()
            End If
        Next

        cmbSupplierName1.Focus()
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Panel3_KeyDown(sender As Object, e As KeyEventArgs) Handles Panel3.KeyDown
        If e.KeyCode = Keys.Escape Then
            clear_fields()
        ElseIf e.KeyCode = Keys.Enter Then
            btnSearchMain.PerformClick()
        Else
        End If
    End Sub

    Private Sub panel_POdateSearch_Paint(sender As Object, e As PaintEventArgs) Handles panel_POdateSearch.Paint

    End Sub

    Private Sub dtgPurchasedItems_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dtgPurchasedItems.CellLeave
        Console.Write("row:" & e.RowIndex & ", column:" & e.ColumnIndex)
    End Sub

    Private Sub cmbSupplierName1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        export_data()
    End Sub

    Sub export_data()
        Try
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

            Dim chartRange As Excel.Range

            'thread = New Threading.Thread(AddressOf FWarehouseItems.loading)
            'thread.Start()

            'create a workbook and get reference to first worksheet
            xls.Workbooks.Add()
            book = xls.ActiveWorkbook
            sheet = book.ActiveSheet

            'step through rows and columns and copy data to worksheet

            Dim excel_array() As String = New String() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W"}

            sheet.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange, sheet.Range("$A$1:$W$1"), , Excel.XlYesNoGuess.xlYes).Name = "Table1"

            '~~> Format the table
            sheet.ListObjects("Table1").TableStyle = "TableStyleLight9"

            sheet.Cells(1, 2) = "SEQ. NO."
            sheet.Cells(1, 3) = "DATE PAID"
            sheet.Cells(1, 4) = "INV."
            sheet.Cells(1, 5) = "RR DATE"
            sheet.Cells(1, 6) = "RR NO."
            sheet.Cells(1, 7) = "RS DATE"
            sheet.Cells(1, 8) = "RS NO."
            sheet.Cells(1, 9) = "PO DATE"
            sheet.Cells(1, 10) = "PO NO."
            sheet.Cells(1, 11) = "QUANTITY"
            sheet.Cells(1, 12) = "UNIT"
            sheet.Cells(1, 13) = "ITEM NAME"
            sheet.Cells(1, 14) = "DESCRIPTION"
            sheet.Cells(1, 15) = "SUPPLIER NAME"
            sheet.Cells(1, 16) = "UNIT PRICE"
            sheet.Cells(1, 17) = "TOTAL PRICE"
            sheet.Cells(1, 18) = "TOTAL AMOUNT"
            sheet.Cells(1, 19) = "CHARGE TO"
            sheet.Cells(1, 20) = "REQUEST TYPE"
            sheet.Cells(1, 21) = "ACCOUNT TITLE"
            sheet.Cells(1, 22) = "CLASSIFICATION"
            sheet.Cells(1, 23) = "REMARKS"

            'For Each item As ListViewItem In LVLEquipList.Items
            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            Dim row As Integer = 2
            Dim col As Integer = 1
            For Each item As DataGridViewRow In dtgPurchasedItems.Rows
                For i As Integer = 0 To item.Cells.Count - 1
                    If i = 0 Or i = 24 Then
                    Else
                        '  MsgBox(item.SubItems.Count - 1)
                        sheet.Cells(row, col) = item.Cells(i).Value
                        col = col + 1
                    End If
                Next
                row += 1
                col = 1

            Next

            chartRange = sheet.Range(excel_array(0) & 1, excel_array(22) & 1)

            With chartRange
                .HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter
                .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                .Font.Size = 12
                .Font.FontStyle = "Arial"
                .EntireColumn.ColumnWidth = 15

                .Borders(Excel.XlBordersIndex.xlEdgeLeft).Weight = 2
                .Borders(Excel.XlBordersIndex.xlEdgeRight).Weight = 2
                .Borders(Excel.XlBordersIndex.xlEdgeTop).Weight = 2
                .Borders(Excel.XlBordersIndex.xlEdgeBottom).Weight = 2
                .EntireColumn.AutoFit()
            End With

            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            'save the workbook and clean up
            book.SaveAs(SaveFileDialog1.FileName)
            xls.Workbooks.Close()
            xls.Quit()
            releaseObject(sheet)
            releaseObject(book)
            releaseObject(xls)

            'thread.Abort()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub releaseObject(ByVal obj As Object)
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

    Private Sub cmb_supplierName2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_supplierName2.SelectedIndexChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        panel_POdateSearch.Visible = True
    End Sub

    Private Sub cmbSupplierName1_TextChanged(sender As Object, e As EventArgs) Handles cmbSupplierName1.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True

            End If
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        'If ComboBox2.Text = "Acct. Title Only" Then
        '    lblcharges.Visible = True
        '    ComboBox4.Visible = True
        '    Label12.Visible = True
        '    ComboBox3.Visible = True
        'Else
        '    lblcharges.Visible = False
        '    ComboBox4.Visible = False
        '    Label12.Visible = False
        '    ComboBox3.Visible = False
        'End If
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub txtcharges_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtbox_trNo_TextChanged(sender As Object, e As EventArgs) Handles txtbox_trNo.TextChanged

    End Sub

    Private Sub dtgPurchasedItems_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dtgPurchasedItems.CellValueChanged
        If dtgPurchasedItems.Rows.Count > 0 Then
            If e.ColumnIndex = 2 Then

                ' Get the new value from the changed cell
                Dim newValue As String = dtgPurchasedItems.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                'MsgBox(dtgPurchasedItems.Rows(e.RowIndex).Cells(4).Value)
                ' Loop through all the rows to update other cells with the same value in column 5
                For Each row As DataGridViewRow In dtgPurchasedItems.Rows
                    'Skip the current row to avoid changing itself
                    If row.Index <> e.RowIndex Then
                        ' Check if the cell in column 5 matches the condition
                        If row.Cells(4).Value = dtgPurchasedItems.Rows(e.RowIndex).Cells(4).Value Then
                            ' Update the cell in the target column (e.g., column 1) with the new value
                            row.Cells(2).Value = newValue
                        End If
                    End If
                Next
            End If
            If e.ColumnIndex = 3 Then

                ' Get the new value from the changed cell
                Dim newValue As String = dtgPurchasedItems.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                'MsgBox(dtgPurchasedItems.Rows(e.RowIndex).Cells(4).Value)
                ' Loop through all the rows to update other cells with the same value in column 5
                For Each row As DataGridViewRow In dtgPurchasedItems.Rows
                    'Skip the current row to avoid changing itself
                    If row.Index <> e.RowIndex Then
                        ' Check if the cell in column 5 matches the condition
                        If row.Cells(4).Value = dtgPurchasedItems.Rows(e.RowIndex).Cells(4).Value Then
                            ' Update the cell in the target column (e.g., column 1) with the new value
                            row.Cells(3).Value = newValue
                        End If
                    End If
                    Dim input As String = TextBox1.Text.Trim()
                    Dim result As Date
                    If Date.TryParse(newValue, result) Then
                        row.Cells(23).Value = "PAID"
                    End If
                Next
            End If
        End If

    End Sub

    Private Sub AccountTitleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccountTitleToolStripMenuItem.Click
        frmAccountTitle.ShowDialog()
        acc_title.Clear()
        generate_tables(acc_title, "accnt_title_id", "account_title", "dbAccount_Title")
    End Sub

    Private Sub ClassificationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClassificationToolStripMenuItem.Click
        frmClassification.ShowDialog()
        acc_class.Clear()
        generate_tables(acc_class, "accnt_classification_id", "account_classification", "dbAccount_Classification")
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click

    End Sub
    Sub load_charges_classification()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Try
            newSQ.connection.Open()
            Dim query As String = "select
	                                a.account_charges_id
	                                ,b.accnt_classification_id
	                                ,c.accnt_title_id
	                                ,a.account_charge
	                                ,b.account_classification
	                                ,c.account_title
                                from dbAccount_Charges a
                                inner join dbAccount_Classification b on b.account_classification = a.classification
                                left join dbAccount_Title c on c.account_title = a.account_title order by a.account_charge"
            newCMD = New SqlCommand(query, newSQ.connection)
            newCMD.CommandTimeout = 0
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.Text
            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim item As New List(Of String)
                item.Add(newDR.Item("account_charges_id").ToString())
                item.Add(newDR.Item("accnt_title_id").ToString())
                item.Add(newDR.Item("accnt_classification_id").ToString())
                item.Add(newDR.Item("account_charge").ToString())
                item.Add(newDR.Item("account_title").ToString())
                item.Add(newDR.Item("account_classification").ToString())

                list_charge_classification.Add(item)
            End While
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub ChargesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChargesToolStripMenuItem.Click
        frmCharges.ShowDialog()
        load_charges_classification()
    End Sub

    Function get_charges_value(ByVal charge As String, ByVal return_int As Integer) As Integer

        Dim int_val As Integer = 0
        For Each item In list_charge_classification
            If item(3).Equals(charge) Then
                If item(return_int).Equals("") = False Then
                    int_val = CInt(item(return_int))
                End If
                Exit For
            End If
        Next
        Return int_val
    End Function

    Private Sub JournalEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JournalEntryToolStripMenuItem.Click
        frmJournalEntry.ShowDialog()
    End Sub
End Class