Imports SUPPLY.KeyPerformanceIndicatorModel

Public Class FCreateChargesNew
    Private searchUI, typeOfChargesUI As New class_placeholder5
    Private CREATECHARGESMODEL As New CreateChargesModel
    Private customMsg As New customMessageBox
    Private cn As New PropsFields.AllCharges
    Private cn2 As New CreateChargesModel.charges

    Public isCreateCharges_fromCreateRsForm As Boolean
    Public item_details_id As Integer = 0
    Public item_details_desc As String = ""

    Public ReadOnly Property getCreateChargesModel() As CreateChargesModel
        Get
            Return CREATECHARGESMODEL
        End Get
    End Property

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Const CS_DROPSHADOW As Integer = &H20000
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_DROPSHADOW
            Return cp
        End Get
    End Property

    Private Sub FCreateChargesNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim fontFamily As New Dictionary(Of String, String)
            fontFamily.Add("fontName", cFontsFamily.bombardier)
            fontFamily.Add("fontSize", 12)

            searchUI.king_placeholder_textbox("Search Charges...",
                                                  txtSearch,
                                                  Nothing,
                                                  Panel11,
                                                  My.Resources.received,
                                                    False,
                                                  searchUI.cCustomColor.Custom1,,,, fontFamily)

            typeOfChargesUI.king_placeholder_combobox("Type Of Charges...",
                                                      cmbTypeOfCharges,
                                                      Nothing, Panel11,
                                                      My.Resources.received,
                                                      ,,,
                                                      fontFamily)

            initialize_data()

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub addCharges()
        Dim inner_rs_id As Integer = CREATECHARGESMODEL.getRsId
        If customMsg.messageYesNo("Are you sure you want add the selected charges to this request?", "SUPPLY INFO:") Then
            Dim createCharges As New CreateRequesitionSlipChargesServices
            Dim _selectedCharges As New PropsFields.AllCharges
            Dim allChargesRow = dvgAllCharges.SelectedRows(0)


            If isProject(allChargesRow, inner_rs_id) And
                Not Utilities.isNotRestrictedTo(cDepartments.CRUSHING_AND_HAULING) Then

                frmQuanitityTakeOff.project_code = allChargesRow.Cells(NameOf(cn.charges)).Value
                frmQuanitityTakeOff.ShowDialog()

                If item_details_id = 0 Then
                    MsgBox("Please select Item No. First!")
                    Exit Sub
                End If
            End If

            With _selectedCharges
                .charges_id = allChargesRow.Cells(NameOf(cn.charges_id)).Value
                .charges_category = allChargesRow.Cells(NameOf(cn.charges_category)).Value
            End With

            Dim result As Integer = createCharges.ExecuteWithReturnId(_selectedCharges, inner_rs_id)

            If result > 0 Then
                customMsg.message("info", "charges added successfully!", "SUPPLY INFO:")

                'for QTO insertion
                If isProject(allChargesRow, inner_rs_id) And
                     Not Utilities.isNotRestrictedTo(cDepartments.CRUSHING_AND_HAULING) Then

                    insert_requisition_slip_item_details(item_details_id, inner_rs_id)
                End If

                'for storing charges if ever same ra og rs
                If isCreateCharges_fromCreateRsForm Then
                    FCreateRSForm.cSelectedChargesStorage.Add(_selectedCharges)
                End If

                CREATECHARGESMODEL.initialize_all_data(loadingPanel)
            Else
                customMsg.message("error", "something went wrong adding charges...", "SUPPLY INFO:")
            End If
        End If
    End Sub

    Private Function isProject(allChargesRow As DataGridViewRow, rs_id As Integer) As Boolean
        Try
            If allChargesRow.Cells(NameOf(cn.charges_category)).Value.Equals("PROJECT") Or
                allChargesRow.Cells(NameOf(cn.charges_category)).Value.Equals("Project") Or
                allChargesRow.Cells(NameOf(cn.charges_category)).Value.Equals("project") Then
                Return True
            End If

            Return False
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Sub cmbTypeOfCharges_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTypeOfCharges.SelectedIndexChanged
        CREATECHARGESMODEL.searchByChargesCategory(cmbTypeOfCharges.Text)
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

        CREATECHARGESMODEL.searchByChargesCategoryAndDescription(cmbTypeOfCharges.Text, txtSearch.Text)

    End Sub

    Private Sub AddChargesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddChargesToolStripMenuItem.Click

        addCharges()

    End Sub

    Private Sub RemoveChargesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveChargesToolStripMenuItem.Click
        If customMsg.messageYesNo("Are you sure you want to remove this charges?", "SUPPLY INFO:") Then
            Dim currentChargesRow = dgvCurrentCharges.SelectedRows(0)
            Dim charges_id As Integer = currentChargesRow.Cells(NameOf(cn2.charges_id)).Value

            Dim deleteCharges As New deleteChargesServices
            Dim deleteResult = deleteCharges.ExecuteWithReturnBoolean(charges_id)

            If deleteResult Then

                CREATECHARGESMODEL.refreshCurrentChargesAfterDelete(charges_id)
                update_requisition_slip_item_details(item_details_id, CREATECHARGESMODEL.getRsId)
                customMsg.message("info", "Successfully Deleted...", "SUPPLY INFO:")
            Else
                customMsg.message("error", "something went wrong in deleting charges...", "SUPPLY INFO:")
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If isCreateCharges_fromCreateRsForm Then

            With FRequesitionFormForDR
                .getNewDrModel().cRsId = CREATECHARGESMODEL.getRsId
                .getNewDrModel().isCreateRsAndAddCharges = True
                .txtSearch.Text = CREATECHARGESMODEL.getRsNo
                .searchUI.resetBgColor()

                .btnSearch.PerformClick()
            End With

        End If

        Me.Dispose()
    End Sub

    Private Sub initialize_data()

        CREATECHARGESMODEL.initialize_searchBy(cmbTypeOfCharges)
        CREATECHARGESMODEL.initialize_datagridview2(dgvCurrentCharges)
        CREATECHARGESMODEL.initialize_datagridview(dvgAllCharges)
        CREATECHARGESMODEL.initialize_all_data(loadingPanel)

    End Sub
End Class