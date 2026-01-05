Imports System.Data.SqlClient
Imports SUPPLY.FCreateDeliveryReceipt

Public Class FCancelServicesForm
    Private remarksUI As New class_placeholder5
    Public cCancelForRs, cUpdateCancelForRs As Boolean
    Public cCancelForPo, cUpdateCancelForPo As Boolean
    Public cCancelForWs, cUpdateCancelForWs As Boolean

    Private customMsg As New customMessageBox
    Public cCancelStorage As New PropsFields.CancelledTransaction

    Private Sub FCancelServicesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        remarksUI.king_placeholder_multipleLine_textbox("Remarks...",
                                                        txtRemarks,
                                                        Nothing,
                                                        Panel7,
                                                        My.Resources.received,,
                                                        remarksUI.cCustomColor.Custom1)

        If cUpdateCancelForRs Or cUpdateCancelForPo Or cUpdateCancelForWs Then
            txtRemarks.Text = cCancelStorage.remarks
        End If

    End Sub

    Private Sub btnSaveWithdrawal_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If cCancelForRs Then

            If customMsg.messageYesNo("Are you sure you want to cancel rs?", "SUPPLY INFO:", MessageBoxIcon.Question) Then
                Dim selectedRow = FRequesitionFormForDR.DataGridView1.SelectedRows(0)
                Dim rsId As Integer = selectedRow.Cells("rs_id").Value
                Dim cancelResult As Integer = cancelRsServices(rsId, txtRemarks.Text)

                If cancelResult > 0 Then
                    customMsg.message("info", "RS successfully cancelled!", "SUPPLY INFO:")
                    FRequesitionFormForDR.getNewDrModel().isCancelRs = True
                    FRequesitionFormForDR.getNewDrModel().cRsId = rsId
                    FRequesitionFormForDR.btnSearch.PerformClick()
                    Me.Dispose()
                Else
                    customMsg.message("error", "something wrong in the query!", "SUPPLY INFO:")
                End If
            End If

        ElseIf cCancelForPo Then

            If customMsg.messageYesNo("Are you sure you want to cancel po?", "SUPPLY INFO:", MessageBoxIcon.Question) Then
                Dim selectedRow = FRequesitionFormForDR.DataGridView1.SelectedRows(0)
                Dim poDetId As Integer = selectedRow.Cells("rs_id").Value
                Dim cancelResult As Integer = cancelPoServices(poDetId, txtRemarks.Text)

                If cancelResult > 0 Then
                    customMsg.message("info", "PO successfully cancelled!", "SUPPLY INFO:")
                    FRequesitionFormForDR.getNewDrModel().isCancelPo = True
                    FRequesitionFormForDR.getNewDrModel().cRsId = poDetId
                    FRequesitionFormForDR.btnSearch.PerformClick()
                    Me.Dispose()
                Else
                    customMsg.message("error", "something wrong in the query!", "SUPPLY INFO:")
                End If
            End If


        ElseIf cCancelForWs Then

            If customMsg.messageYesNo("Are you sure you want to cancel ws?", "SUPPLY INFO:", MessageBoxIcon.Question) Then
                Dim selectedRow = FRequesitionFormForDR.DataGridView1.SelectedRows(0)
                Dim wsId As Integer = selectedRow.Cells("rs_id").Value
                Dim cancelResult As Integer = cancelWsServices(wsId, txtRemarks.Text)

                If cancelResult > 0 Then
                    customMsg.message("info", "WS successfully cancelled!", "SUPPLY INFO:")
                    FRequesitionFormForDR.getNewDrModel().isCancelWs = True
                    FRequesitionFormForDR.getNewDrModel().cRsId = wsId
                    FRequesitionFormForDR.btnSearch.PerformClick()
                    Me.Dispose()
                Else
                    customMsg.message("error", "something wrong in the query!", "SUPPLY INFO:")
                End If
            End If

            ' ===== FOR UPDATE CANCEL =====
        ElseIf cUpdateCancelForPo Then

            If customMsg.messageYesNo("Are you sure you want to update remarks?", "SUPPLY INFO:", MessageBoxIcon.Question) Then
                Dim selectedRow = FRequesitionFormForDR.DataGridView1.SelectedRows(0)
                Dim poDetId As Integer = selectedRow.Cells("rs_id").Value
                Dim cancelResult As Boolean = updateCancelPoServices(poDetId, txtRemarks.Text)

                If cancelResult Then
                    customMsg.message("info", "Successfully Updated!", "SUPPLY INFO:")
                    FRequesitionFormForDR.getNewDrModel().isCancelPo = True
                    FRequesitionFormForDR.getNewDrModel().cRsId = poDetId
                    FRequesitionFormForDR.btnSearch.PerformClick()
                    Me.Dispose()
                Else
                    customMsg.message("error", "something wrong in the query!", "SUPPLY INFO:")
                End If
            End If

        ElseIf cUpdateCancelForWs Then

            If customMsg.messageYesNo("Are you sure you want to update remarks?", "SUPPLY INFO:", MessageBoxIcon.Question) Then
                Dim selectedRow = FRequesitionFormForDR.DataGridView1.SelectedRows(0)
                Dim wsId As Integer = selectedRow.Cells("rs_id").Value

                Dim cancelResult As Boolean = updateCancelWsServices(wsId, txtRemarks.Text)

                If cancelResult Then
                    customMsg.message("info", "Successfully Updated!", "SUPPLY INFO:")
                    FRequesitionFormForDR.getNewDrModel().isCancelWs = True
                    FRequesitionFormForDR.getNewDrModel().cRsId = wsId
                    FRequesitionFormForDR.btnSearch.PerformClick()
                    Me.Dispose()
                Else
                    customMsg.message("error", "something wrong in the query!", "SUPPLY INFO:")
                End If
            End If

        ElseIf cUpdateCancelForRs Then

            If customMsg.messageYesNo("Are you sure you want to update remarks?", "SUPPLY INFO:", MessageBoxIcon.Question) Then
                Dim selectedRow = FRequesitionFormForDR.DataGridView1.SelectedRows(0)
                Dim rsId As Integer = selectedRow.Cells("rs_id").Value
                Dim cancelResult As Boolean = updateCancelRsServices(rsId, txtRemarks.Text)

                If cancelResult Then
                    customMsg.message("info", "Successfully Updated!", "SUPPLY INFO:")
                    FRequesitionFormForDR.getNewDrModel().isCancelRs = True
                    FRequesitionFormForDR.getNewDrModel().cRsId = rsId
                    FRequesitionFormForDR.btnSearch.PerformClick()
                    Me.Dispose()
                Else
                    customMsg.message("error", "something wrong in the query!", "SUPPLY INFO:")
                End If
            End If
        End If
    End Sub

    Private Function cancelRsServices(rs_id As Integer, remarks As String) As Integer
        Try
            Dim cancelRs As New ColumnValuesObj
            cancelRs.add("trans", "RS")
            cancelRs.add("trans_id", rs_id)
            cancelRs.add("remarks", remarks)
            cancelRs.add("user_id_log", pub_user_id)
            cancelRs.add("createdAt", Date.Parse(Now))

            cancelRsServices = cancelRs.insertQuery_and_return_id("dbCancelledTransaction")
            Return cancelRsServices
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
    Private Function cancelPoServices(poDetId As Integer, remarks As String) As Integer

        Dim newSQLcon As New SQLcon
        Dim transaction As SqlTransaction = Nothing

        Try
            Dim cancelPo As New ColumnValuesObj
            Dim cancelPoStatus As New ColumnValuesObj

            newSQLcon.connection.Open()
            transaction = newSQLcon.connection.BeginTransaction()

            cancelPo.add("trans", "PO")
            cancelPo.add("trans_id", poDetId)
            cancelPo.add("remarks", remarks)
            cancelPo.add("user_id_log", pub_user_id)
            cancelPo.add("createdAt", Date.Parse(Now))

            cancelPoStatus.add("cancel_status", 1)
            cancelPoStatus.setCondition($"po_det_id = {poDetId}")

            'cancelPoServices = cancelRs.insertQuery_and_return_id("dbCancelledTransaction")
            cancelPoServices = cancelPo.insertQueryRollBack_and_return_id("dbCancelledTransaction", newSQLcon, Transaction)
            cancelPoStatus.updateQueryRollBack_and_return_true("dbPO_details", newSQLcon, Transaction)

            Transaction.Commit()
            Return cancelPoServices

        Catch ex As Exception
            If Transaction IsNot Nothing Then
                Transaction.Rollback()
            End If

            customMsg.ErrorMessage(ex)
        Finally
            newSQLcon.connection.Close()
        End Try
    End Function
    Private Function cancelWsServices(wsId As Integer, remarks As String) As Integer

        Dim newSQLcon As New SQLcon
        Dim transaction As SqlTransaction = Nothing

        Try
            Dim cancelWs As New ColumnValuesObj
            Dim cancelWsStatus As New ColumnValuesObj

            newSQLcon.connection.Open()
            transaction = newSQLcon.connection.BeginTransaction()

            cancelWs.add("trans", "WS")
            cancelWs.add("trans_id", wsId)
            cancelWs.add("remarks", remarks)
            cancelWs.add("user_id_log", pub_user_id)
            cancelWs.add("createdAt", Date.Parse(Now))

            cancelWsStatus.add("cancel_status", 1)
            cancelWsStatus.setCondition($"po_det_id = {wsId}")

            'cancelPoServices = cancelRs.insertQuery_and_return_id("dbCancelledTransaction")
            cancelWsServices = cancelWs.insertQueryRollBack_and_return_id("dbCancelledTransaction", newSQLcon, transaction)
            cancelWsStatus.updateQueryRollBack_and_return_true("dbPO_details", newSQLcon, transaction)

            transaction.Commit()

            Return cancelWsServices

        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If

            customMsg.ErrorMessage(ex)
        Finally
            newSQLcon.connection.Close()
        End Try
    End Function
    Private Function updateCancelRsServices(rs_id As Integer, remarks As String) As Boolean
        Try
            Dim updateCancelRs As New ColumnValuesObj

            updateCancelRs.add("remarks", remarks)
            updateCancelRs.add("user_id_update_log", pub_user_id)
            updateCancelRs.add("updatedAt", Date.Parse(Now))

            updateCancelRs.setCondition($"trans_id = {rs_id}")

            updateCancelRsServices = updateCancelRs.updateQuery_return_true("dbCancelledTransaction")
            Return updateCancelRsServices

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function updateCancelPoServices(poDetId As Integer, remarks As String) As Boolean
        Try
            Dim updateCancelRs As New ColumnValuesObj

            updateCancelRs.add("remarks", remarks)
            updateCancelRs.add("updatedAt", Date.Parse(Now))
            updateCancelRs.add("user_id_update_log", pub_user_id)

            updateCancelRs.setCondition($"trans_id = {poDetId}")

            updateCancelPoServices = updateCancelRs.updateQuery_return_true("dbCancelledTransaction")
            Return updateCancelPoServices

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function updateCancelWsServices(wsId As Integer, remarks As String) As Boolean
        Try
            Dim updateCancelWs As New ColumnValuesObj

            updateCancelWs.add("remarks", remarks)
            updateCancelWs.add("updatedAt", Date.Parse(Now))
            updateCancelWs.add("user_id_update_log", pub_user_id)

            updateCancelWs.setCondition($"trans_id = {wsId}")

            updateCancelWsServices = updateCancelWs.updateQuery_return_true("dbCancelledTransaction")
            Return updateCancelWsServices

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Sub FCancelServicesForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub
End Class