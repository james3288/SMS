Imports System.Windows.Controls

Public Class FRequesitionSearchBy
    Private searchByUI,
        whatToSearchUI,
        dateFromUI,
        dateToUI,
        itemsUI,
        divisionUI,
        categoryUI As New class_placeholder5

    Public cSearchByEnum As New SEARCHBY
    Private NEWSEARCHBYMODEL As New FRequesitionSearchByModel
    Private isDateEnable As Boolean

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Const CS_DROPSHADOW As Integer = &H20000
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_DROPSHADOW
            Return cp
        End Get
    End Property

    Public Class SEARCHBY
        Public ReadOnly Property searchByCharges As String = "SEARCH BY CHARGES"
        Public ReadOnly Property searchByRequestBy As String = "SEARCH BY REQUESTED BY"
        Public ReadOnly Property searchByItem As String = "SEARCH BY ITEMS"
        Public ReadOnly Property searchByTypeOfRequest As String = "SEARCH BY TYPE OF REQUEST"
        Public ReadOnly Property searchByRsId As String = "SEARCH BY RS_ID"
        Public ReadOnly Property searchByJo As String = "SEARCH BY JOB ORDER"
        Public ReadOnly Property searchByUsername As String = "SEARCH BY USERNAME"
        Public ReadOnly Property searchByRs As String = "SEARCH BY RS"



    End Class

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private customMsg As New customMessageBox

    Private Sub cmbSearchBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearchBy.SelectedIndexChanged
        Try
            NEWSEARCHBYMODEL.initialize_searchBy(cmbSearchBy.Text, cmbCategory)
            'If cmbSearchBy.Text.ToUpper() = cSearchByEnum.searchByCharges.ToUpper() Then

            'End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Panel3.Enabled = True
            isDateEnable = True
        Else
            Panel3.Enabled = False
            isDateEnable = False
        End If
    End Sub

    Private Sub cmbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategory.SelectedIndexChanged
        Try
            NEWSEARCHBYMODEL.initalize_searchBy_category(cmbCategory.Text)
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub



    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If cmbSearchBy.Text = cSearchByEnum.searchByCharges Then

            'purpose of this is to disable some toolstripmenuitem in rs form if you search by charges
            FRequesitionFormForDR.isSearchByCharges = True

            With FSearchByChargesNew

                .cDivision = cmbDivision.Text
                .cSearchBy = cmbSearchBy.Text
                .cSearch = IIf(txtWhatToSearch.Text = whatToSearchUI.placeHolder(), "", txtWhatToSearch.Text)
                .cItems = IIf(txtItems.Text = itemsUI.placeHolder(), "", txtItems.Text)
                .cCategory = cmbCategory.Text

                Dim chargesId As Integer = NEWSEARCHBYMODEL.getChargesId(.cCategory, .cSearch)

#Region "FILTER"
                If chargesId = 0 Then
                    customMsg.message("error", "you must select an exact name of charges...", "SUPPLY INFO:")
                    Exit Sub
                End If
