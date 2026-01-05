Public Class DeleteDeliveryReceiptServices
    Private cCustomMsg As New customMessageBox
    Private cWsRepo As New List(Of PropsFields.dr_ws_props_fields)
    Private cPoRepo As New List(Of PropsFields.dr_po_props_fields)


    Public Sub initialize_ws(wsData As List(Of PropsFields.dr_ws_props_fields))
        cWsRepo = wsData
    End Sub

    Public Sub initialize_po(poData As List(Of PropsFields.dr_po_props_fields))
        cPoRepo = poData
    End Sub

    Public Function ExecuteWithReturnBoolean(drData As PropsFields.dr_list_props_fields,
                                             Optional listOfDrData As List(Of PropsFields.dr_list_props_fields) = Nothing) As Boolean
        Try
            Dim remove_dr As New DeliveryReciptModel

            remove_dr.initialize_ws(cWsRepo)
            remove_dr.initialize_po(cPoRepo)

            Dim removed As Boolean = remove_dr.deleteDeliveryReceipt(drData, listOfDrData)

            Return removed

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Function

End Class
