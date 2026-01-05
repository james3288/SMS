Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FSupplyTransaction
    Private customMsg As New customMessageBox

    Private Sub FRequisition_Slip_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Label12.BringToFront()
        Label12.Parent = pbox_materialTools
        Label12.Location = New Point(30, 115)
        Label12.ForeColor = Color.White
        Label20.BringToFront()
        Label20.Parent = pbox_materialTools
        Label20.Location = New Point(22, 130)
        Label20.ForeColor = Color.YellowGreen

        Label1.BringToFront()
        Label1.Parent = pboxReqSlip
        Label1.Location = New Point(27, 115)
        Label1.ForeColor = Color.White
        Label2.BringToFront()
        Label2.Parent = pboxReqSlip
        Label2.Location = New Point(34, 130)
        Label2.ForeColor = Color.YellowGreen

        Label3.BringToFront()
        Label3.Parent = pboxWithSlip
        Label3.Location = New Point(27, 115)
        Label3.ForeColor = Color.White
        Label4.BringToFront()
        Label4.Parent = pboxWithSlip
        Label4.Location = New Point(34, 130)
        Label4.ForeColor = Color.YellowGreen

        Label5.BringToFront()
        Label5.Parent = pboxSummarySupply
        Label5.Location = New Point(24, 115)
        Label5.ForeColor = Color.White
        Label6.BringToFront()
        Label6.Parent = pboxSummarySupply
        Label6.Location = New Point(29, 130)
        Label6.ForeColor = Color.YellowGreen

        Label8.BringToFront()
        Label8.Parent = pboxPurchaseOrder
        Label8.Location = New Point(27, 115)
        Label8.ForeColor = Color.White
        Label7.BringToFront()
        Label7.Parent = pboxPurchaseOrder
        Label7.Location = New Point(30, 130)
        Label7.ForeColor = Color.YellowGreen

        Label10.BringToFront()
        Label10.Parent = pboxStockCard
        Label10.Location = New Point(42, 115)
        Label10.ForeColor = Color.White
        Label9.BringToFront()
        Label9.Parent = pboxStockCard
        Label9.Location = New Point(11, 130)
        Label9.ForeColor = Color.YellowGreen

        Label11.BringToFront()
        Label11.Parent = pboxReceivingReport
        Label11.Location = New Point(25, 115)
        Label11.ForeColor = Color.White
        Label13.BringToFront()
        Label13.Parent = pboxReceivingReport
        Label13.Location = New Point(30, 130)
        Label13.ForeColor = Color.YellowGreen

        Label14.BringToFront()
        Label14.Parent = pboxVoucher
        Label14.Location = New Point(21, 115)
        Label14.ForeColor = Color.White
        Label16.BringToFront()
        Label16.Parent = pboxVoucher
        Label16.Location = New Point(32, 130)
        Label16.ForeColor = Color.YellowGreen

        Label17.BringToFront()
        Label17.Parent = pboxpurchasedItems
        Label17.Location = New Point(23, 115)
        Label17.ForeColor = Color.White
        Label18.BringToFront()
        Label18.Parent = pboxpurchasedItems
        Label18.Location = New Point(23, 130)
        Label18.ForeColor = Color.YellowGreen

        Label23.BringToFront()
        Label23.Parent = pboxEquipment_History
        Label23.Location = New Point(18, 115)
        Label23.ForeColor = Color.White
        Label22.BringToFront()
        Label22.Parent = pboxEquipment_History
        Label22.Location = New Point(20, 130)
        Label22.ForeColor = Color.YellowGreen


        Label25.BringToFront()
        Label25.Parent = pboxLiquidation
        Label25.Location = New Point(40, 115)
        Label25.ForeColor = Color.White
        Label24.BringToFront()
        Label24.Parent = pboxLiquidation
        Label24.Location = New Point(20, 130)
        Label24.ForeColor = Color.YellowGreen

        Label26.BringToFront()
        Label26.Parent = pboxEquipmentCost
        Label26.Location = New Point(25, 115)
        Label26.ForeColor = Color.White
        Label27.BringToFront()
        Label27.Parent = pboxEquipmentCost
        Label27.Location = New Point(20, 130)
        Label27.ForeColor = Color.YellowGreen

        Label29.BringToFront()
        Label29.Parent = pboxLaborCost
        Label29.Location = New Point(41, 115)
        Label29.ForeColor = Color.White
        Label28.BringToFront()
        Label28.Parent = pboxLaborCost
        Label28.Location = New Point(22, 130)
        Label28.ForeColor = Color.YellowGreen

        Label21.BringToFront()
        Label21.Parent = pboxAllowances
        Label21.Location = New Point(35, 115)
        Label21.ForeColor = Color.White
        Label19.BringToFront()
        Label19.Parent = pboxAllowances
        Label19.Location = New Point(20, 130)
        Label19.ForeColor = Color.YellowGreen

        Label31.BringToFront()
        Label31.Parent = pbox_projectcost
        Label31.Location = New Point(38, 115)
        Label31.ForeColor = Color.White
        Label30.BringToFront()
        Label30.Parent = pbox_projectcost
        Label30.Location = New Point(22, 130)
        Label30.ForeColor = Color.YellowGreen

        Label32.BringToFront()
        Label32.Parent = pbox_equipment_monitoring
        Label32.Location = New Point(7, 115)
        Label32.ForeColor = Color.White
        Label33.BringToFront()
        Label33.Parent = pbox_equipment_monitoring
        Label33.Location = New Point(22, 130)
        Label33.ForeColor = Color.YellowGreen

        Label35.BringToFront()
        Label35.Parent = pboxAccounting
        Label35.Location = New Point(30, 115)
        Label35.ForeColor = Color.White
        Label34.BringToFront()
        Label34.Parent = pboxAccounting
        Label34.Location = New Point(22, 130)
        Label34.ForeColor = Color.YellowGreen

        Label44.BringToFront()
        Label44.Parent = pBoxWithdrawalReport
        Label44.Location = New Point(15, 115)
        Label44.ForeColor = Color.White

        Label45.BringToFront()
        Label45.Parent = pBoxWithdrawalReport
        Label45.Location = New Point(15, 150)
        Label45.ForeColor = Color.YellowGreen


        Label47.BringToFront()
        Label47.Parent = pBoxSummaryOfHauledAggregates
        Label47.Location = New Point(15, 115)
        Label47.ForeColor = Color.White

        Label46.BringToFront()
        Label46.Parent = pBoxSummaryOfHauledAggregates
        Label46.Location = New Point(15, 140)
        Label46.ForeColor = Color.YellowGreen

        Label39.BringToFront()
        Label39.Parent = pBoxAllowanceSummary
        Label39.Location = New Point(15, 115)
        Label39.ForeColor = Color.White

        Label38.BringToFront()
        Label38.Parent = pBoxAllowanceSummary
        Label38.Location = New Point(15, 140)
        Label38.ForeColor = Color.YellowGreen

        Label40.BringToFront()
        Label40.Parent = pBoxGeneralExport
        Label40.Location = New Point(30, 115)
        Label40.ForeColor = Color.White

        Label41.BringToFront()
        Label41.Parent = pBoxGeneralExport
        Label41.Location = New Point(20, 140)
        Label41.ForeColor = Color.YellowGreen

        Label42.BringToFront()
        Label42.Parent = pBoxSupplierEvaluation
        Label42.Location = New Point(30, 115)
        Label42.ForeColor = Color.White

        Label43.BringToFront()
        Label43.Parent = pBoxSupplierEvaluation
        Label43.Location = New Point(20, 140)
        Label43.ForeColor = Color.YellowGreen

        Label15.Parent = pboxHeader
        pboxHeader.Width = FMain.Width - FMain.ToolStrip1.Width
        btnExit.Parent = pboxHeader
        btnExit.Location = New Point(pboxHeader.Width - 50, 10)


    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub pboxReqSlip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pboxReqSlip.Click, Label1.Click, Label2.Click
        'For Each ctr As Control In FRequistionForm.Controls
        '    ctr.Enabled = False
        'Next

        'form_active("FRequistionForm")
        form_active(NameOf(FRequesitionFormForDR))


        'FRequestField.ShowDialog()



        wh_item_destination = 1
    End Sub

    Private Sub pboxWithSlip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pboxWithSlip.Click
        form_active("FWithdrawalList")
        FWithdrawalList.Show()
    End Sub

    Private Sub pboxPurchaseOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pboxPurchaseOrder.Click
        form_active("FPurchasedOrderList")
        FPurchasedOrderList.Show()
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click, Label6.Click
        form_active("FSummarySupplyTransaction")
        FSummarySupplyTransaction.Show()
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click, Label13.Click
        form_active("FReceivingReportList")
        FReceivingReportList.Show()
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        form_active("FWithdrawalList")
        FWithdrawalList.Show()
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        form_active("FWithdrawalList")
        FWithdrawalList.Show()
    End Sub



