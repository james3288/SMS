Module ModSupplyTransaction

    Dim no_of_button As Integer = 40

    Public Sub enable_disable_buttons_in_supptrans(ByVal n As String)
        Dim split() As String

        split = n.Split("-")

        For i = 1 To no_of_button
            For ii = 0 To split.Length - 1
                If split(ii) = i Then
                    supp_trans_buttons(True, i)
                End If
            Next
        Next

    End Sub

    Public Sub supp_trans_buttons(ByVal on_off As Boolean, ByVal n As Integer)


        '********* SUPPLY TRANSACTION ***************
        If n = 1 Then
            With FSupplyTransaction
                If on_off = True Then
                    .pboxReqSlip.Enabled = True
                    .Label1.Enabled = True
                    .Label2.Enabled = True
                Else
                    .pboxReqSlip.Enabled = False
                    .Label1.Enabled = False
                    .Label2.Enabled = False
                End If
            End With
        ElseIf n = 2 Then
            With FSupplyTransaction
                If on_off = True Then
                    .pboxPurchaseOrder.Enabled = True
                    .Label8.Enabled = True
                    .Label7.Enabled = True
                Else
                    .pboxPurchaseOrder.Enabled = False
                    .Label8.Enabled = True
                    .Label7.Enabled = False
                End If
            End With
        ElseIf n = 3 Then
            With FSupplyTransaction
                If on_off = True Then
                    .pboxWithSlip.Enabled = True
                    .Label4.Enabled = True
                    .Label3.Enabled = True
                Else
                    .pboxWithSlip.Enabled = False
                    .Label4.Enabled = False
                    .Label3.Enabled = True
                End If
            End With
        ElseIf n = 4 Then
            With FSupplyTransaction
                If on_off = True Then
                    .pboxReceivingReport.Enabled = True
                    .Label13.Enabled = True
                    .Label11.Enabled = True
                Else
                    .pboxReceivingReport.Enabled = False
                    .Label3.Enabled = False
                    .Label11.Enabled = True
                End If
            End With
        ElseIf n = 5 Then
            With FSupplyTransaction
                If on_off = True Then
                    .pboxSummarySupply.Enabled = True
                    .Label6.Enabled = True
                    .Label5.Enabled = True

                Else
                    .pboxSummarySupply.Enabled = False
                    .Label6.Enabled = False
                    .Label5.Enabled = True

                End If
            End With
        ElseIf n = 6 Then
            With FSupplyTransaction
                If on_off = True Then
                    .pboxVoucher.Enabled = True
                    .Label14.Enabled = True
                    .Label16.Enabled = True
                Else
                    .pboxVoucher.Enabled = False
                    .Label14.Enabled = False
                    .Label16.Enabled = False
                End If
            End With
        ElseIf n = 7 Then
            With FSupplyTransaction
                If on_off = True Then
                    .pboxStockCard.Enabled = True
                    .Label10.Enabled = True
                    .Label9.Enabled = True
                Else
                    .pboxStockCard.Enabled = False
                    .Label10.Enabled = False
                    .Label9.Enabled = False
                End If
            End With
        ElseIf n = 8 Then
            With FSupplyTransaction
                If on_off = True Then
                    .pbox_materialTools.Enabled = True
                    .Label12.Enabled = True
                    .Label20.Enabled = True
                Else
                    .pbox_materialTools.Enabled = False
                    .Label12.Enabled = False
                    .Label20.Enabled = False
                End If
            End With
        ElseIf n = 9 Then
            With FSupplyTransaction
                If on_off = True Then
                    .pboxpurchasedItems.Enabled = True
                    .Label17.Enabled = True
                    .Label18.Enabled = True
                Else
                    .pboxpurchasedItems.Enabled = False
                    .Label17.Enabled = False
                    .Label18.Enabled = False
                End If
            End With
        ElseIf n = 20 Then
            With FSupplyTransaction
                If on_off = True Then
                    .pboxEquipment_History.Enabled = True
                    .Label23.Enabled = True
                    .Label22.Enabled = True
                Else
                    .pboxEquipment_History.Enabled = False
                    .Label23.Enabled = False
                    .Label22.Enabled = False
                End If
            End With
        ElseIf n = 21 Then
            With FSupplyTransaction
                If on_off = True Then
                    .pboxAllowances.Enabled = True
                    .Label21.Enabled = True
                    .Label19.Enabled = True
                Else
                    .pboxAllowances.Enabled = False
                    .Label21.Enabled = True
                    .Label19.Enabled = True
                End If
            End With
        ElseIf n = 22 Then
            With FSupplyTransaction
                If on_off = True Then
                    .pboxLiquidation.Enabled = True
                    .Label25.Enabled = True
                    .Label24.Enabled = True
                Else
                    .pboxLiquidation.Enabled = False
                    .Label25.Enabled = False
                    .Label24.Enabled = False
                End If
            End With
            '***** END SUPPLY TRANSACTION ***********
            '***** LEFT MENU **********
            'SUPPLY TRANSACTION
        ElseIf n = 10 Then
            With FMain
                If on_off = True Then
                    .ToolStripButton1.Enabled = True
                Else
                    .ToolStripButton1.Enabled = False
                End If
            End With
            'WAREHOUSE ITEMS
        ElseIf n = 11 Then
            With FMain
                If on_off = True Then
                    .tlstripbtn1.Enabled = True
                Else
                    .tlstripbtn1.Enabled = False
                End If
            End With

            'STOCK CARD MAINTENANCE
        ElseIf n = 12 Then
            With FMain
                If on_off = True Then
                    .ToolStripButton2.Enabled = True
                Else
                    .ToolStripButton2.Enabled = False
                End If
            End With

            'REGISTRATION
        ElseIf n = 13 And restriction = "Admin" Then
            With FMain
                If on_off = True Then
                    .ToolStripButton3.Enabled = True
                Else
                    .ToolStripButton3.Enabled = False
                End If
            End With
            '********END LEFT MENU**************

            '******* BORROWER ***********
        ElseIf n = 14 Then
            With FMain
                If on_off = True Then
                    .BorrowedItemMonitoringToolStripMenuItem.Enabled = True
                Else
                    .BorrowedItemMonitoringToolStripMenuItem.Enabled = False
                End If
            End With

        ElseIf n = 15 Then
            With FMain
                If on_off = True Then
                    .FacilitiesMaintenanceToolStripMenuItem.Enabled = True
                Else
                    .FacilitiesMaintenanceToolStripMenuItem.Enabled = False
                End If
            End With

        ElseIf n = 16 Then
            With FMain
                If on_off = True Then
                    .BorrowerSlipToolStripMenuItem.Enabled = True
                Else
                    .BorrowerSlipToolStripMenuItem.Enabled = False
                End If
            End With

            '******* END BORROWER *******

            '******* CHARGES MAINTENANCE *****
        ElseIf n = 17 Then
            With FMain
                If on_off = True Then
                    .ChargesMaintananceToolStripMenuItem.Enabled = True
                Else
                    .ChargesMaintananceToolStripMenuItem.Enabled = False
                End If
            End With
            '******* END CHARGES MAINTENANCE *******

            '******* SUPPLIER MAINTENANCE *****
        ElseIf n = 18 Then
            With FMain
                If on_off = True Then
                    .SupplierMaintenanceToolStripMenuItem.Enabled = True
                Else
                    .SupplierMaintenanceToolStripMenuItem.Enabled = False
                End If
            End With
            '******* SUPPLIER MAINTENANCE *****

            '******* PROJECT COST MAINTENANCE *****
        ElseIf n = 23 Then
            With FSupplyTransaction
                If on_off = True Then
                    .pbox_projectcost.Enabled = True
                    .Label31.Enabled = True
                    .Label30.Enabled = True
                Else
                    .pbox_projectcost.Enabled = False
                    .Label31.Enabled = False
                    .Label30.Enabled = False
                End If
            End With

            '******* EQUIPMENT MONITORING MAINTENANCE *****
        ElseIf n = 24 Then
            With FSupplyTransaction
                If on_off = True Then
                    .pbox_equipment_monitoring.Enabled = True
                    .Label32.Enabled = True
                    .Label33.Enabled = True
                Else
                    .pbox_equipment_monitoring.Enabled = False
                    .Label32.Enabled = False
                    .Label33.Enabled = False
                End If
            End With

            '******* EQUIPMENT COST *****
        ElseIf n = 25 Then
            With FSupplyTransaction
                If on_off = True Then
                    .pboxEquipmentCost.Enabled = True
                    .Label26.Enabled = True
                    .Label27.Enabled = True
                Else
                    .pboxEquipmentCost.Enabled = False
                    .Label32.Enabled = False
                    .Label33.Enabled = False
                End If
            End With

            '******* LIQUIDITION *****
        ElseIf n = 22 Then
            With FSupplyTransaction
                If on_off = True Then
                    .pboxLiquidation.Enabled = True
                    .Label25.Enabled = True
                    .Label24.Enabled = True
                Else
                    .pboxEquipmentCost.Enabled = False
                    .Label25.Enabled = False
                    .Label24.Enabled = False
                End If
            End With

            '******* LABOR COST *****
        ElseIf n = 26 Then
            With FSupplyTransaction
                If on_off = True Then
                    .pboxLaborCost.Enabled = True
                    .Label29.Enabled = True
                    .Label28.Enabled = True
                Else
                    .pboxEquipmentCost.Enabled = False
                    .Label29.Enabled = False
                    .Label28.Enabled = False
                End If
            End With

            '******* ACCOUNTING TR *****
        ElseIf n = 27 Then
            With FSupplyTransaction
                If on_off = True Then
                    .pboxAccounting.Enabled = True
                    .Label35.Enabled = True
                    .Label34.Enabled = True
                Else
                    .pboxEquipmentCost.Enabled = False
                    .Label35.Enabled = False
                    .Label34.Enabled = False
                End If
            End With

        ElseIf n = 29 Then
            With FSupplyTransaction
                .pBoxAllowanceSummary.Enabled = on_off
                .Label39.Enabled = on_off
                .Label38.Enabled = on_off
            End With

        ElseIf n = 31 Then
            With FMain
                If on_off = True Then
                    .SupplierMaintenanceToolStripMenuItem.Enabled = True
                Else
                    .SupplierMaintenanceToolStripMenuItem.Enabled = False
                End If
            End With

            '******* WITHDRAWAL REPORT *****
        ElseIf n = 32 Then
            With FSupplyTransaction
                .pBoxWithdrawalReport.Enabled = on_off
                .Label45.Enabled = on_off
                .Label44.Enabled = on_off
            End With

            '******* SUMMARY OF HAULED AGGREGATES *****
        ElseIf n = 33 Then
            With FSupplyTransaction
                .pBoxSummaryOfHauledAggregates.Enabled = on_off
                .Label47.Enabled = on_off
                .Label46.Enabled = on_off
            End With

            '******* GENERAL EXPORT *****
        ElseIf n = 34 Then
            With FSupplyTransaction
                .pBoxGeneralExport.Enabled = on_off
                .Label40.Enabled = on_off
                .Label41.Enabled = on_off
            End With


            '******* SUPPLIER EVALUATION *****
        ElseIf n = 35 Then
            With FSupplyTransaction
                .pBoxSupplierEvaluation.Enabled = on_off
                .Label42.Enabled = on_off
                .Label43.Enabled = on_off
            End With
        Else

            'For Each item As ToolStripMenuItem In FMain.MainMenu.Items
            '    item.Enabled = False
            'Next
        End If

    End Sub

End Module
