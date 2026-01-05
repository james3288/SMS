Imports System.ComponentModel
Imports SUPPLY.KeyPerformanceIndicatorModel

Public Class CreateChargesModel
    Private allChargesModel, multipleChargesModel, QTODetailsModel As New ModelNew.Model
    Public createChargesBgWorker As New List(Of BackgroundWorker)
    Private customDatagrid As New CustomGridview

    Dim cBgWorkerChecker As Timer
    Private cSearch As String
    Private cAllChargesDgv, cRsChargesDgv As New DataGridView
    Private cSearchByCBox As New ComboBox

    Private cListOfCharges As New List(Of PropsFields.AllCharges)
    Private cListOfMultipleCharges As New List(Of PropsFields.MultipleCharges)
    Private cListRefactoredRsCharges As New List(Of charges)
    Private cListOfQTODetails As New List(Of PropsFields.QTO_details)

    Private customMsg As New customMessageBox
    Private cLoadingPanel As New Panel

    Private cRsId As Integer
    Private cRsNo As String

    Private cn As charges
    Private cn2 As PropsFields.AllCharges

#Region "CORE ENTITIES"
    Public Class charges
        Public Property charges_id As Integer
        Public Property charges As String
        Public Property qto_details As String
        Public Property typeOfCharges As String
        Public Property createdAt As DateTime

    End Class
#End Region

#Region "INITIALIZE AND PREVIEW"
    Public Sub initialize_datagridview(Optional dgv As DataGridView = Nothing)
        cAllChargesDgv = dgv
        customDatagrid.customDatagridview(cAllChargesDgv,,, 10)
    End Sub

    Public Sub initialize_datagridview2(Optional dgv As DataGridView = Nothing)
        cRsChargesDgv = dgv
        customDatagrid.customDatagridview(cRsChargesDgv,,, 10)
    End Sub

    Public Sub initialize_rsId(rsId As Integer)
        cRsId = rsId
    End Sub

    Public Sub initialize_rsNo(rsNo As String)
        cRsNo = rsNo
    End Sub
    Public Sub initialize_searchBy(searchByCBox As ComboBox)
        cSearchByCBox = searchByCBox
    End Sub
    Public Sub initialize_multipleChargesOnly(Optional loadingPanel As Panel = Nothing)
        Try
            cLoadingPanel = loadingPanel
            cLoadingPanel.Visible = True

            Dim multipleCharges As New ColumnValues
            multipleCharges.add("rs_id", cRsId)

            cListOfMultipleCharges.Clear()
            cListRefactoredRsCharges.Clear()
            multipleChargesModel.clearParameter()

            _initializing(cCol.forMultipleCharges,
                       multipleCharges.getValues(),
                       multipleChargesModel,
                       createChargesBgWorker)

            cBgWorkerChecker = BgWorkersCheckerFn(AddressOf MultipleChargesSuccessfullyInitialize, createChargesBgWorker)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Public Sub initialize_all_data(Optional loadingPanel As Panel = Nothing)
        Try
            Dim allChargesValues,
                multipleCharges, qtoDetailsValues As New ColumnValues

            cLoadingPanel = loadingPanel
            cLoadingPanel.Visible = True

            cListOfCharges.Clear()
            cListOfMultipleCharges.Clear()
            cListRefactoredRsCharges.Clear()
            cListOfQTODetails.Clear()

            allChargesModel.clearParameter()
            multipleChargesModel.clearParameter()
            QTODetailsModel.clearParameter()


            multipleCharges.add("rs_id", cRsId)

            _initializing(cCol.forAllCharges,
                          allChargesValues.getValues(),
                          allChargesModel,
                          createChargesBgWorker)

            _initializing(cCol.forMultipleCharges,
                          multipleCharges.getValues(),
                          multipleChargesModel,
                          createChargesBgWorker)

            _initializing(cCol.forQTODetails,
                          qtoDetailsValues.getValues(),
                          QTODetailsModel,
                          createChargesBgWorker)

            cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyInitialize, createChargesBgWorker)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    ' private sub Preview()

    ' End Sub
    Public Sub refreshCurrentChargesAfterDelete(charges_id As Integer)
        Try
            Dim charges = cListOfMultipleCharges.FirstOrDefault(Function(x) x.charges_id = charges_id)
            If charges IsNot Nothing Then
                cListOfMultipleCharges.Remove(charges)
            End If

            cRsChargesDgv.DataSource = getRefactoredRsCharges()
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Sub

