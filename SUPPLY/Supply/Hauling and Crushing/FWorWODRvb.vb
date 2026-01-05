Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FWorWODRvb
    Private Sub WithDRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WithDRToolStripMenuItem.Click
        FDeliveryReceipt.Activate()
        FDeliveryReceipt.MdiParent = Me
        FDeliveryReceipt.Dock = DockStyle.Fill

        FDeliveryReceipt.trigger("in without rs", "IN")
        FDeliveryReceipt.Show()

        Exit Sub


        With FDeliveryReceipt
            with_dr_status = "in without rs"

            For Each ctr As Control In .Panel7.Controls
                ctr.Enabled = True
            Next

            .cmbOptions.Enabled = False
            .btnSave.Text = "Save"

            .txtrsno.Text = "N/A"
            '.dtpTimeFrom.Enabled = True
            '.dtpTime_to.Enabled = True
            .txtPlateNo.Enabled = True
            .cmbOperator.Enabled = True
            .cmbTypeofCharge.Enabled = True
            .cmbChargeTo.Enabled = True
            .txtChargeTo.Enabled = True
            '.txtaddress.Enabled = True
            .txtrsno.Enabled = True
            '.txtpono.Enabled = True
            .cmbWsNo_PoNo.Enabled = True
            .cmbWsNo_PoNo.Items.Clear()
            '.cmbWsNo_PoNo.Items.Add("N/A")

            .txtconcession.Enabled = True
            .txtcheckedby.Enabled = True
            .txtreceivedby.Enabled = True

            '.dtpTimeFrom.Text = "12:00 AM"
            '.dtpTime_to.Text = "12:00 AM"

            FReceiving_Info.load_suppliers_list(.cmbSupplier)
            FReceiving_Info.show_cmbOperator(.cmbOperator)
            FPreviousStackCardFinal.load_set_type_of_charge("CASH", .cmbTypeofCharge)

            .Activate()
            .MdiParent = Me
            .Dock = DockStyle.Fill
            .Show()

            Dim a(10) As String

            Dim item_desc As String = FListOfItems.lvlWarehouseItem.SelectedItems(0).SubItems(1).Text & " - " & FListOfItems.lvlWarehouseItem.SelectedItems(0).SubItems(2).Text
            Dim wh_id As Integer = FListOfItems.lvlWarehouseItem.SelectedItems(0).Text

            Dim balance As Double = FormatNumber(FListOfItems.get_wh_item_balance2(wh_id) + FListOfItems.get_qty_from_dbPrevious_stock_card(wh_id), TriState.True) 'CDbl(FListOfItems.lvlWarehouseItem.SelectedItems(0).SubItems(4).Text)
            Dim qty_from_requestor As Double = FormatNumber(FListOfItems.get_total_qty_requested_and_not_withdrawn_yet(wh_id, 2),, TriState.True) 'CDbl(FListOfItems.lvlWarehouseItem.SelectedItems(0).SubItems(6).Text)

            Dim source As String = FListOfItems.lvlWarehouseItem.SelectedItems(0).SubItems(3).Text

            a(1) = "" : a(2) = "" : a(3) = "" : a(4) = balance - qty_from_requestor
            a(5) = item_desc : a(6) = rs_id : a(7) = 0 : a(8) = wh_id

            .dgv_dr_list.Rows.Clear()
            .dgv_dr_list.Rows.Add(a)

            .cmbOptions.Enabled = True
            .cmbOptions.Text = "IN"
            .cmbOptions.Enabled = False
            .dgv_dr_list.Rows(0).Cells("col_qty").Value = 0
            .dgv_dr_list.Rows(0).Cells("col_qty").ReadOnly = False
            .Show()

        End With

    End Sub

    Private Sub WithoutDRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WithoutDRToolStripMenuItem.Click

        FDeliveryReceipt.Activate()
        FDeliveryReceipt.MdiParent = Me
        FDeliveryReceipt.Dock = DockStyle.Fill

        FDeliveryReceipt.Show()
        FDeliveryReceipt.trigger("out without rs", "OUT")

        Exit Sub

        'DONT DELETE THIS CODE
        With FDeliveryReceipt
            with_dr_status = "out without rs"

            For Each ctr As Control In .Panel7.Controls
                ctr.Enabled = True
            Next

            .cmbOptions.Enabled = False
            .btnSave.Text = "Save"

            .txtrsno.Text = "N/A"
            '.dtpTimeFrom.Enabled = True
            '.dtpTime_to.Enabled = True
            .txtPlateNo.Enabled = True
            .cmbOperator.Enabled = True
            .cmbTypeofCharge.Enabled = True
            .cmbChargeTo.Enabled = True
            .txtChargeTo.Enabled = True
            '.txtaddress.Enabled = True
            .txtrsno.Enabled = True
            '.txtpono.Enabled = True
            .cmbWsNo_PoNo.Enabled = True
            .cmbWsNo_PoNo.Items.Clear()

            '.cmbWsNo_PoNo.Items.Add("N/A")
            .txtconcession.Enabled = True
            .txtcheckedby.Enabled = True
            .txtreceivedby.Enabled = True

            FReceiving_Info.load_suppliers_list(.cmbSupplier)
            FReceiving_Info.show_cmbOperator(.cmbOperator)
            FPreviousStackCardFinal.load_set_type_of_charge("CASH", .cmbTypeofCharge)

            .Activate()
            .MdiParent = Me
            .Dock = DockStyle.Fill
            .Show()


            Dim a(10) As String
            Dim item_desc As String = FListOfItems.lvlWarehouseItem.SelectedItems(0).SubItems(1).Text & " - " & FListOfItems.lvlWarehouseItem.SelectedItems(0).SubItems(2).Text
            Dim wh_id As Integer = FListOfItems.lvlWarehouseItem.SelectedItems(0).Text

            Dim balance As Double = FormatNumber(FListOfItems.get_wh_item_balance2(wh_id) + FListOfItems.get_qty_from_dbPrevious_stock_card(wh_id), TriState.True) 'CDbl(FListOfItems.lvlWarehouseItem.SelectedItems(0).SubItems(4).Text)
            Dim qty_from_requestor As Double = FormatNumber(FListOfItems.get_total_qty_requested_and_not_withdrawn_yet(wh_id, 2),, TriState.True) 'CDbl(FListOfItems.lvlWarehouseItem.SelectedItems(0).SubItems(6).Text)

            Dim source As String = FListOfItems.lvlWarehouseItem.SelectedItems(0).SubItems(3).Text


            a(1) = "" : a(2) = "" : a(3) = "" : a(4) = 0 : balances(11, wh_id) 'balance - qty_from_requestor
            a(5) = item_desc : a(6) = rs_id : a(7) = 0 : a(8) = wh_id

            .dgv_dr_list.Rows.Clear()
            .dgv_dr_list.Rows.Add(a)

            .cmbOptions.Enabled = True
            .cmbOptions.Text = "OUT"
            .cmbOptions.Enabled = False

            .dgv_dr_list.Rows(0).Cells("col_qty").ReadOnly = True
            .Show()
        End With


    End Sub


    Private Delegate Sub del_out_without_rs_update()

    Public Function get_prev_remaining_balance1(wh_id As Integer) As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim in_qty, out_qty As Double

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 6)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newCMD.Parameters.AddWithValue("@date_prevfrom", Date.Parse("1991-01-01"))
            newCMD.Parameters.AddWithValue("@date_prevto", Date.Parse("2014-01-01").AddDays(-1))

            newDR = newCMD.ExecuteReader

            While newDR.Read
                If newDR.Item("IN_OUT").ToString = "IN" Then
                    in_qty += newDR.Item("desired_qty").ToString

                ElseIf newDR.Item("IN_OUT").ToString = "OUT" Then
                    out_qty += newDR.Item("desired_qty").ToString

                End If
            End While
            newDR.Close()

            get_prev_remaining_balance1 = in_qty - out_qty

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Function

    Public Function balances(n As Integer, wh_id As Integer) As Double

        'ugma nani nko trabahoon...
        '==>
        Dim beginning_balance As Double = get_prev_remaining_balance1(wh_id) + FStockCard.get_prev_item_balance(wh_id)
        'lblBalance.Text = beginning_balance
        'ehehehehehe


        If wh_id = 0 Then
            Exit Function
        End If

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.CommandTimeout = 0

            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newCMD.Parameters.AddWithValue("@date_from", Date.Parse("2014-01-01"))
            newCMD.Parameters.AddWithValue("@date_to", Date.Parse(Now))


            newDR = newCMD.ExecuteReader

            Dim a(20) As String
            Dim rowcount As Integer = 0
            While newDR.Read
                Dim ws_no As String = newDR.Item("WS_NO").ToString
                Dim rs_no As String = newDR.Item("rs_no").ToString

                'lblReOrderPoint.Text = newDR.Item("REORDER_POINT").ToString
                Select Case n
                    Case 5
                        If newDR.Item("dr_option").ToString = "WITH DR" And newDR.Item("DR").ToString = "PARENT DR" Then
                            GoTo proceedhere1
                        End If

                        If newDR.Item("IN_OUT").ToString = "OUT" Then

                            a(9) = newDR.Item("desired_qty").ToString
                            beginning_balance = beginning_balance - CDbl(a(9))

                        ElseIf newDR.Item("IN_OUT").ToString = "IN" Then

                            a(8) = newDR.Item("desired_qty").ToString
                            beginning_balance = beginning_balance + CDbl(a(8))

                        End If

                        a(10) = FormatNumber(beginning_balance, 2,,, TriState.True)
                        balances = a(10)