#End Region

                .cChargesId = chargesId

                If isDateEnable Then
                    .cDateFrom = Date.Parse(dtpDateFrom.Text)
                    .cDateTo = Date.Parse(dtpDateTo.Text)
                    .isDateEnable = True
                Else
                    .isDateEnable = False
                End If

                .ShowDialog()
            End With

        ElseIf cmbSearchBy.Text = cSearchByEnum.searchByRequestBy Then
            FRequesitionFormForDR.isSearchByRequestedBy = True

            With FSearchByChargesNew

                .cDivision = cmbDivision.Text
                .cSearchBy = cmbSearchBy.Text
                .cSearch = IIf(txtWhatToSearch.Text = whatToSearchUI.placeHolder(), "", txtWhatToSearch.Text)
                .cItems = IIf(txtItems.Text = itemsUI.placeHolder(), "", txtItems.Text)
                .cCategory = cmbCategory.Text


                If isDateEnable Then
                    .cDateFrom = Date.Parse(dtpDateFrom.Text)
                    .cDateTo = Date.Parse(dtpDateTo.Text)
                    .isDateEnable = True
                Else
                    .isDateEnable = False
                End If

                .ShowDialog()
            End With

        ElseIf cmbSearchBy.Text = cSearchByEnum.searchByItem Or
            cmbSearchBy.Text = cSearchByEnum.searchByJo Or
            cmbSearchBy.Text = cSearchByEnum.searchByUsername Or
            cmbSearchBy.Text = cSearchByEnum.searchByTypeOfRequest Then

            Utilities.UnderMaintenance()
        Else
            searchNow()
        End If

    End Sub

    Private Sub searchNow()
        Dim searchRs = FRequesitionFormForDR.getNewDrModel()

        searchRs.initialize(cmbSearchBy.Text.ToUpper(),
                            txtWhatToSearch.Text.ToUpper(),
                            FRequesitionFormForDR.DataGridView1)

        searchRs.execute()
    End Sub

    Private Sub FRequesitionSearchBy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadUI()
        loadSearchBy()
        loadDivision()

        NEWSEARCHBYMODEL.initialize_all_data(loadingPanel)
        NEWSEARCHBYMODEL.initialize_whatToSearch(whatToSearchUI)

        'movable panel
        Dim myPanel As New MovablePanel

        myPanel.addPanel(Panel2)
        myPanel.addPanel(Panel4)

        myPanel.initializeForm(Me)
        myPanel.addPanelEventHandler()
    End Sub

    Private Sub loadSearchBy()
        Try
            cmbSearchBy.Items.Add(cSearchByEnum.searchByCharges)
            cmbSearchBy.Items.Add(cSearchByEnum.searchByRequestBy)
            cmbSearchBy.Items.Add(cSearchByEnum.searchByRsId)
            cmbSearchBy.Items.Add(cSearchByEnum.searchByItem)
            cmbSearchBy.Items.Add(cSearchByEnum.searchByJo)
            cmbSearchBy.Items.Add(cSearchByEnum.searchByTypeOfRequest)
            cmbSearchBy.Items.Add(cSearchByEnum.searchByUsername)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub loadDivision()
        Try
            cmbDivision.Items.Add(cDivision.CRUSHING_AND_HAULING)
            cmbDivision.Items.Add(cDivision.WAREHOUSING_AND_SUPPLY)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub loadUI()
        Try
            Dim newFont As New ColumnValues
            newFont.add("fontName", cFontsFamily.bombardier)
            newFont.add("fontSize", 12)

            divisionUI.king_placeholder_combobox("division...",
                                                 cmbDivision,
                                                 Nothing,
                                                 Panel1,
                                                 My.Resources.received,
                                                 divisionUI.cCustomColor.Custom1,,,
                                                 newFont.getValues())

            searchByUI.king_placeholder_combobox("search by...",
                                                 cmbSearchBy,
                                                 Nothing, Panel1,
                                                 My.Resources.received,
                                                 searchByUI.cCustomColor.Custom1,,,
                                                newFont.getValues())

            categoryUI.king_placeholder_combobox("category...",
                                                 cmbCategory,
                                                 Nothing,
                                                 Panel1,
                                                 My.Resources.received,
                                                 categoryUI.cCustomColor.Custom1,,,
                                                 newFont.getValues())

            whatToSearchUI.king_placeholder_textbox("what to search...",
                                                    txtWhatToSearch,
                                                    Nothing,
                                                    Panel1,
                                                    My.Resources.received, False, whatToSearchUI.cCustomColor.Custom1,,,,
                                                    newFont.getValues())

            dateFromUI.king_placeholder_datepicker("",
                                                   dtpDateFrom,
                                                   Panel3,
                                                   My.Resources.received,
                                                   dateFromUI.cCustomColor.Custom1,
                                                   newFont.getValues())


            dateToUI.king_placeholder_datepicker("",
                                                   dtpDateTo,
                                                   Panel3,
                                                   My.Resources.received,
                                                   dateToUI.cCustomColor.Custom1,
                                                   newFont.getValues())

            itemsUI.king_placeholder_textbox("items...",
                                             txtItems,
                                             Nothing,
                                             Panel1,
                                             My.Resources.received,
                                             False,
                                             itemsUI.cCustomColor.Custom1,,,,
                                             newFont.getValues())

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
End Class