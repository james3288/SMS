Imports System.Data.SqlClient

Public Class CreateDeliveryReceiptForWithdrawalServices
    Private _repo As New PropsFields.create_dr_info_fields
    Dim customMsg As New customMessageBox
    Public Function ExecuteWithReturnId(drInfo As PropsFields.create_dr_info_fields,
                                        drData As PropsFields.create_dr_info_fields) As Integer
        Dim newSQLcon As New SQLcon
        Dim transaction As SqlTransaction = Nothing
        Try

            Dim CREATERDR As New DeliveryReciptModel

            newSQLcon.connection.Open()
            transaction = newSQLcon.connection.BeginTransaction()
            Dim dr_info_id As Integer = CREATERDR.save_dr_info(drInfo, newSQLcon, transaction)

            Dim dr_details_id As Integer = CREATERDR.save_dr_details(dr_info_id,
                                                                     drData,
                                                                     newSQLcon,
                                                                     transaction)

            transaction.Commit()
            Return dr_details_id

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
