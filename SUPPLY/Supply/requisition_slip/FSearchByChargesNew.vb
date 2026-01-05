Public Class FSearchByChargesNew
    Private SEARCHBYCHARGESNEWMODEL As New SearchByChargesNewModel
    Private customMsg As New customMessageBox
    Public cSearchBy As String
    Public cCategory As String
    Public cSearch As String
    Public cChargesId As Integer
    Public cItems As String
    Public cDivision As String
    Public cDateFrom As DateTime
    Public cDateTo As DateTime
    Public isDateEnable As Boolean 
    Private cListOfRsId As New List(Of Integer)

    Private increment As Integer

    Sub FSearchByChargesNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim _props As New SearchByChargesNewModel.myProps
            With _props
                .search = cSearch
                .searchBy = cSearchBy
                .items = cItems
                .division = cDivision
                .loadingPanel = loadingPanel
                .dateFrom = cDateFrom
                .dateTo = cDateTo
                .category = cCategory
                .chargesId = cChargesId
            End With

            SEARCHBYCHARGESNEWMODEL.initialize_listView(lvlSearchCharges)
            SEARCHBYCHARGESNEWMODEL.initialize_all_data(_props, isDateEnable)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        For Each row As ListViewItem In lvlSearchCharges.Items
            row.Checked = True
        Next
    End Sub

    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        For Each row As ListViewItem In lvlSearchCharges.Items
            row.Checked = False
        Next
    End Sub

    Private Sub btnListOfWhItem_Click(sender As Object, e As EventArgs) Handles btnProceed.Click
        Try

            cListOfRsId.Clear()
            increment = 0
            Dim drModel = FRequesitionFormForDR.getNewDrModel()
            drModel.listOfCuratedRsDatas.Clear()

            btnProceed.Enabled = False

            For Each row As ListViewItem In lvlSearchCharges.Items
                If row.Checked Then
                    cListOfRsId.Add(row.SubItems(4).Text)
                End If
            Next

            TchargesExecuter.Start()

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim searchRs = FRequesitionFormForDR.getNewDrModel()
        searchRs.loadAllRsByCharges()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles TchargesChecker.Tick
        Dim searchRs = FRequesitionFormForDR.getNewDrModel()
        Label1.Text = searchRs.isDone
        PictureBox1.Visible = True

        If searchRs.isDone = False Then
            TchargesChecker.Stop()

            If Not increment = cListOfRsId.Count Then
                TchargesExecuter.Start()
            Else
                searchRs.loadAllRsByCharges()
                PictureBox1.Visible = False
                btnProceed.Enabled = True
            End If
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles TchargesExecuter.Tick

        Dim searchByEnum = FRequesitionSearchBy.cSearchByEnum
        Dim searchRs = FRequesitionFormForDR.getNewDrModel()

        If searchRs.isDone = False Then
            searchRs.isSearchByCharges = True
            searchRs.isDone = True

            searchRs.initialize(searchByEnum.searchByRsId,
                                cListOfRsId(increment),
                                FRequesitionFormForDR.DataGridView1)

            searchRs.execute()
            increment += 1

            TchargesExecuter.Stop()
            TchargesChecker.Start()

        End If

    End Sub

    Private Sub FSearchByChargesNew_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Dispose()
        FRequesitionSearchBy.Dispose()
        FRequesitionFormForDR.getNewDrModel().isSearchByCharges = False
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class