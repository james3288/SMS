Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FPrices_Item

    Public SQLcon As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader

    Private Sub FPrices_Item_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        get_prices_from_items(wh_id)
        Label9.Text = wh_id

    End Sub

    Public Sub get_prices_from_items(ByVal id As Integer)

        Try
            SQLcon.connection.Open()
            Dim query As String = "SELECT a.wh_id, a.item_desc, a.qty, d.amount,c.desired_qty FROM dbPO_details a"
            query &= " INNER JOIN dbreceiving_items b ON a.rs_id = b.rs_id"
            query &= " INNER JOIN dbreceiving_item_partially c ON c.rr_item_id = b.rr_item_id"
            query &= " INNER JOIN dbreceiving_items_sub d ON d.rr_item_id = b.rr_item_id "
            query &= " WHERE a.wh_id = '" & id & "' "
            cmd = New SqlCommand(query, SQLcon.connection)
            dr = cmd.ExecuteReader

            While dr.Read

                Dim a(10) As String

                Dim qty As Double = dr.Item("desired").ToString

                a(0) = dr.Item("wh_id").ToString
                a(1) = dr.Item("items_desc").ToString

                Dim lvl As New ListViewItem(a)
                lvl_prices.Items.Add(lvl)

            End While
            dr.Close()

        Catch ex As Exception
        Finally
            SQLcon.connection.Close()
        End Try

    End Sub


End Class