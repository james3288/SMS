Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FWithdrawalSlip
    Dim SQLcon As New SQLcon
    Dim sqldr As SqlDataReader
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Dim ws_info_id As Integer
    Dim backspace As Boolean
    Dim n As Integer
    Dim name2 As String
    Dim chargeto1 As String
    Dim chargeto2 As String
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
        lblchargeTo_id.Refresh()
        clear()
    End Sub

    Private Sub FWithdrawalSlip_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub FWithdrawalSlip_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim a(10) As String
        Dim newSQ As New SQLcon

        lbox_withdrawby.Visible = False
        Panel_chargeTo.Visible = False
        txtChargeto.Visible = True

            dgWithdrawItems.Rows.Clear()

            Try
                newSQ.connection.Open()
                cmd = New SqlCommand("proc_withdrawal_new", newSQ.connection)
                cmd.Parameters.Clear()
                cmd.CommandType = CommandType.StoredProcedure

            If btnSave.Text = "Save" Then
                cmd.Parameters.AddWithValue("@n", 1)
                Dim rs_no As String = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(1).Text
                cmd.Parameters.AddWithValue("@rs_no", rs_no)

            ElseIf btnSave.Text = "Update" Then
                cmd.Parameters.AddWithValue("@n", 4)
                cmd.Parameters.AddWithValue("@rs_id", CInt(lbl_rs_id.Text))

            ElseIf btnSave.Text = "Withdraw" Then
                cmd.Parameters.AddWithValue("@n", 1)
                Dim rs_no As String = FWithdrawalList.lvlwithdrawalList.SelectedItems(0).SubItems(2).Text
                cmd.Parameters.AddWithValue("@rs_no", rs_no)
            End If

                sqldr = cmd.ExecuteReader

            While sqldr.Read

                If btnSave.Text = "Save" Then
                    Dim if_exist_rsid_in_ws_item As Integer = check_if_exist("dbwithdrawal_items", "rs_id", CInt(sqldr.Item("rs_id").ToString), 1)
                    If if_exist_rsid_in_ws_item > 0 Then
                        GoTo proceedhere
                    End If

                ElseIf btnSave.Text = "Withdraw" Then
                    Dim if_rs_id_exist As Integer = check_if_exist("dbwithdrawn_items", "rs_id", CInt(sqldr.Item("rs_id").ToString), 1)
                    If if_rs_id_exist > 0 Then : GoTo proceedhere : End If
                End If

                a(2) = sqldr.Item("qty").ToString
                a(3) = sqldr.Item("unit").ToString
                a(4) = sqldr.Item("ITEM_DESC").ToString
                a(6) = FReceivingReport.multiplecharges(sqldr.Item("rs_id").ToString, 1)
                a(7) = sqldr.Item("rs_id").ToString

                txtRSNo.Text = sqldr.Item("rs_no").ToString

                dgWithdrawItems.Rows.Add(a)

