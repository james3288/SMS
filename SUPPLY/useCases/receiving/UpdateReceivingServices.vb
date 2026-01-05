Imports System.Data.SqlClient

Public Class UpdateReceivingServices
    Private _repo As New PropsFields.Create_receiving_for_dr_props_fields
    Dim customMsg As New customMessageBox
    Private _tireRepo As New PropsFields.tireSerial_props_fields
    Private cOthersCategory As New OTHERSCATEGORY

    Public Function ExecuteWithReturnBoolean(rrDatas As PropsFields.Create_receiving_for_dr_props_fields,
                                       Optional rrDetailsDatas As List(Of PropsFields.Receiving_row) = Nothing) As Boolean
        Dim newSQLcon As New SQLcon
        Dim transaction As SqlTransaction = Nothing
        Try
            _repo = rrDatas

            Dim UPDATERR As New CreateReceivingModel

            newSQLcon.connection.Open()
            transaction = newSQLcon.connection.BeginTransaction()

            'update rr infos and return rr_info_id
            Dim rr_info_result As Boolean = UPDATERR.update_receiving_info(_repo,
                                                                              newSQLcon,
                                                                              transaction)


            'update rr details and retrun rr_items_id
            UPDATERR.cUserId = rrDatas.user_id
            Dim rr_items_boolean As Boolean = UPDATERR.update_multiple_receiving_details(rrDatas.rr_item_id,
                                                                                             rrDetailsDatas,
                                                                                             newSQLcon,
                                                                                             transaction)
            transaction.Commit()
            Return rr_items_boolean

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
