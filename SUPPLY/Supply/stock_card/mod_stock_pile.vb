Module mod_stock_pile

    Structure ls
        Dim wh_id As Integer
        Dim balance As Double
        Dim items As String
        Dim wharea As String
        Dim source As String
    End Structure
    Public cListOfStockPile_Final As New List(Of ls)
End Module