proceedhere1:

                    Case 11
                        If newDR.Item("WITHDRAWN").ToString = "NO" Then
                            GoTo proceedhere
                        End If

                        If newDR.Item("stat").ToString = "" And newDR.Item("dr_no").ToString = "" Then
                            GoTo proceedhere
                        End If

                        If newDR.Item("IN_OUT").ToString = "OUT" Then

                            If newDR.Item("SORTING").ToString = "A" Then

                                a(9) = CDbl(newDR.Item("qty_OUT").ToString) - FStockCard.count_qty_dr_using_ws_no(ws_no, rs_no, 12)

                                'example 12/8 so, 8-12 = -4 therefore,  dili pde mag negative
                                If a(9) < 0 Then
                                    beginning_balance = beginning_balance - 0
                                Else
                                    beginning_balance = beginning_balance - CDbl(a(9))
                                End If

                                If FStockCard.count_qty_dr_using_ws_no(ws_no, rs_no, 12) = 0 Then
                                    a(9) = CDbl(newDR.Item("qty_OUT").ToString)
                                Else
                                    a(9) = FStockCard.count_qty_dr_using_ws_no(ws_no, rs_no, 12) & "/" & CDbl(newDR.Item("qty_OUT").ToString)
                                End If

                                a(10) = FormatNumber(beginning_balance,,, TriState.True)

                            Else

                                a(9) = newDR.Item("qty_OUT").ToString
                                beginning_balance = beginning_balance - CDbl(newDR.Item("qty_OUT").ToString)
                                a(10) = FormatNumber(beginning_balance,,, TriState.True)

                            End If

                        ElseIf newDR.Item("IN_OUT").ToString = "IN" Then

                            a(8) = newDR.Item("qty_IN").ToString
                            beginning_balance = beginning_balance + CDbl(a(8))
                            a(10) = FormatNumber(beginning_balance,,, TriState.True)

                        End If

                        balances = a(10)

                        rowcount += 1

proceedhere:

                End Select


            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Private Sub FWorWODRvb_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FWorWODRvb_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        For Each frm As Form In Me.MdiChildren
            frm.Close()
        Next
    End Sub
End Class