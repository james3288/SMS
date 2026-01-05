Imports System.ComponentModel

Public Class FRequesitionSearchByModel
    Public cRsSearchByBgWorker As New List(Of BackgroundWorker)
    Private customDatagrid As New CustomGridview
    Private customMsg As New customMessageBox

    Dim cBgWorkerChecker As Timer
    Private cLoadingPanel As New Panel
    Private cListOfCharges As New List(Of PropsFields.AllCharges)
    Private cListOfEmployees As New List(Of PropsFields.employee_props_fields)
    Private allChargesModel, EmployeeModel As New ModelNew.Model
    Private cWhatToSearchUI As New class_placeholder5
    Private cSearchBy As String


#Region "INITIALIZE"
    Public Sub initialize_searchBy(searchBy As String, cmbCategory As ComboBox)
        Try
            cSearchBy = searchBy

            Dim searchByEnum = FRequesitionSearchBy.cSearchByEnum

            Select Case cSearchBy
                Case searchByEnum.searchByCharges
                    cmbCategory.Items.Clear()
                    Dim orderedDistinctCategories = cListOfCharges _
                                                                    .Select(Function(x) x.charges_category) _
                                                                    .Distinct() _
                                                                    .OrderBy(Function(cat) cat) _
                                                                    .ToList()

                    For Each row In orderedDistinctCategories
                        cmbCategory.Items.Add(row)
                    Next

                    'cWhatToSearchUI.AutoCompleteData = cListOfCharges.Select(Function(x) x.charges).ToList()
                    'cWhatToSearchUI.set_autocomplete()

                Case searchByEnum.searchByRequestBy

                    cWhatToSearchUI.AutoCompleteData = cListOfEmployees.Select(Function(x) $"{x.last_name}, {x.first_name}").ToList()
                    cWhatToSearchUI.set_autocomplete()
            End Select

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Public Sub initalize_searchBy_category(category As String)
        Try
            Dim charges = cListOfCharges.Where(Function(x) x.charges_category = category).ToList()

            cWhatToSearchUI.AutoCompleteData = charges.Select(Function(x) x.charges).ToList()
            cWhatToSearchUI.set_autocomplete()

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Public Sub initialize_whatToSearch(wts As class_placeholder5)
        Try
            cWhatToSearchUI = wts
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Public Sub initialize_all_data(Optional loadingPanel As Panel = Nothing)
        Try
            cLoadingPanel = loadingPanel
            cLoadingPanel.Visible = True

            Dim allChargesValues, employeeValues As New ColumnValues

            _initializing(cCol.forAllCharges,
              allChargesValues.getValues(),
              allChargesModel,
              cRsSearchByBgWorker)

            _initializing(cCol.forEmployeeData,
                     employeeValues.getValues(),
                     EmployeeModel,
                     cRsSearchByBgWorker)

            cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyInitialize, cRsSearchByBgWorker)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
#End Region

#Region "SUCCESSFULLY INITIALIZE"
    Private Sub SuccessfullyInitialize()
        Try
            cListOfCharges = TryCast(allChargesModel.cData, List(Of PropsFields.AllCharges))
            cListOfEmployees = TryCast(EmployeeModel.cData, List(Of PropsFields.employee_props_fields))

            cLoadingPanel.Visible = False

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Sub
#End Region

#Region "GET"
    Public Function getChargesId(category As String, charges As String) As Integer
        Try
            Dim result = cListOfCharges.FirstOrDefault(Function(x)
                                                           Return x.charges_category.ToUpper() = category.ToUpper() And
                                                           x.charges.ToUpper() = charges.ToUpper()
                                                       End Function)

            If result IsNot Nothing Then
                getChargesId = result.charges_id
            Else
                Return 0
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
#End Region
End Class
