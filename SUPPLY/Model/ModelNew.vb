Imports System.ComponentModel
Imports System.Windows.Interop

Public Class ModelNew
    Public Class Model
        Private cDict As New Dictionary(Of String, Object)
        Public cStoredProcedure As String
        Public cWhatColumn As Integer
        Private cColumn As New ColumnEnum
        Private cCol As New ColumnEnum

        Public Delegate Function functionDelegates()
        Public Delegate Sub subDelegates()

        Public cData As Object

        Public ReadOnly Property getParameter As Dictionary(Of String, Object)
            Get
                Return cDict
            End Get
        End Property
        Public Function _getData()

            ' Begin the asynchronous operation

            Dim dataInstance = getDataInstance()
            Dim asyncResult As IAsyncResult = dataInstance.BeginInvoke(Nothing, Nothing)

            ' Wait for the asynchronous operation to complete
            'While Not asyncResult.IsCompleted
            '    Application.DoEvents()
            'End While
            asyncResult.AsyncWaitHandle.WaitOne()

            ' Get the result of the asynchronous operation
            _getData = dataInstance.EndInvoke(asyncResult)
        End Function

        Private Function getDataInstance()


            Dim queries As New QueriesFn
            Dim dynamic_queries As New DynamicQueriesFn
            Dim dynamicFn As New DynamicFn

            With queries
                .cDict = cDict
                .cStoredProcedure = cStoredProcedure
                .cWhatColumn = cWhatColumn
            End With

            With dynamic_queries
                .cDict = cDict
                .cWhatColumn = cWhatColumn
            End With


            Select Case cWhatColumn

                Case cCol.forEu_Project_DateFrom_DateTo
                    Dim dataInstance As ListOfEquipMentRequestDelegates
                    dataInstance = AddressOf queries._get_eu

                    getDataInstance = dataInstance

                Case cCol.forEu_Project
                    Dim dataInstance As ListOfEquipMentRequestDelegates

                    dataInstance = AddressOf dynamic_queries._get_eu_dynamic

                    getDataInstance = dataInstance

                Case cCol.forActive_Projects


                    Dim dataInstance As ListOfProjectsDelegates
                    dataInstance = AddressOf queries._getProjects

                    getDataInstance = dataInstance

                Case cCol.forWhItem_ProperNames

                    Dim dataInstance As ListOfWhItemProperNamesDelegates
                    dataInstance = AddressOf queries._getWhItem_ProperNames

                    getDataInstance = dataInstance

                Case cCol.forWhItems

                    Dim dataInstance As ListOfWhItemsDelegates
                    dataInstance = AddressOf queries._getWhItems

                    getDataInstance = dataInstance

                Case cCol.forWhIncharge

                    Dim dataInstance As ListOfWhInchargeDelegates
                    dataInstance = AddressOf queries._getWhIncharge

                    getDataInstance = dataInstance

                Case cCol.forDisplayResult

                    Dim dataInstance As ListOfListViewItemDelegates
                    dataInstance = AddressOf queries._ListViewDisplay

                    getDataInstance = dataInstance
                Case cCol.forDrSearch, cCol.forDrWithoutRsSearch

                    Dim dataInstance As ListOfDrItemsDelegates
                    dataInstance = AddressOf queries._getDrItems

                    getDataInstance = dataInstance

                Case cCol.forDrWsSearch

                    Dim dataInstance As ListOfDrWsItemsDelegates
                    dataInstance = AddressOf queries._getDrWsItems

                    getDataInstance = dataInstance

                Case cCol.forDrPoSearch

                    Dim dataInstance As ListOfDrPoItemsDelegates
                    dataInstance = AddressOf queries._getDrPoItems

                    getDataInstance = dataInstance

                Case cCol.forOperatorDriver

                    Dim dataInstance As ListOfOperatorDelegates
                    dataInstance = AddressOf queries._getOperatorDriver

                    getDataInstance = dataInstance

                Case cCol.forSupplier

                    Dim dataInstance As ListOfSupplierDelegates
                    dataInstance = AddressOf queries._getSupplier

                    getDataInstance = dataInstance

                Case cCol.forEmployees

                    Dim dataInstance As ListOfEmployeesDelegates
                    dataInstance = AddressOf queries._getEmployees

                    getDataInstance = dataInstance

                Case cCol.forChargesInfo

                    Dim dataInstance As ListOfChargesInfoDelegates
                    dataInstance = AddressOf queries._getChargesInfo

                    getDataInstance = dataInstance

                Case cCol.forPurchaseOrder

                    Dim dataInstance As ListOfPurchaseOrderDelegates
                    dataInstance = AddressOf queries._getPurchaseOrder

                    getDataInstance = dataInstance

                Case cCol.forWithdrawal, cCol.forWithdrawalPrice

                    Dim dataInstance As ListOfWithdrawalDelegates
                    dataInstance = AddressOf queries._getWithdrawal

                    getDataInstance = dataInstance

                Case cCol.forReceiving, cCol.forRrDr, cCol.forRrWithDetails

                    Dim dataInstance As ListOfReceivingDelegates
                    dataInstance = AddressOf queries._getReceiving

                    getDataInstance = dataInstance

                Case cCol.forRequisition

                    Dim dataInstance As ListOfRequisitionDelegates
                    dataInstance = AddressOf queries._getRs

                    getDataInstance = dataInstance

                Case cCol.forPrevBalance
                    Dim dataInstance As prevStockCardBalanceDelegates

                    dataInstance = AddressOf dynamic_queries._getStockCardPrevBalance

                    getDataInstance = dataInstance

                Case cCol.forWareHouseStockpileArea

                    Dim dataInstance As ListOfWhAreaStockpileDelegates

                    dataInstance = AddressOf queries._getWhArea_StockPileArea

                    getDataInstance = dataInstance

                Case cCol.forEmployeeData
                    Dim dataInstance As ListOfEmployeeDataDelegates

                    dataInstance = AddressOf queries._getEmployeeData

                    getDataInstance = dataInstance

                Case cCol.forSmsUsers
                    Dim dataInstance As ListOfSmsUsersDelegates

                    dataInstance = AddressOf queries._getSMSUsers

                    getDataInstance = dataInstance

                Case cCol.forWhInchargeNew
                    Dim dataInstance As ListOfWhInchargeNewDelegates

                    dataInstance = AddressOf queries._getAll_WhIncharge

                    getDataInstance = dataInstance

                Case cCol.forWithdrawn

                    Dim dataInstance As ListOfWithdrawnItemsDelegates

                    dataInstance = AddressOf queries._getWithdrawnItems

                    getDataInstance = dataInstance

                Case cCol.forPartiallyWithdrawn
                    Dim dataInstance As ListOfPartiallyWithdrawnItemsDelegates

                    dataInstance = AddressOf queries._getPartiallyWithdrawnItems

                    getDataInstance = dataInstance

                Case cCol.forPartiallyReleasedWithdrawal

                    Dim dataInstance As ListOfPartiallyReleasedWithdrawnItemsDelegates

                    dataInstance = AddressOf queries._getPartiallyReleasedWithdrawnItems

                    getDataInstance = dataInstance

                Case cCol.forRsCRH
                    Dim dataInstance As ListOfRsDataDelegates

                    dataInstance = AddressOf queries._getRSCRH

                    getDataInstance = dataInstance

                Case cCol.forMainRsCRH, cCol.forMainRsSubCRH, cCol.forMainRsCRH2, cCol.forMainRsSubCRH2
                    Dim dataInstance As ListOfMainRsDelegates

                    dataInstance = AddressOf queries._get_mainRs

                    getDataInstance = dataInstance

                Case cCol.forPlateNo
                    Dim dataInstance As ListOfEquipmentDelegates

                    dataInstance = AddressOf dynamic_queries._getListOfPlateNoDynamic

                    getDataInstance = dataInstance

                Case cCol.forAllCharges
                    Dim dataInstance As ListOfAlLChargesDelegates

                    dataInstance = AddressOf queries.getAllCharges

                    getDataInstance = dataInstance

                Case cCol.forMultipleCharges
                    Dim dataInstance As ListOfMultipleChargesDelegates

                    dataInstance = AddressOf queries.getMultipleCharges

                    getDataInstance = dataInstance
                Case cCol.forAggPrices
                    Dim dataInstance As ListOfAllAggPricesDelegates

                    dataInstance = AddressOf queries._getAggregatesPrices

                    getDataInstance = dataInstance

                Case cCol.forTirePosition
                    Dim dataInstance As ListOfTirePositionDelegates

                    dataInstance = AddressOf queries.getTirePosition

                    getDataInstance = dataInstance

                Case cCol.forTireSerialNo
                    Dim dataInstance As ListOfTireSerialNoDelegates

                    dataInstance = AddressOf queries.getTireSerialNo

                    getDataInstance = dataInstance

                Case cCol.forTireSerialNoView
                    Dim dataInstance As ListOfTireSerialNoViewDelegates

                    dataInstance = AddressOf queries.getTireSerialNoView

                    getDataInstance = dataInstance

                Case cCol.forKPIView
                    Dim dataInstance As ListOfKPIDelegates

                    dataInstance = AddressOf dynamic_queries._getKPIData

                    getDataInstance = dataInstance

                Case cCol.forMultipleKPI
                    Dim dataInstance As ListOfMultipleKPIDelegates

                    dataInstance = AddressOf dynamic_queries._getMultipleKPIData

                    getDataInstance = dataInstance

                Case cCol.forTypeOfRequest
                    Dim dataInstance As ListOfTypeOfRequestDelegates

                    dataInstance = AddressOf queries.getTypeOfRequest

                    getDataInstance = dataInstance

                Case cCol.forConsolidationAccount
                    Dim dataInstance As ListOfConsolidationAccount

                    dataInstance = AddressOf queries.getConsolidatedAccount

                    getDataInstance = dataInstance

                Case cCol.forRsDr
                    Dim dataInstance As ListOfRSForDrDelegates

                    dataInstance = AddressOf queries._getRS_forDR

                    getDataInstance = dataInstance

                Case cCol.forWsDr
                    Dim dataInstance As ListOfWsForDrDelegates

                    dataInstance = AddressOf queries._getWithdrawalForDR

                    getDataInstance = dataInstance

                Case cCol.forDrDr
                    Dim dataInstance As ListOfDrForDrDelegates

                    dataInstance = AddressOf queries._getDrForDr

                    getDataInstance = dataInstance

                Case cCol.forPoDr
                    Dim dataInstance As ListOfPoForDrDelegates

                    dataInstance = AddressOf queries._getPurchaseOrderForDR

                    getDataInstance = dataInstance

                Case cCol.forQTODetails
                    Dim dataInstance As ListOfQTODetailsDelegates

                    dataInstance = AddressOf queries.getQTO_details

                    getDataInstance = dataInstance

                Case cCol.forCancelRs
                    Dim dataInstance As ListOfCancelledTransactionDelegates

                    dataInstance = AddressOf queries.getCancelledTransaction

                    getDataInstance = dataInstance

                Case cCol.forSearchByCharges, cCol.forSearchByChargesWithDateRange

                    Dim dataInstance As ListOfSearchByChargesDelegates

                    dataInstance = AddressOf queries.getSearchByCharges

                    getDataInstance = dataInstance

                Case cCol.forSearchByRequestedBy
                    Dim dataInstance As ListOfSearchByRequestedByDelegates

                    dataInstance = AddressOf queries.getSearchByRequestedBy

                    getDataInstance = dataInstance

                Case cCol.forRsLocations
                    Dim dataInstance As ListOfRsLocations

                    dataInstance = AddressOf dynamic_queries._getRsLocations

                    getDataInstance = dataInstance
            End Select

        End Function

        Public Function BgWorkerDoWork(Optional fn As functionDelegates = Nothing) As BackgroundWorker

            BgWorkerDoWork = New BackgroundWorker

            AddHandler BgWorkerDoWork.DoWork, Sub(sender, e)
                                                  e.Result = fn()
                                              End Sub

            Return BgWorkerDoWork
        End Function

        Public Function BgWorkerCompleted(bgw As BackgroundWorker,
                                          Optional n As Integer = 0,
                                          Optional label As Label = Nothing)

            AddHandler bgw.RunWorkerCompleted,
                Sub(sender, e)
                    cData = e.Result

                    If n = cCol.forRsCRH Then
                        Dim aa = CType(cData, List(Of PropsFields.rsdata_props_fields))
                        finishCaption(label, aa.Count, "RS")

                    ElseIf n = cCol.forWithdrawal Then
                        Dim aa = CType(cData, List(Of PropsFields.withdrawal_props_fields))
                        finishCaption(label, aa.Count, "WS")

                    ElseIf n = cCol.forPurchaseOrder Then
                        Dim aa = CType(cData, List(Of PropsFields.purchase_order_props_fields))
                        finishCaption(label, aa.Count, "PO")

                    ElseIf n = cCol.forDrSearch Then
                        Dim aa = CType(cData, List(Of PropsFields.dr_props_fields))
                        finishCaption(label, aa.Count, "DR")

                    ElseIf n = cCol.forMainRsCRH Then
                        Dim aa = CType(cData, List(Of PropsFields.main_rsdata_props_fields))
                        finishCaption(label, aa.Count, "MRS")
                    End If

                End Sub
        End Function

        Public Function onProcessing(Optional n As Integer = 0,
                                     Optional label As Label = Nothing) As BackgroundWorker

            onProcessing = New BackgroundWorker
            onProcessing = BgWorkerDoWork(AddressOf _getData)

            BgWorkerCompleted(onProcessing, n, label)

            onProcessing.RunWorkerAsync()
            Return onProcessing
        End Function

        Public Sub parameter(key As String, value As Object)
            cDict.Add(key, value)
        End Sub

        Public Sub clearParameter()
            cDict = New Dictionary(Of String, Object)
        End Sub

        Private Sub finishCaption(label As Label, count As Integer, caption As String)
            If label IsNot Nothing Then
                label.ForeColor = Color.YellowGreen
                label.Font = New Font(cFontsFamily.arial, 10, FontStyle.Bold)
                label.BackColor = Color.DarkGreen
                label.Text = $"{caption}: ✔ ({count})"
            End If

        End Sub
    End Class
End Class
