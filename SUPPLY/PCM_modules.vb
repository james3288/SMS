Imports System.Data.Sql
Imports System.Data.SqlClient
Module PCM_modules
    Public SQLcon As New SQLcon ' new declaration sa sqlconnection
    Public sqldr As SqlDataReader
    Public project_code As String

    Sub view_requisition_slip_item_details(ByVal rs_id As Integer, ByVal item_details_id As Integer, txtProject As TextBox, ByVal txtItemDetails As TextBox)

        Dim query As String = $"SELECT a.requisition_slip_item_details_id
	                                ,d.item_no
	                                ,b.item_details_description
	                                ,c.item_list_description
	                                ,f.project_id
	                                ,f.project_code
	                                ,a.rs_id
	                                ,a.item_details_id
                                  FROM [PCMBS].[dbo].[RequisitionSlipItemDetails] a
                                  inner join [PCMBS].[dbo].[ItemDetails] b on b.item_details_id = a.item_details_id
                                  inner join [PCMBS].[dbo].[ItemList] c on c.item_list_id = b.item_list_id
                                  inner join [PCMBS].[dbo].[Items] d on d.item_id = c.item_id
                                  left join [PCMBS].[dbo].[VariationOrder] e on e.variation_order_id = c.variation_order_id
                                  left join [PCMBS].[dbo].[Projects] f on f.project_id = e.project_id
                                  where a.rs_id = {rs_id}
                                  and a.status = 'active'"
        Try
            Dim cmd As SqlCommand
            SQLcon.connection.Open()
            cmd = New SqlCommand(query, SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.Text
            sqldr = cmd.ExecuteReader
            While sqldr.Read
                txtProject.Text = sqldr(5).ToString
                txtItemDetails.Text = sqldr(1).ToString.ToUpper & " - " & sqldr(2).ToString
                item_details_id = sqldr(7)
            End While
            sqldr.Close()
        Catch ex As Exception
            MsgBox("Something is Wrong in viewing in RequisitionSlipItemDetails")
            MsgBox(ex.Message)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub
    Sub insert_requisition_slip_item_details(ByVal item_details_id As Integer, ByVal rs_id As Integer)
        Dim query As String = $"insert into [PCMBS].[dbo].[RequisitionSlipItemDetails] 
                                ([item_details_id]
                                  ,[rs_id]
                                  ,[rs_no]
                                  ,[description]
                                  ,[status]
                                  ,[date_time_created]
                                  ,[user_created])
                                SELECT
									{item_details_id}
									,rs_id
									,[rs_no]
									,[item_desc]
									,'active'
									,GETDATE()
									,{pub_user_id}
                                FROM [dbrequisition_slip]
                                where rs_id = {rs_id}"
        'Console.Write(query)
        Try
            Dim cmd As SqlCommand
            SQLcon.connection.Open()
            cmd = New SqlCommand(query, SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.Text

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("Something is Wrong in inserting in RequisitionSlipItemDetails")
            MsgBox(ex.Message)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub
    Sub update_requisition_slip_item_details(ByVal item_details_id As Integer, ByVal rs_id As Integer)
        Dim update_query As String = $"update [PCMBS].[dbo].[RequisitionSlipItemDetails]
                                    set status = 'inactive'
                                        ,date_time_updated = GETDATE()
                                        ,user_updated = {pub_user_id}
                                    where rs_id = {rs_id}
                                    and status = 'active'"
        Try
            Dim cmd As SqlCommand
            SQLcon.connection.Open()
            cmd = New SqlCommand(update_query, SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.Text

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("Something is Wrong in updating in RequisitionSlipItemDetails")
            MsgBox(ex.Message)
        Finally
            SQLcon.connection.Close()
        End Try

        'Dim insert_query As String = $"insert into [PCMBS].[dbo].[RequisitionSlipItemDetails] 
        '                        ([item_details_id]
        '                          ,[rs_id]
        '                          ,[rs_no]
        '                          ,[description]
        '                          ,[status]
        '                          ,[date_time_created]
        '                          ,[user_created])
        '                        SELECT
        '	{item_details_id}
        '	,rs_id
        '	,[rs_no]
        '	,[item_desc]
        '	,'active'
        '	,GETDATE()
        '	,{pub_user_id}
        '                        FROM [dbrequisition_slip]
        '                        where rs_id = {rs_id}"
        'Try
        '    Dim cmd As SqlCommand
        '    SQLcon.connection.Open()
        '    cmd = New SqlCommand(insert_query, SQLcon.connection)
        '    cmd.Parameters.Clear()
        '    cmd.CommandType = CommandType.Text

        '    cmd.ExecuteNonQuery()

        'Catch ex As Exception
        '    MsgBox("Something is Wrong in inserting after updating in RequisitionSlipItemDetails")
        '    MsgBox(ex.Message)
        'Finally
        '    SQLcon.connection.Close()
        'End Try

    End Sub

    Sub update_requisition_slip_item_details_non_item(ByVal item_details_id As Integer, ByVal rs_id As Integer)
        Dim update_query As String = $"update [PCMBS].[dbo].[RequisitionSlipItemDetails]
                                    set status = 'inactive'
                                        ,date_time_updated = GETDATE()
                                        ,user_updated = {pub_user_id}
                                    where rs_id = {rs_id}
                                    and status = 'active'"
        Try
            Dim cmd As SqlCommand
            SQLcon.connection.Open()
            cmd = New SqlCommand(update_query, SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.Text

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("Something is Wrong in updating in RequisitionSlipItemDetails")
            MsgBox(ex.Message)
        Finally
            SQLcon.connection.Close()
        End Try

        Dim insert_query As String = $"insert into [PCMBS].[dbo].[RequisitionSlipItemDetails] 
                                ([item_details_id]
                                  ,[rs_id]
                                  ,[rs_no]
                                  ,[description]
                                  ,[status]
                                  ,[date_time_created]
                                  ,[user_created])
                                SELECT
        	{item_details_id}
        	,rs_id
        	,[rs_no]
        	,[item_desc]
        	,'active'
        	,GETDATE()
        	,{pub_user_id}
                                FROM [dbrequisition_slip]
                                where rs_id = {rs_id}"
        Try
            Dim cmd As SqlCommand
            SQLcon.connection.Open()
            cmd = New SqlCommand(insert_query, SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.Text

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("Something is Wrong in inserting after updating in RequisitionSlipItemDetails")
            MsgBox(ex.Message)
        Finally
            SQLcon.connection.Close()
        End Try

    End Sub
End Module
