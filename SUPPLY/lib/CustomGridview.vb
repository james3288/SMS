Public Class CustomGridview
#Region "Custom Datagridview"
    Dim customMsg As New customMessageBox
    Public Sub customDataGridviewCheckBox(Optional dgv As DataGridView = Nothing)

        Dim checkboxColumn As New DataGridViewCheckBoxColumn()
        checkboxColumn.HeaderText = "Select"
        checkboxColumn.Name = "CheckBoxColumn"
        dgv.Columns.Add(checkboxColumn)

    End Sub
    Public Sub customDatagridview(Optional dgv As DataGridView = Nothing,
                                  Optional hexColor As String = "#1B2838",
                                  Optional rowHeight As Integer = 28,
                                  Optional fontSize As Integer = 11)

        ' Set some properties of the DataGridView
        'dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv.RowTemplate.Height = rowHeight
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.MultiSelect = False
        dgv.RowHeadersVisible = False
        dgv.BackgroundColor = ColorTranslator.FromHtml(hexColor)
        dgv.Font = New Font(cFontsFamily.bombardier, fontSize, FontStyle.Regular)

        AddHandler dgv.MouseDown, Sub(sender, e) dataGridView_MouseDown(sender, e, dgv)


    End Sub

    Private Sub dataGridView_MouseDown(sender As Object, e As MouseEventArgs, Optional dgv As DataGridView = Nothing)
        If e.Button = MouseButtons.Right Then
            Dim hitTestInfo As DataGridView.HitTestInfo = dgv.HitTest(e.X, e.Y)

            ' Check if the right-click was on a cell
            If hitTestInfo.Type = DataGridViewHitTestType.Cell Then
                dgv.ClearSelection()
                dgv.Rows(hitTestInfo.RowIndex).Selected = True
            End If
        End If
    End Sub

    Public Sub subcustomDatagridviewSettings(Optional changeType As String = "",
                                             Optional dgv As DataGridView = Nothing,
                                             Optional columIndex As Integer = 0,
                                             Optional width As Integer = 0,
                                             Optional headerText As String = "",
                                             Optional format As String = "",
                                             Optional defaultCellStyleBg As String = "#8d9da0",
                                             Optional defaultCellStyleForeColor As String = "#fff",
                                             Optional alternateRowDefaultStyleBg As String = "#B6C3C7",
                                             Optional alternateRowDefaultForeColor As String = "#000")

        Select Case changeType
            Case "headerText"
                dgv.Columns(columIndex).HeaderText = headerText
                dgv.Columns(columIndex).Width = width

                dgv.Columns(columIndex).DefaultCellStyle.Format = format ' Format date column

            Case "headerTextOnly"
                dgv.Columns(columIndex).HeaderText = headerText

            Case "defaultCellStyle"

                dgv.DefaultCellStyle.BackColor = ColorTranslator.FromHtml(defaultCellStyleBg)
                dgv.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml(defaultCellStyleForeColor)

            Case "alternateRowStyle"
                dgv.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml(alternateRowDefaultStyleBg)
                dgv.AlternatingRowsDefaultCellStyle.ForeColor = ColorTranslator.FromHtml(alternateRowDefaultForeColor)

            Case "ReadOnlyCells"
                For Each column As DataGridViewColumn In dgv.Columns
                    If column.Index = columIndex Then
                        column.ReadOnly = False
                    Else
                        column.ReadOnly = True
                    End If

                Next
        End Select

    End Sub

    Public Sub readOnlyCells(cellsName As String, Optional dgv As DataGridView = Nothing)
        Try
            For Each column As DataGridViewColumn In dgv.Columns
                If column.Name = cellsName Then
                    column.ReadOnly = False
                    Exit For
                Else
                    column.ReadOnly = True
                End If

            Next
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Public Sub readonlyAllCells(dgv As DataGridView)
        Try
            For Each column As DataGridViewColumn In dgv.Columns
                column.ReadOnly = True
            Next
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Public Sub subcustomDatagridviewSettings2(Optional changeType As String = "",
                                             Optional dgv As DataGridView = Nothing,
                                             Optional columnName As String = "",
                                             Optional width As Integer = 0,
                                             Optional headerText As String = "",
                                             Optional format As String = "",
                                             Optional defaultCellStyleBg As String = "#8d9da0",
                                             Optional defaultCellStyleForeColor As String = "#fff",
                                             Optional alternateRowDefaultStyleBg As String = "#B6C3C7",
                                             Optional alternateRowDefaultForeColor As String = "#000")

        Try
            Select Case changeType
                Case "headerText"
                    dgv.Columns(columnName).HeaderText = headerText
                    dgv.Columns(columnName).Width = width
                    dgv.Columns(columnName).DefaultCellStyle.ForeColor = Color.Gray

                'dgv.Columns(columnName).DefaultCellStyle.Format = format' Format date column

                Case "headerTextOnly"
                    dgv.Columns(columnName).HeaderText = headerText

                Case "defaultCellStyle"

                    dgv.DefaultCellStyle.BackColor = ColorTranslator.FromHtml(defaultCellStyleBg)
                    dgv.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml(defaultCellStyleForeColor)

                Case "alternateRowStyle"
                    dgv.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml(alternateRowDefaultStyleBg)
                    dgv.AlternatingRowsDefaultCellStyle.ForeColor = ColorTranslator.FromHtml(alternateRowDefaultForeColor)

                Case "ReadOnlyCells"
                    For Each column As DataGridViewColumn In dgv.Columns
                        'If column(columnName) = columIndex Then
                        '    column.ReadOnly = False
                        'Else
                        '    column.ReadOnly = True
                        'End If

                    Next
            End Select
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Sub

    Public Sub customDatagridviewHideColumn(Optional dgv As DataGridView = Nothing, Optional columnName As String = "", Optional visible As Boolean = True)
        Try
            dgv.Columns(columnName).Visible = visible
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Sub

    Public Sub rowFocus(dgv As DataGridView, cellName As String, cellValue As String)

        For Each row As DataGridViewRow In dgv.Rows
            If row.Cells(cellName).Value IsNot Nothing AndAlso row.Cells(cellName).Value.ToString() = cellValue Then
                dgv.ClearSelection()
                row.Selected = True
                dgv.CurrentCell = row.Cells(0)
                Exit For
            End If
        Next
    End Sub

    Public Sub autoSizeColumn(dgv As DataGridView, autoSize As Boolean)
        If autoSize Then
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Else
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        End If

    End Sub

    Public Sub customHeader(dgv As DataGridView)
        dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1A1A1A")
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#FEF9EC")
        dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' Remove column header border
        dgv.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None

        ' (Optional) remove row header border as well
        'dgv.AdvancedRowHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None
    End Sub

    Public Sub isDisableResizeRowHeight(dgv As DataGridView, Optional _disable As Boolean = False)
        Try
            dgv.AllowUserToResizeRows = _disable
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
#End Region
End Class
