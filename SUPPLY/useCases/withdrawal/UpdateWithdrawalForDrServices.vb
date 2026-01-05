Imports System.Data.SqlClient

Public Class UpdateWithdrawalForDrServices
    Private _repo As New PropsFields.Create_withdrawal_slip_for_dr_props_fields
    Dim customMsg As New customMessageBox

    Public Function ExecuteWithReturnTrue(wsDatas As PropsFields.Create_withdrawal_slip_for_dr_props_fields,
                                    Optional rs_id As Integer = 0) As Integer
        Dim newSQLcon As New SQLcon
        Dim transaction As SqlTransaction = Nothing
        Try
            _repo = wsDatas

            Dim UPDATEWSFORDR As New CreateWithdrawalSlipForDrModel

            newSQLcon.connection.Open()
            transaction = newSQLcon.connection.BeginTransaction()
            Dim ws_info_result As Boolean = UPDATEWSFORDR.update_withdrawal_info(_repo,
                                                                           newSQLcon,
                                                                           transaction)

            Dim ws_details_result As Boolean = UPDATEWSFORDR.update_withdrawal_details(_repo,
                                                                                       newSQLcon,
                                                                                       transaction)


            'Dim ws_details_id As Integer = UPDATEWSFORDR.save_withdrawal_details(ws_info_id,
            '_repo,
            'newSQLcon,
            'transaction)

            transaction.Commit()
            Return ws_details_result

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
