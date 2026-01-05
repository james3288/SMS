Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class ViewPriceHistory
    Public SQ As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Public public_query As String
    Private Sub ViewPriceHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_ViewPriceHistory()
    End Sub
    Public Sub load_ViewPriceHistory()
        lvlViewPriceHistory.Items.Clear()

        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_view_price_history_list_item"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@wh_id", lblwh_id.Text)
            dr = sqlcomm.ExecuteReader
            While dr.Read
                Dim a(20) As String
                a(0) = dr.Item(0).ToString
                a(1) = dr.Item(1).ToString
                a(2) = dr.Item(2).ToString
                a(3) = Format(Date.Parse(dr.Item(3).ToString), "MM/dd/yyyy")
                a(4) = dr.Item(4).ToString
                a(5) = FormatNumber(CDbl(dr.Item(5).ToString), 2,,, TriState.True)

                Dim lvl As New ListViewItem(a)
                lvlViewPriceHistory.Items.Add(lvl)

            End While
            dr.Close()
            ' MsgBox("tes")
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Public Sub compare_date(ByVal y As DateTime)
        Dim newSq As New SQLcon
        Try
            newSq.connection.Open()
            Dim sqlcomm As New SqlCommand
            Dim newdr As SqlDataReader

            sqlcomm.Connection = newSq.connection
            sqlcomm.CommandText = "sp_view_price_history_list_item"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 2)
            newdr = sqlcomm.ExecuteReader
            While newdr.Read
                Dim a(20) As String
                'a(0) = dr.Item(0).ToString
                'a(1) = dr.Item(1).ToString
                'a(2) = dr.Item(2).ToString
                'a(3) = dr.Item(3).ToString
                If y > newdr.Item(2).ToString Or y = newdr.Item(2).ToString Then
                    a(2) = y

                End If

                Dim lvl As New ListViewItem(a)
                lvlViewPriceHistory.Items.Add(lvl)





            End While
            newdr.Close()
            MsgBox("tes")
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSq.connection.Close()
        End Try
    End Sub
End Class