Public Class DRLIST_SEARCHBY

    Private sorByUI, itemDescUI, itemsUI, inoutUI, enableDisableUI, dateFromUI, dateToUI As New class_placeholder4
    Private customMsg As New customMessageBox


    Private Sub cmbEnableDateRange_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEnableDateRange.SelectedIndexChanged
        If cmbEnableDateRange.SelectedIndex = 0 Then
            dtpfrom.Enabled = True
            dtpto.Enabled = True
        ElseIf cmbEnableDateRange.SelectedIndex = 1 Then
            dtpfrom.Enabled = False
            dtpto.Enabled = False

        End If
    End Sub

    Private Sub cmbSortBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSortBy.SelectedIndexChanged
        enableDisable(cmbSortBy.Text)

    End Sub

    Private Sub enableDisable(sortBy As String)
        If sortBy = cDrSearchBy.RSNO Or
            sortBy = cDrSearchBy.DRNO Or
            sortBy = cDrSearchBy.WSNO Or
            sortBy = cDrSearchBy.CONSESSION Or
            sortBy = cDrSearchBy.REMARKS Or
            sortBy = cDrSearchBy.UNIT Or
            sortBy = cDrSearchBy.SUPPLIER Then

            For Each ctr As Control In Panel1.Controls
                If ctr.Name = "cmbSortBy" Or
                    ctr.Name = "txtItemDesc" Or
                    ctr.Name = "btnSearch" Or
                    ctr.Name = "btnExit" Or
                    ctr.Name = "cmbEnableDateRange" Then

                    ctr.Enabled = True
                    txtItemDesc.Focus()
                    cmbEnableDateRange.SelectedIndex = 1
                Else

                    ctr.Enabled = False

                End If
            Next
        ElseIf sortBy = cDrSearchBy.DATE_RANGE Then
            For Each ctr As Control In Panel1.Controls
                If TypeOf ctr Is Label Then
                    ctr.Enabled = True
                Else
                    If ctr.Name = "cmbSortBy" Or
                  ctr.Name = "btnSearch" Or
                  ctr.Name = "btnExit" Or
                  ctr.Name = "dtpfrom" Or
                  ctr.Name = "dtpto" Then

                        ctr.Enabled = True
                        txtItemDesc.Focus()

                    Else

                        ctr.Enabled = False

                    End If
                End If

            Next

        ElseIf sortBy = cDrSearchBy.WITHOUT_RS_AND_DR Then
            For Each ctr As Control In Panel1.Controls
                If TypeOf ctr Is Label Then
                    ctr.Enabled = True
                Else
                    If ctr.Name = "cmbSortBy" Or
                  ctr.Name = "btnSearch" Or
                  ctr.Name = "btnExit" Or
                  ctr.Name = "dtpfrom" Or
                  ctr.Name = "dtpto" Then

                        ctr.Enabled = True
                        txtItemDesc.Focus()

                    Else
                        ctr.Enabled = False

                    End If
                End If

            Next
        End If


    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        If itemDescUI.ifBlankTexbox() And
            Not cmbSortBy.Text = cDrSearchBy.DATE_RANGE And
            Not cmbSortBy.Text = cDrSearchBy.WITHOUT_RS_AND_DR Then

            customMsg.message("error", "you must fill the searchbox first...", "SUPPLY INFO:")
            Exit Sub
        End If

        FDRLIST2.getDrDatasAndPreview(cmbSortBy.Text,
                        txtItemDesc.Text,
                        isDateRange(),
                        Date.Parse(dtpfrom.Text),
                        Date.Parse(dtpto.Text))

        Me.Dispose()

    End Sub

    Private Function isDateRange() As String
        Return IIf(cmbSortBy.Text = cDrSearchBy.DATE_RANGE, cDrSearchBy.DATE_RANGE, cmbEnableDateRange.Text)
    End Function

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Dispose()
    End Sub

    Private Sub DRLIST_SEARCHBY_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        sorByUI.king_placeholder_combobox("Sort By.", cmbSortBy, Nothing, Panel1, My.Resources.received,)
        itemDescUI.king_placeholder_textbox("Search...", txtItemDesc, Nothing, Panel1, My.Resources.received)
        itemsUI.king_placeholder_textbox("Items...", txtItems, Nothing, Panel1, My.Resources.received)
        inoutUI.king_placeholder_combobox("IN/OUT", cmbINOUT, Nothing, Panel1, My.Resources.received,)
        enableDisableUI.king_placeholder_combobox("enable/disable date range", cmbEnableDateRange, Nothing, Panel1, My.Resources.received,)
        dateFromUI.king_placeholder_datepicker("", dtpfrom, Panel1, My.Resources.received)
        dateToUI.king_placeholder_datepicker("", dtpto, Panel1, My.Resources.received)

        enableDisable(cDrSearchBy.RSNO)

        loadItems()
    End Sub

    Private Sub loadItems()

    End Sub
End Class