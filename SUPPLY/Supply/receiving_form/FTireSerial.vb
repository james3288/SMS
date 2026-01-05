
Imports SUPPLY.PropsFields

Public Class FTireSerial
    Private cListOfTirePosition As New List(Of PropsFields.tirePosition_props_fields)
    Private cCustomMsg As New customMessageBox

    Private tirePositionModel, serialNoModel, serialNoViewModel As New ModelNew.Model
    Private cBgWorkerChecker As Timer
    Private customDgv As New CustomGridview
    Private tp As New PropsFields.tirePosition_props_fields
    Private tsn As New PropsFields.tireSerial_props_fields
    Private tsnv As New PropsFields.tireSerialView_props_fields


    Private serialNoUI As New class_placeholder5

    Public forReceivingInfo, forCreateReceiving As Boolean
    Public forCreateWithdrawal As Boolean
    Public forWithdrawn As Boolean

    Private cSearch As String
    Private cn As New tireSerialView_props_fields

    Private Sub FTireSerial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        serialNoUI.king_placeholder_textbox("serial #...", txtSearchItems, Nothing, Panel1, My.Resources.received, False, serialNoUI.cCustomColor.Custom1,)

        loadTirePosition()
        customDgv.customDatagridview(dgvTirePosition, "#011526", 34)
    End Sub

    Private Sub loadTirePosition()
        Try

            If forReceivingInfo Or forCreateReceiving Then
                tirePositionModel.clearParameter()
                serialNoModel.clearParameter()

                PictureBox3.Visible = True
                Dim c As New ColumnValues

                _initializing(cCol.forTirePosition,
                              c.getValues(),
                              tirePositionModel,
                              allTirePositionBgWorker)

                _initializing(cCol.forTireSerialNo,
                              c.getValues(),
                              serialNoModel,
                              allTirePositionBgWorker)

                cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, allTirePositionBgWorker)

            ElseIf forCreateWithdrawal Or forWithdrawn Then
                serialNoViewModel.clearParameter()
                serialNoModel.clearParameter()

                PictureBox3.Visible = True
                Dim c As New ColumnValues

                _initializing(cCol.forTireSerialNoView,
                            c.getValues(),
                            serialNoViewModel,
                            allTirePositionBgWorker)

                _initializing(cCol.forTireSerialNo,
                              c.getValues(),
                              serialNoModel,
                              allTirePositionBgWorker)

                cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, allTirePositionBgWorker)

            End If


        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub SuccessfullyDone()
        Try
            If forReceivingInfo Or forCreateReceiving Then
                Results.rListOfTirePosition = TryCast(tirePositionModel.cData, List(Of PropsFields.tirePosition_props_fields))
                Results.rListOfTireSerialNo = TryCast(serialNoModel.cData, List(Of PropsFields.tireSerial_props_fields))

                serialNoUI.AutoCompleteData = Results.rListOfTireSerialNo.Select(Function(x) x.serial_no).ToList()
                serialNoUI.set_autocomplete()

            ElseIf forCreateWithdrawal Or forWithdrawn Then
                Results.rListOfTireSerialNoView = TryCast(serialNoViewModel.cData, List(Of PropsFields.tireSerialView_props_fields))
                Results.rListOfTireSerialNo = TryCast(serialNoModel.cData, List(Of PropsFields.tireSerial_props_fields))

                serialNoUI.AutoCompleteData = Results.rListOfTireSerialNo.Select(Function(x) x.serial_no).ToList()
                serialNoUI.set_autocomplete()
            End If


            display()

            PictureBox3.Visible = False
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub display()
        Try
            If forReceivingInfo Or forCreateReceiving Then

                dgvTirePosition.Columns.Clear()
                dgvTirePosition.DataSource = Results.rListOfTirePosition

            ElseIf forCreateWithdrawal Or forWithdrawn Then

                dgvTirePosition.Columns.Clear()
                dgvTirePosition.DataSource = Results.rListOfTireSerialNoView

            End If

            setCustomGridview(dgvTirePosition)

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub setCustomGridview(Optional dgv As DataGridView = Nothing)
        Try
            If forReceivingInfo Or forCreateReceiving Then
                With customDgv
                    If dgv.Name = NameOf(dgvTirePosition) Then
                        'readonly cells
                        If dgv.Rows.Count > 0 Then
                            .subcustomDatagridviewSettings("ReadOnlyCells", dgv, 1)
                            .subcustomDatagridviewSettings("ReadOnlyCells", dgv, 2)
                            .subcustomDatagridviewSettings2("headerText", dgv, NameOf(tp.tire_position_id), 40, "tire_position_id")
                        End If
                    End If

                    .autoSizeColumn(dgv, True)
                End With

                Dim chkCol As New DataGridViewCheckBoxColumn() With {
                    .Name = "Select",                ' column’s internal name
                    .HeaderText = "Select",          ' what shows in the header
                    .Width = 50,                     ' optional sizing
                    .ReadOnly = False             ' allow the user to check/uncheck
                    }

                dgv.Columns.Add(chkCol)

            ElseIf forCreateWithdrawal Or forWithdrawn Then
                With customDgv
                    If dgv.Name = NameOf(dgvTirePosition) Then
                        'readonly cells
                        If dgv.Rows.Count > 0 Then
                            For Each column As DataGridViewColumn In dgv.Columns
                                column.ReadOnly = True
                            Next

                            Dim v As New FCreateWithdrawalSlip.customHeaderProps
                            .subcustomDatagridviewSettings2("headerText", dgv, NameOf(tsnv.rr_no), 80, v.RR_NO)
                            .subcustomDatagridviewSettings2("headerText", dgv, NameOf(tsnv.position), 80, v.POSITION)
                            .subcustomDatagridviewSettings2("headerText", dgv, NameOf(tsnv.remaining_balance), 80, v.REMAINING_BALANCE)
                            .subcustomDatagridviewSettings2("headerText", dgv, NameOf(tsnv.units), 40, v.UNITS)
                            .subcustomDatagridviewSettings2("headerText", dgv, NameOf(tsnv.amounts), 40, v.AMOUNT)
                            .subcustomDatagridviewSettings2("headerText", dgv, NameOf(tsnv.item_desc), 200, v.ITEM_DESC)
                            .subcustomDatagridviewSettings2("headerText", dgv, NameOf(tsnv.serial_no), 200, v.SERIAL_NO)
                        End If

                        For Each col As DataGridViewColumn In dgv.Columns
                            If col.Name = NameOf(tsnv.serial_id) Or
                                col.Name = NameOf(tsnv.properName) Or
                                 col.Name = NameOf(tsnv.item_name) Or
                                  col.Name = NameOf(tsnv.rr_items_id) Or
                                  col.Name = NameOf(tsnv.tire_position_id) Or
                                  col.Name = NameOf(tsnv.serialNo) Then

                                col.Visible = False
                            Else
                                col.Visible = True
                            End If
                        Next

                        .autoSizeColumn(dgv, True)
                    End If
                End With
            End If

            'If dgv.Rows.Count > 0 And dgv.Columns.Count > 0 Then
            '    With dgv.Columns

            '        .Item(NameOf(cn.item_desc)).DisplayIndex = 0
            '        .Item(NameOf(cn.rr_no)).DisplayIndex = 1
            '        .Item(NameOf(cn.serial_no)).DisplayIndex = 2
            '        .Item(NameOf(cn.position)).DisplayIndex = 3
            '        .Item(NameOf(cn.remaining_balance)).DisplayIndex = 4

            '    End With
            'End If

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Sub dgvTirePosition_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTirePosition.CellContentClick

    End Sub

    Private Sub dgvTirePosition_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvTirePosition.CurrentCellDirtyStateChanged
        If TypeOf dgvTirePosition.CurrentCell Is DataGridViewCheckBoxCell Then
            ' This forces the CellValueChanged event to fire as soon as the user clicks
            dgvTirePosition.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub txtSearchItems_TextChanged(sender As Object, e As EventArgs) Handles txtSearchItems.TextChanged
        If forCreateWithdrawal Or forWithdrawn Then
            cSearch = txtSearchItems.Text
        End If

    End Sub

    Private Sub btnReleaseNow_Click(sender As Object, e As EventArgs) Handles btnReleaseNow.Click
        Try