#Region "Hover"
    Private Sub pboxSummarySupply_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pboxSummarySupply.MouseDown
        pboxSummarySupply.BackgroundImage = My.Resources.box_bg_down
    End Sub

    Private Sub pboxSummarySupply_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pboxSummarySupply.MouseEnter
        pboxSummarySupply.BackgroundImage = My.Resources.box_bg_down
    End Sub

    Private Sub pboxSummarySupply_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pboxSummarySupply.MouseLeave
        pboxSummarySupply.BackgroundImage = My.Resources.box_bg_1
    End Sub

    Private Sub pboxWithSlip_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pboxWithSlip.MouseDown
        pboxWithSlip.BackgroundImage = My.Resources.box_bg_down
    End Sub

    Private Sub pboxWithSlip_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pboxWithSlip.MouseEnter
        pboxWithSlip.BackgroundImage = My.Resources.box_bg_down
    End Sub

    Private Sub pboxWithSlip_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pboxWithSlip.MouseLeave
        pboxWithSlip.BackgroundImage = My.Resources.box_bg_1
    End Sub

    Private Sub pboxReqSlip_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pboxReqSlip.MouseDown
        pboxReqSlip.BackgroundImage = My.Resources.box_bg_down
    End Sub

    Private Sub pboxReqSlip_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pboxReqSlip.MouseEnter
        pboxReqSlip.BackgroundImage = My.Resources.box_bg_down
    End Sub

    Private Sub pboxReqSlip_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pboxReqSlip.MouseLeave
        pboxReqSlip.BackgroundImage = My.Resources.box_bg_1
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

    Private Sub pboxStockCard_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pboxStockCard.MouseDown
        pboxStockCard.BackgroundImage = My.Resources.box_bg_down
    End Sub

    Private Sub pboxStockCard_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pboxStockCard.MouseEnter
        pboxStockCard.BackgroundImage = My.Resources.box_bg_down
    End Sub

    Private Sub pboxStockCard_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pboxStockCard.MouseLeave
        pboxStockCard.BackgroundImage = My.Resources.box_bg_1
    End Sub

    Private Sub pboxPurchaseOrder_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pboxPurchaseOrder.MouseDown, Label7.MouseDown, Label8.MouseDown
        pboxPurchaseOrder.BackgroundImage = My.Resources.box_bg_down
    End Sub

    Private Sub pboxPurchaseOrder_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pboxPurchaseOrder.MouseEnter, Label7.MouseEnter, Label8.MouseEnter
        pboxPurchaseOrder.BackgroundImage = My.Resources.box_bg_down
    End Sub

    Private Sub pboxPurchaseOrder_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pboxPurchaseOrder.MouseLeave, Label7.MouseLeave, Label8.MouseLeave
        pboxPurchaseOrder.BackgroundImage = My.Resources.box_bg_1
    End Sub

    Private Sub pbox_purchasedItems_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pboxpurchasedItems.MouseDown, Label17.MouseDown, Label18.MouseDown
        pboxpurchasedItems.BackgroundImage = My.Resources.box_bg_down
    End Sub

    Private Sub pbox_purchasedItems_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pboxpurchasedItems.MouseEnter, Label17.MouseEnter, Label18.MouseEnter
        pboxpurchasedItems.BackgroundImage = My.Resources.box_bg_down
    End Sub

    Private Sub pbox_purchasedItems_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pboxpurchasedItems.MouseLeave, Label17.MouseLeave, Label18.MouseLeave
        pboxpurchasedItems.BackgroundImage = My.Resources.box_bg_1
    End Sub

    Private Sub pboxReceivingReport_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pboxReceivingReport.MouseDown, Label11.MouseDown, Label13.MouseDown
        pboxReceivingReport.BackgroundImage = My.Resources.box_bg_down
    End Sub

    Private Sub pboxReceivingReport_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pboxReceivingReport.MouseEnter, Label11.MouseEnter, Label13.MouseEnter
        pboxReceivingReport.BackgroundImage = My.Resources.box_bg_down
    End Sub

    Private Sub pboxReceivingReport_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pboxReceivingReport.MouseLeave, Label11.MouseLeave, Label13.MouseLeave
        pboxReceivingReport.BackgroundImage = My.Resources.box_bg_1
    End Sub

    Private Sub pboxVoucher_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pboxVoucher.MouseDown, Label14.MouseDown, Label16.MouseDown
        pboxVoucher.BackgroundImage = My.Resources.box_bg_down
    End Sub

    Private Sub pboxVoucher_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pboxVoucher.MouseEnter, Label14.MouseEnter, Label16.MouseEnter
        pboxVoucher.BackgroundImage = My.Resources.box_bg_down
    End Sub

    Private Sub pboxVoucher_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pboxVoucher.MouseLeave, Label14.MouseLeave, Label16.MouseLeave
        pboxVoucher.BackgroundImage = My.Resources.box_bg_1
    End Sub

    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbox_materialTools.MouseDown
        pbox_materialTools.BackgroundImage = My.Resources.box_bg_down
    End Sub

    Private Sub PictureBox1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbox_materialTools.MouseEnter
        pbox_materialTools.BackgroundImage = My.Resources.box_bg_down
    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbox_materialTools.MouseLeave
        pbox_materialTools.BackgroundImage = My.Resources.box_bg_1
    End Sub

    Private Sub pboxEquipment_History_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pboxEquipment_History.MouseDown, Label22.MouseDown, Label23.MouseDown
        pboxEquipment_History.BackgroundImage = My.Resources.box_bg_down
    End Sub

    Private Sub pboxEquipment_History_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pboxEquipment_History.MouseEnter, Label22.MouseEnter, Label23.MouseEnter
        pboxEquipment_History.BackgroundImage = My.Resources.box_bg_down
    End Sub

    Private Sub pboxEquipment_History_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pboxEquipment_History.MouseLeave, Label22.MouseLeave, Label23.MouseLeave
        pboxEquipment_History.BackgroundImage = My.Resources.box_bg_1
    End Sub

    Private Sub pboxEquipmentCost_MouseDown(sender As Object, e As MouseEventArgs) Handles pboxEquipmentCost.MouseDown, Label26.MouseDown, Label27.MouseDown
        pboxEquipmentCost.BackgroundImage = My.Resources.box_bg_down
    End Sub

    Private Sub pboxEquipmentCost_MouseEnter(sender As Object, e As EventArgs) Handles pboxEquipmentCost.MouseEnter, Label26.MouseEnter, Label27.MouseEnter
        pboxEquipmentCost.BackgroundImage = My.Resources.box_bg_down
    End Sub

    Private Sub pboxEquipmentCost_MouseLeave(sender As Object, e As EventArgs) Handles pboxEquipmentCost.MouseLeave, Label26.MouseLeave, Label27.MouseLeave
        pboxEquipmentCost.BackgroundImage = My.Resources.box_bg_1
    End Sub

    Sub pboxAllowances_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pboxAllowances.MouseDown, Label21.MouseDown, Label19.MouseDown
        pboxAllowances.BackgroundImage = My.Resources.box_bg_down
    End Sub

    Private Sub pboxAllowances_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pboxAllowances.MouseEnter, Label21.MouseEnter, Label19.MouseEnter
        pboxAllowances.BackgroundImage = My.Resources.box_bg_down
    End Sub

    Private Sub pboxAllowances_History_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pboxAllowances.MouseLeave, Label21.MouseLeave, Label19.MouseLeave
        pboxAllowances.BackgroundImage = My.Resources.box_bg_1
    End Sub

    Private Sub pboxLaborCost_MouseDown(sender As Object, e As MouseEventArgs) Handles pboxLaborCost.MouseDown, Label29.MouseDown, Label28.MouseDown
        pboxLaborCost.BackgroundImage = My.Resources.box_bg_down
    End Sub

    Private Sub pboxLaborCost_MouseEnter(sender As Object, e As EventArgs) Handles pboxLaborCost.MouseEnter, Label29.MouseEnter, Label28.MouseEnter
        pboxLaborCost.BackgroundImage = My.Resources.box_bg_down
    End Sub

    Private Sub pboxLaborCost_MouseLeave(sender As Object, e As EventArgs) Handles pboxLaborCost.MouseLeave, Label29.MouseLeave, Label28.MouseLeave
        pboxLaborCost.BackgroundImage = My.Resources.box_bg_1
    End Sub
    Private Sub pbox_projectcost_MouseDown(sender As Object, e As MouseEventArgs) Handles pbox_projectcost.MouseDown, Label31.MouseDown, Label30.MouseDown
        pbox_projectcost.BackgroundImage = My.Resources.box_bg_down
    End Sub
    Private Sub pbox_projectcost_MouseEnter(sender As Object, e As EventArgs) Handles pbox_projectcost.MouseEnter, Label31.MouseEnter, Label30.MouseEnter
        pbox_projectcost.BackgroundImage = My.Resources.box_bg_down
    End Sub
    Private Sub pbox_projectcost_MouseLeave(sender As Object, e As EventArgs) Handles pbox_projectcost.MouseLeave, Label31.MouseLeave, Label30.MouseLeave
        pbox_projectcost.BackgroundImage = My.Resources.box_bg_1
    End Sub
    Private Sub pbox_equipment_monitoring_MouseDown(sender As Object, e As MouseEventArgs) Handles pbox_equipment_monitoring.MouseDown, Label32.MouseDown, Label33.MouseDown
        pbox_equipment_monitoring.BackgroundImage = My.Resources.box_bg_down
    End Sub
    Private Sub pbox_equipment_monitoring_MouseEnter(sender As Object, e As EventArgs) Handles pbox_equipment_monitoring.MouseEnter, Label32.MouseEnter, Label33.MouseEnter
        pbox_equipment_monitoring.BackgroundImage = My.Resources.box_bg_down
    End Sub
    Private Sub pbox_equipment_monitoring_MouseLeave(sender As Object, e As EventArgs) Handles pbox_equipment_monitoring.MouseLeave, Label32.MouseLeave, Label33.MouseLeave
        pbox_equipment_monitoring.BackgroundImage = My.Resources.box_bg_1
    End Sub
    Private Sub pboxLiquidation_MouseDown(sender As Object, e As MouseEventArgs) Handles pboxLiquidation.MouseDown, Label25.MouseDown, Label24.MouseDown
        pboxLiquidation.BackgroundImage = My.Resources.box_bg_down
    End Sub
    Private Sub pboxLiquidation_MouseEnter(sender As Object, e As EventArgs) Handles pboxLiquidation.MouseEnter, Label25.MouseEnter, Label24.MouseEnter
        pboxLiquidation.BackgroundImage = My.Resources.box_bg_down
    End Sub
    Private Sub pboxLiquidation_MouseLeave(sender As Object, e As EventArgs) Handles pboxLiquidation.MouseLeave, Label25.MouseLeave, Label24.MouseLeave
        pboxLiquidation.BackgroundImage = My.Resources.box_bg_1
    End Sub
    Private Sub pBoxAllowanceSummary_MouseDown(sender As Object, e As MouseEventArgs) Handles pBoxAllowanceSummary.MouseDown, Label39.MouseDown, Label38.MouseDown
        pBoxAllowanceSummary.BackgroundImage = My.Resources.box_bg_down
    End Sub
    Private Sub pBoxAllowanceSummary_MouseEnter(sender As Object, e As EventArgs) Handles pBoxAllowanceSummary.MouseEnter, Label39.MouseEnter, Label38.MouseEnter
        pBoxAllowanceSummary.BackgroundImage = My.Resources.box_bg_down
    End Sub
    Private Sub pBoxAllowanceSummary_MouseLeave(sender As Object, e As EventArgs) Handles pBoxAllowanceSummary.MouseLeave, Label39.MouseLeave, Label38.MouseLeave
        pBoxGeneralExport.BackgroundImage = My.Resources.box_bg_1
    End Sub

    Private Sub pBoxGeneralExport_MouseDown(sender As Object, e As MouseEventArgs) Handles pBoxGeneralExport.MouseDown, Label40.MouseDown, Label41.MouseDown
        pBoxGeneralExport.BackgroundImage = My.Resources.box_bg_down
    End Sub
    Private Sub pBoxGeneralExport_MouseEnter(sender As Object, e As EventArgs) Handles pBoxGeneralExport.MouseEnter, Label40.MouseEnter, Label41.MouseEnter
        pBoxGeneralExport.BackgroundImage = My.Resources.box_bg_down
    End Sub
    Private Sub pBoxGeneralExport_MouseLeave(sender As Object, e As EventArgs) Handles pBoxGeneralExport.MouseLeave, Label40.MouseLeave, Label41.MouseLeave
        pBoxGeneralExport.BackgroundImage = My.Resources.box_bg_1
    End Sub

    Private Sub pBoxSupplierEvaluation_MouseDown(sender As Object, e As MouseEventArgs) Handles pBoxSupplierEvaluation.MouseDown, Label40.MouseDown, Label41.MouseDown
        pBoxSupplierEvaluation.BackgroundImage = My.Resources.box_bg_down
    End Sub
    Private Sub pBoxSupplierEvaluation_MouseEnter(sender As Object, e As EventArgs) Handles pBoxSupplierEvaluation.MouseEnter, Label42.MouseEnter, Label43.MouseEnter
        pBoxSupplierEvaluation.BackgroundImage = My.Resources.box_bg_down
    End Sub
    Private Sub pBoxSupplierEvaluation_MouseLeave(sender As Object, e As EventArgs) Handles pBoxSupplierEvaluation.MouseLeave, Label42.MouseLeave, Label43.MouseLeave
        pBoxSupplierEvaluation.BackgroundImage = My.Resources.box_bg_1
    End Sub

