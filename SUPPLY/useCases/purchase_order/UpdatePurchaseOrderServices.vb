Imports System.Data.SqlClient

Public Class UpdatePurchaseOrderServices
    Private _repo As New PropsFields.Create_purchaseOrder_for_dr_props_fields
    Dim customMsg As New customMessageBox

    Public Function ExecuteWithReturnBoolean(poDatas As PropsFields.Create_purchaseOrder_for_dr_props_fields,
                                        Optional rs_id As Integer = 0,
                                        Optional poDetailsDatas As List(Of PropsFields.Purchase_Order_Row) = Nothing) As Boolean
        Dim newSQLcon As New SQLcon
        Dim transaction As SqlTransaction = Nothing
        Try
            _repo = poDatas

            Dim UPDATEPOFORDR As New CreatePurchaseOrderForDrModel

            newSQLcon.connection.Open()
            transaction = newSQLcon.connection.BeginTransaction()
            Dim poInfoResult As Boolean = UPDATEPOFORDR.update_purchaseOrder_info(_repo,
                                                                              newSQLcon,
                                                                              transaction)

            Dim poDetailsResult As Boolean = UPDATEPOFORDR.update_multiple_purchaseOrder_details(poDetailsDatas,
                                                                                             newSQLcon,
                                                                                             transaction)

            transaction.Commit()
            Return poDetailsResult

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
