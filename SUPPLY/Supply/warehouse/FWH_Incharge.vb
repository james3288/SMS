Public Class FWH_Incharge
    Dim pFname, pLname As New class_placeholder4

    Private Sub FWH_Incharge_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        pFname.king_placeholder_textbox("First Name", txtFname, Nothing, Panel1, My.Resources.username_icon, False, "White")
        pLname.king_placeholder_textbox("Last Name", txtLname, Nothing, Panel1, My.Resources.username_icon, False, "White")

        load_incharge()
    End Sub

    Private Sub load_incharge()

        Dim SelectQuery As New Model_Dynamic_Select

        SelectQuery._initialize("db_wh_incharge",
                                $"fname Like '%' + '{""}'",
                                "incharge_id,fname,lname")

        SelectQuery.display(lvList, 2)


    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If btnSave.Text = "Save" Then

            If pFname.blank_textbox() = True Then
                Exit Sub
            ElseIf pLname.blank_textbox() = True Then
                Exit Sub
            End If

            If MessageBox.Show("Are you sure you want to save this data?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Dim SaveIncharge As New Model_King_Dynamic_Update

                Dim parameter As New Dictionary(Of String, Object)
                parameter.Add("fname", txtFname.Text)
                parameter.Add("lname", txtLname.Text)

                SaveIncharge.InsertData("db_wh_incharge", parameter)
                MessageBox.Show("Successfully Saved!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)

                txtFname.Clear()
                txtLname.Clear()
                txtFname.Focus()

                load_incharge()

            End If

        ElseIf btnSave.Text = "Update" Then
            If MessageBox.Show("Are you sure you want to update this data?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Dim UpdateIncharge As New Model_King_Dynamic_Update

                Dim parameter As New Dictionary(Of String, Object)
                Dim incharge_id As Integer = lvList.SelectedItems(0).Text

                parameter.Add("fname", txtFname.Text)
                parameter.Add("lname", txtLname.Text)

                UpdateIncharge.UpdateData("db_wh_incharge", parameter, $"incharge_id={incharge_id}")
                MessageBox.Show("Successfully Updated!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)

                txtFname.Clear()
                txtLname.Clear()
                txtFname.Focus()

                lvList.Enabled = True
                load_incharge()
                listfocus(lvList, incharge_id)


            End If
        End If

    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click

        txtFname.Text = lvList.SelectedItems(0).SubItems(1).Text
        txtLname.Text = lvList.SelectedItems(0).SubItems(2).Text
        lvList.Enabled = False
        btnSave.Text = "Update"

    End Sub

    Private Sub lvList_DoubleClick(sender As Object, e As EventArgs) Handles lvList.DoubleClick
        If btnSelect.Enabled = False Then
            With FWarehouseItems
                .txtIncharge.Text = $"{lvList.SelectedItems(0).SubItems(2).Text}, {lvList.SelectedItems(0).SubItems(1).Text}"
                .cIncharge_id = lvList.SelectedItems(0).Text
                Me.Close()
            End With
        End If

    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click

        If MessageBox.Show("Are you sure you want to update warehouse incharge?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            With FWarehouseItems
                For Each row As ListViewItem In .lvlItemList.Items
                    If row.Selected = True Then
                        Dim update As New Model_King_Dynamic_Update

                        Dim columnValues As New Dictionary(Of String, Object)()
                        columnValues.Add("incharge_id", lvList.SelectedItems(0).Text)

                        update.UpdateData("dbwarehouse_items", columnValues, $"wh_id={row.Text }")
                        row.SubItems(7).Text = lvList.SelectedItems(0).SubItems(2).Text & ", " & lvList.SelectedItems(0).SubItems(1).Text
                    End If
                Next
                Me.Close()

            End With
        End If
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you wan't to remove selected items?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            For Each row As ListViewItem In lvList.Items
                If row.Selected = True Then
                    Dim delete As New Model_King_Dynamic_Update

                    delete.DeleteData("db_wh_incharge", $"incharge_id={row.Text}")
                    row.Remove()

                End If
            Next
        End If


    End Sub
End Class