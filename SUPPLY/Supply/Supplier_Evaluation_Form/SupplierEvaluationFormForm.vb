Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Globalization
Imports Microsoft.Office.Interop
Public Class SupplierEvaluationFormForm
    Public SQ As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Public public_query As String
    Dim list_name_operator As New List(Of List(Of String))
    Dim list_supplier_name As New List(Of List(Of String))
    Dim rate_1 As Double = 0.3
    Dim rate_2 As Double = 0.2
    Dim rate_3 As Double = 0.15
    Dim rate_4 As Double = 0.15
    Dim rate_5 As Double = 0.1
    Dim rate_6 As Double = 0.1
    Dim totals As Double
    Public checkbox_relayed As String = ""


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Dispose()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub SupplierEvaluationFormForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        supplier_name()
        load_late_rs_logs()
    End Sub

    Private Sub cmbequip_no_SelectedIndexChanged(sender As Object, e As EventArgs) Handles evaluated_by.SelectedIndexChanged

    End Sub
    Private Sub sup_name_TextChanged(sender As Object, e As EventArgs) Handles sup_name.TextChanged

    End Sub

    Private Sub TextBox17_TextChanged(sender As Object, e As EventArgs) Handles TextBox17.TextChanged

    End Sub
    Public Sub supplier_name()
        list_supplier_name = New List(Of List(Of String))
        Dim row As Integer
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_supplier_evaluation"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 1)
            dr = sqlcomm.ExecuteReader

            While dr.Read
                list_supplier_name.Add(New List(Of String))
                list_supplier_name(row).Add(dr.Item(0).ToString)
                list_supplier_name(row).Add(dr.Item(1).ToString)
                row = row + 1
            End While

            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

        Dim txt_row As New AutoCompleteStringCollection

        For Each list_row As List(Of String) In list_supplier_name
            txt_row.Add(list_row(1))
        Next


        sup_name.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        sup_name.AutoCompleteSource = AutoCompleteSource.CustomSource
        sup_name.AutoCompleteCustomSource = txt_row


    End Sub


    Private Sub sup_id_Click(sender As Object, e As EventArgs)

    End Sub

    Function get_sup_id(ByVal supplierName As String) As Integer
        Try
            SQ.connection.Open()
            public_query = "SELECT Supplier_Id FROM dbSupplier WHERE Supplier_name = '" & supplierName & "'"
            cmd = New SqlCommand(public_query, SQ.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                get_sup_id = dr.Item(0).ToString
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

    End Function


    Private Sub sup_name_Leave(sender As Object, e As EventArgs) Handles sup_name.Leave
        'TextBox17.Text = get_sup_id(sup_name.Text)
        'get_transac_or_deliveries()

    End Sub

    Public Sub all_transactions1()
        Dim supplier_id = TextBox17.Text
        Try
            SQ.connection.Open()
            public_query = "select COUNT(*) as count
		                      FROM dbrequisition_slip b
		                      LEFT JOIN dbPO_details a ON a.rs_id = b.rs_id 
		                      LEFT JOIN dbPO j ON j.po_id = a.po_id 
		                      LEFT JOIN dbSupplier k ON k.Supplier_Id = a.supplier_id 
		                      LEFT join dbreceiving_items f ON f.po_det_id = a.po_det_id 
		                      LEFT JOIN dbreceiving_info g ON g.rr_info_id = f.rr_info_id 
                              
                              LEFT join rs_tor_sub_property c ON c.rs_id = b.rs_id
							  LEFT join dbType_of_Request_sub d ON d.tor_sub_id = c.tor_sub_id
							  LEFT join dbwarehouse_items e ON a.wh_id = e.wh_id	
							  left join dbreceiving_item_partially i ON i.rr_item_id = f.rr_item_id	
							  left join dbreceiving_items_sub h ON f.rr_item_id = h.rr_item_id
							  left join dbMultipleCharges l ON l.rs_id = b.rs_id 

		                      WHERE (f.rs_id is not null) AND b.type_of_purchasing = 'PURCHASE ORDER'
		
		                      AND k.supplier_id = '" & supplier_id & "'
		                      AND j.po_date BETWEEN '" & DateTimePicker2.Text & "' AND '" & DateTimePicker1.Text & "'
		                      AND g.date_received BETWEEN '" & DateTimePicker2.Text & "' AND '" & DateTimePicker1.Text & "'"


            'public_query = "SELECT COUNT(*) AS count 
            '                    FROM dbreceiving_info 
            '                    WHERE supplier_id = '" & supplier_id & "' and date_received between '" & DateTimePicker2.Text & "' AND '" & DateTimePicker1.Text & "'"
            cmd = New SqlCommand(public_query, SQ.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                If supplier_id = "0" Then
                    transactions.Text = 0
                    'no_deliveries.Text = 0
                Else
                    transactions.Text = dr.Item(0).ToString
                    'no_deliveries.Text = dr.Item(0).ToString
                End If

            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Public Sub get_transac_or_deliveries()
        Dim supplier_id = TextBox17.Text
        Try
            SQ.connection.Open()
            public_query = "select COUNT(*) as count
		                      FROM dbrequisition_slip b
		                      LEFT JOIN dbPO_details a ON a.rs_id = b.rs_id 
		                      LEFT JOIN dbPO j ON j.po_id = a.po_id 
		                      LEFT JOIN dbSupplier k ON k.Supplier_Id = a.supplier_id 
		                      LEFT join dbreceiving_items f ON f.po_det_id = a.po_det_id 
		                      LEFT JOIN dbreceiving_info g ON g.rr_info_id = f.rr_info_id 

                              LEFT join rs_tor_sub_property c ON c.rs_id = b.rs_id
							  LEFT join dbType_of_Request_sub d ON d.tor_sub_id = c.tor_sub_id
							  LEFT join dbwarehouse_items e ON a.wh_id = e.wh_id	
							  left join dbreceiving_item_partially i ON i.rr_item_id = f.rr_item_id	
							  left join dbreceiving_items_sub h ON f.rr_item_id = h.rr_item_id
							  left join dbMultipleCharges l ON l.rs_id = b.rs_id 

		                      WHERE (f.rs_id is not null) AND b.type_of_purchasing = 'PURCHASE ORDER'
		
		                      AND k.supplier_id = '" & supplier_id & "'
		                      AND j.po_date BETWEEN '" & DateTimePicker2.Text & "' AND '" & DateTimePicker1.Text & "'
		                      AND g.date_received BETWEEN '" & DateTimePicker2.Text & "' AND '" & DateTimePicker1.Text & "' and f.remarks NOT LIKE 'L%'"


            'public_query = "SELECT COUNT(*) AS count 
            '                    FROM dbreceiving_info 
            '                    WHERE supplier_id = '" & supplier_id & "' and date_received between '" & DateTimePicker2.Text & "' AND '" & DateTimePicker1.Text & "'"
            cmd = New SqlCommand(public_query, SQ.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                If supplier_id = "0" Then
                    'transactions.Text = 0
                    no_deliveries.Text = 0
                Else
                    'transactions.Text = dr.Item(0).ToString
                    no_deliveries.Text = dr.Item(0).ToString
                End If

            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox4_Leave(sender As Object, e As EventArgs) Handles TextBox4.Leave
        Try
            TextBox10.Text = rate_1 * TextBox4.Text
            totals = TextBox10.Text
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox5_Leave(sender As Object, e As EventArgs) Handles TextBox5.Leave
        Try
            TextBox11.Text = rate_2 * TextBox5.Text
            totals = totals + TextBox11.Text
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox6_Leave(sender As Object, e As EventArgs) Handles TextBox6.Leave
        Try
            TextBox12.Text = rate_3 * TextBox6.Text
            totals = totals + TextBox12.Text
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox7_Leave(sender As Object, e As EventArgs) Handles TextBox7.Leave
        Try
            TextBox13.Text = rate_4 * TextBox7.Text
            totals = totals + TextBox13.Text
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox8_Leave(sender As Object, e As EventArgs) Handles TextBox8.Leave
        Try
            TextBox14.Text = rate_5 * TextBox8.Text
            totals = totals + TextBox14.Text
        Catch ex As Exception

        End Try


    End Sub

    Private Sub TextBox9_Leave(sender As Object, e As EventArgs) Handles TextBox9.Leave
        Try
            TextBox15.Text = rate_6 * TextBox9.Text
            totals = totals + TextBox15.Text
            total_score.Text = totals
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Submit" Then
            If LlbTitleAllowanceSummary.Text = "SERVICE PROVIDER EVALUATION" Then
                'this is for service provider evaluation
                MsgBox("this is service provider evaluation")
                Dim inputDateFrom As String = DateTimePicker2.Text
                Dim inputDateTo As String = DateTimePicker1.Text
                Dim inputDateCom As String = DateTimePicker3.Text
                Dim parsedDateFrom As DateTime = DateTime.ParseExact(inputDateFrom, "MM/dd/yyyy", Nothing)
                Dim formattedDateFrom As String = parsedDateFrom.ToString("MMMM dd, yyyy")

                Dim parsedDateTo As DateTime = DateTime.ParseExact(inputDateTo, "MM/dd/yyyy", Nothing)
                Dim formattedDateTo As String = parsedDateTo.ToString("MMMM dd, yyyy")
                eva_date_period.Text = formattedDateFrom + " - " + formattedDateTo

                Dim parsedDateCom As DateTime = DateTime.ParseExact(inputDateCom, "MM/dd/yyyy", Nothing)
                Dim formattedDateCom As String = parsedDateCom.ToString("MMMM dd, yyyy")
                date_com.Text = formattedDateCom
                preview_evaluation_report()
                clear_rate2()
                total_score.Text = ""
                TextBox17.Text = get_sup_id(sup_name.Text)
                get_transac_or_deliveries()
                get_late_delivery()


            Else
                'this is for supplier evaluation
                Dim inputDateFrom As String = DateTimePicker2.Text
                Dim inputDateTo As String = DateTimePicker1.Text
                Dim inputDateCom As String = DateTimePicker3.Text
                Dim parsedDateFrom As DateTime = DateTime.ParseExact(inputDateFrom, "MM/dd/yyyy", Nothing)
                Dim formattedDateFrom As String = parsedDateFrom.ToString("MMMM dd, yyyy")

                Dim parsedDateTo As DateTime = DateTime.ParseExact(inputDateTo, "MM/dd/yyyy", Nothing)
                Dim formattedDateTo As String = parsedDateTo.ToString("MMMM dd, yyyy")
                eva_date_period.Text = formattedDateFrom + " - " + formattedDateTo

                Dim parsedDateCom As DateTime = DateTime.ParseExact(inputDateCom, "MM/dd/yyyy", Nothing)
                Dim formattedDateCom As String = parsedDateCom.ToString("MMMM dd, yyyy")
                date_com.Text = formattedDateCom
                preview_evaluation_report()
                clear_rate2()
                total_score.Text = ""
                TextBox17.Text = get_sup_id(sup_name.Text)
                get_transac_or_deliveries()
                get_late_delivery()

            End If
        End If

    End Sub

    Public Sub save_evaluation()
        Dim delete_stat = "False"
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand()

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_supplier_evaluation"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 2)
            sqlcomm.Parameters.AddWithValue("@sup_id", TextBox17.Text)
            sqlcomm.Parameters.AddWithValue("@product_supplied", TextBox1.Text)
            sqlcomm.Parameters.AddWithValue("@datefrom", DateTime.Parse(DateTimePicker2.Text))
            sqlcomm.Parameters.AddWithValue("@dateto", DateTime.Parse(DateTimePicker1.Text))

            sqlcomm.Parameters.AddWithValue("@transac_no", transactions.Text)
            sqlcomm.Parameters.AddWithValue("@delivery_no", no_deliveries.Text)
            sqlcomm.Parameters.AddWithValue("@criteria_1", TextBox4.Text)
            sqlcomm.Parameters.AddWithValue("@criteria_2", TextBox5.Text)
            sqlcomm.Parameters.AddWithValue("@criteria_3", TextBox6.Text)
            sqlcomm.Parameters.AddWithValue("@criteria_4", TextBox7.Text)
            sqlcomm.Parameters.AddWithValue("@criteria_5", TextBox8.Text)
            sqlcomm.Parameters.AddWithValue("@criteria_6", TextBox9.Text)
            sqlcomm.Parameters.AddWithValue("@criteria_6", TextBox9.Text)
            sqlcomm.Parameters.AddWithValue("@delete_stat", delete_stat)
            sqlcomm.Parameters.AddWithValue("@datecreate", DateTime.Parse(date_now.Text))
            'sqlcomm.Parameters.AddWithValue("@sum_allamt", CDbl(txtAllowanceAmt.Text))

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Public Sub preview_evaluation_report()
        If LlbTitleAllowanceSummary.Text = "SERVICE PROVIDER EVALUATION" Then
            Service_Provider_Evaluation_ReportForm.ShowDialog()
            Service_Provider_Evaluation_ReportForm.Dispose()
        Else
            EvaluationResultView.ShowDialog()
            EvaluationResultView.Dispose()
        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            checkbox_relayed = "True"
        Else
            checkbox_relayed = "False"
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub DateTimePicker1_Leave(sender As Object, e As EventArgs) Handles DateTimePicker1.Leave
        TextBox17.Text = get_sup_id(sup_name.Text)
        get_transac_or_deliveries()
        all_transactions1()
        get_late_delivery()

        If (transactions.Text = 0) Then
            clear_rate()
        Else
            clear_rate_for_new2()
        End If
    End Sub

    Public Sub get_late_delivery()
        Dim supplier_id = TextBox17.Text
        Try
            SQ.connection.Open()
            public_query = "select COUNT(*) as count
		                      FROM dbrequisition_slip b
		                      LEFT JOIN dbPO_details a ON a.rs_id = b.rs_id 
		                      LEFT JOIN dbPO j ON j.po_id = a.po_id 
		                      LEFT JOIN dbSupplier k ON k.Supplier_Id = a.supplier_id 
		                      LEFT join dbreceiving_items f ON f.po_det_id = a.po_det_id 
		                      LEFT JOIN dbreceiving_info g ON g.rr_info_id = f.rr_info_id 

                              LEFT join rs_tor_sub_property c ON c.rs_id = b.rs_id
							  LEFT join dbType_of_Request_sub d ON d.tor_sub_id = c.tor_sub_id
							  LEFT join dbwarehouse_items e ON a.wh_id = e.wh_id	
							  left join dbreceiving_item_partially i ON i.rr_item_id = f.rr_item_id	
							  left join dbreceiving_items_sub h ON f.rr_item_id = h.rr_item_id
							  left join dbMultipleCharges l ON l.rs_id = b.rs_id 
		                      WHERE (f.rs_id is not null) AND b.type_of_purchasing = 'PURCHASE ORDER'
		
		                      AND k.supplier_id = '" & supplier_id & "'
		                      AND j.po_date BETWEEN '" & DateTimePicker2.Text & "' AND '" & DateTimePicker1.Text & "'
		                      AND g.date_received BETWEEN '" & DateTimePicker2.Text & "' AND '" & DateTimePicker1.Text & "'
		                      and f.remarks LIKE 'L%'"

            'public_query = "select COUNT(*) AS count 
            '                 FROM dbrequisition_slip a
            '                 inner join dbreceiving_items b ON a.rs_id = b.rs_id
            '                 inner join dbreceiving_info c ON b.rr_info_id = c.rr_info_id
            '                 inner join dbSupplier d ON c.supplier_id = d.Supplier_Id
            '                 WHERE d.supplier_id = '" & supplier_id & "' and date_received between '" & DateTimePicker2.Text & "' AND '" & DateTimePicker1.Text & "'  and b.remarks LIKE 'L%'"
            cmd = New SqlCommand(public_query, SQ.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                If supplier_id = "0" Then
                    total_late_delevery.Text = 0
                    MsgBox("Supplier Not Exist")
                Else
                    total_late_delevery.Text = dr.Item(0).ToString
                    If total_late_delevery.Text > 20 Then
                        TextBox5.Text = 1
                    ElseIf total_late_delevery.Text >= 11 And total_late_delevery.Text <= 20 Then
                        TextBox5.Text = 2
                    ElseIf total_late_delevery.Text >= 6 And total_late_delevery.Text <= 10 Then
                        TextBox5.Text = 3
                    ElseIf total_late_delevery.Text >= 1 And total_late_delevery.Text <= 5 Then
                        TextBox5.Text = 4
                    ElseIf total_late_delevery.Text = 0 Then
                        TextBox5.Text = 5
                    End If

                    If (transactions.Text = 0) Then
                        clear_rate()
                    End If
                End If

            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    'Public Sub load_criteria()
    '    Try
    '        SQ.connection.Open()
    '        public_query = "SELECT Supplier_Id FROM dbSupplier WHERE Supplier_name = '" & supplierName & "'"
    '        cmd = New SqlCommand(public_query, SQ.connection)
    '        dr = cmd.ExecuteReader
    '        While dr.Read
    '            get_sup_id = dr.Item(0).ToString
    '        End While
    '        dr.Close()


    '    Catch ex As Exception
    '        MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        SQ.connection.Close()
    '    End Try
    'End Sub

    Private Sub load_late_rs_logs() 'for now PROJECT SA'
        DataGridView1.Rows.Clear()
        Dim increment_no As Integer = 1

        Try
            SQ.connection.Open()
            cmd = New SqlCommand("proc_progress_report_data", SQ.connection)
            cmd.Parameters.Clear()
            cmd.CommandTimeout = 0
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@rs_date_log_from", Format(Date.Parse(DateTimePicker2.Value), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@rs_date_log_to", Format(Date.Parse(DateTimePicker1.Value), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@po_date_log_from", Format(Date.Parse(DateTimePicker2.Value), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@po_date_log_to", Format(Date.Parse(DateTimePicker1.Value), "MM/dd/yyyy"))

            cmd.Parameters.AddWithValue("@n", 107) 'SA PROJECT
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                Dim row As New DataGridViewRow()
                DataGridView1.Rows.Add(
                    increment_no.ToString,
                dr("REQUEST").ToString,
                dr("type_name").ToString,
                dr("rs_no").ToString,
                dr("CHARGES").ToString,
                dr("WH_ITEM_NAME").ToString,
                dr("RS_ITEM_DESCRIPTION").ToString,
                dr("requested_by").ToString,
                dr("CASUAL_FACTORS").ToString,
                dr("RS_DATE_LOG").ToString,
                dr("PO_DATE_LOG").ToString,
                dr("days_difference").ToString
            )
                increment_no = increment_no + 1
            End While
            dr.Close()


        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        Finally
            SQ.connection.Close()
        End Try
    End Sub


    Private Sub Report_risk_project_equip_others()
        Dim dtRiskMonitoring_all As New DataTable


        Dim i As Integer = 0

        With dtRiskMonitoring_all
            .Columns.Add("Request")
            .Columns.Add("Category")
            .Columns.Add("Rs")
            .Columns.Add("Charges")
            .Columns.Add("WhItem")
            .Columns.Add("RsItem")
            .Columns.Add("Requestor")
            .Columns.Add("CasualFactor")
            .Columns.Add("RsDateLog")
            .Columns.Add("PoDateLog")
            .Columns.Add("DayDelays")
        End With

        For Each row2 As DataGridViewRow In DataGridView1.Rows
            If row2.Cells(0).Value = True Then
                dtRiskMonitoring_all.Rows.Add(row2.Cells(1).Value, row2.Cells(2).Value,
                           row2.Cells(3).Value, row2.Cells(4).Value, row2.Cells(5).Value,
                           row2.Cells(6).Value, row2.Cells(7).Value, row2.Cells(8).Value,
                           row2.Cells(9).Value, row2.Cells(10).Value, row2.Cells(11).Value)
            End If

        Next
        Dim view_risk As New DataView(dtRiskMonitoring_all)

        EvaluationResultView.ReportViewer1.LocalReport.DataSources.Item(0).Value = view_risk
        EvaluationResultView.ShowDialog()
        EvaluationResultView.Dispose()
    End Sub

    Public Sub clear_rate()
        TextBox16.Text = "N/A"
        TextBox4.Text = "N/A"
        TextBox5.Text = "N/A"
        TextBox6.Text = "N/A"
        TextBox7.Text = "N/A"
        TextBox8.Text = "N/A"
        TextBox9.Text = "N/A"
        TextBox10.Text = "N/A"
        TextBox11.Text = "N/A"
        TextBox12.Text = "N/A"
        TextBox13.Text = "N/A"
        TextBox14.Text = "N/A"
        TextBox15.Text = "N/A"
        total_score.Text = "N/A"
    End Sub
    Public Sub clear_rate2()
        TextBox1.Text = ""
        TextBox16.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
        TextBox13.Text = ""
        TextBox14.Text = ""
        TextBox15.Text = ""
    End Sub

    Public Sub clear_rate_for_new()
        TextBox16.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
        TextBox13.Text = ""
        TextBox14.Text = ""
        TextBox15.Text = ""
    End Sub

    Public Sub clear_rate_for_new2()
        TextBox16.Text = ""
        TextBox4.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
        TextBox13.Text = ""
        TextBox14.Text = ""
        TextBox15.Text = ""
    End Sub
End Class