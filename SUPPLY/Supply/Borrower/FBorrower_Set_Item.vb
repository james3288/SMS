Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FBorrower_Set_Item
    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            'Dim query As String = "UPDATE dbreceiving_items_sub"
            'query &= " SET set_det_id = " & CInt(ListView1.SelectedItems(0).Text)
            'query &= " WHERE rr_item_id = " & CInt(FListofBorrowerItem.lvlBorrowerItem.SelectedItems(0).Text)

            newCMD = New SqlCommand("proc_borrower_new", newSQ.connection)

            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 14)

            newCMD.Parameters.AddWithValue("@rr_item_sub_id", CInt(FListofBorrowerItem.lvlBorrowerItem.SelectedItems(0).Text))
            newCMD.Parameters.AddWithValue("@set_det_id", CInt(ListView1.SelectedItems(0).Text))

            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
            Me.Dispose()

        End Try

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub FBorrower_Set_Item_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_set_details()
    End Sub

    Public Sub load_set_details()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        ListView1.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 15)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim a(5) As String

                a(0) = newDR.Item("set_det_id").ToString
                a(1) = newDR.Item("sub_details").ToString

                Dim lvl As New ListViewItem(a)
                ListView1.Items.Add(lvl)
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Sub
End Class