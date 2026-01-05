Public Class ItemCheckedModel
    Private customMsg As New customMessageBox
    Public Function update(itemChecked As PropsFields.item_checked_props_fields) As Boolean
        Try
            Dim cc As New ColumnValuesObj

            With itemChecked
                cc.add("IN_OUT", .inOut)
                cc.add("remarks", .remarks)
                cc.add("type_of_purchasing", .typeOfPurchasing)
                cc.add("warehouse_checker_id", .user_id)
                cc.add("item_checked_user", .user_id)
                cc.add("item_checked_log", Date.Parse(Now))
                cc.add("wh_incharge", .warehouseIncharge)
                cc.add("approved_by", .approved_by)
                cc.add("wh_id", .wh_id)

                cc.setCondition($"rs_id = { .rs_id}")
                update = cc.updateQuery_return_true("dbrequisition_slip")

            End With

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
End Class