#Region "FILTER"
            'If serialNoUI.ifBlankTexbox() Then
            '    cCustomMsg.message("error", "serial no must be fill...", "SUPPLY INFO:")
            '    Exit Sub
            'End If
#End Region

            If forReceivingInfo Then
                Dim tireSerialNo = Results.rListOfTireSerialNo.Where(Function(x)
                                                                         Return x.serial_no.ToUpper() = txtSearchItems.Text.ToUpper()
                                                                     End Function).ToList()

                With FReceiving_Info.cTireSerialStore

                    'If Not tireSerialNo.Count > 0 Then
                    '    Dim message As String = $"we found out that this serial # is new, {vbCrLf} do you want to continue with this serial # you provide?"
                    '    If Not cCustomMsg.messageYesNo(message, "SUPPLY INFO:", MessageBoxIcon.Question) Then
                    '        Exit Sub
                    '    End If
                    'End If

                    For Each row As DataGridViewRow In dgvTirePosition.Rows

                        If row.Cells("Select").Value = True Then
                            .tire_position_id = row.Cells(NameOf(tsn.tire_position_id)).Value
                            FCreateWithdrawalSlip.txtSerialNo.Text = $"{row.Cells(NameOf(tsn.serial_no)).Value}"
                            Exit For
                        End If
                    Next

                    .serial_no = txtSearchItems.Text
                    FReceiving_Info.txtSerialNo.Text = txtSearchItems.Text

                    If .tire_position_id = 0 Then
                        cCustomMsg.message("error", "you must atleast check 1 row to procceed...", "SUPPLY INFO:")
                        Exit Sub
                    End If
                End With
                Me.Dispose()

            ElseIf forCreateReceiving Then
                Dim tireSerialNo = Results.rListOfTireSerialNo.Where(Function(x)
                                                                         Return x.serial_no.ToUpper() = txtSearchItems.Text.ToUpper()
                                                                     End Function).ToList()

                With FCreateReceiving.cTireSerialStore

                    'If Not tireSerialNo.Count > 0 Then
                    '    Dim message As String = $"we found out that this serial # is new, {vbCrLf} do you want to continue with this serial # you provide?"
                    '    If Not cCustomMsg.messageYesNo(message, "SUPPLY INFO:", MessageBoxIcon.Question) Then
                    '        Exit Sub
                    '    End If
                    'End If

                    For Each row As DataGridViewRow In dgvTirePosition.Rows

                        If row.Cells("Select").Value = True Then
                            .tire_position_id = row.Cells(NameOf(tsn.tire_position_id)).Value
                            FCreateReceiving.txtSerialNo.Text = $"{row.Cells(NameOf(tsnv.position)).Value}"
                            Exit For
                        End If

                    Next

                    .serial_no = txtSearchItems.Text
                    'FCreateReceiving.txtSerialNo.Text = txtSearchItems.Text

                    If .tire_position_id = 0 Then
                        cCustomMsg.message("error", "you must atleast check 1 row to procceed...", "SUPPLY INFO:")
                        Exit Sub
                    End If
                End With
                Me.Dispose()

            ElseIf forCreateWithdrawal Then

                If Results.rListOfTireSerialNoView.Count > 0 Then
                    Dim tireSerialNoData = Results.rListOfTireSerialNoView.Where(Function(x)
                                                                                     Return x.serial_id = dgvTirePosition.SelectedRows(0).Cells(NameOf(tsnv.serial_id)).Value
                                                                                 End Function).ToList()

                    If tireSerialNoData.Count > 0 Then
                        With FCreateWithdrawalSlip
                            .cTireSerialStore = tireSerialNoData(0)

                            .txtSerialNo.Text = tireSerialNoData(0).serial_no
                            .tireSerialNoUI.resetBgColor()

                            .lblTireRemaining.Text = $"remaining: {tireSerialNoData(0).remaining_balance} {tireSerialNoData(0).units}"

                            .txtAmount.Text = tireSerialNoData(0).amounts
                            .amountUI.resetBgColor()

                            .txtWsNo.Focus()
                        End With
                    End If

                End If
                Me.Dispose()

            ElseIf forWithdrawn Then

                Dim selectedRow = dgvTirePosition.SelectedRows(0)

                Dim serial_id As Integer = selectedRow.Cells(NameOf(cn.serial_id)).Value
                Dim serial_no As String = selectedRow.Cells(NameOf(cn.serial_no)).Value
                Dim balance As Double = selectedRow.Cells(NameOf(cn.remaining_balance)).Value

                If balance = 0 Then
                    cCustomMsg.message("error", "No remaining balance for this item.", "SUPPLY INFO:")
                    Exit Sub
                End If

                FWithdrawnItems.cPartiallyWithdrawnStorage.serial_id = serial_id
                FWithdrawnItems.txtSerialNo.Text = serial_no
                FWithdrawnItems.tireSerialNoUI.resetBgColor()

                FWithdrawnItems.partialQtyUI.tbox.Text = 1
                FWithdrawnItems.partialQtyUI.resetBgColor()
                FWithdrawnItems.partialQtyUI.tbox.Enabled = False

                Me.Dispose()
            End If

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub debounce_new_Tick(sender As Object, e As EventArgs) Handles debounce_new.Tick
        Try
            debounce_new.Stop()

            Dim searchResult
            searchResult = Results.rListOfTireSerialNoView.Where(Function(x)
                                                                     Dim output As String = x.item_desc.ToUpper() &
                                                                      " " & x.rr_no.ToUpper() &
                                                                      " " & x.serial_no.ToUpper()
                                                                     Return output.Contains(cSearch.ToUpper())

                                                                 End Function).
                                       OrderBy(Function(x) x.rr_no).
                                       ThenBy(Function(x) x.serial_no).ToList()


            If searchResult.Count > 0 Then
                dgvTirePosition.DataSource = searchResult
            Else
                If cSearch = serialNoUI.placeHolder Then
                    dgvTirePosition.DataSource = Results.rListOfTireSerialNoView
                End If

            End If

            PictureBox3.Visible = False
            setCustomGridview(dgvTirePosition)
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub dgvTirePosition_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTirePosition.CellValueChanged
        ' Make sure it’s our checkbox column, and a real row
        If e.RowIndex >= 0 AndAlso
           dgvTirePosition.Columns(e.ColumnIndex).Name = "Select" Then

            ' If the new value is True, clear all the others
            Dim isChecked As Boolean =
                Convert.ToBoolean(dgvTirePosition.Rows(e.RowIndex) _
                                  .Cells("Select").Value)

            If isChecked Then
                For i As Integer = 0 To dgvTirePosition.Rows.Count - 1
                    If i <> e.RowIndex Then
                        dgvTirePosition.Rows(i).Cells("Select").Value = False
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub txtSearchItems_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearchItems.KeyDown
        Try
            If forCreateWithdrawal Or forWithdrawn Then
                If txtSearchItems.TextLength > 0 Then
                    PictureBox3.Visible = True
                    debounce_new.Start()
                Else
                    PictureBox3.Visible = True
                    cSearch = ""
                    debounce_new.Start()

                End If

                If e.KeyCode = Keys.Down Then
                    If txtSearchItems.SelectionStart = txtSearchItems.TextLength Then
                        dgvTirePosition.Focus()
                    End If
                End If
            End If

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Sub FTireSerial_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Dispose()
    End Sub
End Class