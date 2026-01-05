Imports System.ComponentModel
Imports System.Data.Sql
Imports System.Data.SqlClient



Public Class FRequestField
    Dim IsFormBeingDragged As Boolean
    Dim drag As Boolean
    Dim MouseDownX As Integer
    Dim MouseDownY As Integer
    ' Public destination_item As Integer = 0
    Public txtname As String


    Dim tor_id As Integer
    Dim tor_sub_id As Integer
    Dim inout_id As Integer
    Dim tsp_id As Integer
    Public tboxname As String
    Public old_qty As Double

    Private errorSaveUPdate As Boolean = False
    Public fromNewCrushingAndHauling As Boolean

    ' this is code is for dropshadow on form
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Const DROPSHADOW = &H20000
            Dim cParam As CreateParams = MyBase.CreateParams
            cParam.ClassStyle = cParam.ClassStyle Or DROPSHADOW
            Return cParam
        End Get

    End Property

    Public SQ As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader

    Private cListOfListViewItem As New List(Of ListViewItem)
    Private properNamingModel, employeeModel As New ModelNew.Model
    Dim cBgWorkerChecker As Timer
    Dim customMsg As New customMessageBox
    Private cWh_pn_id As Integer
    Private cRowColor As New RowColor
    'Private cListOfEmployees As New List(Of PropsFields.employee_props_fields)
    Public Class RowColor
        Public Property rsRow As Color = Color.DarkGreen
        Public Property poRow As Color = Color.LightGreen
        Public Property rrRow As Color = Color.LightYellow
        Public Property drRow As Color = Color.LightYellow
        Public Property rrDrRow As Color = Color.LightPink
    End Class


    Private Sub pboxHeader_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pboxHeader.MouseDown
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
        End If
    End Sub

    Private Sub pboxHeader_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pboxHeader.MouseMove
        If IsFormBeingDragged Then
            Dim temp As Point = New Point()

            temp.X = Me.Location.X + (e.X - MouseDownX)
            temp.Y = Me.Location.Y + (e.Y - MouseDownY)
            Me.Location = temp
            temp = Nothing
        End If
    End Sub

    Private Sub pboxHeader_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pboxHeader.MouseUp
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        For Each ctr As Control In FRequistionForm.Controls
            ctr.Enabled = True
        Next
        FRequistionForm.btnSearch.Enabled = True

        Me.Dispose()
        clear_fields()
        pub_qto_id = 0
        btnSave.Text = "Save"

        requisition_wh_id = 0
        button_click_name = ""

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        'If wh_id = 0 Then
        '    If cmbInOut.Text = "OTHERS" Or cmbInOut.Text = "QUARRY-IN" Then

        '    Else
        '        MessageBox.Show("You forgot to select 'CHARGE TO' field..", "Supply Info:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '        Select Case cmbCharges.Text
        '            Case "ADFIL"
        '                txtChargeTo.Focus()
        '            Case "EQUIPMENT"
        '                cmbCharges.Focus()
        '            Case "CASH"
        '                txtChargeTo.Focus()
        '            Case "WAREHOUSE"
        '                txtChargeTo.Focus()
        '            Case "PERSONAL"
        '                txtChargeTo.Focus()
        '        End Select
        '        Exit Sub
        '    End If

        'End If


        'check propernaming
        cWh_pn_id = getProperNameIdUsingItemNameAndItemDesc(lblProperNaming.Text)

        If cWh_pn_id = 0 Then
            customMsg.message("error", "You must select a proper naming first...", "SUPPLY EXCEPINFO:")
            Exit Sub

        End If

        If button_click_name = "CopyToolStripMenuItem" Then
            If FRequistionForm.cmbDivision.Text = "CRUSHING AND HAULING" Then
                'If CDec(txtQty.Text) > pub_main_rs_qty_left Then
                '    MessageBox.Show("Unable to save this info, the qty you are trying to save exceed to limit.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    Exit Sub
                'End If
                With FRequistionForm
                    Dim rs_qty As Decimal = .lvlrequisitionlist.SelectedItems(0).SubItems(5).Text
                    Dim copy As New Class_Copy
                    'Dim remaining_balance As Decimal = rs_qty - copy.calc_cut_request(.lvlrequisitionlist, .lvlrequisitionlist.SelectedItems(0).SubItems(1).Text)

                    'If CDec(txtQty.Text) > remaining_balance Then
                    '    MessageBox.Show("Unable to save this info, the qty you are trying to save exceed to limit.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '    Exit Sub
                    'End If

                    Dim main_rs_qty_id As Integer = .lvlrequisitionlist.SelectedItems(0).Text

                    'Dim cRs_no As String = .lvlrequisitionlist.SelectedItems(0).SubItems(1).Text
                    'Dim remaining_balance As Double = copy.get_remaining_balance(main_rs_qty_id, cRs_no)

                    Dim remaining_balance As Double = FRequistionForm.GetDRModel().getRemainingBalance(main_rs_qty_id)

                    If CDec(txtQty.Text) > remaining_balance Then
                        MessageBox.Show("Unable to save this info, the qty you are trying to save exceed to limit.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                End With

            End If
        End If


        If txtRSno.Text = "" Then

            MessageBox.Show("rs_no field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtRSno.Focus()

        ElseIf txtLoc.Text = "" Then
            MessageBox.Show("Location field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtLoc.Focus()

        ElseIf txtJOno.Text = "" Then
            MessageBox.Show("J.O No. field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtJOno.Focus()

        ElseIf txtQty.Text = "" Then
            MessageBox.Show("Quantity field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtQty.Focus()

        ElseIf txtUnit.Text = "" Then
            MessageBox.Show("Unit field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtUnit.Focus()

        ElseIf (cmbRequestType.Text = "SUPPLY" Or cmbRequestType.Text = "EQUIPMENT" Or cmbRequestType.Text = "PROJECT" Or cmbRequestType.Text = "OTHERS") And txtItemDesc.Text = "" Then
            MessageBox.Show("FILL UP ON ITEM DESCRIPTION", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtItemDesc.Focus()

        ElseIf txtPurpose.Text = "" Then
            MessageBox.Show("Purpose field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtPurpose.Focus()

        ElseIf txtRequestBy.Text = "" Then
            MessageBox.Show("Request by field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtRequestBy.Focus()

        ElseIf txtNotedBy.Text = "" Then
            MessageBox.Show("Noted by field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtNotedBy.Focus()

            'ElseIf txtApprovedby.Text = "" Then
            '    MessageBox.Show("Approved by field is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    txtApprovedby.Focus()

            'ElseIf txtWarehouseIncharge.Text = "" Then
            '    MessageBox.Show("Whare In-Charge is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    txtWarehouseIncharge.Focus()
            'ElseIf cmbTypeOfPurchase.Text = "" Then
            '    MessageBox.Show("type of purchase is empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    cmbTypeOfPurchase.Focus()

        ElseIf cmbRequestType.Text <> "" And txtItemDesc.Text <> "" Then


            'if ang rs exist na sa po desc, ma save pd apel sa po_item
            If check_if_exist("dbpurchase_order", "rs_no", txtRSno.Text, 0) > 0 Then

                RequestForm()

                txtQty.Clear()
                txtUnit.Clear()
                txtItemDesc.Clear()
                wh_id = 0

            Else
                RequestForm()
            End If

            'pero og wala pa

        ElseIf cmbRequestType.Text = "OTHERS" And txtItemDesc.Text <> "" Then
            'SEPARATE QTY VOLUME
            'Separate_Qty_Volume(True)
            'FRequistionForm.sep_qty_volume = True

            RequestForm()
        Else
            MessageBox.Show("Please recheck the field if there is something missing..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        '++MODIFICATION+++++ 
        'inputting request
        'to chose the item name that same from the warehouse items to make sure
        'that there Is no conflict Or having a uniformity of item names in the supply management system to avoid human errors

        'Save_to_dbRS_temp_items(pub_rs_id)
        'txtItemDesc.Focus()
        '++++++++++++++++++++++++++++

        'save_update_main_rs(txtRSno.Text, txtQty.Text)


    End Sub
    Public Sub save_update_main_rs(rs_no As String, main_rs_qty As Double)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_main_rs_qty", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 1)
            newCMD.Parameters.AddWithValue("@rs_no", rs_no)
            newCMD.Parameters.AddWithValue("@main_rs_qty", main_rs_qty)
            newCMD.Parameters.AddWithValue("@open_qty", IIf(FRequistionForm.cmbOpenQty.Text = "Open Qty", 1, 0))
            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Private Sub Save_to_Contract_Item_Desc_Save_Update(contruct_id As Integer, cont_item_desc As String, rs_id As Integer, n As Integer)

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_QTO_maintenance", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@contract_id", contruct_id)
            newCMD.Parameters.AddWithValue("@contract_item_desc", cont_item_desc)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Private Sub Separate_Qty_Volume(separate_vol As Boolean)

        If separate_vol = True Then

            Dim newSQ As New SQLcon
            Dim newCMD As SqlCommand

            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_qty_volume", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                With FRequistionForm.lvlrequisitionlist.SelectedItems(0)

                    newCMD.Parameters.AddWithValue("@n", 1)
                    newCMD.Parameters.AddWithValue("@rs_no", .SubItems(1).Text)
                    newCMD.Parameters.AddWithValue("@req_date", .SubItems(2).Text)
                    newCMD.Parameters.AddWithValue("@wh_id", .SubItems(15).Text)
                    newCMD.Parameters.AddWithValue("@rs_qty", .SubItems(5).Text)
                    newCMD.Parameters.AddWithValue("@in_out", .SubItems(9).Text)
                    newCMD.Parameters.AddWithValue("@orig_volume", "A")

                End With

                newCMD.ExecuteNonQuery()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try

        End If

    End Sub
    Public Sub INSERT_INTO_dbPurchase_order_items(ByVal proc_po_id As Integer, ByVal proc_pono As Integer,
                                                ByVal proc_wh_id As Integer, ByVal proc_wh_desc As String,
                                                ByVal proc_qty As Integer, ByVal proc_unit As String,
                                                ByVal proc_price As Double, ByVal proc_amount As Double,
                                                ByVal rs_id As Integer)

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()


            newCMD = New SqlCommand("proc_purchase_order_query", SQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@proc_po_id", proc_po_id)
            newCMD.Parameters.AddWithValue("@proc_pono", proc_pono)
            newCMD.Parameters.AddWithValue("@proc_wh_id", proc_wh_id)
            newCMD.Parameters.AddWithValue("@proc_wh_desc", proc_wh_desc)
            newCMD.Parameters.AddWithValue("@proc_qty", proc_qty)
            newCMD.Parameters.AddWithValue("@proc_unit", proc_unit)
            newCMD.Parameters.AddWithValue("@proc_price", proc_price)
            newCMD.Parameters.AddWithValue("@proc_amount", proc_amount)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            'cmd.Parameters.AddWithValue("@datelog", Now)
            newCMD.Parameters.AddWithValue("@n", 2)

            newCMD.ExecuteReader()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub


#Region "GET IDS"
    Private Function getContractId() As Integer
        If cmbContractName.SelectedIndex = -1 Then
        Else
            getContractId = DirectCast(cmbContractName.SelectedItem, KeyValuePair(Of String, String)).Key
        End If
    End Function

#End Region

    Private Sub checkIfChargesExistInMultipleChargesAndInsert()
        Dim charges As String = charges_checker(txtRSno.Text)
        If charges <> "" Then

            Dim split() As String
            Dim split1() As String

            split = charges_checker(txtRSno.Text).Split("^")

            For i = 0 To split.Length - 1
                split1 = split(i).Split("|")

                If split(i) = "" Then

                Else
                    Dim type_name As String = split1(0)
                    Dim all_charges_id As Integer = split1(1)

                    With FProjectIncharge
                        insert_into_dbmultiplecharges(all_charges_id, type_name, CInt(pub_rs_id))
                    End With
                End If
            Next
        Else

            Select Case txtChargeTo.Text
                Case "ADFIL", "OUTSOURCE", "JQG", "BBC"
                    whouse_rs_selection = True
                    FProjectIncharge.lbl_rs_id.Text = pub_rs_id
                    FProjectIncharge.lbl_sign.Text = "R"
                    FProjectIncharge.btnOk.Text = "OK"
                    FProjectIncharge.ShowDialog()
            End Select

        End If
    End Sub

    Private Sub insert_construction_materials()
        Dim contract_id As Integer = getContractId()
        Dim const_id As Integer = get_id("dbContruct_quantities", "item^item_desc", txtConsItem.Text & "^" & txtConsItemDesc.Text, 2)

        If cmbRequestType.Text = "Construction Materials" Then
            insert_into_dbConstruct_quantities_update(public_rs_id, const_id)
            Save_to_Contract_Item_Desc_Save_Update(contract_id, txtConsItemDesc.Text, public_rs_id, 11)
        End If
    End Sub

    Private Sub updateRs()
        Try
            Dim contract_id As Integer = getContractId()

            Dim cc As New ColumnValuesObj

            cc.add("rs_no", txtRSno.Text)
            cc.add("date_req", Date.Parse(DTPReq.Text))
            cc.add("job_order_no", txtJOno.Text)
            cc.add("charge_to", charge_to_id)
            cc.add("location", txtLoc.Text)
            cc.add("wh_id", wh_id)
            cc.add("item_desc", txtItemDesc.Text.Replace("'", "`"))
            cc.add("qty", txtQty.Text)
            cc.add("unit", txtUnit.Text.Replace("'", "`"))
            cc.add("typeRequest", cmbRequestType.Text)
            cc.add("process", cmbRequestType.Text)
            cc.add("purpose", txtPurpose.Text.Replace("'", "`"))
            cc.add("date_needed", Date.Parse(DTPTimeNeeded.Text))
            cc.add("requested_by", txtRequestBy.Text)
            cc.add("noted_by", txtNotedBy.Text)
            cc.add("wh_incharge", txtWarehouseIncharge.Text)
            cc.add("approved_by", txtApprovedby.Text)
            cc.add("remarks", from_old_item_or_new_item)
            cc.add("qto_id", pub_qto_id)
            cc.add("contract_id", contract_id)
            cc.add("user_id_updated", pub_user_id)
            cc.add("date_log_updated", Date.Parse(Now))
            cc.add("remarks_emd_purposed", txtRemarksForEmd.Text)

            cc.setCondition($"rs_id = {public_rs_id}")
            cc.updateQuery("dbrequisition_slip")

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Function countQtyReleased(rs_id As Integer) As Double

        For Each row As ListViewItem In FRequistionForm.lvlrequisitionlist.Items
            If row.BackColor = cRowColor.poRow And Utilities.ifBlankReplaceToZero(row.Text) = rs_id Then
                countQtyReleased += Utilities.ifBlankReplaceToZero(row.SubItems(22).Text)
            End If
        Next

    End Function

    Private Function countQtyReceived(rs_id As Integer) As Double

        For Each row As ListViewItem In FRequistionForm.lvlrequisitionlist.Items
            If row.BackColor = cRowColor.rrRow And Utilities.ifBlankReplaceToZero(row.Text) = rs_id Then
                countQtyReceived += Utilities.ifBlankReplaceToZero(row.SubItems(23).Text)
            End If
        Next

    End Function

    Private Function countQtyDrReleased(rs_id As Integer) As Double
        For Each row As ListViewItem In FRequistionForm.lvlrequisitionlist.Items
            If row.BackColor = cRowColor.drRow And Utilities.ifBlankReplaceToZero(row.Text) = rs_id Then
                countQtyDrReleased += Utilities.ifBlankReplaceToZero(row.SubItems(22).Text)
            End If
        Next
    End Function
    Public Sub RequestForm()
        Dim n As Integer
        Dim cc As New ColumnValuesObj

        Try
            'SQ.connection.Open()
            publicquery = Nothing

            tor_sub_id = get_id("dbType_of_Request_sub", "tor_sub_desc", cmbTOR_sub.Text, 0)
            inout_id = get_id("dbinout", "in_out_desc", cmbInOut.Text, 0)
            tsp_id = get_id("dbtor_sub_property", "tor_sub_id^inout_id", tor_sub_id & "^" & inout_id, 3)

            If btnSave.Text = "Save" Then

                Dim contract_id As Integer = getContractId()
#Region "INSERT RS"
                cc.add("rs_no", txtRSno.Text)
                cc.add("date_req", Date.Parse(DTPReq.Text))
                cc.add("job_order_no", txtJOno.Text)
                cc.add("charge_to", charge_to_id)
                cc.add("location", txtLoc.Text)
                cc.add("wh_id", wh_id)
                cc.add("item_desc", txtItemDesc.Text.Replace("'", "`"))
                cc.add("qty", txtQty.Text)
                cc.add("unit", txtUnit.Text.Replace("'", "`"))
                cc.add("typeRequest", cmbRequestType.Text)
                cc.add("process", cmbRequestType.Text)
                cc.add("purpose", txtPurpose.Text.Replace("'", "`"))
                cc.add("date_needed", Date.Parse(DTPTimeNeeded.Text))
                cc.add("requested_by", txtRequestBy.Text)
                cc.add("noted_by", txtNotedBy.Text)
                cc.add("wh_incharge", txtWarehouseIncharge.Text)
                cc.add("approved_by", txtApprovedby.Text)
                cc.add("IN_OUT", cmbInOut.Text)
                cc.add("date_log", Date.Parse(Now))
                cc.add("type_of_purchasing", cmbTypeOfPurchase.Text)
                cc.add("remarks", from_old_item_or_new_item)
                cc.add("user_id", pub_user_id)
                cc.add("original_volume", IIf(FRequistionForm.sep_qty_volume = True, "B", ""))
                cc.add("qto_id", pub_qto_id)
                cc.add("contract_id", contract_id)
                cc.add("wh_pn_id", cWh_pn_id)
                cc.add("remarks_emd_purposed", txtRemarksForEmd.Text)

                pub_rs_id = cc.insertQuery_and_return_id("dbrequisition_slip") 'cmd.ExecuteScalar()
#End Region

#Region "FOR COPY FUNCTION OR NOT"

                If button_click_name = "CopyToolStripMenuItem" Then 'if ang ge click is copy
                    Select Case txtChargeTo.Text
                        Case "ADFIL", "OUTSOURCE", "JQG", "BBC"
                            whouse_rs_selection = True
                            FProjectIncharge.lbl_rs_id.Text = pub_rs_id
                            FProjectIncharge.lbl_sign.Text = "R"
                            FProjectIncharge.btnOk.Text = "OK"
                            FProjectIncharge.ShowDialog()
                    End Select
                Else
                    'check this rs_no naa na sa multiple charges
                    checkIfChargesExistInMultipleChargesAndInsert()
                End If
#End Region

                rs_quarry_save_update()
                rs_tor_sub_pro_save(pub_rs_id)

                Dim const_id As Integer = get_id("dbContruct_quantities", "item^item_desc", txtConsItem.Text & "^" & txtConsItemDesc.Text, 2)

                If cmbRequestType.Text = "Construction Materials" Then
                    insert_into_dbConstruct_quantities_save(pub_rs_id, const_id)

                    'INSERT: 'if blank, dili ma save ang contract name and contract item.
                    If Not cmbContractName.Text = "" And Not txtConsItem.Text = "" Then
                        Save_to_Contract_Item_Desc_Save_Update(contract_id, txtConsItemDesc.Text, pub_rs_id, 10)
                    End If
                End If

                pub_qto_id = 0
                txtQtyTakeOff.Clear()

                MessageBox.Show("Successfully Inserted...", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Information)


            ElseIf btnSave.Text = "Update" Then

                Dim contract_id As Integer = getContractId()

                Dim rs_qty As Double = CDbl(txtQty.Text)
                Dim ws_qty As Double = Utilities.ifBlankReplaceToZero(FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(22).Text)
                Dim dr_qty As Double = Utilities.ifBlankReplaceToZero(FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(32).Text)

                'Dim typeOfPurchasing As String = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(18).Text

                Dim pocv_status As String = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(10).Text
                Dim rr_status As String = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(11).Text
                Dim inout As String = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(9).Text
                Dim withdrawal_status As String = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(12).Text
                Dim rs_id As Integer = FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text
                Dim typeOfPurchasing As String = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(18).Text


                'QUANTITY FILTERTING
                Select Case typeOfPurchasing
                    Case cTypeOfPurchasing.PURCHASE_ORDER, cTypeOfPurchasing.WITHDRAWAL
                        If rs_qty < countQtyReleased(rs_id) Then
                            customMsg.message("error", "your rs qty Is less than the ws/po/cv qty released", "SUPPLY INFO")
                            errorSaveUPdate = True
                            Exit Sub
                        End If

                        If countQtyDrReleased(rs_id) > 0 And countQtyReceived(rs_id) > 0 Then
                            customMsg.message("error", "Updates are not allowed if both the PO and RR already exist. Please consult the IT administrator first.", "SUPPLY INFO:")
                            errorSaveUPdate = True
                            Exit Sub
                        End If
                End Select

#Region "UPDATE FOR RECEIVING AND PO AND CASH ONLY"
                '==============================UPDATE FOR RECEIVING AND PO AND CASH ONLY===================================

                If pocv_status = "PO/CV RELEASED" Or pocv_status = "CV RELEASED" Or pocv_status = "PO/CV PARTIALLY RELEASED" Or pocv_status = "CV PARTIALLY RELEASED" Then
                    Dim msg As String = "unable to edit quantities if the status is PO RELEASED or CV RELEASED." & vbCrLf & vbCrLf _
                                       & "If you want to proceed, click yes and please take note that the cv or po qty will be affected."

                    If customMsg.messageYesNo(msg, "SUPPLY INFO:") Then
                        old_qty = CDbl(FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(5).Text)

                        If inout = "OTHERS" Or inout = "IN" Then

                            Panel1.Visible = True
                            project_affected_po_cv(rs_id, inout)

                            'update rs
                            updateRs()

                            rs_quarry_save_update()
                            rs_tor_sub_pro_update(public_rs_id)

                            'insert data for construction materials
                            insert_construction_materials()
                            Exit Sub
                        Else
                            MessageBox.Show("Please, palihog ko paki tawag kang king gwapo.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If

                ElseIf pocv_status = "PENDING" Or pocv_status = "WAITING..." Or pocv_status = "N/A" Then

                    'update rs
                    updateRs()

                    rs_quarry_save_update()
                    rs_tor_sub_pro_update(public_rs_id)

                    'insert data for construction materials
                    insert_construction_materials()
                    Exit Sub

                Else ' na received na, pero naa lang editon gamay. walay labot qty

                    'update rs
                    updateRs()

                    rs_quarry_save_update()
                    rs_tor_sub_pro_update(public_rs_id)

                    'insert data for construction materials
                    insert_construction_materials()
                    Exit Sub

                End If
#End Region

#Region "UPDATE FOR WITHDRAWAL ONLY"
                '==============================UPDATE FOR WITHDRAWAL ONLY===================================

                If inout = "OUT" Then

                    If withdrawal_status = "WS RELEASED" Or
                        withdrawal_status = "WS PARTIALLY RELEASED" Or
                        withdrawal_status = "WITHDRAWN" Or
                        withdrawal_status = "PARTIALLY WITHDRAWN" Then

                        Panel1.Visible = True
                        project_affected_po_cv(rs_id, inout)

                        'update rs
                        updateRs()

                        n = public_rs_id

                        cmd.ExecuteNonQuery()

                        rs_quarry_save_update()
                        rs_tor_sub_pro_update(public_rs_id)

                        'insert data for construction materials
                        insert_construction_materials()

                        Exit Sub
                    Else
                        'update rs
                        updateRs()

                        n = public_rs_id

                        rs_quarry_save_update()
                        rs_tor_sub_pro_update(public_rs_id)

                        'insert data for construction materials
                        insert_construction_materials()

                        Exit Sub
                    End If
                End If
                'End If
#End Region

                'insert data for construction materials
                insert_construction_materials()

                pub_qto_id = 0
                txtQtyTakeOff.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()

            If Not errorSaveUPdate = True Then
                reload(n)
            End If

            errorSaveUPdate = False
        End Try
    End Sub
    Private Sub reload(id As Integer)
        With FRequistionForm
            .lvlrequisitionlist.Items.Clear()
            .cmbSearchByCategory.Text = "Search by RS.No."
            .txtSearch.Text = txtRSno.Text


            FRequistionForm.FlowLayoutPanel1.Enabled = True
            FRequistionForm.btnSearch.Enabled = True
            FRequistionForm.btnSearch.PerformClick()

            If btnSave.Text = "Save" Then
                listfocus(.lvlrequisitionlist, pub_rs_id)

            ElseIf btnSave.Text = "Update" Then
                btnSave.Text = "Save"
                listfocus(.lvlrequisitionlist, id)
            End If

            FRequistionForm.FlowLayoutPanel1.Enabled = False
            FRequistionForm.btnSearch.Enabled = False
        End With

        from_old_item_or_new_item = Nothing
        button_click_name = ""
    End Sub
    Public Sub project_affected_po_cv(rs_id As Integer, in_out As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        ListView1.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_requisition_slip", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 20)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.Parameters.AddWithValue("@inout", in_out)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim a(5) As String

                If in_out = "OUT" Then

                    If newDR.Item("WS_STATUS").ToString = "YES" Then
                        a(0) = newDR.Item("po_det_id").ToString
                        a(1) = newDR.Item("po_no").ToString
                        a(2) = newDR.Item("qty").ToString
                    End If

                ElseIf in_out = "IN" Or in_out = "OTHERS" Then

                    a(0) = newDR.Item("po_det_id").ToString
                    a(1) = newDR.Item("po_no").ToString
                    a(2) = newDR.Item("qty").ToString

                End If

                Dim lvl As New ListViewItem(a)
                ListView1.Items.Add(lvl)

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Public Sub insert_into_dbConstruct_quantities_save(rs_id As Integer, const_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("PROC_Construction_Materials", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 7)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.Parameters.AddWithValue("@const_id", const_id)

            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Public Sub insert_into_dbConstruct_quantities_update(rs_id As Integer, const_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("PROC_Construction_Materials", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            If check_if_exist("dbConstruct_quantities_save", "rs_id", rs_id, 1) > 0 Then
                newCMD.Parameters.AddWithValue("@n", 8)
            Else
                newCMD.Parameters.AddWithValue("@n", 7)
            End If

            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.Parameters.AddWithValue("@const_id", const_id)

            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Public Sub insert_into_dbmultiplecharges(ByVal all_charges_id As Integer, ByVal type_name As String, ByVal rs_id As Integer)

        Dim query As String = "INSERT INTO dbMultipleCharges(all_charges_id,type_name,rs_id,fi_id) VALUES(" & all_charges_id & ",'" & type_name & "'," & rs_id & "," & 0 & ")"
        UPDATE_INSERT_DELETE_QUERY(query, 0, "INSERT")

    End Sub
    Public Function get_multiple_charges_type_name(all_charges_id As Integer, rs_no As String) As String

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_requisition_slip", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 12)
            newCMD.Parameters.AddWithValue("@all_charges_id", all_charges_id)
            newCMD.Parameters.AddWithValue("@rs_no", rs_no)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_multiple_charges_type_name = newDR.Item("type_name").ToString
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Function charges_checker(rs_no As String) As String

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_requisition_slip", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 11)
            newCMD.Parameters.AddWithValue("@rs_no", rs_no)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim all_charges_id As Integer = CInt(newDR.Item("all_charges_id").ToString)

                Dim type_name As String = get_multiple_charges_type_name(all_charges_id, rs_no)
                charges_checker = charges_checker & type_name & "|" & CInt(newDR.Item("all_charges_id").ToString) & "^"

            End While
            newDR.Close()

            If charges_checker = "" Then
            Else
                charges_checker = remove_last_character(charges_checker)
            End If


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Function
    Private Sub rs_quarry_save_update()
        '******** for quarry **********'

        Dim rs_id As Integer

        If btnSave.Text = "Save" Then
            rs_id = pub_rs_id
        Else
            rs_id = CInt(FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text)
        End If


        If cmbTypeOfPurchase.Text = "DR" Then
            'Dim query As String = "DELETE FROM dbquary_charges WHERE rs_id = " & rs_id
            'UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")
            Dim query As String

            For Each row As ListViewItem In lvlQuarry.Items

                If row.Checked = True Then
                    query = Nothing
                    query = "INSERT INTO dbquary_charges(quarry_id,rs_id,source) VALUES(" & CInt(row.Text) & "," & rs_id & ",'" & cmbSelectSource.Text & "')"
                    UPDATE_INSERT_DELETE_QUERY(query, 0, "INSERT")
                End If
            Next
        End If

        '******** end of quarry **********

    End Sub
    Public Sub rs_tor_sub_pro_save(ByVal rs_id As Integer)

        Try
            tor_sub_id = get_id("dbType_of_Request_sub", "tor_sub_desc", cmbTOR_sub.Text, 0)
            inout_id = get_id("dbinout", "in_out_desc", cmbInOut.Text, 0)
            tsp_id = get_id("dbtor_sub_property", "tor_sub_id^inout_id", tor_sub_id & "^" & inout_id, 3)

            '06/05/24 king
            Dim getTorSubId As Integer = get_tor_sub_id()

            Dim query As String = "INSERT INTO rs_tor_sub_property(rs_id,tsp_id,tor_sub_id) VALUES(" & rs_id & "," & tsp_id & "," & getTorSubId & ")" 'tor_sub_id
            UPDATE_INSERT_DELETE_QUERY(query, 0, "INSERT")

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try
    End Sub

    Private Sub rs_tor_sub_pro_update(ByVal rs_id As Integer)

        Try
            tor_sub_id = get_id("dbType_of_Request_sub", "tor_sub_desc", cmbTOR_sub.Text, 0)
            inout_id = get_id("dbinout", "in_out_desc", cmbInOut.Text, 0)
            tsp_id = get_id("dbtor_sub_property", "tor_sub_id^inout_id", tor_sub_id & "^" & inout_id, 3)

            '06-04-24 king
            Dim getTorSubId As Integer = get_tor_sub_id()

            If check_if_exist("rs_tor_sub_property", "rs_id", rs_id, 1) > 0 Then
                Dim query As String = "UPDATE rs_tor_sub_property SET tor_sub_id = " & getTorSubId & " WHERE rs_id = " & rs_id
                UPDATE_INSERT_DELETE_QUERY(query, 0, "UPDATE")

            Else
                rs_tor_sub_pro_save(rs_id)
            End If


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try
    End Sub

    Private Function get_tor_sub_id() As Integer
        Dim getTorSubId As New Model_Dynamic_Select

        Dim table As String = "dbType_of_Request_sub a"
        Dim condition As String = $"UPPER(b.tor_desc) = '{cmbRequestType.Text.ToUpper()}' and UPPER(a.tor_sub_desc) = '{cmbTOR_sub.Text.ToUpper() }'"

        'columns
        getTorSubId.join_columns("a.tor_sub_id")


        'inner or left join
        getTorSubId.joining("LEFT JOIN dbType_of_Request b ")
        getTorSubId.joining("on b.tor_id = a.tor_id")

        'initialize data
        getTorSubId._initialize(table, condition, getTorSubId.cJoinColumns, getTorSubId.cJoining)

        Dim rrData As New List(Of Object) 'create a list of ojbect 
        rrData = getTorSubId.select_query() 'get data

        'loop data to get values
        For Each row In rrData
            Dim n As Integer = 0

            For Each kvp As KeyValuePair(Of String, Object) In row
                get_tor_sub_id = kvp.Value.ToString
            Next
        Next
    End Function
    Private Sub txtItemDesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemDesc.TextChanged
        If txtItemDesc.Text = "" Then
            wh_id = 0
        Else

        End If
    End Sub

    Private Sub FRequestField_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            clear_fields()
        ElseIf e.Control And e.KeyCode = Keys.S Then
            btnSave.PerformClick()
        Else

        End If
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

    Public Sub load_equipment(ByVal n As Integer, ByVal obj As Object)

        Dim cmbox As ComboBox = obj

        cmbox.Items.Clear()

        Dim sqlcon As New SQLcon

        'sqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
        'sqlcon.sql_connect()

        cmbChargeTo.Width = txtApprovedby.Width
        cmbChargeTo.Location = New Point(txtChargeTo.Bounds.Left, txtChargeTo.Bounds.Top)
        txtChargeTo.Visible = False
        cmbox.BringToFront()

        Try
            sqlcon.connection1.Open()

            If n = 0 Then
                publicquery = "SELECT * FROM dbequipment_list ORDER BY plate_no ASC"
            ElseIf n = 1 Then
                publicquery = "SELECT * FROM dbprojectdesc ORDER BY project_desc ASC"
            ElseIf n = 2 Then
                publicquery = "SELECT * FROM dbprojectdesc WHERE project_desc LIKE '%" & "SHOP" & "%' ORDER BY project_desc ASC"
            End If

            cmd = New SqlCommand(publicquery, sqlcon.connection1)
            dr = cmd.ExecuteReader

            While dr.Read

                If n = 0 Then
                    cmbox.Items.Add(dr.Item("plate_no").ToString)
                ElseIf n = 1 Or n = 2 Then
                    cmbox.Items.Add(dr.Item("project_desc").ToString)
                End If

            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection1.Close()
        End Try
    End Sub

    Private Sub btnGetItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        FListOfItems.ShowDialog()

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        'Select Case cmbInOut.Text
        '    Case "IN"
        '        wh_item_destination = 1
        '        FListOfItems.lblInOut.Text = cmbInOut.Text

        '        FListOfItems.ShowDialog()
        '    Case "OUT"
        '        wh_item_destination = 1
        '        FListOfItems.lblInOut.Text = cmbInOut.Text
        '        FListOfItems.ShowDialog()

        '    Case "OTHERS"

        '        wh_item_destination = 1
        '        FListOfItems.lblInOut.Text = cmbInOut.Text
        '        FListOfItems.ShowDialog()

        '    Case "QUARRY-IN"
        '        wh_item_destination = 1
        '        FListOfItems.lblInOut.Text = cmbInOut.Text
        '        FListOfItems.ShowDialog()

        '    Case "FACILITIES"
        '        'FACILITIES_TOOLS()
        '        FBorrowerItems.lbl_Fac_tools.Text = cmbInOut.Text
        '        FBorrowerItems.ShowDialog()

        '    Case "TOOLS"
        '        FBorrowerItems.lbl_Fac_tools.Text = cmbInOut.Text
        '        FBorrowerItems.ShowDialog()

        '    Case "ADD-ON"
        '        FBorrowerItems.lbl_Fac_tools.Text = cmbInOut.Text
        '        FBorrowerItems.ShowDialog()

        'End Select



        'If cmbRequestType.Text = "OTHERS" And cmbInOut.Text = "FACILITIES" Or cmbRequestType.Text = "OTHERS" And cmbInOut.Text = "TOOLS" Then
        '    public_fac_tools = cmbInOut.Text
        '    FFacilities_Tools.btnCreateBS.Enabled = False
        '    FFacilities_Tools.lblnote.Text = "NOTE: double click to select item"
        '    FFacilities_Tools.lvlFacTools.CheckBoxes = False


        '    For Each ctr As Control In FFacilities_Tools.Controls
        '        If ctr.Name = "lvlFacTools" Or ctr.Name = "btnExit" Or ctr.Name = "lblnote" _
        '        Or ctr.Name = "txtSearch" Or ctr.Name = "Label1" Then
        '            ctr.Enabled = True
        '        Else
        '            ctr.Enabled = False
        '        End If
        '    Next

        '    public_fac_tools = "ALL"
        '    FFacilities_Tools.ShowDialog()
        'ElseIf cmbRequestType.Text = "OTHERS" And cmbInOut.Text = "OTHERS" And cmbTypeofCharge.Text = "PERSONAL" Then
        '    FPersonalItem.ShowDialog()

        'ElseIf cmbRequestType.Text = "EQUIPMENT" And cmbInOut.Text = "OTHERS" Then
        '    cmbCharges.Items.Clear()

        '    cmbCharges.Items.Add("MAJOR")
        '    cmbCharges.Items.Add("MINOR")

        '    For Each ctr As Control In Me.Controls
        '        If ctr.Name = "pboxcharges" Then
        '            ctr.Visible = True
        '        Else
        '            ctr.Enabled = False
        '        End If
        '    Next

        '    'FPersonalItem.ShowDialog()

        'Else
        '    FListOfItems.lblInOut.Text = cmbInOut.Text
        '    FListOfItems.ShowDialog()
        'End If
    End Sub
    Public Sub FACILITIES_TOOLS()
        public_fac_tools = cmbInOut.Text
        FFacilities_Tools.btnCreateBS.Enabled = False
        FFacilities_Tools.lblnote.Text = "NOTE: double click to select item"
        FFacilities_Tools.lvlFacTools.CheckBoxes = False


        For Each ctr As Control In FFacilities_Tools.Controls
            If ctr.Name = "lvlFacTools" Or ctr.Name = "btnExit" Or ctr.Name = "lblnote" _
            Or ctr.Name = "txtSearch" Or ctr.Name = "Label1" Then
                ctr.Enabled = True
            Else
                ctr.Enabled = False
            End If
        Next

        public_fac_tools = "ALL"
        FFacilities_Tools.ShowDialog()

    End Sub

    Private Sub txtField_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRSno.GotFocus, txtChargeTo.GotFocus, txtLoc.GotFocus, txtJOno.GotFocus,
    txtQty.GotFocus, txtUnit.GotFocus, txtItemDesc.GotFocus, txtPurpose.GotFocus, txtRequestBy.GotFocus, txtNotedBy.GotFocus, txtWarehouseIncharge.GotFocus, txtApprovedby.GotFocus, txtConsItem.GotFocus, txtConsItemDesc.GotFocus


        sender.backcolor = Color.Yellow

        'for txtRequestby field
        If txtRequestBy.Focused Then
            txtname = txtRequestBy.Name
            txtRequestBy.SelectAll()
        ElseIf txtNotedBy.Focused Then
            txtname = txtNotedBy.Name
            txtNotedBy.SelectAll()
        ElseIf txtApprovedby.Focused Then
            txtname = txtApprovedby.Name
            txtApprovedby.SelectAll()
        ElseIf txtWarehouseIncharge.Focused Then
            txtname = txtWarehouseIncharge.Name
            txtWarehouseIncharge.SelectAll()
        ElseIf cmbContractName.Focused Then
            txtname = cmbContractName.Name
        End If

    End Sub

    Private Sub txtRSno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRSno.KeyDown

        'If Not (e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 48 Or e.KeyValue = 49 Or e.KeyValue = 50 Or e.KeyValue = 51 Or e.KeyValue = 52 Or e.KeyValue = 53 Or e.KeyValue = 54 Or _
        '   e.KeyValue = 55 Or e.KeyValue = 56 Or e.KeyValue = 57 Or e.KeyValue = 96 Or e.KeyValue = 97 Or e.KeyValue = 98 Or e.KeyValue = 99 Or _
        '   e.KeyCode = Keys.OemPeriod Or _
        '  e.KeyValue = 100 Or e.KeyValue = 101 Or e.KeyValue = 102 Or e.KeyValue = 103 Or e.KeyValue = 104 Or e.KeyValue = 105 Or e.KeyValue = 37 Or e.KeyValue = 39) Then

        '    e.SuppressKeyPress() = True
        'End If

    End Sub

    Private Sub txtJOno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtJOno.KeyDown

        'If Not (e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 48 Or e.KeyValue = 49 Or e.KeyValue = 50 Or e.KeyValue = 51 Or e.KeyValue = 52 Or e.KeyValue = 53 Or e.KeyValue = 54 Or _
        '   e.KeyValue = 55 Or e.KeyValue = 56 Or e.KeyValue = 57 Or e.KeyValue = 96 Or e.KeyValue = 97 Or e.KeyValue = 98 Or e.KeyValue = 99 Or _
        '   e.KeyCode = Keys.OemPeriod Or _
        '  e.KeyValue = 100 Or e.KeyValue = 101 Or e.KeyValue = 102 Or e.KeyValue = 103 Or e.KeyValue = 104 Or e.KeyValue = 105 Or e.KeyValue = 37 Or e.KeyValue = 39) Then

        '    e.SuppressKeyPress() = True
        'End If

    End Sub

    Private Sub txtQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQty.KeyDown

        If Not (e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 48 Or e.KeyValue = 49 Or e.KeyValue = 50 Or e.KeyValue = 51 Or e.KeyValue = 52 Or e.KeyValue = 53 Or e.KeyValue = 54 Or
         e.KeyValue = 55 Or e.KeyValue = 56 Or e.KeyValue = 57 Or e.KeyValue = 96 Or e.KeyValue = 97 Or e.KeyValue = 98 Or e.KeyValue = 99 Or
         e.KeyCode = Keys.OemPeriod Or
        e.KeyValue = 100 Or e.KeyValue = 101 Or e.KeyValue = 102 Or e.KeyValue = 103 Or e.KeyValue = 104 Or e.KeyValue = 105 Or e.KeyValue = 37 Or e.KeyValue = 110 Or e.KeyValue = 39) Then

            e.SuppressKeyPress() = True
        End If

    End Sub

   
    Private Sub txtUnit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUnit.KeyPress

    End Sub

    Private Sub txtField_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRequestBy.KeyDown, txtNotedBy.KeyDown, txtApprovedby.KeyDown, txtWarehouseIncharge.KeyDown, txtLoc.KeyDown, txtUnit.KeyDown, txtPurpose.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then

            If lboxUnit.Visible = True Then
                If lboxUnit.Items.Count > 0 Then
                    lboxUnit.Focus()
                    lboxUnit.SelectedIndex = 0
                End If
            End If

        End If
    End Sub

    Private Sub txtNotedBy_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNotedBy.KeyDown

    End Sub

    Private Sub txtApprovedby_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtApprovedby.KeyDown

    End Sub

    Private Sub txtField_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRSno.Leave, txtChargeTo.Leave, txtLoc.Leave, txtJOno.Leave,
   txtQty.Leave, txtUnit.Leave, txtItemDesc.Leave, txtPurpose.Leave, txtRequestBy.Leave, txtNotedBy.Leave, txtWarehouseIncharge.Leave, txtApprovedby.Leave, txtConsItem.Leave, txtConsItemDesc.Leave

        sender.backcolor = Color.White


    End Sub

    Private Sub cmbRequestType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRequestType.SelectedIndexChanged
        'If cmbRequestType.Text = "BORROWER" Then
        '    cmbInOut.Items.Clear()
        '    cmbInOut.Items.Add("FACILITIES")
        '    cmbInOut.Items.Add("TOOLS")
        '    cmbInOut.Items.Add("ADD-ON")
        '    txtUnit.Enabled = True

        'Else
        '    txtItemDesc.Clear()
        '    wh_id = 0
        '    txtChargeTo.Text = ""
        '    charge_to_id = 0
        '    cmbChargeTo.Visible = False

        '    cmbInOut.Items.Clear()

        '    If cmbRequestType.Text = "ADMIN AND MISC." Then
        '        cmbInOut.Items.Add("IN")
        '        cmbInOut.Items.Add("OUT")
        '        cmbInOut.Items.Add("OTHERS")
        '        'cmbInOut.Items.Add("FACILITIES")
        '        'cmbInOut.Items.Add("TOOLS")
        '    Else
        '        cmbInOut.Items.Add("IN")
        '        cmbInOut.Items.Add("OUT")
        '        cmbInOut.Items.Add("OTHERS")
        '        cmbInOut.Items.Add("QUARRY-IN")

        '        'cmbInOut.Items.Add("FACILITIES")
        '        'cmbInOut.Items.Add("TOOLS")
        '    End If

        '    'txtUnit.Enabled = False

        'End If

        'set_type_of_request(cmbInOut.Text)

        ''If cmbRequestType.Text = "EQUIPMENT" Then
        ''    cmbChargeTo.Visible = True
        ''    txtChargeTo.Visible = False

        ''    cmbInOut.Items.Clear()
        ''    cmbInOut.Items.Add("OUT")
        ''    cmbInOut.Items.Add("OTHERS")
        ''    clear_fields()
        ''    load_equipment(0)
        ''    cmbTypeofCharge.Enabled = False

        ''ElseIf cmbRequestType.Text = "PROJECT" Then
        ''    cmbChargeTo.Visible = True
        ''    txtChargeTo.Visible = False

        ''    cmbInOut.Items.Clear()
        ''    cmbInOut.Items.Add("OUT")
        ''    cmbInOut.Items.Add("OTHERS")
        ''    clear_fields()
        ''    load_equipment(1)
        ''    cmbTypeofCharge.Enabled = False


        ''ElseIf cmbRequestType.Text = "OTHERS" Then
        ''    cmbInOut.Items.Clear()
        ''    cmbInOut.Items.Add("TOOLS")
        ''    cmbInOut.Items.Add("FACILITIES")
        ''    cmbInOut.Items.Add("OTHERS")
        ''    cmbInOut.Items.Add("OUT")
        ''    If btnSave.Text = "Update" Then
        ''    Else
        ''        clear_fields()
        ''    End If

        ''    cmbChargeTo.Visible = False
        ''    txtChargeTo.Visible = True

        ''ElseIf cmbRequestType.Text = "SUPPLY" Then
        ''    cmbInOut.Items.Clear()
        ''    cmbChargeTo.Visible = False
        ''    txtChargeTo.Visible = True

        ''    cmbInOut.Items.Add("IN")
        ''    cmbInOut.Items.Add("OUT")

        ''    clear_fields()
        ''    cmbTypeofCharge.Enabled = False

        ''End If

        tor_id = get_id("dbType_of_Request", "tor_desc", cmbRequestType.Text, 0)

        If cmbRequestType.Text = "Construction Materials" Then
            load_type_of_request_and_sub(4, cmbTOR_sub, tor_id, cmbRequestType.Text)
            cmbInOut.Items.Clear()
        Else
            load_type_of_request_and_sub(2, cmbTOR_sub, tor_id)
            cmbInOut.Items.Clear()
        End If


        If cmbRequestType.Text = "Construction Materials" Then
            'txtConsItem.Enabled = True
            txtConsItemDesc.Enabled = True
            'PictureBox5.Enabled = True
            'load sub items

            cmbContractName.Enabled = True
            load_construct_name(cmbContractName)
            cmbContractName.SelectedIndex = -1

        Else
            'txtConsItem.Enabled = False
            txtConsItemDesc.Enabled = False
            'PictureBox5.Enabled = False
            cmbContractName.SelectedIndex = -1
            cmbContractName.Enabled = False

        End If

    End Sub
    Private Sub load_construct_name(cmb As ComboBox)
        Dim comboSource As New Dictionary(Of String, String)()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_QTO_maintenance", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 7)

            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                comboSource.Add(newDR.Item("contract_id").ToString, newDR.Item("Item_name_no").ToString)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

            cmb.DataSource = New BindingSource(comboSource, Nothing)
            cmb.DisplayMember = "Value"
            cmb.ValueMember = "Key"
        End Try


    End Sub
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
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

        charge_to_destination = 1
        FCharge_To.ShowDialog()

        'If cmbRequestType.Text = "SUPPLY" And cmbInOut.Text = "IN" Then
        '    charge_to_selection = 1
        'ElseIf cmbRequestType.Text = "SUPPLY" And cmbInOut.Text = "OUT" Then
        '    charge_to_selection = 2

        'ElseIf cmbRequestType.Text = "OTHERS" And cmbInOut.Text = "OTHERS" Then
        '    charge_to_selection = 3

        'ElseIf cmbRequestType.Text = "OTHERS" And cmbInOut.Text = "TOOLS" And cmbTypeofCharge.Text = "ADFIL" Then
        '    charge_to_selection = 2

        'ElseIf cmbRequestType.Text = "OTHERS" And cmbInOut.Text = "FACILITIES" And cmbTypeofCharge.Text = "ADFIL" Then
        '    charge_to_selection = 2

        'ElseIf cmbRequestType.Text = "OTHERS" And cmbInOut.Text = "FACILITIES" And cmbTypeofCharge.Text = "WAREHOUSE" Then
        '    charge_to_selection = 1

        'ElseIf cmbRequestType.Text = "OTHERS" And cmbInOut.Text = "TOOLS" And cmbTypeofCharge.Text = "ADFIL" Then
        '    charge_to_selection = 2

        'ElseIf cmbRequestType.Text = "OTHERS" And cmbInOut.Text = "TOOLS" And cmbTypeofCharge.Text = "WAREHOUSE" Then
        '    charge_to_selection = 1

        'ElseIf cmbRequestType.Text = "OTHERS" And cmbInOut.Text = "OUT" Then
        '    charge_to_selection = 2
        'End If

        'charge_to_destination = 1
        'FCharge_To.ShowDialog()

        '' FChargeTo.ShowDialog()

    End Sub

    Private Sub txtChargeTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChargeTo.TextChanged
        If txtChargeTo.Text = "ADFIL" And btnSave.Text = "Edit" Then
            btnViewMultipleCharges.Enabled = True
        Else
            btnViewMultipleCharges.Enabled = False

        End If
    End Sub

    Private Sub FRequestField_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'clear_fields()

        'cmbRequestType.Items.Clear()

        'cmbRequestType.Items.Add("MAJOR")
        'cmbRequestType.Items.Add("MINOR")
        'cmbRequestType.Items.Add("EQUIPMENT")
        'cmbRequestType.Items.Add("ADMIN AND MISC.")
        'cmbRequestType.Items.Add("BORROWER")

        load_type_of_request_and_sub(1, cmbRequestType, tor_id)

        load_location_names(txtLoc)
        loadProperNames()
    End Sub

    Private Sub loadProperNames()
        cListOfListViewItem.Clear()
        properNamingModel.clearParameter()
        employeeModel.clearParameter()

        loadingPanel.Visible = True

        Dim values As New Dictionary(Of String, String)

        _init_._initializing(cCol.forWhItem_ProperNames,
                      values,
                      properNamingModel,
                      whItemsProperNameBgWorker)

        _init_._initializing(cCol.forEmployees,
                             values,
                             employeeModel,
                             whItemsProperNameBgWorker)

        cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, whItemsProperNameBgWorker)


    End Sub

    Private Sub SuccessfullyDone()
        Results.cListOfProperNaming = TryCast(properNamingModel.cData, List(Of PropsFields.whItems_properName_fields))
        Results.cListOfEmployees = TryCast(employeeModel.cData, List(Of PropsFields.employee_props_fields))

        loadingPanel.Visible = False

        load_unit_names(txtUnit)
        load_requested_by_names(txtRequestBy)
        load_noted_by_names(txtNotedBy)
    End Sub

    Public Sub load_type_of_request_and_sub(ByVal n As Integer, ByVal cbox As ComboBox, ByVal bypas_tor_id_or_tor_sub_id As Integer, Optional typeOfRequest As String = "")
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        cbox.Items.Clear()

        newSQ.connection.Open()

        Try
            Dim query As String = ""

            If n = 1 Then
                query = "SELECT tor_desc FROM dbType_of_Request"
            ElseIf n = 2 Then
                query = "SELECT tor_sub_desc FROM dbType_of_Request_sub WHERE tor_id = " & bypas_tor_id_or_tor_sub_id
            ElseIf n = 3 Then
                query = "SELECT b.in_out_desc FROM dbtor_sub_property a INNER JOIN dbinout b ON a.inout_id = b.inout_id WHERE a.tor_sub_id = " & bypas_tor_id_or_tor_sub_id 'tor_sub_id
            ElseIf n = 4 Then
                'query = "SELECT tor_sub_desc FROM dbType_of_Request_sub WHERE tor_sub_id IN (1,2,11)"
                '06/04/24 - king
                query = "select a.tor_sub_desc, b.tor_desc from dbType_of_Request_sub a "
                query &= "Left join dbType_of_Request b "
                query &= $"on b.tor_id = a.tor_id where UPPER(b.tor_desc) = '{typeOfRequest.ToUpper()}'"
            End If

            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader
            While newDR.Read
                If n = 1 Then
                    cbox.Items.Add(newDR.Item("tor_desc").ToString)
                ElseIf n = 2 Then
                    cbox.Items.Add(newDR.Item("tor_sub_desc").ToString)
                ElseIf n = 3 Then
                    cbox.Items.Add(newDR.Item("in_out_desc").ToString)
                ElseIf n = 4 Then
                    cbox.Items.Add(newDR.Item("tor_sub_desc").ToString)
                End If

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

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

        ElseIf cmbRequestType.Text = "OTHERS" Then
            Select Case cmbTypeofCharge.Text
                Case "SHOPS"
                    others_charge_to_id("SHOPS")
                Case "PROJECT"
                    others_charge_to_id("PROJECT")
                Case "EQUIPMENT"
                    others_charge_to_id("EQUIPMENT")
                Case "CASH"
                    If lblcharge_for_cash.Text = "PROJECT" Then
                        others_charge_to_id("PROJECT")
                    ElseIf lblcharge_for_cash.Text = "EQUIPMENT" Then
                        others_charge_to_id("EQUIPMENT")
                    ElseIf lblcharge_for_cash.Text = "SHOPS" Then
                        others_charge_to_id("SHOPS")
                    ElseIf lblcharge_for_cash.Text = "ADFIL" Then
                        others_charge_to_id("ADFIL")
                    End If
            End Select
        End If



    End Sub

    Public Function others_charge_to_id(ByVal type As String)
        Dim sqlcon As New SQLcon
        Try
            'sqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
            'sqlcon.sql_connect()

            sqlcon.connection1.Open()
            Select Case type
                Case "SHOPS"
                    publicquery = "SELECT proj_id FROM dbprojectdesc WHERE project_desc = '" & cmbChargeTo.Text & "'"
                Case "PROJECT"
                    publicquery = "SELECT proj_id FROM dbprojectdesc WHERE project_desc = '" & cmbChargeTo.Text & "'"
                Case "EQUIPMENT"
                    publicquery = "SELECT equipListID FROM dbequipment_list WHERE plate_no = '" & cmbChargeTo.Text & "'"
                Case "ADFIL"

            End Select


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
    End Function

    Private Sub cmbInOut_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbInOut.SelectedIndexChanged
        'clear_charge_to()

        'inout_id = get_id("dbinout", "in_out_desc", cmbInOut.Text, 0)
        'set_type_of_request(cmbInOut.Text)

    End Sub
    Public Sub set_type_of_request(ByVal inout As String)

        cmbTypeofCharge.Items.Clear()

        If inout = "IN" Then
            cmbTypeOfPurchase.Items.Clear()
            cmbTypeOfPurchase.Items.Add("CASH")
            cmbTypeOfPurchase.Items.Add("PURCHASE ORDER")
            cmbTypeOfPurchase.Items.Add("DR")

            btnforQuarry.Visible = True
            cmbTypeofCharge.Items.Clear()
            cmbTypeofCharge.Items.Add("ADFIL")
            cmbTypeofCharge.Items.Add("OUTSOURCE")
            cmbTypeOfPurchase.Items.Add("N/A")
            txtUnit.Clear()

            txtItemDesc.Enabled = False
            PictureBox2.Enabled = True
            PictureBox2.Image = My.Resources.Plus_sign
            'txtUnit.Enabled = False
            btnforQuarry.Visible = False

        ElseIf inout = "OUT" Then
            cmbTypeOfPurchase.Items.Clear()
            cmbTypeOfPurchase.Items.Add("WITHDRAWAL")

            txtItemDesc.Enabled = False
            PictureBox2.Enabled = True
            PictureBox2.Image = My.Resources.Plus_sign
            'txtUnit.Enabled = False
            btnforQuarry.Visible = False
            txtUnit.Clear()


        ElseIf inout = "OTHERS" Then
            cmbTypeOfPurchase.Items.Clear()
            cmbTypeOfPurchase.Items.Add("CASH")
            cmbTypeOfPurchase.Items.Add("PURCHASE ORDER")
            cmbTypeOfPurchase.Items.Add("DR")

            txtItemDesc.Enabled = True
            PictureBox2.Enabled = True
            PictureBox2.Image = My.Resources.Plus_sign
            'txtUnit.Enabled = True
            btnforQuarry.Visible = False

        ElseIf inout = "FACILITIES" Or inout = "TOOLS" Or inout = "ADD-ON" Then

            txtItemDesc.Enabled = False
            PictureBox2.Enabled = True
            PictureBox2.Image = My.Resources.Plus_sign
            txtUnit.Enabled = True

            cmbTypeOfPurchase.Items.Clear()
            cmbTypeOfPurchase.Items.Add("PURCHASE ORDER")
            cmbTypeOfPurchase.Items.Add("CASH")
            btnforQuarry.Visible = False
            'txtUnit.Enabled = True

        ElseIf inout = "QUARRY-IN" Then
            cmbTypeOfPurchase.Items.Clear()
            'cmbTypeOfPurchase.Items.Add("N/A")

            txtItemDesc.Enabled = False
            PictureBox2.Enabled = True
            PictureBox2.Image = My.Resources.Plus_sign
            'txtUnit.Enabled = True

            btnforQuarry.Visible = True
            cmbTypeofCharge.Items.Clear()
            cmbTypeofCharge.Items.Add("ADFIL")
            cmbTypeofCharge.Items.Add("OUTSOURCE")

            cmbTypeOfPurchase.Items.Add("N/A")
            cmbTypeOfPurchase.Items.Add("PURCHASE ORDER")
            cmbTypeOfPurchase.Items.Add("CASH")
        End If

        'Select Case cmbRequestType.Text
        '    Case "MAJOR"
        '        cmbTypeofCharge.Items.Clear()
        '        load_type_of_request("EQUIPMENT-PERSONAL-CASH-PROJECT-WAREHOUSE-SUPPLIER", cmbTypeofCharge)
        '        txtChargeTo.Visible = True
        '    Case "MINOR"
        '        load_type_of_request("EQUIPMENT-PERSONAL-CASH-PROJECT-WAREHOUSE-SUPPLIER", cmbTypeofCharge)
        '        txtChargeTo.Visible = True
        '    Case "EQUIPMENT"
        '        load_type_of_request("EQUIPMENT-PERSONAL-CASH-PROJECT-WAREHOUSE-SUPPLIER", cmbTypeofCharge)

        '    Case "ADMIN AND MISC."
        '        load_type_of_request("EQUIPMENT-PERSONAL-CASH-PROJECT-WAREHOUSE-SUPPLIER", cmbTypeofCharge)

        '    Case "BORROWER"
        '        load_type_of_request("EQUIPMENT-PERSONAL-CASH-PROJECT-WAREHOUSE-SUPPLIER", cmbTypeofCharge)

        '        'cmbTypeofCharge.Items.Add("ADFIL")
        '        'cmbTypeofCharge.Items.Add("PERSONAL")
        '        'cmbTypeofCharge.Items.Add("CASH")
        '        'cmbTypeofCharge.Items.Add("WAREHOUSE")

        'End Select

    End Sub
    Public Sub load_type_of_request(ByVal excemption As String, ByVal obj As Object)
        Dim n As Integer = 0
        Dim splitex(10) As String

        Dim cmbox As ComboBox = obj

        Dim s() As String
        s = excemption.Split("-")

        Try
            SQ.connection.Open()
            Dim query As String = "SELECT * FROM dbType_of_charges"
            cmd = New SqlCommand(query, SQ.connection)
            dr = cmd.ExecuteReader

            While dr.Read
                splitex(n) = dr.Item("type_of_charges").ToString
                n += 1
            End While
            dr.Close()

            For i = 0 To s.Count - 1
                For ii = 0 To splitex.Count - 1
                    If s(i) = splitex(ii) Then
                        splitex(ii) = ""
                    End If
                Next
            Next

            For ii = 0 To splitex.Count - 1
                If splitex(ii) = "" Then
                Else
                    cmbox.Items.Add(splitex(ii))
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

    End Sub
    Public Function include_type_of_charges()
 
    End Function
    'Public Sub select_type_of_request(ByVal inout As String)

    '    Select Case cmbRequestType.Text

    '        Case "SUPPLY"
    '            Select Case inout
    '                Case "IN"
    '                    cmbTypeofCharge.Enabled = False
    '                Case "OUT"
    '                    cmbTypeofCharge.Enabled = True

    '                    cmbTypeofCharge.Items.Add("ADFIL")
    '                    cmbTypeofCharge.Items.Add("EQUIPMENT")
    '                    cmbTypeofCharge.Items.Add("PROJECT")
    '                    cmbTypeofCharge.Items.Add("SHOPS")
    '                    cmbTypeofCharge.Items.Add("WAREHOUSE")

    '                Case "OTHERS"

    '            End Select

    '        Case "EQUIPMENT"
    '            Select Case inout
    '                Case "OUT"

    '                Case "OTHERS"
    '            End Select

    '        Case "PROJECT"
    '            Select Case inout
    '                Case "IN"

    '                Case "OUT"

    '                Case "OTHERS"
    '            End Select

    '        Case "OTHERS"

    '    End Select

    'End Sub

    Public Sub clear_charge_to()
        wh_id = 0
        cmbChargeTo.Items.Clear()
        txtChargeTo.Clear()
    End Sub

    Public Sub load_chargetype()

        cmbTypeofCharge.Items.Add("ADFIL")
        cmbTypeofCharge.Items.Add("SHOPS")
        cmbTypeofCharge.Items.Add("PROJECT")
        cmbTypeofCharge.Items.Add("EQUIPMENT")
        cmbTypeofCharge.Items.Add("WAREHOUSE")

    End Sub
    Private Sub cmbTypeofCharge_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTypeofCharge.SelectedIndexChanged


        'If cmbTypeofCharge.Text = "SHOPS" Then
        '    cmbChargeTo.Visible = True
        '    txtChargeTo.Visible = False


        '    load_equipment(2)
        'ElseIf cmbTypeofCharge.Text = "PROJECT" Then
        '    cmbChargeTo.Visible = True
        '    txtChargeTo.Visible = False


        '    load_equipment(1)

        'ElseIf cmbTypeofCharge.Text = "EQUIPMENT" Then
        '    cmbChargeTo.Visible = True
        '    txtChargeTo.Visible = False


        '    load_equipment(0)

        'ElseIf cmbTypeofCharge.Text = "PERSONAL" Then
        '    PictureBox2.Visible = True : PictureBox2.Image = My.Resources.Plus_sign

        'ElseIf cmbTypeofCharge.Text = "CASH" Then

        '    PictureBox2.Image = My.Resources.Plus_sign

        '    For Each ctr As Control In Me.Controls
        '        If TypeOf ctr Is Panel Then
        '            ctr.Visible = True
        '        Else
        '            ctr.Enabled = False
        '        End If
        '    Next
        '    PictureBox2.Visible = False
        'Else

        '    cmbChargeTo.Visible = False
        '    txtChargeTo.Visible = True

        'End If

        Select Case cmbTypeofCharge.Text
            Case "ADFIL"
                cmbChargeTo.Visible = False
                txtChargeTo.Visible = True

                txtChargeTo.Clear()
                txtChargeTo.Text = "ADFIL"
                charge_to_id = get_id("dbCharge_to", "charge_to", "ADFIL", 0)

            Case "OUTSOURCE"
                cmbChargeTo.Visible = False
                txtChargeTo.Visible = True

                txtChargeTo.Clear()
                txtChargeTo.Text = "OUTSOURCE"
                charge_to_id = get_id("dbCharge_to", "charge_to", "OUTSOURCE", 0)

            Case "PROJECT"
                cmbChargeTo.Visible = True
                txtChargeTo.Visible = False
                load_equipment(1, cmbChargeTo)

                txtChargeTo.Clear()
                charge_to_id = 0

            Case "EQUIPMENT"
                cmbChargeTo.Visible = True
                txtChargeTo.Visible = False
                load_equipment(0, cmbChargeTo)

                txtChargeTo.Clear()
                charge_to_id = 0

            Case "PERSONAL"
                cmbChargeTo.Visible = False
                txtChargeTo.Visible = True

                txtChargeTo.Clear()
                charge_to_id = 0

            Case "WAREHOUSE"
                cmbChargeTo.Visible = False
                txtChargeTo.Visible = True

                txtChargeTo.Clear()
                charge_to_id = 0
            Case "CASH"
                cmbChargeTo.Visible = False
                txtChargeTo.Visible = True

                txtChargeTo.Clear()
                charge_to_id = 0


            Case "JQG"
                txtChargeTo.Clear()
                txtChargeTo.Text = "JQG"
            Case "BBC"
                txtChargeTo.Clear()
                txtChargeTo.Text = "BBC"
        End Select
    End Sub

    Private Sub txtQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQty.TextChanged

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

    Private Sub txtUnit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUnit.TextChanged

    End Sub
    Public Sub getUnit(ByVal n As Integer)
        Dim counter As Integer = 0
        Dim newSQ As New SQLcon
        Dim sqlComm As New SqlCommand()
        Dim dr As SqlDataReader

        Try
            newSQ.connection.Open()

            sqlComm.Connection = newSQ.connection
            sqlComm.CommandText = "proc_request_slip"
            sqlComm.CommandType = CommandType.StoredProcedure

            If n = 0 Then
                sqlComm.Parameters.AddWithValue("@unit", txtUnit.Text)
                sqlComm.Parameters.AddWithValue("@crud", "get_Unit")
            ElseIf n = 1 Then
                sqlComm.Parameters.AddWithValue("@reqBy", txtRequestBy.Text)
                sqlComm.Parameters.AddWithValue("@crud", "get_requestedby")
            ElseIf n = 2 Then
                sqlComm.Parameters.AddWithValue("@notedBy", txtNotedBy.Text)
                sqlComm.Parameters.AddWithValue("@crud", "get_notedby")
            ElseIf n = 3 Then
                sqlComm.Parameters.AddWithValue("@approvedBy", txtApprovedby.Text)
                sqlComm.Parameters.AddWithValue("@crud", "get_approved_by")
            ElseIf n = 4 Then
                sqlComm.Parameters.AddWithValue("@warehouseIncharge", txtWarehouseIncharge.Text)
                sqlComm.Parameters.AddWithValue("@crud", "get_wh_incharge")
            End If

            dr = sqlComm.ExecuteReader

            While dr.Read
                If n = 0 Then
                    lboxUnit.Items.Add(dr.Item("unit").ToString)
                    counter += 1
                ElseIf n = 1 Then
                    lboxUnit.Items.Add(dr.Item("requested_by").ToString)
                    counter += 1
                ElseIf n = 2 Then
                    lboxUnit.Items.Add(dr.Item("noted_by").ToString)
                    counter += 1
                ElseIf n = 3 Then
                    lboxUnit.Items.Add(dr.Item("approved_by").ToString)
                    counter += 1
                ElseIf n = 4 Then
                    lboxUnit.Items.Add(dr.Item("wh_incharge").ToString)
                    counter += 1
                End If

            End While

            If counter > 0 Then
                lboxUnit.Visible = True
            Else
                lboxUnit.Visible = False
            End If

            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub lboxUnit_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lboxUnit.DoubleClick

        If lboxUnit.Items.Count > 0 Then

            For Each ctr As Control In Me.Controls
                If ctr.Name = tboxname Then
                    ctr.Text = lboxUnit.SelectedItem.ToString
                    ctr.Focus()
                    lboxUnit.Visible = False
                    lboxUnit.Items.Clear()
                    Exit Sub
                End If
            Next

            If tboxname = "cmbContractName" Then
                txtConsItemDesc.Text = lboxUnit.SelectedItem.ToString
                txtConsItemDesc.Focus()
                lboxUnit.Visible = False
                lboxUnit.Items.Clear()
                Exit Sub
            End If
        End If

    End Sub

    Private Sub lboxUnit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lboxUnit.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    For Each ctr As Control In Me.Controls
        '        If ctr.Name = txtname Then
        '            ctr.Text = lboxUnit.SelectedItem.ToString
        '            'txtProjName.ReadOnly = False
        '            ctr.Focus()
        '        End If
        '    Next

        '    lboxUnit.Visible = False
        'End If

        If e.KeyCode = Keys.Enter Then

            If lboxUnit.Items.Count > 0 Then

                For Each ctr As Control In Me.Controls
                    If ctr.Name = tboxname Then
                        ctr.Text = lboxUnit.SelectedItem.ToString
                        ctr.Focus()
                        lboxUnit.Visible = False
                        lboxUnit.Items.Clear()
                        Exit Sub
                    End If
                Next

                If tboxname = "cmbContractName" Then
                    txtConsItemDesc.Text = lboxUnit.SelectedItem.ToString
                    txtConsItemDesc.Focus()
                    lboxUnit.Visible = False
                    lboxUnit.Items.Clear()
                    cmbContractName.Select(cmbContractName.Text.Length, 0)

                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub lboxUnit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lboxUnit.SelectedIndexChanged

    End Sub

    Private Sub txtRequestBy_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRequestBy.TextChanged
        'Try
        '    If txtRequestBy.Text = "" Then
        '        lboxUnit.Location = New System.Drawing.Point(txtRequestBy.Location.X, txtRequestBy.Location.Y + txtRequestBy.Height)
        '    Else
        '        With lboxUnit
        '            .Location = New System.Drawing.Point(txtRequestBy.Location.X, txtRequestBy.Location.Y + txtRequestBy.Height)
        '            .Visible = True
        '            .Items.Clear()
        '            .Width = txtRequestBy.Width
        '        End With

        '        getUnit(1)
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub txtNotedBy_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNotedBy.TextChanged
        'Try
        '    If txtNotedBy.Text = "" Then
        '        lboxUnit.Location = New System.Drawing.Point(txtNotedBy.Location.X, txtNotedBy.Location.Y + txtNotedBy.Height)
        '    Else
        '        With lboxUnit
        '            .Location = New System.Drawing.Point(txtNotedBy.Location.X, txtNotedBy.Location.Y + txtNotedBy.Height)
        '            .Visible = True
        '            .Items.Clear()
        '            .Width = txtNotedBy.Width
        '        End With

        '        getUnit(2)
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub txtApprovedby_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtApprovedby.TextChanged
        Try
            If txtApprovedby.Text = "" Then
                lboxUnit.Location = New System.Drawing.Point(txtApprovedby.Location.X, txtApprovedby.Location.Y + txtApprovedby.Height)
            Else
                With lboxUnit
                    .Location = New System.Drawing.Point(txtApprovedby.Location.X, txtApprovedby.Location.Y + txtApprovedby.Height)
                    .Visible = True
                    .Items.Clear()
                    .Width = txtApprovedby.Width
                End With

                getUnit(3)
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtWarehouseIncharge_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWarehouseIncharge.TextChanged
        Try
            If txtWarehouseIncharge.Text = "" Then
                lboxUnit.Location = New System.Drawing.Point(txtWarehouseIncharge.Location.X, txtWarehouseIncharge.Location.Y + txtWarehouseIncharge.Height)

            Else
                With lboxUnit
                    .Location = New System.Drawing.Point(txtWarehouseIncharge.Location.X, txtWarehouseIncharge.Location.Y + txtWarehouseIncharge.Height)
                    .Visible = True
                    .Items.Clear()
                    .Width = txtWarehouseIncharge.Width
                End With

                getUnit(4)
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is Panel Then
                ctr.Visible = False
            Else
                ctr.Enabled = True
            End If
        Next
    End Sub

    Private Sub btnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoose.Click
        'If cmbCharges.Text = "EQUIPMENT" Then
        '    btnClose.PerformClick()

        '    cmbChargeTo.Visible = True
        '    txtChargeTo.Visible = False

        '    load_equipment(0)
        '    pboxcharges.Visible = False

        '    lblcharge_for_cash.Text = cmbCharges.Text
        '    cmbChargeTo.Text = lblchargename.Text

        'ElseIf cmbCharges.Text = "PROJECT" Then
        '    btnClose.PerformClick()

        '    cmbChargeTo.Visible = True
        '    txtChargeTo.Visible = False

        '    load_equipment(1)

        '    lblcharge_for_cash.Text = cmbCharges.Text
        '    cmbChargeTo.Text = lblchargename.Text
        'ElseIf cmbCharges.Text = "SHOPS" Then
        '    btnClose.PerformClick()

        '    cmbChargeTo.Visible = True
        '    txtChargeTo.Visible = False

        '    load_equipment(2)

        '    lblcharge_for_cash.Text = cmbCharges.Text
        '    cmbChargeTo.Text = lblchargename.Text

        'ElseIf cmbCharges.Text = "ADFIL" Then
        '    btnClose.PerformClick()
        '    lblcharge_for_cash.Text = cmbCharges.Text
        '    txtChargeTo.Text = lblchargename.Text

        'ElseIf cmbCharges.Text = "MAJOR" Then


        'ElseIf cmbCharges.Text = "MINOR" Then

        '    For Each ctr As Control In Me.Controls
        '        If ctr.Name = "pboxcharges" Then
        '            ctr.Visible = False
        '        Else
        '            ctr.Enabled = True
        '        End If
        '    Next
        '    wh_item_destination = 1
        '    FListOfItems.lblInOut.Text = "OUT"
        '    FListOfItems.ShowDialog()

        'End If

        'txtLoc.Focus()

        For Each ctr As Control In Me.Controls
            If ctr.Name = "pboxcharges" Then
                ctr.Visible = False
            Else
                ctr.Enabled = True
            End If
        Next

        cmbTypeOfPurchase.Text = cmbCharges.Text

    End Sub

    Private Sub btnViewMultipleCharges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewMultipleCharges.Click
        FProjectIncharge.lbl_sign.Text = "R"

      
        With FProjectIncharge
            .lvlListofCharges.Items.Clear()

            .load_all(.lvlListofCharges, 0, "PROJECT")
            .load_all(.lvlListofCharges, 0, "MAINOFFICE")
            .load_all(.lvlListofCharges, 0, "PERSONAL")
            .load_all(.lvlListofCharges, 0, "EQUIPMENT")
            .load_all(.lvlListofCharges, 0, "WAREHOUSE")

        End With

        FProjectIncharge.btnOk.Text = "UPDATE"
        FProjectIncharge.ShowDialog()


    End Sub

    Private Sub btnforQuarry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnforQuarry.Click
        For Each ctr As Control In Me.Controls
            If ctr.Name = "QuarryPanel" Then
                ctr.Location = New Point(86, 103)
                ctr.Visible = True
                ctr.BringToFront()
            Else
                ctr.Enabled = False
            End If
        Next

        If btnSave.Text = "Update" Then
            btnView.PerformClick()

        Else

        End If

    End Sub

    Private Sub QuarryPanelClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuarryPanelClose.Click
        For Each ctr As Control In Me.Controls
            If ctr.Name = "QuarryPanel" Then
                ctr.Location = New Point(783, 93)
                ctr.Visible = False

            Else
                ctr.Enabled = True
            End If
        Next
    End Sub

    Private Sub cmbTypeOfPurchase_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTypeOfPurchase.SelectedIndexChanged
        If cmbTypeOfPurchase.Text = "N/A" Then
            'btnforQuarry.Visible = True
            cmbTypeofCharge.Items.Clear()
            cmbTypeofCharge.Items.Add("ADFIL")
            cmbTypeofCharge.Items.Add("OUTSOURCE")

        ElseIf cmbTypeOfPurchase.Text = "DR" Then
            btnforQuarry.Visible = True
            cmbTypeofCharge.Items.Clear()
            cmbTypeofCharge.Items.Add("ADFIL")
            cmbTypeofCharge.Items.Add("OUTSOURCE")
        Else

            'btnforQuarry.Visible = False
            If cmbInOut.Text = "QUARRY-IN" Then
                btnforQuarry.Visible = True
                cmbTypeofCharge.Items.Clear()
                cmbTypeofCharge.Items.Add("ADFIL")
                cmbTypeofCharge.Items.Add("OUTSOURCE")
            Else
                cmbTypeofCharge.Items.Clear()
                cmbTypeofCharge.Items.Add("ADFIL")
            End If
       


        End If
    End Sub

    Private Sub QuarryPanelSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuarryPanelSave.Click
        If txtQarryName.Text = "" Then
            MessageBox.Show("Fillup Quarry name field..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtQarryName.Focus()

        ElseIf txtQuarryLoc.Text = "" Then
            MessageBox.Show("Fillup Quarry location field..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtQuarryLoc.Focus()
        Else
            If QuarryPanelSave.Text = "Save" Then
                quarry_save_update(1)
            Else
                quarry_save_update(2)
            End If
 
        End If


    End Sub

    Private Sub quarry_save_update(ByVal n As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()

            newCMD = New SqlCommand("proc_quarry_query", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", n)

            If n = 1 Then

            ElseIf n = 2 Then
                newCMD.Parameters.AddWithValue("@quarry_id", CInt(lvlQuarry.SelectedItems(0).Text))
            End If

            newCMD.Parameters.AddWithValue("@quarry_name", txtQarryName.Text)
            newCMD.Parameters.AddWithValue("@quarry_loc", txtQuarryLoc.Text)
            newCMD.Parameters.AddWithValue("@quarry_property", cmbProperty.Text)

            If n = 1 Then
                Dim res As Integer = newCMD.ExecuteScalar()

                Load_quarry_loc()
                listfocus(lvlQuarry, res)

            ElseIf n = 2 Then
                newCMD.ExecuteNonQuery()
                Dim id As Integer = CInt(lvlQuarry.SelectedItems(0).Text)
                Load_quarry_loc()
                btnView.PerformClick()
                listfocus(lvlQuarry, id)
            End If
            
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
            MessageBox.Show("Successfully Saved..", "Supply INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub Load_quarry_loc()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newdr As SqlDataReader
        Dim a(10) As String

        lvlQuarry.Items.Clear()


        Try
            newSQ.connection.Open()


            newCMD = New SqlCommand("proc_quarry_query", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 3)
            newCMD.Parameters.AddWithValue("@quarry_name", txtQarryName.Text)
            newCMD.Parameters.AddWithValue("@quarry_loc", txtQuarryLoc.Text)

            newdr = newCMD.ExecuteReader
            While newdr.Read
                a(0) = newdr.Item("quarry_id").ToString
                a(1) = newdr.Item("quarry_name").ToString
                a(2) = newdr.Item("quarry_location").ToString
                a(3) = newdr.Item("property").ToString

                If newdr.Item("property").ToString = cmbTypeofCharge.Text Then
                    Dim lvl As New ListViewItem(a)
                    lvlQuarry.Items.Add(lvl)
                End If

                If btnSave.Text = "Save" Then

                ElseIf btnSave.Text = "Update" Then

                End If

            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

        End Try
    End Sub
    Public Sub load_warehousearea()
        lvlQuarry.Items.Clear()

        publicquery = "SELECT * FROM dbwh_area"
        SELECT_QUERY(publicquery, 3, lvlQuarry, "5-5", -1)

    End Sub

    Public Sub load_equipment()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim a(10) As String
        lvlQuarry.Items.Clear()

        Try
            newSQ.connection1.Open()
            Dim query As String = "SELECT a.equipListID,a.plate_no,b.equip_typeOf FROM dbequipment_list a "
            query &= "INNER JOIN dbequipment_type b "
            query &= "ON a.equipTypeID = b.equipTypeID "
            query &= "WHERE b.equip_typeOf = 'CRUSHER PLANT' OR b.equip_typeOf = 'MOBILE CRUSHER'"

            newCMD = New SqlCommand(query, newSQ.connection1)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                a(0) = newDR.Item("equipListID").ToString
                a(1) = newDR.Item("plate_no").ToString
                a(2) = newDR.Item("equip_typeOf").ToString

                Dim lvl As New ListViewItem(a)
                lvlQuarry.Items.Add(lvl)

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection1.Close()
        End Try

    End Sub
    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        If btnView.Text = "Cancel" Then
            lvlQuarry.Enabled = True
            QuarryPanelSave.Text = "Save"
            btnView.Text = "View"
        Else
            If cmbSelectSource.Text = "QUARRY" Then
                Load_quarry_loc()
                If btnSave.Text = "Update" Then
                    item_checking()
                End If

            ElseIf cmbSelectSource.Text = "WAREHOUSE" Then
                load_warehousearea()

            ElseIf cmbSelectSource.Text = "EQUIPMENT" Then
                load_equipment()
            End If

        End If


    End Sub
    Private Sub item_checking()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()

            Dim rs_id As Integer = CInt(FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text)
            Dim query As String = "SELECT * FROM dbquary_charges WHERE rs_id = " & rs_id

            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader
            Dim a(10) As String
            While newDR.Read

                Dim quarry_id As Integer = CInt(newDR.Item("quarry_id").ToString)
                a(0) = quarry_id

                Dim checkInt As Integer = FindItem(lvlQuarry, quarry_id) 'DTPTripForDelete.Text)
                If checkInt <> -1 Then
                    lvlQuarry.Items(checkInt).Checked = True
                End If

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()


        End Try
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click

        lvlQuarry.Enabled = False
        QuarryPanelSave.Text = "Update"
        btnView.Text = "Cancel"

        txtQarryName.Text = lvlQuarry.SelectedItems(0).SubItems(1).Text
        txtQuarryLoc.Text = lvlQuarry.SelectedItems(0).SubItems(2).Text

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        QuarryPanelClose.PerformClick()
        btnViewMultipleCharges.Enabled = False

    End Sub

    Private Sub cmbTOR_sub_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTOR_sub.SelectedIndexChanged
        tor_sub_id = get_id("dbType_of_Request_sub", "tor_sub_desc", cmbTOR_sub.Text, 0)
        load_type_of_request_and_sub(3, cmbInOut, tor_sub_id)

    End Sub

    Private Sub txtRSno_TextChanged(sender As Object, e As EventArgs) Handles txtRSno.TextChanged

    End Sub

    Public Sub btnUnitFocus_Click(sender As Object, e As EventArgs) Handles btnUnitFocus.Click
        txtUnit.Focus()

    End Sub

    Private Sub grpStatus_Enter(sender As Object, e As EventArgs) Handles grpStatus.Enter

    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        FConstruction_Items.ShowDialog()

    End Sub

    Private Sub txtConsItemDesc_TextChanged(sender As Object, e As EventArgs) Handles txtConsItemDesc.TextChanged

    End Sub

    Private Sub txtConsItemDesc_MouseHover(sender As Object, e As EventArgs) Handles txtConsItemDesc.MouseHover
        ToolTip1.Active = True
        ToolTip1.Show(txtConsItemDesc.Text, txtConsItemDesc)
    End Sub

    'Private Sub get_rs_info_TextChanged(sender As Object, e As EventArgs) Handles txtLoc.TextChanged, txtRequestBy.TextChanged, txtNotedBy.TextChanged, txtUnit.TextChanged
    '    Dim txtbox As TextBox = sender
    '    Try
    '        If txtbox.Text = "" Then
    '            lboxUnit.Location = New System.Drawing.Point(txtbox.Location.X, txtbox.Location.Y + txtbox.Height)
    '            lboxUnit.Visible = False
    '        Else
    '            lboxUnit.Visible = True
    '            With lboxUnit
    '                .Location = New System.Drawing.Point(txtbox.Location.X, txtbox.Location.Y + txtbox.Height)
    '                .Visible = True
    '                .Items.Clear()
    '                .Width = txtbox.Width
    '            End With

    '            get_rs_info(sender.name, txtbox.Text, txtbox)

    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    Public Function get_rs_info(field As String, search As String, txtbox As TextBox)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        lboxUnit.Items.Clear()
        tboxname = txtbox.Name
        Dim count As Integer

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_requisition_slip", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 19)
            newCMD.Parameters.AddWithValue("@field", field)
            newCMD.Parameters.AddWithValue("@search", search)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                lboxUnit.Items.Add(newDR.Item(0).ToString)
                count += 1
            End While

            If count = 0 Then
                lboxUnit.Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Private Sub txt_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtLoc.PreviewKeyDown, txtUnit.PreviewKeyDown, txtPurpose.PreviewKeyDown, txtRequestBy.PreviewKeyDown, txtNotedBy.PreviewKeyDown, lboxUnit.PreviewKeyDown, txtItemDesc.PreviewKeyDown, txtUnit.PreviewKeyDown

        If e.KeyCode = Keys.Tab Then
            If lboxUnit.Visible = True Then
                lboxUnit.Visible = False
            End If
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim rs_id As Integer = FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text
        Dim query As String = "UPDATE dbrequisition_slip SET qty = " & old_qty & " WHERE rs_id = " & rs_id
        UPDATE_INSERT_DELETE_QUERY(query, 0, "UPDATE")

        FRequistionForm.load_rs_3(13)
        listfocus(FRequistionForm.lvlrequisitionlist, rs_id)

        Panel1.Visible = False
    End Sub

    Private Sub btnProceed_Click(sender As Object, e As EventArgs) Handles btnProceed.Click

        Dim count_ws_qty As Double = 0
        For Each row As ListViewItem In ListView1.Items
            count_ws_qty += CDbl(row.SubItems(2).Text)
        Next

        If count_ws_qty > CDbl(txtQty.Text) Then
            If MessageBox.Show("the rs qty is less than withrawn/received items, still want to proceed?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Else
                Exit Sub
            End If
        End If

        For Each row As ListViewItem In ListView1.Items
            If row.Checked = True Then

                Dim rs_qty As Double = CDbl(txtQty.Text)
                Dim ws_qty As Double = CDbl(FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(22).Text)

                If ws_qty > rs_qty Then
                    If MessageBox.Show("hoy! engon bitaw ko nga dili pede, tarung tarunga ko hap, kung gusto ka mo proceed hala padayon..", "SUPPY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then

                    Else

                        Dim rs_id As Integer = FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text
                        Dim query As String = "UPDATE dbrequisition_slip SET qty = " & old_qty & " WHERE rs_id = " & rs_id
                        UPDATE_INSERT_DELETE_QUERY(query, 0, "UPDATE")

                        FRequistionForm.load_rs_3(13)
                        listfocus(FRequistionForm.lvlrequisitionlist, rs_id)
                        Exit Sub

                    End If
                End If

                Dim newSQ As New SQLcon
                Dim newCMD As SqlCommand

                Try
                    newSQ.connection.Open()
                    Dim query As String = "UPDATE dbPO_details SET qty = " & txtQty.Text & " WHERE po_det_id = " & row.Text
                    newCMD = New SqlCommand(query, newSQ.connection)
                    newCMD.ExecuteNonQuery()

                Catch ex As Exception
                    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    newSQ.connection.Close()
                End Try

            End If
        Next

        Me.Close()
        FRequistionForm.btnSearch.PerformClick()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        txtConsItem.Clear()
        txtConsItemDesc.Clear()

    End Sub

    Private Sub txtQty_HideSelectionChanged(sender As Object, e As EventArgs) Handles txtQty.HideSelectionChanged

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles pboxqtyoff.Click
        pub_button_name = "pboxqtyoff"
        FQTO_Maintenance.ShowDialog()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        pub_qto_id = 0
        txtQtyTakeOff.Clear()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        FRequistionForm.FlowLayoutPanel1.Enabled = True
        FRequistionForm.btnSearch.Enabled = True
        FRequistionForm.btnSearch.PerformClick()
    End Sub

    Private Sub cmbContractName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbContractName.SelectedIndexChanged
        lboxUnit.Parent = Me
        With lboxUnit
            .Location = New System.Drawing.Point(cmbContractName.Location.X + 20, cmbContractName.Location.Y + cmbContractName.Height + 63)
            .Visible = True
            .Items.Clear()
            .Width = cmbContractName.Width
        End With

        Dim key As String
        Dim value As String
        'MessageBox.Show(key & "   " & value)

        If cmbContractName.SelectedIndex = -1 Then
            lboxUnit.Visible = False
        Else
            key = DirectCast(cmbContractName.SelectedItem, KeyValuePair(Of String, String)).Key
            value = DirectCast(cmbContractName.SelectedItem, KeyValuePair(Of String, String)).Value
        End If

        txtConsItemDesc.Clear()


        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_QTO_maintenance", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 16)
            newCMD.Parameters.AddWithValue("@contract_id", key)

            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                'txtConsItemDesc.Text = newDR.Item("contract_item_desc").ToString
                lboxUnit.Items.Add(newDR.Item("contract_item_desc").ToString)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

            If lboxUnit.Items.Count = 1 Then
                If lboxUnit.Items(0) = "" Then
                    lboxUnit.Visible = False
                End If
            ElseIf lboxUnit.Items.Count = 0 Then
                lboxUnit.Visible = False
            End If

            lboxUnit.BringToFront()

        End Try

    End Sub



    Private Sub pboxTempItems_Click(sender As Object, e As EventArgs)
        FRequesition_SearchItem.ShowDialog()

    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        cmbContractName.SelectedIndex = -1
        txtConsItem.Clear()
    End Sub

    Private Sub cmbContractName_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbContractName.KeyDown
        If e.KeyCode = Keys.Enter Then
            sender.DroppedDown = False
            lboxUnit.Focus()

            If lboxUnit.Items.Count > 0 Then
                lboxUnit.SelectedIndex = 0
            End If

        End If

        sender.DroppedDown = True
    End Sub

    Private Sub cmbContractName_GotFocus(sender As Object, e As EventArgs) Handles cmbContractName.GotFocus
        sender.DroppedDown = True
        tboxname = cmbContractName.Name
    End Sub

    Private Sub PictureBox6_Click_1(sender As Object, e As EventArgs) Handles PictureBox6.Click
        FReq_qty_takeOff.ShowDialog()
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        With FLinkToProperNaming
            .isFromRequestFields = True

            .ShowDialog()
        End With
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        lblProperNaming.Text = "link to proper naming"
    End Sub

    Private Sub FRequestField_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Dispose()
    End Sub
End Class