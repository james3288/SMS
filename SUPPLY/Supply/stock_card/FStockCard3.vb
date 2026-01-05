Public Class FStockCard3
    Private customGridview As New CustomGridview
    Private customMsg As New customMessageBox
    Private Sub FStockCard3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim cancelledTransactionValues As New ColumnValues
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Public Sub loadStockCard(wh_id As Integer)

        Dim ee As New StockCardModel
        Dim v As New ColumnValuesObj

        v.add("wh_id", wh_id)
        v.add("beginningBalance", lblBeginningBalance)
        v.add("remBalance", lblRemainingBalance)
        v.add("loading", loadingPanel)
        v.add("datagridview", DataGridView1)
        v.add("view", "datagridview")
        v.add("loading2", PictureBox3)

        ee._initialize2(v.getValues())

        'ee._initialize(wh_id, DataGridView1, lblBeginningBalance, "datagridview", lblRemainingBalance, loadingPanel)

        ee.loadStockcard()

    End Sub

    Private Sub FStockCard3_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Dispose()
    End Sub
End Class