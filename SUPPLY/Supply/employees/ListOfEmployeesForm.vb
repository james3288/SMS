Imports Microsoft.Office.Interop.Excel
Imports OfficeOpenXml.ExcelErrorValue
Imports SUPPLY.KeyPerformanceIndicatorModel

Public Class ListOfEmployeesForm
    Private listOfemployeeModel As New ListOfEmployeeModel
    Private searchUI As New class_placeholder5
    Dim cSearch As String
    Public whAreaId As Integer
    Public cWhArea As String
    Private cn As New PropsFields.employee_props_fields
    Private customMsg As New customMessageBox
    Private Sub ListOfEmployeesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        listOfemployeeModel.initialize(DataGridView1, whAreaId)
        listOfemployeeModel.getEmployess("", cSearch)

        searchUI.king_placeholder_textbox("Search Here...", txtSearch, Nothing, Panel2, My.Resources.received)
    End Sub

    Private Sub debounce_new_Tick(sender As Object, e As EventArgs) Handles debounce_new.Tick
        debounce_new.Stop()

        listOfemployeeModel.searchEmployees(cSearch)
        loadingPanel.Visible = False
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = 17 Then
            Exit Sub
        End If

        If txtSearch.TextLength > 0 Then
            loadingPanel.Visible = True
            debounce_new.Start()
        Else
            loadingPanel.Visible = True
            cSearch = ""
            debounce_new.Start()

        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

        cSearch = IIf(searchUI.placeHolder = txtSearch.Text, "", searchUI.tbox.Text)
    End Sub

    Private Sub AddInchargeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddInchargeToolStripMenuItem.Click
        Dim emp = listOfemployeeModel.getListOfEmployees().Where(Function(x)
                                                                     Dim employee_id As Integer = DataGridView1.SelectedRows(0).Cells(NameOf(cn.employee_id)).Value
                                                                     Return x.employee_id = employee_id
                                                                 End Function).ToList()

        If emp.Count > 0 Then
            Dim result As Integer = listOfemployeeModel.saved(emp(0), whAreaId)

            If result > 0 Then
                customMsg.message("info", "Successfully added incharge", "SUPPLY INFO:")

                With FWarehouseAreaNew.getWhAreaModel
                    '.setRowFocus = True
                    '.setRowId = whAreaId
                    '.getWareHouseArea()

                    Dim values As New PropsFields.whArea_stockpile_props_fields
                    With values
                        .wh_incharge = result
                        .wh_incharge = $"{ emp(0)?.last_name}, {emp(0)?.first_name}"
                        .wh_area_id = whAreaId
                        .wh_area = cWhArea
                    End With
                    .reloadItemsWithoutRefreshNew(whAreaId, "add_incharge", values, emp(0).employee_id)
                End With

                Me.Dispose()
            Else
                customMsg.message("error", "there is something wrong with saved function...", "SUPPLY INFO")
            End If
        End If

    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        Dim selectedRow = DataGridView1.SelectedRows(0)
        Dim data = listOfemployeeModel.getListOfEmployees().Where(Function(x)
                                                                      Return x.employee_id = selectedRow.Cells(NameOf(cn.employee_id)).Value
                                                                  End Function).ToList()
        If data.Count > 0 Then
            listOfemployeeModel.delete(data(0).employee_id, whAreaId)

            With FWarehouseAreaNew.getWhAreaModel
                '.setRowFocus = True
                '.setRowId = whAreaId
                '.getWareHouseArea()
                Dim values As New PropsFields.whArea_stockpile_props_fields
                values.wh_incharge = data(0).employee_id
                .reloadItemsWithoutRefreshNew(whAreaId, "remove_incharge", values, 0)
            End With

            'With FWarehouseItemsNew.getWhItemsModel
            '    .getWarehouseItems("")
            'End With

            Me.Dispose()
        End If


    End Sub
End Class