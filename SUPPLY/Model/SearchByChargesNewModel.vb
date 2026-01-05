Imports System.ComponentModel
Imports OfficeOpenXml.ExcelErrorValue

Public Class SearchByChargesNewModel
    Public searchByChargesBgWorker As New List(Of BackgroundWorker)
    Private customMsg As New customMessageBox

    Dim cBgWorkerChecker As Timer
    Private cLoadingPanel As New Panel
    Private cLvl As New ListView

    Private searchByChargesModel,
        whItemsModel,
        allChargesModel,
        searchByRequestedByModel As New ModelNew.Model
    Private cListOfRsCharges As New List(Of PropsFields.byCharges)
    Private cListOfRsRequestedBy As New List(Of PropsFields.byCharges)

    Private cListOfWhItems As New List(Of PropsFields.whItems_props_fields)
    Private cListOfListViewItem As New List(Of ListViewItem)

    Private cSearchBy As String

#Region "CORE/PROPS"
    Public Class myProps
        Public Property searchBy As String
        Public Property search As String
        Public Property chargesId As Integer
        Public Property items As String
        Public Property division As String
        Public Property category As String
        Public Property loadingPanel As Panel
        Public Property dateFrom As DateTime
        Public Property dateTo As DateTime

    End Class
#End Region


#Region "INITIALIZE"

    Public Sub initialize_listView(lvl As ListView)
        Try
            cLvl = lvl
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Public Sub initialize_all_data(props As myProps,
                                   Optional isDateEnable As Boolean = False)


        Dim cRsSearchBy = FRequesitionSearchBy.cSearchByEnum

        Try
            cLoadingPanel = props.loadingPanel
            cLoadingPanel.Visible = True

            cLvl.Items.Clear()
            cListOfRsCharges.Clear()
            cListOfWhItems.Clear()
            cListOfListViewItem.Clear()

            searchByChargesModel.clearParameter()
            whItemsModel.clearParameter()
            searchByRequestedByModel.clearParameter()

            Dim searchByChargesValues,
                whItemsValues,
                allChargesValues,
                searchByRequestedByValues As New ColumnValues

            searchByChargesValues.add("search", props.search)
            searchByChargesValues.add("items", props.items)
            searchByChargesValues.add("searchBy", props.searchBy)
            searchByChargesValues.add("division", props.division)
            searchByChargesValues.add("dateFrom", props.dateFrom)
            searchByChargesValues.add("dateTo", props.dateTo)
            searchByChargesValues.add("category", props.category)
            searchByChargesValues.add("chargesId", props.chargesId)

            searchByRequestedByValues.add("search", props.search)
            searchByRequestedByValues.add("items", props.items)
            searchByRequestedByValues.add("searchBy", props.searchBy)
            searchByRequestedByValues.add("division", props.division)
            searchByRequestedByValues.add("dateFrom", props.dateFrom)
            searchByRequestedByValues.add("dateTo", props.dateTo)
            searchByRequestedByValues.add("category", props.category)
            searchByRequestedByValues.add("chargesId", props.chargesId)

            cSearchBy = props.searchBy

            If isDateEnable Then
                _initializing(cCol.forSearchByChargesWithDateRange,
                                searchByChargesValues.getValues(),
                                searchByChargesModel,
                                searchByChargesBgWorker)
            Else
                If props.searchBy = cRsSearchBy.searchByCharges Then

                    _initializing(cCol.forSearchByCharges,
                                    searchByChargesValues.getValues(),
                                    searchByChargesModel,
                                    searchByChargesBgWorker)

                ElseIf props.searchBy = cRsSearchBy.searchByRequestBy Then

                    _initializing(cCol.forSearchByRequestedBy,
                                  searchByRequestedByValues.getValues(),
                                  searchByRequestedByModel,
                                  searchByChargesBgWorker)
                End If

            End If

            _initializing(cCol.forWhItems,
                    whItemsValues.getValues(),
                    whItemsModel,
                    searchByChargesBgWorker)


            cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyInitialize, searchByChargesBgWorker)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
#End Region


#Region "SUCCESSFULLY INITIALIZE"
    Private Sub SuccessfullyInitialize()
        Try
            Dim cRsSearchBy = FRequesitionSearchBy.cSearchByEnum

            cListOfRsCharges = TryCast(searchByChargesModel.cData, List(Of PropsFields.byCharges))
            cListOfWhItems = TryCast(whItemsModel.cData, List(Of PropsFields.whItems_props_fields))
            cListOfRsRequestedBy = TryCast(searchByRequestedByModel.cData, List(Of PropsFields.byCharges))

            If cSearchBy = cRsSearchBy.searchByRequestBy Then
                preview_requested_by()
            Else
                preview()
            End If


            cLoadingPanel.Visible = False

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub preview()
        Try
            For Each row In cListOfRsCharges
                Dim a(10) As String

                a(0) = row.rsNo
                a(1) = getWarehouseItem(row.wh_id)
                a(2) = row.rs_date
                a(3) = row.wh_id
                a(4) = row.rsId
                a(5) = FRequesitionFormForDR.getNewDrModel().getChargesByRsId(row.rsId)
                a(6) = row.item_desc_from_rs
                a(7) = FormatNumber(row.qty * row.price).ToString()
                a(8) = row.type_of_purchasing

                Dim lvi As New ListViewItem(a)
                If row.wh_id <> 0 Then
                    lvi.BackColor = Color.LightGreen
                End If

                cListOfListViewItem.Add(lvi)
            Next

            Dim trd As Threading.Thread
            trd = New Threading.Thread(AddressOf letsGo)
            trd.Start()


        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub preview_requested_by()
        Try
            For Each row In cListOfRsRequestedBy
                Dim a(10) As String

                a(0) = row.rsNo
                a(1) = getWarehouseItem(row.wh_id)
                a(2) = row.rs_date
                a(3) = row.wh_id
                a(4) = row.rsId
                a(5) = FRequesitionFormForDR.getNewDrModel().getChargesByRsId(row.rsId)
                a(6) = row.item_desc_from_rs
                a(7) = FormatNumber(row.qty * row.price).ToString()
                a(8) = row.type_of_purchasing
                a(9) = row.requested_by

                Dim lvi As New ListViewItem(a)
                If row.wh_id <> 0 Then
                    lvi.BackColor = Color.LightGreen
                End If

                cListOfListViewItem.Add(lvi)
            Next

            Dim trd As Threading.Thread
            trd = New Threading.Thread(AddressOf letsGo)
            trd.Start()


        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub letsGo()
        If cLvl.InvokeRequired Then
            cLvl.Invoke(Sub()
                            cLvl.Items.AddRange(cListOfListViewItem.ToArray())
                        End Sub)
        Else
            cLvl.Items.AddRange(cListOfListViewItem.ToArray())
        End If
    End Sub

#End Region


#Region "GET"
    Private Function getWarehouseItem(wh_id As Integer) As String
        Try
            Dim data = cListOfWhItems?.FirstOrDefault(Function(x) x.wh_id = wh_id)

            getWarehouseItem = $"{data?.item_name} - {data?.item_desc}"

            Return getWarehouseItem
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function


#End Region

End Class
