Imports System.ComponentModel
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Threading
Public Class FDeliveryReceipt
    Dim rowind As Integer
    Dim txtname1 As String
    Dim txtbox As TextBox

    Dim copysource As String
    Dim copycategory As String
    Public cat, cat_desc As String
    Public tboxname As String
    Dim copy_data_from_list(11) As String

    Public stat As Integer

    Private supplier As New class_supplier
    Private supplier_stat As Boolean = False
    Private equip_operator As New class_operator
    Private equip_operator_stat As Boolean = False
    Private type_of_charges As New class_charges
    Private type_of_charges_stat As Boolean = False

    Private r1, r2 As Boolean
    Private cListOfAggregates As New List(Of aggregates_stockcard)

    Public stockcard As New class_agg_remaining_balance()
    Public stockcard1 As New class_agg_remaining_balance()
    Public rr_balance As New class_agg_remaining_balance()
    Private cStatus As New aggStatus

    Private myInOut As String
    Public Property myRsNo As String
    Public Property myRRNo As String
    Public Property myRRQty As Double
    Public Property MyRsId As Integer

    'id verification during save
    Dim _equipListId, _driverId, _supplierId As Integer

#Region "INTERFACE"
    Public Class aggregates_stockcard
        Public Property drdate As DateTime
        Public Property rs_no As String
        Public Property drno_invoice As String
        Public Property rr_no As String
        Public Property ws_no As String
        Public Property supp_recipient As String
        Public Property qty_in As Double
        Public Property qty_out As Double
        Public Property remarks As String

    End Class

    Public Class aggStatus
        Property wh_id As Integer
        Property status As Integer
        Property item_desc As String
        Property inOut As String
        Property rsNo As String
    End Class

    Public Enum Status
        outWithoutRs = 1
        inWithoutRs = 2
        othersWithoutRs = 3
    End Enum

