Imports System.Data.SqlClient

Public Class class_items
    Public cListOfItems As New List(Of Items)
    Public search As String
    Public search_option As String
    Public Sub item()
        Dim trd As Threading.Thread
        trd = New Threading.Thread(AddressOf get_items)
        trd.Start()
        trd.Join()

    End Sub

    Private Sub get_items()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_get_data_from_warehouse1", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 3)
            newCMD.Parameters.AddWithValue("@item_name", search)
            newCMD.Parameters.AddWithValue("@search_option", search_option)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim myitems As New Items
                With myitems
                    .wh_id = newDR.Item("wh_id").ToString
                    .item_name = newDR.Item("wh_item").ToString
                    .item_desc = newDR.Item("wh_desc").ToString
                    .location = newDR.Item("location").ToString
                    .wh_area = newDR.Item("wh_area").ToString
                    .source_classification = newDR.Item("whClass").ToString

                    cListOfItems.Add(myitems)
                End With

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Public Class Items
        Public Property wh_id As Integer
        Public Property item_name As String
        Public Property item_desc As String
        Public Property wh_area As String
        Public Property location As String
        Public Property source_classification As String

    End Class
End Class
