Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.Drawing
Imports System.Linq
Imports System.ComponentModel
Imports System.Windows.Interop
Imports SUPPLY.FRequistionForm
Imports OfficeOpenXml.ExcelErrorValue
Imports Microsoft.VisualBasic.ApplicationServices
Imports CrystalDecisions.Windows.Forms
Imports System.Security.Cryptography

Public Class FRequistionForm
    'NEW CLASS 2023
    Public cAggregates As New class_exclusive_aggregates

    Public publicquery As String
    Dim SQLcon As New SQLcon
    Dim sqldr As SqlDataReader
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim req_id As Integer = 0
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Dim status As String
    Dim chargename As String
    Dim dr_qty As Double
    Public clear_data As String = "yes"
    Public for_print_po As Boolean = False

    Dim get_charges_category As String
    Dim get_charges_name As String

    Public charges_wh_id As Integer
    Public sep_qty_volume As Boolean

    Public contract_id As Integer
    Dim counter1 As Integer
    Dim total_ws_qty As Decimal
    Dim total_ws_qty1 As Decimal
    Dim total_dr_qty_out As Decimal
    Dim total_dr_qty_in As Decimal
    Dim total_dr_qty_others As Decimal
    Public total_rs_qty As Decimal
    Public main_rs_qty, main_rs_qty1 As Decimal
    Public main_finesand, main_g1, main_34, main_mixed_boulders, main_waste, main_item_104, main_screen_sand As Integer
    Public none As Boolean
    Private thread1, thread2, thread3, thread4 As System.Threading.Thread
    Public thread5 As System.Threading.Thread
    Public thread As System.Threading.Thread
    Dim timer_n As Integer

    Dim selectedindex As Integer
    Public rs_id_count As Integer

    Dim dtp_from, dtp_to As DateTime
    Dim dr_items As String
    Dim abortsearching As Boolean = False

    Public total_finesand, total_g1, total_three_fourth, total_screensand, total_three_eight As Decimal
    Public project1 As String

    Dim ST_Data As New Class_RS_Search.search_wh_data
    Dim th_search As Threading.Thread
    Dim rs_nn As Integer

    Dim list_item_desc As New List(Of List(Of String))
    Dim crs_data As New Class_Search_Charges.search_charges_data

    Dim listview2_item_name As String
    Dim listview2_item_desc As String
    Dim listview2_proper_name As String


    Public all_rr_po_det_id As String

    Public withdrawal_stat1 As String

    Private customMsg As New customMessageBox


    Private newAuth As New authType
    Dim cBgWorkerChecker As Timer
    Private whItemsModel, whProperNames, partiallyWithdrawnModel, withdrawnModel, serialNoViewModel As New ModelNew.Model
    Private cListOfPartiallyWithdrawn As New List(Of PropsFields.partiallyWithdrawn_props_fields)
    Private cListOfWsReleasedItem As New List(Of PropsFields.withdrawn_props_fields)
    Private cListOfListviewItem As New List(Of ListViewItem)
    Dim cListOfDrItemId As New List(Of Integer)

    Public loadStat As Integer

    'variables
    Dim bR1, br2, br3 As Boolean
    Dim cRS_No As String
    Dim cRemaining_Balance As Double
    Dim cTotal_Dr, cTotal_Dr2 As Double
    Dim cTotal_RR As Double
    Dim cToBeDisplay As Boolean
    Dim cOpenCloseQty As Double
    Dim cRsId As Integer

    Private cSomeComponents As New ColumnValuesObj
    Private rearrangeLvl As New ListTabIndex
    Public Class SearchByItemEnum
        Public Property item_name As String = "Item Name"
        Public Property item_desc As String = "Item Desc."
        Public Property item_name_desc As String = "Item Name and Item Desc."
        Public Property proper_naming As String = "Proper Naming"
        Public Property item_desc_for_rs As String = "Item Desc. for RS"
    End Class
    Structure sMainQty

        Dim rs_no As String
        Dim main_qty As Double
        Dim status As Integer

    End Structure

    Public Enum LoadingStatus

        all = 0
        partiallyWithdrawn

    End Enum

    Private DRModel As New ModelDR
    Public cListOfMainQty As New List(Of sMainQty)
    Public cSearchByItemE As New SearchByItemEnum
    Private CDR As New FCreateDeliveryReceipt

    Public ReadOnly Property GetDRModel As ModelDR
        Get
            Return DRModel
        End Get
    End Property

    Public ReadOnly Property GetCDR As FCreateDeliveryReceipt
        Get
            Return CDR
        End Get
    End Property

    Private Sub registerRow()

        With rearrangeLvl
            .addColumns(col_rs_id)
            .addColumns(col_rs_no)
            .addColumns(col_dr_no)
            .addColumns(col_ws_rr_no)
            .addColumns(col_rs_date)
            .addColumns(col_date_needed)
            .addColumns(col_jo_no)
            .addColumns(col_rs_item)
            .addColumns(col_cons_item)
            .addColumns(col_cons_item_desc)
            .addColumns(col_qty_takeoff_desc)
            .addColumns(col_rs_qty)
            .addColumns(col_po_ws_qty_released)
            .addColumns(col_rr_ws_qty_received)
            .addColumns(col_dr_qty_released)
            .addColumns(col_price)
            .addColumns(col_unit)
            .addColumns(col_purpose)
            .addColumns(col_type_of_request)
            .addColumns(col_inout)
            .addColumns(col_po_cv_status)
            .addColumns(col_ws_status)
            .addColumns(col_rr_status)
            .addColumns(col_charges)
            .addColumns(col_rs_location)
            .addColumns(col_wh_id)
            .addColumns(col_date_log)
            .addColumns(col_type_of_charges)
            .addColumns(col_type_of_purchasing)
            .addColumns(col_requested_by)
            .addColumns(col_remarks)
            .addColumns(col_remarks_for_emd)
            .addColumns(col_quarry_location)
            .addColumns(col_bsNo)
            .addColumns(col_main_sub)
            .addColumns(col_type_of_delivery)
            .addColumns(col_rs_qty_left)
            .addColumns(col_wh_qy_area)
            .addColumns(col_tem_col_item_name)
            .addColumns(col_temp_col_project)
            .addColumns(col_dr_option)
            .addColumns(col_updateBy)
            .addColumns(col_date_log_updated)
            .addColumns(col_item_checked_log)
            .addColumns(col_qto_id)
            .addColumns(col_po_det_id_rr_item_id)
            .addColumns(col_qto_id2)
            .addColumns(col_dr_items_id)
            .addColumns(col_wh_pn_id)
            .addColumns(col_ws_item_id)
            .addColumns(col_user)
        End With

    End Sub
    Private Sub FRequistionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        registerRow()

        for_print_po = False
        FDRLIST.load_requestor(cmbProject, 14)
        FDRLIST.load_requestor(cmbProject1, 14)

        Label15.Parent = pboxHeader
        Panel4.Parent = pboxHeader

        'btnExit.Parent = pboxHeader
        'btnExit.Location = New Point(pboxHeader.Width - 400, 10)
        Panel_date_duration.BringToFront()
        'Panel_date_duration.Location = New Point(480, 650)

        ListJobOrderNo.Location = New Point(1000, 1000)
        cmbSearchByCategory.Text = "Search by RS.No."

        col_rs_id.DisplayIndex = 0
        col_rs_no.DisplayIndex = 1
        col_dr_no.DisplayIndex = 2
        col_ws_rr_no.DisplayIndex = 3
        col_rs_date.DisplayIndex = 4
        col_date_needed.DisplayIndex = 5
        col_jo_no.DisplayIndex = 6
        col_rs_item.DisplayIndex = 7
        col_cons_item.DisplayIndex = 8
        col_cons_item_desc.DisplayIndex = 9
        col_qty_takeoff_desc.DisplayIndex = 10
        col_rs_qty.DisplayIndex = 11
        col_po_ws_qty_released.DisplayIndex = 12
        col_rr_ws_qty_received.DisplayIndex = 13
        col_dr_qty_released.DisplayIndex = 14
        col_price.DisplayIndex = 15
        col_unit.DisplayIndex = 16
        col_purpose.DisplayIndex = 17
        col_type_of_request.DisplayIndex = 18
        col_inout.DisplayIndex = 19
        col_po_cv_status.DisplayIndex = 20
        col_rr_status.DisplayIndex = 21
        col_ws_status.DisplayIndex = 22
        col_charges.DisplayIndex = 23
        col_rs_location.DisplayIndex = 24
        col_wh_id.DisplayIndex = 25
        col_date_log.DisplayIndex = 26
        col_type_of_charges.DisplayIndex = 27
        col_type_of_purchasing.DisplayIndex = 28
        col_remarks.DisplayIndex = 29
        col_quarry_location.DisplayIndex = 30
        col_user.DisplayIndex = 31
        col_ws_item_id.DisplayIndex = 32
        col_bsNo.DisplayIndex = 33
        col_main_sub.DisplayIndex = 34
        col_requested_by.DisplayIndex = 35
        col_type_of_delivery.DisplayIndex = 36
        col_qty_takeoff_desc.DisplayIndex = 37
        col_wh_qy_area.DisplayIndex = 38


        Button2.Location = New Point(100000, 10000)
        Button4.Location = New Point(100000, 10000)
        Button5.Location = New Point(100000, 10000)
        Button7.Location = New Point(100000, 10000)
        Button8.Location = New Point(100000, 10000)
        cmbProject.Location = New Point(100000, 10000)
        ListBox1.Location = New Point(100000, 10000)

        If publicvariables.auth = "Admin" Then
            Button14.Visible = True
        Else
            Button14.Visible = False
        End If

        'load_rs_3(1)
        loadWhItems()

    End Sub

    Public Sub loadWhItems()

        whItemsModel.clearParameter()
        whProperNames.clearParameter()
        partiallyWithdrawnModel.clearParameter()
        withdrawnModel.clearParameter()
        serialNoViewModel.clearParameter()

        loadingPanel.Visible = True

        Dim values As New Dictionary(Of String, String)

        If loadStat = LoadingStatus.all Then
            _init_._initializing(cCol.forWhItems,
                    values,
                    whItemsModel,
                    WhItemsBgWorker)

            _init_._initializing(cCol.forWhItem_ProperNames,
                          values,
                          whProperNames,
                          WhItemsBgWorker)

            _init_._initializing(cCol.forPartiallyWithdrawn,
                                 values,
                                 partiallyWithdrawnModel,
                                 WhItemsBgWorker)

            _init_._initializing(cCol.forWithdrawn,
                                 values,
                                 withdrawnModel,
                                 WhItemsBgWorker)

            _initializing(cCol.forTireSerialNoView,
                          values,
                          serialNoViewModel,
                          WhItemsBgWorker)

        ElseIf loadStat = LoadingStatus.partiallyWithdrawn Then
            _init_._initializing(cCol.forWithdrawn,
                                 values,
                                 withdrawnModel,
                                 WhItemsBgWorker)

        End If

        cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, WhItemsBgWorker)

    End Sub

    Private Sub SuccessfullyDone()
        If loadStat = LoadingStatus.all Then
            Results.cResult = TryCast(whItemsModel.cData, List(Of PropsFields.whItems_props_fields))
            Results.cListOfProperNaming = TryCast(whProperNames.cData, List(Of PropsFields.whItems_properName_fields))
            cListOfWsReleasedItem = TryCast(withdrawnModel.cData, List(Of PropsFields.withdrawn_props_fields))
            cListOfPartiallyWithdrawn = TryCast(partiallyWithdrawnModel.cData, List(Of PropsFields.partiallyWithdrawn_props_fields))
            Results.rListOfTireSerialNoView = TryCast(serialNoViewModel.cData, List(Of PropsFields.tireSerialView_props_fields))

        ElseIf loadStat = LoadingStatus.partiallyWithdrawn Then
            cListOfWsReleasedItem = TryCast(withdrawnModel.cData, List(Of PropsFields.withdrawn_props_fields))
        End If

        loadingPanel.Visible = False

    End Sub
    Private Class typeOfPurchasingEnum
        Public Shared ReadOnly Property purchasedOrder = "PURCHASE ORDER"
        Public Shared ReadOnly Property withdrawal = "WITHDRAWAL"
        Public Shared ReadOnly Property cashWithRR = "CASH WITH RR"
    End Class
    Public Sub load_rs_2()
        lvlrequisitionlist.Items.Clear()

        Dim newsq As New SQLcon
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand

        Dim row As Integer

        Try

            newsq.connection.Open()

            newcmd = New SqlCommand("proc_requisition_slip", newsq.connection)
            newcmd.Parameters.Clear()
            newcmd.CommandType = CommandType.StoredProcedure

            If cmbSearchByCategory.Text = "Search by RS.No." Then
                'newcmd.Parameters.AddWithValue("@n", 1)
                newcmd.Parameters.AddWithValue("@n", 8)

            ElseIf cmbSearchByCategory.Text = "Search by JO.No." Then
                newcmd.Parameters.AddWithValue("@n", 2)

            ElseIf cmbSearchByCategory.Text = "Search by item from warehouse" Then
                newcmd.Parameters.AddWithValue("@n", 3)

            ElseIf cmbSearchByCategory.Text = "Search by item from others" Then
                newcmd.Parameters.AddWithValue("@n", 6)

            ElseIf cmbSearchByCategory.Text = "Search by Date Request" Then
                newcmd.Parameters.AddWithValue("@n", 4)
                newcmd.Parameters.AddWithValue("@date_req", Date.Parse(dtpsearchdatereq.Text))

            ElseIf cmbSearchByCategory.Text = "Search by Cash Rs.No." Then
                newcmd.Parameters.AddWithValue("@n", 5)
                newcmd.Parameters.AddWithValue("@date_req", Date.Parse(dtpsearchdatereq.Text))

            ElseIf cmbSearchByCategory.Text = "Filter by month of Date Request" Then
                newcmd.Parameters.AddWithValue("@n", 7)
                newcmd.Parameters.AddWithValue("@date_from", Date.Parse(dtpfrom.Text))
                newcmd.Parameters.AddWithValue("@date_to", Date.Parse(dtpto.Text))
            End If

            newcmd.Parameters.AddWithValue("@searchby", txtSearch.Text)

            newdr = newcmd.ExecuteReader
            If newdr.HasRows Then
                While newdr.Read
                    Dim a(20) As String

                    a(0) = newdr.Item("rs_id").ToString
                    a(1) = newdr.Item("rs_no").ToString
                    a(2) = Format(Date.Parse(newdr.Item("date_req").ToString), "MM/dd/yyyy")
                    a(3) = newdr.Item("job_order_no").ToString

                    If newdr.Item("typeRequest").ToString = "BORROWER" Then
                        If newdr.Item("process").ToString = "PERSONAL" Then
                            a(4) = GET_ITEM_DESC_FROM_PERSONAL_TOOLS(newdr.Item("wh_id").ToString)
                        Else
                            a(4) = GET_ITEM_DESC_FROM_OTHERS(newdr.Item("wh_id").ToString)
                        End If


                    Else
                        If newdr.Item("IN_OUT").ToString = "FACILITIES" Or newdr.Item("IN_OUT").ToString = "TOOLS" Then
                            a(4) = GET_ITEM_DESC_FROM_OTHERS(newdr.Item("wh_id").ToString)
                        Else
                            a(4) = GET_ITEM_DESC(newdr.Item("wh_id").ToString)
                        End If

                    End If

                    If newdr.Item("wh_id").ToString = 0 Then
                        a(4) = newdr.Item("item_desc").ToString
                    End If

                    'If newdr.Item("wh_id").ToString = 0 Then
                    '    a(4) = newdr.Item("item_desc").ToString

                    'ElseIf newdr.Item("wh_id").ToString <> 0 And newdr.Item("typeRequest").ToString <> "OTHERS" Then
                    '    a(4) = GET_ITEM_DESC(newdr.Item("wh_id").ToString)

                    'ElseIf newdr.Item("wh_id").ToString <> 0 And newdr.Item("typeRequest").ToString = "OTHERS" Then
                    '    a(4) = GET_ITEM_DESC_FROM_OTHERS(newdr.Item("wh_id").ToString)

                    'End If

                    'If newdr.Item("wh_id").ToString <> 0 And newdr.Item("typeRequest").ToString = "OTHERS" And newdr.Item("process").ToString = "PERSONAL" Then
                    '    a(4) = GET_ITEM_DESC_FROM_PERSONAL_TOOLS(newdr.Item("wh_id").ToString)

                    'End If

                    'If newdr.Item("wh_id").ToString <> 0 And newdr.Item("typeRequest").ToString = "OTHERS" And newdr.Item("process").ToString = "PERSONAL" And newdr.Item("IN_OUT").ToString = "OUT" Then
                    '    a(4) = GET_ITEM_DESC(newdr.Item("wh_id").ToString)
                    'End If

                    a(5) = newdr.Item("qty").ToString
                    a(6) = newdr.Item("unit").ToString
                    a(7) = Format(Date.Parse(newdr.Item("date_needed").ToString), "MM/dd/yyyy")
                    a(8) = newdr.Item("typeRequest").ToString
                    a(9) = newdr.Item("IN_OUT").ToString

                    If newdr.Item("trans").ToString = "cancel" Then
                        a(10) = "CANCELLED"
                        a(11) = "CANCELLED"
                        a(12) = "CANCELLED"

                    Else
                        If check_if_exist("dbpurchase_order", "rs_no", newdr.Item("rs_no").ToString, 0) > 0 Then
                            a(10) = "PO RELEASED"
                        Else
                            a(10) = "PENDING"
                        End If

                        If newdr.Item("IN_OUT").ToString = "IN" Then
                            a(12) = "N/A"
                            a(11) = "PENDING"
                        ElseIf newdr.Item("IN_OUT").ToString = "OUT" Then
                            a(12) = "PENDING"
                            a(11) = "N/A"
                            a(10) = "N/A"

                        ElseIf newdr.Item("IN_OUT").ToString = "FACILITIES" Or newdr.Item("IN_OUT").ToString = "TOOLS" Then
                            a(12) = "N/A"
                            a(11) = "PENDING"

                        ElseIf newdr.Item("typeRequest").ToString = "EQUIPMENT" And newdr.Item("IN_OUT").ToString = "OTHERS" Then
                            a(12) = "N/A"
                            a(11) = "PENDING"

                        ElseIf newdr.Item("typeRequest").ToString = "PROJECT" And newdr.Item("IN_OUT").ToString = "OTHERS" Then
                            a(12) = "N/A"
                            a(11) = "PENDING"

                        ElseIf newdr.Item("typeRequest").ToString = "SUPPLY" And newdr.Item("IN_OUT").ToString = "OTHERS" Then
                            a(12) = "N/A"
                            a(11) = "PENDING"

                        End If

                        If newdr.Item("IN_OUT").ToString = "OTHERS" And newdr.Item("process").ToString = "PERSONAL" Then
                            a(12) = "N/A"
                            a(11) = "PENDING"
                        End If

                        If check_if_exist("dbreceiving_info", "rs_no", newdr.Item("rs_no").ToString, 0) > 0 Then
                            a(10) = "PURCHASED"
                            a(11) = "RECEIVED"
                        Else

                        End If

                        If check_if_exist("dbwithdrawal_info", "rs_no", newdr.Item("rs_no").ToString, 0) > 0 Then
                            a(12) = "WITHDRAWN"
                            a(10) = "N/A"
                            a(11) = "N/A"
                        Else

                        End If

                        If newdr.Item("IN_OUT").ToString = "OTHERS" Then
                            If newdr.Item("type_of_purchasing").ToString = "CASH" Then
                                a(10) = "N/A"
                                a(11) = "PENDING"
                                a(12) = "N/A"
                            ElseIf newdr.Item("type_of_purchasing").ToString = "PURCHASE ORDER" Then
                                a(10) = "N/A"
                                a(11) = "PENDING"
                                a(12) = "N/A"
                            End If
                        End If
                        'CLOSE NI YOT! HAHAHA ---------------------------------
                    End If


                    Dim typeOfRequest As String = newdr.Item("typeRequest").ToString
                    Dim INOUT As String = newdr.Item("IN_OUT").ToString
                    Dim process As String = newdr.Item("process").ToString
                    Dim charge_for_cash As String = newdr.Item("type_of_purchasing").ToString
                    charge_to_id = newdr.Item("charge_to").ToString

                    '*=========================================
                    '* 4 - charge to warehouse
                    '* 3 - charge to department,admin and etc.
                    '* 1 - charge to equipment
                    '* 2 - charge to project
                    '*=========================================

                    Select Case process
                        Case "EQUIPMENT"
                            a(13) = GET_equip_desc_AND_proj_desc(charge_to_id, 1)
                        Case "PROJECT"
                            a(13) = GET_equip_desc_AND_proj_desc(charge_to_id, 2)
                        Case "WAREHOUSE"
                            a(13) = GET_equip_desc_AND_proj_desc(charge_to_id, 4)
                        Case "PERSONAL"
                            a(13) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                        Case "CASH"
                            a(13) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                        Case "ADFIL"
                            a(13) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)

                    End Select



                    'If typeOfRequest = "SUPPLY" And INOUT = "IN" Then
                    '    charge_to_id = newdr.Item("charge_to").ToString
                    '    a(13) = GET_equip_desc_AND_proj_desc(charge_to_id, 4)

                    'ElseIf typeOfRequest = "SUPPLY" And INOUT = "OUT" Then
                    '    charge_to_id = newdr.Item("charge_to").ToString
                    '    a(13) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)

                    'ElseIf typeOfRequest = "EQUIPMENT" And INOUT = "OUT" Then
                    '    charge_to_id = newdr.Item("charge_to").ToString
                    '    a(13) = GET_equip_desc_AND_proj_desc(charge_to_id, 1)

                    'ElseIf typeOfRequest = "EQUIPMENT" And INOUT = "OTHERS" Then
                    '    charge_to_id = newdr.Item("charge_to").ToString
                    '    a(13) = where_to_charge1(process, charge_for_cash)

                    'ElseIf typeOfRequest = "PROJECT" And INOUT = "OUT" Then
                    '    charge_to_id = newdr.Item("charge_to").ToString
                    '    a(13) = where_to_charge1(process, charge_for_cash)

                    'ElseIf typeOfRequest = "PROJECT" And INOUT = "OTHERS" Then
                    '    charge_to_id = newdr.Item("charge_to").ToString
                    '    a(13) = where_to_charge1(process, charge_for_cash)

                    'ElseIf typeOfRequest = "OTHERS" And INOUT = "TOOLS" Then
                    '    charge_to_id = newdr.Item("charge_to").ToString
                    '    a(13) = where_to_charge1(process, charge_for_cash)

                    'ElseIf typeOfRequest = "OTHERS" And INOUT = "FACILITIES" Then
                    '    charge_to_id = newdr.Item("charge_to").ToString
                    '    a(13) = where_to_charge1(process, charge_for_cash)

                    'ElseIf typeOfRequest = "OTHERS" And INOUT = "OTHERS" Then
                    '    charge_to_id = newdr.Item("charge_to").ToString
                    '    a(13) = where_to_charge1(process, charge_for_cash)

                    'End If

                    a(14) = newdr.Item("location").ToString
                    a(15) = newdr.Item("wh_id").ToString
                    a(16) = newdr.Item("date_log").ToString
                    a(17) = newdr.Item("process").ToString
                    a(18) = newdr.Item("type_of_purchasing").ToString

                    Dim lvl As New ListViewItem(a)
                    lvlrequisitionlist.Items.Add(lvl)

                    row += 1

                    If newdr.Item("trans").ToString = "cancel" Then
                        lvlrequisitionlist.Items(row - 1).BackColor = Color.Red
                    End If

                End While
            Else
                MessageBox.Show("Data doesn't exist...", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsq.connection.Close()
        End Try
    End Sub
    Public Function get_all_qty_for_this_rs(rs_no As String)


        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT sum(qty) as rs_qty FROM dbrequisition_slip WHERE rs_no = '" & rs_no & "' AND original_volume = '" & "B" & "'"
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            Dim a(10) As String

            While newDR.Read
                get_all_qty_for_this_rs = CDbl(newDR.Item("rs_qty").ToString)
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Public Sub load_rs_66(n As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        lvlrequisitionlist.Items.Clear()
        Dim counter As Integer

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_requisition_slip", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 21)
            newCMD.Parameters.AddWithValue("@rs_no", txtSearch.Text)

            newDR = newCMD.ExecuteReader

            Dim a(40) As String

            While newDR.Read

                a(4) = newDR.Item("ITEM_DESC").ToString
                Dim lvl As New ListViewItem(a)
                lvlrequisitionlist.Items.Add(lvl)

                '                If newDR.Item("division").ToString = "WAREHOUSING AND SUPPLY" Then
                '                    GoTo proceedhere
                '                End If

                '                a(0) = newDR.Item("rs_id").ToString
                '                a(1) = newDR.Item("rs_no").ToString

                '                If newDR.Item("date_request").ToString = "" Then
                '                Else
                '                    a(2) = Format(Date.Parse(newDR.Item("date_request").ToString), "MM/dd/yyyy")
                '                End If

                '                a(3) = newDR.Item("job_order_no").ToString
                '                a(4) = newDR.Item("ITEM_DESC").ToString
                '                a(5) = newDR.Item("rs_qty").ToString
                '                a(6) = newDR.Item("unit").ToString
                '                a(7) = IIf(Format(Date.Parse(newDR.Item("date_needed").ToString), "MM/dd/yyyy") = "01/01/1900", "", Format(Date.Parse(newDR.Item("date_needed").ToString), "MM/dd/yyyy"))
                '                a(8) = newDR.Item("type_of_request").ToString
                '                a(9) = newDR.Item("IN_OUT").ToString
                '                a(10) = newDR.Item("po_status").ToString
                '                a(11) = ""
                '                a(12) = newDR.Item("ws_status").ToString
                '                a(13) = newDR.Item("charges").ToString
                '                a(14) = newDR.Item("location").ToString
                '                a(15) = newDR.Item("wh_id").ToString
                '                a(16) = newDR.Item("date_log").ToString
                '                a(17) = newDR.Item("type_of_charges").ToString
                '                a(18) = newDR.Item("type_of_purchasing").ToString
                '                a(19) = newDR.Item("remarks").ToString
                '                a(20) = ""
                '                a(21) = newDR.Item("dr_no").ToString

                '                If newDR.Item("mother_rs").ToString = "A" And newDR.Item("IN_OUT").ToString = "IN" Then
                '                    a(22) = newDR.Item("M_po_ws_released").ToString
                '                Else
                '                    a(22) = newDR.Item("po_ws_qty_released").ToString
                '                End If

                '                If newDR.Item("mother_rs").ToString = "A" And newDR.Item("IN_OUT").ToString = "IN" Then
                '                    a(23) = newDR.Item("M_rr_ws_received").ToString
                '                Else
                '                    a(23) = newDR.Item("rr_ws_qty_received").ToString
                '                End If

                '                a(24) = newDR.Item("users").ToString
                '                a(25) = newDR.Item("ws_id_dr_id").ToString
                '                a(26) = ""
                '                a(27) = ""
                '                a(28) = newDR.Item("requested_by").ToString
                '                a(29) = newDR.Item("cons_item").ToString
                '                a(30) = newDR.Item("cons_item_desc").ToString
                '                a(31) = newDR.Item("type_of_delivery").ToString

                '                If newDR.Item("IN_OUT").ToString = "OUT" Then
                '                    If newDR.Item("mother_rs").ToString = "A1" Then
                '                        a(23) = newDR.Item("OUT_DR_QTY").ToString

                '                        If newDR.Item("ws_dr_in_qty").ToString = "" Then
                '                            a(32) = newDR.Item("ws_dr_out_qty").ToString
                '                        Else
                '                            a(32) = newDR.Item("ws_dr_out_qty").ToString & "/" & newDR.Item("ws_dr_in_qty").ToString
                '                        End If

                '                    ElseIf newDR.Item("mother_rs").ToString = "A" Then
                '                        a(32) = 0
                '                    Else
                '                        a(32) = newDR.Item("OUT_DR_QTY").ToString
                '                    End If

                '                Else
                '                    a(32) = newDR.Item("IN_OTHERS_DR_QTY").ToString
                '                End If

                '                a(33) = newDR.Item("wh_area").ToString
                '                a(34) = 0
                '                a(35) = 0
                '                a(36) = newDR.Item("ws_no").ToString

                '                Dim lvl As New ListViewItem(a)
                '                lvlrequisitionlist.Items.Add(lvl)

                '                If newDR.Item("mother_rs").ToString = "A" Then
                '                    lvlrequisitionlist.Items(counter).BackColor = Color.DarkGreen
                '                    lvlrequisitionlist.Items(counter).ForeColor = Color.White
                '                    lvlrequisitionlist.Items(counter).Font = New Font(New FontFamily("Arial"), 10, FontStyle.Bold)
                '                ElseIf newDR.Item("mother_rs").ToString = "A1" Then
                '                    lvlrequisitionlist.Items(counter).BackColor = Color.LightGreen
                '                    lvlrequisitionlist.Items(counter).Font = New Font(New FontFamily("Arial"), 10, FontStyle.Bold)
                '                ElseIf newDR.Item("mother_rs").ToString = "A2" Then
                '                    lvlrequisitionlist.Items(counter).BackColor = Color.LightYellow
                '                    'lvlrequisitionlist.Items(counter).Font.Size = "11pt"
                '                End If

                '                counter += 1

                'proceedhere:

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Public Sub load_rs_67()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        lvlrequisitionlist.Items.Clear()
        Dim counter As Integer

        Try
            newSQ.connection.Open()

            Dim search, items As String

            Select Case txtSearch.Text
                Case "Charges..."
                    search = ""
                Case "RS No..."
                    search = ""
                Case "Items..."
                    search = ""
                Case "Requested By..."
                    search = ""
                Case "Input By"
                    search = ""
                Case Else
                    search = txtSearch.Text
            End Select

            If txtItemName.Text = "Items..." Then
                items = ""
            Else
                items = txtItemName.Text
            End If

            Dim range, range1, range2 As Integer

            range = 100
            range2 = cmbpages.Text * range
            range1 = range2 - range

            If cmbSearchByCategory.Text = "Search by RS.No." Then

                newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure
                newCMD.Parameters.AddWithValue("@n", 1)

                newCMD.Parameters.AddWithValue("@searchby", cmbSearchByCategory.Text)
                newCMD.Parameters.AddWithValue("@rs_no", txtSearch.Text)
                newCMD.Parameters.AddWithValue("@search", txtSearch.Text)
                newCMD.Parameters.AddWithValue("@iem_desc", txtItemName.Text)

                newCMD.Parameters.AddWithValue("@range1", range1)
                newCMD.Parameters.AddWithValue("@range2", range2)

            ElseIf cmbSearchByCategory.Text = "Search by Requested by" Then

                newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search1", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure
                newCMD.Parameters.AddWithValue("@n", 3)

                newCMD.Parameters.AddWithValue("@searchby", cmbSearchByCategory.Text)
                newCMD.Parameters.AddWithValue("@rs_no", search)
                newCMD.Parameters.AddWithValue("@search", search)
                newCMD.Parameters.AddWithValue("@itemname", items)

                newCMD.Parameters.AddWithValue("@range1", range1)
                newCMD.Parameters.AddWithValue("@range2", range2)

            ElseIf cmbSearchByCategory.Text = "Search by item" Then

                newCMD = New SqlCommand("proc_requisition_slip", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 151)
                newCMD.Parameters.AddWithValue("@dr_no", txtSearch.Text)
                newCMD.Parameters.AddWithValue("@searchby", "Search by item")
                newCMD.Parameters.AddWithValue("@rs_no", "")
                newCMD.Parameters.AddWithValue("@search", txtSearch.Text)
                newCMD.Parameters.AddWithValue("@inout", cmbInOut.Text)

                newCMD.Parameters.AddWithValue("@range1", range1)
                newCMD.Parameters.AddWithValue("@range2", range2)

            ElseIf cmbSearchByCategory.Text = "Search by item (Item Checked only)" Then

                newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search1", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure
                newCMD.Parameters.AddWithValue("@n", 4)
                newCMD.Parameters.AddWithValue("@wh_id", FListOfItems.lvlWarehouseItem.SelectedItems(0).Text)

            End If

            newCMD.CommandTimeout = 300
            newDR = newCMD.ExecuteReader

            Dim a(40) As String

            While newDR.Read

                'a(4) = newDR.Item("ITEM_DESC").ToString
                'Dim lvl As New ListViewItem(a)
                'lvlrequisitionlist.Items.Add(lvl)

                If newDR.Item("division").ToString = "WAREHOUSING AND SUPPLY" Then
                    GoTo proceedhere
                End If

                a(0) = newDR.Item("rs_id").ToString
                a(1) = newDR.Item("rs_no").ToString

                If newDR.Item("date_request").ToString = "" Then
                ElseIf Format(Date.Parse(newDR.Item("date_request").ToString), "MM/dd/yyyy") = "01/01/1990" Then
                    a(2) = "-"
                Else
                    a(2) = Format(Date.Parse(newDR.Item("date_request").ToString), "MM/dd/yyyy")
                End If

                a(3) = newDR.Item("job_order_no").ToString
                a(4) = newDR.Item("ITEM_DESC").ToString
                a(5) = newDR.Item("rs_qty").ToString
                a(6) = newDR.Item("unit").ToString
                a(7) = IIf(Format(Date.Parse(newDR.Item("date_needed").ToString), "MM/dd/yyyy") = "01/01/1900", "", Format(Date.Parse(newDR.Item("date_needed").ToString), "MM/dd/yyyy"))
                a(8) = newDR.Item("type_of_request").ToString
                a(9) = newDR.Item("IN_OUT").ToString
                a(10) = newDR.Item("po_status").ToString
                a(11) = ""
                a(12) = newDR.Item("ws_status").ToString
                a(13) = newDR.Item("charges").ToString
                a(14) = newDR.Item("location").ToString
                a(15) = newDR.Item("wh_id").ToString
                a(16) = newDR.Item("date_log").ToString
                a(17) = newDR.Item("type_of_charges").ToString
                a(18) = newDR.Item("type_of_purchasing").ToString
                a(19) = newDR.Item("remarks").ToString
                a(20) = ""
                a(21) = newDR.Item("dr_no").ToString

                If newDR.Item("mother_rs").ToString = "A" And newDR.Item("IN_OUT").ToString = "IN" Then
                    a(22) = newDR.Item("M_po_ws_released").ToString
                Else
                    a(22) = newDR.Item("po_ws_qty_released").ToString
                End If

                If newDR.Item("mother_rs").ToString = "A" And newDR.Item("IN_OUT").ToString = "IN" Then
                    a(23) = newDR.Item("M_rr_ws_received").ToString
                Else
                    a(23) = newDR.Item("rr_ws_qty_received").ToString
                End If

                a(24) = newDR.Item("users").ToString
                a(25) = newDR.Item("ws_id_dr_id").ToString
                a(26) = ""
                a(27) = ""
                a(28) = newDR.Item("requested_by").ToString
                a(29) = newDR.Item("cons_item").ToString
                a(30) = newDR.Item("cons_item_desc").ToString
                a(31) = newDR.Item("type_of_delivery").ToString

                If newDR.Item("IN_OUT").ToString = "OUT" Then
                    If newDR.Item("mother_rs").ToString = "A1" Then
                        a(23) = newDR.Item("OUT_DR_QTY").ToString

                        If newDR.Item("ws_dr_in_qty").ToString = "" Then
                            a(32) = newDR.Item("ws_dr_out_qty").ToString
                        Else
                            a(32) = newDR.Item("ws_dr_out_qty").ToString & "/" & newDR.Item("ws_dr_in_qty").ToString
                        End If

                    ElseIf newDR.Item("mother_rs").ToString = "A" Then
                        a(32) = 0
                    Else
                        a(32) = newDR.Item("OUT_DR_QTY").ToString
                    End If

                Else
                    a(32) = newDR.Item("IN_OTHERS_DR_QTY").ToString
                End If

                a(33) = newDR.Item("wh_area").ToString
                a(34) = 0
                a(35) = 0
                a(36) = newDR.Item("ws_no").ToString
                a(37) = newDR.Item("qto_item_desc").ToString
                a(38) = newDR.Item("qto_id").ToString
                'a(39) = newDR.Item("temp_col_item_name").ToString
                'a(41) = newDR.Item("dr_option").ToString
                'a(42) = newDR.Item("dr_items_id").ToString

                Dim lvl As New ListViewItem(a)
                lvlrequisitionlist.Items.Add(lvl)

                If newDR.Item("mother_rs").ToString = "A" Then
                    lvlrequisitionlist.Items(counter).BackColor = Color.DarkGreen
                    lvlrequisitionlist.Items(counter).ForeColor = Color.White
                    lvlrequisitionlist.Items(counter).Font = New Font(New FontFamily("Arial"), 10, FontStyle.Bold)
                ElseIf newDR.Item("mother_rs").ToString = "A1" Then
                    lvlrequisitionlist.Items(counter).BackColor = Color.LightGreen
                    lvlrequisitionlist.Items(counter).Font = New Font(New FontFamily("Arial"), 10, FontStyle.Bold)
                ElseIf newDR.Item("mother_rs").ToString = "A2" Then
                    lvlrequisitionlist.Items(counter).BackColor = Color.LightYellow
                    'lvlrequisitionlist.Items(counter).Font.Size = "11pt"
                ElseIf newDR.Item("mother_rs").ToString = "A0" Then
                    lvlrequisitionlist.Items(counter).BackColor = Color.Yellow
                    lvlrequisitionlist.Items(counter).Font = New Font(New FontFamily("Arial"), 10, FontStyle.Bold)
                End If

                counter += 1

proceedhere:

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Public Sub load_rs_3(ByVal n As Integer)
        If clear_data = "yes" Then
            lvlrequisitionlist.Items.Clear()
        End If

        Dim mthread As New Threading.Thread(AddressOf loading)
        mthread.Start()

        Dim newsq As New SQLcon
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand

        Dim row As Integer
        Dim ready As Integer
        Try


            newsq.connection.Open()

            newcmd = New SqlCommand("proc_requisition_slip", newsq.connection)
            newcmd.CommandTimeout = 0
            newcmd.Parameters.Clear()
            newcmd.CommandType = CommandType.StoredProcedure

            newcmd.Parameters.AddWithValue("@nn", cmbSearchByCategory.Text)
            Dim search, items As String

            Select Case txtSearch.Text
                Case "Charges..."
                    search = ""
                Case "RS No..."
                    search = ""
                Case "Items..."
                    search = ""
                Case "Requested By..."
                    search = ""
                Case "Input By"
                    search = ""
                Case Else
                    search = txtSearch.Text
            End Select

            If txtItemName.Text = "Items..." Then
                items = ""
            Else
                items = txtItemName.Text
            End If

            If cmbSearchByCategory.Text = "Search by Date Input" Then

                newcmd.Parameters.AddWithValue("@n", n)
                newcmd.Parameters.AddWithValue("@searchby", Date.Parse(dtpfrom.Text))

            ElseIf cmbSearchByCategory.Text = "Filter by month of Date Request" Then

                'Dim db As String = "dbwarehouse_items"
                'Dim field As String = "whItem^whItemDesc"
                'Dim value As String = cmbItemName.Text & "^" & cmbItemDesc.Text

                'Dim wh_id As Integer = get_id(db, field, value, 2)

                newcmd.Parameters.AddWithValue("@n", n)
                newcmd.Parameters.AddWithValue("@date_from", Date.Parse(dtpfrom.Text))
                newcmd.Parameters.AddWithValue("@date_to", Date.Parse(dtpto.Text))
                newcmd.Parameters.AddWithValue("@search", cmbProject1.Text & " - " & cmbItemDesc.Text)
                newcmd.Parameters.AddWithValue("@division", cmbDivision.Text)

                'newcmd.Parameters.AddWithValue("@wh_id", wh_id)

            ElseIf cmbSearchByCategory.Text = "Search by Charges (Specific Item)" Then

                newcmd.Parameters.AddWithValue("@n", n)
                newcmd.Parameters.AddWithValue("@searchby", search)
                newcmd.Parameters.AddWithValue("@wh_id", charges_wh_id)
                newcmd.Parameters.AddWithValue("@date_from", FListOfItems.date_from)
                newcmd.Parameters.AddWithValue("@date_to", FListOfItems.date_to)

            ElseIf cmbSearchByCategory.Text = "Search by Charges (Specific Item)" Then

                newcmd.Parameters.AddWithValue("@n", n)
                newcmd.Parameters.AddWithValue("@searchby", search)
                newcmd.Parameters.AddWithValue("@wh_id", charges_wh_id)

            ElseIf cmbSearchByCategory.Text = "Search by Charges" Then

                newcmd.Parameters.AddWithValue("@n", n)
                newcmd.Parameters.AddWithValue("@searchby", search)
                newcmd.Parameters.AddWithValue("@itemname", items)

            ElseIf cmbSearchByCategory.Text = "Search by Date Input" Then

                newcmd.Parameters.AddWithValue("@n", 14)
                newcmd.Parameters.AddWithValue("@date_from", Date.Parse(dtpfrom.Text))

            ElseIf cmbSearchByCategory.Text = "Search by Type of Request" Then

                newcmd.Parameters.AddWithValue("@n", n)
                newcmd.Parameters.AddWithValue("@searchby", cmbTypeOfRequest.Text)
                newcmd.Parameters.AddWithValue("@itemname", cmbProject1.Text & " - " & cmbItemDesc.Text)
                newcmd.Parameters.AddWithValue("@date_from", Date.Parse(dtpfrom.Text))
                newcmd.Parameters.AddWithValue("@date_to", Date.Parse(dtpto.Text))
            Else
                If n = 134 Then
                    newcmd.Parameters.AddWithValue("@n", n)
                    newcmd.Parameters.AddWithValue("@searchby", search)
                    newcmd.Parameters.AddWithValue("@division", FDivisionCategory.cmbdiv.Text)
                    newcmd.Parameters.AddWithValue("@from", Date.Parse(FDivisionCategory.dtpFrom.Text))
                    newcmd.Parameters.AddWithValue("@to", Date.Parse(FDivisionCategory.dtpto.Text))
                Else
                    newcmd.Parameters.AddWithValue("@n", n)
                    newcmd.Parameters.AddWithValue("@searchby", search)

                End If

            End If


            ''If cmbSearchByCategory.Text = "Search by item" Then
            ''    newcmd.Parameters.AddWithValue("@n", 1)

            ''ElseIf cmbSearchByCategory.Text = "Search by RS.No." Then
            ''    newcmd.Parameters.AddWithValue("@n", 2)

            ''ElseIf cmbSearchByCategory.Text = "Filter by month of Date Request" Then
            ''    newcmd.Parameters.AddWithValue("@date_from", Date.Parse(DtpickerFrom.Text))
            ''    newcmd.Parameters.AddWithValue("@date_to", Date.Parse(DTP_to.Text))
            ''    newcmd.Parameters.AddWithValue("@n", 3)
            ''ElseIf cmbSearchByCategory.Text = "Search by Type of Request" Then
            ''    newcmd.Parameters.AddWithValue("@n", 4)
            ''ElseIf cmbSearchByCategory.Text = "Search by Charge To" Then
            ''    newcmd.Parameters.AddWithValue("@n", 5)
            ''End If
            'If n = 1 Then
            '    newcmd.Parameters.AddWithValue("@n", 8)
            '    newcmd.Parameters.AddWithValue("@searchby", "")
            'ElseIf n = 2 Then
            '    newcmd.Parameters.AddWithValue("@n", 9)
            '    newcmd.Parameters.AddWithValue("@date_from", Date.Parse(DtpickerFrom.Text))
            '    newcmd.Parameters.AddWithValue("@date_to", Date.Parse(DTP_to.Text))
            'ElseIf n = 3 Then
            '    newcmd.Parameters.AddWithValue("@n", 10)
            '    newcmd.Parameters.AddWithValue("@date_from ", Date.Parse(DtpickerFrom.Text))
            '    'newcmd.Parameters.AddWithValue("@date_from ", Format(Date.Parse(DtpickerFrom.Text), "yyyy-MM-dd"))
            'ElseIf n = 4 Then
            '    'search by item
            '    newcmd.Parameters.AddWithValue("@n", 1)
            '    newcmd.Parameters.AddWithValue("@searchby", txtSearch.Text)
            'ElseIf n = 5 Then
            '    'search by RS_NO

            '    newcmd.Parameters.AddWithValue("@n", 2)
            '    newcmd.Parameters.AddWithValue("@searchby", txtSearch.Text)

            'ElseIf n = 55 Then
            '    'Search by date request

            '    Dim db As String = "dbwarehouse_items"
            '    Dim field As String = "whItem^whItemDesc"
            '    Dim value As String = cmbItemName.Text & "^" & cmbItemDesc.Text

            '    Dim wh_id As Integer = get_id(db, field, value, 2)

            '    newcmd.Parameters.AddWithValue("@n", 31)
            '    newcmd.Parameters.AddWithValue("@date_from", Date.Parse(DtpickerFrom.Text))
            '    newcmd.Parameters.AddWithValue("@date_to", Date.Parse(DTP_to.Text))
            '    newcmd.Parameters.AddWithValue("@wh_id", wh_id)

            'ElseIf n = 6 Then

            '    newcmd.Parameters.AddWithValue("@n", 22)
            '    newcmd.Parameters.AddWithValue("@searchby", txtSearch.Text)

            'ElseIf n = 7 Then

            '    newcmd.Parameters.AddWithValue("@n", 23)
            '    newcmd.Parameters.AddWithValue("@searchby", txtSearch.Text)

            'ElseIf n = 8 Then

            '    newcmd.Parameters.AddWithValue("@n", 24)
            '    newcmd.Parameters.AddWithValue("@searchby", txtSearch.Text)

            'ElseIf n = 9 Then

            '    newcmd.Parameters.AddWithValue("@n", 25)
            '    newcmd.Parameters.AddWithValue("@searchby", txtSearch.Text)

            'ElseIf n = 10 Then

            '    newcmd.Parameters.AddWithValue("@n", 26)
            '    newcmd.Parameters.AddWithValue("@searchby", txtSearch.Text)

            'ElseIf n = 11 Then

            '    newcmd.Parameters.AddWithValue("@n", 27)
            '    newcmd.Parameters.AddWithValue("@searchby", txtSearch.Text)

            'ElseIf n = 12 Then

            '    newcmd.Parameters.AddWithValue("@n", 28)
            '    newcmd.Parameters.AddWithValue("@searchby", txtSearch.Text)

            'End If

            Dim rs_link As String = ""
            Dim rs_link1 As String = ""
            Dim rs_link_qty As Double = 0
            Dim rs_link_qty1 As Double = 0

            newdr = newcmd.ExecuteReader
            If newdr.HasRows Then
                While newdr.Read
                    Dim a(37) As String
                    Dim inout As String = newdr.Item("IN_OUT").ToString
                    Dim wh_id As Integer = CInt(newdr.Item("wh_id").ToString)
                    Dim wh As Integer = CInt(IIf(newdr.Item("remarks").ToString = "", 0, newdr.Item("remarks").ToString))
                    Dim type_of_purchasing As String = newdr.Item("type_of_purchasing").ToString

                    Dim po_exist As Integer = check_if_exist("dbPO_details", "rs_id", newdr.Item("rs_id").ToString, 1)
                    Dim po_status As String = check_po_det_status(newdr.Item("rs_id").ToString)
                    Dim cv_exist As Integer = check_if_exist("dbCashVoucher_items", "rs_id", newdr.Item("rs_id").ToString, 1)
                    Dim ws_exist As Integer = check_if_exist("dbwithdrawal_items", "rs_id", newdr.Item("rs_id").ToString, 1)
                    Dim dr_exist As Integer
                    Dim rr_item_exist As Integer = check_if_exist("dbreceiving_items", "rs_id", newdr.Item("rs_id").ToString, 1)
                    Dim rs_id As Integer = CInt(newdr.Item("rs_id").ToString)

                    Dim po_qty As Double = get_po_qty(CInt(newdr.Item("rs_id").ToString))
                    Dim rr_qty As Double = get_rr_qty(rs_id)

                    Dim rs_qty As Double = CDbl(newdr.Item("qty").ToString)
                    Dim ws_qty As Double = get_ws_qty(rs_id)

                    rs_link = newdr.Item("rs_no").ToString

                    a(0) = rs_id
                    a(1) = newdr.Item("rs_no").ToString
                    a(2) = Format(Date.Parse(newdr.Item("date_req").ToString), "MM/dd/yyyy")
                    a(3) = newdr.Item("job_order_no").ToString

                    'Select Case inout
                    '    Case "IN"
                    '        a(4) = GET_ITEM_DESC(wh_id)
                    '    Case "OUT"
                    '        If wh = 1 Then
                    '            'ddto kwaon sa main database sa warehouse
                    '            a(4) = GET_ITEM_DESC(wh_id)

                    '        ElseIf wh = 2 Then
                    '            'Dim new_wh_id_exist As Integer = check_if_exist("warehouse_items_new", "id", wh_id, 1)

                    '            'If new_wh_id_exist > 0 Then
                    '            '    a(4) = FMaterials_ToolsTurnOverReport.get_newWhItemDesc(wh_id)
                    '            'Else
                    '            '    a(4) = GET_ITEM_DESC(wh_id)
                    '            'End If
                    '            a(4) = get_item_name_from_turnover_item(wh_id)
                    '        End If

                    '    Case "OTHERS"
                    '        a(4) = GET_ITEM_DESC(wh_id)
                    '    Case "QUARRY-IN"
                    '        a(4) = GET_ITEM_DESC(wh_id)
                    '    Case "FACILITIES"
                    '        a(4) = GET_ITEM_DESC_FROM_FACILITIES(wh_id)
                    '    Case "TOOLS"
                    '        a(4) = GET_ITEM_DESC_FROM_FACILITIES(wh_id)
                    '    Case "ADD-ON"
                    '        a(4) = GET_ITEM_DESC_FROM_FACILITIES(wh_id)
                    'End Select

                    If check_if_exist("dbborrower_turnover_details", "rs_id", CInt(newdr.Item("rs_id").ToString), 1) > 0 Then

                        If FListofBorrowerItem.get_borrwed_item(CInt(newdr.Item("rs_id").ToString), 0) = "" Then
                            a(4) = newdr.Item("ITEM_NAME").ToString
                        Else
                            a(4) = newdr.Item("ITEM_NAME").ToString & "(" & FListofBorrowerItem.get_borrwed_item(CInt(newdr.Item("rs_id").ToString), 0) & ")"
                        End If

                    Else
                        a(4) = newdr.Item("ITEM_NAME").ToString & multiple_item(CInt(newdr.Item("rs_id").ToString))
                    End If

                    a(4) = newdr.Item("ITEM_NAME").ToString
                    a(5) = rs_qty

                    a(6) = newdr.Item("unit").ToString
                    a(7) = Format(Date.Parse(IIf(newdr.Item("date_needed").ToString = "", "1990-01-01", newdr.Item("date_needed").ToString)), "MM/dd/yyyy")
                    'a(8) = newdr.Item("typeRequest").ToString & " - " & newdr.Item("tor_sub_desc").ToString
                    a(8) = newdr.Item("tor_desc").ToString & " - " & newdr.Item("tor_sub_desc").ToString

                    a(22) = po_qty
                    a(23) = rr_qty
                    a(27) = newdr.Item("main_sub").ToString
                    a(33) = newdr.Item("wh_area").ToString
                    a(34) = newdr.Item("LINK_QTY").ToString


                    Select Case inout
                        Case ""
                            a(9) = "WAITING..."
                            a(10) = "WAITING..."
                            a(11) = "WAITING..."
                            a(12) = "WAITING..."
                        Case "IN", "OUT", "OTHERS"
                            a(9) = inout
                            a(10) = "WAITING..."
                            a(11) = "WAITING..."
                            a(12) = "WAITING..."

                        Case "BORROWER"

                            '*******for borrower
                            If check_if_requested_items_are_all_purchased(newdr.Item("rs_no").ToString) > 0 Then
                                ready = 1
                            Else
                                ready = 0
                            End If
                            '******************

                            a(4) = a(4)
                            a(9) = inout
                            a(10) = "N/A"
                            a(11) = "N/A"
                            a(12) = "N/A"

                            If check_if_exist("dbborrower_details", "rs_id", CInt(newdr.Item("rs_id").ToString), 1) > 0 Then
                                a(9) = "BORROWED"
                                a(10) = "N/A"
                                a(11) = "N/A"
                                a(12) = "N/A"
                            End If

                    End Select

                    If check_if_exist("dbborrower_turnover_details", "rs_id", CInt(newdr.Item("rs_id").ToString), 1) > 0 Then

                        If FListofBorrowerItem.get_borrwed_item(CInt(newdr.Item("rs_id").ToString), 1) = "" Then
                        Else
                            a(9) = FListofBorrowerItem.get_borrwed_item(CInt(newdr.Item("rs_id").ToString), 1)
                            a(10) = "N/A"
                            a(11) = "N/A"
                            a(12) = "N/A"
                        End If
                    End If

                    Select Case type_of_purchasing
                        Case "PURCHASE ORDER"
                            If a(22) = 0 Then
                                a(10) = "PENDING"
                                a(12) = "N/A"
                            ElseIf a(22) < a(5) Then
                                a(10) = "PO PARTIALLY RELEASED"
                                a(12) = "N/A"
                            Else
                                a(10) = "PO RELEASED"
                                a(12) = "N/A"
                            End If

                            If rr_qty = 0 Then
                                a(11) = "PENDING"
                                a(12) = "N/A"
                            ElseIf rr_qty < rs_qty Then
                                a(11) = "PARTIALLY RECEIVED"
                                a(12) = "N/A"
                            Else
                                a(10) = "PURCHASED"
                                a(11) = "RECEIVED"
                                a(12) = "N/A"
                            End If

                        Case "N/A"
                            If a(22) = 0 Then
                                a(10) = "PENDING"
                                a(12) = "N/A"
                            ElseIf a(22) < a(5) Then
                                a(10) = "PO PARTIALLY RELEASED"
                                a(12) = "N/A"
                            Else
                                a(10) = "PO RELEASED"
                                a(12) = "N/A"
                            End If

                            If rr_qty = 0 Then
                                a(11) = "PENDING"
                                a(12) = "N/A"
                            ElseIf rr_qty < rs_qty Then
                                a(11) = "PARTIALLY RECEIVED"
                                a(12) = "N/A"
                            Else
                                a(10) = "PURCHASED"
                                a(11) = "RECEIVED"
                                a(12) = "N/A"
                            End If

                        Case "CASH"
                            If a(22) = 0 Then
                                a(10) = "PENDING"
                                a(12) = "N/A"
                            ElseIf a(22) < a(5) Then
                                a(10) = "CV PARTIALLY RELEASED"
                                a(12) = "N/A"
                            Else
                                a(10) = "CV RELEASED"
                                a(12) = "N/A"
                            End If

                            If rr_qty = 0 Then
                                a(11) = "PENDING"
                                a(12) = "N/A"
                            ElseIf rr_qty < rs_qty Then
                                a(11) = "PARTIALLY RECEIVED"
                                a(12) = "N/A"
                            Else
                                a(10) = "PURCHASED"
                                a(11) = "RECEIVED"
                                a(12) = "N/A"
                            End If

                        Case "WITHDRAWAL"
                            a(23) = ws_qty


                            If po_qty = 0 Then
                                a(10) = "N/A"
                                a(11) = "N/A"
                                a(12) = "PENDING"

                            ElseIf po_qty < rs_qty Then
                                If ws_qty = 0 Then
                                    a(10) = "N/A"
                                    a(11) = "N/A"
                                    a(12) = "WS PARTIALLY RELEASED"
                                ElseIf ws_qty < po_qty Then
                                    a(10) = "N/A"
                                    a(11) = "N/A"
                                    a(12) = "PARTIALLY WITHDRAWN"
                                ElseIf ws_qty = po_qty And po_qty = rs_qty And po_qty <> 0 Then
                                    a(10) = "N/A"
                                    a(11) = "N/A"
                                    a(12) = "WITHDRAWN"

                                ElseIf ws_qty = po_qty And po_qty <> rs_qty And po_qty <> 0 Then
                                    a(10) = "N/A"
                                    a(11) = "N/A"
                                    a(12) = "PARTIALLY WITHDRAWN"
                                End If

                            ElseIf po_qty = rs_qty And po_qty <> 0 Then
                                If ws_qty = 0 Then
                                    a(10) = "N/A"
                                    a(11) = "N/A"
                                    a(12) = "WS RELEASED"
                                ElseIf ws_qty < po_qty Then
                                    a(10) = "N/A"
                                    a(11) = "N/A"
                                    a(12) = "PARTIALLY WITHDRAWN"
                                ElseIf ws_qty = po_qty And po_qty = rs_qty And po_qty <> 0 Then
                                    a(10) = "N/A"
                                    a(11) = "N/A"
                                    a(12) = "WITHDRAWN"
                                End If
                            End If

                        Case "DR"
                            'a(10) = "N/A"
                            'a(11) = "N/A"
                            'a(12) = "N/A"

                            'a(22) = "N/A"
                            'a(23) = "N/A"

                            If a(22) = 0 Then
                                a(10) = "PENDING"
                                a(12) = "N/A"
                            ElseIf a(22) < a(5) Then
                                a(10) = "PO PARTIALLY RELEASED"
                                a(12) = "N/A"
                            Else
                                a(10) = "PO RELEASED"
                                a(12) = "N/A"
                            End If

                            If rr_qty = 0 Then
                                a(11) = "PENDING"
                                a(12) = "N/A"
                            ElseIf rr_qty < rs_qty Then
                                a(11) = "PARTIALLY RECEIVED"
                                a(12) = "N/A"
                            Else
                                a(10) = "PURCHASED"
                                a(11) = "RECEIVED"
                                a(12) = "N/A"
                            End If

                            a(10) = "N/A"
                            a(22) = "N/A"
                            'a(23) = "N/A"
                    End Select

                    If newdr.Item("trans").ToString = "cancel" Then
                        a(10) = "CANCELLED"
                        a(11) = "CANCELLED"
                        a(12) = "CANCELLED"
                    End If

                    If newdr.Item("process").ToString = "ADFIL" Then

                        'search ni xa for personal and others ky lahi man og table ang warehouse
                        'If cmbSearchByCategory.Text = "Search by Charges (PERSONAL AND OTHERS)" Then
                        '    Dim mcharges As String = get_multiple_charges1(rs_id, txtSearch.Text)

                        '    If mcharges.Length < 1 Then
                        '    Else
                        '        mcharges = mcharges.Trim().Substring(0, mcharges.Length - 1)
                        '        a(13) = "ADFIL" & "(" & UCase(mcharges) & ")"

                        '    End If

                        '    'diri pang warehouse, equipment and project ni xa nga search
                        'Else
                        '    a(13) = FReceivingReport.multiplecharges(CInt(newdr.Item("rs_id").ToString), 1)
                        'End If

                        ''a(13) = FReceivingReport.multiplecharges(CInt(newdr.Item("rs_id").ToString), 1)

                    ElseIf newdr.Item("process").ToString = "OUTSOURCE" Then
                        ''a(13) = FReceivingReport.multiplecharges(CInt(newdr.Item("rs_id").ToString), 2)
                    End If

                    a(14) = newdr.Item("location").ToString
                    a(15) = newdr.Item("wh_id").ToString
                    a(16) = Format(Date.Parse(IIf(newdr.Item("date_log").ToString = "", "1991-01-01", newdr.Item("date_log").ToString)), "yyyy-MM-dd")
                    a(17) = newdr.Item("process").ToString
                    a(18) = newdr.Item("type_of_purchasing").ToString
                    a(19) = newdr.Item("remarks").ToString
                    a(20) = get_quarry_loc(CInt(newdr.Item("rs_id").ToString))
                    'a(21) = IIf(inout = "QUARRY-IN", "coming soon...", "N/A")
                    ' a(23) = get_total_receiving(CInt(newdr.Item("rs_id").ToString))

                    ''a(21) = get_multiple_dr_no(rs_id).ToString

                    a(32) = dr_qty

                    a(24) = get_user_lname_fname(newdr.Item("user_id").ToString)
                    a(25) = func_wh_id(rs_id)
                    a(26) = get_multiple_bs_no(rs_id) 'newdr.Item("BS_no").ToString
                    a(28) = newdr.Item("requested_by").ToString
                    a(29) = newdr.Item("const_item").ToString
                    a(30) = newdr.Item("const_Item_Desc").ToString
                    a(31) = newdr.Item("dr_option").ToString
                    'a(35) = IIf(newdr.Item("rr_item_id").ToString = "", 0, newdr.Item("rr_item_id").ToString)

                    rs_link_qty = If(newdr.Item("LINK_QTY").ToString = "", 0, newdr.Item("LINK_QTY").ToString)

                    If rs_link = rs_link1 Then
                        If rs_link_qty1 = 0 Then
                            rs_link_qty = 0
                        Else
                            rs_link_qty = rs_link_qty1 - ws_qty
                        End If

                        a(34) = rs_link_qty
                    Else
                        a(34) = rs_link_qty
                    End If

                    If inout = "OUT" Then
                        'qty left = rs qty - dr qty
                        a(34) = CDbl(a(5)) - CDbl(a(32))
                    End If

                    If newdr.Item("original_volume").ToString = "A" Then
                        'a(5) = FormatNumber(get_all_qty_for_this_rs(newdr.Item("rs_no").ToString), 0,,, TriState.True) & "/" & FormatNumber(rs_qty, 0,,, TriState.True)
                        a(5) = FDRLIST.get_qty_left_from_receiving(newdr.Item("rs_no").ToString, newdr.Item("rs_id").ToString, 111) & "/" & FormatNumber(rs_qty, 0,,, TriState.True)

                        a(9) = "N/A"
                        a(10) = "N/A"
                        a(11) = "N/A"
                        a(12) = "N/A"
                    End If

                    '**********TEMPORARILY DISABLE DONT DELETE************************
                    If cmbSearchByCategory.Text = "Search by item" Then
                        'If search_by1(a(4), txtSearch.Text) = True Then
                        'Else
                        '    GoTo proceedhere
                        'End If
                    ElseIf cmbSearchByCategory.Text = "Search by RS.No." Then
                        'If search_by1(a(1), txtSearch.Text) = True Then
                        'Else
                        '    GoTo proceedhere
                        'End If
                    ElseIf cmbSearchByCategory.Text = "Search by Type of Request" Then
                        If search_by1(a(8), txtSearch.Text) = True Then
                        Else
                            GoTo proceedhere
                        End If
                    ElseIf cmbSearchByCategory.Text = "Search by Charge To" Then
                        If search_by1(a(13), txtSearch.Text) = True Then
                        Else
                            GoTo proceedhere
                        End If
                    ElseIf cmbSearchByCategory.Text = "Search by Requested by" Then
                        'If search_by1(a(28), txtSearch.Text) = True Then
                        'Else
                        '    GoTo proceedhere
                        'End If
                    ElseIf cmbSearchByCategory.Text = "Search by Input by" Then
                        ''  MsgBox(newdr.Item("user_id").ToString)
                        'If search_by1(a(24), txtSearch.Text) = True Then
                        'Else
                        '    GoTo proceedhere
                        'End If
                    ElseIf cmbSearchByCategory.Text = "Search by User Name" Then
                        'If search_by1(a(24), txtSearch.Text) = True Then
                        'Else
                        '    GoTo proceedhere
                        'End If
                    ElseIf cmbSearchByCategory.Text = "Search by Borrower Slip No." Then
                        If search_by1(a(26), txtSearch.Text) = True Then
                        Else
                            GoTo proceedhere
                        End If
                    End If


                    Dim lvl As New ListViewItem(a)
                    lvlrequisitionlist.Items.Add(lvl)
                    rs_link1 = rs_link
                    rs_link_qty1 = rs_link_qty

                    '***********for borrower ni(mo color kung completo na ang item na ge request para e borrow or transfer)
                    If ready = 1 And newdr.Item("main_sub").ToString = "MAIN" Then
                        lvlrequisitionlist.Items(row).BackColor = Color.Red

                    ElseIf ready = 0 And newdr.Item("main_sub").ToString = "MAIN" Then
                        lvlrequisitionlist.Items(row).BackColor = Color.LightGreen
                    End If
                    '***********

                    If type_of_purchasing = "WITHDRAWAL" Then
                        lvlrequisitionlist.Items(row).BackColor = Color.LightBlue
                    End If

                    row += 1

                    If newdr.Item("trans").ToString = "cancel" Then
                        lvlrequisitionlist.Items(row - 1).BackColor = Color.Red
                    End If

                    If check_if_exist("Mark_Fac_Tools", "rs_id", rs_id, 1) > 0 Then
                        lvlrequisitionlist.Items(row - 1).BackColor = Color.Orange
                    End If

                    If newdr.Item("original_volume").ToString = "A" Then
                        lvlrequisitionlist.Items(row - 1).BackColor = Color.DarkGreen
                        lvlrequisitionlist.Items(row - 1).ForeColor = Color.White
                    ElseIf newdr.Item("original_volume").ToString = "B" Then
                        lvlrequisitionlist.Items(row - 1).BackColor = Color.LightGreen
                        lvlrequisitionlist.Items(row - 1).ForeColor = Color.Black
                    End If

                    Application.DoEvents()

proceedhere:

                End While

            Else
                mthread.Abort()
                MessageBox.Show("Data doesn't exist...", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Exit Sub
            End If

            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsq.connection.Close()

            mthread.Abort()
        End Try
    End Sub

    Public Function get_multiple_dr_no(rs_id As Integer) As String
        'Dim newSQ As New SQLcon
        'Dim newCMD As SqlCommand
        'Dim newDR As SqlDataReader
        'dr_qty = Nothing

        'Try
        '    newSQ.connection.Open()
        '    Dim query As String = "SELECT dr_no,sum(qty) as DR_QTY FROM dbDeliveryReport_items WHERE rs_id = " & rs_id & " group by dr_no"
        '    newCMD = New SqlCommand(query, newSQ.connection)
        '    newDR = newCMD.ExecuteReader

        '    While newDR.Read
        '        get_multiple_dr_no &= newDR.Item("dr_no").ToString & ","
        '        dr_qty = dr_qty + CDbl(newDR.Item("DR_QTY").ToString)

        '    End While
        '    newDR.Close()

        'Catch ex As Exception
        '    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Finally
        '    newSQ.connection.Close()
        '    If get_multiple_dr_no = "" Then
        '        get_multiple_dr_no = 0
        '    Else
        '        get_multiple_dr_no = remove_last_character(get_multiple_dr_no)
        '    End If

        'End Try

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        dr_qty = 0

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 29)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_multiple_dr_no &= newDR.Item("dr_no").ToString & ","
                dr_qty = dr_qty + CDbl(newDR.Item("DR_QTY").ToString)
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

            If get_multiple_dr_no = "" Then
                get_multiple_dr_no = 0
            Else
                get_multiple_dr_no = remove_last_character(get_multiple_dr_no)
            End If
        End Try

    End Function

    Public Function get_multiple_bs_no(rs_id As Integer) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_items", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 6)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_multiple_bs_no &= newDR.Item("bs_no").ToString & ","
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
            If get_multiple_bs_no = "" Then
                get_multiple_bs_no = 0
            Else
                get_multiple_bs_no = remove_last_character(get_multiple_bs_no)
            End If

        End Try

    End Function
    Public Function check_if_requested_items_are_all_purchased(rs_no As String) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 18)
            newCMD.Parameters.AddWithValue("@rs_no", rs_no)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim rs_id As Integer = CInt(newDR.Item("rs_id").ToString)
                Dim rs_qty As Decimal = newDR.Item("qty").ToString
                Dim rr_qty As Decimal = get_rr_qty(rs_id)

                If rs_qty = rr_qty And rr_qty <> 0 Then

                ElseIf rr_qty < rs_qty Or rr_qty = 0 Then
                    check_if_requested_items_are_all_purchased += 1
                End If

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
            GC.Collect()
        End Try

    End Function

    Public Function get_borrowed_qty(ByVal rs_id As Integer) As Integer
        Dim nwSQL As New SQLcon
        Dim nwCMD As SqlCommand
        Dim nwDR As SqlDataReader

        Try
            nwSQL.connection.Open()
            publicquery = "SELECT a.rs_id, b.* FROM dbBorrower_checking_info a INNER JOIN dbBorrower_checking_items b ON a.checking_info_id = b.checking_info_id WHERE rs_id =  " & rs_id
            nwCMD = New SqlCommand(publicquery, nwSQL.connection)
            nwDR = nwCMD.ExecuteReader
            While nwDR.Read

                get_borrowed_qty += FListofBorrowerItem.if_item_available(nwDR.Item("rr_item_sub_id").ToString)
            End While
            nwDR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            nwSQL.connection.Close()
        End Try
    End Function

    Public Function func_wh_id(ByVal rs_id As Integer) As Integer
        func_wh_id = get_id("dbPO_details", "rs_id", rs_id, 1)
    End Function
    Public Function get_user_lname_fname(ByVal x As String) As String
        Dim y As String = ""
        Dim newSQ As New SQLcon

        Try
            Dim newcmd As SqlCommand
            Dim newdr As SqlDataReader

            newSQ.connection.Open()

            Dim query As String = "SELECT * FROM dbregistrationform WHERE user_id = '" & x & "'"
            newcmd = New SqlCommand(query, newSQ.connection)
            newdr = newcmd.ExecuteReader
            While newdr.Read

                y = newdr.Item("fname").ToString & " " & newdr.Item("lname").ToString

            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
        'search_by1 = False
        get_user_lname_fname = y
    End Function
    Public Function get_rr_qty(ByVal rs_id As Integer) As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 16)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_rr_qty += CDbl(newDR.Item("desired_qty").ToString())
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
            GC.Collect()

        End Try

    End Function
    Public Function get_ws_qty(ByVal rs_id As Integer) As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new1", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 7)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_ws_qty += newDR.Item("qty").ToString()
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
            GC.Collect()
        End Try

    End Function
    Public Function get_total_receiving(ByVal rs_id As Integer) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new1", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 5)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_total_receiving += CInt(newDR.Item("desired_qty").ToString())
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Function get_item_name_from_turnover_item(ByVal wh_id As Integer) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim a(10) As String


        Try
            newSQ.connection.Open()

            newCMD = New SqlCommand("proc_turnover_materials", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 2)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)

            newDR = newCMD.ExecuteReader
            While newDR.Read
                get_item_name_from_turnover_item = newDR.Item("item_name").ToString & " - " & newDR.Item("item_desc").ToString
            End While
            newDR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Function
    Public Function count_rs_no_from_wslip(ByVal rs_no As String) As Integer

        count_rs_no_from_wslip = 0
        Dim newSQ As New SQLcon
        Try
            Dim newcmd As SqlCommand
            Dim newdr As SqlDataReader

            newSQ.connection.Open()

            Dim query As String = "SELECT * FROM dbwithdrawn_items a INNER JOIN dbrequisition_slip b ON a.rs_id = b.rs_id WHERE b.rs_no = '" & rs_no & "'"
            newcmd = New SqlCommand(query, newSQ.connection)
            newdr = newcmd.ExecuteReader
            While newdr.Read
                count_rs_no_from_wslip += 1
            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Public Function count_rs_no_from_rrslip(ByVal rs_no As String) As Integer

        count_rs_no_from_rrslip = 0
        Dim newSQ As New SQLcon
        Try
            Dim newcmd As SqlCommand
            Dim newdr As SqlDataReader

            newSQ.connection.Open()

            Dim query As String = "SELECT * FROM dbreceiving_items a INNER JOIN dbrequisition_slip b ON a.rs_id = b.rs_id WHERE b.rs_no = '" & rs_no & "'"
            newcmd = New SqlCommand(query, newSQ.connection)
            newdr = newcmd.ExecuteReader
            While newdr.Read
                count_rs_no_from_rrslip += 1
            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Public Function get_quarry_loc(ByVal rs_id As Integer) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        get_quarry_loc = ""


        Try
            newSQ.connection.Open()
            publicquery = "SELECT b.quarry_name FROM dbquary_charges a INNER JOIN dbQuarryInfo b ON a.quarry_id = b.quarry_id WHERE a.rs_id = " & rs_id
            newCMD = New SqlCommand(publicquery, newSQ.connection)
            newDR = newCMD.ExecuteReader
            While newDR.Read
                get_quarry_loc &= newDR.Item("quarry_name").ToString & "\"
            End While
            newDR.Close()

            If get_quarry_loc.Length < 1 Then
            Else
                get_quarry_loc = get_quarry_loc.Trim().Substring(0, get_quarry_loc.Length - 1)
                get_quarry_loc = "(" & UCase(get_quarry_loc) & ")"

            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Public Function check_withdrawStatus(ByVal req_id As Integer) As String
        Dim dr As SqlDataReader
        Try
            SQLcon.connection.Open()
            publicquery = "SELECT b.rs_id, a.withdraw_status FROM dbwithdrawal_info a INNER JOIN dbwithdrawal_items b ON a.ws_info_id = b.ws_info_id WHERE b.rs_id = '" & req_id & "'"
            cmd = New SqlCommand(publicquery, SQLcon.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                If dr.Item("withdraw_status").ToString = "WITHDRAWAL RELEASED" Then
                    check_withdrawStatus = "WITHDRAWAL RELEASED"
                Else
                    check_withdrawStatus = "WITHDRAWN"
                End If
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Function

    Public Function check_received_status(ByVal id As Integer) As Integer
        Dim SQ As New SQLcon
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        Try
            Dim query As String
            SQ.connection.Open()

            query = "SELECT a.po_no,a.rs_id FROM dbPO_details a INNER JOIN dbreceiving_info b ON a.po_no = b.po_no WHERE a.rs_id = '" & id & "' AND a.selected = 'TRUE'"
            cmd = New SqlCommand(query, SQ.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                check_received_status += 1
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Function

    Public Function check_po_det_status(ByVal rs_id As Integer) As String
        Try
            Dim query As String
            query = "SELECT selected FROM dbPO_details WHERE rs_id = " & rs_id
            check_po_det_status = get_specific_column_value(query, 0)

            GC.Collect()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Sub load_rs()
        lvlrequisitionlist.Items.Clear()

        Dim newsq As New SQLcon
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand

        Dim row As Integer

        Try

            newsq.connection.Open()

            newcmd = New SqlCommand("proc_requisition_slip", newsq.connection)
            newcmd.Parameters.Clear()
            newcmd.CommandType = CommandType.StoredProcedure

            If cmbSearchByCategory.Text = "Search by RS.No." Then
                newcmd.Parameters.AddWithValue("@n", 1)

            ElseIf cmbSearchByCategory.Text = "Search by JO.No." Then
                newcmd.Parameters.AddWithValue("@n", 2)

            ElseIf cmbSearchByCategory.Text = "Search by item from warehouse" Then
                newcmd.Parameters.AddWithValue("@n", 3)

            ElseIf cmbSearchByCategory.Text = "Search by item from others" Then
                newcmd.Parameters.AddWithValue("@n", 6)

            ElseIf cmbSearchByCategory.Text = "Search by Date Request" Then
                newcmd.Parameters.AddWithValue("@n", 4)
                newcmd.Parameters.AddWithValue("@date_req", Date.Parse(dtpsearchdatereq.Text))

            ElseIf cmbSearchByCategory.Text = "Search by Cash Rs.No." Then
                newcmd.Parameters.AddWithValue("@n", 5)
                newcmd.Parameters.AddWithValue("@date_req", Date.Parse(dtpsearchdatereq.Text))

            ElseIf cmbSearchByCategory.Text = "Filter by month of Date Request" Then
                newcmd.Parameters.AddWithValue("@n", 7)
                newcmd.Parameters.AddWithValue("@date_from", Date.Parse(dtpfrom.Text))
                newcmd.Parameters.AddWithValue("@date_to", Date.Parse(dtpto.Text))
            End If

            newcmd.Parameters.AddWithValue("@searchby", txtSearch.Text)

            newdr = newcmd.ExecuteReader
            If newdr.HasRows Then
                While newdr.Read
                    Dim a(20) As String

                    a(0) = newdr.Item("rs_id").ToString
                    a(1) = newdr.Item("rs_no").ToString
                    a(2) = Format(Date.Parse(newdr.Item("date_req").ToString), "MM/dd/yyyy")
                    a(3) = newdr.Item("job_order_no").ToString

                    If newdr.Item("wh_id").ToString = 0 Then
                        a(4) = newdr.Item("item_desc").ToString

                    ElseIf newdr.Item("wh_id").ToString <> 0 And newdr.Item("typeRequest").ToString <> "OTHERS" Then
                        a(4) = GET_ITEM_DESC(newdr.Item("wh_id").ToString)

                    ElseIf newdr.Item("wh_id").ToString <> 0 And newdr.Item("typeRequest").ToString = "OTHERS" Then
                        a(4) = GET_ITEM_DESC_FROM_OTHERS(newdr.Item("wh_id").ToString)

                    End If

                    If newdr.Item("wh_id").ToString <> 0 And newdr.Item("typeRequest").ToString = "OTHERS" And newdr.Item("process").ToString = "PERSONAL" Then
                        a(4) = GET_ITEM_DESC_FROM_PERSONAL_TOOLS(newdr.Item("wh_id").ToString)

                    End If

                    If newdr.Item("wh_id").ToString <> 0 And newdr.Item("typeRequest").ToString = "OTHERS" And newdr.Item("process").ToString = "PERSONAL" And newdr.Item("IN_OUT").ToString = "OUT" Then
                        a(4) = GET_ITEM_DESC(newdr.Item("wh_id").ToString)
                    End If


                    a(5) = newdr.Item("qty").ToString
                    a(6) = newdr.Item("unit").ToString
                    a(7) = Format(Date.Parse(newdr.Item("date_needed").ToString), "MM/dd/yyyy")
                    a(8) = newdr.Item("typeRequest").ToString
                    a(9) = newdr.Item("IN_OUT").ToString

                    If newdr.Item("trans").ToString = "cancel" Then
                        a(10) = "CANCELLED"
                        a(11) = "CANCELLED"
                        a(12) = "CANCELLED"

                    Else
                        If check_if_exist("dbpurchase_order", "rs_no", newdr.Item("rs_no").ToString, 0) > 0 Then
                            a(10) = "PO RELEASED"
                        Else
                            a(10) = "PENDING"
                        End If

                        If newdr.Item("IN_OUT").ToString = "IN" Then
                            a(12) = "N/A"
                            a(11) = "PENDING"
                        ElseIf newdr.Item("IN_OUT").ToString = "OUT" Then
                            a(12) = "PENDING"
                            a(11) = "N/A"
                            a(10) = "N/A"

                        ElseIf newdr.Item("IN_OUT").ToString = "FACILITIES" Or newdr.Item("IN_OUT").ToString = "TOOLS" Then
                            a(12) = "N/A"
                            a(11) = "PENDING"

                        ElseIf newdr.Item("typeRequest").ToString = "EQUIPMENT" And newdr.Item("IN_OUT").ToString = "OTHERS" Then
                            a(12) = "N/A"
                            a(11) = "PENDING"

                        ElseIf newdr.Item("typeRequest").ToString = "PROJECT" And newdr.Item("IN_OUT").ToString = "OTHERS" Then
                            a(12) = "N/A"
                            a(11) = "PENDING"

                        ElseIf newdr.Item("typeRequest").ToString = "SUPPLY" And newdr.Item("IN_OUT").ToString = "OTHERS" Then
                            a(12) = "N/A"
                            a(11) = "PENDING"

                        End If

                        If newdr.Item("IN_OUT").ToString = "OTHERS" And newdr.Item("process").ToString = "PERSONAL" Then
                            a(12) = "N/A"
                            a(11) = "PENDING"
                        End If

                        If check_if_exist("dbreceiving_info", "rs_no", newdr.Item("rs_no").ToString, 0) > 0 Then
                            a(10) = "PURCHASED"
                            a(11) = "RECEIVED"
                        Else

                        End If

                        If check_if_exist("dbwithdrawal_info", "rs_no", newdr.Item("rs_no").ToString, 0) > 0 Then
                            a(12) = "WITHDRAWN"
                            a(10) = "N/A"
                            a(11) = "N/A"
                        Else

                        End If
                        'CLOSE NI YOT! HAHAHA ---------------------------------
                    End If

                    'a(11) = "RR"

                    'a(12) = "N/A lng sa, pass sa hehehe"
                    'If newdr.Item("typeRequest").ToString = "OTHERS" Then
                    '    a(13) = CHARGE_TO(newdr.Item("charge_to").ToString, newdr.Item("typeRequest").ToString, newdr.Item("process").ToString)
                    'Else
                    '    a(13) = CHARGE_TO(newdr.Item("charge_to").ToString, newdr.Item("typeRequest").ToString, newdr.Item("IN_OUT").ToString)

                    'End If

                    'If newdr.Item("typeRequest").ToString = "OTHERS" And newdr.Item("process").ToString = "PERSONAL" And newdr.Item("IN_OUT").ToString = "OUT" Then
                    '    a(13) = CHARGE_TO(newdr.Item("charge_to").ToString, newdr.Item("typeRequest").ToString, newdr.Item("IN_OUT").ToString)

                    'End If

                    ''if CASH

                    'If newdr.Item("typeRequest").ToString = "OTHERS" And newdr.Item("process").ToString = "CASH" And newdr.Item("IN_OUT").ToString = "OTHERS" Then
                    '    a(12) = "N/A"
                    '    a(11) = "N/A"
                    '    a(10) = "N/A"
                    '    a(13) = CHARGE_TO(newdr.Item("charge_to").ToString, newdr.Item("typeRequest").ToString, newdr.Item("IN_OUT").ToString)
                    'End If

                    Dim typeOfRequest As String = newdr.Item("typeRequest").ToString
                    Dim INOUT As String = newdr.Item("IN_OUT").ToString
                    Dim process As String = newdr.Item("process").ToString
                    Dim charge_for_cash As String = newdr.Item("charge_for_cash").ToString

                    '*=========================================
                    '* 4 - charge to warehouse
                    '* 3 - charge to department,admin and etc.
                    '* 1 - charge to equipment
                    '*=========================================

                    If typeOfRequest = "SUPPLY" And INOUT = "IN" Then
                        charge_to_id = newdr.Item("charge_to").ToString
                        a(13) = GET_equip_desc_AND_proj_desc(charge_to_id, 4)

                    ElseIf typeOfRequest = "SUPPLY" And INOUT = "OUT" Then
                        charge_to_id = newdr.Item("charge_to").ToString
                        a(13) = GET_equip_desc_AND_proj_desc(charge_to_id, 3)

                    ElseIf typeOfRequest = "EQUIPMENT" And INOUT = "OUT" Then
                        charge_to_id = newdr.Item("charge_to").ToString
                        a(13) = GET_equip_desc_AND_proj_desc(charge_to_id, 1)

                    ElseIf typeOfRequest = "EQUIPMENT" And INOUT = "OTHERS" Then
                        charge_to_id = newdr.Item("charge_to").ToString
                        a(13) = where_to_charge1(process, charge_for_cash)

                    ElseIf typeOfRequest = "PROJECT" And INOUT = "OUT" Then
                        charge_to_id = newdr.Item("charge_to").ToString
                        a(13) = where_to_charge1(process, charge_for_cash)

                    ElseIf typeOfRequest = "PROJECT" And INOUT = "OTHERS" Then
                        charge_to_id = newdr.Item("charge_to").ToString
                        a(13) = where_to_charge1(process, charge_for_cash)

                    ElseIf typeOfRequest = "OTHERS" And INOUT = "TOOLS" Then
                        charge_to_id = newdr.Item("charge_to").ToString
                        a(13) = where_to_charge1(process, charge_for_cash)

                    ElseIf typeOfRequest = "OTHERS" And INOUT = "FACILITIES" Then
                        charge_to_id = newdr.Item("charge_to").ToString
                        a(13) = where_to_charge1(process, charge_for_cash)

                    ElseIf typeOfRequest = "OTHERS" And INOUT = "OTHERS" Then
                        charge_to_id = newdr.Item("charge_to").ToString
                        a(13) = where_to_charge1(process, charge_for_cash)

                    End If

                    a(14) = newdr.Item("location").ToString
                    a(15) = newdr.Item("wh_id").ToString
                    a(16) = newdr.Item("date_log").ToString
                    a(17) = newdr.Item("process").ToString

                    Dim lvl As New ListViewItem(a)
                    lvlrequisitionlist.Items.Add(lvl)

                    row += 1

                    If newdr.Item("trans").ToString = "cancel" Then
                        lvlrequisitionlist.Items(row - 1).BackColor = Color.Red
                    End If

                End While
            Else
                MessageBox.Show("Data doesn't exist...", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsq.connection.Close()
        End Try
    End Sub

    Public Function GET_ITEM_DESC(ByVal parse_wh_id As Integer)
        Try
            SQLcon.connection.Open()
            publicquery = "SELECT * FROM dbwarehouse_items WHERE wh_id = " & parse_wh_id
            cmd = New SqlCommand(publicquery, SQLcon.connection)
            sqldr = cmd.ExecuteReader
            While sqldr.Read
                GET_ITEM_DESC = sqldr.Item("whItem").ToString & " - " & sqldr.Item("whItemDesc").ToString
            End While
            sqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()

        End Try
    End Function
    Public Function GET_ITEM_DESC_FROM_TURNOVER_ITEM(ByVal parse_wh_id As Integer)
        Try
            SQLcon.connection.Open()
            publicquery = "SELECT * FROM dbwarehouse_items WHERE wh_id = " & parse_wh_id
            cmd = New SqlCommand(publicquery, SQLcon.connection)
            sqldr = cmd.ExecuteReader
            While sqldr.Read
                GET_ITEM_DESC_FROM_TURNOVER_ITEM = sqldr.Item("whItem").ToString & " - " & sqldr.Item("whItemDesc").ToString
            End While
            sqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()

        End Try
    End Function



    Public Function GET_ITEM_DESC_FROM_TURNOVER(ByVal mat_tools_id As Integer)
        Try
            SQLcon.connection.Open()
            publicquery = "SELECT * FROM dbMaterialTools_TurnOver WHERE type_of_material_id = " & mat_tools_id
            cmd = New SqlCommand(publicquery, SQLcon.connection)
            sqldr = cmd.ExecuteReader
            While sqldr.Read
                GET_ITEM_DESC_FROM_TURNOVER = FListOfItems.get_name_of_ItemName(sqldr.Item("type_of_material_id").ToString, sqldr.Item("bases").ToString)
            End While
            sqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()

        End Try
    End Function

    Public Function GET_ITEM_DESC_FROM_OTHERS(ByVal parse_wh_id As Integer)
        Try
            SQLcon.connection.Open()
            publicquery = "SELECT * FROM dbfacilities_tools WHERE fac_tools_id = " & parse_wh_id
            cmd = New SqlCommand(publicquery, SQLcon.connection)
            sqldr = cmd.ExecuteReader
            While sqldr.Read
                GET_ITEM_DESC_FROM_OTHERS = sqldr.Item("fac_tools_desc").ToString & " - " & sqldr.Item("specification").ToString
            End While
            sqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Function

    Public Function GET_ITEM_DESC_FROM_FACILITIES(ByVal parse_wh_id As Integer)
        Try
            SQLcon.connection.Open()
            publicquery = "SELECT * FROM dbfacilities_names WHERE fac_id = " & parse_wh_id
            cmd = New SqlCommand(publicquery, SQLcon.connection)
            sqldr = cmd.ExecuteReader
            While sqldr.Read
                GET_ITEM_DESC_FROM_FACILITIES = sqldr.Item("facility_name").ToString
            End While
            sqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Function

    Public Function GET_ITEM_DESC_FROM_PERSONAL_TOOLS(ByVal parse_wh_id As Integer)
        Try
            SQLcon.connection.Open()
            publicquery = "SELECT * FROM dbPersonal_tools WHERE p_tools_id = " & parse_wh_id
            cmd = New SqlCommand(publicquery, SQLcon.connection)
            sqldr = cmd.ExecuteReader
            While sqldr.Read
                GET_ITEM_DESC_FROM_PERSONAL_TOOLS = sqldr.Item("item_desc").ToString
            End While
            sqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Function

    Public Function CHARGE_TO(ByVal id As Integer, ByVal typeofreq As String, ByVal process As String) As String
        Try
            If typeofreq = "SUPPLY" And process = "IN" Or typeofreq = "SUPPLY" And process = "OTHERS" Then

                publicquery = "SELECT wh_area FROM dbwh_area WHERE wh_area_id = " & id
                CHARGE_TO = get_specific_column_value(publicquery, 0)

            ElseIf typeofreq = "SUPPLY" And process = "OUT" Then
                publicquery = "SELECT charge_to FROM dbCharge_to WHERE charge_to_id = " & id
                CHARGE_TO = get_specific_column_value(publicquery, 0)

            ElseIf typeofreq = "OTHERS" Then
                If process = "SHOPS" Or process = "PROJECT" Then
                    CHARGE_TO = GET_equip_desc_AND_proj_desc(id, 2)

                ElseIf process = "EQUIPMENT" Then
                    CHARGE_TO = GET_equip_desc_AND_proj_desc(id, 1)

                ElseIf process = "ADFIL" Then
                    CHARGE_TO = GET_equip_desc_AND_proj_desc(id, 3)

                ElseIf process = "WAREHOUSE" Then
                    CHARGE_TO = GET_equip_desc_AND_proj_desc(id, 4)

                ElseIf process = "PERSONAL" Then
                    publicquery = "SELECT charge_to FROM dbCharge_to WHERE charge_to_id = " & id
                    CHARGE_TO = get_specific_column_value(publicquery, 0)

                ElseIf process = "CASH" Then
                    publicquery = "SELECT charge_to FROM dbCharge_to WHERE charge_to_id = " & id
                    CHARGE_TO = get_specific_column_value(publicquery, 0)

                ElseIf process = "OTHERS" Then
                    publicquery = "SELECT charge_to FROM dbCharge_to WHERE charge_to_id = " & id
                    CHARGE_TO = get_specific_column_value(publicquery, 0)

                End If

            ElseIf typeofreq = "EQUIPMENT" And process = "OUT" Or typeofreq = "EQUIPMENT" And process = "OTHERS" Then

                Dim sqlcon As New SQLcon

                'sqlcon.set_sql("192.168.1.92", "eus_031916", "sa", "adfil")
                'sqlcon.sql_connect()
                Dim newdr As SqlDataReader
                Dim newcmd As SqlCommand

                sqlcon.connection1.Open()

                publicquery = "SELECT plate_no FROM dbequipment_list WHERE equipListID = " & id
                newcmd = New SqlCommand(publicquery, sqlcon.connection1)
                newdr = newcmd.ExecuteReader

                While newdr.Read
                    CHARGE_TO = newdr.Item("plate_no").ToString
                End While

                newdr.Close()
                sqlcon.connection1.Close()

            ElseIf typeofreq = "PROJECT" And process = "OUT" Or typeofreq = "PROJECT" And process = "OTHERS" Then
                Dim sqlcon As New SQLcon

                'sqlcon.set_sql("192.168.1.92", "eus_031916", "sa", "adfil")
                'sqlcon.sql_connect()
                Dim newdr As SqlDataReader
                Dim newcmd As SqlCommand

                sqlcon.connection1.Open()

                publicquery = "SELECT project_desc FROM dbprojectdesc WHERE proj_id = " & id
                newcmd = New SqlCommand(publicquery, sqlcon.connection1)
                newdr = newcmd.ExecuteReader

                While newdr.Read
                    CHARGE_TO = newdr.Item("project_desc").ToString
                End While

                newdr.Close()
                sqlcon.connection1.Close()

            End If

            If typeofreq = "OTHERS" And process = "OUT" Then
                publicquery = "SELECT charge_to FROM dbCharge_to WHERE charge_to_id = " & id
                CHARGE_TO = get_specific_column_value(publicquery, 0)
            End If


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

        Me.Close()
    End Sub

    Private Sub FRequistionForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        pboxHeader.Width = FMain.Width - FMain.ToolStrip1.Width

        With lvlrequisitionlist
            .Height = Me.Height - 135
            .Width = Me.Width - 30

            'gboxSearch.Location = New Point(lvlrequisitionlist.Location.X, lvlrequisitionlist.Bounds.Bottom)
            FlowLayoutPanel1.Location = New Point(lvlrequisitionlist.Location.X, lvlrequisitionlist.Bounds.Bottom + 10)

            'grpStatus.Width = lvlrequisitionlist.Width
        End With

        btnExit.Parent = pboxHeader
        btnExit.BringToFront()
        btnExit.Location = New Point(lvlrequisitionlist.Width + 1, 10)


        Button2.Location = New Point(100000, 10000)
        Button4.Location = New Point(100000, 10000)
        Button5.Location = New Point(100000, 10000)
        Button7.Location = New Point(100000, 10000)
        Button8.Location = New Point(100000, 10000)
        cmbProject.Location = New Point(100000, 10000)
        ListBox1.Location = New Point(100000, 10000)


    End Sub
    Public Sub form_resize()
        pboxHeader.Width = FMain.Width - FMain.ToolStrip1.Width

        With lvlrequisitionlist
            .Height = Me.Height - 135
            .Width = Me.Width - 30

            gboxSearch.Location = New Point(lvlrequisitionlist.Location.X, lvlrequisitionlist.Bounds.Bottom)

            'grpStatus.Width = lvlrequisitionlist.Width
        End With

        btnExit.Parent = pboxHeader
        btnExit.BringToFront()
        btnExit.Location = New Point(lvlrequisitionlist.Width + 1, 10)

    End Sub

    Private Sub CreartePurchaseOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreartePurchaseOrderToolStripMenuItem.Click
        withdrawal_stat1 = "PO"

        for_print_po = True
        FPOFORM.btnSave.Text = "Save"

        'If MessageBox.Show("Do you want to proceed to receiving without PO?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

        '    'FReceiving_Info.ShowDialog()

        '    FReceiving_Info.load_suppliers_list(FReceiving_Info.cmbSupplier)

        '    Dim po_no As String = lvlrequisitionlist.SelectedItems(0).SubItems(10).Text
        '    Dim dr_no As String = lvlrequisitionlist.SelectedItems(0).SubItems(21).Text

        '    If po_no = "PO RELEASED" And dr_no = "PENDING" Then
        '        MessageBox.Show("Create Delivery Receipt first before receiving...", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Return
        '    End If

        '    If po_no = "N/A" And lvlrequisitionlist.SelectedItems(0).SubItems(11).Text = "N/A" And lvlrequisitionlist.SelectedItems(0).SubItems(12).Text = "N/A" Then
        '        MessageBox.Show("NOT APPLICABLE", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Return
        '    End If

        '    'receiving_n = 1
        '    If lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "IN" And lvlrequisitionlist.SelectedItems(0).SubItems(10).Text = "PO RELEASED" Then
        '        show_receiving_form()
        '    ElseIf lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "FACILITIES" Or lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "TOOLS" Or lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "ADD-ON" Then
        '        show_receiving_form()
        '    ElseIf lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "OTHERS" Or lvlrequisitionlist.SelectedItems(0).SubItems(11).Text = "PENDING" Then
        '        'show_receiving_form_OTHERS()
        '        show_receiving_form()
        '    ElseIf lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "IN" And lvlrequisitionlist.SelectedItems(0).SubItems(11).Text = "CV RELEASED" Then
        '        show_receiving_form()
        '    Else
        '        MessageBox.Show("PO SHOULD RELEASE FIRST", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End If

        '    FReceiving_Info.ShowDialog()
        'Else
        '    ' FPOFORM.load_po_items("SAVE")
        '    Dim inout As String = lvlrequisitionlist.SelectedItems(0).SubItems(9).Text
        '    show_po_cv_ws(inout)
        'End If


        If lvlrequisitionlist.SelectedItems(0).SubItems(18).Text = "CASH" Then
            MessageBox.Show("This function is not intended for PO..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        Dim inout As String = lvlrequisitionlist.SelectedItems(0).SubItems(9).Text

        If cmbDivision.Text = "WAREHOUSING AND SUPPLY" Then
            show_po_cv_ws(inout)

        ElseIf cmbDivision.Text = "CRUSHING AND HAULING" Then
            Dim sortPO As New List(Of class_exclusive_aggregates.podata)
            sortPO = cAggregates.LISTOFPO
            Dim rs_id As Integer = lvlrequisitionlist.SelectedItems(0).Text
            Dim rs_qty As Double = lvlrequisitionlist.SelectedItems(0).SubItems(5).Text
            Dim count_poqty As Double

            For Each p In sortPO
                If p.rs_id = rs_id Then
                    count_poqty += p.qty
                End If
            Next

            If rs_qty = count_poqty Then
                MessageBox.Show("All po qty has been released!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            show_po_cv_ws(inout)

        End If


        'MsgBox(count_poqty)

    End Sub

    Public Sub show_po_cv_ws(ByVal inout As String)
        'If lvlrequisitionlist.SelectedItems(0).SubItems(10).Text = "N/A" And lvlrequisitionlist.SelectedItems(0).SubItems(11).Text = "N/A" And lvlrequisitionlist.SelectedItems(0).SubItems(12).Text = "N/A" Then
        '    MessageBox.Show("NOT APPLICABLE", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return
        'End If

#Region "FOR WAREHOUSING WITHDRAWAL"
        Try
            Dim wh_id2 As Integer = CInt(lvlrequisitionlist.SelectedItems(0).SubItems(15).Text)
            'check for warehousing or hauling
            Dim whId As Integer = lvlrequisitionlist.SelectedItems(0).SubItems(15).Text
            Dim whItems As New List(Of PropsFields.whItems_props_fields)

            whItems = Results.cResult.Where(Function(x) x.wh_id = wh_id2).ToList()

            If whItems(0).division = cDivision.WAREHOUSING_AND_SUPPLY And inout = cInOut._OUT Then

                Dim rsQty As Double = lvlrequisitionlist.SelectedItems(0).SubItems(5).Text
                Dim QtyWithdrawn_released As Double = countWithdrawnItems(lvlrequisitionlist.SelectedItems(0).Text)

                With FCreateWithdrawalSlip

                    Dim whLocation = Results.cResult.Where(Function(x) x.wh_id = whId).ToList()

                    .wsNew.rs_id = lvlrequisitionlist.SelectedItems(0).Text
                    .wsNew.charges = lvlrequisitionlist.SelectedItems(0).SubItems(13).Text
                    .wsNew.rs_no = lvlrequisitionlist.SelectedItems(0).SubItems(1).Text
                    .wsNew.units = lvlrequisitionlist.SelectedItems(0).SubItems(6).Text
                    .wsNew.whLocation = IIf(whLocation.Count > 0, whLocation(0).warehouse_area, "")
                    .wsNew.wh_id = whId
                    .wsNew.rsQty_remaining = rsQty - QtyWithdrawn_released

                    .lblRsQty.Text = rsQty
                    .lblReleased.Text = QtyWithdrawn_released
                    .lblBalance.Text = rsQty - QtyWithdrawn_released

                    If (rsQty - QtyWithdrawn_released) <= 0 Then
                        .Label5.Visible = True
                    Else
                        .Label5.Visible = False
                    End If

                    .saveStatus = SaveBtn.Save

                End With

                FCreateWithdrawalSlip.ShowDialog()

                Exit Sub
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
            Exit Sub
        End Try



#End Region

        po_edit = 0
        'FPurchaseOrder.lblReqType.Text = lvlrequisitionlist.SelectedItems(0).SubItems(8).Text

        FPurchaseOrder.lblInOut.Text = lvlrequisitionlist.SelectedItems(0).SubItems(9).Text

        'FPurchaseOrder.txtRsNo.Text = lvlrequisitionlist.SelectedItems(0).SubItems(1).Text


        Dim rs_no As String = lvlrequisitionlist.SelectedItems(0).SubItems(1).Text

        'Dim exist_rs_no As String = check_if_exist("dbPO", "rs_no", rs_no, 0)
        'If exist_rs_no > 0 Then
        '    load_po_info_if_exist(rs_no)
        'Else

        If lvlrequisitionlist.SelectedItems(0).SubItems(18).Text = "DR" Then
            MessageBox.Show("This function is not intended for PO..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        Dim get_rs_id As Integer = lvlrequisitionlist.SelectedItems(0).Text
        Dim rs_qty1 As Double = lvlrequisitionlist.SelectedItems(0).SubItems(5).Text

        Dim po_ws_qty As Double
        For Each row As ListViewItem In lvlrequisitionlist.Items
            If row.BackColor = Color.LightGreen Then
                If get_rs_id = row.Text Then
                    po_ws_qty += row.SubItems(22).Text
                End If
            End If
        Next

        'MsgBox(po_ws_qty)

        If rs_qty1 = 0 Then
            If MessageBox.Show("RS QTY is zero(0), do you still want to continue?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                'continue
            Else
                Exit Sub
            End If
        ElseIf po_ws_qty = rs_qty1 Then
            MessageBox.Show("PO RELEASED...", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If



        GET_REQUISITION_SLIP_DATA1(lvlrequisitionlist.SelectedItems(0).Text)
        'End If

        Dim type_of_purchasing As String = lvlrequisitionlist.SelectedItems(0).SubItems(18).Text
        Dim rs_qty As Integer

        If type_of_purchasing = "DR" Then
        Else
            rs_qty = CInt(lvlrequisitionlist.SelectedItems(0).SubItems(5).Text)
        End If

        form_active("FPOFORM")

        Dim wh_id As Integer = CInt(lvlrequisitionlist.SelectedItems(0).SubItems(15).Text)

        With FPOFORM

            .cmbdr_option.Text = "WITHOUT DR"

            Select Case inout
                Case "IN", "OTHERS"
                    If type_of_purchasing = "PURCHASE ORDER" Then
                        load_unreleased_po(rs_no, 1, wh_id)
                        .show_supplier_list()

                        .Label10.Text = "Prepared by:"
                        .Label9.Text = "Checked by:"
                        .Label12.Text = "Approved by:"

                        .txtApproved_by.Enabled = True
                        .txtChecked_by.Enabled = True
                        .txtInstructions.Enabled = True
                        .txtPrepared_by.Enabled = True
                        .dgvPOList.Columns("Column1").Visible = True

                        .Label10.Visible = True
                        .txtPrepared_by.Visible = True
                        .Label6.Visible = True
                        .Label11.Visible = True
                        .DTPdateneeded.Visible = True

                        .txtChecked_by.Text = ""
                        .txtApproved_by.Text = ""

                        .txtChecked_by.Text = "Cupay, Mercy Fe G."
                        .txtApproved_by.Text = "Gorme, Joseph Q."


                    ElseIf type_of_purchasing = "CASH" Then
                        load_unreleased_po(rs_no, 3, wh_id)
                        .show_supplier_list()

                        .Label10.Text = "Prepared by:"
                        .Label9.Text = "Checked by:"
                        .Label12.Text = "Approved by:"
                        .Label15.Text = "CASH VOUCHER"

                        .txtApproved_by.Text = "N/A"
                        .txtChecked_by.Text = "N/A"
                        .txtInstructions.Text = "N/A"
                        .txtPrepared_by.Text = "N/A"

                        .txtInstructions.ReadOnly = False
                        .txtApproved_by.Enabled = False
                        .txtChecked_by.Enabled = False
                        .txtInstructions.Enabled = False
                        .txtPrepared_by.Enabled = False
                        .dgvPOList.Columns("Column1").Visible = True

                        .Label10.Visible = True
                        .txtPrepared_by.Visible = True
                        .Label6.Visible = True
                        .txtInstructions.Visible = True
                        .Label11.Visible = True
                        .DTPdateneeded.Visible = True

                        .txtChecked_by.Text = ""
                        .txtApproved_by.Text = ""


                    ElseIf type_of_purchasing = "DR" Then
                        '.dtpTime.Location = New Point(.DTPdateneeded.Bounds.Left, .DTPdateneeded.Bounds.Top)
                        '.DTPdateneeded.Visible = False
                        '.show_quary_source()
                        .dgvPOList.Columns("Column1").Visible = False

                    End If

                Case "OUT"
                    '10,9,12
                    If cmbDivision.Text = "WAREHOUSING AND SUPPLY" Then
                        load_unreleased_ws1(rs_no)
                    Else
                        load_unreleased_ws2(lvlrequisitionlist.SelectedItems(0).Text)
                    End If

                    'load_unreleased_po(rs_no, 2, wh_id)
                    .show_warehouse_list()

                    .Label10.Text = "Withdraw From:"
                    .Label9.Text = "Withdraw by:"
                    .Label12.Text = "Released by:"
                    .Label15.Text = "WITHDRAWAL"
                    .txtInstructions.ReadOnly = True
                    .txtApproved_by.Enabled = True
                    .txtChecked_by.Enabled = True
                    .txtInstructions.Enabled = True
                    .txtPrepared_by.Enabled = True
                    .dgvPOList.Columns("Column1").Visible = True
                    .txtChargeTo.Text = ""
                    .txtPrepared_by.Text = ""
                    .txtChecked_by.Text = ""
                    .txtApproved_by.Text = ""

                    .Label10.Visible = False
                    .txtPrepared_by.Visible = False
                    .Label6.Visible = False
                    .txtInstructions.Visible = False
                    .Label11.Visible = False
                    .DTPdateneeded.Visible = False

                    .Label7.Text = lvlrequisitionlist.SelectedItems(0).SubItems(31).Text




            End Select

            .lbox_List.Visible = False
            .Show()
        End With
    End Sub

    Private Function countWithdrawnItems(rs_id As Integer) As Double
        For Each row As ListViewItem In lvlrequisitionlist.Items
            If row.Text = rs_id.ToString And row.BackColor = Color.LightGreen Then
                If row.SubItems(22).Text = "" Or row.SubItems(22).Text = "-" Then
                Else
                    countWithdrawnItems += row.SubItems(22).Text
                End If


            End If
        Next
    End Function
    Public Sub load_unreleased_ws1(rs_no As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_po_query_new1", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@rs_no", rs_no)
            newCMD.Parameters.AddWithValue("@typeofpurchasing", "WITHDRAWAL")
            newCMD.Parameters.AddWithValue("@n", 3)

            newCMD.CommandTimeout = 300

            newDR = newCMD.ExecuteReader
            Dim a(20) As String

            While newDR.Read
                'If newDR.Item("po_det_id").ToString <> "" Then
                '    If CDec(newDR.Item("qty").ToString) > CDec(newDR.Item("ws_qty").ToString) Then
                '        'padayon ang withdraw
                '    Else
                '        'it means na withdraw na tanan
                '        GoTo proceedhere
                '    End If

                'End If

                If (CDec(newDR.Item("qty").ToString) - CDec(newDR.Item("ws_qty").ToString)) = 0 Then
                    GoTo proceedhere
                End If

                a(1) = get_wh_area(newDR.Item("wh_id").ToString)
                a(2) = newDR.Item("wh_id").ToString
                a(3) = newDR.Item("ITEM_NAME").ToString
                a(5) = 0
                a(4) = newDR.Item("ITEM_DESC").ToString
                a(6) = "N/A"
                a(7) = CDec(newDR.Item("qty").ToString) - CDec(newDR.Item("ws_qty").ToString)
                a(8) = newDR.Item("unit").ToString
                a(9) = "0.00"
                a(10) = "0.00"
                a(11) = 0
                a(12) = newDR.Item("rs_id").ToString
                a(13) = 0
                a(14) = newDR.Item("IN_OUT").ToString
                a(15) = newDR.Item("type_of_purchasing").ToString

                FPOFORM.dgvPOList.Rows.Add(a)

proceedhere:

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Sub

    Public Sub load_unreleased_ws2(rs_id As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_po_query_new1", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.Parameters.AddWithValue("@typeofpurchasing", "WITHDRAWAL")
            newCMD.Parameters.AddWithValue("@n", 4)

            newCMD.CommandTimeout = 300

            newDR = newCMD.ExecuteReader
            Dim a(20) As String

            While newDR.Read
                'If newDR.Item("po_det_id").ToString <> "" Then
                '    If CDec(newDR.Item("qty").ToString) > CDec(newDR.Item("ws_qty").ToString) Then
                '        'padayon ang withdraw
                '    Else
                '        'it means na withdraw na tanan
                '        GoTo proceedhere
                '    End If

                'End If

                If (CDec(newDR.Item("qty").ToString) - CDec(newDR.Item("ws_qty").ToString)) = 0 Then
                    GoTo proceedhere
                End If

                a(1) = get_wh_area(newDR.Item("wh_id").ToString)
                a(2) = newDR.Item("wh_id").ToString
                a(3) = newDR.Item("ITEM_NAME").ToString
                a(5) = 0
                a(4) = newDR.Item("ITEM_DESC").ToString
                a(6) = "N/A"
                a(7) = CDec(newDR.Item("qty").ToString) - CDec(newDR.Item("ws_qty").ToString)
                a(8) = newDR.Item("unit").ToString
                a(9) = "0.00"
                a(10) = "0.00"
                a(11) = 0
                a(12) = newDR.Item("rs_id").ToString
                a(13) = 0
                a(14) = newDR.Item("IN_OUT").ToString
                a(15) = newDR.Item("type_of_purchasing").ToString

                FPOFORM.dgvPOList.Rows.Add(a)

proceedhere:

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Sub
    Public Sub load_unreleased_po(ByVal rs_no As String, ByVal n As Integer, wh_id As Integer)
        FPOFORM.dgvPOList.Rows.Clear()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_po_query_new1", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            'If n = 1 Then
            '    newCMD.Parameters.AddWithValue("@n", 112)
            '    newCMD.Parameters.AddWithValue("@control", "SAVE")
            '    newCMD.Parameters.AddWithValue("@rs_no", rs_no)
            'ElseIf n = 2 Then
            '    newCMD.Parameters.AddWithValue("@n", 9) '111
            '    newCMD.Parameters.AddWithValue("@control", "SAVE")
            '    newCMD.Parameters.AddWithValue("@rs_no", rs_no)
            '    newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            'ElseIf n = 3 Then
            '    newCMD.Parameters.AddWithValue("@n", 113)
            '    newCMD.Parameters.AddWithValue("@control", "SAVE")
            '    newCMD.Parameters.AddWithValue("@rs_no", rs_no)
            'End If

            newCMD.Parameters.AddWithValue("@rs_no", rs_no)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            'newCMD.Parameters.AddWithValue("@control", "SAVE")

            If n = 1 Then
                newCMD.Parameters.AddWithValue("@typeofpurchasing", "PURCHASE ORDER")
                newCMD.Parameters.AddWithValue("@n", 2)
            ElseIf n = 2 Then
                If cmbDivision.Text = "CRUSHING AND HAULING" Then
                    newCMD.Parameters.AddWithValue("@n", 1)
                Else
                    newCMD.Parameters.AddWithValue("@n", 2)
                    'newCMD.Parameters.AddWithValue("@n", 3)
                End If
                newCMD.Parameters.AddWithValue("@typeofpurchasing", "WITHDRAWAL")

            ElseIf n = 3 Then
                newCMD.Parameters.AddWithValue("@typeofpurchasing", "CASH")
                newCMD.Parameters.AddWithValue("@n", 2) : End If

            Dim a(20) As String

            newDR = newCMD.ExecuteReader
            While newDR.Read

                Dim po_qty As Decimal = get_po_qty(CInt(newDR.Item("rs_id").ToString))
                Dim type_of_purchasing As String = newDR.Item("type_of_purchasing").ToString


                If type_of_purchasing = "WITHDRAWAL" Then
                    a(1) = get_wh_area(newDR.Item("wh_id").ToString)
                Else

                End If

                a(2) = newDR.Item("wh_id").ToString
                a(3) = newDR.Item("ITEM_NAME").ToString
                a(5) = 0

                If type_of_purchasing = "DR" Then
                    a(4) = get_aggregate_source(CInt(newDR.Item("rs_id").ToString))
                    a(6) = ""
                    a(7) = CDec(newDR.Item("qty").ToString) - po_qty

                ElseIf type_of_purchasing = "WITHDRAWAL" Then
                    'a(4) = get_aggregate_source(CInt(newDR.Item("rs_id").ToString))
                    a(4) = newDR.Item("ITEM_DESC").ToString
                    a(6) = "N/A"
                    'a(7) = CDec(newDR.Item("qty").ToString) - po_qty

                    If cmbSearchByCategory.Text = "CRUSHING AND HAULING" Then
                        a(7) = CDec(lvlrequisitionlist.SelectedItems(0).SubItems(5).Text) - total_ws_qty
                    Else
                        a(7) = newDR.Item("qty").ToString
                    End If

                Else
                    ' SA A(4) NI& " (" & newDR.Item("ITEM_NAME").ToString & "-" & newDR.Item("ITEM_DESC").ToString & ")"
                    'a(4) = newDR.Item("rs_item_desc").ToString MAO NI ANG ORIGINAL
                    a(4) = newDR.Item("ITEM_NAME").ToString & "-" & newDR.Item("ITEM_DESC").ToString
                    a(5) = FMain.increment_po
                    a(6) = "60 days"
                    a(7) = CDec(newDR.Item("qty").ToString) - po_qty
                End If

                a(8) = newDR.Item("unit").ToString
                a(9) = "0.00"
                a(10) = "0.00"
                a(11) = 0
                a(12) = newDR.Item("rs_id").ToString
                a(13) = 0
                a(14) = newDR.Item("IN_OUT").ToString
                a(15) = type_of_purchasing
                a(16) = newDR.Item("charges").ToString
                FPOFORM.DTPdateneeded.Text = newDR.Item("date_needed").ToString

                'If newDR.Item("process").ToString = "ADFIL" Then
                '    a(16) = multiplecharges(CInt(newDR.Item("rs_id").ToString), 1)
                '    FPOFORM.txtChargeTo.Text = multiplecharges(CInt(newDR.Item("rs_id").ToString), 1)
                'ElseIf newDR.Item("process").ToString = "OUTSOURCE" Then
                '    a(16) = multiplecharges(CInt(newDR.Item("rs_id").ToString), 2)
                'End If
                'FPOFORM.DTPdateneeded.Text = lvlrequisitionlist.Columns(4).Text

                If CDec(a(7)) = 0 Then
                    If type_of_purchasing = "DR" Then
                    Else
                        GoTo proceedhere
                    End If

                End If

                FPOFORM.dgvPOList.Rows.Add(a)

proceedhere:
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Public Function get_wh_area(ByVal id As Integer) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT * FROM dbwarehouse_items a "
            query &= "INNER JOIN dbwh_area b "
            query &= "ON a.whArea = b.wh_area_id "
            query &= "WHERE a.wh_id = '" & id & "'"

            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                '  Column1.Items.Add(newDR.Item(0).ToString)
                get_wh_area = newDR.Item("wh_area").ToString
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function


    Public Function get_equipment_name(ByVal id As Integer) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection1.Open()
            Dim query As String = "SELECT a.equipListID,a.plate_no,b.equip_typeOf FROM dbequipment_list a "
            query &= "INNER JOIN dbequipment_type b "
            query &= "ON a.equipTypeID = b.equipTypeID "
            query &= "WHERE a.equipListID = " & id

            newCMD = New SqlCommand(query, newSQ.connection1)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_equipment_name = newDR.Item("plate_no").ToString
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection1.Close()
        End Try

    End Function
    Public Function get_aggregate_source(ByVal rs_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("po_query_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 7)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                If newDR.Item("source").ToString = "WAREHOUSE" Then
                    get_aggregate_source = get_warehouse_quarry_name(1, CInt(newDR.Item("quarry_id").ToString))
                ElseIf newDR.Item("source").ToString = "QUARRY" Then
                    get_aggregate_source = get_warehouse_quarry_name(2, CInt(newDR.Item("quarry_id").ToString))
                ElseIf newDR.Item("source").ToString = "EQUIPMENT" Then
                    get_aggregate_source = get_equipment_name(CInt(newDR.Item("quarry_id").ToString))
                End If

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Function get_warehouse_quarry_name(ByVal n As Integer, ByVal id As Integer) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("po_query_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            If n = 1 Then
                newCMD.Parameters.AddWithValue("@n", 9)
            ElseIf n = 2 Then
                newCMD.Parameters.AddWithValue("@n", 8)
            End If

            newCMD.Parameters.AddWithValue("@id", id)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_warehouse_quarry_name = newDR.Item(0).ToString
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Function get_po_qty(ByVal rs_id As Integer) As Double
        Dim newcmd As SqlCommand
        Dim newdr As SqlDataReader
        Dim newSQ As New SQLcon

        Try
            newSQ.connection.Open()

            Dim query As String = "SELECT qty FROM dbPO_details WHERE rs_id = " & rs_id
            newcmd = New SqlCommand(query, newSQ.connection)

            newdr = newcmd.ExecuteReader
            While newdr.Read
                get_po_qty += CDec(newdr.Item("qty").ToString)
            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

            newSQ.connection.Close()
            GC.Collect()
        End Try
    End Function
    Private Sub CreateReceivingReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateReceivingReportToolStripMenuItem.Click

        'filter message for cancelled PO
        Dim cancelledPO As String = lvlrequisitionlist.SelectedItems(0).SubItems(10).Text

        If cancelledPO.ToUpper() = "Cancelled PO".ToUpper() Then
            MessageBox.Show("Unable to create receiving, this PO transaction has been already cancelled...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If cmbDivision.Text = "CRUSHING AND HAULING" Then
            '<==NEW CODE MAY 2023 | KING
            create_po_hauling_and_crushing() '==>

        Else
            get_all_podetails()
            button_click_name = "CreateReceivingReportToolStripMenuItem"

            'FReceiving_Info.ShowDialog()
            Dim type_of_purchasing As String = lvlrequisitionlist.SelectedItems(0).SubItems(18).Text
            Dim inout As String = lvlrequisitionlist.SelectedItems(0).SubItems(9).Text
            Dim wh_id As Integer = Utilities.ifBlankReplaceToZero(lvlrequisitionlist.SelectedItems(0).SubItems(15).Text)

            Dim get_po_det_id As Integer
            Dim po_ws_qty As Double

            ''<== FOR HAULING AND CRUSHING FILTER
            'With lvlrequisitionlist.SelectedItems(0)
            '    Select Case cmbDivision.Text
            '        Case "CRUSHING AND HAULING"
            '            Select Case .BackColor
            '                Case Color.DarkGreen 'DARKGREEN
            '                    If type_of_purchasing = "CASH WITH RR" Then
            '                        Dim rt As New Class_RR
            '                        Dim rs_qty As Decimal = .SubItems(5).Text

            '                        If rs_qty = rt.total_received(.Text, lvlrequisitionlist) Then
            '                            MessageBox.Show("Can't proceed to RR FORM, RR qty has been totally received...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                            Exit Sub
            '                        End If
            '                    End If

            '                Case Color.LightGreen 'LIGHTGREEN
            '                    If type_of_purchasing = "PURCHASE ORDER" Then
            '                        Dim rt As New Class_RR
            '                        Dim po_qty As Decimal = .SubItems(22).Text

            '                        If po_qty = rt.total_received_po(.SubItems(35).Text, lvlrequisitionlist) Then
            '                            MessageBox.Show("Can't proceed to RR FORM, RR qty has been totally received...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                            Exit Sub
            '                        End If
            '                    End If
            '            End Select
            '    End Select
            'End With
            ''==>

            If type_of_purchasing = "CASH WITH RR" Then

                If inout = "IN" And wh_id <> 0 Then
                    'if set na og in tpos na item check na, proceed
                    GoTo proceedhere
                End If

                If MessageBox.Show("NOTE:" & vbCrLf & vbCrLf & "before you proceed to receiving form," & vbCrLf & "please let me know if the transaction is for IN (for stock-card purpose)?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    'if yes stop here
                    cash_with_rr_checking("INForCashRR")
                    Exit Sub
                Else
                    'if no, proceed 


                    'if hauling and crushing nya CASH WITH RR
                    If cmbDivision.Text = "CRUSHING AND HAULING" Then
                        If wh_id > 0 Then

                        Else
                            'cash_with_rr_checking("OTHERSForCashRR")
                            'Exit Sub
                        End If
                    End If

                End If

proceedhere:

                get_po_det_id = IIf(Not IsNumeric(lvlrequisitionlist.SelectedItems(0).SubItems(35).Text), 0, lvlrequisitionlist.SelectedItems(0).Text) 'rs_id ang ihatag
                po_ws_qty = IIf(lvlrequisitionlist.SelectedItems(0).SubItems(5).Text = "", 0, lvlrequisitionlist.SelectedItems(0).SubItems(5).Text)

            ElseIf type_of_purchasing = "DR" Then

            Else
                get_po_det_id = IIf(lvlrequisitionlist.SelectedItems(0).SubItems(35).Text = "", 0, lvlrequisitionlist.SelectedItems(0).SubItems(35).Text)
                po_ws_qty = IIf(lvlrequisitionlist.SelectedItems(0).SubItems(22).Text = "", 0, lvlrequisitionlist.SelectedItems(0).SubItems(22).Text)
            End If

            Dim rr_qty As Double
            For Each row As ListViewItem In lvlrequisitionlist.Items
                If row.BackColor = Color.LightYellow Then
                    If get_po_det_id = IIf(row.SubItems(35).Text = "", 0, row.SubItems(35).Text) Then
                        rr_qty += IIf(row.SubItems(23).Text = "", 0, row.SubItems(23).Text)
                    End If
                End If
            Next

            If rr_qty = po_ws_qty Then
                MessageBox.Show("RR TOTALLY RECEIVED...", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If lvlrequisitionlist.SelectedItems(0).SubItems(18).Text = "CASH WITH RR" Then
                show_receiving_for_cash_with_rr()
                Exit Sub
            Else
                'continue...
            End If


            FReceiving_Info.load_suppliers_list(FReceiving_Info.cmbSupplier)

            Dim po_no As String = lvlrequisitionlist.SelectedItems(0).SubItems(10).Text
            Dim dr_no As String = lvlrequisitionlist.SelectedItems(0).SubItems(21).Text

            If po_no = "PO RELEASED" And dr_no = "PENDING" Then
                MessageBox.Show("Create Delivery Receipt first before receiving...", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If po_no = "N/A" And lvlrequisitionlist.SelectedItems(0).SubItems(11).Text = "N/A" And lvlrequisitionlist.SelectedItems(0).SubItems(12).Text = "N/A" Then
                MessageBox.Show("NOT APPLICABLE", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            'receiving_n = 1
            If lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "IN" And lvlrequisitionlist.SelectedItems(0).SubItems(10).Text = "released" Then
                show_receiving_form()
            ElseIf lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "FACILITIES" Or lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "TOOLS" Or lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "ADD-ON" Then
                show_receiving_form()
            ElseIf lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "OTHERS" Or lvlrequisitionlist.SelectedItems(0).SubItems(11).Text = "PENDING" Then
                'show_receiving_form_OTHERS()
                show_receiving_form()
            ElseIf lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "IN" And lvlrequisitionlist.SelectedItems(0).SubItems(11).Text = "CV RELEASED" Then
                show_receiving_form()
            Else
                MessageBox.Show("PO SHOULD RELEASE FIRST", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

    End Sub

    Private Sub create_po_hauling_and_crushing()

        get_all_podetails()
        button_click_name = "CreateReceivingReportToolStripMenuItem"

        'FReceiving_Info.ShowDialog()
        Dim type_of_purchasing As String = lvlrequisitionlist.SelectedItems(0).SubItems(18).Text
        Dim inout As String = lvlrequisitionlist.SelectedItems(0).SubItems(9).Text
        Dim wh_id As Integer = lvlrequisitionlist.SelectedItems(0).SubItems(15).Text

        Dim get_po_det_id As Integer
        Dim po_ws_qty As Double

        '<== FOR HAULING AND CRUSHING FILTER
        Dim sortRR As New List(Of class_exclusive_aggregates.rrdata)
        sortRR = cAggregates.LISTOFRR
        Dim po_det_id As Integer = lvlrequisitionlist.SelectedItems(0).SubItems(35).Text
        Dim po_qty1 As Integer = lvlrequisitionlist.SelectedItems(0).SubItems(22).Text

        Dim count_poqty As Double

        For Each p In sortRR
            If p.po_det_id = po_det_id Then
                count_poqty += p.qty
            End If
        Next

        If po_qty1 = count_poqty Then
            MessageBox.Show("All po qty has been received!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If '==>


        If type_of_purchasing = "CASH WITH RR" Then

            If inout = "IN" And wh_id <> 0 Then
                'if set na og in tpos na item check na, proceed
                GoTo proceedhere
            End If

            If MessageBox.Show("NOTE:" & vbCrLf & vbCrLf & "before you proceed to receiving form," & vbCrLf & "please let me know if the transaction is for IN (for stock-card purpose)?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                'if yes stop here
                cash_with_rr_checking("INForCashRR")
                Exit Sub
            Else
                'if no, proceed 


                'if hauling and crushing nya CASH WITH RR
                If cmbDivision.Text = "CRUSHING AND HAULING" Then
                    If wh_id > 0 Then

                    Else
                        'cash_with_rr_checking("OTHERSForCashRR")
                        'Exit Sub
                    End If
                End If

            End If

proceedhere:

            get_po_det_id = IIf(Not IsNumeric(lvlrequisitionlist.SelectedItems(0).SubItems(35).Text), 0, lvlrequisitionlist.SelectedItems(0).Text) 'rs_id ang ihatag
            po_ws_qty = IIf(lvlrequisitionlist.SelectedItems(0).SubItems(5).Text = "", 0, lvlrequisitionlist.SelectedItems(0).SubItems(5).Text)

        ElseIf type_of_purchasing = "DR" Then

        Else
            get_po_det_id = IIf(lvlrequisitionlist.SelectedItems(0).SubItems(35).Text = "", 0, lvlrequisitionlist.SelectedItems(0).SubItems(35).Text)
            po_ws_qty = IIf(lvlrequisitionlist.SelectedItems(0).SubItems(22).Text = "", 0, lvlrequisitionlist.SelectedItems(0).SubItems(22).Text)
        End If

        Dim rr_qty As Double
        For Each row As ListViewItem In lvlrequisitionlist.Items
            If row.BackColor = Color.LightYellow Then
                If get_po_det_id = IIf(row.SubItems(35).Text = "", 0, row.SubItems(35).Text) Then
                    rr_qty += IIf(row.SubItems(23).Text = "", 0, row.SubItems(23).Text)
                End If
            End If
        Next

        If rr_qty = po_ws_qty Then
            MessageBox.Show("RR TOTALLY RECEIVED...", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If lvlrequisitionlist.SelectedItems(0).SubItems(18).Text = "CASH WITH RR" Then
            show_receiving_for_cash_with_rr()
            Exit Sub
        Else
            'continue...
        End If


        FReceiving_Info.load_suppliers_list(FReceiving_Info.cmbSupplier)

        Dim po_no As String = lvlrequisitionlist.SelectedItems(0).SubItems(10).Text
        Dim dr_no As String = lvlrequisitionlist.SelectedItems(0).SubItems(21).Text

        If po_no = "PO RELEASED" And dr_no = "PENDING" Then
            MessageBox.Show("Create Delivery Receipt first before receiving...", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If po_no = "N/A" And lvlrequisitionlist.SelectedItems(0).SubItems(11).Text = "N/A" And lvlrequisitionlist.SelectedItems(0).SubItems(12).Text = "N/A" Then
            MessageBox.Show("NOT APPLICABLE", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'receiving_n = 1
        If lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "IN" And lvlrequisitionlist.SelectedItems(0).SubItems(10).Text = "released" Then
            show_receiving_form()
        ElseIf lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "FACILITIES" Or lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "TOOLS" Or lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "ADD-ON" Then
            show_receiving_form()
        ElseIf lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "OTHERS" Or lvlrequisitionlist.SelectedItems(0).SubItems(11).Text = "PENDING" Then
            'show_receiving_form_OTHERS()
            show_receiving_form()
        ElseIf lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "IN" And lvlrequisitionlist.SelectedItems(0).SubItems(11).Text = "CV RELEASED" Then
            show_receiving_form()
        Else
            MessageBox.Show("PO SHOULD RELEASE FIRST", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


    End Sub
    Private Sub cash_with_rr_checking(btn_click As String)
        button_click_name = btn_click

        With FWarehouse_FacilitiesTools_Checking.cmb_select_typeof_checking
            With FWarehouse_FacilitiesTools_Checking.cmb_select_typeof_checking
                .Items.Clear()
                .Items.Add("Facilities/Tools Checking")
                .Items.Add("Items Checking")
                .Items.Add("Items Set")

                .SelectedIndex = 1
                FWarehouse_FacilitiesTools_Checking.ShowDialog()

            End With
        End With

    End Sub
    Private Sub show_receiving_for_cash_with_rr()
        With FReceiving_Info

            .txtRSNo.Text = lvlrequisitionlist.SelectedItems(0).SubItems(1).Text
            .load_suppliers_list(.cmbSupplier)
            .ShowDialog()
        End With

    End Sub
    Public Sub show_receiving_form()
        If lvlrequisitionlist.SelectedItems(0).SubItems(10).Text = "PENDING" Or lvlrequisitionlist.SelectedItems(0).SubItems(10).Text = "PO PENDING" Then
            MessageBox.Show("No Purchase Order", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf lvlrequisitionlist.SelectedItems(0).SubItems(10).Text = "PURCHASED" Then
            MessageBox.Show("Already Purchased", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            public_rs_id = lvlrequisitionlist.SelectedItems(0).Text
            po_no = get_PO_NO(lvlrequisitionlist.SelectedItems(0).Text)
            'rs_no = get_RS_NO_OTHERS(lvlrequisitionlist.SelectedItems(0).SubItems(1).Text)
            rs_no = lvlrequisitionlist.SelectedItems(0).SubItems(1).Text

            receiving_inout = lvlrequisitionlist.SelectedItems(0).SubItems(9).Text
            type_purchasing = lvlrequisitionlist.SelectedItems(0).SubItems(18).Text

            FReceiving_Info.txtPOno.Text = po_no
            get_multiple_po_no(public_rs_id)
            FReceiving_Info.txtRSNo.Text = lvlrequisitionlist.SelectedItems(0).SubItems(1).Text
            rs_id = CInt(lvlrequisitionlist.SelectedItems(0).Text)

            'FReceivingReport.ShowDialog()
            FReceiving_Info.ShowDialog()
        End If
    End Sub

    Public Sub show_receiving_form_OTHERS()
        rs_no = get_RS_NO_OTHERS(lvlrequisitionlist.SelectedItems(0).SubItems(1).Text)
        receiving_inout = lvlrequisitionlist.SelectedItems(0).SubItems(9).Text
        'MsgBox(po_no)
        FReceivingReport.txtRSNo.Text = lvlrequisitionlist.SelectedItems(0).SubItems(1).Text
        FReceivingReport.ShowDialog()
    End Sub

    Public Function get_RS_NO_OTHERS(ByVal id As Integer) As Integer
        Dim newsql As New SQLcon
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand

        Try
            newsql.connection.Open()
            publicquery = "SELECT * FROM dbrequisition_slip WHERE rs_id = '" & id & "'"
            newcmd = New SqlCommand(publicquery, newsql.connection)
            newdr = newcmd.ExecuteReader

            While newdr.Read
                get_RS_NO_OTHERS = newdr.Item("rs_no").ToString
            End While
            newdr.Close()


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsql.connection.Close()
        End Try
    End Function

    Public Function get_data_from_requisitionslip(ByVal id As Integer) As Integer

        Dim newsql As New SQLcon
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand

        Try
            newsql.connection.Open()
            publicquery = "SELECT * FROM dbrequisition_slip WHERE rs_id = '" & id & "'"
            newcmd = New SqlCommand(publicquery, newsql.connection)
            newdr = newcmd.ExecuteReader

            While newdr.Read

                With FCashVoucher
                    '.txtChargeTo.Text = lvlrequisitionlist.SelectedItems(0).SubItems(13).Text
                    .txtRSNo.Text = lvlrequisitionlist.SelectedItems(0).SubItems(1).Text
                    'rs_no = newdr.Item("rs_no").ToString
                    charge_to_id = newdr.Item("charge_to").ToString
                End With

            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsql.connection.Close()
        End Try

    End Function

    Public Function get_PO_NO(ByVal id As Integer) As String
        Dim newsql As New SQLcon
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand

        Try
            newsql.connection.Open()
            publicquery = "SELECT * FROM dbPO_details WHERE rs_id = '" & id & "'"
            newcmd = New SqlCommand(publicquery, newsql.connection)
            newdr = newcmd.ExecuteReader

            While newdr.Read
                get_PO_NO = newdr.Item("po_no").ToString
            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsql.connection.Close()
        End Try
    End Function

    Public Function get_multiple_po_no(ByVal rs_id As Integer) As Integer
        Dim newsql As New SQLcon
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand

        Try
            newsql.connection.Open()
            publicquery = "SELECT * FROM dbPO_details WHERE rs_id = '" & rs_id & "'"
            newcmd = New SqlCommand(publicquery, newsql.connection)
            newdr = newcmd.ExecuteReader

            While newdr.Read
                FReceiving_Info.cmbPoNo.Items.Add(newdr.Item("po_no").ToString())
            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsql.connection.Close()
        End Try
    End Function

    Private Delegate Function DoSomethingDelegate() As List(Of class_supplier.supplier)

    Private Sub CreateWithdrawalSlipToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateWithdrawalSlipToolStripMenuItem.Click


        withdrawal_stat1 = "withdrawn"

        'Dim sortWS As New List(Of class_exclusive_aggregates.wsdata)
        'sortWS = cAggregates.LISTOFWS

        Dim selected As ListViewItem = lvlrequisitionlist.SelectedItems(0)

        Dim rs_id As String = selected.Text
        Dim rs_qty As Double = Utilities.ifBlankReplaceToZero(selected.SubItems(5).Text)
        Dim wh_id As Integer = Utilities.ifBlankReplaceToZero(selected.SubItems(15).Text)

        Dim ws = DRModel.GetListOfWithdrawal
        Dim count_wsqty As Double = ws.Where(Function(x)
                                                 Return x.rs_id = rs_id And
                                                 x.wh_id = wh_id
                                             End Function).ToList().Sum(Function(x) x.ws_qty)

        'For Each ws In sortWS
        '    If ws.rs_id = rs_id Then
        '        count_wsqty += ws.ws_qty
        '    End If
        'Next


        If rs_qty = count_wsqty Then
            MessageBox.Show("all rs qty has been withdrawn!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If


        'withdrawal_stat1 = "withdrawn"
        Dim inout As String = lvlrequisitionlist.SelectedItems(0).SubItems(9).Text


        ''FReceiving_Info.ShowDialog()
        'Dim get_rs_id As Integer = lvlrequisitionlist.SelectedItems(0).Text
        'Dim rs_qty As Double = lvlrequisitionlist.SelectedItems(0).SubItems(5).Text

        'Dim rr_qty As Double
        'For Each row As ListViewItem In lvlrequisitionlist.Items
        '    If row.BackColor = Color.LightYellow Then
        '        If get_rs_id = row.Text Then
        '            rr_qty += IIf(row.SubItems(23).Text = "-", 0, row.SubItems(23).Text)
        '        End If
        '    End If
        'Next

        'If rr_qty = rs_qty Then
        '    MessageBox.Show("WITHDRAWN...", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If


        'If (lvlrequisitionlist.SelectedItems(0).SubItems(5).Text - total_ws_qty) <= 0 Then
        '    MessageBox.Show("Can't withdraw anymore. All qty has been released.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Exit Sub
        'End If

        '<=== FOR PO/CV/WS: fill data 
        With FPOFORM

            .dgvPOList.Columns("Column6").ReadOnly = True
            .dgvPOList.Columns("Column9").ReadOnly = True
            .dgvPOList.Columns("Column10").ReadOnly = True
            .dgvPOList.Columns("col_rs_id").ReadOnly = True
            .dgvPOList.Columns("Column14").ReadOnly = True
            .dgvPOList.Columns("col_inout").ReadOnly = True
            .dgvPOList.Columns("col_typeofreq").ReadOnly = True
            .dgvPOList.Columns("Column12").ReadOnly = True

        End With

        show_po_cv_ws(inout) '===>


    End Sub

    Public Sub show_withdraw_form()
        If lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "OUT" And lvlrequisitionlist.SelectedItems(0).SubItems(12).Text = "WITHDRAWN" Then
            MessageBox.Show("Already Withdrawn", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'FReceivingReport.Dispose()
        Else
            FWithdrawalSlip.lblRs_no.Text = lvlrequisitionlist.SelectedItems(0).SubItems(1).Text
            FWithdrawalSlip.lbl_reqID.Text = lvlrequisitionlist.SelectedItems(0).SubItems(0).Text
            'FWithdrawalSlip.txtRSNo.Text = lvlrequisitionlist.SelectedItems(0).SubItems(0).Text
            'chargeto_name = get_chargeto_names()
            'MsgBox(chargeto_name)

            FWithdrawalSlip.ShowDialog()
        End If
    End Sub

    Public Function get_chargeto_names()
        Dim newsql As New SQLcon
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand

        Try
            newsql.connection.Open()
            publicquery = "SELECT * FROM dbrequisition_slip WHERE rs_no = '" & lvlrequisitionlist.SelectedItems(0).SubItems(1).Text & "'"
            newcmd = New SqlCommand(publicquery, newsql.connection)
            newdr = newcmd.ExecuteReader

            While newdr.Read
                get_chargeto_names += 1

            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsql.connection.Close()
        End Try

    End Function


    Private Sub pboxSaveReq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' insert_requisition_slip()
    End Sub

    'Public Sub insert_requisition_slip()
    '    Try
    '        SQLcon.connection.Open()

    '        cmd = New SqlCommand("proc_request_slip", SQLcon.connection)
    '        cmd.Parameters.Clear()
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.Parameters.AddWithValue("@rsNo", txtRSno.Text)
    '        cmd.Parameters.AddWithValue("@dateReq", Date.Parse(DTPReq.Text))
    '        cmd.Parameters.AddWithValue("@joNo", txtJOno.Text)
    '        cmd.Parameters.AddWithValue("@chargeTo", txtChargeTo.Text)
    '        cmd.Parameters.AddWithValue("@location", txtLoc.Text)
    '        cmd.Parameters.AddWithValue("@wh_id", txtItemDesc.Text)
    '        cmd.Parameters.AddWithValue("@qty", txtQty.Text)
    '        cmd.Parameters.AddWithValue("@unit", txtUnit.Text)
    '        cmd.Parameters.AddWithValue("@reqType", cmbRequestType.Text)
    '        cmd.Parameters.AddWithValue("@process", cmbInOut.Text)
    '        cmd.Parameters.AddWithValue("@purpose", txtPurpose.Text)
    '        cmd.Parameters.AddWithValue("@dateNeeded", Date.Parse(DTPTimeNeeded.Text))
    '        cmd.Parameters.AddWithValue("@reqBy", txtRequestBy.Text)
    '        cmd.Parameters.AddWithValue("@notedBy", txtNotedBy.Text)
    '        cmd.Parameters.AddWithValue("@warehouseIncharge", txtWarehouseIncharge.Text)
    '        cmd.Parameters.AddWithValue("@approvedBy", txtApprovedby.Text)
    '        cmd.Parameters.AddWithValue("@crud", "INSERT")

    '        cmd.ExecuteNonQuery()

    '        MessageBox.Show("Successfully added to database..", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)


    '    Catch ex As Exception
    '        MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        SQLcon.connection.Close()
    '    End Try
    'End Sub

    Private Sub txtItemDesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'select sa warehouse aya mo display
        'NOTE temp sa ni. hemoan ra og STORED PROCEDURE

        'search_item_from_warehouse(txtItemDesc.Text)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowInputFields.Click
        If cmbDivision.Text = "" Then
            MessageBox.Show("Please select the category if WAREHOUSING OR CRUSHING..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        'Panel_request_po_cash.Visible = True

        'For Each ctr As Control In Me.Controls
        '    ctr.Enabled = False
        'Next

        'button_click_name = "btnShowInputFields"

        'FRequestField.btnSave.Text = "Save"
        'pub_qto_id = 0
        'FRequestField.Show()

        If CheckBox1.Checked = True Then
            FRequisition_Non_Item.Show()
            Panel_request_po_cash.Visible = False
            Exit Sub

        ElseIf CheckBox2.Checked = True Then

            button_click_name = "btnShowInputFields"

            FRequestField.btnSave.Text = "Save"
            pub_qto_id = 0
            FRequestField.Show()
            Panel_request_po_cash.Visible = False
            Exit Sub

        End If

        MessageBox.Show("Please select which REQUEST! Thank you.!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)

    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click


    End Sub

    Public Function get_type_of_request(ByVal rs_id As Integer, ByVal whatdata As String) As String
        Try
            Dim newSQ As New SQLcon
            Dim newDR As SqlDataReader
            Dim newCMD As SqlCommand

            newSQ.connection.Open()

            newCMD = New SqlCommand("proc_type_of_request", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.Parameters.AddWithValue("@n", 2)

            newDR = newCMD.ExecuteReader
            While newDR.Read
                If whatdata = "type of request" Then
                    get_type_of_request = newDR.Item("tor_desc").ToString

                ElseIf whatdata = "sub of type of request" Then
                    get_type_of_request = newDR.Item("tor_sub_desc").ToString

                    'ElseIf whatdata = "inout" Then
                    '    get_type_of_request = newDR.Item("in_out_desc").ToString

                End If
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Function

    Public Sub GET_REQUISITION_SLIP_DATA(ByVal rs_id As Integer)
        Try
            SQLcon.connection.Open()

            publicquery = "SELECT *,c.item_desc AS con_item_desc FROM dbrequisition_slip a "
            publicquery &= "LEFT JOIN dbConstruct_quantities_save b "
            publicquery &= "On a.rs_id = b.rs_id "
            publicquery &= "LEFT JOIN dbContruct_quantities c "
            publicquery &= "On c.const_id = b.const_id WHERE a.rs_id = " & rs_id

            cmd = New SqlCommand(publicquery, SQLcon.connection)
            sqldr = cmd.ExecuteReader
            While sqldr.Read

                With FRequestField
                    .btnSave.Text = "Update"

                    public_rs_id = sqldr.Item("rs_id").ToString
                    ' .cmbRequestType.Text = sqldr.Item("typeRequest").ToString
                    '.cmbInOut.Text = sqldr.Item("IN_OUT").ToString
                    .txtRSno.Text = sqldr.Item("rs_no").ToString
                    .txtLoc.Text = sqldr.Item("location").ToString
                    .DTPReq.Text = sqldr.Item("date_req").ToString
                    .txtJOno.Text = sqldr.Item("job_order_no").ToString
                    .cmbTypeOfPurchase.Text = sqldr.Item("type_of_purchasing").ToString
                    .txtConsItem.Text = sqldr.Item("item").ToString
                    .txtConsItemDesc.Text = sqldr.Item("con_item_desc").ToString

                    .txtQty.Text = sqldr.Item("qty").ToString
                    .txtUnit.Text = sqldr.Item("unit").ToString
                    .txtItemDesc.Text = sqldr.Item("item_desc").ToString
                    wh_id = sqldr.Item("wh_id").ToString
                    .txtPurpose.Text = sqldr.Item("purpose").ToString
                    .DTPTimeNeeded.Text = sqldr.Item("date_needed").ToString
                    .txtRequestBy.Text = sqldr.Item("requested_by").ToString
                    .txtNotedBy.Text = sqldr.Item("noted_by").ToString
                    .txtApprovedby.Text = sqldr.Item("approved_by").ToString
                    .txtWarehouseIncharge.Text = sqldr.Item("wh_incharge").ToString
                    .cmbTypeofCharge.Text = sqldr.Item("process").ToString
                    .lboxUnit.Visible = False
                    Dim typeOfRequest As String = sqldr.Item("typeRequest").ToString
                    Dim INOUT As String = sqldr.Item("IN_OUT").ToString
                    Dim process As String = sqldr.Item("process").ToString
                    Dim charge_for_cash As String = sqldr.Item("type_of_purchasing").ToString
                    charge_to_id = IIf(Not IsNumeric(sqldr.Item("charge_to").ToString), 0, sqldr.Item("charge_to").ToString)
                    .lboxUnit.Visible = False
                    '.lblFromWh_or_FromTO.Text = sqldr.Item("remarks").ToString
                    'set from_old_item_or_new_item to zero

                    Dim properNaming As New PropsFields.whItems_properName_fields
                    properNaming = getProperNameUsingWhPnId2(IIf(sqldr.Item("wh_pn_id").ToString = "", 0, sqldr.Item("wh_pn_id").ToString))

                    If Not properNaming Is Nothing Then
                        .lblProperNaming.Text = $"{properNaming.item_name} - {properNaming.item_desc}"
                    End If

                    from_old_item_or_new_item = IIf(Not IsNumeric(sqldr.Item("remarks").ToString), 0, sqldr.Item("remarks").ToString)

                    '*=========================================
                    '* 4 - charge to warehouse
                    '* 3 - charge to department,admin and etc.
                    '* 1 - charge to equipment
                    '* 2 - charge to project
                    '*========================================

                    Select Case process
                        Case "EQUIPMENT"
                            .cmbChargeTo.Visible = True
                            .cmbChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 1)
                        Case "PROJECT"
                            .cmbChargeTo.Visible = True
                            .cmbChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 2)
                        Case "WAREHOUSE"
                            .txtChargeTo.Visible = True
                            .txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 4)
                        Case "PERSONAL"
                            .txtChargeTo.Visible = True
                            .txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                        Case "CASH"
                            .txtChargeTo.Visible = True
                            .txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                        Case "ADFIL"
                            .txtChargeTo.Visible = True
                            .txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                    End Select

                    contract_id = IIf(sqldr.Item("contract_id").ToString = "", 0, sqldr.Item("contract_id").ToString)

                End With

            End While

            sqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub

    Private Function get_cons_item_desc(rs_id As Integer) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_QTO_maintenance", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 15)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newCMD.CommandTimeout = 300

            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                get_cons_item_desc = newDR.Item("contract_item_desc").ToString()
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Sub GET_REQUISITION_SLIP_DATA2(ByVal rs_id As Integer)
        Try
            SQLcon.connection.Open()

            publicquery = "SELECT * FROM dbrequisition_slip WHERE rs_id = " & rs_id
            cmd = New SqlCommand(publicquery, SQLcon.connection)
            sqldr = cmd.ExecuteReader
            While sqldr.Read

                With FRequestField
                    .btnSave.Text = "Save"

                    public_rs_id = sqldr.Item("rs_id").ToString
                    .cmbRequestType.Text = sqldr.Item("typeRequest").ToString
                    .cmbInOut.Text = sqldr.Item("IN_OUT").ToString
                    .txtRSno.Text = sqldr.Item("rs_no").ToString
                    .txtLoc.Text = sqldr.Item("location").ToString
                    .DTPReq.Text = sqldr.Item("date_req").ToString
                    .txtJOno.Text = sqldr.Item("job_order_no").ToString
                    .txtItemDesc.Text = sqldr.Item("item_desc").ToString

                    .txtQty.Text = sqldr.Item("qty").ToString
                    .txtUnit.Text = sqldr.Item("unit").ToString

                    .txtPurpose.Text = sqldr.Item("purpose").ToString
                    .DTPTimeNeeded.Text = sqldr.Item("date_needed").ToString
                    .txtRequestBy.Text = sqldr.Item("requested_by").ToString
                    .txtNotedBy.Text = sqldr.Item("noted_by").ToString
                    '.txtApprovedby.Text = sqldr.Item("approved_by").ToString
                    '.txtWarehouseIncharge.Text = sqldr.Item("wh_incharge").ToString

                    .cmbTypeofCharge.Text = sqldr.Item("process").ToString
                    .lboxUnit.Visible = False
                    Dim typeOfRequest As String = sqldr.Item("typeRequest").ToString
                    Dim INOUT As String = sqldr.Item("IN_OUT").ToString
                    Dim process As String = sqldr.Item("process").ToString
                    Dim charge_for_cash As String = sqldr.Item("type_of_purchasing").ToString
                    If sqldr.Item("charge_to").ToString = "" Then
                        charge_to_id = 0
                    Else
                        charge_to_id = sqldr.Item("charge_to").ToString
                    End If

                    .lboxUnit.Visible = False
                    .lblFromWh_or_FromTO.Text = sqldr.Item("remarks").ToString


                    '*=========================================
                    '* 4 - charge to warehouse
                    '* 3 - charge to department,admin and etc.
                    '* 1 - charge to equipment
                    '* 2 - charge to project
                    '*========================================


                    Select Case process
                        Case "EQUIPMENT"
                            .cmbChargeTo.Visible = True
                            .cmbChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 1)
                        Case "PROJECT"
                            .cmbChargeTo.Visible = True
                            .cmbChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 2)
                        Case "WAREHOUSE"
                            .txtChargeTo.Visible = True
                            .txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 4)
                        Case "PERSONAL"
                            .txtChargeTo.Visible = True
                            .txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                        Case "CASH"
                            .txtChargeTo.Visible = True
                            .txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                        Case "ADFIL"
                            .txtChargeTo.Visible = True
                            .txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                    End Select

                    .cmbTypeOfPurchase.Text = sqldr.Item("type_of_purchasing").ToString
                End With

            End While

            sqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()


        End Try
    End Sub

    Public Sub where_to_charge(ByVal process As String, ByVal charge_for_cash As String)

        With FRequestField
            If process = "EQUIPMENT" Then
                .cmbChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 1)

            ElseIf process = "SHOPS" Or process = "PROJECT" Then
                .txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                .cmbChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 2)

            ElseIf process = "ADFIL" Then
                .txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 3)

            ElseIf process = "PERSONAL" Then
                .txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 3)

            ElseIf process = "CASH" Then
                '.txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                '.cmbCharges.Text = charge_for_cash
                '.lblchargename.Text = ""

                If charge_for_cash = "EQUIPMENT" Then
                    .cmbCharges.Text = "EQUIPMENT"
                    .lblchargename.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 1)

                ElseIf charge_for_cash = "PROJECT" Then
                    .cmbCharges.Text = "PROJECT"
                    .lblchargename.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 2)

                ElseIf charge_for_cash = "ADFIL" Then
                    .cmbCharges.Text = "ADFIL"
                    .cmbChargeTo.Visible = False
                    .lblchargename.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 3)

                ElseIf charge_for_cash = "SHOPS" Then
                    .cmbCharges.Text = "SHOPS"
                    .lblchargename.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 2)

                End If

            ElseIf process = "SHOPS" Then
                .cmbChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 2)

            End If
        End With

    End Sub

    Public Function where_to_charge1(ByVal process As String, ByVal charge_for_cash As String) As String

        With FRequestField
            If process = "EQUIPMENT" Then
                where_to_charge1 = GET_equip_desc_AND_proj_desc(charge_to_id, 1)

            ElseIf process = "PROJECT" Then
                where_to_charge1 = GET_equip_desc_AND_proj_desc(charge_to_id, 2)

            ElseIf process = "ADFIL" Then
                where_to_charge1 = GET_equip_desc_AND_proj_desc(charge_to_id, 3)

            ElseIf process = "PERSONAL" Then
                where_to_charge1 = GET_equip_desc_AND_proj_desc(charge_to_id, 3)

            ElseIf process = "CASH" Then
                If charge_for_cash = "EQUIPMENT" Then
                    where_to_charge1 = GET_equip_desc_AND_proj_desc(charge_to_id, 1)

                ElseIf charge_for_cash = "PROJECT" Then
                    where_to_charge1 = GET_equip_desc_AND_proj_desc(charge_to_id, 2)

                ElseIf charge_for_cash = "ADFIL" Then
                    where_to_charge1 = GET_equip_desc_AND_proj_desc(charge_to_id, 3)

                ElseIf charge_for_cash = "SHOPS" Then
                    where_to_charge1 = GET_equip_desc_AND_proj_desc(charge_to_id, 2)
                End If


            ElseIf process = "SHOPS" Then
                where_to_charge1 = GET_equip_desc_AND_proj_desc(charge_to_id, 2)

            End If
        End With

    End Function

    Public Sub GET_REQUISITION_SLIP_DATA1(ByVal rs_id As Integer)
        Try
            SQLcon.connection.Open()

            publicquery = "SELECT * FROM dbrequisition_slip WHERE rs_id = " & rs_id
            cmd = New SqlCommand(publicquery, SQLcon.connection)
            sqldr = cmd.ExecuteReader
            While sqldr.Read

                With FPOFORM

                    .Label1.Text = "WS Date:"
                    .txtRsNo.Text = sqldr.Item("rs_no").ToString
                    .lblChargeToID.Text = sqldr.Item("charge_to").ToString
                    .lblTypeOfCharge.Text = lvlrequisitionlist.SelectedItems(0).SubItems(17).Text

                    Dim typeOfRequest As String = sqldr.Item("typeRequest").ToString
                    Dim INOUT As String = sqldr.Item("IN_OUT").ToString
                    Dim process As String = sqldr.Item("process").ToString
                    Dim charge_for_cash As String = sqldr.Item("type_of_purchasing").ToString
                    charge_to_id = IIf(sqldr.Item("charge_to").ToString = "", 0, sqldr.Item("charge_to").ToString)

                    .lblInOut.Text = INOUT
                    .lblTypeOfReq.Text = typeOfRequest
                    .lbl_type_of_purchasing.Text = sqldr.Item("type_of_purchasing").ToString

                    '*=========================================
                    '* 4 - charge to warehouse
                    '* 3 - charge to department,admin and etc.
                    '* 1 - charge to equipment
                    '* 2 - charge to project
                    '*=========================================

                    Select Case process
                        Case "EQUIPMENT"
                            .txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 1)
                        Case "PROJECT"
                            .txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 2)
                        Case "WAREHOUSE"
                            .txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 4)
                        Case "PERSONAL"
                            .txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                        Case "CASH"
                            .txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 3)
                        Case "ADFIL"
                            .txtChargeTo.Text = GET_equip_desc_AND_proj_desc(charge_to_id, 3)

                            Dim mcharges As String = get_multiple_charges(rs_id)

                            If mcharges.Length < 1 Then
                            Else
                                mcharges = mcharges.Trim().Substring(0, mcharges.Length - 1)
                                .txtChargeTo.Text = .txtChargeTo.Text & "(" & UCase(mcharges) & ")"

                            End If
                    End Select

                End With
            End While

            sqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()

        End Try
    End Sub
    Public Sub load_po_info_if_exist(ByVal rs_no As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            'Dim query As String = "SELECT *,c.rs_no FROM dbPO a INNER JOIN dbPO_details b ON a.po_id = b.po_id "
            'query &= "INNER JOIN dbrequisition_slip c ON b.rs_id = c.rs_id "
            'query &= "WHERE b.rs_id = " & rs_id

            Dim query As String = "SELECT TOP 1 *,b.rs_id,b.charge_to FROM dbPO a INNER JOIN dbrequisition_slip b ON b.rs_no = a.rs_no WHERE a.rs_no = '" & rs_no & "'"

            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader
            While newDR.Read
                With FPOFORM
                    .txtRsNo.Text = newDR.Item("rs_no").ToString
                    Dim rs_id As Integer = newDR.Item("rs_id").ToString
                    .lblTypeOfCharge.Text = lvlrequisitionlist.SelectedItems(0).SubItems(17).Text
                    Dim mcharges As String = get_multiple_charges(rs_id)

                    If mcharges.Length < 1 Then
                    Else
                        mcharges = mcharges.Trim().Substring(0, mcharges.Length - 1)
                        .txtChargeTo.Text = .txtChargeTo.Text & "(" & UCase(mcharges) & ")"
                    End If

                    .DTPTrans.Text = Date.Parse(newDR.Item("po_date").ToString)
                    .txtInstructions.Text = newDR.Item("instructor").ToString
                    .DTPdateneeded.Text = Date.Parse(newDR.Item("date_needed").ToString)
                    .txtPrepared_by.Text = newDR.Item("prepared_by").ToString
                    .txtChecked_by.Text = newDR.Item("checked_by").ToString
                    .txtApproved_by.Text = newDR.Item("approved_by").ToString
                    .lblChargeToID.Text = newDR.Item("charge_to").ToString
                    FPOFORM.set_po_id = newDR.Item("po_id").ToString

                End With
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Private Sub RemoveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you want to delete this rs? all data from po,ws and rrs will be affected..", "EUS Info:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            '****** THIS CODE IS FOR CASH WITH RR **********
            Dim type_of_purchasing As String = lvlrequisitionlist.SelectedItems(0).SubItems(18).Text

            Dim get_po_det_id As Integer
            Dim po_ws_qty As Double

            If type_of_purchasing = "CASH WITH RR" Then
                get_po_det_id = IIf(lvlrequisitionlist.SelectedItems(0).SubItems(35).Text = "", 0, lvlrequisitionlist.SelectedItems(0).Text) 'rs_id ang ihatag
                po_ws_qty = IIf(lvlrequisitionlist.SelectedItems(0).SubItems(5).Text = "", 0, lvlrequisitionlist.SelectedItems(0).SubItems(5).Text)
            Else
                get_po_det_id = IIf(lvlrequisitionlist.SelectedItems(0).SubItems(35).Text = "", 0, lvlrequisitionlist.SelectedItems(0).SubItems(35).Text)
                po_ws_qty = IIf(lvlrequisitionlist.SelectedItems(0).SubItems(22).Text = "", 0, lvlrequisitionlist.SelectedItems(0).SubItems(22).Text)
            End If

            Dim rr_qty As Double
            For Each row As ListViewItem In lvlrequisitionlist.Items
                If row.BackColor = Color.LightYellow Then
                    If get_po_det_id = Utilities.ifBlankReplaceToZero(row.SubItems(35).Text) Then
                        rr_qty += Utilities.ifBlankReplaceToZero(row.SubItems(23).Text)
                    End If
                End If
            Next

            If type_of_purchasing = "CASH WITH RR" Then
                If rr_qty = po_ws_qty Then
                    MessageBox.Show("Unable to Remove if the item has been received...", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

            '*******************************

            For Each row As ListViewItem In lvlrequisitionlist.Items
                If row.Selected = True Then
                    If lvlrequisitionlist.SelectedItems(0).SubItems(11).Text = "RECEIVED" Then
                        MessageBox.Show("Unable to remove, the item has already received...", "EUS INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return

                    ElseIf lvlrequisitionlist.SelectedItems(0).SubItems(12).Text = "WITHDRAWN" Then
                        MessageBox.Show("Unable to remove, the item has already withdrawn." & vbCrLf & "Please contact the administrator.", "EUS INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return

                    ElseIf lvlrequisitionlist.SelectedItems(0).SubItems(10).Text = "PO/CV RELEASED" Then
                        MessageBox.Show("Unable to remove, the PO was already released." & vbCrLf & "Please contact the administrator.", "EUS INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return

                        'ElseIf lvlrequisitionlist.SelectedItems(0).SubItems(21).Text <> "0" And lvlrequisitionlist.SelectedItems(0).SubItems(32).Text <> "0" Then
                        'MessageBox.Show("Unable to remove, some dr has been deliver." & vbCrLf & "Please contact the administrator.", "EUS INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        'Return

                    Else
                        If lvlrequisitionlist.SelectedItems(0).SubItems(22).Text = "" AndAlso
                                                    lvlrequisitionlist.SelectedItems(0).SubItems(23).Text = "" AndAlso
                                                    (lvlrequisitionlist.SelectedItems(0).SubItems(32).Text = "" OrElse
                                                    lvlrequisitionlist.SelectedItems(0).SubItems(32).Text = "0") Then
                            ' Your code for the first condition
                            'continue
                        Else

                            MessageBox.Show("Unable to remove, some dr has been deliver." & vbCrLf & "Please contact the administrator.", "EUS INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return
                        End If

                        Remove_rs()
                        remove_rs_tor_sub_property(CInt(row.Text))

                        Dim query As String = "DELETE FROM Mark_Fac_Tools WHERE rs_id = " & CInt(row.Text)
                        UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

                        query = Nothing
                        query = "DELETE FROM dbMultipleCharges WHERE rs_id = " & CInt(row.Text)
                        UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

                        query = Nothing
                        query = "DELETE FROM dbBorrower_checking_info WHERE rs_id = " & CInt(row.Text)
                        'Dim checking_info_id As Integer = UPDATE_INSERT_DELETE_QUERY(query, 1, "DELETE")
                        UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

                        'query = Nothing
                        'query = "DELETE FROM dbBorrower_checking_info WHERE checking_info_id = " & CInt(checking_info_id)
                        'UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

                        query = Nothing
                        query = "DELETE FROM dbConstruct_quantities_save WHERE rs_id = " & CInt(row.Text)
                        UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

                        'e CLEAR ANG original_volume if isa lng nabilin
                        If count_rs(row.SubItems(1).Text) = 1 Then
                            Dim newSQ As New SQLcon
                            Dim newCMD As SqlCommand
                            Try
                                newSQ.connection.Open()
                                newCMD = New SqlCommand("UPDATE dbrequisition_slip SET original_volume = '' WHERE rs_no = '" & row.SubItems(1).Text & "'", newSQ.connection)
                                newCMD.ExecuteNonQuery()
                            Catch ex As Exception
                                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Finally
                                newSQ.connection.Close()
                            End Try
                        End If

                        'delete ang endorse item
                        query = Nothing
                        query = "DELETE FROM dbEndorse_Items WHERE rs_id = " & CInt(row.Text)
                        UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

                        btnSearch.PerformClick()

                    End If
                End If

            Next
        End If
    End Sub
    Public Function count_rs(rs_no As String) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT count(*) as rs_counting FROM dbrequisition_slip WHERE rs_no = '" & rs_no & "'"
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader
            While newDR.Read
                count_rs = newDR.Item("rs_counting").ToString
            End While
            newDR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Public Sub remove_rs_tor_sub_property(rs_id As Integer)

        Dim query As String = "delete from rs_tor_sub_property WHERE rs_id = " & rs_id
        UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")

    End Sub

    Public Sub remove_rs1()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_viewing", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 6)

            newCMD.ExecuteNonQuery()


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Sub



    Public Sub Remove_rs()
        Dim newsq As New SQLcon
        Dim newcmd As SqlCommand

        Try
            newsq.connection.Open()

            newcmd = New SqlCommand("proc_purchase_order_query", newsq.connection)
            newcmd.Parameters.Clear()
            newcmd.CommandType = CommandType.StoredProcedure
            newcmd.Parameters.AddWithValue("@rs_id", lvlrequisitionlist.SelectedItems(0).Text)
            newcmd.Parameters.AddWithValue("@rs_no", lvlrequisitionlist.SelectedItems(0).SubItems(1).Text)
            newcmd.Parameters.AddWithValue("@proc_po_id", get_po_id_using_rs())
            newcmd.Parameters.AddWithValue("@proc_wh_id", lvlrequisitionlist.SelectedItems(0).SubItems(15).Text)

            'If count_po_item_or_rs_no(1) > 1 And count_po_item_or_rs_no(2) > 0 Then
            '    newcmd.Parameters.AddWithValue("@n", 4)
            'ElseIf count_po_item_or_rs_no(1) <= 1 And count_po_item_or_rs_no(2) <= 1 Then
            '    newcmd.Parameters.AddWithValue("@n", 5)
            'End If

            If count_po_item_or_rs_no(1) > 1 Then
                newcmd.Parameters.AddWithValue("@n", 4)
            Else
                newcmd.Parameters.AddWithValue("@n", 5)
            End If
            Dim rs_id As Integer = Val(lvlrequisitionlist.SelectedItems(0).Text)
            Dim rs_no As String = lvlrequisitionlist.SelectedItems(0).SubItems(1).Text

            If count_widrawal_item(rs_id) > 1 Then
                delete_withdrawal(rs_id, 1)
            Else
                delete_withdrawal(rs_id, 2)
                delete_withdrawal(rs_no, 3)
            End If

            newcmd.ExecuteNonQuery()

            lvlrequisitionlist.SelectedItems(0).Remove()


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsq.connection.Close()

        End Try
    End Sub
    Public Sub delete_withdrawal(ByVal id As String, ByVal n As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            Dim query As String
            If n = 1 Then
                query = "DELETE FROM dbwithdrawal_items WHERE rs_id = " & id
            ElseIf n = 2 Then
                query = "DELETE FROM dbwithdrawal_items WHERE rs_id = " & id
            ElseIf n = 3 Then
                query = "DELETE FROM dbwithdrawal_info WHERE rs_no = '" & id.ToString & "'"
            End If

            newCMD = New SqlCommand(query, newSQ.connection)
            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Public Function count_widrawal_item(ByVal rs_no As Integer) As Integer
        Try
            SQLcon.connection.Open()

            publicquery = " select b.item_desc, a.rs_no from dbwithdrawal_info a " &
                            "INNER JOIN dbwithdrawal_items b ON a.ws_info_id = b.ws_info_id WHERE a.rs_no = " & rs_no

            cmd = New SqlCommand(publicquery, SQLcon.connection)

            sqldr = cmd.ExecuteReader
            While sqldr.Read
                count_widrawal_item += 1

            End While
            sqldr.Close()

        Catch ex As Exception

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Function
    Public Function get_po_id_using_rs() As Integer
        Try
            SQLcon.connection.Open()
            Dim rs_no As String = lvlrequisitionlist.SelectedItems(0).SubItems(1).Text

            publicquery = "SELECT * FROM dbpurchase_order WHERE rs_no = '" & rs_no & "'"
            cmd = New SqlCommand(publicquery, SQLcon.connection)

            sqldr = cmd.ExecuteReader
            While sqldr.Read
                get_po_id_using_rs = sqldr.Item("po_id").ToString
            End While
            sqldr.Close()

        Catch ex As Exception

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Function

    Public Function count_po_item_or_rs_no(ByVal value As Integer) As Integer
        Dim newSQ As New SQLcon

        Try

            Dim newDR As SqlDataReader
            Dim newCMD As SqlCommand

            newSQ.connection.Open()
            If value = 1 Then
                'publicquery = "SELECT a.po_no,b.rs_no FROM dbPurchase_order_items a INNER JOIN dbpurchase_order b ON a.po_no = b.po_no WHERE b.rs_no = " & lvlrequisitionlist.SelectedItems(0).SubItems(1).Text

                publicquery = "SELECT a.po_no,b.rs_no FROM dbPO_details a "
                publicquery &= "INNER JOIN dbPO b ON a.po_id = b.po_id "
                publicquery &= "WHERE b.rs_no = '" & lvlrequisitionlist.SelectedItems(0).SubItems(1).Text & "'"

            ElseIf value = 2 Then
                publicquery = "SELECT * FROM dbrequisition_slip where rs_no = '" & lvlrequisitionlist.SelectedItems(0).SubItems(1).Text & "'"
            End If

            newCMD = New SqlCommand(publicquery, newSQ.connection)
            newDR = newCMD.ExecuteReader
            While newDR.Read
                count_po_item_or_rs_no += 1
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Public Sub enable_disable_menu_for_requisition_from()
        Try
            Dim inout As String
            Dim PO_status, RR_status, WS_status As String
            Dim rs_qty, po_ws_released, ws_rr_qty_received As Double
            Dim type_of_purchasing As String
            Dim item_check As Boolean

            inout = lvlrequisitionlist.SelectedItems(0).SubItems(9).Text

            PO_status = lvlrequisitionlist.SelectedItems(0).SubItems(10).Text
            RR_status = lvlrequisitionlist.SelectedItems(0).SubItems(11).Text
            WS_status = lvlrequisitionlist.SelectedItems(0).SubItems(12).Text
            type_of_purchasing = lvlrequisitionlist.SelectedItems(0).SubItems(18).Text

            rs_qty = IIf(IsNumeric(lvlrequisitionlist.SelectedItems(0).SubItems(5).Text) = True, lvlrequisitionlist.SelectedItems(0).SubItems(5).Text, 0)
            po_ws_released = IIf(IsNumeric(lvlrequisitionlist.SelectedItems(0).SubItems(22).Text) = True, lvlrequisitionlist.SelectedItems(0).SubItems(22).Text, 0)
            ws_rr_qty_received = IIf(IsNumeric(lvlrequisitionlist.SelectedItems(0).SubItems(23).Text) = True, lvlrequisitionlist.SelectedItems(0).SubItems(23).Text, 0)

            item_check = IIf(CInt(lvlrequisitionlist.SelectedItems(0).SubItems(15).Text) > 0, True, False)

            If PO_status = "WAITING..." And RR_status = "" And WS_status = "WAITING..." Then

                cmsMenuRS.Items("CreartePurchaseOrderToolStripMenuItem").Enabled = False 'create po
                cmsMenuRS.Items("CreateReceivingReportToolStripMenuItem").Enabled = False 'create receiving
                cmsMenuRS.Items("CreateCashVoucherToolStripMenuItem").Enabled = False 'create cash voucher
                cmsMenuRS.Items("EquipmentUseForHaulingToolStripMenuItem").Enabled = False 'creat dr
                cmsMenuRS.Items("WarehouseCheckingToolStripMenuItem").Enabled = True  'item checking
                cmsMenuRS.Items("CreateReceivingWithoutPOToolStripMenuItem").Enabled = True 'create receiving without PO
                cmsMenuRS.Items("EndorseItemCheckingToolStripMenuItem").Enabled = True 'Endorse item checking

            End If

            If item_check = True Then
                cmsMenuRS.Items("WarehouseCheckingToolStripMenuItem").Enabled = False
                cmsMenuRS.Items("EndorseItemCheckingToolStripMenuItem").Enabled = False

                Select Case inout
                '************** IN *****************
                    Case "IN", "OTHERS"
                        'check type of purchasing
                        If type_of_purchasing = "PURCHASE ORDER" Then
                            'check the PO status
                            If PO_status = "PENDING" Then

                                cmsMenuRS.Items("CreartePurchaseOrderToolStripMenuItem").Enabled = True
                                cmsMenuRS.Items("CreateReceivingReportToolStripMenuItem").Enabled = False
                                cmsMenuRS.Items("CreateWithdrawalSlipToolStripMenuItem").Enabled = False

                            ElseIf PO_status = "PO/CV PARTIALLY RELEASED" Then
                                cmsMenuRS.Items("CreartePurchaseOrderToolStripMenuItem").Enabled = True
                            ElseIf PO_status = "PO RELEASED" Then
                                cmsMenuRS.Items("CreartePurchaseOrderToolStripMenuItem").Enabled = False
                            End If

                            'check RR status
                            If RR_status = "PENDING" Then
                                cmsMenuRS.Items("CreateReceivingReportToolStripMenuItem").Enabled = True
                            ElseIf RR_status = "PARTIALLY RECEIVED" Then
                                cmsMenuRS.Items("CreateReceivingReportToolStripMenuItem").Enabled = True
                            ElseIf RR_status = "RECEIVED" Then
                                cmsMenuRS.Items("CreateReceivingReportToolStripMenuItem").Enabled = False
                            End If

                        ElseIf type_of_purchasing = "CASH" Then
                            If PO_status = "PENDING" Then

                                cmsMenuRS.Items("CreateCashVoucherToolStripMenuItem").Enabled = True
                                cmsMenuRS.Items("CreateReceivingReportToolStripMenuItem").Enabled = False
                                cmsMenuRS.Items("CreateWithdrawalSlipToolStripMenuItem").Enabled = False

                            ElseIf PO_status = "PO/CV PARTIALLY RELEASED" Then
                                cmsMenuRS.Items("CreateCashVoucherToolStripMenuItem").Enabled = True
                            ElseIf PO_status = "CV RELEASED" Then
                                cmsMenuRS.Items("CreateCashVoucherToolStripMenuItem").Enabled = False
                            End If

                            'check RR status
                            If RR_status = "PENDING" Then
                                If po_ws_released = ws_rr_qty_received And ws_rr_qty_received <> 0 Then
                                    cmsMenuRS.Items("CreateReceivingReportToolStripMenuItem").Enabled = False
                                ElseIf po_ws_released = 0 And ws_rr_qty_received = 0 Then
                                    cmsMenuRS.Items("CreateReceivingReportToolStripMenuItem").Enabled = False
                                ElseIf po_ws_released > ws_rr_qty_received Then
                                    cmsMenuRS.Items("CreateReceivingReportToolStripMenuItem").Enabled = True
                                End If

                            ElseIf RR_status = "PARTIALLY RECEIVED" Then
                                cmsMenuRS.Items("CreateReceivingReportToolStripMenuItem").Enabled = True
                            ElseIf RR_status = "RECEIVED" Then
                                cmsMenuRS.Items("CreateReceivingReportToolStripMenuItem").Enabled = False
                            End If

                        ElseIf type_of_purchasing = "N/A" Then
                            'PO is not applicable for N/A
                            If PO_status = "N/A" Then
                                cmsMenuRS.Items("CreartePurchaseOrderToolStripMenuItem").Enabled = False
                            End If
                        ElseIf type_of_purchasing = "DR" Then
                            'PO is not applicable for DR
                            If PO_status = "N/A" Then
                                cmsMenuRS.Items("CreartePurchaseOrderToolStripMenuItem").Enabled = False
                            End If

                            'check RR status
                            If RR_status = "PENDING" Then

                                cmsMenuRS.Items("CreateReceivingWithoutPOToolStripMenuItem").Enabled = True
                                cmsMenuRS.Items("EquipmentUseForHaulingToolStripMenuItem").Enabled = True

                            ElseIf RR_status = "PARTIALLY RECEIVED" Then

                                cmsMenuRS.Items("CreateReceivingWithoutPOToolStripMenuItem").Enabled = True
                                cmsMenuRS.Items("EquipmentUseForHaulingToolStripMenuItem").Enabled = True

                            ElseIf RR_status = "RECEIVED" Then

                                cmsMenuRS.Items("CreateReceivingWithoutPOToolStripMenuItem").Enabled = False
                                cmsMenuRS.Items("EquipmentUseForHaulingToolStripMenuItem").Enabled = False

                            End If
                        End If

                '*********** OUT **************
                    Case "OUT"
                        cmsMenuRS.Items("CreateReceivingWithoutPOToolStripMenuItem").Enabled = False

                        If type_of_purchasing = "WITHDRAWAL" Then
                            If WS_status = "PENDING" Then

                                cmsMenuRS.Items("CreateWithdrawalSlipToolStripMenuItem").Enabled = True

                            ElseIf WS_status = "WITHDRAWAL RELEASED" Then

                                cmsMenuRS.Items("CreateWithdrawalSlipToolStripMenuItem").Enabled = True

                            ElseIf WS_status = "PARTIALLY WITHDRAWN" Then

                                cmsMenuRS.Items("CreateWithdrawalSlipToolStripMenuItem").Enabled = True
                                cmsMenuRS.Items("EquipmentUseForHaulingToolStripMenuItem").Enabled = True

                            ElseIf WS_status = "WITHDRAWN" Then

                                cmsMenuRS.Items("CreateWithdrawalSlipToolStripMenuItem").Enabled = False
                                cmsMenuRS.Items("EquipmentUseForHaulingToolStripMenuItem").Enabled = True

                            Else
                                cmsMenuRS.Items("CreateWithdrawalSlipToolStripMenuItem").Enabled = False
                            End If
                        End If
                End Select


                Select Case lvlrequisitionlist.SelectedItems(0).BackColor
                    Case Color.DarkGreen

                        If rs_qty = po_ws_released And po_ws_released = ws_rr_qty_received And rs_qty <> 0 Then
                            CreateWithdrawalSlipToolStripMenuItem.Enabled = False
                        Else
                            If inout = "IN" Or inout = "OTHERS" Then
                                CreateWithdrawalSlipToolStripMenuItem.Enabled = False
                            Else
                                If item_check = True Then
                                    CreateWithdrawalSlipToolStripMenuItem.Enabled = True
                                Else
                                    CreateWithdrawalSlipToolStripMenuItem.Enabled = False
                                End If

                            End If
                        End If

                        If inout = "IN" Or inout = "OTHERS" Then
                            EquipmentUseForHaulingToolStripMenuItem.Enabled = True
                        Else
                            EquipmentUseForHaulingToolStripMenuItem.Enabled = False
                        End If

                    Case Color.LightGreen

                        Dim split() As String

                        CreateWithdrawalSlipToolStripMenuItem.Enabled = False

                        split = lvlrequisitionlist.SelectedItems(0).SubItems(32).Text.Split("/")

                        If split(0) = "" Then
                            If ws_rr_qty_received > IIf(lvlrequisitionlist.SelectedItems(0).SubItems(32).Text = "", 0, lvlrequisitionlist.SelectedItems(0).SubItems(32).Text) Then
                                EquipmentUseForHaulingToolStripMenuItem.Enabled = True
                            ElseIf ws_rr_qty_received = IIf(lvlrequisitionlist.SelectedItems(0).SubItems(32).Text = "", 0, lvlrequisitionlist.SelectedItems(0).SubItems(32).Text) And ws_rr_qty_received <> 0 Then
                                EquipmentUseForHaulingToolStripMenuItem.Enabled = False
                            End If
                        Else
                            If ws_rr_qty_received > split(0) Then
                                EquipmentUseForHaulingToolStripMenuItem.Enabled = True
                            ElseIf ws_rr_qty_received = split(0) And ws_rr_qty_received <> 0 Then
                                EquipmentUseForHaulingToolStripMenuItem.Enabled = False
                            End If
                        End If

                    Case Color.LightYellow

                        EquipmentUseForHaulingToolStripMenuItem.Enabled = False
                        CreateWithdrawalSlipToolStripMenuItem.Enabled = False

                End Select
            Else
                cmsMenuRS.Items("WarehouseCheckingToolStripMenuItem").Enabled = True   'item checking

            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try


    End Sub
    Private Sub cmsMenuRS_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsMenuRS.Opening


        If lvlrequisitionlist.SelectedItems.Count = 0 Then
            e.Cancel = True
            Exit Sub
        End If

        '**default disable context menu button**
        INToolStripMenuItem.Enabled = True
        OTHERSToolStripMenuItem.Enabled = True
        '***************************************

        If lvlrequisitionlist.SelectedItems(0).BackColor = Color.LightGreen Then 'LIGHTGREEN

            For Each itm As ToolStripItem In cmsMenuRS.Items
                If itm.Name = "EquipmentUseForHaulingToolStripMenuItem" Then
                    If lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "OTHERS" Then
                        itm.Enabled = False
                    Else
                        If lvlrequisitionlist.SelectedItems(0).SubItems(18).Text = "PURCHASE ORDER" Then
                            itm.Enabled = False
                        Else
                            itm.Enabled = True
                        End If

                    End If

                ElseIf itm.Name = "CalculateToolStripMenuItem" Then
                    itm.Enabled = True
                ElseIf itm.Name = "CreateReceivingReportToolStripMenuItem" Then
                    If lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "OTHERS" Then
                        itm.Enabled = True

                    ElseIf lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "IN" Then
                        itm.Enabled = True
                    Else
                        itm.Enabled = False
                    End If
                ElseIf itm.Name = "CancelToolStripMenuItem" Then
                    itm.Enabled = True
                Else
                    itm.Enabled = False


                End If
            Next

            'enable_disable_menu_for_requisition_from()

        ElseIf lvlrequisitionlist.SelectedItems(0).BackColor = Color.LightYellow Then 'LIGHTYELLOW
            For Each itm As ToolStripItem In cmsMenuRS.Items
                If itm.Name = "CalculateToolStripMenuItem" Then
                    itm.Enabled = True
                ElseIf itm.Name = "CalculateToolStripMenuItem" Then
                    itm.Enabled = True
                Else
                    itm.Enabled = False
                End If
            Next

        ElseIf lvlrequisitionlist.SelectedItems(0).BackColor = Color.Lime Then 'LIME
            For Each item As ToolStripMenuItem In cmsMenuRS.Items
                If item.Name = "CreateMainQtyToolStripMenuItem" Then
                    item.Enabled = False
                ElseIf item.Name = "RemoveMainRSToolStripMenuItem" Then
                    item.Enabled = True
                ElseIf item.Name = "CopyToolStripMenuItem" Then
                    item.Enabled = True
                Else
                    item.Enabled = False
                End If
            Next

        ElseIf lvlrequisitionlist.SelectedItems(0).BackColor = Color.DarkGreen Then 'DARKGREEN
            For Each item As ToolStripMenuItem In cmsMenuRS.Items
                Select Case item.Name

                    Case "CreateReceivingWithoutPOToolStripMenuItem"
                        If lvlrequisitionlist.SelectedItems(0).SubItems(18).Text = "DR" Then
                            item.Enabled = True
                        Else
                            item.Enabled = False
                        End If

                    Case "CreateMainQtyToolStripMenuItem"
                        item.Enabled = True

                    Case "CopyToolStripMenuItem"
                        If cmbDivision.Text = "CRUSHING AND HAULING" Then
                            item.Enabled = False
                        Else
                            item.Enabled = True
                        End If

                    Case "EditToolStripMenuItem"
                        Dim type_of_purchasing As String = lvlrequisitionlist.SelectedItems(0).SubItems(18).Text
                        item.Enabled = True

                        If type_of_purchasing = "CASH WITH RR" Then
                            UpdateWhidToolStripMenuItem.Enabled = False
                            INToolStripMenuItem.Enabled = True
                            OTHERSToolStripMenuItem.Enabled = True

                        Else
                            UpdateWhidToolStripMenuItem.Enabled = True
                            INToolStripMenuItem.Enabled = False
                            OTHERSToolStripMenuItem.Enabled = False

                        End If


                    Case "RemoveToolStripMenuItem"
                        item.Enabled = True

                    Case "CreateCashVoucherToolStripMenuItem"
                        If lvlrequisitionlist.SelectedItems(0).SubItems(18).Text = "CASH WITH RR" Or lvlrequisitionlist.SelectedItems(0).SubItems(18).Text = "CASH WITHOUT RR" Or lvlrequisitionlist.SelectedItems(0).SubItems(18).Text = "DR" Then
                            'item.Enabled = False
                            item.Enabled = True
                        Else
                            item.Enabled = True
                        End If

                    Case "CreateWithdrawalSlipToolStripMenuItem"
                        If lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "OTHERS" Then
                            item.Enabled = False

                        ElseIf lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "IN" Then
                            item.Enabled = False

                        ElseIf lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "" Then
                            item.Enabled = False

                        ElseIf lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "OUT" Then
                            item.Enabled = True

                        End If

                    Case "WarehouseCheckingToolStripMenuItem"
                        If lvlrequisitionlist.SelectedItems(0).SubItems(15).Text = 0 Then
                            item.Enabled = True
                        Else
                            item.Enabled = False
                        End If

                        If lvlrequisitionlist.SelectedItems(0).SubItems(18).Text = "CASH WITH RR" Or lvlrequisitionlist.SelectedItems(0).SubItems(18).Text = "CASH WITHOUT RR" Then
                            item.Enabled = False
                        End If

                    Case "CreateChargesToolStripMenuItem"
                        'If lvlrequisitionlist.SelectedItems(0).SubItems(15).Text = 0 Then
                        '    item.Enabled = False
                        'Else
                        '    item.Enabled = True
                        'End If
                        item.Enabled = True

                    Case "CreateReceivingReportToolStripMenuItem"
                        If lvlrequisitionlist.SelectedItems(0).SubItems(18).Text = "CASH WITH RR" Then
                            item.Enabled = True
                        Else
                            item.Enabled = False
                        End If

                    Case "CreartePurchaseOrderToolStripMenuItem"
                        If lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "OTHERS" Then

                            If lvlrequisitionlist.SelectedItems(0).SubItems(18).Text = "CASH WITH RR" Or lvlrequisitionlist.SelectedItems(0).SubItems(18).Text = "CASH WITHOUT RR" Then
                                item.Enabled = False
                            Else
                                item.Enabled = True
                            End If

                        ElseIf lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "IN" Then
                            item.Enabled = True
                        Else
                            item.Enabled = False
                        End If

                    Case "EquipmentUseForHaulingToolStripMenuItem"
                        If lvlrequisitionlist.SelectedItems(0).SubItems(18).Text = "DR" Then

                            'If dr_with_rr(lvlrequisitionlist.SelectedItems(0).Text) > 0 Then
                            '    item.Enabled = False
                            'Else
                            '    item.Enabled = True
                            'End If
                            item.Enabled = True
                        Else
                            item.Enabled = False
                        End If

                    Case "ExportToExcelFileToolStripMenuItem"
                        item.Enabled = True

                    Case "ConvertToINToolStripMenuItem"
                        item.Enabled = True

                    Case "ConvertToOTHERSToolStripMenuItem"
                        item.Enabled = True

                    Case "ChangeItemNamedescriptionToolStripMenuItem"
                        item.Enabled = True

                    Case "RemoveItemCheckedToolStripMenuItem"
                        item.Enabled = True

                    Case "CreateReceivingWithoutPOToolStripMenuItem"
                        item.Enabled = True

                    Case "ChangeItemNamedescriptionToolStripMenuItem"
                        item.Enabled = True

                    Case "cavass_reportToolStripMenuItem"
                        item.Enabled = True

                    Case "CancelToolStripMenuItem"
                        item.Enabled = True

                    Case Else
                        item.Enabled = False

                End Select
            Next

            total_ws_qty = 0
            Dim rs_id As Integer = lvlrequisitionlist.SelectedItems(0).Text
            For Each row As ListViewItem In lvlrequisitionlist.Items
                If row.BackColor = Color.LightGreen Then
                    If row.Text = rs_id Then
                        total_ws_qty += row.SubItems(22).Text
                    End If
                End If
            Next

        ElseIf lvlrequisitionlist.SelectedItems(0).BackColor = Color.White Then 'WHITE
            For Each itm As ToolStripItem In cmsMenuRS.Items
                itm.Enabled = False
            Next

        ElseIf lvlrequisitionlist.SelectedItems(0).BackColor = Color.LightPink Then ' LIGHT PINK
            For Each itm As ToolStripItem In cmsMenuRS.Items
                Select Case itm.Name
                    Case "EquipmentUseForHaulingToolStripMenuItem"
                        itm.Enabled = True
                    Case Else
                        itm.Enabled = False
                End Select

            Next

        ElseIf lvlrequisitionlist.SelectedItems(0).BackColor = Color.Yellow Then 'YELLOW 
            For Each itm As ToolStripItem In cmsMenuRS.Items
                Select Case itm.Name
                    Case "CopyToolStripMenuItem"
                        itm.Enabled = True
                    Case "CreateMainQtyToolStripMenuItem"
                        itm.Enabled = True
                    Case Else
                        itm.Enabled = False
                End Select

            Next
        ElseIf lvlrequisitionlist.SelectedItems(0).BackColor = Color.Blue Then 'BLUE 
            For Each itm As ToolStripItem In cmsMenuRS.Items
                itm.Enabled = False
            Next
        Else
            For Each itm As ToolStripItem In cmsMenuRS.Items
                itm.Enabled = True
            Next

            enable_disable_menu_for_requisition_from()
        End If

        ExtractToDRListToolStripMenuItem.Enabled = True


        'for auth: admin
        If auth = newAuth.admin Then
            EditRsQtyAuthToolStripMenuItem.Visible = True

        Else
            EditRsQtyAuthToolStripMenuItem.Visible = False

        End If

        Exit Sub


        '***********************************************
        'condem nani ngac code pero ayaw lang sa deleta'
        '***********************************************
        '   *
        '   *
        '   *
        ' *****
        '  ***
        '   *

        Try

            Dim InOut As String = lvlrequisitionlist.SelectedItems(0).SubItems(9).Text
            Dim purchased As String = lvlrequisitionlist.SelectedItems(0).SubItems(10).Text
            Dim received As String = lvlrequisitionlist.SelectedItems(0).SubItems(11).Text
            Dim withdrawn As String = lvlrequisitionlist.SelectedItems(0).SubItems(12).Text
            Dim typepurchased As String = lvlrequisitionlist.SelectedItems(0).SubItems(18).Text
            Dim typeofdelivery As String = lvlrequisitionlist.SelectedItems(0).SubItems(31).Text

            If lvlrequisitionlist.SelectedItems.Count > 0 Then

                Dim po_qty As Double
                Dim rr_qty As Double
                Dim wh_id As Integer = CInt(lvlrequisitionlist.SelectedItems(0).SubItems(15).Text)
                Dim rs_qty As Double = CDbl(lvlrequisitionlist.SelectedItems(0).SubItems(5).Text)


                If lvlrequisitionlist.SelectedItems(0).SubItems(22).Text = "N/A" Then
                    po_qty = 0
                Else
                    po_qty = CDbl(lvlrequisitionlist.SelectedItems(0).SubItems(22).Text)
                End If

                If lvlrequisitionlist.SelectedItems(0).SubItems(23).Text = "N/A" Then
                    rr_qty = 0
                Else
                    rr_qty = CDbl(lvlrequisitionlist.SelectedItems(0).SubItems(23).Text)
                End If

                If typepurchased = "DR" Then
                Else
                    rs_qty = CDbl(lvlrequisitionlist.SelectedItems(0).SubItems(5).Text)
                End If

                If InOut = "OTHERS" Or InOut = "In" Then
                    If typepurchased = "PURCHASE ORDER" Then
                        CreartePurchaseOrderToolStripMenuItem.Enabled = True

                        If po_qty < rs_qty Then
                            cmsMenuRS.Items(0).Enabled = True
                        Else
                            cmsMenuRS.Items(0).Enabled = False
                        End If

                        If rr_qty < po_qty Then
                            cmsMenuRS.Items(1).Enabled = True
                        Else
                            cmsMenuRS.Items(1).Enabled = False
                        End If

                        cmsMenuRS.Items(2).Enabled = False
                        cmsMenuRS.Items(3).Enabled = False
                        cmsMenuRS.Items(6).Enabled = True


                    ElseIf typepurchased = "CASH" Then
                        If po_qty < rs_qty Then
                            cmsMenuRS.Items(3).Enabled = True
                        Else
                            cmsMenuRS.Items(3).Enabled = False
                        End If

                        If rr_qty < po_qty Then
                            cmsMenuRS.Items(1).Enabled = True
                        Else
                            cmsMenuRS.Items(1).Enabled = False
                        End If

                        cmsMenuRS.Items(2).Enabled = False
                        cmsMenuRS.Items(0).Enabled = False

                    ElseIf typepurchased = "DR" Then

                        cmsMenuRS.Items(0).Enabled = False
                        cmsMenuRS.Items(1).Enabled = False
                        cmsMenuRS.Items(2).Enabled = False
                        cmsMenuRS.Items(3).Enabled = False

                        If rs_qty > rr_qty Then
                            If received = "PENDING" Then
                                cmsMenuRS.Items("CreateReceivingWithoutPOToolStripMenuItem").Enabled = True
                            End If
                        Else
                            If received = "RECEIVED" Then
                                cmsMenuRS.Items("CreateReceivingWithoutPOToolStripMenuItem").Enabled = False
                            End If
                        End If

                    End If

                    cmsMenuRS.Items(4).Enabled = False
                    cmsMenuRS.Items(5).Enabled = False
                    cmsMenuRS.Items(7).Enabled = False
                    cmsMenuRS.Items(8).Enabled = False
                    cmsMenuRS.Items(9).Enabled = False
                    cmsMenuRS.Items(17).Enabled = False
                    cmsMenuRS.Items(18).Enabled = False

                ElseIf InOut = "OUT" Then
                    cmsMenuRS.Items(0).Enabled = False
                    cmsMenuRS.Items(1).Enabled = False
                    'cmsMenuRS.Items(4).Enabled = False

                    If rs_qty = po_qty And po_qty = rr_qty Then
                        cmsMenuRS.Items(2).Enabled = False
                    Else
                        cmsMenuRS.Items(2).Enabled = True
                    End If
                    cmsMenuRS.Items(3).Enabled = False

                    If typepurchased = "WITHDRAWAL" Then
                        cmsMenuRS.Items(17).Enabled = True
                        cmsMenuRS.Items(18).Enabled = True
                        cmsMenuRS.Items("CreateReceivingWithoutPOToolStripMenuItem").Enabled = False
                    End If
                End If

                If lvlrequisitionlist.SelectedItems(0).BackColor = Color.Red Then
                    CancelToolStripMenuItem.Text = "Uncancel"
                Else
                    CancelToolStripMenuItem.Text = "Cancel"
                End If

                If InOut = "WAITING..." And wh_id = 0 Then

                    cmsMenuRS.Items(0).Enabled = False
                    cmsMenuRS.Items(1).Enabled = False
                    cmsMenuRS.Items(2).Enabled = False
                    cmsMenuRS.Items(3).Enabled = False
                    cmsMenuRS.Items(4).Enabled = False
                    cmsMenuRS.Items(5).Enabled = False
                    cmsMenuRS.Items(6).Enabled = True
                    cmsMenuRS.Items(7).Enabled = False
                    cmsMenuRS.Items(8).Enabled = False
                    cmsMenuRS.Items(9).Enabled = False
                    ' cmsMenuRS.Items(4).Enabled = False
                    cmsMenuRS.Items("CreateReceivingWithoutPOToolStripMenuItem").Enabled = False
                    cmsMenuRS.Items("EquipmentUseForHaulingToolStripMenuItem").Enabled = False

                ElseIf InOut = "OUT" Then
                    If rs_qty = po_qty And withdrawn = "WS RELEASED" Then
                        cmsMenuRS.Items(0).Enabled = False
                        cmsMenuRS.Items(1).Enabled = False
                        cmsMenuRS.Items(2).Enabled = False
                        cmsMenuRS.Items(3).Enabled = False
                        cmsMenuRS.Items(4).Enabled = False
                        cmsMenuRS.Items(5).Enabled = False
                        cmsMenuRS.Items(6).Enabled = True
                        cmsMenuRS.Items(7).Enabled = False
                        cmsMenuRS.Items(8).Enabled = False
                        cmsMenuRS.Items(9).Enabled = False
                        cmsMenuRS.Items("CreateReceivingWithoutPOToolStripMenuItem").Enabled = False
                        cmsMenuRS.Items("EquipmentUseForHaulingToolStripMenuItem").Enabled = True

                    ElseIf rs_qty > po_qty And withdrawn = "WS PARTIALLY RELEASED" Then
                        cmsMenuRS.Items(5).Enabled = False
                        cmsMenuRS.Items(6).Enabled = True
                        cmsMenuRS.Items(7).Enabled = False
                        cmsMenuRS.Items(8).Enabled = False
                        cmsMenuRS.Items(9).Enabled = False
                        cmsMenuRS.Items("CreateReceivingWithoutPOToolStripMenuItem").Enabled = False
                        cmsMenuRS.Items("EquipmentUseForHaulingToolStripMenuItem").Enabled = True

                    ElseIf withdrawn = "PARTIALLY WITHDRAWN" Then

                        cmsMenuRS.Items(5).Enabled = False
                        cmsMenuRS.Items(6).Enabled = True
                        cmsMenuRS.Items(7).Enabled = False
                        cmsMenuRS.Items(8).Enabled = False
                        cmsMenuRS.Items(9).Enabled = False
                        cmsMenuRS.Items("CreateReceivingWithoutPOToolStripMenuItem").Enabled = False
                        cmsMenuRS.Items("EquipmentUseForHaulingToolStripMenuItem").Enabled = True

                    ElseIf withdrawn = "PENDING" Then

                        cmsMenuRS.Items(5).Enabled = False
                        cmsMenuRS.Items(6).Enabled = True
                        cmsMenuRS.Items(7).Enabled = False
                        cmsMenuRS.Items(8).Enabled = False
                        cmsMenuRS.Items(9).Enabled = False
                        cmsMenuRS.Items("CreateReceivingWithoutPOToolStripMenuItem").Enabled = False
                        cmsMenuRS.Items("EquipmentUseForHaulingToolStripMenuItem").Enabled = True

                    ElseIf withdrawn = "WITHDRAWN" Then

                        cmsMenuRS.Items(5).Enabled = False
                        cmsMenuRS.Items(6).Enabled = True
                        cmsMenuRS.Items(7).Enabled = False
                        cmsMenuRS.Items(8).Enabled = False
                        cmsMenuRS.Items(9).Enabled = False
                        cmsMenuRS.Items("CreateReceivingWithoutPOToolStripMenuItem").Enabled = False
                        cmsMenuRS.Items("EquipmentUseForHaulingToolStripMenuItem").Enabled = True

                    End If
                ElseIf InOut = "BORROWER" Then
                    cmsMenuRS.Items(0).Enabled = False
                    cmsMenuRS.Items(1).Enabled = False
                    cmsMenuRS.Items(2).Enabled = False
                    cmsMenuRS.Items(3).Enabled = False
                    cmsMenuRS.Items(4).Enabled = False
                    cmsMenuRS.Items(5).Enabled = False
                    cmsMenuRS.Items(6).Enabled = True
                    cmsMenuRS.Items(7).Enabled = True
                    cmsMenuRS.Items(8).Enabled = False
                    cmsMenuRS.Items(9).Enabled = False

                ElseIf InOut = "BORROWED" Or InOut = "PARTIALLY TURNOVER" Then

                    cmsMenuRS.Items(0).Enabled = False
                    cmsMenuRS.Items(1).Enabled = False
                    cmsMenuRS.Items(2).Enabled = False
                    cmsMenuRS.Items(3).Enabled = False
                    cmsMenuRS.Items(4).Enabled = False
                    cmsMenuRS.Items(5).Enabled = False
                    cmsMenuRS.Items(6).Enabled = True
                    cmsMenuRS.Items(7).Enabled = True 'temporary true 
                    cmsMenuRS.Items(8).Enabled = True
                    cmsMenuRS.Items(9).Enabled = False

                ElseIf InOut = "TURNOVER" Then

                    'cmsMenuRS.Items(0).Enabled = False
                    'cmsMenuRS.Items(1).Enabled = False
                    'cmsMenuRS.Items(2).Enabled = False
                    'cmsMenuRS.Items(3).Enabled = False
                    'cmsMenuRS.Items(4).Enabled = False
                    'cmsMenuRS.Items(5).Enabled = False
                    'cmsMenuRS.Items(6).Enabled = False
                    'cmsMenuRS.Items(7).Enabled = False
                    'cmsMenuRS.Items(8).Enabled = False
                    'cmsMenuRS.Items(9).Enabled = False

                    If rs_qty = po_qty And withdrawn = "PARTIALLY WITHDRAWN" Then
                        cmsMenuRS.Items(2).Enabled = False
                        cmsMenuRS.Items(6).Enabled = False

                    End If

                End If

                If received = "RECEIVED" Then
                    WarehouseCheckingToolStripMenuItem.Enabled = False
                End If

            Else
                For Each item As ToolStripItem In cmsMenuRS.Items
                    If item.Name = "EditToolStripMenuItem" Then
                    Else
                        item.Enabled = False
                    End If
                Next

            End If

            cmsMenuRS.Items(23).Enabled = True
            WarehouseCheckingToolStripMenuItem.Enabled = True
            RemoveToolStripMenuItem.Enabled = True

            If withdrawn = "WITHDRAWN" Or withdrawn = "PARTIALLY WITHDRAWN" Then
                WarehouseCheckingToolStripMenuItem.Enabled = False

            ElseIf received = "RECEIVED" Or withdrawn = "PARTIALLY RECEIVED" Then
                WarehouseCheckingToolStripMenuItem.Enabled = False
                'cmsMenuRS.Items("EquipmentUseForHaulingToolStripMenuItem").Enabled = True

            ElseIf purchased = "PURCHASED" Then
                WarehouseCheckingToolStripMenuItem.Enabled = False
            Else
                WarehouseCheckingToolStripMenuItem.Enabled = True
            End If

            If purchased = "PURCHASED" And received = "RECEIVED" Then
                EditToolStripMenuItem.Enabled = True
            Else
                EditToolStripMenuItem.Enabled = True
            End If


#Region "TYPEOFDELIVERY"
            'If typeofdelivery = "With DR" Then
            '    EquipmentUseForHaulingToolStripMenuItem.Enabled = True
            'Else
            '    EquipmentUseForHaulingToolStripMenuItem.Enabled = False
            'End If

            'If typepurchased = "DR" Then
            '    EquipmentUseForHaulingToolStripMenuItem.Enabled = True
            'End If
#End Region


        Catch ex As Exception
            MessageBox.Show("Error MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

    Private Sub CancelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelToolStripMenuItem.Click
        '# COMMENT BY KJ
        'Dim n As Integer = lvlrequisitionlist.SelectedItems(0).Text

        'If CancelToolStripMenuItem.Text = "Cancel" Then
        '    Try
        '        SQLcon.connection.Open()
        '        publicquery = "UPDATE dbrequisition_slip SET trans = '" & "cancel" & "' WHERE rs_id = " & Val(lvlrequisitionlist.SelectedItems(0).Text)
        '        UPDATE_INSERT_DELETE_QUERY(publicquery, 1, "UPDATE")

        '    Catch ex As Exception
        '        MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Finally
        '        SQLcon.connection.Close()

        '        lvlrequisitionlist.Items.Clear()
        '        load_rs()
        '        listfocus(lvlrequisitionlist, n)
        '    End Try

        'ElseIf CancelToolStripMenuItem.Text = "Uncancel" Then
        '    Try
        '        SQLcon.connection.Open()
        '        publicquery = "UPDATE dbrequisition_slip SET trans = '" & Nothing & "' WHERE rs_id = " & Val(lvlrequisitionlist.SelectedItems(0).Text)
        '        UPDATE_INSERT_DELETE_QUERY(publicquery, 1, "UPDATE")

        '    Catch ex As Exception
        '        MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Finally
        '        SQLcon.connection.Close()

        '        lvlrequisitionlist.Items.Clear()
        '        load_rs()
        '        listfocus(lvlrequisitionlist, n)
        '    End Try
        'End If


    End Sub

    Private Sub lvlrequisitionlist_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        If lvlrequisitionlist.SelectedItems.Count > 0 Then
            For Each ctr As ToolStripMenuItem In cmsMenuRS.Items
                ctr.Enabled = True
            Next

            If e.Button = Windows.Forms.MouseButtons.Right Then
                If lvlrequisitionlist.SelectedItems(0).SubItems(11).Text = "RECEIVED" Then
                    CancelToolStripMenuItem.Enabled = False
                ElseIf lvlrequisitionlist.SelectedItems(0).SubItems(12).Text = "WITHDRAWN" Then
                    CancelToolStripMenuItem.Enabled = False
                Else
                    CancelToolStripMenuItem.Enabled = True
                End If
            End If

        Else
            For Each ctr As ToolStripMenuItem In cmsMenuRS.Items

                ctr.Enabled = False
            Next
        End If

    End Sub

    Private Sub lvlrequisitionlist_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Public Sub pages(category As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        If category = "WAREHOUSING AND SUPPLY" Then
            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_requisition_slip", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                Dim search, items As String

                Select Case txtSearch.Text
                    Case "Charges..."
                        search = ""
                    Case "RS No..."
                        search = ""
                    Case "Items..."
                        search = ""
                    Case "Requested By..."
                        search = ""
                    Case "Input By"
                        search = ""
                    Case Else
                        search = txtSearch.Text
                End Select

                If txtItemName.Text = "Items..." Then
                    items = ""
                Else
                    items = txtItemName.Text
                End If

                newCMD.Parameters.AddWithValue("@n", 148)
                newCMD.Parameters.AddWithValue("@category", cmbSearchByCategory.Text)
                newCMD.Parameters.AddWithValue("@inout", cmbInOut.Text)
                Fsearchbycharges.Button1.Enabled = True
                Fsearchbycharges.lvlSearchCharges.Items.Clear()

                If cmbSearchByCategory.Text = "Generate Summary of Hauling Aggregates" Then
                    'newCMD.Parameters.AddWithValue("@charges", search)
                    'newCMD.Parameters.AddWithValue("@search", items)

                    Fsearchbycharges.cmbGenerateProject.SelectedIndex = 1
                    Fsearchbycharges.cmbGenerateProject.Text = "Generate by All Project"
                    Fsearchbycharges.ShowDialog()
                    Exit Sub

                ElseIf cmbSearchByCategory.Text = "Search by Charges" Then
                    Fsearchbycharges.ShowDialog()
                    Exit Sub

                ElseIf cmbSearchByCategory.Text = "Search by Requested by" Then
                    Fsearchbycharges.ShowDialog()
                    Exit Sub
                Else
                    newCMD.Parameters.AddWithValue("@search", search)
                    newCMD.Parameters.AddWithValue("@itemname", txtItemName.Text)
                End If

                newCMD.CommandTimeout = 300

                newDR = newCMD.ExecuteReader
                Dim pages As Integer
                Dim a(10) As String

                While newDR.Read
                    pages = newDR.Item("pages").ToString
                End While

                newDR.Close()
                cmbpages.Items.Clear()
                Dim counter As Integer

                For i = 1 To Math.Ceiling(IIf(pages <= 100, 100, pages) / 100)
                    cmbpages.Items.Add(i)
                Next

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
                cmbpages.SelectedIndex = cmbpages.Items.Count - 1
            End Try

        ElseIf category = "CRUSHING AND HAULING" Then
            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_requisition_slip", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                Dim search, items As String

                Select Case txtSearch.Text
                    Case "Charges..."
                        search = ""
                    Case "RS No..."
                        search = ""
                    Case "Items..."
                        search = ""
                    Case "Requested By..."
                        search = ""
                    Case "Input By"
                        search = ""
                    Case Else
                        search = txtSearch.Text
                End Select

                If txtItemName.Text = "Items..." Then
                    items = ""
                Else
                    items = txtItemName.Text
                End If

                newCMD.Parameters.AddWithValue("@n", 150)
                newCMD.Parameters.AddWithValue("@category", cmbSearchByCategory.Text)
                newCMD.Parameters.AddWithValue("@inout", cmbInOut.Text)
                Fsearchbycharges.lvlSearchCharges.Items.Clear()

                If cmbSearchByCategory.Text = "Search by Charges" Or cmbSearchByCategory.Text = "Generate Summary of Hauling Aggregates" Then

                    'If items = "" Then
                    '    MessageBox.Show("Please, fill-up items..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '    Exit Sub
                    'End If

                    'newCMD.Parameters.AddWithValue("@charges", search)
                    'newCMD.Parameters.AddWithValue("@search", items)
                    Fsearchbycharges.ShowDialog()
                    Exit Sub
                Else
                    newCMD.Parameters.AddWithValue("@search", search)
                End If

                newCMD.CommandTimeout = 300

                newDR = newCMD.ExecuteReader
                Dim pages As Integer
                Dim a(10) As String

                While newDR.Read
                    pages = newDR.Item("pages").ToString
                End While

                newDR.Close()
                cmbpages.Items.Clear()
                Dim counter As Integer

                For i = 1 To Math.Ceiling(IIf(pages <= 100, 100, pages) / 100)
                    cmbpages.Items.Add(i)
                Next


            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
                cmbpages.SelectedIndex = cmbpages.Items.Count - 1
            End Try
        End If


    End Sub

    Public Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        'FDivisionCategory.ShowDialog()
        'Exit Sub

        'Search by item
        'Search by RS.No.
        'Search by Charge To
        'Search by Requested by
        'Search by Borrower Slip No.
        'Search by Type of Request
        'Search by User Name
        'Search by Date Input
        'Search by Input by
        'Filter by month of Date Request

        '        Search by Charges (WAREHOUSE)
        'Search by Charges (PROJECT, EQUIPMENT And OTHERS)

        'load_rs_4()

        'load_rs_3(13)
        btnSearch.Enabled = False

        main_finesand = 0
        main_g1 = 0
        main_34 = 0

        If cmbSearchByCategory.Text = "" Then
            MessageBox.Show("Please select search category first...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If cmbDivision.Text = "WAREHOUSING AND SUPPLY" Then
            ''load_rs_3(13)
            'cmbpages.Items.Clear()
            'pages(cmbDivision.Text)
            ''load_rs_68()

            Button5.PerformClick()

        Else
            ''load_rs_66(21)


            ''load_rs_67()

            'pages(cmbDivision.Text)

            If cmbSearchByCategory.Text = "Search by RS.No." Then

                '''<== new code May 2023 
                ''lvlrequisitionlist.Items.Clear()
                ''cAggregates = New class_exclusive_aggregates
                ''cAggregates._initialize(txtSearch.Text, lvlrequisitionlist)
                ''btnSearch.Enabled = True '==>

                'btnSearch.Enabled = False
                ''searchRsNew()

                'DRModel.clear()

                'Dim param As New Dictionary(Of String, Object)

                'param.Add("search", txtSearch.Text)
                'param.Add("panel", loadingPanel)
                'param.Add("listview", lvlrequisitionlist)
                'param.Add("rsLabel", lblRs1)
                'param.Add("wsLabel", lblWs)
                'param.Add("poLabel", lblPo)
                'param.Add("drLabel", lblDr)
                'param.Add("mainRsLabel", lblMainRs1)

                'param.Add("oldLoadingPanel", Panel3)
                'param.Add("btnSearch", btnSearch)
                'param.Add("contextMenuStrip", ContextMenuStrip)

                'DRModel.initialize(param)
                'DRModel.cListOfWsReleasedItems = cListOfWsReleasedItem

                'DRModel.execute()

                Dim NEWDRMODEL As New RSDRModel
                NEWDRMODEL.initialize("", txtSearch.Text)
                NEWDRMODEL.execute()

            ElseIf cmbSearchByCategory.Text = "Search by User Name" Or cmbSearchByCategory.Text = "Search by item" Then
                Button2.PerformClick()

            ElseIf cmbSearchByCategory.Text = "Generate Summary of Hauling Aggregates" Then
                Panel_date_duration.Visible = True
                Exit Sub

            ElseIf cmbSearchByCategory.Text = "Search by Charges" Or cmbSearchByCategory.Text = "Search by Requested by" Then

                With Fsearchbycharges
                    pub_search_by_charges = 1
                    .cmbProject.Enabled = True
                    .cmbProject1.Enabled = True
                    .txtItemSearch.Enabled = True
                    .dtpdatefrom.Enabled = False
                    .dtpdateto.Enabled = False
                    .Button2.Enabled = True

                    .Button1.Enabled = True
                    load_type_of_charges_name(.cmbProject)

                    .ListBox1.Items.Clear()
                    .lvlSearchCharges.Items.Clear()

                    .lvlSearchCharges.Enabled = True
                    .GroupBox1.Enabled = True
                    .ShowDialog()
                End With
                Exit Sub

            End If

            ''load_rs_3(13)
            ''load_rs_5()
        End If


        'If cmbSearchByCategory.Text = "Search by item" Then
        '    load_rs_3(4)
        'ElseIf cmbSearchByCategory.Text = "Search by RS.No." Then
        '    load_rs_3(5)
        'ElseIf cmbSearchByCategory.Text = "Search by Charges (WAREHOUSE)" Then
        '    load_rs_3(6)
        'ElseIf cmbSearchByCategory.Text = "Search by Charges (PERSONAL And OTHERS)" Then
        '    load_rs_3(8)
        'ElseIf cmbSearchByCategory.Text = "Search by Charges (EQUIPMENT)" Then
        '    load_rs_3(11)
        'ElseIf cmbSearchByCategory.Text = "Search by Charges (PROJECT)" Then
        '    load_rs_3(12)
        'ElseIf cmbSearchByCategory.Text = "Search by Requested by" Then
        '    load_rs_3(7)
        'ElseIf cmbSearchByCategory.Text = "Search by Type Of Request" Then
        '    load_rs_3(9)
        'ElseIf cmbSearchByCategory.Text = "Search by User Name" Then
        '    load_rs_3(10)


        'Else
        '    load_rs_3(1)
        'End If


    End Sub

    Private Function checkIfExistInListOfDr(dr_item_id As Integer) As Integer
        'store the dr_item_id in tempStorage
        cListOfDrItemId.ForEach(Sub(id As Integer)
                                    If id = dr_item_id Then
                                        checkIfExistInListOfDr += 1
                                        Exit Sub
                                    End If
                                End Sub)
    End Function

    Public Sub load_rs_68()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        lvlrequisitionlist.Items.Clear()
        Dim counter As Integer = 0

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_requisition_slip", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            Dim search, items As String

            Select Case txtSearch.Text
                Case "Charges..."
                    search = ""
                Case "RS No..."
                    search = ""
                Case "Items..."
                    search = ""
                Case "Requested By..."
                    search = ""
                Case "Input By"
                    search = ""
                Case Else
                    search = txtSearch.Text
            End Select

            If txtItemName.Text = "Items..." Then
                items = ""
            Else
                items = txtItemName.Text
            End If
            Dim range, range1, range2 As Integer

            range = 100
            range2 = cmbpages.Text * range
            range1 = range2 - range


            newCMD.Parameters.AddWithValue("@category", cmbSearchByCategory.Text)
            newCMD.Parameters.AddWithValue("@inout", cmbInOut.Text)
            newCMD.Parameters.AddWithValue("@range1", range1)
            newCMD.Parameters.AddWithValue("@range2", range2)

            If cmbSearchByCategory.Text = "Search by Charges" Then
                newCMD.Parameters.AddWithValue("@n", 147)
                newCMD.Parameters.AddWithValue("@charges", search)
                newCMD.Parameters.AddWithValue("@search", items)
                newCMD.Parameters.AddWithValue("@itemname", txtItemName.Text)

            ElseIf cmbSearchByCategory.Text = "Search by Requested by" Then
                newCMD.Parameters.AddWithValue("@n", 147)

            ElseIf cmbSearchByCategory.Text = "Search by item (Item Checked only)" Then
                newCMD.Parameters.AddWithValue("@n", 44)
                newCMD.Parameters.AddWithValue("@wh_id", FListOfItems.lvlWarehouseItem.SelectedItems(0).Text)

            Else
                newCMD.Parameters.AddWithValue("@n", 147)
                newCMD.Parameters.AddWithValue("@search", search)
                newCMD.Parameters.AddWithValue("@itemname", items)

            End If

            newCMD.CommandTimeout = 300

            newDR = newCMD.ExecuteReader

            Dim a(40) As String
            Dim dat_req, date_needed As DateTime
            Dim pocv_status, rr_status, ws_status As String

            While newDR.Read

                a(0) = newDR.Item("rs_id").ToString

                If newDR.Item("date_req").ToString = "" Or newDR.Item("date_req").ToString = "-" Then
                    dat_req = "1990-01-01"
                Else
                    dat_req = newDR.Item("date_req").ToString
                End If

                a(2) = Format(Date.Parse(dat_req), "MM/dd/yyyy")
                a(3) = newDR.Item("job_order_no").ToString
                a(6) = newDR.Item("unit").ToString

                Select Case newDR.Item("sorting").ToString
                    Case "A"

                        If newDR.Item("date_needed").ToString = "" Or newDR.Item("date_needed").ToString = "-" Then
                            date_needed = "1990-01-01"
                        Else
                            date_needed = newDR.Item("date_needed").ToString
                        End If

                        a(1) = newDR.Item("rs_no").ToString
                        a(4) = newDR.Item("items").ToString
                        a(5) = newDR.Item("qty").ToString
                        a(7) = Format(Date.Parse(date_needed), "MM/dd/yyyy")
                        a(8) = newDR.Item("type_of_request").ToString
                        a(13) = newDR.Item("charges").ToString
                        a(14) = newDR.Item("location").ToString
                        a(15) = newDR.Item("wh_id").ToString
                        a(16) = newDR.Item("date_log").ToString
                        a(17) = newDR.Item("type_of_charges").ToString
                        a(18) = newDR.Item("type_of_purchasing").ToString
                        a(19) = newDR.Item("remarks").ToString
                        a(21) = 0
                        a(22) = newDR.Item("po_cv_ws_released").ToString
                        a(23) = newDR.Item("rr_qty_received").ToString
                        a(24) = newDR.Item("username").ToString
                        a(25) = newDR.Item("ws_id").ToString
                        a(28) = newDR.Item("requested_by").ToString
                        a(29) = newDR.Item("cons_item").ToString
                        a(30) = newDR.Item("cons_item_desc").ToString
                        a(31) = newDR.Item("type_of_delivery").ToString
                        a(32) = 0
                        a(33) = newDR.Item("wh_area").ToString
                        a(35) = newDR.Item("rr_item_id").ToString
                        a(36) = "-"

                        Dim rs_qty As Double = CDbl(a(5))
                        Dim po_qty As Double = CDbl(IIf(a(22) = "", 0, a(22)))
                        Dim ws_rr_qty As Double = CDbl(IIf(a(23) = "", 0, a(23)))

                        Select Case newDR.Item("IN_OUT").ToString
                            Case "IN"

                                If po_qty < rs_qty Then
                                    If po_qty = 0 Then
                                        pocv_status = "PENDING"
                                    Else
                                        pocv_status = "PO/CV PARTIALLY RELEASED"
                                    End If

                                ElseIf po_qty = rs_qty Then
                                    pocv_status = "PO/CV RELEASED"
                                End If

                                If ws_rr_qty < po_qty Then
                                    If ws_rr_qty = 0 Then
                                        rr_status = "PENDING"
                                    Else
                                        rr_status = "PARTIALLY RECEIVED"
                                    End If

                                ElseIf ws_rr_qty = po_qty Then
                                    If ws_rr_qty = 0 Then
                                        rr_status = "PENDING"
                                    Else
                                        rr_status = "RECEIVED"
                                    End If
                                End If

                                'if wala pay po og rr nya na item check na
                                If ws_rr_qty = 0 And po_qty = 0 Then
                                    pocv_status = "PENDING"
                                    rr_status = "PENDING"
                                End If

                                ws_status = "N/A"
                            Case "OTHERS"
                                If po_qty < rs_qty Then
                                    pocv_status = "PO/CV PARTIALLY RELEASED"
                                ElseIf po_qty = rs_qty Then
                                    pocv_status = "PO/CV RELEASED"
                                End If

                                If ws_rr_qty < po_qty Then
                                    If ws_rr_qty = 0 Then
                                        rr_status = "PENDING"
                                    Else
                                        rr_status = "PARTIALLY RECEIVED"
                                    End If
                                ElseIf ws_rr_qty = po_qty Then
                                    rr_status = "RECEIVED"
                                End If

                                'if wala pay po og rr nya na item check na
                                If ws_rr_qty = 0 And po_qty = 0 Then
                                    pocv_status = "PENDING"
                                    rr_status = "PENDING"
                                End If

                                ws_status = "N/A"
                            Case "OUT"
                                If ws_rr_qty < po_qty Then
                                    ws_status = "PARTIALLY WITHDRAWN"
                                ElseIf rs_qty > ws_rr_qty And ws_rr_qty > 0 Then
                                    ws_status = "PARTIALLY WITHDRAWN"
                                ElseIf ws_rr_qty = po_qty Then
                                    ws_status = "WITHDRAWN"
                                End If

                                'if wala pay po og rr nya na item check na
                                If ws_rr_qty = 0 And po_qty = 0 Then
                                    ws_status = "PENDING"
                                End If

                                pocv_status = "N/A"
                                rr_status = "N/A"
                        End Select

                        '
                        If a(15) = 0 Then 'wala pa na item check
                            a(10) = "WAITING..."
                            a(11) = "WAITING..."
                            a(12) = "WAITING..."
                        Else
                            a(10) = pocv_status
                            a(11) = rr_status
                            a(12) = ws_status
                        End If

                    Case "B"
                        a(1) = "-"
                        a(4) = ChrW(187) & " " & newDR.Item("items").ToString
                        a(5) = "-"
                        a(13) = "-"

                        If newDR.Item("IN_OUT").ToString = "IN" Or newDR.Item("IN_OUT").ToString = "OTHERS" Then
                            a(7) = "-"
                            a(8) = newDR.Item("type_of_request").ToString
                            a(10) = "- released"
                            a(11) = "-"
                            a(12) = "-"
                            a(17) = newDR.Item("type_of_charges").ToString
                            a(18) = newDR.Item("type_of_purchasing").ToString
                            a(19) = newDR.Item("remarks").ToString
                            a(22) = newDR.Item("qty").ToString
                            a(23) = "-"
                            a(24) = newDR.Item("username").ToString
                            a(25) = newDR.Item("ws_id").ToString
                            a(28) = newDR.Item("requested_by").ToString
                            a(29) = newDR.Item("cons_item").ToString
                            a(31) = newDR.Item("type_of_delivery").ToString
                            a(33) = newDR.Item("wh_area").ToString
                            a(35) = newDR.Item("rr_item_id").ToString
                        Else
                            a(7) = "-"
                            a(10) = "-"
                            a(11) = "-"

                            If newDR.Item("withdrawn").ToString = "" Then
                                a(12) = "WITHDRAWAL RELEASED"
                            Else
                                a(12) = "WITHDRAWN"
                            End If

                            a(8) = newDR.Item("type_of_request").ToString
                            a(17) = newDR.Item("type_of_charges").ToString
                            a(18) = newDR.Item("type_of_purchasing").ToString
                            a(19) = newDR.Item("remarks").ToString
                            a(22) = "-"
                            a(23) = newDR.Item("qty").ToString
                            a(24) = newDR.Item("username").ToString
                            a(25) = newDR.Item("ws_id").ToString
                            a(28) = newDR.Item("requested_by").ToString
                            a(29) = newDR.Item("cons_item").ToString
                            a(31) = newDR.Item("type_of_delivery").ToString
                            a(33) = newDR.Item("wh_area").ToString
                            a(35) = newDR.Item("rr_item_id").ToString
                        End If

                        a(36) = newDR.Item("po_no").ToString

                    Case "C"
                        a(1) = "-"
                        a(4) = "      " & ChrW(155) & " " & newDR.Item("items").ToString
                        a(5) = "-"
                        a(8) = newDR.Item("type_of_request").ToString
                        a(10) = "-"
                        a(11) = "- received"
                        a(12) = "N/A"
                        a(17) = newDR.Item("type_of_charges").ToString
                        a(18) = newDR.Item("type_of_purchasing").ToString
                        a(19) = newDR.Item("remarks").ToString
                        a(22) = "-"
                        a(23) = newDR.Item("qty").ToString
                        a(24) = newDR.Item("username").ToString
                        a(25) = newDR.Item("ws_id").ToString
                        a(28) = newDR.Item("requested_by").ToString
                        a(29) = newDR.Item("cons_item").ToString
                        a(31) = newDR.Item("type_of_delivery").ToString
                        a(33) = newDR.Item("wh_area").ToString
                        a(35) = newDR.Item("rr_item_id").ToString
                        a(36) = newDR.Item("rr_no").ToString

                End Select

                a(9) = newDR.Item("IN_OUT").ToString
                a(37) = newDR.Item("qto_items").ToString
                a(38) = newDR.Item("qto_id").ToString

                Dim lvl As New ListViewItem(a)
                lvlrequisitionlist.Items.Add(lvl)

                If newDR.Item("sorting").ToString = "A" Then
                    lvlrequisitionlist.Items(counter).BackColor = Color.DarkGreen
                    lvlrequisitionlist.Items(counter).ForeColor = Color.White
                    lvlrequisitionlist.Items(counter).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Bold)
                ElseIf newDR.Item("sorting").ToString = "B" Then
                    lvlrequisitionlist.Items(counter).BackColor = Color.LightGreen
                    lvlrequisitionlist.Items(counter).Font = New Font(New FontFamily("Arial"), 9, FontStyle.Bold)
                ElseIf newDR.Item("sorting").ToString = "C" Then
                    lvlrequisitionlist.Items(counter).BackColor = Color.LightYellow
                    lvlrequisitionlist.Items(counter).Font = New Font(New FontFamily("Arial"), 8, FontStyle.Bold)
                    'lvlrequisitionlist.Items(counter).Font.Size = "11pt"
                End If

                counter += 1
                Application.DoEvents()

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("Error MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Public Sub load_rs_4()
        lvlrequisitionlist.Items.Clear()
        Dim row As Integer

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_requisition_slip", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 133)
            newCMD.Parameters.AddWithValue("@searchby", txtSearch.Text)

            newDR = newCMD.ExecuteReader

            Dim a(40) As String

            While newDR.Read
                a(0) = newDR.Item("rs_id").ToString
                a(1) = newDR.Item("rs_no").ToString
                a(2) = IIf(Format(Date.Parse(newDR.Item("date_req").ToString), "MM/dd/yyyy") = "01/01/1900", "", Format(Date.Parse(newDR.Item("date_req").ToString), "MM/dd/yyyy"))
                a(3) = newDR.Item("job_order_no").ToString
                a(4) = newDR.Item("item_desc").ToString
                a(7) = Format(Date.Parse(newDR.Item("date_needed").ToString), "MM/dd/yyyy")
                a(32) = newDR.Item("dr_qty").ToString
                a(33) = newDR.Item("wh_area").ToString
                a(29) = newDR.Item("cons_item").ToString
                a(30) = newDR.Item("cons_item_desc").ToString
                a(5) = newDR.Item("rs_qty").ToString
                a(15) = newDR.Item("wh_id").ToString
                a(21) = newDR.Item("dr_no").ToString
                a(9) = newDR.Item("IN_OUT").ToString


                Dim lvl As New ListViewItem(a)

                lvlrequisitionlist.Items.Add(lvl)

                row += 1

                If a(0) = 0 Then
                    lvlrequisitionlist.Items(row - 1).BackColor = Color.LightGreen
                    lvlrequisitionlist.Items(row - 1).ForeColor = Color.Black
                    lvlrequisitionlist.Items(row - 1).Font = New Font(lvlrequisitionlist.Font, FontStyle.Bold)
                End If


            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Public Sub loading()
        'Floading.ShowDialog()

    End Sub
    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If cmbSearchByCategory.Text = "Search by item" Then
                    ListView2.Items(0).Selected = True
                    ListView2.SelectedItems(0).EnsureVisible()
                    ListView2.Focus()
                    Exit Sub
                Else
                    btnSearch.PerformClick()
                End If

            ElseIf e.KeyCode = Keys.Down Then
                If cmbSearchByCategory.Text = "Search by item" Then
                    ListView2.Items(0).Selected = True
                    ListView2.SelectedItems(0).EnsureVisible()
                    ListView2.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        If cmbSearchByCategory.Text = "Search by item" Then
            Timer6.Stop()
            Timer7.Stop()

            If txtSearch.Text = "Items..." Then
                Panel11.Visible = False
                Exit Sub
            End If

            'FOR ITEM SEARCH PANEL VISIBILITY
            Panel11.Parent = Me
            Panel11.Location = New Point(txtSearch.Location.X, FlowLayoutPanel1.Location.Y - Panel11.Height)
            'ListView2.Location = New Point(ListView2.Location.X, ListView2.Height)
            Panel11.Visible = True

            ListView2.Items.Clear()

            With ST_Data

                .search = txtSearch.Text
                .panel1 = Panel11
                .lvl = ListView2
                .txtsearch = txtSearch
                .panel2 = Panel12
            End With

            If txtSearch.Text = "" Then
                Panel11.Visible = False
                Exit Sub
            End If

            Timer6.Start()


        End If
    End Sub

    Private Sub cmbSearchByCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSearchByCategory.SelectedIndexChanged
        If cmbSearchByCategory.Text = "Filter by month of Date Request" Then
            If cmbDivision.Text = "" Then
                MessageBox.Show("Please select the category either:" & vbCrLf & vbCrLf & "'WAREHOUSING AND SUPPLY'" & vbCrLf & "'CRUSHING AND HAULING'", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Panel_date_duration.Visible = True
            txtSearch.Enabled = False
            btnSearch.Enabled = False
            dtpto.Enabled = True

            Dim lvl_height, lvl_width As Integer

            lvl_height = lvlrequisitionlist.Height
            lvl_width = lvlrequisitionlist.Width


            lvl_height = (lvl_height / 2) - (Panel_date_duration.Height / 2)
            lvl_width = (lvl_width / 2) - (Panel_date_duration.Width / 2)

            Panel_date_duration.Location = New Point(lvl_width, lvl_height)
            FMaterials_ToolsTurnOverTextFields.get_whItem(0, cmbProject1)
            txtItemName.Visible = False

            cmbTypeOfRequest.Enabled = False
            ComboBox1.Enabled = False

        ElseIf cmbSearchByCategory.Text = "Search by Date Input" Then
            Panel_date_duration.Visible = True
            txtSearch.Enabled = False
            btnSearch.Enabled = False
            dtpto.Enabled = False


            Dim lvl_height, lvl_width As Integer

            lvl_height = lvlrequisitionlist.Height
            lvl_width = lvlrequisitionlist.Width


            lvl_height = (lvl_height / 2) - (Panel_date_duration.Height / 2)
            lvl_width = (lvl_width / 2) - (Panel_date_duration.Width / 2)

            Panel_date_duration.Location = New Point(lvl_width, lvl_height)
            FMaterials_ToolsTurnOverTextFields.get_whItem(0, cmbProject1)
            txtItemName.Visible = False

        ElseIf cmbSearchByCategory.Text = "Search by JO.No." Then
            Panel_date_duration.Visible = False
            txtSearch.Enabled = True
            btnSearch.Enabled = True
            txtItemName.Visible = False
            txtSearch.Focus()
        ElseIf cmbSearchByCategory.Text = "Search by RS.No." Then
            Panel_date_duration.Visible = False
            txtSearch.Enabled = True
            btnSearch.Enabled = True
            txtItemName.Visible = False
            txtSearch.Focus()
        ElseIf cmbSearchByCategory.Text = "Search by Type of Purchasing" Then
            Panel_date_duration.Visible = False
            txtSearch.Enabled = True
            btnSearch.Enabled = True
            txtItemName.Visible = False
            txtSearch.Focus()

        ElseIf cmbSearchByCategory.Text = "Search by item" Then
            'temporary disable 
            'load_type_of_charges_name(ComboBox3)
            cmbEnableDisable.Text = "DISABLE"

            Panel_date_duration.Visible = False
            txtSearch.Enabled = True
            btnSearch.Enabled = False
            txtItemName.Visible = False
            txtSearch.Focus()

        ElseIf cmbSearchByCategory.Text = "Search by Input by" Or cmbSearchByCategory.Text = "Search by User Name" Then
            'Panel_date_duration.Visible = False
            txtSearch.Enabled = True
            btnSearch.Enabled = True
            txtSearch.Visible = True
            txtItemName.Visible = True

            txtSearch.Focus()
            Exit Sub
        ElseIf cmbSearchByCategory.Text = "Search by Charge To" Then
            'Panel_date_duration.Visible = False
            'txtSearch.Enabled = True
            'btnSearch.Enabled = True
            'txtItemName.Visible = False
            'txtSearch.Focus()
            If cmbDivision.Text = "" Then
                MessageBox.Show("Please select the category either:" & vbCrLf & vbCrLf & "'WAREHOUSING AND SUPPLY'" & vbCrLf & "'CRUSHING AND HAULING'", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Panel_date_duration.Visible = True
            txtSearch.Enabled = False
            btnSearch.Enabled = False
            dtpto.Enabled = True

            Dim lvl_height, lvl_width As Integer

            lvl_height = lvlrequisitionlist.Height
            lvl_width = lvlrequisitionlist.Width


            lvl_height = (lvl_height / 2) - (Panel_date_duration.Height / 2)
            lvl_width = (lvl_width / 2) - (Panel_date_duration.Width / 2)

            Panel_date_duration.Location = New Point(lvl_width, lvl_height)
            FMaterials_ToolsTurnOverTextFields.get_whItem(0, cmbProject1)
            txtItemName.Visible = False

            FRequestField.load_type_of_request_and_sub(1, cmbTypeOfRequest, 0)
            cmbTypeOfRequest.Enabled = True


        ElseIf cmbSearchByCategory.Text = "Search by item from others" Then
            Panel_date_duration.Visible = False
            txtSearch.Enabled = True
            btnSearch.Enabled = True
            txtItemName.Visible = False
            txtSearch.Focus()
        ElseIf cmbSearchByCategory.Text = "Search by Date Request" Then
            Panel_date_duration.Visible = False
            txtSearch.Enabled = True
            btnSearch.Enabled = True
            txtItemName.Visible = False
            txtSearch.Focus()
        ElseIf cmbSearchByCategory.Text = "Search by Cash Rs.No." Or cmbSearchByCategory.Text = "Search by Borrower Slip No." Or cmbSearchByCategory.Text = "Search by Requested by" Then
            Panel_date_duration.Visible = False
            txtSearch.Enabled = True
            btnSearch.Enabled = True
            txtItemName.Visible = False
            txtSearch.Focus()

        ElseIf cmbSearchByCategory.Text = "Search by Type of Request/Sub" Then

            btnSearch.Enabled = True
            txtSearch.Visible = True
            txtItemName.Visible = True

            txtSearch.Focus()
            Exit Sub
        End If

        Select Case cmbSearchByCategory.Text

            Case "Search by Date Request"
                dtpsearchdatereq.Visible = True
                dtpsearchdatereq.Location = New Point(12, 77)
                dtpsearchdatereq.Width = txtSearch.Width
                txtSearch.Visible = False
                txtItemName.Visible = False

            Case Else
                txtSearch.Visible = True
                dtpsearchdatereq.Visible = False
                txtItemName.Visible = False

        End Select

        If cmbSearchByCategory.Text = "Search by Charges (Specific Item)" Then

            txtSearch.Enabled = True
            btnSearch.Enabled = False
            btnSelectItem.Enabled = True
            txtItemName.Visible = False
            txtSearch.Focus()

        ElseIf cmbSearchByCategory.Text = "Search by item (Item Checked only)" Then

            txtSearch.Enabled = False
            btnSearch.Enabled = False
            btnSelectItem.Enabled = True
            txtItemName.Visible = False
            txtSearch.Focus()

        ElseIf cmbSearchByCategory.Text = "Search by Charges" Then

            btnSearch.Enabled = True
            btnSelectItem.Enabled = False
            txtItemName.Visible = True

            If cmbDivision.Text = "WAREHOUSING AND SUPPLY" Then
                txtItemName.Enabled = True
                txtSearch.Enabled = True
            Else
                txtItemName.Enabled = False
                txtSearch.Enabled = False
            End If

            txtSearch.Focus()

        ElseIf cmbSearchByCategory.Text = "Generate Summary of Hauling Aggregates" Then
            txtSearch.Visible = False
            btnSearch.Enabled = True
            btnSelectItem.Enabled = False
            txtItemName.Visible = False

            txtSearch.Focus()
            Exit Sub
        ElseIf cmbSearchByCategory.Text = "Search by Requested by" Then
            txtSearch.Enabled = True
            btnSearch.Enabled = True
            btnSelectItem.Enabled = False
            txtItemName.Visible = True

            txtSearch.Focus()

        ElseIf cmbSearchByCategory.Text = "Search by JO" Then
            txtSearch.Enabled = True
            btnSearch.Enabled = True
            btnSelectItem.Enabled = False
            txtItemName.Visible = False

            txtSearch.Focus()
        Else

            txtSearch.Enabled = True
            'btnSearch.Enabled = True
            btnSelectItem.Enabled = False
            txtItemName.Visible = False

        End If
    End Sub

    Private Sub lblSearchByCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSearchByCategory.Click

    End Sub

    Private Sub btnSearchDuration_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchDuration.Click
        'If cmbSearchByCategory.Text = "Filter by month of Date Request" Then
        '    load_rs_3(29)
        'ElseIf cmbSearchByCategory.Text = "Search by Date Input" Then
        '    load_rs_3(14)
        'ElseIf cmbSearchByCategory.Text = "Search by Type of Request" Then
        '    If ComboBox1.Text = "YES" Then
        '        load_rs_3(32)
        '    Else
        '        load_rs_3(13)
        '    End If

        'End If


        If ComboBox2.Text = "" Then
            MessageBox.Show("Please, select a search by first..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Question)
            Exit Sub
        ElseIf ComboBox2.Text = "Search by Specific Project" Then
            lvlrequisitionlist.Items.Clear()
        End If

        dtp_from = dtpfrom.Text
        dtp_to = dtpto.Text
        dr_items = txtRsNo.Text

        Panel_date_duration.Visible = False
        Button7.PerformClick()
        Exit Sub


        '----------CONDEM--------------

        FDRLIST.lvl_drList.Items.Clear()

        For Each row As ListViewItem In lvlrequisitionlist.Items

            Select Case cmbTypeOfRequest.Text
                Case "Search By Month"

                    If Date.Parse(row.SubItems(2).Text).Month & "/" & Date.Parse(row.SubItems(2).Text).Year =
                     Date.Parse(dtpfrom.Text).Month & "/" & Date.Parse(dtpfrom.Text).Year Then

                        If row.SubItems(41).Text = "" Or row.SubItems(41).Text = "WITH DR" Then
                        Else
                            load_dr(row.SubItems(41).Text, row.SubItems(42).Text)
                        End If
                    End If

                Case "Search By RS No."
                    If row.SubItems(41).Text = "" Or row.SubItems(41).Text = "WITH DR" Then
                    Else
                        If row.SubItems(1).Text.Contains(txtRsNo.Text) Then
                            load_dr(row.SubItems(41).Text, row.SubItems(42).Text)
                        End If

                        If txtRsNo.Text = "" Then
                            load_dr(row.SubItems(41).Text, row.SubItems(42).Text)
                        End If
                    End If

                Case "Search By DR No."
                    If row.SubItems(41).Text = "" Or row.SubItems(41).Text = "WITH DR" Then
                    Else
                        If row.SubItems(21).Text.Contains(txtRsNo.Text) Then
                            load_dr(row.SubItems(41).Text, row.SubItems(42).Text)
                        End If

                        If txtRsNo.Text = "" Then
                            load_dr(row.SubItems(41).Text, row.SubItems(42).Text)
                        End If
                    End If

                Case "Search By WS No."
                    If row.SubItems(41).Text = "" Or row.SubItems(41).Text = "WITH DR" Then
                    Else
                        If row.SubItems(36).Text.Contains(txtRsNo.Text) Then
                            load_dr(row.SubItems(41).Text, row.SubItems(42).Text)
                        End If

                        If txtRsNo.Text = "" Then
                            load_dr(row.SubItems(41).Text, row.SubItems(42).Text)
                        End If
                    End If
            End Select
        Next

        FDRLIST.Show()
    End Sub
    Private Function DoesMatchWildcardString(ByVal fullString As String, ByVal wildcardString As String) As Boolean
        Dim count As Integer = 1
        Dim wildchr As String
        Dim fschr As String
        Dim resultstring As String = String.Empty

        Do Until count - 1 = Len(wildcardString)
            wildchr = Mid$(wildcardString, count, 1)
            fschr = Mid$(fullString, count, 1)
            If wildchr = "*" Then ' this one matches any char
                resultstring = resultstring & fschr
            Else
                If wildchr = fschr Then
                    resultstring = resultstring & fschr
                End If
            End If
            count = count + 1
        Loop
        Return resultstring = fullString
    End Function

    Private Sub btnExit_panel_duration_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit_panel_duration.Click
        Panel_date_duration.Visible = False
        txtSearch.Enabled = True
        btnSearch.Enabled = True
        'cmbSearchByCategory.Text = "Search by RS.No."

        dtpfrom.Enabled = True
        'DTP_to.Enabled = True
        cmbTypeOfRequest.Enabled = False
        cmbProject1.Items.Clear()
        cmbItemDesc.Items.Clear()
        ComboBox1.Enabled = False

    End Sub

    Private Sub btnExit_panel_duration_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnExit_panel_duration.MouseDown
        btnExit_panel_duration.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_panel_duration_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit_panel_duration.MouseEnter
        btnExit_panel_duration.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_panel_duration_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit_panel_duration.MouseLeave
        btnExit_panel_duration.BackgroundImage = My.Resources.close_button
    End Sub

    Private Sub Panel_date_duration_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel_date_duration.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Panel_date_duration.Left
        mousey = Windows.Forms.Cursor.Position.Y - Panel_date_duration.Top
    End Sub

    Private Sub Panel_date_duration_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel_date_duration.MouseMove
        If drag Then
            Panel_date_duration.Top = Windows.Forms.Cursor.Position.Y - mousey
            Panel_date_duration.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Panel_date_duration_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel_date_duration.MouseUp
        drag = False
    End Sub

    Private Sub CreateCashVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateCashVoucherToolStripMenuItem.Click
        for_print_po = False

        If lvlrequisitionlist.SelectedItems(0).SubItems(18).Text = "DR" Or lvlrequisitionlist.SelectedItems(0).SubItems(18).Text = "WITHDRAWAL" Then
            MessageBox.Show("This function is not intended for PO/CV..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        ElseIf lvlrequisitionlist.SelectedItems(0).SubItems(18).Text = "CASH WITH RR" Then
            MessageBox.Show("Sorry, this function is not applicable at this time - Programmer KJ", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        Dim inout As String = lvlrequisitionlist.SelectedItems(0).SubItems(9).Text
        show_po_cv_ws(inout)

    End Sub

    Public Sub show_cash_voucher_form()
        'If lvlrequisitionlist.SelectedItems(0).SubItems(10).Text = "PENDING" Or lvlrequisitionlist.SelectedItems(0).SubItems(10).Text = "PO PENDING" Then
        '    MessageBox.Show("No Purchase Order", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'ElseIf lvlrequisitionlist.SelectedItems(0).SubItems(10).Text = "PURCHASED" Then
        '    MessageBox.Show("Already Purchased", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Else
        public_rs_id = lvlrequisitionlist.SelectedItems(0).Text
        get_data_from_requisitionslip(lvlrequisitionlist.SelectedItems(0).Text)
        FCashVoucher.txtChargeTo.Text = lvlrequisitionlist.SelectedItems(0).SubItems(13).Text
        FCashVoucher.txtRSNo.Text = lvlrequisitionlist.SelectedItems(0).SubItems(1).Text
        FCashVoucher.ShowDialog()
        'End If

    End Sub

    Private Sub CreateChargesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FCreateCharges.ShowDialog()

    End Sub
    Public Function check_mother_volume_if_exist()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT * FROM dbrequisition_slip WHERE rs_no = '" & lvlrequisitionlist.SelectedItems(0).SubItems(1).Text & "' AND original_volume = '" & "A" & "'"
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            Dim a(10) As String

            While newDR.Read
                check_mother_volume_if_exist += 1
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        If lvlrequisitionlist.SelectedItems(0).SubItems(18).Text = "CASH WITH RR" Or lvlrequisitionlist.SelectedItems(0).SubItems(18).Text = "CASH WITHOUT RR" Then

            Dim s As String = lvlrequisitionlist.SelectedItems(0).SubItems(8).Text
            Dim words As String() = s.Split(New Char() {"-"c})

            FRequisition_Non_Item.Show()
            Dim rs_id As Integer = CInt(lvlrequisitionlist.SelectedItems(0).SubItems(0).Text)
            get_Frequisition_non_item_Data(rs_id)
            get_Frequisition_non_item_multicharges_data(rs_id)
            With FRequisition_Non_Item
                '.txtItemDesc.Text = lvlrequisitionlist.SelectedItems(0).SubItems(4).Text
                .txtRSno.Text = lvlrequisitionlist.SelectedItems(0).SubItems(1).Text
                .txtLoc.Text = lvlrequisitionlist.SelectedItems(0).SubItems(14).Text
                .DTPReq.Text = lvlrequisitionlist.SelectedItems(0).SubItems(2).Text
                .txtJOno.Text = lvlrequisitionlist.SelectedItems(0).SubItems(3).Text
                .txtQty.Text = lvlrequisitionlist.SelectedItems(0).SubItems(5).Text
                .txtUnit.Text = lvlrequisitionlist.SelectedItems(0).SubItems(6).Text
                .DTPTimeNeeded.Text = lvlrequisitionlist.SelectedItems(0).SubItems(7).Text
                .txtRequestBy.Text = lvlrequisitionlist.SelectedItems(0).SubItems(28).Text
                .cmbCash_wrr_worr.Text = lvlrequisitionlist.SelectedItems(0).SubItems(18).Text
                .txtRemarksForEmd.Text = lvlrequisitionlist.SelectedItems(0).SubItems(50).Text
                .cmbRequestType.Text = words(0).TrimEnd
                .cmbTOR_sub.Text = words(1).Remove(0, 1)
                .lbl_rs_id.Text = rs_id
                .cmbRequestType.Focus()
                .btnSave.Text = "Save"
            End With

        Else
            Dim rowcount As Integer = lvlrequisitionlist.Items.Count - 1

            '******************** kwaon ang main rs qty *****************
            For Each row As ListViewItem In lvlrequisitionlist.Items
                If row.BackColor = Color.White Then
                    If row.Index = rowcount Then
                        If lvlrequisitionlist.SelectedItems(0).Index < row.Index Then
                            'MsgBox(row.SubItems(5).Text)
                            pub_rs_main_qty = row.SubItems(5).Text
                            Exit For
                        End If
                    Else
                        If lvlrequisitionlist.Items(row.Index + 1).BackColor = Color.Yellow Then

                            If lvlrequisitionlist.SelectedItems(0).Index < row.Index Then
                                'MsgBox(row.SubItems(5).Text)
                                pub_rs_main_qty = row.SubItems(5).Text
                                Exit For
                            End If
                        End If
                    End If
                End If
            Next
            '*************************************************************

            button_click_name = "CopyToolStripMenuItem"

            If cmbSearchByCategory.Text = "Search by RS.No." Then
                If cmbDivision.Text = "CRUSHING AND HAULING" Then
                    If lvlrequisitionlist.SelectedItems(0).SubItems(5).Text = "" Then
                        MessageBox.Show("Unable to copy this data, rs main qty has not been set.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub

                    ElseIf lvlrequisitionlist.SelectedItems(0).SubItems(5).Text = "OPEN QTY" Then
                        MessageBox.Show("Unable to copy this data, rs main qty is open!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If

                    '********* RS QTY LEFT *******************
#Region "RS QTY LEFT"



#End Region
                    'Dim rs_qty As Decimal = lvlrequisitionlist.SelectedItems(0).SubItems(5).Text
                    'Dim copy As New Class_Copy
                    ''Dim remaining_balance As Decimal = rs_qty - copy.calc_cut_request(lvlrequisitionlist, lvlrequisitionlist.SelectedItems(0).SubItems(1).Text)

                    'Dim main_rs_qty_id As Integer = lvlrequisitionlist.SelectedItems(0).Text
                    'Dim cRs_no As String = lvlrequisitionlist.SelectedItems(0).SubItems(1).Text

                    'Dim remaining_balance As Double = copy.get_remaining_balance(main_rs_qty_id, cRs_no)

                    'If remaining_balance <= 0 Then
                    '    MessageBox.Show("Unable to copy data, the qty you are trying to copy exceeds to limit.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    '    Exit Sub
                    'Else
                    '    pub_main_rs_qty_left = remaining_balance
                    'End If

                    Dim remaining_balance As Double = DRModel.getRemainingBalance(lvlrequisitionlist.SelectedItems(0).Text)

                    If remaining_balance <= 0 Then
                        MessageBox.Show("Unable to copy data, the qty you are trying to copy exceeds to limit.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    Else
                        pub_main_rs_qty_left = remaining_balance
                    End If
                    '*****************************************

                    If lvlrequisitionlist.Items(lvlrequisitionlist.SelectedItems(0).Index + 1).BackColor = Color.Blue Then
                        'kini nga code mangita siya og rs_id sa listview para mao iyang copyhan nga data
                        For Each row As ListViewItem In lvlrequisitionlist.Items
                            If row.BackColor = Color.DarkGreen Then
                                copy_data_from_rs(row.Text)
                                FRequestField.txtQty.Text = pub_main_rs_qty_left
                                FRequestField.Show()
                                Exit For
                            End If
                        Next

                    ElseIf lvlrequisitionlist.Items(lvlrequisitionlist.SelectedItems(0).Index + 1).BackColor = Color.DarkGreen Then
                        copy_data_from_rs(lvlrequisitionlist.Items(lvlrequisitionlist.SelectedItems(0).Index + 1).Text)
                        FRequestField.txtQty.Text = pub_main_rs_qty_left
                        FRequestField.Show()

                    End If
                    Exit Sub
                Else

                End If
            Else
                MessageBox.Show("NOTE: Copy function is only applicable in 'Search by Rs.No.'", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If



            Dim splitrsqty As Decimal
            Dim originalqty As Decimal



            'get the main rs qty
            For Each row As ListViewItem In lvlrequisitionlist.Items
                'If row.BackColor = Color.Lime Then
                '    pub_main_rs_qty = row.SubItems(5).Text

                'ElseIf row.BackColor = Color.Yellow Then
                '    pub_main_rs_qty_left = row.SubItems(5).Text
                'End If
                If row.BackColor = Color.White Then
                    pub_main_rs_qty_left = row.SubItems(5).Text
                End If
            Next


            For Each row As ListViewItem In lvlrequisitionlist.Items
                If row.BackColor = Color.DarkGreen Then
                    splitrsqty += CDec(row.SubItems(5).Text)
                ElseIf row.BackColor = Color.Yellow Then
                    'originalqty += row.SubItems(5).Text
                End If
            Next

            If (originalqty - splitrsqty) = 0 Then
                MessageBox.Show("exceed to original quantity.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            Dim sp() As String
            Dim vql As String

            vql = lvlrequisitionlist.SelectedItems(0).SubItems(3).Text


            ''check kong naa naba mother volume
            'If check_mother_volume_if_exist() > 0 Then
            '    sep_qty_volume = False
            'Else
            '    'If MessageBox.Show("Do you want to copy this data without affecting qty volume?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            '    '    sep_qty_volume = True
            '    'Else
            '    '    sep_qty_volume = False
            '    'End If
            '    sep_qty_volume = True
            'End If

            button_click_name = "CopyToolStripMenuItem"

            Dim wh_id As Integer = lvlrequisitionlist.SelectedItems(0).SubItems(15).Text
            Dim rs_no As String = lvlrequisitionlist.SelectedItems(0).SubItems(1).Text

            Dim calc As Double = 0
            Dim qty_left As Double = 0

            FRequestField.Show()
            Dim rs_id As Integer = CInt(lvlrequisitionlist.SelectedItems(0).Text)

            FRequestField.cmbRequestType.Text = get_type_of_request(rs_id, "type of request")
            FRequestField.cmbTOR_sub.Text = get_type_of_request(rs_id, "sub of type of request")
            FRequestField.cmbInOut.Text = get_type_of_request(rs_id, "inout")

            GET_REQUISITION_SLIP_DATA2(rs_id)
            FRequestField.pboxcharges.Visible = False

            For Each ctr As Control In FRequestField.Controls
                If ctr.Name = "pboxcharges" Then
                    ctr.Visible = False
                Else
                    ctr.Enabled = True
                End If
            Next

            FRequestField.txtChargeTo.Enabled = False
            FRequestField.cmbInOut.SelectedIndex = -1
            FRequestField.cmbTypeOfPurchase.SelectedIndex = -1


            Dim po, rr, ws As String
            po = lvlrequisitionlist.SelectedItems(0).SubItems(10).Text
            rr = lvlrequisitionlist.SelectedItems(0).SubItems(11).Text
            ws = lvlrequisitionlist.SelectedItems(0).SubItems(12).Text

            FRequestField.txtItemDesc.Focus()
            FRequestField.btnViewMultipleCharges.Enabled = False

            FRequestField.txtApprovedby.Enabled = False
            FRequestField.txtWarehouseIncharge.Enabled = False

            FRequestField.cmbTypeofCharge.SelectedIndex = 0

            If ws = "WITHDRAWN" Then
                FRequestField.PictureBox2.Enabled = False
                FRequestField.PictureBox2.Image = My.Resources.Plus_sign_neg

                If FRequestField.cmbInOut.Text = "OTHERS" Then
                    FRequestField.txtItemDesc.Enabled = True
                    FRequestField.PictureBox2.Enabled = False
                    FRequestField.PictureBox2.Image = My.Resources.Plus_sign_neg
                End If

                Exit Sub

            ElseIf ws = "N/A" Then
                If lvlrequisitionlist.SelectedItems(0).SubItems(11).Text = "RECEIVED" Or lvlrequisitionlist.SelectedItems(0).SubItems(11).Text = "CV RELEASED" Then
                    FRequestField.PictureBox2.Enabled = False
                    FRequestField.PictureBox2.Image = My.Resources.Plus_sign_neg

                    If FRequestField.cmbInOut.Text = "OTHERS" Then
                        FRequestField.txtItemDesc.Enabled = True
                        FRequestField.PictureBox2.Enabled = False
                        FRequestField.PictureBox2.Image = My.Resources.Plus_sign_neg

                    End If

                    Exit Sub
                Else
                    FRequestField.PictureBox2.Enabled = True
                    FRequestField.PictureBox2.Image = My.Resources.Plus_sign

                    If FRequestField.cmbInOut.Text = "OTHERS" Then
                        FRequestField.txtItemDesc.Enabled = True
                        FRequestField.PictureBox2.Enabled = False
                        FRequestField.PictureBox2.Image = My.Resources.Plus_sign_neg

                    End If
                    Exit Sub
                End If
            End If
        End If

        'FRequestField.txtQty.Text = originalqty - splitrsqty

    End Sub
    Private Sub copy_data_from_rs(rs_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_copy_rs_data", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 1)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                With FRequestField

                    .cmbRequestType.Text = newDR.Item("tor_desc").ToString
                    .cmbTOR_sub.Text = newDR.Item("tor_sub_desc").ToString
                    .cmbContractName.Text = newDR.Item("cons_item_desc").ToString
                    .txtQtyTakeOff.Text = newDR.Item("qto_item_desc").ToString
                    .txtItemDesc.Text = newDR.Item("item_desc").ToString
                    .txtRSno.Text = newDR.Item("rs_no").ToString
                    .cmbTypeofCharge.Text = newDR.Item("process").ToString
                    .txtLoc.Text = newDR.Item("location").ToString
                    .DTPReq.Text = Date.Parse(newDR.Item("date_req").ToString)
                    .txtJOno.Text = newDR.Item("job_order_no").ToString
                    .txtQty.Text = newDR.Item("qty").ToString
                    .txtUnit.Text = newDR.Item("unit").ToString
                    .txtPurpose.Text = newDR.Item("purpose").ToString
                    .DTPTimeNeeded.Text = Date.Parse(newDR.Item("date_needed").ToString)
                    .txtRequestBy.Text = newDR.Item("requested_by").ToString
                    .txtNotedBy.Text = newDR.Item("noted_by").ToString
                    .txtApprovedby.Text = newDR.Item("approved_by").ToString
                    .txtWarehouseIncharge.Text = newDR.Item("wh_incharge").ToString
                    .lboxUnit.Visible = False
                End With
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Private Sub CreateChargesToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateChargesToolStripMenuItem.Click
        FProjectIncharge.lbl_sign.Text = "R"
        whouse_rs_selection = True

        FProjectIncharge.btnOk.Text = "Create Charges"
        FProjectIncharge.ShowDialog()

    End Sub

    Private Sub EquipmentUseForHaulingToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles EquipmentUseForHaulingToolStripMenuItem.Click

        Try

            CDR = New FCreateDeliveryReceipt
            With CDR
                If lvlrequisitionlist.SelectedItems.Count > 0 Then
                    Dim selectedItem As ListViewItem = lvlrequisitionlist.SelectedItems(0)
                    Dim TYPEOFPURCHASING As String = selectedItem.SubItems(18).Text

                    If TYPEOFPURCHASING = cTypeOfPurchasing.WITHDRAWAL Then

                        If selectedItem.SubItems(12).Text = "pending" Then
                            customMsg.message("error", "ws status must not be pending", "SUPPLY INFO:")
                            Exit Sub
                        End If

                        .ReleasedQty = selectedItem.SubItems(23).Text

                        .DeliveredQty = totalDeliveredQty(selectedItem.SubItems(36).Text,
                                                          cTypeOfPurchasing.WITHDRAWAL)

                        With .cStockpileOut

                            .wh_id = selectedItem.SubItems(15).Text
                            .charges = selectedItem.SubItems(13).Text
                            .typeOfPurchasing = TYPEOFPURCHASING
                            .rs_id = selectedItem.Text
                            .wsNoRrNo = selectedItem.SubItems(36).Text
                            .rsNo = selectedItem.SubItems(1).Text
                            .units = selectedItem.SubItems(6).Text

                        End With

                        .cTypeOfPurchasing1 = TYPEOFPURCHASING
                        .cWithDr = True
                        .cDrOption = DROptions.out_with_rs

                        .ShowDialog()
                    Else
                        Dim _a = DRModel.GetListOfRR().Where(Function(x)
                                                                 Return x.rr_no = selectedItem.SubItems(36).Text
                                                             End Function).ToList()

                        With .cStockpileIn
                            .wh_id = selectedItem.SubItems(15).Text
                            .charges = selectedItem.SubItems(13).Text
                            .typeOfPurchasing = TYPEOFPURCHASING
                            .rs_id = selectedItem.Text
                            .units = selectedItem.SubItems(6).Text

                            If TYPEOFPURCHASING = cTypeOfPurchasing.PURCHASE_ORDER Then
                                If _a.Count > 0 Then
                                    .supplier = _a(0).supplier

                                End If

                            End If
                        End With

                        If TYPEOFPURCHASING = cTypeOfPurchasing.DR And selectedItem.BackColor = cRsRowColor.MainSubRS Then
                            .ReleasedQty = selectedItem.SubItems(5).Text

                            .DeliveredQty = totalDeliveredQty(,
                                                              cTypeOfPurchasing.DR,
                                                              selectedItem.Text)


                            .cStockpileIn.wsNoRrNo = selectedItem.SubItems(1).Text

#Region "DR OPTIONS"
                            If selectedItem.SubItems(9).Text = cInOut._OTHERS Then
                                .cDrOption = DROptions.others_with_rs
                            ElseIf selectedItem.SubItems(9).Text = cInOut._IN Then
                                .cDrOption = DROptions.in_with_rs
                            End If
#End Region

#Region "OPEN/CLOSED QTY"
                            Dim mainRsSub = DRModel.GetListOfMainRsSub().Where(Function(x) x.rs_id = selectedItem.Text).ToList()
                            If mainRsSub.Count > 0 Then
                                Dim mainRs = DRModel.GetListOfMainRs().Where(Function(x) x.main_rs_qty_id = mainRsSub(0).main_rs_qty_id).ToList()

                                If mainRs.Count > 0 Then
                                    If mainRs(0).open_close_qty = 1 Then
                                        .cOpened = True
                                    End If
                                End If
                            End If
#End Region

                        ElseIf TYPEOFPURCHASING = cTypeOfPurchasing.PURCHASE_ORDER And selectedItem.BackColor = cRsRowColor.Rr Then
                            .ReleasedQty = selectedItem.SubItems(23).Text

                            .DeliveredQty = totalDeliveredQty(selectedItem.SubItems(36).Text,
                                                              cTypeOfPurchasing.PURCHASE_ORDER)
                            .cStockpileIn.wsNoRrNo = selectedItem.SubItems(36).Text
#Region "DR OPTIONS"
                            .cDrOption = DROptions.in_with_rs_po_rr
#End Region

#Region "DEFAULT PRICE"
                            .cStockpileIn.defaultPrice = selectedItem.SubItems(43).Text
#End Region

                        End If

                        .cTypeOfPurchasing1 = TYPEOFPURCHASING
                        .cWithDr = True

                        .ShowDialog()
                    End If

                End If

            End With

        Catch ex As Exception
            Dim cc As New customMessageBox
            cc.ErrorMessage(ex)
        End Try
        Exit Sub

        '============================== BELOW OF THIS COMMENT WERE CONDEMED BUT DONT DELETE =================================

        Dim sortDR As New List(Of class_exclusive_aggregates.drdata)
        sortDR = cAggregates.LISTOFDR

        If lvlrequisitionlist.SelectedItems(0).BackColor = Color.LightGreen Then 'LIGHTGREEN

            Dim ws_no As String = lvlrequisitionlist.SelectedItems(0).SubItems(36).Text
            Dim ws_qty As Double = Utilities.ifBlankReplaceToZero(lvlrequisitionlist.SelectedItems(0).SubItems(23).Text)
            Dim rs_id As Integer = Utilities.ifBlankReplaceToZero(lvlrequisitionlist.SelectedItems(0).Text)

            Dim count_drqty As Double

            For Each dr In sortDR
                If dr.ws_no = ws_no And rs_id = dr.rs_id Then
                    count_drqty += dr.dr_qty
                End If
            Next

            If ws_qty = count_drqty And ws_qty <> 0 Then
                MessageBox.Show("all dr qty has been released!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            ElseIf ws_qty = 0 Then
                customMsg.message("error", "The qty has been released but not withdrawn yet!", "SUPPLY INFO:")
                Exit Sub

            End If

            'previewDR()
            DarkGreen_YellowGreen()

        ElseIf lvlrequisitionlist.SelectedItems(0).BackColor = Color.DarkGreen Then 'DARKGREEN
            Dim rs_id As Integer = Utilities.ifBlankReplaceToZero(lvlrequisitionlist.SelectedItems(0).Text)
            Dim count_drqty As Double
            Dim rs_qty As Double = Utilities.ifBlankReplaceToZero(lvlrequisitionlist.SelectedItems(0).SubItems(5).Text)

            For Each dr In sortDR
                If dr.rs_id = rs_id Then
                    count_drqty += dr.dr_qty
                End If
            Next

            If rs_qty = count_drqty And rs_qty <> 0 Then
                MessageBox.Show("all dr qty has been released!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub

            ElseIf rs_qty = 0 Then
                Dim openclose As String = lvlrequisitionlist.SelectedItems(0).SubItems(19).Text

                If openclose = "CLOSE QTY" Then
                    MessageBox.Show("Unable to create dr if rs qty is already zero (0)." & vbCrLf &
                              "NOTE: you can still proceed to dr transaction by creating main rs qty as 'OPEN QTY'", "SUPPLY INFO:",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

            End If
            'MsgBox(count_drqty)

            DarkGreen_YellowGreen()

        ElseIf lvlrequisitionlist.SelectedItems(0).BackColor = Color.LightPink Then 'LIGHTPINK
            Dim rr_no As String = lvlrequisitionlist.SelectedItems(0).SubItems(36).Text
            Dim rr_qty As Double = Utilities.ifBlankReplaceToZero(lvlrequisitionlist.SelectedItems(0).SubItems(23).Text)
            Dim rs_id As Integer = Utilities.ifBlankReplaceToZero(lvlrequisitionlist.SelectedItems(0).Text)
            Dim count_drqty As Double

            For Each dr In sortDR
                If dr.rs_id = rs_id And dr.rr_no = rr_no Then
                    count_drqty += dr.dr_qty
                End If
            Next

            If rr_qty = count_drqty Then
                MessageBox.Show("All dr qty has been received!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            Else
                lightpink(rr_no, rr_qty)
            End If
        End If

    End Sub

    Public Function totalDeliveredQty(Optional wsNoRrNo As String = "", Optional typeOfPurchasing As String = "", Optional rs_id As Integer = 0) As Double

        Dim _a As New List(Of PropsFields.dr_props_fields)

        Select Case typeOfPurchasing
            Case cTypeOfPurchasing.WITHDRAWAL
                _a = DRModel.GetListOfDR().Where(Function(x)
                                                     Return x.ws_no = wsNoRrNo And
                                                         x.inout = cInOut._OUT
                                                 End Function).ToList()

            Case cTypeOfPurchasing.PURCHASE_ORDER
                _a = DRModel.GetListOfDR().Where(Function(x)
                                                     Return x.rr_no = wsNoRrNo
                                                 End Function).ToList()

            Case cTypeOfPurchasing.DR
                _a = DRModel.GetListOfDR().Where(Function(x)
                                                     Return x.rs_id = rs_id
                                                 End Function).ToList()
        End Select


        totalDeliveredQty = _a.Sum(Function(x) x.dr_qty)
    End Function

    Private Sub lightpink(rr_no As String, rr_qty As Double)

        publicvariables.wh_id_for_dr = lvlrequisitionlist.SelectedItems(0).SubItems(15).Text
        publicvariables.pub_items_for_dr = lvlrequisitionlist.SelectedItems(0).SubItems(4).Text

        rs_id = lvlrequisitionlist.SelectedItems(0).Text
        FDeliveryReceipt.myRsNo = lvlrequisitionlist.SelectedItems(0).SubItems(1).Text
        FDeliveryReceipt.myRRNo = rr_no
        FDeliveryReceipt.myRRQty = rr_qty
        FDeliveryReceipt.MyRsId = lvlrequisitionlist.SelectedItems(0).Text

        button_click_name = ""
        pub_button_name = "CreateDRToolStripMenuItem1"

        FDeliveryReceipt.trigger("in with rs", "OTHERS")

        FDeliveryReceipt.Activate()
        FDeliveryReceipt.MdiParent = FMain
        FDeliveryReceipt.Dock = DockStyle.Fill
        'enable_disable_buttons_in_supptrans("0")

        FDeliveryReceipt.Show()
    End Sub
    Private Sub DarkGreen_YellowGreen()
        pub_button_name = "EquipmentUseForHaulingToolStripMenuItem"

        Dim type_of_purchasing As String = lvlrequisitionlist.SelectedItems(0).SubItems(18).Text

        If lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "IN" Then
            ' with_dr_status = "in with rs"
            create_delivery_receipt()

        ElseIf lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "OTHERS" Then
            create_delivery_receipt()

        ElseIf lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "OUT" Then
            'select_what_dr()


            If check_if_dr(lvlrequisitionlist.SelectedItems(0).SubItems(36).Text) = "WITHOUT DR" Then
                MessageBox.Show("Unable to create dr if the status is Without DR..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                create_delivery_receipt()
                Panel1.Visible = False
            End If

        End If
    End Sub

    Private Function check_if_dr(ws_no As String) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 9)
            newCMD.Parameters.AddWithValue("@ws_no", ws_no)

            newDR = newCMD.ExecuteReader

            While newDR.Read

                check_if_dr = newDR.Item("dr_option").ToString

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Public Sub select_what_dr()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        ListView1.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 25)
            newCMD.Parameters.AddWithValue("@rs_id", lvlrequisitionlist.SelectedItems(0).Text)
            newCMD.Parameters.AddWithValue("@rs_no", lvlrequisitionlist.SelectedItems(0).SubItems(1).Text)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim a(4) As String

                a(0) = newDR.Item("po_det_id").ToString
                a(1) = newDR.Item("WS_NO").ToString
                a(2) = newDR.Item("dr_option").ToString

                Dim lvl As New ListViewItem(a)
                ListView1.Items.Add(lvl)
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

        Panel1.Visible = True
    End Sub

    Public Sub AddWithdrawalNos(rs_id As Integer, cmb As ComboBox, rs_no As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 16)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.Parameters.AddWithValue("@rs_no", rs_no)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                cmb.Items.Add(newDR.Item("ws_no").ToString)
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Sub

    Public Sub AddRRNo(rs_id As Integer, cmb As ComboBox, rs_no As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 166)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.Parameters.AddWithValue("@rs_no", rs_no)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                cmb.Items.Add(newDR.Item("rr_no").ToString)
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Sub

    Public Sub get_charges_category_and_name(rs_id As Integer, inout As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            If inout = "IN" Or inout = "OTHERS" Then
                newCMD.Parameters.AddWithValue("@n", 8)
            Else
                newCMD.Parameters.AddWithValue("@n", 88)
            End If

            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_charges_category = newDR.Item("CATEGORY").ToString
                get_charges_name = newDR.Item("CHARGES").ToString
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

        End Try

    End Sub

    Public Sub load_existing_dr_info(rs_no As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 4)
            newCMD.Parameters.AddWithValue("@rs_no", rs_no)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                With FDeliveryReceipt

                    .dtpDRDate.Text = newDR.Item("date").ToString
                    '.dtpTimeFrom.Text = newDR.Item("time_from").ToString
                    '.dtpTime_to.Text = newDR.Item("time_to").ToString
                    .txtPlateNo.Text = newDR.Item("PLATENO").ToString
                    .cmbTypeofCharge.Text = newDR.Item("type_of_request").ToString
                    .cmbOperator.Text = newDR.Item("OPERATOR").ToString

                    If .cmbTypeofCharge.Text = "PROJECT" And .cmbTypeofCharge.Text = "EQUIPMENT" Then
                        .cmbChargeTo.Text = newDR.Item("REQUESTOR").ToString
                    Else
                        .txtChargeTo.Text = newDR.Item("REQUESTOR").ToString
                    End If

                End With
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
            FDeliveryReceipt.btnSave.Text = "Update"
        End Try

    End Sub
    Public Sub change_PO_form_TO_DR()
        With FPOFORM

            .txtInstructions.Visible = False
            .txtChargeTo.Visible = False
            .DTPdateneeded.Format = DateTimePickerFormat.Time
            .Label1.Text = "DR Date:"
            .Label6.Text = "Driver:"
            .Label8.Text = "Requestor:"
            .Label11.Text = "DR Time:"
            .Label10.Text = "Address:"
            .Label12.Text = "Received by:"

            .cmb_driver.Location = New System.Drawing.Point(.Label6.Location.X + 3, .Label6.Location.Y + .Label6.Height + 2)
            .Label8.Location = New System.Drawing.Point(.cmb_driver.Location.X - 2, .cmb_driver.Location.Y + .cmb_driver.Height + 4)
            .txtRequestor.Location = New System.Drawing.Point(.Label8.Location.X + 2, .Label8.Location.Y + .Label8.Height + 2)
            .Label10.Location = New System.Drawing.Point(.txtRequestor.Location.X - 1, .txtRequestor.Location.Y + .txtRequestor.Height + 4)
            .txtPrepared_by.Location = New System.Drawing.Point(.Label10.Location.X + 1, .Label10.Location.Y + .Label10.Height + 2)
            .Label11.Location = New System.Drawing.Point(.txtPrepared_by.Location.X - 2, .txtPrepared_by.Location.Y + .txtPrepared_by.Height + 4)
            .DTPdateneeded.Location = New System.Drawing.Point(.Label11.Location.X + 2, .Label11.Location.Y + .Label11.Height + 2)
            .Label9.Location = New System.Drawing.Point(.DTPdateneeded.Location.X - 1, .DTPdateneeded.Location.Y + .DTPdateneeded.Height + 5)
            .txtChecked_by.Location = New System.Drawing.Point(.Label9.Location.X, .Label9.Location.Y + .Label9.Height + 2)
            .Label12.Location = New System.Drawing.Point(.txtChecked_by.Location.X, .txtChecked_by.Location.Y + .txtChecked_by.Height + 5)
            .txtApproved_by.Location = New System.Drawing.Point(.Label12.Location.X, .Label12.Location.Y + .Label12.Height + 2)
            .btnSave.Location = New System.Drawing.Point(.txtApproved_by.Location.X, .txtApproved_by.Location.Y + .txtApproved_by.Height + 20)


            .dgvPOList.Columns(4).HeaderCell.Value = "Source"
            .dgvPOList.Columns(6).HeaderCell.Value = "Concession Ticket No."

            load_operator()

        End With
    End Sub
    Public Sub load_operator()
        Dim newsql As New SQLcon
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand

        FPOFORM.cmb_driver.Items.Clear()

        Try
            newsql.connection1.Open()

            Dim query As String = "SELECT * FROM dboperator"
            newcmd = New SqlCommand(query, newsql.connection1)
            newdr = newcmd.ExecuteReader
            While newdr.Read
                FPOFORM.cmb_driver.Items.Add(newdr.Item("operator_name").ToString)
            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsql.connection1.Close()
        End Try

    End Sub

    Private Sub MarkToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MarkToolStripMenuItem.Click
        For Each row As ListViewItem In lvlrequisitionlist.Items

            If row.Selected = True Then
                Dim rs_id As Integer = CInt(row.Text)
                If check_if_exist("Mark_Fac_Tools", "rs_id", rs_id, 1) > 0 Then

                    If MessageBox.Show("Selected item was already mark as Facilities, do you still want to update?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Dim query1 As String = "UPDATE Mark_Fac_Tools SET Marker = '" & "FACILITIES" & "' WHERE rs_id = " & rs_id
                        UPDATE_INSERT_DELETE_QUERY(query1, 0, "UPDATE")

                    End If
                Else
                    Dim query As String = "INSERT INTO Mark_Fac_Tools(rs_id,Marker) VALUES(" & rs_id & ",'" & "FACILITIES" & "')"
                    Borrower_Marker(query, "FACILITIES")
                End If
            End If
        Next

        btnSearch.PerformClick()
        listfocus(lvlrequisitionlist, rs_id)


    End Sub
    Public Sub Borrower_Marker(ByVal query As String, ByVal marker As String)
        Try
            'Dim rs_id As Integer = CInt(lvlrequisitionlist.SelectedItems(0).Text)
            'Dim query As String = "INSERT INTO Mark_Fac_Tools(rs_id,Marker) VALUES(" & rs_id & ",'" & "FACILITIES" & ")"

            UPDATE_INSERT_DELETE_QUERY(query, 0, "INSERT")

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub MarkToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MarkToolStripMenuItem1.Click

        For Each row As ListViewItem In lvlrequisitionlist.Items

            If row.Selected = True Then
                Dim rs_id As Integer = CInt(row.Text)

                If check_if_exist("Mark_Fac_Tools", "rs_id", rs_id, 1) > 0 Then

                    If MessageBox.Show("Selected item was already mark as Tools, do you still want to update?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Dim query1 As String = "UPDATE Mark_Fac_Tools SET Marker = '" & "TOOLS" & "' WHERE rs_id = " & rs_id
                        UPDATE_INSERT_DELETE_QUERY(query1, 0, "UPDATE")
                    End If

                Else
                    Dim query As String = "INSERT INTO Mark_Fac_Tools(rs_id,Marker) VALUES(" & rs_id & ",'" & "TOOLS" & "')"
                    Borrower_Marker(query, "TOOLS")
                End If

            End If

        Next


        btnSearch.PerformClick()
        listfocus(lvlrequisitionlist, rs_id)

    End Sub

    Private Sub UnmarkToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles UnmarkToolStripMenuItem.Click
        Dim rs_id As Integer = CInt(lvlrequisitionlist.SelectedItems(0).Text)

        Dim query As String = "DELETE FROM Mark_Fac_Tools WHERE rs_id = " & rs_id
        UPDATE_INSERT_DELETE_QUERY(query, 0, "UPDATE")

        btnSearch.PerformClick()
        listfocus(lvlrequisitionlist, rs_id)
    End Sub

    Private Sub UnmarkToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles UnmarkToolStripMenuItem1.Click
        Dim rs_id As Integer = CInt(lvlrequisitionlist.SelectedItems(0).Text)

        Dim query As String = "DELETE FROM Mark_Fac_Tools WHERE rs_id = " & rs_id
        UPDATE_INSERT_DELETE_QUERY(query, 0, "UPDATE")

        btnSearch.PerformClick()
        listfocus(lvlrequisitionlist, rs_id)
    End Sub

    Private Sub CrusherProductionToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CrusherProductionToolStripMenuItem.Click

    End Sub

    Private Sub TransferOfAgreggatesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TransferOfAgreggatesToolStripMenuItem.Click
        change_PO_form_TO_DR()
        Dim inout As String = lvlrequisitionlist.SelectedItems(0).SubItems(9).Text
        show_po_cv_ws(inout)
    End Sub

    Private Sub WarehouseCheckingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WarehouseCheckingToolStripMenuItem.Click
        Try
            Dim main_sub As String = lvlrequisitionlist.SelectedItems(0).SubItems(27).Text

            If main_sub = "SUB" Then
                With FWarehouse_FacilitiesTools_Checking.cmb_select_typeof_checking
                    .Items.Clear()
                    .Items.Add("Items Checking")
                    .SelectedIndex = 0
                End With

            ElseIf main_sub = "MAIN" Then
                With FWarehouse_FacilitiesTools_Checking.cmb_select_typeof_checking
                    .Items.Clear()
                    If lvlrequisitionlist.SelectedItems(0).BackColor = Color.Orange Then
                        .Items.Add("Facilities/Tools Checking")
                        .Items.Add("Items Checking")
                        .SelectedIndex = 1
                    Else
                        .Items.Add("Items Set")
                        .SelectedIndex = 0
                    End If

                End With

            ElseIf main_sub = "" Then
                'Dim rs_id As Integer = lvlrequisitionlist.SelectedItems(0).Text
                'If show_endorse_items(rs_id) > 0 Then
                '    FEndorseItem.ShowDialog()
                '    Exit Sub
                'Else
                '    '    If MessageBox.Show("Item has not been endorse yet, do you still want proceed to item checking?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                '    '        With FWarehouse_FacilitiesTools_Checking.cmb_select_typeof_checking
                '    '            .Items.Clear()
                '    '            .Items.Add("Facilities/Tools Checking")
                '    '            .Items.Add("Items Checking")
                '    '            .Items.Add("Items Set")

                '    '            .SelectedIndex = 1
                '    '            FWarehouse_FacilitiesTools_Checking.ShowDialog()

                '    '        End With
                '    '    End If
                '    load_rs_temp()
                '    FEndorseItem.ShowDialog()
                'End If

                With FWarehouse_FacilitiesTools_Checking.cmb_select_typeof_checking
                    .Items.Clear()
                    .Items.Add("Facilities/Tools Checking")
                    .Items.Add("Items Checking")
                    .Items.Add("Items Set")

                    .SelectedIndex = 1
                    FWarehouse_FacilitiesTools_Checking.ShowDialog()

                End With
            End If


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub load_rs_temp()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        'FEndorseItem.lvlEndorseItems.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_requisition_search_item", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 4)
            newCMD.Parameters.AddWithValue("@rs_id", lvlrequisitionlist.SelectedItems(0).Text)

            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                a(1) = newDR.Item("wh_id").ToString
                a(2) = newDR.Item("whItem").ToString
                a(3) = newDR.Item("whItemDesc").ToString
                a(5) = newDR.Item("wh_area").ToString
                a(7) = newDR.Item("from_wh").ToString

                Dim lvl As New ListViewItem(a)
                FEndorseItem.lvlEndorseItems.Items.Add(lvl)

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Sub
    Public Function show_endorse_items(rs_id As Integer) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        FEndorseItem.lvlEndorseItems.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_QTO_maintenance", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 13)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read

                a(1) = newDR.Item("wh_id").ToString
                a(2) = newDR.Item("Item_Name").ToString
                a(3) = newDR.Item("Item_Desc").ToString
                a(4) = newDR.Item("reorder_point").ToString
                a(5) = newDR.Item("wh_area").ToString
                a(6) = newDR.Item("source_clasification").ToString

                show_endorse_items += 1

                Dim lvl As New ListViewItem(a)
                FEndorseItem.lvlEndorseItems.Items.Add(lvl)

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Private Sub WithdrawToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles WithdrawToolStripMenuItem.Click
        Dim rs_id As Integer

        If MessageBox.Show("Are you sure you want to withdraw this item?", "Suppy Info:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            For Each row As ListViewItem In lvlrequisitionlist.Items
                rs_id = CInt(row.Text)
                Dim ws_id As Integer = CInt(row.SubItems(25).Text)


                'kdto ra ge select na row
                If row.Selected = True Then
                    If row.SubItems(18).Text = "WITHDRAWAL" Then
                        UPDATE_INSERT_DELETE_QUERY("DELETE FROM dbwithdrawn_items WHERE rs_id = " & rs_id & " AND ws_id = " & ws_id, 0, "DELETE")

                        Dim query As String = "INSERT INTO dbwithdrawn_items(rs_id,ws_id) VALUES(" & rs_id & "," & ws_id & ")"
                        UPDATE_INSERT_DELETE_QUERY(query, 0, "INSERT")
                    End If
                End If

            Next

        End If

        btnSearch.PerformClick()
        listfocus(lvlrequisitionlist, rs_id)

    End Sub

    Private Sub CancelWithdrawToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CancelWithdrawToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you want to cancel withdrawn item?", "Suppy Info:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim rs_id As Integer
            Dim ws_id As Integer

            For Each row As ListViewItem In lvlrequisitionlist.Items
                rs_id = CInt(row.Text)
                ws_id = CInt(row.SubItems(25).Text)

                If row.Selected = True Then
                    If row.SubItems(18).Text = "WITHDRAWAL" Then
                        Dim query As String = "DELETE FROM dbwithdrawn_items WHERE ws_id = " & ws_id
                        UPDATE_INSERT_DELETE_QUERY(query, 0, "DELETE")
                    End If
                End If

            Next

        End If

        btnSearch.PerformClick()
        listfocus(lvlrequisitionlist, rs_id)

    End Sub

    Private Sub CreateBorrowerSlipToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateBorrowerSlipToolStripMenuItem.Click
        create_borrowerSLip(lvlrequisitionlist.SelectedItems(0).Text)

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

    Public Sub create_borrowerSLip(ByVal rsid As Integer)
        Dim SQL As New SQLcon
        Dim cmd As SqlCommand
        FBorrower_Details.lvlBorrowerItem.Items.Clear()
        FBorrower_Details.lvlMultipleCustodian.Items.Clear()
        Try
            SQL.connection.Open()

            cmd = New SqlCommand("proc_borrower_items", SQL.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@n", 5)
            cmd.Parameters.AddWithValue("@rs_id", rsid)

            Dim reader As SqlDataReader = cmd.ExecuteReader

            While reader.Read
                Dim a(22) As String

                a(0) = reader.Item("rr_item_sub_id").ToString

                Dim avail_qty As Integer = CInt(reader.Item("qty").ToString) ' FListofBorrowerItem.if_item_available(CInt(a(0)))
                Dim reserved_qty As Integer = FListofBorrowerItem.count_reserved_item(CInt(a(0)))
                Dim qty_borrow As Integer = get_qty_borrow(rsid) ' FListofBorrowerItem.if_item_available(CInt(a(0))) 'avail_qty - reserved_qty 

                a(1) = reader.Item("item_name").ToString
                a(2) = avail_qty - IIf(qty_borrow <= 0, 0, qty_borrow)
                a(3) = reader.Item("rr_item_id").ToString
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

proceedhere:

            End While
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQL.connection.Close()
        End Try
    End Sub
    Public Function get_qty_borrow(rs_id As Integer) As Decimal
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT qty FROM dbborrower_details WHERE rs_id = " & rs_id

            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_qty_borrow += CDec(newDR.Item("qty").ToString)
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Private Sub TurnoverItemsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TurnoverItemsToolStripMenuItem.Click

        rs_id = lvlrequisitionlist.SelectedItems(0).Text

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

            .search_borrowed_items(rs_id, 0)

            .cmbSearchBy.Enabled = True
            .txtSearch.Enabled = True
            .btnSearch.Enabled = True

            .Show()
            .lvlMultipleCustodian.Items.Clear()

        End With
    End Sub

    Private Sub SetsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetsToolStripMenuItem.Click
        FItem_Sets.ListView1.Items.Clear()
        FItem_Sets.ShowDialog()

    End Sub

    Private Sub ViewBorrowerHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewBorrowerHistoryToolStripMenuItem.Click
        FBorrower_History.ShowDialog()

    End Sub

    Private Sub FRequistionForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F2 Then
            WarehouseCheckingToolStripMenuItem.PerformClick()
        End If
    End Sub

    Private Sub ViewBorrowerDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewBorrowerDetailsToolStripMenuItem.Click
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

            '.search_borrowed_items(rs_id, 1)

            .cmbSearchBy.Enabled = True
            .txtSearch.Enabled = True
            .btnSearch.Enabled = True

            .Show()

        End With
    End Sub

    Private Sub AutoSearchItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutoSearchItemToolStripMenuItem.Click

        If lvlrequisitionlist.SelectedItems(0).SubItems(15).Text = 0 Then
            rs_id = lvlrequisitionlist.SelectedItems(0).Text
        Else
            If MessageBox.Show("Item was already checked from warehouse. Do you still want to proceed?", "SUPPLY INFO.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                rs_id = lvlrequisitionlist.SelectedItems(0).Text
            Else
                rs_id = 0
                Return
            End If
        End If

        With FListOfItems
            .txtSearch.Text = lvlrequisitionlist.SelectedItems(0).SubItems(4).Text
            .cmbSearchby.Text = "Search By Item Name"

            .Show()
            .btnSearch.PerformClick()

        End With

    End Sub

    Private Sub cmbItemName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProject1.SelectedIndexChanged
        FMaterials_ToolsTurnOverTextFields.get_WhItemDesc(cmbProject1.Text, 0, cmbItemDesc)
    End Sub

    Private Sub pboxHeader_Click(sender As Object, e As EventArgs) Handles pboxHeader.Click

    End Sub
    Private Sub export_data_to_excel()
        Dim xlApp As New Excel.Application

        Try
            Dim SaveFileDialog1 As New SaveFileDialog
            SaveFileDialog1.Title = "Save Excel File"
            SaveFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx"
            SaveFileDialog1.ShowDialog()

            'exit if no file selected
            If SaveFileDialog1.FileName = "" Then
                Exit Sub
            End If

            'create objects to interface to Excel
            Dim xls As New Excel.Application
            Dim book As Excel.Workbook
            Dim sheet As Excel.Worksheet

            Dim chartRange As Excel.Range
            Dim chartRange1 As Excel.Range
            Dim chartRange2 As Excel.Range

            'create a workbook and get reference to first worksheet
            xls.Workbooks.Add()
            book = xls.ActiveWorkbook
            sheet = book.ActiveSheet
            'step through rows and columns and copy data to worksheet
            Dim row As Integer = 2
            Dim col As Integer = 1
            Dim c As Integer = 1
            Dim excel_array() As String = New String() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC"}
            Dim excel_index As Integer = 1
            Dim iii As Integer = 0

            sheet.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange, sheet.Range("$A$1:$AB$1"), , Excel.XlYesNoGuess.xlYes).Name = "Table1"

            '~~> Format the table
            sheet.ListObjects("Table1").TableStyle = "TableStyleLight9"

            sheet.Cells(1, 1) = "RS No."
            sheet.Cells(1, 2) = "DR NO."
            sheet.Cells(1, 3) = "WS NO./RR NO."
            sheet.Cells(1, 4) = "REQUEST DATE"
            sheet.Cells(1, 5) = "DATE NEEDED"
            sheet.Cells(1, 6) = "J.O NO."
            sheet.Cells(1, 7) = "ITEM DESCRIPTION"
            sheet.Cells(1, 8) = "CONS.ITEM"
            sheet.Cells(1, 9) = "CONS.ITEM DESC."
            sheet.Cells(1, 10) = "QTY TAKE OFF DESCRIPTION"
            sheet.Cells(1, 11) = "RS QTY"
            sheet.Cells(1, 12) = "PO/CV/WS QTY RELEASED"
            sheet.Cells(1, 13) = "RR/WS QTY RECEIVED"
            sheet.Cells(1, 14) = "DR QTY (out/in)"
            sheet.Cells(1, 15) = "PRICE"
            sheet.Cells(1, 16) = "UNIT"
            sheet.Cells(1, 17) = "TYPE OF REQUEST"
            sheet.Cells(1, 18) = "IN/OUT"
            sheet.Cells(1, 19) = "PO/CV STATUS"
            sheet.Cells(1, 20) = "RR STATUS"
            sheet.Cells(1, 21) = "WS STATUS"
            sheet.Cells(1, 22) = "CHARGE TO"
            sheet.Cells(1, 23) = "LOCATION"
            sheet.Cells(1, 24) = "DATE LOG"
            sheet.Cells(1, 25) = "TYPE OF CHARGES"
            sheet.Cells(1, 26) = "TYPE OF PURCHASING"
            sheet.Cells(1, 27) = "REQUESTED BY"
            sheet.Cells(1, 28) = "WAREHOUSE/QY AREA"
            sheet.Cells(1, 29) = "USERNAME"


            'For Each item As ListViewItem In LVLEquipList.Items

            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Dim col1, row1 As Integer
            row1 = 2
            col1 = 1


            chartRange1 = sheet.Range(excel_array(3) & 1, excel_array(3) & 1)
            chartRange1.EntireColumn.NumberFormat = "@"

            For Each rows As ListViewItem In lvlrequisitionlist.Items
                'If rows.Selected = True Then


                sheet.Cells(row1, 1) = rows.SubItems(1).Text
                sheet.Cells(row1, 2) = rows.SubItems(21).Text
                sheet.Cells(row1, 3) = rows.SubItems(36).Text
                'sheet.Cells(row1, 4) = Format(Convert.ToDateTime(rows.SubItems(2).Text), "M/d/yyyy")

                If IsDate(rows.SubItems(2).Text) = True Then
                    sheet.Cells(row1, 4) = DateTime.ParseExact(rows.SubItems(2).Text, "M/d/yyyy", Globalization.CultureInfo.InvariantCulture)
                Else
                    sheet.Cells(row1, 4) = rows.SubItems(2).Text
                End If


                If IsDate(rows.SubItems(7).Text) = True Then
                    sheet.Cells(row1, 5) = DateTime.ParseExact(rows.SubItems(7).Text, "M/d/yyyy", Globalization.CultureInfo.InvariantCulture)
                Else
                    sheet.Cells(row1, 5) = rows.SubItems(7).Text
                End If

                'sheet.Cells(row1, 5) = date_needed
                sheet.Cells(row1, 6) = rows.SubItems(3).Text
                sheet.Cells(row1, 7) = rows.SubItems(4).Text
                sheet.Cells(row1, 8) = rows.SubItems(29).Text
                sheet.Cells(row1, 9) = rows.SubItems(30).Text
                sheet.Cells(row1, 10) = rows.SubItems(37).Text
                sheet.Cells(row1, 11) = rows.SubItems(5).Text
                sheet.Cells(row1, 12) = rows.SubItems(22).Text
                sheet.Cells(row1, 13) = rows.SubItems(23).Text
                sheet.Cells(row1, 14) = rows.SubItems(32).Text
                sheet.Cells(row1, 15) = rows.SubItems(43).Text
                sheet.Cells(row1, 16) = rows.SubItems(6).Text
                sheet.Cells(row1, 17) = rows.SubItems(8).Text
                sheet.Cells(row1, 18) = rows.SubItems(9).Text
                sheet.Cells(row1, 19) = rows.SubItems(10).Text
                sheet.Cells(row1, 20) = rows.SubItems(11).Text
                sheet.Cells(row1, 21) = rows.SubItems(12).Text
                sheet.Cells(row1, 22) = rows.SubItems(13).Text
                sheet.Cells(row1, 23) = rows.SubItems(14).Text
                sheet.Cells(row1, 25) = rows.SubItems(17).Text
                sheet.Cells(row1, 26) = rows.SubItems(18).Text
                sheet.Cells(row1, 27) = rows.SubItems(28).Text
                sheet.Cells(row1, 28) = rows.SubItems(33).Text
                sheet.Cells(row1, 29) = rows.SubItems(24).Text

                chartRange1 = sheet.Range(excel_array(3) & 2, excel_array(3) & 2)
                chartRange1.EntireColumn.NumberFormat = "@"

                chartRange = sheet.Range("A" & row1, "AC" & row1)


                With chartRange

                    .HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter
                    .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    .Font.Size = 12
                    .Font.FontStyle = "Arial"
                    .EntireColumn.ColumnWidth = 15
                    '.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightYellow)

                    .Borders(Excel.XlBordersIndex.xlEdgeLeft).Weight = 2
                    .Borders(Excel.XlBordersIndex.xlEdgeRight).Weight = 2
                    .Borders(Excel.XlBordersIndex.xlEdgeTop).Weight = 2
                    .Borders(Excel.XlBordersIndex.xlEdgeBottom).Weight = 2
                    'chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)

                    '.Range("F" & col1).Formula = "=(E" & col1 & "-D" & col1 & ")*24*60/60"
                    .EntireColumn.AutoFit()

                End With

                If rows.BackColor = Color.DarkGreen Then
                    sheet.Range("A" & row1, "AC" & row1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkGreen)
                    sheet.Range("A" & row1, "AC" & row1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                ElseIf rows.BackColor = Color.LightGreen Then
                    sheet.Range("A" & row1, "AC" & row1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen)
                    sheet.Range("A" & row1, "AC" & row1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                ElseIf rows.BackColor = Color.LightYellow Then
                    sheet.Range("A" & row1, "AC" & row1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightYellow)
                    sheet.Range("A" & row1, "AC" & row1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                End If

                row1 += 1

                'End If
            Next
            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


            'save the workbook and clean up
            book.SaveAs(SaveFileDialog1.FileName)
            xls.Workbooks.Close()
            xls.Quit()
            releaseObject(sheet)
            releaseObject(book)
            releaseObject(xls)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ExportToExcelFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExportToExcelFileToolStripMenuItem.Click
        Dim Export As New EXPORT_TO_EXCEL_FILE

        Dim SaveFileDialog1 As New SaveFileDialog

        SaveFileDialog1.Title = "Save Excel File"
        SaveFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx"
        SaveFileDialog1.ShowDialog()

        'exit if no file selected
        If SaveFileDialog1.FileName = "" Then
            Exit Sub
        End If

        Export._initialize(lvlrequisitionlist, SaveFileDialog1.FileName)


        'Export.Export_Rs_to_Excel_File(lvlrequisitionlist)
        'Export.CheckListViewData()

        'export_data_to_excel()

        Exit Sub

        '**** CONDEM *****
        Dim columns As New List(Of String)
        Dim columncount As Integer = lvlrequisitionlist.Columns.Count - 1


        'For i As Integer = 0 To columncount
        '    columns.Add(lvlrequisitionlist.Columns(i).Text)
        'Next


        'For Each columnname In columns
        '    MessageBox.Show(columnname)
        'Next


        'Dim SaveFileDialog1 As New SaveFileDialog
        'SaveFileDialog1.Title = "Save Excel File"
        'SaveFileDialog1.Filter = "Excel files (*.xls)|*.xls|Excel Files (*.xlsx)|*.xslx"
        'SaveFileDialog1.ShowDialog()
        ''exit if no file selected
        'If SaveFileDialog1.FileName = "" Then
        '    Exit Sub
        'End If
        'create objects to interface to Excel
        Dim xls As New Excel.Application
        Dim book As Excel.Workbook
        Dim sheet As Excel.Worksheet
        'create a workbook and get reference to first worksheet
        xls.Workbooks.Add()
        book = xls.ActiveWorkbook
        sheet = book.ActiveSheet
        'step through rows and columns and copy data to worksheet
        Dim row As Integer = 1
        Dim col As Integer = 1
        For Each item As ListViewItem In lvlrequisitionlist.Items
            If row = 1 Then
                For i As Integer = 0 To columncount
                    sheet.Cells(row, col) = lvlrequisitionlist.Columns(i).Text
                    col = col + 1
                Next
                row = 2
                col = 1
                For i As Integer = 0 To item.SubItems.Count - 1

                    If i = 2 Then
                        Dim isValidDate As Boolean = IsDate(item.SubItems(i).Text)

                        If isValidDate = True Then
                            sheet.Cells(row, col) = Date.Parse(item.SubItems(i).Text)
                        Else
                            sheet.Cells(row, col) = item.SubItems(i).Text
                        End If
                    Else
                        sheet.Cells(row, col) = item.SubItems(i).Text
                    End If
                    col = col + 1
                Next
            Else

                For i As Integer = 0 To item.SubItems.Count - 1

                    If i = 2 Then
                        Dim isValidDate As Boolean = IsDate(item.SubItems(i).Text)

                        If isValidDate = True Then
                            sheet.Cells(row, col) = Date.Parse(item.SubItems(i).Text)
                        Else
                            sheet.Cells(row, col) = item.SubItems(i).Text

                        End If
                    Else
                        sheet.Cells(row, col) = item.SubItems(i).Text
                    End If


                    col = col + 1
                Next
            End If
            row += 1
            col = 1
        Next
        'save the workbook and clean up
        book.SaveAs(SaveFileDialog1.FileName)
        xls.Workbooks.Close()
        xls.Quit()
        releaseObject(sheet)
        releaseObject(book)
        releaseObject(xls)
    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        'Release an automation object
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSelectItem.Click
        button_click_name = btnSelectItem.Name
        If cmbDivision.Text = "WAREHOUSING AND SUPPLY" Then
            FListOfItems.cmboptions.Text = "WAREHOUSING"
            FListOfItems.cmboptions.Enabled = False
        Else
            FListOfItems.cmboptions.Text = "HAULING AND CRUSHING"
            FListOfItems.cmboptions.Enabled = False
        End If

        FListOfItems.ShowDialog()

    End Sub

    Private Sub ConvertToINToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConvertToINToolStripMenuItem.Click

        convert_to_IN_OUT("IN")

    End Sub

    Public Sub convert_to_IN_OUT(inout As String)
        Dim status As String = lvlrequisitionlist.SelectedItems(0).SubItems(9).Text


        If status = "OUT" Or status = "DR" Or status = "WAITING..." Then
            MessageBox.Show("Unable to convert to " & inout & ", please contact the administrator.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If MessageBox.Show("Are you sure you want to convert it to " & inout & "?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim newSQ As New SQLcon
            Dim newCMD As SqlCommand

            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_requisition_slip", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 18)
                newCMD.Parameters.AddWithValue("@rs_id", CInt(lvlrequisitionlist.SelectedItems(0).Text))
                newCMD.Parameters.AddWithValue("@inout", inout)
                newCMD.ExecuteNonQuery()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
                MessageBox.Show("Successfully converted to " & inout, "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnSearch.PerformClick()

            End Try
        End If

    End Sub

    Private Sub ConvertToOTHERSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConvertToOTHERSToolStripMenuItem.Click
        convert_to_IN_OUT("OTHERS")
    End Sub

    Private Sub ChangeItemNamedescriptionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeItemNamedescriptionToolStripMenuItem.Click
        button_click_name = ChangeItemNamedescriptionToolStripMenuItem.Name
        FListOfItems.ShowDialog()
    End Sub

    Private Sub txtItemName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItemName.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()

        End If
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick

        If ListView1.SelectedItems(0).SubItems(2).Text = "WITHOUT DR" Then
            MessageBox.Show("Unable to create dr.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            create_delivery_receipt()
            Panel1.Visible = False
        End If
    End Sub
    Private Sub create_delivery_receipt()
        Try
            Dim rs_id1 As Integer
            FDeliveryReceipt.cmbWsNo_PoNo.Items.Clear()
            FDeliveryReceipt.cmbRRNo.Items.Clear()

            rs_id1 = lvlrequisitionlist.SelectedItems(0).Text

            If rs_id1 > 0 Then
            Else
                MessageBox.Show("Please, select the item atleast 1 in the requisition slip form.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'Dim inout As String = lvlrequisitionlist.SelectedItems(0).SubItems(9).Text
            With FDeliveryReceipt
                FReceiving_Info.load_suppliers_list(.cmbSupplier)
                ' FReceiving_Info.show_cmbOperator(.cmbOperator)
                FPreviousStackCardFinal.load_set_type_of_charge("CASH", .cmbTypeofCharge)
                '.txtpono.Text = get_PO_NO(lvlrequisitionlist.SelectedItems(0).Text)
            End With

            Dim ws_status As String = lvlrequisitionlist.SelectedItems(0).SubItems(12).Text

            If ws_status = "WS RELEASED" Then
                MessageBox.Show("Unable to create delivery receipt, you should withdraw the item first." & vbCrLf & "For clarification, please contact the administrator.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            Dim wh_id As Integer = lvlrequisitionlist.SelectedItems(0).SubItems(15).Text

            Dim rs_qty As Integer
            If lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "OTHERS" Then
                rs_qty = IIf(lvlrequisitionlist.SelectedItems(0).SubItems(5).Text = "-", 0, lvlrequisitionlist.SelectedItems(0).SubItems(5).Text)
            ElseIf lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "IN" Then
                rs_qty = lvlrequisitionlist.SelectedItems(0).SubItems(5).Text
            Else
                rs_qty = lvlrequisitionlist.SelectedItems(0).SubItems(23).Text
            End If

            Dim ws_qty As Integer

            '*********** dr qty with / ************
            Dim cut() As String
            Dim dr_qty As Integer
            Dim index As Integer = lvlrequisitionlist.SelectedItems(0).SubItems(32).Text.IndexOf("/")

            If index > 0 Then
                cut = lvlrequisitionlist.SelectedItems(0).SubItems(32).Text.Split("/")

                If cut(0) = 0 Then
                    dr_qty = 0
                Else
                    dr_qty = cut(1)
                End If

            Else
                dr_qty = IIf(lvlrequisitionlist.SelectedItems(0).SubItems(32).Text = "", 0, lvlrequisitionlist.SelectedItems(0).SubItems(32).Text)
            End If
            '****** end ****************

            Dim inout As String = lvlrequisitionlist.SelectedItems(0).SubItems(9).Text

            If lvlrequisitionlist.SelectedItems(0).SubItems(23).Text = "N/A" Or lvlrequisitionlist.SelectedItems(0).SubItems(23).Text = "" Then
                ws_qty = 0
            Else
                ws_qty = lvlrequisitionlist.SelectedItems(0).SubItems(23).Text
            End If

            button_click_name = "EquipmentUseForHaulingToolStripMenuItem"

            FDeliveryReceipt.cmbOptions.Text = inout
            FDeliveryReceipt.cmbOptions.Enabled = False

            'FDeliveryReceipt.txtpono.Text = get_PO_NO(lvlrequisitionlist.SelectedItems(0).Text)
            FDeliveryReceipt.txtChargeTo.Clear()

            Dim type_of_purchasing As String = lvlrequisitionlist.SelectedItems(0).SubItems(18).Text
            Dim type_of_delivery As String = lvlrequisitionlist.SelectedItems(0).SubItems(31).Text

            Dim item_desc As String = GET_ITEM_DESC(wh_id)
            Dim rs_id As Integer = lvlrequisitionlist.SelectedItems(0).Text
            Dim rs_no As String = lvlrequisitionlist.SelectedItems(0).SubItems(1).Text


            FDeliveryReceipt.dgv_dr_list.Rows.Clear()
            FDeliveryReceipt.cmbWsNo_PoNo.Items.Clear()

            'DISABLE ANG REQUESTOR KY REDANDUNT NA  
            FDeliveryReceipt.Panel9.Enabled = False
            FDeliveryReceipt.cmbTypeofCharge.Enabled = False
            FDeliveryReceipt.txtChargeTo.Enabled = False
            'FDeliveryReceipt.txtprice.Enabled = False

            'get_charges_category_and_name(rs_id)

            'If ws_qty <= 0 Then
            Select Case type_of_purchasing
                Case "DR", "WITHDRAWAL", "PURCHASE ORDER"
                    '=====kung naa na sa dbDeliveryReport_items ang rs_id====
                    If check_if_exist("dbDeliveryReport_items", "rs_id", rs_id, 1) > 0 Then
                        'warning sa
                        If MessageBox.Show("Warning:" & vbCrLf & vbCrLf & "DR has already exist. Still want to copy data and proceed?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then

                            With FDeliveryReceipt
                                Dim a(10) As String

                                .txtrsno.Text = rs_no

#Region "COPY_DATA_FROM_DR"
                                FReceiving_Info.load_suppliers_list(.cmbSupplier)
                                FReceiving_Info.show_cmbOperator(.cmbOperator)
                                FPreviousStackCardFinal.load_set_type_of_charge("CASH", .cmbTypeofCharge)

                                Dim newSQ As New SQLcon
                                Dim newCMD As SqlCommand
                                Dim newDR As SqlDataReader

                                Try
                                    newSQ.connection.Open()
                                    newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
                                    newCMD.Parameters.Clear()
                                    newCMD.CommandType = CommandType.StoredProcedure

                                    newCMD.Parameters.AddWithValue("@n", 12)
                                    newCMD.Parameters.AddWithValue("@rs_no", rs_no)
                                    newCMD.Parameters.AddWithValue("@wh_id", CInt(lvlrequisitionlist.SelectedItems(0).SubItems(15).Text))

                                    newDR = newCMD.ExecuteReader

                                    While newDR.Read
                                        With FDeliveryReceipt

                                            If type_of_purchasing = "DR" Then
                                                .cmbDrOptions.Text = "W/ DR"
                                                .cmbDrOptions.Enabled = False

                                            ElseIf type_of_purchasing = "WITHDRAWAL" Then
                                                .cmbDrOptions.Text = "W/ DR"
                                                .cmbDrOptions.Enabled = True

                                            End If

                                            .dtpDRDate.Text = Date.Parse(newDR.Item("date").ToString)
                                            '.dtpTimeFrom.Text = Date.Parse("00:00:00 AM")
                                            '.dtpTime_to.Text = Date.Parse("00:00:00 AM")
                                            .txtPlateNo.Text = newDR.Item("plate_no").ToString
                                            .cmbOperator.Text = newDR.Item("operator").ToString
                                            .txtDriver.Text = newDR.Item("operator").ToString

                                            .cmbTypeofCharge.Text = newDR.Item("type_of_request").ToString

                                            If .cmbTypeofCharge.Text = "PROJECT" Or .cmbTypeofCharge.Text = "EQUIPMENT" Then
                                                .cmbChargeTo.Text = newDR.Item("REQUESTOR_NAME").ToString

                                            Else
                                                .txtChargeTo.Text = newDR.Item("REQUESTOR_NAME").ToString

                                            End If

                                            ' .txtaddress.Text = newDR.Item("address").ToString
                                            .txtrsno.Text = newDR.Item("rs_no").ToString
                                            .cmbSupplier.Text = newDR.Item("SUPPLIER_NAME").ToString
                                            .txtconcession.Text = newDR.Item("concession_ticket_no").ToString
                                            .txtcheckedby.Text = newDR.Item("checkedBy").ToString
                                            .txtreceivedby.Text = newDR.Item("receivedby").ToString
                                            .cmbWsNo_PoNo.Items.Clear()
                                            ' AddWithdrawalNos(CInt(lvlrequisitionlist.SelectedItems(0).Text), .cmbWsNo_PoNo, rs_no)

                                            If inout = "IN" Or inout = "OTHERS" Then

                                                If dr_with_rr(rs_id) > 0 Then 'check if naay rr
                                                    .cmbRRNo.Items.Clear()
                                                    .cmbWsNo_PoNo.Items.Clear()
                                                    AddRRNo(rs_id, .cmbRRNo, rs_no)
                                                    .cmbRRNo.Text = lvlrequisitionlist.SelectedItems(0).SubItems(36).Text

                                                Else
                                                    AddRRNo(rs_id, .cmbWsNo_PoNo, rs_no)
                                                End If

                                                a(2) = newDR.Item("SOURCE").ToString
                                            Else
                                                .cmbWsNo_PoNo.Items.Clear()
                                                AddWithdrawalNos(rs_id, .cmbWsNo_PoNo, rs_no)
                                                a(2) = newDR.Item("out_source").ToString

                                                '.cmbWsNo_PoNo.Text = ListView1.SelectedItems(0).SubItems(1).Text

                                            End If

                                            a(0) = "True"
                                            a(1) = newDR.Item("dr_no").ToString
                                            a(3) = newDR.Item("category").ToString

                                            If type_of_purchasing = "DR" Then

                                                '**kwaon ang total sa dr nga na add**
                                                Dim dr_qty1 As Double
                                                Dim get_rs_id As Integer = lvlrequisitionlist.SelectedItems(0).Text
                                                For Each row As ListViewItem In lvlrequisitionlist.Items
                                                    If row.BackColor = Color.LightYellow Then
                                                        If get_rs_id = IIf(IsNumeric(row.Text), row.Text, 0) Then
                                                            dr_qty1 += row.SubItems(32).Text
                                                        End If
                                                    End If
                                                Next
                                                '***

                                                If CDec(lvlrequisitionlist.SelectedItems(0).SubItems(5).Text) = dr_qty1 Then
                                                    MessageBox.Show("All dr qty has been consumed...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                                    Exit Sub
                                                End If

                                                'a(4) = CDec(lvlrequisitionlist.SelectedItems(0).SubItems(5).Text) - CDec(lvlrequisitionlist.SelectedItems(0).SubItems(32).Text)
                                                a(4) = CDec(lvlrequisitionlist.SelectedItems(0).SubItems(5).Text) - dr_qty1

                                            ElseIf type_of_purchasing = "PURCHASE ORDER" Then

                                                '**kwaon ang total sa dr nga na add**
                                                Dim dr_qty1 As Double
                                                Dim rr_no As String = lvlrequisitionlist.SelectedItems(0).SubItems(36).Text
                                                For Each row As ListViewItem In lvlrequisitionlist.Items
                                                    If row.BackColor = Color.LightYellow Then
                                                        If rr_no = row.SubItems(36).Text Then
                                                            dr_qty1 += row.SubItems(32).Text
                                                        End If
                                                    End If
                                                Next
                                                '***

                                                If CDec(lvlrequisitionlist.SelectedItems(0).SubItems(23).Text) = dr_qty1 Then
                                                    MessageBox.Show("All dr qty has been consumed...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                                    Exit Sub
                                                End If

                                                'a(4) = CDec(lvlrequisitionlist.SelectedItems(0).SubItems(5).Text) - CDec(lvlrequisitionlist.SelectedItems(0).SubItems(32).Text)
                                                a(4) = CDec(lvlrequisitionlist.SelectedItems(0).SubItems(23).Text) - dr_qty1
                                                .dgv_dr_list.Rows.RemoveAt(0)
                                            Else

                                                a(4) = FDeliveryReceipt.get_qty_left_from_withdrawal(lvlrequisitionlist.SelectedItems(0).SubItems(36).Text) 'rs_qty - dr_qty
                                            End If

                                            a(5) = newDR.Item("ITEM_NAME").ToString
                                            a(6) = CInt(lvlrequisitionlist.SelectedItems(0).Text)
                                            a(7) = 0
                                            a(8) = lvlrequisitionlist.SelectedItems(0).SubItems(15).Text
                                            a(10) = 0

                                        End With
                                    End While
                                    newDR.Close()

                                Catch ex As Exception
                                    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Finally
                                    newSQ.connection.Close()

                                End Try

#End Region

                                'If CDbl(a(4)) <= 0 Then
                                '    MessageBox.Show("Unable to create DR for this moment. All requested qty has been consumed...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                '    Exit Sub
                                'End If

                                .dgv_dr_list.Rows.Add(a)

                                .cmbTypeofCharge.SelectedIndex = -1
                                .txtChargeTo.Text = ""

                                If type_of_purchasing = "DR" Then

                                ElseIf type_of_purchasing = "PURCHASE ORDER" Then

                                Else
                                    '.cmbWsNo_PoNo.Text = ListView1.SelectedItems(0).SubItems(1).Text
                                    .cmbWsNo_PoNo.Items.Clear()
                                    .cmbWsNo_PoNo.Items.Add(lvlrequisitionlist.SelectedItems(0).SubItems(36).Text)
                                    .cmbWsNo_PoNo.Text = lvlrequisitionlist.SelectedItems(0).SubItems(36).Text

                                End If

                                .Activate()
                                .MdiParent = FMain
                                .Dock = DockStyle.Fill
                                .Show()

                            End With
                        End If

                        '=====kung wala pa sa dbDeliveryReport_items ang rs_id====
                    Else
                        get_charges_category_and_name(rs_id, inout)
                        'With FDeliveryReceipt

                        '    FReceiving_Info.load_suppliers_list(.cmbSupplier)
                        '    FReceiving_Info.show_cmbOperator(.cmbOperator)
                        '    FPreviousStackCardFinal.load_set_type_of_charge("CASH", .cmbTypeofCharge)

                        'End With

                        With FDeliveryReceipt
                            Dim a(10) As String

                            .txtrsno.Text = rs_no

                            If type_of_purchasing = "DR" Then
                                .cmbDrOptions.Text = "W/ DR"
                                .cmbDrOptions.Enabled = False

                            ElseIf type_of_purchasing = "WITHDRAWAL" Then
                                .cmbDrOptions.Text = "W/ DR"
                                .cmbDrOptions.Enabled = True

                            End If

                            a(1) = "" : a(2) = get_charges_name : a(3) = get_charges_category : a(4) = rs_qty - dr_qty : a(5) = item_desc : a(6) = rs_id : a(7) = 0 : a(8) = wh_id

                            If inout = "IN" Or inout = "OTHERS" Then
                                .cmbRRNo.Items.Clear()
                                AddRRNo(rs_id, .cmbRRNo, rs_no)
                            Else
                                'AddWithdrawalNos(rs_id, .cmbWsNo_PoNo, rs_no)
                                .cmbWsNo_PoNo.Items.Add(lvlrequisitionlist.SelectedItems(0).SubItems(36).Text)
                                '.cmbWsNo_PoNo.SelectedIndex = 0
                            End If


                            .dgv_dr_list.Rows.Add(a)
                            '.ShowDialog()

                            .Activate()
                            .MdiParent = FMain
                            .Dock = DockStyle.Fill
                            .Show()
                        End With
                    End If

                Case Else
                    With FDeliveryReceipt
                        Dim a(10) As String

                        .txtrsno.Text = rs_no

                        a(1) = "" : a(2) = get_charges_name : a(3) = get_charges_category : a(4) = ws_qty - dr_qty : a(5) = item_desc : a(6) = rs_id : a(7) = 0 : a(8) = wh_id

                        If ws_qty = 0 Then
                            If MessageBox.Show("Warning:" & vbCrLf & vbCrLf & "Withdrawal transaction is waiting at this moment. " & vbCrLf & "Are you still want to proceed?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                            Else
                                Exit Sub
                            End If
                        End If

                        If CDbl(a(4)) <= 0 Then
                            MessageBox.Show("Unable to create DR for this moment. All requested qty has been consumed...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If

                        If type_of_delivery = "WITH DR" Then
                            .cmbDrOptions.Text = "W/ DR"

                        ElseIf type_of_delivery = "WITHOUT DR" Then
                            .cmbDrOptions.Text = "W/O DR"

                        End If

                        .cmbDrOptions.Enabled = False
                        .dgv_dr_list.Rows.Add(a)

                        .Activate()
                        .MdiParent = FMain
                        .Dock = DockStyle.Fill
                        .Show()
                        '.ShowDialog()
                    End With

            End Select


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Function dr_with_rr(rs_id As Integer) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 22)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                dr_with_rr = newDR.Item("count_rr_with_dr").ToString
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Function
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Panel1.Visible = False
    End Sub

    Private Sub CreateLiquiditionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateLiquiditionToolStripMenuItem.Click
        FRequestField.Show()
        Dim rs_id As Integer = CInt(lvlrequisitionlist.SelectedItems(0).Text)

        FRequestField.cmbRequestType.Text = get_type_of_request(rs_id, "type of request")
        FRequestField.cmbTOR_sub.Text = get_type_of_request(rs_id, "sub of type of request")
        FRequestField.cmbInOut.Text = get_type_of_request(rs_id, "inout")

        GET_REQUISITION_SLIP_DATA2(rs_id)
        FRequestField.pboxcharges.Visible = False

        For Each ctr As Control In FRequestField.Controls
            If ctr.Name = "pboxcharges" Then
                ctr.Visible = False
            Else
                ctr.Enabled = True
            End If
        Next

        FRequestField.txtChargeTo.Enabled = False
        FRequestField.cmbInOut.SelectedIndex = -1
        FRequestField.cmbTypeOfPurchase.SelectedIndex = -1


        Dim po, rr, ws As String
        po = lvlrequisitionlist.SelectedItems(0).SubItems(10).Text
        rr = lvlrequisitionlist.SelectedItems(0).SubItems(11).Text
        ws = lvlrequisitionlist.SelectedItems(0).SubItems(12).Text

        FRequestField.txtItemDesc.Focus()
        FRequestField.btnViewMultipleCharges.Enabled = False

        FRequestField.txtApprovedby.Enabled = False
        FRequestField.txtWarehouseIncharge.Enabled = False

        FRequestField.cmbTypeofCharge.SelectedIndex = 0
        FRequestField.txtItemDesc.Focus()


        If ws = "WITHDRAWN" Then
            FRequestField.PictureBox2.Enabled = False
            FRequestField.PictureBox2.Image = My.Resources.Plus_sign_neg

            If FRequestField.cmbInOut.Text = "OTHERS" Then
                FRequestField.txtItemDesc.Enabled = True
                FRequestField.PictureBox2.Enabled = False
                FRequestField.PictureBox2.Image = My.Resources.Plus_sign_neg


            End If

            Exit Sub

        ElseIf ws = "N/A" Then
            If lvlrequisitionlist.SelectedItems(0).SubItems(11).Text = "RECEIVED" Or lvlrequisitionlist.SelectedItems(0).SubItems(11).Text = "CV RELEASED" Then
                FRequestField.PictureBox2.Enabled = False
                FRequestField.PictureBox2.Image = My.Resources.Plus_sign_neg

                If FRequestField.cmbInOut.Text = "OTHERS" Then
                    FRequestField.txtItemDesc.Enabled = True
                    FRequestField.PictureBox2.Enabled = False
                    FRequestField.PictureBox2.Image = My.Resources.Plus_sign_neg


                End If

                Exit Sub
            Else
                FRequestField.PictureBox2.Enabled = True
                FRequestField.PictureBox2.Image = My.Resources.Plus_sign

                If FRequestField.cmbInOut.Text = "OTHERS" Then
                    FRequestField.txtItemDesc.Enabled = True
                    FRequestField.PictureBox2.Enabled = False
                    FRequestField.PictureBox2.Image = My.Resources.Plus_sign_neg


                End If
                Exit Sub
            End If
        End If


    End Sub

    Private Sub RemoveItemCheckedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveItemCheckedToolStripMenuItem.Click

        If MessageBox.Show("Are you sure you want to remove the item checking?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim rs_id As Integer = lvlrequisitionlist.SelectedItems(0).Text

            Dim po_cv_status, rr_status, ws_status, type_of_purchasing As String
            Dim dr_qty As Double

            po_cv_status = lvlrequisitionlist.SelectedItems(0).SubItems(10).Text
            rr_status = lvlrequisitionlist.SelectedItems(0).SubItems(11).Text
            ws_status = lvlrequisitionlist.SelectedItems(0).SubItems(12).Text

            Dim wh_id As Integer = lvlrequisitionlist.SelectedItems(0).SubItems(15).Text

            type_of_purchasing = lvlrequisitionlist.SelectedItems(0).SubItems(18).Text
            dr_qty = IIf(lvlrequisitionlist.SelectedItems(0).SubItems(32).Text = "", 0, lvlrequisitionlist.SelectedItems(0).SubItems(32).Text)

            If po_cv_status = "PENDING" Or rr_status = "PENDING" Or ws_status = "PENDING" Then

                remove_item_checking(rs_id)

            ElseIf po_cv_status = "WAITING..." And rr_status = "WAITING..." And ws_status = "WAITING..." And wh_id = 0 Then
                MessageBox.Show("Unable to remove item checked, item is not been checked yet.", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            ElseIf po_cv_status = "WAITING..." And rr_status = "" And ws_status = "WAITING..." And wh_id <> 0 Then

                remove_item_checking(rs_id)

            ElseIf po_cv_status = "N/A" Or rr_status = "N/A" Or ws_status = "N/A" And type_of_purchasing = "DR" And dr_qty = 0 Then

                remove_item_checking(rs_id)

            Else
                If dr_qty > 0 Then

                    If MessageBox.Show("some items has been partially delivered, do you still want to remove item check?", "SUPPLY INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        remove_item_checking(rs_id)
                    End If

                ElseIf dr_qty = 0 Then

                    remove_item_checking(rs_id)

                Else
                    MessageBox.Show("Unable to remove item checked, check the status if already released,received,withrawn.", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

        End If



    End Sub

    Public Sub remove_item_checking(rs_id As Integer)

        Dim query As String = "UPDATE dbrequisition_slip set wh_id = 0, wh_incharge = '',approved_by = '',IN_OUT = '',type_of_purchasing = '',warehouse_checker_id = 0 where rs_id = " & rs_id
        UPDATE_INSERT_DELETE_QUERY(query, 0, "UPDATE")

        cmbSearchByCategory.Text = "Search by RS.No."
        btnSearch.PerformClick()
        listfocus(lvlrequisitionlist, rs_id)

    End Sub

    Private Sub CreateReceivingWithoutPOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateReceivingWithoutPOToolStripMenuItem.Click
        'FReceiving_Info.ShowDialog()

        button_click_name = "CreateReceivingWithoutPOToolStripMenuItem"

        'FReceiving_Info.ShowDialog()
        Dim type_of_purchasing As String = lvlrequisitionlist.SelectedItems(0).SubItems(18).Text

        Dim get_rs_id As Integer
        Dim rs_qty As Double


        If type_of_purchasing = "DR" Then
            'GoTo proceedhere
            get_rs_id = lvlrequisitionlist.SelectedItems(0).Text 'rs_id ang ihatag
            rs_qty = IIf(lvlrequisitionlist.SelectedItems(0).SubItems(5).Text = "", 0, lvlrequisitionlist.SelectedItems(0).SubItems(5).Text)
        End If

        Dim rr_qty As Double
        For Each row As ListViewItem In lvlrequisitionlist.Items
            If row.BackColor = Color.LightYellow Then
                If get_rs_id = row.Text Then
                    rr_qty += row.SubItems(32).Text
                End If
            End If
        Next

        If rr_qty = rs_qty Then
            MessageBox.Show("RR RECEIVED...", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If lvlrequisitionlist.SelectedItems(0).SubItems(18).Text = "DR" Then
            show_receiving_for_cash_with_rr()
            Exit Sub
        Else
            'continue...
        End If


        Exit Sub


        ' CONDEMED CODES

        button_click_name = "CreateReceivingWithoutPOToolStripMenuItem"

        FReceiving_Info.load_suppliers_list(FReceiving_Info.cmbSupplier)

        Dim po_no As String = lvlrequisitionlist.SelectedItems(0).SubItems(10).Text
        Dim dr_no As String = lvlrequisitionlist.SelectedItems(0).SubItems(21).Text
        Dim inout As String = lvlrequisitionlist.SelectedItems(0).SubItems(9).Text
        Dim po_status As String = lvlrequisitionlist.SelectedItems(0).SubItems(10).Text
        Dim rr_status As String = lvlrequisitionlist.SelectedItems(0).SubItems(11).Text
        Dim ws_status As String = lvlrequisitionlist.SelectedItems(0).SubItems(12).Text

        If po_no = "PO RELEASED" And dr_no = "PENDING" Then
            MessageBox.Show("Create Delivery Receipt first before receiving...", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If po_no = "N/A" And lvlrequisitionlist.SelectedItems(0).SubItems(11).Text = "N/A" And lvlrequisitionlist.SelectedItems(0).SubItems(12).Text = "N/A" Then
            If inout = "IN" Then
                'continue
            Else
                MessageBox.Show("NOT APPLICABLE", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        End If

        'receiving_n = 1
        If inout = "IN" And po_status = "PO RELEASED" Then
            show_receiving_form()
        ElseIf inout = "FACILITIES" Or inout = "TOOLS" Or inout = "ADD-ON" Then
            show_receiving_form()
        ElseIf inout = "OTHERS" Or rr_status = "PENDING" Then
            'show_receiving_form_OTHERS()
            show_receiving_form()
        ElseIf inout = "IN" And rr_status = "CV RELEASED" Then
            show_receiving_form()
        ElseIf inout = "IN" And po_status = "N/A" Then
            FReceiving_Info.cmbPoNo.Items.Add("N/A")
            show_receiving_form()
        Else
            MessageBox.Show("PO SHOULD RELEASE FIRST", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        FReceiving_Info.ShowDialog()
    End Sub

    Private Sub CalculateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalculateToolStripMenuItem.Click
        'Dim sum_qty As Double

        'For Each row As ListViewItem In lvlrequisitionlist.Items
        '    If row.Selected = True Then
        '        sum_qty += row.SubItems(32).Text
        '    End If
        'Next

        'MsgBox(sum_qty)
    End Sub

    Private Sub UpdateWhAreaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateWhAreaToolStripMenuItem.Click

        button_click_name = "UpdateSourceFromRS"
        FListOfItems.ShowDialog()

    End Sub

    Private Sub ReceivedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReceivedToolStripMenuItem.Click
        Dim calc As Decimal

        For Each row As ListViewItem In lvlrequisitionlist.Items
            If row.Selected = True Then
                If row.BackColor = Color.LightYellow Then
                    calc += row.SubItems(23).Text
                End If
            End If
        Next

        MsgBox(calc)
    End Sub

    Private Sub OUTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WithdrawnToolStripMenuItem.Click
        Dim calc As Decimal

        For Each row As ListViewItem In lvlrequisitionlist.Items
            If row.Selected = True Then
                If row.BackColor = Color.LightGreen Then
                    calc += row.SubItems(23).Text
                End If
            End If
        Next

        MsgBox(calc)
    End Sub

    Private Sub RemoveDRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveDRToolStripMenuItem.Click
        If lvlrequisitionlist.SelectedItems(0).SubItems(3).BackColor = Color.DarkGreen Or
           lvlrequisitionlist.SelectedItems(0).SubItems(3).BackColor = Color.LightGreen Then

            MessageBox.Show("Unable to remove this data, kindly ask King for the permission..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If


        If lvlrequisitionlist.SelectedItems(0).SubItems(1).Text = "n/a" Or lvlrequisitionlist.SelectedItems(0).SubItems(1).Text = "N/A" Then
            delete_dr_using_rs_data(0, 0, 1)
            Exit Sub
        End If

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim inout As String = ""
        Dim dr_no As String = lvlrequisitionlist.SelectedItems(0).SubItems(21).Text

        If lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "OUT" Then
            inout = "IN"
        ElseIf lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "IN" Then
            inout = "OUT"
        ElseIf lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "OTHERS" Then
            inout = "OTHERS"
        End If

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_requisition_slip", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 145)
            newCMD.Parameters.AddWithValue("@dr_no", dr_no)
            newCMD.Parameters.AddWithValue("@inout", inout)
            newDR = newCMD.ExecuteReader

            Dim a(10) As String
            Dim count As Integer = 0

            While newDR.Read
                count += 1

                'MsgBox("RS: " & newDR.Item("rs_id").ToString & vbCrLf & "Dr_item_id: " & newDR.Item("dr_items_id").ToString)
                If newDR.Item("IN_OUT").ToString = "OTHERS" Then
                    'walay delete mahitabo diring dapita kay others man
                Else
                    delete_dr_using_rs_data(newDR.Item("rs_id").ToString, newDR.Item("dr_items_id").ToString, 1)
                End If

            End While

            If count > 0 Then
                If lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "IN" Then

                ElseIf lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "OUT" Then

                ElseIf lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "OTHERS" Then

                    delete_dr_using_rs_data(0, 0, 1)

                End If
            Else
                'kung out na dili whs to whs
                'whs to project
                If lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "OUT" Then
                    delete_dr_using_rs_data(0, 0, 2)
                ElseIf lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "OTHERS" Then
                    delete_dr_using_rs_data(0, 0, 1)
                End If
            End If

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
            btnSearch.PerformClick()

        End Try


    End Sub
    Private Sub delete_dr_using_rs_data(rs_id_given As Integer, dr_item_id_given As Integer, n As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_delete_dr_from_rs_data", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@rs_id_given", rs_id_given)
            newCMD.Parameters.AddWithValue("@dr_item_id_given", dr_item_id_given)
            newCMD.Parameters.AddWithValue("@dr_item_id_selected_given", lvlrequisitionlist.SelectedItems(0).SubItems(25).Text)
            newCMD.Parameters.AddWithValue("@rs_id_selected_given", lvlrequisitionlist.SelectedItems(0).Text)
            newCMD.Parameters.AddWithValue("@in_out", lvlrequisitionlist.SelectedItems(0).SubItems(9).Text)
            newCMD.Parameters.AddWithValue("@rs_no", lvlrequisitionlist.SelectedItems(0).SubItems(1).Text)

            If MessageBox.Show("Are you sure you want to delete this selected data?", "RS INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                newCMD.ExecuteNonQuery()

            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Private Sub OTHERSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReleasedToolStripMenuItem.Click
        Dim sum_qty As Double

        For Each row As ListViewItem In lvlrequisitionlist.Items
            If row.BackColor = Color.LightGreen Then
                If row.Selected = True Then
                    sum_qty += IIf(IsNumeric(row.SubItems(22).Text) = True, row.SubItems(22).Text, 0)
                End If
            End If
        Next

        MsgBox(sum_qty)
    End Sub

    Private Sub cmbTypeOfRequest_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTypeOfRequest.SelectedIndexChanged
        'load items na belong sa type of request
        'load_item_using_type_of_req(cmbTypeOfRequest.Text)

        If cmbTypeOfRequest.Text = "Search By Month" Then
            txtRsNo.Enabled = False
            dtpfrom.Enabled = True

        ElseIf cmbTypeOfRequest.Text = "Search By RS No." Then
            txtRsNo.Enabled = True
            dtpfrom.Enabled = False

        ElseIf cmbTypeOfRequest.Text = "Search By DR No." Then
            txtRsNo.Enabled = True
            dtpfrom.Enabled = False

        ElseIf cmbTypeOfRequest.Text = "Search By WS No." Then
            txtRsNo.Enabled = True
            dtpfrom.Enabled = False

        End If
    End Sub
    Private Sub load_item_using_type_of_req(type_of_req As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        cmbProject1.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_requisition_slip", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 30)
            newCMD.Parameters.AddWithValue("@typeofrequest", cmbTypeOfRequest.Text)

            newDR = newCMD.ExecuteReader

            Dim a(10) As String

            While newDR.Read
                cmbProject1.Items.Add(newDR.Item("whitem").ToString)
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "YES" Then
            dtpfrom.Enabled = True
            dtpto.Enabled = True
        Else
            dtpfrom.Enabled = False
            dtpto.Enabled = False
        End If
    End Sub

    Private Sub txtSearch_GotFocus(sender As Object, e As EventArgs) Handles txtSearch.GotFocus

        Select Case txtSearch.Text
            Case "Charges..."
                txtSearch.ForeColor = Color.Black
                txtSearch.Clear()
            Case "RS No..."
                txtSearch.ForeColor = Color.Black
                txtSearch.Clear()
            Case "Items..."
                txtSearch.ForeColor = Color.Black
                txtSearch.Clear()
            Case "Requested By..."
                txtSearch.ForeColor = Color.Black
                txtSearch.Clear()
            Case "Input By..."
                txtSearch.ForeColor = Color.Black
                txtSearch.Clear()
            Case "Username..."
                txtSearch.ForeColor = Color.Black
                txtSearch.Clear()
            Case "Type of Request..."
                txtSearch.ForeColor = Color.Black
                txtSearch.Clear()
            Case "Type of Purchasing..."
                txtSearch.ForeColor = Color.Black
                txtSearch.Clear()
            Case "Job Order..."
                txtSearch.ForeColor = Color.Black
                txtSearch.Clear()
        End Select

    End Sub

    Private Sub txtSearch_Leave(sender As Object, e As EventArgs) Handles txtSearch.Leave

        If txtSearch.Text = "" Then
            Select Case cmbSearchByCategory.Text
                Case "Search by Charges"
                    txtSearch.Text = "Charges..."
                Case "Generate Summary of Hauling Aggregates"
                    txtSearch.Text = "Charges..."
                Case "Search by RS.No."
                    txtSearch.Text = "RS No..."
                Case "Search by item"
                    txtSearch.Text = "Items..."
                Case "Search by Requested by"
                    txtSearch.Text = "Requested By..."
                Case "Search by Input by"
                    txtSearch.Text = "Input By..."
                Case "Search by User Name"
                    txtSearch.Text = "Username..."
                Case "Search by Type of Request/Sub"
                    txtSearch.Text = "Type of Request..."
                Case "Search by Type of Purchasing"
                    txtSearch.Text = "Type of Purchasing..."
                Case "Search by JO"
                    txtSearch.Text = "Job Order..."
            End Select

            txtSearch.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub txtItemName_GotFocus(sender As Object, e As EventArgs) Handles txtItemName.GotFocus
        If txtItemName.Text = "Items..." Then
            txtItemName.Clear()
            txtItemName.ForeColor = Color.Black
        End If

    End Sub

    Private Sub txtItemName_Leave(sender As Object, e As EventArgs) Handles txtItemName.Leave

        If txtItemName.Text = "" Then
            txtItemName.Text = "Items..."
            txtItemName.ForeColor = Color.Gray
        End If

    End Sub

    Private Sub cmbpages_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbpages.SelectedIndexChanged
        If cmbDivision.Text = "WAREHOUSING AND SUPPLY" Then
            load_rs_68()
        Else
            load_rs_67()
        End If

    End Sub

    Public Function get_Frequisition_non_item_charge_to(ByVal x As String, ByVal y As String, ByVal n As Integer) As String
        Dim newSqlcon As New SQLcon
        Try
            Dim Newsqlcomm As New SqlCommand
            Dim newDr1 As SqlDataReader

            newSqlcon.connection.Open()
            Newsqlcomm.Connection = SQLcon.connection
            Newsqlcomm.CommandText = "sp_crud_Requisition_Non_Item"
            Newsqlcomm.CommandType = CommandType.StoredProcedure
            If n = 1 Then
                Newsqlcomm.Parameters.AddWithValue("@n", 6)
                Newsqlcomm.Parameters.AddWithValue("@type_name", x)
                Newsqlcomm.Parameters.AddWithValue("@charge_to_id", CInt(y))
            ElseIf n = 2 Then
                Newsqlcomm.Parameters.AddWithValue("@n", 7)
                Newsqlcomm.Parameters.AddWithValue("@wh_area_id", CInt(y))
            ElseIf n = 3 Then
                Newsqlcomm.Parameters.AddWithValue("@n", 8)
                Newsqlcomm.Parameters.AddWithValue("@proj_id", CInt(y))
            ElseIf n = 4 Then
                Newsqlcomm.Parameters.AddWithValue("@n", 9)
                Newsqlcomm.Parameters.AddWithValue("@equipListID", CInt(y))
            End If

            newDr1 = Newsqlcomm.ExecuteReader

            While newDr1.Read
                If n = 1 Then
                    get_Frequisition_non_item_charge_to = newDr1.Item("charge_to").ToString
                ElseIf n = 2 Then
                    get_Frequisition_non_item_charge_to = newDr1.Item("wh_area").ToString
                ElseIf n = 3 Then
                    get_Frequisition_non_item_charge_to = newDr1.Item("project_desc").ToString
                ElseIf n = 4 Then
                    get_Frequisition_non_item_charge_to = newDr1.Item("plate_no").ToString
                End If
            End While
            newDr1.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSqlcon.connection.Close()
        End Try
    End Function
    Public Sub get_Frequisition_non_item_multicharges_data(ByVal x As Integer)
        Try
            SQLcon.connection.Open()
            Dim sqlcomm As New SqlCommand
            Dim newDr As SqlDataReader
            Dim type_name As String = ""
            Dim all_charges_id As Integer

            sqlcomm.Connection = SQLcon.connection
            sqlcomm.CommandText = "sp_crud_Requisition_Non_Item"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 5)
            sqlcomm.Parameters.AddWithValue("@rs_id", x)

            newDr = sqlcomm.ExecuteReader

            While newDr.Read
                type_name = newDr.Item("type_name").ToString
                all_charges_id = newDr.Item("all_charges_id").ToString
            End While
            newDr.Close()

            'If type_name.Equals("PERSONAL") Or type_name.Equals("MAINOFFICE") Or type_name.Equals("OTHERS") Or type_name.Equals("COMPANY") Or type_name.Equals("DIVISION") Or type_name.Equals("DEPARTMENT") Or type_name.Equals("SECTION") Or type_name.Equals("SHOPS") Or type_name.Equals("MOBILE CRUSHER") Or type_name.Equals("CRUSHER PLANT") Or type_name.Equals("BATCHING PLANT") Or type_name.Equals("WAREHOUSES") Or type_name.Equals("FABRICATION") Or type_name.Equals("BUNKHOUSE") Or type_name.Equals("OTHERS_NEW") Then
            '    With FRequisition_Non_Item
            '        .cmbTypeOfChargesName.Text = type_name
            '        .cmbTypeofCharge.Text = get_Frequisition_non_item_charge_to(type_name, all_charges_id, 1)
            '    End With
            'ElseIf type_name.Equals("MAINOFFICE") Then
            '    With FRequisition_Non_Item
            '        .cmbTypeOfChargesName.Text = type_name
            '        .cmbTypeofCharge.Text = get_Frequisition_non_item_charge_to("MAINOFFICE", all_charges_id, 1)
            '    End With
            'ElseIf type_name.Equals("OTHERS") Then
            '    With FRequisition_Non_Item
            '        .cmbTypeOfChargesName.Text = type_name
            '        .cmbTypeofCharge.Text = get_Frequisition_non_item_charge_to("OTHERS", all_charges_id, 1)
            '    End With
            If type_name.Equals("WAREHOUSE") Then
                With FRequisition_Non_Item
                    .cmbTypeOfChargesName.Text = type_name
                    .cmbTypeofCharge.Text = get_Frequisition_non_item_charge_to("WAREHOUSE", all_charges_id, 2)
                End With
            ElseIf type_name.Equals("PROJECT") Then
                With FRequisition_Non_Item
                    .cmbTypeOfChargesName.Text = type_name
                    .cmbTypeofCharge.Text = get_Frequisition_non_item_charge_to("PROJECT", all_charges_id, 3)
                End With
            ElseIf type_name.Equals("EQUIPMENT") Then
                With FRequisition_Non_Item
                    .cmbTypeOfChargesName.Text = type_name
                    .cmbTypeofCharge.Text = get_Frequisition_non_item_charge_to("EQUIPMENT", all_charges_id, 4)
                End With
            ElseIf type_name.Equals("") Then
                MsgBox("Please contact to IT Personnel")
            Else
                With FRequisition_Non_Item
                    .cmbTypeOfChargesName.Text = type_name
                    .cmbTypeofCharge.Text = get_Frequisition_non_item_charge_to(type_name, all_charges_id, 1)
                End With
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub
    Public Sub get_Frequisition_non_item_Data(ByVal x As Integer)
        Try
            SQLcon.connection.Open()
            Dim sqlcomm As New SqlCommand
            Dim newDr As SqlDataReader

            sqlcomm.Connection = SQLcon.connection
            sqlcomm.CommandText = "sp_crud_Requisition_Non_Item"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 4)
            sqlcomm.Parameters.AddWithValue("@rs_id", x)

            newDr = sqlcomm.ExecuteReader

            While newDr.Read

                With FRequisition_Non_Item
                    .txtApprovedby.Text = newDr.Item("approved_by").ToString
                    .txtAmount.Text = newDr.Item("amount").ToString
                    .txtPurpose.Text = newDr.Item("purpose").ToString
                    .txtNotedBy.Text = newDr.Item("noted_by").ToString
                    .txtItemDesc.Text = newDr.Item("item_desc").ToString
                End With

            End While
            newDr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try

    End Sub
    Private Sub EditRSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditRSToolStripMenuItem.Click
        If lvlrequisitionlist.SelectedItems(0).SubItems(18).Text = "CASH WITH RR" Or lvlrequisitionlist.SelectedItems(0).SubItems(18).Text = "CASH WITHOUT RR" Then
            Dim s As String = lvlrequisitionlist.SelectedItems(0).SubItems(8).Text
            Dim words As String() = s.Split(New Char() {"-"c})

            FRequisition_Non_Item.Show()
            Dim rs_id As Integer = CInt(lvlrequisitionlist.SelectedItems(0).SubItems(0).Text)
            get_Frequisition_non_item_Data(rs_id)
            get_Frequisition_non_item_multicharges_data(rs_id)
            With FRequisition_Non_Item
                '.txtItemDesc.Text = lvlrequisitionlist.SelectedItems(0).SubItems(4).Text
                .txtRSno.Text = lvlrequisitionlist.SelectedItems(0).SubItems(1).Text
                .txtLoc.Text = lvlrequisitionlist.SelectedItems(0).SubItems(14).Text
                .DTPReq.Text = lvlrequisitionlist.SelectedItems(0).SubItems(2).Text
                .txtJOno.Text = lvlrequisitionlist.SelectedItems(0).SubItems(3).Text
                .txtQty.Text = lvlrequisitionlist.SelectedItems(0).SubItems(5).Text
                .txtUnit.Text = lvlrequisitionlist.SelectedItems(0).SubItems(6).Text
                .DTPTimeNeeded.Text = lvlrequisitionlist.SelectedItems(0).SubItems(7).Text
                .txtRequestBy.Text = lvlrequisitionlist.SelectedItems(0).SubItems(28).Text
                .cmbCash_wrr_worr.Text = lvlrequisitionlist.SelectedItems(0).SubItems(18).Text
                .txtRemarksForEmd.Text = lvlrequisitionlist.SelectedItems(0).SubItems(50).Text
                .cmbRequestType.Text = words(0).TrimEnd
                .cmbTOR_sub.Text = words(1).Remove(0, 1)
                .lbl_rs_id.Text = rs_id
                .cmbRequestType.Focus()

                .btnSave.Text = "Update"
            End With


        Else
            FRequestField.Show()
            Dim rs_id As Integer = CInt(lvlrequisitionlist.SelectedItems(0).Text)

            FRequestField.cmbRequestType.Text = get_type_of_request(rs_id, "type of request")
            FRequestField.cmbTOR_sub.Text = get_type_of_request(rs_id, "sub of type of request")

            ' FRequestField.cmbInOut.Text = get_type_of_request(rs_id, "inout")

            '  MsgBox(get_type_of_request(rs_id, "type of request"))

            GET_REQUISITION_SLIP_DATA(rs_id)

            FRequestField.pboxcharges.Visible = False

            For Each ctr As Control In FRequestField.Controls
                If ctr.Name = "pboxcharges" Then
                    ctr.Visible = False
                Else
                    ctr.Enabled = True
                End If
            Next

            FRequestField.txtChargeTo.Enabled = False
            Dim po, rr, ws As String
            po = lvlrequisitionlist.SelectedItems(0).SubItems(10).Text
            rr = lvlrequisitionlist.SelectedItems(0).SubItems(11).Text
            ws = lvlrequisitionlist.SelectedItems(0).SubItems(12).Text

            FRequestField.txtApprovedby.Enabled = False
            FRequestField.txtWarehouseIncharge.Enabled = False

            pub_qto_id = IIf(Not IsNumeric(lvlrequisitionlist.SelectedItems(0).SubItems(38).Text), 0, lvlrequisitionlist.SelectedItems(0).SubItems(38).Text)
            FRequestField.txtQtyTakeOff.Text = lvlrequisitionlist.SelectedItems(0).SubItems(37).Text

            If contract_id = 0 Then
                FRequestField.cmbContractName.SelectedIndex = -1
            Else
                FRequestField.cmbContractName.Text = contract_name(contract_id)
            End If

            FRequestField.txtConsItemDesc.Text = get_cons_item_desc(lvlrequisitionlist.SelectedItems(0).Text)
            FRequestField.lboxUnit.Visible = False
            FRequestField.txtRemarksForEmd.Text = lvlrequisitionlist.SelectedItems(0).SubItems(50).Text

        End If

    End Sub
    Private Function contract_name(contract_id As Integer) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_QTO_maintenance", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 9)
            newCMD.Parameters.AddWithValue("@contract_id", contract_id)

            newCMD.CommandTimeout = 300

            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                contract_name = newDR.Item("Item_name_no").ToString
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Private Sub ExtractToDRListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExtractToDRListToolStripMenuItem.Click
        'Panel_date_duration.Location = New Point(360, 300)
        'Panel_date_duration.Visible = True
        'cmbTypeOfRequest.Enabled = True

        'lblFrom_date.Text = "Month:"


        For Each row As ListViewItem In lvlrequisitionlist.Items
            rs_id_count += 1
        Next

        Timer5.Start()
        thread = New System.Threading.Thread(AddressOf load_to_drList1)
        thread.Start()
    End Sub
    Private Sub load_to_drList1()
        Try
            Dim rs_percent As Integer
            Dim n As Integer
            'If Integer.TryParse((rs_id_count / 100), n) Then
            '    rs_percent = rs_id_count / 100
            'Else
            '    rs_percent = 1
            'End If

            rs_percent = 1

            If ProgressBar1.InvokeRequired Then
                ProgressBar1.Invoke(Sub()
                                        ProgressBar1.Value = 0
                                        'ProgressBar1.Maximum = (rs_percent * 100)
                                        ProgressBar1.Maximum = rs_id_count
                                    End Sub)

            Else
                ProgressBar1.Value = 0
                'ProgressBar1.Maximum = (rs_percent * 100)
                ProgressBar1.Maximum = rs_id_count
            End If

            'For Each list As String In ListBox1.Items
            For i = 0 To lvlrequisitionlist.Items.Count - 1

                If lvlrequisitionlist.InvokeRequired Then
                    lvlrequisitionlist.Invoke(Sub()
                                                  If lvlrequisitionlist.Items(i).BackColor = Color.LightPink Then
                                                  Else
                                                      If lvlrequisitionlist.Items(i).SubItems(18).Text = "PURCHASE ORDER" And lvlrequisitionlist.Items(i).SubItems(41).Text = "WITHOUT DR" Then
                                                      Else
                                                          load_dr(lvlrequisitionlist.Items(i).SubItems(41).Text, lvlrequisitionlist.Items(i).SubItems(42).Text)
                                                      End If
                                                  End If

                                              End Sub)
                Else
                    If lvlrequisitionlist.Items(i).SubItems(18).Text = "PURCHASE ORDER" And lvlrequisitionlist.Items(i).SubItems(41).Text = "WITHOUT DR" Then
                    Else
                        load_dr(lvlrequisitionlist.Items(i).SubItems(41).Text, lvlrequisitionlist.Items(i).SubItems(42).Text)
                    End If
                End If

                If ProgressBar1.InvokeRequired Then
                    ProgressBar1.Invoke(Sub()
                                            If ProgressBar1.Value = rs_id_count Then ' 100 Then
                                            Else
                                                ProgressBar1.Value += CDbl(rs_percent)
                                            End If

                                        End Sub)
                Else
                    ProgressBar1.Value += CDbl(rs_percent)
                End If
            Next

            'Next

            If ProgressBar1.InvokeRequired Then
                ProgressBar1.Invoke(Sub() ProgressBar1.Value = ProgressBar1.Maximum)
            Else
                ProgressBar1.Value = ProgressBar1.Maximum
            End If

            rs_id_count = 0
            'thread.Abort()
        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                If FlowLayoutPanel1.InvokeRequired Then
                    FlowLayoutPanel1.Invoke(Sub() FlowLayoutPanel1.Enabled = True)
                Else
                    FlowLayoutPanel1.Enabled = True
                End If

                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub load_to_drList()
        If lvlrequisitionlist.InvokeRequired Then
            lvlrequisitionlist.Invoke(Sub()
                                          For Each row As ListViewItem In lvlrequisitionlist.Items
                                              If row.BackColor = Color.DarkGreen Then
                                              ElseIf row.BackColor = Color.White Then
                                              ElseIf row.BackColor = Color.Yellow Then
                                              ElseIf row.BackColor = Color.Lime Then
                                              Else
                                                  load_dr(row.SubItems(41).Text, row.SubItems(42).Text)
                                              End If
                                          Next
                                      End Sub)
        Else
            For Each row As ListViewItem In lvlrequisitionlist.Items
                If row.BackColor = Color.DarkGreen Then
                ElseIf row.BackColor = Color.White Then
                ElseIf row.BackColor = Color.Yellow Then
                ElseIf row.BackColor = Color.Lime Then
                Else
                    load_dr(row.SubItems(41).Text, row.SubItems(42).Text)
                End If
            Next
        End If



    End Sub

    Public Sub load_dr(dr_option As String, id As Integer)

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        With FDRLIST
            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_Aggregates_Search_by_Charges", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                If dr_option = "DR" Then
                    newCMD.Parameters.AddWithValue("@n", 3)
                Else
                    newCMD.Parameters.AddWithValue("@n", 4)
                End If

                newCMD.Parameters.AddWithValue("@id", id)

                newCMD.CommandTimeout = 300
                newDR = newCMD.ExecuteReader

                Dim a(42) As String

                While newDR.Read

                    If newDR.Item("dr_option").ToString = "" Or newDR.Item("dr_option").ToString = "WITH DR" Then
                        GoTo proceedhere
                    Else

                    End If

                    If newDR.Item("date_served").ToString = "" Then
                    Else
                        a(3) = Format(Date.Parse(newDR.Item("date_served").ToString), "MM/dd/yyyy")
                    End If

                    If newDR.Item("date_served").ToString = "" Then
                    Else
                        a(3) = Format(Date.Parse(newDR.Item("date_served").ToString), "MM/dd/yyyy")
                    End If



                    a(0) = newDR.Item("ws_id_dr_id").ToString
                    a(1) = newDR.Item("dr_no").ToString
                    a(2) = newDR.Item("rs_no").ToString
                    a(4) = newDR.Item("whItem").ToString 'newDR.Item("ITEM_DESC").ToString
                    a(5) = newDR.Item("SUPP_SOURCE").ToString
                    a(6) = newDR.Item("rs_qty").ToString
                    a(7) = newDR.Item("unit").ToString
                    a(8) = newDR.Item("conssession_ticket").ToString
                    a(9) = newDR.Item("operator").ToString
                    a(10) = newDR.Item("charges").ToString
                    a(12) = newDR.Item("checked_by").ToString
                    a(13) = newDR.Item("received_by").ToString
                    a(14) = newDR.Item("dr_info_id").ToString
                    a(15) = newDR.Item("rs_id").ToString
                    a(16) = newDR.Item("IN_OUT").ToString
                    a(19) = IIf(newDR.Item("IN_OUT").ToString = "OTHERS", "Unavailable this time...", newDR.Item("ws_no").ToString)
                    a(20) = newDR.Item("par_rr_item_id").ToString
                    a(21) = newDR.Item("remarks").ToString
                    a(22) = newDR.Item("SUPPLIER").ToString
                    a(23) = newDR.Item("username").ToString
                    a(24) = newDR.Item("plate_no").ToString
                    a(25) = newDR.Item("RR_NO").ToString
                    a(27) = FormatNumber(CDbl(IIf(IsNumeric(newDR.Item("price").ToString) = True, newDR.Item("price").ToString, 0)), 2,,, TriState.True)
                    a(28) = FormatNumber(CDbl(IIf(IsNumeric(newDR.Item("total_amount").ToString) = True, newDR.Item("total_amount").ToString, 0)), 2,,, TriState.True)
                    a(29) = newDR.Item("whItemDesc").ToString
                    a(30) = Format(Date.Parse(newDR.Item("date_request").ToString), "MM/dd/yyyy")

                    If newDR.Item("IN_OUT").ToString = "OUT" Then
                        a(6) = 0
                        a(26) = newDR.Item("out_dr_qty").ToString
                    Else
                        a(6) = newDR.Item("in_dr_qty").ToString
                        a(26) = 0
                    End If

                    Dim lvl As New ListViewItem(a)
                    If .lvl_drList.InvokeRequired Then
                        .lvl_drList.Invoke(Sub()
                                               Label7.Text = newDR.Item("ws_id_dr_id").ToString & " - " & newDR.Item("whItemDesc").ToString
                                               .lvl_drList.Items.Add(lvl)
                                           End Sub)
                    Else
                        Label7.Text = newDR.Item("ws_id_dr_id").ToString & " - " & newDR.Item("whItemDesc").ToString
                        .lvl_drList.Items.Add(lvl)
                    End If

proceedhere:
                End While

                newDR.Close()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try
        End With

    End Sub

    Private Sub EndorseItemCheckingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EndorseItemCheckingToolStripMenuItem.Click

        button_click_name = "EndorseItemCheckingToolStripMenuItem"
        FListOfItems.ShowDialog()

    End Sub

    Public Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        total_rs_qty = 0
        main_rs_qty = 0
        none = False

        If cmbSearchByCategory.Text = "Search by RS.No." Or cmbSearchByCategory.Text = "Search by User Name" Or cmbSearchByCategory.Text = "Search by item" Then
            FlowLayoutPanel1.Enabled = False
            lvlrequisitionlist.Visible = False
            Dim proj As String = cmbProject.Text
            final_search(proj)
            Timer3.Start()

        ElseIf cmbSearchByCategory.Text = "Generate Summary of Hauling Aggregates" Then
            lvlrequisitionlist.Visible = False
            If Fsearchbycharges.cmbGenerateProject.Text = "Generate by All Project" Then

                FlowLayoutPanel1.Enabled = False
                Button4.PerformClick()
                Dim proj As String = cmbProject.Text
                final_search(proj)
                Timer1.Start()

            ElseIf Fsearchbycharges.cmbGenerateProject.Text = "Generate by Specific project" Then
                FlowLayoutPanel1.Enabled = False
                Dim proj As String = Fsearchbycharges.cmbProject.Text
                final_search(proj)
                Timer2.Start()
            End If

        End If

        'Fsearchbycharges.Activate()
        'Fsearchbycharges.MdiParent = FMain
        'Fsearchbycharges.Show()

    End Sub

    Public Sub load_type_of_charges_name(cmbox As ComboBox)

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("sp_crud_Requisition_Non_Item", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 13)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                cmbox.Items.Add(newDR.Item(0).ToString)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Public Sub final_search1(proj As String)

        Select Case cmbSearchByCategory.Text
            Case "Search by Charges"
                With Fsearchbycharges
                    pub_search_by_charges = 1
                    .cmbProject.Enabled = True
                    .cmbProject1.Enabled = True
                    .txtItemSearch.Enabled = True
                    .dtpdatefrom.Enabled = True
                    .dtpdateto.Enabled = True
                    .Button2.Enabled = True

                    .Button1.Enabled = True
                    load_type_of_charges_name(.cmbProject)

                    .ListBox1.Items.Clear()
                    .lvlSearchCharges.Items.Clear()

                    .lvlSearchCharges.Enabled = True
                    .GroupBox1.Enabled = True

                    .cmbProject1.Text = return_blank_space(txtSearch.Text)
                    .txtItemSearch.Text = return_blank_space(txtItemName.Text)
                    .Show()

                    If return_blank_space(txtSearch.Text) = "" And return_blank_space(txtItemName.Text) = "" Then
                    Else
                        .Button2.PerformClick()
                    End If

                End With

                Exit Sub
            Case "Search by Type of Purchasing"

                With Fsearchbycharges
                    pub_search_by_charges = 3
                    .cmbProject.Enabled = True
                    .cmbProject1.Enabled = True
                    .txtItemSearch.Enabled = True
                    .dtpdatefrom.Enabled = True
                    .dtpdateto.Enabled = True
                    .Button2.Enabled = True

                    .Button1.Enabled = True
                    load_type_of_charges_name(.cmbProject)

                    .ListBox1.Items.Clear()
                    .lvlSearchCharges.Items.Clear()

                    .lvlSearchCharges.Enabled = True
                    .GroupBox1.Enabled = True
                    .Show()
                End With

                Exit Sub
        End Select

        '------------------------------------------

        rs_id_count = 0
        Timer3.Start()
        thread1 = New System.Threading.Thread(AddressOf panelvisible)
        thread1.Start()
        lvlrequisitionlist.Items.Clear()
        Label7.Text = "Initializing..."

        Select Case cmbSearchByCategory.Text
            Case "Search by RS.No.", "Search by item"
                load_rs_rs_id1(4, placeholdervalue(txtSearch), "")

            Case "Search by Requested by", "Search by User Name", "Search by Type of Request/Sub", "Search by Type of Purchasing"
                load_rs_rs_id1(18, placeholdervalue(txtSearch), placeholdervalue(txtItemName))

            Case "Search by wh_id"
                load_rs_rs_id1(23, placeholdervalue(txtSearch), "")
            Case "Search by JO"
                load_rs_rs_id1(39, placeholdervalue(txtSearch), "")
        End Select

        thread = New System.Threading.Thread(AddressOf search_using_rs1)
        thread.Start()

    End Sub
    Private Function return_blank_space(textbox As String) As String
        If textbox = "Charges..." Then
            return_blank_space = ""
        ElseIf textbox = "Items..." Then
            return_blank_space = ""
        Else
            return_blank_space = textbox
        End If
    End Function
    Public Sub final_search(proj As String)

        If cmbSearchByCategory.Text = "Search by RS.No." Then
            load_rs_rs_id(25, placeholdervalue(txtSearch), "") '4
            lvlrequisitionlist.Items.Clear()
            load_main_qty(txtSearch.Text)

            Label7.Text = "Initializing..."

        ElseIf cmbSearchByCategory.Text = "Search by item" Then
            load_rs_rs_id(4, placeholdervalue(txtSearch), "")
            lvlrequisitionlist.Items.Clear()

            Label7.Text = "Initializing..."

        ElseIf cmbSearchByCategory.Text = "Search by User Name" Then
            load_rs_rs_id(18, placeholdervalue(txtSearch), placeholdervalue(txtItemName))
            lvlrequisitionlist.Items.Clear()
            'load_main_qty(txtSearch.Text)

            Label7.Text = "Initializing..."

        ElseIf cmbSearchByCategory.Text = "Generate Summary of Hauling Aggregates" Then

            'For Each proj As String In cmbProject.Items
            'load_rs_rs_id(10, proj, Fsearchbycharges.txtItemSearch.Text)
            'lvlrequisitionlist.Items.Clear()
            'load_main_qty(txtSearch.Text)
            Label7.Text = "Initializing..."
            'Next
        End If

        thread = New System.Threading.Thread(AddressOf search_using_rs)
        thread.Start()
    End Sub
    Public Sub search_using_rs()
        Try
            Dim rs_percent As Integer
            Dim n As Integer
            'If Integer.TryParse((rs_id_count / 100), n) Then
            '    rs_percent = rs_id_count / 100
            'Else
            '    rs_percent = 1
            'End If

            rs_percent = 1

            If ProgressBar1.InvokeRequired Then
                ProgressBar1.Invoke(Sub()
                                        ProgressBar1.Value = 0
                                        'ProgressBar1.Maximum = (rs_percent * 100)
                                        ProgressBar1.Maximum = rs_id_count
                                    End Sub)

            Else
                ProgressBar1.Value = 0
                'ProgressBar1.Maximum = (rs_percent * 100)
                ProgressBar1.Maximum = rs_id_count
            End If

            'For Each list As String In ListBox1.Items
            For i = 0 To ListBox1.Items.Count - 1

                'load_rs_new1(list)

                load_rs_new1(ListBox1.Items(i))

                If ProgressBar1.InvokeRequired Then
                    ProgressBar1.Invoke(Sub()
                                            If ProgressBar1.Value = rs_id_count Then ' 100 Then
                                            Else
                                                ProgressBar1.Value += CDbl(rs_percent)
                                            End If

                                        End Sub)
                Else
                    ProgressBar1.Value += CDbl(rs_percent)
                End If
            Next

            'Next

            If ProgressBar1.InvokeRequired Then
                ProgressBar1.Invoke(Sub() ProgressBar1.Value = ProgressBar1.Maximum)
            Else
                ProgressBar1.Value = ProgressBar1.Maximum
            End If

            rs_id_count = 0
            counter1 = 0
            'thread.Abort()
        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                If FlowLayoutPanel1.InvokeRequired Then
                    FlowLayoutPanel1.Invoke(Sub() FlowLayoutPanel1.Enabled = True)
                Else
                    FlowLayoutPanel1.Enabled = True
                End If

                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub search_using_rs1()
        Try
            Dim rs_percent As Integer
            Dim n As Integer
            'If Integer.TryParse((rs_id_count / 100), n) Then
            '    rs_percent = rs_id_count / 100
            'Else
            '    rs_percent = 1
            'End If

            rs_percent = 1

            If ProgressBar1.InvokeRequired Then
                ProgressBar1.Invoke(Sub()
                                        ProgressBar1.Value = 0
                                        'ProgressBar1.Maximum = (rs_percent * 100)
                                        ProgressBar1.Maximum = rs_id_count
                                    End Sub)

            Else
                ProgressBar1.Value = 0
                'ProgressBar1.Maximum = (rs_percent * 100)
                ProgressBar1.Maximum = rs_id_count
            End If

            For i = 0 To ListBox1.Items.Count - 1

                load_rs_new2(ListBox1.Items(i))

                If ProgressBar1.InvokeRequired Then
                    ProgressBar1.Invoke(Sub()
                                            If ProgressBar1.Value = rs_id_count Then ' 100 Then
                                            Else
                                                ProgressBar1.Value += CDbl(rs_percent)
                                            End If
                                        End Sub)
                Else
                    ProgressBar1.Value += CDbl(rs_percent)
                End If

            Next

            If ProgressBar1.InvokeRequired Then
                ProgressBar1.Invoke(Sub() ProgressBar1.Value = ProgressBar1.Maximum)
            Else
                ProgressBar1.Value = ProgressBar1.Maximum
            End If

            rs_id_count = 0
            counter1 = 0
            'thread.Abort()
        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                If FlowLayoutPanel1.InvokeRequired Then
                    FlowLayoutPanel1.Invoke(Sub() FlowLayoutPanel1.Enabled = True)
                Else
                    FlowLayoutPanel1.Enabled = True
                End If

                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub load_main_qty(rs_no As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim f As Integer
        cListOfMainQty.Clear()
        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 5)
            newCMD.Parameters.AddWithValue("@rs_no", rs_no)
            newDR = newCMD.ExecuteReader

            Dim newsMainQty As New sMainQty


            While newDR.Read
                Dim a(50) As String

                a(0) = newDR.Item("main_rs_qty_id").ToString
                a(1) = newDR.Item("rs_no").ToString
                a(5) = FormatNumber(CDec(newDR.Item("main_rs_qty").ToString), 2,,, TriState.True)

                main_rs_qty = a(5)
                main_rs_qty1 = a(5)

                newsMainQty.rs_no = newDR.Item("rs_no").ToString
                newsMainQty.main_qty = IIf(IsNumeric(newDR.Item("main_rs_qty").ToString), newDR.Item("main_rs_qty").ToString, 0)
                newsMainQty.status = IIf(IsNumeric(newDR.Item("open_qty").ToString), newDR.Item("open_qty").ToString, 0)

                cListOfMainQty.Add(newsMainQty)

                If IIf(IsNumeric(newDR.Item("open_qty").ToString), newDR.Item("open_qty").ToString, 0) = 1 Then
                    a(5) = "open-qty"
                End If

                Dim lvl As New ListViewItem(a)
                lvl.BackColor = Color.Lime
                lvl.ForeColor = Color.Black
                lvl.Font = New Font(New FontFamily("Arial"), 10, FontStyle.Bold)

                lvlrequisitionlist.Items.Add(lvl)

                'lvlrequisitionlist.Items(counter1).BackColor = Color.Lime
                'lvlrequisitionlist.Items(counter1).ForeColor = Color.Black
                'lvlrequisitionlist.Items(counter1).Font = New Font(New FontFamily("Arial"), 14, FontStyle.Bold)

                counter1 += 1
                f += 1

            End While


            If f = 0 Then
                none = False
            Else
                none = True
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Public Sub load_rs_rs_id(n As Integer, search As String, items As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        ListBox1.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@rs_no", search)
            newCMD.Parameters.AddWithValue("@items", items)
            newCMD.Parameters.AddWithValue("@searchby", cmbSearchByCategory.Text)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                If newDR.Item("IN_OUT").ToString = "IN" And newDR.Item("type_of_purchasing").ToString = "DR" And newDR.Item("typeRequest").ToString = "" And newDR.Item("process").ToString = "" Then
                Else
                    ListBox1.Items.Add(newDR.Item("rs_id").ToString)
                    rs_id_count += 1
                End If

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
            lblRecords.Text = rs_id_count
        End Try
    End Sub

    Public Sub load_rs_rs_id3(n As Integer, search As String, items As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim counter As Integer

        If lblRecords.InvokeRequired Then
            lblRecords.Invoke(Sub()
                                  lblRecords.Text = search
                                  ProgressBar1.Maximum = rs_id_count
                                  ProgressBar1.Value = 0
                                  Label7.Text = "Waiting..."
                              End Sub)
        Else
            lblRecords.Text = search
            ProgressBar1.Maximum = rs_id_count
            ProgressBar1.Value = 0
            Label7.Text = "Waiting..."
        End If

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@rs_no", search)
            newCMD.Parameters.AddWithValue("@items", items)

            If cmbSearchByCategory.InvokeRequired Then
                cmbSearchByCategory.Invoke(Sub() newCMD.Parameters.AddWithValue("@searchby", cmbSearchByCategory.Text))
            Else
                newCMD.Parameters.AddWithValue("@searchby", cmbSearchByCategory.Text)
            End If

            newDR = newCMD.ExecuteReader

            While newDR.Read

                If newDR.Item("IN_OUT").ToString = "IN" And newDR.Item("type_of_purchasing").ToString = "DR" Then
                Else
                    load_rs_new1(newDR.Item("rs_id").ToString)
                    counter += 1

                    If ProgressBar1.InvokeRequired Then
                        ProgressBar1.Invoke(Sub() ProgressBar1.Value += 1)
                    Else
                        ProgressBar1.Value += 1
                    End If
                End If

            End While

        Catch ex As Exception

            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                If FlowLayoutPanel1.InvokeRequired Then
                    FlowLayoutPanel1.Invoke(Sub() FlowLayoutPanel1.Enabled = True)
                Else
                    FlowLayoutPanel1.Enabled = True
                End If

                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

            If counter = 0 Then
                If lblRecords.InvokeRequired Then
                    lblRecords.Invoke(Sub() lblRecords.Text = "initializing...")
                Else
                    lblRecords.Text = "initializing..."
                End If
            End If

            rs_id_count = 0
        End Try
    End Sub

    Public Sub load_rs_rs_id2(n As Integer, search As String, items As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim counter As Integer

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@rs_no", search)
            newCMD.Parameters.AddWithValue("@items", items)

            If cmbSearchByCategory.InvokeRequired Then
                cmbSearchByCategory.Invoke(Sub() newCMD.Parameters.AddWithValue("@searchby", cmbSearchByCategory.Text))
            Else
                newCMD.Parameters.AddWithValue("@searchby", cmbSearchByCategory.Text)
            End If

            newDR = newCMD.ExecuteReader

            While newDR.Read
                If ListBox1.InvokeRequired Then
                    ListBox1.Invoke(Sub()
                                        If newDR.Item("IN_OUT").ToString = "IN" And newDR.Item("type_of_purchasing").ToString = "DR" Then
                                        Else
                                            ListBox1.Items.Add(newDR.Item("rs_id").ToString)
                                            rs_id_count += 1
                                        End If

                                        'ListBox1.Items.Add(newDR.Item("rs_id").ToString)
                                        'rs_id_count += 1
                                    End Sub)
                Else
                    If newDR.Item("IN_OUT").ToString = "IN" And newDR.Item("type_of_purchasing").ToString = "DR" Then
                    Else
                        ListBox1.Items.Add(newDR.Item("rs_id").ToString)
                        rs_id_count += 1
                    End If

                    'ListBox1.Items.Add(newDR.Item("rs_id").ToString)
                    'rs_id_count += 1
                End If


                If lblRecords.InvokeRequired Then
                    lblRecords.Invoke(Sub() lblRecords.Text = search & ": " & rs_id_count)
                Else
                    lblRecords.Text = search & ": " & rs_id_count
                End If
                counter += 1
            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                If FlowLayoutPanel1.InvokeRequired Then
                    FlowLayoutPanel1.Invoke(Sub() FlowLayoutPanel1.Enabled = True)
                Else
                    FlowLayoutPanel1.Enabled = True
                End If

                Return
                Exit Sub
            End If
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

            If counter = 0 Then
                If lblRecords.InvokeRequired Then
                    lblRecords.Invoke(Sub() lblRecords.Text = "initializing...")
                Else
                    lblRecords.Text = "initializing..."
                End If
            End If

        End Try
    End Sub
    Public Sub load_rs_rs_id1(n As Integer, search As String, items As String)

        'new code June 22, 2023 | this code is for search by item name by date range
        If cmbEnableDisable.Text = "DISABLE" Then
            'continue

        ElseIf cmbEnableDisable.Text = "ENABLE" Then
            ListBox1.Items.Clear()
            get_rsid_by_daterange(ComboBox5.Text, txtSearch.Text, Date.Parse(dtpFrom1.Text), Date.Parse(dtpTo1.Text))
            Exit Sub
        Else
            'continue

        End If


        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        ListBox1.Items.Clear()
        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            If n = 32 Then
                Select Case ComboBox5.Text
                    Case "Item Name"
                        newCMD.Parameters.AddWithValue("@n", n)
                        newCMD.Parameters.AddWithValue("@search", listview2_item_name)
                        newCMD.Parameters.AddWithValue("@searchby", ComboBox5.Text)

                    Case "Item Desc."
                        newCMD.Parameters.AddWithValue("@n", n)
                        newCMD.Parameters.AddWithValue("@search", listview2_item_desc)
                        newCMD.Parameters.AddWithValue("@searchby", ComboBox5.Text)

                    Case "Item Name and Item Desc."
                        newCMD.Parameters.AddWithValue("@n", n)
                        newCMD.Parameters.AddWithValue("@search", listview2_item_name & " - " & listview2_item_desc)
                        newCMD.Parameters.AddWithValue("@searchby", ComboBox5.Text)

                    Case "Proper Naming"
                        newCMD.Parameters.AddWithValue("@n", n)
                        newCMD.Parameters.AddWithValue("@search", listview2_proper_name)
                        newCMD.Parameters.AddWithValue("@searchby", ComboBox5.Text)

                    Case "wh_id"
                        newCMD.Parameters.AddWithValue("@n", 23)
                        newCMD.Parameters.AddWithValue("@rs_no", search)
                        newCMD.Parameters.AddWithValue("@items", items)
                        newCMD.Parameters.AddWithValue("@searchby", cmbSearchByCategory.Text)
                End Select
            Else
                newCMD.Parameters.AddWithValue("@n", n)
                newCMD.Parameters.AddWithValue("@rs_no", search)
                newCMD.Parameters.AddWithValue("@items", items)
                newCMD.Parameters.AddWithValue("@searchby", cmbSearchByCategory.Text)
            End If

            newDR = newCMD.ExecuteReader

            While newDR.Read
                ListBox1.Items.Add(newDR.Item("rs_id").ToString)
                rs_id_count += 1
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
            lblRecords.Text = rs_id_count.ToString("N0") & " record(s) found..."

        End Try
    End Sub
    Private Sub get_rsid_by_daterange(Optional searchby As String = "", Optional search As String = "", Optional datefrom As DateTime = Nothing, Optional dateto As DateTime = Nothing)
        Dim query As New class_query

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query
            c.add_parameter("@n", 40)
            c.add_parameter("@searchby", searchby)
            c.add_parameter("@search", search)
            c.add_parameter("@date_from", datefrom)
            c.add_parameter("@date_to", dateto)

            Dim reader As SqlDataReader = c.sql_data("proc_temp_proc_requisition_slip_search2", SQ.connection)

            While reader.Read
                ListBox1.Items.Add(reader.Item("rs_id").ToString)
                rs_id_count += 1
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
            lblRecords.Text = rs_id_count.ToString("N0") & " record(s) found..."
        End Try
    End Sub

    Private Function placeholdervalue(obj As Object) As String
        Dim textbox As TextBox = obj

        If textbox.Text = "Charges..." Then
            placeholdervalue = ""
        ElseIf textbox.Text = "Items..." Then
            placeholdervalue = ""
        ElseIf textbox.Text = "RS No..." Then
            placeholdervalue = ""
        ElseIf textbox.Text = "Requested By..." Then
            placeholdervalue = ""
        ElseIf textbox.Text = "Job Order..." Then
            placeholdervalue = ""
        Else
            placeholdervalue = textbox.Text
        End If
    End Function

    Private Function searchby(what_to_search As String, what_row As String) As Integer
        Select Case what_to_search
            Case "Search by RS.No.", "Search by Charges", "Search by Requested by", "Search by User Name", "Search by item"
                If what_row = "po_ws" Then
                    searchby = 2
                ElseIf what_row = "dr_out" Then
                    searchby = 3
                ElseIf what_row = "dr_in" Then
                    searchby = 6
                ElseIf what_row = "dr_in_others" Then
                    searchby = 7
                End If

            Case "Generate Summary of Hauling Aggregates"
                If what_row = "po_ws" Then
                    searchby = 11
                ElseIf what_row = "dr_out" Then
                    searchby = 12
                ElseIf what_row = "dr_in" Then
                    searchby = 14
                ElseIf what_row = "dr_in_others" Then
                    searchby = 13
                End If

        End Select
    End Function
    Private Sub load_ws(rs_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            If cmbSearchByCategory.InvokeRequired Then
                cmbSearchByCategory.Invoke(Sub()
                                               'If cmbSearchByCategory.Text = "Search by RS.No." Or cmbSearchByCategory.Text = "Search by Charges" Or cmbSearchByCategory.Text = "Search by Requested by" Or cmbSearchByCategory.Text = "Search by User Name" Then
                                               '    newCMD.Parameters.AddWithValue("@n", 2)

                                               'ElseIf cmbSearchByCategory.Text = "Generate Summary of Hauling Aggregates" Then
                                               '    newCMD.Parameters.AddWithValue("@n", 11)
                                               '    newCMD.Parameters.AddWithValue("@date_from", Date.Parse(Fsearchbycharges.dtpdatefrom.Text))
                                               '    newCMD.Parameters.AddWithValue("@date_to", Date.Parse(Fsearchbycharges.dtpdateto.Text))

                                               'End If
                                               Select Case searchby(cmbSearchByCategory.Text, "po_ws")
                                                   Case 2
                                                       newCMD.Parameters.AddWithValue("@n", searchby(cmbSearchByCategory.Text, "po_ws"))
                                                   Case 11
                                                       newCMD.Parameters.AddWithValue("@n", searchby(cmbSearchByCategory.Text, "po_ws"))
                                                       newCMD.Parameters.AddWithValue("@date_from", Date.Parse(dtp_from))
                                                       newCMD.Parameters.AddWithValue("@date_to", Date.Parse(dtp_to))
                                               End Select


                                               '    newCMD.Parameters.AddWithValue("@date_from", Date.Parse(Fsearchbycharges.dtpdatefrom.Text))
                                               '    newCMD.Parameters.AddWithValue("@date_to", Date.Parse(Fsearchbycharges.dtpdateto.Text))
                                           End Sub)
            Else
                'If cmbSearchByCategory.Text = "Search by RS.No." Or cmbSearchByCategory.Text = "Search by Charges" Or cmbSearchByCategory.Text = "Search by Requested by" Or cmbSearchByCategory.Text = "Search by User Name" Then
                '    newCMD.Parameters.AddWithValue("@n", 2)

                'ElseIf cmbSearchByCategory.Text = "Generate Summary of Hauling Aggregates" Then
                '    newCMD.Parameters.AddWithValue("@n", 11)
                '    newCMD.Parameters.AddWithValue("@date_from", Date.Parse(Fsearchbycharges.dtpdatefrom.Text))
                '    newCMD.Parameters.AddWithValue("@date_to", Date.Parse(Fsearchbycharges.dtpdateto.Text))

                'End If
                Select Case searchby(cmbSearchByCategory.Text, "po_ws")
                    Case 2
                        newCMD.Parameters.AddWithValue("@n", searchby(cmbSearchByCategory.Text, "po_ws"))
                    Case 11
                        newCMD.Parameters.AddWithValue("@n", searchby(cmbSearchByCategory.Text, "po_ws"))
                        newCMD.Parameters.AddWithValue("@date_from", Date.Parse(Fsearchbycharges.dtpdatefrom.Text))
                        newCMD.Parameters.AddWithValue("@date_to", Date.Parse(Fsearchbycharges.dtpdateto.Text))
                End Select
            End If

            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader
            Dim a(50) As String

            While newDR.Read
                If newDR.Item("type_of_purchasing").ToString = "DR" And newDR.Item("IN_OUT").ToString = "IN" Then
                    GoTo proceedhere
                Else

                End If

                Dim po_date As DateTime
                If newDR.Item("po_date").ToString = "" Then
                    po_date = Date.Parse("1990-01-01")
                Else
                    po_date = newDR.Item("po_date").ToString
                End If

                a(0) = newDR.Item("rs_id").ToString
                a(1) = newDR.Item("rs_no").ToString
                a(2) = Format(Date.Parse(po_date), "MM/dd/yyyy")
                a(3) = "-"
                a(4) = newDR.Item("items").ToString
                a(5) = "-"
                a(6) = newDR.Item("unit").ToString
                a(7) = "-"
                a(8) = "-" 'newDR.Item("type_of_request").ToString
                a(9) = newDR.Item("IN_OUT").ToString
                a(10) = "-"
                a(11) = "-"
                'a(12) = newDR.Item("ws_status").ToString
                a(13) = newDR.Item("charges").ToString
                a(14) = "" 'newDR.Item("location").ToString
                a(15) = newDR.Item("wh_id").ToString
                a(16) = newDR.Item("date_log").ToString
                a(17) = "" 'newDR.Item("type_of_charges").ToString
                a(18) = newDR.Item("type_of_purchasing").ToString
                a(19) = newDR.Item("remarks").ToString
                a(20) = ""
                a(21) = "" 'newDR.Item("dr_no").ToString
                a(22) = newDR.Item("po_qty").ToString
                a(23) = IIf(newDR.Item("qty_withdrawn").ToString > 0, newDR.Item("po_qty").ToString, 0)


                If a(23) = a(22) Then
                    a(12) = "withdrawn"
                ElseIf a(23) = 0 Then
                    a(12) = "pending"
                End If


                a(24) = newDR.Item("users").ToString
                'a(25) = newDR.Item("ws_id_dr_id").ToString
                a(26) = ""
                a(27) = ""
                a(28) = newDR.Item("requested_by").ToString
                a(29) = "" 'newDR.Item("cons_item").ToString
                a(30) = "" 'newDR.Item("cons_item_desc").ToString
                a(31) = "" 'newDR.Item("type_of_delivery").ToString
                a(36) = newDR.Item("ws_no").ToString
                a(41) = newDR.Item("dr_option").ToString
                a(42) = newDR.Item("dr_items_id").ToString
                If IsNumeric(newDR.Item("price").ToString) Then : a(43) = FormatNumber(CDec(newDR.Item("price").ToString), 2,,, TriState.True) : Else : a(43) = 0 : End If

                Dim lvl As New ListViewItem(a)
                lvl.BackColor = Color.LightGreen
                lvl.ForeColor = Color.Black
                lvl.Font = New Font(New FontFamily("Arial"), 10, FontStyle.Bold)

                InvokeRequiredList(lvlrequisitionlist, lvl)

                total_ws_qty += a(23)

                'lvlrequisitionlist.Items(counter1).BackColor = Color.LightGreen
                'lvlrequisitionlist.Items(counter1).ForeColor = Color.Black
                'lvlrequisitionlist.Items(counter1).Font = New Font(New FontFamily("Arial"), 10, FontStyle.Bold)

                counter1 += 1

                If Label7.InvokeRequired Then
                    Label7.Invoke(Sub() Label7.Text = a(4))
                Else
                    Label7.Text = a(4)
                End If

proceedhere:

                load_dr5(a(0), a(36))
                'load_dr6(a(0), a(36), a(15))

                'If newDR.Item("").ToString = "PURCHASE ORDER" Then
                '    load_rr_item_sub2(newDR.Item("rs_id").ToString)
                'End If
            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                Return
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()


            'If dr_with_rr(rs_id) > 0 Then ' if dr exist in rr
            '    load_dr_rr(rs_id)
            'Else
            '    'dr for others 
            '    load_dr7(rs_id, "")
            'End If

            load_dr7(rs_id, "")

            Dim a1(50) As String

            a1(0) = rs_id
            a1(37) = IIf(none = False, "TOTAL:", "Remaining Balance:")
            a1(23) = total_ws_qty 'FormatNumber(total_ws_qty, 2, TriState.False)
            a1(32) = IIf(total_dr_qty_out = 0, total_dr_qty_others, total_dr_qty_out) & IIf(total_dr_qty_in = 0, "", "/" & total_dr_qty_in)
            'a1(32) = FormatNumber(a1(32), 2, TriState.False)
            main_rs_qty = main_rs_qty - total_rs_qty

            Select Case none
                Case True
                    a1(5) = main_rs_qty 'FormatNumber(main_rs_qty, 2,,, TriState.True) '& "/" & main_rs_qty1
                Case Else
                    a1(5) = total_rs_qty 'FormatNumber(total_rs_qty, 2, TriState.False)
            End Select

            Dim lvl1 As New ListViewItem(a1)
            lvl1.BackColor = Color.White
            lvl1.ForeColor = Color.Black
            lvl1.Font = New Font(New FontFamily("Arial"), 10, FontStyle.Bold)

            InvokeRequiredList(lvlrequisitionlist, lvl1)

            'lvlrequisitionlist.Items(counter1).ForeColor = Color.Black
            'lvlrequisitionlist.Items(counter1).Font = New Font(New FontFamily("Arial"), 10, FontStyle.Bold)

            counter1 += 1

            total_ws_qty = 0
            total_dr_qty_out = 0
            total_dr_qty_in = 0
            total_dr_qty_others = 0
            total_rs_qty = 0
        End Try
    End Sub
    Private Sub load_dr_rr(rs_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 21)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newDR = newCMD.ExecuteReader
            Dim a(36) As String

            While newDR.Read
                a(0) = newDR.Item("par_rr_item_id").ToString
                a(36) = newDR.Item("rr_no").ToString
                a(23) = newDR.Item("qty").ToString

                Dim lvl As New ListViewItem(a)
                lvl.BackColor = Color.Orange

                If lvlrequisitionlist.InvokeRequired Then
                    lvlrequisitionlist.Invoke(Sub() lvlrequisitionlist.Items.Add(lvl))
                Else
                    lvlrequisitionlist.Items.Add(lvl)
                End If
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub load_po_ws(rs_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure


            newCMD.Parameters.AddWithValue("@n", 17)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader
            Dim a(50) As String

            While newDR.Read
                If newDR.Item("type_of_purchasing").ToString = "DR" And newDR.Item("IN_OUT").ToString = "IN" Then
                    GoTo proceedhere
                Else

                End If
                Dim po_date As DateTime
                If newDR.Item("po_date").ToString = "" Then
                    po_date = Date.Parse("1990-01-01")
                Else
                    po_date = newDR.Item("po_date").ToString
                End If

                Dim wh_id_from_rs As Integer = IIf(newDR.Item("wh_id_from_rs").ToString = "", 0, newDR.Item("wh_id_from_rs").ToString)
                Dim properName As String = getProperNameUsingWhId(wh_id_from_rs, True)
                Dim serialNo As String = ""

#Region "for SERIAL NO"
                If Results.rListOfTireSerialNoView.Count > 0 Then

                    Dim lookupId As Integer = Utilities.ifBlankReplaceToZero(newDR.Item("serial_id").ToString())
                    Dim found = Results.rListOfTireSerialNoView.FirstOrDefault(Function(x) x.serial_id = lookupId)
                    serialNo = If(found IsNot Nothing, found.serial_no, String.Empty)

                End If

#End Region

                a(0) = newDR.Item("rs_id").ToString
                a(1) = newDR.Item("rs_no").ToString
                a(2) = Format(po_date, "MM/dd/yyyy")
                a(3) = "-"
                a(4) = IIf(properName = "", $"- {newDR.Item("items")}", $"- {properName} {IIf(serialNo = "", "", $"| serial No: {serialNo}")}")
                a(5) = "-"
                a(6) = newDR.Item("unit").ToString
                a(7) = "-"
                a(8) = "-" 'newDR.Item("type_of_request").ToString
                a(9) = newDR.Item("IN_OUT").ToString

                If newDR.Item("IN_OUT").ToString = "IN" Or newDR.Item("IN_OUT").ToString = "OTHERS" Then
                    a(10) = newDR.Item("stat").ToString
                    a(11) = "-"
                    a(12) = "-"
                Else
                    a(10) = "-"
                    a(11) = "-"
                    a(12) = "-" 'newDR.Item("stat").ToString
                End If

                a(13) = newDR.Item("charges").ToString
                a(14) = "" 'newDR.Item("location").ToString
                a(15) = newDR.Item("wh_id").ToString
                a(16) = newDR.Item("date_log").ToString
                a(17) = "" 'newDR.Item("type_of_charges").ToString
                a(18) = newDR.Item("type_of_purchasing").ToString
                a(19) = newDR.Item("remarks").ToString
                a(20) = ""
                a(21) = "-" 'newDR.Item("dr_no").ToString
                a(22) = newDR.Item("po_qty").ToString
                a(23) = "-" 'IIf(newDR.Item("qty_withdrawn").ToString > 0, newDR.Item("po_qty").ToString, 0)
                a(24) = newDR.Item("users").ToString
                'a(25) = newDR.Item("ws_id_dr_id").ToString
                a(26) = ""
                a(27) = ""
                a(28) = newDR.Item("requested_by").ToString
                a(29) = "-" 'newDR.Item("cons_item").ToString
                a(30) = "-" 'newDR.Item("cons_item_desc").ToString
                a(31) = "-" 'newDR.Item("type_of_delivery").ToString
                a(35) = newDR.Item("po_det_id").ToString
                a(36) = newDR.Item("ws_no").ToString
                a(41) = newDR.Item("dr_option").ToString
                a(42) = newDR.Item("dr_items_id").ToString
                a(43) = FormatNumber(Utilities.ifBlankReplaceToZero(newDR.Item("price").ToString), 2,,, TriState.True)

                Dim lvl As New ListViewItem

                '# for cancel status
                If newDR.Item("cancel_status").ToString = "" Then
                    lvl = New ListViewItem(a)
                    lvl.BackColor = Color.LightGreen
                    lvl.ForeColor = Color.Black

                Else
                    a(10) = "Cancelled PO"
                    lvl = New ListViewItem(a)
                    lvl.BackColor = Color.Red
                    lvl.ForeColor = Color.White


                End If


                lvl.Font = New Font(New FontFamily("Bombardier"), 11, FontStyle.Regular)

                InvokeRequiredList(lvlrequisitionlist, lvl)

                If Label7.InvokeRequired Then
                    Label7.Invoke(Sub() Label7.Text = a(4))
                Else
                    Label7.Text = a(4)
                End If

                'total_ws_qty += a(23)
                counter1 += 1

proceedhere:

                If cmbDivision.InvokeRequired Then
                    cmbDivision.Invoke(Sub()
                                           If cmbDivision.Text = "CRUSHING AND HAULING" Then
                                               load_rr2(newDR.Item("po_det_id").ToString)
                                           Else
                                               'for partial released and withdrawn
                                               partiallyReleasedAndWithdrawn(newDR.Item("po_det_id").ToString,
                                                                             newDR.Item("ws_no").ToString,
                                                                             a(4))

                                               load_rr(newDR.Item("po_det_id").ToString)
                                           End If
                                       End Sub)
                Else
                    If cmbDivision.Text = "CRUSHING AND HAULING" Then
                        load_rr2(newDR.Item("po_det_id").ToString)
                    Else
                        'for partial withdrawn
                        partiallyReleasedAndWithdrawn(newDR.Item("po_det_id").ToString,
                                                                             newDR.Item("ws_no").ToString,
                                                                             a(4))

                        'for load rr
                        load_rr(newDR.Item("po_det_id").ToString)
                    End If
                End If

            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

            total_ws_qty = 0
            total_dr_qty_out = 0
            total_dr_qty_in = 0
            total_dr_qty_others = 0
            total_rs_qty = 0

        End Try
    End Sub

    Private Sub partiallyReleasedAndWithdrawn(param_ws_id As Integer,
                                              Optional param_ws_no As String = "",
                                              Optional param_items As String = "")

        If cListOfWsReleasedItem.Count > 0 And cListOfPartiallyWithdrawn.Count > 0 Then
            Dim data As New List(Of PropsFields.withdrawn_props_fields)
            data = cListOfWsReleasedItem.Where(Function(x) x.ws_id = param_ws_id).ToList()

            If data.Count > 0 Then
                For Each row In cListOfPartiallyWithdrawn

                    If row.withdrawn_id = data(0).withdrawn_id And Not row.status = "deleted" Then

                        Dim aa(49) As String
                        For i = 0 To 49
                            aa(i) = "-"
                        Next


                        aa(2) = row.date_partially_withdrawn
                        aa(4) = param_items
                        aa(6) = row.units
                        aa(23) = row.partially_withdrawn_qty
                        aa(36) = param_ws_no

                        Dim lvl3 As New ListViewItem(aa)
                        lvl3.BackColor = Color.LightBlue

                        InvokeRequiredList(lvlrequisitionlist, lvl3)

                    End If
                Next
            End If
        End If
    End Sub
    Private Sub load_rr(po_det_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new4", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 11)
            newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)
            newCMD.CommandTimeout = 100

            newDR = newCMD.ExecuteReader
            Dim a(45) As String

            While newDR.Read

                Dim date_received As DateTime
                If newDR.Item("date_received").ToString = "" Then
                    date_received = Date.Parse("1990-01-01")
                Else
                    date_received = newDR.Item("date_received").ToString
                End If

                Dim wh_id_from_rs As Integer = IIf(newDR.Item("wh_id").ToString = "", 0, newDR.Item("wh_id").ToString)
                Dim properName As String = getProperNameUsingWhId(wh_id_from_rs, True)

                a(0) = newDR.Item("rs_id").ToString
                a(1) = newDR.Item("rs_no").ToString
                a(2) = Format(date_received, "MM/dd/yyyy")
                a(3) = "-"
                a(4) = IIf(properName = "", $"- {newDR.Item("whItem").ToString & " - " & newDR.Item("item_desc").ToString}", $"- {properName}")
                a(5) = "-"
                a(6) = newDR.Item("unit").ToString
                a(7) = "-"
                a(8) = "-" 'newDR.Item("type_of_request").ToString
                a(9) = newDR.Item("IN_OUT").ToString
                a(10) = "-"
                a(11) = "received"
                a(12) = "-"
                a(13) = newDR.Item("CHARGES").ToString
                a(14) = "" 'newDR.Item("location").ToString
                a(15) = newDR.Item("wh_id").ToString
                a(16) = newDR.Item("date_log").ToString
                a(17) = "" 'newDR.Item("type_of_charges").ToString
                a(18) = newDR.Item("type_of_purchasing").ToString
                a(19) = newDR.Item("remarks").ToString
                a(20) = ""
                a(21) = "" 'newDR.Item("dr_no").ToString
                a(22) = "-" 'newDR.Item("po_qty").ToString
                a(23) = newDR.Item("qty").ToString 'IIf(newDR.Item("qty_withdrawn").ToString > 0, newDR.Item("po_qty").ToString, 0)

                'If a(23) = a(22) Then
                '    a(12) = "withdrawn"
                'ElseIf a(23) = 0 Then
                '    a(12) = "pending"
                'End If


                a(24) = newDR.Item("users").ToString
                'a(25) = newDR.Item("ws_id_dr_id").ToString
                a(26) = ""
                a(27) = ""
                a(28) = newDR.Item("requested_by").ToString
                a(29) = "-" 'newDR.Item("cons_item").ToString
                a(30) = "-" 'newDR.Item("cons_item_desc").ToString
                a(31) = "-" 'newDR.Item("type_of_delivery").ToString
                a(35) = newDR.Item("po_det_id").ToString
                a(36) = newDR.Item("rr_no").ToString
                a(41) = "-"
                a(42) = "-"
                a(43) = FormatNumber(CDec(newDR.Item("price").ToString), 2,,, TriState.True)

                Dim lvl As New ListViewItem(a)
                lvl.BackColor = Color.LightYellow
                lvl.ForeColor = Color.Black
                lvl.Font = New Font(New FontFamily("Bombardier"), 11, FontStyle.Regular)

                InvokeRequiredList(lvlrequisitionlist, lvl)

                If Label7.InvokeRequired Then
                    Label7.Invoke(Sub() Label7.Text = a(4))
                Else
                    Label7.Text = a(4)
                End If

            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Private Sub load_rr2(po_det_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new4", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 11)
            newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)
            newCMD.CommandTimeout = 100

            newDR = newCMD.ExecuteReader
            Dim a(45) As String

            While newDR.Read

                Dim date_received As DateTime
                If newDR.Item("date_received").ToString = "" Then
                    date_received = Date.Parse("1990-01-01")
                Else
                    date_received = newDR.Item("date_received").ToString
                End If

                a(0) = newDR.Item("rs_id").ToString
                a(1) = newDR.Item("rs_no").ToString
                a(2) = Format(date_received, "MM/dd/yyyy")
                a(3) = "-"
                a(4) = newDR.Item("whItem").ToString & " - " & newDR.Item("item_desc").ToString
                a(5) = "-"
                a(6) = newDR.Item("unit").ToString
                a(7) = "-"
                a(8) = "-" 'newDR.Item("type_of_request").ToString
                a(9) = newDR.Item("IN_OUT").ToString
                a(10) = "-"
                a(11) = "received"
                a(12) = "-"
                a(13) = newDR.Item("CHARGES").ToString
                a(14) = "" 'newDR.Item("location").ToString
                a(15) = newDR.Item("wh_id").ToString
                a(16) = newDR.Item("date_log").ToString
                a(17) = "" 'newDR.Item("type_of_charges").ToString
                a(18) = newDR.Item("type_of_purchasing").ToString
                a(19) = newDR.Item("remarks").ToString
                a(20) = ""
                a(21) = "" 'newDR.Item("dr_no").ToString
                a(22) = "-" 'newDR.Item("po_qty").ToString
                a(23) = newDR.Item("qty").ToString 'IIf(newDR.Item("qty_withdrawn").ToString > 0, newDR.Item("po_qty").ToString, 0)

                'If a(23) = a(22) Then
                '    a(12) = "withdrawn"
                'ElseIf a(23) = 0 Then
                '    a(12) = "pending"
                'End If


                a(24) = newDR.Item("users").ToString
                'a(25) = newDR.Item("ws_id_dr_id").ToString
                a(26) = ""
                a(27) = ""
                a(28) = newDR.Item("requested_by").ToString
                a(29) = "-" 'newDR.Item("cons_item").ToString
                a(30) = "-" 'newDR.Item("cons_item_desc").ToString
                a(31) = "-" 'newDR.Item("type_of_delivery").ToString
                a(35) = newDR.Item("po_det_id").ToString
                a(36) = newDR.Item("rr_no").ToString
                a(41) = "-"
                a(42) = "-"
                a(43) = FormatNumber(CDec(newDR.Item("price").ToString), 2,,, TriState.True)

                Dim lvl As New ListViewItem(a)
                lvl.BackColor = Color.LightPink
                lvl.ForeColor = Color.Black
                lvl.Font = New Font(New FontFamily("Arial"), 10, FontStyle.Italic)

                InvokeRequiredList(lvlrequisitionlist, lvl)

                If Label7.InvokeRequired Then
                    Label7.Invoke(Sub() Label7.Text = a(4))
                Else
                    Label7.Text = a(4)
                End If

                load_dr8(newDR.Item("rs_id").ToString, newDR.Item("rr_no").ToString)

            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Private Sub load_dr8(rs_id As Integer, rr_no As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            If cmbSearchByCategory.InvokeRequired Then
                cmbSearchByCategory.Invoke(Sub()
                                               newCMD.Parameters.AddWithValue("@n", 24)
                                           End Sub)
            Else
                newCMD.Parameters.AddWithValue("@n", 24)
            End If

            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.Parameters.AddWithValue("@rr_no", rr_no)

            newDR = newCMD.ExecuteReader
            Dim a(50) As String

            While newDR.Read

                a(0) = newDR.Item("rs_id").ToString
                a(1) = newDR.Item("rs_no").ToString
                a(2) = Format(Date.Parse(newDR.Item("dr_date").ToString), "MM/dd/yyyy")
                a(3) = "-"
                a(4) = newDR.Item("items").ToString
                a(5) = "-"
                a(6) = newDR.Item("unit").ToString
                a(7) = "-"
                a(8) = "-" 'newDR.Item("type_of_request").ToString
                a(9) = newDR.Item("IN_OUT").ToString
                'a(10) = newDR.Item("po_status").ToString
                a(11) = ""
                'a(12) = newDR.Item("ws_status").ToString
                a(13) = newDR.Item("charges").ToString
                a(14) = "" 'newDR.Item("location").ToString
                a(15) = newDR.Item("wh_id").ToString
                a(16) = newDR.Item("date_log").ToString
                a(17) = "" 'newDR.Item("type_of_charges").ToString
                a(18) = newDR.Item("type_of_purchasing").ToString
                a(19) = newDR.Item("remarks").ToString
                a(20) = ""
                a(21) = newDR.Item("dr_no").ToString
                a(24) = newDR.Item("users").ToString
                'a(25) = newDR.Item("ws_id_dr_id").ToString
                a(26) = ""
                a(27) = ""
                a(28) = newDR.Item("requested_by").ToString
                a(29) = "" 'newDR.Item("cons_item").ToString
                a(30) = "" 'newDR.Item("cons_item_desc").ToString
                a(31) = "" 'newDR.Item("type_of_delivery").ToString
                a(32) = newDR.Item("dr_qty").ToString
                a(33) = newDR.Item("wh_area").ToString
                a(36) = newDR.Item("rr_no").ToString
                a(41) = newDR.Item("dr_option").ToString
                a(42) = newDR.Item("dr_items_id").ToString
                If IsNumeric(newDR.Item("price").ToString) Then : a(43) = FormatNumber(CDec(newDR.Item("price").ToString), 2,,, TriState.True) : Else : a(43) = 0 : End If

                Dim lvl As New ListViewItem(a)

                lvl.BackColor = Color.LightYellow
                lvl.ForeColor = Color.Black
                lvl.Font = New Font(New FontFamily("Arial"), 10, FontStyle.Italic)

                InvokeRequiredList(lvlrequisitionlist, lvl)

                'lvlrequisitionlist.Items(counter1).BackColor = Color.LightYellow
                'lvlrequisitionlist.Items(counter1).ForeColor = Color.Black
                'lvlrequisitionlist.Items(counter1).Font = New Font(New FontFamily("Arial"), 10, FontStyle.Regular)

                counter1 += 1

                If Label7.InvokeRequired Then
                    Label7.Invoke(Sub() Label7.Text = a(4))
                Else
                    Label7.Text = a(4)
                End If

                total_dr_qty_others += a(32)

            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                Return
                Exit Sub
            End If
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
            Dim a1(50) As String

            a1(0) = rs_id
            a1(37) = IIf(none = False, "TOTAL:", "Remaining Balance:")
            a1(23) = FormatNumber(total_dr_qty_others, 2, TriState.False)
            a1(32) = IIf(total_dr_qty_out = 0, total_dr_qty_others, total_dr_qty_out) & IIf(total_dr_qty_in = 0, "", "/" & total_dr_qty_in)
            'a1(32) = FormatNumber(a1(32), 2, TriState.False)

            main_rs_qty = main_rs_qty - total_rs_qty

            Select Case none
                Case True
                    a1(5) = main_rs_qty 'FormatNumber(main_rs_qty, 2,,, TriState.True) '& "/" & main_rs_qty1
                Case Else
                    a1(5) = total_rs_qty 'FormatNumber(total_rs_qty, 2, TriState.True)
            End Select

            Dim lvl1 As New ListViewItem(a1)
            lvl1.BackColor = Color.White
            lvl1.ForeColor = Color.Black
            lvl1.Font = New Font(New FontFamily("Arial"), 10, FontStyle.Bold)

            InvokeRequiredList(lvlrequisitionlist, lvl1)

            'lvlrequisitionlist.Items(counter1).ForeColor = Color.Black
            'lvlrequisitionlist.Items(counter1).Font = New Font(New FontFamily("Arial"), 10, FontStyle.Bold)

            counter1 += 1

            total_ws_qty = 0
            total_dr_qty_out = 0
            total_dr_qty_in = 0
            total_dr_qty_others = 0
            total_rs_qty = 0
        End Try

    End Sub

    Private Sub load_rr1(rs_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new4", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 12)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.CommandTimeout = 100

            newDR = newCMD.ExecuteReader
            Dim a(45) As String

            While newDR.Read

                Dim date_received As DateTime
                If newDR.Item("date_received").ToString = "" Then
                    date_received = Date.Parse("1990-01-01")
                Else
                    date_received = newDR.Item("date_received").ToString
                End If

                Dim wh_id_from_rs As Integer = IIf(newDR.Item("wh_id").ToString = "", 0, newDR.Item("wh_id").ToString)
                Dim properName As String = getProperNameUsingWhId(wh_id_from_rs, True)

                a(0) = newDR.Item("rs_id").ToString
                a(1) = newDR.Item("rs_no").ToString
                a(2) = Format(date_received, "MM/dd/yyyy")
                a(3) = "-"
                a(4) = IIf(properName = "", $"- {newDR.Item("whItem").ToString & " - " & newDR.Item("item_desc").ToString}", $"- {properName}")
                a(5) = "-"
                a(6) = newDR.Item("unit").ToString
                a(7) = "-"
                a(8) = "-" 'newDR.Item("type_of_request").ToString
                a(9) = newDR.Item("IN_OUT").ToString
                a(10) = "-"
                a(11) = "received"
                a(12) = "-"
                a(13) = newDR.Item("CHARGES").ToString
                a(14) = "" 'newDR.Item("location").ToString
                a(15) = newDR.Item("wh_id").ToString
                a(16) = newDR.Item("date_log").ToString
                a(17) = "" 'newDR.Item("type_of_charges").ToString
                a(18) = newDR.Item("type_of_purchasing").ToString
                a(19) = newDR.Item("remarks").ToString
                a(20) = ""
                a(21) = "" 'newDR.Item("dr_no").ToString
                a(22) = "-" 'newDR.Item("po_qty").ToString
                a(23) = newDR.Item("qty").ToString 'IIf(newDR.Item("qty_withdrawn").ToString > 0, newDR.Item("po_qty").ToString, 0)

                'If a(23) = a(22) Then
                '    a(12) = "withdrawn"
                'ElseIf a(23) = 0 Then
                '    a(12) = "pending"
                'End If


                a(24) = newDR.Item("users").ToString
                'a(25) = newDR.Item("ws_id_dr_id").ToString
                a(26) = ""
                a(27) = ""
                a(28) = newDR.Item("requested_by").ToString
                a(29) = "-" 'newDR.Item("cons_item").ToString
                a(30) = "-" 'newDR.Item("cons_item_desc").ToString
                a(31) = "-" 'newDR.Item("type_of_delivery").ToString
                a(35) = newDR.Item("rs_id").ToString
                a(36) = newDR.Item("rr_no").ToString
                a(41) = "-"
                a(42) = "-"
                a(43) = FormatNumber(CDec(newDR.Item("price").ToString), 2,,, TriState.True)

                Dim lvl As New ListViewItem(a)
                lvl.BackColor = Color.LightYellow
                lvl.ForeColor = Color.Black
                lvl.Font = New Font(New FontFamily("Bombardier"), 11, FontStyle.Regular)

                InvokeRequiredList(lvlrequisitionlist, lvl)

                If Label7.InvokeRequired Then
                    Label7.Invoke(Sub() Label7.Text = a(4))
                Else
                    Label7.Text = a(4)
                End If

            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                Return
                Exit Sub
            End If
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Private Sub load_rr3(rs_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new4", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 12)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.CommandTimeout = 100

            newDR = newCMD.ExecuteReader
            Dim a(45) As String

            While newDR.Read

                Dim date_received As DateTime
                If newDR.Item("date_received").ToString = "" Then
                    date_received = Date.Parse("1990-01-01")
                Else
                    date_received = newDR.Item("date_received").ToString
                End If

                a(0) = newDR.Item("rs_id").ToString
                a(1) = newDR.Item("rs_no").ToString
                a(2) = Format(date_received, "MM/dd/yyyy")
                a(3) = "-"
                a(4) = newDR.Item("whItem").ToString & " - " & newDR.Item("item_desc").ToString
                a(5) = "-"
                a(6) = newDR.Item("unit").ToString
                a(7) = "-"
                a(8) = "-" 'newDR.Item("type_of_request").ToString
                a(9) = newDR.Item("IN_OUT").ToString
                a(10) = "-"
                a(11) = "received"
                a(12) = "-"
                a(13) = newDR.Item("CHARGES").ToString
                a(14) = "" 'newDR.Item("location").ToString
                a(15) = newDR.Item("wh_id").ToString
                a(16) = newDR.Item("date_log").ToString
                a(17) = "" 'newDR.Item("type_of_charges").ToString
                a(18) = newDR.Item("type_of_purchasing").ToString
                a(19) = newDR.Item("remarks").ToString
                a(20) = ""
                a(21) = "" 'newDR.Item("dr_no").ToString
                a(22) = "-" 'newDR.Item("po_qty").ToString
                a(23) = newDR.Item("qty").ToString 'IIf(newDR.Item("qty_withdrawn").ToString > 0, newDR.Item("po_qty").ToString, 0)

                'If a(23) = a(22) Then
                '    a(12) = "withdrawn"
                'ElseIf a(23) = 0 Then
                '    a(12) = "pending"
                'End If


                a(24) = newDR.Item("users").ToString
                'a(25) = newDR.Item("ws_id_dr_id").ToString
                a(26) = ""
                a(27) = ""
                a(28) = newDR.Item("requested_by").ToString
                a(29) = "-" 'newDR.Item("cons_item").ToString
                a(30) = "-" 'newDR.Item("cons_item_desc").ToString
                a(31) = "-" 'newDR.Item("type_of_delivery").ToString
                a(35) = newDR.Item("rs_id").ToString
                a(36) = newDR.Item("rr_no").ToString
                a(41) = "-"
                a(42) = "-"
                a(43) = FormatNumber(CDec(newDR.Item("price").ToString), 2,,, TriState.True)

                Dim lvl As New ListViewItem(a)
                lvl.BackColor = Color.LightPink
                lvl.ForeColor = Color.Black
                lvl.Font = New Font(New FontFamily("Arial"), 10, FontStyle.Italic)

                InvokeRequiredList(lvlrequisitionlist, lvl)

                If Label7.InvokeRequired Then
                    Label7.Invoke(Sub() Label7.Text = a(4))
                Else
                    Label7.Text = a(4)
                End If

                load_dr8(newDR.Item("rs_id").ToString, newDR.Item("rr_no").ToString)
            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                Return
                Exit Sub
            End If
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Private Sub load_dr5(rs_id As Integer, ws_no As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            If cmbSearchByCategory.InvokeRequired Then
                cmbSearchByCategory.Invoke(Sub()
                                               'If cmbSearchByCategory.Text = "Search by RS.No." Or cmbSearchByCategory.Text = "Search by Charges" Or cmbSearchByCategory.Text = "Search by Requested by" Or cmbSearchByCategory.Text = "Search by User Name" Then
                                               '    newCMD.Parameters.AddWithValue("@n", 3)

                                               'ElseIf cmbSearchByCategory.Text = "Generate Summary of Hauling Aggregates" Then
                                               '    newCMD.Parameters.AddWithValue("@n", 12)
                                               '    newCMD.Parameters.AddWithValue("@date_from", Date.Parse(Fsearchbycharges.dtpdatefrom.Text))
                                               '    newCMD.Parameters.AddWithValue("@date_to", Date.Parse(Fsearchbycharges.dtpdateto.Text))
                                               'End If

                                               Select Case searchby(cmbSearchByCategory.Text, "dr_out")
                                                   Case 3
                                                       newCMD.Parameters.AddWithValue("@n", searchby(cmbSearchByCategory.Text, "dr_out"))
                                                   Case 12
                                                       newCMD.Parameters.AddWithValue("@n", searchby(cmbSearchByCategory.Text, "dr_out"))
                                                       newCMD.Parameters.AddWithValue("@date_from", Date.Parse(dtp_from))
                                                       newCMD.Parameters.AddWithValue("@date_to", Date.Parse(dtp_to))
                                               End Select
                                           End Sub)
            Else
                'If cmbSearchByCategory.Text = "Search by RS.No." Or cmbSearchByCategory.Text = "Search by Charges" Or cmbSearchByCategory.Text = "Search by Requested by" Or cmbSearchByCategory.Text = "Search by User Name" Then
                '    newCMD.Parameters.AddWithValue("@n", 3)

                'ElseIf cmbSearchByCategory.Text = "Generate Summary of Hauling Aggregates" Then
                '    newCMD.Parameters.AddWithValue("@n", 12)
                '    newCMD.Parameters.AddWithValue("@date_from", Date.Parse(Fsearchbycharges.dtpdatefrom.Text))
                '    newCMD.Parameters.AddWithValue("@date_to", Date.Parse(Fsearchbycharges.dtpdateto.Text))
                'End If
                newCMD.Parameters.AddWithValue("@n", searchby(cmbSearchByCategory.Text, "dr_out"))
            End If

            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.Parameters.AddWithValue("@ws_no", ws_no)

            newDR = newCMD.ExecuteReader
            Dim a(50) As String

            While newDR.Read

                a(0) = newDR.Item("rs_id").ToString
                a(1) = newDR.Item("rs_no").ToString
                a(2) = Format(Date.Parse(newDR.Item("dr_date").ToString), "MM/dd/yyyy")
                a(3) = "-"
                a(4) = newDR.Item("items").ToString
                a(5) = "-"
                a(6) = newDR.Item("unit").ToString
                a(7) = "-"
                a(8) = "-" 'newDR.Item("type_of_request").ToString
                a(9) = newDR.Item("IN_OUT").ToString
                'a(10) = newDR.Item("po_status").ToString
                a(11) = ""
                'a(12) = newDR.Item("ws_status").ToString
                a(13) = newDR.Item("charges").ToString
                a(14) = "" 'newDR.Item("location").ToString
                a(15) = newDR.Item("wh_id").ToString
                a(16) = newDR.Item("date_log").ToString
                a(17) = "" 'newDR.Item("type_of_charges").ToString
                a(18) = newDR.Item("type_of_purchasing").ToString
                a(19) = newDR.Item("remarks").ToString
                a(20) = ""
                a(21) = newDR.Item("dr_no").ToString
                a(24) = newDR.Item("users").ToString
                'a(25) = newDR.Item("ws_id_dr_id").ToString
                a(26) = ""
                a(27) = ""
                a(28) = newDR.Item("requested_by").ToString
                a(29) = "" 'newDR.Item("cons_item").ToString
                a(30) = "" 'newDR.Item("cons_item_desc").ToString
                a(31) = "" 'newDR.Item("type_of_delivery").ToString
                a(32) = newDR.Item("dr_qty").ToString
                a(33) = newDR.Item("wh_area").ToString
                a(36) = newDR.Item("ws_no").ToString
                a(41) = newDR.Item("dr_option").ToString
                a(42) = newDR.Item("dr_items_id").ToString
                If IsNumeric(newDR.Item("price").ToString) Then : a(43) = FormatNumber(CDec(newDR.Item("price").ToString), 2,,, TriState.True) : Else : a(43) = 0 : End If

                Dim lvl As New ListViewItem(a)

                lvl.BackColor = Color.LightYellow
                lvl.ForeColor = Color.Black
                lvl.Font = New Font(New FontFamily("Arial"), 10, FontStyle.Italic)

                InvokeRequiredList(lvlrequisitionlist, lvl)

                'lvlrequisitionlist.Items(counter1).BackColor = Color.LightYellow
                'lvlrequisitionlist.Items(counter1).ForeColor = Color.Black
                'lvlrequisitionlist.Items(counter1).Font = New Font(New FontFamily("Arial"), 10, FontStyle.Regular)

                counter1 += 1

                If Label7.InvokeRequired Then
                    Label7.Invoke(Sub() Label7.Text = a(4))
                Else
                    Label7.Text = a(4)
                End If

                total_dr_qty_out += a(32)
                load_dr6(a(0), a(36), a(21), a(1))

            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                Return
                Exit Sub
            End If
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

        End Try

    End Sub

    Private Sub load_dr6(rs_id As Integer, ws_no As String, dr_no As String, rs_no As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            If cmbSearchByCategory.InvokeRequired Then
                cmbSearchByCategory.Invoke(Sub()
                                               'If cmbSearchByCategory.Text = "Search by RS.No." Or cmbSearchByCategory.Text = "Search by Charges" Or cmbSearchByCategory.Text = "Search by Requested by" Or cmbSearchByCategory.Text = "Search by User Name" Then
                                               '    newCMD.Parameters.AddWithValue("@n", 6)
                                               'ElseIf cmbSearchByCategory.Text = "Generate Summary of Hauling Aggregates" Then
                                               '    newCMD.Parameters.AddWithValue("@n", 14)
                                               '    newCMD.Parameters.AddWithValue("@date_from", Date.Parse(Fsearchbycharges.dtpdatefrom.Text))
                                               '    newCMD.Parameters.AddWithValue("@date_to", Date.Parse(Fsearchbycharges.dtpdateto.Text))
                                               'End If
                                               Select Case searchby(cmbSearchByCategory.Text, "dr_in")
                                                   Case 6
                                                       newCMD.Parameters.AddWithValue("@n", searchby(cmbSearchByCategory.Text, "dr_in"))
                                                   Case 14
                                                       newCMD.Parameters.AddWithValue("@n", searchby(cmbSearchByCategory.Text, "dr_in"))
                                                       newCMD.Parameters.AddWithValue("@date_from", Date.Parse(dtp_from))
                                                       newCMD.Parameters.AddWithValue("@date_to", Date.Parse(dtp_to))
                                               End Select
                                           End Sub)
            Else
                'If cmbSearchByCategory.Text = "Search by RS.No." Then
                '    newCMD.Parameters.AddWithValue("@n", 6)
                'ElseIf cmbSearchByCategory.Text = "Generate Summary of Hauling Aggregates" Then
                '    newCMD.Parameters.AddWithValue("@n", 14)
                '    newCMD.Parameters.AddWithValue("@date_from", Date.Parse(Fsearchbycharges.dtpdatefrom.Text))
                '    newCMD.Parameters.AddWithValue("@date_to", Date.Parse(Fsearchbycharges.dtpdateto.Text))

                'ElseIf cmbSearchByCategory.Text = "Search by Charges" Then
                '    newCMD.Parameters.AddWithValue("@n", 6)
                'End If
                newCMD.Parameters.AddWithValue("@n", searchby(cmbSearchByCategory.Text, "dr_in"))
            End If

            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.Parameters.AddWithValue("@ws_no", ws_no)
            newCMD.Parameters.AddWithValue("@dr_no", dr_no)
            newCMD.Parameters.AddWithValue("@rs_no", rs_no)

            newDR = newCMD.ExecuteReader
            Dim a(50) As String

            While newDR.Read

                a(0) = newDR.Item("rs_id").ToString
                a(1) = newDR.Item("rs_no").ToString
                a(2) = Format(Date.Parse(newDR.Item("dr_date").ToString), "MM/dd/yyyy")
                a(3) = "-"
                a(4) = newDR.Item("items").ToString
                a(5) = "-"
                a(6) = newDR.Item("unit").ToString
                a(7) = "-"
                a(8) = "-" 'newDR.Item("type_of_request").ToString
                a(9) = newDR.Item("IN_OUT").ToString
                'a(10) = newDR.Item("po_status").ToString
                a(11) = ""
                'a(12) = newDR.Item("ws_status").ToString
                a(13) = newDR.Item("charges").ToString
                a(14) = "" 'newDR.Item("location").ToString
                a(15) = newDR.Item("wh_id").ToString
                a(16) = newDR.Item("date_log").ToString
                a(17) = "" 'newDR.Item("type_of_charges").ToString
                a(18) = newDR.Item("type_of_purchasing").ToString
                a(19) = newDR.Item("remarks").ToString
                a(20) = ""
                a(21) = newDR.Item("dr_no").ToString
                a(24) = newDR.Item("users").ToString
                'a(25) = newDR.Item("ws_id_dr_id").ToString
                a(26) = ""
                a(27) = ""
                a(28) = newDR.Item("requested_by").ToString
                a(29) = "" 'newDR.Item("cons_item").ToString
                a(30) = "" 'newDR.Item("cons_item_desc").ToString
                a(31) = "" 'newDR.Item("type_of_delivery").ToString
                a(32) = newDR.Item("dr_qty").ToString
                a(33) = newDR.Item("wh_area").ToString
                a(36) = newDR.Item("ws_no").ToString
                a(41) = newDR.Item("dr_option").ToString
                a(42) = newDR.Item("dr_items_id").ToString
                If IsNumeric(newDR.Item("price").ToString) Then : a(43) = FormatNumber(CDec(newDR.Item("price").ToString), 2,,, TriState.True) : Else : a(43) = 0 : End If

                Dim lvl As New ListViewItem(a)
                lvl.BackColor = Color.LightYellow
                lvl.ForeColor = Color.Black
                lvl.Font = New Font(New FontFamily("Arial"), 10, FontStyle.Italic)

                InvokeRequiredList(lvlrequisitionlist, lvl)

                counter1 += 1

                If Label7.InvokeRequired Then
                    Label7.Invoke(Sub() Label7.Text = a(4))
                Else
                    Label7.Text = a(4)
                End If

                total_dr_qty_in += a(32)

            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                Return
                Exit Sub
            End If
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Private Sub load_dr7(rs_id As Integer, ws_no As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            If cmbSearchByCategory.InvokeRequired Then
                cmbSearchByCategory.Invoke(Sub()
                                               'If cmbSearchByCategory.Text = "Search by RS.No." Or cmbSearchByCategory.Text = "Search by Charges" Or cmbSearchByCategory.Text = "Search by Requested by" Or cmbSearchByCategory.Text = "Search by User Name" Then
                                               '    newCMD.Parameters.AddWithValue("@n", 7)

                                               'ElseIf cmbSearchByCategory.Text = "Generate Summary of Hauling Aggregates" Then
                                               '    newCMD.Parameters.AddWithValue("@n", 13)
                                               '    newCMD.Parameters.AddWithValue("@date_from", Date.Parse(Fsearchbycharges.dtpdatefrom.Text))
                                               '    newCMD.Parameters.AddWithValue("@date_to", Date.Parse(Fsearchbycharges.dtpdateto.Text))

                                               'End If
                                               Select Case searchby(cmbSearchByCategory.Text, "dr_in_others")
                                                   Case 7
                                                       newCMD.Parameters.AddWithValue("@n", searchby(cmbSearchByCategory.Text, "dr_in_others"))
                                                   Case 13
                                                       newCMD.Parameters.AddWithValue("@n", searchby(cmbSearchByCategory.Text, "dr_in_others"))
                                                       newCMD.Parameters.AddWithValue("@date_from", Date.Parse(dtp_from))
                                                       newCMD.Parameters.AddWithValue("@date_to", Date.Parse(dtp_to))
                                               End Select

                                           End Sub)
            Else
                'If cmbSearchByCategory.Text = "Search by RS.No." Or cmbSearchByCategory.Text = "Search by Charges" Or cmbSearchByCategory.Text = "Search by Requested by" Or cmbSearchByCategory.Text = "Search by User Name" Then
                '    newCMD.Parameters.AddWithValue("@n", 7)

                'ElseIf cmbSearchByCategory.Text = "Generate Summary of Hauling Aggregates" Then
                '    newCMD.Parameters.AddWithValue("@n", 13)
                '    newCMD.Parameters.AddWithValue("@date_from", Date.Parse(Fsearchbycharges.dtpdatefrom.Text))
                '    newCMD.Parameters.AddWithValue("@date_to", Date.Parse(Fsearchbycharges.dtpdateto.Text))

                'End If
                newCMD.Parameters.AddWithValue("@n", searchby(cmbSearchByCategory.Text, "dr_in_others"))
            End If

            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.Parameters.AddWithValue("@ws_no", ws_no)

            newDR = newCMD.ExecuteReader
            Dim a(50) As String

            While newDR.Read

                a(0) = newDR.Item("rs_id").ToString
                a(1) = newDR.Item("rs_no").ToString
                a(2) = Format(Date.Parse(newDR.Item("dr_date").ToString), "MM/dd/yyyy")
                a(3) = "-"
                a(4) = newDR.Item("items").ToString
                a(5) = "-"
                a(6) = newDR.Item("unit").ToString
                a(7) = "-"
                a(8) = "-" 'newDR.Item("type_of_request").ToString
                a(9) = newDR.Item("IN_OUT").ToString
                'a(10) = newDR.Item("po_status").ToString
                a(11) = ""
                'a(12) = newDR.Item("ws_status").ToString
                a(13) = newDR.Item("charges").ToString
                a(14) = "" 'newDR.Item("location").ToString
                a(15) = newDR.Item("wh_id").ToString
                a(16) = newDR.Item("date_log").ToString
                a(17) = "" 'newDR.Item("type_of_charges").ToString
                a(18) = newDR.Item("type_of_purchasing").ToString
                a(19) = newDR.Item("remarks").ToString
                a(20) = ""
                a(21) = newDR.Item("dr_no").ToString
                a(24) = newDR.Item("users").ToString
                'a(25) = newDR.Item("ws_id_dr_id").ToString
                a(26) = ""
                a(27) = ""
                a(28) = newDR.Item("requested_by").ToString
                a(29) = "" 'newDR.Item("cons_item").ToString
                a(30) = "" 'newDR.Item("cons_item_desc").ToString
                a(31) = "" 'newDR.Item("type_of_delivery").ToString
                a(32) = newDR.Item("dr_qty").ToString
                a(36) = IIf(newDR.Item("ws_no").ToString = "", newDR.Item("RR_NO").ToString, newDR.Item("ws_no").ToString)
                a(41) = newDR.Item("dr_option").ToString
                a(42) = newDR.Item("dr_items_id").ToString
                If IsNumeric(newDR.Item("price").ToString) Then : a(43) = FormatNumber(CDec(newDR.Item("price").ToString), 2,,, TriState.True) : Else : a(43) = 0 : End If

                Dim lvl As New ListViewItem(a)
                lvl.BackColor = Color.LightYellow
                lvl.ForeColor = Color.Black
                lvl.Font = New Font(New FontFamily("Arial"), 10, FontStyle.Italic)

                InvokeRequiredList(lvlrequisitionlist, lvl)

                counter1 += 1

                If Label7.InvokeRequired Then
                    Label7.Invoke(Sub() Label7.Text = a(4))
                Else
                    Label7.Text = a(4)
                End If

                total_dr_qty_others += a(32)

            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                Return
                Exit Sub
            End If
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Private Sub load_rs_new1(rs_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 1)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader
            Dim a(50) As String

            While newDR.Read

                'If newDR.Item("type_of_purchasing").ToString = "DR" Then
                '    If newDR.Item("IN_OUT").ToString = "OTHERS" Or newDR.Item("IN_OUT").ToString = "IN" Then

                '    Else
                '        GoTo proceedhere
                '    End If
                'End If

                'THIS CODE IS FOR CHECKING AGGREGATES DATA TO EXCEMPT

                For Each row In cListOfExemptedAggregates
                    If row.wh_id = IIf(Not IsNumeric(newDR.Item("wh_id").ToString), 0, newDR.Item("wh_id").ToString) Then
                        'excempt
                        GoTo proceedhere
                    End If
                Next

                Dim date_needed As DateTime
                If newDR.Item("date_needed").ToString = "" Then : date_needed = "01/01/1900" : Else : date_needed = newDR.Item("date_needed").ToString : End If

                a(0) = newDR.Item("rs_id").ToString
                a(1) = newDR.Item("rs_no").ToString
                a(2) = Format(Date.Parse(newDR.Item("date_req").ToString), "MM/dd/yyyy")
                a(3) = newDR.Item("job_order_no").ToString
                a(4) = newDR.Item("item_desc").ToString
                a(5) = CDec(newDR.Item("rs_qty").ToString)
                a(6) = newDR.Item("unit1").ToString
                a(7) = IIf(Format(Date.Parse(date_needed), "MM/dd/yyyy") = "01/01/1900", "", Format(Date.Parse(date_needed), "MM/dd/yyyy"))
                a(8) = newDR.Item("type_of_request").ToString
                a(9) = newDR.Item("IN_OUT").ToString
                a(10) = "N/A" 'newDR.Item("po_status").ToString
                a(11) = ""
                a(12) = "N/A" 'newDR.Item("ws_status").ToString
                a(13) = newDR.Item("charges").ToString
                a(14) = newDR.Item("location").ToString
                a(15) = newDR.Item("wh_id").ToString
                a(16) = newDR.Item("date_log").ToString
                a(17) = newDR.Item("type_of_charges").ToString
                a(18) = newDR.Item("type_of_purchasing").ToString
                a(19) = newDR.Item("remarks").ToString
                a(20) = ""
                a(21) = newDR.Item("dr_no").ToString

                a(24) = newDR.Item("users").ToString
                'a(25) = newDR.Item("ws_id_dr_id").ToString
                a(26) = ""
                a(27) = ""
                a(28) = newDR.Item("requested_by").ToString
                a(29) = newDR.Item("cons_item").ToString
                a(30) = newDR.Item("cons_item_desc").ToString
                a(31) = newDR.Item("type_of_delivery").ToString
                a(32) = 0
                a(33) = newDR.Item("wh_area").ToString
                a(37) = newDR.Item("qto_item_desc").ToString
                a(41) = ""
                a(42) = ""
                a(49) = newDR.Item("wh_pn_id").ToString



                Dim lvl As New ListViewItem(a)
                lvl.BackColor = Color.DarkGreen
                lvl.ForeColor = Color.White
                lvl.Font = New Font(New FontFamily("Arial"), 10, FontStyle.Bold)

                InvokeRequiredList(lvlrequisitionlist, lvl)


                'lvlrequisitionlist.Items(counter1).BackColor = Color.DarkGreen
                'lvlrequisitionlist.Items(counter1).ForeColor = Color.White
                'lvlrequisitionlist.Items(counter1).Font = New Font(New FontFamily("Arial"), 10, FontStyle.Bold)

                counter1 += 1

                total_rs_qty += a(5)

                'thread = New System.Threading.Thread(AddressOf load_ws)
                'thread.Start(a(0))        

                If Label7.InvokeRequired Then
                    Label7.Invoke(Sub() Label7.Text = a(4))
                Else
                    Label7.Text = a(4)
                End If

                If newDR.Item("type_of_purchasing").ToString = "PURCHASE ORDER" Then
                    If newDR.Item("type_of_purchasing").ToString = "CASH WITH RR" Then
                        load_rr1(newDR.Item("rs_id").ToString)
                    Else
                        load_po_ws(a(0))
                    End If
                ElseIf newDR.Item("type_of_purchasing").ToString = "CASH WITH RR" Then
                    load_rr3(newDR.Item("rs_id").ToString)
                    'load_rr2(newDR.Item("po_det_id").ToString)
                Else
                    load_ws(a(0))
                End If

proceedhere:
            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                Return
                Exit Sub
            End If
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

        End Try
    End Sub

    Private Sub load_rs_new2(rs_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 1)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader
            Dim a(50) As String

            While newDR.Read

                If newDR.Item("type_of_purchasing").ToString = "DR" Then
                    If newDR.Item("IN_OUT").ToString = "OTHERS" Or newDR.Item("IN_OUT").ToString = "IN" Then

                    Else
                        GoTo proceedhere
                    End If
                End If

                Dim date_needed As DateTime
                Dim date_updated As DateTime
                If IsDate(newDR.Item("date_needed").ToString) = True Then
                    date_needed = newDR.Item("date_needed").ToString
                Else
                    date_needed = "1990-01-01"
                End If

                If IsDate(newDR.Item("date_log_updated").ToString) = True Then
                    date_updated = newDR.Item("date_log_updated").ToString
                Else
                    date_updated = "1990-01-01"
                End If

                Dim wh_id As Double = IIf(newDR.Item("wh_id").ToString = "",
                                                                         0,
                                                                         newDR.Item("wh_id").ToString)

                Dim properName As String = getProperNameUsingWhId(wh_id)

                Dim wh_pn_id As Integer = Utilities.ifBlankReplaceToZero(newDR.Item("wh_pn_id").ToString)
                Dim properNameWithoutWhId = Results.cListOfProperNaming.Where(Function(x) x.wh_pn_id = wh_pn_id).ToList()

                a(0) = newDR.Item("rs_id").ToString
                a(1) = newDR.Item("rs_no").ToString
                a(2) = Format(Date.Parse(newDR.Item("date_req").ToString), "MM/dd/yyyy")
                a(3) = newDR.Item("job_order_no").ToString

#Region "PROPERNAMING"
                'If wh_id = 0 Then
                '    If properNameWithoutWhId.Count > 0 Then
                '        a(4) = $"{newDR.Item("item_desc_from_rs").ToString} → {properNameWithoutWhId(0).item_desc}"
                '    Else
                '        a(4) = $"{newDR.Item("item_desc_from_rs").ToString}"
                '    End If

                'Else
                '    a(4) = IIf(properName = "", newDR.Item("item_desc").ToString, $"{newDR.Item("item_desc_from_rs").ToString} ✔ ({properName})")
                'End If
                a(4) = Utilities.formatProperNamingNew_RS_WS_RR_DR(wh_pn_id,
                                                                           wh_id,
                                                                           newDR.Item("item_desc_from_rs").ToString,
                                                                           newDR.Item("item_desc").ToString)

#End Region

                a(5) = newDR.Item("rs_qty").ToString
                a(6) = newDR.Item("unit1").ToString
                a(7) = IIf(Format(Date.Parse(date_needed), "MM/dd/yyyy") = "01/01/1900", "", Format(Date.Parse(date_needed), "MM/dd/yyyy"))
                a(8) = newDR.Item("type_of_request").ToString
                a(9) = newDR.Item("IN_OUT").ToString
                a(10) = "N/A" 'newDR.Item("po_status").ToString
                a(11) = "N/A"
                a(12) = "N/A" 'newDR.Item("ws_status").ToString
                a(13) = newDR.Item("charges").ToString
                a(14) = newDR.Item("location").ToString
                a(15) = newDR.Item("wh_id").ToString
                a(16) = newDR.Item("date_log").ToString
                a(17) = newDR.Item("type_of_charges").ToString
                a(18) = newDR.Item("type_of_purchasing").ToString
                a(19) = newDR.Item("remarks").ToString
                a(20) = ""
                a(21) = "-"

                a(24) = newDR.Item("users").ToString
                'a(25) = newDR.Item("ws_id_dr_id").ToString
                a(26) = ""
                a(27) = ""
                a(28) = newDR.Item("requested_by").ToString
                a(29) = newDR.Item("cons_item").ToString
                a(30) = newDR.Item("cons_item_desc").ToString
                a(31) = newDR.Item("type_of_delivery").ToString
                a(32) = 0
                a(33) = newDR.Item("wh_area").ToString
                a(35) = 0
                a(37) = newDR.Item("qto_item_name").ToString + " -- " + newDR.Item("qto_item_des").ToString

                a(38) = newDR.Item("qto_item_name").ToString + " -- " + newDR.Item("qto_item_des").ToString ''jophet
                a(44) = newDR.Item("qto_id").ToString 'jop  het

                a(41) = ""
                a(42) = ""

                If newDR.Item("type_of_purchasing").ToString = "CASH WITHOUT RR" Then
                    a(43) = FormatNumber(CDec(newDR.Item("price").ToString), 2,,, TriState.True)
                Else
                    a(43) = "-"
                End If
                a(45) = newDR.Item("users1").ToString
                a(46) = IIf(Format(Date.Parse(date_updated), "MM/dd/yyyy") = "01/01/1900", "", Format(Date.Parse(date_updated), "MM/dd/yyyy"))
                a(47) = newDR.Item("purpose").ToString  '11/17/23 (king)
                a(48) = newDR.Item("item_checked_log").ToString '03/18/24 (king)
                a(49) = newDR.Item("wh_pn_id").ToString
                a(50) = newDR.Item("remarks_emd_purposed").ToString

                Dim lvl As New ListViewItem(a)


                If newDR.Item("cancelled").ToString > 0 Then  'for cancelled rs transaction
                    lvl.BackColor = Color.Red
                    lvl.ForeColor = Color.White
                Else 'default
                    lvl.BackColor = Color.DarkGreen
                    lvl.ForeColor = Color.White
                End If

                lvl.Font = New Font(New FontFamily(cFontsFamily.bombardier), 11, FontStyle.Regular)

                InvokeRequiredList(lvlrequisitionlist, lvl)


                'lvlrequisitionlist.Items(counter1).BackColor = Color.DarkGreen
                'lvlrequisitionlist.Items(counter1).ForeColor = Color.White
                'lvlrequisitionlist.Items(counter1).Font = New Font(New FontFamily("Arial"), 10, FontStyle.Bold)

                counter1 += 1

                total_rs_qty += a(5)

                'thread = New System.Threading.Thread(AddressOf load_ws)
                'thread.Start(a(0))               

                If Label7.InvokeRequired Then
                    Label7.Invoke(Sub() Label7.Text = a(4))
                Else
                    Label7.Text = a(4)
                End If

                If newDR.Item("type_of_purchasing").ToString = "CASH WITH RR" Then
                    load_rr1(newDR.Item("rs_id").ToString)
                Else
                    load_po_ws(a(0))
                End If


proceedhere:

            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted.. load_rs_new2", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub InvokeRequiredList(listview As ListView, lvl As ListViewItem)

        If listview.InvokeRequired Then
            listview.Invoke(Sub() listview.Items.Add(lvl))
        Else
            listview.Items.Add(lvl)
        End If

    End Sub
    Private Sub INToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles INToolStripMenuItem1.Click
        Dim calc As Decimal

        For Each row As ListViewItem In lvlrequisitionlist.Items
            If row.Selected = True Then
                If row.BackColor = Color.LightYellow And row.SubItems(9).Text = "IN" Then
                    calc += row.SubItems(32).Text
                End If
            End If
        Next

        MsgBox(calc)
    End Sub

    Private Sub OUTToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OUTToolStripMenuItem1.Click
        Dim calc As Decimal

        For Each row As ListViewItem In lvlrequisitionlist.Items
            If row.Selected = True Then
                If row.BackColor = Color.LightYellow And row.SubItems(9).Text = "OUT" Then
                    calc += row.SubItems(32).Text
                End If
            End If
        Next

        MsgBox(calc)
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        For Each ctr As Control In Me.Controls
            ctr.Enabled = True
        Next

        Panel2.Visible = False
    End Sub

    Public Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If Not thread.IsAlive Then
            'cmbProject.SelectedIndex = 1

            If (cmbProject.Items.Count - 1) = selectedindex Then
                Timer1.Stop()
                Panel3.Visible = False
                FlowLayoutPanel1.Enabled = True
                lvlrequisitionlist.Visible = True

                If cmbDivision.Text = "CRUSHING AND HAULING" And cmbSearchByCategory.Text = "Generate Summary of Hauling Aggregates" Then
                    For Each row As ListViewItem In lvlrequisitionlist.Items
                        If row.BackColor = Color.DarkGreen Then
                            row.Remove()
                        ElseIf row.BackColor = Color.Lime Then
                            row.Remove()
                        ElseIf row.BackColor = Color.White Then
                            row.Remove()
                        End If
                    Next
                End If
            Else
                Button2.PerformClick()
                Panel3.Visible = True
                Label7.Text = cmbProject.Text
                Button4.PerformClick()
            End If
            btnSearch.Enabled = True

        Else
            Label7.Text = cmbProject.Text
            Panel3.Visible = True
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If Not thread.IsAlive Then
            'cmbProject.SelectedIndex = 1
            Label7.Text = Fsearchbycharges.cmbProject.Text
            Panel3.Visible = False
            Timer2.Stop()
            FlowLayoutPanel1.Enabled = True
            lvlrequisitionlist.Visible = True

            btnSearch.Enabled = True
        Else
            Panel3.Visible = True
        End If
    End Sub

    Public Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        cmbProject.SelectedIndex = selectedindex

        If (cmbProject.Items.Count - 1) = selectedindex Then
            Timer1.Stop()
            Fsearchbycharges.Close()

        Else
            selectedindex += 1
        End If

    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        If Not thread.IsAlive Then
            Panel3.Visible = False
            Timer3.Stop()
            lvlrequisitionlist.Visible = True

            If cmbDivision.Text = "CRUSHING AND HAULING" And cmbSearchByCategory.Text = "Generate Summary of Hauling Aggregates" Then
                For Each row As ListViewItem In lvlrequisitionlist.Items
                    If row.BackColor = Color.DarkGreen Then
                        row.Remove()
                    ElseIf row.BackColor = Color.Lime Then
                        row.Remove()
                    ElseIf row.BackColor = Color.White Then
                        row.Remove()
                    End If
                Next
            End If
            FlowLayoutPanel1.Enabled = True
            btnSearch.Enabled = True

            If lvlrequisitionlist.Items.Count > 0 Then
                listfocus(lvlrequisitionlist, pub_rs_id2)
            End If

            If cmbSearchByCategory.Text = "Search by RS.No." Or cmbSearchByCategory.Text = "Search by Charges" Then
                'load ang RS Main QTY :yellow row
                'aggregates_main_rs_balance()

                If cmbDivision.Text = "CRUSHING AND HAULING" Then
                    'Dim Yellow_Rows As New Class_Try
                    'Yellow_Rows.YellowRow(lvlrequisitionlist)
                    'Button11.PerformClick()

                    Dim row_total As New Class_Row_Total(lvlrequisitionlist)
                End If

            End If
        Else
            Panel3.Visible = True
        End If
    End Sub

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        total_rs_qty = 0
        main_rs_qty = 0


        Dim proj As String = cmbProject.Text
        final_search1(proj)

    End Sub

    Private Sub panelvisible()
        If Panel3.InvokeRequired Then
            Panel3.Invoke(Sub()
                              Panel3.Visible = True
                              Label7.Text = "initializing..."
                              lvlrequisitionlist.Visible = False
                          End Sub)
        Else
            Panel3.Visible = True
            lvlrequisitionlist.Visible = False
        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        abortsearching = True

        Try
            If abortsearching = True Then
                If cmbSearchByCategory.Text = "Search by Charges" Then
                    Fsearchbycharges.thread.Abort()

                ElseIf cmbSearchByCategory.Text = "Generate Summary of Hauling Aggregates" Then
                    If thread5.IsAlive Then
                        thread5.Abort()
                        Exit Sub
                    End If

                    If thread.IsAlive Then
                        thread.Abort()
                        Exit Sub
                    End If
                Else
                    thread.Abort()
                End If
            End If

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'If cmbSearchByCategory.Text = "Search by Charges" Then
        '    Fsearchbycharges.thread.Abort()
        'Else
        '    If abortsearching = True Then
        '        thread.Abort()
        '    End If
        'End If  

    End Sub
    Public Function IsFormOpen(ByVal frm As Form) As Boolean
        If Application.OpenForms.OfType(Of Form).Contains(frm) Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub Timer4_Tick(sender As Object, e As EventArgs)
        If Not thread.IsAlive Then
            Panel3.Visible = False
            Timer3.Stop()
            lvlrequisitionlist.Visible = True
        Else
            Panel3.Visible = True
        End If
    End Sub

    Private Sub cmbDivision_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDivision.SelectedIndexChanged
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        cmbSearchByCategory.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 19)
            newCMD.Parameters.AddWithValue("@searchb_option", cmbDivision.Text)

            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                cmbSearchByCategory.Items.Add(newDR.Item("searchby").ToString)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

        If cmbDivision.Text = "WAREHOUSING AND SUPPLY" Then
            lblDRrr.Text = "RR"
            Label13.Visible = False
            Panel10.Visible = False

            Panel9.Visible = False
            Label12.Visible = False

        ElseIf cmbDivision.Text = "CRUSHING AND HAULING" Then
            lblDRrr.Text = "DR"
            'WAREHOUSING AND SUPPLY
            'CRUSHING And HAULING
            Label13.Visible = True
            Panel10.Visible = True

            Panel9.Visible = True
            Label12.Visible = True
        End If

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ListBox1.Items.Clear()

        Panel3.Visible = True
        lvlrequisitionlist.Visible = False

        If ComboBox2.Text = "Search by All" Then
            thread5 = New Threading.Thread(AddressOf dr_summary_load_rs_id)
            thread5.Start()
            Timer4.Start()
        Else
            thread5 = New Threading.Thread(AddressOf dr_summary_load_rs_id1)
            thread5.Start(cmbProject1.Text)
            Timer4.Start()
        End If

    End Sub
    Private Sub dr_summary_load_rs_id()

        For Each row As String In cmbProject.Items
            load_rs_rs_id2(10, row, dr_items)
            load_rs_rs_id3(10, row, dr_items)
        Next

    End Sub
    Private Sub dr_summary_load_rs_id1(project As String)

        load_rs_rs_id2(10, project, dr_items)
        load_rs_rs_id3(10, project, dr_items)

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)
        thread = New System.Threading.Thread(AddressOf search_using_rs)
        thread.Start()
    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click
        lvlrequisitionlist.Visible = False
        Dim proj As String = cmbProject.Text

        thread = New System.Threading.Thread(AddressOf search_using_rs)
        thread.Start()
        Timer3.Start()

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text = "Search by All" Then
            cmbProject1.Enabled = False
            'list_ListOfExAgg.Enabled = False
            btnSelecItems.Enabled = True

            cmbProject1.Items.Clear()
        Else
            cmbProject1.Enabled = True
            list_ListOfExAgg.Enabled = True
            btnSelecItems.Enabled = True
            FDRLIST.load_requestor(cmbProject1, 14)
            txtRsNo.Enabled = False
        End If
    End Sub

    Private Sub cmbRequest_cash_po_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRequest_cash_po.SelectedIndexChanged
        If cmbRequest_cash_po.Text = "CASH REQUEST" Then
            FRequisition_Non_Item.Show()
            Panel_request_po_cash.Visible = False

        Else

            button_click_name = "btnShowInputFields"

            FRequestField.btnSave.Text = "Save"
            pub_qto_id = 0
            FRequestField.Show()
            Panel_request_po_cash.Visible = False
        End If


    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Panel_request_po_cash.Visible = False
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.Click
        CheckBox2.Checked = False
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.Click
        CheckBox1.Checked = False
    End Sub

    Private Sub Timer4_Tick_1(sender As Object, e As EventArgs) Handles Timer4.Tick
        If Not thread5.IsAlive Then
            Panel3.Visible = False
            Timer4.Stop()
            lvlrequisitionlist.Visible = True

            If cmbDivision.Text = "CRUSHING AND HAULING" And cmbSearchByCategory.Text = "Generate Summary of Hauling Aggregates" Then

                If ComboBox2.Text = "Search by All" Or ComboBox2.Text = "Search by Specific Project" Then
                    For Each row As ListViewItem In lvlrequisitionlist.Items
                        If row.BackColor = Color.DarkGreen Then
                            row.Remove()
                        ElseIf row.BackColor = Color.Lime Then
                            row.Remove()
                        ElseIf row.BackColor = Color.White Then
                            row.Remove()
                        End If
                    Next
                End If
            End If
            btnSearch.Enabled = True
            'Button8.PerformClick()
        Else
            Panel3.Visible = True
        End If
    End Sub

    Private Sub INToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INToolStripMenuItem.Click
        button_click_name = "INToolStripMenuItem"

        With FWarehouse_FacilitiesTools_Checking.cmb_select_typeof_checking
            With FWarehouse_FacilitiesTools_Checking.cmb_select_typeof_checking
                .Items.Clear()
                .Items.Add("Facilities/Tools Checking")
                .Items.Add("Items Checking")
                .Items.Add("Items Set")

                .SelectedIndex = 1
                FWarehouse_FacilitiesTools_Checking.ShowDialog()

            End With
        End With

    End Sub

    Private Sub OTHERSToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles OTHERSToolStripMenuItem.Click
        button_click_name = "INToolStripMenuItem"

        With FWarehouse_FacilitiesTools_Checking.cmb_select_typeof_checking
            With FWarehouse_FacilitiesTools_Checking.cmb_select_typeof_checking

                .Items.Clear()
                .Items.Add("Facilities/Tools Checking")
                .Items.Add("Items Checking")
                .Items.Add("Items Set")

                .SelectedIndex = 1
                FWarehouse_FacilitiesTools_Checking.ShowDialog()

            End With
        End With
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        'Dim ind As Integer

        'For Each row As ListViewItem In lvlrequisitionlist.Items
        '    If row.BackColor = Color.White Then
        '        If row.SubItems(37).Text = "TOTAL:" Then
        '            ind = row.Index
        '            row.Remove()
        '        End If
        '    End If
        'Next

        'MsgBox(ind)
        Dim main_rs As Decimal
        Dim count As Integer
        Dim re As Decimal

        For Each row As ListViewItem In lvlrequisitionlist.Items
            If row.Text = TextBox1.Text Then
                If row.BackColor = Color.DarkGreen Then
                    'store main rs qty
                    main_rs = row.SubItems(5).Text
                    count += 1
                ElseIf row.BackColor = Color.LightGreen Then
                    count += 1

                    If count = 2 Then
                        row.SubItems(5).Text = main_rs & "-" & row.SubItems(23).Text & "=" & (main_rs - CDbl(row.SubItems(23).Text))
                        re = (main_rs - CDbl(row.SubItems(23).Text))
                    Else
                        row.SubItems(5).Text = re & "-" & row.SubItems(23).Text & "=" & (re - CDbl(row.SubItems(23).Text))
                        re = (re - CDbl(row.SubItems(23).Text))
                    End If


                End If
            End If
        Next

        MsgBox(main_rs)
    End Sub

    Private Sub EditChargesByBatchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditChargesByBatchToolStripMenuItem.Click
        FProjectIncharge.btnOk.Text = "Create Charges"
        FProjectIncharge.Button1.Visible = True
        FProjectIncharge.Button1.Text = "Update Charges"
        FProjectIncharge.btnOk.Enabled = False

        FProjectIncharge.ShowDialog()
    End Sub

    Private Sub Timer6_Tick(sender As Object, e As EventArgs) Handles Timer6.Tick

        rs_nn += 1

        If rs_nn = 2 Then
            Dim c_search As New Class_RS_Search(ST_Data)
            th_search = New Threading.Thread(AddressOf c_search.search_by_items)
            th_search.Start()
            Timer6.Stop()
            Timer7.Start()
            rs_nn = 0
        End If
    End Sub

    Private Sub Timer7_Tick(sender As Object, e As EventArgs) Handles Timer7.Tick
        If Not th_search.IsAlive Then
            Timer7.Stop()
            Panel12.Visible = False
            txtSearch.Enabled = True
            ListView2.Visible = True
            txtSearch.Focus()
            txtSearch.SelectAll()
        Else
            Panel12.Visible = True
        End If
    End Sub

    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick
        If Not thread.IsAlive Then
            Panel3.Visible = False
            Timer5.Stop()
            FDRLIST.Show()
        Else

            Panel3.Visible = True
        End If

    End Sub

    Private Sub OTHERSToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OTHERSToolStripMenuItem1.Click
        Dim calc As Decimal

        For Each row As ListViewItem In lvlrequisitionlist.Items
            If row.Selected = True Then
                If row.BackColor = Color.LightYellow And row.SubItems(9).Text = "OTHERS" Then
                    calc += row.SubItems(32).Text
                End If
            End If
        Next

        MsgBox(calc)
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        ListView2.Items.Clear()
        Panel11.Visible = False
        txtSearch.Focus()

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click

        '        Dim finesand, g1, three_fourth, screensand, three_eight As Decimal
        '        Dim get_rs_no As String = 0

        '        For Each row As ListViewItem In lvlrequisitionlist.Items
        '            If row.BackColor = Color.White Then
        '                If row.SubItems(4).Text = "FINE SAND" Then
        '                    'finesand = row.SubItems(5).Text
        '                    finesand += row.SubItems(5).Text
        '                    get_rs_no = row.SubItems(1).Text
        '                ElseIf row.SubItems(4).Text = "G-1" Then
        '                    'g1 = row.SubItems(5).Text
        '                    g1 += row.SubItems(5).Text
        '                    get_rs_no = row.SubItems(1).Text
        '                ElseIf row.SubItems(4).Text = "3/4 GRAVEL" Then
        '                    'three_fourth = row.SubItems(5).Text
        '                    three_fourth += row.SubItems(5).Text
        '                    get_rs_no = row.SubItems(1).Text
        '                ElseIf row.SubItems(4).Text = "3/8 GRAVEL" Then
        '                    'three_eight = row.SubItems(5).Text
        '                    three_eight += row.SubItems(5).Text
        '                    get_rs_no = row.SubItems(1).Text
        '                ElseIf row.SubItems(4).Text = "SCREEN SAND" Then
        '                    'screensand = row.SubItems(5).Text
        '                    screensand += row.SubItems(5).Text
        '                    get_rs_no = row.SubItems(1).Text
        '                Else
        '                    get_rs_no = lvlrequisitionlist.Items(row.Index - 1).SubItems(1).Text & " (Re-check)"
        '                End If


        '            End If
        '        Next

        '        total_finesand += finesand
        '        total_g1 += g1
        '        total_three_fourth += three_fourth
        '        total_three_eight += three_eight
        '        total_screensand += screensand

        '        If Application.OpenForms().OfType(Of FAggregates_General_Request2).Any Then
        '        Else
        '            GoTo procceedhere
        '        End If

        '        Dim a(6) As String
        '        Dim proj As String = FAggregates_General_Request2.temp_sto_proj
        '        With FAggregates_General_Request2

        '            a(0) = get_rs_no
        '            a(1) = finesand
        '            a(2) = g1

        '            a(3) = three_fourth
        '            a(4) = three_eight
        '            a(5) = screensand
        '            a(6) = proj

        '            Dim lvl As New ListViewItem(a)
        '            .ListView2.Items.Add(lvl)
        '        End With

        'procceedhere:

        '*******************************************************************************

        Dim get_rs_no As String = 0
        Dim items_remaining As Decimal
        Dim items, items2 As String
        Dim recheck As Boolean = False

        For Each row As ListViewItem In lvlrequisitionlist.Items
            If row.BackColor = Color.White Then

                get_rs_no = row.SubItems(1).Text
                items = row.SubItems(4).Text
                items_remaining = row.SubItems(5).Text

                If items = "" Then
                    get_rs_no = lvlrequisitionlist.Items(row.Index - 1).SubItems(1).Text & " (Re-check)"
                    items2 = lvlrequisitionlist.Items(row.Index - 1).SubItems(4).Text
                    recheck = True
                Else
                    items2 = row.SubItems(4).Text
                    recheck = False
                End If

                If Application.OpenForms().OfType(Of FAggregates_General_Request2).Any Then
                Else
                    GoTo procceedhere
                End If

                Dim a(10) As String
                Dim proj As String = FAggregates_General_Request2.temp_sto_proj
                With FAggregates_General_Request2

                    a(0) = get_rs_no
                    a(1) = 0
                    a(2) = 0
                    a(3) = 0
                    a(4) = 0
                    a(5) = 0
                    a(6) = proj
                    a(7) = items2
                    a(8) = items_remaining

                    Dim lvl As New ListViewItem(a)

                    If items = "" Then
                        lvl.ForeColor = Color.Red
                    Else
                        lvl.ForeColor = Color.Black
                    End If

                    .ListView2.Items.Add(lvl)
                End With

procceedhere:
            End If
        Next

        For Each row As ListViewItem In lvlrequisitionlist.Items
            If row.BackColor = Color.White Then
                If row.SubItems(37).Text = "TOTAL:" Then
                    row.Remove()
                End If
            End If
        Next
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        'aggregates_main_rs_balance()

        Dim Yellow_Rows As New Class_Try
        Yellow_Rows.YellowRow(lvlrequisitionlist)

    End Sub
    Private Sub get_aggregates_main_rs()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 27)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                main_qty_items(newDR.Item("agg_main_rs").ToString)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub aggregates_main_rs_balance()
        'main_qty_items("G-1")
        'main_qty_items("FINE SAND")
        'main_qty_items("3/4 GRAVEL")
        main_34 = 0 : main_finesand = 0 : main_g1 = 0 : main_item_104 = 0 : main_mixed_boulders = 0 : main_screen_sand = 0 : main_waste = 0

        Try
            get_aggregates_main_rs()

            'for item nga nag naay wh_id pero wala nag exist sa database
            For Each row As ListViewItem In lvlrequisitionlist.Items
                If row.BackColor = Color.DarkGreen Then
                    If row.SubItems(15).Text = 0 Then
                    Else
                        If check_if_exist("dbwarehouse_items", "wh_id", row.SubItems(15).Text, 1) = 0 Then
                            for_item_not_exist_aggregates(row.Index, "")
                        End If
                    End If
                End If
            Next

            Dim main_qty As Double
            Dim counter As Integer
            Dim agg_name As String = ""
            Dim get_rs_no As String = ""

            '*** FIRST STEP ****
            For Each row As ListViewItem In lvlrequisitionlist.Items

                If row.BackColor = Color.Yellow Then
                    'kwaon ang main qty first
                    counter += 1

                    If counter > 1 Then
                        'If main_qty < 0 Then
                        'Else
                        '    lvlrequisitionlist.Items(row.Index - 1).SubItems(37).Text = "Remaining Balance:"
                        '    lvlrequisitionlist.Items(row.Index - 1).SubItems(5).Text = main_qty
                        'End If

                        lvlrequisitionlist.Items(row.Index - 1).SubItems(1).Text = get_rs_no
                        lvlrequisitionlist.Items(row.Index - 1).SubItems(4).Text = agg_name
                        lvlrequisitionlist.Items(row.Index - 1).SubItems(37).Text = "Remaining Balance:"
                        lvlrequisitionlist.Items(row.Index - 1).SubItems(5).Text = main_qty

                    End If

                    get_rs_no = row.SubItems(1).Text
                    agg_name = row.SubItems(4).Text
                    main_qty = IIf(IsNumeric(row.SubItems(5).Text) = False, 0, row.SubItems(5).Text)
                End If

                If row.BackColor = Color.DarkGreen Then

                    If row.SubItems(15).Text = 0 Then
                    Else
                        If lvlrequisitionlist.Items(row.Index - 1).BackColor = Color.Yellow Then


                        ElseIf lvlrequisitionlist.Items(row.Index - 1).BackColor = Color.White Then
                            'If main_qty < 0 Then
                            'Else
                            '    lvlrequisitionlist.Items(row.Index - 1).SubItems(37).Text = "Remaining Balance:"
                            '    lvlrequisitionlist.Items(row.Index - 1).SubItems(5).Text = main_qty
                            'End If
                            lvlrequisitionlist.Items(row.Index - 1).SubItems(1).Text = get_rs_no
                            lvlrequisitionlist.Items(row.Index - 1).SubItems(4).Text = agg_name
                            lvlrequisitionlist.Items(row.Index - 1).SubItems(37).Text = "Remaining Balance:"
                            lvlrequisitionlist.Items(row.Index - 1).SubItems(5).Text = main_qty

                        End If
                    End If

                    main_qty -= row.SubItems(5).Text
                End If
            Next

            '*** SECOND STEP ****
            Dim count_rows As Integer = lvlrequisitionlist.Items.Count - 1
            'If main_qty < 0 Then
            'Else
            '    lvlrequisitionlist.Items(count_rows).SubItems(37).Text = "Remaining Balance:"
            '    lvlrequisitionlist.Items(count_rows).SubItems(5).Text = main_qty
            'End If
            lvlrequisitionlist.Items(count_rows).SubItems(1).Text = get_rs_no
            lvlrequisitionlist.Items(count_rows).SubItems(4).Text = agg_name
            lvlrequisitionlist.Items(count_rows).SubItems(37).Text = "Remaining Balance:"
            lvlrequisitionlist.Items(count_rows).SubItems(5).Text = main_qty

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        With crs_data
            .typeofcharges = ComboBox3
            .list_of_charges = ComboBox4
            .n = 3
        End With

        Dim c_search As New Class_Search_Charges(crs_data)
        c_search.select_type_of_charges()
        ComboBox4.Focus()

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged

    End Sub

    Private Sub main_qty_items(items As String)

        For Each row As ListViewItem In lvlrequisitionlist.Items
            If row.BackColor = Color.DarkGreen Then
                If row.SubItems(15).Text = 0 Then

                Else
                    If items = "FINE SAND" Then
                        main_item_checker(main_finesand, row.SubItems(15).Text, items, row.Index)
                    ElseIf items = "G-1" Then
                        main_item_checker(main_g1, row.SubItems(15).Text, items, row.Index)
                    ElseIf items = "3/4 GRAVEL" Then
                        main_item_checker(main_34, row.SubItems(15).Text, items, row.Index)
                    ElseIf items = "Mixed/Boulders/200/300/foundation fill" Then
                        main_item_checker(main_mixed_boulders, row.SubItems(15).Text, items, row.Index)
                    ElseIf items = "Waste" Then
                        main_item_checker(main_waste, row.SubItems(15).Text, items, row.Index)
                    ElseIf items = "ITEM 104" Then
                        main_item_checker(main_item_104, row.SubItems(15).Text, items, row.Index)
                    ElseIf items = "Screen Sand" Then
                        main_item_checker(main_screen_sand, row.SubItems(15).Text, items, row.Index)
                    End If
                End If
            End If
        Next

    End Sub

    Private Sub CreateMainQtyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateMainQtyToolStripMenuItem.Click

        FMainRS_New.ShowDialog()

        'For Each ctr As Control In Me.Controls
        '    If ctr.Name = "Panel2" Then
        '        ctr.Enabled = True
        '    ElseIf ctr.Name = "txtMainQty" Then
        '        ctr.Enabled = True
        '    ElseIf ctr.Name = "txtSaveMainQty" Then
        '        ctr.Enabled = True
        '    Else
        '        ctr.Enabled = False
        '    End If
        'Next


        'get_main_rsqty(lvlrequisitionlist.SelectedItems(0).SubItems(1).Text)
        'Panel2.Visible = True
        'txtMainQty.Focus()
    End Sub

    Private Sub get_main_rsqty(rs_no As String)
        'Dim newSQ As New SQLcon
        'Dim newdr As SqlDataReader

        'Try
        '    Dim query As New class_query
        '    Dim param As New Dictionary(Of String, String) From {
        '                {"@n", 4},
        '                {"rs_no", rs_no}
        '        }

        '    newdr = query.SQ_Data_Reader("proc_main_rs_qty", param, newSQ)
        '    While newdr.Read
        '        IIf(newdr.Item("open_qty").ToString = 1, cmbOpenQty.Text = "Open Qty", cmbOpenQty.Text = "Close Qty")

        '        MsgBox(newdr.Item("open_qty").ToString & vbCrLf & CStr(newdr.Item("rs_no").ToString))
        '        txtMainQty.Text = newdr.Item("main_rs_qty").ToString
        '    End While
        'Catch ex As Exception
        '    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Finally
        '    newSQ.connection.Close()
        'End Try


        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_main_rs_qty", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 4)
            newCMD.Parameters.AddWithValue("@rs_no", rs_no)
            newDR = newCMD.ExecuteReader

            While newDR.Read

                If newDR.Item("open_qty").ToString = 1 Then : cmbOpenQty.Text = "Open Qty" : Else : cmbOpenQty.Text = "Close Qty" : End If
                txtMainQty.Text = newDR.Item("main_rs_qty").ToString
                txtMainQty.Focus()

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs)

        'Dim d As Integer
        'For Each oRow As DataGridViewRow In lvlrequisitionlist.Rows
        '    po_recomendataion1 = lvlrequisitionlist.Rows(d).Cells("Column4").Value
        'Next
    End Sub

    Private Sub main_item_checker(gg As Integer, wh_id As Integer, items As String, rowindex As Integer)
        If gg > 0 Then
        Else
            check_what_items1(wh_id, items, rowindex)
        End If
    End Sub

    Private Sub CancelPOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelPOToolStripMenuItem.Click
        Dim typeOfPurchasing As String = lvlrequisitionlist.SelectedItems(0).SubItems(18).Text



#Region "FILTER BEFORE CANCELATION"
        'withdrawal
        If typeOfPurchasing = typeOfPurchasingEnum.withdrawal Then
            MessageBox.Show("unable to cancel po if transactions are withdrawal...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If

        'if already received
        Dim cancelation As New useRsForm
        Dim param As New PropsFields.rsFormParam_props_fields

        With param
            .lvl = lvlrequisitionlist
            .id = lvlrequisitionlist.SelectedItems(0).SubItems(col_po_det_id_rr_item_id.Index).Text
        End With

        cancelation.initialized(param)
        If cancelation.countReceivedItem(col_po_det_id_rr_item_id.Index) > 0 Then
            customMsg.message("error", $"Unable to cancel this item if already received, { vbCrLf } to do that you need to cancel receiving first...", "SUPPLY INFO:")
            Exit Sub
        End If
#End Region


        If MessageBox.Show("Are you sure you want to cancel selected items?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            For Each row As ListViewItem In lvlrequisitionlist.Items

                If row.Selected Then
                    If row.BackColor = Color.LightGreen Then
                        'continue 
                    Else
                        GoTo continuehere
                    End If

                    If row.SubItems(18).Text = typeOfPurchasingEnum.purchasedOrder Then
                        'update status 
                        cancel_status(row.SubItems(35).Text)
                    Else
                        GoTo continuehere
                    End If
continuehere:

                End If
            Next
        End If

        btnSearch.PerformClick()

        '        If MessageBox.Show("Are you sure you want to cancel selected items?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
        '            For Each row As ListViewItem In lvlrequisitionlist.Items

        '                If row.Selected Then
        '                    If row.BackColor = Color.LightGreen Then
        '                        'continue 
        '                    Else
        '                        GoTo continuehere
        '                    End If

        '                    If row.SubItems(18).Text = "PURCHASE ORDER" Then
        '                        'update status 
        '                        cancel_status(row.SubItems(35).Text)
        '                    Else
        '                        GoTo continuehere
        '                    End If
        'continuehere:

        '                End If
        '            Next
        '        End If

        '        btnSearch.PerformClick()

    End Sub
    Private Sub remove_cancelled_status(po_det_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            Dim query As String = "update dbPO_details set cancel_status = null where po_det_id = " & po_det_id
            newCMD = New SqlCommand(query, newSQ.connection)
            'newDR = newCMD.ExecuteReader
            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Private Sub cancel_status(po_det_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            Dim query As String = "update dbPO_details set cancel_status = 1 where po_det_id = " & po_det_id
            newCMD = New SqlCommand(query, newSQ.connection)
            'newDR = newCMD.ExecuteReader
            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub RemoveCancelPOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveCancelPOToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you want to remove Cancelled PO?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            For Each row As ListViewItem In lvlrequisitionlist.Items

                If row.Selected Then
                    If row.BackColor = Color.Red Then
                        'continue 
                    Else
                        GoTo continuehere
                    End If

                    If row.SubItems(18).Text = "PURCHASE ORDER" Then
                        'remove status 
                        remove_cancelled_status(row.SubItems(35).Text)
                    Else
                        GoTo continuehere
                    End If
continuehere:

                End If
            Next
        End If

        btnSearch.PerformClick()
    End Sub

    Private Sub btnSelecItems_Click(sender As Object, e As EventArgs) Handles btnSelecItems.Click
        FSelectItemsForSummaryOFHauledAgg.searchcategory = ComboBox2.Text
        FSelectItemsForSummaryOFHauledAgg.specificProject = cmbProject1.Text
        FSelectItemsForSummaryOFHauledAgg.ShowDialog()

    End Sub

    Private Sub cavass_reportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles cavass_reportToolStripMenuItem.Click
        getreq_info_canvass()
    End Sub

    Private Sub for_item_not_exist_aggregates(index As Integer, items As String)
        With lvlrequisitionlist.Items.Insert(index, "")
            .SubItems.Add("")
            .SubItems.Add("")
            .SubItems.Add("")
            .SubItems.Add(items.ToUpper)
            .SubItems.Add("")
            .BackColor = Color.Yellow
            .Font = New Font("Arial", 12, FontStyle.Bold)
        End With
    End Sub

    Private Sub EditRSQTYOnlyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditRSQTYOnlyToolStripMenuItem.Click
        FEditRSQtyOnly.cRsQty = lvlrequisitionlist.SelectedItems(0).SubItems(5).Text
        FEditRSQtyOnly.ShowDialog()

    End Sub

    Private Sub lvlrequisitionlist_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles lvlrequisitionlist.SelectedIndexChanged

    End Sub

    Private Sub check_what_items1(wh_id As Integer, items As String, index As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim counter As Integer

        Try

            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 26)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newCMD.Parameters.AddWithValue("@items", items)
            newCMD.Parameters.AddWithValue("@rs_id", lvlrequisitionlist.Items(index).Text)

            newDR = newCMD.ExecuteReader

            While newDR.Read

                If newDR.Item("tt").ToString = 1 Then

                    With lvlrequisitionlist.Items.Insert(index, "")
                        .SubItems.Add(newDR.Item("rs_no").ToString)
                        .SubItems.Add("")
                        .SubItems.Add("")
                        .SubItems.Add(items.ToUpper)
                        .SubItems.Add(newDR.Item("main_qty").ToString)
                        .BackColor = Color.Yellow
                        .Font = New Font("Arial", 12, FontStyle.Bold)
                    End With

                    If items = "FINE SAND" Then
                        main_finesand += 1
                    ElseIf items = "G-1" Then
                        main_g1 += 1
                    ElseIf items = "3/4 GRAVEL" Then
                        main_34 += 1
                    ElseIf items = "Mixed/Boulders/200/300/foundation fill" Then
                        main_mixed_boulders += 1
                    ElseIf items = "Waste" Then
                        main_waste += 1
                    ElseIf items = "ITEM 104" Then
                        main_item_104 += 1
                    ElseIf items = "Screen Sand" Then
                        main_screen_sand += 1
                    End If

                End If
                counter += 1
            End While


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Private Sub cmbEnableDisable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEnableDisable.SelectedIndexChanged
        If cmbEnableDisable.Text = "DISABLE" Then
            Panel14.Visible = False
        Else
            Panel14.Visible = True
        End If
    End Sub

    Private Sub CancelToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem1.Click
        Try
            Dim cancelRs As New Model_King_Dynamic_Update()
            Dim rs_id As Integer = lvlrequisitionlist.SelectedItems(0).Text


            If isPOReleased(rs_id) And lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "IN" OrElse isPOReleased(rs_id) And lvlrequisitionlist.SelectedItems(0).SubItems(9).Text = "OTHERS" Then
                customMsg.message("error", "unable to cancel rs, po or ws has been released!" & vbCrLf &
                                  "please contact the administrator for more info.", "SUPPLY INFO:")
                Exit Sub
            End If

            With FCancelForm
                If isCancelled(rs_id) Then
                    .cIsCancelled = True
                End If
                .ShowDialog()
            End With
        Catch ex As Exception
            customMsg.message("error", ex.Message, "SUPPLY INFO")
        End Try





    End Sub

    Private Sub UncancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UncancelToolStripMenuItem.Click
        Dim unCancelRs As New Model_King_Dynamic_Update()
        Dim rs_id As Integer = lvlrequisitionlist.SelectedItems(0).Text

        If Not isCancelled(rs_id) Then
            customMsg.message("error", "this item is not cancelled yet!", "SUPPLY INFO")
            Exit Sub
        End If

        If MessageBox.Show("Are you sure you want to uncancel this selected item?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            'Dim columnValues As New Dictionary(Of String, Object)()
            'columnValues.Add("trans", "")

            'unCancelRs.UpdateData("dbrequisition_slip", columnValues, $"rs_id = {rs_id}")



            unCancelRs.DeleteData("dbCancelledTransaction", $"trans_id = {rs_id }")
            customMsg.message("info", "Successfully uncancelled...", "SUPPLY INFO:")
            btnSearch.PerformClick()
        End If
    End Sub

    Public Function isCancelled(id As Integer) As Boolean
        Dim cancelled As New Model_Dynamic_Select

        Dim table As String = "dbCancelledTransaction a" 'table
        Dim condition As String = $"a.trans_id = {id}" 'conditions

        'columns
        cancelled.join_columns("a.trans_id")
        'end columns


        'initialize data
        cancelled._initialize(table, condition, cancelled.cJoinColumns, cancelled.cJoining)


        Dim rrData As New List(Of Object) 'create a list of ojbect 
        rrData = cancelled.select_query() 'get data


        If rrData.Count > 0 Then
            isCancelled = True
        End If
    End Function

    Public Function isPOReleased(id As Integer) As Boolean
        Dim poReleased As New Model_Dynamic_Select

        Dim table As String = "dbPO_details a" 'table
        Dim condition As String = $"a.rs_id = {id}" 'conditions

        'columns
        poReleased.join_columns("a.po_det_id")
        'end columns


        'initialize data
        poReleased._initialize(table, condition, poReleased.cJoinColumns, poReleased.cJoining)


        Dim rrData As New List(Of Object) 'create a list of ojbect 
        rrData = poReleased.select_query() 'get data


        If rrData.Count > 0 Then
            isPOReleased = True
        End If
    End Function

    Private Sub RemarksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemarksToolStripMenuItem.Click
        If isCancelled(lvlrequisitionlist.SelectedItems(0).Text) Then
            'MsgBox()
            customMsg.message("info", getCancelledRemarks(lvlrequisitionlist.SelectedItems(0).Text), "SUPPLY INFO:")
        Else
            customMsg.message("warning", "This item is not cancelled yet!", "SUPPLY INFO:")
        End If

    End Sub

    Public Function getCancelledRemarks(rs_id As Integer) As String
        getCancelledRemarks = ""

        If isCancelled(rs_id) Then
            Dim cancelled As New Model_Dynamic_Select

            Dim table As String = "dbCancelledTransaction a" 'table
            Dim condition As String = $"a.trans_id = {lvlrequisitionlist.SelectedItems(0).Text }" 'conditions

            'columns
            cancelled.join_columns("a.remarks")
            'end columns

            'initialize data
            cancelled._initialize(table, condition, cancelled.cJoinColumns, cancelled.cJoining)


            Dim rrData As New List(Of Object) 'create a list of ojbect 
            rrData = cancelled.select_query() 'get data


            For Each row In rrData
                getCancelledRemarks = row("remarks").ToString
            Next

            Return getCancelledRemarks
        End If
    End Function

    Private Sub ListView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView2.SelectedIndexChanged

    End Sub

    Private Sub Button14_Click_1(sender As Object, e As EventArgs) Handles Button14.Click
        searchByItems(cSearchByItemE.item_desc_for_rs,
                                   txtSearch.Text)
    End Sub


    Private Sub EditRsQtyAuthToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditRsQtyAuthToolStripMenuItem.Click
        Dim where As String = "rs_id"
        Dim rs_id As Integer = lvlrequisitionlist.SelectedItems(0).Text

        Dim newUpdateFrom As New UpdateForm

        With newUpdateFrom
            .qtyPlaceholder = "Qty Here..."
            .unitsPlaceholder = "Units Here..."
            .toolTip = "qty"

            .cTypes = enumType.ifInteger
            .cTableName = "dbrequisition_slip"

            'table columns
            .column = "qty"
            .column2 = "unit"

            .cWhereId = where
            .cId = rs_id

            .ShowDialog()
        End With
    End Sub


    Private Sub EditProperNamingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditProperNamingToolStripMenuItem.Click
        If lvlrequisitionlist.SelectedItems(0).SubItems(15).Text = "" Or lvlrequisitionlist.SelectedItems(0).SubItems(15).Text = 0 Then

            FLinkToProperNaming.isFromRequisitionFormEdit = True
            FLinkToProperNaming.ShowDialog()

        Else
            customMsg.message("error", "Items cannot be set proper naming once they are item-checked.", "SUPPLY INFO:")
        End If
    End Sub

    Private Sub btnSaveMainQty_Click(sender As Object, e As EventArgs) Handles btnSaveMainQty.Click


        'Dim rs_no As String
        'Dim rs_id As Integer

        'With lvlrequisitionlist

        '    rs_no = .Items(.SelectedItems(0).Index + 1).SubItems(1).Text
        '    rs_id = .Items(.SelectedItems(0).Index + 1).Text
        'End With

        'save_update_main_rs(rs_no, txtMainQty.Text, rs_id)
        'Button3.PerformClick()
        ''Button2.PerformClick()
        'btnSearch.PerformClick()

        Dim rs_no As String = lvlrequisitionlist.SelectedItems(0).SubItems(1).Text

        FRequestField.save_update_main_rs(rs_no, txtMainQty.Text)
        Button3.PerformClick()
        Button2.PerformClick()
    End Sub

    Public Sub save_update_main_rs(rs_no As String, main_rs_qty As Double, rs_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_create_update_main_rs_qty", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@rs_no", rs_no)
            newCMD.Parameters.AddWithValue("@main_rs_qty", main_rs_qty)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.Parameters.AddWithValue("@user_id", pub_user_id)

            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Private Sub txtMainQty_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMainQty.KeyDown
        Dim str As String = txtMainQty.Text

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

    Private Sub RemoveMainRSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveMainRSToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you want to remove this main rs qty?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim newSQ As New SQLcon
            Dim newCMD As SqlCommand

            Dim rs_no As String = lvlrequisitionlist.SelectedItems(0).SubItems(1).Text

            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 8)
                newCMD.Parameters.AddWithValue("@rs_no", rs_no)
                newCMD.ExecuteNonQuery()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
                MessageBox.Show("Successfully Removed...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lvlrequisitionlist.SelectedItems(0).Remove()

            End Try

        End If
    End Sub

    Private Sub lvlrequisitionlist_Click(sender As Object, e As EventArgs) Handles lvlrequisitionlist.Click
        Try
            If lvlrequisitionlist.Items.Count > 0 Then
                pub_rs_id2 = IIf(IsNumeric(lvlrequisitionlist.SelectedItems(0).Text), lvlrequisitionlist.SelectedItems(0).Text, 0)
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ListView2_DoubleClick(sender As Object, e As EventArgs) Handles ListView2.DoubleClick
        If ComboBox5.Text = "" Then
            MessageBox.Show("please select what column you want to search.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            If cmbDivision.Text = "WAREHOUSING AND SUPPLY" Then
                load_by_selected_items()
            Else
                Select Case ComboBox5.Text
                    Case cSearchByItemE.item_name

                        If cmbEnableDisable.Text = "ENABLE" Then
                            searchByItems(cSearchByItemE.item_name,
                                          ListView2.SelectedItems(0).SubItems(1).Text)

                            Button13.PerformClick()
                        End If
                    Case cSearchByItemE.item_desc_for_rs

                        If cmbEnableDisable.Text = "ENABLE" Then
                            searchByItems(cSearchByItemE.item_desc_for_rs,
                                          txtSearch.Text)

                            Button13.PerformClick()
                        End If

                    Case cSearchByItemE.item_desc

                End Select
                'MessageBox.Show("this function is under maintenance!", "SUPPY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If


    End Sub

    Private Sub searchByItems(searchBy As String, search As String)
        DRModel.clear()

        Dim param As New Dictionary(Of String, Object)
        param.Add("panel", loadingPanel)
        param.Add("listview", lvlrequisitionlist)

        param.Add("dateEnable", True)
        param.Add("searchby", searchBy)
        param.Add("search", search)
        param.Add("dateFrom", Date.Parse(dtpFrom1.Text))
        param.Add("dateTo", Date.Parse(dtpTo1.Text))
        param.Add("rsLabel", lblRs1)
        param.Add("wsLabel", lblWs)
        param.Add("poLabel", lblPo)
        param.Add("drLabel", lblDr)
        param.Add("mainRsLabel", lblMainRs1)

        param.Add("oldLoadingPanel", Panel3)

        DRModel.initialize(param)

        DRModel.execute_by_items()

    End Sub
    Private Sub load_by_selected_items()
        Dim item_desc As String = ListView2.SelectedItems(0).SubItems(2).Text
        Dim wh_id As Integer = ListView2.SelectedItems(0).Text

        listview2_item_name = ListView2.SelectedItems(0).SubItems(1).Text
        listview2_item_desc = ListView2.SelectedItems(0).SubItems(2).Text
        listview2_proper_name = ListView2.SelectedItems(0).SubItems(5).Text

        If ComboBox5.Text = "Item Name" Then
            txtSearch.Text = listview2_item_name
        ElseIf ComboBox5.Text = "Item Desc." Then
            txtSearch.Text = listview2_item_desc
        ElseIf ComboBox5.Text = "Proper Naming" Then
            txtSearch.Text = listview2_proper_name
        End If

        txtSearch.SelectAll()
        txtSearch.Focus()


        rs_id_count = 0
        Timer3.Start()
        thread1 = New System.Threading.Thread(AddressOf panelvisible)
        thread1.Start()
        lvlrequisitionlist.Items.Clear()
        Label7.Text = "Initializing..."

        '23 or 32 exclusive for search by item
        '<==kung naay edugang where statement diri raka mag edit
        load_rs_rs_id1(32, wh_id, "") '==>

        thread = New System.Threading.Thread(AddressOf search_using_rs1)
        thread.Start()

        Panel11.Visible = False
        Timer6.Stop()
        Timer7.Stop()

    End Sub


    Private Sub ListView2_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView2.KeyDown
        If e.KeyCode = Keys.Back Then
            Panel11.Visible = False
            txtSearch.Focus()
        ElseIf e.KeyCode = Keys.Enter Then
            If ComboBox5.Text = "" Then
                MessageBox.Show("please select what column you want to search.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                load_by_selected_items()
            End If

        End If
    End Sub

    Private Sub Button13_MouseDown(sender As Object, e As MouseEventArgs) Handles Button13.MouseDown
        Button13.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub Button13_MouseEnter(sender As Object, e As EventArgs) Handles Button13.MouseEnter
        Button13.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub Button13_MouseLeave(sender As Object, e As EventArgs) Handles Button13.MouseLeave
        Button13.BackgroundImage = My.Resources.close_button
    End Sub

    Private Sub ComboBox4_GotFocus(sender As Object, e As EventArgs) Handles ComboBox4.GotFocus
        sender.DroppedDown = True
    End Sub

    Public Sub get_all_podetails()
        Dim id_det As String = ""
        all_rr_po_det_id = ""
        For Each lvi As ListViewItem In lvlrequisitionlist.Items
            If lvi.BackColor = Color.LightGreen Then
                id_det = id_det + "," + lvi.SubItems(35).Text
            End If
        Next

        If all_rr_po_det_id <> "" Then
            all_rr_po_det_id = id_det.Remove(0, 1)
        End If
        ''  MsgBox(all_rr_po_det_id)
    End Sub

    Public Sub getreq_info_canvass()
        Dim SQ As New SQLcon
        Dim dr As SqlDataReader
        'Dim newcmd As SqlCommand
        Canvas_Report_req.dgvPOList.Rows.Clear()
        'Dim i As Integer = get_id_projeccode(cmbSearch_Project_WorkSite.Text)
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "proc_requisition_slip"
            sqlcomm.CommandType = CommandType.StoredProcedure

            sqlcomm.Parameters.AddWithValue("@searchby", txtSearch.Text)
            sqlcomm.Parameters.AddWithValue("@n", 455)
            dr = sqlcomm.ExecuteReader
            While dr.Read

                Dim a(20) As String
                a(2) = dr.Item(2).ToString
                a(3) = dr.Item(1).ToString
                a(4) = dr.Item(7).ToString
                a(5) = dr.Item(3).ToString
                a(9) = dr.Item(4).ToString & " " & dr.Item(5).ToString

                'a(0) = dr.Item(2).ToString
                'a(1) = dr.Item(3).ToString
                ' a(2) = dr.Item(4).ToString
                'If x = 4 Then
                '    a(5) = dr.Item("plate_no")
                'Else
                '    a(5) = get_ProjectName_Designation(dr.Item(5).ToString, 1)
                'End If
                ''  a(4) = dr.Item(6).ToString
                ''  a(5) = FormatNumber(dr.Item(7).ToString)
                ''     a(6) = FormatNumber(dr.Item(10).ToString)
                'Dim lvl As New ListViewItem(a)
                Canvas_Report_req.purpose_txt.Text = dr.Item(6).ToString
                Canvas_Report_req.dgvPOList.Rows.Add(a)
            End While

            Canvas_Report_req.ShowDialog()
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "supply INFOSsss", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

    End Sub

    Private Sub lvlrequisitionlist_DrawSubItem(sender As Object, e As DrawListViewSubItemEventArgs) Handles lvlrequisitionlist.DrawSubItem
        e.DrawDefault = True ' Let the system draw the default item style

        ' Add padding to the left of each item
        Dim padding As Integer = 10 ' Set the desired padding value
        Dim bounds As Rectangle = e.Bounds
        bounds.X += padding ' Adjust the left position
        bounds.Width -= padding ' Adjust the width
        TextRenderer.DrawText(e.Graphics, e.Item.Text, e.Item.Font, bounds, e.Item.ForeColor, e.Item.BackColor, TextFormatFlags.Left)
    End Sub

    Private Sub Panel5_Click(sender As Object, e As EventArgs) Handles Panel5.Click
        If publicvariables.auth = "Admin" Then
            Panel11.Visible = True
        End If

    End Sub
End Class
