Public Class FWarehouse_FacilitiesTools_Checking

    Private Sub btn_Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Ok.Click

        If cmb_select_typeof_checking.Text = "Facilities/Tools Checking" Then
            rs_id = FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text
            rs_no = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(1).Text
            FListofBorrowerItem.ShowDialog()
            FListofBorrowerItem.btn_proceed.Enabled = True

        ElseIf cmb_select_typeof_checking.Text = "Items Checking" Then
            With FRequistionForm
                If .cmbDivision.Text = cDivision.WAREHOUSING_AND_SUPPLY Then

                    FListOfItems.cmboptions.SelectedIndex = 1
                    FListOfItems.cmboptions.Enabled = False


                ElseIf .cmbDivision.Text = cDivision.CRUSHING_AND_HAULING Then

                    FListOfItems.cmboptions.SelectedIndex = 0
                    FListOfItems.cmboptions.Enabled = False


                End If

                If .lvlrequisitionlist.SelectedItems(0).SubItems(15).Text = 0 Then
                    rs_id = .lvlrequisitionlist.SelectedItems(0).Text
                Else
                    If MessageBox.Show("Item was already checked from warehouse. Do you still want to proceed?", "SUPPLY INFO.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        rs_id = .lvlrequisitionlist.SelectedItems(0).Text
                    Else
                        rs_id = 0
                        Return
                    End If
                End If

                wh_item_destination = 1

                'this code indicate if item already linked in proper naming
                Dim selected_wh_pn_id As Integer = IIf(.lvlrequisitionlist.SelectedItems(0).SubItems(49).Text = "", 0, .lvlrequisitionlist.SelectedItems(0).SubItems(49).Text)

                If selected_wh_pn_id > 0 Then

                    FListOfItems.isItemLinked = True
                    FListOfItems.cWh_pn_id = selected_wh_pn_id

                End If

                FListOfItems.ShowDialog()
            End With

        ElseIf cmb_select_typeof_checking.Text = "Items Set" Then
            FItem_Sets.ListView1.Items.Clear()
            FItem_Sets.ShowDialog()
        End If

        Me.Hide()

    End Sub

    Private Sub cmb_select_typeof_checking_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_select_typeof_checking.SelectedIndexChanged

    End Sub

    Private Sub FWarehouse_FacilitiesTools_Checking_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            btn_Ok.PerformClick()

        End If
    End Sub

    Private Sub FWarehouse_FacilitiesTools_Checking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


End Class