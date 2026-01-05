Public Class PrintPurchaseOrderServices
    Private customMsg As New customMessageBox
    Public cPoStatus As New PRINT_STATUS

    Public Class PRINT_STATUS
        Public ReadOnly Property PRINTED As String = "PRINTED"
        Public ReadOnly Property FOR_PRINTING As String = "FOR PRINTING"
    End Class
    Public Function ExecutePrintedWithReturnTrue(po_details_id As Integer) As Boolean
        Try
            Dim printPo As New ColumnValuesObj
            printPo.add("print_status", cPoStatus.PRINTED)
            printPo.add("print_date_logs", Date.Parse(Now))
            printPo.add("user_id_logs", pub_user_id)
            printPo.setCondition($"po_det_id = {po_details_id}")

            ExecutePrintedWithReturnTrue = printPo.updateQuery_return_true("dbPO_details", False)
            Return ExecutePrintedWithReturnTrue

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function ExecuteForPrintingWithReturnTrue(po_details_id As Integer) As Boolean
        Try
            Dim printPo As New ColumnValuesObj
            printPo.add("print_status", cPoStatus.FOR_PRINTING)
            printPo.add("user_id_logs", pub_user_id)
            printPo.setCondition($"po_det_id = {po_details_id}")

            ExecuteForPrintingWithReturnTrue = printPo.updateQuery_return_true("dbPO_details", False)
            Return ExecuteForPrintingWithReturnTrue

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function ExecuteUpdateForPrintingToPrintedWithReturnTrue(po_details_id As Integer)
        Dim printPo As New ColumnValuesObj
        printPo.add("print_status", cPoStatus.PRINTED)
        printPo.add("user_id_logs", pub_user_id)
        printPo.add("print_date_logs", Date.Parse(Now))

        printPo.setCondition($"po_det_id = {po_details_id}")

        ExecuteUpdateForPrintingToPrintedWithReturnTrue = printPo.updateQuery_return_true("dbPO_details", False)
        Return ExecuteUpdateForPrintingToPrintedWithReturnTrue
    End Function

    Public Function ExecuteUpdateForRePrintWithReturnTrue(po_details_id As Integer)
        Dim printPo As New ColumnValuesObj
        printPo.add("user_id_update_logs", pub_user_id)
        printPo.add("up_prnt_dt_logs", Date.Parse(Now))

        printPo.setCondition($"po_det_id = {po_details_id}")

        ExecuteUpdateForRePrintWithReturnTrue = printPo.updateQuery_return_true("dbPO_details", False)
        Return ExecuteUpdateForRePrintWithReturnTrue
    End Function
End Class
