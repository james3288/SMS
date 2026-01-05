Imports System.ComponentModel
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FEquipment_history_searchby_date
    Public SQLcn As New SQLcon

    Private cListOfEquipmentHistory As New List(Of equipmentHistoryData)
    Private cPlateNo, cCategory, cStoreProcName As String
    Private cDateFrom, cDateTo As DateTime
    Private cN As Integer
    Dim newCatEnum As New CategoryEnum
    Dim newStatEnum As New StatusEnum
    Dim cLoading As Boolean

    Private Class CategoryEnum
        Public ReadOnly Property AllCategory As String = "All Category"
        Public ReadOnly Property EquipmentType As String = "Equipment Type"
        Public ReadOnly Property Salaries As String = "Salaries"
        Public ReadOnly Property Acquisition As String = "Acquisition"
        Public ReadOnly Property Allowances As String = "Allowances"
        Public ReadOnly Property Others As String = "Other Equipment Request"
        Public ReadOnly Property Tires As String = "Tires and Accessories Expense"
        Public ReadOnly Property Rehabilitation As String = "Rehabilitation Expense"
        Public ReadOnly Property Fuel As String = "Fuel Expense"
        Public ReadOnly Property Maintenance As String = "Maintenance Expense"
        Public ReadOnly Property Repair As String = "Repair Expense"
    End Class
    Private Class StatusEnum
        Public ReadOnly Property AllRequest As String = "All Request"
        Public ReadOnly Property ReportedStatus As String = "Reported Status"
        Public ReadOnly Property UnReportedStatus As String = "UnReported Status"
    End Class
    Private Class equipmentHistoryData
        Property dateLog As DateTime
        Property rsNo As String
        Property receivedQty As Double
        Property unit As String
        Property itemName As String
        Property itemDesc As String
        Property requestedBy As String
        Property poNo As String
        Property torSubDesc As String
        Property receivedAmount As Double
        Property plateNo As String
        Property jobOrderNo As String
        Property conductedBy As String
        Property problemEncounter As String
        Property typeOfPurchasing As String
        Property qty As Double

    End Class

    Private Sub btn_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_search.Click

        'BW_loading.WorkerSupportsCancellation = True
        'BW_loading.RunWorkerAsync()

        With FEquipment_history

            'If .cmb_status.Text = "All Request" Then

            'If .cmb_category.Text = "Allowances" Then
            '    get_history_allowance(8)
            'ElseIf .cmb_category.Text = "Salaries" Then
            '    get_history_salaries(344)
            'If .cmb_category.Text = "Fuel" Then
            '    get_history_repair(6)
            'If .cmb_category.Text = "Repair" Then
            '    get_history_repair(22)
            'If .cmb_category.Text = "Equipment Type" Then
            '    get_history_repair(90)

            If .cmb_category.Text = newCatEnum.AllCategory Or
                        .cmb_category.Text = newCatEnum.Others Or
                        .cmb_category.Text = newCatEnum.Salaries Or
                        .cmb_category.Text = newCatEnum.Acquisition Or
                        .cmb_category.Text = newCatEnum.Allowances Or
                        .cmb_category.Text = newCatEnum.Fuel Or
                        .cmb_category.Text = newCatEnum.Repair Or
                        .cmb_category.Text = newCatEnum.Maintenance Or
                        .cmb_category.Text = newCatEnum.Rehabilitation Or
                        .cmb_category.Text = newCatEnum.Tires Or
                        .cmb_category.Text = newCatEnum.EquipmentType Then

                'get_history_repair(500)

                FEquipment_history.dtg_equipmentHistory.Rows.Clear()
                cListOfEquipmentHistory.Clear()

                With FEquipment_history

                    cPlateNo = .cmb_plate_no.Text
                    cCategory = .cmb_category.Text
                    cDateFrom = Date.Parse(dtp_from.Text)
                    cDateTo = Date.Parse(dtp_to.Text)

                    Select Case .cmb_category.Text

                        Case newCatEnum.AllCategory

                            Select Case .cmb_status.Text
                                Case newStatEnum.AllRequest : cN = 500
                                Case newStatEnum.ReportedStatus : cN = 502
                                Case newStatEnum.UnReportedStatus : cN = 503
                            End Select

                            cStoreProcName = "proc_dbequipment_history"

                        Case newCatEnum.Others,
                            newCatEnum.Acquisition,
                            newCatEnum.Maintenance,
                            newCatEnum.Rehabilitation,
                            newCatEnum.Tires

                            Select Case .cmb_status.Text
                                Case newStatEnum.AllRequest : cN = 2
                                Case newStatEnum.ReportedStatus : cN = 300
                                Case newStatEnum.UnReportedStatus : cN = 302
                            End Select

                            cStoreProcName = "proc_dbequipment_history"

                        Case newCatEnum.EquipmentType

                            cN = 90
                            cStoreProcName = "proc_dbequipment_history"

                        Case newCatEnum.Fuel

                            Select Case .cmb_status.Text
                                Case newStatEnum.AllRequest : cN = 6
                                Case newStatEnum.ReportedStatus : cN = 100
                                Case newStatEnum.UnReportedStatus : cN = 102
                            End Select

                            cStoreProcName = "proc_dbequipment_history"

                        Case newCatEnum.Salaries

                            Select Case .cmb_status.Text
                                Case newStatEnum.AllRequest : cN = 344
                                Case newStatEnum.ReportedStatus : cN = 355
                                Case newStatEnum.UnReportedStatus : cN = 366
                            End Select

                            cStoreProcName = "sp_crud_Allowance"

                        Case newCatEnum.Allowances

                            Select Case .cmb_status.Text
                                Case newStatEnum.AllRequest : cN = 8
                                Case newStatEnum.ReportedStatus : cN = 88
                                Case newStatEnum.UnReportedStatus : cN = 882
                            End Select

                            cStoreProcName = "sp_crud_Allowance"

                        Case newCatEnum.Repair

                            Select Case .cmb_status.Text
                                Case newStatEnum.AllRequest : cN = 22
                                Case newStatEnum.ReportedStatus : cN = 200
                                Case newStatEnum.UnReportedStatus : cN = 202
                            End Select

                            cStoreProcName = "proc_dbequipment_history"

                    End Select

                    .Panel4.Visible = True
                End With



                BW_search.WorkerSupportsCancellation = True
                BW_search.RunWorkerAsync()

            Else
                get_history_repair(2)
            End If

            'ElseIf .cmb_status.Text = "Reported Status" Then

            '    If .cmb_category.Text = "Allowances" Then
            '        get_history_allowance(88)
            '    ElseIf .cmb_category.Text = "Salaries" Then
            '        get_history_salaries(355)
            '    ElseIf .cmb_category.Text = "Fuel" Then
            '        get_history_repair(100)
            '    ElseIf .cmb_category.Text = "Repair" Then
            '        get_history_repair(200)
            '    ElseIf .cmb_category.Text = "All Category" Then
            '        get_history_repair(502)
            '    Else
            '        get_history_repair(300)
            '    End If

            'ElseIf .cmb_status.Text = "UnReported Status" Then

            '    If .cmb_category.Text = "Allowances" Then
            '        get_history_allowance(882)
            '    ElseIf .cmb_category.Text = "Salaries" Then
            '        get_history_salaries(366)
            '    ElseIf .cmb_category.Text = "Fuel" Then
            '        get_history_repair(102)
            '    ElseIf .cmb_category.Text = "Repair" Then
            '        get_history_repair(202)
            '    ElseIf .cmb_category.Text = "All Category" Then
            '        get_history_repair(503)
            '    Else
            '        get_history_repair(302)
            '    End If

            'End If

        End With

        Me.Close()



    End Sub

    Public Sub get_history_allowance(ByVal n As Integer)
        FEquipment_history.dtg_equipmentHistory.Rows.Clear()
        Dim newsqlcon As New SQLcon
        Dim newcmd As SqlCommand
        Dim newdr As SqlDataReader
        Dim a(15) As String
        Try
            newsqlcon.connection.Open()
            newcmd = New SqlCommand("sp_crud_Allowance", newsqlcon.connection)
            newcmd.Parameters.Clear()
            newcmd.CommandType = CommandType.StoredProcedure

            newcmd.Parameters.AddWithValue("@n", n)
            newcmd.Parameters.AddWithValue("@from_date", Format(Date.Parse(dtp_from.Value), "MM/dd/yyyy"))
            newcmd.Parameters.AddWithValue("@to_date", Format(Date.Parse(dtp_to.Value), "MM/dd/yyyy"))
            newcmd.Parameters.AddWithValue("@Designation", get_id_Designation(FEquipment_history.cmb_plate_no.Text))

            newdr = newcmd.ExecuteReader

            While newdr.Read

                ' Dim amount_price As Double = newdr.Item("amount").ToString

                a(1) = newdr.Item(1).ToString
                a(1) = Format(Date.Parse(newdr.Item(1).ToString), "MM/dd/yyyy")
                a(2) = "-"
                a(3) = FEquipment_history.cmb_category.Text
                a(4) = FEquipment_history.cmb_plate_no.Text
                a(5) = "-"
                a(6) = "-"
                a(7) = "-"
                a(8) = "-"
                a(9) = "-"
                a(10) = "Allowance"
                a(11) = "-"
                a(12) = newdr.Item(4).ToString
                a(13) = "V.N.: " & newdr.Item(6).ToString
                a(14) = newdr.Item(7).ToString

                FEquipment_history.dtg_equipmentHistory.Rows.Add(a)

            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & ex.StackTrace() & vbCrLf & "Info: " & ex.Message, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
        End Try
    End Sub

    Public Sub get_history_salaries(ByVal n As Integer)
        FEquipment_history.dtg_equipmentHistory.Rows.Clear()
        Dim newsqlcon As New SQLcon
        Dim newcmd As SqlCommand
        Dim newdr As SqlDataReader
        Dim a(15) As String
        Try
            newsqlcon.connection.Open()
            newcmd = New SqlCommand("sp_crud_Allowance", newsqlcon.connection)
            newcmd.Parameters.Clear()
            newcmd.CommandType = CommandType.StoredProcedure

            newcmd.Parameters.AddWithValue("@n", n)
            newcmd.Parameters.AddWithValue("@from_date", Format(Date.Parse(dtp_from.Value), "MM/dd/yyyy"))
            newcmd.Parameters.AddWithValue("@to_date", Format(Date.Parse(dtp_to.Value), "MM/dd/yyyy"))
            newcmd.Parameters.AddWithValue("@Designation", get_id_Designation(FEquipment_history.cmb_plate_no.Text))

            newdr = newcmd.ExecuteReader

            While newdr.Read

                ' Dim amount_price As Double = newdr.Item("amount").ToString

                a(1) = newdr.Item(1).ToString
                a(1) = Format(Date.Parse(newdr.Item(1).ToString), "MM/dd/yyyy")
                a(2) = "-"
                a(3) = FEquipment_history.cmb_category.Text
                a(4) = FEquipment_history.cmb_plate_no.Text
                a(5) = "-"
                a(6) = "-"
                a(7) = "-"
                a(8) = "-"
                a(9) = "-"
                a(10) = "Salaries"
                a(11) = "-"
                a(12) = newdr.Item(4).ToString
                a(13) = "V.N.: " & newdr.Item(6).ToString
                a(14) = newdr.Item(7).ToString

                FEquipment_history.dtg_equipmentHistory.Rows.Add(a)

            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & ex.StackTrace() & vbCrLf & "Info: " & ex.Message, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
        End Try
    End Sub

    Public Function get_id_Designation(ByVal x As String) As Integer
        Dim newsqlcon As New SQLcon
        Dim newcmd As SqlCommand
        Dim newdr As SqlDataReader
        Dim public_query As String
        Try
            newsqlcon.connection1.Open()
            public_query = "SELECT equipListID FROM dbequipment_list WHERE plate_no = '" & x & "'"
            newcmd = New SqlCommand(public_query, newsqlcon.connection1)
            newdr = newcmd.ExecuteReader

            While newdr.Read
                get_id_Designation = newdr.Item(0).ToString
            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection1.Close()
        End Try

    End Function

    Public Sub getEquipmentHistory(n As Integer,
                                   paramPlateNo As String,
                                   paramCategory As String,
                                   paramDateFrom As DateTime,
                                   paramDateTo As DateTime
                                   )


        Dim newsqlcon As New SQLcon
        Dim newcmd As SqlCommand
        Dim newdr As SqlDataReader

        With FEquipment_history
            Try
                newsqlcon.connection.Open()
                newcmd = New SqlCommand(cStoreProcName, newsqlcon.connection)
                newcmd.Parameters.Clear()
                newcmd.CommandType = CommandType.StoredProcedure

                newcmd.Parameters.AddWithValue("@n", n)

                If paramCategory = newCatEnum.AllCategory Or
                    paramCategory = newCatEnum.Others Or
                    paramCategory = newCatEnum.Acquisition Or
                    paramCategory = newCatEnum.Fuel Or
                    paramCategory = newCatEnum.Repair Or
                    paramCategory = newCatEnum.Maintenance Or
                    paramCategory = newCatEnum.Rehabilitation Or
                    paramCategory = newCatEnum.Tires Or
                    paramCategory = newCatEnum.EquipmentType Then

                    newcmd.Parameters.AddWithValue("@plateno", paramPlateNo)
                    newcmd.Parameters.AddWithValue("@category", paramCategory)
                    newcmd.Parameters.AddWithValue("@datefrom", Format(Date.Parse(paramDateFrom), "MM/dd/yyyy"))
                    newcmd.Parameters.AddWithValue("@dateto", Format(Date.Parse(paramDateTo), "MM/dd/yyyy"))

                ElseIf paramCategory = newCatEnum.Salaries Or paramCategory = newCatEnum.Allowances Then

                    newcmd.Parameters.AddWithValue("@from_date", Format(Date.Parse(paramDateFrom), "MM/dd/yyyy"))
                    newcmd.Parameters.AddWithValue("@to_date", Format(Date.Parse(paramDateTo), "MM/dd/yyyy"))
                    newcmd.Parameters.AddWithValue("@Designation", get_id_Designation(paramPlateNo))

                End If


                newdr = newcmd.ExecuteReader

                While newdr.Read
                    Dim a(20) As String
                    Dim newEquipHistoryData As New equipmentHistoryData

                    With newEquipHistoryData

                        Select Case paramCategory

                            Case newCatEnum.AllCategory,
                                 newCatEnum.Others,
                                 newCatEnum.Acquisition,
                                 newCatEnum.Fuel,
                                 newCatEnum.Repair,
                                 newCatEnum.Maintenance,
                                 newCatEnum.Rehabilitation,
                                 newCatEnum.Tires,
                                 newCatEnum.EquipmentType

                                '.dateLog = IIf(newdr.Item("date_log").ToString = "",
                                '               Date.Parse("1990-01-01"), Format(Date.Parse(newdr.Item("date_log").ToString), "MM/dd/yyyy"))

                                .dateLog = IIf(Not IsDate(newdr.Item("date_log").ToString), Date.Parse("1990-01-01"), newdr.Item("date_log").ToString)
                                .rsNo = newdr.Item("rs_no").ToString
                                .receivedQty = IIf(IsNumeric(newdr.Item("RECEIVED_QTY").ToString), newdr.Item("RECEIVED_QTY").ToString, 0)
                                .unit = newdr.Item("unit").ToString
                                .requestedBy = newdr.Item("requested_by").ToString
                                .poNo = newdr.Item("po_no").ToString
                                .torSubDesc = newdr.Item("tor_sub_desc").ToString
                                .typeOfPurchasing = newdr.Item("type_of_purchasing").ToString


                                If newdr.Item("problem_encounter").ToString <> Nothing Then
                                    .conductedBy = newdr.Item("conducted_by").ToString
                                    .problemEncounter = newdr.Item("problem_encounter").ToString
                                Else
                                    .conductedBy = "-"
                                    .problemEncounter = newdr.Item("purpose").ToString
                                End If

                                If newdr.Item("type_of_purchasing").ToString.Contains("PURCHASE ORDER") Or
                                    newdr.Item("type_of_purchasing").ToString = "CASH" _
                                    Or newdr.Item("type_of_purchasing").ToString = "CASH WITH RR" Then

                                    .poNo = newdr.Item("po_no").ToString
                                    .receivedQty = newdr.Item("RECEIVED_QTY").ToString
                                    .itemName = newdr.Item("whItem").ToString
                                    .itemDesc = newdr.Item("whItemDesc").ToString
                                    .unit = newdr.Item("unit").ToString
                                    .jobOrderNo = newdr.Item("job_order_no").ToString

                                    If paramCategory = newCatEnum.EquipmentType Then 'EQUIPMENT TYPE
                                        .plateNo = newdr.Item("plate_no").ToString
                                    End If

                                    If newdr.Item("UNIT_PRICE").ToString <> Nothing Then
                                        Dim unitPrice As Double = IIf(IsNumeric(newdr.Item("UNIT_PRICE").ToString()), newdr.Item("UNIT_PRICE").ToString(), 0)

                                        .receivedAmount = unitPrice * .receivedQty
                                    End If

                                ElseIf newdr.Item("type_of_purchasing").ToString = "WITHDRAWAL" Or
                                    newdr.Item("type_of_purchasing").ToString = "CASH WITHOUT RR" Then

                                    .poNo = "WS # " + newdr.Item("po_no").ToString
                                    .receivedQty = newdr.Item("WITHDRAWAL_QTY").ToString
                                    .unit = newdr.Item("unit_withdrawal").ToString
                                    .itemName = newdr.Item("whItem").ToString
                                    .itemDesc = newdr.Item("whItemDesc").ToString
                                    .jobOrderNo = newdr.Item("job_order_no").ToString

                                    If paramCategory = newCatEnum.EquipmentType Then 'EQUIPMENT TYPE
                                        .plateNo = newdr.Item("plate_no").ToString
                                    End If

                                    If newdr.Item("WITHDRAWAL_AMOUNT").ToString <> Nothing Then
                                        Dim receivedAmount As Double = IIf(IsNumeric(newdr.Item("WITHDRAWAL_AMOUNT").ToString()),
                                                                           newdr.Item("WITHDRAWAL_AMOUNT").ToString(), 0)

                                        .receivedAmount = receivedAmount * .receivedQty
                                    End If

                                ElseIf newdr.Item("type_of_purchasing").ToString = "LIQUIDAITON-CASH" Then

                                    .poNo = "CV # " + newdr.Item("po_no").ToString
                                    .receivedQty = newdr.Item("RECEIVED_QTY").ToString
                                    .itemName = newdr.Item("whItem").ToString
                                    .itemDesc = newdr.Item("whItemDesc").ToString

                                    If paramCategory = newCatEnum.EquipmentType Then 'EQUIPMENT TYPE
                                        .plateNo = newdr.Item("plate_no").ToString
                                    End If

                                    If newdr.Item("UNIT_PRICE").ToString <> Nothing Then
                                        .receivedAmount = IIf(Not IsNumeric(newdr.Item("UNIT_PRICE").ToString()),
                                                              0, newdr.Item("UNIT_PRICE").ToString())
                                    End If

                                ElseIf newdr.Item("type_of_purchasing").ToString = "LIQUIDAITON-WITHDRAWN" Then

                                    .poNo = "WS # " + newdr.Item("po_no").ToString
                                    .receivedQty = newdr.Item("RECEIVED_QTY").ToString
                                    .itemName = newdr.Item("whItem").ToString
                                    .itemDesc = newdr.Item("whItemDesc").ToString

                                    If paramCategory = newCatEnum.EquipmentType Then 'EQUIPMENT TYPE
                                        .plateNo = newdr.Item("plate_no").ToString
                                    End If

                                    If newdr.Item("UNIT_PRICE").ToString <> Nothing Then
                                        .receivedAmount = IIf(Not IsNumeric(newdr.Item("UNIT_PRICE").ToString()),
                                                              0, newdr.Item("UNIT_PRICE").ToString())
                                    End If

                                ElseIf .torSubDesc.ToUpper() = "FUEL-EU" Then

                                    .problemEncounter = "Refuel"
                                    .itemName = "Fuel"
                                    .itemDesc = "Diesel"
                                    .unit = "ltrs"
                                    .conductedBy = "-"

                                    If paramCategory = newCatEnum.EquipmentType Then 'EQUIPMENT TYPE
                                        .plateNo = newdr.Item("plate_no").ToString
                                        .receivedAmount = IIf(Not IsNumeric(newdr.Item("UNIT_PRICE").ToString()),
                                                              0, newdr.Item("UNIT_PRICE").ToString())

                                    Else
                                        .receivedAmount = IIf(Not IsNumeric(newdr.Item("RECEIVED_AMOUNT").ToString()),
                                                              0, newdr.Item("RECEIVED_AMOUNT").ToString())

                                    End If

                                ElseIf .torSubDesc.ToUpper() = "ALLOWANCE" Then

                                    .plateNo = newdr.Item("plate_no").ToString
                                    .poNo = "V.N.: " & newdr.Item("po_no").ToString
                                    .receivedAmount = IIf(Not IsNumeric(newdr.Item("WITHDRAWAL_AMOUNT").ToString()),
                                                              0, newdr.Item("WITHDRAWAL_AMOUNT").ToString())

                                End If

                            Case newCatEnum.Salaries, newCatEnum.Allowances

                                .dateLog = Format(Date.Parse(newdr.Item(1).ToString), "MM/dd/yyyy")
                                .rsNo = "-"
                                .torSubDesc = IIf(paramCategory = newCatEnum.Allowances, "Allowances", "Salaries")
                                .plateNo = FEquipment_history.cmb_plate_no.Text
                                .jobOrderNo = "-"
                                .conductedBy = "-"
                                .problemEncounter = "-"
                                .unit = "-"
                                .itemName = IIf(paramCategory = newCatEnum.Allowances, "Allowance", "Salaries")
                                .itemDesc = "-"
                                .requestedBy = newdr.Item(4).ToString
                                .poNo = "V.N.: " & newdr.Item(6).ToString
                                .receivedAmount = IIf(Not IsNumeric(newdr.Item(7).ToString), 0, newdr.Item(7).ToString)


                        End Select


                    End With


                    cListOfEquipmentHistory.Add(newEquipHistoryData)

