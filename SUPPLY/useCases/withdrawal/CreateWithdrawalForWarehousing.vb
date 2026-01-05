Imports System.Data.SqlClient

Public Class CreateWithdrawalForWarehousing
    Private _repo As New PropsFields.Create_withdrawal_slip_for_dr_props_fields
    Dim customMsg As New customMessageBox
    Public Function ExecuteWithReturnId(wsDatas As PropsFields.Create_withdrawal_slip_for_dr_props_fields,
                                        Optional rs_id As Integer = 0) As Integer
        Dim newSQLcon As New SQLcon
        Dim transaction As SqlTransaction = Nothing
        Try
            _repo = wsDatas

            Dim CREATEWSFORDR As New CreateWithdrawalSlipForDrModel

            newSQLcon.connection.Open()
            transaction = newSQLcon.connection.BeginTransaction()
            Dim ws_info_id As Integer = CREATEWSFORDR.save_withdrawal_info(_repo, newSQLcon, transaction)

            Dim ws_details_id As Integer = CREATEWSFORDR.save_withdrawal_details(ws_info_id, _repo, newSQLcon, transaction)

            transaction.Commit()
            Return ws_details_id

        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If

            customMsg.ErrorMessage(ex)
        Finally
            newSQLcon.connection.Close()
        End Try

    End Function

End Class
