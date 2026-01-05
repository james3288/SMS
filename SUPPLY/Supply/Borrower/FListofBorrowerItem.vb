Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FListofBorrowerItem

    Private Sub FListofBorrowerItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' btn_proceed.Location = New Point(gboxBorrowerMonitoringSearch.Width + 970, 28)

        'load_borrower_items()

    End Sub
    Public Sub load_specific_items()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim a(10) As String
        Dim c As Integer

        lvlBorrowerItem.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_items", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 1)

            newDR = newCMD.ExecuteReader
            While newDR.Read

                a(0) = newDR.Item("rs_id").ToString
                a(1) = newDR.Item("rs_no").ToString
                a(2) = newDR.Item("po_no").ToString
                a(3) = newDR.Item("rr_no").ToString
                a(4) = newDR.Item("whItem").ToString.ToUpper & "-" & newDR.Item("whItemDesc").ToString.ToUpper
                'a(9) = newDR.Item("rr_item_id").ToString

                Dim desc As String = newDR.Item("whItem").ToString & "-" & newDR.Item("whItemDesc").ToString

                'If search_by(convert_lowupcase(a(4), 3), convert_lowupcase(ComboBox1.Text, 3)) = True Then
                'Else
                '    GoTo proceedhere
                'End If
                If (a(4).ToUpper).Contains(ComboBox1.Text.ToUpper) Then

                    Dim lvl As New ListViewItem(a)
                    lvlBorrowerItem.Items.Add(lvl)

                    lvlBorrowerItem.Items(c).BackColor = Color.DarkGreen
                    lvlBorrowerItem.Items(c).ForeColor = Color.White
                    c += 1
                    c = load_sub_items(CInt(newDR.Item("rr_item_id").ToString), c, CInt(newDR.Item("rs_id").ToString))

                ElseIf (a(4).ToUpper).Contains(ComboBox1.Text.ToUpper) = False Then
                    ' MessageBox.Show("start")
                    Dim let_display As Boolean = True
                    let_display = read_sub_items(newDR.Item("rr_item_id").ToString, ComboBox1.Text)
                    If let_display = True Then
                        ' MessageBox.Show(let_display)
                        Dim lvl As New ListViewItem(a)
                        lvlBorrowerItem.Items.Add(lvl)

                        lvlBorrowerItem.Items(c).BackColor = Color.DarkGreen
                        lvlBorrowerItem.Items(c).ForeColor = Color.White
                        c += 1
                        c = load_sub_items(CInt(newDR.Item("rr_item_id").ToString), c, CInt(newDR.Item("rs_id").ToString))
                    ElseIf let_display = False Then
                        ' MessageBox.Show(let_display)
                    End If
                Else
                    ' MessageBox.Show("here")
                End If


                'proceedhere:
                'MessageBox.Show("here1")
            End While
            newDR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Public Sub load_borrower_items()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim a(10) As String
        Dim c As Integer

        lvlBorrowerItem.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_items", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 1)

            newDR = newCMD.ExecuteReader
            While newDR.Read

                a(0) = newDR.Item("rs_id").ToString
                a(1) = newDR.Item("rs_no").ToString
                a(2) = newDR.Item("po_no").ToString
                a(3) = newDR.Item("rr_no").ToString
                a(4) = newDR.Item("whItem").ToString.ToUpper & "-" & newDR.Item("whItemDesc").ToString.ToUpper
                'a(9) = newDR.Item("rr_item_id").ToString

                Dim desc As String = newDR.Item("whItem").ToString & "-" & newDR.Item("whItemDesc").ToString

                If search_by(convert_lowupcase(a(4), 3), convert_lowupcase(ComboBox1.Text, 3)) = True Then
                Else
                    GoTo proceedhere
                End If


                Dim lvl As New ListViewItem(a)
                lvlBorrowerItem.Items.Add(lvl)

                lvlBorrowerItem.Items(c).BackColor = Color.DarkGreen
                lvlBorrowerItem.Items(c).ForeColor = Color.White
                c += 1

                c = load_sub_items(CInt(newDR.Item("rr_item_id").ToString), c, CInt(newDR.Item("rs_id").ToString))

