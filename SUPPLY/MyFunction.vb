Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Globalization

Module MyFunctions
    Private customMsg As New customMessageBox
    Public Function find_item_from_datagridview(ByVal datagrid As DataGridView, ByVal index As Integer, ByVal value As String)
        Dim i As Integer = 0
        For Each Row As DataGridViewRow In datagrid.Rows
            If datagrid.Rows(i).Cells(index).Value.Equals(value) Then
                Return i
                Exit For
            End If
            i = i + 1
        Next
    End Function
    Public Sub form_active(ByVal a As String)
        Dim i As Integer
        For Each f As Form In Application.OpenForms
            If f.Name = a Then
                i += 1
            End If
        Next

        If i > 0 Then

            For Each f As Form In Application.OpenForms

                If f.Name = a Then

                    f.Activate()
                    f.MdiParent = FMain
                    f.Dock = DockStyle.Fill

                    f.Show()
                End If
            Next

        ElseIf i = 0 Then
            If a = "FRequistionForm" Then
                form_activate(FRequistionForm)
            ElseIf a = "FPurchasedOrderList" Then
                form_activate(FPurchasedOrderList)
            ElseIf a = "FReceivingReportList" Then
                form_activate(FReceivingReportList)
            ElseIf a = "FSummarySupplyTransaction" Then
                form_activate(FSummarySupplyTransaction)
            ElseIf a = "FWithdrawalList" Then
                form_activate(FWithdrawalList)
            ElseIf a = "FBorrowedDetails" Then
                form_activate(FBorrowedDetails)
            ElseIf a = "FMaterials_ToolsTurnOverReport" Then
                form_activate(FMaterials_ToolsTurnOverReport)
            ElseIf a = "FPOFORM" Then
                form_activate(FPOFORM)
            ElseIf a = "FCashVoucherList" Then
                form_activate(FCashVoucherList)
            ElseIf a = "FBorrowed_Item_Monitoring" Then
                form_activate(FBorrowed_Item_Monitoring)
            ElseIf a = "Form1" Then
                form_activate(Form1)
            ElseIf a = "FStockCard" Then
                form_activate(FStockCard)
            ElseIf a = "FEquipment_history" Then
                form_activate(FEquipment_history)
            ElseIf a = "FEquipment_cost_report" Then
                form_activate(FEquipment_cost_report)
            ElseIf a = "FLaborCost" Then
                form_activate(FLaborCost)
            ElseIf a = "FProjectCost" Then
                form_activate(FProjectCost)
            ElseIf a = "FQty_takeoff" Then
                form_activate(FQty_takeoff)
            ElseIf a = "FEquipment_monitoring" Then
                form_activate(FEquipment_monitoring)
            ElseIf a = "FAggregates_General_Request" Then
                form_activate(FAggregates_General_Request)
            ElseIf a = "Summary_Purchased_Item" Then
                form_activate(Summary_Purchased_Item)
            ElseIf a = "FAllowance" Then
                form_activate(FAllowance)
            ElseIf a = "FStockpile_monitoring" Then
                form_activate(FStockpile_monitoring)
            ElseIf a = "FDRLIST1" Then
                form_activate(FDRLIST1)
            ElseIf a = "StockCard1" Then
                form_activate(StockCard1)
            ElseIf a = "FAccidentReportField" Then
                form_activate(FAccidentReportField)
            ElseIf a = "Allowance_sum" Then
                form_activate(Allowance_sum)
            ElseIf a = "ExportingRecordForm" Then
                form_activate(ExportingRecordForm)
            ElseIf a = "SupplierEvaluationForm" Then
                form_activate(ListofEvaluatedSupplierForm)
            ElseIf a = "FDRLIST2" Then
                form_activate(FDRLIST2)
            ElseIf a = NameOf(FRequesitionFormForDR) Then
                form_activate(FRequesitionFormForDR)
            ElseIf a = NameOf(FReceivingReportListNew) Then
                form_activate(FReceivingReportListNew)
            End If
        End If

    End Sub


    Public Sub form_activate(ByVal f As Form)
        f.Activate()
        f.MdiParent = FMain
        f.Dock = DockStyle.Fill

        f.Show()
    End Sub

    Public Function check_if_exist(ByVal db As String, ByVal field As String, ByVal value As String, ByVal n As Integer) As Integer
        Dim SQ As New SQLcon
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        Try
            Dim query As String
            SQ.connection.Open()
            If n = 0 Then
                query = "SELECT * FROM " & db & " WHERE " & field & " = '" & value & "'"
            ElseIf n = 1 Then
                query = "SELECT * FROM " & db & " WHERE " & field & " = " & value
            ElseIf n = 2 Then
                query = "SELECT * FROM " & db & " WHERE " & field & " LIKE '%" & value & "%'"
            ElseIf n = 3 Then
                Dim mul_field() As String
                Dim mul_value() As String

                mul_field = field.Split("^")
                mul_value = value.Split("^")

                query = "SELECT * FROM " & db & " WHERE " & mul_field(0) & " = '" & mul_value(0) & "' AND " & mul_field(1) & " = '" & mul_value(1) & "'"

            End If

            cmd = New SqlCommand(query, SQ.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                check_if_exist += 1
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
            GC.Collect()


        End Try
    End Function

    Public Function get_id(ByVal db As String, ByVal field As String, ByVal value As String, ByVal n As Integer) As Integer
        Dim SQ As New SQLcon
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        Try
            Dim query As String = ""
            SQ.connection.Open()
            If n = 0 Then

                query = "SELECT * FROM " & db & " WHERE " & field & " = '" & value & "'"

            ElseIf n = 1 Then

                query = "SELECT * FROM " & db & " WHERE " & field & " = " & value

            ElseIf n = 2 Then

                Dim mul_field() As String
                Dim mul_value() As String

                mul_field = field.Split("^")
                mul_value = value.Split("^")

                query = "SELECT * FROM " & db & " WHERE " & mul_field(0) & " = '" & mul_value(0) & "' AND " & mul_field(1) & " = '" & mul_value(1) & "'"

            ElseIf n = 3 Then

                Dim mul_field() As String
                Dim mul_value() As String

                mul_field = field.Split("^")
                mul_value = value.Split("^")

                query = "SELECT * FROM " & db & " WHERE " & mul_field(0) & " = " & CInt(mul_value(0)) & " AND " & mul_field(1) & " = " & CInt(mul_value(1))

            End If

            cmd = New SqlCommand("proc_select_query", SQ.connection)

            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@querystring", query)
            cmd.Parameters.AddWithValue("@typeofquery", "SELECT")
            get_id = cmd.ExecuteScalar()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
            GC.Collect()
        End Try
    End Function

    Public Function UPDATE_INSERT_DELETE_QUERY(ByVal query As String, ByVal n As Integer, ByVal typeofquery As String) As Integer
        Dim SQ As New SQLcon
        Dim cmd As SqlCommand
        Dim result As String = ""

        Try
            SQ.connection.Open()
            cmd = New SqlCommand("proc_select_query", SQ.connection)

            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@querystring", query)
            cmd.Parameters.AddWithValue("@typeofquery", typeofquery)

            If n = 0 Then
                cmd.ExecuteNonQuery()
            ElseIf n = 1 Then
                ' UPDATE_INSERT_DELETE_QUERY = IIf(IsDBNull(cmd.ExecuteScalar()) = True, 0, cmd.ExecuteScalar)
                result = cmd.ExecuteScalar

                If result = "" Or result = Nothing Then
                    UPDATE_INSERT_DELETE_QUERY = 0
                Else
                    UPDATE_INSERT_DELETE_QUERY = cmd.ExecuteScalar()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
            GC.Collect()
        End Try
    End Function

    Public Sub SELECT_(ByVal query As String, ByVal n As Integer, ByVal lview As Object, ByVal b As String, ByVal DF As Integer)
        Dim SQ As New SQLcon
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        Dim lv As ListView = lview

        Dim a(20) As String
        Dim rows() As String
        Dim incr As Integer = 0

        rows = b.Split("-")


        Try
            SQ.connection.Open()
            cmd = New SqlCommand(query, SQ.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                For i = 0 To n
                    For Each colno As String In rows
                        If colno = i Then
                            incr += 1
                        Else

                        End If
                    Next

                    If incr > 0 Then
                    Else
                        If i = DF Then
                            a(i) = dformat(dr.Item(i).ToString, 1)
                        Else
                            a(i) = dr.Item(i).ToString
                        End If

                    End If

                    incr = 0
                Next

                Dim lvl As New ListViewItem(a)
                lv.Items.Add(lvl)
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Sub SELECT_QUERY(ByVal query As String, ByVal n As Integer, ByVal lview As Object, ByVal b As String, ByVal DF As Integer)
        Dim SQ As New SQLcon
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        Dim lv As ListView = lview

        Dim a(20) As String
        Dim rows() As String
        Dim incr As Integer = 0

        rows = b.Split("-")

        Try
            SQ.connection.Open()
            cmd = New SqlCommand("proc_select_query", SQ.connection)

            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@querystring", query)
            cmd.Parameters.AddWithValue("@typeofquery", "SELECT")
            dr = cmd.ExecuteReader
            While dr.Read
                For i = 0 To n
                    For Each colno As String In rows
                        If colno = i Then
                            incr += 1
                        Else

                        End If
                    Next

                    If incr > 0 Then
                    Else
                        If i = DF Then
                            a(i) = dformat(dr.Item(i).ToString, 1)
                        Else
                            a(i) = dr.Item(i).ToString
                        End If

                    End If

                    incr = 0
                Next

                Dim lvl As New ListViewItem(a)
                lv.Items.Add(lvl)

            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

    End Sub

    Public Sub SELECT_QUERY1(ByVal query As String, ByVal n As Integer, ByVal lview As Object, ByVal b As String, ByVal DF As Integer)
        Dim SQ As New SQLcon
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        Dim lv As ComboBox = lview


        Dim a(20) As String
        Dim rows() As String
        Dim incr As Integer = 0

        rows = b.Split("-")

        Try
            SQ.connection.Open()
            cmd = New SqlCommand("proc_select_query", SQ.connection)

            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@querystring", query)
            cmd.Parameters.AddWithValue("@typeofquery", "SELECT")
            dr = cmd.ExecuteReader
            While dr.Read
                For i = 0 To n
                    For Each colno As String In rows
                        If colno = i Then
                            incr += 1
                        Else

                        End If
                    Next

                    If incr > 0 Then
                    Else
                        If i = DF Then
                            a(i) = dformat(dr.Item(i).ToString, 1)
                        Else
                            a(i) = dr.Item(i).ToString
                        End If

                    End If

                    incr = 0
                Next

                Dim lvl As New ListViewItem(a)
                'Dim listview1 As ListView = lview

                'listview1.Items.Add(lvl)
                lv.Items.Add(lvl)

            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

    End Sub
    Public Sub SELECT_QUERY3(query As String, obj As Object)

        Dim SQ As New SQLcon
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim lview As ListView
        Dim lbox As ListBox
        Dim counter As Integer

        Dim a(20) As String

        Try
            SQ.connection.Open()
            cmd = New SqlCommand("proc_select_query", SQ.connection)

            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@querystring", query)
            cmd.Parameters.AddWithValue("@typeofquery", "SELECT")
            dr = cmd.ExecuteReader

            While dr.Read
                If TypeOf obj Is ListView Then
                    lview = obj
                    lview.Items.Add(dr.Item(0).ToString)
                    counter += 1

                ElseIf TypeOf obj Is ListBox Then
                    lbox = obj
                    lbox.Items.Add(dr.Item(0).ToString)
                    counter += 1

                End If
            End While
            dr.Close()

            If TypeOf obj Is ListView Then
                If counter > 0 Then
                    lview = obj
                    lview.Visible = True
                Else
                    lview = obj
                    lview.Visible = False
                End If

            ElseIf TypeOf obj Is ListBox Then
                If counter > 0 Then
                    lbox = obj
                    lbox.Visible = True
                Else
                    lbox = obj
                    lbox.Visible = False
                End If

            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

    End Sub
    Public Function get_specific_column_value(ByVal query As String, ByVal n As Integer)
        Dim SQ As New SQLcon
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        Dim valstr As String
        Dim valint As Integer
        Dim valdbl As Decimal

        SQ.connection.Open()

        Try
            cmd = New SqlCommand(query, SQ.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                If n = 0 Then
                    valstr = dr.Item(0).ToString
                ElseIf n = 1 Then
                    valint = CInt(dr.Item(0).ToString)
                ElseIf n = 2 Then
                    valdbl = CDec(dr.Item(0).ToString)
                ElseIf n = 3 Then
                    valint += CInt(dr.Item(0).ToString)
                End If

            End While
            dr.Close()

            If n = 0 Then
                Return valstr
            ElseIf n = 1 Then
                Return valint

            ElseIf n = 2 Then
                Return valdbl

            ElseIf n = 3 Then
                Return valint
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Function

    Public Function dformat(ByVal formatdate As String, ByVal n As Integer) As String

        If n = 0 Then
            dformat = Format(Date.Parse(formatdate), "yyyy-MM-dd")
        ElseIf n = 1 Then
            dformat = Format(Date.Parse(formatdate), "MM/dd/yyyy")
        End If

    End Function

    Public Sub cleartextbox(ByVal parent As Object, ByVal ctrname As String)

        If ctrname = "groupbox" Then
            Dim parentctr As GroupBox = parent

            For Each ctr As Control In parentctr.Controls
                If TypeOf ctr Is TextBox Then
                    Dim tbox As TextBox = ctr
                    tbox.Clear()
                End If
            Next
        ElseIf ctrname = "me" Then
            Dim parentctr As Form = parent

            For Each ctr As Control In parentctr.Controls
                If TypeOf ctr Is TextBox Then
                    Dim tbox As TextBox = ctr
                    tbox.Clear()
                End If
            Next
        End If

    End Sub

    Public Sub enablecontrols(ByVal parent As Object)
        Dim parentctr As Form = parent

        For Each ctr As Control In parentctr.Controls
            ctr.Enabled = True
        Next

    End Sub

    Public Function convert_to_currency(ByVal val As Decimal) As Decimal

        val = Decimal.Round(val, 2).ToString("f2")
        convert_to_currency = String.Format("{0:n}", val)

    End Function


    Public Function listfocus(ByVal lvl As Object, ByVal selectedfocus As Integer)
        Dim lview As ListView = lvl

        Dim checkInt As Integer = FindItem(lview, selectedfocus) 'DTPTripForDelete.Text)
        If checkInt <> -1 Then
            lview.Items(checkInt).Selected = True
            'LVLEquipList.Focus()
            lview.SelectedItems(0).EnsureVisible()
        Else
            'Label1.Text = "Search string not found"
        End If

    End Function
    Public Sub listfocus1(ByVal lvl As Object, ByVal selectedfocus As Integer)
        Dim lview As ListView = lvl

        For Each row As ListViewItem In lview.Items
            If row.Text = selectedfocus Then
                row.Selected = True
                row.EnsureVisible()
            End If

        Next
    End Sub

    Public Function FindItem(ByVal LV As ListView, ByVal TextToFind As String) As Integer
        ' Loop through LV’s ListViewItems.
        For i As Integer = 0 To LV.Items.Count - 1
            If Trim(LV.Items(i).Text) = Trim(TextToFind) Then
                ' If found, return the row number
                Return (i)
            End If
            For subitem As Integer = 0 To LV.Items(i).SubItems.Count - 1
                If Trim(LV.Items(i).SubItems(subitem).Text) = Trim(TextToFind) Then
                    ' If found, return the row number
                    Return (i)
                End If
            Next
        Next
        Return -1
    End Function

    Public Function sp(ByVal split As String, ByVal value As String, ByVal i As Integer)
        Dim splitnow() As String
        Dim returnValue As String = ""

        splitnow = split.Split(value)

        If i = 0 Then
            returnValue = splitnow(0)
        ElseIf i = 1 Then
            returnValue = splitnow(1)
        ElseIf i = 2 Then
            returnValue = splitnow(2)
        ElseIf i = 3 Then
            returnValue = splitnow(3)
        End If

        Return returnValue
    End Function

    Public Sub message(ByVal errormsg As String, ByVal msgboxicon As Integer, Optional ByVal ex As Exception = Nothing)
        If msgboxicon = 1 Then
            MessageBox.Show(errormsg, "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf msgboxicon = 2 Then
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf msgboxicon = 3 Then
            MessageBox.Show(errormsg, "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        ElseIf msgboxicon = 4 Then
            MessageBox.Show(errormsg, "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Function row_counter(ByVal db As String, ByVal field As String, ByVal value As String, ByVal n As Integer) As Integer
        Dim newSQ As New SQLcon
        row_counter = 0
        Try

            Dim cmd As SqlCommand
            Dim dr As SqlDataReader

            Dim query As String = ""
            If n = 0 Then
                query = "SELECT * FROM " & db & " WHERE " & field & " = '" & value & "'"
            ElseIf n = 1 Then
                query = "SELECT * FROM " & db & " WHERE " & field & " = " & value
            End If

            newSQ.connection.Open()
            cmd = New SqlCommand(query, newSQ.connection)

            dr = cmd.ExecuteReader
            While dr.Read
                row_counter += 1
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function


    Public Function search_by(ByVal searching As String, ByVal value As String) As Boolean
        searching = LCase(searching)
        value = LCase(value)

        If searching Like "*" & value & "*" Then
            search_by = True

        ElseIf searching = "ADFIL LOT (NALCO)" Then
            search_by = False
        Else
            search_by = False
        End If

    End Function

    Public Function search_by1(ByVal searching As String, ByVal value As String) As Boolean
        searching = LCase(searching)
        value = LCase(value)

        If searching.Contains(value) Then
            search_by1 = True
        Else
            search_by1 = False
        End If

    End Function

    Public Function multiplecharges(ByVal rs_id As Integer, ByVal n As Integer) As String

        If n = 1 Then
            multiplecharges = "ADFIL"
        ElseIf n = 2 Then
            multiplecharges = "OUTSOURCE"
        End If

        Dim mcharges As String = get_multiple_charges(rs_id)

        If mcharges.Length < 1 Then
        Else

            mcharges = mcharges.Trim().Substring(0, mcharges.Length - 1)
            multiplecharges = multiplecharges & "(" & UCase(mcharges) & ")"
        End If
    End Function

    Public Function get_multiple_charges1(rs_id As Integer, search As String) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        get_multiple_charges1 = ""

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("PROC_MULTIPLE_CHARGES", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 0)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.Parameters.AddWithValue("@search", search)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_multiple_charges1 &= newDR.Item("charge_to").ToString & "/"
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function

    Public Function get_multiple_charges(ByVal rs_id As Integer) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        get_multiple_charges = ""

        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT * FROM dbMultipleCharges WHERE rs_id = " & rs_id
            newCMD = New SqlCommand(query, newSQ.connection)

            newDR = newCMD.ExecuteReader
            While newDR.Read
                Dim process As String = newDR.Item("type_name").ToString
                Dim charge_to_id As Integer = CInt(newDR.Item("all_charges_id").ToString)

                Select Case process
                    Case "EQUIPMENT"
                        get_multiple_charges &= GET_equip_desc_AND_proj_desc(charge_to_id, 1) & "/"
                    Case "PROJECT"
                        get_multiple_charges &= GET_equip_desc_AND_proj_desc(charge_to_id, 2) & "/"
                    Case "WAREHOUSE"
                        get_multiple_charges &= GET_equip_desc_AND_proj_desc(charge_to_id, 4) & "/"
                    Case "PERSONAL"
                        get_multiple_charges &= GET_equip_desc_AND_proj_desc(charge_to_id, 3) & "/"
                    Case "CASH"
                        get_multiple_charges &= GET_equip_desc_AND_proj_desc(charge_to_id, 3) & "/"
                    Case "MAINOFFICE"
                        get_multiple_charges &= GET_equip_desc_AND_proj_desc(charge_to_id, 3) & "/"
                    Case "OTHERS"
                        get_multiple_charges &= GET_equip_desc_AND_proj_desc(charge_to_id, 3) & "/"
                End Select

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function

    Public Function get_multiple_item(ByVal rs_id As Integer) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        get_multiple_item = ""

        Try
            newSQ.connection.Open()

            newCMD = New SqlCommand("proc_borrower_items", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 4)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader
            While newDR.Read

                get_multiple_item &= newDR.Item("item_name").ToString & "/"
            End While

            newDR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function

    Public Function multiple_item(ByVal rs_id As Integer) As String
        Dim mitem As String = get_multiple_item(rs_id)

        If mitem.Length < 1 Then
        Else

            mitem = mitem.Trim().Substring(0, mitem.Length - 1)
            multiple_item = multiple_item & "(" & UCase(mitem) & ")"
        End If

    End Function

    Public Function func_get_datagrid_rowindex(ByVal datagrid As DataGridView) As Integer

        For i As Integer = 0 To datagrid.SelectedCells.Count - 1
            func_get_datagrid_rowindex = datagrid.SelectedCells.Item(i).RowIndex
        Next
    End Function

    Public Function func_get_listview_rowindex(ByVal lv As ListView, Optional id As Integer = 0) As Integer

        Try
            For Each row As ListViewItem In lv.Items
                If row.Text = id Then
                    func_get_listview_rowindex = row.Index
                    Exit For
                End If
            Next

            Return func_get_listview_rowindex
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function

    Public Function select_atleast_one(datagrid As DataGridView) As Integer

        For Each row As DataGridViewRow In datagrid.Rows

            If row.Cells(0).Value = True Then
                select_atleast_one += 1
            End If

        Next

    End Function

    Public Function if_numeric(value As String) As Boolean
        If Not IsNumeric(value) Then
            if_numeric = False
        Else
            if_numeric = True
        End If
    End Function

    Public Sub clear_selected_on_datagrid(dgv As DataGridView)

        For i = 0 To dgv.Rows.Count - 1
            dgv.Rows(i).Selected = False
        Next
    End Sub

    Public Function remove_last_character(value As String) As String
        If value.Length < 1 Then
        Else
            remove_last_character = value.TrimEnd(CChar(","))
        End If
    End Function

    Public Function remove_first_character(value As String) As String
        remove_first_character = value.Remove(0, 1)
    End Function

    Public Function check_if_numeric(value As String) As Decimal

        If IsNumeric(value) = True Then
            check_if_numeric = CDec(value)
        Else
            check_if_numeric = 0
        End If

    End Function

    Public Function convert_lowupcase(value As String, n As Integer) As String
        If value = "" Then
            Exit Function
        End If

        If n = 1 Then
            value = value.ToUpper
        ElseIf n = 2 Then
            value = value.ToLower
        ElseIf n = 3 Then
            value = Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(value.ToLower)
        End If

        convert_lowupcase = value

    End Function


    Public Function calc_month_and_days(datefrom As DateTime, dateto As DateTime) As String

        Dim timespan1 As TimeSpan = dateto - datefrom

        'this code calculate month and days (month1:2, days1:31)
        Dim days1 As Integer = 1
        Dim month1 As Integer = 0
        Dim year As Integer = 0

        Dim counter = 1

        For i = 1 To timespan1.TotalDays
            days1 += 1

            If datefrom.AddDays(i) = datefrom.AddMonths(counter) Then

                'MsgBox(monthfrom.AddMonths(counter))
                month1 += 1
                counter += 1
                days1 = 0

                If month1 = 12 Then
                    year += 1
                    month1 = 0
                End If

            End If
        Next

        'this code convert to string type (ex. 1 month and 3 days)
        Dim result As String = ""
        result = IIf(year > 1, year & " years, ", year & " year,") & " " & IIf(month1 > 1, month1 & " months", month1 & " month") &
           " and " &
           IIf(days1 - 1 > 1, days1 & " days", days1 & " day")

        calc_month_and_days = result


    End Function

    Public Function listview_counter(lview As ListView, func As String) As Integer
        'func - checked or selected 

        For Each row As ListViewItem In lview.Items
            If func = "checked" Then
                If row.Checked = True Then
                    listview_counter += 1
                End If
            ElseIf func = "selected" Then
                If row.Selected = True Then
                    listview_counter += 1
                End If
            End If
        Next
    End Function

    Public Function get_last_row_id(query As String, fieldorder As String, n As Integer) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim order As String = ""

        If n = 0 Then
            order = " ORDER BY " & fieldorder & " ASC"
        ElseIf n = 1 Then
            order = " ORDER BY " & fieldorder & " DESC"
        End If

        newSQ.connection.Open()

        Try
            newCMD = New SqlCommand(query & order, newSQ.connection)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_last_row_id = CInt(newDR.Item(0).ToString)
            End While
            newDR.Close()


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Public Function select_unselect_listview(lvl As ListView, n As Integer)
        For Each row As ListViewItem In lvl.Items
            If n = 1 Then
                row.Checked = True
            ElseIf n = 2 Then
                row.Checked = False
            End If
        Next
    End Function


    Public Sub enable_disable_controls(form As Form, controlname As String, switch1 As Boolean, switch2 As Boolean)

        For Each ctr As Control In form.Controls

            If ctr.Name = controlname Then
                ctr.Visible = switch1
                ctr.Enabled = switch1
            Else
                ctr.Enabled = switch2
            End If

        Next

    End Sub

    Public Function totaltime(ByVal tripstarttime As String, ByVal tripendtime As String, ByVal notconverted As Boolean)
        'Dim Hour, Minutes, Hour1, Minutes1 As Integer
        'Dim total1, total2 As Double
        'Dim value, meridiem, meridiem1 As String
        'If IsNumeric(tripstarttime) = False Then

        'Else
        '    tripstarttime = "00:00:00 AM"
        'End If

        'If IsNumeric(tripendtime) = False Then

        'Else
        '    tripendtime = "00:00:00 AM"
        'End If

        ''MsgBox(Format(Date.Parse(tripstarttime), "HH:mm:ss tt"))

        'Hour = TimeSPlitter(Format(Date.Parse(tripstarttime), "HH:mm:ss tt"), 1)
        'Minutes = TimeSPlitter(Format(Date.Parse(tripstarttime), "HH:mm:ss tt"), 2)
        'meridiem = TimeSPlitter(Format(Date.Parse(tripstarttime), "HH:mm:ss tt"), 4)

        'Hour1 = TimeSPlitter(Format(Date.Parse(tripendtime), "HH:mm:ss tt"), 1)
        'Minutes1 = TimeSPlitter(Format(Date.Parse(tripendtime), "HH:mm:ss tt"), 2)
        'meridiem1 = TimeSPlitter(Format(Date.Parse(tripendtime), "HH:mm:ss tt"), 4)

        ''If Hour = "00" Then
        ''    Hour = 12
        ''End If

        ''If Hour1 = "00" Then
        ''    Hour1 = 12
        ''End If

        'total1 = Hour * 60 + Minutes
        'total2 = Hour1 * 60 + Minutes1

        'If notconverted = True Then
        '    'value = Format(((total2 - total1) / 60), "0.00")
        '    value = (total2 - total1) / 60
        '    value = Math.Truncate(value * 100) / 100
        'Else
        '    value = Convert_Min_to_Hr(total2 - total1)
        'End If
        'Return value

        Dim HRS As TimeSpan
        Dim Hour, Minutes As Integer
        Dim result, final_result As String
        Dim St As TimeSpan = TimeSpan.Parse(Format(Date.Parse(tripstarttime), "HH:mm:ss"))
        Dim Cl As TimeSpan = TimeSpan.Parse(Format(Date.Parse(tripendtime), "HH:mm:ss"))

        HRS = Cl - St

        If HRS.Hours < 0 Then

            HRS = (HRS + New TimeSpan(0, 24, 0, 0, 0))
        Else
            HRS = Cl - St
        End If

        result = HRS.ToString()

        Hour = sp(result, ":", 0)
        Minutes = sp(result, ":", 1)

        result = ((Hour * 60) + Minutes) / 60
        'final_result = Math.Truncate(result * 100) / 100

        final_result = (result * 100) / 100

        Return final_result

    End Function

    Public Function Get_Equipment_Rate(ByVal equiptypeid As Integer) As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim a(10) As String


        Try
            newSQ.connection1.Open()

            Dim query As String = "SELECT * FROM dbequipment_rate WHERE equiptype_id = " & equiptypeid & " AND status = 'true'"
            newCMD = New SqlCommand(query, newSQ.connection1)

            newDR = newCMD.ExecuteReader
            While newDR.Read
                If newDR.Item("type_of_rate").ToString = "rate_per_hour" Then
                    Get_Equipment_Rate = CDbl(newDR.Item("rate_hour").ToString)

                ElseIf newDR.Item("type_of_rate").ToString = "rate_per_day" Then
                    Get_Equipment_Rate = CDbl(newDR.Item("rate_day").ToString)

                ElseIf newDR.Item("type_of_rate").ToString = "rate_per_month" Then
                    Get_Equipment_Rate = CDbl(newDR.Item("rate_month").ToString)

                End If

            End While
            newDR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection1.Close()
        End Try

    End Function
    Public Function LastDayOfMonth(ByVal sourceDate As DateTime) As DateTime
        Dim lastDay As DateTime = New DateTime(sourceDate.Year, sourceDate.Month, 1)
        Return lastDay.AddMonths(1).AddDays(-1)
    End Function

    Public Function get_id2(Optional paramTable As String = "",
                            Optional paramCondition As String = "",
                            Optional columnNameId As String = "",
                            Optional paramConnection As String = "") As Integer


        Dim getId As New Model_Dynamic_Select
        Dim newEnumType As New enumType

        Dim table As String = $"{paramTable}" 'table
        Dim condition As String = paramCondition

        'columns
        getId.join_columns(columnNameId)

        'end columns

        ''inner or left join
        'dynamicEditRR.joining("LEFT JOIN dbSupplier b ")
        'dynamicEditRR.joining("ON b.Supplier_Id = a.supplier_id")\
        'end inner or left join

        'initialize data
        getId._initialize(table, condition, getId.cJoinColumns, getId.cJoining, paramConnection)

        Dim myData As New List(Of Object) 'create a list of ojbect 
        myData = getId.select_query() 'get data

        For Each row In myData
            Dim n As Integer = 0

            For Each kvp As KeyValuePair(Of String, Object) In row
                'MsgBox($"{kvp.Key}: {kvp.Value.ToString()}")

                get_id2 = kvp.Value.ToString
            Next
        Next

    End Function

    Public Function get_specific_data(Optional paramTable As String = "",
                            Optional paramCondition As String = "",
                            Optional columnNameId As String = "",
                            Optional paramConnection As String = "") As String


        Dim getId As New Model_Dynamic_Select
        Dim newEnumType As New enumType

        Dim table As String = $"{paramTable}" 'table
        Dim condition As String = paramCondition

        'columns
        getId.join_columns(columnNameId)

        'end columns

        ''inner or left join
        'dynamicEditRR.joining("LEFT JOIN dbSupplier b ")
        'dynamicEditRR.joining("ON b.Supplier_Id = a.supplier_id")\
        'end inner or left join

        'initialize data
        getId._initialize(table, condition, getId.cJoinColumns, getId.cJoining, paramConnection)

        Dim myData As New List(Of Object) 'create a list of ojbect 
        myData = getId.select_query() 'get data

        For Each row In myData
            Dim n As Integer = 0

            For Each kvp As KeyValuePair(Of String, Object) In row
                'MsgBox($"{kvp.Key}: {kvp.Value.ToString()}")

                get_specific_data = kvp.Value.ToString
            Next
        Next

    End Function

    Public Function CapitalizeEachWord(input As String) As String
        If String.IsNullOrEmpty(input) Then
            Return input
        End If
        Dim textInfo As TextInfo = CultureInfo.CurrentCulture.TextInfo
        Return textInfo.ToTitleCase(input.ToLower())
    End Function

End Module

