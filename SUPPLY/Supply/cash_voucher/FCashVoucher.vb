Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FCashVoucher
    Dim SQLcon As New SQLcon
    Dim sqldr As SqlDataReader
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Dim IsFormBeingDragged As Boolean
    Dim rowind As Integer
    Dim n As Integer
    Dim price_value As Double
    Public pub_cv_id As Integer
    Public txtname As String
    Dim process As String
    Dim item As DataGridView
    Dim panloc As New Point(0, 0)
    Dim curloc As New Point(0, 0)
    Dim old_amount As Double

    Private Sub setpositions()
        panloc = panel_brand.Location
        curloc = System.Windows.Forms.Cursor.Position
    End Sub

    Private Sub FCashVoucher_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub FCashVoucher_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Timer_panel.Interval = "1"
        setpositions()
        panel_chargeTo.Visible = False
        lbox_cash_voucher.Visible = False
        PictureBox2.Enabled = True
        txtRSNo.Enabled = False
        txtChargeTo.Enabled = False
        panel_brand.Visible = False
        load_supplier()

        If check_if_exist("dbCashVoucher_info", "cv_info_id", Val(lbl_cv_info_id.Text), 0) > 0 Then
            'cmbSupplier.Width = txtChargeTo.Width
            'charge_to(txtRSNo.Text, 1)
            'PictureBox2.Visible = False
            'load_suppliers_list()
            cmb_chargeto.Enabled = False
            btnSave.Text = "Update"
            Load_cv_INFO(lbl_cv_info_id.Text)
            grandtotal()
            
        Else

            'cmbSupplier.Width = 184
            'txtChargeTo.Width = 216
            'charge_to(txtRSNo.Text, 2)
            btnSave.Text = "Save"
            view_cash_voucher()

        End If

    End Sub

#Region "drag fcashvoucher form/panel"
    Private Sub FCashVoucher_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            mousex = e.X
            mousey = e.Y
        End If
    End Sub

    Private Sub FCashVoucher_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If IsFormBeingDragged Then
            Dim temp As Point = New Point()

            temp.X = Me.Location.X + (e.X - mousex)
            temp.Y = Me.Location.Y + (e.Y - mousey)
            Me.Location = temp
            temp = Nothing
        End If
    End Sub

    Private Sub FCashVoucher_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
    End Sub

    Private Sub panel_chargeTo_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panel_chargeTo.MouseDown, Label13.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - panel_chargeTo.Left
        mousey = Windows.Forms.Cursor.Position.Y - panel_chargeTo.Top
    End Sub

    Private Sub panel_chargeTo_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panel_chargeTo.MouseMove, Label13.MouseMove
        If drag Then
            panel_chargeTo.Top = Windows.Forms.Cursor.Position.Y - mousey
            panel_chargeTo.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub panel_chargeTo_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panel_chargeTo.MouseUp, Label13.MouseUp
        drag = False
    End Sub

    Private Sub panel_brand_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panel_brand.MouseDown
        Timer_panel.Enabled = True
        Timer_panel.Start()
        setpositions()
    End Sub

    Private Sub panel_brand_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panel_brand.MouseUp
        Timer_panel.Stop()
        setpositions()
    End Sub

    Private Sub Timer_panel_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_panel.Tick
        panel_brand.Location = panloc - curloc + System.Windows.Forms.Cursor.Position
        setpositions()
    End Sub

