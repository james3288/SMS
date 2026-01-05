Imports System.Data.SqlClient

Public Class CreatePurchaseOrderServices
    Private _repo As New PropsFields.Create_purchaseOrder_for_dr_props_fields
    Dim customMsg As New customMessageBox

    Public Function ExecuteWithReturnId(poDatas As PropsFields.Create_purchaseOrder_for_dr_props_fields,
                                        Optional rs_id As Integer = 0,
                                        Optional poDetailsDatas As List(Of PropsFields.Purchase_Order_Row) = Nothing) As Integer
        Dim newSQLcon As New SQLcon
        Dim transaction As SqlTransaction = Nothing
        Try
            _repo = poDatas

            Dim CREATEPOFORDR As New CreatePurchaseOrderForDrModel

            newSQLcon.connection.Open()
            transaction = newSQLcon.connection.BeginTransaction()
            Dim po_info_id As Integer = CREATEPOFORDR.save_purchaseOrder_info(_repo,
                                                                              newSQLcon,
                                                                              transaction)

            Dim po_details_id As Integer = CREATEPOFORDR.save_multiple_purchaseOrder_details(po_info_id,
                                                                                             poDetailsDatas,
                                                                                             newSQLcon,
                                                                                             transaction)

            transaction.Commit()
            Return po_details_id

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
