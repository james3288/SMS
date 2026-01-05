
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FPreviousStackCardFinal
    Public SQ As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Dim n As Integer

    Dim IsFormBeingDragged As Boolean
    Dim drag As Boolean
    Dim MouseDownX As Integer
    Dim MouseDownY As Integer
    Dim tor_id_ToR As Integer
    Dim cNewAllCharges As New Model._Mod_Charges
    Dim cMyAllCharges As New List(Of Model._Mod_Charges.charges_info)
    Dim cCustomMsg As New customMessageBox

    Private cListOfCharges As New List(Of String)
    Public Sub insert_PreviousStockCard(Optional paramChargeToId As Integer = 0)
        Dim tor_sub_id As Integer = get_tor_sub_id(tor_id_ToR, cmbSubTypeofRequest.Text)
        Dim n As Integer
        Try

            SQ.connection.Open()
            Dim sqlComm As New SqlCommand()

            sqlComm.Connection = SQ.connection
            sqlComm.CommandText = "sp_crud_PreviousStockCard"
            sqlComm.CommandType = CommandType.StoredProcedure
            'sqlComm.Parameters.AddWithValue("@psc_id", .Text)

            sqlComm.Parameters.AddWithValue("@date_previous", DateTime.Parse(DTP_PreviousStockcard.Text))
            sqlComm.Parameters.AddWithValue("@rs_no", txtRSno.Text)
            sqlComm.Parameters.AddWithValue("@invoice_no", txtInvoice.Text)
            sqlComm.Parameters.AddWithValue("@receiving_no", txt_Receiving_no.Text)
            sqlComm.Parameters.AddWithValue("@ws_no", txt_Ws_no.Text)
            sqlComm.Parameters.AddWithValue("@typeRequest", cmbRequestType.Text)
            sqlComm.Parameters.AddWithValue("@status", cmbInOut.Text)
            sqlComm.Parameters.AddWithValue("@supplier_receipient", paramChargeToId)
            sqlComm.Parameters.AddWithValue("@wh_id", wh_id)
            sqlComm.Parameters.AddWithValue("@in_out", CDbl(txtIn_out.Text))
            sqlComm.Parameters.AddWithValue("@balance", CDbl(txtBalance.Text))
            sqlComm.Parameters.AddWithValue("@remarks", txtRemarks.Text)
            sqlComm.Parameters.AddWithValue("@type_of_charge", cmbTypeofCharge.Text)
            sqlComm.Parameters.AddWithValue("@type_of_purchase", cmbTypeOfPurchase.Text)
            sqlComm.Parameters.AddWithValue("@tor_sub_id", tor_sub_id)
            sqlComm.Parameters.AddWithValue("@n", 1)

            n = sqlComm.ExecuteScalar
            'MsgBox(n)
            MessageBox.Show("Successfully Saved...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' FPreviousStockCard.load_PreviousStockCard()
            ' listfocus(FPreviousStockCard.lvList, n)

            'clear_PreviousStockCardFinal()
            'load_PreviousStockCard()
            'clear()

            With FPreviousStockCard
                .lvList.Items.Clear()
                .cmbSearchByCategory.Text = "Rs_no"
                .txtSearch.Text = txtRSno.Text
                .btnSearch.PerformClick()
                listfocus(.lvList, n)
                ' MsgBox(n)
            End With


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Function get_tor_sub_id(ByVal x As Integer, ByVal y As String) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim query As String
        Try
            newSQ.connection.Open()
            query = "SELECT tor_sub_id FROM dbType_of_Request_sub WHERE tor_id= '" & x & "' AND tor_sub_desc = '" & y & "'"
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_tor_sub_id = newDR.Item(0).ToString
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Public Sub UpdateRecord_PreviousStockCard(Optional paramChargeToId As Integer = 0)
        Dim tor_sub_id As Integer = get_tor_sub_id(tor_id_ToR, cmbSubTypeofRequest.Text)
        Dim wh_id As Integer = FPreviousStockCard.lvList.SelectedItems(0).SubItems(18).Text

        Dim newsql As New SQLcon
        get_id_item_description()
        With FPreviousStockCard
            n = .lvList.SelectedItems(0).SubItems(0).Text
        End With

        Try
            newsql.connection.Open()
            Dim sqlComm As New SqlCommand

            sqlComm.Connection = newsql.connection
            sqlComm.CommandText = "sp_crud_PreviousStockCard"
            sqlComm.CommandType = CommandType.StoredProcedure
            sqlComm.Parameters.AddWithValue("@psc_id", n)
            sqlComm.Parameters.AddWithValue("@date_previous", DateTime.Parse(DTP_PreviousStockcard.Text))
            sqlComm.Parameters.AddWithValue("@rs_no", txtRSno.Text)
            sqlComm.Parameters.AddWithValue("@invoice_no", txtInvoice.Text)
            sqlComm.Parameters.AddWithValue("@receiving_no", txt_Receiving_no.Text)
            sqlComm.Parameters.AddWithValue("@ws_no", txt_Ws_no.Text)
            sqlComm.Parameters.AddWithValue("@typeRequest", cmbRequestType.Text)
            sqlComm.Parameters.AddWithValue("@status", cmbInOut.Text)
            sqlComm.Parameters.AddWithValue("@supplier_receipient", paramChargeToId)
            sqlComm.Parameters.AddWithValue("@wh_id", wh_id)
            sqlComm.Parameters.AddWithValue("@in_out", CDbl(txtIn_out.Text))
            sqlComm.Parameters.AddWithValue("@balance", CDbl(txtBalance.Text))
            sqlComm.Parameters.AddWithValue("@remarks", txtRemarks.Text)
            sqlComm.Parameters.AddWithValue("@type_of_charge", cmbTypeofCharge.Text)
            sqlComm.Parameters.AddWithValue("@type_of_purchase", cmbTypeOfPurchase.Text)
            sqlComm.Parameters.AddWithValue("@tor_sub_id", tor_sub_id)
            sqlComm.Parameters.AddWithValue("@n", 2)
            sqlComm.ExecuteNonQuery()

            'load_PreviousStockCard()
            'clear()
            MessageBox.Show("Successfully Updated...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ' clear_PreviousStockCardFinal()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsql.connection.Close()
        End Try

    End Sub
    Public Sub get_id_supplier_or_recepient(ByVal x As Integer)

        Dim newSQ As New SQLcon

        Try
            newSQ.connection.Open()

            If x = 0 Then
                publicquery = "SELECT Supplier_Id FROM dbSupplier WHERE Supplier_Name = '" & txtChargeTo.Text & "'"
            ElseIf x = 1 Then
                publicquery = "SELECT charge_to_id FROM dbCharge_to WHERE charge_to = '" & txtChargeTo.Text & "'"
            ElseIf x = 2 Then
                publicquery = "SELECT wh_area_id FROM dbwh_area WHERE wh_area = '" & txtChargeTo.Text & "'"
            End If

            cmd = New SqlCommand(publicquery, newSQ.connection)
            dr = cmd.ExecuteReader

            While dr.Read

                If x = 0 Then
                    charge_to_id = dr.Item("Supplier_Id").ToString
                ElseIf x = 1 Then
                    charge_to_id = dr.Item("charge_to_id").ToString
                ElseIf x = 2 Then
                    charge_to_id = dr.Item("wh_area_id").ToString
                End If

            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
       
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        wh_item_destination = 2
        FListOfItems.ShowDialog()
    End Sub

    Private Sub txtChargeTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChargeTo.TextChanged
        If cmbTypeofCharge.Text = "PERSONAL" Then
            get_id_supplier_or_recepient(1)
        ElseIf cmbTypeofCharge.Text = "SUPPLIER" Then
            get_id_supplier_or_recepient(0)
        ElseIf cmbTypeofCharge.Text = "WAREHOUSE" Then
            get_id_supplier_or_recepient(2)
        ElseIf cmbTypeofCharge.Text = "ADFIL" Then
            get_id_supplier_or_recepient(1)
        End If
    End Sub
    Public Sub clear_PreviousStockCardFinal()
        cmbRequestType.Text = Nothing
        cmbInOut.Text = Nothing
        cmbTypeOfPurchase.Text = Nothing
        cmbTypeofCharge.Text = Nothing
        txtChargeTo.Text = ""
        cmbChargeTo.Text = Nothing
        DTP_PreviousStockcard.Text = ""
        txtRSno.Text = ""
        txtItemDesc.Text = ""
        txt_item_name.Text = ""
        txtInvoice.Text = ""
        txt_Receiving_no.Text = ""
        txt_Ws_no.Text = ""
        txtIn_out.Text = ""
        txtBalance.Text = ""
        txtRemarks.Text = ""

    End Sub
    Public Sub check_if_exist(Optional paramChargeToId As Integer = 0)
        Dim newSQ As New SQLcon
        Dim newdr As SqlDataReader

        Try
            newSQ.connection.Open()
            Dim sqlComm As New SqlCommand()

            sqlComm.Connection = newSQ.connection
            sqlComm.CommandText = "sp_crud_PreviousStockCard"
            sqlComm.CommandType = CommandType.StoredProcedure
            sqlComm.Parameters.AddWithValue("@wh_id", wh_id)
            sqlComm.Parameters.AddWithValue("@n", 11)

            newdr = sqlComm.ExecuteReader

            If newdr.HasRows Then
                MessageBox.Show("Data already exist...", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                'insert_PreviousStockCard()
                insert_PreviousStockCard(paramChargeToId)

            End If
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub lblDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDate.Click

    End Sub

    Private Sub txtRSno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRSno.KeyDown
        If Not (e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 48 Or e.KeyValue = 49 Or e.KeyValue = 50 Or e.KeyValue = 51 Or e.KeyValue = 52 Or e.KeyValue = 53 Or e.KeyValue = 54 Or _
                e.KeyValue = 55 Or e.KeyValue = 56 Or e.KeyValue = 57 Or e.KeyValue = 96 Or e.KeyValue = 97 Or e.KeyValue = 98 Or e.KeyValue = 99 Or _
                e.KeyCode = Keys.OemPeriod Or _
               e.KeyValue = 100 Or e.KeyValue = 101 Or e.KeyValue = 102 Or e.KeyValue = 103 Or e.KeyValue = 104 Or e.KeyValue = 105 Or e.KeyValue = 37 Or e.KeyValue = 39) Then

            e.SuppressKeyPress() = True

        End If
    End Sub

    Private Sub txtRSno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRSno.TextChanged

    End Sub

    Private Sub FPreviousStackCardFinal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            clear_PreviousStockCardFinal()
            Me.Close()
        End If
    End Sub

    Private Sub FPreviousStackCardFinal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnExit.Parent = pboxHeader
        btnExit.BringToFront()

        cmbTypeofCharge.Items.Clear()

        'clear_fields()

        'cmbRequestType.Items.Clear()
        'cmbRequestType.Items.Add("EQUIPMENT")
        'cmbRequestType.Items.Add("ADMIN")
        ' get_id_item_description()

        'load_set_type_of_charge("CASH", cmbTypeofCharge)
        load_cmbTypeofRequest()

        loadTypeOfPurchasing()

        Dim sortListOfCharges = From data In cListOfCharges
                                Select data Order By data Ascending

        cNewAllCharges.parameter("@n", 3)
        cMyAllCharges = cNewAllCharges.LISTOFCHARGES()


        For Each data As String In sortListOfCharges
            cmbTypeofCharge.Items.Add(data)
        Next


    End Sub

    Private Sub loadTypeOfPurchasing()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        cListOfCharges.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_charges2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 1)
            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                cListOfCharges.Add(newDR.Item("type_of_charges").ToString)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

            'add supplier
            cListOfCharges.Add("SUPPLIER")
        End Try
    End Sub
    Public Sub load_cmbTypeofRequest()
        cmbRequestType.Items.Clear()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim query As String
        Try
            newSQ.connection.Open()
            query = "SELECT tor_desc FROM dbType_of_Request "
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                cmbRequestType.Items.Add(newDR.Item(0).ToString)
            End While
            newDR.Close()


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Public Sub clear_fields()
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is TextBox Then
                Dim tbox As TextBox = ctr
                tbox.Clear()
            End If
        Next

        wh_id = 0
        charge_to_id = 0

        txtRSno.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
        FPreviousStockCard.Btn_for_PreviousStockCard.Enabled = True
        FPreviousStockCard.lvList.Enabled = True
    End Sub

    Private Sub FPreviousStackCardFinal_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
        End If
    End Sub

    Private Sub FPreviousStackCardFinal_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If IsFormBeingDragged Then
            Dim temp As Point = New Point()

            temp.X = Me.Location.X + (e.X - MouseDownX)
            temp.Y = Me.Location.Y + (e.Y - MouseDownY)
            Me.Location = temp
            temp = Nothing
        End If
    End Sub

    Private Sub FPreviousStackCardFinal_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
    End Sub

    Private Sub cmbInOut_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbInOut.SelectedIndexChanged
        If cmbInOut.Text = "IN" Then
            cmbTypeOfPurchase.Items.Clear()
            cmbTypeOfPurchase.Items.Add("PURCHASE ORDER")
            txtInvoice.Text = ""
            txt_Receiving_no.Text = ""
            txt_Ws_no.Text = "N/A"

        ElseIf cmbInOut.Text = "OUT" Then
            cmbTypeOfPurchase.Items.Clear()
            cmbTypeOfPurchase.Items.Add("WITHDRAWAL")
            txtInvoice.Text = "N/A"
            txt_Receiving_no.Text = "N/A"
            txt_Ws_no.Text = ""
        End If
        ' cmbTypeOfPurchase.Focus()
    End Sub

    Private Sub field_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRequestType.GotFocus, cmbInOut.GotFocus, cmbTypeOfPurchase.GotFocus, cmbTypeofCharge.GotFocus, txtChargeTo.GotFocus, cmbChargeTo.GotFocus, DTP_PreviousStockcard.GotFocus, txtRSno.GotFocus, txtItemDesc.GotFocus, txtInvoice.GotFocus, txt_Receiving_no.GotFocus, txt_Ws_no.GotFocus, txtIn_out.GotFocus, txtBalance.GotFocus, txtRemarks.GotFocus, cmbSubTypeofRequest.GotFocus
        sender.backcolor = Color.Yellow
    End Sub

    Private Sub txt_Receiving_no_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Receiving_no.KeyDown
        'If Not (e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 48 Or e.KeyValue = 49 Or e.KeyValue = 50 Or e.KeyValue = 51 Or e.KeyValue = 52 Or e.KeyValue = 53 Or e.KeyValue = 54 Or _
        '        e.KeyValue = 55 Or e.KeyValue = 56 Or e.KeyValue = 57 Or e.KeyValue = 96 Or e.KeyValue = 97 Or e.KeyValue = 98 Or e.KeyValue = 99 Or _
        '        e.KeyCode = Keys.OemPeriod Or _
        '       e.KeyValue = 100 Or e.KeyValue = 101 Or e.KeyValue = 102 Or e.KeyValue = 103 Or e.KeyValue = 104 Or e.KeyValue = 105 Or e.KeyValue = 37 Or e.KeyValue = 39) Then

        '    e.SuppressKeyPress() = True

        'End If
    End Sub

    Private Sub txt_Ws_no_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Ws_no.KeyDown
        'If Not (e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 48 Or e.KeyValue = 49 Or e.KeyValue = 50 Or e.KeyValue = 51 Or e.KeyValue = 52 Or e.KeyValue = 53 Or e.KeyValue = 54 Or _
        '        e.KeyValue = 55 Or e.KeyValue = 56 Or e.KeyValue = 57 Or e.KeyValue = 96 Or e.KeyValue = 97 Or e.KeyValue = 98 Or e.KeyValue = 99 Or _
        '        e.KeyCode = Keys.OemPeriod Or _
        '       e.KeyValue = 100 Or e.KeyValue = 101 Or e.KeyValue = 102 Or e.KeyValue = 103 Or e.KeyValue = 104 Or e.KeyValue = 105 Or e.KeyValue = 37 Or e.KeyValue = 39) Then

        '    e.SuppressKeyPress() = True

        'End If


    End Sub

    Private Sub txtIn_out_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIn_out.KeyDown

        Dim str As String = txtIn_out.Text

        Dim isExist As Boolean = str.Contains(".")
        Dim isExist2 As Boolean = str.Contains("-")

        If isExist Then
            If e.KeyCode = 190 Or e.KeyCode = 110 Then
                e.SuppressKeyPress = True
                Exit Sub
            End If
        End If

        If isExist2 Then
            If e.KeyCode = 189 Then
                e.SuppressKeyPress = True
                Exit Sub
            End If
        End If

        Select Case e.KeyCode
            Case 48 To 57 '0 to 9
                e.SuppressKeyPress = False
            Case 96 To 105
            Case 8 'backspace
                e.SuppressKeyPress = False
            Case 190 'period
                e.SuppressKeyPress = False
            Case 189 'negative
                e.SuppressKeyPress = False
            Case 110 'decimal point
                e.SuppressKeyPress = False
            Case Else
                e.SuppressKeyPress = True
        End Select

        'If Not (e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 48 Or e.KeyValue = 49 Or e.KeyValue = 50 Or e.KeyValue = 51 Or e.KeyValue = 52 Or e.KeyValue = 53 Or
        ' e.KeyValue = 54 Or e.KeyValue = 55 Or e.KeyValue = 56 Or e.KeyValue = 57 Or e.KeyValue = 96 Or e.KeyValue = 97 Or e.KeyValue = 98 Or e.KeyValue = 99 Or
        ' e.KeyCode = Keys.OemPeriod Or e.KeyValue = 100 Or e.KeyValue = 101 Or e.KeyValue = 102 Or e.KeyValue = 103 Or e.KeyValue = 104 Or e.KeyValue = 105 Or e.KeyValue = 37 Or
        ' e.KeyValue = 110 Or e.KeyValue = 39) Then

        '    e.SuppressKeyPress() = True
        'End If
    End Sub

    Private Sub txtBalance_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBalance.KeyDown
        'If Not (e.KeyValue = 8 Or
        ' e.KeyValue = 46 Or e.KeyValue = 48 Or e.KeyValue = 49 Or e.KeyValue = 50 Or e.KeyValue = 51 Or e.KeyValue = 52 Or e.KeyValue = 53 Or
        ' e.KeyValue = 54 Or e.KeyValue = 55 Or e.KeyValue = 56 Or e.KeyValue = 57 Or e.KeyValue = 96 Or e.KeyValue = 97 Or e.KeyValue = 98 Or
        ' e.KeyValue = 99 Or e.KeyCode = Keys.OemPeriod Or e.KeyValue = 100 Or e.KeyValue = 101 Or e.KeyValue = 102 Or e.KeyValue = 103 Or
        ' e.KeyValue = 104 Or e.KeyValue = 105 Or e.KeyValue = 37 Or e.KeyValue = 110 Or e.KeyValue = 39) Then

        '    e.SuppressKeyPress() = True
        'End If


        Dim str As String = txtBalance.Text

        Dim isExist As Boolean = str.Contains(".")
        Dim isExist2 As Boolean = str.Contains("-")

        If isExist Then
            If e.KeyCode = 190 Or e.KeyCode = 110 Then
                e.SuppressKeyPress = True
                Exit Sub
            End If
        End If

        If isExist2 Then
            If e.KeyCode = 189 Then
                e.SuppressKeyPress = True
                Exit Sub
            End If
        End If

        Select Case e.KeyCode
            Case 48 To 57 '0 to 9
                e.SuppressKeyPress = False
            Case 96 To 105
            Case 8 'backspace
                e.SuppressKeyPress = False
            Case 190 'period
                e.SuppressKeyPress = False
            Case 189 'negative
                e.SuppressKeyPress = False
            Case 110 'decimal point
                e.SuppressKeyPress = False
            Case Else
                e.SuppressKeyPress = True
        End Select
    End Sub

    Private Sub field_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRequestType.Leave, cmbInOut.Leave, cmbTypeOfPurchase.Leave, cmbTypeofCharge.Leave, txtChargeTo.Leave, cmbChargeTo.Leave, DTP_PreviousStockcard.Leave, txtRSno.Leave, txtItemDesc.Leave, txtInvoice.Leave, txt_Receiving_no.Leave, txt_Ws_no.Leave, txtIn_out.Leave, txtBalance.Leave, txtRemarks.Leave, cmbSubTypeofRequest.Leave
        sender.backcolor = Color.White
    End Sub

    Private Sub cmbRequestType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRequestType.SelectedIndexChanged
        tor_id_ToR = get_tor_id_TypeofRequest(cmbRequestType.Text)
        load_cmbSubTypeofRequest(tor_id_ToR)
    End Sub
    Public Sub load_set_type_of_charge(ByVal EXEMPTION As String, cmb As ComboBox)
        cmb.Items.Clear()

        Dim n As Integer
        Dim splitex(10) As String

        Dim s() As String
        s = EXEMPTION.Split("-")

        Try
            SQ.connection.Open()
            Dim query As String = "select * FROM dbType_of_charges"
            cmd = New SqlCommand(query, SQ.connection)
            dr = cmd.ExecuteReader

            While dr.Read
                splitex(n) = dr.Item("type_of_charges").ToString
                n = n + 1
                'MsgBox(splitex(n))
            End While
            dr.Close()

            For i As Integer = 0 To s.Count - 1
                For ii As Integer = 0 To splitex.Count - 1
                    If splitex(ii) = s(i) Then
                        splitex(ii) = ""

                    End If
                Next
            Next

            For ii As Integer = 0 To splitex.Count - 1
                If splitex(ii) = "" Then
                Else
                    cmb.Items.Add(splitex(ii))
                End If
            Next


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Sub load_equipment(ByVal x As Integer, cmb As ComboBox, txt As TextBox, groupbox As GroupBox)
        cmb.Items.Clear()

        Dim sqlcon As New SQLcon

        'sqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
        'sqlcon.sql_connect()

        'DTP_PSC.Width = txtSearch.Width
        'DTP_PSC.Location = New Point(txtSearch.Bounds.Left, txtSearch.Bounds.Top)
        'DTP_PSC.Parent = gboxSearch
        'DTP_PSC.BringToFront()
        'DTP_PSC.Visible = True

        cmb.Width = txt.Width
        cmb.Location = New Point(txt.Bounds.Left, txt.Bounds.Top)
        cmb.Parent = groupbox
        ' cmbChargeTo.Visible = True
        'txtChargeTo.Visible = False
        cmb.BringToFront()

        Try
            sqlcon.connection1.Open()
            If x = 0 Then
                publicquery_Psc = "SELECT * FROM dbequipment_list ORDER BY plate_no ASC"
            ElseIf x = 1 Then
                publicquery_Psc = "SELECT * FROM dbprojectdesc ORDER BY project_desc ASC"
            End If

            cmd = New SqlCommand(publicquery_Psc, sqlcon.connection1)
            dr = cmd.ExecuteReader

            While dr.Read
                If x = 0 Then
                    cmb.Items.Add(dr.Item("plate_no").ToString)
                ElseIf x = 1 Then
                    cmb.Items.Add(dr.Item("project_desc").ToString)
                End If
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection1.Close()
        End Try
    End Sub

    Private Sub cmbTypeofCharge_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTypeofCharge.SelectedIndexChanged
        Select Case cmbTypeofCharge.Text
            Case "EQUIPMENT"
                cmbChargeTo.Visible = True
                txtChargeTo.Visible = False

                load_equipment(0, cmbChargeTo, txtChargeTo, GroupBox1)
                cmbChargeTo.Width = cmbTypeOfPurchase.Width

            Case "PROJECT"
                cmbChargeTo.Visible = True
                txtChargeTo.Visible = False

                load_equipment(1, cmbChargeTo, txtChargeTo, GroupBox1)
                cmbChargeTo.Width = cmbTypeOfPurchase.Width

            Case "PERSONAL"
                cmbChargeTo.Visible = False
                txtChargeTo.Visible = True
                txtChargeTo.Clear()

            Case "WAREHOUSE"
                cmbChargeTo.Visible = False
                txtChargeTo.Visible = True
                txtChargeTo.Clear()

            Case "ADFIL"
                cmbChargeTo.Visible = False
                txtChargeTo.Visible = True
                txtChargeTo.Clear()

            Case "SUPPLIER"
                cmbChargeTo.Visible = False
                txtChargeTo.Visible = True
                txtChargeTo.Clear()

        End Select
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Select Case cmbTypeofCharge.Text
            Case "PERSONAL"
                charge_to_selection = 2
            Case "WAREHOUSE"
                charge_to_selection = 1
            Case "ADFIL"
                charge_to_selection = 2
                'Case "SUPPLIER"
                '    charge_to_selection = 4
        End Select


        With FCharge_To
            .cmbTypeofCharge.Items.Clear()
            .cmbTypeofCharge.Items.Add(cmbTypeofCharge.Text)
            .cmbTypeofCharge.SelectedIndex = 0
        End With

        target_location_project = "FPreviousStackCardFinal"
        charge_to_destination = 2

        FCharge_To.ShowDialog()
    End Sub

    Private Sub cmbTypeOfPurchase_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTypeOfPurchase.SelectedIndexChanged

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If btnSave.Text = "Save" Then
            If cmbRequestType.Text = "" Then
                MessageBox.Show("YOU FORGOT TO FILL UP TYPE OF REQUEST...  ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop)
                cmbRequestType.Focus()
            ElseIf cmbInOut.Text = "" Then
                MessageBox.Show("YOU FORGOT TO FILL UP TYPE OF CHARGES...  ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop)
                cmbInOut.Focus()
            ElseIf cmbTypeOfPurchase.Text = "" Then
                MessageBox.Show("YOU FORGOT TO FILL UP TYPE OF PURCHASING...  ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop)
                cmbTypeOfPurchase.Focus()
            ElseIf cmbTypeofCharge.Text = "" Then
                MessageBox.Show("YOU FORGOT TO FILL UP TYPE OF SUPPLIER/RECIPIENT...  ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop)
                cmbTypeofCharge.Focus()
            ElseIf txtChargeTo.Text = "" And (cmbTypeofCharge.Text = "PERSONAL" Or cmbTypeofCharge.Text = "WAREHOUSE" Or cmbTypeofCharge.Text = "ADFIL" Or cmbTypeofCharge.Text = "SUPPLIER") Then
                MessageBox.Show("YOU FORGOT TO FILL OF CHARGE TO...  ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop)
                txtChargeTo.Focus()
            ElseIf cmbChargeTo.Text = "" And (cmbTypeofCharge.Text = "EQUIPMENT" Or cmbTypeofCharge.Text = "PROJECT") Then
                MessageBox.Show("YOU FORGOT TO FILL UP CHARGE TO...  ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop)
                cmbChargeTo.Focus()
            ElseIf txtRSno.Text = "" Then
                MessageBox.Show("YOU FORGOT TO FILL UP RS_NO...  ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop)
                txtRSno.Focus()
            ElseIf txt_item_name.Text = "" Then
                MessageBox.Show("YOU FORGOT TO FILL UP ITEM DESCRIPTION...  ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop)
                txtItemDesc.Focus()
            ElseIf txtInvoice.Text = "" Then
                MessageBox.Show("YOU FORGOT TO FILL UP INVOICE NO...  ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop)
                txtInvoice.Focus()
            ElseIf txt_Receiving_no.Text = "" Then
                MessageBox.Show("YOU FORGOT TO FILL UP RECEIVING NO...  ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop)
                txt_Receiving_no.Focus()
            ElseIf txt_Ws_no.Text = "" Then
                MessageBox.Show("YOU FORGOT TO FILL UP WS_NO...  ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop)
                txt_Ws_no.Focus()
            ElseIf txtIn_out.Text = "" Then
                MessageBox.Show("YOU FORGOT TO FILL UP IN/OUT...  ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop)
                txtIn_out.Focus()
            ElseIf txtBalance.Text = "" Then
                MessageBox.Show("YOU FORGOT TO FILL UP BALANCE...  ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop)
                txtBalance.Focus()
            ElseIf txtRemarks.Text = "" Then
                MessageBox.Show("YOU FORGOT TO FILL UP REMARKS...  ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop)
                txtRemarks.Focus()
            Else
                If cCustomMsg.messageYesNo("Are you sure you want to save that data?", "SUPPLY INFO:") = True Then
                    Dim id As Integer = get_charges_id()

                    check_if_exist(id)
                    clear_PreviousStockCardFinal()
                    FPreviousStockCard.lvList.Enabled = True

                End If



            End If

            'insert_PreviousStockCard()
            'FPreviousStockCard.load_PreviousStockCard()
            'listfocus(FPreviousStockCard.lvList, n)

        ElseIf btnSave.Text = "Update" Then
            Dim ex = MessageBox.Show("Are you sure u want to update the selected item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If ex = MsgBoxResult.Yes Then
                Dim id As Integer = get_charges_id()

                UpdateRecord_PreviousStockCard(id)
                ' Me.Close()
                With FPreviousStockCard
                    .lvList.Items.Clear()
                    .cmbSearchByCategory.Text = "Rs_no"
                    .txtSearch.Text = txtRSno.Text
                    .btnSearch.PerformClick()
                    listfocus(.lvList, n)
                    ' MsgBox(n)
                End With
                clear_PreviousStockCardFinal()
                Me.Close()
                'FPreviousStockCard.load_PreviousStockCard()
                'listfocus(FPreviousStockCard.lvList, n)
                'btnSave.Text = "Save"
                '    btnCancel.Visible = False
                'ElseIf ex = MsgBoxResult.No Then
                '    btnCancel.PerformClick()
            Else
                Me.Close()
            End If

        End If

    End Sub

    Private Function get_charges_id() As Integer

        If cmbTypeofCharge.Text.ToUpper() = "PROJECT" Or
            cmbTypeofCharge.Text.ToUpper() = "EQUIPMENT" Then
            get_charges_id = cMyAllCharges _
          .Where(Function(x) x.category.ToUpper() = cmbTypeofCharge.Text.ToUpper() And x.charges_desc.ToLower() = cmbChargeTo.Text.ToLower()) _
          .Select(Function(x) x.charges_id) _
          .FirstOrDefault()

        Else
            get_charges_id = cMyAllCharges _
           .Where(Function(x) x.category.ToUpper() = cmbTypeofCharge.Text.ToUpper() And x.charges_desc.ToLower() = txtChargeTo.Text.ToLower()) _
           .Select(Function(x) x.charges_id) _
           .FirstOrDefault()
        End If

    End Function

    Private Sub cmbChargeTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbChargeTo.SelectedIndexChanged
        Dim sqlcon As New SQLcon

        If cmbTypeofCharge.Text = "EQUIPMENT" Then
            Try
                'sqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
                'sqlcon.sql_connect()

                sqlcon.connection1.Open()
                publicquery = "SELECT equipListID FROM dbequipment_list WHERE plate_no = '" & cmbChargeTo.Text & "'"
                cmd = New SqlCommand(publicquery, sqlcon.connection1)
                dr = cmd.ExecuteReader

                While dr.Read
                    charge_to_id = dr.Item(0).ToString
                End While
                dr.Close()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                sqlcon.connection1.Close()
            End Try

        ElseIf cmbTypeofCharge.Text = "PROJECT" Then
            Try
                'sqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
                'sqlcon.sql_connect()

                sqlcon.connection1.Open()
                publicquery = "SELECT proj_id FROM dbprojectdesc WHERE project_desc = '" & cmbChargeTo.Text & "'"
                cmd = New SqlCommand(publicquery, sqlcon.connection1)
                dr = cmd.ExecuteReader

                While dr.Read
                    charge_to_id = dr.Item(0).ToString
                End While
                dr.Close()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                sqlcon.connection1.Close()
            End Try
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'UpdateRecord_PreviousStockCard()
    End Sub

    Private Sub txtItemDesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemDesc.TextChanged
        'get_id_item_description()
    End Sub
    Public Sub get_id_item_description()
        Try
            Dim newsq As New SQLcon
            Dim newdr As SqlDataReader
            Dim newcmd As SqlCommand

            Try
                newsq.connection.Open()
                publicquery = "SELECT wh_id FROM dbwarehouse_items WHERE whItem = '" & txt_item_name.Text & "' and  whItemDesc = '" & txtItemDesc.Text & "'"
                newcmd = New SqlCommand(publicquery, newsq.connection)
                newdr = newcmd.ExecuteReader
                While newdr.Read
                    wh_id = newdr.Item("wh_id").ToString
                End While
                newdr.Close()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newsq.connection.Close()

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtInvoice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvoice.TextChanged

    End Sub

    Private Sub txt_Receiving_no_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Receiving_no.TextChanged

    End Sub

    Private Sub txt_Ws_no_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Ws_no.TextChanged

    End Sub

    Private Sub txtIn_out_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIn_out.TextChanged

    End Sub

    Private Sub txtBalance_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBalance.TextChanged

    End Sub

    Private Sub Button1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseDown
        Button1.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub Button1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseEnter
        Button1.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub Button1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave
        btnExit.BackgroundImage = My.Resources.close_button
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub pboxHeader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pboxHeader.Click

    End Sub

    Private Sub cmbSubTypeofRequest_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubTypeofRequest.SelectedIndexChanged


    End Sub
    Public Function get_tor_id_TypeofRequest(ByVal s As String) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim query As String
        Try
            newSQ.connection.Open()
            query = "SELECT tor_id FROM dbType_of_Request WHERE tor_desc = '" & s & "'"
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_tor_id_TypeofRequest = newDR.Item(0).ToString
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Public Sub load_cmbSubTypeofRequest(ByVal x As Integer)
        cmbSubTypeofRequest.Items.Clear()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim query As String

        Try
            newSQ.connection.Open()
            query = "SELECT tor_sub_desc FROM dbType_of_Request_sub WHERE tor_id = '" & x & "'"
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                cmbSubTypeofRequest.Items.Add(newDR.Item(0).ToString)
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs)
        load_set_type_of_charge("CASH", cmbTypeofCharge)


    End Sub

    Private Sub txtInvoice_KeyDown(sender As Object, e As KeyEventArgs) Handles txtInvoice.KeyDown

    End Sub
End Class