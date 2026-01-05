
Imports System.Data.Sql
Imports System.Data.SqlClient


Public Class FCharge_To
    Public conn As New SQLcon
    Dim operatorCancel As Boolean = False

    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Public forDrWithoutRs As Integer
    Public forStockpileLocation,
        forZoning,
        forZoningSource,
        forWarehouseProperName,
        forSaveWarehouseProperName,
        forSaveWarehouseProperNameNew As Boolean

    Public forWhItemsProjectSiteAndOthers As Boolean

    Dim IsFormBeingDragged As Boolean
    Dim drag As Boolean
    Dim MouseDownX As Integer
    Dim MouseDownY As Integer

    Private cAllChargesModel As New ModelNew.Model
    Dim cBgWorkerChecker As Timer
    Private cCustomMsg As New customMessageBox
    Private cListOfAllCharges As New List(Of PropsFields.AllCharges)
    Private cListOfListviewItem As New List(Of ListViewItem)
    Private cSearch As String
    Public cId As Integer

    Public cListOfPendingDr As New List(Of PropsFields.create_dr_props_fields)
    Public cDgv As New DataGridView

    ' this is code is for dropshadow on form
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Const DROPSHADOW = &H20000
            Dim cParam As CreateParams = MyBase.CreateParams
            cParam.ClassStyle = cParam.ClassStyle Or DROPSHADOW
            Return cParam
        End Get

    End Property

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
    Private Sub showdata()
        lvList.Items.Clear()
        Try
            conn.connection.Open()
            Dim cmd As SqlCommand
            Dim dr As SqlDataReader
            Dim query As String = "select a.*, b.username from dbCharge_to a left join dbregistrationform b on a.user_id = b.user_id order by a.charge_to_id asc"
            cmd = New SqlCommand(query, conn.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim a(5) As String
                a(0) = dr.Item(0).ToString
                a(1) = dr.Item(1).ToString
                a(2) = dr.Item(2).ToString
                a(3) = dr.Item(5).ToString
                'txtId.Text = a(0) + 1
                Dim lvl As New ListViewItem(a)
                lvList.Items.Add(lvl)
            End While
            dr.Close()
            conn.connection.Close()
            ' listfocus(lvlList, txtId.Text)
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub InsertNewRecord()
        conn.connection.Open()
        Dim sqlComm As New SqlCommand()
        sqlComm.Connection = conn.connection
        sqlComm.CommandText = "sp_Insert_Charge_To"
        sqlComm.CommandType = CommandType.StoredProcedure
        sqlComm.Parameters.AddWithValue("@ChargeTo", txt_Save.Text)
        sqlComm.Parameters.AddWithValue("@typename", cmbTypeofCharge.Text)
        sqlComm.Parameters.AddWithValue("@user_id", pub_user_id)
        sqlComm.ExecuteNonQuery()
        conn.connection.Close()
        showdata() 'show data after save
        txt_Save.Text = ""
        txt_Save.Focus()
    End Sub

    Private Sub Search()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newdr As SqlDataReader

        lvList.Items.Clear()

        Try

            Dim query As String = ""

            If charge_to_selection = 1 Then

                'newSQ.connection.Open()

                'query = "SELECT * FROM dbwh_area where wh_area like '%" & txt_Search.Text.Trim & "%'"
                'newCMD = New SqlCommand(query, newSQ.connection)
                'newdr = newCMD.ExecuteReader

                'While newdr.Read
                '    Dim a(4) As String

                '    a(0) = newdr.Item(0).ToString
                '    a(1) = UCase(newdr.Item(1).ToString)
                '    a(2) = newdr.Item(2).ToString

                '    Dim lvl As New ListViewItem(a)
                '    lvList.Items.Add(lvl)

                'End While
                'newdr.Close()

            ElseIf charge_to_selection = 2 Or charge_to_selection = 3 Then

                newSQ.connection.Open()

                query = "SELECT * FROM dbCharge_to where charge_to like '%" & txt_Search.Text.Trim & "%'"
                newCMD = New SqlCommand(query, newSQ.connection)
                newdr = newCMD.ExecuteReader

                While newdr.Read
                    Dim a(4) As String

                    a(0) = newdr.Item(0).ToString
                    a(1) = UCase(newdr.Item(1).ToString)
                    a(2) = newdr.Item(2).ToString

                    Dim lvl As New ListViewItem(a)
                    lvList.Items.Add(lvl)

                End While
                newdr.Close()

            End If

            If cmbTypeofCharge.Text = "EQUIPMENT" Then

                newSQ.connection1.Open()
                query = "SELECT equipListID,plateno," & "EQUIPMENT" & "AS category FROM dbequipment_list WHERE plate_no LIKE '%" & txt_Search.Text.Trim & "%'"
                newCMD = New SqlCommand(query, newSQ.connection1)
                newdr = newCMD.ExecuteReader

                While newdr.Read
                    Dim a(4) As String

                    a(0) = newdr.Item(0).ToString
                    a(1) = UCase(newdr.Item(1).ToString)
                    a(2) = newdr.Item(2).ToString

                    Dim lvl As New ListViewItem(a)
                    lvList.Items.Add(lvl)

                End While
                newdr.Close()

            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cmbTypeofCharge.Text = "EQUIPMENT" Then
                newSQ.connection1.Close()
            Else
                newSQ.connection.Close()

            End If

        End Try

    End Sub

    Private Sub UpdateRecord()


        conn.connection.Open()
        Try
            Dim chargetoid As Integer = Val(lvList.SelectedItems(0).Text)


            Dim sqlComm As New SqlCommand

            sqlComm.Connection = conn.connection


            sqlComm.CommandText = "sp_Update_Charge_To"
            sqlComm.CommandType = CommandType.StoredProcedure

            sqlComm.Parameters.AddWithValue("@ChargeTo", txt_Save.Text)
            sqlComm.Parameters.AddWithValue("@Charge_To_Id", Val(lvList.SelectedItems(0).Text))
            sqlComm.Parameters.AddWithValue("@typename", cmbTypeofCharge.Text)

            sqlComm.ExecuteNonQuery()
            conn.connection.Close()


            MsgBox("succesfuly Updated")
            btnUpdate.Enabled = False

            load_to_list()
            listfocus(lvList, chargetoid)

            txt_Save.Focus()



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub DeleteRecord()

        conn.connection.Open()


        Dim sqlComm As New SqlCommand

        sqlComm.Connection = conn.connection

        sqlComm.CommandText = "sp_Delete_Charge_To"
        sqlComm.CommandType = CommandType.StoredProcedure

        sqlComm.Parameters.AddWithValue("@charge_to_Id", Integer.Parse(lvList.SelectedItems.Item(0).SubItems(0).Text))





        sqlComm.ExecuteNonQuery()
        conn.connection.Close()

        showdata()


    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Panel1.Visible = False
        'showdata()

        If charge_to_selection = 1 Then
            lvList.Items.Clear()
            load_charge_to(0)

            btnSearch.Enabled = False
            btnUpdate.Enabled = False
            txt_Save.Enabled = False
            btn_Save.Enabled = False

        ElseIf charge_to_selection = 2 Or charge_to_selection = 3 Then

            lvList.Items.Clear()
            load_charge_to(1)

            btnSearch.Enabled = True
            btnUpdate.Enabled = False
            txt_Save.Enabled = True
            btn_Save.Enabled = True

            view_cmb(cmbTypeofCharge, 1) 'para sa load sa combobox na cmbtypeofcharge

        ElseIf charge_to_selection = 4 Then
            lvList.Items.Clear()
            load_charge_to(2)

            btnSearch.Enabled = False
            btnUpdate.Enabled = False
            txt_Save.Enabled = False
            btn_Save.Enabled = False

        End If

        If lvList.Items.Count > 0 Then
            lvList.Focus()
            lvList.Items(0).Selected = True
            lvList.Items(0).EnsureVisible()
        End If

        If forStockpileLocation = True Or forZoning = True Or
            forZoningSource Or forWarehouseProperName Or
            forSaveWarehouseProperName Or
            forSaveWarehouseProperNameNew Or
            forWhItemsProjectSiteAndOthers Then

            btn_Save.Enabled = False
            txt_Save.Enabled = False
            Button1.Enabled = False
            cmbTypeofCharge.Enabled = False

            loadAllCharges()

        ElseIf forSaveWarehouseProperNameNew Then
            txt_Search.Enabled = False
            btnSearch.Enabled = False
        End If



    End Sub

    Private Sub loadAllCharges()
        Try
            Dim cv3 As New ColumnValues
            cAllChargesModel.clearParameter()
            loadingPanel.Visible = True

            _initializing(cCol.forAllCharges,
                          cv3.getValues(),
                          cAllChargesModel,
                          allChargesBgWorker)

            cBgWorkerChecker = BgWorkersCheckerFn(AddressOf chargesLoadSuccessfullyDone, allChargesBgWorker)

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub chargesLoadSuccessfullyDone()
        Try
            cListOfAllCharges = TryCast(cAllChargesModel.cData, List(Of PropsFields.AllCharges))
            loadingPanel.Visible = False

            If forWarehouseProperName Or forSaveWarehouseProperName Or forSaveWarehouseProperNameNew Then
                previewWarehousesOnlyToListView(cListOfAllCharges)
            Else
                previewToListView(cListOfAllCharges)
            End If


        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub previewToListView(data As List(Of PropsFields.AllCharges))
        Try
            lvList.Items.Clear()
            cListOfListviewItem.Clear()

            For Each row In data
                If Not exclude(row.charges_category) Then

                    If Not row.charges = "" Then

                        Dim a(3) As String
                        a(0) = row.charges_id
                        a(1) = row.charges
                        a(2) = row.charges_category
                        a(3) = row.specific_location

                        Dim lvl = customListviewItem(Color.White, a,,, Color.Black)
                        cListOfListviewItem.Add(lvl)

                    End If
                End If

            Next

            lvList.Items.AddRange(cListOfListviewItem.ToArray)
            customizeListView()
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub previewWarehousesOnlyToListView(data As List(Of PropsFields.AllCharges))
        Try
            lvList.Items.Clear()
            cListOfListviewItem.Clear()

            For Each row In data
                If row.charges_category = "WAREHOUSES" Then

                    If Not row.charges = "" Then

                        Dim a(3) As String
                        a(0) = row.charges_id
                        a(1) = row.charges
                        a(2) = row.charges_category
                        a(3) = row.specific_location

                        Dim lvl = customListviewItem(Color.White, a,,, Color.Black)
                        cListOfListviewItem.Add(lvl)

                    End If
                End If

            Next

            lvList.Items.AddRange(cListOfListviewItem.ToArray)
            customizeListView()
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Function exclude(value As String) As Boolean
        If value = "PERSONAL" Or
            value = "EQUIPMENT" Or
            value = "SUPPLIER" Or
            value = "WAREHOUSES" Or
            value = "" Then

            Return True
        Else

            Return False
        End If
    End Function

    Private Function include(value As String) As Boolean
        If value = "WAREHOUSE" Then
            Return True
        Else

            Return False
        End If
    End Function

    Public Sub view_cmb(ByVal cmb As Object, ByVal n As Integer)
        Dim cmb1 = cmb
        cmb1.items.clear()
        Dim Sql_conn As New SQLcon
        Dim dr As SqlDataReader
        Try
            Sql_conn.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = Sql_conn.connection
            sqlcomm.CommandText = "crud_charges"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", n)

            dr = sqlcomm.ExecuteReader
            While dr.Read
                cmb1.Items.Add(dr.Item(0).ToString)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sql_conn.connection.Close()
        End Try
    End Sub
    Public Sub load_charge_to(ByVal n As Integer)

        Try
            conn.connection.Open()

            If n = 0 Then
                cmbTypeofCharge.Items.Clear()
                publicquery = "SELECT * FROM dbwh_area"
            ElseIf n = 1 Then
                cmbTypeofCharge.Items.Clear()
                publicquery = "select a.*, b.username from dbCharge_to a left join dbregistrationform b on a.user_id = b.user_id order by a.charge_to_id asc"
            ElseIf n = 2 Then
                lvList.Items.Clear()
                publicquery = $"SELECT * FROM dbSupplier a WHERE a.Supplier_Name LIKE '%{txt_Search.Text}%' ORDER BY a.Supplier_Name ASC"
            End If

            cmd = New SqlCommand(publicquery, conn.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim a(5) As String
                If n = 0 Then
                    a(0) = dr.Item(0).ToString
                    a(1) = UCase(dr.Item(1).ToString)
                    a(2) = dr.Item(3).ToString

                ElseIf n = 1 Then
                    a(0) = dr.Item(0).ToString
                    a(1) = UCase(dr.Item(1).ToString)
                    a(2) = dr.Item(2).ToString
                    a(3) = dr.Item(5).ToString

                ElseIf n = 2 Then
                    a(0) = dr.Item(0).ToString
                    a(1) = UCase(dr.Item(1).ToString)

                End If
                Dim lvl As New ListViewItem(a)
                lvList.Items.Add(lvl)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.connection.Close()
        End Try
    End Sub

    Private Sub btn_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Save.Click
        If btn_Save.Text = "Cancel" Then
            For Each ctr As Control In Me.Controls
                ctr.Enabled = True
            Next
            btnUpdate.Enabled = False
        End If

        If txt_Save.Text <> "" Then
            If operatorCancel = True Then
                btnUpdate.Enabled = False
                txt_Save.Text = ""
                btn_Save.Text = "Save"
            ElseIf btn_Save.Text = "Save" Then
                InsertNewRecord()
            End If
        End If
        operatorCancel = False
    End Sub

    Private Sub txt_Search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Search.TextChanged

        If forStockpileLocation Or
            forZoning Or
            forZoningSource Or
            forWarehouseProperName Or
            forSaveWarehouseProperName Or
            forSaveWarehouseProperNameNew Or
            forWhItemsProjectSiteAndOthers Then

            cSearch = txt_Search.Text
            Exit Sub
        End If

        If cmbTypeofCharge.Text = "SUPPLIER" Then
            load_charge_to(2)

        Else
            search_charges(txt_Search.Text)
        End If


    End Sub
    Public Sub search_charges(search As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        lvList.Items.Clear()

        Dim a(10) As String
        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            If cmbTypeofCharge.Text = "EQUIPMENT" Then
                newCMD.Parameters.AddWithValue("@n", 27)
            Else
                newCMD.Parameters.AddWithValue("@n", 26)
            End If

            newCMD.Parameters.AddWithValue("@SearchCharges", cmbTypeofCharge.Text)
            newCMD.Parameters.AddWithValue("@search", search)
            newDR = newCMD.ExecuteReader

            While newDR.Read

                a(0) = newDR.Item(0).ToString
                a(1) = UCase(newDR.Item(1).ToString)
                a(2) = newDR.Item(2).ToString

                Dim lvl As New ListViewItem(a)
                lvList.Items.Add(lvl)

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Search()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        UpdateRecord()
        btn_Save.Text = "Save"
        txt_Save.Text = ""
        operatorCancel = False


        For Each ctr As Control In Me.Controls
            ctr.Enabled = True
        Next
        btnUpdate.Enabled = False


    End Sub
    Public Sub load_to_list()
        If charge_to_selection = 1 Then
            lvList.Items.Clear()
            load_charge_to(0)

            btnSearch.Enabled = False
            btnUpdate.Enabled = False
            txt_Save.Enabled = False
            btn_Save.Enabled = False

        ElseIf charge_to_selection = 2 Or charge_to_selection = 3 Then
            lvList.Items.Clear()
            load_charge_to(1)

            btnSearch.Enabled = True
            btnUpdate.Enabled = True
            txt_Save.Enabled = True
            btn_Save.Enabled = True

        ElseIf charge_to_selection = 4 Then
            lvList.Items.Clear()
            load_charge_to(2)

            btnSearch.Enabled = False
            btnUpdate.Enabled = False
            txt_Save.Enabled = False
            btn_Save.Enabled = False

        End If
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click

        If lvList.SelectedItems.Count > 0 Then
            txt_Save.Text = lvList.SelectedItems.Item(0).SubItems(1).Text
            cmbTypeofCharge.Text = lvList.SelectedItems.Item(0).SubItems(2).Text

            btn_Save.Text = "Cancel"
            btnUpdate.Enabled = True
            operatorCancel = True

            For Each ctr As Control In Me.Controls
                If ctr.Name = "txt_Save" Then
                    ctr.Enabled = True
                ElseIf ctr.Name = "btnUpdate" Then
                    ctr.Enabled = True
                ElseIf ctr.Name = "btn_Save" Then
                    ctr.Enabled = True
                ElseIf ctr.Name = "cmbTypeofCharge" Then
                    ctr.Enabled = True
                Else
                    ctr.Enabled = False
                End If

            Next

        Else

        End If

    End Sub


    Private Sub lvList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvList.DoubleClick
        'If lvList.SelectedItems(0).SubItems(1).Text = "ADFIL" Then
        '    Panel1.Visible = True
        '    load_equipment(1, lvlListofProject)
        'Else
        '    select_item()
        'End If

#Region "FOR FCreateDeliveryReceipt"
        If forDrWithoutRs = DROptions.out_without_rs Or
            forDrWithoutRs = DROptions.in_without_rs Or
            forDrWithoutRs = DROptions.others_without_rs Or
            forDrWithoutRs = DROptions.in_with_rs Or
            forDrWithoutRs = DROptions.others_with_rs Then

            Dim id As Integer = cId

            If cListOfPendingDr.Count > 0 Then
                Dim index As Integer = cListOfPendingDr.FindIndex(Function(x) x.id = id)

                With cListOfPendingDr(index)
                    .recepient_id = lvList.SelectedItems(0).Text
                    '.recepient_category = cmbTypeofCharge.Text
                    .recepient_category = lvList.SelectedItems(0).SubItems(2).Text
                    .recepient_for_screening = lvList.SelectedItems(0).SubItems(1).Text

                    'for pricing
                    If forDrWithoutRs = DROptions.in_with_rs Or
                        forDrWithoutRs = DROptions.others_with_rs Then

                        .price = FRequistionForm.GetCDR.getSpecificPrice(.stockpile_recepient, lvList.SelectedItems(0).SubItems(1).Text)
                        FRequistionForm.GetCDR.lblRequestor.Text = $"REQUESTOR: {lvList.SelectedItems(0).SubItems(1).Text}"

                    Else
                        If forDrWithoutRs = DROptions.out_without_rs Then

                            Dim destination As String = lvList.SelectedItems(0).SubItems(1).Text

                            .price = FCreateDeliveryReceipt.getSpecificPrice(lvList.SelectedItems(0).SubItems(1).Text, .stockpile_source)

                            'visualize transaction
                            FCreateDeliveryReceipt.lblRequestor.Text = $"REQUESTOR: {destination}"

                        ElseIf forDrWithoutRs = DROptions.in_without_rs Then

                            Dim source As String = lvList.SelectedItems(0).SubItems(1).Text
                            Dim destination As String = .stockpile_recepient

                            .price = FCreateDeliveryReceipt.getSpecificPrice(destination, source)

                            'visualize transaction
                            FCreateDeliveryReceipt.lblStockpile.Text = source
                            FCreateDeliveryReceipt.lblRequestor.Text = $"REQUESTOR: {destination}"

                        ElseIf forDrWithoutRs = DROptions.others_without_rs Then
                            .price = FCreateDeliveryReceipt.getSpecificPrice(.stockpile_recepient, lvList.SelectedItems(0).SubItems(1).Text)

                            Dim source As String = lvList.SelectedItems(0).SubItems(1).Text
                            FCreateDeliveryReceipt.lblStockpile.Text = $"SOURCE: {source}"
                            FCreateDeliveryReceipt.lblQuarry.Text = "-"

                        End If

                        'FCreateDeliveryReceipt.lblRequestor.Text = $"REQUESTOR: {lvList.SelectedItems(0).SubItems(1).Text}"
                    End If

                End With

                cDgv.Refresh()
            End If

            Me.Dispose()
            Exit Sub
        End If

#End Region

#Region "FOR FWarehousItems"
        If forStockpileLocation = True  Then
            Dim selectedItem = lvList.SelectedItems(0)

            With FCreateWarehouseItemForm.whitemStorage 'FWarehouseItems
                '.whAreaId = selectedItem.Text
                '.txtWarehouseArea.Text = selectedItem.SubItems(1).Text
                '.whAreaCategory = selectedItem.SubItems(2).Text

                .wh_area_id = selectedItem.Text
                FCreateWarehouseItemForm.txtWhAreaQuarryAreaProjectSite.Text = selectedItem.SubItems(1).Text
                .whArea_category = selectedItem.SubItems(2).Text
                FCreateWarehouseItemForm.txtWhAreaQuarryAreaProjectSite.Focus()
                Me.Dispose()
            End With
            Exit Sub

        ElseIf forZoning = True Then 'for zoning area
            Dim selectedItem = lvList.SelectedItems(0)

            'With FWarehouseItems.AggregatesPricesForm.data

            '    .zoning_area_category = selectedItem.SubItems(2).Text
            '    .zoning_area_id = selectedItem.Text

            'End With

            'With FWarehouseItems.AggregatesPricesForm

            '    .txtZoningArea.Text = selectedItem.SubItems(1).Text
            '    .zoningAreaUI.resetBgColor()

            'End With

            With FWarehouseItemsNew.AggregatesPricesForm.data

                .zoning_area_category = selectedItem.SubItems(2).Text
                .zoning_area_id = selectedItem.Text

            End With

            With FWarehouseItemsNew.AggregatesPricesForm

                .txtZoningArea.Text = selectedItem.SubItems(1).Text
                .zoningAreaUI.resetBgColor()

            End With

            Me.Dispose()

        ElseIf forZoningSource = True Then 'for zoning source
            Dim selectedItem = lvList.SelectedItems(0)

            'With FWarehouseItems.AggregatesPricesForm.data
            '    .zoning_source_category = selectedItem.SubItems(2).Text
            '    .zoning_source_id = selectedItem.Text
            'End With

            'With FWarehouseItems.AggregatesPricesForm
            '    .txtZoningSource.Text = selectedItem.SubItems(1).Text
            '    .zoningAreaSourceUI.resetBgColor()
            'End With

            With FWarehouseItemsNew.AggregatesPricesForm.data
                .zoning_source_category = selectedItem.SubItems(2).Text
                .zoning_source_id = selectedItem.Text
            End With

            With FWarehouseItemsNew.AggregatesPricesForm
                .txtZoningSource.Text = selectedItem.SubItems(1).Text
                .zoningAreaSourceUI.resetBgColor()
            End With

            Me.Dispose()

        ElseIf forWhItemsProjectSiteAndOthers Then
            Dim cn_proj_others As New PropsFields.whItemsFinal

            Dim selectedItem = lvList.SelectedItems(0)
            Dim category As String = selectedItem.SubItems(2).Text
            Dim locationArea As String = selectedItem.SubItems(1).Text

            Dim charge_to_id As Integer = selectedItem.Text
            Dim wh_id As Integer = FWarehouseItemsNew.DataGridView1.SelectedRows(0).Cells("wh_id").Value

            If cCustomMsg.messageYesNo("Are you sure you want to update area to this item?", "SUPPLY INFO:", MessageBoxIcon.Question) Then
                Dim cc As New ColumnValuesObj
                cc.add("whArea", charge_to_id)
                cc.add("whArea_category", category)
                cc.setCondition($"wh_id = {wh_id}")

                Dim result As Boolean = cc.updateQuery_return_true("dbwarehouse_items")
                If result Then
                    cCustomMsg.message("info", "Successfully Updated...", "SUPPLY INFO:")

                    'FWarehouseItemsNew.getWhItemsModel().setRowId = wh_id
                    'FWarehouseItemsNew.getWhItemsModel().isEdit = True
                    'FWarehouseItemsNew.getWhItemsModel().getWarehouseItems("")
                    With cn_proj_others
                        .wh_area_id = charge_to_id
                        .warehouse_area = locationArea
                        .whArea_category = category.ToUpper()
                    End With

                    FWarehouseItemsNew.getWhItemsModel().reloadItemsWithoutRefreshNew(wh_id,
                                                                                      NameOf(cn_proj_others.warehouse_area),
                                                                                      cn_proj_others)

                    Me.Dispose()
                Else
                    cCustomMsg.message("error", "Something went wrong with update...", "SUPPLY INFO:")
                End If
            End If




            Me.Dispose()

        End If
#End Region

#Region "FOR Warehouse Proper Name"

        If forWarehouseProperName = True Then
            If cCustomMsg.messageYesNo("Are you sure you want to update warehouse proper name?", "SUPPLY INFO:") Then
                Dim selectedRow = lvList.SelectedItems(0)

                Dim id As Integer = FWarehouseArea.lvlWhareaList.SelectedItems(0).Text
                Dim charges_to_id As Integer = selectedRow.Text

                Dim cc As New ColumnValuesObj
                cc.parameterToUpdate("charge_to_id", charges_to_id)
                cc.setCondition($"wh_area_id = {id}")
                Dim result As Boolean = cc.updateQuery_return_true("dbwh_area")

                If result = True Then
                    cCustomMsg.message("info", "successfully set to warehouse proper name...", "SUPPLY INFO:")
                    FWarehouseArea.isUpdateWhAreaProperName = True
                    FWarehouseArea.cStoredId = id
                    FWarehouseArea.load_whArea_stockpile()
                    Exit Sub
                Else
                    cCustomMsg.message("error", "something went wrong on updating warehouse proper name..", "SUPPLY INFO:")
                    Exit Sub
                End If

            End If

        ElseIf forSaveWarehouseProperName = True Then
            Dim charges_to_id As Integer = lvList.SelectedItems(0).Text
            FWarehouseArea.txtWharea.Text = lvList.SelectedItems(0).SubItems(1).Text
            FWarehouseArea.charge_to_id = charges_to_id
            Me.Dispose()

        ElseIf forSaveWarehouseProperNameNew = True Then
            Dim charges_to_id As Integer = lvList.SelectedItems(0).Text
            FWarehouseAreaNew.txtWharea.Text = lvList.SelectedItems(0).SubItems(1).Text
            FWarehouseAreaNew.whAreaUI.resetBgColor()
            FWarehouseAreaNew.charge_to_id = charges_to_id
            Me.Dispose()

        End If

#End Region

        If charge_to_destination = 0 Then
        Else
            select_item()
        End If



    End Sub
    Private Sub load_equipment(ByVal n As Integer, ByVal obj As Object)

        Dim lvl As ListView = obj

        lvl.Items.Clear()

        Dim sqlcon As New SQLcon

        'sqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
        'sqlcon.sql_connect()

        Try
            sqlcon.connection1.Open()


            publicquery = "SELECT * FROM dbprojectdesc ORDER BY project_desc ASC"

            cmd = New SqlCommand(publicquery, sqlcon.connection1)
            dr = cmd.ExecuteReader

            While dr.Read
                Dim a(2) As String

                a(0) = dr.Item("proj_id").ToString
                a(1) = dr.Item("project_desc").ToString

                Dim lvllist As New ListViewItem(a)
                lvl.Items.Add(lvllist)

            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection1.Close()
        End Try
    End Sub
    Private Sub lvList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvList.KeyDown
        If e.KeyCode = Keys.Enter Then
            select_item()
        End If
    End Sub
    Public Sub select_item()
        Try

            If charge_to_destination = 1 Then

                charge_to_id = Val(lvList.SelectedItems(0).Text)
                FRequestField.txtChargeTo.Text = lvList.SelectedItems(0).SubItems(1).Text
                FRequestField.txtLoc.Text = lvList.SelectedItems(0).SubItems(2).Text

            ElseIf charge_to_destination = 2 Then 'FOR PREVIOUS STACKCARD FINAL FORM
                charge_to_id = Val(lvList.SelectedItems(0).Text)
                FPreviousStackCardFinal.txtChargeTo.Text = lvList.SelectedItems(0).SubItems(1).Text

            ElseIf charge_to_destination = 3 Then
                charge_to_id = Val(lvList.SelectedItems(0).Text)
                FBorrowerSlip.txtChargeTo.Text = lvList.SelectedItems(0).SubItems(1).Text

            ElseIf charge_to_destination = 4 Then
                charge_to_id = Val(lvList.SelectedItems(0).Text)
                FBorrowed_Item_Monitoring.txtChargeTo.Text = lvList.SelectedItems(0).SubItems(1).Text

            ElseIf charge_to_destination = 5 Then
                charge_to_id = Val(lvList.SelectedItems(0).Text)
                FOldFacilities.txtCustodian.Text = lvList.SelectedItems(0).SubItems(1).Text

            ElseIf charge_to_destination = 6 Then
                charge_to_id1 = Val(lvList.SelectedItems(0).Text)
                FOldFacilities.txtChargeTo.Text = lvList.SelectedItems(0).SubItems(1).Text

            ElseIf charge_to_destination = 7 Then
                charge_to_id1 = Val(lvList.SelectedItems(0).Text)
                FBorrowed_Item_Monitoring.txtChargeTo1.Text = lvList.SelectedItems(0).SubItems(1).Text

            ElseIf charge_to_destination = 8 Then
                return_to_id = Val(lvList.SelectedItems(0).Text)
                FBorrower_Turnover.txtReturnTo.Text = lvList.SelectedItems(0).SubItems(1).Text

            ElseIf charge_to_destination = 9 Then
                return_to_id1 = Val(lvList.SelectedItems(0).Text)
                FBorrower_Turnover.txtTurnoverLocation.Text = lvList.SelectedItems(0).SubItems(1).Text

            ElseIf charge_to_destination = 10 Then
                charge_to_id1 = Val(lvList.SelectedItems(0).Text)
                FBorrowed_Item_List.txtChargeTo1.Text = lvList.SelectedItems(0).SubItems(1).Text

            ElseIf charge_to_destination = 11 Then
                FDeliveryReceipt.txtChargeTo.Text = lvList.SelectedItems(0).SubItems(1).Text

            ElseIf charge_to_destination = 12 Then

                If target_location_project = "FDeliveryReceipt" Then

                    With FDeliveryReceipt
                        For Each row As DataGridViewRow In .dgv_dr_list.Rows
                            If row.Cells(1).Selected = True Then
                                row.Cells("col_category").Value = lvList.SelectedItems(0).SubItems(2).Text
                                row.Cells("col_source").Value = lvList.SelectedItems(0).SubItems(1).Text
                            End If

                        Next
                    End With

                    Me.Dispose()

                End If

            ElseIf charge_to_destination = 13 Then
                If MessageBox.Show("Are you sure you want to edit source to this selected row?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    With FDRLIST1
                        For Each row As ListViewItem In .lvl_drList.Items
                            If row.Selected = True Then
                                update_source_drlist1(cmbTypeofCharge.Text, lvList.SelectedItems(0).Text, row.Text)
                                row.SubItems(5).Text = lvList.SelectedItems(0).SubItems(1).Text
                            End If
                        Next
                    End With
                    Me.Close()
                End If

            ElseIf charge_to_destination = 14 Then
                If MessageBox.Show("Are you sure you want to edit source to this selected row?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    With FDRLIST2
                        For Each row As ListViewItem In .lvl_drList.Items
                            If row.Selected = True Then
                                update_source_drlist1(cmbTypeofCharge.Text, lvList.SelectedItems(0).Text, row.Text)
                                row.SubItems(5).Text = lvList.SelectedItems(0).SubItems(1).Text
                            End If
                        Next
                    End With
                    Me.Close()
                End If
            End If

            Me.Dispose()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub update_source_drlist1(source_category As String, source_id As Integer, dr_items_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 12)
            newCMD.Parameters.AddWithValue("@source_category", source_category)
            newCMD.Parameters.AddWithValue("@source_id", source_id)
            newCMD.Parameters.AddWithValue("@dr_items_id", dr_items_id)
            newCMD.ExecuteNonQuery()


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Private Sub lvList_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvList.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then

            ContextMenuStrip1.Show(Me, e.Location)
            ContextMenuStrip1.Show(Cursor.Position)

        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim ex = MsgBox("Are you sure u want to DELETE the SELECTED item?", MsgBoxStyle.YesNo, "ERROR")
        If ex = MsgBoxResult.Yes Then
            DeleteRecord()
        Else
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Dispose()
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

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'For Each row As ListViewItem In lvlListofProject.Items
        '    If row.Checked = True Then
        '        Me.Close()
        '        Me.Dispose()
        '    End If
        'Next
    End Sub

    Private Sub cmbTypeofCharge_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTypeofCharge.SelectedIndexChanged
        If btn_Save.Text = "Cancel" Then

        Else
            FProjectIncharge.load_all(lvList, 0, cmbTypeofCharge.Text)
        End If

    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

        If cmbTypeofCharge.Text = "EQUIPMENT" Then
            EditToolStripMenuItem.Enabled = False
            DeleteToolStripMenuItem.Enabled = False

        Else
            EditToolStripMenuItem.Enabled = True
            DeleteToolStripMenuItem.Enabled = True
        End If

        If forWhItemsProjectSiteAndOthers Or forStockpileLocation Then

            Utilities.disableAllItemsFromContextMenu(ContextMenuStrip1)
        End If

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If cmbTypeofCharge.Text.Equals("") = False Then
            TextBox1.Text = cmbTypeofCharge.Text
            TextBox1.Enabled = False
        Else
            TextBox1.Enabled = True
        End If
        Button3.Enabled = True
        Panel1.Visible = True
    End Sub

    Sub add_charges()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel1.Visible = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim cmd As New SqlCommand
        Dim a(20) As String
        Try
            conn.connection.Open()
            cmd.Connection = conn.connection
            cmd.CommandText = "proc_charges"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Charge_cat_name", TextBox1.Text)
            cmd.Parameters.AddWithValue("@description", TextBox2.Text)
            cmd.Parameters.AddWithValue("@code", TextBox3.Text)
            If TextBox1.Enabled = False Then
                cmd.Parameters.AddWithValue("@existing", 1)
            Else
                cmd.Parameters.AddWithValue("@existing", 0)
            End If
            cmd.ExecuteNonQuery()
            MsgBox("Success")
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.connection.Close()
            Panel1.Visible = False
        End Try
    End Sub

    Private Sub debounce_new_Tick(sender As Object, e As EventArgs) Handles debounce_new.Tick
        Try
            debounce_new.Stop()

            Dim searchResult

            If forSaveWarehouseProperName Or forSaveWarehouseProperNameNew Then
                searchResult = cListOfAllCharges.Where(Function(x)
                                                           Dim output As String = x.charges.ToUpper() & " " & x.charges_category.ToUpper()
                                                           Return output.Contains(cSearch.ToUpper) And x.charges_category = "WAREHOUSES"
                                                       End Function).
                                      OrderBy(Function(x) x.charges).
                                      ThenBy(Function(x) x.charges_category).ToList()

            Else
                searchResult = cListOfAllCharges.Where(Function(x)
                                                           Dim output As String = x.charges.ToUpper() & " " & x.charges_category.ToUpper()
                                                           Return output.Contains(cSearch.ToUpper)
                                                       End Function).
                                    OrderBy(Function(x) x.charges).
                                    ThenBy(Function(x) x.charges_category).ToList()
            End If



            If searchResult.Count > 0 Then
                previewToListView(searchResult)

            End If

            PictureBox3.Visible = False

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Sub lvList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvList.SelectedIndexChanged

    End Sub

    Private Sub txt_Search_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Search.KeyDown
        Try
            If txt_Search.TextLength > 0 Then
                PictureBox3.Visible = True
                debounce_new.Start()
            Else
                PictureBox3.Visible = True
                cSearch = ""
                debounce_new.Start()

            End If
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try

    End Sub


    Private Sub FCharge_To_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Dispose()
    End Sub

#Region "CUSTOMIZE"
    Private Sub customizeListView()
        Try
            'rename column
            If forZoning Or forZoningSource Then
                lvList.Columns(3).Text = "Location"
            End If


        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub FCharge_To_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
#End Region

End Class

