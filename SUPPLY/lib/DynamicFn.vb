Public Class DynamicFn
    Public cWhatColumn As Integer
    Public cDict As New Dictionary(Of String, Object)
    Private customMsg As New customMessageBox

    Public Function _getStockCardDatas() As Double
        _getStockCardDatas = New Double


        Try
            Dim ee As New StockCardModel

            ee.loadStockcard()
            _getStockCardDatas = ee.getStockCardBalance()

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try


    End Function
End Class