#End Region

    Public Sub load_supplier()
        cmbSupplier.Items.Clear()
        Try
            SQLcon.connection.Open()
            publicquery = "SELECT * FROM dbSupplier"
            cmd = New SqlCommand(publicquery, SQLcon.connection)
            sqldr = cmd.ExecuteReader
            While sqldr.Read
                cmbSupplier.Items.Add(sqldr.Item("Supplier_Name").ToString)
            End While
            sqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub

    Public Sub charge_to(ByVal id As Integer, ByVal n As Integer)

        If n = 1 Then
            Try
                SQLcon.connection.Open()
                publicquery = "SELECT b.rs_no, a.cv_charge_to_id, c.process FROM dbCashVoucher_items a INNER JOIN dbCashVoucher_info b ON a.cv_info_id = b.cv_info_id " & _
                "INNER JOIN dbrequisition_slip c ON c.rs_id = a.rs_id WHERE b.rs_no = '" & id & "' "
                cmd = New SqlCommand(publicquery, SQLcon.connection)
                sqldr = cmd.ExecuteReader
                While sqldr.Read
                    If sqldr.Item("process").ToString = "PROJECT" Then
                        txtChargeTo.Text &= GET_equip_desc_AND_proj_desc(sqldr.Item("cv_charge_to_id").ToString, 2) & " / "
                    ElseIf sqldr.Item("process").ToString = "EQUIPMENT" Then
                        txtChargeTo.Text &= GET_equip_desc_AND_proj_desc(sqldr.Item("cv_charge_to_id").ToString, 1) & " / "
                    ElseIf sqldr.Item("process").ToString = "PERSONAL" Or sqldr.Item("process").ToString = "ADFIL" Then
                        txtChargeTo.Text &= GET_equip_desc_AND_proj_desc(sqldr.Item("cv_charge_to_id").ToString, 3) & " / "
                    ElseIf sqldr.Item("process").ToString = "WAREHOUSE" Then
                        txtChargeTo.Text &= GET_equip_desc_AND_proj_desc(sqldr.Item("cv_charge_to_id").ToString, 4) & " / "
                    End If
                End While
                sqldr.Close()
            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                SQLcon.connection.Close()
            End Try

        ElseIf n = 2 Then

            Try
                SQLcon.connection.Open()
                publicquery = "SELECT * FROM dbrequisition_slip WHERE rs_no = '" & id & "' "
                cmd = New SqlCommand(publicquery, SQLcon.connection)
                sqldr = cmd.ExecuteReader
                While sqldr.Read
                    If sqldr.Item("process").ToString = "PROJECT" Then
                        txtChargeTo.Text &= GET_equip_desc_AND_proj_desc(sqldr.Item("charge_to").ToString, 2) & " / "
                    ElseIf sqldr.Item("process").ToString = "EQUIPMENT" Then
                        txtChargeTo.Text &= GET_equip_desc_AND_proj_desc(sqldr.Item("charge_to").ToString, 1) & " / "
                    ElseIf sqldr.Item("process").ToString = "PERSONAL" Or sqldr.Item("process").ToString = "ADFIL" Then
                        txtChargeTo.Text &= GET_equip_desc_AND_proj_desc(sqldr.Item("charge_to").ToString, 3) & " / "
                    ElseIf sqldr.Item("process").ToString = "WAREHOUSE" Then
                        txtChargeTo.Text &= GET_equip_desc_AND_proj_desc(sqldr.Item("charge_to").ToString, 4) & " / "
                    End If '
                End While
                sqldr.Close()
            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                SQLcon.connection.Close()
            End Try

        End If

    End Sub

    Public Function get_supplier(ByVal supplier_id As Integer) As String
        Dim sql As New SQLcon
        Dim dr As SqlDataReader
        Try
            sql.connection.Open()
            publicquery = "SELECT Supplier_Name FROM dbSupplier WHERE Supplier_Id = '" & supplier_id & "'"
            cmd = New SqlCommand(publicquery, sql.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                get_supplier = dr.Item("Supplier_Name").ToString
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sql.connection.Close()
        End Try
    End Function

    Public Sub Load_cv_INFO(ByVal cv_infoID As Integer)

        txtRSNo.Text = FCashVoucherList.lvlvoucherlist.SelectedItems(0).SubItems(2).Text
        txtCVno.Text = FCashVoucherList.lvlvoucherlist.SelectedItems(0).SubItems(3).Text
        DTPVoucher.Text = FCashVoucherList.lvlvoucherlist.SelectedItems(0).SubItems(1).Text
        txtReceivedby.Text = FCashVoucherList.lvlvoucherlist.SelectedItems(0).SubItems(10).Text

        Try
            SQLcon.connection.Open()
            cmd = New SqlCommand("proc_cashvoucher_query", SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@n", 13)
            cmd.Parameters.AddWithValue("@cv_infoID", cv_infoID)
            sqldr = cmd.ExecuteReader
            While sqldr.Read
                cmbSupplier.Text = get_supplier(sqldr.Item("cv_supplier_id").ToString)
                Dim x(15) As String
                x(0) = sqldr.Item("cv_items_id").ToString
                x(2) = sqldr.Item("wh_id").ToString
                x(3) = get_item_name_warehouse(sqldr.Item("wh_id").ToString, 1)
                x(4) = get_item_name_warehouse(sqldr.Item("wh_id").ToString, 2)

                If sqldr.Item("process").ToString = "EQUIPMENT" Then
                    x(5) = GET_equip_desc_AND_proj_desc(sqldr.Item("cv_charge_to_id").ToString, 1)
                ElseIf sqldr.Item("process").ToString = "PROJECT" Then
                    x(5) = GET_equip_desc_AND_proj_desc(sqldr.Item("cv_charge_to_id").ToString, 2)
                ElseIf sqldr.Item("process").ToString = "ADFIL" Or sqldr.Item("process").ToString = "PERSONAL" Then
                    x(5) = GET_equip_desc_AND_proj_desc(sqldr.Item("cv_charge_to_id").ToString, 3)

                    Dim mcharges As String = get_multiple_charges(sqldr.Item("rs_id").ToString)

                    If mcharges.Length < 1 Then
                    Else
                        mcharges = mcharges.Trim().Substring(0, mcharges.Length - 1)
                        x(5) = x(5) & "(" & UCase(mcharges) & ")"

                    End If

                ElseIf sqldr.Item("process").ToString = "WAREHOUSE" Then
                    x(5) = GET_equip_desc_AND_proj_desc(sqldr.Item("cv_charge_to_id").ToString, 4)
                End If

                x(6) = sqldr.Item("cv_qty").ToString
                x(7) = sqldr.Item("cv_amount").ToString
                x(8) = sqldr.Item("cv_total").ToString
                x(9) = sqldr.Item("cv_charge_to_id").ToString

                dgCashVoucherItems.Rows.Add(x)

            End While
            sqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub

    Public Function get_item_desc()
        Dim newSq1 As New SQLcon
        Dim newdr1 As SqlDataReader
        Try
            newSq1.connection.Open()
            publicquery = "SELECT b.process FROM dbCashVoucher_items a INNER JOIN dbrequisition_slip b ON a.rs_id = b.rs_id"
            cmd = New SqlCommand(publicquery, newSq1.connection)
            newdr1 = cmd.ExecuteReader
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSq1.connection.Close()
        End Try
    End Function

    Public Sub get_chargeto_id(ByVal chargeto As String, ByVal i As Integer)
        Dim sqlcon1 As New SQLcon
        Dim newsqlcon1 As New SQLcon
        Try
            If i = 0 Or i = 1 Then
                sqlcon1.connection.Open()
            ElseIf i = 2 Or i = 3 Then
                'newsqlcon1.set_sql("192.168.1.91", "eus", "sa", "adfil")
                'newsqlcon1.sql_connect()
                newsqlcon1.connection1.Open()
            End If

            If i = 0 Then
                publicquery = "SELECT * FROM dbCharge_to WHERE dbCharge_to = '" & chargeto & "' "
            ElseIf i = 1 Then
                publicquery = "SELECT * FROM dbwh_area WHERE wh_area = '" & chargeto & "'"
            ElseIf i = 2 Then
                publicquery = "SELECT * FROM dbprojectdesc WHERE project_desc = '" & chargeto & "'"
            ElseIf i = 3 Then
                publicquery = "SELECT * FROM dbequipment_list WHERE plate_no = '" & chargeto & "'"
            End If

            If i = 0 Or i = 1 Then
                cmd = New SqlCommand(publicquery, sqlcon1.connection)
            ElseIf i = 2 Or i = 3 Then
                cmd = New SqlCommand(publicquery, newsqlcon1.connection1)
            End If

            sqldr = cmd.ExecuteReader
            While sqldr.Read
                If i = 0 Then
                    txtChargeToID.Text = sqldr.Item("charge_to_id").ToString
                ElseIf i = 1 Then
                    txtChargeToID.Text = sqldr.Item("wh_area_id").ToString
                ElseIf i = 2 Then
                    txt_proj_equp_id.Text = sqldr.Item("proj_id").ToString
                ElseIf i = 3 Then
                    txt_proj_equp_id.Text = sqldr.Item("equipListID").ToString
                End If
            End While
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If i = 0 Or i = 1 Then
                sqlcon1.connection.Close()
            ElseIf i = 2 Or i = 3 Then
                newsqlcon1.connection1.Close()
            End If
        End Try
    End Sub

    Public Sub gEt_chargeto(ByVal n As Integer)
        Dim sqlcon As New SQLcon
        Dim newsqlcon As New SQLcon
        lvl_chargeto.Items.Clear()
        cmb_chargeto.Items.Clear()
        Try
            If n = 0 Or n = 1 Then
                sqlcon.connection.Open()
            ElseIf n = 2 Or n = 3 Then
                'newsqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
                'newsqlcon.sql_connect()
                newsqlcon.connection.Open()
            End If

            If n = 0 Then
                publicquery = "SELECT * FROM dbCharge_to ORDER BY charge_to ASC"
            ElseIf n = 1 Then
                publicquery = "SELECT * FROM dbwh_area ORDER BY wh_area ASC"
            ElseIf n = 2 Then
                publicquery = "SELECT * FROM dbprojectdesc ORDER BY project_desc ASC"
            ElseIf n = 3 Then
                publicquery = "SELECT * FROM dbequipment_list ORDER BY plate_no ASC"
            End If

            If n = 0 Or n = 1 Then
                cmd = New SqlCommand(publicquery, sqlcon.connection)
            ElseIf n = 2 Or n = 3 Then
                cmd = New SqlCommand(publicquery, newsqlcon.connection1)
            End If

            sqldr = cmd.ExecuteReader
            While sqldr.Read
                Dim a(5) As String
                If n = 0 Then
                    a(0) = sqldr.Item("charge_to_id").ToString
                    a(1) = sqldr.Item("charge_to").ToString
                ElseIf n = 1 Then
                    a(0) = sqldr.Item("wh_area_id").ToString
                    a(1) = sqldr.Item("wh_area").ToString
                End If

                If n = 0 Or n = 1 Then
                    Dim newlvl As New ListViewItem(a)
                    lvl_chargeto.Items.Add(newlvl)
                ElseIf n = 2 Then
                    cmb_chargeto.Items.Add(sqldr.Item("project_desc").ToString)
                ElseIf n = 3 Then
                    cmb_chargeto.Items.Add(sqldr.Item("plate_no").ToString)
                End If

            End While
            sqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If n = 0 Or n = 1 Then
                sqlcon.connection.Close()
            ElseIf n = 2 Or n = 3 Then
                newsqlcon.connection1.Close()
            End If
        End Try
    End Sub

    Public Sub get_prOj_equip_id(ByVal desc As String, ByVal n As Integer)
        Dim SQ As New SQLcon
        Try
            'SQ.set_sql("192.168.1.91", "eus", "sa", "adfil")
            'SQ.sql_connect()

            SQ.connection1.Open()
            If n = 0 Then
                publicquery = "SELECT * FROM dbprojectdesc WHERE project_desc ='" & desc & "'"
            ElseIf n = 1 Then
                publicquery = "SELECT * FROM dbequipment_list WHERE plate_no ='" & desc & "'"
            End If

            cmd = New SqlCommand(publicquery, SQ.connection1)
            sqldr = cmd.ExecuteReader

            While sqldr.Read
                If n = 0 Then
                    txt_proj_equp_id.Text = sqldr.Item("proj_id").ToString
                ElseIf n = 1 Then
                    txt_proj_equp_id.Text = sqldr.Item("equipListID").ToString
                End If
            End While
            sqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection1.Close()
        End Try
    End Sub

    Public Function get_supplier_id(ByVal supplier_name As String) As Integer
        Dim newSq As New SQLcon
        Dim newDr As SqlDataReader
        Dim newcmd As SqlCommand
        Try
            newSq.connection.Open()
            publicquery = "SELECT * FROM dbSupplier WHERE Supplier_Name = '" & supplier_name & "'"
            newcmd = New SqlCommand(publicquery, newSq.connection)
            newDr = newcmd.ExecuteReader

            While newDr.Read
                get_supplier_id = newDr.Item("Supplier_Id").ToString
            End While
            newDr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSq.connection.Close()
        End Try
    End Function

    Public Sub view_cash_voucher()

        'If receiving_inout = "OTHERS" Then
        'view_items_from_rs()
        '    '--Gibson start--
        'ElseIf receiving_inout = "FACILITIES" Or receiving_inout = "TOOLS" Or receiving_inout = "ADD-ON" Then

        'load_borrower_cv()

        'ElseIf receiving_inout = "IN" Then

           Dim count As Integer = 0
       
        For i As Integer = 0 To FRequistionForm.lvlrequisitionlist.Items.Count - 1
            If FRequistionForm.lvlrequisitionlist.Items(i).SubItems(1).Text = txtRSNo.Text And FRequistionForm.lvlrequisitionlist.Items(i).SubItems(11).Text = rr_status Then

                count += 1

                If count > 1 Then
                    get_cv_data(txtRSNo.Text, 2)
                Else
                    get_cv_data(txtRSNo.Text, 1)
                End If

            End If

        Next

        'End If
        '--End--
    End Sub
    'Public Sub load_borrower_cv()
    '    Dim publicquery As String
    '    Dim typeofpurchasing As String = "CASH"
    '    Dim DR As SqlDataReader
    '    Dim SQ As New SQLcon

    '    Try
    '        SQ.connection.Open()

    '        publicquery = "SELECT b.fac_id,b.facility_name,a.qty,a.unit,a.typeRequest,a.rs_id,a.process,a.IN_OUT,a.rs_id,a.charge_to FROM dbrequisition_slip a " & _
    '     "INNER JOIN dbfacilities_names b ON a.wh_id = b.fac_id " & _
    '     "WHERE a.rs_no = '" & Val(txtRSNo.Text) & "' AND a.type_of_purchasing = '" & typeofpurchasing & "'"

    '        'get_wh_id(FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text, 1)
    '        cmd = New SqlCommand(publicquery, SQ.connection)
    '        DR = cmd.ExecuteReader

    '        While DR.Read

    '            Dim a(12) As String

    '            If receiving_inout = "FACILITIES" Or receiving_inout = "TOOLS" Or receiving_inout = "ADD-ON" Then

    '                a(0) = DR.Item("rs_id").ToString
    '                a(1) = DR.Item("fac_id").ToString
    '                a(2) = DR.Item("facility_name").ToString
    '                a(3) = ""
    '                a(5) = DR.Item("qty").ToString
    '                a(6) = 0
    '                a(7) = FormatNumber(CDbl(a(5)) * CDbl(a(6)), , , TriState.True)
    '                a(8) = DR.Item("charge_to").ToString

    '                If DR.Item("process").ToString = "EQUIPMENT" Then
    '                    a(4) = GET_equip_desc_AND_proj_desc(DR.Item("charge_to").ToString, 1)
    '                ElseIf DR.Item("process").ToString = "PROJECT" Then
    '                    a(4) = GET_equip_desc_AND_proj_desc(DR.Item("charge_to").ToString, 2)
    '                ElseIf DR.Item("process").ToString = "ADFIL" Or DR.Item("process").ToString = "PERSONAL" Then
    '                    a(4) = GET_equip_desc_AND_proj_desc(DR.Item("charge_to").ToString, 3)
    '                ElseIf DR.Item("process").ToString = "WAREHOUSE" Then
    '                    a(4) = GET_equip_desc_AND_proj_desc(DR.Item("charge_to").ToString, 4)
    '                End If

    '            End If

    '            dgCashVoucherItems.Rows.Add(a)

    '        End While
    '        DR.Close()
    '    Catch ex As Exception
    '        MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        SQ.connection.Close()

    '    End Try
    'End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Dispose()
    End Sub

    Public Sub get_cv_data(ByVal rs_no As Integer, ByVal n As Integer)
        Dim typeofpurchasing As String = "CASH"
        dgCashVoucherItems.Rows.Clear()
        Try
            SQLcon.connection.Open()

            If n = 1 Then
                publicquery = "SELECT * FROM dbrequisition_slip WHERE rs_id = '" & public_rs_id & "' AND type_of_purchasing = '" & typeofpurchasing & "'"
            ElseIf n = 2 Then
                publicquery = "SELECT * FROM dbrequisition_slip WHERE rs_no = '" & rs_no & "' AND type_of_purchasing = '" & typeofpurchasing & "'"
            End If

            cmd = New SqlCommand(publicquery, SQLcon.connection)
            sqldr = cmd.ExecuteReader
            While sqldr.Read
                Dim b(10) As String
                If n = 1 Then
                    b(0) = sqldr.Item("rs_id").ToString
                    b(2) = sqldr.Item("wh_id").ToString
                    b(3) = get_item_name_warehouse(sqldr.Item("wh_id").ToString, 1)
                    b(4) = sqldr.Item("item_desc").ToString
                    b(6) = sqldr.Item("qty").ToString
                    'b(6) = 0
                    b(8) = FormatNumber(CDbl(b(5)) * CDbl(b(6)), , , TriState.True)
                    'b(8) = sqldr.Item("charge_to").ToString
                    b(9) = sqldr.Item("charge_to").ToString

                ElseIf n = 2 Then
                    b(0) = sqldr.Item("rs_id").ToString
                    b(2) = sqldr.Item("wh_id").ToString
                    b(3) = get_item_name_warehouse(sqldr.Item("wh_id").ToString, 1)
                    b(4) = sqldr.Item("item_desc").ToString
                    b(6) = sqldr.Item("qty").ToString
                    'b(6) = 0
                    b(8) = FormatNumber(CDbl(b(5)) * CDbl(b(6)), , , TriState.True)
                    'b(8) = sqldr.Item("charge_to").ToString
                    b(9) = sqldr.Item("charge_to").ToString

                End If

                If sqldr.Item("process").ToString = "EQUIPMENT" Then
                    b(5) = GET_equip_desc_AND_proj_desc(sqldr.Item("charge_to").ToString, 1)
                ElseIf sqldr.Item("process").ToString = "PROJECT" Then
                    b(5) = GET_equip_desc_AND_proj_desc(sqldr.Item("charge_to").ToString, 2)
                ElseIf sqldr.Item("process").ToString = "ADFIL" Or sqldr.Item("process").ToString = "PERSONAL" Then
                    b(5) = GET_equip_desc_AND_proj_desc(sqldr.Item("charge_to").ToString, 3)

                    Dim mcharges As String = get_multiple_charges(sqldr.Item("rs_id").ToString)

                    If mcharges.Length < 1 Then
                    Else
                        mcharges = mcharges.Trim().Substring(0, mcharges.Length - 1)
                        b(5) = b(5) & "(" & UCase(mcharges) & ")"

                    End If

                ElseIf sqldr.Item("process").ToString = "WAREHOUSE" Then
                    b(5) = GET_equip_desc_AND_proj_desc(sqldr.Item("charge_to").ToString, 4)
                End If

                dgCashVoucherItems.Rows.Add(b)

            End While
            sqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub

    Public Function get_item_name_warehouse(ByVal wh_id As Integer, ByVal n As Integer) As String
        Dim newsqlcon As New SQLcon
        Dim newcmd As SqlCommand
        Dim newsqldr As SqlDataReader

        Try
            newsqlcon.connection.Open()
            publicquery = "SELECT * FROM dbwarehouse_items WHERE wh_id = '" & wh_id & "'"
            newcmd = New SqlCommand(publicquery, newsqlcon.connection)
            newsqldr = newcmd.ExecuteReader
            While newsqldr.Read

                If n = 1 Then
                    get_item_name_warehouse = newsqldr.Item("whItem").ToString
                ElseIf n = 2 Then
                    get_item_name_warehouse = newsqldr.Item("whItemDesc").ToString
                End If

            End While

            newsqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
        End Try
    End Function

    Public Sub get_brand_name(ByVal wh_id As Integer)
        cmb_brand.Items.Clear()
        Dim newSQLCON As New SQLcon
        Dim NEWDR As SqlDataReader
        Try
            newSQLCON.connection.Open()
            publicquery = "SELECT DISTINCT * FROM dbfacilities_list WHERE fac_id = '" & wh_id & "'"
            cmd = New SqlCommand(publicquery, newSQLCON.connection)
            NEWDR = cmd.ExecuteReader
            While NEWDR.Read
                cmb_brand.Items.Add(NEWDR.Item("brand").ToString)
            End While
            NEWDR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQLCON.connection.Close()
        End Try
    End Sub

    'Public Sub view_items_from_rs()
    '    Try
    '        SQLcon.connection.Open()
    '        cmd = New SqlCommand("proc_cashvoucher_query", SQLcon.connection)
    '        cmd.Parameters.Clear()
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.Parameters.AddWithValue("@n", 1)
    '        cmd.Parameters.AddWithValue("@rsNo", txtRSNo.Text)
    '        Dim c As Integer

    '        sqldr = cmd.ExecuteReader

    '        While sqldr.Read
    '            Dim a(10) As String

    '            a(0) = sqldr.Item("rs_id").ToString
    '            a(1) = sqldr.Item("wh_id").ToString
    '            a(2) = sqldr.Item("item_desc").ToString()
    '            a(3) = sqldr.Item("item_desc").ToString
    '            a(4) = FReceivingReport.multiplecharges(CInt(sqldr.Item("rs_id").ToString), 0)
    '            a(5) = sqldr.Item("qty").ToString
    '            a(6) = 0
    '            a(7) = FormatNumber(CDbl(a(5)) * CDbl(a(6)), , , TriState.True)
    '            a(8) = sqldr.Item("charge_to").ToString

    '            'If sqldr.Item("process").ToString = "EQUIPMENT" Then
    '            '    a(4) = GET_equip_desc_AND_proj_desc(sqldr.Item("charge_to").ToString, 1)
    '            'ElseIf sqldr.Item("process").ToString = "PROJECT" Then
    '            '    a(4) = GET_equip_desc_AND_proj_desc(sqldr.Item("charge_to").ToString, 2)
    '            'ElseIf sqldr.Item("process").ToString = "ADFIL" Or sqldr.Item("process").ToString = "PERSONAL" Then
    '            '    a(4) = GET_equip_desc_AND_proj_desc(sqldr.Item("charge_to").ToString, 3)
    '            'ElseIf sqldr.Item("process").ToString = "WAREHOUSE" Then
    '            '    a(4) = GET_equip_desc_AND_proj_desc(sqldr.Item("charge_to").ToString, 4)
    '            'End If

    '            dgCashVoucherItems.Rows.Add(a)

    '            'For i = 0 To dgCashVoucherItems.Rows.Count - 1
    '            '    With dgCashVoucherItems
    '            '        .Rows(i).Cells(3).ReadOnly = True
    '            '    End With
    '            'Next

    '            Dim process As String = sqldr.Item("process").ToString

    '            With dgCashVoucherItems
    '                If process = "FACILITIES" Or process = "TOOLS" Or process = "ADD-ON" Then
    '                    .Rows(c).Cells(3).ReadOnly = True
    '                End If
    '            End With

    '            c += 1
    '        End While
    '        sqldr.Close()

    '    Catch ex As Exception
    '        MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        SQLcon.connection.Close()
    '    End Try

    'End Sub

    Private Sub dgCashVoucherItems_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgCashVoucherItems.CellBeginEdit
        rowind = Format(get_datagrid_rowindex)
        old_amount = dgCashVoucherItems.Rows(Format(rowind)).Cells(7).Value

    End Sub

    Private Sub dgCashVoucherItems_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCashVoucherItems.CellDoubleClick
        'rowind = Format(get_datagrid_rowindex)
        'If dgCashVoucherItems.Rows(rowind).Cells(3).Selected = True Then
        '    If btnSave.Text = "Save" Then
        '        If receiving_inout = "FACILITIES" Or receiving_inout = "TOOLS" Or receiving_inout = "ADD-ON" Then
        '            get_brand_name(dgCashVoucherItems.Rows(rowind).Cells(1).Value)
        '            panel_brand.Visible = True
        '        End If
        '    ElseIf btnSave.Text = "Update" Then
        '        receiving_inout = get_inOut(dgCashVoucherItems.Rows(rowind).Cells(10).Value)
        '        If receiving_inout = "FACILITIES" Or receiving_inout = "TOOLS" Or receiving_inout = "ADD-ON" Then
        '            get_brand_name(dgCashVoucherItems.Rows(rowind).Cells(1).Value)
        '            panel_brand.Visible = True
        '        End If
        '    End If
        'Else
        '    panel_brand.Visible = False
        'End If
    End Sub

    Public Function get_inOut(ByVal rsID As Integer) As String
        Try
            SQLcon.connection.Open()
            publicquery = "SELECT b.cv_itemDesc, a.IN_OUT FROM dbrequisition_slip a INNER JOIN dbCashVoucher_items b ON a.rs_id = b.rs_id WHERE b.rs_id = '" & rsID & "'"
            cmd = New SqlCommand(publicquery, SQLcon.connection)
            sqldr = cmd.ExecuteReader
            While sqldr.Read
                get_inOut = sqldr.Item("IN_OUT").ToString
            End While
            sqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Function

    Public Function get_datagrid_rowindex() As Integer
        For i As Integer = 0 To Me.dgCashVoucherItems.SelectedCells.Count - 1
            get_datagrid_rowindex = Me.dgCashVoucherItems.SelectedCells.Item(i).RowIndex
        Next
    End Function

    Private Sub dgCashVoucherItems_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCashVoucherItems.CellEndEdit
        Dim qty As Integer
        Dim amount As Double
        Dim total As Double

        'If Not IsNumeric(dgCashVoucherItems.Rows(Format(rowind)).Cells(7).Value()) Then

        '    MessageBox.Show("Entry must numeric..", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    dgCashVoucherItems.Rows(Format(rowind)).Cells(7).Selected = True
        '    dgCashVoucherItems.Rows(Format(rowind)).Cells(7).Value = FormatNumber(old_amount, 2, , , TriState.True)

        'Else
        qty = dgCashVoucherItems.Rows(Format(rowind)).Cells(6).Value
        amount = dgCashVoucherItems.Rows(Format(rowind)).Cells(7).Value

        total = CDbl(qty * amount)

        'dgCashVoucherItems.Rows(Format(rowind)).Cells(7).Value = FormatNumber(amount)
        dgCashVoucherItems.Rows(Format(rowind)).Cells(8).Value = FormatNumber(total)
        grandtotal()

        '  End If

        'For Each row1 As DataGridViewRow In dgCashVoucherItems.Rows
        '    qty = row1.Cells(5).Value

        '    amount = row1.Cells(6).Value
        '    total = CDbl(qty * amount)

        '    For Each row2 As DataGridViewRow In dgCashVoucherItems.Rows
        '        row1.Cells(6).Value = FormatNumber(amount)
        '        row1.Cells(7).Value = FormatNumber(total)
        '        grandtotal()
        '    Next
        'Next
    End Sub

    Public Sub grandtotal()
        Dim total As Double
        For i = 0 To dgCashVoucherItems.Rows.Count - 1
            total += CDbl(dgCashVoucherItems.Rows(i).Cells(8).Value)
        Next
        lblTotalAmount.Text = FormatNumber(total, 2, , , TriState.True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If cmbSupplier.Text = "" Then
            MessageBox.Show("Pls select 1 supplier in Paid to", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbSupplier.Focus()
        ElseIf txtCVno.Text = "" Then
            MessageBox.Show("Pls fill up the CV No", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCVno.Focus()
        ElseIf txtReceivedby.Text = "" Then
            MessageBox.Show("Pls fill up Received by", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtReceivedby.Focus()
        Else
            If btnSave.Text = "Save" Then
                save_cash_voucher_items()
                FRequistionForm.load_rs_3(1)
            ElseIf btnSave.Text = "Update" Then
                update_cv_info()
                update_cv_items()
                FCashVoucherList.load_cv_List()
                listfocus(FCashVoucherList.lvlvoucherlist, lbl_cv_info_id.Text)
            End If
            'Me.Dispose()
        End If

    End Sub

    Public Sub get_cv_info_id(ByVal rsID As Integer)
        Dim newsqlcon As New SQLcon
        Dim newsqldr1 As SqlDataReader
        'Dim newcmd As SqlCommand

        Try
            newsqlcon.connection.Open()
            publicquery = "SELECT * FROM dbCashVoucher_items WHERE rs_id = '" & rsID & "'"
            cmd = New SqlCommand(publicquery, newsqlcon.connection)
            newsqldr1 = cmd.ExecuteReader
            While newsqldr1.Read
                cvINFO_id = newsqldr1.Item("cv_info_id").ToString
            End While
            newsqldr1.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
        End Try
    End Sub

    Public Function save_cash_voucher_info() As Integer
        Dim newSQLcon As New SQLcon

        Try
            newSQLcon.connection.Open()
            cmd = New SqlCommand("proc_cashvoucher_query", newSQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@n", 2)
            cmd.Parameters.AddWithValue("@supplierID", get_id("dbSupplier", "Supplier_Name", cmbSupplier.Text, 0))
            'cmd.Parameters.AddWithValue("@chargeTo_id", charge_to_id)
            cmd.Parameters.AddWithValue("@rsNo", txtRSNo.Text)
            cmd.Parameters.AddWithValue("@cvNo", txtCVno.Text)
            cmd.Parameters.AddWithValue("@date_voucher", Format(Date.Parse(DTPVoucher.Text), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@receivedBy", txtReceivedby.Text)

            pub_cv_id = cmd.ExecuteScalar()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQLcon.connection.Close()
        End Try

    End Function

    Public Function save_cash_voucher_items_rs_id() As Integer

        Try
            SQLcon.connection.Open()

            For i = 0 To dgCashVoucherItems.RowCount - 1

                cmd = New SqlCommand("proc_cashvoucher_query", SQLcon.connection)
                cmd.Parameters.Clear()
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@n", 3)
                cmd.Parameters.AddWithValue("@rsNo", txtRSNo.Text)
                cmd.Parameters.AddWithValue("@rsID", dgCashVoucherItems.Rows(i).Cells(0).Value)
                cmd.Parameters.AddWithValue("@wh_id", dgCashVoucherItems.Rows(i).Cells(1).Value)
                cmd.Parameters.AddWithValue("@cvItems", dgCashVoucherItems.Rows(i).Cells(2).Value)
                cmd.Parameters.AddWithValue("@cvQty", dgCashVoucherItems.Rows(i).Cells(3).Value)
                cmd.Parameters.AddWithValue("@cvAmount", dgCashVoucherItems.Rows(i).Cells(4).Value)
                cmd.Parameters.AddWithValue("@cvTotal", dgCashVoucherItems.Rows(i).Cells(5).Value)

                cmd.ExecuteNonQuery()
            Next

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
            MessageBox.Show("Successfully Saved...", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try
    End Function

    Public Function save_cash_voucher_items() As Integer

        save_cash_voucher_info()

        Try
            SQLcon.connection.Open()

            cmd = New SqlCommand("proc_cashvoucher_query", SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure

            For i = 0 To dgCashVoucherItems.RowCount - 1
                If dgCashVoucherItems.Rows(i).Cells("Column9").Value = True Then
                    cmd = New SqlCommand("proc_cashvoucher_query", SQLcon.connection)
                    cmd.Parameters.Clear()
                    cmd.CommandType = CommandType.StoredProcedure

                    Dim wh_id As Integer = dgCashVoucherItems.Rows(i).Cells(2).Value
                    Dim itemdesc As String = dgCashVoucherItems.Rows(i).Cells(4).Value
                    Dim qty As Integer = dgCashVoucherItems.Rows(i).Cells(6).Value

                    Dim lof_id As Integer = get_lof_id(wh_id, itemdesc)

                    cmd.Parameters.AddWithValue("@n", 3)
                    cmd.Parameters.AddWithValue("@rsNo", txtRSNo.Text)
                    cmd.Parameters.AddWithValue("@rsID", dgCashVoucherItems.Rows(i).Cells(0).Value)
                    cmd.Parameters.AddWithValue("@wh_id", dgCashVoucherItems.Rows(i).Cells(2).Value)
                    cmd.Parameters.AddWithValue("@cvQty", dgCashVoucherItems.Rows(i).Cells(6).Value)
                    cmd.Parameters.AddWithValue("@cvAmount", dgCashVoucherItems.Rows(i).Cells(7).Value)
                    cmd.Parameters.AddWithValue("@cvTotal", dgCashVoucherItems.Rows(i).Cells(8).Value)
                    cmd.Parameters.AddWithValue("@charge_to_id", dgCashVoucherItems.Rows(i).Cells(9).Value)

                    Dim cv_items_id As Integer = cmd.ExecuteScalar()

                    If lblTypeOfReq.Text = "BORROWER" Then

                        If qty > 1 Then
                            For ii = 0 To qty - 1
                                INSERT_FACILITIES_ITEM1(cv_items_id, lof_id, Date.Parse("1991-01-01"), 0, 0, "", "pending", 1, "", "", 0)
                            Next
                        Else
                            INSERT_FACILITIES_ITEM1(cv_items_id, lof_id, Date.Parse("1991-01-01"), 0, 0, "", "pending", qty, "", "", 0)
                        End If

                    End If

                Else
                End If

            Next

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
            MessageBox.Show("Successfully Saved..", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Function
    Public Sub INSERT_FACILITIES_ITEM1(ByVal po_det_id As Integer, ByVal lof_id As Integer, ByVal date_aquired As DateTime, _
                                     ByVal custodian As Integer, ByVal received_to As Integer, ByVal condition As String, _
                                     ByVal remarks As String, ByVal qty As Integer, ByVal type_of_custodian As String, _
                                     ByVal type_of_received As String, ByVal no As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_facilities", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 32)
            newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)
            newCMD.Parameters.AddWithValue("@lof_id", lof_id)
            newCMD.Parameters.AddWithValue("@date_aquired", date_aquired)
            newCMD.Parameters.AddWithValue("@type_of_custodian", type_of_custodian)
            newCMD.Parameters.AddWithValue("@custodian", custodian)
            newCMD.Parameters.AddWithValue("@type_of_received", type_of_received)
            newCMD.Parameters.AddWithValue("@received_to", received_to)
            newCMD.Parameters.AddWithValue("@condition", condition)
            newCMD.Parameters.AddWithValue("@remarks", remarks)
            newCMD.Parameters.AddWithValue("@qty", qty)
            newCMD.Parameters.AddWithValue("@no", no)
            newCMD.Parameters.AddWithValue("@type_of_purchasing", "CASH")

            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Sub
    Private Function get_lof_id(ByVal fac_id As Integer, ByVal fac_brand As String) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()

            Dim query As String = ""

            query &= "SELECT a.lof_id,b.facility_name,a.brand FROM dbfacilities_list a "
            query &= "INNER JOIN dbfacilities_names b "
            query &= "ON a.fac_id = b.fac_id "
            query &= "WHERE b.fac_id = " & fac_id & " "
            query &= "AND a.brand = '" & fac_brand & "'"

            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_lof_id = CInt(newDR.Item("lof_id").ToString)
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'conn.connection.Close()
            newSQ.connection.Close()
        End Try
    End Function

    Public Sub update_cv_info()
        Try
            SQLcon.connection.Open()
            cmd = New SqlCommand("proc_cashvoucher_query", SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@n", 5)
            cmd.Parameters.AddWithValue("@cv_id", lbl_cv_info_id.Text)
            cmd.Parameters.AddWithValue("@cvNo", txtCVno.Text)
            cmd.Parameters.AddWithValue("@supplierID", get_supplier_id(cmbSupplier.Text))
            cmd.Parameters.AddWithValue("@date_voucher", DTPVoucher.Text)
            cmd.Parameters.AddWithValue("@receivedBy", txtReceivedby.Text)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub

    Public Sub update_exst_cv_info()
        Dim newSQ As New SQLcon
        Try
            newSQ.connection.Open()
            cmd = New SqlCommand("proc_cashvoucher_query", newSQ.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@n", 5)
            cmd.Parameters.AddWithValue("@cv_id", cvINFO_id)
            cmd.Parameters.AddWithValue("@cvNo", txtCVno.Text)
            cmd.Parameters.AddWithValue("@rsNo", txtRSNo.Text)
            cmd.Parameters.AddWithValue("@supplierID", get_id("dbSupplier", "Supplier_Name", cmbSupplier.Text, 0))
            'If process = "PERSONAL" Or process = "ADFIL" Or process = "WAREHOUSE" Then
            cmd.Parameters.AddWithValue("@chargeTo_id", charge_to_id)
            'ElseIf process = "PROJECT" Or process = "EQUIPMENT" Then
            'cmd.Parameters.AddWithValue("@chargeTo_id", txt_proj_equp_id.Text)
            'End If
            cmd.Parameters.AddWithValue("@date_voucher", DTPVoucher.Text)
            cmd.Parameters.AddWithValue("@receivedBy", txtReceivedby.Text)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Public Sub update_cv_items()
        Try
            SQLcon.connection.Open()
            For i As Integer = 0 To dgCashVoucherItems.Rows.Count - 1
                If dgCashVoucherItems.Rows(i).Cells("Column9").Value = True Then

                    cmd = New SqlCommand("proc_cashvoucher_query", SQLcon.connection)
                    cmd.Parameters.Clear()
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@n", 6)
                    cmd.Parameters.AddWithValue("@cv_id", lbl_cv_info_id.Text)
                    cmd.Parameters.AddWithValue("@cv_items_id", dgCashVoucherItems.Rows(i).Cells(0).Value)
                    'cmd.Parameters.AddWithValue("@wh_id", dgCashVoucherItems.Rows(i).Cells(2).Value)
                    'cmd.Parameters.AddWithValue("@cvItemDesc", dgCashVoucherItems.Rows(i).Cells(4).Value)
                    'cmd.Parameters.AddWithValue("@cvQty", dgCashVoucherItems.Rows(i).Cells(6).Value)
                    cmd.Parameters.AddWithValue("@cvAmount", dgCashVoucherItems.Rows(i).Cells(7).Value)
                    cmd.Parameters.AddWithValue("@cvTotal", dgCashVoucherItems.Rows(i).Cells(8).Value)

                    cmd.ExecuteNonQuery()

                Else
                End If

            Next
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
            MessageBox.Show("Successfully UPDATED !", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Public Sub update_exst_cv_items()
        Dim SQ As New SQLcon
        Try
            SQ.connection.Open()
            For i As Integer = 0 To dgCashVoucherItems.Rows.Count - 1

                cmd = New SqlCommand("proc_cashvoucher_query", SQ.connection)
                cmd.Parameters.Clear()
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@n", 7)
                cmd.Parameters.AddWithValue("@cv_id", cvINFO_id)
                cmd.Parameters.AddWithValue("@rsID", rs_id)
                cmd.Parameters.AddWithValue("@wh_id", dgCashVoucherItems.Rows(i).Cells(1).Value)
                cmd.Parameters.AddWithValue("@cvItems", dgCashVoucherItems.Rows(i).Cells(2).Value)
                cmd.Parameters.AddWithValue("@cvQty", dgCashVoucherItems.Rows(i).Cells(3).Value)
                cmd.Parameters.AddWithValue("@cvAmount", dgCashVoucherItems.Rows(i).Cells(4).Value)
                cmd.Parameters.AddWithValue("@cvTotal", dgCashVoucherItems.Rows(i).Cells(5).Value)

                cmd.ExecuteNonQuery()

            Next
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
       
        show_supplier_list()
        btn_update.Enabled = False
        panel_chargeTo.Visible = True
        txt_supplier_name.Focus()

    End Sub

    Private Sub show_supplier_list()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        lvl_chargeto.Items.Clear()
        newSQ.connection.Open()
        Try

            Dim query As String = "SELECT * FROM dbSupplier order by Supplier_Id asc"
            newCMD = New SqlCommand(query, newSQ.connection)

            newDR = newCMD.ExecuteReader

            While newDR.Read

                Dim a(5) As String
                a(0) = newDR.Item(0).ToString
                a(1) = newDR.Item(1).ToString
                a(2) = newDR.Item(2).ToString

                Dim lvl As New ListViewItem(a)
                lvl_chargeto.Items.Add(lvl)

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        panel_chargeTo.Visible = False
    End Sub

    Private Sub lvl_chargeto_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvl_chargeto.DoubleClick
        'txtChargeToID.Text = lvl_chargeto.SelectedItems(0).SubItems(0).Text
        'cmbSupplier.Text = lvl_chargeto.SelectedItems(0).SubItems(1).Text
        ''txtChargeTo.Text = lvl_chargeto.SelectedItems(0).SubItems(1).Text
        'panel_chargeTo.Visible = False
    End Sub

    Private Sub cmb_chargeto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_chargeto.SelectedIndexChanged
        If process = "PROJECT" Then
            get_prOj_equip_id(cmb_chargeto.Text, 0)
        ElseIf process = "EQUIPMENT" Then
            get_prOj_equip_id(cmb_chargeto.Text, 1)
        End If
        txtChargeToID.Clear()
    End Sub

    Public Sub load_receivedby(ByVal receive_by As String)
        Dim counter As Integer = 0
        lbox_cash_voucher.Items.Clear()
        Try
            SQLcon.connection.Open()
            publicquery = "SELECT * FROM dbCashVoucher_info WHERE cv_received_by LIKE '%" & receive_by & "%'"
            cmd = New SqlCommand(publicquery, SQLcon.connection)
            sqldr = cmd.ExecuteReader
            While sqldr.Read
                lbox_cash_voucher.Items.Add(sqldr.Item("cv_received_by").ToString)
                counter += 1
            End While
            If counter > 0 Then
                lbox_cash_voucher.Visible = True
            Else
                lbox_cash_voucher.Visible = False
            End If
            sqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub

    Private Sub txtReceivedby_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReceivedby.GotFocus, DTPVoucher.GotFocus, txtCVno.GotFocus, txtRSNo.GotFocus, txtChargeTo.GotFocus, cmbSupplier.GotFocus, _
    dgCashVoucherItems.GotFocus, txt_supplier_name.GotFocus, txt_location.GotFocus

        sender.backcolor = Color.Yellow

        If txtReceivedby.Focused Then
            txtname = txtReceivedby.Name
            txtReceivedby.SelectAll()
        End If

        lbox_cash_voucher.Visible = False

    End Sub

    Private Sub txtReceivedby_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReceivedby.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
            If lbox_cash_voucher.Visible = True Then
                If lbox_cash_voucher.Items.Count > 0 Then
                    lbox_cash_voucher.Focus()
                    lbox_cash_voucher.SelectedIndex = 0
                End If
            Else
                lbox_cash_voucher.Visible = False
            End If
        End If
    End Sub

    Private Sub txtCVno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCVno.KeyDown
        If Not (e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 48 Or e.KeyValue = 49 Or e.KeyValue = 50 Or e.KeyValue = 51 Or e.KeyValue = 52 Or e.KeyValue = 53 Or e.KeyValue = 54 Or _
       e.KeyValue = 55 Or e.KeyValue = 56 Or e.KeyValue = 57 Or e.KeyValue = 96 Or e.KeyValue = 97 Or e.KeyValue = 98 Or e.KeyValue = 99 Or _
       e.KeyCode = Keys.OemPeriod Or _
      e.KeyValue = 100 Or e.KeyValue = 101 Or e.KeyValue = 102 Or e.KeyValue = 103 Or e.KeyValue = 104 Or e.KeyValue = 105 Or e.KeyValue = 37 Or e.KeyValue = 39) Then

            e.SuppressKeyPress() = True
        End If
    End Sub

    Private Sub txt_location_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_location.KeyDown, txt_supplier_name.KeyDown
        If e.KeyCode = Keys.Enter Then
            If btn_save.Text = "Save" Then
                btn_save.PerformClick()
            ElseIf btn_update.Text = "Update" Then
                btn_update.PerformClick()
            End If
        End If
    End Sub

    Private Sub txtReceivedby_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReceivedby.Leave, DTPVoucher.Leave, txtCVno.Leave, txtRSNo.Leave, txtChargeTo.Leave, cmbSupplier.Leave, _
    txt_supplier_name.Leave, txt_location.Leave
        sender.backcolor = Color.White
    End Sub


    Private Sub txtReceivedby_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReceivedby.TextChanged
        lbox_cash_voucher.Width = txtReceivedby.Width
        lbox_cash_voucher.Location = New Point(txtReceivedby.Location.X, txtReceivedby.Location.Y + 24)
        If txtReceivedby.Focus = True Then
            lbox_cash_voucher.Visible = True
            load_receivedby(txtReceivedby.Text)
        End If
    End Sub

    Private Sub lbox_cash_voucher_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbox_cash_voucher.DoubleClick
        If lbox_cash_voucher.SelectedItems.Count > 0 Then
            For Each ctr As Control In Me.Controls
                If ctr.Name = txtname Then
                    ctr.Text = lbox_cash_voucher.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next

            lbox_cash_voucher.Visible = False
        End If
    End Sub

    Private Sub lbox_cash_voucher_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lbox_cash_voucher.KeyDown
        If e.KeyCode = Keys.Enter Then
            For Each ctr As Control In Me.Controls
                If ctr.Name = txtname Then
                    ctr.Text = lbox_cash_voucher.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next
            lbox_cash_voucher.Visible = False
        End If
    End Sub

    Private Sub Btn_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_exit.Click
        panel_brand.Visible = False
    End Sub

    Private Sub btn_select_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_select.Click
        If cmb_brand.Text = "" Then
            MessageBox.Show("Please select 1 item to continue", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmb_brand.Focus()
        Else
            dgCashVoucherItems.Rows(rowind).Cells(3).Value = cmb_brand.Text
            panel_brand.Visible = False
        End If
    End Sub

    Private Sub dgCashVoucherItems_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgCashVoucherItems.EditingControlShowing
        If dgCashVoucherItems.CurrentCell.ColumnIndex = 7 Then

            AddHandler CType(e.Control, TextBox).KeyDown, AddressOf txt_inputnumeric_KeyDown

        End If
    End Sub

    Private Sub txt_inputnumeric_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_inputnumeric.KeyDown
        If Not (e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 48 Or e.KeyValue = 49 Or e.KeyValue = 50 Or e.KeyValue = 51 Or e.KeyValue = 52 Or e.KeyValue = 53 Or e.KeyValue = 54 Or _
         e.KeyValue = 55 Or e.KeyValue = 56 Or e.KeyValue = 57 Or e.KeyValue = 96 Or e.KeyValue = 97 Or e.KeyValue = 98 Or e.KeyValue = 99 Or _
         e.KeyCode = Keys.OemPeriod Or _
        e.KeyValue = 100 Or e.KeyValue = 101 Or e.KeyValue = 102 Or e.KeyValue = 103 Or e.KeyValue = 104 Or e.KeyValue = 105 Or e.KeyValue = 37 Or e.KeyValue = 39) Then

            e.SuppressKeyPress() = True
        End If
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click

        lbl_supplierID.Text = lvl_chargeto.SelectedItems(0).Text
        lvl_chargeto.Enabled = False
        btn_update.Enabled = True
        btn_save.Text = "Cancel"
        txt_supplier_name.Text = lvl_chargeto.SelectedItems(0).SubItems(1).Text
        txt_location.Text = lvl_chargeto.SelectedItems(0).SubItems(2).Text

    End Sub

    Private Sub cms_chargeto_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cms_chargeto.Opening
        If lvl_chargeto.SelectedItems.Count > 0 Then
            cms_chargeto.Enabled = True
        Else
            cms_chargeto.Enabled = False
        End If
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click

        If txt_supplier_name.Text = "" Or txt_location.Text = "" Then
            MessageBox.Show("Pls fill up all fields...", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txt_supplier_name.Focus()
        Else
            If btn_save.Text = "Save" Then
                save_supplier()
                load_supplier()
                txt_supplier_name.Text = ""
                txt_location.Text = ""
                txt_supplier_name.Focus()
            ElseIf btn_save.Text = "Cancel" Then
                If MessageBox.Show("Are you sure you want to cancel?", "SUPPLY INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Yes Then
                    cancel()
                Else
                    Return
                End If
            End If
        End If

    End Sub

    Public Sub cancel()
        lvl_chargeto.Enabled = True
        btn_update.Enabled = False
        btn_save.Text = "Save"
        txt_supplier_name.Text = ""
        txt_location.Text = ""
        txt_supplier_name.Focus()
    End Sub

    Public Sub save_supplier()
        Try
            SQLcon.connection.Open()
            cmd = New SqlCommand("proc_cashvoucher_query", SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@n", 11)
            cmd.Parameters.AddWithValue("@supplier_name", txt_supplier_name.Text)
            cmd.Parameters.AddWithValue("@supplier_location", txt_location.Text)
            n = cmd.ExecuteScalar
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
            MessageBox.Show("Successfully Saved...", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            show_supplier_list()
            listfocus(lvl_chargeto, Focus)
            lvl_chargeto.Items(lvl_chargeto.Items.Count - 1).Selected = True
            lvl_chargeto.EnsureVisible(lvl_chargeto.Items.Count - 1)
        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Delete_supplier(lvl_chargeto.SelectedItems(0).Text)
    End Sub

    Public Sub Delete_supplier(ByVal id As Integer)
        Try
            SQLcon.connection.Open()
            publicquery = "DELETE FROM dbSupplier WHERE Supplier_Id = '" & id & "'"
            cmd = New SqlCommand(publicquery, SQLcon.connection)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
            lvl_chargeto.SelectedItems(0).Remove()
            txt_supplier_name.Focus()
        End Try
    End Sub

    Private Sub btn_update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_update.Click
        update_supplier()
        load_supplier()
        cancel()
    End Sub

    Public Sub update_supplier()
        Try
            SQLcon.connection.Open()
            cmd = New SqlCommand("proc_cashvoucher_query", SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@n", 12)
            cmd.Parameters.AddWithValue("@supplierID", lvl_chargeto.SelectedItems(0).Text)
            cmd.Parameters.AddWithValue("@supplier_name", txt_supplier_name.Text)
            cmd.Parameters.AddWithValue("@supplier_location", txt_location.Text)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
            MessageBox.Show("Successfully Updated...", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            show_supplier_list()
            listfocus(lvl_chargeto, lbl_supplierID.Text)
        End Try
    End Sub

    Private Sub lvl_chargeto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvl_chargeto.SelectedIndexChanged

    End Sub

    Private Sub panel_chargeTo_Paint(sender As Object, e As PaintEventArgs) Handles panel_chargeTo.Paint

    End Sub

    Private Sub lbox_cash_voucher_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbox_cash_voucher.SelectedIndexChanged

    End Sub
End Class