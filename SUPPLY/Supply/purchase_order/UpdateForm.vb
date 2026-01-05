Imports System.Data.SqlClient

Public Class UpdateForm


    Private UIQty, UITypes, UIUnits As New class_placeholder4

    Public qtyPlaceholder As String = "Qty here...."
    Public unitsPlaceholder As String = "Units here...."
    Private optionsTypePlaceHolder As String = "Select Options"
    Public toolTip As String = "qty"


    Public cValueString As String
    Public cValueInteger As Integer
    Public cTypes As Integer

    'Table entity
    Public cTableName As String
    Public cId As Integer
    Public cPoId As Integer
    Public cRsId As Integer

    Public column As String 'table column name | instance: qty
    Public column2 As String 'table column name | instance: unit
    Public cWhereId As String

    Private newMsgBox, customMsg As New customMessageBox
    Dim newWhatToUpdate As New poWhatToUpdateType

    Public isUpdateQtyAndUnit As Boolean

    Private Sub UpdateForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.BackColor = ColorTranslator.FromHtml("#1A1A19")
        panelTop.BackColor = ColorTranslator.FromHtml("#31511E")
        btnUpdate.BackColor = ColorTranslator.FromHtml("#CBDCEB")
        btnUpdate.ForeColor = ColorTranslator.FromHtml("#133E87")

        UIQty.king_placeholder_textbox(qtyPlaceholder, txtQty, Nothing, Panel1, My.Resources.received, True,, toolTip)
        UIUnits.king_placeholder_textbox(unitsPlaceholder, txtUnits, Nothing, Panel1, My.Resources.received, False,,)
        UITypes.king_placeholder_combobox(optionsTypePlaceHolder, cmbTypes, Nothing, Panel1, My.Resources.received, "White",)

        Dim cListOfOptions As New List(Of String)


        With cListOfOptions
            .Add(newWhatToUpdate.qty)
            .Add(newWhatToUpdate.qty_units)
            .Add(newWhatToUpdate.units)
        End With

        cListOfOptions.Sort()

        'add options
        For Each item As String In cListOfOptions
            cmbTypes.Items.Add(item)
        Next

    End Sub
    Private Sub btn_panelExt_Click(sender As Object, e As EventArgs) Handles btn_panelExt.Click
        Me.Dispose()
    End Sub

    Private Sub cmbTypes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTypes.SelectedIndexChanged
        If cmbTypes.Text = newWhatToUpdate.qty Then
            txtQty.Enabled = True
            txtUnits.Enabled = False
            txtQty.Focus()

        ElseIf cmbTypes.Text = newWhatToUpdate.qty_units Then
            txtQty.Enabled = True
            txtUnits.Enabled = True
            txtQty.Focus()

        ElseIf cmbTypes.Text = newWhatToUpdate.units Then
            txtQty.Enabled = False
            txtUnits.Enabled = True
            txtUnits.Focus()

        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        If cmbTypes.Text = "" Or cmbTypes.Text = optionsTypePlaceHolder Then
            newMsgBox.message("error", "You must select an option category first!", "SUPPLY INFO:")
            cmbTypes.Focus()
            Exit Sub
        End If

        If isUpdateQtyAndUnit Then
            updateFunction()
        End If


    End Sub

    Private Sub updateFunction()
        Dim newCol As String = ""

#Region "FILTER"
        'filter if blank
        If UIQty.ifBlankTexbox = True Then
            newMsgBox.message("error", "Qty must not be blank!", "SUPPLY INFO:")

            Exit Sub
        ElseIf (UIUnits.ifBlankTexbox = True And cmbTypes.Text.ToUpper() = newWhatToUpdate.units.ToUpper()) AndAlso
            (UIUnits.ifBlankTexbox = True And cmbTypes.Text.ToUpper() = newWhatToUpdate.qty_units.ToUpper()) Then

            newMsgBox.message("error", "Unit must not be blank!", "SUPPLY INFO:")

            Exit Sub
        End If
