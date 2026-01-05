Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FReceiving_Create_New_Item
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For Each row As ListViewItem In lvlCreate_New_Item.Items
            If row.Checked = True Then

                'col_wh_id 4
                'col_unit 3
                'col_item_name 1
                'col_item_desc 2
                'col_rs_id 0


                '0. check if data already exist
                If if_new_item_exist(row.SubItems(1).Text, row.SubItems(2).Text) > 0 Then
                    'if exist
                    MessageBox.Show("This data '" & row.SubItems(1).Text & " - " & row.SubItems(2).Text & vbCrLf & "' was already exist in the database..", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
                Else
                    'if not exist
                    '1.save first and get the wh_id
                    Dim wh_id As Integer = save_and_get_wh_id(row.SubItems(4).Text, row.SubItems(3).Text, row.SubItems(1).Text, row.SubItems(2).Text)

                    '2. update data from rs
                    Dim newSQ As New SQLcon
                    Dim newCMD As SqlCommand

                    Try
                        newSQ.connection.Open()
                        newCMD = New SqlCommand("proc_requisition_slip", newSQ.connection)
                        newCMD.Parameters.Clear()
                        newCMD.CommandType = CommandType.StoredProcedure

                        newCMD.Parameters.AddWithValue("@n", 38)
                        newCMD.Parameters.AddWithValue("@wh_id", wh_id)
                        newCMD.Parameters.AddWithValue("@rs_id", row.Text)

                        newCMD.ExecuteNonQuery()

                    Catch ex As Exception
                        MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        newSQ.connection.Close()

                        If button_click_name = "CreateNewItemsAndUpdateToolStripMenuItem" Then
                            FReceivingReportList.btnSearch.PerformClick()
                        End If
                    End Try
                End If
            End If
        Next

        Me.Close()

    End Sub
    Private Function if_new_item_exist(new_item_name As String, new_Pitem_desc As String) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_requisition_slip", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 39)
            newCMD.Parameters.AddWithValue("@whItem", new_item_name)
            newCMD.Parameters.AddWithValue("@whItemDesc", new_Pitem_desc)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                If newDR.Item(0).ToString = "" Then
                    if_new_item_exist = 0
                Else
                    if_new_item_exist = newDR.Item(0).ToString
                End If
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Private Function save_and_get_wh_id(wh_id As Integer, unit As String, item_name As String, item_desc As String) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim whItem As String = ""
        Dim whItemDesc As String = ""
        Dim whClass As String = ""
        Dim whArea As String = ""
        Dim whSpecificLoc As String = ""
        Dim whIncharge As String = ""
        Dim whReorderPoint As Integer
        Dim default_price As Integer
        Dim typeOfItem As String = ""
        Dim tsp_id As Integer = 0
        Dim set_det_id As Integer = 0
        Dim turnover As String = ""
        Dim division As String = ""

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_requisition_slip", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 36)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)

            newDR = newCMD.ExecuteReader

            Dim a(10) As String

            'copy the existing data from wh
            While newDR.Read
                'whItem = newDR.Item("").ToString
                'whItemDesc = newDR.Item("").ToString
                whClass = newDR.Item("whClass").ToString
                whArea = newDR.Item("whArea").ToString
                whSpecificLoc = newDR.Item("whSpecificLoc").ToString
                whIncharge = newDR.Item("whIncharge").ToString
                whReorderPoint = newDR.Item("whReorderPoint").ToString
                default_price = newDR.Item("default_price").ToString
                unit = newDR.Item("unit").ToString
                typeOfItem = newDR.Item("typeOfItem").ToString
                tsp_id = newDR.Item("tsp_id").ToString
                set_det_id = newDR.Item("set_det_id").ToString
                turnover = newDR.Item("turnover").ToString
                division = newDR.Item("division").ToString

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_requisition_slip", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 37)
            newCMD.Parameters.AddWithValue("@whItem", item_name)
            newCMD.Parameters.AddWithValue("@whItemDesc", item_desc)
            newCMD.Parameters.AddWithValue("@whClass", whClass)
            newCMD.Parameters.AddWithValue("@whArea", whArea)
            newCMD.Parameters.AddWithValue("@whSpecificLoc", whSpecificLoc)
            newCMD.Parameters.AddWithValue("@whIncharge", whIncharge)
            newCMD.Parameters.AddWithValue("@whReorderPoint", whReorderPoint)
            newCMD.Parameters.AddWithValue("@default_price", default_price)
            newCMD.Parameters.AddWithValue("@unit", unit)
            newCMD.Parameters.AddWithValue("@typeOfItem", typeOfItem)
            newCMD.Parameters.AddWithValue("@tsp_id", tsp_id)
            newCMD.Parameters.AddWithValue("@set_det_id", set_det_id)
            newCMD.Parameters.AddWithValue("@division", division)
            newCMD.Parameters.AddWithValue("@turnover", turnover)

            save_and_get_wh_id = newCMD.ExecuteScalar()


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Function

    Private Sub FReceiving_Create_New_Item_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class