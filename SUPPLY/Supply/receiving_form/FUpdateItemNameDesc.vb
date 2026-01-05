Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FUpdateItemNameDesc
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For Each row As DataGridViewRow In DataGridView1.Rows

            If row.Cells("Col_Check").Value = True Then
                Dim query As String = "UPDATE dbwarehouse_items SET whItem = '" & row.Cells("Col_Item_Name").Value & "', whItemDesc = '" & row.Cells("Col_Item_Desc").Value & "' WHERE wh_id = " & CInt(row.Cells("Col_Wh_Id").Value)
                UPDATE_INSERT_DELETE_QUERY(query, 0, "UPDATE")
            End If

        Next

        Me.Close()

    End Sub

    Private Sub FindRelatedItemsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FindRelatedItemsToolStripMenuItem.Click
        For Each ctr As Control In Me.Controls
            If ctr.Name = "Panel1" Then
                ctr.Visible = True
            Else
                ctr.Enabled = False
            End If
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        For Each ctr As Control In Me.Controls
            If ctr.Name = "Panel1" Then
                ctr.Visible = False
            Else
                ctr.Enabled = True
            End If
        Next
    End Sub

    Private Sub lvl_whitems_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub FUpdateItemNameDesc_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class