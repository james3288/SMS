Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FMaterial_Turnover_Fields
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Dim tor_sub_id As Integer
    Dim tor_id As Integer
    Dim inout_id As Integer
    Public txtname As String
    Dim m As Integer

    Private Sub FMaterial_Turnover_Fields_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If MessageBox.Show("Are you sure you want to Cancel?", "SUPPLY INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                Me.Close()
                Me.Dispose()
            Else
                Return
            End If
        End If
    End Sub

    Private Sub FMaterial_Turnover_Fields_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lbl_save.Parent = btn_save
        lbl_save.BringToFront()
        lbl_save.Location = New Point(216, 10)

        FRequestField.load_type_of_request_and_sub(1, cmbRequestType, tor_id)

        If lbl_save.Text = "Update" Then
            FMaterials_ToolsTurnOverReport.Edit_turnover_materials()

        ElseIf lbl_save.Text = "Save" Then

        End If

        lbox_list.Visible = False

    End Sub

    Private Sub cmbTOR_sub_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTOR_sub.SelectedIndexChanged
        tor_sub_id = get_id("dbType_of_Request_sub", "tor_sub_desc", cmbTOR_sub.Text, 0)
    End Sub

    Private Sub cmbRequestType_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRequestType.Leave, cmbTOR_sub.Leave, cmbInOut.Leave, cmb_projectcodeName.Leave, cmbTurnoverFrom.Leave, cmb_selectItem.Leave, cmbTypeofMaterial.Leave _
        , cmb_materialDesc.Leave, txtconditionofItem.Leave, cmbTurnoverToType.Leave, cmb_turnOverLocation.Leave, cmb_specLocation.Leave, txtReceiver.Leave, txtTurnOverBy.Leave, txtNotedby.Leave, txtQuantity.Leave, txtUnit.Leave _
        , txtRemarks.Leave
        sender.backcolor = Color.White
    End Sub

    Private Sub cmbRequestType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRequestType.SelectedIndexChanged
        tor_id = get_id("dbType_of_Request", "tor_desc", cmbRequestType.Text, 0)
        FRequestField.load_type_of_request_and_sub(2, cmbTOR_sub, tor_id)
    End Sub

    Private Sub cmbInOut_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbInOut.SelectedIndexChanged
        inout_id = get_id("dbinout", "in_out_desc", cmbInOut.Text, 0)

    End Sub

    Private Sub cmb_projectcodeName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_projectcodeName.SelectedIndexChanged
        cmbTurnoverFrom.Items.Clear()
        FProjectIncharge.load_all(cmbTurnoverFrom, 1, cmb_projectcodeName.Text)
    End Sub

    Private Sub cmb_selectItem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_selectItem.SelectedIndexChanged
        With FMaterials_ToolsTurnOverTextFields
            If cmb_selectItem.Text = "Warehouse Item" Then

                .get_whItem(0, cmbTypeofMaterial)
                'cmb_materialDesc.DropDownStyle = ComboBoxStyle.DropDownList
            Else
                .get_whItem(1, cmbTypeofMaterial)
                'cmb_materialDesc.DropDownStyle = ComboBoxStyle.DropDown

            End If
        End With

    End Sub

    Private Sub cmbTypeofMaterial_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTypeofMaterial.SelectedIndexChanged
        With FMaterials_ToolsTurnOverTextFields

            If cmb_selectItem.Text = "Warehouse Item" Then
                .get_WhItemDesc(cmbTypeofMaterial.Text, 0, cmb_materialDesc)
            Else
                .get_WhItemDesc(cmbTypeofMaterial.Text, 1, cmb_materialDesc)
            End If
        End With
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTurnoverToType.SelectedIndexChanged
        cmb_turnOverLocation.Items.Clear()
        FProjectIncharge.load_all(cmb_turnOverLocation, 1, cmbTurnoverToType.Text)
    End Sub

    Private Sub cmb_turnOverLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_turnOverLocation.SelectedIndexChanged
        FMaterials_ToolsTurnOverTextFields.get_specLocation(cmb_turnOverLocation.Text, cmb_specLocation)
        cmb_specLocation.Items.Add("N/A")
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        PnlAddTypeofMaterials.Location = New Point(75, 223)
        PnlAddTypeofMaterials.Visible = True
        m = 2
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlbtnclose.Click
        PnlAddTypeofMaterials.Hide()
        For Each ctr As Control In Me.Controls
            If ctr.Name = "PnlAddTypeofMaterials" Then
                PnlAddTypeofMaterials.Visible = False
            Else
                ctr.Enabled = True
            End If
        Next
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If m = 1 Then
            cmbTypeofMaterial.Items.Add(UCase(txtAdditionalMaterialDesc.Text))
            cmbTypeofMaterial.Sorted = True
        ElseIf m = 2 Then
            cmb_materialDesc.Items.Add(UCase(txtAdditionalMaterialDesc.Text))
            cmb_materialDesc.Sorted = True

        End If

        For Each ctr As Control In Me.Controls
            If ctr.Name = "PnlAddTypeofMaterials" Then
                PnlAddTypeofMaterials.Visible = False
            Else
                ctr.Enabled = True
            End If
        Next

    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click

        save_update()

    End Sub

    Public Sub save_update()
        If cmbRequestType.Text = "" Or cmbTOR_sub.Text = "" Or cmbInOut.Text = "" Or cmb_projectcodeName.Text = "" Or cmbTurnoverFrom.Text = "" Or cmb_selectItem.Text = "" Or cmbTypeofMaterial.Text = "" _
         Or cmb_materialDesc.Text = "" Or txtconditionofItem.Text = "" Or cmbTurnoverToType.Text = "" Or cmb_turnOverLocation.Text = "" Or cmb_specLocation.Text = "" Or txtReceiver.Text = "" Or txtTurnOverBy.Text = "" _
         Or txtNotedby.Text = "" Or txtQuantity.Text = "" Or txtUnit.Text = "" Or txtRemarks.Text = "" Then
            MessageBox.Show("Pls fill up all fields!. ", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim wh_id_for_turnover_items As Integer = dbwarehouse_items_for_turnover()
            Dim turnover_from_id As Integer = get_id_from_this_parameter(cmb_projectcodeName.Text, cmbTurnoverFrom.Text)
            Dim turnover_to_id As Integer = get_id_from_this_parameter(cmbTurnoverToType.Text, cmb_turnOverLocation.Text)

            tor_sub_id = get_id("dbType_of_Request_sub", "tor_sub_desc", cmbTOR_sub.Text, 0)
            inout_id = get_id("dbinout", "in_out_desc", cmbInOut.Text, 0)
            Dim tsp_id As Integer = get_id("dbtor_sub_property", "tor_sub_id^inout_id", tor_sub_id & "^" & inout_id, 3)

            Dim newSQ As New SQLcon
            Dim newCMD As SqlCommand
            Dim a(10) As String

            Try
                newSQ.connection.Open()

                newCMD = New SqlCommand("proc_turnover_items_to_wh", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure
                newCMD.Parameters.AddWithValue("@tsp_id", tsp_id)
                newCMD.Parameters.AddWithValue("@turnover_from_type", cmb_projectcodeName.Text)
                newCMD.Parameters.AddWithValue("@turnover_from_id", turnover_from_id)
                newCMD.Parameters.AddWithValue("@wh_id", wh_id_for_turnover_items)
                newCMD.Parameters.AddWithValue("@condition_of_item", txtconditionofItem.Text)
                newCMD.Parameters.AddWithValue("@turnover_to_type", cmbTurnoverToType.Text)
                newCMD.Parameters.AddWithValue("@turnover_to_id", turnover_to_id)
                newCMD.Parameters.AddWithValue("@receiver", txtReceiver.Text)
                newCMD.Parameters.AddWithValue("@turnover_by", txtTurnOverBy.Text)
                newCMD.Parameters.AddWithValue("@turnover_date", Date.Parse(DTP_TurnedOverdate.Text))
                newCMD.Parameters.AddWithValue("@noted_by", txtNotedby.Text)
                newCMD.Parameters.AddWithValue("@noted_date", Date.Parse(DTP_NotedDate.Text))
                newCMD.Parameters.AddWithValue("@qty", CDbl(txtQuantity.Text))
                newCMD.Parameters.AddWithValue("@unit", txtUnit.Text)
                newCMD.Parameters.AddWithValue("@remarks", txtRemarks.Text)
                newCMD.Parameters.AddWithValue("@what_wh_area", cmb_selectItem.Text)

                If lbl_save.Text = "Save" Then
                    newCMD.Parameters.AddWithValue("@n", 2)
                    Dim turnover_item_id As Integer = newCMD.ExecuteScalar()

                    If turnover_item_id > 0 Then
                        MessageBox.Show("Successfully Saved...", "Supply INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Dispose()

                    Else
                        MessageBox.Show("I think there is some errors in your query..", "Supply INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    FMaterials_ToolsTurnOverReport.btnSearch.PerformClick()
                    listfocus(FMaterials_ToolsTurnOverReport.lvlMaterialToolsList, turnover_item_id)
                Else

                    newCMD.Parameters.AddWithValue("@n", 6)
                    newCMD.Parameters.AddWithValue("@turnover_item_id", FMaterials_ToolsTurnOverReport.lvlMaterialToolsList.SelectedItems(0).Text)
                    newCMD.ExecuteNonQuery()

                    MessageBox.Show("Successfully Updated...", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Dispose()

                    Dim turnover_item_id As Integer = FMaterials_ToolsTurnOverReport.lvlMaterialToolsList.SelectedItems(0).Text

                    FMaterials_ToolsTurnOverReport.btnSearch.PerformClick()
                    listfocus(FMaterials_ToolsTurnOverReport.lvlMaterialToolsList, turnover_item_id)

                End If

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try
        End If
    End Sub

    Public Function get_id_from_this_parameter(ByVal type As String, ByVal value As String) As Integer

        Select Case type
            Case "WAREHOUSE"
                get_id_from_this_parameter = get_id("dbwh_area", "wh_area", value, 0)
            Case "PROJECT"
                get_id_from_this_parameter = FMaterials_ToolsTurnOverTextFields.get_project_id(value)
            Case "MAINOFFICE"
                get_id_from_this_parameter = get_id("dbCharge_to", "charge_to", value, 0)
            Case "EQUIPMENT"
                get_id_from_this_parameter = FMaterials_ToolsTurnOverTextFields.get_equipment_id(value)
            Case "PERSONAL"
                get_id_from_this_parameter = get_id("dbCharge_to", "charge_to", value, 0)
        End Select

    End Function

    Private Function dbwarehouse_items_for_turnover() As Integer

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try

            Dim a(10) As String
            Dim wh_area_id As Integer = get_id_from_this_parameter(cmbTurnoverToType.Text, cmb_turnOverLocation.Text)

            Dim check_item_if_exist As Integer = check_if_exist("dbwarehouse_items_for_turnover", "item_name^item_desc", cmbTypeofMaterial.Text & "^" & cmb_materialDesc.Text, 3)

            If check_item_if_exist > 0 Then
                dbwarehouse_items_for_turnover = get_id("dbwarehouse_items_for_turnover", "item_name^item_desc", cmbTypeofMaterial.Text & "^" & cmb_materialDesc.Text, 2)
                GoTo proceedhere
            End If

            newSQ.connection.Open()

            newCMD = New SqlCommand("proc_turnover_items_to_wh", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 1)
            newCMD.Parameters.AddWithValue("@item_name", cmbTypeofMaterial.Text)
            newCMD.Parameters.AddWithValue("@item_desc", cmb_materialDesc.Text)
            newCMD.Parameters.AddWithValue("@wh_area_type", cmbTurnoverToType.Text)
            newCMD.Parameters.AddWithValue("@wh_area_id", wh_area_id)
            newCMD.Parameters.AddWithValue("@spec_loc", cmb_specLocation.Text)

            dbwarehouse_items_for_turnover = newCMD.ExecuteScalar()

proceedhere:

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        PnlAddTypeofMaterials.Location = New Point(75, 223)

        m = 1

        For Each ctr As Control In Me.Controls
            If ctr.Name = "PnlAddTypeofMaterials" Then
                PnlAddTypeofMaterials.Visible = True
            Else
                ctr.Enabled = False
            End If
        Next

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
        Me.Dispose()
    End Sub
#Region "DragForm/GUI"
    Private Sub FMaterial_Turnover_Fields_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown, PictureBox5.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub FMaterial_Turnover_Fields_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove, PictureBox5.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub FMaterial_Turnover_Fields_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp, PictureBox5.MouseUp
        drag = False
    End Sub

    Private Sub btnExit_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnExit.MouseDown
        btnExit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.MouseEnter
        btnExit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.MouseLeave
        btnExit.BackgroundImage = My.Resources.close_button
    End Sub

    Private Sub txtQuantity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQuantity.KeyDown
        If Not (e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 48 Or e.KeyValue = 49 Or e.KeyValue = 50 Or e.KeyValue = 51 Or e.KeyValue = 52 Or e.KeyValue = 53 Or e.KeyValue = 54 Or _
         e.KeyValue = 55 Or e.KeyValue = 56 Or e.KeyValue = 57 Or e.KeyValue = 96 Or e.KeyValue = 97 Or e.KeyValue = 98 Or e.KeyValue = 99 Or _
                 e.KeyCode = Keys.OemPeriod Or _
                e.KeyValue = 100 Or e.KeyValue = 101 Or e.KeyValue = 102 Or e.KeyValue = 103 Or e.KeyValue = 104 Or e.KeyValue = 105 Or e.KeyValue = 37 Or e.KeyValue = 39) Then
            e.SuppressKeyPress() = True
        End If
    End Sub
#End Region

    Private Sub txtReceiver_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReceiver.GotFocus, txtTurnOverBy.GotFocus, txtNotedby.GotFocus, cmbRequestType.GotFocus, cmbTOR_sub.GotFocus, cmbInOut.GotFocus, cmb_projectcodeName.GotFocus, _
        cmbTurnoverFrom.GotFocus, cmb_selectItem.GotFocus, cmbTypeofMaterial.GotFocus, cmb_materialDesc.GotFocus, txtconditionofItem.GotFocus, cmbTurnoverToType.GotFocus, cmb_turnOverLocation.GotFocus _
        , cmb_specLocation.GotFocus, txtReceiver.GotFocus, txtTurnOverBy.GotFocus, txtNotedby.GotFocus, txtQuantity.GotFocus, txtUnit.GotFocus, txtRemarks.GotFocus

        sender.backcolor = Color.Yellow

        If txtReceiver.Focused Then
            txtname = txtReceiver.Name
            txtReceiver.SelectAll()
        ElseIf txtTurnOverBy.Focused Then
            txtname = txtTurnOverBy.Name
            txtTurnOverBy.SelectAll()
        ElseIf txtNotedby.Focused Then
            txtname = txtNotedby.Name
            txtNotedby.SelectAll()
        End If

    End Sub

    Private Sub txtReceiver_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReceiver.KeyDown, txtTurnOverBy.KeyDown, txtNotedby.KeyDown

        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
            If lbox_list.Visible = True Then
                If lbox_list.Items.Count > 0 Then
                    lbox_list.Focus()
                    lbox_list.SelectedIndex = 0
                End If
            Else
            End If
        End If

    End Sub

    Private Sub txtReceiver_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReceiver.TextChanged
        Try
            If txtReceiver.Text = "" Then
                lbox_list.Location = New System.Drawing.Point(txtReceiver.Location.X, txtReceiver.Location.Y + txtReceiver.Height)
            Else
                With lbox_list
                    .Location = New System.Drawing.Point(txtReceiver.Location.X, txtReceiver.Location.Y + txtReceiver.Height)
                    .Visible = True
                    .Items.Clear()
                    .Width = txtReceiver.Width
                End With

                get_receiver_turn_overby_notedby(txtReceiver.Text, 0)

            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub get_receiver_turn_overby_notedby(ByVal value As String, ByVal n As Integer)
        Dim sqlcon As New SQLcon
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim counter As Integer = 0
        lbox_list.Items.Clear()
        Try
            sqlcon.connection.Open()
            cmd = New SqlCommand("proc_turnover_items_to_wh", sqlcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure

            If n = 0 Then
                cmd.Parameters.AddWithValue("@n", 7)
            ElseIf n = 1 Then
                cmd.Parameters.AddWithValue("@n", 8)
            ElseIf n = 2 Then
                cmd.Parameters.AddWithValue("@n", 9)
            End If

            cmd.Parameters.AddWithValue("@value", value)
            dr = cmd.ExecuteReader

            While dr.Read

                If n = 0 Then
                    lbox_list.Items.Add(dr.Item("receiver").ToString)
                ElseIf n = 1 Then
                    lbox_list.Items.Add(dr.Item("turnover_by").ToString)
                ElseIf n = 2 Then
                    lbox_list.Items.Add(dr.Item("noted_by").ToString)
                End If

                counter += 1

            End While

            If counter > 0 Then
                lbox_list.Visible = True
            Else
                lbox_list.Visible = False
            End If

            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try
    End Sub

    Private Sub lbox_list_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbox_list.DoubleClick

        If lbox_list.SelectedItems.Count > 0 Then
            For Each ctr As Control In Me.Controls
                If ctr.Name = txtname Then
                    ctr.Text = lbox_list.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next

            lbox_list.Visible = False

        End If

    End Sub

    Private Sub lbox_list_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lbox_list.KeyDown

        If e.KeyCode = Keys.Enter Then
            For Each ctr As Control In Me.Controls
                If ctr.Name = txtname Then
                    ctr.Text = lbox_list.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next

            lbox_list.Visible = False

        End If
    End Sub

    Private Sub txtTurnOverBy_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTurnOverBy.TextChanged
        Try
            If txtTurnOverBy.Text = "" Then
                lbox_list.Location = New System.Drawing.Point(txtTurnOverBy.Location.X, txtTurnOverBy.Location.Y + txtTurnOverBy.Height)
            Else
                With lbox_list
                    .Location = New System.Drawing.Point(txtTurnOverBy.Location.X, txtTurnOverBy.Location.Y + txtTurnOverBy.Height)
                    .Visible = True
                    .Items.Clear()
                    .Width = txtTurnOverBy.Width
                End With

                get_receiver_turn_overby_notedby(txtTurnOverBy.Text, 1)

            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtNotedby_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNotedby.TextChanged
        Try
            If txtNotedby.Text = "" Then
                lbox_list.Location = New System.Drawing.Point(txtNotedby.Location.X, txtNotedby.Location.Y + txtNotedby.Height)
            Else
                With lbox_list
                    .Location = New System.Drawing.Point(txtNotedby.Location.X, txtNotedby.Location.Y + txtNotedby.Height)
                    .Visible = True
                    .Items.Clear()
                    .Width = txtNotedby.Width
                End With

                get_receiver_turn_overby_notedby(txtNotedby.Text, 2)

            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtRemarks_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRemarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            save_update()
        End If
    End Sub

    Private Sub txtRemarks_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemarks.TextChanged

    End Sub
End Class