proceedhere:

            End While
            newDR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Public Function read_sub_items(ByVal rr_item_id As Integer, ByVal val As String) As Boolean
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim is_have As Boolean = False

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_items", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 2)
            newCMD.Parameters.AddWithValue("@rr_item_id", rr_item_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                If (newDR.Item("item_desc").ToString().ToUpper).Contains(val.ToUpper) Then
                    is_have = True
                End If

            End While
            newDR.Close()

            read_sub_items = is_have
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Function load_sub_items(ByVal rr_item_id As Integer, ByVal c As Integer, rs_id As Integer) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim a(15) As String

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_items", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 2)
            newCMD.Parameters.AddWithValue("@rr_item_id", rr_item_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read

                a(0) = newDR.Item("rr_item_sub_id").ToString
                a(1) = "-"
                a(2) = "-"
                a(3) = "-"
                a(4) = convert_lowupcase(newDR.Item("item_desc").ToString, 3)
                a(5) = newDR.Item("item_no").ToString

                '#Region "No of items"
                a(6) = newDR.Item("qty").ToString
                '#End Region

                '#Region "Item Reserved"
                Dim query1 As String = "SELECT qty FROM dbBorrower_reserved WHERE rr_item_sub_id = " & CInt(a(0))
                Dim qty_reserved As Integer = get_specific_column_value(query1, 3)

                a(8) = qty_reserved
                '#End Region

                '#Region "Item Borrowed"
                Dim query2 As String = "SELECT qty FROM dbborrower_details WHERE rr_item_sub_id = " & CInt(a(0))
                Dim qty_borrowed As Integer = get_specific_column_value(query2, 3)

                a(10) = qty_borrowed
                '#End Region

                '#Region "Item Turnover"
                Dim qty_turnover As Integer = no_of_turnover(CInt(a(0)))
                a(12) = qty_turnover
                '#End Region

                a(8) = CInt(a(8)) - CInt(a(10))
                a(9) = rr_item_id
                a(10) = qty_borrowed - qty_turnover

                a(7) = CInt(a(6)) - CInt(a(10)) 'qty_turnover

                'a(7) = (CInt(newDR.Item("qty").ToString) - if_item_available(CInt(a(0)))) - count_reserved_item(newDR.Item("rr_item_sub_id").ToString)
                'a(8) = count_reserved_item(newDR.Item("rr_item_sub_id").ToString) '- if_item_available(CInt(a(0)))

                'a(9) = rr_item_id
                'a(10) = if_item_available(CInt(a(0)))
                a(11) = if_item_defective(CInt(a(0)), rs_id)
                a(7) = CInt(a(7)) - CInt(a(11))

                'a(7) = CInt(a(7)) - CInt(a(10))

                Dim lvl As New ListViewItem(a)
                lvlBorrowerItem.Items.Add(lvl)

                lvlBorrowerItem.Items(c).BackColor = Color.LightGreen
                lvlBorrowerItem.Items(c).ForeColor = Color.Black

                c += 1

            End While
            newDR.Close()

            load_sub_items = c

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Function no_of_turnover(rr_item_sub_id As Integer) As Decimal
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_items", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 7)
            newCMD.Parameters.AddWithValue("@rr_item_sub_id", rr_item_sub_id)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                no_of_turnover += CDec(newDR.Item("qty").ToString)
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Function count_reserved_item(ByVal rr_item_sub_id As Integer) As Integer
        Dim sql As New SQLcon
        Dim nwcmd As SqlCommand
        Dim nwdr As SqlDataReader
        Try
            sql.connection.Open()
            publicquery = "SELECT * FROM dbBorrower_reserved WHERE rr_item_sub_id = '" & rr_item_sub_id & "' "
            nwcmd = New SqlCommand(publicquery, sql.connection)
            nwdr = nwcmd.ExecuteReader
            While nwdr.Read

                'check if rr_item_sub_id naa na sa borrower_details
                If check_if_exist("dbborrower_details", "rr_item_sub_id", CInt(nwdr.Item("rr_item_sub_id").ToString), 1) > 0 Then
                    'if rs_id naa na sa borrower_details. check napud sa dbborrower_turnover_details kung na turnover na ba

                    'get ang br_tr_det_id
                    Dim br_tr_det_id As Integer = get_id("dbborrower_details", "rr_item_sub_id", CInt(nwdr.Item("rr_item_sub_id").ToString), 1)

                    If check_if_exist("dbborrower_turnover_details", "br_tr_det_id", br_tr_det_id, 1) > 0 Then
                        'if turnover na.
                    Else
                        'if naa siya sa borrower_details pero wala pa na turnover
                        'minus na ang reserve ky na borrow naman, wala palang ge uli.

                        Dim query1 As String = "SELECT qty FROM dbborrower_details WHERE br_tr_det_id = " & br_tr_det_id
                        count_reserved_item += CInt(nwdr.Item("qty").ToString) - get_specific_column_value(query1, 1)
                    End If
                Else 'if rs_id wala pa sa borrower_details pero naa na sa dbBorrower_reserved
                    count_reserved_item += CInt(nwdr.Item("qty").ToString)
                End If

            End While
            nwdr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sql.connection.Close()
        End Try
    End Function

    Public Function if_item_available(ByVal rr_item_sub_id As Integer) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 3)
            newCMD.Parameters.AddWithValue("@rr_item_sub_id", rr_item_sub_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read

                Dim return_qty As Decimal = return_qty_of_turnoveritem(CInt(newDR.Item("br_tr_det_id").ToString))
                if_item_available += CDec(newDR.Item("qty").ToString) - return_qty

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function

    Public Function if_item_defective(ByVal rr_item_sub_id As Integer, rs_id As Integer) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 33)
            newCMD.Parameters.AddWithValue("@rr_item_sub_id", rr_item_sub_id)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim br_tr_det_id As Integer = CInt(newDR.Item("br_tr_det_id").ToString)

                If check_if_exist("dbborrower_turnover_details", "br_tr_det_id", br_tr_det_id, 1) > 0 Then
                    if_item_defective = return_qty_defective(CInt(newDR.Item("br_tr_det_id").ToString))
                Else
                End If

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function

    Public Function return_qty_of_turnoveritem(ByVal br_tr_det_id As Integer) As Decimal
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT a.qty FROM dbborrower_turnover_details a "
            query &= "WHERE a.br_tr_det_id = " & br_tr_det_id

            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read

                return_qty_of_turnoveritem += CDec(newDR.Item("qty").ToString())

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Public Function return_qty_defective(ByVal br_tr_det_id As Integer) As Decimal
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT * FROM dbborrower_turnover_details WHERE br_tr_det_id = '" & br_tr_det_id & "'"

            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim to_items_id As Integer = CInt(newDR.Item("to_items_id").ToString)

                'If check_if_Defective(to_items_id) = True Then

                '    return_qty_defective += CInt(newDR.Item("qty").ToString())
                'Else
                '    return_qty_defective = 0
                'End If
                If newDR.Item("item_stat").ToString = "Defective" Then
                    return_qty_defective += CDec(newDR.Item("qty").ToString())
                End If

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Public Function check_if_Defective(ByVal to_items_id As Integer) As Boolean
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT * FROM dbborrower_turnover_details WHERE to_items_id = '" & to_items_id & "'"

            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                If newDR.Item("item_stat").ToString = "Defective" Then
                    check_if_Defective = True

                End If
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function


    Public Sub get_mark_fac_tools(ByVal marker As String)
        Dim sqL As New SQLcon
        Dim existitem As Boolean = False


        With ComboBox1
            .Items.Clear()

            '  .Items.Clear()
            Try
                sqL.connection.Open()
                Dim cmd As SqlCommand = New SqlCommand("proc_borrower_items", sqL.connection)
                cmd.Parameters.Clear()
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@n", 3)
                cmd.Parameters.AddWithValue("@marker", marker)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                While dr.Read
                    For Each item As String In .Items
                        If (dr.Item("whItem").ToString.ToUpper & "-" & dr.Item("whItemDesc").ToString.ToUpper) = item Then
                            existitem = True
                        End If
                    Next
                    If existitem = False Then
                        .Items.Add(dr.Item("whItem").ToString.ToUpper & "-" & dr.Item("whItemDesc").ToString.ToUpper)
                    Else
                        existitem = False
                    End If

                End While
                dr.Close()
            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                sqL.connection.Close()
            End Try
        End With
    End Sub

    Private Sub SetItemNoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SetItemNoToolStripMenuItem.Click
        'txtset.Text = 0
        'txtset.Focus()

        'For Each ctr As Control In Me.Controls
        '    If ctr.Name = "Panel5" Then
        '        ctr.Parent = Me
        '        ctr.Visible = True
        '        ctr.BringToFront()

        '    Else
        '        ctr.Enabled = False
        '    End If
        'Next

        FBorrower_Set_Item_No.ShowDialog()

    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs)
        For Each ctr As Control In Me.Controls
            If ctr.Name = "Panel5" Then
                ctr.Visible = False
            Else
                ctr.Enabled = True
            End If
        Next
    End Sub

    Private Sub btnSet_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim sub_id As Integer = CInt(lvlBorrowerItem.SelectedItems(0).Text)
        'Dim query As String = "UPDATE dbreceiving_items_sub SET item_no = " & CInt(txtset.Text) & " WHERE rr_item_sub_id = " & sub_id
        'UPDATE_INSERT_DELETE_QUERY(query, 0, "UPDATE")

        ' panel_btn_close.PerformClick()

        load_borrower_items()
        listfocus(lvlBorrowerItem, sub_id)

    End Sub

    Private Sub ViewDetailsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ViewDetailsToolStripMenuItem.Click

        With FBorrower_Details
            .lvlMultipleCustodian.Enabled = True
            .btnReturnthisItem.Enabled = True
            .txtBsNo.Enabled = False
            .txtPurpose.Enabled = False
            .txtWithdrawn.Enabled = False
            .txtReleased.Enabled = False
            .txtNotedBy.Enabled = False
            .txtApproved_by.Enabled = False
            .txtRemarks.Enabled = False
            .lvlBorrowerItem.Enabled = True
            .btnToggle.Enabled = False
            .DtpDate.Enabled = False
            .cmbChargesDesc.Enabled = False
            .cmbChargesType.Enabled = False
            .btnAddTempCustodian.Enabled = False
            .cmbSelectBSorTS.Enabled = False
            .btnSave.Enabled = False
            .CMS_lvlBorrowerItem.Items(1).Enabled = True
            .CMS_lvlBorrowerItem.Items(2).Enabled = True

            .lvlMultipleCustodian.Items.Clear()
            .lvlMultipleCustodian.Visible = False
            .cmbSearchBy.Text = "CUSTODIAN"

            'FBorrower_Details.search_borrowed_items()

            .cmbSearchBy.Enabled = True
            .txtSearch.Enabled = True
            .btnSearch.Enabled = True

            .Show()
            .lvlMultipleCustodian.Items.Clear()

        End With

    End Sub

    Public Function return_estimated_days(ByVal br_tr_det_id As Integer, ByVal n As Integer) As Integer
        Dim query As String = Nothing
        If n = 1 Then
            query = "SELECT estimated_days_return FROM dbBorrower_expiration WHERE br_tr_det_id = " & br_tr_det_id
        ElseIf n = 2 Then
            query = "SELECT extended FROM dbBorrower_expiration WHERE br_tr_det_id = " & br_tr_det_id
        End If

        return_estimated_days = get_specific_column_value(query, 1)

    End Function
    Public Function return_turnover_item_qty(ByVal br_tr_det_id As Integer) As Decimal
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 8)
            newCMD.Parameters.AddWithValue("@br_tr_det_id", br_tr_det_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                return_turnover_item_qty += CDec(newDR.Item("qty").ToString)
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Function load_multiple_charges(ByVal multiplecharges As String) As String
        load_multiple_charges = ""

        If multiplecharges = "" Or multiplecharges = Nothing Then
            Exit Function
        End If

        Dim charges_array() As String
        Dim splittedcharges() As String
        charges_array = multiplecharges.Split(",")

        Dim charges As New function_charges

        For Each a As String In charges_array.ToArray
            splittedcharges = a.Split(":")

            load_multiple_charges &= charges.charges_desc(splittedcharges(0), CInt(splittedcharges(1))) & ","

        Next

        load_multiple_charges = remove_last_character(load_multiple_charges)
    End Function

    Public Function return_from(ByVal from As String) As String

        Dim returnfrom As String = ""
        Dim str As String = ""

        If from = "" Or from = Nothing Then
            Exit Function
        End If

        Dim charges_array() As String
        Dim splittedcharges() As String
        charges_array = from.Split(",")

        Dim charges As New function_charges

        For Each a As String In charges_array.ToArray

            splittedcharges = a.Split(":")

            For Each b As String In splittedcharges.ToArray

                If b = "RETURN FROM" Then
                    return_from = str
                ElseIf b = "RETURN TO" Then

                Else
                    str &= b & ":"
                End If

            Next
        Next

    End Function

    Public Function return_to(ByVal rTo As String) As String

        Dim returnto As String = ""
        Dim str As String = ""

        If rTo = "" Or rTo = Nothing Then
            Exit Function
        End If

        Dim charges_array() As String
        Dim splittedcharges() As String
        charges_array = rTo.Split(",")

        Dim charges As New function_charges

        For Each a As String In charges_array.ToArray

            splittedcharges = a.Split(":")

            For Each b As String In splittedcharges.ToArray

                If b = "RETURN TO" Then
                    return_to = str
                ElseIf b = "RETURN FROM" Then

                Else
                    str &= b & ":"
                End If

            Next
        Next

    End Function


    Private Sub CreateBorrowerSlipToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CreateBorrowerSlipToolStripMenuItem.Click
        FBorrower_Details.lvlBorrowerItem.Items.Clear()
        FBorrower_Details.lvlMultipleCustodian.Items.Clear()


        For Each row As ListViewItem In lvlBorrowerItem.Items
            If row.BackColor = Color.DarkGreen Then
            Else
                If row.Checked = True Then
                    Dim a(22) As String

                    a(0) = row.Text
                    a(1) = row.SubItems(4).Text
                    a(2) = row.SubItems(7).Text
                    a(3) = row.SubItems(8).Text
                    a(4) = ""
                    a(5) = ""
                    a(6) = ""
                    a(7) = ""
                    a(8) = ""
                    a(9) = ""
                    a(10) = ""
                    a(11) = ""
                    a(12) = ""
                    a(13) = ""
                    a(14) = ""
                    a(15) = ""
                    a(16) = ""
                    a(17) = ""

                    If CInt(a(2)) = 0 Then
                        MessageBox.Show("qty available of " & a(1) & " is already zero.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        GoTo proceedhere
                    End If

                    Dim lvl As New ListViewItem(a)
                    FBorrower_Details.lvlBorrowerItem.Items.Add(lvl)

                End If
            End If
proceedhere:
        Next

        With FBorrower_Details
            .lvlMultipleCustodian.Enabled = True
            .btnReturnthisItem.Enabled = False


            .txtBsNo.Enabled = True
            .txtPurpose.Enabled = True
            .txtWithdrawn.Enabled = True
            .txtReleased.Enabled = True
            .txtNotedBy.Enabled = True
            .txtApproved_by.Enabled = True
            .txtRemarks.Enabled = True
            .lvlBorrowerItem.Enabled = True
            .btnToggle.Enabled = True
            .DtpDate.Enabled = True
            .cmbChargesDesc.Enabled = True
            .cmbChargesType.Enabled = True
            .btnAddTempCustodian.Enabled = True
            .cmbSelectBSorTS.Enabled = True
            .btnSave.Enabled = True

            .CMS_lvlBorrowerItem.Items(1).Enabled = False
            .CMS_lvlBorrowerItem.Items(2).Enabled = False

            .cmbSearchBy.Enabled = False
            .txtSearch.Enabled = False
            .btnSearch.Enabled = False


            .ShowDialog()
        End With

    End Sub


    Private Sub ViewHistoryOfThisItemToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ViewHistoryOfThisItemToolStripMenuItem.Click
        FBorrower_History.rr_item_sub_id = CInt(lvlBorrowerItem.SelectedItems(0).Text)
        FBorrower_History.ShowDialog()

    End Sub

    Private Sub Panel3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub


    Public Sub insert_info_items(desiredqty As Integer)
        Dim SQLconn As New SQLcon
        Dim command As SqlCommand
        Try
            SQLconn.connection.Open()

            publicquery = "INSERT INTO dbBorrower_checking_info (rs_id, rs_no) VALUES ('" & rs_id & "', '" & rs_no & "')"
            command = New SqlCommand(publicquery, SQLconn.connection)
            command.ExecuteNonQuery()

            Dim query As String = "SELECT checking_info_id FROM dbBorrower_checking_info WHERE rs_id = " & rs_id
            Dim checkingInfo_id As Integer = get_specific_column_value(query, 1)

            For Each item As ListViewItem In lvlBorrowerItem.CheckedItems

                insert_borrowerchercking_items(checkingInfo_id, item.Text, item.SubItems(4).Text, item.SubItems(5).Text, desiredqty, item.SubItems(9).Text)
            Next

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLconn.connection.Close()
        End Try
    End Sub

    Public Sub insert_borrowerchercking_items(ByVal checking_info_id As Integer, ByVal rrItem_sub_id As Integer, ByVal item_name As String, ByVal itemNo As String, ByVal qty As Integer, ByVal rritem_id As Integer)
        Dim newSQLcon As New SQLcon
        Dim newCMD As SqlCommand

        Try

            newSQLcon.connection.Open()

            publicquery = "INSERT INTO dbBorrower_checking_items (checking_info_id, rr_item_sub_id, item_name, item_no, qty, rr_item_id) VALUES ('" & checking_info_id & "', '" & rrItem_sub_id & "',"
            publicquery &= "'" & item_name & "', '" & itemNo & "', '" & qty & "', '" & rritem_id & "')"
            newCMD = New SqlCommand(publicquery, newSQLcon.connection)

            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQLcon.connection.Close()
        End Try

    End Sub

    Public Sub update_requestionslip(ByVal rsid As Integer, ByVal n As Integer)
        Dim nwSQL As New SQLcon
        Dim nwCMD As SqlCommand
        Dim in_out As String

        If n = 0 Then
            in_out = "BORROWER"
        ElseIf n = 1 Then
            in_out = "TURNOVER"
        ElseIf n = 2 Then
            in_out = "BORROWED"
        End If

        Try
            nwSQL.connection.Open()
            publicquery = "UPDATE dbrequisition_slip SET IN_OUT = '" & in_out & "'WHERE rs_id = '" & rsid & "'"
            nwCMD = New SqlCommand(publicquery, nwSQL.connection)
            nwCMD.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            nwSQL.connection.Close()
            'FRequistionForm.btnSearch.PerformClick()
        End Try

    End Sub

    Public Function get_borrwed_item(ByVal rs_id As Integer, ByVal n As Integer) As String
        Dim nwSQL2 As New SQLcon
        Dim nwCMD2 As SqlCommand
        Dim nwDR2 As SqlDataReader
        Dim count As Integer = 0

        Try
            nwSQL2.connection.Open()
            publicquery = "SELECT * FROM dbborrower_details WHERE rs_id = " & rs_id
            nwCMD2 = New SqlCommand(publicquery, nwSQL2.connection)
            nwDR2 = nwCMD2.ExecuteReader
            While nwDR2.Read

                If nwDR2.Item("qty").ToString = get_turnover_qty(CInt(nwDR2.Item("br_tr_det_id").ToString)) Then
                    If n = 0 Then
                    ElseIf n = 1 Then
                        get_borrwed_item = "TURNOVER"

                    End If
                Else
                    If n = 0 Then
                        get_borrwed_item = nwDR2.Item("sub_item_desc").ToString
                    ElseIf n = 1 Then
                        count += 1
                    End If

                End If

                If n = 0 Then
                ElseIf n = 1 Then
                    If count <> 0 Then
                        get_borrwed_item = "PARTIALLY TURNOVER"
                    End If
                End If

            End While

            nwDR2.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            nwSQL2.connection.Close()
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try
    End Function

    Public Function get_turnover_qty(ByVal br_tr_det_id As Integer) As Integer
        Dim nwSQL1 As New SQLcon
        Dim nwCMD1 As SqlCommand
        Dim nwDR1 As SqlDataReader

        Try
            nwSQL1.connection.Open()
            publicquery = "SELECT * FROM dbborrower_turnover_details WHERE br_tr_det_id = " & br_tr_det_id
            nwCMD1 = New SqlCommand(publicquery, nwSQL1.connection)
            nwDR1 = nwCMD1.ExecuteReader
            While nwDR1.Read
                get_turnover_qty += nwDR1.Item("qty").ToString
            End While
            nwDR1.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            nwSQL1.connection.Close()
        End Try
    End Function

    Private Sub cmbSearchBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearchBy.SelectedIndexChanged
        If cmbSearchBy.Text = "FACILITIES" Then
            ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
            get_mark_fac_tools(cmbSearchBy.Text)
        ElseIf cmbSearchBy.Text = "TOOLS" Then
            ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
            get_mark_fac_tools(cmbSearchBy.Text)
        ElseIf cmbSearchBy.SelectedIndex = 2 Then
            ComboBox1.DropDownStyle = ComboBoxStyle.Simple
        End If
        get_mark_fac_tools(cmbSearchBy.Text)
    End Sub

    Private Sub btnBMsearch_Click(sender As Object, e As EventArgs) Handles btnBMsearch.Click
        If cmbSearchBy.SelectedIndex = 2 Then
            load_specific_items()
        Else
            load_borrower_items()
        End If


    End Sub

    Private Sub btn_proceed_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_proceed.Click

        If MessageBox.Show("Are you sure you want borrow this selected item?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If lvlBorrowerItem.CheckedItems.Count <= 0 Then
                MessageBox.Show("Pls check at least one(1) Check box to Proceed.", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                For Each check_item As ListViewItem In lvlBorrowerItem.CheckedItems
                    If check_item.SubItems(7).Text = 0 Then 'check_item.SubItems(8).Text Then
                        MessageBox.Show("SORRY..!" & vbCr & check_item.SubItems(4).Text & "is no longer available..", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return

                    ElseIf check_item.SubItems(6).Text = CInt(check_item.SubItems(8).Text) + CInt(check_item.SubItems(10).Text) Then
                        MessageBox.Show("SORRY..!" & vbCr & check_item.SubItems(4).Text & "is no longer available1..", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return

                    Else
                        Dim desired_qty As Integer = get_qty_inputted(check_item.SubItems(4).Text)
                        Dim available_qty As Integer = CInt(check_item.SubItems(7).Text)

                        If desired_qty > available_qty Then
                            MessageBox.Show("desired qty must not be greater than the available qty from " &
                                            check_item.SubItems(4).Text & ".", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            insert_reserved_item(check_item.Text, check_item.SubItems(4).Text, desired_qty)
                            insert_info_items(desired_qty)
                            update_requestionslip(rs_id, 0)
                        End If

                    End If
                Next

                Me.Hide()
                Me.Dispose()
                listfocus(FRequistionForm.lvlrequisitionlist, rs_id)

            End If
        End If

    End Sub
    Public Function get_qty_inputted(item As String) As Integer
        Try
            Dim prompt As String = String.Empty
            Dim title As String = String.Empty
            Dim defaultResponse As String = String.Empty

            Dim answer As Object
            ' Set prompt.
            prompt = "desired qty of this item: "
            ' Set title.
            title = "Qty"
            ' Set default value.
            defaultResponse = "0"

            ' Display prompt, title, and default value.
            answer = InputBox(prompt, title, defaultResponse)

            If String.IsNullOrEmpty(answer) Then
                ' Cancelled, or empty
            Else
                If IsNumeric(answer) = True Then
                    get_qty_inputted = answer
                Else
                    MessageBox.Show("qty of " & item & " must be numeric.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Sub insert_reserved_item(ByVal rr_item_sub_id As Integer, ByVal item_desc As String, qty As Integer)
        Dim newsq As New SQLcon
        Dim newcmd As SqlCommand

        Try
            newsq.connection.Open()
            publicquery = "INSERT INTO dbBorrower_reserved(rs_id, rs_no, rr_item_sub_id, item_desc,qty) VALUES ('" & rs_id & "', '" & rs_no & "', '" & rr_item_sub_id & "', '" & item_desc & "'," & qty & ")"
            newcmd = New SqlCommand(publicquery, newsq.connection)
            newcmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsq.connection.Close()
        End Try
    End Sub

    Private Sub SetItemNameToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SetItemNameToolStripMenuItem.Click
        FBorrower_Set_Item.ShowDialog()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub CMS_lvl_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CMS_lvl.Opening
        If lvlBorrowerItem.SelectedItems(0).BackColor = Color.DarkGreen Then
            CMS_lvl.Items("SetItemNoToolStripMenuItem").Enabled = False
        Else
            CMS_lvl.Items("SetItemNoToolStripMenuItem").Enabled = True
        End If
    End Sub
End Class