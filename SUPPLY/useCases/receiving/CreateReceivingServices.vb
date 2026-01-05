Imports System.Data.SqlClient

Public Class CreateReceivingServices
    Private _repo As New PropsFields.Create_receiving_for_dr_props_fields
    Private _tireSerialNosRepo As New List(Of AddTireSerialNoModel.TIRE)
    Dim customMsg As New customMessageBox
    Private _tireRepo As New PropsFields.tireSerial_props_fields
    Private cOthersCategory As New OTHERSCATEGORY
    Public Sub initializeTireSerial(tireSerial As PropsFields.tireSerial_props_fields)
        _tireRepo = tireSerial
    End Sub

    Public Sub initializeListOfTireSerialNo(tireSerialNos As List(Of AddTireSerialNoModel.TIRE))
        _tireSerialNosRepo = tireSerialNos
    End Sub

    Public Function ExecuteWithReturnId(rrDatas As PropsFields.Create_receiving_for_dr_props_fields,
                                       Optional po_det_id As Integer = 0,
                                       Optional rrDetailsDatas As List(Of PropsFields.Receiving_row) = Nothing) As Integer
        Dim newSQLcon As New SQLcon
        Dim transaction As SqlTransaction = Nothing
        Try
            _repo = rrDatas

            Dim CREATERRFORDR As New CreateReceivingModel

            newSQLcon.connection.Open()
            transaction = newSQLcon.connection.BeginTransaction()

            'save rr infos and return rr_info_id
            CREATERRFORDR.cUserId = rrDatas.user_id
            Dim rr_info_id As Integer = CREATERRFORDR.save_receiving_info(_repo,
                                                                              newSQLcon,
                                                                              transaction)


            'save rr details and retrun rr_items_id

            Dim rr_items_id As Integer = CREATERRFORDR.save_multiple_receiving_details(rr_info_id,
                                                                                             rrDetailsDatas,
                                                                                             newSQLcon,
                                                                                             transaction)
            'if for tire stocking
            If rrDatas.tireOption = cOthersCategory.FOR_TIRE_STOCKING Then
                _tireRepo.rr_items_id = rr_items_id

                'save tire serial
                'Dim serial_id As Integer = CREATERRFORDR.save_tire_serial(_tireRepo, newSQLcon, transaction)
                Dim serial_id As Integer = CREATERRFORDR.save_tire_serialNew(_tireSerialNosRepo, _tireRepo, newSQLcon, transaction)
            End If

            transaction.Commit()
            Return rr_items_id

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