continuehere:

                End While
                newdr.Close()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & ex.StackTrace() & vbCrLf & "Info: " & ex.Message, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newsqlcon.connection.Close()
            End Try
        End With
    End Sub


    Public Sub get_history_repair(ByVal n As Integer)
        FEquipment_history.dtg_equipmentHistory.Rows.Clear()

        Dim newsqlcon As New SQLcon
        Dim newcmd As SqlCommand
        Dim newdr As SqlDataReader


        With FEquipment_history
            Try
                newsqlcon.connection.Open()
                newcmd = New SqlCommand("proc_dbequipment_history", newsqlcon.connection)
                newcmd.Parameters.Clear()
                newcmd.CommandType = CommandType.StoredProcedure

                newcmd.Parameters.AddWithValue("@n", n)
                newcmd.Parameters.AddWithValue("@plateno", .cmb_plate_no.Text)
                newcmd.Parameters.AddWithValue("@category", .cmb_category.Text)
                newcmd.Parameters.AddWithValue("@datefrom", Format(Date.Parse(dtp_from.Value), "MM/dd/yyyy"))
                newcmd.Parameters.AddWithValue("@dateto", Format(Date.Parse(dtp_to.Value), "MM/dd/yyyy"))

                newdr = newcmd.ExecuteReader

                While newdr.Read
                    Dim a(20) As String
                    a(1) = Format(Date.Parse(newdr.Item("date_log").ToString), "MM/dd/yyyy")
                    a(2) = newdr.Item("rs_no").ToString
                    a(8) = newdr.Item("RECEIVED_QTY").ToString
                    a(9) = newdr.Item("unit").ToString
                    a(10) = newdr.Item("whItem").ToString
                    a(11) = newdr.Item("whItemDesc").ToString
                    a(12) = newdr.Item("requested_by").ToString
                    a(13) = newdr.Item("po_no").ToString
                    a(3) = newdr.Item("tor_sub_desc").ToString

                    If FEquipment_history.cmb_category.Text = "Fuel" Then
                        'a(4) = newdr.Item("po_no").ToString
                        a(5) = "-"
                        a(6) = "-"
                        a(7) = "Refuel"

                        If newdr.Item("type_of_purchasing").ToString.Contains("PURCHASE ORDER") Or newdr.Item("type_of_purchasing").ToString = "CASH" _
                            Or newdr.Item("type_of_purchasing").ToString = "CASH WITH RR" Then
                            a(13) = newdr.Item("po_no").ToString
                            a(8) = newdr.Item("RECEIVED_QTY").ToString
                            a(14) = FormatNumber(newdr.Item("RECEIVED_AMOUNT").ToString() * a(8))
                        ElseIf newdr.Item("type_of_purchasing").ToString = "WITHDRAWAL" Or newdr.Item("type_of_purchasing").ToString = "CASH WITHOUT RR" Then
                            a(13) = "WS # " + newdr.Item("po_no").ToString
                            a(8) = newdr.Item("WITHDRAWAL_QTY").ToString
                            a(9) = newdr.Item("unit_withdrawal").ToString
                            'a(11) = FormatNumber(newdr.Item("WITHDRAWAL_AMOUNT").ToString() * a(5))
                            If newdr.Item("WITHDRAWAL_AMOUNT").ToString <> Nothing Then
                                a(14) = FormatNumber(newdr.Item("WITHDRAWAL_AMOUNT").ToString() * a(8))
                            End If
                        ElseIf newdr.Item("tor_sub_desc").ToString = "Fuel-EU" Then
                            a(9) = "ltrs"
                            a(10) = "Fuel"
                            a(11) = "Diesel"
                            a(14) = FormatNumber(newdr.Item("RECEIVED_AMOUNT").ToString())
                        ElseIf newdr.Item("tor_sub_desc").ToString = "Fuel-LiqReport" Then
                            a(9) = "ltrs"
                            a(10) = "Fuel"
                            a(11) = newdr.Item("whItem").ToString
                            a(14) = FormatNumber(newdr.Item("RECEIVED_AMOUNT").ToString())
                        End If


                    ElseIf FEquipment_history.cmb_category.Text = "Equipment Type" Then

                        a(4) = newdr.Item("plate_no").ToString
                        a(5) = newdr.Item("job_order_no").ToString


                        If newdr.Item("problem_encounter").ToString <> Nothing Then
                            a(6) = newdr.Item("conducted_by").ToString
                            a(7) = newdr.Item("problem_encounter").ToString
                        Else
                            a(6) = "-"
                            a(7) = newdr.Item("purpose").ToString
                        End If


                        a(15) = newdr.Item("tor_sub_desc").ToString

                        If newdr.Item("Transaction_Type").ToString = "Request" Then
                            'newdr.Item("job_order_no").ToString
                            a(6) = newdr.Item("conducted_by").ToString
                            a(7) = newdr.Item("problem_encounter").ToString


                            If newdr.Item("type_of_purchasing").ToString.Contains("PURCHASE ORDER") Or newdr.Item("type_of_purchasing").ToString = "CASH" _
                            Or newdr.Item("type_of_purchasing").ToString = "CASH WITH RR" Then
                                a(13) = newdr.Item("po_no").ToString
                                a(8) = newdr.Item("RECEIVED_QTY").ToString
                                If newdr.Item("UNIT_PRICE").ToString <> Nothing Then
                                    a(14) = FormatNumber(newdr.Item("UNIT_PRICE").ToString() * a(8))
                                End If
                            ElseIf newdr.Item("type_of_purchasing").ToString = "WITHDRAWAL" Or newdr.Item("type_of_purchasing").ToString = "CASH WITHOUT RR" Then
                                a(13) = "WS # " + newdr.Item("po_no").ToString
                                a(8) = newdr.Item("WITHDRAWAL_QTY").ToString
                                a(9) = newdr.Item("unit_withdrawal").ToString '''''''''''Latest
                                If newdr.Item("WITHDRAWAL_AMOUNT").ToString <> Nothing Then
                                    a(14) = FormatNumber(newdr.Item("WITHDRAWAL_AMOUNT").ToString() * a(8))
                                End If
                            ElseIf newdr.Item("type_of_purchasing").ToString = "LIQUIDAITON-CASH" Then
                                a(13) = "CV # " + newdr.Item("po_no").ToString
                                a(8) = newdr.Item("RECEIVED_QTY").ToString
                                If newdr.Item("UNIT_PRICE").ToString <> Nothing Then
                                    a(14) = FormatNumber(newdr.Item("UNIT_PRICE").ToString())
                                End If
                            ElseIf newdr.Item("type_of_purchasing").ToString = "LIQUIDAITON-WITHDRAWN" Then
                                a(13) = "WS # " + newdr.Item("po_no").ToString
                                a(8) = newdr.Item("RECEIVED_QTY").ToString
                                If newdr.Item("UNIT_PRICE").ToString <> Nothing Then
                                    a(14) = FormatNumber(newdr.Item("UNIT_PRICE").ToString())
                                End If
                            End If

                        ElseIf newdr.Item("Transaction_Type").ToString = "Fuel" Then

                            a(6) = "-"
                            a(7) = "Refuel"

                            If newdr.Item("type_of_purchasing").ToString.Contains("PURCHASE ORDER") Or newdr.Item("type_of_purchasing").ToString = "CASH" _
                            Or newdr.Item("type_of_purchasing").ToString = "CASH WITH RR" Then
                                a(13) = newdr.Item("po_no").ToString
                                a(8) = newdr.Item("RECEIVED_QTY").ToString
                                a(14) = FormatNumber(newdr.Item("WITHDRAWAL_AMOUNT").ToString() * a(8))
                            ElseIf newdr.Item("type_of_purchasing").ToString = "WITHDRAWAL" Or newdr.Item("type_of_purchasing").ToString = "CASH WITHOUT RR" Then
                                a(13) = "WS # " + newdr.Item("po_no").ToString
                                a(8) = newdr.Item("WITHDRAWAL_QTY").ToString
                                a(9) = newdr.Item("unit_withdrawal").ToString
                                'a(11) = FormatNumber(newdr.Item("WITHDRAWAL_AMOUNT").ToString() * a(5))
                                If newdr.Item("WITHDRAWAL_AMOUNT").ToString <> Nothing Then
                                    a(14) = FormatNumber(newdr.Item("WITHDRAWAL_AMOUNT").ToString() * a(7))
                                End If
                            ElseIf newdr.Item("tor_sub_desc").ToString = "Fuel-EU" Then
                                a(9) = "ltrs"
                                a(10) = "Fuel"
                                a(11) = "Diesel"
                                a(14) = FormatNumber(newdr.Item("UNIT_PRICE").ToString())
                            ElseIf newdr.Item("tor_sub_desc").ToString = "Fuel-LiqReport" Then
                                a(9) = "ltrs"
                                a(10) = "Fuel"
                                a(11) = newdr.Item("whItem").ToString
                                a(14) = FormatNumber(newdr.Item("UNIT_PRICE").ToString())
                            End If

                        ElseIf newdr.Item("Transaction_Type").ToString = "Allowance" Then
                            a(5) = "-"
                            a(6) = "-"
                            a(8) = "-"
                            a(8) = "-"
                            a(9) = "-"
                            a(10) = "-"
                            a(13) = "V.N.: " + newdr.Item("po_no").ToString
                            a(15) = newdr.Item("tor_sub_desc").ToString
                            a(14) = FormatNumber(newdr.Item("WITHDRAWAL_AMOUNT").ToString())

                        End If

                    ElseIf FEquipment_history.cmb_category.Text = "All Category" Then

                        If newdr.Item("tor_sub_desc").ToString = "Fuel-EU" Then
                            a(4) = "-"
                            a(5) = "-"
                            a(6) = "-"
                            a(7) = "Refuel"
                            a(13) = newdr.Item("po_no").ToString

                            If newdr.Item("type_of_purchasing").ToString.Contains("PURCHASE ORDER") Or newdr.Item("type_of_purchasing").ToString = "CASH" _
                            Or newdr.Item("type_of_purchasing").ToString = "CASH WITH RR" Then
                                a(13) = newdr.Item("po_no").ToString
                                a(8) = newdr.Item("RECEIVED_QTY").ToString
                                a(14) = FormatNumber(newdr.Item("RECEIVED_AMOUNT").ToString() * a(8))
                            ElseIf newdr.Item("type_of_purchasing").ToString = "WITHDRAWAL" Or newdr.Item("type_of_purchasing").ToString = "CASH WITHOUT RR" Then
                                a(13) = "WS # " + newdr.Item("po_no").ToString
                                a(8) = newdr.Item("WITHDRAWAL_QTY").ToString
                                a(9) = newdr.Item("unit_withdrawal").ToString
                                'a(11) = FormatNumber(newdr.Item("WITHDRAWAL_AMOUNT").ToString() * a(5))
                                If newdr.Item("WITHDRAWAL_AMOUNT").ToString <> Nothing Then
                                    a(14) = FormatNumber(newdr.Item("WITHDRAWAL_AMOUNT").ToString() * a(8))
                                End If
                            ElseIf newdr.Item("tor_sub_desc").ToString = "Fuel-EU" Then
                                a(9) = "ltrs"
                                a(10) = "Fuel"
                                a(11) = "Diesel"
                                a(14) = FormatNumber(newdr.Item("RECEIVED_AMOUNT").ToString())
                            ElseIf newdr.Item("tor_sub_desc").ToString = "Fuel-LiqReport" Then
                                a(9) = "ltrs"
                                a(10) = "Fuel"
                                a(11) = newdr.Item("whItem").ToString
                                a(14) = FormatNumber(newdr.Item("RECEIVED_AMOUNT").ToString())
                            End If

                        ElseIf newdr.Item("tor_sub_desc").ToString = "Allowance" Then

                            a(5) = "-"
                            a(6) = "-"
                            a(7) = "-"
                            a(8) = "-"
                            a(8) = "-"
                            a(9) = "-"
                            a(10) = "-"
                            a(13) = "V.N.: " + newdr.Item("po_no").ToString
                            a(15) = newdr.Item("tor_sub_desc").ToString
                            a(14) = FormatNumber(newdr.Item("WITHDRAWAL_AMOUNT").ToString())

                        Else
                            a(5) = newdr.Item("job_order_no").ToString

                            If newdr.Item("problem_encounter").ToString <> Nothing Then
                                a(6) = newdr.Item("conducted_by").ToString
                                a(7) = newdr.Item("problem_encounter").ToString
                            Else
                                a(6) = "-"
                                a(7) = newdr.Item("purpose").ToString
                            End If

                            If newdr.Item("type_of_purchasing").ToString.Contains("PURCHASE ORDER") Or newdr.Item("type_of_purchasing").ToString = "CASH" _
                            Or newdr.Item("type_of_purchasing").ToString = "CASH WITH RR" Then
                                a(13) = newdr.Item("po_no").ToString
                                a(8) = newdr.Item("RECEIVED_QTY").ToString
                                If newdr.Item("UNIT_PRICE").ToString <> Nothing Then
                                    a(14) = FormatNumber(newdr.Item("UNIT_PRICE").ToString() * a(8))
                                End If

                            ElseIf newdr.Item("type_of_purchasing").ToString = "WITHDRAWAL" Or newdr.Item("type_of_purchasing").ToString = "CASH WITHOUT RR" Then
                                a(13) = "WS # " + newdr.Item("po_no").ToString
                                a(8) = newdr.Item("WITHDRAWAL_QTY").ToString
                                a(9) = newdr.Item("unit_withdrawal").ToString
                                If newdr.Item("WITHDRAWAL_AMOUNT").ToString <> Nothing Then
                                    a(14) = FormatNumber(newdr.Item("WITHDRAWAL_AMOUNT").ToString() * a(8))
                                End If

                            ElseIf newdr.Item("type_of_purchasing").ToString = "LIQUIDAITON-CASH" Then
                                a(13) = "CV # " + newdr.Item("po_no").ToString
                                a(8) = newdr.Item("RECEIVED_QTY").ToString
                                If newdr.Item("UNIT_PRICE").ToString <> Nothing Then
                                    a(14) = FormatNumber(newdr.Item("UNIT_PRICE").ToString())
                                End If

                            ElseIf newdr.Item("type_of_purchasing").ToString = "LIQUIDAITON-WITHDRAWN" Then
                                a(13) = "WS # " + newdr.Item("po_no").ToString
                                a(8) = newdr.Item("RECEIVED_QTY").ToString
                                If newdr.Item("UNIT_PRICE").ToString <> Nothing Then
                                    a(14) = FormatNumber(newdr.Item("UNIT_PRICE").ToString())
                                End If
                            End If

                        End If

                    Else

                        a(5) = newdr.Item("job_order_no").ToString

                        If newdr.Item("problem_encounter").ToString <> Nothing Then
                            a(6) = newdr.Item("conducted_by").ToString
                            a(7) = newdr.Item("problem_encounter").ToString
                        Else
                            a(6) = "-"
                            a(7) = newdr.Item("purpose").ToString
                        End If

                        If newdr.Item("type_of_purchasing").ToString.Contains("PURCHASE ORDER") Or newdr.Item("type_of_purchasing").ToString = "CASH" _
                            Or newdr.Item("type_of_purchasing").ToString = "CASH WITH RR" Then
                            a(13) = newdr.Item("po_no").ToString
                            a(8) = newdr.Item("RECEIVED_QTY").ToString
                            If newdr.Item("UNIT_PRICE").ToString <> Nothing Then
                                a(14) = FormatNumber(newdr.Item("UNIT_PRICE").ToString() * a(8))
                            End If

                        ElseIf newdr.Item("type_of_purchasing").ToString = "WITHDRAWAL" Or newdr.Item("type_of_purchasing").ToString = "CASH WITHOUT RR" Then
                            a(13) = "WS # " + newdr.Item("po_no").ToString
                            a(8) = newdr.Item("WITHDRAWAL_QTY").ToString
                            a(9) = newdr.Item("unit_withdrawal").ToString
                            If newdr.Item("WITHDRAWAL_AMOUNT").ToString <> Nothing Then
                                a(14) = FormatNumber(newdr.Item("WITHDRAWAL_AMOUNT").ToString() * a(8))
                            End If

                        ElseIf newdr.Item("type_of_purchasing").ToString = "LIQUIDAITON-CASH" Then
                            a(13) = "CV # " + newdr.Item("po_no").ToString
                            a(8) = newdr.Item("RECEIVED_QTY").ToString
                            If newdr.Item("UNIT_PRICE").ToString <> Nothing Then
                                a(14) = FormatNumber(newdr.Item("UNIT_PRICE").ToString())
                            End If

                        ElseIf newdr.Item("type_of_purchasing").ToString = "LIQUIDAITON-WITHDRAWN" Then
                            a(13) = "WS # " + newdr.Item("po_no").ToString
                            a(8) = newdr.Item("RECEIVED_QTY").ToString
                            If newdr.Item("UNIT_PRICE").ToString <> Nothing Then
                                a(14) = FormatNumber(newdr.Item("UNIT_PRICE").ToString())
                            End If
                        End If

                    End If

                    .dtg_equipmentHistory.Rows.Add(a)


                End While
                newdr.Close()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & ex.StackTrace() & vbCrLf & "Info: " & ex.Message, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newsqlcon.connection.Close()
            End Try
        End With

    End Sub

    Private Sub FEquipment_history_searchby_date_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If FEquipment_history.cmb_status.Text = "All Request" Then
            Label3.Text = "ALL REQUEST DATE"
        ElseIf FEquipment_history.cmb_status.Text = "Reported Status" Then
            Label3.Text = "REPORTED STATUS DATE"
        ElseIf FEquipment_history.cmb_status.Text = "UnReported Status" Then
            Label3.Text = "UNREPORTED STATUS DATE"
        End If

    End Sub

    Private Sub BW_search_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BW_search.DoWork


        getEquipmentHistory(cN,
                             cPlateNo,
                             cCategory,
                             cDateFrom,
                             cDateTo
                             )
    End Sub

    Private Sub BW_loading_DoWork(sender As Object, e As DoWorkEventArgs) Handles BW_loading.DoWork

        cLoading = True
        'FEquipment_history.Panel4.Visible = True

        While cLoading = True

        End While
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub BW_display_DoWork(sender As Object, e As DoWorkEventArgs)

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub BW_search_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BW_search.RunWorkerCompleted
        'MsgBox(cListOfEquipmentHistory.Count)
        'sort data
        Dim newData = From data In cListOfEquipmentHistory
                      Select data Order By data.dateLog Ascending


        For Each equipHistory In newData
            Dim a(20) As String

            With equipHistory
                a(1) = Format(Date.Parse(.dateLog), "MM/dd/yyyy")
                a(2) = .rsNo
                a(3) = .torSubDesc
                a(4) = .plateNo
                a(5) = .jobOrderNo
                a(6) = CapitalizeEachWord(.conductedBy)
                a(7) = .problemEncounter
                a(8) = IIf(.receivedQty = 0, "-", .receivedQty)
                a(9) = .unit
                a(10) = .itemName
                a(11) = .itemDesc
                a(12) = CapitalizeEachWord(.requestedBy)
                a(13) = .poNo
                a(14) = FormatNumber(.receivedAmount, 2,,, TriState.True)
                a(15) = .typeOfPurchasing

                FEquipment_history.dtg_equipmentHistory.Rows.Add(a)
            End With
        Next

        cLoading = False
    End Sub

    Private Sub BW_loading_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BW_loading.RunWorkerCompleted
        FEquipment_history.Panel4.Visible = False
    End Sub
End Class