#End Region

    Private UIPlateNo, UIOperator, UISupplier, UIInOut, UIdrOption, UICheckBy,
        UIReceivedBy, UIRemarks, UIConcession, UIRsNo, UITypeOfCharge, UIChargeTo,
        UIWsNoPoNo, UIRRNo, UIprice, UIDate, UIDateSubmitted, UIStockpileToStockpile As New class_placeholder4

    Dim cListOfEquipments As New List(Of Model._Mod_Equipment.Equipment)
    Dim cListOfOperators As New List(Of Model._Mod_Driver.driver)
    Dim cListOfSuppliers As New List(Of Model._Mod_Supplier.Supplier)
    Dim cListOfAdfilEmployee As New List(Of Model._Mod_Adfil_Employee.employee_data)
    Dim cListOfRequestorCharges As New List(Of Model._Mod_Charges.charges_info)

    Public myLoadingEffect As New Floading
    Private storeRsNo, storeInOut, storeDrOption, storePlateNo, storeDriver,
        storeSupplier, storeWsNo_PoNo, storeConcession, storeRRNo, storeReceivedBy,
        storeCheckedBy, storePrice, storeRemarks As String


    Private customMsg As New customMessageBox

    Public Sub LoadAllData()
        Try
            'System.Threading.Thread.Sleep(2000) ' simulate heavy load
            initialize()

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub ProjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProjectToolStripMenuItem.Click
        charge_to_destination = 12
        public_rowind = rowind
        target_location_project = "FDeliveryReceipt"
        FProject_maintenance.ShowDialog()

    End Sub

    Private Sub OthersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OthersToolStripMenuItem.Click
        charge_to_destination = 12
        public_rowind = rowind
        target_location_project = "FDeliveryReceipt"
        load_charges_category()

        FCharge_To.ShowDialog()
    End Sub

    Public Function get_datagrid_rowindex() As Integer

        For i As Integer = 0 To Me.dgv_dr_list.SelectedCells.Count - 1
            get_datagrid_rowindex = Me.dgv_dr_list.SelectedCells.Item(i).RowIndex
        Next

    End Function

    Private Sub dgv_dr_list_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_dr_list.CellContentClick
        'rowind = Format(get_datagrid_rowindex)

        ' rowind = dgv_dr_list.CurrentRow.Index

    End Sub

    Private Sub SplitQtyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SplitQtyToolStripMenuItem.Click

        Try
            For Each ctr As Control In Panel2.Controls
                ctr.Enabled = False
            Next

            For Each ctr As Control In Panel5.Controls

                If ctr.Name = "Panel6" Then
                    ctr.Visible = True
                    ctr.Enabled = True
                    txtsplitqty.Text = dgv_dr_list.Rows(rowind).Cells(4).Value


                Else
                    ctr.Enabled = False
                End If
            Next

            txtsplitqty.SelectAll()
            txtsplitqty.Focus()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Dim qty As Integer = CInt(dgv_dr_list.Rows(rowind).Cells(4).Value)
            Dim dr_item_id As Integer = CInt(dgv_dr_list.Rows(rowind).Cells(7).Value)

            If CInt(txtsplitqty.Text) = 0 Then

                MessageBox.Show("zero is not applicable..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            ElseIf CInt(txtsplitqty.Text) > CInt(dgv_dr_list.Rows(rowind).Cells(4).Value) Then

                Dim aa As New class_main_rs_qty
                Dim rs_no As String = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(1).Text
                Dim rs_id As Integer = FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text

                Dim mainrs_sub As New List(Of class_main_rs_qty.main_rs_sub)
                mainrs_sub = aa.LISTOFMAINRS_SUB(rs_no)

                Dim mainrs As New List(Of class_main_rs_qty.main_rs)
                mainrs = aa.LISTOFMAINRS(rs_no)


                Dim query = From abc In mainrs
                            Group Join bb In mainrs_sub On bb.main_rs_qty_id Equals abc.main_rs_qty_id Into GG = Group
                            From g In GG.DefaultIfEmpty
                            Select New With {.main_rs_qty_id = abc.main_rs_qty_id, .main_rs_qty = abc.main_rs_qty, .rs_id = g.rs_id, .open_close = abc.open_close_qty} '===>

                For Each row In query
                    If row.rs_id = rs_id Then
                        If row.open_close = 1 Then 'OPEN QTY
                            'continue 
                            Exit For
                        ElseIf row.open_close = 0 Then 'CLOSE QTY
                            MessageBox.Show("check your qty, must not greater than selected items.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End If
                Next


                'If stat = 1 Then
                '    'continue             
                'Else
                '    MessageBox.Show("check your qty, must not greater than selected items.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    Exit Sub
                'End If
            End If

            If dr_item_id > 0 Then
                MessageBox.Show("Unable to split qty, this item has already delivererd...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim a(10) As String
            With dgv_dr_list.Rows(rowind)

                a(1) = .Cells(1).Value
                a(2) = .Cells(2).Value
                a(3) = .Cells(3).Value
                a(4) = txtsplitqty.Text
                a(5) = .Cells(5).Value
                a(6) = .Cells(6).Value
                a(7) = 0
                a(8) = .Cells(8).Value

            End With

            dgv_dr_list.Rows(rowind).Cells(4).Value = CDbl(dgv_dr_list.Rows(rowind).Cells(4).Value) - CDbl(txtsplitqty.Text)
            dgv_dr_list.Rows.Add(a)

            uncheck_datagridview()
            dgv_dr_list.Rows(dgv_dr_list.Rows.Count - 1).Cells("col_checkbox").Value = True
            dgv_dr_list.Rows(dgv_dr_list.Rows.Count - 1).Selected = True

            Button4.PerformClick()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Public Sub uncheck_datagridview()
        For i = 0 To dgv_dr_list.Rows.Count - 1

            dgv_dr_list.Rows(i).Cells("col_checkbox").Value = False
            dgv_dr_list.Rows(i).Selected = False
        Next
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        For Each ctr As Control In Panel2.Controls
            ctr.Enabled = True
        Next

        For Each ctr As Control In Panel5.Controls
            If ctr.Name = "Panel6" Then
                ctr.Visible = False
                ctr.Enabled = True
            Else
                ctr.Enabled = True
            End If
        Next

    End Sub

    Private Sub dgv_dr_list_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_dr_list.CellClick
        rowind = dgv_dr_list.CurrentRow.Index
    End Sub
    Public Sub trigger_for_receiving_dr(status As String, inout As String)
        with_dr_status = status '"out without rs"
        myInOut = inout

        For Each ctr As Control In Panel7.Controls
            ctr.Enabled = True
        Next

        cmbOptions.Enabled = False
        btnSave.Text = "Save"

        txtrsno.Text = "N/A"
        '.dtpTimeFrom.Enabled = True
        '.dtpTime_to.Enabled = True
        txtPlateNo.Enabled = True
        cmbOperator.Enabled = True
        cmbTypeofCharge.Enabled = True
        cmbChargeTo.Enabled = True
        txtChargeTo.Enabled = True
        '.txtaddress.Enabled = True
        txtrsno.Enabled = True
        '.txtpono.Enabled = True
        cmbWsNo_PoNo.Enabled = True
        cmbWsNo_PoNo.Items.Clear()
        '.cmbWsNo_PoNo.Items.Add("N/A")

        txtconcession.Enabled = True
        txtcheckedby.Enabled = True
        txtreceivedby.Enabled = True

        '

        Panel8.Parent = Me
        Panel8.BringToFront()
        Panel8.Location = New Point(Me.Left, Me.Top)


        Panel8.Visible = True
        Panel7.Enabled = False

        'disable save button
        btnSave.Enabled = False

        'clear all variables
        supplier_stat = False

        cmbOptions.Enabled = True
        cmbOptions.Text = inout
        cmbOptions.Enabled = False

        'GET SUPPLIER
        bw_get_supplier = New BackgroundWorker
        bw_get_supplier.WorkerSupportsCancellation = True
        bw_get_supplier.RunWorkerAsync()

        'GET OPERATOR
        bw_get_operator = New BackgroundWorker
        bw_get_operator.WorkerSupportsCancellation = True
        bw_get_operator.RunWorkerAsync()

        'GET TYPE OF CHARGES
        bw_get_type_of_charges = New BackgroundWorker
        bw_get_type_of_charges.WorkerSupportsCancellation = True
        bw_get_type_of_charges.RunWorkerAsync()


    End Sub
    Public Sub trigger3(status As aggStatus)
        cStatus = status
        cmbOptions.Text = status.inOut
        txtrsno.Text = status.rsNo
        cmbTransaction.Enabled = True

    End Sub

    Public Function trigger2(status As String, inout As String, wh_id As Integer, Optional itemDesc As String = "") As Boolean
        Try
            with_dr_status = status '"out without rs"
            myInOut = inout
            wh_id = wh_id

            'get stockcardaggregates data
            Dim stockCardAgg As New Model._Mod_StockCardAggregates
            With stockCardAgg
                .parameter("@n", 11)
                .parameter("@wh_id", wh_id)
                .parameter("@date_from", Date.Parse("1990-01-01"))
                .parameter("date_to", Date.Parse(Now))
            End With

            Dim data = stockCardAgg.LISTOFAGGREGATESSTOCKCARD

            Dim balances As Double = stockCardAgg.get_balances(data)

            'get aggregates previous balance

            Dim stockCardAggPrevBalance As New Model._Mod_StockCardAggregates
            With stockCardAggPrevBalance
                .parameter("@n", 21)
                .parameter("@wh_id", wh_id)
            End With

            Dim prevBalance = stockCardAggPrevBalance.AGGREGATESBALANCE


            'add new row to datagridview 
            Dim a(20) As String

            a(0) = False
            a(4) = balances + prevBalance

            a(5) = itemDesc
            a(8) = wh_id

            dgv_dr_list.Rows.Add(a)
            Return True

        Catch ex As Exception
            Return False
            'Finally
            '    Threading.Thread.Sleep(2000)
            '    If Floading IsNot Nothing AndAlso Floading.Visible Then
            '        Floading.Close()
            '    End If
        End Try


    End Function
    Public Sub trigger(status As String, inout As String)
        with_dr_status = status '"out without rs"
        myInOut = inout

        For Each ctr As Control In Panel7.Controls
            ctr.Enabled = True
        Next

        cmbOptions.Enabled = False
        btnSave.Text = "Save"

        txtrsno.Text = "N/A"
        '.dtpTimeFrom.Enabled = True
        '.dtpTime_to.Enabled = True
        txtPlateNo.Enabled = True
        cmbOperator.Enabled = True
        cmbTypeofCharge.Enabled = True
        cmbChargeTo.Enabled = True
        txtChargeTo.Enabled = True
        '.txtaddress.Enabled = True
        txtrsno.Enabled = True
        '.txtpono.Enabled = True
        cmbWsNo_PoNo.Enabled = True
        cmbWsNo_PoNo.Items.Clear()
        '.cmbWsNo_PoNo.Items.Add("N/A")

        txtconcession.Enabled = True
        txtcheckedby.Enabled = True
        txtreceivedby.Enabled = True

        '

        Panel8.Parent = Me
        Panel8.BringToFront()
        Panel8.Location = New Point(Me.Left, Me.Top)


        Panel8.Visible = True
        Panel7.Enabled = False

        'disable save button
        btnSave.Enabled = False

        'clear all variables
        supplier_stat = False

        cmbOptions.Enabled = True
        cmbOptions.Text = inout
        cmbOptions.Enabled = False


        cmbTransaction.SelectedIndex = -1
        cmbTransaction.Enabled = False

        'GET SUPPLIER
        bw_get_supplier = New BackgroundWorker
        bw_get_supplier.WorkerSupportsCancellation = True
        bw_get_supplier.RunWorkerAsync()

        'GET OPERATOR
        bw_get_operator = New BackgroundWorker
        bw_get_operator.WorkerSupportsCancellation = True
        bw_get_operator.RunWorkerAsync()

        'GET TYPE OF CHARGES
        bw_get_type_of_charges = New BackgroundWorker
        bw_get_type_of_charges.WorkerSupportsCancellation = True
        bw_get_type_of_charges.RunWorkerAsync()

        'GET BALANCE FROM STOCKCARD
        r1 = False
        r2 = False
        supplier_stat = False
        equip_operator_stat = False
        type_of_charges_stat = False

        stockcard.cListOfStockCard.Clear()
        stockcard.dr_qty_using_wsno = 0
        stockcard1.my_prev_balance = 0


        If myInOut = "OUT" And with_dr_status = "out without rs" Then

            'get aggregates stockcard data
            BackgroundWorker1 = New BackgroundWorker
            BackgroundWorker1.WorkerSupportsCancellation = True
            BackgroundWorker1.RunWorkerAsync()

            'get previous balance data
            BackgroundWorker3 = New BackgroundWorker
            BackgroundWorker3.WorkerSupportsCancellation = True
            BackgroundWorker3.RunWorkerAsync()

            'if done
            bw_check_if_done = New BackgroundWorker
            bw_check_if_done.WorkerSupportsCancellation = True
            bw_check_if_done.RunWorkerAsync()

        ElseIf myInOut = "IN" And with_dr_status = "in without rs" Then
            r1 = True
            r2 = True

            bw_check_if_done = New BackgroundWorker
            bw_check_if_done.WorkerSupportsCancellation = True
            bw_check_if_done.RunWorkerAsync()

        ElseIf myInOut = "OTHERS" And with_dr_status = "in with rs" Then
            r1 = True
            r2 = True

            Panel9.Enabled = False
            txtrsno.Text = myRsNo
            cmbRRNo.Items.Add(myRRNo)

            cmbRRNo.SelectedIndex = 0

        End If


    End Sub



    Private Sub FDeliveryReceipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.Location = New Point(10000, 10000)

        lboxUnit.Visible = False

        For Each row As FRequistionForm.sMainQty In FRequistionForm.cListOfMainQty
            'MsgBox(row.main_qty)
            stat = row.status
        Next

        initialize()

    End Sub

    Private Sub initialize()

#Region "store data ky mawala after pag initialize sa UI"

        storeRsNo = txtrsno.Text
        storeInOut = cmbOptions.Text
        storeDrOption = cmbDrOptions.Text
        storePlateNo = txtPlateNo.Text
        storeDriver = txtDriver.Text
        storeWsNo_PoNo = cmbWsNo_PoNo.Text
        storeSupplier = cmbSupplier.Text
        storeRRNo = cmbRRNo.Text
        storeConcession = txtconcession.Text
        storeReceivedBy = txtreceivedby.Text
        storeCheckedBy = txtcheckedby.Text
        storePrice = txtprice.Text
        storeRemarks = txtRemarks.Text



#End Region 'store rsNo ky mawala after pag initialize sa UI


#Region "Loading Effects here"
        'loading effects background worker
        BW_loadingEffects = New BackgroundWorker
        BW_loadingEffects.WorkerSupportsCancellation = True
        BW_loadingEffects.RunWorkerAsync()
#End Region

        'SetTimeout(AddressOf initializeDataRun, 2000)

#Region "initialize all data here"
        'initialize data background worker
        BW_initializeData = New BackgroundWorker
        BW_initializeData.WorkerSupportsCancellation = True
        BW_initializeData.RunWorkerAsync()

#End Region

#Region "for out/others without RS"
        'if out without rs
        If cStatus.status = Status.outWithoutRs Or cStatus.status = Status.othersWithoutRs Then

            BW_get_aggregates_balances = New BackgroundWorker
            BW_get_aggregates_balances.WorkerSupportsCancellation = True
            BW_get_aggregates_balances.RunWorkerAsync()

        End If
#End Region
    End Sub

    Private Function get_aggregates_remaining_balance(wh_id As Integer) As Double
        'get stockcardaggregates data
        Dim stockCardAgg As New Model._Mod_StockCardAggregates
        With stockCardAgg
            .parameter("@n", 11)
            .parameter("@wh_id", wh_id)
            .parameter("@date_from", Date.Parse("1990-01-01"))
            .parameter("date_to", Date.Parse(Now))
        End With

        Dim data = stockCardAgg.LISTOFAGGREGATESSTOCKCARD

        Dim balances As Double = stockCardAgg.get_balances(data)

        'get aggregates previous balance

        Dim stockCardAggPrevBalance As New Model._Mod_StockCardAggregates
        With stockCardAggPrevBalance
            .parameter("@n", 21)
            .parameter("@wh_id", wh_id)
        End With

        Dim prevBalance = stockCardAggPrevBalance.AGGREGATESBALANCE

        get_aggregates_remaining_balance = balances + prevBalance

    End Function


    Private Sub _initialize_ui(Optional listOfEquipments As List(Of String) = Nothing,
                               Optional listOfOperators As List(Of String) = Nothing,
                               Optional listOfSuppliers As List(Of String) = Nothing,
                               Optional listOfAdfilEmployee As List(Of String) = Nothing,
                               Optional listOfRequestorCharges As List(Of String) = Nothing)

        If InvokeRequired Then
            Invoke(Sub()

                       UI(listOfEquipments, listOfOperators, listOfSuppliers, listOfAdfilEmployee, listOfRequestorCharges)

                   End Sub)
        Else
            UI(listOfEquipments, listOfOperators, listOfSuppliers, listOfRequestorCharges)
        End If
    End Sub

    Private Sub UI(Optional listOfEquipments As List(Of String) = Nothing,
                    Optional listOfOperators As List(Of String) = Nothing,
                    Optional listOfSuppliers As List(Of String) = Nothing,
                    Optional listOfAdfilEmployee As List(Of String) = Nothing,
                    Optional listOfRequestorCharges As List(Of String) = Nothing)

        UIPlateNo.king_placeholder_textbox("Plate No...", txtPlateNo, listOfEquipments, Panel7, My.Resources.plateno, False, "White", "Plate No here...")
        UIOperator.king_placeholder_textbox("Operator/Driver...", txtDriver, listOfOperators, Panel7, My.Resources.driver, False, "White", "Operator/Driver here...")
        UISupplier.king_placeholder_combobox("Supplier...", cmbSupplier, listOfSuppliers, Panel7, My.Resources.icons8_supplier_24, "White", "Supplier here...")
        UIInOut.king_placeholder_combobox("IN/OUT...", cmbOptions, Nothing, Panel7, My.Resources.logout, "White", "IN/OUT here...")
        UIdrOption.king_placeholder_combobox("Options...", cmbDrOptions, Nothing, Panel7, My.Resources.categories, "White", "Options here...")
        UICheckBy.king_placeholder_textbox("Checked By...", txtcheckedby, listOfAdfilEmployee, Panel7, My.Resources.done, False, "White", "Checked By...")
        UIReceivedBy.king_placeholder_textbox("Recevied By...", txtreceivedby, listOfAdfilEmployee, Panel7, My.Resources.received, False, "White", "Received By...")
        UIConcession.king_placeholder_textbox("Concession...", txtconcession, Nothing, Panel7, My.Resources.consession, False, "White", "Consession here...")
        UIRsNo.king_placeholder_textbox("RS No...", txtrsno, Nothing, Panel7, My.Resources.request, False, "White", "RS No here...")
        UITypeOfCharge.king_placeholder_combobox("Type Of Charge...", cmbTypeofCharge, Nothing, Panel9, My.Resources.categories, "White", "Type of charges here...")
        UIChargeTo.king_placeholder_textbox("Charge to...", txtChargeTo, Nothing, Panel9, My.Resources.charge_to, False, "White", "charge to here...")
        UIWsNoPoNo.king_placeholder_combobox("WS/PO No...", cmbWsNo_PoNo, Nothing, Panel7, My.Resources.check_out, "White", "WS/PO No...")
        UIRRNo.king_placeholder_combobox("RR No...", cmbRRNo, Nothing, Panel7, My.Resources.inbox, "White", "RR No here...")
        UIRemarks.king_placeholder_textbox("Remarks...", txtRemarks, Nothing, Panel7, My.Resources.chat_bubble, False, "White", "Remarks here...")
        UIprice.king_placeholder_textbox("Price...", txtprice, Nothing, Panel7, My.Resources.philippine_peso, True, "White", "Price here...")
        UIDate.king_placeholder_datepicker("Date...", dtpDRDate, Panel7, My.Resources.schedule, "White")

        UIDateSubmitted.king_placeholder_datepicker("Date Submitted...", dtpDateSubmitted, Panel7, My.Resources.schedule, "White")
        UIStockpileToStockpile.king_placeholder_combobox("Stockpile to Stockpile Here...", cmbTransaction, Nothing, Panel7, My.Resources.transfer, "White", "Stockpile to stockpile...")


#Region "====> Manual store data"
        'manual add supplier 
        cmbSupplier.Items.Clear()

        For Each supplier As String In listOfSuppliers
            cmbSupplier.Items.Add(supplier)
        Next

        'restore:datas
        txtrsno.Text = IIf(storeRsNo = "", UIRsNo.placeHolder(), storeRsNo)
        cmbOptions.Text = IIf(storeInOut = "", UIInOut.placeHolder(), storeInOut)
        cmbDrOptions.Text = IIf(storeDrOption = "", UIdrOption.placeHolder(), storeDrOption)
        txtPlateNo.Text = IIf(storePlateNo = "", UIPlateNo.placeHolder(), storePlateNo)
        txtDriver.Text = IIf(storeDriver = "", UIOperator.placeHolder(), storeDriver)
        cmbSupplier.Text = IIf(storeSupplier = "", UISupplier.placeHolder(), storeSupplier)
        cmbWsNo_PoNo.Text = IIf(storeWsNo_PoNo = "", UIWsNoPoNo.placeHolder(), storeWsNo_PoNo)
        txtconcession.Text = IIf(storeConcession = "", UIConcession.placeHolder(), storeConcession)
        txtcheckedby.Text = IIf(storeCheckedBy = "", UICheckBy.placeHolder(), storeCheckedBy)
        txtreceivedby.Text = IIf(storeReceivedBy = "", UIReceivedBy.placeHolder(), storeReceivedBy)
        txtprice.Text = IIf(storePrice = "", UIprice.placeHolder(), storePrice)
        txtRemarks.Text = IIf(storeRemarks = "", UIRemarks.placeHolder(), storeRemarks)

        'set price default to 0
        txtprice.Text = 0

#End Region

#Region "====> Requestor Category"

        For Each category In listOfRequestorCharges
            cmbTypeofCharge.Items.Add(category)
        Next

#End Region
    End Sub

    Private Sub loadingEffect(init As Boolean)
        If init = True Then
            Panel8.Visible = True

        End If

        If init = False Then
            Panel8.Visible = False
        End If
    End Sub
    Private Sub cmbTypeofCharge_SelectedIndexChanged(sender As Object, e As EventArgs)

        'Select Case cmbTypeofCharge.Text
        '    Case "EQUIPMENT"
        '        cmbChargeTo.Visible = True
        '        txtChargeTo.Visible = False
        '        FPreviousStackCardFinal.load_equipment(0, cmbChargeTo, txtChargeTo, GroupBox1)
        '        cmbChargeTo.Width = cmbTypeofCharge.Width

        '    Case "PROJECT"
        '        cmbChargeTo.Visible = True
        '        txtChargeTo.Visible = False
        '        FPreviousStackCardFinal.load_equipment(1, cmbChargeTo, txtChargeTo, GroupBox1)
        '        cmbChargeTo.Width = cmbTypeofCharge.Width

        '    Case "PERSONAL"
        '        cmbChargeTo.Visible = False
        '        txtChargeTo.Visible = True
        '        txtChargeTo.Clear()

        '    Case "WAREHOUSE"
        '        cmbChargeTo.Visible = False
        '        txtChargeTo.Visible = True
        '        txtChargeTo.Clear()

        '    Case "ADFIL"
        '        cmbChargeTo.Visible = False
        '        txtChargeTo.Visible = True
        '        txtChargeTo.Clear()

        'End Select

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If cmbTypeofCharge.Text = "PROJECT" Then
            target_location_project = "FDeliveryReceipt_txtChargeTo"
            FProject_maintenance.ShowDialog()
        Else
            charge_to_destination = 11
            target_location_project = "FDeliveryReceipt"
            load_charges_category()

            '2023-09-18 king code


            FCharge_To.ShowDialog()
        End If


    End Sub

    Private Sub load_charges_category()
        FCharge_To.cmbTypeofCharge.Items.Clear()

        Dim charges_category_data As New Model._Mod_Charges_Category
        charges_category_data.clear_parameter()
        charges_category_data.cStoreProcedureName = "proc_charges2"
        charges_category_data.parameter("@n", 2)

        Dim listofchargescat = charges_category_data.LISTOFCHARGESCATEGORY

        'ADDITIONAL CATEGORY
        Dim ct As New Model._Mod_Charges_Category.Charges_Category_Fields
        ct.charges_category_name = "WAREHOUSE"
        listofchargescat.Add(ct)

        Dim ct1 As New Model._Mod_Charges_Category.Charges_Category_Fields
        ct1.charges_category_name = "PROJECT"

        listofchargescat.Add(ct1)

        'SORT THE LIST
        Dim loc = From aa In listofchargescat
                  Select aa.charges_category_name Order By charges_category_name Ascending


        With FCharge_To

            For Each row In loc
                .cmbTypeofCharge.Items.Add(row)
            Next

        End With
    End Sub

    Private Sub txtPlateNo_TextChanged(sender As Object, e As EventArgs) Handles txtPlateNo.TextChanged
        'Dim txtbox As TextBox = sender
        'Try
        '    If txtbox.Text = "" Then
        '        lboxUnit.Location = New System.Drawing.Point(txtbox.Location.X, txtbox.Location.Y + txtbox.Height)
        '        lboxUnit.Visible = False
        '    Else
        '        lboxUnit.Visible = True
        '        With lboxUnit
        '            .Location = New System.Drawing.Point(txtbox.Location.X, txtbox.Location.Y + txtbox.Height)
        '            .Visible = True
        '            .BringToFront()
        '            .Items.Clear()
        '            .Width = txtbox.Width
        '        End With

        '        'get_dr_info(sender.name, txtbox.Text, txtbox)

        '        With FReceiving_Info
        '            FReceiving_Info.lbox_list(txtbox, 1, lboxUnit)
        '        End With

        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("ERROR MESSAGE:  " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub list_box_SelectedIndexChanged(sender As Object, e As EventArgs) Handles list_box.SelectedIndexChanged

    End Sub

    Private Sub list_box_KeyDown(sender As Object, e As KeyEventArgs) Handles list_box.KeyDown

        If e.KeyCode = Keys.Enter Then
            If list_box.SelectedItems.Count > 0 Then
                For Each ctr As Control In Panel7.Controls
                    If ctr.Name = txtname1 Then
                        ctr.Text = list_box.SelectedItem.ToString
                        ctr.Focus()
                    End If
                Next
                list_box.Visible = False
            End If
        ElseIf e.KeyCode = Keys.Up Then
            If list_box.SelectedIndex = 0 Then
                Dim f As Integer
                f = 1

                If f = 1 Then
                    list_box.SelectedIndex = 0
                    txtbox.Focus()
                End If
                'pub_textbox.Focus()
            End If
        End If
    End Sub

    'Private Sub txt_GotFocus(sender As Object, e As EventArgs) Handles txtPlateNo.GotFocus, txtrsno.GotFocus, txtconcession.GotFocus, txtcheckedby.GotFocus, txtreceivedby.GotFocus, txtDriver.GotFocus

    '    sender.backcolor = Color.Yellow

    '    If txtPlateNo.Focused Then
    '        txtname1 = txtPlateNo.Name
    '        txtPlateNo.SelectAll()
    '        ' ElseIf txtaddress.Focused Then
    '        'txtname1 = txtaddress.Name
    '        'txtaddress.SelectAll()
    '    ElseIf txtrsno.Focused Then
    '        txtname1 = txtrsno.Name
    '        txtrsno.SelectAll()
    '        'ElseIf txtpono.Focused Then
    '        '    txtname1 = txtpono.Name
    '        '    txtpono.SelectAll()
    '    ElseIf txtconcession.Focused Then
    '        txtname1 = txtconcession.Name
    '        txtconcession.SelectAll()
    '    ElseIf txtcheckedby.Focused Then
    '        txtname1 = txtcheckedby.Name
    '        txtcheckedby.SelectAll()
    '    ElseIf txtreceivedby.Focused Then
    '        txtname1 = txtreceivedby.Name
    '        txtreceivedby.SelectAll()
    '    ElseIf txtDriver.Focused Then
    '        txtname1 = txtDriver.Name
    '        txtDriver.SelectAll()
    '    End If

    'End Sub

    Private Sub txtPlateNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPlateNo.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
            If list_box.Visible = True Then
                If list_box.Items.Count > 0 Then
                    list_box.Focus()
                    list_box.SelectedIndex = 0
                End If
            End If
            'ListBox1.Focus()
        End If

    End Sub

    Private Sub list_box_DoubleClick(sender As Object, e As EventArgs) Handles list_box.DoubleClick
        If list_box.SelectedItems.Count > 0 Then
            For Each ctr As Control In Panel7.Controls
                If ctr.Name = txtname1 Then
                    ctr.Text = list_box.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next
            list_box.Visible = False
        End If
    End Sub

    'Private Sub txt_Leave(sender As Object, e As EventArgs) Handles txtPlateNo.Leave, txtrsno.Leave, txtconcession.Leave,
    '        txtcheckedby.Leave, txtreceivedby.Leave, txtDriver.Leave

    '    sender.backcolor = Color.White

    'End Sub
    Private Function get_type_of_charges(rs_id As Integer) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 32)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader

            Dim a(10) As String

            While newDR.Read
                get_type_of_charges = newDR.Item("type_name").ToString
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        newSave()
        'oldSave()
    End Sub

    Private Sub newSave()
        Dim typeofcharges As String = ""

        Dim msg As Boolean = False
        '***ARROW LEGEND***

        'main               | ====>
        'sub                | ->
        'sub-child          | -->
        'sub-child-child    | --->
        '******************

        Try
#Region "====> FILTER ERROR HERE"

#Region "-> FIELD VERIFICATION"

            Select Case cmbDrOptions.Text
                Case "W/ DR"
                    If UIdrOption.blank_combobox() Or UIInOut.blank_combobox Or UIOperator.blank_textbox Or
               UIPlateNo.blank_textbox Or UIRsNo.blank_textbox Or UISupplier.blank_combobox Or
               UIConcession.blank_textbox Or
               UICheckBy.blank_textbox Or UIReceivedBy.blank_textbox Or UIRemarks.blank_textbox Then
                        Exit Sub
                    End If

                Case "W/ O DR"
                    If UIOperator.blank_textbox() Or UIRemarks.blank_textbox() Or UIprice.blank_textbox() Then
                        Exit Sub
                    End If
                Case UIdrOption.blank_combobox()
                    customMsg.message("error", "You must select DR option either W/ DR OR W/O DR...", "SUPPLY INFO:")
                    Exit Sub
            End Select



            If cmbWsNo_PoNo.Items.Count > 0 Then 'check kung pang withdrawal bani xa
                If UIWsNoPoNo.blank_combobox() Then
                    Exit Sub
                End If

            ElseIf cmbRRNo.Items.Count > 0 Then 'check kung pang rr bani xa
                If UIRRNo.blank_combobox() Then
                    Exit Sub
                End If
            End If

#End Region
#Region "-> ID VERIFICATION"
#Region "--> plateno"
            For Each p In cListOfEquipments
                If p.PlateNo.ToUpper() = txtPlateNo.Text.ToUpper() Then
                    _equipListId = p.equipListID
                End If
            Next
#End Region
#Region "--> driver/operator"
            For Each o In cListOfOperators
                If o.driver_name.ToUpper() = txtDriver.Text.ToUpper() Then
                    _driverId = o.driver_id
                End If
            Next
#End Region
#Region "--> supplier"
            For Each s In cListOfSuppliers
                If s.supplier_name.ToUpper() = cmbSupplier.Text.ToUpper() Then
                    _supplierId = s.supplier_id
                End If
            Next
#End Region
#End Region

#Region "-> ROWS VERIFICATION IF THERE IS BLANK CELL"
            'check if there is checked in rows or not
            Dim countChecked As Integer = 0
            Dim countBlankDr As Integer = 0
            Dim countBlankSource As Integer = 0

            For Each row As DataGridViewRow In dgv_dr_list.Rows
                If row.Cells("col_checkbox").Value = True Then
                    countChecked += 1
                End If

                If row.Cells("col_dr_no").Value = "" And row.Cells("col_checkbox").Value = True Then
                    countBlankDr += 1
                End If

                If row.Cells("col_source").Value = "" And row.Cells("col_checkbox").Value = True Then
                    countBlankSource += 1
                End If
            Next

            'error if no selected items in a rows
            If countChecked = 0 Then
                customMsg.message("error", "Please select atleast one item to proceed saving data..", "SUPPLY INFO")
                Exit Sub
            End If

            'error if some dr are blank
            If countBlankDr > 0 Then
                customMsg.message("error", "DR NO must not be blank!", "SUPPLY INFO")
                Exit Sub
            End If

            'error if some source are blank
            If countBlankSource > 0 Then
                customMsg.message("error", "source must not be blank!", "SUPPLY INFO")
                Exit Sub
            End If
#End Region

#End Region 'FILTER ERROR HERE

#Region "====> GET TYPE OF CHARGES"
            If pub_button_name = "EquipmentUseForHaulingToolStripMenuItem" Then
                typeofcharges = get_type_of_charges(CInt(FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text))
            End If

            If button_click_name = "EditInfoToolStripMenuItem" Then
                typeofcharges = get_type_of_charges(CInt(FDRLIST.lvl_drList.SelectedItems(0).SubItems(15).Text))
            End If
#End Region 'GET TYPE OF CHARGES

#Region "====> SAVE DR"
            If btnSave.Text = "Save" Then
                msg = customMsg.messageYesNo("Are you sure you want to save this data?", "SUPPLY INFO:")

                If msg = True Then
#Region "-> IN/OUT/OTHERS TRANSACTIONS HERE"
                    Select Case cmbOptions.Text
                        Case "IN", "OTHERS" 'IN TRANSACTION
#Region "--> IN/OTHERS TRANSACTION"
                            If with_dr_status = "in without rs" Then
                                inWithoutRs()
                            ElseIf with_dr_status = "in with rs" Then
                                inWithRs()
                            ElseIf cStatus.status = Status.othersWithoutRs Then
                                othersWithoutRs()
                            Else
                                inWithOrWithoutRs_others(with_dr_status, typeofcharges)
                            End If
#End Region
                        Case "OUT" 'OUT TRANSACTION
#Region "--> OUT TRANSACTION"
                            dr_OUT("OUT")

                            'stockpile to stockpile
                            If cmbTransaction.Text = "Stockpile to Stockpile" Then
                                dr_IN_to_requestor_after_OUT("IN")
                                FAggregatesForm.ShowDialog()

                            End If

#End Region

                        Case Else 'OTHER TRANSACTION LIKE DR ETC.
#Region "--> OTHER TRANSACTION LIKE DR ETC"
                            Dim rs_id As Integer
                            Dim wh_id As Integer

                            If pub_button_name = "CreateDRToolStripMenuItem" Then
                                rs_id = CInt(FReceivingReportList.lvlreceivingreportlist.SelectedItems(0).SubItems(16).Text)

                            ElseIf pub_button_name = "CreateDRToolStripMenuItem1" Then
                                rs_id = MyRsId
                            Else
                                rs_id = CInt(FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text)
                                wh_id = CInt(FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(15).Text)
                            End If

                            Dim dr_info_id As Integer = dr_info_id_with_save_update(2, rs_id)


                            dr_item_save(dr_info_id, rs_id, 0, wh_id, "NO")

                            If pub_button_name = "CreateDRToolStripMenuItem" Then

                            ElseIf pub_button_name = "CreateDRToolStripMenuItem1" Then

                            Else
                                FRequistionForm.cmbSearchByCategory.Text = "Search by RS.No."
                                FRequistionForm.txtSearch.Text = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(1).Text
                            End If

                            customMsg.message("info", "Successfully Saved...", "SUPPLY INFO:")

#End Region

                    End Select
#End Region
                Else
                    GoTo proceedhere
                End If
            End If
#End Region 'SAVE DR HERE

#Region "====> UPDATE DR"
            If btnSave.Text = "Update Info" Then
#Region "-> Update Info"
                Dim dr_item_id As Integer = FDRLIST.lvl_drList.SelectedItems(0).Text
                Dim rs_id As Integer = FDRLIST.lvl_drList.SelectedItems(0).SubItems(15).Text
                Dim in_out As String = FDRLIST.lvl_drList.SelectedItems(0).SubItems(16).Text
                Dim dr_no As String = FDRLIST.lvl_drList.SelectedItems(0).SubItems(1).Text

                If button_click_name = "EditInfoToolStripMenuItem" Then
                    typeofcharges = get_type_of_charges(CInt(FDRLIST.lvl_drList.SelectedItems(0).SubItems(15).Text))
                End If

                dr_info_id_with_save_update(222, rs_id)

                If cmbTransaction.Text = "Stockpile to Stockpile" Or typeofcharges.ToUpper() = "WAREHOUSE" Then

                    If in_out = "IN" Then

                        pub_dr_item_id = dr_item_id
                        FAggregatesForm.ShowDialog()

                    ElseIf in_out = "OUT" Then

                        Dim msgYesNo = customMsg.messageYesNo("YES: LINK TO OTHER WAREHOUSE/PROJECT AND UPDATE.", "SUPPLY INFO")

                        If msgYesNo = True Then
                            'check sa ang dr kung naa naba in
                            If check_dr_if_already_in(dr_no, "IN") > 0 Then
                                MessageBox.Show("DR No has already in, press yes to continue...", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Stop)
                                GoTo procceed3
                            End If

                            dr_IN_to_requestor_after_OUT("IN")
                            FAggregatesForm.ShowDialog()
                        Else
                            Dim dr_info_id As Integer = dr_info_id_with_save_update(2, rs_id)
                        End If

                    End If
                End If

procceed3:
                lbl_dr_info_id.Text = 0

                'MessageBox.Show("Successfully Updated...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
                customMsg.message("info", "Successfully Updated...", "SUPPLY INFO:")
                Me.Dispose()

                btnSave.Text = "Save"

#End Region
            ElseIf btnSave.Text = "Update Description" Then
#Region "-> Update Description"
                Dim dr_item_id As Integer = FDRLIST.lvl_drList.SelectedItems(0).Text
                dr_item_update(dr_item_id)

                MessageBox.Show("Successfully Updated...", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Dispose()
#End Region
            End If
#End Region 'UPDATE DR HERE

#Region "proceedhere"
proceedhere:
            If button_click_name = "EquipmentUseForHaulingToolStripMenuItem" Then
                'FRequistionForm.btnSearch.PerformClick()
                'cmbWsNo_PoNo.SelectedIndex = -1

                'If Application.OpenForms().OfType(Of FRequistionForm).Any Then
                '    FRequistionForm.btnSearch.PerformClick()
                'End If

            ElseIf button_click_name = "EditDescriptionToolStripMenuItem" Then
                Dim dr_item_id As Integer = FDRLIST.lvl_drList.SelectedItems(0).Text

                FDRLIST.btnSearch.PerformClick()

            ElseIf button_click_name = "EditInfoToolStripMenuItem" Then
                Dim dr_item_id As Integer = FDRLIST.lvl_drList.SelectedItems(0).Text

                FDRLIST.btnSearch.PerformClick()
                listfocus(FDRLIST.lvl_drList, dr_item_id)
            End If
#End Region
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
#Region "finally"
            cmbDrOptions.Focus()

            If msg = True And cStatus.status = Status.inWithoutRs OrElse
                msg = True And cStatus.status = Status.othersWithoutRs Then
                'pass
            ElseIf with_dr_status = "in without rs" Then
                'pass
            Else
                For Each row As DataGridViewRow In dgv_dr_list.Rows
                    If row.Cells("col_checkbox").Value = True Then
                        dgv_dr_list.Rows.Remove(row)
                    End If
                Next
            End If

            'If with_dr_status = "in without rs" Then

            'ElseIf with_dr_status = "out without rs" Then

            '    For Each row As DataGridViewRow In dgv_dr_list.Rows
            '        If row.Cells("col_checkbox").Value = True Then
            '            dgv_dr_list.Rows.Remove(row)
            '        End If
            '    Next

            'Else
            '    For Each row As DataGridViewRow In dgv_dr_list.Rows
            '        If row.Cells("col_checkbox").Value = True Then
            '            dgv_dr_list.Rows.Remove(row)
            '        End If
            '    Next

            '    dtpDRDate.Select()

            'End If
#End Region
        End Try
    End Sub

#Region "with_dr_status: IN/OTHERS WITHOUT RS"
    Private Sub inWithoutRs()
        dr_IN("IN")
        'MessageBox.Show("Successfully Save...", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        customMsg.message("info", "Successfully Save...", "SUPPLY INFO:")
        dtpDRDate.Focus()
    End Sub

    Private Sub othersWithoutRs()
        dr_IN("OTHERS")
        customMsg.message("info", "Successfully Save...", "SUPPLY INFO:")
        dtpDRDate.Focus()
    End Sub

#End Region
#Region "with_dr_status: IN WITH RS"
    Private Sub inWithRs()
        With FRequistionForm.lvlrequisitionlist.SelectedItems(0)
            Dim rs_id As Integer = .Text  'FReceivingReportList.lvlreceivingreportlist.SelectedItems(0).SubItems(16).Text
            Dim rr_item_id As Integer = .SubItems(35).Text
            Dim wh_id As Integer = .SubItems(15).Text

            Dim dr_info_id As Integer = dr_info_id_with_save_update(2, rs_id)
            dr_item_save(dr_info_id, rs_id, rr_item_id, wh_id, "NO")

        End With
    End Sub
#End Region
#Region "with_dr_status: blank or wh to wh"
    Private Sub inWithOrWithoutRs_others(status As String, Optional typeofcharges As String = "")
        If status = "" Then
            dr_IN("IN")

            customMsg.message("info", "Successfully Saved...", "SUPPLY INFO:")
            dtpDRDate.Focus()
        Else
            'stockpile to stockpile
            If cmbTransaction.Text = "Stockpile to Stockpile" Or typeofcharges.ToUpper() = "WAREHOUSE" Then
                dr_IN_to_requestor_after_OUT("IN")
                FAggregatesForm.ShowDialog()

            Else
                Dim rs_id As Integer = CInt(FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text)
                Dim dr_info_id As Integer = dr_info_id_with_save_update(2, rs_id)
                Dim wh_id As Integer = CInt(FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(15).Text)

                dr_item_save(dr_info_id, rs_id, 0, wh_id, "NO")

                FRequistionForm.cmbSearchByCategory.Text = "Search by RS.No."
                FRequistionForm.txtSearch.Text = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(1).Text

                customMsg.message("info", "Successfuly Saved...", "SUPPLY INFO:")

                'MessageBox.Show("Successfully Save...", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
#End Region

    Private Sub oldSave()
        Dim typeofcharges As String = ""
        Dim dv As New datagridviews

        Try
            '---------SAVE-------------
            If btnSave.Text = "Save" Then

#Region "FILTER"
                '------FILTER FOR W/ DR-------
                If cmbDrOptions.Text = "W/ DR" Then
                    If cmbDrOptions.Text = "" Then
                        MessageBox.Show("Unable To save this data, please select DR option first..", "SUPPLY INFO: ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    If txtPlateNo.Text = "" Then
                        MessageBox.Show("Unable to save this data, please input an equipment first..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    If txtDriver.Text = "" Then
                        MessageBox.Show("Unable to save this data, please input a driver first..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    If txtcheckedby.Text = "" Then
                        MessageBox.Show("Unable to save this data, please input check by first..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If


                    If txtreceivedby.Text = "" Then
                        MessageBox.Show("Unable to save this data, please input received by first..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    If dgv_dr_list.Rows.Count = 0 Then
                        MessageBox.Show("Unable to save this data, please check if there is a row inserted on the list.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If
                '------------------------
#End Region
                ' dr_item_save()

                'IF SURE NA NGA E SAVE | YES
                If MessageBox.Show("Are you sure you want to save this data?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    'check sa ang selected data og naa bay mga kulang like wala na checkan, etc.

                    'check ang rows kung naa bay ge checkan | True
                    If dv.no_of_rows_selected(dgv_dr_list, "col_checkbox") > 0 Then
                        If cmbDrOptions.Text = "W/ DR" Then
                            'CHECK ANG MGA COLUMN KUNG NAA BAY BLANK
                            If dv.blank_cell(dgv_dr_list, "col_dr_no", "col_checkbox") > 0 Then
                                MessageBox.Show("Please fill in DR NO to proceed saving data..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Exit Sub
                            End If

                            If dv.blank_cell(dgv_dr_list, "col_source", "col_checkbox") > 0 Then
                                MessageBox.Show("Please fill in source to proceed saving data..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Exit Sub
                            End If
                            '----------------------
                        Else 'WITHOUT DR
                            'CHECK ANG MGA COLUMN KUNG NAA BAY BLANK
                            If dv.blank_cell(dgv_dr_list, "col_source", "col_checkbox") > 0 Then
                                MessageBox.Show("Please fill in source to proceed saving data..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Exit Sub
                            End If
                        End If

                    Else 'check ang rows kung naa bay ge checkan | FALSE
                        If dgv_dr_list.Rows.Count > 0 Then
                            MessageBox.Show("Please select atleast one item to proceed saving data..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If
                    End If

                Else 'NO
                    GoTo proceedhere
                End If

                'kwaon ang type of charges:
                'example: 
                ' - WAREHOUSE:WHS KING
                ' - PROJECT: 16-01 KING
                ' - EQUIPMENT: RMN 219


                If pub_button_name = "EquipmentUseForHaulingToolStripMenuItem" Then
                    typeofcharges = get_type_of_charges(CInt(FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text))
                End If

                If button_click_name = "EditInfoToolStripMenuItem" Then
                    typeofcharges = get_type_of_charges(CInt(FDRLIST.lvl_drList.SelectedItems(0).SubItems(15).Text))
                End If


                If cmbOptions.Text = "IN" Then

                    If with_dr_status = "in without rs" Then
                        'in without rs
                        dr_IN("IN")
                        MessageBox.Show("Successfully Save...", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        dtpDRDate.Focus()

                    ElseIf with_dr_status = "in with rs" Then

                        'Dim rs_id As Integer = FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text
                        'Dim rr_item_id As Integer = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(35).Text
                        'Dim wh_id As Integer = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(15).Text

                        Dim rs_id As Integer = FReceivingReportList.lvlreceivingreportlist.SelectedItems(0).SubItems(16).Text
                        Dim rr_item_id As Integer = FReceivingReportList.lvlreceivingreportlist.SelectedItems(0).Text
                        Dim wh_id As Integer = FReceivingReportList.lvlreceivingreportlist.SelectedItems(0).SubItems(23).Text

                        Dim dr_info_id As Integer = dr_info_id_with_save_update(2, rs_id)
                        dr_item_save(dr_info_id, rs_id, rr_item_id, wh_id, "NO")

                    ElseIf with_dr_status = "" Then
                        'in with rs
                        dr_IN("IN")
                        MessageBox.Show("Successfully Save...", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        dtpDRDate.Focus()

                    Else
                        'link in with rs
                        If typeofcharges = "WAREHOUSE" Then

                            dr_IN_to_requestor_after_OUT("IN")
                            FAggregatesForm.ShowDialog()

                        Else
                            Dim rs_id As Integer = CInt(FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text)
                            Dim dr_info_id As Integer = dr_info_id_with_save_update(2, rs_id)
                            Dim wh_id As Integer = CInt(FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(15).Text)

                            dr_item_save(dr_info_id, rs_id, 0, wh_id, "NO")

                            FRequistionForm.cmbSearchByCategory.Text = "Search by RS.No."
                            FRequistionForm.txtSearch.Text = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(1).Text

                            MessageBox.Show("Successfully Save...", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                    End If

                    'If cmbTypeofCharge.Text = "WAREHOUSE" Then
                    '    FAggregatesForm.ShowDialog()
                    'End If

                ElseIf cmbOptions.Text = "OUT" Then
                    dr_OUT("OUT")

                    If typeofcharges = "WAREHOUSE" Then
                        dr_IN_to_requestor_after_OUT("IN")
                        FAggregatesForm.ShowDialog()
                    End If

                Else

                    Dim rs_id As Integer
                    Dim wh_id As Integer

                    If pub_button_name = "CreateDRToolStripMenuItem" Then
                        rs_id = CInt(FReceivingReportList.lvlreceivingreportlist.SelectedItems(0).SubItems(16).Text)

                    ElseIf pub_button_name = "CreateDRToolStripMenuItem1" Then
                        rs_id = MyRsId
                    Else
                        rs_id = CInt(FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text)
                        wh_id = CInt(FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(15).Text)
                    End If

                    Dim dr_info_id As Integer = dr_info_id_with_save_update(2, rs_id)


                    dr_item_save(dr_info_id, rs_id, 0, wh_id, "NO")

                    If pub_button_name = "CreateDRToolStripMenuItem" Then

                    ElseIf pub_button_name = "CreateDRToolStripMenuItem1" Then

                    Else
                        FRequistionForm.cmbSearchByCategory.Text = "Search by RS.No."
                        FRequistionForm.txtSearch.Text = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(1).Text
                    End If


                    MessageBox.Show("Successfully Save...", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    'If cmbTypeofCharge.Text = "WAREHOUSE" Then
                    '    FAggregatesForm.ShowDialog()

                    'End If
                End If

            ElseIf btnSave.Text = "Update Info" Then

                Dim dr_item_id As Integer = FDRLIST.lvl_drList.SelectedItems(0).Text
                Dim rs_id As Integer = FDRLIST.lvl_drList.SelectedItems(0).SubItems(15).Text
                Dim in_out As String = FDRLIST.lvl_drList.SelectedItems(0).SubItems(16).Text
                Dim dr_no As String = FDRLIST.lvl_drList.SelectedItems(0).SubItems(1).Text

                If button_click_name = "EditInfoToolStripMenuItem" Then
                    typeofcharges = get_type_of_charges(CInt(FDRLIST.lvl_drList.SelectedItems(0).SubItems(15).Text))
                End If

                dr_info_id_with_save_update(222, rs_id)

                If typeofcharges = "WAREHOUSE" Or cmbTransaction.Text = "Stockpile to Stockpile" Then

                    If in_out = "IN" Then

                        pub_dr_item_id = dr_item_id
                        FAggregatesForm.ShowDialog()

                    ElseIf in_out = "OUT" Then

                        If MessageBox.Show("YES: LINK TO OTHER WAREHOUSE/PROJECT AND UPDATE." & vbCrLf & "NO:UPDATE ONLY", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            'check sa ang dr kung naa naba in
                            If check_dr_if_already_in(dr_no, "IN") > 0 Then
                                MessageBox.Show("DR No has already in, press yes to continue...", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Stop)
                                GoTo procceed3
                            End If

                            dr_IN_to_requestor_after_OUT("IN")
                            FAggregatesForm.ShowDialog()
                        Else
                            Dim dr_info_id As Integer = dr_info_id_with_save_update(2, rs_id)
                        End If
                    End If

                End If

procceed3:
                lbl_dr_info_id.Text = 0

                'FDRLIST.load_DR(1)
                'listfocus(FDRLIST.lvlDRList, dr_item_id)

                'If cmbTypeofCharge.Text = "WAREHOUSE" Then
                '    pub_dr_item_id = dr_item_id
                '    FAggregatesForm.ShowDialog()
                'End If

                MessageBox.Show("Successfully Updated...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Dispose()

                btnSave.Text = "Save"

            ElseIf btnSave.Text = "Update Description" Then
                Dim dr_item_id As Integer = FDRLIST.lvl_drList.SelectedItems(0).Text
                dr_item_update(dr_item_id)

                'FDRLIST.load_DR(1)
                'listfocus(FDRLIST.lvlDRList, dr_item_id)

                MessageBox.Show("Successfully Updated...", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Dispose()
            End If

proceedhere:

            If button_click_name = "EquipmentUseForHaulingToolStripMenuItem" Then
                'FRequistionForm.btnSearch.PerformClick()
                'cmbWsNo_PoNo.SelectedIndex = -1

                'If Application.OpenForms().OfType(Of FRequistionForm).Any Then
                '    FRequistionForm.btnSearch.PerformClick()
                'End If

            ElseIf button_click_name = "EditDescriptionToolStripMenuItem" Then
                Dim dr_item_id As Integer = FDRLIST.lvl_drList.SelectedItems(0).Text

                FDRLIST.btnSearch.PerformClick()

            ElseIf button_click_name = "EditInfoToolStripMenuItem" Then
                Dim dr_item_id As Integer = FDRLIST.lvl_drList.SelectedItems(0).Text

                FDRLIST.btnSearch.PerformClick()
                listfocus(FDRLIST.lvl_drList, dr_item_id)

            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cmbDrOptions.Focus()

            If with_dr_status = "in without rs" Then

            ElseIf with_dr_status = "out without rs" Then

                For Each row As DataGridViewRow In dgv_dr_list.Rows
                    If row.Cells("col_checkbox").Value = True Then
                        dgv_dr_list.Rows.Remove(row)
                    End If
                Next

            Else
                For Each row As DataGridViewRow In dgv_dr_list.Rows
                    If row.Cells("col_checkbox").Value = True Then
                        dgv_dr_list.Rows.Remove(row)
                    End If
                Next

                dtpDRDate.Select()

            End If

        End Try
    End Sub

    Private Function check_dr_if_already_in(dr_no As String, inout As String) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt1", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 5)
            newCMD.Parameters.AddWithValue("@dr_no", dr_no)
            newCMD.Parameters.AddWithValue("@inout", inout)

            newCMD.CommandTimeout = 300

            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                check_dr_if_already_in += 1
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Sub dr_IN(IN_OUT As String)
        Dim rs_id As Integer
        Dim rs_qty As Double
        Dim wh_id As Integer

        For i = 0 To dgv_dr_list.Rows.Count - 1
            If dgv_dr_list.Rows(i).Cells("col_checkbox").Value = "True" Then
                rs_qty += CDbl(dgv_dr_list.Rows(i).Cells("col_qty").Value)
                'counter+ =1
            End If
        Next

        'If counter = 0 Then
        '    MessageBox.Show("Please select atleast one item to proceed saving data..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Exit Sub
        'End If

        If button_click_name = "EquipmentUseForHaulingToolStripMenuItem" Then
            'meaning gkan ni nag click sa requisition form

            rs_id = CInt(FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text)
            wh_id = CInt(FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(15).Text)

        ElseIf button_click_name = "ItemsToolStripMenuItem" Then
            'meaning gkan ni nag click sa list of items sa warehouse

            wh_id = FListOfItems.lvlWarehouseItem.SelectedItems(0).Text

            'save sa rs
            'ang importante lng ani naay rs_id
            rs_id = need_to_save_rs(rs_qty, wh_id)

            'update ang inout to OUT
            Dim query1 As String = "UPDATE dbrequisition_slip SET IN_OUT = '" & IN_OUT & "',type_of_purchasing = '" & "DR" & "',wh_id = " & wh_id & " WHERE rs_id = " & rs_id
            UPDATE_INSERT_DELETE_QUERY(query1, 0, "UPDATE")
        End If

        'mo save sa po

        Dim po_id As Integer = INSERT_PO(1)
        FPOFORM.INSERT_PO_DETAILS(po_id, 0, 0, "", 0, "", rs_qty, "", 0, 0, rs_id, "TRUE")

        'mo save rr_info
        Dim rr_info_id As Integer
        rr_info_id = insert_dbreceiving_info("OTHERS", 2)

        'mo save rr_desc
        Dim rr_item_id As Integer
        rr_item_id = insert_update_dbreceiving_items(rr_info_id, "OTHERS", 3, "", "", 0, rs_id, rs_qty, 0, pub_po_det_id, "Include", 0)

        'mo save sa rr_partially

        'Dim query As String = "INSERT INTO dbreceiving_item_partially(rr_item_id,desired_qty) VALUES(" & rr_item_id & "," & rs_qty & ")"
        Dim par_rr_item_id As Integer = insert_dbreceiving_partially(rr_item_id, rs_qty)

        '******************************************************

        Dim dr_info_id As Integer = dr_info_id_with_save_update(2, rs_id)
        dr_item_save(dr_info_id, rs_id, par_rr_item_id, wh_id, "NO")

        'If button_click_name = "EquipmentUseForHaulingToolStripMenuItem" Then
        '    FRequistionForm.cmbSearchByCategory.Text = "Search by RS.No."
        '    FRequistionForm.txtSearch.Text = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(1).Text
        'End If

    End Sub

    Public Sub dr_OUT(IN_OUT As String)
        Dim qty As Double

        For i = 0 To dgv_dr_list.Rows.Count - 1
            If dgv_dr_list.Rows(i).Cells("col_checkbox").Value = "True" Then
                qty += dgv_dr_list.Rows(i).Cells("col_qty").Value
            End If
        Next

        Dim rs_id As Integer
        Dim wh_id As Integer = 0

        If button_click_name = "EquipmentUseForHaulingToolStripMenuItem" Or button_click_name = "clickyesaftersavepoform" Then

            wh_id = CInt(FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(15).Text)
            rs_id = CInt(FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text)

        ElseIf button_click_name = "ItemsToolStripMenuItem" Then


            wh_id = FListOfItems.lvlWarehouseItem.SelectedItems(0).Text

            'save sa sa rs
            'ang imprtante lng ani naay rs_id
            rs_id = need_to_save_rs(qty, wh_id)

            'for update sa rs gkan sa aggregates form
            pub_rs_id = rs_id

            'save ws
            Dim po_id As Integer = INSERT_PO(1)

            FPOFORM.INSERT_PO_DETAILS(po_id, 0, wh_id, "", 0, "", qty, "", 0, 0, rs_id, "TRUE")

            'update ang inout to OUT
            Dim query1 As String = "UPDATE dbrequisition_slip SET IN_OUT = '" & IN_OUT & "',type_of_purchasing = '" & "WITHDRAWAL" & "',wh_id = " & wh_id & " WHERE rs_id = " & rs_id
            UPDATE_INSERT_DELETE_QUERY(query1, 0, "UPDATE")

            'save withdrawn items
            Dim ws_id As Integer = pub_po_det_id

            Dim query As String = "INSERT INTO dbwithdrawn_items(rs_id,ws_id) VALUES(" & rs_id & "," & ws_id & ")"
            UPDATE_INSERT_DELETE_QUERY(query, 0, "INSERT")

        End If

        '******************************************************

        'and lastly save dr information
        'with dr or without dr

        Dim dr_info_id As Integer = dr_info_id_with_save_update(2, rs_id)
        dr_item_save(dr_info_id, rs_id, 0, wh_id, "NO")

        MessageBox.Show("Successfully Save...", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Public Sub dr_IN_to_requestor_after_OUT(IN_OUT As String)
        Dim rs_id As Integer
        Dim rs_qty As Double
        Dim pass_wh_id As Integer

        For i = 0 To dgv_dr_list.Rows.Count - 1
            If dgv_dr_list.Rows(i).Cells("col_checkbox").Value = "True" Then
                rs_qty += CDbl(dgv_dr_list.Rows(i).Cells("col_qty").Value)
                'counter+ =1
            End If
        Next

        'GET REQUESTOR ID

        If cmbTypeofCharge.Text = "EQUIPMENT" Or cmbTypeofCharge.Text = "PROJECT" Then
            pass_wh_id = get_requestor_id(cmbTypeofCharge.Text, cmbChargeTo.Text)
        Else
            pass_wh_id = get_requestor_id(cmbTypeofCharge.Text, txtChargeTo.Text)
        End If

        'save sa rs
        'ang importante lng ani naay rs_id
        rs_id = need_to_save_rs(rs_qty, pass_wh_id)
        pub_rs_id = rs_id

        'update ang inout to OUT
        Dim query1 As String = "UPDATE dbrequisition_slip SET IN_OUT = '" & IN_OUT & "',type_of_purchasing = '" & "DR" & "',wh_id = " & pass_wh_id & " WHERE rs_id = " & rs_id
        UPDATE_INSERT_DELETE_QUERY(query1, 0, "UPDATE")


        'mo save sa po

        Dim po_id As Integer = INSERT_PO(1)
        FPOFORM.INSERT_PO_DETAILS(po_id, 0, 0, "", 0, "", rs_qty, "", 0, 0, rs_id, "TRUE")

        'mo save rr_info
        Dim rr_info_id As Integer
        rr_info_id = insert_dbreceiving_info("OTHERS", 2)

        'mo save rr_desc
        Dim rr_item_id As Integer
        rr_item_id = insert_update_dbreceiving_items(rr_info_id, "OTHERS", 3, "", "", 0, rs_id, rs_qty, 0, pub_po_det_id, "Include", 0)

        'mo save sa rr_partially

        'Dim query As String = "INSERT INTO dbreceiving_item_partially(rr_item_id,desired_qty) VALUES(" & rr_item_id & "," & rs_qty & ")"
        Dim par_rr_item_id As Integer = insert_dbreceiving_partially(rr_item_id, rs_qty)

        '******************************************************


        Dim dr_info_id As Integer = dr_info_id_with_save_update(2, rs_id)

        If IN_OUT = "IN" Then
            If btnSave.Text = "Update Info" Then
                Dim selected_dr_item_id As Integer = FDRLIST.lvl_drList.SelectedItems(0).Text
                dr_item_save1(selected_dr_item_id, rs_id, par_rr_item_id, pass_wh_id, "YES", dr_info_id)
            Else
                dr_item_save(dr_info_id, rs_id, par_rr_item_id, pass_wh_id, "YES")
            End If
        Else
            dr_item_save(dr_info_id, rs_id, par_rr_item_id, pass_wh_id, "YES")
        End If


        'If button_click_name = "EquipmentUseForHaulingToolStripMenuItem" Then
        '    FRequistionForm.cmbSearchByCategory.Text = "Search by RS.No."
        '    FRequistionForm.txtSearch.Text = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(1).Text
        'End If

    End Sub
    Public Function get_requestor_id(typeofrequestor As String, requestor As String) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 19)
            newCMD.Parameters.AddWithValue("@type_of_request", typeofrequestor)
            newCMD.Parameters.AddWithValue("@requestor", requestor)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_requestor_id = CInt(IIf(newDR.Item(0).ToString = "", 0, newDR.Item(0).ToString))
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Function insert_dbreceiving_partially(rr_item_id As Integer, desired_qty As Double) As Integer

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 18)
            newCMD.Parameters.AddWithValue("@rr_item_id1", rr_item_id)
            newCMD.Parameters.AddWithValue("@qty", desired_qty)

            insert_dbreceiving_partially = newCMD.ExecuteScalar()


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Function need_to_save_rs(qty As Double, wh_id As Integer) As Integer
        Dim SQ As New SQLcon
        Dim cmd As SqlCommand

        SQ.connection.Open()

        publicquery = "SET NOCOUNT ON;"
        publicquery = "INSERT INTO dbrequisition_slip(rs_no,date_req,job_order_no,charge_to,location,"
        publicquery &= "wh_id,item_desc,qty,unit,typeRequest,process,purpose,date_needed,requested_by,noted_by,wh_incharge,approved_by,IN_OUT,date_log,type_of_purchasing,remarks,user_id)"
        publicquery &= " VALUES('" & IIf(UIRsNo.ifBlankTexbox(), "N/A", txtrsno.Text) & "','"
        publicquery &= Date.Parse(dtpDRDate.Text) & "','" & 0 & "','" & 0 & "','"
        publicquery &= "" & "','" & wh_id & "','" & "" & "'," & qty & ",'" & "" & "','"
        publicquery &= "" & "','" & "" & "','" & "" & "','" & Date.Parse(dtpDRDate.Text) & "','" & "" & "','"
        publicquery &= "" & "','" & "" & "','" & "" & "','" & "" & "','" & Format(Date.Parse(Now), "yyyy-MM-dd") & "','" & "" & "','" & from_old_item_or_new_item & "','" & pub_user_id & "') "

        publicquery &= "SELECT SCOPE_IDENTITY()"

        cmd = New SqlCommand(publicquery, SQ.connection)
        need_to_save_rs = cmd.ExecuteScalar()

        SQ.connection.Close()

    End Function
    Public Function insert_update_dbreceiving_items(ByVal rr_info_id As Integer, ByVal type As String, ByVal n As Integer, ByVal item_desc As String, ByVal remarks As String, ByVal wh_id As Integer, ByVal rs_id As Integer, ByVal qty As Decimal, rowindex As Integer, po_det_id As Integer, selected As String, rr_item_id As Integer) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@type", type)

            newCMD.Parameters.AddWithValue("@rr_info_id", rr_info_id)
            newCMD.Parameters.AddWithValue("@item_desc", item_desc)
            newCMD.Parameters.AddWithValue("@remarks", remarks)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.Parameters.AddWithValue("@qty", qty)
            newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)
            newCMD.Parameters.AddWithValue("@selected", selected)

            If n = 3 Then 'insert
                rr_item_id = newCMD.ExecuteScalar
                Return rr_item_id
            ElseIf n = 33 Then 'update
                newCMD.Parameters.AddWithValue("@rr_item_id", rr_item_id)
                newCMD.ExecuteNonQuery()
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Public Function insert_dbreceiving_info(ByVal type As String, ByVal n As Integer) As Integer
        'Dim suppname, invoiceno, supplier, po_no, rs_no, receivedby, checkedby, receivedstatus, so_no, hauler, plateno As String
        'Dim date_received As DateTime

        With FReceiving_Info
            Dim newSQ As New SQLcon
            Dim newCMD As SqlCommand
            Dim supplier_id As Integer = get_id("dbSupplier", "Supplier_Name", .cmbSupplier.Text, 0)
            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_receiving_crud_new", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", n)
                newCMD.Parameters.AddWithValue("@type", type)

                newCMD.Parameters.AddWithValue("@rr_no", "n/a")
                newCMD.Parameters.AddWithValue("@invoice_no", "n/a")
                newCMD.Parameters.AddWithValue("@supplier_id", _supplierId)
                newCMD.Parameters.AddWithValue("@po_no", "n/a")
                newCMD.Parameters.AddWithValue("@rs_no", "n/a")
                newCMD.Parameters.AddWithValue("@date_received", Date.Parse(dtpDRDate.Text))
                newCMD.Parameters.AddWithValue("@received_by", "n/a")
                newCMD.Parameters.AddWithValue("@checked_by", "n/a")
                newCMD.Parameters.AddWithValue("@received_status", "PENDING")
                newCMD.Parameters.AddWithValue("@so_no", "n/a")
                newCMD.Parameters.AddWithValue("@hauler", "n/a")
                newCMD.Parameters.AddWithValue("@plateno", "n/a")
                newCMD.Parameters.AddWithValue("@date_log", Format(Date.Parse(dtpDRDate.Text), "yyyy-MM-dd"))
                newCMD.Parameters.AddWithValue("@user_id", pub_user_id)

                insert_dbreceiving_info = newCMD.ExecuteScalar()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try
        End With

    End Function
    Public Function INSERT_PO(n As Integer) As Integer
        Dim SQ As New SQLcon
        Dim cmd As SqlCommand

        Try
            SQ.connection.Open()

            cmd = New SqlCommand("proc_po_query", SQ.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@n", n)

            cmd.Parameters.AddWithValue("@po_date", Date.Parse(dtpDRDate.Text))
            cmd.Parameters.AddWithValue("@rs_no", IIf(UIRsNo.ifBlankTexbox(), "N/A", txtrsno.Text))
            cmd.Parameters.AddWithValue("@instructions", "n/a")
            cmd.Parameters.AddWithValue("@charge_to", 0)
            cmd.Parameters.AddWithValue("@charge_type", "n/a")
            cmd.Parameters.AddWithValue("@date_needed", Date.Parse(dtpDRDate.Text))
            cmd.Parameters.AddWithValue("@prepared_by", "n/a")
            cmd.Parameters.AddWithValue("@checked_by", "n/a")
            cmd.Parameters.AddWithValue("@approved_by", "n/a")
            cmd.Parameters.AddWithValue("@user_id", pub_user_id)
            cmd.Parameters.AddWithValue("@date_log", Format(Date.Parse(Now), "yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@dr_option", cmbDrOptions.Text)

            INSERT_PO = cmd.ExecuteScalar()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

    End Function

    Public Sub dr_item_save(dr_info_id As Integer, rs_id As Integer, par_rr_item_id As Integer, pass_wh_id As Integer, in_to_stock_card As String)
        Try
            Dim newSQ As New SQLcon
            Dim newCMD As SqlCommand

            Dim wh_id, ws_id As Integer
            Dim qty As Double

            Dim dr_no, source, category, item_name_desc As String

            With dgv_dr_list
                For i = 0 To .Rows.Count - 1
                    Dim check As String = .Rows(i).Cells("col_checkbox").Value

                    If check = "False" Or check = "" Then

                    Else
                        If button_click_name = "EquipmentUseForHaulingToolStripMenuItem" Then

                            'rs_id = .Rows(i).Cells("col_rs_id").Value

                        ElseIf button_click_name = "ItemsToolStripMenuItem" Then

                            'rs_id = default 

                        End If

                        qty = .Rows(i).Cells("col_qty").Value
                        dr_no = .Rows(i).Cells("col_dr_no").Value
                        source = .Rows(i).Cells("col_source").Value
                        category = .Rows(i).Cells("col_category").Value
                        item_name_desc = .Rows(i).Cells("col_item_name").Value

                        'wh_id = .Rows(i).Cells("col_wh_id").Value
                        ws_id = .Rows(i).Cells("col_ws_id").Value

                        newSQ.connection.Open()
                        newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
                        newCMD.Parameters.Clear()
                        newCMD.CommandType = CommandType.StoredProcedure

                        newCMD.Parameters.AddWithValue("@n", 3)
                        newCMD.Parameters.AddWithValue("@dr_info_id", dr_info_id)
                        newCMD.Parameters.AddWithValue("@rs_id", rs_id)
                        newCMD.Parameters.AddWithValue("@qty", qty)
                        newCMD.Parameters.AddWithValue("@dr_no", dr_no)
                        newCMD.Parameters.AddWithValue("@source", source)
                        newCMD.Parameters.AddWithValue("@category", category)
                        newCMD.Parameters.AddWithValue("@wh_id", pass_wh_id)
                        newCMD.Parameters.AddWithValue("@par_rr_item_id", par_rr_item_id) 'this is suppose to be rr_item_id not par_rr_item_id
                        newCMD.Parameters.AddWithValue("@in_to_stock_card", in_to_stock_card)
                        newCMD.Parameters.AddWithValue("@user_id", pub_user_id)

                        pub_dr_item_id = newCMD.ExecuteScalar()

                        newSQ.connection.Close()

                    End If

                Next
            End With
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Public Sub dr_item_save1(selected_dr_items_id As Integer, rs_id As Integer, par_rr_item_id As Integer, pass_wh_id As Integer, in_to_stock_card As String, dr_info_id As Integer)
        Dim newSQ1 As New SQLcon
        Dim newCMD1 As SqlCommand
        Dim newDR1 As SqlDataReader

        Dim dr_no, source, category, item_name_desc As String

        Dim wh_id As Integer
        Dim qty As Double

        Try
            newSQ1.connection.Open()

            newCMD1 = New SqlCommand("proc_Delivery_Receipt", newSQ1.connection)
            newCMD1.Parameters.Clear()
            newCMD1.CommandType = CommandType.StoredProcedure
            newCMD1.Parameters.AddWithValue("@n", 66)
            newCMD1.Parameters.AddWithValue("@dr_item_id", selected_dr_items_id)

            newDR1 = newCMD1.ExecuteReader

            While newDR1.Read

                dr_no = newDR1.Item("dr_no").ToString
                source = newDR1.Item("SOURCE").ToString
                category = newDR1.Item("category").ToString
                qty = newDR1.Item("qty").ToString
                item_name_desc = newDR1.Item("ITEM_NAME").ToString
                wh_id = newDR1.Item("wh_id").ToString

            End While
            newDR1.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ1.connection.Close()

            dr_item_save2(dr_info_id, rs_id, qty, dr_no, source, category, wh_id, par_rr_item_id, in_to_stock_card, pub_user_id)
        End Try

    End Sub

    Public Sub dr_item_save2(dr_info_id As Integer, rs_id As Integer, qty As Double, dr_no As String, source As String, category As String, wh_id As Integer, par_rr_item_id As Integer, in_to_stock_card As String, pub_user_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            With dgv_dr_list

                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 3)
                newCMD.Parameters.AddWithValue("@dr_info_id", dr_info_id)
                newCMD.Parameters.AddWithValue("@rs_id", rs_id)
                newCMD.Parameters.AddWithValue("@qty", qty)
                newCMD.Parameters.AddWithValue("@dr_no", dr_no)
                newCMD.Parameters.AddWithValue("@source", source)
                newCMD.Parameters.AddWithValue("@category", category)
                newCMD.Parameters.AddWithValue("@wh_id", wh_id)
                newCMD.Parameters.AddWithValue("@par_rr_item_id", par_rr_item_id)
                newCMD.Parameters.AddWithValue("@in_to_stock_card", in_to_stock_card)
                newCMD.Parameters.AddWithValue("@user_id", pub_user_id)
                pub_dr_item_id = newCMD.ExecuteScalar()

                newSQ.connection.Close()
            End With

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Public Sub dr_item_update(dr_info_id As Integer)
        Try
            Dim newSQ As New SQLcon
            Dim newCMD As SqlCommand

            Dim rs_id, wh_id, dr_item_id As Integer
            Dim qty As Double

            Dim dr_no, source, category, item_name_desc As String

            With dgv_dr_list
                For i = 0 To .Rows.Count - 1

                    rs_id = .Rows(i).Cells("col_rs_id").Value
                    qty = .Rows(i).Cells("col_qty").Value
                    dr_no = .Rows(i).Cells("col_dr_no").Value
                    source = .Rows(i).Cells("col_source").Value
                    category = .Rows(i).Cells("col_category").Value
                    item_name_desc = .Rows(i).Cells("col_item_name").Value
                    wh_id = .Rows(i).Cells("col_wh_id").Value
                    dr_item_id = .Rows(i).Cells("col_dr_item_id").Value

                    newSQ.connection.Open()
                    newCMD = New SqlCommand("proc_Delivery_Receipt1", newSQ.connection)
                    newCMD.Parameters.Clear()
                    newCMD.CommandType = CommandType.StoredProcedure

                    'newCMD.Parameters.AddWithValue("@n", 33)
                    newCMD.Parameters.AddWithValue("@n", 7)
                    newCMD.Parameters.AddWithValue("@dr_info_id", dr_info_id)
                    newCMD.Parameters.AddWithValue("@rs_id", rs_id)
                    newCMD.Parameters.AddWithValue("@qty", qty)
                    newCMD.Parameters.AddWithValue("@dr_no", dr_no)
                    newCMD.Parameters.AddWithValue("@source", source)
                    newCMD.Parameters.AddWithValue("@category", category)
                    newCMD.Parameters.AddWithValue("@wh_id", wh_id)
                    newCMD.Parameters.AddWithValue("@dr_item_id", dr_item_id)

                    newCMD.ExecuteNonQuery()
                    newSQ.connection.Close()

                Next
            End With
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Public Function dr_info_id_with_save_update(n As Integer, rs_id As Integer) As Integer
        Dim drdate, time_from, time_to As DateTime

        Dim type_of_request, address, rs_no, po_no, concession_ticket_no, checked_by, received_by, plate_no, plateno1, driver, requestor, supplier, options, ws_po_no, rr_no As String
        Dim price As Double

        drdate = Date.Parse(dtpDRDate.Text)
        'time_from = Date.Parse(dtpTimeFrom.Text)
        'time_to = Date.Parse(dtpTime_to.Text)
        plate_no = IIf(UIPlateNo.ifBlankTexbox(), "", txtPlateNo.Text)
        driver = IIf(UIOperator.ifBlankTexbox(), "", txtDriver.Text) 'cmbOperator.Text
        type_of_request = IIf(UITypeOfCharge.ifBlankCombobox(), "", cmbTypeofCharge.Text)
        ws_po_no = IIf(UIWsNoPoNo.ifBlankCombobox(), "", UIWsNoPoNo.cBox.Text)
        rr_no = IIf(UIRRNo.ifBlankCombobox(), "", cmbRRNo.Text)


        If type_of_request = "PROJECT" Then
            requestor = cmbChargeTo.Text
            'plate_no = cmbChargeTo.Text
        Else
            requestor = txtChargeTo.Text
        End If

        'address = txtaddress.Text
        rs_no = IIf(UIRsNo.ifBlankTexbox(), "N/A", txtrsno.Text)
        supplier = IIf(UISupplier.ifBlankCombobox(), "", cmbSupplier.Text)
        ' po_no = txtpono.Text
        concession_ticket_no = IIf(UIConcession.ifBlankTexbox(), "", txtconcession.Text)
        checked_by = IIf(UIConcession.ifBlankTexbox(), "", txtcheckedby.Text)
        received_by = IIf(UIReceivedBy.ifBlankTexbox(), "", txtreceivedby.Text)
        options = IIf(UIdrOption.ifBlankTexbox(), "", cmbDrOptions.Text)
        price = IIf(UIprice.ifBlankTexbox(), 0, txtprice.Text)


        'GET REQUESTOR ID
        Dim requestor_id As Integer = getRequestorId(cmbTypeofCharge.Text, txtChargeTo.Text)


        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt5", newSQ.connection) 'old store procedure | proc_Delivery_Receipt
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.Parameters.AddWithValue("@date", drdate)
            'newCMD.Parameters.AddWithValue("@time_from", time_from)
            ' newCMD.Parameters.AddWithValue("@time_to", time_to)
            newCMD.Parameters.AddWithValue("@plate_no", plate_no)
            newCMD.Parameters.AddWithValue("@driver", driver)
            newCMD.Parameters.AddWithValue("@type_of_request", type_of_request)
            newCMD.Parameters.AddWithValue("@requestor_id", requestor_id) 'old | @requestor
            'newCMD.Parameters.AddWithValue("@address", address)
            newCMD.Parameters.AddWithValue("@rs_no", rs_no)
            newCMD.Parameters.AddWithValue("@supplier", supplier)
            newCMD.Parameters.AddWithValue("@supplier_id", _supplierId)
            newCMD.Parameters.AddWithValue("@po_no", ws_po_no)
            newCMD.Parameters.AddWithValue("@con_ticket_no", concession_ticket_no)
            newCMD.Parameters.AddWithValue("@checkedby", checked_by)
            newCMD.Parameters.AddWithValue("@receivedby", received_by)
            newCMD.Parameters.AddWithValue("@dr_info_id", lbl_dr_info_id.Text)
            newCMD.Parameters.AddWithValue("@options", options)
            newCMD.Parameters.AddWithValue("@remarks", txtRemarks.Text)
            newCMD.Parameters.AddWithValue("@price", CDbl(txtprice.Text))
            newCMD.Parameters.AddWithValue("@rr_no", rr_no)
            newCMD.Parameters.AddWithValue("@dateSubmitted", Date.Parse(dtpDateSubmitted.Text))

            If n = 2 Then
                dr_info_id_with_save_update = newCMD.ExecuteScalar()
            ElseIf n = 222 Then
                newCMD.ExecuteNonQuery()
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

            If n = 222 Then
                If FDRLIST.lvl_drList.SelectedItems(0).SubItems(16).Text = "IN" Then

                    Dim query As String = "UPDATE dbreceiving_info SET date_received = '" & drdate & "' WHERE rr_info_id = " & get_rr_info_id_to_update_date()
                    UPDATE_INSERT_DELETE_QUERY(query, 0, "UPDATE")

                End If

            End If
        End Try
    End Function

    'get requestor/charges id
    Private Function getRequestorId(category As String, chargesName As String) As Integer
        For Each requestor In cListOfRequestorCharges
            If requestor.category.ToLower() = category.ToLower() And requestor.charges_desc.ToLower() = chargesName.ToLower() Then
                getRequestorId = requestor.charges_id
            End If
        Next

    End Function

    Private Function get_rr_info_id_to_update_date() As Integer
        Dim newSQ As New SQLcon
        Try

            Dim newcmd As SqlCommand
            Dim newdr As SqlDataReader

            newSQ.connection.Open()

            Dim query As String
            query = "SELECT c.rr_info_id FROM dbreceiving_item_partially a "
            query &= "LEFT JOIN dbreceiving_items b "
            query &= "On b.rr_item_id = a.rr_item_id "
            query &= "LEFT JOIN dbreceiving_info c "
            query &= "ON c.rr_info_id = b.rr_info_id "
            query &= "WHERE a.par_rr_item_id  = " & FDRLIST.lvl_drList.SelectedItems(0).SubItems(20).Text

            newcmd = New SqlCommand(query, newSQ.connection)
            newdr = newcmd.ExecuteReader

            While newdr.Read
                get_rr_info_id_to_update_date = newdr.Item("rr_info_id").ToString
            End While

            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Function
    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs) Handles Panel7.Paint

    End Sub

    Private Sub cmbOperator_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOperator.SelectedIndexChanged

    End Sub

    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem.Click
        With dgv_dr_list
            For Each row As DataGridViewRow In dgv_dr_list.Rows

                row.Cells(0).Value = "True"

            Next
        End With
    End Sub

    Private Sub UnselectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnselectToolStripMenuItem.Click
        With dgv_dr_list
            For Each row As DataGridViewRow In dgv_dr_list.Rows

                row.Cells(0).Value = "False"

            Next
        End With
    End Sub

    Private Sub CMS_dgv_dr_list_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CMS_dgv_dr_list.Opening
        If btnSave.Text = "Update Description" Then
            'SplitQtyToolStripMenuItem.Enabled = False
        Else
            SplitQtyToolStripMenuItem.Enabled = True
        End If

        If cmbOptions.Text = "OUT" Then
            AddSourceToolStripMenuItem.Enabled = False
        Else
            AddSourceToolStripMenuItem.Enabled = True
        End If

        If button_click_name = "EditDescriptionToolStripMenuItem" Then
            If FDRLIST.lvl_drList.SelectedItems(0).SubItems(16).Text = "OUT" Then
                AddSourceToolStripMenuItem.Enabled = False
            Else
                AddSourceToolStripMenuItem.Enabled = True
            End If
        ElseIf button_click_name = "ItemsToolStripMenuItem" Then
            AddSourceToolStripMenuItem.Enabled = True
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDrOptions.SelectedIndexChanged
        Select Case cmbDrOptions.Text

            Case "W/ DR"

                'dtpTimeFrom.Enabled = True
                'dtpTime_to.Enabled = True
                txtPlateNo.Enabled = True
                'txtaddress.Enabled = True
                'txtChargeTo.Enabled = True
                txtcheckedby.Enabled = True
                txtconcession.Enabled = True
                txtrsno.Enabled = True

                If pub_button_name = "CreateDRToolStripMenuItem" Or pub_button_name = "CreateDRToolStripMenuItem1" Then
                    Panel9.Enabled = False
                ElseIf cStatus.status = Status.othersWithoutRs Or Status.inWithoutRs Then
                    Panel9.Enabled = True
                Else
                    Panel9.Enabled = True
                End If



                'txtpono.Enabled = True
                cmbWsNo_PoNo.Enabled = True
                cmbSupplier.Enabled = True
                txtcheckedby.Enabled = True
                txtreceivedby.Enabled = True
                cmbOperator.Enabled = True

                For Each row As DataGridViewRow In dgv_dr_list.Rows
                    row.Cells("col_dr_no").ReadOnly = False
                    row.Cells("col_dr_no").Value = ""
                Next


            Case "W/O DR"

                'dtpTimeFrom.Enabled = False
                ' dtpTime_to.Enabled = False
                txtPlateNo.Enabled = False
                'txtaddress.Enabled = False
                txtChargeTo.Enabled = False
                txtcheckedby.Enabled = False
                txtconcession.Enabled = False
                txtrsno.Enabled = False

                If pub_button_name = "CreateDRToolStripMenuItem" Or pub_button_name = "CreateDRToolStripMenuItem1" Then
                    Panel9.Enabled = False
                Else
                    Panel9.Enabled = True
                End If

                'txtpono.Enabled = False
                cmbWsNo_PoNo.Enabled = False
                cmbSupplier.Enabled = False
                txtcheckedby.Enabled = False
                txtreceivedby.Enabled = False
                cmbOperator.Enabled = False

                For Each row As DataGridViewRow In dgv_dr_list.Rows
                    row.Cells("col_dr_no").ReadOnly = True
                    row.Cells("col_dr_no").Value = "n/a"
                Next

                If with_dr_status = "in without rs" Then
                    Panel9.Enabled = False
                End If

        End Select

    End Sub

    Private Sub cmbOptions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOptions.SelectedIndexChanged
        If cmbOptions.Text = "In" Then
            For Each row As DataGridViewRow In dgv_dr_list.Rows
                row.Cells("col_qty").ReadOnly = False
                row.Cells("col_qty").Value = 0
            Next
            txtprice.Enabled = False
        ElseIf cmbOptions.Text = "OUT" Then
            For Each row As DataGridViewRow In dgv_dr_list.Rows
                row.Cells("col_qty").ReadOnly = True
            Next
            txtprice.Enabled = False
        Else
            txtprice.Enabled = True
        End If
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click

        For Each row As DataGridViewRow In dgv_dr_list.Rows
            If row.Selected = True Then
                copycategory = row.Cells("col_category").Value
                copysource = row.Cells("col_source").Value
            End If
        Next

    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click

        For Each row As DataGridViewRow In dgv_dr_list.Rows
            If row.Selected = True Then
                row.Cells("col_category").Value = copycategory
                row.Cells("col_source").Value = copysource
            End If
        Next

    End Sub

    Private Sub txtaddress_TextChanged(sender As Object, e As EventArgs) Handles txtcheckedby.TextChanged, txtreceivedby.TextChanged
        'Dim txtbox As TextBox = sender
        'Try
        '    If txtbox.Text = "" Then
        '        lboxUnit.Location = New System.Drawing.Point(txtbox.Location.X, txtbox.Location.Y + txtbox.Height)
        '        lboxUnit.Visible = False
        '    Else
        '        lboxUnit.Visible = True
        '        lboxUnit.BringToFront()
        '        With lboxUnit
        '            .Location = New System.Drawing.Point(txtbox.Location.X, txtbox.Location.Y + txtbox.Height)
        '            .Visible = True
        '            .Items.Clear()
        '            .Width = txtbox.Width
        '        End With

        '        get_dr_info(sender.name, txtbox.Text, txtbox)

        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("Error MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub


    Public Function get_dr_info(field As String, search As String, txtbox As TextBox)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        lboxUnit.Items.Clear()
        tboxname = txtbox.Name

        Dim counter As Integer = 0

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 13)
            newCMD.Parameters.AddWithValue("@field", field)
            newCMD.Parameters.AddWithValue("@search", search)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                lboxUnit.Items.Add(newDR.Item(0).ToString)
                counter += 1
            End While

            If counter = 0 Then
                lboxUnit.Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Private Sub txtcheckedby_TextChanged(sender As Object, e As EventArgs) Handles txtcheckedby.TextChanged

    End Sub

    Private Sub txtsplitqty_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsplitqty.KeyDown
        If Not (e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 48 Or e.KeyValue = 49 Or e.KeyValue = 50 Or e.KeyValue = 51 Or e.KeyValue = 52 Or e.KeyValue = 53 Or e.KeyValue = 54 Or
         e.KeyValue = 55 Or e.KeyValue = 56 Or e.KeyValue = 57 Or e.KeyValue = 96 Or e.KeyValue = 97 Or e.KeyValue = 98 Or e.KeyValue = 99 Or
         e.KeyCode = Keys.OemPeriod Or
        e.KeyValue = 100 Or e.KeyValue = 101 Or e.KeyValue = 102 Or e.KeyValue = 103 Or e.KeyValue = 104 Or e.KeyValue = 105 Or e.KeyValue = 37 Or e.KeyValue = 110 Or e.KeyValue = 39) Then

            e.SuppressKeyPress() = True
        End If

        If e.KeyCode = Keys.Enter Then

            Button5.PerformClick()

        End If
    End Sub

    Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtcheckedby.KeyDown, txtreceivedby.KeyDown, txtPlateNo.KeyDown, txtDriver.KeyDown


        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then

            If lboxUnit.Visible = True Then
                If lboxUnit.Items.Count > 0 Then
                    lboxUnit.Focus()
                    lboxUnit.SelectedIndex = 0
                End If
            End If
        End If
    End Sub

    Private Sub lboxUnit_KeyDown(sender As Object, e As KeyEventArgs) Handles lboxUnit.KeyDown
        If e.KeyCode = Keys.Enter Then

            If lboxUnit.Items.Count > 0 Then

                For Each ctr As Control In Panel7.Controls
                    If ctr.Name = txtname1 Then
                        ctr.Text = lboxUnit.SelectedItem.ToString
                        ctr.Focus()
                        lboxUnit.Visible = False
                        lboxUnit.Items.Clear()
                        Exit Sub
                    End If
                Next
            End If
        End If

    End Sub

    Private Sub cmbWsNo_PoNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbWsNo_PoNo.SelectedIndexChanged


        '--------------------------- DONT REMOVE ---------------------------------


        If cmbOptions.Text = "IN" Then

            If dgv_dr_list.Rows.Count > 0 Then
                For i = 0 To 11
                    copy_data_from_list(i) = dgv_dr_list.Rows(0).Cells(i).Value
                Next
            End If

            dgv_dr_list.Rows.Clear()

            dgv_dr_list.Rows.Add(copy_data_from_list)


            If ws_vs_dr() = 0 Then
                dgv_dr_list.Rows.Clear()
                Exit Sub
            End If

            If dgv_dr_list.Rows.Count > 0 Then
                'dgv_dr_list.Rows(0).Cells("col_qty").Value = get_qty_left_from_withdrawal(cmbWsNo_PoNo.Text)
                dgv_dr_list.Rows(0).Cells("col_qty").Value = ws_vs_dr()

                If if_withdrawn(cmbWsNo_PoNo.Text) = False Then

                    If cmbWsNo_PoNo.Text = "" Then

                    Else
                        If cmbOptions.Text = "OTHERS" Or cmbOptions.Text = "IN" Then

                        Else
                            MessageBox.Show("The WS No. you've selected has not been withdrawn yet.." & vbCrLf &
                             "go-to withdrawl slip form to withdraw the items.", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            dgv_dr_list.Rows.Clear()
                        End If

                    End If
                    Exit Sub
                End If
                'set qty

            End If

            If btnSave.Text = "Update Info" Then
                dgv_dr_list.Rows.Clear()
            End If

        Else
            Dim wh_id As Integer

            If dgv_dr_list.Rows.Count > 0 Then
                For i = 0 To 11
                    copy_data_from_list(i) = dgv_dr_list.Rows(0).Cells(i).Value
                Next
            End If

            'cmbWsNo_PoNo.SelectedIndex = 0

            'dgv_dr_list.Rows.Add(copy_data_from_list)

            If get_qty_left_from_withdrawal(cmbWsNo_PoNo.Text) = 0 Then
                dgv_dr_list.Rows.Clear()
                Exit Sub

            Else
                dgv_dr_list.Rows.Clear()
                dgv_dr_list.Rows.Add(copy_data_from_list)
            End If

            If dgv_dr_list.Rows.Count > 0 Then

                wh_id = dgv_dr_list.Rows(0).Cells("col_wh_id").Value

                dgv_dr_list.Rows(0).Cells("col_qty").Value = get_qty_left_from_withdrawal(cmbWsNo_PoNo.Text)
                dgv_dr_list.Rows(0).Cells("col_source").Value = get_source(wh_id)

                'dgv_dr_list.Rows(2).Cells("Source").Value = ""

                If if_withdrawn(cmbWsNo_PoNo.Text) = False Then

                    If cmbWsNo_PoNo.Text = "" Then

                    Else
                        If cmbOptions.Text = "OTHERS" Then

                        Else
                            MessageBox.Show("The WS No. you've selected has not been withdrawn yet.." & vbCrLf &
                             "go-to withdrawl slip form to withdraw the items.", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            dgv_dr_list.Rows.Clear()
                        End If

                    End If
                    Exit Sub
                End If
                'set qty

            End If


            If btnSave.Text = "Update Info" Then
                dgv_dr_list.Rows.Clear()
            End If
        End If

    End Sub

    Public Function ws_vs_dr() As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 422)
            'newCMD.Parameters.AddWithValue("@project", "BAASP")
            newCMD.Parameters.AddWithValue("@searchby1", "WS NO")

            If pub_button_name = "EquipmentUseForHaulingToolStripMenuItem" Then
                newCMD.Parameters.AddWithValue("@rs_id", FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text)
            Else

            End If

            newCMD.Parameters.AddWithValue("@search", cmbWsNo_PoNo.Text)

            newDR = newCMD.ExecuteReader

            Dim a(10) As String

            While newDR.Read
                ws_vs_dr = newDR.Item("qty").ToString
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Private Function get_source(wh_id As Integer) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT b.wh_area FROM dbwarehouse_items a LEFT JOIN dbwh_area b ON b.wh_area_id = a.whArea WHERE a.wh_id = " & wh_id
            newCMD = New SqlCommand(query, newSQ.connection)

            newDR = newCMD.ExecuteReader
            While newDR.Read
                get_source = newDR.Item("wh_area").ToString
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Private Function if_withdrawn(ws_no As String) As Boolean
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_withdrawal_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 10)
            newCMD.Parameters.AddWithValue("@ws_no", ws_no)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                'MsgBox(newDR.Item("rs_id").ToString)

                If newDR.Item("COUNT_WITHDRAWN").ToString > 0 Then
                    if_withdrawn = True
                Else
                    if_withdrawn = False
                End If

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function

    Public Function get_qty_left_from_withdrawal(ws_po_no_rr_no As String) As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim rs_id As Integer

        If pub_button_name = "EquipmentUseForHaulingToolStripMenuItem" Then
            rs_id = FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text
        ElseIf pub_button_name = "EditInfoToolStripMenuItem" Then
            rs_id = FDRLIST.lvl_drList.SelectedItems(0).SubItems(15).Text
        ElseIf pub_button_name = "CreateDRToolStripMenuItem" Then
            rs_id = FReceivingReportList.lvlreceivingreportlist.SelectedItems(0).SubItems(16).Text
        End If

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_withdrawal_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            If cmbOptions.Text = "OUT" Then

                newCMD.Parameters.AddWithValue("@n", 9)
                newCMD.Parameters.AddWithValue("@ws_no", ws_po_no_rr_no)
                newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            ElseIf cmbOptions.Text = "IN" Or cmbOptions.Text = "OTHERS" Then

                newCMD.Parameters.AddWithValue("@n", 99)
                newCMD.Parameters.AddWithValue("@rr_no", ws_po_no_rr_no)
                newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            End If

            newDR = newCMD.ExecuteReader

            While newDR.Read

                get_qty_left_from_withdrawal = newDR.Item("qty").ToString

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Function

    Public Function get_qty_left_from_rr(rr_no As String) As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim rs_id As Integer

        If pub_button_name = "EquipmentUseForHaulingToolStripMenuItem" Then
            rs_id = FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text
        ElseIf pub_button_name = "EditInfoToolStripMenuItem" Then
            rs_id = FDRLIST.lvl_drList.SelectedItems(0).SubItems(15).Text
        End If


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_withdrawal_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 12)
            newCMD.Parameters.AddWithValue("@rr_no", rr_no)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_qty_left_from_rr = newDR.Item("qty1").ToString
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Function



    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Try
            For i = 0 To 11
                MsgBox(dgv_dr_list.Rows(0).Cells(i).Value)
            Next
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub txtDriver_TextChanged(sender As Object, e As EventArgs) Handles txtDriver.TextChanged
        'Dim txtbox As TextBox = sender
        'Try
        '    If txtbox.Text = "" Then
        '        lboxUnit.Location = New System.Drawing.Point(txtbox.Location.X, txtbox.Location.Y + txtbox.Height)
        '        lboxUnit.Visible = False
        '    Else
        '        lboxUnit.Visible = True
        '        With lboxUnit
        '            .Location = New System.Drawing.Point(txtbox.Location.X, txtbox.Location.Y + txtbox.Height)
        '            .Visible = True
        '            .Items.Clear()
        '            .Width = txtbox.Width
        '        End With

        '        'get_dr_info(sender.name, txtbox.Text, txtbox)

        '        load_Operator(lboxUnit, txtDriver.Text)

        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub
    Sub load_Operator(lbox As ListBox, opname As String)
        lbox.Items.Clear()

        Dim sqlcon As New SQLcon
        Dim sqldr As SqlDataReader
        Dim cmd As SqlCommand
        Dim count As Integer

        Try
            sqlcon.connection1.Open()
            publicquery = "SELECT operator_name FROM dboperator WHERE operator_name LIKE '%" & opname & "%' ORDER BY operator_name ASC"
            cmd = New SqlCommand(publicquery, sqlcon.connection1)
            sqldr = cmd.ExecuteReader
            While sqldr.Read
                lbox.Items.Add(sqldr.Item("operator_name").ToString)
                count += 1
            End While
            sqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection1.Close()
            If count = 0 Then
                lboxUnit.Visible = False
            End If
        End Try
    End Sub

    Private Sub tab_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtDriver.PreviewKeyDown, txtPlateNo.PreviewKeyDown, txtcheckedby.PreviewKeyDown, txtreceivedby.PreviewKeyDown

        If e.KeyCode = Keys.Tab Then
            If lboxUnit.Visible = True Then
                lboxUnit.Visible = False
            End If
        End If

    End Sub

    Private Sub FDeliveryReceipt_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        cmbWsNo_PoNo.Enabled = True
        dgv_dr_list.Enabled = True
        Panel7.Enabled = True
        btnSave.Text = "Save"
        with_dr_status = Nothing
        txtprice.Text = 0

    End Sub

    Private Sub FDeliveryReceipt_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            btnSave.PerformClick()
        End If

        If e.KeyCode = Keys.F2 Then
            Try

                For Each ctr As Control In Panel2.Controls
                    ctr.Enabled = False
                Next

                For Each ctr As Control In Panel5.Controls

                    If ctr.Name = "Panel6" Then
                        ctr.Visible = True
                        ctr.Enabled = True
                        txtsplitqty.Text = dgv_dr_list.Rows(rowind).Cells(4).Value


                    Else
                        ctr.Enabled = False
                    End If
                Next

                txtsplitqty.SelectAll()
                txtsplitqty.Focus()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If


    End Sub


    Private Sub BW_get_aggregates_balances_DoWork(sender As Object, e As DoWorkEventArgs) Handles BW_get_aggregates_balances.DoWork
        If cStatus.status = Status.outWithoutRs Then
            e.Result = get_aggregates_remaining_balance(cStatus.wh_id)

        ElseIf cStatus.status = Status.othersWithoutRs Then
            e.Result = 0
        End If

    End Sub



    Private Sub dgv_dr_list_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgv_dr_list.CellFormatting
        If dgv_dr_list.CurrentCell IsNot Nothing Then
            If e.RowIndex = dgv_dr_list.CurrentCell.RowIndex And e.ColumnIndex = dgv_dr_list.CurrentCell.ColumnIndex Then
                e.CellStyle.SelectionBackColor = Color.Green
            Else
                e.CellStyle.SelectionBackColor = dgv_dr_list.DefaultCellStyle.SelectionBackColor
            End If
        End If
    End Sub

    Private Sub txtprice_TextChanged(sender As Object, e As EventArgs) Handles txtprice.TextChanged

    End Sub

    Private Sub txtRemarks_Leave(sender As Object, e As EventArgs) Handles txtRemarks.Leave
        Try

            If dgv_dr_list.Rows.Count = 0 Then
            Else
                dgv_dr_list.Focus()
                dgv_dr_list.CurrentCell = dgv_dr_list(0, 0)
                dgv_dr_list.BeginEdit(True)
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub cmbRRNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRRNo.SelectedIndexChanged

        'rr_list_left()
        bw_check_if_done = New BackgroundWorker
        bw_check_if_done.WorkerSupportsCancellation = True
        bw_check_if_done.RunWorkerAsync()

    End Sub
    Public Sub rr_list_left()
        Dim ws_po_rr_no As String = cmbRRNo.Text

        If dgv_dr_list.Rows.Count > 0 Then
            For i = 0 To 11
                copy_data_from_list(i) = dgv_dr_list.Rows(0).Cells(i).Value
            Next
        End If

        dgv_dr_list.Rows.Clear()

        dgv_dr_list.Rows.Add(copy_data_from_list)


        If get_qty_left_from_withdrawal(ws_po_rr_no) = 0 Then
            dgv_dr_list.Rows.Clear()
            Exit Sub
        End If

        If dgv_dr_list.Rows.Count > 0 Then
            dgv_dr_list.Rows(0).Cells("col_qty").Value = get_qty_left_from_withdrawal(ws_po_rr_no)

            If if_withdrawn(ws_po_rr_no) = False Then

                If ws_po_rr_no = "" Then
                Else
                    If cmbOptions.Text = "OTHERS" Or cmbOptions.Text = "IN" Then

                    Else
                        MessageBox.Show("The WS No. you've selected has not been withdrawn yet.." & vbCrLf &
                             "go-to withdrawl slip form to withdraw the items.", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        dgv_dr_list.Rows.Clear()
                    End If

                End If
                Exit Sub
            End If
            'set qty

        End If

        If btnSave.Text = "Update Info" Then
            dgv_dr_list.Rows.Clear()
        End If
    End Sub

    Public Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        rr_list_left()
    End Sub

    Private Sub bw_get_supplier_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bw_get_supplier.DoWork

        supplier.get_supplier()

    End Sub
    Private Sub bw_get_supplier_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw_get_supplier.RunWorkerCompleted
        supplier_stat = True
    End Sub

    Private Sub bw_get_operator_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw_get_operator.DoWork
        equip_operator.get_operator()

    End Sub

    Private Sub bw_get_operator_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw_get_operator.RunWorkerCompleted
        equip_operator_stat = True

    End Sub

    Private Sub bw_type_of_charges_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw_get_type_of_charges.DoWork
        'type_of_charges.get_type_of_charges()
        type_of_charges.get_charges_category()

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        stockcard.cListOfStockCard.Clear()

        Dim cWh_id As Integer = publicvariables.wh_id_for_dr
        Dim cDateFrom As DateTime = Date.Parse("2013-01-01")
        Dim cDateTo As DateTime = Date.Parse(Now)

        'NewStockCard._initialize2(cWh_id, cDateFrom, cDateTo)
        'GET THE DATA FROM AGGREGATES
        stockcard.aggregates_data(cWh_id, cDateFrom, cDateTo)
    End Sub



    Private Sub BackgroundWorker3_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker3.DoWork
        Dim cWh_id As Integer = publicvariables.wh_id_for_dr

        'NewStockCard3.get_prev_item_balance2(cWh_id)
        'GET PREVIOUS BALANCE
        stockcard1.wh_id = cWh_id
        stockcard1.prev_balance()

    End Sub
    Private Sub BackgroundWorker3_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker3.RunWorkerCompleted
        r2 = True
    End Sub

    Private Sub bw_type_of_charges_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw_get_type_of_charges.RunWorkerCompleted
        type_of_charges_stat = True
    End Sub



    Private Sub txtprice_KeyDown(sender As Object, e As KeyEventArgs) Handles txtprice.KeyDown
        If Not (e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 48 Or e.KeyValue = 49 Or e.KeyValue = 50 Or e.KeyValue = 51 Or e.KeyValue = 52 Or e.KeyValue = 53 Or e.KeyValue = 54 Or
       e.KeyValue = 55 Or e.KeyValue = 56 Or e.KeyValue = 57 Or e.KeyValue = 96 Or e.KeyValue = 97 Or e.KeyValue = 98 Or e.KeyValue = 99 Or
       e.KeyCode = Keys.OemPeriod Or
      e.KeyValue = 100 Or e.KeyValue = 101 Or e.KeyValue = 102 Or e.KeyValue = 103 Or e.KeyValue = 104 Or e.KeyValue = 105 Or e.KeyValue = 37 Or e.KeyValue = 110 Or e.KeyValue = 39 Or Keys.C AndAlso e.Modifiers = Keys.Control) Then

            e.SuppressKeyPress() = True
        End If
    End Sub


    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        r1 = True
    End Sub


    Private Sub bw_check_if_done_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw_check_if_done.DoWork
        'CHECK IF DONE NA TANAN PROCESS
        check_if_done_process()
    End Sub
    Private Sub check_if_done_process()
        While True
            If r1 = True And r2 = True And supplier_stat = True And equip_operator_stat = True And type_of_charges_stat = True Then
                Exit While
            End If
        End While
    End Sub

    Private Sub BW_initializeData_DoWork(sender As Object, e As DoWorkEventArgs) Handles BW_initializeData.DoWork

#Region "==> INITIALIZE DATA HERE"

#Region "=> PLATENO"
        'LOAD PLATENO
        Dim getEquipment As New Model._Mod_Equipment

        getEquipment.parameter("@n", 2)

        cListOfEquipments = getEquipment.LISTOFEQUIPMENT

        Dim listOfEquipments As New List(Of String)
        For Each equip In cListOfEquipments
            listOfEquipments.Add(equip.PlateNo)
        Next

#End Region

#Region "=> OPERATOR/DRIVER"
        'LOAD OPERATOR
        Dim getOperator As New Model._Mod_Driver

        getOperator.parameter("@n", 1)

        cListOfOperators = getOperator.LISTOFDRIVER

        Dim listOfOperators As New List(Of String)
        For Each driver In cListOfOperators
            listOfOperators.Add(driver.driver_name)
        Next

        'MsgBox("OPERATOR: " & vbCrLf & cListOfOperators.Count)
#End Region

#Region "=> SUPPLIER"
        'LOAD SUPPLIER
        Dim getSupplier As New Model._Mod_Supplier

        getSupplier.parameter("@n", 3)

        cListOfSuppliers = getSupplier.LISTOFSUPPLIER

        Dim listOfSuppliers As New List(Of String)
        'cmbSupplier.Items.Clear()

        For Each sup In cListOfSuppliers
            listOfSuppliers.Add(sup.supplier_name)
            'cmbSupplier.Items.Add(sup.supplier_name)
        Next

        'MsgBox("SUPPLIER: " & vbCrLf & listOfSuppliers.Count)
#End Region

#Region "=> ADFIL EMPLOYEES"
        'Load adfil employees
        Dim getAdfilEmployee As New Model._Mod_Adfil_Employee
        getAdfilEmployee.parameter("@n", 1)

        cListOfAdfilEmployee = getAdfilEmployee.LISTOFADFILEMPLOYEE

        Dim listOfAdfilEmployee As New List(Of String)

        For Each emp In cListOfAdfilEmployee
            listOfAdfilEmployee.Add(emp.employee)
        Next

#End Region

#Region "REQUESTOR"
        Dim getRequestor As New Model._Mod_Charges
        getRequestor.parameter("@n", 3)

        cListOfRequestorCharges = getRequestor.LISTOFCHARGES

        Dim listOfRequestorCharges As New List(Of String)

        Dim distinct_listOfRequestorCharges = From a In cListOfRequestorCharges
                                              Select a Group By a.category Into Group
                                              Select Group.First()

        For Each req In distinct_listOfRequestorCharges
            listOfRequestorCharges.Add(req.category)
        Next


#End Region

#End Region

#Region "==> INITIALIZE UI"
        _initialize_ui(listOfEquipments, listOfOperators, listOfSuppliers, listOfAdfilEmployee, listOfRequestorCharges)
#End Region

    End Sub


    Private Sub BW_loadingEffects_DoWork(sender As Object, e As DoWorkEventArgs) Handles BW_loadingEffects.DoWork
        'If InvokeRequired Then
        '    Invoke(Sub()
        '               'Floading.Show()
        '             
        '           End Sub)
        'Else
        '    'Floading.Show()
        'End If

        customLoadingPanel(True)
    End Sub

    Private Sub bw_check_if_done_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw_check_if_done.RunWorkerCompleted

        Panel8.Visible = False
        Panel7.Enabled = True
        btnSave.Enabled = True

        bw_display_balance_out = New BackgroundWorker
        bw_display_balance_out.WorkerSupportsCancellation = True
        bw_display_balance_out.RunWorkerAsync()

    End Sub



    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Dispose()

    End Sub

    Private Sub bw_display_balance_in_DoWork(sender As Object, e As DoWorkEventArgs)

    End Sub

    Private Sub bw_display_balance_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw_display_balance_out.DoWork

        'ANG LAST BALANCE SA STOCKCARD NGA NABILIN
        If myInOut = "OUT" Then
            stockcard.get_balances()
        Else
            'pass
        End If

    End Sub

    Private Function current_balance() As Double
        If with_dr_status = "in without rs" Or with_dr_status = "out without rs" Then
            current_balance = (CDbl(stockcard1.my_prev_balance) + CDbl(stockcard.myBalanceNow)).ToString("N0")

        ElseIf with_dr_status = "in with rs" Then
            Dim rr_data = rr_balance.get_rr_data(myRRNo)
            Dim ss As Double

            For Each row In rr_data
                ss += row.dr_qty
            Next

            current_balance = myRRQty - ss

        End If

    End Function

    Private Sub bw_display_balance_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw_display_balance_out.RunWorkerCompleted
        'ADD ROWS
        Dim a(10) As String

        a(1) = ""
        a(2) = ""
        a(3) = ""
        a(4) = current_balance() 'balance - qty_from_requestor
        a(5) = publicvariables.pub_items_for_dr
        a(6) = rs_id
        a(7) = 0
        a(8) = publicvariables.wh_id_for_dr

        dgv_dr_list.Rows.Clear()
        dgv_dr_list.Rows.Add(a)

        If myInOut = "OUT" Then
            'dgv_dr_list.Rows(0).Cells("col_qty").Value = 0
            dgv_dr_list.Rows(0).Cells("col_qty").ReadOnly = True
        ElseIf myInOut = "IN" Then
            dgv_dr_list.Rows(0).Cells("col_qty").Value = 0
            dgv_dr_list.Rows(0).Cells("col_qty").ReadOnly = False
        End If

        'ADD SUPPLIER TO COMBOBOX
        cmbSupplier.Items.Clear()
        For Each row In supplier.cListOfSupplier
            cmbSupplier.Items.Add(row.supplier_name)
        Next

        'ADD TYPE OF CHARGES
        cmbTypeofCharge.Items.Clear()
        'For Each row In type_of_charges.cListOfTypeOfCharges
        '    cmbTypeofCharge.Items.Add(row.type_of_charges)
        'Next
        For Each row In type_of_charges.cListOfChargesCategory
            cmbTypeofCharge.Items.Add(row.charges_cat)
        Next

        If myInOut = "OUT" Then
            bw_get_operator.CancelAsync()
            bw_get_supplier.CancelAsync()
            bw_get_type_of_charges.CancelAsync()
            BackgroundWorker1.CancelAsync()
            BackgroundWorker3.CancelAsync()
            bw_check_if_done.CancelAsync()
            bw_display_balance_out.CancelAsync()

        ElseIf myInOut = "IN" Then
            bw_get_operator.CancelAsync()
            bw_get_supplier.CancelAsync()
            bw_get_type_of_charges.CancelAsync()

            bw_check_if_done.CancelAsync()
            bw_display_balance_out.CancelAsync()
        End If

    End Sub

    Private Sub FDeliveryReceipt_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Panel8.Parent = Me
        Panel8.BringToFront()
        Panel8.Location = New Point(Me.Left, Me.Top)

        Panel8.Width = Me.Width
        Panel8.Height = Me.Height
    End Sub

    Sub SetTimeout(action As Action, delay As Integer)
        Dim timer As New System.Threading.Timer(Sub(state) action.Invoke(), Nothing, delay, Timeout.Infinite)
    End Sub

    Private Sub BW_get_aggregates_balances_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BW_get_aggregates_balances.RunWorkerCompleted
        Dim result As Double = CType(e.Result, Double)
        addRow(result)
    End Sub
    Private Sub addRow(result As Double)

        'add new row to datagridview 
        Dim a(20) As String

        a(0) = False
        a(4) = result
        a(5) = cStatus.item_desc
        a(8) = cStatus.wh_id

        If InvokeRequired Then
            Invoke(Sub()
                       dgv_dr_list.Rows.Add(a)
                   End Sub)
        Else
            dgv_dr_list.Rows.Add(a)
        End If

        If Floading IsNot Nothing AndAlso Floading.Visible Then
            ' The form is visible
            Floading.Close()
        End If

        If cStatus.status = Status.othersWithoutRs Then
            dgv_dr_list.Rows(0).Cells("col_qty").ReadOnly = False
        Else
            dgv_dr_list.Rows(0).Cells("col_qty").ReadOnly = True
        End If

        customLoadingPanel(False)

    End Sub

    Private Sub customLoadingPanel(onOff As Boolean)
        If loadingPanel.InvokeRequired Then
            loadingPanel.Invoke(Sub()
                                    loadingPanel.Visible = onOff
                                End Sub)
        Else
            loadingPanel.Visible = onOff
        End If
    End Sub

    Private Sub BW_initializeData_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BW_initializeData.RunWorkerCompleted

        If cStatus.status = Status.outWithoutRs Or cStatus.status = Status.inWithoutRs Then

        Else
            If Floading IsNot Nothing AndAlso Floading.Visible Then
                ' The form is visible
                Floading.Close()
            End If

            customLoadingPanel(False)
        End If

    End Sub

End Class

Public Class datagridviews

    Enum col_name

        dr_no = 1
        source = 2
        category = 3

    End Enum

    Public Function no_of_rows_selected(dgv As DataGridView, cellname As String) As Integer

        For i = 0 To dgv.Rows.Count - 1
            If dgv.Rows(i).Cells(cellname).Value = "True" Then
                no_of_rows_selected += 1
            End If
        Next
    End Function

    Public Function blank_cell(dgv As DataGridView, cellname As String, cellname2 As String) As Integer
        For Each row As DataGridViewRow In dgv.Rows

            If row.Cells(cellname2).Value = "True" Then
                If row.Cells(cellname).Value = "" Then
                    blank_cell += 1
                End If
            End If

        Next
    End Function

End Class