#End Region

#Region "SUCCESSFULLY INITIALIZE"
    Private Sub SuccessfullyInitialize()
        Try
            cListOfCharges = TryCast(allChargesModel.cData, List(Of PropsFields.AllCharges))
            cListOfMultipleCharges = TryCast(multipleChargesModel.cData, List(Of PropsFields.MultipleCharges))
            cListOfQTODetails = TryCast(QTODetailsModel.cData, List(Of PropsFields.QTO_details))

            cLoadingPanel.Visible = False

            cSearchByCBox.DataSource = getDistinctCharges()
            cRsChargesDgv.DataSource = getRefactoredRsCharges()

            cAllChargesDgv.DataSource = getAllCharges_ExcludeIfExistInMultipleCharges()

            customizeDatagridview()
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub MultipleChargesSuccessfullyInitialize()
        cListOfMultipleCharges = TryCast(multipleChargesModel.cData, List(Of PropsFields.MultipleCharges))
        cLoadingPanel.Visible = False

        cRsChargesDgv.DataSource = getRefactoredRsCharges()

    End Sub
#End Region

#Region "BUSINESS LOGIC"
    Public Sub searchByChargesCategory(searchBy As String)
        Try
            Dim datas = getAllCharges_ExcludeIfExistInMultipleCharges()
            If datas IsNot Nothing Then
                cAllChargesDgv.DataSource = datas.Where(Function(x)
                                                            Return x.charges_category.ToUpper() = searchBy.ToUpper()
                                                        End Function).ToList()
            End If


        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Public Sub searchByChargesCategoryAndDescription(searchBy As String, search As String)
        Try
            Dim datas = getAllCharges_ExcludeIfExistInMultipleCharges()

            Dim byChargesCategoryAndDescriptionData = datas.Where(Function(x)
                                                                      Return x.charges_category.ToUpper() = searchBy.ToUpper() And
                                                                            x.charges.ToUpper().Contains(search.ToUpper())
                                                                  End Function).ToList()

            cAllChargesDgv.DataSource = byChargesCategoryAndDescriptionData

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

#End Region

#Region "DATAGRIDVIEW ROWS"

#End Region

#Region "DATAGRIDVIEW ROWS FROM OTHER FORMS"

#End Region

#Region "CUSTOMIZE SOMETHING"
    Private Sub customizeDatagridview()
        Try
            customDatagrid.autoSizeColumn(cAllChargesDgv, True)
            customDatagrid.autoSizeColumn(cRsChargesDgv, True)

            cAllChargesDgv.ReadOnly = True
            cRsChargesDgv.ReadOnly = True

            'rename columns

            With cRsChargesDgv
                .Columns(NameOf(cn.charges)).HeaderText = "CHARGES"
                .Columns(NameOf(cn.qto_details)).HeaderText = "QTO DETAILS"
                .Columns(NameOf(cn.typeOfCharges)).HeaderText = "TYPE OF CHARGES"
            End With

            With cAllChargesDgv
                .Columns(NameOf(cn2.charges)).HeaderText = "CHARGES"
                .Columns(NameOf(cn2.charges_category)).HeaderText = "CHARGES CATEGORY"
                .Columns(NameOf(cn2.specific_location)).HeaderText = "SPECIFIC LOCATION"
            End With

            'hide columns
            With cRsChargesDgv
                .Columns(NameOf(cn.charges_id)).Visible = False
                .Columns(NameOf(cn.createdAt)).Visible = False
            End With

            With cAllChargesDgv
                .Columns(NameOf(cn2.charges_id)).Visible = False
                .Columns(NameOf(cn2.rs_id)).Visible = False
            End With

            customDatagrid.customHeader(cAllChargesDgv)
            customDatagrid.customHeader(cRsChargesDgv)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
