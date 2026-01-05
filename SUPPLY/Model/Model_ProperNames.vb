Public Class Model_ProperNames
    Public properNamingModel As New ModelNew.Model
    Private cListOfListViewItem As New List(Of ListViewItem)
    Private cLoadingPanel As New Panel
    Dim cBgWorkerChecker As Timer
    Public Sub initialize(Optional paramLoading As Panel = Nothing)
        cLoadingPanel = paramLoading
    End Sub
    Public Sub loadProperNames()
        cListOfListViewItem.Clear()
        properNamingModel.clearParameter()

        cLoadingPanel.Visible = True

        Dim values As New Dictionary(Of String, String)

        _init_._initializing(cCol.forWhItem_ProperNames,
                      values,
                      properNamingModel,
                      whItemsProperNameBgWorker)

        cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, whItemsProperNameBgWorker)


    End Sub

    Private Sub SuccessfullyDone()
        Results.cListOfProperNaming = TryCast(properNamingModel.cData, List(Of PropsFields.whItems_properName_fields))
        cLoadingPanel.Visible = False


    End Sub
End Class
