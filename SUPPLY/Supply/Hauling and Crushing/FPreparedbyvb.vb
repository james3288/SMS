Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FPreparedbyvb
    Public t As Integer = 0
    Public trd As Threading.Thread
    Dim list_prepared_by As New List(Of String)
    Dim list_noted_by As New List(Of String)
    Private cCustomMsg As New customMessageBox
    Dim dt As New DataTable

    Private Class PrivateProps
        Public Property requestor As String
        Public Property dateServed As DateTime
        Public Property itemName As String
        Public Property qty As Double
        Public Property unit As String
        Public Property dateOfRequest As DateTime
        Public Property rsNo As String
        Public Property source As String
        Public Property unitPrice As Double
        Public Property totalAmount As Double
        Public Property remarks As String
        Public Property stockpile As String
        Public Property plateNo As String
        Public Property drNo As String
        Public Property wsNoPoNo As String
        Public Property supplier As String
        Public Property concession As String

    End Class
    Private Sub BtnPreview_Click(sender As Object, e As EventArgs) Handles BtnPreview.Click
        Dim includeIn As Boolean = False


        If MessageBox.Show("Do you want to preview dr and mark as reported?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            report_dr()
        End If

        If MessageBox.Show("Do you want to include the IN/OTHERS dr?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            includeIn = True
        End If

        dt = New DataTable

        With dt
            .Columns.Add("project")
            .Columns.Add("date_served")
            .Columns.Add("item_name")
            .Columns.Add("quantity")
            .Columns.Add("unit")
            .Columns.Add("date_of_request")
            .Columns.Add("rs_no")
            .Columns.Add("source")
            .Columns.Add("unit_price")
            .Columns.Add("total_amount")
            .Columns.Add("remarks")
            .Columns.Add("stockpile")
            .Columns.Add("plate_no")
            .Columns.Add("dr_no")
            .Columns.Add("ws_no_po_no")
            .Columns.Add("supplier")
            .Columns.Add("concession")
        End With


        If t = 2 Then
            With FDRLIST
                For Each row As ListViewItem In .lvl_drList.Items

                    If row.Checked = False Then

                    Else

                        Dim qty As Double = 0
                        Dim inout As String = row.SubItems(16).Text

                        If inout = "OUT" Then
                            qty = row.SubItems(26).Text
                        ElseIf inout = "IN" Or inout = "OTHERS" Then
                            qty = row.SubItems(6).Text
                        End If

                        dt.Rows.Add(
                        row.SubItems(10).Text,
                        row.SubItems(3).Text,
                        row.SubItems(29).Text,
                        qty,
                        row.SubItems(7).Text,
                        Date.Parse(row.SubItems(30).Text),
                        row.SubItems(2).Text,
                        row.SubItems(5).Text,
                        row.SubItems(27).Text,
                        row.SubItems(28).Text,
                        row.SubItems(21).Text,
                        row.SubItems(36).Text,
                        row.SubItems(24).Text,
                        row.SubItems(1).Text,
                        row.SubItems(19).Text,
                        row.SubItems(22).Text,
                        row.SubItems(8).Text)
                    End If
                Next
            End With

        ElseIf t = 1 Then
            With FDRLIST1
                For Each row As ListViewItem In .lvl_drList.Items
                    If row.Checked = False Then

                    Else

                        'THIS CODE IS FOR CHECKING AGGREGATES DATA TO EXCEMPT
                        For Each row2 In cListOfExemptedAggregates
                            If row2.wh_id = IIf(Not IsNumeric(row.SubItems(35).Text), 0, row.SubItems(35).Text) Then
                                'excempt
                                GoTo proceedhere
                            End If
                        Next

                        If includeIn = True Then
                            If row.SubItems(16).Text = "OUT" Or row.SubItems(16).Text = "IN" Or row.SubItems(16).Text = "OTHERS" Then
                                dt.Rows.Add(
                              row.SubItems(10).Text,
                              row.SubItems(3).Text,
                              row.SubItems(29).Text,
                              IIf(row.SubItems(16).Text = "OTHERS", row.SubItems(6).Text, IIf(row.SubItems(16).Text = "IN", row.SubItems(6).Text, row.SubItems(26).Text)),
                              row.SubItems(7).Text,
                              row.SubItems(30).Text,
                              row.SubItems(2).Text,
                              row.SubItems(5).Text,
                              row.SubItems(27).Text,
                              row.SubItems(28).Text,
                              row.SubItems(21).Text,
                              row.SubItems(36).Text,
                              row.SubItems(24).Text,
                              row.SubItems(1).Text,
                              row.SubItems(19).Text,
                              row.SubItems(22).Text,
                              row.SubItems(8).Text)
                            End If
                        Else
                            If row.SubItems(16).Text = "OUT" Or row.SubItems(16).Text = "OTHERS" Then
                                dt.Rows.Add(
                              row.SubItems(10).Text,
                              row.SubItems(3).Text,
                              row.SubItems(29).Text,
                              IIf(row.SubItems(16).Text = "OTHERS", row.SubItems(6).Text, row.SubItems(26).Text),
                              row.SubItems(7).Text,
                              row.SubItems(30).Text,
                              row.SubItems(2).Text,
                              row.SubItems(5).Text,
                              row.SubItems(27).Text,
                              row.SubItems(28).Text,
                              row.SubItems(21).Text,
                              row.SubItems(36).Text,
                              row.SubItems(24).Text,
                              row.SubItems(1).Text,
                              row.SubItems(19).Text,
                              row.SubItems(22).Text,
                              row.SubItems(8).Text)
                            End If
                        End If


                    End If
proceedhere:

                Next

            End With

        ElseIf t = 3 Then
            '            With FDRLIST2
            '                For Each row As ListViewItem In .lvl_drList.Items
            '                    If row.Checked = False Then

            '                    Else

            '                        'THIS CODE IS FOR CHECKING AGGREGATES DATA TO EXCEMPT
            '                        For Each row2 In cListOfExemptedAggregates
            '                            If row2.wh_id = IIf(Not IsNumeric(row.SubItems(35).Text), 0, row.SubItems(35).Text) Then
            '                                'excempt
            '                                GoTo proceedhere1
            '                            End If
            '                        Next


            '                        Dim stockpile As String = "" 'STOCKPILE
            '                        Dim quarry As String = ""   'QUARRY
            '                        Dim whOptions As String = row.SubItems(38).Text

            '                        stockpile = row.SubItems(36).Text
            '                        quarry = row.SubItems(39).Text

            '                        If includeIn = True Then
            '                            If row.SubItems(16).Text = "OUT" Or row.SubItems(16).Text = "IN" Or row.SubItems(16).Text = "OTHERS" Then
            '                                dt.Rows.Add(
            '                              row.SubItems(10).Text,
            '                              row.SubItems(3).Text,
            '                              row.SubItems(40).Text,'row.SubItems(29).Text,
            '                              IIf(row.SubItems(16).Text = "OTHERS", row.SubItems(6).Text, IIf(row.SubItems(16).Text = "IN", row.SubItems(6).Text, row.SubItems(26).Text)),
            '                              row.SubItems(7).Text,
            '                              row.SubItems(30).Text,
            '                              row.SubItems(2).Text,
            '                             quarry, 'QUARRY CODE
            '                              row.SubItems(27).Text,
            '                              row.SubItems(28).Text,
            '                              row.SubItems(21).Text,
            '                              stockpile, 'STOCKPILE CODE
            '                              row.SubItems(24).Text,
            '                              row.SubItems(1).Text,
            '                              row.SubItems(19).Text,
            '                              row.SubItems(22).Text,
            '                              row.SubItems(8).Text)
            '                            End If
            '                        Else
            '                            If row.SubItems(16).Text = "OUT" Or row.SubItems(16).Text = "OTHERS" Then
            '                                dt.Rows.Add(
            '                              row.SubItems(10).Text,
            '                              row.SubItems(3).Text,
            '                              row.SubItems(40).Text,'row.SubItems(29).Text,
            '                              IIf(row.SubItems(16).Text = "OTHERS", row.SubItems(6).Text, row.SubItems(26).Text),
            '                              row.SubItems(7).Text,
            '                              row.SubItems(30).Text,
            '                              row.SubItems(2).Text,
            '                             quarry, 'QUARRY CODE
            '                              row.SubItems(27).Text,
            '                              row.SubItems(28).Text,
            '                              row.SubItems(21).Text,
            '                              stockpile, 'STOCKPILE CODE
            '                              row.SubItems(24).Text,
            '                              row.SubItems(1).Text,
            '                              row.SubItems(19).Text,
            '                              row.SubItems(22).Text,
            '                              row.SubItems(8).Text)
            '                            End If
            '                        End If


            '                    End If
            'proceedhere1:

            '                Next

            '            End With


            For Each row As ListViewItem In FDRLIST2.lvl_drList.Items
                If row.Checked = True Then
                    If Not excemptAggregates(Utilities.ifBlankReplaceToZero(row.SubItems(35).Text)) Then

                        Dim dataRows As New PropsFields.dr_list_props_fields

                        With dataRows
                            .quarry = row.SubItems(39).Text 'quarry
                            .source = row.SubItems(36).Text 'stockpile
                            .source2 = row.SubItems(41).Text 'source
                            .requestor = row.SubItems(10).Text 'requestor
                            .inout = row.SubItems(16).Text
                            .rs_no = row.SubItems(2).Text
                            .dr_no = row.SubItems(1).Text
                            .dr_date = Utilities.DateConverter(row.SubItems(3).Text)

                        End With

                        '26 - out
                        '6 - in/others

                        If includeIn = True Then
                            If dataRows.inout = cInOut._OUT And row.BackColor = cDrListColor.outWithDR Or
                                 dataRows.inout = cInOut._OUT And row.BackColor = cDrListColor.outWithoutDR Then 'OUT WITH DR or OUT WITHOUT DR

                                Dim c As New PrivateProps
                                With c
                                    .requestor = dataRows.requestor
                                    .dateServed = Format(Utilities.DateConverter(row.SubItems(3).Text), "MM/dd/yyyy")
                                    .itemName = row.SubItems(29).Text
                                    .qty = Utilities.ifBlankReplaceToZero(row.SubItems(26).Text)
                                    .unit = row.SubItems(7).Text
                                    .dateOfRequest = Utilities.DateConverter(row.SubItems(30).Text)
                                    .rsNo = row.SubItems(2).Text


                                    If row.SubItems(2).Text.ToUpper() = cNotApplicable Then
                                        .source = "-"
                                        .stockpile = dataRows.source2
                                    Else
                                        .source = dataRows.quarry
                                        .stockpile = dataRows.source
                                    End If

                                    .unitPrice = ifBlankReplaceToZero(row.SubItems(27).Text)
                                    .totalAmount = ifBlankReplaceToZero(row.SubItems(28).Text)
                                    .remarks = row.SubItems(21).Text

                                    .plateNo = row.SubItems(24).Text
                                    .drNo = row.SubItems(1).Text
                                    .wsNoPoNo = row.SubItems(19).Text
                                    .supplier = row.SubItems(22).Text
                                    .concession = row.SubItems(8).Text

                                End With

                                addDataTable(c)

                            ElseIf dataRows.inout = cInOut._OTHERS And row.BackColor = cDrListColor.othersDR Or
                                dataRows.inout = cInOut._IN And row.BackColor = cDrListColor.inDR Then

                                Dim c As New PrivateProps
                                With c
                                    .requestor = dataRows.requestor
                                    .dateServed = Utilities.DateConverter(row.SubItems(3).Text)
                                    .itemName = row.SubItems(29).Text
                                    .qty = Utilities.ifBlankReplaceToZero(row.SubItems(6).Text)
                                    .unit = row.SubItems(7).Text
                                    .dateOfRequest = Utilities.DateConverter(row.SubItems(30).Text)
                                    .rsNo = row.SubItems(2).Text
                                    .source = dataRows.source2
                                    .unitPrice = ifBlankReplaceToZero(row.SubItems(27).Text)
                                    .totalAmount = ifBlankReplaceToZero(row.SubItems(28).Text)
                                    .remarks = row.SubItems(21).Text
                                    .stockpile = dataRows.source
                                    .plateNo = row.SubItems(24).Text
                                    .drNo = row.SubItems(1).Text
                                    .wsNoPoNo = row.SubItems(19).Text
                                    .supplier = row.SubItems(22).Text
                                    .concession = row.SubItems(8).Text
                                End With

                                addDataTable(c)
                            End If
                        End If
                    End If
                End If
            Next
        End If


        Dim view As New DataView(dt)
        dr_month_export = Date.Parse(dtpMonthOf.Text)

        FHaulingReportView.ReportViewer1.LocalReport.DataSources.Item(0).Value = view
        FHaulingReportView.ShowDialog()
        FHaulingReportView.Dispose()


    End Sub

    Private Sub addDataTable(param As PrivateProps)

        Try
            With param
                dt.Rows.Add(
                            .requestor,
                            .dateServed,
                            .itemName,
                            .qty,
                            .unit,
                            .dateOfRequest,
                            .rsNo,
                            .source,
                            .unitPrice,
                            .totalAmount,
                            .remarks,
                            .stockpile,
                            .plateNo,
                            .drNo,
                            .wsNoPoNo,
                            .supplier,
                            .concession)
            End With

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Function excemptAggregates(whId As Integer) As Boolean
        Try
            'THIS CODE IS FOR CHECKING AGGREGATES DATA TO EXCEMPT
            For Each row2 In cListOfExemptedAggregates
                If row2.wh_id = whId Then
                    'excempt
                    Return True
                    Exit For
                End If
            Next
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Function

    Dim dr As New class_new_dr
    Dim dr_list As New class_new_dr.dr
    Private Sub report_dr()

        With FDRLIST1
            For Each row As ListViewItem In .lvl_drList.Items
                If row.Checked = True Then
                    dr_list.dr_item_id = row.Text
                    dr_list.dr_option = row.SubItems(31).Text
                    dr_list.date_reported = Date.Parse(Now)
                    dr_list.dr_date = Date.Parse(row.SubItems(3).Text)
                    dr.cListOfDr.Add(dr_list)
                End If
            Next
        End With

        insert_into_report_dr()

    End Sub

    Private Sub insert_into_report_dr()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        For Each row In dr.cListOfDr

            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_dr_list2", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 9)
                newCMD.Parameters.AddWithValue("@dr_item_id", row.dr_item_id)
                newCMD.Parameters.AddWithValue("@dr_option", row.dr_option)
                newCMD.Parameters.AddWithValue("@date_reported", row.date_reported)
                newCMD.Parameters.AddWithValue("@date_served", row.dr_date)
                newCMD.Parameters.AddWithValue("@user_id", pub_user_id)

                newCMD.ExecuteNonQuery()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try

        Next

    End Sub

    Private Sub FPreparedbyvb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        save_data_txtbox(1, list_prepared_by) 'load para sa txtbox prepared by
        load_list_txtbox(txtPrepared, list_prepared_by)

        save_data_txtbox(1, list_noted_by)
        load_list_txtbox(txtnoted, list_noted_by)



    End Sub

    Private Sub save_data_txtbox(ByVal value As Integer, ByVal txtbox As List(Of String))
        txtbox.Clear()

        Dim Sql_conn As New SQLcon
        Dim dr1 As SqlDataReader
        Try
            Sql_conn.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = Sql_conn.connection
            sqlcomm.CommandText = "proc_dr_list4"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", value)

            dr1 = sqlcomm.ExecuteReader
            While dr1.Read
                txtbox.Add(dr1.Item("Employee").ToString)
            End While
            dr1.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sql_conn.connection.Close()
        End Try
    End Sub
    Private Sub load_list_txtbox(ByVal obj As TextBox, ByVal txtbox As List(Of String))
        Dim row As New AutoCompleteStringCollection
        For Each item In txtbox
            row.Add(item)
        Next
        obj.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        obj.AutoCompleteSource = AutoCompleteSource.CustomSource
        obj.AutoCompleteCustomSource = row
    End Sub

    Private Sub txtPrepared_TextChanged(sender As Object, e As EventArgs) Handles txtPrepared.TextChanged

    End Sub

    Private Sub txtPrepared_Leave(sender As Object, e As EventArgs) Handles txtPrepared.Leave
        lbl_job_position_prepared_by.Text = get_value_data(2, txtPrepared.Text)
    End Sub
    Private Function get_value_data(ByVal n As Integer, ByVal txtbox As String) As String
        Dim Sql_conn As New SQLcon
        Dim dr1 As SqlDataReader
        Dim result As String = ""
        Try
            Sql_conn.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = Sql_conn.connection
            sqlcomm.CommandText = "proc_dr_list4"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", n)
            sqlcomm.Parameters.AddWithValue("@employee", txtbox)

            dr1 = sqlcomm.ExecuteReader
            While dr1.Read
                result = dr1.Item(1).ToString
            End While
            dr1.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sql_conn.connection.Close()
        End Try

        get_value_data = result
    End Function

    Private Sub txtnoted_TextChanged(sender As Object, e As EventArgs) Handles txtnoted.TextChanged

    End Sub

    Private Sub txtnoted_Leave(sender As Object, e As EventArgs) Handles txtnoted.Leave
        lbl_noted_by.Text = get_value_data(2, txtnoted.Text)
    End Sub
End Class