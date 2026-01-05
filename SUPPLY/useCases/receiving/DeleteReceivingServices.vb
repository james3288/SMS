Imports System.Data.SqlClient

Public Class DeleteReceivingServices
    Private _repo As New PropsFields.Create_receiving_for_dr_props_fields
    Dim customMsg As New customMessageBox
    Public Function ExecuteWithReturnBoolean(rrData As ReceivingModel.COLUMNS) As Boolean
        Try
            Dim remove_rr As New CreateReceivingModel


            Dim removed As Boolean = remove_rr.remove_receiving(rrData)

            Return removed

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function ExecuteIncludingTireWithReturnBoolean(rrData As ReceivingModel.COLUMNS) As Boolean
        Try
            Dim remove_rr As New CreateReceivingModel


            Dim removed As Boolean = remove_rr.remove_receiving_including_tireSerial(rrData)

            Return removed

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function


End Class