proceedhere:

            End While

            sqldr.Close()

            If btnSave.Text = "Update" Or btnSave.Text = "Withdraw" Then
                For Each row As DataGridViewRow In dgWithdrawItems.Rows
                    row.Cells(1).Value = True
                    row.Cells(4).ReadOnly = True
                Next
            End If

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try


        'If check_if_exist("dbwithdrawal_info", "ws_info_id", Val(lbl_ws_info_id.Text), 0) > 0 Then
        '    'If check_if_exist("dbwithdrawal_info", "rs_no", Val(txtRSNo.Text, 0) > 0 Then

        '    'cmb_chargeto.Location = New System.Drawing.Point(txtChargeto.Location.X, txtChargeto.Location.Y)
        '    'cmb_chargeto.Width = txtWSNo.Width

        '    charge_to(FWithdrawalList.lvlwithdrawalList.SelectedItems(0).SubItems(2).Text)
        '    load_from_ws_info()
        '    load_from_ws_item()

        '    btnSave.Text = "Update"
        '    txtLocation.Enabled = False
        '    txtRSNo.Enabled = False
        '    txtChargeto.Enabled = False
        '    'dgWithdrawItems.Columns(1).Visible = False
        'Else
        '    txtChargeto.Enabled = False
        '    PictureBox2.Enabled = False
        '    txtLocation.Enabled = False
        '    txtRSNo.Enabled = False
        '    'view_item_from_rs()
        '    'getRSno(txtRSNo.Text)


        '    view_item_from_rs(1)
        '    charge_to(lblRs_no.Text)
        '    txtRSNo.Text = lblRs_no.Text
        '    btnSave.Text = "Save"
        '    txtLocation.Enabled = False
        '    'dgWithdrawItems.Columns(1).Visible = False
        'End If

        ''With FRequistionForm
        ''    If .lvlrequisitionlist.SelectedItems.Count > 0 Then
        ''        view_item_info()
        ''        disable_field()
        ''        btnSave.Text = "Save"
        ''    End If

        ''End With

       
    End Sub


    Public Sub charge_to(ByVal id As Integer)
        Try
            SQLcon.connection.Open()
            publicquery = "SELECT * FROM dbrequisition_slip WHERE rs_no = '" & lblRs_no.Text & "' "
            cmd = New SqlCommand(publicquery, SQLcon.connection)
            sqldr = cmd.ExecuteReader
            While sqldr.Read
                If sqldr.Item("process").ToString = "PROJECT" Then
                    txtChargeto.Text &= GET_equip_desc_AND_proj_desc(sqldr.Item("charge_to").ToString, 2)
                ElseIf sqldr.Item("process").ToString = "EQUIPMENT" Then
                    txtChargeto.Text &= GET_equip_desc_AND_proj_desc(sqldr.Item("charge_to").ToString, 1)
                ElseIf sqldr.Item("process").ToString = "PERSONAL" Or sqldr.Item("process").ToString = "ADFIL" Then
                    txtChargeto.Text &= GET_equip_desc_AND_proj_desc(sqldr.Item("charge_to").ToString, 3)
                ElseIf sqldr.Item("process").ToString = "WAREHOUSE" Then
                    txtChargeto.Text &= GET_equip_desc_AND_proj_desc(sqldr.Item("charge_to").ToString, 4)
                End If
            End While
            sqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try

    End Sub

    Public Sub view_item_from_rs()
        Dim row As Integer
        dgWithdrawItems.Rows.Clear()
        Try
            SQLcon.connection.Open()
            cmd = New SqlCommand("proc_withdrawal_crud", SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@rsNo", FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(0).Text)
            cmd.Parameters.AddWithValue("@crud", 1)
            sqldr = cmd.ExecuteReader
            While sqldr.Read
                Dim a(10) As String

                If sqldr.Item("IN_OUT").ToString = "OUT" Then
                    txtRSNo.Text = sqldr.Item("rs_no").ToString

                    'txtChargeto.Text = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(13).Text
                    txtLocation.Text = sqldr.Item("location").ToString
                    lblchargeTo_id.Text = sqldr.Item("charge_to").ToString
                    txtWithdrawFrom.Text = get_warehouse_area(sqldr.Item("wh_id").ToString)

                    a(0) = sqldr.Item("wh_id").ToString
                    a(1) = sqldr.Item("qty").ToString()
                    a(2) = sqldr.Item("unit").ToString
                    a(3) = sqldr.Item("item_desc").ToString()
                    a(4) = sqldr.Item("rs_id").ToString

                    dgWithdrawItems.Rows.Add(a)

                    'If check_if_rs_cancel(sqldr.Item("rs_id").ToString) > 0 Then
                    '    With dgWithdrawItems.Rows(row)
                    '        For i = 0 To 3
                    '            .Cells(i).Style.BackColor = Color.Red
                    '            .Cells(i).Style.ForeColor = Color.White
                    '        Next
                    '    End With
                    'End If

                    'row += 1

                End If
            End While
            sqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub

    Public Sub getRSno(ByVal rs_no As Integer)
        Dim SQ As New SQLcon
        Dim DR As SqlDataReader
        Try
            SQ.connection.Open()
            publicquery = "SELECT * FROM dbrequisition_slip WHERE rs_no = '" & rs_no & "'"
            cmd = New SqlCommand(publicquery, SQ.connection)
            DR = cmd.ExecuteReader
            While DR.Read
                txtRSNo.Text = DR.Item("rs_no").ToString
            End While
            DR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
            view_item_from_rs(1)
            'countRS(txtRSNo.Text)
        End Try
    End Sub

    Public Sub clear()
        txtWSNo.Clear()
        txtChargeto.Clear()
        'cmb_chargeto.Text = ""
        txtLocation.Clear()
        txtRSNo.Clear()
        DTPDateWithdraw.Refresh()
        txtWithdrawby.Clear()
        txtWithdrawFrom.Clear()
        txtReleasedby.Clear()
        chargeto1 = ""
        chargeto2 = ""
        dgWithdrawItems.Rows.Clear()
        lbox_withdrawby.Visible = False
        txtWSNo.Focus()
    End Sub

    Public Sub disable_field()
        txtRSNo.Enabled = False
        txtChargeto.Enabled = False
        txtLocation.Enabled = False
        ' DTPDateNeeded.Enabled = False
        txtWithdrawFrom.Enabled = False
    End Sub

    Public Sub load_from_ws_info()

        txtWithdrawFrom.Text = FWithdrawalList.lvlwithdrawalList.SelectedItems(0).SubItems(8).Text
        txtWithdrawby.Text = FWithdrawalList.lvlwithdrawalList.SelectedItems(0).SubItems(9).Text
        txtReleasedby.Text = FWithdrawalList.lvlwithdrawalList.SelectedItems(0).SubItems(10).Text
        PictureBox2.Enabled = True

        Try
            SQLcon.connection.Open()
            publicquery = "SELECT * FROM dbwithdrawal_info WHERE ws_info_id = '" & lbl_ws_info_id.Text & "'"

            cmd = New SqlCommand(publicquery, SQLcon.connection)
            sqldr = cmd.ExecuteReader
            While sqldr.Read
                lbl_withdrawInfoID.Text = sqldr.Item("ws_info_id").ToString
                txtWSNo.Text = sqldr.Item("ws_no").ToString
                txtRSNo.Text = sqldr.Item("rs_no").ToString
                'txtChargeto.Text = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(13).Text
                txtLocation.Text = sqldr.Item("location").ToString
                DTPDateWithdraw.Text = sqldr.Item("date_withdraw").ToString
                'txtWithdrawFrom.Text = sqldr.Item("withdraw_from").ToString
                '  txtWithdrawby.Text = sqldr.Item("withdraw_by").ToString
                'txtReleasedby.Text = sqldr.Item("released_by").ToString
                lblchargeTo_id.Text = sqldr.Item("charge_to").ToString

            End While
            sqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
            'TypeOfRequest(lbl_ws_info_id.Text)
        End Try
    End Sub

    Public Sub load_from_ws_item()
        dgWithdrawItems.Rows.Clear()
        Try
            SQLcon.connection.Open()
            publicquery = "SELECT a.ws_info_id,b.ws_no,a.wh_id,a.qty,a.unit,a.item_desc,a.rs_id,a.item_name,c.process,c.charge_to, a.ws_item_id " & _
            "FROM dbwithdrawal_items a INNER JOIN dbwithdrawal_info b ON a.ws_info_id = b.ws_info_id " & _
            "INNER JOIN dbrequisition_slip c ON a.rs_id = c.rs_id WHERE a.ws_info_id= '" & lbl_ws_info_id.Text & "'"

            cmd = New SqlCommand(publicquery, SQLcon.connection)
            sqldr = cmd.ExecuteReader
            While sqldr.Read

                Dim a(10) As String

                a(0) = sqldr.Item("wh_id").ToString()
                a(2) = sqldr.Item("qty").ToString()
                a(3) = sqldr.Item("unit").ToString()
                a(4) = sqldr.Item("item_name").ToString()
                a(5) = sqldr.Item("item_desc").ToString()
                a(7) = sqldr.Item("rs_id").ToString()
                a(8) = sqldr.Item("ws_item_id").ToString

                Dim process As String = sqldr.Item("process").ToString
                charge_to_id = sqldr.Item("charge_to").ToString

                Select Case process
                    Case "EQUIPMENT"
                        a(6) = GET_equip_desc_AND_proj_desc(charge_to_id, 1)
                    Case "PROJECT"
                        a(6) = GET_equip_desc_AND_proj_desc(charge_to_id, 2)
                    Case "WAREHOUSE"
                        a(6) = GET_equip_desc_AND_proj_desc(charge_to_id, 4)
                    Case "PERSONAL"
                        a(6) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                    Case "CASH"
                        a(6) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                    Case "ADFIL"
                        'a(6) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                        a(6) = FReceivingReport.multiplecharges(CInt(sqldr.Item("rs_id").ToString), 1)
                End Select

                dgWithdrawItems.Rows.Add(a)

            End While
            sqldr.Close()

            dgWithdrawItems.AllowUserToAddRows = False

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub

    Public Sub view_item_from_rs(ByVal nn As Integer)
        Dim row As Integer
        dgWithdrawItems.Rows.Clear()
        Try
            SQLcon.connection.Open()
            cmd = New SqlCommand("proc_withdrawal_crud", SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            If nn = 0 Then
                cmd.Parameters.AddWithValue("@rs_id", lbl_reqID.Text)
                cmd.Parameters.AddWithValue("@crud", 1)
            ElseIf nn = 1 Then
                cmd.Parameters.AddWithValue("@rsNo", lblRs_no.Text)
                cmd.Parameters.AddWithValue("@crud", 2)
            End If

            sqldr = cmd.ExecuteReader

            While sqldr.Read
                Dim a(10) As String
                Dim new_whid As Integer = check_if_exist("warehouse_items_new", "id", sqldr.Item("wh_id").ToString, 1)
                Dim old_whid As Integer = check_if_exist("dbwarehouse_items", "wh_id", sqldr.Item("wh_id").ToString, 1)
                If sqldr.Item("IN_OUT").ToString = "OUT" Then

                    'txtChargeto.Text = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(13).Text
                    txtLocation.Text = sqldr.Item("location").ToString
                    lblchargeTo_id.Text = sqldr.Item("charge_to").ToString
                    txtRSNo.Text = rs_no
                    txtWithdrawFrom.Text = get_warehouse_area(sqldr.Item("wh_id").ToString)

                    a(0) = sqldr.Item("wh_id").ToString()
                    a(2) = sqldr.Item("qty").ToString()
                    a(3) = sqldr.Item("unit").ToString()
                    'a(4) = get_item_name_warehouse(sqldr.Item("wh_id").ToString())
                    a(5) = sqldr.Item("item_desc").ToString()
                    a(7) = sqldr.Item("rs_id").ToString()

                    If new_whid = old_whid Then
                        If check_if_exist("warehouse_items_new", "Whitem_Desc", sqldr.Item("item_desc").ToString(), 0) > 0 Then
                            a(4) = get_Item_name(sqldr.Item("wh_id").ToString, 1)
                        Else
                            a(4) = get_Item_name(sqldr.Item("wh_id").ToString, 2)
                        End If
                    Else
                        a(4) = get_Item_name(sqldr.Item("wh_id").ToString, 2)
                    End If

                    Dim process As String = sqldr.Item("process").ToString
                    charge_to_id = sqldr.Item("charge_to").ToString

                    Select Case process
                        Case "EQUIPMENT"
                            a(6) = GET_equip_desc_AND_proj_desc(charge_to_id, 1)
                        Case "PROJECT"
                            a(6) = GET_equip_desc_AND_proj_desc(charge_to_id, 2)
                        Case "WAREHOUSE"
                            a(6) = GET_equip_desc_AND_proj_desc(charge_to_id, 4)
                        Case "PERSONAL"
                            a(6) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                        Case "CASH"
                            a(6) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                        Case "ADFIL"
                            'a(6) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                            a(6) = FReceivingReport.multiplecharges(CInt(sqldr.Item("rs_id").ToString), 1)
                    End Select

                    'If sqldr.Item("process").ToString = "EQUIPMENT" And sqldr.Item("IN_OUT") = "OUT".ToString Then
                    '    a(6) = get_chargeTo(sqldr.Item("charge_to").ToString, 0)
                    'ElseIf sqldr.Item("process").ToString = "PROJECT" And sqldr.Item("IN_OUT") = "OUT".ToString Then
                    '    a(6) = get_chargeTo(sqldr.Item("charge_to").ToString, 1)
                    'ElseIf sqldr.Item("process").ToString = "WAREHOUSE" And sqldr.Item("IN_OUT") = "OUT".ToString Then
                    '    a(6) = get_wh_AREA(sqldr.Item("charge_to").ToString)
                    'ElseIf sqldr.Item("process").ToString = "ADFIL" Or sqldr.Item("process").ToString = "PERSONAL" Then
                    '    a(6) = get_chargetoAdminPersonal(sqldr.Item("charge_to").ToString)
                    'End If

                    dgWithdrawItems.Rows.Add(a)

                    'If check_if_rs_cancel(sqldr.Item("rs_id").ToString) > 0 Then
                    '    With dgWithdrawItems.Rows(row)
                    '        For i = 0 To 3
                    '            .Cells(i).Style.BackColor = Color.Red
                    '            .Cells(i).Style.ForeColor = Color.White
                    '        Next
                    '    End With
                    'End If

                    'row += 1

                    'ElseIf sqldr.Item("IN_OUT").ToString = "OUT" And sqldr.Item("type_of_purchasing").ToString = "WITHDRAWAL" Then

                    '    txtRSNo.Text = sqldr.Item("rs_no").ToString
                    '    txtChargeto.Text = "test"
                    '    txtLocation.Text = sqldr.Item("location").ToString
                    '    'lblchargeTo_id.Text = sqldr.Item("charge_to").ToString
                    '    txtWithdrawFrom.Text = get_warehouse_area(sqldr.Item("wh_id").ToString)

                    '    a(0) = sqldr.Item("wh_id").ToString
                    '    a(1) = sqldr.Item("qty").ToString()
                    '    a(2) = sqldr.Item("unit").ToString
                    '    a(3) = sqldr.Item("item_desc").ToString()
                    '    a(4) = sqldr.Item("rs_id").ToString

                    '    dgWithdrawItems.Rows.Add(a)

                End If
            End While
            sqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub

    Public Function get_Item_name(ByVal wh_id As Integer, ByVal n As Integer)
        Dim newsqlcon As New SQLcon
        Dim newsqldr As SqlDataReader
        Try
            newsqlcon.connection.Open()

            If n = 1 Then
                publicquery = "SELECT * FROM warehouse_items_new WHERE id = " & wh_id
            ElseIf n = 2 Then
                publicquery = "SELECT * FROM dbwarehouse_items WHERE wh_id = " & wh_id
            End If

            cmd = New SqlCommand(publicquery, newsqlcon.connection)
            newsqldr = cmd.ExecuteReader
            While newsqldr.Read

                If n = 1 Then
                    get_Item_name = newsqldr.Item("WHitem").ToString
                ElseIf n = 2 Then
                    get_Item_name = newsqldr.Item("whItem").ToString
                End If

            End While
            newsqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
        End Try
    End Function

    'Public Sub view_cash_voucher()

    '    dgWithdrawItems.Rows.Clear()

    '    If receiving_inout = "OTHERS" Then
    '        view_item_from_rs()
    '        '--Gibson start--
    '        'ElseIf receiving_inout = "FACILITIES" Or receiving_inout = "TOOLS" Then

    '        '    load_borrower_cv()

    '    ElseIf receiving_inout = "IN" Then

    '        get_wh_id(FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text, 2)

    '    End If
    '    '--End--
    'End Sub

    Public Function get_item_name_warehouse(ByVal wh_id As Integer)
        Dim newsqlcon As New SQLcon
        Dim newcmd As SqlCommand
        Dim newsqldr As SqlDataReader

        Try
            newsqlcon.connection.Open()
            publicquery = "SELECT * FROM dbwarehouse_items WHERE wh_id = '" & wh_id & "'"
            newcmd = New SqlCommand(publicquery, newsqlcon.connection)
            newsqldr = newcmd.ExecuteReader

            While newsqldr.Read
                get_item_name_warehouse = newsqldr.Item("whItem").ToString
            End While

            newsqldr.Close()

            newsqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
        End Try
    End Function
  
    Public Function countRS(ByVal id As Integer)
        Dim newsq As New SQLcon
        Dim newdr As SqlDataReader
        Dim rsno As Integer = 0
        Try
            newsq.connection.Open()
            publicquery = "SELECT COUNT(rs_no) AS RsNo, charge_to FROM dbrequisition_slip WHERE rs_no = '" & id & "' " 'GROUP BY charge_to"
            cmd = New SqlCommand(publicquery, newsq.connection)
            newdr = cmd.ExecuteReader
            While newdr.Read
                rsno = newdr.Item("RsNo").ToString
            End While
            If rsno = 1 Then
                view_item_from_rs(0)
            Else
                view_item_from_rs(1)
            End If
            newdr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsq.connection.Close()
        End Try
    End Function


    Public Function check_if_rs_cancel(ByVal rs_id As Integer) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()

            Dim query As String = "SELECT * FROM dbrequisition_slip WHERE rs_id = " & rs_id
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                If newDR.Item("trans").ToString = "cancel" Then
                    check_if_rs_cancel += 1
                End If
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Public Function get_warehouse_area(ByVal area As String)
        Dim newsqlcon As New SQLcon
        Dim newcmd As SqlCommand
        Dim newsqldr As SqlDataReader
        Try
            newsqlcon.connection.Open()

            publicquery = "SELECT whArea FROM dbwarehouse_items WHERE whItem = '" & FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(4).Text & "'"
            newcmd = New SqlCommand(publicquery, newsqlcon.connection)
            newsqldr = newcmd.ExecuteReader()

            While newsqldr.Read
                get_warehouse_area = newsqldr.Item("whArea").ToString
            End While
            newsqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
        End Try
    End Function

    Public Function TypeOfRequest(ByVal id As Integer)
        Dim sqlcon As New SQLcon
        Dim cmd As SqlCommand
        Dim newdr As SqlDataReader
        Try
            sqlcon.connection.Open()
            cmd = New SqlCommand("proc_withdrawal_crud", sqlcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@withdraw_info_id", id)
            cmd.Parameters.AddWithValue("@crud", "type_of_request")
            newdr = cmd.ExecuteReader
            While newdr.Read
                If newdr.Item("process").ToString = "EQUIPMENT" And newdr.Item("IN_OUT") = "OUT".ToString Then
                    txtProcess.Text = newdr.Item("process").ToString
                    get_chargeTo(newdr.Item("charge_to").ToString, 0)
                ElseIf newdr.Item("process").ToString = "PROJECT" And newdr.Item("IN_OUT") = "OUT".ToString Then
                    txtProcess.Text = newdr.Item("process").ToString
                    get_chargeTo(newdr.Item("charge_to").ToString, 1)
                ElseIf newdr.Item("process").ToString = "WAREHOUSE" And newdr.Item("IN_OUT") = "OUT".ToString Then
                    txtProcess.Text = newdr.Item("process").ToString
                    get_wh_AREA(newdr.Item("charge_to").ToString)
                ElseIf newdr.Item("process").ToString = "ADFIL" Or newdr.Item("process").ToString = "PERSONAL" Then
                    txtProcess.Text = newdr.Item("process").ToString
                    get_chargetoAdminPersonal(newdr.Item("charge_to").ToString)
                End If
            End While
            newdr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try
    End Function

    Public Function get_chargetoAdminPersonal(ByVal chargeto_id As Integer)
        txtChargeto.Visible = True
        PictureBox2.Visible = True
        cmb_chargeto.Visible = False
        Dim sqlcon As New SQLcon
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Try
            sqlcon.connection.Open()
            publicquery = "SELECT charge_to FROM dbCharge_to WHERE charge_to_id = '" & chargeto_id & "'"
            cmd = New SqlCommand(publicquery, sqlcon.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                txtChargeto.Text = dr.Item("charge_to").ToString
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try
    End Function

    Public Function get_wh_AREA(ByVal wh_areID As Integer)
        txtChargeto.Visible = True
        PictureBox2.Visible = True
        cmb_chargeto.Visible = False
        Dim sqlcon As New SQLcon
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Try
            sqlcon.connection.Open()
            publicquery = "SELECT wh_area FROM dbwh_area WHERE wh_area_id = '" & wh_areID & "'"
            cmd = New SqlCommand(publicquery, sqlcon.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                txtChargeto.Text = dr.Item("wh_area").ToString
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try
    End Function

    Public Function get_chargeTo(ByVal chargeto As String, ByVal n As Integer)
        cmb_chargeto.Visible = True
        txtChargeto.Visible = False
        PictureBox2.Visible = False
        Dim newsqlcon As New SQLcon
        Dim newcmd As SqlCommand
        Dim newsqldr As SqlDataReader
        Try
            'newsqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
            'newsqlcon.sql_connect()
            newsqlcon.connection1.Open()
            If n = 0 Then
                publicquery = "SELECT * FROM dbequipment_list WHERE equipListID =  '" & chargeto & "'"
            ElseIf n = 1 Then
                publicquery = "SELECT * FROM dbprojectdesc WHERE proj_id =  '" & chargeto & "'"
            End If
            newcmd = New SqlCommand(publicquery, newsqlcon.connection1)
            newsqldr = newcmd.ExecuteReader()
            While newsqldr.Read
                If n = 0 Then
                    cmb_chargeto.Text = newsqldr.Item("plate_no").ToString
                    getchargeTo(0)
                ElseIf n = 1 Then
                    cmb_chargeto.Text = newsqldr.Item("project_desc").ToString
                    getchargeTo(1)
                End If
            End While
            newsqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection1.Close()
        End Try
    End Function

    Public Sub get_eqpListID(ByVal nn As Integer)
        Try
            Dim newsqlcon As New SQLcon
            Dim newcmd As SqlCommand
            Dim newsqldr As SqlDataReader
            Try
                'newsqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
                'newsqlcon.sql_connect()
                newsqlcon.connection1.Open()
                If nn = 0 Then
                    publicquery = "SELECT * FROM dbequipment_list WHERE plate_no = '" & cmb_chargeto.Text & "'"
                ElseIf nn = 1 Then
                    publicquery = "SELECT * FROM dbprojectdesc WHERE project_desc = '" & cmb_chargeto.Text & "'"
                End If
                newcmd = New SqlCommand(publicquery, newsqlcon.connection1)
                newsqldr = newcmd.ExecuteReader()
                While newsqldr.Read
                    If nn = 0 Then
                        lblchargeTo_id.Text = newsqldr.Item("equipListID").ToString
                    ElseIf nn = 1 Then
                        lblchargeTo_id.Text = newsqldr.Item("proj_id").ToString
                    End If
                End While
                newsqldr.Close()
            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newsqlcon.connection1.Close()
            End Try
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
        End Try
    End Sub

#Region "DragForm"
    Private Sub FWithdrawalSlip_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub FWithdrawalSlip_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub FWithdrawalSlip_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        drag = False
    End Sub
#End Region

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtWSNo.Text = "" Then
            MessageBox.Show("Pls. Fill up W.S NO.", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtWSNo.Focus()
        ElseIf txtLocation.Text = "" Then
            MessageBox.Show("Pls. Fill up Location", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtLocation.Focus()
        ElseIf txtRSNo.Text = "" Then
            MessageBox.Show("Pls. Fill up R.S NO.", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtRSNo.Focus()
        ElseIf DTPDateWithdraw.Text = "" Then
            MessageBox.Show("Pls. Fill up Date Needed", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DTPDateWithdraw.Focus()
        ElseIf txtWithdrawFrom.Text = "" Then
            MessageBox.Show("Pls. Fill up Withdraw From", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtWithdrawFrom.Focus()
        ElseIf txtWithdrawby.Text = "" Then
            MessageBox.Show("Pls. Fill up Withdraw by", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtWithdrawby.Focus()
        ElseIf txtReleasedby.Text = "" Then
            MessageBox.Show("Pls. Fill up Released by", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtReleasedby.Focus()
        Else


            If btnSave.Text = "Save" Then
                Dim counter As Integer
                Dim rs_id As Integer

                If MessageBox.Show("Are you sure you want to save this data?", "Supply Info:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    For Each row As DataGridViewRow In dgWithdrawItems.Rows
                        If row.Cells(1).Value = True Then
                            counter += 1
                        End If
                    Next

                    If counter = 0 Then
                        MessageBox.Show("Please, select atleast 1 in the list.", "Supply Info:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub

                    End If

                    Dim ws_info_id As Integer = save_update_withdraw_info("save")
                    Dim a(10) As String

                    For Each row As DataGridViewRow In dgWithdrawItems.Rows
                        If row.Cells(1).Value = True Then
                            a(1) = lbl_withdrawInfoID.Text
                            a(2) = txtWSNo.Text
                            a(3) = row.Cells(0).Value
                            a(4) = row.Cells(2).Value
                            a(5) = row.Cells(3).Value
                            a(6) = row.Cells(4).Value
                            a(7) = row.Cells(5).Value
                            a(9) = row.Cells(7).Value
                            a(10) = txtRSNo.Text

                            save_withdraw_item(ws_info_id, txtWSNo.Text, 0, row.Cells(2).Value, row.Cells(3).Value, "", "", row.Cells(7).Value, txtRSNo.Text)
                            rs_id = CInt(row.Cells(7).Value)

                        End If
                    Next

                    Me.Dispose()
                    FRequistionForm.btnSearch.PerformClick()
                    listfocus(FRequistionForm.lvlrequisitionlist, rs_id)

                End If

            ElseIf btnSave.Text = "Update" Then

                If MessageBox.Show("Are you sure you want to update this data?", "Supply Info:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    save_update_withdraw_info("update")
                    update_WithdrawnITEMS()

                    Me.Dispose()
                    FWithdrawalList.btnSearch.PerformClick()


                End If

            ElseIf btnSave.Text = "Withdraw" Then
                If MessageBox.Show("Are you sure you want to withraw the selected data?", "Supply Info:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim rs_id As Integer
                    For Each row As DataGridViewRow In dgWithdrawItems.Rows
                        If row.Cells(1).Value = True Then
                            rs_id = CInt(row.Cells(7).Value)
                            withdrawn_item(rs_id)
                        End If
                    Next

                    Me.Dispose()
                    FWithdrawalList.btnSearch.PerformClick()
                    listfocus(FWithdrawalList.lvlwithdrawalList, rs_id)

                End If

            End If




            'If btnSave.Text = "Save" Then

            '    save_withdraw_info()

            '    publicquery = "SELECT ws_info_id FROM dbwithdrawal_info WHERE rs_no = " & txtRSNo.Text
            '    Dim ws_info_id As Integer = get_specific_column_value(publicquery, 1)

            '    lbl_withdrawInfoID.Text = ws_info_id

            '    Dim a(15) As String
            '    For i = 0 To dgWithdrawItems.Rows.Count - 1

            '        a(1) = lbl_withdrawInfoID.Text
            '        a(2) = txtWSNo.Text
            '        a(3) = dgWithdrawItems.Rows(i).Cells(0).Value
            '        a(4) = dgWithdrawItems.Rows(i).Cells(2).Value
            '        a(5) = dgWithdrawItems.Rows(i).Cells(3).Value
            '        a(6) = dgWithdrawItems.Rows(i).Cells(4).Value
            '        a(7) = dgWithdrawItems.Rows(i).Cells(5).Value
            '        '  a(8) = dgWithdrawItems.Rows(i).Cells(6).Value
            '        a(9) = dgWithdrawItems.Rows(i).Cells(7).Value
            '        a(10) = txtRSNo.Text


            '        If dgWithdrawItems.Rows(i).Cells(0).Style.BackColor = Color.Red Then
            '        Else
            '            If dgWithdrawItems.Rows(i).Cells(1).Value = True Then
            '                save_withdraw_item(a(1), a(2), a(3), a(4), a(5), a(6), a(7), a(9), a(10))
            '            End If
            '        End If

            '    Next

            '    MessageBox.Show("Successfully Saved...", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

            '    lbl_reqID.Text = ""
            '    FRequistionForm.lvlrequisitionlist.Items.Clear()
            '    FRequistionForm.load_rs_3()
            '    listfocus(FRequistionForm.lvlrequisitionlist, txtRSNo.Text)
            '    Me.Close()

            'ElseIf btnSave.Text = "Update" Then
            '    update_WithdrawnINFO()
            '    update_WithdrawnITEMS()
            '    FWithdrawalList.view_withdrawnList()
            '    listfocus(FWithdrawalList.lvlwithdrawalList, txtRSNo.Text)
            '    Me.Close()

            'ElseIf btnSave.Text = "Withdraw" Then
            '    '    Dim count As Integer = 0
            '    '    For Each row As DataGridViewRow In dgWithdrawItems.Rows
            '    '        If row.Cells(1).Value = True Then
            '    '            count += 1
            '    '        End If
            '    '    Next
            '    '    If count = 0 Then
            '    '        MessageBox.Show("Pls select atleast 1 of the checkboxes")
            '    '        Return
            '    '    ElseIf count = 1 Then
            '    '        ' Withdrawn(0)
            '    '    Else
            '    Withdrawn(1)
            '    listfocus(FWithdrawalList.lvlwithdrawalList, txtRSNo.Text)
            '    '    End If
            '    Me.Close()

            'End If
        End If

        ' Me.Dispose()

    End Sub
    Public Sub withdrawn_item(ByVal rs_id As Integer)
        Try
            Dim if_rs_id_exist As Integer = check_if_exist("dbwithdrawn_items", "rs_id", rs_id, 1)

            If if_rs_id_exist = 0 Then

                Dim query As String = "INSERT INTO dbwithdrawn_items(rs_id) VALUES(" & rs_id & ")"
                UPDATE_INSERT_DELETE_QUERY(query, 0, "INSERT")

            End If

        Catch ex As Exception

        End Try
    End Sub
    Public Sub Withdrawn(ByVal nn As Integer)
        Dim newsq As New SQLcon
        Dim status As String = "WITHDRAWN"

        Dim result = MessageBox.Show("Are you sure you want to withdraw?", "MSUPPLY INFO.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

        If result = Windows.Forms.DialogResult.Yes Then
            If result = DialogResult.Yes Then
                Try
                    newsq.connection.Open()
                    If nn = 0 Then
                        publicquery = "UPDATE dbwithdrawal_info a SET a.withdraw_status = '" & status & "' INNER JOIN dbwithdrawal_items b ON a.ws_info_id = b.ws_info_id WHERE b.rs_id = '" & txtReqID.Text & "'"
                    ElseIf nn = 1 Then
                        publicquery = "UPDATE dbwithdrawal_info SET withdraw_status = '" & status & "' WHERE ws_info_id = '" & lbl_ws_info_id.Text & "'"
                    End If

                    Dim newcmd As SqlCommand = New SqlCommand(publicquery, newsq.connection)
                    newcmd.ExecuteNonQuery()

                    FWithdrawalList.view_withdrawnList()

                Catch ex As Exception
                    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    newsq.connection.Close()
                    MessageBox.Show("Successfully WITHDRAWN !", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try

            End If

        End If

    End Sub

    Public Function save_update_withdraw_info(ByVal crud As String) As Integer


        Dim status_withdraw As String = "WITHDRAWAL RELEASED"
        Try
            SQLcon.connection.Open()

            cmd = New SqlCommand("proc_withdrawal_new", SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            'cmd.Parameters.AddWithValue("@rs_id")
            cmd.Parameters.AddWithValue("@ws_no", txtWSNo.Text)
            cmd.Parameters.AddWithValue("@rs_no", txtRSNo.Text)
            cmd.Parameters.AddWithValue("@date_withdraw", Date.Parse(DTPDateWithdraw.Text))
            cmd.Parameters.AddWithValue("@withdraw_from", txtWithdrawFrom.Text)
            cmd.Parameters.AddWithValue("@withdraw_by", txtWithdrawby.Text)
            cmd.Parameters.AddWithValue("@released_by", txtReleasedby.Text)
            cmd.Parameters.AddWithValue("@withdraw_status", status_withdraw)
            cmd.Parameters.AddWithValue("@location", txtLocation.Text)
            cmd.Parameters.AddWithValue("@n", 2)
            cmd.Parameters.AddWithValue("@crud", crud)

            If crud = "save" Then
                save_update_withdraw_info = cmd.ExecuteScalar()
            ElseIf crud = "update" Then
                cmd.Parameters.AddWithValue("@ws_info_id", CInt(lbl_ws_info_id.Text))
                save_update_withdraw_info = cmd.ExecuteNonQuery()
            End If


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Function

    Public Sub save_withdraw_item(ByVal ws_infoID As Integer, ByVal wsNo As Integer, ByVal whID As Integer, _
                                  ByVal qty As Double, ByVal unit As String, ByVal item_name As String, ByVal itemDesc As String, ByVal rs_id As Integer, ByVal rs_no As String)
        Try
            SQLcon.connection.Open()
            'For i = 0 To dgWithdrawItems.RowCount - 1
            cmd = New SqlCommand("proc_withdrawal_crud", SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@withdraw_info_id", ws_infoID)
            cmd.Parameters.AddWithValue("@wsNo", wsNo)
            cmd.Parameters.AddWithValue("@wh_id", whID)
            cmd.Parameters.AddWithValue("@Qty", qty)
            cmd.Parameters.AddWithValue("@unit", unit)
            cmd.Parameters.AddWithValue("@item_name", item_name)
            cmd.Parameters.AddWithValue("@item_desc", itemDesc)
            cmd.Parameters.AddWithValue("@rs_id", rs_id)
            cmd.Parameters.AddWithValue("@rsNo", rs_no)
            cmd.Parameters.AddWithValue("@crud", "INSERT_TO_ITEMS")
            cmd.ExecuteNonQuery()
            ' Next

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub

    Public Sub update_WithdrawnINFO()
        SQLcon.connection.Close()
        '  With FWithdrawalList
        Try
            SQLcon.connection.Open()
            Dim dr As String
            cmd = New SqlCommand("proc_withdrawal_crud", SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@crud", "update_withdrawal_info")
            cmd.Parameters.AddWithValue("@id", lbl_withdrawInfoID.Text)
            cmd.Parameters.AddWithValue("@wsNo", txtWSNo.Text)
            cmd.Parameters.AddWithValue("@chargeTo_id", lblchargeTo_id.Text)
            cmd.Parameters.AddWithValue("@location", txtLocation.Text)
            cmd.Parameters.AddWithValue("@rsNo", txtRSNo.Text)
            cmd.Parameters.AddWithValue("@date_withdraw", DTPDateWithdraw.Text)
            cmd.Parameters.AddWithValue("@withdrawFrom", txtWithdrawFrom.Text)
            cmd.Parameters.AddWithValue("@withdrawBy", txtWithdrawby.Text)
            cmd.Parameters.AddWithValue("@releasedBy", txtReleasedby.Text)

            dr = cmd.ExecuteNonQuery()

            '   .lvlwithdrawalList.Items.Add(dr)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
        '  End With
    End Sub

    Public Sub update_WithdrawnITEMS()
        ' With FWithdrawalList
        Try
            SQLcon.connection.Open()
            Dim dr As String
            For i = 0 To dgWithdrawItems.Rows.Count - 1

                cmd = New SqlCommand("proc_withdrawal_crud", SQLcon.connection)
                cmd.Parameters.Clear()
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@ws_item_id", dgWithdrawItems.Rows(i).Cells(8).Value)
                cmd.Parameters.AddWithValue("@wh_id", dgWithdrawItems.Rows(i).Cells(0).Value)
                cmd.Parameters.AddWithValue("@Qty", dgWithdrawItems.Rows(i).Cells(2).Value)
                cmd.Parameters.AddWithValue("@unit", dgWithdrawItems.Rows(i).Cells(3).Value)
                cmd.Parameters.AddWithValue("@item_name", dgWithdrawItems.Rows(i).Cells(4).Value)
                cmd.Parameters.AddWithValue("@item_desc", dgWithdrawItems.Rows(i).Cells(5).Value)

                cmd.Parameters.AddWithValue("@crud", "update_withdrawal_items")
                dr = cmd.ExecuteNonQuery

            Next
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
            MessageBox.Show("Successfully UPDATED !", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        '  End With
    End Sub

    Public Sub update_condtion_withdrawal()
        Try
            SQLcon.connection.Open()
            Dim dr As SqlDataReader
            Dim cmd As New SqlCommand("proc_withdrawal_crud", SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@rsNo", txtRSNo.Text)
            cmd.Parameters.AddWithValue("@crud", "update_condition_withdrawal")
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                Dim ex As MsgBoxResult = MessageBox.Show("Are you sure you want to update the existing RECORD ?", "EUS INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If ex = MsgBoxResult.Yes Then
                    If btnSave.Text = "Save" Then
                        With FRequistionForm
                            If .lvlrequisitionlist.Items.Count > 0 Then
                                ' save_withdraw_info()
                                ' save_withdraw_item()
                            End If
                        End With
                    ElseIf btnSave.Text = "Update" Then
                        update_WithdrawnINFO()
                        '  update_WithdrawnITEMS()
                        With FWithdrawalList
                            .view_withdrawnList()
                        End With
                    End If
                Else
                End If
            Else
                MessageBox.Show("ERROR !", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub

    Public Sub view_chargeTo(ByVal b As Integer)
        lvList.Items.Clear()
        Try
            SQLcon.connection.Open()
            Dim cmd As SqlCommand
            Dim dr As SqlDataReader
            If b = 0 Then
                publicquery = "SELECT * FROM dbCharge_to ORDER BY charge_to ASC"
            ElseIf b = 1 Then
                publicquery = "SELECT * FROM dbwh_area ORDER BY wh_area ASC "
            End If
            cmd = New SqlCommand(publicquery, SQLcon.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim a(5) As String
                If b = 0 Then
                    a(0) = dr.Item("charge_to_id").ToString
                    a(1) = dr.Item("charge_to").ToString
                ElseIf b = 1 Then
                    a(0) = dr.Item("wh_area_id").ToString
                    a(1) = dr.Item("wh_area").ToString
                End If
                Dim lvl As New ListViewItem(a)
                lvList.Items.Add(lvl)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub

    Public Sub getchargeTo(ByVal n As Integer)
        Dim newsqlcon As New SQLcon
        Dim newcmd As SqlCommand
        Dim newsqldr As SqlDataReader
        cmb_chargeto.Items.Clear()
        Try
            'newsqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
            'newsqlcon.sql_connect()
            newsqlcon.connection1.Open()
            If n = 0 Then
                publicquery = "SELECT * FROM dbequipment_list ORDER BY plate_no ASC"
            ElseIf n = 1 Then
                publicquery = "SELECT * FROM dbprojectdesc ORDER BY project_desc ASC"
            End If
            newcmd = New SqlCommand(publicquery, newsqlcon.connection1)
            newsqldr = newcmd.ExecuteReader()
            While newsqldr.Read
                If n = 0 Then
                    cmb_chargeto.Items.Add(newsqldr.Item("plate_no").ToString)
                ElseIf n = 1 Then
                    cmb_chargeto.Items.Add(newsqldr.Item("project_desc").ToString)
                End If
            End While
            newsqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection1.Close()
        End Try
    End Sub

    Public Sub view_chargeTo_SEARCH()
        lvList.Items.Clear()
        Try
            SQLcon.connection.Open()

            Dim cmd As SqlCommand
            Dim dr As SqlDataReader
            Dim query As String = "SELECT * FROM dbCharge_to WHERE charge_to LIKE '%" & txt_Search.Text & "%'"
            cmd = New SqlCommand(query, SQLcon.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim a(5) As String

                a(0) = dr.Item(0).ToString
                a(1) = dr.Item(1).ToString

                Dim lvl As New ListViewItem(a)
                lvList.Items.Add(lvl)
            End While

            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub

    Private Sub dgWithdrawItems_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgWithdrawItems.CellEndEdit
        Try
            SQLcon.connection.Open()
            Dim dr As String
            For i = 0 To dgWithdrawItems.Rows.Count - 1

                cmd = New SqlCommand("proc_withdrawal_crud", SQLcon.connection)
                cmd.Parameters.Clear()
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@wh_id", dgWithdrawItems.Rows(i).Cells(0).Value)
                cmd.Parameters.AddWithValue("@Qty", dgWithdrawItems.Rows(i).Cells(1).Value)
                cmd.Parameters.AddWithValue("@unit", dgWithdrawItems.Rows(i).Cells(2).Value)
                cmd.Parameters.AddWithValue("@item_desc", dgWithdrawItems.Rows(i).Cells(3).Value)
                cmd.Parameters.AddWithValue("@crud", "update_withdrawal_items")
                dr = cmd.ExecuteNonQuery

                ' .lvlwithdrawalList.Items.Add(dr)

            Next
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub

    Private Sub withdrawfrom_list()
        lbox_withdrawby.Items.Clear()
        Try
            SQLcon.connection.Open()
            Dim cmd As SqlCommand
            Dim dr As SqlDataReader
            Dim query As String = "SELECT DISTINCT wh_area FROM dbwh_area WHERE wh_area LIKE '%" & txtWithdrawFrom.Text & "%' "
            cmd = New SqlCommand(query, SQLcon.connection)
            dr = cmd.ExecuteReader
            If dr.HasRows = False Then
                lbox_withdrawby.Visible = False
            Else
                While dr.Read
                    Dim withdrawfrom As String = dr.Item("wh_area").ToString
                    lbox_withdrawby.Items.Add(withdrawfrom)
                End While
                dr.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub

    Private Sub withdrawby_list(ByVal n As Integer)
        Dim counter As Integer = 0
        lbox_withdrawby.Items.Clear()
        Try
            SQLcon.connection.Open()
            Dim dr As SqlDataReader
            Dim cmd As New SqlCommand("proc_withdrawal_crud", SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            If n = 0 Then
                cmd.Parameters.AddWithValue("@withdrawBy", txtWithdrawby.Text)
                cmd.Parameters.AddWithValue("@crud", "get_withdraw_by")
            ElseIf n = 1 Then
                cmd.Parameters.AddWithValue("@releasedBy", txtReleasedby.Text)
                cmd.Parameters.AddWithValue("@crud", "get_released_by")
            End If
            dr = cmd.ExecuteReader
            If dr.HasRows = False Then
                lbox_withdrawby.Visible = False
            Else
                While dr.Read
                    If n = 0 Then
                        Dim withdrawby As String = dr.Item("withdraw_by").ToString
                        lbox_withdrawby.Items.Add(withdrawby)
                        counter += 1
                    ElseIf n = 1 Then
                        Dim releaseby As String = dr.Item("released_by").ToString
                        lbox_withdrawby.Items.Add(releaseby)
                        counter += 1
                    End If

                    If counter > 0 Then
                        lbox_withdrawby.Visible = True
                    Else
                        lbox_withdrawby.Visible = False
                    End If

                End While
                dr.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub

    Private Sub releaseby_list()
        lbox_withdrawby.Items.Clear()
        Try
            SQLcon.connection.Open()
            Dim cmd As SqlCommand
            Dim dr As SqlDataReader
            Dim query As String = "SELECT released_by FROM dbwithdrawal_info WHERE released_by LIKE '%" & txtReleasedby.Text & "%'"
            cmd = New SqlCommand(query, SQLcon.connection)
            dr = cmd.ExecuteReader
            While dr.Read

                Dim releaseby As String = dr.Item("released_by").ToString
                lbox_withdrawby.Items.Add(releaseby)

            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Panel_chargeTo.Visible = True
        If txtProcess.Text = "PERSONAL" Or txtProcess.Text = "ADFIL" Then
            view_chargeTo(0)
        ElseIf txtProcess.Text = "WAREHOUSE" Then
            view_chargeTo(1)
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Panel_chargeTo.Visible = False
    End Sub

    Private Sub lvList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvList.DoubleClick
        txtChargeto.Text = lvList.SelectedItems(0).SubItems(1).Text
        lblchargeTo_id.Text = lvList.SelectedItems(0).SubItems(0).Text
        Panel_chargeTo.Visible = False
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Panel_chargeTo.Visible = False
    End Sub

    Private Sub txt_Search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Search.TextChanged
        view_chargeTo_SEARCH()
    End Sub

#Region "txtbxKeyscode"

    Private Sub txtWSNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWSNo.KeyDown
        If e.KeyCode = Keys.Back Then
            backspace = True
        Else
            backspace = False
        End If
    End Sub

    Private Sub txtWSNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtWSNo.KeyPress
        If backspace = False Then
            If Not IsNumeric(e.KeyChar) Then
                FWithdrawalSlip_ToolTip.Show("NUMBERS only !", sender, 2000)
                e.KeyChar = Nothing
            End If
        End If
    End Sub

    Private Sub txtRSNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRSNo.KeyDown
        If e.KeyCode = Keys.Back Then
            backspace = True
        Else
            backspace = False
        End If
    End Sub

    Private Sub txtRSNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRSNo.KeyPress
        If backspace = False Then
            If Not IsNumeric(e.KeyChar) Then
                FWithdrawalSlip_ToolTip.Show("NUMBERS only !", sender, 2000)
                e.KeyChar = Nothing
            End If
        End If
    End Sub
#End Region

#Region "GUI_BUTTON"
    Private Sub btnExit_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnExit.MouseDown
        btnExit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.MouseEnter
        btnExit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.MouseLeave
        btnExit.BackgroundImage = My.Resources.close_button
    End Sub

    Private Sub Button1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseDown
        Button1.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub Button1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseEnter
        Button1.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub Button1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave
        Button1.BackgroundImage = My.Resources.close_button
    End Sub
#End Region

    Private Sub txtWithdrawby_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWithdrawby.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
            If lbox_withdrawby.Visible = True Then
                If lbox_withdrawby.Items.Count > 0 Then
                    lbox_withdrawby.Focus()
                    lbox_withdrawby.SelectedIndex = 0
                End If
            Else
                'If lbox_withdrawby.Items.Count > 0 Then
                '    lbox_withdrawby.Focus()
                '    lbox_withdrawby.Items(0).Selected = True
                'End If
            End If
        End If
    End Sub
    Private Sub txtWithdrawby_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWithdrawby.TextChanged

        lbox_withdrawby.Location = New Point(txtWithdrawby.Width + 224, 145)
        lbox_withdrawby.Width = txtWithdrawby.Width

        If txtWithdrawby.Focus Then
            lbox_withdrawby.Visible = True
            withdrawby_list(0)
        End If
    End Sub

    Private Sub txtReleasedby_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReleasedby.TextChanged

        lbox_withdrawby.Location = New Point(txtReleasedby.Width + 224, 179)
        lbox_withdrawby.Width = txtReleasedby.Width

        If txtReleasedby.Focus = True Then
            lbox_withdrawby.Visible = True
            withdrawby_list(1)
        End If
    End Sub

    Private Sub ttxtReleasedby_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReleasedby.GotFocus

    End Sub

    Private Sub lbox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbox_withdrawby.DoubleClick
        If lbox_withdrawby.SelectedItems.Count > 0 Then
            For Each ctr As Control In Me.Controls
                If ctr.Name = name2 Then
                    ctr.Text = lbox_withdrawby.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next
            lbox_withdrawby.Visible = False
        Else
            MessageBox.Show("Pls select data", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub txtField_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWSNo.GotFocus, txtLocation.GotFocus, txtRSNo.GotFocus, _
   txtWithdrawFrom.GotFocus, txtWithdrawby.GotFocus, txtReleasedby.GotFocus

        sender.backcolor = Color.Yellow

        If txtWithdrawFrom.Focused Then
            name2 = txtWithdrawFrom.Name
            txtWithdrawFrom.SelectAll()
        ElseIf txtWithdrawby.Focused Then
            name2 = txtWithdrawby.Name
            txtWithdrawby.SelectAll()
        ElseIf txtReleasedby.Focused Then
            name2 = txtReleasedby.Name
            txtReleasedby.SelectAll()
        End If

    End Sub

    Private Sub txtWithdrawFrom_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWithdrawFrom.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
            If lbox_withdrawby.Visible = True Then
                If lbox_withdrawby.Items.Count > 0 Then
                    lbox_withdrawby.Focus()
                    lbox_withdrawby.SelectedIndex = 0
                End If
            Else
                'If lbox_withdrawby.Items.Count > 0 Then
                '    lbox_withdrawby.Focus()
                '    lbox_withdrawby.Items(0).Selected = True
                'End If
            End If
        End If
    End Sub

    Private Sub txtField_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWSNo.Leave, txtLocation.Leave, txtRSNo.Leave, _
   txtWithdrawFrom.Leave, txtWithdrawby.Leave, txtReleasedby.Leave

        sender.backcolor = Color.White

    End Sub

    Private Sub lbox_withdrawby_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lbox_withdrawby.KeyDown
        If e.KeyCode = Keys.Enter Then
            For Each ctr As Control In Me.Controls
                If ctr.Name = name2 Then
                    ctr.Text = lbox_withdrawby.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next
            lbox_withdrawby.Visible = False
        End If
    End Sub

    Private Sub txtReleasedby_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReleasedby.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
            If lbox_withdrawby.Visible = True Then
                If lbox_withdrawby.Items.Count > 0 Then
                    lbox_withdrawby.Focus()
                    lbox_withdrawby.SelectedIndex = 0
                End If
            Else
                'If lbox_withdrawby.Items.Count > 0 Then
                '    lbox_withdrawby.Focus()
                '    lbox_withdrawby.Items(0).Selected = True
                'End If
            End If
        End If
    End Sub

    Private Sub txtWithdrawFrom_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWithdrawFrom.TextChanged

        lbox_withdrawby.Location = New Point(txtWithdrawFrom.Width + 224, 112)
        lbox_withdrawby.Width = txtWithdrawFrom.Width

        If txtWithdrawFrom.Focus = True Then
            lbox_withdrawby.Visible = True
            withdrawfrom_list()
        End If
    End Sub

    Private Sub cmb_chargeto_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_chargeto.TextChanged
        If txtProcess.Text = "EQUIPMENT" Then
            get_eqpListID(0)
        ElseIf txtProcess.Text = "PROJECT" Then
            get_eqpListID(1)
        End If

    End Sub

    Private Sub dgWithdrawItems_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgWithdrawItems.CellContentClick
        'txtReqID.Text = dgWithdrawItems.SelectedRows(0).Cells(5).Value
    End Sub

End Class