#End Region

        'set what columns you want to update
        Dim columnValues As New Dictionary(Of String, Object)()
        Dim updateQtyUnit As New ColumnValuesObj
        Dim updateRsQtyUnit As New ColumnValuesObj

        Select Case cmbTypes.Text
                    'for qty only
            Case newWhatToUpdate.qty

                'columnValues.Add(column, CDbl(txtQty.Text))
                newCol = column

                updateQtyUnit.add(column, CDbl(txtQty.Text))
                updateRsQtyUnit.add(column, CDbl(txtQty.Text))

                    'for qty and units
            Case newWhatToUpdate.qty_units

                'columnValues.Add(column, CDbl(txtQty.Text))
                'columnValues.Add(column2, CStr(txtUnits.Text))
                newCol = $"{column}, {column2}"

                updateQtyUnit.add(column, CDbl(txtQty.Text))
                updateQtyUnit.add(column2, CStr(txtUnits.Text))

                updateRsQtyUnit.add(column, CDbl(txtQty.Text))
                updateRsQtyUnit.add(column2, CStr(txtUnits.Text))

                    'for units only
            Case newWhatToUpdate.units

                'columnValues.Add(column2, CStr(txtUnits.Text))
                newCol = column2

                updateQtyUnit.add(column2, CStr(txtUnits.Text))
                updateRsQtyUnit.add(column2, CStr(txtUnits.Text))

        End Select

        If MessageBox.Show($"Are you sure you want to update { newCol }? Please note that this will also affect the RS quantity and unit.", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then

            'Dim dynamicUpdater As New Model_King_Dynamic_Update()

            Try
                'updateQtyUnit.add("user_id_update_logs", pub_user_id)

                'updateQtyUnit.setCondition($"{cWhereId} = {cId}")

                'Dim resultBoolean As Boolean = updateQtyUnit.updateQuery_return_true(cTableName)
                Dim resultBoolean As Boolean = updatePoRsQtyUnit_and_RsQtyUnit(updateQtyUnit, updateRsQtyUnit)

                If resultBoolean Then
                    newMsgBox.message("info", $"{newCol} Successfully Updated!", "SUPPLY INFO:")
                Else
                    newMsgBox.message("error", "something went wrong in updating data...", "SUS INFO:")
                    Exit Sub
                End If

                'dynamicUpdater.UpdateData(cTableName, columnValues, $"{cWhereId} = {cId}")

                'newMsgBox.message("info", $"{newCol} Successfully Updated!", "SUPPLY INFO:")

                If isUpdateQtyAndUnit Then
                    FPurchasedOrderList.isEditAllPo = True
                    FPurchasedOrderList.cPoDetId = cId
                    FPurchasedOrderList.btnSearch.PerformClick()

                    Me.Dispose()
                End If

            Catch ex As Exception
                newMsgBox.ErrorMessage(ex)
            End Try

        End If
    End Sub

#Region "CRUD"
    Private Function updatePoRsQtyUnit_and_RsQtyUnit(updateQtyUnit As ColumnValuesObj,
                                                     updateRsQtyUnit As ColumnValuesObj) As Boolean
        Dim newSQLcon As New SQLcon
        Dim transaction As SqlTransaction = Nothing

        Try
            newSQLcon.connection.Open()
            transaction = newSQLcon.connection.BeginTransaction()
            Dim resultBoolean, result2Boolean, result3Boolean As Boolean

            'for po
            updateQtyUnit.add("user_id_update_logs", pub_user_id)
            updateQtyUnit.setCondition($"{cWhereId} = {cId}")
            resultBoolean = updateQtyUnit.updateQueryRollBack_and_return_true("dbPO_details", newSQLcon, transaction)

            'for rs
            If customMsg.messageYesNo("Would you also like to update the RS quantity or unit?", "SMS INFO:", MessageBoxIcon.Question) Then
                updateRsQtyUnit.setCondition($"rs_id = {cRsId}")
                result2Boolean = updateRsQtyUnit.updateQueryRollBack_and_return_true("dbrequisition_slip", newSQLcon, transaction)
            End If

            'for po logs
            'update also the date log updated in po
            Dim updateDateLogUpdated As New ColumnValuesObj
            updateDateLogUpdated.add("date_log_updated", Date.Parse(Now))
            updateDateLogUpdated.setCondition($"po_id = {cPoId}")
            result3Boolean = updateDateLogUpdated.updateQueryRollBack_and_return_true("dbPO", newSQLcon, transaction)

            transaction.Commit()

            If resultBoolean And result3Boolean Then
                Return True
            End If

        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If

            customMsg.ErrorMessage(ex)
        Finally
            newSQLcon.connection.Close()
        End Try
    End Function
#End Region
End Class