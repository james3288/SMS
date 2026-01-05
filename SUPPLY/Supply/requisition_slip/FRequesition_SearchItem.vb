Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FRequesition_SearchItem
    Dim timer As Integer

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        timer = 0
        Timer1.Start()
        Timer2.Start()


    End Sub
    Private Sub item_search()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_requisition_search_item", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 1)
            newCMD.Parameters.AddWithValue("@search", txtSearch.Text)
            newCMD.Parameters.AddWithValue("@division", FRequistionForm.cmbDivision.Text)

            newCMD.CommandTimeout = 100

            newDR = newCMD.ExecuteReader
            Dim a(10) As String
            lvlSearchItem.Items.Clear()

            While newDR.Read
                'a(0) = newDR.Item("wh_id").ToString
                a(1) = newDR.Item("Item_Name").ToString
                a(2) = newDR.Item("Item_Desc").ToString

                Dim lvl As New ListViewItem(a)
                lvlSearchItem.Items.Add(lvl)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        timer += 1
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If timer = 2 Then
            If txtSearch.Text = "" Then
                timer = 0
                Timer1.Stop()
            Else
                item_search()
                timer = 0
                Timer1.Stop()
            End If



        End If
    End Sub

    Private Sub lvlSearchItem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvlSearchItem.SelectedIndexChanged

    End Sub

    Private Sub lvlSearchItem_DoubleClick(sender As Object, e As EventArgs) Handles lvlSearchItem.DoubleClick

        requisition_item_name = lvlSearchItem.SelectedItems(0).SubItems(1).Text
        requisition_item_desc = lvlSearchItem.SelectedItems(0).SubItems(2).Text

        FRequestField.txtItemDesc.Text = lvlSearchItem.SelectedItems(0).SubItems(1).Text & " " & lvlSearchItem.SelectedItems(0).SubItems(2).Text
        FRequestField.txtItemDesc.Focus()

        Me.Close()

    End Sub


End Class