#Region "WITHDRAWAL REPORT MENU BUTTON"
    Private Sub pBoxWithrawalReport_MouseDown(sender As Object, e As MouseEventArgs) Handles pBoxWithdrawalReport.MouseDown, Label44.MouseDown, Label45.MouseDown
        pBoxWithdrawalReport.BackgroundImage = My.Resources.box_bg_down
    End Sub
    Private Sub pBoxWithrawalReport_MouseEnter(sender As Object, e As EventArgs) Handles pBoxWithdrawalReport.MouseEnter, Label44.MouseEnter, Label45.MouseEnter
        pBoxWithdrawalReport.BackgroundImage = My.Resources.box_bg_down
    End Sub
    Private Sub pBoxWithrawalReport_MouseLeave(sender As Object, e As EventArgs) Handles pBoxWithdrawalReport.MouseLeave, Label44.MouseLeave, Label45.MouseLeave
        pBoxWithdrawalReport.BackgroundImage = My.Resources.box_bg_1
    End Sub
#End Region

#Region "SUMMARY OF HAULED AGGREGATES MENU BUTTON"
    Private Sub pBoxHauledAggregates_MouseDown(sender As Object, e As MouseEventArgs) Handles pBoxSummaryOfHauledAggregates.MouseDown, Label47.MouseDown, Label46.MouseDown
        pBoxSummaryOfHauledAggregates.BackgroundImage = My.Resources.box_bg_down
    End Sub
    Private Sub pBoxHauledAggregates_MouseEnter(sender As Object, e As EventArgs) Handles pBoxSummaryOfHauledAggregates.MouseEnter, Label47.MouseEnter, Label46.MouseEnter
        pBoxSummaryOfHauledAggregates.BackgroundImage = My.Resources.box_bg_down
    End Sub
    Private Sub pBoxHauledAggregates_MouseLeave(sender As Object, e As EventArgs) Handles pBoxSummaryOfHauledAggregates.MouseLeave, Label47.MouseLeave, Label46.MouseLeave
        pBoxSummaryOfHauledAggregates.BackgroundImage = My.Resources.box_bg_1
    End Sub