#End Region

#Region "PUBLIC GET"
    Public ReadOnly Property getAllCharges() As List(Of PropsFields.AllCharges)
        Get
            Return cListOfCharges
        End Get
    End Property

    Public ReadOnly Property getRsId() As Integer
        Get
            Return cRsId
        End Get
    End Property

    Public ReadOnly Property getRsNo() As String
        Get
            Return cRsNo
        End Get
    End Property
#End Region

#Region "PRIVATE GET"
    Private Function getDistinctCharges()

        Try
            getDistinctCharges = cListOfCharges _
                                .Select(Function(x) x.charges_category.ToUpper()) _
                                .Distinct() _
                                .OrderBy(Function(x) x) _
                                .ToList()
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function

    Private Function getChargesInformation(row As PropsFields.MultipleCharges) As PropsFields.AllCharges
        Try
            Dim chargesData = cListOfCharges.FirstOrDefault(Function(x) x.charges_id = row.all_charges_id And
                                                                x.charges_category.ToUpper() = row.charges_category.ToUpper())
            Return chargesData

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function getQTODetails(rsId As Integer) As PropsFields.QTO_details
        Try
            Dim qtoDetails = cListOfQTODetails.FirstOrDefault(Function(x) x.rs_id = rsId)
            Return qtoDetails
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function getAllCharges_ExcludeIfExistInMultipleCharges() As List(Of PropsFields.AllCharges)
        Try
            getAllCharges_ExcludeIfExistInMultipleCharges = New List(Of PropsFields.AllCharges)

            For Each row In cListOfCharges
                Dim chargesExistInMultipleCharges = cListOfMultipleCharges.FirstOrDefault(Function(x)
                                                                                              Return x.all_charges_id = row.charges_id And
                                                                                              x.charges_category = row.charges_category
                                                                                          End Function)

                If chargesExistInMultipleCharges Is Nothing Then
                    Dim _newCharges As New PropsFields.AllCharges
                    With _newCharges
                        .charges_id = row.charges_id
                        .charges = row.charges
                        .charges_category = row.charges_category
                        .specific_location = row.specific_location

                        getAllCharges_ExcludeIfExistInMultipleCharges.Add(_newCharges)
                    End With
                End If
            Next
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function getRefactoredRsCharges() As List(Of charges)
        getRefactoredRsCharges = New List(Of charges)
        Try
            For Each row In cListOfMultipleCharges
                Dim _charges As New charges

                With _charges
                    .charges_id = row.charges_id

                    Dim _chargesInfo = useCharges(row)
                    .charges = _chargesInfo?.charges
                    .typeOfCharges = _chargesInfo?.charges_category

                    .qto_details = useQuantityTakeOffDetails(row)
                    .createdAt = row.createdAt
                End With

                getRefactoredRsCharges.Add(_charges)
            Next

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

#End Region

#Region "UTILITIES"
    Private Function useQuantityTakeOffDetails(row As PropsFields.MultipleCharges) As String
        Try
            If row.charges_category.ToUpper() = "PROJECT" Then
                Dim _qtoDetails = getQTODetails(row.rs_id)

                useQuantityTakeOffDetails = _qtoDetails?.details
            Else
                useQuantityTakeOffDetails = "-"
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function useCharges(row As PropsFields.MultipleCharges) As PropsFields.AllCharges
        Try
            Dim _chargesInfo = getChargesInformation(row)
            Return _chargesInfo

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
#End Region

#Region "CRUD"
    Public Function deleteCharges(charges_id As Integer) As Boolean
        Try
            Dim lot As New ListOfTables
            lot.addTable("dbMultipleCharges", $"charges_id = {charges_id}")

            Dim cc As New ColumnValuesObj
            cc.deleteDataUsingRollback(lot.getListOfTables)

            Return True
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
#End Region
End Class
