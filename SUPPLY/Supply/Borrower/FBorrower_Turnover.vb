Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FBorrower_Turnover
    Public SQ As New SQLcon
    Public CMD As SqlCommand
    Public DR As SqlDataReader
    Public txtbox As TextBox
    Public txtname1 As String


    Private Sub FBorrower_Turnover_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()

    End Sub

    Private Sub FBorrower_Turnover_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FRequestField.load_type_of_request("CASH", cmbTypeofCharge)
        FRequestField.load_type_of_request("CASH", cmbTurnoverLocation)


            Dim newSQ As New SQLcon
            Dim newCMD As SqlCommand
            Dim newDR As SqlDataReader
            Dim counter As Integer

        Try
            With FBorrowed_Item_Monitoring
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_facilities", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure
                newCMD.Parameters.AddWithValue("@n", 21)
                newCMD.Parameters.AddWithValue("@bs_no", lbl_bs_no.Text)
                newCMD.Parameters.AddWithValue("@bs_id", lbl_bs_id.Text)

                txtTypeOfMat.Text = get_brand_name(CInt(lbl_fi_id.Text))

                newDR = newCMD.ExecuteReader
                While newDR.Read
                    cmbTypeofCharge.Text = newDR.Item("type_of_turnover_from").ToString
                    lbl_bs_turnover_id.Text = newDR.Item("bs_turnover_id").ToString

                    Dim type As String = cmbTypeofCharge.Text
                    Dim type_of_turnover_id As Integer = CInt(newDR.Item("type_of_turnover_id").ToString)

                    Select Case type
                        Case "EQUIPMENT"
                            cmbReturnTo.Visible = True
                            cmbReturnTo.Text = .get_charges_name(type_of_turnover_id, type)

                        Case "PROJECT"
                            cmbReturnTo.Visible = True
                            cmbReturnTo.Text = .get_charges_name(type_of_turnover_id, type)

                        Case "WAREHOUSE"
                            txtReturnTo.Visible = True
                            txtReturnTo.Text = .get_charges_name(type_of_turnover_id, type)

                        Case "PERSONAL"
                            txtReturnTo.Visible = True
                            txtReturnTo.Text = .get_charges_name(type_of_turnover_id, type)

                        Case "CASH"
                            txtReturnTo.Visible = True
                            txtReturnTo.Text = .get_charges_name(type_of_turnover_id, type)

                        Case "ADFIL"
                            txtReturnTo.Visible = True
                            txtReturnTo.Text = .get_charges_name(type_of_turnover_id, type)

                    End Select

                    cmbTurnoverLocation.Text = newDR.Item("turnover_location").ToString

                    Dim type1 As String = cmbTurnoverLocation.Text
                    Dim turnoverloc_id As Integer = CInt(newDR.Item("turnover_location_id").ToString)

                    Select Case type1
                        Case "EQUIPMENT"
                            cmbTurnoverTo.Visible = True
                            cmbTurnoverTo.Text = .get_charges_name(turnoverloc_id, type1)

                        Case "PROJECT"
                            cmbTurnoverTo.Visible = True
                            cmbTurnoverTo.Text = .get_charges_name(turnoverloc_id, type1)

                        Case "WAREHOUSE"
                            txtTurnoverLocation.Visible = True
                            txtTurnoverLocation.Text = .get_charges_name(turnoverloc_id, type1)

                        Case "PERSONAL"
                            txtTurnoverLocation.Visible = True
                            txtTurnoverLocation.Text = .get_charges_name(turnoverloc_id, type1)

                        Case "CASH"
                            txtTurnoverLocation.Visible = True
                            txtTurnoverLocation.Text = .get_charges_name(turnoverloc_id, type1)

                        Case "ADFIL"
                            txtTurnoverLocation.Visible = True
                            txtTurnoverLocation.Text = .get_charges_name(turnoverloc_id, type1)

                    End Select

                    txtQty.Text = newDR.Item("qty").ToString
                    cmbCondition.Text = newDR.Item("condition_of_item").ToString
                    txtReceiver.Text = newDR.Item("receiver").ToString
                    dtpdateturnover.Text = Date.Parse(newDR.Item("date_turnover").ToString)
                    txtturnoverby.Text = newDR.Item("turnover_by").ToString
                    dtpDateNoted.Text = newDR.Item("date_noted").ToString
                    txtNotedBy.Text = newDR.Item("noted_by").ToString

                    counter += 1

                End While

                newDR.Close()
            End With
            
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

            If counter = 0 Then
                btnSave.Text = "Save"
            Else
                btnSave.Text = "Update"
            End If
        End Try

        ''--COMMONHANDLER--

        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is Button Then
                AddHandler ctrl.GotFocus, AddressOf commonhadler
            ElseIf TypeOf ctrl Is TextBox Then
                AddHandler ctrl.GotFocus, AddressOf commonhadler
            ElseIf TypeOf ctrl Is ComboBox Then
                AddHandler ctrl.GotFocus, AddressOf commonhadler
            ElseIf TypeOf ctrl Is DateTimePicker Then
                AddHandler ctrl.GotFocus, AddressOf commonhadler
            End If
        Next

    End Sub

    Private Sub cmbTypeofCharge_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTypeofCharge.SelectedIndexChanged


        Select Case cmbTypeofCharge.Text
            Case "ADFIL"
                cmbReturnTo.Visible = False
                txtReturnTo.Visible = True

                txtReturnTo.Clear()
                charge_to_id = 0

            Case "PROJECT"

                cmbReturnTo.Visible = True
                txtReturnTo.Visible = False

                cmbReturnTo.Location = New Point(txtReturnTo.Bounds.Left, txtReturnTo.Bounds.Top)

                FRequestField.load_equipment(1, cmbReturnTo)

                txtReturnTo.Clear()
                charge_to_id = 0

            Case "EQUIPMENT"
                cmbReturnTo.Visible = True
                txtReturnTo.Visible = False

                cmbReturnTo.Location = New Point(txtReturnTo.Bounds.Left, txtReturnTo.Bounds.Top)

                FRequestField.load_equipment(0, cmbReturnTo)

                txtReturnTo.Clear()
                charge_to_id = 0

            Case "PERSONAL"
                cmbReturnTo.Visible = False
                txtReturnTo.Visible = True

                txtReturnTo.Clear()
                charge_to_id = 0

            Case "WAREHOUSE"
                cmbReturnTo.Visible = False
                txtReturnTo.Visible = True

                txtReturnTo.Clear()
                charge_to_id = 0
            Case "CASH"
                cmbReturnTo.Visible = False
                txtReturnTo.Visible = True

                txtReturnTo.Clear()
                charge_to_id = 0

        End Select
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Select Case cmbTypeofCharge.Text

            Case "ADFIL"
                charge_to_selection = 2
            Case "WAREHOUSE"
                charge_to_selection = 1
            Case "PERSONAL"
                charge_to_selection = 2
            Case "CASH"
                charge_to_selection = 2

        End Select

        charge_to_destination = 8
        FCharge_To.ShowDialog()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Select Case cmbTurnoverLocation.Text

            Case "ADFIL"
                charge_to_selection = 2
            Case "WAREHOUSE"
                charge_to_selection = 1
            Case "PERSONAL"
                charge_to_selection = 2
            Case "CASH"
                charge_to_selection = 2

        End Select

        charge_to_destination = 9
        FCharge_To.ShowDialog()
    End Sub

    Private Sub cmbTurnoverLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTurnoverLocation.SelectedIndexChanged

        Select Case cmbTurnoverLocation.Text
            Case "ADFIL"
                cmbTurnoverTo.Visible = False
                txtTurnoverLocation.Visible = True

                txtTurnoverLocation.Clear()
                return_to_id1 = 0
                btn_picbox2.Enabled = True
            Case "PROJECT"

                cmbTurnoverTo.Visible = True
                txtTurnoverLocation.Visible = False

                cmbTurnoverTo.Location = New Point(txtTurnoverLocation.Bounds.Left, txtTurnoverLocation.Bounds.Top)

                FRequestField.load_equipment(1, cmbTurnoverTo)

                txtTurnoverLocation.Clear()
                return_to_id1 = 0
                btn_picbox2.Enabled = False
            Case "EQUIPMENT"
                cmbTurnoverTo.Visible = True
                txtTurnoverLocation.Visible = False

                cmbTurnoverTo.Location = New Point(txtTurnoverLocation.Bounds.Left, txtTurnoverLocation.Bounds.Top)

                FRequestField.load_equipment(0, cmbTurnoverTo)

                txtTurnoverLocation.Clear()
                return_to_id1 = 0
                btn_picbox2.Enabled = False

            Case "PERSONAL"
                cmbTurnoverTo.Visible = False
                txtTurnoverLocation.Visible = True

                txtTurnoverLocation.Clear()
                return_to_id1 = 0
                btn_picbox2.Enabled = True

            Case "WAREHOUSE"
                cmbTurnoverTo.Visible = False
                txtTurnoverLocation.Visible = True

                txtTurnoverLocation.Clear()
                return_to_id1 = 0
                btn_picbox2.Enabled = True

            Case "CASH"
                cmbTurnoverTo.Visible = False
                txtTurnoverLocation.Visible = True

                txtTurnoverLocation.Clear()
                return_to_id1 = 0
                btn_picbox2.Enabled = True

        End Select
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If btnSave.Text = "Save" Then

            Dim bs_id, charge_id As Integer
            Dim type_name As String

            bs_id = CInt(FBorrowed_Item_Monitoring.lvlBorrowerList.SelectedItems(0).Text)

            save_update(0)
            'FBorrowed_Item_Monitoring.borrower_slip_list(0)

            bs_id = CInt(FBorrowed_Item_Monitoring.lvlBorrowerList.SelectedItems(0).Text)

            For Each row As ListViewItem In lvlList.Items

                charge_id = CInt(row.Text)
                type_name = row.SubItems(2).Text
                FCreateCharges.insert_into_dbborrower_charges(bs_id, charge_id, type_name, "Turnover")

            Next

            FBorrowed_Item_Monitoring.btnSearch.PerformClick()
            listfocus(FBorrowed_Item_Monitoring.lvlBorrowerList, bs_id)

            'With FBorrowed_Item_Monitoring
            '    Dim fi_id As Integer = CInt(.lvList.SelectedItems(0).Text)
            '    FBorrowed_Item_Monitoring.LOAD_facilities_item()
            '    listfocus(.lvList, fi_id)
            'End With

            FBorrowed_Item_Monitoring.lvlist_loader()
            FBorrowed_Item_Monitoring.btnSearch.PerformClick()

            Me.Dispose()
        ElseIf btnSave.Text = "Update" Then
            save_update(1)
            'FBorrowed_Item_Monitoring.borrower_slip_list(0)

            Dim bs_id, charge_id As Integer
            Dim type_name As String

            bs_id = CInt(FBorrowed_Item_Monitoring.lvlBorrowerList.SelectedItems(0).Text)

            For Each row As ListViewItem In lvlList.Items

                charge_id = CInt(row.Text)
                type_name = row.SubItems(2).Text
                FCreateCharges.insert_into_dbborrower_charges(bs_id, charge_id, type_name, "Turnover")

            Next

            FBorrowed_Item_Monitoring.btnSearch.PerformClick()
            listfocus(FBorrowed_Item_Monitoring.lvlBorrowerList, bs_id)

            'With FBorrowed_Item_Monitoring
            '    Dim fi_id As Integer = CInt(.lvList.SelectedItems(0).Text)
            '    FBorrowed_Item_Monitoring.LOAD_facilities_item()
            '    listfocus(.lvList, fi_id)
            'End With

            FBorrowed_Item_Monitoring.lvlist_loader()
            FBorrowed_Item_Monitoring.btnSearch.PerformClick()
            Me.Dispose()
        End If


    End Sub
  

    Private Sub save_update(ByVal trigger As Integer)

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand


        'og wala ni, pag update, mwala ang id sa turnover location
        If cmbTurnoverLocation.Text = "ADFIL" Then
            return_to_id1 = get_id("dbCharge_to", "charge_to", txtTurnoverLocation.Text, 0)

        ElseIf cmbTurnoverLocation.Text = "WAREHOUSE" Then
            return_to_id1 = get_id("dbwh_area", "wh_area", txtTurnoverLocation.Text, 0)

        End If

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_facilities", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            If trigger = 0 Then
                newCMD.Parameters.AddWithValue("@n", 20)
            ElseIf trigger = 1 Then
                newCMD.Parameters.AddWithValue("@n", 22)
                newCMD.Parameters.AddWithValue("@bs_turnover_id", CInt(lbl_bs_turnover_id.Text))
            End If

            newCMD.Parameters.AddWithValue("@type_of_turnover_from", cmbTypeofCharge.Text)
            newCMD.Parameters.AddWithValue("@type_of_turnover_id", return_to_id)
            newCMD.Parameters.AddWithValue("@fi_id", CInt(FBorrowed_Item_Monitoring.lbl_fi_id.Text))
            newCMD.Parameters.AddWithValue("@qty", txtQty.Text)
            newCMD.Parameters.AddWithValue("@condition_of_item", cmbCondition.Text)
            newCMD.Parameters.AddWithValue("@turnover_location", cmbTurnoverLocation.Text)
            newCMD.Parameters.AddWithValue("@turnover_location_id", return_to_id1)
            newCMD.Parameters.AddWithValue("@receiver", txtReceiver.Text)
            newCMD.Parameters.AddWithValue("@date_turnover", Date.Parse(dtpDateNoted.Text))
            newCMD.Parameters.AddWithValue("@date_noted", Date.Parse(dtpDateNoted.Text))
            newCMD.Parameters.AddWithValue("@noted_by", txtNotedBy.Text)
            newCMD.Parameters.AddWithValue("@turnover_by", txtturnoverby.Text)
            newCMD.Parameters.AddWithValue("@bs_no", FBorrowed_Item_Monitoring.lvlBorrowerList.SelectedItems(0).SubItems(1).Text)
            newCMD.Parameters.AddWithValue("@bs_id", CInt(lbl_bs_id.Text))

            If trigger = 0 Then
                Dim save As Integer
                save = newCMD.ExecuteScalar

                If save > 0 Then
                    MessageBox.Show("Successfully Saved...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            ElseIf trigger = 1 Then
                newCMD.ExecuteNonQuery()
                MessageBox.Show("Successfully Updated...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub cmbReturnTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbReturnTo.SelectedIndexChanged

        return_to_id = charge_id(cmbTypeofCharge.Text, cmbReturnTo.Text)
       
    End Sub
    Public Function charge_id(ByVal typeofcharge As String, ByVal value As String) As Integer
        Dim sqlcon As New SQLcon

        If typeofcharge = "EQUIPMENT" Then
            Try
                'sqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
                'sqlcon.sql_connect()

                sqlcon.connection1.Open()

                publicquery = "SELECT equipListID FROM dbequipment_list WHERE plate_no = '" & value & "'"
                CMD = New SqlCommand(publicquery, sqlcon.connection1) : DR = CMD.ExecuteReader
                While DR.Read : charge_id = DR.Item(0).ToString : End While
                DR.Close()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                sqlcon.connection1.Close()
            End Try
        ElseIf typeofcharge = "PROJECT" Then
            Try
                'sqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
                'sqlcon.sql_connect()

                sqlcon.connection1.Open()

                publicquery = "SELECT proj_id FROM dbprojectdesc WHERE project_desc = '" & value & "'"

                CMD = New SqlCommand(publicquery, sqlcon.connection1) : DR = CMD.ExecuteReader
                While DR.Read : charge_id = DR.Item(0).ToString : End While
                DR.Close()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                sqlcon.connection1.Close()
            End Try
        End If
    End Function
    Private Sub cmbTurnoverTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTurnoverTo.SelectedIndexChanged

        return_to_id1 = charge_id(cmbTurnoverLocation.Text, cmbTurnoverTo.Text)

    End Sub

    Private Sub txtTurnoverLocation_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTurnoverLocation.TextChanged

    End Sub

    Private Sub dtpdateturnover_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpdateturnover.ValueChanged

    End Sub

    Private Sub btn_picbox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_picbox1.Click
        'Select Case cmbTypeofCharge.Text

        '    Case "ADFIL"
        '        charge_to_selection = 2
        '    Case "WAREHOUSE"
        '        charge_to_selection = 1
        '    Case "PERSONAL"
        '        charge_to_selection = 2
        '    Case "CASH"
        '        charge_to_selection = 2

        'End Select

        'charge_to_destination = 8
        'FCharge_To.ShowDialog()
        FBorrowed_Item_Monitoring.load_intended_charges_from_rs()
        FCreateCharges.lbl_bs_status.Text = "Turnover"
        FCreateCharges.ShowDialog()

        'FBorrowerMultipleCharges.ShowDialog()

    End Sub

    Private Sub btn_picbox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_picbox2.Click
        Select Case cmbTurnoverLocation.Text

            Case "ADFIL"
                charge_to_selection = 2
            Case "WAREHOUSE"
                charge_to_selection = 1
            Case "PERSONAL"
                charge_to_selection = 2
            Case "CASH"
                charge_to_selection = 2

        End Select

        charge_to_destination = 9
        FCharge_To.ShowDialog()
    End Sub

    Private Sub ListBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick
        If ListBox1.SelectedItems.Count > 0 Then
            For Each ctr As Control In Me.Controls
                If ctr.Name = txtname1 Then
                    ctr.Text = ListBox1.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next
            ListBox1.Visible = False
        End If
    End Sub

    Private Sub ListBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ListBox1.SelectedItems.Count > 0 Then
                For Each ctr As Control In Me.Controls
                    If ctr.Name = txtname1 Then
                        ctr.Text = ListBox1.SelectedItem.ToString
                        ctr.Focus()
                    End If
                Next
                ListBox1.Visible = False
            End If
            'ElseIf e.KeyCode = Keys.Up Then
            '    If ListBox1.SelectedIndex = 0 Then
            '        Dim f As Integer
            '        f = 1

            '        If f = 1 Then
            '            ListBox1.SelectedIndex = 0
            '            pub_textbox.Focus()
            '        End If
            '        'pub_textbox.Focus()
            '    End If
        End If
    End Sub
    Private Sub ListBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox1.KeyUp
        If e.KeyCode = Keys.Up Then
            If ListBox1.SelectedIndex = 0 Then
                txtbox.Focus()
            End If
        End If
    End Sub

    Private Sub txtbox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTypeOfMat.GotFocus, cmbTypeofCharge.GotFocus, cmbReturnTo.GotFocus, txtReturnTo.GotFocus, txtQty.GotFocus, cmbCondition.GotFocus, cmbTurnoverLocation.GotFocus, cmbTurnoverTo.GotFocus, txtTurnoverLocation.GotFocus, txtNotedBy.GotFocus, txtReceiver.GotFocus, txtturnoverby.GotFocus, dtpdateturnover.GotFocus, dtpDateNoted.GotFocus
        sender.backcolor = Color.Yellow

        If txtReceiver.Focused Then
            txtname1 = txtReceiver.Name
            txtReceiver.SelectAll()
        ElseIf txtturnoverby.Focused Then
            txtname1 = txtturnoverby.Name
            txtturnoverby.SelectAll()
        ElseIf txtNotedBy.Focused Then
            txtname1 = txtNotedBy.Name
            txtNotedBy.SelectAll()
        End If

    End Sub
    Private Sub txtbox_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTypeOfMat.Leave, cmbTypeofCharge.Leave, cmbReturnTo.Leave, txtReturnTo.Leave, txtQty.Leave, cmbCondition.Leave, cmbTurnoverLocation.Leave, cmbTurnoverTo.Leave, txtturnoverby.Leave, txtReceiver.Leave, dtpdateturnover.Leave, txtReceiver.Leave, dtpDateNoted.Leave, txtNotedBy.Leave
        sender.backcolor = Color.White
    End Sub

    Private Sub txtbox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNotedBy.KeyDown, txtReceiver.KeyDown, txtturnoverby.KeyDown
        ' pub_textbox = sender

        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
            If ListBox1.Visible = True Then
                If ListBox1.Items.Count > 0 Then
                    ListBox1.Focus()
                    ListBox1.SelectedIndex = 0
                End If
            End If
            'ListBox1.Focus()
        End If
    End Sub

    Private Sub txtbox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReceiver.TextChanged, txtturnoverby.TextChanged, txtNotedBy.TextChanged
        'Dim txtbox As TextBox = sender
        txtbox = sender
        Dim n As Integer

        If txtbox.Name = "txtReceiver" Then : n = 1 : ElseIf txtbox.Name = "txtturnoverby" Then : n = 2 : ElseIf txtbox.Name = "txtNotedBy" Then : n = 3 : End If

        Try
            If txtbox.Text = "" Then
                ListBox1.Location = New System.Drawing.Point(txtbox.Location.X, txtbox.Location.Y + txtbox.Height)
                ListBox1.Visible = False
            Else
                With ListBox1
                    .Location = New System.Drawing.Point(txtbox.Location.X, txtbox.Location.Y + txtbox.Height)
                    .Visible = True
                    .Items.Clear()
                    .Width = txtbox.Width
                End With

                get_textbox_value(n, txtbox)

            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub get_textbox_value(ByVal n As Integer, ByVal txtbox As TextBox)
        Dim newsqlconn As New SQLcon
        Dim counter As Integer

        Try
            newsqlconn.connection.Open()
            Dim newsqlcomm As New SqlCommand
            Dim newdr As SqlDataReader

            newsqlcomm.Connection = newsqlconn.connection
            newsqlcomm.CommandText = "sp_borrower_turnover"
            newsqlcomm.CommandType = CommandType.StoredProcedure

            If n = 1 Then
                newsqlcomm.Parameters.AddWithValue("@receiver", txtbox.Text)
                newsqlcomm.Parameters.AddWithValue("@n", 1)
            ElseIf n = 2 Then
                newsqlcomm.Parameters.AddWithValue("@turnover_by", txtbox.Text)
                newsqlcomm.Parameters.AddWithValue("@n", 2)
            ElseIf n = 3 Then
                newsqlcomm.Parameters.AddWithValue("@receiver", txtbox.Text)
                newsqlcomm.Parameters.AddWithValue("@n", 3)
            End If

            newdr = newsqlcomm.ExecuteReader

            While newdr.Read
                If n = 1 Then
                    ListBox1.Items.Add(newdr.Item(0).ToString)
                    counter += 1
                ElseIf n = 2 Then
                    ListBox1.Items.Add(newdr.Item(0).ToString)
                    counter += 1
                ElseIf n = 3 Then
                    ListBox1.Items.Add(newdr.Item(0).ToString)
                    counter += 1
                End If
            End While
            newdr.Close()

            If counter > 0 Then
                ListBox1.Visible = True
            Else
                ListBox1.Visible = False
            End If


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlconn.connection.Close()
        End Try
    End Sub
    Private Sub commonhadler(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ListBox1.Visible = True Then
            ListBox1.Visible = False
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub
End Class