#End Region

#End Region
    Private Sub pboxStockCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pboxStockCard.Click, Label9.Click, Label10.Click
        'form_active("FStockCard")
        If MessageBox.Show("Click Yes if WAREHOUSING DEPARTMENT and click No if CRUSHING AND HAULING DEPARTMENT", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            'FStockCard.lbl_status.Text = "SUPPLY DEPT."
            form_active("StockCard1")
            StockCard1.Show()
            Exit Sub
        Else
            FStockCard.lbl_status.Text = "CRUSHING AND HAULING DEPT."
        End If

        form_active("FStockCard")
        FStockCard.Show()
    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        form_active("FPurchasedOrderList")
        FPurchasedOrderList.Show()
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        form_active("FPurchasedOrderList")
        FPurchasedOrderList.Show()
    End Sub

    Private Sub pbox_materialTools_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbox_materialTools.Click, Label20.Click, Label12.Click
        MessageBox.Show("Sorry, this form is under maintenance.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Exit Sub

        form_active("FMaterials_ToolsTurnOverReport")
        FMaterials_ToolsTurnOverReport.Show()
    End Sub

    Private Sub pboxSummarySupply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pboxSummarySupply.Click
        form_active("FSummarySupplyTransaction")
        FSummarySupplyTransaction.Show()
    End Sub

    Private Sub pboxVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pboxVoucher.Click

        Utilities.UnderMaintenance()
        Exit Sub

        form_active("FCashVoucherList")
        FCashVoucherList.Show()
    End Sub

    Private Sub pboxReceivingReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pboxReceivingReport.Click
        'form_active("FReceivingReportList")
        'FReceivingReportList.Show()
        form_active(FReceivingReportListNew.Name)
        FReceivingReportListNew.Show()

    End Sub

    Private Sub pbox_purchasedItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pboxpurchasedItems.Click, Label17.Click, Label18.Click
        FSummaryofPurchasedItems.Show()
    End Sub

    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label14.Click, Label16.Click
        form_active("FCashVoucherList")
        FCashVoucherList.Show()
    End Sub

    Private Sub pbox_EquipmentHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pboxEquipment_History.Click, Label23.Click, Label22.Click
        form_active("FEquipment_history")
        FEquipment_history.Show()
    End Sub
    Private Sub pboxAllowances_Click(ByVal sender As Object, e As EventArgs) Handles pboxAllowances.Click, Label19.Click, Label21.Click
        Utilities.UnderMaintenance()
        Exit Sub

        form_active("FAllowance")
        FAllowance.Show()
    End Sub

    Private Sub pboxLiquidation_Click(ByVal sender As Object, e As EventArgs) Handles pboxLiquidation.Click, Label24.Click, Label25.Click
        FLiquidationReport.ShowDialog()
    End Sub

    Private Sub pboxEquipmentCost_Click(ByVal sender As Object, e As EventArgs) Handles pboxEquipmentCost.Click, Label26.Click, Label27.Click
        form_active("FEquipment_cost_report")
        FEquipment_cost_report.Show()
    End Sub

    Private Sub pboxLaborCost_Click(sender As Object, e As EventArgs) Handles pboxLaborCost.Click, Label29.Click, Label28.Click

        Utilities.UnderMaintenance()
        Exit Sub

        form_active("FLaborCost")
        FLaborCost.Show()
    End Sub
    Private Sub pbox_projectcost_Click(sender As Object, e As EventArgs) Handles pbox_projectcost.Click, Label31.Click, Label30.Click

        Utilities.UnderMaintenance()
        Exit Sub

        'form_active("FProjectCost")
        form_active("FProjectCost")
        FProjectCost.Show()
    End Sub
    Private Sub pbox_equipment_monitoring_Click(sender As Object, e As EventArgs) Handles pbox_equipment_monitoring.Click, Label32.Click, Label33.Click
        form_active("FEquipment_monitoring")
        FEquipment_monitoring.Show()
    End Sub

    Private Sub pboxAccounting_Click(sender As Object, e As EventArgs) Handles pboxAccounting.Click, Label35.Click, Label34.Click
        form_active("Summary_Purchased_Item")
        Summary_Purchased_Item.Show()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        Utilities.UnderMaintenance()
        Exit Sub

        form_active("FAccidentReportField")
        FAccidentReportField.Show()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles pBoxAllowanceSummary.Click
        form_active("Allowance_sum")
        Dim result As DialogResult = MessageBox.Show("Include Retired Employee?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Allowance_sum.save_name_list(6)
        Else
            Allowance_sum.save_name_list(1)
        End If
        Allowance_sum.Show()
    End Sub

    Private Sub pboxHeader_Click(sender As Object, e As EventArgs) Handles pboxHeader.Click

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles pBoxGeneralExport.Click
        form_active("ExportingRecordForm")
        ExportingRecordForm.Show()

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles pBoxSupplierEvaluation.Click
        form_active("SupplierEvaluationForm")
        ListofEvaluatedSupplierForm.Show()
    End Sub

    Private Sub FSupplyTransaction_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = "e"c OrElse e.KeyChar = "E"c Then
            ' Call the PictureBox click logic manually
            pbox_equipment_monitoring_Click(pbox_equipment_monitoring, EventArgs.Empty)
        End If
    End Sub

    Private Sub pBoxWithdrawalReport_Click(sender As Object, e As EventArgs) Handles pBoxWithdrawalReport.Click, Label44.Click, Label45.Click
        Fwithdrawal_kpi_report.ShowDialog()
    End Sub

    Private Sub pBoxSummaryOfHauledAggregates_Click(sender As Object, e As EventArgs) Handles pBoxSummaryOfHauledAggregates.Click, Label47.Click, Label46.Click
        form_active("FDRLIST2")
    End Sub
End Class